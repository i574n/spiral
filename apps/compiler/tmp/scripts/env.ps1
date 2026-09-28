# Shared environment for the spiral-bin scripts. Dot-source it: `. $PSScriptRoot/env.ps1`.
# Works on Windows and Linux (PowerShell 7+). Nothing here writes inside the bundle: builds,
# outputs, toolchains and results all live under the cache directory.

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

$script:BundleRoot = Split-Path $PSScriptRoot -Parent

function Get-SpiralCacheDir {
    $dir =
        if ($env:SPIRAL_BIN_CACHE_DIR) { $env:SPIRAL_BIN_CACHE_DIR }
        elseif ($IsWindows) { Join-Path $env:LOCALAPPDATA 'spiral-bin' }
        else { Join-Path $HOME '.cache/spiral-bin' }
    New-Item -ItemType Directory -Force $dir | Out-Null
    (Resolve-Path $dir).Path
}

function ConvertTo-SpiralMode([string]$Mode) {
    switch -Regex ($Mode) {
        '^(sf|single|single-flight)$' { 'single-flight' }
        '^(hp|hopac)$' { 'hopac' }
        default { throw "unknown mode '$Mode' (use single-flight or hopac)" }
    }
}

# The single-flight core is the repo's main compiler source (apps/compiler/spiral_compiler.fs); the hopac
# core is still a lane of its own until it meets the promotion criterion in AGENTS.md.
function Get-SpiralCoreSource([string]$Mode) {
    switch (ConvertTo-SpiralMode $Mode) {
        'single-flight' { Join-Path (Split-Path $BundleRoot -Parent) 'spiral_compiler.fs' }
        'hopac' { Join-Path $BundleRoot 'compiler/cores/hopac/spiral_compiler.fs' }
    }
}

function Test-DotnetHasSdk11([string]$Dotnet) {
    try { (& $Dotnet --list-sdks 2>$null) -match '^11\.' } catch { $false }
}

# The compiler targets net11.0. Resolution order: $env:SPIRAL_DOTNET, the cache-local toolchain
# installed by scripts/install-dotnet.ps1, then dotnet on PATH if it carries an 11.x SDK.
function Resolve-SpiralDotnet {
    $exe = if ($IsWindows) { 'dotnet.exe' } else { 'dotnet' }
    $candidates = @()
    if ($env:SPIRAL_DOTNET) { $candidates += $env:SPIRAL_DOTNET }
    $candidates += Join-Path (Get-SpiralCacheDir) "toolchains/dotnet/$exe"
    $onPath = Get-Command dotnet -ErrorAction SilentlyContinue
    if ($onPath) { $candidates += $onPath.Source }
    foreach ($candidate in $candidates) {
        if ((Test-Path $candidate) -and (Test-DotnetHasSdk11 $candidate)) {
            $env:DOTNET_ROOT = Split-Path $candidate -Parent
            $env:DOTNET_CLI_TELEMETRY_OPTOUT = '1'
            $env:DOTNET_NOLOGO = '1'
            $env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = '1'
            return $candidate
        }
    }
    throw "No .NET 11 SDK found. Run scripts/install-dotnet.ps1 (installs into the cache dir) or set SPIRAL_DOTNET."
}

function Resolve-SpiralTool([string]$Name, [string[]]$Candidates) {
    foreach ($candidate in $Candidates) {
        if (-not $candidate) { continue }
        # Applications only: package-manager shims such as scoop's fpc.ps1 cannot be started as processes.
        $command = Get-Command $candidate -CommandType Application -ErrorAction SilentlyContinue | Select-Object -First 1
        if ($command) { return $command.Source }
    }
    $null
}

function Get-SpiralNativeTools {
    [pscustomobject]@{
        CC = Resolve-SpiralTool 'cc' @($env:SPIRAL_CC, 'gcc', 'clang', 'cc')
        Rustc = Resolve-SpiralTool 'rustc' @($env:SPIRAL_RUSTC, 'rustc')
        Fpc = Resolve-SpiralTool 'fpc' @($env:SPIRAL_FPC, 'fpc')
    }
}

function Get-SpiralCompilerDll([string]$Mode, [string]$Configuration = 'Release') {
    # SPIRAL_COMPILER_DLL runs another build of the host, e.g. the split one from scripts/gear-dev.ps1.
    if ($env:SPIRAL_COMPILER_DLL) { return $env:SPIRAL_COMPILER_DLL }
    $mode = ConvertTo-SpiralMode $Mode
    Join-Path (Get-SpiralCacheDir) "bin/$mode/SpiralCompiler/$Configuration/net11.0/SpiralCompiler.dll"
}

# Generated test results live in the cache, not in the tree: the single-flight oracle (written by
# `test.ps1 -Bless`) and each lane's scoreboard (written by `test.ps1 -Record`).
function Get-SpiralBaselinePath { Join-Path (Get-SpiralCacheDir) 'baseline/EXPECTED.tsv' }
function Get-SpiralScoreboardPath([string]$Mode) { Join-Path (Get-SpiralCacheDir) "scoreboards/$(ConvertTo-SpiralMode $Mode).tsv" }

# Where `packages: |core-` resolves: the standard library in polyglot's The-Spiral-Language checkout,
# reached through the spiral repo's deps/polyglot link (or a sibling polyglot checkout). Never copied here.
function Get-SpiralPackageDir {
    $candidates = @(
        $env:SPIRAL_COMPILER_PACKAGE_DIR,
        (Join-Path $BundleRoot '../../../deps/polyglot/deps/The-Spiral-Language/VS Code Plugin'),
        (Join-Path $BundleRoot '../../../../polyglot/deps/The-Spiral-Language/VS Code Plugin')
    )
    foreach ($candidate in $candidates) {
        if ($candidate -and (Test-Path (Join-Path $candidate 'core/package.spiproj'))) { return (Resolve-Path $candidate).Path }
    }
    throw 'The-Spiral-Language core package not found: link deps/polyglot or set SPIRAL_COMPILER_PACKAGE_DIR.'
}

# Flat directory of the compiler's dependency DLLs (compiler/lib/Packages.props plus the SDK's FSharp.Core),
# for projects the splitter generates. Built into the cache on first use; nothing binary lives in the tree.
function Get-SpiralLibDir {
    $cache = Get-SpiralCacheDir
    $lib = Join-Path $cache 'lib'
    if (-not (Test-Path (Join-Path $lib 'Hopac.dll'))) {
        $dotnet = Resolve-SpiralDotnet
        & $dotnet build (Join-Path $BundleRoot 'compiler/lib/Dependencies.fsproj') -c Release -nologo -v:q "-p:SpiralCacheDir=$cache" | Out-Host
        if ($LASTEXITCODE -ne 0) { throw 'building the dependency directory failed' }
    }
    (Resolve-Path $lib).Path
}

function Get-FileSha256([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path)) { return '' }
    (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

# Residual text hash that ignores line-ending and trailing-whitespace differences.
function Get-TextSha256([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path)) { return '' }
    $text = [IO.File]::ReadAllText($Path) -replace "`r`n", "`n"
    $text = ($text -split "`n" | ForEach-Object { $_.TrimEnd() }) -join "`n"
    $bytes = [Text.Encoding]::UTF8.GetBytes($text.TrimEnd())
    [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData($bytes)).ToLowerInvariant()
}
