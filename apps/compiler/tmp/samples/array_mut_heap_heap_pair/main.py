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
@dataclass
class Mut0:
    v0 : Heap2
def main():
    v0 = 1
    v1 = "no"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 2
    v4 = "zz"
    v5 = Heap0(v3, v4)
    del v3, v4
    v6 = Heap1(v2, v5)
    del v2, v5
    v7 = 3
    v8 = Heap2(v6, v7)
    del v6, v7
    v9 = Mut0(v8)
    del v8
    v10 = __import__('numpy').empty(1,dtype=object)
    v10[0] = v9
    del v9
    v11 = 7
    v12 = "hi"
    v13 = Heap0(v11, v12)
    del v11, v12
    v14 = 4
    v15 = "yo"
    v16 = Heap0(v14, v15)
    del v14, v15
    v17 = Heap1(v13, v16)
    del v13, v16
    v18 = 2
    v19 = Heap2(v17, v18)
    del v17, v18
    v20 = spiral_array_index(v10, 0)
    del v10
    v20.v0 = v19
    del v19
    v21 = v20.v0
    del v20
    v22, v23 = v21.v0, v21.v1
    del v21
    v24, v25 = v22.v0, v22.v1
    del v22
    v26, v27 = v24.v0, v24.v1
    del v24
    v28, v29 = v25.v0, v25.v1
    del v25
    v30 = v26 == 7
    del v26
    if v30:
        v31 = v27 == "hi"
        v32 = v31
    else:
        v32 = False
    del v27, v30
    if v32:
        v33 = v28 == 4
        v34 = v33
    else:
        v34 = False
    del v28, v32
    if v34:
        v35 = v29 == "yo"
        v36 = v35
    else:
        v36 = False
    del v29, v34
    if v36:
        v37 = v23 == 2
        v38 = v37
    else:
        v38 = False
    del v23, v36
    if v38:
        del v38
        return 0
    else:
        del v38
        return 1

if __name__ == '__main__': sys.exit(main())
