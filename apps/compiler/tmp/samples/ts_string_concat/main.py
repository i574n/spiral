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
def method0(v0 : bool) -> string:
    if v0:
        del v0
        v1 = "spi"
        return v1
    else:
        del v0
        v2 = "bad"
        return v2
def method1(v0 : bool) -> string:
    if v0:
        del v0
        v1 = "bad"
        return v1
    else:
        del v0
        v2 = "ral"
        return v2
def main():
    v0 = True
    v1 = method0(v0)
    del v0
    v2 = False
    v3 = method1(v2)
    del v2
    v4 = v1 + v3
    del v1, v3
    v5 = len(v4)
    v6 = v5 == 6
    del v5
    if v6:
        del v6
        v7 = v4[0]
        v8 = v7 == 's'
        del v7
        if v8:
            del v8
            v9 = v4[5]
            del v4
            v10 = v9 == 'l'
            del v9
            if v10:
                del v10
                return 0
            else:
                del v10
                return 1
        else:
            del v4, v8
            return 2
    else:
        del v4, v6
        return 3

if __name__ == '__main__': sys.exit(main())
