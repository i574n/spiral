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
def f_c0(env_v0 : Heap0):
    def inner(v1 : i32) -> Heap0:
        nonlocal env_v0
        v0 = env_v0
        return v0
    return inner
def main():
    v0 = 1.5
    v1 = "hi"
    v2 = Heap0(v0, v1)
    v3 = f_c0(v2)
    v4 = v3(1)
    v5, v6 = v4.v0, v4.v1
    v7 = v5 == 1.5
    if v7:
        v8 = v6 == "hi"
        v9 = v8
    else:
        v9 = False
    if v9:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
