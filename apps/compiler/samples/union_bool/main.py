kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class US0_No(NamedTuple): # No
    v0 : bool
    tag = 0
class US0_Yes(NamedTuple): # Yes
    v0 : i32
    tag = 1
US0 = Union[US0_No, US0_Yes]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_No(v1): # No
            if v1:
                return 1
            else:
                return 2
        case US0_Yes(v3): # Yes
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    if v0:
        v3 = US0_Yes(7)
    else:
        v3 = US0_No(False)
    if v0:
        v6 = US0_No(True)
    else:
        v6 = US0_Yes(1)
    v7 = score_0(v3)
    v8 = v7 == 7
    if v8:
        v9 = score_0(v6)
        v10 = v9 == 1
        v11 = v10
    else:
        v11 = False
    if v11:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
