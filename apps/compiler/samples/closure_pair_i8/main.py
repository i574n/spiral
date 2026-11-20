kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def f_c0(env_v0 : i8):
    def inner(v1 : i32) -> Tuple[i8, i8]:
        nonlocal env_v0
        v0 = env_v0
        v2 = v1 == 0
        if v2:
            del v0, v2
            return 0, 0
        else:
            del v2
            return v0, 7
    return inner
def main():
    v0 = 100
    v1 = f_c0(v0)
    v2, v3 = v1(1)
    v4 = v2 == 100
    if v4:
        v5 = v3 == 7
        v6 = v5
    else:
        v6 = False
    if v6:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
