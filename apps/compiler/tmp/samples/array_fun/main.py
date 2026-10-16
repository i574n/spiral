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
def f_c0(env_v0 : i32):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        v2 = v1 + v0
        del v0
        return v2
    return inner
def main():
    v0 = 3
    v1 = f_c0(v0)
    del v0
    v2 = 1
    v3 = __import__('numpy').empty(v2,dtype=object)
    del v2
    v3[0] = v1
    del v1
    v4 = spiral_array_index(v3, 0)
    del v3
    v5 = v4(4)
    del v4
    v6 = v5 == 7
    del v5
    if v6:
        del v6
        return 0
    else:
        del v6
        return 1

if __name__ == '__main__': sys.exit(main())
