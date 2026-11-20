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
def main():
    v0 = 100
    v1 = spiral_wrap(v0 + v0, 8, True)
    v2 = 200
    v3 = 100
    v4 = spiral_wrap(v2 + v3, 8, False)
    v5 = -8
    v6 = v5 >> 1
    v7 = v2 >> 1
    v8 = 20000
    v9 = spiral_wrap(v8 + v8, 16, True)
    v10 = 40000
    v11 = spiral_wrap(v10 + v10, 16, False)
    v12 = 7
    v13 = spiral_wrap(int(v12), 8, True)
    v14 = 9
    v15 = spiral_wrap(int(v14), 32, True)
    v16 = v1 == -56
    if v16:
        v17 = v4 == 44
        v18 = v17
    else:
        v18 = False
    if v18:
        v19 = v6 == -4
        v20 = v19
    else:
        v20 = False
    if v20:
        v21 = v7 == 100
        v22 = v21
    else:
        v22 = False
    if v22:
        v23 = v9 == -25536
        v24 = v23
    else:
        v24 = False
    if v24:
        v25 = v11 == 14464
        v26 = v25
    else:
        v26 = False
    if v26:
        v27 = v13 == 7
        v28 = v27
    else:
        v28 = False
    if v28:
        v29 = v15 == 9
        v30 = v29
    else:
        v30 = False
    if v30:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
