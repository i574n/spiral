$ErrorActionPreference = "Stop"
$homeDir = if ($env:USERPROFILE) { $env:USERPROFILE } else { $env:HOME }
$erlang = Join-Path $homeDir "scoop/apps/erlang/current/bin"
$elixir = Join-Path $homeDir "scoop/apps/elixir/current/bin"
$sep = [IO.Path]::PathSeparator
if (Test-Path $erlang) { $env:PATH = "$erlang$sep$env:PATH" }
if (Test-Path $elixir) { $env:PATH = "$elixir$sep$env:PATH" }
$cwd = (Get-Location).Path
$fixed = New-Object System.Collections.Generic.List[string]
$key = $null
foreach ($arg in $args) {
    if ($arg -in @("--path", "--output-path", "--spi-path", "--spir-path", "--fs-path")) {
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
if ($null -eq $LASTEXITCODE) { exit 1 }
exit $LASTEXITCODE
