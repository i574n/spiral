<#
.SYNOPSIS
Contracts for Rust library output: `RustLibrary()` plus the `RustExport*` markers.

.DESCRIPTION
Compiles tests/rust-exports/exports (six export ABIs) and tests/rust-exports/library (an i32 policy)
with the compiler, checks every negative case is rejected without publishing output, then builds each
generated library with rustc and runs a real Rust consumer against it.
#>
param([ValidateSet('single-flight', 'hopac')][string]$Mode = 'single-flight')
$ErrorActionPreference = 'Stop'
. $PSScriptRoot/env.ps1
$dotnet = Resolve-SpiralDotnet
$compiler = Get-SpiralCompilerDll $Mode
$rustc = (Get-SpiralNativeTools).Rustc
if (-not $rustc) { throw 'rustc is required for the Rust export contracts.' }
$work = Join-Path (Get-SpiralCacheDir) ('rust-exports/' + [guid]::NewGuid().ToString('N'))
$fixtures = Join-Path $BundleRoot 'tests/rust-exports'
$library = '    $"RustLibrary()" : ()'

function Invoke-Cases([string]$Fixture, [System.Collections.Specialized.OrderedDictionary]$Cases) {
    $jobs = foreach ($case in $Cases.Keys) {
        $directory = Join-Path $work $case
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
        Copy-Item -LiteralPath (Join-Path $Fixture 'package.spiproj') -Destination $directory
        $inputPath = Join-Path $directory 'main.spi'
        [IO.File]::WriteAllText($inputPath, $Cases[$case][0])
        "$case`tRust`t$inputPath`t$(Join-Path $directory 'library.rs')`t20000"
    }
    $jobsPath = Join-Path $work "$(Split-Path $Fixture -Leaf).jobs.tsv"
    $resultsPath = Join-Path $work "$(Split-Path $Fixture -Leaf).results.tsv"
    $jobs | Set-Content -LiteralPath $jobsPath -Encoding utf8NoBOM
    & $dotnet $compiler --batch $jobsPath $resultsPath --timeout-ms 20000
    $rows = @(Import-Csv -LiteralPath $resultsPath -Delimiter "`t" -Header 'case','status','elapsed','detail')
    if ($rows.Count -ne $Cases.Count) { throw "Missing compiler results: $resultsPath" }
    foreach ($row in $rows) {
        $outputPath = Join-Path $work "$($row.case)/library.rs"
        $expected = $Cases[$row.case][1]
        if ($expected) {
            if ($row.status -ne 'error' -or -not $row.detail.Contains($expected) -or (Test-Path -LiteralPath $outputPath)) {
                throw "Expected $($row.case) rejection: $($row | ConvertTo-Json -Compress)"
            }
        } elseif ($row.status -ne 'ok' -or -not (Test-Path -LiteralPath $outputPath)) {
            throw "Rust library compilation failed: $($row | ConvertTo-Json -Compress)"
        }
    }
}

function Test-Consumer([string]$Case, [string]$Crate, [string]$Consumer) {
    $directory = Join-Path $work $Case
    $rlib = Join-Path $directory "lib$Crate.rlib"
    & $rustc --edition 2024 --crate-type rlib --crate-name $Crate (Join-Path $directory 'library.rs') -o $rlib
    if ($LASTEXITCODE -ne 0) { throw "Generated $Case library failed rustc." }
    $binary = Join-Path $directory $(if ($IsWindows) { 'consumer.exe' } else { 'consumer' })
    & $rustc --edition 2024 --test $Consumer --extern "$Crate=$rlib" -o $binary
    if ($LASTEXITCODE -ne 0) { throw "$Case consumer failed rustc." }
    & $binary
    if ($LASTEXITCODE -ne 0) { throw "$Case consumer behavior failed." }
}

$exports = Join-Path $fixtures 'exports'
$source = [IO.File]::ReadAllText((Join-Path $exports 'main.spi'))
Invoke-Cases $exports ([ordered]@{
    exports = @($source, '')
    no_library = @($source.Replace($library, ''), 'require exactly one RustLibrary')
    missing = @($source.Replace('\"scalar\")', '\"absent\")'), 'requires exactly one retained')
    wrong_signature = @($source.Replace('\"scalar\")', '\"echo\")'), 'requires exactly one retained')
    optimized_argument = @($source.Replace('\"echo\")', '\"unused\")'), 'requires exactly one retained')
    wrong_tuple = @($source.Replace('string * string * string * string * string', 'string * string * string * string * i32').Replace('value, "second", "", "fourth", "fifth"', 'value, "second", "", "fourth", 5i32'), 'tuple of exactly five strings')
    duplicate = @($source.Replace('\"export_echo\"', '\"export_scalar\"'), 'duplicate Rust export')
    duplicate_library = @($source.Replace($library, "$library`n$library"), 'exactly one RustLibrary')
    unsupported = @($source.Replace('RustExportStringUnary', 'RustExportUnknown'), 'unsupported Rust export marker')
})
Test-Consumer 'exports' 'spiral_exports' (Join-Path $exports 'consumer.rs')

$policy = Join-Path $fixtures 'library'
$source = [IO.File]::ReadAllText((Join-Path $policy 'main.spi'))
Invoke-Cases $policy ([ordered]@{
    library = @($source, '')
    library_missing = @($source.Replace('\"admitted\")', '\"missing\")'), 'requires exactly one retained')
    library_duplicate = @($source.Replace('    $"RustLibrary()"', '    $"RustExportI32Binary(\"export_admitted\",\"admitted\")" : ()' + "`n" + '    $"RustLibrary()"'), 'duplicate Rust export')
    library_unsupported = @($source.Replace('RustExportI32Binary', 'RustExportUnknown'), 'unsupported Rust export marker')
})
$harness = Join-Path $work 'library/harness.rs'
@'
extern crate spiral_library;
#[test]
fn exported_spiral_policy() {
    for value in -1..=4096 {
        assert_eq!(spiral_library::export_admitted(value, 0), i32::from((0..=4095).contains(&value)));
    }
    assert_eq!(spiral_library::export_admitted(493, 1), 0);
}
'@ | Set-Content -LiteralPath $harness -Encoding utf8NoBOM
Test-Consumer 'library' 'spiral_library' $harness

Write-Host "Rust export contracts passed: six ABIs and one policy library, eleven negative cases; $work"
