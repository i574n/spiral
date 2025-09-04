from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.list import (to_array, empty, of_array)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_1, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type, option_type)
from fable_modules.fable_library.string_ import (trim_end, trim_start)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Array, Union, Record)
from fable_modules.fable_library.util import (create_atom, int64_to_string, to_enumerable, compare)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

def _expr194() -> TypeInfo:
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


US0_reflection = _expr194

def _expr195() -> TypeInfo:
    return record_type("Trace.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr195

def _expr196() -> TypeInfo:
    return record_type("Trace.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr196

def _expr197() -> TypeInfo:
    return record_type("Trace.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr197

def _expr198() -> TypeInfo:
    return record_type("Trace.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr198

def _expr199() -> TypeInfo:
    return record_type("Trace.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr199

def _expr200() -> TypeInfo:
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


US1_reflection = _expr200

def _expr201() -> TypeInfo:
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


US2_reflection = _expr201

def _expr202() -> TypeInfo:
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


US3_reflection = _expr202

def _expr203() -> TypeInfo:
    return union_type("Trace.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())], [("f6_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5", "US4_6"]


US4_reflection = _expr203

def _expr204() -> TypeInfo:
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


US5_reflection = _expr204

def _expr205() -> TypeInfo:
    return union_type("Trace.US6", [], US6, lambda: [[("f0_0", Mut0_reflection()), ("f0_1", Mut1_reflection()), ("f0_2", Mut2_reflection()), ("f0_3", Mut3_reflection()), ("f0_4", Mut4_reflection()), ("f0_5", option_type(int64_type))], []])


class US6(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US6_0", "US6_1"]


US6_reflection = _expr205

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow206(v: str) -> US5:
        return closure1(None, v)

    return _arrow206


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
    def _arrow207(__unit: None=None) -> US1:
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









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow207(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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



def closure7(unit_var: None, v0: int64) -> US2:
    return US2(0, v0)


def method7(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow208(v: int64) -> US2:
        return closure7(None, v)

    return _arrow208


def method8(__unit: None=None) -> str:
    return "hh:mm:ss"


def method9(__unit: None=None) -> str:
    return "HH:mm:ss"


def method6(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v920: US2 = default_arg(map(method7(), v5), US2(1))
    v1074: Any
    if v920.tag == 0:
        v1003: Any = create(op_subtraction(from_value(ticks_1(now()), False), v920.fields[0]))
        v1074 = create_1(1, 1, 1, hours(v1003), minutes(v1003), seconds(v1003), milliseconds(v1003))

    else: 
        v1074 = now()

    v1075: str = method9()
    return to_string(v1074, "M-d-y hh:mm:ss tt" if (v1075 == "") else v1075)


def method12(__unit: None=None) -> str:
    return ""


def closure8(v0: Mut3, v1: str, unit_var: None) -> None:
    v4: str = v0.l0 + v1
    v0.l0 = v4


def method11(v0: str) -> str:
    v2: Mut3 = Mut3(method12())
    v17: None
    closure8(v2, ("" + str(v0)) + "", None)
    v17 = None
    return v2.l0


def method10(v0: US0) -> str:
    v650: str = "\u001b[94m" if (v0.tag == 1) else ("\u001b[92m" if (v0.tag == 2) else ("\u001b[90m" if (v0.tag == 0) else ("\u001b[93m" if (v0.tag == 3) else "\u001b[91m")))
    v655: US5 = US5(0, "Verbose") if (True if (v0.tag == 0) else False) else US5(1)
    v696: US5
    if v655.tag == 0:
        v696 = US5(0, v655.fields[0])

    else: 
        v662: US5 = US5(0, "Debug") if (True if (v0.tag == 1) else False) else US5(1)
        if v662.tag == 0:
            v696 = US5(0, v662.fields[0])

        else: 
            v669: US5 = US5(0, "Info") if (True if (v0.tag == 2) else False) else US5(1)
            if v669.tag == 0:
                v696 = US5(0, v669.fields[0])

            else: 
                v676: US5 = US5(0, "Warning") if (True if (v0.tag == 3) else False) else US5(1)
                if v676.tag == 0:
                    v696 = US5(0, v676.fields[0])

                else: 
                    v683: US5 = US5(0, "Critical") if (True if (v0.tag == 4) else False) else US5(1)
                    v696 = US5(0, v683.fields[0]) if (v683.tag == 0) else US5(1)




    v700: str
    if v696.tag == 0:
        v700 = v696.fields[0]

    else: 
        raise Exception("Option does not have a value.")

    v703: str = v700.lower()
    return (v650 + method11(v703[0])) + "\u001b[0m"


def method14(v0: str) -> str:
    v2: Mut3 = Mut3(method12())
    v14_1: None
    closure8(v2, v0, None)
    v14_1 = None
    return v2.l0


def method15(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method13(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v10: str = method14(v9)
    return method15((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + v8) + " / ") + v10)


def closure9(v0: Mut0, unit_var: None) -> None:
    v2: int64 = op_addition(v0.l0, int64(1))
    v0.l0 = v2


def closure11(v0: str, unit_var: None) -> None:
    print(v0)


def closure10(unit_var: None, v0: str) -> None:
    v4: None
    closure11(v0, None)
    v4 = None


def closure6(v0: US0, v1: Callable[[], str], v2: Callable[[], str], unit_var: None) -> None:
    def v18(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v19: None
    v18(None)
    v19 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
    v60: US0 = pattern_input[4].l0
    v306: US6
    class ObjectExpr209:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    class ObjectExpr210:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (find(v0, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr209())) >= find(v60, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr210())))) == False:
        v306 = US6(1)

    else: 
        v84: None
        v18(None)
        v84 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
        v112: int64 | None = pattern_input_1[5]
        v111: Mut4 = pattern_input_1[4]
        v110: Mut3 = pattern_input_1[3]
        v109: Mut2 = pattern_input_1[2]
        v108: Mut1 = pattern_input_1[1]
        v107: Mut0 = pattern_input_1[0]
        v125: str = method6(v107, v108, v109, v110, v111, v112)
        v126: str = method10(v0)
        v127: str = v1(None)
        v132: str = "" if (v127 == "") else method13(v107, v108, v109, v110, v111, v112, v125, v126, v127, v2(None))
        v148: None
        v18(None)
        v148 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_1(TraceState_trace_state())
        v172: Mut1 = pattern_input_2[1]
        v171: Mut0 = pattern_input_2[0]
        v193: None
        closure9(v171, None)
        v193 = None
        closure10(None, v132)
        v172.l0(v132)
        v306 = US6(0, v171, v172, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def closure5(v0: US0, v1: Callable[[], str], v2: Callable[[], str]) -> None:
    v322: None
    closure6(v0, v1, v2, None)
    v322 = None


def closure4(v0: US0, v1: Callable[[], str]) -> Callable[[Callable[[], str]], None]:
    def _arrow211(v: Callable[[], str], v0: Any=v0, v1: Any=v1) -> None:
        closure5(v0, v1, v)

    return _arrow211


def closure3(unit_var: None, v0: US0) -> Callable[[Callable[[], str], Callable[[], str]], None]:
    def _arrow212(v: Callable[[], str], unit_var: Any=unit_var, v0: Any=v0) -> Callable[[Callable[[], str]], None]:
        return closure4(v0, v)

    return _arrow212


v14: None = None

def _arrow213(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow213

def _expr214():
    v15(None)
    return v14


v16: None = _expr214()

def _arrow215(v: US0) -> Callable[[Callable[[], str], Callable[[], str]], None]:
    return closure3(None, v)


v31: Callable[[US0, Callable[[], str], Callable[[], str]], None] = _arrow215

def trace(x: US0) -> Callable[[Callable[[], str], Callable[[], str]], None]:
    return v31(x)


