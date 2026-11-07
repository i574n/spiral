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
    v0[0] = 2
    v0[1] = 3
    v0[2] = 5
    v0[3] = 7
    v1 = 1
    v0[v1] = 11
    del v1
    v2 = spiral_array_index(v0, 0)
    v3 = spiral_array_index(v0, 1)
    v4 = spiral_array_index(v0, 2)
    v5 = spiral_array_index(v0, 3)
    del v0
    v6 = spiral_wrap(v2 + v3, 32, True)
    del v2, v3
    v7 = spiral_wrap(v6 + v4, 32, True)
    del v4, v6
    v8 = spiral_wrap(v7 + v5, 32, True)
    del v5, v7
    v9 = spiral_wrap(v8 - 25, 32, True)
    del v8
    return v9

if __name__ == '__main__': sys.exit(main())
