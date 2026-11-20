kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class US0_Empty(NamedTuple): # Empty
    tag = 0
US0_Empty_shared = US0_Empty()
class US0_Full(NamedTuple): # Full
    v0 : i32
    tag = 1
US0 = Union[US0_Empty, US0_Full]
def pick_0(v0 : US0) -> i32:
    match v0:
        case US0_Empty(): # Empty
            return 0
        case US0_Full(v1): # Full
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    if v0:
        v3 = US0_Full(7)
    else:
        v3 = US0_Empty_shared
    if v0:
        v6 = US0_Empty_shared
    else:
        v6 = US0_Full(1)
    v7 = pick_0(v3)
    v8 = v7 == 7
    if v8:
        v9 = pick_0(v6)
        v10 = v9 == 0
        v11 = v10
    else:
        v11 = False
    if v11:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
