param(
    [string] $From = (Join-Path $env:LOCALAPPDATA 'spiral-bin\bin\single-flight\SpiralCompiler\Release\net11.0'),
    [string] $To = (Join-Path $PSScriptRoot 'dll')
)
$ErrorActionPreference = 'Stop'
if (-not (Test-Path (Join-Path $From 'SpiralCompilerCore.dll'))) { throw "missing $From\SpiralCompilerCore.dll" }
New-Item -ItemType Directory -Force $To | Out-Null
Get-ChildItem $From -Filter '*.dll' -File | Where-Object { $_.Name -notmatch '^(System|Microsoft)\.' } | Copy-Item -Destination $To -Force
$core = Get-Item (Join-Path $To 'SpiralCompilerCore.dll')
"core {0} {1:yyyy-MM-dd HH:mm} {2}" -f $core.Length, (Get-Item (Join-Path $From 'SpiralCompilerCore.dll')).LastWriteTime, (Get-FileHash $core.FullName).Hash.Substring(0, 12)
