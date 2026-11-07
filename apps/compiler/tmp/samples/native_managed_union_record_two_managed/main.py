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
def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
class US0_Empty(NamedTuple): # Empty
    tag = 0
US0_Empty_shared = US0_Empty()
class US0_Item(NamedTuple): # Item
    v0 : string
    v1 : cp.ndarray
    tag = 1
US0 = Union[US0_Empty, US0_Item]
def closure0():
    def inner(v0 : i32) -> US0:
        v1 = v0 == 0
        if v1:
            del v1
            return US0_Empty_shared
        else:
            del v1
            v3 = cp.zeros(2,dtype=cp.int32)
            v3[0] = v0
            v4 = spiral_wrap(v0 + 1, 32, True)
            v3[1] = v4
            del v4
            v5 = "hi"
            return US0_Item(v5, v3)
    return inner
def method0(v0 : Callable[[i32], US0]) -> US0:
    return v0(0)
def method1(v0 : Callable[[i32], US0]) -> US0:
    return v0(4)
def main():
    v0 = closure0()
    v1 = method0(v0)
    match v1:
        case US0_Empty(): # Empty
            v12 = 3
        case US0_Item(v2, v3): # Item
            v4 = spiral_string_length(v2)
            del v2
            v5 = v3.size
            v6 = spiral_wrap(v4 + v5, 32, True)
            del v4, v5
            v7 = spiral_array_index(v3, 0)
            v8 = spiral_wrap(v6 + v7, 32, True)
            del v6, v7
            v9 = spiral_array_index(v3, 1)
            del v3
            v10 = spiral_wrap(v8 + v9, 32, True)
            del v8, v9
            v12 = v10
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1
    v13 = method1(v0)
    del v0
    match v13:
        case US0_Empty(): # Empty
            v24 = 3
        case US0_Item(v14, v15): # Item
            v16 = spiral_string_length(v14)
            del v14
            v17 = v15.size
            v18 = spiral_wrap(v16 + v17, 32, True)
            del v16, v17
            v19 = spiral_array_index(v15, 0)
            v20 = spiral_wrap(v18 + v19, 32, True)
            del v18, v19
            v21 = spiral_array_index(v15, 1)
            del v15
            v22 = spiral_wrap(v20 + v21, 32, True)
            del v20, v21
            v24 = v22
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v13
    v25 = spiral_wrap(v12 + v24, 32, True)
    del v12, v24
    v26 = spiral_wrap(v25 + 26, 32, True)
    del v25
    return v26

if __name__ == '__main__': sys.exit(main())
