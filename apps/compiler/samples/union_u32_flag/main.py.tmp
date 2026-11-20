kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class US0_None(NamedTuple): # None
    tag = 0
US0_None_shared = US0_None()
class US0_All(NamedTuple): # All
    v0 : u32
    v1 : string
    v2 : bool
    tag = 1
US0 = Union[US0_None, US0_All]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_All(v1, v2, v3): # All
            v4 = v1 == 4000000000
            if v4:
                v5 = v2 == "hi"
                v6 = v5
            else:
                v6 = False
            v7 = v6 and v3
            if v7:
                return 0
            else:
                return 1
        case US0_None(): # None
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 4000000000
    v1 = "hi"
    v2 = True
    v3 = True
    if v3:
        v6 = US0_All(v0, v1, v2)
    else:
        v6 = US0_None_shared
    return score_0(v6)

if __name__ == '__main__': sys.exit(main())
