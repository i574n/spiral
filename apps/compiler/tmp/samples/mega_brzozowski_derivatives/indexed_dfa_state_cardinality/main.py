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
UH0 = Union["UH0_RegexEmpty", "UH0_RegexEpsilon", "UH0_RegexChar", "UH0_RegexAlt", "UH0_RegexCat", "UH0_RegexStar"]
UH1 = Union["UH1_InputEmpty", "UH1_InputCons"]
UH2 = Union["UH2_RegexEmpty", "UH2_RegexEpsilon", "UH2_RegexChar", "UH2_RegexAlt", "UH2_RegexCat", "UH2_RegexStar"]
UH3 = Union["UH3_InputEmpty", "UH3_InputCons"]
class US0_BitZero(NamedTuple): # BitZero
    tag = 0
class US0_BitOne(NamedTuple): # BitOne
    tag = 1
US0 = Union[US0_BitZero, US0_BitOne]
class UH0_RegexEmpty(NamedTuple): # RegexEmpty
    tag = 0
class UH0_RegexEpsilon(NamedTuple): # RegexEpsilon
    tag = 1
class UH0_RegexChar(NamedTuple): # RegexChar
    v0 : US0
    tag = 2
class UH0_RegexAlt(NamedTuple): # RegexAlt
    v0 : UH0
    v1 : UH0
    tag = 3
class UH0_RegexCat(NamedTuple): # RegexCat
    v0 : UH0
    v1 : UH0
    tag = 4
class UH0_RegexStar(NamedTuple): # RegexStar
    v0 : UH0
    tag = 5
class UH1_InputEmpty(NamedTuple): # InputEmpty
    tag = 0
class UH1_InputCons(NamedTuple): # InputCons
    v0 : US0
    v1 : UH1
    tag = 1
class US1_SymbolLess(NamedTuple): # SymbolLess
    tag = 0
class US1_SymbolSame(NamedTuple): # SymbolSame
    tag = 1
class US1_SymbolGreater(NamedTuple): # SymbolGreater
    tag = 2
US1 = Union[US1_SymbolLess, US1_SymbolSame, US1_SymbolGreater]
class US2_Nullable(NamedTuple): # Nullable
    tag = 0
class US2_NonNullable(NamedTuple): # NonNullable
    tag = 1
US2 = Union[US2_Nullable, US2_NonNullable]
class US3_TriA(NamedTuple): # TriA
    tag = 0
class US3_TriB(NamedTuple): # TriB
    tag = 1
class US3_TriC(NamedTuple): # TriC
    tag = 2
US3 = Union[US3_TriA, US3_TriB, US3_TriC]
class UH2_RegexEmpty(NamedTuple): # RegexEmpty
    tag = 0
class UH2_RegexEpsilon(NamedTuple): # RegexEpsilon
    tag = 1
class UH2_RegexChar(NamedTuple): # RegexChar
    v0 : US3
    tag = 2
class UH2_RegexAlt(NamedTuple): # RegexAlt
    v0 : UH2
    v1 : UH2
    tag = 3
class UH2_RegexCat(NamedTuple): # RegexCat
    v0 : UH2
    v1 : UH2
    tag = 4
class UH2_RegexStar(NamedTuple): # RegexStar
    v0 : UH2
    tag = 5
class UH3_InputEmpty(NamedTuple): # InputEmpty
    tag = 0
class UH3_InputCons(NamedTuple): # InputCons
    v0 : US3
    v1 : UH3
    tag = 1
def random_bit_input_1(v0 : u64, v1 : i32, v2 : UH1) -> Tuple[UH1, u64]:
    while True:
        v3 = 0 < v1
        if v3:
            del v3
            v4 = spiral_wrap(v0 * 1103515245, 64, False)
            del v0
            v5 = spiral_wrap(v4 + 12345, 64, False)
            del v4
            v6 = v5 & 2147483647
            del v5
            v7 = spiral_wrap(v1 - 1, 32, True)
            del v1
            v8 = v6 >> 16
            v9 = v8 & 1
            del v8
            v10 = v9 == 0
            del v9
            if v10:
                v11 = US0_BitZero()
                v13 = v11
            else:
                v12 = US0_BitOne()
                v13 = v12
            del v10
            v14 = UH1_InputCons(v13, v2)
            del v2, v13
            v0, v1, v2 = v6, v7, v14
            continue
        else:
            del v1, v3
            return v2, v0
def run_2(v0 : i32, v1 : UH1) -> bool:
    while True:
        match v1:
            case UH1_InputCons(v4, v5): # InputCons
                del v1
                v6 = v0 == 0
                del v0
                if v6:
                    match v4:
                        case US0_BitOne(): # BitOne
                            v10 = US1_SymbolGreater()
                        case US0_BitZero(): # BitZero
                            v10 = US1_SymbolSame()
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    match v10:
                        case US1_SymbolSame(): # SymbolSame
                            v11 = True
                        case t:
                            v11 = False
                    del v10
                    if v11:
                        del v11
                        v19 = 1
                    else:
                        del v11
                        v19 = 0
                else:
                    match v4:
                        case US0_BitOne(): # BitOne
                            v16 = US1_SymbolGreater()
                        case US0_BitZero(): # BitZero
                            v16 = US1_SymbolSame()
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    match v16:
                        case US1_SymbolSame(): # SymbolSame
                            v17 = True
                        case t:
                            v17 = False
                    del v16
                    if v17:
                        del v17
                        v19 = 1
                    else:
                        del v17
                        v19 = 0
                del v4, v6
                v0, v1 = v19, v5
                continue
            case UH1_InputEmpty(): # InputEmpty
                del v1
                v2 = v0 == 0
                del v0
                v3 = v2 == False
                del v2
                return v3
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def regex_compare_8(v0 : UH0, v1 : UH0) -> US1:
    while True:
        match v0:
            case UH0_RegexAlt(v53, v54): # RegexAlt
                del v0
                match v1:
                    case UH0_RegexAlt(v55, v56): # RegexAlt
                        del v1
                        v57 = regex_compare_8(v53, v55)
                        del v53, v55
                        match v57:
                            case US1_SymbolSame(): # SymbolSame
                                del v57
                                v0, v1 = v54, v56
                                continue
                            case t:
                                del v54, v56
                                return v57
                    case t:
                        del v1, v53, v54
                        return US1_SymbolGreater()
            case UH0_RegexCat(v28, v29): # RegexCat
                del v0
                match v1:
                    case UH0_RegexCat(v34, v35): # RegexCat
                        del v1
                        v36 = regex_compare_8(v28, v34)
                        del v28, v34
                        match v36:
                            case US1_SymbolSame(): # SymbolSame
                                del v36
                                v0, v1 = v29, v35
                                continue
                            case t:
                                del v29, v35
                                return v36
                    case UH0_RegexChar(_): # RegexChar
                        del v1, v28, v29
                        return US1_SymbolGreater()
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v1, v28, v29
                        return US1_SymbolGreater()
                    case UH0_RegexEpsilon(): # RegexEpsilon
                        del v1, v28, v29
                        return US1_SymbolGreater()
                    case t:
                        del v1, v28, v29
                        return US1_SymbolLess()
            case UH0_RegexChar(v10): # RegexChar
                del v0
                match v1:
                    case UH0_RegexChar(v13): # RegexChar
                        del v1
                        match v10:
                            case US0_BitOne(): # BitOne
                                del v10
                                match v13:
                                    case US0_BitOne(): # BitOne
                                        del v13
                                        return US1_SymbolSame()
                                    case US0_BitZero(): # BitZero
                                        del v13
                                        return US1_SymbolGreater()
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case US0_BitZero(): # BitZero
                                del v10
                                match v13:
                                    case US0_BitOne(): # BitOne
                                        del v13
                                        return US1_SymbolLess()
                                    case US0_BitZero(): # BitZero
                                        del v13
                                        return US1_SymbolSame()
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v1, v10
                        return US1_SymbolGreater()
                    case UH0_RegexEpsilon(): # RegexEpsilon
                        del v1, v10
                        return US1_SymbolGreater()
                    case t:
                        del v1, v10
                        return US1_SymbolLess()
            case UH0_RegexEmpty(): # RegexEmpty
                del v0
                match v1:
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v1
                        return US1_SymbolSame()
                    case t:
                        del v1
                        return US1_SymbolLess()
            case UH0_RegexEpsilon(): # RegexEpsilon
                del v0
                match v1:
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v1
                        return US1_SymbolGreater()
                    case UH0_RegexEpsilon(): # RegexEpsilon
                        del v1
                        return US1_SymbolSame()
                    case t:
                        del v1
                        return US1_SymbolLess()
            case UH0_RegexStar(v44): # RegexStar
                del v0
                match v1:
                    case UH0_RegexAlt(_, _): # RegexAlt
                        del v1, v44
                        return US1_SymbolLess()
                    case UH0_RegexStar(v48): # RegexStar
                        del v1
                        v0, v1 = v44, v48
                        continue
                    case t:
                        del v1, v44
                        return US1_SymbolGreater()
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def alt_insert_sorted_7(v0 : UH0, v1 : UH0) -> UH0:
    match v1:
        case UH0_RegexAlt(v2, v3): # RegexAlt
            v4 = regex_compare_8(v0, v2)
            match v4:
                case US1_SymbolGreater(): # SymbolGreater
                    del v1, v4
                    v6 = alt_insert_sorted_7(v0, v3)
                    del v0, v3
                    return UH0_RegexAlt(v2, v6)
                case US1_SymbolLess(): # SymbolLess
                    del v2, v3, v4
                    return UH0_RegexAlt(v0, v1)
                case US1_SymbolSame(): # SymbolSame
                    del v0, v2, v3, v4
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH0_RegexEmpty(): # RegexEmpty
            del v1
            return v0
        case t:
            v11 = regex_compare_8(v0, v1)
            match v11:
                case US1_SymbolGreater(): # SymbolGreater
                    del v11
                    return UH0_RegexAlt(v1, v0)
                case US1_SymbolLess(): # SymbolLess
                    del v11
                    return UH0_RegexAlt(v0, v1)
                case US1_SymbolSame(): # SymbolSame
                    del v0, v11
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
def make_alt_6(v0 : UH0, v1 : UH0) -> UH0:
    while True:
        match v0:
            case UH0_RegexAlt(v2, v3): # RegexAlt
                del v0
                v4 = alt_insert_sorted_7(v2, v1)
                del v1, v2
                v0, v1 = v3, v4
                continue
            case UH0_RegexEmpty(): # RegexEmpty
                del v0
                return v1
            case t:
                return alt_insert_sorted_7(v0, v1)
def regex_equal_10(v0 : UH0, v1 : UH0) -> bool:
    while True:
        match v0:
            case UH0_RegexAlt(v18, v19): # RegexAlt
                del v0
                match v1:
                    case UH0_RegexAlt(v20, v21): # RegexAlt
                        del v1
                        v22 = regex_equal_10(v18, v20)
                        del v18, v20
                        if v22:
                            del v22
                            v0, v1 = v19, v21
                            continue
                        else:
                            del v19, v21, v22
                            return False
                    case t:
                        del v1, v18, v19
                        return False
            case UH0_RegexCat(v26, v27): # RegexCat
                del v0
                match v1:
                    case UH0_RegexCat(v28, v29): # RegexCat
                        del v1
                        v30 = regex_equal_10(v26, v28)
                        del v26, v28
                        if v30:
                            del v30
                            v0, v1 = v27, v29
                            continue
                        else:
                            del v27, v29, v30
                            return False
                    case t:
                        del v1, v26, v27
                        return False
            case UH0_RegexChar(v4): # RegexChar
                del v0
                match v1:
                    case UH0_RegexChar(v5): # RegexChar
                        del v1
                        match v4:
                            case US0_BitOne(): # BitOne
                                match v5:
                                    case US0_BitOne(): # BitOne
                                        v15 = US1_SymbolSame()
                                    case US0_BitZero(): # BitZero
                                        v15 = US1_SymbolGreater()
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case US0_BitZero(): # BitZero
                                match v5:
                                    case US0_BitOne(): # BitOne
                                        v15 = US1_SymbolLess()
                                    case US0_BitZero(): # BitZero
                                        v15 = US1_SymbolSame()
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v4, v5
                        match v15:
                            case US1_SymbolSame(): # SymbolSame
                                del v15
                                return True
                            case t:
                                del v15
                                return False
                    case t:
                        del v1, v4
                        return False
            case UH0_RegexEmpty(): # RegexEmpty
                del v0
                match v1:
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v1
                        return True
                    case t:
                        del v1
                        return False
            case UH0_RegexEpsilon(): # RegexEpsilon
                del v0
                match v1:
                    case UH0_RegexEpsilon(): # RegexEpsilon
                        del v1
                        return True
                    case t:
                        del v1
                        return False
            case UH0_RegexStar(v34): # RegexStar
                del v0
                match v1:
                    case UH0_RegexStar(v35): # RegexStar
                        del v1
                        v0, v1 = v34, v35
                        continue
                    case t:
                        del v1, v34
                        return False
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def make_cat_9(v0 : UH0, v1 : UH0) -> UH0:
    match v0:
        case UH0_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH0_RegexEmpty()
        case t:
            match v1:
                case UH0_RegexEmpty(): # RegexEmpty
                    del v0, v1
                    return UH0_RegexEmpty()
                case t:
                    match v0:
                        case UH0_RegexEpsilon(): # RegexEpsilon
                            del v0
                            return v1
                        case t:
                            match v1:
                                case UH0_RegexEpsilon(): # RegexEpsilon
                                    del v1
                                    return v0
                                case t:
                                    match v0:
                                        case UH0_RegexCat(v12, v13): # RegexCat
                                            del v0
                                            v14 = make_cat_9(v13, v1)
                                            del v1, v13
                                            return UH0_RegexCat(v12, v14)
                                        case UH0_RegexStar(v4): # RegexStar
                                            match v1:
                                                case UH0_RegexStar(v5): # RegexStar
                                                    v6 = regex_equal_10(v4, v5)
                                                    del v5
                                                    if v6:
                                                        del v0, v1, v6
                                                        return UH0_RegexStar(v4)
                                                    else:
                                                        del v4, v6
                                                        return UH0_RegexCat(v0, v1)
                                                case t:
                                                    del v4
                                                    return UH0_RegexCat(v0, v1)
                                        case t:
                                            return UH0_RegexCat(v0, v1)
def make_star_11(v0 : UH0) -> UH0:
    match v0:
        case UH0_RegexEmpty(): # RegexEmpty
            del v0
            return UH0_RegexEpsilon()
        case UH0_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH0_RegexEpsilon()
        case UH0_RegexStar(v3): # RegexStar
            del v0
            return UH0_RegexStar(v3)
        case t:
            return UH0_RegexStar(v0)
def normalize_5(v0 : UH0) -> UH0:
    match v0:
        case UH0_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = normalize_5(v5)
            del v5
            v8 = normalize_5(v6)
            del v6
            return make_alt_6(v7, v8)
        case UH0_RegexCat(v10, v11): # RegexCat
            del v0
            v12 = normalize_5(v10)
            del v10
            v13 = normalize_5(v11)
            del v11
            return make_cat_9(v12, v13)
        case UH0_RegexChar(v3): # RegexChar
            del v0
            return UH0_RegexChar(v3)
        case UH0_RegexEmpty(): # RegexEmpty
            del v0
            return UH0_RegexEmpty()
        case UH0_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH0_RegexEpsilon()
        case UH0_RegexStar(v15): # RegexStar
            del v0
            v16 = normalize_5(v15)
            del v15
            return make_star_11(v16)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def nullable_13(v0 : UH0) -> US2:
    match v0:
        case UH0_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = nullable_13(v5)
            del v5
            v8 = nullable_13(v6)
            del v6
            match v7:
                case US2_Nullable(): # Nullable
                    del v7, v8
                    return US2_Nullable()
                case t:
                    match v8:
                        case US2_Nullable(): # Nullable
                            del v7, v8
                            return US2_Nullable()
                        case t:
                            match v7:
                                case US2_NonNullable(): # NonNullable
                                    del v7
                                    match v8:
                                        case US2_NonNullable(): # NonNullable
                                            del v8
                                            return US2_NonNullable()
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH0_RegexCat(v16, v17): # RegexCat
            del v0
            v18 = nullable_13(v16)
            del v16
            v19 = nullable_13(v17)
            del v17
            match v18:
                case US2_Nullable(): # Nullable
                    del v18
                    match v19:
                        case US2_Nullable(): # Nullable
                            del v19
                            return US2_Nullable()
                        case t:
                            del v19
                            return US2_NonNullable()
                case t:
                    del v18, v19
                    return US2_NonNullable()
        case UH0_RegexChar(_): # RegexChar
            del v0
            return US2_NonNullable()
        case UH0_RegexEmpty(): # RegexEmpty
            del v0
            return US2_NonNullable()
        case UH0_RegexEpsilon(): # RegexEpsilon
            del v0
            return US2_Nullable()
        case UH0_RegexStar(_): # RegexStar
            del v0
            return US2_Nullable()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def derivative_12(v0 : UH0, v1 : US0) -> UH0:
    match v0:
        case UH0_RegexAlt(v19, v20): # RegexAlt
            del v0
            v21 = derivative_12(v19, v1)
            del v19
            v22 = derivative_12(v20, v1)
            del v1, v20
            return make_alt_6(v21, v22)
        case UH0_RegexCat(v24, v25): # RegexCat
            del v0
            v26 = nullable_13(v24)
            match v26:
                case US2_NonNullable(): # NonNullable
                    del v26
                    v31 = derivative_12(v24, v1)
                    del v1, v24
                    return make_cat_9(v31, v25)
                case US2_Nullable(): # Nullable
                    del v26
                    v27 = derivative_12(v24, v1)
                    del v24
                    v28 = make_cat_9(v27, v25)
                    del v27
                    v29 = derivative_12(v25, v1)
                    del v1, v25
                    return make_alt_6(v28, v29)
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH0_RegexChar(v4): # RegexChar
            del v0
            match v4:
                case US0_BitOne(): # BitOne
                    match v1:
                        case US0_BitOne(): # BitOne
                            v14 = US1_SymbolSame()
                        case US0_BitZero(): # BitZero
                            v14 = US1_SymbolGreater()
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US0_BitZero(): # BitZero
                    match v1:
                        case US0_BitOne(): # BitOne
                            v14 = US1_SymbolLess()
                        case US0_BitZero(): # BitZero
                            v14 = US1_SymbolSame()
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v1, v4
            match v14:
                case US1_SymbolSame(): # SymbolSame
                    v15 = True
                case t:
                    v15 = False
            del v14
            if v15:
                del v15
                return UH0_RegexEpsilon()
            else:
                del v15
                return UH0_RegexEmpty()
        case UH0_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH0_RegexEmpty()
        case UH0_RegexEpsilon(): # RegexEpsilon
            del v0, v1
            return UH0_RegexEmpty()
        case UH0_RegexStar(v35): # RegexStar
            del v0
            v36 = derivative_12(v35, v1)
            del v1
            v37 = make_star_11(v35)
            del v35
            return make_cat_9(v36, v37)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def canonical_derivative_4(v0 : UH0, v1 : US0) -> UH0:
    v2 = normalize_5(v0)
    del v0
    v3 = derivative_12(v2, v1)
    del v1, v2
    return normalize_5(v3)
def accepts_3(v0 : UH0, v1 : UH1) -> bool:
    while True:
        match v1:
            case UH1_InputCons(v6, v7): # InputCons
                del v1
                v8 = canonical_derivative_4(v0, v6)
                del v0, v6
                v0, v1 = v8, v7
                continue
            case UH1_InputEmpty(): # InputEmpty
                del v1
                v2 = normalize_5(v0)
                del v0
                v3 = nullable_13(v2)
                del v2
                match v3:
                    case US2_NonNullable(): # NonNullable
                        del v3
                        return False
                    case US2_Nullable(): # Nullable
                        del v3
                        return True
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_0(v0 : i32, v1 : UH0, v2 : i32, v3 : u64, v4 : i32) -> i32:
    while True:
        v5 = 0 < v2
        if v5:
            del v5
            v6 = UH1_InputEmpty()
            v7, v8 = random_bit_input_1(v3, v0, v6)
            del v3, v6
            v9 = 0
            v10 = run_2(v9, v7)
            del v9
            v11 = accepts_3(v1, v7)
            del v7
            if v10:
                v13 = v11
            else:
                v12 = False == v11
                v13 = v12
            del v11
            if v13:
                del v13
                v14 = spiral_wrap(v2 - 1, 32, True)
                del v2
                if v10:
                    v15 = spiral_wrap(v4 + 1, 32, True)
                    v16 = v15
                else:
                    v16 = v4
                del v4, v10
                v0, v1, v2, v3, v4 = v0, v1, v14, v8, v16
                continue
            else:
                del v0, v1, v2, v4, v8, v10, v13
                raise Exception("brzozowski-compiled-core-disagrees-on-random-input")
        else:
            del v0, v1, v2, v3, v5
            return v4
def zeros_input_15(v0 : i32, v1 : UH1) -> UH1:
    while True:
        v2 = 0 < v0
        if v2:
            del v2
            v3 = spiral_wrap(v0 - 1, 32, True)
            del v0
            v4 = US0_BitZero()
            v5 = UH1_InputCons(v4, v1)
            del v1, v4
            v0, v1 = v3, v5
            continue
        else:
            del v0, v2
            return v1
def run_16(v0 : i32, v1 : UH1) -> bool:
    while True:
        match v1:
            case UH1_InputCons(v5, v6): # InputCons
                del v1
                v7 = v0 == 0
                if v7:
                    v26 = 1
                else:
                    v13 = v0 == 1
                    if v13:
                        del v13
                        v26 = 1
                    else:
                        del v13
                        match v5:
                            case US0_BitOne(): # BitOne
                                v22 = US1_SymbolGreater()
                            case US0_BitZero(): # BitZero
                                v22 = US1_SymbolSame()
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        match v22:
                            case US1_SymbolSame(): # SymbolSame
                                v23 = True
                            case t:
                                v23 = False
                        del v22
                        if v23:
                            del v23
                            v26 = 2
                        else:
                            del v23
                            v26 = 0
                del v0, v5, v7
                v0, v1 = v26, v6
                continue
            case UH1_InputEmpty(): # InputEmpty
                del v1
                v2 = v0 == 0
                del v0
                if v2:
                    del v2
                    return True
                else:
                    del v2
                    return False
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_14(v0 : i32, v1 : UH0, v2 : i32, v3 : i32) -> i32:
    while True:
        v4 = v0 < v2
        if v4:
            del v0, v1, v2, v4
            return v3
        else:
            del v4
            v5 = UH1_InputEmpty()
            v6 = zeros_input_15(v2, v5)
            del v5
            v7 = 2
            v8 = run_16(v7, v6)
            del v7
            v9 = accepts_3(v1, v6)
            del v6
            if v8:
                v11 = v9
            else:
                v10 = False == v9
                v11 = v10
            del v9
            if v11:
                if v8:
                    v12 = spiral_wrap(v3 + 1, 32, True)
                    v15 = v12
                else:
                    v15 = v3
            else:
                raise Exception("brzozowski-compiled-core-disagrees-on-zero-run")
            del v3, v8, v11
            v16 = US0_BitOne()
            v17 = UH1_InputEmpty()
            v18 = UH1_InputCons(v16, v17)
            del v16, v17
            v19 = zeros_input_15(v2, v18)
            del v18
            v20 = 2
            v21 = run_16(v20, v19)
            del v20
            v22 = accepts_3(v1, v19)
            del v19
            if v21:
                v24 = v22
            else:
                v23 = False == v22
                v24 = v23
            del v22
            if v24:
                if v21:
                    v25 = spiral_wrap(v15 + 1, 32, True)
                    v28 = v25
                else:
                    v28 = v15
            else:
                raise Exception("brzozowski-compiled-core-disagrees-on-zero-run")
            del v15, v21, v24
            v29 = spiral_wrap(v2 + 1, 32, True)
            del v2
            v0, v1, v2, v3 = v0, v1, v29, v28
            continue
def run_17(v0 : i32, v1 : UH3) -> bool:
    while True:
        match v1:
            case UH3_InputCons(v5, v6): # InputCons
                del v1
                v7 = v0 == 0
                if v7:
                    match v5:
                        case US3_TriA(): # TriA
                            v10 = US1_SymbolSame()
                        case t:
                            v10 = US1_SymbolGreater()
                    match v10:
                        case US1_SymbolSame(): # SymbolSame
                            v11 = True
                        case t:
                            v11 = False
                    del v10
                    if v11:
                        del v11
                        v47 = 0
                    else:
                        del v11
                        match v5:
                            case US3_TriA(): # TriA
                                v17 = US1_SymbolLess()
                            case US3_TriB(): # TriB
                                v17 = US1_SymbolSame()
                            case US3_TriC(): # TriC
                                v17 = US1_SymbolGreater()
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        match v17:
                            case US1_SymbolSame(): # SymbolSame
                                v18 = True
                            case t:
                                v18 = False
                        del v17
                        if v18:
                            del v18
                            v47 = 0
                        else:
                            del v18
                            v47 = 1
                else:
                    v21 = v0 == 1
                    if v21:
                        del v21
                        match v5:
                            case US3_TriA(): # TriA
                                v24 = US1_SymbolSame()
                            case t:
                                v24 = US1_SymbolGreater()
                        match v24:
                            case US1_SymbolSame(): # SymbolSame
                                v25 = True
                            case t:
                                v25 = False
                        del v24
                        if v25:
                            del v25
                            v47 = 2
                        else:
                            del v25
                            v47 = 2
                    else:
                        del v21
                        match v5:
                            case US3_TriA(): # TriA
                                v36 = US1_SymbolSame()
                            case t:
                                v36 = US1_SymbolGreater()
                        match v36:
                            case US1_SymbolSame(): # SymbolSame
                                v37 = True
                            case t:
                                v37 = False
                        del v36
                        if v37:
                            del v37
                            v47 = 2
                        else:
                            del v37
                            v47 = 2
                del v0, v5, v7
                v0, v1 = v47, v6
                continue
            case UH3_InputEmpty(): # InputEmpty
                del v1
                v2 = v0 == 0
                if v2:
                    del v0, v2
                    return False
                else:
                    del v2
                    v3 = v0 == 1
                    del v0
                    return v3
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def regex_compare_23(v0 : UH2, v1 : UH2) -> US1:
    while True:
        match v0:
            case UH2_RegexAlt(v59, v60): # RegexAlt
                del v0
                match v1:
                    case UH2_RegexAlt(v61, v62): # RegexAlt
                        del v1
                        v63 = regex_compare_23(v59, v61)
                        del v59, v61
                        match v63:
                            case US1_SymbolSame(): # SymbolSame
                                del v63
                                v0, v1 = v60, v62
                                continue
                            case t:
                                del v60, v62
                                return v63
                    case t:
                        del v1, v59, v60
                        return US1_SymbolGreater()
            case UH2_RegexCat(v34, v35): # RegexCat
                del v0
                match v1:
                    case UH2_RegexCat(v40, v41): # RegexCat
                        del v1
                        v42 = regex_compare_23(v34, v40)
                        del v34, v40
                        match v42:
                            case US1_SymbolSame(): # SymbolSame
                                del v42
                                v0, v1 = v35, v41
                                continue
                            case t:
                                del v35, v41
                                return v42
                    case UH2_RegexChar(_): # RegexChar
                        del v1, v34, v35
                        return US1_SymbolGreater()
                    case UH2_RegexEmpty(): # RegexEmpty
                        del v1, v34, v35
                        return US1_SymbolGreater()
                    case UH2_RegexEpsilon(): # RegexEpsilon
                        del v1, v34, v35
                        return US1_SymbolGreater()
                    case t:
                        del v1, v34, v35
                        return US1_SymbolLess()
            case UH2_RegexChar(v10): # RegexChar
                del v0
                match v1:
                    case UH2_RegexChar(v13): # RegexChar
                        del v1
                        match v10:
                            case US3_TriA(): # TriA
                                del v10
                                match v13:
                                    case US3_TriA(): # TriA
                                        del v13
                                        return US1_SymbolSame()
                                    case t:
                                        del v13
                                        return US1_SymbolLess()
                            case t:
                                match v13:
                                    case US3_TriA(): # TriA
                                        del v10, v13
                                        return US1_SymbolGreater()
                                    case t:
                                        match v10:
                                            case US3_TriB(): # TriB
                                                del v10
                                                match v13:
                                                    case US3_TriB(): # TriB
                                                        del v13
                                                        return US1_SymbolSame()
                                                    case US3_TriC(): # TriC
                                                        del v13
                                                        return US1_SymbolLess()
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case US3_TriC(): # TriC
                                                del v10
                                                match v13:
                                                    case US3_TriB(): # TriB
                                                        del v13
                                                        return US1_SymbolGreater()
                                                    case US3_TriC(): # TriC
                                                        del v13
                                                        return US1_SymbolSame()
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case t:
                                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case UH2_RegexEmpty(): # RegexEmpty
                        del v1, v10
                        return US1_SymbolGreater()
                    case UH2_RegexEpsilon(): # RegexEpsilon
                        del v1, v10
                        return US1_SymbolGreater()
                    case t:
                        del v1, v10
                        return US1_SymbolLess()
            case UH2_RegexEmpty(): # RegexEmpty
                del v0
                match v1:
                    case UH2_RegexEmpty(): # RegexEmpty
                        del v1
                        return US1_SymbolSame()
                    case t:
                        del v1
                        return US1_SymbolLess()
            case UH2_RegexEpsilon(): # RegexEpsilon
                del v0
                match v1:
                    case UH2_RegexEmpty(): # RegexEmpty
                        del v1
                        return US1_SymbolGreater()
                    case UH2_RegexEpsilon(): # RegexEpsilon
                        del v1
                        return US1_SymbolSame()
                    case t:
                        del v1
                        return US1_SymbolLess()
            case UH2_RegexStar(v50): # RegexStar
                del v0
                match v1:
                    case UH2_RegexAlt(_, _): # RegexAlt
                        del v1, v50
                        return US1_SymbolLess()
                    case UH2_RegexStar(v54): # RegexStar
                        del v1
                        v0, v1 = v50, v54
                        continue
                    case t:
                        del v1, v50
                        return US1_SymbolGreater()
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def alt_insert_sorted_22(v0 : UH2, v1 : UH2) -> UH2:
    match v1:
        case UH2_RegexAlt(v2, v3): # RegexAlt
            v4 = regex_compare_23(v0, v2)
            match v4:
                case US1_SymbolGreater(): # SymbolGreater
                    del v1, v4
                    v6 = alt_insert_sorted_22(v0, v3)
                    del v0, v3
                    return UH2_RegexAlt(v2, v6)
                case US1_SymbolLess(): # SymbolLess
                    del v2, v3, v4
                    return UH2_RegexAlt(v0, v1)
                case US1_SymbolSame(): # SymbolSame
                    del v0, v2, v3, v4
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH2_RegexEmpty(): # RegexEmpty
            del v1
            return v0
        case t:
            v11 = regex_compare_23(v0, v1)
            match v11:
                case US1_SymbolGreater(): # SymbolGreater
                    del v11
                    return UH2_RegexAlt(v1, v0)
                case US1_SymbolLess(): # SymbolLess
                    del v11
                    return UH2_RegexAlt(v0, v1)
                case US1_SymbolSame(): # SymbolSame
                    del v0, v11
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
def make_alt_21(v0 : UH2, v1 : UH2) -> UH2:
    while True:
        match v0:
            case UH2_RegexAlt(v2, v3): # RegexAlt
                del v0
                v4 = alt_insert_sorted_22(v2, v1)
                del v1, v2
                v0, v1 = v3, v4
                continue
            case UH2_RegexEmpty(): # RegexEmpty
                del v0
                return v1
            case t:
                return alt_insert_sorted_22(v0, v1)
def regex_equal_25(v0 : UH2, v1 : UH2) -> bool:
    while True:
        match v0:
            case UH2_RegexAlt(v24, v25): # RegexAlt
                del v0
                match v1:
                    case UH2_RegexAlt(v26, v27): # RegexAlt
                        del v1
                        v28 = regex_equal_25(v24, v26)
                        del v24, v26
                        if v28:
                            del v28
                            v0, v1 = v25, v27
                            continue
                        else:
                            del v25, v27, v28
                            return False
                    case t:
                        del v1, v24, v25
                        return False
            case UH2_RegexCat(v32, v33): # RegexCat
                del v0
                match v1:
                    case UH2_RegexCat(v34, v35): # RegexCat
                        del v1
                        v36 = regex_equal_25(v32, v34)
                        del v32, v34
                        if v36:
                            del v36
                            v0, v1 = v33, v35
                            continue
                        else:
                            del v33, v35, v36
                            return False
                    case t:
                        del v1, v32, v33
                        return False
            case UH2_RegexChar(v4): # RegexChar
                del v0
                match v1:
                    case UH2_RegexChar(v5): # RegexChar
                        del v1
                        match v4:
                            case US3_TriA(): # TriA
                                match v5:
                                    case US3_TriA(): # TriA
                                        v21 = US1_SymbolSame()
                                    case t:
                                        v21 = US1_SymbolLess()
                            case t:
                                match v5:
                                    case US3_TriA(): # TriA
                                        v21 = US1_SymbolGreater()
                                    case t:
                                        match v4:
                                            case US3_TriB(): # TriB
                                                match v5:
                                                    case US3_TriB(): # TriB
                                                        v21 = US1_SymbolSame()
                                                    case US3_TriC(): # TriC
                                                        v21 = US1_SymbolLess()
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case US3_TriC(): # TriC
                                                match v5:
                                                    case US3_TriB(): # TriB
                                                        v21 = US1_SymbolGreater()
                                                    case US3_TriC(): # TriC
                                                        v21 = US1_SymbolSame()
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case t:
                                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v4, v5
                        match v21:
                            case US1_SymbolSame(): # SymbolSame
                                del v21
                                return True
                            case t:
                                del v21
                                return False
                    case t:
                        del v1, v4
                        return False
            case UH2_RegexEmpty(): # RegexEmpty
                del v0
                match v1:
                    case UH2_RegexEmpty(): # RegexEmpty
                        del v1
                        return True
                    case t:
                        del v1
                        return False
            case UH2_RegexEpsilon(): # RegexEpsilon
                del v0
                match v1:
                    case UH2_RegexEpsilon(): # RegexEpsilon
                        del v1
                        return True
                    case t:
                        del v1
                        return False
            case UH2_RegexStar(v40): # RegexStar
                del v0
                match v1:
                    case UH2_RegexStar(v41): # RegexStar
                        del v1
                        v0, v1 = v40, v41
                        continue
                    case t:
                        del v1, v40
                        return False
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def make_cat_24(v0 : UH2, v1 : UH2) -> UH2:
    match v0:
        case UH2_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH2_RegexEmpty()
        case t:
            match v1:
                case UH2_RegexEmpty(): # RegexEmpty
                    del v0, v1
                    return UH2_RegexEmpty()
                case t:
                    match v0:
                        case UH2_RegexEpsilon(): # RegexEpsilon
                            del v0
                            return v1
                        case t:
                            match v1:
                                case UH2_RegexEpsilon(): # RegexEpsilon
                                    del v1
                                    return v0
                                case t:
                                    match v0:
                                        case UH2_RegexCat(v12, v13): # RegexCat
                                            del v0
                                            v14 = make_cat_24(v13, v1)
                                            del v1, v13
                                            return UH2_RegexCat(v12, v14)
                                        case UH2_RegexStar(v4): # RegexStar
                                            match v1:
                                                case UH2_RegexStar(v5): # RegexStar
                                                    v6 = regex_equal_25(v4, v5)
                                                    del v5
                                                    if v6:
                                                        del v0, v1, v6
                                                        return UH2_RegexStar(v4)
                                                    else:
                                                        del v4, v6
                                                        return UH2_RegexCat(v0, v1)
                                                case t:
                                                    del v4
                                                    return UH2_RegexCat(v0, v1)
                                        case t:
                                            return UH2_RegexCat(v0, v1)
def make_star_26(v0 : UH2) -> UH2:
    match v0:
        case UH2_RegexEmpty(): # RegexEmpty
            del v0
            return UH2_RegexEpsilon()
        case UH2_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH2_RegexEpsilon()
        case UH2_RegexStar(v3): # RegexStar
            del v0
            return UH2_RegexStar(v3)
        case t:
            return UH2_RegexStar(v0)
def normalize_20(v0 : UH2) -> UH2:
    match v0:
        case UH2_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = normalize_20(v5)
            del v5
            v8 = normalize_20(v6)
            del v6
            return make_alt_21(v7, v8)
        case UH2_RegexCat(v10, v11): # RegexCat
            del v0
            v12 = normalize_20(v10)
            del v10
            v13 = normalize_20(v11)
            del v11
            return make_cat_24(v12, v13)
        case UH2_RegexChar(v3): # RegexChar
            del v0
            return UH2_RegexChar(v3)
        case UH2_RegexEmpty(): # RegexEmpty
            del v0
            return UH2_RegexEmpty()
        case UH2_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH2_RegexEpsilon()
        case UH2_RegexStar(v15): # RegexStar
            del v0
            v16 = normalize_20(v15)
            del v15
            return make_star_26(v16)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def nullable_28(v0 : UH2) -> US2:
    match v0:
        case UH2_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = nullable_28(v5)
            del v5
            v8 = nullable_28(v6)
            del v6
            match v7:
                case US2_Nullable(): # Nullable
                    del v7, v8
                    return US2_Nullable()
                case t:
                    match v8:
                        case US2_Nullable(): # Nullable
                            del v7, v8
                            return US2_Nullable()
                        case t:
                            match v7:
                                case US2_NonNullable(): # NonNullable
                                    del v7
                                    match v8:
                                        case US2_NonNullable(): # NonNullable
                                            del v8
                                            return US2_NonNullable()
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH2_RegexCat(v16, v17): # RegexCat
            del v0
            v18 = nullable_28(v16)
            del v16
            v19 = nullable_28(v17)
            del v17
            match v18:
                case US2_Nullable(): # Nullable
                    del v18
                    match v19:
                        case US2_Nullable(): # Nullable
                            del v19
                            return US2_Nullable()
                        case t:
                            del v19
                            return US2_NonNullable()
                case t:
                    del v18, v19
                    return US2_NonNullable()
        case UH2_RegexChar(_): # RegexChar
            del v0
            return US2_NonNullable()
        case UH2_RegexEmpty(): # RegexEmpty
            del v0
            return US2_NonNullable()
        case UH2_RegexEpsilon(): # RegexEpsilon
            del v0
            return US2_Nullable()
        case UH2_RegexStar(_): # RegexStar
            del v0
            return US2_Nullable()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def derivative_27(v0 : UH2, v1 : US3) -> UH2:
    match v0:
        case UH2_RegexAlt(v25, v26): # RegexAlt
            del v0
            v27 = derivative_27(v25, v1)
            del v25
            v28 = derivative_27(v26, v1)
            del v1, v26
            return make_alt_21(v27, v28)
        case UH2_RegexCat(v30, v31): # RegexCat
            del v0
            v32 = nullable_28(v30)
            match v32:
                case US2_NonNullable(): # NonNullable
                    del v32
                    v37 = derivative_27(v30, v1)
                    del v1, v30
                    return make_cat_24(v37, v31)
                case US2_Nullable(): # Nullable
                    del v32
                    v33 = derivative_27(v30, v1)
                    del v30
                    v34 = make_cat_24(v33, v31)
                    del v33
                    v35 = derivative_27(v31, v1)
                    del v1, v31
                    return make_alt_21(v34, v35)
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH2_RegexChar(v4): # RegexChar
            del v0
            match v4:
                case US3_TriA(): # TriA
                    match v1:
                        case US3_TriA(): # TriA
                            v20 = US1_SymbolSame()
                        case t:
                            v20 = US1_SymbolLess()
                case t:
                    match v1:
                        case US3_TriA(): # TriA
                            v20 = US1_SymbolGreater()
                        case t:
                            match v4:
                                case US3_TriB(): # TriB
                                    match v1:
                                        case US3_TriB(): # TriB
                                            v20 = US1_SymbolSame()
                                        case US3_TriC(): # TriC
                                            v20 = US1_SymbolLess()
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case US3_TriC(): # TriC
                                    match v1:
                                        case US3_TriB(): # TriB
                                            v20 = US1_SymbolGreater()
                                        case US3_TriC(): # TriC
                                            v20 = US1_SymbolSame()
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v1, v4
            match v20:
                case US1_SymbolSame(): # SymbolSame
                    v21 = True
                case t:
                    v21 = False
            del v20
            if v21:
                del v21
                return UH2_RegexEpsilon()
            else:
                del v21
                return UH2_RegexEmpty()
        case UH2_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH2_RegexEmpty()
        case UH2_RegexEpsilon(): # RegexEpsilon
            del v0, v1
            return UH2_RegexEmpty()
        case UH2_RegexStar(v41): # RegexStar
            del v0
            v42 = derivative_27(v41, v1)
            del v1
            v43 = make_star_26(v41)
            del v41
            return make_cat_24(v42, v43)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def canonical_derivative_19(v0 : UH2, v1 : US3) -> UH2:
    v2 = normalize_20(v0)
    del v0
    v3 = derivative_27(v2, v1)
    del v1, v2
    return normalize_20(v3)
def accepts_18(v0 : UH2, v1 : UH3) -> bool:
    while True:
        match v1:
            case UH3_InputCons(v6, v7): # InputCons
                del v1
                v8 = canonical_derivative_19(v0, v6)
                del v0, v6
                v0, v1 = v8, v7
                continue
            case UH3_InputEmpty(): # InputEmpty
                del v1
                v2 = normalize_20(v0)
                del v0
                v3 = nullable_28(v2)
                del v2
                match v3:
                    case US2_NonNullable(): # NonNullable
                        del v3
                        return False
                    case US2_Nullable(): # Nullable
                        del v3
                        return True
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 200
    v1 = 32
    v2 = 16
    v3 = US0_BitZero()
    v4 = UH0_RegexChar(v3)
    del v3
    v5 = US0_BitOne()
    v6 = UH0_RegexChar(v5)
    del v5
    v7 = UH0_RegexAlt(v4, v6)
    del v4, v6
    v8 = UH0_RegexStar(v7)
    del v7
    v9 = US0_BitZero()
    v10 = UH0_RegexChar(v9)
    del v9
    v11 = UH0_RegexCat(v8, v10)
    del v8, v10
    v12 = 1
    v13 = 0
    v14 = loop_0(v1, v11, v0, v12, v13)
    del v0, v1, v11, v12, v13
    v15 = v14 == 93
    del v14
    if v15:
        pass
    else:
        raise Exception("brzozowski-compiled-ends-with-zero-count")
    del v15
    v16 = US0_BitZero()
    v17 = UH0_RegexChar(v16)
    del v16
    v18 = US0_BitZero()
    v19 = UH0_RegexChar(v18)
    del v18
    v20 = US0_BitZero()
    v21 = UH0_RegexChar(v20)
    del v20
    v22 = UH0_RegexCat(v19, v21)
    del v19, v21
    v23 = UH0_RegexAlt(v17, v22)
    del v17, v22
    v24 = UH0_RegexStar(v23)
    del v23
    v25 = US0_BitOne()
    v26 = UH0_RegexChar(v25)
    del v25
    v27 = UH0_RegexCat(v24, v26)
    del v24, v26
    v28 = 1
    v29 = 0
    v30 = loop_14(v2, v27, v28, v29)
    del v2, v27, v28, v29
    v31 = v30 == 16
    del v30
    if v31:
        pass
    else:
        raise Exception("brzozowski-compiled-zero-runs-count")
    del v31
    v32 = US3_TriA()
    v33 = UH2_RegexChar(v32)
    del v32
    v34 = US3_TriB()
    v35 = UH2_RegexChar(v34)
    del v34
    v36 = UH2_RegexAlt(v33, v35)
    del v33, v35
    v37 = UH2_RegexStar(v36)
    del v36
    v38 = US3_TriC()
    v39 = UH2_RegexChar(v38)
    del v38
    v40 = UH2_RegexCat(v37, v39)
    del v37, v39
    v41 = US3_TriA()
    v42 = US3_TriB()
    v43 = US3_TriA()
    v44 = US3_TriC()
    v45 = UH3_InputEmpty()
    v46 = UH3_InputCons(v44, v45)
    del v44, v45
    v47 = UH3_InputCons(v43, v46)
    del v43, v46
    v48 = UH3_InputCons(v42, v47)
    del v42, v47
    v49 = UH3_InputCons(v41, v48)
    del v41, v48
    v50 = US3_TriA()
    v51 = US3_TriB()
    v52 = US3_TriA()
    v53 = US3_TriB()
    v54 = UH3_InputEmpty()
    v55 = UH3_InputCons(v53, v54)
    del v53, v54
    v56 = UH3_InputCons(v52, v55)
    del v52, v55
    v57 = UH3_InputCons(v51, v56)
    del v51, v56
    v58 = UH3_InputCons(v50, v57)
    del v50, v57
    v59 = 0
    v60 = run_17(v59, v49)
    del v59
    if v60:
        v62 = accepts_18(v40, v49)
    else:
        v62 = False
    del v49, v60
    if v62:
        v63 = 0
        v64 = run_17(v63, v58)
        del v63
        if v64:
            del v64
            v68 = False
        else:
            del v64
            v65 = accepts_18(v40, v58)
            v66 = v65 == False
            del v65
            v68 = v66
    else:
        v68 = False
    del v40, v58, v62
    if v68:
        del v68
        return 0
    else:
        del v68
        raise Exception("brzozowski-compiled-ternary-disagrees")

if __name__ == '__main__': sys.exit(main())
