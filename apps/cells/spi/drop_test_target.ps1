param(
    [Parameter(Mandatory)] [string] $Lib,
    [Parameter(Mandatory)] [string] $Target,
    [Parameter(Mandatory)] [string] $Tests,
    [Parameter(Mandatory)] [string] $OutDir,
    [switch] $Add
)
$ErrorActionPreference = 'Stop'
$byFile = @{}
foreach ($pair in ($Tests -split ',' | Where-Object { $_ })) {
    $file, $test = $pair -split '\|', 2
    if (-not $byFile.ContainsKey($file)) { $byFile[$file] = [Collections.Generic.HashSet[string]]::new([StringComparer]::OrdinalIgnoreCase) }
    [void]$byFile[$file].Add($test)
}
$targetLine = "///> $Target"
$total = 0
foreach ($file in $byFile.Keys) {
    $path = Join-Path $Lib $file
    $lines = [Collections.Generic.List[string]][IO.File]::ReadAllLines($path)
    $wanted = $byFile[$file]
    $found = [Collections.Generic.HashSet[string]]::new([StringComparer]::OrdinalIgnoreCase)
    for ($i = $lines.Count - 1; $i -ge 0; $i--) {
        if ($lines[$i] -notmatch '^(?:test|:#)\s+([^\s=]+)') { continue }
        $name = $Matches[1]
        if (-not $wanted.Contains($name)) { continue }
        if ($Add) {
            $j = $i - 1
            $has = $false
            while ($j -ge 0 -and $lines[$j].StartsWith('///')) { if ($lines[$j].Trim() -eq $targetLine) { $has = $true }; $j-- }
            if (-not $has) { $lines.Insert($j + 1, $targetLine); [void]$found.Add($name) }
            continue
        }
        $j = $i - 1
        while ($j -ge 0 -and $lines[$j].StartsWith('///') -and $lines[$j].Trim() -ne $targetLine) { $j-- }
        if ($j -ge 0 -and $lines[$j].Trim() -eq $targetLine) {
            $k = $j + 1
            $groupOnly = $true
            for ($m = $k; $m -lt $i; $m++) { if (-not $lines[$m].StartsWith('///')) { $groupOnly = $false } }
            if ($groupOnly) { $lines.RemoveAt($j); [void]$found.Add($name); $i-- }
        }
    }
    $missing = @($wanted | Where-Object { -not $found.Contains($_) })
    $target = Join-Path $OutDir $file
    New-Item -ItemType Directory -Force (Split-Path $target) | Out-Null
    [IO.File]::WriteAllText($target, (($lines -join "`n") + "`n"))
    $total += $found.Count
    "{0}: {1} {2} of {3}{4}" -f $file, $(if ($Add) { 'added' } else { 'removed' }), $found.Count, $wanted.Count, $(if ($missing) { "; NOT FOUND or already present: $($missing -join ', ')" })
}
"total $(if ($Add) { 'added' } else { 'removed' }) $total"
