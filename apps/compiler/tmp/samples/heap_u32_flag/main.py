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
    v0 : u32
    v1 : string
    v2 : bool
def main():
    v0 = 4000000000
    v1 = "hi"
    v2 = True
    v3 = Heap0(v0, v1, v2)
    del v0, v1, v2
    v4, v5, v6 = v3.v0, v3.v1, v3.v2
    del v3
    v7 = v4 == 4000000000
    del v4
    if v7:
        v8 = v5 == "hi"
        v9 = v8
    else:
        v9 = False
    del v5, v7
    v10 = v9 and v6
    del v6, v9
    if v10:
        del v10
        return 0
    else:
        del v10
        return 1

if __name__ == '__main__': sys.exit(main())
