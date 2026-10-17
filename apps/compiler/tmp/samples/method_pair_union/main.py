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

class US0_None(NamedTuple): # None
    tag = 0
class US0_Some(NamedTuple): # Some
    v0 : i32
    tag = 1
US0 = Union[US0_None, US0_Some]
def method0(v0 : i32) -> Tuple[US0, US0]:
    v1 = v0 == 0
    if v1:
        del v0, v1
        v2 = US0_None()
        v3 = US0_None()
        return v2, v3
    else:
        del v1
        v4 = US0_Some(v0)
        del v0
        v5 = US0_None()
        return v4, v5
def main():
    v0 = 7
    v1, v2 = method0(v0)
    del v0
    match v1:
        case US0_None(): # None
            del v1, v2
            return 1
        case US0_Some(v3): # Some
            del v1
            match v2:
                case US0_None(): # None
                    del v2
                    v4 = v3 == 7
                    del v3
                    if v4:
                        del v4
                        return 0
                    else:
                        del v4
                        return 1
                case US0_Some(_): # Some
                    del v2, v3
                    return 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
