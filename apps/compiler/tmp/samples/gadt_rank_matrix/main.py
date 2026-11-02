kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

class US0_RawA(NamedTuple): # RawA
    v0 : i32
    tag = 0
US0 = US0_RawA
class US1_DecidedA(NamedTuple): # DecidedA
    v0 : i32
    v1 : bool
    tag = 1
US1 = US1_DecidedA
class US2_RawB(NamedTuple): # RawB
    v0 : i32
    tag = 1
US2 = US2_RawB
class US3_DecidedB(NamedTuple): # DecidedB
    v0 : bool
    v1 : i32
    tag = 0
US3 = US3_DecidedB
class US4_RawC(NamedTuple): # RawC
    v0 : i32
    tag = 0
US4 = US4_RawC
class US5_DecidedC(NamedTuple): # DecidedC
    v0 : i32
    v1 : bool
    tag = 1
US5 = US5_DecidedC
class US6_FinalC(NamedTuple): # FinalC
    v0 : bool
    tag = 2
US6 = US6_FinalC
def decide_a_0(v0 : US0) -> US1:
    match v0:
        case US0_RawA(v1): # RawA
            return US1_DecidedA(v1, True)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def decide_b_1(v0 : US2) -> US3:
    match v0:
        case US2_RawB(v1): # RawB
            return US3_DecidedB(True, v1)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def decide_c_2(v0 : US4) -> US5:
    match v0:
        case US4_RawC(v1): # RawC
            return US5_DecidedC(v1, True)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def finalize_c_3(v0 : US5) -> US6:
    match v0:
        case US5_DecidedC(_, v2): # DecidedC
            return US6_FinalC(v2)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 7
    v1 = US0_RawA(v0)
    v2 = decide_a_0(v1)
    v3 = 9
    v4 = US2_RawB(v3)
    v5 = decide_b_1(v4)
    v6 = 11
    v7 = US4_RawC(v6)
    v8 = decide_c_2(v7)
    v9 = finalize_c_3(v8)
    match v2:
        case US1_DecidedA(_, v11): # DecidedA
            v12 = v11
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    match v5:
        case US3_DecidedB(v13, _): # DecidedB
            v15 = v13
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    match v9:
        case US6_FinalC(v16): # FinalC
            v17 = v16
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    v18 = v12 and v15
    v19 = v18 and v17
    if v19:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
