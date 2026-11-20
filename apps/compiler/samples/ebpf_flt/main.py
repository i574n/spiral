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
    v0 = -2.0
    v1 = -1.0
    v2 = 0.0
    v3 = v0 < v1
    if v3:
        v4 = v1 < v2
        v5 = v4
    else:
        v5 = False
    if v5:
        v6 = v0 > v1
        v7 = v6 == False
        v8 = v7
    else:
        v8 = False
    if v8:
        v9 = v0 >= v1
        v10 = v9 == False
        v11 = v10
    else:
        v11 = False
    if v11:
        v12 = v1 <= v2
        v13 = v12
    else:
        v13 = False
    if v13:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
