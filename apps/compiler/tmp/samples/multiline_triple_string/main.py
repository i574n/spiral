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
    v12 = v11 != 7
    del v11
    if v12:
        del v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v12
        return 1
    else:
        del v12
        v13 = spiral_string_index(v6, 2)
        del v6
        v14 = v13 != '"'
        del v13
        if v14:
            del v0, v1, v2, v3, v4, v5, v7, v8, v9, v10, v14
            return 2
        else:
            del v14
            v15 = spiral_string_length(v7)
            del v7
            v16 = v15 != 0
            del v15
            if v16:
                del v0, v1, v2, v3, v4, v5, v8, v9, v10, v16
                return 3
            else:
                del v16
                v17 = spiral_string_length(v8)
                v18 = v17 != 4
                del v17
                if v18:
                    del v0, v1, v2, v3, v4, v5, v8, v9, v10, v18
                    return 4
                else:
                    del v18
                    v19 = spiral_string_index(v8, 1)
                    del v8
                    v20 = v19 != '\\'
                    del v19
                    if v20:
                        del v0, v1, v2, v3, v4, v5, v9, v10, v20
                        return 5
                    else:
                        del v20
                        v21 = spiral_string_length(v9)
                        v22 = v21 != 83
                        del v21
                        if v22:
                            del v0, v1, v2, v3, v4, v5, v9, v10, v22
                            return 6
                        else:
                            del v22
                            v23 = spiral_string_index(v9, 5)
                            v24 = v23 != '\n'
                            del v23
                            if v24:
                                del v0, v1, v2, v3, v4, v5, v9, v10, v24
                                return 7
                            else:
                                del v24
                                v25 = spiral_string_index(v9, 37)
                                v26 = v25 != '\n'
                                del v25
                                if v26:
                                    del v0, v1, v2, v3, v4, v5, v9, v10, v26
                                    return 8
                                else:
                                    del v26
                                    v27 = spiral_string_index(v9, 38)
                                    v28 = v27 != '\n'
                                    del v27
                                    if v28:
                                        del v0, v1, v2, v3, v4, v5, v9, v10, v28
                                        return 9
                                    else:
                                        del v28
                                        v29 = spiral_string_index(v9, 39)
                                        v30 = v29 != '$'
                                        del v29
                                        if v30:
                                            del v0, v1, v2, v3, v4, v5, v9, v10, v30
                                            return 10
                                        else:
                                            del v30
                                            v31 = spiral_string_index(v9, 57)
                                            v32 = v31 != 'i'
                                            del v31
                                            if v32:
                                                del v0, v1, v2, v3, v4, v5, v9, v10, v32
                                                return 11
                                            else:
                                                del v32
                                                v33 = spiral_string_index(v9, 82)
                                                del v9
                                                v34 = v33 != 'd'
                                                del v33
                                                if v34:
                                                    del v0, v1, v2, v3, v4, v5, v10, v34
                                                    return 12
                                                else:
                                                    del v34
                                                    v35 = spiral_string_length(v10)
                                                    v36 = v35 != 11
                                                    del v35
                                                    if v36:
                                                        del v0, v1, v2, v3, v4, v5, v10, v36
                                                        return 13
                                                    else:
                                                        del v36
                                                        v37 = spiral_string_index(v10, 0)
                                                        v38 = v37 != '\n'
                                                        del v37
                                                        if v38:
                                                            del v0, v1, v2, v3, v4, v5, v10, v38
                                                            return 14
                                                        else:
                                                            del v38
                                                            v39 = spiral_string_index(v10, 5)
                                                            del v10
                                                            v40 = v39 != '\n'
                                                            del v39
                                                            if v40:
                                                                del v0, v1, v2, v3, v4, v5, v40
                                                                return 15
                                                            else:
                                                                del v40
                                                                v41 = v0 != 16
                                                                del v0
                                                                if v41:
                                                                    del v1, v2, v3, v4, v5, v41
                                                                    return 16
                                                                else:
                                                                    del v41
                                                                    v42 = spiral_string_length(v1)
                                                                    del v1
                                                                    v43 = v42 != 3
                                                                    del v42
                                                                    if v43:
                                                                        del v2, v3, v4, v5, v43
                                                                        return 17
                                                                    else:
                                                                        del v43
                                                                        v44 = spiral_string_length(v2)
                                                                        v45 = v44 != 8
                                                                        del v44
                                                                        if v45:
                                                                            del v2, v3, v4, v5, v45
                                                                            return 18
                                                                        else:
                                                                            del v45
                                                                            v46 = spiral_string_index(v2, 7)
                                                                            del v2
                                                                            v47 = v46 != '"'
                                                                            del v46
                                                                            if v47:
                                                                                del v3, v4, v5, v47
                                                                                return 19
                                                                            else:
                                                                                del v47
                                                                                v48 = spiral_string_length(v3)
                                                                                v49 = v48 != 7
                                                                                del v48
                                                                                if v49:
                                                                                    del v3, v4, v5, v49
                                                                                    return 20
                                                                                else:
                                                                                    del v49
                                                                                    v50 = spiral_string_index(v3, 4)
                                                                                    del v3
                                                                                    v51 = v50 != '"'
                                                                                    del v50
                                                                                    if v51:
                                                                                        del v4, v5, v51
                                                                                        return 21
                                                                                    else:
                                                                                        del v51
                                                                                        v52 = spiral_string_length(v4)
                                                                                        v53 = v52 != 23
                                                                                        del v52
                                                                                        if v53:
                                                                                            del v4, v5, v53
                                                                                            return 22
                                                                                        else:
                                                                                            del v53
                                                                                            v54 = spiral_string_index(v4, 6)
                                                                                            v55 = v54 != ' '
                                                                                            del v54
                                                                                            if v55:
                                                                                                del v4, v5, v55
                                                                                                return 23
                                                                                            else:
                                                                                                del v55
                                                                                                v56 = spiral_string_index(v4, 10)
                                                                                                v57 = v56 != 's'
                                                                                                del v56
                                                                                                if v57:
                                                                                                    del v4, v5, v57
                                                                                                    return 24
                                                                                                else:
                                                                                                    del v57
                                                                                                    v58 = spiral_string_index(v4, 17)
                                                                                                    v59 = v58 != '\n'
                                                                                                    del v58
                                                                                                    if v59:
                                                                                                        del v4, v5, v59
                                                                                                        return 25
                                                                                                    else:
                                                                                                        del v59
                                                                                                        v60 = spiral_string_index(v4, 22)
                                                                                                        del v4
                                                                                                        v61 = v60 != 'd'
                                                                                                        del v60
                                                                                                        if v61:
                                                                                                            del v5, v61
                                                                                                            return 26
                                                                                                        else:
                                                                                                            del v61
                                                                                                            v62 = spiral_string_length(v5)
                                                                                                            v63 = v62 != 5
                                                                                                            del v62
                                                                                                            if v63:
                                                                                                                del v5, v63
                                                                                                                return 27
                                                                                                            else:
                                                                                                                del v63
                                                                                                                v64 = spiral_string_index(v5, 3)
                                                                                                                del v5
                                                                                                                v65 = v64 != 'c'
                                                                                                                del v64
                                                                                                                if v65:
                                                                                                                    del v65
                                                                                                                    return 28
                                                                                                                else:
                                                                                                                    del v65
                                                                                                                    return 0

if __name__ == '__main__': sys.exit(main())
