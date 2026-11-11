param([string]$Channel = '11.0', [string]$Quality = 'preview', [string]$Version)
. $PSScriptRoot/env.ps1

$target = Join-Path (Get-SpiralCacheDir) 'toolchains/dotnet'
New-Item -ItemType Directory -Force $target | Out-Null
if ($IsWindows) {
    $installer = Join-Path $target 'dotnet-install.ps1'
    Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile $installer -UseBasicParsing
    if ($Version) { & $installer -Version $Version -InstallDir $target -NoPath }
    else { & $installer -Channel $Channel -Quality $Quality -InstallDir $target -NoPath }
}
else {
    $installer = Join-Path $target 'dotnet-install.sh'
    Invoke-WebRequest 'https://dot.net/v1/dotnet-install.sh' -OutFile $installer -UseBasicParsing
    if ($Version) { & bash $installer --version $Version --install-dir $target --no-path }
    else { & bash $installer --channel $Channel --quality $Quality --install-dir $target --no-path }
}
$installed = & (Resolve-SpiralDotnet) --list-sdks
if ($Version -and -not ($installed | Where-Object { $_ -like "$Version *" })) { throw "SDK $Version is not listed after the install: $($installed -join '; ')" }
Write-Host "installed: $(Resolve-SpiralDotnet)$(if ($Version) { " (SDK $Version)" })"
