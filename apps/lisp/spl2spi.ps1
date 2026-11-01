param([Parameter(Mandatory)] [string] $In, [Parameter(Mandatory)] [string] $Out)
$ErrorActionPreference = 'Stop'
$token = [regex]'\G\s*(?:(;[^\n]*)|(\()|(\))|("(?:\\.|[^"\\])*")|([^\s()";]+))'
$infix = @('=', '+', '-', '*', '<>', '<', '>', '<=', '>=', '&&', '||')

function Read-Forms([string] $Text) {
    $Text = $Text.Replace([string][char]0x201C, '"').Replace([string][char]0x201D, '"')
    $stack = [Collections.Generic.Stack[object]]::new()
    $top = [Collections.Generic.List[object]]::new()
    $pos = 0
    while ($pos -lt $Text.Length) {
        $m = $token.Match($Text, $pos)
        if (-not $m.Success -or $m.Index + $m.Length -eq $pos) {
            if ($Text.Substring($pos).Trim() -eq '') { break }
            throw "bad token at ${pos}: $($Text.Substring($pos, [Math]::Min(20, $Text.Length - $pos)))"
        }
        $pos = $m.Index + $m.Length
        if ($m.Groups[1].Success) { continue }
        if ($m.Groups[2].Success) { $stack.Push($top); $top = [Collections.Generic.List[object]]::new() }
        elseif ($m.Groups[3].Success) {
            if (-not $stack.Count) { throw "unbalanced ) at $pos" }
            $done = $top; $top = $stack.Pop(); $top.Add($done)
        }
        elseif ($m.Groups[4].Success) { $top.Add([Tuple[string, string]]::new('str', $m.Groups[4].Value)) }
        elseif ($m.Groups[5].Success) { $top.Add($m.Groups[5].Value) }
    }
    if ($stack.Count) { throw 'unbalanced (' }
    , $top
}

function Test-List($x) { $x -is [Collections.Generic.List[object]] }
function Test-Str($x) { $x -is [Tuple[string, string]] }
function Test-Ctor($x) { $x -is [string] -and $x.Length -and [char]::IsUpper($x[0]) }
function Get-Rest($x, [int] $from) {
    $rest = [Collections.Generic.List[object]]::new()
    for ($i = $from; $i -lt $x.Count; $i++) { $rest.Add($x[$i]) }
    , $rest
}

function Format-Type($t, [bool] $Nested = $false) {
    if ($t -is [string]) { return $t }
    if (-not $t.Count) { return '()' }
    $head = $t[0]; $args_ = Get-Rest $t 1
    $h = if ($head -is [string]) { $head } else { $null }
    if ($h -eq '->') { $s = ($args_ | ForEach-Object { if ((Test-List $_) -and $_.Count -and $_[0] -is [string] -and $_[0] -eq '->') { Format-Type $_ $true } else { Format-Type $_ } }) -join ' -> ' }
    elseif ($h -eq 'tuple') { $s = ($args_ | ForEach-Object { Format-Type $_ $true }) -join ' * ' }
    else { $s = (@($head) + @($args_ | ForEach-Object { Format-Type $_ $true })) -join ' ' }
    if ($Nested -and ($h -in '->', 'tuple' -or $args_.Count)) { "($s)" } else { $s }
}

function Format-Pattern($p) {
    if ($p -is [string]) { return $p }
    $head = $p[0]; $args_ = Get-Rest $p 1
    if (-not $args_.Count) { return $head }
    if ($args_.Count -eq 1) { return "$head $(Format-Pattern $args_[0])" }
    "$head ($(($args_ | ForEach-Object { Format-Pattern $_ }) -join ', '))"
}

function Format-Expr($e, [int] $Ind, [bool] $Nested = $false) {
    if ($e -is [string]) { return $e }
    if (Test-Str $e) { return $e.Item2 }
    if (-not $e.Count) { return '()' }
    $head = $e[0]; $args_ = Get-Rest $e 1
    $h = if ($head -is [string]) { $head } else { $null }
    if ($h -eq 'emit') { return '$' + $args_[0].Item2 }
    if ($h -eq 'then') { $s = ($args_ | ForEach-Object { Format-Expr $_ $Ind $true }) -join ' |> ' }
    elseif ($h -eq 'if') { $s = "if $(Format-Expr $args_[0] $Ind) then $(Format-Expr $args_[1] $Ind) else $(Format-Expr $args_[2] $Ind)" }
    elseif ($h -eq 'match') {
        $pad = ' ' * $Ind
        $arms = ((Get-Rest $args_ 1) | ForEach-Object { "$pad| $(Format-Pattern $_[0]) => $(Format-Expr $_[1] ($Ind + 4))" }) -join "`n"
        $s = "match $(Format-Expr $args_[0] $Ind) with`n$arms"
        if ($Nested) { return "(`n$(' ' * ($Ind + 4))$s)" } else { return $s }
    }
    elseif ($h -and $h -in $infix -and $args_.Count -eq 2) { $s = "$(Format-Expr $args_[0] $Ind $true) $head $(Format-Expr $args_[1] $Ind $true)" }
    elseif (Test-Ctor $head) {
        if (-not $args_.Count) { return $head }
        if ($args_.Count -eq 1) { $s = "$head $(Format-Expr $args_[0] $Ind $true)" }
        else { $s = "$head ($(($args_ | ForEach-Object { Format-Expr $_ $Ind }) -join ', '))" }
    }
    else { $s = (@(Format-Expr $head $Ind $true) + @($args_ | ForEach-Object { Format-Expr $_ $Ind $true })) -join ' ' }
    if ($Nested) { "($s)" } else { $s }
}

function Get-NameParams($x) { if ($x -is [string]) { , @($x) } else { , @($x) } }

function Get-Forall($xs) {
    if ($xs.Count -and (Test-List $xs[0]) -and $xs[0].Count -and $xs[0][0] -is [string] -and $xs[0][0] -eq 'forall') { return @("forall $((Get-Rest $xs[0] 1) -join ' '). ", (Get-Rest $xs 1)) }
    @('', $xs)
}

function Format-Top($f) {
    $head = $f[0]; $args_ = Get-Rest $f 1
    if ($head -in 'nominal', 'type') { return "$head $((Get-NameParams $args_[0]) -join ' ') = $(Format-Type $args_[1])" }
    if ($head -eq 'union') {
        $rec = $args_[0] -is [string] -and $args_[0] -eq 'rec'
        if ($rec) { $args_ = Get-Rest $args_ 1 }
        $lines = @("union $(if ($rec) { 'rec ' })$((Get-NameParams $args_[0]) -join ' ') =")
        foreach ($c in (Get-Rest $args_ 1)) { $fa, $rest = Get-Forall (Get-Rest $c 1); $lines += "    | $($c[0]) :: $fa$(Format-Type $rest[0])" }
        return $lines -join "`n"
    }
    if ($head -eq 'inl') {
        $rec = $args_[0] -is [string] -and $args_[0] -eq 'rec'
        if ($rec) { $args_ = Get-Rest $args_ 1 }
        $name = $args_[0]; $fa, $rest = Get-Forall (Get-Rest $args_ 1)
        $params = $rest[0]; $rest = Get-Rest $rest 1
        $ps = if ($params.Count) { ($params | ForEach-Object { "($($_[0]) : $(Format-Type $_[1]))" }) -join ' ' } else { '()' }
        if ($rest.Count -eq 2) { $ret = $rest[0]; $body = $rest[1] } else { $ret = $null; $body = $rest[0] }
        $sig = "inl $(if ($rec) { 'rec ' })$name $fa$ps" + $(if ($null -ne $ret) { " : $(Format-Type $ret)" })
        return "$sig =`n    $(Format-Expr $body 4)"
    }
    throw "unknown top-level form '$head'"
}

$forms = Read-Forms ([IO.File]::ReadAllText($In, [Text.Encoding]::UTF8))
$text = (($forms | ForEach-Object { Format-Top $_ }) -join "`n`n") + "`n"
[IO.File]::WriteAllText($Out, $text, [Text.UTF8Encoding]::new($false))
"$($forms.Count) forms -> $Out"
