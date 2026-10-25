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
UH0 = Union["UH0_Nil", "UH0_Cons"]
class UH0_Nil(NamedTuple): # Nil
    tag = 0
class UH0_Cons(NamedTuple): # Cons
    v0 : i32
    v1 : UH0
    tag = 1
def sum_0(v0 : UH0) -> i32:
    match v0:
        case UH0_Cons(v1, v2): # Cons
            del v0
            v3 = sum_0(v2)
            del v2
            v4 = spiral_wrap(v1 + v3, 32, True)
            del v1, v3
            return v4
        case UH0_Nil(): # Nil
            del v0
            return 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = UH0_Nil()
    v4 = UH0_Cons(v2, v3)
    del v2, v3
    v5 = UH0_Cons(v1, v4)
    del v1, v4
    v6 = UH0_Cons(v0, v5)
    del v0, v5
    v7 = sum_0(v6)
    del v6
    v8 = spiral_wrap(v7 - 6, 32, True)
    del v7
    return v8

if __name__ == '__main__': sys.exit(main())
