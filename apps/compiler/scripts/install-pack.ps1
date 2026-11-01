param(
    [Parameter(Mandatory)] [string] $Name,
    [string[]] $CoreAppliers = @(),
    [string[]] $HostAppliers = @(),
    [string[]] $Programs = @(),
    [string[]] $Modes = @('single-flight'),
    [string] $Backup = (Join-Path $env:LOCALAPPDATA 'spiral-bin\compiler-installs'),
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

$compiler = Split-Path $PSScriptRoot
$liveCore = Join-Path $compiler 'spiral_compiler.fs'
$liveHost = Join-Path $compiler 'tmp/compiler/host/Program.fs'
$candidate = Join-Path $env:LOCALAPPDATA "spiral-bin-candidates/$Name"
$candidateCore = Join-Path $candidate 'source/spiral_compiler.fs'
$candidateHost = Join-Path $candidate 'source/Program.fs'
foreach ($required in $candidateCore, $candidateHost) { if (-not (Test-Path -LiteralPath $required)) { throw "candidate source missing: $required" } }

$stage = Join-Path ([IO.Path]::GetTempPath()) "install-pack-$Name-$PID"
New-Item -ItemType Directory -Force $stage | Out-Null
$stageCore = Join-Path $stage 'spiral_compiler.fs'
$stageHost = Join-Path $stage 'Program.fs'
Copy-Item -LiteralPath $liveCore $stageCore
Copy-Item -LiteralPath $liveHost $stageHost
foreach ($applier in $CoreAppliers) { pwsh -NoProfile -File (Join-Path $PSScriptRoot $applier) -Core $stageCore -Apply | Out-Null; if ($LASTEXITCODE) { throw "$applier failed on today's live core" } }
foreach ($applier in $HostAppliers) { pwsh -NoProfile -File (Join-Path $PSScriptRoot $applier) -HostSource $stageHost -Apply | Out-Null; if ($LASTEXITCODE) { throw "$applier failed on today's live host" } }
foreach ($program in $Programs) { Get-Content -Raw -LiteralPath $program | & (Join-Path $env:LOCALAPPDATA 'kit\bin\kit.exe') do $stage - | Out-Null; if ($LASTEXITCODE) { throw "kit do $program failed on today's live source" } }
"live core $(Get-Short $liveCore), host $(Get-Short $liveHost); appliers on today's live -> core $(Get-Short $stageCore), host $(Get-Short $stageHost); reviewed candidate source core $(Get-Short $candidateCore), host $(Get-Short $candidateHost)"
if ((Get-Short $stageCore) -ne (Get-Short $candidateCore) -or (Get-Short $stageHost) -ne (Get-Short $candidateHost)) { throw 'the appliers on today''s live source do not reproduce the reviewed candidate source; re-review before installing' }

$installed = Join-Path $env:LOCALAPPDATA 'spiral-bin\bin'
$users = @(Get-CimInstance Win32_Process | Where-Object { $_.CommandLine -and $_.CommandLine -match [regex]::Escape($installed) -and $_.ProcessId -ne $PID })
$daemons = @(Get-CimInstance Win32_Process -Filter "Name='erl.exe'" | Where-Object { $_.CommandLine -match 'CompilerDaemon|spiral\.notebook' })
if ($users -or $daemons) { @($users) + @($daemons) | ForEach-Object { "IN USE pid=$($_.ProcessId) $($_.Name)" }; throw 'the installed compiler is in use; not installing' }
if (-not $Apply) { Remove-Item -Recurse -Force $stage; 'dry run ok: the candidate reproduces from today''s live source and nothing uses the installed compiler; rerun with -Apply'; return }

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
foreach ($mode in $Modes) {
    pwsh -NoProfile -File (Join-Path $compiler 'scripts/build.ps1') -Mode $mode -Configuration Release
    if ($LASTEXITCODE) { throw "build of $mode failed with exit $LASTEXITCODE; live sources are the candidate's, backup in $backupDir" }
}
$candidateBin = Join-Path $candidate 'cache/bin/single-flight/SpiralCompiler/Release/net11.0'
$installedBin = Join-Path $installed 'single-flight/SpiralCompiler/Release/net11.0'
foreach ($dll in 'SpiralCompiler.dll', 'SpiralCompilerCore.dll') {
    $want = Get-Short (Join-Path $candidateBin $dll)
    $got = Get-Short (Join-Path $installedBin $dll)
    "$dll installed $got, reviewed candidate $want, equal=$($got -eq $want)"
}
$systemDotnet = (Get-Command dotnet -ErrorAction SilentlyContinue).Source
if ($systemDotnet) {
    $help = & $systemDotnet (Join-Path $installedBin 'SpiralCompiler.dll') --capabilities 2>&1 | Out-String
    $launches = $LASTEXITCODE -eq 0 -and $help -notmatch 'install or update \.NET'
    "system dotnet ($systemDotnet) launches the installed compiler: $launches"
    if (-not $launches) { throw "the installed compiler does not launch under the system dotnet (runtime mismatch); restore with: copy $backupDir\<mode>-bin.before over the installed bin folder" }
}
Remove-Item -Recurse -Force $stage
$cellsDomainStamp = Join-Path $PSScriptRoot '../../cells/build/spiral_domain.inputs'
if (Test-Path -LiteralPath $cellsDomainStamp) { Remove-Item -LiteralPath $cellsDomainStamp; 'Cells domain stamp removed: the next mix compile regenerates domain.gleam with the new compiler' }
"INSTALLED $Name; undo: copy $backupDir\<mode>-bin.before over $installed\<mode>\SpiralCompiler\Release\net11.0 and the *.fs.before sources back"
