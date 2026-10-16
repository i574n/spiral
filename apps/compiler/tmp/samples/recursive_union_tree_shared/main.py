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
UH0 = Union["UH0_Leaf", "UH0_Node"]
class UH0_Leaf(NamedTuple): # Leaf
    tag = 0
class UH0_Node(NamedTuple): # Node
    v0 : i32
    v1 : UH0
    v2 : UH0
    tag = 1
def sum_0(v0 : UH0) -> i32:
    match v0:
        case UH0_Leaf(): # Leaf
            del v0
            return 0
        case UH0_Node(v1, v2, v3): # Node
            del v0
            v4 = sum_0(v2)
            del v2
            v5 = sum_0(v3)
            del v3
            v6 = v4 + v5
            del v4, v5
            v7 = v1 + v6
            del v1, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 1
    v1 = 2
    v2 = UH0_Leaf()
    v3 = UH0_Node(v1, v2, v2)
    del v1, v2
    v4 = UH0_Node(v0, v3, v3)
    del v0, v3
    v5 = sum_0(v4)
    del v4
    v6 = v5 - 5
    del v5
    return v6

if __name__ == '__main__': sys.exit(main())
