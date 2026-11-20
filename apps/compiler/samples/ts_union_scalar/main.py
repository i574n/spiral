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
class US0_Hit(NamedTuple): # Hit
    v0 : i32
    tag = 0
class US0_Miss(NamedTuple): # Miss
    v0 : i32
    tag = 1
US0 = Union[US0_Hit, US0_Miss]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Hit(v1): # Hit
            return v1
        case US0_Miss(v2): # Miss
            v3 = spiral_wrap(-v2, 32, True)
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    if v0:
        v3 = US0_Hit(7)
    else:
        v3 = US0_Miss(3)
    v4 = score_0(v3)
    v5 = spiral_wrap(v4 - 7, 32, True)
    return v5

if __name__ == '__main__': sys.exit(main())
