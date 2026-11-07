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
def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
def method0(v0 : u32) -> bool:
    v1 = spiral_wrap(v0 + 5, 32, False)
    v2 = spiral_mod_trunc(v1, 4)
    v3 = v2 == 0
    return v3
def main():
    v0 = 7
    v1 = method0(v0)
    if v1:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
