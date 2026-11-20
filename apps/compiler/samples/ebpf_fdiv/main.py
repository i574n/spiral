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
    v0 = 1.5
    v1 = -2.0
    v2 = -0.5
    v3 = v0 / v1
    v4 = v2 / v1
    v5 = v3 == -0.75
    if v5:
        v6 = v4 == 0.25
        v7 = v6
    else:
        v7 = False
    if v7:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
