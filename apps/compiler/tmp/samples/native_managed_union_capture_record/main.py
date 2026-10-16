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
def closure1(env_v0 : US0):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        match v0:
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
        del v0
        v13 = v12 + v1
        del v12
        return v13
    return inner
def closure0():
    def inner(v0 : i32) -> Callable[[i32], i32]:
        v1 = cp.empty(2,dtype=cp.int32)
        v1[0] = v0
        v2 = v0 + 1
        v1[1] = v2
        del v2
        v3 = v0 == 0
        if v3:
            v7 = US0_Empty()
        else:
            v5 = "hi"
            v7 = US0_Item(v5, v1)
        del v1, v3
        return closure1(v7)
    return inner
def method0(v0 : Callable[[i32], Callable[[i32], i32]]) -> Callable[[i32], i32]:
    return v0(0)
def method1(v0 : Callable[[i32], Callable[[i32], i32]]) -> Callable[[i32], i32]:
    return v0(4)
def method4(v0 : Callable[[i32], i32]) -> i32:
    v1 = v0(2)
    del v0
    v2 = v1 + 5
    del v1
    return v2
def method3(v0 : Callable[[i32], i32]) -> i32:
    v1 = v0(1)
    v2 = method4(v0)
    del v0
    v3 = v1 + v2
    del v1, v2
    return v3
def method2(v0 : Callable[[i32], i32], v1 : Callable[[i32], i32]) -> i32:
    v2 = v0(5)
    del v0
    v3 = method3(v1)
    del v1
    v4 = v2 + v3
    del v2, v3
    return v4
def main():
    v0 = closure0()
    v1 = method0(v0)
    v2 = method1(v0)
    del v0
    return method2(v1, v2)

if __name__ == '__main__': sys.exit(main())
