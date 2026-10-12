param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"


pwsh init.ps1

. ./core.ps1

{ pwsh dir-tree-html.ps1 } | Invoke-Block

{ pwsh ../apps/spiral/build.ps1 -fast 1 } | Invoke-Block

{ pwsh build.ps1 } | Invoke-Block

{ pwsh outdated.ps1 } | Invoke-Block

{ pwsh publish.ps1 } | Invoke-Block
