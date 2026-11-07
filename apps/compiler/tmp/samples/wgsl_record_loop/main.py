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
def loop_0(v0 : i32, v1 : i32, v2 : i32, v3 : i32) -> Tuple[i32, i32]:
    v4 = v1 >= v0
    if v4:
        v9, v10 = v2, v3
    else:
        v5 = spiral_wrap(v1 + 1, 32, True)
        v6 = spiral_wrap(v2 + 1, 32, True)
        v7, v8 = loop_0(v0, v5, v6, v3)
        v9, v10 = v7, v8
    return v9, v10
def main():
    v0 = 5
    v1 = 0
    v2 = 1
    v3 = 2
    v4, v5 = loop_0(v0, v1, v2, v3)
    v6 = spiral_wrap(v4 + v5, 32, True)
    return v6

if __name__ == '__main__': sys.exit(main())
