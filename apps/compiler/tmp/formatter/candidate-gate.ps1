param(
    [Parameter(Mandatory)] [string] $Dll,
    [string] $Work = (Join-Path $env:LOCALAPPDATA 'spiral-bin\candidates\formatter-gate')
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot '..\scripts\env.ps1')
$dotnet = Resolve-SpiralDotnet
$installed = Get-SpiralCompilerDll single-flight
New-Item -ItemType Directory -Force $Work | Out-Null
Get-ChildItem $Work -Directory | Where-Object Name -match '-(installed|candidate)$' | Remove-Item -Recurse -Force
Get-ChildItem $Work -Filter 'review-*.diff' | Remove-Item -Force
$env:SPIRAL_FORMAT_PARALLEL = '1'
$corpora = [ordered]@{}
$corpora.user = Join-Path $Work 'corpus-user'
$corpora.lib = Join-Path $Work 'corpus-lib-head'
if (-not (Test-Path $corpora.user)) { pwsh -NoProfile -File (Join-Path $PSScriptRoot 'extract-corpus.ps1') -Out $corpora.user -Which user | Out-Null }
if (-not (Test-Path $corpora.lib)) { pwsh -NoProfile -File (Join-Path $PSScriptRoot 'extract-corpus.ps1') -Out $corpora.lib -Which lib-head | Out-Null }
$corpora.synthetic = Join-Path $PSScriptRoot 'synthetic'
$dice = Join-Path $Work 'corpus-dice'
if (-not (Test-Path $dice)) { New-Item -ItemType Directory $dice | Out-Null }
foreach ($f in 'lib/dice.spi', 'ui/src/model/near/rpc.spi', 'ui/src/model/near/nearblocks.spi', 'ui/src/components/content.spi', 'ui/src/components/menu_tabs.spi') {
    cmd /c "git -C C:\home\git\dice show HEAD:$f > `"$dice\$(Split-Path $f -Leaf)`""
}
cmd /c "git -C C:\home\git\alphabet show HEAD:apps/documents/documents.spi > `"$dice\documents.spi`""
$corpora.dice = $dice
$eoie = Join-Path $Work 'corpus-eoie'
if (-not (Test-Path $eoie)) {
    foreach ($rel in (git -C C:\home\git\eoie ls-tree -r --name-only HEAD -- src | Where-Object { $_ -match '\.spi$' })) {
        $to = Join-Path $eoie ($rel -replace '/', '\')
        New-Item -ItemType Directory -Force (Split-Path $to) | Out-Null
        cmd /c "git -C C:\home\git\eoie show HEAD:$rel > `"$to`""
    }
}
$corpora.eoie = $eoie
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
}
foreach ($name in $corpora.Keys) {
    $counts = foreach ($side in 'installed', 'candidate') {
        $census = @(python -I (Join-Path $PSScriptRoot 'fitting_lines_kept.py') $corpora[$name] (Join-Path $Work "$name-$side"))
        $thenMoved = [regex]::Match(($census -join "`n"), '(?m)^\s+(\d+) then moved$')
        "$side $(([regex]::Match([string]$census[0], 'not kept verbatim (\d+)')).Groups[1].Value) (then moved $(if ($thenMoved.Success) { $thenMoved.Groups[1].Value } else { 0 }))"
    }
    "== fitting authored lines not kept verbatim, $name`: $($counts -join ', ') (informational: parentheses the candidate drops on purpose count too)"
}
$complaintFiles = @(Get-ChildItem (Join-Path $Work 'dice-candidate') -Filter *.spi | ForEach-Object FullName)
$complaints = @(python -I (Join-Path $PSScriptRoot 'complaints_probe.py') $complaintFiles)
$complaintsExit = $LASTEXITCODE
$complaints | ForEach-Object { if ($_.StartsWith(' ')) { "  $_" } else { "== complaints $_" } }
if ($complaintsExit) { $verdict = $false }
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
"automatic part: $(if ($verdict) { 'PASS' } else { 'FAIL' }) (candidate exits equal the installed ones or are 0, no file differs beyond parentheses, whitespace and backslash continuations, no authored break that fit is joined, and the dice files have no parenthesized join head and no off-grid line); then read every hunk in $Work\review-*.diff by hand"
