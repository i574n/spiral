param(
    [string] $MetricsDir,
    [int] $FirstRunMinutes = 10,
    [double] $Margin = 1.5
)
$ErrorActionPreference = 'Stop'
$table = if ($MetricsDir) { Join-Path $MetricsDir 'tests.tsv' } else { '' }
if (-not $table -or -not (Test-Path -LiteralPath $table)) {
    [pscustomobject]@{ Minutes = $FirstRunMinutes; Source = 'first-run default'; Rows = 0; MemoHits = 0 }
    return
}
$rows = @(Import-Csv -LiteralPath $table -Delimiter "`t")
$hits = @($rows | Where-Object { $_.Memo -eq 'hit' })
$ran = @($rows | Where-Object { $_.Memo -ne 'hit' })
$milliseconds = ($ran | ForEach-Object { [double] $_.Ms } | Measure-Object -Sum).Sum
$minutes = [Math]::Max(1, [int] [Math]::Ceiling(($milliseconds * $Margin) / 60000))
[pscustomobject]@{ Minutes = $minutes; Source = $table; Rows = $rows.Count; MemoHits = $hits.Count }
