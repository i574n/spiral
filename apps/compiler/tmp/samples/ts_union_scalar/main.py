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
class US0_0(NamedTuple): # Hit
    v0 : i32
    tag = 0
class US0_1(NamedTuple): # Miss
    v0 : i32
    tag = 1
US0 = Union[US0_0, US0_1]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_0(v1): # Hit
            del v0
            return v1
        case US0_1(v2): # Miss
            del v0
            v3 = -v2
            del v2
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    if v0:
        v3 = US0_0(7)
    else:
        v3 = US0_1(3)
    del v0
    v4 = score_0(v3)
    del v3
    v5 = v4 - 7
    del v4
    return v5

if __name__ == '__main__': sys.exit(main())
