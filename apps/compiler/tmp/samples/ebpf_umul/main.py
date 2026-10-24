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
    v0 = 65536
    v1 = 65536
    v2 = 4294967295
    v3 = 3
    v4 = spiral_wrap(v0 * v1, 32, False)
    v5 = spiral_wrap(v2 * v3, 32, False)
    v6 = v4 == 0
    if v6:
        v7 = v5 == 4294967293
        v8 = v7
    else:
        v8 = False
    if v8:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
