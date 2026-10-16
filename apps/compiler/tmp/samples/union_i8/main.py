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
class US0_Missing(NamedTuple): # Missing
    tag = 0
class US0_Held(NamedTuple): # Held
    v0 : i8
    tag = 1
US0 = Union[US0_Missing, US0_Held]
def main():
    v0 = 100
    v1 = True
    if v1:
        v4 = US0_Held(v0)
    else:
        v4 = US0_Missing()
    del v0, v1
    match v4:
        case US0_Held(v5): # Held
            del v4
            v6 = v5 == 100
            del v5
            if v6:
                del v6
                return 0
            else:
                del v6
                return 1
        case US0_Missing(): # Missing
            del v4
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
