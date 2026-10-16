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

def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
import sys
class US0_Empty(NamedTuple): # Empty
    tag = 0
class US0_Item(NamedTuple): # Item
    v0 : string
    v1 : cp.ndarray
    tag = 1
US0 = Union[US0_Empty, US0_Item]
def closure0():
    def inner(v0 : i32) -> US0:
        v1 = v0 == 0
        if v1:
            del v1
            return US0_Empty()
        else:
            del v1
            v3 = cp.empty(2,dtype=cp.int32)
            v3[0] = v0
            v4 = v0 + 1
            v3[1] = v4
            del v4
            v5 = "hi"
            return US0_Item(v5, v3)
    return inner
def method0(v0 : Callable[[i32], US0]) -> US0:
    return v0(0)
def method1(v0 : Callable[[i32], US0]) -> US0:
    return v0(4)
def main():
    v0 = closure0()
    v1 = method0(v0)
    match v1:
        case US0_Empty(): # Empty
            v12 = 3
        case US0_Item(v2, v3): # Item
            v4 = len(v2)
            del v2
            v5 = v3.size
            v6 = v4 + v5
            del v4, v5
            v7 = spiral_array_index(v3, 0)
            v8 = v6 + v7
            del v6, v7
            v9 = spiral_array_index(v3, 1)
            del v3
            v10 = v8 + v9
            del v8, v9
            v12 = v10
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1
    v13 = method1(v0)
    del v0
    match v13:
        case US0_Empty(): # Empty
            v24 = 3
        case US0_Item(v14, v15): # Item
            v16 = len(v14)
            del v14
            v17 = v15.size
            v18 = v16 + v17
            del v16, v17
            v19 = spiral_array_index(v15, 0)
            v20 = v18 + v19
            del v18, v19
            v21 = spiral_array_index(v15, 1)
            del v15
            v22 = v20 + v21
            del v20, v21
            v24 = v22
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v13
    v25 = v12 + v24
    del v12, v24
    v26 = v25 + 26
    del v25
    return v26

if __name__ == '__main__': sys.exit(main())
