param(
    [Parameter(Mandatory)] [string] $Dll,
    [Parameter(Mandatory)] [string[]] $Files,
    [Parameter(Mandatory)] [string] $Out,
    [string] $Detail = '',
    [string] $Tag = 'dll'
)
$ErrorActionPreference = 'Stop'
if (-not (Test-Path $Dll)) { throw "no compiler at $Dll" }
$Files = @($Files | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$env:SPIRAL_COMPILER_DLL = $Dll
$build = Join-Path $env:LOCALAPPDATA "spiral-bin/mix-builds/lib-gate-$Tag"
$gate = (Resolve-Path (Join-Path $PSScriptRoot '..\..\cells\spi\lib_gate.ps1')).Path
"lib-gate-dll $(Get-Date -Format 'HH:mm') dll=$Dll core=$((Get-FileHash (Join-Path (Split-Path $Dll) 'SpiralCompilerCore.dll')).Hash.Substring(0, 16)) files=$($Files.Count) build=$build" | Set-Content $Out
foreach ($f in $Files) {
    $t0 = Get-Date
    $gateArgs = @('-NoProfile', '-File', $gate, '-File', $f, '-Compiler', 'process', '-BuildPath', $build)
    if ($Detail) { $gateArgs += @('-Detail', $Detail) }
    $lines = @(pwsh @gateArgs 2>&1 | ForEach-Object { "$_" })
    $code = $LASTEXITCODE
    $summary = @($lines | Where-Object { $_ -match '^tests: |^type errors: |^failed: |^lib-gate /' }) -join ' | '
    "$f exit=$code wall=$([int]((Get-Date) - $t0).TotalSeconds)s $summary" | Add-Content $Out
    if ($f -eq $Files[0] -and $summary -match 'lib-gate /') { 'ABORT: the first file ran nothing (smoke failed)' | Add-Content $Out; exit 2 }
    if ($Detail) { $lines | Where-Object { $_ -match [regex]::Escape($Detail) -or $_ -match 'Error trace on line' } | Select-Object -First 12 | ForEach-Object { "    $_" } | Add-Content $Out }
}
'done' | Add-Content $Out
