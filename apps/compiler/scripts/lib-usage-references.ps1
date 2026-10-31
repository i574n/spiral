param(
    [Parameter(Mandatory)] [string] $References,
    [string] $Lib = 'C:\home\git\spiral\lib\spiral',
    [string] $Out = (Join-Path ([IO.Path]::GetTempPath()) 'lib-usage-references.tsv')
)
$ErrorActionPreference = 'Stop'
function Normalize([string] $path) { $path.Replace('file:///', '').Replace('\', '/').ToLowerInvariant() }
$lib = Normalize (Resolve-Path $Lib).Path
$defs = @{}
$uses = @{}
$unresolvedByName = @{}
foreach ($line in [IO.File]::ReadLines($References)) {
    $f = $line.Split("`t")
    if ($f.Length -lt 4) { continue }
    if ($f[0] -eq 'def') {
        $key = "$(Normalize $f[1])`t$($f[2])`t$($f[3])"
        $defs[$key] = $true
    } elseif ($f[0] -eq 'use' -and -not ($f.Length -ge 7 -and $f[4])) {
        $unresolvedByName[$f[3]] = 1 + [int]$unresolvedByName[$f[3]]
    } elseif ($f[0] -eq 'use') {
        $key = "$(Normalize $f[4])`t$($f[5])`t$($f[6])"
        if (-not $uses[$key]) { $uses[$key] = [System.Collections.Generic.HashSet[string]]::new() }
        [void]$uses[$key].Add("$(Normalize $f[1])`t$($f[2])")
    }
}
$rows = foreach ($key in $defs.Keys) {
    $path, $lineNumber, $name = $key.Split("`t")
    if (-not $path.StartsWith($lib)) { continue }
    $sameFile = 0; $libOther = 0; $outside = 0
    foreach ($site in @($uses[$key])) {
        if (-not $site) { continue }
        $usePath = $site.Split("`t")[0]
        if ($usePath -eq $path) { $sameFile++ } elseif ($usePath.StartsWith($lib)) { $libOther++ } else { $outside++ }
    }
    $verdict = if ($sameFile + $libOther + $outside -eq 0) { 'unused' } elseif ($libOther + $outside -eq 0) { 'file-local' } elseif ($outside -eq 0) { 'lib-only' } else { 'used-outside' }
    [pscustomobject]@{ Module = [IO.Path]::GetFileNameWithoutExtension($path); Name = $name; Line = [int]$lineNumber; Verdict = $verdict; SameFile = $sameFile; Lib = $libOther; Outside = $outside }
}
$rows | Sort-Object Module, Line | Export-Csv $Out -Delimiter "`t" -NoTypeInformation
"references census: $(@($rows).Count) lib definitions -> $Out"
$rows | Group-Object Verdict | Sort-Object Count -Descending | ForEach-Object { '  {0,-13} {1,5}' -f $_.Name, $_.Count }
"never-reached lib definitions per module (unused, most first):"
$rows | Where-Object Verdict -eq 'unused' | Group-Object Module | Sort-Object Count -Descending | ForEach-Object {
    $names = ($_.Group | Sort-Object Line | ForEach-Object Name) -join ', '
    '  {0,-22} {1,4}  {2}' -f $_.Name, $_.Count, $(if ($names.Length -gt 160) { $names.Substring(0, 160) + ' ...' } else { $names })
}
$unresolvedTotal =($unresolvedByName.GetEnumerator() | Measure-Object -Property Value -Sum).Sum
"unresolved use rows: $unresolvedTotal over $($unresolvedByName.get_Count()) names; most frequent:"
$unresolvedByName.GetEnumerator() | Sort-Object Value -Descending | Select-Object -First 15 | ForEach-Object { '  {0,-24} {1,6}' -f $_.Key, $_.Value }
