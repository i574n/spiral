<#
.SYNOPSIS
Benchmarks compiling the split core as one F# project against the monolith, phase by phase.

.DESCRIPTION
Emits the core with spiral-split (unless -SkipEmit), generates single-compilation projects with
scripts/split_project.py and builds each with `--times`, then prints wall time per compiler phase and the
summed per-file check CPU. Everything lands in <cache>/split-bench/<core>/. Needs the hopac build (for
Supervisor.dll) and the splitter binary (scripts/build-splitter.ps1).

.EXAMPLE
pwsh scripts/bench-split.ps1                               # monolith, one file per part, grouped (cap 12000)
pwsh scripts/bench-split.ps1 -Variants parts -SkipEmit      # re-time one variant on the last emit
#>
param(
    [ValidateSet('single-flight', 'sf', 'hopac', 'hp')][string]$Mode = 'hopac',
    [ValidateSet('monolith', 'parts', 'grouped')][string[]]$Variants = @('monolith', 'parts', 'grouped'),
    [int]$GroupCap = 12000,
    [int]$GroupBudget = 45000,
    [switch]$NoGraph,
    [switch]$SkipEmit,
    # Re-summarize the last builds' --times output without emitting or building again.
    [switch]$ReportOnly
)
. $PSScriptRoot/env.ps1

$dotnet = Resolve-SpiralDotnet
$cache = Get-SpiralCacheDir
$m = ConvertTo-SpiralMode $Mode
$core = Get-SpiralCoreSource $m
$root = Join-Path $cache "split-bench/$m"
$emit = Join-Path $root 'emit'
$lib = Get-SpiralLibDir
$env:SPIRAL_ASSEMBLY_ROOT = $lib
$supervisor = Join-Path $cache 'bin/hopac/SpiralCompilerRuntimeCompat/Release/net11.0/Supervisor.dll'
$splitter = Join-Path $cache 'splitter-target/release/spiral-split'
if ($IsWindows) { $splitter += '.exe' }
foreach ($required in $supervisor, $splitter) {
    if (-not (Test-Path $required)) { throw "missing $required (run scripts/build.ps1 -Mode hopac and scripts/build-splitter.ps1)" }
}
New-Item -ItemType Directory -Force $root | Out-Null

if (-not $SkipEmit -and -not $ReportOnly -and ($Variants -contains 'parts' -or $Variants -contains 'grouped')) {
    Write-Host "== emitting $core"
    & $splitter gears $core $emit --threads ([Environment]::ProcessorCount) 2>&1 | Select-Object -Last 1
    if ($LASTEXITCODE -ne 0) { throw 'spiral-split failed' }
}

$phases = 'Parse inputs', 'Typecheck', 'Optimizations', 'TAST -> IL', 'Write .NET Binary'
$graphArg = if ($NoGraph) { @('--nograph') } else { @() }
$rows = foreach ($variant in $Variants) {
    $dir = Join-Path $root $variant
    if ($ReportOnly) {
        if (-not (Test-Path (Join-Path $dir 'times.csv'))) { Write-Host "== no build for $variant"; continue }
        $exit = 0; $seconds = ''
        $errors = @(Get-Content (Join-Path $dir 'build.log') | Select-String ': error ' | ForEach-Object { $_.Line -replace ' \[.*$', '' } | Sort-Object -Unique)
    } else {
    if (Test-Path $dir) { Remove-Item -Recurse -Force $dir }
    $generator = switch ($variant) {
        'monolith' { @('monolith', $core, $lib, $supervisor, $dir) }
        'parts' { @('parts', $emit, $lib, $supervisor, $dir) }
        'grouped' { @('parts', $emit, $lib, $supervisor, $dir, '--cap', $GroupCap, '--budget', $GroupBudget) }
    }
    $generator += $graphArg
    python (Join-Path $PSScriptRoot 'split_project.py') @generator | Out-Host
    Write-Host "== building $variant"
    $sw = [Diagnostics.Stopwatch]::StartNew()
    $log = & $dotnet build (Join-Path $dir 'SplitBench.fsproj') -c Release -nologo -v:q 2>&1
    $exit = $LASTEXITCODE
    $seconds = [math]::Round($sw.Elapsed.TotalSeconds)
    $log | Set-Content (Join-Path $dir 'build.log')
    $errors = @($log | Select-String ': error ' | ForEach-Object { $_.Line -replace ' \[.*$', '' } | Sort-Object -Unique)
    }
    if ($errors) { $errors | Select-Object -First 10 | ForEach-Object { Write-Host "   $_" -ForegroundColor Red } }
    $times = Import-Csv (Join-Path $dir 'times.csv')
    $parse = { param($s) $p = $s -split '-'; [int]$p[0] * 3600 + [int]$p[1] * 60 + [double]$p[2] }
    $row = [ordered]@{ variant = $variant; exit = $exit; errors = $errors.Count; build_s = $seconds }
    foreach ($phase in $phases) {
        $spans = @($times | Where-Object Name -EQ $phase)
        $row[$phase] = if ($spans) { [math]::Round(($spans | ForEach-Object { (& $parse $_.EndTime) - (& $parse $_.StartTime) } | Measure-Object -Sum).Sum) } else { '' }
    }
    $checks = @($times | Where-Object Name -EQ 'CheckDeclarations.CheckOneImplFile')
    $row['files'] = $checks.Count
    $row['check_cpu_s'] = [math]::Round(($checks | ForEach-Object { [double]$_.'Duration(s)' } | Measure-Object -Sum).Sum)
    [pscustomobject]$row
}
$rows | Format-Table -AutoSize | Out-String -Width 200
$receipt = Join-Path $root 'bench.tsv'
$lines = $rows | ForEach-Object { $_ | Add-Member -NotePropertyName timestamp -NotePropertyValue (Get-Date -Format s) -PassThru } |
    ConvertTo-Csv -Delimiter "`t" -NoTypeInformation -UseQuotes Never
if (Test-Path $receipt) { $lines = $lines | Select-Object -Skip 1 }
$lines | Add-Content $receipt
Write-Host "== receipts appended to $receipt ($([Environment]::ProcessorCount) logical cores)"
