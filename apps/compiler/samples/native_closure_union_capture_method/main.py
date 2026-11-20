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
class US0_Idle(NamedTuple): # Idle
    tag = 0
US0_Idle_shared = US0_Idle()
class US0_Hit(NamedTuple): # Hit
    v0 : i32
    tag = 1
class US0_Flag(NamedTuple): # Flag
    v0 : bool
    tag = 2
US0 = Union[US0_Idle, US0_Hit, US0_Flag]
def closure0(env_v0 : US0):
    def inner(v1 : i32) -> i32:
        nonlocal env_v0
        v0 = env_v0
        v2 = score_0(v0)
        del v0
        v3 = spiral_wrap(v2 + v1, 32, True)
        del v2
        return v3
    return inner
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Flag(v2): # Flag
            if v2:
                return 11
            else:
                return 5
        case US0_Hit(v1): # Hit
            return v1
        case US0_Idle(): # Idle
            return 3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method1(v0 : Callable[[i32], i32]) -> i32:
    return v0(31)
def main():
    v0 = 2
    v1 = v0 == 0
    if v1:
        v7 = US0_Idle_shared
    else:
        v3 = v0 == 1
        if v3:
            v7 = US0_Hit(7)
        else:
            v7 = US0_Flag(True)
    v8 = closure0(v7)
    return method1(v8)

if __name__ == '__main__': sys.exit(main())
