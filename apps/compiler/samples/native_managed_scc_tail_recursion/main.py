kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
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
def method2(v0 : i32, v1 : string) -> i32:
    v2 = spiral_wrap(v0 - 1, 32, True)
    v3 = v2 == 0
    if v3:
        v4 = spiral_string_length(v1)
        return v4
    else:
        return method1(v2, v1)
def method1(v0 : i32, v1 : string) -> i32:
    v2 = spiral_wrap(v0 - 1, 32, True)
    v3 = v2 == 0
    if v3:
        return 99
    else:
        return method2(v2, v1)
def method0(v0 : i32, v1 : string) -> i32:
    v2 = v0 == 0
    if v2:
        v3 = spiral_string_length(v1)
        v5 = v3
    else:
        v5 = method1(v0, v1)
    v6 = spiral_wrap(v5 - 2, 32, True)
    return v6
def main():
    v0 = 1000000
    v1 = spiral_mod_trunc(v0, 2)
    v2 = v1 == 0
    if v2:
        v3 = "ok"
        v5 = v3
    else:
        v4 = "go"
        v5 = v4
    return method0(v0, v5)

if __name__ == '__main__': sys.exit(main())
