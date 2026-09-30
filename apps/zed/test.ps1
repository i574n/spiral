# Build spiral-zed and probe the two fixtures. The ok module checks clean.
# The bad module is rejected. Exit 0 means both of those happened.
$ErrorActionPreference = 'Stop'
Set-Location $PSScriptRoot
cargo test
if ($LASTEXITCODE -ne 0) { throw 'spiral-zed tests failed.' }
cargo build --release --bin spiral-zed
if ($LASTEXITCODE -ne 0) { throw 'spiral-zed release build failed.' }
$builtName = if ($IsWindows) { 'spiral-zed.exe' } else { 'spiral-zed' }
$dotnetName = if ($IsWindows) { 'dotnet.exe' } else { 'dotnet' }
New-Item -ItemType Directory -Force -Path dist | Out-Null
Copy-Item -Force (Join-Path target "release/$builtName") (Join-Path dist $builtName)
$cache = if ($env:SPIRAL_BIN_CACHE_DIR) { $env:SPIRAL_BIN_CACHE_DIR } elseif ($env:LOCALAPPDATA) { Join-Path $env:LOCALAPPDATA 'spiral-bin' } else { Join-Path $HOME '.cache/spiral-bin' }
$dotnet = if ($env:SPIRAL_DOTNET) { $env:SPIRAL_DOTNET } else { Join-Path $cache "toolchains/dotnet/$dotnetName" }
$compiler = if ($env:SPIRAL_COMPILER) { $env:SPIRAL_COMPILER } else { Join-Path $cache 'bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll' }
if (-not (Test-Path -LiteralPath $dotnet)) { throw "dotnet for the probe was not found: $dotnet" }
if (-not (Test-Path -LiteralPath $compiler)) { throw "SpiralCompiler.dll for the probe was not found: $compiler" }
$helper = Join-Path dist $builtName
& $helper --dotnet $dotnet --compiler $compiler --probe (Join-Path fixtures 'ok/main.spi')
if ($LASTEXITCODE -ne 0) { throw 'The ok fixture was rejected.' }
& $helper --dotnet $dotnet --compiler $compiler --probe (Join-Path fixtures 'bad/main.spi')
if ($LASTEXITCODE -eq 0) { throw 'The bad fixture was accepted.' }
Write-Host 'spiral-zed probe passed. Restart the spiral-lsp language server in Zed to load dist/spiral-zed.exe.'
