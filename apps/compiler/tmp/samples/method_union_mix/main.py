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

class US0_One(NamedTuple): # One
    v0 : i32
    tag = 0
class US0_Both(NamedTuple): # Both
    v0 : i32
    v1 : string
    tag = 1
US0 = Union[US0_One, US0_Both]
def method0(v0 : i32, v1 : string) -> US0:
    v2 = v0 == 0
    if v2:
        del v0, v1, v2
        return US0_One(0)
    else:
        del v2
        return US0_Both(v0, v1)
def main():
    v0 = 3
    v1 = "hi"
    v2 = method0(v0, v1)
    del v0, v1
    match v2:
        case US0_Both(v4, v5): # Both
            del v2
            v6 = v4 == 3
            del v4
            if v6:
                v7 = v5 == "hi"
                v8 = v7
            else:
                v8 = False
            del v5, v6
            if v8:
                del v8
                return 0
            else:
                del v8
                return 1
        case US0_One(_): # One
            del v2
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
