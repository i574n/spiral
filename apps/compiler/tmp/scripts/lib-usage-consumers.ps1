param(
    [string[]] $Paths,
    [int] $PathsPerRun = 20,
    [string] $References = (Join-Path ([IO.Path]::GetTempPath()) 'spiral-consumer-references.tsv'),
    [string] $Out = (Join-Path ([IO.Path]::GetTempPath()) 'lib-usage-consumers.tsv'),
    [string] $PackageDir
)
$ErrorActionPreference = 'Stop'
$spiral = (Resolve-Path (Join-Path $PSScriptRoot '../../../..')).Path
if (-not $Paths) {
    $libWithTests = Get-ChildItem (Join-Path $spiral 'lib/spiral') -Recurse -Filter *.spi | Where-Object { Select-String -LiteralPath $_.FullName -Pattern '^test ' -Quiet }
    $blogEngine = Get-ChildItem (Join-Path (Split-Path $spiral) 'blog/engine') -Filter *.spi -ErrorAction SilentlyContinue
    $xSources = Get-ChildItem (Join-Path (Split-Path $spiral) 'x') -Recurse -Filter *.spi -ErrorAction SilentlyContinue | Where-Object { $_.FullName -notmatch '\\(target|deps|dist)\\' -and (Select-String -LiteralPath $_.FullName -Pattern '^test ' -Quiet) }
    $Paths = @($libWithTests) + @($blogEngine) + @($xSources) | ForEach-Object FullName
}
Remove-Item -LiteralPath $References -ErrorAction Ignore
$env:SPIRAL_REFERENCES_OUT = $References
$env:SPIRAL_CELLS_COMPILER = 'process'
$env:SPIRAL_CELLS_MEMO = '0'
if ($PackageDir) { $env:SPIRAL_COMPILER_PACKAGE_DIR = (Resolve-Path $PackageDir).Path }
$env:MIX_BUILD_PATH = Join-Path ([IO.Path]::GetTempPath()) 'spiral-consumer-census-build'
$env:PATH = "$HOME\scoop\apps\erlang\current\bin;$HOME\scoop\apps\elixir\current\bin;$env:PATH"
$watch = [Diagnostics.Stopwatch]::StartNew()
Push-Location (Join-Path $spiral 'apps/cells')
try {
    for ($at = 0; $at -lt $Paths.Count; $at += $PathsPerRun) {
        $chunk = $Paths[$at..([Math]::Min($at + $PathsPerRun, $Paths.Count) - 1)]
        $mixArgs = @('spiral.notebook', '--gate') + ($chunk | ForEach-Object { '--path'; $_ })
        & mix @mixArgs 2>&1 | Select-String -Pattern 'spiral-tests total' | ForEach-Object { $_.Line.Substring(0, [Math]::Min(160, $_.Line.Length)) }
        $firstChunkRecordedNothing = $at -eq 0 -and -not ((Test-Path -LiteralPath $References) -and (Get-Item -LiteralPath $References).Length -gt 0)
        if ($firstChunkRecordedNothing) {
            throw "first chunk recorded no reference rows in ${References}: the compiler Cells ran predates the recorder; stopping before the remaining chunks"
        }
    }
} finally {
    Pop-Location
    $env:SPIRAL_REFERENCES_OUT = $null
    $env:SPIRAL_COMPILER_PACKAGE_DIR = $null
}
if (-not (Test-Path -LiteralPath $References) -or (Get-Item -LiteralPath $References).Length -eq 0) {
    throw "no reference rows in ${References}: the installed compiler predates the recorder, or no compile reached prepass"
}
"consumer corpus: $($Paths.Count) files in $([int]$watch.Elapsed.TotalSeconds) s"
pwsh -NoProfile -File (Join-Path $PSScriptRoot 'lib-usage-references.ps1') -References $References -Out $Out
