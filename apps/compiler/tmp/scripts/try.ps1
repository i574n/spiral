param(
    [Parameter(Mandatory)][string]$Source,
    [string[]]$Modules = @(),
    [string]$Name = [IO.Path]::GetFileNameWithoutExtension($Source),
    [ValidateSet('C', 'Zig', 'Lua', 'Rust')][string]$Backend = 'C',
    [int]$TimeoutSec = 60
)
$ErrorActionPreference = 'Stop'
$Modules = @($Modules | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
. $PSScriptRoot/env.ps1
$run = Join-Path (Get-SpiralCacheDir) "runs/try/$Name"
New-Item -ItemType Directory -Force $run | Out-Null
Get-ChildItem $run -File | Remove-Item -Force
$moduleLines = foreach ($module in $Modules) {
    $file = Get-Item -LiteralPath $module
    Copy-Item -LiteralPath $file.FullName (Join-Path $run $file.Name)
    if ($file.Extension -eq '.spir') { "    $($file.BaseName)*" } else { "    $($file.BaseName)" }
}
[IO.File]::WriteAllText((Join-Path $run 'package.spiproj'), "packages:`n    |core-`nmodules:`n" + ((@($moduleLines) + @('    main')) -join "`n") + "`n")
Copy-Item -LiteralPath $Source (Join-Path $run 'main.spi')
$extension = @{ C = 'c'; Zig = 'zig'; Lua = 'lua'; Rust = 'rs' }[$Backend]
$output = Join-Path $run "main.$extension"
$repo = (Resolve-Path (Join-Path $PSScriptRoot '../../../..')).Path
$env:SPIRAL_WORKSPACE_ROOT = Join-Path $repo 'apps/compiler/tmp'
$env:SPIRAL_COMPILER_PACKAGE_DIR = Join-Path $repo 'deps/The-Spiral-Language/VS Code Plugin'
$dll = if ($env:SPIRAL_COMPILER_DLL) { $env:SPIRAL_COMPILER_DLL } else { Join-Path $env:LOCALAPPDATA 'spiral-bin/bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll' }
$info = [Diagnostics.ProcessStartInfo]::new((Join-Path $env:LOCALAPPDATA 'spiral-bin/toolchains/dotnet/dotnet.exe'))
foreach ($argument in @($dll, '--backend', $Backend, (Join-Path $run 'main.spi'), $output)) { $info.ArgumentList.Add($argument) }
$info.RedirectStandardOutput = $true
$info.RedirectStandardError = $true
$info.UseShellExecute = $false
$compiler = [Diagnostics.Process]::Start($info)
$stdout = $compiler.StandardOutput.ReadToEndAsync()
$stderr = $compiler.StandardError.ReadToEndAsync()
if (-not $compiler.WaitForExit($TimeoutSec * 1000)) {
    $compiler.Kill($true)
    "$Name : TIMEOUT after $TimeoutSec s (compiler killed)"
    return
}
$messages = (($stdout.Result + $stderr.Result) -split "`n" | Where-Object { $_ -match 'ETY|rror|Failed|Got:|Expected:' } | Select-Object -First 4) -join ' / '
$result = "$Name : compile exit $($compiler.ExitCode)"
if ($compiler.ExitCode -eq 0) {
    $exe = Join-Path $run 'main.exe'
    switch ($Backend) {
        'C' { gcc -std=c11 -O2 -fwrapv -w -o $exe $output -lm; & $exe }
        'Zig' { zig build-exe $output -O ReleaseFast -fno-emit-implib "-femit-bin=$exe" 2>&1 | Out-Null; & $exe }
        'Lua' { lua (Join-Path $env:SPIRAL_WORKSPACE_ROOT 'tests/native-shims/run_main.lua') $output }
        'Rust' { $pin = if ((Get-Command rustc -ErrorAction SilentlyContinue).Source -match '[\\/]\.cargo[\\/]bin[\\/]') { @('+nightly-2026-10-18') } else { @() }; rustc $pin --edition 2024 -O -A warnings -o $exe $output; & $exe }
    }
    $result += ", run exit $LASTEXITCODE"
}
"$result :: $($messages.Trim())"
