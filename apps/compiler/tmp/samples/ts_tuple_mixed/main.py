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

def method0(v0 : f32) -> Tuple[bool, f32, i32]:
    v1 = v0 >= 3.5
    return v1, v0, 7
def method1(v0 : bool, v1 : f32, v2 : i32) -> i32:
    if v0:
        del v0
        v3 = v1 >= 3.5
        del v1
        if v3:
            del v3
            v4 = v2 - 7
            del v2
            return v4
        else:
            del v2, v3
            return 1
    else:
        del v0, v1, v2
        return 2
def main():
    v0 = 4.0
    v1, v2, v3 = method0(v0)
    del v0
    return method1(v1, v2, v3)

if __name__ == '__main__': result = main(); None if result is None else print(result)
