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
class Heap0(NamedTuple):
    v0 : i32
    v1 : string
class Heap1(NamedTuple):
    v0 : Heap0
    v1 : i32
class US0_None(NamedTuple): # None
    tag = 0
class US0_Held(NamedTuple): # Held
    v0 : Heap1
    tag = 1
US0 = Union[US0_None, US0_Held]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Held(v1): # Held
            del v0
            v2, v3 = v1.v0, v1.v1
            del v1
            v4, v5 = v2.v0, v2.v1
            del v2
            v6 = v4 == 7
            del v4
            if v6:
                v7 = v5 == "hi"
                v8 = v7
            else:
                v8 = False
            del v5, v6
            if v8:
                v9 = v3 == 1
                v10 = v9
            else:
                v10 = False
            del v3, v8
            if v10:
                del v10
                return 0
            else:
                del v10
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
    v3 = 1
    v4 = Heap1(v2, v3)
    del v2, v3
    v5 = True
    if v5:
        v8 = US0_Held(v4)
    else:
        v8 = US0_None()
    del v4, v5
    return score_0(v8)

if __name__ == '__main__': sys.exit(main())
