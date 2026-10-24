kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
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
            return US1_Absent_shared
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
            return 1
        case US1_Box(v3): # Box
            v4 = v3.v0
            match v4:
                case US0_Held(v5): # Held
                    v6, v7 = v5.v0, v5.v1
                    v8, v9 = v6.v0, v6.v1
                    v10, v11 = v8.v0, v8.v1
                    v12, v13 = v9.v0, v9.v1
                    v14 = v10 == 7
                    if v14:
                        v15 = v11 == "hi"
                        v16 = v15
                    else:
                        v16 = False
                    if v16:
                        v17 = v12 == 4
                        v18 = v17
                    else:
                        v18 = False
                    if v18:
                        v19 = v13 == "yo"
                        v20 = v19
                    else:
                        v20 = False
                    if v20:
                        v21 = v7 == 2
                        v22 = v21
                    else:
                        v22 = False
                    if v22:
                        return 0
                    else:
                        return 1
                case US0_None(): # None
                    return 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case US1_Mark(_): # Mark
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 7
    v1 = "hi"
    v2 = Heap0(v0, v1)
    v3 = 4
    v4 = "yo"
    v5 = Heap0(v3, v4)
    v6 = Heap1(v2, v5)
    v7 = 2
    v8 = Heap2(v6, v7)
    v9 = True
    if v9:
        v12 = US0_Held(v8)
    else:
        v12 = US0_None_shared
    v13 = Heap3(v12)
    v14 = True
    if v14:
        v17 = US1_Box(v13)
    else:
        v17 = US1_Mark(1)
    v18 = 3
    v19 = f_c0(v17, v18)
    v20 = v19(1)
    v21 = Heap4(v20)
    v22 = v19(2)
    v23 = Heap4(v22)
    v24 = v19(0)
    v25 = Heap4(v24)
    v26 = v21.v0
    v27 = v23.v0
    v28 = v25.v0
    v29 = score_0(v26)
    v30 = score_0(v27)
    v31 = score_0(v28)
    v32 = v29 == 0
    if v32:
        v33 = v30 == 1
        v34 = v33
    else:
        v34 = False
    if v34:
        v35 = v31 == 1
        v36 = v35
    else:
        v36 = False
    if v36:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
