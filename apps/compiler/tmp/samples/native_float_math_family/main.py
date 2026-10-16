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
    v0 = 0.0
    v1 = 1.0
    v2 = 0.0
    v3 = 1.0
    v4 = math.log(v1)
    v5 = v4 == v0
    del v4
    if v5:
        v6 = math.log(v3)
        v7 = v6 == v2
        del v6
        v8 = v7
    else:
        v8 = False
    del v5
    if v8:
        v9 = math.exp(v0)
        v10 = v9 == v1
        del v9
        v11 = v10
    else:
        v11 = False
    del v8
    if v11:
        v12 = math.exp(v2)
        v13 = v12 == v3
        del v12
        v14 = v13
    else:
        v14 = False
    del v11
    if v14:
        v15 = math.tanh(v0)
        v16 = v15 == v0
        del v15
        v17 = v16
    else:
        v17 = False
    del v14
    if v17:
        v18 = math.tanh(v2)
        v19 = v18 == v2
        del v18
        v20 = v19
    else:
        v20 = False
    del v17
    if v20:
        v21 = math.sin(v0)
        v22 = v21 == v0
        del v21
        v23 = v22
    else:
        v23 = False
    del v20
    if v23:
        v24 = math.sin(v2)
        v25 = v24 == v2
        del v24
        v26 = v25
    else:
        v26 = False
    del v23
    if v26:
        v27 = math.cos(v0)
        v28 = v27 == v1
        del v27
        v29 = v28
    else:
        v29 = False
    del v0, v1, v26
    if v29:
        v30 = math.cos(v2)
        v31 = v30 == v3
        del v30
        v32 = v31
    else:
        v32 = False
    del v2, v3, v29
    if v32:
        del v32
        return 0
    else:
        del v32
        return 1

if __name__ == '__main__': sys.exit(main())
