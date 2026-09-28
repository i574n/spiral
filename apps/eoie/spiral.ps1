[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$InputPath,
    [Parameter(Mandatory)][string]$OutputPath,
    [ValidateSet('Rust', 'C', 'Fsharp', 'Delphi')][string]$Backend = 'Rust',
    [string]$CompilerBundle = $env:EOIE_SPIRAL_BUNDLE,
    [string]$SourceRoot = $PSScriptRoot,
    [ValidateRange(1, 600)][int]$TimeoutSec = 60
)
$ErrorActionPreference = 'Stop'
$inputFile = (Resolve-Path -LiteralPath $InputPath).Path
$outputFile = [IO.Path]::GetFullPath($OutputPath, $PWD.Path)
$sourceDirectory = (Resolve-Path -LiteralPath $SourceRoot).Path
$relativeInput = [IO.Path]::GetRelativePath($sourceDirectory, $inputFile)
if ($relativeInput -eq '..' -or $relativeInput.StartsWith('../') -or $relativeInput.StartsWith('..\') -or [IO.Path]::IsPathRooted($relativeInput)) {
    throw 'InputPath must be inside SourceRoot (the EOIE directory by default).'
}
if (-not $CompilerBundle) {
    $CompilerBundle = Join-Path $PSScriptRoot '../compiler/tmp'
}
$CompilerBundle = (Resolve-Path -LiteralPath $CompilerBundle).Path
$previousWorkspace = $env:SPIRAL_WORKSPACE_ROOT
$previousDotnet = $env:DOTNET_ROOT
try {
    . (Join-Path $CompilerBundle 'scripts/env.ps1')
    $dotnet = Resolve-SpiralDotnet
    $compiler = Get-SpiralCompilerDll 'single-flight'
    if (-not (Test-Path -LiteralPath $compiler)) { throw "Build the compiler first: pwsh $CompilerBundle/scripts/build.ps1" }
    $work = Join-Path (Get-SpiralCacheDir) ('eoie/' + [guid]::NewGuid().ToString('N'))
    New-Item -ItemType Directory -Path $work -Force | Out-Null
    # The core writes residuals beside its inputs. Never compile the checkout in place.
    function Copy-SpiralSources([string]$From, [string]$To) {
        New-Item -ItemType Directory -Path $To -Force | Out-Null
        foreach ($entry in Get-ChildItem -LiteralPath $From -Force) {
            if ($entry.Attributes -band [IO.FileAttributes]::ReparsePoint) { continue }
            if ($entry.PSIsContainer) {
                if ($entry.Name -notin @('target', 'vendor', '.git', '.cache')) {
                    Copy-SpiralSources $entry.FullName (Join-Path $To $entry.Name)
                }
            } elseif ($entry.Extension -in @('.spi', '.spiproj')) {
                Copy-Item -LiteralPath $entry.FullName -Destination (Join-Path $To $entry.Name)
            }
        }
    }
    Copy-SpiralSources $sourceDirectory (Join-Path $work 'source')
    $stagedInput = Join-Path $work (Join-Path 'source' $relativeInput)
    $stagedOutput = Join-Path $work ('output' + [IO.Path]::GetExtension($outputFile))
    $jobs = Join-Path $work 'jobs.tsv'
    $results = Join-Path $work 'results.tsv'
    foreach ($value in @($stagedInput, $stagedOutput)) {
        if ($value.Contains("`t") -or $value.Contains("`n")) { throw 'Compiler batch paths cannot contain tabs or newlines.' }
    }
    "eoie`t$Backend`t$stagedInput`t$stagedOutput`t$($TimeoutSec * 1000)" | Set-Content -LiteralPath $jobs -Encoding utf8NoBOM
    $env:SPIRAL_WORKSPACE_ROOT = $CompilerBundle
    & $dotnet $compiler --batch $jobs $results --timeout-ms ($TimeoutSec * 1000)
    if ($LASTEXITCODE -ne 0 -or -not (Test-Path -LiteralPath $stagedOutput)) {
        throw "Spiral compilation failed; diagnostics: $results"
    }
    New-Item -ItemType Directory -Path (Split-Path $outputFile -Parent) -Force | Out-Null
    [IO.File]::WriteAllText($outputFile, [IO.File]::ReadAllText($stagedOutput).TrimEnd() + "`n")
    Write-Host "Generated $outputFile (single-flight; staged sources: $work)"
} finally {
    $env:SPIRAL_WORKSPACE_ROOT = $previousWorkspace
    $env:DOTNET_ROOT = $previousDotnet
}
