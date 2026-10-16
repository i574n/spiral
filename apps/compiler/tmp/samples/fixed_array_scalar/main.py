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
    v0 = cp.empty(3,dtype=cp.int32)
    v0[0] = 2
    v0[1] = 3
    v0[2] = 5
    v1 = spiral_array_index(v0, 0)
    v2 = spiral_array_index(v0, 1)
    v3 = spiral_array_index(v0, 2)
    del v0
    v4 = v1 + v2
    del v1, v2
    v5 = v4 + v3
    del v3, v4
    v6 = v5 - 10
    del v5
    return v6

if __name__ == '__main__': sys.exit(main())
