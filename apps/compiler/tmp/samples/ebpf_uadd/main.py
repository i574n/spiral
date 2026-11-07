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
def main():
    v0 = 2147483647
    v1 = 2
    v2 = 1
    v3 = spiral_wrap(v0 + v1, 32, False)
    v4 = spiral_wrap(v0 + v2, 32, False)
    v5 = v3 == 2147483649
    if v5:
        v6 = v4 == 2147483648
        v7 = v6
    else:
        v7 = False
    if v7:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
