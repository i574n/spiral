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
class US0_North(NamedTuple): # North
    tag = 0
US0_North_shared = US0_North()
class US0_East(NamedTuple): # East
    tag = 1
US0_East_shared = US0_East()
class US0_South(NamedTuple): # South
    tag = 2
US0_South_shared = US0_South()
class US0_West(NamedTuple): # West
    tag = 3
US0_West_shared = US0_West()
US0 = Union[US0_North, US0_East, US0_South, US0_West]
def main():
    v0 = US0_North_shared
    match v0:
        case US0_East(): # East
            v8 = US0_South_shared
        case US0_North(): # North
            v8 = US0_East_shared
        case US0_South(): # South
            v8 = US0_West_shared
        case US0_West(): # West
            v8 = US0_North_shared
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    match v8:
        case US0_East(): # East
            v16 = US0_South_shared
        case US0_North(): # North
            v16 = US0_East_shared
        case US0_South(): # South
            v16 = US0_West_shared
        case US0_West(): # West
            v16 = US0_North_shared
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    v17 = US0_South_shared
    match v16, v17:
        case US0_East(), US0_East(): # East
            v18 = True
        case US0_North(), US0_North(): # North
            v18 = True
        case US0_South(), US0_South(): # South
            v18 = True
        case US0_West(), US0_West(): # West
            v18 = True
        case t:
            v18 = False
    if v18:
        v19 = 100
    else:
        v19 = 0
    match v0:
        case US0_East(): # East
            v21 = 2
        case US0_North(): # North
            v21 = 1
        case t:
            v21 = 7
    match v8:
        case US0_East(): # East
            v23 = 2
        case US0_North(): # North
            v23 = 1
        case t:
            v23 = 7
    v24 = spiral_wrap(v23 * 3, 32, True)
    v25 = spiral_wrap(v21 + v24, 32, True)
    match v16:
        case US0_East(): # East
            v27 = 2
        case US0_North(): # North
            v27 = 1
        case t:
            v27 = 7
    v28 = spiral_wrap(v27 * 9, 32, True)
    v29 = spiral_wrap(v25 + v28, 32, True)
    v30 = spiral_wrap(v29 + v19, 32, True)
    return v30

if __name__ == '__main__': sys.exit(main())
