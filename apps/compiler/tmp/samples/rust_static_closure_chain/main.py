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
UH0 = Union["UH0_Cons", "UH0_Nil"]
class UH0_Cons(NamedTuple): # Cons
    v0 : u64
    v1 : Callable[[], UH0]
    tag = 0
class UH0_Nil(NamedTuple): # Nil
    tag = 1
def closure79():
    def inner() -> UH0:
        return UH0_Nil()
    return inner
def closure78():
    def inner() -> UH0:
        v0 = closure79()
        return UH0_Cons(1, v0)
    return inner
def closure77():
    def inner() -> UH0:
        v0 = closure78()
        return UH0_Cons(2, v0)
    return inner
def closure76():
    def inner() -> UH0:
        v0 = closure77()
        return UH0_Cons(3, v0)
    return inner
def closure75():
    def inner() -> UH0:
        v0 = closure76()
        return UH0_Cons(4, v0)
    return inner
def closure74():
    def inner() -> UH0:
        v0 = closure75()
        return UH0_Cons(5, v0)
    return inner
def closure73():
    def inner() -> UH0:
        v0 = closure74()
        return UH0_Cons(6, v0)
    return inner
def closure72():
    def inner() -> UH0:
        v0 = closure73()
        return UH0_Cons(7, v0)
    return inner
def closure71():
    def inner() -> UH0:
        v0 = closure72()
        return UH0_Cons(8, v0)
    return inner
def closure70():
    def inner() -> UH0:
        v0 = closure71()
        return UH0_Cons(9, v0)
    return inner
def closure69():
    def inner() -> UH0:
        v0 = closure70()
        return UH0_Cons(10, v0)
    return inner
def closure68():
    def inner() -> UH0:
        v0 = closure69()
        return UH0_Cons(11, v0)
    return inner
def closure67():
    def inner() -> UH0:
        v0 = closure68()
        return UH0_Cons(12, v0)
    return inner
def closure66():
    def inner() -> UH0:
        v0 = closure67()
        return UH0_Cons(13, v0)
    return inner
def closure65():
    def inner() -> UH0:
        v0 = closure66()
        return UH0_Cons(14, v0)
    return inner
def closure64():
    def inner() -> UH0:
        v0 = closure65()
        return UH0_Cons(15, v0)
    return inner
def closure63():
    def inner() -> UH0:
        v0 = closure64()
        return UH0_Cons(16, v0)
    return inner
def closure62():
    def inner() -> UH0:
        v0 = closure63()
        return UH0_Cons(17, v0)
    return inner
def closure61():
    def inner() -> UH0:
        v0 = closure62()
        return UH0_Cons(18, v0)
    return inner
def closure60():
    def inner() -> UH0:
        v0 = closure61()
        return UH0_Cons(19, v0)
    return inner
def closure59():
    def inner() -> UH0:
        v0 = closure60()
        return UH0_Cons(20, v0)
    return inner
def closure58():
    def inner() -> UH0:
        v0 = closure59()
        return UH0_Cons(21, v0)
    return inner
def closure57():
    def inner() -> UH0:
        v0 = closure58()
        return UH0_Cons(22, v0)
    return inner
def closure56():
    def inner() -> UH0:
        v0 = closure57()
        return UH0_Cons(23, v0)
    return inner
def closure55():
    def inner() -> UH0:
        v0 = closure56()
        return UH0_Cons(24, v0)
    return inner
def closure54():
    def inner() -> UH0:
        v0 = closure55()
        return UH0_Cons(25, v0)
    return inner
def closure53():
    def inner() -> UH0:
        v0 = closure54()
        return UH0_Cons(26, v0)
    return inner
def closure52():
    def inner() -> UH0:
        v0 = closure53()
        return UH0_Cons(27, v0)
    return inner
def closure51():
    def inner() -> UH0:
        v0 = closure52()
        return UH0_Cons(28, v0)
    return inner
def closure50():
    def inner() -> UH0:
        v0 = closure51()
        return UH0_Cons(29, v0)
    return inner
def closure49():
    def inner() -> UH0:
        v0 = closure50()
        return UH0_Cons(30, v0)
    return inner
def closure48():
    def inner() -> UH0:
        v0 = closure49()
        return UH0_Cons(31, v0)
    return inner
def closure47():
    def inner() -> UH0:
        v0 = closure48()
        return UH0_Cons(32, v0)
    return inner
def closure46():
    def inner() -> UH0:
        v0 = closure47()
        return UH0_Cons(33, v0)
    return inner
def closure45():
    def inner() -> UH0:
        v0 = closure46()
        return UH0_Cons(34, v0)
    return inner
def closure44():
    def inner() -> UH0:
        v0 = closure45()
        return UH0_Cons(35, v0)
    return inner
def closure43():
    def inner() -> UH0:
        v0 = closure44()
        return UH0_Cons(36, v0)
    return inner
def closure42():
    def inner() -> UH0:
        v0 = closure43()
        return UH0_Cons(37, v0)
    return inner
def closure41():
    def inner() -> UH0:
        v0 = closure42()
        return UH0_Cons(38, v0)
    return inner
def closure40():
    def inner() -> UH0:
        v0 = closure41()
        return UH0_Cons(39, v0)
    return inner
def closure39():
    def inner() -> UH0:
        v0 = closure40()
        return UH0_Cons(40, v0)
    return inner
def closure38():
    def inner() -> UH0:
        v0 = closure39()
        return UH0_Cons(41, v0)
    return inner
def closure37():
    def inner() -> UH0:
        v0 = closure38()
        return UH0_Cons(42, v0)
    return inner
def closure36():
    def inner() -> UH0:
        v0 = closure37()
        return UH0_Cons(43, v0)
    return inner
def closure35():
    def inner() -> UH0:
        v0 = closure36()
        return UH0_Cons(44, v0)
    return inner
def closure34():
    def inner() -> UH0:
        v0 = closure35()
        return UH0_Cons(45, v0)
    return inner
def closure33():
    def inner() -> UH0:
        v0 = closure34()
        return UH0_Cons(46, v0)
    return inner
def closure32():
    def inner() -> UH0:
        v0 = closure33()
        return UH0_Cons(47, v0)
    return inner
def closure31():
    def inner() -> UH0:
        v0 = closure32()
        return UH0_Cons(48, v0)
    return inner
def closure30():
    def inner() -> UH0:
        v0 = closure31()
        return UH0_Cons(49, v0)
    return inner
def closure29():
    def inner() -> UH0:
        v0 = closure30()
        return UH0_Cons(50, v0)
    return inner
def closure28():
    def inner() -> UH0:
        v0 = closure29()
        return UH0_Cons(51, v0)
    return inner
def closure27():
    def inner() -> UH0:
        v0 = closure28()
        return UH0_Cons(52, v0)
    return inner
def closure26():
    def inner() -> UH0:
        v0 = closure27()
        return UH0_Cons(53, v0)
    return inner
def closure25():
    def inner() -> UH0:
        v0 = closure26()
        return UH0_Cons(54, v0)
    return inner
def closure24():
    def inner() -> UH0:
        v0 = closure25()
        return UH0_Cons(55, v0)
    return inner
def closure23():
    def inner() -> UH0:
        v0 = closure24()
        return UH0_Cons(56, v0)
    return inner
def closure22():
    def inner() -> UH0:
        v0 = closure23()
        return UH0_Cons(57, v0)
    return inner
def closure21():
    def inner() -> UH0:
        v0 = closure22()
        return UH0_Cons(58, v0)
    return inner
def closure20():
    def inner() -> UH0:
        v0 = closure21()
        return UH0_Cons(59, v0)
    return inner
def closure19():
    def inner() -> UH0:
        v0 = closure20()
        return UH0_Cons(60, v0)
    return inner
def closure18():
    def inner() -> UH0:
        v0 = closure19()
        return UH0_Cons(61, v0)
    return inner
def closure17():
    def inner() -> UH0:
        v0 = closure18()
        return UH0_Cons(62, v0)
    return inner
def closure16():
    def inner() -> UH0:
        v0 = closure17()
        return UH0_Cons(63, v0)
    return inner
def closure15():
    def inner() -> UH0:
        v0 = closure16()
        return UH0_Cons(64, v0)
    return inner
def closure14():
    def inner() -> UH0:
        v0 = closure15()
        return UH0_Cons(65, v0)
    return inner
def closure13():
    def inner() -> UH0:
        v0 = closure14()
        return UH0_Cons(66, v0)
    return inner
def closure12():
    def inner() -> UH0:
        v0 = closure13()
        return UH0_Cons(67, v0)
    return inner
def closure11():
    def inner() -> UH0:
        v0 = closure12()
        return UH0_Cons(68, v0)
    return inner
def closure10():
    def inner() -> UH0:
        v0 = closure11()
        return UH0_Cons(69, v0)
    return inner
def closure9():
    def inner() -> UH0:
        v0 = closure10()
        return UH0_Cons(70, v0)
    return inner
def closure8():
    def inner() -> UH0:
        v0 = closure9()
        return UH0_Cons(71, v0)
    return inner
def closure7():
    def inner() -> UH0:
        v0 = closure8()
        return UH0_Cons(72, v0)
    return inner
def closure6():
    def inner() -> UH0:
        v0 = closure7()
        return UH0_Cons(73, v0)
    return inner
def closure5():
    def inner() -> UH0:
        v0 = closure6()
        return UH0_Cons(74, v0)
    return inner
def closure4():
    def inner() -> UH0:
        v0 = closure5()
        return UH0_Cons(75, v0)
    return inner
def closure3():
    def inner() -> UH0:
        v0 = closure4()
        return UH0_Cons(76, v0)
    return inner
def closure2():
    def inner() -> UH0:
        v0 = closure3()
        return UH0_Cons(77, v0)
    return inner
def closure1():
    def inner() -> UH0:
        v0 = closure2()
        return UH0_Cons(78, v0)
    return inner
def closure0():
    def inner() -> UH0:
        v0 = closure1()
        return UH0_Cons(79, v0)
    return inner
def loop_0(v0 : UH0, v1 : u64) -> u64:
    while True:
        match v0:
            case UH0_Cons(v2, v3): # Cons
                del v0
                v4 = v3()
                del v3
                v5 = v1 + v2
                del v1, v2
                v0, v1 = v4, v5
                continue
            case UH0_Nil(): # Nil
                del v0
                return v1
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 80
    v1 = closure0()
    v2 = UH0_Cons(v0, v1)
    del v0, v1
    v3 = 0
    v4 = loop_0(v2, v3)
    del v2, v3
    v5 = v4 % 200
    del v4
    v6 = i32(v5)
    del v5
    return v6

if __name__ == '__main__': sys.exit(main())
