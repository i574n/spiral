kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def method0(v0 : string, v1 : string) -> Tuple[string, string]:
    v2 = v0 == ""
    if v2:
        v3 = "no"
        v4 = "nay"
        return v3, v4
    else:
        return v0, v1
def main():
    v0 = "hi"
    v1 = "yo"
    v2, v3 = method0(v0, v1)
    v4 = v2 == "hi"
    if v4:
        v5 = v3 == "yo"
        v6 = v5
    else:
        v6 = False
    if v6:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
