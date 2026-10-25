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
    v0 = 1.5
    v1 = -2.0
    v2 = v0 / v1
    del v0, v1
    v3 = 1000000.0
    v4 = v3 * v3
    v5 = v4 * v3
    del v3, v4
    v6 = v5 * 10000.0
    del v5
    v7 = v6 * v6
    v8 = 3
    v9 = f64(v8)
    del v8
    v10 = 2.9
    v11 = -1.9
    v12 = spiral_wrap(int(v10), 32, True)
    del v10
    v13 = spiral_wrap(int(v11), 32, True)
    del v11
    v14 = 1.5
    v15 = f64(v14)
    del v14
    v16 = v2 == -0.75
    del v2
    if v16:
        v17 = v7 > v6
        v18 = v17
    else:
        v18 = False
    del v16
    if v18:
        v19 = v7 * v6
        v20 = v7 < v19
        del v19
        v21 = v20
    else:
        v21 = False
    del v6, v7, v18
    if v21:
        v22 = v9 == 3.0
        v23 = v22
    else:
        v23 = False
    del v9, v21
    if v23:
        v24 = v12 == 2
        v25 = v24
    else:
        v25 = False
    del v12, v23
    if v25:
        v26 = v13 == -1
        v27 = v26
    else:
        v27 = False
    del v13, v25
    if v27:
        v28 = v15 == 1.5
        v29 = v28
    else:
        v29 = False
    del v15, v27
    if v29:
        del v29
        return 0
    else:
        del v29
        return 1

if __name__ == '__main__': sys.exit(main())
