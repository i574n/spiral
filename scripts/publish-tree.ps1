param(
    [Parameter(Mandatory)] [string] $Root,
    [string] $Tool,
    [string[]] $Include = @(),
    $ScriptDir = $PSScriptRoot
)
$ErrorActionPreference = "Stop"
. $ScriptDir/core.ps1

$Root = (Resolve-Path $Root).Path
if ($Tool) { $Tool = (Resolve-Path $Tool).Path } else { $Tool = pwsh (Join-Path $ScriptDir "dir-tree-html.ps1") | Select-Object -Last 1 }
$renderer = Join-Path ([IO.Path]::GetTempPath()) "publish-tree-$PID-$(Split-Path $Tool -Leaf)"
Copy-Item $Tool $renderer -Force

$excluded = '.elixir_ls', '.git', '.history', '.vscode', 'bin', 'build', 'deps', 'node_modules', 'obj', 'pkg', 'target'
$included = @(
    'LICENSE', 'Dockerfile', '*.ans', '*.cs', '*.css', '*.csproj', '*.dependencies', '*.livemd', '*.editorconfig', '*.exs',
    '*.fs', '*.fsproj', '*.fsx', '*.gleam', '*.gitattributes', '*.gitignore', '*.html', '*.ico', '*.ipynb', '*.js', '*.json',
    '*.log', '*.md', '*.nix', '*.out', '*.ps1', '*.py', '*.references', '*.rs', '*.sln', '*.spi', '*.spiproj', '*.spir',
    '*.toml', '*.ts', '*.vsix', '*.wasm', '*.webm', '*.yaml', '*.yml', '*.zip'
) + $Include
$rsyncArguments = @('-av') + @($excluded | ForEach-Object { '--exclude', $_ }) + @($included | ForEach-Object { '--include', $_ }) +
    @('--include', '*/', '--exclude', '*', '--no-links', '--prune-empty-dirs', './', 'dist/')

Set-Location $Root
Remove-Item dist -Recurse -Force -ErrorAction Ignore
$env:CYGWIN = "noglob"
rsync @rsyncArguments
if ($LASTEXITCODE -ne 0) { throw "publish-tree.ps1 / rsync failed (exit code $LASTEXITCODE)" }

Get-ChildItem -Path dist -Recurse -Force | Where-Object { $_.Name.StartsWith(".") } | ForEach-Object {
    Rename-Item -Path $_.FullName -NewName "_$($_.Name.Substring(1))"
}

{ & $renderer --dir dist --html dist/index.html } | Invoke-Block
Remove-Item $renderer -Force -ErrorAction Ignore
