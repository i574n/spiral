param(
    [Parameter(Mandatory)] [string] $TargetDir,
    $fast,
    $ScriptDir = $PSScriptRoot
)
$ErrorActionPreference = "Stop"
. $ScriptDir/core.ps1

$TargetDir = (New-Item -ItemType Directory -Force $TargetDir).FullName
$wgslRun = Join-Path $TargetDir "release/spiral-wgsl$(_exe)"
$runnerDir = Split-Path $wgslRun

if ($IsLinux -and !(Test-Path /usr/share/vulkan/icd.d/lvp_icd*.json)) {
    { sudo apt-get update } | Invoke-Block -OnError Continue
    { sudo apt-get install -y mesa-vulkan-drivers } | Invoke-Block -OnError Continue
    if (!(Test-Path /usr/share/vulkan/icd.d/lvp_icd*.json)) { { apt-get install -y mesa-vulkan-drivers } | Invoke-Block -OnError Continue }
}

if (!$fast -or !(Test-Path $wgslRun)) {
    $manifest = Join-Path $ScriptDir "../apps/compiler/tmp/tests/native-shims/wgsl-run/Cargo.toml"
    { cargo build --release --manifest-path $manifest --target-dir $TargetDir } | Invoke-Block
}
Write-Output "init-wgsl-run.ps1 / wgsl runner: $wgslRun"

if ($IsWindows) {
    $dxc = Get-ChildItem "${env:ProgramFiles(x86)}/Windows Kits/10/bin/*/x64/dxcompiler.dll" -ErrorAction Ignore |
        Where-Object { Test-Path (Join-Path $_.DirectoryName 'dxil.dll') } |
        Sort-Object { [version]$_.Directory.Parent.Name } -Descending | Select-Object -First 1
    if ($dxc) { Copy-Item $dxc.FullName, (Join-Path $dxc.DirectoryName 'dxil.dll') $runnerDir -Force }
    Write-Output "init-wgsl-run.ps1 / dx12 shader compiler beside the runner: $(if ($dxc) { $dxc.DirectoryName } else { 'none, wgpu falls back to fxc' })"
}

if ($IsWindows -and $env:CI) {
    $downloads = (New-Item -ItemType Directory -Force (Join-Path ([IO.Path]::GetTempPath()) "spiral-gpu-downloads-$PID")).FullName
    Invoke-WebRequest "https://sdk.lunarg.com/sdk/download/latest/windows/vulkan-runtime-components.zip" -OutFile "$downloads/vulkan-runtime.zip"
    { 7z e "$downloads/vulkan-runtime.zip" "-o$runnerDir" "*/x64/vulkan-1.dll" -y } | Invoke-Block
    $mesaRelease = Invoke-RestMethod "https://api.github.com/repos/pal1000/mesa-dist-win/releases/latest"
    $mesaAsset = $mesaRelease.assets | Where-Object { $_.name -match '^mesa3d-.*-release-msvc\.7z$' } | Select-Object -First 1
    Invoke-WebRequest $mesaAsset.browser_download_url -OutFile "$downloads/$($mesaAsset.name)"
    $mesaDir = (New-Item -ItemType Directory -Force (Join-Path $TargetDir "mesa")).FullName
    { 7z x "$downloads/$($mesaAsset.name)" "-o$mesaDir" "x64/*lvp*" -y } | Invoke-Block
    $icd = Join-Path $mesaDir "x64/lvp_icd.x86_64.json"
    New-Item -Path "HKLM:\SOFTWARE\Khronos\Vulkan\Drivers" -Force | Out-Null
    New-ItemProperty -Path "HKLM:\SOFTWARE\Khronos\Vulkan\Drivers" -Name $icd -PropertyType DWord -Value 0 -Force | Out-Null
    Write-Output "init-wgsl-run.ps1 / lavapipe $($mesaRelease.tag_name) registered for the elevated CI runner: $icd, vulkan loader beside the runner"
}
