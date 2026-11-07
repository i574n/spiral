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
class US0_Both(NamedTuple): # Both
    v0 : i8
    v1 : string
    tag = 1
US0 = Union[US0_None, US0_Both]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Both(v1, v2): # Both
            v3 = v1 == 100
            if v3:
                v4 = v2 == "hi"
                v5 = v4
            else:
                v5 = False
            if v5:
                return 0
            else:
                return 1
        case US0_None(): # None
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 100
    v1 = "hi"
    v2 = True
    if v2:
        v5 = US0_Both(v0, v1)
    else:
        v5 = US0_None_shared
    return score_0(v5)

if __name__ == '__main__': sys.exit(main())
