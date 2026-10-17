param([string] $Out = '')
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot '../scripts/env.ps1')
if (-not $env:DOTNET_GCgen0size) { $env:DOTNET_GCgen0size = '0x10000000' }
$root = (Resolve-Path (Join-Path $PSScriptRoot '../../../..')).Path
if (-not $Out) { $Out = Join-Path (Get-SpiralCacheDir) 'runs/format-check.txt' }
New-Item -ItemType Directory -Force (Split-Path $Out) | Out-Null
$inputs = @(Join-Path $root 'lib') + @(Get-ChildItem (Join-Path $root 'apps') -Directory | ForEach-Object FullName)
$watch = [Diagnostics.Stopwatch]::StartNew()
$lines = @(& (Resolve-SpiralDotnet) (Get-SpiralCompilerDll single-flight) format --check @inputs 2>&1 | ForEach-Object { "$_" })
$exit = $LASTEXITCODE
[IO.File]::WriteAllText($Out, ($lines -join "`n") + "`n")
$changed = @($lines | Where-Object { $_.StartsWith('would change: ') }).Count
$over = @($lines | Where-Object { $_ -match ': over-120 ' }).Count
"format --check exit $exit in $([int]$watch.Elapsed.TotalSeconds) s: $changed files would change, $over lines over 120 (report $Out)"
exit 0
