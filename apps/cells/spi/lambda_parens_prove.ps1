param(
    [Parameter(Mandatory)] [string] $File,
    [string] $LiveLib = (Join-Path $PSScriptRoot '../../../lib/spiral'),
    [string] $Work = (Join-Path $env:TEMP 'lambda-parens-prove'),
    [switch] $KeepEdited,
    [string[]] $Site = @()
)
$Site = @($Site | ForEach-Object { "$_" -split ',' } | Where-Object { $_ } | ForEach-Object { [int]$_ })
$ErrorActionPreference = 'Stop'
$gate = Join-Path $PSScriptRoot 'lib_gate.ps1'

function Get-TailSites([string] $Text) {
    $lines = $Text -split "`n"
    $sites = [Collections.Generic.List[object]]::new()
    for ($n = 0; $n -lt $lines.Count; $n++) {
        $line = $lines[$n]
        if ($line -match '^\s*///') { continue }
        $i = 0
        while (($i = $line.IndexOf('(\ ', $i)) -ge 0) {
            $d = 0; $j = $i; $end = -1
            while ($j -lt $line.Length) {
                $c = $line[$j]
                if ($c -eq '(') { $d++ } elseif ($c -eq ')') { $d--; if ($d -eq 0) { $end = $j; break } } elseif ($c -eq '"') { break }
                $j++
            }
            $inner = if ($end -ge 0) { $line.Substring($i + 1, $end - $i - 1) } else { '' }
            $scoped = $inner -match '=>\s*\\\*' -or $inner -match '\s:\s*[A-Za-z_][\w''.]*(\s+[A-Za-z_][\w''.]*)*\s*$'
            if ($end -ge 0 -and -not $scoped -and $line.Substring($end + 1).Trim() -eq '') { $sites.Add([pscustomobject]@{ Line = $n; Open = $i; Close = $end }) }
            $i++
        }
    }
    , $sites
}

function Remove-Parens([string] $Text, [object[]] $Sites, [string] $ControlTail) {
    $lines = $Text -split "`n"
    foreach ($s in ($Sites | Sort-Object Line, Open -Descending)) {
        $l = $lines[$s.Line]
        $inner = $l.Substring($s.Open + 1, $s.Close - $s.Open - 1)
        $lines[$s.Line] = $l.Substring(0, $s.Open) + $inner + $ControlTail + $l.Substring($s.Close + 1)
        $ControlTail = ''
    }
    $lines -join "`n"
}

function Invoke-Gate([string] $Lib, [string] $Tag) {
    $raw = Join-Path $Work "$Tag.raw.txt"
    $out = & pwsh -NoProfile -File $gate -File $File -Lib $Lib -RawOut $raw 2>&1 | ForEach-Object { "$_" }
    $tests = ($out | Select-String '^tests:' | Select-Object -Last 1).Line
    $types = ($out | Select-String '^type errors:' | Select-Object -Last 1).Line
    [pscustomobject]@{ Tag = $Tag; Tests = $tests; Types = $types }
}

$root = Join-Path $Work (([IO.Path]::GetFileNameWithoutExtension($File) -replace "'", '_') + $(if ($Site.Count) { '-sites-' + ($Site -join '-') }))
Remove-Item -LiteralPath $root -Recurse -Force -ErrorAction SilentlyContinue
foreach ($arm in 'base', 'edit', 'control') { New-Item -ItemType Directory -Force (Join-Path $root "$arm\lib") | Out-Null; Copy-Item -LiteralPath $LiveLib -Destination (Join-Path $root "$arm\lib\spiral") -Recurse }
$text = [IO.File]::ReadAllText((Join-Path $LiveLib $File)) -replace "`r`n", "`n"
$sites = Get-TailSites $text
if ($Site.Count) {
    $all = $sites
    $sites = @($Site | ForEach-Object { if ($_ -lt 1 -or $_ -gt $all.Count) { throw "-Site $_ is outside 1..$($all.Count)" }; $all[$_ - 1] })
    $sites | ForEach-Object { "site at line $($_.Line + 1): $(($text -split "`n")[$_.Line].Trim())" }
}
if (-not $sites.Count) { "no tail-paren sites in $File"; return }
[IO.File]::WriteAllText((Join-Path $root "edit\lib\spiral\$File"), (Remove-Parens $text $sites ''))
[IO.File]::WriteAllText((Join-Path $root "control\lib\spiral\$File"), (Remove-Parens $text $sites ' |> lp_control_unbound'))
$results = foreach ($arm in 'base', 'edit', 'control') { Invoke-Gate (Join-Path $root "$arm\lib\spiral") $arm }
$results | Format-Table -AutoSize | Out-String -Width 200
$base, $edit, $control = $results
$reached = $control.Types -notmatch 'type errors: 0$' -or $control.Tests -ne $base.Tests
$same = $edit.Tests -eq $base.Tests -and $edit.Types -eq $base.Types
"sites: $($sites.Count); edit equals base: $same; control reaches the edits: $reached"
if ($same -and $reached) { 'VERDICT: PROVEN (the edit keeps every test result, and the control shows the tests reach the edited lambdas)' }
elseif ($same) { 'VERDICT: UNPROVEN (the edit keeps every result, but the control did not change anything: no test reaches these lambdas)' }
else { 'VERDICT: BREAKS (the edit changes test results: keep the parens)' }
if ($KeepEdited -and $same -and $reached) { Copy-Item (Join-Path $root "edit\lib\spiral\$File") (Join-Path $Work "$($File).edited") -Force; "edited copy: $(Join-Path $Work "$File.edited")" }
