kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def spiral_div_trunc(a, b):
    q = abs(a) // abs(b)
    return q if (a < 0) == (b < 0) else -q
def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
def main():
    v0 = 7
    v1 = -2
    v2 = -7
    v3 = 100
    v4 = 7
    v5 = spiral_wrap(spiral_div_trunc(v0, v1), 32, True)
    v6 = spiral_mod_trunc(v0, v1)
    v7 = spiral_wrap(spiral_div_trunc(v2, v1), 32, True)
    v8 = spiral_mod_trunc(v2, v1)
    v9 = spiral_wrap(spiral_div_trunc(v3, v4), 32, False)
    v10 = spiral_mod_trunc(v3, v4)
    v11 = v5 == -3
    if v11:
        v12 = v6 == 1
        v13 = v12
    else:
        v13 = False
    if v13:
        v14 = v7 == 3
        v15 = v14
    else:
        v15 = False
    if v15:
        v16 = v8 == -1
        v17 = v16
    else:
        v17 = False
    if v17:
        v18 = v9 == 14
        v19 = v18
    else:
        v19 = False
    if v19:
        v20 = v10 == 2
        v21 = v20
    else:
        v21 = False
    if v21:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
