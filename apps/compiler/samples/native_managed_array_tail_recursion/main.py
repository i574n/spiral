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
def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
def method1(v0 : i32, v1 : cp.ndarray, v2 : cp.ndarray) -> cp.ndarray:
    while True:
        v3 = spiral_wrap(v0 - 1, 32, True)
        del v0
        v4 = v3 == 0
        if v4:
            del v1, v3, v4
            return v2
        else:
            del v4
            v0, v1, v2 = v3, v2, v1
            continue
def method0(v0 : cp.ndarray, v1 : cp.ndarray) -> cp.ndarray:
    v2 = 1000000
    v3 = v2 == 0
    if v3:
        del v1, v2, v3
        return v0
    else:
        del v3
        return method1(v2, v0, v1)
def main():
    v0 = 1
    v1 = cp.zeros(v0,dtype=cp.int32)
    v2 = cp.zeros(v0,dtype=cp.int32)
    del v0
    v1[0] = 7
    v2[0] = 11
    v3 = method0(v1, v2)
    v3[0] = 13
    del v3
    v4 = spiral_array_index(v1, 0)
    del v1
    v5 = v4 == 13
    del v4
    if v5:
        del v5
        v6 = spiral_array_index(v2, 0)
        del v2
        v7 = v6 == 11
        del v6
        if v7:
            del v7
            return 0
        else:
            del v7
            return 2
    else:
        del v2, v5
        return 1

if __name__ == '__main__': sys.exit(main())
