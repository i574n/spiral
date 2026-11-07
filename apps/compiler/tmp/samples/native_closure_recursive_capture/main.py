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
UH0 = Union["UH0_Leaf", "UH0_Node"]
class UH0_Leaf(NamedTuple): # Leaf
    tag = 0
UH0_Leaf_shared = UH0_Leaf()
class UH0_Node(NamedTuple): # Node
    v0 : i32
    v1 : UH0
    v2 : UH0
    tag = 1
def f_c0(env_v0 : UH0):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        v2 = sum_0(v0)
        del v0
        v3 = spiral_wrap(v2 + v1, 32, True)
        del v2
        return v3
    return inner
def sum_0(v0 : UH0) -> i32:
    match v0:
        case UH0_Leaf(): # Leaf
            return 0
        case UH0_Node(v1, v2, v3): # Node
            v4 = sum_0(v2)
            v5 = sum_0(v3)
            v6 = spiral_wrap(v4 + v5, 32, True)
            v7 = spiral_wrap(v1 + v6, 32, True)
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = UH0_Leaf_shared
    v1 = 2
    v2 = UH0_Node(v1, v0, v0)
    v3 = f_c0(v2)
    v4 = v3(19)
    v5 = v3(19)
    v6 = spiral_wrap(v4 + v5, 32, True)
    return v6

if __name__ == '__main__': sys.exit(main())
