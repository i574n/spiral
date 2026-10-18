param(
    [Parameter(Mandatory)] [string] $Out,
    [string] $Spiral = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..\..')).Path,
    [string] $Eoie = (Join-Path (Split-Path (Resolve-Path (Join-Path $PSScriptRoot '..\..\..\..')).Path) 'eoie'),
    [string] $UserManifest,
    [string] $Backlog
)
$ErrorActionPreference = 'Stop'
$rows = [System.Collections.Generic.List[string]]::new()
function Add-Row([string] $Corpus, [string] $Path, [string] $Rel) { $rows.Add("$Corpus`t3`t$Path`t$Rel") }
function Get-Tracked([string] $Repo, [string[]] $Patterns) {
    git -C $Repo ls-files -- @Patterns | Sort-Object
}
if ($UserManifest) {
    foreach ($entry in (Get-Content $UserManifest -Raw | ConvertFrom-Json)) { Add-Row 'user' $entry.path $entry.rel }
}
foreach ($rel in Get-Tracked $Spiral @('lib/*.spi', 'lib/*.spir')) { Add-Row 'lib' (Join-Path $Spiral $rel) $rel }
foreach ($rel in Get-Tracked $Spiral @('apps/*.spi', 'apps/*.spir')) {
    $corpus = if ($rel -like 'apps/compiler/tmp/samples/*') { 'samples' } else { 'apps' }
    Add-Row $corpus (Join-Path $Spiral $rel) $rel
}
if (Test-Path $Eoie) {
    foreach ($rel in Get-Tracked $Eoie @('src/*.spi', 'src/*.spir')) { Add-Row 'eoie' (Join-Path $Eoie $rel) "eoie/$rel" }
}
if ($Backlog) { Add-Row 'agile' $Backlog 'backlog/state/agile.spi' }
[IO.File]::WriteAllText($Out, ($rows -join "`n") + "`n")
$rows | ForEach-Object { ($_ -split "`t")[0] } | Group-Object | ForEach-Object { '{0} {1}' -f $_.Name, $_.Count }
