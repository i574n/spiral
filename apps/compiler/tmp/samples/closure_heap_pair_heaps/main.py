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
def f_c0(env_v0 : Heap2):
    def inner(v1 : i32) -> Heap2:
        nonlocal env_v0
        v0 = env_v0
        return v0
    return inner
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
    v9 = f_c0(v8)
    v10 = v9(1)
    v11, v12 = v10.v0, v10.v1
    v13, v14 = v11.v0, v11.v1
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
        v26 = v12 == 2
        v27 = v26
    else:
        v27 = False
    if v27:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
