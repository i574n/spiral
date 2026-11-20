kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class US0_Living(NamedTuple): # Living
    v0 : i32
    v1 : i32
    tag = 0
US0 = US0_Living
class US2_Fallen(NamedTuple): # Fallen
    v0 : i32
    tag = 1
US2 = US2_Fallen
class US1_Survived(NamedTuple): # Survived
    v0 : US0
    tag = 0
class US1_Slain(NamedTuple): # Slain
    v0 : US2
    tag = 1
US1 = Union[US1_Survived, US1_Slain]
def main():
    v0 = 60
    v1 = v0 > 0
    if v1:
        v2 = US0_Living(v0, 100)
        v6 = US1_Survived(v2)
    else:
        v4 = US2_Fallen(100)
        v6 = US1_Slain(v4)
    match v6:
        case US1_Slain(_): # Slain
            return 2
        case US1_Survived(v7): # Survived
            match v7:
                case US0_Living(v8, _): # Living
                    v10 = v8 == 60
                    if v10:
                        return 0
                    else:
                        return 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
