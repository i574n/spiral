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
def spiral_div_trunc(a, b):
    q = abs(a) // abs(b)
    return q if (a < 0) == (b < 0) else -q
def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
def main():
    v0 = 7
    v1 = 2
    v2 = 4294967295
    v3 = spiral_wrap(-v0, 32, True)
    v4 = -3
    v5 = -12
    v6 = -4
    v7 = -1
    v8 = spiral_wrap(spiral_div_trunc(v3, v1), 32, True)
    v9 = v8 == v4
    if v9:
        v10 = spiral_mod_trunc(v3, v1)
        v11 = v10 == v7
        if v11:
            v12 = v3 >> 1
            v13 = v12 == v6
            if v13:
                v14 = spiral_wrap(v4 << 2, 32, True)
                v15 = v14 == v5
                if v15:
                    v16 = spiral_wrap(v2 + 1, 32, False)
                    v17 = v16 == 0
                    if v17:
                        v18 = spiral_wrap(v2 * v2, 32, False)
                        v19 = v18 == 1
                        if v19:
                            v20 = v2 >> 28
                            v21 = v20 == 15
                            if v21:
                                return 0
                            else:
                                return 7
                        else:
                            return 6
                    else:
                        return 5
                else:
                    return 4
            else:
                return 3
        else:
            return 2
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
