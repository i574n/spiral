param(
    $fast,
    $SkipNotebook,
    $ScriptDir = $PSScriptRoot
)
$ScriptDir | Set-Location
$ErrorActionPreference = "Stop"
. ../../scripts/core.ps1
. ../../lib/spiral/lib.ps1

$ResolvedScriptDir = ResolveLink $ScriptDir
$ResolvedScriptDir | Set-Location

Write-Output "spiral/apps/spiral/build.ps1 / ScriptDir: $ScriptDir / ResolvedScriptDir: $ResolvedScriptDir"

$projectName = "spiral"

$exe = "../../workspace/target/release/$projectName$(_exe)"
function MoveExeAside {
    Get-ChildItem "$exe.old-*" -ErrorAction Ignore | ForEach-Object { try { $_.Delete() } catch { } }
    if (Test-Path $exe) { Move-Item $exe "$exe.old-$(Get-Date -Format yyyyMMddHHmmss)" }
}


$targetDir = GetTargetDir $projectName
if (!(BuildSpiral "$projectName.spi" "$projectName.rs" "apps/spiral")) {
    throw "RUST-FAILED apps/spiral / compile"
}
[IO.File]::AppendAllText((Join-Path $ResolvedScriptDir "$projectName.rs"), "#[global_allocator]`nstatic GLOBAL: mimalloc::MiMalloc = mimalloc::MiMalloc;`n")
{ cargo +nightly-2026-10-18 build --profile release-unwind --package $projectName } | Invoke-Block -Location ../../workspace
$cargoTarget = (cargo metadata --format-version 1 --no-deps --manifest-path ../../workspace/Cargo.toml | ConvertFrom-Json).target_directory
$newExe = "$cargoTarget/release-unwind/$projectName$(_exe)"
$checkDir = "$targetDir/check"
Remove-Item $checkDir -Recurse -Force -ErrorAction Ignore
New-Item -ItemType Directory -Force $checkDir | Out-Null
$failures = @()
$env:TRACE_LEVEL, $traceLevel = "Warning", $env:TRACE_LEVEL
try {
    $helpOutput = & $newExe --help 2>&1 | ForEach-Object { "$_" }
    $helpExit = $LASTEXITCODE
    "#!meta`n`n{`"kernelInfo`":{`"defaultKernelName`":`"spiral`",`"items`":[{`"name`":`"spiral`"}]}}`n`n#!markdown`n`n# check`n`n#!spiral`n`ninl main () = 1i32`n" `
        | Set-Content "$checkDir/check.cells" -NoNewline
    $exportOutput = & $newExe export "$checkDir/check.cells" spi 2>&1 | ForEach-Object { "$_" }
    $exportExit = $LASTEXITCODE
    $helpOutput | ForEach-Object { Write-Output "spiral/apps/spiral/build.ps1 / run check / $_" }
    $exportOutput | ForEach-Object { Write-Output "spiral/apps/spiral/build.ps1 / run check / $_" }
    $spi = Get-Content "$checkDir/check.spi" -Raw -ErrorAction Ignore
    if ($helpExit -ne 0 -or !($helpOutput -match '^Usage: ') -or $exportExit -ne 0 -or $spi -ne "/// # check`ninl main () = 1i32`n") {
        $failures += "--help exit $helpExit, export exit $exportExit, check.spi '$spi'"
    }

    if (Test-Path $exe) {
        $repoRoot = GetFullPath "../.."
        $livemds = Get-ChildItem "$repoRoot/lib", "$repoRoot/apps" -Recurse -Filter *.livemd -ErrorAction Ignore `
            | Where-Object { $_.FullName -notmatch '[\\/](target|node_modules|deps|bin|obj|_build|\.git)[\\/]' }
        $rendered = "$checkDir/livemd"
        $sep = [IO.Path]::PathSeparator
        $homeDir = $env:USERPROFILE ?? $env:HOME
        $mixPath = (@("scoop/apps/erlang/current/bin", "scoop/apps/elixir/current/bin") | ForEach-Object { Join-Path $homeDir $_ } | Where-Object { Test-Path $_ }) -join $sep
        $env:PATH, $pathBefore = "$mixPath$sep$env:PATH", $env:PATH
        Push-Location (GetFullPath "../cells")
        [IO.File]::WriteAllText("$checkDir/livemd.txt", (($livemds.FullName -join "`n") + "`n"))
        try {
            if (-not (Test-Path "deps/kino/mix.exs")) {
                foreach ($task in "local.hex", "local.rebar", "deps.get") {
                    $taskArgs = $task -like "local.*" ? @("--force", "--if-missing") : @()
                    mix $task @taskArgs 2>&1 | Select-Object -Last 1
                }
            }
            $renderOutput = mix spiral.render_cells --out-dir $rendered --list "$checkDir/livemd.txt" 2>&1 | ForEach-Object { "$_" }; $renderExit = $LASTEXITCODE
        }
        finally { Pop-Location; $env:PATH = $pathBefore }
        if ($renderExit -ne 0) { $failures += "mix spiral.render_cells exit ${renderExit}: $($renderOutput -join ' / ')" }
        $notebooks = Get-ChildItem $rendered -Recurse -Filter *.cells -ErrorAction Ignore
        $i = 0
        foreach ($notebook in $notebooks) {
            $i++
            $kinds = $notebook.Name -eq "sm'.cells" ? @("spi", "spir") : @("spi")
            $results = foreach ($side in "previous", "new") {
                $sideDir = "$checkDir/export/$side/$i"
                New-Item -ItemType Directory -Force $sideDir | Out-Null
                Copy-Item -LiteralPath $notebook.FullName "$sideDir/$($notebook.Name)"
                $codes = foreach ($kind in $kinds) {
                    $null = if ($side -eq "previous") { & $exe dib-export "$sideDir/$($notebook.Name)" $kind 2>&1 } else { & $newExe export "$sideDir/$($notebook.Name)" $kind 2>&1 }
                    $LASTEXITCODE
                }
                $files = Get-ChildItem $sideDir -File | Where-Object Extension -ne ".cells" | Sort-Object Name `
                    | ForEach-Object { "$($_.Name) $((Get-FileHash -LiteralPath $_.FullName).Hash)" }
                "$($codes -join ',') | $($files -join ' | ')"
            }
            if ($results[0] -cne $results[1]) {
                $failures += "export differs from the previous CLI: $($notebook.FullName): previous: $($results[0]) / new: $($results[1])"
            }
        }
        Write-Output "spiral/apps/spiral/build.ps1 / run check / export of $i notebooks compared with the previous CLI"
    } else {
        Write-Output "spiral/apps/spiral/build.ps1 / run check / no previous CLI at ${exe}: export comparison skipped"
    }

    $env:SPIRAL_JSON, $spiralJson = "1", $env:SPIRAL_JSON
    $scoopErlang = Join-Path $HOME 'scoop/apps/erlang/current/bin'
    if (Test-Path $scoopErlang) { $env:PATH = $scoopErlang + [IO.Path]::PathSeparator + $env:PATH }
    try {
        New-Item -ItemType Directory -Force "$checkDir/rust", "$checkDir/cuda", "$checkDir/lua", "$checkDir/gleam" | Out-Null
        "import gleam/io`n`npub fn main() {`n  io.println(`"spiral-check-gleam 42`")`n}`n" | Set-Content "$checkDir/gleam/main.gleam" -NoNewline
        "print('spiral-check-lua', 6 * 7)`n" | Set-Content "$checkDir/lua/main.lua" -NoNewline
        "fn main() { println!(`"spiral-check-rust {}`", 6 * 7); }`n" | Set-Content "$checkDir/rust/main.rs" -NoNewline
        "print('spiral-check-cuda', 6 * 7)`n" | Set-Content "$checkDir/cuda/main.py" -NoNewline
        $protocol = GetFullPath "$checkDir/protocol ü"
        New-Item -ItemType Directory -Force "$protocol/rust" | Out-Null
        ('print("child output: \"quoted\"")' + "`n") | Set-Content "$protocol/child with spaces.py" -NoNewline
        ('raise RuntimeError("protocol-child-failure")' + "`n") | Set-Content "$protocol/child raises.py" -NoNewline
        ('raise RuntimeError("cupy_backends.cuda.api.runtime.CUDARuntimeError: cudaErrorInsufficientDriver")' + "`n") | Set-Content "$protocol/cuda driver.py" -NoNewline
        ('fn main() { let _x: i32 = "rust-protocol-failure"; }' + "`n") | Set-Content "$protocol/rust/main.rs" -NoNewline
        ('print("lua-print", 1)' + "`n" + 'io.write("lua-", "write")' + "`n" + 'return 6 * 7' + "`n") | Set-Content "$protocol/main with spaces.lua" -NoNewline
        ('error("lua-protocol-failure")' + "`n") | Set-Content "$protocol/lua error.lua" -NoNewline
        $cases = @(
            @{ name = "rust"; args = @("rust", "--rs-path", (GetFullPath "$checkDir/rust/main.rs")); expect = "output"; text = "spiral-check-rust 42" }
            @{ name = "cuda"; args = @("cuda", "--py-path", (GetFullPath "$checkDir/cuda/main.py")); expect = "output"; text = "spiral-check-cuda 42" }
            @{ name = "lua"; args = @("lua", "--lua-path", (GetFullPath "$checkDir/lua/main.lua")); expect = "output"; text = "spiral-check-lua`t42" }
            @{ name = "gleam"; args = @("gleam", "--gleam-path", (GetFullPath "$checkDir/gleam/main.gleam")); expect = "exact"; text = "spiral-check-gleam 42" }
            foreach ($level in "", "Verbose", "Debug", "Info", "Warning", "Critical") {
                @{ name = "protocol-level-$(if ($level) { $level } else { 'unset' })"; level = $level; args = @("cuda", "--py-path", "$protocol/child with spaces.py"); expect = "output"; text = 'child output: "quoted"' }
            }
            @{ name = "protocol-child-exception"; args = @("cuda", "--py-path", "$protocol/child raises.py"); expect = "failure"; text = "protocol-child-failure" }
            @{ name = "protocol-cuda-driver"; args = @("cuda", "--py-path", "$protocol/cuda driver.py"); expect = "failure"; text = "cudaErrorInsufficientDriver" }
            @{ name = "protocol-rust-build"; args = @("rust", "--rs-path", "$protocol/rust/main.rs"); expect = "failure"; text = "rust-protocol-failure" }
            @{ name = "protocol-lua-output"; args = @("lua", "--lua-path", "$protocol/main with spaces.lua"); expect = "exact"; text = "lua-print`t1`nlua-write" }
            @{ name = "protocol-lua-error"; args = @("lua", "--lua-path", "$protocol/lua error.lua"); expect = "failure"; text = "lua-protocol-failure" })
        foreach ($case in $cases) {
            $env:TRACE_LEVEL = $case.level
            $json = & $newExe @($case.args) 2> "$checkDir/$($case.name).err" | ForEach-Object { "$_" }
            $caseExit = $LASTEXITCODE
            $stdout = $json -join "`n"
            $stderr = "$(Get-Content -Raw "$checkDir/$($case.name).err" -ErrorAction Ignore)"
            $output = try {
                $result = $stdout | ConvertFrom-Json
                if ($result.command_result) { $result = $result.command_result | ConvertFrom-Json }
                $result.output
            } catch { "<no JSON> $stdout" }
            $passed = switch ($case.expect) {
                "output" { $caseExit -eq 0 -and "$output" -match [regex]::Escape($case.text) }
                "exact" { $caseExit -eq 0 -and "$output".Trim() -ceq $case.text }
                "failure" { $caseExit -ne 0 -and "$stdout`n$stderr".Contains($case.text) -and -not $stdout.Contains('"command_result"') }
            }
            Write-Output "spiral/apps/spiral/build.ps1 / run check / $($case.name): exit $caseExit / $(("$output" -replace '\s+', ' ').Trim())"
            if (-not $passed) {
                $stderr -split "`n" | Select-Object -Last 40 | ForEach-Object { Write-Output "spiral/apps/spiral/build.ps1 / run check / $($case.name) stderr / $_" }
                $failures += "$($case.name): exit $caseExit, expected $($case.expect) '$($case.text)': $output"
            }
        }
    } finally {
        $env:SPIRAL_JSON = $spiralJson
        Remove-Item Env:TRACE_LEVEL -ErrorAction Ignore
    }
} finally {
    $env:TRACE_LEVEL = $traceLevel
}
if ($failures) {
    $failures | ForEach-Object { Write-Output "spiral/apps/spiral/build.ps1 / run check / FAILED / $_" }
    throw "RUST-FAILED apps/spiral / run check: $($failures.Count) failure(s), the previous CLI stays"
}
Write-Output "RUST-OK apps/spiral"

MoveExeAside
New-Item -ItemType Directory -Force (Split-Path $exe) | Out-Null
Copy-Item $newExe $exe
Write-Output "spiral/apps/spiral/build.ps1 / shipped the new $projectName$(_exe) to $exe"

Write-Output "spiral/apps/spiral/build.ps1 / `$projectName: $projectName / `$env:CI:'$env:CI'"

if ($env:CI) {
    $targetDir | Remove-Item -Recurse -Force -ErrorAction Ignore
    ClearCargoTarget "../../target/spiral/spiral"
    ClearCargoTarget "../../target/spiral/spiral_contract"
}
