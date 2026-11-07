param(
    [Parameter(Mandatory)] [string] $Copy,
    [Parameter(Mandatory)] [string[]] $File,
    [Parameter(Mandatory)] [string[]] $TreeHash,
    [string] $Tree = (Join-Path $PSScriptRoot '../../../lib/spiral'),
    [switch] $Apply
)
$ErrorActionPreference = 'Stop'
if ($File.Count -ne $TreeHash.Count) { throw "-File and -TreeHash pair up: got $($File.Count) files and $($TreeHash.Count) hashes" }
function Get-ShortHash([string] $path) { if (Test-Path -LiteralPath $path) { (Get-FileHash -LiteralPath $path).Hash.Substring(0, 16) } else { 'absent' } }
for ($i = 0; $i -lt $File.Count; $i++) {
    $now = Get-ShortHash (Join-Path $Tree $File[$i])
    if ($now -ne $TreeHash[$i]) { throw "tree $($File[$i]) is $now, the gated copy was taken from $($TreeHash[$i]): re-gate on a fresh copy" }
    if (-not (Test-Path -LiteralPath (Join-Path $Copy $File[$i]))) { throw "no $($File[$i]) in $Copy" }
}
foreach ($name in $File) {
    $from = Join-Path $Copy $name
    $to = Join-Path $Tree $name
    if (-not $Apply) { "would land $name $(Get-ShortHash $to) -> $(Get-ShortHash $from)"; continue }
    Copy-Item -LiteralPath $from $to -Force
    "landed $name $(Get-ShortHash $to)"
}
if (-not $Apply) { 'dry run; pass -Apply to write the tree' }
