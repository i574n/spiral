kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

import math
def main():
    v0 = 0.0
    v1 = 1.0
    v2 = 0.0
    v3 = 1.0
    v4 = math.log(v1)
    v5 = v4 == v0
    if v5:
        v6 = math.log(v3)
        v7 = v6 == v2
        v8 = v7
    else:
        v8 = False
    if v8:
        v9 = math.exp(v0)
        v10 = v9 == v1
        v11 = v10
    else:
        v11 = False
    if v11:
        v12 = math.exp(v2)
        v13 = v12 == v3
        v14 = v13
    else:
        v14 = False
    if v14:
        v15 = math.tanh(v0)
        v16 = v15 == v0
        v17 = v16
    else:
        v17 = False
    if v17:
        v18 = math.tanh(v2)
        v19 = v18 == v2
        v20 = v19
    else:
        v20 = False
    if v20:
        v21 = math.sin(v0)
        v22 = v21 == v0
        v23 = v22
    else:
        v23 = False
    if v23:
        v24 = math.sin(v2)
        v25 = v24 == v2
        v26 = v25
    else:
        v26 = False
    if v26:
        v27 = math.cos(v0)
        v28 = v27 == v1
        v29 = v28
    else:
        v29 = False
    if v29:
        v30 = math.cos(v2)
        v31 = v30 == v3
        v32 = v31
    else:
        v32 = False
    if v32:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
