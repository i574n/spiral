param(
    [Parameter(Mandatory)] [string] $Applier,
    [Parameter(Mandatory)] [string[]] $Files,
    [Parameter(Mandatory)] [string[]] $Tests,
    [Parameter(Mandatory)] [string] $Label,
    [string] $Cells = (Join-Path $PSScriptRoot '..'),
    [string] $UndoRoot = (Join-Path $env:LOCALAPPDATA 'spiral-bin/lib-land-undo'),
    [int] $Minutes = 30
)
$ErrorActionPreference = 'Stop'
$kit = Join-Path $env:LOCALAPPDATA 'kit\bin\kit.exe'
$Cells = (Resolve-Path $Cells).Path
$Files = @($Files | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$Tests = @($Tests | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
pwsh -NoProfile -File $Applier -Cells $Cells | Select-Object -Last 1
if ($LASTEXITCODE) { throw "dry run failed: $Applier" }
$undo = Join-Path $UndoRoot ("cells-" + (Get-Date -Format 'yyyyMMdd-HHmmss'))
foreach ($f in $Files) { $u = Join-Path $undo $f; New-Item -ItemType Directory -Force (Split-Path $u) | Out-Null; Copy-Item -LiteralPath (Join-Path $Cells $f) -Destination $u }
function Restore-Undo { foreach ($f in $Files) { $t = Join-Path $Cells $f; Copy-Item -LiteralPath (Join-Path $undo $f) -Destination $t -Force; (Get-Item -LiteralPath $t).LastWriteTime = Get-Date }; "RESTORED from $undo" }
$win = & $kit window request tree-write $Minutes --label $Label 2>&1 | Select-Object -Last 1
"$win"
$winId = if ("$win" -match 'id=(\S+)') { $Matches[1] }
$ok = $false
try {
    pwsh -NoProfile -File $Applier -Cells $Cells -Apply | Select-Object -Last 1
    if ($LASTEXITCODE) { throw "apply failed: $Applier" }
    foreach ($f in $Files) { (Get-Item -LiteralPath (Join-Path $Cells $f)).LastWriteTime = Get-Date }
    $env:PATH = "$HOME\scoop\apps\erlang\current\bin;$HOME\scoop\apps\elixir\current\bin;$env:PATH"
    $env:MIX_ENV = 'test'
    $env:MIX_BUILD_PATH = Join-Path $env:LOCALAPPDATA 'spiral-bin/mix-builds/cells-land'
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
    if (-not $ok) { 'CLOSE FAILED: undoing'; Restore-Undo; exit 1 }
    foreach ($f in $Files) { "{0,-46} {1}" -f $f, (Get-FileHash -LiteralPath (Join-Path $Cells $f)).Hash.Substring(0, 12) }
    "LANDED and closed green; undo: $undo"
} catch { if (-not $ok) { Restore-Undo }; throw } finally { if ($winId) { & $kit window release $winId 2>&1 | Select-Object -Last 1 } }
