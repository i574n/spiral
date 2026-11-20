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
class US0_DeepBlue(NamedTuple): # DeepBlue
    tag = 0
US0_DeepBlue_shared = US0_DeepBlue()
class US0_LightGreen(NamedTuple): # LightGreen
    v0 : f64
    tag = 1
class US0_Red(NamedTuple): # Red
    tag = 2
US0_Red_shared = US0_Red()
US0 = Union[US0_DeepBlue, US0_LightGreen, US0_Red]
def main():
    v0 = 0.5
    v1 = US0_LightGreen(v0)
    del v0
    v2 = US0_DeepBlue_shared
    v3 = US0_Red_shared
    v4 = "deep_blue"
    v5 = "light_green"
    v6 = "red"
    v7 = spiral_object_array((v4), (v5), (v6))
    v8 = v1.tag
    del v1
    v9 = spiral_array_index(v7, v8)
    del v7
    v10 = v9 == "light_green"
    del v9
    if v10:
        v11 = "deep-blue"
        v12 = "light-green"
        v13 = spiral_object_array((v11), (v12), (v6))
        del v11, v12
        v14 = v2.tag
        v15 = spiral_array_index(v13, v14)
        del v13, v14
        v16 = v15 == "deep-blue"
        del v15
        v17 = v16
    else:
        v17 = False
    del v2, v10
    if v17:
        v18 = "deepblue"
        v19 = "lightgreen"
        v20 = spiral_object_array((v18), (v19), (v6))
        del v18, v19
        v21 = spiral_array_index(v20, v8)
        del v20
        v22 = v21 == "lightgreen"
        del v21
        v23 = v22
    else:
        v23 = False
    del v17
    if v23:
        v24 = spiral_object_array((v4), (v5), (v6))
        v25 = v3.tag
        v26 = spiral_array_index(v24, v25)
        del v24, v25
        v27 = v26 == "red"
        del v26
        v28 = v27
    else:
        v28 = False
    del v3, v4, v5, v6, v23
    if v28:
        v29 = "DeepBlue"
        v30 = "LightGreen"
        v31 = "Red"
        v32 = spiral_object_array((v29), (v30), (v31))
        del v29, v30, v31
        v33 = spiral_array_index(v32, v8)
        del v32
        v34 = v33 == "LightGreen"
        del v33
        v35 = v34
    else:
        v35 = False
    del v8, v28
    if v35:
        del v35
        return 42
    else:
        del v35
        return 1

if __name__ == '__main__': sys.exit(main())
