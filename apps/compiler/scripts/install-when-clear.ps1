param(
    [Parameter(Mandatory)] [string] $Name,
    [string[]] $CoreAppliers = @(),
    [string[]] $HostAppliers = @(),
    [string[]] $Programs = @(),
    [int] $MaxWaitMin = 300,
    [string] $AvoidJobPattern = 'train'
)
$ErrorActionPreference = 'Stop'
$kit = Join-Path $env:LOCALAPPDATA 'kit\bin\kit.exe'
$install = Join-Path $PSScriptRoot 'install-pack.ps1'
$CoreAppliers = @($CoreAppliers | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$HostAppliers = @($HostAppliers | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$Programs = @($Programs | ForEach-Object { $_ -split ',' } | Where-Object { $_ })
$installArgs = @('-Name', $Name, '-CoreAppliers', ($CoreAppliers -join ','), '-HostAppliers', ($HostAppliers -join ','), '-Programs', ($Programs -join ','))
$deadline = (Get-Date).AddMinutes($MaxWaitMin)
while ($true) {
    $blocking = @(& $kit job list 40 2>&1 | Select-String 'state=running' | Where-Object { $_ -match "label=\S*$AvoidJobPattern" })
    if (-not $blocking.Count) {
        pwsh -NoProfile -File $install @installArgs *> (Join-Path $env:TEMP "$Name-install-dry.log")
        if ($LASTEXITCODE -eq 0) { break }
    }
    if ((Get-Date) -gt $deadline) { "$(Get-Date -Format HH:mm) gave up after $MaxWaitMin min: $(if ($blocking.Count) { 'a train is running' } else { 'the installed compiler stayed in use' })"; exit 3 }
    Start-Sleep 120
}
"$(Get-Date -Format HH:mm) clear: no running $AvoidJobPattern job and the dry run passes"
$win = & $kit window request compiler-install 60 --label "main install $Name" 2>&1 | Select-Object -Last 1
"$win"
$winId = if ("$win" -match 'id=(\S+)') { $Matches[1] }
try {
    pwsh -NoProfile -File $install @installArgs -Apply 2>&1 | Select-Object -Last 15
    "install exit=$LASTEXITCODE"
} finally { if ($winId) { & $kit window release $winId 2>&1 | Select-Object -Last 1 } }
