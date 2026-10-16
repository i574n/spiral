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
class US0_Both(NamedTuple): # Both
    v0 : i32
    v1 : string
    tag = 1
US0 = Union[US0_One, US0_Both]
def f_c0(env_v0 : i32, env_v1 : string):
    def inner(v2 : i32) -> US0:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 == 0
        if v3:
            del v0, v1, v3
            return US0_One(0)
        else:
            del v3
            return US0_Both(v0, v1)
    return inner
def main():
    v0 = 3
    v1 = "hi"
    v2 = f_c0(v0, v1)
    del v0, v1
    v3 = v2(1)
    del v2
    match v3:
        case US0_Both(v5, v6): # Both
            del v3
            v7 = v5 == 3
            del v5
            if v7:
                v8 = v6 == "hi"
                v9 = v8
            else:
                v9 = False
            del v6, v7
            if v9:
                del v9
                return 0
            else:
                del v9
                return 1
        case US0_One(_): # One
            del v3
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
