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
sys.setrecursionlimit(1 << 30)

class Heap0(NamedTuple):
    v0 : i32
    v1 : string
class Heap1(NamedTuple):
    v0 : Heap0
    v1 : i32
class Heap2(NamedTuple):
    v0 : Heap1
    v1 : i32
def main():
    v0 = 7
    v1 = "hi"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 1
    v4 = Heap1(v2, v3)
    del v2, v3
    v5 = 2
    v6 = Heap2(v4, v5)
    del v4, v5
    v7, v8 = v6.v0, v6.v1
    del v6
    v9, v10 = v7.v0, v7.v1
    del v7
    v11, v12 = v9.v0, v9.v1
    del v9
    v13 = v11 == 7
    del v11
    if v13:
        v14 = v12 == "hi"
        v15 = v14
    else:
        v15 = False
    del v12, v13
    if v15:
        v16 = v10 == 1
        v17 = v16
    else:
        v17 = False
    del v10, v15
    if v17:
        v18 = v8 == 2
        v19 = v18
    else:
        v19 = False
    del v8, v17
    if v19:
        del v19
        return 0
    else:
        del v19
        return 1

if __name__ == '__main__': sys.exit(main())
