param(
    [Parameter(Mandatory)] [string] $Candidate,
    [string] $InstalledRun = '',
    [switch] $ReuseCompile
)
$ErrorActionPreference = 'Stop'
$arms = [ordered]@{
    installed = Join-Path $env:LOCALAPPDATA 'spiral-bin\bin\single-flight\SpiralCompiler\Release\net11.0\SpiralCompiler.dll'
    $Candidate = Join-Path $env:LOCALAPPDATA "spiral-bin-candidates\$Candidate\cache\bin\single-flight\SpiralCompiler\Release\net11.0\SpiralCompiler.dll"
}
$out = Join-Path $env:LOCALAPPDATA "spiral-bin-candidates\$Candidate\predict"
New-Item -ItemType Directory -Force $out | Out-Null
$results = [ordered]@{}
foreach ($arm in $arms.GetEnumerator()) {
    if ($arm.Key -eq 'installed' -and $InstalledRun) {
        $rows = @{}; Import-Csv -Delimiter "`t" (Join-Path $InstalledRun 'results.tsv') | ForEach-Object { $rows["$($_.id)|$($_.backend)"] = $_ }
        $results[$arm.Key] = $rows
        "installed: reused $InstalledRun, $($rows.Count) rows, timeouts $(@($rows.Values | Where-Object compile -eq 'timeout').Count)"
        continue
    }
    $env:SPIRAL_COMPILER_DLL = $arm.Value
    $started = Get-Date
    pwsh -NoProfile -File (Join-Path $PSScriptRoot '..\scripts\test.ps1') -Mode single-flight -Suite all @(if ($ReuseCompile) { '-ReuseCompile' }) 2>&1 | Select-String -Pattern '^(== compiled|results:)' | ForEach-Object { "$($arm.Key): $($_.Line)" }
    $run = (Get-ChildItem (Join-Path $env:LOCALAPPDATA 'spiral-bin\runs') -Directory -Filter 'single-flight-*' | Where-Object LastWriteTime -gt $started | Sort-Object Name | Select-Object -Last 1).FullName
    $rows = @{}; Import-Csv -Delimiter "`t" (Join-Path $run 'results.tsv') | ForEach-Object { $rows["$($_.id)|$($_.backend)"] = $_ }
    $results[$arm.Key] = $rows
    "$($arm.Key): $($rows.Count) rows in $run, timeouts $(@($rows.Values | Where-Object compile -eq 'timeout').Count)"
}
Remove-Item Env:SPIRAL_COMPILER_DLL
$a = $results.installed; $b = $results[$Candidate]
$p = @($a.Keys | Where-Object { $b.ContainsKey($_) -and $a[$_].compile -eq 'ok' -and $b[$_].compile -eq 'ok' -and $a[$_].residual -ne $b[$_].residual })
$status = @($a.Keys | Where-Object { $b.ContainsKey($_) -and $a[$_].compile -ne $b[$_].compile -and 'timeout' -notin $a[$_].compile, $b[$_].compile })
$timeouts = @($a.Keys | Where-Object { $b.ContainsKey($_) -and 'timeout' -in $a[$_].compile, $b[$_].compile })
$verdicts = @($a.Keys | Where-Object { $b.ContainsKey($_) -and $a[$_].baseline -ne $b[$_].baseline -and 'timeout' -notin $a[$_].compile, $b[$_].compile })
"PREDICTED SET P (residual differs, both ok): $($p.Count)"; $p | Select-Object -First 20 | ForEach-Object { "   $_" }
"compile status differs (no timeout involved): $($status.Count)"; $status | Select-Object -First 20 | ForEach-Object { "   $_ $($a[$_].compile) -> $($b[$_].compile)" }
"rows with a timeout on either side (rerun alone before reading): $($timeouts.Count)"; $timeouts | Select-Object -First 10 | ForEach-Object { "   $_" }
"baseline verdict differs (no timeout involved): $($verdicts.Count)"; $verdicts | Select-Object -First 30 | ForEach-Object { "   $_ $($a[$_].baseline) -> $($b[$_].baseline)" }
[ordered]@{
    predicted = $p
    status = @($status | ForEach-Object { [ordered]@{ row = $_; installed = $a[$_].compile; candidate = $b[$_].compile; detail = $b[$_].detail } })
    timeouts = $timeouts
    verdicts = @($verdicts | ForEach-Object { [ordered]@{ row = $_; installed = $a[$_].baseline; candidate = $b[$_].baseline; detail = $b[$_].detail } })
} | ConvertTo-Json -Depth 4 | Set-Content (Join-Path $out 'predict.json')
"written: $(Join-Path $out 'predict.json')"
