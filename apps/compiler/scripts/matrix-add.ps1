[CmdletBinding(DefaultParameterSetName = 'List')]
param(
    [Parameter(Mandatory, ParameterSetName = 'List')] [string] $List,
    [Parameter(Mandatory, ParameterSetName = 'Backend')] [string] $Backend,
    [Parameter(ParameterSetName = 'Backend')] [string] $After = '',
    [Parameter(Mandatory)] [string[]] $Samples,
    [string] $Matrix = (Join-Path $PSScriptRoot '../tmp/tests/matrix.psd1'),
    [switch] $Apply
)
$ErrorActionPreference = 'Stop'
$Samples = @($Samples | ForEach-Object { $_ -split ',' } | Where-Object { $_ } | ForEach-Object { if ($_.StartsWith('samples/')) { $_ } else { "samples/$_" } })
$text = [IO.File]::ReadAllText($Matrix) -replace "`r`n", "`n"
$utf8 = [Text.UTF8Encoding]::new($false)

if ($PSCmdlet.ParameterSetName -eq 'List') {
    $anchor = "`n    $List = @(`n"
    $hits = ([regex]::Matches($text, [regex]::Escape($anchor))).Count
    if ($hits -ne 1) { "$List list anchor matches $hits times, expected 1"; exit 1 }
    $start = $text.IndexOf($anchor) + $anchor.Length
    $end = $text.IndexOf("`n    )", $start)
    $listed = [Collections.Generic.HashSet[string]]::new([string[]] @($text.Substring($start, $end - $start).Split("`n") | ForEach-Object { $_.Trim().Trim("'") }))
    $missing = @($Samples | Where-Object { -not $listed.Contains($_) })
    $samplesRoot = Split-Path (Split-Path $Matrix)
    $absent = @($missing | Where-Object { -not (Test-Path (Join-Path $samplesRoot "$_/main.spi")) -and -not (Test-Path (Join-Path $samplesRoot "$_/main.spir")) })
    if ($absent) { "no such sample: $($absent -join ' ')"; exit 1 }
    if (-not $missing) { "${List}: already listed"; exit 0 }
    if (-not $Apply) { "${List}: $($missing.Count) samples to add (dry run, pass -Apply to write)"; exit 0 }
    [IO.File]::WriteAllText($Matrix, $text.Substring(0, $end) + (($missing | ForEach-Object { "`n        '$_'" }) -join '') + $text.Substring($end), $utf8)
    "${List}: added $($missing.Count) samples"
    exit 0
}

$lines = $text.Split("`n")
$start = [Array]::IndexOf($lines, '    Backends = @{')
$end = $start + 1; while ($lines[$end] -ne '    }') { $end++ }
$groups = [ordered]@{}
$current = $null
for ($i = $start + 1; $i -lt $end; $i++) {
    if ($lines[$i] -match "^        '([^']+)' = @\($") { $current = $Matches[1]; $groups[$current] = [Collections.Generic.List[string]]::new(); continue }
    if ($null -ne $current -and $lines[$i] -match "^ {8,}'(samples/[^']+)'$") { $groups[$current].Add($Matches[1]) }
}
$moves = [Collections.Generic.List[object]]::new()
$missing = [Collections.Generic.List[string]]::new()
foreach ($name in $Samples) {
    $owner = @($groups.Keys | Where-Object { $groups[$_].Contains($name) } | Select-Object -First 1)
    if (-not $owner) { $missing.Add($name); continue }
    $parts = @($owner[0] -split ',')
    if ($parts -contains $Backend) { continue }
    $position = if ($parts -contains $After) { [Array]::IndexOf($parts, $After) + 1 } else { $parts.Count }
    $moves.Add([pscustomobject]@{ Name = $name; Owner = $owner[0]; NewKey = (@($parts[0..($position - 1)]) + $Backend + @(if ($position -lt $parts.Count) { $parts[$position..($parts.Count - 1)] }) | Where-Object { $_ }) -join ',' })
}
if ($missing.Count) { "not in the Backends table (default backends already include it or the name is wrong): $($missing -join ' ')"; exit 1 }
$moves | Group-Object Owner, NewKey | ForEach-Object { "{0,4} {1} -> {2}" -f $_.Count, $_.Group[0].Owner, $_.Group[0].NewKey }
if (-not $Apply) { "$($moves.Count) samples to move (dry run, pass -Apply to write)"; exit 0 }
$foreign = @(for ($i = $start + 1; $i -lt $end; $i++) { if ($lines[$i] -notmatch "^        '([^']+)' = @\($" -and $lines[$i] -notmatch "^ {8,}'(samples/[^']+)'$" -and $lines[$i] -ne '        )') { $lines[$i] } })
if ($foreign) { "refusing: the Backends block has $($foreign.Count) lines this script would drop, e.g. '$($foreign[0])'"; exit 1 }
foreach ($m in $moves) {
    [void]$groups[$m.Owner].Remove($m.Name)
    if (-not $groups.Contains($m.NewKey)) { $groups[$m.NewKey] = [Collections.Generic.List[string]]::new() }
    $groups[$m.NewKey].Add($m.Name)
}
$block = @('    Backends = @{') + @(foreach ($key in $groups.Keys) { if ($groups[$key].Count) { "        '$key' = @("; foreach ($n in $groups[$key]) { "            '$n'" }; '        )' } }) + '    }'
[IO.File]::WriteAllText($Matrix, ((@($lines[0..($start - 1)]) + $block + @(if ($end + 1 -lt $lines.Count) { $lines[($end + 1)..($lines.Count - 1)] })) -join "`n"), $utf8)
"moved $($moves.Count) samples"
