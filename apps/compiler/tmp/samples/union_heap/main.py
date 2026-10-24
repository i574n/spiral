kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class Heap0(NamedTuple):
    v0 : i32
class US0_Missing(NamedTuple): # Missing
    tag = 0
US0_Missing_shared = US0_Missing()
class US0_Box(NamedTuple): # Box
    v0 : Heap0
    tag = 1
US0 = Union[US0_Missing, US0_Box]
def main():
    v0 = 7
    v1 = Heap0(v0)
    v2 = True
    if v2:
        v5 = US0_Box(v1)
    else:
        v5 = US0_Missing_shared
    match v5:
        case US0_Box(v6): # Box
            v7 = v6.v0
            v8 = v7 == 7
            if v8:
                return 0
            else:
                return 1
        case US0_Missing(): # Missing
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
