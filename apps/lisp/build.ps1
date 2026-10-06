param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../deps/polyglot/scripts/core.ps1
. ../../deps/polyglot/deps/spiral/lib/spiral/lib.ps1


$projectName = "lisp"

$targetDir = GetTargetDir $projectName

# A Lisp surface for Spiral: spl2spi.py reads a .spl file (S-expressions) and writes ordinary Spiral source, which the
# Spiral compiler's own Rust backend compiles. Each sample is transpiled into its own package under the target dir
# (main.spi plus a package file; |core- resolves through the compiler's package dir) and compiled there.
# membership.spl (a GADT: De Bruijn membership in a typed context) and membership_short.spl (the same proof with one
# top-level form per 280-character message) must compile, build with rustc and exit 0 (their `main` checks the proved
# slot). membership_wrong.spl differs from membership.spl in one proof only and must be rejected by the compiler.
function Build-Sample([string] $Sample) {
    $dir = "$targetDir/$Sample"
    Remove-Item $dir -Recurse -Force -ErrorAction Ignore
    New-Item -ItemType Directory -Force $dir | Out-Null
    { python spl2spi.py "$Sample.spl" "$dir/main.spi" } | Invoke-Block | Out-Host
    @('packages:', '    |core-', 'modules:', '    main') | Set-Content "$dir/package.spiproj"
    BuildNativeRust "$dir/main.spi" "$dir/main.rs" "apps/lisp/$Sample"
}

foreach ($sample in 'membership', 'membership_short') {
    if (!(Build-Sample $sample)) {
        throw "NATIVE-RUST-FAILED apps/lisp / $sample.spl / compile"
    }
    $dir = "$targetDir/$sample"
    { rustc +nightly-2025-11-01 -O --edition 2021 "$dir/main.rs" -o "$dir/main$(_exe)" } | Invoke-Block
    & "$dir/main$(_exe)"
    if ($LASTEXITCODE -ne 0) {
        throw "NATIVE-RUST-FAILED apps/lisp / $sample.spl / run exit code $LASTEXITCODE, expected 0"
    }
    Write-Output "NATIVE-RUST-OK apps/lisp / $sample.spl"
}

if (Build-Sample 'membership_wrong') {
    throw "NATIVE-RUST-FAILED apps/lisp / membership_wrong.spl compiled, expected a type error"
}
Write-Output "NATIVE-RUST-OK apps/lisp / membership_wrong.spl rejected"

Write-Output "spiral/apps/lisp/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"

if ($env:CI) {
    Remove-Item $targetDir -Recurse -Force -ErrorAction Ignore
}
