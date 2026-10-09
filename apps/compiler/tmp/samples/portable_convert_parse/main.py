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
class US0_0(NamedTuple): # Ok
    v0 : i32
    tag = 0
class US0_1(NamedTuple): # Error
    v0 : 'BaseException'
    tag = 1
US0 = Union[US0_0, US0_1]
def Closure1():
    def inner(v0 : i32) -> US0:
        return US0_0(v0)
    return inner
def Closure2():
    def inner(v0 : 'BaseException') -> US0:
        return US0_1(v0)
    return inner
def Closure3():
    def inner(v0 : Callable[[], 'BaseException']) -> 'BaseException':
        return v0()
    return inner
class US1_0(NamedTuple): # Some
    v0 : i32
    tag = 0
class US1_1(NamedTuple): # None
    tag = 1
US1 = Union[US1_0, US1_1]
def main():
    v0 = "ff"
    v13 = int (v0, 16)
    del v0
    print(v13)
    del v13
    v67 = "1011"
    v80 = int (v67, 2)
    del v67
    print(v80)
    del v80
    v91 = "-42"
    v127 = int (v91, 10)
    del v91
    print(v127)
    del v127
    v138 = " 123 "
    v283 = Closure0(v138)
    del v138
    fn = v283 
    del v283
    v284 = Closure1()
    ok = v284 
    v285 = Closure2()
    error = v285 
    v286 = Closure3()
    ex_fn = v286 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v287 = x
    match v287:
        case US0_1(_): # Error
            v307 = US1_1()
        case US0_0(v302): # Ok
            v307 = US1_0(v302)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v287
    match v307:
        case US1_1(): # None
            v705 = "none"
            print(v705)
            del v705
        case US1_0(v700): # Some
            print(v700)
            del v700
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v307
    v708 = "12x"
    v709 = Closure0(v708)
    del v708
    fn = v709 
    del v709
    ok = v284 
    error = v285 
    ex_fn = v286 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v710 = x
    match v710:
        case US0_1(_): # Error
            v716 = US1_1()
        case US0_0(v711): # Ok
            v716 = US1_0(v711)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v710
    match v716:
        case US1_1(): # None
            v718 = "none"
            print(v718)
            del v718
        case US1_0(v717): # Some
            print(v717)
            del v717
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v716
    v719 = ""
    v720 = Closure0(v719)
    del v719
    fn = v720 
    del v720
    ok = v284 
    error = v285 
    ex_fn = v286 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v721 = x
    match v721:
        case US0_1(_): # Error
            v727 = US1_1()
        case US0_0(v722): # Ok
            v727 = US1_0(v722)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v721
    match v727:
        case US1_1(): # None
            v729 = "none"
            print(v729)
            del v729
        case US1_0(v728): # Some
            print(v728)
            del v728
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v727
    v730 = "+7"
    v731 = Closure0(v730)
    del v730
    fn = v731 
    del v731
    ok = v284 
    del v284
    error = v285 
    del v285
    ex_fn = v286 
    del v286
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v732 = x
    match v732:
        case US0_1(_): # Error
            v738 = US1_1()
        case US0_0(v733): # Ok
            v738 = US1_0(v733)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v732
    match v738:
        case US1_1(): # None
            v740 = "none"
            print(v740)
            del v740
        case US1_0(v739): # Some
            print(v739)
            del v739
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v738
    return 0

if __name__ == '__main__': sys.exit(main())
