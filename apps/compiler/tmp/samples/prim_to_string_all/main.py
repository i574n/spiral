kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def main():
    v0 = -128
    v1 = -32768
    v2 = -5
    v3 = -1234567890123
    v4 = 255
    v5 = 65535
    v6 = 4294967295
    v7 = 18446744073709551615
    v8 = True
    v9 = False
    v10 = 'a'
    v11 = str(v0)
    v12 = v11 == "-128"
    if v12:
        v13 = 0
    else:
        v13 = 1
    v14 = str(v1)
    v15 = v14 == "-32768"
    if v15:
        v16 = 0
    else:
        v16 = 1
    v17 = spiral_wrap(v13 + v16, 32, True)
    v18 = str(v2)
    v19 = v18 == "-5"
    if v19:
        v20 = 0
    else:
        v20 = 1
    v21 = spiral_wrap(v17 + v20, 32, True)
    v22 = str(v3)
    v23 = v22 == "-1234567890123"
    if v23:
        v24 = 0
    else:
        v24 = 1
    v25 = spiral_wrap(v21 + v24, 32, True)
    v26 = str(v4)
    v27 = v26 == "255"
    if v27:
        v28 = 0
    else:
        v28 = 1
    v29 = spiral_wrap(v25 + v28, 32, True)
    v30 = str(v5)
    v31 = v30 == "65535"
    if v31:
        v32 = 0
    else:
        v32 = 1
    v33 = spiral_wrap(v29 + v32, 32, True)
    v34 = str(v6)
    v35 = v34 == "4294967295"
    if v35:
        v36 = 0
    else:
        v36 = 1
    v37 = spiral_wrap(v33 + v36, 32, True)
    v38 = str(v7)
    v39 = v38 == "18446744073709551615"
    if v39:
        v40 = 0
    else:
        v40 = 1
    v41 = spiral_wrap(v37 + v40, 32, True)
    v42 = ("true" if v8 else "false")
    v43 = v42 == "true"
    if v43:
        v44 = 0
    else:
        v44 = 1
    v45 = spiral_wrap(v41 + v44, 32, True)
    v46 = ("true" if v9 else "false")
    v47 = v46 == "false"
    if v47:
        v48 = 0
    else:
        v48 = 1
    v49 = spiral_wrap(v45 + v48, 32, True)
    v50 = v10
    v51 = v50 == "a"
    if v51:
        v52 = 0
    else:
        v52 = 1
    v53 = spiral_wrap(v49 + v52, 32, True)
    v54 = str(7)
    v55 = v54 == "7"
    if v55:
        v56 = 0
    else:
        v56 = 1
    v57 = spiral_wrap(v53 + v56, 32, True)
    v58 = ("true" if False else "false")
    v59 = v58 == "false"
    if v59:
        v60 = 0
    else:
        v60 = 1
    v61 = spiral_wrap(v57 + v60, 32, True)
    v62 = 'z'
    v63 = v62 == "z"
    if v63:
        v64 = 0
    else:
        v64 = 1
    v65 = spiral_wrap(v61 + v64, 32, True)
    v66 = str(-3)
    v67 = v66 == "-3"
    if v67:
        v68 = 0
    else:
        v68 = 1
    v69 = spiral_wrap(v65 + v68, 32, True)
    return v69

if __name__ == '__main__': sys.exit(main())
