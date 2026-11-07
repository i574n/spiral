param(
    [Parameter(Mandatory, Position = 0)] [string] $Path,
    [ValidateSet('Summary', 'Thread')] [string] $View = 'Summary',
    [int] $Threads = 1,
    [int] $Rows = 40
)
$ErrorActionPreference = 'Stop'
$inv = [Globalization.CultureInfo]::InvariantCulture
function Format-Inv([string] $format, [object[]] $values) { [string]::Format($inv, $format, $values) }
function New-Tally { [pscustomobject]@{ Value = [Collections.Generic.Dictionary[string, double]]::new(); Order = [Collections.Generic.List[string]]::new() } }
function Add-Tally($tally, [string] $key, [double] $amount) {
    if ($tally.Value.ContainsKey($key)) { $tally.Value[$key] += $amount } else { $tally.Value[$key] = $amount; $tally.Order.Add($key) }
}
function Get-MostCommon($tally) { [Linq.Enumerable]::OrderByDescending($tally.Order, [Func[string, double]] { param($k) $tally.Value[$k] }) }
function Get-Short([string] $name, [int] $limit) {
    $n = [regex]::Replace($name, '\(.*$', '')
    $n = $n.Replace('SpiralCompilerCore!Spiral.spiral_compiler+', '').Replace('SpiralCompilerCore!Spiral.spiral_compiler.', '')
    $n = [regex]::Replace($n, '@\d+[-\d]*', '')
    $n.Substring(0, [Math]::Min($limit, $n.Length))
}

$doc = [Text.Json.JsonDocument]::Parse([ReadOnlyMemory[byte]]::new([IO.File]::ReadAllBytes($Path)), [Text.Json.JsonDocumentOptions]::new())
$root = $doc.RootElement
$frames = @(foreach ($f in $root.GetProperty('shared').GetProperty('frames').EnumerateArray()) { $f.GetProperty('name').GetString() })
$profiles = @($root.GetProperty('profiles').EnumerateArray())
function Get-ProfileName($p) { $v = [Text.Json.JsonElement]::new(); if ($p.TryGetProperty('name', [ref]$v)) { $v.GetString() } else { '?' } }

if ($View -eq 'Thread') {
    $wait = [regex]::new('Wait|Sleep|Monitor\.Enter|SpinWait|Poll|UNMANAGED_CODE_TIME|Idle|Park|Blocking|Thread\.Join', 'IgnoreCase')
    $nameIds = [Collections.Generic.Dictionary[string, int]]::new()
    $idNames = [Collections.Generic.List[string]]::new()
    $frameName = [int[]]::new($frames.Count)
    $isWait = [bool[]]::new($frames.Count)
    for ($i = 0; $i -lt $frames.Count; $i++) {
        $short = Get-Short $frames[$i] 120
        if (-not $nameIds.ContainsKey($short)) { $nameIds[$short] = $idNames.Count; $idNames.Add($short) }
        $frameName[$i] = $nameIds[$short]
        $isWait[$i] = $wait.IsMatch($frames[$i])
    }
    $results = foreach ($p in $profiles) {
        $stack = [Collections.Generic.List[int]]::new(); $last = $null; $busy = 0.0
        $depth = [Collections.Generic.Dictionary[int, int]]::new(); $entered = [Collections.Generic.Dictionary[int, double]]::new(); $incl = New-Tally
        foreach ($ev in $p.GetProperty('events').EnumerateArray()) {
            $t = $ev.GetProperty('at').GetDouble()
            if ($null -ne $last -and $stack.Count -and -not $isWait[$stack[$stack.Count - 1]]) { $busy += $t - $last }
            $last = $t
            $f = $ev.GetProperty('frame').GetInt32(); $n = $frameName[$f]
            $type = $ev.GetProperty('type').GetString()
            if ($type -eq 'O') {
                $stack.Add($f)
                $depth[$n] = $(if ($depth.ContainsKey($n)) { $depth[$n] } else { 0 }) + 1
                if ($depth[$n] -eq 1) { $entered[$n] = $busy }
            } elseif ($type -eq 'C' -and $stack.Count) {
                $stack.RemoveAt($stack.Count - 1)
                $depth[$n] = $(if ($depth.ContainsKey($n)) { $depth[$n] } else { 0 }) - 1
                if ($depth[$n] -eq 0) { $since = if ($entered.ContainsKey($n)) { $entered[$n] } else { $busy }; [void]$entered.Remove($n); Add-Tally $incl "$n" ($busy - $since) }
            }
        }
        foreach ($kv in $depth.GetEnumerator()) { if ($kv.Value -gt 0) { Add-Tally $incl "$($kv.Key)" ($busy - $(if ($entered.ContainsKey($kv.Key)) { $entered[$kv.Key] } else { $busy })) } }
        [pscustomobject]@{ Busy = $busy; Name = (Get-ProfileName $p); Incl = $incl }
    }
    foreach ($r in @($results | Sort-Object Busy -Descending -Stable | Select-Object -First $Threads)) {
        Format-Inv '== {0}: busy {1:F0} ms' @($r.Name, $r.Busy)
        $shown = 0
        foreach ($k in (Get-MostCommon $r.Incl)) {
            $frame = $idNames[[int]$k]
            if ($frame.Contains('!') -and -not $frame.Contains('SpiralCompilerCore')) { continue }
            Format-Inv '  {0,5:F1}%  {1}' @((100 * $r.Incl.Value[$k] / [Math]::Max($r.Busy, 1)), $frame)
            $shown++
            if ($shown -ge $Rows) { break }
        }
    }
    return
}

$wait = [regex]::new('Wait|Sleep|Monitor\.Enter|SpinWait|Poll|UNMANAGED_CODE_TIME|ReadFile|Idle|Park|Blocking|Thread\.Join|Receive', 'IgnoreCase')
$names = @(foreach ($f in $frames) { Get-Short $f 150 })
$isCore = @(foreach ($f in $frames) { $f.Contains('SpiralCompiler') })
$waitFrame = @(foreach ($f in $frames) { $wait.IsMatch($f) })
$leaf = New-Tally; $incl = New-Tally; $coreLeaf = New-Tally
$threadRows = foreach ($p in $profiles) {
    $stack = [Collections.Generic.List[int]]::new(); $last = $null; $busy = 0.0
    foreach ($ev in $p.GetProperty('events').EnumerateArray()) {
        $at = $ev.GetProperty('at').GetDouble()
        if ($stack.Count -and $null -ne $last -and $at -gt $last -and -not $waitFrame[$stack[$stack.Count - 1]]) {
            $dt = $at - $last; $busy += $dt
            Add-Tally $leaf $names[$stack[$stack.Count - 1]] $dt
            for ($i = $stack.Count - 1; $i -ge 0; $i--) { if ($isCore[$stack[$i]]) { Add-Tally $coreLeaf $names[$stack[$i]] $dt; break } }
            $seen = [Collections.Generic.HashSet[string]]::new()
            foreach ($idx in $stack) { if ($isCore[$idx] -and $seen.Add($names[$idx])) { Add-Tally $incl $names[$idx] $dt } }
        }
        $last = $at
        $frame = $ev.GetProperty('frame').GetInt32()
        if ($ev.GetProperty('type').GetString() -eq 'O') { $stack.Add($frame) }
        elseif ($stack.Count) {
            if ($stack[$stack.Count - 1] -eq $frame) { $stack.RemoveAt($stack.Count - 1) }
            else { $at2 = $stack.LastIndexOf($frame); if ($at2 -ge 0) { $stack.RemoveRange($at2, $stack.Count - $at2) } }
        }
    }
    [pscustomobject]@{ Busy = $busy; Name = (Get-ProfileName $p) }
}
$total = ($threadRows | Measure-Object Busy -Sum).Sum; if (-not $total) { $total = 1 }
$unit = $profiles[0].GetProperty('unit').GetString()
Format-Inv 'busy total {0:F0} {1} over {2} threads' @($total, $unit, @($threadRows).Count)
foreach ($t in @($threadRows | Sort-Object Busy, Name -Descending | Select-Object -First 8)) { Format-Inv '  {0,9:F0}  {1}' @($t.Busy, $t.Name) }
'== hot leaf frames (any code)'
foreach ($k in @(Get-MostCommon $leaf | Select-Object -First 15)) { Format-Inv '  {0,5:F1}%  {1}' @(($leaf.Value[$k] / $total * 100), $k) }
'== innermost compiler frame'
foreach ($k in @(Get-MostCommon $coreLeaf | Select-Object -First 25)) { Format-Inv '  {0,5:F1}%  {1}' @(($coreLeaf.Value[$k] / $total * 100), $k) }
'== inclusive compiler frames'
foreach ($k in @(Get-MostCommon $incl | Select-Object -First 45)) { Format-Inv '  {0,5:F1}%  {1}' @(($incl.Value[$k] / $total * 100), $k) }
