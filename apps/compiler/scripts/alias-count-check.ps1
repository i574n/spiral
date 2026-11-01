param(
    [Parameter(Mandatory)] [string] $A,   # a parallel-policy .fsx output (e.g. w8-cw1-r1.fsx)
    [Parameter(Mandatory)] [string] $B    # the single-flight (or w1) reference .fsx
)
# HOPACSOTA-P2 negative gate (main 19:3x): the FFI/external type-alias declarations must appear EXACTLY the same
# number of times in the parallel output as in single-flight's -- so a reorder is the ONLY allowed difference, and a
# DROP or DUPLICATE (e.g. from UnusedGlobals.prune or a broken key_body merge) fails loudly here instead of surfacing
# only as a bare hash mismatch. GREEN = 0 multiset diffs. Run alongside alternating-ab.ps1 after the fix.
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
