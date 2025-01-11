param(
    $fast,
    $SkipNotebook,
    $SkipFsx,
    $SkipPreBuild,
    $ScriptDir = $PSScriptRoot
)
$ScriptDir | Set-Location
$ErrorActionPreference = "Stop"
. ../../deps/polyglot/scripts/core.ps1
. ../../deps/polyglot/lib/spiral/lib.ps1

$ResolvedScriptDir = ResolveLink $ScriptDir
$ResolvedScriptDir | Set-Location

Write-Output "spiral/apps/spiral/build.ps1 / ScriptDir: $ScriptDir / ResolvedScriptDir: $ResolvedScriptDir"

$projectName = "spiral"

if (!$SkipPreBuild -and !$SkipFsx) {
    if (!$fast -and !$SkipNotebook) {
        echo "../../deps ls"
        { ls } | Invoke-Block -Location ../../deps
        echo "../.. ls"
        { ls } | Invoke-Block -Location ../..
        echo "../../workspace ls"
        { ls } | Invoke-Block -Location ../../workspace
        echo "../../workspace/target ls"
        { ls } | Invoke-Block -Location ../../workspace/target
        echo "../../workspace/target/release ls"
        { ls } | Invoke-Block -Location ../../workspace/target/release

        $workingDirectory = ResolveLink (GetFullPath "../../deps/polyglot")
        { . ../../deps/polyglot/apps/spiral/dist/Supervisor$(_exe) --execute-command "../../workspace/target/release/spiral$(_exe) dib --path $ResolvedScriptDir/$projectName.dib --working-directory $workingDirectory" } | Invoke-Block -Retries 3
    }

    { . ../../deps/polyglot/apps/parser/dist/DibParser$(_exe) "$projectName.dib" spi } | Invoke-Block

    { . ../../deps/polyglot/apps/spiral/dist/Supervisor$(_exe) --build-file "$projectName.spi" "$projectName.fsx" } | Invoke-Block
}

if (!$SkipPreBuild) {
    $runtime = $fast -or $env:CI ? @("--runtime", ($IsWindows ? "win-x64" : "linux-x64")) : @()
    $builderArgs = @("$projectName.fsx", "--persist-only", $runtime, "--packages", "Fable.Core", "--modules", @(GetFsxModules), "lib/fsharp/Common.fs")

    { . ../../deps/polyglot/apps/builder/dist/Builder$(_exe) @builderArgs } | Invoke-Block

    $targetDir = GetTargetDir $projectName

    { BuildFable $targetDir $projectName "rs" } | Invoke-Block

    $path = "$targetDir/target/rs/polyglot/target/Builder/$projectName/$projectName.rs"
    if (!($path | Test-Path)) {
        $path = "$targetDir/target/rs/target/Builder/$projectName/$projectName.rs"
    }

    Write-Output "spiral/apps/spiral/build.ps1 / path: $path"

    (Get-Content $path) `
        -replace ".fsx`"]", ".rs`"]" `
        -replace "`"../../../../../../../../../../../../polyglot", "`"../../deps/polyglot" `
        -replace "`"../../../../../../../../../../../../lib", "`"../../deps/polyglot/lib" `
        -replace "`"../../../lib", "`"../../deps/polyglot/lib" `
        | FixRust `
        | Set-Content "$projectName.rs"

    if ($env:CI) {
        $targetDir | Remove-Item -Recurse -Force -ErrorAction Ignore
    }
}

cargo fmt --

if (!$fast) {
    { cargo test --release -- --show-output } | Invoke-Block
}
{ cargo build --release } | Invoke-Block -OnError Continue
