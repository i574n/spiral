param(
    [Parameter(Mandatory, Position = 0)] [ValidateSet('status', 'import', 'export')] [string] $Command,
    [Parameter(Mandatory, Position = 1)] [string] $Fork,
    [Parameter(Position = 2)] [string] $Ref,
    [Parameter(Position = 3)] [string] $Target,
    [string] $Since,
    [string] $Until,
    [string] $Core = (Join-Path $PSScriptRoot '../spiral_compiler.fs')
)
$ErrorActionPreference = 'Stop'
$Core = [IO.Path]::GetFullPath($Core)
$directory = 'The Spiral Language 2'
$fileOf = @{ SignalRSupervisor = 'Supervisor.fs' }
$indentText = '    '
$utf8 = [Text.UTF8Encoding]::new($false)

if (-not ('SpiralSequenceMatcher' -as [type])) {
    Add-Type -TypeDefinition @'
using System;
using System.Collections.Generic;
public static class SpiralSequenceMatcher {
    static int[] Longest(string[] a, string[] b, Dictionary<string, List<int>> b2j, int alo, int ahi, int blo, int bhi) {
        int besti = alo, bestj = blo, bestsize = 0;
        var j2len = new Dictionary<int, int>();
        var nothing = new List<int>();
        for (int i = alo; i < ahi; i++) {
            var newj2len = new Dictionary<int, int>();
            List<int> js;
            if (!b2j.TryGetValue(a[i], out js)) js = nothing;
            foreach (int j in js) {
                if (j < blo) continue;
                if (j >= bhi) break;
                int prev;
                int k = (j2len.TryGetValue(j - 1, out prev) ? prev : 0) + 1;
                newj2len[j] = k;
                if (k > bestsize) { besti = i - k + 1; bestj = j - k + 1; bestsize = k; }
            }
            j2len = newj2len;
        }
        while (besti > alo && bestj > blo && a[besti - 1] == b[bestj - 1]) { besti--; bestj--; bestsize++; }
        while (besti + bestsize < ahi && bestj + bestsize < bhi && a[besti + bestsize] == b[bestj + bestsize]) bestsize++;
        return new[] { besti, bestj, bestsize };
    }
    public static List<int[]> MatchingBlocks(string[] a, string[] b) {
        var b2j = new Dictionary<string, List<int>>(StringComparer.Ordinal);
        for (int i = 0; i < b.Length; i++) {
            List<int> list;
            if (!b2j.TryGetValue(b[i], out list)) { list = new List<int>(); b2j[b[i]] = list; }
            list.Add(i);
        }
        var queue = new List<int[]> { new[] { 0, a.Length, 0, b.Length } };
        var blocks = new List<int[]>();
        while (queue.Count > 0) {
            var q = queue[queue.Count - 1]; queue.RemoveAt(queue.Count - 1);
            var x = Longest(a, b, b2j, q[0], q[1], q[2], q[3]);
            int i = x[0], j = x[1], k = x[2];
            if (k > 0) {
                blocks.Add(x);
                if (q[0] < i && q[2] < j) queue.Add(new[] { q[0], i, q[2], j });
                if (i + k < q[1] && j + k < q[3]) queue.Add(new[] { i + k, q[1], j + k, q[3] });
            }
        }
        blocks.Sort((p, r) => p[0] != r[0] ? p[0].CompareTo(r[0]) : p[1] != r[1] ? p[1].CompareTo(r[1]) : p[2].CompareTo(r[2]));
        var merged = new List<int[]>();
        int i1 = 0, j1 = 0, k1 = 0;
        foreach (var blk in blocks) {
            if (i1 + k1 == blk[0] && j1 + k1 == blk[1]) k1 += blk[2];
            else { if (k1 > 0) merged.Add(new[] { i1, j1, k1 }); i1 = blk[0]; j1 = blk[1]; k1 = blk[2]; }
        }
        if (k1 > 0) merged.Add(new[] { i1, j1, k1 });
        merged.Add(new[] { a.Length, b.Length, 0 });
        return merged;
    }
    public static List<object[]> Opcodes(string[] a, string[] b) {
        var answer = new List<object[]>();
        int i = 0, j = 0;
        foreach (var blk in MatchingBlocks(a, b)) {
            int ai = blk[0], bj = blk[1], size = blk[2];
            string tag = i < ai && j < bj ? "replace" : i < ai ? "delete" : j < bj ? "insert" : "";
            if (tag != "") answer.Add(new object[] { tag, i, ai, j, bj });
            i = ai + size; j = bj + size;
            if (size > 0) answer.Add(new object[] { "equal", ai, i, bj, j });
        }
        return answer;
    }
}
'@
}

$ordinal = [StringComparison]::Ordinal
$space = [char[]] @(9, 10, 11, 12, 13, 28, 29, 30, 31, 32, 0x85, 0xA0, 0x1680, 0x2000, 0x2001, 0x2002, 0x2003, 0x2004, 0x2005, 0x2006, 0x2007, 0x2008, 0x2009, 0x200A, 0x2028, 0x2029, 0x202F, 0x205F, 0x3000)
function Test-Skipped([string] $line) {
    $s = $line.Trim($space).TrimStart([char]0xFEFF)
    (-not $s) -or $s.StartsWith('/// ### ', $ordinal) -or $s.StartsWith('/// ## ', $ordinal) -or $s.StartsWith('// #!import', $ordinal) -or ($line.TrimStart([char]0xFEFF).StartsWith('module ', $ordinal) -and -not $s.EndsWith('=', $ordinal))
}
function Get-Normalized([string[]] $lines) {
    $keys = [Collections.Generic.List[string]]::new(); $index = [Collections.Generic.List[int]]::new()
    for ($i = 0; $i -lt $lines.Count; $i++) { if (-not (Test-Skipped $lines[$i])) { $keys.Add($lines[$i].Trim($space)); $index.Add($i) } }
    [pscustomobject]@{ Keys = [string[]] $keys.ToArray(); Index = [int[]] $index.ToArray() }
}
function Invoke-Git([string] $repo, [string[]] $arguments) {
    $start = [Diagnostics.ProcessStartInfo]::new('git'); $start.RedirectStandardOutput = $true; $start.RedirectStandardError = $true; $start.UseShellExecute = $false
    foreach ($a in @('-C', $repo) + $arguments) { $start.ArgumentList.Add($a) }
    $p = [Diagnostics.Process]::Start($start)
    $errTask = $p.StandardError.ReadToEndAsync()
    $bytes = [IO.MemoryStream]::new(); $p.StandardOutput.BaseStream.CopyTo($bytes); $p.WaitForExit(); $null = $errTask.Result
    if ($p.ExitCode -eq 0) { $utf8.GetString($bytes.ToArray()) } else { $null }
}
function Get-ForkText([string] $ref, [string] $name) {
    $file = if ($fileOf.ContainsKey($name)) { $fileOf[$name] } else { "$name.fs" }
    Invoke-Git $Fork @('show', "${ref}:$directory/$file")
}
function Get-ForkFile([string] $ref, [string] $name) { $t = Get-ForkText $ref $name; if ($null -eq $t) { $null } else { , $t.Replace("`r`n", "`n").Split("`n") } }
function Get-Sections([string[]] $lines) {
    $result = [ordered]@{}; $state = $null; $start = $null; $name = $null; $depth = 0
    for ($index = 0; $index -lt $lines.Count; $index++) {
        $line = $lines[$index]
        if ($line -ceq '#if SPIRAL_CORE_GPT5PARALLEL' -and -not $state) {
            if ($null -ne $name -and $null -ne $start) { $result[$name] = @($start, $index) }
            $name = $null; $start = $null; $state = 'hopac'; $depth = 0; continue
        }
        if ($state -and $line.StartsWith('#if', $ordinal)) { $depth++ }
        elseif ($state -and $depth -gt 0 -and $line -ceq '#endif') { $depth-- }
        elseif ($state -and $depth -eq 0 -and $line -ceq '#else') { $state = 'single'; continue }
        elseif ($state -and $depth -eq 0 -and $line -ceq '#endif') {
            if ($null -ne $name -and $null -ne $start) { $result[$name] = @($start, $index) }
            $name = $null; $start = $null; $state = $null; continue
        }
        if ($state -eq 'hopac') { continue }
        if ($line -match '^\s*/// ## (.+?)\s*$') {
            if ($null -ne $name -and $null -ne $start) { $result[$name] = @($start, $index) }
            $name = $Matches[1]; $start = $index
        }
    }
    if ($null -ne $name -and $null -ne $start) { $result[$name] = @($start, $lines.Count) }
    $result
}
function Get-Slice([string[]] $lines, [int] $from, [int] $to) { if ($to -gt $from) { $lines[$from..($to - 1)] } }
function Test-Heading([string] $line) { $s = $line.Trim($space); $s.StartsWith('/// ### ', $ordinal) -or $s.StartsWith('/// ## ', $ordinal) -or $s.StartsWith('// #!import', $ordinal) }
function Invoke-Transfer([string[]] $old, [string[]] $new, [string[]] $target, [scriptblock] $reindent) {
    $o = Get-Normalized $old; $n = Get-Normalized $new; $t = Get-Normalized $target
    $toTarget = @{}
    foreach ($blk in [SpiralSequenceMatcher]::MatchingBlocks($o.Keys, $t.Keys)) { for ($k = 0; $k -lt $blk[2]; $k++) { $toTarget[$blk[0] + $k] = $blk[1] + $k } }
    $edits = [Collections.Generic.List[object]]::new(); $conflicts = [Collections.Generic.List[string]]::new()
    foreach ($op in [SpiralSequenceMatcher]::Opcodes($o.Keys, $n.Keys)) {
        $tag, $i1, $i2, $j1, $j2 = $op
        if ($tag -eq 'equal') { continue }
        $replacement = if ($j2 -gt $j1) { @(Get-Slice $new $n.Index[$j1] ($n.Index[$j2 - 1] + 1) | ForEach-Object { & $reindent $_ }) } else { @() }
        $replacement = @($replacement | Where-Object { -not (Test-Heading $_) })
        if ($i2 -gt $i1) {
            $mapped = @(for ($i = $i1; $i -lt $i2; $i++) { if ($toTarget.ContainsKey($i)) { $toTarget[$i] } else { $null } })
            $consecutive = $null -notin $mapped
            if ($consecutive) { for ($k = 1; $k -lt $mapped.Count; $k++) { if ($mapped[$k] -ne $mapped[0] + $k) { $consecutive = $false; break } } }
            if (-not $consecutive) { $conflicts.Add("lines changed on both sides near: $($o.Keys[$i1].Substring(0, [Math]::Min(80, $o.Keys[$i1].Length)))"); continue }
            $edits.Add([pscustomobject]@{ Start = $t.Index[$mapped[0]]; End = $t.Index[$mapped[-1]] + 1; Lines = $replacement })
        } else {
            if ($o.Keys.Count -and $i1 -eq $o.Keys.Count) {
                $at = $target.Count
                while ($at -gt 0 -and -not $target[$at - 1].Trim($space)) { $at-- }
                $replacement = @('') + $replacement
            } elseif ($i1 -gt 0 -and $toTarget.ContainsKey($i1 - 1)) { $at = $t.Index[$toTarget[$i1 - 1]] + 1 }
            elseif ($i1 -lt $o.Keys.Count -and $toTarget.ContainsKey($i1)) { $at = $t.Index[$toTarget[$i1]] }
            elseif (-not $o.Keys.Count) { $at = $target.Count }
            else { $conflicts.Add("insertion point changed on both sides near: $($n.Keys[$j1].Substring(0, [Math]::Min(80, $n.Keys[$j1].Length)))"); continue }
            $edits.Add([pscustomobject]@{ Start = $at; End = $at; Lines = $replacement })
        }
    }
    $result = [Collections.Generic.List[string]]::new([string[]] $target)
    foreach ($e in @($edits | Sort-Object Start -Descending -Stable)) {
        $result.RemoveRange($e.Start, $e.End - $e.Start)
        $result.InsertRange($e.Start, [string[]] @($e.Lines))
    }
    [pscustomobject]@{ Lines = [string[]] $result.ToArray(); Conflicts = $conflicts }
}
function Get-Indented([string] $line) { if ($line.Trim($space)) { $indentText + $line } else { $line } }
function Get-Dedented([string] $line) { if ($line.StartsWith($indentText, $ordinal)) { $line.Substring($indentText.Length) } elseif (-not $line.Trim($space)) { $line.TrimStart($space) } else { $line } }
function Get-CoreLines { , [IO.File]::ReadAllText($Core).Split("`n") }
function Get-CoreAt([string] $ref) {
    $root = (Invoke-Git (Split-Path $Core) @('rev-parse', '--show-toplevel')).Trim($space)
    $path = [IO.Path]::GetRelativePath($root, $Core).Replace('\', '/')
    $text = Invoke-Git $root @('show', "${ref}:$path")
    if ($null -eq $text) { throw "$path not found at $ref" }
    , $text.Split("`n")
}
function Get-IndentShift([string[]] $section, [string[]] $forkLines) {
    $s = Get-Normalized $section; $f = Get-Normalized $forkLines
    $counts = [ordered]@{}
    foreach ($blk in [SpiralSequenceMatcher]::MatchingBlocks($s.Keys, $f.Keys)) {
        for ($k = 0; $k -lt $blk[2]; $k++) {
            $a = $section[$s.Index[$blk[0] + $k]]; $b = $forkLines[$f.Index[$blk[1] + $k]]
            $delta = ($a.Length - $a.TrimStart(' ').Length) - ($b.Length - $b.TrimStart(' ').Length)
            $counts[[string]$delta] = $(if ($counts.Contains([string]$delta)) { $counts[[string]$delta] } else { 0 }) + 1
        }
    }
    if (-not $counts.Count) { return 0 }
    $best = $null; foreach ($key in $counts.Keys) { if ($null -eq $best -or $counts[$key] -gt $counts[$best]) { $best = $key } }
    [Math]::Max(0, [int]$best)
}

switch ($Command) {
    'status' {
        $lines = Get-CoreLines
        $total = 0
        $sections = Get-Sections $lines
        foreach ($name in $sections.Keys) {
            $upstream = Get-ForkFile $(if ($Ref) { $Ref } else { 'HEAD' }) $name
            if ($null -eq $upstream) { continue }
            $span = $sections[$name]
            $a = (Get-Normalized @(Get-Slice $lines $span[0] $span[1])).Keys; $b = (Get-Normalized $upstream).Keys
            $same = 0; foreach ($blk in [SpiralSequenceMatcher]::MatchingBlocks($a, $b)) { $same += $blk[2] }
            $total += $a.Count - $same + $b.Count - $same
            '{0,-26} section-only {1,5}  fork-only {2,5}' -f $name, ($a.Count - $same), ($b.Count - $same)
        }
        "total differing lines: $total"
    }
    'import' {
        if (-not $Ref -or -not $Target) { throw 'usage: upstream.ps1 import <fork> <old-ref> <new-ref>' }
        $lines = Get-CoreLines
        $changed = @("$(Invoke-Git $Fork @('diff', '--name-only', $Ref, $Target, '--', $directory))".Split("`n") | Where-Object { $_.EndsWith('.fs') } | ForEach-Object { [IO.Path]::GetFileName($_) })
        $spans = Get-Sections $lines
        $edits = [Collections.Generic.List[object]]::new()
        foreach ($name in $spans.Keys) {
            $start, $end = $spans[$name]
            if ($(if ($fileOf.ContainsKey($name)) { $fileOf[$name] } else { "$name.fs" }) -notin $changed) { continue }
            $old = Get-ForkFile $Ref $name; $new = Get-ForkFile $Target $name
            if ($null -eq $old -or $null -eq $new) { "${name}: file added or removed upstream; carry it by hand"; continue }
            $r = Invoke-Transfer $old $new @(Get-Slice $lines $start $end) ${function:Get-Indented}
            foreach ($c in $r.Conflicts) { "${name}: CONFLICT $c" }
            $pair = $start -gt 0 -and $lines[$start - 1] -ceq '#else'
            "${name}: $($r.Conflicts.Count) conflicts$(if ($pair) { ' (a pair: hopac''s side not updated)' })"
            $edits.Add([pscustomobject]@{ Start = $start; End = $end; Lines = $r.Lines })
        }
        $list = [Collections.Generic.List[string]]::new([string[]] $lines)
        foreach ($e in @($edits | Sort-Object Start, End -Descending)) { $list.RemoveRange($e.Start, $e.End - $e.Start); $list.InsertRange($e.Start, [string[]] $e.Lines) }
        [IO.File]::WriteAllText($Core, ($list -join "`n"), $utf8)
    }
    'export' {
        if (-not $Ref -or -not $Target) { throw 'usage: upstream.ps1 export <fork> <base-ref> <out-dir> [-Since <ref>] [-Until <ref>]' }
        $out = $Target
        $lines = if ($Until) { Get-CoreAt $Until } else { Get-CoreLines }
        if ($Since) { $oldLines = Get-CoreAt $Since; $oldSpans = Get-Sections $oldLines }
        $spans = Get-Sections $lines
        foreach ($name in $spans.Keys) {
            $base = Get-ForkFile $Ref $name
            if ($null -eq $base) { continue }
            $start, $end = $spans[$name]
            $section = [string[]] @(Get-Slice $lines $start $end | ForEach-Object { Get-Dedented $_ })
            if ($Since) {
                if (-not $oldSpans.Contains($name)) { "${name}: not in the core at $Since; skipped"; continue }
                $os, $oe = $oldSpans[$name]
                $old = [string[]] @(Get-Slice $oldLines $os $oe | ForEach-Object { Get-Dedented $_ })
                if (((Get-Normalized $old).Keys -join "`n") -ceq ((Get-Normalized $section).Keys -join "`n") -and (Get-Normalized $old).Keys.Count -eq (Get-Normalized $section).Keys.Count) { continue }
                $shift = Get-IndentShift $old $base
                $r = Invoke-Transfer $old $section $base { param($line) if ($line.Substring(0, [Math]::Min($shift, $line.Length)).Trim($space) -eq '') { $line.Substring([Math]::Min($shift, $line.Length)) } else { $line.TrimStart($space) } }.GetNewClosure()
            } else {
                $r = Invoke-Transfer $base $section $base { param($line) $line }
            }
            foreach ($c in $r.Conflicts) { "${name}: CONFLICT $c" }
            $path = Join-Path (Join-Path $out $directory) $(if ($fileOf.ContainsKey($name)) { $fileOf[$name] } else { "$name.fs" })
            New-Item -ItemType Directory -Force (Split-Path $path) | Out-Null
            $newline = if ("$(Get-ForkText $Ref $name)".Contains("`r`n")) { "`r`n" } else { "`n" }
            [IO.File]::WriteAllText($path, ($r.Lines -join $newline), $utf8)
        }
        "wrote the fork's files with the sections' edits under $out"
    }
}
