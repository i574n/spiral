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
def spiral_div_trunc(a, b):
    q = abs(a) // abs(b)
    return q if (a < 0) == (b < 0) else -q
def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
def method5(v0 : i32, v1 : i32) -> i32:
    v2 = spiral_wrap(v0 * v1, 32, True)
    del v0, v1
    v3 = spiral_wrap(v2 + 5, 32, True)
    del v2
    v4 = spiral_wrap(spiral_div_trunc(v3, 3), 32, True)
    del v3
    return v4
def method4(v0 : i32) -> i32:
    v1 = 4
    v2 = 4
    v3 = method5(v1, v2)
    del v1, v2
    v4 = spiral_wrap(v0 + v3, 32, True)
    del v0, v3
    v5 = spiral_wrap(v4 - 7, 32, True)
    del v4
    return v5
def method6(v0 : u32) -> bool:
    v1 = spiral_wrap(v0 + 5, 32, False)
    del v0
    v2 = spiral_mod_trunc(v1, 4)
    del v1
    v3 = v2 == 0
    del v2
    return v3
def method3(v0 : i32) -> i32:
    v1 = 7
    v2 = method6(v1)
    del v1
    if v2:
        del v2
        return method4(v0)
    else:
        del v0, v2
        return 1
def method7(v0 : string) -> bool:
    del v0
    return True
def method2(v0 : i32) -> i32:
    v1 = "spiral"
    v2 = method7(v1)
    del v1
    if v2:
        del v2
        return method3(v0)
    else:
        del v0, v2
        return 1
def method8(v0 : f32) -> Tuple[bool, f32, i32]:
    v1 = v0 >= 3.5
    return v1, v0, 7
def method9(v0 : bool, v1 : f32, v2 : i32) -> i32:
    if v0:
        del v0
        v3 = v1 >= 3.5
        del v1
        if v3:
            del v3
            v4 = spiral_wrap(v2 - 7, 32, True)
            del v2
            return v4
        else:
            del v2, v3
            return 1
    else:
        del v0, v1, v2
        return 2
def method1(v0 : i32) -> i32:
    v1 = 4.0
    v2, v3, v4 = method8(v1)
    del v1
    v5 = method9(v2, v3, v4)
    del v2, v3, v4
    v6 = spiral_wrap(v0 + v5, 32, True)
    del v0, v5
    return method2(v6)
def method10(v0 : i32) -> Tuple[i32, i32, bool]:
    v1 = spiral_wrap(v0 + 2, 32, True)
    v2 = v0 > 0
    return v0, v1, v2
def method11(v0 : i32, v1 : i32, v2 : bool) -> i32:
    if v2:
        del v2
        v3 = spiral_wrap(v0 + v1, 32, True)
        del v0, v1
        v4 = spiral_wrap(v3 - 4, 32, True)
        del v3
        return v4
    else:
        del v0, v1, v2
        return 1
def method0(v0 : i32) -> i32:
    v1 = 1
    v2, v3, v4 = method10(v1)
    del v1
    v5 = method11(v2, v3, v4)
    del v2, v3, v4
    v6 = spiral_wrap(v0 + v5, 32, True)
    del v0, v5
    return method1(v6)
def main():
    v0 = 0
    return method0(v0)

if __name__ == '__main__': sys.exit(main())
