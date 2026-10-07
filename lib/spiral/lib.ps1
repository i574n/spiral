function GetTargetDir {
    param (
        [Parameter(Mandatory)]
        [string] $ProjectName
    )
    $root = "$PSScriptRoot/../../deps/polyglot"
    $result = ResolveLink "$root/target/Builder/$ProjectName"
    Write-Host "spiral/lib/spiral/lib.ps1/GetTargetDir / targetDir: $result"
    $result
}

# The compiler bundle of this spiral checkout (apps/compiler/tmp): installs the .NET 11 SDK and builds the single-flight
# compiler into the cache when either is missing (what polyglot's scripts/spiral-bundle.ps1 does for polyglot's apps).
function Ensure-SpiralCompiler {
    $bundle = ResolveLink "$PSScriptRoot/../../apps/compiler/tmp"
    if (!(Test-Path -LiteralPath (Join-Path $bundle "scripts/env.ps1"))) { throw "Spiral compiler bundle not found at $bundle" }
    . (Join-Path $bundle "scripts/env.ps1")
    $env:SPIRAL_WORKSPACE_ROOT = $bundle
    $env:CARGO_TERM_COLOR = "never"
    $ready = try { $null = Resolve-SpiralDotnet; $true } catch { $false }
    if (!$ready) {
        & (Join-Path $bundle "scripts/install-dotnet.ps1")
        if ($LASTEXITCODE -ne 0) { throw "dotnet 11 install failed" }
    }
    $compiler = Get-SpiralCompilerDll "single-flight"
    if (!(Test-Path -LiteralPath $compiler)) {
        & (Join-Path $bundle "scripts/build.ps1") -Mode single-flight
        if ($LASTEXITCODE -ne 0) { throw "SpiralCompiler build failed" }
        $compiler = Get-SpiralCompilerDll "single-flight"
    }
    if (!(Test-Path -LiteralPath $compiler)) { throw "SpiralCompiler dll missing at $compiler" }
    [pscustomobject]@{ Bundle = $bundle; Dotnet = (Resolve-SpiralDotnet); Compiler = $compiler }
}

# Compiles $SpiPath to $OutPath with the Spiral compiler (`--backend $Backend`, Rust by default), through the portable
# compiler host of this checkout (Ensure-SpiralCompiler).
# Returns $true when the compiler wrote $OutPath. Never throws: a failure prints a `<BACKEND>-FAILED <name>` line
# (RUST-FAILED, TYPESCRIPT-FAILED, PYTHON-FAILED for "Python + Cuda", GLEAM-FAILED, ...; grep the workflow log for it)
# and the caller throws. The compile is killed (whole process tree) after SPIRAL_COMPILE_TIMEOUT_SEC seconds (default
# 1800; the former SPIRAL_NATIVE_RUST_TIMEOUT_SEC is still read): apps/spiral is the largest compile in either repo.
function BuildSpiral {
    param (
        [Parameter(Mandatory)]
        [string] $SpiPath,
        [Parameter(Mandatory)]
        [string] $OutPath,
        [Parameter(Mandatory)]
        [string] $Name,
        [string] $Backend = "Rust"
    )
    $RsPath = $OutPath
    $tag = ($Backend -split ' ')[0].ToUpperInvariant()
    try {
        $spiral = Ensure-SpiralCompiler | Select-Object -Last 1
        # `|core-` resolves through SPIRAL_COMPILER_PACKAGE_DIR (else "Package not loaded." on line 1).
        # A child scope keeps env.ps1's StrictMode/ErrorActionPreference out of this function.
        if (!$env:SPIRAL_COMPILER_PACKAGE_DIR) {
            $env:SPIRAL_COMPILER_PACKAGE_DIR = & { . (Join-Path $spiral.Bundle 'scripts/env.ps1'); Get-SpiralPackageDir }
        }
        $start = Get-Date
        Write-Host "spiral/lib/spiral/lib.ps1/BuildSpiral / $Name / $($spiral.Compiler) --backend $Backend $SpiPath $RsPath"
        $timeoutSec = [int]($env:SPIRAL_COMPILE_TIMEOUT_SEC ?? $env:SPIRAL_NATIVE_RUST_TIMEOUT_SEC ?? 1800)
        $arguments = @($spiral.Compiler, "--backend", $Backend, $SpiPath, $RsPath) | ForEach-Object { "`"$_`"" }
        $process = Start-Process -FilePath $spiral.Dotnet -ArgumentList $arguments -NoNewWindow -PassThru
        $null = $process.Handle
        if (!$process.WaitForExit($timeoutSec * 1000)) {
            try { $process.Kill($true) } catch { }
            throw "timeout after $timeoutSec s (SPIRAL_COMPILE_TIMEOUT_SEC)"
        }
        if ($process.ExitCode -ne 0) { throw "compiler exit code $($process.ExitCode)" }
        if (!(Test-Path $RsPath) -or (Get-Item $RsPath).LastWriteTime -lt $start) { throw "the compiler wrote no $RsPath" }
        Write-Host "$tag-COMPILED $Name / $RsPath / $([int]((Get-Date) - $start).TotalSeconds) s"
        $true
    } catch {
        Write-Host "$tag-FAILED $Name / compile / $_"
        $false
    }
}

# The former name, kept for one release (scripts outside these repos may still call it).
function BuildNativeRust {
    param (
        [Parameter(Mandatory)]
        [string] $SpiPath,
        [Parameter(Mandatory)]
        [string] $RsPath,
        [Parameter(Mandatory)]
        [string] $Name,
        [string] $Backend = "Rust"
    )
    BuildSpiral -SpiPath $SpiPath -OutPath $RsPath -Name $Name -Backend $Backend
}

function GetFsxModules {
    @("deps/spiral/lib/spiral/common.fsx", "deps/spiral/lib/spiral/sm.fsx", "deps/spiral/lib/spiral/crypto.fsx", "deps/spiral/lib/spiral/date_time.fsx", "deps/spiral/lib/spiral/async_.fsx", "deps/spiral/lib/spiral/threading.fsx", "deps/spiral/lib/spiral/networking.fsx", "deps/spiral/lib/spiral/platform.fsx", "deps/spiral/lib/spiral/runtime.fsx", "deps/spiral/lib/spiral/file_system.fsx", "deps/spiral/lib/spiral/trace.fsx", "deps/spiral/lib/spiral/lib.fsx")
}

# The spiral library's F# modules (the compiler's F# runtime helpers), absolute, in compile order: what an F# program the
# compiler wrote (e.g. dice.fsx) is published with (PublishFsharp -Modules).
function GetFsxModulePaths {
    @("common", "sm", "crypto", "date_time", "async_", "threading", "networking", "platform", "runtime", "file_system", "trace", "lib") `
        | ForEach-Object { (Resolve-Path (Join-Path $PSScriptRoot "$_.fsx")).Path }
}
# F# (.NET): publishes $SourcePath (an .fsx/.fs the compiler wrote, e.g. dice.fsx) as a self-contained single-file exe
# in <source dir>/dist, compiled with $Modules (paths, compiled first, in order). Packages are NuGet PackageReferences
# (`Name=Version`; FSharp.Core always), restored by dotnet itself: no paket. Like polyglot's former Builder, the
# compiler's top-level `let main args` gets [<EntryPoint>] and the script's trailing `()` is dropped. -Runtime picks one
# RID (default: linux-x64 and win-x64). Returns $true when every publish exited 0.
function PublishFsharp {
    param (
        [Parameter(Mandatory)]
        [string] $SourcePath,
        [string[]] $Modules = @(),
        [string[]] $Packages = @(),
        [string] $Runtime,
        [string] $Name
    )
    $source = (Resolve-Path $SourcePath).Path
    $Name = $Name ? $Name : [IO.Path]::GetFileNameWithoutExtension($source)
    $outDir = Join-Path (Split-Path $source) "dist"
    $projectDir = Join-Path (GetTargetDir $Name) "fsproj"
    New-Item -ItemType Directory -Force $projectDir | Out-Null

    $text = [IO.File]::ReadAllText($source).Replace("`r`n", "`n")
    # the first `let main` that is a function (`let main args`, `let main()`), not a value (`let main = ...`)
    $entry = [regex]::Match($text, '(?m)^([ \t]*)let main(?=\(|[ \t]+[^=\s])')
    if ($entry.Success) { $text = $text.Insert($entry.Index, "$($entry.Groups[1].Value)[<EntryPoint>]`n") }
    $text = [regex]::Replace($text, '\n\(\)\s*$', '')
    [IO.File]::WriteAllText((Join-Path $projectDir "$Name.fs"), $text)

    $compile = @($Modules | ForEach-Object { "        <Compile Include=`"$((Resolve-Path $_).Path)`" />" }) + "        <Compile Include=`"$Name.fs`" />"
    $references = @("FSharp.Core=9.0.303") + $Packages | ForEach-Object {
        $id, $version = $_ -split '=', 2
        "        <PackageReference Include=`"$id`" Version=`"$version`" />"
    }
    $fsproj = @"
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>net9.0</TargetFramework>
        <LangVersion>preview</LangVersion>
        <RollForward>Major</RollForward>
        <ServerGarbageCollection>true</ServerGarbageCollection>
        <ConcurrentGarbageCollection>true</ConcurrentGarbageCollection>
        <PublishSingleFile>true</PublishSingleFile>
        <SelfContained>true</SelfContained>
        <OutputType>Exe</OutputType>
        <DisableImplicitFSharpCoreReference>true</DisableImplicitFSharpCoreReference>
        <DefineConstants Condition="`$([MSBuild]::IsOSPlatform('Linux'))">_LINUX</DefineConstants>
        <DefineConstants Condition="`$([MSBuild]::IsOSPlatform('Windows'))">_WINDOWS</DefineConstants>
    </PropertyGroup>
    <ItemGroup>
$($compile -join "`n")
    </ItemGroup>
    <ItemGroup>
$($references -join "`n")
    </ItemGroup>
    <ItemGroup>
        <FrameworkReference Include="Microsoft.AspNetCore.App" />
    </ItemGroup>
</Project>
"@
    $fsprojPath = Join-Path $projectDir "$Name.fsproj"
    [IO.File]::WriteAllText($fsprojPath, $fsproj.Replace("`r`n", "`n"))
    $ok = $true
    foreach ($rid in ($Runtime ? @($Runtime) : @("linux-x64", "win-x64"))) {
        dotnet publish $fsprojPath --configuration Release --output $outDir --runtime $rid | Out-Host
        if ($LASTEXITCODE -ne 0) { $ok = $false }
    }
    $ok
}
