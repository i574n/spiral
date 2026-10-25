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
def runtime_byte_1(v0 : string, v1 : i32) -> char:
    v2 = spiral_string_index(v0, v1)
    del v0, v1
    return v2
def utf8_scalar_at_byte_offset_0(v0 : string, v1 : i32) -> i32:
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
            v7 = runtime_byte_1(v0, v1)
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
                            v16 = runtime_byte_1(v0, v13)
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
                                v33 = runtime_byte_1(v0, v32)
                                del v32
                                v34 = ord(v33)
                                del v33
                                v35 = runtime_byte_1(v0, v29)
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
                                    v68 = runtime_byte_1(v0, v67)
                                    del v67
                                    v69 = ord(v68)
                                    del v68
                                    v70 = spiral_wrap(v1 + 2, 32, True)
                                    del v1
                                    v71 = runtime_byte_1(v0, v70)
                                    del v70
                                    v72 = ord(v71)
                                    del v71
                                    v73 = runtime_byte_1(v0, v64)
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
def main():
    v0 = "é"
    v1 = 0
    v2 = utf8_scalar_at_byte_offset_0(v0, v1)
    del v0, v1
    v3 = "õ"
    v4 = 0
    v5 = utf8_scalar_at_byte_offset_0(v3, v4)
    del v3, v4
    v6 = "ç"
    v7 = 0
    v8 = utf8_scalar_at_byte_offset_0(v6, v7)
    del v6, v7
    v9 = "́"
    v10 = 0
    v11 = utf8_scalar_at_byte_offset_0(v9, v10)
    del v9, v10
    v12 = "̃"
    v13 = 0
    v14 = utf8_scalar_at_byte_offset_0(v12, v13)
    del v12, v13
    v15 = "̧"
    v16 = 0
    v17 = utf8_scalar_at_byte_offset_0(v15, v16)
    del v15, v16
    v18 = v2 == 192
    if v18:
        v64, v65 = 65, 768
    else:
        v19 = v2 == 193
        if v19:
            del v19
            v64, v65 = 65, 769
        else:
            del v19
            v20 = v2 == 195
            if v20:
                del v20
                v64, v65 = 65, 771
            else:
                del v20
                v21 = v2 == 196
                if v21:
                    del v21
                    v64, v65 = 65, 776
                else:
                    del v21
                    v22 = v2 == 199
                    if v22:
                        del v22
                        v64, v65 = 67, 807
                    else:
                        del v22
                        v23 = v2 == 201
                        if v23:
                            del v23
                            v64, v65 = 69, 769
                        else:
                            del v23
                            v24 = v2 == 211
                            if v24:
                                del v24
                                v64, v65 = 79, 769
                            else:
                                del v24
                                v25 = v2 == 213
                                if v25:
                                    del v25
                                    v64, v65 = 79, 771
                                else:
                                    del v25
                                    v26 = v2 == 224
                                    if v26:
                                        del v26
                                        v64, v65 = 97, 768
                                    else:
                                        del v26
                                        v27 = v2 == 225
                                        if v27:
                                            del v27
                                            v64, v65 = 97, 769
                                        else:
                                            del v27
                                            v28 = v2 == 227
                                            if v28:
                                                del v28
                                                v64, v65 = 97, 771
                                            else:
                                                del v28
                                                v29 = v2 == 228
                                                if v29:
                                                    del v29
                                                    v64, v65 = 97, 776
                                                else:
                                                    del v29
                                                    v30 = v2 == 231
                                                    if v30:
                                                        del v30
                                                        v64, v65 = 99, 807
                                                    else:
                                                        del v30
                                                        v31 = v2 == 233
                                                        if v31:
                                                            del v31
                                                            v64, v65 = 101, 769
                                                        else:
                                                            del v31
                                                            v32 = v2 == 243
                                                            if v32:
                                                                del v32
                                                                v64, v65 = 111, 769
                                                            else:
                                                                del v32
                                                                v33 = v2 == 245
                                                                if v33:
                                                                    del v33
                                                                    v64, v65 = 111, 771
                                                                else:
                                                                    del v33
                                                                    v64, v65 = v2, -1
    del v18
    v66 = v5 == 192
    if v66:
        v112, v113 = 65, 768
    else:
        v67 = v5 == 193
        if v67:
            del v67
            v112, v113 = 65, 769
        else:
            del v67
            v68 = v5 == 195
            if v68:
                del v68
                v112, v113 = 65, 771
            else:
                del v68
                v69 = v5 == 196
                if v69:
                    del v69
                    v112, v113 = 65, 776
                else:
                    del v69
                    v70 = v5 == 199
                    if v70:
                        del v70
                        v112, v113 = 67, 807
                    else:
                        del v70
                        v71 = v5 == 201
                        if v71:
                            del v71
                            v112, v113 = 69, 769
                        else:
                            del v71
                            v72 = v5 == 211
                            if v72:
                                del v72
                                v112, v113 = 79, 769
                            else:
                                del v72
                                v73 = v5 == 213
                                if v73:
                                    del v73
                                    v112, v113 = 79, 771
                                else:
                                    del v73
                                    v74 = v5 == 224
                                    if v74:
                                        del v74
                                        v112, v113 = 97, 768
                                    else:
                                        del v74
                                        v75 = v5 == 225
                                        if v75:
                                            del v75
                                            v112, v113 = 97, 769
                                        else:
                                            del v75
                                            v76 = v5 == 227
                                            if v76:
                                                del v76
                                                v112, v113 = 97, 771
                                            else:
                                                del v76
                                                v77 = v5 == 228
                                                if v77:
                                                    del v77
                                                    v112, v113 = 97, 776
                                                else:
                                                    del v77
                                                    v78 = v5 == 231
                                                    if v78:
                                                        del v78
                                                        v112, v113 = 99, 807
                                                    else:
                                                        del v78
                                                        v79 = v5 == 233
                                                        if v79:
                                                            del v79
                                                            v112, v113 = 101, 769
                                                        else:
                                                            del v79
                                                            v80 = v5 == 243
                                                            if v80:
                                                                del v80
                                                                v112, v113 = 111, 769
                                                            else:
                                                                del v80
                                                                v81 = v5 == 245
                                                                if v81:
                                                                    del v81
                                                                    v112, v113 = 111, 771
                                                                else:
                                                                    del v81
                                                                    v112, v113 = v5, -1
    del v66
    v114 = v8 == 192
    if v114:
        v160, v161 = 65, 768
    else:
        v115 = v8 == 193
        if v115:
            del v115
            v160, v161 = 65, 769
        else:
            del v115
            v116 = v8 == 195
            if v116:
                del v116
                v160, v161 = 65, 771
            else:
                del v116
                v117 = v8 == 196
                if v117:
                    del v117
                    v160, v161 = 65, 776
                else:
                    del v117
                    v118 = v8 == 199
                    if v118:
                        del v118
                        v160, v161 = 67, 807
                    else:
                        del v118
                        v119 = v8 == 201
                        if v119:
                            del v119
                            v160, v161 = 69, 769
                        else:
                            del v119
                            v120 = v8 == 211
                            if v120:
                                del v120
                                v160, v161 = 79, 769
                            else:
                                del v120
                                v121 = v8 == 213
                                if v121:
                                    del v121
                                    v160, v161 = 79, 771
                                else:
                                    del v121
                                    v122 = v8 == 224
                                    if v122:
                                        del v122
                                        v160, v161 = 97, 768
                                    else:
                                        del v122
                                        v123 = v8 == 225
                                        if v123:
                                            del v123
                                            v160, v161 = 97, 769
                                        else:
                                            del v123
                                            v124 = v8 == 227
                                            if v124:
                                                del v124
                                                v160, v161 = 97, 771
                                            else:
                                                del v124
                                                v125 = v8 == 228
                                                if v125:
                                                    del v125
                                                    v160, v161 = 97, 776
                                                else:
                                                    del v125
                                                    v126 = v8 == 231
                                                    if v126:
                                                        del v126
                                                        v160, v161 = 99, 807
                                                    else:
                                                        del v126
                                                        v127 = v8 == 233
                                                        if v127:
                                                            del v127
                                                            v160, v161 = 101, 769
                                                        else:
                                                            del v127
                                                            v128 = v8 == 243
                                                            if v128:
                                                                del v128
                                                                v160, v161 = 111, 769
                                                            else:
                                                                del v128
                                                                v129 = v8 == 245
                                                                if v129:
                                                                    del v129
                                                                    v160, v161 = 111, 771
                                                                else:
                                                                    del v129
                                                                    v160, v161 = v8, -1
    del v114
    v162 = v11 == 769
    if v162:
        v163 = 233
    else:
        v163 = -1
    del v162
    v164 = v163 < 0
    if v164:
        v165, v166 = 101, v11
    else:
        v165, v166 = v163, -1
    del v163, v164
    v167 = v14 == 769
    if v167:
        v170 = 243
    else:
        v168 = v14 == 771
        if v168:
            del v168
            v170 = 245
        else:
            del v168
            v170 = -1
    del v167
    v171 = v170 < 0
    if v171:
        v172, v173 = 111, v14
    else:
        v172, v173 = v170, -1
    del v170, v171
    v174 = v17 == 807
    if v174:
        v175 = 231
    else:
        v175 = -1
    del v174
    v176 = v175 < 0
    if v176:
        v177, v178 = 99, v17
    else:
        v177, v178 = v175, -1
    del v175, v176
    v179 = v64 == 101
    del v64
    if v179:
        v180 = v65 == v11
        v181 = v180
    else:
        v181 = False
    del v11, v65, v179
    if v181:
        del v181
        v182 = v112 == 111
        del v112
        if v182:
            v183 = v113 == v14
            v184 = v183
        else:
            v184 = False
        del v14, v113, v182
        if v184:
            del v184
            v185 = v160 == 99
            del v160
            if v185:
                v186 = v161 == v17
                v187 = v186
            else:
                v187 = False
            del v17, v161, v185
            if v187:
                del v187
                v188 = v165 == v2
                del v2, v165
                if v188:
                    v189 = v166 == -1
                    v190 = v189
                else:
                    v190 = False
                del v166, v188
                if v190:
                    del v190
                    v191 = v172 == v5
                    del v5, v172
                    if v191:
                        v192 = v173 == -1
                        v193 = v192
                    else:
                        v193 = False
                    del v173, v191
                    if v193:
                        del v193
                        v194 = v177 == v8
                        del v8, v177
                        if v194:
                            v195 = v178 == -1
                            v196 = v195
                        else:
                            v196 = False
                        del v178, v194
                        if v196:
                            del v196
                            return 0
                        else:
                            del v196
                            return 6
                    else:
                        del v8, v177, v178, v193
                        return 5
                else:
                    del v5, v8, v172, v173, v177, v178, v190
                    return 4
            else:
                del v2, v5, v8, v165, v166, v172, v173, v177, v178, v187
                return 3
        else:
            del v2, v5, v8, v17, v160, v161, v165, v166, v172, v173, v177, v178, v184
            return 2
    else:
        del v2, v5, v8, v14, v17, v112, v113, v160, v161, v165, v166, v172, v173, v177, v178, v181
        return 1

if __name__ == '__main__': sys.exit(main())
