param([Parameter(Mandatory)] [string] $Script, [int] $CapMb = 12000, [string[]] $ScriptArgs = @())
$out = Join-Path $env:TEMP "capped-run-$PID.txt"
$run = Start-Process pwsh -ArgumentList (@('-NoProfile', '-File', $Script) + $ScriptArgs) -NoNewWindow -PassThru
$cap = Start-Process pwsh -ArgumentList @('-NoProfile', '-File', (Join-Path $PSScriptRoot 'memory-cap.ps1'), '-RootPid', $run.Id, '-CapMb', $CapMb, '-Out', $out) -NoNewWindow -PassThru
$run.WaitForExit()
$cap.WaitForExit(30000) | Out-Null
"capped-run: exit $($run.ExitCode); memory $(if (Test-Path $out) { (Get-Content $out) -join ' / ' } else { 'no sample' })"
if ((Get-Content $out -ErrorAction Ignore) -match 'capped') { exit 137 }
exit $run.ExitCode
