param([int] $SampleSeconds = 10, [int] $SilentMinutes = 60, [int] $RogueMinutes = 30, [double] $RogueCores = 0.8)
$ErrorActionPreference = 'Continue'
$eoie = Join-Path $PSScriptRoot '../../../../../eoie/eoie.exe'
if (-not (Test-Path $eoie)) { $eoie = 'eoie' }
$stateDir = Join-Path $env:LOCALAPPDATA 'machine-watch'
New-Item -ItemType Directory -Force $stateDir | Out-Null
$statePath = Join-Path $stateDir 'last.json'
$tools = @('dotnet', 'rustc', 'cargo', 'erl', 'beam.smp', 'pwsh', 'powershell', 'node', 'bun', 'gcc', 'cc1', 'cc1plus', 'ld', 'zig', 'lean', 'java', 'swiftc', 'swift-frontend', 'python', 'kotlinc', 'gleam', 'wasmtime', 'link', 'clang', 'mix', 'escript', 'make', 'git')
$now = Get-Date

$before = @{}
foreach ($p in Get-Process) { try { $before[$p.Id] = $p.TotalProcessorTime.TotalSeconds } catch {} }
Start-Sleep -Seconds $SampleSeconds
$elapsed = ((Get-Date) - $now).TotalSeconds
$processes = @{}
foreach ($c in Get-CimInstance Win32_Process) { $processes[[int]$c.ProcessId] = $c }

function Get-Owner([int] $id) {
    $at = $processes[$id]
    $hops = 0
    while ($at -and $hops -lt 40) {
        if ($at.Name -eq 'claude.exe') { return "claude:$($at.ProcessId)" }
        if ($at.CommandLine -and $at.CommandLine -match 'job supervise (job-\S+)') { return "eoie:$($Matches[1])" }
        $parent = [int]$at.ParentProcessId
        if (-not $processes.ContainsKey($parent)) {
            if ($at.Name -eq 'erl.exe' -and $at.CommandLine -match '(?i)spiral\.notebook|spiral-cells|cells-build') { return "cells-vm:$($at.ProcessId)" }
            return 'orphan'
        }
        $at = $processes[$parent]
        $hops++
    }
    'orphan'
}

function Get-Repo([string] $commandLine) {
    if (-not $commandLine) { return '' }
    $m = [regex]::Match($commandLine, '(?i)c:[\\/]home[\\/]git[\\/]([^\\/" ]+)')
    if ($m.Success) { $m.Groups[1].Value } else { '' }
}

function Get-AncestorRepo([int] $id) {
    $at = $processes[$id]
    $hops = 0
    while ($at -and $hops -lt 40) {
        $repo = Get-Repo $at.CommandLine
        if ($repo) { return $repo }
        $at = $processes[[int]$at.ParentProcessId]
        $hops++
    }
    '?'
}

$busy = foreach ($p in Get-Process) {
    try {
        if (-not $before.ContainsKey($p.Id)) { continue }
        $cores = ($p.TotalProcessorTime.TotalSeconds - $before[$p.Id]) / $elapsed
        if ($cores -lt 0.1) { continue }
        $c = $processes[$p.Id]
        $age = if ($p.StartTime) { ($now - $p.StartTime).TotalMinutes } else { 0 }
        [pscustomobject]@{
            Id = $p.Id; Name = $p.ProcessName; Cores = [math]::Round($cores, 2)
            AgeMin = [int]$age; CpuMin = [int]($p.TotalProcessorTime.TotalMinutes)
            Owner = if ($tools -contains $p.ProcessName) { Get-Owner $p.Id } else { '-' }
            Repo = if ($tools -contains $p.ProcessName) { Get-AncestorRepo $p.Id } else { '' }
        }
    } catch {}
}
$total = ($busy | Measure-Object Cores -Sum).Sum
$free = [int]((Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory / 1kb)
"== machine $($now.ToString('yyyy-MM-dd HH:mm')): $([math]::Round($total, 1)) of $([Environment]::ProcessorCount) cores busy over $SampleSeconds s, $free MB free"
$busy | Sort-Object Cores -Descending | Select-Object -First 12 | Format-Table Id, Name, Cores, AgeMin, CpuMin, Owner, Repo -AutoSize | Out-String -Width 160

$rogues = @($busy | Where-Object { $tools -contains $_.Name -and $_.Cores -ge $RogueCores -and (($_.Owner -eq 'orphan' -and $_.AgeMin -ge $RogueMinutes) -or ($_.AgeMin -ge 180 -and $_.CpuMin -ge 0.8 * $_.AgeMin)) })
"== rogue candidates (tool process, >= $RogueCores cores now, orphan for >= $RogueMinutes min or busy >= 80% of 3 h+): $($rogues.Count)"
$rogues | ForEach-Object { "  pid $($_.Id) $($_.Name) $($_.Cores) cores, age $($_.AgeMin) min, cpu $($_.CpuMin) min, owner $($_.Owner), repo $($_.Repo): $((($processes[$_.Id].CommandLine) -replace '\s+', ' ').Substring(0, [math]::Min(180, (($processes[$_.Id].CommandLine) -replace '\s+', ' ').Length)))" }

$hogs = @(Get-Process | Where-Object { $_.PrivateMemorySize64 -ge 8gb })
"== memory hogs (>= 8 GB private): $($hogs.Count)"
$hogs | ForEach-Object { "  pid $($_.Id) $($_.ProcessName) $([int]($_.PrivateMemorySize64 / 1mb)) MB private, owner $(Get-Owner $_.Id), repo $(Get-AncestorRepo $_.Id), started $($_.StartTime.ToString('HH:mm'))" }

$jobs = @{}
foreach ($line in @(& $eoie job list 300 2>$null)) {
    $m = [regex]::Match($line, 'id=(\S+) state=(\S+) exit=\S+ elapsed_ms=(\d+) stdout_bytes=(\d+) stderr_bytes=(\d+).*label=(\S+)')
    if ($m.Success) { $jobs[$m.Groups[1].Value] = [pscustomobject]@{ State = $m.Groups[2].Value; ElapsedMin = [int]([long]$m.Groups[3].Value / 60000); Out = [long]$m.Groups[4].Value + [long]$m.Groups[5].Value; Label = $m.Groups[6].Value } }
}
$last = if (Test-Path $statePath) { Get-Content $statePath -Raw | ConvertFrom-Json -AsHashtable } else { @{} }
$snapshot = @{ at = $now.ToString('o'); jobs = @{} }
$windowLines = @(& $eoie window list 2>$null | Where-Object { $_ -match '^win-' })
$liveBlock = @($windowLines | Where-Object { $_ -match ' live-gui\s+held ' }).Count -gt 0
$cellsCores = [math]::Round((@($busy | Where-Object Owner -like 'cells-vm:*') | Measure-Object Cores -Sum).Sum, 2)
"== eoie jobs running: $(@($jobs.Values | Where-Object State -eq 'running').Count), queued: $(@($jobs.Values | Where-Object State -eq 'queued').Count)"
foreach ($id in $jobs.Keys) {
    $j = $jobs[$id]
    if ($j.State -ne 'running') { continue }
    $seen = if ($last.jobs -and $last.jobs.ContainsKey($id)) { $last.jobs[$id] } else { $null }
    $quietSince = if ($seen -and [long]$seen.out -eq $j.Out) { [DateTime]::Parse($seen.quiet_since) } else { $now }
    $snapshot.jobs[$id] = @{ out = $j.Out; quiet_since = $quietSince.ToString('o') }
    $quiet = [int]($now - $quietSince).TotalMinutes
    $treeCores = [math]::Round((@($busy | Where-Object Owner -eq "eoie:$id") | Measure-Object Cores -Sum).Sum, 2)
    $lastLine = if ($quiet -ge $SilentMinutes -and $treeCores -lt 0.1 -and -not $liveBlock) { @(& $eoie job tail $id 3 2>$null | Where-Object { $_ -and $_ -notmatch '^(eoie job tail|--- )' }) | Select-Object -Last 1 } else { '' }
    $flag = if ($quiet -lt $SilentMinutes) { '' } elseif ($treeCores -ge 0.1) { "  (quiet output, tree busy $treeCores cores: buffered)" } elseif ($liveBlock) { "  (quiet during a live block: waiting for a window is expected)" } elseif ($lastLine -match '(?i)waiting for') { "  (waiting by design, last line: $($lastLine.Trim()))" } elseif ($cellsCores -ge 0.5) { "  (quiet, tree idle, but detached Cells VMs use $cellsCores cores: likely this job's compiler daemon work)" } else { "  <- SILENT $quiet min, tree idle now: check the job's own progress files (Cells work can run in a shared compiler daemon outside the tree)" }
    "  $($j.Label) running $($j.ElapsedMin) min, output $($j.Out) bytes, unchanged $quiet min, tree $treeCores cores$flag"
}
$snapshot | ConvertTo-Json -Depth 5 | Set-Content $statePath

$gateLog = Join-Path $HOME '.claude\autonomous\gate.log'
if (Test-Path $gateLog) {
    $hourAgo = $now.AddHours(-1)
    $recent = @(Get-Content $gateLog -Tail 4000 | Where-Object { $_ -match '^\d{4}-\d\d-\d\d \d\d:\d\d:\d\d [0-9a-f]{8} ' -and [DateTime]::Parse($_.Substring(0, 19)) -ge $hourAgo })
    "== stop gate, last hour (idle passes = a lane stopped 3 times in a row without using a tool)"
    $recent | Group-Object { ($_ -split ' ')[2] } | ForEach-Object {
        $blocks = @($_.Group | Where-Object { ($_ -split ' ')[3] -eq 'block' }).Count
        $idle = @($_.Group | Where-Object { $_ -match ' pass 3 consecutive idle stops' }).Count
        "  $($_.Name): blocks $blocks, idle passes $idle$(if ($idle) { '  <- idled' })"
    }
}

"== windows"
foreach ($line in $windowLines) {
    $m = [regex]::Match($line, '\(eoie job (job-\S+)\)')
    $stale = if ($m.Success -and $line -match ' held ' -and $jobs.ContainsKey($m.Groups[1].Value) -and $jobs[$m.Groups[1].Value].State -notin 'running', 'queued') { "  <- STALE: job is $($jobs[$m.Groups[1].Value].State)" } else { '' }
    "  $($line.Trim())$stale"
}
