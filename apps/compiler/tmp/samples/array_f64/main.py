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
    v1 = cp.empty(v0,dtype=cp.float64)
    del v0
    v2 = 1.5
    v1[0] = v2
    del v2
    v1[1] = 2.5
    v3 = spiral_array_index(v1, 0)
    del v1
    v4 = v3 == 1.5
    del v3
    if v4:
        del v4
        return 0
    else:
        del v4
        return 1

if __name__ == '__main__': sys.exit(main())
