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
class Heap0(NamedTuple):
    v0 : i32
def f_c0(env_v0 : i32, env_v1 : Heap0):
    def inner(v2 : i32) -> Tuple[Heap0, i32]:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 == 0
        if v3:
            del v0, v3
            return v1, 0
        else:
            del v3
            return v1, v0
    return inner
def main():
    v0 = 3
    v1 = 4
    v2 = Heap0(v0)
    v3 = f_c0(v1, v2)
    v4, v5 = v3(1)
    v6 = v4.v0
    v7 = spiral_wrap(v6 + v5, 32, True)
    v8 = v7 == 7
    if v8:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
