kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
import os
try: # CuPy when a CUDA device answers, otherwise numpy under the same name (SPIRAL_CUDA=0 forces numpy).
    if os.environ.get('SPIRAL_CUDA', '1') == '0': raise ImportError('SPIRAL_CUDA=0')
    import cupy as cp
    if cp.cuda.runtime.getDeviceCount() < 1: raise RuntimeError('no CUDA device')
    cuda = True
except Exception:
    import numpy as cp
    cuda = False
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def method1(v0 : i32, v1 : i32) -> i32:
    while True:
        v2 = spiral_wrap(v0 - 1, 32, True)
        del v0
        v3 = spiral_wrap(v1 + 3, 32, True)
        del v1
        v4 = v2 == 0
        if v4:
            del v2, v4
            return v3
        else:
            del v4
            v0, v1 = v2, v3
            continue
def method0(v0 : i32) -> i32:
    v1 = 0
    v2 = v0 == 0
    if v2:
        del v0, v2
        return v1
    else:
        del v2
        return method1(v0, v1)
def method3(v0 : i32, v1 : i32) -> i32:
    while True:
        v2 = spiral_wrap(v0 - 1, 32, True)
        del v0
        v3 = spiral_wrap(v1 - 2, 32, True)
        del v1
        v4 = v2 == 0
        if v4:
            del v2, v4
            return v3
        else:
            del v4
            v0, v1 = v2, v3
            continue
def method2(v0 : i32) -> i32:
    v1 = 0
    v2 = v0 == 0
    if v2:
        del v0, v2
        return v1
    else:
        del v2
        return method3(v0, v1)
def main():
    v0 = 4
    v1 = method0(v0)
    v2 = method2(v0)
    del v0
    v3 = v1 == 12
    del v1
    if v3:
        v4 = v2 == -8
        v5 = v4
    else:
        v5 = False
    del v2, v3
    if v5:
        del v5
        return 0
    else:
        del v5
        return 1

if __name__ == '__main__': sys.exit(main())
