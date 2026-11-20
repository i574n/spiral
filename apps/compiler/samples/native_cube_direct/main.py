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
def method2() -> i32:
    return 14
def method1() -> i32:
    v0 = method2()
    v1 = spiral_wrap(14 + v0, 32, True)
    return v1
def method0() -> i32:
    v0 = method1()
    v1 = spiral_wrap(14 + v0, 32, True)
    return v1
def main():
    return method0()

if __name__ == '__main__': sys.exit(main())
