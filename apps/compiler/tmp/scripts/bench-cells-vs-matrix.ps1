param(
    [int] $Rounds = 5,
    [string] $Families = (Join-Path $PSScriptRoot '..\tests\families'),
    [string] $Out = (Join-Path $env:LOCALAPPDATA "spiral-bin\runs\bench-cells-vs-matrix-$(Get-Date -Format yyyyMMdd-HHmmss)"),
    [double] $Threshold = 2.0,
    [int] $MinFreeMB = 1536,
    [ValidateSet('process', 'private-daemon')] [string] $CellsCompiler = 'process'
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'tree-cpu.ps1')
$Families = (Resolve-Path $Families).Path
$familyFiles = @(Get-ChildItem $Families -Filter '*_family.spi' | Where-Object { (Get-Content (Join-Path $Families 'package.spiproj') -Raw) -match "(?m)^\s+$($_.BaseName)\s*$" } | ForEach-Object Name)
$samples = @(foreach ($f in $familyFiles) { [regex]::Matches((Get-Content (Join-Path $Families $f) -Raw), 'failwith "([^"]+)"') | ForEach-Object { $_.Groups[1].Value } }) | Sort-Object -Unique
if (-not $samples) { throw "no samples named by failwith in $Families" }
$filter = '^samples/(' + (($samples | ForEach-Object { [regex]::Escape($_) }) -join '|') + ')$'
New-Item -ItemType Directory -Force $Out | Out-Null
"bench: $($familyFiles.Count) family files, $($samples.Count) samples, $Rounds rounds, threshold $Threshold; out $Out"

function Measure-Side([string] $Side, [int] $Round, [string[]] $ArgList, [hashtable] $Environment) {
    $log = Join-Path $Out "round$Round-$Side.log"
    $job = [TreeCpu]::Create()
    $start = [Diagnostics.ProcessStartInfo]::new('pwsh')
    foreach ($a in $ArgList) { $start.ArgumentList.Add($a) }
    $start.UseShellExecute = $false
    $start.RedirectStandardOutput = $true
    $start.RedirectStandardError = $true
    foreach ($k in $Environment.Keys) { $start.Environment[$k] = $Environment[$k] }
    $clock = [Diagnostics.Stopwatch]::StartNew()
    $process = [Diagnostics.Process]::Start($start)
    [void][TreeCpu]::Assign($job, $process.Handle)
    $stdout = $process.StandardOutput.ReadToEndAsync()
    $stderr = $process.StandardError.ReadToEndAsync()
    $loads = [Collections.Generic.List[int]]::new()
    while (-not $process.WaitForExit(10000)) { $loads.Add([int](Get-CimInstance Win32_Processor | Measure-Object LoadPercentage -Average).Average) }
    $process.WaitForExit()
    $clock.Stop()
    $cpu = [TreeCpu]::Query($job)
    [TreeCpu]::Close($job)
    [IO.File]::WriteAllText($log, $stdout.Result + "`n--- stderr`n" + $stderr.Result)
    [pscustomobject]@{
        Round = $Round; Side = $Side; Exit = $process.ExitCode
        CpuS = [math]::Round($cpu[0], 1); Processes = [int]$cpu[1]; WallS = [math]::Round($clock.Elapsed.TotalSeconds, 1)
        LoadPct = if ($loads.Count) { [int]($loads | Measure-Object -Average).Average } else { -1 }
    }
}

$scripts = $PSScriptRoot
$daemonSide = Join-Path $Out 'cells-private-daemon.ps1'
[IO.File]::WriteAllText($daemonSide, @'
param([int] $Port, [string] $TestBlocks, [string] $Lib, [string] $Files, [string] $Out)
$ErrorActionPreference = 'Stop'
$env:PATH = "$HOME\scoop\apps\erlang\current\bin;$HOME\scoop\apps\elixir\current\bin;$env:PATH"
$env:SPIRAL_CELLS_COMPILER_PORT = "$Port"
$env:SPIRAL_CELLS_DAEMON_OWNER = "bench-cells-vs-matrix private daemon port $Port"
$daemon = Start-Process -FilePath 'cmd.exe' -ArgumentList '/d', '/c', 'mix spiral.compiler_daemon' -WorkingDirectory 'C:\home\git\spiral\apps\cells' -PassThru -NoNewWindow
$deadline = (Get-Date).AddMinutes(10)
$up = $false
while (-not $up -and (Get-Date) -lt $deadline -and -not $daemon.HasExited) {
    try { $c = [Net.Sockets.TcpClient]::new('127.0.0.1', $Port); $c.Close(); $up = $true } catch { Start-Sleep -Seconds 2 }
}
if (-not $up) { if (-not $daemon.HasExited) { taskkill /T /F /PID $daemon.Id | Out-Null }; Write-Host "private daemon on port $Port never listened"; exit 3 }
Write-Host "private daemon pid $($daemon.Id) listening on $Port"
pwsh -NoProfile -File $TestBlocks -Lib $Lib -Files $Files -Out $Out -Compiler daemon
$code = $LASTEXITCODE
if (-not $daemon.HasExited) { taskkill /T /F /PID $daemon.Id | Out-Null }
Push-Location 'C:\home\git\spiral\apps\cells'
$listed = @(mix spiral.compiler_daemon --list 2>$null | Where-Object { $_ -match '^\d+\t\d+\t' })
Pop-Location
foreach ($row in $listed) {
    $cols = $row -split "`t"
    if ([int]$cols[0] -ge $Port -and [int]$cols[0] -lt $Port + 100) { taskkill /T /F /PID ([int]$cols[1]) | Out-Null; Write-Host "stopped pool daemon port $($cols[0]) pid $($cols[1])" }
}
exit $code
'@)
$matrixArgs = @('-NoProfile', '-File', (Join-Path $scripts 'test.ps1'), '-Mode', 'single-flight', '-Suite', 'all', '-Filter', $filter, '-Backend', 'C,Zig', '-Native')
$rows = foreach ($round in 1..$Rounds) {
    $freeMB = [int]((Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory / 1KB)
    if ($freeMB -lt $MinFreeMB) {
        [pscustomobject]@{ Round = $round; Side = 'void'; Exit = -1; CpuS = 0; Processes = 0; WallS = 0; LoadPct = -1 }
        Write-Host "round $round VOID: $freeMB MB free < $MinFreeMB"
        continue
    }
    $cellsOut = Join-Path $Out "round$round-cells"
    $snap = Join-Path $Out "round$round-tree"
    $spiralRoot = (Resolve-Path (Join-Path $scripts '..\..\..\..')).Path
    robocopy (Join-Path $spiralRoot 'lib\spiral') (Join-Path $snap 'lib\spiral') /E /XD target _build .cache node_modules /NFL /NDL /NJH /NJS /NP | Out-Null
    robocopy (Join-Path $spiralRoot 'apps\compiler\tmp\samples\core') (Join-Path $snap 'apps\compiler\tmp\samples\core') /E /NFL /NDL /NJH /NJS /NP | Out-Null
    robocopy $Families (Join-Path $snap 'apps\compiler\tmp\tests\families') /E /NFL /NDL /NJH /NJS /NP | Out-Null
    $roundFamilies = Join-Path $snap 'apps\compiler\tmp\tests\families'
    Write-Host "round $round lib snapshot: $(@(Get-ChildItem (Join-Path $snap 'lib\spiral') -Recurse -File).Count) files at $snap"
    $cellsArgs = if ($CellsCompiler -eq 'process') {
        @('-NoProfile', '-File', (Join-Path $scripts 'test-blocks.ps1'), '-Lib', $roundFamilies, '-Files', ($familyFiles -join ','), '-Out', $cellsOut, '-Compiler', 'process')
    } else {
        @('-NoProfile', '-File', $daemonSide, '-Port', "$(14000 + 100 * $round)", '-TestBlocks', (Join-Path $scripts 'test-blocks.ps1'), '-Lib', $roundFamilies, '-Files', ($familyFiles -join ','), '-Out', $cellsOut)
    }
    $order = if ($round % 2) { @('matrix', 'cells') } else { @('cells', 'matrix') }
    foreach ($side in $order) {
        $r = if ($side -eq 'matrix') { Measure-Side 'matrix' $round $matrixArgs @{} } else { Measure-Side 'cells' $round $cellsArgs @{ SPIRAL_CELLS_MEMO = '0'; SPIRAL_CELLS_COMPILER = $(if ($CellsCompiler -eq 'process') { 'process' } else { 'daemon' }); SPIRAL_COMPILER_PACKAGE_DIR = (Join-Path $spiralRoot 'deps\The-Spiral-Language\VS Code Plugin') } }
        $r
        Write-Host "$(Get-Date -Format 'HH:mm') round $round $side`: cpu $($r.CpuS) s over $($r.Processes) processes, wall $($r.WallS) s, box load $($r.LoadPct)%, exit $($r.Exit)"
    }
}
$measured = @($rows | Where-Object { $_ -is [pscustomobject] })
$measured | Export-Csv (Join-Path $Out 'rounds.tsv') -Delimiter "`t" -NoTypeInformation -UseQuotes Never
$ratios = @(foreach ($round in 1..$Rounds) {
    $m = $measured | Where-Object { $_.Round -eq $round -and $_.Side -eq 'matrix' }
    $c = $measured | Where-Object { $_.Round -eq $round -and $_.Side -eq 'cells' }
    if ($m -and $c -and $m.CpuS -gt 0 -and $m.Exit -eq 0 -and $c.Exit -eq 0) { [pscustomobject]@{ Round = $round; Cpu = $c.CpuS / $m.CpuS; Wall = $c.WallS / [Math]::Max(0.1, $m.WallS) } }
})
$phases = @{}
foreach ($nb in Get-ChildItem $Out -Recurse -Filter '*.ipynb' -ErrorAction Ignore) {
    foreach ($cell in (Get-Content $nb.FullName -Raw | ConvertFrom-Json).cells) {
        $p = $cell.metadata.phases_ms
        if (-not $p) { continue }
        foreach ($prop in $p.PSObject.Properties) { $phases[$prop.Name] = [long]$phases[$prop.Name] + [long]$prop.Value }
    }
}
if ($phases.Count) { 'cells phase totals over all rounds (ms): ' + (($phases.GetEnumerator() | Sort-Object Value -Descending | ForEach-Object { "$($_.Key) $($_.Value)" }) -join ', ') }
if ($ratios.Count -eq 0) { 'VERDICT VOID (no round where both sides exited 0)'; return }
$sorted = @($ratios.Cpu | Sort-Object)
$median = if ($sorted.Count % 2) { $sorted[[int][Math]::Floor($sorted.Count / 2)] } else { ($sorted[$sorted.Count / 2 - 1] + $sorted[$sorted.Count / 2]) / 2 }
$wallSorted = @($ratios.Wall | Sort-Object)
$wallMedian = $wallSorted[[int][Math]::Floor($wallSorted.Count / 2)]
'per-round cpu ratio cells/matrix: ' + (($ratios | ForEach-Object { '{0}:{1:N2}' -f $_.Round, $_.Cpu }) -join ' ')
'median cpu ratio {0:N2} over {1} rounds (wall ratio median {2:N2}, reported only)' -f $median, $ratios.Count, $wallMedian
"VERDICT $(if ($median -le $Threshold) { 'GREEN' } else { 'RED' }) (rule SAMPLES-TO-TEST-BLOCKS n27: the migration resumes iff the median per-round CPU ratio is <= $Threshold)"
