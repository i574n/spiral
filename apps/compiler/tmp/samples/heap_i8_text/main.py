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
    v0 : i8
    v1 : string
def main():
    v0 = 100
    v1 = "hi"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3, v4 = v2.v0, v2.v1
    del v2
    v5 = v3 == 100
    del v3
    if v5:
        v6 = v4 == "hi"
        v7 = v6
    else:
        v7 = False
    del v4, v5
    if v7:
        del v7
        return 0
    else:
        del v7
        return 1

if __name__ == '__main__': sys.exit(main())
