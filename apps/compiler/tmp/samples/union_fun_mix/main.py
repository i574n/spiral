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
def add_c0(env_v0 : i32):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        v2 = v1 + v0
        del v0
        return v2
    return inner
class US0_None(NamedTuple): # None
    tag = 0
class US0_Call(NamedTuple): # Call
    v0 : Callable[[i32], i32]
    v1 : i32
    tag = 1
US0 = Union[US0_None, US0_Call]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Call(v1, v2): # Call
            del v0
            v3 = v1(0)
            del v1
            v4 = v3 + v2
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
    v2 = True
    if v2:
        v3 = add_c0(v0)
        v6 = US0_Call(v3, v1)
    else:
        v6 = US0_None()
    del v0, v1, v2
    return score_0(v6)

if __name__ == '__main__': sys.exit(main())
