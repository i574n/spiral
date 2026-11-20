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
class US0_Real(NamedTuple): # Real
    v0 : f64
    tag = 0
class US0_Whole(NamedTuple): # Whole
    v0 : i32
    tag = 1
US0 = Union[US0_Real, US0_Whole]
def twice_1(v0 : f64) -> i32:
    v1 = v0 * 2.0
    v2 = spiral_wrap(int(v1), 32, True)
    return v2
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Real(v1): # Real
            return twice_1(v1)
        case US0_Whole(v3): # Whole
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    v1 = 1.5
    if v0:
        v4 = US0_Real(v1)
    else:
        v4 = US0_Whole(1)
    if v0:
        v7 = US0_Whole(5)
    else:
        v7 = US0_Real(v1)
    v8 = score_0(v4)
    v9 = v8 == 3
    if v9:
        v10 = score_0(v7)
        v11 = v10 == 5
        v12 = v11
    else:
        v12 = False
    if v12:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
