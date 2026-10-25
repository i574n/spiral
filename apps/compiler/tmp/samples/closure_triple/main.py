kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def f_c0(env_v0 : i32, env_v1 : string, env_v2 : bool):
    def inner(v3 : i32) -> Tuple[i32, string, bool]:
        nonlocal env_v0, env_v1, env_v2
        v0 = env_v0; v1 = env_v1; v2 = env_v2
        v4 = v3 == 0
        if v4:
            del v0, v1, v2, v4
            v5 = "no"
            return 0, v5, False
        else:
            del v4
            return v0, v1, v2
    return inner
def main():
    v0 = 7
    v1 = "hi"
    v2 = True
    v3 = f_c0(v0, v1, v2)
    v4, v5, v6 = v3(1)
    v7 = v4 == 7
    if v7:
        v8 = v5 == "hi"
        v9 = v8
    else:
        v9 = False
    v10 = v9 and v6
    if v10:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
