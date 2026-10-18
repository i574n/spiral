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
def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
UH0 = Union["UH0_Link", "UH0_End"]
class UH0_Link(NamedTuple): # Link
    v0 : i32
    v1 : UH0
    tag = 0
class UH0_End(NamedTuple): # End
    tag = 1
def build_0(v0 : i32, v1 : UH0) -> UH0:
    while True:
        v2 = v0 == 0
        if v2:
            del v0, v2
            return v1
        else:
            del v2
            v3 = spiral_wrap(v0 - 1, 32, True)
            v4 = UH0_Link(v0, v1)
            del v0, v1
            v0, v1 = v3, v4
            continue
def sum_1(v0 : UH0, v1 : i32) -> i32:
    while True:
        match v0:
            case UH0_End(): # End
                del v0
                return v1
            case UH0_Link(v2, v3): # Link
                del v0
                v4 = spiral_wrap(v1 * 31, 32, True)
                del v1
                v5 = spiral_wrap(v4 + v2, 32, True)
                del v2, v4
                v6 = spiral_mod_trunc(v5, 9973)
                del v5
                v0, v1 = v3, v6
                continue
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 1000000
    v1 = UH0_End()
    v2 = build_0(v0, v1)
    del v0, v1
    v3 = 0
    v4 = sum_1(v2, v3)
    del v2, v3
    v5 = spiral_mod_trunc(v4, 256)
    del v4
    return v5

if __name__ == '__main__': sys.exit(main())
