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

# Native Rust: compiles $SpiPath to $RsPath with the Spiral compiler's own Rust backend (`--backend Rust`), through
# the portable compiler host that polyglot/scripts/spiral-bundle.ps1 resolves (the way apps/builder and
# apps/dir-tree-html build). Returns $true when the compiler wrote $RsPath. Never throws: a failure prints a
# `NATIVE-RUST-FAILED <name>` line (grep the workflow log for it) and the caller throws. The compile is killed (whole process tree) after
# SPIRAL_NATIVE_RUST_TIMEOUT_SEC seconds (default 1800): apps/spiral is the largest compile in either repo.
# -Backend "Python + Cuda" compiles the same way with the native Python backend (the former Fable Python path) and
# prints NATIVE-PYTHON-* lines instead.
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
    # NATIVE-RUST, NATIVE-TYPESCRIPT, NATIVE-PYTHON (Python + Cuda), NATIVE-GLEAM, ...
    $tag = "NATIVE-" + ($Backend -split ' ')[0].ToUpperInvariant()
    try {
        . (ResolveLink "$PSScriptRoot/../../deps/polyglot/scripts/spiral-bundle.ps1")
        $spiral = Ensure-SpiralRustCompiler | Select-Object -Last 1
        # `|core-` resolves through SPIRAL_COMPILER_PACKAGE_DIR (else "Package not loaded." on line 1).
        # A child scope keeps env.ps1's StrictMode/ErrorActionPreference out of this function.
        if (!$env:SPIRAL_COMPILER_PACKAGE_DIR) {
            $env:SPIRAL_COMPILER_PACKAGE_DIR = & { . (Join-Path $spiral.Bundle 'scripts/env.ps1'); Get-SpiralPackageDir }
        }
        $start = Get-Date
        Write-Host "spiral/lib/spiral/lib.ps1/BuildNativeRust / $Name / $($spiral.Compiler) --backend $Backend $SpiPath $RsPath"
        $timeoutSec = [int]($env:SPIRAL_NATIVE_RUST_TIMEOUT_SEC ?? 1800)
        $arguments = @($spiral.Compiler, "--backend", $Backend, $SpiPath, $RsPath) | ForEach-Object { "`"$_`"" }
        $process = Start-Process -FilePath $spiral.Dotnet -ArgumentList $arguments -NoNewWindow -PassThru
        $null = $process.Handle
        if (!$process.WaitForExit($timeoutSec * 1000)) {
            try { $process.Kill($true) } catch { }
            throw "timeout after $timeoutSec s (SPIRAL_NATIVE_RUST_TIMEOUT_SEC)"
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

function GetFsxModules {
    @("deps/spiral/lib/spiral/common.fsx", "deps/spiral/lib/spiral/sm.fsx", "deps/spiral/lib/spiral/crypto.fsx", "deps/spiral/lib/spiral/date_time.fsx", "deps/spiral/lib/spiral/async_.fsx", "deps/spiral/lib/spiral/threading.fsx", "deps/spiral/lib/spiral/networking.fsx", "deps/spiral/lib/spiral/platform.fsx", "deps/spiral/lib/spiral/runtime.fsx", "deps/spiral/lib/spiral/file_system.fsx", "deps/spiral/lib/spiral/trace.fsx", "deps/spiral/lib/spiral/lib.fsx")
}
