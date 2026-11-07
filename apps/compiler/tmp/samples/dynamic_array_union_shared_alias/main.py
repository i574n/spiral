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
US0_Empty_shared = US0_Empty()
class US0_Values(NamedTuple): # Values
    v0 : cp.ndarray
    tag = 1
US0 = Union[US0_Empty, US0_Values]
def bump_0(v0 : US0) -> i32:
    match v0:
        case US0_Empty(): # Empty
            del v0
            return 0
        case US0_Values(v1): # Values
            del v0
            v2 = spiral_array_index(v1, 0)
            v3 = spiral_wrap(v2 + 1, 32, True)
            del v2
            v1[0] = v3
            del v1, v3
            return 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def score_1(v0 : US0) -> i32:
    match v0:
        case US0_Empty(): # Empty
            del v0
            return 0
        case US0_Values(v1): # Values
            del v0
            v2 = v1.size
            v3 = spiral_array_index(v1, 0)
            v4 = spiral_wrap(v2 + v3, 32, True)
            del v2, v3
            v5 = spiral_array_index(v1, 1)
            del v1
            v6 = spiral_wrap(v4 + v5, 32, True)
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 2
    v1 = cp.zeros(v0,dtype=cp.int32)
    del v0
    v1[0] = 4
    v1[1] = 5
    v2 = US0_Values(v1)
    v3 = bump_0(v2)
    del v2
    v4 = US0_Values(v1)
    del v1
    v5 = score_1(v4)
    del v4
    v6 = spiral_wrap(v5 + v3, 32, True)
    del v3, v5
    v7 = spiral_wrap(v6 - 12, 32, True)
    del v6
    return v7

if __name__ == '__main__': sys.exit(main())
