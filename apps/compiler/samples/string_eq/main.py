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
def main():
    v0 = "é"
    v1 = "x"
    v2 = v0 + v1
    v3 = "éx"
    v4 = "éy"
    v5 = ""
    v6 = spiral_string_slice(v3, 1, 0)
    v7 = v2 == v3
    if v7:
        v8 = v2 != v4
        v9 = v8
    else:
        v9 = False
    if v9:
        v10 = v0 != v3
        v11 = v10
    else:
        v11 = False
    if v11:
        v12 = v5 == v6
        v13 = v12
    else:
        v13 = False
    if v13:
        v14 = v5 != v0
        v15 = v14
    else:
        v15 = False
    if v15:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
