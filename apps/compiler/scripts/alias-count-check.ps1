param(
    [Parameter(Mandatory)] [string] $A,
    [Parameter(Mandatory)] [string] $B
)
$ErrorActionPreference = 'Stop'
function Aliases([string] $f) {
    Get-Content -LiteralPath $f | Where-Object { $_ -match '^type \S+ = ' } | ForEach-Object { ($_ -split '\s+')[1] }
}
$aa = @(Aliases $A); $bb = @(Aliases $B)
$diff = Compare-Object ($aa | Sort-Object) ($bb | Sort-Object)
"A ($([IO.Path]::GetFileName($A))): $($aa.Count) alias decls, $(($aa | Sort-Object -Unique).Count) distinct"
"B ($([IO.Path]::GetFileName($B))): $($bb.Count) alias decls, $(($bb | Sort-Object -Unique).Count) distinct"
"dup aliases in A (count>1): $(@($aa | Group-Object | Where-Object Count -gt 1).Count); in B: $(@($bb | Group-Object | Where-Object Count -gt 1).Count)"
if (@($diff).Count -eq 0) { "GREEN: identical type-alias multiset (reorder-only is allowed; no drop/dup)"; exit 0 }
"RED: $(@($diff).Count) multiset difference(s):"
$diff | ForEach-Object { "  {0} {1}" -f $_.SideIndicator, $_.InputObject }
exit 1
