$ErrorActionPreference = "Stop"
$notebookStarted = Get-Date
. (Join-Path $PSScriptRoot "../../compiler/tmp/scripts/heavy.ps1")
function Write-NotebookLedger([string] $Route, [int] $Code) {
    $notebook = $fixed[[Math]::Max(0, $fixed.IndexOf('--path') + 1)]
    $label = "kino notebook $([IO.Path]::GetFileName($notebook)) ($Route)"
    $outcome = if ($Code) { "exit $Code" } else { 'ok' }
    try { Write-RunLedger 'notebook' $label ([scriptblock]::Create("'" + ("run_notebook.ps1 $($fixed -join ' ')" -replace "'", "''") + "'")) $notebookStarted $notebookStarted '-' $outcome 0 } catch { Write-Warning "run ledger: $($_.Exception.Message)" }
}
$homeDir = if ($env:USERPROFILE) { $env:USERPROFILE } else { $env:HOME }
$erlang = Join-Path $homeDir "scoop/apps/erlang/current/bin"
$elixir = Join-Path $homeDir "scoop/apps/elixir/current/bin"
$sep = [IO.Path]::PathSeparator
if (Test-Path $erlang) { $env:PATH = "$erlang$sep$env:PATH" }
if (Test-Path $elixir) { $env:PATH = "$elixir$sep$env:PATH" }
$crashDumps = Join-Path ($env:LOCALAPPDATA ?? $homeDir) "spiral-bin/crash-dumps"
New-Item -ItemType Directory -Force $crashDumps | Out-Null
$env:ERL_CRASH_DUMP = Join-Path $crashDumps "erl_crash-$(Get-Date -Format yyyyMMdd-HHmmss)-$PID.dump"
$cwd = (Get-Location).Path
$fixed = New-Object System.Collections.Generic.List[string]
$key = $null
foreach ($item in $args) {
    $arg = if ($item -is [array]) { $item -join "," } else { "$item" }
    if ($arg -in @("--path", "--output-path", "--output-dir", "--spi-path", "--spir-path", "--fs-path", "--livemd-path")) {
        $key = $arg
        $fixed.Add($arg)
    }
    elseif ($null -ne $key) {
        $value = $arg
        if (-not [System.IO.Path]::IsPathRooted($value)) {
            $value = Join-Path $cwd $value
        }
        $fixed.Add($value)
        $key = $null
    }
    else {
        $fixed.Add($arg)
    }
}
function Invoke-WarmNotebook([int] $Port, [string[]] $Arguments) {
    $client = [System.Net.Sockets.TcpClient]::new()
    try {
        if (-not $client.ConnectAsync('127.0.0.1', $Port).Wait(300)) { return $null }
        $utf8 = [System.Text.UTF8Encoding]::new($false)
        $stream = $client.GetStream()
        $writer = [System.IO.StreamWriter]::new($stream, $utf8)
        $writer.NewLine = "`n"
        $reader = [System.IO.StreamReader]::new($stream, $utf8)
        $request = [ordered]@{ args = $Arguments; root = (Split-Path $PSScriptRoot -Parent) } | ConvertTo-Json -Compress -Depth 3
        $writer.WriteLine("notebook`t$request")
        $writer.Flush()
        while ($null -ne ($line = $reader.ReadLine())) {
            $kind, $text = $line -split "`t", 2
            switch ($kind) {
                'line' { [Console]::Out.WriteLine($text) }
                'error' { [Console]::Error.WriteLine((ConvertFrom-Json $text)) }
                'end' { return [int]$text }
                default { return $null }
            }
        }
        return $null
    }
    catch { return $null }
    finally { $client.Dispose() }
}
if ($env:SPIRAL_CELLS_WARM -ne '0') {
    $warmArgs = [string[]] @($fixed) + $(if ($env:SPIRAL_CELLS_MEMO -eq '0') { @('--no-memo') } else { @() })
    $warmPort = if ($env:SPIRAL_CELLS_COMPILER_PORT) { [int] $env:SPIRAL_CELLS_COMPILER_PORT } else { 13905 }
    $warmExit = Invoke-WarmNotebook $warmPort $warmArgs
    if ($null -ne $warmExit) { Write-NotebookLedger 'warm' $warmExit; exit $warmExit }
}
function Resolve-RealPath([string] $Path) {
    $full = [IO.Path]::GetFullPath($Path)
    $current = [IO.Path]::GetPathRoot($full)
    foreach ($part in $full.Substring($current.Length).Split([char[]] @('\', '/'), [StringSplitOptions]::RemoveEmptyEntries)) {
        $current = Join-Path $current $part
        $target = (Get-Item -LiteralPath $current -Force -ErrorAction Ignore).LinkTarget
        if ($target) { $current = Resolve-RealPath ([IO.Path]::GetFullPath($target, (Split-Path $current))) }
    }
    $current
}
Set-Location (Resolve-RealPath (Join-Path $PSScriptRoot ".."))
$mix = Join-Path $elixir "mix.bat"
if (-not (Test-Path $mix)) { $mix = "mix" }

$bundleScripts = Join-Path (Get-Location) "../compiler/tmp/scripts"
$dotnetRoot = $env:DOTNET_ROOT
$toolchain = & {
    . (Join-Path $bundleScripts "env.ps1")
    $dotnet = try { Resolve-SpiralDotnet } catch { $null }
    if (-not $dotnet) {
        Write-Host "run_notebook.ps1 / no .NET 11 SDK: scripts/install-dotnet.ps1"
        & (Join-Path $bundleScripts "install-dotnet.ps1") | Out-Host
        $dotnet = Resolve-SpiralDotnet
    }
    $dll = if ($env:SPIRAL_COMPILER_DLL) { $env:SPIRAL_COMPILER_DLL } else { Get-SpiralCompilerDll "single-flight" }
    if (-not (Test-Path -LiteralPath $dll)) {
        Write-Host "run_notebook.ps1 / no compiler at $dll`: scripts/build.ps1 -Mode single-flight"
        & (Join-Path $bundleScripts "build.ps1") -Mode single-flight | Out-Host
        if (-not (Test-Path -LiteralPath $dll)) { throw "run_notebook.ps1 / the compiler build wrote no $dll" }
    }
    $packageDir = try { Get-SpiralPackageDir } catch { $null }
    [pscustomobject]@{ Dotnet = $dotnet; Dll = $dll; PackageDir = $packageDir }
}
$env:DOTNET_ROOT = $dotnetRoot
$env:SPIRAL_DOTNET = $toolchain.Dotnet
$env:SPIRAL_COMPILER_DLL = $toolchain.Dll
if (-not $env:SPIRAL_COMPILER_PACKAGE_DIR -and $toolchain.PackageDir) { $env:SPIRAL_COMPILER_PACKAGE_DIR = $toolchain.PackageDir }

if (-not (Test-Path "deps/kino/mix.exs")) {
    foreach ($task in "local.hex", "local.rebar", "deps.get") {
        $taskArgs = $task -like "local.*" ? @("--force", "--if-missing") : @()
        & $mix $task @taskArgs
        if ($LASTEXITCODE -ne 0) { throw "run_notebook.ps1 / mix $task failed (exit code $LASTEXITCODE)" }
    }
}

& $mix spiral.notebook @fixed
$notebookExit = if ($null -eq $LASTEXITCODE) { 1 } else { $LASTEXITCODE }
Write-NotebookLedger 'mix' $notebookExit
exit $notebookExit
