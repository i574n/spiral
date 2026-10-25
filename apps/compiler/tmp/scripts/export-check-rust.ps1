param([string] $Dll, [string[]] $Case)
$ErrorActionPreference = 'Continue'
$pin = if ((Get-Command rustc -ErrorAction SilentlyContinue).Source -match '[\\/]\.cargo[\\/]bin[\\/]') { @('+nightly-2026-10-18') } else { @() }
. (Join-Path $PSScriptRoot 'env.ps1')
$dotnet = Resolve-SpiralDotnet
$compiler = if ($Dll) { $Dll } else { Get-SpiralCompilerDll single-flight }
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
$root = Join-Path $PSScriptRoot 'export-check-rust'
$failed = 0
foreach ($dir in Get-ChildItem $root -Directory | Where-Object { -not $Case -or $Case -contains $_.Name }) {
    $expected = [int](Get-Content (Join-Path $dir.FullName 'expected-exit.txt') -TotalCount 1)
    $out = Join-Path (Get-SpiralCacheDir) "runs/export-check-rust/$($dir.Name)"
    if (Test-Path $out) { Remove-Item $out -Recurse -Force }
    New-Item -ItemType Directory -Force $out | Out-Null
    & $dotnet $compiler --backend Rust (Join-Path $dir.FullName 'main.spi') "$out\xc.rs" 2>&1 | Select-Object -Last 1 | Out-Null
    Push-Location $out
    try {
        $errors = @(rustc $pin --edition 2021 --crate-type rlib --crate-name xc xc.rs -o libxc.rlib 2>&1 | Select-String 'error' | Select-Object -First 3)
        Copy-Item (Join-Path $dir.FullName 'consumer.rs') consumer.rs
        $errors += @(rustc $pin --edition 2021 consumer.rs --extern xc=libxc.rlib -L . -o consumer.exe 2>&1 | Select-String 'error' | Select-Object -First 3)
        $code = if (Test-Path consumer.exe) { & .\consumer.exe; $LASTEXITCODE } else { $null }
    }
    finally { Pop-Location }
    $ok = $code -eq $expected
    if (-not $ok) { $failed++ }
    '{0,-22} {1}  consumer exit {2} (expected {3}){4}' -f $dir.Name, $(if ($ok) { 'ok  ' } else { 'FAIL' }), $(if ($null -eq $code) { 'none' } else { $code }), $expected, $(if ($errors) { '  ' + (($errors | ForEach-Object { "$_".Trim() }) -join ' / ') } else { '' })
}
"export-check-rust: $failed failed"
exit $failed
