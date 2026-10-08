param(
    $fast,
    $SkipNotebook,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../scripts/core.ps1
. ../../lib/spiral/lib.ps1


$projectName = "spiral_wasm"

$livebook = Join-Path $ScriptDir "../kino/spi/run_notebook.ps1"
$notebook = @("--path", "$ScriptDir/$projectName.livemd", "--spi-path", "$ScriptDir/$projectName.spi")
if (!$fast -and !$SkipNotebook) {
    { pwsh -NoProfile -File $livebook @notebook --output-path "$ScriptDir/$projectName.livemd.ipynb" } | Invoke-Block -Retries 3
}
else {
    { pwsh -NoProfile -File $livebook @notebook --export-only } | Invoke-Block
}

$targetDir = GetTargetDir $projectName

if (!(BuildSpiral "$projectName.spi" "$projectName.rs" "apps/wasm")) {
    throw "RUST-FAILED apps/wasm / compile"
}
{ cargo +nightly-2025-11-01 build --profile release-unwind --package $projectName } | Invoke-Block -Location ../../workspace
$cargoTarget = (cargo metadata --format-version 1 --no-deps --manifest-path ../../workspace/Cargo.toml | ConvertFrom-Json).target_directory
$built = "$cargoTarget/release-unwind/$projectName$(_exe)"
$rustOutput = & $built --help 2>&1 | ForEach-Object { "$_" }
$rustExit = $LASTEXITCODE
$rustOutput | ForEach-Object { Write-Output "spiral/apps/wasm/build.ps1 / run / $_" }
if ($rustExit -ne 0 -or !($rustOutput -match '--wasm')) {
    throw "RUST-FAILED apps/wasm / run --help exit code $($rustExit): expected exit code 0 and the --wasm argument"
}
Write-Output "RUST-OK apps/wasm"

$shipped = "../../workspace/target/release/$projectName$(_exe)"
New-Item -ItemType Directory -Force (Split-Path $shipped) | Out-Null
Remove-Item $shipped -Force -ErrorAction Ignore
Copy-Item $built $shipped
Write-Output "spiral/apps/wasm/build.ps1 / shipped $projectName to $shipped"

Write-Output "spiral/apps/wasm/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"

if ($env:CI) {
    Remove-Item $targetDir -Recurse -Force -ErrorAction Ignore
}
