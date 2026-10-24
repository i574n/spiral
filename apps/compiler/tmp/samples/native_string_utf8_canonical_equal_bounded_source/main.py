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
def utf8_canonical_equal_bounded_loop_0(v0 : string, v1 : string, v2 : i32, v3 : i32, v4 : i32, v5 : i32, v6 : i32, v7 : i32) -> bool:
    while True:
        v8 = v4 >= 0
        if v8:
            v76, v77, v78 = v4, v2, -1
        else:
            v9 = v2 == v6
            if v9:
                v76, v77, v78 = -1, v2, -1
            else:
                v10 = v2 > v6
                if v10:
                    raise Exception("UTF-8 canonical stream offset exceeds the string.")
                else:
                    v14 = utf8_scalar_at_byte_offset_1(v0, v2)
                    v15 = v14 < 128
                    if v15:
                        v20 = 1
                    else:
                        v16 = v14 < 2048
                        if v16:
                            v20 = 2
                        else:
                            v17 = v14 < 65536
                            if v17:
                                v20 = 3
                            else:
                                v20 = 4
                    v21 = v14 == 192
                    if v21:
                        v67, v68 = 65, 768
                    else:
                        v22 = v14 == 193
                        if v22:
                            v67, v68 = 65, 769
                        else:
                            v23 = v14 == 195
                            if v23:
                                v67, v68 = 65, 771
                            else:
                                v24 = v14 == 196
                                if v24:
                                    v67, v68 = 65, 776
                                else:
                                    v25 = v14 == 199
                                    if v25:
                                        v67, v68 = 67, 807
                                    else:
                                        v26 = v14 == 201
                                        if v26:
                                            v67, v68 = 69, 769
                                        else:
                                            v27 = v14 == 211
                                            if v27:
                                                v67, v68 = 79, 769
                                            else:
                                                v28 = v14 == 213
                                                if v28:
                                                    v67, v68 = 79, 771
                                                else:
                                                    v29 = v14 == 224
                                                    if v29:
                                                        v67, v68 = 97, 768
                                                    else:
                                                        v30 = v14 == 225
                                                        if v30:
                                                            v67, v68 = 97, 769
                                                        else:
                                                            v31 = v14 == 227
                                                            if v31:
                                                                v67, v68 = 97, 771
                                                            else:
                                                                v32 = v14 == 228
                                                                if v32:
                                                                    v67, v68 = 97, 776
                                                                else:
                                                                    v33 = v14 == 231
                                                                    if v33:
                                                                        v67, v68 = 99, 807
                                                                    else:
                                                                        v34 = v14 == 233
                                                                        if v34:
                                                                            v67, v68 = 101, 769
                                                                        else:
                                                                            v35 = v14 == 243
                                                                            if v35:
                                                                                v67, v68 = 111, 769
                                                                            else:
                                                                                v36 = v14 == 245
                                                                                if v36:
                                                                                    v67, v68 = 111, 771
                                                                                else:
                                                                                    v67, v68 = v14, -1
                    v69 = spiral_wrap(v2 + v20, 32, True)
                    v76, v77, v78 = v67, v69, v68
        v79 = v5 >= 0
        if v79:
            v147, v148, v149 = v5, v3, -1
        else:
            v80 = v3 == v7
            if v80:
                v147, v148, v149 = -1, v3, -1
            else:
                v81 = v3 > v7
                if v81:
                    raise Exception("UTF-8 canonical stream offset exceeds the string.")
                else:
                    v85 = utf8_scalar_at_byte_offset_1(v1, v3)
                    v86 = v85 < 128
                    if v86:
                        v91 = 1
                    else:
                        v87 = v85 < 2048
                        if v87:
                            v91 = 2
                        else:
                            v88 = v85 < 65536
                            if v88:
                                v91 = 3
                            else:
                                v91 = 4
                    v92 = v85 == 192
                    if v92:
                        v138, v139 = 65, 768
                    else:
                        v93 = v85 == 193
                        if v93:
                            v138, v139 = 65, 769
                        else:
                            v94 = v85 == 195
                            if v94:
                                v138, v139 = 65, 771
                            else:
                                v95 = v85 == 196
                                if v95:
                                    v138, v139 = 65, 776
                                else:
                                    v96 = v85 == 199
                                    if v96:
                                        v138, v139 = 67, 807
                                    else:
                                        v97 = v85 == 201
                                        if v97:
                                            v138, v139 = 69, 769
                                        else:
                                            v98 = v85 == 211
                                            if v98:
                                                v138, v139 = 79, 769
                                            else:
                                                v99 = v85 == 213
                                                if v99:
                                                    v138, v139 = 79, 771
                                                else:
                                                    v100 = v85 == 224
                                                    if v100:
                                                        v138, v139 = 97, 768
                                                    else:
                                                        v101 = v85 == 225
                                                        if v101:
                                                            v138, v139 = 97, 769
                                                        else:
                                                            v102 = v85 == 227
                                                            if v102:
                                                                v138, v139 = 97, 771
                                                            else:
                                                                v103 = v85 == 228
                                                                if v103:
                                                                    v138, v139 = 97, 776
                                                                else:
                                                                    v104 = v85 == 231
                                                                    if v104:
                                                                        v138, v139 = 99, 807
                                                                    else:
                                                                        v105 = v85 == 233
                                                                        if v105:
                                                                            v138, v139 = 101, 769
                                                                        else:
                                                                            v106 = v85 == 243
                                                                            if v106:
                                                                                v138, v139 = 111, 769
                                                                            else:
                                                                                v107 = v85 == 245
                                                                                if v107:
                                                                                    v138, v139 = 111, 771
                                                                                else:
                                                                                    v138, v139 = v85, -1
                    v140 = spiral_wrap(v3 + v91, 32, True)
                    v147, v148, v149 = v138, v140, v139
        v150 = v76 < 0
        if v150:
            v151 = v147 == -1
            return v151
        else:
            v152 = v147 < 0
            if v152:
                return False
            else:
                v153 = v76 == v147
                if v153:
                    v0, v1, v2, v3, v4, v5, v6, v7 = v0, v1, v77, v148, v78, v149, v6, v7
                    continue
                else:
                    return False
def main():
    v0 = "plain"
    v1 = 0
    v2 = 0
    v3 = -1
    v4 = -1
    v5 = 5
    v6 = 5
    v7 = utf8_canonical_equal_bounded_loop_0(v0, v0, v1, v2, v3, v4, v5, v6)
    v8 = ""
    v9 = 0
    v10 = 0
    v11 = -1
    v12 = -1
    v13 = 0
    v14 = 0
    v15 = utf8_canonical_equal_bounded_loop_0(v8, v8, v9, v10, v11, v12, v13, v14)
    v16 = "éõç"
    v17 = "éõç"
    v18 = 0
    v19 = 0
    v20 = -1
    v21 = -1
    v22 = 6
    v23 = 9
    v24 = utf8_canonical_equal_bounded_loop_0(v16, v17, v18, v19, v20, v21, v22, v23)
    v25 = "é̃"
    v26 = "é̃"
    v27 = 0
    v28 = 0
    v29 = -1
    v30 = -1
    v31 = 4
    v32 = 5
    v33 = utf8_canonical_equal_bounded_loop_0(v25, v26, v27, v28, v29, v30, v31, v32)
    v34 = "À"
    v35 = "À"
    v36 = 0
    v37 = 0
    v38 = -1
    v39 = -1
    v40 = 2
    v41 = 3
    v42 = utf8_canonical_equal_bounded_loop_0(v34, v35, v36, v37, v38, v39, v40, v41)
    v43 = "Ω"
    v44 = 0
    v45 = 0
    v46 = -1
    v47 = -1
    v48 = 2
    v49 = 2
    v50 = utf8_canonical_equal_bounded_loop_0(v43, v43, v44, v45, v46, v47, v48, v49)
    v51 = "ẽ́"
    v52 = 0
    v53 = 0
    v54 = -1
    v55 = -1
    v56 = 5
    v57 = 5
    v58 = utf8_canonical_equal_bounded_loop_0(v26, v51, v52, v53, v54, v55, v56, v57)
    v59 = "é"
    v60 = "á"
    v61 = 0
    v62 = 0
    v63 = -1
    v64 = -1
    v65 = 2
    v66 = 2
    v67 = utf8_canonical_equal_bounded_loop_0(v59, v60, v61, v62, v63, v64, v65, v66)
    v68 = "ω"
    v69 = 0
    v70 = 0
    v71 = -1
    v72 = -1
    v73 = 2
    v74 = 2
    v75 = utf8_canonical_equal_bounded_loop_0(v43, v68, v69, v70, v71, v72, v73, v74)
    v76 = "e"
    v77 = 0
    v78 = 0
    v79 = -1
    v80 = -1
    v81 = 2
    v82 = 1
    v83 = utf8_canonical_equal_bounded_loop_0(v59, v76, v77, v78, v79, v80, v81, v82)
    if v7:
        if v15:
            if v24:
                if v33:
                    if v42:
                        if v50:
                            if v58:
                                return 7
                            else:
                                if v67:
                                    return 8
                                else:
                                    if v75:
                                        return 9
                                    else:
                                        if v83:
                                            return 10
                                        else:
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
