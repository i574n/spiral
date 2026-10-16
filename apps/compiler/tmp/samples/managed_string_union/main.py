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
class US0_Text(NamedTuple): # Text
    v0 : string
    tag = 0
class US0_Number(NamedTuple): # Number
    v0 : i32
    tag = 1
US0 = Union[US0_Text, US0_Number]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Number(v3): # Number
            del v0
            return v3
        case US0_Text(v1): # Text
            del v0
            v2 = len(v1)
            del v1
            return v2
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = False
    if v0:
        v4 = US0_Number(7)
    else:
        v2 = "qwe"
        v4 = US0_Text(v2)
    del v0
    v5 = score_0(v4)
    v6 = score_0(v4)
    del v4
    v7 = v5 + v6
    del v5, v6
    v8 = v7 - 6
    del v7
    return v8

if __name__ == '__main__': sys.exit(main())
