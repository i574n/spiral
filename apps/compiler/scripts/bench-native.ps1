param(
    [string[]] $Samples = @(
        'mega_brzozowski_derivatives/runtime_bench', 'mega_brzozowski_derivatives/indexed_dfa_state_cardinality',
        'mega_brzozowski_derivatives/inventory_closed_dfa_runtime', 'mega_brzozowski_derivatives/runtime_native',
        'mega_lean_cic_bottom_up_kernel/runtime_native', 'mega_omniledger_erp_kernel/runtime_native',
        'mega_spiral_proves_spiral_relative_consistency/runtime_native', 'mega_zeta_structural_laboratory/runtime_native',
        'native_cube_direct'),
    [string] $Mode = 'single-flight',
    [int] $Runs = 7,
    [string] $Out = ''
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'env.ps1')
$root = Join-Path (Get-SpiralCacheDir) "native/$(ConvertTo-SpiralMode $Mode)/samples"
$sampleRoot = Join-Path $PSScriptRoot '../tmp/samples'
$shimDir = Join-Path $PSScriptRoot '../tmp/tests/native-shims'
$tools = Get-SpiralNativeTools
$kotlinStdlib = if ($tools.Kotlinc) { Join-Path (Split-Path (Split-Path $tools.Kotlinc)) 'lib/kotlin-stdlib.jar' }
function Measure-FastestRun([string] $program, [string[]] $arguments, [string] $workingDirectory, [string] $pathPrefix, [hashtable] $environment) {
    $best = [double]::MaxValue
    $code = $null
    for ($i = 0; $i -lt $Runs; $i++) {
        $info = [Diagnostics.ProcessStartInfo]::new($program)
        foreach ($argument in $arguments) { $info.ArgumentList.Add($argument) }
        $info.WorkingDirectory = $workingDirectory
        if ($pathPrefix) { $info.Environment['PATH'] = $pathPrefix + [IO.Path]::PathSeparator + $env:PATH }
        if ($environment) { foreach ($entry in $environment.GetEnumerator()) { $info.Environment[$entry.Key] = $entry.Value } }
        $info.UseShellExecute = $false
        $info.RedirectStandardOutput = $true
        $info.RedirectStandardError = $true
        $watch = [Diagnostics.Stopwatch]::StartNew()
        $process = [Diagnostics.Process]::Start($info)
        $null = $process.StandardOutput.ReadToEndAsync()
        $null = $process.StandardError.ReadToEndAsync()
        $process.WaitForExit()
        $watch.Stop()
        $code = $process.ExitCode
        $best = [Math]::Min($best, $watch.Elapsed.TotalMilliseconds)
    }
    [pscustomobject]@{ Ms = [Math]::Round($best, 1); Exit = $code }
}
function Get-InterpretedRuns([string] $sample) {
    $source = Join-Path $sampleRoot $sample
    $wat = Join-Path $source 'main.wat'
    if ($tools.Wasmtime -and (Test-Path $wat)) {
        [pscustomobject]@{ Backend = 'Wasm'; Program = $tools.Wasmtime; Arguments = @('run', '-W', 'max-wasm-stack=1073741824', $wat); Directory = $source; PathPrefix = $null }
    }
    $lua = Join-Path $source 'main.lua'
    if ($tools.Lua -and (Test-Path $lua)) {
        [pscustomobject]@{ Backend = 'Lua'; Program = $tools.Lua; Arguments = @((Join-Path $shimDir 'run_main.lua'), $lua); Directory = $source; PathPrefix = $null }
    }
    $wgsl = Join-Path $source 'main.wgsl'
    if ($tools.WgslRun -and (Test-Path $wgsl)) {
        [pscustomobject]@{ Backend = 'Wgsl'; Program = $tools.WgslRun; Arguments = @($wgsl); Directory = $source; PathPrefix = $null }
    }
    $lean = Join-Path $source 'main.lean'
    if ($tools.Lean -and (Test-Path $lean)) {
        [pscustomobject]@{ Backend = 'Lean'; Program = $tools.Lean; Arguments = @('+leanprover/lean4:v4.35.0', '--run', $lean); Directory = $source; PathPrefix = $null }
    }
    $py = Join-Path $source 'main.py'
    if ($tools.Python -and (Test-Path $py)) {
        [pscustomobject]@{ Backend = 'Python'; Program = $tools.Python; Arguments = @((Join-Path $shimDir 'run_main.py'), $py); Directory = $source; PathPrefix = $null; Environment = @{ PYTHONDONTWRITEBYTECODE = '1'; SPIRAL_CUDA = '0' } }
    }
    $gleamSource = Join-Path $source 'main.gleam'
    if ($tools.Gleam -and $tools.Erl -and (Test-Path $gleamSource)) {
        $project = Join-Path (Get-SpiralCacheDir) 'bench-gleam'
        if (-not (Test-Path (Join-Path $project 'gleam.toml'))) { Copy-Item (Join-Path $shimDir 'gleam') $project -Recurse -Force }
        Copy-Item $gleamSource (Join-Path $project 'src/main.gleam') -Force
        $erlBin = Split-Path $tools.Erl
        $buildInfo = [Diagnostics.ProcessStartInfo]::new($tools.Gleam)
        foreach ($argument in 'build', '--no-print-progress') { $buildInfo.ArgumentList.Add($argument) }
        $buildInfo.WorkingDirectory = $project
        $buildInfo.Environment['PATH'] = $erlBin + [IO.Path]::PathSeparator + $env:PATH
        $buildInfo.UseShellExecute = $false
        $buildInfo.RedirectStandardOutput = $true
        $buildInfo.RedirectStandardError = $true
        $build = [Diagnostics.Process]::Start($buildInfo)
        $null = $build.StandardOutput.ReadToEndAsync()
        $null = $build.StandardError.ReadToEndAsync()
        $build.WaitForExit()
        if ($build.ExitCode -eq 0) {
            $ebin = @(Get-ChildItem (Join-Path $project 'build/dev/erlang') -Directory | ForEach-Object { Join-Path $_.FullName 'ebin' })
            [pscustomobject]@{ Backend = 'Gleam'; Program = $tools.Erl; Arguments = @('-noshell', '-pa') + $ebin + @('-eval', 'spiral_exit:halt(main:main()).'); Directory = $project; PathPrefix = $erlBin }
        } else { Write-Warning "gleam build failed for $sample" }
    }    $bend = Join-Path $source 'main.bend'
    if ($tools.Bun -and $tools.BendMain -and (Test-Path $bend)) {
        [pscustomobject]@{ Backend = 'Bend'; Program = $tools.Bun; Arguments = @($tools.BendMain, $bend); Directory = (Split-Path $tools.BendMain); PathPrefix = $null; Environment = @{ BEND_NO_TELEMETRY = '1'; BUN_JSC_maxPerThreadStackUsage = '16777216' } }
    }
}
$rows = foreach ($sample in $Samples) {
    $dir = Join-Path $root $sample
    if (-not (Test-Path $dir)) { Write-Warning "no native build for $sample under $root"; continue }
    $compiled = foreach ($backend in Get-ChildItem $dir -Directory | Sort-Object { $_.Name -ne 'C' }, Name) {
        $exe = Join-Path $backend.FullName $(if ($IsWindows) { 'main.exe' } else { 'main' })
        $classes = Join-Path $backend.FullName 'classes'
        if (Test-Path $exe) { [pscustomobject]@{ Backend = $backend.Name; Program = $exe; Arguments = @(); Directory = $backend.FullName; PathPrefix = $(if ($backend.Name -eq 'Swift') { $tools.SwiftRuntime }) } }
        elseif ($backend.Name -eq 'Kotlin' -and $tools.Java -and $kotlinStdlib -and (Test-Path (Join-Path $classes 'MainKt.class'))) { [pscustomobject]@{ Backend = 'Kotlin'; Program = $tools.Java; Arguments = @('-cp', "$kotlinStdlib$([IO.Path]::PathSeparator)$classes", 'MainKt'); Directory = $backend.FullName; PathPrefix = $null } }
    }
    $reference = $null
    foreach ($run in @($compiled) + @(Get-InterpretedRuns $sample)) {
        if (-not $run) { continue }
        $measured = Measure-FastestRun $run.Program $run.Arguments $run.Directory $run.PathPrefix $(if ($run.PSObject.Properties['Environment']) { $run.Environment })
        if ($run.Backend -eq 'C') { $reference = $measured }
        [pscustomobject]@{
            sample = $sample; backend = $run.Backend; min_ms = $measured.Ms; exit = $measured.Exit
            vs_c = if ($reference -and $reference.Ms -gt 0) { [Math]::Round($measured.Ms / $reference.Ms, 2) } else { $null }
            exit_matches_c = if ($reference) { $measured.Exit -eq $reference.Exit } else { $null }
        }
    }
}
$rows | Format-Table -AutoSize | Out-String -Width 200
if ($Out) { $rows | Export-Csv -Path $Out -Delimiter "`t" -NoTypeInformation; "written $Out" }
