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
class US0_Text(NamedTuple): # Text
    v0 : string
    tag = 1
class US0_Note(NamedTuple): # Note
    v0 : string
    tag = 2
US0 = Union[US0_Idle, US0_Text, US0_Note]
def closure0():
    def inner(v0 : i32) -> US0:
        v1 = v0 == 1
        if v1:
            del v1
            v2 = "alpha"
            return US0_Text(v2)
        else:
            del v1
            v4 = "beta"
            return US0_Note(v4)
    return inner
def method0(v0 : Callable[[i32], US0]) -> US0:
    return v0(1)
def method1(v0 : Callable[[i32], US0]) -> US0:
    return v0(2)
def main():
    v0 = closure0()
    v1 = method0(v0)
    match v1:
        case US0_Idle(): # Idle
            v6 = 3
        case US0_Note(_): # Note
            v6 = 6
        case US0_Text(_): # Text
            v6 = 5
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    v7 = method1(v0)
    match v7:
        case US0_Idle(): # Idle
            v12 = 3
        case US0_Note(_): # Note
            v12 = 6
        case US0_Text(_): # Text
            v12 = 5
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    v13 = spiral_wrap(v6 + v12, 32, True)
    v14 = spiral_wrap(v13 + 31, 32, True)
    return v14

if __name__ == '__main__': sys.exit(main())
