from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.async_ import (cancellation_token, await_task, start_child, catch_async, sleep)
from fable_modules.fable_library.async_builder import (singleton, CancellationToken, Async)
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.list import (to_array, empty, of_array)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition, op_modulus)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_3, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type, option_type, class_type, int32_type)
from fable_modules.fable_library.string_ import (trim_end, trim_start, to_text, interpolate)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Array, Union, Record)
from fable_modules.fable_library.util import (create_atom, int64_to_string, to_enumerable, compare, IDisposable)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

def _expr130() -> TypeInfo:
    return union_type("Networking.US0", [], US0, lambda: [[], [], [], [], []])


class US0(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US0_0", "US0_1", "US0_2", "US0_3", "US0_4"]


US0_reflection = _expr130

def _expr131() -> TypeInfo:
    return record_type("Networking.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr131

def _expr132() -> TypeInfo:
    return record_type("Networking.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr132

def _expr133() -> TypeInfo:
    return record_type("Networking.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr133

def _expr134() -> TypeInfo:
    return record_type("Networking.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr134

def _expr135() -> TypeInfo:
    return record_type("Networking.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr135

def _expr136() -> TypeInfo:
    return union_type("Networking.US1", [], US1, lambda: [[("f0_0", US0_reflection())], []])


class US1(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US1_0", "US1_1"]


US1_reflection = _expr136

def _expr137() -> TypeInfo:
    return union_type("Networking.US2", [], US2, lambda: [[("f0_0", int64_type)], []])


class US2(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US2_0", "US2_1"]


US2_reflection = _expr137

def _expr138() -> TypeInfo:
    return union_type("Networking.US3", [], US3, lambda: [[], [], []])


class US3(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US3_0", "US3_1", "US3_2"]


US3_reflection = _expr138

def _expr139() -> TypeInfo:
    return union_type("Networking.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())], [("f6_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5", "US4_6"]


US4_reflection = _expr139

def _expr140() -> TypeInfo:
    return union_type("Networking.US5", [], US5, lambda: [[("f0_0", string_type)], []])


class US5(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US5_0", "US5_1"]


US5_reflection = _expr140

def _expr141() -> TypeInfo:
    return union_type("Networking.US6", [], US6, lambda: [[("f0_0", Mut0_reflection()), ("f0_1", Mut1_reflection()), ("f0_2", Mut2_reflection()), ("f0_3", Mut3_reflection()), ("f0_4", Mut4_reflection()), ("f0_5", option_type(int64_type))], []])


class US6(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US6_0", "US6_1"]


US6_reflection = _expr141

def _expr142() -> TypeInfo:
    return union_type("Networking.US7", [], US7, lambda: [[("f0_0", bool_type)], []])


class US7(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US7_0", "US7_1"]


US7_reflection = _expr142

def _expr143() -> TypeInfo:
    return union_type("Networking.US8", [], US8, lambda: [[("f0_0", bool_type)], [("f1_0", class_type("System.Exception"))]])


class US8(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US8_0", "US8_1"]


US8_reflection = _expr143

def _expr144() -> TypeInfo:
    return union_type("Networking.US9", [], US9, lambda: [[("f0_0", bool_type)], [("f1_0", class_type("System.Exception"))]])


class US9(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US9_0", "US9_1"]


US9_reflection = _expr144

def _expr145() -> TypeInfo:
    return union_type("Networking.US10", [], US10, lambda: [[("f0_0", int32_type)], []])


class US10(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US10_0", "US10_1"]


US10_reflection = _expr145

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow146(v: str) -> US5:
        return closure1(None, v)

    return _arrow146


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
        v44 = value_3(_v38)

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
    v34_1: str = "Verbose".lower()
    v41: US1 = US1(0, US0(0)) if ("Verbose" == v1) else US1(1)
    def _arrow147(__unit: None=None) -> US1:
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
                        v76: US1 = US1(0, US0(0)) if (v34_1 == v1) else US1(1)
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









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow147(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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



def closure6(unit_var: None, v0: int64) -> US2:
    return US2(0, v0)


def method9(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow148(v: int64) -> US2:
        return closure6(None, v)

    return _arrow148


def method10(__unit: None=None) -> str:
    return "hh:mm:ss"


def method11(__unit: None=None) -> str:
    return "HH:mm:ss"


def method8(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v920: US2 = default_arg(map(method9(), v5), US2(1))
    v1074: Any
    if v920.tag == 0:
        v1003: Any = create(op_subtraction(from_value(ticks_1(now()), False), v920.fields[0]))
        v1074 = create_1(1, 1, 1, hours(v1003), minutes(v1003), seconds(v1003), milliseconds(v1003))

    else: 
        v1074 = now()

    v1075: str = method11()
    return to_string(v1074, "M-d-y hh:mm:ss tt" if (v1075 == "") else v1075)


def method14(__unit: None=None) -> str:
    return ""


def closure7(v0: Mut3, v1: str, unit_var: None) -> None:
    v4: str = v0.l0 + v1
    v0.l0 = v4


def method13(v0: str) -> str:
    v2: Mut3 = Mut3(method14())
    v17: None
    closure7(v2, ("" + str(v0)) + "", None)
    v17 = None
    return v2.l0


def method12(__unit: None=None) -> str:
    v133: str = "Verbose".lower()
    return ("\u001b[90m" + method13(v133[0])) + "\u001b[0m"


def method16(v0: int, v1: str) -> str:
    v3: Mut3 = Mut3(method14())
    v17: None
    closure7(v3, "{ ", None)
    v17 = None
    v36: None
    closure7(v3, "port", None)
    v36 = None
    v55: None
    closure7(v3, " = ", None)
    v55 = None
    v75: None
    closure7(v3, ("" + str(v0)) + "", None)
    v75 = None
    v94: None
    closure7(v3, "; ", None)
    v94 = None
    v113: None
    closure7(v3, "ex", None)
    v113 = None
    v130: None
    closure7(v3, " = ", None)
    v130 = None
    v147: None
    closure7(v3, v1, None)
    v147 = None
    v166: None
    closure7(v3, " }", None)
    v166 = None
    return v3.l0


def method17(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method15(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: str) -> str:
    v10: str = method16(v8, v9)
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "networking.test_port_open") + " / ") + v10)


def closure8(v0: Mut0, unit_var: None) -> None:
    v2: int64 = op_addition(v0.l0, int64(1))
    v0.l0 = v2


def closure10(v0: str, unit_var: None) -> None:
    print(v0)


def closure9(unit_var: None, v0: str) -> None:
    v4: None
    closure10(v0, None)
    v4 = None


def closure5(v0: int, v1: Exception, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v338: US6
    class ObjectExpr149:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (0 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr149())))) == False:
        v338 = US6(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v164: str = method15(v105, v106, v107, v108, v109, v110, method8(v105, v106, v107, v108, v109, v110), method12(), v0, to_text(interpolate("%A%P()", [v1])))
        v180: None
        v17(None)
        v180 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v204: Mut1 = pattern_input_2[1]
        v203: Mut0 = pattern_input_2[0]
        v225: None
        closure8(v203, None)
        v225 = None
        closure9(None, v164)
        v204.l0(v164)
        v338 = US6(0, v203, v204, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method7(v0: str, v1: int) -> Async[bool]:
    def _arrow155(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[bool]:
        v100028: Async[CancellationToken] = cancellation_token()
        def _arrow154(_arg: CancellationToken) -> Async[bool]:
            def _arrow153(_arg_1: IDisposable) -> Async[bool]:
                def _arrow151(__unit: None=None) -> Async[bool]:
                    v100282: Async[None] = await_task(None)
                    def _arrow150(__unit: None=None) -> Async[bool]:
                        return singleton.Return(True)

                    return singleton.Bind(v100282, _arrow150)

                def _arrow152(_arg_3: Exception) -> Async[bool]:
                    v101463: None
                    closure5(v1, _arg_3, None)
                    v101463 = None
                    return singleton.Return(False)

                return singleton.TryWith(singleton.Delay(_arrow151), _arrow152)

            return singleton.Using(None, _arrow153)

        return singleton.Bind(v100028, _arrow154)

    return singleton.Delay(_arrow155)


def method6(v0: str, v1: int) -> Async[bool]:
    return method7(v0, v1)


def closure4(v0: str, v1: int) -> Async[bool]:
    return method6(v0, v1)


def closure3(unit_var: None, v0: str) -> Callable[[int], Async[bool]]:
    def _arrow156(v: int, unit_var: Any=unit_var, v0: Any=v0) -> Async[bool]:
        return closure4(v0, v)

    return _arrow156


def closure15(unit_var: None, v0: bool) -> US8:
    return US8(0, v0)


def method22(__unit: None=None) -> Callable[[bool], US8]:
    def _arrow157(v: bool) -> US8:
        return closure15(None, v)

    return _arrow157


def closure16(unit_var: None, v0: Exception) -> US8:
    return US8(1, v0)


def method23(__unit: None=None) -> Callable[[Exception], US8]:
    def _arrow158(v: Exception) -> US8:
        return closure16(None, v)

    return _arrow158


def closure14(unit_var: None, v0: Any) -> US8:
    return None


def method25(v0: Callable[[Any], US8], v1: Async[Any]) -> Async[US8]:
    def _arrow160(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US8]:
        def _arrow159(_arg: Any) -> Async[US8]:
            v109: US8 = v0(_arg)
            return singleton.Return(v109)

        return singleton.Bind(v1, _arrow159)

    return singleton.Delay(_arrow160)


def method24(v0: Callable[[Any], US8], v1: Async[Any]) -> Async[US8]:
    return method25(v0, v1)


def closure17(unit_var: None, v0: US8) -> US9:
    if v0.tag == 1:
        return US9(1, v0.fields[0])

    else: 
        return US9(0, v0.fields[0])



def method27(v0: Callable[[US8], US9], v1: Async[US8]) -> Async[US9]:
    def _arrow162(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US9]:
        def _arrow161(_arg: US8) -> Async[US9]:
            v109: US9 = v0(_arg)
            return singleton.Return(v109)

        return singleton.Bind(v1, _arrow161)

    return singleton.Delay(_arrow162)


def method26(v0: Callable[[US8], US9], v1: Async[US8]) -> Async[US9]:
    return method27(v0, v1)


def method29(v0: int) -> str:
    v2: Mut3 = Mut3(method14())
    v16_1: None
    closure7(v2, "{ ", None)
    v16_1 = None
    v35: None
    closure7(v2, "timeout", None)
    v35 = None
    v54: None
    closure7(v2, " = ", None)
    v54 = None
    v74: None
    closure7(v2, ("" + str(v0)) + "", None)
    v74 = None
    v93: None
    closure7(v2, " }", None)
    v93 = None
    return v2.l0


def method28(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int) -> str:
    v9: str = method29(v8)
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "async.run_with_timeout_async") + " / ") + v9)


def closure19(v0: int, unit_var: None) -> None:
    def v16_1(__unit: None=None, v0: Any=v0, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v17: None
    v16_1(None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
    v58: US0 = pattern_input[4].l0
    v298: US6
    class ObjectExpr163:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (0 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr163())))) == False:
        v298 = US6(1)

    else: 
        v81: None
        v16_1(None)
        v81 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v109: int64 | None = pattern_input_1[5]
        v108: Mut4 = pattern_input_1[4]
        v107: Mut3 = pattern_input_1[3]
        v106: Mut2 = pattern_input_1[2]
        v105: Mut1 = pattern_input_1[1]
        v104: Mut0 = pattern_input_1[0]
        v124: str = method28(v104, v105, v106, v107, v108, v109, method8(v104, v105, v106, v107, v108, v109), method12(), v0)
        v140: None
        v16_1(None)
        v140 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v164: Mut1 = pattern_input_2[1]
        v163: Mut0 = pattern_input_2[0]
        v185: None
        closure8(v163, None)
        v185 = None
        closure9(None, v124)
        v164.l0(v124)
        v298 = US6(0, v163, v164, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method30(__unit: None=None) -> str:
    v133: str = "Critical".lower()
    return ("\u001b[91m" + method13(v133[0])) + "\u001b[0m"


def method32(v0: int, v1: str) -> str:
    v3: Mut3 = Mut3(method14())
    v17: None
    closure7(v3, "{ ", None)
    v17 = None
    v36: None
    closure7(v3, "timeout", None)
    v36 = None
    v55: None
    closure7(v3, " = ", None)
    v55 = None
    v75: None
    closure7(v3, ("" + str(v0)) + "", None)
    v75 = None
    v94: None
    closure7(v3, "; ", None)
    v94 = None
    v113: None
    closure7(v3, "ex", None)
    v113 = None
    v130: None
    closure7(v3, " = ", None)
    v130 = None
    v147: None
    closure7(v3, v1, None)
    v147 = None
    v166: None
    closure7(v3, " }", None)
    v166 = None
    return v3.l0


def method31(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: str) -> str:
    v10: str = method32(v8, v9)
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "async.run_with_timeout_async**") + " / ") + v10)


def closure20(v0: int, v1: Exception, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v338: US6
    class ObjectExpr164:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (4 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr164())))) == False:
        v338 = US6(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v164: str = method31(v105, v106, v107, v108, v109, v110, method8(v105, v106, v107, v108, v109, v110), method30(), v0, to_text(interpolate("%A%P()", [v1])))
        v180: None
        v17(None)
        v180 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v204: Mut1 = pattern_input_2[1]
        v203: Mut0 = pattern_input_2[0]
        v225: None
        closure8(v203, None)
        v225 = None
        closure9(None, v164)
        v204.l0(v164)
        v338 = US6(0, v203, v204, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def closure18(v0: int, v1: US9) -> US7:
    if v1.tag == 0:
        return US7(0, v1.fields[0])

    else: 
        v4: Exception = v1.fields[0]
        v6: str = to_text(interpolate("%A%P()", [v4]))
        if v6.find("System.TimeoutException") >= 0:
            v328: None
            closure19(v0, None)
            v328 = None
            return US7(1)

        else: 
            v996: None
            closure20(v0, v4, None)
            v996 = None
            return US7(1)




def method34(v0: Callable[[US9], US7], v1: Async[US9]) -> Async[US7]:
    def _arrow166(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US7]:
        def _arrow165(_arg: US9) -> Async[US7]:
            v109: US7 = v0(_arg)
            return singleton.Return(v109)

        return singleton.Bind(v1, _arrow165)

    return singleton.Delay(_arrow166)


def method33(v0: Callable[[US9], US7], v1: Async[US9]) -> Async[US7]:
    return method34(v0, v1)


def method21(v0: Async[bool], v1: int) -> Async[US7]:
    def _arrow168(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US7]:
        v2886: Async[Async[bool]] = start_child(v0, v1)
        def _arrow167(_arg: Async[bool]) -> Async[US7]:
            def v2937(v_2: US9) -> US7:
                return closure18(v1, v_2)

            def v2935(v_1: US8) -> US9:
                return closure17(None, v_1)

            def v2933(v: Any) -> US8:
                return closure14(None, v)

            v2938: Async[US7] = method33(v2937, method26(v2935, method24(v2933, catch_async(_arg))))
            return singleton.ReturnFrom(v2938)

        return singleton.Bind(v2886, _arrow167)

    return singleton.Delay(_arrow168)


def method20(v0: int, v1: Async[bool]) -> Async[US7]:
    return method21(v1, v0)


def method19(v0: int, v1: str, v2: int) -> Async[bool]:
    def _arrow170(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[bool]:
        v270: Async[US7] = method20(v0, method6(v1, v2))
        def _arrow169(_arg: US7) -> Async[bool]:
            v271: US7 = _arg
            v274: bool = v271.fields[0] if (v271.tag == 0) else False
            return singleton.Return(v274)

        return singleton.Bind(v270, _arrow169)

    return singleton.Delay(_arrow170)


def method18(v0: int, v1: str, v2: int) -> Async[bool]:
    return method19(v0, v1, v2)


def closure13(v0: int, v1: str, v2: int) -> Async[bool]:
    return method18(v0, v1, v2)


def closure12(v0: int, v1: str) -> Callable[[int], Async[bool]]:
    def _arrow171(v: int, v0: Any=v0, v1: Any=v1) -> Async[bool]:
        return closure13(v0, v1, v)

    return _arrow171


def closure11(unit_var: None, v0: int) -> Callable[[str, int], Async[bool]]:
    def _arrow172(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Callable[[int], Async[bool]]:
        return closure12(v0, v)

    return _arrow172


def closure25(unit_var: None, v0: int) -> US10:
    return US10(0, v0)


def method38(__unit: None=None) -> Callable[[int], US10]:
    def _arrow173(v: int) -> US10:
        return closure25(None, v)

    return _arrow173


def method40(v0: int, v1: int64, v2: int | None, v3: bool) -> str:
    v5: Mut3 = Mut3(method14())
    v19: None
    closure7(v5, "{ ", None)
    v19 = None
    v38: None
    closure7(v5, "port", None)
    v38 = None
    v57: None
    closure7(v5, " = ", None)
    v57 = None
    v77: None
    closure7(v5, ("" + str(v0)) + "", None)
    v77 = None
    v96: None
    closure7(v5, "; ", None)
    v96 = None
    v115: None
    closure7(v5, "retry", None)
    v115 = None
    v132: None
    closure7(v5, " = ", None)
    v132 = None
    v152: None
    closure7(v5, ("" + str(v1)) + "", None)
    v152 = None
    v169: None
    closure7(v5, "; ", None)
    v169 = None
    v188: None
    closure7(v5, "timeout", None)
    v188 = None
    v205: None
    closure7(v5, " = ", None)
    v205 = None
    v264: None
    closure7(v5, to_text(interpolate("%A%P()", [v2])), None)
    v264 = None
    v281: None
    closure7(v5, "; ", None)
    v281 = None
    v300: None
    closure7(v5, "status", None)
    v300 = None
    v317: None
    closure7(v5, " = ", None)
    v317 = None
    v337: None
    closure7(v5, "true" if v3 else "false", None)
    v337 = None
    v356: None
    closure7(v5, " }", None)
    v356 = None
    return v5.l0


def method39(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: int64, v10: int | None, v11: bool) -> str:
    v12: str = method40(v8, v9, v10, v11)
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "networking.wait_for_port_access") + " / ") + v12)


def closure26(v0: int | None, v1: bool, v2: int, v3: int64, unit_var: None) -> None:
    def v19(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v20: None
    v19(None)
    v20 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
    v61: US0 = pattern_input[4].l0
    v301: US6
    class ObjectExpr174:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (0 >= find(v61, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr174())))) == False:
        v301 = US6(1)

    else: 
        v84: None
        v19(None)
        v84 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v112: int64 | None = pattern_input_1[5]
        v111: Mut4 = pattern_input_1[4]
        v110: Mut3 = pattern_input_1[3]
        v109: Mut2 = pattern_input_1[2]
        v108: Mut1 = pattern_input_1[1]
        v107: Mut0 = pattern_input_1[0]
        v127: str = method39(v107, v108, v109, v110, v111, v112, method8(v107, v108, v109, v110, v111, v112), method12(), v2, v3, v0, v1)
        v143: None
        v19(None)
        v143 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v167: Mut1 = pattern_input_2[1]
        v166: Mut0 = pattern_input_2[0]
        v188: None
        closure8(v166, None)
        v188 = None
        closure9(None, v127)
        v167.l0(v127)
        v301 = US6(0, v166, v167, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method37(v0: int | None, v1: bool, v2: str, v3: int, v4: int64) -> Async[int64]:
    def _arrow179(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> Async[int64]:
        v27651: US10 = default_arg(map(method38(), v0), US10(1))
        v27659: Async[bool] = method18(v27651.fields[0], v2, v3) if (v27651.tag == 0) else method6(v2, v3)
        def _arrow178(_arg: bool) -> Async[int64]:
            if _arg == v1:
                return singleton.Return(v4)

            else: 
                v27663: bool = op_modulus(v4, int64(100)) == int64(0)
                def _arrow175(__unit: None=None) -> Async[None]:
                    v27977: None
                    closure26(v0, v1, v3, v4, None)
                    v27977 = None
                    return singleton.Zero()

                def _arrow177(__unit: None=None) -> Async[int64]:
                    v28306: Async[None] = sleep(10)
                    def _arrow176(__unit: None=None) -> Async[int64]:
                        v28318: Async[int64] = method36(v0, v1, v2, v3, op_addition(v4, int64(1)))
                        return singleton.ReturnFrom(v28318)

                    return singleton.Bind(v28306, _arrow176)

                return singleton.Combine(_arrow175() if v27663 else singleton.Zero(), singleton.Delay(_arrow177))


        return singleton.Bind(v27659, _arrow178)

    return singleton.Delay(_arrow179)


def method36(v0: int | None, v1: bool, v2: str, v3: int, v4: int64) -> Async[int64]:
    return method37(v0, v1, v2, v3, v4)


def method35(v0: int | None, v1: bool, v2: str, v3: int) -> Async[int64]:
    return method36(v0, v1, v2, v3, int64(1))


def closure24(v0: int | None, v1: bool, v2: str, v3: int) -> Async[int64]:
    return method35(v0, v1, v2, v3)


def closure23(v0: int | None, v1: bool, v2: str) -> Callable[[int], Async[int64]]:
    def _arrow180(v: int, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[int64]:
        return closure24(v0, v1, v2, v)

    return _arrow180


def closure22(v0: int | None, v1: bool) -> Callable[[str, int], Async[int64]]:
    def _arrow181(v: str, v0: Any=v0, v1: Any=v1) -> Callable[[int], Async[int64]]:
        return closure23(v0, v1, v)

    return _arrow181


def closure21(unit_var: None, v0: int | None=None) -> Callable[[bool, str, int], Async[int64]]:
    def _arrow182(v: bool, unit_var: Any=unit_var, v0: Any=v0) -> Callable[[str, int], Async[int64]]:
        return closure22(v0, v)

    return _arrow182


def method43(v0: int | None, v1: str, v2: int) -> Async[int]:
    def _arrow184(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[int]:
        v1533: US10 = default_arg(map(method38(), v0), US10(1))
        v1541: Async[bool] = method18(v1533.fields[0], v1, v2) if (v1533.tag == 0) else method6(v1, v2)
        def _arrow183(_arg: bool) -> Async[int]:
            if _arg == False:
                return singleton.Return(v2)

            else: 
                v1545: Async[int] = method42(v0, v1, v2 + 1)
                return singleton.ReturnFrom(v1545)


        return singleton.Bind(v1541, _arrow183)

    return singleton.Delay(_arrow184)


def method42(v0: int | None, v1: str, v2: int) -> Async[int]:
    return method43(v0, v1, v2)


def method41(v0: int | None, v1: str, v2: int) -> Async[int]:
    return method42(v0, v1, v2)


def closure29(v0: int | None, v1: str, v2: int) -> Async[int]:
    return method41(v0, v1, v2)


def closure28(v0: int | None, v1: str) -> Callable[[int], Async[int]]:
    def _arrow185(v: int, v0: Any=v0, v1: Any=v1) -> Async[int]:
        return closure29(v0, v1, v)

    return _arrow185


def closure27(unit_var: None, v0: int | None=None) -> Callable[[str, int], Async[int]]:
    def _arrow186(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Callable[[int], Async[int]]:
        return closure28(v0, v)

    return _arrow186


v14: None = None

def _arrow187(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow187

def _expr188():
    v15(None)
    return v14


v16: None = _expr188()

def _arrow189(v: str) -> Callable[[int], Async[bool]]:
    return closure3(None, v)


v31: Callable[[str, int], Async[bool]] = _arrow189

def test_port_open(x: str) -> Callable[[int], Async[bool]]:
    return v31(x)


def _arrow190(v: int) -> Callable[[str, int], Async[bool]]:
    return closure11(None, v)


v32: Callable[[int, str, int], Async[bool]] = _arrow190

def test_port_open_timeout(x: int) -> Callable[[str, int], Async[bool]]:
    return v32(x)


def _arrow191(v: int | None=None) -> Callable[[bool, str, int], Async[int64]]:
    return closure21(None, v)


v33: Callable[[int | None, bool, str, int], Async[int64]] = _arrow191

def wait_for_port_access(x: int | None=None) -> Callable[[bool, str, int], Async[int64]]:
    return v33(x)


def _arrow192(v: int | None=None) -> Callable[[str, int], Async[int]]:
    return closure27(None, v)


v34: Callable[[int | None, str, int], Async[int]] = _arrow192

def get_available_port(x: int | None=None) -> Callable[[str, int], Async[int]]:
    return v34(x)


