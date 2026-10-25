kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def main():
    v0 = -8
    v1 = 3
    v2 = 1
    v3 = 4294967295
    v4 = 4
    v5 = v0 >> v2
    v6 = spiral_wrap(v1 << v2, 32, True)
    v7 = v3 >> v4
    v8 = spiral_wrap(v3 << v2, 32, False)
    v9 = v5 == -4
    if v9:
        v10 = v6 == 6
        if v10:
            v11 = v7 == 268435455
            if v11:
                v12 = v8 == 4294967294
                if v12:
                    return 0
                else:
                    return 4
            else:
                return 3
        else:
            return 2
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
