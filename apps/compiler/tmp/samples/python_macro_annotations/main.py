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
class US0_0(NamedTuple): # W
    v0 : object
    tag = 0
class US0_1(NamedTuple): # T
    v0 : 'System.Threading.CancellationToken'
    tag = 1
US0 = Union[US0_0, US0_1]
def method0(v0 : object) -> i32:
    v1 = v0 * 2
    del v0
    return v1
def main():
    v0 = 7
    v1 = v0 + 1
    v2 = method0(v1)
    v3 = v0 > 0
    del v0
    if v3:
        v7 = US0_0(v1)
    else:
        v5 = None
        v7 = US0_1(v5)
    del v1, v3
    match v7:
        case US0_1(_): # T
            del v2, v7
            return 0
        case US0_0(v8): # W
            del v7
            v9 = (v8)
            del v8
            v10 = v2 + v9
            del v2, v9
            return v10
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
