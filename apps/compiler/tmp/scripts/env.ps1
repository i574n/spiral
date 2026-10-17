$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

$script:BundleRoot = Split-Path $PSScriptRoot -Parent

function Get-SpiralCacheDir {
    $dir =
        if ($env:SPIRAL_BIN_CACHE_DIR) { $env:SPIRAL_BIN_CACHE_DIR }
        elseif ($IsWindows) { Join-Path $env:LOCALAPPDATA 'spiral-bin' }
        else { Join-Path $HOME '.cache/spiral-bin' }
    New-Item -ItemType Directory -Force $dir | Out-Null
    (Resolve-Path $dir).Path
}

function ConvertTo-SpiralMode([string]$Mode) {
    switch -Regex ($Mode) {
        '^(sf|single|single-flight)$' { 'single-flight' }
        '^(gp|gpt5parallel)$' { 'gpt5parallel' }
        '^(hs|hopacsota)$' { 'hopacsota' }
        default { throw "unknown mode '$Mode' (use single-flight, gpt5parallel or hopacsota)" }
    }
}

function Get-SpiralCoreSource([string]$Mode) {
    [void](ConvertTo-SpiralMode $Mode)
    Join-Path (Split-Path $BundleRoot -Parent) 'spiral_compiler.fs'
}

function Get-SpiralCoreProjection([string]$Mode, [string]$Destination, [string]$Source) {
    $gpt5parallel = (ConvertTo-SpiralMode $Mode) -eq 'gpt5parallel'
    $hopacsota = (ConvertTo-SpiralMode $Mode) -eq 'hopacsota'
    $text = [IO.File]::ReadAllText($(if ($Source) { $Source } else { Get-SpiralCoreSource $Mode }))
    $out = [Text.StringBuilder]::new($text.Length)
    $depth = 0
    $ours = [Collections.Generic.List[object]]::new()
    foreach ($line in [regex]::Split($text, '(?<=\n)')) {
        if ($line.Length -eq 0) { continue }
        $bare = $line.TrimEnd("`r", "`n")
        if ($bare -ceq '#if SPIRAL_CORE_GPT5PARALLEL') { $depth++; $ours.Add(@($depth, $true, $gpt5parallel)); continue }
        if ($bare -ceq '#if SPIRAL_CORE_HOPACSOTA') { $depth++; $ours.Add(@($depth, $true, $hopacsota)); continue }
        if ($ours.Count -and $depth -eq $ours[$ours.Count - 1][0] -and ($bare -ceq '#else' -or $bare -ceq '#endif')) {
            if ($bare -ceq '#else') { $ours[$ours.Count - 1] = @($depth, $false, $ours[$ours.Count - 1][2]) } else { $ours.RemoveAt($ours.Count - 1); $depth-- }
            continue
        }
        if ($line -match '^\s*#if\b') { $depth++ } elseif ($line -match '^\s*#endif\b') { $depth-- }
        $keep = $true
        foreach ($block in $ours) { if ($block[1] -ne $block[2]) { $keep = $false; break } }
        if ($keep) { [void]$out.Append($line) }
    }
    if ($ours.Count) { throw 'unterminated #if SPIRAL_CORE_GPT5PARALLEL or SPIRAL_CORE_HOPACSOTA block in the core' }
    New-Item -ItemType Directory -Force (Split-Path $Destination) | Out-Null
    [IO.File]::WriteAllText($Destination, $out.ToString())
    $Destination
}

function Test-DotnetHasSdk11([string]$Dotnet) {
    try { (& $Dotnet --list-sdks 2>$null) -match '^11\.' } catch { $false }
}

function Resolve-SpiralDotnet {
    $exe = if ($IsWindows) { 'dotnet.exe' } else { 'dotnet' }
    $candidates = @()
    if ($env:SPIRAL_DOTNET) { $candidates += $env:SPIRAL_DOTNET }
    $candidates += Join-Path (Get-SpiralCacheDir) "toolchains/dotnet/$exe"
    $sharedCache = if ($IsWindows) { Join-Path $env:LOCALAPPDATA 'spiral-bin' } else { Join-Path $HOME '.cache/spiral-bin' }
    $candidates += Join-Path $sharedCache "toolchains/dotnet/$exe"
    $onPath = Get-Command dotnet -ErrorAction SilentlyContinue
    if ($onPath) { $candidates += $onPath.Source }
    foreach ($candidate in $candidates) {
        if ((Test-Path $candidate) -and (Test-DotnetHasSdk11 $candidate)) {
            $env:DOTNET_ROOT = Split-Path $candidate -Parent
            $env:DOTNET_CLI_TELEMETRY_OPTOUT = '1'
            $env:DOTNET_NOLOGO = '1'
            $env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = '1'
            return $candidate
        }
    }
    throw "No .NET 11 SDK found. Run scripts/install-dotnet.ps1 (installs into the cache dir) or set SPIRAL_DOTNET."
}

function Resolve-SpiralTool([string]$Name, [string[]]$Candidates) {
    foreach ($candidate in $Candidates) {
        if (-not $candidate) { continue }
        $command = Get-Command $candidate -CommandType Application -ErrorAction SilentlyContinue | Select-Object -First 1
        if ($command) { return $command.Source }
    }
    $null
}

function Get-SpiralNativeTools {
    [pscustomobject]@{
        CC = Resolve-SpiralTool 'cc' @($env:SPIRAL_CC, 'gcc', 'clang', 'cc')
        Rustc = Resolve-SpiralTool 'rustc' @($env:SPIRAL_RUSTC, 'rustc')
        Fpc = Resolve-SpiralTool 'fpc' @($env:SPIRAL_FPC, 'fpc')
        Zig = Resolve-SpiralTool 'zig' @($env:SPIRAL_ZIG, 'zig')
        Wasmtime = Resolve-SpiralTool 'wasmtime' @($env:SPIRAL_WASMTIME, (Join-Path $HOME 'scoop/apps/wasmtime/current/wasmtime.exe'), 'wasmtime', $(if ($env:ProgramFiles) { Join-Path $env:ProgramFiles 'Wasmtime/bin/wasmtime.exe' }), (Join-Path $HOME '.wasmtime/bin/wasmtime'))
        WgslRun = @($env:SPIRAL_WGSL_RUN, (Join-Path (Get-SpiralCacheDir) 'toolchains/wgsl-run/release/spiral-wgsl.exe'), (Join-Path (Get-SpiralCacheDir) 'toolchains/wgsl-run/release/spiral-wgsl')) | Where-Object { $_ -and (Test-Path $_) } | Select-Object -First 1
        Cider = @($env:SPIRAL_CIDER, (Join-Path (Get-SpiralCacheDir) 'toolchains/calyx-src/target/release/cider.exe'), (Join-Path (Get-SpiralCacheDir) 'toolchains/calyx-src/target/release/cider')) | Where-Object { $_ -and (Test-Path $_) } | Select-Object -First 1
        Auxin = @($env:SPIRAL_AUXIN, (Join-Path (Get-SpiralCacheDir) 'toolchains/calyx-src/target/release/auxin.exe'), (Join-Path (Get-SpiralCacheDir) 'toolchains/calyx-src/target/release/auxin')) | Where-Object { $_ -and (Test-Path $_) } | Select-Object -First 1
        CalyxRoot = @($env:SPIRAL_CALYX_ROOT, (Join-Path (Get-SpiralCacheDir) 'toolchains/calyx-src')) | Where-Object { $_ -and (Test-Path (Join-Path $_ 'primitives/core.futil')) } | Select-Object -First 1
        Kotlinc = @($env:SPIRAL_KOTLINC, (Join-Path $HOME 'scoop/apps/kotlin/current/bin/kotlinc.bat'), (Join-Path (Get-SpiralCacheDir) 'toolchains/kotlinc/bin/kotlinc.bat'), (Join-Path (Get-SpiralCacheDir) 'toolchains/kotlinc/bin/kotlinc')) | Where-Object { $_ -and (Test-Path $_) } | Select-Object -First 1
        Java = Resolve-SpiralTool 'java' @($env:SPIRAL_JAVA, (Join-Path $HOME 'scoop/apps/temurin25-jdk/current/bin/java.exe'), (Join-Path $HOME 'scoop/apps/temurin-jdk/current/bin/java.exe'), 'java')
        Swiftc = Resolve-SpiralTool 'swiftc' @($env:SPIRAL_SWIFTC, 'swiftc', $(if ($env:LOCALAPPDATA) { Join-Path $env:LOCALAPPDATA 'Programs/Swift/Toolchains/6.4.0+Asserts/usr/bin/swiftc.exe' }))
        SwiftSdk = @($env:SPIRAL_SWIFT_SDK, $(if ($env:LOCALAPPDATA) { Join-Path $env:LOCALAPPDATA 'Programs/Swift/Platforms/6.4.0/Windows.platform/Developer/SDKs/Windows.sdk' })) | Where-Object { $_ -and (Test-Path (Join-Path $_ 'usr/lib/swift/windows/x86_64/swiftCore.lib')) } | Select-Object -First 1
        SwiftRuntime = @($env:SPIRAL_SWIFT_RUNTIME, $(if ($env:LOCALAPPDATA) { Join-Path $env:LOCALAPPDATA 'Programs/Swift/Runtimes/6.4.0/usr/bin' })) | Where-Object { $_ -and (Test-Path (Join-Path $_ 'swiftCore.dll')) } | Select-Object -First 1
        Lean = Resolve-SpiralTool 'lean' @($env:SPIRAL_LEAN, 'lean', $(if ($env:ELAN_HOME) { Join-Path $env:ELAN_HOME 'bin/lean' }), (Join-Path $HOME '.elan/bin/lean'), (Join-Path $HOME 'scoop/persist/elan/.elan/bin/lean'))
        Gleam = Resolve-SpiralTool 'gleam' @($env:SPIRAL_GLEAM, 'gleam')
        Erl = Resolve-SpiralTool 'erl' @($env:SPIRAL_ERL, (Join-Path $HOME 'scoop/apps/erlang/current/bin/erl'), 'erl')
        # `lua` is Scoop lua51 5.1.5 for WoW. lua54 is a side command and must not take this slot.
        Lua = Resolve-SpiralTool 'lua' @($env:SPIRAL_LUA, 'lua', 'luajit')
        Bun = Resolve-SpiralTool 'bun' @($env:SPIRAL_BUN, 'bun')
        BendMain = @($env:SPIRAL_BEND_MAIN, (Join-Path (Get-SpiralCacheDir) 'toolchains/bend/bend2/main.ts'), $(if ($env:LOCALAPPDATA) { Join-Path $env:LOCALAPPDATA 'spiral-bin/toolchains/bend/bend2/main.ts' })) | Where-Object { $_ -and (Test-Path $_) } | Select-Object -First 1
        Python = Resolve-SpiralTool 'python' @($env:SPIRAL_PYTHON, (Join-Path $HOME 'scoop/apps/python/current/python.exe'), 'python', 'python3')
    }
}

if (-not $env:SPIRAL_CODEGEN_RUNTIME_DIR) {
    $env:SPIRAL_CODEGEN_RUNTIME_DIR = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '../../runtime'))
}

function Get-SpiralCompilerDll([string]$Mode, [string]$Configuration = 'Release') {
    if ($env:SPIRAL_COMPILER_DLL) { return $env:SPIRAL_COMPILER_DLL }
    $mode = ConvertTo-SpiralMode $Mode
    Join-Path (Get-SpiralCacheDir) "bin/$mode/SpiralCompiler/$Configuration/net11.0/SpiralCompiler.dll"
}

function Get-SpiralBaselinePath { Join-Path (Get-SpiralCacheDir) 'baseline/EXPECTED.tsv' }
function Get-SpiralScoreboardPath([string]$Mode) { Join-Path (Get-SpiralCacheDir) "scoreboards/$(ConvertTo-SpiralMode $Mode).tsv" }

function Get-SpiralPackageDir {
    $candidates = @(
        $env:SPIRAL_COMPILER_PACKAGE_DIR,
        (Join-Path $BundleRoot '../../../deps/The-Spiral-Language/VS Code Plugin'),
        (Join-Path $BundleRoot '../../../deps/polyglot/deps/The-Spiral-Language/VS Code Plugin'),
        (Join-Path $BundleRoot '../../../../polyglot/deps/The-Spiral-Language/VS Code Plugin')
    )
    foreach ($candidate in $candidates) {
        if ($candidate -and (Test-Path (Join-Path $candidate 'core/package.spiproj'))) { return (Resolve-Path $candidate).Path }
    }
    throw 'The-Spiral-Language core package not found: run scripts/init.ps1 (clones it to deps/The-Spiral-Language) or set SPIRAL_COMPILER_PACKAGE_DIR.'
}

function Get-SpiralLibDir {
    $cache = Get-SpiralCacheDir
    $lib = Join-Path $cache 'lib'
    if (-not (Test-Path (Join-Path $lib 'Hopac.dll'))) {
        $dotnet = Resolve-SpiralDotnet
        & $dotnet build (Join-Path $BundleRoot 'compiler/lib/Dependencies.fsproj') -c Release -nologo -v:q "-p:SpiralCacheDir=$cache" | Out-Host
        if ($LASTEXITCODE -ne 0) { throw 'building the dependency directory failed' }
    }
    (Resolve-Path $lib).Path
}

function Get-FileSha256([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path)) { return '' }
    (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Get-TextSha256([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path)) { return '' }
    $text = [IO.File]::ReadAllText($Path) -replace "`r`n", "`n"
    $text = ($text -split "`n" | ForEach-Object { $_.TrimEnd() }) -join "`n"
    $bytes = [Text.Encoding]::UTF8.GetBytes($text.TrimEnd())
    [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData($bytes)).ToLowerInvariant()
}
