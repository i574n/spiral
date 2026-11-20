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

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
def spiral_mod_trunc(a, b):
    r = abs(a) % abs(b)
    return -r if a < 0 else r
def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
UH0 = Union["UH0_Nil", "UH0_Cons"]
@dataclass
class Mut0:
    v0 : i32
@dataclass
class Mut1:
    v0 : i32
class UH0_Nil(NamedTuple): # Nil
    tag = 0
UH0_Nil_shared = UH0_Nil()
class UH0_Cons(NamedTuple): # Cons
    v0 : i32
    v1 : UH0
    tag = 1
@dataclass
class Mut2:
    v0 : UH0
def method0(v0 : Mut0) -> bool:
    v1 = v0.v0
    del v0
    v2 = v1 < 3
    del v1
    return v2
def method1(v0 : Mut1) -> bool:
    v1 = v0.v0
    del v0
    v2 = v1 < 4
    del v1
    return v2
def main():
    v0 = cp.zeros(3,dtype=cp.int32)
    v1 = Mut0(0)
    while method0(v1):
        v3 = v1.v0
        v4 = spiral_wrap(v3 * 5, 32, True)
        v0[v3] = v4
        del v4
        v5 = spiral_wrap(v3 + 1, 32, True)
        del v3
        v1.v0 = v5
        del v5
    del v1
    v6 = Mut1(0)
    v7 = Mut1(0)
    v8 = UH0_Nil_shared
    v9 = Mut2(v8)
    del v8
    while method1(v6):
        v11 = v6.v0
        v12 = spiral_mod_trunc(v11, 2)
        v13 = v12 == 1
        del v12
        if v13:
            v14 = v7.v0
            v15 = spiral_wrap(v14 + 1, 32, True)
            del v14
            v7.v0 = v15
            del v15
        else:
            pass
        del v13
        v16 = v9.v0
        v17 = UH0_Cons(v11, v16)
        del v16
        v9.v0 = v17
        del v17
        v18 = spiral_wrap(v11 + 1, 32, True)
        del v11
        v6.v0 = v18
        del v18
    del v6
    v19 = v9.v0
    del v9
    match v19:
        case UH0_Cons(v20, v21): # Cons
            match v21:
                case UH0_Cons(v22, v23): # Cons
                    del v21
                    match v23:
                        case UH0_Cons(v24, v25): # Cons
                            del v23
                            match v25:
                                case UH0_Cons(v26, v27): # Cons
                                    del v25
                                    match v27:
                                        case UH0_Nil(): # Nil
                                            del v27
                                            v28 = spiral_wrap(v20 * 64, 32, True)
                                            del v20
                                            v29 = spiral_wrap(v22 * 16, 32, True)
                                            del v22
                                            v30 = spiral_wrap(v28 + v29, 32, True)
                                            del v28, v29
                                            v31 = spiral_wrap(v24 * 4, 32, True)
                                            del v24
                                            v32 = spiral_wrap(v30 + v31, 32, True)
                                            del v30, v31
                                            v33 = spiral_wrap(v32 + v26, 32, True)
                                            del v26, v32
                                            v38 = v33
                                        case t:
                                            del v20, v22, v24, v26, v27
                                            v38 = -1
                                case t:
                                    del v20, v22, v24, v25
                                    v38 = -1
                        case t:
                            del v20, v22, v23
                            v38 = -1
                case t:
                    del v20, v21
                    v38 = -1
        case t:
            v38 = -1
    del v19
    v39 = v7.v0
    del v7
    v40 = spiral_wrap(v38 + v39, 32, True)
    del v38, v39
    v41 = spiral_array_index(v0, 2)
    v42 = spiral_wrap(v40 + v41, 32, True)
    del v40, v41
    v43 = spiral_array_index(v0, 1)
    del v0
    v44 = spiral_wrap(v42 - v43, 32, True)
    del v42, v43
    return v44

if __name__ == '__main__': sys.exit(main())
