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
class US0_None(NamedTuple): # None
    tag = 0
class US0_Some(NamedTuple): # Some
    v0 : i32
    tag = 1
US0 = Union[US0_None, US0_Some]
class Heap0(NamedTuple):
    v0 : US0
    v1 : i32
def main():
    v0 = 3
    v1 = 4
    v2 = US0_Some(v0)
    del v0
    v3 = Heap0(v2, v1)
    del v1, v2
    v4, v5 = v3.v0, v3.v1
    del v3
    match v4:
        case US0_None(): # None
            del v4, v5
            return 1
        case US0_Some(v6): # Some
            del v4
            v7 = v6 + v5
            del v5, v6
            v8 = v7 == 7
            del v7
            if v8:
                del v8
                return 0
            else:
                del v8
                return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
