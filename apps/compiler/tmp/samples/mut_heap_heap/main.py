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
class Heap1(NamedTuple):
    v0 : Heap0
    v1 : i32
@dataclass
class Mut0:
    v0 : Heap1
def main():
    v0 = 3
    v1 = "no"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 1
    v4 = Heap1(v2, v3)
    del v2, v3
    v5 = Mut0(v4)
    del v4
    v6 = 7
    v7 = "hi"
    v8 = Heap0(v6, v7)
    del v6, v7
    v9 = 4
    v10 = Heap1(v8, v9)
    del v8, v9
    v5.v0 = v10
    del v10
    v11 = v5.v0
    del v5
    v12, v13 = v11.v0, v11.v1
    del v11
    v14, v15 = v12.v0, v12.v1
    del v12
    v16 = v14 == 7
    del v14
    if v16:
        v17 = v15 == "hi"
        v18 = v17
    else:
        v18 = False
    del v15, v16
    if v18:
        v19 = v13 == 4
        v20 = v19
    else:
        v20 = False
    del v13, v18
    if v20:
        del v20
        return 0
    else:
        del v20
        return 1

if __name__ == '__main__': sys.exit(main())
