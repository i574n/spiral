param([long] $RunId = 0, [string] $Repo = 'i574n/spiral')
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'env.ps1')
if (-not $RunId) {
    $runs = gh run list -R $Repo --workflow gh-pages.yml -L 20 --json 'databaseId,event,status,conclusion,createdAt' | ConvertFrom-Json
    $candidate = $runs | Where-Object { $_.event -in 'schedule', 'workflow_dispatch' -and $_.status -eq 'completed' } | Select-Object -First 1
    if (-not $candidate) { throw "no completed compiler job run in the last 20 runs of $Repo" }
    $RunId = $candidate.databaseId
}
$target = Join-Path (Get-SpiralCacheDir) "runs/ci-$RunId"
if (-not (Test-Path $target)) {
    New-Item -ItemType Directory -Force $target | Out-Null
    gh run download $RunId -R $Repo -n compiler-oracle -D $target
    if ($LASTEXITCODE -ne 0) { Remove-Item -LiteralPath $target -Recurse -Force; throw "gh run download $RunId failed (the job uploads compiler-oracle only once it starts)" }
}
"ci run $RunId -> $target"
Get-ChildItem $target -Recurse -Filter results.tsv | ForEach-Object { "  $($_.Directory.FullName) ($(@(Get-Content $_.FullName).Count - 1) rows)" }
