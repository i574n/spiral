param(
    [Parameter(Mandatory)] [string] $A,
    [Parameter(Mandatory)] [string] $B,
    [Parameter(Mandatory)] [string] $Sample,
    [string] $Backend = 'C',
    [int] $Rounds = 5
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'env.ps1')
$dotnet = Resolve-SpiralDotnet
$env:SPIRAL_COMPILER_PACKAGE_DIR = Get-SpiralPackageDir
$env:SPIRAL_DIAG_QUIET = '1'
$dir = if (Test-Path -LiteralPath $Sample -PathType Container) { $Sample } else { Join-Path $BundleRoot "samples/$Sample" }
$entry = Get-ChildItem $dir -Filter 'main.spi*' | Select-Object -First 1 -ExpandProperty FullName
if (-not $entry) { throw "no main.spi or main.spir in $dir" }
$extension = @{ Fsharp = 'fsx'; C = 'c'; Rust = 'rs'; Delphi = 'pas'; Zig = 'zig'; Lua = 'lua'; Gleam = 'gleam'; TypeScript = 'ts'; Python = 'py' }[$Backend]
if (-not $extension) { throw "bench-pair supports Fsharp, C, Rust, Delphi, Zig, Lua, Gleam, TypeScript and Python" }
$scratch = Join-Path ([IO.Path]::GetTempPath()) "spiral-bench-pair-$PID"
New-Item -ItemType Directory -Force $scratch | Out-Null
function Measure-Compile([string] $dll, [string] $label, [int] $round) {
    $output = Join-Path $scratch "$label-$round.$extension"
    $watch = [Diagnostics.Stopwatch]::StartNew()
    & $dotnet $dll --backend $Backend $entry $output *> $null
    $ms = $watch.ElapsedMilliseconds
    $bytes = if (Test-Path -LiteralPath $output) { (Get-Item -LiteralPath $output).Length } else { -1 }
    [pscustomobject]@{ Label = $label; Round = $round; Ms = $ms; Exit = $LASTEXITCODE; Bytes = $bytes }
}
try {
    $rows = for ($round = 1; $round -le $Rounds; $round++) {
        $order = if ($round % 2) { @(@('A', $A), @('B', $B)) } else { @(@('B', $B), @('A', $A)) }
        foreach ($pair in $order) { Measure-Compile $pair[1] $pair[0] $round }
    }
    $median = { param($xs) $s = @($xs | Sort-Object); $s[[int][Math]::Floor(($s.Count - 1) / 2)] }
    $a = & $median ($rows | Where-Object Label -eq 'A' | ForEach-Object Ms)
    $b = & $median ($rows | Where-Object Label -eq 'B' | ForEach-Object Ms)
    $rows | Format-Table -AutoSize | Out-String -Width 120
    "median A $a ms, B $b ms, B/A $([Math]::Round($b / [Math]::Max(1, $a), 3)) ($Rounds rounds, alternating order, fresh process per compile, $Backend, $(Split-Path $dir -Leaf))"
    $sizes = $rows | Group-Object Label | ForEach-Object { "$($_.Name) $((@($_.Group.Bytes) | Sort-Object -Unique) -join '/') bytes" }
    "outputs: $($sizes -join ', ')"
} finally {
    Remove-Item -LiteralPath $scratch -Recurse -Force -ErrorAction SilentlyContinue
}
