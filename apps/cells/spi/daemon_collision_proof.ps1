param([string] $SpiFile = 'guid.spi')
$ErrorActionPreference = 'Stop'
$here = $PSScriptRoot
$cells = 'C:\home\git\spiral\apps\cells'
$elixir = Join-Path $HOME 'scoop\apps\elixir\current\bin\elixir.bat'
$ebin = Join-Path $env:LOCALAPPDATA 'spiral-bin\mix-builds\lib-gate\lib\*\ebin'
$rel = Join-Path $env:LOCALAPPDATA 'spiral-bin\bin\single-flight\SpiralCompiler\Release\net11.0'
$scratch = Join-Path $env:TEMP 'cells-collision'
Remove-Item Env:SPIRAL_COMPILER_DLL, Env:SPIRAL_CELLS_COMPILER_PORT -ErrorAction SilentlyContinue
if (Test-Path $scratch) { Remove-Item $scratch -Recurse -Force }
New-Item -ItemType Directory -Force $scratch | Out-Null
Copy-Item $rel (Join-Path $scratch 'net11.0') -Recurse
$copy = Join-Path $scratch 'net11.0\SpiralCompiler.dll'
Push-Location $cells
try { $line = & $elixir -pa $ebin (Join-Path $here 'daemon_collision.exs') (Join-Path $rel 'SpiralCompiler.dll') $copy 'c:/home/git/spiral/apps/cells' } finally { Pop-Location }
"collide: $line"
if ($line -notmatch 'live_port=(\d+) copy_mtime_offset=(\d+) copy_port=(\d+) next_slot=(\d+)' -or $Matches[1] -ne $Matches[3]) { throw 'no forced collision' }
$livePort = [int] $Matches[1]; $nextSlot = [int] $Matches[4]
if (Get-NetTCPConnection -State Listen -LocalPort $livePort -ErrorAction SilentlyContinue) { throw "slot $livePort is already in use: run when it is free" }
$env:SPIRAL_CELLS_DAEMON_OWNER = 'main collide-proof'
$daemonLog = Join-Path $scratch 'live-daemon.log'
$null = Start-Process -FilePath $elixir -ArgumentList '-pa', "`"$ebin`"", '-e', 'Spiral.Cells.CompilerDaemon.serve_app()' -WorkingDirectory $cells -WindowStyle Hidden -PassThru -RedirectStandardOutput $daemonLog -RedirectStandardError (Join-Path $scratch 'live-daemon.err')
$deadline = (Get-Date).AddSeconds(90)
while ((Get-Date) -lt $deadline -and -not (Get-NetTCPConnection -State Listen -LocalPort $livePort -ErrorAction SilentlyContinue)) { Start-Sleep 2 }
$heldPid = (Get-NetTCPConnection -State Listen -LocalPort $livePort -ErrorAction SilentlyContinue | Select-Object -First 1).OwningProcess
if (-not $heldPid) { throw "held daemon did not listen on $livePort" }
"held live-build daemon pid=$heldPid on $livePort"
$before = @(Get-Content $daemonLog).Count
try {
    $env:SPIRAL_COMPILER_DLL = $copy
    $gate = pwsh -NoProfile -File (Join-Path $cells 'spi\lib_gate.ps1') -File $SpiFile 2>&1 | Select-String 'tests: passed' | Select-Object -Last 1
    $gateExit = $LASTEXITCODE
} finally { Remove-Item Env:SPIRAL_COMPILER_DLL -ErrorAction SilentlyContinue }
$after = @(Get-Content $daemonLog | Select-Object -Skip $before | Where-Object { $_ -match ' compile ' })
$stillHeld = (Get-NetTCPConnection -State Listen -LocalPort $livePort -ErrorAction SilentlyContinue | Select-Object -First 1).OwningProcess
$copyItem = Get-Item $copy
$copyTag = "$([DateTimeOffset]::new($copyItem.LastWriteTimeUtc).ToUnixTimeSeconds())-$($copyItem.Length)"
$copyPortFile = Join-Path $env:LOCALAPPDATA "spiral-bin\cells-port-215003CF759F40A9-$copyTag.txt"
$copySlot = if (Test-Path $copyPortFile) { (Get-Content $copyPortFile -Raw).Trim() } else { 'none' }
"copy build's warm-port file names slot $copySlot (expected $nextSlot)"
"copy gate: $gate (exit $gateExit)"
"held daemon compiles during the copy run: $($after.Count)"
"held daemon still pid $heldPid on ${livePort}: $($stillHeld -eq $heldPid)"
try {
    $c = [Net.Sockets.TcpClient]::new('127.0.0.1', $livePort); $w = [IO.StreamWriter]::new($c.GetStream()); $w.NewLine = "`n"; $w.WriteLine('retire'); $w.Flush(); $c.Dispose()
} catch { "retire failed: $_" }
if ($gateExit -eq 0 -and $after.Count -eq 0 -and $stillHeld -eq $heldPid -and $copySlot -eq "$nextSlot") { 'VERDICT: PROVEN (another build ran on its own slot; the live build''s daemon compiled nothing for it and was not replaced)' }
else { 'VERDICT: FAILED' }
