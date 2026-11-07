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
    v0 : string
    v1 : string
def main():
    v0 = "no"
    v1 = "nay"
    v2 = Mut0(v0, v1)
    v3 = "hi"
    v4 = "yo"
    v2.v0 = v3
    v2.v1 = v4
    v5, v6 = v2.v0, v2.v1
    v7 = v5 == "hi"
    if v7:
        v8 = v6 == "yo"
        v9 = v8
    else:
        v9 = False
    if v9:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
