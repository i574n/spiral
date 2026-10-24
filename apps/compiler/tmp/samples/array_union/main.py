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

def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
class US0_None(NamedTuple): # None
    tag = 0
US0_None_shared = US0_None()
class US0_Some(NamedTuple): # Some
    v0 : i32
    tag = 1
US0 = Union[US0_None, US0_Some]
def main():
    v0 = 2
    v1 = __import__('numpy').empty(v0,dtype=object)
    del v0
    v2 = 7
    v3 = US0_Some(v2)
    del v2
    v1[0] = v3
    del v3
    v4 = US0_None_shared
    v1[1] = v4
    del v4
    v5 = spiral_array_index(v1, 0)
    match v5:
        case US0_None(): # None
            del v1, v5
            return 1
        case US0_Some(v6): # Some
            del v5
            v7 = spiral_array_index(v1, 1)
            del v1
            match v7:
                case US0_None(): # None
                    del v7
                    v8 = v6 == 7
                    del v6
                    if v8:
                        del v8
                        return 0
                    else:
                        del v8
                        return 1
                case US0_Some(_): # Some
                    del v6, v7
                    return 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
