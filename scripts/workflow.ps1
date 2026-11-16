param(
    $fast,
    [switch] $Compiler,
    [switch] $K3s,
    [string] $Suite = 'all',
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"


pwsh init.ps1

. ./core.ps1

if ($K3s) {
    if (-not $IsLinux) { throw '-K3s starts a throwaway k3s server and needs a Linux host with sudo' }
    $k3sVersion = 'v1.37.2+k3s1'
    $work = Join-Path ($env:RUNNER_TEMP ?? [IO.Path]::GetTempPath()) "k3s-smoke-$PID"
    New-Item -ItemType Directory -Force $work | Out-Null
    $release = "https://github.com/k3s-io/k3s/releases/download/$([uri]::EscapeDataString($k3sVersion))"
    $k3sBin = Join-Path $work 'k3s'
    { curl -fsSL --retry 3 -o $k3sBin "$release/k3s" } | Invoke-Block
    { curl -fsSL --retry 3 -o (Join-Path $work 'sha256sum-amd64.txt') "$release/sha256sum-amd64.txt" } | Invoke-Block
    $expected = (Get-Content (Join-Path $work 'sha256sum-amd64.txt') | Where-Object { $_ -match '\s+k3s$' } | Select-Object -First 1) -split '\s+' | Select-Object -First 1
    $actual = (Get-FileHash -Algorithm SHA256 $k3sBin).Hash.ToLower()
    if (-not $expected -or $actual -ne $expected) { throw "k3s $k3sVersion binary sha256 $actual does not match the release's $expected" }
    chmod +x $k3sBin
    $kubectl = { & sudo -n $k3sBin kubectl @args }
    $server = Start-Process sudo -ArgumentList @('-n', $k3sBin, 'server', '--disable', 'traefik', '--disable', 'metrics-server') -RedirectStandardOutput (Join-Path $work 'server.out') -RedirectStandardError (Join-Path $work 'server.log') -PassThru
    $ns = "k3s-smoke-$PID"
    $forward = $null
    try {
        $deadline = (Get-Date).AddMinutes(4)
        while (-not ((& $kubectl get nodes --no-headers 2>$null) -match '\sReady\s')) {
            if ((Get-Date) -gt $deadline) { Get-Content (Join-Path $work 'server.log') -Tail 40; throw "k3s $k3sVersion node never reached Ready" }
            Start-Sleep -Seconds 3
        }
        "k3s: $k3sVersion node Ready"
        $image = Join-Path $work 'compiler.tar'
        { docker build -t spiral-compiler:local -f ../infra/k3s-compiler/Dockerfile ../apps/compiler } | Invoke-Block
        { docker save -o $image spiral-compiler:local } | Invoke-Block
        { sudo -n $k3sBin ctr -n k8s.io images import $image } | Invoke-Block
        Remove-Item $image
        { & $kubectl create namespace $ns } | Invoke-Block
        { & $kubectl apply -n $ns -f ../infra/k3s-compiler/compiler.yaml } | Invoke-Block
        { & $kubectl rollout status -n $ns deployment/spiral-compiler --timeout=600s } | Invoke-Block
        $pod = (& $kubectl get pods -n $ns -l app=spiral-compiler -o 'jsonpath={.items[0].metadata.name}')
        Get-Content -Raw ../lib/spiral/unicode.spi | & sudo -n $k3sBin kubectl exec -i -n $ns $pod -- sh -c 'cat > /work/smoke.spi'
        if ($LASTEXITCODE -ne 0) { throw "copying the smoke source into $pod exited $LASTEXITCODE" }
        $forward = Start-Process sudo -ArgumentList @('-n', $k3sBin, 'kubectl', 'port-forward', '-n', $ns, 'svc/spiral-compiler', '17470:7470') -RedirectStandardOutput (Join-Path $work 'forward.out') -RedirectStandardError (Join-Path $work 'forward.log') -PassThru
        $reply = $null
        for ($try = 1; $try -le 20 -and -not $reply; $try++) {
            Start-Sleep -Seconds 2
            try {
                $client = [Net.Sockets.TcpClient]::new('127.0.0.1', 17470)
                $stream = $client.GetStream()
                $writer = [IO.StreamWriter]::new($stream, [Text.UTF8Encoding]::new($false))
                $writer.NewLine = "`n"
                $writer.WriteLine("test-blocks`t/work/smoke.spi")
                $writer.Flush()
                $reader = [IO.StreamReader]::new($stream)
                while ($null -ne ($line = $reader.ReadLine())) { if ($line.StartsWith("spiral-session`t")) { $reply = $line; break } }
                $client.Dispose()
            }
            catch { "k3s: port-forward not answering yet ($try): $($_.Exception.Message)" }
        }
        if (-not $reply) { throw 'spiral-compiler never answered test-blocks through the k3s Service' }
        $fields = $reply -split "`t"
        if ($fields[1] -ne 'test-blocks' -or [int]$fields[3] -lt 1) { throw "spiral-compiler answered '$reply', expected a test-blocks reply with at least one block" }
        "k3s: spiral-compiler ready behind its Service and answered test-blocks with $($fields[3]) block(s) ($k3sVersion)"
    }
    finally {
        if ($forward) { & sudo -n kill $forward.Id 2>$null }
        & $kubectl delete namespace $ns --wait=true --timeout=180s 2>$null | Out-Null
        $left = @(& $kubectl get all -n $ns --no-headers 2>$null)
        & sudo -n kill $server.Id 2>$null
        if ($left.Count -gt 0) { throw "k3s smoke left $($left.Count) object(s) in $ns after the delete" }
    }
    return
}

if ($Compiler) {
    $resolveDotnet = ". ../apps/compiler/scripts/env.ps1; try { Resolve-SpiralDotnet } catch { '' }"
    $dotnet = pwsh -NoProfile -Command $resolveDotnet | Select-Object -Last 1
    if (-not $dotnet) {
        { pwsh ../apps/compiler/scripts/install-dotnet.ps1 } | Invoke-Block
        $dotnet = pwsh -NoProfile -Command $resolveDotnet | Select-Object -Last 1
    }
    if (-not $dotnet) { throw 'no .NET 11 SDK after install-dotnet.ps1' }
    $env:SPIRAL_DOTNET = $dotnet
    "dotnet: $dotnet"

    { pwsh ../apps/compiler/scripts/build.ps1 -Mode single-flight } | Invoke-Block

    { pwsh ../apps/compiler/scripts/formatter/report.ps1 } | Invoke-Block

    $matrixRustToolchain = [regex]::Match([IO.File]::ReadAllText((Resolve-Path ../apps/compiler/scripts/test.ps1)), "'\+((?:nightly-)?[0-9][0-9.-]*)', '-C', 'opt-level").Groups[1].Value
    if (-not $matrixRustToolchain) { throw 'test.ps1 no longer names the matrix rustc toolchain' }
    { rustup toolchain install $matrixRustToolchain --profile minimal } | Invoke-Block

    if ($IsLinux) {
        $pins = @{ Lean = 'v4.35.0'; Wasmtime = 'v39.0.1'; Kotlin = '2.4.21'; Swift = '6.3.1' }
        $tools = Join-Path ($env:RUNNER_TEMP ?? [IO.Path]::GetTempPath()) 'spiral-ci-tools'
        New-Item -ItemType Directory -Force $tools | Out-Null

        { curl -fsSL --retry 3 -o (Join-Path $tools 'elan-init.sh') https://raw.githubusercontent.com/leanprover/elan/master/elan-init.sh } | Invoke-Block
        { sh (Join-Path $tools 'elan-init.sh') -y --no-modify-path --default-toolchain "leanprover/lean4:$($pins.Lean)" } | Invoke-Block
        $env:SPIRAL_LEAN = Join-Path $HOME '.elan/bin/lean'

        $wasmtimeDir = "wasmtime-$($pins.Wasmtime)-x86_64-linux"
        { curl -fsSL --retry 3 -o (Join-Path $tools 'wasmtime.tar.xz') "https://github.com/bytecodealliance/wasmtime/releases/download/$($pins.Wasmtime)/$wasmtimeDir.tar.xz" } | Invoke-Block
        { tar -xJf (Join-Path $tools 'wasmtime.tar.xz') -C $tools } | Invoke-Block
        $env:SPIRAL_WASMTIME = Join-Path $tools "$wasmtimeDir/wasmtime"

        { curl -fsSL --retry 3 -o (Join-Path $tools 'kotlin.zip') "https://github.com/JetBrains/kotlin/releases/download/v$($pins.Kotlin)/kotlin-compiler-$($pins.Kotlin).zip" } | Invoke-Block
        { unzip -q -o (Join-Path $tools 'kotlin.zip') -d $tools } | Invoke-Block
        $env:SPIRAL_KOTLINC = Join-Path $tools 'kotlinc/bin/kotlinc'

        $swiftRelease = "swift-$($pins.Swift)-RELEASE"
        { curl -fsSL --retry 3 -o (Join-Path $tools 'swift.tar.gz') "https://download.swift.org/swift-$($pins.Swift)-release/ubuntu2404/$swiftRelease/$swiftRelease-ubuntu24.04.tar.gz" } | Invoke-Block
        { tar -xzf (Join-Path $tools 'swift.tar.gz') -C $tools } | Invoke-Block
        $env:SPIRAL_SWIFTC = Join-Path $tools "$swiftRelease-ubuntu24.04/usr/bin/swiftc"

        { sudo apt-get install -y -q fp-compiler } | Invoke-Block
        $env:SPIRAL_FPC = (Get-Command fpc).Source

        foreach ($tool in 'SPIRAL_LEAN', 'SPIRAL_WASMTIME', 'SPIRAL_KOTLINC', 'SPIRAL_SWIFTC', 'SPIRAL_FPC') {
            $path = [Environment]::GetEnvironmentVariable($tool)
            if (-not $path -or -not (Test-Path $path)) { throw "$tool was not installed: '$path'" }
            "${tool}: $path"
        }
    }

    $binTail = 'bin/single-flight/SpiralCompiler/Release/net11.0'
    $ctlDir = $env:SPIRAL_CTL_COMPILER_DIR
    $suiteResults = {
        param($cacheDir, $log, [switch] $Accept)
        $env:SPIRAL_BIN_CACHE_DIR = $cacheDir
        pwsh ../apps/compiler/scripts/test.ps1 -Mode single-flight -Suite $Suite -Native -Parallel 4 @($Accept ? @('-Accept') : @()) *> $log
        $code = $LASTEXITCODE
        $path = (Select-String -Path $log -Pattern 'results: (.*results\.tsv)' | Select-Object -Last 1).Matches.Groups[1].Value
        Get-Content $log -Tail 25
        [pscustomobject]@{ Code = $code; Results = $path }
    }
    $trtCache = $env:SPIRAL_BIN_CACHE_DIR
    $work = Join-Path ($env:RUNNER_TEMP ?? [IO.Path]::GetTempPath()) 'spiral-ab'
    New-Item -ItemType Directory -Force $work | Out-Null
    $ctl = $null
    if ($ctlDir -and (Test-Path (Join-Path $ctlDir "$binTail/SpiralCompiler.dll"))) {
        $ctlCache = Join-Path $work 'ctl-cache'
        New-Item -ItemType Directory -Force (Join-Path $ctlCache 'bin/single-flight/SpiralCompiler/Release') | Out-Null
        Copy-Item -Recurse -Force (Join-Path $ctlDir $binTail) (Join-Path $ctlCache 'bin/single-flight/SpiralCompiler/Release')
        if (Test-Path (Join-Path $trtCache 'toolchains')) { New-Item -ItemType SymbolicLink -Path (Join-Path $ctlCache 'toolchains') -Target (Join-Path $trtCache 'toolchains') | Out-Null }
        "ctl: last green compiler from $ctlDir"
        $ctl = & $suiteResults $ctlCache (Join-Path $work 'suite-ctl.log')
    }
    else { 'ctl: no cached last-green compiler, so this run only records the trt arm' }
    $trt = & $suiteResults $trtCache (Join-Path $work 'suite-trt.log') -Accept
    $env:SPIRAL_BIN_CACHE_DIR = $trtCache
    if (-not $trt.Results -or -not (Test-Path $trt.Results)) { throw "the trt suite wrote no results.tsv (exit $($trt.Code))" }
    $changed = @()
    if ($ctl -and $ctl.Results -and (Test-Path $ctl.Results)) {
        $before = @{}
        foreach ($row in Import-Csv $ctl.Results -Delimiter "`t") { $before["$($row.id)|$($row.backend)"] = $row }
        foreach ($row in Import-Csv $trt.Results -Delimiter "`t") {
            $old = $before["$($row.id)|$($row.backend)"]
            if (-not $old) { continue }
            $fields = @('compile', 'native', 'exit', 'stdout') | Where-Object { $old.$_ -ne $row.$_ }
            if ($fields) { $changed += "$($row.id) [$($row.backend)] " + (($fields | ForEach-Object { "$_ $($old.$_)->$($row.$_)" }) -join ', ') }
        }
        "ab: $($before.Count) ctl rows, $($changed.Count) changed between ctl and trt"
        $changed | Select-Object -First 60 | ForEach-Object { "  $_" }
        $changed | Set-Content (Join-Path $trtCache 'ab-changed.txt')
    }
    elseif (-not $ctl -and $trt.Code -ne 0) { throw "the trt suite exited $($trt.Code) and there is no ctl arm to compare against" }
    elseif ($ctl) { throw "the ctl suite wrote no results.tsv (exit $($ctl.Code))" }
    if ($changed) { throw "$($changed.Count) row(s) changed between the last green compiler and this one; see ab-changed.txt" }
    if ($ctlDir) {
        if (Test-Path $ctlDir) { Remove-Item -Recurse -Force $ctlDir }
        New-Item -ItemType Directory -Force (Join-Path $ctlDir 'bin/single-flight/SpiralCompiler/Release') | Out-Null
        Copy-Item -Recurse -Force (Join-Path $trtCache $binTail) (Join-Path $ctlDir 'bin/single-flight/SpiralCompiler/Release')
        "ctl: this green compiler is staged in $ctlDir for the cache to save"
    }

    return
}

{ pwsh dir-tree-html.ps1 } | Invoke-Block

{ pwsh ../apps/spiral/build.ps1 -fast 1 } | Invoke-Block

{ pwsh build.ps1 } | Invoke-Block

{ pwsh outdated.ps1 } | Invoke-Block

{ pwsh publish.ps1 } | Invoke-Block
