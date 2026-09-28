<#
.SYNOPSIS
Builds the spiral-split Rust workspace into the cache directory.

.EXAMPLE
pwsh scripts/build-splitter.ps1            # release build of the CLI
pwsh scripts/build-splitter.ps1 -Test      # cargo test for the whole workspace (every crate, even after a failure)
#>
param([switch]$Test)
. $PSScriptRoot/env.ps1

$env:CARGO_TARGET_DIR = Join-Path (Get-SpiralCacheDir) 'splitter-target'
Push-Location (Join-Path $BundleRoot 'splitter')
try {
    if ($Test) { cargo test --workspace --locked --no-fail-fast }
    else { cargo build --release --locked -p spiral-split-cli }
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
}
finally { Pop-Location }
$exe = Join-Path $env:CARGO_TARGET_DIR ("release/spiral-split" + $(if ($IsWindows) { '.exe' } else { '' }))
if (-not $Test) { Write-Host "spiral-split -> $exe" }
