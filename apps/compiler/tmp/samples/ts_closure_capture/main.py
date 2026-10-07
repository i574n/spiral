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
def Closure0(env_v0 : i32, env_v1 : i32):
    def inner(v2 : i32) -> i32:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v0 + v1
        del v0, v1
        v4 = v3 + v2
        del v3
        return v4
    return inner
def main():
    v0 = 1
    v1 = 2
    v2 = Closure0(v0, v1)
    del v0, v1
    return v2(39)

if __name__ == '__main__': sys.exit(main())
