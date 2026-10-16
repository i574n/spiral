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

def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
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
class US1_Mark(NamedTuple): # Mark
    v0 : i32
    tag = 2
US1 = Union[US1_Absent, US1_Box, US1_Mark]
def f_c0(env_v0 : US1, env_v1 : i32):
    def inner(v2 : i32) -> US1:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 == 0
        if v3:
            del v0, v1, v3
            return US1_Absent()
        else:
            del v3
            v5 = v2 == 1
            if v5:
                del v1, v5
                return v0
            else:
                del v0, v5
                return US1_Mark(v1)
    return inner
class Heap4(NamedTuple):
    v0 : US1
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
    v19 = f_c0(v17, v18)
    del v17, v18
    v20 = v19(1)
    v21 = Heap4(v20)
    del v20
    v22 = v19(2)
    v23 = Heap4(v22)
    del v22
    v24 = v19(0)
    del v19
    v25 = Heap4(v24)
    del v24
    v26 = __import__('numpy').empty(3,dtype=object)
    v26[0] = v21
    del v21
    v26[1] = v23
    del v23
    v26[2] = v25
    del v25
    v27 = spiral_array_index(v26, 0)
    v28 = v27.v0
    del v27
    v29 = spiral_array_index(v26, 1)
    v30 = v29.v0
    del v29
    v31 = spiral_array_index(v26, 2)
    del v26
    v32 = v31.v0
    del v31
    v33 = score_0(v28)
    del v28
    v34 = score_0(v30)
    del v30
    v35 = score_0(v32)
    del v32
    v36 = v33 == 0
    del v33
    if v36:
        v37 = v34 == 1
        v38 = v37
    else:
        v38 = False
    del v34, v36
    if v38:
        v39 = v35 == 1
        v40 = v39
    else:
        v40 = False
    del v35, v38
    if v40:
        del v40
        return 0
    else:
        del v40
        return 1

if __name__ == '__main__': sys.exit(main())
