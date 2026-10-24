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
def right_c1(env_v0 : i32, env_v1 : i32):
    def inner(v2 : i32) -> i32:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v1 == 0
        del v1
        if v3:
            del v0, v3
            return 0
        else:
            del v3
            v4 = spiral_wrap(v2 + v0, 32, True)
            del v0
            return v4
    return inner
def left_c2(env_v0 : i32, env_v1 : i32):
    def inner(v2 : i32) -> i32:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v1 == 0
        del v1
        if v3:
            del v0, v3
            return 0
        else:
            del v3
            v4 = spiral_wrap(v2 + v0, 32, True)
            del v0
            return v4
    return inner
def f_c0(env_v0 : i32, env_v1 : i32):
    def inner(v2 : i32) -> Tuple[Callable[[i32], i32], Callable[[i32], i32]]:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 == 0
        if v3:
            del v3
            v4 = right_c1(v1, v2)
            del v1
            v5 = left_c2(v0, v2)
            del v0
            return v4, v5
        else:
            del v3
            v6 = left_c2(v0, v2)
            del v0
            v7 = right_c1(v1, v2)
            del v1
            return v6, v7
    return inner
def main():
    v0 = 3
    v1 = 4
    v2 = f_c0(v0, v1)
    v3, v4 = v2(1)
    v5 = v3(0)
    v6 = v4(0)
    v7 = spiral_wrap(v5 + v6, 32, True)
    v8 = v7 == 7
    if v8:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
