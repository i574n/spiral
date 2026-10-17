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

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def spiral_div_trunc(a, b):
    q = abs(a) // abs(b)
    return q if (a < 0) == (b < 0) else -q
def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
def main():
    v0 = 100
    v1 = 3
    v2 = spiral_wrap(v0 * v1, 8, True)
    v3 = -8
    v4 = 2
    v5 = spiral_wrap(spiral_div_trunc(v3, v4), 8, True)
    del v4
    v6 = spiral_mod_trunc(v3, v1)
    del v3
    v7 = spiral_wrap(-v1, 8, True)
    del v1
    v8 = spiral_wrap(v0 << 1, 8, True)
    del v0
    v9 = 200
    v10 = 3
    v11 = spiral_wrap(spiral_div_trunc(v9, v10), 8, False)
    v12 = spiral_mod_trunc(v9, v10)
    del v10
    v13 = 15
    v14 = v9 & v13
    v15 = v9 | v13
    v16 = v9 ^ v13
    del v9
    v17 = spiral_wrap(~v13, 8, False)
    del v13
    v18 = 20000
    v19 = 7
    v20 = spiral_wrap(spiral_div_trunc(v18, v19), 16, True)
    v21 = spiral_mod_trunc(v18, v19)
    del v19
    v22 = spiral_wrap(-v18, 16, True)
    del v18
    v23 = 40000
    v24 = spiral_wrap(v23 << 1, 16, False)
    del v23
    v25 = v2 == 44
    del v2
    if v25:
        v26 = v5 == -4
        v27 = v26
    else:
        v27 = False
    del v5, v25
    if v27:
        v28 = v6 == -2
        v29 = v28
    else:
        v29 = False
    del v6, v27
    if v29:
        v30 = v7 == -3
        v31 = v30
    else:
        v31 = False
    del v7, v29
    if v31:
        v32 = v8 == -56
        v33 = v32
    else:
        v33 = False
    del v8, v31
    if v33:
        v34 = v11 == 66
        v35 = v34
    else:
        v35 = False
    del v11, v33
    if v35:
        v36 = v12 == 2
        v37 = v36
    else:
        v37 = False
    del v12, v35
    if v37:
        v38 = v14 == 8
        v39 = v38
    else:
        v39 = False
    del v14, v37
    if v39:
        v40 = v15 == 207
        v41 = v40
    else:
        v41 = False
    del v15, v39
    if v41:
        v42 = v16 == 199
        v43 = v42
    else:
        v43 = False
    del v16, v41
    if v43:
        v44 = v17 == 240
        v45 = v44
    else:
        v45 = False
    del v17, v43
    if v45:
        v46 = v20 == 2857
        v47 = v46
    else:
        v47 = False
    del v20, v45
    if v47:
        v48 = v21 == 1
        v49 = v48
    else:
        v49 = False
    del v21, v47
    if v49:
        v50 = v22 == -20000
        v51 = v50
    else:
        v51 = False
    del v22, v49
    if v51:
        v52 = v24 == 14464
        v53 = v52
    else:
        v53 = False
    del v24, v51
    if v53:
        del v53
        return 0
    else:
        del v53
        return 1

if __name__ == '__main__': sys.exit(main())
