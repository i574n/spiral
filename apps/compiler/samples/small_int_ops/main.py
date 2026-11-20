kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
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
    v6 = spiral_mod_trunc(v3, v1)
    v7 = spiral_wrap(-v1, 8, True)
    v8 = spiral_wrap(v0 << 1, 8, True)
    v9 = 200
    v10 = 3
    v11 = spiral_wrap(spiral_div_trunc(v9, v10), 8, False)
    v12 = spiral_mod_trunc(v9, v10)
    v13 = 15
    v14 = v9 & v13
    v15 = v9 | v13
    v16 = v9 ^ v13
    v17 = spiral_wrap(~v13, 8, False)
    v18 = 20000
    v19 = 7
    v20 = spiral_wrap(spiral_div_trunc(v18, v19), 16, True)
    v21 = spiral_mod_trunc(v18, v19)
    v22 = spiral_wrap(-v18, 16, True)
    v23 = 40000
    v24 = spiral_wrap(v23 << 1, 16, False)
    v25 = v2 == 44
    if v25:
        v26 = v5 == -4
        v27 = v26
    else:
        v27 = False
    if v27:
        v28 = v6 == -2
        v29 = v28
    else:
        v29 = False
    if v29:
        v30 = v7 == -3
        v31 = v30
    else:
        v31 = False
    if v31:
        v32 = v8 == -56
        v33 = v32
    else:
        v33 = False
    if v33:
        v34 = v11 == 66
        v35 = v34
    else:
        v35 = False
    if v35:
        v36 = v12 == 2
        v37 = v36
    else:
        v37 = False
    if v37:
        v38 = v14 == 8
        v39 = v38
    else:
        v39 = False
    if v39:
        v40 = v15 == 207
        v41 = v40
    else:
        v41 = False
    if v41:
        v42 = v16 == 199
        v43 = v42
    else:
        v43 = False
    if v43:
        v44 = v17 == 240
        v45 = v44
    else:
        v45 = False
    if v45:
        v46 = v20 == 2857
        v47 = v46
    else:
        v47 = False
    if v47:
        v48 = v21 == 1
        v49 = v48
    else:
        v49 = False
    if v49:
        v50 = v22 == -20000
        v51 = v50
    else:
        v51 = False
    if v51:
        v52 = v24 == 14464
        v53 = v52
    else:
        v53 = False
    if v53:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
