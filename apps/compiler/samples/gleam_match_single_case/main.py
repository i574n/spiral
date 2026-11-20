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
class US0_Step(NamedTuple): # Step
    v0 : i32
    v1 : i32
    v2 : i32
    tag = 0
US0 = US0_Step
def walk_0(v0 : i32) -> i32:
    v1 = v0 > 2
    if v1:
        v2 = spiral_wrap(v0 + 1, 32, True)
        v3 = spiral_wrap(v0 + 2, 32, True)
        v6 = US0_Step(v0, v2, v3)
    else:
        v6 = US0_Step(0, 1, 2)
    match v6:
        case US0_Step(v7, v8, v9): # Step
            v10 = spiral_wrap(v8 * v9, 32, True)
            v11 = spiral_wrap(v7 + v10, 32, True)
            return v11
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 5
    v1 = walk_0(v0)
    v2 = spiral_wrap(v0 - 4, 32, True)
    v3 = walk_0(v2)
    v4 = spiral_wrap(v1 + v3, 32, True)
    return v4

if __name__ == '__main__': sys.exit(main())
