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
def method0(v0 : i32) -> bool:
    v1 = v0 < 10
    del v0
    return v1
def main():
    v0 = 0
    v1 = 0
    while method0(v0):
        v3 = v1 + v0
        v1 = v3
        del v3
        v4 = v0 + 1
        v0 = v4
        del v4
    del v0
    v5 = v1 - 45
    del v1
    return v5

if __name__ == '__main__': sys.exit(main())
