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
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Held(v1): # Held
            v2, v3 = v1.v0, v1.v1
            v4, v5 = v2.v0, v2.v1
            v6, v7 = v4.v0, v4.v1
            v8, v9 = v5.v0, v5.v1
            v10 = v6 == 7
            if v10:
                v11 = v7 == "hi"
                v12 = v11
            else:
                v12 = False
            if v12:
                v13 = v8 == 4
                v14 = v13
            else:
                v14 = False
            if v14:
                v15 = v9 == "yo"
                v16 = v15
            else:
                v16 = False
            if v16:
                v17 = v3 == 2
                v18 = v17
            else:
                v18 = False
            if v18:
                return 0
            else:
                return 1
        case US0_None(): # None
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
    v14 = v13.v0
    return score_0(v14)

if __name__ == '__main__': sys.exit(main())
