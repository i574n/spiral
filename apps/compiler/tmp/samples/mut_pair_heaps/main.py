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
class Heap0(NamedTuple):
    v0 : i32
    v1 : string
@dataclass
class Mut0:
    v0 : Heap0
    v1 : Heap0
def main():
    v0 = 1
    v1 = "no"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 2
    v4 = "zz"
    v5 = Heap0(v3, v4)
    del v3, v4
    v6 = Mut0(v2, v5)
    del v2, v5
    v7 = 7
    v8 = "hi"
    v9 = Heap0(v7, v8)
    del v7, v8
    v10 = 4
    v11 = "yo"
    v12 = Heap0(v10, v11)
    del v10, v11
    v6.v0 = v9
    v6.v1 = v12
    del v9, v12
    v13, v14 = v6.v0, v6.v1
    del v6
    v15, v16 = v13.v0, v13.v1
    del v13
    v17, v18 = v14.v0, v14.v1
    del v14
    v19 = v15 == 7
    del v15
    if v19:
        v20 = v16 == "hi"
        v21 = v20
    else:
        v21 = False
    del v16, v19
    if v21:
        v22 = v17 == 4
        v23 = v22
    else:
        v23 = False
    del v17, v21
    if v23:
        v24 = v18 == "yo"
        v25 = v24
    else:
        v25 = False
    del v18, v23
    if v25:
        del v25
        return 0
    else:
        del v25
        return 1

if __name__ == '__main__': sys.exit(main())
