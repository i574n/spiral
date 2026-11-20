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

def spiral_object_array(*items):
    import numpy
    array = numpy.empty(len(items), dtype=object)
    for i, x in enumerate(items): array[i] = x
    return array
def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
class US0_First(NamedTuple): # First
    tag = 1
US0_First_shared = US0_First()
class US0_Second(NamedTuple): # Second
    tag = 2
US0_Second_shared = US0_Second()
US0 = Union[US0_First, US0_Second]
class US1_Third(NamedTuple): # Third
    tag = 0
US1_Third_shared = US1_Third()
US1 = US1_Third
def main():
    v0 = US0_First_shared
    v1 = US0_Second_shared
    v2 = US1_Third_shared
    del v2
    v3 = ""
    v4 = "First"
    v5 = "Second"
    v6 = spiral_object_array((v3), (v4), (v5))
    v7 = v0.tag
    del v0
    v8 = spiral_array_index(v6, v7)
    del v6, v7
    v9 = v8 == "First"
    del v8
    if v9:
        v10 = spiral_object_array((v3), (v4), (v5))
        v11 = v1.tag
        v12 = spiral_array_index(v10, v11)
        del v10, v11
        v13 = v12 == "Second"
        del v12
        v14 = v13
    else:
        v14 = False
    del v1, v3, v4, v5, v9
    if v14:
        del v14
        return 42
    else:
        del v14
        return 1

if __name__ == '__main__': sys.exit(main())
