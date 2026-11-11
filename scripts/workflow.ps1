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

    { pwsh ../apps/compiler/scripts/test.ps1 -Mode single-flight -Suite $Suite -Native -Parallel 2 -Accept } | Invoke-Block

    return
}

{ pwsh dir-tree-html.ps1 } | Invoke-Block

{ pwsh ../apps/spiral/build.ps1 -fast 1 } | Invoke-Block

{ pwsh build.ps1 } | Invoke-Block

{ pwsh outdated.ps1 } | Invoke-Block

{ pwsh publish.ps1 } | Invoke-Block
