kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def g_c1(env_v0 : string, env_v1 : i32):
    def inner(v2 : i32) -> string:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v1 == 0
        del v1
        if v3:
            del v0, v3
            v4 = "no"
            return v4
        else:
            del v3
            return v0
    return inner
def f_c0(env_v0 : string):
    def inner(v1 : i32) -> Callable[[i32], string]:
        nonlocal env_v0
        v0 = env_v0
        return g_c1(v0, v1)
    return inner
def main():
    v0 = "hi"
    v1 = f_c0(v0)
    v2 = v1(1)
    v3 = v2(0)
    v4 = v3 == "hi"
    if v4:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
