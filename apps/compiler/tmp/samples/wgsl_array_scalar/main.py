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

def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
import sys
def main():
    v0 = 5
    v1 = cp.empty(v0,dtype=cp.int32)
    del v0
    v1[0] = 0
    v1[1] = 1
    v1[2] = 4
    v2 = 3
    v1[v2] = 9
    v3 = v2 + 1
    del v2
    v1[v3] = 16
    del v3
    v4 = cp.empty(3,dtype=cp.bool_)
    v4[0] = False
    v4[1] = True
    v4[2] = False
    v5 = spiral_array_index(v1, 1)
    v6 = spiral_array_index(v1, 2)
    v7 = v5 + v6
    del v5, v6
    v8 = spiral_array_index(v1, 3)
    v9 = v7 + v8
    del v7, v8
    v10 = spiral_array_index(v1, 4)
    v11 = v9 + v10
    del v9, v10
    v12 = spiral_array_index(v4, 1)
    if v12:
        v13 = spiral_array_index(v4, 0)
        if v13:
            del v13
            v15 = 0
        else:
            del v13
            v15 = 100
    else:
        v15 = 0
    del v4, v12
    v16 = v11 + v15
    del v11, v15
    v17 = v1.size
    del v1
    v18 = v16 + v17
    del v16, v17
    return v18

if __name__ == '__main__': sys.exit(main())
