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

@dataclass
class Mut0:
    v0 : string
def method3(v0 : Mut0, v1 : string) -> None:
    v2 = v0.v0
    v3 = v2 + v1 
    del v1, v2
    v0.v0 = v3
    del v0, v3
    return 
def format_real_2(v0 : i32) -> string:
    v1 = ""
    v2 = Mut0(v1)
    del v1
    v3 = f"{v0}"
    del v0
    method3(v2, v3)
    del v3
    v4 = v2.v0
    del v2
    return v4
def method1() -> string:
    v0 = "Some"
    v1 = "("
    v2 = v0 + v1 
    del v0, v1
    v3 = 1
    v4 = format_real_2(v3)
    del v3
    v5 = v2 + v4 
    del v2, v4
    v6 = ")"
    v7 = v5 + v6 
    del v5, v6
    return v7
def method0() -> string:
    v0 = method1()
    v1 = "x: "
    v2 = v1 + v0 
    del v0, v1
    return v2
def main():
    v0 = method0()
    v1 = v0 == ""
    del v0
    if v1:
        del v1
        return 1
    else:
        del v1
        return 0

if __name__ == '__main__': sys.exit(main())
