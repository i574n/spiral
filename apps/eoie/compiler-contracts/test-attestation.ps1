param([ValidateSet('single-flight')][string]$Mode = 'single-flight')
$ErrorActionPreference = 'Stop'
. $PSScriptRoot/spiral-compiler.ps1
$dotnet = Resolve-SpiralDotnet
$compiler = Get-SpiralCompilerDll $Mode
$rustc = (Get-SpiralNativeTools).Rustc
if (-not $rustc) { throw 'rustc is required.' }
$work = Join-Path (Get-SpiralCacheDir) ('eoie-attestation/' + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $work -Force | Out-Null
function Fixture([string]$Name, [string]$Source) {
    $directory = Join-Path $work $Name
    New-Item -ItemType Directory -Path $directory -Force | Out-Null
    [IO.File]::WriteAllText((Join-Path $directory 'package.spiproj'), "modules:`n    main`n")
    $inputFile = Join-Path $directory 'main.spi'
    [IO.File]::WriteAllText($inputFile, $Source)
    return $inputFile
}
function Invoke-Spiral([string[]]$Arguments) {
    $captured = & $dotnet $compiler @Arguments 2>&1 | Out-String
    return @{ Code = $LASTEXITCODE; Output = $captured.Trim() }
}
function Check([string]$InputFile, [bool]$Expected) {
    $result = Invoke-Spiral @('--check', $InputFile)
    if (($result.Code -eq 0) -ne $Expected) { throw "Unexpected --check result: $InputFile`n$($result.Output)" }
}
function Plan([string]$InputFile, [bool]$Expected) {
    $output = [IO.Path]::ChangeExtension($InputFile, '.ir')
    $result = Invoke-Spiral @('--plan-ir', '--timeout-ms', '20000', $InputFile, $output)
    if (($result.Code -eq 0) -ne $Expected) { throw "Unexpected --plan-ir result: $InputFile`n$($result.Output)" }
    if (-not $Expected -and (Test-Path -LiteralPath $output)) { throw "Rejected plan published output.`n$($result.Output)" }
    return $output
}
$packageOnly = Fixture 'package-only' 'inl answer () : i32 = 42i32'
Check $packageOnly $true
$later = Join-Path (Split-Path $packageOnly) 'later.spi'
[IO.File]::WriteAllText($later, 'inl broken () : i32 = true')
[IO.File]::WriteAllText((Join-Path (Split-Path $packageOnly) 'package.spiproj'), "modules:`n    main`n    later`n")
Check $packageOnly $false
$undeclared = Join-Path (Split-Path $packageOnly) 'undeclared.spi'
[IO.File]::WriteAllText($undeclared, 'inl main () : i32 = 0i32')
Check $undeclared $false
$planSource = @'
inl main () : i32 =
    $"RustPlanOp(\"patch-exact\",\"value.txt\",\"{old}\",\"}new{\",\"write\")" : ()
    0i32
'@
$planInput = Fixture 'plan' $planSource
$manifest = Plan $planInput $true
$rows = [IO.File]::ReadAllLines($manifest)
$expected = @('op') + (@('patch-exact', 'value.txt', '{old}', '}new{', 'write') | ForEach-Object {
    [Convert]::ToHexString([Text.Encoding]::UTF8.GetBytes($_)).ToLowerInvariant()
})
if ($rows.Count -ne 2 -or $rows[0] -ne "EOIE-PLAN-IR`t1" -or $rows[1] -cne ($expected -join "`t")) { throw 'Plan payload changed.' }
$conditional = Fixture 'conditional-plan' @'
inl main () : i32 =
    inl flag = $"true" : bool
    if flag then
        $"RustPlanOp(\"patch-exact\",\"value.txt\",\"old\",\"new\",\"write\")" : ()
    0i32
'@
$null = Plan $conditional $false
$invalid = Invoke-Spiral @('--plan-ir', '--timeout-ms', '0', $planInput, (Join-Path $work 'invalid.ir'))
if ($invalid.Code -ne 2) { throw "Nonpositive timeout was accepted.`n$($invalid.Output)" }
$timer = [Diagnostics.Stopwatch]::StartNew()
$timeout = Invoke-Spiral @('--plan-ir', '--timeout-ms', '1', $planInput, (Join-Path $work 'timeout.ir'))
if ($timeout.Code -ne 3 -or $timer.Elapsed.TotalSeconds -gt 10) { throw "Timeout was not enforced.`n$($timeout.Output)" }
$gadt = Fixture 'gadt' @'
nominal raw_phase = ()
nominal decided_phase = ()
union phase_state phase =
    | RawState :: i32 -> phase_state raw_phase
    | DecidedState :: i32 * bool -> phase_state decided_phase
let decide (state : phase_state raw_phase) : phase_state decided_phase =
    match state with
    | RawState value => DecidedState (value, true)
let read (state : phase_state decided_phase) : i32 =
    match state with
    | DecidedState (_, accepted) => if accepted then 0i32 else 1i32
inl main () : i32 = read (decide (RawState 7i32))
'@
$rust = [IO.Path]::ChangeExtension($gadt, '.rs')
$jobs = Join-Path $work 'jobs.tsv'
$results = Join-Path $work 'results.tsv'
[IO.File]::WriteAllText($jobs, "gadt`tRust`t$gadt`t$rust`t20000`n")
& $dotnet $compiler --batch $jobs $results --timeout-ms 20000
if ($LASTEXITCODE -ne 0) { throw ([IO.File]::ReadAllText($results)) }
$bin = Join-Path $work 'bin'
New-Item -ItemType Directory -Path $bin -Force | Out-Null
$executable = Join-Path $bin $(if ($IsWindows) { 'gadt.exe' } else { 'gadt' })
& $rustc --edition 2024 --crate-name gadt $rust -o $executable
if ($LASTEXITCODE -ne 0) { throw 'GADT Rust failed native compilation.' }
& $executable
if ($LASTEXITCODE -ne 0) { throw 'GADT result disagrees with the source.' }
$arrayDirectory = Join-Path $work 'fixed-array-source'
Copy-Item -LiteralPath (Join-Path $BundleRoot 'samples/fixed_array_runtime_index') -Destination $arrayDirectory -Recurse
Copy-Item -LiteralPath (Join-Path $BundleRoot 'samples/core') -Destination (Join-Path $work 'core') -Recurse
$arrayInput = Join-Path $arrayDirectory 'main.spi'
$arrayRust = Join-Path $work 'fixed-array.rs'
& $dotnet $compiler --backend Rust (Resolve-Path $arrayInput).Path $arrayRust | Out-Host
if ($LASTEXITCODE -ne 0) { throw 'Fixed-array getter fixture failed to compile.' }
$arrayCode = [IO.File]::ReadAllText($arrayRust)
if ($arrayCode -match 'ArrayGet[0-9]+') {
    throw 'Native fixed array was scalarized through ArrayGet. That getter is the portable C lowering.'
}
if (-not [regex]::IsMatch($arrayCode, 'borrow\(\)\[v1 as usize\]')) {
    throw 'Native fixed array lost its runtime Vec index.'
}
$inRangeExecutable = Join-Path $bin $(if ($IsWindows) { 'fixed-array.exe' } else { 'fixed-array' })
& $rustc --edition 2024 --crate-name fixed_array $arrayRust -o $inRangeExecutable
if ($LASTEXITCODE -ne 0) { throw 'Fixed-array Rust failed native compilation.' }
& $inRangeExecutable
if ($LASTEXITCODE -ne 0) { throw "Fixed-array in-range result was $LASTEXITCODE; expected 0." }
$negativeMutation = [regex]::Replace($arrayCode, '(?m)^    let mut v1: i32 = 2i32;\r?$', '    let mut v1: i32 = -1i32;')
if ($negativeMutation -eq $arrayCode) { throw 'Fixed-array probe could not locate the fixture index.' }
$negativeSource = Join-Path $work 'fixed-array-negative.rs'
$negativeExecutable = Join-Path $bin $(if ($IsWindows) { 'fixed-array-negative.exe' } else { 'fixed-array-negative' })
[IO.File]::WriteAllText($negativeSource, $negativeMutation)
& $rustc --edition 2024 --crate-name fixed_array_negative $negativeSource -o $negativeExecutable
if ($LASTEXITCODE -ne 0) { throw 'Fixed-array negative Rust failed to compile.' }
$negativeLog = Join-Path $work 'fixed-array-negative.txt'
& $negativeExecutable *> $negativeLog
$negativeCode = $LASTEXITCODE
$negativeOutput = if (Test-Path -LiteralPath $negativeLog) { [IO.File]::ReadAllText($negativeLog) } else { '' }
if ($negativeCode -eq 2) { throw "Negative array index returned the portable last-element fallback.`n$negativeOutput" }
if ($negativeCode -ne 101) { throw "Negative array index exited $negativeCode; native Vec indexing panics with 101.`n$negativeOutput" }
Write-Host "EOIE attestation contracts passed: $work"
exit 0
