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
    if v12:
        return 1
    else:
        v13 = spiral_string_index(v6, 2)
        v14 = v13 != '"'
        if v14:
            return 2
        else:
            v15 = spiral_string_length(v7)
            v16 = v15 != 0
            if v16:
                return 3
            else:
                v17 = spiral_string_length(v8)
                v18 = v17 != 4
                if v18:
                    return 4
                else:
                    v19 = spiral_string_index(v8, 1)
                    v20 = v19 != '\\'
                    if v20:
                        return 5
                    else:
                        v21 = spiral_string_length(v9)
                        v22 = v21 != 83
                        if v22:
                            return 6
                        else:
                            v23 = spiral_string_index(v9, 5)
                            v24 = v23 != '\n'
                            if v24:
                                return 7
                            else:
                                v25 = spiral_string_index(v9, 37)
                                v26 = v25 != '\n'
                                if v26:
                                    return 8
                                else:
                                    v27 = spiral_string_index(v9, 38)
                                    v28 = v27 != '\n'
                                    if v28:
                                        return 9
                                    else:
                                        v29 = spiral_string_index(v9, 39)
                                        v30 = v29 != '$'
                                        if v30:
                                            return 10
                                        else:
                                            v31 = spiral_string_index(v9, 57)
                                            v32 = v31 != 'i'
                                            if v32:
                                                return 11
                                            else:
                                                v33 = spiral_string_index(v9, 82)
                                                v34 = v33 != 'd'
                                                if v34:
                                                    return 12
                                                else:
                                                    v35 = spiral_string_length(v10)
                                                    v36 = v35 != 11
                                                    if v36:
                                                        return 13
                                                    else:
                                                        v37 = spiral_string_index(v10, 0)
                                                        v38 = v37 != '\n'
                                                        if v38:
                                                            return 14
                                                        else:
                                                            v39 = spiral_string_index(v10, 5)
                                                            v40 = v39 != '\n'
                                                            if v40:
                                                                return 15
                                                            else:
                                                                v41 = v0 != 16
                                                                if v41:
                                                                    return 16
                                                                else:
                                                                    v42 = spiral_string_length(v1)
                                                                    v43 = v42 != 3
                                                                    if v43:
                                                                        return 17
                                                                    else:
                                                                        v44 = spiral_string_length(v2)
                                                                        v45 = v44 != 8
                                                                        if v45:
                                                                            return 18
                                                                        else:
                                                                            v46 = spiral_string_index(v2, 7)
                                                                            v47 = v46 != '"'
                                                                            if v47:
                                                                                return 19
                                                                            else:
                                                                                v48 = spiral_string_length(v3)
                                                                                v49 = v48 != 7
                                                                                if v49:
                                                                                    return 20
                                                                                else:
                                                                                    v50 = spiral_string_index(v3, 4)
                                                                                    v51 = v50 != '"'
                                                                                    if v51:
                                                                                        return 21
                                                                                    else:
                                                                                        v52 = spiral_string_length(v4)
                                                                                        v53 = v52 != 23
                                                                                        if v53:
                                                                                            return 22
                                                                                        else:
                                                                                            v54 = spiral_string_index(v4, 6)
                                                                                            v55 = v54 != ' '
                                                                                            if v55:
                                                                                                return 23
                                                                                            else:
                                                                                                v56 = spiral_string_index(v4, 10)
                                                                                                v57 = v56 != 's'
                                                                                                if v57:
                                                                                                    return 24
                                                                                                else:
                                                                                                    v58 = spiral_string_index(v4, 17)
                                                                                                    v59 = v58 != '\n'
                                                                                                    if v59:
                                                                                                        return 25
                                                                                                    else:
                                                                                                        v60 = spiral_string_index(v4, 22)
                                                                                                        v61 = v60 != 'd'
                                                                                                        if v61:
                                                                                                            return 26
                                                                                                        else:
                                                                                                            v62 = spiral_string_length(v5)
                                                                                                            v63 = v62 != 5
                                                                                                            if v63:
                                                                                                                return 27
                                                                                                            else:
                                                                                                                v64 = spiral_string_index(v5, 3)
                                                                                                                v65 = v64 != 'c'
                                                                                                                if v65:
                                                                                                                    return 28
                                                                                                                else:
                                                                                                                    return 0

if __name__ == '__main__': sys.exit(main())
