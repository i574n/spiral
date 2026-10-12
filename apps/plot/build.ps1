param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../scripts/core.ps1
. ../../lib/spiral/lib.ps1

{ cargo +nightly-2025-11-01 build --release --package plot } | Invoke-Block -Location ../../workspace
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
