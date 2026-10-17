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
class US1_Mark(NamedTuple): # Mark
    v0 : i32
    tag = 2
US1 = Union[US1_Absent, US1_Box, US1_Mark]
def score_0(v0 : US1) -> i32:
    match v0:
        case US1_Absent(): # Absent
            del v0
            return 1
        case US1_Box(v3): # Box
            del v0
            v4 = v3.v0
            del v3
            match v4:
                case US0_Held(v5): # Held
                    del v4
                    v6, v7 = v5.v0, v5.v1
                    del v5
                    v8, v9 = v6.v0, v6.v1
                    del v6
                    v10, v11 = v8.v0, v8.v1
                    del v8
                    v12, v13 = v9.v0, v9.v1
                    del v9
                    v14 = v10 == 7
                    del v10
                    if v14:
                        v15 = v11 == "hi"
                        v16 = v15
                    else:
                        v16 = False
                    del v11, v14
                    if v16:
                        v17 = v12 == 4
                        v18 = v17
                    else:
                        v18 = False
                    del v12, v16
                    if v18:
                        v19 = v13 == "yo"
                        v20 = v19
                    else:
                        v20 = False
                    del v13, v18
                    if v20:
                        v21 = v7 == 2
                        v22 = v21
                    else:
                        v22 = False
                    del v7, v20
                    if v22:
                        del v22
                        return 0
                    else:
                        del v22
                        return 1
                case US0_None(): # None
                    del v4
                    return 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case US1_Mark(_): # Mark
            del v0
            return 1
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
        v17 = US1_Mark(1)
    del v13, v14
    v18 = 3
    v19 = score_0(v17)
    del v17
    v20 = US1_Mark(v18)
    del v18
    v21 = score_0(v20)
    del v20
    v22 = US1_Absent()
    v23 = score_0(v22)
    del v22
    v24 = v19 == 0
    del v19
    if v24:
        v25 = v21 == 1
        v26 = v25
    else:
        v26 = False
    del v21, v24
    if v26:
        v27 = v23 == 1
        v28 = v27
    else:
        v28 = False
    del v23, v26
    if v28:
        del v28
        return 0
    else:
        del v28
        return 1

if __name__ == '__main__': sys.exit(main())
