<#
.SYNOPSIS
Contracts for Rust library output: `!!!!Export(name, f)` makes the program a library crate with one
`pub fn name` per export (strings in as `&str`, out as `Rc<str>`).

.DESCRIPTION
Compiles tests/rust-exports/exports (six signatures) and tests/rust-exports/library (an i32 policy)
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

function New-ExportCase([string]$Text, [string[]]$Expected) {
    # A bare @(source, @(phrases)) flattens, so the fallback phrase would be a third element.
    $pair = [object[]]::new(2)
    $pair[0] = $Text
    $pair[1] = [string[]]$Expected
    ,$pair
}

function Invoke-Cases([string]$Fixture, [System.Collections.Specialized.OrderedDictionary]$Cases) {
    # One compiler process per case. A second BuildFile in the same process can
    # sit until the batch timeout on Linux, which used to leave the results file short.
    foreach ($case in $Cases.Keys) {
        $directory = Join-Path $work $case
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
        Copy-Item -LiteralPath (Join-Path $Fixture 'package.spiproj') -Destination $directory
        $inputPath = Join-Path $directory 'main.spi'
        $outputPath = Join-Path $directory 'library.rs'
        [IO.File]::WriteAllText($inputPath, $Cases[$case][0])
        if (Test-Path -LiteralPath $outputPath) { Remove-Item -LiteralPath $outputPath -Force }
        $log = & $dotnet $compiler --backend Rust $inputPath $outputPath 2>&1 | Out-String
        $code = $LASTEXITCODE
        $expected = @($Cases[$case][1] | Where-Object { $_ })
        $published = Test-Path -LiteralPath $outputPath
        if ($expected.Count) {
            $matched = $false
            foreach ($part in $expected) { if ($log.Contains([string]$part)) { $matched = $true } }
            if ($code -eq 0 -or -not $matched -or $published) {
                $need = $expected -join ' | '
                throw "Expected $case rejection (exit $code, matched=$matched, published=$published, need='$need'): $log"
            }
        } elseif ($code -ne 0 -or -not $published) {
            throw "Rust library compilation failed for ${case} (exit $code, published=$published): $log"
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
$captured = '    inl ~k = 1i32' + "`n" + '    export "export_captured" ((fun (a, b) => choose a k) : i32 * i32 -> i32)' + "`n" + '    0i32'
Invoke-Cases $exports ([ordered]@{
    exports = @($source, '')
    missing = (New-ExportCase ($source.Replace('=> choose first second', '=> absent first second')) @('Unbound variable: absent.', 'has a type error somewhere in its path'))
    wrong_signature = (New-ExportCase ($source.Replace('(fun value => opaque value) : string -> u64', '(fun value => opaque value) : i32 -> u64')) @('Expected: i32', 'has a type error somewhere in its path'))
    wrong_tuple = (New-ExportCase ($source.Replace(': string -> string * string * string * string * string)', ': string -> string * string * string * string * i32)')) @('Expected: string * string * string * string * i32', 'has a type error somewhere in its path'))
    captured = @($source.Replace('    0i32', $captured), 'runtime free variables')
    duplicate = @($source.Replace('"export_echo"', '"export_scalar"'), 'Duplicate export: export_scalar')
})
Test-Consumer 'exports' 'spiral_exports' (Join-Path $exports 'consumer.rs')

$policy = Join-Path $fixtures 'library'
$source = [IO.File]::ReadAllText((Join-Path $policy 'main.spi'))
Invoke-Cases $policy ([ordered]@{
    library = @($source, '')
    library_duplicate = @($source.Replace('    0i32', '    !!!!Export("export_admitted", ((fun (value, reserved) => admitted value reserved) : i32 * i32 -> i32))' + "`n" + '    0i32'), 'Duplicate export: export_admitted')
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

Write-Host "Rust export contracts passed: six signatures and one policy library, six negative cases; $work"
