kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class Heap0(NamedTuple):
    v0 : i32
    v1 : string
@dataclass
class Mut0:
    v0 : Heap0
    v1 : Heap0
    v2 : Heap0
def main():
    v0 = 1
    v1 = "no"
    v2 = Heap0(v0, v1)
    v3 = 2
    v4 = "zz"
    v5 = Heap0(v3, v4)
    v6 = 3
    v7 = "aa"
    v8 = Heap0(v6, v7)
    v9 = Mut0(v2, v5, v8)
    v10 = 7
    v11 = "hi"
    v12 = Heap0(v10, v11)
    v13 = 4
    v14 = "yo"
    v15 = Heap0(v13, v14)
    v16 = 9
    v17 = "ok"
    v18 = Heap0(v16, v17)
    v9.v0 = v12
    v9.v1 = v15
    v9.v2 = v18
    v19, v20, v21 = v9.v0, v9.v1, v9.v2
    v22, v23 = v19.v0, v19.v1
    v24, v25 = v20.v0, v20.v1
    v26, v27 = v21.v0, v21.v1
    v28 = v22 == 7
    if v28:
        v29 = v23 == "hi"
        v30 = v29
    else:
        v30 = False
    if v30:
        v31 = v24 == 4
        v32 = v31
    else:
        v32 = False
    if v32:
        v33 = v25 == "yo"
        v34 = v33
    else:
        v34 = False
    if v34:
        v35 = v26 == 9
        v36 = v35
    else:
        v36 = False
    if v36:
        v37 = v27 == "ok"
        v38 = v37
    else:
        v38 = False
    if v38:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
