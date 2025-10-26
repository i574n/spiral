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

def _expr216() -> TypeInfo:
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


US0_reflection = _expr216

def _expr217() -> TypeInfo:
    return record_type("Runtime.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr217

def _expr218() -> TypeInfo:
    return record_type("Runtime.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr218

def _expr219() -> TypeInfo:
    return record_type("Runtime.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr219

def _expr220() -> TypeInfo:
    return record_type("Runtime.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr220

def _expr221() -> TypeInfo:
    return record_type("Runtime.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr221

def _expr222() -> TypeInfo:
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


US1_reflection = _expr222

def _expr223() -> TypeInfo:
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


US2_reflection = _expr223

def _expr224() -> TypeInfo:
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


US3_reflection = _expr224

def _expr225() -> TypeInfo:
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


US4_reflection = _expr225

def _expr226() -> TypeInfo:
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


US5_reflection = _expr226

def _expr227() -> TypeInfo:
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


US6_reflection = _expr227

def _expr228() -> TypeInfo:
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


US7_reflection = _expr228

def _expr229() -> TypeInfo:
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


US8_reflection = _expr229

def _expr230() -> TypeInfo:
    return union_type("Runtime.UH0", [], UH0, lambda: [[], [("Item1", char_type), ("Item2", UH0_reflection())]])


class UH0(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH0_0", "UH0_1"]


UH0_reflection = _expr230

def _expr231() -> TypeInfo:
    return union_type("Runtime.UH1", [], UH1, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US8_reflection())), ("Item2", UH1_reflection())]])


class UH1(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH1_0", "UH1_1"]


UH1_reflection = _expr231

def _expr232() -> TypeInfo:
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


US9_reflection = _expr232

def _expr233() -> TypeInfo:
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


US10_reflection = _expr233

def _expr234() -> TypeInfo:
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


US11_reflection = _expr234

def _expr235() -> TypeInfo:
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


US12_reflection = _expr235

def _expr236() -> TypeInfo:
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


US13_reflection = _expr236

def _expr237() -> TypeInfo:
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


US14_reflection = _expr237

def _expr238() -> TypeInfo:
    return record_type("Runtime.Mut5", [], Mut5, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut5(Record):
    l0: int

Mut5_reflection = _expr238

def _expr239() -> TypeInfo:
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


US15_reflection = _expr239

def _expr240() -> TypeInfo:
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


US16_reflection = _expr240

def _expr241() -> TypeInfo:
    return record_type("Runtime.Heap0", [], Heap0, lambda: [("l0", string_type), ("l1", option_type(class_type("System.Threading.CancellationToken"))), ("l2", array_type(tuple_type(string_type, string_type))), ("l3", option_type(lambda_type(tuple_type(int32_type, string_type, bool_type), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [unit_type])))), ("l4", option_type(lambda_type(class_type("Runtime.std_sync_Arc`1", [class_type("Runtime.std_sync_Mutex`1", [class_type("Runtime.std_process_ChildStdin")])]), unit_type))), ("l5", bool_type), ("l6", option_type(string_type)), ("l7", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Heap0(Record):
    l0: str
    l1: CancellationToken | None
    l2: Array[tuple[str, str]]
    l3: Callable[[tuple[int, str, bool]], Async[None]] | None
    l4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None
    l5: bool
    l6: str | None
    l7: bool

Heap0_reflection = _expr241

def _expr242() -> TypeInfo:
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


US17_reflection = _expr242

def _expr243() -> TypeInfo:
    return union_type("Runtime.UH2", [], UH2, lambda: [[], [("Item1", string_type), ("Item2", UH2_reflection())]])


class UH2(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH2_0", "UH2_1"]


UH2_reflection = _expr243

def _expr244() -> TypeInfo:
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


US18_reflection = _expr244

def _expr245() -> TypeInfo:
    return union_type("Runtime.UH3", [], UH3, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US9_reflection())), ("Item2", UH3_reflection())]])


class UH3(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH3_0", "UH3_1"]


UH3_reflection = _expr245

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow246(v: str) -> US5:
        return closure1(None, v)

    return _arrow246


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
    def _arrow247(__unit: None=None) -> US1:
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









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow247(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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
    def _arrow248(v: int64) -> US2:
        return closure6(None, v)

    return _arrow248


def method9(__unit: None=None) -> str:
    return "hh:mm:ss"


def method10(__unit: None=None) -> str:
    return "HH:mm:ss"


def method7(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v920: US2 = default_arg(map(method8(), v5), US2(1))
    v1074: Any
    if v920.tag == 0:
        v1003: Any = create(op_subtraction(from_value(ticks_1(now()), False), v920.fields[0]))
        v1074 = create_1(1, 1, 1, hours(v1003), minutes(v1003), seconds(v1003), milliseconds(v1003))

    else: 
        v1074 = now()

    v1075: str = method10()
    return to_string(v1074, "M-d-y hh:mm:ss tt" if (v1075 == "") else v1075)


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


def method11(__unit: None=None) -> str:
    v133: str = "Warning".lower()
    return ("\u001b[93m" + method12(v133[0])) + "\u001b[0m"


def method15(__unit: None=None) -> str:
    v1: Mut3 = Mut3(method13())
    return v1.l0


def method16(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method14(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str) -> str:
    v8: str = method15()
    return method16((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 3") + " / ") + v8)


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
    class ObjectExpr249:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v57, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr249())))) == False:
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
        v123: str = method14(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11())
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



def method17(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str) -> str:
    v8: str = method15()
    return method16((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 2") + " / ") + v8)


def closure11(unit_var: None, unit_var_1: None) -> None:
    def v15_1(__unit: None=None, unit_var: Any=unit_var, unit_var_1: Any=unit_var_1) -> None:
        closure0(None, None)

    v16_1: None
    v15_1(None)
    v16_1 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v57: US0 = pattern_input[4].l0
    v297: US6
    class ObjectExpr250:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v57, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr250())))) == False:
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
        v123: str = method17(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11())
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
    v8: str = method15()
    return method16((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 1") + " / ") + v8)


def closure12(unit_var: None, unit_var_1: None) -> None:
    def v15_1(__unit: None=None, unit_var: Any=unit_var, unit_var_1: Any=unit_var_1) -> None:
        closure0(None, None)

    v16_1: None
    v15_1(None)
    v16_1 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v57: US0 = pattern_input[4].l0
    v297: US6
    class ObjectExpr251:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v57, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr251())))) == False:
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



def closure4(unit_var: None, unit_var_1: None) -> None:
    pass


def method6(__unit: None=None) -> None:
    pass


def closure3(unit_var: None, unit_var_1: None) -> None:
    method6()


def method23(__unit: None=None) -> str:
    return ""


def method24(v0: str, v1: Any, v2: int, v3: int) -> str:
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
            def _arrow252(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3) -> Any:
                v12: Any = StringBuilder__Clear(v1)
                return v1

            def _arrow253(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3) -> Any:
                v23: Any = StringBuilder__Append_Z721C83C5(v1, v4)
                return v1

            v1_mut = _arrow252() if v6 else _arrow253()
            v2_mut = pattern_input[0]
            v3_mut = pattern_input[1]
            continue

        break


def method27(v0: str, v1: int, v2: int) -> str:
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
        return method28(v0, v1 + 1)(v2 + " ")



def method28(v0: int, v1: int) -> Callable[[str], str]:
    def _arrow254(v: str, v0: Any=v0, v1: Any=v1) -> str:
        return closure15(v0, v1, v)

    return _arrow254


def closure14(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    if "" == v0:
        return US8(1, "parsing.p_char / unexpected end of input / " + method24("\"", v1, v2, v3))

    else: 
        v14_1: str = v0[0]
        if v14_1 == "\"":
            v49: int = (len(v0) - 1) or 0
            v51: str = v0[1:v49 + 1]
            v57: str = v14_1
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v57), False, 2), v57, int64(0)), v1, v2, v3)
            return US8(0, v14_1, v51, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v74: int = (v0.find("\n") - 1) or 0
            v112: int = (((len(v0) + 1) if (-2 == v74) else (v74 + 1)) - 1) or 0
            v114: str = v0[0:v112 + 1]
            return US8(1, (((((("parsing.p_char / " + method27("\"", v2, v3)) + "\n") + to_string_1(v1)) + v114) + "\n") + (method28(v3 - 1, 0)("") + "^")) + "\n")




def closure16(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    if "" == v0:
        return US8(1, "parsing.p_char / unexpected end of input / " + method24("\'", v1, v2, v3))

    else: 
        v14_1: str = v0[0]
        if v14_1 == "\'":
            v49: int = (len(v0) - 1) or 0
            v51: str = v0[1:v49 + 1]
            v57: str = v14_1
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v57), False, 2), v57, int64(0)), v1, v2, v3)
            return US8(0, v14_1, v51, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v74: int = (v0.find("\n") - 1) or 0
            v112: int = (((len(v0) + 1) if (-2 == v74) else (v74 + 1)) - 1) or 0
            v114: str = v0[0:v112 + 1]
            return US8(1, (((((("parsing.p_char / " + method27("\'", v2, v3)) + "\n") + to_string_1(v1)) + v114) + "\n") + (method28(v3 - 1, 0)("") + "^")) + "\n")




def method29(v0_mut: str, v1_mut: Any, v2_mut: UH1) -> US8:
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


def method30(v0: Array[str]) -> str:
    v2: Mut3 = Mut3(method13())
    v19: None
    closure7(v2, to_text(interpolate("%A%P()", [v0])), None)
    v19 = None
    return v2.l0


def method31(v0: str, v1: Any, v2: int, v3: int) -> str:
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
    v74: None
    closure7(v5, v0, None)
    v74 = None
    v93: None
    closure7(v5, "; ", None)
    v93 = None
    v112: None
    closure7(v5, "s", None)
    v112 = None
    v129: None
    closure7(v5, " = ", None)
    v129 = None
    v188: None
    closure7(v5, to_text(interpolate("%A%P()", [(v1, v2, v3)])), None)
    v188 = None
    v207: None
    closure7(v5, " }", None)
    v207 = None
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


            def _arrow255(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v11.fields[0] if (v11.tag == 0) else _arrow255()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def method33(v0: str, v1: str, v2: Any, v3: int, v4: int) -> str:
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
    v150: None
    closure7(v6, v1, None)
    v150 = None
    v167: None
    closure7(v6, "; ", None)
    v167 = None
    v186: None
    closure7(v6, "s", None)
    v186 = None
    v203: None
    closure7(v6, " = ", None)
    v203 = None
    v262: None
    closure7(v6, to_text(interpolate("%A%P()", [(v2, v3, v4)])), None)
    v262 = None
    v281: None
    closure7(v6, " }", None)
    v281 = None
    return v6.l0


def method34(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v176: US8
        if "" == v1:
            v176 = US8(1, "parsing.none_of / unexpected end of input / " + method31(method30(to_array(of_array(["\"", "\'"]))), v2, v3, v4))

        else: 
            v63: str = v1[0]
            if method32(v63, int64(0)) == False:
                v100: int = (len(v1) - 1) or 0
                v102: str = v1[1:v100 + 1]
                v108: str = v63
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v108), False, 2), v108, int64(0)), v2, v3, v4)
                v176 = US8(0, v63, v102, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v176 = US8(1, "parsing.none_of / unexpected char / " + method33(v63, method30(to_array(of_array(["\"", "\'"]))), v2, v3, v4))


        v188: US8
        if v176.tag == 0:
            v177: str = v176.fields[0]
            v188 = US8(0, "/" if ("\\" == v177) else v177, v176.fields[1], v176.fields[2], v176.fields[3], v176.fields[4])

        else: 
            v188 = US8(1, v176.fields[0])

        if v188.tag == 0:
            v0_mut = v0 + v188.fields[0]
            v1_mut = v188.fields[1]
            v2_mut = v188.fields[2]
            v3_mut = v188.fields[3]
            v4_mut = v188.fields[4]
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



            def _arrow263(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v15_1.fields[0] if (v15_1.tag == 0) else _arrow263()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def method38(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v200: US8
        if "" == v1:
            v200 = US8(1, "parsing.none_of / unexpected end of input / " + method31(method30(to_array(of_array(["\"", "\'", " "]))), v2, v3, v4))

        else: 
            v75: str = v1[0]
            if method37(v75, int64(0)) == False:
                v112: int = (len(v1) - 1) or 0
                v114: str = v1[1:v112 + 1]
                v120: str = v75
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v120), False, 2), v120, int64(0)), v2, v3, v4)
                v200 = US8(0, v75, v114, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v200 = US8(1, "parsing.none_of / unexpected char / " + method33(v75, method30(to_array(of_array(["\"", "\'", " "]))), v2, v3, v4))


        v212: US8
        if v200.tag == 0:
            v201: str = v200.fields[0]
            v212 = US8(0, "/" if ("\\" == v201) else v201, v200.fields[1], v200.fields[2], v200.fields[3], v200.fields[4])

        else: 
            v212 = US8(1, v200.fields[0])

        if v212.tag == 0:
            v0_mut = v0 + v212.fields[0]
            v1_mut = v212.fields[1]
            v2_mut = v212.fields[2]
            v3_mut = v212.fields[3]
            v4_mut = v212.fields[4]
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
        v66: US8
        if "" == v1:
            v66 = US8(1, "parsing.any_char / unexpected end of input / " + method41(v2, v3, v4))

        else: 
            v14_1: str = v1[0]
            v48: int = (len(v1) - 1) or 0
            v50: str = v1[1:v48 + 1]
            v56: str = v14_1
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v56), False, 2), v56, int64(0)), v2, v3, v4)
            v66 = US8(0, v14_1, v50, pattern_input[0], pattern_input[1], pattern_input[2])

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


def method22(v0: str) -> US7:
    _v0: (str | None) | None = None
    _v0 = some(v0)
    def _arrow271(__unit: None=None, v0: Any=v0) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v10: str = default_arg(_arrow271() if (_v0 is None) else value_12(_v0), "")
    v16_1: Any = StringBuilder__ctor_Z721C83C5(method23())
    def v19(_arg10: tuple[str, Any, int, int], v0: Any=v0) -> US8:
        return closure14(None, _arg10)

    def v20(_arg10_1: tuple[str, Any, int, int], v0: Any=v0) -> US8:
        return closure16(None, _arg10_1)

    v24: US8 = method29(v10, v16_1, UH1(1, v19, UH1(1, v20, UH1(0))))
    v280: US9
    if v24.tag == 0:
        v29: int = v24.fields[4] or 0
        v28: int = v24.fields[3] or 0
        v27: Any = v24.fields[2]
        v26: str = v24.fields[1]
        v201: US8
        if "" == v26:
            v201 = US8(1, "parsing.none_of / unexpected end of input / " + method31(method30(to_array(of_array(["\"", "\'"]))), v27, v28, v29))

        else: 
            v88: str = v26[0]
            if method32(v88, int64(0)) == False:
                v125: int = (len(v26) - 1) or 0
                v127: str = v26[1:v125 + 1]
                v133: str = v88
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v133), False, 2), v133, int64(0)), v27, v28, v29)
                v201 = US8(0, v88, v127, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v201 = US8(1, "parsing.none_of / unexpected char / " + method33(v88, method30(to_array(of_array(["\"", "\'"]))), v27, v28, v29))


        v213: US8
        if v201.tag == 0:
            v202: str = v201.fields[0]
            v213 = US8(0, "/" if ("\\" == v202) else v202, v201.fields[1], v201.fields[2], v201.fields[3], v201.fields[4])

        else: 
            v213 = US8(1, v201.fields[0])

        v233: US9
        if v213.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method34(v213.fields[0], v213.fields[1], v213.fields[2], v213.fields[3], v213.fields[4])
            v233 = US9(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v233 = US9(1, v213.fields[0])

        v243: US9 = US9(0, v233.fields[0], v233.fields[1], v233.fields[2], v233.fields[3], v233.fields[4]) if (v233.tag == 0) else US9(0, "", v26, v27, v28, v29)
        if v243.tag == 0:
            v248: int = v243.fields[4] or 0
            v247: int = v243.fields[3] or 0
            v246: Any = v243.fields[2]
            v245: str = v243.fields[1]
            v252: US8 = method35(v245, v246, v247, v248, UH1(1, v19, UH1(1, v20, UH1(0))))
            v280 = US9(0, v243.fields[0], v252.fields[1], v252.fields[2], v252.fields[3], v252.fields[4]) if (v252.tag == 0) else US9(1, "parsing.between / expected closing delimiter / " + method36(v252.fields[0], v10, v16_1, 1, 1, v26, v27, v28, v29, v245, v246, v247, v248))

        else: 
            v280 = US9(1, "parsing.between / expected content")


    else: 
        v280 = US9(1, v24.fields[0])

    v602: US9
    if v280.tag == 0:
        v602 = v280

    else: 
        v488: US8
        if "" == v10:
            v488 = US8(1, "parsing.none_of / unexpected end of input / " + method31(method30(to_array(of_array(["\"", "\'", " "]))), v16_1, 1, 1))

        else: 
            v359: str = v10[0]
            if method37(v359, int64(0)) == False:
                v396: int = (len(v10) - 1) or 0
                v398: str = v10[1:v396 + 1]
                v404: str = v359
                pattern_input_2: tuple[Any, int, int] = method26(method25(from_integer(len(v404), False, 2), v404, int64(0)), v16_1, 1, 1)
                v488 = US8(0, v359, v398, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

            else: 
                v488 = US8(1, "parsing.none_of / unexpected char / " + method33(v359, method30(to_array(of_array(["\"", "\'", " "]))), v16_1, 1, 1))


        v500: US8
        if v488.tag == 0:
            v489: str = v488.fields[0]
            v500 = US8(0, "/" if ("\\" == v489) else v489, v488.fields[1], v488.fields[2], v488.fields[3], v488.fields[4])

        else: 
            v500 = US8(1, v488.fields[0])

        v520: US9
        if v500.tag == 0:
            pattern_input_3: tuple[str, str, Any, int, int] = method38(v500.fields[0], v500.fields[1], v500.fields[2], v500.fields[3], v500.fields[4])
            v520 = US9(0, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2], pattern_input_3[3], pattern_input_3[4])

        else: 
            v520 = US9(1, v500.fields[0])

        if v520.tag == 0:
            v602 = v520

        else: 
            v538: US11 = US11(0, v10, v16_1, 1, 1) if (len(v10) == 0) else US11(1, "parsing.eof / expected end of input / " + method39(v10))
            v547: US9 = US9(0, "", v538.fields[0], v538.fields[1], v538.fields[2], v538.fields[3]) if (v538.tag == 0) else US9(1, v538.fields[0])
            if v547.tag == 0:
                v549: str = v547.fields[1]
                v554: int = method40(v549, 0) or 0
                v588: int = (len(v549) - 1) or 0
                v602 = US9(0, v547.fields[0], v549[v554:v588 + 1], v547.fields[2], v547.fields[3], v547.fields[4])

            else: 
                v602 = US9(1, v547.fields[0])



    v900: US12
    if v602.tag == 0:
        v607: int = v602.fields[4] or 0
        v606: int = v602.fields[3] or 0
        v605: Any = v602.fields[2]
        v604: str = v602.fields[1]
        v771: US8
        if "" == v604:
            v771 = US8(1, "parsing.p_char / unexpected end of input / " + method24(" ", v605, v606, v607))

        else: 
            v618: str = v604[0]
            if v618 == " ":
                v653: int = (len(v604) - 1) or 0
                v655: str = v604[1:v653 + 1]
                v661: str = v618
                pattern_input_4: tuple[Any, int, int] = method26(method25(from_integer(len(v661), False, 2), v661, int64(0)), v605, v606, v607)
                v771 = US8(0, v618, v655, pattern_input_4[0], pattern_input_4[1], pattern_input_4[2])

            else: 
                v678: int = (v604.find("\n") - 1) or 0
                v716: int = (((len(v604) + 1) if (-2 == v678) else (v678 + 1)) - 1) or 0
                v718: str = v604[0:v716 + 1]
                v771 = US8(1, (((((("parsing.p_char / " + method27(" ", v606, v607)) + "\n") + to_string_1(v605)) + v718) + "\n") + (method28(v607 - 1, 0)("") + "^")) + "\n")


        v783: US13 = US13(0, US10(0, v771.fields[0]), v771.fields[1], v771.fields[2], v771.fields[3], v771.fields[4]) if (v771.tag == 0) else US13(0, US10(1), v604, v605, v606, v607)
        v874: US9
        if v783.tag == 0:
            v788: int = v783.fields[4] or 0
            v787: int = v783.fields[3] or 0
            v786: Any = v783.fields[2]
            v785: str = v783.fields[1]
            v850: US8
            if "" == v785:
                v850 = US8(1, "parsing.any_char / unexpected end of input / " + method41(v786, v787, v788))

            else: 
                v798: str = v785[0]
                v832: int = (len(v785) - 1) or 0
                v834: str = v785[1:v832 + 1]
                v840: str = v798
                pattern_input_5: tuple[Any, int, int] = method26(method25(from_integer(len(v840), False, 2), v840, int64(0)), v786, v787, v788)
                v850 = US8(0, v798, v834, pattern_input_5[0], pattern_input_5[1], pattern_input_5[2])

            if v850.tag == 0:
                pattern_input_6: tuple[str, str, Any, int, int] = method42(v850.fields[0], v850.fields[1], v850.fields[2], v850.fields[3], v850.fields[4])
                v874 = US9(0, pattern_input_6[0], pattern_input_6[1], pattern_input_6[2], pattern_input_6[3], pattern_input_6[4])

            else: 
                v874 = US9(1, v850.fields[0])


        else: 
            v874 = US9(1, v783.fields[0])

        v886: US14 = US14(0, US5(0, v874.fields[0]), v874.fields[1], v874.fields[2], v874.fields[3], v874.fields[4]) if (v874.tag == 0) else US14(0, US5(1), v604, v605, v606, v607)
        v900 = US12(0, v602.fields[0], v886.fields[0], v886.fields[1], v886.fields[2], v886.fields[3], v886.fields[4]) if (v886.tag == 0) else US12(1, v886.fields[0])

    else: 
        v900 = US12(1, v602.fields[0])

    if v900.tag == 0:
        return US7(0, v900.fields[0], v900.fields[1])

    else: 
        return US7(1, v900.fields[0])



def method43(__unit: None=None) -> str:
    v133: str = "Debug".lower()
    return ("\u001b[94m" + method12(v133[0])) + "\u001b[0m"


def method45(v0: str, v1: US5, v2: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None, v9: bool) -> str:
    v11: Mut3 = Mut3(method13())
    v25: None
    closure7(v11, "{ ", None)
    v25 = None
    v44: None
    closure7(v11, "file_name", None)
    v44 = None
    v63: None
    closure7(v11, " = ", None)
    v63 = None
    v80: None
    closure7(v11, v0, None)
    v80 = None
    v99: None
    closure7(v11, "; ", None)
    v99 = None
    v118: None
    closure7(v11, "arguments", None)
    v118 = None
    v135: None
    closure7(v11, " = ", None)
    v135 = None
    v156: None
    closure7(v11, to_text(interpolate("%A%P()", [v1])), None)
    v156 = None
    v173: None
    closure7(v11, "; ", None)
    v173 = None
    v192: None
    closure7(v11, "options", None)
    v192 = None
    v209: None
    closure7(v11, " = ", None)
    v209 = None
    v226: None
    closure7(v11, "{ ", None)
    v226 = None
    v245: None
    closure7(v11, "command", None)
    v245 = None
    v262: None
    closure7(v11, " = ", None)
    v262 = None
    v279: None
    closure7(v11, v2, None)
    v279 = None
    v296: None
    closure7(v11, "; ", None)
    v296 = None
    v315: None
    closure7(v11, "cancellation_token", None)
    v315 = None
    v332: None
    closure7(v11, " = ", None)
    v332 = None
    v391: None
    closure7(v11, to_text(interpolate("%A%P()", [v3])), None)
    v391 = None
    v408: None
    closure7(v11, "; ", None)
    v408 = None
    v427: None
    closure7(v11, "environment_variables", None)
    v427 = None
    v444: None
    closure7(v11, " = ", None)
    v444 = None
    v466: None
    closure7(v11, to_text(interpolate("%A%P()", [v4])), None)
    v466 = None
    v483: None
    closure7(v11, "; ", None)
    v483 = None
    v502: None
    closure7(v11, "on_line", None)
    v502 = None
    v519: None
    closure7(v11, " = ", None)
    v519 = None
    v578: None
    closure7(v11, to_text(interpolate("%A%P()", [v5])), None)
    v578 = None
    v595: None
    closure7(v11, "; ", None)
    v595 = None
    v614: None
    closure7(v11, "stdin", None)
    v614 = None
    v631: None
    closure7(v11, " = ", None)
    v631 = None
    v690: None
    closure7(v11, to_text(interpolate("%A%P()", [v6])), None)
    v690 = None
    v707: None
    closure7(v11, "; ", None)
    v707 = None
    v726: None
    closure7(v11, "trace", None)
    v726 = None
    v743: None
    closure7(v11, " = ", None)
    v743 = None
    v763: None
    closure7(v11, "true" if v7 else "false", None)
    v763 = None
    v780: None
    closure7(v11, "; ", None)
    v780 = None
    v799: None
    closure7(v11, "working_directory", None)
    v799 = None
    v816: None
    closure7(v11, " = ", None)
    v816 = None
    v875: None
    closure7(v11, to_text(interpolate("%A%P()", [v8])), None)
    v875 = None
    v892: None
    closure7(v11, "; ", None)
    v892 = None
    v911: None
    closure7(v11, "stderr", None)
    v911 = None
    v928: None
    closure7(v11, " = ", None)
    v928 = None
    v948: None
    closure7(v11, "true" if v9 else "false", None)
    v948 = None
    v967: None
    closure7(v11, " }", None)
    v967 = None
    v984: None
    closure7(v11, " }", None)
    v984 = None
    return v11.l0


def method44(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: US5, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14_1: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15_1: bool, v16_1: str | None, v17: bool) -> str:
    v18: str = method45(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1, v17)
    return method16((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v18)


def closure17(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: US5, v9: str, unit_var: None) -> None:
    def v25(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, v9: Any=v9, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v26: None
    v25(None)
    v26 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v67: US0 = pattern_input[4].l0
    v307: US6
    class ObjectExpr289:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v67, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr289())))) == False:
        v307 = US6(1)

    else: 
        v90: None
        v25(None)
        v90 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v118: int64 | None = pattern_input_1[5]
        v117: Mut4 = pattern_input_1[4]
        v116: Mut3 = pattern_input_1[3]
        v115: Mut2 = pattern_input_1[2]
        v114: Mut1 = pattern_input_1[1]
        v113: Mut0 = pattern_input_1[0]
        v133: str = method44(v113, v114, v115, v116, v117, v118, method7(v113, v114, v115, v116, v117, v118), method43(), v9, v8, v0, v1, v2, v3, v4, v5, v6, v7)
        v149: None
        v25(None)
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



def method46(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool) -> Array[tuple[str, str]]:
    return v2


def method47(v0: int, v1: Mut5) -> bool:
    return v1.l0 < v0


def method50(v0: bool) -> str:
    return None


def closure19(unit_var: None, v0: Callable[[tuple[int, str, bool]], Async[None]]) -> US15:
    return US15(0, v0)


def method51(__unit: None=None) -> Callable[[Callable[[tuple[int, str, bool]], Async[None]]], US15]:
    def _arrow290(v: Callable[[tuple[int, str, bool]], Async[None]]) -> US15:
        return closure19(None, v)

    return _arrow290


def method52(v0: bool) -> int:
    return None


def method53(__unit: None=None) -> str:
    v133: str = "Verbose".lower()
    return ("\u001b[90m" + method12(v133[0])) + "\u001b[0m"


def method54(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v9: str = method15()
    return method16((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + v8) + " / ") + v9)


def closure20(v0: str, unit_var: None) -> None:
    def v16_1(__unit: None=None, v0: Any=v0, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v17: None
    v16_1(None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v58: US0 = pattern_input[4].l0
    v301: US6
    class ObjectExpr291:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (0 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr291())))) == False:
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



def method49(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: bool, v9: Any, v10: bool, v11: bool) -> Async[None]:
    def _arrow301(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, v9: Any=v9, v10: Any=v10, v11: Any=v11) -> Async[None]:
        v27514: str = method50(v11)
        v27520: bool = (v27514 is None) != True
        def _arrow299(__unit: None=None) -> Async[None]:
            v27545: US15 = default_arg(map(method51(), v3), US15(1))
            def _arrow293(__unit: None=None) -> Async[None]:
                v27551: Async[None] = v27545.fields[0]((method52(v8), v27514, v10))
                def _arrow292(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v27551, _arrow292)

            def _expr294():
                return singleton.Zero()

            def _arrow298(__unit: None=None) -> Async[None]:
                v27554: str = concat("! ", *v27514) if v10 else concat("> ", *v27514)
                def _arrow295(__unit: None=None) -> Async[None]:
                    v27871: None
                    closure20(v27554, None)
                    v27871 = None
                    return singleton.Zero()

                def _arrow296(__unit: None=None) -> Async[None]:
                    v28192: None
                    closure10(v27554, None)
                    v28192 = None
                    return singleton.Zero()

                def _arrow297(__unit: None=None) -> Async[None]:
                    v28200: str = concat("\u001b[7;4m" if v10 else "", v27514, *"\u001b[0m" if v10 else "")
                    return singleton.Zero()

                return singleton.Combine(_arrow295() if v5 else _arrow296(), singleton.Delay(_arrow297))

            return singleton.Combine(_arrow293() if (v27545.tag == 0) else _expr294(), singleton.Delay(_arrow298))

        def _arrow300(__unit: None=None) -> Async[None]:
            return singleton.Zero()

        return singleton.Combine(_arrow299() if v27520 else singleton.Zero(), singleton.Delay(_arrow300))

    return singleton.Delay(_arrow301)


def method48(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: bool, v9: Any, v10: bool, v11: bool) -> Async[None]:
    return method49(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11)


def closure18(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: bool, v9: Any, v10: bool, v11: bool) -> None:
    start_immediate(method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11))


def closure21(unit_var: None, v0: CancellationToken) -> US16:
    return US16(0, v0)


def method55(__unit: None=None) -> Callable[[CancellationToken], US16]:
    def _arrow302(v: CancellationToken) -> US16:
        return closure21(None, v)

    return _arrow302


def method57(v0: CancellationToken) -> Async[CancellationToken]:
    def _arrow303(__unit: None=None, v0: Any=v0) -> Async[CancellationToken]:
        return singleton.Return(None)

    return singleton.Delay(_arrow303)


def method56(v0: CancellationToken) -> Async[CancellationToken]:
    return method57(v0)


def method58(v0: bool) -> bool:
    return None


def method59(v0: bool) -> None:
    pass


def closure22(v0: bool, unit_var: None) -> None:
    if method58(v0) == False:
        method59(v0)



def method62(v0: Any) -> str:
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


def method61(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: Any) -> str:
    v9: str = method62(v8)
    return method16((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.execute_with_options_async / WaitForExitAsync") + " / ") + v9)


def closure23(v0: Any, unit_var: None) -> None:
    def v16_1(__unit: None=None, v0: Any=v0, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v17: None
    v16_1(None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v58: US0 = pattern_input[4].l0
    v298: US6
    class ObjectExpr304:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr304())))) == False:
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
        v124: str = method61(v104, v105, v106, v107, v108, v109, method7(v104, v105, v106, v107, v108, v109), method11(), v0)
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



def method60(v0: bool, v1: Any, v2: CancellationToken) -> Async[int]:
    def _arrow308(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[int]:
        def _arrow306(__unit: None=None) -> Async[int]:
            v94280: Async[None] = await_task(None)
            def _arrow305(__unit: None=None) -> Async[int]:
                return singleton.Return(None)

            return singleton.Bind(v94280, _arrow305)

        def _arrow307(_arg_1: Exception) -> Async[int]:
            v95113: Exception = _arg_1
            v95136: str = to_text(interpolate("%A%P()", [v95113]))
            v95472: None
            closure23(v95113, None)
            v95472 = None
            return singleton.Return(-2147483648)

        return singleton.TryWith(singleton.Delay(_arrow306), _arrow307)

    return singleton.Delay(_arrow308)


def method63(__unit: None=None) -> str:
    return "\n"


def method65(v0: int, v1: int, v2: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None, v9: bool) -> str:
    v11: Mut3 = Mut3(method13())
    v25: None
    closure7(v11, "{ ", None)
    v25 = None
    v44: None
    closure7(v11, "exit_code", None)
    v44 = None
    v63: None
    closure7(v11, " = ", None)
    v63 = None
    v83: None
    closure7(v11, ("" + str(v0)) + "", None)
    v83 = None
    v102: None
    closure7(v11, "; ", None)
    v102 = None
    v121: None
    closure7(v11, "output_length", None)
    v121 = None
    v138: None
    closure7(v11, " = ", None)
    v138 = None
    v158: None
    closure7(v11, ("" + str(v1)) + "", None)
    v158 = None
    v175: None
    closure7(v11, "; ", None)
    v175 = None
    v194: None
    closure7(v11, "options", None)
    v194 = None
    v211: None
    closure7(v11, " = ", None)
    v211 = None
    v228: None
    closure7(v11, "{ ", None)
    v228 = None
    v247: None
    closure7(v11, "command", None)
    v247 = None
    v264: None
    closure7(v11, " = ", None)
    v264 = None
    v281: None
    closure7(v11, v2, None)
    v281 = None
    v298: None
    closure7(v11, "; ", None)
    v298 = None
    v317: None
    closure7(v11, "cancellation_token", None)
    v317 = None
    v334: None
    closure7(v11, " = ", None)
    v334 = None
    v393: None
    closure7(v11, to_text(interpolate("%A%P()", [v3])), None)
    v393 = None
    v410: None
    closure7(v11, "; ", None)
    v410 = None
    v429: None
    closure7(v11, "environment_variables", None)
    v429 = None
    v446: None
    closure7(v11, " = ", None)
    v446 = None
    v468: None
    closure7(v11, to_text(interpolate("%A%P()", [v4])), None)
    v468 = None
    v485: None
    closure7(v11, "; ", None)
    v485 = None
    v504: None
    closure7(v11, "on_line", None)
    v504 = None
    v521: None
    closure7(v11, " = ", None)
    v521 = None
    v580: None
    closure7(v11, to_text(interpolate("%A%P()", [v5])), None)
    v580 = None
    v597: None
    closure7(v11, "; ", None)
    v597 = None
    v616: None
    closure7(v11, "stdin", None)
    v616 = None
    v633: None
    closure7(v11, " = ", None)
    v633 = None
    v692: None
    closure7(v11, to_text(interpolate("%A%P()", [v6])), None)
    v692 = None
    v709: None
    closure7(v11, "; ", None)
    v709 = None
    v728: None
    closure7(v11, "trace", None)
    v728 = None
    v745: None
    closure7(v11, " = ", None)
    v745 = None
    v765: None
    closure7(v11, "true" if v7 else "false", None)
    v765 = None
    v782: None
    closure7(v11, "; ", None)
    v782 = None
    v801: None
    closure7(v11, "working_directory", None)
    v801 = None
    v818: None
    closure7(v11, " = ", None)
    v818 = None
    v877: None
    closure7(v11, to_text(interpolate("%A%P()", [v8])), None)
    v877 = None
    v894: None
    closure7(v11, "; ", None)
    v894 = None
    v913: None
    closure7(v11, "stderr", None)
    v913 = None
    v930: None
    closure7(v11, " = ", None)
    v930 = None
    v950: None
    closure7(v11, "true" if v9 else "false", None)
    v950 = None
    v969: None
    closure7(v11, " }", None)
    v969 = None
    v986: None
    closure7(v11, " }", None)
    v986 = None
    return v11.l0


def method64(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: int, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14_1: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15_1: bool, v16_1: str | None, v17: bool) -> str:
    v18: str = method65(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1, v17)
    return method16((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v18)


def closure24(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: int, v9: str, unit_var: None) -> None:
    def v25(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, v9: Any=v9, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v26: None
    v25(None)
    v26 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v67: US0 = pattern_input[4].l0
    v308: US6
    class ObjectExpr309:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v67, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr309())))) == False:
        v308 = US6(1)

    else: 
        v90: None
        v25(None)
        v90 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v118: int64 | None = pattern_input_1[5]
        v117: Mut4 = pattern_input_1[4]
        v116: Mut3 = pattern_input_1[3]
        v115: Mut2 = pattern_input_1[2]
        v114: Mut1 = pattern_input_1[1]
        v113: Mut0 = pattern_input_1[0]
        v134: str = method64(v113, v114, v115, v116, v117, v118, method7(v113, v114, v115, v116, v117, v118), method43(), v8, len(v9), v0, v1, v2, v3, v4, v5, v6, v7)
        v150: None
        v25(None)
        v150 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v174: Mut1 = pattern_input_2[1]
        v173: Mut0 = pattern_input_2[0]
        v195: None
        closure8(v173, None)
        v195 = None
        closure9(None, v134)
        v174.l0(v134)
        v308 = US6(0, v173, v174, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method21(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool) -> Async[tuple[int, str]]:
    def _arrow310(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7) -> Async[tuple[int, str]]:
        pattern_input: tuple[int, str] = None
        return singleton.Return((pattern_input[0], pattern_input[1]))

    return singleton.Delay(_arrow310)


def method20(v0: str, v1: CancellationToken | None, v2: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool) -> Async[tuple[int, str]]:
    return method21(v0, v1, v2, v3, v4, v5, v6, v7)


def method19(v0: str) -> Async[tuple[int, str]]:
    return method20(v0, None, [], None, None, True, None, True)


def closure13(unit_var: None, v0: str) -> Async[tuple[int, str]]:
    return method19(v0)


def closure25(unit_var: None, _arg: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None, bool]) -> Async[tuple[int, str]]:
    return method20(_arg[0], _arg[1], _arg[2], _arg[3], _arg[4], _arg[5], _arg[6], _arg[7])


def closure26(unit_var: None, v0: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None, bool]:
    v20: Heap0 = v0(Heap0("", None, [], None, None, True, None, True))
    return (v20.l0, v20.l1, v20.l2, v20.l3, v20.l4, v20.l5, v20.l6, v20.l7)


def method68(v0_mut: str, v1_mut: int64) -> bool:
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




            def _arrow311(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v19.fields[0] if (v19.tag == 0) else _arrow311()):
                return True

            else: 
                v0_mut = v0
                v1_mut = op_addition(v1, int64(1))
                continue


        break


def method69(v0_mut: str, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v224: US8
        if "" == v1:
            v224 = US8(1, "parsing.none_of / unexpected end of input / " + method31(method30(to_array(of_array(["\\", "`", "\"", " "]))), v2, v3, v4))

        else: 
            v87: str = v1[0]
            if method68(v87, int64(0)) == False:
                v124: int = (len(v1) - 1) or 0
                v126: str = v1[1:v124 + 1]
                v132: str = v87
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v132), False, 2), v132, int64(0)), v2, v3, v4)
                v224 = US8(0, v87, v126, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v224 = US8(1, "parsing.none_of / unexpected char / " + method33(v87, method30(to_array(of_array(["\\", "`", "\"", " "]))), v2, v3, v4))


        if v224.tag == 0:
            v0_mut = v0 + v224.fields[0]
            v1_mut = v224.fields[1]
            v2_mut = v224.fields[2]
            v3_mut = v224.fields[3]
            v4_mut = v224.fields[4]
            continue

        else: 
            return (v0, v1, v2, v3, v4)

        break


def method71(v0_mut: str, v1_mut: int64) -> bool:
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



            def _arrow312(__unit: None=None, v0: Any=v0, v1: Any=v1) -> str:
                raise Exception("Option does not have a value.")

            if v0 == (v15_1.fields[0] if (v15_1.tag == 0) else _arrow312()):
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
    v168: US8
    if "" == v0:
        v168 = US8(1, "parsing.p_char / unexpected end of input / " + method24("\\", v1, v2, v3))

    else: 
        v14_1: str = v0[0]
        if v14_1 == "\\":
            v49: int = (len(v0) - 1) or 0
            v51: str = v0[1:v49 + 1]
            v57: str = v14_1
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v57), False, 2), v57, int64(0)), v1, v2, v3)
            v168 = US8(0, v14_1, v51, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v74: int = (v0.find("\n") - 1) or 0
            v112: int = (((len(v0) + 1) if (-2 == v74) else (v74 + 1)) - 1) or 0
            v114: str = v0[0:v112 + 1]
            v168 = US8(1, (((((("parsing.p_char / " + method27("\\", v2, v3)) + "\n") + to_string_1(v1)) + v114) + "\n") + (method28(v3 - 1, 0)("") + "^")) + "\n")


    v239: US8
    if v168.tag == 0:
        v173: int = v168.fields[4] or 0
        v172: int = v168.fields[3] or 0
        v171: Any = v168.fields[2]
        v170: str = v168.fields[1]
        if "" == v170:
            v239 = US8(1, "parsing.any_char / unexpected end of input / " + method41(v171, v172, v173))

        else: 
            v183: str = v170[0]
            v217: int = (len(v170) - 1) or 0
            v219: str = v170[1:v217 + 1]
            v225: str = v183
            pattern_input_1: tuple[Any, int, int] = method26(method25(from_integer(len(v225), False, 2), v225, int64(0)), v171, v172, v173)
            v239 = US8(0, v183, v219, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v239 = US8(1, v168.fields[0])

    if v239.tag == 0:
        return US9(0, "\\" + v239.fields[0], v239.fields[1], v239.fields[2], v239.fields[3], v239.fields[4])

    else: 
        return US9(1, v239.fields[0])



def closure29(unit_var: None, _arg: tuple[str, Any, int, int]) -> US9:
    v3: int = _arg[3] or 0
    v2: int = _arg[2] or 0
    v1: Any = _arg[1]
    v0: str = _arg[0]
    v168: US8
    if "" == v0:
        v168 = US8(1, "parsing.p_char / unexpected end of input / " + method24("`", v1, v2, v3))

    else: 
        v14_1: str = v0[0]
        if v14_1 == "`":
            v49: int = (len(v0) - 1) or 0
            v51: str = v0[1:v49 + 1]
            v57: str = v14_1
            pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v57), False, 2), v57, int64(0)), v1, v2, v3)
            v168 = US8(0, v14_1, v51, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v74: int = (v0.find("\n") - 1) or 0
            v112: int = (((len(v0) + 1) if (-2 == v74) else (v74 + 1)) - 1) or 0
            v114: str = v0[0:v112 + 1]
            v168 = US8(1, (((((("parsing.p_char / " + method27("`", v2, v3)) + "\n") + to_string_1(v1)) + v114) + "\n") + (method28(v3 - 1, 0)("") + "^")) + "\n")


    v239: US8
    if v168.tag == 0:
        v173: int = v168.fields[4] or 0
        v172: int = v168.fields[3] or 0
        v171: Any = v168.fields[2]
        v170: str = v168.fields[1]
        if "" == v170:
            v239 = US8(1, "parsing.any_char / unexpected end of input / " + method41(v171, v172, v173))

        else: 
            v183: str = v170[0]
            v217: int = (len(v170) - 1) or 0
            v219: str = v170[1:v217 + 1]
            v225: str = v183
            pattern_input_1: tuple[Any, int, int] = method26(method25(from_integer(len(v225), False, 2), v225, int64(0)), v171, v172, v173)
            v239 = US8(0, v183, v219, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v239 = US8(1, v168.fields[0])

    if v239.tag == 0:
        return US9(0, "`" + v239.fields[0], v239.fields[1], v239.fields[2], v239.fields[3], v239.fields[4])

    else: 
        return US9(1, v239.fields[0])



def method72(v0_mut: str, v1_mut: Any, v2_mut: int, v3_mut: int, v4_mut: UH3) -> US9:
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


def method73(v0_mut: UH2, v1_mut: UH2) -> UH2:
    while True:
        (v0, v1) = (v0_mut, v1_mut)
        if v0.tag == 0:
            return v1

        else: 
            v0_mut = v0.fields[1]
            v1_mut = UH2(1, v0.fields[0], v1)
            continue

        break


def method70(v0_mut: UH2, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v200: US8
        if "" == v1:
            v200 = US8(1, "parsing.none_of / unexpected end of input / " + method31(method30(to_array(of_array(["\\", "`", "\""]))), v2, v3, v4))

        else: 
            v75: str = v1[0]
            if method71(v75, int64(0)) == False:
                v112: int = (len(v1) - 1) or 0
                v114: str = v1[1:v112 + 1]
                v120: str = v75
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v120), False, 2), v120, int64(0)), v2, v3, v4)
                v200 = US8(0, v75, v114, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v200 = US8(1, "parsing.none_of / unexpected char / " + method33(v75, method30(to_array(of_array(["\\", "`", "\""]))), v2, v3, v4))


        v215: US9 = US9(0, v200.fields[0], v200.fields[1], v200.fields[2], v200.fields[3], v200.fields[4]) if (v200.tag == 0) else US9(1, v200.fields[0])
        def v222(_arg10: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
            return closure28(None, _arg10)

        def v223(_arg10_1: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
            return closure29(None, _arg10_1)

        v229: US9 = v215 if (v215.tag == 0) else method72(v1, v2, v3, v4, UH3(1, v222, UH3(1, v223, UH3(0))))
        if v229.tag == 0:
            v0_mut = UH2(1, v229.fields[0], v0)
            v1_mut = v229.fields[1]
            v2_mut = v229.fields[2]
            v3_mut = v229.fields[3]
            v4_mut = v229.fields[4]
            continue

        else: 
            return US18(0, method73(v0, UH2(0)), v1, v2, v3, v4)

        break


def method74(v0: UH2, v1: FSharpList[str]) -> FSharpList[str]:
    if v0.tag == 0:
        return v1

    else: 
        return cons(v0.fields[0], method74(v0.fields[1], v1))



def method75(v0_mut: UH2, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v200: US8
        if "" == v1:
            v200 = US8(1, "parsing.none_of / unexpected end of input / " + method31(method30(to_array(of_array(["\\", "`", "\""]))), v2, v3, v4))

        else: 
            v75: str = v1[0]
            if method71(v75, int64(0)) == False:
                v112: int = (len(v1) - 1) or 0
                v114: str = v1[1:v112 + 1]
                v120: str = v75
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v120), False, 2), v120, int64(0)), v2, v3, v4)
                v200 = US8(0, v75, v114, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v200 = US8(1, "parsing.none_of / unexpected char / " + method33(v75, method30(to_array(of_array(["\\", "`", "\""]))), v2, v3, v4))


        v215: US9 = US9(0, v200.fields[0], v200.fields[1], v200.fields[2], v200.fields[3], v200.fields[4]) if (v200.tag == 0) else US9(1, v200.fields[0])
        if v215.tag == 0:
            v0_mut = UH2(1, v215.fields[0], v0)
            v1_mut = v215.fields[1]
            v2_mut = v215.fields[2]
            v3_mut = v215.fields[3]
            v4_mut = v215.fields[4]
            continue

        else: 
            return US18(0, method73(v0, UH2(0)), v1, v2, v3, v4)

        break


def method67(v0_mut: UH2, v1_mut: str, v2_mut: Any, v3_mut: int, v4_mut: int) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        v5: bool = "" == v1
        v224: US8
        if v5:
            v224 = US8(1, "parsing.none_of / unexpected end of input / " + method31(method30(to_array(of_array(["\\", "`", "\"", " "]))), v2, v3, v4))

        else: 
            v87: str = v1[0]
            if method68(v87, int64(0)) == False:
                v124: int = (len(v1) - 1) or 0
                v126: str = v1[1:v124 + 1]
                v132: str = v87
                pattern_input: tuple[Any, int, int] = method26(method25(from_integer(len(v132), False, 2), v132, int64(0)), v2, v3, v4)
                v224 = US8(0, v87, v126, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v224 = US8(1, "parsing.none_of / unexpected char / " + method33(v87, method30(to_array(of_array(["\\", "`", "\"", " "]))), v2, v3, v4))


        v244: US9
        if v224.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method69(v224.fields[0], v224.fields[1], v224.fields[2], v224.fields[3], v224.fields[4])
            v244 = US9(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v244 = US9(1, v224.fields[0])

        v721: US9
        if v244.tag == 0:
            v721 = v244

        else: 
            v414: US8
            if v5:
                v414 = US8(1, "parsing.p_char / unexpected end of input / " + method24("\"", v2, v3, v4))

            else: 
                v260: str = v1[0]
                if v260 == "\"":
                    v295: int = (len(v1) - 1) or 0
                    v297: str = v1[1:v295 + 1]
                    v303: str = v260
                    pattern_input_2: tuple[Any, int, int] = method26(method25(from_integer(len(v303), False, 2), v303, int64(0)), v2, v3, v4)
                    v414 = US8(0, v260, v297, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

                else: 
                    v320: int = (v1.find("\n") - 1) or 0
                    v358: int = (((len(v1) + 1) if (-2 == v320) else (v320 + 1)) - 1) or 0
                    v360: str = v1[0:v358 + 1]
                    v414 = US8(1, (((((("parsing.p_char / " + method27("\"", v3, v4)) + "\n") + to_string_1(v2)) + v360) + "\n") + (method28(v4 - 1, 0)("") + "^")) + "\n")


            v650: US9
            if v414.tag == 0:
                v419: int = v414.fields[4] or 0
                v418: int = v414.fields[3] or 0
                v417: Any = v414.fields[2]
                v416: str = v414.fields[1]
                v421: US18 = method70(UH2(0), v416, v417, v418, v419)
                v454: US9
                if v421.tag == 0:
                    v428: FSharpList[str] = method74(v421.fields[0], empty())
                    def _arrow313(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v428

                    v454 = US9(0, join("", delay(_arrow313)), v421.fields[1], v421.fields[2], v421.fields[3], v421.fields[4])

                else: 
                    v454 = US9(1, v421.fields[0])

                if v454.tag == 0:
                    v459: int = v454.fields[4] or 0
                    v458: int = v454.fields[3] or 0
                    v457: Any = v454.fields[2]
                    v456: str = v454.fields[1]
                    v624: US8
                    if "" == v456:
                        v624 = US8(1, "parsing.p_char / unexpected end of input / " + method24("\"", v457, v458, v459))

                    else: 
                        v470: str = v456[0]
                        if v470 == "\"":
                            v505: int = (len(v456) - 1) or 0
                            v507: str = v456[1:v505 + 1]
                            v513: str = v470
                            pattern_input_3: tuple[Any, int, int] = method26(method25(from_integer(len(v513), False, 2), v513, int64(0)), v457, v458, v459)
                            v624 = US8(0, v470, v507, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2])

                        else: 
                            v530: int = (v456.find("\n") - 1) or 0
                            v568: int = (((len(v456) + 1) if (-2 == v530) else (v530 + 1)) - 1) or 0
                            v570: str = v456[0:v568 + 1]
                            v624 = US8(1, (((((("parsing.p_char / " + method27("\"", v458, v459)) + "\n") + to_string_1(v457)) + v570) + "\n") + (method28(v459 - 1, 0)("") + "^")) + "\n")


                    v650 = US9(0, v454.fields[0], v624.fields[1], v624.fields[2], v624.fields[3], v624.fields[4]) if (v624.tag == 0) else US9(1, "parsing.between / expected closing delimiter / " + method36(v624.fields[0], v1, v2, v3, v4, v416, v417, v418, v419, v456, v457, v458, v459))

                else: 
                    v650 = US9(1, "parsing.between / expected content")


            else: 
                v650 = US9(1, v414.fields[0])

            if v650.tag == 0:
                v721 = v650

            else: 
                def v657(_arg10: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
                    return closure28(None, _arg10)

                def v658(_arg10_1: tuple[str, Any, int, int], v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> US9:
                    return closure29(None, _arg10_1)

                v662: US9 = method72(v1, v2, v3, v4, UH3(1, v657, UH3(1, v658, UH3(0))))
                v673: US9 = US9(0, "", v662.fields[1], v662.fields[2], v662.fields[3], v662.fields[4]) if (v662.tag == 0) else US9(1, v662.fields[0])
                v684: US18 = method75(UH2(0), v673.fields[1], v673.fields[2], v673.fields[3], v673.fields[4]) if (v673.tag == 0) else US18(1, v673.fields[0])
                if v684.tag == 0:
                    v691: FSharpList[str] = method74(v684.fields[0], empty())
                    def _arrow314(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v691

                    v721 = US9(0, join("", delay(_arrow314)), v684.fields[1], v684.fields[2], v684.fields[3], v684.fields[4])

                else: 
                    v721 = US9(1, v684.fields[0])



        if v721.tag == 0:
            v726: int = v721.fields[4] or 0
            v725: int = v721.fields[3] or 0
            v724: Any = v721.fields[2]
            v723: str = v721.fields[1]
            v722: str = v721.fields[0]
            v728: int = method40(v723, 0) or 0
            v772: US11
            if 0 == v728:
                v772 = US11(1, "parsing.spaces1 / expected at least one space")

            else: 
                v765: int = (len(v723) - 1) or 0
                v772 = US11(0, v723[v728:v765 + 1], v724, v725, v726)

            if v772.tag == 0:
                v0_mut = UH2(1, v722, v0)
                v1_mut = v772.fields[0]
                v2_mut = v772.fields[1]
                v3_mut = v772.fields[2]
                v4_mut = v772.fields[3]
                continue

            else: 
                return US18(0, method73(v0, UH2(1, v722, UH2(0))), v723, v724, v725, v726)


        else: 
            return US18(0, method73(v0, UH2(0)), v1, v2, v3, v4)

        break


def method66(v0: str) -> US17:
    _v0: (str | None) | None = None
    _v0 = some(v0)
    def _arrow315(__unit: None=None, v0: Any=v0) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v22: US18 = method67(UH2(0), default_arg(_arrow315() if (_v0 is None) else value_12(_v0), ""), StringBuilder__ctor_Z721C83C5(method23()), 1, 1)
    if v22.tag == 0:
        return US17(0, to_array(method74(v22.fields[0], empty())))

    else: 
        return US17(1, v22.fields[0])



def closure27(unit_var: None, v0: str) -> FSharpResult_2[Array[str], str]:
    v1: US17 = method66(v0)
    if v1.tag == 0:
        return FSharpResult_2(0, v1.fields[0])

    else: 
        return FSharpResult_2(1, v1.fields[0])



v14: None = None

def _arrow316(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow316

def _expr317():
    v15(None)
    return v14


v16: None = _expr317()

def _arrow318(__unit: None=None) -> None:
    closure3(None, None)


v31: Callable[[], None] = _arrow318

def current_process_kill(__unit: None=None) -> None:
    v31(None)


def _arrow319(v: str) -> Async[tuple[int, str]]:
    return closure13(None, v)


v32: Callable[[str], Async[tuple[int, str]]] = _arrow319

def execute_async(x: str) -> Async[tuple[int, str]]:
    return v32(x)


def _arrow320(_arg10: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None, bool]) -> Async[tuple[int, str]]:
    return closure25(None, _arg10)


v33: Callable[[tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None, bool]], Async[tuple[int, str]]] = _arrow320

def execute_with_options_async(x: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None, bool]) -> Async[tuple[int, str]]:
    return v33(x)


def _arrow321(v: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None, bool]:
    return closure26(None, v)


v34: Callable[[Callable[[Heap0], Heap0]], tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None, bool]] = _arrow321

def execution_options(x: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None, bool]:
    return v34(x)


def _arrow322(v: str) -> FSharpResult_2[Array[str], str]:
    return closure27(None, v)


v35: Callable[[str], FSharpResult_2[Array[str], str]] = _arrow322

def split_args(x: str) -> FSharpResult_2[Array[str], str]:
    return v35(x)


