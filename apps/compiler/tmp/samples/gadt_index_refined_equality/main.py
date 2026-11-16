kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

UH0 = Union["UH0_Nil", "UH0_Cons"]
class US0_Vowel(NamedTuple): # Vowel
    v0 : i32
    tag = 1
US0 = US0_Vowel
class UH0_Nil(NamedTuple): # Nil
    tag = 0
UH0_Nil_shared = UH0_Nil()
class UH0_Cons(NamedTuple): # Cons
    v0 : US0
    v1 : UH0
    tag = 1
def method0(v0 : UH0, v1 : UH0) -> bool:
    while True:
        match v1, v0:
            case UH0_Cons(v2, v3), UH0_Cons(v4, v5): # Cons
                match v2, v4:
                    case US0_Vowel(v6), US0_Vowel(v7): # Vowel
                        v8 = v6 == v7
                        v9 = v8
                    case t:
                        v9 = False
                if v9:
                    v0, v1 = v5, v3
                    continue
                else:
                    return False
            case UH0_Nil(), UH0_Nil(): # Nil
                return True
            case t:
                return False
def main():
    v0 = 1
    v1 = US0_Vowel(v0)
    v2 = 1
    v3 = US0_Vowel(v2)
    v4 = 2
    v5 = US0_Vowel(v4)
    v6 = UH0_Nil_shared
    v7 = UH0_Cons(v5, v6)
    v8 = UH0_Cons(v1, v7)
    v9 = UH0_Nil_shared
    v10 = UH0_Cons(v5, v9)
    v11 = UH0_Cons(v3, v10)
    v12 = UH0_Nil_shared
    v13 = UH0_Cons(v1, v12)
    match v1, v3:
        case US0_Vowel(v14), US0_Vowel(v15): # Vowel
            v16 = v14 == v15
            v17 = v16
        case t:
            v17 = False
    if v17:
        match v1, v5:
            case US0_Vowel(v18), US0_Vowel(v19): # Vowel
                v20 = v18 == v19
                v21 = v20
            case t:
                v21 = False
        v22 = v21 == False
        v23 = v22
    else:
        v23 = False
    if v23:
        match v1, v3:
            case US0_Vowel(v24), US0_Vowel(v25): # Vowel
                v26 = v24 == v25
                v27 = v26
            case t:
                v27 = False
        if v27:
            v30 = method0(v11, v8)
        else:
            v30 = False
    else:
        v30 = False
    if v30:
        match v1, v5:
            case US0_Vowel(v31), US0_Vowel(v32): # Vowel
                v33 = v31 == v32
                v34 = v33
            case t:
                v34 = False
        if v34:
            v36 = method0(v13, v8)
        else:
            v36 = False
        v37 = v36 == False
        v38 = v37
    else:
        v38 = False
    if v38:
        return 0
    else:
        return 1

if __name__ == '__main__': sys.exit(main())
