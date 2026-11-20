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

def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def main():
    v0 = cp.zeros(4,dtype=cp.int32)
    v0[0] = 7
    v0[1] = 7
    v0[2] = 7
    v0[3] = 7
    v1 = spiral_array_index(v0, 3)
    del v0
    v2 = cp.zeros(4,dtype=cp.int32)
    v2[0] = 5
    v3 = spiral_array_index(v2, 3)
    v4 = spiral_array_index(v2, 0)
    del v2
    v5 = spiral_wrap(v3 * 100, 32, True)
    del v3
    v6 = spiral_wrap(v5 + v4, 32, True)
    del v4, v5
    v7 = spiral_wrap(v1 - 7, 32, True)
    del v1
    v8 = spiral_wrap(v6 + v7, 32, True)
    del v6, v7
    return v8

if __name__ == '__main__': sys.exit(main())
