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
    # The notebook runs through Kino and exports src/near_wallet.spi (outputs <nb>.livemd.ipynb/.html).
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
    # src/near_wallet.gleam with the Spiral compiler's own Gleam backend.
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
# { . $(Search-Command bunx) --bun esbuild --bundle --minify --loader:.html=copy --loader:.wasm=file --outdir=dist "C:\home\git\singularity\playground\gleam\index.html" } | Invoke-Block -OnError Continue
#
# # { wasm-pack build --target web --dev <# --reference-types # --weak-refs --no-typescript #> } | Invoke-Block
$distDir = "dist"
{ trunk build $($fast ? $() : '--release') $($fast ? $() : '--minify') --dist="$distDir" --public-url="./" --no-sri } | Invoke-Block -EnvironmentVariables @{ "TRUNK_TOOLS_WASM_BINDGEN" = "0.2.93" }


$path = "$distDir/index.html"
$html = Get-Content $path -Raw

# const wasm = await init({ module_or_path: './near_wallet-f737b13e62d4337_bg.wasm' });
$wasmFile = ($html | Select-String -Pattern "init\(.*?'\./(.*?)'.*?\);").Matches[0].Groups[1].Value
$jsFile = ($html | Select-String -Pattern "import init, \* as bindings from '\./(.*?)';").Matches[0].Groups[1].Value

(Get-Content "$distDir/$jsFile" -Raw) `
    -replace "\('.*', import.meta.url\);", "('$wasmFile', import.meta.url);" `
| Set-Content "$distDir/$jsFile"

# Write-Output "rna:"
# { . $(Search-Command bunx) --bun @chialab/rna build --bundle --assetNames "[name]" $path --output "$targetDir/rna" --target es2022 } | Invoke-Block

# Copy-Item Cargo2.toml "$distDir/Cargo.toml" -Force

# { trunk build $($fast ? $() : '--release') $($fast ? $() : '--minify') --dist="$ScriptDir/dist" --public-url="./" --no-sri } | Invoke-Block -EnvironmentVariables @{ "TRUNK_TOOLS_WASM_BINDGEN" = "0.2.93" } -Location "$distDir"

# $path = "dist/index.html"

# Move-Item $path dist/popup.html -Force
# Copy-Item dist/popup.html dist/index.html -Force
# Copy-Item public/manifest.json dist/manifest.json -Force

#
# { Copy-Item ./public/* ./dist -Recurse -Force } | Invoke-Block -OnError Continue

if (!$fast) {
    { . $(Search-Command bun) test:e2e } | Invoke-Block -OnError Continue
}

Write-Output "spiral/lib/spiral/near/wallet/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"
