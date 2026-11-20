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
class US0_First(NamedTuple): # First
    tag = 1
US0_First_shared = US0_First()
class US0_Second(NamedTuple): # Second
    tag = 2
US0_Second_shared = US0_Second()
US0 = Union[US0_First, US0_Second]
def main():
    v0 = US0_Second_shared
    v1 = v0.tag
    v2 = spiral_wrap(v1 * 10, 32, True)
    v3 = spiral_wrap(v2 + 2, 32, True)
    return v3

if __name__ == '__main__': sys.exit(main())
