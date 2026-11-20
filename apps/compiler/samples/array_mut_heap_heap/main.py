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
class Heap0(NamedTuple):
    v0 : i32
    v1 : string
class Heap1(NamedTuple):
    v0 : Heap0
    v1 : i32
@dataclass
class Mut0:
    v0 : Heap1
def main():
    v0 = 3
    v1 = "no"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 1
    v4 = Heap1(v2, v3)
    del v2, v3
    v5 = Mut0(v4)
    del v4
    v6 = __import__('numpy').empty(1,dtype=object)
    v6[0] = v5
    del v5
    v7 = 7
    v8 = "hi"
    v9 = Heap0(v7, v8)
    del v7, v8
    v10 = 4
    v11 = Heap1(v9, v10)
    del v9, v10
    v12 = spiral_array_index(v6, 0)
    del v6
    v12.v0 = v11
    del v11
    v13 = v12.v0
    del v12
    v14, v15 = v13.v0, v13.v1
    del v13
    v16, v17 = v14.v0, v14.v1
    del v14
    v18 = v16 == 7
    del v16
    if v18:
        v19 = v17 == "hi"
        v20 = v19
    else:
        v20 = False
    del v17, v18
    if v20:
        v21 = v15 == 4
        v22 = v21
    else:
        v22 = False
    del v15, v20
    if v22:
        del v22
        return 0
    else:
        del v22
        return 1

if __name__ == '__main__': sys.exit(main())
