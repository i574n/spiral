kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

@dataclass
class Mut0:
    v0 : i32
def f_c0(env_v0 : Mut0):
    def inner(v1 : i32) -> Mut0:
        nonlocal env_v0
        v0 = env_v0
        return v0
    return inner
def main():
    v0 = Mut0(1)
    v1 = f_c0(v0)
    v2 = v1(1)
    v2.v0 = 7
    v3 = v2.v0
    v4 = v3 == 7
    if v4:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
