param(
    [Parameter(Mandatory)] [string] $Name,
    [string[]] $CoreAppliers = @(),
    [string[]] $HostAppliers = @(),
    [string[]] $Programs = @(),
    [string[]] $Modes = @('single-flight'),
    [string] $Backup = (Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/compiler-installs'),
    [switch] $FromStore,
    [string] $FromUrls,
    [switch] $MintUrls,
    [ValidateSet('win-x64', 'linux-x64')] [string] $TargetRid = 'linux-x64',
    [string] $TargetSdk,
    [string] $UrlsOut,
    [string] $UrlsExpire = '2h',
    [string] $FromDir,
    [switch] $Put,
    [string] $Smoke = (Join-Path $PSScriptRoot '../../../lib/spiral/process.spi'),
    [switch] $Apply
)
$ErrorActionPreference = 'Stop'
$CoreAppliers = @($CoreAppliers | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$HostAppliers = @($HostAppliers | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$Programs = @($Programs | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$Modes = @($Modes | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
foreach ($scope in 'Machine', 'User') {
    $variables = [Environment]::GetEnvironmentVariables($scope)
    foreach ($key in $variables.Keys) {
        if ($key -in 'Path', 'PSModulePath', 'TEMP', 'TMP' -or $key -match '(?i)token|secret|password|api_key|_key_') { continue }
        if ($variables[$key] -and -not [Environment]::GetEnvironmentVariable($key, 'Process')) { [Environment]::SetEnvironmentVariable($key, $variables[$key], 'Process') }
    }
}
Remove-Item Env:SPIRAL_BIN_CACHE_DIR -ErrorAction Ignore
function Get-Short([string] $path) { (Get-FileHash -LiteralPath $path -Algorithm SHA256).Hash.Substring(0, 16) }
function Get-Sha([string] $path) { (Get-FileHash -LiteralPath $path -Algorithm SHA256).Hash.ToLowerInvariant() }
function Get-StoreKeys([string] $Core, [string] $HostSource, [string] $Projects, [string] $Sdk, [string] $Rid) {
    $depsHash = [Security.Cryptography.IncrementalHash]::CreateHash([Security.Cryptography.HashAlgorithmName]::SHA256)
    foreach ($p in Get-ChildItem -LiteralPath $Projects -Recurse -Filter '*.fsproj' | Sort-Object FullName) {
        $depsHash.AppendData([Text.Encoding]::UTF8.GetBytes($p.Name + "`n" + ([IO.File]::ReadAllText($p.FullName) -replace "`r`n", "`n") + "`n"))
    }
    $deps = ([BitConverter]::ToString($depsHash.GetHashAndReset()) -replace '-', '').ToLowerInvariant()
    [pscustomobject]@{
        Deps = $deps
        Base = "compiler/base/v1/deps-$deps/sdk-$Sdk/rid-$Rid"
        Pair = "compiler/pack/v1/core-$(Get-Sha $Core)/host-$(Get-Sha $HostSource)/sdk-$Sdk/rid-$Rid"
    }
}
$pairDlls = 'SpiralCompiler.dll', 'SpiralCompilerCore.dll'
function Test-ReadyToRunImage([string] $Path) {
    $fs = [IO.File]::OpenRead($Path)
    try {
        $pe = [System.Reflection.PortableExecutable.PEReader]::new($fs)
        $cor = $pe.PEHeaders.CorHeader
        if ($null -eq $cor) { return $true }
        $cor.ManagedNativeHeaderDirectory.Size -gt 0
    } catch { $true } finally { $fs.Dispose() }
}
function Get-BaseRows([string] $Dir) {
    $root = (Resolve-Path -LiteralPath $Dir).Path
    @(Get-ChildItem -LiteralPath $root -Recurse -File | Where-Object { $_.Name -notin $pairDlls } | ForEach-Object {
        [pscustomobject]@{ Name = $_.FullName.Substring($root.Length + 1) -replace '\\', '/'; Path = $_.FullName; Sha = Get-Sha $_.FullName } } | Sort-Object Name)
}
function Get-BaseKeyV2([object[]] $Rows, [string] $Rid) {
    $text = ($Rows | ForEach-Object { "$($_.Name)`t$($_.Sha)`n" }) -join ''
    $sha = ([BitConverter]::ToString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($text))) -replace '-', '').ToLowerInvariant()
    "compiler/base/v2/files-$sha/rid-$Rid"
}
function Get-OortPath([string] $Key) {
    if (-not $env:OORT_BUCKET) { throw 'OORT_BUCKET is not set; the store bucket lives in local config only' }
    "oort:$env:OORT_BUCKET/$Key"
}
function Use-OortKeys([scriptblock] $Body) {
    $secrets = @{}
    foreach ($line in Get-Content ($env:OORT_ENV_FILE ?? (Join-Path $HOME '.secrets/oort-s3.env'))) { if ($line -match '^\s*([A-Za-z_][A-Za-z0-9_]*)\s*=\s*"?([^"]*)"?\s*$') { $secrets[$Matches[1]] = $Matches[2] } }
    $env:RCLONE_CONFIG_OORT_TYPE = 's3'; $env:RCLONE_CONFIG_OORT_PROVIDER = 'Other'; $env:RCLONE_CONFIG_OORT_REGION = 'us-east-1'
    $env:RCLONE_CONFIG_OORT_ENDPOINT = $secrets['S3_ENDPOINT']; $env:RCLONE_CONFIG_OORT_ACCESS_KEY_ID = $secrets['S3_ACCESS_KEY']; $env:RCLONE_CONFIG_OORT_SECRET_ACCESS_KEY = $secrets['S3_SECRET_KEY']
    $secrets.Clear()
    try { & $Body } finally { Get-ChildItem Env:RCLONE_CONFIG_OORT_* | ForEach-Object { Remove-Item "Env:$($_.Name)" } }
}
function Get-StoreInstall([string] $Core, [string] $HostSource, [string] $Projects, [string] $Into, [string] $UrlFile) {
    . (Join-Path $PSScriptRoot 'env.ps1')
    $sdk = (& (Resolve-SpiralDotnet) --version | Select-Object -Last 1).Trim()
    $rid = if ($IsWindows) { 'win-x64' } else { 'linux-x64' }
    $keys = Get-StoreKeys $Core $HostSource $Projects $sdk $rid
    $baseDir = Join-Path $Into 'base'; $pairDir = Join-Path $Into 'pair'
    $rows = if ($UrlFile) { @(Get-Content -LiteralPath $UrlFile | Where-Object { $_ } | ForEach-Object { $o, $u = $_ -split "`t", 2; [pscustomobject]@{ Object = $o; Url = $u } }) } else { @() }
    function Fetch([string] $Key, [string] $Dir) {
        if ($UrlFile) {
            foreach ($row in $rows | Where-Object { $_.Object.StartsWith($Key + '/') }) {
                $local = Join-Path $Dir $row.Object.Substring($Key.Length + 1)
                New-Item -ItemType Directory -Force (Split-Path $local) | Out-Null
                Invoke-WebRequest -Uri $row.Url -OutFile $local -UseBasicParsing
            }
        } else { Use-OortKeys { rclone copy (Get-OortPath $Key) $Dir --s3-no-check-bucket 2>&1 | ForEach-Object { "  rclone: $_" } | Write-Host } }
    }
    Fetch $keys.Pair $pairDir
    if (-not (Test-Path -LiteralPath (Join-Path $pairDir 'manifest.json'))) { throw "store miss: no pair manifest at $($keys.Pair); build instead" }
    $pairManifest = Get-Content -Raw (Join-Path $pairDir 'manifest.json') | ConvertFrom-Json
    $baseKey = if ($pairManifest.PSObject.Properties['base'] -and $pairManifest.base) { $pairManifest.base } else { $keys.Base }
    if ($UrlFile) { $unknown = @($rows | Where-Object { -not $_.Object.StartsWith($keys.Pair + '/') -and -not $_.Object.StartsWith($baseKey + '/') }); if ($unknown) { throw "url list row $($unknown[0].Object) is for another sdk/rid/source than this host's $baseKey + $($keys.Pair)" } }
    Fetch $baseKey $baseDir
    if (-not (Test-Path -LiteralPath (Join-Path $baseDir 'manifest.json'))) { throw "store miss: no base manifest at $baseKey; build instead" }
    $baseManifest = Get-Content -Raw (Join-Path $baseDir 'manifest.json') | ConvertFrom-Json
    $files = Join-Path $baseDir 'files'
    foreach ($entry in $baseManifest.files.PSObject.Properties) { if ((Get-Sha (Join-Path $files $entry.Name)) -ne $entry.Value) { throw "store base file $($entry.Name) does not match its manifest" } }
    foreach ($entry in $pairManifest.dlls.PSObject.Properties) {
        $dll = Join-Path $pairDir $entry.Name
        if ((Get-Sha $dll) -ne $entry.Value) { throw "store pair file $($entry.Name) does not match its manifest" }
        Copy-Item -LiteralPath $dll (Join-Path $files $entry.Name) -Force
    }
    Write-Host "store hit: base $($baseKey -replace '^compiler/base/', '' -replace '/sdk-.*|/rid-.*', '') + pack $($pairManifest.pack), sdk $sdk, $rid; every file matches its manifest"
    $files
}
$compiler = Split-Path $PSScriptRoot
$liveCore = Join-Path $compiler 'spiral_compiler.fs'
$liveHost = Join-Path $compiler 'tmp/compiler/host/Program.fs'
$cacheRoot = $env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')
$kitExe = if ($IsWindows) { Join-Path $cacheRoot 'kit/bin/kit.exe' } else { $env:KIT_BIN ?? 'kit' }
$candidate = Join-Path $cacheRoot "spiral-bin-candidates/$Name"
$candidateCore = Join-Path $candidate 'source/spiral_compiler.fs'
$candidateHost = Join-Path $candidate 'source/Program.fs'
foreach ($required in $candidateCore, $candidateHost) { if (-not (Test-Path -LiteralPath $required)) { throw "candidate source missing: $required" } }
if ($MintUrls) {
    if (-not $UrlsOut) { throw '-MintUrls needs -UrlsOut <file>' }
    if (-not $TargetSdk) { . (Join-Path $PSScriptRoot 'env.ps1'); $TargetSdk = (& (Resolve-SpiralDotnet) --version | Select-Object -Last 1).Trim() }
    $keys = Get-StoreKeys $candidateCore $candidateHost (Join-Path $compiler 'tmp/compiler') $TargetSdk $TargetRid
    $rows = Use-OortKeys {
        $pairJson = (rclone cat --s3-no-check-bucket (Get-OortPath "$($keys.Pair)/manifest.json") 2>$null) -join "`n"
        if (-not $pairJson) { throw "store miss: no pair manifest at $($keys.Pair)" }
        $pairBase = ($pairJson | ConvertFrom-Json).PSObject.Properties['base']
        $baseKey = if ($pairBase -and $pairBase.Value) { $pairBase.Value } else { $keys.Base }
        foreach ($prefix in $baseKey, $keys.Pair) {
            $objects = @(rclone lsf -R --files-only --s3-no-check-bucket (Get-OortPath $prefix) 2>$null)
            if (-not $objects.Count) { throw "store miss: nothing under $prefix" }
            foreach ($o in $objects) { "$prefix/$o`t$((rclone link --expire $UrlsExpire (Get-OortPath "$prefix/$o") 2>$null | Select-Object -Last 1))" }
        }
    }
    [IO.File]::WriteAllText($UrlsOut, ($rows -join "`n") + "`n")
    "minted $($rows.Count) presigned GET urls (expire $UrlsExpire) for $TargetRid sdk $TargetSdk into $UrlsOut; the file is a bearer credential until it expires: ship it, never log it"
    return
}
if ($Put) {
    if (-not $FromDir -or -not $TargetSdk) { throw '-Put needs -FromDir <finished build output> and -TargetSdk <the exact SDK that built it>' }
    $identity = Get-Content -Raw -LiteralPath (Join-Path $FromDir 'build-identity.json') | ConvertFrom-Json
    if ($identity.sourceSha16 -ne (Get-Short $candidateCore)) { throw "-FromDir was built from core $($identity.sourceSha16), not the reviewed candidate $(Get-Short $candidateCore)" }
    foreach ($dll in $pairDlls) { if (-not (Test-ReadyToRunImage (Join-Path $FromDir $dll))) { throw "$dll in $FromDir is IL only: build.ps1 has not finished its in-place ReadyToRun step (wait for the build job to EXIT); refusing to put an immutable store entry" } }
    $keys = Get-StoreKeys $candidateCore $candidateHost (Join-Path $compiler 'tmp/compiler') $TargetSdk $TargetRid
    $baseRows = Get-BaseRows $FromDir
    $baseKey = Get-BaseKeyV2 $baseRows $TargetRid
    $putStage = Join-Path ([IO.Path]::GetTempPath()) "install-pack-put-$PID"
    try {
        foreach ($r in $baseRows) { $to = Join-Path $putStage "base/files/$($r.Name)"; New-Item -ItemType Directory -Force (Split-Path $to) | Out-Null; Copy-Item -LiteralPath $r.Path $to }
        $baseFiles = [ordered]@{}; foreach ($r in $baseRows) { $baseFiles[$r.Name] = $r.Sha }
        [IO.File]::WriteAllText((Join-Path $putStage 'base/manifest.json'), ([ordered]@{ schema = 'compiler-base/v2'; rid = $TargetRid; sdk = $TargetSdk; files = $baseFiles } | ConvertTo-Json -Depth 4) + "`n")
        New-Item -ItemType Directory -Force (Join-Path $putStage 'pair') | Out-Null
        $dllShas = [ordered]@{}; foreach ($dll in $pairDlls) { Copy-Item -LiteralPath (Join-Path $FromDir $dll) (Join-Path $putStage "pair/$dll"); $dllShas[$dll] = Get-Sha (Join-Path $FromDir $dll) }
        [IO.File]::WriteAllText((Join-Path $putStage 'pair/manifest.json'), ([ordered]@{ schema = 'compiler-pack/v1'; pack = $Name; core_source_sha256 = (Get-Sha $candidateCore); host_source_sha256 = (Get-Sha $candidateHost); sdk = $TargetSdk; rid = $TargetRid; base = $baseKey; dlls = $dllShas; uploaded = (Get-Date).ToUniversalTime().ToString('yyyy-MM-ddTHH:mm:ssZ') } | ConvertTo-Json -Depth 4) + "`n")
        Use-OortKeys {
            foreach ($part in @(@('base', $baseKey), @('pair', $keys.Pair))) {
                rclone copy (Join-Path $putStage $part[0]) (Get-OortPath $part[1]) --immutable --s3-no-check-bucket 2>&1 | ForEach-Object { "  rclone: $_" }
                if ($LASTEXITCODE) { throw "rclone copy of the $($part[0]) to $($part[1]) failed with exit $LASTEXITCODE (an existing immutable entry with different bytes also fails here)" }
            }
        }
        "PUT $Name $TargetRid sdk ${TargetSdk}: base $baseKey ($($baseRows.Count) files), pair $($keys.Pair); both DLLs ReadyToRun; build-identity matches the reviewed candidate"
    } finally { Remove-Item -LiteralPath $putStage -Recurse -Force -ErrorAction Ignore }
    return
}

$stage = Join-Path ([IO.Path]::GetTempPath()) "install-pack-$Name-$PID"
New-Item -ItemType Directory -Force $stage | Out-Null
$stageCore = Join-Path $stage 'spiral_compiler.fs'
$stageHost = Join-Path $stage 'Program.fs'
Copy-Item -LiteralPath $liveCore $stageCore
Copy-Item -LiteralPath $liveHost $stageHost
foreach ($applier in $CoreAppliers) { pwsh -NoProfile -File (Join-Path $PSScriptRoot $applier) -Core $stageCore -Apply | Out-Null; if ($LASTEXITCODE) { throw "$applier failed on today's live core" } }
foreach ($applier in $HostAppliers) { pwsh -NoProfile -File (Join-Path $PSScriptRoot $applier) -HostSource $stageHost -Apply | Out-Null; if ($LASTEXITCODE) { throw "$applier failed on today's live host" } }
foreach ($program in $Programs) { Get-Content -Raw -LiteralPath $program | & $kitExe do $stage - | Out-Null; if ($LASTEXITCODE) { throw "kit do $program failed on today's live source" } }
"live core $(Get-Short $liveCore), host $(Get-Short $liveHost); appliers on today's live -> core $(Get-Short $stageCore), host $(Get-Short $stageHost); reviewed candidate source core $(Get-Short $candidateCore), host $(Get-Short $candidateHost)"
if ((Get-Short $stageCore) -ne (Get-Short $candidateCore) -or (Get-Short $stageHost) -ne (Get-Short $candidateHost)) { throw 'the appliers on today''s live source do not reproduce the reviewed candidate source; re-review before installing' }

$fetched = $null
if ($FromStore -or $FromUrls) {
    if ($Modes -ne @('single-flight')) { throw '-FromStore/-FromUrls install single-flight only' }
    $fetched = Get-StoreInstall -Core $candidateCore -HostSource $candidateHost -Projects (Join-Path $compiler 'tmp/compiler') -Into (Join-Path $stage 'store') -UrlFile $FromUrls
}
if ($FromDir) {
    if ($Modes -ne @('single-flight')) { throw '-FromDir installs single-flight only' }
    $identityPath = Join-Path $FromDir 'build-identity.json'
    if (-not (Test-Path -LiteralPath (Join-Path $FromDir 'SpiralCompilerCore.dll')) -or -not (Test-Path -LiteralPath $identityPath)) { throw "-FromDir $FromDir is not a finished build output (no SpiralCompilerCore.dll or build-identity.json)" }
    $built = (Get-Content -Raw -LiteralPath $identityPath | ConvertFrom-Json).sourceSha16
    if ($built -ne (Get-Short $candidateCore)) { throw "-FromDir was built from core $built, not the reviewed candidate $(Get-Short $candidateCore)" }
    $fetched = (Resolve-Path -LiteralPath $FromDir).Path
    "from dir: $fetched, built from the reviewed candidate core $built"
}
$installed = Join-Path $cacheRoot 'spiral-bin/bin'
$processes =if ($IsWindows) { @(Get-CimInstance Win32_Process) } else { @(Get-Process | ForEach-Object { [pscustomobject]@{ ProcessId = $_.Id; Name = $_.ProcessName; CommandLine = $_.CommandLine; CreationDate = $_.StartTime } }) }
$installedPattern = [regex]::Escape(($installed -replace '\\', '/'))
$users = @($processes | Where-Object { $_.CommandLine -and ($_.CommandLine -replace '\\', '/') -match $installedPattern -and $_.ProcessId -ne $PID })
$pinCode = (Get-Item -LiteralPath (Join-Path $compiler '../cells/lib/spiral/cells/compiler_daemon.ex')).LastWriteTime
$daemons = @($processes | Where-Object { $_.Name -in 'erl.exe', 'beam.smp', 'erl' } | Where-Object { ($_.CommandLine -match 'spiral\.notebook' -and $_.CommandLine -notmatch '--gate\b') -or ($_.CommandLine -match 'CompilerDaemon' -and $_.CreationDate -lt $pinCode) })
if ($users -or $daemons) { @($users) + @($daemons) | ForEach-Object { "IN USE pid=$($_.ProcessId) $($_.Name)" }; throw 'the installed compiler is in use; not installing' }
if (-not $Apply) { Remove-Item -Recurse -Force $stage; "dry run ok: the candidate reproduces from today's live source$(if ($fetched) { ', the store copy fetched and matched its manifests' }) and nothing uses the installed compiler; rerun with -Apply"; return }

$stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
$backupDir = Join-Path $Backup "$Name-$stamp"
New-Item -ItemType Directory -Force $backupDir | Out-Null
Copy-Item -LiteralPath $liveCore (Join-Path $backupDir 'spiral_compiler.fs.before')
Copy-Item -LiteralPath $liveHost (Join-Path $backupDir 'Program.fs.before')
foreach ($mode in $Modes) {
    $bin = Join-Path $installed "$mode/SpiralCompiler/Release/net11.0"
    if (Test-Path $bin) { Copy-Item -LiteralPath $bin (Join-Path $backupDir "$mode-bin.before") -Recurse }
}
"backup: $backupDir"
Copy-Item -LiteralPath $candidateCore $liveCore -Force
Copy-Item -LiteralPath $candidateHost $liveHost -Force
$installedBin = Join-Path $installed 'single-flight/SpiralCompiler/Release/net11.0'
if ($fetched) {
    New-Item -ItemType Directory -Force $installedBin | Out-Null
    Get-ChildItem -LiteralPath $fetched -Recurse -File | ForEach-Object {
        $target = Join-Path $installedBin $_.FullName.Substring($fetched.Length + 1)
        New-Item -ItemType Directory -Force (Split-Path $target) | Out-Null
        Copy-Item -LiteralPath $_.FullName $target -Force
    }
    $mismatch = @(Get-ChildItem -LiteralPath $fetched -Recurse -File | Where-Object { (Get-FileHash -LiteralPath $_.FullName).Hash -ne (Get-FileHash -LiteralPath (Join-Path $installedBin $_.FullName.Substring($fetched.Length + 1))).Hash })
    "installed $(if ($FromDir) { 'from the dir' } else { 'from the store' }): $((Get-ChildItem -LiteralPath $fetched -Recurse -File).Count) files, mismatches after copy: $($mismatch.Count)"
    if ($mismatch.Count) { throw "copy left $($mismatch.Count) mismatched files; restore with: copy $backupDir\single-flight-bin.before over $installedBin" }
} else {
    foreach ($mode in $Modes) {
        pwsh -NoProfile -File (Join-Path $compiler 'scripts/build.ps1') -Mode $mode -Configuration Release
        if ($LASTEXITCODE) { throw "build of $mode failed with exit $LASTEXITCODE; live sources are the candidate's, backup in $backupDir" }
    }
    $candidateBin = Join-Path $candidate 'cache/bin/single-flight/SpiralCompiler/Release/net11.0'
    foreach ($dll in 'SpiralCompiler.dll', 'SpiralCompilerCore.dll') {
        $want = Get-Short (Join-Path $candidateBin $dll)
        $got = Get-Short (Join-Path $installedBin $dll)
        "$dll installed $got, reviewed candidate $want, equal=$($got -eq $want)"
    }
}
function Test-Launches([string] $dotnet) {
    $help = & $dotnet (Join-Path $installedBin 'SpiralCompiler.dll') --capabilities 2>&1 | Out-String
    $LASTEXITCODE -eq 0 -and $help -notmatch 'install or update \.NET'
}
. (Join-Path $PSScriptRoot 'env.ps1')
$consumerDotnet = Resolve-SpiralDotnet
$launches = Test-Launches $consumerDotnet
"resolved dotnet ($consumerDotnet, the one Cells and the scripts use) launches the installed compiler: $launches"
if (-not $launches) { throw "the installed compiler does not launch under the resolved dotnet (runtime mismatch); restore with: copy $backupDir\<mode>-bin.before over the installed bin folder" }
if ($Smoke) {
    if (-not $env:SPIRAL_COMPILER_PACKAGE_DIR) { $env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir }
    $smokeOut = & $consumerDotnet (Join-Path $installedBin 'SpiralCompiler.dll') --check --timeout-ms 300000 $Smoke 2>&1 | Out-String
    $smokeOk = $LASTEXITCODE -eq 0 -and $smokeOut -notmatch 'Method not found|MissingMethod|TypeLoadException|FileNotFoundException'
    "smoke --check $(Split-Path -Leaf $Smoke): exit $LASTEXITCODE, ok $smokeOk"
    if (-not $smokeOk) {
        $before = Join-Path $backupDir 'single-flight-bin.before'
        if (Test-Path -LiteralPath $before) { Remove-Item -Recurse -Force -LiteralPath $installedBin; Copy-Item -LiteralPath $before $installedBin -Recurse }
        throw "the installed compiler failed a real --check (a launch check alone misses a stale FSharp.Core); ROLLED BACK the bin from $before. First lines: $(($smokeOut -split "`n" | Select-Object -First 3) -join ' | ')"
    }
}
$pathDotnet = (Get-Command dotnet -ErrorAction SilentlyContinue).Source
if ($pathDotnet -and [IO.Path]::GetFullPath($pathDotnet) -ne [IO.Path]::GetFullPath($consumerDotnet) -and -not (Test-Launches $pathDotnet)) {
    "WARNING: the PATH dotnet ($pathDotnet) does not launch it; only a bare 'dotnet SpiralCompiler.dll' call uses that one (set SPIRAL_DOTNET or put $consumerDotnet first on PATH)"
}
Remove-Item -Recurse -Force $stage
$cellsDomainStamp = Join-Path $PSScriptRoot '../../cells/build/spiral_domain.inputs'
if (Test-Path -LiteralPath $cellsDomainStamp) { Remove-Item -LiteralPath $cellsDomainStamp; 'Cells domain stamp removed: the next mix compile regenerates domain.gleam with the new compiler' }
"INSTALLED $Name; undo: copy $backupDir\<mode>-bin.before over $installed\<mode>\SpiralCompiler\Release\net11.0 and the *.fs.before sources back"
