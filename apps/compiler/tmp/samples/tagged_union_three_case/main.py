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
class US0_Idle(NamedTuple): # Idle
    tag = 0
class US0_Hit(NamedTuple): # Hit
    v0 : i32
    tag = 1
class US0_Flag(NamedTuple): # Flag
    v0 : bool
    tag = 2
US0 = Union[US0_Idle, US0_Hit, US0_Flag]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Flag(v2): # Flag
            del v0
            if v2:
                del v2
                return 11
            else:
                del v2
                return 5
        case US0_Hit(v1): # Hit
            del v0
            return v1
        case US0_Idle(): # Idle
            del v0
            return 3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 2
    v1 = v0 == 0
    if v1:
        v7 = US0_Idle()
    else:
        v3 = v0 == 1
        if v3:
            del v3
            v7 = US0_Hit(7)
        else:
            del v3
            v7 = US0_Flag(True)
    del v0, v1
    v8 = score_0(v7)
    del v7
    v9 = v8 - 11
    del v8
    return v9

if __name__ == '__main__': sys.exit(main())
