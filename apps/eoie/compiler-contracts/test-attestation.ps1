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
function Check([string]$InputFile, [bool]$Expected) {
    & $dotnet $compiler --check $InputFile
    if (($LASTEXITCODE -eq 0) -ne $Expected) { throw "Unexpected --check result: $InputFile" }
}
function Plan([string]$InputFile, [bool]$Expected) {
    $output = [IO.Path]::ChangeExtension($InputFile, '.ir')
    & $dotnet $compiler --plan-ir --timeout-ms 20000 $InputFile $output | Out-Host
    if (($LASTEXITCODE -eq 0) -ne $Expected) { throw "Unexpected --plan-ir result: $InputFile" }
    if (-not $Expected -and (Test-Path -LiteralPath $output)) { throw 'Rejected plan published output.' }
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
& $dotnet $compiler --plan-ir --timeout-ms 0 $planInput (Join-Path $work 'invalid.ir')
if ($LASTEXITCODE -ne 2) { throw 'Nonpositive timeout was accepted.' }
$timer = [Diagnostics.Stopwatch]::StartNew()
& $dotnet $compiler --plan-ir --timeout-ms 1 $planInput (Join-Path $work 'timeout.ir')
if ($LASTEXITCODE -ne 3 -or $timer.Elapsed.TotalSeconds -gt 10) { throw 'Timeout was not enforced.' }
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
if (-not [regex]::IsMatch($arrayCode, 'ArrayGet[0-9]+\([^\r\n]+\) -> i32 \{\s*if index == 0 \{\s*(?:return )?v0;?\s*\}[\s\S]*?(?:else \{ v3 \}|return v3;)')) {
    throw 'Fixed-array Rust getter lost its final-element fallback.'
}
$fallbackMutation = [regex]::Replace($arrayCode, '(?m)^    let v1: i32 = 2;$', '    let v1: i32 = -1;')
if ($fallbackMutation -eq $arrayCode) { throw 'Fixed-array fallback probe could not locate the fixture index.' }
$fallbackSource = Join-Path $work 'fixed-array-fallback.rs'
$fallbackExecutable = Join-Path $bin $(if ($IsWindows) { 'fixed-array-fallback.exe' } else { 'fixed-array-fallback' })
[IO.File]::WriteAllText($fallbackSource, $fallbackMutation)
& $rustc --edition 2024 --crate-name fixed_array_fallback $fallbackSource -o $fallbackExecutable
if ($LASTEXITCODE -ne 0) { throw 'Fixed-array fallback Rust failed to compile.' }
& $fallbackExecutable
if ($LASTEXITCODE -ne 2) { throw "Fixed-array fallback returned $LASTEXITCODE; expected 2." }
Write-Host "EOIE attestation contracts passed: $work"
$LASTEXITCODE = 0
