param(
    $fast,
    $SkipNotebook,
    $SkipFsx,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../deps/polyglot/scripts/core.ps1
. ../../deps/polyglot/deps/spiral/lib/spiral/lib.ps1


$projectName = "spiral_wasm"

if (!$SkipFsx) {
    if (!$fast -and !$SkipNotebook) {
        $workingDirectory = ResolveLink (GetFullPath "../../deps/polyglot")
        { . ../../workspace/target/release/spiral$(_exe) dib --path "$ScriptDir/$projectName.dib" --working-directory $workingDirectory } | Invoke-Block -Retries 3
    }

    { . ../../workspace/target/release/spiral$(_exe) dib-export "$ScriptDir/$projectName.dib" spi } | Invoke-Block

    { . ../../deps/polyglot/apps/spiral/dist/Supervisor$(_exe) --build-file "$projectName.spi" "$projectName.fsx" } | Invoke-Block
}

$targetDir = GetTargetDir $projectName

# Native Rust: the spiral_wasm.spi entry (its `main` has a `Rust` arm that runs `run_main` with the process args) -> a
# crate under the target dir with the Spiral compiler's own Rust backend. Running it needs a contract .wasm and a NEAR
# sandbox (the spiral CLI's `rust -c` cells do that), so the required check is that the binary builds and its clap
# command answers `--help` (exit code 0, the `--wasm` argument listed). It then ships as
# workspace/target/release/spiral_wasm, the path the spiral CLI runs.
# The compiler writes its output next to the .spi it compiles, so it compiles a staged copy (the .spi plus a package
# file with an absolute packageDir) under the target dir.
$nativeDir = "$targetDir/native"
$nativeStage = "$nativeDir/spi"
Remove-Item $nativeStage -Recurse -Force -ErrorAction Ignore
New-Item -ItemType Directory -Force "$nativeDir/src", $nativeStage | Out-Null
Copy-Item "$projectName.spi" $nativeStage
$packageDir = (ResolveLink (GetFullPath "../../deps/polyglot/deps/spiral/lib")) -replace '\\', '/'
@("packageDir: $packageDir", 'packages:', '    |core-', '    spiral-', 'modules:', "    $projectName") | Set-Content "$nativeStage/package.spiproj"
@(
    '[package]', "name = `"$projectName`"", 'version = "0.0.1"', 'edition = "2021"', '', '[workspace]', '', '[dependencies]',
    'anyhow = "1.0"', 'clap = "4.5"', 'tokio = { version = "1.40", features = ["full"] }',
    'near-workspaces = { version = "=0.11.1", features = ["experimental", "unstable"] }',
    'near-sandbox-utils = { version = ">=0.11,<1", features = ["global_install"] }', 'near-sdk = "=5.11.0"'
) | Set-Content "$nativeDir/Cargo.toml"
# The spiral workspace's lock file pins the versions the Fable crate (a workspace member with the same dependencies)
# builds with: near-workspaces needs older transitive deps.
Copy-Item ../../workspace/Cargo.lock "$nativeDir/Cargo.lock" -Force
if (!(BuildNativeRust "$nativeStage/$projectName.spi" "$nativeDir/src/main.rs" "apps/wasm")) {
    throw "NATIVE-RUST-FAILED apps/wasm / compile"
}
# near-workspaces' build script sets up the NEAR sandbox, which only exists for Linux.
{ cargo +nightly-2025-11-01 build --release } | Invoke-Block -Location $nativeDir -Linux
Push-Location $nativeDir
$nativeOutput = [scriptblock]::Create("./target/release/$projectName --help") | Invoke-Linux 2>&1 | ForEach-Object { "$_" }
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
Copy-Item "$nativeDir/target/release/$projectName" $shipped
Write-Output "spiral/apps/wasm/build.ps1 / shipped the native $projectName to $shipped"

Write-Output "spiral/apps/wasm/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"

if ($env:CI) {
    Remove-Item $targetDir -Recurse -Force -ErrorAction Ignore
}
