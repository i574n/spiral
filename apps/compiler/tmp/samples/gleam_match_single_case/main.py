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
class US0_Step(NamedTuple): # Step
    v0 : i32
    v1 : i32
    v2 : i32
    tag = 0
US0 = US0_Step
def walk_0(v0 : i32) -> i32:
    v1 = v0 > 2
    if v1:
        v2 = spiral_wrap(v0 + 1, 32, True)
        v3 = spiral_wrap(v0 + 2, 32, True)
        v6 = US0_Step(v0, v2, v3)
    else:
        v6 = US0_Step(0, 1, 2)
    del v0, v1
    match v6:
        case US0_Step(v7, v8, v9): # Step
            del v6
            v10 = spiral_wrap(v8 * v9, 32, True)
            del v8, v9
            v11 = spiral_wrap(v7 + v10, 32, True)
            del v7, v10
            return v11
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 5
    v1 = walk_0(v0)
    v2 = spiral_wrap(v0 - 4, 32, True)
    del v0
    v3 = walk_0(v2)
    del v2
    v4 = spiral_wrap(v1 + v3, 32, True)
    del v1, v3
    return v4

if __name__ == '__main__': sys.exit(main())
