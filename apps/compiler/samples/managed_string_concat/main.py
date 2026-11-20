kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

import sys
def spiral_utf8(s):
    return s.encode('utf-8', 'surrogateescape')
def spiral_string_length(s):
    return len(s) if s.isascii() else len(spiral_utf8(s))
def spiral_string_index(s, i):
    return s[i] if s.isascii() else chr(spiral_utf8(s)[i])
def spiral_string_slice(s, a, b):
    data = s.encode('ascii') if s.isascii() else spiral_utf8(s)
    n = len(data)
    if a < 0 or a > n or b < a - 1 or b >= n: sys.exit(3)
    if b >= a and ((data[a] & 0xC0) == 0x80 or (b + 1 < n and (data[b + 1] & 0xC0) == 0x80)): sys.exit(3)
    return s[a:b + 1] if s.isascii() else data[a:b + 1].decode('utf-8', 'surrogateescape')
def choose_left_0(v0 : bool) -> string:
    if v0:
        v1 = "spi"
        return v1
    else:
        v2 = "bad"
        return v2
def choose_right_1(v0 : bool) -> string:
    if v0:
        v1 = "bad"
        return v1
    else:
        v2 = "ral"
        return v2
def main():
    v0 = True
    v1 = choose_left_0(v0)
    v2 = False
    v3 = choose_right_1(v2)
    v4 = v1 + v3
    v5 = spiral_string_length(v4)
    v6 = v5 == 6
    if v6:
        v7 = spiral_string_index(v4, 0)
        v8 = v7 == 's'
        if v8:
            v9 = spiral_string_index(v4, 5)
            v10 = v9 == 'l'
            if v10:
                return 0
            else:
                return 1
        else:
            return 2
    else:
        return 3

if __name__ == '__main__': sys.exit(main())
