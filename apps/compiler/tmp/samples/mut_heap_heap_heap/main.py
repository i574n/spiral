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
class Heap2(NamedTuple):
    v0 : Heap1
    v1 : i32
@dataclass
class Mut0:
    v0 : Heap2
def main():
    v0 = 3
    v1 = "no"
    v2 = Heap0(v0, v1)
    v3 = 1
    v4 = Heap1(v2, v3)
    v5 = 2
    v6 = Heap2(v4, v5)
    v7 = Mut0(v6)
    v8 = 7
    v9 = "hi"
    v10 = Heap0(v8, v9)
    v11 = 4
    v12 = Heap1(v10, v11)
    v13 = 5
    v14 = Heap2(v12, v13)
    v7.v0 = v14
    v15 = v7.v0
    v16, v17 = v15.v0, v15.v1
    v18, v19 = v16.v0, v16.v1
    v20, v21 = v18.v0, v18.v1
    v22 = v20 == 7
    if v22:
        v23 = v21 == "hi"
        v24 = v23
    else:
        v24 = False
    if v24:
        v25 = v19 == 4
        v26 = v25
    else:
        v26 = False
    if v26:
        v27 = v17 == 5
        v28 = v27
    else:
        v28 = False
    if v28:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
