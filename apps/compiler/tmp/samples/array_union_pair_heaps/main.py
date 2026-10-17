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
class Heap0(NamedTuple):
    v0 : i32
    v1 : string
class US0_None(NamedTuple): # None
    tag = 0
class US0_Held(NamedTuple): # Held
    v0 : Heap0
    v1 : Heap0
    tag = 1
US0 = Union[US0_None, US0_Held]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Held(v1, v2): # Held
            del v0
            v3, v4 = v1.v0, v1.v1
            del v1
            v5, v6 = v2.v0, v2.v1
            del v2
            v7 = v3 == 7
            del v3
            if v7:
                v8 = v4 == "hi"
                v9 = v8
            else:
                v9 = False
            del v4, v7
            if v9:
                v10 = v5 == 4
                v11 = v10
            else:
                v11 = False
            del v5, v9
            if v11:
                v12 = v6 == "yo"
                v13 = v12
            else:
                v13 = False
            del v6, v11
            if v13:
                del v13
                return 0
            else:
                del v13
                return 1
        case US0_None(): # None
            del v0
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 7
    v1 = "hi"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 4
    v4 = "yo"
    v5 = Heap0(v3, v4)
    del v3, v4
    v6 = __import__('numpy').empty(1,dtype=object)
    v7 = True
    if v7:
        v10 = US0_Held(v2, v5)
    else:
        v10 = US0_None()
    del v2, v5, v7
    v6[0] = v10
    del v10
    v11 = spiral_array_index(v6, 0)
    del v6
    return score_0(v11)

if __name__ == '__main__': sys.exit(main())
