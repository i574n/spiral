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

def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def loop_0(v0 : i32, v1 : cp.ndarray, v2 : i32, v3 : i32, v4 : i32) -> i32:
    while True:
        v5 = v3 >= v0
        if v5:
            del v0, v1, v2, v3, v5
            return v4
        else:
            del v5
            v6 = spiral_mod_trunc(v3, 4)
            v7 = spiral_array_index(v1, v6)
            del v6
            v8 = spiral_wrap(v3 + 1, 32, True)
            del v3
            v9 = spiral_wrap(v4 * 7, 32, True)
            del v4
            v10 = spiral_wrap(v9 + v7, 32, True)
            del v7, v9
            v11 = spiral_wrap(v10 + v2, 32, True)
            del v10
            v12 = spiral_mod_trunc(v11, 9973)
            del v11
            v0, v1, v2, v3, v4 = v0, v1, v2, v8, v12
            continue
def main():
    v0 = cp.zeros(4,dtype=cp.int32)
    v0[0] = 1
    v0[1] = 2
    v0[2] = 3
    v0[3] = 4
    v1 = 0
    v2 = 1000000
    v3 = 0
    v4 = 0
    v5 = loop_0(v2, v0, v1, v3, v4)
    del v0, v1, v2, v3, v4
    v6 = spiral_mod_trunc(v5, 256)
    del v5
    return v6

if __name__ == '__main__': sys.exit(main())
