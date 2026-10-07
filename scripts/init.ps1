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

# The-Spiral-Language fork: only its `VS Code Plugin/core` is used, as the `|core-` package (the compiler finds it
# through apps/compiler/tmp/scripts/env.ps1 Get-SpiralPackageDir, Kino through its toolchain); nothing is copied from it.
$fork = "../deps/The-Spiral-Language"
if (!(Test-Path "$fork/.git")) {
    New-Item -ItemType Directory -Force ../deps | Out-Null
    git clone --recurse-submodules https://$domain/$owner/The-Spiral-Language.git $fork
    if ($LASTEXITCODE -ne 0) { throw "init.ps1 / git clone The-Spiral-Language failed (exit code $LASTEXITCODE)" }
} elseif (!$fast) {
    git -C $fork pull
    if ($LASTEXITCODE -ne 0) { Write-Output "init.ps1 / git pull in $fork failed (exit code $LASTEXITCODE), keeping the checkout" }
}

# Toolchains the builds and notebooks of this repo use. Each step runs only when its tool is missing, except rustup's
# installs (no-ops when present).
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
    $env:PATH = "$(Join-Path $HOME '.cargo/bin')$([IO.Path]::PathSeparator)$env:PATH"
}
# nightly-2025-05-09: the default (Kino's rustc cells, wasm); nightly-2024-07-14: the NEAR contract toolchain
# (`spiral rust --contract`); nightly-2025-11-01: the CLI, apps and `cargo test` builds.
rustup install nightly-2025-05-09
rustup default nightly-2025-05-09
rustup +nightly-2025-05-09 target add wasm32-unknown-unknown
rustup +nightly-2025-05-09 component add clippy rust-src rustfmt
rustup install nightly-2024-07-14
rustup +nightly-2024-07-14 target add wasm32-unknown-unknown
rustup +nightly-2024-07-14 component add clippy rust-src rustfmt
rustup install nightly-2025-11-01

if (!(Test-Command "bun") -and !(Test-Path (Join-Path $HOME ".bun/bin/bun$($IsWindows ? '.exe' : '')"))) {
    if ($IsWindows) { Invoke-RestMethod bun.sh/install.ps1 | Invoke-Expression } else { curl -fsSL https://bun.sh/install | bash }
}

# jupyter nbconvert (the notebooks' html outputs), mpmath/cupy (`spiral cuda`). Ubuntu's system Python is externally
# managed (PEP 668): pip refuses a plain install there.
if (Test-Command "pip") {
    $pipArgs = $IsLinux ? @("--break-system-packages") : @()
    pip install @pipArgs -r ../requirements.txt
    if ($LASTEXITCODE -ne 0) { Write-Output "init.ps1 / pip install -r requirements.txt failed (exit code $LASTEXITCODE)" }
} else {
    Write-Output "init.ps1 / no pip: the notebooks' html outputs need jupyter (pip install -r requirements.txt)"
}

# trunk (wasm app bundles: `spiral gleam` targets, lib/spiral/near/wallet).
if (!(Test-Command "trunk")) {
    cargo +nightly-2025-11-01 install trunk --version 0.21.14 --locked
    if ($LASTEXITCODE -ne 0) { Write-Output "init.ps1 / cargo install trunk failed (exit code $LASTEXITCODE)" }
}

# Kino (apps/kino) needs Elixir >= 1.18 with its OTP and Gleam >= 1.14 (README "CI"); the .NET 11 SDK and the compiler it
# provides itself (spi/run_notebook.ps1).
foreach ($tool in "elixir", "gleam") {
    if (!(Test-Command $tool)) { Write-Output "init.ps1 / $tool is not on PATH: notebooks (apps/kino) need it" }
}

# polyglot: still the source of the plot app, the Builder and dir-tree-html (scripts/build.ps1, publish.ps1) and of the
# shared core.ps1 helpers, until they move or go.
if (!$fast) {
    Set-Location (New-Item -ItemType Directory -Path "../.." -Force)
    git clone --recurse-submodules https://$domain/$owner/polyglot.git # --branch gh-pages
    Set-Location polyglot
    git pull
    Set-Location $ScriptDir
}

. ../../polyglot/scripts/core.ps1

EnsureSymbolicLink -Path "../deps/polyglot" -Target "../../polyglot"
