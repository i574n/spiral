param(
    [int] $Rounds = 5,
    [string] $Families = (Join-Path $PSScriptRoot '..\tests\families'),
    [string] $Out = (Join-Path $env:LOCALAPPDATA "spiral-bin\runs\bench-cells-vs-matrix-$(Get-Date -Format yyyyMMdd-HHmmss)"),
    [double] $Threshold = 2.0,
    [int] $MinFreeMB = 1536
)
$ErrorActionPreference = 'Stop'
if (-not ('TreeCpu' -as [type])) {
    Add-Type @'
using System;
using System.Runtime.InteropServices;
public static class TreeCpu {
    [StructLayout(LayoutKind.Sequential)]
    struct BasicAccounting {
        public long TotalUserTime, TotalKernelTime, ThisPeriodTotalUserTime, ThisPeriodTotalKernelTime;
        public uint TotalPageFaultCount, TotalProcesses, ActiveProcesses, TotalTerminatedProcesses;
    }
    [DllImport("kernel32.dll", SetLastError = true)] static extern IntPtr CreateJobObject(IntPtr attributes, string name);
    [DllImport("kernel32.dll", SetLastError = true)] static extern bool AssignProcessToJobObject(IntPtr job, IntPtr process);
    [DllImport("kernel32.dll", SetLastError = true)] static extern bool QueryInformationJobObject(IntPtr job, int infoClass, out BasicAccounting info, int length, IntPtr returned);
    [DllImport("kernel32.dll", SetLastError = true)] static extern bool CloseHandle(IntPtr handle);
    public static IntPtr Create() { return CreateJobObject(IntPtr.Zero, null); }
    public static bool Assign(IntPtr job, IntPtr process) { return AssignProcessToJobObject(job, process); }
    public static double[] Query(IntPtr job) {
        BasicAccounting info;
        QueryInformationJobObject(job, 1, out info, Marshal.SizeOf(typeof(BasicAccounting)), IntPtr.Zero);
        return new double[] { (info.TotalUserTime + info.TotalKernelTime) / 1e7, info.TotalProcesses };
    }
    public static void Close(IntPtr job) { CloseHandle(job); }
}
'@
}
$Families = (Resolve-Path $Families).Path
$familyFiles = @(Get-ChildItem $Families -Filter '*_family.spi' | Where-Object { (Get-Content (Join-Path $Families 'package.spiproj') -Raw) -match "(?m)^\s+$($_.BaseName)\s*$" } | ForEach-Object Name)
$samples = @(foreach ($f in $familyFiles) { [regex]::Matches((Get-Content (Join-Path $Families $f) -Raw), 'failwith "([^"]+)"') | ForEach-Object { $_.Groups[1].Value } }) | Sort-Object -Unique
if (-not $samples) { throw "no samples named by failwith in $Families" }
$filter = '^samples/(' + (($samples | ForEach-Object { [regex]::Escape($_) }) -join '|') + ')$'
New-Item -ItemType Directory -Force $Out | Out-Null
"bench: $($familyFiles.Count) family files, $($samples.Count) samples, $Rounds rounds, threshold $Threshold; out $Out"

function Measure-Side([string] $Side, [int] $Round, [string[]] $ArgList, [hashtable] $Environment) {
    $log = Join-Path $Out "round$Round-$Side.log"
    $job = [TreeCpu]::Create()
    $start = [Diagnostics.ProcessStartInfo]::new('pwsh')
    foreach ($a in $ArgList) { $start.ArgumentList.Add($a) }
    $start.UseShellExecute = $false
    $start.RedirectStandardOutput = $true
    $start.RedirectStandardError = $true
    foreach ($k in $Environment.Keys) { $start.Environment[$k] = $Environment[$k] }
    $clock = [Diagnostics.Stopwatch]::StartNew()
    $process = [Diagnostics.Process]::Start($start)
    [void][TreeCpu]::Assign($job, $process.Handle)
    $stdout = $process.StandardOutput.ReadToEndAsync()
    $stderr = $process.StandardError.ReadToEndAsync()
    $loads = [Collections.Generic.List[int]]::new()
    while (-not $process.WaitForExit(10000)) { $loads.Add([int](Get-CimInstance Win32_Processor | Measure-Object LoadPercentage -Average).Average) }
    $process.WaitForExit()
    $clock.Stop()
    $cpu = [TreeCpu]::Query($job)
    [TreeCpu]::Close($job)
    [IO.File]::WriteAllText($log, $stdout.Result + "`n--- stderr`n" + $stderr.Result)
    [pscustomobject]@{
        Round = $Round; Side = $Side; Exit = $process.ExitCode
        CpuS = [math]::Round($cpu[0], 1); Processes = [int]$cpu[1]; WallS = [math]::Round($clock.Elapsed.TotalSeconds, 1)
        LoadPct = if ($loads.Count) { [int]($loads | Measure-Object -Average).Average } else { -1 }
    }
}

$scripts = $PSScriptRoot
$matrixArgs = @('-NoProfile', '-File', (Join-Path $scripts 'test.ps1'), '-Mode', 'single-flight', '-Suite', 'all', '-Filter', $filter, '-Backend', 'C,Zig', '-Native')
$rows = foreach ($round in 1..$Rounds) {
    $freeMB = [int]((Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory / 1KB)
    if ($freeMB -lt $MinFreeMB) {
        [pscustomobject]@{ Round = $round; Side = 'void'; Exit = -1; CpuS = 0; Processes = 0; WallS = 0; LoadPct = -1 }
        "round $round VOID: $freeMB MB free < $MinFreeMB"
        continue
    }
    $cellsOut = Join-Path $Out "round$round-cells"
    $cellsArgs = @('-NoProfile', '-File', (Join-Path $scripts 'test-blocks.ps1'), '-Lib', $Families, '-Files', ($familyFiles -join ','), '-Out', $cellsOut, '-Compiler', 'process')
    $order = if ($round % 2) { @('matrix', 'cells') } else { @('cells', 'matrix') }
    foreach ($side in $order) {
        $r = if ($side -eq 'matrix') { Measure-Side 'matrix' $round $matrixArgs @{} } else { Measure-Side 'cells' $round $cellsArgs @{ SPIRAL_CELLS_MEMO = '0'; SPIRAL_CELLS_COMPILER = 'process' } }
        $r
        "round $round $side`: cpu $($r.CpuS) s over $($r.Processes) processes, wall $($r.WallS) s, box load $($r.LoadPct)%, exit $($r.Exit)"
    }
}
$measured = @($rows | Where-Object { $_ -is [pscustomobject] })
$measured | Export-Csv (Join-Path $Out 'rounds.tsv') -Delimiter "`t" -NoTypeInformation -UseQuotes Never
$ratios = @(foreach ($round in 1..$Rounds) {
    $m = $measured | Where-Object { $_.Round -eq $round -and $_.Side -eq 'matrix' }
    $c = $measured | Where-Object { $_.Round -eq $round -and $_.Side -eq 'cells' }
    if ($m -and $c -and $m.CpuS -gt 0 -and $m.Exit -eq 0 -and $c.Exit -eq 0) { [pscustomobject]@{ Round = $round; Cpu = $c.CpuS / $m.CpuS; Wall = $c.WallS / [Math]::Max(0.1, $m.WallS) } }
})
$phases = @{}
foreach ($nb in Get-ChildItem $Out -Recurse -Filter '*.ipynb' -ErrorAction Ignore) {
    foreach ($cell in (Get-Content $nb.FullName -Raw | ConvertFrom-Json).cells) {
        $p = $cell.metadata.phases_ms
        if (-not $p) { continue }
        foreach ($prop in $p.PSObject.Properties) { $phases[$prop.Name] = [long]$phases[$prop.Name] + [long]$prop.Value }
    }
}
if ($phases.Count) { 'cells phase totals over all rounds (ms): ' + (($phases.GetEnumerator() | Sort-Object Value -Descending | ForEach-Object { "$($_.Key) $($_.Value)" }) -join ', ') }
if ($ratios.Count -eq 0) { 'VERDICT VOID (no round where both sides exited 0)'; return }
$sorted = @($ratios.Cpu | Sort-Object)
$median = if ($sorted.Count % 2) { $sorted[[int][Math]::Floor($sorted.Count / 2)] } else { ($sorted[$sorted.Count / 2 - 1] + $sorted[$sorted.Count / 2]) / 2 }
$wallSorted = @($ratios.Wall | Sort-Object)
$wallMedian = $wallSorted[[int][Math]::Floor($wallSorted.Count / 2)]
'per-round cpu ratio cells/matrix: ' + (($ratios | ForEach-Object { '{0}:{1:N2}' -f $_.Round, $_.Cpu }) -join ' ')
'median cpu ratio {0:N2} over {1} rounds (wall ratio median {2:N2}, reported only)' -f $median, $ratios.Count, $wallMedian
"VERDICT $(if ($median -le $Threshold) { 'GREEN' } else { 'RED' }) (rule SAMPLES-TO-TEST-BLOCKS n27: the migration resumes iff the median per-round CPU ratio is <= $Threshold)"
