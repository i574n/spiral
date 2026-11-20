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
    v0 = 250
    v1 = 10
    v2 = 4294967295
    v3 = 18446744073709551615
    v4 = 127
    v5 = 1
    v6 = 7
    v7 = 2
    v8 = 9223372036854775807
    v9 = spiral_wrap(-v6, 32, True)
    v10 = spiral_wrap(-v8, 64, True)
    v11 = spiral_wrap(v0 + v1, 8, False)
    v12 = v11 == 4
    if v12:
        v13 = spiral_wrap(v2 + 1, 32, False)
        v14 = v13 == 0
        if v14:
            v15 = spiral_wrap(v2 * v2, 32, False)
            v16 = v15 == 1
            if v16:
                v17 = spiral_wrap(v3 + 1, 64, False)
                v18 = v17 == 0
                if v18:
                    v19 = spiral_wrap(v3 * v3, 64, False)
                    v20 = v19 == 1
                    if v20:
                        v21 = spiral_wrap(spiral_div_trunc(v3, 3), 64, False)
                        v22 = v21 == 6148914691236517205
                        if v22:
                            v23 = spiral_wrap(v4 + v5, 8, True)
                            v24 = v23 < 0
                            if v24:
                                v25 = spiral_wrap(spiral_div_trunc(v9, v7), 32, True)
                                v26 = v25 == -3
                                if v26:
                                    v27 = spiral_mod_trunc(v9, v7)
                                    v28 = v27 == -1
                                    if v28:
                                        v29 = spiral_mod_trunc(v10, 10)
                                        v30 = v29 == -7
                                        if v30:
                                            v31 = v2 >> 28
                                            v32 = v31 == 15
                                            if v32:
                                                v33 = v9 >> 1
                                                v34 = v33 == -4
                                                if v34:
                                                    return 0
                                                else:
                                                    return 12
                                            else:
                                                return 11
                                        else:
                                            return 10
                                    else:
                                        return 9
                                else:
                                    return 8
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
