param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"


$url = git ls-remote --get-url
$owner = ($url -split '/' | Select-Object -Last 2 | Select-Object -First 1) -replace '\.git$', '' ?? $env:GITHUB_REPOSITORY_OWNER
$domain = ($url -split '/' | Select-Object -Last 3 | Select-Object -First 1) ?? $env:GITHUB_SERVER_URL -replace 'https?://', ''
Write-Output "init.ps1 / url: $url / owner: $owner / domain: $domain"

pwsh init-app-build.ps1 -fast $($fast ?? '')
if ($LASTEXITCODE -ne 0) { throw "init.ps1 / init-app-build.ps1 failed (exit code $LASTEXITCODE)" }

function Test-Command([string] $Name) { [bool](Get-Command $Name -ErrorAction Ignore) }
if (!(Test-Command "rustup")) {
    if ($IsWindows) {
        $rustupInit = Join-Path ([IO.Path]::GetTempPath()) "rustup-init.exe"
        Invoke-WebRequest -Uri "https://win.rustup.rs/x86_64" -OutFile $rustupInit
        & $rustupInit -y --default-toolchain none
    } else {
        $rustupInit = Join-Path ([IO.Path]::GetTempPath()) "rustup.sh"
        Invoke-WebRequest -Uri "https://sh.rustup.rs" -OutFile $rustupInit
        /bin/sh $rustupInit -y --default-toolchain none
    }
}
$cargoBin = Join-Path $HOME '.cargo/bin'
if ((Test-Path $cargoBin) -and -not (($env:PATH -split [IO.Path]::PathSeparator) -contains $cargoBin)) {
    $env:PATH = "$cargoBin$([IO.Path]::PathSeparator)$env:PATH"
}
$defaultKinoWasmToolchain = "nightly-2025-05-09"
$nearContractToolchain = "nightly-2024-07-14"
$appBuildToolchain = "nightly-2025-11-01"
rustup install $defaultKinoWasmToolchain
rustup default $defaultKinoWasmToolchain
rustup +$defaultKinoWasmToolchain target add wasm32-unknown-unknown
rustup +$defaultKinoWasmToolchain component add clippy rust-src rustfmt
rustup install $nearContractToolchain
rustup +$nearContractToolchain target add wasm32-unknown-unknown
rustup +$nearContractToolchain component add clippy rust-src rustfmt
rustup install $appBuildToolchain

if (!(Test-Command "bun") -and !(Test-Path (Join-Path $HOME ".bun/bin/bun$($IsWindows ? '.exe' : '')"))) {
    if ($IsWindows) { Invoke-RestMethod bun.sh/install.ps1 | Invoke-Expression } else { curl -fsSL https://bun.sh/install | bash }
}

if (Test-Command "pip") {
    $pipArgs = $IsLinux ? @("--break-system-packages") : @()
    pip install @pipArgs -r ../requirements.txt
    if ($LASTEXITCODE -ne 0) { Write-Output "init.ps1 / pip install -r requirements.txt failed (exit code $LASTEXITCODE)" }
} else {
    Write-Output "init.ps1 / no pip: the notebooks' html outputs need jupyter (pip install -r requirements.txt)"
}

if (!(Test-Command "trunk")) {
    if (Test-Command "cargo") {
        cargo +nightly-2025-11-01 install trunk --version 0.21.14 --locked
        if ($LASTEXITCODE -ne 0) { Write-Output "init.ps1 / cargo install trunk failed (exit code $LASTEXITCODE)" }
    } else { Write-Output "init.ps1 / no cargo on PATH: trunk not installed" }
}

foreach ($tool in "elixir", "gleam") {
    if (!(Test-Command $tool)) { Write-Output "init.ps1 / $tool is not on PATH: notebooks (apps/kino) need it" }
}

if (Test-Command "cargo") {
    if (!(Test-Command "cargo-binstall")) {
        if ($IsWindows) {
            Invoke-Expression (Invoke-WebRequest "https://raw.githubusercontent.com/cargo-bins/cargo-binstall/main/install-from-binstall-release.ps1").Content
        } else {
            curl -L --proto '=https' --tlsv1.2 -sSf https://raw.githubusercontent.com/cargo-bins/cargo-binstall/main/install-from-binstall-release.sh | bash
        }
    }
    if (!(Test-Command "sccache")) {
        cargo binstall -y sccache
        if ($LASTEXITCODE -ne 0) { Write-Output "init.ps1 / cargo binstall sccache failed (exit code $LASTEXITCODE)" }
    }
    try { & "$PSScriptRoot/patched-crates/install.ps1" cargo-outdated }
    catch { Write-Output "init.ps1 / patched cargo-outdated failed: $($_.Exception.Message)" }
}

if ($IsWindows -and !(Test-Command "rsync")) {
    if (Test-Command "choco") {
        choco install rsync -y
        if ($LASTEXITCODE -ne 0) { Write-Output "init.ps1 / choco install rsync failed (exit code $LASTEXITCODE)" }
    } else { Write-Output "init.ps1 / no rsync and no choco: scripts/publish.ps1 needs rsync" }
}

$bunBin = Join-Path $HOME '.bun/bin'
if ((Test-Path $bunBin) -and -not (($env:PATH -split [IO.Path]::PathSeparator) -contains $bunBin)) {
    $env:PATH = "$bunBin$([IO.Path]::PathSeparator)$env:PATH"
}
if (Test-Command "bunx") {
    bunx --bun playwright@1.44.0 install
    if ($LASTEXITCODE -ne 0) { Write-Output "init.ps1 / playwright browsers install failed (exit code $LASTEXITCODE)" }
}

. ./core.ps1

if ($IsWindows -and (Test-Command "wsl")) {
    $distributions = (wsl --list --quiet) -replace "`0", ""
    if (-not ($distributions -contains "Ubuntu")) {
        wsl --install Ubuntu --no-launch
    }
    { sudo sh init.sh } | Invoke-Block -Linux -OnError Continue
    { sh init.sh } | Invoke-Block -Linux -OnError Continue
}
