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
    v0 : string
def method2(v0 : Mut0, v1 : string) -> None:
    v2 = v0.v0
    v3 = v2 + v1 
    v0.v0 = v3
    return 
def format_real_1(v0 : i32) -> string:
    v1 = ""
    v2 = Mut0(v1)
    v3 = f"{v0}"
    method2(v2, v3)
    v4 = v2.v0
    return v4
def method0() -> string:
    v0 = "Some"
    v1 = "("
    v2 = v0 + v1 
    v3 = 1
    v4 = format_real_1(v3)
    v5 = v2 + v4 
    v6 = ")"
    v7 = v5 + v6 
    return v7
def main():
    v0 = method0()
    v1 = "x: "
    v2 = v1 + v0 
    v3 = v2 == ""
    if v3:
        return 1
    else:
        return 0

if __name__ == '__main__': sys.exit(main())
