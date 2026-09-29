[CmdletBinding()]
param(
    [string]$EoieRoot,
    [string]$Filter = '.*',
    [ValidateRange(1, 600)][int]$TimeoutSec = 180,
    [switch]$CargoCheck,
    [switch]$Test,
    [switch]$CompilerContracts,
    [switch]$Offline
)
$ErrorActionPreference = 'Stop'
if ($CompilerContracts -and -not $Test) { throw '-CompilerContracts requires -Test.' }
. $PSScriptRoot/spiral-compiler.ps1
if (-not $EoieRoot) { $EoieRoot = Join-Path $PSScriptRoot '..' }
$EoieRoot = (Resolve-Path -LiteralPath $EoieRoot).Path
$dotnet = Resolve-SpiralDotnet
$compiler = Get-SpiralCompilerDll 'single-flight'
$work = Join-Path (Get-SpiralCacheDir) ('eoie-regeneration/' + [guid]::NewGuid().ToString('N'))
$staged = Join-Path $work 'eoie'
function Copy-Workspace([string]$From, [string]$To) {
    New-Item -ItemType Directory -Path $To -Force | Out-Null
    foreach ($entry in Get-ChildItem -LiteralPath $From -Force) {
        if ($entry.Attributes -band [IO.FileAttributes]::ReparsePoint) { throw "Unexpected workspace link: $($entry.FullName)" }
        if ($entry.PSIsContainer) {
            if ($entry.Name -notin @('target', 'vendor', '.git', '.cache')) {
                Copy-Workspace $entry.FullName (Join-Path $To $entry.Name)
            }
        } elseif ($entry.Name -notin @('eoie', 'eoie.exe')) {
            Copy-Item -LiteralPath $entry.FullName -Destination (Join-Path $To $entry.Name)
        }
    }
}
Copy-Workspace $EoieRoot $staged
$sourceRoot = Join-Path $staged 'src'
$workspace = [IO.File]::ReadAllText((Join-Path $sourceRoot 'Cargo.toml'))
$memberBlock = [regex]::Match($workspace, '(?s)members\s*=\s*\[(.*?)\]')
if (-not $memberBlock.Success) { throw 'Cannot find explicit Cargo workspace members.' }
$members = [regex]::Matches($memberBlock.Groups[1].Value, '"([^"]+)"')
$rows = @()
foreach ($memberMatch in $members) {
    $member = $memberMatch.Groups[1].Value
    if ($member -notmatch $Filter) { continue }
    $directory = Join-Path $sourceRoot $member
    $manifest = [IO.File]::ReadAllText((Join-Path $directory 'Cargo.toml'))
    # The first target is the production library/binary. Auxiliary probes remain
    # committed consumers and are checked by Cargo against regenerated owners.
    $target = [regex]::Match($manifest, '(?m)^path\s*=\s*"([^"]+\.rs)"')
    if (-not $target.Success) { throw "No explicit primary Cargo target: $member" }
    $rustPath = Join-Path $directory $target.Groups[1].Value
    $sameStem = [IO.Path]::ChangeExtension($rustPath, '.spi')
    $entry = if ($member -eq 'rust_std_fs') { Join-Path $directory 'runtime_main.spi' }
        elseif ((Test-Path -LiteralPath $sameStem) -and (Select-String -LiteralPath $sameStem -Pattern '^inl main ' -Quiet)) { $sameStem }
        elseif (Test-Path -LiteralPath (Join-Path $directory 'main.spi')) { Join-Path $directory 'main.spi' }
        elseif (Test-Path -LiteralPath (Join-Path $directory 'crate_main.spi')) { Join-Path $directory 'crate_main.spi' }
        else { throw "Cannot identify primary Spiral entry for $member" }
    if (-not (Select-String -LiteralPath $entry -Pattern '^inl main ' -Quiet)) {
        throw "Chosen entry has no main: $entry"
    }
    $output = Join-Path $work "outputs/$member.rs"
    $rows += [pscustomobject]@{ Member = $member; Input = $entry; Output = $output; Target = $rustPath }
}
if (-not $rows.Count) { throw 'No regeneration owners selected.' }
New-Item -ItemType Directory -Path (Join-Path $work 'outputs') -Force | Out-Null
New-Item -ItemType Directory -Path (Join-Path $work 'logs') -Force | Out-Null
$results = Join-Path $work 'results.tsv'
$rows | Export-Csv -LiteralPath (Join-Path $work 'owners.csv') -NoTypeInformation
$previousWorkspace = $env:SPIRAL_WORKSPACE_ROOT
$previousBudget = $env:SPIRAL_BUILD_BUDGET_MS
try {
    $env:SPIRAL_WORKSPACE_ROOT = $BundleRoot
    # One compiler process per owner. A second BuildFile in the same process can
    # sit until the batch timeout, which used to stop the remaining owners.
    Write-Host "Regenerating $($rows.Count) primary EOIE owners: $work"
    $encoding = [Text.UTF8Encoding]::new($false)
    $writer = [IO.StreamWriter]::new($results, $false, $encoding)
    try {
        $writer.AutoFlush = $true
        foreach ($row in $rows) {
            $timeoutMs = $TimeoutSec * 1000
            $stdout = Join-Path $work "logs/$($row.Member).out"
            $stderr = Join-Path $work "logs/$($row.Member).err"
            $env:SPIRAL_BUILD_BUDGET_MS = [string]([Math]::Max(1000, $timeoutMs - 3000))
            $watch = [Diagnostics.Stopwatch]::StartNew()
            # -WindowStyle is Windows-only. Linux pwsh rejects the parameter before any owner compiles.
            $launch = @{
                FilePath = $dotnet
                ArgumentList = @($compiler, '--backend', 'Rust', $row.Input, $row.Output)
                WorkingDirectory = $work
                PassThru = $true
                RedirectStandardOutput = $stdout
                RedirectStandardError = $stderr
            }
            if ($IsWindows) { $launch.WindowStyle = 'Hidden' }
            $proc = Start-Process @launch
            if (-not $proc.WaitForExit($timeoutMs)) {
                try { $proc.Kill($true) } catch { try { $proc.Kill() } catch {} }
                $null = $proc.WaitForExit(10000)
                $writer.WriteLine("$($row.Member)`ttimeout`t$($watch.ElapsedMilliseconds)`tno result within $timeoutMs ms")
                Write-Host "$($row.Member) timeout $($watch.ElapsedMilliseconds) ms"
                continue
            }
            $elapsed = $watch.ElapsedMilliseconds
            if ($proc.ExitCode -eq 0 -and (Test-Path -LiteralPath $row.Output)) {
                $bytes = (Get-Item -LiteralPath $row.Output).Length
                $writer.WriteLine("$($row.Member)`tok`t$elapsed`tbytes=$bytes entry=main revision=process")
                Write-Host "$($row.Member) ok $elapsed ms ($bytes bytes)"
            } else {
                $detail = ''
                if (Test-Path -LiteralPath $stderr) {
                    $detail = ([IO.File]::ReadAllText($stderr) -replace '[\t\r\n]', ' ').Trim()
                }
                if (-not $detail -and (Test-Path -LiteralPath $stdout)) {
                    $detail = ([IO.File]::ReadAllText($stdout) -replace '[\t\r\n]', ' ').Trim()
                }
                if ($detail.Length -gt 500) { $detail = $detail.Substring(0, 500) }
                if (-not $detail) { $detail = "compiler exit $($proc.ExitCode)" }
                $writer.WriteLine("$($row.Member)`terror`t$elapsed`t$detail")
                Write-Host "$($row.Member) error $elapsed ms $detail"
            }
        }
    } finally {
        $writer.Dispose()
    }
} finally {
    $env:SPIRAL_WORKSPACE_ROOT = $previousWorkspace
    if ($null -eq $previousBudget) { Remove-Item Env:SPIRAL_BUILD_BUDGET_MS -ErrorAction SilentlyContinue }
    else { $env:SPIRAL_BUILD_BUDGET_MS = $previousBudget }
}
$compiled = @(Import-Csv -LiteralPath $results -Delimiter "`t" -Header 'owner','status','elapsed','detail')
$failed = @($compiled | Where-Object status -ne 'ok')
Write-Host "Emitted: $(@($compiled | Where-Object status -eq 'ok').Count)/$($rows.Count); results: $results"
if ($failed.Count -or $compiled.Count -ne $rows.Count) {
    $failed | Format-Table owner,status,detail -Wrap
    throw "EOIE regeneration incomplete; committed Rust was not replaced. Results: $results"
}
foreach ($row in $rows) {
    if (-not (Test-Path -LiteralPath $row.Output)) { throw "Missing emitted owner: $($row.Member)" }
    Copy-Item -LiteralPath $row.Output -Destination $row.Target
}
if ($CargoCheck) {
    $cargoArgs = @('check', '--manifest-path', (Join-Path $sourceRoot 'Cargo.toml'), '--target-dir', (Join-Path $sourceRoot 'target'), '--workspace', '--all-targets', '--locked')
    if ($Offline) { $cargoArgs += '--offline' }
    & cargo @cargoArgs
    if ($LASTEXITCODE -ne 0) { throw "Cargo rejected regenerated EOIE owners: $staged" }
}
if ($Test) {
    $previousDotnet = $env:EOIE_DOTNET
    $previousBundle = $env:EOIE_SPIRAL_BUNDLE
    try {
        $env:EOIE_DOTNET = $dotnet
        $env:EOIE_SPIRAL_BUNDLE = $BundleRoot
        & (Join-Path $staged 'build.ps1') -Test -CompilerContracts:$CompilerContracts -Offline:$Offline -SpiralCompiler $compiler
        if ($LASTEXITCODE -ne 0) { throw "Regenerated EOIE runtime contracts failed: $staged" }
    } finally {
        $env:EOIE_DOTNET = $previousDotnet
        $env:EOIE_SPIRAL_BUNDLE = $previousBundle
    }
}
Write-Host "EOIE regeneration passed for $($rows.Count) selected owners. Staged workspace: $staged"
