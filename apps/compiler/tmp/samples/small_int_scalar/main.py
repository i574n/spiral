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
    v0 = 100
    v1 = spiral_wrap(v0 + v0, 8, True)
    del v0
    v2 = 200
    v3 = 100
    v4 = spiral_wrap(v2 + v3, 8, False)
    del v3
    v5 = -8
    v6 = v5 >> 1
    del v5
    v7 = v2 >> 1
    del v2
    v8 = 20000
    v9 = spiral_wrap(v8 + v8, 16, True)
    del v8
    v10 = 40000
    v11 = spiral_wrap(v10 + v10, 16, False)
    del v10
    v12 = 7
    v13 = spiral_wrap(int(v12), 8, True)
    del v12
    v14 = 9
    v15 = spiral_wrap(int(v14), 32, True)
    del v14
    v16 = v1 == -56
    del v1
    if v16:
        v17 = v4 == 44
        v18 = v17
    else:
        v18 = False
    del v4, v16
    if v18:
        v19 = v6 == -4
        v20 = v19
    else:
        v20 = False
    del v6, v18
    if v20:
        v21 = v7 == 100
        v22 = v21
    else:
        v22 = False
    del v7, v20
    if v22:
        v23 = v9 == -25536
        v24 = v23
    else:
        v24 = False
    del v9, v22
    if v24:
        v25 = v11 == 14464
        v26 = v25
    else:
        v26 = False
    del v11, v24
    if v26:
        v27 = v13 == 7
        v28 = v27
    else:
        v28 = False
    del v13, v26
    if v28:
        v29 = v15 == 9
        v30 = v29
    else:
        v30 = False
    del v15, v28
    if v30:
        del v30
        return 0
    else:
        del v30
        return 1

if __name__ == '__main__': sys.exit(main())
