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
def f_c0(env_v0 : Heap0, env_v1 : Heap0):
    def inner(v2 : i32) -> Tuple[Heap0, Heap0]:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 == 0
        if v3:
            del v3
            return v1, v0
        else:
            del v3
            return v0, v1
    return inner
def main():
    v0 = 3
    v1 = 4
    v2 = Heap0(v0)
    v3 = Heap0(v1)
    v4 = f_c0(v2, v3)
    v5, v6 = v4(1)
    v7 = v5.v0
    v8 = v6.v0
    v9 = spiral_wrap(v7 + v8, 32, True)
    v10 = v9 == 7
    if v10:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
