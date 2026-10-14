param([Parameter(Mandatory)] [string] $File, [int] $Row = 0, [switch] $DryRun, [switch] $ImpactTable)
$ErrorActionPreference = 'Stop'
$lines = [IO.File]::ReadAllLines($File)
$runner = Join-Path $PSScriptRoot '../../kino/spi/run_notebook.ps1'
$output = Join-Path ([IO.Path]::GetTempPath()) ("spiral-zed-" + [IO.Path]::GetFileNameWithoutExtension($File) + ".ipynb")

function Test-StatementLine([string] $Line) { $Line -match '^\S' -and $Line -notmatch '^(//|\(\* )' }

function Remove-LineComment([string] $Line) {
    $inString = $false
    for ($i = 0; $i -lt $Line.Length; $i++) {
        $ch = $Line[$i]
        if ($inString -and $ch -eq '\') { $i++; continue }
        if ($ch -eq '"') { $inString = -not $inString; continue }
        if (-not $inString -and $ch -eq '/' -and $i + 1 -lt $Line.Length -and $Line[$i + 1] -eq '/') { return $Line.Substring(0, $i) }
    }
    $Line
}

function Get-SourceBlocks([string[]] $Lines) {
    $blocks = [Collections.Generic.List[object]]::new()
    $current = $null
    for ($i = 0; $i -lt $Lines.Count; $i++) {
        $line = $Lines[$i]
        if (Test-StatementLine $line) {
            $current = [pscustomobject]@{ Start = $i + 1; CodeEnd = $i + 1; Header = $line; Text = [Text.StringBuilder]::new(); Kind = ''; Names = @(); Operators = @(); Reaches = $null }
            $blocks.Add($current)
        }
        if ($current) {
            $code = Remove-LineComment $line
            if ($code.Trim() -and $line -notmatch '^(//|\(\* )') { $current.CodeEnd = $i + 1 }
            [void]$current.Text.AppendLine($code)
        }
    }
    foreach ($block in $blocks) {
        $header = $block.Header
        switch -regex ($header) {
            '^test\s+([^\s=]+)' { $block.Kind = 'test'; $block.Names = @($Matches[1]); break }
            '^(?:and\s+)?(?:inl|let|inm|inb)(?:\s+rec)?\s+\(([^)\s]+)\)' { $block.Kind = 'definition'; $block.Operators = @($Matches[1]); $block.Names = @("($($Matches[1]))"); break }
            '^(?:and\s+)?(?:inl|let|inm|inb)(?:\s+rec)?\s+([^\s(:=]+)' { $block.Kind = 'definition'; $block.Names = @($Matches[1]); break }
            '^(?:and\s+)?(?:type|union|nominal|prototype)(?:\s+rec)?\s+([^\s=]+)' {
                $block.Kind = 'definition'
                $cases = [regex]::Matches($block.Text.ToString(), "\|\s*([A-Z][A-Za-z0-9_']*)") | ForEach-Object { $_.Groups[1].Value }
                $block.Names = @($Matches[1]) + @($cases)
                break
            }
            '^instance\s+([^\s]+)' { $block.Kind = 'definition'; $block.Names = @($Matches[1]); break }
            default { $block.Kind = 'other' }
        }
    }
    $blocks
}

function Get-Reach($Blocks) {
    $identifier = [regex]"[A-Za-z_][A-Za-z0-9_']*"
    $definedBy = [Collections.Generic.Dictionary[string, Collections.Generic.List[int]]]::new()
    $operators = [Collections.Generic.List[object]]::new()
    $instances = [Collections.Generic.List[int]]::new()
    for ($d = 0; $d -lt $Blocks.Count; $d++) {
        if ($Blocks[$d].Kind -ne 'definition') { continue }
        foreach ($name in $Blocks[$d].Names) {
            if (-not $definedBy.ContainsKey($name)) { $definedBy[$name] = [Collections.Generic.List[int]]::new() }
            $definedBy[$name].Add($d)
        }
        foreach ($operator in $Blocks[$d].Operators) { $operators.Add(@($operator, $d)) }
        if ($Blocks[$d].Header -match '^instance\s') { $instances.Add($d) }
    }
    $direct = @{}
    for ($b = 0; $b -lt $Blocks.Count; $b++) {
        $text = $Blocks[$b].Text.ToString()
        if ($Blocks[$b].Kind -eq 'test') { $text = $text.Substring([Math]::Max(0, $text.IndexOf("`n"))) }
        $found = [Collections.Generic.HashSet[int]]::new()
        foreach ($match in $identifier.Matches($text)) {
            $defining = $null
            if ($definedBy.TryGetValue($match.Value, [ref] $defining)) { foreach ($d in $defining) { if ($d -lt $b) { [void]$found.Add($d) } } }
        }
        foreach ($pair in $operators) { if ($pair[1] -lt $b -and $text.Contains($pair[0])) { [void]$found.Add($pair[1]) } }
        if ($Blocks[$b].Kind -eq 'test') { foreach ($d in $instances) { if ($d -lt $b) { [void]$found.Add($d) } } }
        $direct[$b] = @($found)
    }
    for ($b = 0; $b -lt $Blocks.Count; $b++) {
        $seen = [Collections.Generic.HashSet[int]]::new()
        $queue = [Collections.Generic.Queue[int]]::new()
        foreach ($d in $direct[$b]) { if ($seen.Add($d)) { $queue.Enqueue($d) } }
        while ($queue.Count) { foreach ($d in $direct[$queue.Dequeue()]) { if ($seen.Add($d)) { $queue.Enqueue($d) } } }
        $Blocks[$b].Reaches = $seen
    }
}

function Get-BlockAtRow($Blocks, [string[]] $Lines, [int] $Row) {
    for ($b = 0; $b -lt $Blocks.Count; $b++) {
        $block = $Blocks[$b]
        $nextStart = if ($b + 1 -lt $Blocks.Count) { $Blocks[$b + 1].Start } else { [int]::MaxValue }
        if ($Row -ge $block.Start -and $Row -le $block.CodeEnd) { return $b }
        if ($Row -gt $block.CodeEnd -and $Row -lt $nextStart) {
            if ($nextStart -eq [int]::MaxValue) { return -1 }
            $between = $Lines[($Row - 1)..($nextStart - 2)]
            if (-not @($between | Where-Object { $_.Trim() -and $_ -notmatch '^\s*(//|\(\*)' }).Count) { return $b + 1 }
            return -1
        }
    }
    -1
}

$blocks = @(Get-SourceBlocks $lines)
Get-Reach $blocks
$tests = @(for ($b = 0; $b -lt $blocks.Count; $b++) { if ($blocks[$b].Kind -eq 'test') { $b } })

function Get-ImpactedTests([int] $Definition) {
    @($tests | Where-Object { $blocks[$_].Reaches.Contains($Definition) } | ForEach-Object { $blocks[$_].Names[0] })
}

if ($ImpactTable) {
    for ($b = 0; $b -lt $blocks.Count; $b++) {
        if ($blocks[$b].Kind -ne 'definition') { continue }
        $impacted = Get-ImpactedTests $b
        "{0}`t{1}`t{2}/{3}`t{4}" -f $blocks[$b].Start, $blocks[$b].Names[0], $impacted.Count, $tests.Count, ($impacted -join ',')
    }
    exit 0
}

$selected = @()
if ($Row -gt 0) {
    $at = Get-BlockAtRow $blocks $lines $Row
    if ($at -ge 0 -and $blocks[$at].Kind -eq 'test') { $selected = @('--test', $blocks[$at].Names[0]) }
    elseif ($at -ge 0 -and $blocks[$at].Kind -eq 'definition') {
        $impacted = Get-ImpactedTests $at
        if (-not $impacted.Count) { Write-Host "no test in $File reaches $($blocks[$at].Names[0]) (row $Row); nothing to run"; exit 0 }
        Write-Host "$($impacted.Count) of $($tests.Count) tests reach $($blocks[$at].Names[0]): $($impacted -join ', ')"
        $selected = @('--test', ($impacted -join ','))
    }
    else { Write-Host "row $Row of $File is neither a test nor a definition; running every test in the file" }
}
if ($DryRun) { "run_notebook --path $File --output-path $output --no-html $($selected -join ' ')"; exit 0 }
& pwsh -NoProfile -File $runner --path $File --output-path $output --no-html @selected
exit $LASTEXITCODE
