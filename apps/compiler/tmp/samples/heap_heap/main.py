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
def main():
    v0 = 7
    v1 = "hi"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 1
    v4 = Heap1(v2, v3)
    del v2, v3
    v5, v6 = v4.v0, v4.v1
    del v4
    v7, v8 = v5.v0, v5.v1
    del v5
    v9 = v7 == 7
    del v7
    if v9:
        v10 = v8 == "hi"
        v11 = v10
    else:
        v11 = False
    del v8, v9
    if v11:
        v12 = v6 == 1
        v13 = v12
    else:
        v13 = False
    del v6, v11
    if v13:
        del v13
        return 0
    else:
        del v13
        return 1

if __name__ == '__main__': sys.exit(main())
