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
def main():
    v0 = 5000000000
    v1 = -4
    v2 = spiral_wrap(spiral_div_trunc(v0, v1), 64, True)
    v3 = 1000000
    v4 = spiral_wrap(v3 * v3, 64, True)
    v5 = -8
    v6 = v5 >> 1
    v7 = 7
    v8 = spiral_wrap(int(v7), 64, True)
    v9 = 9
    v10 = spiral_wrap(int(v9), 32, True)
    v11 = 4294967296
    v12 = spiral_wrap(v11 + 1, 64, False)
    v13 = v11 >> 1
    v14 = spiral_wrap(int(v7), 64, False)
    v15 = v2 == -1250000000
    if v15:
        v16 = v4 == 1000000000000
        v17 = v16
    else:
        v17 = False
    if v17:
        v18 = v6 == -4
        v19 = v18
    else:
        v19 = False
    if v19:
        v20 = v8 == 7
        v21 = v20
    else:
        v21 = False
    if v21:
        v22 = v10 == 9
        v23 = v22
    else:
        v23 = False
    if v23:
        v24 = v12 == 4294967297
        v25 = v24
    else:
        v25 = False
    if v25:
        v26 = v13 == 2147483648
        v27 = v26
    else:
        v27 = False
    if v27:
        v28 = v14 == 7
        v29 = v28
    else:
        v29 = False
    if v29:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
