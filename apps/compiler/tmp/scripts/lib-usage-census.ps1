param(
    [string] $Lib = 'C:\home\git\spiral\lib\spiral',
    [string[]] $Repos = @('C:\home\git\spiral', 'C:\home\git\eoie', 'C:\home\git\polyglot', 'C:\home\git\dice', 'C:\home\git\alphabet', 'C:\home\git\x', 'C:\home\git\tibia'),
    [string] $Out = (Join-Path ([IO.Path]::GetTempPath()) 'lib-usage-census.tsv')
)
$ErrorActionPreference = 'Stop'
$identifier = "(?<![\w'])([A-Za-z_][\w']*)(?:\.([A-Za-z_][\w']*))?"

function Get-LibModules([string] $root) {
    $lines = [IO.File]::ReadAllLines((Join-Path $root 'package.spiproj'))
    $inModules = $false
    $stack = [System.Collections.Generic.List[object]]::new()
    foreach ($line in $lines) {
        if ($line -match '^modules:') { $inModules = $true; continue }
        if ($line -match '^\S') { $inModules = $false }
        if (-not $inModules -or -not $line.Trim()) { continue }
        $depth = ($line.Length - $line.TrimStart().Length) / 4
        while ($stack.Count -ge $depth) { $stack.RemoveAt($stack.Count - 1) }
        $entry = $line.Trim()
        if ($entry.EndsWith('/')) { $stack.Add($entry.TrimEnd('/')); continue }
        $flat = $entry.EndsWith('-')
        $stem = $entry.TrimEnd('-', '*')
        $relative = (@($stack) + $stem) -join '/'
        $file = @('.spi', '.spir') | ForEach-Object { Join-Path $root "$relative$_" } | Where-Object { Test-Path $_ } | Select-Object -First 1
        if ($file) { [pscustomobject]@{ Module = $stem; Path = $file; Flat = $flat } }
    }
}

function Get-Definitions([string] $path) {
    $lines = [IO.File]::ReadAllLines($path)
    for ($i = 0; $i -lt $lines.Length; $i++) {
        if ($lines[$i] -match "^(?:and\s+)?(?:inl|let)(?:\s+rec)?\s+(\([^)\s]+\)|[A-Za-z_][\w']*)") {
            $name = $Matches[1]
            if ($name -ne 'main') { [pscustomobject]@{ Name = $name.Trim('(', ')'); Operator = $name.StartsWith('('); Line = $i + 1 } }
        }
    }
}

function Get-FileIndex([string] $path) {
    $lines = [IO.File]::ReadAllLines($path)
    $plain = [hashtable]::new([StringComparer]::Ordinal)
    $qualified = [hashtable]::new([StringComparer]::Ordinal)
    $opens = [System.Collections.Generic.HashSet[string]]::new()
    $inTest = $false
    for ($i = 0; $i -lt $lines.Length; $i++) {
        $line = $lines[$i]
        if ($line -match '^\S') { $inTest = $line -match '^test\s' }
        if ($line -match '^\s*open\s+(\S+)') { [void]$opens.Add($Matches[1]) }
        $code = $line -replace '//.*$', ''
        $kind = if ($inTest) { 'test' } else { 'code' }
        foreach ($m in [regex]::Matches($code, $identifier)) {
            $head = $m.Groups[1].Value
            if ($m.Groups[2].Success) {
                $key = "$head.$($m.Groups[2].Value)"
                if (-not $qualified[$key]) { $qualified[$key] = [System.Collections.Generic.List[object]]::new() }
                $qualified[$key].Add([pscustomobject]@{ Line = $i + 1; Kind = $kind })
            }
            if (-not $plain[$head]) { $plain[$head] = [System.Collections.Generic.List[object]]::new() }
            $plain[$head].Add([pscustomobject]@{ Line = $i + 1; Kind = $kind })
        }
    }
    $words = [hashtable]::new([StringComparer]::Ordinal)
    foreach ($word in ($lines -join " ") -split '\s+') { if ($word) { $words[$word] = 1 + [int]$words[$word] } }
    [pscustomobject]@{ Path = $path; Plain = $plain; Qualified = $qualified; Opens = $opens; Words = $words }
}

$watch = [Diagnostics.Stopwatch]::StartNew()
$modules = @(Get-LibModules $Lib)
$sources = foreach ($repo in $Repos) {
    if (-not (Test-Path $repo)) { continue }
    $tracked = git -C $repo ls-files -- '*.spi' '*.spir' 2>$null
    foreach ($relative in $tracked) {
        $full = Join-Path $repo $relative
        if ($full -match '[\\/](deps|target|\.history)[\\/]' -or -not (Test-Path -LiteralPath $full)) { continue }
        $full
    }
}
$index = @($sources | Sort-Object -Unique | ForEach-Object { Get-FileIndex $_ })
$libFull = (Resolve-Path $Lib).Path
$rows = foreach ($module in $modules) {
    foreach ($def in @(Get-Definitions $module.Path)) {
        $sameFile = 0; $libCode = 0; $outsideCode = 0; $testUses = 0; $files = [System.Collections.Generic.HashSet[string]]::new()
        foreach ($file in $index) {
            $hits = [System.Collections.Generic.List[object]]::new()
            if ($def.Operator) {
                $count = [int]$file.Words[$def.Name]
                for ($k = 0; $k -lt $count; $k++) { $hits.Add([pscustomobject]@{ Line = 0; Kind = 'code' }) }
            } else {
                $q = $file.Qualified["$($module.Module).$($def.Name)"]
                if ($q) { $hits.AddRange($q) }
                $visible = $file.Path -eq $module.Path -or $module.Flat -or $file.Opens.Contains($module.Module) -or $file.Opens.Contains("$($module.Module)_operators")
                if ($visible -and $file.Plain[$def.Name]) { foreach ($h in $file.Plain[$def.Name]) { if (-not ($file.Path -eq $module.Path -and $h.Line -eq $def.Line)) { $hits.Add($h) } } }
            }
            if (-not $hits.Count) { continue }
            [void]$files.Add($file.Path)
            foreach ($h in $hits) {
                if ($h.Kind -eq 'test') { $testUses++ }
                elseif ($file.Path -eq $module.Path) { $sameFile++ }
                elseif ($file.Path.StartsWith($libFull)) { $libCode++ }
                else { $outsideCode++ }
            }
        }
        $verdict = if ($sameFile + $libCode + $outsideCode + $testUses -eq 0) { 'unused' } elseif ($sameFile + $libCode + $outsideCode -eq 0) { 'tests-only' } elseif ($libCode + $outsideCode -eq 0) { 'file-local' } elseif ($outsideCode -eq 0) { 'lib-only' } else { 'used-outside' }
        [pscustomobject]@{ Module = $module.Module; Name = $def.Name; Line = $def.Line; Verdict = $verdict; SameFile = $sameFile; Lib = $libCode; Outside = $outsideCode; Tests = $testUses; Files = $files.Count }
    }
}
$rows | Export-Csv $Out -Delimiter "`t" -NoTypeInformation
"census: $(@($rows).Count) definitions in $($modules.Count) modules, $($index.Count) source files, $([int]$watch.Elapsed.TotalSeconds) s -> $Out"
$rows | Group-Object Verdict | Sort-Object Count -Descending | ForEach-Object { '  {0,-13} {1,5}' -f $_.Name, $_.Count }
