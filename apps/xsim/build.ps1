param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../scripts/core.ps1

$toolchain = & {
    . ../compiler/tmp/scripts/env.ps1
    [pscustomobject]@{ PackageDir = Get-SpiralPackageDir; Dotnet = Resolve-SpiralDotnet; Dll = Get-SpiralCompilerDll 'single-flight' }
}
$env:SPIRAL_COMPILER_PACKAGE_DIR = $toolchain.PackageDir
$env:SPIRAL_DOTNET = $toolchain.Dotnet
$env:SPIRAL_COMPILER_DLL = $toolchain.Dll
$env:SPIRAL_WORKSPACE_ROOT = (Resolve-Path ../compiler/tmp).Path
$scoopErlang = Join-Path $HOME 'scoop/apps/erlang/current/bin'
if (Test-Path $scoopErlang) { $env:PATH = "$scoopErlang$([IO.Path]::PathSeparator)$env:PATH" }

{ mix deps.get } | Invoke-Block
{ mix test } | Invoke-Block

$corpus = Get-ChildItem ../../lib/spiral -Recurse -Filter *.spi |
    Where-Object { $_.FullName -notmatch '[\\/](target|bench)[\\/]' -and (Select-String -LiteralPath $_.FullName -Pattern '^test ' -Quiet) } |
    ForEach-Object { $_.FullName }
$list = Join-Path ([IO.Path]::GetTempPath()) "xsim-corpus-$PID.txt"
[IO.File]::WriteAllText($list, ($corpus -join "`n") + "`n")
{ mix xsim.run --spi-file $list --schedules 2 --users 3 --edits 3 --breaking 1 --churn 2 --frames --duplicates 0.15 --personas lurker=2,fickle=3,editor=2,breaker=2 } | Invoke-Block
Remove-Item $list -ErrorAction Ignore

if (!$fast) {
    { mix xsim.run --spi ../../lib/spiral/math.spi --cells 3 --users 2 --edits 0 --schedules 1 --executor kino --max-concurrency 2 } | Invoke-Block
    { pwsh ../compiler/tmp/scripts/spiral-processes.ps1 -Kind daemon -Stop } | Invoke-Block -OnError Continue
}
