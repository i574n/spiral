[CmdletBinding(DefaultParameterSetName = 'land')]
param(
    [Parameter(Mandatory, ParameterSetName = 'land')] [string] $Applier,
    [Parameter(Mandatory, ParameterSetName = 'land')] [string[]] $Files,
    [Parameter(Mandatory, ParameterSetName = 'land')] [string[]] $Tests,
    [Parameter(Mandatory, ParameterSetName = 'land')] [string] $Label,
    [Parameter(ParameterSetName = 'land')] [string] $Cells = (Join-Path $PSScriptRoot '..'),
    [Parameter(ParameterSetName = 'land')] [string] $UndoRoot = (Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/lib-land-undo'),
    [Parameter(ParameterSetName = 'land')] [int] $Minutes = 30,
    [Parameter(ParameterSetName = 'land')] [int] $MinFreeMb = 1200,
    [Parameter(ParameterSetName = 'land')] [string] $ProvenLog,
    [Parameter(Mandatory, ParameterSetName = 'selftest')] [switch] $RatchetSelfTest
)
$ErrorActionPreference = 'Stop'

function Get-ElixirDrift([object[]] $Rows, [string] $Label) {
    $before = [int]($Rows | Measure-Object -Property Before -Sum).Sum
    $after = [int]($Rows | Measure-Object -Property After -Sum).Sum
    $newFiles = @($Rows | Where-Object { $_.Created }).Count
    $exempt = $Label -match '^(CELLS-PORT-|CELLS-ELIXIR-HEAL)'
    $grew = ($after -gt $before) -or ($newFiles -gt 0)
    [pscustomobject]@{
        Line = "elixir drift: .ex lines $before -> $after ($($after - $before)), new .ex files $newFiles$(if ($exempt) { ', exempt port/heal label' })"
        Refused = $grew -and -not $exempt
    }
}

if ($RatchetSelfTest) {
    $cases = @(
        @('shrinks', 'CELLS-X', @(@{ Before = 10; After = 8; Created = $false }), $false),
        @('grows', 'CELLS-X', @(@{ Before = 10; After = 12; Created = $false }), $true),
        @('new file', 'CELLS-X', @(@{ Before = 0; After = 3; Created = $true }, @{ Before = 9; After = 1; Created = $false }), $true),
        @('port grows', 'CELLS-PORT-MOUNTS-TEXT', @(@{ Before = 10; After = 12; Created = $false }), $false),
        @('heal grows', 'CELLS-ELIXIR-HEAL-1106', @(@{ Before = 0; After = 3; Created = $true }), $false),
        @('no ex files', 'CELLS-X', @(), $false)
    )
    $failed = 0
    foreach ($c in $cases) {
        $d = Get-ElixirDrift @($c[2] | ForEach-Object { [pscustomobject]$_ }) $c[1]
        $ok = $d.Refused -eq $c[3]
        if (-not $ok) { $failed++ }
        "{0} {1}: refused={2} ({3})" -f $(if ($ok) { 'ok  ' } else { 'FAIL' }), $c[0], $d.Refused, $d.Line
    }
    "ratchet self-test: $($cases.Count - $failed)/$($cases.Count)"
    exit $(if ($failed) { 1 } else { 0 })
}
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
    $exRows = foreach ($f in @($Files | Where-Object { $_ -like '*.ex' })) {
        $after = @(Get-Content -LiteralPath (Join-Path $Cells $f)).Count
        $before = if ($created.Contains($f)) { 0 } else { @(Get-Content -LiteralPath (Join-Path $undo $f)).Count }
        [pscustomobject]@{ Before = $before; After = $after; Created = $created.Contains($f) }
    }
    $drift = Get-ElixirDrift @($exRows) $Label
    $drift.Line
    if ($drift.Refused) { "CLOSE FAILED (Elixir grew under $Label; only CELLS-PORT-* / CELLS-ELIXIR-HEAL* may grow it): undoing"; Restore-Undo; exit 1 }
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
