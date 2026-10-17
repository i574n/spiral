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
def main():
    v0 = 3
    v1 = -2
    v2 = 7
    v3 = 2.9
    v4 = f32(v0)
    del v0
    v5 = f32(v1)
    del v1
    v6 = f32(v2)
    del v2
    v7 = spiral_wrap(int(v3), 32, False)
    del v3
    v8 = v4 == 3.0
    del v4
    if v8:
        v9 = v5 == -2.0
        v10 = v9
    else:
        v10 = False
    del v5, v8
    if v10:
        v11 = v6 == 7.0
        v12 = v11
    else:
        v12 = False
    del v6, v10
    if v12:
        v13 = v7 == 2
        v14 = v13
    else:
        v14 = False
    del v7, v12
    if v14:
        del v14
        return 0
    else:
        del v14
        return 1

if __name__ == '__main__': sys.exit(main())
