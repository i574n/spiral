param([Parameter(Mandatory)][string]$Against, [string]$Label = 'g3', [switch]$SkipBuild)
$ErrorActionPreference = 'Continue'
. $PSScriptRoot/env.ps1
$runs = Join-Path (Get-SpiralCacheDir) "runs/hopacsota-g3-$Label"
New-Item -ItemType Directory -Force $runs | Out-Null
Remove-Item Env:SPIRAL_BIN_CACHE_DIR, Env:SPIRAL_COMPILER_DLL, Env:SPIRAL_HOPACSOTA_POLICY -ErrorAction Ignore
if (-not $SkipBuild) {
    pwsh -NoProfile -File (Join-Path $PSScriptRoot 'build.ps1') -Mode single-flight -Configuration Debug *> (Join-Path $runs 'build-single-flight-debug.log')
    "build single-flight Debug exit $LASTEXITCODE"
    foreach ($mode in 'single-flight', 'hopacsota', 'gpt5parallel') {
        $watch = [Diagnostics.Stopwatch]::StartNew()
        pwsh -NoProfile -File (Join-Path $PSScriptRoot 'build.ps1') -Mode $mode *> (Join-Path $runs "build-$mode.log")
        "build $mode exit $LASTEXITCODE in $([int]$watch.Elapsed.TotalSeconds) s"
    }
}
$env:DOTNET_gcServer = '0'; $env:SPIRAL_NATIVE_PARALLEL = '4'
foreach ($case in @(@('single-flight', ''), @('hopacsota', ''), @('hopacsota', 'random:23'))) {
    $mode, $policy = $case
    if ($policy) { $env:SPIRAL_HOPACSOTA_POLICY = $policy } else { Remove-Item Env:SPIRAL_HOPACSOTA_POLICY -ErrorAction Ignore }
    $name = if ($policy) { "$mode-$($policy -replace ':', '')" } else { $mode }
    $log = Join-Path $runs "review-$name.log"
    pwsh -NoProfile -Command "& '$(Join-Path $PSScriptRoot 'test.ps1')' -Mode $mode -Suite all -Native -Parallel 2 -ReuseNative" *> $log
    $run = (Get-Content $log | Select-String 'run dir (\S+)').Matches[0].Groups[1].Value
    "== $name ($run)"
    Get-Content $log | Select-String '== compiled|native:' | ForEach-Object Line
    pwsh -NoProfile -File (Join-Path $PSScriptRoot 'compare-runs.ps1') -Left $Against -Right $run -Show 6
}
Remove-Item Env:SPIRAL_HOPACSOTA_POLICY -ErrorAction Ignore
