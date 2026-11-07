param([string] $Dll)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'env.ps1')
$dotnet = Resolve-SpiralDotnet
$compiler = if ($Dll) { $Dll } else { Get-SpiralCompilerDll single-flight }
$probe = Join-Path $PSScriptRoot 'export-check-fsharp'
$out = Join-Path (Get-SpiralCacheDir) 'runs/export-check-fsharp'
New-Item -ItemType Directory -Force $out | Out-Null
Copy-Item (Join-Path $probe 'use.fsx') $out -Force
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
& $dotnet $compiler --backend Fsharp (Join-Path $probe 'main.spi') (Join-Path $out 'main.fsx') 2>&1 | Select-Object -Last 3
Push-Location $out
try { $result = @(& $dotnet fsi use.fsx 2>&1 | ForEach-Object { "$_" }); $code = $LASTEXITCODE } finally { Pop-Location }
$result | Select-Object -Last 3
"fsi exit $code"
if ($code -ne 0 -or -not ($result -contains 'FSX-EXPORT-OK')) { exit 1 }