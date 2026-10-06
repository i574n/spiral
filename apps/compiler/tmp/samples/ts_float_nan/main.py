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
def main():
    v6 = float('nan')
    v13 = float('nan')
    v14 = 1.0
    v15 = 1.0
    v16 = math.isnan(v6)
    del v6
    if v16:
        v17 = math.isnan(v13)
        v18 = v17
    else:
        v18 = False
    del v13, v16
    if v18:
        del v18
        v19 = math.isnan(v14)
        del v14
        if v19:
            v21 = True
        else:
            v20 = math.isnan(v15)
            v21 = v20
        del v15, v19
        if v21:
            del v21
            return 2
        else:
            del v21
            return 0
    else:
        del v14, v15, v18
        return 1

if __name__ == '__main__': result = main(); None if result is None else print(result)
