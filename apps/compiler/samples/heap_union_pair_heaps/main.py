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
class US0_None(NamedTuple): # None
    tag = 0
US0_None_shared = US0_None()
class US0_Held(NamedTuple): # Held
    v0 : Heap0
    v1 : Heap0
    tag = 1
US0 = Union[US0_None, US0_Held]
class Heap1(NamedTuple):
    v0 : US0
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Held(v1, v2): # Held
            v3, v4 = v1.v0, v1.v1
            v5, v6 = v2.v0, v2.v1
            v7 = v3 == 7
            if v7:
                v8 = v4 == "hi"
                v9 = v8
            else:
                v9 = False
            if v9:
                v10 = v5 == 4
                v11 = v10
            else:
                v11 = False
            if v11:
                v12 = v6 == "yo"
                v13 = v12
            else:
                v13 = False
            if v13:
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
    v6 = True
    if v6:
        v9 = US0_Held(v2, v5)
    else:
        v9 = US0_None_shared
    v10 = Heap1(v9)
    v11 = v10.v0
    return score_0(v11)

if __name__ == '__main__': sys.exit(main())
