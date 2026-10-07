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

def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
import sys
def main():
    v0 = static_array(1)
    v0[0] = 20, 22
    v1, v2 = spiral_array_index(v0, 0)
    del v0
    v3 = dynamic_array(1)
    v3[0] = 7
    v4 = cp.empty(1,dtype=cp.int32)
    v4[0] = 9
    v5 = spiral_array_index(v4, 0)
    del v4
    v6 = type(v5) is int
    v7 = cp.empty(1,dtype=object)
    v7[0] = 3, 4
    v8, v9 = spiral_array_index(v7, 0)
    del v7
    v10 = v1 + v2
    del v1, v2
    v11 = v8 + v9
    del v8, v9
    v12 = spiral_array_index(v3, 0)
    del v3
    v13 = v10 == 42
    del v10
    if v13:
        del v13
        v14 = v12 == 7
        del v12
        if v14:
            del v14
            v15 = v5 == 9
            del v5
            if v15:
                del v15
                if v6:
                    del v6
                    v16 = v11 == 7
                    del v11
                    if v16:
                        del v16
                        return 0
                    else:
                        del v16
                        return 5
                else:
                    del v6, v11
                    return 4
            else:
                del v6, v11, v15
                return 3
        else:
            del v5, v6, v11, v14
            return 2
    else:
        del v5, v6, v11, v12, v13
        return 1

if __name__ == '__main__': sys.exit(main())
