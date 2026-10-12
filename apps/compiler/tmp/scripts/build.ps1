param(
    [ValidateSet('single-flight', 'sf', 'hopac', 'hp', 'both')][string]$Mode = 'single-flight',
    [ValidateSet('Release', 'Debug')][string]$Configuration = 'Release',
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
        if ($null -eq $cor) { return $true }
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
        $stamp = "$($dll.Length)-$($dll.LastWriteTimeUtc.Ticks)"
        $skip = "$($dll.FullName).r2r-skip"
        if ((Test-Path $skip) -and (Get-Content $skip -Raw).Trim() -eq $stamp) { continue }
        $tmp = "$($dll.FullName).r2r"
        $refs = Get-ChildItem $OutDir -Filter *.dll -File | Where-Object FullName -ne $dll.FullName | ForEach-Object { '-r', $_.FullName }
        $log = & $cg.Tool $dll.FullName -o $tmp -r (Join-Path $cg.Framework '*.dll') @refs --targetos $os --targetarch $arch -O 2>&1
        $why = ($log | Select-Object -First 1) -replace '\s+', ' '
        if ($LASTEXITCODE -eq 0 -and (Test-Path $tmp)) {
            try { [IO.File]::Move($tmp, $dll.FullName, $true); $done++; continue } catch { $why = $_.Exception.Message }
        }
        if (Test-Path $tmp) { [IO.File]::Delete($tmp) }
        if ($LASTEXITCODE -ne 0) { Set-Content $skip $stamp }
        Write-Host "== ReadyToRun: $($dll.Name) stays IL ($why)" -ForegroundColor Yellow
    }
    Write-Host "== ReadyToRun: $done dll(s) precompiled in $([math]::Round($sw.Elapsed.TotalSeconds, 1)) s"
}

function Unlock-SpiralOutputs([string]$OutDir) {
    if (-not (Test-Path $OutDir)) { return }
    Get-ChildItem $OutDir -Filter '*.dll.r2r-old-*' -File | ForEach-Object { try { $_.Delete() } catch { } }
    $stamp = Get-Date -Format 'HHmmssfff'
    foreach ($dll in Get-ChildItem $OutDir -Filter *.dll -File) {
        $aside = "$($dll.FullName).r2r-old-$stamp"
        try { [IO.File]::Move($dll.FullName, $aside); [IO.File]::Copy($aside, $dll.FullName) } catch { }
    }
}

$failed = $false
foreach ($m in $modes) {
    $core = if ($CoreSource) { (Resolve-Path $CoreSource).Path } else { Get-SpiralCoreSource $m }
    $staged = Join-Path $cache "core-src/$m/spiral_compiler.fs"
    New-Item -ItemType Directory -Force (Split-Path $staged) | Out-Null
    if (-not (Test-Path $staged) -or (Get-FileSha256 $staged) -ne (Get-FileSha256 $core)) {
        Copy-Item -LiteralPath $core -Destination $staged -Force
        (Get-Item -LiteralPath $staged).LastWriteTime = Get-Date
    }
    $args = @('build', $project, '-c', $Configuration, "-p:SpiralCore=$m", "-p:SpiralCacheDir=$cache", "-p:SpiralCoreSource=$staged", '-nologo', '-v:m')
    Write-Host "== building $m ($Configuration) from $core"
    $sw = [Diagnostics.Stopwatch]::StartNew()
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
exit 0
