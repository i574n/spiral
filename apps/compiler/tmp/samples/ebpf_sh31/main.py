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
    v0 = 1
    v1 = 0
    v2 = 31
    v3 = spiral_wrap(v0 << v2, 32, False)
    v4 = v3 >> v2
    del v2
    v5 = spiral_wrap(v0 << v1, 32, False)
    del v0, v1
    v6 = v3 == 2147483648
    del v3
    if v6:
        v7 = v4 == 1
        v8 = v7
    else:
        v8 = False
    del v4, v6
    if v8:
        v9 = v5 == 1
        v10 = v9
    else:
        v10 = False
    del v5, v8
    if v10:
        del v10
        return 0
    else:
        del v10
        return 1

if __name__ == '__main__': sys.exit(main())
