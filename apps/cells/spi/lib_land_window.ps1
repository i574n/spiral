param(
    [Parameter(Mandatory)] [string[]] $Draft,
    [Parameter(Mandatory)] [string] $Label,
    [string[]] $BaseHash = @(),
    [string[]] $Remove = @(),
    [string[]] $RemoveHash = @(),
    [string] $Lib = (Join-Path $PSScriptRoot '../../../lib/spiral'),
    [string] $UndoRoot = (Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/lib-land-undo'),
    [string[]] $Consumer = @('apps/spiral/spiral.spi'),
    [string] $Compiler = (Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll'),
    [string] $Dotnet = (Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) "spiral-bin/toolchains/dotnet/dotnet$(if ($IsWindows) { '.exe' })"),
    [int] $MaxWaitMin = 30,
    [switch] $Apply
)
$ErrorActionPreference = 'Stop'
$kit = Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) "kit/bin/kit$(if ($IsWindows) { '.exe' })"
if (!(Test-Path $kit)) { $kit = (Get-Command kit -CommandType Application -ErrorAction Stop | Select-Object -First 1).Source }
$Lib = (Resolve-Path $Lib).Path.TrimEnd('\')
$Draft = @($Draft | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$BaseHash = @($BaseHash | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$pairs = foreach ($d in $Draft) {
    $live, $source = $d -split '=', 2
    if (-not $source -or -not (Test-Path -LiteralPath $source)) { throw "draft '$d' must be <lib file>=<existing draft path>" }
    $liveName = $live.Replace('\', '/')
    [pscustomobject]@{ Live = $liveName; Source = (Resolve-Path -LiteralPath $source).Path; New = -not (Test-Path -LiteralPath (Join-Path $Lib $liveName)) }
}
if ($BaseHash.Count -and $BaseHash.Count -ne $pairs.Count) { throw '-BaseHash needs one sha256 prefix per draft, in the same order' }
$Remove = @($Remove | ForEach-Object { $_ -split ',' } | Where-Object { $_ } | ForEach-Object { $_.Replace('\', '/') })
$RemoveHash = @($RemoveHash | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
if ($Remove.Count -ne $RemoveHash.Count) { throw '-Remove needs one -RemoveHash sha256 prefix per removed file, in the same order' }
for ($i = 0; $i -lt $Remove.Count; $i++) {
    $gone = Join-Path $Lib $Remove[$i]
    if (-not (Test-Path -LiteralPath $gone -PathType Leaf)) { throw "remove '$($Remove[$i])': not a lib file" }
    if ($Remove[$i] -in $pairs.Live) { throw "remove '$($Remove[$i])' is also a draft target" }
    $now = (Get-FileHash -LiteralPath $gone).Hash
    if (-not $now.StartsWith($RemoveHash[$i])) { throw "$($Remove[$i]) changed since the removal was planned (now $($now.Substring(0, 12))): re-plan first" }
}
for ($i = 0; $i -lt $BaseHash.Count; $i++) {
    if ($pairs[$i].New) { if ($BaseHash[$i] -ne 'new') { throw "$($pairs[$i].Live) is a new file: give 'new' as its -BaseHash" }; continue }
    if ($BaseHash[$i] -eq 'new') { throw "$($pairs[$i].Live) exists in lib: 'new' is only for new files" }
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
$pairs | ForEach-Object { "{0,-28} <= {1}{2}" -f $_.Live, $_.Source, $(if ($_.New) { ' (new file)' } else { '' }) }
$Remove | ForEach-Object { "{0,-28} => removed (kept in the undo dir)" -f $_ }
if (-not $Apply) { 'dry run: nothing written; rerun with -Apply'; return }
$deadline = (Get-Date).AddMinutes($MaxWaitMin)
while ((Get-LiveReaders).Count -and (Get-Date) -lt $deadline) { Start-Sleep 30 }
$readers = Get-LiveReaders
if ($readers.Count) { $readers | ForEach-Object { "LIVE READER: $($_.ProcessId) $("$($_.CommandLine)".Substring(0, [Math]::Min(140, "$($_.CommandLine)".Length)))" }; throw 'live lib readers still present: not landing' }
$undo = Join-Path $UndoRoot (Get-Date -Format 'yyyyMMdd-HHmmss')
$winMinutes = [Math]::Max(30, 45 + 10 * [Math]::Ceiling($pairs.Count / 10))
$win = & $kit window request tree-write $winMinutes --label $Label 2>&1 | Select-Object -Last 1
"$win"
$winId = if ("$win" -match 'id=(\S+)') { $Matches[1] }
foreach ($live in @($pairs | Where-Object { -not $_.New } | ForEach-Object Live) + $Remove) { $u = Join-Path $undo $live; New-Item -ItemType Directory -Force (Split-Path $u) | Out-Null; Copy-Item -LiteralPath (Join-Path $Lib $live) -Destination $u }
function Restore-Undo {
    foreach ($gone in $Remove) { Copy-Retry (Join-Path $undo $gone) (Join-Path $Lib $gone) }
    foreach ($p in $pairs) {
        if (-not $p.New) { Copy-Retry (Join-Path $undo $p.Live) (Join-Path $Lib $p.Live); continue }
        $landed = Join-Path $Lib $p.Live
        if (Test-Path -LiteralPath $landed) { $u = Join-Path $undo "$($p.Live).new"; New-Item -ItemType Directory -Force (Split-Path $u) | Out-Null; Move-Item -LiteralPath $landed -Destination $u -Force }
    }
    "RESTORED from $undo"
}
$probe = @($pairs | Where-Object { $_.Live -like '*.spi' -and $_.Live -notlike '../*' } | ForEach-Object Live)
$baseProbe = @($pairs | Where-Object { $_.Live -like '*.spi' -and $_.Live -notlike '../*' -and -not $_.New } | ForEach-Object Live)
function Get-ProbeFailures([string[]] $lines) { @($lines | ForEach-Object { if ($_ -match '^type-probe (\S+): FAIL') { $Matches[1] } }) }
try {
    $baseFail = @()
    if ($baseProbe.Count) { $baseFail = Get-ProbeFailures @(pwsh -NoProfile -File (Join-Path $PSScriptRoot 'type_probe.ps1') -File ($baseProbe -join ',') -Lib $Lib 2>&1 | ForEach-Object { "$_" }) }
    foreach ($p in $pairs) { Copy-Retry $p.Source (Join-Path $Lib $p.Live) }
    foreach ($gone in $Remove) { Remove-Item -LiteralPath (Join-Path $Lib $gone) -Force }
    $closeOk = $true
    $repo = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
    '=== signatures'
    $spelling = { param($text) $text -replace '(?<=[\w''])::(?=[\w(])', '.' }
    $consumerText = (@($Consumer | ForEach-Object { Get-ChildItem (Split-Path (Join-Path $repo $_)) -Filter *.spi -File }) | Sort-Object FullName -Unique | ForEach-Object { [IO.File]::ReadAllText($_.FullName) }) -join "`n"
    $checked = 0
    $drift = foreach ($live in @($pairs | Where-Object { -not $_.New } | ForEach-Object Live) + $Remove) {
        $stem = [IO.Path]::GetFileNameWithoutExtension($live)
        $before = [IO.File]::ReadAllLines((Join-Path $undo $live))
        $defined = @($before | ForEach-Object { if ($_ -match '^(?::=|:~ \^?|inl|let|:~) *(\([^)\s]+\)|[\w'']+)') { $Matches[1] } } | Sort-Object -Unique)
        $opened = [regex]::IsMatch($consumerText, '(?m)^\s*(open|:<)\s+' + [regex]::Escape($stem) + '\s*$')
        $used = @(@([regex]::Matches($consumerText, '(?<![\w''])' + [regex]::Escape($stem) + '(?:::|\.)([\w'']+|\([^)\s]+\))') | ForEach-Object { $_.Groups[1].Value }) + @($defined | Where-Object {
            if ($_ -like '(*)') { $consumerText.Contains(" $($_.Trim('(', ')')) ") } else { $opened -and [regex]::IsMatch($consumerText, '(?<![\w''.:])' + [regex]::Escape($_) + '(?![\w''])') } }) | Sort-Object -Unique)
        $after = if (Test-Path -LiteralPath (Join-Path $Lib $live)) { [IO.File]::ReadAllLines((Join-Path $Lib $live)) } else { @() }
        foreach ($name in $used) {
            $pattern = '^(:=|:~ \^?|inl|let|:~) *' + [regex]::Escape($name) + '(\s|$)'
            $was = @($before | Where-Object { $_ -match $pattern }) -join ' || '
            if (-not $was) { continue }
            $checked++
            $now = @($after | Where-Object { $_ -match $pattern }) -join ' || '
            if ((& $spelling $now) -ne (& $spelling $was)) { "$live $name changed" }
        }
    }
    if ($drift) { $drift; $closeOk = $false } else { "$checked consumer-used signatures unchanged" }
    '=== consumers'
    if (-not $env:SPIRAL_COMPILER_PACKAGE_DIR) { $env:SPIRAL_COMPILER_PACKAGE_DIR = Join-Path $repo 'deps/The-Spiral-Language/VS Code Plugin' }
    $consumerOut = Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/mix-builds/lib-land-consumers'
    New-Item -ItemType Directory -Force $consumerOut | Out-Null
    foreach ($c in $Consumer) {
        $entry = Join-Path $repo $c
        Push-Location (Split-Path $entry)
        try { $text = @(& $Dotnet $Compiler --backend Rust (Split-Path $entry -Leaf) (Join-Path $consumerOut "$([IO.Path]::GetFileNameWithoutExtension($entry)).rs") 2>&1 | ForEach-Object { "$_" }); $code = $LASTEXITCODE } finally { Pop-Location }
        if ($code) { "$c exit ${code}: $(@($text | Where-Object { $_ -match 'Error' } | Select-Object -First 1))"; $closeOk = $false } else { "$c compiles" }
    }
    '=== document_test'
    $user = [Environment]::GetEnvironmentVariables('User')
    foreach ($name in $user.Keys) { if ($name -notin 'Path', 'PSModulePath', 'TEMP', 'TMP' -and $user[$name] -and -not [Environment]::GetEnvironmentVariable($name, 'Process')) { [Environment]::SetEnvironmentVariable($name, $user[$name], 'Process') } }
    $env:MIX_ENV = 'test'
    $env:MIX_BUILD_PATH = Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/mix-builds/lib-land'
    Push-Location (Join-Path $PSScriptRoot '..')
    try { $mix = Join-Path (Split-Path (Get-Command mix).Source -Parent) 'mix.bat'; & $mix test test/spiral/document_test.exs --timeout 900000 2>&1 | Select-String -Pattern '^\s+\d+\) test |Result:' | ForEach-Object { $_.Line.Trim() }; if ($LASTEXITCODE) { $closeOk = $false } } finally { Pop-Location }
    '=== type_probe'
    if ($probe.Count) {
        $lines = @(pwsh -NoProfile -File (Join-Path $PSScriptRoot 'type_probe.ps1') -File ($probe -join ',') -Lib $Lib 2>&1 | ForEach-Object { "$_" })
        $probeExit = $LASTEXITCODE
        $lines | Select-Object -Last ($probe.Count + 1)
        $nowFail = Get-ProbeFailures $lines
        $newFail = @($nowFail | Where-Object { $_ -notin $baseFail })
        if ($baseFail) { "type_probe: $($baseFail.Count) already failed before this land, not blocking: $($baseFail -join ', ')" }
        if ($newFail) { "type_probe NEW failures: $($newFail -join ', ')"; $closeOk = $false }
        elseif ($probeExit -and -not $nowFail) { "type_probe exit $probeExit with no FAIL rows"; $closeOk = $false }
    }
    if (-not $closeOk) { 'CLOSE FAILED: undoing'; Restore-Undo; throw 'close failed; undone' }
    foreach ($p in $pairs) { "{0,-28} {1}" -f $p.Live, (Get-FileHash -LiteralPath (Join-Path $Lib $p.Live)).Hash.Substring(0, 12) }
    "LANDED and closed green; undo: $undo"
} catch { if ("$_" -notmatch 'undone') { Restore-Undo }; throw } finally { if ($winId) { & $kit window release $winId 2>&1 | Select-Object -Last 1 } }
