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
    v1 : Heap0
class Heap2(NamedTuple):
    v0 : Heap1
    v1 : i32
def main():
    v0 = 7
    v1 = "hi"
    v2 = Heap0(v0, v1)
    v3 = 4
    v4 = "yo"
    v5 = Heap0(v3, v4)
    v6 = Heap1(v2, v5)
    v7 = 2
    v8 = Heap2(v6, v7)
    v9, v10 = v8.v0, v8.v1
    v11, v12 = v9.v0, v9.v1
    v13, v14 = v11.v0, v11.v1
    v15, v16 = v12.v0, v12.v1
    v17 = v13 == 7
    if v17:
        v18 = v14 == "hi"
        v19 = v18
    else:
        v19 = False
    if v19:
        v20 = v15 == 4
        v21 = v20
    else:
        v21 = False
    if v21:
        v22 = v16 == "yo"
        v23 = v22
    else:
        v23 = False
    if v23:
        v24 = v10 == 2
        v25 = v24
    else:
        v25 = False
    if v25:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
