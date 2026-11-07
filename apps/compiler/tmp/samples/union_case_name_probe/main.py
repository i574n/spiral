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
class US0_Circle(NamedTuple): # Circle
    v0 : f64
    tag = 0
class US0_Square(NamedTuple): # Square
    v0 : f64
    tag = 1
class US0_Dot(NamedTuple): # Dot
    tag = 2
US0_Dot_shared = US0_Dot()
US0 = Union[US0_Circle, US0_Square, US0_Dot]
class US1_Hello(NamedTuple): # Hello
    tag = 0
US1_Hello_shared = US1_Hello()
US1 = US1_Hello
class US2_Count(NamedTuple): # Count
    v0 : i32
    tag = 1
US2 = US2_Count
def main():
    v0 = 1.5
    v1 = US0_Circle(v0)
    del v0
    v2 = 2.5
    v3 = US0_Square(v2)
    del v2
    v4 = US0_Dot_shared
    v5 = US1_Hello_shared
    del v5
    v6 = 3
    v7 = US2_Count(v6)
    del v6, v7
    v8 = "Circle"
    v9 = "Square"
    v10 = "Dot"
    v11 = spiral_object_array((v8), (v9), (v10))
    v12 = v1.tag
    del v1
    v13 = spiral_array_index(v11, v12)
    del v11, v12
    v14 = v13 == "Circle"
    del v13
    if v14:
        v15 = spiral_object_array((v8), (v9), (v10))
        v16 = v3.tag
        v17 = spiral_array_index(v15, v16)
        del v15, v16
        v18 = v17 == "Square"
        del v17
        v19 = v18
    else:
        v19 = False
    del v3, v14
    if v19:
        v20 = spiral_object_array((v8), (v9), (v10))
        v21 = v4.tag
        v22 = spiral_array_index(v20, v21)
        del v20, v21
        v23 = v22 == "Dot"
        del v22
        v24 = v23
    else:
        v24 = False
    del v4, v8, v9, v10, v19
    if v24:
        del v24
        return 42
    else:
        del v24
        return 1

if __name__ == '__main__': sys.exit(main())
