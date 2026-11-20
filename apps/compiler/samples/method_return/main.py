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
def g_c0(env_v0 : i32):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        v2 = v0 == 0
        if v2:
            del v0, v2
            return 0
        else:
            del v2
            v3 = spiral_wrap(v1 + v0, 32, True)
            del v0
            return v3
    return inner
def method0(v0 : i32) -> Callable[[i32], i32]:
    return g_c0(v0)
def main():
    v0 = 7
    v1 = method0(v0)
    v2 = v1(0)
    v3 = v2 == 7
    if v3:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
