[CmdletBinding()]
param(
    [switch]$Test,
    [switch]$CompilerContracts,
    [switch]$Offline,
    [string]$SpiralCompiler
)
$ErrorActionPreference = 'Stop'
$bundleRoot = $PSScriptRoot
$sourceRoot = Join-Path $bundleRoot 'src'
$targetRoot = Join-Path $sourceRoot 'target'
$previousCompiler = $env:EOIE_SPIRAL_COMPILE
$cargoCommon = @('--locked')
if ($Offline) { $cargoCommon += '--offline' }
# Resolve caller-relative paths before changing to src (Cargo discovers config there).
if ($SpiralCompiler) { $SpiralCompiler = (Resolve-Path -LiteralPath $SpiralCompiler).Path }
if ($CompilerContracts -and -not $Test) { throw '-CompilerContracts requires -Test.' }
if ($CompilerContracts -and -not ($SpiralCompiler -or $env:EOIE_SPIRAL_COMPILE)) {
    throw '-CompilerContracts requires -SpiralCompiler or EOIE_SPIRAL_COMPILE with --check and --plan-ir support.'
}
Push-Location $sourceRoot
try {
    if ($SpiralCompiler) {
        $env:EOIE_SPIRAL_COMPILE = $SpiralCompiler
    }
    if ($Test) {
        # Public integration contracts locate the development binary beside tests.
        & cargo build @cargoCommon --target-dir $targetRoot -p eoie-cli
        if ($LASTEXITCODE -ne 0) { throw 'EOIE development build failed.' }
        $testArgs = @('test') + $cargoCommon + @('--target-dir', $targetRoot, '--workspace')
        if ($CompilerContracts) {
            $testArgs += @('--', '--include-ignored')
        } else {
            Write-Host 'Running all native contracts. Explicitly ignored attestation tests require -CompilerContracts and a compatible facade.'
        }
        & cargo @testArgs
        if ($LASTEXITCODE -ne 0) { throw 'EOIE tests failed.' }
    }
    & cargo build --release @cargoCommon --target-dir $targetRoot -p eoie-cli
    if ($LASTEXITCODE -ne 0) { throw 'EOIE release build failed.' }
    $binaryName = if ($env:OS -eq 'Windows_NT') { 'eoie.exe' } else { 'eoie' }
    $builtBinary = Join-Path $targetRoot "release/$binaryName"
    $installedBinary = Join-Path $bundleRoot $binaryName
    Copy-Item -LiteralPath $builtBinary -Destination $installedBinary -Force
    & $installedBinary help --schema
    if ($LASTEXITCODE -ne 0) { throw 'EOIE executable smoke check failed.' }
    Write-Host "Built $installedBinary"
} finally {
    $env:EOIE_SPIRAL_COMPILE = $previousCompiler
    Pop-Location
}
