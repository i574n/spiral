param(
    $fast,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../scripts/core.ps1
. ../../lib/spiral/lib.ps1

if (!(BuildSpiral dir_tree_html.spi dir_tree_html.rs "apps/dir-tree-html")) {
    throw "RUST-FAILED apps/dir-tree-html / compile"
}
{ cargo +nightly-2025-11-01 build --release --package dir-tree-html } | Invoke-Block -Location ../../workspace
$cargoTarget = (cargo metadata --format-version 1 --no-deps --manifest-path ../../workspace/Cargo.toml | ConvertFrom-Json).target_directory

Remove-Item dist -Recurse -Force -ErrorAction Ignore
New-Item -ItemType Directory -Force -Path dist | Out-Null
Copy-Item -Force "$cargoTarget/release/DirTreeHtml$(_exe)" "dist/DirTreeHtml$(_exe)"
{ & "dist/DirTreeHtml$(_exe)" --self-test } | Invoke-Block
Write-Output "RUST-OK apps/dir-tree-html"
