param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"


pwsh init.ps1

. ../deps/polyglot/scripts/core.ps1

{ pwsh ../deps/polyglot/scripts/init.ps1 } | Invoke-Block

{ pwsh ../deps/polyglot/apps/builder/build.ps1 -fast 1 } | Invoke-Block
{ pwsh ../deps/polyglot/apps/parser/build.ps1 -fast 1 } | Invoke-Block
{ pwsh ../deps/polyglot/apps/spiral/build.ps1 -fast 1 } | Invoke-Block
{ pwsh ../deps/polyglot/apps/dir-tree-html/build.ps1 -fast 1 } | Invoke-Block

{ pwsh ../apps/spiral/build.ps1 -fast 1 -SkipFsx 1 } | Invoke-Block

{ pwsh build.ps1 } | Invoke-Block

if ($env:CI) {
    Remove-Item ../deps/polyglot/target -Recurse -Force -ErrorAction Ignore
}

{ pwsh outdated.ps1 } | Invoke-Block

{ pwsh publish.ps1 } | Invoke-Block
