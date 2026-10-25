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
class US0_Empty(NamedTuple): # Empty
    tag = 0
class US0_Nested(NamedTuple): # Nested
    v0 : cp.ndarray
    tag = 1
US0 = Union[US0_Empty, US0_Nested]
def bump_0(v0 : US0) -> i32:
    match v0:
        case US0_Empty(): # Empty
            del v0
            return 0
        case US0_Nested(v1): # Nested
            del v0
            v2 = spiral_array_index(v1, 0)
            del v1
            v3 = spiral_array_index(v2, 0)
            v4 = spiral_wrap(v3 + 1, 32, True)
            del v3
            v2[0] = v4
            del v2, v4
            return 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def score_1(v0 : US0) -> i32:
    match v0:
        case US0_Empty(): # Empty
            del v0
            return 0
        case US0_Nested(v1): # Nested
            del v0
            v2 = spiral_array_index(v1, 0)
            v3 = spiral_array_index(v1, 1)
            del v1
            v4 = spiral_array_index(v2, 0)
            v5 = spiral_array_index(v2, 1)
            del v2
            v6 = spiral_wrap(v4 + v5, 32, True)
            del v4, v5
            v7 = spiral_array_index(v3, 0)
            v8 = spiral_wrap(v6 + v7, 32, True)
            del v6, v7
            v9 = spiral_array_index(v3, 1)
            del v3
            v10 = spiral_wrap(v8 + v9, 32, True)
            del v8, v9
            return v10
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 2
    v1 = __import__('numpy').empty(v0,dtype=object)
    v2 = cp.zeros(v0,dtype=cp.int32)
    v3 = cp.zeros(v0,dtype=cp.int32)
    del v0
    v2[0] = 3
    v2[1] = 4
    v3[0] = 5
    v3[1] = 6
    v1[0] = v2
    del v2
    v1[1] = v3
    del v3
    v4 = US0_Nested(v1)
    v5 = bump_0(v4)
    del v4
    v6 = US0_Nested(v1)
    del v1
    v7 = score_1(v6)
    del v6
    v8 = spiral_wrap(v7 + v5, 32, True)
    del v5, v7
    v9 = spiral_wrap(v8 - 19, 32, True)
    del v8
    return v9

if __name__ == '__main__': sys.exit(main())
