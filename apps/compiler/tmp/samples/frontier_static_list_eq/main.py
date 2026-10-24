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
    v0 = 'x'
    v1 = v0 == ' '
    if v1:
        v3 = True
    else:
        v2 = v0 == '/'
        v3 = v2
    if v3:
        return 1
    else:
        return 0

if __name__ == '__main__': sys.exit(main())
