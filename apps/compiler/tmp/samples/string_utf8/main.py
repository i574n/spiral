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
def main():
    v0 = "é"
    v1 = spiral_string_length(v0)
    v2 = spiral_string_index(v0, 0)
    v3 = spiral_string_index(v0, 1)
    v4 = "x"
    v5 = v0 + v4
    del v4
    v6 = spiral_string_length(v5)
    del v5
    v7 = "ab"
    v8 = spiral_string_index(v7, 0)
    v9 = spiral_string_slice(v7, 0, 0)
    v10 = spiral_string_length(v9)
    del v9
    v11 = spiral_string_slice(v7, 1, 0)
    del v7
    v12 = spiral_string_length(v11)
    del v11
    v13 = spiral_string_slice(v0, 0, 1)
    del v0
    v14 = spiral_string_length(v13)
    del v13
    v15 = v2 == v3
    del v2, v3
    if v15:
        del v1, v6, v8, v10, v12, v14, v15
        return 1
    else:
        del v15
        v16 = v1 == 2
        del v1
        if v16:
            v17 = v8 == 'a'
            v18 = v17
        else:
            v18 = False
        del v8, v16
        if v18:
            v19 = v6 == 3
            v20 = v19
        else:
            v20 = False
        del v6, v18
        if v20:
            v21 = v10 == 1
            v22 = v21
        else:
            v22 = False
        del v10, v20
        if v22:
            v23 = v12 == 0
            v24 = v23
        else:
            v24 = False
        del v12, v22
        if v24:
            v25 = v14 == 2
            v26 = v25
        else:
            v26 = False
        del v14, v24
        if v26:
            del v26
            return 0
        else:
            del v26
            return 1

if __name__ == '__main__': sys.exit(main())
