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
$jobs = Join-Path $work 'jobs.tsv'
$results = Join-Path $work 'results.tsv'
$rows | ForEach-Object { "$($_.Member)`tRust`t$($_.Input)`t$($_.Output)`t$($TimeoutSec * 1000)" } |
    Set-Content -LiteralPath $jobs -Encoding utf8NoBOM
$rows | Export-Csv -LiteralPath (Join-Path $work 'owners.csv') -NoTypeInformation
$previousWorkspace = $env:SPIRAL_WORKSPACE_ROOT
try {
    $env:SPIRAL_WORKSPACE_ROOT = $BundleRoot
    Write-Host "Regenerating $($rows.Count) primary EOIE owners: $work"
    & $dotnet $compiler --batch $jobs $results --timeout-ms ($TimeoutSec * 1000)
} finally {
    $env:SPIRAL_WORKSPACE_ROOT = $previousWorkspace
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
