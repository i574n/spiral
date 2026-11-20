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
    v0 = -3
    v1 = -4
    v2 = -3
    v3 = 4294967295
    v4 = 0
    v5 = 4294967295
    v6 = -1.5
    v7 = -0.5
    v8 = -1.5
    v9 = v0 != v1
    v10 = v0 != v2
    v11 = v3 != v4
    v12 = v3 != v5
    v13 = v6 != v7
    v14 = v6 != v8
    v15 = v9 and v11
    v16 = v15 and v13
    if v16:
        if v10:
            return 1
        else:
            if v12:
                return 2
            else:
                if v14:
                    return 3
                else:
                    return 0
    else:
        return 4

if __name__ == '__main__': sys.exit(main())
