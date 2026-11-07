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
    v0 = 3
    v1 = 4
    v2 = 1
    v3 = 1
    v4 = 1.5
    v5 = -v4
    v6 = v0 != v1
    if v6:
        v7 = v2 != v3
        if v7:
            return 2
        else:
            v8 = v5 == -1.5
            if v8:
                return 0
            else:
                return 3
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
