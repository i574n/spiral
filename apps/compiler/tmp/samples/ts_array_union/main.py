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
class US0_0(NamedTuple): # Empty
    tag = 0
class US0_1(NamedTuple): # Values
    v0 : cp.ndarray
    tag = 1
US0 = Union[US0_0, US0_1]
def method0(v0 : US0) -> i32:
    match v0:
        case US0_0(): # Empty
            del v0
            return 0
        case US0_1(v1): # Values
            del v0
            v2 = v1.size
            v3 = spiral_array_index(v1, 0)
            v4 = v2 + v3
            del v2, v3
            v5 = spiral_array_index(v1, 1)
            del v1
            v6 = v4 + v5
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 2
    v1 = cp.empty(v0,dtype=cp.int32)
    del v0
    v1[0] = 4
    v1[1] = 5
    v2 = US0_1(v1)
    del v1
    v3 = method0(v2)
    del v2
    v4 = v3 - 11
    del v3
    return v4

if __name__ == '__main__': result = main(); None if result is None else print(result)
