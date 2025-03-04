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

    { . ../../deps/polyglot/apps/parser/dist/DibParser$(_exe) "$projectName.dib" spi } | Invoke-Block

    { . ../../deps/polyglot/apps/spiral/dist/Supervisor$(_exe) --build-file "$projectName.spi" "$projectName.fsx" } | Invoke-Block
}

$runtime = $fast -or $env:CI ? @("--runtime", ($IsWindows ? "win-x64" : "linux-x64")) : @()
$builderArgs = @("$projectName.fsx", "--persist-only", $runtime, "--packages", "Fable.Core", "--modules", @(GetFsxModules), "lib/fsharp/Common.fs")
{ . ../../deps/polyglot/apps/builder/dist/Builder$(_exe) @builderArgs } | Invoke-Block

$targetDir = GetTargetDir $projectName

{ BuildFable $targetDir $projectName "rs" } | Invoke-Block

$path = "$targetDir/target/rs/$projectName.rs"
if (!(Test-Path $path)) {
    $path = "$targetDir/target/rs/polyglot/target/Builder/$projectName/$projectName.rs"
}
if (!(Test-Path $path)) {
    $path = "$targetDir/target/rs/target/Builder/$projectName/$projectName.rs"
}
Write-Output "spiral/apps/wasm/build.ps1 / path: $path"
(Get-Content $path) `
    -replace ".fsx`"]", ".rs`"]" `
    -replace "`"../../../../../../../../../../../../polyglot", "`"../../deps/polyglot" `
    -replace "`"../../../../../../../../../../../../lib", "`"../../deps/polyglot/deps/spiral/lib" `
    -replace "`"../../../../../lib", "`"../../deps/polyglot/deps/spiral/lib" `
    -replace "`"../../../../../deps/spiral", "`"../.." `
    -replace "`"../../../lib", "`"../../deps/polyglot/lib" `
    -replace "`"./lib", "`"../../deps/polyglot/lib" `
    | FixRust `
    | Set-Content "$projectName.rs"

if ($env:CI) {
    Remove-Item $targetDir -Recurse -Force -ErrorAction Ignore
}

Write-Output "spiral/apps/wasm/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"

cargo fmt --

{ cargo build --release } | Invoke-Block -Linux
