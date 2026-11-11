param(
    [Parameter(Mandatory)] [string] $Dll,
    [string] $Work = (Join-Path $env:LOCALAPPDATA 'spiral-bin\candidates\formatter-gate'),
    [string[]] $Consumers = @(),
    [string] $ComplaintCorpus = 'dice'
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot '..\env.ps1')
$dotnet = Resolve-SpiralDotnet
$installed = Get-SpiralCompilerDll single-flight
New-Item -ItemType Directory -Force $Work | Out-Null
Get-ChildItem $Work -Directory | Where-Object Name -match '-(installed|candidate)(-again)?$' | Remove-Item -Recurse -Force
Get-ChildItem $Work -Filter 'review-*.diff' | Remove-Item -Force
$env:SPIRAL_FORMAT_PARALLEL = '1'
$corpora = [ordered]@{}
$corpora.user = Join-Path $Work 'corpus-user'
$corpora.lib = Join-Path $Work 'corpus-lib-head'
if (-not (Test-Path $corpora.user)) { pwsh -NoProfile -File (Join-Path $PSScriptRoot 'extract-corpus.ps1') -Out $corpora.user -Which user | Out-Null }
if (-not (Test-Path $corpora.lib)) { pwsh -NoProfile -File (Join-Path $PSScriptRoot 'extract-corpus.ps1') -Out $corpora.lib -Which lib-head | Out-Null }
$corpora.synthetic = Join-Path $PSScriptRoot 'synthetic'
foreach ($consumer in $Consumers) {
    if ($consumer -notmatch '^(?<name>[\w-]+)=(?<repo>.+):(?<paths>[^:]+)$') { throw "consumer '$consumer': expected <name>=<repo dir>:<path>[,<path>...]" }
    $name = $Matches.name; $repo = $Matches.repo; $paths = $Matches.paths -split ','
    $dir = Join-Path $Work "corpus-$name"
    if (-not $corpora.Contains($name)) {
        if (Test-Path $dir) { Remove-Item -Recurse -Force $dir }
        New-Item -ItemType Directory $dir | Out-Null
        $corpora[$name] = $dir
    }
    $quoted = ($paths | ForEach-Object { '"' + $_ + '"' }) -join ' '
    cmd /c "git -C `"$repo`" archive --format=tar HEAD -- $quoted | tar -x -C `"$dir`""
    if ($LASTEXITCODE) { throw "consumer '$consumer': extracting HEAD failed" }
    Get-ChildItem $dir -Recurse -File | Where-Object Extension -ne '.spi' | Remove-Item -Force
}
function Get-Squeezed([string] $text) { [regex]::Replace([regex]::Replace($text, '"\s*\^\^\s*"', ''), '[\s\(\)\\]', '') }
$verdict = $true
foreach ($name in $corpora.Keys) {
    $outputs = @{}
    foreach ($side in 'installed', 'candidate') {
        $copy = Join-Path $Work "$name-$side"
        New-Item -ItemType Directory $copy | Out-Null
        Copy-Item -Path (Join-Path $corpora[$name] '*') -Destination $copy -Recurse
        $watch = [Diagnostics.Stopwatch]::StartNew()
        & $dotnet $(if ($side -eq 'installed') { $installed } else { $Dll }) format $copy 2>&1 | Out-Null
        $outputs[$side] = [pscustomobject]@{ Dir = $copy; Seconds = [math]::Round($watch.Elapsed.TotalSeconds, 1); Exit = $LASTEXITCODE }
    }
    $files = @(Get-ChildItem $outputs.installed.Dir -Recurse -File -Filter *.spi)
    $differing = @(); $tokenChanges = @()
    foreach ($file in $files) {
        $rel = $file.FullName.Substring($outputs.installed.Dir.Length)
        $a = [IO.File]::ReadAllText($file.FullName); $b = [IO.File]::ReadAllText((Join-Path $outputs.candidate.Dir $rel))
        if ($a -ne $b) {
            $differing += $rel
            if ((Get-Squeezed $a) -ne (Get-Squeezed $b)) { $tokenChanges += $rel }
        }
    }
    "== $name ($($files.Count) files): installed $($outputs.installed.Seconds) s exit $($outputs.installed.Exit), candidate $($outputs.candidate.Seconds) s exit $($outputs.candidate.Exit); differing $($differing.Count); differing beyond parentheses and whitespace $($tokenChanges.Count)"
    $differing | Select-Object -First 25 | ForEach-Object { "  differs: $_" }
    foreach ($d in $differing) { git --no-pager diff --no-index -U1 (Join-Path $outputs.installed.Dir $d) (Join-Path $outputs.candidate.Dir $d) 2>$null | Out-File -Append -Encoding utf8 (Join-Path $Work "review-$name.diff") }
    $tokenChanges | ForEach-Object { "  TOKEN CHANGE: $_" }
    if ($tokenChanges.Count -or ($outputs.candidate.Exit -ne $outputs.installed.Exit -and $outputs.candidate.Exit -ne 0)) { $verdict = $false }
    $unstable = @{}
    foreach ($side in 'installed', 'candidate') {
        $again = Join-Path $Work "$name-$side-again"
        New-Item -ItemType Directory $again | Out-Null
        Copy-Item -Path (Join-Path $outputs[$side].Dir '*') -Destination $again -Recurse
        & $dotnet $(if ($side -eq 'installed') { $installed } else { $Dll }) format $again 2>&1 | Out-Null
        $unstable[$side] = @($files | ForEach-Object { $_.FullName.Substring($outputs.installed.Dir.Length) } | Where-Object { [IO.File]::ReadAllText((Join-Path $outputs[$side].Dir $_)) -ne [IO.File]::ReadAllText((Join-Path $again $_)) })
    }
    $newlyUnstable = @($unstable.candidate | Where-Object { $_ -notin $unstable.installed })
    "== $name second pass: files a second format changes, installed $($unstable.installed.Count), candidate $($unstable.candidate.Count), newly unstable $($newlyUnstable.Count)"
    $unstable.candidate | Select-Object -First 25 | ForEach-Object { "  NOT A FIXPOINT: $_" }
    if ($newlyUnstable.Count -or ($name -eq 'synthetic' -and $unstable.candidate.Count)) { $verdict = $false }
}
function Get-FittingLinesKept([string] $sourceRoot, [string] $outputRoot) {
    $sourceRoot = (Resolve-Path $sourceRoot).Path
    $kinds = [ordered]@{}; $examples = @{}; $checked = 0
    foreach ($source in @(Get-ChildItem $sourceRoot -Recurse -Filter *.spi -File | Sort-Object { $_.FullName.ToLowerInvariant() })) {
        $relative = $source.FullName.Substring($sourceRoot.TrimEnd('\', '/').Length + 1)
        $output = Join-Path $outputRoot $relative
        if (-not (Test-Path -LiteralPath $output)) { continue }
        $authored = [IO.File]::ReadAllText($source.FullName).Replace("`r`n", "`n").Split("`n")
        $laid = [Collections.Generic.HashSet[string]]::new([string[]] @([IO.File]::ReadAllText($output).Replace("`r`n", "`n").Split("`n") | ForEach-Object { $_.Trim() }))
        for ($i = 0; $i -lt $authored.Count; $i++) {
            $line = $authored[$i]; $text = $line.Trim()
            if (-not $text -or $line.Length -gt 120 -or $text.StartsWith('//')) { continue }
            $checked++
            if ($laid.Contains($text)) { continue }
            $kind = if ($text.StartsWith('(') -or $text.EndsWith(')') -or $text.Contains('(join')) { 'parentheses changed' }
                elseif ($text.StartsWith('then') -or $text.EndsWith('then')) { 'then moved' }
                elseif ($text.EndsWith('\') -or $text.Contains("`$'") -or $text.Contains('$"')) { 'macro continuation' }
                else { 'other' }
            if (-not $kinds.Contains($kind)) { $kinds[$kind] = 0; $examples[$kind] = [Collections.Generic.List[string]]::new() }
            $kinds[$kind]++
            $examples[$kind].Add("${relative}:$($i + 1): $($text.Substring(0, [Math]::Min(100, $text.Length)))")
        }
    }
    "fitting authored lines checked $checked, not kept verbatim $(($kinds.Values | Measure-Object -Sum).Sum + 0)"
    foreach ($kind in @($kinds.Keys | Sort-Object { -$kinds[$_] } -Stable)) {
        "  {0,5} {1}" -f $kinds[$kind], $kind
        $examples[$kind] | Select-Object -First 3 | ForEach-Object { "        $_" }
    }
}
function Get-FormatComplaints([string[]] $files) {
    $failed = $false
    $lines = foreach ($path in $files) {
        $code = [Collections.Generic.List[object]]::new(); $insideMacro = $false; $number = 0
        foreach ($line in [IO.File]::ReadAllText($path).Replace("`r`n", "`n").Split("`n")) {
            $number++
            $stripped = $line.Trim()
            $quotes = if ($line.Contains("`$'") -or $insideMacro) { ($line.ToCharArray() | Where-Object { $_ -eq "'" }).Count } else { 0 }
            if (-not $insideMacro -and $stripped -and -not $stripped.StartsWith('//')) { $code.Add([pscustomobject]@{ N = $number; L = $line }) }
            if ($quotes % 2) { $insideMacro = -not $insideMacro }
        }
        $parens = [Collections.Generic.List[object]]::new()
        foreach ($c in $code) { if ($c.L -match '^\s*\(join\b.*\)\s*$') { $parens.Add($c) } }
        for ($i = 0; $i + 1 -lt $code.Count; $i++) { if ($code[$i].L -match '^\s*\($' -and $code[$i + 1].L -match '^\s*join\b') { $parens.Add($code[$i]) } }
        $offGrid = @($code | Where-Object { ($_.L.Length - $_.L.TrimStart(' ').Length) % 4 })
        $leads = @($code | Where-Object { $_.L -match '^\s*then\b' }).Count
        $trails = @($code | Where-Object { $_.L -match '\bthen\s*$' -and -not $_.L.TrimStart().StartsWith('|') }).Count
        "$([IO.Path]::GetFileName($path)): (join heads $($parens.Count), off-grid lines $($offGrid.Count), then leading $leads trailing $trails"
        @($parens) + @($offGrid) | Select-Object -First 12 | ForEach-Object { $t = $_.L.TrimEnd(); "    $($_.N): $($t.Substring(0, [Math]::Min(110, $t.Length)))" }
        if ($parens.Count -or $offGrid.Count) { $failed = $true }
    }
    [pscustomobject]@{ Lines = @($lines); Failed = $failed }
}
foreach ($name in $corpora.Keys) {
    $counts = foreach ($side in 'installed', 'candidate') {
        $census = @(Get-FittingLinesKept $corpora[$name] (Join-Path $Work "$name-$side"))
        $thenMoved = [regex]::Match(($census -join "`n"), '(?m)^\s+(\d+) then moved$')
        "$side $(([regex]::Match([string]$census[0], 'not kept verbatim (\d+)')).Groups[1].Value) (then moved $(if ($thenMoved.Success) { $thenMoved.Groups[1].Value } else { 0 }))"
    }
    "== fitting authored lines not kept verbatim, $name`: $($counts -join ', ') (informational: parentheses the candidate drops on purpose count too)"
}
if ($corpora.Contains($ComplaintCorpus)) {
    $complaintFiles = @(Get-ChildItem (Join-Path $Work "$ComplaintCorpus-candidate") -Recurse -Filter *.spi | ForEach-Object FullName)
    $complaints = Get-FormatComplaints $complaintFiles
    $complaints.Lines | ForEach-Object { if ($_.StartsWith(' ')) { "  $_" } else { "== complaints $_" } }
    if ($complaints.Failed) { $verdict = $false }
}
function Get-JoinedAuthoredLines([string] $diffPath) {
    $removed = @(); $added = @(); $file = ''
    $flush = {
        if ($removed.Count -gt 1 -and -not ($removed | Where-Object { $_.Length -gt 121 })) {
            $starts = $added | ForEach-Object { $_.Substring(1).TrimStart() }
            foreach ($authored in $removed | Select-Object -Skip 1 | ForEach-Object { $_.Substring(1).Trim() } | Where-Object { $_.Length -ge 4 }) {
                $head = $authored.Substring(0, [Math]::Min(16, $authored.Length))
                $atStart = $starts | Where-Object { $_.StartsWith($head) }
                $midLine = $added | Where-Object { $_.Substring(1).TrimStart().IndexOf($head) -gt 0 }
                if (-not $atStart -and $midLine) { "$file|$authored"; break }
            }
        }
    }
    foreach ($line in Get-Content -LiteralPath $diffPath) {
        if ($line.StartsWith('+++ ')) { $file = $line.Substring(4).Trim('"') }
        elseif ($line.StartsWith('@@') -or $line.StartsWith('diff ')) { & $flush; $removed = @(); $added = @() }
        elseif ($line.StartsWith('-') -and -not $line.StartsWith('---')) { $removed += $line }
        elseif ($line.StartsWith('+') -and -not $line.StartsWith('+++')) { $added += $line }
    }
    & $flush
}
function Test-AuthoredLine([string] $flag) {
    $candidatePath, $line = $flag -split '\|', 2
    $candidatePath = $candidatePath -replace '^b/', '' -replace '\\\\', '\'
    foreach ($name in $corpora.Keys) {
        $marker = Join-Path $Work "$name-candidate"
        $at = $candidatePath.IndexOf($marker, [StringComparison]::OrdinalIgnoreCase)
        if ($at -lt 0) { continue }
        $source = Join-Path $corpora[$name] $candidatePath.Substring($at + $marker.Length).TrimStart('\')
        if (-not (Test-Path -LiteralPath $source)) { return $false }
        $wanted = [regex]::Replace($line.Trim(), '\s+', ' ')
        return [bool]([IO.File]::ReadAllLines($source) | Where-Object { [regex]::Replace($_.Trim(), '\s+', ' ') -eq $wanted } | Select-Object -First 1)
    }
    $false
}
$flagged = @(Get-ChildItem $Work -Filter 'review-*.diff' | ForEach-Object { Get-JoinedAuthoredLines $_.FullName })
$joined = @($flagged | Where-Object { Test-AuthoredLine $_ } | ForEach-Object { $path, $line = $_ -split '\|', 2; "$(Split-Path $path -Leaf): $line" })
"== flagged joins $($flagged.Count), of which the joined line was authored in the source: $($joined.Count) (a flag on a line the installed formatter wrote is a re-lay difference, not a join)"
"== joined authored lines that fit in 120 (then lines included): $($joined.Count)"
$joined | Select-Object -First 25 | ForEach-Object { "  JOINED: $_" }
if ($joined.Count) { $verdict = $false }
"automatic part: $(if ($verdict) { 'PASS' } else { 'FAIL' }) (candidate exits equal the installed ones or are 0, no file differs beyond parentheses, whitespace and backslash continuations, no authored break that fit is joined, a second format pass changes no synthetic file and no file the installed formatter keeps stable, and the $ComplaintCorpus files, when that corpus is given, have no parenthesized join head and no off-grid line); then read every hunk in $Work\review-*.diff by hand"
