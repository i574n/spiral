param([Parameter(Mandatory)][string] $Main, [string] $Target = 'c', [switch] $InsideHeavySlot)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot
$spiral = if ($env:SPIRAL_ROOT) { $env:SPIRAL_ROOT } else { Join-Path (Split-Path $root) 'spiral' }
$cells = Join-Path $spiral 'apps/cells'
if (-not (Test-Path (Join-Path $cells 'mix.exs'))) { throw "probe.ps1 / no Cells at ${cells}: clone spiral beside this project or set SPIRAL_ROOT" }
if (-not $env:SPIRAL_LIB) { $env:SPIRAL_LIB = Join-Path $spiral 'lib/spiral' }
$program = (Resolve-Path $Main).Path
$targets = @($Target -split ',' | ForEach-Object { $_.Trim() } | Where-Object { $_ })
$arguments = @('spiral.notebook', '--gate', '--probe', $program) + @($targets | ForEach-Object { '--target', $_ })
$heavyGate = Join-Path $spiral 'apps/compiler/scripts/heavy.ps1'
$runProbe = {
    Push-Location $cells
    try { mix @arguments } finally { Pop-Location }
    if ($LASTEXITCODE -ne 0) { throw "probe.ps1 / mix spiral.notebook --probe exit $LASTEXITCODE" }
}
if ((Test-Path -LiteralPath $heavyGate) -and -not $InsideHeavySlot) {
    . $heavyGate
    Invoke-Heavy -Label "cells probe $(Split-Path $program -Leaf)" $runProbe
} else {
    & $runProbe
}