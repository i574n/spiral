param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../deps/polyglot/scripts/core.ps1
. ../../deps/polyglot/deps/spiral/lib/spiral/lib.ps1


$projectName = "spiral_compiler"

# spiral_compiler.fs is the source of truth (the single-flight core); there is no notebook to export it from.
$runtime = $fast -or $env:CI ? @("--runtime", ($IsWindows ? "win-x64" : "linux-x64")) : @()
$builderArgs = @("$projectName.fs", $runtime, "--packages", "FSharp.Control.AsyncSeq", "FSharpx.Collections", "Hopac", "Argu", "FParsec", "FSharp.Json", "Microsoft.AspNetCore.SignalR.Client", "System.Management", "--modules", @(GetFsxModules), "lib/fsharp/Common.fs")
{ . ../../deps/polyglot/apps/builder/dist/Builder$(_exe) @builderArgs } | Invoke-Block -OnError Continue

$targetDir = GetTargetDir $projectName

Write-Output "spiral/apps/compiler/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"

if ($env:CI) {
    Remove-Item $targetDir -Recurse -Force -ErrorAction Ignore
}
