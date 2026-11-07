param(
    [Parameter(Mandatory)] [string[]] $Path,
    [string] $Tsv
)
$ErrorActionPreference = 'Stop'
$files = @($Path | ForEach-Object { $_ -split ',' } | Where-Object { $_ } | ForEach-Object {
    if (Test-Path -LiteralPath $_ -PathType Container) { Get-ChildItem -LiteralPath $_ -Recurse -Filter *.spi -File | Where-Object { $_.FullName -notmatch '\\(bench|target|deps)\\' } } else { Get-Item -LiteralPath $_ }
})
function Get-Count([string[]] $lines, [string] $pattern) { (@($lines | Select-String -Pattern $pattern -AllMatches | ForEach-Object { $_.Matches.Count }) | Measure-Object -Sum).Sum }
function Get-Code([string[]] $all) {
    $inTest = $false
    foreach ($line in $all) {
        if ($line -match '^(test|:#)\s') { $inTest = $true; continue }
        if ($inTest -and ($line -eq '' -or $line -match '^\s')) { continue }
        $inTest = $false
        if ($line -match '^\s*//') { continue }
        $line -replace "\$'[^']*'", "`$''" -replace '\$"[^"]*"', '$""'
    }
}
$rows = foreach ($f in $files) {
    $all = [IO.File]::ReadAllLines($f.FullName)
    $code = @(Get-Code $all)
    $n = [Math]::Max(1, $code.Count)
    $heads = for ($i = 0; $i -lt $code.Count; $i++) {
        if ($code[$i] -notmatch '^(:= |:~ )') { continue }
        $h = $code[$i]; $j = $i
        while ($h -notmatch '\s=(\s|$)' -and $j + 1 -lt $code.Count -and $j - $i -lt 8) { $j++; $h += ' ' + $code[$j] }
        ($h -split '\s=(\s|$)')[0]
    }
    $defs = [Math]::Max(1, @($heads).Count)
    $inUnion = $false; $cases = 0; $gadt = 0
    foreach ($line in $code) {
        if ($line -match '^:\| ') { $inUnion = $true; continue }
        if ($line -match '^\S') { $inUnion = $false }
        if ($inUnion -and $line -match '^\s+\| [A-Z]\w*') { $cases++; if ($line -match '::') { $gadt++ } }
    }
    $arms = Get-Count $code '^\s*\|\s+\S.*=>'
    $unions = Get-Count $code '^:\| '
    $nominals = Get-Count $code '^(:!|:==) '
    $macros = ([regex]::Matches(($all -join "`n"), "\$'|\$""")).Count + ([regex]::Matches(($all -join "`n"), '!!!!')).Count
    [pscustomobject][ordered]@{
        File = $f.Name
        Lines = $code.Count
        Defs = @($heads).Count
        Kind = if (1000 * $macros / [Math]::Max(1, $all.Count) -gt 100) { 'ffi' } else { 'model' }
        M1RetAnnotPct = [Math]::Round(100 * @($heads | Where-Object { $_ -match '\)\s*:\s*[^=]+$|\(\)\s*:\s*\S' }).Count / $defs)
        M2BareParamPct = [Math]::Round(100 * @($heads | Where-Object { $_ -match '^(:= |:~ )\^?\s*\S+(\s+[a-z_]\w*)+\s*$' }).Count / $defs)
        M3GadtCasePct = [Math]::Round(100 * $gadt / [Math]::Max(1, $cases))
        M4IndexedUnionPct = [Math]::Round(100 * (Get-Count $code '^:\| (\^ )?\w+ \w') / [Math]::Max(1, $unions))
        M5ExistPerKl = [Math]::Round(1000 * (Get-Count $code '\\\?') / $n, 1)
        M6WildArmPct = [Math]::Round(100 * (Get-Count $code '^\s*\|\s+_(\s*,\s*_)*\s*=>') / [Math]::Max(1, $arms))
        M7StringDispatchPerKl = [Math]::Round(1000 * (Get-Count $code '(\?|\|\?|&&|\|\||<>) *[\w.]+ (=|<>) "[^"]*"') / $n, 1)
        M8SentinelPerKl = [Math]::Round(1000 * (Get-Count $code '(?<![\w.])-1i(32|64)\b') / $n, 1)
        M9BoolOptPerDef = [Math]::Round((Get-Count $code '[:>] *bool\b|\boption\b') / $defs, 2)
        M10MutPerKl = [Math]::Round(1000 * (Get-Count $code '\bmut\b|^\s*[\w.]+ <- ') / $n, 1)
        M11TypesPer100Defs = [Math]::Round(100 * ($unions + $nominals) / $defs)
    }
}
if ($Tsv) { $rows | Export-Csv -LiteralPath $Tsv -Delimiter "`t" -NoTypeInformation }
$rows | Sort-Object Kind, M1RetAnnotPct | Format-Table -AutoSize | Out-String -Width 220
