param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"


$url = git ls-remote --get-url
$owner = ($url -split '/' | Select-Object -Last 2 | Select-Object -First 1) -replace '\.git$', '' ?? $env:GITHUB_REPOSITORY_OWNER
$domain = ($url -split '/' | Select-Object -Last 3 | Select-Object -First 1) ?? $env:GITHUB_SERVER_URL -replace 'https?://', ''
Write-Output "init-app-build.ps1 / url: $url / owner: $owner / domain: $domain"

$fork = "../deps/The-Spiral-Language"
if (!(Test-Path "$fork/.git")) {
    New-Item -ItemType Directory -Force ../deps | Out-Null
    git clone --recurse-submodules https://$domain/$owner/The-Spiral-Language.git $fork
    if ($LASTEXITCODE -ne 0) { throw "init-app-build.ps1 / git clone The-Spiral-Language failed (exit code $LASTEXITCODE)" }
} elseif (!$fast) {
    git -C $fork pull
    if ($LASTEXITCODE -ne 0) { Write-Output "init-app-build.ps1 / git pull in $fork failed (exit code $LASTEXITCODE), keeping the checkout" }
}

if (Get-Command rustup -ErrorAction Ignore) {
    rustup install nightly-2025-11-01
}

if ($IsWindows -and !(Get-Command rsync -ErrorAction Ignore)) {
    if (Get-Command choco -ErrorAction Ignore) {
        choco install rsync -y
        if ($LASTEXITCODE -ne 0) { Write-Output "init-app-build.ps1 / choco install rsync failed (exit code $LASTEXITCODE)" }
    } else { Write-Output "init-app-build.ps1 / no rsync and no choco: scripts/publish-tree.ps1 needs rsync" }
}
