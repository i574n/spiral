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

def f_c0(env_v0 : string):
    def inner(v1 : i32) -> Tuple[string, string]:
        nonlocal env_v0
        v0 = env_v0
        v2 = v1 == 0
        if v2:
            del v0, v2
            v3 = "no"
            return v3, v3
        else:
            del v2
            v4 = "yo"
            return v0, v4
    return inner
def main():
    v0 = "hi"
    v1 = f_c0(v0)
    del v0
    v2, v3 = v1(1)
    del v1
    v4 = v2 == "hi"
    del v2
    if v4:
        v5 = v3 == "yo"
        v6 = v5
    else:
        v6 = False
    del v3, v4
    if v6:
        del v6
        return 0
    else:
        del v6
        return 1

if __name__ == '__main__': sys.exit(main())
