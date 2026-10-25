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
UH0 = Union["UH0_Empty", "UH0_Box"]
class UH0_Empty(NamedTuple): # Empty
    tag = 0
class UH0_Box(NamedTuple): # Box
    v0 : i32
    v1 : UH0
    tag = 1
def method2(v0 : i32) -> UH0:
    v1 = spiral_wrap(v0 - 1, 32, True)
    del v0
    v2 = v1 == 0
    if v2:
        del v1, v2
        v3 = UH0_Empty()
        return UH0_Box(7, v3)
    else:
        del v2
        return method1(v1)
def method1(v0 : i32) -> UH0:
    v1 = spiral_wrap(v0 - 1, 32, True)
    del v0
    v2 = v1 == 0
    if v2:
        del v1, v2
        v3 = UH0_Empty()
        return UH0_Box(11, v3)
    else:
        del v2
        return method2(v1)
def method0() -> UH0:
    v0 = 1000000
    v1 = v0 == 0
    if v1:
        del v0, v1
        v2 = UH0_Empty()
        return UH0_Box(7, v2)
    else:
        del v1
        return method1(v0)
def main():
    v0 = method0()
    match v0:
        case UH0_Box(v1, _): # Box
            del v0
            v3 = v1 == 7
            del v1
            if v3:
                del v3
                return 0
            else:
                del v3
                return 3
        case UH0_Empty(): # Empty
            del v0
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
