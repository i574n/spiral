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
function Measure-Exe([string] $exe) {
    $best = [double]::MaxValue
    $code = $null
    for ($i = 0; $i -lt $Runs; $i++) {
        $info = [Diagnostics.ProcessStartInfo]::new($exe)
        $info.WorkingDirectory = Split-Path $exe
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
$rows = foreach ($sample in $Samples) {
    $dir = Join-Path $root $sample
    if (-not (Test-Path $dir)) { Write-Warning "no native build for $sample under $root"; continue }
    $reference = $null
    foreach ($backend in Get-ChildItem $dir -Directory | Sort-Object { $_.Name -ne 'C' }, Name) {
        $exe = Join-Path $backend.FullName $(if ($IsWindows) { 'main.exe' } else { 'main' })
        if (-not (Test-Path $exe)) { continue }
        $measured = Measure-Exe $exe
        if ($backend.Name -eq 'C') { $reference = $measured }
        [pscustomobject]@{
            sample = $sample; backend = $backend.Name; min_ms = $measured.Ms; exit = $measured.Exit
            vs_c = if ($reference -and $reference.Ms -gt 0) { [Math]::Round($measured.Ms / $reference.Ms, 2) } else { $null }
            exit_matches_c = if ($reference) { $measured.Exit -eq $reference.Exit } else { $null }
        }
    }
}
$rows | Format-Table -AutoSize | Out-String -Width 200
if ($Out) { $rows | Export-Csv -Path $Out -Delimiter "`t" -NoTypeInformation; "written $Out" }
