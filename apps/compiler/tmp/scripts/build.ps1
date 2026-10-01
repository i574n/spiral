<#
.SYNOPSIS
Builds the Spiral compiler in one or both modes.

.EXAMPLE
pwsh scripts/build.ps1                                  # single-flight, Release
pwsh scripts/build.ps1 -Mode hopac -Configuration Debug   # not faster to build (median 382 s vs Release 239 s, results/builds.tsv)
pwsh scripts/build.ps1 -Mode hopac -CoreSource ../../spiral_compiler.fs   # build a core that lives elsewhere
#>
param(
    [ValidateSet('single-flight', 'sf', 'hopac', 'hp', 'both')][string]$Mode = 'single-flight',
    [ValidateSet('Release', 'Debug')][string]$Configuration = 'Release',
    # Build a different core file than compiler/cores/<mode>/spiral_compiler.fs (e.g. the repo's working copy).
    [string]$CoreSource
)
. $PSScriptRoot/env.ps1

$dotnet = Resolve-SpiralDotnet
$cache = Get-SpiralCacheDir
$project = Join-Path $BundleRoot 'compiler/host/SpiralCompiler.fsproj'
$modes = if ($Mode -eq 'both') { 'single-flight', 'hopac' } else { ConvertTo-SpiralMode $Mode }
$receipts = Join-Path $cache 'results/builds.tsv'
New-Item -ItemType Directory -Force (Split-Path $receipts) | Out-Null
if (-not (Test-Path $receipts)) { "timestamp`tmode`tconfiguration`tseconds`texit`tcore_sha256`tcore" | Set-Content $receipts }

$failed = $false
foreach ($m in $modes) {
    $core = if ($CoreSource) { (Resolve-Path $CoreSource).Path } else { Get-SpiralCoreSource $m }
    # Compile a staged copy: the Hopac core writes its <timestamp>.jsonl run logs next to its own source
    # (__SOURCE_DIRECTORY__), and those must land in the cache, not in the bundle or the repo. The copy is
    # only refreshed when the content changes, so unchanged cores keep their incremental build.
    $staged = Join-Path $cache "core-src/$m/spiral_compiler.fs"
    New-Item -ItemType Directory -Force (Split-Path $staged) | Out-Null
    # Copy-Item keeps the source's write time, and MSBuild compares times: an older core (a backup) would
    # look up to date, so the copy is stamped now.
    if (-not (Test-Path $staged) -or (Get-FileSha256 $staged) -ne (Get-FileSha256 $core)) {
        Copy-Item -LiteralPath $core -Destination $staged -Force
        (Get-Item -LiteralPath $staged).LastWriteTime = Get-Date
    }
    $args = @('build', $project, '-c', $Configuration, "-p:SpiralCore=$m", "-p:SpiralCacheDir=$cache", "-p:SpiralCoreSource=$staged", '-nologo', '-v:m')
    Write-Host "== building $m ($Configuration) from $core"
    $sw = [Diagnostics.Stopwatch]::StartNew()
    # The F# compile of the core takes several GB: workstation GC with memory conservation keeps it from being
    # reaped on a loaded machine. Set here for the build only, restored after: a compiler run that inherits
    # them is 2-4x slower (and, with hopac's timing-dependent replay, can even emit different code).
    $gcSaved = $env:DOTNET_gcServer, $env:DOTNET_GCConserveMemory, $env:MSBUILDDISABLENODEREUSE
    $env:DOTNET_gcServer = '0'; $env:DOTNET_GCConserveMemory = '9'; $env:MSBUILDDISABLENODEREUSE = '1'
    try { & $dotnet @args }
    finally { $env:DOTNET_gcServer, $env:DOTNET_GCConserveMemory, $env:MSBUILDDISABLENODEREUSE = $gcSaved }
    $exit = $LASTEXITCODE
    $seconds = [math]::Round($sw.Elapsed.TotalSeconds, 1)
    "$(Get-Date -Format s)`t$m`t$Configuration`t$seconds`t$exit`t$(Get-FileSha256 $core)`t$core" | Add-Content $receipts
    if ($exit -ne 0) { $failed = $true; Write-Host "== $m build FAILED after $seconds s" -ForegroundColor Red }
    else { Write-Host "== $m built in $seconds s -> $(Get-SpiralCompilerDll $m $Configuration)" -ForegroundColor Green }
}
if ($failed) { exit 1 }
