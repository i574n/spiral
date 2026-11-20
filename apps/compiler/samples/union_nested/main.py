kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
class US0_A(NamedTuple): # A
    v0 : i32
    tag = 0
class US0_B(NamedTuple): # B
    v0 : i32
    tag = 1
US0 = Union[US0_A, US0_B]
class US1_Wrap(NamedTuple): # Wrap
    v0 : US0
    tag = 0
class US1_Other(NamedTuple): # Other
    v0 : i32
    tag = 1
US1 = Union[US1_Wrap, US1_Other]
def score_inner_1(v0 : US0) -> i32:
    match v0:
        case US0_A(v1): # A
            return v1
        case US0_B(v2): # B
            v3 = spiral_wrap(-v2, 32, True)
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def score_0(v0 : US1) -> i32:
    match v0:
        case US1_Other(v3): # Other
            return v3
        case US1_Wrap(v1): # Wrap
            return score_inner_1(v1)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    if v0:
        v1 = US0_A(7)
        v4 = US1_Wrap(v1)
    else:
        v4 = US1_Other(1)
    if v0:
        v8 = US1_Other(4)
    else:
        v6 = US0_B(2)
        v8 = US1_Wrap(v6)
    v9 = score_0(v4)
    v10 = v9 == 7
    if v10:
        v11 = score_0(v8)
        v12 = v11 == 4
        v13 = v12
    else:
        v13 = False
    if v13:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
