kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def method0(v0 : i32) -> string:
    v1 = v0 == 0
    if v1:
        v2 = "no"
        return v2
    else:
        v3 = "hi"
        return v3
def main():
    v0 = 7
    v1 = method0(v0)
    v2 = v1 == "hi"
    if v2:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
