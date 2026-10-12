# Times the Brzozowski workloads of runtime_workload.spi (derivative matcher, naive backtracking matcher, staged DFA) and of
# runtime_interned.spi (interned regex nodes with memoized derivatives) on
# the native backends. Each bench_* package is compiled (single-flight) to C, Rust, Delphi and F# and built with the
# suite's flags (gcc -O2, rustc opt-level=2, fpc -O2, dotnet Release); then every target runs once per round for -Repeat
# rounds (round-robin, so load changes on a busy machine hit all targets alike). The table shows the median and minimum
# wall time of the whole process; runtime_native (a dozen matches) is the process-start baseline. With -RegexCrate, the
# same inputs through Rust's regex crate (regex_crate_bench.rs; needs the crate in the cargo cache, built --offline).
#
#   pwsh samples/mega_brzozowski_derivatives/bench.ps1                     # from apps/compiler/tmp
#   pwsh samples/mega_brzozowski_derivatives/bench.ps1 -Repeat 11 -Backend C,Rust -RegexCrate
#
# Builds and timings go to <cache>/bench/brzozowski (nothing is written to the tree except the compiler's outputs
# next to each main.spi, as in every suite run).
param(
    [int]$Repeat = 7,
    [string[]]$Backend = @('C', 'Rust', 'Delphi', 'Fsharp'),
    [string[]]$Program = @('runtime_native', 'bench_derivative', 'bench_backtrack', 'bench_staged', 'bench_interned', 'bench_zero_runs_derivative', 'bench_zero_runs_backtrack', 'bench_zero_runs_staged', 'bench_zero_runs_interned'),
    [switch]$SkipCompile,
    [switch]$RegexCrate
)
$ErrorActionPreference = 'Stop'
$tmpRoot = Resolve-Path (Join-Path $PSScriptRoot '../..')
. (Join-Path $tmpRoot 'scripts/env.ps1')
$Backend = @($Backend | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$Program = @($Program | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$tools = Get-SpiralNativeTools
$out = Join-Path (Get-SpiralCacheDir) 'bench/brzozowski'
New-Item -ItemType Directory -Force $out | Out-Null
$ext = @{ C = 'c'; Rust = 'rs'; Delphi = 'pas'; Fsharp = 'fsx' }

function Invoke-Checked([string]$what, [scriptblock]$block) {
    $text = & $block 2>&1 | Out-String
    if ($LASTEXITCODE -ne 0) { throw "$what failed ($LASTEXITCODE): $text" }
}

function Build-Program([string]$name, [string]$backend) {
    $sample = "mega_brzozowski_derivatives/$name"
    $source = Join-Path $PSScriptRoot "$name/main.$($ext[$backend])"
    if (-not $SkipCompile) {
        $probe = & pwsh -NoProfile (Join-Path $tmpRoot 'scripts/probe.ps1') $sample -Mode single-flight -Backend $backend 2>&1 | Out-String
        if (-not (Test-Path $source) -or $probe -notmatch '\s1\s+0\s') { throw "spiral compile of $sample ($backend) failed:`n$probe" }
    }
    $dir = Join-Path $out "$name/$backend"
    New-Item -ItemType Directory -Force $dir | Out-Null
    # Build from a copy in the cache. The suite compiles the bench_* packages to F# only, so their C/Rust/Delphi
    # outputs would go stale in the tree: those leave it (-SkipCompile then reuses the cached copy).
    $cached = Join-Path $dir "main.$($ext[$backend])"
    if (Test-Path $source) {
        Copy-Item $source $cached -Force
        if ($name -like 'bench_*' -and $backend -ne 'Fsharp') { [IO.File]::Delete($source) }
    }
    elseif (-not (Test-Path $cached)) { throw "no $backend output for $sample (run without -SkipCompile)" }
    $source = $cached
    $exe = Join-Path $dir 'main.exe'
    switch ($backend) {
        'C' { Invoke-Checked "gcc $name" { & $tools.CC -std=c11 -O2 -w -o $exe $source -lm } }
        'Rust' { Invoke-Checked "rustc $name" { & $tools.Rustc -C opt-level=2 -A warnings --edition 2024 -o $exe $source } }
        'Delphi' { Invoke-Checked "fpc $name" { & $tools.Fpc -O2 -Mdelphi "-FE$dir" "-FU$dir" "-o$exe" $source } }
        'Fsharp' {
            # The F# output is a script whose top level runs the program: compiled as the last file of a Release exe.
            Copy-Item $source (Join-Path $dir 'Program.fs') -Force
            [IO.File]::WriteAllText((Join-Path $dir 'bench.fsproj'), @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework><Optimize>true</Optimize>
    <NoWarn>FS0025;FS0020;FS0064;FS1182</NoWarn><TreatWarningsAsErrors>false</TreatWarningsAsErrors>
    <AssemblyName>main</AssemblyName><SatelliteResourceLanguages>en</SatelliteResourceLanguages></PropertyGroup>
  <ItemGroup><Compile Include="Program.fs" /></ItemGroup>
</Project>
"@)
            Invoke-Checked "dotnet build $name" { dotnet build (Join-Path $dir 'bench.fsproj') -c Release -o (Join-Path $dir 'bin') -nologo -v q -nodeReuse:false }
            $exe = Join-Path $dir 'bin/main.exe'
        }
    }
    $exe
}

function Invoke-Timed([string]$exe, [string[]]$arguments) {
    $sw = [Diagnostics.Stopwatch]::StartNew()
    & $exe @arguments | Out-Null
    $code = $LASTEXITCODE
    $sw.Stop()
    if ($code -ne 0) { throw "$exe exited $code" }
    $sw.Elapsed.TotalMilliseconds
}

$os = Get-CimInstance Win32_OperatingSystem
$cpu = (Get-CimInstance Win32_Processor | Select-Object -First 1)
Write-Host ("machine: {0}, {1} logical CPUs; {2:N1} GB free of {3:N1} GB; load {4}%; {5}" -f $cpu.Name.Trim(), [Environment]::ProcessorCount,
    ($os.FreePhysicalMemory / 1MB), ($os.TotalVisibleMemorySize / 1MB), $cpu.LoadPercentage, (Get-Date -Format 'yyyy-MM-dd HH:mm'))
# Build everything first, then time round-robin (every target once per round), so load changes on a busy machine hit
# all targets alike instead of whichever program happened to run during them.
$targets = [Collections.Generic.List[object]]::new()
foreach ($name in $Program) {
    foreach ($b in $Backend) { $targets.Add([pscustomobject]@{ Program = $name; Backend = $b; Exe = (Build-Program $name $b); Args = @(); Times = [Collections.Generic.List[double]]::new() }) }
}
if ($RegexCrate) {
    # The same LCG inputs and anchored regexes, through the regex crate.
    $crate = Join-Path $out 'regexbench'
    New-Item -ItemType Directory -Force (Join-Path $crate 'src') | Out-Null
    Copy-Item (Join-Path $PSScriptRoot 'regex_crate_bench.rs') (Join-Path $crate 'src/main.rs') -Force
    [IO.File]::WriteAllText((Join-Path $crate 'Cargo.toml'), "[package]`nname = `"regexbench`"`nversion = `"0.1.0`"`nedition = `"2021`"`n`n[dependencies]`nregex = `"1`"`n`n[profile.release]`nopt-level = 2`n")
    Invoke-Checked 'cargo build regexbench' { cargo build --release --offline --quiet --manifest-path (Join-Path $crate 'Cargo.toml') }
    $exe = Join-Path $crate 'target/release/regexbench.exe'
    foreach ($w in @(@{ Name = 'regex_crate_random'; Args = @('2000', '32', '0'); Expect = '^997 985 0 ' }, @{ Name = 'regex_crate_zero_runs'; Args = @('0', '32', '26'); Expect = '^0 0 26 ' })) {
        $check = & $exe @($w.Args)
        if ($check -notmatch $w.Expect) { throw "regex crate counts differ: $check" }
        $targets.Add([pscustomobject]@{ Program = $w.Name; Backend = 'Rust'; Exe = $exe; Args = $w.Args; Times = [Collections.Generic.List[double]]::new() })
    }
}
Write-Host ("built {0} targets; timing {1} rounds" -f $targets.Count, $Repeat)
foreach ($round in 1..$Repeat) { foreach ($x in $targets) { $x.Times.Add((Invoke-Timed $x.Exe $x.Args)) } }
$rows = @(foreach ($x in $targets) {
    $sorted = @($x.Times | Sort-Object)
    $median = $sorted[[int][Math]::Floor($sorted.Count / 2)]
    Write-Host ("{0,-28} {1,-7} median {2,8:N0} ms  (min {3:N0}, max {4:N0}, n={5})" -f $x.Program, $x.Backend, $median, $sorted[0], $sorted[-1], $sorted.Count)
    [pscustomobject]@{ program = $x.Program; backend = $x.Backend; median_ms = [Math]::Round($median, 1); min_ms = [Math]::Round($sorted[0], 1)
        max_ms = [Math]::Round($sorted[-1], 1); runs = $sorted.Count; times_ms = ($x.Times | ForEach-Object { [Math]::Round($_, 1) }) -join ',' }
})
$tsv = Join-Path $out ("bench-{0}.tsv" -f (Get-Date -Format 'yyyyMMdd-HHmmss'))
$rows | Export-Csv $tsv -Delimiter "`t" -NoTypeInformation -UseQuotes Never
Write-Host "results: $tsv"
