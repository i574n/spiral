param(
    [Parameter(Mandatory)][string] $Local,
    [Parameter(Mandatory)][string] $Ci,
    [int] $Show = 20
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'results-path.ps1')
function Get-Class($left, $right) {
    if ($right.native -eq 'no-toolchain' -and $left.native -ne 'no-toolchain') { return 'no-toolchain-on-runner' }
    if ($right.detail -match 'could not rename|component download failed|missing manifest in toolchain') { return 'toolchain-install-race' }
    $behavior = foreach ($field in 'compile', 'native', 'exit', 'stdout') { if ($left.$field -ne $right.$field) { $field } }
    if (-not $behavior) { return $(if ($left.residual -ne $right.residual) { 'residual-only' } else { 'oracle-only' }) }
    if ($platformBound.ContainsKey("$($left.id)|$($left.backend)")) { return 'platform-bound' }
    if (@($behavior) -join ',' -eq 'exit') {
        $l = 0; $r = 0
        if ([int]::TryParse($left.exit, [ref]$l) -and [int]::TryParse($right.exit, [ref]$r)) {
            if ($l -eq 3 -and $r -eq 134) { return 'abort-exit-134-vs-3' }
            if (($l -band 255) -eq $r) { return 'exit-mod-256' }
        }
    }
    'behavior'
}
$platformBound = @{}
$matrix = Import-PowerShellDataFile (Join-Path $PSScriptRoot '../tests/matrix.psd1') -SkipLimitCheck
foreach ($entry in @($matrix.Known) | Where-Object { $_.Platform }) { $platformBound["$($entry.Id)|$($entry.Backend)"] = $entry.Reason }
$left = Import-Csv (Resolve-Results $Local) -Delimiter "`t"
$right = Import-Csv (Resolve-Results $Ci) -Delimiter "`t"
$byKey = @{}
foreach ($row in $left) { $byKey["$($row.id)|$($row.backend)"] = $row }
$rows = foreach ($row in $right) {
    $base = $byKey["$($row.id)|$($row.backend)"]
    if (-not $base) { continue }
    $differs = foreach ($field in 'compile', 'residual', 'native', 'exit', 'stdout', 'oracle') { if ($base.$field -ne $row.$field) { $field } }
    if (-not $differs) { continue }
    [pscustomobject]@{ id = $row.id; backend = $row.backend; class = Get-Class $base $row; fields = (@($differs) -join ','); local = "$($base.native)/$($base.exit)/$($base.oracle)"; ci = "$($row.native)/$($row.exit)/$($row.oracle)" }
}
"differing rows: $(@($rows).Count) of $(@($right).Count) CI rows"
$rows | Group-Object class | Sort-Object Count -Descending | ForEach-Object {
    $backends = ($_.Group | Group-Object backend | Sort-Object Count -Descending | ForEach-Object { "$($_.Name) $($_.Count)" }) -join ', '
    '  {0,-26} {1,5}  {2}' -f $_.Name, $_.Count, $backends
}
"unclassified behavior rows (first $Show):"
$rows | Where-Object class -eq 'behavior' | Select-Object -First $Show id, backend, fields, local, ci | Format-Table -AutoSize | Out-String -Width 220
