# Convenient entry point when the native executable has not been built yet.
$ErrorActionPreference = 'Stop'
$binaryName = if ($env:OS -eq 'Windows_NT') { 'eoie.exe' } else { 'eoie' }
$binary = Join-Path $PSScriptRoot $binaryName
if (-not (Test-Path -LiteralPath $binary -PathType Leaf)) {
    & (Join-Path $PSScriptRoot 'build.ps1')
}
& $binary @args
exit $LASTEXITCODE
