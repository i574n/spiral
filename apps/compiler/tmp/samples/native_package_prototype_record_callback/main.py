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
def closure0(env_v0 : i32):
    def inner(v1 : i32, v2 : i32) -> Tuple[i32, i32]:
        nonlocal env_v0
        v0 = env_v0
        v3 = spiral_wrap(v1 - 8, 32, True)
        v4 = spiral_wrap(v3 + v0, 32, True)
        del v0, v3
        v5 = spiral_wrap(v2 - 18, 32, True)
        return v4, v5
    return inner
def method0(v0 : Callable[[i32, i32], Tuple[i32, i32]]) -> Tuple[i32, i32]:
    return v0(10, 20)
def main():
    v0 = 1
    v1 = closure0(v0)
    v2, v3 = method0(v1)
    v4 = spiral_wrap(10 + v2, 32, True)
    v5 = spiral_wrap(20 + v3, 32, True)
    v6 = spiral_wrap(v4 + v5, 32, True)
    v7 = spiral_wrap(v6 + 7, 32, True)
    return v7

if __name__ == '__main__': sys.exit(main())
