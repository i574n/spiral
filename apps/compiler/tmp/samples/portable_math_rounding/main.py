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
    del v7
    if v8:
        del v0, v1, v2, v3, v4, v5, v6, v8
        return 1
    else:
        del v8
        v9 = math.ceil
        v10 = v9(v0)
        del v9
        v11 = v10 != 3.0
        del v10
        if v11:
            del v0, v1, v2, v3, v4, v5, v6, v11
            return 2
        else:
            del v11
            v12 = round
            v13 = v12(v0)
            del v0, v12
            v14 = v13 != 3.0
            del v13
            if v14:
                del v1, v2, v3, v4, v5, v6, v14
                return 3
            else:
                del v14
                v15 = round
                v16 = v15(v1)
                del v1, v15
                v17 = v16 != 3.0
                del v16
                if v17:
                    del v2, v3, v4, v5, v6, v17
                    return 4
                else:
                    del v17
                    v18 = round
                    v19 = v18(v2)
                    del v2, v18
                    v20 = v19 != -2.0
                    del v19
                    if v20:
                        del v3, v4, v5, v6, v20
                        return 5
                    else:
                        del v20
                        v21 = round
                        v22 = v21(v3)
                        del v3, v21
                        v23 = v22 != 4.0
                        del v22
                        if v23:
                            del v4, v5, v6, v23
                            return 6
                        else:
                            del v23
                            v24 = round
                            v25 = v24(v4)
                            del v4, v24
                            v26 = v25 != 0.0
                            del v25
                            if v26:
                                del v5, v6, v26
                                return 7
                            else:
                                del v26
                                v27 = math.atan2(v5, v5)
                                del v5
                                v28 = v27 * 1000.0
                                del v27
                                v29 = math.floor(v28)
                                del v28
                                v30 = v29 != 785.0
                                del v29
                                if v30:
                                    del v6, v30
                                    return 8
                                else:
                                    del v30
                                    v31 = math.floor(v6)
                                    del v6
                                    v32 = v31 != 2.0
                                    del v31
                                    if v32:
                                        del v32
                                        return 9
                                    else:
                                        del v32
                                        return 0

if __name__ == '__main__': sys.exit(main())
