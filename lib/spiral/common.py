from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.list import (to_array, empty, of_array)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_1, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, class_type, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type)
from fable_modules.fable_library.string_ import (trim_end, trim_start, to_text, interpolate)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Array, Union, Record, FSharpRef)
from fable_modules.fable_library.util import (create_atom, IDisposable, to_enumerable, compare, int64_to_string, Lazy)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


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

def _expr11() -> TypeInfo:
    return record_type("Common.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr11

def _expr12() -> TypeInfo:
    return record_type("Common.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr12

def _expr13() -> TypeInfo:
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


US1_reflection = _expr13

def _expr14() -> TypeInfo:
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


US2_reflection = _expr14

def _expr15() -> TypeInfo:
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


US3_reflection = _expr15

def _expr17() -> TypeInfo:
    return union_type("Common.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5"]


US4_reflection = _expr17

def _expr20() -> TypeInfo:
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


US5_reflection = _expr20

def _expr23() -> TypeInfo:
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


US6_reflection = _expr23

def _expr25() -> TypeInfo:
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


US7_reflection = _expr25

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow28(v: str) -> US5:
        return closure1(None, v)

    return _arrow28


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
    def _arrow42(__unit: None=None) -> US1:
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









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow42(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


def closure2(unit_var: None, v0: str) -> None:
    pass


def method0(v0: US0) -> tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None]:
    pattern_input: tuple[US1, US2] = method1()
    _run_target_args_0027_v3: tuple[US1, US2] = (pattern_input[0], pattern_input[1])
    v173: US2 = _run_target_args_0027_v3[1]
    v172: US1 = _run_target_args_0027_v3[0]
    def v179(v: str, v0: Any=v0) -> None:
        closure2(None, v)

    return (Mut0(int64(1)), Mut1(v179), Mut2(True), Mut3(""), Mut4(v172.fields[0] if (v172.tag == 0) else v0), v173.fields[0] if (v173.tag == 0) else None)


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
    class ObjectExpr49(IDisposable):
        def Dispose(self, __unit: None=None, unit_var: Any=unit_var, v0: Any=v0) -> None:
            v14_1(None)

    return ObjectExpr49()


def closure6(unit_var: None, v0: US6) -> US7:
    return US7(0, v0)


def closure7(v0: int, v1: Callable[[], None], v2: int, unit_var: None) -> US6:
    if v2 < v0:
        v1(None)
        return US6(0)

    else: 
        return US6(1)



def method9(v0: US0) -> bool:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
    v56: US0 = pattern_input[4].l0
    if pattern_input[2].l0 == False:
        return False

    else: 
        class ObjectExpr70:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        class ObjectExpr71:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        return find(v0, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr70())) >= find(v56, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr71()))



def closure10(unit_var: None, v0: int64) -> US2:
    return US2(0, v0)


def method11(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow72(v: int64) -> US2:
        return closure10(None, v)

    return _arrow72


def method12(__unit: None=None) -> str:
    return "hh:mm:ss"


def method13(__unit: None=None) -> str:
    return "HH:mm:ss"


def method10(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v804: US2 = default_arg(map(method11(), v5), US2(1))
    v936: Any
    if v804.tag == 0:
        v884: Any = create(op_subtraction(from_value(ticks_1(now()), False), v804.fields[0]))
        v936 = create_1(1, 1, 1, hours(v884), minutes(v884), seconds(v884), milliseconds(v884))

    else: 
        v936 = now()

    v938: str = method13()
    return to_string(v936, "M-d-y hh:mm:ss tt" if (v938 == "") else v938)


def method15(__unit: None=None) -> str:
    return ""


def closure11(v0: Mut3, v1: str, unit_var: None) -> None:
    v4: str = v0.l0 + v1
    v0.l0 = v4


def method16(__unit: None=None) -> str:
    return "\u001b[0m"


def method14(__unit: None=None) -> str:
    v4: str = "Warning".lower()
    v7: str = v4[0]
    v9: Mut3 = Mut3(method15())
    v24: None
    closure11(v9, ("" + str(v7)) + "", None)
    v24 = None
    return ("\u001b[93m" + v9.l0) + method16()


def method18(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method17(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: Exception) -> str:
    v11: Mut3 = Mut3(method15())
    v25: None
    closure11(v11, "{ ", None)
    v25 = None
    v44: None
    closure11(v11, "retry", None)
    v44 = None
    v63: None
    closure11(v11, " = ", None)
    v63 = None
    v83: None
    closure11(v11, ("" + str(v8)) + "", None)
    v83 = None
    v102: None
    closure11(v11, "; ", None)
    v102 = None
    v121: None
    closure11(v11, "ex", None)
    v121 = None
    v138: None
    closure11(v11, " = ", None)
    v138 = None
    v194: None
    closure11(v11, to_text(interpolate("%A%P()", [v9])), None)
    v194 = None
    v213: None
    closure11(v11, " }", None)
    v213 = None
    v219: str = v11.l0
    return method18((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "common.retry_fn") + " / ") + v219)


def closure12(v0: Mut0, unit_var: None) -> None:
    v2: int64 = op_addition(v0.l0, int64(1))
    v0.l0 = v2


def closure14(v0: str, unit_var: None) -> None:
    print(v0)


def closure13(unit_var: None, v0: str) -> None:
    v4: None
    closure14(v0, None)
    v4 = None


def method19(v0: str) -> None:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
    v60: None
    closure12(pattern_input[0], None)
    v60 = None
    closure13(None, v0)
    pattern_input[1].l0(v0)


def closure9(v0: int, v1: Exception, unit_var: None) -> None:
    if method9(US0(3)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
        v46: int64 | None = pattern_input[5]
        v45: Mut4 = pattern_input[4]
        v44: Mut3 = pattern_input[3]
        v43: Mut2 = pattern_input[2]
        v42: Mut1 = pattern_input[1]
        v41: Mut0 = pattern_input[0]
        method19(method17(v41, v42, v43, v44, v45, v46, method10(v41, v42, v43, v44, v45, v46), method14(), v0, v1))



def closure8(v0: int, v1: Exception) -> US7:
    v64: None
    closure9(v0, v1, None)
    v64 = None
    return US7(1)


def method8(v0_mut: int, v1_mut: Callable[[], None], v2_mut: int) -> US6:
    while True:
        (v0, v1, v2) = (v0_mut, v1_mut, v2_mut)
        result: FSharpRef[US7] = FSharpRef(US7(1))
        try: 
            result.contents = closure6(None, closure7(v0, v1, v2, None))

        except Exception as ex:
            result.contents = closure8(v2, ex)

        v8: US7 = result.contents
        if v8.tag == 0:
            return v8.fields[0]

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


def method20(v0: Callable[[], None]) -> Callable[[], None]:
    return v0


def closure16(v0: Any, unit_var: None) -> None:
    v0.Value


def closure15(unit_var: None, v0: Callable[[], None]) -> Callable[[], None]:
    v1: Callable[[], None] = method20(v0)
    def _arrow74(__unit: None=None, unit_var: Any=unit_var, v0: Any=v0) -> None:
        v1(None)

    v6: Any = Lazy(_arrow74)
    def _arrow75(__unit: None=None, unit_var: Any=unit_var, v0: Any=v0) -> None:
        closure16(v6, None)

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


