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

def method0(v0 : i32) -> f64:
    v1 = v0 == 0
    del v0
    if v1:
        del v1
        return 0.0
    else:
        del v1
        return 1.5
def main():
    v0 = 7
    v1 = method0(v0)
    del v0
    v2 = v1 == 1.5
    del v1
    if v2:
        del v2
        return 0
    else:
        del v2
        return 1

if __name__ == '__main__': sys.exit(main())
