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
def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def left_c0(env_v0 : string, env_v1 : i32):
    def inner(v2 : i32) -> i32:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 > 0
        if v3:
            del v3
            v4 = spiral_string_length(v0)
            del v0
            v5 = spiral_wrap(v4 + v1, 32, True)
            del v1, v4
            v6 = spiral_wrap(v5 + v2, 32, True)
            del v5
            return v6
        else:
            del v0, v1, v3
            return 0
    return inner
def right_c1(env_v0 : string, env_v1 : i32):
    def inner(v2 : i32) -> i32:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v2 > 0
        if v3:
            del v3
            v4 = spiral_string_length(v0)
            del v0
            v5 = spiral_wrap(v4 + v1, 32, True)
            del v1, v4
            v6 = spiral_wrap(v5 + v2, 32, True)
            del v5
            v7 = spiral_wrap(v6 - 1, 32, True)
            del v6
            return v7
        else:
            del v0, v1, v3
            return -1
    return inner
def method0(v0 : Callable[[i32], i32]) -> i32:
    return v0(37)
def main():
    v0 = "abc"
    v1 = "wxyz"
    v2 = 2
    v3 = 2
    v4 = True
    if v4:
        v7 = left_c0(v0, v2)
    else:
        v7 = right_c1(v1, v3)
    return method0(v7)

if __name__ == '__main__': sys.exit(main())
