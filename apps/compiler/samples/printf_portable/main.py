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
    v0 = 60
    v1 = -9000000000
    v2 = 200
    v3 = "cube"
    print(v3, ": ", v0, " frames, checksum ", 970392, "\n", sep='', end='')
    print("big ", v1, ", small ", -5, ", byte ", v2, "\n", sep='', end='')
    print("100% {braces} \"quoted\" \\ tab\tend\n", end='')
    print("literal", "\n", sep='', end='')
    print(v3, end='')
    print("\n", end='')
    return 0

if __name__ == '__main__': sys.exit(main())
