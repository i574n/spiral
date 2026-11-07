param(
    [Parameter(Mandatory)] [string] $Dll,
    [string] $Variants = 'w1-cw1,w8-cw1,w8-cw2,w8-cw8',
    [int] $Rounds = 5,
    [string] $Source = 'C:\home\git\spiral\apps\spiral\spiral.spi',
    [int] $TimeoutSec = 900
)
$ErrorActionPreference = 'Stop'
. C:\home\git\spiral\apps\compiler\scripts\env.ps1
$dotnet = Resolve-SpiralDotnet
$out = Join-Path $env:LOCALAPPDATA ('spiral-bin\candidates\hopacsota-p2\alternating-ab\{0}' -f (Get-Date -Format 'yyyyMMdd-HHmmss'))
New-Item -ItemType Directory -Force $out | Out-Null
"core $((Get-FileHash (Join-Path (Split-Path $Dll) 'SpiralCompilerCore.dll')).Hash.Substring(0, 16)); results $out"
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
$env:DOTNET_GCgen0size = '0x10000000'
$env:DOTNET_gcServer = '0'
$env:SPIRAL_HOPACSOTA_STATS = '1'
$env:SPIRAL_HOPACSOTA_POLICY = 'parallel'
function Get-BusyCores {
    $before = @{}
    foreach ($p in Get-Process) { try { $before[$p.Id] = $p.TotalProcessorTime.TotalSeconds } catch {} }
    $watch = [Diagnostics.Stopwatch]::StartNew()
    Start-Sleep -Seconds 2
    $busy = 0.0
    foreach ($p in Get-Process) { try { if ($before.ContainsKey($p.Id) -and $p.Id -ne $PID) { $busy += $p.TotalProcessorTime.TotalSeconds - $before[$p.Id] } } catch {} }
    [math]::Round($busy / $watch.Elapsed.TotalSeconds, 1)
}
$list = $Variants.Split(',')
$rows = foreach ($round in 1 .. $Rounds) {
    $order = if ($round % 2) { $list } else { $list[($list.Count - 1)..0] }
    foreach ($variant in $order) {
        $workers, $control = $variant.Split('-')
        $env:SPIRAL_HOPACSOTA_WORKERS = $workers.TrimStart('w')
        $env:SPIRAL_HOPACSOTA_CONTROL_WORKERS = $control.TrimStart('cw')
        $target = Join-Path $out "$variant-r$round.fsx"
        $log = Join-Path $out "$variant-r$round.log"
        $loadStart = Get-BusyCores
        $watch = [Diagnostics.Stopwatch]::StartNew()
        $process = Start-Process -FilePath $dotnet -ArgumentList $Dll, '--backend', 'Fsharp', $Source, $target -NoNewWindow -PassThru -RedirectStandardOutput "$log.out" -RedirectStandardError $log
        if (-not $process.WaitForExit($TimeoutSec * 1000)) { Stop-Process -Id $process.Id; $status = ">${TimeoutSec}s" } else { $status = "exit $($process.ExitCode)" }
        $seconds = [math]::Round($watch.Elapsed.TotalSeconds, 1)
        $hash = if (Test-Path $target) { (Get-FileHash $target).Hash.Substring(0, 12) } else { '-' }
        $stats = (Select-String -Path $log, "$log.out" -Pattern 'hopacsota engine:' | Select-Object -First 1 | ForEach-Object { $_.Line.Trim() }) -join ''
        $loadEnd = Get-BusyCores
        $census = (Select-String -Path $log, "$log.out" -Pattern 'hopacsota census:' | Select-Object -First 1 | ForEach-Object { $_.Line.Trim() }) -join ''
        [pscustomobject]@{
            Round = $round; Variant = $variant; Seconds = $seconds; Status = $status; Hash = $hash; LoadStart = $loadStart; LoadEnd = $loadEnd
            Waits = [regex]::Match($stats, 'waits=(\d+)').Groups[1].Value; Bridges = [regex]::Match($stats, 'bridges=(\d+)').Groups[1].Value
            WaitMs = [regex]::Match($census, 'wait_ms=(\d+)').Groups[1].Value; LongestWaitMs = [regex]::Match($census, 'longest_wait_ms=(\d+)').Groups[1].Value; BridgeMs = [regex]::Match($census, 'bridge_ms=(\d+)').Groups[1].Value
        }
    }
}
foreach ($name in 'SPIRAL_HOPACSOTA_POLICY', 'SPIRAL_HOPACSOTA_WORKERS', 'SPIRAL_HOPACSOTA_CONTROL_WORKERS', 'SPIRAL_HOPACSOTA_STATS') { Remove-Item "Env:$name" -ErrorAction Ignore }
$rows | Export-Csv (Join-Path $out 'runs.tsv') -Delimiter "`t" -NoTypeInformation
$rows | Format-Table Round, Variant, Seconds, LoadStart, LoadEnd, Waits, Bridges, WaitMs, LongestWaitMs, BridgeMs, Status, Hash -AutoSize | Out-String -Width 220
$quietRounds = @($rows | Group-Object Round | Where-Object { -not ($_.Group | Where-Object { $_.LoadStart -ge 2 -or $_.LoadEnd -ge 2 }) } | ForEach-Object { [int]$_.Name })
"quiet rounds (other load < 2 cores at every run's start and end): $($quietRounds -join ', ')"
$quiet = @($rows | Where-Object { $quietRounds -contains $_.Round })
if ($quiet.Count) {
    $quietBase = @($quiet | Where-Object Variant -eq $list[0] | Sort-Object Seconds)
    $quietBaseMedian = $quietBase[[int][math]::Floor($quietBase.Count / 2)].Seconds
    $quiet | Group-Object Variant | ForEach-Object { $sorted = @($_.Group | Sort-Object Seconds); $median = $sorted[[int][math]::Floor($sorted.Count / 2)].Seconds; "quiet {0}: median {1} s ({2:N2}x {3}) over {4} round(s)" -f $_.Name, $median, ($median / $quietBaseMedian), $list[0], $sorted.Count }
}
$base = @($rows | Where-Object Variant -eq $list[0] | Sort-Object Seconds)[[int][math]::Floor($Rounds / 2)].Seconds
$rows | Group-Object Variant | ForEach-Object { $median = @($_.Group | Sort-Object Seconds)[[int][math]::Floor($_.Count / 2)].Seconds; "{0}: median {1} s ({2:N2}x {3}), min {4} s, hashes {5}" -f $_.Name, $median, ($median / $base), $list[0], ($_.Group.Seconds | Measure-Object -Minimum).Minimum, (($_.Group.Hash | Sort-Object -Unique) -join ',') }
