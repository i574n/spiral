param([Parameter(ValueFromRemainingArguments)] [string[]] $Arguments)
$ErrorActionPreference = 'Stop'
$dotnet = if ($env:SPIRAL_DOTNET) { $env:SPIRAL_DOTNET } else {
    $cached = Join-Path $env:LOCALAPPDATA 'spiral-bin\toolchains\dotnet\dotnet.exe'
    if (Test-Path $cached) { $cached } else { (Get-Command dotnet).Source }
}
if (-not (Test-Path (Join-Path $PSScriptRoot 'dll\SpiralCompilerCore.dll'))) { & (Join-Path $PSScriptRoot 'sync-core.ps1') | Out-Host }
& $dotnet fsi --quiet (Join-Path $PSScriptRoot 'Format.fsx') @Arguments
exit $LASTEXITCODE
