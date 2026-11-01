param(
    [Parameter(Mandatory)] [string[]] $Draft,
    [Parameter(Mandatory)] [string] $Label,
    [string[]] $BaseHash = @(),
    [string] $Lib = (Join-Path $PSScriptRoot '../../../lib/spiral'),
    [string] $SignatureFile = (Join-Path $PSScriptRoot 'lib_consumer_signatures.tsv'),
    [string] $UndoRoot = (Join-Path $env:LOCALAPPDATA 'spiral-bin/lib-land-undo'),
    [int] $MaxWaitMin = 30,
    [switch] $Apply
)
$ErrorActionPreference = 'Stop'
$kit = Join-Path $env:LOCALAPPDATA 'kit\bin\kit.exe'
$Lib = (Resolve-Path $Lib).Path.TrimEnd('\')
$Draft = @($Draft | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$BaseHash = @($BaseHash | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$pairs = foreach ($d in $Draft) {
    $live, $source = $d -split '=', 2
    if (-not $source -or -not (Test-Path -LiteralPath $source)) { throw "draft '$d' must be <lib file>=<existing draft path>" }
    [pscustomobject]@{ Live = $live.Replace('\', '/'); Source = (Resolve-Path -LiteralPath $source).Path }
}
if ($BaseHash.Count -and $BaseHash.Count -ne $pairs.Count) { throw '-BaseHash needs one sha256 prefix per draft, in the same order' }
for ($i = 0; $i -lt $BaseHash.Count; $i++) {
    $now = (Get-FileHash -LiteralPath (Join-Path $Lib $pairs[$i].Live)).Hash
    if (-not $now.StartsWith($BaseHash[$i])) { throw "$($pairs[$i].Live) changed since its draft was proven (now $($now.Substring(0, 12))): re-prove first" }
}
function Get-LiveReaders {
    $all = @(Get-CimInstance Win32_Process)
    $byId = @{}; foreach ($p in $all) { $byId[[int]$p.ProcessId] = $p }
    @($all | Where-Object { "$($_.CommandLine)" -match 'lib_gate\.ps1|run_notebook\.ps1|spiral\.notebook|document_test' -and $_.ProcessId -ne $PID } | Where-Object {
        $cur = $_; $scratch = $false
        for ($i = 0; $i -lt 10 -and $cur; $i++) {
            $c = "$($cur.CommandLine)"
            if ($c -match 'lib_land_window\.ps1') { $scratch = $true; break }
            if ($c -match '(lib_gate|release-train)\.ps1' -and $c -match '-Lib\s+"?([^"\s]+)') { $scratch = ($Matches[1].TrimEnd('\') -ne $Lib); break }
            $cur = $byId[[int]$cur.ParentProcessId]
        }
        -not $scratch
    })
}
function Copy-Retry([string] $from, [string] $to) {
    foreach ($i in 1..120) { try { Copy-Item -LiteralPath $from -Destination $to -Force -ErrorAction Stop; (Get-Item -LiteralPath $to).LastWriteTime = Get-Date; return } catch { Start-Sleep -Milliseconds 500 } }
    throw "could not copy $from -> $to (locked for 60 s)"
}
$pairs | ForEach-Object { "{0,-28} <= {1}" -f $_.Live, $_.Source }
if (-not $Apply) { 'dry run: nothing written; rerun with -Apply'; return }
$deadline = (Get-Date).AddMinutes($MaxWaitMin)
while ((Get-LiveReaders).Count -and (Get-Date) -lt $deadline) { Start-Sleep 30 }
$readers = Get-LiveReaders
if ($readers.Count) { $readers | ForEach-Object { "LIVE READER: $($_.ProcessId) $("$($_.CommandLine)".Substring(0, [Math]::Min(140, "$($_.CommandLine)".Length)))" }; throw 'live lib readers still present: not landing' }
$undo = Join-Path $UndoRoot (Get-Date -Format 'yyyyMMdd-HHmmss')
$win = & $kit window request tree-write 30 --label $Label 2>&1 | Select-Object -Last 1
"$win"
$winId = if ("$win" -match 'id=(\S+)') { $Matches[1] }
foreach ($p in $pairs) { $u = Join-Path $undo $p.Live; New-Item -ItemType Directory -Force (Split-Path $u) | Out-Null; Copy-Item -LiteralPath (Join-Path $Lib $p.Live) -Destination $u }
function Restore-Undo { foreach ($p in $pairs) { Copy-Retry (Join-Path $undo $p.Live) (Join-Path $Lib $p.Live) }; "RESTORED from $undo" }
try {
    foreach ($p in $pairs) { Copy-Retry $p.Source (Join-Path $Lib $p.Live) }
    $closeOk = $true
    if ($SignatureFile) {
        '=== signatures'
        $drift = foreach ($row in Get-Content $SignatureFile) {
            $file, $name, $count, $before = $row -split "`t", 4
            $pattern = '^(:=|:~ \^?|inl|let|:~) *' + [regex]::Escape($name) + '(\s|$)'
            $now = @([IO.File]::ReadAllLines((Join-Path $Lib $file)) | Where-Object { $_ -match $pattern }) -join ' || '
            if ($now -ne $before) { "$file $name changed" }
        }
        if ($drift) { $drift; $closeOk = $false } else { "$(@(Get-Content $SignatureFile).Count) signatures unchanged" }
    }
    '=== document_test'
    $user = [Environment]::GetEnvironmentVariables('User')
    foreach ($name in $user.Keys) { if ($name -notin 'Path', 'PSModulePath', 'TEMP', 'TMP' -and $user[$name] -and -not [Environment]::GetEnvironmentVariable($name, 'Process')) { [Environment]::SetEnvironmentVariable($name, $user[$name], 'Process') } }
    $env:MIX_ENV = 'test'
    $env:MIX_BUILD_PATH = Join-Path $env:LOCALAPPDATA 'spiral-bin/mix-builds/lib-land'
    Push-Location (Join-Path $PSScriptRoot '..')
    try { $mix = Join-Path (Split-Path (Get-Command mix).Source -Parent) 'mix.bat'; & $mix test test/spiral/document_test.exs --timeout 900000 2>&1 | Select-String -Pattern '^\s+\d+\) test |Result:' | ForEach-Object { $_.Line.Trim() }; if ($LASTEXITCODE) { $closeOk = $false } } finally { Pop-Location }
    '=== type_probe'
    $probe = @($pairs | Where-Object { $_.Live -like '*.spi' } | ForEach-Object Live)
    if ($probe.Count) { pwsh -NoProfile -File (Join-Path $PSScriptRoot 'type_probe.ps1') -File ($probe -join ',') -Lib $Lib 2>&1 | Select-Object -Last ($probe.Count + 1); if ($LASTEXITCODE) { $closeOk = $false } }
    if (-not $closeOk) { 'CLOSE FAILED: undoing'; Restore-Undo; throw 'close failed; undone' }
    foreach ($p in $pairs) { "{0,-28} {1}" -f $p.Live, (Get-FileHash -LiteralPath (Join-Path $Lib $p.Live)).Hash.Substring(0, 12) }
    "LANDED and closed green; undo: $undo"
} catch { if ("$_" -notmatch 'undone') { Restore-Undo }; throw } finally { if ($winId) { & $kit window release $winId 2>&1 | Select-Object -Last 1 } }
