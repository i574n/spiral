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
    v1 : string
class Heap1(NamedTuple):
    v0 : Heap0
    v1 : i32
@dataclass
class Mut0:
    v0 : Heap1
def main():
    v0 = 3
    v1 = "no"
    v2 = Heap0(v0, v1)
    v3 = 1
    v4 = Heap1(v2, v3)
    v5 = Mut0(v4)
    v6 = 7
    v7 = "hi"
    v8 = Heap0(v6, v7)
    v9 = 4
    v10 = Heap1(v8, v9)
    v5.v0 = v10
    v11 = v5.v0
    v12, v13 = v11.v0, v11.v1
    v14, v15 = v12.v0, v12.v1
    v16 = v14 == 7
    if v16:
        v17 = v15 == "hi"
        v18 = v17
    else:
        v18 = False
    if v18:
        v19 = v13 == 4
        v20 = v19
    else:
        v20 = False
    if v20:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
