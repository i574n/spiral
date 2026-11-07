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
class US0_Cold(NamedTuple): # Cold
    tag = 0
US0_Cold_shared = US0_Cold()
class US0_Warm(NamedTuple): # Warm
    tag = 1
US0_Warm_shared = US0_Warm()
class US0_Hot(NamedTuple): # Hot
    tag = 2
US0_Hot_shared = US0_Hot()
class US0_Done(NamedTuple): # Done
    tag = 3
US0_Done_shared = US0_Done()
US0 = Union[US0_Cold, US0_Warm, US0_Hot, US0_Done]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Cold(): # Cold
            return 1
        case US0_Done(): # Done
            return 4
        case US0_Hot(): # Hot
            return 3
        case US0_Warm(): # Warm
            return 2
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 3
    v1 = v0 == 0
    if v1:
        v10 = US0_Cold_shared
    else:
        v3 = v0 == 1
        if v3:
            v10 = US0_Warm_shared
        else:
            v5 = v0 == 2
            if v5:
                v10 = US0_Hot_shared
            else:
                v10 = US0_Done_shared
    v11 = score_0(v10)
    v12 = spiral_wrap(v11 - 4, 32, True)
    return v12

if __name__ == '__main__': sys.exit(main())
