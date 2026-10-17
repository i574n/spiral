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

def main():
    v0 = "a"
    v1 = "b"
    v2 = "é"
    v3 = "éx"
    v4 = ""
    v5 = v0 < v0
    if v5:
        del v0, v1, v2, v3, v4, v5
        return 1
    else:
        del v5
        v6 = v0 < v1
        if v6:
            v7 = v1 < v2
            v8 = v7
        else:
            v8 = False
        del v6
        if v8:
            v9 = v2 < v3
            v10 = v9
        else:
            v10 = False
        del v8
        if v10:
            v11 = v4 < v0
            v12 = v11
        else:
            v12 = False
        del v4, v10
        if v12:
            v13 = v0 <= v0
            v14 = v13
        else:
            v14 = False
        del v12
        if v14:
            v15 = v0 >= v0
            v16 = v15
        else:
            v16 = False
        del v14
        if v16:
            v17 = v3 > v2
            v18 = v17
        else:
            v18 = False
        del v2, v3, v16
        if v18:
            v19 = v1 >= v0
            v20 = v19
        else:
            v20 = False
        del v0, v1, v18
        if v20:
            del v20
            return 0
        else:
            del v20
            return 1

if __name__ == '__main__': sys.exit(main())
