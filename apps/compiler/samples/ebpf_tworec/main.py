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
def method1(v0 : i32, v1 : i32) -> i32:
    while True:
        v2 = spiral_wrap(v0 - 1, 32, True)
        v3 = spiral_wrap(v1 + 3, 32, True)
        v4 = v2 == 0
        if v4:
            return v3
        else:
            v0, v1 = v2, v3
            continue
def method0(v0 : i32) -> i32:
    v1 = 0
    v2 = v0 == 0
    if v2:
        return v1
    else:
        return method1(v0, v1)
def method3(v0 : i32, v1 : i32) -> i32:
    while True:
        v2 = spiral_wrap(v0 - 1, 32, True)
        v3 = spiral_wrap(v1 - 2, 32, True)
        v4 = v2 == 0
        if v4:
            return v3
        else:
            v0, v1 = v2, v3
            continue
def method2(v0 : i32) -> i32:
    v1 = 0
    v2 = v0 == 0
    if v2:
        return v1
    else:
        return method3(v0, v1)
def main():
    v0 = 4
    v1 = method0(v0)
    v2 = method2(v0)
    v3 = v1 == 12
    if v3:
        v4 = v2 == -8
        v5 = v4
    else:
        v5 = False
    if v5:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
