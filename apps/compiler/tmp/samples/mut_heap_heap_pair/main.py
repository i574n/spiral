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
    v10 = 7
    v11 = "hi"
    v12 = Heap0(v10, v11)
    del v10, v11
    v13 = 4
    v14 = "yo"
    v15 = Heap0(v13, v14)
    del v13, v14
    v16 = Heap1(v12, v15)
    del v12, v15
    v17 = 2
    v18 = Heap2(v16, v17)
    del v16, v17
    v9.v0 = v18
    del v18
    v19 = v9.v0
    del v9
    v20, v21 = v19.v0, v19.v1
    del v19
    v22, v23 = v20.v0, v20.v1
    del v20
    v24, v25 = v22.v0, v22.v1
    del v22
    v26, v27 = v23.v0, v23.v1
    del v23
    v28 = v24 == 7
    del v24
    if v28:
        v29 = v25 == "hi"
        v30 = v29
    else:
        v30 = False
    del v25, v28
    if v30:
        v31 = v26 == 4
        v32 = v31
    else:
        v32 = False
    del v26, v30
    if v32:
        v33 = v27 == "yo"
        v34 = v33
    else:
        v34 = False
    del v27, v32
    if v34:
        v35 = v21 == 2
        v36 = v35
    else:
        v36 = False
    del v21, v34
    if v36:
        del v36
        return 0
    else:
        del v36
        return 1

if __name__ == '__main__': sys.exit(main())
