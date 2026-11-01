param(
    [Parameter(Mandatory)] [string] $Program,
    [Parameter(Mandatory)] [string] $File,
    [string[]] $Test = @(),
    [string] $Negative = '',
    [switch] $Control,
    [string] $Lib = 'C:\home\git\spiral\lib\spiral',
    [string] $Kit = (Join-Path $env:LOCALAPPDATA 'kit\bin\kit.exe'),
    [string] $Work = (Join-Path ([IO.Path]::GetTempPath()) "lib-program-gate-$PID")
)
$ErrorActionPreference = 'Stop'
$gate = (Resolve-Path (Join-Path $Lib '../../apps/cells/spi/lib_gate.ps1')).Path
$copy = Join-Path $Work 'lib\spiral'
function Get-Hash16([string] $Path) { (Get-FileHash -LiteralPath $Path).Hash.Substring(0, 16) }
function Invoke-Program([string] $Path) {
    $out = @(Get-Content -Raw -LiteralPath $Path | & $kit do $copy - 2>&1 | ForEach-Object { "$_" })
    $code = $LASTEXITCODE
    $out | Select-Object -Last 2 | ForEach-Object { [Console]::WriteLine("lib-program-gate / do / $_") }
    if ($code) { throw "lib-program-gate / kit do exit $code on $Path" }
}
function Invoke-Gate([string] $Label, [string[]] $Names = $Test) {
    $testArgs = if ($Names.Count) { @('-Test', ($Names -join ',')) } else { @() }
    $out = @(& pwsh -NoProfile -NonInteractive -File $gate -File $File -Lib $copy @testArgs -RawOut (Join-Path $Work "$Label.raw.txt") 2>&1 | ForEach-Object { "$_" })
    $out | Set-Content -LiteralPath (Join-Path $Work "$Label.txt")
    $out | ForEach-Object { [Console]::WriteLine("lib-program-gate / $Label / $_") }
    $tests = [regex]::Match(($out -join "`n"), 'tests: passed (\d+) failed (\d+) of (\d+)')
    $types = [regex]::Match(($out -join "`n"), 'type errors: (\d+)')
    [pscustomobject]@{
        Ran = $tests.Success -and [int]$tests.Groups[1].Value + [int]$tests.Groups[2].Value -gt 0
        Failed = if ($tests.Success) { [int]$tests.Groups[2].Value } else { -1 }
        TypeErrors = if ($types.Success) { [int]$types.Groups[1].Value } else { -1 }
    }
}
if (Test-Path -LiteralPath $Work) { throw "lib-program-gate / $Work exists; pass a fresh -Work" }
robocopy $Lib $copy /E /XD target _build .cache /NFL /NDL /NJH /NJS /NP | Out-Null
"lib-program-gate / $File base $(Get-Hash16 (Join-Path $copy $File)) / live $(Get-Hash16 (Join-Path $Lib $File))"
if ($Control) {
    $baseText = [IO.File]::ReadAllText((Join-Path $copy $File))
    $present = @($Test -split ',' | Where-Object { $_ -and $baseText -match "(?m)^test $([regex]::Escape($_)) =" })
    "lib-program-gate / control runs $($present.Count) of $(@($Test -split ',' | Where-Object { $_ }).Count) tests (the rest are new): $($present -join ',')"
    if ($present) {
        $base = Invoke-Gate 'control' $present
        "lib-program-gate / control (unchanged base) $(if (-not $base.Ran) { 'NOT RUN' } elseif ($base.Failed -eq 0 -and $base.TypeErrors -eq 0) { 'GREEN' } else { 'RED' })"
    }
}
Invoke-Program $Program
"lib-program-gate / $File target $(Get-Hash16 (Join-Path $copy $File))"
$positive = Invoke-Gate 'positive'
$green = $positive.Ran -and $positive.Failed -eq 0 -and $positive.TypeErrors -eq 0
"lib-program-gate / positive $(if ($green) { 'GREEN' } else { 'RED' })"
$caught = $true
if ($Negative) {
    Invoke-Program $Negative
    $mutant = Invoke-Gate 'negative'
    $caught = $mutant.Ran -and $mutant.Failed -gt 0 -and $mutant.TypeErrors -eq 0
    "lib-program-gate / negative $(if ($caught) { 'CAUGHT (a test failed, no type error)' } else { 'NOT CAUGHT' })"
}
if (-not $green -or -not $caught) { exit 1 }
