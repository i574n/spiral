param(
    [ValidateSet('single-flight', 'sf', 'hopac', 'hp')][string]$Mode = 'single-flight',
    [string[]]$Suite = @('smoke'),
    [string]$Filter,
    [string[]]$Backend,
    [int]$TimeoutSec = 0,
    [int]$Parallel = 0,
    [switch]$Native,
    [switch]$Bless,
    [switch]$Record,
    [switch]$FreshProcess,
    [switch]$WarmRecycle,
    [ValidateSet('Release', 'Debug')][string]$Configuration = 'Release',
    [string]$WorkspaceRoot,
    [ValidateSet('Zig', 'Lean', 'Bend', 'Gleam', 'Lua', 'TypeScript', 'Python', 'Rust', 'Delphi', 'Cpp')][string]$Probe
)
. $PSScriptRoot/env.ps1
$harness = Import-PowerShellDataFile (Join-Path $BundleRoot 'tests/harness.psd1')
$Suite = @($Suite | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
$Backend = @($Backend | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
foreach ($s in $Suite) { if ($s -notin 'frontier', 'smoke', 'examples', 'contracts', 'mega', 'all') { throw "unknown suite '$s'" } }
foreach ($b in $Backend) { if ($b -notin 'Fsharp', 'C', 'Rust', 'Delphi', 'Zig', 'Lean', 'Bend', 'Gleam', 'Lua', 'TypeScript', 'Cpp', 'Python') { throw "unknown backend '$b'" } }
$mode = ConvertTo-SpiralMode $Mode
$suiteTimeoutSec = @{ frontier = 20; smoke = 20; examples = 20; contracts = 30; mega = 180 }
$freshProcess = if ($WarmRecycle) { $false } elseif ($PSBoundParameters.ContainsKey('FreshProcess')) { [bool]$FreshProcess } else { $mode -eq 'hopac' }
if ($WarmRecycle) { $env:SPIRAL_BATCH_RECYCLE_AFTER_ERROR = '1' }
if ($Parallel -le 0) {
    $cpus = [Environment]::ProcessorCount
    $byCpu = if ($mode -eq 'hopac') { [Math]::Ceiling($cpus * 3 / 8) } else { [Math]::Ceiling($cpus / 2) }
    $freeGb = try { (Get-CimInstance Win32_OperatingSystem -ErrorAction Stop).FreePhysicalMemory / 1MB } catch { 3 }
    $Parallel = [int][Math]::Max(1, [Math]::Min($byCpu, [Math]::Floor($freeGb / 1.5)))
}
if ($Bless -and $Probe) { throw '-Probe runs are never blessed: they only measure a backend against the C rows' }
if ($Bless -and $mode -ne 'single-flight') { throw '-Bless records the oracle baseline and is only valid in single-flight mode' }

$dotnet = Resolve-SpiralDotnet
$cache = Get-SpiralCacheDir
$compiler = Get-SpiralCompilerDll $mode $Configuration
if (-not (Test-Path $compiler)) { throw "compiler not built: $compiler`nrun: pwsh scripts/build.ps1 -Mode $mode -Configuration $Configuration" }
$stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
$runDir = Join-Path $cache "runs/$mode-$stamp"
$nativeRoot = Join-Path $cache "native/$mode"
$scratch = Join-Path $cache "scratch/$mode"
New-Item -ItemType Directory -Force $runDir, $nativeRoot, $scratch | Out-Null

$lockName = 'Global\spiral-test-run-' + [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($cache.ToLowerInvariant()))).Substring(0, 16)
$lock = [Threading.Mutex]::new($false, $lockName)
$lockHeld = $false
try { $lockHeld = $lock.WaitOne(0) } catch [Threading.AbandonedMutexException] { $lockHeld = $true }
if (-not $lockHeld) { throw "another scripts/test.ps1 run is compiling the samples in place (mutex $lockName)" }
$staleLogs = (Get-Date).AddHours(-12)
Get-ChildItem (Join-Path $cache 'core-src') -Filter '*.jsonl' -Recurse -File -ErrorAction SilentlyContinue |
    Where-Object { $_.LastWriteTime -lt $staleLogs } | Remove-Item -Force -ErrorAction SilentlyContinue
$env:SPIRAL_WORKSPACE_ROOT = if ($WorkspaceRoot) { (Resolve-Path $WorkspaceRoot).Path } else { $BundleRoot }
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
if (-not $env:SPIRAL_DIAG_QUIET) { $env:SPIRAL_DIAG_QUIET = '1' }
if (-not $env:DOTNET_GCgen0size) { $env:DOTNET_GCgen0size = '0x10000000' }
$runStart = [DateTime]::UtcNow

$extension = @{ Fsharp = 'fsx'; C = 'c'; Rust = 'rs'; Delphi = 'pas'; Zig = 'zig'; Lean = 'lean'; Bend = 'bend'; Gleam = 'gleam'; Lua = 'lua'; TypeScript = 'ts'; Cpp = 'cpp'; Python = 'py' }
$coreBackend = @{ Cpp = 'Cpp + Cuda'; Python = 'Python + Cuda' }
function Get-Rel([string]$path) { [IO.Path]::GetRelativePath($BundleRoot, $path).Replace('\', '/') }

function New-Sample([string]$suite, [string]$sourcePath, [string[]]$backends) {
    $id = Get-Rel (Split-Path $sourcePath)
    if ($harness.AlsoTypeScript -and $id -in $harness.AlsoTypeScript -and $backends -notcontains 'TypeScript') { $backends = @($backends) + 'TypeScript' }
    [pscustomobject]@{ Suite = $suite; Id = $id; Input = $sourcePath; Backends = $backends }
}

function Get-Entry([string]$dir) {
    foreach ($name in 'main.spi', 'main.spir') {
        $path = Join-Path $dir $name
        if (Test-Path $path) { return $path }
    }
    $null
}

function Test-ContractSample([string]$relative) { $relative -like 'samples/contract_*' -or $relative -like 'samples/mega_*' }

$sampleBackends = @{}
foreach ($set in $harness.Backends.Keys) { foreach ($sample in $harness.Backends[$set]) { $sampleBackends[$sample] = @($set -split ',') } }
$listedSamples = @{}
foreach ($listed in 'Zig', 'Lean', 'Bend', 'Gleam', 'Lua') { $listedSamples[$listed] = @{}; foreach ($sample in @($harness[$listed])) { if ($sample) { $listedSamples[$listed][$sample] = $true } } }
function Add-ListedBackends([string]$relative, [string[]]$backends) {
    $result = @($backends)
    foreach ($listed in 'Zig', 'Lean', 'Bend', 'Gleam', 'Lua') { if ($listedSamples[$listed].ContainsKey($relative) -and $result -notcontains $listed) { $result += $listed } }
    if ($Probe -and $result -contains 'C' -and $result -notcontains $Probe) { $result += $Probe }
    $result
}
function Get-ExampleBackends([string]$dir) {
    $relative = 'samples/' + (Split-Path $dir -Leaf)
    $backends = if ($sampleBackends.ContainsKey($relative)) { $sampleBackends[$relative] } else { @('Fsharp', 'C', 'Rust', 'Delphi') }
    Add-ListedBackends $relative $backends
}

function Get-Samples([string]$suite) {
    switch ($suite) {
        'frontier' {
            Get-ChildItem (Join-Path $BundleRoot 'samples') -Directory -Filter 'frontier_*' | ForEach-Object {
                New-Sample 'frontier' (Get-Entry $_.FullName) (Add-ListedBackends "samples/$($_.Name)" @('Fsharp', 'C', 'Rust', 'Delphi')) }
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
            Get-ChildItem (Join-Path $BundleRoot 'samples') -Directory -Filter 'mega_*' | ForEach-Object {
                Get-ChildItem $_.FullName -Directory | Where-Object { (Test-Path (Join-Path $_.FullName 'package.spiproj')) -and (Get-Entry $_.FullName) } | ForEach-Object {
                    $relative = Get-Rel $_.FullName
                    $backends = if ($sampleBackends.ContainsKey($relative)) { $sampleBackends[$relative] } else { @('Fsharp') }
                    New-Sample 'contracts' (Get-Entry $_.FullName) (Add-ListedBackends $relative $backends) } }
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
    $timeout = if ($TimeoutSec -gt 0) { $TimeoutSec } elseif ($harness.Timeouts -and $harness.Timeouts.ContainsKey($sample.Id)) { $harness.Timeouts[$sample.Id] } else { $suiteTimeoutSec[$sample.Suite] }
    foreach ($b in $sample.Backends) {
        if ($Backend -and $Backend -notcontains $b) { continue }
        [pscustomobject]@{ Key = "$($sample.Id)|$b"; Suite = $sample.Suite; Id = $sample.Id; Backend = $b; Input = $sample.Input
            CoreBackend = $(if ($coreBackend.ContainsKey($b)) { $coreBackend[$b] } else { $b })
            Output = $(if ($b -eq $Probe) { Join-Path $scratch "probe/$($sample.Id)/main.$($extension[$b])" } else { [IO.Path]::ChangeExtension($sample.Input, $extension[$b]) }); TimeoutSec = $timeout
            Native = Join-Path $nativeRoot "$($sample.Id)/$b" }
    }
}
if ($Probe) { $jobs | Where-Object Backend -eq $Probe | ForEach-Object { New-Item -ItemType Directory -Force (Split-Path $_.Output) | Out-Null } }
$jobs = @($jobs)
if ($jobs.Count -eq 0) { throw 'no jobs selected' }
$timeoutText = if ($TimeoutSec -gt 0) { "${TimeoutSec}s" } else { 'per suite' }
Write-Host "== $mode | suites: $($suites -join ',') | $($jobs.Count) jobs | $Parallel worker(s) | timeout $timeoutText | run dir $runDir"

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
        $batch = if ($fresh) { @($remaining[0]) } else { $remaining }
        $batch | ForEach-Object { "$($_.Key)`t$($_.CoreBackend)`t$($_.Input)`t$($_.Output)`t$($_.TimeoutSec * 1000)" } | Set-Content $jobsPath
        $arguments = @($compiler, '--batch', $jobsPath, $resultsPath)
        $process = Start-Process -FilePath $dotnet -ArgumentList $arguments -NoNewWindow -PassThru -WorkingDirectory $workDir `
            -RedirectStandardOutput "$logPath.out" -RedirectStandardError $logPath
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
        elseif ($exitCode -eq 4 -and $firstMissing -ge 0) {
            $remaining = @($remaining | Select-Object -Skip $firstMissing) + $rest
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
foreach ($k in @($compiled.Keys)) {
    $c = $compiled[$k]
    if ($c.Status -eq 'error' -and $c.Detail -match '^FatalError: BuildFile stalled') { $c.Status = 'timeout' }
}
Write-Host ("== compiled in {0:N1}s" -f $sw.Elapsed.TotalSeconds)

foreach ($job in $jobs) {
    $c = $compiled[$job.Key]
    if (-not $c -or $c.Status -notin 'timeout', 'crash' -or $job.Backend -in 'Rust', 'Delphi', 'Zig', 'Lean', 'Bend', 'Gleam', 'Lua', 'TypeScript', 'Cpp', 'Python') { continue }
    $core = Get-Item -LiteralPath $job.Output -ErrorAction SilentlyContinue
    if (-not $core -or $core.LastWriteTimeUtc -lt $runStart) { continue }
    $c.Status = 'emitted'
    $c.Detail = "output written, compile did not return ($($c.Detail))"
}

$tools = Get-SpiralNativeTools
$zigExe = $tools.Zig
if ($zigExe -and $zigExe -match '[\\/]scoop[\\/]shims[\\/]') {
    $shim = [IO.Path]::ChangeExtension($zigExe, '.shim')
    if (Test-Path $shim) { $real = (Get-Content $shim | Where-Object { $_ -match '^\s*path\s*=' } | Select-Object -First 1) -replace '^\s*path\s*=\s*"?([^"]+)"?\s*$', '$1'; if ($real -and (Test-Path $real)) { $zigExe = $real } }
}
$zigCacheGen = 0
$zigCache = Join-Path $scratch "zig-cache-$stamp-0"
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
    $info.RedirectStandardInput = $true
    $info.RedirectStandardOutput = $true
    $info.RedirectStandardError = $true
    $info.UseShellExecute = $false
    $p = [Diagnostics.Process]::Start($info)
    $p.StandardInput.Close()
    $out = $p.StandardOutput.ReadToEndAsync()
    $err = $p.StandardError.ReadToEndAsync()
    if (-not $p.WaitForExit($timeoutSec * 1000)) { try { $p.Kill($true) } catch { }; return [pscustomobject]@{ Exit = 'timeout'; Out = ''; Err = '' } }
    if (-not [Threading.Tasks.Task]::WaitAll([Threading.Tasks.Task[]]@($out, $err), 15000)) {
        return [pscustomobject]@{ Exit = 'hung-output'; Out = ''; Err = 'stdout/stderr still open 15 s after exit (a child process holds them)' }
    }
    [pscustomobject]@{ Exit = $p.ExitCode; Out = $out.Result; Err = $err.Result }
}
function Build-And-Run($job) {
    $binDir = $job.Native
    $dir = $binDir
    New-Item -ItemType Directory -Force $binDir | Out-Null
    if ($job.Backend -eq 'TypeScript') {
        if (-not $tools.Bun) { return 'no-toolchain' }
        $run = Invoke-Native $tools.Bun @((Join-Path $shimDir 'run_main.mjs'), $job.Output) $binDir 30
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Lean') {
        if (-not $tools.Lean) { return 'no-toolchain' }
        $elanBin = Split-Path $tools.Lean
        if (-not $env:ELAN_HOME -and (Split-Path $elanBin -Leaf) -eq 'bin' -and (Test-Path (Join-Path $elanBin 'elan*'))) { $env:ELAN_HOME = Split-Path $elanBin }
        $run = Invoke-Native $tools.Lean @('--run', $job.Output) $binDir 180
        if ("$($run.Exit)" -ne '0' -and ($run.Out + $run.Err) -match '\.lean:\d+:\d+: error') {
            $msg = ((($run.Out + "`n" + $run.Err) -split "`n" | Where-Object { $_ -match 'error' } | Select-Object -First 1) -replace '\s+', ' ').Trim()
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Bend') {
        if (-not $tools.Bun -or -not $tools.BendMain) { return 'no-toolchain' }
        $env:BEND_NO_TELEMETRY = '1'
        $run = Invoke-Native $tools.Bun @($tools.BendMain, $job.Output) (Split-Path $tools.BendMain) 120
        if (($run.Out + "`n" + $run.Err) -match '(?m)^Error:\s*$') {
            $msg = ((($run.Out + "`n" + $run.Err) -split "`n" | Where-Object { $_.Trim() } | Select-Object -First 4) -join ' / ') -replace '\s+', ' '
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Lua') {
        if (-not $tools.Lua) { return 'no-toolchain' }
        $run = Invoke-Native $tools.Lua @((Join-Path $shimDir 'run_main.lua'), $job.Output) $binDir 60
        if ($run.Err -match 'SPIRAL-LUA-LOAD-ERROR (.*)') { return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $Matches[1].Substring(0, [Math]::Min(300, $Matches[1].Length)) } }
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Gleam') {
        if (-not $tools.Gleam -or -not $tools.Erl) { return 'no-toolchain' }
        $erlBin = Split-Path $tools.Erl
        if (-not (($env:PATH -split [IO.Path]::PathSeparator) -contains $erlBin)) { $env:PATH = "$erlBin$([IO.Path]::PathSeparator)$env:PATH" }
        $project = Join-Path $scratch 'gleam-native'
        if (-not (Test-Path (Join-Path $project 'gleam.toml'))) { Copy-Item (Join-Path $shimDir 'gleam') $project -Recurse -Force }
        $programFile = Join-Path $project 'src/main.gleam'
        Copy-Item $job.Output $programFile -Force
        (Get-Item $programFile).LastWriteTime = Get-Date
        $build = Invoke-Native $tools.Gleam @('build', '--no-print-progress') $project 180
        if ("$($build.Exit)" -ne '0') {
            $msg = if (($build.Out + "`n" + $build.Err) -match '(?m)^error: (.*)') { $Matches[1] } else { "gleam build exit $($build.Exit)" }
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $run = Invoke-Native $tools.Gleam @('run', '--no-print-progress', '-m', 'spiral_run') $project 180
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Python') {
        if (-not $tools.Python) { return 'no-toolchain' }
        $env:PYTHONDONTWRITEBYTECODE = '1'
        $env:SPIRAL_CUDA = '0'
        $run = Invoke-Native $tools.Python @((Join-Path $shimDir 'run_main.py'), $job.Output) $binDir 30
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    $exe = Join-Path $binDir ($(if ($IsWindows) { 'main.exe' } else { 'main' }))
    $build = switch ($job.Backend) {
        'C' { if (-not $tools.CC) { return 'no-toolchain' }; Invoke-Native $tools.CC (@('-std=c11', '-O2', '-w') + (Get-CFlags $job) + @('-o', $exe, $job.Output, '-lm')) $dir 120 }
        'Rust' { if (-not $tools.Rustc) { return 'no-toolchain' }; Invoke-Native $tools.Rustc @('-C', 'opt-level=2', '-A', 'warnings', '--edition', '2024', '-o', $exe, $job.Output) $dir 180 }
        'Delphi' { if (-not $tools.Fpc) { return 'no-toolchain' }; Invoke-Native $tools.Fpc @('-O2', '-Mdelphi', "-FE$binDir", "-FU$binDir", "-o$exe", $job.Output) $dir 180 }
        'Zig' {
            if (-not $zigExe) { return 'no-toolchain' }
            $b = Invoke-Native $zigExe @('build-exe', $job.Output, '-O', 'ReleaseFast', '--stack', '1073741824', '-fno-emit-implib', "-femit-bin=$exe", '--cache-dir', "$zigCache-local", '--global-cache-dir', $zigCache) $dir 120
            if ($b.Exit -eq 'timeout') { $script:zigCacheGen++; $script:zigCache = Join-Path $scratch "zig-cache-$stamp-$($script:zigCacheGen)" }
            $b
        }
        'Cpp' {
            if (-not $tools.Python) { return 'no-toolchain' }
            $b = Invoke-Native $tools.Python @((Join-Path $shimDir 'cpp_native.py'), $job.Output, $exe) $dir 180
            if ("$($b.Exit)" -eq '3') { return 'no-toolchain' }
            $b
        }
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
    $nativeJobs = @($jobs | Where-Object { $_.Backend -ne 'Fsharp' -and $compiled[$_.Key] -and $compiled[$_.Key].Status -in 'ok', 'emitted' })
    $done = 0
    foreach ($job in $nativeJobs) {
        $jobWatch = [Diagnostics.Stopwatch]::StartNew()
        $r = Build-And-Run $job
        if ($r -is [string]) { $r = [pscustomobject]@{ Status = $r; Exit = ''; Stdout = ''; Detail = '' } }
        $nativeResults[$job.Key] = $r
        $done++
        Write-Host ("native {0}/{1} {2} {3}: {4} exit {5} ({6:N1}s)" -f $done, $nativeJobs.Count, $job.Id, $job.Backend, $r.Status, $r.Exit, $jobWatch.Elapsed.TotalSeconds)
    }
    Get-ChildItem $scratch -Directory -Filter "zig-cache-$stamp-*" -ErrorAction SilentlyContinue | ForEach-Object { try { [IO.Directory]::Delete($_.FullName, $true) } catch { } }
    Write-Host ("== native tier in {0:N1}s" -f $sw.Elapsed.TotalSeconds)
}

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

$byId = $rows | Group-Object id -AsHashTable
$known = @{}
$harness.Known | ForEach-Object { $known["$($_.Id)|$($_.Backend)"] = $_.Reason }
foreach ($row in $rows | Where-Object { $_.backend -in 'Rust', 'Delphi', 'Zig', 'Lean', 'Bend', 'Gleam', 'Lua', 'TypeScript', 'Cpp', 'Python' -and $_.native -eq 'ran' }) {
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
}$jobOutput = @{}
foreach ($job in $jobs) { $jobOutput[$job.Key] = $job.Output }
$cOnlyHelper = 'DynamicArray(Reserve|Resize|Capacity)\d|spiral_abi_lib|\(\(uint8_t\)'
foreach ($row in $rows | Where-Object { $_.backend -ne 'C' -and ($_.oracle -eq 'DISAGREE' -or $_.native -eq 'build-fail') }) {
    $output = $jobOutput["$($row.id)|$($row.backend)"]
    if ($output -and (Test-Path $output) -and (Select-String -LiteralPath $output -Pattern $cOnlyHelper -Quiet)) { $row.oracle = 'c-only'; $row.detail = "c-only: the sample uses a C-only helper; $($row.detail)" }
}

foreach ($row in $rows) {
    $e = $expected["$($row.id)|$($row.backend)"]
    if (-not $e) { $row.baseline = 'new'; continue }
    $produced = $row.compile -in 'ok', 'emitted'
    $broken = if ($mode -eq 'hopac') { 'missing' } else { 'REGRESSED' }
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

function Count($set, $pred) {
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
if ($Probe) { Write-Host "probe outputs ($Probe): $(Join-Path $scratch 'probe')" }

if ($Bless) {
    $existing = if (Test-Path $expectedPath) { @(Import-Csv $expectedPath -Delimiter "`t") } else { @() }
    $blessable = @($rows | Where-Object { $_.compile -ne 'timeout' })
    $skipped = $rows.Count - $blessable.Count
    if ($skipped) { Write-Host "not blessed: $skipped timeout row(s), they keep their previous oracle entry" -ForegroundColor Yellow }
    $fresh = @{}
    foreach ($row in $blessable) { $fresh["$($row.id)|$($row.backend)"] = $row }
    $merged = @($existing | Where-Object { -not $fresh.ContainsKey("$($_.id)|$($_.backend)") }) + @($blessable | ForEach-Object {
        [pscustomobject]@{ id = $_.id; backend = $_.backend; compile = $_.compile; residual = $_.residual; native = $_.native; exit = $_.exit; stdout = $_.stdout } })
    New-Item -ItemType Directory -Force (Split-Path $expectedPath) | Out-Null
    $merged | Sort-Object id, backend | Export-Csv $expectedPath -Delimiter "`t" -NoTypeInformation -UseQuotes Never
    Write-Host "blessed $($blessable.Count) rows into $expectedPath"
}
if ($Record) {
    $board = Get-SpiralScoreboardPath $mode
    New-Item -ItemType Directory -Force (Split-Path $board) | Out-Null
    $rows | Select-Object id, backend, suite, compile, native, oracle, baseline | Sort-Object id, backend |
        Export-Csv $board -Delimiter "`t" -NoTypeInformation -UseQuotes Never
    Write-Host "recorded $board"
}
if ($bad.Count -gt 0) { exit 1 }
