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
def f_c0():
    def inner(v0 : i32) -> Tuple[i32, i32]:
        v1 = spiral_wrap(v0 + 1, 32, True)
        return v0, v1
    return inner
def main():
    v0 = 3
    v1 = f_c0()
    v2, v3 = v1(v0)
    del v0, v1
    v4 = v2 == 3
    del v2
    if v4:
        v5 = v3 == 4
        v6 = v5
    else:
        v6 = False
    del v3, v4
    if v6:
        del v6
        return 0
    else:
        del v6
        return 1

if __name__ == '__main__': sys.exit(main())
