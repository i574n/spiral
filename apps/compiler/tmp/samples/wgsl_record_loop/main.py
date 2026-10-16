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
def loop_0(v0 : i32, v1 : i32, v2 : i32, v3 : i32) -> Tuple[i32, i32]:
    v4 = v1 >= v0
    if v4:
        v9, v10 = v2, v3
    else:
        v5 = v1 + 1
        v6 = v2 + 1
        v7, v8 = loop_0(v0, v5, v6, v3)
        del v5, v6
        v9, v10 = v7, v8
    del v0, v1, v2, v3, v4
    return v9, v10
def main():
    v0 = 5
    v1 = 0
    v2 = 1
    v3 = 2
    v4, v5 = loop_0(v0, v1, v2, v3)
    del v0, v1, v2, v3
    v6 = v4 + v5
    del v4, v5
    return v6

if __name__ == '__main__': sys.exit(main())
