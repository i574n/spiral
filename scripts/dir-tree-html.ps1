param(
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ./core.ps1

$spiralRoot = ResolveLink (Split-Path $ScriptDir)
$repo = Join-Path (Split-Path $spiralRoot) "dir-tree-html"
$exe = Join-Path $repo "dist/dir-tree-html$(_exe)"
if (!(Test-Path $exe)) {
    if (!(Test-Path (Join-Path $repo ".git"))) {
        $url = git ls-remote --get-url
        $owner = ($url -split '/' | Select-Object -Last 2 | Select-Object -First 1) -replace '\.git$', '' ?? $env:GITHUB_REPOSITORY_OWNER
        $domain = ($url -split '/' | Select-Object -Last 3 | Select-Object -First 1) ?? $env:GITHUB_SERVER_URL -replace 'https?://', ''
        git clone https://$domain/$owner/dir-tree-html.git $repo
        if ($LASTEXITCODE -ne 0) { throw "dir-tree-html.ps1 / git clone dir-tree-html failed (exit code $LASTEXITCODE)" }
    }
    { pwsh (Join-Path $repo "scripts/init.ps1") -fast 1 } | Invoke-Block
    { pwsh (Join-Path $repo "build.ps1") } | Invoke-Block
}
Write-Output $exe
