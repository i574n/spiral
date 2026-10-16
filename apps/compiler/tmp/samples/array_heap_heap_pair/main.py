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
class Heap0(NamedTuple):
    v0 : i32
    v1 : string
class Heap1(NamedTuple):
    v0 : Heap0
    v1 : Heap0
class Heap2(NamedTuple):
    v0 : Heap1
    v1 : i32
def main():
    v0 = 7
    v1 = "hi"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 4
    v4 = "yo"
    v5 = Heap0(v3, v4)
    del v3, v4
    v6 = Heap1(v2, v5)
    del v2, v5
    v7 = 2
    v8 = Heap2(v6, v7)
    del v6, v7
    v9 = __import__('numpy').empty(1,dtype=object)
    v9[0] = v8
    del v8
    v10 = spiral_array_index(v9, 0)
    del v9
    v11, v12 = v10.v0, v10.v1
    del v10
    v13, v14 = v11.v0, v11.v1
    del v11
    v15, v16 = v13.v0, v13.v1
    del v13
    v17, v18 = v14.v0, v14.v1
    del v14
    v19 = v15 == 7
    del v15
    if v19:
        v20 = v16 == "hi"
        v21 = v20
    else:
        v21 = False
    del v16, v19
    if v21:
        v22 = v17 == 4
        v23 = v22
    else:
        v23 = False
    del v17, v21
    if v23:
        v24 = v18 == "yo"
        v25 = v24
    else:
        v25 = False
    del v18, v23
    if v25:
        v26 = v12 == 2
        v27 = v26
    else:
        v27 = False
    del v12, v25
    if v27:
        del v27
        return 0
    else:
        del v27
        return 1

if __name__ == '__main__': sys.exit(main())
