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
class US0_None(NamedTuple): # None
    tag = 0
US0_None_shared = US0_None()
class US0_Some(NamedTuple): # Some
    v0 : i32
    tag = 1
US0 = Union[US0_None, US0_Some]
class Heap0(NamedTuple):
    v0 : US0
    v1 : i32
def main():
    v0 = 3
    v1 = 4
    v2 = US0_Some(v0)
    v3 = Heap0(v2, v1)
    v4, v5 = v3.v0, v3.v1
    match v4:
        case US0_None(): # None
            return 1
        case US0_Some(v6): # Some
            v7 = spiral_wrap(v6 + v5, 32, True)
            v8 = v7 == 7
            if v8:
                return 0
            else:
                return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
