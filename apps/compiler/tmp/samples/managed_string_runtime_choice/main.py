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
def choose_0(v0 : bool) -> string:
    if v0:
        del v0
        v1 = "alpha"
        return v1
    else:
        del v0
        v2 = "beta"
        return v2
def measure_1(v0 : string) -> i32:
    v1 = len(v0)
    del v0
    return v1
def main():
    v0 = True
    v1 = choose_0(v0)
    del v0
    v2 = False
    v3 = choose_0(v2)
    del v2
    v4 = measure_1(v1)
    v5 = measure_1(v1)
    del v1
    v6 = v4 + v5
    del v4, v5
    v7 = measure_1(v3)
    del v3
    v8 = v6 + v7
    del v6, v7
    v9 = v8 - 14
    del v8
    return v9

if __name__ == '__main__': sys.exit(main())
