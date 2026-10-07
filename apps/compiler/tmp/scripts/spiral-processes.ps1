<#
Lists or stops this workspace's Spiral compiler processes, by what they are, never by remembered PIDs.

  pwsh scripts/spiral-processes.ps1                       # list (default)
  pwsh scripts/spiral-processes.ps1 -Stop -Kind daemon    # stop Kino's compile daemons (they restart on demand)
  pwsh scripts/spiral-processes.ps1 -Stop -IdleMin 10     # stop only those idle (no CPU) for the last sample and older than 10 min

Kinds (matched on the command line):
  daemon   Kino's compile daemon: erl `mix spiral.compiler_daemon`, its compiler bridge, the `--server` compiler
  worker   compiler processes: SpiralCompiler.dll `--batch` (suite workers) or `--backend` (single compiles)
  test     harness runs: tmp/scripts/test.ps1
-Stop stops each match with its whole process tree, after re-reading the process and checking that its start time
and command line are unchanged: a PID reused by an unrelated process is never touched (stopping PIDs copied from a
log killed two unrelated processes on 2026-10-07).
#>
param(
    [ValidateSet('all', 'daemon', 'worker', 'test')] [string]$Kind = 'all',
    [switch]$Stop,
    [int]$IdleMin = 0
)
$ErrorActionPreference = 'Stop'

$patterns = [ordered]@{
    daemon = @('spiral\.compiler_daemon', 'compiler_bridge', 'SpiralCompiler\.dll"?\s+--server\s')
    worker = @('SpiralCompiler\.dll"?\s+--batch\s', 'SpiralCompiler\.dll"?\s+--backend\s')
    test   = @('apps[\\/]compiler[\\/]tmp[\\/]scripts[\\/]test\.ps1')
}
function Get-Kind([string]$cmd) {
    foreach ($k in $patterns.Keys) { foreach ($p in $patterns[$k]) { if ($cmd -match $p) { return $k } } }
    $null
}
function Get-Matches {
    Get-CimInstance Win32_Process -Property ProcessId, ParentProcessId, Name, CommandLine, CreationDate, KernelModeTime, UserModeTime, WorkingSetSize |
        Where-Object { $_.ProcessId -ne $PID -and $_.CommandLine } | ForEach-Object {
            $k = Get-Kind $_.CommandLine
            if ($k -and ($Kind -eq 'all' -or $Kind -eq $k)) {
                [pscustomobject]@{ Pid = [int]$_.ProcessId; Kind = $k; Name = $_.Name; Started = $_.CreationDate
                    CpuS = ([double]$_.KernelModeTime + [double]$_.UserModeTime) / 1e7; WsMb = [int]($_.WorkingSetSize / 1MB); Cmd = $_.CommandLine }
            }
        }
}

$first = @(Get-Matches)
if ($IdleMin -gt 0) {
    # Idle: no CPU over a 3 s sample, and running for at least -IdleMin minutes.
    Start-Sleep -Seconds 3
    $second = @{}; foreach ($m in Get-Matches) { $second[$m.Pid] = $m }
    $first = @($first | Where-Object { $second.ContainsKey($_.Pid) -and ($second[$_.Pid].CpuS - $_.CpuS) -lt 0.05 -and $_.Started -lt (Get-Date).AddMinutes(-$IdleMin) })
}
if (-not $first.Count) { "no matching Spiral compiler processes (kind $Kind$(if ($IdleMin) { ", idle >= $IdleMin min" }))"; exit 0 }
foreach ($m in $first) {
    "{0,6} {1,-6} {2,-10} started {3:MM-dd HH:mm} cpu {4,7:N1}s ws {5,6} MB  {6}" -f $m.Pid, $m.Kind, $m.Name, $m.Started, $m.CpuS, $m.WsMb, ($m.Cmd -replace '\s+', ' ').Substring(0, [Math]::Min(110, ($m.Cmd -replace '\s+', ' ').Length))
}
if (-not $Stop) { exit 0 }

$stopped = 0
foreach ($m in $first) {
    # Re-read right before stopping: same start time and command line, or it is not the process we listed.
    $now = Get-CimInstance Win32_Process -Filter "ProcessId=$($m.Pid)" -Property CreationDate, CommandLine
    if (-not $now -or $now.CreationDate -ne $m.Started -or $now.CommandLine -ne $m.Cmd) { "skip $($m.Pid): gone or reused"; continue }
    try { (Get-Process -Id $m.Pid -ErrorAction Stop).Kill($true); $stopped++; "stopped $($m.Pid) $($m.Kind) ($($m.Name)) with its tree" }
    catch {
        # A process stuck in teardown (still listed, holding handles such as test.lock, but no longer openable by
        # Get-Process) only goes with taskkill. Identity was re-verified just above.
        $tk = taskkill /F /T /PID $m.Pid 2>&1 | Out-String
        if ($LASTEXITCODE -eq 0) { $stopped++; "stopped $($m.Pid) $($m.Kind) ($($m.Name)) with taskkill" }
        else { "skip $($m.Pid): $($_.Exception.Message); taskkill: $($tk.Trim())" }
    }
}
"stopped $stopped of $($first.Count)"
