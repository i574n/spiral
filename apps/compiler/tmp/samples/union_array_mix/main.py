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
class US0_None(NamedTuple): # None
    tag = 0
class US0_Held(NamedTuple): # Held
    v0 : cp.ndarray
    v1 : i32
    tag = 1
US0 = Union[US0_None, US0_Held]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Held(v1, v2): # Held
            del v0
            v3 = spiral_array_index(v1, 0)
            del v1
            v4 = spiral_wrap(v3 + v2, 32, True)
            del v2, v3
            v5 = v4 == 7
            del v4
            if v5:
                del v5
                return 0
            else:
                del v5
                return 1
        case US0_None(): # None
            del v0
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 3
    v1 = 4
    v2 = cp.zeros(1,dtype=cp.int32)
    v2[0] = v0
    del v0
    v3 = True
    if v3:
        v6 = US0_Held(v2, v1)
    else:
        v6 = US0_None()
    del v1, v2, v3
    return score_0(v6)

if __name__ == '__main__': sys.exit(main())
