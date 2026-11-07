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
    v0 = 1
    v1 = 0
    v2 = 31
    v3 = spiral_wrap(v0 << v2, 32, False)
    v4 = v3 >> v2
    v5 = spiral_wrap(v0 << v1, 32, False)
    v6 = v3 == 2147483648
    if v6:
        v7 = v4 == 1
        v8 = v7
    else:
        v8 = False
    if v8:
        v9 = v5 == 1
        v10 = v9
    else:
        v10 = False
    if v10:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
