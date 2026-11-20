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
def method2(v0 : i32, v1 : i32, v2 : i32, v3 : i32) -> Tuple[i32, i32, i32]:
    while True:
        v4 = spiral_wrap(v0 - 1, 32, True)
        v5 = spiral_wrap(v1 + 1, 32, True)
        v6 = spiral_wrap(v2 + 2, 32, True)
        v7 = spiral_wrap(v3 + 3, 32, True)
        v8 = v4 == 0
        if v8:
            return v5, v6, v7
        else:
            v0, v1, v2, v3 = v4, v5, v6, v7
            continue
def method1(v0 : i32) -> Tuple[i32, i32, i32]:
    v1 = 0
    v2 = 0
    v3 = 0
    v4 = v0 == 0
    if v4:
        return v1, v2, v3
    else:
        return method2(v0, v1, v2, v3)
def method0(v0 : i32) -> i32:
    v1, v2, v3 = method1(v0)
    v4 = v1 == 3
    if v4:
        v5 = v2 == 6
        v6 = v5
    else:
        v6 = False
    if v6:
        v7 = v3 == 9
        v8 = v7
    else:
        v8 = False
    if v8:
        return 0
    else:
        return 1
def main():
    v0 = 3
    return method0(v0)

if __name__ == '__main__': sys.exit(main())
