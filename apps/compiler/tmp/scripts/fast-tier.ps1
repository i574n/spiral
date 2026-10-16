param(
    [ValidateSet('single-flight', 'sf', 'gpt5parallel', 'gp', 'hopacsota', 'hs')][string]$Mode = 'single-flight',
    [int]$BudgetSeconds = 0,
    [string]$ListPath
)
. $PSScriptRoot/env.ps1

function Get-SpiralSampleFamily([string]$Id) {
    $name = ($Id -replace '^samples/', '').Split('/')[0]
    $underscore = $name.IndexOf('_')
    if ($underscore -gt 0) { $name.Substring(0, $underscore) } else { $name }
}

function Get-SpiralRunHistoryDirs([string]$Mode) {
    $prefixes = switch (ConvertTo-SpiralMode $Mode) { 'gpt5parallel' { 'gpt5parallel-', 'hopac-' } 'hopacsota' { , 'hopacsota-' } default { , 'single-flight-' } }
    $runsRoot = Join-Path (Get-SpiralCacheDir) 'runs'
    if (-not (Test-Path $runsRoot)) { return @() }
    @(Get-ChildItem $runsRoot -Directory | Where-Object {
            $name = $_.Name
            ($prefixes | Where-Object { $name.StartsWith($_) }) -and (Test-Path (Join-Path $_.FullName 'results.tsv')) } |
        Sort-Object { $_.Name -replace '^.*-(\d{8}-\d{6})$', '$1' })
}

class SpiralRowHistory {
    [string]$Id
    [string]$Backend
    [int]$Runs
    [int]$Changes
    [int]$Flips
    [string]$Compile = ''
    [string]$Residual = ''
    [string]$NativeOutcome = ''
    [string]$FlipHistory = ''
    [Collections.Generic.List[double]]$Costs = [Collections.Generic.List[double]]::new()
}

function Get-SpiralColumnIndex([string[]]$Header, [string]$Name) { [Array]::IndexOf($Header, $Name) }

function Get-SpiralRowHistory([string]$Mode, [double]$MaxTimeoutShare, [int]$RecentCostRuns) {
    $rows = [Collections.Generic.Dictionary[string, SpiralRowHistory]]::new()
    $minedRuns = 0
    $timeoutHeavyRuns = 0
    $largestRun = 0
    $reference = $null
    foreach ($run in Get-SpiralRunHistoryDirs $Mode) {
        $lines = [IO.File]::ReadAllLines((Join-Path $run.FullName 'results.tsv'))
        if ($lines.Count -lt 2) { continue }
        $header = $lines[0].Split("`t")
        $idAt = Get-SpiralColumnIndex $header 'id'
        $backendAt = Get-SpiralColumnIndex $header 'backend'
        $compileAt = Get-SpiralColumnIndex $header 'compile'
        $residualAt = Get-SpiralColumnIndex $header 'residual'
        $nativeAt = Get-SpiralColumnIndex $header 'native'
        $exitAt = Get-SpiralColumnIndex $header 'exit'
        $oracleAt = Get-SpiralColumnIndex $header 'oracle'
        $compileMsAt = Get-SpiralColumnIndex $header 'compile_ms'
        $nativeMsAt = Get-SpiralColumnIndex $header 'native_ms'
        if ($idAt -lt 0 -or $backendAt -lt 0 -or $compileAt -lt 0) { continue }
        $width = (@($idAt, $backendAt, $compileAt, $residualAt, $nativeAt, $exitAt, $oracleAt, $compileMsAt, $nativeMsAt) | Measure-Object -Maximum).Maximum
        $parsed = [Collections.Generic.List[string[]]]::new()
        $timeouts = 0
        for ($l = 1; $l -lt $lines.Count; $l++) {
            $f = $lines[$l].Split("`t")
            if ($f.Count -le $width) { continue }
            $parsed.Add($f)
            if ($f[$compileAt] -eq 'timeout') { $timeouts++ }
        }
        if ($parsed.Count -eq 0) { continue }
        if ($parsed.Count -ge 50 -and $timeouts / $parsed.Count -gt $MaxTimeoutShare) { $timeoutHeavyRuns++; continue }
        $minedRuns++
        $selectedRun = Test-Path (Join-Path $run.FullName 'fast-tier.tsv')
        $runKeys = [Collections.Generic.List[string]]::new($parsed.Count)
        foreach ($f in $parsed) {
            $id = $f[$idAt]
            if ($id.StartsWith('examples/')) { $id = 'samples/' + $id.Substring(9) }
            $key = $id + '|' + $f[$backendAt]
            $runKeys.Add($key)
            $compile = $f[$compileAt]
            $residual = if ($residualAt -ge 0) { $f[$residualAt] } else { '' }
            $nativeOutcome = if ($nativeAt -ge 0 -and $f[$nativeAt]) { $f[$nativeAt] + '|' + $f[$exitAt] + '|' + $f[$oracleAt] } else { '' }
            $compileMs = 0.0
            $nativeMs = 0.0
            if ($compileMsAt -ge 0) { [void][double]::TryParse($f[$compileMsAt], [ref]$compileMs) }
            if ($nativeMsAt -ge 0) { [void][double]::TryParse($f[$nativeMsAt], [ref]$nativeMs) }
            $row = $null
            if (-not $rows.TryGetValue($key, [ref]$row)) {
                $row = [SpiralRowHistory]@{ Id = $id; Backend = $f[$backendAt] }
                $rows[$key] = $row
            }
            if ($row.Runs -gt 0 -and -not $selectedRun) {
                if ($residual -and $row.Residual -and $residual -ne $row.Residual) { $row.Changes++ }
                if ($compile -ne $row.Compile -or ($nativeOutcome -and $row.NativeOutcome -and $nativeOutcome -ne $row.NativeOutcome)) { $row.Flips++; $row.FlipHistory += "$minedRuns," }
            }
            $row.Runs++
            $row.Compile = $compile
            if ($residual) { $row.Residual = $residual }
            if ($nativeOutcome) { $row.NativeOutcome = $nativeOutcome }
            $row.Costs.Add(($compileMs + $nativeMs) / 1000.0)
            if ($row.Costs.Count -gt $RecentCostRuns) { $row.Costs.RemoveAt(0) }
        }
        $largestRun = [Math]::Max($largestRun, $runKeys.Count)
        if ($runKeys.Count -ge 0.95 * $largestRun) { $reference = [pscustomobject]@{ Name = $run.Name; Keys = $runKeys } }
    }
    [pscustomobject]@{ Rows = $rows; MinedRuns = $minedRuns; Reference = $reference; TimeoutHeavyRuns = $timeoutHeavyRuns }
}

function Get-SpiralMedian([Collections.Generic.List[double]]$Values) {
    if ($Values.Count -eq 0) { return 0.0 }
    $sorted = @($Values | Sort-Object)
    $middle = [Math]::Floor($sorted.Count / 2)
    if ($sorted.Count % 2) { $sorted[$middle] } else { ($sorted[$middle - 1] + $sorted[$middle]) / 2 }
}

function Get-SpiralFastTier([string]$Mode = 'single-flight', [hashtable]$Policy) {
    $budget = [double]$Policy.BudgetSeconds
    $history = Get-SpiralRowHistory $Mode ([double]$Policy.MaxTimeoutShare) ([int]$Policy.RecentCostRuns)
    if (-not $history.Reference) { throw "no $Mode run history under $(Join-Path (Get-SpiralCacheDir) 'runs'): run a full suite first" }
    $reference = $history.Reference
    $current = foreach ($key in ($reference.Keys | Sort-Object -Unique)) {
        $row = $history.Rows[$key]
        [pscustomobject]@{ Key = $key; Id = $row.Id; Backend = $row.Backend; Family = Get-SpiralSampleFamily $row.Id; Runs = $row.Runs
            Changes = $row.Changes; FlipHistory = $row.FlipHistory; Signal = $row.Changes + 2 * $row.Flips; Cost = Get-SpiralMedian $row.Costs; Young = $row.Runs -lt [int]$Policy.MatureRuns }
    }
    $current = @($current)
    $byKey = @{}
    foreach ($row in $current) { $byKey[$row.Key] = $row }
    $chosen = [Collections.Generic.Dictionary[string, object]]::new()
    $tally = [pscustomobject]@{ Seconds = 0.0 }
    $withOracle = {
        param($row)
        $oracleKey = "$($row.Id)|C"
        if ($row.Backend -notin 'C', 'Fsharp' -and $byKey.ContainsKey($oracleKey)) { $row, $byKey[$oracleKey] } else { , $row }
    }
    $addedCost = { param($row) (& $withOracle $row | Where-Object { -not $chosen.ContainsKey($_.Key) } | Measure-Object Cost -Sum).Sum }
    $coveredFlipHistories = [Collections.Generic.HashSet[string]]::new()
    $choose = {
        param($row)
        foreach ($member in & $withOracle $row) {
            if (-not $chosen.ContainsKey($member.Key)) { $chosen[$member.Key] = $member; $tally.Seconds += $member.Cost }
            if ($member.FlipHistory) { [void]$coveredFlipHistories.Add($member.FlipHistory) }
        }
    }
    $flipTwin = { param($row) $row.FlipHistory -and $row.Changes -eq 0 -and $coveredFlipHistories.Contains($row.FlipHistory) }
    $needBackend = [Collections.Generic.HashSet[string]]::new([string[]]@($current.Backend | Sort-Object -Unique))
    $needFamily = [Collections.Generic.HashSet[string]]::new([string[]]@($current.Family | Sort-Object -Unique))
    foreach ($row in $current | Sort-Object Cost, @{ Expression = 'Signal'; Descending = $true }) {
        if ($needBackend.Contains($row.Backend) -or $needFamily.Contains($row.Family)) {
            & $choose $row
            [void]$needBackend.Remove($row.Backend)
            [void]$needFamily.Remove($row.Family)
        }
    }
    foreach ($row in $current | Where-Object Young | Sort-Object Cost) { & $choose $row }
    foreach ($row in $current | Where-Object FlipHistory | Sort-Object Cost) {
        if ($coveredFlipHistories.Contains($row.FlipHistory) -or $tally.Seconds + (& $addedCost $row) -gt $budget) { continue }
        & $choose $row
    }
    foreach ($row in $current | Sort-Object { - ($_.Signal + 0.01) / ($_.Cost + 0.05) }) {
        if ($row.Signal -le 0 -or $chosen.ContainsKey($row.Key) -or (& $flipTwin $row) -or $tally.Seconds + (& $addedCost $row) -gt $budget) { continue }
        & $choose $row
    }
    $allSignal = ($current | Measure-Object Signal -Sum).Sum
    $allCost = ($current | Measure-Object Cost -Sum).Sum
    $picked = @($chosen.Values)
    [pscustomobject]@{
        Keys = [Collections.Generic.HashSet[string]]::new([string[]]@($picked.Key))
        Rows = $picked
        Current = $current
        Reference = $reference.Name
        ReferenceRows = $current.Count
        HistoryRuns = $history.MinedRuns
        TimeoutHeavyRuns = $history.TimeoutHeavyRuns
        CostSeconds = $tally.Seconds
        AllCostSeconds = $allCost
        Signal = ($picked | Measure-Object Signal -Sum).Sum
        AllSignal = $allSignal
        Young = @($picked | Where-Object Young).Count
        FlipHistories = @($current | Where-Object FlipHistory | Select-Object -ExpandProperty FlipHistory -Unique).Count
        FlipHistoriesCovered = $coveredFlipHistories.Count
        UncoveredBackends = @($needBackend)
        UncoveredFamilies = @($needFamily)
    }
}

function Format-SpiralFastTier($Tier) {
    '{0} rows of {1} (reference {2}, {3} runs mined, {4} timeout-heavy runs skipped): median cost {5:N0} s of {6:N0} s ({7:P1}), signal {8} of {9} ({10:P1}), {11} young rows, {12} of {13} distinct outcome-flip histories' -f
    $Tier.Rows.Count, $Tier.ReferenceRows, $Tier.Reference, $Tier.HistoryRuns, $Tier.TimeoutHeavyRuns, $Tier.CostSeconds, $Tier.AllCostSeconds,
    ($Tier.CostSeconds / [Math]::Max($Tier.AllCostSeconds, 1)), $Tier.Signal, $Tier.AllSignal, ($Tier.Signal / [Math]::Max($Tier.AllSignal, 1)), $Tier.Young, $Tier.FlipHistoriesCovered, $Tier.FlipHistories
}

$policy = (Import-PowerShellDataFile (Join-Path $BundleRoot 'tests/harness.psd1') -SkipLimitCheck).Fast
if ($BudgetSeconds -gt 0) { $policy = $policy.Clone(); $policy.BudgetSeconds = $BudgetSeconds }
$tier = Get-SpiralFastTier $Mode $policy
Format-SpiralFastTier $tier
if ($ListPath) {
    $tierOf = { param($row) if ($tier.Keys.Contains($row.Key)) { 'fast' } else { 'rest' } }
    @("id`tbackend`ttier`truns`tsignal`tcost_s") + @($tier.Current | Sort-Object Id, Backend | ForEach-Object { "$($_.Id)`t$($_.Backend)`t$(& $tierOf $_)`t$($_.Runs)`t$($_.Signal)`t$([Math]::Round($_.Cost, 3))" }) |
        Set-Content -LiteralPath $ListPath
}
