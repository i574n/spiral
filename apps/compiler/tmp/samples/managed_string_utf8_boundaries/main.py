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
def first_codepoint_0(v0 : string) -> string:
    v1 = spiral_string_slice(v0, 0, 1)
    del v0
    return v1
def second_codepoint_1(v0 : string) -> string:
    v1 = spiral_string_slice(v0, 2, 3)
    del v0
    return v1
def main():
    v0 = "éλ"
    v1 = first_codepoint_0(v0)
    v2 = second_codepoint_1(v0)
    del v0
    v3 = v1 + v2
    v4 = spiral_string_length(v1)
    del v1
    v5 = v4 == 2
    del v4
    if v5:
        del v5
        v6 = spiral_string_length(v2)
        del v2
        v7 = v6 == 2
        del v6
        if v7:
            del v7
            v8 = spiral_string_length(v3)
            del v3
            v9 = v8 == 4
            del v8
            if v9:
                del v9
                return 0
            else:
                del v9
                return 1
        else:
            del v3, v7
            return 2
    else:
        del v2, v3, v5
        return 3

if __name__ == '__main__': sys.exit(main())
