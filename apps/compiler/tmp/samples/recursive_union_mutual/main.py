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

UH0 = Union["UH0_A", "UH0_StopA"]
UH1 = Union["UH1_B", "UH1_StopB"]
class UH1_B(NamedTuple): # B
    v0 : UH0
    tag = 0
class UH1_StopB(NamedTuple): # StopB
    tag = 1
class UH0_A(NamedTuple): # A
    v0 : UH1
    tag = 0
class UH0_StopA(NamedTuple): # StopA
    tag = 1
def main():
    v0 = True
    if v0:
        v1 = UH0_StopA()
        v2 = UH1_B(v1)
        del v1
        v5 = UH0_A(v2)
    else:
        v5 = UH0_StopA()
    del v0
    match v5:
        case UH0_A(_): # A
            del v5
            return 0
        case UH0_StopA(): # StopA
            del v5
            return 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
