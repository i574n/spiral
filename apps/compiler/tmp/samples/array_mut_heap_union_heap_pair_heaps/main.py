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
class Heap1(NamedTuple):
    v0 : Heap0
    v1 : Heap0
class Heap2(NamedTuple):
    v0 : Heap1
    v1 : i32
class US0_None(NamedTuple): # None
    tag = 0
class US0_Held(NamedTuple): # Held
    v0 : Heap2
    tag = 1
US0 = Union[US0_None, US0_Held]
class Heap3(NamedTuple):
    v0 : US0
@dataclass
class Mut0:
    v0 : Heap3
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Held(v1): # Held
            del v0
            v2, v3 = v1.v0, v1.v1
            del v1
            v4, v5 = v2.v0, v2.v1
            del v2
            v6, v7 = v4.v0, v4.v1
            del v4
            v8, v9 = v5.v0, v5.v1
            del v5
            v10 = v6 == 7
            del v6
            if v10:
                v11 = v7 == "hi"
                v12 = v11
            else:
                v12 = False
            del v7, v10
            if v12:
                v13 = v8 == 4
                v14 = v13
            else:
                v14 = False
            del v8, v12
            if v14:
                v15 = v9 == "yo"
                v16 = v15
            else:
                v16 = False
            del v9, v14
            if v16:
                v17 = v3 == 2
                v18 = v17
            else:
                v18 = False
            del v3, v16
            if v18:
                del v18
                return 0
            else:
                del v18
                return 1
        case US0_None(): # None
            del v0
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 1
    v1 = "no"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 2
    v4 = "zz"
    v5 = Heap0(v3, v4)
    del v3, v4
    v6 = Heap1(v2, v5)
    del v2, v5
    v7 = 3
    v8 = Heap2(v6, v7)
    del v6, v7
    v9 = True
    if v9:
        v12 = US0_Held(v8)
    else:
        v12 = US0_None()
    del v8, v9
    v13 = Heap3(v12)
    del v12
    v14 = Mut0(v13)
    del v13
    v15 = __import__('numpy').empty(1,dtype=object)
    v15[0] = v14
    del v14
    v16 = 7
    v17 = "hi"
    v18 = Heap0(v16, v17)
    del v16, v17
    v19 = 4
    v20 = "yo"
    v21 = Heap0(v19, v20)
    del v19, v20
    v22 = Heap1(v18, v21)
    del v18, v21
    v23 = 2
    v24 = Heap2(v22, v23)
    del v22, v23
    v25 = True
    if v25:
        v28 = US0_Held(v24)
    else:
        v28 = US0_None()
    del v24, v25
    v29 = Heap3(v28)
    del v28
    v30 = spiral_array_index(v15, 0)
    del v15
    v30.v0 = v29
    del v29
    v31 = v30.v0
    del v30
    v32 = v31.v0
    del v31
    return score_0(v32)

if __name__ == '__main__': sys.exit(main())
