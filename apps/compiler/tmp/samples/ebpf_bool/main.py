kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def method0(v0 : bool) -> i32:
    if v0:
        return 1
    else:
        return 3
def method1(v0 : bool, v1 : bool) -> i32:
    v2 = v0 and v1
    if v2:
        return 1
    else:
        v3 = v0 or v1
        if v3:
            return 2
        else:
            return 3
def method2(v0 : bool) -> i32:
    if v0:
        return 1
    else:
        return 3
def main():
    v0 = True
    v1 = False
    v2 = method0(v0)
    v3 = method1(v0, v1)
    v4 = method2(v1)
    v5 = v0 == v1
    v6 = v5 == False
    v7 = v2 == 1
    if v7:
        v8 = v3 == 2
        v9 = v8
    else:
        v9 = False
    if v9:
        v10 = v4 == 3
        v11 = v10
    else:
        v11 = False
    v12 = v11 and v6
    if v12:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
