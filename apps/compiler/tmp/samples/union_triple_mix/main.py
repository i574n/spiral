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
class US0_One(NamedTuple): # One
    v0 : i32
    tag = 0
class US0_All(NamedTuple): # All
    v0 : i32
    v1 : string
    v2 : bool
    tag = 1
US0 = Union[US0_One, US0_All]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_All(v2, v3, v4): # All
            del v0
            v5 = v2 == 7
            del v2
            if v5:
                v6 = v3 == "hi"
                v7 = v6
            else:
                v7 = False
            del v3, v5
            v8 = v7 and v4
            del v4, v7
            if v8:
                del v8
                return 0
            else:
                del v8
                return 1
        case US0_One(v1): # One
            del v0
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    v1 = 7
    v2 = "hi"
    v3 = True
    if v0:
        v6 = US0_All(v1, v2, v3)
    else:
        v6 = US0_One(1)
    del v0, v1, v2, v3
    return score_0(v6)

if __name__ == '__main__': sys.exit(main())
