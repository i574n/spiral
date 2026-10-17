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
def runtime_byte_0(v0 : string, v1 : i32) -> char:
    v2 = spiral_string_index(v0, v1)
    del v0, v1
    return v2
def codepoint_length_loop_1(v0 : string, v1 : char, v2 : char, v3 : i32, v4 : i32, v5 : i32) -> i32:
    while True:
        v6 = v3 == v5
        if v6:
            del v0, v1, v2, v3, v5, v6
            return v4
        else:
            del v6
            v7 = spiral_string_index(v0, v3)
            v8 = v7 < v1
            if v8:
                v10 = False
            else:
                v9 = v7 < v2
                v10 = v9
            del v7, v8
            if v10:
                v12 = v4
            else:
                v11 = spiral_wrap(v4 + 1, 32, True)
                v12 = v11
            del v4, v10
            v13 = spiral_wrap(v3 + 1, 32, True)
            del v3
            v0, v1, v2, v3, v4, v5 = v0, v1, v2, v13, v12, v5
            continue
def codepoint_byte_offset_loop_2(v0 : string, v1 : char, v2 : char, v3 : i32, v4 : i32, v5 : i32, v6 : i32) -> i32:
    while True:
        v7 = v4 == v6
        if v7:
            del v0, v1, v2, v3, v4, v5, v7
            return v6
        else:
            del v7
            v8 = spiral_string_index(v0, v4)
            v9 = v8 < v1
            if v9:
                v11 = False
            else:
                v10 = v8 < v2
                v11 = v10
            del v8, v9
            if v11:
                del v11
                v12 = spiral_wrap(v4 + 1, 32, True)
                del v4
                v0, v1, v2, v3, v4, v5, v6 = v0, v1, v2, v3, v12, v5, v6
                continue
            else:
                del v11
                v14 = v5 == v3
                if v14:
                    del v0, v1, v2, v3, v5, v6, v14
                    return v4
                else:
                    del v14
                    v15 = spiral_wrap(v4 + 1, 32, True)
                    del v4
                    v16 = spiral_wrap(v5 + 1, 32, True)
                    del v5
                    v0, v1, v2, v3, v4, v5, v6 = v0, v1, v2, v3, v15, v16, v6
                    continue
def main():
    v0 = "À"
    v1 = 1
    v2 = runtime_byte_0(v0, v1)
    del v1
    v3 = "©"
    v4 = 0
    v5 = runtime_byte_0(v3, v4)
    del v4
    v6 = "Aéλ🙂Z"
    v7 = 0
    v8 = 0
    v9 = 10
    v10 = codepoint_length_loop_1(v6, v2, v5, v7, v8, v9)
    del v2, v5, v7, v8, v9
    v11 = 1
    v12 = runtime_byte_0(v0, v11)
    del v11
    v13 = 0
    v14 = runtime_byte_0(v3, v13)
    del v13
    v15 = 1
    v16 = 0
    v17 = 0
    v18 = 10
    v19 = codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18)
    del v12, v14, v15, v16, v17, v18
    v20 = 1
    v21 = runtime_byte_0(v0, v20)
    del v20
    v22 = 0
    v23 = runtime_byte_0(v3, v22)
    del v22
    v24 = 2
    v25 = 0
    v26 = 0
    v27 = 10
    v28 = codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27)
    del v21, v23, v24, v25, v26, v27
    v29 = spiral_wrap(v28 - 1, 32, True)
    del v28
    v30 = spiral_string_slice("Aéλ🙂Z", v19, v29)
    del v19, v29
    v31 = 1
    v32 = runtime_byte_0(v0, v31)
    del v31
    v33 = 0
    v34 = runtime_byte_0(v3, v33)
    del v33
    v35 = 3
    v36 = 0
    v37 = 0
    v38 = 10
    v39 = codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38)
    del v32, v34, v35, v36, v37, v38
    v40 = 1
    v41 = runtime_byte_0(v0, v40)
    del v40
    v42 = 0
    v43 = runtime_byte_0(v3, v42)
    del v42
    v44 = 4
    v45 = 0
    v46 = 0
    v47 = 10
    v48 = codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47)
    del v41, v43, v44, v45, v46, v47
    v49 = spiral_wrap(v48 - 1, 32, True)
    del v48
    v50 = spiral_string_slice("Aéλ🙂Z", v39, v49)
    del v39, v49
    v51 = 1
    v52 = runtime_byte_0(v0, v51)
    del v51
    v53 = 0
    v54 = runtime_byte_0(v3, v53)
    del v53
    v55 = 1
    v56 = 0
    v57 = 0
    v58 = 10
    v59 = codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58)
    del v52, v54, v55, v56, v57, v58
    v60 = 1
    v61 = runtime_byte_0(v0, v60)
    del v60
    v62 = 0
    v63 = runtime_byte_0(v3, v62)
    del v62
    v64 = 4
    v65 = 0
    v66 = 0
    v67 = 10
    v68 = codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67)
    del v61, v63, v64, v65, v66, v67
    v69 = spiral_wrap(v68 - 1, 32, True)
    del v68
    v70 = spiral_string_slice("Aéλ🙂Z", v59, v69)
    del v59, v69
    v71 = 1
    v72 = runtime_byte_0(v0, v71)
    del v0, v71
    v73 = 0
    v74 = runtime_byte_0(v3, v73)
    del v3, v73
    v75 = 3
    v76 = 0
    v77 = 0
    v78 = 10
    v79 = codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78)
    del v6, v72, v74, v75, v76, v77, v78
    v80 = 0
    v81 = runtime_byte_0(v30, v80)
    del v80
    v82 = "é"
    v83 = 0
    v84 = runtime_byte_0(v82, v83)
    del v82, v83
    v85 = 3
    v86 = runtime_byte_0(v50, v85)
    del v85
    v87 = "🙂"
    v88 = 3
    v89 = runtime_byte_0(v87, v88)
    del v87, v88
    v90 = v10 == 5
    del v10
    if v90:
        del v90
        v91 = spiral_string_length(v30)
        del v30
        v92 = v91 == 2
        del v91
        if v92:
            del v92
            v93 = v81 == v84
            del v81, v84
            if v93:
                del v93
                v94 = spiral_string_length(v50)
                del v50
                v95 = v94 == 4
                del v94
                if v95:
                    del v95
                    v96 = v86 == v89
                    del v86, v89
                    if v96:
                        del v96
                        v97 = spiral_string_length(v70)
                        del v70
                        v98 = v97 == 8
                        del v97
                        if v98:
                            del v98
                            v99 = v79 == 5
                            del v79
                            if v99:
                                del v99
                                return 0
                            else:
                                del v99
                                return 1
                        else:
                            del v79, v98
                            return 2
                    else:
                        del v70, v79, v96
                        return 3
                else:
                    del v70, v79, v86, v89, v95
                    return 4
            else:
                del v50, v70, v79, v86, v89, v93
                return 5
        else:
            del v50, v70, v79, v81, v84, v86, v89, v92
            return 6
    else:
        del v30, v50, v70, v79, v81, v84, v86, v89, v90
        return 7

if __name__ == '__main__': sys.exit(main())
