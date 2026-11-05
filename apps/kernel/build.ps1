param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../scripts/core.ps1

$notebooks = @(Get-ChildItem src -Filter *.spi | ForEach-Object { '--path'; $_.FullName })
$env:SPIRAL_CELLS_MEMO = '0'
Push-Location (Join-Path '..' 'cells')
try { $cells = @(& pwsh -NoProfile -File (Join-Path 'spi' 'run_notebook.ps1') --gate @notebooks 2>&1 | ForEach-Object { "$_" }); $cellsExit = $LASTEXITCODE }
finally { Pop-Location }
$cells | ForEach-Object { Write-Output "apps/kernel/build.ps1 / cells / $_" }
if ($cellsExit -ne 0) { throw "apps/kernel/build.ps1 / Spiral test cells exited $cellsExit" }
if (!($cells -match '^spiral-tests total')) { throw "apps/kernel/build.ps1 / Spiral test cells printed no spiral-tests total line" }
Write-Output "KERNEL-OK"
