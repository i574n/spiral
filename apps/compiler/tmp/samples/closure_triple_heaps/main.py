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
class Heap0(NamedTuple):
    v0 : i32
    v1 : string
def f_c0(env_v0 : Heap0, env_v1 : Heap0, env_v2 : Heap0):
    def inner(v3 : i32) -> Tuple[Heap0, Heap0, Heap0]:
        nonlocal env_v0, env_v1, env_v2
        v0 = env_v0; v1 = env_v1; v2 = env_v2
        return v0, v1, v2
    return inner
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
    v9 = f_c0(v2, v5, v8)
    del v2, v5, v8
    v10, v11, v12 = v9(1)
    del v9
    v13, v14 = v10.v0, v10.v1
    del v10
    v15, v16 = v11.v0, v11.v1
    del v11
    v17, v18 = v12.v0, v12.v1
    del v12
    v19 = v13 == 7
    del v13
    if v19:
        v20 = v14 == "hi"
        v21 = v20
    else:
        v21 = False
    del v14, v19
    if v21:
        v22 = v15 == 4
        v23 = v22
    else:
        v23 = False
    del v15, v21
    if v23:
        v24 = v16 == "yo"
        v25 = v24
    else:
        v25 = False
    del v16, v23
    if v25:
        v26 = v17 == 9
        v27 = v26
    else:
        v27 = False
    del v17, v25
    if v27:
        v28 = v18 == "ok"
        v29 = v28
    else:
        v29 = False
    del v18, v27
    if v29:
        del v29
        return 0
    else:
        del v29
        return 1

if __name__ == '__main__': sys.exit(main())
