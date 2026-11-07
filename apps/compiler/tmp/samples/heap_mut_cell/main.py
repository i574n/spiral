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
    v1 : string
class Heap0(NamedTuple):
    v0 : Mut0
def main():
    v0 = 3
    v1 = "no"
    v2 = Mut0(v0, v1)
    v3 = Heap0(v2)
    v4 = v3.v0
    v5 = 7
    v6 = "hi"
    v4.v0 = v5
    v4.v1 = v6
    v7, v8 = v4.v0, v4.v1
    v9 = v7 == 7
    if v9:
        v10 = v8 == "hi"
        v11 = v10
    else:
        v11 = False
    if v11:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
