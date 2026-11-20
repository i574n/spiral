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
class US0_Done(NamedTuple): # Done
    v0 : i32
    tag = 0
class US0_More(NamedTuple): # More
    v0 : i32
    tag = 1
US0 = Union[US0_Done, US0_More]
def layers_0(v0 : i32) -> i32:
    while True:
        v1 = v0 >= 5
        if v1:
            v4 = US0_Done(v0)
        else:
            v4 = US0_More(v0)
        match v4:
            case US0_Done(v8): # Done
                v9 = spiral_wrap(v8 * 2, 32, True)
                return v9
            case US0_More(v5): # More
                v6 = spiral_wrap(v5 + 1, 32, True)
                v0 = v6
                continue
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 0
    return layers_0(v0)

if __name__ == '__main__': sys.exit(main())
