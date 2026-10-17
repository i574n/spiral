param([Parameter(Mandatory)][string] $Left, [Parameter(Mandatory)][string] $Right, [string[]] $Fields = @('compile', 'residual', 'native', 'exit', 'stdout', 'oracle'), [int] $Show = 12)
$ErrorActionPreference = 'Stop'
function Resolve-Results([string] $run) {
    if (Test-Path $run -PathType Container) { return Join-Path $run 'results.tsv' }
    Join-Path $env:LOCALAPPDATA "spiral-bin\runs\$run\results.tsv"
}
$l = Import-Csv (Resolve-Results $Left) -Delimiter "`t"
$r = Import-Csv (Resolve-Results $Right) -Delimiter "`t"
$byKey = @{}; foreach ($row in $l) { $byKey["$($row.id)|$($row.backend)"] = $row }
$seen = @{}
$cells = foreach ($row in $r) {
    $key = "$($row.id)|$($row.backend)"; $seen[$key] = $true
    $b = $byKey[$key]
    if (-not $b) { [pscustomobject]@{ id = $row.id; backend = $row.backend; field = 'row'; left = '<none>'; right = 'new' }; continue }
    foreach ($f in $Fields) { if ($row.$f -ne $b.$f) { [pscustomobject]@{ id = $row.id; backend = $row.backend; field = $f; left = $b.$f; right = $row.$f } } }
}
$missing = @($l | Where-Object { -not $seen["$($_.id)|$($_.backend)"] })
"rows: left $(@($l).Count), right $(@($r).Count), missing on right $($missing.Count); differing cells: $(@($cells).Count)"
$cells | Group-Object backend, field | Sort-Object Count -Descending | ForEach-Object { '  {0,-24} {1,5}' -f $_.Name, $_.Count }
"behavior cells (not residual): $(@($cells | Where-Object field -ne 'residual').Count)"
"DISAGREE rows on right: $(@($r | Where-Object oracle -eq 'DISAGREE').Count)"
$cells | Where-Object field -ne 'residual' | Select-Object -First $Show | Format-Table -AutoSize | Out-String -Width 220
