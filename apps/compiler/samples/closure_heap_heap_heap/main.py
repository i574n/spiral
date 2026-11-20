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
    v3 = 1
    v4 = Heap1(v2, v3)
    v5 = 2
    v6 = Heap2(v4, v5)
    v7 = f_c0(v6)
    v8 = v7(1)
    v9, v10 = v8.v0, v8.v1
    v11, v12 = v9.v0, v9.v1
    v13, v14 = v11.v0, v11.v1
    v15 = v13 == 7
    if v15:
        v16 = v14 == "hi"
        v17 = v16
    else:
        v17 = False
    if v17:
        v18 = v12 == 1
        v19 = v18
    else:
        v19 = False
    if v19:
        v20 = v10 == 2
        v21 = v20
    else:
        v21 = False
    if v21:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
