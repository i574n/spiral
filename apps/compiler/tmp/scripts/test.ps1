<#
.SYNOPSIS
Compiles the Spiral corpora with one compiler mode and scores the result against the
single-flight baseline (<cache>/baseline/EXPECTED.tsv, written by -Bless).

.DESCRIPTION
Suites (combine freely):
  frontier   samples/frontier_*           smallest programs the Hopac core must finish first
  smoke      tests/harness.psd1 Smoke     a few seconds of broad coverage
  examples   samples/<name>               backend fixtures (F#, C, Rust, Delphi)
  contracts  samples/contract_*,          type-system contract cases (F#), and the megaprojects'
             samples/mega_*/<package>     sub-packages
  mega       tests/harness.psd1 Mega      the five megaprojects
  all        everything above

A sample is a directory with main.spi (top-down) or main.spir (bottom-up) and package.spiproj.
samples/core is the portable `core-` package the fixtures share; `|core-` resolves to The-Spiral-Language's
core through the repo's deps/polyglot link (Get-SpiralPackageDir). Hand-written tables (smoke list, known
failures, megaproject roots, C flags, backends) are tests/harness.psd1.

The compiler writes its output next to its source (samples/<name>/main.c, ...), replacing the previous
one; those files are committed, so `git diff samples` shows what a run changed. A run holds a lock, so two
runs (e.g. hopac and single-flight) never write the same files at once. Run records, the oracle baseline,
scoreboards and native binaries live in the cache directory.

Every compile of one worker runs inside a single warm compiler process (`SpiralCompiler --batch`),
so startup and core-library parsing are paid once. A job that hangs past -TimeoutSec or crashes the
process is recorded and the worker restarts after it.

With -Native, C/Rust/Delphi residuals are built and run. C is the semantic oracle: Rust and Delphi
must reproduce its exit code and stdout.

.EXAMPLE
pwsh scripts/test.ps1 -Mode hopac -Suite frontier            # the hopac inner loop
pwsh scripts/test.ps1 -Suite all -Native                      # full single-flight regression run
pwsh scripts/test.ps1 -Suite all -Native -Bless               # refresh the single-flight baseline
pwsh scripts/test.ps1 -Mode hopac -Suite all -Record          # update the hopac scoreboard (<cache>/scoreboards)
#>
param(
    [ValidateSet('single-flight', 'sf', 'hopac', 'hp')][string]$Mode = 'single-flight',
    # One or more of: frontier, smoke, examples, contracts, mega, all (comma-separated works from any shell).
    [string[]]$Suite = @('smoke'),
    [string]$Filter,
    # Restrict to some of: Fsharp, C, Rust, Delphi.
    [string[]]$Backend,
    [int]$TimeoutSec = 0,
    [int]$Parallel = 0,
    [switch]$Native,
    [switch]$Bless,
    [switch]$Record,
    # One compiler process per job. Default on in hopac mode, whose core serves one BuildFile per process.
    [switch]$FreshProcess,
    [ValidateSet('Release', 'Debug')][string]$Configuration = 'Release',
    # Workspace root for the compiler (SPIRAL_WORKSPACE_ROOT). Defaults to this directory.
    [string]$WorkspaceRoot
)
. $PSScriptRoot/env.ps1
$harness = Import-PowerShellDataFile (Join-Path $BundleRoot 'tests/harness.psd1')
$Suite = @($Suite | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
$Backend = @($Backend | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
foreach ($s in $Suite) { if ($s -notin 'frontier', 'smoke', 'examples', 'contracts', 'mega', 'all') { throw "unknown suite '$s'" } }
foreach ($b in $Backend) { if ($b -notin 'Fsharp', 'C', 'Rust', 'Delphi') { throw "unknown backend '$b'" } }
$mode = ConvertTo-SpiralMode $Mode
# Per-job timeouts stay small: fast samples compile in well under a second once the core library is warm,
# so anything slower is a hang (the expected Hopac failure mode) and should cost seconds, not minutes.
# A fresh hopac process needs ~9-12 s for a trivial program (startup, core warm-up, commit and run-end
# grace), and the host reports a stall as an error 7 s before the job timeout, so 20 s is the floor.
$suiteTimeoutSec = @{ frontier = 20; smoke = 20; examples = 20; contracts = 30; mega = 180 }
$freshProcess = if ($PSBoundParameters.ContainsKey('FreshProcess')) { [bool]$FreshProcess } else { $mode -eq 'hopac' }
if ($Parallel -le 0) { $Parallel = if ($mode -eq 'hopac') { 2 } else { [Math]::Max(1, [int]([Environment]::ProcessorCount / 3)) } }
if ($Bless -and $mode -ne 'single-flight') { throw '-Bless records the oracle baseline and is only valid in single-flight mode' }

$dotnet = Resolve-SpiralDotnet
$cache = Get-SpiralCacheDir
$compiler = Get-SpiralCompilerDll $mode $Configuration
if (-not (Test-Path $compiler)) { throw "compiler not built: $compiler`nrun: pwsh scripts/build.ps1 -Mode $mode -Configuration $Configuration" }
$stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
$runDir = Join-Path $cache "runs/$mode-$stamp"
$nativeRoot = Join-Path $cache "native/$mode"
# The compiler's working directory: the Hopac core creates target/ folders relative to it.
$scratch = Join-Path $cache "scratch/$mode"
New-Item -ItemType Directory -Force $runDir, $nativeRoot, $scratch | Out-Null

# Outputs are written in place, so only one run at a time.
$lockPath = Join-Path $cache 'test.lock'
try { $lock = [IO.File]::Open($lockPath, 'OpenOrCreate', 'ReadWrite', 'None') }
catch { throw "another scripts/test.ps1 run is compiling the samples in place ($lockPath)" }
$env:SPIRAL_WORKSPACE_ROOT = if ($WorkspaceRoot) { (Resolve-Path $WorkspaceRoot).Path } else { $BundleRoot }
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir   # where `|core-` resolves
$runStart = [DateTime]::UtcNow

# ------------------------------------------------------------------ discovery
$extension = @{ Fsharp = 'fsx'; C = 'c'; Rust = 'rs'; Delphi = 'pas' }
function Get-Rel([string]$path) { [IO.Path]::GetRelativePath($BundleRoot, $path).Replace('\', '/') }

function New-Sample([string]$suite, [string]$sourcePath, [string[]]$backends) {
    [pscustomobject]@{ Suite = $suite; Id = (Get-Rel (Split-Path $sourcePath)); Input = $sourcePath; Backends = $backends }
}

# The entry of a sample directory: main.spi, or main.spir for bottom-up fixtures.
function Get-Entry([string]$dir) {
    foreach ($name in 'main.spi', 'main.spir') {
        $path = Join-Path $dir $name
        if (Test-Path $path) { return $path }
    }
    $null
}

# Contract cases and megaproject sub-packages are type-system checks compiled to F# only.
function Test-ContractSample([string]$relative) { $relative -like 'samples/contract_*' -or $relative -like 'samples/mega_*' }

# harness.psd1 lists the samples compiled to fewer than all four backends.
$sampleBackends = @{}
foreach ($set in $harness.Backends.Keys) { foreach ($sample in $harness.Backends[$set]) { $sampleBackends[$sample] = @($set -split ',') } }
function Get-ExampleBackends([string]$dir) {
    $relative = 'samples/' + (Split-Path $dir -Leaf)
    if ($sampleBackends.ContainsKey($relative)) { $sampleBackends[$relative] } else { @('Fsharp', 'C', 'Rust', 'Delphi') }
}

function Get-Samples([string]$suite) {
    switch ($suite) {
        'frontier' {
            Get-ChildItem (Join-Path $BundleRoot 'samples') -Directory -Filter 'frontier_*' | ForEach-Object {
                New-Sample 'frontier' (Get-Entry $_.FullName) @('Fsharp', 'C', 'Rust', 'Delphi') }
        }
        'smoke' {
            $harness.Smoke | ForEach-Object {
                $dir = Join-Path $BundleRoot $_.Trim()
                $backends = if (Test-ContractSample $_.Trim()) { @('Fsharp') } else { Get-ExampleBackends $dir }
                New-Sample 'smoke' (Get-Entry $dir) $backends }
        }
        'examples' {
            Get-ChildItem (Join-Path $BundleRoot 'samples') -Directory | Where-Object {
                $_.Name -ne 'core' -and -not (Test-ContractSample "samples/$($_.Name)") -and (Get-Entry $_.FullName) } | ForEach-Object {
                New-Sample 'examples' (Get-Entry $_.FullName) (Get-ExampleBackends $_.FullName) }
        }
        'contracts' {
            Get-ChildItem (Join-Path $BundleRoot 'samples') -Directory -Filter 'contract_*' | Where-Object { Get-Entry $_.FullName } | ForEach-Object {
                New-Sample 'contracts' (Get-Entry $_.FullName) @('Fsharp') }
            # Megaproject sub-packages; the megaproject roots themselves are the mega suite.
            Get-ChildItem (Join-Path $BundleRoot 'samples') -Directory -Filter 'mega_*' | ForEach-Object {
                Get-ChildItem $_.FullName -Directory | Where-Object { (Test-Path (Join-Path $_.FullName 'package.spiproj')) -and (Get-Entry $_.FullName) } | ForEach-Object {
                    New-Sample 'contracts' (Get-Entry $_.FullName) @('Fsharp') } }
        }
        'mega' {
            $harness.Mega | ForEach-Object {
                New-Sample 'mega' (Join-Path $BundleRoot $_.Source) @('Fsharp') }
        }
    }
}

$suites = if ($Suite -contains 'all') { 'frontier', 'examples', 'contracts', 'mega' } else { $Suite }
$samples = $suites | ForEach-Object { Get-Samples $_ } | Sort-Object Id -Unique
if ($Filter) { $samples = $samples | Where-Object { $_.Id -match $Filter } }

$jobs = foreach ($sample in $samples) {
    $timeout = if ($TimeoutSec -gt 0) { $TimeoutSec } else { $suiteTimeoutSec[$sample.Suite] }
    foreach ($b in $sample.Backends) {
        if ($Backend -and $Backend -notcontains $b) { continue }
        [pscustomobject]@{ Key = "$($sample.Id)|$b"; Suite = $sample.Suite; Id = $sample.Id; Backend = $b; Input = $sample.Input
            Output = [IO.Path]::ChangeExtension($sample.Input, $extension[$b]); TimeoutSec = $timeout
            Native = Join-Path $nativeRoot "$($sample.Id)/$b" }
    }
}
$jobs = @($jobs)
if ($jobs.Count -eq 0) { throw 'no jobs selected' }
$timeoutText = if ($TimeoutSec -gt 0) { "${TimeoutSec}s" } else { 'per suite' }
Write-Host "== $mode | suites: $($suites -join ',') | $($jobs.Count) jobs | $Parallel worker(s) | timeout $timeoutText | run dir $runDir"

# ------------------------------------------------------------------ compile (warm batch workers)
$workerScript = {
    param($dotnet, $compiler, $jobs, $dir, $index, $fresh, $workDir)
    $results = @{}
    $remaining = @($jobs)
    $attempt = 0
    while ($remaining.Count -gt 0) {
        $attempt++
        $jobsPath = Join-Path $dir "worker$index-$attempt.jobs.tsv"
        $resultsPath = Join-Path $dir "worker$index-$attempt.results.tsv"
        $logPath = Join-Path $dir "worker$index-$attempt.log"
        # -FreshProcess: one compile per process (the Hopac core treats BuildFile as one-shot per process).
        $batch = if ($fresh) { @($remaining[0]) } else { $remaining }
        $batch | ForEach-Object { "$($_.Key)`t$($_.Backend)`t$($_.Input)`t$($_.Output)`t$($_.TimeoutSec * 1000)" } | Set-Content $jobsPath
        $arguments = @($compiler, '--batch', $jobsPath, $resultsPath)
        # Run from the scratch dir: the Hopac core creates target/ folders relative to the current directory.
        $process = Start-Process -FilePath $dotnet -ArgumentList $arguments -NoNewWindow -PassThru -WorkingDirectory $workDir `
            -RedirectStandardOutput "$logPath.out" -RedirectStandardError $logPath
        # Watchdog: the host enforces each job's timeout itself; this only catches a wedged process.
        $deadline = [DateTime]::UtcNow.AddSeconds((($batch | Measure-Object TimeoutSec -Sum).Sum) + 60)
        $killed = $false
        while (-not $process.HasExited) {
            if ([DateTime]::UtcNow -gt $deadline) { Stop-Process -Id $process.Id -Force -ErrorAction SilentlyContinue; $killed = $true; break }
            Start-Sleep -Milliseconds 250
        }
        [void]$process.WaitForExit(10000)
        $exitCode = if ($process.HasExited) { $process.ExitCode } else { -1 }
        if (Test-Path $resultsPath) {
            foreach ($row in Get-Content $resultsPath) {
                $f = $row.Split("`t", 4)
                if ($f.Count -ge 3) { $results[$f[0]] = [pscustomobject]@{ Status = $f[1]; Ms = [int64]$f[2]; Detail = if ($f.Count -ge 4) { $f[3] } else { '' }; Log = $logPath } }
            }
        }
        $rest = @($remaining | Select-Object -Skip $batch.Count)
        $remaining = @($batch)
        $firstMissing = -1
        for ($i = 0; $i -lt $remaining.Count; $i++) { if (-not $results.ContainsKey($remaining[$i].Key)) { $firstMissing = $i; break } }
        $lastTimedOut = $remaining | Where-Object { $results.ContainsKey($_.Key) -and $results[$_.Key].Status -eq 'timeout' } | Select-Object -Last 1
        if ($lastTimedOut) {
            $cut = [Array]::IndexOf(@($remaining.Key), $lastTimedOut.Key)
            $remaining = @($remaining | Select-Object -Skip ($cut + 1)) + $rest
        }
        elseif ($firstMissing -ge 0) {
            $key = $remaining[$firstMissing].Key
            $status = if ($killed) { 'timeout' } else { 'crash' }
            $tail = (Get-Content $logPath -Tail 3 -ErrorAction SilentlyContinue) -join ' | '
            if ($tail.Length -gt 400) { $tail = $tail.Substring($tail.Length - 400) }
            $results[$key] = [pscustomobject]@{ Status = $status; Ms = 0; Detail = "process exit $exitCode; $tail"; Log = $logPath }
            $remaining = @($remaining | Select-Object -Skip ($firstMissing + 1)) + $rest
        }
        else { $remaining = $rest }
    }
    $results
}

# All backends of one sample go to the same worker: the core writes into the sample's directory.
$groups = @{}
$sampleIndex = 0
foreach ($bySample in ($jobs | Group-Object Id)) {
    $g = $sampleIndex++ % $Parallel
    if (-not $groups.ContainsKey($g)) { $groups[$g] = [Collections.Generic.List[object]]::new() }
    foreach ($j in $bySample.Group) { $groups[$g].Add($j) }
}
$sw = [Diagnostics.Stopwatch]::StartNew()
$workerText = $workerScript.ToString()
$compiled = @{}
$workers = $groups.Keys | ForEach-Object { [pscustomobject]@{ Index = $_; Jobs = @($groups[$_]) } }
$partials = $workers | ForEach-Object -ThrottleLimit $Parallel -Parallel {
    $runner = [scriptblock]::Create($using:workerText)
    & $runner $using:dotnet $using:compiler $_.Jobs $using:runDir $_.Index $using:freshProcess $using:scratch
}
foreach ($p in $partials) { foreach ($k in $p.Keys) { $compiled[$k] = $p[$k] } }
Write-Host ("== compiled in {0:N1}s" -f $sw.Elapsed.TotalSeconds)

# "emitted": the job timed out or crashed, but the core had already written its output during this run.
# That is the Hopac lane's typical state (work done, termination protocol never seals), so it is scored
# separately from a plain hang. F# and C only: Rust/Delphi go through a C file the host puts back.
foreach ($job in $jobs) {
    $c = $compiled[$job.Key]
    if (-not $c -or $c.Status -notin 'timeout', 'crash' -or $job.Backend -in 'Rust', 'Delphi') { continue }
    $core = Get-Item -LiteralPath $job.Output -ErrorAction SilentlyContinue
    if (-not $core -or $core.LastWriteTimeUtc -lt $runStart) { continue }
    $c.Status = 'emitted'
    $c.Detail = "output written, compile did not return ($($c.Detail))"
}

# ------------------------------------------------------------------ native tier (C oracle, Rust, Delphi)
$tools = Get-SpiralNativeTools
$shimDir = Join-Path $BundleRoot 'tests/native-shims'
$cFlagRules = @($harness.CFlags | ForEach-Object { [pscustomobject]$_ })
function Get-CFlags($job) {
    $name = Split-Path (Split-Path $job.Input) -Leaf
    $flags = @()
    $rule = $cFlagRules | Where-Object { $name -like $_.Pattern } | Select-Object -First 1
    if ($rule) { $flags += $rule.Flags.Replace('{shims}', $shimDir.Replace('\', '/')) -split ' ' }
    $own = Join-Path (Split-Path $job.Input) 'c-shim.h'
    if (Test-Path $own) { $flags += @('-include', $own) }
    $flags
}
function Invoke-Native([string]$exe, [string[]]$arguments, [string]$workDir, [int]$timeoutSec) {
    $info = [Diagnostics.ProcessStartInfo]::new($exe)
    foreach ($a in $arguments) { $info.ArgumentList.Add($a) }
    $info.WorkingDirectory = $workDir
    $info.RedirectStandardOutput = $true
    $info.RedirectStandardError = $true
    $info.UseShellExecute = $false
    $p = [Diagnostics.Process]::Start($info)
    $out = $p.StandardOutput.ReadToEndAsync()
    $err = $p.StandardError.ReadToEndAsync()
    if (-not $p.WaitForExit($timeoutSec * 1000)) { $p.Kill($true); return [pscustomobject]@{ Exit = 'timeout'; Out = ''; Err = '' } }
    $p.WaitForExit()
    [pscustomobject]@{ Exit = $p.ExitCode; Out = $out.Result; Err = $err.Result }
}
function Build-And-Run($job) {
    $binDir = $job.Native
    $dir = $binDir
    New-Item -ItemType Directory -Force $binDir | Out-Null
    $exe = Join-Path $binDir ($(if ($IsWindows) { 'main.exe' } else { 'main' }))
    $build = switch ($job.Backend) {
        'C' { if (-not $tools.CC) { return 'no-toolchain' }; Invoke-Native $tools.CC (@('-std=c11', '-O2', '-w') + (Get-CFlags $job) + @('-o', $exe, $job.Output, '-lm')) $dir 120 }
        'Rust' { if (-not $tools.Rustc) { return 'no-toolchain' }; Invoke-Native $tools.Rustc @('-C', 'opt-level=2', '-A', 'warnings', '--edition', '2024', '-o', $exe, $job.Output) $dir 180 }
        'Delphi' { if (-not $tools.Fpc) { return 'no-toolchain' }; Invoke-Native $tools.Fpc @('-O2', '-Mdelphi', "-FE$binDir", "-FU$binDir", "-o$exe", $job.Output) $dir 180 }
    }
    if ($build.Exit -ne 0 -or -not (Test-Path $exe)) {
        $msg = (($build.Err + ' ' + $build.Out) -replace '\s+', ' ').Trim()
        return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
    }
    $run = Invoke-Native $exe @() $binDir 30
    $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
    $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
    [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
}

$nativeResults = @{}
if ($Native) {
    $sw.Restart()
    foreach ($job in $jobs | Where-Object { $_.Backend -ne 'Fsharp' -and $compiled[$_.Key] -and $compiled[$_.Key].Status -in 'ok', 'emitted' }) {
        $r = Build-And-Run $job
        if ($r -is [string]) { $r = [pscustomobject]@{ Status = $r; Exit = ''; Stdout = ''; Detail = '' } }
        $nativeResults[$job.Key] = $r
    }
    Write-Host ("== native tier in {0:N1}s" -f $sw.Elapsed.TotalSeconds)
}

# ------------------------------------------------------------------ rows, oracle, baseline
$expectedPath = Get-SpiralBaselinePath
$expected = @{}
if (Test-Path $expectedPath) { Import-Csv $expectedPath -Delimiter "`t" | ForEach-Object { $expected["$($_.id)|$($_.backend)"] = $_ } }

$rows = foreach ($job in $jobs) {
    $c = $compiled[$job.Key]
    if (-not $c) { $c = [pscustomobject]@{ Status = 'not-run'; Ms = 0; Detail = ''; Log = '' } }
    $n = $nativeResults[$job.Key]
    $residual = if ($c.Status -in 'ok', 'emitted') { Get-TextSha256 $job.Output } else { '' }
    [pscustomobject]@{
        id = $job.Id; backend = $job.Backend; suite = $job.Suite; compile = $c.Status; compile_ms = $c.Ms
        residual = if ($residual) { $residual.Substring(0, 16) } else { '' }
        native = if ($n) { $n.Status } else { '' }; exit = if ($n) { $n.Exit } else { '' }; stdout = if ($n) { $n.Stdout } else { '' }
        oracle = ''; baseline = ''; detail = (($c.Detail + ' ' + $(if ($n) { $n.Detail } else { '' })) -replace '\s+', ' ').Trim()
    }
}
$rows = @($rows)

# Rust and Delphi must reproduce the native behaviour of the C residual of the same sample.
$byId = $rows | Group-Object id -AsHashTable
# Negative fixtures fail by design and each runtime reports failure with its own code (C abort, Rust panic
# 101, FPC runtime error 2xx), so "both failed" agrees. Diagnosed issues listed in harness.psd1 Known are
# reported as `known` instead of failing the run.
$known = @{}
$harness.Known | ForEach-Object { $known["$($_.Id)|$($_.Backend)"] = $_.Reason }
foreach ($row in $rows | Where-Object { $_.backend -in 'Rust', 'Delphi' -and $_.native -eq 'ran' }) {
    $c = $byId[$row.id] | Where-Object { $_.backend -eq 'C' -and $_.native -eq 'ran' } | Select-Object -First 1
    $bothFailed = $c -and $c.exit -ne '0' -and $row.exit -ne '0' -and $c.exit -ne 'timeout' -and $row.exit -ne 'timeout'
    $row.oracle =
        if (-not $c) { 'no-c' }
        elseif ($c.exit -eq $row.exit -and $c.stdout -eq $row.stdout) { 'agree' }
        elseif ($bothFailed) { 'agree-fail' }
        else { 'DISAGREE' }
}
foreach ($row in $rows) {
    $reason = $known["$($row.id)|$($row.backend)"]
    if ($reason -and ($row.oracle -eq 'DISAGREE' -or $row.native -eq 'build-fail')) { $row.oracle = 'known'; $row.detail = "known: $reason; $($row.detail)" }
}

# Baseline verdict. single-flight: regression check. hopac: parity with the single-flight oracle.
# An expected rejection is only matched by a rejection (`error`); a hang or crash never counts as one.
foreach ($row in $rows) {
    $e = $expected["$($row.id)|$($row.backend)"]
    if (-not $e) { $row.baseline = 'new'; continue }
    $produced = $row.compile -in 'ok', 'emitted'
    $broken = if ($mode -eq 'hopac') { 'missing' } else { 'REGRESSED' }
    # A missing toolchain on this machine (e.g. no fpc) is not a difference in the program's behaviour.
    $nativeMatch = (-not $Native) -or ($e.native -ne 'ran') -or ($row.native -eq 'no-toolchain') -or ($row.native -eq 'ran' -and $e.exit -eq $row.exit -and $e.stdout -eq $row.stdout)
    $row.baseline =
        if ($e.compile -in 'timeout', 'crash', 'not-run') { if ($produced) { 'FIXED' } else { 'no-oracle' } }
        elseif ($e.compile -eq 'error') {
            if ($row.compile -eq 'error') { 'parity' } elseif ($produced) { 'UNEXPECTED-OUTPUT' } else { $broken } }
        elseif (-not $produced) { $broken }
        elseif (-not $nativeMatch) { 'NATIVE-DIFF' }
        elseif ($e.residual -and $e.residual -ne $row.residual) { if ($row.compile -eq 'emitted') { 'emitted-residual-differs' } else { 'parity-residual-differs' } }
        elseif ($row.compile -eq 'emitted') { 'emitted-parity' }
        else { 'parity' }
}

$resultPath = Join-Path $runDir 'results.tsv'
$rows | Export-Csv $resultPath -Delimiter "`t" -NoTypeInformation -UseQuotes Never
Copy-Item $resultPath (Join-Path $cache "results/latest-$mode.tsv") -Force -ErrorAction SilentlyContinue

# ------------------------------------------------------------------ summary
function Count($set, $pred) {
    # A filtered suite can reject every fixture before any native run. PowerShell
    # assigns $null to that empty pipeline; do not evaluate a property on $null.
    if ($null -eq $set) { return 0 }
    @($set | Where-Object $pred).Count
}
Write-Host ''
Write-Host ('{0,-10} {1,6} {2,6} {3,8} {4,6} {5,8} {6,6}  {7}' -f 'suite', 'jobs', 'ok', 'emitted', 'error', 'timeout', 'crash', 'baseline (parity/emitted-parity/fixed/missing|regressed/new)')
foreach ($s in ($rows | Group-Object suite)) {
    $g = $s.Group
    $parity = Count $g { $_.baseline -like 'parity*' }
    $emittedParity = Count $g { $_.baseline -like 'emitted-*' }
    $broken = Count $g { $_.baseline -in 'missing', 'REGRESSED', 'NATIVE-DIFF', 'UNEXPECTED-OUTPUT' }
    Write-Host ('{0,-10} {1,6} {2,6} {3,8} {4,6} {5,8} {6,6}  {7}/{8}/{9}/{10}/{11}' -f $s.Name, $g.Count, (Count $g { $_.compile -eq 'ok' }), (Count $g { $_.compile -eq 'emitted' }),
        (Count $g { $_.compile -eq 'error' }), (Count $g { $_.compile -eq 'timeout' }), (Count $g { $_.compile -eq 'crash' }),
        $parity, $emittedParity, (Count $g { $_.baseline -eq 'FIXED' }), $broken, (Count $g { $_.baseline -eq 'new' }))
}
if ($Native) {
    $nat = $rows | Where-Object native
    Write-Host ("native: {0} ran, {1} build-fail, oracle agree {2}, DISAGREE {3}" -f (Count $nat { $_.native -eq 'ran' }), (Count $nat { $_.native -eq 'build-fail' }),
        (Count $rows { $_.oracle -eq 'agree' }), (Count $rows { $_.oracle -eq 'DISAGREE' }))
}
$bad = @($rows | Where-Object { $_.baseline -in 'REGRESSED', 'NATIVE-DIFF' -or ($mode -ne 'hopac' -and $_.baseline -eq 'UNEXPECTED-OUTPUT') -or $_.oracle -eq 'DISAGREE' })
foreach ($b in $bad | Select-Object -First 20) { Write-Host "  !! $($b.id) [$($b.backend)] $($b.baseline) $($b.oracle) $($b.detail)" -ForegroundColor Red }
Write-Host "results: $resultPath"
Write-Host "outputs: written next to their sources; git diff samples shows what changed"

# ------------------------------------------------------------------ bless / record
if ($Bless) {
    $existing = if (Test-Path $expectedPath) { @(Import-Csv $expectedPath -Delimiter "`t") } else { @() }
    $fresh = @{}
    foreach ($row in $rows) { $fresh["$($row.id)|$($row.backend)"] = $row }
    $merged = @($existing | Where-Object { -not $fresh.ContainsKey("$($_.id)|$($_.backend)") }) + @($rows | ForEach-Object {
        [pscustomobject]@{ id = $_.id; backend = $_.backend; compile = $_.compile; residual = $_.residual; native = $_.native; exit = $_.exit; stdout = $_.stdout } })
    New-Item -ItemType Directory -Force (Split-Path $expectedPath) | Out-Null
    $merged | Sort-Object id, backend | Export-Csv $expectedPath -Delimiter "`t" -NoTypeInformation -UseQuotes Never
    Write-Host "blessed $($rows.Count) rows into $expectedPath"
}
if ($Record) {
    $board = Get-SpiralScoreboardPath $mode
    New-Item -ItemType Directory -Force (Split-Path $board) | Out-Null
    $rows | Select-Object id, backend, suite, compile, native, oracle, baseline | Sort-Object id, backend |
        Export-Csv $board -Delimiter "`t" -NoTypeInformation -UseQuotes Never
    Write-Host "recorded $board"
}
if ($bad.Count -gt 0) { exit 1 }
