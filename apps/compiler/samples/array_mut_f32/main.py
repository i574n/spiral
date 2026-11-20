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
@dataclass
class Mut0:
    v0 : f32
    v1 : string
def main():
    v0 = 1.5
    v1 = "no"
    v2 = Mut0(v0, v1)
    del v0, v1
    v3 = __import__('numpy').empty(1,dtype=object)
    v3[0] = v2
    del v2
    v4 = spiral_array_index(v3, 0)
    del v3
    v5 = 2.5
    v6 = "hi"
    v4.v0 = v5
    v4.v1 = v6
    del v5, v6
    v7, v8 = v4.v0, v4.v1
    del v4
    v9 = v7 == 2.5
    del v7
    if v9:
        v10 = v8 == "hi"
        v11 = v10
    else:
        v11 = False
    del v8, v9
    if v11:
        del v11
        return 0
    else:
        del v11
        return 1

if __name__ == '__main__': sys.exit(main())
