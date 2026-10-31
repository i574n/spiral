param([switch]$Size, [switch]$Banned, [string]$CoreSource)
. $PSScriptRoot/env.ps1
if (-not $Size -and -not $Banned) { $Size = $true; $Banned = $true }
$source = if ($CoreSource) { $CoreSource } else { Get-SpiralCoreSource 'hopacsota' }
$lines = [IO.File]::ReadAllText($source).Replace("`r`n", "`n").Split("`n")
$layerBudget = 5934
$sectionBudget = 1000
$bannedPatterns = [ordered]@{
    'ConcurrentDictionary' = 'ConcurrentDictionary'
    'lock' = '\block\s*[\(\w]'
    'Monitor' = '\bMonitor\.'
    'Interlocked' = '\bInterlocked\.'
    'Promise.Now' = '\bPromise\.Now\.'
    'IVar.Now' = '\bIVar\.Now\.'
    'Hopac.run' = '\bHopac\.run\b|\brun\s*<\|'
    'ThreadLocal' = '\bThreadLocal\b'
    'Thread.Sleep' = '\bThread\.Sleep\b'
    'Stopwatch' = '\bStopwatch\b'
    'DateTime' = '\bDateTime\b'
    'hashing' = '\bSHA256\b|\bMD5\b|\bSHA1\b'
    'choice operator' = '<~>'
    'Alt.chooser' = '\bAlt\.chooser\b'
    'Alt.random' = '\bAlt\.random\b'
    'Job.Random' = '\bJob\.Random\b'
    'Stream.mapPipelined' = '\bStream\.mapPipelined\w*'
    'Scheduler.run' = '\bScheduler\.run\b'
    'ThreadStatic' = '\bThreadStatic\b'
    'blocking primitives' = '\b(ManualResetEvent\w*|SemaphoreSlim|SpinLock|Mutex)\b'
    'new Thread' = '\bnew\s+(System\.Threading\.)?Thread\s*\('
    'replay/record identifiers' = '(?i)\w*(replay|record|resume|snapshot|ledger)\w*'
}
$allowlist = @(
    [pscustomobject]@{ Rule = 'Scheduler.run'; Text = 'Scheduler.run control operation'; Reason = 'D5 2b: the one blocking bridge from a body thread or the peval thread to the control scheduler; never called on a Hopac worker' }
    [pscustomobject]@{ Rule = 'ThreadLocal'; Text = 'new System.Threading.ThreadLocal<BodyContext>()'; Reason = 'D5 2b: body identity for claims; a body thread never migrates; one instance per engine, disposed at Close' }
    [pscustomobject]@{ Rule = 'new Thread'; Text = 'new System.Threading.Thread((fun () -> body_loop ctx), body_stack_bytes)'; Reason = 'D5 2b: dedicated body threads with the 1.5 GB peval stack, joined at Close' }
    [pscustomobject]@{ Rule = 'Stopwatch'; Text = 'let trace_clock, trace_frequency = (fun () -> System.Diagnostics.Stopwatch.GetTimestamp ()), System.Diagnostics.Stopwatch.Frequency'; Reason = 'P3 2026-10-30: the worklist trace clock, read only while SPIRAL_HOPACSOTA_TRACE is set, written to the trace file at Close, never read by a decision' }
)
$layer = [Collections.Generic.List[object]]::new()
$depth = 0
$stack = [Collections.Generic.List[object]]::new()
for ($index = 0; $index -lt $lines.Length; $index++) {
    $bare = $lines[$index].TrimEnd()
    if ($bare -ceq '#if SPIRAL_CORE_HOPACSOTA') { $depth++; $stack.Add(@($depth, $true)); continue }
    if ($stack.Count -and $depth -eq $stack[$stack.Count - 1][0] -and ($bare -ceq '#else' -or $bare -ceq '#endif')) {
        if ($bare -ceq '#else') { $stack[$stack.Count - 1] = @($depth, $false) } else { $stack.RemoveAt($stack.Count - 1); $depth-- }
        continue
    }
    if ($bare -match '^\s*#if\b') { $depth++ } elseif ($bare -match '^\s*#endif\b') { $depth-- }
    if (@($stack | Where-Object { $_[1] }).Count -gt 0) { $layer.Add([pscustomobject]@{ Line = $index + 1; Text = $lines[$index] }) }
}
$failed = $false
if ($Size) {
    $sections = [ordered]@{}
    $current = '(no section)'
    foreach ($entry in $layer) {
        if ($entry.Text -match '^\s*/// ## (.+)$') { $current = $Matches[1].Trim() }
        if (-not $sections.Contains($current)) { $sections[$current] = 0 }
        $sections[$current]++
    }
    $overSections = @($sections.GetEnumerator() | Where-Object { $_.Value -gt $sectionBudget })
    "G1 size: hopacsota layer {0:N0} lines (budget {1:N0}), {2} sections, largest {3:N0} (budget {4:N0})" -f $layer.Count, $layerBudget, $sections.Count, $(if ($sections.Count) { ($sections.Values | Measure-Object -Maximum).Maximum } else { 0 }), $sectionBudget
    foreach ($section in $overSections) { "  over budget: $($section.Key) $($section.Value) lines" }
    if ($layer.Count -gt $layerBudget -or $overSections.Count) { $failed = $true }
}
if ($Banned) {
    $hits = foreach ($entry in $layer) {
        foreach ($rule in $bannedPatterns.GetEnumerator()) {
            if ($entry.Text -match $rule.Value) {
                $allowed = $allowlist | Where-Object { $_.Rule -eq $rule.Key -and $entry.Text.Contains($_.Text) }
                if (-not $allowed) { [pscustomobject]@{ Line = $entry.Line; Rule = $rule.Key; Text = $entry.Text.Trim() } }
            }
        }
    }
    "G2 banned: {0} hits outside the allowlist ({1} allowlisted exceptions)" -f @($hits).Count, $allowlist.Count
    foreach ($hit in $hits | Select-Object -First 40) { "  {0}: {1}: {2}" -f $hit.Line, $hit.Rule, $hit.Text.Substring(0, [Math]::Min(120, $hit.Text.Length)) }
    if (@($hits).Count) { $failed = $true }
}
if ($failed) { exit 1 }
