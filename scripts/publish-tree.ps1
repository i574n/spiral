param(
    [Parameter(Mandatory)] [string] $Root,
    [string] $Tool,
    [string[]] $Include = @(),
    [string[]] $Exclude = @(),
    $ScriptDir = $PSScriptRoot
)
$ErrorActionPreference = "Stop"
. $ScriptDir/core.ps1

$Root = (Resolve-Path $Root).Path
if ($Tool) { $Tool = (Resolve-Path $Tool).Path } else { $Tool = pwsh (Join-Path $ScriptDir "dir-tree-html.ps1") | Select-Object -Last 1 }
$renderer = Join-Path ([IO.Path]::GetTempPath()) "publish-tree-$PID-$(Split-Path $Tool -Leaf)"
Copy-Item $Tool $renderer -Force

Set-Location $Root
Remove-Item dist -Recurse -Force -ErrorAction Ignore
function Test-Excluded([string] $path) { foreach ($segment in $path -split '/') { foreach ($pattern in $Exclude) { if ($segment -like $pattern) { return $true } } }; $false }
$tracked = @(git -c core.quotepath=off ls-files -z | ForEach-Object { $_ -split "`0" } | Where-Object { $_ -and !(Test-Excluded $_) })
if ($LASTEXITCODE -ne 0) { throw "publish-tree.ps1 / git ls-files failed in $Root (exit code $LASTEXITCODE)" }
$extra = @(if ($Include) {
    git -c core.quotepath=off ls-files -z --others | ForEach-Object { $_ -split "`0" } | Where-Object { $_ -and $_ -notmatch '^dist/' -and !(Test-Excluded $_) } |
        Where-Object { $name = Split-Path $_ -Leaf; @($Include | Where-Object { $name -like $_ }).Count }
})
git checkout-index -a -f --prefix=dist/
if ($LASTEXITCODE -ne 0) { throw "publish-tree.ps1 / git checkout-index failed (exit code $LASTEXITCODE)" }
foreach ($file in @(git -c core.quotepath=off ls-files -z | ForEach-Object { $_ -split "`0" } | Where-Object { $_ -and (Test-Excluded $_) })) { Remove-Item -LiteralPath (Join-Path 'dist' $file) -Force -ErrorAction Ignore }
foreach ($file in $extra) {
    $target = Join-Path 'dist' $file
    New-Item -ItemType Directory -Force (Split-Path $target) | Out-Null
    Copy-Item -LiteralPath $file $target
}
Get-ChildItem -LiteralPath dist -Recurse -Force | Where-Object { (Get-Item -LiteralPath $_.FullName -Force).LinkType } | Remove-Item -Force -ErrorAction Ignore
Write-Output "publish-tree.ps1 / $($tracked.Count) tracked files$(if ($extra) { " + $($extra.Count) untracked matching $($Include -join ', ')" }) copied to dist"

Get-ChildItem -Path dist -Recurse -Force | Sort-Object { $_.FullName.Length } -Descending | Where-Object { $_.Name.StartsWith(".") } | ForEach-Object {
    Rename-Item -LiteralPath $_.FullName -NewName "_$($_.Name.Substring(1))"
}

& $renderer --dir dist --html dist/index.html
$rendererExitCode = $LASTEXITCODE
Remove-Item $renderer -Force -ErrorAction Ignore
if ($rendererExitCode -ne 0) {
    Remove-Item dist -Recurse -Force -ErrorAction Ignore
    throw "publish-tree.ps1 / dir-tree-html failed (exit code $rendererExitCode); dist removed so the push job keeps the last good page"
}
