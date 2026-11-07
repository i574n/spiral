kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
class US0_W(NamedTuple): # W
    v0 : object
    tag = 0
class US0_T(NamedTuple): # T
    v0 : 'System.Threading.CancellationToken'
    tag = 1
US0 = Union[US0_W, US0_T]
def method0(v0 : object) -> i32:
    v1 = v0 * 2
    return v1
def main():
    v0 = 7
    v1 = v0 + 1
    v2 = method0(v1)
    v3 = v0 > 0
    if v3:
        v7 = US0_W(v1)
    else:
        v5 = None
        v7 = US0_T(v5)
    match v7:
        case US0_T(_): # T
            return 0
        case US0_W(v8): # W
            v9 = (v8)
            v10 = spiral_wrap(v2 + v9, 32, True)
            return v10
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': sys.exit(main())
