param(
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ./core.ps1


{ pwsh publish-tree.ps1 -Root .. } | Invoke-Block
