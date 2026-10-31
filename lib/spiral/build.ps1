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

$livebook = Join-Path $ResolvedScriptDir "../../apps/cells/spi/run_notebook.ps1"
$notebooks = @(
    "physics", "parsing", "sm'", "rust/rust", "rust/testing", "rust/near", "rust/near_workspaces", "testing", "guid",
    "async", "trace", "am'", "crypto", "common", "resultm", "console", "base", "convert", "date_time", "math",
    "mapm", "optionm'", "listm'", "reflection", "iter", "wasm", "leptos/leptos", "lustre", "util", "platform", "stream",
    "threading", "benchmark", "seq", "env", "file_system", "networking", "rust/clap"
)
function Get-NotebookArgs([string] $Notebook) {
    @("--path", (Join-Path $ResolvedScriptDir "$Notebook.spi"), "--livemd")
}

if (!$fast) {
    $jobs = $notebooks | ForEach-Object { [pscustomobject]@{ Notebook = $_; Arguments = (Get-NotebookArgs $_) } }
    $runs = $jobs | ForEach-Object -ThrottleLimit ($sequential ? 1 : 4) -Parallel {
        $notebook = $_.Notebook
        $arguments = $_.Arguments
        $output = Join-Path $using:ResolvedScriptDir "$notebook.spi.ipynb"
        $log = @()
        $exitCode = 1
        $started = Get-Date
        foreach ($attempt in 1..3) {
            Write-Host "spiral/lib/spiral/build.ps1 / $notebook / start / attempt $attempt / $(Get-Date -Format 'HH:mm:ss')"
            $log = pwsh -NoProfile -File $using:livebook @arguments --output-path $output 2>&1 | ForEach-Object { "$_" }
            $exitCode = $LASTEXITCODE
            if ($exitCode -eq 0) { break }
        }
        $tests = @($log | Where-Object { $_ -like 'spiral-tests file *' } | ForEach-Object { $_.Substring('spiral-tests file '.Length) | ConvertFrom-Json })
        $counts = ($tests | Measure-Object -Property passed, failed, skipped -Sum | ForEach-Object { "$($_.Property) $([int]$_.Sum)" }) -join ' / '
        $availableMb = if ($IsLinux) { [int](((Get-Content /proc/meminfo | Where-Object { $_ -like 'MemAvailable:*' }) -split '\s+')[1] / 1024) } else { [int]((Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory / 1024) }
        Write-Host "spiral/lib/spiral/build.ps1 / $notebook / done / exit $exitCode / attempts $attempt / $([int]((Get-Date) - $started).TotalSeconds) s / $counts / available $availableMb MB"
        [pscustomobject]@{ Notebook = $notebook; ExitCode = $exitCode; Log = $log; Tests = $tests }
    }
    $runs | Sort-Object Notebook | ForEach-Object { Write-Output "spiral/lib/spiral/build.ps1 / $($_.Notebook) / exit $($_.ExitCode)" }
    $all = @($runs | ForEach-Object { $_.Tests })
    Write-Output ("spiral/lib/spiral/build.ps1 / tests / files $($all.Count) / " + (($all | Measure-Object -Property passed, failed, skipped, unsupported -Sum | ForEach-Object { "$($_.Property) $([int]$_.Sum)" }) -join ' / '))
    $all | Where-Object { $_.failed -gt 0 } | ForEach-Object { Write-Output "spiral/lib/spiral/build.ps1 / failed tests / $($_.file) / $($_.failed_tests -join ', ')" }
    $failed = @($runs | Where-Object ExitCode -ne 0)
    foreach ($run in $failed) {
        $run.Log | Select-String -Pattern "panicked at|^\*\* \(|error(\[E\d+\])?:|Exception" -Context 0, 1 | Select-Object -First 10 | ForEach-Object { @($_.Line) + @($_.Context.PostContext) } | ForEach-Object { Write-Output "spiral/lib/spiral/build.ps1 / $($run.Notebook) / cause / $_" }
        $run.Log | Select-Object -Last 30 | ForEach-Object { Write-Output "spiral/lib/spiral/build.ps1 / $($run.Notebook) / $_" }
    }
    if ($failed) { throw "spiral/lib/spiral/build.ps1 / notebooks failed: $(($failed | ForEach-Object Notebook) -join ', ')" }
}

if (!$fast) {
    { pwsh near/wallet/build.ps1 } | Invoke-Block
}

if ($env:CI) {
    ClearCargoTarget "../../target/spiral/spiral"
}
