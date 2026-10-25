kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def method1(v0 : i32, v1 : u32, v2 : f32) -> Tuple[i32, u32, f32]:
    return v0, v1, v2
def method0(v0 : i32, v1 : u32, v2 : f32) -> i32:
    v3, v4, v5 = method1(v0, v1, v2)
    v6 = v3 == 2
    if v6:
        v7 = v4 == 3
        v8 = v7
    else:
        v8 = False
    if v8:
        v9 = v5 == 1.5
        v10 = v9
    else:
        v10 = False
    if v10:
        return 0
    else:
        return 1
def main():
    v0 = 2
    v1 = 3
    v2 = 1.5
    return method0(v0, v1, v2)

if __name__ == '__main__': sys.exit(main())
