from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.list import (to_array, empty, of_array)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_1, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, class_type, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type, option_type)
from fable_modules.fable_library.string_ import (to_text, interpolate, trim_end, trim_start)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Array, Union, Record, FSharpRef)
from fable_modules.fable_library.util import (create_atom, IDisposable, int64_to_string, to_enumerable, compare, Lazy)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

def _expr5() -> TypeInfo:
    return class_type("Common.Disposable", None, Disposable)


class Disposable(IDisposable):
    def __init__(self, f: Callable[[], None]) -> None:
        self.f: Callable[[], None] = f

    def Dispose(self, __unit: None=None) -> None:
        _: Disposable = self
        _.f(None)


Disposable_reflection = _expr5

def Disposable__ctor_3A5B6456(f: Callable[[], None]) -> Disposable:
    return Disposable(f)


def _expr6() -> TypeInfo:
    return union_type("Common.US0", [], US0, lambda: [[], [], [], [], []])


class US0(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US0_0", "US0_1", "US0_2", "US0_3", "US0_4"]


US0_reflection = _expr6

def _expr7() -> TypeInfo:
    return record_type("Common.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr7

def _expr8() -> TypeInfo:
    return record_type("Common.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr8

def _expr9() -> TypeInfo:
    return record_type("Common.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr9

def _expr10() -> TypeInfo:
    return record_type("Common.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr10

def _expr11() -> TypeInfo:
    return record_type("Common.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr11

def _expr12() -> TypeInfo:
    return union_type("Common.US1", [], US1, lambda: [[("f0_0", US0_reflection())], []])


class US1(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US1_0", "US1_1"]


US1_reflection = _expr12

def _expr13() -> TypeInfo:
    return union_type("Common.US2", [], US2, lambda: [[("f0_0", int64_type)], []])


class US2(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US2_0", "US2_1"]


US2_reflection = _expr13

def _expr14() -> TypeInfo:
    return union_type("Common.US3", [], US3, lambda: [[], [], []])


class US3(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US3_0", "US3_1", "US3_2"]


US3_reflection = _expr14

def _expr16() -> TypeInfo:
    return union_type("Common.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())], [("f6_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5", "US4_6"]


US4_reflection = _expr16

def _expr17() -> TypeInfo:
    return union_type("Common.US5", [], US5, lambda: [[("f0_0", string_type)], []])


class US5(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US5_0", "US5_1"]


US5_reflection = _expr17

def _expr18() -> TypeInfo:
    return union_type("Common.US6", [], US6, lambda: [[], []])


class US6(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US6_0", "US6_1"]


US6_reflection = _expr18

def _expr19() -> TypeInfo:
    return union_type("Common.US7", [], US7, lambda: [[("f0_0", US6_reflection())], []])


class US7(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US7_0", "US7_1"]


US7_reflection = _expr19

def _expr20() -> TypeInfo:
    return union_type("Common.US8", [], US8, lambda: [[("f0_0", Mut0_reflection()), ("f0_1", Mut1_reflection()), ("f0_2", Mut2_reflection()), ("f0_3", Mut3_reflection()), ("f0_4", Mut4_reflection()), ("f0_5", option_type(int64_type))], []])


class US8(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US8_0", "US8_1"]


US8_reflection = _expr20

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow22(v: str) -> US5:
        return closure1(None, v)

    return _arrow22


def method2(v0: str) -> str:
    v31_1: IOsEnviron = os
    v33_1: Any = v31.environ
    _v38: (str | None) | None = None
    x: str | None = v33.get(v0)
    _v38 = some(x)
    v44: str | None
    if _v38 is None:
        raise Exception("optionm\'.of_obj / _v38=None")

    else: 
        v44 = value_1(_v38)

    v71: US5 = default_arg(map(method5(), v44), US5(1))
    if v71.tag == 0:
        return v71.fields[0]

    else: 
        return ""



def method1(__unit: None=None) -> tuple[US1, US2]:
    v1: str = method2("TRACE_LEVEL")
    v6: str = "Critical".lower()
    v13: str = "Warning".lower()
    v20: str = "Info".lower()
    v27: str = "Debug".lower()
    v34: str = "Verbose".lower()
    v41: US1 = US1(0, US0(0)) if ("Verbose" == v1) else US1(1)
    def _arrow43(__unit: None=None) -> US1:
        v48: US1 = US1(0, US0(1)) if ("Debug" == v1) else US1(1)
        if v48.tag == 0:
            return US1(0, v48.fields[0])

        else: 
            v55: US1 = US1(0, US0(2)) if ("Info" == v1) else US1(1)
            if v55.tag == 0:
                return US1(0, v55.fields[0])

            else: 
                v62: US1 = US1(0, US0(3)) if ("Warning" == v1) else US1(1)
                if v62.tag == 0:
                    return US1(0, v62.fields[0])

                else: 
                    v69: US1 = US1(0, US0(4)) if ("Critical" == v1) else US1(1)
                    if v69.tag == 0:
                        return US1(0, v69.fields[0])

                    else: 
                        v76: US1 = US1(0, US0(0)) if (v34 == v1) else US1(1)
                        if v76.tag == 0:
                            return US1(0, v76.fields[0])

                        else: 
                            v83: US1 = US1(0, US0(1)) if (v27 == v1) else US1(1)
                            if v83.tag == 0:
                                return US1(0, v83.fields[0])

                            else: 
                                v90: US1 = US1(0, US0(2)) if (v20 == v1) else US1(1)
                                if v90.tag == 0:
                                    return US1(0, v90.fields[0])

                                else: 
                                    v97: US1 = US1(0, US0(3)) if (v13 == v1) else US1(1)
                                    if v97.tag == 0:
                                        return US1(0, v97.fields[0])

                                    else: 
                                        v104: US1 = US1(0, US0(4)) if (v6 == v1) else US1(1)
                                        return US1(0, v104.fields[0]) if (v104.tag == 0) else US1(1)









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow43(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


def closure2(unit_var: None, v0: str) -> None:
    pass


def method0(v0: US0) -> tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None]:
    pattern_input: tuple[US1, US2] = method1()
    _run_target_args_0027_v3: tuple[US1, US2] = (pattern_input[0], pattern_input[1])
    v185: US2 = _run_target_args_0027_v3[1]
    v184: US1 = _run_target_args_0027_v3[0]
    def v191(v: str, v0: Any=v0) -> None:
        closure2(None, v)

    return (Mut0(int64(1)), Mut1(v191), Mut2(True), Mut3(""), Mut4(v184.fields[0] if (v184.tag == 0) else v0), v185.fields[0] if (v185.tag == 0) else None)


def closure0(unit_var: None, unit_var_1: None) -> None:
    if TraceState_trace_state() is None:
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = method0(US0(0))
        TraceState_trace_state((pattern_input[0], pattern_input[1], pattern_input[2], pattern_input[3], pattern_input[4], pattern_input[5]))



def method6(v0: Callable[[], None]) -> Callable[[], None]:
    return v0


def method7(v0: Callable[[], None]) -> Callable[[], None]:
    return v0


def closure3(unit_var: None, v0: Callable[[], None]) -> IDisposable:
    v14_1: Callable[[], None] = method7(v0)
    class ObjectExpr56(IDisposable):
        def Dispose(self, __unit: None=None, unit_var: Any=unit_var, v0: Any=v0) -> None:
            v14_1(None)

    return ObjectExpr56()


def closure6(unit_var: None, v0: US6) -> US7:
    return US7(0, v0)


def closure7(v0: int, v1: Callable[[], None], v2: int, unit_var: None) -> US6:
    if v2 < v0:
        v1(None)
        return US6(0)

    else: 
        return US6(1)



def closure10(unit_var: None, v0: int64) -> US2:
    return US2(0, v0)


def method10(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow62(v: int64) -> US2:
        return closure10(None, v)

    return _arrow62


def method11(__unit: None=None) -> str:
    return "hh:mm:ss"


def method12(__unit: None=None) -> str:
    return "HH:mm:ss"


def method9(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v920: US2 = default_arg(map(method10(), v5), US2(1))
    v1074: Any
    if v920.tag == 0:
        v1003: Any = create(op_subtraction(from_value(ticks_1(now()), False), v920.fields[0]))
        v1074 = create_1(1, 1, 1, hours(v1003), minutes(v1003), seconds(v1003), milliseconds(v1003))

    else: 
        v1074 = now()

    v1075: str = method12()
    return to_string(v1074, "M-d-y hh:mm:ss tt" if (v1075 == "") else v1075)


def method15(__unit: None=None) -> str:
    return ""


def closure11(v0: Mut3, v1: str, unit_var: None) -> None:
    v4: str = v0.l0 + v1
    v0.l0 = v4


def method14(v0: str) -> str:
    v2: Mut3 = Mut3(method15())
    v17: None
    closure11(v2, ("" + str(v0)) + "", None)
    v17 = None
    return v2.l0


def method13(__unit: None=None) -> str:
    v133: str = "Warning".lower()
    return ("\u001b[93m" + method14(v133[0])) + "\u001b[0m"


def method17(v0: int, v1: Exception) -> str:
    v3: Mut3 = Mut3(method15())
    v17: None
    closure11(v3, "{ ", None)
    v17 = None
    v36: None
    closure11(v3, "retry", None)
    v36 = None
    v55: None
    closure11(v3, " = ", None)
    v55 = None
    v75: None
    closure11(v3, ("" + str(v0)) + "", None)
    v75 = None
    v94: None
    closure11(v3, "; ", None)
    v94 = None
    v113: None
    closure11(v3, "ex", None)
    v113 = None
    v130: None
    closure11(v3, " = ", None)
    v130 = None
    v189: None
    closure11(v3, to_text(interpolate("%A%P()", [v1])), None)
    v189 = None
    v208: None
    closure11(v3, " }", None)
    v208 = None
    return v3.l0


def method18(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method16(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: Exception) -> str:
    v10: str = method17(v8, v9)
    return method18((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "common.retry_fn") + " / ") + v10)


def closure12(v0: Mut0, unit_var: None) -> None:
    v2: int64 = op_addition(v0.l0, int64(1))
    v0.l0 = v2


def closure14(v0: str, unit_var: None) -> None:
    print(v0)


def closure13(unit_var: None, v0: str) -> None:
    v4: None
    closure14(v0, None)
    v4 = None


def closure9(v0: int, v1: Exception, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v299: US8
    class ObjectExpr72:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr72())))) == False:
        v299 = US8(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v125: str = method16(v105, v106, v107, v108, v109, v110, method9(v105, v106, v107, v108, v109, v110), method13(), v0, v1)
        v141: None
        v17(None)
        v141 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
        v165: Mut1 = pattern_input_2[1]
        v164: Mut0 = pattern_input_2[0]
        v186: None
        closure12(v164, None)
        v186 = None
        closure13(None, v125)
        v165.l0(v125)
        v299 = US8(0, v164, v165, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def closure8(v0: int, v1: Exception) -> US7:
    v315: None
    closure9(v0, v1, None)
    v315 = None
    return US7(1)


def method8(v0_mut: int, v1_mut: Callable[[], None], v2_mut: int) -> US6:
    while True:
        (v0, v1, v2) = (v0_mut, v1_mut, v2_mut)
        result: FSharpRef[US7] = FSharpRef(US7(1))
        try: 
            result.contents = closure6(None, closure7(v0, v1, v2, None))

        except Exception as ex:
            result.contents = closure8(v2, ex)

        v9: US7 = result.contents
        if v9.tag == 0:
            return v9.fields[0]

        else: 
            v0_mut = v0
            v1_mut = v1
            v2_mut = v2 + 1
            continue

        break


def closure5(v0: int, v1: Callable[[], None]) -> None | None:
    v3: US6 = method8(v0, v1, 0)
    if v3.tag == 0:
        return some(None)

    else: 
        return None



def closure4(unit_var: None, v0: int) -> Callable[[Callable[[], None]], None | None]:
    def _arrow73(v: Callable[[], None], unit_var: Any=unit_var, v0: Any=v0) -> None | None:
        return closure5(v0, v)

    return _arrow73


def closure16(v0: Any, unit_var: None) -> None:
    v0.Value


def closure15(unit_var: None, v0: Callable[[], None]) -> Callable[[], None]:
    def _arrow74(__unit: None=None, unit_var: Any=unit_var, v0: Any=v0) -> None:
        v0(None)

    v4: Any = Lazy(_arrow74)
    def _arrow75(__unit: None=None, unit_var: Any=unit_var, v0: Any=v0) -> None:
        closure16(v4, None)

    return _arrow75


v14: None = None

def _arrow76(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow76

def _expr77():
    v15(None)
    return v14


v16: None = _expr77()

def _arrow78(v: Callable[[], None]) -> IDisposable:
    return closure3(None, v)


v31: Callable[[Callable[[], None]], IDisposable] = _arrow78

def new_disposable(x: Callable[[], None]) -> IDisposable:
    return v31(x)


def _arrow79(v: int) -> Callable[[Callable[[], None]], None | None]:
    return closure4(None, v)


v32: Callable[[int, Callable[[], None]], None | None] = _arrow79

def retry_fn(x: int) -> Callable[[Callable[[], None]], None | None]:
    return v32(x)


def _arrow80(v: Callable[[], None]) -> Callable[[], None]:
    return closure15(None, v)


v33: Callable[[Callable[[], None], None], None] = _arrow80

def memoize(x: Callable[[], None]) -> Callable[[], None]:
    return v33(x)


