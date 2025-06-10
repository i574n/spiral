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


$projectName = "spiral_compiler"

if (!$SkipFsx) {
    if (!$fast -and !$SkipNotebook -and !$env:CI) {
        $workingDirectory = ResolveLink (GetFullPath "../../deps/polyglot/lib/fsharp")
        { . ../../workspace/target/release/spiral$(_exe) dib --path "$ScriptDir/$projectName.dib" --working-directory $workingDirectory } | Invoke-Block -Retries 3
    }

    { . ../../deps/polyglot/apps/parser/dist/DibParser$(_exe) "$projectName.dib" fs } | Invoke-Block
}

$runtime = $fast -or $env:CI ? @("--runtime", ($IsWindows ? "win-x64" : "linux-x64")) : @()
$builderArgs = @("$projectName.fs", $runtime, "--packages", "Fable.Core", "FSharp.Control.AsyncSeq", "FSharpx.Collections", "Hopac", "Argu", "FParsec", "FSharp.Json", "Microsoft.AspNetCore.SignalR.Client", "System.Management", "--modules", @(GetFsxModules), "lib/fsharp/Common.fs")
{ . ../../deps/polyglot/apps/builder/dist/Builder$(_exe) @builderArgs } | Invoke-Block -OnError Continue

$targetDir = GetTargetDir $projectName

Write-Output "spiral/apps/compiler/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"

if ($env:CI) {
    Remove-Item $targetDir -Recurse -Force -ErrorAction Ignore
}
