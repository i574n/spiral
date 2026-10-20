param(
    [string]$Source = (Join-Path $PSScriptRoot '../../spiral_compiler.fs'),
    [string]$Base = 'HEAD',
    [string]$Tracked,
    [switch]$Table
)
$Source = (Resolve-Path $Source).Path
$lines = [IO.File]::ReadAllText($Source).Split("`n")

$pairs = [Collections.Generic.List[object]]::new()
$open = [Collections.Generic.Stack[object]]::new()
for ($i = 0; $i -lt $lines.Count; $i++) {
    $directive = $lines[$i].Trim()
    if ($directive.StartsWith('#if')) { $open.Push([pscustomobject]@{ Start = $i + 1; Middle = 0; Core = ($directive -eq '#if SPIRAL_CORE_GPT5PARALLEL') }) }
    elseif ($directive -eq '#else' -and $open.Count -gt 0) { $open.Peek().Middle = $i + 1 }
    elseif ($directive -eq '#endif' -and $open.Count -gt 0) {
        $block = $open.Pop()
        if ($block.Core -and $block.Middle -gt 0) {
            $header = $lines[$block.Middle..($i - 1)] | Where-Object { $_.Trim().StartsWith('/// ## ') } | Select-Object -First 1
            $pairs.Add([pscustomobject]@{ Name = if ($header) { $header.Trim().Substring(7) } else { "line $($block.Start)" }; Start = $block.Start; Middle = $block.Middle; End = $i + 1; Gpt5parallelTouched = $false; SingleTouched = $false; SingleSeamOnly = $true })
        }
    }
}

if ($Tracked) {
    $trackedPath = (Resolve-Path $Tracked).Path
    $root = git -C (Split-Path $trackedPath) rev-parse --show-toplevel
    if ($LASTEXITCODE -ne 0) { throw "pair-drift: $trackedPath is not inside a git work tree" }
    $relative = git -C $root ls-files --full-name -- $trackedPath
    $baseCopy = Join-Path ([IO.Path]::GetTempPath()) "pair-drift-base-$PID.fs"
    $previousEncoding = [Console]::OutputEncoding
    [Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
    $baseText = (git -C $root show "${Base}:$relative") -join "`n"
    $showExit = $LASTEXITCODE
    [Console]::OutputEncoding = $previousEncoding
    if ($showExit -ne 0) { throw "pair-drift: git show ${Base}:$relative failed" }
    [IO.File]::WriteAllText($baseCopy, $baseText + "`n")
    $diff = git --no-optional-locks diff --no-index -w -U0 -- $baseCopy $Source
    $diffExit = $LASTEXITCODE
    Remove-Item -LiteralPath $baseCopy -Force
    if ($diffExit -gt 1) { throw "pair-drift: git diff --no-index failed for $Source against ${Base}:$relative" }
}
else {
    $root = git -C (Split-Path $Source) rev-parse --show-toplevel
    if ($LASTEXITCODE -ne 0) { throw "pair-drift: $Source is not inside a git work tree" }
    $relative = git -C $root ls-files --full-name -- $Source
    $diff = git -C $root --no-optional-locks diff -w -U0 $Base -- $relative
    if ($LASTEXITCODE -ne 0) { throw "pair-drift: git diff $Base failed for $relative" }
}
$changed = [Collections.Generic.List[object]]::new()
$header = $null
$codeChanged = $false
$seamOnly = $true
$minus = [Collections.Generic.List[string]]::new()
$plus = [Collections.Generic.List[string]]::new()
function Get-RenamedNames($removed, $added) {
    if ($removed.Count -eq 0 -or $removed.Count -ne $added.Count) { return $null }
    $names = [Collections.Generic.HashSet[string]]::new()
    for ($k = 0; $k -lt $removed.Count; $k++) {
        $a = [regex]::Split($removed[$k], '(\W)') | Where-Object { $_ -ne '' }
        $b = [regex]::Split($added[$k], '(\W)') | Where-Object { $_ -ne '' }
        if (@($a).Count -ne @($b).Count) { return $null }
        for ($m = 0; $m -lt @($a).Count; $m++) {
            if ($a[$m] -ceq $b[$m]) { continue }
            if ($a[$m] -notmatch '^[A-Za-z_]\w*$' -or $b[$m] -notmatch '^[A-Za-z_]\w*$') { return $null }
            [void]$names.Add($a[$m])
        }
    }
    if ($names.Count -eq 0) { return $null }
    ,@($names)
}
foreach ($row in @($diff) + '@@ end') {
    if ($row -match '^@@ ') {
        if ($header -and $codeChanged) { $changed.Add([pscustomobject]@{ Header = $header; SeamOnly = $seamOnly; Renamed = (Get-RenamedNames $minus $plus) }) }
        $header = $row
        $codeChanged = $false
        $seamOnly = $true
        $minus.Clear()
        $plus.Clear()
    }
    elseif ($row -match '^[+-](?![+-]{2} )') {
        $body = $row.Substring(1).Trim()
        if ($row.StartsWith('-')) { $minus.Add($body) } else { $plus.Add($body) }
        if ($body -and -not $body.StartsWith('//')) {
            $codeChanged = $true
            if ($row.StartsWith('+') -and -not $body.Contains('PartEvalSeams.') -and $body -notmatch '^\)+$') { $seamOnly = $false }
        }
    }
}
$sideLocalRenames = [Collections.Generic.List[string]]::new()
foreach ($hunk in $changed) {
    $match = [regex]::Match($hunk.Header, '^@@ -\d+(?:,\d+)? \+(\d+)(?:,(\d+))? @@')
    $first = [int]$match.Groups[1].Value
    $count = if ($match.Groups[2].Success) { [int]$match.Groups[2].Value } else { 1 }
    $last = $first + [Math]::Max($count, 1) - 1
    foreach ($pair in $pairs) {
        if ($last -le $pair.Start -or $first -ge $pair.End) { continue }
        if ($hunk.Renamed) {
            $otherSide = if ($first -lt $pair.Middle) { $lines[$pair.Middle..($pair.End - 1)] -join "`n" } else { $lines[$pair.Start..($pair.Middle - 1)] -join "`n" }
            $sideLocal = @($hunk.Renamed | Where-Object { [regex]::IsMatch($otherSide, "\b$([regex]::Escape($_))\b") }).Count -eq 0
            if ($sideLocal) { $sideLocalRenames.Add("pair-drift: $($pair.Name) renamed $($hunk.Renamed -join ', ') on one side only; the names do not occur on the other side, as a side-local rename may"); continue }
        }
        if ($first -lt $pair.Middle) { $pair.Gpt5parallelTouched = $true }
        if ($last -gt $pair.Middle) { $pair.SingleTouched = $true; if (-not $hunk.SeamOnly) { $pair.SingleSeamOnly = $false } }
    }
}

if ($Table) {
    $pairs | ForEach-Object { "{0,-32} lines {1,7}-{2,-7} gpt5parallel {3,6} single-flight {4,6}" -f $_.Name, $_.Start, $_.End, ($_.Middle - $_.Start - 1), ($_.End - $_.Middle - 1) }
}
$gpt5parallelLayerGrowth = @($pairs | Where-Object { $_.Name -like '*Gpt5parallel' -and $_.Gpt5parallelTouched -and -not $_.SingleTouched })
$seamMoves = @($pairs | Where-Object { $_.SingleTouched -and -not $_.Gpt5parallelTouched -and $_.SingleSeamOnly })
$oneSided = @($pairs | Where-Object { $_.Gpt5parallelTouched -ne $_.SingleTouched -and $_ -notin $gpt5parallelLayerGrowth -and $_ -notin $seamMoves })
"pair-drift: $($pairs.Count) SPIRAL_CORE_GPT5PARALLEL pairs, $(@($pairs | Where-Object { $_.Gpt5parallelTouched -or $_.SingleTouched }).Count) touched since $Base, $($oneSided.Count) touched on one side only"
foreach ($pair in $gpt5parallelLayerGrowth) {
    "pair-drift: $($pair.Name) (lines $($pair.Start)-$($pair.End)) is a gpt5parallel layer and changed on its gpt5parallel side only, as a gpt5parallel layer may"
}
foreach ($pair in $seamMoves) {
    "pair-drift: $($pair.Name) (lines $($pair.Start)-$($pair.End)) changed on its single-flight side only by hopacsota seam calls (every added line calls PartEvalSeams), as D10 allows"
}
$sideLocalRenames | Select-Object -Unique
foreach ($pair in $oneSided) {
    $side = if ($pair.Gpt5parallelTouched) { 'gpt5parallel' } else { 'single-flight' }
    "pair-drift: $($pair.Name) (lines $($pair.Start)-$($pair.End)) changed only on the $side side: change both sides or unify the pair"
}
if ($oneSided.Count -gt 0) { exit 1 }
