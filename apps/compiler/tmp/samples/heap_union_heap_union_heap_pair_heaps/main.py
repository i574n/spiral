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
class Heap0(NamedTuple):
    v0 : i32
    v1 : string
class Heap1(NamedTuple):
    v0 : Heap0
    v1 : Heap0
class Heap2(NamedTuple):
    v0 : Heap1
    v1 : i32
class US0_None(NamedTuple): # None
    tag = 0
class US0_Held(NamedTuple): # Held
    v0 : Heap2
    tag = 1
US0 = Union[US0_None, US0_Held]
class Heap3(NamedTuple):
    v0 : US0
class US1_Absent(NamedTuple): # Absent
    tag = 0
class US1_Box(NamedTuple): # Box
    v0 : Heap3
    tag = 1
US1 = Union[US1_Absent, US1_Box]
class Heap4(NamedTuple):
    v0 : US1
def score_0(v0 : US1) -> i32:
    match v0:
        case US1_Absent(): # Absent
            del v0
            return 1
        case US1_Box(v1): # Box
            del v0
            v2 = v1.v0
            del v1
            match v2:
                case US0_Held(v3): # Held
                    del v2
                    v4, v5 = v3.v0, v3.v1
                    del v3
                    v6, v7 = v4.v0, v4.v1
                    del v4
                    v8, v9 = v6.v0, v6.v1
                    del v6
                    v10, v11 = v7.v0, v7.v1
                    del v7
                    v12 = v8 == 7
                    del v8
                    if v12:
                        v13 = v9 == "hi"
                        v14 = v13
                    else:
                        v14 = False
                    del v9, v12
                    if v14:
                        v15 = v10 == 4
                        v16 = v15
                    else:
                        v16 = False
                    del v10, v14
                    if v16:
                        v17 = v11 == "yo"
                        v18 = v17
                    else:
                        v18 = False
                    del v11, v16
                    if v18:
                        v19 = v5 == 2
                        v20 = v19
                    else:
                        v20 = False
                    del v5, v18
                    if v20:
                        del v20
                        return 0
                    else:
                        del v20
                        return 1
                case US0_None(): # None
                    del v2
                    return 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 7
    v1 = "hi"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 4
    v4 = "yo"
    v5 = Heap0(v3, v4)
    del v3, v4
    v6 = Heap1(v2, v5)
    del v2, v5
    v7 = 2
    v8 = Heap2(v6, v7)
    del v6, v7
    v9 = True
    if v9:
        v12 = US0_Held(v8)
    else:
        v12 = US0_None()
    del v8, v9
    v13 = Heap3(v12)
    del v12
    v14 = True
    if v14:
        v17 = US1_Box(v13)
    else:
        v17 = US1_Absent()
    del v13, v14
    v18 = Heap4(v17)
    del v17
    v19 = v18.v0
    del v18
    return score_0(v19)

if __name__ == '__main__': sys.exit(main())
