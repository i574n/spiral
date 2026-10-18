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
    v0 = 16
    v1 = "x\ny"
    v2 = "say \"hi\""
    v3 = "a \"\"\" b"
    v4 = "first\n    second\n\nthird"
    v5 = "ab\ncd"
    v6 = "a \"b\" c"
    v7 = ""
    v8 = "a\\nb"
    v9 = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
    v10 = "\ntop\n\nlevel"
    v11 = spiral_string_length(v6)
    v12 = v11 == 7
    del v11
    v13 = v12 != True
    del v12
    if v13:
        del v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v13
        return 1
    else:
        del v13
        v14 = spiral_string_index(v6, 2)
        del v6
        v15 = v14 == '"'
        del v14
        v16 = v15 != True
        del v15
        if v16:
            del v0, v1, v2, v3, v4, v5, v7, v8, v9, v10, v16
            return 2
        else:
            del v16
            v17 = spiral_string_length(v7)
            del v7
            v18 = v17 == 0
            del v17
            v19 = v18 != True
            del v18
            if v19:
                del v0, v1, v2, v3, v4, v5, v8, v9, v10, v19
                return 3
            else:
                del v19
                v20 = spiral_string_length(v8)
                v21 = v20 == 4
                del v20
                v22 = v21 != True
                del v21
                if v22:
                    del v0, v1, v2, v3, v4, v5, v8, v9, v10, v22
                    return 4
                else:
                    del v22
                    v23 = spiral_string_index(v8, 1)
                    del v8
                    v24 = v23 == '\\'
                    del v23
                    v25 = v24 != True
                    del v24
                    if v25:
                        del v0, v1, v2, v3, v4, v5, v9, v10, v25
                        return 5
                    else:
                        del v25
                        v26 = spiral_string_length(v9)
                        v27 = v26 == 83
                        del v26
                        v28 = v27 != True
                        del v27
                        if v28:
                            del v0, v1, v2, v3, v4, v5, v9, v10, v28
                            return 6
                        else:
                            del v28
                            v29 = spiral_string_index(v9, 5)
                            v30 = v29 == '\n'
                            del v29
                            v31 = v30 != True
                            del v30
                            if v31:
                                del v0, v1, v2, v3, v4, v5, v9, v10, v31
                                return 7
                            else:
                                del v31
                                v32 = spiral_string_index(v9, 37)
                                v33 = v32 == '\n'
                                del v32
                                v34 = v33 != True
                                del v33
                                if v34:
                                    del v0, v1, v2, v3, v4, v5, v9, v10, v34
                                    return 8
                                else:
                                    del v34
                                    v35 = spiral_string_index(v9, 38)
                                    v36 = v35 == '\n'
                                    del v35
                                    v37 = v36 != True
                                    del v36
                                    if v37:
                                        del v0, v1, v2, v3, v4, v5, v9, v10, v37
                                        return 9
                                    else:
                                        del v37
                                        v38 = spiral_string_index(v9, 39)
                                        v39 = v38 == '$'
                                        del v38
                                        v40 = v39 != True
                                        del v39
                                        if v40:
                                            del v0, v1, v2, v3, v4, v5, v9, v10, v40
                                            return 10
                                        else:
                                            del v40
                                            v41 = spiral_string_index(v9, 57)
                                            v42 = v41 == 'i'
                                            del v41
                                            v43 = v42 != True
                                            del v42
                                            if v43:
                                                del v0, v1, v2, v3, v4, v5, v9, v10, v43
                                                return 11
                                            else:
                                                del v43
                                                v44 = spiral_string_index(v9, 82)
                                                del v9
                                                v45 = v44 == 'd'
                                                del v44
                                                v46 = v45 != True
                                                del v45
                                                if v46:
                                                    del v0, v1, v2, v3, v4, v5, v10, v46
                                                    return 12
                                                else:
                                                    del v46
                                                    v47 = spiral_string_length(v10)
                                                    v48 = v47 == 11
                                                    del v47
                                                    v49 = v48 != True
                                                    del v48
                                                    if v49:
                                                        del v0, v1, v2, v3, v4, v5, v10, v49
                                                        return 13
                                                    else:
                                                        del v49
                                                        v50 = spiral_string_index(v10, 0)
                                                        v51 = v50 == '\n'
                                                        del v50
                                                        v52 = v51 != True
                                                        del v51
                                                        if v52:
                                                            del v0, v1, v2, v3, v4, v5, v10, v52
                                                            return 14
                                                        else:
                                                            del v52
                                                            v53 = spiral_string_index(v10, 5)
                                                            del v10
                                                            v54 = v53 == '\n'
                                                            del v53
                                                            v55 = v54 != True
                                                            del v54
                                                            if v55:
                                                                del v0, v1, v2, v3, v4, v5, v55
                                                                return 15
                                                            else:
                                                                del v55
                                                                v56 = v0 == 16
                                                                del v0
                                                                v57 = v56 != True
                                                                del v56
                                                                if v57:
                                                                    del v1, v2, v3, v4, v5, v57
                                                                    return 16
                                                                else:
                                                                    del v57
                                                                    v58 = spiral_string_length(v1)
                                                                    del v1
                                                                    v59 = v58 == 3
                                                                    del v58
                                                                    v60 = v59 != True
                                                                    del v59
                                                                    if v60:
                                                                        del v2, v3, v4, v5, v60
                                                                        return 17
                                                                    else:
                                                                        del v60
                                                                        v61 = spiral_string_length(v2)
                                                                        v62 = v61 == 8
                                                                        del v61
                                                                        v63 = v62 != True
                                                                        del v62
                                                                        if v63:
                                                                            del v2, v3, v4, v5, v63
                                                                            return 18
                                                                        else:
                                                                            del v63
                                                                            v64 = spiral_string_index(v2, 7)
                                                                            del v2
                                                                            v65 = v64 == '"'
                                                                            del v64
                                                                            v66 = v65 != True
                                                                            del v65
                                                                            if v66:
                                                                                del v3, v4, v5, v66
                                                                                return 19
                                                                            else:
                                                                                del v66
                                                                                v67 = spiral_string_length(v3)
                                                                                v68 = v67 == 7
                                                                                del v67
                                                                                v69 = v68 != True
                                                                                del v68
                                                                                if v69:
                                                                                    del v3, v4, v5, v69
                                                                                    return 20
                                                                                else:
                                                                                    del v69
                                                                                    v70 = spiral_string_index(v3, 4)
                                                                                    del v3
                                                                                    v71 = v70 == '"'
                                                                                    del v70
                                                                                    v72 = v71 != True
                                                                                    del v71
                                                                                    if v72:
                                                                                        del v4, v5, v72
                                                                                        return 21
                                                                                    else:
                                                                                        del v72
                                                                                        v73 = spiral_string_length(v4)
                                                                                        v74 = v73 == 23
                                                                                        del v73
                                                                                        v75 = v74 != True
                                                                                        del v74
                                                                                        if v75:
                                                                                            del v4, v5, v75
                                                                                            return 22
                                                                                        else:
                                                                                            del v75
                                                                                            v76 = spiral_string_index(v4, 6)
                                                                                            v77 = v76 == ' '
                                                                                            del v76
                                                                                            v78 = v77 != True
                                                                                            del v77
                                                                                            if v78:
                                                                                                del v4, v5, v78
                                                                                                return 23
                                                                                            else:
                                                                                                del v78
                                                                                                v79 = spiral_string_index(v4, 10)
                                                                                                v80 = v79 == 's'
                                                                                                del v79
                                                                                                v81 = v80 != True
                                                                                                del v80
                                                                                                if v81:
                                                                                                    del v4, v5, v81
                                                                                                    return 24
                                                                                                else:
                                                                                                    del v81
                                                                                                    v82 = spiral_string_index(v4, 17)
                                                                                                    v83 = v82 == '\n'
                                                                                                    del v82
                                                                                                    v84 = v83 != True
                                                                                                    del v83
                                                                                                    if v84:
                                                                                                        del v4, v5, v84
                                                                                                        return 25
                                                                                                    else:
                                                                                                        del v84
                                                                                                        v85 = spiral_string_index(v4, 22)
                                                                                                        del v4
                                                                                                        v86 = v85 == 'd'
                                                                                                        del v85
                                                                                                        v87 = v86 != True
                                                                                                        del v86
                                                                                                        if v87:
                                                                                                            del v5, v87
                                                                                                            return 26
                                                                                                        else:
                                                                                                            del v87
                                                                                                            v88 = spiral_string_length(v5)
                                                                                                            v89 = v88 == 5
                                                                                                            del v88
                                                                                                            v90 = v89 != True
                                                                                                            del v89
                                                                                                            if v90:
                                                                                                                del v5, v90
                                                                                                                return 27
                                                                                                            else:
                                                                                                                del v90
                                                                                                                v91 = spiral_string_index(v5, 3)
                                                                                                                del v5
                                                                                                                v92 = v91 == 'c'
                                                                                                                del v91
                                                                                                                v93 = v92 != True
                                                                                                                del v92
                                                                                                                if v93:
                                                                                                                    del v93
                                                                                                                    return 28
                                                                                                                else:
                                                                                                                    del v93
                                                                                                                    return 0

if __name__ == '__main__': sys.exit(main())
