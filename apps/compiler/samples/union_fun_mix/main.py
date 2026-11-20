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
def add_c0(env_v0 : i32):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        v2 = spiral_wrap(v1 + v0, 32, True)
        del v0
        return v2
    return inner
class US0_None(NamedTuple): # None
    tag = 0
US0_None_shared = US0_None()
class US0_Call(NamedTuple): # Call
    v0 : Callable[[i32], i32]
    v1 : i32
    tag = 1
US0 = Union[US0_None, US0_Call]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Call(v1, v2): # Call
            v3 = v1(0)
            v4 = spiral_wrap(v3 + v2, 32, True)
            v5 = v4 == 7
            if v5:
                return 0
            else:
                return 1
        case US0_None(): # None
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 3
    v1 = 4
    v2 = True
    if v2:
        v3 = add_c0(v0)
        v6 = US0_Call(v3, v1)
    else:
        v6 = US0_None_shared
    return score_0(v6)

if __name__ == '__main__': sys.exit(main())
