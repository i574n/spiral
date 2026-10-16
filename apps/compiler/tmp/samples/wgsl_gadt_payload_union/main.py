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
class US0_Living(NamedTuple): # Living
    v0 : i32
    v1 : i32
    tag = 0
US0 = US0_Living
class US2_Fallen(NamedTuple): # Fallen
    v0 : i32
    tag = 1
US2 = US2_Fallen
class US1_Survived(NamedTuple): # Survived
    v0 : US0
    tag = 0
class US1_Slain(NamedTuple): # Slain
    v0 : US2
    tag = 1
US1 = Union[US1_Survived, US1_Slain]
def main():
    v0 = 60
    v1 = v0 > 0
    if v1:
        v2 = US0_Living(v0, 100)
        v6 = US1_Survived(v2)
    else:
        v4 = US2_Fallen(100)
        v6 = US1_Slain(v4)
    del v0, v1
    match v6:
        case US1_Slain(_): # Slain
            del v6
            return 2
        case US1_Survived(v7): # Survived
            del v6
            match v7:
                case US0_Living(v8, _): # Living
                    del v7
                    v10 = v8 == 60
                    del v8
                    if v10:
                        del v10
                        return 0
                    else:
                        del v10
                        return 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
