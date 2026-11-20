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
    v0 = 43
    v1 = 15
    v2 = 2
    v3 = 5
    v4 = v0 & v1
    v5 = v0 | v1
    v6 = v0 ^ v1
    v7 = spiral_wrap(~v0, 32, True)
    v8 = v7 & 255
    v9 = spiral_wrap(1 << v3, 32, True)
    v10 = 168 >> v2
    v11 = spiral_wrap(v4 - 11, 32, True)
    v12 = spiral_wrap(v10 + v11, 32, True)
    v13 = spiral_wrap(v5 - 47, 32, True)
    v14 = spiral_wrap(v12 + v13, 32, True)
    v15 = spiral_wrap(v6 - 36, 32, True)
    v16 = spiral_wrap(v14 + v15, 32, True)
    v17 = spiral_wrap(v8 - 212, 32, True)
    v18 = spiral_wrap(v16 + v17, 32, True)
    v19 = spiral_wrap(v9 - 32, 32, True)
    v20 = spiral_wrap(v18 + v19, 32, True)
    return v20

if __name__ == '__main__': sys.exit(main())
