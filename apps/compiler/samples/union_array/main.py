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
class US0_Missing(NamedTuple): # Missing
    tag = 0
US0_Missing_shared = US0_Missing()
class US0_Held(NamedTuple): # Held
    v0 : cp.ndarray
    tag = 1
US0 = Union[US0_Missing, US0_Held]
def main():
    v0 = 2
    v1 = cp.zeros(v0,dtype=cp.int32)
    del v0
    v2 = 7
    v1[0] = v2
    del v2
    v3 = True
    if v3:
        v6 = US0_Held(v1)
    else:
        v6 = US0_Missing_shared
    del v1, v3
    match v6:
        case US0_Held(v7): # Held
            del v6
            v8 = spiral_array_index(v7, 0)
            del v7
            v9 = v8 == 7
            del v8
            if v9:
                del v9
                return 0
            else:
                del v9
                return 1
        case US0_Missing(): # Missing
            del v6
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
