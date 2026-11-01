param(
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ./core.ps1


{ pwsh publish-tree.ps1 -Root .. -Include '*.spi.html,*.spi.ipynb,*.spi.livemd' -Exclude 'target,_build,node_modules' } | Invoke-Block
