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
def method0(v0 : i32) -> Tuple[string, string]:
    v1 = v0 == 0
    del v0
    if v1:
        del v1
        v2 = "no"
        return v2, v2
    else:
        del v1
        v3 = "hi"
        v4 = "yo"
        return v3, v4
def main():
    v0 = 7
    v1, v2 = method0(v0)
    del v0
    v3 = v1 == "hi"
    del v1
    if v3:
        v4 = v2 == "yo"
        v5 = v4
    else:
        v5 = False
    del v2, v3
    if v5:
        del v5
        return 0
    else:
        del v5
        return 1

if __name__ == '__main__': sys.exit(main())
