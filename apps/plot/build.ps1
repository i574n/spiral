param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../scripts/core.ps1
. ../../lib/spiral/lib.ps1

{ cargo build --release --package plot } | Invoke-Block -Location ../../workspace
$cargoTarget = (cargo metadata --format-version 1 --no-deps --manifest-path ../../workspace/Cargo.toml | ConvertFrom-Json).target_directory
$plotExe = "$cargoTarget/release/plot$(_exe)"

$checkDir = GetTargetDir "plot"
New-Item -ItemType Directory -Force $checkDir | Out-Null
$checkJson = Join-Path $checkDir "check.json"
$checkSvg = Join-Path $checkDir "check.svg"
Remove-Item $checkSvg -Force -ErrorAction Ignore
[IO.File]::WriteAllText($checkJson, '["square","x","y",[["square",[-1.0,0.0,1.0],[1.0,0.0,1.0]],["line",[-1.0,1.0],[0.5,0.5]]]]')
{ & $plotExe $checkJson $checkSvg } | Invoke-Block
$svg = [IO.File]::ReadAllText($checkSvg)
if (!$svg.StartsWith("<svg") -or !$svg.Contains("square") -or !$svg.Contains("line")) {
    throw "RUST-FAILED apps/plot / run check: $checkSvg is not the expected svg"
}
Write-Output "RUST-OK apps/plot / $plotExe"

$livebook = Join-Path ($env:SPIRAL_CELLS_ROOT ? $env:SPIRAL_CELLS_ROOT : (Join-Path $ScriptDir "../cells")) "spi/run_notebook.ps1"
$notebook = Join-Path $ScriptDir "physics.spi"
$log = @(pwsh -NoProfile -File $livebook --path $notebook --livemd --output-path "$notebook.ipynb" 2>&1 | ForEach-Object { "$_" })
$notebookExit = $LASTEXITCODE
$log | Where-Object { $_ -like 'spiral-tests *' } | ForEach-Object { Write-Output "apps/plot / physics / $_" }
if ($notebookExit -ne 0) { $log | Select-Object -Last 30 | ForEach-Object { Write-Output "apps/plot / physics / $_" }; throw "apps/plot / physics.spi notebook exited $notebookExit" }
$svgs = ([regex]::Matches([IO.File]::ReadAllText("$notebook.ipynb"), '<svg')).Count
if ($svgs -eq 0) { throw "apps/plot / physics.spi.ipynb rendered no svg although $plotExe exists" }
Write-Output "apps/plot / physics / $svgs svg in physics.spi.ipynb"
