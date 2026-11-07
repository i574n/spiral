param(
    [Parameter(Mandatory)] [string] $Dll,
    [string[]] $Suite = @('all'),
    [switch] $Accept,
    [switch] $AcceptToolchain,
    [switch] $Reuse
)
$ErrorActionPreference = 'Continue'
$Suite = @($Suite | ForEach-Object { $_ -split ',' } | Where-Object { $_ })

$added = [Collections.Generic.List[string]]::new()
$differs = [Collections.Generic.List[string]]::new()
foreach ($scope in 'Machine', 'User') {
    foreach ($e in [Environment]::GetEnvironmentVariables($scope).GetEnumerator()) {
        if ($e.Key -in 'Path', 'PSModulePath', 'TEMP', 'TMP' -or -not $e.Value) { continue }
        $current = [Environment]::GetEnvironmentVariable($e.Key, 'Process')
        if ($null -eq $current) { [Environment]::SetEnvironmentVariable($e.Key, $e.Value, 'Process'); $added.Add($e.Key) }
        elseif ($current -ne $e.Value -and $scope -eq 'User') { $differs.Add($e.Key) }
    }
}
"env: added from the registry (names only): $($added -join ', ')"
"env: process value differs from User registry (kept, names only): $($differs -join ', ')"

$resolved = (Resolve-Path -LiteralPath $Dll).Path
$env:SPIRAL_COMPILER_DLL = $resolved
$env:SPIRAL_CC = Join-Path $HOME 'scoop\apps\gcc\current\bin\gcc.exe'
Remove-Item Env:SPIRAL_BIN_CACHE_DIR -ErrorAction SilentlyContinue
$bin = Split-Path $resolved
foreach ($name in 'SpiralCompiler.dll', 'SpiralCompilerCore.dll') { "$name $((Get-FileHash (Join-Path $bin $name) -Algorithm SHA256).Hash.Substring(0, 16))" }

$compiler = Split-Path $PSScriptRoot
$repo = (Resolve-Path (Join-Path $compiler '..\..')).Path
$dirtyBefore = @(git -C $repo status --porcelain -- apps/compiler/tmp/samples)
"samples dirty before the run: $($dirtyBefore.Count)"
$dirtyBefore | Select-Object -First 10

Set-Location $compiler
$testArgs = @('-NoProfile', '-File', 'scripts\test.ps1', '-Mode', 'single-flight', '-Suite', ($Suite -join ','), '-Native')
if ($Accept) { $testArgs += '-Accept' }
if ($Accept -and $AcceptToolchain) { $testArgs += '-AcceptToolchain' }
elseif ($Reuse) { $testArgs += @('-ReuseCompile', '-ReuseNative') }
"start $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss') accept=$([bool]$Accept) suite=$($Suite -join ',') cc=$env:SPIRAL_CC"
pwsh @testArgs 2>&1 | ForEach-Object { "$_" }
$code = $LASTEXITCODE
"end $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss') exit=$code"
$latest = Get-ChildItem (Join-Path $env:LOCALAPPDATA 'spiral-bin\runs') -Directory -Filter 'single-flight-*' | Sort-Object LastWriteTime | Select-Object -Last 1
"run dir: $($latest.FullName)"
"samples changed by the run:"
git -C $repo --no-pager diff --stat -- apps/compiler/tmp/samples | Select-Object -Last 30
exit $code
