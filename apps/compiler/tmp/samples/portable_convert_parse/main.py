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
def Closure0(env_v0 : string):
    def inner() -> i32:
        nonlocal env_v0
        v0 = env_v0
        v1 = i32(v0)
        del v0
        return v1
    return inner
class US0_Ok(NamedTuple): # Ok
    v0 : i32
    tag = 0
class US0_Error(NamedTuple): # Error
    v0 : 'BaseException'
    tag = 1
US0 = Union[US0_Ok, US0_Error]
def Closure1():
    def inner(v0 : i32) -> US0:
        return US0_Ok(v0)
    return inner
def Closure2():
    def inner(v0 : 'BaseException') -> US0:
        return US0_Error(v0)
    return inner
def Closure3():
    def inner(v0 : Callable[[], 'BaseException']) -> 'BaseException':
        return v0()
    return inner
class US1_Some(NamedTuple): # Some
    v0 : i32
    tag = 0
class US1_None(NamedTuple): # None
    tag = 1
US1 = Union[US1_Some, US1_None]
def main():
    v0 = "ff"
    v13 = int (v0, 16)
    del v0
    print(v13)
    del v13
    v69 = "1011"
    v82 = int (v69, 2)
    del v69
    print(v82)
    del v82
    v94 = "-42"
    v131 = int (v94, 10)
    del v94
    print(v131)
    del v131
    v143 = " 123 "
    v313 = Closure0(v143)
    del v143
    fn = v313 
    del v313
    v314 = Closure1()
    ok = v314 
    v315 = Closure2()
    error = v315 
    v316 = Closure3()
    ex_fn = v316 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v317 = x
    match v317:
        case US0_Error(_): # Error
            v338 = US1_None()
        case US0_Ok(v333): # Ok
            v338 = US1_Some(v333)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v317
    match v338:
        case US1_None(): # None
            v800 = "none"
            print(v800)
            del v800
        case US1_Some(v795): # Some
            print(v795)
            del v795
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v338
    v803 = "12x"
    v804 = Closure0(v803)
    del v803
    fn = v804 
    del v804
    ok = v314 
    error = v315 
    ex_fn = v316 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v805 = x
    match v805:
        case US0_Error(_): # Error
            v811 = US1_None()
        case US0_Ok(v806): # Ok
            v811 = US1_Some(v806)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v805
    match v811:
        case US1_None(): # None
            v813 = "none"
            print(v813)
            del v813
        case US1_Some(v812): # Some
            print(v812)
            del v812
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v811
    v814 = ""
    v815 = Closure0(v814)
    del v814
    fn = v815 
    del v815
    ok = v314 
    error = v315 
    ex_fn = v316 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v816 = x
    match v816:
        case US0_Error(_): # Error
            v822 = US1_None()
        case US0_Ok(v817): # Ok
            v822 = US1_Some(v817)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v816
    match v822:
        case US1_None(): # None
            v824 = "none"
            print(v824)
            del v824
        case US1_Some(v823): # Some
            print(v823)
            del v823
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v822
    v825 = "+7"
    v826 = Closure0(v825)
    del v825
    fn = v826 
    del v826
    ok = v314 
    del v314
    error = v315 
    del v315
    ex_fn = v316 
    del v316
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v827 = x
    match v827:
        case US0_Error(_): # Error
            v833 = US1_None()
        case US0_Ok(v828): # Ok
            v833 = US1_Some(v828)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v827
    match v833:
        case US1_None(): # None
            v835 = "none"
            print(v835)
            del v835
        case US1_Some(v834): # Some
            print(v834)
            del v834
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v833
    return 0

if __name__ == '__main__': sys.exit(main())
