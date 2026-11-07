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

def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
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
US0_None_shared = US0_None()
class US0_Held(NamedTuple): # Held
    v0 : Heap2
    tag = 1
US0 = Union[US0_None, US0_Held]
class Heap3(NamedTuple):
    v0 : US0
class US1_Absent(NamedTuple): # Absent
    tag = 0
US1_Absent_shared = US1_Absent()
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
def score_b_1(v0 : US1) -> i32:
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
                    v12 = v8 == 8
                    del v8
                    if v12:
                        v13 = v9 == "ok"
                        v14 = v13
                    else:
                        v14 = False
                    del v9, v12
                    if v14:
                        v15 = v10 == 5
                        v16 = v15
                    else:
                        v16 = False
                    del v10, v14
                    if v16:
                        v17 = v11 == "no"
                        v18 = v17
                    else:
                        v18 = False
                    del v11, v16
                    if v18:
                        v19 = v5 == 9
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
    v9 = US0_Held(v8)
    del v8
    v10 = Heap3(v9)
    del v9
    v11 = US1_Box(v10)
    del v10
    v12 = Heap4(v11)
    del v11
    v13 = 8
    v14 = "ok"
    v15 = Heap0(v13, v14)
    del v13, v14
    v16 = 5
    v17 = "no"
    v18 = Heap0(v16, v17)
    del v16, v17
    v19 = Heap1(v15, v18)
    del v15, v18
    v20 = 9
    v21 = Heap2(v19, v20)
    del v19, v20
    v22 = US0_Held(v21)
    del v21
    v23 = Heap3(v22)
    del v22
    v24 = US1_Box(v23)
    del v23
    v25 = Heap4(v24)
    del v24
    v26 = __import__('numpy').empty(2,dtype=object)
    v26[0] = v12
    del v12
    v26[1] = v25
    del v25
    v27 = spiral_array_index(v26, 0)
    v28 = spiral_array_index(v26, 1)
    del v26
    v29 = v27.v0
    del v27
    v30 = v28.v0
    del v28
    v31 = score_0(v29)
    del v29
    v32 = score_b_1(v30)
    del v30
    v33 = v31 == 0
    del v31
    if v33:
        v34 = v32 == 0
        v35 = v34
    else:
        v35 = False
    del v32, v33
    if v35:
        del v35
        return 0
    else:
        del v35
        return 1

if __name__ == '__main__': sys.exit(main())
