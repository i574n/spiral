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
def runtime_byte_0(v0 : string, v1 : i32) -> char:
    v2 = spiral_string_index(v0, v1)
    return v2
def codepoint_length_loop_1(v0 : string, v1 : char, v2 : char, v3 : i32, v4 : i32, v5 : i32) -> i32:
    while True:
        v6 = v3 == v5
        if v6:
            return v4
        else:
            v7 = spiral_string_index(v0, v3)
            v8 = v7 < v1
            if v8:
                v10 = False
            else:
                v9 = v7 < v2
                v10 = v9
            if v10:
                v12 = v4
            else:
                v11 = spiral_wrap(v4 + 1, 32, True)
                v12 = v11
            v13 = spiral_wrap(v3 + 1, 32, True)
            v0, v1, v2, v3, v4, v5 = v0, v1, v2, v13, v12, v5
            continue
def codepoint_byte_offset_loop_2(v0 : string, v1 : char, v2 : char, v3 : i32, v4 : i32, v5 : i32, v6 : i32) -> i32:
    while True:
        v7 = v4 == v6
        if v7:
            return v6
        else:
            v8 = spiral_string_index(v0, v4)
            v9 = v8 < v1
            if v9:
                v11 = False
            else:
                v10 = v8 < v2
                v11 = v10
            if v11:
                v12 = spiral_wrap(v4 + 1, 32, True)
                v0, v1, v2, v3, v4, v5, v6 = v0, v1, v2, v3, v12, v5, v6
                continue
            else:
                v14 = v5 == v3
                if v14:
                    return v4
                else:
                    v15 = spiral_wrap(v4 + 1, 32, True)
                    v16 = spiral_wrap(v5 + 1, 32, True)
                    v0, v1, v2, v3, v4, v5, v6 = v0, v1, v2, v3, v15, v16, v6
                    continue
def main():
    v0 = "À"
    v1 = 1
    v2 = runtime_byte_0(v0, v1)
    v3 = "©"
    v4 = 0
    v5 = runtime_byte_0(v3, v4)
    v6 = "Aéλ🙂Z"
    v7 = 0
    v8 = 0
    v9 = 10
    v10 = codepoint_length_loop_1(v6, v2, v5, v7, v8, v9)
    v11 = 1
    v12 = runtime_byte_0(v0, v11)
    v13 = 0
    v14 = runtime_byte_0(v3, v13)
    v15 = 1
    v16 = 0
    v17 = 0
    v18 = 10
    v19 = codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18)
    v20 = 1
    v21 = runtime_byte_0(v0, v20)
    v22 = 0
    v23 = runtime_byte_0(v3, v22)
    v24 = 2
    v25 = 0
    v26 = 0
    v27 = 10
    v28 = codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27)
    v29 = spiral_wrap(v28 - 1, 32, True)
    v30 = spiral_string_slice("Aéλ🙂Z", v19, v29)
    v31 = 1
    v32 = runtime_byte_0(v0, v31)
    v33 = 0
    v34 = runtime_byte_0(v3, v33)
    v35 = 3
    v36 = 0
    v37 = 0
    v38 = 10
    v39 = codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38)
    v40 = 1
    v41 = runtime_byte_0(v0, v40)
    v42 = 0
    v43 = runtime_byte_0(v3, v42)
    v44 = 4
    v45 = 0
    v46 = 0
    v47 = 10
    v48 = codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47)
    v49 = spiral_wrap(v48 - 1, 32, True)
    v50 = spiral_string_slice("Aéλ🙂Z", v39, v49)
    v51 = 1
    v52 = runtime_byte_0(v0, v51)
    v53 = 0
    v54 = runtime_byte_0(v3, v53)
    v55 = 1
    v56 = 0
    v57 = 0
    v58 = 10
    v59 = codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58)
    v60 = 1
    v61 = runtime_byte_0(v0, v60)
    v62 = 0
    v63 = runtime_byte_0(v3, v62)
    v64 = 4
    v65 = 0
    v66 = 0
    v67 = 10
    v68 = codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67)
    v69 = spiral_wrap(v68 - 1, 32, True)
    v70 = spiral_string_slice("Aéλ🙂Z", v59, v69)
    v71 = 1
    v72 = runtime_byte_0(v0, v71)
    v73 = 0
    v74 = runtime_byte_0(v3, v73)
    v75 = 3
    v76 = 0
    v77 = 0
    v78 = 10
    v79 = codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78)
    v80 = 0
    v81 = runtime_byte_0(v30, v80)
    v82 = "é"
    v83 = 0
    v84 = runtime_byte_0(v82, v83)
    v85 = 3
    v86 = runtime_byte_0(v50, v85)
    v87 = "🙂"
    v88 = 3
    v89 = runtime_byte_0(v87, v88)
    v90 = v10 == 5
    if v90:
        v91 = spiral_string_length(v30)
        v92 = v91 == 2
        if v92:
            v93 = v81 == v84
            if v93:
                v94 = spiral_string_length(v50)
                v95 = v94 == 4
                if v95:
                    v96 = v86 == v89
                    if v96:
                        v97 = spiral_string_length(v70)
                        v98 = v97 == 8
                        if v98:
                            v99 = v79 == 5
                            if v99:
                                return 0
                            else:
                                return 1
                        else:
                            return 2
                    else:
                        return 3
                else:
                    return 4
            else:
                return 5
        else:
            return 6
    else:
        return 7

if __name__ == '__main__': sys.exit(main())
