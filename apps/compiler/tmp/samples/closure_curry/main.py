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
def closure1(env_v0 : i32):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        v2 = spiral_wrap(v0 * 10, 32, True)
        del v0
        v3 = spiral_wrap(v2 + v1, 32, True)
        del v2
        return v3
    return inner
def f_c0():
    def inner(v0 : i32) -> Callable[[i32], i32]:
        return closure1(v0)
    return inner
def main():
    v0 = f_c0()
    v1 = v0(3)
    v2 = v1(4)
    v3 = v2 == 34
    if v3:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
