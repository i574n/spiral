param(
    [int] $Runs = 12,
    [int] $Top = 15,
    [string] $Ledger = (Join-Path ($env:LOCALAPPDATA ?? $HOME) 'spiral-bin\ledger\runs.tsv'),
    [string[]] $Notebooks = @()
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'env.ps1')

function Get-Median([double[]] $values) {
    if (-not $values.Count) { return 0 }
    $sorted = @($values | Sort-Object)
    $sorted[[int][Math]::Floor($sorted.Count / 2)]
}

function Get-Field($object, [string] $name) {
    if ($null -eq $object) { return $null }
    $property = $object.PSObject.Properties[$name]
    if ($property) { $property.Value }
}

if (Test-Path $Ledger) {
    $rows = @(Import-Csv $Ledger -Delimiter "`t")
    "== ledger $Ledger ($($rows.Count) runs)"
    $rows | Group-Object kind, label | ForEach-Object {
        $run = @($_.Group | ForEach-Object { [double]$_.run_s })
        $wait = @($_.Group | ForEach-Object { [double]$_.wait_s })
        [pscustomobject]@{
            label = $_.Group[0].label; kind = $_.Group[0].kind; runs = $_.Count
            total_min = [Math]::Round(($run | Measure-Object -Sum).Sum / 60, 1)
            median_s = Get-Median $run; max_s = ($run | Measure-Object -Maximum).Maximum
            wait_min = [Math]::Round(($wait | Measure-Object -Sum).Sum / 60, 1)
            failed = @($_.Group | Where-Object outcome -ne 'ok').Count
        }
    } | Sort-Object total_min -Descending | Select-Object -First $Top | Format-Table -AutoSize | Out-String -Width 200
}

if ($Notebooks) {
    $cells = foreach ($path in $Notebooks) {
        foreach ($file in Get-ChildItem $path -Recurse -Filter '*.ipynb' -File) {
            $doc = Get-Content $file.FullName -Raw | ConvertFrom-Json
            foreach ($cell in $doc.cells) {
                $test = Get-Field (Get-Field $cell 'metadata') 'spiral_test'
                foreach ($t in @(Get-Field $test 'targets' | Where-Object { $_ })) {
                    [pscustomobject]@{ notebook = $file.Name; test = Get-Field $test 'name'; target = Get-Field $t 'target'; ms = [double]('0' + (Get-Field $t 'ms')) }
                }
            }
        }
    }
    "== Kino target cost in $(@($Notebooks).Count) notebook path(s): $(@($cells).Count) test x target runs"
    $cells | Group-Object target | ForEach-Object {
        $ms = @($_.Group | ForEach-Object { $_.ms })
        [pscustomobject]@{ target = $_.Name; runs = $_.Count; total_min = [Math]::Round(($ms | Measure-Object -Sum).Sum / 60000, 1); median_s = [Math]::Round((Get-Median $ms) / 1000, 1); max_s = [Math]::Round(($ms | Measure-Object -Maximum).Maximum / 1000, 1) }
    } | Sort-Object total_min -Descending | Format-Table -AutoSize | Out-String -Width 200
    $cells | Sort-Object ms -Descending | Select-Object -First $Top notebook, test, target, @{ n = 'seconds'; e = { [Math]::Round($_.ms / 1000, 1) } } | Format-Table -AutoSize | Out-String -Width 200
}

$runRoot = Join-Path (Get-SpiralCacheDir) 'runs'
$recent = @(Get-ChildItem $runRoot -Directory | Where-Object { Test-Path (Join-Path $_.FullName 'results.tsv') } | Sort-Object LastWriteTime -Descending | Select-Object -First $Runs)
"== last $($recent.Count) harness runs ($runRoot)"
$recent | ForEach-Object {
    $results = Join-Path $_.FullName 'results.tsv'
    $first = Get-ChildItem $_.FullName -Filter 'worker*.jobs.tsv' | Sort-Object CreationTime | Select-Object -First 1
    $start = if ($first) { $first.CreationTime } else { $_.CreationTime }
    $data = @(Import-Csv $results -Delimiter "`t")
    [pscustomobject]@{
        run = $_.Name; rows = $data.Count
        wall_min = [Math]::Round(((Get-Item $results).LastWriteTime - $start).TotalMinutes, 1)
        compile_min = [Math]::Round(($data | Where-Object detail -notmatch 'compile-reused' | ForEach-Object { [double]('0' + $_.compile_ms) } | Measure-Object -Sum).Sum / 60000, 1)
        compile_reused = @($data | Where-Object detail -match 'compile-reused').Count
        native_min = [Math]::Round(($data | Where-Object detail -notmatch 'native-reused' | ForEach-Object { [double]('0' + $_.native_ms) } | Measure-Object -Sum).Sum / 60000, 1)
        native_reused = @($data | Where-Object detail -match 'native-reused').Count
        backends = @($data | Select-Object -ExpandProperty backend -Unique).Count
    }
} | Format-Table -AutoSize | Out-String -Width 200

$full = $recent | Where-Object { @(Import-Csv (Join-Path $_.FullName 'results.tsv') -Delimiter "`t").Count -ge 5000 } | Select-Object -First 1
if ($full) {
    $data = @(Import-Csv (Join-Path $full.FullName 'results.tsv') -Delimiter "`t")
    "== cost by backend in $($full.Name) (summed row time; workers run in parallel)"
    $data | Group-Object backend | ForEach-Object {
        $c = @($_.Group | ForEach-Object { [double]('0' + $_.compile_ms) }); $n = @($_.Group | ForEach-Object { [double]('0' + $_.native_ms) })
        [pscustomobject]@{
            backend = $_.Name; rows = $_.Count
            compile_min = [Math]::Round(($c | Measure-Object -Sum).Sum / 60000, 1); native_min = [Math]::Round(($n | Measure-Object -Sum).Sum / 60000, 1)
            native_median_ms = Get-Median $n
            agree = @($_.Group | Where-Object oracle -eq 'agree').Count
        }
    } | Sort-Object native_min -Descending | Format-Table -AutoSize | Out-String -Width 200
    $history = @($recent | Where-Object { @(Import-Csv (Join-Path $_.FullName 'results.tsv') -Delimiter "`t").Count -ge 5000 } | Select-Object -First 5)
    if ($history.Count -ge 2) {
        $seen = @{}
        foreach ($run in $history) {
            foreach ($r in Import-Csv (Join-Path $run.FullName 'results.tsv') -Delimiter "`t") {
                $key = "$($r.id)|$($r.backend)"
                $state = "$($r.compile)|$($r.residual)|$($r.native)|$($r.exit)|$($r.stdout)"
                if (-not $seen.ContainsKey($key)) { $seen[$key] = [Collections.Generic.HashSet[string]]::new() }
                [void]$seen[$key].Add($state)
            }
        }
        "== signal over the last $($history.Count) full runs: rows whose compile/residual/native/exit/stdout changed"
        $data | Group-Object backend | ForEach-Object {
            $changed = @($_.Group | Where-Object { $seen["$($_.id)|$($_.backend)"].Count -gt 1 })
            $quiet = @($_.Group | Where-Object { $seen["$($_.id)|$($_.backend)"].Count -le 1 })
            [pscustomobject]@{
                backend = $_.Name; rows = $_.Count; changed = $changed.Count
                quiet_native_min = [Math]::Round(($quiet | ForEach-Object { [double]('0' + $_.native_ms) } | Measure-Object -Sum).Sum / 60000, 1)
                changed_native_min = [Math]::Round(($changed | ForEach-Object { [double]('0' + $_.native_ms) } | Measure-Object -Sum).Sum / 60000, 1)
            }
        } | Sort-Object quiet_native_min -Descending | Format-Table -AutoSize | Out-String -Width 200
    }
    "== slowest $Top rows in $($full.Name) (compile + native)"
    $data | ForEach-Object { [pscustomobject]@{ id = $_.id; backend = $_.backend; total_s = [Math]::Round(([double]('0' + $_.compile_ms) + [double]('0' + $_.native_ms)) / 1000, 1); compile = $_.compile; native = $_.native } } |
        Sort-Object total_s -Descending | Select-Object -First $Top | Format-Table -AutoSize | Out-String -Width 200
}
