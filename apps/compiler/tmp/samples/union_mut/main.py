kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

@dataclass
class Mut0:
    v0 : i32
class US0_Missing(NamedTuple): # Missing
    tag = 0
US0_Missing_shared = US0_Missing()
class US0_Held(NamedTuple): # Held
    v0 : Mut0
    tag = 1
US0 = Union[US0_Missing, US0_Held]
def main():
    v0 = Mut0(1)
    v1 = True
    if v1:
        v4 = US0_Held(v0)
    else:
        v4 = US0_Missing_shared
    match v4:
        case US0_Held(v5): # Held
            v5.v0 = 7
            v6 = v5.v0
            v7 = v6 == 7
            if v7:
                return 0
            else:
                return 1
        case US0_Missing(): # Missing
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
