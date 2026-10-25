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
    v0 = 4294967295
    v1 = 15
    v2 = v0 & v1
    v3 = v0 | v1
    v4 = v0 ^ v1
    v5 = spiral_wrap(~v1, 32, False)
    v6 = v2 == 15
    if v6:
        v7 = v3 == v0
        v8 = v7
    else:
        v8 = False
    if v8:
        v9 = v4 == v5
        v10 = v9
    else:
        v10 = False
    if v10:
        v11 = v5 == 4294967280
        v12 = v11
    else:
        v12 = False
    if v12:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
