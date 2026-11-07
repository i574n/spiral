param(
    [string] $Dll = '',
    [Parameter(Mandatory)] [string] $Out,
    [string] $Filter = '*',
    [int] $TimeoutSec = 60,
    [switch] $UseCommitted
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot '..\scripts\env.ps1')
$dotnet = Resolve-SpiralDotnet
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
$env:DOTNET_ROOT = Split-Path $dotnet
$env:SPIRAL_WORKSPACE_ROOT = $BundleRoot
$fpc = if ($env:SPIRAL_FPC) { $env:SPIRAL_FPC } else { Join-Path $HOME 'scoop\apps\freepascal\3.3.1-20261025\bin\i386-win32\fpc.exe' }
$root = (Resolve-Path (Join-Path $PSScriptRoot '..\tmp\samples')).Path + '\'
$samples = @(Get-ChildItem $root -Recurse -Filter main.pas | ForEach-Object DirectoryName | Sort-Object -Unique | Where-Object { (Split-Path $_ -Leaf) -like $Filter })
$work = Join-Path ([IO.Path]::GetTempPath()) "delphi-heaptrc-$PID"
New-Item -ItemType Directory -Force $work | Out-Null
"sample`tcompile`tbuild`texit`tstdout`tunfreed" | Set-Content $Out
try {
    foreach ($dir in $samples) {
        $name = $dir.Substring($root.Length)
        $case = Join-Path $work ($name -replace '[\\/]', '_')
        New-Item -ItemType Directory -Force $case | Out-Null
        $pas = Join-Path $case 'main.pas'
        if ($UseCommitted) { Copy-Item (Join-Path $dir 'main.pas') $pas }
        else {
            $p = Start-Process -FilePath $dotnet -ArgumentList @($Dll, '--backend', 'Pascal', $(if (Test-Path (Join-Path $dir 'main.spi')) { Join-Path $dir 'main.spi' } else { Join-Path $dir 'main.spir' }), $pas) -WindowStyle Hidden -PassThru -RedirectStandardOutput "$case\compile.out" -RedirectStandardError "$case\compile.err"
            if (-not $p.WaitForExit($TimeoutSec * 1000)) { $p.Kill($true); "$name`ttimeout`t-`t-`t-`t-" | Add-Content $Out; continue }
            if ($p.ExitCode -ne 0 -or -not (Test-Path $pas)) { "$name`terror`t-`t-`t-`t-" | Add-Content $Out; continue }
        }
        $null = & $fpc -O2 -Mdelphi -Px86_64 -gh "-FE$case" "-FU$case" $pas 2>&1 | Out-String
        $exe = Join-Path $case 'main.exe'
        if (-not (Test-Path $exe)) { "$name`tok`tbuild-fail`t-`t-`t-" | Add-Content $Out; continue }
        $env:HEAPTRC = "log=$case\heap.trc"
        $r = Start-Process -FilePath $exe -WorkingDirectory $case -WindowStyle Hidden -PassThru -RedirectStandardOutput "$case\run.out" -RedirectStandardError "$case\run.err"
        if (-not $r.WaitForExit($TimeoutSec * 1000)) { $r.Kill($true); "$name`tok`tok`ttimeout`t-`t-" | Add-Content $Out; continue }
        $text = "$(Get-Content "$case\run.out" -Raw)"
        $marker = $text.IndexOf('Heap dump by heaptrc')
        $program = if ($marker -ge 0) { $text.Substring(0, $marker) } else { $text }
        $unfreed = [regex]::Match("$(Get-Content "$case\heap.trc" -Raw -ErrorAction SilentlyContinue)", '(\d+) unfreed memory blocks').Groups[1].Value
        $hash = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($program))).Substring(0, 12)
        "$name`tok`tok`t$($r.ExitCode)`t$hash`t$unfreed" | Add-Content $Out
    }
}
finally { Remove-Item -Recurse -Force $work -ErrorAction SilentlyContinue }
'done' | Add-Content $Out
