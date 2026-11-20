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
class Heap0(NamedTuple):
    v0 : i32
def main():
    v0 = 2
    v1 = __import__('numpy').empty(v0,dtype=object)
    del v0
    v2 = 4
    v3 = 6
    v4 = Heap0(v2)
    del v2
    v1[0] = v4
    del v4
    v5 = Heap0(v3)
    del v3
    v1[1] = v5
    del v5
    v6 = spiral_array_index(v1, 0)
    v7 = v6.v0
    del v6
    v8 = spiral_array_index(v1, 1)
    del v1
    v9 = v8.v0
    del v8
    v10 = spiral_wrap(v7 + v9, 32, True)
    del v7, v9
    v11 = v10 == 10
    del v10
    if v11:
        del v11
        return 0
    else:
        del v11
        return 1

if __name__ == '__main__': sys.exit(main())
