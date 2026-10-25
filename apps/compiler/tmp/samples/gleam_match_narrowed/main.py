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
class US0_Circle(NamedTuple): # Circle
    v0 : i32
    tag = 0
class US0_Square(NamedTuple): # Square
    v0 : i32
    tag = 1
class US0_Tri(NamedTuple): # Tri
    v0 : i32
    tag = 2
class US0_Dot(NamedTuple): # Dot
    tag = 3
US0_Dot_shared = US0_Dot()
US0 = Union[US0_Circle, US0_Square, US0_Tri, US0_Dot]
def pick_0(v0 : i32) -> US0:
    v1 = v0 == 0
    if v1:
        return US0_Circle(5)
    else:
        v3 = v0 == 1
        if v3:
            return US0_Square(4)
        else:
            v5 = v0 == 2
            if v5:
                return US0_Tri(7)
            else:
                return US0_Dot_shared
def measure_1(v0 : US0, v1 : i32) -> i32:
    match v0:
        case US0_Circle(v2): # Circle
            v3 = spiral_wrap(v2 * 3, 32, True)
            return v3
        case t:
            v4 = spiral_wrap(v1 * v1, 32, True)
            v5 = v4 > 3
            match v0:
                case US0_Dot(): # Dot
                    return v4
                case US0_Square(v6): # Square
                    if v5:
                        v7 = spiral_wrap(v6 * v6, 32, True)
                        return v7
                    else:
                        return v6
                case US0_Tri(v9): # Tri
                    if v5:
                        v10 = spiral_wrap(v9 * 2, 32, True)
                        return v10
                    else:
                        return v9
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
def measure_tri_2(v0 : US0, v1 : i32) -> i32:
    match v0:
        case US0_Circle(v2): # Circle
            return v2
        case US0_Dot(): # Dot
            return 0
        case US0_Square(v3): # Square
            return v3
        case t:
            v4 = spiral_wrap(v1 + 2, 32, True)
            match v0:
                case US0_Tri(v5): # Tri
                    v6 = spiral_wrap(v5 * v4, 32, True)
                    return v6
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 0
    v1 = pick_0(v0)
    v2 = measure_1(v1, v0)
    v3 = spiral_wrap(v0 + 1, 32, True)
    v4 = pick_0(v3)
    v5 = measure_1(v4, v3)
    v6 = spiral_wrap(v2 + v5, 32, True)
    v7 = spiral_wrap(v0 + 2, 32, True)
    v8 = pick_0(v7)
    v9 = measure_1(v8, v7)
    v10 = spiral_wrap(v6 + v9, 32, True)
    v11 = spiral_wrap(v0 + 3, 32, True)
    v12 = pick_0(v11)
    v13 = measure_1(v12, v11)
    v14 = spiral_wrap(v10 + v13, 32, True)
    v15 = pick_0(v7)
    v16 = measure_tri_2(v15, v0)
    v17 = spiral_wrap(v14 + v16, 32, True)
    v18 = pick_0(v0)
    v19 = measure_tri_2(v18, v0)
    v20 = spiral_wrap(v17 + v19, 32, True)
    return v20

if __name__ == '__main__': sys.exit(main())
