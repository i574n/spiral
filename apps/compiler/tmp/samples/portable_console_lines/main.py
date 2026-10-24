kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def main():
    v0 = "hello"
    print(v0)
    v1 = 42
    print(v1)
    v2 = "a"
    print(v2, end="")
    v3 = "b"
    print(v3, end="")
    v4 = ""
    print(v4)
    v5 = -7
    print(v5)
    return 0

if __name__ == '__main__': sys.exit(main())
