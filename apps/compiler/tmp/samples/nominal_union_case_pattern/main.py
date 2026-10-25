kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class US0_Zero(NamedTuple): # Zero
    tag = 0
US0_Zero_shared = US0_Zero()
class US0_One(NamedTuple): # One
    tag = 1
US0_One_shared = US0_One()
US0 = Union[US0_Zero, US0_One]
def main():
    v0 = US0_Zero_shared
    match v0:
        case US0_One(): # One
            v2 = False
        case US0_Zero(): # Zero
            v2 = True
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    if v2:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
