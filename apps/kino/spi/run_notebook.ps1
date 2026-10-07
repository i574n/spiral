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
# Run mix from the project's real path: callers reach this script through symlinked routes (dice/deps/polyglot/deps/
# spiral/...), and mix links _build/dev/lib/spiral_kino/priv to the project path it runs from, so a different route makes
# it recreate that link, which fails on Windows ("Cannot remove symlink ... not owner").
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

# A fresh checkout (a CI runner) has neither the Spiral compiler nor the hex deps; both steps below run only when their
# output is missing, so a dev machine just checks two paths.
# 1. The single-flight SpiralCompiler.dll and the .NET 11 SDK it runs on, in the spiral-bin cache (%LOCALAPPDATA%\spiral-bin,
#    ~/.cache/spiral-bin on Linux): `mix compile` regenerates the Gleam domain with it and every cell compiles with it.
#    The compiler bundle's own scripts install and build them (polyglot's spiral-bundle.ps1 does the same for the app
#    builds; CI's setup-dotnet only provides .NET 9).
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
# Resolve-SpiralDotnet points DOTNET_ROOT at the .NET 11 SDK; the cells' own tools must keep the caller's (Kino sets it
# per compile).
$env:DOTNET_ROOT = $dotnetRoot
$env:SPIRAL_DOTNET = $toolchain.Dotnet
$env:SPIRAL_COMPILER_DLL = $toolchain.Dll
if (-not $env:SPIRAL_COMPILER_PACKAGE_DIR -and $toolchain.PackageDir) { $env:SPIRAL_COMPILER_PACKAGE_DIR = $toolchain.PackageDir }

# 2. The hex deps (kino). `--if-missing` keeps an installed Hex/rebar; on a fresh machine it installs them without the
#    interactive prompt `mix deps.get` would otherwise show.
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
