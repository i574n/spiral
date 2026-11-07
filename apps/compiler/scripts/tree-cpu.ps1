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

function Measure-TreeCpu([string] $Exe, [string[]] $ArgList, [hashtable] $Environment = @{}, [string] $Log = '') {
    $job = [TreeCpu]::Create()
    $start = [Diagnostics.ProcessStartInfo]::new($Exe)
    foreach ($a in $ArgList) { $start.ArgumentList.Add($a) }
    $start.UseShellExecute = $false
    $start.RedirectStandardOutput = $true
    $start.RedirectStandardError = $true
    foreach ($k in $Environment.Keys) { if ($null -eq $Environment[$k]) { [void]$start.Environment.Remove($k) } else { $start.Environment[$k] = $Environment[$k] } }
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
    if ($Log) { [IO.File]::WriteAllText($Log, $stdout.Result + "`n--- stderr`n" + $stderr.Result) }
    [pscustomobject]@{
        Exit = $process.ExitCode; CpuS = [math]::Round($cpu[0], 2); Processes = [int]$cpu[1]
        WallS = [math]::Round($clock.Elapsed.TotalSeconds, 2); LoadPct = if ($loads.Count) { [int]($loads | Measure-Object -Average).Average } else { -1 }
        Stdout = $stdout.Result
    }
}
