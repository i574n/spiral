"""Writes runtime/corelib.cuh = upstream corelib.cuh (hcc @ 0cb0fda0) + the workspace's CPU-host deltas. Each delta is
a pure insertion or a one-line edit, so a later upstream corelib can be re-patched with this script. The unified diff of
the deltas goes to stdout (redirect it to keep it); nothing but corelib.cuh is written into runtime/, whose `corelib.*`
files the host copies next to the compiler.

    git -C <The-Spiral-Language> show "0cb0fda0:The Spiral Language 2/corelib.cuh" > <tmp>/corelib.stock.cuh
    python make_corelib.py <tmp>/corelib.stock.cuh [> corelib.ws.patch]
"""
import difflib, os, sys

HERE = os.path.dirname(os.path.abspath(__file__))

DELTAS = [
    # (anchor line in upstream, replacement lines). The anchor must occur exactly once.
    ("#include <cuda_runtime.h> // So we can link with Cuda libs.", [
        "// ws: upstream includes <cuda_runtime.h> unconditionally, so the CppHost `.cpp` did not build with a plain",
        "// g++/clang++ on a machine without the CUDA SDK. Include it under nvcc/NVRTC as before, and under a host compiler",
        "// only when the header is reachable (then the CppHost object can still link with the nvcc-built `.cu`).",
        "#if defined(__CUDACC__) || defined(__NVRTC__)",
        "#include <cuda_runtime.h> // So we can link with Cuda libs.",
        "#elif defined(__has_include)",
        "#if __has_include(<cuda_runtime.h>)",
        "#include <cuda_runtime.h> // So we can link with Cuda libs.",
        "#endif",
        "#endif",
        "// ws: nvcc and NVRTC provide log/exp/tanh/sqrt/sin/cos/pow/isnan as builtins; a host compiler needs the header.",
        "#if !defined(__CUDACC__) && !defined(__NVRTC__)",
        "#include <math.h>",
        "#endif",
    ]),
    ("#ifdef __CUDACC__", [
        "// ws: the generator prefixes methods named `noinline...` with `__noinline__`, which only nvcc knows. Empty on a host",
        "// compiler: libstdc++ spells `__attribute__((__noinline__))`, which stays valid as `__attribute__(())`.",
        "#if !defined(__CUDACC__) && !defined(__NVRTC__) && !defined(__noinline__)",
        "#define __noinline__",
        "#endif",
        "",
        "#ifdef __CUDACC__",
    ]),
]
# dynamic_array_base::operator[] checks a member it does not have; the first occurrence of this line is that one.
LENGTH_BUG = '        assert("The index has to be in range." && 0 <= i && i < this->length);'
LENGTH_FIX = [
    "        // ws: upstream checks `i < this->length`, a member dynamic_array_base does not have (a compile error once indexed).",
    '        assert("The index has to be in range." && 0 <= i && i < max_length);',
]


def patch(lines):
    out = list(lines)
    for anchor, repl in DELTAS:
        idx = [i for i, l in enumerate(out) if l == anchor]
        assert len(idx) == 1, (anchor, idx)
        out[idx[0]:idx[0] + 1] = repl
    start = out.index("struct dynamic_array_base")
    i = out.index(LENGTH_BUG, start)
    out[i:i + 1] = LENGTH_FIX
    return out


def main():
    if len(sys.argv) != 2:
        sys.exit(__doc__)
    text = open(sys.argv[1], encoding="utf-8").read().replace("\r\n", "\n")
    lines = text.split("\n")
    if lines and lines[-1] == "":
        lines.pop()
    new = patch(lines)
    # upstream's file ends without a newline; runtime/corelib.cuh ends with one (the generators embed it as is).
    with open(os.path.join(HERE, "corelib.cuh"), "w", encoding="utf-8", newline="\n") as fh:
        fh.write("\n".join(new) + "\n")
    sys.stdout.write("\n".join(difflib.unified_diff(lines, new, "a/The Spiral Language 2/corelib.cuh", "b/The Spiral Language 2/corelib.cuh", lineterm="")) + "\n")
    print("wrote " + os.path.join(HERE, "corelib.cuh"), file=sys.stderr)


if __name__ == "__main__":
    main()
