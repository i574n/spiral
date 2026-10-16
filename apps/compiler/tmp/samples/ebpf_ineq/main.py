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
    del v1
    v10 = v0 != v2
    del v0, v2
    v11 = v3 != v4
    del v4
    v12 = v3 != v5
    del v3, v5
    v13 = v6 != v7
    del v7
    v14 = v6 != v8
    del v6, v8
    v15 = v9 and v11
    del v9, v11
    v16 = v15 and v13
    del v13, v15
    if v16:
        del v16
        if v10:
            del v10, v12, v14
            return 1
        else:
            del v10
            if v12:
                del v12, v14
                return 2
            else:
                del v12
                if v14:
                    del v14
                    return 3
                else:
                    del v14
                    return 0
    else:
        del v10, v12, v14, v16
        return 4

if __name__ == '__main__': sys.exit(main())
