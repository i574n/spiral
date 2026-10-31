param(
    [Parameter(Mandatory)] [string] $Run,
    [string[]] $Backends = @('Zig', 'Rust', 'Lean', 'Wasm', 'Bend', 'Wgsl', 'Calyx'),
    [string] $Root = (Join-Path $PSScriptRoot '../tmp')
)
$Backends = @($Backends | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
$runDir = if (Test-Path -LiteralPath $Run) { $Run } else { Join-Path "$env:LOCALAPPDATA\spiral-bin\runs" $Run }
$rows = Import-Csv (Join-Path $runDir 'results.tsv') -Delimiter "`t"
$cIds = @($rows | Where-Object backend -eq 'C' | ForEach-Object id | Sort-Object -Unique)
$features = @{}
foreach ($id in $cIds) {
    $source = (Get-ChildItem (Join-Path $Root $id) -Filter *.spi -ErrorAction SilentlyContinue | ForEach-Object { Get-Content $_.FullName -Raw }) -join "`n"
    $tags = @()
    if ($source -match '\b[iu]64\b|\d+[iu]64') { $tags += 'i64' }
    if ($source -match '\bf64\b|\d\.\d+(f64)?\b') { $tags += 'f64' }
    if ($source -match '(?m)^\s*union\b') { $tags += 'union' }
    if ($source -match ';\[|array_create|ArrayCreate|\barray\b') { $tags += 'array' }
    if ($source -match '"') { $tags += 'string' }
    if ($source -match "\$'|\$`"") { $tags += 'macro' }
    $features[$id] = $tags
}
foreach ($backend in $Backends) {
    $present = @($rows | Where-Object backend -eq $backend | ForEach-Object id)
    $missing = @($cIds | Where-Object { $_ -notin $present })
    $buckets = $missing | ForEach-Object { if ($features[$_].Count) { $features[$_] } else { 'none' } } | Group-Object | Sort-Object Count -Descending | ForEach-Object { "$($_.Name) $($_.Count)" }
    "{0,-6} missing {1,3}: {2}" -f $backend, $missing.Count, ($buckets -join ', ')
}
