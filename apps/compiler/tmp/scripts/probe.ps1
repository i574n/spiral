param(
    [Parameter(Mandatory, Position = 0)][string]$Sample,
    [ValidateSet('single-flight', 'sf', 'hopac', 'hp')][string]$Mode = 'hopac',
    [ValidateSet('Fsharp', 'C', 'Rust', 'Delphi', 'TypeScript', 'Cpp', 'Python')][string]$Backend = 'Fsharp',
    [int]$Repeat = 1,
    [int]$BudgetSec = 180,
    [int]$Stacks = 0,
    [int]$Profile = 0,
    [int]$ProfileDelay = 5,
    [int]$Workers = 0,
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
