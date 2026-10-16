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
@dataclass
class Mut0:
    v0 : i32
def method0(v0 : Mut0) -> None:
    v1 = v0.v0
    v2 = v1 + 5
    del v1
    v0.v0 = v2
    del v0, v2
    return 
def method1(v0 : Mut0) -> None:
    del v0
    return 
def method2(v0 : Mut0) -> None:
    v1 = v0.v0
    v2 = v1 + 7
    del v1
    v0.v0 = v2
    del v0, v2
    return 
def main():
    v0 = Mut0(0)
    method0(v0)
    method1(v0)
    method2(v0)
    v1 = v0.v0
    del v0
    v2 = v1 - 12
    del v1
    return v2

if __name__ == '__main__': sys.exit(main())
