param(
    [Parameter(Mandatory)] [string] $Out,
    [ValidateSet('user', 'lib-head')] [string] $Which = 'user'
)
$ErrorActionPreference = 'Stop'
$repo, $rev, $filter = switch ($Which) {
    'user' { 'C:\home\git\polyglot', 'bb856d13', '\.(spi|spir)$' }
    'lib-head' { 'C:\home\git\spiral', 'HEAD', '^lib/.*\.(spi|spir)$' }
}
if (Test-Path $Out) { Remove-Item -LiteralPath $Out -Recurse -Force }
$files = git -C $repo ls-tree -r --name-only $rev | Where-Object { $_ -match $filter }
foreach ($f in $files) {
    $to = Join-Path $Out ($f -replace '/', '\')
    New-Item -ItemType Directory -Force (Split-Path $to) | Out-Null
    $text = git -C $repo show "${rev}:$f" | Out-String
    [IO.File]::WriteAllText($to, $text.Replace("`r`n", "`n"))
}
"$Which corpus: $(@($files).Count) files from $repo@$rev into $Out"
