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
    v0 : f32
    v1 : string
def main():
    v0 = 1.5
    v1 = "hi"
    v2 = Heap0(v0, v1)
    v3, v4 = v2.v0, v2.v1
    v5 = v3 == 1.5
    if v5:
        v6 = v4 == "hi"
        v7 = v6
    else:
        v7 = False
    if v7:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
