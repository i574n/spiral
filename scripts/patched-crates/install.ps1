param(
    [Parameter(Mandatory)] [string] $Name,
    [string] $CargoRoot = $(if ($env:CARGO_HOME) { $env:CARGO_HOME } else { Join-Path $HOME '.cargo' })
)
$ErrorActionPreference = 'Stop'

$crateDir = Join-Path $PSScriptRoot $Name
$pin = Import-PowerShellDataFile (Join-Path $crateDir 'crate.psd1')
$patch = Join-Path $crateDir "$($pin.Version).patch"
$patchHash = (Get-FileHash $patch -Algorithm SHA256).Hash
$identity = "$Name $($pin.Version) $($pin.Sha256) $patchHash"

$stampDir = Join-Path $CargoRoot 'bin/.patched-crates'
$stamp = Join-Path $stampDir $Name
if ((Test-Path $stamp) -and (Get-Content $stamp -Raw).Trim() -eq $identity) {
    Write-Output "patched-crates / $Name $($pin.Version) already installed"
    return
}

$work = Join-Path ([IO.Path]::GetTempPath()) "patched-crate-$Name-$([guid]::NewGuid().ToString('N'))"
New-Item -ItemType Directory -Force $work | Out-Null
try {
    $archive = Join-Path $work "$Name-$($pin.Version).crate"
    Invoke-WebRequest "https://crates.io/api/v1/crates/$Name/$($pin.Version)/download" -OutFile $archive -UserAgent 'spiral-patched-crates'
    $actual = (Get-FileHash $archive -Algorithm SHA256).Hash
    if ($actual -ne $pin.Sha256) { throw "patched-crates / $Name $($pin.Version): crate sha256 $actual, pinned $($pin.Sha256)" }

    tar -xzf $archive -C $work
    if ($LASTEXITCODE -ne 0) { throw "patched-crates / ${Name}: tar exited $LASTEXITCODE" }
    $source = Join-Path $work "$Name-$($pin.Version)"

    git -C $source -c core.autocrlf=false apply --whitespace=nowarn $patch
    if ($LASTEXITCODE -ne 0) { throw "patched-crates / ${Name}: $patch no longer applies to $($pin.Version)" }

    cargo install --path $source --locked --force --root $CargoRoot
    if ($LASTEXITCODE -ne 0) { throw "patched-crates / ${Name}: cargo install exited $LASTEXITCODE" }

    New-Item -ItemType Directory -Force $stampDir | Out-Null
    [IO.File]::WriteAllText($stamp, "$identity`n")
    Write-Output "patched-crates / $Name $($pin.Version) installed with $(Split-Path $patch -Leaf)"
}
finally {
    Remove-Item $work -Recurse -Force -ErrorAction Ignore
}
