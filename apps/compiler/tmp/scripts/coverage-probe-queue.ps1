param(
    [Parameter(Mandatory)] [string] $Baseline,
    [string] $Backends = 'Zig,Lean,Bend,Wasm,Rust',
    [string] $Out = (Join-Path ([IO.Path]::GetTempPath()) "probe-queue-$PID")
)
$scripts = $PSScriptRoot
$matrix = Import-PowerShellDataFile (Join-Path $PSScriptRoot '../tests/matrix.psd1') -SkipLimitCheck
$env:SPIRAL_BIN_CACHE_DIR = $null
$env:SPIRAL_COMPILER_DLL = $null
$env:SPIRAL_CC = 'C:\Users\i574n\scoop\apps\gcc\current\bin\gcc.exe'
$env:DOTNET_gcServer = '0'
$env:SPIRAL_NATIVE_PARALLEL = '2'
New-Item -ItemType Directory -Force $Out | Out-Null
foreach ($backend in $Backends -split ',') {
    "$(Get-Date -Format 'HH:mm:ss') probe $backend"
    $output = pwsh -NoProfile -Command "& '$scripts/test.ps1' -Mode single-flight -Suite all -Native -Parallel 2 -ReuseNative -ReuseCompile -Probe $backend" 2>&1
    $run = ($output | Select-String -Pattern 'run dir (\S+)' | Select-Object -First 1).Matches[0].Groups[1].Value
    if (-not $run) { "  no run dir"; continue }
    $rows = Import-Csv (Join-Path $run 'results.tsv') -Delimiter "`t"
    $listed = @($matrix.$backend)
    $probe = @($rows | Where-Object { $_.backend -eq $backend -and $_.id -notin $listed })
    $agree = @($probe | Where-Object oracle -eq 'agree' | ForEach-Object id | Sort-Object -Unique)
    "  run ${run}: probe rows $($probe.Count), agree $($agree.Count), disagree $(@($probe | Where-Object oracle -match 'DISAGREE').Count)"
    $probe | Group-Object { if ($_.compile -ne 'ok') { "compile $($_.compile)" } elseif ($_.native -ne 'ran') { "native $($_.native)" } else { "oracle $($_.oracle)" } } | Sort-Object Count -Descending | ForEach-Object { "    {0,4} {1}" -f $_.Count, $_.Name }
    Set-Content (Join-Path $Out "$backend-agree.txt") ($agree -join "`n")
}
"lists: $Out"
