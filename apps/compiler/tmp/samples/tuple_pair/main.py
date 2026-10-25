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
def method0(v0 : i32, v1 : i32) -> Tuple[i32, i32]:
    return v0, v1
def method1(v0 : i32, v1 : i32) -> i32:
    v2 = spiral_wrap(v0 + v1, 32, True)
    return v2
def main():
    v0 = 20
    v1 = 22
    v2, v3 = method0(v0, v1)
    v4 = method1(v2, v3)
    v5 = spiral_wrap(v4 - 42, 32, True)
    return v5

if __name__ == '__main__': sys.exit(main())
