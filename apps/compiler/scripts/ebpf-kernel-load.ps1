param(
    [string] $Samples = (Join-Path $PSScriptRoot '../tmp/samples'),
    [string] $Work = (Join-Path ([IO.Path]::GetTempPath()) "ebpf-kernel-load-$PID")
)
$ErrorActionPreference = 'Stop'
if (-not $IsLinux) { throw 'kernel-load.ps1 loads programs into the running Linux kernel; run it on a Linux runner' }
function Find-Named($node, [string] $name) {
    if ($null -eq $node) { return $null }
    if ($node -is [System.Collections.IEnumerable] -and $node -isnot [string]) {
        foreach ($item in $node) { $found = Find-Named $item $name; if ($null -ne $found) { return $found } }
        return $null
    }
    if ($node -is [pscustomobject]) {
        foreach ($property in $node.PSObject.Properties) {
            if ($property.Name -eq $name) { return [int]$property.Value }
            $found = Find-Named $property.Value $name
            if ($null -ne $found) { return $found }
        }
    }
    $null
}
"kernel $(uname -r); $((clang --version | Select-Object -First 1)); $((sudo bpftool version | Select-Object -First 1)); $((gcc --version | Select-Object -First 1))"
New-Item -ItemType Directory -Force $Work | Out-Null
$packet = Join-Path $Work 'packet.bin'
[IO.File]::WriteAllBytes($packet, [byte[]]::new(64))
$rows = foreach ($source in Get-ChildItem $Samples -Recurse -Filter main.ebpf) {
    $id = [IO.Path]::GetRelativePath($Samples, $source.DirectoryName).Replace('\', '/')
    $name = 'spiral_' + ($id -replace '[^A-Za-z0-9]', '_')
    $object = Join-Path $Work "$name.o"
    $hostExe = Join-Path $Work "$name.host"
    $pin = "/sys/fs/bpf/$name"
    $maps = "/sys/fs/bpf/${name}_maps"
    $verdict = 'ok'
    $kernelValue = ''
    gcc -std=c11 -O2 -w -x c $source.FullName -o $hostExe
    if ($LASTEXITCODE -ne 0) { $verdict = 'host-build-fail' }
    else {
        & $hostExe | Out-Null
        $hostExit = $LASTEXITCODE
        clang -O2 -g -target bpf -x c -c $source.FullName -o $object
        if ($LASTEXITCODE -ne 0) { $verdict = 'bpf-build-fail' }
        else {
            sudo bpftool prog load $object $pin type socket pinmaps $maps 2>&1 | Out-Null
            if ($LASTEXITCODE -ne 0) { $verdict = 'verifier-reject' }
            else {
                sudo bpftool prog run pinned $pin data_in $packet repeat 1 2>&1 | Out-Null
                if ($LASTEXITCODE -ne 0) { $verdict = 'run-fail' }
                else {
                    $bss = @(sudo ls $maps 2>$null) | Where-Object { $_ -like '*bss*' } | Select-Object -First 1
                    if (-not $bss) { $verdict = 'no-bss' }
                    else {
                        $dump = sudo bpftool map dump pinned "$maps/$bss" -j | ConvertFrom-Json
                        $kernelValue = Find-Named @($dump)[0].formatted 'spiral_exit_code'
                        if ($null -eq $kernelValue) { $verdict = 'no-exit-symbol' }
                        elseif ($kernelValue -eq -2147483647) { $verdict = 'loop-capped' }
                        elseif (($kernelValue -band 255) -ne $hostExit) { $verdict = "differs host=$hostExit kernel=$kernelValue" }
                    }
                }
                sudo rm -rf $pin $maps
            }
        }
    }
    [pscustomobject]@{ id = $id; verdict = $verdict; kernel = $kernelValue }
}
$rows | Format-Table -AutoSize | Out-String -Width 200
$rows | Group-Object verdict | ForEach-Object { "$($_.Name): $($_.Count)" }
if ($rows | Where-Object verdict -ne 'ok') { exit 1 }
