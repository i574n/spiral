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
from fable_modules.fable_library.types import (int64, Array, Union, Record, to_string as to_string_1)
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

def _expr225() -> TypeInfo:
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


US0_reflection = _expr225

def _expr226() -> TypeInfo:
    return record_type("Runtime.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr226

def _expr227() -> TypeInfo:
    return record_type("Runtime.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr227

def _expr228() -> TypeInfo:
    return record_type("Runtime.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr228

def _expr229() -> TypeInfo:
    return record_type("Runtime.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr229

def _expr230() -> TypeInfo:
    return record_type("Runtime.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr230

def _expr231() -> TypeInfo:
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


US1_reflection = _expr231

def _expr232() -> TypeInfo:
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


US2_reflection = _expr232

def _expr233() -> TypeInfo:
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


US3_reflection = _expr233

def _expr234() -> TypeInfo:
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


US4_reflection = _expr234

def _expr235() -> TypeInfo:
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


US5_reflection = _expr235

def _expr236() -> TypeInfo:
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


US6_reflection = _expr236

def _expr237() -> TypeInfo:
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


US7_reflection = _expr237

def _expr238() -> TypeInfo:
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


US8_reflection = _expr238

def _expr239() -> TypeInfo:
    return union_type("Runtime.UH0", [], UH0, lambda: [[], [("Item1", char_type), ("Item2", UH0_reflection())]])


class UH0(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH0_0", "UH0_1"]


UH0_reflection = _expr239

def _expr240() -> TypeInfo:
    return union_type("Runtime.UH1", [], UH1, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US8_reflection())), ("Item2", UH1_reflection())]])


class UH1(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH1_0", "UH1_1"]


UH1_reflection = _expr240

def _expr241() -> TypeInfo:
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


US9_reflection = _expr241

def _expr242() -> TypeInfo:
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


US10_reflection = _expr242

def _expr243() -> TypeInfo:
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


US11_reflection = _expr243

def _expr244() -> TypeInfo:
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


US12_reflection = _expr244

def _expr245() -> TypeInfo:
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


US13_reflection = _expr245

def _expr246() -> TypeInfo:
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


US14_reflection = _expr246

def _expr247() -> TypeInfo:
    return record_type("Runtime.Mut5", [], Mut5, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut5(Record):
    l0: int

Mut5_reflection = _expr247

def _expr248() -> TypeInfo:
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


US15_reflection = _expr248

def _expr249() -> TypeInfo:
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


US16_reflection = _expr249

def _expr250() -> TypeInfo:
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

Heap0_reflection = _expr250

def _expr251() -> TypeInfo:
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


US17_reflection = _expr251

def _expr252() -> TypeInfo:
    return union_type("Runtime.UH2", [], UH2, lambda: [[], [("Item1", string_type), ("Item2", UH2_reflection())]])


class UH2(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH2_0", "UH2_1"]


UH2_reflection = _expr252

def _expr253() -> TypeInfo:
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


US18_reflection = _expr253

def _expr254() -> TypeInfo:
    return union_type("Runtime.UH3", [], UH3, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US9_reflection())), ("Item2", UH3_reflection())]])


class UH3(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH3_0", "UH3_1"]


UH3_reflection = _expr254

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow255(v: str) -> US5:
        return closure1(None, v)

    return _arrow255


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









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow256(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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
    def _arrow257(v: int64) -> US2:
        return closure6(None, v)

    return _arrow257


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
    class ObjectExpr258:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v57, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr258())))) == False:
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
    class ObjectExpr259:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v57, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr259())))) == False:
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
    class ObjectExpr260:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v57, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr260())))) == False:
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


def method25(v0: str, v1: Any, v2: int, v3: int) -> str:
    v5: Mut3 = Mut3(method13())
    v19: None
    closure7(v5, "{ ", None)
    v19 = None
    v38: None
    closure7(v5, "c", None)
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
    closure7(v5, "s", None)
    v115 = None
    v132: None
    closure7(v5, " = ", None)
    v132 = None
    v191: None
    closure7(v5, to_text(interpolate("%A%P()", [(v1, v2, v3)])), None)
    v191 = None
    v210: None
    closure7(v5, " }", None)
    v210 = None
    return v5.l0


def method26(v0: int64, v1: str, v2: int64) -> UH0:
    if v2 < v0:
        return UH0(1, v1[int(to_int(v2))], method26(v0, v1, op_addition(v2, int64(1))))

    else: 
        return UH0(0)



def method27(v0_mut: UH0, v1_mut: Any, v2_mut: int, v3_mut: int) -> tuple[Any, int, int]:
    while True:
        (v0, v1, v2, v3) = (v0_mut, v1_mut, v2_mut, v3_mut)
        if v0.tag == 0:
            return (v1, v2, v3)

        else: 
            v4: str = v0.fields[0]
            v6: bool = "\n" == v4
            pattern_input: tuple[int, int] = ((v2 + 1, 1)) if v6 else ((v2, v3 + 1))
            v0_mut = v0.fields[1]
            def _arrow261(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3) -> Any:
                v12: Any = StringBuilder__Clear(v1)
                return v1

            def _arrow262(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3) -> Any:
                v23: Any = StringBuilder__Append_Z721C83C5(v1, v4)
                return v1

            v1_mut = _arrow261() if v6 else _arrow262()
            v2_mut = pattern_input[0]
            v3_mut = pattern_input[1]
            continue

        break


def method28(v0: str, v1: int, v2: int) -> str:
    v4: Mut3 = Mut3(method13())
    v18: None
    closure7(v4, "{ ", None)
    v18 = None
    v37: None
    closure7(v4, "expected", None)
    v37 = None
    v56: None
    closure7(v4, " = ", None)
    v56 = None
    v76: None
    closure7(v4, ("" + str(v0)) + "", None)
    v76 = None
    v95: None
    closure7(v4, "; ", None)
    v95 = None
    v114: None
    closure7(v4, "line", None)
    v114 = None
    v131: None
    closure7(v4, " = ", None)
    v131 = None
    v151: None
    closure7(v4, ("" + str(v1)) + "", None)
    v151 = None
    v168: None
    closure7(v4, "; ", None)
    v168 = None
    v187: None
    closure7(v4, "col", None)
    v187 = None
    v204: None
    closure7(v4, " = ", None)
    v204 = None
    v224: None
    closure7(v4, ("" + str(v2)) + "", None)
    v224 = None
    v243: None
    closure7(v4, " }", None)
    v243 = None
    return v4.l0


def closure15(v0: int, v1: int, v2: str) -> str:
    if v1 >= v0:
        return v2

    else: 
        return method29(v0, v1 + 1)(v2 + " ")



def method29(v0: int, v1: int) -> Callable[[str], str]:
    def _arrow263(v: str, v0: Any=v0, v1: Any=v1) -> str:
        return closure15(v0, v1, v)

    return _arrow263


def closure14(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    if "" == v0:
        return US8(1, "parsing.p_char / unexpected end of input / " + method25("\"", v1, v2, v3))

    else: 
        v14_1: str = v0[0]
        if v14_1 == "\"":
            v47: int = (len(v0) - 1) or 0
            v49: str = v0[1:v47 + 1]
            v55: str = v14_1
            pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v55), False, 2), v55, int64(0)), v1, v2, v3)
            return US8(0, v14_1, v49, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v72: int = (v0.find("\n") - 1) or 0
            v108: int = (((len(v0) + 1) if (-2 == v72) else (v72 + 1)) - 1) or 0
            v110: str = v0[0:v108 + 1]
            return US8(1, (((((("parsing.p_char / " + method28("\"", v2, v3)) + "\n") + to_string_1(v1)) + v110) + "\n") + (method29(v3 - 1, 0)("") + "^")) + "\n")




def closure16(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    if "" == v0:
        return US8(1, "parsing.p_char / unexpected end of input / " + method25("\'", v1, v2, v3))

    else: 
        v14_1: str = v0[0]
        if v14_1 == "\'":
            v47: int = (len(v0) - 1) or 0
            v49: str = v0[1:v47 + 1]
            v55: str = v14_1
            pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v55), False, 2), v55, int64(0)), v1, v2, v3)
            return US8(0, v14_1, v49, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v72: int = (v0.find("\n") - 1) or 0
            v108: int = (((len(v0) + 1) if (-2 == v72) else (v72 + 1)) - 1) or 0
            v110: str = v0[0:v108 + 1]
            return US8(1, (((((("parsing.p_char / " + method28("\'", v2, v3)) + "\n") + to_string_1(v1)) + v110) + "\n") + (method29(v3 - 1, 0)("") + "^")) + "\n")




def method30(v0_mut: str, v1_mut: Any, v2_mut: UH1) -> US8:
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


def method31(v0: Array[str], v1: Any, v2: int, v3: int) -> str:
    v5: Mut3 = Mut3(method13())
    v19: None
    closure7(v5, "{ ", None)
    v19 = None
    v38: None
    closure7(v5, "chars", None)
    v38 = None
    v57: None
    closure7(v5, " = ", None)
    v57 = None
    v78: None
    closure7(v5, to_text(interpolate("%A%P()", [v0])), None)
    v78 = None
    v97: None
    closure7(v5, "; ", None)
    v97 = None
    v116: None
    closure7(v5, "s", None)
    v116 = None
    v133: None
    closure7(v5, " = ", None)
    v133 = None
    v192: None
    closure7(v5, to_text(interpolate("%A%P()", [(v1, v2, v3)])), None)
    v192 = None
    v211: None
    closure7(v5, " }", None)
    v211 = None
    return v5.l0


def method32(v0_mut: str, v1_mut: int64) -> bool:
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


            def _arrow264(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v11.fields[0] if (v11.tag == 0) else _arrow264()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def method33(v0: str, v1: Array[str], v2: Any, v3: int, v4: int) -> str:
    v6: Mut3 = Mut3(method13())
    v20: None
    closure7(v6, "{ ", None)
    v20 = None
    v39: None
    closure7(v6, "first_char", None)
    v39 = None
    v58: None
    closure7(v6, " = ", None)
    v58 = None
    v78: None
    closure7(v6, ("" + str(v0)) + "", None)
    v78 = None
    v97: None
    closure7(v6, "; ", None)
    v97 = None
    v116: None
    closure7(v6, "chars", None)
    v116 = None
    v133: None
    closure7(v6, " = ", None)
    v133 = None
    v154: None
    closure7(v6, to_text(interpolate("%A%P()", [v1])), None)
    v154 = None
    v171: None
    closure7(v6, "; ", None)
    v171 = None
    v190: None
    closure7(v6, "s", None)
    v190 = None
    v207: None
    closure7(v6, " = ", None)
    v207 = None
    v266: None
    closure7(v6, to_text(interpolate("%A%P()", [(v2, v3, v4)])), None)
    v266 = None
    v285: None
    closure7(v6, " }", None)
    v285 = None
    return v6.l0


def method34(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v104: US8
        if "" == v1:
            v104 = US8(1, "parsing.none_of / unexpected end of input / " + method31(to_array(of_array(["\"", "\'"])), v2, v3, v4))

        else: 
            v28: str = v1[0]
            if method32(v28, int64(0)) == False:
                v63: int = (len(v1) - 1) or 0
                v65: str = v1[1:v63 + 1]
                v71: str = v28
                pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v71), False, 2), v71, int64(0)), v2, v3, v4)
                v104 = US8(0, v28, v65, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v104 = US8(1, "parsing.none_of / unexpected char / " + method33(v28, to_array(of_array(["\"", "\'"])), v2, v3, v4))


        v116: US8
        if v104.tag == 0:
            v105: str = v104.fields[0]
            v116 = US8(0, "/" if ("\\" == v105) else v105, v104.fields[1], v104.fields[2], v104.fields[3], v104.fields[4])

        else: 
            v116 = US8(1, v104.fields[0])

        if v116.tag == 0:
            v0_mut = v0 + v116.fields[0]
            v1_mut = v116.fields[1]
            v2_mut = v116.fields[2]
            v3_mut = v116.fields[3]
            v4_mut = v116.fields[4]
            continue

        else: 
            return (v0, v1, v2, v3, v4)

        break


def method35(v0_mut: str, v1_mut: Any, v2_mut: int, v3_mut: int, v4_mut: UH1) -> US8:
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


def method36(v0: str, v1: str, v2: Any, v3: int, v4: int, v5: str, v6: Any, v7: int, v8: int, v9: str, v10: Any, v11: int, v12: int) -> str:
    v14_1: Mut3 = Mut3(method13())
    v28: None
    closure7(v14_1, "{ ", None)
    v28 = None
    v47: None
    closure7(v14_1, "e", None)
    v47 = None
    v66: None
    closure7(v14_1, " = ", None)
    v66 = None
    v83: None
    closure7(v14_1, v0, None)
    v83 = None
    v102: None
    closure7(v14_1, "; ", None)
    v102 = None
    v121: None
    closure7(v14_1, "input", None)
    v121 = None
    v138: None
    closure7(v14_1, " = ", None)
    v138 = None
    v155: None
    closure7(v14_1, v1, None)
    v155 = None
    v174: None
    closure7(v14_1, ", ", None)
    v174 = None
    v233: None
    closure7(v14_1, to_text(interpolate("%A%P()", [(v2, v3, v4)])), None)
    v233 = None
    v250: None
    closure7(v14_1, "; ", None)
    v250 = None
    v269: None
    closure7(v14_1, "rest1", None)
    v269 = None
    v286: None
    closure7(v14_1, " = ", None)
    v286 = None
    v303: None
    closure7(v14_1, v5, None)
    v303 = None
    v320: None
    closure7(v14_1, ", ", None)
    v320 = None
    v379: None
    closure7(v14_1, to_text(interpolate("%A%P()", [(v6, v7, v8)])), None)
    v379 = None
    v396: None
    closure7(v14_1, "; ", None)
    v396 = None
    v415: None
    closure7(v14_1, "rest2", None)
    v415 = None
    v432: None
    closure7(v14_1, " = ", None)
    v432 = None
    v449: None
    closure7(v14_1, v9, None)
    v449 = None
    v466: None
    closure7(v14_1, ", ", None)
    v466 = None
    v525: None
    closure7(v14_1, to_text(interpolate("%A%P()", [(v10, v11, v12)])), None)
    v525 = None
    v544: None
    closure7(v14_1, " }", None)
    v544 = None
    return v14_1.l0


def method37(v0_mut: str, v1_mut: int64) -> bool:
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



            def _arrow265(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v15_1.fields[0] if (v15_1.tag == 0) else _arrow265()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def method38(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v112: US8
        if "" == v1:
            v112 = US8(1, "parsing.none_of / unexpected end of input / " + method31(to_array(of_array(["\"", "\'", " "])), v2, v3, v4))

        else: 
            v32_1: str = v1[0]
            if method37(v32_1, int64(0)) == False:
                v67: int = (len(v1) - 1) or 0
                v69: str = v1[1:v67 + 1]
                v75: str = v32_1
                pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v75), False, 2), v75, int64(0)), v2, v3, v4)
                v112 = US8(0, v32_1, v69, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v112 = US8(1, "parsing.none_of / unexpected char / " + method33(v32_1, to_array(of_array(["\"", "\'", " "])), v2, v3, v4))


        v124: US8
        if v112.tag == 0:
            v113: str = v112.fields[0]
            v124 = US8(0, "/" if ("\\" == v113) else v113, v112.fields[1], v112.fields[2], v112.fields[3], v112.fields[4])

        else: 
            v124 = US8(1, v112.fields[0])

        if v124.tag == 0:
            v0_mut = v0 + v124.fields[0]
            v1_mut = v124.fields[1]
            v2_mut = v124.fields[2]
            v3_mut = v124.fields[3]
            v4_mut = v124.fields[4]
            continue

        else: 
            return (v0, v1, v2, v3, v4)

        break


def method39(v0: str) -> str:
    v2: Mut3 = Mut3(method13())
    v16_1: None
    closure7(v2, "{ ", None)
    v16_1 = None
    v35_1: None
    closure7(v2, "input", None)
    v35_1 = None
    v54: None
    closure7(v2, " = ", None)
    v54 = None
    v71: None
    closure7(v2, v0, None)
    v71 = None
    v90: None
    closure7(v2, " }", None)
    v90 = None
    return v2.l0


def method40(v0_mut: str, v1_mut: int) -> int:
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


def method41(v0: Any, v1: int, v2: int) -> str:
    v4: Mut3 = Mut3(method13())
    v18: None
    closure7(v4, "{ ", None)
    v18 = None
    v37: None
    closure7(v4, "s", None)
    v37 = None
    v56: None
    closure7(v4, " = ", None)
    v56 = None
    v115: None
    closure7(v4, to_text(interpolate("%A%P()", [(v0, v1, v2)])), None)
    v115 = None
    v134: None
    closure7(v4, " }", None)
    v134 = None
    return v4.l0


def method42(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v64: US8
        if "" == v1:
            v64 = US8(1, "parsing.any_char / unexpected end of input / " + method41(v2, v3, v4))

        else: 
            v14_1: str = v1[0]
            v46: int = (len(v1) - 1) or 0
            v48: str = v1[1:v46 + 1]
            v54: str = v14_1
            pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v54), False, 2), v54, int64(0)), v2, v3, v4)
            v64 = US8(0, v14_1, v48, pattern_input[0], pattern_input[1], pattern_input[2])

        if v64.tag == 0:
            v0_mut = v0 + v64.fields[0]
            v1_mut = v64.fields[1]
            v2_mut = v64.fields[2]
            v3_mut = v64.fields[3]
            v4_mut = v64.fields[4]
            continue

        else: 
            return (v0, v1, v2, v3, v4)

        break


def method23(v0: str) -> US7:
    _v0: (str | None) | None = None
    _v0 = some(v0)
    def _arrow266(__unit: None=None, v0: Any=v0) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v10: str = default_arg(_arrow266() if (_v0 is None) else value_12(_v0), "")
    v16_1: Any = StringBuilder__ctor_Z721C83C5(method24())
    def v19(_arg10: tuple[str, Any, int, int], v0: Any=v0) -> US8:
        return closure14(None, _arg10)

    def v20(_arg10_1: tuple[str, Any, int, int], v0: Any=v0) -> US8:
        return closure16(None, _arg10_1)

    v24: US8 = method30(v10, v16_1, UH1(1, v19, UH1(1, v20, UH1(0))))
    v208: US9
    if v24.tag == 0:
        v29: int = v24.fields[4] or 0
        v28: int = v24.fields[3] or 0
        v27: Any = v24.fields[2]
        v26: str = v24.fields[1]
        v129: US8
        if "" == v26:
            v129 = US8(1, "parsing.none_of / unexpected end of input / " + method31(to_array(of_array(["\"", "\'"])), v27, v28, v29))

        else: 
            v53: str = v26[0]
            if method32(v53, int64(0)) == False:
                v88: int = (len(v26) - 1) or 0
                v90: str = v26[1:v88 + 1]
                v96: str = v53
                pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v96), False, 2), v96, int64(0)), v27, v28, v29)
                v129 = US8(0, v53, v90, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v129 = US8(1, "parsing.none_of / unexpected char / " + method33(v53, to_array(of_array(["\"", "\'"])), v27, v28, v29))


        v141: US8
        if v129.tag == 0:
            v130: str = v129.fields[0]
            v141 = US8(0, "/" if ("\\" == v130) else v130, v129.fields[1], v129.fields[2], v129.fields[3], v129.fields[4])

        else: 
            v141 = US8(1, v129.fields[0])

        v161: US9
        if v141.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method34(v141.fields[0], v141.fields[1], v141.fields[2], v141.fields[3], v141.fields[4])
            v161 = US9(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v161 = US9(1, v141.fields[0])

        v171: US9 = US9(0, v161.fields[0], v161.fields[1], v161.fields[2], v161.fields[3], v161.fields[4]) if (v161.tag == 0) else US9(0, "", v26, v27, v28, v29)
        if v171.tag == 0:
            v176: int = v171.fields[4] or 0
            v175: int = v171.fields[3] or 0
            v174: Any = v171.fields[2]
            v173: str = v171.fields[1]
            v180: US8 = method35(v173, v174, v175, v176, UH1(1, v19, UH1(1, v20, UH1(0))))
            v208 = US9(0, v171.fields[0], v180.fields[1], v180.fields[2], v180.fields[3], v180.fields[4]) if (v180.tag == 0) else US9(1, "parsing.between / expected closing delimiter / " + method36(v180.fields[0], v10, v16_1, 1, 1, v26, v27, v28, v29, v173, v174, v175, v176))

        else: 
            v208 = US9(1, "parsing.between / expected content")


    else: 
        v208 = US9(1, v24.fields[0])

    v440: US9
    if v208.tag == 0:
        v440 = v208

    else: 
        v328: US8
        if "" == v10:
            v328 = US8(1, "parsing.none_of / unexpected end of input / " + method31(to_array(of_array(["\"", "\'", " "])), v16_1, 1, 1))

        else: 
            v244: str = v10[0]
            if method37(v244, int64(0)) == False:
                v279: int = (len(v10) - 1) or 0
                v281: str = v10[1:v279 + 1]
                v287: str = v244
                pattern_input_2: tuple[Any, int, int] = method27(method26(from_integer(len(v287), False, 2), v287, int64(0)), v16_1, 1, 1)
                v328 = US8(0, v244, v281, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

            else: 
                v328 = US8(1, "parsing.none_of / unexpected char / " + method33(v244, to_array(of_array(["\"", "\'", " "])), v16_1, 1, 1))


        v340: US8
        if v328.tag == 0:
            v329: str = v328.fields[0]
            v340 = US8(0, "/" if ("\\" == v329) else v329, v328.fields[1], v328.fields[2], v328.fields[3], v328.fields[4])

        else: 
            v340 = US8(1, v328.fields[0])

        v360: US9
        if v340.tag == 0:
            pattern_input_3: tuple[str, str, Any, int, int] = method38(v340.fields[0], v340.fields[1], v340.fields[2], v340.fields[3], v340.fields[4])
            v360 = US9(0, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2], pattern_input_3[3], pattern_input_3[4])

        else: 
            v360 = US9(1, v340.fields[0])

        if v360.tag == 0:
            v440 = v360

        else: 
            v378: US11 = US11(0, v10, v16_1, 1, 1) if (len(v10) == 0) else US11(1, "parsing.eof / expected end of input / " + method39(v10))
            v387: US9 = US9(0, "", v378.fields[0], v378.fields[1], v378.fields[2], v378.fields[3]) if (v378.tag == 0) else US9(1, v378.fields[0])
            if v387.tag == 0:
                v389: str = v387.fields[1]
                v394: int = method40(v389, 0) or 0
                v426: int = (len(v389) - 1) or 0
                v440 = US9(0, v387.fields[0], v389[v394:v426 + 1], v387.fields[2], v387.fields[3], v387.fields[4])

            else: 
                v440 = US9(1, v387.fields[0])



    v732: US12
    if v440.tag == 0:
        v445: int = v440.fields[4] or 0
        v444: int = v440.fields[3] or 0
        v443: Any = v440.fields[2]
        v442: str = v440.fields[1]
        v605: US8
        if "" == v442:
            v605 = US8(1, "parsing.p_char / unexpected end of input / " + method25(" ", v443, v444, v445))

        else: 
            v456: str = v442[0]
            if v456 == " ":
                v489: int = (len(v442) - 1) or 0
                v491: str = v442[1:v489 + 1]
                v497: str = v456
                pattern_input_4: tuple[Any, int, int] = method27(method26(from_integer(len(v497), False, 2), v497, int64(0)), v443, v444, v445)
                v605 = US8(0, v456, v491, pattern_input_4[0], pattern_input_4[1], pattern_input_4[2])

            else: 
                v514: int = (v442.find("\n") - 1) or 0
                v550: int = (((len(v442) + 1) if (-2 == v514) else (v514 + 1)) - 1) or 0
                v552: str = v442[0:v550 + 1]
                v605 = US8(1, (((((("parsing.p_char / " + method28(" ", v444, v445)) + "\n") + to_string_1(v443)) + v552) + "\n") + (method29(v445 - 1, 0)("") + "^")) + "\n")


        v617: US13 = US13(0, US10(0, v605.fields[0]), v605.fields[1], v605.fields[2], v605.fields[3], v605.fields[4]) if (v605.tag == 0) else US13(0, US10(1), v442, v443, v444, v445)
        v706: US9
        if v617.tag == 0:
            v622: int = v617.fields[4] or 0
            v621: int = v617.fields[3] or 0
            v620: Any = v617.fields[2]
            v619: str = v617.fields[1]
            v682: US8
            if "" == v619:
                v682 = US8(1, "parsing.any_char / unexpected end of input / " + method41(v620, v621, v622))

            else: 
                v632: str = v619[0]
                v664: int = (len(v619) - 1) or 0
                v666: str = v619[1:v664 + 1]
                v672: str = v632
                pattern_input_5: tuple[Any, int, int] = method27(method26(from_integer(len(v672), False, 2), v672, int64(0)), v620, v621, v622)
                v682 = US8(0, v632, v666, pattern_input_5[0], pattern_input_5[1], pattern_input_5[2])

            if v682.tag == 0:
                pattern_input_6: tuple[str, str, Any, int, int] = method42(v682.fields[0], v682.fields[1], v682.fields[2], v682.fields[3], v682.fields[4])
                v706 = US9(0, pattern_input_6[0], pattern_input_6[1], pattern_input_6[2], pattern_input_6[3], pattern_input_6[4])

            else: 
                v706 = US9(1, v682.fields[0])


        else: 
            v706 = US9(1, v617.fields[0])

        v718: US14 = US14(0, US5(0, v706.fields[0]), v706.fields[1], v706.fields[2], v706.fields[3], v706.fields[4]) if (v706.tag == 0) else US14(0, US5(1), v442, v443, v444, v445)
        v732 = US12(0, v440.fields[0], v718.fields[0], v718.fields[1], v718.fields[2], v718.fields[3], v718.fields[4]) if (v718.tag == 0) else US12(1, v718.fields[0])

    else: 
        v732 = US12(1, v440.fields[0])

    if v732.tag == 0:
        return US7(0, v732.fields[0], v732.fields[1])

    else: 
        return US7(1, v732.fields[0])



def method43(__unit: None=None) -> str:
    v4: str = "Debug".lower()
    return ("\u001b[94m" + method12(v4[0])) + method14()


def method45(v0: str, v1: US5, v2: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None=None) -> str:
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


def method44(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: US5, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14_1: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15_1: bool, v16_1: str | None=None) -> str:
    v17: str = method45(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1)
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
    class ObjectExpr267:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v66, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr267())))) == False:
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
        v132: str = method44(v112, v113, v114, v115, v116, v117, method7(v112, v113, v114, v115, v116, v117), method43(), v8, v7, v0, v1, v2, v3, v4, v5, v6)
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



def method46(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Array[tuple[str, str]]:
    return v2


def method47(v0: int, v1: Mut5) -> bool:
    return v1.l0 < v0


def method50(v0: bool) -> str:
    return None


def closure19(unit_var: None, v0: Callable[[tuple[int, str, bool]], Async[None]]) -> US15:
    return US15(0, v0)


def method51(__unit: None=None) -> Callable[[Callable[[tuple[int, str, bool]], Async[None]]], US15]:
    def _arrow268(v: Callable[[tuple[int, str, bool]], Async[None]]) -> US15:
        return closure19(None, v)

    return _arrow268


def method52(v0: bool) -> int:
    return None


def method53(__unit: None=None) -> str:
    v4: str = "Verbose".lower()
    return ("\u001b[90m" + method12(v4[0])) + method14()


def method54(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
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
    class ObjectExpr269:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (0 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr269())))) == False:
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
        v127: str = "" if (v0 == "") else method54(v104, v105, v106, v107, v108, v109, method7(v104, v105, v106, v107, v108, v109), method53(), v0)
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



def method49(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> Async[None]:
    def _arrow279(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, v9: Any=v9, v10: Any=v10) -> Async[None]:
        v27513: str = method50(v10)
        v27519: bool = (v27513 is None) != True
        def _arrow277(__unit: None=None) -> Async[None]:
            v27544: US15 = default_arg(map(method51(), v3), US15(1))
            def _arrow271(__unit: None=None) -> Async[None]:
                v27550: Async[None] = v27544.fields[0]((method52(v7), v27513, v9))
                def _arrow270(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v27550, _arrow270)

            def _expr272():
                return singleton.Zero()

            def _arrow276(__unit: None=None) -> Async[None]:
                v27553: str = concat("! ", *v27513) if v9 else concat("> ", *v27513)
                def _arrow273(__unit: None=None) -> Async[None]:
                    v27870: None
                    closure20(v27553, None)
                    v27870 = None
                    return singleton.Zero()

                def _arrow274(__unit: None=None) -> Async[None]:
                    v28191: None
                    closure10(v27553, None)
                    v28191 = None
                    return singleton.Zero()

                def _arrow275(__unit: None=None) -> Async[None]:
                    v28199: str = concat("\u001b[7;4m" if v9 else "", v27513, *"\u001b[0m" if v9 else "")
                    return singleton.Zero()

                return singleton.Combine(_arrow273() if v5 else _arrow274(), singleton.Delay(_arrow275))

            return singleton.Combine(_arrow271() if (v27544.tag == 0) else _expr272(), singleton.Delay(_arrow276))

        def _arrow278(__unit: None=None) -> Async[None]:
            return singleton.Zero()

        return singleton.Combine(_arrow277() if v27519 else singleton.Zero(), singleton.Delay(_arrow278))

    return singleton.Delay(_arrow279)


def method48(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> Async[None]:
    return method49(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)


def closure18(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> None:
    start_immediate(method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10))


def closure21(unit_var: None, v0: CancellationToken) -> US16:
    return US16(0, v0)


def method55(__unit: None=None) -> Callable[[CancellationToken], US16]:
    def _arrow280(v: CancellationToken) -> US16:
        return closure21(None, v)

    return _arrow280


def method56(v0: CancellationToken) -> Async[CancellationToken]:
    def _arrow281(__unit: None=None, v0: Any=v0) -> Async[CancellationToken]:
        return singleton.Return(None)

    return singleton.Delay(_arrow281)


def method57(v0: bool) -> bool:
    return None


def method58(v0: bool) -> None:
    pass


def closure22(v0: bool, unit_var: None) -> None:
    if method57(v0) == False:
        method58(v0)



def method61(v0: Any) -> str:
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


def method60(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: Any) -> str:
    v9: str = method61(v8)
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
    class ObjectExpr282:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr282())))) == False:
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
        v124: str = method60(v104, v105, v106, v107, v108, v109, method7(v104, v105, v106, v107, v108, v109), method11(), v0)
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



def method59(v0: bool, v1: Any, v2: CancellationToken) -> Async[int]:
    def _arrow286(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[int]:
        def _arrow284(__unit: None=None) -> Async[int]:
            v94280: Async[None] = await_task(None)
            def _arrow283(__unit: None=None) -> Async[int]:
                return singleton.Return(None)

            return singleton.Bind(v94280, _arrow283)

        def _arrow285(_arg_1: Exception) -> Async[int]:
            v95113: Exception = _arg_1
            v95136: str = to_text(interpolate("%A%P()", [v95113]))
            v95472: None
            closure23(v95113, None)
            v95472 = None
            return singleton.Return(-2147483648)

        return singleton.TryWith(singleton.Delay(_arrow284), _arrow285)

    return singleton.Delay(_arrow286)


def method62(__unit: None=None) -> str:
    return "\n"


def method64(v0: int, v1: int, v2: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None=None) -> str:
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


def method63(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: int, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14_1: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15_1: bool, v16_1: str | None=None) -> str:
    v17: str = method64(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1)
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
    class ObjectExpr287:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v66, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr287())))) == False:
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
        v133: str = method63(v112, v113, v114, v115, v116, v117, method7(v112, v113, v114, v115, v116, v117), method43(), v7, len(v8), v0, v1, v2, v3, v4, v5, v6)
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
    def _arrow288(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6) -> Async[tuple[int, str]]:
        pattern_input: tuple[int, str] = None
        return singleton.Return((pattern_input[0], pattern_input[1]))

    return singleton.Delay(_arrow288)


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


def method67(v0_mut: str, v1_mut: int64) -> bool:
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




            def _arrow289(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v19.fields[0] if (v19.tag == 0) else _arrow289()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def method68(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v120: US8
        if "" == v1:
            v120 = US8(1, "parsing.none_of / unexpected end of input / " + method31(to_array(of_array(["\\", "`", "\"", " "])), v2, v3, v4))

        else: 
            v36: str = v1[0]
            if method67(v36, int64(0)) == False:
                v71: int = (len(v1) - 1) or 0
                v73: str = v1[1:v71 + 1]
                v79: str = v36
                pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v79), False, 2), v79, int64(0)), v2, v3, v4)
                v120 = US8(0, v36, v73, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v120 = US8(1, "parsing.none_of / unexpected char / " + method33(v36, to_array(of_array(["\\", "`", "\"", " "])), v2, v3, v4))


        if v120.tag == 0:
            v0_mut = v0 + v120.fields[0]
            v1_mut = v120.fields[1]
            v2_mut = v120.fields[2]
            v3_mut = v120.fields[3]
            v4_mut = v120.fields[4]
            continue

        else: 
            return (v0, v1, v2, v3, v4)

        break


def method70(v0_mut: str, v1_mut: int64) -> bool:
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



            def _arrow290(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v15_1.fields[0] if (v15_1.tag == 0) else _arrow290()):
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
    v164: US8
    if "" == v0:
        v164 = US8(1, "parsing.p_char / unexpected end of input / " + method25("\\", v1, v2, v3))

    else: 
        v14_1: str = v0[0]
        if v14_1 == "\\":
            v47: int = (len(v0) - 1) or 0
            v49: str = v0[1:v47 + 1]
            v55: str = v14_1
            pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v55), False, 2), v55, int64(0)), v1, v2, v3)
            v164 = US8(0, v14_1, v49, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v72: int = (v0.find("\n") - 1) or 0
            v108: int = (((len(v0) + 1) if (-2 == v72) else (v72 + 1)) - 1) or 0
            v110: str = v0[0:v108 + 1]
            v164 = US8(1, (((((("parsing.p_char / " + method28("\\", v2, v3)) + "\n") + to_string_1(v1)) + v110) + "\n") + (method29(v3 - 1, 0)("") + "^")) + "\n")


    v233: US8
    if v164.tag == 0:
        v169: int = v164.fields[4] or 0
        v168: int = v164.fields[3] or 0
        v167: Any = v164.fields[2]
        v166: str = v164.fields[1]
        if "" == v166:
            v233 = US8(1, "parsing.any_char / unexpected end of input / " + method41(v167, v168, v169))

        else: 
            v179: str = v166[0]
            v211: int = (len(v166) - 1) or 0
            v213: str = v166[1:v211 + 1]
            v219: str = v179
            pattern_input_1: tuple[Any, int, int] = method27(method26(from_integer(len(v219), False, 2), v219, int64(0)), v167, v168, v169)
            v233 = US8(0, v179, v213, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v233 = US8(1, v164.fields[0])

    if v233.tag == 0:
        return US9(0, "\\" + v233.fields[0], v233.fields[1], v233.fields[2], v233.fields[3], v233.fields[4])

    else: 
        return US9(1, v233.fields[0])



def closure29(unit_var: None, _arg: tuple[str, Any, int, int]) -> US9:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    v164: US8
    if "" == v0:
        v164 = US8(1, "parsing.p_char / unexpected end of input / " + method25("`", v1, v2, v3))

    else: 
        v14_1: str = v0[0]
        if v14_1 == "`":
            v47: int = (len(v0) - 1) or 0
            v49: str = v0[1:v47 + 1]
            v55: str = v14_1
            pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v55), False, 2), v55, int64(0)), v1, v2, v3)
            v164 = US8(0, v14_1, v49, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v72: int = (v0.find("\n") - 1) or 0
            v108: int = (((len(v0) + 1) if (-2 == v72) else (v72 + 1)) - 1) or 0
            v110: str = v0[0:v108 + 1]
            v164 = US8(1, (((((("parsing.p_char / " + method28("`", v2, v3)) + "\n") + to_string_1(v1)) + v110) + "\n") + (method29(v3 - 1, 0)("") + "^")) + "\n")


    v233: US8
    if v164.tag == 0:
        v169: int = v164.fields[4] or 0
        v168: int = v164.fields[3] or 0
        v167: Any = v164.fields[2]
        v166: str = v164.fields[1]
        if "" == v166:
            v233 = US8(1, "parsing.any_char / unexpected end of input / " + method41(v167, v168, v169))

        else: 
            v179: str = v166[0]
            v211: int = (len(v166) - 1) or 0
            v213: str = v166[1:v211 + 1]
            v219: str = v179
            pattern_input_1: tuple[Any, int, int] = method27(method26(from_integer(len(v219), False, 2), v219, int64(0)), v167, v168, v169)
            v233 = US8(0, v179, v213, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v233 = US8(1, v164.fields[0])

    if v233.tag == 0:
        return US9(0, "`" + v233.fields[0], v233.fields[1], v233.fields[2], v233.fields[3], v233.fields[4])

    else: 
        return US9(1, v233.fields[0])



def method71(v0_mut: str, v1_mut: Any, v2_mut: int, v3_mut: int, v4_mut: UH3) -> US9:
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


def method72(v0_mut: UH2, v1_mut: UH2) -> UH2:
    while True:
        (v0, v1) = (v0_mut, v1_mut)
        if v0.tag == 0:
            return v1

        else: 
            v0_mut = v0.fields[1]
            v1_mut = UH2(1, v0.fields[0], v1)
            continue

        break


def method69(v0_mut: UH2, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v112: US8
        if "" == v1:
            v112 = US8(1, "parsing.none_of / unexpected end of input / " + method31(to_array(of_array(["\\", "`", "\""])), v2, v3, v4))

        else: 
            v32_1: str = v1[0]
            if method70(v32_1, int64(0)) == False:
                v67: int = (len(v1) - 1) or 0
                v69: str = v1[1:v67 + 1]
                v75: str = v32_1
                pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v75), False, 2), v75, int64(0)), v2, v3, v4)
                v112 = US8(0, v32_1, v69, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v112 = US8(1, "parsing.none_of / unexpected char / " + method33(v32_1, to_array(of_array(["\\", "`", "\""])), v2, v3, v4))


        v127: US9 = US9(0, v112.fields[0], v112.fields[1], v112.fields[2], v112.fields[3], v112.fields[4]) if (v112.tag == 0) else US9(1, v112.fields[0])
        def v134(_arg10: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
            return closure28(None, _arg10)

        def v135(_arg10_1: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
            return closure29(None, _arg10_1)

        v141: US9 = v127 if (v127.tag == 0) else method71(v1, v2, v3, v4, UH3(1, v134, UH3(1, v135, UH3(0))))
        if v141.tag == 0:
            v0_mut = UH2(1, v141.fields[0], v0)
            v1_mut = v141.fields[1]
            v2_mut = v141.fields[2]
            v3_mut = v141.fields[3]
            v4_mut = v141.fields[4]
            continue

        else: 
            return US18(0, method72(v0, UH2(0)), v1, v2, v3, v4)

        break


def method73(v0: UH2, v1: FSharpList[str]) -> FSharpList[str]:
    if v0.tag == 0:
        return v1

    else: 
        return cons(v0.fields[0], method73(v0.fields[1], v1))



def method74(v0_mut: UH2, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v112: US8
        if "" == v1:
            v112 = US8(1, "parsing.none_of / unexpected end of input / " + method31(to_array(of_array(["\\", "`", "\""])), v2, v3, v4))

        else: 
            v32_1: str = v1[0]
            if method70(v32_1, int64(0)) == False:
                v67: int = (len(v1) - 1) or 0
                v69: str = v1[1:v67 + 1]
                v75: str = v32_1
                pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v75), False, 2), v75, int64(0)), v2, v3, v4)
                v112 = US8(0, v32_1, v69, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v112 = US8(1, "parsing.none_of / unexpected char / " + method33(v32_1, to_array(of_array(["\\", "`", "\""])), v2, v3, v4))


        v127: US9 = US9(0, v112.fields[0], v112.fields[1], v112.fields[2], v112.fields[3], v112.fields[4]) if (v112.tag == 0) else US9(1, v112.fields[0])
        if v127.tag == 0:
            v0_mut = UH2(1, v127.fields[0], v0)
            v1_mut = v127.fields[1]
            v2_mut = v127.fields[2]
            v3_mut = v127.fields[3]
            v4_mut = v127.fields[4]
            continue

        else: 
            return US18(0, method72(v0, UH2(0)), v1, v2, v3, v4)

        break


def method66(v0_mut: UH2, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v5: bool = "" == v1
        v120: US8
        if v5:
            v120 = US8(1, "parsing.none_of / unexpected end of input / " + method31(to_array(of_array(["\\", "`", "\"", " "])), v2, v3, v4))

        else: 
            v36: str = v1[0]
            if method67(v36, int64(0)) == False:
                v71: int = (len(v1) - 1) or 0
                v73: str = v1[1:v71 + 1]
                v79: str = v36
                pattern_input: tuple[Any, int, int] = method27(method26(from_integer(len(v79), False, 2), v79, int64(0)), v2, v3, v4)
                v120 = US8(0, v36, v73, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v120 = US8(1, "parsing.none_of / unexpected char / " + method33(v36, to_array(of_array(["\\", "`", "\"", " "])), v2, v3, v4))


        v140: US9
        if v120.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method68(v120.fields[0], v120.fields[1], v120.fields[2], v120.fields[3], v120.fields[4])
            v140 = US9(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v140 = US9(1, v120.fields[0])

        v609: US9
        if v140.tag == 0:
            v609 = v140

        else: 
            v306: US8
            if v5:
                v306 = US8(1, "parsing.p_char / unexpected end of input / " + method25("\"", v2, v3, v4))

            else: 
                v156: str = v1[0]
                if v156 == "\"":
                    v189: int = (len(v1) - 1) or 0
                    v191: str = v1[1:v189 + 1]
                    v197: str = v156
                    pattern_input_2: tuple[Any, int, int] = method27(method26(from_integer(len(v197), False, 2), v197, int64(0)), v2, v3, v4)
                    v306 = US8(0, v156, v191, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

                else: 
                    v214: int = (v1.find("\n") - 1) or 0
                    v250: int = (((len(v1) + 1) if (-2 == v214) else (v214 + 1)) - 1) or 0
                    v252: str = v1[0:v250 + 1]
                    v306 = US8(1, (((((("parsing.p_char / " + method28("\"", v3, v4)) + "\n") + to_string_1(v2)) + v252) + "\n") + (method29(v4 - 1, 0)("") + "^")) + "\n")


            v538: US9
            if v306.tag == 0:
                v311: int = v306.fields[4] or 0
                v310: int = v306.fields[3] or 0
                v309: Any = v306.fields[2]
                v308: str = v306.fields[1]
                v313: US18 = method69(UH2(0), v308, v309, v310, v311)
                v346: US9
                if v313.tag == 0:
                    v320: FSharpList[str] = method73(v313.fields[0], empty())
                    def _arrow291(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v320

                    v346 = US9(0, join("", delay(_arrow291)), v313.fields[1], v313.fields[2], v313.fields[3], v313.fields[4])

                else: 
                    v346 = US9(1, v313.fields[0])

                if v346.tag == 0:
                    v351: int = v346.fields[4] or 0
                    v350: int = v346.fields[3] or 0
                    v349: Any = v346.fields[2]
                    v348: str = v346.fields[1]
                    v512: US8
                    if "" == v348:
                        v512 = US8(1, "parsing.p_char / unexpected end of input / " + method25("\"", v349, v350, v351))

                    else: 
                        v362: str = v348[0]
                        if v362 == "\"":
                            v395: int = (len(v348) - 1) or 0
                            v397: str = v348[1:v395 + 1]
                            v403: str = v362
                            pattern_input_3: tuple[Any, int, int] = method27(method26(from_integer(len(v403), False, 2), v403, int64(0)), v349, v350, v351)
                            v512 = US8(0, v362, v397, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2])

                        else: 
                            v420: int = (v348.find("\n") - 1) or 0
                            v456: int = (((len(v348) + 1) if (-2 == v420) else (v420 + 1)) - 1) or 0
                            v458: str = v348[0:v456 + 1]
                            v512 = US8(1, (((((("parsing.p_char / " + method28("\"", v350, v351)) + "\n") + to_string_1(v349)) + v458) + "\n") + (method29(v351 - 1, 0)("") + "^")) + "\n")


                    v538 = US9(0, v346.fields[0], v512.fields[1], v512.fields[2], v512.fields[3], v512.fields[4]) if (v512.tag == 0) else US9(1, "parsing.between / expected closing delimiter / " + method36(v512.fields[0], v1, v2, v3, v4, v308, v309, v310, v311, v348, v349, v350, v351))

                else: 
                    v538 = US9(1, "parsing.between / expected content")


            else: 
                v538 = US9(1, v306.fields[0])

            if v538.tag == 0:
                v609 = v538

            else: 
                def v545(_arg10: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
                    return closure28(None, _arg10)

                def v546(_arg10_1: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
                    return closure29(None, _arg10_1)

                v550: US9 = method71(v1, v2, v3, v4, UH3(1, v545, UH3(1, v546, UH3(0))))
                v561: US9 = US9(0, "", v550.fields[1], v550.fields[2], v550.fields[3], v550.fields[4]) if (v550.tag == 0) else US9(1, v550.fields[0])
                v572: US18 = method74(UH2(0), v561.fields[1], v561.fields[2], v561.fields[3], v561.fields[4]) if (v561.tag == 0) else US18(1, v561.fields[0])
                if v572.tag == 0:
                    v579: FSharpList[str] = method73(v572.fields[0], empty())
                    def _arrow292(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v579

                    v609 = US9(0, join("", delay(_arrow292)), v572.fields[1], v572.fields[2], v572.fields[3], v572.fields[4])

                else: 
                    v609 = US9(1, v572.fields[0])



        if v609.tag == 0:
            v614: int = v609.fields[4] or 0
            v613: int = v609.fields[3] or 0
            v612: Any = v609.fields[2]
            v611: str = v609.fields[1]
            v610: str = v609.fields[0]
            v616: int = method40(v611, 0) or 0
            v658: US11
            if 0 == v616:
                v658 = US11(1, "parsing.spaces1 / expected at least one space")

            else: 
                v651: int = (len(v611) - 1) or 0
                v658 = US11(0, v611[v616:v651 + 1], v612, v613, v614)

            if v658.tag == 0:
                v0_mut = UH2(1, v610, v0)
                v1_mut = v658.fields[0]
                v2_mut = v658.fields[1]
                v3_mut = v658.fields[2]
                v4_mut = v658.fields[3]
                continue

            else: 
                return US18(0, method72(v0, UH2(1, v610, UH2(0))), v611, v612, v613, v614)


        else: 
            return US18(0, method72(v0, UH2(0)), v1, v2, v3, v4)

        break


def method65(v0: str) -> US17:
    _v0: (str | None) | None = None
    _v0 = some(v0)
    def _arrow293(__unit: None=None, v0: Any=v0) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v22: US18 = method66(UH2(0), default_arg(_arrow293() if (_v0 is None) else value_12(_v0), ""), StringBuilder__ctor_Z721C83C5(method24()), 1, 1)
    if v22.tag == 0:
        return US17(0, to_array(method73(v22.fields[0], empty())))

    else: 
        return US17(1, v22.fields[0])



def closure27(unit_var: None, v0: str) -> FSharpResult_2[Array[str], str]:
    v1: US17 = method65(v0)
    if v1.tag == 0:
        return FSharpResult_2(0, v1.fields[0])

    else: 
        return FSharpResult_2(1, v1.fields[0])



v14: None = None

def _arrow294(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow294

def _expr295():
    v15(None)
    return v14


v16: None = _expr295()

def _arrow296(__unit: None=None) -> None:
    closure3(None, None)


v31: Callable[[], None] = _arrow296

def current_process_kill(__unit: None=None) -> None:
    v31(None)


def _arrow297(v: str) -> Async[tuple[int, str]]:
    return closure13(None, v)


v32: Callable[[str], Async[tuple[int, str]]] = _arrow297

def execute_async(x: str) -> Async[tuple[int, str]]:
    return v32(x)


def _arrow298(_arg10: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return closure25(None, _arg10)


v33: Callable[[tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]], Async[tuple[int, str]]] = _arrow298

def execute_with_options_async(x: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return v33(x)


def _arrow299(v: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    return closure26(None, v)


v34: Callable[[Callable[[Heap0], Heap0]], tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]] = _arrow299

def execution_options(x: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    return v34(x)


def _arrow300(v: str) -> FSharpResult_2[Array[str], str]:
    return closure27(None, v)


v35: Callable[[str], FSharpResult_2[Array[str], str]] = _arrow300

def split_args(x: str) -> FSharpResult_2[Array[str], str]:
    return v35(x)


