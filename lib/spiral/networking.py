from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.async_ import (cancellation_token, await_task, start_child, catch_async, sleep)
from fable_modules.fable_library.async_builder import (singleton, CancellationToken, Async)
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.list import (to_array, empty, of_array)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition, op_modulus)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_3, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type, class_type, int32_type)
from fable_modules.fable_library.string_ import (trim_end, trim_start, to_text, interpolate)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Array, Union, Record)
from fable_modules.fable_library.util import (create_atom, to_enumerable, compare, int64_to_string, IDisposable)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


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
    return union_type("Networking.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5"]


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
    return union_type("Networking.US6", [], US6, lambda: [[("f0_0", bool_type)], []])


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
    return union_type("Networking.US7", [], US7, lambda: [[("f0_0", bool_type)], [("f1_0", class_type("System.Exception"))]])


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
    return union_type("Networking.US9", [], US9, lambda: [[("f0_0", int32_type)], []])


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

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow145(v: str) -> US5:
        return closure1(None, v)

    return _arrow145


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
    def _arrow146(__unit: None=None) -> US1:
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









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow146(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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



def method8(v0: US0) -> bool:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
    v56: US0 = pattern_input[4].l0
    if pattern_input[2].l0 == False:
        return False

    else: 
        class ObjectExpr147:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        class ObjectExpr148:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        return find(v0, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr147())) >= find(v56, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr148()))



def closure6(unit_var: None, v0: int64) -> US2:
    return US2(0, v0)


def method10(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow149(v: int64) -> US2:
        return closure6(None, v)

    return _arrow149


def method11(__unit: None=None) -> str:
    return "hh:mm:ss"


def method12(__unit: None=None) -> str:
    return "HH:mm:ss"


def method9(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v804: US2 = default_arg(map(method10(), v5), US2(1))
    v936: Any
    if v804.tag == 0:
        v884: Any = create(op_subtraction(from_value(ticks_1(now()), False), v804.fields[0]))
        v936 = create_1(1, 1, 1, hours(v884), minutes(v884), seconds(v884), milliseconds(v884))

    else: 
        v936 = now()

    v938: str = method12()
    return to_string(v936, "M-d-y hh:mm:ss tt" if (v938 == "") else v938)


def method14(__unit: None=None) -> str:
    return ""


def closure7(v0: Mut3, v1: str, unit_var: None) -> None:
    v4: str = v0.l0 + v1
    v0.l0 = v4


def method15(__unit: None=None) -> str:
    return "\u001b[0m"


def method13(__unit: None=None) -> str:
    v4: str = "Verbose".lower()
    v7: str = v4[0]
    v9: Mut3 = Mut3(method14())
    v24: None
    closure7(v9, ("" + str(v7)) + "", None)
    v24 = None
    return ("\u001b[90m" + v9.l0) + method15()


def method17(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method16(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: str) -> str:
    v11: Mut3 = Mut3(method14())
    v25: None
    closure7(v11, "{ ", None)
    v25 = None
    v44: None
    closure7(v11, "port", None)
    v44 = None
    v63: None
    closure7(v11, " = ", None)
    v63 = None
    v83: None
    closure7(v11, ("" + str(v8)) + "", None)
    v83 = None
    v102: None
    closure7(v11, "; ", None)
    v102 = None
    v121: None
    closure7(v11, "ex", None)
    v121 = None
    v138: None
    closure7(v11, " = ", None)
    v138 = None
    v155: None
    closure7(v11, v9, None)
    v155 = None
    v174: None
    closure7(v11, " }", None)
    v174 = None
    v180: str = v11.l0
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "networking.test_port_open") + " / ") + v180)


def closure8(v0: Mut0, unit_var: None) -> None:
    v2: int64 = op_addition(v0.l0, int64(1))
    v0.l0 = v2


def closure10(v0: str, unit_var: None) -> None:
    print(v0)


def closure9(unit_var: None, v0: str) -> None:
    v4: None
    closure10(v0, None)
    v4 = None


def method18(v0: str) -> None:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
    v60: None
    closure8(pattern_input[0], None)
    v60 = None
    closure9(None, v0)
    pattern_input[1].l0(v0)


def closure5(v0: int, v1: Exception, unit_var: None) -> None:
    if method8(US0(0)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v46: int64 | None = pattern_input[5]
        v45: Mut4 = pattern_input[4]
        v44: Mut3 = pattern_input[3]
        v43: Mut2 = pattern_input[2]
        v42: Mut1 = pattern_input[1]
        v41: Mut0 = pattern_input[0]
        method18(method16(v41, v42, v43, v44, v45, v46, method9(v41, v42, v43, v44, v45, v46), method13(), v0, to_text(interpolate("%A%P()", [v1]))))



def method7(v0: str, v1: int) -> Async[bool]:
    def _arrow155(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[bool]:
        v37748: Async[CancellationToken] = cancellation_token()
        def _arrow154(_arg: CancellationToken) -> Async[bool]:
            def _arrow153(_arg_1: IDisposable) -> Async[bool]:
                def _arrow151(__unit: None=None) -> Async[bool]:
                    v37984: Async[None] = await_task(None)
                    def _arrow150(__unit: None=None) -> Async[bool]:
                        return singleton.Return(True)

                    return singleton.Bind(v37984, _arrow150)

                def _arrow152(_arg_3: Exception) -> Async[bool]:
                    v38394: None
                    closure5(v1, _arg_3, None)
                    v38394 = None
                    return singleton.Return(False)

                return singleton.TryWith(singleton.Delay(_arrow151), _arrow152)

            return singleton.Using(None, _arrow153)

        return singleton.Bind(v37748, _arrow154)

    return singleton.Delay(_arrow155)


def method6(v0: str, v1: int) -> Async[bool]:
    return method7(v0, v1)


def closure4(v0: str, v1: int) -> Async[bool]:
    return method6(v0, v1)


def closure3(unit_var: None, v0: str) -> Callable[[int], Async[bool]]:
    def _arrow156(v: int, unit_var: Any=unit_var, v0: Any=v0) -> Async[bool]:
        return closure4(v0, v)

    return _arrow156


def closure14(unit_var: None, v0: bool) -> US7:
    return US7(0, v0)


def method24(__unit: None=None) -> Callable[[bool], US7]:
    def _arrow157(v: bool) -> US7:
        return closure14(None, v)

    return _arrow157


def closure15(unit_var: None, v0: Exception) -> US7:
    return US7(1, v0)


def method25(__unit: None=None) -> Callable[[Exception], US7]:
    def _arrow158(v: Exception) -> US7:
        return closure15(None, v)

    return _arrow158


def method23(v0: Async[Any]) -> Async[US7]:
    def _arrow160(__unit: None=None, v0: Any=v0) -> Async[US7]:
        def _arrow159(_arg: Any) -> Async[US7]:
            return singleton.Return(None)

        return singleton.Bind(v0, _arrow159)

    return singleton.Delay(_arrow160)


def method26(v0: Async[US7]) -> Async[US8]:
    def _arrow162(__unit: None=None, v0: Any=v0) -> Async[US8]:
        def _arrow161(_arg: US7) -> Async[US8]:
            v307: US7 = _arg
            v313: US8 = US8(1, v307.fields[0]) if (v307.tag == 1) else US8(0, v307.fields[0])
            return singleton.Return(v313)

        return singleton.Bind(v0, _arrow161)

    return singleton.Delay(_arrow162)


def method28(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int) -> str:
    v10: Mut3 = Mut3(method14())
    v24: None
    closure7(v10, "{ ", None)
    v24 = None
    v43: None
    closure7(v10, "timeout", None)
    v43 = None
    v62: None
    closure7(v10, " = ", None)
    v62 = None
    v82: None
    closure7(v10, ("" + str(v8)) + "", None)
    v82 = None
    v101: None
    closure7(v10, " }", None)
    v101 = None
    v107: str = v10.l0
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "async.run_with_timeout_async") + " / ") + v107)


def closure16(v0: int, unit_var: None) -> None:
    if method8(US0(0)):
        v19: None
        closure0(None, None)
        v19 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v45: int64 | None = pattern_input[5]
        v44: Mut4 = pattern_input[4]
        v43: Mut3 = pattern_input[3]
        v42: Mut2 = pattern_input[2]
        v41: Mut1 = pattern_input[1]
        v40: Mut0 = pattern_input[0]
        method18(method28(v40, v41, v42, v43, v44, v45, method9(v40, v41, v42, v43, v44, v45), method13(), v0))



def method29(__unit: None=None) -> str:
    v4: str = "Critical".lower()
    v7: str = v4[0]
    v9: Mut3 = Mut3(method14())
    v24: None
    closure7(v9, ("" + str(v7)) + "", None)
    v24 = None
    return ("\u001b[91m" + v9.l0) + method15()


def method30(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: str) -> str:
    v11: Mut3 = Mut3(method14())
    v25: None
    closure7(v11, "{ ", None)
    v25 = None
    v44: None
    closure7(v11, "timeout", None)
    v44 = None
    v63: None
    closure7(v11, " = ", None)
    v63 = None
    v83: None
    closure7(v11, ("" + str(v8)) + "", None)
    v83 = None
    v102: None
    closure7(v11, "; ", None)
    v102 = None
    v121: None
    closure7(v11, "ex", None)
    v121 = None
    v138: None
    closure7(v11, " = ", None)
    v138 = None
    v155: None
    closure7(v11, v9, None)
    v155 = None
    v174: None
    closure7(v11, " }", None)
    v174 = None
    v180: str = v11.l0
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "async.run_with_timeout_async**") + " / ") + v180)


def closure17(v0: int, v1: Exception, unit_var: None) -> None:
    if method8(US0(4)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v46: int64 | None = pattern_input[5]
        v45: Mut4 = pattern_input[4]
        v44: Mut3 = pattern_input[3]
        v43: Mut2 = pattern_input[2]
        v42: Mut1 = pattern_input[1]
        v41: Mut0 = pattern_input[0]
        method18(method30(v41, v42, v43, v44, v45, v46, method9(v41, v42, v43, v44, v45, v46), method29(), v0, to_text(interpolate("%A%P()", [v1]))))



def method27(v0: int, v1: Async[US8]) -> Async[US6]:
    def _arrow164(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US6]:
        def _arrow163(_arg: US8) -> Async[US6]:
            v13508: US8 = _arg
            v13844: US6
            if v13508.tag == 0:
                v13844 = US6(0, v13508.fields[0])

            else: 
                v13511: Exception = v13508.fields[0]
                v13513: str = to_text(interpolate("%A%P()", [v13511]))
                if v13513.find("System.TimeoutException") >= 0:
                    v13584: None
                    closure16(v0, None)
                    v13584 = None
                    v13844 = US6(1)

                else: 
                    v13744: None
                    closure17(v0, v13511, None)
                    v13744 = None
                    v13844 = US6(1)


            return singleton.Return(v13844)

        return singleton.Bind(v1, _arrow163)

    return singleton.Delay(_arrow164)


def method22(v0: Async[bool], v1: int) -> Async[US6]:
    def _arrow166(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US6]:
        v2526: Async[Async[bool]] = start_child(v0, v1)
        def _arrow165(_arg: Async[bool]) -> Async[US6]:
            v2569: Async[US6] = method27(v1, method26(method23(catch_async(_arg))))
            return singleton.ReturnFrom(v2569)

        return singleton.Bind(v2526, _arrow165)

    return singleton.Delay(_arrow166)


def method21(v0: int, v1: Async[bool]) -> Async[US6]:
    return method22(v1, v0)


def method20(v0: int, v1: str, v2: int) -> Async[bool]:
    def _arrow168(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[bool]:
        v270: Async[US6] = method21(v0, method6(v1, v2))
        def _arrow167(_arg: US6) -> Async[bool]:
            v271: US6 = _arg
            v274: bool = v271.fields[0] if (v271.tag == 0) else False
            return singleton.Return(v274)

        return singleton.Bind(v270, _arrow167)

    return singleton.Delay(_arrow168)


def method19(v0: int, v1: str, v2: int) -> Async[bool]:
    return method20(v0, v1, v2)


def closure13(v0: int, v1: str, v2: int) -> Async[bool]:
    return method19(v0, v1, v2)


def closure12(v0: int, v1: str) -> Callable[[int], Async[bool]]:
    def _arrow169(v: int, v0: Any=v0, v1: Any=v1) -> Async[bool]:
        return closure13(v0, v1, v)

    return _arrow169


def closure11(unit_var: None, v0: int) -> Callable[[str, int], Async[bool]]:
    def _arrow170(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Callable[[int], Async[bool]]:
        return closure12(v0, v)

    return _arrow170


def closure22(unit_var: None, v0: int) -> US9:
    return US9(0, v0)


def method34(__unit: None=None) -> Callable[[int], US9]:
    def _arrow171(v: int) -> US9:
        return closure22(None, v)

    return _arrow171


def method35(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: int64, v10: int | None, v11: bool) -> str:
    v13: Mut3 = Mut3(method14())
    v27: None
    closure7(v13, "{ ", None)
    v27 = None
    v46: None
    closure7(v13, "port", None)
    v46 = None
    v65: None
    closure7(v13, " = ", None)
    v65 = None
    v85: None
    closure7(v13, ("" + str(v8)) + "", None)
    v85 = None
    v104: None
    closure7(v13, "; ", None)
    v104 = None
    v123: None
    closure7(v13, "retry", None)
    v123 = None
    v140: None
    closure7(v13, " = ", None)
    v140 = None
    v160: None
    closure7(v13, ("" + str(v9)) + "", None)
    v160 = None
    v177: None
    closure7(v13, "; ", None)
    v177 = None
    v196: None
    closure7(v13, "timeout", None)
    v196 = None
    v213: None
    closure7(v13, " = ", None)
    v213 = None
    v269: None
    closure7(v13, to_text(interpolate("%A%P()", [v10])), None)
    v269 = None
    v286: None
    closure7(v13, "; ", None)
    v286 = None
    v305: None
    closure7(v13, "status", None)
    v305 = None
    v322: None
    closure7(v13, " = ", None)
    v322 = None
    v342: None
    closure7(v13, "true" if v11 else "false", None)
    v342 = None
    v361: None
    closure7(v13, " }", None)
    v361 = None
    v367: str = v13.l0
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "networking.wait_for_port_access") + " / ") + v367)


def closure23(v0: int | None, v1: bool, v2: int, v3: int64, unit_var: None) -> None:
    if method8(US0(0)):
        v22: None
        closure0(None, None)
        v22 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_3(TraceState_trace_state())
        v48: int64 | None = pattern_input[5]
        v47: Mut4 = pattern_input[4]
        v46: Mut3 = pattern_input[3]
        v45: Mut2 = pattern_input[2]
        v44: Mut1 = pattern_input[1]
        v43: Mut0 = pattern_input[0]
        method18(method35(v43, v44, v45, v46, v47, v48, method9(v43, v44, v45, v46, v47, v48), method13(), v2, v3, v0, v1))



def method33(v0: int | None, v1: bool, v2: str, v3: int, v4: int64) -> Async[int64]:
    def _arrow176(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> Async[int64]:
        v7415: US9 = default_arg(map(method34(), v0), US9(1))
        v7423: Async[bool] = method19(v7415.fields[0], v2, v3) if (v7415.tag == 0) else method6(v2, v3)
        def _arrow175(_arg: bool) -> Async[int64]:
            if _arg == v1:
                return singleton.Return(v4)

            else: 
                v7427: bool = op_modulus(v4, int64(100)) == int64(0)
                def _arrow172(__unit: None=None) -> Async[None]:
                    v7490: None
                    closure23(v0, v1, v3, v4, None)
                    v7490 = None
                    return singleton.Zero()

                def _arrow174(__unit: None=None) -> Async[int64]:
                    v7565: Async[None] = sleep(10)
                    def _arrow173(__unit: None=None) -> Async[int64]:
                        v7574: Async[int64] = method32(v0, v1, v2, v3, op_addition(v4, int64(1)))
                        return singleton.ReturnFrom(v7574)

                    return singleton.Bind(v7565, _arrow173)

                return singleton.Combine(_arrow172() if v7427 else singleton.Zero(), singleton.Delay(_arrow174))


        return singleton.Bind(v7423, _arrow175)

    return singleton.Delay(_arrow176)


def method32(v0: int | None, v1: bool, v2: str, v3: int, v4: int64) -> Async[int64]:
    return method33(v0, v1, v2, v3, v4)


def method31(v0: int | None, v1: bool, v2: str, v3: int) -> Async[int64]:
    return method32(v0, v1, v2, v3, int64(1))


def closure21(v0: int | None, v1: bool, v2: str, v3: int) -> Async[int64]:
    return method31(v0, v1, v2, v3)


def closure20(v0: int | None, v1: bool, v2: str) -> Callable[[int], Async[int64]]:
    def _arrow177(v: int, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[int64]:
        return closure21(v0, v1, v2, v)

    return _arrow177


def closure19(v0: int | None, v1: bool) -> Callable[[str, int], Async[int64]]:
    def _arrow178(v: str, v0: Any=v0, v1: Any=v1) -> Callable[[int], Async[int64]]:
        return closure20(v0, v1, v)

    return _arrow178


def closure18(unit_var: None, v0: int | None=None) -> Callable[[bool, str, int], Async[int64]]:
    def _arrow179(v: bool, unit_var: Any=unit_var, v0: Any=v0) -> Callable[[str, int], Async[int64]]:
        return closure19(v0, v)

    return _arrow179


def method38(v0: int | None, v1: str, v2: int) -> Async[int]:
    def _arrow181(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[int]:
        v1533: US9 = default_arg(map(method34(), v0), US9(1))
        v1541: Async[bool] = method19(v1533.fields[0], v1, v2) if (v1533.tag == 0) else method6(v1, v2)
        def _arrow180(_arg: bool) -> Async[int]:
            if _arg == False:
                return singleton.Return(v2)

            else: 
                v1545: Async[int] = method37(v0, v1, v2 + 1)
                return singleton.ReturnFrom(v1545)


        return singleton.Bind(v1541, _arrow180)

    return singleton.Delay(_arrow181)


def method37(v0: int | None, v1: str, v2: int) -> Async[int]:
    return method38(v0, v1, v2)


def method36(v0: int | None, v1: str, v2: int) -> Async[int]:
    return method37(v0, v1, v2)


def closure26(v0: int | None, v1: str, v2: int) -> Async[int]:
    return method36(v0, v1, v2)


def closure25(v0: int | None, v1: str) -> Callable[[int], Async[int]]:
    def _arrow182(v: int, v0: Any=v0, v1: Any=v1) -> Async[int]:
        return closure26(v0, v1, v)

    return _arrow182


def closure24(unit_var: None, v0: int | None=None) -> Callable[[str, int], Async[int]]:
    def _arrow183(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Callable[[int], Async[int]]:
        return closure25(v0, v)

    return _arrow183


v14: None = None

def _arrow184(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow184

def _expr185():
    v15(None)
    return v14


v16: None = _expr185()

def _arrow186(v: str) -> Callable[[int], Async[bool]]:
    return closure3(None, v)


v31: Callable[[str, int], Async[bool]] = _arrow186

def test_port_open(x: str) -> Callable[[int], Async[bool]]:
    return v31(x)


def _arrow187(v: int) -> Callable[[str, int], Async[bool]]:
    return closure11(None, v)


v32: Callable[[int, str, int], Async[bool]] = _arrow187

def test_port_open_timeout(x: int) -> Callable[[str, int], Async[bool]]:
    return v32(x)


def _arrow188(v: int | None=None) -> Callable[[bool, str, int], Async[int64]]:
    return closure18(None, v)


v33: Callable[[int | None, bool, str, int], Async[int64]] = _arrow188

def wait_for_port_access(x: int | None=None) -> Callable[[bool, str, int], Async[int64]]:
    return v33(x)


def _arrow189(v: int | None=None) -> Callable[[str, int], Async[int]]:
    return closure24(None, v)


v34: Callable[[int | None, str, int], Async[int]] = _arrow189

def get_available_port(x: int | None=None) -> Callable[[str, int], Async[int]]:
    return v34(x)


