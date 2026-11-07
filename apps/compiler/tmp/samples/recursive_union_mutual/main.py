kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

UH0 = Union["UH0_A", "UH0_StopA"]
UH1 = Union["UH1_B", "UH1_StopB"]
class UH1_B(NamedTuple): # B
    v0 : UH0
    tag = 0
class UH1_StopB(NamedTuple): # StopB
    tag = 1
UH1_StopB_shared = UH1_StopB()
class UH0_A(NamedTuple): # A
    v0 : UH1
    tag = 0
class UH0_StopA(NamedTuple): # StopA
    tag = 1
UH0_StopA_shared = UH0_StopA()
def main():
    v0 = True
    if v0:
        v1 = UH0_StopA_shared
        v2 = UH1_B(v1)
        v5 = UH0_A(v2)
    else:
        v5 = UH0_StopA_shared
    match v5:
        case UH0_A(_): # A
            return 0
        case UH0_StopA(): # StopA
            return 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
