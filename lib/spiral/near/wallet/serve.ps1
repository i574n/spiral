Set-Location (Join-Path $PSScriptRoot 'dist')
$job = Start-Job { & ~/.bun/bin/bunx --bun ssl-serve --ssl }
Start-Sleep 60
Stop-Job $job | Out-Null
Receive-Job $job -Wait -AutoRemoveJob
