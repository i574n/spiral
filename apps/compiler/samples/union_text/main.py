kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class US0_Text(NamedTuple): # Text
    v0 : string
    tag = 0
class US0_Code(NamedTuple): # Code
    v0 : i32
    tag = 1
US0 = Union[US0_Text, US0_Code]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Code(v4): # Code
            return v4
        case US0_Text(v1): # Text
            v2 = v1 == "hi"
            if v2:
                return 2
            else:
                return 3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = True
    v1 = "hi"
    if v0:
        v4 = US0_Text(v1)
    else:
        v4 = US0_Code(1)
    if v0:
        v7 = US0_Code(5)
    else:
        v7 = US0_Text(v1)
    v8 = score_0(v4)
    v9 = v8 == 2
    if v9:
        v10 = score_0(v7)
        v11 = v10 == 5
        v12 = v11
    else:
        v12 = False
    if v12:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
