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
    v0 = "a"
    v1 = "b"
    v2 = "é"
    v3 = "éx"
    v4 = ""
    v5 = v0 < v0
    if v5:
        return 1
    else:
        v6 = v0 < v1
        if v6:
            v7 = v1 < v2
            v8 = v7
        else:
            v8 = False
        if v8:
            v9 = v2 < v3
            v10 = v9
        else:
            v10 = False
        if v10:
            v11 = v4 < v0
            v12 = v11
        else:
            v12 = False
        if v12:
            v13 = v0 <= v0
            v14 = v13
        else:
            v14 = False
        if v14:
            v15 = v0 >= v0
            v16 = v15
        else:
            v16 = False
        if v16:
            v17 = v3 > v2
            v18 = v17
        else:
            v18 = False
        if v18:
            v19 = v1 >= v0
            v20 = v19
        else:
            v20 = False
        if v20:
            return 0
        else:
            return 1

if __name__ == '__main__': sys.exit(main())
