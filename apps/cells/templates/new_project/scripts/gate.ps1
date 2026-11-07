param([string[]] $Path = @(), [switch] $InsideHeavySlot)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot
$spiral = if ($env:SPIRAL_ROOT) { $env:SPIRAL_ROOT } else { Join-Path (Split-Path $root) 'spiral' }
$cells = Join-Path $spiral 'apps/cells'
if (-not (Test-Path (Join-Path $cells 'mix.exs'))) { throw "gate.ps1 / no Cells at ${cells}: clone spiral beside this project or set SPIRAL_ROOT" }
if (-not $env:SPIRAL_LIB) { $env:SPIRAL_LIB = Join-Path $spiral 'lib/spiral' }
$files = if ($Path) { $Path | ForEach-Object { $_ -split ',' } | Where-Object { $_.Trim() } | ForEach-Object { (Resolve-Path $_.Trim()).Path } } else { Get-ChildItem (Join-Path $root 'src') -Filter *.spi | ForEach-Object FullName }
$arguments = @('spiral.notebook', '--gate') + @($files | ForEach-Object { '--path', $_ })
$heavyGate = Join-Path $spiral 'apps/compiler/scripts/heavy.ps1'
$runGate = {
    Push-Location $cells
    try { mix @arguments } finally { Pop-Location }
    if ($LASTEXITCODE -ne 0) { throw "gate.ps1 / mix spiral.notebook --gate exit $LASTEXITCODE" }
}
if ((Test-Path -LiteralPath $heavyGate) -and -not $InsideHeavySlot) {
    . $heavyGate
    Invoke-Heavy -Label "cells gate $(Split-Path $root -Leaf)" $runGate
} else {
    & $runGate
}
