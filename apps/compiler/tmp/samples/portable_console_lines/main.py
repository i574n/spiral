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
def main():
    v4 = "hello"
    print(v4)
    del v4
    v11 = 42
    print(v11)
    del v11
    v18 = "a"
    print(v18, end="")
    del v18
    v24 = "b"
    print(v24, end="")
    del v24
    v31 = ""
    print(v31)
    del v31
    v34 = -7
    print(v34)
    del v34
    return 0

if __name__ == '__main__': sys.exit(main())
