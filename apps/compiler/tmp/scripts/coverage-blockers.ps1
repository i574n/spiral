param(
    [Parameter(Mandatory)] [string] $Run,
    [Parameter(Mandatory)] [ValidateSet('Wgsl', 'Calyx', 'Bend', 'Lean', 'Zig', 'Wasm', 'Rust', 'OpenQasm', 'Ebpf')] [string] $Backend,
    [string] $Root = (Join-Path $PSScriptRoot '..'),
    [string] $Out = (Join-Path ([IO.Path]::GetTempPath()) "blockers-$PID")
)
. (Join-Path $Root 'scripts/env.ps1')
$runDir = if (Test-Path -LiteralPath $Run) { $Run } else { Join-Path "$env:LOCALAPPDATA\spiral-bin\runs" $Run }
$rows = Import-Csv (Join-Path $runDir 'results.tsv') -Delimiter "`t"
$listed = @((Import-PowerShellDataFile (Join-Path $Root 'tests/matrix.psd1') -SkipLimitCheck).$Backend)
$present = @($rows | Where-Object backend -eq $Backend | ForEach-Object id) + $listed
$candidates = @($rows | Where-Object { $_.backend -eq 'C' -and $_.compile -eq 'ok' -and $_.native -eq 'ran' -and $_.id -notin $present } | ForEach-Object id | Sort-Object -Unique)
Remove-Item -LiteralPath $Out -Recurse -Force -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Force $Out | Out-Null
$extension = @{ Wgsl = 'wgsl'; Calyx = 'futil'; Bend = 'bend'; Lean = 'lean'; Zig = 'zig'; Wasm = 'wat'; Rust = 'rs'; OpenQasm = 'qasm'; Ebpf = 'ebpf' }[$Backend]
$jobs = Join-Path $Out 'jobs.tsv'
$results = Join-Path $Out 'results.tsv'
$candidates | ForEach-Object { "$_`t$Backend`t$(Join-Path $Root "$_/main.spi")`t$(Join-Path $Out (($_ -replace '[\\/]', '__') + ".$extension"))`t20000" } | Set-Content $jobs
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
& (Resolve-SpiralDotnet) (Get-SpiralCompilerDll single-flight) --batch $jobs $results *> (Join-Path $Out 'batch.log')
if (-not (Test-Path $results)) { "no results: see $(Join-Path $Out 'batch.log')"; exit 1 }
$census = foreach ($row in Get-Content $results) {
    $f = $row.Split("`t", 4)
    $detail = if ($f.Count -ge 4) { $f[3] } else { '' }
    $why = if ($f[1] -eq 'ok') { 'COMPILES' }
        elseif ($detail -match "doesn't support (.*?) yet") { $Matches[1] -replace '\{[^}]*\}', '{..}' -replace '^the type .*\((Y\w+)\)$', 'type $1' -replace '^the primitive ', 'primitive ' }
        elseif ($detail -match 'backend switch') { "no $Backend arm in a backend switch" }
        else { "$($f[1]): " + ($detail -replace '\s+', ' ').Substring(0, [Math]::Min(90, ($detail -replace '\s+', ' ').Length)) }
    [pscustomobject]@{ Id = $f[0]; Why = $why }
}
"{0}: {1} C run-ok samples without a row, {2} results" -f $Backend, $candidates.Count, @($census).Count
$census | Group-Object Why | Sort-Object Count -Descending | ForEach-Object { "{0,5}  {1}" -f $_.Count, $_.Name }
$census | Export-Csv (Join-Path $Out 'census.tsv') -Delimiter "`t" -NoTypeInformation
"census: $(Join-Path $Out 'census.tsv')"
