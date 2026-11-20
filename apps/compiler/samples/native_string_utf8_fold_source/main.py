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
def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
def runtime_byte_2(v0 : string, v1 : i32) -> char:
    v2 = spiral_string_index(v0, v1)
    return v2
def utf8_scalar_at_byte_offset_1(v0 : string, v1 : i32) -> i32:
    v2 = spiral_string_length(v0)
    v3 = v1 < 0
    if v3:
        raise Exception("UTF-8 byte offset is negative.")
    else:
        v5 = v1 >= v2
        if v5:
            raise Exception("UTF-8 byte offset is outside the string.")
        else:
            v7 = runtime_byte_2(v0, v1)
            v8 = ord(v7)
            v9 = v8 < 128
            if v9:
                return v8
            else:
                v10 = v8 < 194
                if v10:
                    raise Exception("UTF-8 scalar starts with an invalid lead byte.")
                else:
                    v12 = v8 < 224
                    if v12:
                        v13 = spiral_wrap(v1 + 1, 32, True)
                        v14 = v13 >= v2
                        if v14:
                            raise Exception("UTF-8 sequence is truncated.")
                        else:
                            v16 = runtime_byte_2(v0, v13)
                            v17 = ord(v16)
                            v18 = v17 < 128
                            if v18:
                                v20 = False
                            else:
                                v19 = v17 < 192
                                v20 = v19
                            if v20:
                                v21 = spiral_wrap(v8 - 192, 32, True)
                                v22 = spiral_wrap(v21 * 64, 32, True)
                                v23 = spiral_wrap(v17 - 128, 32, True)
                                v24 = spiral_wrap(v22 + v23, 32, True)
                                return v24
                            else:
                                raise Exception("UTF-8 sequence has an invalid continuation byte.")
                    else:
                        v28 = v8 < 240
                        if v28:
                            v29 = spiral_wrap(v1 + 2, 32, True)
                            v30 = v29 >= v2
                            if v30:
                                raise Exception("UTF-8 sequence is truncated.")
                            else:
                                v32 = spiral_wrap(v1 + 1, 32, True)
                                v33 = runtime_byte_2(v0, v32)
                                v34 = ord(v33)
                                v35 = runtime_byte_2(v0, v29)
                                v36 = ord(v35)
                                v37 = v34 < 128
                                if v37:
                                    v39 = False
                                else:
                                    v38 = v34 < 192
                                    v39 = v38
                                if v39:
                                    v40 = v36 < 128
                                    if v40:
                                        v42 = False
                                    else:
                                        v41 = v36 < 192
                                        v42 = v41
                                    if v42:
                                        v43 = spiral_wrap(v8 - 224, 32, True)
                                        v44 = spiral_wrap(v43 * 4096, 32, True)
                                        v45 = spiral_wrap(v34 - 128, 32, True)
                                        v46 = spiral_wrap(v45 * 64, 32, True)
                                        v47 = spiral_wrap(v44 + v46, 32, True)
                                        v48 = spiral_wrap(v36 - 128, 32, True)
                                        v49 = spiral_wrap(v47 + v48, 32, True)
                                        v50 = v49 < 2048
                                        if v50:
                                            raise Exception("UTF-8 sequence is overlong.")
                                        else:
                                            v52 = v49 >= 55296
                                            if v52:
                                                v53 = v49 <= 57343
                                                if v53:
                                                    raise Exception("UTF-8 sequence encodes a surrogate.")
                                                else:
                                                    return v49
                                            else:
                                                return v49
                                    else:
                                        raise Exception("UTF-8 sequence has an invalid continuation byte.")
                                else:
                                    raise Exception("UTF-8 sequence has an invalid continuation byte.")
                        else:
                            v63 = v8 < 245
                            if v63:
                                v64 = spiral_wrap(v1 + 3, 32, True)
                                v65 = v64 >= v2
                                if v65:
                                    raise Exception("UTF-8 sequence is truncated.")
                                else:
                                    v67 = spiral_wrap(v1 + 1, 32, True)
                                    v68 = runtime_byte_2(v0, v67)
                                    v69 = ord(v68)
                                    v70 = spiral_wrap(v1 + 2, 32, True)
                                    v71 = runtime_byte_2(v0, v70)
                                    v72 = ord(v71)
                                    v73 = runtime_byte_2(v0, v64)
                                    v74 = ord(v73)
                                    v75 = v69 < 128
                                    if v75:
                                        v77 = False
                                    else:
                                        v76 = v69 < 192
                                        v77 = v76
                                    if v77:
                                        v78 = v72 < 128
                                        if v78:
                                            v80 = False
                                        else:
                                            v79 = v72 < 192
                                            v80 = v79
                                        if v80:
                                            v81 = v74 < 128
                                            if v81:
                                                v83 = False
                                            else:
                                                v82 = v74 < 192
                                                v83 = v82
                                            if v83:
                                                v84 = spiral_wrap(v8 - 240, 32, True)
                                                v85 = spiral_wrap(v84 * 262144, 32, True)
                                                v86 = spiral_wrap(v69 - 128, 32, True)
                                                v87 = spiral_wrap(v86 * 4096, 32, True)
                                                v88 = spiral_wrap(v85 + v87, 32, True)
                                                v89 = spiral_wrap(v72 - 128, 32, True)
                                                v90 = spiral_wrap(v89 * 64, 32, True)
                                                v91 = spiral_wrap(v88 + v90, 32, True)
                                                v92 = spiral_wrap(v74 - 128, 32, True)
                                                v93 = spiral_wrap(v91 + v92, 32, True)
                                                v94 = v93 < 65536
                                                if v94:
                                                    raise Exception("UTF-8 sequence is overlong.")
                                                else:
                                                    v96 = v93 > 1114111
                                                    if v96:
                                                        raise Exception("UTF-8 scalar is above U+10FFFF.")
                                                    else:
                                                        return v93
                                            else:
                                                raise Exception("UTF-8 sequence has an invalid continuation byte.")
                                        else:
                                            raise Exception("UTF-8 sequence has an invalid continuation byte.")
                                    else:
                                        raise Exception("UTF-8 sequence has an invalid continuation byte.")
                            else:
                                raise Exception("UTF-8 scalar starts with an invalid lead byte.")
def loop_0(v0 : i32, v1 : i32, v2 : i32) -> Tuple[i32, i32]:
    while True:
        v3 = v0 == 10
        if v3:
            return v1, v2
        else:
            v4 = v0 > 10
            if v4:
                raise Exception("UTF-8 scalar width exceeds the string.")
            else:
                v7 = "Aéλ🙂Z"
                v8 = utf8_scalar_at_byte_offset_1(v7, v0)
                v9 = v8 < 128
                if v9:
                    v14 = 1
                else:
                    v10 = v8 < 2048
                    if v10:
                        v14 = 2
                    else:
                        v11 = v8 < 65536
                        if v11:
                            v14 = 3
                        else:
                            v14 = 4
                v15 = spiral_wrap(v0 + v14, 32, True)
                v16 = spiral_wrap(v1 + 1, 32, True)
                v17 = spiral_wrap(v2 * 3, 32, True)
                v18 = spiral_mod_trunc(v8, 17)
                v19 = spiral_wrap(v17 + v18, 32, True)
                v0, v1, v2 = v15, v16, v19
                continue
def loop_3(v0 : i32, v1 : i32, v2 : i32) -> Tuple[i32, i32]:
    while True:
        v3 = v0 == 0
        if v3:
            return v1, v2
        else:
            v4 = v0 > 0
            if v4:
                raise Exception("UTF-8 scalar width exceeds the string.")
            else:
                v7 = ""
                v8 = utf8_scalar_at_byte_offset_1(v7, v0)
                v9 = v8 < 128
                if v9:
                    v14 = 1
                else:
                    v10 = v8 < 2048
                    if v10:
                        v14 = 2
                    else:
                        v11 = v8 < 65536
                        if v11:
                            v14 = 3
                        else:
                            v14 = 4
                v15 = spiral_wrap(v0 + v14, 32, True)
                v16 = spiral_wrap(v1 + 1, 32, True)
                v17 = spiral_wrap(v2 * 3, 32, True)
                v18 = spiral_mod_trunc(v8, 17)
                v19 = spiral_wrap(v17 + v18, 32, True)
                v0, v1, v2 = v15, v16, v19
                continue
def main():
    v0 = 0
    v1 = 0
    v2 = 0
    v3, v4 = loop_0(v0, v1, v2)
    v5 = 0
    v6 = 0
    v7 = 0
    v8, v9 = loop_3(v5, v6, v7)
    v10 = 5
    v11 = 0
    v12 = 0
    v13, v14 = loop_0(v10, v11, v12)
    v15 = v3 == 5
    if v15:
        v16 = v4 == 1511
        if v16:
            v17 = v8 == 0
            if v17:
                v18 = v9 == 0
                if v18:
                    v19 = v13 == 2
                    if v19:
                        v20 = v14 == 26
                        if v20:
                            return 0
                        else:
                            return 6
                    else:
                        return 5
                else:
                    return 4
            else:
                return 3
        else:
            return 2
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
