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
def method1(v0 : i32, v1 : i32) -> Tuple[i32, i32]:
    return v0, v1
def method0(v0 : i32, v1 : i32) -> i32:
    v2, v3 = method1(v0, v1)
    v4 = spiral_wrap(v2 + v3, 32, True)
    return v4
def method3(v0 : i32, v1 : i32, v2 : i32) -> Tuple[i32, i32, i32]:
    return v0, v1, v2
def method2(v0 : i32, v1 : i32, v2 : i32) -> i32:
    v3, v4, v5 = method3(v0, v1, v2)
    v6 = spiral_wrap(v3 + v4, 32, True)
    v7 = spiral_wrap(v6 + v5, 32, True)
    return v7
def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = method0(v0, v1)
    v4 = method2(v0, v1, v2)
    v5 = spiral_wrap(v3 + v4, 32, True)
    v6 = spiral_wrap(v5 - 9, 32, True)
    return v6

if __name__ == '__main__': sys.exit(main())
