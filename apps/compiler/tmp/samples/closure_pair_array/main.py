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

def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def f_c0(env_v0 : i32, env_v1 : i32):
    def inner(v2 : i32) -> Tuple[cp.ndarray, cp.ndarray]:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = cp.zeros(1,dtype=cp.int32)
        v4 = cp.zeros(1,dtype=cp.int32)
        v5 = v2 == 0
        if v5:
            del v0, v1, v5
            v3[0] = 0
            v4[0] = 0
            return v3, v4
        else:
            del v5
            v3[0] = v0
            del v0
            v4[0] = v1
            del v1
            return v3, v4
    return inner
def main():
    v0 = 3
    v1 = 4
    v2 = f_c0(v0, v1)
    del v0, v1
    v3, v4 = v2(1)
    del v2
    v5 = spiral_array_index(v3, 0)
    del v3
    v6 = spiral_array_index(v4, 0)
    del v4
    v7 = spiral_wrap(v5 + v6, 32, True)
    del v5, v6
    v8 = v7 == 7
    del v7
    if v8:
        del v8
        return 0
    else:
        del v8
        return 1

if __name__ == '__main__': sys.exit(main())
