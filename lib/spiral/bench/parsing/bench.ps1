# split_args / lib/spiral/parsing benchmark pipeline. See README.md.
#   pwsh bench.ps1 -Label before                 # compile + run F# (FParsec vs pure vs runtime) and native Rust
#   pwsh bench.ps1 -Label after -Compare before  # same, then diff results (behaviour) and timings against `before`
#   pwsh bench.ps1 -Label x -Cells               # also time the compile of every parsing.livemd test cell (F#)
#   pwsh bench.ps1 -Label x -Cells -Backends None  # only the per-cell compile times
# Outputs go to bench/parsing/target/<Label>/ (gitignored): compile times, program output, summary.tsv.
param(
    [string] $Label = 'run',
    [string] $Compare,
    [ValidateSet('Fsharp', 'Rust', 'None')] [string[]] $Backends = @('Fsharp', 'Rust'),
    [switch] $Cells,
    [string] $Notebook = (Join-Path $PSScriptRoot '../../parsing.livemd'), # -Cells: notebook whose test cells are compiled
    [string] $LibDir = (Join-Path $PSScriptRoot '../../..'), # -Cells: packageDir holding the spiral package
    [switch] $SkipCompile, # reuse the generated sources of this label (only rebuild + run)
    [string] $Agent = 'parsing-bench',
    [string] $Spc, # optional compile wrapper (pwsh $Spc -Agent -Backend -In -Out); default: the polyglot spiral bundle
    [string] $Heavy, # optional script defining Invoke-Heavy (a machine-wide memory mutex) for the dotnet/cargo builds
    [string] $RustToolchain = 'nightly-2025-11-01',
    [int] $MinFreeMB = 2500,
    [switch] $MemoryWait, # build without the heavy slot once -MinFreeMB is free (instead of queueing behind long jobs)
    [string] $TraceLevel = 'Info', # TRACE_LEVEL for the benchmark runs; '' leaves it unset
    [int] $RunTimeoutMin = 20 # wall-clock limit per benchmark program run
)
$ErrorActionPreference = 'Stop'
$here = $PSScriptRoot
$root = Join-Path $here "target/$Label"
New-Item -ItemType Directory -Force $root | Out-Null
$heavyAvailable = $Heavy -and (Test-Path $Heavy)
if ($heavyAvailable) { . $Heavy }
function Set-TraceLevel { [Environment]::SetEnvironmentVariable('TRACE_LEVEL', $(if ($TraceLevel) { $TraceLevel } else { $null })) }
# Runs a benchmark program with stdout streamed to $file (a stuck case is visible there) under a wall-clock limit.
function Invoke-Bench([string] $exe, [string] $file) {
    Set-TraceLevel
    $p = Start-Process -FilePath $exe -NoNewWindow -PassThru -RedirectStandardOutput $file -RedirectStandardError "$file.err"
    $null = $p.Handle
    if (!$p.WaitForExit($RunTimeoutMin * 60 * 1000)) {
        $p.Kill($true)
        throw "$exe timed out after $RunTimeoutMin min; last output line: $(Get-Content $file -Tail 1)"
    }
    if ($p.ExitCode -ne 0) { Get-Content "$file.err" -Tail 20 | Write-Host; throw "$exe exited with $($p.ExitCode)" }
    Get-Content $file
}
# The dotnet/cargo builds take a machine-wide heavy slot (Invoke-Heavy) by default, as RULES.md asks; with -MemoryWait
# they only wait for -MinFreeMB of free memory, so a long notebook run holding both slots doesn't stall the benchmark.
function Heavy([scriptblock] $b) {
    $free = [int]((Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory / 1KB)
    if ($heavyAvailable -and !$MemoryWait) { Invoke-Heavy $b; return }
    # Wait (up to 30 min) for enough free memory instead of queueing behind hour-long jobs in the heavy slots.
    $until = (Get-Date).AddMinutes(30)
    while ($free -lt $MinFreeMB -and (Get-Date) -lt $until) {
        Write-Host "bench.ps1: $free MB free < $MinFreeMB, waiting"
        Start-Sleep 20
        $free = [int]((Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory / 1KB)
    }
    if ($free -lt $MinFreeMB -and $heavyAvailable) { Invoke-Heavy $b } else { & $b }
}
$compileTimes = [ordered]@{}

# The compiler of the polyglot spiral bundle (as lib.ps1's BuildSpiral), run from the entry's directory.
function Invoke-BundleCompiler([string] $backend, [string] $in, [string] $out) {
    . (Join-Path $here '../../../../deps/polyglot/scripts/spiral-bundle.ps1')
    # The bundle points DOTNET_ROOT at its .NET 11 toolchain; the F# benchmark exe (net9.0) must keep the system one.
    $dotnetRoot = $env:DOTNET_ROOT
    try { $spiral = Ensure-SpiralRustCompiler | Select-Object -Last 1 } finally { $env:DOTNET_ROOT = $dotnetRoot }
    if (!$env:SPIRAL_COMPILER_PACKAGE_DIR) {
        $env:SPIRAL_COMPILER_PACKAGE_DIR = & { . (Join-Path $spiral.Bundle 'scripts/env.ps1'); Get-SpiralPackageDir }
    }
    Push-Location (Split-Path $in)
    try { & $spiral.Dotnet $spiral.Compiler --backend $backend (Split-Path $in -Leaf) $out 2>&1 } finally { Pop-Location }
}

function Compile-Spiral([string] $backend, [string] $in, [string] $out) {
    # The compiler host also writes its output next to the entry module (<entry>.fsx / .rs ...): remove those copies so
    # nothing generated is left in the source tree.
    $srcDir = Split-Path $in
    $existing = @(Get-ChildItem $srcDir -File | Select-Object -ExpandProperty FullName)
    $sw = [Diagnostics.Stopwatch]::StartNew()
    $log = if ($Spc) { & pwsh $Spc -Agent $Agent -Backend $backend -In $in -Out $out 2>&1 } else { Invoke-BundleCompiler $backend $in $out }
    Get-ChildItem $srcDir -File |
        Where-Object { $_.FullName -notin $existing -and $_.FullName -ne [IO.Path]::GetFullPath($out) -and $_.BaseName -eq [IO.Path]::GetFileNameWithoutExtension($in) -and $_.Extension -ne '.spi' } |
        ForEach-Object { Remove-Item -LiteralPath $_.FullName -Force }
    $code = $LASTEXITCODE
    $sw.Stop()
    if ($code -ne 0 -or !(Test-Path $out)) { $log | Select-Object -Last 40 | Write-Host; throw "compile failed: $in ($backend)" }
    $lines = (Get-Content $out | Measure-Object -Line).Lines
    Write-Host ("compiled {0} ({1}) in {2:n1} s, {3} lines" -f (Split-Path $in -Leaf), $backend, $sw.Elapsed.TotalSeconds, $lines)
    [pscustomobject]@{ Seconds = [math]::Round($sw.Elapsed.TotalSeconds, 1); Lines = $lines }
}

$outputs = @{}
if ('Fsharp' -in $Backends) {
    $dir = Join-Path $root 'fsharp'
    New-Item -ItemType Directory -Force $dir | Out-Null
    $fs = Join-Path $dir 'bench.fs'
    if (!$SkipCompile) { $compileTimes['main.spi (Fsharp)'] = Compile-Spiral Fsharp (Join-Path $here 'main.spi') $fs }
    @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <Optimize>true</Optimize>
    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
    <NoWarn>$(NoWarn);FS0025;FS0049;FS0064;FS1182;FS3370;FS0020</NoWarn>
    <ServerGarbageCollection>false</ServerGarbageCollection>
    <TieredPGO>true</TieredPGO>
  </PropertyGroup>
  <ItemGroup>
    <Compile Include="bench.fs" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="FParsec" Version="2.0.0-beta2" />
  </ItemGroup>
</Project>
'@ | Set-Content (Join-Path $dir 'bench.fsproj')
    # SDK 9 pinned: the 11.0 rc SDK doesn't copy FSharp.Core 11 next to the exe.
    '{ "sdk": { "version": "9.0.308", "rollForward": "latestFeature" } }' | Set-Content (Join-Path $dir 'global.json')
    Push-Location $dir
    try { Heavy { dotnet build -c Release bench.fsproj -o bin -v q -nologo 2>&1 | Select-Object -Last 15 | Write-Host } } finally { Pop-Location }
    if ($LASTEXITCODE -ne 0) { throw 'dotnet build failed' }
    $out = Invoke-Bench (Join-Path $dir 'bin/bench.exe') (Join-Path $dir 'output.txt')
    $outputs['Fsharp'] = $out
}
if ('Rust' -in $Backends) {
    $dir = Join-Path $root 'rust'
    New-Item -ItemType Directory -Force (Join-Path $dir 'src') | Out-Null
    $rs = Join-Path $dir 'src/main.rs'
    if (!$SkipCompile) { $compileTimes['main.spi (Rust)'] = Compile-Spiral Rust (Join-Path $here 'main.spi') $rs }
    @'
[package]
name = "bench_parsing"
version = "0.0.1"
edition = "2021"

[workspace]

[profile.release]
opt-level = 3
lto = "thin"
codegen-units = 1
'@ | Set-Content (Join-Path $dir 'Cargo.toml')
    Push-Location $dir
    try {
        Heavy { cargo "+$RustToolchain" build --release --quiet 2>&1 | Select-Object -Last 40 | Write-Host }
        if ($LASTEXITCODE -ne 0) { throw 'cargo build failed' }
    } finally { Pop-Location }
    $out = Invoke-Bench (Join-Path $dir 'target/release/bench_parsing.exe') (Join-Path $dir 'output.txt')
    $outputs['Rust'] = $out
}

# Backends not run this time: reuse this label's earlier output, so the summary always covers both.
foreach ($b in 'Fsharp', 'Rust') {
    $prev = Join-Path $root "$($b.ToLower())/output.txt"
    if (!$outputs.ContainsKey($b) -and (Test-Path $prev)) { $outputs[$b] = Get-Content $prev }
}

if ($Cells) {
    # Every `///- --test` cell of parsing.livemd that uses the pure-Spiral library (FParsec cells need the #r'd DLLs and
    # the `--test static` frontend, so they are skipped), compiled to F# as its own program.
    # a Spiral cell's source is its smart-cell annotation's attrs.source (spiral/apps/kino Document)
    $sources = [regex]::Matches((Get-Content -Raw $Notebook), '<!-- livebook:(\{"chunks".*?"kind":"Elixir\.Spiral\.Kino\.SmartCell".*?\}) -->') | ForEach-Object { 'spiral' + "`n" + ($_.Groups[1].Value | ConvertFrom-Json).attrs.source }
    $cellList = $sources | Where-Object { $_ -match '^spiral' -and $_ -match '///- --test' -and $_ -notmatch '///- --test static' -and $_ -notmatch '_ \(|\$''FParsec|parse_ |#r ' }
    $cdir = Join-Path $root 'cells'
    $i = 0
    foreach ($c in $cellList) {
        $i++
        $d = Join-Path $cdir ('cell{0:d2}' -f $i)
        New-Item -ItemType Directory -Force $d | Out-Null
        $body = ($c -split "`n" | Select-Object -Skip 1 | Where-Object { $_ -notmatch '^///' }) | ForEach-Object { "    $_" }
        "packageDir: $((Resolve-Path $LibDir).Path)`npackages:`n    |core-`n    spiral-`nmodules:`n    main`n" | Set-Content (Join-Path $d 'package.spiproj') -NoNewline
        ("open parsing`nopen testing`nopen sm'_operators`n`ninl main () =`n" + ($body -join "`n") + "`n") | Set-Content (Join-Path $d 'main.spi') -NoNewline
        $first = ($body | Where-Object { $_.Trim() } | Select-Object -First 2) -join ' / '
        try { $compileTimes[('cell{0:d2} {1}' -f $i, $first.Trim())] = Compile-Spiral Fsharp (Join-Path $d 'main.spi') (Join-Path $d 'main.fsx') }
        catch { $compileTimes[('cell{0:d2} {1}' -f $i, $first.Trim())] = [pscustomobject]@{ Seconds = -1; Lines = -1 } }
    }
}

# Summary: one row per (backend, case) with ns/call per impl and ratios against FParsec; RESULT mismatches across impls.
$rows = foreach ($b in $outputs.Keys) {
    $times = $outputs[$b] | Where-Object { $_ -like "TIME`t*" } | ForEach-Object { $f = $_ -split "`t"; [pscustomobject]@{ Backend = $b; Impl = $f[1]; Case = $f[2]; Len = [int]$f[3]; Iters = [int]$f[4]; Ns = [long]$f[5] } }
    foreach ($g in $times | Group-Object Case) {
        $r = [ordered]@{ Backend = $b; Case = $g.Name; Len = $g.Group[0].Len }
        foreach ($t in $g.Group) { $r["$($t.Impl)_ns"] = $t.Ns }
        [pscustomobject]$r
    }
}
$fsRef = @{}
$rows | Where-Object { $_.Backend -eq 'Fsharp' -and $_.PSObject.Properties['fparsec_ns'] } | ForEach-Object { $fsRef[$_.Case] = $_.fparsec_ns }
$rows = $rows | ForEach-Object {
    $ref = $fsRef[$_.Case]
    if ($ref) {
        foreach ($impl in 'pure', 'runtime') {
            if ($_.PSObject.Properties["$($impl)_ns"]) { $_ | Add-Member "$($impl)_vs_fparsec" ([math]::Round($_."$($impl)_ns" / $ref, 2)) }
        }
    }
    $_
}
$rows | Export-Csv -Delimiter "`t" -NoTypeInformation (Join-Path $root 'summary.tsv')
$rows | Format-Table -AutoSize | Out-String -Width 220 | Write-Host

$results = foreach ($b in $outputs.Keys) {
    $outputs[$b] | Where-Object { $_ -like "RESULT`t*" } | ForEach-Object { $f = $_ -split "`t", 5; [pscustomobject]@{ Backend = $b; Impl = $f[1]; Case = $f[2]; Args = $f[4] } }
}
$results | Export-Csv -Delimiter "`t" -NoTypeInformation (Join-Path $root 'results.tsv')
Write-Host 'cases where implementations disagree (pure vs fparsec are the same grammar; runtime has extra \" delimiters):'
foreach ($g in $results | Group-Object Case) {
    $distinct = $g.Group | Group-Object { "$($_.Impl)" -replace '^(pure|fparsec)$', 'dib-grammar' } | ForEach-Object { ($_.Group | Select-Object -ExpandProperty Args -Unique).Count }
    $byImpl = $g.Group | Group-Object Impl | ForEach-Object { "$($_.Name)[$(@($_.Group | Select-Object -ExpandProperty Args -Unique).Count)]=$($_.Group[0].Args)" }
    $pureF = $g.Group | Where-Object Impl -in 'pure', 'fparsec' | Select-Object -ExpandProperty Args -Unique
    if (@($pureF).Count -gt 1) { Write-Host "  $($g.Name): $($byImpl -join ' ; ')" }
}

if ($outputs.ContainsKey('Fsharp') -and $outputs.ContainsKey('Rust')) {
    $fsr = @{}
    $results | Where-Object Backend -eq 'Fsharp' | ForEach-Object { $fsr["$($_.Impl)/$($_.Case)"] = $_.Args }
    $bad = @($results | Where-Object { $_.Backend -eq 'Rust' -and $fsr["$($_.Impl)/$($_.Case)"] -ne $_.Args })
    if ($bad) { Write-Host "NATIVE != F# for $($bad.Count) results:"; $bad | ForEach-Object { Write-Host "  $($_.Impl)/$($_.Case): rust=$($_.Args) fsharp=$($fsr["$($_.Impl)/$($_.Case)"])" } }
    else { Write-Host "native Rust results identical to F# ($(@($results | Where-Object Backend -eq 'Rust').Count) results)" }
}

$compileTimes.GetEnumerator() | ForEach-Object { [pscustomobject]@{ Program = $_.Key; Seconds = $_.Value.Seconds; Lines = $_.Value.Lines } } |
    Tee-Object -Variable ct | Format-Table -AutoSize | Out-String -Width 220 | Write-Host
if ($ct) { $ct | Export-Csv -Delimiter "`t" -NoTypeInformation (Join-Path $root 'compile.tsv') }

if ($Compare) {
    $other = Join-Path $here "target/$Compare"
    $old = Import-Csv -Delimiter "`t" (Join-Path $other 'results.tsv')
    $diff = Compare-Object $old $results -Property Backend, Impl, Case, Args
    if ($diff) { Write-Host "BEHAVIOUR CHANGED vs $Compare :"; $diff | Format-Table -AutoSize | Out-String -Width 250 | Write-Host }
    else { Write-Host "results identical to $Compare ($(@($results).Count) rows)" }
    $oldRows = Import-Csv -Delimiter "`t" (Join-Path $other 'summary.tsv')
    $cmp = foreach ($r in $rows) {
        $o = $oldRows | Where-Object { $_.Backend -eq $r.Backend -and $_.Case -eq $r.Case }
        if ($o) {
            $x = [ordered]@{ Backend = $r.Backend; Case = $r.Case; Len = $r.Len }
            foreach ($impl in 'fparsec', 'pure', 'runtime') {
                if ($r.PSObject.Properties["$($impl)_ns"] -and $o.PSObject.Properties["$($impl)_ns"]) {
                    $x["$($impl)_before"] = [long]$o."$($impl)_ns"; $x["$($impl)_after"] = $r."$($impl)_ns"
                }
            }
            [pscustomobject]$x
        }
    }
    $cmp | Export-Csv -Delimiter "`t" -NoTypeInformation (Join-Path $root "compare_$Compare.tsv")
    $cmp | Format-Table -AutoSize | Out-String -Width 250 | Write-Host
}
