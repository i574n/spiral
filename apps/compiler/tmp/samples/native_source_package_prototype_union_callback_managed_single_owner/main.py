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
class US0_Text(NamedTuple): # Text
    v0 : string
    tag = 1
US0 = Union[US0_Idle, US0_Text]
def closure0():
    def inner(v0 : i32) -> US0:
        v1 = "managed"
        return US0_Text(v1)
    return inner
def method0(v0 : Callable[[i32], US0]) -> US0:
    return v0(2)
def main():
    v0 = closure0()
    v1 = method0(v0)
    del v0
    match v1:
        case US0_Idle(): # Idle
            v4 = 3
        case US0_Text(_): # Text
            v4 = 11
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1
    v5 = v4 + 31
    del v4
    return v5

if __name__ == '__main__': sys.exit(main())
