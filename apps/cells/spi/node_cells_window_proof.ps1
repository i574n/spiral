param(
    [Parameter(Mandatory)] [string] $Tree,
    [Parameter(Mandatory)] [string] $Stage,
    [string[]] $Applier = @(),
    [string[]] $LibFile = @(),
    [string[]] $Tests = @()
)
$ErrorActionPreference = 'Continue'
$Applier = @($Applier | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$LibFile = @($LibFile | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$Tests = @($Tests | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$cells = Join-Path $Tree 'apps\cells'
foreach ($a in $Applier) {
    pwsh -NoProfile -File (Join-Path $Stage $a) -Cells $cells -Apply | Select-Object -Last 1
    if ($LASTEXITCODE) { "APPLY FAILED: $a"; exit 2 }
}
foreach ($f in $LibFile) { Copy-Item (Join-Path $Stage $f) (Join-Path $Tree "lib\spiral\$f") -Force; "lib file staged: $f" }
$env:MIX_ENV = 'test'
$env:MIX_BUILD_PATH = Join-Path (Split-Path $Tree) 'mix-build-window-proof'
Push-Location $cells
try {
    $mix = Join-Path (Split-Path (Get-Command mix).Source -Parent) 'mix.bat'
    $t0 = Get-Date
    if ($Tests) { "=== mix test on $($Tests.Count) file(s): $($Tests -join ', ')" } else { '=== full mix test' }
    & $mix test @Tests 2>&1 | Select-String -Pattern '^\s+\d+\) test |Result:|Finished in' | ForEach-Object { $_.Line.Trim() }
    $full = $LASTEXITCODE
    "full exit=$full wall=$([int]((Get-Date) - $t0).TotalSeconds)s"
    if ($full) {
        foreach ($round in 1..2) {
            "=== rerun only the failed tests (round $round)"
            & $mix test --failed 2>&1 | Select-String -Pattern '^\s+\d+\) test |Result:' | ForEach-Object { $_.Line.Trim() }
            if (-not $LASTEXITCODE) { 'every failed test passed on its rerun alone: load reds'; break }
        }
    }
} finally { Pop-Location }
'NODE-CELLS-WINDOW-PROOF-DONE'
