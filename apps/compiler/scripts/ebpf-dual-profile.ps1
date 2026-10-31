param([string[]] $Samples = @('ebpf_arith', 'ebpf_minkey', 'ebpf_tacc', 'ebpf_tworec'), [string] $Llvm = (Join-Path $HOME 'scoop\apps\llvm\current\bin'), [string] $Cc = 'C:\Users\i574n\scoop\apps\gcc\current\bin\gcc.exe')
$ErrorActionPreference = 'Stop'
$capOld = "#define SPIRAL_LOOP_CAP 16777216`n"
$capNew = "#ifdef __bpf__`n#define SPIRAL_LOOP_CAP 8192`nint32_t spiral_loop_capped;`n#define SPIRAL_LOOP_CAPPED() (spiral_loop_capped = 1)`n#else`n#define SPIRAL_LOOP_CAP 16777216`n#define SPIRAL_LOOP_CAPPED() ((void)0)`n#endif`n"
$mainOld = "int main(void) {`n    return spiral_main();`n}"
$mainNew = "#ifdef __bpf__`n#define SEC(name) __attribute__((section(name), used))`nint32_t spiral_exit_code;`nSEC(`"socket`")`nint spiral_socket(void *context) {`n    int32_t spiral_result = spiral_main();`n    spiral_exit_code = spiral_loop_capped ? -2147483647 : spiral_result;`n    return 0;`n}`nchar LICENSE[] SEC(`"license`") = `"GPL`";`n#else`nint main(void) {`n    return spiral_main();`n}`n#endif"
foreach ($sample in $Samples) {
    $work = Join-Path $env:LOCALAPPDATA "spiral-bin/runs/ebpf-dual-profile/$sample"
    New-Item -ItemType Directory -Force $work | Out-Null
    $text = [IO.File]::ReadAllText("C:\home\git\spiral\apps\compiler\tmp\samples\$sample\main.ebpf").Replace("`r`n", "`n")
    $emittedDual = $text.Contains('#ifdef __bpf__')
    if (-not $emittedDual -and (-not $text.Contains($capOld) -or -not $text.Contains($mainOld))) { throw "$sample does not have the expected cap or host main" }
    $dual = Join-Path $work 'main.c'
    $profiled = if ($emittedDual) { $text } else { $text.Replace($capOld, $capNew).Replace($mainOld, $mainNew) }
    if (-not $emittedDual) {
        $preludeEnd = $profiled.IndexOf("`n}`n", $profiled.IndexOf('spiral_map_update(')) + 3
        $profiled = $profiled.Substring(0, $preludeEnd) + $profiled.Substring($preludeEnd).Replace("`n    }`n    return ", "`n    }`n    SPIRAL_LOOP_CAPPED();`n    return ")
    }
    [IO.File]::WriteAllText($dual, $profiled)
    $exe = Join-Path $work 'host.exe'
    & $Cc -std=c11 -O2 -w -x c $dual -o $exe
    if ($LASTEXITCODE -ne 0) { throw "$sample host build failed" }
    & $exe
    $hostExit = $LASTEXITCODE
    $object = Join-Path $work 'main.bpf.o'
    & (Join-Path $Llvm 'clang.exe') -target bpf -O2 -g -c $dual -o $object
    $bpfBuilt = $LASTEXITCODE -eq 0
    $sections = if ($bpfBuilt) { (& (Join-Path $Llvm 'llvm-objdump.exe') -h $object | Select-String -Pattern ' (socket|license|\.bss) ' | ForEach-Object { ($_.Line.Trim() -split '\s+')[1..2] -join '=' }) -join ' ' } else { 'bpf build failed' }
    "$sample host exit=$hostExit bpf: $sections"
}
'expect: host exits equal the committed oracle exits; every sample also builds for -target bpf with socket, license and .bss sections'
