param(
    [Parameter(Mandatory)] [string] $File,
    [string] $Lib = (Join-Path $PSScriptRoot '../../../lib/spiral'),
    [string] $Candidate = (Join-Path $PSScriptRoot '../../../deps/The-Spiral-Language/VS Code Plugin'),
    [int] $Show = 12,
    [string] $Detail,
    [string] $RawOut,
    [ValidateSet('process', 'daemon')] [string] $Compiler = 'daemon',
    [string] $NotebookOut,
    [string] $BuildPath = (Join-Path $env:LOCALAPPDATA 'spiral-bin/mix-builds/lib-gate')
)
$ErrorActionPreference = 'Continue'
$libRoot = Get-Item (Resolve-Path $Lib).Path
while ($libRoot -and -not (@('lib/spiral', 'deps/spiral/lib/spiral', 'deps/polyglot/deps/spiral/lib/spiral') | Where-Object { Test-Path (Join-Path $libRoot.FullName "$_/testing.spi") })) { $libRoot = $libRoot.Parent }
if (-not $libRoot -and ((Resolve-Path $Lib).Path -replace '\\', '/') -notmatch '/lib/spiral/?$') { throw "-Lib needs lib/spiral at or above it: Cells finds the lib and its real prelude through that path (got $Lib)" }
if (-not (Test-Path -LiteralPath (Join-Path $Lib $File))) { throw "no $File under -Lib ${Lib}: a missing file runs zero tests and reads as green" }
$env:PATH = "$HOME\scoop\apps\erlang\current\bin;$HOME\scoop\apps\elixir\current\bin;$env:PATH"
$env:MIX_BUILD_PATH = $BuildPath
if (-not $env:SPIRAL_CC) { $env:SPIRAL_CC = Join-Path $HOME 'scoop\apps\gcc\current\bin\gcc.exe' }
$env:SPIRAL_COMPILER_PACKAGE_DIR = (Resolve-Path $Candidate).Path
$env:SPIRAL_CELLS_COMPILER = $Compiler
$env:SPIRAL_CELLS_MEMO = '0'
Push-Location (Join-Path $PSScriptRoot '..')
$metrics = Join-Path ([IO.Path]::GetTempPath()) "probe-lib-metrics-$PID"
if (-not $NotebookOut -and $RawOut) { $NotebookOut = "$RawOut.ipynb" }
$notebookArgs = if ($NotebookOut) { @('--output-path', $NotebookOut) } else { @() }
try { $out = mix spiral.notebook --gate --metrics $metrics --path (Join-Path $Lib $File) @notebookArgs 2>&1 | Out-String }
finally { Pop-Location }
$testRows = Join-Path $metrics 'tests.tsv'
if (Test-Path $testRows) {
    Import-Csv $testRows -Delimiter "`t" | Where-Object { $_.Status -ne 'passed' } | ForEach-Object { "target not passed: $($_.Test) $($_.Target) $($_.Status)" }
    if ($RawOut) { Copy-Item -LiteralPath $testRows "$RawOut.tests.tsv" -Force }
    Remove-Item -LiteralPath $metrics -Recurse -Force
}
$out = $out -replace '(?i)[a-z]:/Users/[^/]+/AppData/Local/spiral-bin/cells-mounts/\w+/', '' -replace "`r", ''
if ($RawOut) { Set-Content -LiteralPath $RawOut $out }
$total = [regex]::Match($out, 'spiral-tests total (\{[^\n]*\})')
if ($total.Success) { $j = $total.Groups[1].Value | ConvertFrom-Json; "tests: passed $($j.passed) failed $($j.failed) of $($j.discovered)" }
$fileReport = [regex]::Match($out, 'spiral-tests file (\{[^\n]*\})')
if ($fileReport.Success) { $names = ($fileReport.Groups[1].Value | ConvertFrom-Json).failed_tests; if ($names) { "failed: $($names -join ', ')" } }
if ($Detail) { $out -split "`n" | Select-String -SimpleMatch $Detail -Context 0, 4 | Select-Object -First 40 | ForEach-Object { $_.Line; $_.Context.PostContext } }
$out = $out -replace '(?m)^[a-zA-Z]:/\S*?/lib/spiral/', 'spiral/' -replace ' \(main\.spi:\d+:\d+\)', ''
$errors = [regex]::Matches($out, '(?m)(?:^|\s)(?:spiral/|[a-zA-Z]:/\S*/)?([^/\s:]+\.spir?):(\d+):\d+: (ETY-\w+): ([^\n]*?)(?=\s[a-zA-Z]:/\S+\.spir?:\d|\s?spiral/\S+\.spir?:\d|\n|$)((\n(Got|Expected):[^\n]*){0,2})')
"type errors: $($errors.Count)"
$errors | Group-Object { $_.Groups[1].Value } | Sort-Object Count -Descending | ForEach-Object { "  {0,-22} {1}" -f $_.Name, $_.Count }
$errors | Select-Object -First $Show | ForEach-Object {
    $line = "$($_.Groups[1].Value):$($_.Groups[2].Value) $($_.Groups[3].Value) $($_.Groups[4].Value)$($_.Groups[5].Value.Replace("`n", ' | '))"
    '  ' + $line.Substring(0, [Math]::Min(220, $line.Length))
}
