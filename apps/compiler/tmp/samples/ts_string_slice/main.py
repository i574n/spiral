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
def middle_0(v0 : string) -> string:
    v1 = v0[1:3]
    del v0
    return v1
def main():
    v0 = "alpha"
    v1 = middle_0(v0)
    del v0
    v2 = len(v1)
    v3 = v2 == 3
    del v2
    if v3:
        del v3
        v4 = v1[0]
        v5 = v4 == 'l'
        del v4
        if v5:
            del v5
            v6 = v1[2]
            del v1
            v7 = v6 == 'h'
            del v6
            if v7:
                del v7
                return 0
            else:
                del v7
                return 1
        else:
            del v1, v5
            return 2
    else:
        del v1, v3
        return 3

if __name__ == '__main__': sys.exit(main())
