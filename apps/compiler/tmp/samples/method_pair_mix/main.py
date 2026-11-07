kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def method0(v0 : i32, v1 : string) -> Tuple[i32, string]:
    v2 = v0 == 0
    if v2:
        v3 = "no"
        return 0, v3
    else:
        return v0, v1
def main():
    v0 = 7
    v1 = "hi"
    v2, v3 = method0(v0, v1)
    v4 = v2 == 7
    if v4:
        v5 = v3 == "hi"
        v6 = v5
    else:
        v6 = False
    if v6:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
