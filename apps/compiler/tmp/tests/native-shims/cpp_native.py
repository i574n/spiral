"""Native-tier build for `Cpp + Cuda` outputs (scripts/test.ps1 -Native, Cpp rows).

    python cpp_native.py <dir>/main.cpp <out-exe>

The backend writes main.corelib.hpp, main.hpp, main.cpp and main.cu. The CppHost part (main.cpp) builds with a
plain host compiler (SPIRAL_CXX, else g++, else clang++). main.cu only matters when the program entered
`join_backend CudaHost`, which shows as a non-empty .cu body (anything after its `#include` line); then nvcc
(SPIRAL_NVCC, else nvcc on PATH) compiles it and the host object links against it with -lcudart.

Exit codes: 0 built, 2 build failed (compiler output on stderr), 3 no-toolchain (prints the reason).
"""
import os
import shutil
import subprocess
import sys


def tool(env, *names):
    if os.environ.get(env):
        return os.environ[env]
    for n in names:
        p = shutil.which(n)
        if p:
            return p
    return None


def needs_cuda(cu_path):
    if not os.path.exists(cu_path):
        return False
    body = [l for l in open(cu_path, encoding="utf-8").read().splitlines()[1:] if l.strip()]
    return bool(body)


def main():
    cpp, exe = os.path.abspath(sys.argv[1]), os.path.abspath(sys.argv[2])
    base = os.path.splitext(cpp)[0]
    cxx = tool("SPIRAL_CXX", "g++", "clang++")
    if not cxx:
        print("no-toolchain: no C++ compiler (SPIRAL_CXX, g++, clang++)")
        sys.exit(3)
    flags = ["-std=c++20", "-O2", "-w"]
    objs, link = [], []
    if needs_cuda(base + ".cu"):
        nvcc = tool("SPIRAL_NVCC", "nvcc")
        if not nvcc:
            print("no-toolchain: the program uses join_backend CudaHost and nvcc is not available")
            sys.exit(3)
        cu_obj = exe + ".cu.o"
        r = subprocess.run([nvcc, "-std=c++20", "-O2", "-arch=native", "-c", base + ".cu", "-o", cu_obj], capture_output=True, text=True)
        if r.returncode != 0:
            sys.stderr.write(r.stdout + r.stderr)
            sys.exit(2)
        objs.append(cu_obj)
        link = ["-lcudart"]
    r = subprocess.run([cxx, *flags, cpp, *objs, "-o", exe, *link, "-lm"], capture_output=True, text=True)
    if r.returncode != 0:
        sys.stderr.write(r.stdout + r.stderr)
        sys.exit(2)
    sys.exit(0)


if __name__ == "__main__":
    main()
