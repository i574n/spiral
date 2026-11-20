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
def f_c0(env_v0 : Heap0, env_v1 : Heap0):
    def inner(v2 : i32) -> Tuple[Heap0, Heap0]:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        return v0, v1
    return inner
def main():
    v0 = 7
    v1 = "hi"
    v2 = Heap0(v0, v1)
    v3 = 4
    v4 = "yo"
    v5 = Heap0(v3, v4)
    v6 = f_c0(v2, v5)
    v7, v8 = v6(1)
    v9, v10 = v7.v0, v7.v1
    v11, v12 = v8.v0, v8.v1
    v13 = v9 == 7
    if v13:
        v14 = v10 == "hi"
        v15 = v14
    else:
        v15 = False
    if v15:
        v16 = v11 == 4
        v17 = v16
    else:
        v17 = False
    if v17:
        v18 = v12 == "yo"
        v19 = v18
    else:
        v19 = False
    if v19:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
