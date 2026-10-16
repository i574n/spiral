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
def closure0(env_v0 : US0):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        match v0:
            case US0_Flag(v3): # Flag
                if v3:
                    del v3
                    v7 = 11
                else:
                    del v3
                    v7 = 5
            case US0_Hit(v2): # Hit
                v7 = v2
            case US0_Idle(): # Idle
                v7 = 3
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v0
        v8 = v7 + v1
        del v7
        return v8
    return inner
def method0(v0 : Callable[[i32], i32]) -> i32:
    return v0(31)
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
    v8 = closure0(v7)
    del v7
    return method0(v8)

if __name__ == '__main__': sys.exit(main())
