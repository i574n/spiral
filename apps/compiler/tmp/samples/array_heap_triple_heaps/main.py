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
    v2 : Heap0
def main():
    v0 = 7
    v1 = "hi"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 4
    v4 = "yo"
    v5 = Heap0(v3, v4)
    del v3, v4
    v6 = 9
    v7 = "ok"
    v8 = Heap0(v6, v7)
    del v6, v7
    v9 = Heap1(v2, v5, v8)
    del v2, v5, v8
    v10 = __import__('numpy').empty(1,dtype=object)
    v10[0] = v9
    del v9
    v11 = spiral_array_index(v10, 0)
    del v10
    v12, v13, v14 = v11.v0, v11.v1, v11.v2
    del v11
    v15, v16 = v12.v0, v12.v1
    del v12
    v17, v18 = v13.v0, v13.v1
    del v13
    v19, v20 = v14.v0, v14.v1
    del v14
    v21 = v15 == 7
    del v15
    if v21:
        v22 = v16 == "hi"
        v23 = v22
    else:
        v23 = False
    del v16, v21
    if v23:
        v24 = v17 == 4
        v25 = v24
    else:
        v25 = False
    del v17, v23
    if v25:
        v26 = v18 == "yo"
        v27 = v26
    else:
        v27 = False
    del v18, v25
    if v27:
        v28 = v19 == 9
        v29 = v28
    else:
        v29 = False
    del v19, v27
    if v29:
        v30 = v20 == "ok"
        v31 = v30
    else:
        v31 = False
    del v20, v29
    if v31:
        del v31
        return 0
    else:
        del v31
        return 1

if __name__ == '__main__': sys.exit(main())
