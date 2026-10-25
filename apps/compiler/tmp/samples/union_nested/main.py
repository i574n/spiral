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

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
class US0_A(NamedTuple): # A
    v0 : i32
    tag = 0
class US0_B(NamedTuple): # B
    v0 : i32
    tag = 1
US0 = Union[US0_A, US0_B]
class US1_Wrap(NamedTuple): # Wrap
    v0 : US0
    tag = 0
class US1_Other(NamedTuple): # Other
    v0 : i32
    tag = 1
US1 = Union[US1_Wrap, US1_Other]
def score_inner_1(v0 : US0) -> i32:
    match v0:
        case US0_A(v1): # A
            del v0
            return v1
        case US0_B(v2): # B
            del v0
            v3 = spiral_wrap(-v2, 32, True)
            del v2
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def score_0(v0 : US1) -> i32:
    match v0:
        case US1_Other(v3): # Other
            del v0
            return v3
        case US1_Wrap(v1): # Wrap
            del v0
            return score_inner_1(v1)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    if v0:
        v1 = US0_A(7)
        v4 = US1_Wrap(v1)
    else:
        v4 = US1_Other(1)
    if v0:
        v8 = US1_Other(4)
    else:
        v6 = US0_B(2)
        v8 = US1_Wrap(v6)
    del v0
    v9 = score_0(v4)
    del v4
    v10 = v9 == 7
    del v9
    if v10:
        v11 = score_0(v8)
        v12 = v11 == 4
        del v11
        v13 = v12
    else:
        v13 = False
    del v8, v10
    if v13:
        del v13
        return 0
    else:
        del v13
        return 1

if __name__ == '__main__': sys.exit(main())
