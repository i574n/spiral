from __future__ import annotations
from fable_modules.fable_library.array_ import fill
from fable_modules.fable_library.double import divide
from fable_modules.fable_library.int32 import op_unary_negation_int32
from fable_modules.fable_library.list import (cons, FSharpList, to_array, empty, of_array as of_array_1, fold_back)
from fable_modules.fable_library.long import (from_integer, to_number, from_number, op_subtraction, to_int)
from fable_modules.fable_library.reflection import (TypeInfo, char_type, union_type, int32_type, string_type, record_type)
from fable_modules.fable_library.seq import of_array
from fable_modules.fable_library.string_ import (ends_with as ends_with_1, replace as replace_1, split as split_1, join, starts_with as starts_with_1, substring as substring_1, trim_end as trim_end_1, trim_start as trim_start_1, to_text, interpolate)
from fable_modules.fable_library.types import (Array, Union, Record, int64)
from fable_modules.fable_library.util import (IEnumerable_1, uncurry2)
from collections.abc import Callable
from dataclasses import dataclass
from math import (ceil, floor)
from typing import Any

def _expr0() -> TypeInfo:
    return union_type("Sm.UH0", [], UH0, lambda: [[], [("Item1", char_type), ("Item2", UH0_reflection())]])


class UH0(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH0_0", "UH0_1"]


UH0_reflection = _expr0

def _expr1() -> TypeInfo:
    return record_type("Sm.Mut0", [], Mut0, lambda: [("l0", int32_type), ("l1", string_type), ("l2", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int
    l1: str
    l2: str

Mut0_reflection = _expr1

def _expr2() -> TypeInfo:
    return record_type("Sm.Mut1", [], Mut1, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: int

Mut1_reflection = _expr2

def closure1(v0_1: str, v1_1: str) -> bool:
    return v1_1.find(v0_1) >= 0


def closure0(unit_var: None, v0_1: str) -> Callable[[str], bool]:
    def _arrow3(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> bool:
        return closure1(v0_1, v)

    return _arrow3


def closure3(v0_1: str, v1_1: str) -> bool:
    return ends_with_1(v1_1, v0_1, False)


def closure2(unit_var: None, v0_1: str) -> Callable[[str], bool]:
    def _arrow4(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> bool:
        return closure3(v0_1, v)

    return _arrow4


def closure7(v0_1: int, v1_1: str, v2_1: int, v3_1: str) -> str:
    if v2_1 >= v0_1:
        return v3_1

    else: 
        return method0(v0_1, v1_1, v2_1 + 1)(v3_1 + v1_1)



def method0(v0_1: int, v1_1: str, v2_1: int) -> Callable[[str], str]:
    def _arrow9(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1) -> str:
        return closure7(v0_1, v1_1, v2_1, v)

    return _arrow9


def closure6(v0_1: int, v1_1: str, v2_1: str) -> str:
    return method0(v0_1 - len(v2_1), v1_1, 0)("") + v2_1


def closure5(v0_1: int, v1_1: str) -> Callable[[str], str]:
    def _arrow16(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
        return closure6(v0_1, v1_1, v)

    return _arrow16


def closure4(unit_var: None, v0_1: int) -> Callable[[str, str], str]:
    def _arrow18(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Callable[[str], str]:
        return closure5(v0_1, v)

    return _arrow18


def closure10(v0_1: int, v1_1: str, v2_1: str) -> str:
    return v2_1 + method0(v0_1 - len(v2_1), v1_1, 0)("")


def closure9(v0_1: int, v1_1: str) -> Callable[[str], str]:
    def _arrow19(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
        return closure10(v0_1, v1_1, v)

    return _arrow19


def closure8(unit_var: None, v0_1: int) -> Callable[[str, str], str]:
    def _arrow21(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Callable[[str], str]:
        return closure9(v0_1, v)

    return _arrow21


def closure13(v0_1: str, v1_1: str, v2_1: str) -> str:
    return replace_1(v2_1, v0_1, v1_1)


def closure12(v0_1: str, v1_1: str) -> Callable[[str], str]:
    def _arrow22(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
        return closure13(v0_1, v1_1, v)

    return _arrow22


def closure11(unit_var: None, v0_1: str) -> Callable[[str, str], str]:
    def _arrow24(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Callable[[str], str]:
        return closure12(v0_1, v)

    return _arrow24


def method2(v0_1: str) -> str:
    return v0_1


def method3(__unit: None=None) -> str:
    return ""


def method1(v0_1: str, v1_1: str, v2_1: str) -> str:
    return method3()


def closure16(v0_1: str, v1_1: str, v2_1: str) -> str:
    return method1(v0_1, v1_1, v2_1)


def closure15(v0_1: str, v1_1: str) -> Callable[[str], str]:
    def _arrow26(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
        return closure16(v0_1, v1_1, v)

    return _arrow26


def closure14(unit_var: None, v0_1: str) -> Callable[[str, str], str]:
    def _arrow27(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Callable[[str], str]:
        return closure15(v0_1, v)

    return _arrow27


def closure19(v0_1: int, v1_1: int, v2_1: str) -> str:
    return v2_1[v0_1:v1_1 + 1]


def closure18(v0_1: int, v1_1: int) -> Callable[[str], str]:
    def _arrow30(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
        return closure19(v0_1, v1_1, v)

    return _arrow30


def closure17(unit_var: None, v0_1: int) -> Callable[[int, str], str]:
    def _arrow31(v: int, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Callable[[str], str]:
        return closure18(v0_1, v)

    return _arrow31


def closure21(v0_1: str, v1_1: str) -> Array[str]:
    return split_1(v1_1, [v0_1], None, 0)


def closure20(unit_var: None, v0_1: str) -> Callable[[str], Array[str]]:
    def _arrow32(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Array[str]:
        return closure21(v0_1, v)

    return _arrow32


def method4(__unit: None=None) -> str:
    return ""


def method5(v0_1: str) -> str:
    return v0_1


def closure23(v0_1: Array[str], v1_1: str) -> Array[str]:
    v134: IEnumerable_1[str] = of_array(v0_1)
    v137: str = method4()
    return split_1(v1_1, [join(method5(v137) if (v137 == "\n") else v137, v134)], None, 0)


def closure22(unit_var: None, v0_1: Array[str]) -> Callable[[str], Array[str]]:
    def _arrow33(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Array[str]:
        return closure23(v0_1, v)

    return _arrow33


def closure25(v0_1: str, v1_1: str) -> bool:
    return starts_with_1(v1_1, v0_1, False)


def closure24(unit_var: None, v0_1: str) -> Callable[[str], bool]:
    def _arrow34(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> bool:
        return closure25(v0_1, v)

    return _arrow34


def closure28(v0_1: int, v1_1: int, v2_1: str) -> str:
    return substring_1(v2_1, v0_1, v1_1)


def closure27(v0_1: int, v1_1: int) -> Callable[[str], str]:
    def _arrow35(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
        return closure28(v0_1, v1_1, v)

    return _arrow35


def closure26(unit_var: None, v0_1: int) -> Callable[[int, str], str]:
    def _arrow36(v: int, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Callable[[str], str]:
        return closure27(v0_1, v)

    return _arrow36


def closure29(unit_var: None, v0_1: str) -> str:
    return v0_1.lower()


def closure30(unit_var: None, v0_1: str) -> str:
    return v0_1.upper()


def closure31(unit_var: None, v0_1: str) -> str:
    return v0_1.strip()


def closure34(v0_1: str, v1_1: UH0) -> UH0:
    return UH0(1, v0_1, v1_1)


def closure33(unit_var: None, v0_1: str) -> Callable[[UH0], UH0]:
    def _arrow37(v: UH0, unit_var: Any=unit_var, v0_1: Any=v0_1) -> UH0:
        return closure34(v0_1, v)

    return _arrow37


def method6(__unit: None=None) -> Callable[[str, UH0], UH0]:
    def _arrow38(v: str) -> Callable[[UH0], UH0]:
        return closure33(None, v)

    return _arrow38


def method7(v0_1: UH0, v1_1: FSharpList[str]) -> FSharpList[str]:
    if v0_1.tag == 0:
        return v1_1

    else: 
        return cons(v0_1.fields[0], method7(v0_1.fields[1], v1_1))



def closure35(v0_1: UH0, v1_1: str) -> str:
    return trim_end_1(v1_1, *to_array(method7(v0_1, empty())))


def closure32(unit_var: None, v0_1: Array[str]) -> Callable[[str], str]:
    v2_1: FSharpList[str] = of_array_1(v0_1)
    v15_1: UH0 = fold_back(uncurry2(method6()), v2_1, UH0(0))
    def _arrow39(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> str:
        return closure35(v15_1, v)

    return _arrow39


def closure37(v0_1: UH0, v1_1: str) -> str:
    return trim_start_1(v1_1, *to_array(method7(v0_1, empty())))


def closure36(unit_var: None, v0_1: Array[str]) -> Callable[[str], str]:
    v2_1: FSharpList[str] = of_array_1(v0_1)
    v15_1: UH0 = fold_back(uncurry2(method6()), v2_1, UH0(0))
    def _arrow40(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> str:
        return closure37(v15_1, v)

    return _arrow40


def closure39(v0_1: int, v1_1: str) -> str:
    if len(v1_1) <= v0_1:
        return v1_1

    else: 
        v4_1: int = (v0_1 - 1) or 0
        return v1_1[0:v4_1 + 1] + "..."



def closure38(unit_var: None, v0_1: int) -> Callable[[str], str]:
    def _arrow41(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> str:
        return closure39(v0_1, v)

    return _arrow41


def method8(v0_1: int64, v1_1: str) -> str:
    v2_1: int64 = from_integer(len(v1_1), False, 2)
    if v2_1 <= v0_1:
        return v1_1

    else: 
        v9_1: float = divide(to_number(v0_1), 2.0)
        v14_1: int64 = from_number(ceil(v9_1), False)
        v21_1: int64 = from_number(floor(v9_1), False)
        v24: int64 = op_subtraction(v14_1, int64(1))
        v26: str = v1_1[int(to_int(int64(0))):int(to_int(v24)) + 1]
        v30: int64 = op_subtraction(v2_1, v21_1)
        v31: int64 = op_subtraction(v2_1, int64(1))
        return join("", of_array([v26, "...", v1_1[int(to_int(v30)):int(to_int(v31)) + 1]]))



def closure41(v0_1: int64, v1_1: str) -> str:
    return method8(v0_1, v1_1)


def closure40(unit_var: None, v0_1: int64) -> Callable[[str], str]:
    def _arrow42(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> str:
        return closure41(v0_1, v)

    return _arrow42


def closure42(unit_var: None, v0_1: Exception) -> str:
    return to_text(interpolate("%A%P()", [v0_1]))


def method9(v0_1: int, v1_1: Mut0) -> bool:
    return v1_1.l0 < v0_1


def closure44(v0_1: str, v1_1: Array[str]) -> str:
    v2_1: int = len(v1_1) or 0
    v4_1: Mut0 = Mut0(0, "", "")
    while method9(v2_1, v4_1):
        v6_1: int = v4_1.l0 or 0
        v9_1: int = ((op_unary_negation_int32(v6_1) + v2_1) - 1) or 0
        match_value: str = v4_1.l1
        match_value_1: str = v4_1.l2
        v18_1: str = (v1_1[v9_1] + match_value_1) + match_value
        v21_1: int = (v6_1 + 1) or 0
        v4_1.l0 = v21_1 or 0
        v4_1.l1 = v18_1
        v4_1.l2 = v0_1
    match_value_2: str = v4_1.l1
    match_value_3: str = v4_1.l2
    return match_value_2


def closure43(unit_var: None, v0_1: str) -> Callable[[Array[str]], str]:
    def _arrow44(v: Array[str], unit_var: Any=unit_var, v0_1: Any=v0_1) -> str:
        return closure44(v0_1, v)

    return _arrow44


def closure46(v0_1: str, v1_1: IEnumerable_1[str]) -> str:
    return join(method5(v0_1) if (v0_1 == "\n") else v0_1, v1_1)


def closure45(unit_var: None, v0_1: str) -> Callable[[IEnumerable_1[str]], str]:
    def _arrow45(v: IEnumerable_1[str], unit_var: Any=unit_var, v0_1: Any=v0_1) -> str:
        return closure46(v0_1, v)

    return _arrow45


def closure48(v0_1: str, v1_1: Array[str]) -> str:
    return join(v0_1, v1_1)


def closure47(unit_var: None, v0_1: str) -> Callable[[Array[str]], str]:
    def _arrow46(v: Array[str], unit_var: Any=unit_var, v0_1: Any=v0_1) -> str:
        return closure48(v0_1, v)

    return _arrow46


def method10(v0_1: int, v1_1: Mut1) -> bool:
    return v1_1.l0 < v0_1


def closure49(unit_var: None, v0_1: str) -> Array[str]:
    v1_1: int = len(v0_1) or 0
    v2_1: Array[str] = fill([0] * v1_1, 0, v1_1, "")
    v3_1: Mut1 = Mut1(0)
    while method10(v1_1, v3_1):
        v5_1: int = v3_1.l0 or 0
        v6_1: str = v0_1[v5_1]
        v2_1[v5_1] = v6_1
        v7_1: int = (v5_1 + 1) or 0
        v3_1.l0 = v7_1 or 0
    return v2_1


def _arrow47(v: str) -> Callable[[str], bool]:
    return closure0(None, v)


v0: Callable[[str, str], bool] = _arrow47

def contains(x: str) -> Callable[[str], bool]:
    return v0(x)


def _arrow49(v: str) -> Callable[[str], bool]:
    return closure2(None, v)


v1: Callable[[str, str], bool] = _arrow49

def ends_with(x: str) -> Callable[[str], bool]:
    return v1(x)


def _arrow50(v: int) -> Callable[[str, str], str]:
    return closure4(None, v)


v2: Callable[[int, str, str], str] = _arrow50

def pad_left(x: int) -> Callable[[str, str], str]:
    return v2(x)


def _arrow51(v: int) -> Callable[[str, str], str]:
    return closure8(None, v)


v3: Callable[[int, str, str], str] = _arrow51

def pad_right(x: int) -> Callable[[str, str], str]:
    return v3(x)


def _arrow52(v: str) -> Callable[[str, str], str]:
    return closure11(None, v)


v4: Callable[[str, str, str], str] = _arrow52

def replace(x: str) -> Callable[[str, str], str]:
    return v4(x)


def _arrow54(v: str) -> Callable[[str, str], str]:
    return closure14(None, v)


v5: Callable[[str, str, str], str] = _arrow54

def replace_regex(x: str) -> Callable[[str, str], str]:
    return v5(x)


def _arrow55(v: int) -> Callable[[int, str], str]:
    return closure17(None, v)


v6: Callable[[int, int, str], str] = _arrow55

def slice(x: int) -> Callable[[int, str], str]:
    return v6(x)


def _arrow56(v: str) -> Callable[[str], Array[str]]:
    return closure20(None, v)


v7: Callable[[str, str], Array[str]] = _arrow56

def split(x: str) -> Callable[[str], Array[str]]:
    return v7(x)


def _arrow57(v: Array[str]) -> Callable[[str], Array[str]]:
    return closure22(None, v)


v8: Callable[[Array[str], str], Array[str]] = _arrow57

def split_string(x: Array[str]) -> Callable[[str], Array[str]]:
    return v8(x)


def _arrow58(v: str) -> Callable[[str], bool]:
    return closure24(None, v)


v9: Callable[[str, str], bool] = _arrow58

def starts_with(x: str) -> Callable[[str], bool]:
    return v9(x)


def _arrow59(v: int) -> Callable[[int, str], str]:
    return closure26(None, v)


v10: Callable[[int, int, str], str] = _arrow59

def substring(x: int) -> Callable[[int, str], str]:
    return v10(x)


def _arrow60(v: str) -> str:
    return closure29(None, v)


v11: Callable[[str], str] = _arrow60

def to_lower(x: str) -> str:
    return v11(x)


def _arrow61(v: str) -> str:
    return closure30(None, v)


v12: Callable[[str], str] = _arrow61

def to_upper(x: str) -> str:
    return v12(x)


def _arrow62(v: str) -> str:
    return closure31(None, v)


v13: Callable[[str], str] = _arrow62

def trim(x: str) -> str:
    return v13(x)


def _arrow63(v: Array[str]) -> Callable[[str], str]:
    return closure32(None, v)


v14: Callable[[Array[str], str], str] = _arrow63

def trim_end(x: Array[str]) -> Callable[[str], str]:
    return v14(x)


def _arrow64(v: Array[str]) -> Callable[[str], str]:
    return closure36(None, v)


v15: Callable[[Array[str], str], str] = _arrow64

def trim_start(x: Array[str]) -> Callable[[str], str]:
    return v15(x)


def _arrow65(v: int) -> Callable[[str], str]:
    return closure38(None, v)


v16: Callable[[int, str], str] = _arrow65

def ellipsis(x: int) -> Callable[[str], str]:
    return v16(x)


def _arrow66(v: int64) -> Callable[[str], str]:
    return closure40(None, v)


v17: Callable[[int64, str], str] = _arrow66

def ellipsis_end(x: int64) -> Callable[[str], str]:
    return v17(x)


def _arrow67(v: Exception) -> str:
    return closure42(None, v)


v18: Callable[[Exception], str] = _arrow67

def format_exception(x: Exception) -> str:
    return v18(x)


def _arrow68(v: str) -> Callable[[Array[str]], str]:
    return closure43(None, v)


v19: Callable[[str, Array[str]], str] = _arrow68

def concat_array(x: str) -> Callable[[Array[str]], str]:
    return v19(x)


def _arrow69(v: str) -> Callable[[IEnumerable_1[str]], str]:
    return closure45(None, v)


v20: Callable[[str, IEnumerable_1[str]], str] = _arrow69

def concat(x: str) -> Callable[[IEnumerable_1[str]], str]:
    return v20(x)


def _arrow70(v: str) -> Callable[[Array[str]], str]:
    return closure47(None, v)


v21: Callable[[str, Array[str]], str] = _arrow70

def join_0027(x: str) -> Callable[[Array[str]], str]:
    return v21(x)


def _arrow71(v: str) -> Array[str]:
    return closure49(None, v)


v22: Callable[[str], Array[str]] = _arrow71

def to_char_array(x: str) -> Array[str]:
    return v22(x)


