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
def method0(v0 : i32) -> bool:
    v1 = v0 < 10
    return v1
def main():
    v0 = 0
    v1 = 0
    while method0(v0):
        v3 = spiral_wrap(v1 + v0, 32, True)
        v1 = v3
        v4 = spiral_wrap(v0 + 1, 32, True)
        v0 = v4
    v5 = spiral_wrap(v1 - 45, 32, True)
    return v5

if __name__ == '__main__': sys.exit(main())
