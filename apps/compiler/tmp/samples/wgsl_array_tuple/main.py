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
    v0 = 3
    v1 = __import__('numpy').empty(v0,dtype=object)
    del v0
    v2 = 4
    v1[0] = v2, True
    del v2
    v1[1] = 7, False
    v1[2] = 9, True
    v3, v4 = spiral_array_index(v1, 0)
    v5, v6 = spiral_array_index(v1, 1)
    v7 = 2
    v8, v9 = spiral_array_index(v1, v7)
    del v1, v7
    if v4:
        v10 = 1
    else:
        v10 = 0
    del v4
    if v6:
        v11 = 10
    else:
        v11 = 0
    del v6
    if v9:
        v12 = 100
    else:
        v12 = 0
    del v9
    v13 = spiral_wrap(v3 + v5, 32, True)
    del v3, v5
    v14 = spiral_wrap(v13 + v8, 32, True)
    del v8, v13
    v15 = spiral_wrap(v14 + v10, 32, True)
    del v10, v14
    v16 = spiral_wrap(v15 + v11, 32, True)
    del v11, v15
    v17 = spiral_wrap(v16 + v12, 32, True)
    del v12, v16
    return v17

if __name__ == '__main__': sys.exit(main())
