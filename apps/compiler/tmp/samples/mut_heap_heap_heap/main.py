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
class Heap2(NamedTuple):
    v0 : Heap1
    v1 : i32
@dataclass
class Mut0:
    v0 : Heap2
def main():
    v0 = 3
    v1 = "no"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 1
    v4 = Heap1(v2, v3)
    del v2, v3
    v5 = 2
    v6 = Heap2(v4, v5)
    del v4, v5
    v7 = Mut0(v6)
    del v6
    v8 = 7
    v9 = "hi"
    v10 = Heap0(v8, v9)
    del v8, v9
    v11 = 4
    v12 = Heap1(v10, v11)
    del v10, v11
    v13 = 5
    v14 = Heap2(v12, v13)
    del v12, v13
    v7.v0 = v14
    del v14
    v15 = v7.v0
    del v7
    v16, v17 = v15.v0, v15.v1
    del v15
    v18, v19 = v16.v0, v16.v1
    del v16
    v20, v21 = v18.v0, v18.v1
    del v18
    v22 = v20 == 7
    del v20
    if v22:
        v23 = v21 == "hi"
        v24 = v23
    else:
        v24 = False
    del v21, v22
    if v24:
        v25 = v19 == 4
        v26 = v25
    else:
        v26 = False
    del v19, v24
    if v26:
        v27 = v17 == 5
        v28 = v27
    else:
        v28 = False
    del v17, v26
    if v28:
        del v28
        return 0
    else:
        del v28
        return 1

if __name__ == '__main__': sys.exit(main())
