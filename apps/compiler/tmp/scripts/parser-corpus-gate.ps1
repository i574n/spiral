param(
    [Parameter(Mandatory)] [string] $CoreSource,
    [string] $Cache = (Join-Path $env:LOCALAPPDATA 'spiral-bin\candidates\parser-corpus-gate'),
    [string] $SampleDir
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'env.ps1')
$dotnet = Resolve-SpiralDotnet
"candidate core $((Get-FileHash $CoreSource).Hash.Substring(0, 16))"
$env:SPIRAL_BIN_CACHE_DIR = $Cache
Remove-Item Env:SPIRAL_COMPILER_DLL -ErrorAction Ignore
pwsh -NoProfile -File (Join-Path $PSScriptRoot 'build.ps1') -Mode single-flight -Configuration Debug -CoreSource $CoreSource 2>&1 | Select-Object -Last 2
if ($LASTEXITCODE) { throw 'candidate did not build' }
Remove-Item Env:SPIRAL_BIN_CACHE_DIR -ErrorAction Ignore
$candidate = Join-Path $Cache 'bin\single-flight\SpiralCompiler\Debug\net11.0\SpiralCompiler.dll'
$installed = Get-SpiralCompilerDll single-flight
$work = Join-Path $Cache 'gate'
if (Test-Path $work) { Remove-Item $work -Recurse -Force }
New-Item -ItemType Directory -Force $work | Out-Null
$corpus = Join-Path $work 'corpus.tsv'
pwsh -NoProfile -File (Join-Path $PSScriptRoot '..\formatter\corpus.ps1') -Out $corpus | Out-Null
foreach ($repo in 'tibia', 'x', 'dice', 'alphabet', 'polyglot') {
    $root = "C:\home\git\$repo"
    if (-not (Test-Path "$root\.git")) { continue }
    foreach ($rel in git -C $root ls-files -- '*.spi' '*.spir') { Add-Content $corpus "$repo`t3`t$(Join-Path $root $rel)`t$repo/$rel" }
}
"corpus rows: $((Get-Content $corpus).Count)"
foreach ($pair in @(@('installed', $installed), @('candidate', $candidate))) {
    $listing = Join-Path $work "$($pair[0]).listing"
    & $dotnet $pair[1] format-corpus flatten --list $listing $corpus 2>&1 | Out-Null
    "$($pair[0]) listing: $((Get-Item $listing).Length) bytes"
}
$diff = Compare-Object @(Get-Content (Join-Path $work 'installed.listing')) @(Get-Content (Join-Path $work 'candidate.listing'))
"listing lines that differ: $(@($diff).Count)"
$diff | Select-Object -First 20 | ForEach-Object { "  $($_.SideIndicator) $($_.InputObject)" }
if ($SampleDir) {
    $out = Join-Path $work 'sample.c'
    Push-Location $SampleDir
    $env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
    $o = @(& $dotnet $candidate --backend C (Join-Path $SampleDir 'main.spi') $out 2>&1 | ForEach-Object { "$_" })
    $code = $LASTEXITCODE
    Pop-Location
    "sample with the candidate: exit $code, output written: $(Test-Path $out) $(($o | Select-Object -First 1))"
}
