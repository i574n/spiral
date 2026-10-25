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
class Heap0(NamedTuple):
    v0 : i32
class US0_None(NamedTuple): # None
    tag = 0
US0_None_shared = US0_None()
class US0_Some(NamedTuple): # Some
    v0 : i32
    tag = 1
US0 = Union[US0_None, US0_Some]
def method0(v0 : i32, v1 : Heap0) -> Tuple[US0, Heap0]:
    v2 = US0_Some(v0)
    return v2, v1
def main():
    v0 = 3
    v1 = 4
    v2 = Heap0(v1)
    v3, v4 = method0(v0, v2)
    match v3:
        case US0_None(): # None
            return 1
        case US0_Some(v5): # Some
            v6 = v4.v0
            v7 = spiral_wrap(v5 + v6, 32, True)
            v8 = v7 == 7
            if v8:
                return 0
            else:
                return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
