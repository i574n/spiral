param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../../../deps/polyglot/scripts/core.ps1
. ../../lib.ps1


$projectName = "near_wallet"

if (!$fast) {
    { . $(Search-Command bun) install --frozen-lockfile } | Invoke-Block
}

$targetDir = GetTargetDir $projectName

Remove-Item ./dist -Recurse -Force -ErrorAction Ignore

{ . $(Search-Command bunx) --bun esbuild --bundle --minify --loader:.wasm=file --outdir=dist "C:\home\git\singularity\playground\gleam\build\dev\javascript\app\app.mjs" } | Invoke-Block -OnError Continue
# { . $(Search-Command bunx) --bun esbuild --bundle --minify --loader:.html=copy --loader:.wasm=file --outdir=dist "C:\home\git\singularity\playground\gleam\index.html" } | Invoke-Block -OnError Continue
#
# { wasm-pack build --target web --dev <# --reference-types # --weak-refs --no-typescript #> } | Invoke-Block
{ trunk build $($fast ? $() : '--release') $($fast ? $() : '--minify') --dist="dist" --public-url="./" --no-sri } | Invoke-Block -EnvironmentVariables @{ "TRUNK_TOOLS_WASM_BINDGEN" = "0.2.93" }


$path = "$targetDir/trunk/index.html"
$html = Get-Content $path -Raw

# const wasm = await init({ module_or_path: './near_wallet-f737b13e62d4337_bg.wasm' });
$wasmFile = ($html | Select-String -Pattern "init\(.*?'\./(.*?)'.*?\);").Matches[0].Groups[1].Value
$jsFile = ($html | Select-String -Pattern "import init, \* as bindings from '\./(.*?)';").Matches[0].Groups[1].Value

(Get-Content "$targetDir/trunk/$jsFile" -Raw) `
    -replace "\('.*', import.meta.url\);", "('$wasmFile', import.meta.url);" `
| Set-Content "$targetDir/trunk/$jsFile"

# Write-Output "rna:"
# { . $(Search-Command bunx) --bun @chialab/rna build --bundle --assetNames "[name]" $path --output "$targetDir/rna" --target es2022 } | Invoke-Block

# Copy-Item Cargo2.toml "$targetDir/trunk/Cargo.toml" -Force

# { trunk build $($fast ? $() : '--release') $($fast ? $() : '--minify') --dist="$ScriptDir/dist" --public-url="./" --no-sri } | Invoke-Block -EnvironmentVariables @{ "TRUNK_TOOLS_WASM_BINDGEN" = "0.2.93" } -Location "$targetDir/trunk"

$path = "dist/index.html"

# Move-Item $path dist/popup.html -Force
# Copy-Item dist/popup.html dist/index.html -Force
# Copy-Item public/manifest.json dist/manifest.json -Force

#
{ Copy-Item ./public/* ./dist -Recurse -Force } | Invoke-Block -OnError Continue

if (!$fast) {
    # { . $(Search-Command bun) test:e2e } | Invoke-Block -OnError Continue
}

Write-Output "spiral/lib/spiral/near/wallet/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"
