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
    v0 = 144.0
    v1 = 81.0
    v2 = math.sqrt(v0)
    v3 = math.sqrt(v1)
    v4 = v2 == 12.0
    if v4:
        v5 = v3 == 9.0
        v6 = v5
    else:
        v6 = False
    if v6:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
