param(
    [Parameter(Mandatory)] [string] $Applier,
    [Parameter(Mandatory)] [string[]] $Files,
    [Parameter(Mandatory)] [string[]] $Tests,
    [Parameter(Mandatory)] [string] $Label,
    [string] $Cells = (Join-Path $PSScriptRoot '..'),
    [string] $UndoRoot = (Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/lib-land-undo'),
    [int] $Minutes = 30,
    [int] $MinFreeMb = 1200,
    [string] $ProvenLog
)
$ErrorActionPreference = 'Stop'
$kit = Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) "kit/bin/kit$(if ($IsWindows) { '.exe' })"
if (-not (Test-Path -LiteralPath $kit)) { $kit = (Get-Command kit -ErrorAction Stop).Source }
$Cells = (Resolve-Path $Cells).Path
$Files = @($Files | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$Tests = @($Tests | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
pwsh -NoProfile -File $Applier -Cells $Cells | Select-Object -Last 1
if ($LASTEXITCODE) { throw "dry run failed: $Applier" }
"land $Label"
$win = & $kit window request tree-write $Minutes --label ($Cells.Replace('\', '/')) --wait $Minutes --min-free-mb $MinFreeMb 2>&1 | Select-Object -Last 1
"$win"
$winId = if ("$win" -match 'id=(\S+)') { $Matches[1] }
if (-not $winId) { throw "no tree-write window on $Cells within $Minutes min: not landing" }
$undo = Join-Path $UndoRoot ("cells-" + (Get-Date -Format 'yyyyMMdd-HHmmss'))
$created = [Collections.Generic.HashSet[string]]::new()
$landed = @{}
function Restore-Undo {
    foreach ($f in $Files) {
        $t = Join-Path $Cells $f
        if ($landed.ContainsKey($f) -and (Get-FileHash -LiteralPath $t).Hash -ne $landed[$f]) { "SKIP restore of ${f}: another writer changed it after this land applied"; continue }
        if ($created.Contains($f)) { if (Test-Path -LiteralPath $t) { Remove-Item -LiteralPath $t -Force }; continue }
        Copy-Item -LiteralPath (Join-Path $undo $f) -Destination $t -Force; (Get-Item -LiteralPath $t).LastWriteTime = Get-Date
    }
    "RESTORED from $undo"
}
$ok = $false
try {
    foreach ($f in $Files) {
        $source = Join-Path $Cells $f
        if (-not (Test-Path -LiteralPath $source)) { [void]$created.Add($f); continue }
        $u = Join-Path $undo $f
        New-Item -ItemType Directory -Force (Split-Path $u) | Out-Null
        Copy-Item -LiteralPath $source -Destination $u
    }
    pwsh -NoProfile -File $Applier -Cells $Cells -Apply | Select-Object -Last 1
    if ($LASTEXITCODE) { throw "apply failed: $Applier" }
    foreach ($f in $Files) { (Get-Item -LiteralPath (Join-Path $Cells $f)).LastWriteTime = Get-Date; $landed[$f] = (Get-FileHash -LiteralPath (Join-Path $Cells $f)).Hash }
    $proven = $false
    if ($ProvenLog) {
        $log = if (Test-Path -LiteralPath $ProvenLog) { Get-Content -LiteralPath $ProvenLog } else { @() }
        $missing = @($Files | Where-Object { $p = $_; -not ($log | Where-Object { $_ -match ('^' + [regex]::Escape($p) + '\s+' + $landed[$p].Substring(0, 12) + '$') }) })
        $green = [bool]($log | Where-Object { $_ -match 'LANDED and closed green' })
        if ($green -and -not $missing.Count) { "close proven by $ProvenLog for $($Files.Count) files: the box result equals the proof byte for byte"; $proven = $true }
        else { "proof not usable ($(if (-not $green) { 'no green close' } else { 'hash differs: ' + ($missing -join ', ') })): running the tests here" }
    }
    $env:PATH = "$HOME\scoop\apps\erlang\current\bin;$HOME\scoop\apps\elixir\current\bin;$env:PATH"
    $env:MIX_ENV = 'test'
    $env:MIX_BUILD_PATH = Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/mix-builds/cells-land'
    if ($proven) { $ok = $true }
    else {
        Push-Location $Cells
        try {
            $mix = Join-Path (Split-Path (Get-Command mix).Source -Parent) 'mix.bat'
            & $mix test @Tests --timeout 900000 2>&1 | Select-String -Pattern '^\s+\d+\) test |Result:' | ForEach-Object { $_.Line.Trim() }
            if ($LASTEXITCODE) {
                '=== rerun only the failed tests'
                & $mix test @Tests --failed --timeout 900000 2>&1 | Select-String -Pattern '^\s+\d+\) test |Result:' | ForEach-Object { $_.Line.Trim() }
            }
            $ok = ($LASTEXITCODE -eq 0)
        } finally { Pop-Location }
    }
    if (-not $ok) { 'CLOSE FAILED: undoing'; Restore-Undo; exit 1 }
    foreach ($f in $Files) { "{0,-46} {1}" -f $f, (Get-FileHash -LiteralPath (Join-Path $Cells $f)).Hash.Substring(0, 12) }
    "LANDED and closed green; undo: $undo"
} catch { if (-not $ok) { Restore-Undo }; throw } finally { if ($winId) { & $kit window release $winId 2>&1 | Select-Object -Last 1 } }
