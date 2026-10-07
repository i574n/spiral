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

# ReadyToRun: every compile in hopac mode is a fresh process (and the first one in a single-flight batch), which spent
# seconds JIT-compiling the compiler: precompiled code takes frontier_hello from ~6.0 to ~3.2 s and a lib/spiral
# fixture from ~12 to ~9.6 s (2026-10-05). After a Release build, crossgen2 (the runtime's own, from the NuGet cache,
# restored on first use) compiles each managed dll of the output in place; a dll it can't compile stays IL, and an
# output that is already ReadyToRun is skipped, so an incremental build only redoes what MSBuild copied anew.
function Get-SpiralCrossgen2([string]$Dotnet) {
    $rid = [System.Runtime.InteropServices.RuntimeInformation]::RuntimeIdentifier -replace '^win\d*-', 'win-' -replace '^(ubuntu|debian|fedora|rhel|alpine)[^-]*-', 'linux-'
    $runtime = & $Dotnet --list-runtimes | Select-String '^Microsoft\.NETCore\.App (\S+) \[(.+)\]' | ForEach-Object { $_.Matches[0] } |
        Sort-Object { [version]($_.Groups[1].Value -replace '-.*$', '') } | Select-Object -Last 1
    if (-not $runtime) { return $null }
    $version = $runtime.Groups[1].Value
    $nuget = if ($env:NUGET_PACKAGES) { $env:NUGET_PACKAGES } else { Join-Path $HOME '.nuget/packages' }
    $tool = Join-Path $nuget "microsoft.netcore.app.crossgen2.$rid/$version/tools/crossgen2$(if ($IsWindows) { '.exe' } else { '' })"
    if (-not (Test-Path $tool)) {
        $proj = Join-Path $cache 'crossgen2-restore/restore.csproj'
        New-Item -ItemType Directory -Force (Split-Path $proj) | Out-Null
        "<Project Sdk=`"Microsoft.NET.Sdk`"><PropertyGroup><TargetFramework>net11.0</TargetFramework><RuntimeIdentifier>$rid</RuntimeIdentifier><PublishReadyToRun>true</PublishReadyToRun><RuntimeFrameworkVersion>$version</RuntimeFrameworkVersion></PropertyGroup></Project>" | Set-Content $proj
        & $Dotnet restore $proj -nologo -v:q | Out-Null
    }
    if (Test-Path $tool) { @{ Tool = $tool; Framework = Join-Path $runtime.Groups[2].Value $version; Rid = $rid } } else { $null }
}
function Test-ReadyToRunImage([string]$Path) {
    $fs = [IO.File]::OpenRead($Path)
    try {
        $pe = [System.Reflection.PortableExecutable.PEReader]::new($fs)
        $cor = $pe.PEHeaders.CorHeader
        if ($null -eq $cor) { return $true } # native: nothing to do
        $cor.ManagedNativeHeaderDirectory.Size -gt 0
    } catch { $true } finally { $fs.Dispose() }
}
function Invoke-SpiralReadyToRun([string]$Dotnet, [string]$OutDir) {
    $cg = Get-SpiralCrossgen2 $Dotnet
    if (-not $cg -or -not (Test-Path $cg.Framework)) { Write-Host '== ReadyToRun skipped: no crossgen2 for this runtime (JIT only)' -ForegroundColor Yellow; return }
    $os, $arch = ($cg.Rid -split '-')[0], ($cg.Rid -split '-')[-1]
    $os = @{ win = 'windows'; linux = 'linux'; osx = 'osx' }[$os]
    $sw = [Diagnostics.Stopwatch]::StartNew()
    $done = 0
    foreach ($dll in Get-ChildItem $OutDir -Filter *.dll -File) {
        if (Test-ReadyToRunImage $dll.FullName) { continue }
        # crossgen2 rejects some dlls (Hopac.dll: a generic-cycle check throws); remember those per file version.
        $stamp = "$($dll.Length)-$($dll.LastWriteTimeUtc.Ticks)"
        $skip = "$($dll.FullName).r2r-skip"
        if ((Test-Path $skip) -and (Get-Content $skip -Raw).Trim() -eq $stamp) { continue }
        $tmp = "$($dll.FullName).r2r"
        # The output directory's other dlls as references, not a glob: on Linux crossgen2 rejects an input that a
        # reference glob matches again ("Multiple input files matching same simple name"), so nothing was precompiled.
        $refs = Get-ChildItem $OutDir -Filter *.dll -File | Where-Object FullName -ne $dll.FullName | ForEach-Object { '-r', $_.FullName }
        $log = & $cg.Tool $dll.FullName -o $tmp -r (Join-Path $cg.Framework '*.dll') @refs --targetos $os --targetarch $arch -O 2>&1
        $why = ($log | Select-Object -First 1) -replace '\s+', ' '
        if ($LASTEXITCODE -eq 0 -and (Test-Path $tmp)) {
            # A process that loaded the new IL dll meanwhile holds it: keep the IL then.
            try { [IO.File]::Move($tmp, $dll.FullName, $true); $done++; continue } catch { $why = $_.Exception.Message }
        }
        if (Test-Path $tmp) { [IO.File]::Delete($tmp) }
        if ($LASTEXITCODE -ne 0) { Set-Content $skip $stamp }
        Write-Host "== ReadyToRun: $($dll.Name) stays IL ($why)" -ForegroundColor Yellow
    }
    Write-Host "== ReadyToRun: $done dll(s) precompiled in $([math]::Round($sw.Elapsed.TotalSeconds, 1)) s"
}

# A ReadyToRun dll in the output differs from its IL source, so every build copies the dependency dlls again, and a
# running compiler (a Kino or notebook server on the shared build) holds them open: MSB3026, build failed. Rename each
# ReadyToRun dll aside and copy it back first (a loaded dll can be renamed, and the copy is not locked); the asides are
# deleted on a later build once nothing holds them.
function Unlock-SpiralOutputs([string]$OutDir) {
    if (-not (Test-Path $OutDir)) { return }
    Get-ChildItem $OutDir -Filter '*.dll.r2r-old-*' -File | ForEach-Object { try { $_.Delete() } catch { } }
    $stamp = Get-Date -Format 'HHmmssfff'
    # Every dll, not only ReadyToRun ones: an IL dll a running compiler has loaded (FParsecCS, FSharpx.Collections, Hopac)
    # is locked just the same, and MSBuild's copy over it failed the whole build (MSB3027, 2026-10-06).
    foreach ($dll in Get-ChildItem $OutDir -Filter *.dll -File) {
        $aside = "$($dll.FullName).r2r-old-$stamp"
        try { [IO.File]::Move($dll.FullName, $aside); [IO.File]::Copy($aside, $dll.FullName) } catch { }
    }
}

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
    if ($Configuration -eq 'Release') { Unlock-SpiralOutputs (Join-Path $cache "bin/$m/SpiralCompiler/$Configuration/net11.0") }
    try { & $dotnet @args }
    finally { $env:DOTNET_gcServer, $env:DOTNET_GCConserveMemory, $env:MSBUILDDISABLENODEREUSE = $gcSaved }
    $exit = $LASTEXITCODE
    if ($exit -eq 0 -and $Configuration -eq 'Release') { Invoke-SpiralReadyToRun $dotnet (Join-Path $cache "bin/$m/SpiralCompiler/$Configuration/net11.0") }
    $seconds = [math]::Round($sw.Elapsed.TotalSeconds, 1)
    "$(Get-Date -Format s)`t$m`t$Configuration`t$seconds`t$exit`t$(Get-FileSha256 $core)`t$core" | Add-Content $receipts
    if ($exit -ne 0) { $failed = $true; Write-Host "== $m build FAILED after $seconds s" -ForegroundColor Red }
    else { Write-Host "== $m built in $seconds s -> $(Get-SpiralCompilerDll $m $Configuration)" -ForegroundColor Green }
}
if ($failed) { exit 1 }
# Explicit: falling off the end exits with the last native command's code, a crossgen2 rejection (dll stays IL) in CI.
exit 0
