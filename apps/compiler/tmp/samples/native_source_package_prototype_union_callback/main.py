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
def closure0(env_v0 : i32):
    def inner(v1 : i32) -> US0:
        nonlocal env_v0
        v0 = env_v0
        v2 = v1 == v0
        del v0
        return US0_Flag(v2)
    return inner
def method0(v0 : Callable[[i32], US0], v1 : i32) -> US0:
    return v0(v1)
def main():
    v0 = 2
    v1 = closure0(v0)
    v2 = method0(v1, v0)
    match v2:
        case US0_Flag(v4): # Flag
            if v4:
                v8 = 11
            else:
                v8 = 5
        case US0_Hit(v3): # Hit
            v8 = v3
        case US0_Idle(): # Idle
            v8 = 3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    v9 = spiral_wrap(v8 + 31, 32, True)
    return v9

if __name__ == '__main__': sys.exit(main())
