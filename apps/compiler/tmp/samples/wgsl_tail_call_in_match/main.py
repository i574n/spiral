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
class US0_Done(NamedTuple): # Done
    v0 : i32
    tag = 0
class US0_More(NamedTuple): # More
    v0 : i32
    tag = 1
US0 = Union[US0_Done, US0_More]
def layers_0(v0 : i32) -> i32:
    while True:
        v1 = v0 >= 5
        if v1:
            v4 = US0_Done(v0)
        else:
            v4 = US0_More(v0)
        del v0, v1
        match v4:
            case US0_Done(v8): # Done
                del v4
                v9 = spiral_wrap(v8 * 2, 32, True)
                del v8
                return v9
            case US0_More(v5): # More
                del v4
                v6 = spiral_wrap(v5 + 1, 32, True)
                del v5
                v0 = v6
                continue
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 0
    return layers_0(v0)

if __name__ == '__main__': sys.exit(main())
