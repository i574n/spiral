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

import math
import sys
def main():
    v0 = float('inf')
    v1 = float('inf')
    v2 = -v0
    v3 = -v1
    v4 = 1.0
    v5 = 1.0
    v6 = math.isnan(v4)
    if v6:
        v8 = True
    else:
        v7 = math.isnan(v5)
        v8 = v7
    del v6
    if v8:
        del v0, v1, v2, v3, v4, v5, v8
        return 3
    else:
        del v8
        v9 = v0 > v4
        del v0, v4
        if v9:
            v10 = v1 > v5
            v11 = v10
        else:
            v11 = False
        del v1, v5, v9
        if v11:
            del v11
            v12 = v2 < 0.0
            del v2
            if v12:
                v13 = v3 < 0.0
                v14 = v13
            else:
                v14 = False
            del v3, v12
            if v14:
                del v14
                return 0
            else:
                del v14
                return 2
        else:
            del v2, v3, v11
            return 1

if __name__ == '__main__': sys.exit(main())
