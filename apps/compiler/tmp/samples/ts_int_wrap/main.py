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
def main():
    v0 = 250
    v1 = 10
    v2 = 4294967295
    v3 = 18446744073709551615
    v4 = 127
    v5 = 1
    v6 = 7
    v7 = 2
    v8 = 9223372036854775807
    v9 = -v6
    del v6
    v10 = -v8
    del v8
    v11 = v0 + v1
    del v0, v1
    v12 = v11 == 4
    del v11
    if v12:
        del v12
        v13 = v2 + 1
        v14 = v13 == 0
        del v13
        if v14:
            del v14
            v15 = v2 * v2
            v16 = v15 == 1
            del v15
            if v16:
                del v16
                v17 = v3 + 1
                v18 = v17 == 0
                del v17
                if v18:
                    del v18
                    v19 = v3 * v3
                    v20 = v19 == 1
                    del v19
                    if v20:
                        del v20
                        v21 = v3 // 3
                        del v3
                        v22 = v21 == 6148914691236517205
                        del v21
                        if v22:
                            del v22
                            v23 = v4 + v5
                            del v4, v5
                            v24 = v23 < 0
                            del v23
                            if v24:
                                del v24
                                v25 = v9 // v7
                                v26 = v25 == -3
                                del v25
                                if v26:
                                    del v26
                                    v27 = v9 % v7
                                    del v7
                                    v28 = v27 == -1
                                    del v27
                                    if v28:
                                        del v28
                                        v29 = v10 % 10
                                        del v10
                                        v30 = v29 == -7
                                        del v29
                                        if v30:
                                            del v30
                                            v31 = v2 >> 28
                                            del v2
                                            v32 = v31 == 15
                                            del v31
                                            if v32:
                                                del v32
                                                v33 = v9 >> 1
                                                del v9
                                                v34 = v33 == -4
                                                del v33
                                                if v34:
                                                    del v34
                                                    return 0
                                                else:
                                                    del v34
                                                    return 12
                                            else:
                                                del v9, v32
                                                return 11
                                        else:
                                            del v2, v9, v30
                                            return 10
                                    else:
                                        del v2, v9, v10, v28
                                        return 9
                                else:
                                    del v2, v7, v9, v10, v26
                                    return 8
                            else:
                                del v2, v7, v9, v10, v24
                                return 7
                        else:
                            del v2, v4, v5, v7, v9, v10, v22
                            return 6
                    else:
                        del v2, v3, v4, v5, v7, v9, v10, v20
                        return 5
                else:
                    del v2, v3, v4, v5, v7, v9, v10, v18
                    return 4
            else:
                del v2, v3, v4, v5, v7, v9, v10, v16
                return 3
        else:
            del v2, v3, v4, v5, v7, v9, v10, v14
            return 2
    else:
        del v2, v3, v4, v5, v7, v9, v10, v12
        return 1

if __name__ == '__main__': sys.exit(main())
