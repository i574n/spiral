param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../scripts/core.ps1
. ../../lib/spiral/lib.ps1


$projectName = "lisp"

$targetDir = GetTargetDir $projectName

function Build-Sample([string] $Sample) {
    $dir = "$targetDir/$Sample"
    Remove-Item $dir -Recurse -Force -ErrorAction Ignore
    New-Item -ItemType Directory -Force $dir | Out-Null
    { python spl2spi.py "$Sample.spl" "$dir/main.spi" } | Invoke-Block | Out-Host
    @('packages:', '    |core-', 'modules:', '    main') | Set-Content "$dir/package.spiproj"
    BuildSpiral "$dir/main.spi" "$dir/main.rs" "apps/lisp/$Sample"
}

foreach ($sample in 'membership', 'membership_short') {
    if (!(Build-Sample $sample)) {
        throw "RUST-FAILED apps/lisp / $sample.spl / compile"
    }
    $dir = "$targetDir/$sample"
    { rustc +nightly-2025-11-01 -O --edition 2021 "$dir/main.rs" -o "$dir/main$(_exe)" } | Invoke-Block
    & "$dir/main$(_exe)"
    if ($LASTEXITCODE -ne 0) {
        throw "RUST-FAILED apps/lisp / $sample.spl / run exit code $LASTEXITCODE, expected 0"
    }
    Write-Output "RUST-OK apps/lisp / $sample.spl"
}

if (Build-Sample 'membership_wrong') {
    throw "RUST-FAILED apps/lisp / membership_wrong.spl compiled, expected a type error"
}
Write-Output "RUST-OK apps/lisp / membership_wrong.spl rejected"

Write-Output "spiral/apps/lisp/build.ps1 / `$targetDir = $targetDir / `$projectName: $projectName / `$env:CI:'$env:CI'"

if ($env:CI) {
    Remove-Item $targetDir -Recurse -Force -ErrorAction Ignore
}
