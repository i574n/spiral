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

UH0 = Union["UH0_SymbolListNil", "UH0_SymbolListCons"]
UH1 = Union["UH1_InputListNil", "UH1_InputListCons"]
UH2 = Union["UH2_InputEmpty", "UH2_InputCons"]
UH3 = Union["UH3_SymbolListNil", "UH3_SymbolListCons"]
UH4 = Union["UH4_InputListNil", "UH4_InputListCons"]
UH5 = Union["UH5_InputEmpty", "UH5_InputCons"]
UH6 = Union["UH6_InputEmpty", "UH6_InputCons"]
UH7 = Union["UH7_RegexEmpty", "UH7_RegexEpsilon", "UH7_RegexChar", "UH7_RegexAlt", "UH7_RegexCat", "UH7_RegexStar"]
UH8 = Union["UH8_RegexEmpty", "UH8_RegexEpsilon", "UH8_RegexChar", "UH8_RegexAlt", "UH8_RegexCat", "UH8_RegexStar"]
class US0_BitZero(NamedTuple): # BitZero
    tag = 0
class US0_BitOne(NamedTuple): # BitOne
    tag = 1
US0 = Union[US0_BitZero, US0_BitOne]
class UH0_SymbolListNil(NamedTuple): # SymbolListNil
    tag = 0
class UH0_SymbolListCons(NamedTuple): # SymbolListCons
    v0 : US0
    v1 : UH0
    tag = 1
class UH2_InputEmpty(NamedTuple): # InputEmpty
    tag = 0
class UH2_InputCons(NamedTuple): # InputCons
    v0 : US0
    v1 : UH2
    tag = 1
class UH1_InputListNil(NamedTuple): # InputListNil
    tag = 0
class UH1_InputListCons(NamedTuple): # InputListCons
    v0 : UH2
    v1 : UH1
    tag = 1
class US1_TriA(NamedTuple): # TriA
    tag = 0
class US1_TriB(NamedTuple): # TriB
    tag = 1
class US1_TriC(NamedTuple): # TriC
    tag = 2
US1 = Union[US1_TriA, US1_TriB, US1_TriC]
class UH3_SymbolListNil(NamedTuple): # SymbolListNil
    tag = 0
class UH3_SymbolListCons(NamedTuple): # SymbolListCons
    v0 : US1
    v1 : UH3
    tag = 1
class UH5_InputEmpty(NamedTuple): # InputEmpty
    tag = 0
class UH5_InputCons(NamedTuple): # InputCons
    v0 : US1
    v1 : UH5
    tag = 1
class UH4_InputListNil(NamedTuple): # InputListNil
    tag = 0
class UH4_InputListCons(NamedTuple): # InputListCons
    v0 : UH5
    v1 : UH4
    tag = 1
class US2_ModelA(NamedTuple): # ModelA
    tag = 0
class US2_ModelB(NamedTuple): # ModelB
    tag = 1
class US2_ModelC(NamedTuple): # ModelC
    tag = 2
US2 = Union[US2_ModelA, US2_ModelB, US2_ModelC]
class UH6_InputEmpty(NamedTuple): # InputEmpty
    tag = 0
class UH6_InputCons(NamedTuple): # InputCons
    v0 : US2
    v1 : UH6
    tag = 1
class UH7_RegexEmpty(NamedTuple): # RegexEmpty
    tag = 0
class UH7_RegexEpsilon(NamedTuple): # RegexEpsilon
    tag = 1
class UH7_RegexChar(NamedTuple): # RegexChar
    v0 : US0
    tag = 2
class UH7_RegexAlt(NamedTuple): # RegexAlt
    v0 : UH7
    v1 : UH7
    tag = 3
class UH7_RegexCat(NamedTuple): # RegexCat
    v0 : UH7
    v1 : UH7
    tag = 4
class UH7_RegexStar(NamedTuple): # RegexStar
    v0 : UH7
    tag = 5
class US3_InventoryDfaAccepted(NamedTuple): # InventoryDfaAccepted
    tag = 0
class US3_InventoryDfaRejected(NamedTuple): # InventoryDfaRejected
    tag = 1
class US3_InventoryDfaInputOutsideInventory(NamedTuple): # InventoryDfaInputOutsideInventory
    tag = 2
US3 = Union[US3_InventoryDfaAccepted, US3_InventoryDfaRejected, US3_InventoryDfaInputOutsideInventory]
class US4_SymbolLess(NamedTuple): # SymbolLess
    tag = 0
class US4_SymbolSame(NamedTuple): # SymbolSame
    tag = 1
class US4_SymbolGreater(NamedTuple): # SymbolGreater
    tag = 2
US4 = Union[US4_SymbolLess, US4_SymbolSame, US4_SymbolGreater]
class US5_Nullable(NamedTuple): # Nullable
    tag = 0
class US5_NonNullable(NamedTuple): # NonNullable
    tag = 1
US5 = Union[US5_Nullable, US5_NonNullable]
class UH8_RegexEmpty(NamedTuple): # RegexEmpty
    tag = 0
class UH8_RegexEpsilon(NamedTuple): # RegexEpsilon
    tag = 1
class UH8_RegexChar(NamedTuple): # RegexChar
    v0 : US1
    tag = 2
class UH8_RegexAlt(NamedTuple): # RegexAlt
    v0 : UH8
    v1 : UH8
    tag = 3
class UH8_RegexCat(NamedTuple): # RegexCat
    v0 : UH8
    v1 : UH8
    tag = 4
class UH8_RegexStar(NamedTuple): # RegexStar
    v0 : UH8
    tag = 5
def input_singletons_from_symbols_0(v0 : UH0) -> UH1:
    match v0:
        case UH0_SymbolListCons(v2, v3): # SymbolListCons
            del v0
            v4 = input_singletons_from_symbols_0(v3)
            del v3
            v5 = UH2_InputEmpty()
            v6 = UH2_InputCons(v2, v5)
            del v2, v5
            return UH1_InputListCons(v6, v4)
        case UH0_SymbolListNil(): # SymbolListNil
            del v0
            return UH1_InputListNil()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def input_list_append_2(v0 : UH1, v1 : UH1) -> UH1:
    match v0:
        case UH1_InputListCons(v2, v3): # InputListCons
            del v0
            v4 = input_list_append_2(v3, v1)
            del v1, v3
            return UH1_InputListCons(v2, v4)
        case UH1_InputListNil(): # InputListNil
            del v0
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def input_prepend_symbol_to_corpus_3(v0 : US0, v1 : UH1) -> UH1:
    match v1:
        case UH1_InputListCons(v3, v4): # InputListCons
            del v1
            v5 = input_prepend_symbol_to_corpus_3(v0, v4)
            del v4
            v6 = UH2_InputCons(v0, v3)
            del v0, v3
            return UH1_InputListCons(v6, v5)
        case UH1_InputListNil(): # InputListNil
            del v0, v1
            return UH1_InputListNil()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def input_prepend_symbols_to_corpus_1(v0 : UH0, v1 : UH1) -> UH1:
    match v0:
        case UH0_SymbolListCons(v3, v4): # SymbolListCons
            del v0
            v5 = input_prepend_symbol_to_corpus_3(v3, v1)
            del v3
            v6 = input_prepend_symbols_to_corpus_1(v4, v1)
            del v1, v4
            return input_list_append_2(v5, v6)
        case UH0_SymbolListNil(): # SymbolListNil
            del v0, v1
            return UH1_InputListNil()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def input_singletons_from_symbols_4(v0 : UH3) -> UH4:
    match v0:
        case UH3_SymbolListCons(v2, v3): # SymbolListCons
            del v0
            v4 = input_singletons_from_symbols_4(v3)
            del v3
            v5 = UH5_InputEmpty()
            v6 = UH5_InputCons(v2, v5)
            del v2, v5
            return UH4_InputListCons(v6, v4)
        case UH3_SymbolListNil(): # SymbolListNil
            del v0
            return UH4_InputListNil()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def input_list_append_6(v0 : UH4, v1 : UH4) -> UH4:
    match v0:
        case UH4_InputListCons(v2, v3): # InputListCons
            del v0
            v4 = input_list_append_6(v3, v1)
            del v1, v3
            return UH4_InputListCons(v2, v4)
        case UH4_InputListNil(): # InputListNil
            del v0
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def input_prepend_symbol_to_corpus_7(v0 : US1, v1 : UH4) -> UH4:
    match v1:
        case UH4_InputListCons(v3, v4): # InputListCons
            del v1
            v5 = input_prepend_symbol_to_corpus_7(v0, v4)
            del v4
            v6 = UH5_InputCons(v0, v3)
            del v0, v3
            return UH4_InputListCons(v6, v5)
        case UH4_InputListNil(): # InputListNil
            del v0, v1
            return UH4_InputListNil()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def input_prepend_symbols_to_corpus_5(v0 : UH3, v1 : UH4) -> UH4:
    match v0:
        case UH3_SymbolListCons(v3, v4): # SymbolListCons
            del v0
            v5 = input_prepend_symbol_to_corpus_7(v3, v1)
            del v3
            v6 = input_prepend_symbols_to_corpus_5(v4, v1)
            del v1, v4
            return input_list_append_6(v5, v6)
        case UH3_SymbolListNil(): # SymbolListNil
            del v0, v1
            return UH4_InputListNil()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def loop_9(v0 : i32, v1 : UH2) -> US3:
    while True:
        match v1:
            case UH2_InputCons(v6, v7): # InputCons
                del v1
                match v6:
                    case US0_BitOne(): # BitOne
                        v11 = US4_SymbolGreater()
                    case US0_BitZero(): # BitZero
                        v11 = US4_SymbolSame()
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                match v11:
                    case US4_SymbolSame(): # SymbolSame
                        v12 = True
                    case t:
                        v12 = False
                del v11
                if v12:
                    v19 = 0
                else:
                    match v6:
                        case US0_BitOne(): # BitOne
                            v16 = US4_SymbolSame()
                        case US0_BitZero(): # BitZero
                            v16 = US4_SymbolLess()
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    match v16:
                        case US4_SymbolSame(): # SymbolSame
                            v17 = True
                        case t:
                            v17 = False
                    del v16
                    if v17:
                        del v17
                        v19 = 1
                    else:
                        del v17
                        v19 = -1
                del v6, v12
                v20 = v19 < 0
                if v20:
                    del v0, v7, v19, v20
                    return US3_InventoryDfaInputOutsideInventory()
                else:
                    del v20
                    v22 = v0 == 0
                    del v0
                    if v22:
                        v23 = v19 == 0
                        if v23:
                            del v23
                            v27 = 0
                        else:
                            del v23
                            v27 = 1
                    else:
                        v25 = v19 == 0
                        if v25:
                            del v25
                            v27 = 0
                        else:
                            del v25
                            v27 = 1
                    del v19, v22
                    v0, v1 = v27, v7
                    continue
            case UH2_InputEmpty(): # InputEmpty
                del v1
                v2 = v0 == 0
                del v0
                if v2:
                    del v2
                    return US3_InventoryDfaAccepted()
                else:
                    del v2
                    return US3_InventoryDfaRejected()
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def regex_compare_15(v0 : UH7, v1 : UH7) -> US4:
    while True:
        match v0:
            case UH7_RegexAlt(v53, v54): # RegexAlt
                del v0
                match v1:
                    case UH7_RegexAlt(v55, v56): # RegexAlt
                        del v1
                        v57 = regex_compare_15(v53, v55)
                        del v53, v55
                        match v57:
                            case US4_SymbolSame(): # SymbolSame
                                del v57
                                v0, v1 = v54, v56
                                continue
                            case t:
                                del v54, v56
                                return v57
                    case t:
                        del v1, v53, v54
                        return US4_SymbolGreater()
            case UH7_RegexCat(v28, v29): # RegexCat
                del v0
                match v1:
                    case UH7_RegexCat(v34, v35): # RegexCat
                        del v1
                        v36 = regex_compare_15(v28, v34)
                        del v28, v34
                        match v36:
                            case US4_SymbolSame(): # SymbolSame
                                del v36
                                v0, v1 = v29, v35
                                continue
                            case t:
                                del v29, v35
                                return v36
                    case UH7_RegexChar(_): # RegexChar
                        del v1, v28, v29
                        return US4_SymbolGreater()
                    case UH7_RegexEmpty(): # RegexEmpty
                        del v1, v28, v29
                        return US4_SymbolGreater()
                    case UH7_RegexEpsilon(): # RegexEpsilon
                        del v1, v28, v29
                        return US4_SymbolGreater()
                    case t:
                        del v1, v28, v29
                        return US4_SymbolLess()
            case UH7_RegexChar(v10): # RegexChar
                del v0
                match v1:
                    case UH7_RegexChar(v13): # RegexChar
                        del v1
                        match v10:
                            case US0_BitOne(): # BitOne
                                del v10
                                match v13:
                                    case US0_BitOne(): # BitOne
                                        del v13
                                        return US4_SymbolSame()
                                    case US0_BitZero(): # BitZero
                                        del v13
                                        return US4_SymbolGreater()
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case US0_BitZero(): # BitZero
                                del v10
                                match v13:
                                    case US0_BitOne(): # BitOne
                                        del v13
                                        return US4_SymbolLess()
                                    case US0_BitZero(): # BitZero
                                        del v13
                                        return US4_SymbolSame()
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case UH7_RegexEmpty(): # RegexEmpty
                        del v1, v10
                        return US4_SymbolGreater()
                    case UH7_RegexEpsilon(): # RegexEpsilon
                        del v1, v10
                        return US4_SymbolGreater()
                    case t:
                        del v1, v10
                        return US4_SymbolLess()
            case UH7_RegexEmpty(): # RegexEmpty
                del v0
                match v1:
                    case UH7_RegexEmpty(): # RegexEmpty
                        del v1
                        return US4_SymbolSame()
                    case t:
                        del v1
                        return US4_SymbolLess()
            case UH7_RegexEpsilon(): # RegexEpsilon
                del v0
                match v1:
                    case UH7_RegexEmpty(): # RegexEmpty
                        del v1
                        return US4_SymbolGreater()
                    case UH7_RegexEpsilon(): # RegexEpsilon
                        del v1
                        return US4_SymbolSame()
                    case t:
                        del v1
                        return US4_SymbolLess()
            case UH7_RegexStar(v44): # RegexStar
                del v0
                match v1:
                    case UH7_RegexAlt(_, _): # RegexAlt
                        del v1, v44
                        return US4_SymbolLess()
                    case UH7_RegexStar(v48): # RegexStar
                        del v1
                        v0, v1 = v44, v48
                        continue
                    case t:
                        del v1, v44
                        return US4_SymbolGreater()
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def alt_insert_sorted_14(v0 : UH7, v1 : UH7) -> UH7:
    match v1:
        case UH7_RegexAlt(v2, v3): # RegexAlt
            v4 = regex_compare_15(v0, v2)
            match v4:
                case US4_SymbolGreater(): # SymbolGreater
                    del v1, v4
                    v6 = alt_insert_sorted_14(v0, v3)
                    del v0, v3
                    return UH7_RegexAlt(v2, v6)
                case US4_SymbolLess(): # SymbolLess
                    del v2, v3, v4
                    return UH7_RegexAlt(v0, v1)
                case US4_SymbolSame(): # SymbolSame
                    del v0, v2, v3, v4
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH7_RegexEmpty(): # RegexEmpty
            del v1
            return v0
        case t:
            v11 = regex_compare_15(v0, v1)
            match v11:
                case US4_SymbolGreater(): # SymbolGreater
                    del v11
                    return UH7_RegexAlt(v1, v0)
                case US4_SymbolLess(): # SymbolLess
                    del v11
                    return UH7_RegexAlt(v0, v1)
                case US4_SymbolSame(): # SymbolSame
                    del v0, v11
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
def make_alt_13(v0 : UH7, v1 : UH7) -> UH7:
    while True:
        match v0:
            case UH7_RegexAlt(v2, v3): # RegexAlt
                del v0
                v4 = alt_insert_sorted_14(v2, v1)
                del v1, v2
                v0, v1 = v3, v4
                continue
            case UH7_RegexEmpty(): # RegexEmpty
                del v0
                return v1
            case t:
                return alt_insert_sorted_14(v0, v1)
def regex_equal_17(v0 : UH7, v1 : UH7) -> bool:
    while True:
        match v0:
            case UH7_RegexAlt(v18, v19): # RegexAlt
                del v0
                match v1:
                    case UH7_RegexAlt(v20, v21): # RegexAlt
                        del v1
                        v22 = regex_equal_17(v18, v20)
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
            case UH7_RegexCat(v26, v27): # RegexCat
                del v0
                match v1:
                    case UH7_RegexCat(v28, v29): # RegexCat
                        del v1
                        v30 = regex_equal_17(v26, v28)
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
            case UH7_RegexChar(v4): # RegexChar
                del v0
                match v1:
                    case UH7_RegexChar(v5): # RegexChar
                        del v1
                        match v4:
                            case US0_BitOne(): # BitOne
                                match v5:
                                    case US0_BitOne(): # BitOne
                                        v15 = US4_SymbolSame()
                                    case US0_BitZero(): # BitZero
                                        v15 = US4_SymbolGreater()
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case US0_BitZero(): # BitZero
                                match v5:
                                    case US0_BitOne(): # BitOne
                                        v15 = US4_SymbolLess()
                                    case US0_BitZero(): # BitZero
                                        v15 = US4_SymbolSame()
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v4, v5
                        match v15:
                            case US4_SymbolSame(): # SymbolSame
                                del v15
                                return True
                            case t:
                                del v15
                                return False
                    case t:
                        del v1, v4
                        return False
            case UH7_RegexEmpty(): # RegexEmpty
                del v0
                match v1:
                    case UH7_RegexEmpty(): # RegexEmpty
                        del v1
                        return True
                    case t:
                        del v1
                        return False
            case UH7_RegexEpsilon(): # RegexEpsilon
                del v0
                match v1:
                    case UH7_RegexEpsilon(): # RegexEpsilon
                        del v1
                        return True
                    case t:
                        del v1
                        return False
            case UH7_RegexStar(v34): # RegexStar
                del v0
                match v1:
                    case UH7_RegexStar(v35): # RegexStar
                        del v1
                        v0, v1 = v34, v35
                        continue
                    case t:
                        del v1, v34
                        return False
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def make_cat_16(v0 : UH7, v1 : UH7) -> UH7:
    match v0:
        case UH7_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH7_RegexEmpty()
        case t:
            match v1:
                case UH7_RegexEmpty(): # RegexEmpty
                    del v0, v1
                    return UH7_RegexEmpty()
                case t:
                    match v0:
                        case UH7_RegexEpsilon(): # RegexEpsilon
                            del v0
                            return v1
                        case t:
                            match v1:
                                case UH7_RegexEpsilon(): # RegexEpsilon
                                    del v1
                                    return v0
                                case t:
                                    match v0:
                                        case UH7_RegexCat(v12, v13): # RegexCat
                                            del v0
                                            v14 = make_cat_16(v13, v1)
                                            del v1, v13
                                            return UH7_RegexCat(v12, v14)
                                        case UH7_RegexStar(v4): # RegexStar
                                            match v1:
                                                case UH7_RegexStar(v5): # RegexStar
                                                    v6 = regex_equal_17(v4, v5)
                                                    del v5
                                                    if v6:
                                                        del v0, v1, v6
                                                        return UH7_RegexStar(v4)
                                                    else:
                                                        del v4, v6
                                                        return UH7_RegexCat(v0, v1)
                                                case t:
                                                    del v4
                                                    return UH7_RegexCat(v0, v1)
                                        case t:
                                            return UH7_RegexCat(v0, v1)
def make_star_18(v0 : UH7) -> UH7:
    match v0:
        case UH7_RegexEmpty(): # RegexEmpty
            del v0
            return UH7_RegexEpsilon()
        case UH7_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH7_RegexEpsilon()
        case UH7_RegexStar(v3): # RegexStar
            del v0
            return UH7_RegexStar(v3)
        case t:
            return UH7_RegexStar(v0)
def normalize_12(v0 : UH7) -> UH7:
    match v0:
        case UH7_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = normalize_12(v5)
            del v5
            v8 = normalize_12(v6)
            del v6
            return make_alt_13(v7, v8)
        case UH7_RegexCat(v10, v11): # RegexCat
            del v0
            v12 = normalize_12(v10)
            del v10
            v13 = normalize_12(v11)
            del v11
            return make_cat_16(v12, v13)
        case UH7_RegexChar(v3): # RegexChar
            del v0
            return UH7_RegexChar(v3)
        case UH7_RegexEmpty(): # RegexEmpty
            del v0
            return UH7_RegexEmpty()
        case UH7_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH7_RegexEpsilon()
        case UH7_RegexStar(v15): # RegexStar
            del v0
            v16 = normalize_12(v15)
            del v15
            return make_star_18(v16)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def nullable_20(v0 : UH7) -> US5:
    match v0:
        case UH7_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = nullable_20(v5)
            del v5
            v8 = nullable_20(v6)
            del v6
            match v7:
                case US5_Nullable(): # Nullable
                    del v7, v8
                    return US5_Nullable()
                case t:
                    match v8:
                        case US5_Nullable(): # Nullable
                            del v7, v8
                            return US5_Nullable()
                        case t:
                            match v7:
                                case US5_NonNullable(): # NonNullable
                                    del v7
                                    match v8:
                                        case US5_NonNullable(): # NonNullable
                                            del v8
                                            return US5_NonNullable()
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH7_RegexCat(v16, v17): # RegexCat
            del v0
            v18 = nullable_20(v16)
            del v16
            v19 = nullable_20(v17)
            del v17
            match v18:
                case US5_Nullable(): # Nullable
                    del v18
                    match v19:
                        case US5_Nullable(): # Nullable
                            del v19
                            return US5_Nullable()
                        case t:
                            del v19
                            return US5_NonNullable()
                case t:
                    del v18, v19
                    return US5_NonNullable()
        case UH7_RegexChar(_): # RegexChar
            del v0
            return US5_NonNullable()
        case UH7_RegexEmpty(): # RegexEmpty
            del v0
            return US5_NonNullable()
        case UH7_RegexEpsilon(): # RegexEpsilon
            del v0
            return US5_Nullable()
        case UH7_RegexStar(_): # RegexStar
            del v0
            return US5_Nullable()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def derivative_19(v0 : UH7, v1 : US0) -> UH7:
    match v0:
        case UH7_RegexAlt(v19, v20): # RegexAlt
            del v0
            v21 = derivative_19(v19, v1)
            del v19
            v22 = derivative_19(v20, v1)
            del v1, v20
            return make_alt_13(v21, v22)
        case UH7_RegexCat(v24, v25): # RegexCat
            del v0
            v26 = nullable_20(v24)
            match v26:
                case US5_NonNullable(): # NonNullable
                    del v26
                    v31 = derivative_19(v24, v1)
                    del v1, v24
                    return make_cat_16(v31, v25)
                case US5_Nullable(): # Nullable
                    del v26
                    v27 = derivative_19(v24, v1)
                    del v24
                    v28 = make_cat_16(v27, v25)
                    del v27
                    v29 = derivative_19(v25, v1)
                    del v1, v25
                    return make_alt_13(v28, v29)
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH7_RegexChar(v4): # RegexChar
            del v0
            match v4:
                case US0_BitOne(): # BitOne
                    match v1:
                        case US0_BitOne(): # BitOne
                            v14 = US4_SymbolSame()
                        case US0_BitZero(): # BitZero
                            v14 = US4_SymbolGreater()
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US0_BitZero(): # BitZero
                    match v1:
                        case US0_BitOne(): # BitOne
                            v14 = US4_SymbolLess()
                        case US0_BitZero(): # BitZero
                            v14 = US4_SymbolSame()
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v1, v4
            match v14:
                case US4_SymbolSame(): # SymbolSame
                    v15 = True
                case t:
                    v15 = False
            del v14
            if v15:
                del v15
                return UH7_RegexEpsilon()
            else:
                del v15
                return UH7_RegexEmpty()
        case UH7_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH7_RegexEmpty()
        case UH7_RegexEpsilon(): # RegexEpsilon
            del v0, v1
            return UH7_RegexEmpty()
        case UH7_RegexStar(v35): # RegexStar
            del v0
            v36 = derivative_19(v35, v1)
            del v1
            v37 = make_star_18(v35)
            del v35
            return make_cat_16(v36, v37)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def canonical_derivative_11(v0 : UH7, v1 : US0) -> UH7:
    v2 = normalize_12(v0)
    del v0
    v3 = derivative_19(v2, v1)
    del v1, v2
    return normalize_12(v3)
def accepts_10(v0 : UH7, v1 : UH2) -> bool:
    while True:
        match v1:
            case UH2_InputCons(v6, v7): # InputCons
                del v1
                v8 = canonical_derivative_11(v0, v6)
                del v0, v6
                v0, v1 = v8, v7
                continue
            case UH2_InputEmpty(): # InputEmpty
                del v1
                v2 = normalize_12(v0)
                del v0
                v3 = nullable_20(v2)
                del v2
                match v3:
                    case US5_NonNullable(): # NonNullable
                        del v3
                        return False
                    case US5_Nullable(): # Nullable
                        del v3
                        return True
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_8(v0 : UH7, v1 : UH1) -> bool:
    while True:
        match v1:
            case UH1_InputListCons(v2, v3): # InputListCons
                del v1
                v4 = 1
                v5 = loop_9(v4, v2)
                del v4
                match v5:
                    case US3_InventoryDfaAccepted(): # InventoryDfaAccepted
                        v11 = accepts_10(v0, v2)
                    case US3_InventoryDfaInputOutsideInventory(): # InventoryDfaInputOutsideInventory
                        v11 = False
                    case US3_InventoryDfaRejected(): # InventoryDfaRejected
                        v7 = accepts_10(v0, v2)
                        v8 = v7 == False
                        del v7
                        v11 = v8
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v2, v5
                if v11:
                    del v11
                    v0, v1 = v0, v3
                    continue
                else:
                    del v0, v3, v11
                    return False
            case UH1_InputListNil(): # InputListNil
                del v0, v1
                return True
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_22(v0 : i32, v1 : UH5) -> US3:
    while True:
        match v1:
            case UH5_InputCons(v8, v9): # InputCons
                del v1
                match v8:
                    case US1_TriA(): # TriA
                        v12 = US4_SymbolSame()
                    case t:
                        v12 = US4_SymbolGreater()
                match v12:
                    case US4_SymbolSame(): # SymbolSame
                        v13 = True
                    case t:
                        v13 = False
                del v12
                if v13:
                    v30 = 0
                else:
                    match v8:
                        case US1_TriA(): # TriA
                            v19 = US4_SymbolLess()
                        case US1_TriB(): # TriB
                            v19 = US4_SymbolSame()
                        case US1_TriC(): # TriC
                            v19 = US4_SymbolGreater()
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    match v19:
                        case US4_SymbolSame(): # SymbolSame
                            v20 = True
                        case t:
                            v20 = False
                    del v19
                    if v20:
                        del v20
                        v30 = 1
                    else:
                        del v20
                        match v8:
                            case US1_TriA(): # TriA
                                v26 = US4_SymbolLess()
                            case US1_TriB(): # TriB
                                v26 = US4_SymbolLess()
                            case US1_TriC(): # TriC
                                v26 = US4_SymbolSame()
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        match v26:
                            case US4_SymbolSame(): # SymbolSame
                                v27 = True
                            case t:
                                v27 = False
                        del v26
                        if v27:
                            del v27
                            v30 = 2
                        else:
                            del v27
                            v30 = -1
                del v8, v13
                v31 = v30 < 0
                if v31:
                    del v0, v9, v30, v31
                    return US3_InventoryDfaInputOutsideInventory()
                else:
                    del v31
                    v33 = v0 == 0
                    if v33:
                        v34 = v30 == 0
                        if v34:
                            del v34
                            v46 = 0
                        else:
                            del v34
                            v46 = 0
                    else:
                        v37 = v0 == 1
                        if v37:
                            del v37
                            v38 = v30 == 0
                            if v38:
                                del v38
                                v46 = 0
                            else:
                                del v38
                                v46 = 0
                        else:
                            del v37
                            v41 = v30 == 0
                            if v41:
                                del v41
                                v46 = 2
                            else:
                                del v41
                                v42 = v30 == 1
                                if v42:
                                    del v42
                                    v46 = 2
                                else:
                                    del v42
                                    v46 = 1
                    del v0, v30, v33
                    v0, v1 = v46, v9
                    continue
            case UH5_InputEmpty(): # InputEmpty
                del v1
                v2 = v0 == 0
                if v2:
                    v4 = False
                else:
                    v3 = v0 == 1
                    v4 = v3
                del v0, v2
                if v4:
                    del v4
                    return US3_InventoryDfaAccepted()
                else:
                    del v4
                    return US3_InventoryDfaRejected()
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def regex_compare_28(v0 : UH8, v1 : UH8) -> US4:
    while True:
        match v0:
            case UH8_RegexAlt(v59, v60): # RegexAlt
                del v0
                match v1:
                    case UH8_RegexAlt(v61, v62): # RegexAlt
                        del v1
                        v63 = regex_compare_28(v59, v61)
                        del v59, v61
                        match v63:
                            case US4_SymbolSame(): # SymbolSame
                                del v63
                                v0, v1 = v60, v62
                                continue
                            case t:
                                del v60, v62
                                return v63
                    case t:
                        del v1, v59, v60
                        return US4_SymbolGreater()
            case UH8_RegexCat(v34, v35): # RegexCat
                del v0
                match v1:
                    case UH8_RegexCat(v40, v41): # RegexCat
                        del v1
                        v42 = regex_compare_28(v34, v40)
                        del v34, v40
                        match v42:
                            case US4_SymbolSame(): # SymbolSame
                                del v42
                                v0, v1 = v35, v41
                                continue
                            case t:
                                del v35, v41
                                return v42
                    case UH8_RegexChar(_): # RegexChar
                        del v1, v34, v35
                        return US4_SymbolGreater()
                    case UH8_RegexEmpty(): # RegexEmpty
                        del v1, v34, v35
                        return US4_SymbolGreater()
                    case UH8_RegexEpsilon(): # RegexEpsilon
                        del v1, v34, v35
                        return US4_SymbolGreater()
                    case t:
                        del v1, v34, v35
                        return US4_SymbolLess()
            case UH8_RegexChar(v10): # RegexChar
                del v0
                match v1:
                    case UH8_RegexChar(v13): # RegexChar
                        del v1
                        match v10:
                            case US1_TriA(): # TriA
                                del v10
                                match v13:
                                    case US1_TriA(): # TriA
                                        del v13
                                        return US4_SymbolSame()
                                    case t:
                                        del v13
                                        return US4_SymbolLess()
                            case t:
                                match v13:
                                    case US1_TriA(): # TriA
                                        del v10, v13
                                        return US4_SymbolGreater()
                                    case t:
                                        match v10:
                                            case US1_TriB(): # TriB
                                                del v10
                                                match v13:
                                                    case US1_TriB(): # TriB
                                                        del v13
                                                        return US4_SymbolSame()
                                                    case US1_TriC(): # TriC
                                                        del v13
                                                        return US4_SymbolLess()
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case US1_TriC(): # TriC
                                                del v10
                                                match v13:
                                                    case US1_TriB(): # TriB
                                                        del v13
                                                        return US4_SymbolGreater()
                                                    case US1_TriC(): # TriC
                                                        del v13
                                                        return US4_SymbolSame()
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case t:
                                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case UH8_RegexEmpty(): # RegexEmpty
                        del v1, v10
                        return US4_SymbolGreater()
                    case UH8_RegexEpsilon(): # RegexEpsilon
                        del v1, v10
                        return US4_SymbolGreater()
                    case t:
                        del v1, v10
                        return US4_SymbolLess()
            case UH8_RegexEmpty(): # RegexEmpty
                del v0
                match v1:
                    case UH8_RegexEmpty(): # RegexEmpty
                        del v1
                        return US4_SymbolSame()
                    case t:
                        del v1
                        return US4_SymbolLess()
            case UH8_RegexEpsilon(): # RegexEpsilon
                del v0
                match v1:
                    case UH8_RegexEmpty(): # RegexEmpty
                        del v1
                        return US4_SymbolGreater()
                    case UH8_RegexEpsilon(): # RegexEpsilon
                        del v1
                        return US4_SymbolSame()
                    case t:
                        del v1
                        return US4_SymbolLess()
            case UH8_RegexStar(v50): # RegexStar
                del v0
                match v1:
                    case UH8_RegexAlt(_, _): # RegexAlt
                        del v1, v50
                        return US4_SymbolLess()
                    case UH8_RegexStar(v54): # RegexStar
                        del v1
                        v0, v1 = v50, v54
                        continue
                    case t:
                        del v1, v50
                        return US4_SymbolGreater()
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def alt_insert_sorted_27(v0 : UH8, v1 : UH8) -> UH8:
    match v1:
        case UH8_RegexAlt(v2, v3): # RegexAlt
            v4 = regex_compare_28(v0, v2)
            match v4:
                case US4_SymbolGreater(): # SymbolGreater
                    del v1, v4
                    v6 = alt_insert_sorted_27(v0, v3)
                    del v0, v3
                    return UH8_RegexAlt(v2, v6)
                case US4_SymbolLess(): # SymbolLess
                    del v2, v3, v4
                    return UH8_RegexAlt(v0, v1)
                case US4_SymbolSame(): # SymbolSame
                    del v0, v2, v3, v4
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH8_RegexEmpty(): # RegexEmpty
            del v1
            return v0
        case t:
            v11 = regex_compare_28(v0, v1)
            match v11:
                case US4_SymbolGreater(): # SymbolGreater
                    del v11
                    return UH8_RegexAlt(v1, v0)
                case US4_SymbolLess(): # SymbolLess
                    del v11
                    return UH8_RegexAlt(v0, v1)
                case US4_SymbolSame(): # SymbolSame
                    del v0, v11
                    return v1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
def make_alt_26(v0 : UH8, v1 : UH8) -> UH8:
    while True:
        match v0:
            case UH8_RegexAlt(v2, v3): # RegexAlt
                del v0
                v4 = alt_insert_sorted_27(v2, v1)
                del v1, v2
                v0, v1 = v3, v4
                continue
            case UH8_RegexEmpty(): # RegexEmpty
                del v0
                return v1
            case t:
                return alt_insert_sorted_27(v0, v1)
def regex_equal_30(v0 : UH8, v1 : UH8) -> bool:
    while True:
        match v0:
            case UH8_RegexAlt(v24, v25): # RegexAlt
                del v0
                match v1:
                    case UH8_RegexAlt(v26, v27): # RegexAlt
                        del v1
                        v28 = regex_equal_30(v24, v26)
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
            case UH8_RegexCat(v32, v33): # RegexCat
                del v0
                match v1:
                    case UH8_RegexCat(v34, v35): # RegexCat
                        del v1
                        v36 = regex_equal_30(v32, v34)
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
            case UH8_RegexChar(v4): # RegexChar
                del v0
                match v1:
                    case UH8_RegexChar(v5): # RegexChar
                        del v1
                        match v4:
                            case US1_TriA(): # TriA
                                match v5:
                                    case US1_TriA(): # TriA
                                        v21 = US4_SymbolSame()
                                    case t:
                                        v21 = US4_SymbolLess()
                            case t:
                                match v5:
                                    case US1_TriA(): # TriA
                                        v21 = US4_SymbolGreater()
                                    case t:
                                        match v4:
                                            case US1_TriB(): # TriB
                                                match v5:
                                                    case US1_TriB(): # TriB
                                                        v21 = US4_SymbolSame()
                                                    case US1_TriC(): # TriC
                                                        v21 = US4_SymbolLess()
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case US1_TriC(): # TriC
                                                match v5:
                                                    case US1_TriB(): # TriB
                                                        v21 = US4_SymbolGreater()
                                                    case US1_TriC(): # TriC
                                                        v21 = US4_SymbolSame()
                                                    case t:
                                                        raise Exception(f'Pattern matching miss. Got: {t}')
                                            case t:
                                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v4, v5
                        match v21:
                            case US4_SymbolSame(): # SymbolSame
                                del v21
                                return True
                            case t:
                                del v21
                                return False
                    case t:
                        del v1, v4
                        return False
            case UH8_RegexEmpty(): # RegexEmpty
                del v0
                match v1:
                    case UH8_RegexEmpty(): # RegexEmpty
                        del v1
                        return True
                    case t:
                        del v1
                        return False
            case UH8_RegexEpsilon(): # RegexEpsilon
                del v0
                match v1:
                    case UH8_RegexEpsilon(): # RegexEpsilon
                        del v1
                        return True
                    case t:
                        del v1
                        return False
            case UH8_RegexStar(v40): # RegexStar
                del v0
                match v1:
                    case UH8_RegexStar(v41): # RegexStar
                        del v1
                        v0, v1 = v40, v41
                        continue
                    case t:
                        del v1, v40
                        return False
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def make_cat_29(v0 : UH8, v1 : UH8) -> UH8:
    match v0:
        case UH8_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH8_RegexEmpty()
        case t:
            match v1:
                case UH8_RegexEmpty(): # RegexEmpty
                    del v0, v1
                    return UH8_RegexEmpty()
                case t:
                    match v0:
                        case UH8_RegexEpsilon(): # RegexEpsilon
                            del v0
                            return v1
                        case t:
                            match v1:
                                case UH8_RegexEpsilon(): # RegexEpsilon
                                    del v1
                                    return v0
                                case t:
                                    match v0:
                                        case UH8_RegexCat(v12, v13): # RegexCat
                                            del v0
                                            v14 = make_cat_29(v13, v1)
                                            del v1, v13
                                            return UH8_RegexCat(v12, v14)
                                        case UH8_RegexStar(v4): # RegexStar
                                            match v1:
                                                case UH8_RegexStar(v5): # RegexStar
                                                    v6 = regex_equal_30(v4, v5)
                                                    del v5
                                                    if v6:
                                                        del v0, v1, v6
                                                        return UH8_RegexStar(v4)
                                                    else:
                                                        del v4, v6
                                                        return UH8_RegexCat(v0, v1)
                                                case t:
                                                    del v4
                                                    return UH8_RegexCat(v0, v1)
                                        case t:
                                            return UH8_RegexCat(v0, v1)
def make_star_31(v0 : UH8) -> UH8:
    match v0:
        case UH8_RegexEmpty(): # RegexEmpty
            del v0
            return UH8_RegexEpsilon()
        case UH8_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH8_RegexEpsilon()
        case UH8_RegexStar(v3): # RegexStar
            del v0
            return UH8_RegexStar(v3)
        case t:
            return UH8_RegexStar(v0)
def normalize_25(v0 : UH8) -> UH8:
    match v0:
        case UH8_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = normalize_25(v5)
            del v5
            v8 = normalize_25(v6)
            del v6
            return make_alt_26(v7, v8)
        case UH8_RegexCat(v10, v11): # RegexCat
            del v0
            v12 = normalize_25(v10)
            del v10
            v13 = normalize_25(v11)
            del v11
            return make_cat_29(v12, v13)
        case UH8_RegexChar(v3): # RegexChar
            del v0
            return UH8_RegexChar(v3)
        case UH8_RegexEmpty(): # RegexEmpty
            del v0
            return UH8_RegexEmpty()
        case UH8_RegexEpsilon(): # RegexEpsilon
            del v0
            return UH8_RegexEpsilon()
        case UH8_RegexStar(v15): # RegexStar
            del v0
            v16 = normalize_25(v15)
            del v15
            return make_star_31(v16)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def nullable_33(v0 : UH8) -> US5:
    match v0:
        case UH8_RegexAlt(v5, v6): # RegexAlt
            del v0
            v7 = nullable_33(v5)
            del v5
            v8 = nullable_33(v6)
            del v6
            match v7:
                case US5_Nullable(): # Nullable
                    del v7, v8
                    return US5_Nullable()
                case t:
                    match v8:
                        case US5_Nullable(): # Nullable
                            del v7, v8
                            return US5_Nullable()
                        case t:
                            match v7:
                                case US5_NonNullable(): # NonNullable
                                    del v7
                                    match v8:
                                        case US5_NonNullable(): # NonNullable
                                            del v8
                                            return US5_NonNullable()
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH8_RegexCat(v16, v17): # RegexCat
            del v0
            v18 = nullable_33(v16)
            del v16
            v19 = nullable_33(v17)
            del v17
            match v18:
                case US5_Nullable(): # Nullable
                    del v18
                    match v19:
                        case US5_Nullable(): # Nullable
                            del v19
                            return US5_Nullable()
                        case t:
                            del v19
                            return US5_NonNullable()
                case t:
                    del v18, v19
                    return US5_NonNullable()
        case UH8_RegexChar(_): # RegexChar
            del v0
            return US5_NonNullable()
        case UH8_RegexEmpty(): # RegexEmpty
            del v0
            return US5_NonNullable()
        case UH8_RegexEpsilon(): # RegexEpsilon
            del v0
            return US5_Nullable()
        case UH8_RegexStar(_): # RegexStar
            del v0
            return US5_Nullable()
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def derivative_32(v0 : UH8, v1 : US1) -> UH8:
    match v0:
        case UH8_RegexAlt(v25, v26): # RegexAlt
            del v0
            v27 = derivative_32(v25, v1)
            del v25
            v28 = derivative_32(v26, v1)
            del v1, v26
            return make_alt_26(v27, v28)
        case UH8_RegexCat(v30, v31): # RegexCat
            del v0
            v32 = nullable_33(v30)
            match v32:
                case US5_NonNullable(): # NonNullable
                    del v32
                    v37 = derivative_32(v30, v1)
                    del v1, v30
                    return make_cat_29(v37, v31)
                case US5_Nullable(): # Nullable
                    del v32
                    v33 = derivative_32(v30, v1)
                    del v30
                    v34 = make_cat_29(v33, v31)
                    del v33
                    v35 = derivative_32(v31, v1)
                    del v1, v31
                    return make_alt_26(v34, v35)
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH8_RegexChar(v4): # RegexChar
            del v0
            match v4:
                case US1_TriA(): # TriA
                    match v1:
                        case US1_TriA(): # TriA
                            v20 = US4_SymbolSame()
                        case t:
                            v20 = US4_SymbolLess()
                case t:
                    match v1:
                        case US1_TriA(): # TriA
                            v20 = US4_SymbolGreater()
                        case t:
                            match v4:
                                case US1_TriB(): # TriB
                                    match v1:
                                        case US1_TriB(): # TriB
                                            v20 = US4_SymbolSame()
                                        case US1_TriC(): # TriC
                                            v20 = US4_SymbolLess()
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case US1_TriC(): # TriC
                                    match v1:
                                        case US1_TriB(): # TriB
                                            v20 = US4_SymbolGreater()
                                        case US1_TriC(): # TriC
                                            v20 = US4_SymbolSame()
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v1, v4
            match v20:
                case US4_SymbolSame(): # SymbolSame
                    v21 = True
                case t:
                    v21 = False
            del v20
            if v21:
                del v21
                return UH8_RegexEpsilon()
            else:
                del v21
                return UH8_RegexEmpty()
        case UH8_RegexEmpty(): # RegexEmpty
            del v0, v1
            return UH8_RegexEmpty()
        case UH8_RegexEpsilon(): # RegexEpsilon
            del v0, v1
            return UH8_RegexEmpty()
        case UH8_RegexStar(v41): # RegexStar
            del v0
            v42 = derivative_32(v41, v1)
            del v1
            v43 = make_star_31(v41)
            del v41
            return make_cat_29(v42, v43)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def canonical_derivative_24(v0 : UH8, v1 : US1) -> UH8:
    v2 = normalize_25(v0)
    del v0
    v3 = derivative_32(v2, v1)
    del v1, v2
    return normalize_25(v3)
def accepts_23(v0 : UH8, v1 : UH5) -> bool:
    while True:
        match v1:
            case UH5_InputCons(v6, v7): # InputCons
                del v1
                v8 = canonical_derivative_24(v0, v6)
                del v0, v6
                v0, v1 = v8, v7
                continue
            case UH5_InputEmpty(): # InputEmpty
                del v1
                v2 = normalize_25(v0)
                del v0
                v3 = nullable_33(v2)
                del v2
                match v3:
                    case US5_NonNullable(): # NonNullable
                        del v3
                        return False
                    case US5_Nullable(): # Nullable
                        del v3
                        return True
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_21(v0 : UH8, v1 : UH4) -> bool:
    while True:
        match v1:
            case UH4_InputListCons(v2, v3): # InputListCons
                del v1
                v4 = 2
                v5 = loop_22(v4, v2)
                del v4
                match v5:
                    case US3_InventoryDfaAccepted(): # InventoryDfaAccepted
                        v11 = accepts_23(v0, v2)
                    case US3_InventoryDfaInputOutsideInventory(): # InventoryDfaInputOutsideInventory
                        v11 = False
                    case US3_InventoryDfaRejected(): # InventoryDfaRejected
                        v7 = accepts_23(v0, v2)
                        v8 = v7 == False
                        del v7
                        v11 = v8
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v2, v5
                if v11:
                    del v11
                    v0, v1 = v0, v3
                    continue
                else:
                    del v0, v3, v11
                    return False
            case UH4_InputListNil(): # InputListNil
                del v0, v1
                return True
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def loop_34(v0 : i32, v1 : UH6) -> US3:
    while True:
        match v1:
            case UH6_InputCons(v7, v8): # InputCons
                del v1
                match v7:
                    case US2_ModelA(): # ModelA
                        v11 = US4_SymbolSame()
                    case t:
                        v11 = US4_SymbolGreater()
                match v11:
                    case US4_SymbolSame(): # SymbolSame
                        v12 = True
                    case t:
                        v12 = False
                del v11
                if v12:
                    v21 = 0
                else:
                    match v7:
                        case US2_ModelA(): # ModelA
                            v18 = US4_SymbolLess()
                        case US2_ModelB(): # ModelB
                            v18 = US4_SymbolSame()
                        case US2_ModelC(): # ModelC
                            v18 = US4_SymbolGreater()
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    match v18:
                        case US4_SymbolSame(): # SymbolSame
                            v19 = True
                        case t:
                            v19 = False
                    del v18
                    if v19:
                        del v19
                        v21 = 1
                    else:
                        del v19
                        v21 = -1
                del v7, v12
                v22 = v21 < 0
                if v22:
                    del v0, v8, v21, v22
                    return US3_InventoryDfaInputOutsideInventory()
                else:
                    del v22
                    v24 = v0 == 0
                    del v0
                    if v24:
                        v28 = 0
                    else:
                        v26 = v21 == 0
                        if v26:
                            del v26
                            v28 = 1
                        else:
                            del v26
                            v28 = 0
                    del v21, v24
                    v0, v1 = v28, v8
                    continue
            case UH6_InputEmpty(): # InputEmpty
                del v1
                v2 = v0 == 0
                del v0
                v3 = v2 == False
                del v2
                if v3:
                    del v3
                    return US3_InventoryDfaAccepted()
                else:
                    del v3
                    return US3_InventoryDfaRejected()
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = US0_BitZero()
    v1 = US0_BitOne()
    v2 = UH0_SymbolListNil()
    v3 = UH0_SymbolListCons(v1, v2)
    del v1, v2
    v4 = UH0_SymbolListCons(v0, v3)
    del v0, v3
    v5 = input_singletons_from_symbols_0(v4)
    del v4
    v6 = UH2_InputEmpty()
    v7 = UH1_InputListCons(v6, v5)
    del v5, v6
    v8 = US0_BitZero()
    v9 = US0_BitOne()
    v10 = UH0_SymbolListNil()
    v11 = UH0_SymbolListCons(v9, v10)
    del v9, v10
    v12 = UH0_SymbolListCons(v8, v11)
    del v8, v11
    v13 = US0_BitZero()
    v14 = US0_BitOne()
    v15 = UH0_SymbolListNil()
    v16 = UH0_SymbolListCons(v14, v15)
    del v14, v15
    v17 = UH0_SymbolListCons(v13, v16)
    del v13, v16
    v18 = input_singletons_from_symbols_0(v17)
    del v17
    v19 = input_prepend_symbols_to_corpus_1(v12, v18)
    del v12, v18
    v20 = input_list_append_2(v7, v19)
    del v7, v19
    v21 = US1_TriA()
    v22 = US1_TriB()
    v23 = US1_TriC()
    v24 = UH3_SymbolListNil()
    v25 = UH3_SymbolListCons(v23, v24)
    del v23, v24
    v26 = UH3_SymbolListCons(v22, v25)
    del v22, v25
    v27 = UH3_SymbolListCons(v21, v26)
    del v21, v26
    v28 = input_singletons_from_symbols_4(v27)
    del v27
    v29 = UH5_InputEmpty()
    v30 = UH4_InputListCons(v29, v28)
    del v28, v29
    v31 = US1_TriA()
    v32 = US1_TriB()
    v33 = US1_TriC()
    v34 = UH3_SymbolListNil()
    v35 = UH3_SymbolListCons(v33, v34)
    del v33, v34
    v36 = UH3_SymbolListCons(v32, v35)
    del v32, v35
    v37 = UH3_SymbolListCons(v31, v36)
    del v31, v36
    v38 = US1_TriA()
    v39 = US1_TriB()
    v40 = US1_TriC()
    v41 = UH3_SymbolListNil()
    v42 = UH3_SymbolListCons(v40, v41)
    del v40, v41
    v43 = UH3_SymbolListCons(v39, v42)
    del v39, v42
    v44 = UH3_SymbolListCons(v38, v43)
    del v38, v43
    v45 = input_singletons_from_symbols_4(v44)
    del v44
    v46 = input_prepend_symbols_to_corpus_5(v37, v45)
    del v37, v45
    v47 = input_list_append_6(v30, v46)
    del v30, v46
    v48 = US2_ModelC()
    v49 = UH6_InputEmpty()
    v50 = UH6_InputCons(v48, v49)
    del v48, v49
    v51 = US0_BitZero()
    v52 = UH7_RegexChar(v51)
    del v51
    v53 = US0_BitOne()
    v54 = UH7_RegexChar(v53)
    del v53
    v55 = UH7_RegexAlt(v52, v54)
    del v52, v54
    v56 = UH7_RegexStar(v55)
    del v55
    v57 = US0_BitZero()
    v58 = UH7_RegexChar(v57)
    del v57
    v59 = UH7_RegexCat(v56, v58)
    del v56, v58
    v60 = loop_8(v59, v20)
    del v20, v59
    if v60:
        v61 = US1_TriA()
        v62 = UH8_RegexChar(v61)
        del v61
        v63 = US1_TriB()
        v64 = UH8_RegexChar(v63)
        del v63
        v65 = UH8_RegexAlt(v62, v64)
        del v62, v64
        v66 = UH8_RegexStar(v65)
        del v65
        v67 = US1_TriC()
        v68 = UH8_RegexChar(v67)
        del v67
        v69 = UH8_RegexCat(v66, v68)
        del v66, v68
        v70 = loop_21(v69, v47)
        del v69
        if v70:
            del v70
            v71 = 1
            v72 = loop_34(v71, v50)
            del v71
            match v72:
                case US3_InventoryDfaInputOutsideInventory(): # InventoryDfaInputOutsideInventory
                    del v72
                    v75 = True
                case t:
                    del v72
                    v75 = False
        else:
            del v70
            v75 = False
    else:
        v75 = False
    del v47, v50, v60
    if v75:
        del v75
        return 0
    else:
        del v75
        return 1

if __name__ == '__main__': sys.exit(main())
