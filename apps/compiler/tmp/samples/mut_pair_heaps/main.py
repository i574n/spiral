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
@dataclass
class Mut0:
    v0 : Heap0
    v1 : Heap0
def main():
    v0 = 1
    v1 = "no"
    v2 = Heap0(v0, v1)
    v3 = 2
    v4 = "zz"
    v5 = Heap0(v3, v4)
    v6 = Mut0(v2, v5)
    v7 = 7
    v8 = "hi"
    v9 = Heap0(v7, v8)
    v10 = 4
    v11 = "yo"
    v12 = Heap0(v10, v11)
    v6.v0 = v9
    v6.v1 = v12
    v13, v14 = v6.v0, v6.v1
    v15, v16 = v13.v0, v13.v1
    v17, v18 = v14.v0, v14.v1
    v19 = v15 == 7
    if v19:
        v20 = v16 == "hi"
        v21 = v20
    else:
        v21 = False
    if v21:
        v22 = v17 == 4
        v23 = v22
    else:
        v23 = False
    if v23:
        v24 = v18 == "yo"
        v25 = v24
    else:
        v25 = False
    if v25:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
