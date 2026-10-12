param(
    [ValidateSet('all', 'daemon', 'worker', 'test')] [string]$Kind = 'all',
    [switch]$Stop,
    [int]$IdleMin = 0
)
$ErrorActionPreference = 'Stop'

$patterns = [ordered]@{
    daemon = @('spiral\.compiler_daemon', 'compiler_bridge', 'SpiralCompiler\.dll"?\s+--server\s')
    worker = @('SpiralCompiler\.dll"?\s+--batch\s', 'SpiralCompiler\.dll"?\s+--backend\s')
    test   = @('(^|[\\/\s"])scripts[\\/]test\.ps1')
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
    $now = Get-CimInstance Win32_Process -Filter "ProcessId=$($m.Pid)" -Property CreationDate, CommandLine
    if (-not $now -or $now.CreationDate -ne $m.Started -or $now.CommandLine -ne $m.Cmd) { "skip $($m.Pid): gone or reused"; continue }
    try { (Get-Process -Id $m.Pid -ErrorAction Stop).Kill($true); $stopped++; "stopped $($m.Pid) $($m.Kind) ($($m.Name)) with its tree" }
    catch {
        $tk = taskkill /F /T /PID $m.Pid 2>&1 | Out-String
        if ($LASTEXITCODE -eq 0) { $stopped++; "stopped $($m.Pid) $($m.Kind) ($($m.Name)) with taskkill" }
        else { "skip $($m.Pid): $($_.Exception.Message); taskkill: $($tk.Trim())" }
    }
}
"stopped $stopped of $($first.Count)"
