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
def sum_0(v0 : i32) -> i32:
    v1 = v0 < 1
    if v1:
        return 0
    else:
        v2 = spiral_wrap(v0 - 1, 32, True)
        v3 = sum_0(v2)
        v4 = spiral_wrap(v0 + v3, 32, True)
        return v4
def main():
    v0 = 4
    v1 = sum_0(v0)
    v2 = v1 == 10
    if v2:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
