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
    v0 = float('nan')
    v1 = float('nan')
    v2 = 1.0
    v3 = 1.0
    v4 = math.isnan(v0)
    del v0
    if v4:
        v5 = math.isnan(v1)
        v6 = v5
    else:
        v6 = False
    del v1, v4
    if v6:
        del v6
        v7 = math.isnan(v2)
        del v2
        if v7:
            v9 = True
        else:
            v8 = math.isnan(v3)
            v9 = v8
        del v3, v7
        if v9:
            del v9
            return 2
        else:
            del v9
            return 0
    else:
        del v2, v3, v6
        return 1

if __name__ == '__main__': sys.exit(main())
