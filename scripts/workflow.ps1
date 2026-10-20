param(
    $fast,
    [switch] $Compiler,
    [string] $Suite = 'all',
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"


pwsh init.ps1

. ./core.ps1

if ($Compiler) {
    $resolveDotnet = ". ../apps/compiler/tmp/scripts/env.ps1; try { Resolve-SpiralDotnet } catch { '' }"
    $dotnet = pwsh -NoProfile -Command $resolveDotnet | Select-Object -Last 1
    if (-not $dotnet) {
        { pwsh ../apps/compiler/tmp/scripts/install-dotnet.ps1 } | Invoke-Block
        $dotnet = pwsh -NoProfile -Command $resolveDotnet | Select-Object -Last 1
    }
    if (-not $dotnet) { throw 'no .NET 11 SDK after install-dotnet.ps1' }
    $env:SPIRAL_DOTNET = $dotnet
    "dotnet: $dotnet"

    { pwsh ../apps/compiler/tmp/scripts/build.ps1 -Mode single-flight } | Invoke-Block

    { pwsh ../apps/compiler/tmp/formatter/report.ps1 } | Invoke-Block

    $matrixRustToolchain = [regex]::Match([IO.File]::ReadAllText((Resolve-Path ../apps/compiler/tmp/scripts/test.ps1)), "'\+((?:nightly-)?[0-9][0-9.-]*)', '-C', 'opt-level").Groups[1].Value
    if (-not $matrixRustToolchain) { throw 'test.ps1 no longer names the matrix rustc toolchain' }
    { rustup toolchain install $matrixRustToolchain --profile minimal } | Invoke-Block

    { pwsh ../apps/compiler/tmp/scripts/test.ps1 -Mode single-flight -Suite $Suite -Native -Parallel 2 -Accept } | Invoke-Block

    return
}

{ pwsh dir-tree-html.ps1 } | Invoke-Block

{ pwsh ../apps/spiral/build.ps1 -fast 1 } | Invoke-Block

{ pwsh build.ps1 } | Invoke-Block

{ pwsh outdated.ps1 } | Invoke-Block

{ pwsh publish.ps1 } | Invoke-Block
