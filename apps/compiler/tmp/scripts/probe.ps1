# Compile one sample directly, several times if asked, and optionally look inside the compiler while it runs.
# The fast loop for small fixes: one fixture in seconds, no suite, no oracle.
#
#   pwsh scripts/probe.ps1 mega_brzozowski_derivatives/negative_antimirov_slot_shape -Repeat 5   # races
#   pwsh scripts/probe.ps1 frontier_hello -Mode single-flight -Backend C                        # compare lanes
#   pwsh scripts/probe.ps1 mega_spiral_proves_spiral_relative_consistency -Profile 40           # where time goes
#   pwsh scripts/probe.ps1 <sample> -Stacks 12        # stack dump if still running after 12 s (hangs)
#
# The sample compiles in place (its outputs are rewritten, as by scripts/test.ps1). Each run's stdout/stderr go
# to <cache>/probes/<sample>/; the table shows exit code, wall time and the first result line. Profiles and
# stacks use dotnet-trace/dotnet-stack, installed into <cache>/tools on first use.
param(
    [Parameter(Mandatory, Position = 0)][string]$Sample,
    [ValidateSet('single-flight', 'sf', 'hopac', 'hp')][string]$Mode = 'hopac',
    [ValidateSet('Fsharp', 'C', 'Rust', 'Delphi', 'TypeScript', 'Cpp', 'Python')][string]$Backend = 'Fsharp',
    [int]$Repeat = 1,
    [int]$BudgetSec = 180,
    # Take a stack dump of the compiler after this many seconds if it is still running (0: never).
    [int]$Stacks = 0,
    # Record a sampled-thread profile for this many seconds (0: none), starting after -ProfileDelay seconds.
    [int]$Profile = 0,
    [int]$ProfileDelay = 5,
    # Hopac workers (SPIRAL_HOPAC_WORKERS and SPIRAL_DOP); 0 keeps the default of one per core.
    [int]$Workers = 0,
    # Keep the diagnostic JSONL rows and HUD (SPIRAL_DIAG_QUIET=0); off by default, like scripts/test.ps1.
    [switch]$Loud
)
. $PSScriptRoot/env.ps1
$mode = ConvertTo-SpiralMode $Mode
$dotnet = Resolve-SpiralDotnet
$dll = Get-SpiralCompilerDll $mode 'Release'
if (-not (Test-Path $dll)) { throw "compiler not built: $dll`nrun: pwsh scripts/build.ps1 -Mode $mode" }
$cache = Get-SpiralCacheDir
$dir = Join-Path $BundleRoot "samples/$Sample"
$entry = @('main.spi', 'main.spir') | ForEach-Object { Join-Path $dir $_ } | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $entry) { throw "no main.spi or main.spir in $dir" }
$ext = @{ Fsharp = '.fsx'; C = '.c'; Rust = '.rs'; Delphi = '.pas'; TypeScript = '.ts'; Cpp = '.cpp'; Python = '.py' }[$Backend]
# The core's ids for the multi-file backends (they also write main.corelib.hpp/.hpp/.cu, main_auto.py).
$backendId = @{ Cpp = 'Cpp + Cuda'; Python = 'Python + Cuda' }[$Backend] ?? $Backend
$output = [IO.Path]::ChangeExtension($entry, $ext)
$logDir = Join-Path $cache ("probes/" + ($Sample -replace '[\\/]', '__'))
New-Item -ItemType Directory -Force $logDir | Out-Null

function Get-DiagTool([string]$name) {
    $tools = Join-Path $cache 'tools'
    $exe = Join-Path $tools ($name + $(if ($IsWindows) { '.exe' } else { '' }))
    if (-not (Test-Path $exe)) {
        & $dotnet tool install $name --tool-path $tools | Out-Null
        if (-not (Test-Path $exe)) { throw "could not install $name into $tools" }
    }
    $exe
}

$env:DOTNET_ROOT = Split-Path $dotnet
$env:SPIRAL_WORKSPACE_ROOT = $BundleRoot
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
$env:SPIRAL_BUILD_BUDGET_MS = [string]($BudgetSec * 1000)
$env:SPIRAL_DIAG_QUIET = if ($Loud) { '0' } else { '1' }
if ($Workers -gt 0) { $env:SPIRAL_HOPAC_WORKERS = "$Workers"; $env:SPIRAL_DOP = "$Workers" }

$rows = for ($run = 1; $run -le $Repeat; $run++) {
    $out = Join-Path $logDir "run$run.out.txt"
    $err = Join-Path $logDir "run$run.err.txt"
    $sw = [Diagnostics.Stopwatch]::StartNew()
    $proc = Start-Process $dotnet -ArgumentList $dll, '--backend', "`"$backendId`"", "`"$entry`"", "`"$output`"" `
        -WindowStyle Hidden -PassThru -RedirectStandardOutput $out -RedirectStandardError $err
    $note = ''
    if ($Profile -gt 0) {
        $trace = Join-Path $logDir "run$run.nettrace"
        Start-Sleep -Seconds $ProfileDelay
        if (-not $proc.HasExited) {
            & (Get-DiagTool 'dotnet-trace') collect -p $proc.Id --profile dotnet-sampled-thread-time `
                --duration ('00:00:{0:D2}' -f [Math]::Min(59, $Profile)) --format Speedscope -o $trace 2>&1 | Out-Null
            $speedscope = [IO.Path]::ChangeExtension($trace, 'speedscope.json')
            if (Test-Path $speedscope) { $note = "profile: $speedscope" }
        }
    }
    if ($Stacks -gt 0) {
        while (-not $proc.HasExited -and $sw.Elapsed.TotalSeconds -lt $Stacks) { Start-Sleep -Milliseconds 200 }
        if (-not $proc.HasExited) {
            $dump = Join-Path $logDir "run$run.stacks.txt"
            & (Get-DiagTool 'dotnet-stack') report -p $proc.Id > $dump 2>&1
            $note = "stacks at $($Stacks)s: $dump"
        }
    }
    $proc | Wait-Process -Timeout ($BudgetSec + 30) -ErrorAction SilentlyContinue
    if (-not $proc.HasExited) { Stop-Process -Id $proc.Id -Force -ErrorAction SilentlyContinue; $note += ' (killed)' }
    $text = ((Get-Content $out, $err -Raw -ErrorAction SilentlyContinue) -join "`n") -replace '\x1b\[[0-9;?]*[A-Za-z]|\x1b\][^\x07]*\x07', ''
    $first = [regex]::Match($text, '(FatalError|TypeErrors|ParserErrors|TracedError|TokenizerErrors|PackageErrors)[^\r\n]*').Value
    $result = if ($first) { $first.Trim() } elseif (Test-Path $output) { "ok ($((Get-Item $output).Length) bytes)" } else { 'no output, no diagnostic' }
    [pscustomobject]@{ Run = $run; Exit = $proc.ExitCode; Seconds = [Math]::Round($sw.Elapsed.TotalSeconds, 1); Result = $result.Substring(0, [Math]::Min(110, $result.Length)); Note = $note }
}
$rows | Format-Table -AutoSize -Wrap | Out-String -Width 220
if ($Repeat -gt 1) {
    $kinds = @($rows | Group-Object { if ($_.Result -match 'stalled') { 'stalled' } elseif ($_.Result -match '^ok') { 'ok' } else { ($_.Result -split ':')[0] } })
    "outcomes: " + (($kinds | ForEach-Object { "$($_.Name) x$($_.Count)" }) -join ', ') + $(if ($kinds.Count -gt 1) { '  <- differs between runs (race?)' } else { '' })
}
foreach ($row in $rows | Where-Object { $_.Note -match 'profile: (.+)$' }) {
    $py = Get-Command python -ErrorAction SilentlyContinue
    if ($py) { & $py.Source (Join-Path $PSScriptRoot 'profile-summary.py') ($row.Note -replace '^profile: ', '') | Select-Object -First 45 }
}
"logs: $logDir"
