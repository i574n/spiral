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
    v0 : string
def main():
    v0 = "hi"
    v1 = Heap0(v0)
    v2 = v1.v0
    v3 = v2 == "hi"
    if v3:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
