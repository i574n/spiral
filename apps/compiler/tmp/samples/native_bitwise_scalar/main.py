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
    v0 = 43
    v1 = 15
    v2 = 2
    v3 = 5
    v4 = v0 & v1
    v5 = v0 | v1
    v6 = v0 ^ v1
    del v1
    v7 = ~v0
    del v0
    v8 = v7 & 255
    del v7
    v9 = 1 << v3
    del v3
    v10 = 168 >> v2
    del v2
    v11 = v4 - 11
    del v4
    v12 = v10 + v11
    del v10, v11
    v13 = v5 - 47
    del v5
    v14 = v12 + v13
    del v12, v13
    v15 = v6 - 36
    del v6
    v16 = v14 + v15
    del v14, v15
    v17 = v8 - 212
    del v8
    v18 = v16 + v17
    del v16, v17
    v19 = v9 - 32
    del v9
    v20 = v18 + v19
    del v18, v19
    return v20

if __name__ == '__main__': sys.exit(main())
