param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"


$url = git ls-remote --get-url
$owner = ($url -split '/' | Select-Object -Last 2 | Select-Object -First 1) -replace '\.git$', '' ?? $env:GITHUB_REPOSITORY_OWNER
Write-Output "init.ps1 / url: $url / owner: $owner"

if (!$fast) {
    Set-Location (New-Item -ItemType Directory -Path "../.." -Force)
    git clone --recurse-submodules https://github.com/$owner/polyglot.git # --branch gh-pages
    Set-Location polyglot
    git pull
    Set-Location $ScriptDir
}

. ../../polyglot/scripts/core.ps1

EnsureSymbolicLink -Path "../deps/polyglot" -Target "../../polyglot"
