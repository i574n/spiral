kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class US0_None(NamedTuple): # None
    tag = 0
US0_None_shared = US0_None()
class US0_Some(NamedTuple): # Some
    v0 : i32
    tag = 1
US0 = Union[US0_None, US0_Some]
def method0(v0 : i32) -> Tuple[US0, US0]:
    v1 = v0 == 0
    if v1:
        v2 = US0_None_shared
        v3 = US0_None_shared
        return v2, v3
    else:
        v4 = US0_Some(v0)
        v5 = US0_None_shared
        return v4, v5
def main():
    v0 = 7
    v1, v2 = method0(v0)
    match v1:
        case US0_None(): # None
            return 1
        case US0_Some(v3): # Some
            match v2:
                case US0_None(): # None
                    v4 = v3 == 7
                    if v4:
                        return 0
                    else:
                        return 1
                case US0_Some(_): # Some
                    return 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
