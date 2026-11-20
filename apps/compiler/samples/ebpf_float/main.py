kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def main():
    v0 = -1.5
    v1 = 2.0
    v2 = v0 / v1
    v3 = -0.75
    v4 = v0 * v1
    v5 = v4 + 0.5
    v6 = -2.5
    v7 = v2 == v3
    if v7:
        v8 = v5 == v6
        if v8:
            return 0
        else:
            return 2
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
