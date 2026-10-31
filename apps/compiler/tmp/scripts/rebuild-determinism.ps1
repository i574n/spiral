[Console]::Error.WriteLine('apps/compiler/tmp/scripts/rebuild-determinism.ps1 moved to apps/compiler/scripts/rebuild-determinism.ps1; update this caller')
if ($MyInvocation.InvocationName -eq '.') { . (Join-Path $PSScriptRoot '../../scripts/rebuild-determinism.ps1') @args; return }
$launch = [Environment]::GetCommandLineArgs()
$fileAt = [Array]::FindIndex($launch, [Predicate[string]] { $args[0] -match '^-(f|file)$' })
if ($fileAt -ge 0 -and $fileAt + 1 -lt $launch.Count -and (Resolve-Path -LiteralPath $launch[$fileAt + 1] -ErrorAction Ignore).Path -eq $PSCommandPath) {
    & (Get-Process -Id $PID).Path -NoProfile -File (Join-Path $PSScriptRoot '../../scripts/rebuild-determinism.ps1') @args
    exit $LASTEXITCODE
}
& (Join-Path $PSScriptRoot '../../scripts/rebuild-determinism.ps1') @args
if (-not $?) { exit $LASTEXITCODE }
