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
def runtime_byte_2(v0 : string, v1 : i32) -> char:
    v2 = spiral_string_index(v0, v1)
    del v0, v1
    return v2
def utf8_scalar_at_byte_offset_1(v0 : string, v1 : i32) -> i32:
    v2 = spiral_string_length(v0)
    v3 = v1 < 0
    if v3:
        del v0, v1, v2, v3
        raise Exception("UTF-8 byte offset is negative.")
    else:
        del v3
        v5 = v1 >= v2
        if v5:
            del v0, v1, v2, v5
            raise Exception("UTF-8 byte offset is outside the string.")
        else:
            del v5
            v7 = runtime_byte_2(v0, v1)
            v8 = ord(v7)
            del v7
            v9 = v8 < 128
            if v9:
                del v0, v1, v2, v9
                return v8
            else:
                del v9
                v10 = v8 < 194
                if v10:
                    del v0, v1, v2, v8, v10
                    raise Exception("UTF-8 scalar starts with an invalid lead byte.")
                else:
                    del v10
                    v12 = v8 < 224
                    if v12:
                        del v12
                        v13 = spiral_wrap(v1 + 1, 32, True)
                        del v1
                        v14 = v13 >= v2
                        del v2
                        if v14:
                            del v0, v8, v13, v14
                            raise Exception("UTF-8 sequence is truncated.")
                        else:
                            del v14
                            v16 = runtime_byte_2(v0, v13)
                            del v0, v13
                            v17 = ord(v16)
                            del v16
                            v18 = v17 < 128
                            if v18:
                                v20 = False
                            else:
                                v19 = v17 < 192
                                v20 = v19
                            del v18
                            if v20:
                                del v20
                                v21 = spiral_wrap(v8 - 192, 32, True)
                                del v8
                                v22 = spiral_wrap(v21 * 64, 32, True)
                                del v21
                                v23 = spiral_wrap(v17 - 128, 32, True)
                                del v17
                                v24 = spiral_wrap(v22 + v23, 32, True)
                                del v22, v23
                                return v24
                            else:
                                del v8, v17, v20
                                raise Exception("UTF-8 sequence has an invalid continuation byte.")
                    else:
                        del v12
                        v28 = v8 < 240
                        if v28:
                            del v28
                            v29 = spiral_wrap(v1 + 2, 32, True)
                            v30 = v29 >= v2
                            del v2
                            if v30:
                                del v0, v1, v8, v29, v30
                                raise Exception("UTF-8 sequence is truncated.")
                            else:
                                del v30
                                v32 = spiral_wrap(v1 + 1, 32, True)
                                del v1
                                v33 = runtime_byte_2(v0, v32)
                                del v32
                                v34 = ord(v33)
                                del v33
                                v35 = runtime_byte_2(v0, v29)
                                del v0, v29
                                v36 = ord(v35)
                                del v35
                                v37 = v34 < 128
                                if v37:
                                    v39 = False
                                else:
                                    v38 = v34 < 192
                                    v39 = v38
                                del v37
                                if v39:
                                    del v39
                                    v40 = v36 < 128
                                    if v40:
                                        v42 = False
                                    else:
                                        v41 = v36 < 192
                                        v42 = v41
                                    del v40
                                    if v42:
                                        del v42
                                        v43 = spiral_wrap(v8 - 224, 32, True)
                                        del v8
                                        v44 = spiral_wrap(v43 * 4096, 32, True)
                                        del v43
                                        v45 = spiral_wrap(v34 - 128, 32, True)
                                        del v34
                                        v46 = spiral_wrap(v45 * 64, 32, True)
                                        del v45
                                        v47 = spiral_wrap(v44 + v46, 32, True)
                                        del v44, v46
                                        v48 = spiral_wrap(v36 - 128, 32, True)
                                        del v36
                                        v49 = spiral_wrap(v47 + v48, 32, True)
                                        del v47, v48
                                        v50 = v49 < 2048
                                        if v50:
                                            del v49, v50
                                            raise Exception("UTF-8 sequence is overlong.")
                                        else:
                                            del v50
                                            v52 = v49 >= 55296
                                            if v52:
                                                del v52
                                                v53 = v49 <= 57343
                                                if v53:
                                                    del v49, v53
                                                    raise Exception("UTF-8 sequence encodes a surrogate.")
                                                else:
                                                    del v53
                                                    return v49
                                            else:
                                                del v52
                                                return v49
                                    else:
                                        del v8, v34, v36, v42
                                        raise Exception("UTF-8 sequence has an invalid continuation byte.")
                                else:
                                    del v8, v34, v36, v39
                                    raise Exception("UTF-8 sequence has an invalid continuation byte.")
                        else:
                            del v28
                            v63 = v8 < 245
                            if v63:
                                del v63
                                v64 = spiral_wrap(v1 + 3, 32, True)
                                v65 = v64 >= v2
                                del v2
                                if v65:
                                    del v0, v1, v8, v64, v65
                                    raise Exception("UTF-8 sequence is truncated.")
                                else:
                                    del v65
                                    v67 = spiral_wrap(v1 + 1, 32, True)
                                    v68 = runtime_byte_2(v0, v67)
                                    del v67
                                    v69 = ord(v68)
                                    del v68
                                    v70 = spiral_wrap(v1 + 2, 32, True)
                                    del v1
                                    v71 = runtime_byte_2(v0, v70)
                                    del v70
                                    v72 = ord(v71)
                                    del v71
                                    v73 = runtime_byte_2(v0, v64)
                                    del v0, v64
                                    v74 = ord(v73)
                                    del v73
                                    v75 = v69 < 128
                                    if v75:
                                        v77 = False
                                    else:
                                        v76 = v69 < 192
                                        v77 = v76
                                    del v75
                                    if v77:
                                        del v77
                                        v78 = v72 < 128
                                        if v78:
                                            v80 = False
                                        else:
                                            v79 = v72 < 192
                                            v80 = v79
                                        del v78
                                        if v80:
                                            del v80
                                            v81 = v74 < 128
                                            if v81:
                                                v83 = False
                                            else:
                                                v82 = v74 < 192
                                                v83 = v82
                                            del v81
                                            if v83:
                                                del v83
                                                v84 = spiral_wrap(v8 - 240, 32, True)
                                                del v8
                                                v85 = spiral_wrap(v84 * 262144, 32, True)
                                                del v84
                                                v86 = spiral_wrap(v69 - 128, 32, True)
                                                del v69
                                                v87 = spiral_wrap(v86 * 4096, 32, True)
                                                del v86
                                                v88 = spiral_wrap(v85 + v87, 32, True)
                                                del v85, v87
                                                v89 = spiral_wrap(v72 - 128, 32, True)
                                                del v72
                                                v90 = spiral_wrap(v89 * 64, 32, True)
                                                del v89
                                                v91 = spiral_wrap(v88 + v90, 32, True)
                                                del v88, v90
                                                v92 = spiral_wrap(v74 - 128, 32, True)
                                                del v74
                                                v93 = spiral_wrap(v91 + v92, 32, True)
                                                del v91, v92
                                                v94 = v93 < 65536
                                                if v94:
                                                    del v93, v94
                                                    raise Exception("UTF-8 sequence is overlong.")
                                                else:
                                                    del v94
                                                    v96 = v93 > 1114111
                                                    if v96:
                                                        del v93, v96
                                                        raise Exception("UTF-8 scalar is above U+10FFFF.")
                                                    else:
                                                        del v96
                                                        return v93
                                            else:
                                                del v8, v69, v72, v74, v83
                                                raise Exception("UTF-8 sequence has an invalid continuation byte.")
                                        else:
                                            del v8, v69, v72, v74, v80
                                            raise Exception("UTF-8 sequence has an invalid continuation byte.")
                                    else:
                                        del v8, v69, v72, v74, v77
                                        raise Exception("UTF-8 sequence has an invalid continuation byte.")
                            else:
                                del v0, v1, v2, v8, v63
                                raise Exception("UTF-8 scalar starts with an invalid lead byte.")
def loop_0(v0 : i32, v1 : i32) -> i32:
    while True:
        v2 = v0 == 2
        if v2:
            del v0, v2
            return v1
        else:
            del v2
            v3 = v0 > 2
            if v3:
                del v0, v1, v3
                raise Exception("UTF-8 scalar width exceeds the string.")
            else:
                del v3
                v5 = "é"
                v6 = utf8_scalar_at_byte_offset_1(v5, v0)
                del v5
                v7 = v6 < 128
                if v7:
                    v12 = 1
                else:
                    v8 = v6 < 2048
                    if v8:
                        del v8
                        v12 = 2
                    else:
                        del v8
                        v9 = v6 < 65536
                        if v9:
                            del v9
                            v12 = 3
                        else:
                            del v9
                            v12 = 4
                del v7
                v13 = spiral_wrap(v0 + v12, 32, True)
                del v0, v12
                v14 = spiral_wrap(v1 + v6, 32, True)
                del v1, v6
                v0, v1 = v13, v14
                continue
def main():
    v0 = 1
    v1 = 0
    return loop_0(v0, v1)

if __name__ == '__main__': sys.exit(main())
