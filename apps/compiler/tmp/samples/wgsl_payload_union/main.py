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
class US0_Circle(NamedTuple): # Circle
    v0 : i32
    tag = 0
class US0_Rect(NamedTuple): # Rect
    v0 : i32
    v1 : i32
    tag = 1
class US0_Empty(NamedTuple): # Empty
    tag = 2
US0 = Union[US0_Circle, US0_Rect, US0_Empty]
def main():
    v0 = 2
    v1 = US0_Circle(v0)
    del v0
    v2 = 3
    v3 = 4
    v4 = US0_Rect(v2, v3)
    del v2, v3
    v5 = US0_Empty()
    v6 = 2
    v7 = US0_Circle(v6)
    del v6
    match v1, v7:
        case US0_Circle(v8), US0_Circle(v9): # Circle
            v10 = v8 == v9
            del v8, v9
            v18 = v10
        case US0_Empty(), US0_Empty(): # Empty
            v18 = True
        case US0_Rect(v11, v12), US0_Rect(v13, v14): # Rect
            v15 = v11 == v13
            del v11, v13
            if v15:
                del v15
                v16 = v12 == v14
                del v12, v14
                v18 = v16
            else:
                del v12, v14, v15
                v18 = False
        case t:
            v18 = False
    del v7
    if v18:
        v19 = 100
    else:
        v19 = 0
    del v18
    match v1:
        case US0_Circle(v20): # Circle
            v21 = spiral_wrap(3 * v20, 32, True)
            v22 = spiral_wrap(v21 * v20, 32, True)
            del v20, v21
            v28 = v22
        case US0_Empty(): # Empty
            v28 = 0
        case US0_Rect(v23, v24): # Rect
            v25 = spiral_wrap(v23 * v24, 32, True)
            del v23, v24
            v28 = v25
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1
    match v4:
        case US0_Circle(v29): # Circle
            v30 = spiral_wrap(3 * v29, 32, True)
            v31 = spiral_wrap(v30 * v29, 32, True)
            del v29, v30
            v37 = v31
        case US0_Empty(): # Empty
            v37 = 0
        case US0_Rect(v32, v33): # Rect
            v34 = spiral_wrap(v32 * v33, 32, True)
            del v32, v33
            v37 = v34
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v4
    v38 = spiral_wrap(v28 + v37, 32, True)
    del v28, v37
    match v5:
        case US0_Circle(v39): # Circle
            v40 = spiral_wrap(3 * v39, 32, True)
            v41 = spiral_wrap(v40 * v39, 32, True)
            del v39, v40
            v47 = v41
        case US0_Empty(): # Empty
            v47 = 0
        case US0_Rect(v42, v43): # Rect
            v44 = spiral_wrap(v42 * v43, 32, True)
            del v42, v43
            v47 = v44
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v5
    v48 = spiral_wrap(v38 + v47, 32, True)
    del v38, v47
    v49 = spiral_wrap(v48 + v19, 32, True)
    del v19, v48
    return v49

if __name__ == '__main__': sys.exit(main())
