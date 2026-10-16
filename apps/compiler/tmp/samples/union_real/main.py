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
class US0_Real(NamedTuple): # Real
    v0 : f64
    tag = 0
class US0_Whole(NamedTuple): # Whole
    v0 : i32
    tag = 1
US0 = Union[US0_Real, US0_Whole]
def twice_1(v0 : f64) -> i32:
    v1 = v0 * 2.0
    del v0
    v2 = i32(v1)
    del v1
    return v2
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Real(v1): # Real
            del v0
            return twice_1(v1)
        case US0_Whole(v3): # Whole
            del v0
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    v1 = 1.5
    if v0:
        v4 = US0_Real(v1)
    else:
        v4 = US0_Whole(1)
    if v0:
        v7 = US0_Whole(5)
    else:
        v7 = US0_Real(v1)
    del v0, v1
    v8 = score_0(v4)
    del v4
    v9 = v8 == 3
    del v8
    if v9:
        v10 = score_0(v7)
        v11 = v10 == 5
        del v10
        v12 = v11
    else:
        v12 = False
    del v7, v9
    if v12:
        del v12
        return 0
    else:
        del v12
        return 1

if __name__ == '__main__': sys.exit(main())
