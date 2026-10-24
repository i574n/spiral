kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class US0_One(NamedTuple): # One
    v0 : i32
    tag = 0
class US0_All(NamedTuple): # All
    v0 : i32
    v1 : string
    v2 : bool
    tag = 1
US0 = Union[US0_One, US0_All]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_All(v2, v3, v4): # All
            v5 = v2 == 7
            if v5:
                v6 = v3 == "hi"
                v7 = v6
            else:
                v7 = False
            v8 = v7 and v4
            if v8:
                return 0
            else:
                return 1
        case US0_One(v1): # One
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    v1 = 7
    v2 = "hi"
    v3 = True
    if v0:
        v6 = US0_All(v1, v2, v3)
    else:
        v6 = US0_One(1)
    return score_0(v6)

if __name__ == '__main__': sys.exit(main())
