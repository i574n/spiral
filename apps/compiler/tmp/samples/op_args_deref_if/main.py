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
    v0 : string
def main():
    v0 = "deref"
    v1 = Mut0(v0)
    del v0
    v2 = 3
    v3 = "deref!"
    v1.v0 = v3
    del v3
    v4 = v1.v0
    del v1
    v5 = v2 == 3
    if v5:
        v6 = v2 + 1
        v7 = v6
    else:
        v7 = 0
    del v5
    print(v4, " ", v7, "\n", sep='', end='')
    del v4, v7
    v8 = v2 * 2
    v9 = v2 > 0
    del v2
    if v9:
        v10 = 6
    else:
        v10 = 0
    del v9
    v11 = v8 == v10
    del v8, v10
    if v11:
        del v11
        return 0
    else:
        del v11
        return 1

if __name__ == '__main__': sys.exit(main())
