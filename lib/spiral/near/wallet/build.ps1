param(
    $fast,
    $SkipPreBuild,
    $SkipNotebook,
    $SkipGleam,
    $ScriptDir = $PSScriptRoot
)
$ScriptDir | Set-Location
$ErrorActionPreference = "Stop"
. ../../../../scripts/core.ps1
. ../../lib.ps1

$ResolvedScriptDir = ResolveLink $ScriptDir
$ResolvedScriptDir | Set-Location

Write-Output "spiral/lib/spiral/near/wallet/build.ps1 / ScriptDir: $ScriptDir / ResolvedScriptDir: $ResolvedScriptDir"

$projectName = "near_wallet"

if (!$SkipPreBuild) {
    $livebook = Join-Path $ResolvedScriptDir "../../../../apps/kino/spi/run_notebook.ps1"
    $notebook = @("--path", "$ResolvedScriptDir/src/$projectName.livemd", "--spi-path", "$ResolvedScriptDir/src/$projectName.spi")
    if (!$SkipNotebook) {
        { pwsh -NoProfile -File $livebook @notebook --output-path "$ResolvedScriptDir/src/$projectName.livemd.ipynb" } | Invoke-Block -Retries 3
    }
    else {
        { pwsh -NoProfile -File $livebook @notebook --export-only } | Invoke-Block
    }
}

if (!$SkipGleam) {
    if (!(BuildSpiral "src/$projectName.spi" "src/$projectName.gleam" "lib/spiral/near/wallet" -Backend "Gleam")) {
        throw "GLEAM-FAILED lib/spiral/near/wallet / compile"
    }
}

if (!$fast) {
    { . $(Search-Command bun) install --frozen-lockfile } | Invoke-Block
}

$targetDir = GetTargetDir $projectName

Remove-Item ./dist -Recurse -Force -ErrorAction Ignore

{ gleam build } | Invoke-Block

$path = "build/dev/javascript/near_wallet/near_wallet.mjs"
$text = Get-Content $path -Raw
if (-not $text.Trim().EndsWith("main()")) {
    "$text`nmain()" | Set-Content $path
}

{ . $(Search-Command bunx) --bun esbuild --bundle --minify --loader:.wasm=file --outdir=dist $path } | Invoke-Block -OnError Continue
$distDir = "dist"
{ trunk build $($fast ? $() : '--release') $($fast ? $() : '--minify') --dist="$distDir" --public-url="./" --no-sri } | Invoke-Block -EnvironmentVariables @{ "TRUNK_TOOLS_WASM_BINDGEN" = "0.2.93" }


$path = "$distDir/index.html"
$html = Get-Content $path -Raw

$wasmFile = ($html | Select-String -Pattern "init\(.*?'\./(.*?)'.*?\);").Matches[0].Groups[1].Value
$jsFile = ($html | Select-String -Pattern "import init, \* as bindings from '\./(.*?)';").Matches[0].Groups[1].Value

(Get-Content "$distDir/$jsFile" -Raw) `
    -replace "\('.*', import.meta.url\);", "('$wasmFile', import.meta.url);" `
| Set-Content "$distDir/$jsFile"


if (!$fast) {
    { . $(Search-Command bun) test:e2e } | Invoke-Block -OnError Continue
}

Write-Output "spiral/lib/spiral/near/wallet/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"
