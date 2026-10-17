kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
import os
try: # CuPy when a CUDA device answers, otherwise numpy under the same name (SPIRAL_CUDA=0 forces numpy).
    if os.environ.get('SPIRAL_CUDA', '1') == '0': raise ImportError('SPIRAL_CUDA=0')
    import cupy as cp
    if cp.cuda.runtime.getDeviceCount() < 1: raise RuntimeError('no CUDA device')
    cuda = True
except Exception:
    import numpy as cp
    cuda = False
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
    del v0
    v4 = -3
    v5 = -12
    v6 = -4
    v7 = -1
    v8 = spiral_wrap(spiral_div_trunc(v3, v1), 32, True)
    v9 = v8 == v4
    del v8
    if v9:
        del v9
        v10 = spiral_mod_trunc(v3, v1)
        del v1
        v11 = v10 == v7
        del v7, v10
        if v11:
            del v11
            v12 = v3 >> 1
            del v3
            v13 = v12 == v6
            del v6, v12
            if v13:
                del v13
                v14 = spiral_wrap(v4 << 2, 32, True)
                del v4
                v15 = v14 == v5
                del v5, v14
                if v15:
                    del v15
                    v16 = spiral_wrap(v2 + 1, 32, False)
                    v17 = v16 == 0
                    del v16
                    if v17:
                        del v17
                        v18 = spiral_wrap(v2 * v2, 32, False)
                        v19 = v18 == 1
                        del v18
                        if v19:
                            del v19
                            v20 = v2 >> 28
                            del v2
                            v21 = v20 == 15
                            del v20
                            if v21:
                                del v21
                                return 0
                            else:
                                del v21
                                return 7
                        else:
                            del v2, v19
                            return 6
                    else:
                        del v2, v17
                        return 5
                else:
                    del v2, v15
                    return 4
            else:
                del v2, v4, v5, v13
                return 3
        else:
            del v2, v3, v4, v5, v6, v11
            return 2
    else:
        del v1, v2, v3, v4, v5, v6, v7, v9
        return 1

if __name__ == '__main__': sys.exit(main())
