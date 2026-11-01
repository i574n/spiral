param(
    [Parameter(Mandatory)] [string] $Name,
    [string[]] $CoreAppliers = @(),
    [string[]] $HostAppliers = @(),
    [string[]] $Programs = @(),
    [ValidateSet('Release', 'Debug')] [string] $Configuration = 'Release',
    [ValidateSet('single-flight', 'hopacsota')] [string] $Mode = 'single-flight'
)
$ErrorActionPreference = 'Stop'
$CoreAppliers = @($CoreAppliers | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$HostAppliers = @($HostAppliers | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$Programs = @($Programs | ForEach-Object { $_ -split ',' } | Where-Object { $_ })

$skipped = 'Path', 'PSModulePath', 'TEMP', 'TMP'
$imported = foreach ($scope in 'Machine', 'User') {
    $variables = [Environment]::GetEnvironmentVariables($scope)
    foreach ($key in $variables.Keys) {
        if ($key -in $skipped -or -not $variables[$key] -or [Environment]::GetEnvironmentVariable($key, 'Process')) { continue }
        [Environment]::SetEnvironmentVariable($key, $variables[$key], 'Process')
        $key
    }
}
"imported from the registry: $(if ($imported) { ($imported | Sort-Object -Unique) -join ', ' } else { 'none' })"

$compiler = Split-Path $PSScriptRoot
$liveCore = Join-Path $compiler 'spiral_compiler.fs'
$liveHost = Join-Path $compiler 'tmp/compiler/host/Program.fs'
$root = Join-Path $env:LOCALAPPDATA "spiral-bin-candidates/$Name"
$source = Join-Path $root 'source'
New-Item -ItemType Directory -Force $source | Out-Null
$core = Join-Path $source 'spiral_compiler.fs'
$hostSource = Join-Path $source 'Program.fs'
Copy-Item $liveCore $core -Force
Copy-Item $liveHost $hostSource -Force
"live core $((Get-FileHash $liveCore -Algorithm SHA256).Hash.Substring(0, 16)), live host $((Get-FileHash $liveHost -Algorithm SHA256).Hash.Substring(0, 16))"

foreach ($applier in $CoreAppliers) {
    pwsh -NoProfile -File (Join-Path $PSScriptRoot $applier) -Core $core -Apply
    if ($LASTEXITCODE) { throw "$applier failed on the core copy" }
}
foreach ($applier in $HostAppliers) {
    pwsh -NoProfile -File (Join-Path $PSScriptRoot $applier) -HostSource $hostSource -Apply
    if ($LASTEXITCODE) { throw "$applier failed on the host copy" }
}
foreach ($program in $Programs) {
    Get-Content -Raw -LiteralPath $program | & (Join-Path $env:LOCALAPPDATA 'kit\bin\kit.exe') do $source -
    if ($LASTEXITCODE) { throw "kit do $program failed on the source copy" }
}
"candidate core $((Get-FileHash $core -Algorithm SHA256).Hash.Substring(0, 16)), candidate host $((Get-FileHash $hostSource -Algorithm SHA256).Hash.Substring(0, 16))"

$env:SPIRAL_BIN_CACHE_DIR = Join-Path $root 'cache'
pwsh -NoProfile -File (Join-Path $compiler 'scripts/build.ps1') -Mode $Mode -Configuration $Configuration -CoreSource $core -HostSource $hostSource
if ($LASTEXITCODE) { throw "build failed with exit $LASTEXITCODE" }
$bin = Join-Path $env:SPIRAL_BIN_CACHE_DIR "bin/$Mode/SpiralCompiler/$Configuration/net11.0"
foreach ($dll in 'SpiralCompiler.dll', 'SpiralCompilerCore.dll') {
    "$dll $((Get-FileHash (Join-Path $bin $dll) -Algorithm SHA256).Hash.Substring(0, 16))"
}
"candidate: $(Join-Path $bin 'SpiralCompiler.dll')"
