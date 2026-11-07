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
    [int] $MinFreeMb = 1200,
    [string] $ProvenLog,
    [switch] $PrivateLib,
    [switch] $Apply
)
$ErrorActionPreference = 'Stop'
$kit = Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) "kit/bin/kit$(if ($IsWindows) { '.exe' })"
if (-not (Test-Path -LiteralPath $kit)) { $kit = (Get-Command kit -ErrorAction Stop).Source }
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
function Get-LibDigest([hashtable] $override) {
    $rows = foreach ($f in Get-ChildItem -LiteralPath $Lib -Recurse -File | Where-Object { $_.Extension -in '.spi', '.spir', '.spiproj' }) {
        $rel = $f.FullName.Substring($Lib.Length + 1).Replace('\', '/')
        "$rel $(if ($override.ContainsKey($rel)) { $override[$rel] } else { (Get-FileHash -LiteralPath $f.FullName).Hash })"
    }
    foreach ($k in $override.Keys) { if (-not (Test-Path -LiteralPath (Join-Path $Lib $k))) { $rows += "$k $($override[$k])" } }
    [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes((($rows | Sort-Object -Culture 'en-US') -join "`n")))).Substring(0, 16)
}
if ($ProvenLog) {
    $proof = Get-Content -LiteralPath $ProvenLog -ErrorAction Stop
    $after = @{}; foreach ($p in $pairs) { $after[$p.Live] = (Get-FileHash -LiteralPath $p.Source).Hash }
    $want = Get-LibDigest $after
    $provenExact = [bool]($proof -match "^lib digest $want$")
    if (-not $provenExact) { "$ProvenLog was closed on a different lib (this lib with the drafts = $want): the fast checks rerun here, only document_test is taken from the proof" }
    if (-not ($proof -match 'LANDED and closed green')) { throw "$ProvenLog does not record a green close" }
    foreach ($p in $pairs) {
        $want = (Get-FileHash -LiteralPath $p.Source).Hash.Substring(0, 12)
        if (-not ($proof -match ('^' + [regex]::Escape($p.Live) + '\s+' + $want + '$'))) { throw "$ProvenLog does not prove $($p.Live) at $want" }
    }
    "close proven by $ProvenLog for $($pairs.Count) drafts"
}
function Get-LiveReaders {
    $all = @(Get-CimInstance Win32_Process)
    $byId = @{}; foreach ($p in $all) { $byId[[int]$p.ProcessId] = $p }
    @($all | Where-Object { "$($_.CommandLine)" -match 'lib_gate\.ps1|run_notebook\.ps1|spiral\.notebook|document_test' -and $_.ProcessId -ne $PID } | Where-Object {
        $paths = @([regex]::Matches("$($_.CommandLine)", '--path\s+"?([^"\s]+)') | ForEach-Object { $_.Groups[1].Value.Replace('/', '\') })
        $elsewhere = $paths.Count -and -not @($paths | Where-Object { -not ($_ -match '\\lib\\spiral\\') -or $_.StartsWith($Lib + '\', [StringComparison]::OrdinalIgnoreCase) }).Count
        if ($elsewhere) { return $false }
        $cur = $_; $scratch = $false
        for ($i = 0; $i -lt 10 -and $cur; $i++) {
            $c = "$($cur.CommandLine)"
            if ($c -match 'lib_land_window\.ps1') { $scratch = $true; break }
            if ($c -match 'remote\.ps1"?\s+\S+\s+run\b') { $scratch = $true; break }
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
function Set-MixEnv {
    $user = [Environment]::GetEnvironmentVariables('User')
    foreach ($name in $user.Keys) { if ($name -notin 'Path', 'PSModulePath', 'TEMP', 'TMP' -and $user[$name] -and -not [Environment]::GetEnvironmentVariable($name, 'Process')) { [Environment]::SetEnvironmentVariable($name, $user[$name], 'Process') } }
    $env:MIX_ENV = 'test'
    $env:MIX_BUILD_PATH = Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/mix-builds/lib-land'
    if ($IsWindows) { Join-Path (Split-Path (Get-Command mix).Source -Parent) 'mix.bat' } else { (Get-Command mix).Source }
}
function Show-FirstDiff([string] $label, [string] $want, [string] $got) {
    $a = $want -split "`n"; $b = $got -split "`n"
    for ($i = 0; $i -lt [Math]::Max($a.Count, $b.Count); $i++) {
        $x = if ($i -lt $a.Count) { $a[$i] } else { '<end of file>' }
        $y = if ($i -lt $b.Count) { $b[$i] } else { '<end of file>' }
        if ($x -cne $y) { "  ${label}:$($i + 1) draft      $(ConvertTo-Json $x -Compress)"; "  ${label}:$($i + 1) round trip $(ConvertTo-Json $y -Compress)"; return }
    }
}
$roundTrip = @($pairs | Where-Object { $_.Live -like '*.spi' -and $_.Live -notlike '../*' })
if ($roundTrip.Count) {
    '=== round trip (drafts, before landing)'
    $rt = Join-Path ([IO.Path]::GetTempPath()) "lib-land-roundtrip-$PID"
    Remove-Item -Recurse -Force $rt -ErrorAction Ignore
    foreach ($p in $roundTrip) {
        $in = Join-Path "$rt/in" $p.Live; New-Item -ItemType Directory -Force (Split-Path $in) | Out-Null; Copy-Item -LiteralPath $p.Source $in
        $spirLive = $p.Live -replace '\.spi$', '_real.spir'
        $spirDraft = @($pairs | Where-Object { $_.Live -eq $spirLive } | ForEach-Object Source)
        $spir = if ($spirDraft.Count) { $spirDraft[0] } elseif (Test-Path -LiteralPath (Join-Path $Lib $spirLive)) { Join-Path $Lib $spirLive }
        if ($spir) { Copy-Item -LiteralPath $spir (Join-Path "$rt/in" $spirLive) }
    }
    $mix = Set-MixEnv
    Push-Location (Join-Path $PSScriptRoot '..')
    try { $rtOut = @(& $mix run --no-start spi/lib_roundtrip.exs "$rt/in" "$rt/out" @($roundTrip | ForEach-Object Live) 2>&1 | ForEach-Object { "$_" }) } finally { Pop-Location }
    $rtBad = @(foreach ($p in $roundTrip) {
        $row = @($rtOut | Where-Object { $_ -like "ROUNDTRIP $($p.Live): *" }) | Select-Object -First 1
        $draftText = [IO.File]::ReadAllText((Join-Path "$rt/in" $p.Live))
        $tests = [regex]::Matches($draftText, '(?m)^(?:test|:#) \w+').Count
        if (-not $row) { "$($p.Live): no ROUNDTRIP row (VOID)"; continue }
        $fixpoint = $row -match 'fixpoint true'; $canonical = $row -match 'canonical true'
        if ($fixpoint -and ($canonical -or $tests -eq 0)) { continue }
        "$($p.Live): $(if (-not $fixpoint) { 'not a fixpoint' } else { "not byte-exact ($tests test blocks)" })"
        Show-FirstDiff $p.Live $draftText ([IO.File]::ReadAllText((Join-Path "$rt/out" $p.Live)))
    })
    if ($rtBad) { $rtBad; if (-not @($rtOut -match '^ROUNDTRIP ').Count) { $rtOut | Select-Object -Last 12 }; Remove-Item -Recurse -Force $rt -ErrorAction Ignore; throw 'a draft does not round-trip through the notebook (document_test would fail after landing): fix it first; nothing was written' }
    "$($roundTrip.Count) drafts round-trip as document_test requires"
    Remove-Item -Recurse -Force $rt -ErrorAction Ignore
}
if (-not $Apply) { 'dry run: nothing written; rerun with -Apply'; return }
$deadline = (Get-Date).AddMinutes($MaxWaitMin)
while (-not $PrivateLib -and (Get-LiveReaders).Count -and (Get-Date) -lt $deadline) { Start-Sleep 30 }
$readers = if ($PrivateLib) { @() } else { Get-LiveReaders }
if ($readers.Count) { $readers | ForEach-Object { "LIVE READER: $($_.ProcessId) $("$($_.CommandLine)".Substring(0, [Math]::Min(140, "$($_.CommandLine)".Length)))" }; throw 'live lib readers still present: not landing' }
$undo = Join-Path $UndoRoot (Get-Date -Format 'yyyyMMdd-HHmmss')
$winMinutes = [Math]::Max(30, 45 + 10 * [Math]::Ceiling($pairs.Count / 10))
"land $Label"
$win = & $kit window request tree-write $winMinutes --label ($Lib.Replace('\', '/')) --wait $MaxWaitMin --min-free-mb $MinFreeMb 2>&1 | Select-Object -Last 1
"$win"
$winId = if ("$win" -match 'id=(\S+)') { $Matches[1] }
if (-not $winId) { throw "no tree-write window on $Lib within $MaxWaitMin min: not landing" }
foreach ($live in @($pairs | Where-Object { -not $_.New } | ForEach-Object Live) + $Remove) { $u = Join-Path $undo $live; New-Item -ItemType Directory -Force (Split-Path $u) | Out-Null; Copy-Item -LiteralPath (Join-Path $Lib $live) -Destination $u }
$landedHash = @{}
function Restore-Undo {
    foreach ($gone in $Remove) { Copy-Retry (Join-Path $undo $gone) (Join-Path $Lib $gone) }
    foreach ($p in $pairs) {
        $live = Join-Path $Lib $p.Live
        if ($landedHash.ContainsKey($p.Live) -and (Test-Path -LiteralPath $live) -and (Get-FileHash -LiteralPath $live).Hash -ne $landedHash[$p.Live]) {
            "SKIP restore of $($p.Live): another writer changed it after this land applied (now $((Get-FileHash -LiteralPath $live).Hash.Substring(0, 12))); left as is"
            continue
        }
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
    if ($baseProbe.Count -and -not $ProvenLog) { $baseFail = Get-ProbeFailures @(pwsh -NoProfile -File (Join-Path $PSScriptRoot 'type_probe.ps1') -File ($baseProbe -join ',') -Lib $Lib 2>&1 | ForEach-Object { "$_" }) }
    foreach ($p in $pairs) { Copy-Retry $p.Source (Join-Path $Lib $p.Live); $landedHash[$p.Live] = (Get-FileHash -LiteralPath (Join-Path $Lib $p.Live)).Hash }
    foreach ($gone in $Remove) { Remove-Item -LiteralPath (Join-Path $Lib $gone) -Force }
    $closeOk = $true; $why = [Collections.Generic.List[string]]::new()
    if ($ProvenLog -and $provenExact) {
        foreach ($p in $pairs) { "{0,-28} {1}" -f $p.Live, (Get-FileHash -LiteralPath (Join-Path $Lib $p.Live)).Hash.Substring(0, 12) }
        "LANDED from a proven close ($ProvenLog); undo: $undo"
        return
    }
    $repo = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
    '=== signatures'
    $spelling = { param($text) $text -replace '(?<=[\w''])::(?=[\w(])', '.' }
    $consumerText = (@($Consumer | ForEach-Object { Get-ChildItem (Split-Path (Join-Path $repo $_)) -Filter *.spi -File }) | Sort-Object FullName -Unique | ForEach-Object { [IO.File]::ReadAllText($_.FullName) }) -join "`n"
    $checked = 0
    $ownDefs = @([regex]::Matches($consumerText, '(?m)^(?::=|:~ \^?|inl|let|:~) *([\w'']+)') | ForEach-Object { $_.Groups[1].Value } | Sort-Object -Unique)
    $drift = foreach ($live in @($pairs | Where-Object { -not $_.New } | ForEach-Object Live) + $Remove) {
        $stem = [IO.Path]::GetFileNameWithoutExtension($live)
        $before = [IO.File]::ReadAllLines((Join-Path $undo $live))
        $defined = @($before | ForEach-Object { if ($_ -match '^(?::=|:~ \^?|inl|let|:~) *(\([^)\s]+\)|[\w'']+)') { $Matches[1] } } | Sort-Object -Unique)
        $opened = [regex]::IsMatch($consumerText, '(?m)^\s*(open|:<)\s+' + [regex]::Escape($stem) + '\s*$')
        $used = @(@([regex]::Matches($consumerText, '(?<![\w''])' + [regex]::Escape($stem) + '(?:::|\.)([\w'']+|\([^)\s]+\))') | ForEach-Object { $_.Groups[1].Value }) + @($defined | Where-Object {
            if ($_ -like '(*)') { $consumerText.Contains(" $($_.Trim('(', ')')) ") } else { $opened -and $_ -notin $ownDefs -and [regex]::IsMatch($consumerText, '(?<![\w''.:])' + [regex]::Escape($_) + '(?![\w''])') } }) | Sort-Object -Unique)
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
    if ($drift) { $drift; $closeOk = $false; $why.Add('consumer signatures changed') } else { "$checked consumer-used signatures unchanged" }
    '=== consumers'
    if (-not $env:SPIRAL_COMPILER_PACKAGE_DIR) { $env:SPIRAL_COMPILER_PACKAGE_DIR = Join-Path $repo 'deps/The-Spiral-Language/VS Code Plugin' }
    $consumerOut = Join-Path ($env:LOCALAPPDATA ?? $env:XDG_CACHE_HOME ?? (Join-Path $HOME '.cache')) 'spiral-bin/mix-builds/lib-land-consumers'
    New-Item -ItemType Directory -Force $consumerOut | Out-Null
    foreach ($c in $Consumer) {
        $entry = Join-Path $repo $c
        Push-Location (Split-Path $entry)
        try { $text = @(& $Dotnet $Compiler --backend Rust (Split-Path $entry -Leaf) (Join-Path $consumerOut "$([IO.Path]::GetFileNameWithoutExtension($entry)).rs") 2>&1 | ForEach-Object { "$_" }); $code = $LASTEXITCODE } finally { Pop-Location }
        if ($code) { "$c exit ${code}: $(@($text | Where-Object { $_ -match 'Error' } | Select-Object -First 1))"; $closeOk = $false; $why.Add("consumer $c exit $code") } else { "$c compiles" }
    }
    '=== document_test'
    if ($ProvenLog) { "taken from $ProvenLog : $(@($proof | Where-Object { $_ -match '^Result:' }) -join ' ')" } else {
    $mix = Set-MixEnv
    $docLog = Join-Path $undo 'document_test.log'
    New-Item -ItemType Directory -Force $undo | Out-Null
    Push-Location (Join-Path $PSScriptRoot '..')
    try { $docOut = @(& $mix test test/spiral/document_test.exs --timeout 900000 2>&1 | ForEach-Object { "$_" }); $docExit = $LASTEXITCODE } finally { Pop-Location }
    $docOut | Set-Content -LiteralPath $docLog
    $docOut | Where-Object { $_ -match '^\s+\d+\) test |Result:' } | ForEach-Object { $_.Trim() }
    if ($docExit) {
        $closeOk = $false; $why.Add("document_test exit $docExit (log $docLog)")
        @($docOut | ForEach-Object { if ($_ -match '(\S*lib[\\/]spiral[\\/]\S+\.(?:spi|spir))') { $Matches[1] } } | Select-Object -Unique -First 10) | ForEach-Object { "document_test names $_" }
        "document_test exit ${docExit}; full log: $docLog"
    }
    }
    '=== type_probe'
    if ($probe.Count) {
        $lines = @(pwsh -NoProfile -File (Join-Path $PSScriptRoot 'type_probe.ps1') -File ($probe -join ',') -Lib $Lib 2>&1 | ForEach-Object { "$_" })
        $probeExit = $LASTEXITCODE
        $lines | Select-Object -Last ($probe.Count + 1)
        $nowFail = Get-ProbeFailures $lines
        $newFail = @($nowFail | Where-Object { $_ -notin $baseFail })
        if ($baseFail) { "type_probe: $($baseFail.Count) already failed before this land, not blocking: $($baseFail -join ', ')" }
        if ($newFail) { "type_probe NEW failures: $($newFail -join ', ')"; $closeOk = $false; $why.Add("type_probe NEW failures: $($newFail -join ', ')") }
        elseif ($probeExit -and -not $nowFail) { "type_probe exit $probeExit with no FAIL rows"; $closeOk = $false; $why.Add("type_probe exit $probeExit") }
    }
    '=== respell_drift'
    if ($probe.Count) {
        $drifted = @(& $Dotnet $Compiler format --check --respell-drift @($probe | ForEach-Object { Join-Path $Lib $_ }) 2>&1 | ForEach-Object { "$_" } | Where-Object { $_ -match ': respell-drift ' })
        if ($drifted) { $drifted | Select-Object -First 10; "respell_drift: $($drifted.Count) findings in the landed files"; $closeOk = $false; $why.Add("respell_drift $($drifted.Count) findings") } else { "0 respell-drift findings in $($probe.Count) landed files" }
    }
    if (-not $closeOk) { "CLOSE FAILED ($($why -join '; ')): undoing"; Restore-Undo; throw "close failed ($($why -join '; ')); undone" }
    foreach ($p in $pairs) { "{0,-28} {1}" -f $p.Live, (Get-FileHash -LiteralPath (Join-Path $Lib $p.Live)).Hash.Substring(0, 12) }
    "lib digest $(Get-LibDigest @{})"
    "LANDED and closed green; undo: $undo"
} catch { if ("$_" -notmatch 'undone') { Restore-Undo }; throw } finally { if ($winId) { & $kit window release $winId 2>&1 | Select-Object -Last 1 } }
