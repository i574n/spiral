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
class US0_Empty(NamedTuple): # Empty
    tag = 0
class US0_Item(NamedTuple): # Item
    v0 : string
    v1 : i32
    tag = 1
US0 = Union[US0_Empty, US0_Item]
def closure0():
    def inner(v0 : i32) -> US0:
        v1 = v0 == 0
        if v1:
            del v1
            return US0_Empty()
        else:
            del v1
            v3 = "managed"
            return US0_Item(v3, 32)
    return inner
def method0(v0 : Callable[[i32], US0]) -> US0:
    return v0(0)
def method1(v0 : Callable[[i32], US0]) -> US0:
    return v0(1)
def main():
    v0 = closure0()
    v1 = method0(v0)
    match v1:
        case US0_Empty(): # Empty
            v7 = 3
        case US0_Item(v2, v3): # Item
            v4 = spiral_string_length(v2)
            del v2
            v5 = spiral_wrap(v4 + v3, 32, True)
            del v3, v4
            v7 = v5
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1
    v8 = method1(v0)
    del v0
    match v8:
        case US0_Empty(): # Empty
            v14 = 3
        case US0_Item(v9, v10): # Item
            v11 = spiral_string_length(v9)
            del v9
            v12 = spiral_wrap(v11 + v10, 32, True)
            del v10, v11
            v14 = v12
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v8
    v15 = spiral_wrap(v7 + v14, 32, True)
    del v7, v14
    return v15

if __name__ == '__main__': sys.exit(main())
