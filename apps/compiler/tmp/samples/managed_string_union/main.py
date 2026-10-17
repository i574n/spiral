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
def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
class US0_Text(NamedTuple): # Text
    v0 : string
    tag = 0
class US0_Number(NamedTuple): # Number
    v0 : i32
    tag = 1
US0 = Union[US0_Text, US0_Number]
def score_0(v0 : US0) -> i32:
    match v0:
        case US0_Number(v3): # Number
            del v0
            return v3
        case US0_Text(v1): # Text
            del v0
            v2 = spiral_string_length(v1)
            del v1
            return v2
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = False
    if v0:
        v4 = US0_Number(7)
    else:
        v2 = "qwe"
        v4 = US0_Text(v2)
    del v0
    v5 = score_0(v4)
    v6 = score_0(v4)
    del v4
    v7 = spiral_wrap(v5 + v6, 32, True)
    del v5, v6
    v8 = spiral_wrap(v7 - 6, 32, True)
    del v7
    return v8

if __name__ == '__main__': sys.exit(main())
