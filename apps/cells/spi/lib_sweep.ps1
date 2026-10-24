param(
    [string] $Lib = (Join-Path $PSScriptRoot '../../../lib/spiral'),
    [string] $Out = (Join-Path $env:LOCALAPPDATA 'spiral-bin/lib-sweep.tsv'),
    [string[]] $Files,
    [string] $Candidate = (Join-Path $PSScriptRoot '../../../deps/The-Spiral-Language/VS Code Plugin')
)
$Lib = (Resolve-Path $Lib).Path
if (-not $Files) { $Files = Get-ChildItem $Lib -Recurse -Filter *.spi | Where-Object { $_.FullName -notmatch '[\\/]target[\\/]' -and (Select-String -Path $_.FullName -Pattern '^test ' -Quiet) } | ForEach-Object { $_.FullName.Substring($Lib.Length + 1) } | Sort-Object }
"file`tpassed`tfailed`tdiscovered`ttype_errors`tfirst_error`tseconds" | Set-Content $Out
foreach ($file in $Files) {
    $watch = [Diagnostics.Stopwatch]::StartNew()
    $report = & (Join-Path $PSScriptRoot 'lib_gate.ps1') -File $file -Lib $Lib -Candidate $Candidate -Show 1 2>&1 | Out-String
    $tests = [regex]::Match($report, 'tests: passed (\d+) failed (\d+) of (\d+)')
    $errors = [regex]::Match($report, 'type errors: (\d+)')
    $first = ($report -split "`n" | Where-Object { $_ -match '^\s{2}\S+:\d+ ETY' } | Select-Object -First 1)
    $row = @($file, $tests.Groups[1].Value, $tests.Groups[2].Value, $tests.Groups[3].Value, $errors.Groups[1].Value, ("$first".Trim() -replace "`t", ' '), [int]$watch.Elapsed.TotalSeconds) -join "`t"
    Add-Content $Out $row
    $row
}
