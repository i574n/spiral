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

def main():
    v0 = 3
    v1 = 4
    v2 = 1
    v3 = 1
    v4 = 1.5
    v5 = -v4
    del v4
    v6 = v0 == v1
    del v0, v1
    v7 = v6 != True
    del v6
    if v7:
        del v7
        v8 = v2 == v3
        del v2, v3
        v9 = v8 != True
        del v8
        if v9:
            del v5, v9
            return 2
        else:
            del v9
            v10 = v5 == -1.5
            del v5
            if v10:
                del v10
                return 0
            else:
                del v10
                return 3
    else:
        del v2, v3, v5, v7
        return 1

if __name__ == '__main__': sys.exit(main())
