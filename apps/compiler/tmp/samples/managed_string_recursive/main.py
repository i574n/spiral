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
UH0 = Union["UH0_Empty", "UH0_Node"]
class UH0_Empty(NamedTuple): # Empty
    tag = 0
class UH0_Node(NamedTuple): # Node
    v0 : string
    v1 : UH0
    v2 : UH0
    tag = 1
def score_0(v0 : UH0) -> i32:
    match v0:
        case UH0_Empty(): # Empty
            del v0
            return 0
        case UH0_Node(v1, v2, v3): # Node
            del v0
            v4 = spiral_string_length(v1)
            del v1
            v5 = score_0(v2)
            del v2
            v6 = spiral_wrap(v4 + v5, 32, True)
            del v4, v5
            v7 = score_0(v3)
            del v3
            v8 = spiral_wrap(v6 + v7, 32, True)
            del v6, v7
            return v8
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = "ab"
    v1 = "qwe"
    v2 = UH0_Empty()
    v3 = UH0_Node(v1, v2, v2)
    del v2
    v4 = UH0_Node(v0, v3, v3)
    del v3
    v5 = score_0(v4)
    del v4
    v6 = UH0_Empty()
    v7 = UH0_Node(v1, v6, v6)
    del v1, v6
    v8 = UH0_Node(v0, v7, v7)
    del v0, v7
    v9 = score_0(v8)
    del v8
    v10 = spiral_wrap(v5 + v9, 32, True)
    del v5, v9
    v11 = spiral_wrap(v10 - 16, 32, True)
    del v10
    return v11

if __name__ == '__main__': sys.exit(main())
