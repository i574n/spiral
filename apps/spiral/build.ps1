param(
    $fast,
    $SkipNotebook,
    $SkipFsx,
    $SkipPreBuild,
    $ScriptDir = $PSScriptRoot
)
$ScriptDir | Set-Location
$ErrorActionPreference = "Stop"
. ../../deps/polyglot/scripts/core.ps1
. ../../deps/polyglot/deps/spiral/lib/spiral/lib.ps1

$ResolvedScriptDir = ResolveLink $ScriptDir
$ResolvedScriptDir | Set-Location

Write-Output "spiral/apps/spiral/build.ps1 / ScriptDir: $ScriptDir / ResolvedScriptDir: $ResolvedScriptDir"

$projectName = "spiral"

# The shipped CLI (what polyglot, dice and alphabet run): the native Rust build of spiral.spi, no Fable.
$exe = "../../workspace/target/release/$projectName$(_exe)"
# polyglot's build.dib runs this script under the spiral CLI it rebuilds, and Windows can't replace a running exe
# ("Access is denied") but can rename it (Linux can't overwrite a running binary in place either: ETXTBSY), so the
# previous exe is moved aside, and kept until the next build as the backup.
function MoveExeAside {
    Get-ChildItem "$exe.old-*" -ErrorAction Ignore | ForEach-Object { try { $_.Delete() } catch { } }
    if (Test-Path $exe) { Move-Item $exe "$exe.old-$(Get-Date -Format yyyyMMddHHmmss)" }
}

# -SkipPreBuild (polyglot/scripts/init.ps1's bootstrap, before any spiral CLI exists): no dib-export and no F# output;
# the native build only needs the Spiral compiler (lib.ps1's BuildNativeRust) and cargo.
if (!$SkipPreBuild) {
    { . $exe dib-export "$ResolvedScriptDir/$projectName.dib" spi } | Invoke-Block
}

if (!$SkipPreBuild -and !$SkipFsx) {
    { . ../../deps/polyglot/apps/spiral/dist/Supervisor$(_exe) --build-file "$projectName.spi" "$projectName.fsx" } | Invoke-Block
}

# Native Rust: the spiral.spi entry (its `main` runs `run_main` on the process arguments when `rust.is_native ()`) -> a
# crate under the target dir with the Spiral compiler's own Rust backend. The compiler writes its output next to the .spi
# it compiles, so it compiles a staged copy (the .spi plus a package file with an absolute packageDir).
$targetDir = GetTargetDir $projectName
$nativeDir = "$targetDir/native"
$nativeStage = "$nativeDir/spi"
Remove-Item $nativeStage -Recurse -Force -ErrorAction Ignore
New-Item -ItemType Directory -Force "$nativeDir/src", $nativeStage | Out-Null
Copy-Item "$projectName.spi" $nativeStage
Copy-Item "build.rs", "$projectName.ico" $nativeDir
$packageDir = (ResolveLink (GetFullPath "../../deps/polyglot/deps/spiral/lib")) -replace '\\', '/'
@("packageDir: $packageDir", 'packages:', '    |core-', '    spiral-', 'modules:', "    $projectName") | Set-Content "$nativeStage/package.spiproj"
# The release profile keeps unwinding (lib's `try` catches panics natively). mimalloc is the global allocator (D7': the
# CLI parses every command line it runs, and the system heap was ~57 % of its native profile); build.rs sets the icon.
@(
    '[package]', "name = `"$projectName`"", 'version = "0.0.1"', 'edition = "2021"', 'build = "build.rs"', '', '[workspace]', '',
    '[[bin]]', "name = `"$projectName`"", 'path = "src/main.rs"', '',
    '[build-dependencies]',
    'winres = "0.1"', '',
    '[dependencies]',
    'mimalloc = { version = "0.1", default-features = false }',
    'chrono = ">=0.4,<1"',
    'regex = "1.10"',
    'sha2 = "~0.11.0-pre.4"',
    'serde_json = { version = "1.0", features = ["arbitrary_precision"] }',
    'clap = "4.5"',
    'futures = ">=0.3,<1"',
    'encoding_rs = ">=0.8,<1"',
    'encoding_rs_io = ">=0.1,<1"',
    'async-walkdir = "2.0"',
    'mlua = { version = ">=0.11.4", features = ["lua51", "vendored"] }'
) | Set-Content "$nativeDir/Cargo.toml"
# The first build pins the dependencies at the versions of the spiral workspace's lock file (the Fable crate,
# Cargo.toml + spiral.rs, is a workspace member with the same dependencies; it is no longer built here).
if (!(Test-Path "$nativeDir/Cargo.lock")) { Copy-Item "../../workspace/Cargo.lock" "$nativeDir/Cargo.lock" }
if (!(BuildNativeRust "$nativeStage/$projectName.spi" "$nativeDir/src/main.rs" "apps/spiral")) {
    throw "NATIVE-RUST-FAILED apps/spiral / compile"
}
Add-Content "$nativeDir/src/main.rs" "#[global_allocator]`nstatic GLOBAL: mimalloc::MiMalloc = mimalloc::MiMalloc;"
{ cargo +nightly-2025-11-01 build --release } | Invoke-Block -Location $nativeDir
$nativeExe = "$nativeDir/target/release/$projectName$(_exe)"

# Required run check before the binary replaces the shipped one:
# - `--help` exits 0 with clap's usage, and `dib-export` of a small notebook writes the expected .spi;
# - `dib-export` of every .dib of this repo (spi, plus spir for sm') gives byte-identical files and the same exit codes as
#   the previous CLI (skipped when there is none, e.g. a fresh checkout; to ship an intended dib-export change, delete
#   the previous exe first);
# - `rust --rs-path` builds and runs a std-only program, `cuda --py-path` runs a Python program (SPIRAL_JSON output).
$checkDir = "$nativeDir/check"
Remove-Item $checkDir -Recurse -Force -ErrorAction Ignore
New-Item -ItemType Directory -Force $checkDir | Out-Null
$failures = @()
$env:TRACE_LEVEL, $traceLevel = "Warning", $env:TRACE_LEVEL
try {
    $helpOutput = & $nativeExe --help 2>&1 | ForEach-Object { "$_" }
    $helpExit = $LASTEXITCODE
    "#!meta`n`n{`"kernelInfo`":{`"defaultKernelName`":`"spiral`",`"items`":[{`"name`":`"spiral`"}]}}`n`n#!markdown`n`n# check`n`n#!spiral`n`ninl main () = 1i32`n" `
        | Set-Content "$checkDir/check.dib" -NoNewline
    $exportOutput = & $nativeExe dib-export "$checkDir/check.dib" spi 2>&1 | ForEach-Object { "$_" }
    $exportExit = $LASTEXITCODE
    $helpOutput | ForEach-Object { Write-Output "spiral/apps/spiral/build.ps1 / native run / $_" }
    $exportOutput | ForEach-Object { Write-Output "spiral/apps/spiral/build.ps1 / native run / $_" }
    $spi = Get-Content "$checkDir/check.spi" -Raw -ErrorAction Ignore
    if ($helpExit -ne 0 -or !($helpOutput -match '^Usage: ') -or $exportExit -ne 0 -or $spi -ne "/// # check`ninl main () = 1i32`n") {
        $failures += "--help exit $helpExit, dib-export exit $exportExit, check.spi '$spi'"
    }

    if (Test-Path $exe) {
        $repoRoot = GetFullPath "../.."
        $dibs = Get-ChildItem "$repoRoot/lib", "$repoRoot/apps" -Recurse -Filter *.dib -ErrorAction Ignore `
            | Where-Object { $_.FullName -notmatch '[\\/](target|node_modules|deps|bin|obj|_build|\.git)[\\/]' }
        $i = 0
        foreach ($dib in $dibs) {
            $i++
            $kinds = $dib.Name -eq "sm'.dib" ? @("spi", "spir") : @("spi")
            $results = foreach ($side in "previous", "native") {
                $sideDir = "$checkDir/dib/$side/$i"
                New-Item -ItemType Directory -Force $sideDir | Out-Null
                Copy-Item -LiteralPath $dib.FullName "$sideDir/$($dib.Name)"
                $codes = foreach ($kind in $kinds) {
                    $null = & ($side -eq "previous" ? $exe : $nativeExe) dib-export "$sideDir/$($dib.Name)" $kind 2>&1
                    $LASTEXITCODE
                }
                $files = Get-ChildItem $sideDir -File | Where-Object Extension -ne ".dib" | Sort-Object Name `
                    | ForEach-Object { "$($_.Name) $((Get-FileHash -LiteralPath $_.FullName).Hash)" }
                "$($codes -join ',') | $($files -join ' | ')"
            }
            if ($results[0] -cne $results[1]) {
                $failures += "dib-export differs from the previous CLI: $($dib.FullName): previous: $($results[0]) / native: $($results[1])"
            }
        }
        Write-Output "spiral/apps/spiral/build.ps1 / native run / dib-export of $i .dib files compared with the previous CLI"
    } else {
        Write-Output "spiral/apps/spiral/build.ps1 / native run / no previous CLI at ${exe}: dib-export comparison skipped"
    }

    $env:SPIRAL_JSON, $spiralJson = "1", $env:SPIRAL_JSON
    try {
        New-Item -ItemType Directory -Force "$checkDir/rust", "$checkDir/cuda" | Out-Null
        "fn main() { println!(`"spiral-check-rust {}`", 6 * 7); }`n" | Set-Content "$checkDir/rust/main.rs" -NoNewline
        "print('spiral-check-cuda', 6 * 7)`n" | Set-Content "$checkDir/cuda/main.py" -NoNewline
        foreach ($case in @(
                @{ name = "rust"; args = @("rust", "--rs-path", (GetFullPath "$checkDir/rust/main.rs")); expect = "spiral-check-rust 42" },
                @{ name = "cuda"; args = @("cuda", "--py-path", (GetFullPath "$checkDir/cuda/main.py")); expect = "spiral-check-cuda 42" })) {
            $json = & $nativeExe @($case.args) 2> "$checkDir/$($case.name).err" | ForEach-Object { "$_" }
            $caseExit = $LASTEXITCODE
            # `cuda` wraps its result in a command_result envelope, `rust` prints the result object itself.
            $output = try {
                $result = ($json -join "`n") | ConvertFrom-Json
                if ($result.command_result) { $result = $result.command_result | ConvertFrom-Json }
                $result.output
            } catch { "<no JSON> $json" }
            Write-Output "spiral/apps/spiral/build.ps1 / native run / $($case.name): exit $caseExit / $("$output".Trim())"
            if ($caseExit -ne 0 -or !("$output" -match [regex]::Escape($case.expect))) {
                $failures += "$($case.name): exit $caseExit, expected '$($case.expect)' in the output: $output"
            }
        }
    } finally {
        $env:SPIRAL_JSON = $spiralJson
    }
} finally {
    $env:TRACE_LEVEL = $traceLevel
}
if ($failures) {
    $failures | ForEach-Object { Write-Output "spiral/apps/spiral/build.ps1 / native run / FAILED / $_" }
    throw "NATIVE-RUST-FAILED apps/spiral / run check: $($failures.Count) failure(s), the previous CLI stays"
}
Write-Output "NATIVE-RUST-OK apps/spiral"

MoveExeAside
New-Item -ItemType Directory -Force (Split-Path $exe) | Out-Null
Copy-Item $nativeExe $exe
Write-Output "spiral/apps/spiral/build.ps1 / shipped the native $projectName$(_exe) to $exe"

Write-Output "spiral/apps/spiral/build.ps1 / `$projectName: $projectName / `$env:CI:'$env:CI'"

if ($env:CI) {
    $targetDir | Remove-Item -Recurse -Force -ErrorAction Ignore
    ClearCargoTarget "../../deps/polyglot/target/spiral/spiral"
    # process_rust builds contract/wasm cells in their own workspace (their own lock for the NEAR toolchain).
    ClearCargoTarget "../../deps/polyglot/target/spiral/spiral_contract"
}
