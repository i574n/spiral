param(
    [string]$Source = (Join-Path $PSScriptRoot '../../spiral_compiler.fs'),
    [string]$Base = 'HEAD',
    [switch]$Table
)
$Source = (Resolve-Path $Source).Path
$lines = [IO.File]::ReadAllText($Source).Split("`n")

$pairs = [Collections.Generic.List[object]]::new()
$open = [Collections.Generic.Stack[object]]::new()
for ($i = 0; $i -lt $lines.Count; $i++) {
    $directive = $lines[$i].Trim()
    if ($directive.StartsWith('#if')) { $open.Push([pscustomobject]@{ Start = $i + 1; Middle = 0; Core = ($directive -eq '#if SPIRAL_CORE_HOPAC') }) }
    elseif ($directive -eq '#else' -and $open.Count -gt 0) { $open.Peek().Middle = $i + 1 }
    elseif ($directive -eq '#endif' -and $open.Count -gt 0) {
        $block = $open.Pop()
        if ($block.Core -and $block.Middle -gt 0) {
            $header = $lines[$block.Middle..($i - 1)] | Where-Object { $_.Trim().StartsWith('/// ## ') } | Select-Object -First 1
            $pairs.Add([pscustomobject]@{ Name = if ($header) { $header.Trim().Substring(7) } else { "line $($block.Start)" }; Start = $block.Start; Middle = $block.Middle; End = $i + 1; HopacTouched = $false; SingleTouched = $false })
        }
    }
}

$root = git -C (Split-Path $Source) rev-parse --show-toplevel
if ($LASTEXITCODE -ne 0) { throw "pair-drift: $Source is not inside a git work tree" }
$relative = git -C $root ls-files --full-name -- $Source
$diff = git -C $root --no-optional-locks diff -U0 $Base -- $relative
if ($LASTEXITCODE -ne 0) { throw "pair-drift: git diff $Base failed for $relative" }
$changed = $diff | Where-Object { $_ -match '^@@ ' }
foreach ($hunk in $changed) {
    $match = [regex]::Match($hunk, '^@@ -\d+(?:,\d+)? \+(\d+)(?:,(\d+))? @@')
    $first = [int]$match.Groups[1].Value
    $count = if ($match.Groups[2].Success) { [int]$match.Groups[2].Value } else { 1 }
    $last = $first + [Math]::Max($count, 1) - 1
    foreach ($pair in $pairs) {
        if ($last -le $pair.Start -or $first -ge $pair.End) { continue }
        if ($first -lt $pair.Middle) { $pair.HopacTouched = $true }
        if ($last -gt $pair.Middle) { $pair.SingleTouched = $true }
    }
}

if ($Table) {
    $pairs | ForEach-Object { "{0,-32} lines {1,7}-{2,-7} hopac {3,6} single-flight {4,6}" -f $_.Name, $_.Start, $_.End, ($_.Middle - $_.Start - 1), ($_.End - $_.Middle - 1) }
}
$oneSided = @($pairs | Where-Object { $_.HopacTouched -ne $_.SingleTouched })
"pair-drift: $($pairs.Count) SPIRAL_CORE_HOPAC pairs, $(@($pairs | Where-Object { $_.HopacTouched -or $_.SingleTouched }).Count) touched since $Base, $($oneSided.Count) touched on one side only"
foreach ($pair in $oneSided) {
    $side = if ($pair.HopacTouched) { 'hopac' } else { 'single-flight' }
    "pair-drift: $($pair.Name) (lines $($pair.Start)-$($pair.End)) changed only on the $side side: change both sides or unify the pair"
}
if ($oneSided.Count -gt 0) { exit 1 }
