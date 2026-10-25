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
def spiral_array_index(array, index):
    value = array[index]
    return value.item() if isinstance(array, cp.ndarray) and array.dtype.kind != 'O' else value
UH0 = Union["UH0_RegexEmpty", "UH0_RegexEpsilon", "UH0_RegexChar", "UH0_RegexAlt", "UH0_RegexCat", "UH0_RegexStar"]
UH1 = Union["UH1_InputEmpty", "UH1_InputCons"]
UH2 = Union["UH2_RegexListNil", "UH2_RegexListCons"]
class US0_BitZero(NamedTuple): # BitZero
    tag = 0
US0_BitZero_shared = US0_BitZero()
class US0_BitOne(NamedTuple): # BitOne
    tag = 1
US0_BitOne_shared = US0_BitOne()
US0 = Union[US0_BitZero, US0_BitOne]
class UH0_RegexEmpty(NamedTuple): # RegexEmpty
    tag = 0
UH0_RegexEmpty_shared = UH0_RegexEmpty()
class UH0_RegexEpsilon(NamedTuple): # RegexEpsilon
    tag = 1
UH0_RegexEpsilon_shared = UH0_RegexEpsilon()
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
UH1_InputEmpty_shared = UH1_InputEmpty()
class UH1_InputCons(NamedTuple): # InputCons
    v0 : US0
    v1 : UH1
    tag = 1
class US1_SymbolLess(NamedTuple): # SymbolLess
    tag = 0
US1_SymbolLess_shared = US1_SymbolLess()
class US1_SymbolSame(NamedTuple): # SymbolSame
    tag = 1
US1_SymbolSame_shared = US1_SymbolSame()
class US1_SymbolGreater(NamedTuple): # SymbolGreater
    tag = 2
US1_SymbolGreater_shared = US1_SymbolGreater()
US1 = Union[US1_SymbolLess, US1_SymbolSame, US1_SymbolGreater]
class US2_Nullable(NamedTuple): # Nullable
    tag = 0
US2_Nullable_shared = US2_Nullable()
class US2_NonNullable(NamedTuple): # NonNullable
    tag = 1
US2_NonNullable_shared = US2_NonNullable()
US2 = Union[US2_Nullable, US2_NonNullable]
class UH2_RegexListNil(NamedTuple): # RegexListNil
    tag = 0
UH2_RegexListNil_shared = UH2_RegexListNil()
class UH2_RegexListCons(NamedTuple): # RegexListCons
    v0 : UH0
    v1 : UH2
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
                v11 = US0_BitZero_shared
                v13 = v11
            else:
                v12 = US0_BitOne_shared
                v13 = v12
            del v10
            v14 = UH1_InputCons(v13, v2)
            del v2, v13
            v0, v1, v2 = v6, v7, v14
            continue
        else:
            del v1, v3
            return v2, v0
def regex_compare_7(v0 : UH0, v1 : UH0) -> US1:
    while True:
        match v0:
            case UH0_RegexAlt(v53, v54): # RegexAlt
                del v0
                match v1:
                    case UH0_RegexAlt(v55, v56): # RegexAlt
                        del v1
                        v57 = regex_compare_7(v53, v55)
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
                        return US1_SymbolGreater_shared
            case UH0_RegexCat(v28, v29): # RegexCat
                del v0
                match v1:
                    case UH0_RegexCat(v34, v35): # RegexCat
                        del v1
                        v36 = regex_compare_7(v28, v34)
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
                        return US1_SymbolGreater_shared
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v1, v28, v29
                        return US1_SymbolGreater_shared
                    case UH0_RegexEpsilon(): # RegexEpsilon
                        del v1, v28, v29
                        return US1_SymbolGreater_shared
                    case t:
                        del v1, v28, v29
                        return US1_SymbolLess_shared
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
                                        return US1_SymbolSame_shared
                                    case US0_BitZero(): # BitZero
                                        del v13
                                        return US1_SymbolGreater_shared
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case US0_BitZero(): # BitZero
                                del v10
                                match v13:
                                    case US0_BitOne(): # BitOne
                                        del v13
                                        return US1_SymbolLess_shared
                                    case US0_BitZero(): # BitZero
                                        del v13
                                        return US1_SymbolSame_shared
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v1, v10
                        return US1_SymbolGreater_shared
                    case UH0_RegexEpsilon(): # RegexEpsilon
                        del v1, v10
                        return US1_SymbolGreater_shared
                    case t:
                        del v1, v10
                        return US1_SymbolLess_shared
            case UH0_RegexEmpty(): # RegexEmpty
                del v0
                match v1:
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v1
                        return US1_SymbolSame_shared
                    case t:
                        del v1
                        return US1_SymbolLess_shared
            case UH0_RegexEpsilon(): # RegexEpsilon
                del v0
                match v1:
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v1
                        return US1_SymbolGreater_shared
                    case UH0_RegexEpsilon(): # RegexEpsilon
                        del v1
                        return US1_SymbolSame_shared
                    case t:
                        del v1
                        return US1_SymbolLess_shared
            case UH0_RegexStar(v44): # RegexStar
                del v0
                match v1:
                    case UH0_RegexAlt(_, _): # RegexAlt
                        del v1, v44
                        return US1_SymbolLess_shared
                    case UH0_RegexStar(v48): # RegexStar
                        del v1
                        v0, v1 = v44, v48
                        continue
                    case t:
                        del v1, v44
                        return US1_SymbolGreater_shared
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def alt_insert_sorted_6(v0 : UH0, v1 : UH0) -> UH0:
    match v1:
        case UH0_RegexAlt(v2, v3): # RegexAlt
            v4 = regex_compare_7(v0, v2)
            match v4:
                case US1_SymbolGreater(): # SymbolGreater
                    del v1, v4
                    v6 = alt_insert_sorted_6(v0, v3)
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
            v11 = regex_compare_7(v0, v1)
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
def make_alt_5(v0 : UH0, v1 : UH0) -> UH0:
    while True:
        match v0:
            case UH0_RegexAlt(v2, v3): # RegexAlt
                del v0
                v4 = alt_insert_sorted_6(v2, v1)
                del v1, v2
                v0, v1 = v3, v4
                continue
            case UH0_RegexEmpty(): # RegexEmpty
                del v0
                return v1
            case t:
                return alt_insert_sorted_6(v0, v1)
def regex_equal_9(v0 : UH0, v1 : UH0) -> bool:
    while True:
        match v0:
            case UH0_RegexAlt(v18, v19): # RegexAlt
                del v0
                match v1:
                    case UH0_RegexAlt(v20, v21): # RegexAlt
                        del v1
                        v22 = regex_equal_9(v18, v20)
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
                        v30 = regex_equal_9(v26, v28)
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
                                        v15 = US1_SymbolSame_shared
                                    case US0_BitZero(): # BitZero
                                        v15 = US1_SymbolGreater_shared
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case US0_BitZero(): # BitZero
                                match v5:
                                    case US0_BitOne(): # BitOne
                                        v15 = US1_SymbolLess_shared
                                    case US0_BitZero(): # BitZero
                                        v15 = US1_SymbolSame_shared
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
def make_cat_8(v0 : UH0, v1 : UH0) -> UH0:
    match v0:
        case UH0_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH0_RegexEmpty_shared
        case t:
            match v1:
                case UH0_RegexEmpty(): # RegexEmpty
                    del v0, v1
                    return UH0_RegexEmpty_shared
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
                                            v14 = make_cat_8(v13, v1)
                                            del v1, v13
                                            return UH0_RegexCat(v12, v14)
                                        case UH0_RegexStar(v4): # RegexStar
                                            match v1:
                                                case UH0_RegexStar(v5): # RegexStar
                                                    v6 = regex_equal_9(v4, v5)
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
def make_star_10(v0 : UH0) -> UH0:
    match v0:
        case UH0_RegexEmpty(): # RegexEmpty
            del v0
            return UH0_RegexEpsilon_shared
        case UH0_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH0_RegexEpsilon_shared
        case UH0_RegexStar(v3): # RegexStar
            del v0
            return UH0_RegexStar(v3)
        case t:
            return UH0_RegexStar(v0)
def normalize_4(v0 : UH0) -> UH0:
    match v0:
        case UH0_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = normalize_4(v5)
            del v5
            v8 = normalize_4(v6)
            del v6
            return make_alt_5(v7, v8)
        case UH0_RegexCat(v10, v11): # RegexCat
            del v0
            v12 = normalize_4(v10)
            del v10
            v13 = normalize_4(v11)
            del v11
            return make_cat_8(v12, v13)
        case UH0_RegexChar(v3): # RegexChar
            del v0
            return UH0_RegexChar(v3)
        case UH0_RegexEmpty(): # RegexEmpty
            del v0
            return UH0_RegexEmpty_shared
        case UH0_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH0_RegexEpsilon_shared
        case UH0_RegexStar(v15): # RegexStar
            del v0
            v16 = normalize_4(v15)
            del v15
            return make_star_10(v16)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def nullable_12(v0 : UH0) -> US2:
    match v0:
        case UH0_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = nullable_12(v5)
            del v5
            v8 = nullable_12(v6)
            del v6
            match v7:
                case US2_Nullable(): # Nullable
                    del v7, v8
                    return US2_Nullable_shared
                case t:
                    match v8:
                        case US2_Nullable(): # Nullable
                            del v7, v8
                            return US2_Nullable_shared
                        case t:
                            match v7:
                                case US2_NonNullable(): # NonNullable
                                    del v7
                                    match v8:
                                        case US2_NonNullable(): # NonNullable
                                            del v8
                                            return US2_NonNullable_shared
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH0_RegexCat(v16, v17): # RegexCat
            del v0
            v18 = nullable_12(v16)
            del v16
            v19 = nullable_12(v17)
            del v17
            match v18:
                case US2_Nullable(): # Nullable
                    del v18
                    match v19:
                        case US2_Nullable(): # Nullable
                            del v19
                            return US2_Nullable_shared
                        case t:
                            del v19
                            return US2_NonNullable_shared
                case t:
                    del v18, v19
                    return US2_NonNullable_shared
        case UH0_RegexChar(_): # RegexChar
            del v0
            return US2_NonNullable_shared
        case UH0_RegexEmpty(): # RegexEmpty
            del v0
            return US2_NonNullable_shared
        case UH0_RegexEpsilon(): # RegexEpsilon
            del v0
            return US2_Nullable_shared
        case UH0_RegexStar(_): # RegexStar
            del v0
            return US2_Nullable_shared
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def derivative_11(v0 : UH0, v1 : US0) -> UH0:
    match v0:
        case UH0_RegexAlt(v19, v20): # RegexAlt
            del v0
            v21 = derivative_11(v19, v1)
            del v19
            v22 = derivative_11(v20, v1)
            del v1, v20
            return make_alt_5(v21, v22)
        case UH0_RegexCat(v24, v25): # RegexCat
            del v0
            v26 = nullable_12(v24)
            match v26:
                case US2_NonNullable(): # NonNullable
                    del v26
                    v31 = derivative_11(v24, v1)
                    del v1, v24
                    return make_cat_8(v31, v25)
                case US2_Nullable(): # Nullable
                    del v26
                    v27 = derivative_11(v24, v1)
                    del v24
                    v28 = make_cat_8(v27, v25)
                    del v27
                    v29 = derivative_11(v25, v1)
                    del v1, v25
                    return make_alt_5(v28, v29)
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH0_RegexChar(v4): # RegexChar
            del v0
            match v4:
                case US0_BitOne(): # BitOne
                    match v1:
                        case US0_BitOne(): # BitOne
                            v14 = US1_SymbolSame_shared
                        case US0_BitZero(): # BitZero
                            v14 = US1_SymbolGreater_shared
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US0_BitZero(): # BitZero
                    match v1:
                        case US0_BitOne(): # BitOne
                            v14 = US1_SymbolLess_shared
                        case US0_BitZero(): # BitZero
                            v14 = US1_SymbolSame_shared
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
                return UH0_RegexEpsilon_shared
            else:
                del v15
                return UH0_RegexEmpty_shared
        case UH0_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH0_RegexEmpty_shared
        case UH0_RegexEpsilon(): # RegexEpsilon
            del v0, v1
            return UH0_RegexEmpty_shared
        case UH0_RegexStar(v35): # RegexStar
            del v0
            v36 = derivative_11(v35, v1)
            del v1
            v37 = make_star_10(v35)
            del v35
            return make_cat_8(v36, v37)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def canonical_derivative_3(v0 : UH0, v1 : US0) -> UH0:
    v2 = normalize_4(v0)
    del v0
    v3 = derivative_11(v2, v1)
    del v1, v2
    return normalize_4(v3)
def accepts_2(v0 : UH0, v1 : UH1) -> bool:
    while True:
        match v1:
            case UH1_InputCons(v6, v7): # InputCons
                del v1
                v8 = canonical_derivative_3(v0, v6)
                del v0, v6
                v0, v1 = v8, v7
                continue
            case UH1_InputEmpty(): # InputEmpty
                del v1
                v2 = normalize_4(v0)
                del v0
                v3 = nullable_12(v2)
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
def loop_0(v0 : UH0, v1 : i32, v2 : i32, v3 : u64, v4 : i32) -> i32:
    while True:
        v5 = 0 < v2
        if v5:
            del v5
            v6 = UH1_InputEmpty_shared
            v7, v8 = random_bit_input_1(v3, v1, v6)
            del v3, v6
            v9 = accepts_2(v0, v7)
            del v7
            if v9:
                v10 = spiral_wrap(v4 + 1, 32, True)
                v11 = v10
            else:
                v11 = v4
            del v4, v9
            v12 = spiral_wrap(v2 - 1, 32, True)
            del v2
            v0, v1, v2, v3, v4 = v0, v1, v12, v8, v11
            continue
        else:
            del v0, v1, v2, v3, v5
            return v4
def zeros_input_14(v0 : i32, v1 : UH1) -> UH1:
    while True:
        v2 = 0 < v0
        if v2:
            del v2
            v3 = spiral_wrap(v0 - 1, 32, True)
            del v0
            v4 = US0_BitZero_shared
            v5 = UH1_InputCons(v4, v1)
            del v1, v4
            v0, v1 = v3, v5
            continue
        else:
            del v0, v2
            return v1
def loop_13(v0 : UH0, v1 : i32, v2 : i32, v3 : i32) -> i32:
    while True:
        v4 = v1 < v2
        if v4:
            del v0, v1, v2, v4
            return v3
        else:
            del v4
            v5 = UH1_InputEmpty_shared
            v6 = zeros_input_14(v2, v5)
            del v5
            v7 = accepts_2(v0, v6)
            del v6
            if v7:
                v8 = spiral_wrap(v3 + 1, 32, True)
                v9 = v8
            else:
                v9 = v3
            del v3, v7
            v10 = US0_BitOne_shared
            v11 = UH1_InputEmpty_shared
            v12 = UH1_InputCons(v10, v11)
            del v10, v11
            v13 = zeros_input_14(v2, v12)
            del v12
            v14 = accepts_2(v0, v13)
            del v13
            if v14:
                v15 = spiral_wrap(v9 + 1, 32, True)
                v16 = v15
            else:
                v16 = v9
            del v9, v14
            v17 = spiral_wrap(v2 + 1, 32, True)
            del v2
            v0, v1, v2, v3 = v0, v1, v17, v16
            continue
def backtrack_stack_16(v0 : UH2, v1 : UH1) -> bool:
    while True:
        match v0:
            case UH2_RegexListCons(v6, v7): # RegexListCons
                match v6:
                    case UH0_RegexAlt(v27, v28): # RegexAlt
                        del v0, v6
                        v29 = UH2_RegexListCons(v27, v7)
                        del v27
                        v30 = backtrack_stack_16(v29, v1)
                        del v29
                        if v30:
                            del v1, v7, v28, v30
                            return True
                        else:
                            del v30
                            v31 = UH2_RegexListCons(v28, v7)
                            del v7, v28
                            v0, v1 = v31, v1
                            continue
                    case UH0_RegexCat(v34, v35): # RegexCat
                        del v0, v6
                        v36 = UH2_RegexListCons(v35, v7)
                        del v7, v35
                        v37 = UH2_RegexListCons(v34, v36)
                        del v34, v36
                        v0, v1 = v37, v1
                        continue
                    case UH0_RegexChar(v9): # RegexChar
                        del v0, v6
                        match v1:
                            case UH1_InputCons(v10, v11): # InputCons
                                del v1
                                match v9:
                                    case US0_BitOne(): # BitOne
                                        match v10:
                                            case US0_BitOne(): # BitOne
                                                v21 = US1_SymbolSame_shared
                                            case US0_BitZero(): # BitZero
                                                v21 = US1_SymbolGreater_shared
                                            case t:
                                                raise Exception(f'Pattern matching miss. Got: {t}')
                                    case US0_BitZero(): # BitZero
                                        match v10:
                                            case US0_BitOne(): # BitOne
                                                v21 = US1_SymbolLess_shared
                                            case US0_BitZero(): # BitZero
                                                v21 = US1_SymbolSame_shared
                                            case t:
                                                raise Exception(f'Pattern matching miss. Got: {t}')
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                del v9, v10
                                match v21:
                                    case US1_SymbolSame(): # SymbolSame
                                        v22 = True
                                    case t:
                                        v22 = False
                                del v21
                                if v22:
                                    del v22
                                    v0, v1 = v7, v11
                                    continue
                                else:
                                    del v7, v11, v22
                                    return False
                            case UH1_InputEmpty(): # InputEmpty
                                del v1, v7, v9
                                return False
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case UH0_RegexEmpty(): # RegexEmpty
                        del v0, v1, v6, v7
                        return False
                    case UH0_RegexEpsilon(): # RegexEpsilon
                        del v0, v6
                        v0, v1 = v7, v1
                        continue
                    case UH0_RegexStar(v39): # RegexStar
                        del v6
                        v40 = UH2_RegexListCons(v39, v0)
                        del v0, v39
                        v41 = backtrack_stack_16(v40, v1)
                        del v40
                        if v41:
                            del v1, v7, v41
                            return True
                        else:
                            del v41
                            v0, v1 = v7, v1
                            continue
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case UH2_RegexListNil(): # RegexListNil
                del v0
                match v1:
                    case UH1_InputCons(_, _): # InputCons
                        del v1
                        return False
                    case UH1_InputEmpty(): # InputEmpty
                        del v1
                        return True
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_15(v0 : UH0, v1 : i32, v2 : i32, v3 : u64, v4 : i32) -> i32:
    while True:
        v5 = 0 < v2
        if v5:
            del v5
            v6 = UH1_InputEmpty_shared
            v7, v8 = random_bit_input_1(v3, v1, v6)
            del v3, v6
            v9 = UH2_RegexListNil_shared
            v10 = UH2_RegexListCons(v0, v9)
            del v9
            v11 = backtrack_stack_16(v10, v7)
            del v7, v10
            if v11:
                v12 = spiral_wrap(v4 + 1, 32, True)
                v13 = v12
            else:
                v13 = v4
            del v4, v11
            v14 = spiral_wrap(v2 - 1, 32, True)
            del v2
            v0, v1, v2, v3, v4 = v0, v1, v14, v8, v13
            continue
        else:
            del v0, v1, v2, v3, v5
            return v4
def loop_17(v0 : UH0, v1 : i32, v2 : i32, v3 : i32) -> i32:
    while True:
        v4 = v1 < v2
        if v4:
            del v0, v1, v2, v4
            return v3
        else:
            del v4
            v5 = UH1_InputEmpty_shared
            v6 = zeros_input_14(v2, v5)
            del v5
            v7 = UH2_RegexListNil_shared
            v8 = UH2_RegexListCons(v0, v7)
            del v7
            v9 = backtrack_stack_16(v8, v6)
            del v6, v8
            if v9:
                v10 = spiral_wrap(v3 + 1, 32, True)
                v11 = v10
            else:
                v11 = v3
            del v3, v9
            v12 = US0_BitOne_shared
            v13 = UH1_InputEmpty_shared
            v14 = UH1_InputCons(v12, v13)
            del v12, v13
            v15 = zeros_input_14(v2, v14)
            del v14
            v16 = UH2_RegexListNil_shared
            v17 = UH2_RegexListCons(v0, v16)
            del v16
            v18 = backtrack_stack_16(v17, v15)
            del v15, v17
            if v18:
                v19 = spiral_wrap(v11 + 1, 32, True)
                v20 = v19
            else:
                v20 = v11
            del v11, v18
            v21 = spiral_wrap(v2 + 1, 32, True)
            del v2
            v0, v1, v2, v3 = v0, v1, v21, v20
            continue
def run_19(v0 : i32, v1 : UH1) -> bool:
    while True:
        match v1:
            case UH1_InputCons(v3, v4): # InputCons
                del v0, v1
                match v3:
                    case US0_BitOne(): # BitOne
                        del v3
                        v9 = 0
                        v0, v1 = v9, v4
                        continue
                    case US0_BitZero(): # BitZero
                        del v3
                        v6 = 1
                        v0, v1 = v6, v4
                        continue
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case UH1_InputEmpty(): # InputEmpty
                del v1
                v2 = v0 == 1
                del v0
                return v2
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_18(v0 : i32, v1 : i32, v2 : u64, v3 : i32) -> i32:
    while True:
        v4 = 0 < v1
        if v4:
            del v4
            v5 = UH1_InputEmpty_shared
            v6, v7 = random_bit_input_1(v2, v0, v5)
            del v2, v5
            v8 = 0
            v9 = run_19(v8, v6)
            del v6, v8
            if v9:
                v10 = spiral_wrap(v3 + 1, 32, True)
                v11 = v10
            else:
                v11 = v3
            del v3, v9
            v12 = spiral_wrap(v1 - 1, 32, True)
            del v1
            v0, v1, v2, v3 = v0, v12, v7, v11
            continue
        else:
            del v0, v1, v2, v4
            return v3
def run_21(v0 : i32, v1 : UH1) -> bool:
    while True:
        match v1:
            case UH1_InputCons(v17, v18): # InputCons
                del v1
                match v17:
                    case US0_BitOne(): # BitOne
                        del v17
                        v50 = v0 == 0
                        if v50:
                            v79 = 1
                        else:
                            v51 = v0 == 1
                            if v51:
                                del v51
                                v79 = 6
                            else:
                                del v51
                                v52 = v0 == 2
                                if v52:
                                    del v52
                                    v79 = 11
                                else:
                                    del v52
                                    v53 = v0 == 3
                                    if v53:
                                        del v53
                                        v79 = 5
                                    else:
                                        del v53
                                        v54 = v0 == 4
                                        if v54:
                                            del v54
                                            v79 = 1
                                        else:
                                            del v54
                                            v55 = v0 == 5
                                            if v55:
                                                del v55
                                                v79 = 6
                                            else:
                                                del v55
                                                v56 = v0 == 6
                                                if v56:
                                                    del v56
                                                    v79 = 13
                                                else:
                                                    del v56
                                                    v57 = v0 == 7
                                                    if v57:
                                                        del v57
                                                        v79 = 9
                                                    else:
                                                        del v57
                                                        v58 = v0 == 8
                                                        if v58:
                                                            del v58
                                                            v79 = 5
                                                        else:
                                                            del v58
                                                            v59 = v0 == 9
                                                            if v59:
                                                                del v59
                                                                v79 = 12
                                                            else:
                                                                del v59
                                                                v60 = v0 == 10
                                                                if v60:
                                                                    del v60
                                                                    v79 = 11
                                                                else:
                                                                    del v60
                                                                    v61 = v0 == 11
                                                                    if v61:
                                                                        del v61
                                                                        v79 = 12
                                                                    else:
                                                                        del v61
                                                                        v62 = v0 == 12
                                                                        if v62:
                                                                            del v62
                                                                            v79 = 13
                                                                        else:
                                                                            del v62
                                                                            v63 = v0 == 13
                                                                            if v63:
                                                                                del v63
                                                                                v79 = 15
                                                                            else:
                                                                                del v63
                                                                                v64 = v0 == 14
                                                                                if v64:
                                                                                    del v64
                                                                                    v79 = 9
                                                                                else:
                                                                                    del v64
                                                                                    v79 = 15
                        del v0, v50
                        v0, v1 = v79, v18
                        continue
                    case US0_BitZero(): # BitZero
                        del v17
                        v19 = v0 == 0
                        if v19:
                            v48 = 0
                        else:
                            v20 = v0 == 1
                            if v20:
                                del v20
                                v48 = 2
                            else:
                                del v20
                                v21 = v0 == 2
                                if v21:
                                    del v21
                                    v48 = 3
                                else:
                                    del v21
                                    v22 = v0 == 3
                                    if v22:
                                        del v22
                                        v48 = 4
                                    else:
                                        del v22
                                        v23 = v0 == 4
                                        if v23:
                                            del v23
                                            v48 = 0
                                        else:
                                            del v23
                                            v24 = v0 == 5
                                            if v24:
                                                del v24
                                                v48 = 2
                                            else:
                                                del v24
                                                v25 = v0 == 6
                                                if v25:
                                                    del v25
                                                    v48 = 7
                                                else:
                                                    del v25
                                                    v26 = v0 == 7
                                                    if v26:
                                                        del v26
                                                        v48 = 8
                                                    else:
                                                        del v26
                                                        v27 = v0 == 8
                                                        if v27:
                                                            del v27
                                                            v48 = 4
                                                        else:
                                                            del v27
                                                            v28 = v0 == 9
                                                            if v28:
                                                                del v28
                                                                v48 = 10
                                                            else:
                                                                del v28
                                                                v29 = v0 == 10
                                                                if v29:
                                                                    del v29
                                                                    v48 = 3
                                                                else:
                                                                    del v29
                                                                    v30 = v0 == 11
                                                                    if v30:
                                                                        del v30
                                                                        v48 = 10
                                                                    else:
                                                                        del v30
                                                                        v31 = v0 == 12
                                                                        if v31:
                                                                            del v31
                                                                            v48 = 7
                                                                        else:
                                                                            del v31
                                                                            v32 = v0 == 13
                                                                            if v32:
                                                                                del v32
                                                                                v48 = 14
                                                                            else:
                                                                                del v32
                                                                                v33 = v0 == 14
                                                                                if v33:
                                                                                    del v33
                                                                                    v48 = 8
                                                                                else:
                                                                                    del v33
                                                                                    v48 = 14
                        del v0, v19
                        v0, v1 = v48, v18
                        continue
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case UH1_InputEmpty(): # InputEmpty
                del v1
                v2 = v0 == 4
                if v2:
                    del v0, v2
                    return True
                else:
                    del v2
                    v3 = v0 == 5
                    if v3:
                        del v0, v3
                        return True
                    else:
                        del v3
                        v4 = v0 == 8
                        if v4:
                            del v0, v4
                            return True
                        else:
                            del v4
                            v5 = v0 == 9
                            if v5:
                                del v0, v5
                                return True
                            else:
                                del v5
                                v6 = v0 == 10
                                if v6:
                                    del v0, v6
                                    return True
                                else:
                                    del v6
                                    v7 = v0 == 12
                                    if v7:
                                        del v0, v7
                                        return True
                                    else:
                                        del v7
                                        v8 = v0 == 14
                                        if v8:
                                            del v0, v8
                                            return True
                                        else:
                                            del v8
                                            v9 = v0 == 15
                                            del v0
                                            return v9
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_20(v0 : i32, v1 : i32, v2 : u64, v3 : i32) -> i32:
    while True:
        v4 = 0 < v1
        if v4:
            del v4
            v5 = UH1_InputEmpty_shared
            v6, v7 = random_bit_input_1(v2, v0, v5)
            del v2, v5
            v8 = 0
            v9 = run_21(v8, v6)
            del v6, v8
            if v9:
                v10 = spiral_wrap(v3 + 1, 32, True)
                v11 = v10
            else:
                v11 = v3
            del v3, v9
            v12 = spiral_wrap(v1 - 1, 32, True)
            del v1
            v0, v1, v2, v3 = v0, v12, v7, v11
            continue
        else:
            del v0, v1, v2, v4
            return v3
def run_23(v0 : i32, v1 : UH1) -> bool:
    while True:
        match v1:
            case UH1_InputCons(v3, v4): # InputCons
                del v1
                match v3:
                    case US0_BitOne(): # BitOne
                        del v3
                        v13 = v0 == 0
                        if v13:
                            v19 = 3
                        else:
                            v14 = v0 == 1
                            if v14:
                                del v14
                                v19 = 3
                            else:
                                del v14
                                v15 = v0 == 2
                                if v15:
                                    del v15
                                    v19 = 3
                                else:
                                    del v15
                                    v19 = 4
                        del v0, v13
                        v0, v1 = v19, v4
                        continue
                    case US0_BitZero(): # BitZero
                        del v3
                        v5 = v0 == 0
                        if v5:
                            v11 = 1
                        else:
                            v6 = v0 == 1
                            if v6:
                                del v6
                                v11 = 2
                            else:
                                del v6
                                v7 = v0 == 2
                                if v7:
                                    del v7
                                    v11 = 2
                                else:
                                    del v7
                                    v11 = 4
                        del v0, v5
                        v0, v1 = v11, v4
                        continue
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case UH1_InputEmpty(): # InputEmpty
                del v1
                v2 = v0 == 3
                del v0
                return v2
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_22(v0 : i32, v1 : i32, v2 : i32) -> i32:
    while True:
        v3 = v0 < v1
        if v3:
            del v0, v1, v3
            return v2
        else:
            del v3
            v4 = UH1_InputEmpty_shared
            v5 = zeros_input_14(v1, v4)
            del v4
            v6 = 0
            v7 = run_23(v6, v5)
            del v5, v6
            if v7:
                v8 = spiral_wrap(v2 + 1, 32, True)
                v9 = v8
            else:
                v9 = v2
            del v2, v7
            v10 = US0_BitOne_shared
            v11 = UH1_InputEmpty_shared
            v12 = UH1_InputCons(v10, v11)
            del v10, v11
            v13 = zeros_input_14(v1, v12)
            del v12
            v14 = 0
            v15 = run_23(v14, v13)
            del v13, v14
            if v15:
                v16 = spiral_wrap(v9 + 1, 32, True)
                v17 = v16
            else:
                v17 = v9
            del v9, v15
            v18 = spiral_wrap(v1 + 1, 32, True)
            del v1
            v0, v1, v2 = v0, v18, v17
            continue
def loop_24(v0 : cp.ndarray, v1 : i32) -> None:
    while True:
        v2 = v1 < 8192
        if v2:
            del v2
            v0[v1] = 0
            v3 = spiral_wrap(v1 + 1, 32, True)
            del v1
            v0, v1 = v0, v3
            continue
        else:
            del v0, v1, v2
            return 
def loop_25(v0 : cp.ndarray, v1 : i32) -> None:
    while True:
        v2 = v1 < 1
        if v2:
            del v2
            v0[v1] = 0
            v3 = spiral_wrap(v1 + 1, 32, True)
            del v1
            v0, v1 = v0, v3
            continue
        else:
            del v0, v1, v2
            return 
def probe_27(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : i32, v9 : i32, v10 : i32) -> i32:
    while True:
        v11 = spiral_array_index(v4, v10)
        v12 = v11 == 0
        if v12:
            del v5, v11, v12
            v13 = spiral_array_index(v6, 0)
            v14 = v13 < 4096
            if v14:
                del v14
                v0[v13] = v7
                del v0
                v1[v13] = v8
                del v1
                v2[v13] = v9
                del v2
                v15 = v7 == 1
                if v15:
                    v32 = True
                else:
                    v16 = v7 == 5
                    if v16:
                        del v16
                        v32 = True
                    else:
                        del v16
                        v17 = v7 == 3
                        if v17:
                            del v17
                            v18 = spiral_array_index(v3, v8)
                            v19 = v18 == 1
                            del v18
                            if v19:
                                del v19
                                v32 = True
                            else:
                                del v19
                                v20 = spiral_array_index(v3, v9)
                                v21 = v20 == 1
                                del v20
                                v32 = v21
                        else:
                            del v17
                            v23 = v7 == 4
                            if v23:
                                del v23
                                v24 = spiral_array_index(v3, v8)
                                v25 = v24 == 1
                                del v24
                                if v25:
                                    del v25
                                    v26 = spiral_array_index(v3, v9)
                                    v27 = v26 == 1
                                    del v26
                                    v32 = v27
                                else:
                                    del v25
                                    v32 = False
                            else:
                                del v23
                                v32 = False
                del v7, v8, v9, v15
                if v32:
                    v33 = 1
                else:
                    v33 = 0
                del v32
                v3[v13] = v33
                del v3, v33
                v34 = spiral_wrap(v13 + 1, 32, True)
                v4[v10] = v34
                del v4, v10
                v6[0] = v34
                del v6, v34
                return v13
            else:
                del v0, v1, v2, v3, v4, v6, v7, v8, v9, v10, v13, v14
                raise Exception("brzozowski-interned-store-full")
        else:
            del v12
            v37 = spiral_wrap(v11 - 1, 32, True)
            del v11
            v38 = spiral_array_index(v0, v37)
            v39 = v38 == v7
            del v38
            if v39:
                v40 = spiral_array_index(v1, v37)
                v41 = v40 == v8
                del v40
                v42 = v41
            else:
                v42 = False
            del v39
            if v42:
                v43 = spiral_array_index(v2, v37)
                v44 = v43 == v9
                del v43
                v45 = v44
            else:
                v45 = False
            del v42
            if v45:
                del v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v45
                return v37
            else:
                del v37, v45
                v46 = spiral_wrap(v10 + 1, 32, True)
                del v10
                v47 = v46 & 8191
                del v46
                v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10 = v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v47
                continue
def interned_node_26(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : i32, v9 : i32) -> i32:
    v10 = spiral_wrap(v7 * 1024, 32, True)
    v11 = spiral_wrap(v10 + v8, 32, True)
    del v10
    v12 = spiral_wrap(v11 * 4099, 32, True)
    del v11
    v13 = spiral_wrap(v12 + v9, 32, True)
    del v12
    v14 = v13 & 8191
    del v13
    return probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14)
def interned_alt_insert_30(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : i32) -> i32:
    v9 = v8 == 0
    if v9:
        del v0, v1, v2, v3, v4, v5, v6, v8, v9
        return v7
    else:
        del v9
        v10 = spiral_array_index(v0, v8)
        v11 = v10 == 3
        del v10
        if v11:
            del v11
            v12 = spiral_array_index(v1, v8)
            v13 = v7 < v12
            if v13:
                del v12, v13
                v14 = 3
                return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8)
            else:
                del v13
                v16 = v7 == v12
                if v16:
                    del v0, v1, v2, v3, v4, v5, v6, v7, v12, v16
                    return v8
                else:
                    del v16
                    v17 = 3
                    v18 = spiral_array_index(v2, v8)
                    del v8
                    v19 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v18)
                    del v7, v18
                    return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19)
        else:
            del v11
            v23 = v7 < v8
            if v23:
                del v23
                v24 = 3
                return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8)
            else:
                del v23
                v26 = v7 == v8
                if v26:
                    del v0, v1, v2, v3, v4, v5, v6, v7, v26
                    return v8
                else:
                    del v26
                    v27 = 3
                    return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7)
def interned_make_alt_29(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : i32) -> i32:
    while True:
        v9 = v7 == 0
        if v9:
            del v0, v1, v2, v3, v4, v5, v6, v7, v9
            return v8
        else:
            del v9
            v10 = spiral_array_index(v0, v7)
            v11 = v10 == 3
            del v10
            if v11:
                del v11
                v12 = spiral_array_index(v2, v7)
                v13 = spiral_array_index(v1, v7)
                del v7
                v14 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v13, v8)
                del v8, v13
                v0, v1, v2, v3, v4, v5, v6, v7, v8 = v0, v1, v2, v3, v4, v5, v6, v12, v14
                continue
            else:
                del v11
                return interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v8)
def interned_make_cat_31(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : i32) -> i32:
    v9 = v7 == 0
    if v9:
        del v0, v1, v2, v3, v4, v5, v6, v7, v8, v9
        return 0
    else:
        del v9
        v10 = v8 == 0
        if v10:
            del v0, v1, v2, v3, v4, v5, v6, v7, v8, v10
            return 0
        else:
            del v10
            v11 = v7 == 1
            if v11:
                del v0, v1, v2, v3, v4, v5, v6, v7, v11
                return v8
            else:
                del v11
                v12 = v8 == 1
                if v12:
                    del v0, v1, v2, v3, v4, v5, v6, v8, v12
                    return v7
                else:
                    del v12
                    v13 = spiral_array_index(v0, v7)
                    v14 = v13 == 5
                    del v13
                    if v14:
                        v15 = spiral_array_index(v0, v8)
                        v16 = v15 == 5
                        del v15
                        v17 = v16
                    else:
                        v17 = False
                    del v14
                    if v17:
                        del v17
                        v18 = spiral_array_index(v1, v7)
                        v19 = spiral_array_index(v1, v8)
                        v20 = v18 == v19
                        del v18, v19
                        if v20:
                            del v0, v1, v2, v3, v4, v5, v6, v8, v20
                            return v7
                        else:
                            del v20
                            v21 = 4
                            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8)
                    else:
                        del v17
                        v24 = spiral_array_index(v0, v7)
                        v25 = v24 == 4
                        del v24
                        if v25:
                            del v25
                            v26 = 4
                            v27 = spiral_array_index(v1, v7)
                            v28 = spiral_array_index(v2, v7)
                            del v7
                            v29 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v8)
                            del v8, v28
                            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29)
                        else:
                            del v25
                            v31 = 4
                            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8)
def interned_of_regex_raw_28(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : UH0) -> i32:
    match v7:
        case UH0_RegexAlt(v14, v15): # RegexAlt
            del v7
            v16 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v14)
            del v14
            v17 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v15)
            del v15
            return interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v16, v17)
        case UH0_RegexCat(v19, v20): # RegexCat
            del v7
            v21 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v19)
            del v19
            v22 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v20)
            del v20
            return interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v21, v22)
        case UH0_RegexChar(v8): # RegexChar
            del v7
            v9 = 2
            match v8:
                case US0_BitOne(): # BitOne
                    v11 = 1
                case US0_BitZero(): # BitZero
                    v11 = 0
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v8
            v12 = 0
            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12)
        case UH0_RegexEmpty(): # RegexEmpty
            del v0, v1, v2, v3, v4, v5, v6, v7
            return 0
        case UH0_RegexEpsilon(): # RegexEpsilon
            del v0, v1, v2, v3, v4, v5, v6, v7
            return 1
        case UH0_RegexStar(v24): # RegexStar
            del v7
            v25 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v24)
            del v24
            v26 = spiral_array_index(v0, v25)
            v27 = v26 < 2
            if v27:
                del v0, v1, v2, v3, v4, v5, v6, v25, v26, v27
                return 1
            else:
                del v27
                v28 = v26 == 5
                del v26
                if v28:
                    del v0, v1, v2, v3, v4, v5, v6, v28
                    return v25
                else:
                    del v28
                    v29 = 5
                    v30 = 0
                    return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def interned_derivative_raw_35(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : i32) -> i32:
    v9 = spiral_wrap(v7 * 2, 32, True)
    v10 = spiral_wrap(v9 + v8, 32, True)
    del v9
    v11 = spiral_array_index(v5, v10)
    v12 = v11 == 0
    if v12:
        del v11, v12
        v13 = spiral_array_index(v0, v7)
        v14 = v13 < 2
        if v14:
            v41 = 0
        else:
            v15 = v13 == 2
            if v15:
                del v15
                v16 = spiral_array_index(v1, v7)
                v17 = v16 == v8
                del v16
                if v17:
                    del v17
                    v41 = 1
                else:
                    del v17
                    v41 = 0
            else:
                del v15
                v19 = v13 == 3
                if v19:
                    del v19
                    v20 = spiral_array_index(v1, v7)
                    v21 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v20, v8)
                    del v20
                    v22 = spiral_array_index(v2, v7)
                    v23 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v22, v8)
                    del v22
                    v41 = interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v21, v23)
                else:
                    del v19
                    v25 = v13 == 4
                    if v25:
                        del v25
                        v26 = spiral_array_index(v1, v7)
                        v27 = spiral_array_index(v2, v7)
                        v28 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v26, v8)
                        v29 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v27)
                        del v28
                        v30 = spiral_array_index(v3, v26)
                        del v26
                        v31 = v30 == 1
                        del v30
                        if v31:
                            del v31
                            v32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v27, v8)
                            del v27
                            v41 = interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v29, v32)
                        else:
                            del v27, v31
                            v41 = v29
                    else:
                        del v25
                        v35 = spiral_array_index(v1, v7)
                        v36 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v35, v8)
                        del v35
                        v41 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v36, v7)
        del v0, v1, v2, v3, v4, v6, v7, v8, v13, v14
        v42 = spiral_wrap(v41 + 1, 32, True)
        v5[v10] = v42
        del v5, v10, v42
        return v41
    else:
        del v0, v1, v2, v3, v4, v5, v6, v7, v8, v10, v12
        v43 = spiral_wrap(v11 - 1, 32, True)
        del v11
        return v43
def loop_34(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : UH1) -> bool:
    while True:
        v9 = v7 == 0
        if v9:
            del v0, v1, v2, v3, v4, v5, v6, v7, v8, v9
            return False
        else:
            del v9
            match v8:
                case UH1_InputCons(v12, v13): # InputCons
                    del v8
                    match v12:
                        case US0_BitOne(): # BitOne
                            v15 = 1
                        case US0_BitZero(): # BitZero
                            v15 = 0
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v12
                    v16 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v7, v15)
                    del v7, v15
                    v0, v1, v2, v3, v4, v5, v6, v7, v8 = v0, v1, v2, v3, v4, v5, v6, v16, v13
                    continue
                case UH1_InputEmpty(): # InputEmpty
                    del v0, v1, v2, v4, v5, v6, v8
                    v10 = spiral_array_index(v3, v7)
                    del v3, v7
                    v11 = v10 == 1
                    del v10
                    return v11
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
def interned_accepts_33(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : UH1) -> bool:
    return loop_34(v0, v1, v2, v3, v4, v5, v6, v7, v8)
def loop_32(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : i32, v9 : i32, v10 : u64, v11 : i32) -> i32:
    while True:
        v12 = 0 < v9
        if v12:
            del v12
            v13 = UH1_InputEmpty_shared
            v14, v15 = random_bit_input_1(v10, v7, v13)
            del v10, v13
            v16 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v14)
            del v14
            if v16:
                v17 = spiral_wrap(v11 + 1, 32, True)
                v18 = v17
            else:
                v18 = v11
            del v11, v16
            v19 = spiral_wrap(v9 - 1, 32, True)
            del v9
            v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 = v0, v1, v2, v3, v4, v5, v6, v7, v8, v19, v15, v18
            continue
        else:
            del v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v12
            return v11
def loop_36(v0 : cp.ndarray, v1 : cp.ndarray, v2 : cp.ndarray, v3 : cp.ndarray, v4 : cp.ndarray, v5 : cp.ndarray, v6 : cp.ndarray, v7 : i32, v8 : i32, v9 : i32, v10 : i32) -> i32:
    while True:
        v11 = v7 < v9
        if v11:
            del v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v11
            return v10
        else:
            del v11
            v12 = UH1_InputEmpty_shared
            v13 = zeros_input_14(v9, v12)
            del v12
            v14 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v13)
            del v13
            if v14:
                v15 = spiral_wrap(v10 + 1, 32, True)
                v16 = v15
            else:
                v16 = v10
            del v10, v14
            v17 = US0_BitOne_shared
            v18 = UH1_InputEmpty_shared
            v19 = UH1_InputCons(v17, v18)
            del v17, v18
            v20 = zeros_input_14(v9, v19)
            del v19
            v21 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v20)
            del v20
            if v21:
                v22 = spiral_wrap(v16 + 1, 32, True)
                v23 = v22
            else:
                v23 = v16
            del v16, v21
            v24 = spiral_wrap(v9 + 1, 32, True)
            del v9
            v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10 = v0, v1, v2, v3, v4, v5, v6, v7, v8, v24, v23
            continue
def main():
    v0 = 200
    v1 = 32
    v2 = US0_BitZero_shared
    v3 = UH0_RegexChar(v2)
    del v2
    v4 = US0_BitOne_shared
    v5 = UH0_RegexChar(v4)
    del v4
    v6 = UH0_RegexAlt(v3, v5)
    del v3, v5
    v7 = UH0_RegexStar(v6)
    del v6
    v8 = US0_BitZero_shared
    v9 = UH0_RegexChar(v8)
    del v8
    v10 = UH0_RegexCat(v7, v9)
    del v7, v9
    v11 = US0_BitZero_shared
    v12 = UH0_RegexChar(v11)
    del v11
    v13 = US0_BitOne_shared
    v14 = UH0_RegexChar(v13)
    del v13
    v15 = UH0_RegexAlt(v12, v14)
    del v12, v14
    v16 = UH0_RegexStar(v15)
    del v15
    v17 = US0_BitOne_shared
    v18 = UH0_RegexChar(v17)
    del v17
    v19 = US0_BitZero_shared
    v20 = UH0_RegexChar(v19)
    del v19
    v21 = US0_BitOne_shared
    v22 = UH0_RegexChar(v21)
    del v21
    v23 = UH0_RegexAlt(v20, v22)
    del v20, v22
    v24 = US0_BitZero_shared
    v25 = UH0_RegexChar(v24)
    del v24
    v26 = US0_BitOne_shared
    v27 = UH0_RegexChar(v26)
    del v26
    v28 = UH0_RegexAlt(v25, v27)
    del v25, v27
    v29 = US0_BitZero_shared
    v30 = UH0_RegexChar(v29)
    del v29
    v31 = US0_BitOne_shared
    v32 = UH0_RegexChar(v31)
    del v31
    v33 = UH0_RegexAlt(v30, v32)
    del v30, v32
    v34 = UH0_RegexCat(v28, v33)
    del v28, v33
    v35 = UH0_RegexCat(v23, v34)
    del v23, v34
    v36 = UH0_RegexCat(v18, v35)
    del v18, v35
    v37 = UH0_RegexCat(v16, v36)
    del v16, v36
    v38 = 1
    v39 = 0
    v40 = loop_0(v10, v1, v0, v38, v39)
    del v10
    v41 = loop_0(v37, v1, v0, v38, v39)
    del v0, v1, v37, v38, v39
    v42 = 16
    v43 = US0_BitZero_shared
    v44 = UH0_RegexChar(v43)
    del v43
    v45 = US0_BitZero_shared
    v46 = UH0_RegexChar(v45)
    del v45
    v47 = US0_BitZero_shared
    v48 = UH0_RegexChar(v47)
    del v47
    v49 = UH0_RegexCat(v46, v48)
    del v46, v48
    v50 = UH0_RegexAlt(v44, v49)
    del v44, v49
    v51 = UH0_RegexStar(v50)
    del v50
    v52 = US0_BitOne_shared
    v53 = UH0_RegexChar(v52)
    del v52
    v54 = UH0_RegexCat(v51, v53)
    del v51, v53
    v55 = 0
    v56 = 1
    v57 = loop_13(v54, v42, v56, v55)
    del v42, v54, v55, v56
    v58 = 200
    v59 = 32
    v60 = US0_BitZero_shared
    v61 = UH0_RegexChar(v60)
    del v60
    v62 = US0_BitOne_shared
    v63 = UH0_RegexChar(v62)
    del v62
    v64 = UH0_RegexAlt(v61, v63)
    del v61, v63
    v65 = UH0_RegexStar(v64)
    del v64
    v66 = US0_BitZero_shared
    v67 = UH0_RegexChar(v66)
    del v66
    v68 = UH0_RegexCat(v65, v67)
    del v65, v67
    v69 = US0_BitZero_shared
    v70 = UH0_RegexChar(v69)
    del v69
    v71 = US0_BitOne_shared
    v72 = UH0_RegexChar(v71)
    del v71
    v73 = UH0_RegexAlt(v70, v72)
    del v70, v72
    v74 = UH0_RegexStar(v73)
    del v73
    v75 = US0_BitOne_shared
    v76 = UH0_RegexChar(v75)
    del v75
    v77 = US0_BitZero_shared
    v78 = UH0_RegexChar(v77)
    del v77
    v79 = US0_BitOne_shared
    v80 = UH0_RegexChar(v79)
    del v79
    v81 = UH0_RegexAlt(v78, v80)
    del v78, v80
    v82 = US0_BitZero_shared
    v83 = UH0_RegexChar(v82)
    del v82
    v84 = US0_BitOne_shared
    v85 = UH0_RegexChar(v84)
    del v84
    v86 = UH0_RegexAlt(v83, v85)
    del v83, v85
    v87 = US0_BitZero_shared
    v88 = UH0_RegexChar(v87)
    del v87
    v89 = US0_BitOne_shared
    v90 = UH0_RegexChar(v89)
    del v89
    v91 = UH0_RegexAlt(v88, v90)
    del v88, v90
    v92 = UH0_RegexCat(v86, v91)
    del v86, v91
    v93 = UH0_RegexCat(v81, v92)
    del v81, v92
    v94 = UH0_RegexCat(v76, v93)
    del v76, v93
    v95 = UH0_RegexCat(v74, v94)
    del v74, v94
    v96 = 1
    v97 = 0
    v98 = loop_15(v68, v59, v58, v96, v97)
    del v68
    v99 = loop_15(v95, v59, v58, v96, v97)
    del v58, v59, v95, v96, v97
    v100 = 16
    v101 = US0_BitZero_shared
    v102 = UH0_RegexChar(v101)
    del v101
    v103 = US0_BitZero_shared
    v104 = UH0_RegexChar(v103)
    del v103
    v105 = US0_BitZero_shared
    v106 = UH0_RegexChar(v105)
    del v105
    v107 = UH0_RegexCat(v104, v106)
    del v104, v106
    v108 = UH0_RegexAlt(v102, v107)
    del v102, v107
    v109 = UH0_RegexStar(v108)
    del v108
    v110 = US0_BitOne_shared
    v111 = UH0_RegexChar(v110)
    del v110
    v112 = UH0_RegexCat(v109, v111)
    del v109, v111
    v113 = 0
    v114 = 1
    v115 = loop_17(v112, v100, v114, v113)
    del v100, v112, v113, v114
    v116 = v40 == v98
    del v98
    if v116:
        v117 = v41 == v99
        v118 = v117
    else:
        v118 = False
    del v99, v116
    if v118:
        v119 = v57 == v115
        v120 = v119
    else:
        v120 = False
    del v115, v118
    if v120:
        pass
    else:
        raise Exception("brzozowski-bench-engines-disagree")
    del v120
    v121 = 200
    v122 = 32
    v123 = 1
    v124 = 0
    v125 = loop_18(v122, v121, v123, v124)
    v126 = loop_20(v122, v121, v123, v124)
    del v121, v122, v123, v124
    v127 = 16
    v128 = 0
    v129 = 1
    v130 = loop_22(v127, v129, v128)
    del v127, v128, v129
    v131 = v40 == v125
    del v125
    if v131:
        v132 = v41 == v126
        v133 = v132
    else:
        v133 = False
    del v126, v131
    if v133:
        v134 = v57 == v130
        v135 = v134
    else:
        v135 = False
    del v130, v133
    if v135:
        pass
    else:
        raise Exception("brzozowski-bench-engines-disagree")
    del v135
    v136 = 200
    v137 = 32
    v138 = cp.zeros(4096,dtype=cp.int32)
    v139 = cp.zeros(4096,dtype=cp.int32)
    v140 = cp.zeros(4096,dtype=cp.int32)
    v141 = cp.zeros(4096,dtype=cp.int32)
    v142 = cp.zeros(8192,dtype=cp.int32)
    v143 = cp.zeros(8192,dtype=cp.int32)
    v144 = cp.zeros(1,dtype=cp.int32)
    v145 = 0
    loop_24(v142, v145)
    del v145
    v146 = 0
    loop_24(v143, v146)
    del v146
    v147 = 0
    loop_25(v144, v147)
    del v147
    v148 = 0
    v149 = 0
    v150 = 0
    v151 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150)
    del v148, v149, v150
    v152 = 1
    v153 = 0
    v154 = 0
    v155 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154)
    del v152, v153, v154
    v156 = v151 == 0
    del v151
    if v156:
        v157 = v155 == 1
        v158 = v157
    else:
        v158 = False
    del v155, v156
    if v158:
        v166, v167, v168, v169, v170, v171, v172 = v138, v139, v140, v141, v142, v143, v144
    else:
        raise Exception("brzozowski-interned-store-init")
    del v138, v139, v140, v141, v142, v143, v144, v158
    v173 = US0_BitZero_shared
    v174 = UH0_RegexChar(v173)
    del v173
    v175 = US0_BitOne_shared
    v176 = UH0_RegexChar(v175)
    del v175
    v177 = UH0_RegexAlt(v174, v176)
    del v174, v176
    v178 = UH0_RegexStar(v177)
    del v177
    v179 = US0_BitZero_shared
    v180 = UH0_RegexChar(v179)
    del v179
    v181 = UH0_RegexCat(v178, v180)
    del v178, v180
    v182 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v181)
    del v181
    v183 = 1
    v184 = 0
    v185 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184)
    del v182, v183, v184
    v186 = US0_BitZero_shared
    v187 = UH0_RegexChar(v186)
    del v186
    v188 = US0_BitOne_shared
    v189 = UH0_RegexChar(v188)
    del v188
    v190 = UH0_RegexAlt(v187, v189)
    del v187, v189
    v191 = UH0_RegexStar(v190)
    del v190
    v192 = US0_BitOne_shared
    v193 = UH0_RegexChar(v192)
    del v192
    v194 = US0_BitZero_shared
    v195 = UH0_RegexChar(v194)
    del v194
    v196 = US0_BitOne_shared
    v197 = UH0_RegexChar(v196)
    del v196
    v198 = UH0_RegexAlt(v195, v197)
    del v195, v197
    v199 = US0_BitZero_shared
    v200 = UH0_RegexChar(v199)
    del v199
    v201 = US0_BitOne_shared
    v202 = UH0_RegexChar(v201)
    del v201
    v203 = UH0_RegexAlt(v200, v202)
    del v200, v202
    v204 = US0_BitZero_shared
    v205 = UH0_RegexChar(v204)
    del v204
    v206 = US0_BitOne_shared
    v207 = UH0_RegexChar(v206)
    del v206
    v208 = UH0_RegexAlt(v205, v207)
    del v205, v207
    v209 = UH0_RegexCat(v203, v208)
    del v203, v208
    v210 = UH0_RegexCat(v198, v209)
    del v198, v209
    v211 = UH0_RegexCat(v193, v210)
    del v193, v210
    v212 = UH0_RegexCat(v191, v211)
    del v191, v211
    v213 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v212)
    del v212
    v214 = 1
    v215 = 0
    v216 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215)
    del v136, v137, v166, v167, v168, v169, v170, v171, v172, v213, v214, v215
    v217 = 16
    v218 = cp.zeros(4096,dtype=cp.int32)
    v219 = cp.zeros(4096,dtype=cp.int32)
    v220 = cp.zeros(4096,dtype=cp.int32)
    v221 = cp.zeros(4096,dtype=cp.int32)
    v222 = cp.zeros(8192,dtype=cp.int32)
    v223 = cp.zeros(8192,dtype=cp.int32)
    v224 = cp.zeros(1,dtype=cp.int32)
    v225 = 0
    loop_24(v222, v225)
    del v225
    v226 = 0
    loop_24(v223, v226)
    del v226
    v227 = 0
    loop_25(v224, v227)
    del v227
    v228 = 0
    v229 = 0
    v230 = 0
    v231 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230)
    del v228, v229, v230
    v232 = 1
    v233 = 0
    v234 = 0
    v235 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234)
    del v232, v233, v234
    v236 = v231 == 0
    del v231
    if v236:
        v237 = v235 == 1
        v238 = v237
    else:
        v238 = False
    del v235, v236
    if v238:
        v246, v247, v248, v249, v250, v251, v252 = v218, v219, v220, v221, v222, v223, v224
    else:
        raise Exception("brzozowski-interned-store-init")
    del v218, v219, v220, v221, v222, v223, v224, v238
    v253 = US0_BitZero_shared
    v254 = UH0_RegexChar(v253)
    del v253
    v255 = US0_BitZero_shared
    v256 = UH0_RegexChar(v255)
    del v255
    v257 = US0_BitZero_shared
    v258 = UH0_RegexChar(v257)
    del v257
    v259 = UH0_RegexCat(v256, v258)
    del v256, v258
    v260 = UH0_RegexAlt(v254, v259)
    del v254, v259
    v261 = UH0_RegexStar(v260)
    del v260
    v262 = US0_BitOne_shared
    v263 = UH0_RegexChar(v262)
    del v262
    v264 = UH0_RegexCat(v261, v263)
    del v261, v263
    v265 = interned_of_regex_raw_28(v246, v247, v248, v249, v250, v251, v252, v264)
    del v264
    v266 = 1
    v267 = 0
    v268 = loop_36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267)
    del v217, v246, v247, v248, v249, v250, v251, v252, v265, v266, v267
    v269 = v40 == v185
    del v185
    if v269:
        v270 = v41 == v216
        v271 = v270
    else:
        v271 = False
    del v216, v269
    if v271:
        v272 = v57 == v268
        v273 = v272
    else:
        v273 = False
    del v268, v271
    if v273:
        pass
    else:
        raise Exception("brzozowski-bench-engines-disagree")
    del v273
    v274 = v57 == 16
    del v57
    if v274:
        pass
    else:
        raise Exception("brzozowski-bench-zero-runs-count")
    del v274
    v275 = v40 == 93
    del v40
    if v275:
        pass
    else:
        raise Exception("brzozowski-bench-ends-with-zero-count")
    del v275
    v276 = v41 == 97
    del v41
    if v276:
        pass
    else:
        raise Exception("brzozowski-bench-fourth-from-end-count")
    del v276
    return 0

if __name__ == '__main__': sys.exit(main())
