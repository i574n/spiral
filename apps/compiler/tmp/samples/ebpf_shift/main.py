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
def main():
    v0 = -8
    v1 = 3
    v2 = 1
    v3 = 4294967295
    v4 = 4
    v5 = v0 >> v2
    del v0
    v6 = spiral_wrap(v1 << v2, 32, True)
    del v1
    v7 = v3 >> v4
    del v4
    v8 = spiral_wrap(v3 << v2, 32, False)
    del v2, v3
    v9 = v5 == -4
    del v5
    if v9:
        del v9
        v10 = v6 == 6
        del v6
        if v10:
            del v10
            v11 = v7 == 268435455
            del v7
            if v11:
                del v11
                v12 = v8 == 4294967294
                del v8
                if v12:
                    del v12
                    return 0
                else:
                    del v12
                    return 4
            else:
                del v8, v11
                return 3
        else:
            del v7, v8, v10
            return 2
    else:
        del v6, v7, v8, v9
        return 1

if __name__ == '__main__': sys.exit(main())
