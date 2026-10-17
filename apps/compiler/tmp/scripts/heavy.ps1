$script:HeavyState = Join-Path ($env:LOCALAPPDATA ?? $HOME) 'spiral-bin'
$script:HeavyQueue = Join-Path $script:HeavyState 'heavy-queue'
$script:RunLedger = Join-Path $script:HeavyState 'ledger/runs.tsv'
$script:HeavySecondSlotMinFreeMB = 3072
$script:WslTicketMaxWaitMinutes = 45

function Get-HeavyFreeMB { [int]((Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory / 1KB) }

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
            Write-Host "Invoke-Heavy: still waiting ($([int]((Get-Date) - $queuedAt).TotalMinutes) min, $(Get-HeavyFreeMB) MB free)"
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

function Invoke-Heavy([Parameter(Mandatory)] [scriptblock] $Command, [switch] $Wsl, [string] $Label) {
    $ledgerQueued = Get-Date
    $ledgerFree = Get-HeavyFreeMB
    $slots = @([System.Threading.Mutex]::new($false, 'Global\spiral-heavy-job'), [System.Threading.Mutex]::new($false, 'Global\spiral-heavy-job-2'))
    New-Item -ItemType Directory -Force $script:HeavyQueue | Out-Null
    $ticket = '{0}{1:D20}-{2}.t' -f (Get-HeavyTicketPrefix -Wsl:$Wsl), [DateTime]::UtcNow.Ticks, $PID
    $ticketPath = Join-Path $script:HeavyQueue $ticket
    New-Item -ItemType File -Force $ticketPath | Out-Null
    try { $held = Wait-HeavySlot $slots $ticket } finally { Remove-Item $ticketPath -Force -ErrorAction Ignore }
    Write-Host "Invoke-Heavy: acquired slot $($held + 1) after $([int]((Get-Date) - $ledgerQueued).TotalSeconds) s"
    $wslMarker = Join-Path $script:HeavyQueue "running-wsl-$PID.r"
    if ($Wsl) { New-Item -ItemType File -Force $wslMarker | Out-Null; Wait-WslReady }
    $self = [System.Diagnostics.Process]::GetCurrentProcess()
    $priority = $self.PriorityClass
    try { $self.PriorityClass = [System.Diagnostics.ProcessPriorityClass]::BelowNormal } catch { }
    $ledgerStarted = Get-Date
    $ledgerOutcome = 'ok'
    $global:LASTEXITCODE = 0
    try { & $Command; if ($LASTEXITCODE) { $ledgerOutcome = "exit $LASTEXITCODE" } }
    catch { $ledgerOutcome = "threw: $($_.Exception.Message -replace '\s+', ' ')"; throw }
    finally {
        Write-RunLedger 'heavy' $Label $Command $ledgerQueued $ledgerStarted "$($held + 1)" $ledgerOutcome $ledgerFree
        try { $self.PriorityClass = $priority } catch { }
        $slots[$held].ReleaseMutex()
        $slots | ForEach-Object { $_.Dispose() }
        if ($Wsl) { Remove-Item $wslMarker -Force -ErrorAction Ignore; Stop-IdleWsl }
    }
}
