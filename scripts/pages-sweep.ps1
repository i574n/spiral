param([string[]] $Repos = @('alphabet', 'dice', 'spiral', 'polyglot', 'x', 'blog', 'dir-tree-html', 'tibia', 'eoie', '.github'))
$ErrorActionPreference = 'Stop'
$rows = foreach ($repo in $Repos) {
    $url = "https://i574n.github.io/$repo/"
    $pages = ((git ls-remote "https://github.com/i574n/$repo" refs/heads/gh-pages refs/heads/main 2>$null) | ForEach-Object { $sha, $ref = $_ -split "`t"; "$(Split-Path $ref -Leaf)=$($sha.Substring(0, 8))" }) -join ' '
    try {
        $page = Invoke-WebRequest $url -TimeoutSec 30 -SkipHttpErrorCheck
        $html = $page.Content
        [pscustomobject]@{
            repo = $repo
            status = [int]$page.StatusCode
            readme = $html -match 'id="readme"|class="readme'
            viewport = $html -match 'name="viewport"'
            portrait = $html -match '@media \(max-width: 600px\)'
            heads = $pages
        }
    } catch {
        [pscustomobject]@{ repo = $repo; status = -1; readme = $false; viewport = $false; portrait = $false; heads = $pages }
    }
}
$rows | Format-Table -AutoSize | Out-String -Width 120
$failing = @($rows | Where-Object { $_.status -ne 200 -or -not $_.readme -or -not $_.viewport -or -not $_.portrait })
"pages ok: $($rows.Count - $failing.Count) of $($rows.Count)"
if ($failing) { "not yet: $(($failing | ForEach-Object repo) -join ', ')"; exit 1 }
'TREE-PAGES-OK every page is 200 with its README section, a viewport meta and the portrait rules'
