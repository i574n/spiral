param(
    [ValidateSet('single-flight', 'sf', 'gpt5parallel', 'gp', 'hopacsota', 'hs')][string]$Mode = 'single-flight',
    [string[]]$Suite = @('smoke'),
    [string]$Filter,
    [string[]]$Backend,
    [int]$TimeoutSec = 0,
    [int]$Parallel = 0,
    [switch]$Native,
    [switch]$Accept,
    [switch]$AcceptToolchain,
    [switch]$Record,
    [switch]$FreshProcess,
    [switch]$WarmRecycle,
    [switch]$ReuseNative,
    [switch]$ReuseCompile,
    [ValidateSet('Release', 'Debug')][string]$Configuration = 'Release',
    [string]$WorkspaceRoot,
    [ValidateSet('Zig', 'Wasm', 'Lean', 'Bend', 'Gleam', 'Lua', 'TypeScript', 'Python', 'Rust', 'Delphi', 'Cpp', 'Kotlin', 'Swift', 'Wgsl', 'Calyx', 'OpenQasm', 'Ebpf')][string]$Probe,
    [string[]]$Oracle = @('Zig', 'C')
)
. $PSScriptRoot/env.ps1
$matrix = Import-PowerShellDataFile (Join-Path $BundleRoot 'tests/matrix.psd1') -SkipLimitCheck
$Suite = @($Suite | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
$Backend = @($Backend | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
foreach ($s in $Suite) { if ($s -notin 'frontier', 'smoke', 'examples', 'contracts', 'mega', 'all', 'fast') { throw "unknown suite '$s'" } }
$fastSuite = $Suite -contains 'fast'
if ($fastSuite -and $Suite.Count -gt 1) { throw "-Suite fast picks its rows from every suite and does not combine with '$($Suite -join ',')'" }
if ($fastSuite -and ($Accept -or $Record)) { throw '-Suite fast runs a subset picked from run history: -Accept and -Record need the full suite' }
foreach ($b in $Backend) { if ($b -notin 'Fsharp', 'C', 'Rust', 'Delphi', 'Zig', 'Wasm', 'Wgsl', 'Calyx', 'Kotlin', 'Swift', 'OpenQasm', 'Ebpf', 'Lean', 'Bend', 'Gleam', 'Lua', 'TypeScript', 'Cpp', 'Python') { throw "unknown backend '$b'" } }
$mode = ConvertTo-SpiralMode $Mode
$suiteTimeoutSec = @{ frontier = 20; smoke = 20; examples = 20; contracts = 30; mega = 180 }
$recycleWarmBatches = $WarmRecycle -or ($mode -eq 'gpt5parallel' -and -not $PSBoundParameters.ContainsKey('FreshProcess'))
$freshProcess = if ($recycleWarmBatches) { $false } else { [bool]$FreshProcess }
if ($recycleWarmBatches) { $env:SPIRAL_BATCH_RECYCLE_AFTER_ERROR = '1' }
if ($Parallel -le 0) {
    $cpus = [Environment]::ProcessorCount
    $byCpu = if ($mode -eq 'gpt5parallel') { [Math]::Ceiling($cpus * 3 / 8) } else { [Math]::Ceiling($cpus / 2) }
    $freeGb = try { (Get-CimInstance Win32_OperatingSystem -ErrorAction Stop).FreePhysicalMemory / 1MB } catch { 3 }
    $Parallel = [int][Math]::Max(1, [Math]::Min($byCpu, [Math]::Floor($freeGb / 1.5)))
}
if ($Accept -and $Probe) { throw '-Probe runs are never accepted: they only measure a backend against the C rows' }
if ($ReuseCompile -and ($Accept -or $Record)) { throw '-ReuseCompile replays stored compile results: -Accept and -Record compile every row' }
if ($ReuseNative -and ($Accept -or $Record)) { throw '-ReuseNative replays stored native outcomes: -Accept and -Record run every native row' }
if ($Accept -and $mode -ne 'single-flight') { throw '-Accept records the oracle baseline and is only valid in single-flight mode' }

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

$extension = @{ Fsharp = 'fsx'; C = 'c'; Rust = 'rs'; Delphi = 'pas'; Zig = 'zig'; Wasm = 'wat'; Wgsl = 'wgsl'; Calyx = 'futil'; Kotlin = 'kt'; Swift = 'swift'; OpenQasm = 'qasm'; Ebpf = 'ebpf'; Lean = 'lean'; Bend = 'bend'; Gleam = 'gleam'; Lua = 'lua'; TypeScript = 'ts'; Cpp = 'cpp'; Python = 'py' }
$coreBackend = @{ Cpp = 'Cpp + Cuda'; Python = 'Python + Cuda' }
function Get-Rel([string]$path) { [IO.Path]::GetRelativePath($BundleRoot, $path).Replace('\', '/') }

function New-Sample([string]$suite, [string]$sourcePath, [string[]]$backends) {
    $id = Get-Rel (Split-Path $sourcePath)
    if ($matrix.AlsoTypeScript -and $id -in $matrix.AlsoTypeScript -and $backends -notcontains 'TypeScript') { $backends = @($backends) + 'TypeScript' }
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
foreach ($set in $matrix.Backends.Keys) { foreach ($sample in $matrix.Backends[$set]) { $sampleBackends[$sample] = @($set -split ',') } }
$listedSamples = @{}
foreach ($listed in 'Zig', 'Wasm', 'Wgsl', 'Calyx', 'Kotlin', 'Swift', 'OpenQasm', 'Ebpf', 'Lean', 'Bend', 'Gleam', 'Lua', 'Python') { $listedSamples[$listed] = @{}; foreach ($sample in @($matrix[$listed])) { if ($sample) { $listedSamples[$listed][$sample] = $true } } }
function Add-ListedBackends([string]$relative, [string[]]$backends) {
    $result = @($backends)
    foreach ($listed in 'Zig', 'Wasm', 'Wgsl', 'Calyx', 'Kotlin', 'Swift', 'OpenQasm', 'Ebpf', 'Lean', 'Bend', 'Gleam', 'Lua', 'Python') { if ($listedSamples[$listed].ContainsKey($relative) -and $result -notcontains $listed) { $result += $listed } }
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
            $matrix.Smoke | ForEach-Object {
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
            $matrix.Mega | ForEach-Object {
                New-Sample 'mega' (Join-Path $BundleRoot $_.Source) @('Fsharp') }
        }
    }
}

$suites = if ($Suite -contains 'all' -or $fastSuite) { 'frontier', 'examples', 'contracts', 'mega' } else { $Suite }
$fastKeys = $null
if ($fastSuite) {
    $fastList = Join-Path $runDir 'fast-tier.tsv'
    & (Join-Path $PSScriptRoot 'fast-tier.ps1') -Mode $mode -ListPath $fastList | Write-Host
    $fastKeys = [Collections.Generic.HashSet[string]]::new()
    $restKeys = [Collections.Generic.HashSet[string]]::new()
    foreach ($row in Import-Csv $fastList -Delimiter "`t") {
        $key = "$($row.id)|$($row.backend)"
        if ($row.tier -eq 'fast') { [void]$fastKeys.Add($key) } else { [void]$restKeys.Add($key) }
    }
}
$samples = $suites | ForEach-Object { Get-Samples $_ } | Sort-Object Id -Unique
if ($Filter) { $samples = $samples | Where-Object { $_.Id -match $Filter } }

$jobs = foreach ($sample in $samples) {
    $timeout = if ($TimeoutSec -gt 0) { $TimeoutSec } elseif ($matrix.Timeouts -and $matrix.Timeouts.ContainsKey($sample.Id)) { $matrix.Timeouts[$sample.Id] } else { $suiteTimeoutSec[$sample.Suite] }
    foreach ($b in $sample.Backends) {
        if ($Backend -and $Backend -notcontains $b) { continue }
        if ($fastSuite -and $restKeys.Contains("$($sample.Id)|$b")) { continue }
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

foreach ($memoStore in @(@('compile-memo', 2), @('native-memo', 14))) {
    $memoStorePath = Join-Path $cache $memoStore[0]
    $memoUnusedBefore = (Get-Date).AddDays(-$memoStore[1])
    if (Test-Path $memoStorePath) { foreach ($entry in [IO.Directory]::EnumerateFiles($memoStorePath)) { if ([IO.File]::GetLastWriteTime($entry) -lt $memoUnusedBefore) { try { [IO.File]::Delete($entry) } catch { } } } }
}
$compiled = @{}
$compileMemoDir = Join-Path $cache 'compile-memo'
$multiFileSuffixes = @{ 'Cpp + Cuda' = @('.corelib.hpp', '.hpp', '.cpp', '.cu'); 'Python + Cuda' = @('_auto.py', '.py') }
function Get-OutputParts([string]$output, [string]$coreBackend) {
    if (-not $coreBackend -or -not $multiFileSuffixes.ContainsKey($coreBackend)) { return @() }
    $stem = Join-Path (Split-Path $output) ([IO.Path]::GetFileNameWithoutExtension($output))
    $main = [IO.Path]::GetFullPath($output)
    @($multiFileSuffixes[$coreBackend] | ForEach-Object { "$stem$_" } | Where-Object { [IO.Path]::GetFullPath($_) -ne $main -and (Test-Path -LiteralPath $_) } | ForEach-Object { Get-Item -LiteralPath $_ } | Sort-Object Name)
}
New-Item -ItemType Directory -Force $compileMemoDir | Out-Null
$compileSignatureLines = [Collections.Generic.List[string]]::new()
foreach ($binary in @(Get-ChildItem (Split-Path $compiler) -Filter '*.dll' -File | Sort-Object Name)) { $compileSignatureLines.Add("$($binary.Name)=$([Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([IO.File]::ReadAllBytes($binary.FullName))))") }
function Get-SpiralSourceFiles([string]$root) {
    $prunedDirectories = [Collections.Generic.HashSet[string]]::new([string[]]@('target', '_build', 'node_modules', '.git'), [StringComparer]::OrdinalIgnoreCase)
    $sourceExtensions = [Collections.Generic.HashSet[string]]::new([string[]]@('.spi', '.spir', '.spiproj'), [StringComparer]::OrdinalIgnoreCase)
    $pending = [Collections.Generic.Stack[string]]::new()
    $pending.Push([IO.Path]::GetFullPath($root))
    $found = [Collections.Generic.List[string]]::new()
    while ($pending.Count -gt 0) {
        $directory = $pending.Pop()
        try {
            foreach ($file in [IO.Directory]::EnumerateFiles($directory)) { if ($sourceExtensions.Contains([IO.Path]::GetExtension($file))) { $found.Add($file) } }
            foreach ($child in [IO.Directory]::EnumerateDirectories($directory)) { if (-not $prunedDirectories.Contains([IO.Path]::GetFileName($child))) { $pending.Push($child) } }
        }
        catch [IO.IOException], [UnauthorizedAccessException] { }
    }
    $found | Sort-Object
}
foreach ($root in @($BundleRoot, (Join-Path $BundleRoot '../../../lib'), $env:SPIRAL_COMPILER_PACKAGE_DIR) | Where-Object { $_ -and (Test-Path $_) }) {
    foreach ($source in Get-SpiralSourceFiles $root) { $compileSignatureLines.Add("$([IO.Path]::GetRelativePath($root, $source))=$([Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([IO.File]::ReadAllBytes($source))))") }
}
Get-ChildItem Env: | Where-Object { $_.Name -like 'SPIRAL_*' -and $_.Name -notin 'SPIRAL_NATIVE_PARALLEL', 'SPIRAL_BIN_CACHE_DIR' -and $_.Name -notlike 'SPIRAL_CELLS_*' } | Sort-Object Name | ForEach-Object { $compileSignatureLines.Add("env $($_.Name)=$($_.Value)") }
$compileSignature = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes(($compileSignatureLines -join "`n") + "`n$mode`n$compiler"))).ToLowerInvariant()
$compileMemoKeys = @{}
$compileReused = 0
$jobsToCompile = @(foreach ($job in $jobs) {
    $memoKey = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes("$compileSignature`n$($job.Key)`n$($job.CoreBackend)`n$($job.Input)`n$($job.Output)`n$($job.TimeoutSec)"))).ToLowerInvariant()
    $compileMemoKeys[$job.Key] = $memoKey
    $memoPath = Join-Path $compileMemoDir "$memoKey.json"
    if ($ReuseCompile -and (Test-Path -LiteralPath $memoPath)) {
        $stored = Get-Content -LiteralPath $memoPath -Raw | ConvertFrom-Json
        $outputPath = Join-Path $compileMemoDir "$memoKey.out"
        if ($stored.Status -eq 'ok') {
            if (-not (Test-Path -LiteralPath $outputPath)) { $job; continue }
            $bytes = [IO.File]::ReadAllBytes($outputPath)
            $current = if (Test-Path -LiteralPath $job.Output) { [IO.File]::ReadAllBytes($job.Output) } else { $null }
            if ($null -eq $current -or -not [Linq.Enumerable]::SequenceEqual([byte[]]$current, [byte[]]$bytes)) { New-Item -ItemType Directory -Force (Split-Path $job.Output) | Out-Null; [IO.File]::WriteAllBytes($job.Output, $bytes) }
            $partsDir = Join-Path $compileMemoDir "$memoKey.parts"
            if (Test-Path -LiteralPath $partsDir) { foreach ($part in Get-ChildItem -LiteralPath $partsDir -File) { [IO.File]::Copy($part.FullName, (Join-Path (Split-Path $job.Output) $part.Name), $true) } }
        }
        foreach ($used in $memoPath, $outputPath) { if (Test-Path -LiteralPath $used) { [IO.File]::SetLastWriteTime($used, (Get-Date)) } }
        $compiled[$job.Key] = [pscustomobject]@{ Status = $stored.Status; Ms = [int64]$stored.Ms; Detail = ("$($stored.Detail) compile-reused").Trim(); Log = '' }
        $compileReused++
        continue
    }
    $job
})
if ($ReuseCompile) { Write-Host ("== compile memo: {0} jobs replayed, {1} to compile" -f $compileReused, $jobsToCompile.Count) }

$groups = @{}
$sampleIndex = 0
foreach ($bySample in ($jobsToCompile | Group-Object Id)) {
    $g = $sampleIndex++ % $Parallel
    if (-not $groups.ContainsKey($g)) { $groups[$g] = [Collections.Generic.List[object]]::new() }
    foreach ($j in $bySample.Group) { $groups[$g].Add($j) }
}
$sw = [Diagnostics.Stopwatch]::StartNew()
$workerText = $workerScript.ToString()
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
foreach ($job in $jobs) {
    $c = $compiled[$job.Key]
    if (-not $c -or $c.Status -ne 'ok') { continue }
    $written = Get-Item -LiteralPath $job.Output -ErrorAction SilentlyContinue
    if (-not $written -or $written.Length -eq 0) {
        $c.Status = 'error'
        $c.Detail = "empty output: the compile reported ok but left $($job.Output) empty or missing"
    }
}
Write-Host ("== compiled in {0:N1}s" -f $sw.Elapsed.TotalSeconds)

foreach ($job in $jobs) {
    $c = $compiled[$job.Key]
    if (-not $c -or $c.Status -notin 'timeout', 'crash' -or $job.Backend -in 'Rust', 'Delphi', 'Zig', 'Wasm', 'Wgsl', 'Calyx', 'Kotlin', 'Swift', 'OpenQasm', 'Ebpf', 'Lean', 'Bend', 'Gleam', 'Lua', 'TypeScript', 'Cpp', 'Python') { continue }
    $core = Get-Item -LiteralPath $job.Output -ErrorAction SilentlyContinue
    if (-not $core -or $core.LastWriteTimeUtc -lt $runStart) { continue }
    $c.Status = 'emitted'
    $c.Detail = "output written, compile did not return ($($c.Detail))"
}
foreach ($job in $jobsToCompile) {
    $c = $compiled[$job.Key]
    if (-not $c -or $c.Status -notin 'ok', 'error') { continue }
    $memoKey = $compileMemoKeys[$job.Key]
    try {
        if ($c.Status -eq 'ok') {
            [IO.File]::Copy($job.Output, (Join-Path $compileMemoDir "$memoKey.out"), $true)
            $partsDir = Join-Path $compileMemoDir "$memoKey.parts"
            if (Test-Path -LiteralPath $partsDir) { Remove-Item -LiteralPath $partsDir -Recurse -Force }
            $parts = Get-OutputParts $job.Output $job.CoreBackend
            if ($parts.Count) { New-Item -ItemType Directory -Force $partsDir | Out-Null; foreach ($part in $parts) { [IO.File]::Copy($part.FullName, (Join-Path $partsDir $part.Name), $true) } }
        }
        [IO.File]::WriteAllText((Join-Path $compileMemoDir "$memoKey.json"), ([ordered]@{ Status = $c.Status; Ms = [int64]$c.Ms; Detail = "$($c.Detail)" } | ConvertTo-Json -Compress))
    } catch { }
}

$tools = Get-SpiralNativeTools
$zigExe = $tools.Zig
if ($zigExe -and $zigExe -match '[\\/]scoop[\\/]shims[\\/]') {
    $shim = [IO.Path]::ChangeExtension($zigExe, '.shim')
    if (Test-Path $shim) { $real = (Get-Content $shim | Where-Object { $_ -match '^\s*path\s*=' } | Select-Object -First 1) -replace '^\s*path\s*=\s*"?([^"]+)"?\s*$', '$1'; if ($real -and (Test-Path $real)) { $zigExe = $real } }
}
$zigCacheGen = 0
$zigCache = Join-Path $scratch 'zig-cache-shared'
$shimDir = Join-Path $BundleRoot 'tests/native-shims'
$cFlagRules = @($matrix.CFlags | ForEach-Object { [pscustomobject]$_ })
function Get-CFlags($job) {
    $name = Split-Path (Split-Path $job.Input) -Leaf
    $flags = @()
    $rule = $cFlagRules | Where-Object { $name -like $_.Pattern } | Select-Object -First 1
    if ($rule) { $flags += $rule.Flags.Replace('{shims}', $shimDir.Replace('\', '/')) -split ' ' }
    $own = Join-Path (Split-Path $job.Input) 'c-shim.h'
    if (Test-Path $own) { $flags += @('-include', $own) }
    $flags
}
function Get-FileSha256([string]$path) { [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([IO.File]::ReadAllBytes($path))).ToLowerInvariant() }
function Get-TextKey([string]$text) { [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($text))).ToLowerInvariant() }
function Get-ToolStamp([string]$path) {
    if (-not $path -or -not (Test-Path -LiteralPath $path)) { return "$path|missing" }
    $real = $path
    $scoopShim = [IO.Path]::ChangeExtension($real, '.shim')
    if ($real -match '[\\/]scoop[\\/]shims[\\/]' -and (Test-Path -LiteralPath $scoopShim)) {
        $target = (Get-Content -LiteralPath $scoopShim | Where-Object { $_ -match '^\s*path\s*=' } | Select-Object -First 1) -replace '^\s*path\s*=\s*"?([^"]+)"?\s*$', '$1'
        if ($target -and (Test-Path -LiteralPath $target)) { $real = $target }
    }
    $parts = @($real -split '[\\/]')
    $current = [Array]::LastIndexOf($parts, 'current')
    if ($current -gt 0) {
        $link = (Get-Item -LiteralPath ($parts[0..$current] -join [IO.Path]::DirectorySeparatorChar)).LinkTarget
        if ($link) { $real = (@($link) + @($parts | Select-Object -Skip ($current + 1))) -join [IO.Path]::DirectorySeparatorChar }
    }
    $item = Get-Item -LiteralPath $real
    $size = if ($item -is [IO.FileInfo]) { $item.Length } else { 'dir' }
    "$real|$size|$($item.LastWriteTimeUtc.Ticks)"
}

$toolchain = @($tools.PSObject.Properties | Sort-Object Name | ForEach-Object { [pscustomobject]@{ tool = $_.Name; stamp = Get-ToolStamp $_.Value } })
$baselineToolchainPath = Join-Path (Split-Path (Get-SpiralBaselinePath)) 'toolchain.tsv'
$toolchainChanges = @()
if ($Native -and (Test-Path -LiteralPath $baselineToolchainPath)) {
    $baselineStamps = @{}
    Import-Csv $baselineToolchainPath -Delimiter "`t" | ForEach-Object { $baselineStamps[$_.tool] = $_.stamp }
    $toolchainChanges = @($toolchain | Where-Object { $baselineStamps.ContainsKey($_.tool) -and $baselineStamps[$_.tool] -ne $_.stamp } | ForEach-Object { "$($_.tool): $($baselineStamps[$_.tool]) -> $($_.stamp)" })
}
if ($toolchainChanges) {
    Write-Host "toolchain differs from the baseline's:" -ForegroundColor Yellow
    $toolchainChanges | ForEach-Object { Write-Host "  $_" -ForegroundColor Yellow }
    if ($Accept -and -not $AcceptToolchain) { throw "-Accept refuses a run whose native toolchain differs from the baseline's: pin the baseline's tools (SPIRAL_CC and the others) or pass -AcceptToolchain to move the baseline to this toolchain" }
}
if ($Native) { $toolchain | Export-Csv (Join-Path $runDir 'toolchain.tsv') -Delimiter "`t" -NoTypeInformation -UseQuotes Never }
function Get-NativeSignature([string]$ScriptPath = $PSCommandPath) {
    $language = [System.Management.Automation.Language.Parser]
    $script = $language::ParseFile($ScriptPath, [ref]$null, [ref]$null)
    $buildAndRun = $script.Find({ param($node) $node -is [System.Management.Automation.Language.FunctionDefinitionAst] -and $node.Name -eq 'Build-And-Run' }, $true)
    $otherNativeCode = $script.FindAll({ param($node)
            ($node -is [System.Management.Automation.Language.FunctionDefinitionAst] -and $node.Name -in 'Invoke-Native', 'Get-CFlags', 'Get-ShimKey') -or
            ($node -is [System.Management.Automation.Language.IfStatementAst] -and $node.Clauses[0].Item1.Extent.Text -eq '$Native' -and $node.Extent.Text.Contains('$nativeJobs')) }, $true) |
        ForEach-Object { $_.Extent.Text }
    $backendPieces = [Collections.Generic.List[object]]::new()
    foreach ($node in $buildAndRun.FindAll({ param($n) $n -is [System.Management.Automation.Language.IfStatementAst] -and $n.Clauses.Count -eq 1 -and $n.Clauses[0].Item1.Extent.Text -match "^\`$job\.Backend -eq '(\w+)'$" }, $true)) {
        $null = $node.Clauses[0].Item1.Extent.Text -match "'(\w+)'"
        $backendPieces.Add([pscustomobject]@{ Backend = $Matches[1]; Start = $node.Extent.StartOffset; End = $node.Extent.EndOffset; Text = $node.Extent.Text })
    }
    foreach ($switch in $buildAndRun.FindAll({ param($n) $n -is [System.Management.Automation.Language.SwitchStatementAst] -and $n.Condition.Extent.Text -eq '$job.Backend' }, $true)) {
        foreach ($clause in $switch.Clauses) {
            $backendPieces.Add([pscustomobject]@{ Backend = $clause.Item1.Extent.Text.Trim("'", '"'); Start = $clause.Item1.Extent.StartOffset; End = $clause.Item2.Extent.EndOffset; Text = $clause.Item1.Extent.Text + ' ' + $clause.Item2.Extent.Text })
        }
    }
    $outermost = [Collections.Generic.List[object]]::new()
    foreach ($piece in @($backendPieces | Sort-Object Start, @{ Expression = 'End'; Descending = $true })) {
        if ($outermost.Count -and $piece.Start -lt $outermost[$outermost.Count - 1].End) { continue }
        $outermost.Add($piece)
    }
    $sharedText = $buildAndRun.Extent.Text
    $functionStart = $buildAndRun.Extent.StartOffset
    foreach ($piece in @($outermost | Sort-Object Start -Descending)) {
        $sharedText = $sharedText.Remove($piece.Start - $functionStart, $piece.End - $piece.Start)
    }
    $commonCode = $sharedText + "`n" + ($otherNativeCode -join "`n")
    $toolNamesIn = { param([string]$text)
        $names = @([regex]::Matches($text, '\$tools\.(\w+)') | ForEach-Object { $_.Groups[1].Value })
        if ($text.Contains('$zigExe')) { $names += 'Zig' }
        $names | Where-Object { $_ -ne 'PSObject' } | Sort-Object -Unique
    }
    $commonTools = @(& $toolNamesIn $commonCode)
    $stampOf = { param([string]$name) if ($name -eq 'Zig') { Get-ToolStamp $zigExe } else { Get-ToolStamp "$($tools.$name)" } }
    $keyFor = { param([string]$ownCode)
        $lines = [Collections.Generic.List[string]]::new()
        $lines.Add('native code=' + (Get-TextKey ($commonCode + "`n" + $ownCode)))
        foreach ($name in @(@($commonTools) + @(& $toolNamesIn $ownCode) | Sort-Object -Unique)) { $lines.Add("$name=" + (& $stampOf $name)) }
        $lines.Add("SPIRAL_CXX=$env:SPIRAL_CXX")
        Get-TextKey ($lines -join "`n")
    }
    $signature = @{}
    foreach ($group in @($outermost | Group-Object Backend)) {
        $signature[$group.Name] = & $keyFor (($group.Group | Sort-Object Start | ForEach-Object Text) -join "`n")
    }
    $signature['*'] = & $keyFor (($outermost | Sort-Object Start | ForEach-Object Text) -join "`n")
    $signature
}
$shimsByBackend = @{
    TypeScript = @('run_main.mjs'); Lua = @('run_main.lua'); Python = @('run_main.py'); Cpp = @('cpp_native.py')
    Gleam = @('gleam'); Kotlin = @('kotlin-server'); OpenQasm = @('openqasm-run'); Wgsl = @('wgsl-run')
    C = @('*.h'); Ebpf = @('*.h')
    Rust = @(); Delphi = @(); Zig = @(); Lean = @(); Bend = @(); Wasm = @(); Swift = @(); Calyx = @()
    Fsharp = @('fsharp-warm')
}
$shimKeys = @{}
function Get-ShimKey([string]$backend) {
    if ($shimKeys.ContainsKey($backend)) { return $shimKeys[$backend] }
    $selectors = if ($shimsByBackend.ContainsKey($backend)) { $shimsByBackend[$backend] } else { @('**') }
    $files = foreach ($selector in $selectors) {
        $path = Join-Path $shimDir $selector
        if ($selector -eq '**') { Get-ChildItem $shimDir -Recurse -File }
        elseif ($selector.Contains('*')) { Get-ChildItem $shimDir -File -Filter $selector }
        elseif (Test-Path -LiteralPath $path -PathType Container) { Get-ChildItem $path -Recurse -File }
        elseif (Test-Path -LiteralPath $path) { Get-Item -LiteralPath $path }
    }
    $lines = @($files | Where-Object FullName -notmatch '[\\/](target|build|node_modules)[\\/]' | Sort-Object FullName -Unique | ForEach-Object {
        "shim $([IO.Path]::GetRelativePath($shimDir, $_.FullName))=" + (Get-FileSha256 $_.FullName)
    })
    $shimKeys[$backend] = Get-TextKey ($lines -join "`n")
    $shimKeys[$backend]
}

function Get-NativeMemoKey($job, [string]$signature) {
    $flags = if ($job.Backend -eq 'C') { (Get-CFlags $job) -join ' ' } else { '' }
    $ownShim = Join-Path (Split-Path $job.Input) 'c-shim.h'
    $ownShimHash = if ($job.Backend -eq 'C' -and (Test-Path -LiteralPath $ownShim)) { Get-FileSha256 $ownShim } else { '' }
    $backendSignature = if ($signature -is [hashtable]) { if ($signature.ContainsKey($job.Backend)) { $signature[$job.Backend] } else { $signature['*'] } } else { $signature }
    $partsKey = (Get-OutputParts $job.Output $job.CoreBackend | ForEach-Object { "$($_.Name)=$(Get-FileSha256 $_.FullName)" }) -join ';'
    Get-TextKey "$backendSignature`n$($job.Backend)`n$(Get-ShimKey $job.Backend)`n$(Get-FileSha256 $job.Output)`n$flags`n$ownShimHash$(if ($partsKey) { "`n$partsKey" })"
}
function Invoke-Native([string]$exe, [string[]]$arguments, [string]$workDir, [int]$timeoutSec, [string]$PathPrefix) {
    $info = [Diagnostics.ProcessStartInfo]::new($exe)
    foreach ($a in $arguments) { $info.ArgumentList.Add($a) }
    $info.WorkingDirectory = $workDir
    $info.RedirectStandardInput = $true
    $info.RedirectStandardOutput = $true
    $info.RedirectStandardError = $true
    $info.UseShellExecute = $false
    if ($PathPrefix) {
        $pathKey = @($info.Environment.Keys) | Where-Object { $_ -eq 'Path' -or $_ -eq 'PATH' } | Select-Object -First 1
        if (-not $pathKey) { $pathKey = 'PATH' }
        $info.Environment[$pathKey] = $PathPrefix + [IO.Path]::PathSeparator + $info.Environment[$pathKey]
    }
    $nativeCallWatch = [Diagnostics.Stopwatch]::StartNew()
    $p = [Diagnostics.Process]::Start($info)
    $p.StandardInput.Close()
    $out = $p.StandardOutput.ReadToEndAsync()
    $err = $p.StandardError.ReadToEndAsync()
    if (-not $p.WaitForExit($timeoutSec * 1000)) { try { $p.Kill($true) } catch { }; return [pscustomobject]@{ Exit = 'timeout'; Out = ''; Err = '' } }
    $p.WaitForExit() | Out-Null
    $global:SpiralLastNativeMs = [int]$nativeCallWatch.Elapsed.TotalMilliseconds
    $code = $p.ExitCode
    if (-not [Threading.Tasks.Task]::WaitAll([Threading.Tasks.Task[]]@($out, $err), 15000)) {
        # The process has exited. A child can keep the redirected pipes open (mingw gcc does this).
        # The exit code is still the result; dropping it turned a finished compile into build-fail.
        return [pscustomobject]@{ Exit = [string]$code; Out = ''; Err = 'stdout/stderr still open 15 s after exit (a child process holds them)' }
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
    if ($job.Backend -eq 'Fsharp') {
        if (-not $tools.Dotnet) { return 'no-toolchain' }
        $script = Join-Path $binDir 'main.fsx'
        [IO.File]::WriteAllText($script, [IO.File]::ReadAllText($job.Output).TrimEnd() + "`n|> fun x -> match box x with :? int32 as code -> exit code | _ -> exit 0`n")
        $run = Invoke-Native $tools.Dotnet @('fsi', '--quiet', '--exec', $script) $binDir 60
        $fsiError = [regex]::Match("$($run.Err)`n$($run.Out)", 'error FS\d+:[^\r\n]{0,240}')
        if ($fsiError.Success) { return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $fsiError.Value } }
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Calyx') {
        if (-not $tools.Cider -or -not $tools.Auxin -or -not $tools.CalyxRoot) { return 'no-toolchain' }
        $dump = Join-Path $binDir 'spiral-calyx.dat'
        $json = Join-Path $binDir 'spiral-calyx.json'
        Remove-Item -LiteralPath $dump, $json -ErrorAction SilentlyContinue
        # cider's interpret path serializes the memory dump to stdout and ignores -o.
        $info = [Diagnostics.ProcessStartInfo]::new($tools.Cider)
        foreach ($a in @('-l', $tools.CalyxRoot, '-q', $job.Output)) { $info.ArgumentList.Add($a) }
        $info.WorkingDirectory = $binDir
        $info.RedirectStandardOutput = $true
        $info.RedirectStandardError = $true
        $info.UseShellExecute = $false
        $proc = [Diagnostics.Process]::Start($info)
        $dumpStream = [IO.File]::Create($dump)
        $copyTask = $proc.StandardOutput.BaseStream.CopyToAsync($dumpStream)
        $errTask = $proc.StandardError.ReadToEndAsync()
        if (-not $proc.WaitForExit(120000)) {
            try { $proc.Kill($true) } catch { }
            $dumpStream.Dispose()
            return [pscustomobject]@{ Status = 'timeout'; Exit = 'timeout'; Stdout = ''; Detail = 'cider timed out' }
        }
        if (-not [Threading.Tasks.Task]::WaitAll([Threading.Tasks.Task[]]@($copyTask, $errTask), 15000)) {
            $dumpStream.Dispose()
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = 'cider stdout still open after exit' }
        }
        $dumpStream.Dispose()
        $cerr = $errTask.Result
        if ("$($proc.ExitCode)" -ne '0') {
            $msg = (($cerr -split "`n" | Where-Object { $_.Trim() } | Select-Object -First 3) -join ' / ') -replace '\s+', ' '
            if (-not $msg) { $msg = "cider exit $($proc.ExitCode)" }
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $conv = Invoke-Native $tools.Auxin @('-f', 'cider', '-t', 'json', '-o', $json, $dump) $binDir 30
        if ("$($conv.Exit)" -ne '0' -or -not (Test-Path -LiteralPath $json)) {
            $msg = ((($conv.Err + "`n" + $conv.Out) -split "`n" | Where-Object { $_.Trim() } | Select-Object -First 3) -join ' / ') -replace '\s+', ' '
            if (-not $msg) { $msg = "auxin exit $($conv.Exit)" }
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $text = [IO.File]::ReadAllText($json)
        $found = [regex]::Match($text, '"spiral_io"[\s\S]{0,800}?"data"\s*:\s*\[(?:\s*\[)*\s*(-?\d+)')
        if (-not $found.Success) {
            $snippet = if ($text.Length -gt 180) { $text.Substring(0, 180) } else { $text }
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = ("no spiral_io in cider dump: " + ($snippet -replace '\s+', ' ')) }
        }
        $raw = [int64]$found.Groups[1].Value
        if ($raw -gt 2147483647L) { $raw -= 4294967296L }
        $stdout = ''
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]([int]$raw); Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Kotlin') {
        if (-not $tools.Java) { return 'no-toolchain' }
        $built = $kotlinBuilds[$job.Output]
        if (-not $built) { return 'no-toolchain' }
        if ($built.Exit -ne 'OK') {
            $msg = ($built.Messages -replace '\s+', ' ').Trim()
            if (-not $msg) { $msg = "kotlinc $($built.Exit)" }
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $classes = Join-Path $job.Native 'classes'
        $run = Invoke-Native $tools.Java @('-cp', "$kotlinStdlib$([IO.Path]::PathSeparator)$classes", 'MainKt') $binDir 60
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Swift') {
        if (-not $tools.Swiftc -or -not $tools.SwiftSdk -or -not $tools.SwiftRuntime) { return 'no-toolchain' }
        if ($swiftBatchExe -and $swiftBatch.ContainsKey($job.Output)) {
            $entry = $swiftBatch[$job.Output]
            $run = Invoke-Native $entry.Exe @($entry.Slot) $binDir 60 $tools.SwiftRuntime
            $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
            $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
            return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
        }
        $exe = Join-Path $binDir ($(if ($IsWindows) { 'main.exe' } else { 'main' }))
        Remove-Item -LiteralPath $exe -ErrorAction SilentlyContinue
        $build = Invoke-Native $tools.Swiftc @('-O', '-sdk', $tools.SwiftSdk, '-o', $exe, $job.Output) $binDir 180
        if ("$($build.Exit)" -ne '0' -or -not (Test-Path -LiteralPath $exe)) {
            $msg = ((($build.Err + "`n" + $build.Out) -split "`n" | Where-Object { $_.Trim() } | Select-Object -First 4) -join ' / ') -replace '\s+', ' '
            if (-not $msg) { $msg = "swiftc exit $($build.Exit)" }
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $run = Invoke-Native $exe @() $binDir 60 $tools.SwiftRuntime
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'OpenQasm') {
        if (-not $tools.Python) { return 'no-toolchain' }
        $shim = Join-Path $shimDir 'openqasm-run/run.py'
        if (-not (Test-Path -LiteralPath $shim)) { return 'no-toolchain' }
        $run = Invoke-Native $tools.Python @($shim, $job.Output) $binDir 60
        if ($run.Err -match 'qasm error:') {
            $msg = (($run.Err -split "`n" | Where-Object { $_.Trim() } | Select-Object -First 3) -join ' / ') -replace '\s+', ' '
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Wgsl') {
        if (-not $tools.WgslRun) { return 'no-toolchain' }
        $run = Invoke-Native $tools.WgslRun @($job.Output) $binDir 60
        if ("$($run.Exit)" -eq '3') { return 'no-toolchain' }
        if ($run.Err -match 'wgsl error:') {
            $msg = (($run.Err -split "`n" | Where-Object { $_.Trim() } | Select-Object -First 3) -join ' / ') -replace '\s+', ' '
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Wasm') {
        if (-not $tools.Wasmtime) { return 'no-toolchain' }
        $run = Invoke-Native $tools.Wasmtime @('run', '-W', 'max-wasm-stack=1073741824', $job.Output) $binDir 60
        $wasiStart = '(call $proc_exit (call $spiralMain))'
        if ("$($run.Exit)" -eq '1' -and $run.Err -match 'exit with invalid exit status outside of \[0\.\.126\)') {
            $module = [IO.File]::ReadAllText($job.Output)
            if ($module.Contains($wasiStart)) {
                $splitRuns = @(foreach ($split in @(@('high', '(call $proc_exit (i32.shr_u (call $spiralMain) (i32.const 4)))'), @('low', '(call $proc_exit (i32.and (call $spiralMain) (i32.const 15)))'))) {
                    $splitModule = Join-Path $binDir "exit-$($split[0]).wat"
                    [IO.File]::WriteAllText($splitModule, $module.Replace($wasiStart, $split[1]))
                    Invoke-Native $tools.Wasmtime @('run', '-W', 'max-wasm-stack=1073741824', $splitModule) $binDir 60
                })
                $splitClean = @($splitRuns | Where-Object { "$($_.Exit)" -match '^\d+$' -and "$($_.Err)" -notmatch 'exit with invalid exit status' }).Count -eq 2
                if ($splitClean) { $run.Exit = [int]$splitRuns[0].Exit * 16 + [int]$splitRuns[1].Exit }
            }
        }
        if ("$($run.Exit)" -ne '0' -and $run.Err -match '\.wat:\d+:\d+|Invalid input WebAssembly|failed to compile: wasm') {
            $msg = (($run.Err -split "`n" | Where-Object { $_.Trim() } | Select-Object -First 3) -join ' / ') -replace '\s+', ' '
            return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $msg.Substring(0, [Math]::Min(300, $msg.Length)) }
        }
        $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
        $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
        return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
    }
    if ($job.Backend -eq 'Lean') {
        if (-not $tools.Lean) { return 'no-toolchain' }
        $elanBin = Split-Path $tools.Lean
        if (-not $env:ELAN_HOME -and (Split-Path $elanBin -Leaf) -eq 'bin' -and (Test-Path (Join-Path $elanBin 'elan*'))) { $env:ELAN_HOME = Split-Path $elanBin }
        $run = Invoke-Native $tools.Lean @('+leanprover/lean4:v4.35.0-rc4', '--run', $job.Output) $binDir 180
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
        $env:BUN_JSC_maxPerThreadStackUsage = '16777216'
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
        $batched = if ($gleamBuilds) { $gleamBuilds[$job.Key] } else { $null }
        if ($batched) {
            if ($batched.Failure) { return [pscustomobject]@{ Status = 'build-fail'; Exit = ''; Stdout = ''; Detail = $batched.Failure.Substring(0, [Math]::Min(300, $batched.Failure.Length)) } }
            $run = Invoke-Native $tools.Erl (@('-noshell', '-pa') + $batched.Ebin + @('-eval', "spiral_exit:halt($($batched.Module):main()).")) $batched.Project 180
            $stdout = ($run.Out -replace "`r`n", "`n").TrimEnd()
            $sha = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($stdout))).ToLowerInvariant().Substring(0, 16)
            return [pscustomobject]@{ Status = 'ran'; Exit = [string]$run.Exit; Stdout = $sha; Detail = '' }
        }
        $project = Join-Path $scratch "gleam-native-$nativeLane"
        if (-not (Test-Path (Join-Path $project 'gleam.toml'))) { Copy-Item (Join-Path $shimDir 'gleam') $project -Recurse -Force }
        $programFile = Join-Path $project 'src/main.gleam'
        Get-ChildItem (Join-Path $project 'src') -File -Filter 'main_*.gleam' | Remove-Item -Force
        $partStem = [IO.Path]::GetFileNameWithoutExtension($job.Output)
        foreach ($part in Get-ChildItem -LiteralPath (Split-Path $job.Output) -File -Filter "${partStem}_*.gleam") {
            $partFile = Join-Path $project "src/$($part.Name)"
            Copy-Item -LiteralPath $part.FullName $partFile -Force
            (Get-Item $partFile).LastWriteTime = Get-Date
        }
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
        'C' { if (-not $tools.CC) { return 'no-toolchain' }; Invoke-Native $tools.CC (@('-std=c11', '-O2', '-fwrapv', '-w') + (Get-CFlags $job) + @('-o', $exe, $job.Output, '-lm')) $dir 120 }
        'Ebpf' { if (-not $tools.CC) { return 'no-toolchain' }; Invoke-Native $tools.CC (@('-std=c11', '-O2', '-fwrapv', '-w', '-x', 'c') + @('-o', $exe, $job.Output, '-lm')) $dir 120 }
        'Rust' { if (-not $tools.Rustc) { return 'no-toolchain' }; Invoke-Native $tools.Rustc @('+nightly-2026-10-18', '-C', 'opt-level=2', '-A', 'warnings', '--edition', '2024', '-o', $exe, $job.Output) $dir 180 }
        'Delphi' { if (-not $tools.Fpc) { return 'no-toolchain' }; Invoke-Native $tools.Fpc @('-O2', '-Mdelphi', "-FE$binDir", "-FU$binDir", "-o$exe", $job.Output) $dir 180 }
        'Zig' {
            if (-not $zigExe) { return 'no-toolchain' }
            $b = Invoke-Native $zigExe @('build-exe', $job.Output, '-O', 'ReleaseFast', '--stack', '1073741824', '-fno-emit-implib', "-femit-bin=$exe", '--cache-dir', "$zigCache-local", '--global-cache-dir', $zigCache) $dir 120
            if ($b.Exit -eq 'timeout') { $script:zigCacheGen++; $script:zigCache = Join-Path $scratch "zig-cache-$stamp-$($script:zigCacheGen)" }
            $b
        }
        'Cpp' {
            if (-not $tools.Python) { return 'no-toolchain' }
            if (-not $env:SPIRAL_CXX) {
                $mingwxx = Join-Path $HOME 'scoop/apps/mingw/current/bin/g++.exe'
                if (Test-Path $mingwxx) { $env:SPIRAL_CXX = $mingwxx }
            }
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
    $nativeJobs = @($jobs | Where-Object { $compiled[$_.Key] -and $compiled[$_.Key].Status -in 'ok', 'emitted' })
    $nativeMemoDir = Join-Path $cache 'native-memo'
    New-Item -ItemType Directory -Force $nativeMemoDir | Out-Null
    $nativeSignature = Get-NativeSignature
    $nativeMemoKeys = @{}
    $nativeReused = 0
    $nativeReusedMs = 0
    $nativeJobs = @(foreach ($job in $nativeJobs) {
        if (-not (Test-Path -LiteralPath $job.Output)) { $job; continue }
        $memoKey = Get-NativeMemoKey $job $nativeSignature
        $nativeMemoKeys[$job.Key] = $memoKey
        $memoPath = Join-Path $nativeMemoDir "$memoKey.json"
        if ($ReuseNative -and (Test-Path -LiteralPath $memoPath)) {
            $stored = Get-Content -LiteralPath $memoPath -Raw | ConvertFrom-Json
            $stored.Detail = ("$($stored.Detail) native-reused").Trim()
            $nativeResults[$job.Key] = $stored
            $nativeReused++
            $nativeReusedMs += [int]$stored.Ms
            continue
        }
        $job
    })
    if ($ReuseNative) { Write-Host ("== native memo: {0} rows replayed (they took {1:N1} min summed), {2} to run" -f $nativeReused, ($nativeReusedMs / 60000), $nativeJobs.Count) }
    $fsharpWarmJobs = @()
    if ($tools.Dotnet) { $fsharpWarmJobs = @($nativeJobs | Where-Object Backend -eq 'Fsharp') }
    if ($fsharpWarmJobs.Count) {
        $fsharpWatch = [Diagnostics.Stopwatch]::StartNew()
        $fsharpRunner = Join-Path $shimDir 'fsharp-warm/warm.ps1'
        $fsharpSessions = [Math]::Max(1, [Math]::Min(2, $fsharpWarmJobs.Count))
        $fsharpChunks = for ($i = 0; $i -lt $fsharpSessions; $i++) { , @(for ($k = $i; $k -lt $fsharpWarmJobs.Count; $k += $fsharpSessions) { $fsharpWarmJobs[$k] }) }
        $fsharpResults = $fsharpChunks | ForEach-Object -ThrottleLimit $fsharpSessions -Parallel {
            $chunk = @($_)
            $work = Join-Path $using:scratch ("fsharp-warm-{0}-{1}" -f $using:stamp, [guid]::NewGuid().ToString('N').Substring(0, 8))
            $warm = @(& $using:fsharpRunner -Dotnet ($using:tools).Dotnet -Scripts @($chunk | ForEach-Object Output) -TimeoutSec 60 -Work $work)
            for ($i = 0; $i -lt $chunk.Count; $i++) { [pscustomobject]@{ Job = $chunk[$i]; Result = $warm[$i] } }
        }
        $fsharpColdKeys = [Collections.Generic.HashSet[string]]::new()
        foreach ($entry in $fsharpResults) {
            $w = $entry.Result
            if ($w.Status -eq 'timeout') {
                [void]$fsharpColdKeys.Add($entry.Job.Key)
                Write-Host ("native {0} Fsharp: warm timeout after {1:N1}s, rerun cold" -f $entry.Job.Id, ($w.Ms / 1000))
                continue
            }
            $sha = if ($w.Status -eq 'ran') { [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($w.Stdout))).ToLowerInvariant().Substring(0, 16) } else { '' }
            $processExit = if ($IsWindows -or "$($w.Exit)" -notmatch '^-?\d+$') { $w.Exit } else { [int]([int64]"$($w.Exit)" -band 255) }
            $nativeResults[$entry.Job.Key] = [pscustomobject]@{ Status = $w.Status; Exit = $processExit; Stdout = $sha; Detail = $w.Detail; Ms = $w.Ms; RunMs = $w.Ms }
            Write-Host ("native {0} Fsharp: {1} exit {2} ({3:N1}s, warm)" -f $entry.Job.Id, $w.Status, $processExit, ($w.Ms / 1000))
        }
        $nativeJobs = @($nativeJobs | Where-Object { $_.Backend -ne 'Fsharp' -or $fsharpColdKeys.Contains($_.Key) })
        $fsharpWarmJobs = @($fsharpWarmJobs | Where-Object { -not $fsharpColdKeys.Contains($_.Key) })
        Write-Host ("== fsharp warm: {0} rows in {1} session(s), {2:N1}s" -f $fsharpWarmJobs.Count, $fsharpSessions, $fsharpWatch.Elapsed.TotalSeconds)
    }
    $laneCount = if ($env:SPIRAL_NATIVE_PARALLEL) { [int]$env:SPIRAL_NATIVE_PARALLEL } else { [Math]::Max(1, [Math]::Min(6, [Environment]::ProcessorCount - 2)) }
    $lanes = [Collections.Generic.List[object]]::new()
    for ($i = 0; $i -lt $laneCount; $i++) {
        $chunk = @(for ($k = $i; $k -lt $nativeJobs.Count; $k += $laneCount) { $nativeJobs[$k] })
        if ($chunk.Count) { $lanes.Add([pscustomobject]@{ Lane = $i; Jobs = $chunk }) }
    }
    $kotlinBuilds = @{}
    $kotlinStdlib = ''
    $kotlinJobs = @($nativeJobs | Where-Object Backend -eq 'Kotlin')
    if ($kotlinJobs.Count -and $tools.Kotlinc -and $tools.Java) {
        $kotlinWatch = [Diagnostics.Stopwatch]::StartNew()
        $kotlinLib = Join-Path (Split-Path (Split-Path $tools.Kotlinc)) 'lib'
        $kotlinStdlib = Join-Path $kotlinLib 'kotlin-stdlib.jar'
        $kotlinClasspath = (Get-ChildItem $kotlinLib -Filter *.jar | Where-Object Name -notmatch 'sources|-js|wasm' | ForEach-Object FullName) -join [IO.Path]::PathSeparator
        $kotlinServer = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '../tests/native-shims/kotlin-server/KotlinServer.java'))
        $kotlinRequests = foreach ($job in $kotlinJobs) {
            $classes = Join-Path $job.Native 'classes'
            Remove-Item -LiteralPath $classes -Recurse -Force -ErrorAction SilentlyContinue
            "$($job.Output)`t$classes"
        }
        $serverStart = [Diagnostics.ProcessStartInfo]::new($tools.Java)
        foreach ($argument in @('-Xmx1g', '--add-opens', 'java.base/java.util=ALL-UNNAMED', '-cp', $kotlinClasspath, $kotlinServer, $kotlinStdlib)) { $serverStart.ArgumentList.Add($argument) }
        $serverStart.RedirectStandardInput = $true; $serverStart.RedirectStandardOutput = $true; $serverStart.RedirectStandardError = $true; $serverStart.UseShellExecute = $false
        $server = [Diagnostics.Process]::Start($serverStart)
        $serverErrors = $server.StandardError.ReadToEndAsync()
        $serverReplies = $server.StandardOutput.ReadToEndAsync()
        foreach ($request in $kotlinRequests) { $server.StandardInput.WriteLine($request) }
        $server.StandardInput.Close()
        if (-not $server.WaitForExit(60000 + 20000 * $kotlinJobs.Count)) { $server.Kill($true) }
        foreach ($reply in ($serverReplies.Result -split "`r?`n")) {
            if ($reply.StartsWith("DONE`t")) { $f = $reply -split "`t", 5; $kotlinBuilds[$f[1]] = [pscustomobject]@{ Exit = $f[2]; Ms = [int]$f[3]; Messages = $f[4] } }
        }
        Write-Host ("== kotlin server: {0} of {1} compiled in {2:N1}s" -f @($kotlinBuilds.Values | Where-Object Exit -eq 'OK').Count, $kotlinJobs.Count, $kotlinWatch.Elapsed.TotalSeconds)
    }
    $swiftBatch = @{}
    $swiftBatchExe = ''
    $swiftJobs = @($nativeJobs | Where-Object Backend -eq 'Swift')
    if ($swiftJobs.Count -gt 1 -and $tools.Swiftc -and $tools.SwiftSdk -and $tools.SwiftRuntime) {
        $swiftWatch = [Diagnostics.Stopwatch]::StartNew()
        $swiftDir = Join-Path $scratch "swift-batch-$stamp"
        Remove-Item -LiteralPath $swiftDir -Recurse -Force -ErrorAction SilentlyContinue
        New-Item -ItemType Directory -Force $swiftDir | Out-Null
        $swiftChunkSize = 16
        $swiftChunks = for ($first = 0; $first -lt $swiftJobs.Count; $first += $swiftChunkSize) {
            $chunkDir = Join-Path $swiftDir "chunk$first"
            New-Item -ItemType Directory -Force $chunkDir | Out-Null
            $members = @($swiftJobs[$first..([Math]::Min($first + $swiftChunkSize, $swiftJobs.Count) - 1)])
            $swiftMainLines = 'import CRT', 'import WinSDK', 'exit(spiral_main())', 'nonisolated(unsafe) var spiral_exit_code: Int32 = 0', 'WaitForSingleObject(spiral_thread, INFINITE)', 'exit(spiral_exit_code)'
            $cases = for ($slot = 0; $slot -lt $members.Count; $slot++) {
                $source = [IO.File]::ReadAllLines($members[$slot].Output)
                $imports = @($source | Where-Object { $_ -match '^import ' -and $_ -notin $swiftMainLines })
                $wrapped = foreach ($line in $source) {
                    if ($line -in $swiftMainLines -or $line -in $imports -or $line.StartsWith('let spiral_thread = CreateThread(')) { continue }
                    if ($line -match '^(func|var|let) ') { "    static $line"; continue }
                    "    $line"
                }
                [IO.File]::WriteAllText((Join-Path $chunkDir "s$slot.swift"), ((@('import CRT') + $imports) -join "`n") + "`nenum SpiralBatch$slot {`n" + ($wrapped -join "`n") + "`n}`n")
                if ($source -match '\{ _ in spiral_main\(\); return 0 \}') { "case `"$slot`": SpiralBatch$slot.spiral_main(); exit(0)" }
                else { "case `"$slot`": exit(SpiralBatch$slot.spiral_main())" }
            }
            [IO.File]::WriteAllText((Join-Path $chunkDir 'main.swift'), "import CRT`nswitch CommandLine.arguments[1] {`n" + ($cases -join "`n") + "`ndefault: exit(99)`n}`n")
            [pscustomobject]@{ Dir = $chunkDir; Outputs = @($members | ForEach-Object Output); Exe = Join-Path $chunkDir $(if ($IsWindows) { 'batch.exe' } else { 'batch' }) }
        }
        $swiftTools = $tools
        $swiftBuilt = $swiftChunks | ForEach-Object -ThrottleLimit ([Math]::Max(1, $laneCount)) -Parallel {
            $chunk = $_
            $tools = $using:swiftTools
            $sources = @(Join-Path $chunk.Dir 'main.swift') + @(0..($chunk.Outputs.Count - 1) | ForEach-Object { Join-Path $chunk.Dir "s$_.swift" })
            $mainThreadStack = if ($IsWindows) { @('-Xlinker', '/STACK:1073741824') } else { @() }
            & $tools.Swiftc -O -no-whole-module-optimization -j 2 -sdk $tools.SwiftSdk @mainThreadStack -o $chunk.Exe @sources *> (Join-Path $chunk.Dir 'build.log')
            [pscustomobject]@{ Chunk = $chunk; Ok = ($LASTEXITCODE -eq 0 -and (Test-Path -LiteralPath $chunk.Exe)) }
        }
        foreach ($built in @($swiftBuilt | Where-Object Ok)) {
            for ($slot = 0; $slot -lt $built.Chunk.Outputs.Count; $slot++) { $swiftBatch[$built.Chunk.Outputs[$slot]] = [pscustomobject]@{ Exe = $built.Chunk.Exe; Slot = "$slot" } }
        }
        $swiftBatchExe = if ($swiftBatch.Count) { 'chunked' } else { '' }
        Write-Host ("== swift batch: {0} of {1} programs built in {2} chunks of {3} in {4:N1}s; the rest build on their own" -f $swiftBatch.Count, $swiftJobs.Count, @($swiftChunks).Count, $swiftChunkSize, $swiftWatch.Elapsed.TotalSeconds)
    }
    $gleamBuilds = @{}
    $gleamJobs = @($nativeJobs | Where-Object { $_.Backend -eq 'Gleam' -and -not @(Get-OutputParts $_.Output | Where-Object Extension -eq '.gleam').Count })
    if ($gleamJobs.Count -and $tools.Gleam -and $tools.Erl) {
        $gleamWatch = [Diagnostics.Stopwatch]::StartNew()
        $erlBin = Split-Path $tools.Erl
        if (-not (($env:PATH -split [IO.Path]::PathSeparator) -contains $erlBin)) { $env:PATH = "$erlBin$([IO.Path]::PathSeparator)$env:PATH" }
        $gleamBatch = Join-Path $scratch "gleam-batch-$stamp"
        Remove-Item -LiteralPath $gleamBatch -Recurse -Force -ErrorAction SilentlyContinue
        Copy-Item (Join-Path $shimDir 'gleam') $gleamBatch -Recurse -Force
        Remove-Item -LiteralPath (Join-Path $gleamBatch 'src/spiral_run.gleam')
        $gleamModules = @{}
        for ($i = 0; $i -lt $gleamJobs.Count; $i++) {
            $module = 'spiral_row_{0:D4}' -f $i
            $gleamModules[$module] = $gleamJobs[$i]
            Copy-Item -LiteralPath $gleamJobs[$i].Output (Join-Path $gleamBatch "src/$module.gleam")
        }
        $gleamFailures = @{}
        for ($round = 0; $round -le $gleamJobs.Count; $round++) {
            $gleamBuild = Invoke-Native $tools.Gleam @('build', '--no-print-progress') $gleamBatch 900
            if ("$($gleamBuild.Exit)" -eq '0') { break }
            $failedNow = @{}
            $lastError = $null
            foreach ($line in (($gleamBuild.Out + "`n" + $gleamBuild.Err) -split "`r?`n")) {
                if ($line -match '^error: (.*)') { $lastError = $Matches[1] }
                elseif ($line -match '^warning: ') { $lastError = $null }
                elseif ($lastError -and $line -match 'src[\\/](spiral_row_\d{4})\.gleam' -and -not $failedNow.ContainsKey($Matches[1])) { $failedNow[$Matches[1]] = $lastError }
            }
            if (-not $failedNow.Count) { $gleamFailures = $null; break }
            foreach ($module in $failedNow.Keys) {
                $gleamFailures[$module] = $failedNow[$module]
                Remove-Item -LiteralPath (Join-Path $gleamBatch "src/$module.gleam")
            }
        }
        if ($null -ne $gleamFailures) {
            $gleamEbin = @(Get-ChildItem (Join-Path $gleamBatch 'build/dev/erlang') -Directory | ForEach-Object { Join-Path $_.FullName 'ebin' })
            foreach ($module in $gleamModules.Keys) {
                $gleamBuilds[$gleamModules[$module].Key] = [pscustomobject]@{ Module = $module; Project = $gleamBatch; Ebin = $gleamEbin; Failure = $gleamFailures[$module] }
            }
        }
        Write-Host ("== gleam batch: {0} of {1} built in {2:N1}s{3}" -f ($gleamJobs.Count - $(if ($gleamFailures) { $gleamFailures.Count } else { 0 })), $gleamJobs.Count, $gleamWatch.Elapsed.TotalSeconds, $(if ($null -eq $gleamFailures) { '; unattributed build error, rows build one by one' } else { '' }))
    }
    $laneFunctions = @{ 'Build-And-Run' = ${function:Build-And-Run}.ToString(); 'Invoke-Native' = ${function:Invoke-Native}.ToString(); 'Get-CFlags' = ${function:Get-CFlags}.ToString() }
    if ($IsWindows) {
        if (-not ('Spiral.NativeErrorMode' -as [type])) {
            Add-Type -Namespace Spiral -Name NativeErrorMode -MemberDefinition @'
[System.Runtime.InteropServices.DllImport("kernel32.dll")]
public static extern uint SetErrorMode(uint mode);
'@
        }
        # abort() otherwise waits on WerFault. A 30s native timeout then looks like a missed exit 3.
        [Spiral.NativeErrorMode]::SetErrorMode(0x8003) | Out-Null
    }
    $laneResults = $lanes | ForEach-Object -ThrottleLimit ([Math]::Max(1, $lanes.Count)) -Parallel {
        foreach ($f in ($using:laneFunctions).GetEnumerator()) { Set-Item "function:$($f.Key)" -Value ([scriptblock]::Create($f.Value)) }
        $nativeLane = $_.Lane
        $kotlinBuilds = $using:kotlinBuilds; $kotlinStdlib = $using:kotlinStdlib; $gleamBuilds = $using:gleamBuilds
        $swiftBatch = $using:swiftBatch; $swiftBatchExe = $using:swiftBatchExe
        $tools = $using:tools; $zigExe = $using:zigExe; $zigCacheGen = 0; $zigCache = "$($using:zigCache)-lane$nativeLane"
        $scratch = $using:scratch; $shimDir = $using:shimDir; $cFlagRules = $using:cFlagRules; $stamp = $using:stamp
        $laneResult = @{}
        foreach ($job in $_.Jobs) {
            $jobWatch = [Diagnostics.Stopwatch]::StartNew()
            $global:SpiralLastNativeMs = $null
            $r = Build-And-Run $job
            if ($r -is [string]) { $r = [pscustomobject]@{ Status = $r; Exit = ''; Stdout = ''; Detail = '' } }
            $r | Add-Member -NotePropertyName Ms -NotePropertyValue ([int]$jobWatch.Elapsed.TotalMilliseconds) -Force
            $r | Add-Member -NotePropertyName RunMs -NotePropertyValue $global:SpiralLastNativeMs -Force
            $laneResult[$job.Key] = $r
            Write-Host ("native {0} {1}: {2} exit {3} ({4:N1}s)" -f $job.Id, $job.Backend, $r.Status, $r.Exit, $jobWatch.Elapsed.TotalSeconds)
        }
        $laneResult
    }
    foreach ($laneResult in $laneResults) { foreach ($k in $laneResult.Keys) { $nativeResults[$k] = $laneResult[$k] } }
    foreach ($job in @($nativeJobs) + @($fsharpWarmJobs)) {
        $result = $nativeResults[$job.Key]
        $memoKey = $nativeMemoKeys[$job.Key]
        if (-not $memoKey -or -not $result -or $result.Status -notin 'ran', 'build-fail' -or "$($result.Exit)" -eq 'timeout') { continue }
        if ($result.Status -eq 'build-fail' -and -not "$($result.Detail)".Trim()) { continue }
        $memo = [ordered]@{ Status = $result.Status; Exit = "$($result.Exit)"; Stdout = "$($result.Stdout)"; Detail = "$($result.Detail)"; Ms = [int]$result.Ms; RunMs = $result.RunMs }
        try { [IO.File]::WriteAllText((Join-Path $nativeMemoDir "$memoKey.json"), ($memo | ConvertTo-Json -Compress)) } catch { }
    }
    Write-Host ("== native lanes: {0}, each with its own gleam project and zig cache" -f $lanes.Count)
    Get-ChildItem $scratch -Directory -Filter "zig-cache-$stamp-*" -ErrorAction SilentlyContinue | ForEach-Object { try { [IO.Directory]::Delete($_.FullName, $true) } catch { } }
    Write-Host ("== native tier in {0:N1}s" -f $sw.Elapsed.TotalSeconds)
}

if ($Native -and $ReuseNative) {
    foreach ($k in @($nativeResults.Keys)) {
        if ("$($nativeResults[$k].Detail)" -notmatch 'native-reused' -or -not $nativeMemoKeys[$k]) { continue }
        $usedEntry = Join-Path $nativeMemoDir "$($nativeMemoKeys[$k]).json"
        if (Test-Path -LiteralPath $usedEntry) { [IO.File]::SetLastWriteTime($usedEntry, (Get-Date)) }
    }
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
        native = if ($n) { $n.Status } else { '' }; native_ms = if ($n) { $n.Ms } else { '' }; exit = if ($n) { $n.Exit } else { '' }; stdout = if ($n) { $n.Stdout } else { '' }
        oracle = ''; baseline = ''; detail = (($c.Detail + ' ' + $(if ($n) { $n.Detail } else { '' })) -replace '\s+', ' ').Trim()
        run_ms = if ($n) { $n.RunMs } else { '' }
    }
}
$rows = @($rows)

function Test-FailureExit([string]$backend, [string]$exit) {
    $code = 0L
    if (-not [long]::TryParse($exit, [ref]$code)) { return $false }
    if ($code -lt 0 -or $code -ge 3221225472L) { return $true }
    if ($code -in 1, 3, 134) { return $true }
    if ($backend -eq 'Rust' -and $code -eq 101) { return $true }
    if ($backend -eq 'Delphi' -and $code -in @(200..219) + @(227, 229, 231, 232)) { return $true }
    $false
}
function Test-SharedFailure($c, $row) {
    if ($c.exit -eq 'timeout' -or $row.exit -eq 'timeout') { return $c.exit -eq 'timeout' -and $row.exit -eq 'timeout' }
    (Test-FailureExit $c.backend $c.exit) -and (Test-FailureExit $row.backend $row.exit)
}
$byId = $rows | Group-Object id -AsHashTable
$known = @{}
$oracles = @($Oracle | ForEach-Object { $_ -split ',' } | ForEach-Object { $_.Trim() } | Where-Object { $_ })
foreach ($name in $oracles) { if ($name -notin 'C', 'Zig', 'Rust', 'Delphi', 'Wasm', 'Lean', 'Gleam', 'Lua', 'TypeScript', 'Python', 'Kotlin', 'Swift') { throw "unknown oracle '$name'" } }
$Oracle = $oracles[0]
function Get-ScopedKnown([string]$OracleName) {
    $scoped = @{}
    $platform = if ($IsWindows) { 'Windows' } else { 'Linux' }
    $matrix.Known | Where-Object { (-not $_.ContainsKey('Oracle') -or $_['Oracle'] -eq $OracleName) -and (-not $_.ContainsKey('Platform') -or $_['Platform'] -eq $platform) } | ForEach-Object { $scoped["$($_.Id)|$($_.Backend)"] = $_.Reason }
    $scoped
}
$known = Get-ScopedKnown $Oracle
$noOracle = if ($Oracle -eq 'C') { 'no-c' } else { "no-$($Oracle.ToLowerInvariant())" }
foreach ($row in $rows | Where-Object { $_.backend -in 'Fsharp', 'C', 'Rust', 'Delphi', 'Zig', 'Wasm', 'Wgsl', 'Calyx', 'Kotlin', 'Swift', 'OpenQasm', 'Ebpf', 'Lean', 'Bend', 'Gleam', 'Lua', 'TypeScript', 'Cpp', 'Python' -and $_.backend -ne $Oracle -and $_.native -eq 'ran' }) {
    $c = $byId[$row.id] | Where-Object { $_.backend -eq $Oracle -and $_.native -eq 'ran' } | Select-Object -First 1
    if (-not $c -and $Oracle -ne 'C' -and $row.backend -ne 'C') {
        $c = $byId[$row.id] | Where-Object { $_.backend -eq 'C' -and $_.native -eq 'ran' } | Select-Object -First 1
        if ($c) { $row.detail = ("oracle C (no $Oracle row); $($row.detail)").Trim() }
    }
    $bothFailed = $c -and (Test-SharedFailure $c $row)
    $row.oracle =
        if (-not $c) { $noOracle }
        elseif ($c.exit -eq $row.exit -and $c.stdout -eq $row.stdout) { 'agree' }
        elseif ($bothFailed) { 'agree-fail' }
        else { 'DISAGREE' }
}
foreach ($second in @($oracles | Select-Object -Skip 1)) {
    $secondKnown = Get-ScopedKnown $second
    foreach ($row in $rows | Where-Object { $_.backend -ne $second -and $_.native -eq 'ran' -and $_.oracle -in 'agree', 'agree-fail' }) {
        $z = $byId[$row.id] | Where-Object { $_.backend -eq $second -and $_.native -eq 'ran' } | Select-Object -First 1
        if (-not $z -or ($z.exit -eq $row.exit -and $z.stdout -eq $row.stdout) -or (Test-SharedFailure $z $row)) { continue }
        $reason = $secondKnown["$($row.id)|$($row.backend)"]
        if ($reason) { $row.detail = ("known vs $second oracle: $reason; $($row.detail)").Trim() }
        else { $row.oracle = 'DISAGREE'; $row.detail = ("vs $second oracle: exit $($z.exit) here $($row.exit); $($row.detail)").Trim() }
    }
}foreach ($row in $rows) {
    $reason = $known["$($row.id)|$($row.backend)"]
    if ($reason -and ($row.oracle -eq 'DISAGREE' -or $row.native -eq 'build-fail')) { $row.oracle = 'known'; $row.detail = "known: $reason; $($row.detail)" }
}$jobOutput = @{}
foreach ($job in $jobs) { $jobOutput[$job.Key] = $job.Output }
$expectedErrors = @{}
foreach ($entry in @($matrix.ExpectedErrors)) { if ($entry) { $expectedErrors[$entry.Id] = $entry.Contains } }
foreach ($row in $rows | Where-Object { $_.compile -eq 'error' -and $expectedErrors.ContainsKey($_.id) }) {
    if (-not "$($row.detail)".Contains($expectedErrors[$row.id])) { $row.oracle = 'WRONG-ERROR'; $row.detail = "wrong error: expected text '$($expectedErrors[$row.id])'; $($row.detail)" }
}
$cOnlyHelper = 'DynamicArray(Reserve|Resize|Capacity)\d|spiral_abi_lib|\(\(uint8_t\)'
foreach ($row in $rows | Where-Object { $_.backend -ne 'C' -and $_.native -eq 'build-fail' }) {
    $output = $jobOutput["$($row.id)|$($row.backend)"]
    if ($output -and (Test-Path $output) -and (Select-String -LiteralPath $output -Pattern $cOnlyHelper -Quiet)) { $row.oracle = 'c-only'; $row.detail = "c-only: the sample uses a C-only helper; $($row.detail)" }
}

foreach ($row in $rows) {
    $e = $expected["$($row.id)|$($row.backend)"]
    if (-not $e) { $row.baseline = 'new'; continue }
    $produced = $row.compile -in 'ok', 'emitted'
    $broken = if ($mode -in 'gpt5parallel', 'hopacsota') { 'missing' } else { 'REGRESSED' }
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
$bad = @($rows | Where-Object { $_.baseline -in 'REGRESSED', 'NATIVE-DIFF' -or ($mode -notin 'gpt5parallel', 'hopacsota' -and $_.baseline -eq 'UNEXPECTED-OUTPUT') -or $_.oracle -eq 'DISAGREE' -or $_.oracle -eq 'WRONG-ERROR' })
foreach ($b in $bad | Select-Object -First 20) { Write-Host "  !! $($b.id) [$($b.backend)] $($b.baseline) $($b.oracle) $($b.detail)" -ForegroundColor Red }
Write-Host "results: $resultPath"
Write-Host "outputs: written next to their sources; git diff samples shows what changed"
if ($Probe) { Write-Host "probe outputs ($Probe): $(Join-Path $scratch 'probe')" }

if ($Accept) {
    $existing = if (Test-Path $expectedPath) { @(Import-Csv $expectedPath -Delimiter "`t") } else { @() }
    $acceptRows = @($rows | Where-Object { $_.compile -ne 'timeout' })
    $skipped = $rows.Count - $acceptRows.Count
    if ($skipped) { Write-Host "not accepted: $skipped timeout row(s), they keep their previous oracle entry" -ForegroundColor Yellow }
    $fresh = @{}
    foreach ($row in $acceptRows) { $fresh["$($row.id)|$($row.backend)"] = $row }
    $scheduled = @{}
    if ($Suite -contains 'all' -and -not $Filter) { foreach ($sample in $samples) { $scheduled[$sample.Id] = @($scheduled[$sample.Id]) + @($sample.Backends) | Where-Object { $_ } | Select-Object -Unique } }
    $fullSchedule = $Suite -contains 'all' -and -not $Filter
    $unscheduled = @($existing | Where-Object { ($scheduled.ContainsKey($_.id) -and $scheduled[$_.id] -notcontains $_.backend) -or ($fullSchedule -and -not $scheduled.ContainsKey($_.id)) })
    if ($unscheduled) {
        Write-Host "dropped $($unscheduled.Count) oracle row(s) whose sample or backend the matrix no longer schedules:" -ForegroundColor Yellow
        $unscheduled | ForEach-Object { Write-Host "  $($_.id) [$($_.backend)]" }
    }
    $dropped = @{}
    foreach ($row in $unscheduled) { $dropped["$($row.id)|$($row.backend)"] = $true }
    $kept = @($existing | Where-Object { -not $fresh.ContainsKey("$($_.id)|$($_.backend)") -and -not $dropped.ContainsKey("$($_.id)|$($_.backend)") })
    $merged = $kept + @($acceptRows | ForEach-Object {
        [pscustomobject]@{ id = $_.id; backend = $_.backend; compile = $_.compile; residual = $_.residual; native = $_.native; exit = $_.exit; stdout = $_.stdout } })
    New-Item -ItemType Directory -Force (Split-Path $expectedPath) | Out-Null
    $merged | Sort-Object id, backend | Export-Csv $expectedPath -Delimiter "`t" -NoTypeInformation -UseQuotes Never
    Write-Host "accepted $($acceptRows.Count) rows into $expectedPath"
    if ($Native) { Copy-Item -LiteralPath (Join-Path $runDir 'toolchain.tsv') $baselineToolchainPath -Force; Write-Host "baseline toolchain recorded in $baselineToolchainPath" }
}
if ($Record) {
    $board = Get-SpiralScoreboardPath $mode
    New-Item -ItemType Directory -Force (Split-Path $board) | Out-Null
    $rows | Select-Object id, backend, suite, compile, native, oracle, baseline | Sort-Object id, backend |
        Export-Csv $board -Delimiter "`t" -NoTypeInformation -UseQuotes Never
    Write-Host "recorded $board"
}
if ($bad.Count -gt 0) { exit 1 }
