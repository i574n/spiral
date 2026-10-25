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
class US0_One(NamedTuple): # One
    v0 : i32
    tag = 0
class US0_Both(NamedTuple): # Both
    v0 : i32
    v1 : i32
    tag = 1
US0 = Union[US0_One, US0_Both]
def sum_0(v0 : US0) -> i32:
    match v0:
        case US0_Both(v2, v3): # Both
            del v0
            v4 = spiral_wrap(v2 * 10, 32, True)
            del v2
            v5 = spiral_wrap(v4 + v3, 32, True)
            del v3, v4
            return v5
        case US0_One(v1): # One
            del v0
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    if v0:
        v3 = US0_Both(3, 4)
    else:
        v3 = US0_One(1)
    if v0:
        v6 = US0_One(5)
    else:
        v6 = US0_Both(1, 1)
    del v0
    v7 = sum_0(v3)
    del v3
    v8 = v7 == 34
    del v7
    if v8:
        v9 = sum_0(v6)
        v10 = v9 == 5
        del v9
        v11 = v10
    else:
        v11 = False
    del v6, v8
    if v11:
        del v11
        return 0
    else:
        del v11
        return 1

if __name__ == '__main__': sys.exit(main())
