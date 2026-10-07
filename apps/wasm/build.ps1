param(
    $fast,
    $SkipNotebook,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../deps/polyglot/scripts/core.ps1
. ../../deps/polyglot/deps/spiral/lib/spiral/lib.ps1


$projectName = "spiral_wasm"

# The notebook runs through Kino and exports spiral_wasm.spi (the run's outputs keep the .dib route's names).
$livebook = Join-Path $ScriptDir "../kino/spi/livebook_dib.ps1"
$notebook = @("--path", "$ScriptDir/$projectName.livemd", "--spi-path", "$ScriptDir/$projectName.spi")
if (!$fast -and !$SkipNotebook) {
    { pwsh -NoProfile -File $livebook @notebook --output-path "$ScriptDir/$projectName.dib.ipynb" } | Invoke-Block -Retries 3
}
else {
    { pwsh -NoProfile -File $livebook @notebook --export-only } | Invoke-Block
}

$targetDir = GetTargetDir $projectName

# Native Rust: spiral_wasm.spi (its `main` has a `Rust` arm that runs `run_main` with the process args) -> spiral_wasm.rs
# (tracked) with the Spiral compiler's own Rust backend: the `spiral_wasm` bin of Cargo.toml, a member of the spiral
# workspace (its lock pins the older transitive deps near-workspaces needs). near-workspaces' build script sets up the
# NEAR sandbox, which only exists for Linux, so it builds there (its own target dir: target/linux), with the workspace's
# release-unwind profile. Running it needs a contract .wasm and a NEAR sandbox (the spiral CLI's `rust -c` cells do that),
# so the required check is that the binary builds and its clap command answers `--help` (exit code 0, the `--wasm`
# argument listed). It then ships as workspace/target/release/spiral_wasm, the path the spiral CLI runs.
if (!(BuildNativeRust "$projectName.spi" "$projectName.rs" "apps/wasm")) {
    throw "NATIVE-RUST-FAILED apps/wasm / compile"
}
{ cargo +nightly-2025-11-01 build --profile release-unwind --package $projectName --target-dir target/linux } `
    | Invoke-Block -Location ../../workspace -Linux
$built = "../../workspace/target/linux/release-unwind/$projectName"
Push-Location ../../workspace
$nativeOutput = [scriptblock]::Create("./target/linux/release-unwind/$projectName --help") | Invoke-Linux 2>&1 | ForEach-Object { "$_" }
$nativeExit = $LASTEXITCODE
Pop-Location
$nativeOutput | ForEach-Object { Write-Output "spiral/apps/wasm/build.ps1 / native run / $_" }
if ($nativeExit -ne 0 -or !($nativeOutput -match '--wasm')) {
    throw "NATIVE-RUST-FAILED apps/wasm / run --help exit code $($nativeExit): expected exit code 0 and the --wasm argument"
}
Write-Output "NATIVE-RUST-OK apps/wasm"

$shipped = "../../workspace/target/release/$projectName"
New-Item -ItemType Directory -Force (Split-Path $shipped) | Out-Null
Remove-Item $shipped -Force -ErrorAction Ignore
Copy-Item $built $shipped
Write-Output "spiral/apps/wasm/build.ps1 / shipped the native $projectName to $shipped"

Write-Output "spiral/apps/wasm/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"

if ($env:CI) {
    Remove-Item $targetDir -Recurse -Force -ErrorAction Ignore
}
