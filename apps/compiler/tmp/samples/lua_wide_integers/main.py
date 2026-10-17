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
def lcg_0(v0 : u64, v1 : u64, v2 : i32, v3 : u64) -> u64:
    while True:
        v4 = v2 == 0
        if v4:
            del v0, v1, v2, v4
            return v3
        else:
            del v4
            v5 = spiral_wrap(v2 - 1, 32, True)
            del v2
            v6 = spiral_wrap(v3 * v0, 64, False)
            del v3
            v7 = spiral_wrap(v6 + v1, 64, False)
            del v6
            v0, v1, v2, v3 = v0, v1, v5, v7
            continue
def main():
    v0 = 42
    v1 = 6364136223846793005
    v2 = 1442695040888963407
    v3 = 1000
    v4 = lcg_0(v1, v2, v3, v0)
    del v0, v2, v3
    print("lcg ", v4, "\n", sep='', end='')
    v5 = 9223372036854775807
    v6 = -9223372036854775807
    v7 = 18446744073709551615
    v8 = spiral_wrap(v6 - 1, 64, True)
    del v6
    v9 = spiral_wrap(v7 + 2, 64, False)
    del v7
    print("max ", v5, " min ", v8, " wrap ", v9, "\n", sep='', end='')
    del v5, v8, v9
    v10 = -9007199254740993
    v11 = 7
    v12 = spiral_wrap(spiral_div_trunc(v10, v11), 64, True)
    v13 = spiral_mod_trunc(v10, v11)
    del v11
    print("div ", v12, " mod ", v13, "\n", sep='', end='')
    del v12, v13
    v14 = v10 >> 3
    v15 = v4 >> 60
    print("shl ", 4611686018427387904, " shr ", v14, " ushr ", v15, "\n", sep='', end='')
    del v14, v15
    v16 = v4 & 18446744069414584320
    v17 = v10 | 255
    v18 = v4 ^ v1
    print("and ", v16, " or ", v17, " xor ", v18, "\n", sep='', end='')
    del v16, v17, v18
    v19 = 1E+18
    v20 = spiral_wrap(int(v19), 64, True)
    del v19
    v21 = spiral_wrap(int(v4), 32, False)
    v22 = f64(v10)
    del v10
    v23 = v22 < 0.0
    del v22
    if v23:
        v24 = 1
    else:
        v24 = 0
    del v23
    print("conv ", v20, " ", v21, " ", v24, "\n", sep='', end='')
    del v20, v21, v24
    v25 = v4 > v1
    del v1, v4
    if v25:
        del v25
        return 1
    else:
        del v25
        return 0

if __name__ == '__main__': sys.exit(main())
