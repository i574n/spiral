$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot '..\env.ps1')
if (-not $env:DOTNET_GCgen0size) { $env:DOTNET_GCgen0size = '0x10000000' }
& (Resolve-SpiralDotnet) (Get-SpiralCompilerDll single-flight) format-corpus @args
exit $LASTEXITCODE
