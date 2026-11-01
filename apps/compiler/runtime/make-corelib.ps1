<#
Writes runtime/corelib.cuh = upstream corelib.cuh (hcc @ 0cb0fda0) + the workspace's CPU-host deltas. Each delta is a
pure insertion or a one-line edit, so a later upstream corelib can be re-patched with this script. The patch of the
deltas goes to stdout (redirect it to keep it); nothing but corelib.cuh is written into runtime/, whose `corelib.*`
files the host copies next to the compiler.

    git -C <The-Spiral-Language> show "0cb0fda0:The Spiral Language 2/corelib.cuh" > <tmp>/corelib.stock.cuh
    pwsh make-corelib.ps1 <tmp>/corelib.stock.cuh [> corelib.ws.patch]
#>
param(
    [Parameter(Mandatory, Position = 0)] [string] $Stock,
    [string] $Out = (Join-Path $PSScriptRoot 'corelib.cuh')
)
$ErrorActionPreference = 'Stop'
$deltas = @(
    @{ anchor = '#include <cuda_runtime.h> // So we can link with Cuda libs.'; lines = @(
        '// ws: upstream includes <cuda_runtime.h> unconditionally, so the CppHost `.cpp` did not build with a plain',
        '// g++/clang++ on a machine without the CUDA SDK. Include it under nvcc/NVRTC as before, and under a host compiler',
        '// only when the header is reachable (then the CppHost object can still link with the nvcc-built `.cu`).',
        '#if defined(__CUDACC__) || defined(__NVRTC__)',
        '#include <cuda_runtime.h> // So we can link with Cuda libs.',
        '#elif defined(__has_include)',
        '#if __has_include(<cuda_runtime.h>)',
        '#include <cuda_runtime.h> // So we can link with Cuda libs.',
        '#endif',
        '#endif',
        '// ws: nvcc and NVRTC provide log/exp/tanh/sqrt/sin/cos/pow/isnan as builtins; a host compiler needs the header.',
        '#if !defined(__CUDACC__) && !defined(__NVRTC__)',
        '#include <math.h>',
        '#endif') }
    @{ anchor = '#ifdef __CUDACC__'; lines = @(
        '// ws: the generator prefixes methods named `noinline...` with `__noinline__`, which only nvcc knows. Empty on a host',
        '// compiler: libstdc++ spells `__attribute__((__noinline__))`, which stays valid as `__attribute__(())`.',
        '#if !defined(__CUDACC__) && !defined(__NVRTC__) && !defined(__noinline__)',
        '#define __noinline__',
        '#endif',
        '',
        '#ifdef __CUDACC__') }
)
# dynamic_array_base::operator[] checks a member it does not have; the first occurrence of this line is that one.
$lengthBug = '        assert("The index has to be in range." && 0 <= i && i < this->length);'
$lengthFix = @(
    '        // ws: upstream checks `i < this->length`, a member dynamic_array_base does not have (a compile error once indexed).',
    '        assert("The index has to be in range." && 0 <= i && i < max_length);')

$lines = [Collections.Generic.List[string]]::new([string[]] ([IO.File]::ReadAllText($Stock).Replace("`r`n", "`n").Split("`n")))
if ($lines.Count -and $lines[$lines.Count - 1] -eq '') { $lines.RemoveAt($lines.Count - 1) }
$original = [string[]] $lines.ToArray()
foreach ($d in $deltas) {
    $hits = @(for ($i = 0; $i -lt $lines.Count; $i++) { if ($lines[$i] -ceq $d.anchor) { $i } })
    if ($hits.Count -ne 1) { throw "anchor '$($d.anchor)' occurs $($hits.Count) times, expected 1" }
    $lines.RemoveAt($hits[0]); $lines.InsertRange($hits[0], [string[]] $d.lines)
}
$start = $lines.IndexOf('struct dynamic_array_base')
if ($start -lt 0) { throw 'no struct dynamic_array_base line' }
$bug = $lines.IndexOf($lengthBug, $start)
if ($bug -lt 0) { throw 'no dynamic_array_base length assert after struct dynamic_array_base' }
$lines.RemoveAt($bug); $lines.InsertRange($bug, [string[]] $lengthFix)
# upstream's file ends without a newline; runtime/corelib.cuh ends with one (the generators embed it as is).
$utf8 = [Text.UTF8Encoding]::new($false)
[IO.File]::WriteAllText($Out, (($lines -join "`n") + "`n"), $utf8)
$work = Join-Path ([IO.Path]::GetTempPath()) "make-corelib-$PID"
try {
    New-Item -ItemType Directory -Force "$work/a/The Spiral Language 2", "$work/b/The Spiral Language 2" | Out-Null
    [IO.File]::WriteAllText("$work/a/The Spiral Language 2/corelib.cuh", (($original -join "`n") + "`n"), $utf8)
    [IO.File]::WriteAllText("$work/b/The Spiral Language 2/corelib.cuh", (($lines -join "`n") + "`n"), $utf8)
    Push-Location $work
    try { git diff --no-index --no-color --no-prefix 'a/The Spiral Language 2/corelib.cuh' 'b/The Spiral Language 2/corelib.cuh' } finally { Pop-Location }
}
finally { Remove-Item -Recurse -Force $work -ErrorAction SilentlyContinue }
[Console]::Error.WriteLine("wrote $Out")
