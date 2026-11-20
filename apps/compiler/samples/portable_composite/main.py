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
def spiral_div_trunc(a, b):
    q = abs(a) // abs(b)
    return q if (a < 0) == (b < 0) else -q
def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
def method5(v0 : i32, v1 : i32) -> i32:
    v2 = spiral_wrap(v0 * v1, 32, True)
    v3 = spiral_wrap(v2 + 5, 32, True)
    v4 = spiral_wrap(spiral_div_trunc(v3, 3), 32, True)
    return v4
def method4(v0 : i32) -> i32:
    v1 = 4
    v2 = 4
    v3 = method5(v1, v2)
    v4 = spiral_wrap(v0 + v3, 32, True)
    v5 = spiral_wrap(v4 - 7, 32, True)
    return v5
def method6(v0 : u32) -> bool:
    v1 = spiral_wrap(v0 + 5, 32, False)
    v2 = spiral_mod_trunc(v1, 4)
    v3 = v2 == 0
    return v3
def method3(v0 : i32) -> i32:
    v1 = 7
    v2 = method6(v1)
    if v2:
        return method4(v0)
    else:
        return 1
def method7(v0 : string, v1 : string) -> bool:
    v2 = v0 == v1
    return v2
def method2(v0 : i32) -> i32:
    v1 = "spiral"
    v2 = method7(v1, v1)
    if v2:
        return method3(v0)
    else:
        return 1
def method8(v0 : f32) -> Tuple[bool, f32, i32]:
    v1 = v0 >= 3.5
    return v1, v0, 7
def method9(v0 : bool, v1 : f32, v2 : i32) -> i32:
    if v0:
        v3 = v1 >= 3.5
        if v3:
            v4 = spiral_wrap(v2 - 7, 32, True)
            return v4
        else:
            return 1
    else:
        return 2
def method1(v0 : i32) -> i32:
    v1 = 4.0
    v2, v3, v4 = method8(v1)
    v5 = method9(v2, v3, v4)
    v6 = spiral_wrap(v0 + v5, 32, True)
    return method2(v6)
def method10(v0 : i32) -> Tuple[i32, i32, bool]:
    v1 = spiral_wrap(v0 + 2, 32, True)
    v2 = v0 > 0
    return v0, v1, v2
def method11(v0 : i32, v1 : i32, v2 : bool) -> i32:
    if v2:
        v3 = spiral_wrap(v0 + v1, 32, True)
        v4 = spiral_wrap(v3 - 4, 32, True)
        return v4
    else:
        return 1
def method0(v0 : i32) -> i32:
    v1 = 1
    v2, v3, v4 = method10(v1)
    v5 = method11(v2, v3, v4)
    v6 = spiral_wrap(v0 + v5, 32, True)
    return method1(v6)
def main():
    v0 = 0
    return method0(v0)

if __name__ == '__main__': sys.exit(main())
