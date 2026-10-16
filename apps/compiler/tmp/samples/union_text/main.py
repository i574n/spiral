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
class US0_Text(NamedTuple): # Text
    v0 : string
    tag = 0
class US0_Code(NamedTuple): # Code
    v0 : i32
    tag = 1
US0 = Union[US0_Text, US0_Code]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Code(v4): # Code
            del v0
            return v4
        case US0_Text(v1): # Text
            del v0
            v2 = v1 == "hi"
            del v1
            if v2:
                del v2
                return 2
            else:
                del v2
                return 3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    v1 = "hi"
    if v0:
        v4 = US0_Text(v1)
    else:
        v4 = US0_Code(1)
    if v0:
        v7 = US0_Code(5)
    else:
        v7 = US0_Text(v1)
    del v0, v1
    v8 = score_0(v4)
    del v4
    v9 = v8 == 2
    del v8
    if v9:
        v10 = score_0(v7)
        v11 = v10 == 5
        del v10
        v12 = v11
    else:
        v12 = False
    del v7, v9
    if v12:
        del v12
        return 0
    else:
        del v12
        return 1

if __name__ == '__main__': sys.exit(main())
