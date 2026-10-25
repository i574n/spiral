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
    v0 = 2.0
    v1 = 3.0
    v2 = 2.0
    v3 = 3.0
    v4 = 3.1415927
    v5 = 3.141592653589793
    v6 = pow(v0,v1)
    v7 = v6 == 8.0
    if v7:
        v8 = pow(v2,v3)
        v9 = v8 == 8.0
        v10 = v9
    else:
        v10 = False
    if v10:
        v11 = v4 > 3.0
        v12 = v11
    else:
        v12 = False
    if v12:
        v13 = v4 < 4.0
        v14 = v13
    else:
        v14 = False
    if v14:
        v15 = v5 > 3.0
        v16 = v15
    else:
        v16 = False
    if v16:
        v17 = v5 < 4.0
        v18 = v17
    else:
        v18 = False
    if v18:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
