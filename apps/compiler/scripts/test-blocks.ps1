param(
    [string] $Lib,
    [string[]] $Files = @(),
    [string] $Out = (Join-Path $env:LOCALAPPDATA "spiral-bin\runs\testblocks-$(Get-Date -Format yyyyMMdd-HHmmss)"),
    [string[]] $Reports = @(),
    [ValidateSet('process', 'daemon')] [string] $Compiler = 'daemon'
)
$ErrorActionPreference = 'Stop'
$Files = @($Files | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
New-Item -ItemType Directory -Force $Out | Out-Null
if ($Files.Count) {
    if (-not $Lib) { throw '-Files needs -Lib, the package directory that holds them' }
    foreach ($file in $Files) {
        $raw = Join-Path $Out "$($file.Replace("'", '')).gate.txt"
        & C:\home\git\spiral\apps\cells\spi\lib_gate.ps1 -Lib $Lib -File $file -RawOut $raw -Show 0 -Compiler $Compiler 2>&1 | Out-Null
        $Reports += "$raw.tests.tsv"
    }
}
if (-not $Reports.Count) { throw 'nothing to convert: pass -Lib with -Files, or -Reports <*.tests.tsv>' }
$backendOf = @{ c = 'C'; zig = 'Zig'; rust = 'Rust'; fsharp = 'Fsharp'; gleam = 'Gleam'; typescript = 'TypeScript'; python = 'Python'; lua = 'Lua'; lean = 'Lean'; delphi = 'Delphi'; cuda = 'Cuda'; kotlin = 'Kotlin'; swift = 'Swift'; wasm = 'Wasm'; bend = 'Bend'; wgsl = 'Wgsl' }
$columns = 'id', 'backend', 'suite', 'compile', 'compile_ms', 'residual', 'native', 'native_ms', 'exit', 'stdout', 'oracle', 'baseline', 'detail', 'run_ms'
$rows = foreach ($report in $Reports) {
    if (-not (Test-Path $report)) { Write-Host "missing report, its file yields no rows: $report"; continue }
    foreach ($test in Import-Csv $report -Delimiter "`t") {
        $ran = $test.Status -in 'passed', 'failed'
        [pscustomobject][ordered]@{
            id = "testblocks/$($test.File)/$($test.Test)"
            backend = if ($backendOf.ContainsKey($test.Target)) { $backendOf[$test.Target] } else { $test.Target }
            suite = 'testblocks'
            compile = if ($ran) { 'ok' } else { 'error' }
            compile_ms = $test.Ms
            residual = ''
            native = if ($ran) { 'ran' } else { $test.Status }
            native_ms = $test.Ms
            exit = switch ($test.Status) { 'passed' { '0' } 'failed' { '1' } default { '' } }
            stdout = ''
            oracle = if ($test.Status -eq 'passed') { 'agree' } elseif ($test.Status -eq 'failed') { 'DISAGREE' } else { "not-run-$($test.Status)" }
            baseline = ''
            detail = "vs its inline expectation: cells $($test.Status)$(if ($test.Memo) { " memo=$($test.Memo)" })"
            run_ms = '0'
        }
    }
}
$lines = @($columns -join "`t") + @($rows | ForEach-Object { $row = $_; ($columns | ForEach-Object { $row.$_ }) -join "`t" })
[IO.File]::WriteAllText((Join-Path $Out 'results.tsv'), ($lines -join "`n") + "`n", [Text.UTF8Encoding]::new($false))
$disagree = @($rows | Where-Object oracle -eq 'DISAGREE').Count
"test-block rows $(@($rows).Count): agree $(@($rows | Where-Object oracle -eq 'agree').Count), DISAGREE $disagree, not run $(@($rows | Where-Object { $_.oracle -like 'not-run-*' }).Count); run dir $Out"
if ($disagree) { exit 1 }
