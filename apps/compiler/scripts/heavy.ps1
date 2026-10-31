$script:HeavyState = Join-Path ($env:LOCALAPPDATA ?? $HOME) 'spiral-bin'
$script:HeavyQueue = Join-Path $script:HeavyState 'heavy-queue'
$script:RunLedger = Join-Path $script:HeavyState 'ledger/runs.tsv'
$script:HeavySecondSlotMinFreeMB = 3072
$script:WslTicketMaxWaitMinutes = 45

function Get-HeavyFreeMB {
    if ($IsWindows) { return [int]((Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory / 1KB) }
    $available = Select-String -Path /proc/meminfo -Pattern '^MemAvailable:\s+(\d+) kB' -ErrorAction Ignore | Select-Object -First 1
    if ($available) { [int]([long]$available.Matches[0].Groups[1].Value / 1KB) } else { [int]::MaxValue }
}

function Test-HeavyFirstInLine([string] $ticket) {
    $live = foreach ($f in Get-ChildItem $script:HeavyQueue -Filter '*.t' -ErrorAction Ignore) {
        $owner = [int]($f.BaseName -split '-')[1]
        if (Get-Process -Id $owner -ErrorAction Ignore) { $f.Name } else { try { $f.Delete() } catch { } }
    }
    ($live | Sort-Object | Select-Object -First 1) -eq $ticket
}

function Write-RunLedger([string] $Kind, [string] $Label, [scriptblock] $Command, [datetime] $Queued, [datetime] $Started, [string] $Slot, [string] $Outcome, [int] $FreeBefore) {
    New-Item -ItemType Directory -Force (Split-Path $script:RunLedger) | Out-Null
    if (-not (Test-Path $script:RunLedger)) {
        [IO.File]::WriteAllText($script:RunLedger, "start`tend`twait_s`trun_s`tkind`tslot`tlabel`toutcome`tfree_mb_start`tfree_mb_end`tcommand`n")
    }
    $end = Get-Date
    $text = ($Command.ToString() -replace '\s+', ' ').Trim()
    if ($text.Length -gt 300) { $text = $text.Substring(0, 300) }
    if (-not $Label) { $Label = if ($text.Length -gt 80) { $text.Substring(0, 80) } else { $text } }
    $row = @($Queued.ToString('yyyy-MM-ddTHH:mm:ss'), $end.ToString('yyyy-MM-ddTHH:mm:ss'), [int]($Started - $Queued).TotalSeconds, [int]($end - $Started).TotalSeconds, $Kind, $Slot, ($Label -replace '\t', ' '), $Outcome, $FreeBefore, (Get-HeavyFreeMB), ($text -replace '\t', ' ')) -join "`t"
    for ($try = 0; $try -lt 5; $try++) { try { [IO.File]::AppendAllText($script:RunLedger, $row + "`n"); break } catch { Start-Sleep -Milliseconds 200 } }
}

function Invoke-Timed([Parameter(Mandatory)] [scriptblock] $Command, [string] $Label) {
    $started = Get-Date
    $free = Get-HeavyFreeMB
    $outcome = 'ok'
    $global:LASTEXITCODE = 0
    try { & $Command; if ($LASTEXITCODE) { $outcome = "exit $LASTEXITCODE" } }
    catch { $outcome = "threw: $($_.Exception.Message -replace '\s+', ' ')"; throw }
    finally { Write-RunLedger 'timed' $Label $Command $started $started '-' $outcome $free }
}

function Get-HeavyTicketPrefix([switch] $Wsl) {
    if ($Wsl) { return 'w' }
    $starvedWsl = Get-ChildItem $script:HeavyQueue -Filter '*.t' -ErrorAction Ignore | Where-Object {
        ($_.Name.StartsWith('w') -and $_.CreationTimeUtc -lt [DateTime]::UtcNow.AddMinutes(-$script:WslTicketMaxWaitMinutes)) -or $_.Name.StartsWith('x') }
    if ($starvedWsl) { 'x' } else { '' }
}

function Get-HeavyHolders {
    $holders = foreach ($f in Get-ChildItem $script:HeavyQueue -Filter 'holder-*.h' -ErrorAction Ignore | Sort-Object Name) {
        $slot, $owner, $started, $label = (Get-Content $f.FullName -Raw -ErrorAction Ignore) -split "`t", 4
        if (-not $owner -or -not (Get-Process -Id ([int]$owner) -ErrorAction Ignore)) { Remove-Item $f.FullName -Force -ErrorAction Ignore; continue }
        "slot $slot held $([int]((Get-Date) - [DateTime]::Parse($started)).TotalMinutes) min by pid $owner '$($label.Trim())'"
    }
    if ($holders) { $holders -join ', ' } else { 'no holder recorded' }
}

function Start-HeavyWatchdog([string] $HolderPath, [int] $MaxMinutes) {
    if (-not $IsWindows -or $MaxMinutes -le 0) { return }
    $watch = @'
param($holder, $holderPath, $deadline)
while ((Test-Path $holderPath) -and (Get-Process -Id $holder -ErrorAction Ignore)) {
    if ([DateTime]::Now -ge [DateTime]::Parse($deadline)) {
        $all = Get-CimInstance Win32_Process
        $children = @{}
        foreach ($p in $all) { $children[[int]$p.ParentProcessId] += @([int]$p.ProcessId) }
        $stack = [Collections.Generic.Stack[int]]::new(); $stack.Push([int]$holder)
        $tree = while ($stack.Count) { $id = $stack.Pop(); foreach ($c in $children[$id]) { if ($c -ne $PID) { $c; $stack.Push($c) } } }
        foreach ($id in $tree) { Stop-Process -Id $id -Force -ErrorAction Ignore }
        if ($tree) { Add-Content $holderPath "`texpired: stopped $(@($tree).Count) process(es) of pid $holder" }
    }
    Start-Sleep -Seconds 15
}
'@
    $script = Join-Path $script:HeavyQueue 'watchdog.ps1'
    if (-not (Test-Path $script) -or (Get-Content $script -Raw) -ne $watch) { [IO.File]::WriteAllText($script, $watch) }
    $deadline = (Get-Date).AddMinutes($MaxMinutes).ToString('o')
    try { $null = Start-ThreadJob -ScriptBlock ([scriptblock]::Create($watch)) -ArgumentList $PID, $HolderPath, $deadline -ErrorAction Stop }
    catch { Start-Process pwsh -WindowStyle Hidden -ArgumentList @('-NoProfile', '-File', $script, $PID, $HolderPath, $deadline) | Out-Null }
}

function Get-HeavyHeldByAncestor {
    if (-not $env:SPIRAL_HEAVY_HELD) { return }
    $slot, $owner = $env:SPIRAL_HEAVY_HELD -split ':', 2
    $recorded = ((Get-Content (Join-Path $script:HeavyQueue "holder-$slot.h") -Raw -ErrorAction Ignore) -split "`t", 3)[1]
    if (-not $recorded -or $recorded -ne $owner) { return }
    $process = Get-Process -Id $PID
    for ($depth = 0; $process -and $depth -lt 32; $depth++) {
        if ("$($process.Id)" -eq $owner) { return "slot $slot is already held by ancestor pid $owner" }
        $process = $process.Parent
    }
}

function Wait-HeavySlot($slots, [string] $ticket) {
    $held = $null
    $queuedAt = Get-Date
    $lastBeat = Get-Date
    while ($null -eq $held) {
        if (Test-HeavyFirstInLine $ticket) {
            foreach ($i in 0, 1) {
                if ($null -ne $held) { break }
                if ($i -eq 1 -and (Get-HeavyFreeMB) -lt $script:HeavySecondSlotMinFreeMB) { continue }
                $got = $false
                try { $got = $slots[$i].WaitOne(0) } catch [System.Threading.AbandonedMutexException] { $got = $true }
                if ($got) { $held = $i }
            }
            if ($null -eq $held) {
                try { if ($slots[0].WaitOne([TimeSpan]::FromSeconds(30))) { $held = 0 } } catch [System.Threading.AbandonedMutexException] { $held = 0 }
            }
        } else { Start-Sleep -Seconds 5 }
        if ($null -eq $held -and ((Get-Date) - $lastBeat).TotalMinutes -ge 5) {
            Write-Host "Invoke-Heavy: still waiting ($([int]((Get-Date) - $queuedAt).TotalMinutes) min, $(Get-HeavyFreeMB) MB free; $(Get-HeavyHolders))"
            $lastBeat = Get-Date
        }
    }
    $held
}

function Wait-WslReady {
    if (-not $IsWindows) { return }
    for ($try = 1; $try -le 6; $try++) {
        $probe = wsl -e true 2>&1 | Out-String
        if ($LASTEXITCODE -eq 0) { break }
        Write-Host "Invoke-Heavy: WSL not ready (try $try/6): $($probe.Trim() -replace '\0', '')"
        [System.Threading.Thread]::Sleep(5000)
    }
}

function Stop-IdleWsl {
    if (-not $IsWindows) { return }
    $running = Get-ChildItem $script:HeavyQueue -Filter 'running-wsl-*.r' -ErrorAction Ignore | Where-Object {
        if (Get-Process -Id ([int]($_.BaseName -split '-')[-1]) -ErrorAction Ignore) { $true } else { Remove-Item $_.FullName -Force -ErrorAction Ignore; $false } }
    $next = Get-ChildItem $script:HeavyQueue -Filter '*.t' -ErrorAction Ignore | Where-Object { Get-Process -Id ([int]($_.BaseName -split '-')[1]) -ErrorAction Ignore } | Sort-Object Name | Select-Object -First 1
    if ($running) { Write-Host 'Invoke-Heavy: WSL job done, another WSL job is running: VM kept' }
    elseif (-not $next -or -not $next.Name.StartsWith('w')) { Write-Host "Invoke-Heavy: WSL job done, next job isn't WSL: wsl --shutdown"; wsl --shutdown }
}

function Invoke-Heavy([Parameter(Mandatory)] [scriptblock] $Command, [switch] $Wsl, [string] $Label, [int] $MaxMinutes = $(if ($env:SPIRAL_HEAVY_MAX_MINUTES) { [int]$env:SPIRAL_HEAVY_MAX_MINUTES } else { 240 })) {
    $inherited = Get-HeavyHeldByAncestor
    if ($inherited) { Write-Host "Invoke-Heavy: $inherited; running inside it"; & $Command; return }
    $ledgerQueued = Get-Date
    $ledgerFree = Get-HeavyFreeMB
    $slots = @([System.Threading.Mutex]::new($false, 'Global\spiral-heavy-job'), [System.Threading.Mutex]::new($false, 'Global\spiral-heavy-job-2'))
    New-Item -ItemType Directory -Force $script:HeavyQueue | Out-Null
    $adopted = $env:SPIRAL_HEAVY_TICKET
    Remove-Item Env:SPIRAL_HEAVY_TICKET -ErrorAction Ignore
    if ($adopted -and (Test-Path (Join-Path $script:HeavyQueue $adopted))) {
        $ticket = $adopted
        $ticketPath = Join-Path $script:HeavyQueue $ticket
    } else {
        $ticket = '{0}{1:D20}-{2}.t' -f (Get-HeavyTicketPrefix -Wsl:$Wsl), [DateTime]::UtcNow.Ticks, $PID
        $ticketPath = Join-Path $script:HeavyQueue $ticket
        New-Item -ItemType File -Force $ticketPath | Out-Null
    }
    try { $held = Wait-HeavySlot $slots $ticket } finally { Remove-Item $ticketPath -Force -ErrorAction Ignore }
    Write-Host "Invoke-Heavy: acquired slot $($held + 1) after $([int]((Get-Date) - $ledgerQueued).TotalSeconds) s (held at most $MaxMinutes min)"
    $holderPath = Join-Path $script:HeavyQueue "holder-$($held + 1).h"
    $holderLabel = if ($Label) { $Label } else { (($Command.ToString() -replace '\s+', ' ').Trim() + ' ' * 80).Substring(0, 80).Trim() }
    [IO.File]::WriteAllText($holderPath, "$($held + 1)`t$PID`t$((Get-Date).ToString('o'))`t$holderLabel")
    Start-HeavyWatchdog $holderPath $MaxMinutes
    $wslMarker = Join-Path $script:HeavyQueue "running-wsl-$PID.r"
    if ($Wsl) { New-Item -ItemType File -Force $wslMarker | Out-Null; Wait-WslReady }
    $self = [System.Diagnostics.Process]::GetCurrentProcess()
    $priority = $self.PriorityClass
    try { $self.PriorityClass = [System.Diagnostics.ProcessPriorityClass]::Normal } catch { }
    $ledgerStarted = Get-Date
    $ledgerOutcome = 'ok'
    $heldBefore = $env:SPIRAL_HEAVY_HELD
    $env:SPIRAL_HEAVY_HELD = "$($held + 1):$PID"
    $global:LASTEXITCODE = 0
    try { & $Command; if ($LASTEXITCODE) { $ledgerOutcome = "exit $LASTEXITCODE" } }
    catch { $ledgerOutcome = "threw: $($_.Exception.Message -replace '\s+', ' ')"; throw }
    finally {
        if ($null -eq $heldBefore) { Remove-Item Env:SPIRAL_HEAVY_HELD -ErrorAction Ignore } else { $env:SPIRAL_HEAVY_HELD = $heldBefore }
        Write-RunLedger 'heavy' $Label $Command $ledgerQueued $ledgerStarted "$($held + 1)" $ledgerOutcome $ledgerFree
        try { $self.PriorityClass = $priority } catch { }
        Remove-Item $holderPath -Force -ErrorAction Ignore
        $slots[$held].ReleaseMutex()
        $slots | ForEach-Object { $_.Dispose() }
        if ($Wsl) { Remove-Item $wslMarker -Force -ErrorAction Ignore; Stop-IdleWsl }
    }
}
