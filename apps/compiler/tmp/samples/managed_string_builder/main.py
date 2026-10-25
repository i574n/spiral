kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
import os
try: # CuPy when a CUDA device answers, otherwise numpy under the same name (SPIRAL_CUDA=0 forces numpy).
    if os.environ.get('SPIRAL_CUDA', '1') == '0': raise ImportError('SPIRAL_CUDA=0')
    import cupy as cp
    if cp.cuda.runtime.getDeviceCount() < 1: raise RuntimeError('no CUDA device')
    cuda = True
except Exception:
    import numpy as cp
    cuda = False
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
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
def method2(v0 : i32, v1 : string, v2 : string) -> string:
    while True:
        v3 = spiral_wrap(v0 - 1, 32, True)
        del v0
        v4 = v1 + v2
        del v1, v2
        v5 = v3 == 0
        if v5:
            del v3, v5
            return v4
        else:
            del v5
            v6 = spiral_mod_trunc(v3, 2)
            v7 = v6 == 0
            del v6
            if v7:
                v8 = "ab"
                v10 = v8
            else:
                v9 = "c"
                v10 = v9
            del v7
            v0, v1, v2 = v3, v4, v10
            continue
def method1(v0 : i32, v1 : string) -> string:
    v2 = spiral_wrap(v0 - 1, 32, True)
    del v0
    v3 = "" + v1
    del v1
    v4 = v2 == 0
    if v4:
        del v2, v4
        return v3
    else:
        del v4
        v5 = spiral_mod_trunc(v2, 2)
        v6 = v5 == 0
        del v5
        if v6:
            v7 = "ab"
            v9 = v7
        else:
            v8 = "c"
            v9 = v8
        del v6
        return method2(v2, v3, v9)
def method0() -> string:
    v0 = 4
    v1 = v0 == 0
    if v1:
        del v0, v1
        v2 = ""
        return v2
    else:
        del v1
        v3 = spiral_mod_trunc(v0, 2)
        v4 = v3 == 0
        del v3
        if v4:
            v5 = "ab"
            v7 = v5
        else:
            v6 = "c"
            v7 = v6
        del v4
        return method1(v0, v7)
def main():
    v0 = method0()
    v1 = spiral_string_length(v0)
    v2 = v1 == 6
    del v1
    if v2:
        del v2
        v3 = spiral_string_index(v0, 0)
        v4 = v3 == 'a'
        del v3
        if v4:
            del v4
            v5 = spiral_string_index(v0, 5)
            del v0
            v6 = v5 == 'c'
            del v5
            if v6:
                del v6
                return 0
            else:
                del v6
                return 1
        else:
            del v0, v4
            return 2
    else:
        del v0, v2
        return 3

if __name__ == '__main__': sys.exit(main())
