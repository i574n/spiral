kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

import math
def main():
    v0 = float('inf')
    v1 = float('inf')
    v2 = -v0
    v3 = -v1
    v4 = 1.0
    v5 = 1.0
    v6 = math.isnan(v4)
    if v6:
        v8 = True
    else:
        v7 = math.isnan(v5)
        v8 = v7
    if v8:
        return 3
    else:
        v9 = v0 > v4
        if v9:
            v10 = v1 > v5
            v11 = v10
        else:
            v11 = False
        if v11:
            v12 = v2 < 0.0
            if v12:
                v13 = v3 < 0.0
                v14 = v13
            else:
                v14 = False
            if v14:
                return 0
            else:
                return 2
        else:
            return 1

if __name__ == '__main__': sys.exit(main())
