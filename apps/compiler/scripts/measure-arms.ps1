param(
    [Parameter(Mandatory)] [string[]] $Arms,
    [string] $Reference,
    [string] $Entry = (Join-Path (Split-Path (Split-Path (Split-Path $PSScriptRoot))) 'apps\spiral\spiral.spi'),
    [string] $Backend = 'Fsharp',
    [int] $Rounds = 5,
    [string] $GcServer = '0',
    [string] $Out = (Join-Path ([IO.Path]::GetTempPath()) "spiral-arms-$PID"),
    [switch] $Trace
)
$ErrorActionPreference = 'Stop'
$Arms = @($Arms | ForEach-Object { $_ -split ';' } | Where-Object { $_ })
. (Join-Path $PSScriptRoot '..\scripts\env.ps1')
. (Join-Path $PSScriptRoot '..\scripts\tree-cpu.ps1')
$dotnet = Resolve-SpiralDotnet
New-Item -ItemType Directory -Force $Out | Out-Null
$extension = @{ Fsharp = 'fsx'; C = 'c'; Rust = 'rs' }[$Backend]
if (-not $extension) { $extension = 'out' }

$baseEnvironment = @{ SPIRAL_COMPILER_PACKAGE_DIR = (Get-SpiralPackageDir); SPIRAL_COMPILER_DLL = $null; SPIRAL_BIN_CACHE_DIR = $null; DOTNET_gcServer = $(if ($GcServer) { $GcServer } else { $null }) }
foreach ($name in [Environment]::GetEnvironmentVariables('Process').Keys) { if ($name -like 'SPIRAL_HOPACSOTA_*') { $baseEnvironment[$name] = $null } }
$parsed = [ordered]@{}
foreach ($arm in $Arms) {
    $label, $rest = $arm -split '=', 2
    $dll, $settings = $rest -split '\|', 2
    if (-not (Test-Path -LiteralPath $dll)) { throw "arm $label has no compiler at $dll" }
    $environment = $baseEnvironment.Clone()
    if ($settings) { foreach ($pair in $settings -split ',') { $k, $v = $pair -split '=', 2; $environment[$k] = $v } }
    $parsed[$label] = [pscustomobject]@{ Dll = (Resolve-Path -LiteralPath $dll).Path; Environment = $environment; Settings = $settings }
}
if (-not $Reference) { $Reference = @($parsed.Keys)[0] }
"entry $Entry backend $Backend rounds $Rounds gcServer '$GcServer' reference $Reference"
foreach ($label in $parsed.Keys) { "arm {0}: {1} {2}" -f $label, (Get-FileHash (Join-Path (Split-Path $parsed[$label].Dll) 'SpiralCompilerCore.dll')).Hash.Substring(0, 16), $parsed[$label].Settings }

function Read-HopacsotaTrace([string] $path) {
    if (-not (Test-Path -LiteralPath $path)) { return $null }
    $freq = 0.0; $samples = [Collections.Generic.List[long[]]]::new()
    foreach ($line in [IO.File]::ReadLines($path)) {
        $p = $line.Split([char[]] ' ', [StringSplitOptions]::RemoveEmptyEntries)
        if ($p.Count -ge 2 -and $p[0] -eq 'freq') { $freq = [double]$p[1] }
        elseif ($p.Count -ge 7) { $samples.Add([long[]] @([long]$p[0], [long]$p[3])) }
    }
    $bodyThreads = 0; $bridgeBodies = 0.0; $wait = 0.0; $decide = 0.0; $split = $false
    if (Test-Path -LiteralPath "$path.bridges") {
        foreach ($line in [IO.File]::ReadLines("$path.bridges")) {
            $v = @($line.Split([char[]] ' ', [StringSplitOptions]::RemoveEmptyEntries) | ForEach-Object { [double]$_ })
            if ($v.Count -lt 6 -or $v[0] -eq 0) { continue }
            $bodyThreads++; $bridgeBodies += $v[2] / $freq
            if ($v.Count -ge 8) { $split = $true; $wait += $v[6] / $freq; $decide += $v[7] / $freq }
        }
    }
    $held = 0.0
    for ($i = 0; $i + 1 -lt $samples.Count; $i++) { $held += [Math]::Max(0, $bodyThreads - $samples[$i][1]) * ($samples[$i + 1][0] - $samples[$i][0]) / $freq }
    $waits = $null
    if (Test-Path -LiteralPath "$path.waits") { $waits = 0.0; foreach ($line in [IO.File]::ReadLines("$path.waits")) { $p = $line.Split(' ', 5); if ($p.Count -ge 4) { $waits += [double]$p[3] / $freq } } }
    [pscustomobject]@{
        WaitsS = $(if ($null -ne $waits) { [Math]::Round($waits, 1) })
        ReachingS = $(if ($split) { [Math]::Round($bridgeBodies - $wait - $decide, 1) })
        BridgeShare = $(if ($held -gt 0) { [Math]::Round($bridgeBodies / $held, 3) })
    }
}

$names = @($parsed.Keys)
$rows = [Collections.Generic.List[object]]::new()
for ($round = 1; $round -le $Rounds; $round++) {
    $shift = ($round - 1) % $names.Count
    $order = @($names[$shift..($names.Count - 1)]) + @(if ($shift) { $names[0..($shift - 1)] })
    foreach ($label in $order) {
        $output = Join-Path $Out "$label-$round.$extension"
        $log = Join-Path $Out "$label-$round.log"
        $environment = $parsed[$label].Environment.Clone()
        $tracePath = Join-Path $Out "$label-$round.trace"
        if ($Trace) { $environment['SPIRAL_HOPACSOTA_TRACE'] = $tracePath; $environment['SPIRAL_HOPACSOTA_STATS'] = '1' }
        $m = Measure-TreeCpu $dotnet @($parsed[$label].Dll, '--backend', $Backend, $Entry, $output) $environment $log
        $hash = if (Test-Path $output) { (Get-FileHash $output).Hash.Substring(0, 16) } else { 'none' }
        $stats = Select-String -Path $log -Pattern 'hopacsota engine: (.*)' | Select-Object -First 1 | ForEach-Object { $_.Matches[0].Groups[1].Value }
        $restart = [bool](Select-String -Path $log -Pattern 'restarting the build in canonical' -Quiet)
        $t = if ($Trace) { Read-HopacsotaTrace $tracePath }
        $row = [pscustomobject]@{ Round = $round; Arm = $label; WallS = $m.WallS; CpuS = $m.CpuS; LoadPct = $m.LoadPct; Exit = $m.Exit; Output = $hash; Restart = $restart; WaitsS = $(if ($t) { $t.WaitsS }); ReachingS = $(if ($t) { $t.ReachingS }); BridgeShare = $(if ($t) { $t.BridgeShare }); Stats = $stats }
        $rows.Add($row)
        "round {0} {1,-12} wall {2,7}s cpu {3,7}s load {4,3}% exit {5} out {6}{7}{8}" -f $round, $label, $m.WallS, $m.CpuS, $m.LoadPct, $m.Exit, $hash, $(if ($restart) { ' RESTART' } else { '' }), $(if ($t) { " waits $($t.WaitsS)s reaching $($t.ReachingS)s bridge-share $($t.BridgeShare)" } else { '' })
    }
}
$median = { param($xs) $s = @($xs | Sort-Object); if ($s.Count) { $s[[int][Math]::Floor(($s.Count - 1) / 2)] } else { $null } }
$referenceOutputs = @($rows | Where-Object Arm -eq $Reference | ForEach-Object Output | Sort-Object -Unique)
"--- summary (median of $Rounds; ratio = arm wall / $Reference wall in the same round)"
foreach ($label in $names) {
    $mine = @($rows | Where-Object Arm -eq $label)
    $ratios = foreach ($r in $mine) { $ref = $rows | Where-Object { $_.Arm -eq $Reference -and $_.Round -eq $r.Round } | Select-Object -First 1; if ($ref -and $ref.WallS -gt 0) { $r.WallS / $ref.WallS } }
    $outputs = @($mine | ForEach-Object Output | Sort-Object -Unique)
    $agrees = @($outputs | Where-Object { $_ -notin $referenceOutputs }).Count -eq 0 -and $referenceOutputs.Count -eq 1
    "{0,-12} wall {1,7}s cpu {2,7}s ratio {3,5:N2} (min {4:N2} max {5:N2}) exits {6} outputs {7} {8}" -f $label, (& $median ($mine | ForEach-Object WallS)), (& $median ($mine | ForEach-Object CpuS)), (& $median $ratios), (($ratios | Measure-Object -Minimum).Minimum), (($ratios | Measure-Object -Maximum).Maximum), (($mine | ForEach-Object Exit | Sort-Object -Unique) -join ','), ($outputs -join ','), $(if ($agrees) { 'SAME as reference' } else { 'DIFFERS' })
    if ($Trace) { "             trace medians: waits {0}s reaching {1}s bridge-share {2}; canonical restarts {3}" -f (& $median ($mine | ForEach-Object WaitsS)), (& $median ($mine | ForEach-Object ReachingS)), (& $median ($mine | ForEach-Object BridgeShare)), @($mine | Where-Object Restart).Count }
    $mine | Where-Object Stats | Select-Object -First 1 | ForEach-Object { "             stats: $($_.Stats)" }
}
$rows | Export-Csv -NoTypeInformation -Delimiter "`t" (Join-Path $Out 'rows.tsv')
"rows: $(Join-Path $Out 'rows.tsv')"
