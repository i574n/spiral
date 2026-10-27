param(
    [string] $Match = '.',
    [string] $Out = (Join-Path ($env:SPIRAL_BIN_CACHE_DIR ?? (Join-Path $env:LOCALAPPDATA 'spiral-bin')) "runs/cells-gate-ci-$(Get-Date -Format 'yyyyMMdd-HHmmss')"),
    [int] $PathsPerRun = 20
)
$ErrorActionPreference = 'Stop'
$spiral = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
$Paths = @(git -C $spiral ls-files -- 'lib/spiral/*.spi' |
        ForEach-Object { Join-Path $spiral $_ } |
        Where-Object { (Split-Path $_ -Leaf) -match $Match -and (Select-String -LiteralPath $_ -Pattern '^test ' -Quiet) })
if (-not $Paths) { throw "no lib .spi with test blocks matches $Match" }
New-Item -ItemType Directory -Force $Out | Out-Null
$env:SPIRAL_CELLS_MEMO = '0'
$env:SPIRAL_LIB = Join-Path $spiral 'lib/spiral'
$summary = [Collections.Generic.List[string]]::new()
$summary.Add("file`tdiscovered`texecuted`tpassed`tfailed`tfailed_targets")
$watch = [Diagnostics.Stopwatch]::StartNew()
Push-Location (Join-Path $spiral 'apps/cells')
try {
    for ($at = 0; $at -lt $Paths.Count; $at += $PathsPerRun) {
        $chunk = @($Paths[$at..([Math]::Min($at + $PathsPerRun, $Paths.Count) - 1)])
        $notebookArgs = @('--gate', '--metrics', (Join-Path $Out "metrics-$at")) + ($chunk | ForEach-Object { '--path'; $_ })
        $lines = @(& pwsh -NoProfile -File (Join-Path $PSScriptRoot 'run_notebook.ps1') @notebookArgs 2>&1 | ForEach-Object { "$_" })
        $mixExit = $LASTEXITCODE
        [IO.File]::AppendAllLines((Join-Path $Out 'gate.log'), [string[]]$lines)
        if ($mixExit -ne 0 -and -not ($lines -match '^spiral-tests file ')) {
            "run_notebook.ps1 exited $mixExit with no test report for paths $at..$($at + $chunk.Count - 1); its last lines:"
            $lines | Select-Object -Last 30 | ForEach-Object { "  $_" }
        }
        foreach ($line in $lines) {
            if ($line -notmatch '^spiral-tests file (\{.*\})\s*$') { continue }
            $report = $Matches[1] | ConvertFrom-Json
            $failedTargets = ($report.failed_targets.PSObject.Properties | ForEach-Object { "$($_.Name)=$($_.Value -join '+')" }) -join ';'
            $summary.Add("$($report.file)`t$($report.discovered)`t$($report.executed)`t$($report.passed)`t$($report.failed)`t$failedTargets")
        }
    }
} finally {
    Pop-Location
    $env:SPIRAL_CELLS_MEMO = $null
    $env:SPIRAL_LIB = $null
}
[IO.File]::WriteAllText((Join-Path $Out 'cells-gate.tsv'), (($summary -join "`n") + "`n"))
$executed = 0
foreach ($row in $summary | Select-Object -Skip 1) { $executed += [int]($row -split "`t")[2] }
"cells gate: $($Paths.Count) files, $($summary.Count - 1) reports, $executed tests executed in $([int]$watch.Elapsed.TotalSeconds) s; artifact folder $Out (cells-gate.tsv, metrics-*/, gate.log)"
if ($executed -eq 0) { throw "cells gate is VOID: $($Paths.Count) lib files with test blocks, but no test executed (see the mix output above and gate.log)" }
