param(
    $fast,
    $sequential,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../scripts/core.ps1

$ResolvedScriptDir = ResolveLink $ScriptDir
$ResolvedScriptDir | Set-Location

Write-Output "spiral/lib/spiral/build.ps1 / ScriptDir: $ScriptDir / ResolvedScriptDir: $ResolvedScriptDir"

$livebook = Join-Path $ResolvedScriptDir "../../apps/kino/spi/run_notebook.ps1"
$notebooks = @(
    "physics", "parsing", "sm'", "rust/rust", "rust/testing", "rust/near", "rust/near_workspaces", "testing", "guid",
    "async", "runtime", "trace", "am'", "crypto", "common", "resultm", "console", "base", "convert", "date_time", "math",
    "mapm", "optionm'", "listm'", "reflection", "iter", "wasm", "leptos/leptos", "lustre", "util", "platform", "stream",
    "threading", "benchmark", "seq", "env", "file_system", "networking"
)
function Get-NotebookArgs([string] $Notebook) {
    $path = Join-Path $ResolvedScriptDir "$Notebook.livemd"
    $exports = @("--path", $path, "--spi-path", (Join-Path $ResolvedScriptDir "$Notebook.spi"))
    if ($Notebook -eq "sm'") { $exports += @("--spir-path", (Join-Path $ResolvedScriptDir "sm'_real.spir")) }
    $exports
}

if (!$fast) {
    $jobs = $notebooks | ForEach-Object { [pscustomobject]@{ Notebook = $_; Arguments = (Get-NotebookArgs $_) } }
    $runs = $jobs | ForEach-Object -ThrottleLimit ($sequential ? 1 : 4) -Parallel {
        $notebook = $_.Notebook
        $arguments = $_.Arguments
        $output = Join-Path $using:ResolvedScriptDir "$notebook.livemd.ipynb"
        $log = @()
        $exitCode = 1
        foreach ($attempt in 1..3) {
            $log = pwsh -NoProfile -File $using:livebook @arguments --output-path $output 2>&1 | ForEach-Object { "$_" }
            $exitCode = $LASTEXITCODE
            if ($exitCode -eq 0) { break }
        }
        [pscustomobject]@{ Notebook = $notebook; ExitCode = $exitCode; Log = $log }
    }
    $runs | Sort-Object Notebook | ForEach-Object { Write-Output "spiral/lib/spiral/build.ps1 / $($_.Notebook) / exit $($_.ExitCode)" }
    $failed = @($runs | Where-Object ExitCode -ne 0)
    foreach ($run in $failed) { $run.Log | Select-Object -Last 30 | ForEach-Object { Write-Output "spiral/lib/spiral/build.ps1 / $($run.Notebook) / $_" } }
    if ($failed) { throw "spiral/lib/spiral/build.ps1 / notebooks failed: $(($failed | ForEach-Object Notebook) -join ', ')" }
}

foreach ($notebook in $notebooks) {
    $arguments = Get-NotebookArgs $notebook
    { pwsh -NoProfile -File $livebook @arguments --export-only } | Invoke-Block
}

if (!$fast) {
    { pwsh near/wallet/build.ps1 } | Invoke-Block
}

if ($env:CI) {
    ClearCargoTarget "../../target/spiral/spiral"
}
