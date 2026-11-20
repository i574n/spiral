kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
import math
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def main():
    v0 = 2.7
    v1 = 3.2
    v2 = -2.5
    v3 = 3.5
    v4 = 0.5
    v5 = 1.0
    v6 = 2.7
    v7 = math.floor(v0)
    v8 = v7 != 2.0
    if v8:
        return 1
    else:
        v9 = math.ceil
        v10 = v9(v0)
        v11 = v10 != 3.0
        if v11:
            return 2
        else:
            v12 = round
            v13 = v12(v0)
            v14 = v13 != 3.0
            if v14:
                return 3
            else:
                v15 = round
                v16 = v15(v1)
                v17 = v16 != 3.0
                if v17:
                    return 4
                else:
                    v18 = round
                    v19 = v18(v2)
                    v20 = v19 != -2.0
                    if v20:
                        return 5
                    else:
                        v21 = round
                        v22 = v21(v3)
                        v23 = v22 != 4.0
                        if v23:
                            return 6
                        else:
                            v24 = round
                            v25 = v24(v4)
                            v26 = v25 != 0.0
                            if v26:
                                return 7
                            else:
                                v27 = math.atan2(v5, v5)
                                v28 = v27 * 1000.0
                                v29 = math.floor(v28)
                                v30 = v29 != 785.0
                                if v30:
                                    return 8
                                else:
                                    v31 = math.floor(v6)
                                    v32 = v31 != 2.0
                                    if v32:
                                        return 9
                                    else:
                                        return 0

if __name__ == '__main__': sys.exit(main())
