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
def left_c0(env_v0 : string, env_v1 : i32):
    def inner(v2 : i32) -> i32:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 > 0
        if v3:
            del v3
            v4 = len(v0)
            del v0
            v5 = v4 + v1
            del v1, v4
            v6 = v5 + v2
            del v5
            return v6
        else:
            del v0, v1, v3
            return 0
    return inner
def right_c1(env_v0 : string, env_v1 : i32):
    def inner(v2 : i32) -> i32:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 > 0
        if v3:
            del v3
            v4 = len(v0)
            del v0
            v5 = v4 + v1
            del v1, v4
            v6 = v5 + v2
            del v5
            v7 = v6 - 1
            del v6
            return v7
        else:
            del v0, v1, v3
            return -1
    return inner
def method0(v0 : Callable[[i32], i32]) -> i32:
    return v0(37)
def main():
    v0 = "abc"
    v1 = "wxyz"
    v2 = 2
    v3 = 2
    v4 = True
    if v4:
        v7 = left_c0(v0, v2)
    else:
        v7 = right_c1(v1, v3)
    del v0, v1, v2, v3, v4
    return method0(v7)

if __name__ == '__main__': sys.exit(main())
