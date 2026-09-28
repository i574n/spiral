<#
.SYNOPSIS
Installs a .NET 11 SDK into <cache>/toolchains/dotnet without touching the system installation.
On a machine without network access (the browser sandbox), use tools/sandbox/dotnet-installer-v2.cpp
with an uploaded SDK archive instead, then point SPIRAL_DOTNET at it.
#>
param([string]$Channel = '11.0', [string]$Quality = 'preview')
. $PSScriptRoot/env.ps1

$target = Join-Path (Get-SpiralCacheDir) 'toolchains/dotnet'
New-Item -ItemType Directory -Force $target | Out-Null
if ($IsWindows) {
    $installer = Join-Path $target 'dotnet-install.ps1'
    Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile $installer -UseBasicParsing
    & $installer -Channel $Channel -Quality $Quality -InstallDir $target -NoPath
}
else {
    $installer = Join-Path $target 'dotnet-install.sh'
    Invoke-WebRequest 'https://dot.net/v1/dotnet-install.sh' -OutFile $installer -UseBasicParsing
    & bash $installer --channel $Channel --quality $Quality --install-dir $target --no-path
}
Write-Host "installed: $(Resolve-SpiralDotnet)"
