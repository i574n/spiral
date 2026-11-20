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
def runtime_byte_1(v0 : string, v1 : i32) -> char:
    v2 = spiral_string_index(v0, v1)
    return v2
def utf8_scalar_at_byte_offset_0(v0 : string, v1 : i32) -> i32:
    v2 = spiral_string_length(v0)
    v3 = v1 < 0
    if v3:
        raise Exception("UTF-8 byte offset is negative.")
    else:
        v5 = v1 >= v2
        if v5:
            raise Exception("UTF-8 byte offset is outside the string.")
        else:
            v7 = runtime_byte_1(v0, v1)
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
                            v16 = runtime_byte_1(v0, v13)
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
                                v33 = runtime_byte_1(v0, v32)
                                v34 = ord(v33)
                                v35 = runtime_byte_1(v0, v29)
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
                                    v68 = runtime_byte_1(v0, v67)
                                    v69 = ord(v68)
                                    v70 = spiral_wrap(v1 + 2, 32, True)
                                    v71 = runtime_byte_1(v0, v70)
                                    v72 = ord(v71)
                                    v73 = runtime_byte_1(v0, v64)
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
def main():
    v0 = "é"
    v1 = 0
    v2 = utf8_scalar_at_byte_offset_0(v0, v1)
    v3 = "õ"
    v4 = 0
    v5 = utf8_scalar_at_byte_offset_0(v3, v4)
    v6 = "ç"
    v7 = 0
    v8 = utf8_scalar_at_byte_offset_0(v6, v7)
    v9 = "́"
    v10 = 0
    v11 = utf8_scalar_at_byte_offset_0(v9, v10)
    v12 = "̃"
    v13 = 0
    v14 = utf8_scalar_at_byte_offset_0(v12, v13)
    v15 = "̧"
    v16 = 0
    v17 = utf8_scalar_at_byte_offset_0(v15, v16)
    v18 = v2 == 192
    if v18:
        v64, v65 = 65, 768
    else:
        v19 = v2 == 193
        if v19:
            v64, v65 = 65, 769
        else:
            v20 = v2 == 195
            if v20:
                v64, v65 = 65, 771
            else:
                v21 = v2 == 196
                if v21:
                    v64, v65 = 65, 776
                else:
                    v22 = v2 == 199
                    if v22:
                        v64, v65 = 67, 807
                    else:
                        v23 = v2 == 201
                        if v23:
                            v64, v65 = 69, 769
                        else:
                            v24 = v2 == 211
                            if v24:
                                v64, v65 = 79, 769
                            else:
                                v25 = v2 == 213
                                if v25:
                                    v64, v65 = 79, 771
                                else:
                                    v26 = v2 == 224
                                    if v26:
                                        v64, v65 = 97, 768
                                    else:
                                        v27 = v2 == 225
                                        if v27:
                                            v64, v65 = 97, 769
                                        else:
                                            v28 = v2 == 227
                                            if v28:
                                                v64, v65 = 97, 771
                                            else:
                                                v29 = v2 == 228
                                                if v29:
                                                    v64, v65 = 97, 776
                                                else:
                                                    v30 = v2 == 231
                                                    if v30:
                                                        v64, v65 = 99, 807
                                                    else:
                                                        v31 = v2 == 233
                                                        if v31:
                                                            v64, v65 = 101, 769
                                                        else:
                                                            v32 = v2 == 243
                                                            if v32:
                                                                v64, v65 = 111, 769
                                                            else:
                                                                v33 = v2 == 245
                                                                if v33:
                                                                    v64, v65 = 111, 771
                                                                else:
                                                                    v64, v65 = v2, -1
    v66 = v5 == 192
    if v66:
        v112, v113 = 65, 768
    else:
        v67 = v5 == 193
        if v67:
            v112, v113 = 65, 769
        else:
            v68 = v5 == 195
            if v68:
                v112, v113 = 65, 771
            else:
                v69 = v5 == 196
                if v69:
                    v112, v113 = 65, 776
                else:
                    v70 = v5 == 199
                    if v70:
                        v112, v113 = 67, 807
                    else:
                        v71 = v5 == 201
                        if v71:
                            v112, v113 = 69, 769
                        else:
                            v72 = v5 == 211
                            if v72:
                                v112, v113 = 79, 769
                            else:
                                v73 = v5 == 213
                                if v73:
                                    v112, v113 = 79, 771
                                else:
                                    v74 = v5 == 224
                                    if v74:
                                        v112, v113 = 97, 768
                                    else:
                                        v75 = v5 == 225
                                        if v75:
                                            v112, v113 = 97, 769
                                        else:
                                            v76 = v5 == 227
                                            if v76:
                                                v112, v113 = 97, 771
                                            else:
                                                v77 = v5 == 228
                                                if v77:
                                                    v112, v113 = 97, 776
                                                else:
                                                    v78 = v5 == 231
                                                    if v78:
                                                        v112, v113 = 99, 807
                                                    else:
                                                        v79 = v5 == 233
                                                        if v79:
                                                            v112, v113 = 101, 769
                                                        else:
                                                            v80 = v5 == 243
                                                            if v80:
                                                                v112, v113 = 111, 769
                                                            else:
                                                                v81 = v5 == 245
                                                                if v81:
                                                                    v112, v113 = 111, 771
                                                                else:
                                                                    v112, v113 = v5, -1
    v114 = v8 == 192
    if v114:
        v160, v161 = 65, 768
    else:
        v115 = v8 == 193
        if v115:
            v160, v161 = 65, 769
        else:
            v116 = v8 == 195
            if v116:
                v160, v161 = 65, 771
            else:
                v117 = v8 == 196
                if v117:
                    v160, v161 = 65, 776
                else:
                    v118 = v8 == 199
                    if v118:
                        v160, v161 = 67, 807
                    else:
                        v119 = v8 == 201
                        if v119:
                            v160, v161 = 69, 769
                        else:
                            v120 = v8 == 211
                            if v120:
                                v160, v161 = 79, 769
                            else:
                                v121 = v8 == 213
                                if v121:
                                    v160, v161 = 79, 771
                                else:
                                    v122 = v8 == 224
                                    if v122:
                                        v160, v161 = 97, 768
                                    else:
                                        v123 = v8 == 225
                                        if v123:
                                            v160, v161 = 97, 769
                                        else:
                                            v124 = v8 == 227
                                            if v124:
                                                v160, v161 = 97, 771
                                            else:
                                                v125 = v8 == 228
                                                if v125:
                                                    v160, v161 = 97, 776
                                                else:
                                                    v126 = v8 == 231
                                                    if v126:
                                                        v160, v161 = 99, 807
                                                    else:
                                                        v127 = v8 == 233
                                                        if v127:
                                                            v160, v161 = 101, 769
                                                        else:
                                                            v128 = v8 == 243
                                                            if v128:
                                                                v160, v161 = 111, 769
                                                            else:
                                                                v129 = v8 == 245
                                                                if v129:
                                                                    v160, v161 = 111, 771
                                                                else:
                                                                    v160, v161 = v8, -1
    v162 = v11 == 769
    if v162:
        v163 = 233
    else:
        v163 = -1
    v164 = v163 < 0
    if v164:
        v165, v166 = 101, v11
    else:
        v165, v166 = v163, -1
    v167 = v14 == 769
    if v167:
        v170 = 243
    else:
        v168 = v14 == 771
        if v168:
            v170 = 245
        else:
            v170 = -1
    v171 = v170 < 0
    if v171:
        v172, v173 = 111, v14
    else:
        v172, v173 = v170, -1
    v174 = v17 == 807
    if v174:
        v175 = 231
    else:
        v175 = -1
    v176 = v175 < 0
    if v176:
        v177, v178 = 99, v17
    else:
        v177, v178 = v175, -1
    v179 = v64 == 101
    if v179:
        v180 = v65 == v11
        v181 = v180
    else:
        v181 = False
    if v181:
        v182 = v112 == 111
        if v182:
            v183 = v113 == v14
            v184 = v183
        else:
            v184 = False
        if v184:
            v185 = v160 == 99
            if v185:
                v186 = v161 == v17
                v187 = v186
            else:
                v187 = False
            if v187:
                v188 = v165 == v2
                if v188:
                    v189 = v166 == -1
                    v190 = v189
                else:
                    v190 = False
                if v190:
                    v191 = v172 == v5
                    if v191:
                        v192 = v173 == -1
                        v193 = v192
                    else:
                        v193 = False
                    if v193:
                        v194 = v177 == v8
                        if v194:
                            v195 = v178 == -1
                            v196 = v195
                        else:
                            v196 = False
                        if v196:
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
