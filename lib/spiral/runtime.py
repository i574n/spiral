from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.async_ import (start_immediate, await_task)
from fable_modules.fable_library.async_builder import (Async, CancellationToken, singleton)
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.list import (to_array, empty, of_array, cons, FSharpList)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition, to_int, from_integer)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_12, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type, option_type, char_type, class_type, int32_type, tuple_type, array_type)
from fable_modules.fable_library.result import FSharpResult_2
from fable_modules.fable_library.seq import delay
from fable_modules.fable_library.string_ import (trim_end, trim_start, to_text, interpolate, concat, join)
from fable_modules.fable_library.system_text import (StringBuilder__Clear, StringBuilder__Append_Z721C83C5, StringBuilder__ctor_Z721C83C5)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Array, Union, Record)
from fable_modules.fable_library.util import (create_atom, int64_to_string, to_enumerable, compare, IEnumerable_1)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

def _expr193() -> TypeInfo:
    return union_type("Runtime.US0", [], US0, lambda: [[], [], [], [], []])


class US0(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US0_0", "US0_1", "US0_2", "US0_3", "US0_4"]


US0_reflection = _expr193

def _expr194() -> TypeInfo:
    return record_type("Runtime.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr194

def _expr195() -> TypeInfo:
    return record_type("Runtime.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr195

def _expr196() -> TypeInfo:
    return record_type("Runtime.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr196

def _expr197() -> TypeInfo:
    return record_type("Runtime.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr197

def _expr198() -> TypeInfo:
    return record_type("Runtime.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr198

def _expr199() -> TypeInfo:
    return union_type("Runtime.US1", [], US1, lambda: [[("f0_0", US0_reflection())], []])


class US1(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US1_0", "US1_1"]


US1_reflection = _expr199

def _expr200() -> TypeInfo:
    return union_type("Runtime.US2", [], US2, lambda: [[("f0_0", int64_type)], []])


class US2(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US2_0", "US2_1"]


US2_reflection = _expr200

def _expr201() -> TypeInfo:
    return union_type("Runtime.US3", [], US3, lambda: [[], [], []])


class US3(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US3_0", "US3_1", "US3_2"]


US3_reflection = _expr201

def _expr202() -> TypeInfo:
    return union_type("Runtime.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())], [("f6_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5", "US4_6"]


US4_reflection = _expr202

def _expr203() -> TypeInfo:
    return union_type("Runtime.US5", [], US5, lambda: [[("f0_0", string_type)], []])


class US5(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US5_0", "US5_1"]


US5_reflection = _expr203

def _expr204() -> TypeInfo:
    return union_type("Runtime.US6", [], US6, lambda: [[("f0_0", Mut0_reflection()), ("f0_1", Mut1_reflection()), ("f0_2", Mut2_reflection()), ("f0_3", Mut3_reflection()), ("f0_4", Mut4_reflection()), ("f0_5", option_type(int64_type))], []])


class US6(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US6_0", "US6_1"]


US6_reflection = _expr204

def _expr205() -> TypeInfo:
    return union_type("Runtime.US7", [], US7, lambda: [[("f0_0", string_type), ("f0_1", US5_reflection())], [("f1_0", string_type)]])


class US7(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US7_0", "US7_1"]


US7_reflection = _expr205

def _expr206() -> TypeInfo:
    return union_type("Runtime.US8", [], US8, lambda: [[("f0_0", char_type), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US8(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US8_0", "US8_1"]


US8_reflection = _expr206

def _expr207() -> TypeInfo:
    return union_type("Runtime.UH0", [], UH0, lambda: [[], [("Item1", char_type), ("Item2", UH0_reflection())]])


class UH0(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH0_0", "UH0_1"]


UH0_reflection = _expr207

def _expr208() -> TypeInfo:
    return union_type("Runtime.UH1", [], UH1, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US8_reflection())), ("Item2", UH1_reflection())]])


class UH1(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH1_0", "UH1_1"]


UH1_reflection = _expr208

def _expr209() -> TypeInfo:
    return union_type("Runtime.US9", [], US9, lambda: [[("f0_0", string_type), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US9(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US9_0", "US9_1"]


US9_reflection = _expr209

def _expr210() -> TypeInfo:
    return union_type("Runtime.US10", [], US10, lambda: [[("f0_0", char_type)], []])


class US10(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US10_0", "US10_1"]


US10_reflection = _expr210

def _expr211() -> TypeInfo:
    return union_type("Runtime.US11", [], US11, lambda: [[("f0_0", string_type), ("f0_1", class_type("System.Text.StringBuilder")), ("f0_2", int32_type), ("f0_3", int32_type)], [("f1_0", string_type)]])


class US11(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US11_0", "US11_1"]


US11_reflection = _expr211

def _expr212() -> TypeInfo:
    return union_type("Runtime.US12", [], US12, lambda: [[("f0_0", string_type), ("f0_1", US5_reflection()), ("f0_2", string_type), ("f0_3", class_type("System.Text.StringBuilder")), ("f0_4", int32_type), ("f0_5", int32_type)], [("f1_0", string_type)]])


class US12(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US12_0", "US12_1"]


US12_reflection = _expr212

def _expr213() -> TypeInfo:
    return union_type("Runtime.US13", [], US13, lambda: [[("f0_0", US10_reflection()), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US13(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US13_0", "US13_1"]


US13_reflection = _expr213

def _expr214() -> TypeInfo:
    return union_type("Runtime.US14", [], US14, lambda: [[("f0_0", US5_reflection()), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US14(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US14_0", "US14_1"]


US14_reflection = _expr214

def _expr215() -> TypeInfo:
    return record_type("Runtime.Mut5", [], Mut5, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut5(Record):
    l0: int

Mut5_reflection = _expr215

def _expr216() -> TypeInfo:
    return union_type("Runtime.US15", [], US15, lambda: [[("f0_0", lambda_type(tuple_type(int32_type, string_type, bool_type), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [unit_type])))], []])


class US15(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US15_0", "US15_1"]


US15_reflection = _expr216

def _expr217() -> TypeInfo:
    return union_type("Runtime.US16", [], US16, lambda: [[("f0_0", class_type("System.Threading.CancellationToken"))], []])


class US16(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US16_0", "US16_1"]


US16_reflection = _expr217

def _expr218() -> TypeInfo:
    return record_type("Runtime.Heap0", [], Heap0, lambda: [("l0", string_type), ("l1", option_type(class_type("System.Threading.CancellationToken"))), ("l2", array_type(tuple_type(string_type, string_type))), ("l3", option_type(lambda_type(tuple_type(int32_type, string_type, bool_type), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [unit_type])))), ("l4", option_type(lambda_type(class_type("Runtime.std_sync_Arc`1", [class_type("Runtime.std_sync_Mutex`1", [class_type("Runtime.std_process_ChildStdin")])]), unit_type))), ("l5", bool_type), ("l6", option_type(string_type))])


@dataclass(eq = False, repr = False, slots = True)
class Heap0(Record):
    l0: str
    l1: CancellationToken | None
    l2: Array[tuple[str, str]]
    l3: Callable[[tuple[int, str, bool]], Async[None]] | None
    l4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None
    l5: bool
    l6: str | None

Heap0_reflection = _expr218

def _expr219() -> TypeInfo:
    return union_type("Runtime.US17", [], US17, lambda: [[("f0_0", array_type(string_type))], [("f1_0", string_type)]])


class US17(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US17_0", "US17_1"]


US17_reflection = _expr219

def _expr220() -> TypeInfo:
    return union_type("Runtime.UH2", [], UH2, lambda: [[], [("Item1", string_type), ("Item2", UH2_reflection())]])


class UH2(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH2_0", "UH2_1"]


UH2_reflection = _expr220

def _expr221() -> TypeInfo:
    return union_type("Runtime.US18", [], US18, lambda: [[("f0_0", UH2_reflection()), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US18(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US18_0", "US18_1"]


US18_reflection = _expr221

def _expr222() -> TypeInfo:
    return union_type("Runtime.UH3", [], UH3, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US9_reflection())), ("Item2", UH3_reflection())]])


class UH3(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH3_0", "UH3_1"]


UH3_reflection = _expr222

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow223(v: str) -> US5:
        return closure1(None, v)

    return _arrow223


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
        v44 = value_12(_v38)

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
    def _arrow224(__unit: None=None) -> US1:
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









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow224(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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


def method8(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow225(v: int64) -> US2:
        return closure6(None, v)

    return _arrow225


def method9(__unit: None=None) -> str:
    return "hh:mm:ss"


def method10(__unit: None=None) -> str:
    return "HH:mm:ss"


def method7(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v827: US2 = default_arg(map(method8(), v5), US2(1))
    v967: Any
    if v827.tag == 0:
        v910: Any = create(op_subtraction(from_value(ticks_1(now()), False), v827.fields[0]))
        v967 = create_1(1, 1, 1, hours(v910), minutes(v910), seconds(v910), milliseconds(v910))

    else: 
        v967 = now()

    v968: str = method10()
    return to_string(v967, "M-d-y hh:mm:ss tt" if (v968 == "") else v968)


def method13(__unit: None=None) -> str:
    return ""


def closure7(v0: Mut3, v1: str, unit_var: None) -> None:
    v4: str = v0.l0 + v1
    v0.l0 = v4


def method12(v0: str) -> str:
    v2: Mut3 = Mut3(method13())
    v17: None
    closure7(v2, ("" + str(v0)) + "", None)
    v17 = None
    return v2.l0


def method14(__unit: None=None) -> str:
    return "\u001b[0m"


def method11(__unit: None=None) -> str:
    v4: str = "Warning".lower()
    return ("\u001b[93m" + method12(v4[0])) + method14()


def method16(__unit: None=None) -> str:
    v1: Mut3 = Mut3(method13())
    return v1.l0


def method17(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method15(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str) -> str:
    v8: str = method16()
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 3") + " / ") + v8)


def closure8(v0: Mut0, unit_var: None) -> None:
    v2: int64 = op_addition(v0.l0, int64(1))
    v0.l0 = v2


def closure10(v0: str, unit_var: None) -> None:
    print(v0)


def closure9(unit_var: None, v0: str) -> None:
    v4: None
    closure10(v0, None)
    v4 = None


def closure5(unit_var: None, unit_var_1: None) -> None:
    def v15_1(__unit: None=None, unit_var: Any=unit_var, unit_var_1: Any=unit_var_1) -> None:
        closure0(None, None)

    v16_1: None
    v15_1(None)
    v16_1 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v57: US0 = pattern_input[4].l0
    v297: US6
    class ObjectExpr226:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v57, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr226())))) == False:
        v297 = US6(1)

    else: 
        v80: None
        v15_1(None)
        v80 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v108: int64 | None = pattern_input_1[5]
        v107: Mut4 = pattern_input_1[4]
        v106: Mut3 = pattern_input_1[3]
        v105: Mut2 = pattern_input_1[2]
        v104: Mut1 = pattern_input_1[1]
        v103: Mut0 = pattern_input_1[0]
        v123: str = method15(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11())
        v139: None
        v15_1(None)
        v139 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v163: Mut1 = pattern_input_2[1]
        v162: Mut0 = pattern_input_2[0]
        v184: None
        closure8(v162, None)
        v184 = None
        closure9(None, v123)
        v163.l0(v123)
        v297 = US6(0, v162, v163, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method18(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str) -> str:
    v8: str = method16()
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 2") + " / ") + v8)


def closure11(unit_var: None, unit_var_1: None) -> None:
    def v15_1(__unit: None=None, unit_var: Any=unit_var, unit_var_1: Any=unit_var_1) -> None:
        closure0(None, None)

    v16_1: None
    v15_1(None)
    v16_1 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v57: US0 = pattern_input[4].l0
    v297: US6
    class ObjectExpr227:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v57, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr227())))) == False:
        v297 = US6(1)

    else: 
        v80: None
        v15_1(None)
        v80 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v108: int64 | None = pattern_input_1[5]
        v107: Mut4 = pattern_input_1[4]
        v106: Mut3 = pattern_input_1[3]
        v105: Mut2 = pattern_input_1[2]
        v104: Mut1 = pattern_input_1[1]
        v103: Mut0 = pattern_input_1[0]
        v123: str = method18(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11())
        v139: None
        v15_1(None)
        v139 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v163: Mut1 = pattern_input_2[1]
        v162: Mut0 = pattern_input_2[0]
        v184: None
        closure8(v162, None)
        v184 = None
        closure9(None, v123)
        v163.l0(v123)
        v297 = US6(0, v162, v163, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method19(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str) -> str:
    v8: str = method16()
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 1") + " / ") + v8)


def closure12(unit_var: None, unit_var_1: None) -> None:
    def v15_1(__unit: None=None, unit_var: Any=unit_var, unit_var_1: Any=unit_var_1) -> None:
        closure0(None, None)

    v16_1: None
    v15_1(None)
    v16_1 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v57: US0 = pattern_input[4].l0
    v297: US6
    class ObjectExpr228:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v57, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr228())))) == False:
        v297 = US6(1)

    else: 
        v80: None
        v15_1(None)
        v80 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v108: int64 | None = pattern_input_1[5]
        v107: Mut4 = pattern_input_1[4]
        v106: Mut3 = pattern_input_1[3]
        v105: Mut2 = pattern_input_1[2]
        v104: Mut1 = pattern_input_1[1]
        v103: Mut0 = pattern_input_1[0]
        v123: str = method19(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11())
        v139: None
        v15_1(None)
        v139 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v163: Mut1 = pattern_input_2[1]
        v162: Mut0 = pattern_input_2[0]
        v184: None
        closure8(v162, None)
        v184 = None
        closure9(None, v123)
        v163.l0(v123)
        v297 = US6(0, v162, v163, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def closure4(unit_var: None, unit_var_1: None) -> None:
    pass


def method6(__unit: None=None) -> None:
    pass


def closure3(unit_var: None, unit_var_1: None) -> None:
    method6()


def method24(__unit: None=None) -> str:
    return ""


def method25(v0: int64, v1: str, v2: int64) -> UH0:
    if v2 < v0:
        return UH0(1, v1[int(to_int(v2))], method25(v0, v1, op_addition(v2, int64(1))))

    else: 
        return UH0(0)



def method26(v0_mut: UH0, v1_mut: Any, v2_mut: int, v3_mut: int) -> tuple[Any, int, int]:
    while True:
        (v0, v1, v2, v3) = (v0_mut, v1_mut, v2_mut, v3_mut)
        if v0.tag == 0:
            return (v1, v2, v3)

        else: 
            v4: str = v0.fields[0]
            v6: bool = "\n" == v4
            pattern_input: tuple[int, int] = ((v2 + 1, 1)) if v6 else ((v2, v3 + 1))
            v0_mut = v0.fields[1]
            def _arrow229(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3) -> Any:
                v13: Any = StringBuilder__Clear(v1)
                return v1

            def _arrow230(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3) -> Any:
                v24: Any = StringBuilder__Append_Z721C83C5(v1, v4)
                return v1

            v1_mut = _arrow229() if v6 else _arrow230()
            v2_mut = pattern_input[0]
            v3_mut = pattern_input[1]
            continue

        break


def closure15(v0: int, v1: int, v2: str) -> str:
    if v1 >= v0:
        return v2

    else: 
        return method27(v0, v1 + 1)(v2 + " ")



def method27(v0: int, v1: int) -> Callable[[str], str]:
    def _arrow231(v: str, v0: Any=v0, v1: Any=v1) -> str:
        return closure15(v0, v1, v)

    return _arrow231


def closure14(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    if "" == v0:
        return US8(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v1, v2, v3)])))

    else: 
        v10: str = v0[0]
        if v10 == "\"":
            v43: int = (len(v0) - 1) or 0
            v45: str = v0[1:v43 + 1]
            v51: str = v10
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v51), False, 2), v51, int64(0)), v1, v2, v3)
            return US8(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v66: int = (v0.find("\n") - 1) or 0
            v102: int = (((len(v0) + 1) if (-2 == v66) else (v66 + 1)) - 1) or 0
            return US8(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v2)) + " / col: ") + str(v3)) + "\n") + str(v1)) + "") + v0[0:v102 + 1]) + "", "\n", method27(v3 - 1, 0)("") + "^", *"\n"))




def closure16(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    if "" == v0:
        return US8(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\'", (v1, v2, v3)])))

    else: 
        v10: str = v0[0]
        if v10 == "\'":
            v43: int = (len(v0) - 1) or 0
            v45: str = v0[1:v43 + 1]
            v51: str = v10
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v51), False, 2), v51, int64(0)), v1, v2, v3)
            return US8(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v66: int = (v0.find("\n") - 1) or 0
            v102: int = (((len(v0) + 1) if (-2 == v66) else (v66 + 1)) - 1) or 0
            return US8(1, concat(((((((((("parsing.p_char / expected: \'" + str("\'")) + "\' / line: ") + str(v2)) + " / col: ") + str(v3)) + "\n") + str(v1)) + "") + v0[0:v102 + 1]) + "", "\n", method27(v3 - 1, 0)("") + "^", *"\n"))




def method28(v0_mut: str, v1_mut: Any, v2_mut: UH1) -> US8:
    while True:
        (v0, v1, v2) = (v0_mut, v1_mut, v2_mut)
        if v2.tag == 0:
            return US8(1, "parsing.choice / no parsers succeeded")

        else: 
            v7: US8 = v2.fields[0]((v0, v1, 1, 1))
            if v7.tag == 0:
                return v7

            else: 
                v0_mut = v0
                v1_mut = v1
                v2_mut = v2.fields[1]
                continue


        break


def method29(v0_mut: str, v1_mut: int64) -> bool:
    while True:
        (v0, v1) = (v0_mut, v1_mut)
        if v1 >= int64(2):
            return False

        else: 
            v11: US10
            if v1 == int64(0):
                v11 = US10(0, "\"")

            else: 
                v5: int64 = op_subtraction(v1, int64(1))
                if v5 == int64(0):
                    v11 = US10(0, "\'")

                else: 
                    v8: int64 = op_subtraction(v5, int64(1))
                    v11 = US10(1)


            def _arrow232(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v11.fields[0] if (v11.tag == 0) else _arrow232()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def method30(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v98: US8
        if "" == v1:
            v98 = US8(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'"])), (v2, v3, v4)])))

        else: 
            v25: str = v1[0]
            if method29(v25, int64(0)) == False:
                v60: int = (len(v1) - 1) or 0
                v62: str = v1[1:v60 + 1]
                v68: str = v25
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v68), False, 2), v68, int64(0)), v2, v3, v4)
                v98 = US8(0, v25, v62, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v98 = US8(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v25, to_array(of_array(["\"", "\'"])), (v2, v3, v4)])))


        v110: US8
        if v98.tag == 0:
            v99: str = v98.fields[0]
            v110 = US8(0, "/" if ("\\" == v99) else v99, v98.fields[1], v98.fields[2], v98.fields[3], v98.fields[4])

        else: 
            v110 = US8(1, v98.fields[0])

        if v110.tag == 0:
            v0_mut = v0 + v110.fields[0]
            v1_mut = v110.fields[1]
            v2_mut = v110.fields[2]
            v3_mut = v110.fields[3]
            v4_mut = v110.fields[4]
            continue

        else: 
            return (v0, v1, v2, v3, v4)

        break


def method31(v0_mut: str, v1_mut: Any, v2_mut: int, v3_mut: int, v4_mut: UH1) -> US8:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        if v4.tag == 0:
            return US8(1, "parsing.choice / no parsers succeeded")

        else: 
            v9: US8 = v4.fields[0]((v0, v1, v2, v3))
            if v9.tag == 0:
                return v9

            else: 
                v0_mut = v0
                v1_mut = v1
                v2_mut = v2
                v3_mut = v3
                v4_mut = v4.fields[1]
                continue


        break


def method32(v0_mut: str, v1_mut: int64) -> bool:
    while True:
        (v0, v1) = (v0_mut, v1_mut)
        if v1 >= int64(3):
            return False

        else: 
            v15_1: US10
            if v1 == int64(0):
                v15_1 = US10(0, "\"")

            else: 
                v5: int64 = op_subtraction(v1, int64(1))
                if v5 == int64(0):
                    v15_1 = US10(0, "\'")

                else: 
                    v8: int64 = op_subtraction(v5, int64(1))
                    if v8 == int64(0):
                        v15_1 = US10(0, " ")

                    else: 
                        v11: int64 = op_subtraction(v8, int64(1))
                        v15_1 = US10(1)



            def _arrow233(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v15_1.fields[0] if (v15_1.tag == 0) else _arrow233()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def method33(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v106: US8
        if "" == v1:
            v106 = US8(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'", " "])), (v2, v3, v4)])))

        else: 
            v29: str = v1[0]
            if method32(v29, int64(0)) == False:
                v64: int = (len(v1) - 1) or 0
                v66: str = v1[1:v64 + 1]
                v72: str = v29
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v72), False, 2), v72, int64(0)), v2, v3, v4)
                v106 = US8(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v106 = US8(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\"", "\'", " "])), (v2, v3, v4)])))


        v118: US8
        if v106.tag == 0:
            v107: str = v106.fields[0]
            v118 = US8(0, "/" if ("\\" == v107) else v107, v106.fields[1], v106.fields[2], v106.fields[3], v106.fields[4])

        else: 
            v118 = US8(1, v106.fields[0])

        if v118.tag == 0:
            v0_mut = v0 + v118.fields[0]
            v1_mut = v118.fields[1]
            v2_mut = v118.fields[2]
            v3_mut = v118.fields[3]
            v4_mut = v118.fields[4]
            continue

        else: 
            return (v0, v1, v2, v3, v4)

        break


def method34(v0_mut: str, v1_mut: int) -> int:
    while True:
        (v0, v1) = (v0_mut, v1_mut)
        if v1 >= len(v0):
            return v1

        elif " " == v0[v1]:
            v0_mut = v0
            v1_mut = v1 + 1
            continue

        else: 
            return v1

        break


def method35(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v66: US8
        if "" == v1:
            v66 = US8(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v2, v3, v4)])))

        else: 
            v16_1: str = v1[0]
            v48: int = (len(v1) - 1) or 0
            v50: str = v1[1:v48 + 1]
            v56: str = v16_1
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v56), False, 2), v56, int64(0)), v2, v3, v4)
            v66 = US8(0, v16_1, v50, pattern_input[0], pattern_input[1], pattern_input[2])

        if v66.tag == 0:
            v0_mut = v0 + v66.fields[0]
            v1_mut = v66.fields[1]
            v2_mut = v66.fields[2]
            v3_mut = v66.fields[3]
            v4_mut = v66.fields[4]
            continue

        else: 
            return (v0, v1, v2, v3, v4)

        break


def method23(v0: str) -> US7:
    _v0: (str | None) | None = None
    _v0 = some(v0)
    def _arrow234(__unit: None=None, v0: Any=v0) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v10: str = default_arg(_arrow234() if (_v0 is None) else value_12(_v0), "")
    v16_1: Any = StringBuilder__ctor_Z721C83C5(method24())
    def v19(_arg10: tuple[str, Any, int, int], v0: Any=v0) -> US8:
        return closure14(None, _arg10)

    def v20(_arg10_1: tuple[str, Any, int, int], v0: Any=v0) -> US8:
        return closure16(None, _arg10_1)

    v24: US8 = method28(v10, v16_1, UH1(1, v19, UH1(1, v20, UH1(0))))
    v197: US9
    if v24.tag == 0:
        v29: int = v24.fields[4] or 0
        v28: int = v24.fields[3] or 0
        v27: Any = v24.fields[2]
        v26: str = v24.fields[1]
        v123: US8
        if "" == v26:
            v123 = US8(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'"])), (v27, v28, v29)])))

        else: 
            v50: str = v26[0]
            if method29(v50, int64(0)) == False:
                v85: int = (len(v26) - 1) or 0
                v87: str = v26[1:v85 + 1]
                v93: str = v50
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v93), False, 2), v93, int64(0)), v27, v28, v29)
                v123 = US8(0, v50, v87, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v123 = US8(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v50, to_array(of_array(["\"", "\'"])), (v27, v28, v29)])))


        v135: US8
        if v123.tag == 0:
            v124: str = v123.fields[0]
            v135 = US8(0, "/" if ("\\" == v124) else v124, v123.fields[1], v123.fields[2], v123.fields[3], v123.fields[4])

        else: 
            v135 = US8(1, v123.fields[0])

        v155: US9
        if v135.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method30(v135.fields[0], v135.fields[1], v135.fields[2], v135.fields[3], v135.fields[4])
            v155 = US9(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v155 = US9(1, v135.fields[0])

        v165: US9 = US9(0, v155.fields[0], v155.fields[1], v155.fields[2], v155.fields[3], v155.fields[4]) if (v155.tag == 0) else US9(0, "", v26, v27, v28, v29)
        if v165.tag == 0:
            v170: int = v165.fields[4] or 0
            v169: int = v165.fields[3] or 0
            v168: Any = v165.fields[2]
            v167: str = v165.fields[1]
            v174: US8 = method31(v167, v168, v169, v170, UH1(1, v19, UH1(1, v20, UH1(0))))
            v197 = US9(0, v165.fields[0], v174.fields[1], v174.fields[2], v174.fields[3], v174.fields[4]) if (v174.tag == 0) else US9(1, to_text(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v174.fields[0], (v10, v16_1, 1, 1), (v26, v27, v28, v29), (v167, v168, v169, v170)])))

        else: 
            v197 = US9(1, "parsing.between / expected content")


    else: 
        v197 = US9(1, v24.fields[0])

    v416: US9
    if v197.tag == 0:
        v416 = v197

    else: 
        v307: US8
        if "" == v10:
            v307 = US8(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'", " "])), (v16_1, 1, 1)])))

        else: 
            v228: str = v10[0]
            if method32(v228, int64(0)) == False:
                v263: int = (len(v10) - 1) or 0
                v265: str = v10[1:v263 + 1]
                v271: str = v228
                pattern_input_2: tuple[Any, int, int] = method26(method25(from_integer(len(v271), False, 2), v271, int64(0)), v16_1, 1, 1)
                v307 = US8(0, v228, v265, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

            else: 
                v307 = US8(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v228, to_array(of_array(["\"", "\'", " "])), (v16_1, 1, 1)])))


        v319: US8
        if v307.tag == 0:
            v308: str = v307.fields[0]
            v319 = US8(0, "/" if ("\\" == v308) else v308, v307.fields[1], v307.fields[2], v307.fields[3], v307.fields[4])

        else: 
            v319 = US8(1, v307.fields[0])

        v339: US9
        if v319.tag == 0:
            pattern_input_3: tuple[str, str, Any, int, int] = method33(v319.fields[0], v319.fields[1], v319.fields[2], v319.fields[3], v319.fields[4])
            v339 = US9(0, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2], pattern_input_3[3], pattern_input_3[4])

        else: 
            v339 = US9(1, v319.fields[0])

        if v339.tag == 0:
            v416 = v339

        else: 
            v354: US11 = US11(0, v10, v16_1, 1, 1) if (len(v10) == 0) else US11(1, to_text(interpolate("parsing.eof / expected end of input / input: %A%P()", [v10])))
            v363: US9 = US9(0, "", v354.fields[0], v354.fields[1], v354.fields[2], v354.fields[3]) if (v354.tag == 0) else US9(1, v354.fields[0])
            if v363.tag == 0:
                v365: str = v363.fields[1]
                v370: int = method34(v365, 0) or 0
                v402: int = (len(v365) - 1) or 0
                v416 = US9(0, v363.fields[0], v365[v370:v402 + 1], v363.fields[2], v363.fields[3], v363.fields[4])

            else: 
                v416 = US9(1, v363.fields[0])



    v671: US12
    if v416.tag == 0:
        v421: int = v416.fields[4] or 0
        v420: int = v416.fields[3] or 0
        v419: Any = v416.fields[2]
        v418: str = v416.fields[1]
        v542: US8
        if "" == v418:
            v542 = US8(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", [" ", (v419, v420, v421)])))

        else: 
            v428: str = v418[0]
            if v428 == " ":
                v461: int = (len(v418) - 1) or 0
                v463: str = v418[1:v461 + 1]
                v469: str = v428
                pattern_input_4: tuple[Any, int, int] = method26(method25(from_integer(len(v469), False, 2), v469, int64(0)), v419, v420, v421)
                v542 = US8(0, v428, v463, pattern_input_4[0], pattern_input_4[1], pattern_input_4[2])

            else: 
                v484: int = (v418.find("\n") - 1) or 0
                v520: int = (((len(v418) + 1) if (-2 == v484) else (v484 + 1)) - 1) or 0
                v542 = US8(1, concat(((((((((("parsing.p_char / expected: \'" + str(" ")) + "\' / line: ") + str(v420)) + " / col: ") + str(v421)) + "\n") + str(v419)) + "") + v418[0:v520 + 1]) + "", "\n", method27(v421 - 1, 0)("") + "^", *"\n"))


        v554: US13 = US13(0, US10(0, v542.fields[0]), v542.fields[1], v542.fields[2], v542.fields[3], v542.fields[4]) if (v542.tag == 0) else US13(0, US10(1), v418, v419, v420, v421)
        v645: US9
        if v554.tag == 0:
            v559: int = v554.fields[4] or 0
            v558: int = v554.fields[3] or 0
            v557: Any = v554.fields[2]
            v556: str = v554.fields[1]
            v621: US8
            if "" == v556:
                v621 = US8(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v557, v558, v559)])))

            else: 
                v571: str = v556[0]
                v603: int = (len(v556) - 1) or 0
                v605: str = v556[1:v603 + 1]
                v611: str = v571
                pattern_input_5: tuple[Any, int, int] = method26(method25(from_integer(len(v611), False, 2), v611, int64(0)), v557, v558, v559)
                v621 = US8(0, v571, v605, pattern_input_5[0], pattern_input_5[1], pattern_input_5[2])

            if v621.tag == 0:
                pattern_input_6: tuple[str, str, Any, int, int] = method35(v621.fields[0], v621.fields[1], v621.fields[2], v621.fields[3], v621.fields[4])
                v645 = US9(0, pattern_input_6[0], pattern_input_6[1], pattern_input_6[2], pattern_input_6[3], pattern_input_6[4])

            else: 
                v645 = US9(1, v621.fields[0])


        else: 
            v645 = US9(1, v554.fields[0])

        v657: US14 = US14(0, US5(0, v645.fields[0]), v645.fields[1], v645.fields[2], v645.fields[3], v645.fields[4]) if (v645.tag == 0) else US14(0, US5(1), v418, v419, v420, v421)
        v671 = US12(0, v416.fields[0], v657.fields[0], v657.fields[1], v657.fields[2], v657.fields[3], v657.fields[4]) if (v657.tag == 0) else US12(1, v657.fields[0])

    else: 
        v671 = US12(1, v416.fields[0])

    if v671.tag == 0:
        return US7(0, v671.fields[0], v671.fields[1])

    else: 
        return US7(1, v671.fields[0])



def method36(__unit: None=None) -> str:
    v4: str = "Debug".lower()
    return ("\u001b[94m" + method12(v4[0])) + method14()


def method38(v0: str, v1: US5, v2: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None=None) -> str:
    v10: Mut3 = Mut3(method13())
    v24: None
    closure7(v10, "{ ", None)
    v24 = None
    v43: None
    closure7(v10, "file_name", None)
    v43 = None
    v62: None
    closure7(v10, " = ", None)
    v62 = None
    v79: None
    closure7(v10, v0, None)
    v79 = None
    v98: None
    closure7(v10, "; ", None)
    v98 = None
    v117: None
    closure7(v10, "arguments", None)
    v117 = None
    v134: None
    closure7(v10, " = ", None)
    v134 = None
    v155: None
    closure7(v10, to_text(interpolate("%A%P()", [v1])), None)
    v155 = None
    v172: None
    closure7(v10, "; ", None)
    v172 = None
    v191: None
    closure7(v10, "options", None)
    v191 = None
    v208: None
    closure7(v10, " = ", None)
    v208 = None
    v225: None
    closure7(v10, "{ ", None)
    v225 = None
    v244: None
    closure7(v10, "command", None)
    v244 = None
    v261: None
    closure7(v10, " = ", None)
    v261 = None
    v278: None
    closure7(v10, v2, None)
    v278 = None
    v295: None
    closure7(v10, "; ", None)
    v295 = None
    v314: None
    closure7(v10, "cancellation_token", None)
    v314 = None
    v331: None
    closure7(v10, " = ", None)
    v331 = None
    v390: None
    closure7(v10, to_text(interpolate("%A%P()", [v3])), None)
    v390 = None
    v407: None
    closure7(v10, "; ", None)
    v407 = None
    v426: None
    closure7(v10, "environment_variables", None)
    v426 = None
    v443: None
    closure7(v10, " = ", None)
    v443 = None
    v464: None
    closure7(v10, to_text(interpolate("%A%P()", [v4])), None)
    v464 = None
    v481: None
    closure7(v10, "; ", None)
    v481 = None
    v500: None
    closure7(v10, "on_line", None)
    v500 = None
    v517: None
    closure7(v10, " = ", None)
    v517 = None
    v576: None
    closure7(v10, to_text(interpolate("%A%P()", [v5])), None)
    v576 = None
    v593: None
    closure7(v10, "; ", None)
    v593 = None
    v612: None
    closure7(v10, "stdin", None)
    v612 = None
    v629: None
    closure7(v10, " = ", None)
    v629 = None
    v688: None
    closure7(v10, to_text(interpolate("%A%P()", [v6])), None)
    v688 = None
    v705: None
    closure7(v10, "; ", None)
    v705 = None
    v724: None
    closure7(v10, "trace", None)
    v724 = None
    v741: None
    closure7(v10, " = ", None)
    v741 = None
    v761: None
    closure7(v10, "true" if v7 else "false", None)
    v761 = None
    v778: None
    closure7(v10, "; ", None)
    v778 = None
    v797: None
    closure7(v10, "working_directory", None)
    v797 = None
    v814: None
    closure7(v10, " = ", None)
    v814 = None
    v873: None
    closure7(v10, to_text(interpolate("%A%P()", [v8])), None)
    v873 = None
    v892: None
    closure7(v10, " }", None)
    v892 = None
    v909: None
    closure7(v10, " }", None)
    v909 = None
    return v10.l0


def method37(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: US5, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14_1: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15_1: bool, v16_1: str | None=None) -> str:
    v17: str = method38(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1)
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v17)


def closure17(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: US5, v8: str, unit_var: None) -> None:
    def v24(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v25: None
    v24(None)
    v25 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v66: US0 = pattern_input[4].l0
    v306: US6
    class ObjectExpr235:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v66, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr235())))) == False:
        v306 = US6(1)

    else: 
        v89: None
        v24(None)
        v89 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v117: int64 | None = pattern_input_1[5]
        v116: Mut4 = pattern_input_1[4]
        v115: Mut3 = pattern_input_1[3]
        v114: Mut2 = pattern_input_1[2]
        v113: Mut1 = pattern_input_1[1]
        v112: Mut0 = pattern_input_1[0]
        v132: str = method37(v112, v113, v114, v115, v116, v117, method7(v112, v113, v114, v115, v116, v117), method36(), v8, v7, v0, v1, v2, v3, v4, v5, v6)
        v148: None
        v24(None)
        v148 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v172: Mut1 = pattern_input_2[1]
        v171: Mut0 = pattern_input_2[0]
        v193: None
        closure8(v171, None)
        v193 = None
        closure9(None, v132)
        v172.l0(v132)
        v306 = US6(0, v171, v172, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method39(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Array[tuple[str, str]]:
    return v2


def method40(v0: int, v1: Mut5) -> bool:
    return v1.l0 < v0


def method43(v0: bool) -> str:
    return None


def closure19(unit_var: None, v0: Callable[[tuple[int, str, bool]], Async[None]]) -> US15:
    return US15(0, v0)


def method44(__unit: None=None) -> Callable[[Callable[[tuple[int, str, bool]], Async[None]]], US15]:
    def _arrow236(v: Callable[[tuple[int, str, bool]], Async[None]]) -> US15:
        return closure19(None, v)

    return _arrow236


def method45(v0: bool) -> int:
    return None


def method46(__unit: None=None) -> str:
    v4: str = "Verbose".lower()
    return ("\u001b[90m" + method12(v4[0])) + method14()


def method47(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v9: str = method16()
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + v8) + " / ") + v9)


def closure20(v0: str, unit_var: None) -> None:
    def v16_1(__unit: None=None, v0: Any=v0, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v17: None
    v16_1(None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v58: US0 = pattern_input[4].l0
    v301: US6
    class ObjectExpr237:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (0 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr237())))) == False:
        v301 = US6(1)

    else: 
        v81: None
        v16_1(None)
        v81 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v109: int64 | None = pattern_input_1[5]
        v108: Mut4 = pattern_input_1[4]
        v107: Mut3 = pattern_input_1[3]
        v106: Mut2 = pattern_input_1[2]
        v105: Mut1 = pattern_input_1[1]
        v104: Mut0 = pattern_input_1[0]
        v127: str = "" if (v0 == "") else method47(v104, v105, v106, v107, v108, v109, method7(v104, v105, v106, v107, v108, v109), method46(), v0)
        v143: None
        v16_1(None)
        v143 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v167: Mut1 = pattern_input_2[1]
        v166: Mut0 = pattern_input_2[0]
        v188: None
        closure8(v166, None)
        v188 = None
        closure9(None, v127)
        v167.l0(v127)
        v301 = US6(0, v166, v167, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method42(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> Async[None]:
    def _arrow247(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, v9: Any=v9, v10: Any=v10) -> Async[None]:
        v27513: str = method43(v10)
        v27519: bool = (v27513 is None) != True
        def _arrow245(__unit: None=None) -> Async[None]:
            v27544: US15 = default_arg(map(method44(), v3), US15(1))
            def _arrow239(__unit: None=None) -> Async[None]:
                v27550: Async[None] = v27544.fields[0]((method45(v7), v27513, v9))
                def _arrow238(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v27550, _arrow238)

            def _expr240():
                return singleton.Zero()

            def _arrow244(__unit: None=None) -> Async[None]:
                v27553: str = concat("! ", *v27513) if v9 else concat("> ", *v27513)
                def _arrow241(__unit: None=None) -> Async[None]:
                    v27870: None
                    closure20(v27553, None)
                    v27870 = None
                    return singleton.Zero()

                def _arrow242(__unit: None=None) -> Async[None]:
                    v28191: None
                    closure10(v27553, None)
                    v28191 = None
                    return singleton.Zero()

                def _arrow243(__unit: None=None) -> Async[None]:
                    v28199: str = concat("\u001b[7;4m" if v9 else "", v27513, *"\u001b[0m" if v9 else "")
                    return singleton.Zero()

                return singleton.Combine(_arrow241() if v5 else _arrow242(), singleton.Delay(_arrow243))

            return singleton.Combine(_arrow239() if (v27544.tag == 0) else _expr240(), singleton.Delay(_arrow244))

        def _arrow246(__unit: None=None) -> Async[None]:
            return singleton.Zero()

        return singleton.Combine(_arrow245() if v27519 else singleton.Zero(), singleton.Delay(_arrow246))

    return singleton.Delay(_arrow247)


def method41(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> Async[None]:
    return method42(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)


def closure18(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> None:
    start_immediate(method41(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10))


def closure21(unit_var: None, v0: CancellationToken) -> US16:
    return US16(0, v0)


def method48(__unit: None=None) -> Callable[[CancellationToken], US16]:
    def _arrow249(v: CancellationToken) -> US16:
        return closure21(None, v)

    return _arrow249


def method49(v0: CancellationToken) -> Async[CancellationToken]:
    def _arrow250(__unit: None=None, v0: Any=v0) -> Async[CancellationToken]:
        return singleton.Return(None)

    return singleton.Delay(_arrow250)


def method50(v0: bool) -> bool:
    return None


def method51(v0: bool) -> None:
    pass


def closure22(v0: bool, unit_var: None) -> None:
    if method50(v0) == False:
        method51(v0)



def method54(v0: Any) -> str:
    v2: Mut3 = Mut3(method13())
    v16_1: None
    closure7(v2, "{ ", None)
    v16_1 = None
    v35_1: None
    closure7(v2, "ex", None)
    v35_1 = None
    v54: None
    closure7(v2, " = ", None)
    v54 = None
    v113: None
    closure7(v2, to_text(interpolate("%A%P()", [v0])), None)
    v113 = None
    v132: None
    closure7(v2, " }", None)
    v132 = None
    return v2.l0


def method53(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: Any) -> str:
    v9: str = method54(v8)
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.execute_with_options_async / WaitForExitAsync") + " / ") + v9)


def closure23(v0: Any, unit_var: None) -> None:
    def v16_1(__unit: None=None, v0: Any=v0, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v17: None
    v16_1(None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v58: US0 = pattern_input[4].l0
    v298: US6
    class ObjectExpr251:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr251())))) == False:
        v298 = US6(1)

    else: 
        v81: None
        v16_1(None)
        v81 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v109: int64 | None = pattern_input_1[5]
        v108: Mut4 = pattern_input_1[4]
        v107: Mut3 = pattern_input_1[3]
        v106: Mut2 = pattern_input_1[2]
        v105: Mut1 = pattern_input_1[1]
        v104: Mut0 = pattern_input_1[0]
        v124: str = method53(v104, v105, v106, v107, v108, v109, method7(v104, v105, v106, v107, v108, v109), method11(), v0)
        v140: None
        v16_1(None)
        v140 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v164: Mut1 = pattern_input_2[1]
        v163: Mut0 = pattern_input_2[0]
        v185: None
        closure8(v163, None)
        v185 = None
        closure9(None, v124)
        v164.l0(v124)
        v298 = US6(0, v163, v164, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method52(v0: bool, v1: Any, v2: CancellationToken) -> Async[int]:
    def _arrow255(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[int]:
        def _arrow253(__unit: None=None) -> Async[int]:
            v94280: Async[None] = await_task(None)
            def _arrow252(__unit: None=None) -> Async[int]:
                return singleton.Return(None)

            return singleton.Bind(v94280, _arrow252)

        def _arrow254(_arg_1: Exception) -> Async[int]:
            v95113: Exception = _arg_1
            v95136: str = to_text(interpolate("%A%P()", [v95113]))
            v95472: None
            closure23(v95113, None)
            v95472 = None
            return singleton.Return(-2147483648)

        return singleton.TryWith(singleton.Delay(_arrow253), _arrow254)

    return singleton.Delay(_arrow255)


def method55(__unit: None=None) -> str:
    return "\n"


def method57(v0: int, v1: int, v2: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None=None) -> str:
    v10: Mut3 = Mut3(method13())
    v24: None
    closure7(v10, "{ ", None)
    v24 = None
    v43: None
    closure7(v10, "exit_code", None)
    v43 = None
    v62: None
    closure7(v10, " = ", None)
    v62 = None
    v82: None
    closure7(v10, ("" + str(v0)) + "", None)
    v82 = None
    v101: None
    closure7(v10, "; ", None)
    v101 = None
    v120: None
    closure7(v10, "output_length", None)
    v120 = None
    v137: None
    closure7(v10, " = ", None)
    v137 = None
    v157: None
    closure7(v10, ("" + str(v1)) + "", None)
    v157 = None
    v174: None
    closure7(v10, "; ", None)
    v174 = None
    v193: None
    closure7(v10, "options", None)
    v193 = None
    v210: None
    closure7(v10, " = ", None)
    v210 = None
    v227: None
    closure7(v10, "{ ", None)
    v227 = None
    v246: None
    closure7(v10, "command", None)
    v246 = None
    v263: None
    closure7(v10, " = ", None)
    v263 = None
    v280: None
    closure7(v10, v2, None)
    v280 = None
    v297: None
    closure7(v10, "; ", None)
    v297 = None
    v316: None
    closure7(v10, "cancellation_token", None)
    v316 = None
    v333: None
    closure7(v10, " = ", None)
    v333 = None
    v392: None
    closure7(v10, to_text(interpolate("%A%P()", [v3])), None)
    v392 = None
    v409: None
    closure7(v10, "; ", None)
    v409 = None
    v428: None
    closure7(v10, "environment_variables", None)
    v428 = None
    v445: None
    closure7(v10, " = ", None)
    v445 = None
    v466: None
    closure7(v10, to_text(interpolate("%A%P()", [v4])), None)
    v466 = None
    v483: None
    closure7(v10, "; ", None)
    v483 = None
    v502: None
    closure7(v10, "on_line", None)
    v502 = None
    v519: None
    closure7(v10, " = ", None)
    v519 = None
    v578: None
    closure7(v10, to_text(interpolate("%A%P()", [v5])), None)
    v578 = None
    v595: None
    closure7(v10, "; ", None)
    v595 = None
    v614: None
    closure7(v10, "stdin", None)
    v614 = None
    v631: None
    closure7(v10, " = ", None)
    v631 = None
    v690: None
    closure7(v10, to_text(interpolate("%A%P()", [v6])), None)
    v690 = None
    v707: None
    closure7(v10, "; ", None)
    v707 = None
    v726: None
    closure7(v10, "trace", None)
    v726 = None
    v743: None
    closure7(v10, " = ", None)
    v743 = None
    v763: None
    closure7(v10, "true" if v7 else "false", None)
    v763 = None
    v780: None
    closure7(v10, "; ", None)
    v780 = None
    v799: None
    closure7(v10, "working_directory", None)
    v799 = None
    v816: None
    closure7(v10, " = ", None)
    v816 = None
    v875: None
    closure7(v10, to_text(interpolate("%A%P()", [v8])), None)
    v875 = None
    v894: None
    closure7(v10, " }", None)
    v894 = None
    v911: None
    closure7(v10, " }", None)
    v911 = None
    return v10.l0


def method56(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: int, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14_1: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15_1: bool, v16_1: str | None=None) -> str:
    v17: str = method57(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1)
    return method17((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v17)


def closure24(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: int, v8: str, unit_var: None) -> None:
    def v24(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v25: None
    v24(None)
    v25 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v66: US0 = pattern_input[4].l0
    v307: US6
    class ObjectExpr256:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v66, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr256())))) == False:
        v307 = US6(1)

    else: 
        v89: None
        v24(None)
        v89 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v117: int64 | None = pattern_input_1[5]
        v116: Mut4 = pattern_input_1[4]
        v115: Mut3 = pattern_input_1[3]
        v114: Mut2 = pattern_input_1[2]
        v113: Mut1 = pattern_input_1[1]
        v112: Mut0 = pattern_input_1[0]
        v133: str = method56(v112, v113, v114, v115, v116, v117, method7(v112, v113, v114, v115, v116, v117), method36(), v7, len(v8), v0, v1, v2, v3, v4, v5, v6)
        v149: None
        v24(None)
        v149 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v173: Mut1 = pattern_input_2[1]
        v172: Mut0 = pattern_input_2[0]
        v194: None
        closure8(v172, None)
        v194 = None
        closure9(None, v133)
        v173.l0(v133)
        v307 = US6(0, v172, v173, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method22(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Async[tuple[int, str]]:
    def _arrow257(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6) -> Async[tuple[int, str]]:
        pattern_input: tuple[int, str] = None
        return singleton.Return((pattern_input[0], pattern_input[1]))

    return singleton.Delay(_arrow257)


def method21(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Async[tuple[int, str]]:
    return method22(v0, v1, v2, v3, v4, v5, v6)


def method20(v0: str) -> Async[tuple[int, str]]:
    return method21(v0, None, [], None, None, True, None)


def closure13(unit_var: None, v0: str) -> Async[tuple[int, str]]:
    return method20(v0)


def closure25(unit_var: None, _arg: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return method21(_arg[0], _arg[1], _arg[2], _arg[3], _arg[4], _arg[5], _arg[6])


def closure26(unit_var: None, v0: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    v20: Heap0 = v0(Heap0("", None, [], None, None, True, None))
    return (v20.l0, v20.l1, v20.l2, v20.l3, v20.l4, v20.l5, v20.l6)


def method60(v0_mut: str, v1_mut: int64) -> bool:
    while True:
        (v0, v1) = (v0_mut, v1_mut)
        if v1 >= int64(4):
            return False

        else: 
            v19: US10
            if v1 == int64(0):
                v19 = US10(0, "\\")

            else: 
                v5: int64 = op_subtraction(v1, int64(1))
                if v5 == int64(0):
                    v19 = US10(0, "`")

                else: 
                    v8: int64 = op_subtraction(v5, int64(1))
                    if v8 == int64(0):
                        v19 = US10(0, "\"")

                    else: 
                        v11: int64 = op_subtraction(v8, int64(1))
                        if v11 == int64(0):
                            v19 = US10(0, " ")

                        else: 
                            v14_1: int64 = op_subtraction(v11, int64(1))
                            v19 = US10(1)




            def _arrow258(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v19.fields[0] if (v19.tag == 0) else _arrow258()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def method61(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v114: US8
        if "" == v1:
            v114 = US8(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\"", " "])), (v2, v3, v4)])))

        else: 
            v33_1: str = v1[0]
            if method60(v33_1, int64(0)) == False:
                v68: int = (len(v1) - 1) or 0
                v70: str = v1[1:v68 + 1]
                v76: str = v33_1
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v76), False, 2), v76, int64(0)), v2, v3, v4)
                v114 = US8(0, v33_1, v70, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v114 = US8(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33_1, to_array(of_array(["\\", "`", "\"", " "])), (v2, v3, v4)])))


        if v114.tag == 0:
            v0_mut = v0 + v114.fields[0]
            v1_mut = v114.fields[1]
            v2_mut = v114.fields[2]
            v3_mut = v114.fields[3]
            v4_mut = v114.fields[4]
            continue

        else: 
            return (v0, v1, v2, v3, v4)

        break


def method63(v0_mut: str, v1_mut: int64) -> bool:
    while True:
        (v0, v1) = (v0_mut, v1_mut)
        if v1 >= int64(3):
            return False

        else: 
            v15_1: US10
            if v1 == int64(0):
                v15_1 = US10(0, "\\")

            else: 
                v5: int64 = op_subtraction(v1, int64(1))
                if v5 == int64(0):
                    v15_1 = US10(0, "`")

                else: 
                    v8: int64 = op_subtraction(v5, int64(1))
                    if v8 == int64(0):
                        v15_1 = US10(0, "\"")

                    else: 
                        v11: int64 = op_subtraction(v8, int64(1))
                        v15_1 = US10(1)



            def _arrow259(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v15_1.fields[0] if (v15_1.tag == 0) else _arrow259()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def closure28(unit_var: None, _arg: tuple[str, Any, int, int]) -> US9:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    v125: US8
    if "" == v0:
        v125 = US8(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\\", (v1, v2, v3)])))

    else: 
        v10: str = v0[0]
        if v10 == "\\":
            v43: int = (len(v0) - 1) or 0
            v45: str = v0[1:v43 + 1]
            v51: str = v10
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v51), False, 2), v51, int64(0)), v1, v2, v3)
            v125 = US8(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v66: int = (v0.find("\n") - 1) or 0
            v102: int = (((len(v0) + 1) if (-2 == v66) else (v66 + 1)) - 1) or 0
            v125 = US8(1, concat(((((((((("parsing.p_char / expected: \'" + str("\\")) + "\' / line: ") + str(v2)) + " / col: ") + str(v3)) + "\n") + str(v1)) + "") + v0[0:v102 + 1]) + "", "\n", method27(v3 - 1, 0)("") + "^", *"\n"))


    v196: US8
    if v125.tag == 0:
        v130: int = v125.fields[4] or 0
        v129: int = v125.fields[3] or 0
        v128: Any = v125.fields[2]
        v127: str = v125.fields[1]
        if "" == v127:
            v196 = US8(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v128, v129, v130)])))

        else: 
            v142: str = v127[0]
            v174: int = (len(v127) - 1) or 0
            v176: str = v127[1:v174 + 1]
            v182: str = v142
            pattern_input_1: tuple[Any, int, int] = method26(method25(from_integer(len(v182), False, 2), v182, int64(0)), v128, v129, v130)
            v196 = US8(0, v142, v176, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v196 = US8(1, v125.fields[0])

    if v196.tag == 0:
        return US9(0, "\\" + v196.fields[0], v196.fields[1], v196.fields[2], v196.fields[3], v196.fields[4])

    else: 
        return US9(1, v196.fields[0])



def closure29(unit_var: None, _arg: tuple[str, Any, int, int]) -> US9:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    v125: US8
    if "" == v0:
        v125 = US8(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["`", (v1, v2, v3)])))

    else: 
        v10: str = v0[0]
        if v10 == "`":
            v43: int = (len(v0) - 1) or 0
            v45: str = v0[1:v43 + 1]
            v51: str = v10
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v51), False, 2), v51, int64(0)), v1, v2, v3)
            v125 = US8(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v66: int = (v0.find("\n") - 1) or 0
            v102: int = (((len(v0) + 1) if (-2 == v66) else (v66 + 1)) - 1) or 0
            v125 = US8(1, concat(((((((((("parsing.p_char / expected: \'" + str("`")) + "\' / line: ") + str(v2)) + " / col: ") + str(v3)) + "\n") + str(v1)) + "") + v0[0:v102 + 1]) + "", "\n", method27(v3 - 1, 0)("") + "^", *"\n"))


    v196: US8
    if v125.tag == 0:
        v130: int = v125.fields[4] or 0
        v129: int = v125.fields[3] or 0
        v128: Any = v125.fields[2]
        v127: str = v125.fields[1]
        if "" == v127:
            v196 = US8(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v128, v129, v130)])))

        else: 
            v142: str = v127[0]
            v174: int = (len(v127) - 1) or 0
            v176: str = v127[1:v174 + 1]
            v182: str = v142
            pattern_input_1: tuple[Any, int, int] = method26(method25(from_integer(len(v182), False, 2), v182, int64(0)), v128, v129, v130)
            v196 = US8(0, v142, v176, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v196 = US8(1, v125.fields[0])

    if v196.tag == 0:
        return US9(0, "`" + v196.fields[0], v196.fields[1], v196.fields[2], v196.fields[3], v196.fields[4])

    else: 
        return US9(1, v196.fields[0])



def method64(v0_mut: str, v1_mut: Any, v2_mut: int, v3_mut: int, v4_mut: UH3) -> US9:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        if v4.tag == 0:
            return US9(1, "parsing.choice / no parsers succeeded")

        else: 
            v9: US9 = v4.fields[0]((v0, v1, v2, v3))
            if v9.tag == 0:
                return v9

            else: 
                v0_mut = v0
                v1_mut = v1
                v2_mut = v2
                v3_mut = v3
                v4_mut = v4.fields[1]
                continue


        break


def method65(v0_mut: UH2, v1_mut: UH2) -> UH2:
    while True:
        (v0, v1) = (v0_mut, v1_mut)
        if v0.tag == 0:
            return v1

        else: 
            v0_mut = v0.fields[1]
            v1_mut = UH2(1, v0.fields[0], v1)
            continue

        break


def method62(v0_mut: UH2, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v106: US8
        if "" == v1:
            v106 = US8(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\""])), (v2, v3, v4)])))

        else: 
            v29: str = v1[0]
            if method63(v29, int64(0)) == False:
                v64: int = (len(v1) - 1) or 0
                v66: str = v1[1:v64 + 1]
                v72: str = v29
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v72), False, 2), v72, int64(0)), v2, v3, v4)
                v106 = US8(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v106 = US8(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\\", "`", "\""])), (v2, v3, v4)])))


        v121: US9 = US9(0, v106.fields[0], v106.fields[1], v106.fields[2], v106.fields[3], v106.fields[4]) if (v106.tag == 0) else US9(1, v106.fields[0])
        def v128(_arg10: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
            return closure28(None, _arg10)

        def v129(_arg10_1: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
            return closure29(None, _arg10_1)

        v135: US9 = v121 if (v121.tag == 0) else method64(v1, v2, v3, v4, UH3(1, v128, UH3(1, v129, UH3(0))))
        if v135.tag == 0:
            v0_mut = UH2(1, v135.fields[0], v0)
            v1_mut = v135.fields[1]
            v2_mut = v135.fields[2]
            v3_mut = v135.fields[3]
            v4_mut = v135.fields[4]
            continue

        else: 
            return US18(0, method65(v0, UH2(0)), v1, v2, v3, v4)

        break


def method66(v0: UH2, v1: FSharpList[str]) -> FSharpList[str]:
    if v0.tag == 0:
        return v1

    else: 
        return cons(v0.fields[0], method66(v0.fields[1], v1))



def method67(v0_mut: UH2, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v106: US8
        if "" == v1:
            v106 = US8(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\""])), (v2, v3, v4)])))

        else: 
            v29: str = v1[0]
            if method63(v29, int64(0)) == False:
                v64: int = (len(v1) - 1) or 0
                v66: str = v1[1:v64 + 1]
                v72: str = v29
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v72), False, 2), v72, int64(0)), v2, v3, v4)
                v106 = US8(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v106 = US8(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\\", "`", "\""])), (v2, v3, v4)])))


        v121: US9 = US9(0, v106.fields[0], v106.fields[1], v106.fields[2], v106.fields[3], v106.fields[4]) if (v106.tag == 0) else US9(1, v106.fields[0])
        if v121.tag == 0:
            v0_mut = UH2(1, v121.fields[0], v0)
            v1_mut = v121.fields[1]
            v2_mut = v121.fields[2]
            v3_mut = v121.fields[3]
            v4_mut = v121.fields[4]
            continue

        else: 
            return US18(0, method65(v0, UH2(0)), v1, v2, v3, v4)

        break


def method59(v0_mut: UH2, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v5: bool = "" == v1
        v114: US8
        if v5:
            v114 = US8(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\"", " "])), (v2, v3, v4)])))

        else: 
            v33_1: str = v1[0]
            if method60(v33_1, int64(0)) == False:
                v68: int = (len(v1) - 1) or 0
                v70: str = v1[1:v68 + 1]
                v76: str = v33_1
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v76), False, 2), v76, int64(0)), v2, v3, v4)
                v114 = US8(0, v33_1, v70, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v114 = US8(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33_1, to_array(of_array(["\\", "`", "\"", " "])), (v2, v3, v4)])))


        v134: US9
        if v114.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method61(v114.fields[0], v114.fields[1], v114.fields[2], v114.fields[3], v114.fields[4])
            v134 = US9(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v134 = US9(1, v114.fields[0])

        v522: US9
        if v134.tag == 0:
            v522 = v134

        else: 
            v261: US8
            if v5:
                v261 = US8(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v2, v3, v4)])))

            else: 
                v146: str = v1[0]
                if v146 == "\"":
                    v179: int = (len(v1) - 1) or 0
                    v181: str = v1[1:v179 + 1]
                    v187: str = v146
                    pattern_input_2: tuple[Any, int, int] = method26(method25(from_integer(len(v187), False, 2), v187, int64(0)), v2, v3, v4)
                    v261 = US8(0, v146, v181, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

                else: 
                    v202: int = (v1.find("\n") - 1) or 0
                    v238: int = (((len(v1) + 1) if (-2 == v202) else (v202 + 1)) - 1) or 0
                    v261 = US8(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v3)) + " / col: ") + str(v4)) + "\n") + str(v2)) + "") + v1[0:v238 + 1]) + "", "\n", method27(v4 - 1, 0)("") + "^", *"\n"))


            v451: US9
            if v261.tag == 0:
                v266: int = v261.fields[4] or 0
                v265: int = v261.fields[3] or 0
                v264: Any = v261.fields[2]
                v263: str = v261.fields[1]
                v268: US18 = method62(UH2(0), v263, v264, v265, v266)
                v301: US9
                if v268.tag == 0:
                    v275: FSharpList[str] = method66(v268.fields[0], empty())
                    def _arrow260(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v275

                    v301 = US9(0, join("", delay(_arrow260)), v268.fields[1], v268.fields[2], v268.fields[3], v268.fields[4])

                else: 
                    v301 = US9(1, v268.fields[0])

                if v301.tag == 0:
                    v306: int = v301.fields[4] or 0
                    v305: int = v301.fields[3] or 0
                    v304: Any = v301.fields[2]
                    v303: str = v301.fields[1]
                    v428: US8
                    if "" == v303:
                        v428 = US8(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v304, v305, v306)])))

                    else: 
                        v313: str = v303[0]
                        if v313 == "\"":
                            v346: int = (len(v303) - 1) or 0
                            v348: str = v303[1:v346 + 1]
                            v354: str = v313
                            pattern_input_3: tuple[Any, int, int] = method26(method25(from_integer(len(v354), False, 2), v354, int64(0)), v304, v305, v306)
                            v428 = US8(0, v313, v348, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2])

                        else: 
                            v369: int = (v303.find("\n") - 1) or 0
                            v405: int = (((len(v303) + 1) if (-2 == v369) else (v369 + 1)) - 1) or 0
                            v428 = US8(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v305)) + " / col: ") + str(v306)) + "\n") + str(v304)) + "") + v303[0:v405 + 1]) + "", "\n", method27(v306 - 1, 0)("") + "^", *"\n"))


                    v451 = US9(0, v301.fields[0], v428.fields[1], v428.fields[2], v428.fields[3], v428.fields[4]) if (v428.tag == 0) else US9(1, to_text(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v428.fields[0], (v1, v2, v3, v4), (v263, v264, v265, v266), (v303, v304, v305, v306)])))

                else: 
                    v451 = US9(1, "parsing.between / expected content")


            else: 
                v451 = US9(1, v261.fields[0])

            if v451.tag == 0:
                v522 = v451

            else: 
                def v458(_arg10: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
                    return closure28(None, _arg10)

                def v459(_arg10_1: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
                    return closure29(None, _arg10_1)

                v463: US9 = method64(v1, v2, v3, v4, UH3(1, v458, UH3(1, v459, UH3(0))))
                v474: US9 = US9(0, "", v463.fields[1], v463.fields[2], v463.fields[3], v463.fields[4]) if (v463.tag == 0) else US9(1, v463.fields[0])
                v485: US18 = method67(UH2(0), v474.fields[1], v474.fields[2], v474.fields[3], v474.fields[4]) if (v474.tag == 0) else US18(1, v474.fields[0])
                if v485.tag == 0:
                    v492: FSharpList[str] = method66(v485.fields[0], empty())
                    def _arrow261(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v492

                    v522 = US9(0, join("", delay(_arrow261)), v485.fields[1], v485.fields[2], v485.fields[3], v485.fields[4])

                else: 
                    v522 = US9(1, v485.fields[0])



        if v522.tag == 0:
            v527: int = v522.fields[4] or 0
            v526: int = v522.fields[3] or 0
            v525: Any = v522.fields[2]
            v524: str = v522.fields[1]
            v523: str = v522.fields[0]
            v529: int = method34(v524, 0) or 0
            v571: US11
            if 0 == v529:
                v571 = US11(1, "parsing.spaces1 / expected at least one space")

            else: 
                v564: int = (len(v524) - 1) or 0
                v571 = US11(0, v524[v529:v564 + 1], v525, v526, v527)

            if v571.tag == 0:
                v0_mut = UH2(1, v523, v0)
                v1_mut = v571.fields[0]
                v2_mut = v571.fields[1]
                v3_mut = v571.fields[2]
                v4_mut = v571.fields[3]
                continue

            else: 
                return US18(0, method65(v0, UH2(1, v523, UH2(0))), v524, v525, v526, v527)


        else: 
            return US18(0, method65(v0, UH2(0)), v1, v2, v3, v4)

        break


def method58(v0: str) -> US17:
    _v0: (str | None) | None = None
    _v0 = some(v0)
    def _arrow262(__unit: None=None, v0: Any=v0) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v22: US18 = method59(UH2(0), default_arg(_arrow262() if (_v0 is None) else value_12(_v0), ""), StringBuilder__ctor_Z721C83C5(method24()), 1, 1)
    if v22.tag == 0:
        return US17(0, to_array(method66(v22.fields[0], empty())))

    else: 
        return US17(1, v22.fields[0])



def closure27(unit_var: None, v0: str) -> FSharpResult_2[Array[str], str]:
    v1: US17 = method58(v0)
    if v1.tag == 0:
        return FSharpResult_2(0, v1.fields[0])

    else: 
        return FSharpResult_2(1, v1.fields[0])



v14: None = None

def _arrow263(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow263

def _expr264():
    v15(None)
    return v14


v16: None = _expr264()

def _arrow265(__unit: None=None) -> None:
    closure3(None, None)


v31: Callable[[], None] = _arrow265

def current_process_kill(__unit: None=None) -> None:
    v31(None)


def _arrow266(v: str) -> Async[tuple[int, str]]:
    return closure13(None, v)


v32: Callable[[str], Async[tuple[int, str]]] = _arrow266

def execute_async(x: str) -> Async[tuple[int, str]]:
    return v32(x)


def _arrow267(_arg10: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return closure25(None, _arg10)


v33: Callable[[tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]], Async[tuple[int, str]]] = _arrow267

def execute_with_options_async(x: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return v33(x)


def _arrow268(v: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    return closure26(None, v)


v34: Callable[[Callable[[Heap0], Heap0]], tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]] = _arrow268

def execution_options(x: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    return v34(x)


def _arrow269(v: str) -> FSharpResult_2[Array[str], str]:
    return closure27(None, v)


v35: Callable[[str], FSharpResult_2[Array[str], str]] = _arrow269

def split_args(x: str) -> FSharpResult_2[Array[str], str]:
    return v35(x)


