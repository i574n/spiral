from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.list import (to_array, empty, of_array)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_1, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type)
from fable_modules.fable_library.string_ import (trim_end, trim_start)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Array, Union, Record)
from fable_modules.fable_library.util import (create_atom, to_enumerable, compare, int64_to_string)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


def _expr232() -> TypeInfo:
    return union_type("Trace.US0", [], US0, lambda: [[], [], [], [], []])


class US0(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US0_0", "US0_1", "US0_2", "US0_3", "US0_4"]


US0_reflection = _expr232

def _expr233() -> TypeInfo:
    return record_type("Trace.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr233

def _expr234() -> TypeInfo:
    return record_type("Trace.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr234

def _expr235() -> TypeInfo:
    return record_type("Trace.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr235

def _expr236() -> TypeInfo:
    return record_type("Trace.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr236

def _expr237() -> TypeInfo:
    return record_type("Trace.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr237

def _expr241() -> TypeInfo:
    return union_type("Trace.US1", [], US1, lambda: [[("f0_0", US0_reflection())], []])


class US1(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US1_0", "US1_1"]


US1_reflection = _expr241

def _expr244() -> TypeInfo:
    return union_type("Trace.US2", [], US2, lambda: [[("f0_0", int64_type)], []])


class US2(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US2_0", "US2_1"]


US2_reflection = _expr244

def _expr250() -> TypeInfo:
    return union_type("Trace.US3", [], US3, lambda: [[], [], []])


class US3(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US3_0", "US3_1", "US3_2"]


US3_reflection = _expr250

def _expr251() -> TypeInfo:
    return union_type("Trace.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5"]


US4_reflection = _expr251

def _expr252() -> TypeInfo:
    return union_type("Trace.US5", [], US5, lambda: [[("f0_0", string_type)], []])


class US5(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US5_0", "US5_1"]


US5_reflection = _expr252

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow253(v: str) -> US5:
        return closure1(None, v)

    return _arrow253


def method2(v0: str) -> str:
    v31_1: IOsEnviron = os
    v33: Any = v31.environ
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
    def _arrow256(__unit: None=None) -> US1:
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









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow256(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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



def method6(v0: US0) -> bool:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
    v56: US0 = pattern_input[4].l0
    if pattern_input[2].l0 == False:
        return False

    else: 
        class ObjectExpr257:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        class ObjectExpr262:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        return find(v0, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr257())) >= find(v56, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr262()))



def closure7(unit_var: None, v0: int64) -> US2:
    return US2(0, v0)


def method8(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow263(v: int64) -> US2:
        return closure7(None, v)

    return _arrow263


def method9(__unit: None=None) -> str:
    return "hh:mm:ss"


def method10(__unit: None=None) -> str:
    return "HH:mm:ss"


def method7(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v804: US2 = default_arg(map(method8(), v5), US2(1))
    v936: Any
    if v804.tag == 0:
        v884: Any = create(op_subtraction(from_value(ticks_1(now()), False), v804.fields[0]))
        v936 = create_1(1, 1, 1, hours(v884), minutes(v884), seconds(v884), milliseconds(v884))

    else: 
        v936 = now()

    v938: str = method10()
    return to_string(v936, "M-d-y hh:mm:ss tt" if (v938 == "") else v938)


def method12(__unit: None=None) -> str:
    return ""


def closure8(v0: Mut3, v1: str, unit_var: None) -> None:
    v4: str = v0.l0 + v1
    v0.l0 = v4


def method13(__unit: None=None) -> str:
    return "\u001b[0m"


def method11(v0: US0) -> str:
    v5: US5 = US5(0, "Verbose") if (True if (v0.tag == 0) else False) else US5(1)
    v46: US5
    if v5.tag == 0:
        v46 = US5(0, v5.fields[0])

    else: 
        v12: US5 = US5(0, "Debug") if (True if (v0.tag == 1) else False) else US5(1)
        if v12.tag == 0:
            v46 = US5(0, v12.fields[0])

        else: 
            v19: US5 = US5(0, "Info") if (True if (v0.tag == 2) else False) else US5(1)
            if v19.tag == 0:
                v46 = US5(0, v19.fields[0])

            else: 
                v26: US5 = US5(0, "Warning") if (True if (v0.tag == 3) else False) else US5(1)
                if v26.tag == 0:
                    v46 = US5(0, v26.fields[0])

                else: 
                    v33: US5 = US5(0, "Critical") if (True if (v0.tag == 4) else False) else US5(1)
                    v46 = US5(0, v33.fields[0]) if (v33.tag == 0) else US5(1)




    v50: str
    if v46.tag == 0:
        v50 = v46.fields[0]

    else: 
        raise Exception("Option does not have a value.")

    v53: str = v50.lower()
    v56: str = v53[0]
    v58: Mut3 = Mut3(method12())
    v73: None
    closure8(v58, ("" + str(v56)) + "", None)
    v73 = None
    v79: str = v58.l0
    return (("\u001b[94m" if (v0.tag == 1) else ("\u001b[92m" if (v0.tag == 2) else ("\u001b[90m" if (v0.tag == 0) else ("\u001b[93m" if (v0.tag == 3) else "\u001b[91m")))) + v79) + method13()


def method15(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method14(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v11: Mut3 = Mut3(method12())
    v23: None
    closure8(v11, v9, None)
    v23 = None
    v29: str = v11.l0
    return method15((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + v8) + " / ") + v29)


def closure9(v0: Mut0, unit_var: None) -> None:
    v2: int64 = op_addition(v0.l0, int64(1))
    v0.l0 = v2


def closure11(v0: str, unit_var: None) -> None:
    print(v0)


def closure10(unit_var: None, v0: str) -> None:
    v4: None
    closure11(v0, None)
    v4 = None


def method16(v0: str) -> None:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
    v60: None
    closure9(pattern_input[0], None)
    v60 = None
    closure10(None, v0)
    pattern_input[1].l0(v0)


def closure6(v0: US0, v1: Callable[[], str], v2: Callable[[], str], unit_var: None) -> None:
    if method6(v0):
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
        v59: str = method7(v41, v42, v43, v44, v45, v46)
        v60: str = method11(v0)
        v61: str = v1(None)
        method16("" if (v61 == "") else method14(v41, v42, v43, v44, v45, v46, v59, v60, v61, v2(None)))



def closure5(v0: US0, v1: Callable[[], str], v2: Callable[[], str]) -> None:
    v69: None
    closure6(v0, v1, v2, None)
    v69 = None


def closure4(v0: US0, v1: Callable[[], str]) -> Callable[[Callable[[], str]], None]:
    def _arrow265(v: Callable[[], str], v0: Any=v0, v1: Any=v1) -> None:
        closure5(v0, v1, v)

    return _arrow265


def closure3(unit_var: None, v0: US0) -> Callable[[Callable[[], str], Callable[[], str]], None]:
    def _arrow266(v: Callable[[], str], unit_var: Any=unit_var, v0: Any=v0) -> Callable[[Callable[[], str]], None]:
        return closure4(v0, v)

    return _arrow266


v14: None = None

def _arrow267(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow267

def _expr268():
    v15(None)
    return v14


v16: None = _expr268()

def _arrow269(v: US0) -> Callable[[Callable[[], str], Callable[[], str]], None]:
    return closure3(None, v)


v31: Callable[[US0, Callable[[], str], Callable[[], str]], None] = _arrow269

def trace(x: US0) -> Callable[[Callable[[], str], Callable[[], str]], None]:
    return v31(x)


