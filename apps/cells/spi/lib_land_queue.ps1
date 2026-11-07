param(
    [Parameter(Mandatory)] [string] $Queue,
    [int] $MaxWaitMin = 240
)
$ErrorActionPreference = 'Continue'
$land = Join-Path $PSScriptRoot 'lib_land_window.ps1'
function Say([string] $line) { [Console]::WriteLine($line) }
$steps = @(Get-Content -Raw -LiteralPath $Queue | ConvertFrom-Json)
$results = [Collections.Generic.List[object]]::new()
foreach ($step in $steps) {
    Say "=== $($step.Label) ($(Get-Date -Format HH:mm))"
    if ($step.Test) {
        $env:PATH = "$HOME\scoop\apps\erlang\current\bin;$HOME\scoop\apps\elixir\current\bin;$env:PATH"
        $env:MIX_ENV = 'test'
        $env:MIX_BUILD_PATH = Join-Path $env:LOCALAPPDATA 'spiral-bin/mix-builds/lib-land'
        Push-Location (Join-Path $PSScriptRoot '..')
        $mix = Join-Path (Split-Path (Get-Command mix).Source -Parent) 'mix.bat'
        & $mix test @($step.Test) --timeout 900000 2>&1 | Select-String -Pattern '^\s+\d+\) test |Result:' | ForEach-Object { Say $_.Line.Trim() }
        $code = $LASTEXITCODE
        Pop-Location
    } elseif ($step.Script) {
        pwsh -NoProfile -File $step.Script @($step.Args) 2>&1 | ForEach-Object { "$_" } | Select-Object -Last 30 | ForEach-Object { Say $_ }
        $code = $LASTEXITCODE
    } else {
        $drafts = @($step.Drafts.PSObject.Properties | ForEach-Object { "$($_.Name)=$($_.Value)" }) -join ','
        pwsh -NoProfile -File $land -Draft $drafts -BaseHash (@($step.Bases) -join ',') -Label $step.Label -MaxWaitMin $MaxWaitMin -Apply 2>&1 |
            Where-Object { "$_" -notmatch '^\d\d:\d\d:\d\d ' -and "$_" -notmatch ' <= ' } | ForEach-Object { "$_" } | Select-Object -Last 16 | ForEach-Object { Say $_ }
        $code = $LASTEXITCODE
    }
    Say "$($step.Label) exit=$code at $(Get-Date -Format HH:mm)"
    $results.Add([pscustomobject]@{ Label = $step.Label; Exit = $code })
    if ($code -and $step.StopOnRed) { Say "stopping: $($step.Label) is a guard step"; break }
}
Say '=== queue summary'
foreach ($r in $results) { Say ("{0,-70} exit={1}" -f $r.Label, $r.Exit) }
