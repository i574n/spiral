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
@dataclass
class Mut0:
    v0 : Heap4
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
    v0 = 1
    v1 = "no"
    v2 = Heap0(v0, v1)
    del v0, v1
    v3 = 2
    v4 = "zz"
    v5 = Heap0(v3, v4)
    del v3, v4
    v6 = Heap1(v2, v5)
    del v2, v5
    v7 = 3
    v8 = Heap2(v6, v7)
    del v6, v7
    v9 = True
    if v9:
        v12 = US0_Held(v8)
    else:
        v12 = US0_None_shared
    del v8, v9
    v13 = Heap3(v12)
    del v12
    v14 = True
    if v14:
        v17 = US1_Box(v13)
    else:
        v17 = US1_Absent_shared
    del v13, v14
    v18 = Heap4(v17)
    del v17
    v19 = Mut0(v18)
    del v18
    v20 = __import__('numpy').empty(1,dtype=object)
    v20[0] = v19
    del v19
    v21 = 7
    v22 = "hi"
    v23 = Heap0(v21, v22)
    del v21, v22
    v24 = 4
    v25 = "yo"
    v26 = Heap0(v24, v25)
    del v24, v25
    v27 = Heap1(v23, v26)
    del v23, v26
    v28 = 2
    v29 = Heap2(v27, v28)
    del v27, v28
    v30 = True
    if v30:
        v33 = US0_Held(v29)
    else:
        v33 = US0_None_shared
    del v29, v30
    v34 = Heap3(v33)
    del v33
    v35 = True
    if v35:
        v38 = US1_Box(v34)
    else:
        v38 = US1_Absent_shared
    del v34, v35
    v39 = Heap4(v38)
    del v38
    v40 = spiral_array_index(v20, 0)
    del v20
    v40.v0 = v39
    del v39
    v41 = v40.v0
    del v40
    v42 = v41.v0
    del v41
    return score_0(v42)

if __name__ == '__main__': sys.exit(main())
