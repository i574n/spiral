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
    v0 = 2
    v1 = __import__('numpy').empty(v0,dtype=object)
    v2 = cp.empty(v0,dtype=cp.int32)
    v3 = cp.empty(v0,dtype=cp.int32)
    del v0
    v2[0] = 3
    v2[1] = 4
    v3[0] = 5
    v3[1] = 6
    v1[0] = v2
    del v2
    v1[1] = v3
    del v3
    v4 = spiral_array_index(v1, 0)
    v5 = spiral_array_index(v1, 1)
    del v1
    v6 = spiral_array_index(v4, 0)
    v7 = spiral_array_index(v4, 1)
    del v4
    v8 = v6 + v7
    del v6, v7
    v9 = spiral_array_index(v5, 0)
    v10 = v8 + v9
    del v8, v9
    v11 = spiral_array_index(v5, 1)
    del v5
    v12 = v10 + v11
    del v10, v11
    v13 = v12 - 18
    del v12
    return v13

if __name__ == '__main__': sys.exit(main())
