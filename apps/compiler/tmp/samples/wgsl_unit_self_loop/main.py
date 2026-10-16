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
def fill_0(v0 : i32, v1 : cp.ndarray, v2 : i32) -> None:
    while True:
        v3 = v2 < v0
        if v3:
            del v3
            v1[v2] = v2
            v4 = v2 + 1
            del v2
            v0, v1, v2 = v0, v1, v4
            continue
        else:
            del v0, v1, v2, v3
            return 
def main():
    v0 = 6
    v1 = cp.empty(6,dtype=cp.int32)
    v2 = 0
    fill_0(v0, v1, v2)
    del v0, v2
    v3 = spiral_array_index(v1, 5)
    del v1
    v4 = v3 + 2
    del v3
    return v4

if __name__ == '__main__': sys.exit(main())
