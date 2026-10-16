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
    v0 = 5000000000
    v1 = -4
    v2 = v0 // v1
    del v0, v1
    v3 = 1000000
    v4 = v3 * v3
    del v3
    v5 = -8
    v6 = v5 >> 1
    del v5
    v7 = 7
    v8 = i64(v7)
    v9 = 9
    v10 = i32(v9)
    del v9
    v11 = 4294967296
    v12 = v11 + 1
    v13 = v11 >> 1
    del v11
    v14 = u64(v7)
    del v7
    v15 = v2 == -1250000000
    del v2
    if v15:
        v16 = v4 == 1000000000000
        v17 = v16
    else:
        v17 = False
    del v4, v15
    if v17:
        v18 = v6 == -4
        v19 = v18
    else:
        v19 = False
    del v6, v17
    if v19:
        v20 = v8 == 7
        v21 = v20
    else:
        v21 = False
    del v8, v19
    if v21:
        v22 = v10 == 9
        v23 = v22
    else:
        v23 = False
    del v10, v21
    if v23:
        v24 = v12 == 4294967297
        v25 = v24
    else:
        v25 = False
    del v12, v23
    if v25:
        v26 = v13 == 2147483648
        v27 = v26
    else:
        v27 = False
    del v13, v25
    if v27:
        v28 = v14 == 7
        v29 = v28
    else:
        v29 = False
    del v14, v27
    if v29:
        del v29
        return 0
    else:
        del v29
        return 1

if __name__ == '__main__': sys.exit(main())
