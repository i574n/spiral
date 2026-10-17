param(
    [Parameter(Mandatory)][string]$Label,
    [string[]]$Tests = @(),
    [string]$Dll,
    [int]$Port = 13995,
    [int]$TimeoutMin = 60
)
$ErrorActionPreference = 'Continue'
if (Get-Process otclient_gl_x64, canary -ErrorAction Ignore) { "deferred: a live Tibia client or server is running ($(Get-Date -Format HH:mm:ss))"; return }
$kino = Split-Path $PSScriptRoot
$repo = Split-Path (Split-Path $kino)
$state = Join-Path ($env:LOCALAPPDATA ?? $HOME) 'spiral-bin'
$env:PATH = "$env:USERPROFILE\scoop\apps\erlang\current\bin;$env:USERPROFILE\scoop\apps\elixir\current\bin;$env:PATH"
$env:MIX_BUILD_PATH = Join-Path $state "kino-builds/$Label"
$env:SPIRAL_DOTNET = Join-Path $state 'toolchains/dotnet/dotnet.exe'
$env:SPIRAL_WORKSPACE_ROOT = Join-Path $repo 'apps/compiler/tmp'
$env:SPIRAL_COMPILER_PACKAGE_DIR = Join-Path $repo 'deps/The-Spiral-Language/VS Code Plugin'
$env:SPIRAL_KINO_DAEMON_POOL = '1'
$env:SPIRAL_KINO_MEMO = '0'
$env:SPIRAL_KINO_COMPILER_PORT = "$Port"
if ($Dll) { $env:SPIRAL_COMPILER_DLL = $Dll }
Remove-Item Env:SPIRAL_KINO_DEFAULT_TARGET, Env:SPIRAL_KINO_FORCE_TARGETS -ErrorAction Ignore
$logs = Join-Path $state 'kino-suite'
New-Item -ItemType Directory -Force $logs | Out-Null
$log = Join-Path $logs "$Label.log"
$Tests = @($Tests | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
Push-Location $kino
& mix.bat deps.get 2>&1 | Select-Object -Last 1
Pop-Location
$suite = Start-Process mix.bat -ArgumentList (@('test', '--slowest', '25') + $Tests) -WorkingDirectory $kino -NoNewWindow -PassThru -RedirectStandardOutput $log -RedirectStandardError "$log.err"
if (-not $suite.WaitForExit($TimeoutMin * 60000)) { "TIMEOUT $log"; taskkill /T /F /PID $suite.Id | Out-Null }
try {
    $client = [Net.Sockets.TcpClient]::new()
    if ($client.ConnectAsync('127.0.0.1', $Port).Wait(500)) { $stream = $client.GetStream(); $bytes = [Text.Encoding]::ASCII.GetBytes("retire`n"); $stream.Write($bytes, 0, $bytes.Length) }
    $client.Dispose()
} catch { }
. (Join-Path $PSScriptRoot '../../compiler/tmp/scripts/heavy.ps1')
$suiteOutcome = if ($suite.ExitCode) { "exit $($suite.ExitCode)" } else { 'ok' }
try { Write-RunLedger 'kino-suite' "kino suite $Label" ([scriptblock]::Create("'" + ("run_suite.ps1 -Label $Label $($Tests -join ' ')" -replace "'", "''") + "'")) $suite.StartTime $suite.StartTime '-' $suiteOutcome 0 } catch { Write-Warning "run ledger: $($_.Exception.Message)" }
"== $Label exit $($suite.ExitCode) (log $log)"
Select-String -Path $log -Pattern '^\s+\d+\) test|tests, \d+ failure' | ForEach-Object Line
$global:LASTEXITCODE = $suite.ExitCode
