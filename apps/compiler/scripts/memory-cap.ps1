param([Parameter(Mandatory)] [int] $RootPid, [int] $CapMb = 16000, [Parameter(Mandatory)] [string] $Out, [int] $EverySeconds = 5)
$peak = 0
while (Get-Process -Id $RootPid -ErrorAction SilentlyContinue) {
    $table = @{}
    foreach ($p in Get-CimInstance Win32_Process) { $table[[int]$p.ProcessId] = $p }
    $children = @{}
    foreach ($p in $table.Values) {
        $parent = [int]$p.ParentProcessId
        if (-not $children.ContainsKey($parent)) { $children[$parent] = [Collections.Generic.List[int]]::new() }
        $children[$parent].Add([int]$p.ProcessId)
    }
    $tree = [Collections.Generic.List[int]]::new()
    $pending = [Collections.Generic.Queue[int]]::new()
    $pending.Enqueue($RootPid)
    while ($pending.Count) {
        $id = $pending.Dequeue()
        if ($id -ne $RootPid) { $tree.Add($id) }
        if ($children.ContainsKey($id)) { foreach ($child in $children[$id]) { if ($child -ne $id -and -not $tree.Contains($child)) { $pending.Enqueue($child) } } }
    }
    $sizes = foreach ($id in $tree) { $process = Get-Process -Id $id -ErrorAction SilentlyContinue; if ($process) { [pscustomobject]@{ Id = $id; Name = $process.ProcessName; Mb = [int]($process.PrivateMemorySize64 / 1mb) } } }
    $total = [int](($sizes | Measure-Object Mb -Sum).Sum)
    if ($total -gt $peak) {
        $peak = $total
        $largest = $sizes | Sort-Object Mb -Descending | Select-Object -First 1
        Set-Content $Out "peak $peak MB over $($tree.Count) processes at $(Get-Date -Format 'HH:mm:ss'); largest $($largest.Name) $($largest.Id) $($largest.Mb) MB"
    }
    if ($total -gt $CapMb) {
        Add-Content $Out "capped at $(Get-Date -Format 'HH:mm:ss'): $total MB > $CapMb MB; stopping the tree under $RootPid"
        foreach ($id in $tree) { Stop-Process -Id $id -Force -ErrorAction SilentlyContinue }
        break
    }
    Start-Sleep -Seconds $EverySeconds
}
