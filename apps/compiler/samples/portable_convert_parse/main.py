kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
def spiral_try(fn, some, ex_fn):
    try:
        return some(fn())
    except Exception as e:
        return ex_fn(e)
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def closure0(env_v0 : string):
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
def ok_c1():
    def inner(v0 : i32) -> US0:
        return US0_Ok(v0)
    return inner
def error_c2():
    def inner(v0 : 'BaseException') -> US0:
        return US0_Error(v0)
    return inner
def closure3():
    def inner(v0 : Callable[[], 'BaseException']) -> 'BaseException':
        return v0()
    return inner
class US1_Some(NamedTuple): # Some
    v0 : i32
    tag = 0
class US1_None(NamedTuple): # None
    tag = 1
US1_None_shared = US1_None()
US1 = Union[US1_Some, US1_None]
def main():
    v0 = "ff"
    v1 = int (v0, 16)
    print(v1)
    v2 = "1011"
    v3 = int (v2, 2)
    print(v3)
    v4 = "-42"
    v5 = int (v4, 10)
    print(v5)
    v6 = " 123 "
    v7 = closure0(v6)
    fn = v7 
    v8 = ok_c1()
    ok = v8 
    v9 = error_c2()
    error = v9 
    v10 = closure3()
    ex_fn = v10 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v11 = x
    match v11:
        case US0_Error(_): # Error
            v17 = US1_None_shared
        case US0_Ok(v12): # Ok
            v17 = US1_Some(v12)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    match v17:
        case US1_None(): # None
            v19 = "none"
            print(v19)
        case US1_Some(v18): # Some
            print(v18)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    v20 = "12x"
    v21 = closure0(v20)
    fn = v21 
    ok = v8 
    error = v9 
    ex_fn = v10 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v22 = x
    match v22:
        case US0_Error(_): # Error
            v28 = US1_None_shared
        case US0_Ok(v23): # Ok
            v28 = US1_Some(v23)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    match v28:
        case US1_None(): # None
            v30 = "none"
            print(v30)
        case US1_Some(v29): # Some
            print(v29)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    v31 = ""
    v32 = closure0(v31)
    fn = v32 
    ok = v8 
    error = v9 
    ex_fn = v10 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v33 = x
    match v33:
        case US0_Error(_): # Error
            v39 = US1_None_shared
        case US0_Ok(v34): # Ok
            v39 = US1_Some(v34)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    match v39:
        case US1_None(): # None
            v41 = "none"
            print(v41)
        case US1_Some(v40): # Some
            print(v40)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    v42 = "+7"
    v43 = closure0(v42)
    fn = v43 
    ok = v8 
    error = v9 
    ex_fn = v10 
    try: x = ok(fn()) 
    except Exception as ex: x = error(ex_fn(lambda: ex))
    v44 = x
    match v44:
        case US0_Error(_): # Error
            v50 = US1_None_shared
        case US0_Ok(v45): # Ok
            v50 = US1_Some(v45)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    match v50:
        case US1_None(): # None
            v52 = "none"
            print(v52)
        case US1_Some(v51): # Some
            print(v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    return 0

if __name__ == '__main__': sys.exit(main())
