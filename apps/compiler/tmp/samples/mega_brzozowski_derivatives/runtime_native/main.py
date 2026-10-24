kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

UH0 = Union["UH0_InputEmpty", "UH0_InputCons"]
UH1 = Union["UH1_InputEmpty", "UH1_InputCons"]
UH2 = Union["UH2_RegexEmpty", "UH2_RegexEpsilon", "UH2_RegexChar", "UH2_RegexAlt", "UH2_RegexCat", "UH2_RegexStar"]
UH3 = Union["UH3_RegexEmpty", "UH3_RegexEpsilon", "UH3_RegexChar", "UH3_RegexAlt", "UH3_RegexCat", "UH3_RegexStar"]
class US0_BitZero(NamedTuple): # BitZero
    tag = 0
US0_BitZero_shared = US0_BitZero()
class US0_BitOne(NamedTuple): # BitOne
    tag = 1
US0_BitOne_shared = US0_BitOne()
US0 = Union[US0_BitZero, US0_BitOne]
class UH0_InputEmpty(NamedTuple): # InputEmpty
    tag = 0
UH0_InputEmpty_shared = UH0_InputEmpty()
class UH0_InputCons(NamedTuple): # InputCons
    v0 : US0
    v1 : UH0
    tag = 1
class US1_TriA(NamedTuple): # TriA
    tag = 0
US1_TriA_shared = US1_TriA()
class US1_TriB(NamedTuple): # TriB
    tag = 1
US1_TriB_shared = US1_TriB()
class US1_TriC(NamedTuple): # TriC
    tag = 2
US1_TriC_shared = US1_TriC()
US1 = Union[US1_TriA, US1_TriB, US1_TriC]
class UH1_InputEmpty(NamedTuple): # InputEmpty
    tag = 0
UH1_InputEmpty_shared = UH1_InputEmpty()
class UH1_InputCons(NamedTuple): # InputCons
    v0 : US1
    v1 : UH1
    tag = 1
class UH2_RegexEmpty(NamedTuple): # RegexEmpty
    tag = 0
UH2_RegexEmpty_shared = UH2_RegexEmpty()
class UH2_RegexEpsilon(NamedTuple): # RegexEpsilon
    tag = 1
UH2_RegexEpsilon_shared = UH2_RegexEpsilon()
class UH2_RegexChar(NamedTuple): # RegexChar
    v0 : US0
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
class US2_SymbolLess(NamedTuple): # SymbolLess
    tag = 0
US2_SymbolLess_shared = US2_SymbolLess()
class US2_SymbolSame(NamedTuple): # SymbolSame
    tag = 1
US2_SymbolSame_shared = US2_SymbolSame()
class US2_SymbolGreater(NamedTuple): # SymbolGreater
    tag = 2
US2_SymbolGreater_shared = US2_SymbolGreater()
US2 = Union[US2_SymbolLess, US2_SymbolSame, US2_SymbolGreater]
class US3_Nullable(NamedTuple): # Nullable
    tag = 0
US3_Nullable_shared = US3_Nullable()
class US3_NonNullable(NamedTuple): # NonNullable
    tag = 1
US3_NonNullable_shared = US3_NonNullable()
US3 = Union[US3_Nullable, US3_NonNullable]
class UH3_RegexEmpty(NamedTuple): # RegexEmpty
    tag = 0
UH3_RegexEmpty_shared = UH3_RegexEmpty()
class UH3_RegexEpsilon(NamedTuple): # RegexEpsilon
    tag = 1
UH3_RegexEpsilon_shared = UH3_RegexEpsilon()
class UH3_RegexChar(NamedTuple): # RegexChar
    v0 : US1
    tag = 2
class UH3_RegexAlt(NamedTuple): # RegexAlt
    v0 : UH3
    v1 : UH3
    tag = 3
class UH3_RegexCat(NamedTuple): # RegexCat
    v0 : UH3
    v1 : UH3
    tag = 4
class UH3_RegexStar(NamedTuple): # RegexStar
    v0 : UH3
    tag = 5
class US4_BitMatcherRaw(NamedTuple): # BitMatcherRaw
    v0 : UH2
    v1 : UH0
    tag = 0
US4 = US4_BitMatcherRaw
class US5_BitMatcherDecided(NamedTuple): # BitMatcherDecided
    v0 : UH2
    v1 : UH0
    v2 : bool
    tag = 1
US5 = US5_BitMatcherDecided
def regex_compare_5(v0 : UH2, v1 : UH2) -> US2:
    while True:
        match v0:
            case UH2_RegexAlt(v53, v54): # RegexAlt
                match v1:
                    case UH2_RegexAlt(v55, v56): # RegexAlt
                        v57 = regex_compare_5(v53, v55)
                        match v57:
                            case US2_SymbolSame(): # SymbolSame
                                v0, v1 = v54, v56
                                continue
                            case t:
                                return v57
                    case t:
                        return US2_SymbolGreater_shared
            case UH2_RegexCat(v28, v29): # RegexCat
                match v1:
                    case UH2_RegexCat(v34, v35): # RegexCat
                        v36 = regex_compare_5(v28, v34)
                        match v36:
                            case US2_SymbolSame(): # SymbolSame
                                v0, v1 = v29, v35
                                continue
                            case t:
                                return v36
                    case UH2_RegexChar(_): # RegexChar
                        return US2_SymbolGreater_shared
                    case UH2_RegexEmpty(): # RegexEmpty
                        return US2_SymbolGreater_shared
                    case UH2_RegexEpsilon(): # RegexEpsilon
                        return US2_SymbolGreater_shared
                    case t:
                        return US2_SymbolLess_shared
            case UH2_RegexChar(v10): # RegexChar
                match v1:
                    case UH2_RegexChar(v13): # RegexChar
                        match v10:
                            case US0_BitOne(): # BitOne
                                match v13:
                                    case US0_BitOne(): # BitOne
                                        return US2_SymbolSame_shared
                                    case US0_BitZero(): # BitZero
                                        return US2_SymbolGreater_shared
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case US0_BitZero(): # BitZero
                                match v13:
                                    case US0_BitOne(): # BitOne
                                        return US2_SymbolLess_shared
                                    case US0_BitZero(): # BitZero
                                        return US2_SymbolSame_shared
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case UH2_RegexEmpty(): # RegexEmpty
                        return US2_SymbolGreater_shared
                    case UH2_RegexEpsilon(): # RegexEpsilon
                        return US2_SymbolGreater_shared
                    case t:
                        return US2_SymbolLess_shared
            case UH2_RegexEmpty(): # RegexEmpty
                match v1:
                    case UH2_RegexEmpty(): # RegexEmpty
                        return US2_SymbolSame_shared
                    case t:
                        return US2_SymbolLess_shared
            case UH2_RegexEpsilon(): # RegexEpsilon
                match v1:
                    case UH2_RegexEmpty(): # RegexEmpty
                        return US2_SymbolGreater_shared
                    case UH2_RegexEpsilon(): # RegexEpsilon
                        return US2_SymbolSame_shared
                    case t:
                        return US2_SymbolLess_shared
            case UH2_RegexStar(v44): # RegexStar
                match v1:
                    case UH2_RegexAlt(_, _): # RegexAlt
                        return US2_SymbolLess_shared
                    case UH2_RegexStar(v48): # RegexStar
                        v0, v1 = v44, v48
                        continue
                    case t:
                        return US2_SymbolGreater_shared
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def alt_insert_sorted_4(v0 : UH2, v1 : UH2) -> UH2:
    match v1:
        case UH2_RegexAlt(v2, v3): # RegexAlt
            v4 = regex_compare_5(v0, v2)
            match v4:
                case US2_SymbolGreater(): # SymbolGreater
                    v6 = alt_insert_sorted_4(v0, v3)
                    return UH2_RegexAlt(v2, v6)
                case US2_SymbolLess(): # SymbolLess
                    return UH2_RegexAlt(v0, v1)
                case US2_SymbolSame(): # SymbolSame
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH2_RegexEmpty(): # RegexEmpty
            return v0
        case t:
            v11 = regex_compare_5(v0, v1)
            match v11:
                case US2_SymbolGreater(): # SymbolGreater
                    return UH2_RegexAlt(v1, v0)
                case US2_SymbolLess(): # SymbolLess
                    return UH2_RegexAlt(v0, v1)
                case US2_SymbolSame(): # SymbolSame
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
def make_alt_3(v0 : UH2, v1 : UH2) -> UH2:
    while True:
        match v0:
            case UH2_RegexAlt(v2, v3): # RegexAlt
                v4 = alt_insert_sorted_4(v2, v1)
                v0, v1 = v3, v4
                continue
            case UH2_RegexEmpty(): # RegexEmpty
                return v1
            case t:
                return alt_insert_sorted_4(v0, v1)
def regex_equal_7(v0 : UH2, v1 : UH2) -> bool:
    while True:
        match v0:
            case UH2_RegexAlt(v18, v19): # RegexAlt
                match v1:
                    case UH2_RegexAlt(v20, v21): # RegexAlt
                        v22 = regex_equal_7(v18, v20)
                        if v22:
                            v0, v1 = v19, v21
                            continue
                        else:
                            return False
                    case t:
                        return False
            case UH2_RegexCat(v26, v27): # RegexCat
                match v1:
                    case UH2_RegexCat(v28, v29): # RegexCat
                        v30 = regex_equal_7(v26, v28)
                        if v30:
                            v0, v1 = v27, v29
                            continue
                        else:
                            return False
                    case t:
                        return False
            case UH2_RegexChar(v4): # RegexChar
                match v1:
                    case UH2_RegexChar(v5): # RegexChar
                        match v4:
                            case US0_BitOne(): # BitOne
                                match v5:
                                    case US0_BitOne(): # BitOne
                                        v15 = US2_SymbolSame_shared
                                    case US0_BitZero(): # BitZero
                                        v15 = US2_SymbolGreater_shared
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case US0_BitZero(): # BitZero
                                match v5:
                                    case US0_BitOne(): # BitOne
                                        v15 = US2_SymbolLess_shared
                                    case US0_BitZero(): # BitZero
                                        v15 = US2_SymbolSame_shared
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        match v15:
                            case US2_SymbolSame(): # SymbolSame
                                return True
                            case t:
                                return False
                    case t:
                        return False
            case UH2_RegexEmpty(): # RegexEmpty
                match v1:
                    case UH2_RegexEmpty(): # RegexEmpty
                        return True
                    case t:
                        return False
            case UH2_RegexEpsilon(): # RegexEpsilon
                match v1:
                    case UH2_RegexEpsilon(): # RegexEpsilon
                        return True
                    case t:
                        return False
            case UH2_RegexStar(v34): # RegexStar
                match v1:
                    case UH2_RegexStar(v35): # RegexStar
                        v0, v1 = v34, v35
                        continue
                    case t:
                        return False
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def make_cat_6(v0 : UH2, v1 : UH2) -> UH2:
    match v0:
        case UH2_RegexEmpty(): # RegexEmpty
            return UH2_RegexEmpty_shared
        case t:
            match v1:
                case UH2_RegexEmpty(): # RegexEmpty
                    return UH2_RegexEmpty_shared
                case t:
                    match v0:
                        case UH2_RegexEpsilon(): # RegexEpsilon
                            return v1
                        case t:
                            match v1:
                                case UH2_RegexEpsilon(): # RegexEpsilon
                                    return v0
                                case t:
                                    match v0:
                                        case UH2_RegexCat(v12, v13): # RegexCat
                                            v14 = make_cat_6(v13, v1)
                                            return UH2_RegexCat(v12, v14)
                                        case UH2_RegexStar(v4): # RegexStar
                                            match v1:
                                                case UH2_RegexStar(v5): # RegexStar
                                                    v6 = regex_equal_7(v4, v5)
                                                    if v6:
                                                        return UH2_RegexStar(v4)
                                                    else:
                                                        return UH2_RegexCat(v0, v1)
                                                case t:
                                                    return UH2_RegexCat(v0, v1)
                                        case t:
                                            return UH2_RegexCat(v0, v1)
def make_star_8(v0 : UH2) -> UH2:
    match v0:
        case UH2_RegexEmpty(): # RegexEmpty
            return UH2_RegexEpsilon_shared
        case UH2_RegexEpsilon(): # RegexEpsilon
            return UH2_RegexEpsilon_shared
        case UH2_RegexStar(v3): # RegexStar
            return UH2_RegexStar(v3)
        case t:
            return UH2_RegexStar(v0)
def normalize_2(v0 : UH2) -> UH2:
    match v0:
        case UH2_RegexAlt(v5, v6): # RegexAlt
            v7 = normalize_2(v5)
            v8 = normalize_2(v6)
            return make_alt_3(v7, v8)
        case UH2_RegexCat(v10, v11): # RegexCat
            v12 = normalize_2(v10)
            v13 = normalize_2(v11)
            return make_cat_6(v12, v13)
        case UH2_RegexChar(v3): # RegexChar
            return UH2_RegexChar(v3)
        case UH2_RegexEmpty(): # RegexEmpty
            return UH2_RegexEmpty_shared
        case UH2_RegexEpsilon(): # RegexEpsilon
            return UH2_RegexEpsilon_shared
        case UH2_RegexStar(v15): # RegexStar
            v16 = normalize_2(v15)
            return make_star_8(v16)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def nullable_10(v0 : UH2) -> US3:
    match v0:
        case UH2_RegexAlt(v5, v6): # RegexAlt
            v7 = nullable_10(v5)
            v8 = nullable_10(v6)
            match v7:
                case US3_Nullable(): # Nullable
                    return US3_Nullable_shared
                case t:
                    match v8:
                        case US3_Nullable(): # Nullable
                            return US3_Nullable_shared
                        case t:
                            match v7:
                                case US3_NonNullable(): # NonNullable
                                    match v8:
                                        case US3_NonNullable(): # NonNullable
                                            return US3_NonNullable_shared
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH2_RegexCat(v16, v17): # RegexCat
            v18 = nullable_10(v16)
            v19 = nullable_10(v17)
            match v18:
                case US3_Nullable(): # Nullable
                    match v19:
                        case US3_Nullable(): # Nullable
                            return US3_Nullable_shared
                        case t:
                            return US3_NonNullable_shared
                case t:
                    return US3_NonNullable_shared
        case UH2_RegexChar(_): # RegexChar
            return US3_NonNullable_shared
        case UH2_RegexEmpty(): # RegexEmpty
            return US3_NonNullable_shared
        case UH2_RegexEpsilon(): # RegexEpsilon
            return US3_Nullable_shared
        case UH2_RegexStar(_): # RegexStar
            return US3_Nullable_shared
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def derivative_9(v0 : UH2, v1 : US0) -> UH2:
    match v0:
        case UH2_RegexAlt(v19, v20): # RegexAlt
            v21 = derivative_9(v19, v1)
            v22 = derivative_9(v20, v1)
            return make_alt_3(v21, v22)
        case UH2_RegexCat(v24, v25): # RegexCat
            v26 = nullable_10(v24)
            match v26:
                case US3_NonNullable(): # NonNullable
                    v31 = derivative_9(v24, v1)
                    return make_cat_6(v31, v25)
                case US3_Nullable(): # Nullable
                    v27 = derivative_9(v24, v1)
                    v28 = make_cat_6(v27, v25)
                    v29 = derivative_9(v25, v1)
                    return make_alt_3(v28, v29)
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH2_RegexChar(v4): # RegexChar
            match v4:
                case US0_BitOne(): # BitOne
                    match v1:
                        case US0_BitOne(): # BitOne
                            v14 = US2_SymbolSame_shared
                        case US0_BitZero(): # BitZero
                            v14 = US2_SymbolGreater_shared
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US0_BitZero(): # BitZero
                    match v1:
                        case US0_BitOne(): # BitOne
                            v14 = US2_SymbolLess_shared
                        case US0_BitZero(): # BitZero
                            v14 = US2_SymbolSame_shared
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            match v14:
                case US2_SymbolSame(): # SymbolSame
                    v15 = True
                case t:
                    v15 = False
            if v15:
                return UH2_RegexEpsilon_shared
            else:
                return UH2_RegexEmpty_shared
        case UH2_RegexEmpty(): # RegexEmpty
            return UH2_RegexEmpty_shared
        case UH2_RegexEpsilon(): # RegexEpsilon
            return UH2_RegexEmpty_shared
        case UH2_RegexStar(v35): # RegexStar
            v36 = derivative_9(v35, v1)
            v37 = make_star_8(v35)
            return make_cat_6(v36, v37)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def canonical_derivative_1(v0 : UH2, v1 : US0) -> UH2:
    v2 = normalize_2(v0)
    v3 = derivative_9(v2, v1)
    return normalize_2(v3)
def accepts_0(v0 : UH2, v1 : UH0) -> bool:
    while True:
        match v1:
            case UH0_InputCons(v6, v7): # InputCons
                v8 = canonical_derivative_1(v0, v6)
                v0, v1 = v8, v7
                continue
            case UH0_InputEmpty(): # InputEmpty
                v2 = normalize_2(v0)
                v3 = nullable_10(v2)
                match v3:
                    case US3_NonNullable(): # NonNullable
                        return False
                    case US3_Nullable(): # Nullable
                        return True
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def regex_compare_16(v0 : UH3, v1 : UH3) -> US2:
    while True:
        match v0:
            case UH3_RegexAlt(v59, v60): # RegexAlt
                match v1:
                    case UH3_RegexAlt(v61, v62): # RegexAlt
                        v63 = regex_compare_16(v59, v61)
                        match v63:
                            case US2_SymbolSame(): # SymbolSame
                                v0, v1 = v60, v62
                                continue
                            case t:
                                return v63
                    case t:
                        return US2_SymbolGreater_shared
            case UH3_RegexCat(v34, v35): # RegexCat
                match v1:
                    case UH3_RegexCat(v40, v41): # RegexCat
                        v42 = regex_compare_16(v34, v40)
                        match v42:
                            case US2_SymbolSame(): # SymbolSame
                                v0, v1 = v35, v41
                                continue
                            case t:
                                return v42
                    case UH3_RegexChar(_): # RegexChar
                        return US2_SymbolGreater_shared
                    case UH3_RegexEmpty(): # RegexEmpty
                        return US2_SymbolGreater_shared
                    case UH3_RegexEpsilon(): # RegexEpsilon
                        return US2_SymbolGreater_shared
                    case t:
                        return US2_SymbolLess_shared
            case UH3_RegexChar(v10): # RegexChar
                match v1:
                    case UH3_RegexChar(v13): # RegexChar
                        match v10:
                            case US1_TriA(): # TriA
                                match v13:
                                    case US1_TriA(): # TriA
                                        return US2_SymbolSame_shared
                                    case t:
                                        return US2_SymbolLess_shared
                            case t:
                                match v13:
                                    case US1_TriA(): # TriA
                                        return US2_SymbolGreater_shared
                                    case t:
                                        match v10:
                                            case US1_TriB(): # TriB
                                                match v13:
                                                    case US1_TriB(): # TriB
                                                        return US2_SymbolSame_shared
                                                    case US1_TriC(): # TriC
                                                        return US2_SymbolLess_shared
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case US1_TriC(): # TriC
                                                match v13:
                                                    case US1_TriB(): # TriB
                                                        return US2_SymbolGreater_shared
                                                    case US1_TriC(): # TriC
                                                        return US2_SymbolSame_shared
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case t:
                                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case UH3_RegexEmpty(): # RegexEmpty
                        return US2_SymbolGreater_shared
                    case UH3_RegexEpsilon(): # RegexEpsilon
                        return US2_SymbolGreater_shared
                    case t:
                        return US2_SymbolLess_shared
            case UH3_RegexEmpty(): # RegexEmpty
                match v1:
                    case UH3_RegexEmpty(): # RegexEmpty
                        return US2_SymbolSame_shared
                    case t:
                        return US2_SymbolLess_shared
            case UH3_RegexEpsilon(): # RegexEpsilon
                match v1:
                    case UH3_RegexEmpty(): # RegexEmpty
                        return US2_SymbolGreater_shared
                    case UH3_RegexEpsilon(): # RegexEpsilon
                        return US2_SymbolSame_shared
                    case t:
                        return US2_SymbolLess_shared
            case UH3_RegexStar(v50): # RegexStar
                match v1:
                    case UH3_RegexAlt(_, _): # RegexAlt
                        return US2_SymbolLess_shared
                    case UH3_RegexStar(v54): # RegexStar
                        v0, v1 = v50, v54
                        continue
                    case t:
                        return US2_SymbolGreater_shared
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def alt_insert_sorted_15(v0 : UH3, v1 : UH3) -> UH3:
    match v1:
        case UH3_RegexAlt(v2, v3): # RegexAlt
            v4 = regex_compare_16(v0, v2)
            match v4:
                case US2_SymbolGreater(): # SymbolGreater
                    v6 = alt_insert_sorted_15(v0, v3)
                    return UH3_RegexAlt(v2, v6)
                case US2_SymbolLess(): # SymbolLess
                    return UH3_RegexAlt(v0, v1)
                case US2_SymbolSame(): # SymbolSame
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH3_RegexEmpty(): # RegexEmpty
            return v0
        case t:
            v11 = regex_compare_16(v0, v1)
            match v11:
                case US2_SymbolGreater(): # SymbolGreater
                    return UH3_RegexAlt(v1, v0)
                case US2_SymbolLess(): # SymbolLess
                    return UH3_RegexAlt(v0, v1)
                case US2_SymbolSame(): # SymbolSame
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
def make_alt_14(v0 : UH3, v1 : UH3) -> UH3:
    while True:
        match v0:
            case UH3_RegexAlt(v2, v3): # RegexAlt
                v4 = alt_insert_sorted_15(v2, v1)
                v0, v1 = v3, v4
                continue
            case UH3_RegexEmpty(): # RegexEmpty
                return v1
            case t:
                return alt_insert_sorted_15(v0, v1)
def regex_equal_18(v0 : UH3, v1 : UH3) -> bool:
    while True:
        match v0:
            case UH3_RegexAlt(v24, v25): # RegexAlt
                match v1:
                    case UH3_RegexAlt(v26, v27): # RegexAlt
                        v28 = regex_equal_18(v24, v26)
                        if v28:
                            v0, v1 = v25, v27
                            continue
                        else:
                            return False
                    case t:
                        return False
            case UH3_RegexCat(v32, v33): # RegexCat
                match v1:
                    case UH3_RegexCat(v34, v35): # RegexCat
                        v36 = regex_equal_18(v32, v34)
                        if v36:
                            v0, v1 = v33, v35
                            continue
                        else:
                            return False
                    case t:
                        return False
            case UH3_RegexChar(v4): # RegexChar
                match v1:
                    case UH3_RegexChar(v5): # RegexChar
                        match v4:
                            case US1_TriA(): # TriA
                                match v5:
                                    case US1_TriA(): # TriA
                                        v21 = US2_SymbolSame_shared
                                    case t:
                                        v21 = US2_SymbolLess_shared
                            case t:
                                match v5:
                                    case US1_TriA(): # TriA
                                        v21 = US2_SymbolGreater_shared
                                    case t:
                                        match v4:
                                            case US1_TriB(): # TriB
                                                match v5:
                                                    case US1_TriB(): # TriB
                                                        v21 = US2_SymbolSame_shared
                                                    case US1_TriC(): # TriC
                                                        v21 = US2_SymbolLess_shared
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case US1_TriC(): # TriC
                                                match v5:
                                                    case US1_TriB(): # TriB
                                                        v21 = US2_SymbolGreater_shared
                                                    case US1_TriC(): # TriC
                                                        v21 = US2_SymbolSame_shared
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case t:
                                                raise Exception(f'Pattern matching miss. Got: {t}')
                        match v21:
                            case US2_SymbolSame(): # SymbolSame
                                return True
                            case t:
                                return False
                    case t:
                        return False
            case UH3_RegexEmpty(): # RegexEmpty
                match v1:
                    case UH3_RegexEmpty(): # RegexEmpty
                        return True
                    case t:
                        return False
            case UH3_RegexEpsilon(): # RegexEpsilon
                match v1:
                    case UH3_RegexEpsilon(): # RegexEpsilon
                        return True
                    case t:
                        return False
            case UH3_RegexStar(v40): # RegexStar
                match v1:
                    case UH3_RegexStar(v41): # RegexStar
                        v0, v1 = v40, v41
                        continue
                    case t:
                        return False
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def make_cat_17(v0 : UH3, v1 : UH3) -> UH3:
    match v0:
        case UH3_RegexEmpty(): # RegexEmpty
            return UH3_RegexEmpty_shared
        case t:
            match v1:
                case UH3_RegexEmpty(): # RegexEmpty
                    return UH3_RegexEmpty_shared
                case t:
                    match v0:
                        case UH3_RegexEpsilon(): # RegexEpsilon
                            return v1
                        case t:
                            match v1:
                                case UH3_RegexEpsilon(): # RegexEpsilon
                                    return v0
                                case t:
                                    match v0:
                                        case UH3_RegexCat(v12, v13): # RegexCat
                                            v14 = make_cat_17(v13, v1)
                                            return UH3_RegexCat(v12, v14)
                                        case UH3_RegexStar(v4): # RegexStar
                                            match v1:
                                                case UH3_RegexStar(v5): # RegexStar
                                                    v6 = regex_equal_18(v4, v5)
                                                    if v6:
                                                        return UH3_RegexStar(v4)
                                                    else:
                                                        return UH3_RegexCat(v0, v1)
                                                case t:
                                                    return UH3_RegexCat(v0, v1)
                                        case t:
                                            return UH3_RegexCat(v0, v1)
def make_star_19(v0 : UH3) -> UH3:
    match v0:
        case UH3_RegexEmpty(): # RegexEmpty
            return UH3_RegexEpsilon_shared
        case UH3_RegexEpsilon(): # RegexEpsilon
            return UH3_RegexEpsilon_shared
        case UH3_RegexStar(v3): # RegexStar
            return UH3_RegexStar(v3)
        case t:
            return UH3_RegexStar(v0)
def normalize_13(v0 : UH3) -> UH3:
    match v0:
        case UH3_RegexAlt(v5, v6): # RegexAlt
            v7 = normalize_13(v5)
            v8 = normalize_13(v6)
            return make_alt_14(v7, v8)
        case UH3_RegexCat(v10, v11): # RegexCat
            v12 = normalize_13(v10)
            v13 = normalize_13(v11)
            return make_cat_17(v12, v13)
        case UH3_RegexChar(v3): # RegexChar
            return UH3_RegexChar(v3)
        case UH3_RegexEmpty(): # RegexEmpty
            return UH3_RegexEmpty_shared
        case UH3_RegexEpsilon(): # RegexEpsilon
            return UH3_RegexEpsilon_shared
        case UH3_RegexStar(v15): # RegexStar
            v16 = normalize_13(v15)
            return make_star_19(v16)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def nullable_21(v0 : UH3) -> US3:
    match v0:
        case UH3_RegexAlt(v5, v6): # RegexAlt
            v7 = nullable_21(v5)
            v8 = nullable_21(v6)
            match v7:
                case US3_Nullable(): # Nullable
                    return US3_Nullable_shared
                case t:
                    match v8:
                        case US3_Nullable(): # Nullable
                            return US3_Nullable_shared
                        case t:
                            match v7:
                                case US3_NonNullable(): # NonNullable
                                    match v8:
                                        case US3_NonNullable(): # NonNullable
                                            return US3_NonNullable_shared
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH3_RegexCat(v16, v17): # RegexCat
            v18 = nullable_21(v16)
            v19 = nullable_21(v17)
            match v18:
                case US3_Nullable(): # Nullable
                    match v19:
                        case US3_Nullable(): # Nullable
                            return US3_Nullable_shared
                        case t:
                            return US3_NonNullable_shared
                case t:
                    return US3_NonNullable_shared
        case UH3_RegexChar(_): # RegexChar
            return US3_NonNullable_shared
        case UH3_RegexEmpty(): # RegexEmpty
            return US3_NonNullable_shared
        case UH3_RegexEpsilon(): # RegexEpsilon
            return US3_Nullable_shared
        case UH3_RegexStar(_): # RegexStar
            return US3_Nullable_shared
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def derivative_20(v0 : UH3, v1 : US1) -> UH3:
    match v0:
        case UH3_RegexAlt(v25, v26): # RegexAlt
            v27 = derivative_20(v25, v1)
            v28 = derivative_20(v26, v1)
            return make_alt_14(v27, v28)
        case UH3_RegexCat(v30, v31): # RegexCat
            v32 = nullable_21(v30)
            match v32:
                case US3_NonNullable(): # NonNullable
                    v37 = derivative_20(v30, v1)
                    return make_cat_17(v37, v31)
                case US3_Nullable(): # Nullable
                    v33 = derivative_20(v30, v1)
                    v34 = make_cat_17(v33, v31)
                    v35 = derivative_20(v31, v1)
                    return make_alt_14(v34, v35)
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH3_RegexChar(v4): # RegexChar
            match v4:
                case US1_TriA(): # TriA
                    match v1:
                        case US1_TriA(): # TriA
                            v20 = US2_SymbolSame_shared
                        case t:
                            v20 = US2_SymbolLess_shared
                case t:
                    match v1:
                        case US1_TriA(): # TriA
                            v20 = US2_SymbolGreater_shared
                        case t:
                            match v4:
                                case US1_TriB(): # TriB
                                    match v1:
                                        case US1_TriB(): # TriB
                                            v20 = US2_SymbolSame_shared
                                        case US1_TriC(): # TriC
                                            v20 = US2_SymbolLess_shared
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case US1_TriC(): # TriC
                                    match v1:
                                        case US1_TriB(): # TriB
                                            v20 = US2_SymbolGreater_shared
                                        case US1_TriC(): # TriC
                                            v20 = US2_SymbolSame_shared
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
            match v20:
                case US2_SymbolSame(): # SymbolSame
                    v21 = True
                case t:
                    v21 = False
            if v21:
                return UH3_RegexEpsilon_shared
            else:
                return UH3_RegexEmpty_shared
        case UH3_RegexEmpty(): # RegexEmpty
            return UH3_RegexEmpty_shared
        case UH3_RegexEpsilon(): # RegexEpsilon
            return UH3_RegexEmpty_shared
        case UH3_RegexStar(v41): # RegexStar
            v42 = derivative_20(v41, v1)
            v43 = make_star_19(v41)
            return make_cat_17(v42, v43)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def canonical_derivative_12(v0 : UH3, v1 : US1) -> UH3:
    v2 = normalize_13(v0)
    v3 = derivative_20(v2, v1)
    return normalize_13(v3)
def accepts_11(v0 : UH3, v1 : UH1) -> bool:
    while True:
        match v1:
            case UH1_InputCons(v6, v7): # InputCons
                v8 = canonical_derivative_12(v0, v6)
                v0, v1 = v8, v7
                continue
            case UH1_InputEmpty(): # InputEmpty
                v2 = normalize_13(v0)
                v3 = nullable_21(v2)
                match v3:
                    case US3_NonNullable(): # NonNullable
                        return False
                    case US3_Nullable(): # Nullable
                        return True
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def decide_bit_match_22(v0 : US4) -> US5:
    match v0:
        case US4_BitMatcherRaw(v1, v2): # BitMatcherRaw
            v3 = accepts_0(v1, v2)
            return US5_BitMatcherDecided(v1, v2, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def bit_match_value_23(v0 : US5) -> bool:
    match v0:
        case US5_BitMatcherDecided(_, _, v3): # BitMatcherDecided
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = US0_BitOne_shared
    v1 = US0_BitOne_shared
    v2 = US0_BitZero_shared
    v3 = UH0_InputEmpty_shared
    v4 = UH0_InputCons(v2, v3)
    v5 = UH0_InputCons(v1, v4)
    v6 = UH0_InputCons(v0, v5)
    v7 = US0_BitOne_shared
    v8 = US0_BitOne_shared
    v9 = US0_BitOne_shared
    v10 = UH0_InputEmpty_shared
    v11 = UH0_InputCons(v9, v10)
    v12 = UH0_InputCons(v8, v11)
    v13 = UH0_InputCons(v7, v12)
    v14 = US1_TriA_shared
    v15 = US1_TriA_shared
    v16 = US1_TriA_shared
    v17 = UH1_InputEmpty_shared
    v18 = UH1_InputCons(v16, v17)
    v19 = UH1_InputCons(v15, v18)
    v20 = UH1_InputCons(v14, v19)
    v21 = US1_TriA_shared
    v22 = US1_TriA_shared
    v23 = US1_TriB_shared
    v24 = UH1_InputEmpty_shared
    v25 = UH1_InputCons(v23, v24)
    v26 = UH1_InputCons(v22, v25)
    v27 = UH1_InputCons(v21, v26)
    v28 = US0_BitZero_shared
    v29 = UH2_RegexChar(v28)
    v30 = US0_BitOne_shared
    v31 = UH2_RegexChar(v30)
    v32 = UH2_RegexAlt(v29, v31)
    v33 = UH2_RegexStar(v32)
    v34 = US0_BitZero_shared
    v35 = UH2_RegexChar(v34)
    v36 = UH2_RegexCat(v33, v35)
    v37 = accepts_0(v36, v6)
    if v37:
        pass
    else:
        raise Exception("brzozowski-expected-true")
    v38 = US0_BitZero_shared
    v39 = UH2_RegexChar(v38)
    v40 = US0_BitOne_shared
    v41 = UH2_RegexChar(v40)
    v42 = UH2_RegexAlt(v39, v41)
    v43 = UH2_RegexStar(v42)
    v44 = US0_BitZero_shared
    v45 = UH2_RegexChar(v44)
    v46 = UH2_RegexCat(v43, v45)
    v47 = accepts_0(v46, v13)
    if v47:
        raise Exception("brzozowski-expected-false")
    else:
        pass
    v48 = US1_TriA_shared
    v49 = UH3_RegexChar(v48)
    v50 = UH3_RegexStar(v49)
    v51 = accepts_11(v50, v20)
    if v51:
        pass
    else:
        raise Exception("brzozowski-expected-true")
    v52 = US1_TriA_shared
    v53 = UH3_RegexChar(v52)
    v54 = UH3_RegexStar(v53)
    v55 = accepts_11(v54, v27)
    if v55:
        raise Exception("brzozowski-expected-false")
    else:
        pass
    v56 = US0_BitZero_shared
    v57 = UH2_RegexChar(v56)
    v58 = US0_BitOne_shared
    v59 = UH2_RegexChar(v58)
    v60 = UH2_RegexAlt(v57, v59)
    v61 = UH2_RegexStar(v60)
    v62 = US0_BitZero_shared
    v63 = UH2_RegexChar(v62)
    v64 = UH2_RegexCat(v61, v63)
    v65 = US4_BitMatcherRaw(v64, v6)
    v66 = decide_bit_match_22(v65)
    v67 = US0_BitZero_shared
    v68 = UH2_RegexChar(v67)
    v69 = US0_BitOne_shared
    v70 = UH2_RegexChar(v69)
    v71 = UH2_RegexAlt(v68, v70)
    v72 = UH2_RegexStar(v71)
    v73 = US0_BitZero_shared
    v74 = UH2_RegexChar(v73)
    v75 = UH2_RegexCat(v72, v74)
    v76 = US4_BitMatcherRaw(v75, v13)
    v77 = decide_bit_match_22(v76)
    v78 = bit_match_value_23(v66)
    if v78:
        pass
    else:
        raise Exception("brzozowski-expected-true")
    v79 = bit_match_value_23(v77)
    if v79:
        raise Exception("brzozowski-expected-false")
    else:
        pass
    return 0

if __name__ == '__main__': sys.exit(main())
