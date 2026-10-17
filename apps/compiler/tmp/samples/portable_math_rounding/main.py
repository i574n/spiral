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
    v8 = v7 == 2.0
    del v7
    v9 = v8 != True
    del v8
    if v9:
        del v0, v1, v2, v3, v4, v5, v6, v9
        return 1
    else:
        del v9
        v10 = math.ceil
        v11 = v10(v0)
        del v10
        v12 = v11 == 3.0
        del v11
        v13 = v12 != True
        del v12
        if v13:
            del v0, v1, v2, v3, v4, v5, v6, v13
            return 2
        else:
            del v13
            v14 = round
            v15 = v14(v0)
            del v0, v14
            v16 = v15 == 3.0
            del v15
            v17 = v16 != True
            del v16
            if v17:
                del v1, v2, v3, v4, v5, v6, v17
                return 3
            else:
                del v17
                v18 = round
                v19 = v18(v1)
                del v1, v18
                v20 = v19 == 3.0
                del v19
                v21 = v20 != True
                del v20
                if v21:
                    del v2, v3, v4, v5, v6, v21
                    return 4
                else:
                    del v21
                    v22 = round
                    v23 = v22(v2)
                    del v2, v22
                    v24 = v23 == -2.0
                    del v23
                    v25 = v24 != True
                    del v24
                    if v25:
                        del v3, v4, v5, v6, v25
                        return 5
                    else:
                        del v25
                        v26 = round
                        v27 = v26(v3)
                        del v3, v26
                        v28 = v27 == 4.0
                        del v27
                        v29 = v28 != True
                        del v28
                        if v29:
                            del v4, v5, v6, v29
                            return 6
                        else:
                            del v29
                            v30 = round
                            v31 = v30(v4)
                            del v4, v30
                            v32 = v31 == 0.0
                            del v31
                            v33 = v32 != True
                            del v32
                            if v33:
                                del v5, v6, v33
                                return 7
                            else:
                                del v33
                                v34 = math.atan2(v5, v5)
                                del v5
                                v35 = v34 * 1000.0
                                del v34
                                v36 = math.floor(v35)
                                del v35
                                v37 = v36 == 785.0
                                del v36
                                v38 = v37 != True
                                del v37
                                if v38:
                                    del v6, v38
                                    return 8
                                else:
                                    del v38
                                    v39 = math.floor(v6)
                                    del v6
                                    v40 = v39 == 2.0
                                    del v39
                                    v41 = v40 != True
                                    del v40
                                    if v41:
                                        del v41
                                        return 9
                                    else:
                                        del v41
                                        return 0

if __name__ == '__main__': sys.exit(main())
