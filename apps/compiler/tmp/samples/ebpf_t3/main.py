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
def method2(v0 : i32, v1 : i32, v2 : i32, v3 : i32) -> Tuple[i32, i32, i32]:
    while True:
        v4 = v0 - 1
        del v0
        v5 = v1 + 1
        del v1
        v6 = v2 + 2
        del v2
        v7 = v3 + 3
        del v3
        v8 = v4 == 0
        if v8:
            del v4, v8
            return v5, v6, v7
        else:
            del v8
            v0, v1, v2, v3 = v4, v5, v6, v7
            continue
def method1(v0 : i32) -> Tuple[i32, i32, i32]:
    v1 = 0
    v2 = 0
    v3 = 0
    v4 = v0 == 0
    if v4:
        del v0, v4
        return v1, v2, v3
    else:
        del v4
        return method2(v0, v1, v2, v3)
def method0(v0 : i32) -> i32:
    v1, v2, v3 = method1(v0)
    del v0
    v4 = v1 == 3
    del v1
    if v4:
        v5 = v2 == 6
        v6 = v5
    else:
        v6 = False
    del v2, v4
    if v6:
        v7 = v3 == 9
        v8 = v7
    else:
        v8 = False
    del v3, v6
    if v8:
        del v8
        return 0
    else:
        del v8
        return 1
def main():
    v0 = 3
    return method0(v0)

if __name__ == '__main__': sys.exit(main())
