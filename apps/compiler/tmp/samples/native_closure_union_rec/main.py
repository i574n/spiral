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
UH0 = Union["UH0_Cons", "UH0_Nil"]
class UH0_Cons(NamedTuple): # Cons
    v0 : u64
    v1 : Callable[[], UH0]
    tag = 0
class UH0_Nil(NamedTuple): # Nil
    tag = 1
def closure0(env_v0 : u64):
    def inner() -> UH0:
        nonlocal env_v0
        v0 = env_v0
        v1 = spiral_wrap(v0 - 1, 64, False)
        del v0
        return build_0(v1)
    return inner
def build_0(v0 : u64) -> UH0:
    v1 = v0 == 0
    if v1:
        del v0, v1
        return UH0_Nil()
    else:
        del v1
        v3 = closure0(v0)
        return UH0_Cons(v0, v3)
def sum_1(v0 : UH0, v1 : u64) -> u64:
    while True:
        match v0:
            case UH0_Cons(v2, v3): # Cons
                del v0
                v4 = v3()
                del v3
                v5 = spiral_wrap(v1 + v2, 64, False)
                del v1, v2
                v0, v1 = v4, v5
                continue
            case UH0_Nil(): # Nil
                del v0
                return v1
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 10
    v1 = build_0(v0)
    del v0
    v2 = 0
    v3 = sum_1(v1, v2)
    del v1, v2
    v4 = 5
    v5 = spiral_wrap(int(v3), 32, True)
    del v3
    v6 = spiral_wrap(v4 * 2, 32, True)
    v7 = spiral_wrap(v4 + v6, 32, True)
    del v4, v6
    v8 = spiral_wrap(v5 + v7, 32, True)
    del v5, v7
    return v8

if __name__ == '__main__': sys.exit(main())
