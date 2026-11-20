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
def method1(v0 : i32, v1 : bool) -> bool:
    while True:
        v2 = spiral_wrap(v0 - 1, 32, True)
        if v1:
            v3 = v0 > 0
            v4 = v3
        else:
            v4 = False
        v5 = v2 == 0
        if v5:
            return v4
        else:
            v0, v1 = v2, v4
            continue
def method0(v0 : i32) -> bool:
    v1 = True
    v2 = v0 == 0
    if v2:
        return v1
    else:
        return method1(v0, v1)
def method2(v0 : i32) -> bool:
    v1 = False
    v2 = v0 == 0
    if v2:
        return v1
    else:
        return method1(v0, v1)
def main():
    v0 = 3
    v1 = method0(v0)
    v2 = method2(v0)
    if v1:
        if v2:
            return 1
        else:
            return 0
    else:
        return 2

if __name__ == '__main__': sys.exit(main())
