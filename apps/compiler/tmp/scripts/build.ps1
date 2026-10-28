param(
    [ValidateSet('single-flight', 'sf', 'gpt5parallel', 'gp', 'hopacsota', 'hs', 'both')][string]$Mode = 'single-flight',
    [ValidateSet('Release', 'Debug')][string]$Configuration = 'Release',
    [string]$CoreSource
)
. $PSScriptRoot/env.ps1

if (-not $CoreSource) {
    pwsh -NoProfile -File (Join-Path $PSScriptRoot 'pair-drift.ps1')
    if ($LASTEXITCODE -ne 0) { throw 'pair-drift: a SPIRAL_CORE_GPT5PARALLEL pair changed on one side only; change both sides or unify the pair' }
}
if ($Mode -in 'hopacsota', 'hs') {
    $lintArgs = if ($CoreSource) { @('-CoreSource', $CoreSource) } else { @() }
    pwsh -NoProfile -File (Join-Path $PSScriptRoot 'hopacsota-lint.ps1') @lintArgs
    if ($LASTEXITCODE -ne 0) { throw 'hopacsota-lint: gate G1 (size) or G2 (banned constructs) failed' }
}

$dotnet = Resolve-SpiralDotnet
$cache = Get-SpiralCacheDir
$sharedCache = if ($IsWindows) { Join-Path $env:LOCALAPPDATA 'spiral-bin' } else { Join-Path $HOME '.cache/spiral-bin' }
$detRoot = Get-SpiralDetRoot
$project = Join-Path $BundleRoot 'compiler/host/SpiralCompiler.fsproj'
$modes = if ($Mode -eq 'both') { 'single-flight', 'gpt5parallel' } else { ConvertTo-SpiralMode $Mode }
$receipts = Join-Path $cache 'results/builds.tsv'
New-Item -ItemType Directory -Force (Split-Path $receipts) | Out-Null
if (-not (Test-Path $receipts)) { "timestamp`tmode`tconfiguration`tseconds`texit`tcore_sha256`tcore" | Set-Content $receipts }
$script:SpiralBuildRuntime = $null

function Get-SpiralBuildDirectory([string]$Dotnet) {
    $systemDotnet = if ($IsWindows) { Join-Path $env:ProgramFiles 'dotnet/dotnet.exe' } else { '/usr/share/dotnet/dotnet' }
    $systemRuntimes = if (Test-Path $systemDotnet) { @(& $systemDotnet --list-runtimes | Select-String '^Microsoft\.NETCore\.App (\S+)' | ForEach-Object { $_.Matches[0].Groups[1].Value }) } else { @() }
    $sdks = foreach ($sdk in Get-ChildItem (Join-Path (Split-Path $Dotnet) 'sdk') -Directory -ErrorAction SilentlyContinue) {
        $bundled = Join-Path $sdk.FullName 'Microsoft.NETCoreSdk.BundledVersions.props'
        if (-not (Test-Path $bundled)) { continue }
        $runtime = ([regex]::Match([IO.File]::ReadAllText($bundled), '<BundledNETCoreAppPackageVersion>([^<]+)<')).Groups[1].Value
        $semantic = $null
        if ([Management.Automation.SemanticVersion]::TryParse($sdk.Name, [ref]$semantic)) { [pscustomobject]@{ Sdk = $sdk.Name; Runtime = $runtime; Order = $semantic } }
    }
    $chosen = @($sdks | Sort-Object Order -Descending | Where-Object { -not $systemRuntimes.Count -or $systemRuntimes -contains $_.Runtime }) | Select-Object -First 1
    if (-not $chosen) { return $null }
    $directory = Join-Path $cache "build-cwd/$($chosen.Sdk)"
    New-Item -ItemType Directory -Force $directory | Out-Null
    [IO.File]::WriteAllText((Join-Path $directory 'global.json'), "{`n  `"sdk`": { `"version`": `"$($chosen.Sdk)`", `"rollForward`": `"disable`" }`n}`n")
    Write-Host "== SDK $($chosen.Sdk) (runtime $($chosen.Runtime), the newest one the system dotnet can run)"
    $script:SpiralBuildRuntime = $chosen.Runtime
    $directory
}
function Get-SpiralCrossgen2([string]$Dotnet) {
    $rid = [System.Runtime.InteropServices.RuntimeInformation]::RuntimeIdentifier -replace '^win\d*-', 'win-' -replace '^(ubuntu|debian|fedora|rhel|alpine)[^-]*-', 'linux-'
    $runtimes = @(& $Dotnet --list-runtimes | Select-String '^Microsoft\.NETCore\.App (\S+) \[(.+)\]' | ForEach-Object { $_.Matches[0] })
    $runtime = $runtimes | Where-Object { $script:SpiralBuildRuntime -and $_.Groups[1].Value -eq $script:SpiralBuildRuntime } | Select-Object -First 1
    if (-not $runtime) { $runtime = $runtimes | Sort-Object { [version]($_.Groups[1].Value -replace '-.*$', '') } | Select-Object -Last 1 }
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
function Get-ReadyToRunKey([string]$Path, [string]$Runtime, [string]$Target, [hashtable]$Hashes) {
    $fs = [IO.File]::OpenRead($Path)
    try {
        $metadata = [System.Reflection.Metadata.PEReaderExtensions]::GetMetadataReader([System.Reflection.PortableExecutable.PEReader]::new($fs))
        $references = foreach ($handle in $metadata.AssemblyReferences) { $metadata.GetString($metadata.GetAssemblyReference($handle).Name) }
    }
    finally { $fs.Dispose() }
    $parts = @($Hashes[[IO.Path]::GetFileName($Path)], $Runtime, $Target) + @($references | Sort-Object -Unique | ForEach-Object { $name = "$_.dll"; if ($Hashes.ContainsKey($name)) { "$name=$($Hashes[$name])" } })
    [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($parts -join "`n"))).Substring(0, 32)
}
function Invoke-SpiralReadyToRun([string]$Dotnet, [string]$OutDir) {
    $cg = Get-SpiralCrossgen2 $Dotnet
    if (-not $cg -or -not (Test-Path $cg.Framework)) { Write-Host '== ReadyToRun skipped: no crossgen2 for this runtime (JIT only)' -ForegroundColor Yellow; return }
    $os, $arch = ($cg.Rid -split '-')[0], ($cg.Rid -split '-')[-1]
    $os = @{ win = 'windows'; linux = 'linux'; osx = 'osx' }[$os]
    $sw = [Diagnostics.Stopwatch]::StartNew()
    $done = 0
    $reused = 0
    $ilHashes = @{}
    foreach ($file in Get-ChildItem $OutDir -Filter *.dll -File) { $ilHashes[$file.Name] = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([IO.File]::ReadAllBytes($file.FullName))) }
    $imageCache = Join-Path $sharedCache 'r2r-cache'
    New-Item -ItemType Directory -Force $imageCache | Out-Null
    foreach ($dll in Get-ChildItem $OutDir -Filter *.dll -File) {
        if (Test-ReadyToRunImage $dll.FullName) { continue }
        $stamp = "$($dll.Length)-$($dll.LastWriteTimeUtc.Ticks)"
        $skip = "$($dll.FullName).r2r-skip"
        if ((Test-Path $skip) -and (Get-Content $skip -Raw).Trim() -eq $stamp) { continue }
        $tmp = "$($dll.FullName).r2r"
        $cached = Join-Path $imageCache "$(Get-ReadyToRunKey $dll.FullName $cg.Framework "$os-$arch" $ilHashes).dll"
        $failureMarker = "$cached.failed"
        if (Test-Path $cached) {
            Copy-Item -LiteralPath $cached $tmp -Force
            (Get-Item -LiteralPath $cached).LastWriteTime = Get-Date
            $exit = 0
            $why = 'reused'
            $reused++
        }
        elseif (Test-Path $failureMarker) {
            (Get-Item -LiteralPath $failureMarker).LastWriteTime = Get-Date
            $exit = 1
            $why = "crossgen2 failed on this exact image before: $(Get-Content -LiteralPath $failureMarker -TotalCount 1)"
        }
        else {
            $refs = Get-ChildItem $OutDir -Filter *.dll -File | Where-Object FullName -ne $dll.FullName | ForEach-Object { '-r', $_.FullName }
            $log = & $cg.Tool $dll.FullName -o $tmp -r (Join-Path $cg.Framework '*.dll') @refs --targetos $os --targetarch $arch -O 2>&1
            $exit = $LASTEXITCODE
            $why = ($log | Select-Object -First 1) -replace '\s+', ' '
            if ($exit -eq 0 -and (Test-Path $tmp)) { Copy-Item -LiteralPath $tmp $cached -Force }
            elseif ($exit -ne 0) { Set-Content -LiteralPath $failureMarker $why.Substring(0, [Math]::Min(300, $why.Length)) }
        }
        if ($exit -eq 0 -and (Test-Path $tmp)) {
            try { [IO.File]::Move($tmp, $dll.FullName, $true); $done++; continue }
            catch {
                $why = $_.Exception.Message
                $aside = "$($dll.FullName).r2r-old-$(Get-Date -Format 'HHmmssfff')"
                try { [IO.File]::Move($dll.FullName, $aside) } catch { $aside = $null }
                if ($aside) {
                    try { [IO.File]::Move($tmp, $dll.FullName); $done++; continue }
                    catch { $why = $_.Exception.Message; [IO.File]::Move($aside, $dll.FullName) }
                }
            }
        }
        if (Test-Path $tmp) { [IO.File]::Delete($tmp) }
        if ($exit -ne 0) { Set-Content $skip $stamp }
        Write-Host "== ReadyToRun: $($dll.Name) stays IL ($why)" -ForegroundColor Yellow
    }
    $unusedBefore = (Get-Date).AddDays(-30)
    Get-ChildItem $imageCache -File | Where-Object LastWriteTime -lt $unusedBefore | ForEach-Object { try { $_.Delete() } catch { } }
    Write-Host "== ReadyToRun: $done dll(s) precompiled in $([math]::Round($sw.Elapsed.TotalSeconds, 1)) s ($reused from the shared image cache)"
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
    $coreSha = Get-FileSha256 $core
    $staged = Join-Path $detRoot "core-src/$m/$($coreSha.Substring(0, 16))/spiral_compiler.fs"
    New-Item -ItemType Directory -Force (Split-Path $staged) | Out-Null
    if (-not (Test-Path $staged) -or (Get-FileSha256 $staged) -ne $coreSha) { Copy-Item -LiteralPath $core -Destination $staged -Force }
    (Get-Item -LiteralPath (Split-Path $staged)).LastWriteTime = Get-Date
    $lastStaged = Join-Path $cache "obj/$m/last-staged-core.txt"
    New-Item -ItemType Directory -Force (Split-Path $lastStaged) | Out-Null
    if (-not (Test-Path $lastStaged) -or (Get-Content -LiteralPath $lastStaged -Raw).Trim() -ne $staged) {
        (Get-Item -LiteralPath $staged).LastWriteTime = Get-Date
        [IO.File]::WriteAllText($lastStaged, $staged)
    }
    Get-ChildItem (Join-Path $detRoot "core-src/$m") -Directory -ErrorAction SilentlyContinue | Sort-Object LastWriteTime -Descending | Select-Object -Skip 8 |
        ForEach-Object { try { [IO.Directory]::Delete($_.FullName, $true) } catch { } }
    $args = @('build', $project, '-c', $Configuration, "-p:SpiralCore=$m", "-p:SpiralCacheDir=$cache", "-p:SpiralCoreSource=$staged", "-p:PathMap=$cache=/_/%2c$BundleRoot=/_b/", '-nologo', '-v:m')
    Write-Host "== building $m ($Configuration) from $core"
    $sw = [Diagnostics.Stopwatch]::StartNew()
    $gcSaved = $env:DOTNET_gcServer, $env:DOTNET_GCConserveMemory, $env:MSBUILDDISABLENODEREUSE
    $env:DOTNET_gcServer = '0'; $env:DOTNET_GCConserveMemory = '9'; $env:MSBUILDDISABLENODEREUSE = '1'
    if ($Configuration -eq 'Release') { Unlock-SpiralOutputs (Join-Path $cache "bin/$m/SpiralCompiler/$Configuration/net11.0") }
    $buildDirectory = Get-SpiralBuildDirectory $dotnet
    Push-Location $(if ($buildDirectory) { $buildDirectory } else { Join-Path $BundleRoot 'compiler' })
    try {
        & $dotnet @args | Tee-Object -Variable buildOutput
        $exit = $LASTEXITCODE
        $retry = 0
        while ($exit -ne 0 -and $Configuration -eq 'Release' -and $retry -lt 3 -and ($buildOutput -match 'MSB3021|MSB3027') -and -not ($buildOutput -match 'error FS\d')) {
            $retry++
            Write-Host "== outputs locked by running compilers: unlock and recopy, attempt $retry" -ForegroundColor Yellow
            Unlock-SpiralOutputs (Join-Path $cache "bin/$m/SpiralCompiler/$Configuration/net11.0")
            & $dotnet @args | Tee-Object -Variable buildOutput
            $exit = $LASTEXITCODE
        }
    }
    finally { $env:DOTNET_gcServer, $env:DOTNET_GCConserveMemory, $env:MSBUILDDISABLENODEREUSE = $gcSaved; Pop-Location }
    if ($exit -eq 0 -and $Configuration -eq 'Release') { Invoke-SpiralReadyToRun $dotnet (Join-Path $cache "bin/$m/SpiralCompiler/$Configuration/net11.0") }
    $seconds = [math]::Round($sw.Elapsed.TotalSeconds, 1)
    "$(Get-Date -Format s)`t$m`t$Configuration`t$seconds`t$exit`t$(Get-FileSha256 $core)`t$core" | Add-Content $receipts
    if ($exit -ne 0) { $failed = $true; Write-Host "== $m build FAILED after $seconds s" -ForegroundColor Red }
    else { Write-Host "== $m built in $seconds s -> $(Get-SpiralCompilerDll $m $Configuration)" -ForegroundColor Green }
}
if ($failed) { exit 1 }
exit 0
