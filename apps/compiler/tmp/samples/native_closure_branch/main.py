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
def a_c0():
    def inner(v0 : i32) -> i32:
        v1 = spiral_wrap(v0 + 2, 32, True)
        return v1
    return inner
def b_c1():
    def inner(v0 : i32) -> i32:
        v1 = spiral_wrap(v0 + 3, 32, True)
        return v1
    return inner
def method0(v0 : Callable[[i32], i32]) -> i32:
    return v0(40)
def main():
    v0 = True
    if v0:
        v3 = a_c0()
    else:
        v3 = b_c1()
    return method0(v3)

if __name__ == '__main__': sys.exit(main())
