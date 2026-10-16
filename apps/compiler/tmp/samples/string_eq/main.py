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
    v0 = "é"
    v1 = "x"
    v2 = v0 + v1
    del v1
    v3 = "éx"
    v4 = "éy"
    v5 = ""
    v6 = v3[1:(0) + 1]
    v7 = v2 == v3
    if v7:
        v8 = v2 != v4
        v9 = v8
    else:
        v9 = False
    del v2, v4, v7
    if v9:
        v10 = v0 != v3
        v11 = v10
    else:
        v11 = False
    del v3, v9
    if v11:
        v12 = v5 == v6
        v13 = v12
    else:
        v13 = False
    del v6, v11
    if v13:
        v14 = v5 != v0
        v15 = v14
    else:
        v15 = False
    del v0, v5, v13
    if v15:
        del v15
        return 0
    else:
        del v15
        return 1

if __name__ == '__main__': sys.exit(main())
