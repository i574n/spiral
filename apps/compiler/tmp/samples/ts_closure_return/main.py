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

def Closure1(env_v0 : string):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        v2 = len(v0)
        del v0
        v3 = v2 + v1
        del v2
        return v3
    return inner
def Closure0():
    def inner(v0 : string) -> Callable[[i32], i32]:
        return Closure1(v0)
    return inner
def method0(v0 : Callable[[i32], i32]) -> i32:
    return v0(39)
def main():
    v0 = Closure0()
    v1 = "abc"
    v2 = v0(v1)
    del v0, v1
    return method0(v2)

if __name__ == '__main__': result = main(); None if result is None else print(result)
