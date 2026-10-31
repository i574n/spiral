param(
    [Parameter(Mandatory)] [string] $A,
    [Parameter(Mandatory)] [string] $B,
    [Parameter(Mandatory)] [string] $Sample,
    [string] $Backend = 'C',
    [int] $Rounds = 5,
    [switch] $Native,
    [double] $QuietCores = 0
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'env.ps1')
. (Join-Path $PSScriptRoot 'heavy.ps1')
$benchStarted = Get-Date
$benchFreeMB = Get-HeavyFreeMB
$dotnet = Resolve-SpiralDotnet
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
$env:SPIRAL_DIAG_QUIET = '1'
$dir = if (Test-Path -LiteralPath $Sample -PathType Container) { $Sample } else { Join-Path $BundleRoot "samples/$Sample" }
$entry = Get-ChildItem $dir -Filter 'main.spi*' | Select-Object -First 1 -ExpandProperty FullName
if (-not $entry) { throw "no main.spi or main.spir in $dir" }
$extension = @{ Fsharp = 'fsx'; C = 'c'; Rust = 'rs'; Delphi = 'pas'; Zig = 'zig'; Lua = 'lua'; Gleam = 'gleam'; TypeScript = 'ts'; Python = 'py' }[$Backend]
if (-not $extension) { throw "bench-pair supports Fsharp, C, Rust, Delphi, Zig, Lua, Gleam, TypeScript and Python" }
if ($Native -and $Backend -ne 'C') { throw '-Native builds and times the program for the C backend only' }
$cc = if ($Native) { (Get-SpiralNativeTools).CC }
if ($Native -and -not $cc) { throw '-Native needs a C compiler (SPIRAL_CC, gcc, clang or cc)' }
$ownShim = Join-Path $dir 'c-shim.h'
$ruleFlags = @()
if ($Native) {
    $matrix = Import-PowerShellDataFile (Join-Path $BundleRoot 'tests/matrix.psd1') -SkipLimitCheck
    $shimDir = (Join-Path $BundleRoot 'tests/native-shims').Replace('\', '/')
    $rule = @($matrix.CFlags) | Where-Object { (Split-Path $dir -Leaf) -like $_.Pattern } | Select-Object -First 1
    if ($rule) { $ruleFlags = $rule.Flags.Replace('{shims}', $shimDir) -split ' ' }
}
$scratch = Join-Path ([IO.Path]::GetTempPath()) "spiral-bench-pair-$PID"
New-Item -ItemType Directory -Force $scratch | Out-Null
function Measure-Compile([string] $dll, [string] $label, [int] $round) {
    $output = Join-Path $scratch "$label-$round.$extension"
    $watch = [Diagnostics.Stopwatch]::StartNew()
    & $dotnet $dll --backend $Backend $entry $output *> $null
    $ms = $watch.ElapsedMilliseconds
    $compileExit = $LASTEXITCODE
    $bytes = if (Test-Path -LiteralPath $output) { (Get-Item -LiteralPath $output).Length } else { -1 }
    $runMs = $null; $runExit = $null
    if ($Native -and $bytes -gt 0) {
        $exe = [IO.Path]::ChangeExtension($output, '.exe')
        $shim = if (Test-Path -LiteralPath $ownShim) { @('-include', $ownShim) } else { @() }
        & $cc -std=c11 -O2 -fwrapv -w @ruleFlags @shim -o $exe $output -lm *> $null
        if ($LASTEXITCODE -eq 0) {
            $runWatch = [Diagnostics.Stopwatch]::StartNew()
            & $exe *> $null
            $runExit = $LASTEXITCODE
            $runMs = $runWatch.ElapsedMilliseconds
        } else { $runExit = 'build-fail' }
    }
    [pscustomobject]@{ Label = $label; Round = $round; Ms = $ms; Exit = $compileExit; Bytes = $bytes; RunMs = $runMs; RunExit = $runExit }
}
function Get-BusyCores {
    $before = @{}
    foreach ($p in Get-Process) { try { $before[$p.Id] = $p.TotalProcessorTime.TotalSeconds } catch {} }
    $watch = [Diagnostics.Stopwatch]::StartNew()
    Start-Sleep -Seconds 2
    $busy = 0.0
    foreach ($p in Get-Process) { try { if ($before.ContainsKey($p.Id) -and $p.Id -ne $PID) { $busy += $p.TotalProcessorTime.TotalSeconds - $before[$p.Id] } } catch {} }
    [math]::Round($busy / $watch.Elapsed.TotalSeconds, 1)
}
try {
    $rows = for ($round = 1; $round -le $Rounds; $round++) {
        $order = if ($round % 2) { @(@('A', $A), @('B', $B)) } else { @(@('B', $B), @('A', $A)) }
        foreach ($pair in $order) {
            $load = if ($QuietCores -gt 0) { Get-BusyCores } else { $null }
            Measure-Compile $pair[1] $pair[0] $round | Add-Member -NotePropertyName Load -NotePropertyValue $load -PassThru
        }
    }
    $median = { param($xs) $s = @($xs | Sort-Object); $s[[int][Math]::Floor(($s.Count - 1) / 2)] }
    $a = & $median ($rows | Where-Object Label -eq 'A' | ForEach-Object Ms)
    $b = & $median ($rows | Where-Object Label -eq 'B' | ForEach-Object Ms)
    $rows | Format-Table -AutoSize | Out-String -Width 120
    "median A $a ms, B $b ms, B/A $([Math]::Round($b / [Math]::Max(1, $a), 3)) ($Rounds rounds, alternating order, fresh process per compile, $Backend, $(Split-Path $dir -Leaf))"
    if ($QuietCores -gt 0) {
        $loudRounds = @($rows | Where-Object { $_.Load -ge $QuietCores } | ForEach-Object Round | Sort-Object -Unique)
        $quiet = @($rows | Where-Object { $loudRounds -notcontains $_.Round })
        $quietRounds = @($quiet | ForEach-Object Round | Sort-Object -Unique).Count
        if ($quietRounds) {
            $qa = & $median ($quiet | Where-Object Label -eq 'A' | ForEach-Object Ms)
            $qb = & $median ($quiet | Where-Object Label -eq 'B' | ForEach-Object Ms)
            "quiet rounds (other load < $QuietCores cores before both compiles): $quietRounds of $Rounds; median A $qa ms, B $qb ms, B/A $([Math]::Round($qb / [Math]::Max(1, $qa), 3))"
        } else { "quiet rounds (other load < $QuietCores cores before both compiles): 0 of $Rounds" }
    }
    $sizes = $rows | Group-Object Label | ForEach-Object { "$($_.Name) $((@($_.Group.Bytes) | Sort-Object -Unique) -join '/') bytes" }
    "outputs: $($sizes -join ', ')"
    $runText = ''
    if ($Native) {
        $runA = & $median ($rows | Where-Object { $_.Label -eq 'A' -and $null -ne $_.RunMs } | ForEach-Object RunMs)
        $runB = & $median ($rows | Where-Object { $_.Label -eq 'B' -and $null -ne $_.RunMs } | ForEach-Object RunMs)
        $exits = $rows | Group-Object Label | ForEach-Object { "$($_.Name) exit $((@($_.Group.RunExit) | Sort-Object -Unique) -join '/')" }
        $runText = "; run A $runA ms B $runB ms ($($exits -join ', '))"
        "native run: median A $runA ms, B $runB ms; $($exits -join ', ')"
    }
    $ratio = [Math]::Round($b / [Math]::Max(1, $a), 3)
    $benchCommand = [scriptblock]::Create("bench-pair.ps1 -A '$A' -B '$B' -Sample '$Sample' -Backend $Backend -Rounds $Rounds$(if ($Native) { ' -Native' })")
    Write-RunLedger 'bench' "bench-pair $(Split-Path $dir -Leaf) $Backend A $a ms B $b ms B/A $ratio$runText" $benchCommand $benchStarted $benchStarted '-' "B/A $ratio; sizes $($sizes -join ', ')$runText" $benchFreeMB
} finally {
    Remove-Item -LiteralPath $scratch -Recurse -Force -ErrorAction SilentlyContinue
}
