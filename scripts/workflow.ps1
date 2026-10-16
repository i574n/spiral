param(
    $fast,
    [switch] $Compiler,
    [string] $Suite = 'all',
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"


pwsh init.ps1

. ./core.ps1

if ($Compiler) {
    { pwsh ../apps/compiler/tmp/scripts/build.ps1 -Mode single-flight } | Invoke-Block

    { pwsh ../apps/compiler/tmp/scripts/test.ps1 -Mode single-flight -Suite $Suite -Native -Parallel 2 -Bless } | Invoke-Block

    return
}

{ pwsh dir-tree-html.ps1 } | Invoke-Block

{ pwsh ../apps/spiral/build.ps1 -fast 1 } | Invoke-Block

{ pwsh build.ps1 } | Invoke-Block

{ pwsh outdated.ps1 } | Invoke-Block

{ pwsh publish.ps1 } | Invoke-Block
