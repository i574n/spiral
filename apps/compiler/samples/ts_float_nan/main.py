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
    v0 = float('nan')
    v1 = float('nan')
    v2 = 1.0
    v3 = 1.0
    v4 = math.isnan(v0)
    if v4:
        v5 = math.isnan(v1)
        v6 = v5
    else:
        v6 = False
    if v6:
        v7 = math.isnan(v2)
        if v7:
            v9 = True
        else:
            v8 = math.isnan(v3)
            v9 = v8
        if v9:
            return 2
        else:
            return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
