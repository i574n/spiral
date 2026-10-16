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
def closure0(env_v0 : i32):
    def inner(v1 : i32, v2 : i32) -> Tuple[i32, i32]:
        nonlocal env_v0
        v0 = env_v0
        v3 = v1 - 8
        v4 = v3 + v0
        del v0, v3
        v5 = v2 - 18
        return v4, v5
    return inner
def method0(v0 : Callable[[i32, i32], Tuple[i32, i32]]) -> Tuple[i32, i32]:
    return v0(10, 20)
def main():
    v0 = 1
    v1 = closure0(v0)
    del v0
    v2, v3 = method0(v1)
    del v1
    v4 = 10 + v2
    del v2
    v5 = 20 + v3
    del v3
    v6 = v4 + v5
    del v4, v5
    v7 = v6 + 7
    del v6
    return v7

if __name__ == '__main__': sys.exit(main())
