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

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
class Heap0(NamedTuple):
    v0 : i32
class US0_None(NamedTuple): # None
    tag = 0
class US0_Some(NamedTuple): # Some
    v0 : i32
    tag = 1
US0 = Union[US0_None, US0_Some]
def f_c0(env_v0 : i32, env_v1 : Heap0):
    def inner(v2 : i32) -> Tuple[US0, Heap0]:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 == 0
        if v3:
            del v0, v3
            v4 = US0_None()
            return v4, v1
        else:
            del v3
            v5 = US0_Some(v0)
            del v0
            return v5, v1
    return inner
def main():
    v0 = 3
    v1 = 4
    v2 = Heap0(v1)
    del v1
    v3 = f_c0(v0, v2)
    del v0, v2
    v4, v5 = v3(1)
    del v3
    match v4:
        case US0_None(): # None
            del v4, v5
            return 1
        case US0_Some(v6): # Some
            del v4
            v7 = v5.v0
            del v5
            v8 = spiral_wrap(v6 + v7, 32, True)
            del v6, v7
            v9 = v8 == 7
            del v8
            if v9:
                del v9
                return 0
            else:
                del v9
                return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
