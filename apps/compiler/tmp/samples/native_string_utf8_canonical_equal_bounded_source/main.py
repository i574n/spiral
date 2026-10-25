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
def utf8_canonical_equal_bounded_loop_0(v0 : string, v1 : string, v2 : i32, v3 : i32, v4 : i32, v5 : i32, v6 : i32, v7 : i32) -> bool:
    while True:
        v8 = v4 >= 0
        if v8:
            v76, v77, v78 = v4, v2, -1
        else:
            v9 = v2 == v6
            if v9:
                del v9
                v76, v77, v78 = -1, v2, -1
            else:
                del v9
                v10 = v2 > v6
                if v10:
                    del v10
                    raise Exception("UTF-8 canonical stream offset exceeds the string.")
                else:
                    del v10
                    v14 = utf8_scalar_at_byte_offset_1(v0, v2)
                    v15 = v14 < 128
                    if v15:
                        v20 = 1
                    else:
                        v16 = v14 < 2048
                        if v16:
                            del v16
                            v20 = 2
                        else:
                            del v16
                            v17 = v14 < 65536
                            if v17:
                                del v17
                                v20 = 3
                            else:
                                del v17
                                v20 = 4
                    del v15
                    v21 = v14 == 192
                    if v21:
                        v67, v68 = 65, 768
                    else:
                        v22 = v14 == 193
                        if v22:
                            del v22
                            v67, v68 = 65, 769
                        else:
                            del v22
                            v23 = v14 == 195
                            if v23:
                                del v23
                                v67, v68 = 65, 771
                            else:
                                del v23
                                v24 = v14 == 196
                                if v24:
                                    del v24
                                    v67, v68 = 65, 776
                                else:
                                    del v24
                                    v25 = v14 == 199
                                    if v25:
                                        del v25
                                        v67, v68 = 67, 807
                                    else:
                                        del v25
                                        v26 = v14 == 201
                                        if v26:
                                            del v26
                                            v67, v68 = 69, 769
                                        else:
                                            del v26
                                            v27 = v14 == 211
                                            if v27:
                                                del v27
                                                v67, v68 = 79, 769
                                            else:
                                                del v27
                                                v28 = v14 == 213
                                                if v28:
                                                    del v28
                                                    v67, v68 = 79, 771
                                                else:
                                                    del v28
                                                    v29 = v14 == 224
                                                    if v29:
                                                        del v29
                                                        v67, v68 = 97, 768
                                                    else:
                                                        del v29
                                                        v30 = v14 == 225
                                                        if v30:
                                                            del v30
                                                            v67, v68 = 97, 769
                                                        else:
                                                            del v30
                                                            v31 = v14 == 227
                                                            if v31:
                                                                del v31
                                                                v67, v68 = 97, 771
                                                            else:
                                                                del v31
                                                                v32 = v14 == 228
                                                                if v32:
                                                                    del v32
                                                                    v67, v68 = 97, 776
                                                                else:
                                                                    del v32
                                                                    v33 = v14 == 231
                                                                    if v33:
                                                                        del v33
                                                                        v67, v68 = 99, 807
                                                                    else:
                                                                        del v33
                                                                        v34 = v14 == 233
                                                                        if v34:
                                                                            del v34
                                                                            v67, v68 = 101, 769
                                                                        else:
                                                                            del v34
                                                                            v35 = v14 == 243
                                                                            if v35:
                                                                                del v35
                                                                                v67, v68 = 111, 769
                                                                            else:
                                                                                del v35
                                                                                v36 = v14 == 245
                                                                                if v36:
                                                                                    del v36
                                                                                    v67, v68 = 111, 771
                                                                                else:
                                                                                    del v36
                                                                                    v67, v68 = v14, -1
                    del v14, v21
                    v69 = spiral_wrap(v2 + v20, 32, True)
                    del v20
                    v76, v77, v78 = v67, v69, v68
        del v2, v4, v8
        v79 = v5 >= 0
        if v79:
            v147, v148, v149 = v5, v3, -1
        else:
            v80 = v3 == v7
            if v80:
                del v80
                v147, v148, v149 = -1, v3, -1
            else:
                del v80
                v81 = v3 > v7
                if v81:
                    del v81
                    raise Exception("UTF-8 canonical stream offset exceeds the string.")
                else:
                    del v81
                    v85 = utf8_scalar_at_byte_offset_1(v1, v3)
                    v86 = v85 < 128
                    if v86:
                        v91 = 1
                    else:
                        v87 = v85 < 2048
                        if v87:
                            del v87
                            v91 = 2
                        else:
                            del v87
                            v88 = v85 < 65536
                            if v88:
                                del v88
                                v91 = 3
                            else:
                                del v88
                                v91 = 4
                    del v86
                    v92 = v85 == 192
                    if v92:
                        v138, v139 = 65, 768
                    else:
                        v93 = v85 == 193
                        if v93:
                            del v93
                            v138, v139 = 65, 769
                        else:
                            del v93
                            v94 = v85 == 195
                            if v94:
                                del v94
                                v138, v139 = 65, 771
                            else:
                                del v94
                                v95 = v85 == 196
                                if v95:
                                    del v95
                                    v138, v139 = 65, 776
                                else:
                                    del v95
                                    v96 = v85 == 199
                                    if v96:
                                        del v96
                                        v138, v139 = 67, 807
                                    else:
                                        del v96
                                        v97 = v85 == 201
                                        if v97:
                                            del v97
                                            v138, v139 = 69, 769
                                        else:
                                            del v97
                                            v98 = v85 == 211
                                            if v98:
                                                del v98
                                                v138, v139 = 79, 769
                                            else:
                                                del v98
                                                v99 = v85 == 213
                                                if v99:
                                                    del v99
                                                    v138, v139 = 79, 771
                                                else:
                                                    del v99
                                                    v100 = v85 == 224
                                                    if v100:
                                                        del v100
                                                        v138, v139 = 97, 768
                                                    else:
                                                        del v100
                                                        v101 = v85 == 225
                                                        if v101:
                                                            del v101
                                                            v138, v139 = 97, 769
                                                        else:
                                                            del v101
                                                            v102 = v85 == 227
                                                            if v102:
                                                                del v102
                                                                v138, v139 = 97, 771
                                                            else:
                                                                del v102
                                                                v103 = v85 == 228
                                                                if v103:
                                                                    del v103
                                                                    v138, v139 = 97, 776
                                                                else:
                                                                    del v103
                                                                    v104 = v85 == 231
                                                                    if v104:
                                                                        del v104
                                                                        v138, v139 = 99, 807
                                                                    else:
                                                                        del v104
                                                                        v105 = v85 == 233
                                                                        if v105:
                                                                            del v105
                                                                            v138, v139 = 101, 769
                                                                        else:
                                                                            del v105
                                                                            v106 = v85 == 243
                                                                            if v106:
                                                                                del v106
                                                                                v138, v139 = 111, 769
                                                                            else:
                                                                                del v106
                                                                                v107 = v85 == 245
                                                                                if v107:
                                                                                    del v107
                                                                                    v138, v139 = 111, 771
                                                                                else:
                                                                                    del v107
                                                                                    v138, v139 = v85, -1
                    del v85, v92
                    v140 = spiral_wrap(v3 + v91, 32, True)
                    del v91
                    v147, v148, v149 = v138, v140, v139
        del v3, v5, v79
        v150 = v76 < 0
        if v150:
            del v0, v1, v6, v7, v76, v77, v78, v148, v149, v150
            v151 = v147 == -1
            del v147
            return v151
        else:
            del v150
            v152 = v147 < 0
            if v152:
                del v0, v1, v6, v7, v76, v77, v78, v147, v148, v149, v152
                return False
            else:
                del v152
                v153 = v76 == v147
                del v76, v147
                if v153:
                    del v153
                    v0, v1, v2, v3, v4, v5, v6, v7 = v0, v1, v77, v148, v78, v149, v6, v7
                    continue
                else:
                    del v0, v1, v6, v7, v77, v78, v148, v149, v153
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
    del v0, v1, v2, v3, v4, v5, v6
    v8 = ""
    v9 = 0
    v10 = 0
    v11 = -1
    v12 = -1
    v13 = 0
    v14 = 0
    v15 = utf8_canonical_equal_bounded_loop_0(v8, v8, v9, v10, v11, v12, v13, v14)
    del v8, v9, v10, v11, v12, v13, v14
    v16 = "éõç"
    v17 = "éõç"
    v18 = 0
    v19 = 0
    v20 = -1
    v21 = -1
    v22 = 6
    v23 = 9
    v24 = utf8_canonical_equal_bounded_loop_0(v16, v17, v18, v19, v20, v21, v22, v23)
    del v16, v17, v18, v19, v20, v21, v22, v23
    v25 = "é̃"
    v26 = "é̃"
    v27 = 0
    v28 = 0
    v29 = -1
    v30 = -1
    v31 = 4
    v32 = 5
    v33 = utf8_canonical_equal_bounded_loop_0(v25, v26, v27, v28, v29, v30, v31, v32)
    del v25, v27, v28, v29, v30, v31, v32
    v34 = "À"
    v35 = "À"
    v36 = 0
    v37 = 0
    v38 = -1
    v39 = -1
    v40 = 2
    v41 = 3
    v42 = utf8_canonical_equal_bounded_loop_0(v34, v35, v36, v37, v38, v39, v40, v41)
    del v34, v35, v36, v37, v38, v39, v40, v41
    v43 = "Ω"
    v44 = 0
    v45 = 0
    v46 = -1
    v47 = -1
    v48 = 2
    v49 = 2
    v50 = utf8_canonical_equal_bounded_loop_0(v43, v43, v44, v45, v46, v47, v48, v49)
    del v44, v45, v46, v47, v48, v49
    v51 = "ẽ́"
    v52 = 0
    v53 = 0
    v54 = -1
    v55 = -1
    v56 = 5
    v57 = 5
    v58 = utf8_canonical_equal_bounded_loop_0(v26, v51, v52, v53, v54, v55, v56, v57)
    del v26, v51, v52, v53, v54, v55, v56, v57
    v59 = "é"
    v60 = "á"
    v61 = 0
    v62 = 0
    v63 = -1
    v64 = -1
    v65 = 2
    v66 = 2
    v67 = utf8_canonical_equal_bounded_loop_0(v59, v60, v61, v62, v63, v64, v65, v66)
    del v60, v61, v62, v63, v64, v65, v66
    v68 = "ω"
    v69 = 0
    v70 = 0
    v71 = -1
    v72 = -1
    v73 = 2
    v74 = 2
    v75 = utf8_canonical_equal_bounded_loop_0(v43, v68, v69, v70, v71, v72, v73, v74)
    del v43, v68, v69, v70, v71, v72, v73, v74
    v76 = "e"
    v77 = 0
    v78 = 0
    v79 = -1
    v80 = -1
    v81 = 2
    v82 = 1
    v83 = utf8_canonical_equal_bounded_loop_0(v59, v76, v77, v78, v79, v80, v81, v82)
    del v59, v76, v77, v78, v79, v80, v81, v82
    if v7:
        del v7
        if v15:
            del v15
            if v24:
                del v24
                if v33:
                    del v33
                    if v42:
                        del v42
                        if v50:
                            del v50
                            if v58:
                                del v58, v67, v75, v83
                                return 7
                            else:
                                del v58
                                if v67:
                                    del v67, v75, v83
                                    return 8
                                else:
                                    del v67
                                    if v75:
                                        del v75, v83
                                        return 9
                                    else:
                                        del v75
                                        if v83:
                                            del v83
                                            return 10
                                        else:
                                            del v83
                                            return 0
                        else:
                            del v50, v58, v67, v75, v83
                            return 6
                    else:
                        del v42, v50, v58, v67, v75, v83
                        return 5
                else:
                    del v33, v42, v50, v58, v67, v75, v83
                    return 4
            else:
                del v24, v33, v42, v50, v58, v67, v75, v83
                return 3
        else:
            del v15, v24, v33, v42, v50, v58, v67, v75, v83
            return 2
    else:
        del v7, v15, v24, v33, v42, v50, v58, v67, v75, v83
        return 1

if __name__ == '__main__': sys.exit(main())
