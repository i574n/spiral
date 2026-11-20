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
    v0 = -2147483648
    v1 = 4294967295
    v2 = -1
    v3 = 0.0
    v4 = 1.9
    v5 = 2.9
    v6 = 4294967294
    v7 = 5
    v8 = 0
    v9 = v3 - v4
    v10 = spiral_wrap(int(v0), 32, False)
    v11 = spiral_wrap(int(v10), 32, True)
    v12 = spiral_wrap(int(v1), 32, True)
    v13 = spiral_wrap(int(v2), 32, False)
    v14 = spiral_wrap(int(v9), 32, True)
    v15 = spiral_wrap(int(v5), 32, True)
    v16 = spiral_wrap(spiral_div_trunc(v10, 2), 32, False)
    v17 = spiral_wrap(spiral_div_trunc(v6, 2), 32, False)
    v18 = spiral_mod_trunc(v7, 3)
    v19 = spiral_wrap(~v8, 32, False)
    v20 = v1 >> 31
    v21 = v0 < -1
    if v21:
        v22 = v0 <= v0
        v23 = v22
    else:
        v23 = False
    if v23:
        v24 = v0 > 0
        v25 = v24 == False
        v26 = v25
    else:
        v26 = False
    if v26:
        v27 = v10 > 1
        if v27:
            v28 = v11 == v0
            v29 = v28
        else:
            v29 = False
        if v29:
            v30 = v12 == v2
            v31 = v30
        else:
            v31 = False
        if v31:
            v32 = v13 == v1
            v33 = v32
        else:
            v33 = False
        if v33:
            v34 = v14 == v2
            if v34:
                v35 = v15 == 2
                v36 = v35
            else:
                v36 = False
            if v36:
                v37 = v16 == 1073741824
                if v37:
                    v38 = v17 == 2147483647
                    v39 = v38
                else:
                    v39 = False
                if v39:
                    v40 = v18 == 2
                    v41 = v40
                else:
                    v41 = False
                if v41:
                    v42 = v19 == v1
                    if v42:
                        v43 = v20 == 1
                        v44 = v43
                    else:
                        v44 = False
                    if v44:
                        return 0
                    else:
                        return 5
                else:
                    return 4
            else:
                return 3
        else:
            return 2
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
