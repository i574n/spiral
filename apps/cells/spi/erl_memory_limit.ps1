function Start-ErlMemoryLimit([string] $ProcessName = 'erl', [int] $LimitMegabytes = 0) {
    if ($LimitMegabytes -le 0) {
        $configured = 0
        $guardMegabytes = if ([int]::TryParse("$env:SPIRAL_CELLS_MAX_MB", [ref]$configured)) { $configured } else { 2048 }
        if ($guardMegabytes -eq 0) { return $null }
        $LimitMegabytes = $guardMegabytes + 1024
    }
    if (-not ('ErlMemoryLimit' -as [type])) {
        Add-Type -TypeDefinition @'
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
public sealed class ErlMemoryLimit {
    [StructLayout(LayoutKind.Sequential)] struct Basic { public long A; public long B; public uint Flags; public UIntPtr C; public UIntPtr D; public uint E; public UIntPtr F; public uint G; public uint H; }
    [StructLayout(LayoutKind.Sequential)] struct Io { public ulong A, B, C, D, E, F; }
    [StructLayout(LayoutKind.Sequential)] struct Extended { public Basic Basic; public Io Io; public UIntPtr ProcessMemoryLimit; public UIntPtr JobMemoryLimit; public UIntPtr PeakProcess; public UIntPtr PeakJob; }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)] struct Entry { public uint Size; public uint Usage; public uint ProcessId; public IntPtr HeapId; public uint ModuleId; public uint Threads; public uint ParentProcessId; public int Priority; public uint Flags; [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string ExeFile; }
    [DllImport("kernel32.dll", SetLastError = true)] static extern IntPtr CreateJobObject(IntPtr attributes, string name);
    [DllImport("kernel32.dll", SetLastError = true)] static extern bool SetInformationJobObject(IntPtr job, int kind, ref Extended info, int length);
    [DllImport("kernel32.dll", SetLastError = true)] static extern bool AssignProcessToJobObject(IntPtr job, IntPtr process);
    [DllImport("kernel32.dll", SetLastError = true)] static extern IntPtr OpenProcess(uint access, bool inherit, int id);
    [DllImport("kernel32.dll", SetLastError = true)] static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processId);
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)] static extern bool Process32FirstW(IntPtr snapshot, ref Entry entry);
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)] static extern bool Process32NextW(IntPtr snapshot, ref Entry entry);
    [DllImport("kernel32.dll")] static extern bool CloseHandle(IntPtr handle);

    readonly int root;
    readonly string name;
    readonly ulong bytes;
    readonly HashSet<int> seen = new HashSet<int>();
    volatile bool running = true;
    public int Confined;

    ErlMemoryLimit(int root, string name, ulong bytes) { this.root = root; this.name = name; this.bytes = bytes; }

    public static ErlMemoryLimit Start(int root, string name, ulong bytes) {
        var limit = new ErlMemoryLimit(root, name, bytes);
        var thread = new Thread(limit.Watch) { IsBackground = true, Name = "erl-memory-limit" };
        thread.Start();
        return limit;
    }

    public void Stop() { running = false; }

    static Dictionary<int, int> Parents() {
        var parents = new Dictionary<int, int>();
        IntPtr snapshot = CreateToolhelp32Snapshot(2, 0);
        if (snapshot == new IntPtr(-1)) return parents;
        try {
            var entry = new Entry { Size = (uint)Marshal.SizeOf(typeof(Entry)) };
            for (bool more = Process32FirstW(snapshot, ref entry); more; more = Process32NextW(snapshot, ref entry))
                parents[(int)entry.ProcessId] = (int)entry.ParentProcessId;
        } finally { CloseHandle(snapshot); }
        return parents;
    }

    bool Descends(int id, Dictionary<int, int> parents) {
        for (int hop = 0; hop < 12; hop++) {
            int parent;
            if (!parents.TryGetValue(id, out parent) || parent == 0) return false;
            if (parent == root) return true;
            id = parent;
        }
        return false;
    }

    bool Confine(int id) {
        IntPtr process = OpenProcess(0x0101, false, id);
        if (process == IntPtr.Zero) return false;
        IntPtr job = CreateJobObject(IntPtr.Zero, null);
        var info = new Extended();
        info.Basic.Flags = 0x100 | 0x800 | 0x1000;
        info.ProcessMemoryLimit = new UIntPtr(bytes);
        bool done = SetInformationJobObject(job, 9, ref info, Marshal.SizeOf(typeof(Extended))) && AssignProcessToJobObject(job, process);
        CloseHandle(process);
        return done;
    }

    void Watch() {
        while (running) {
            Process[] candidates = Process.GetProcessesByName(name);
            if (candidates.Length > 0) {
                Dictionary<int, int> parents = null;
                foreach (var candidate in candidates) {
                    if (seen.Contains(candidate.Id)) continue;
                    if (parents == null) parents = Parents();
                    if (Descends(candidate.Id, parents) && Confine(candidate.Id)) Confined++;
                    seen.Add(candidate.Id);
                }
            }
            Thread.Sleep(250);
        }
    }
}
'@
    }
    [ErlMemoryLimit]::Start($PID, $ProcessName, [uint64]$LimitMegabytes * 1MB)
}
