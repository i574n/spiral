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
def f_c0(env_v0 : Heap1):
    def inner(v1 : i32) -> Heap1:
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
    v5 = f_c0(v4)
    v6 = v5(1)
    v7, v8 = v6.v0, v6.v1
    v9, v10 = v7.v0, v7.v1
    v11 = v9 == 7
    if v11:
        v12 = v10 == "hi"
        v13 = v12
    else:
        v13 = False
    if v13:
        v14 = v8 == 1
        v15 = v14
    else:
        v15 = False
    if v15:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
