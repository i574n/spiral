param([string]$Mode = 'single-flight', [string]$Label = 'same-sdk')
$ErrorActionPreference = 'Stop'
. $PSScriptRoot/env.ps1
$mode = ConvertTo-SpiralMode $Mode
$dir = Split-Path (Get-SpiralCompilerDll $mode 'Release')
if (-not (Test-Path $dir)) { throw "no build at $dir" }
function Get-Prints { Get-ChildItem $dir -Filter 'SpiralCompiler*.dll' | Sort-Object Name | ForEach-Object { [pscustomobject]@{ name = $_.Name; sha = (Get-FileHash $_.FullName -Algorithm SHA256).Hash.Substring(0, 16); bytes = $_.Length } } }
$before = @(Get-Prints)
$now = Get-Date
foreach ($staged in Get-ChildItem (Join-Path (Get-SpiralCacheDir) "core-src/$mode") -Recurse -Filter spiral_compiler.fs -ErrorAction Ignore) { $staged.LastWriteTime = $now }
$log = Join-Path (Get-SpiralCacheDir) "runs/rebuild-determinism-$mode-$Label.log"
New-Item -ItemType Directory -Force (Split-Path $log) | Out-Null
$watch = [Diagnostics.Stopwatch]::StartNew()
pwsh -NoProfile -File (Join-Path $PSScriptRoot 'build.ps1') -Mode $mode *> $log
$code = $LASTEXITCODE
$after = @(Get-Prints)
"rebuild $mode ($Label): exit $code in $([int]$watch.Elapsed.TotalSeconds) s; sdk $(& (Resolve-SpiralDotnet) --version); log $log"
foreach ($b in $before) {
    $a = $after | Where-Object name -eq $b.name
    '{0,-28} {1} -> {2} {3}' -f $b.name, $b.sha, $a.sha, $(if ($a.sha -eq $b.sha) { 'same' } else { "DIFFERS ($($b.bytes) -> $($a.bytes) bytes)" })
}
$global:LASTEXITCODE = $code
