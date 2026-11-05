param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"

. ./core.ps1


{ pwsh ../apps/spiral/build.ps1 } | Invoke-Block

{ pwsh ../apps/wasm/build.ps1 } | Invoke-Block

{ pwsh ../apps/plot/build.ps1 } | Invoke-Block

{ pwsh ../apps/lisp/build.ps1 } | Invoke-Block

{ pwsh ../apps/kernel/build.ps1 } | Invoke-Block

{ pwsh ../lib/spiral/build.ps1 -sequential 1 } | Invoke-Block
