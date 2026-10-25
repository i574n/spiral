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
US1 = Union[US1_Absent, US1_Box]
class Heap4(NamedTuple):
    v0 : US1
def f_c0(env_v0 : Heap4):
    def inner(v1 : i32) -> Heap4:
        nonlocal env_v0
        v0 = env_v0
        return v0
    return inner
def score_0(v0 : US1) -> i32:
    match v0:
        case US1_Absent(): # Absent
            return 1
        case US1_Box(v1): # Box
            v2 = v1.v0
            match v2:
                case US0_Held(v3): # Held
                    v4, v5 = v3.v0, v3.v1
                    v6, v7 = v4.v0, v4.v1
                    v8, v9 = v6.v0, v6.v1
                    v10, v11 = v7.v0, v7.v1
                    v12 = v8 == 7
                    if v12:
                        v13 = v9 == "hi"
                        v14 = v13
                    else:
                        v14 = False
                    if v14:
                        v15 = v10 == 4
                        v16 = v15
                    else:
                        v16 = False
                    if v16:
                        v17 = v11 == "yo"
                        v18 = v17
                    else:
                        v18 = False
                    if v18:
                        v19 = v5 == 2
                        v20 = v19
                    else:
                        v20 = False
                    if v20:
                        return 0
                    else:
                        return 1
                case US0_None(): # None
                    return 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
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
        v17 = US1_Absent_shared
    v18 = Heap4(v17)
    v19 = f_c0(v18)
    v20 = v19(1)
    v21 = v20.v0
    return score_0(v21)

if __name__ == '__main__': sys.exit(main())
