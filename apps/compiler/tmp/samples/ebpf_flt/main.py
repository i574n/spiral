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
def main():
    v0 = -2.0
    v1 = -1.0
    v2 = 0.0
    v3 = v0 < v1
    if v3:
        v4 = v1 < v2
        v5 = v4
    else:
        v5 = False
    del v3
    if v5:
        v6 = v0 > v1
        v7 = v6 == False
        del v6
        v8 = v7
    else:
        v8 = False
    del v5
    if v8:
        v9 = v0 >= v1
        v10 = v9 == False
        del v9
        v11 = v10
    else:
        v11 = False
    del v0, v8
    if v11:
        v12 = v1 <= v2
        v13 = v12
    else:
        v13 = False
    del v1, v2, v11
    if v13:
        del v13
        return 0
    else:
        del v13
        return 1

if __name__ == '__main__': sys.exit(main())
