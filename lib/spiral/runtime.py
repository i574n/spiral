from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.async_ import (start_immediate, await_task)
from fable_modules.fable_library.async_builder import (Async, CancellationToken, singleton)
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.list import (to_array, empty, of_array, cons, FSharpList)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition, to_int, from_integer)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_12, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type, char_type, class_type, int32_type, tuple_type, option_type, array_type)
from fable_modules.fable_library.result import FSharpResult_2
from fable_modules.fable_library.seq import delay
from fable_modules.fable_library.string_ import (trim_end, trim_start, to_text, interpolate, concat, join)
from fable_modules.fable_library.system_text import (StringBuilder__Clear, StringBuilder__Append_Z721C83C5, StringBuilder__ctor_Z721C83C5)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Array, Union, Record)
from fable_modules.fable_library.util import (create_atom, to_enumerable, compare, IEnumerable_1)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


def _expr212() -> TypeInfo:
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


US0_reflection = _expr212

def _expr213() -> TypeInfo:
    return record_type("Runtime.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr213

def _expr214() -> TypeInfo:
    return record_type("Runtime.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr214

def _expr215() -> TypeInfo:
    return record_type("Runtime.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr215

def _expr216() -> TypeInfo:
    return record_type("Runtime.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr216

def _expr217() -> TypeInfo:
    return record_type("Runtime.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr217

def _expr218() -> TypeInfo:
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


US1_reflection = _expr218

def _expr219() -> TypeInfo:
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


US2_reflection = _expr219

def _expr220() -> TypeInfo:
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


US3_reflection = _expr220

def _expr221() -> TypeInfo:
    return union_type("Runtime.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5"]


US4_reflection = _expr221

def _expr222() -> TypeInfo:
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


US5_reflection = _expr222

def _expr223() -> TypeInfo:
    return union_type("Runtime.US6", [], US6, lambda: [[("f0_0", string_type), ("f0_1", US5_reflection())], [("f1_0", string_type)]])


class US6(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US6_0", "US6_1"]


US6_reflection = _expr223

def _expr224() -> TypeInfo:
    return union_type("Runtime.US7", [], US7, lambda: [[("f0_0", char_type), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US7(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US7_0", "US7_1"]


US7_reflection = _expr224

def _expr225() -> TypeInfo:
    return union_type("Runtime.UH0", [], UH0, lambda: [[], [("Item1", char_type), ("Item2", UH0_reflection())]])


class UH0(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH0_0", "UH0_1"]


UH0_reflection = _expr225

def _expr226() -> TypeInfo:
    return union_type("Runtime.UH1", [], UH1, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US7_reflection())), ("Item2", UH1_reflection())]])


class UH1(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH1_0", "UH1_1"]


UH1_reflection = _expr226

def _expr227() -> TypeInfo:
    return union_type("Runtime.US8", [], US8, lambda: [[("f0_0", string_type), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US8(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US8_0", "US8_1"]


US8_reflection = _expr227

def _expr228() -> TypeInfo:
    return union_type("Runtime.US9", [], US9, lambda: [[("f0_0", char_type)], []])


class US9(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US9_0", "US9_1"]


US9_reflection = _expr228

def _expr229() -> TypeInfo:
    return union_type("Runtime.US10", [], US10, lambda: [[("f0_0", string_type), ("f0_1", class_type("System.Text.StringBuilder")), ("f0_2", int32_type), ("f0_3", int32_type)], [("f1_0", string_type)]])


class US10(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US10_0", "US10_1"]


US10_reflection = _expr229

def _expr230() -> TypeInfo:
    return union_type("Runtime.US11", [], US11, lambda: [[("f0_0", string_type), ("f0_1", US5_reflection()), ("f0_2", string_type), ("f0_3", class_type("System.Text.StringBuilder")), ("f0_4", int32_type), ("f0_5", int32_type)], [("f1_0", string_type)]])


class US11(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US11_0", "US11_1"]


US11_reflection = _expr230

def _expr231() -> TypeInfo:
    return union_type("Runtime.US12", [], US12, lambda: [[("f0_0", US9_reflection()), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US12(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US12_0", "US12_1"]


US12_reflection = _expr231

def _expr232() -> TypeInfo:
    return union_type("Runtime.US13", [], US13, lambda: [[("f0_0", US5_reflection()), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US13(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US13_0", "US13_1"]


US13_reflection = _expr232

def _expr233() -> TypeInfo:
    return record_type("Runtime.Mut5", [], Mut5, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut5(Record):
    l0: int

Mut5_reflection = _expr233

def _expr234() -> TypeInfo:
    return union_type("Runtime.US14", [], US14, lambda: [[("f0_0", lambda_type(tuple_type(int32_type, string_type, bool_type), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [unit_type])))], []])


class US14(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US14_0", "US14_1"]


US14_reflection = _expr234

def _expr235() -> TypeInfo:
    return union_type("Runtime.US15", [], US15, lambda: [[("f0_0", class_type("System.Threading.CancellationToken"))], []])


class US15(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US15_0", "US15_1"]


US15_reflection = _expr235

def _expr236() -> TypeInfo:
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

Heap0_reflection = _expr236

def _expr237() -> TypeInfo:
    return union_type("Runtime.US16", [], US16, lambda: [[("f0_0", array_type(string_type))], [("f1_0", string_type)]])


class US16(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US16_0", "US16_1"]


US16_reflection = _expr237

def _expr238() -> TypeInfo:
    return union_type("Runtime.UH2", [], UH2, lambda: [[], [("Item1", string_type), ("Item2", UH2_reflection())]])


class UH2(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH2_0", "UH2_1"]


UH2_reflection = _expr238

def _expr239() -> TypeInfo:
    return union_type("Runtime.US17", [], US17, lambda: [[("f0_0", UH2_reflection()), ("f0_1", string_type), ("f0_2", class_type("System.Text.StringBuilder")), ("f0_3", int32_type), ("f0_4", int32_type)], [("f1_0", string_type)]])


class US17(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US17_0", "US17_1"]


US17_reflection = _expr239

def _expr240() -> TypeInfo:
    return union_type("Runtime.UH3", [], UH3, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US8_reflection())), ("Item2", UH3_reflection())]])


class UH3(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH3_0", "UH3_1"]


UH3_reflection = _expr240

def method3(v0_1: str) -> str:
    return v0_1


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0_1: str) -> US5:
    return US5(0, v0_1)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow241(v: str) -> US5:
        return closure1(None, v)

    return _arrow241


def method2(v0_1: str) -> str:
    v34: IOsEnviron = os
    v36: Any = v34.environ
    _v41: (str | None) | None = None
    x: str | None = v36.get(v0_1)
    _v41 = some(x)
    v47: str | None
    if _v41 is None:
        raise Exception("optionm\'.of_obj / _v41=None")

    else: 
        v47 = value_12(_v41)

    v68: US5 = default_arg(map(method5(), v47), US5(1))
    if v68.tag == 0:
        return v68.fields[0]

    else: 
        return ""



def method1(__unit: None=None) -> tuple[US1, US2]:
    v1_1: str = method2("TRACE_LEVEL")
    v6: str = "Critical".lower()
    v13: str = "Warning".lower()
    v20_1: str = "Info".lower()
    v27: str = "Debug".lower()
    v34: str = "Verbose".lower()
    v41: US1 = US1(0, US0(0)) if ("Verbose" == v1_1) else US1(1)
    def _arrow242(__unit: None=None) -> US1:
        v48: US1 = US1(0, US0(1)) if ("Debug" == v1_1) else US1(1)
        if v48.tag == 0:
            return US1(0, v48.fields[0])

        else: 
            v55: US1 = US1(0, US0(2)) if ("Info" == v1_1) else US1(1)
            if v55.tag == 0:
                return US1(0, v55.fields[0])

            else: 
                v62: US1 = US1(0, US0(3)) if ("Warning" == v1_1) else US1(1)
                if v62.tag == 0:
                    return US1(0, v62.fields[0])

                else: 
                    v69: US1 = US1(0, US0(4)) if ("Critical" == v1_1) else US1(1)
                    if v69.tag == 0:
                        return US1(0, v69.fields[0])

                    else: 
                        v76: US1 = US1(0, US0(0)) if (v34 == v1_1) else US1(1)
                        if v76.tag == 0:
                            return US1(0, v76.fields[0])

                        else: 
                            v83: US1 = US1(0, US0(1)) if (v27 == v1_1) else US1(1)
                            if v83.tag == 0:
                                return US1(0, v83.fields[0])

                            else: 
                                v90: US1 = US1(0, US0(2)) if (v20_1 == v1_1) else US1(1)
                                if v90.tag == 0:
                                    return US1(0, v90.fields[0])

                                else: 
                                    v97: US1 = US1(0, US0(3)) if (v13 == v1_1) else US1(1)
                                    if v97.tag == 0:
                                        return US1(0, v97.fields[0])

                                    else: 
                                        v104: US1 = US1(0, US0(4)) if (v6 == v1_1) else US1(1)
                                        return US1(0, v104.fields[0]) if (v104.tag == 0) else US1(1)









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow242(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


def closure2(unit_var: None, v0_1: str) -> None:
    pass


def method0(v0_1: US0) -> tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None]:
    pattern_input: tuple[US1, US2] = method1()
    _run_target_args_0027_v3: tuple[US1, US2] = (pattern_input[0], pattern_input[1])
    v173: US2 = _run_target_args_0027_v3[1]
    v172: US1 = _run_target_args_0027_v3[0]
    def v179(v: str, v0_1: Any=v0_1) -> None:
        closure2(None, v)

    return (Mut0(int64(1)), Mut1(v179), Mut2(True), Mut3(""), Mut4(v172.fields[0] if (v172.tag == 0) else v0_1), v173.fields[0] if (v173.tag == 0) else None)


def closure0(unit_var: None, unit_var_1: None) -> None:
    if TraceState_trace_state() is None:
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = method0(US0(0))
        TraceState_trace_state((pattern_input[0], pattern_input[1], pattern_input[2], pattern_input[3], pattern_input[4], pattern_input[5]))



def method7(v0_1: US0) -> bool:
    v3: None
    closure0(None, None)
    v3 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v42: US0 = pattern_input[4].l0
    if pattern_input[2].l0 == False:
        return False

    else: 
        class ObjectExpr243:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        class ObjectExpr244:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        return find(v0_1, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr243())) >= find(v42, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr244()))



def closure6(unit_var: None, v0_1: int64) -> US2:
    return US2(0, v0_1)


def method9(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow245(v: int64) -> US2:
        return closure6(None, v)

    return _arrow245


def method10(__unit: None=None) -> str:
    return "hh:mm:ss"


def method11(__unit: None=None) -> str:
    return "HH:mm:ss"


def method8(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v712: US2 = default_arg(map(method9(), v5), US2(1))
    v830: Any
    if v712.tag == 0:
        v782: Any = create(op_subtraction(from_value(ticks_1(now()), False), v712.fields[0]))
        v830 = create_1(1, 1, 1, hours(v782), minutes(v782), seconds(v782), milliseconds(v782))

    else: 
        v830 = now()

    v832: str = method11()
    return to_string(v830, "M-d-y hh:mm:ss tt" if (v832 == "") else v832)


def method14(__unit: None=None) -> str:
    return ""


def closure7(v0_1: Mut3, v1_1: str, unit_var: None) -> None:
    v3: str = v0_1.l0 + v1_1
    v0_1.l0 = v3


def method13(v0_1: str) -> str:
    v2_1: Mut3 = Mut3(method14())
    v9: None
    closure7(v2_1, ("" + str(v0_1)) + "", None)
    v9 = None
    return v2_1.l0


def method15(__unit: None=None) -> str:
    return "\u001b[0m"


def method12(__unit: None=None) -> str:
    v4: str = "Warning".lower()
    return ("\u001b[93m" + method13(v4[0])) + method15()


def method17(__unit: None=None) -> str:
    v1_1: Mut3 = Mut3(method14())
    return v1_1.l0


def method18(v0_1: str) -> str:
    return trim_end(trim_start(v0_1, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method16(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str) -> str:
    v8: str = method17()
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "runtime.current_process_kill / exiting... 3") + " / ") + v8) + "")


def closure8(v0_1: Mut0, unit_var: None) -> None:
    v2_1: int64 = op_addition(v0_1.l0, int64(1))
    v0_1.l0 = v2_1


def closure10(v0_1: str, unit_var: None) -> None:
    print(v0_1)


def closure9(unit_var: None, v0_1: str) -> None:
    v3: None
    closure10(v0_1, None)
    v3 = None


def method19(v0_1: str) -> None:
    v3: None
    closure0(None, None)
    v3 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
    v44: None
    closure8(pattern_input[0], None)
    v44 = None
    closure9(None, v0_1)
    pattern_input[1].l0(v0_1)


def closure5(unit_var: None, unit_var_1: None) -> None:
    if method7(US0(3)):
        v4: None
        closure0(None, None)
        v4 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v30: int64 | None = pattern_input[5]
        v29: Mut4 = pattern_input[4]
        v28: Mut3 = pattern_input[3]
        v27: Mut2 = pattern_input[2]
        v26: Mut1 = pattern_input[1]
        v25: Mut0 = pattern_input[0]
        method19(method16(v25, v26, v27, v28, v29, v30, method8(v25, v26, v27, v28, v29, v30), method12()))



def method20(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str) -> str:
    v8: str = method17()
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "runtime.current_process_kill / exiting... 2") + " / ") + v8) + "")


def closure11(unit_var: None, unit_var_1: None) -> None:
    if method7(US0(3)):
        v4: None
        closure0(None, None)
        v4 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v30: int64 | None = pattern_input[5]
        v29: Mut4 = pattern_input[4]
        v28: Mut3 = pattern_input[3]
        v27: Mut2 = pattern_input[2]
        v26: Mut1 = pattern_input[1]
        v25: Mut0 = pattern_input[0]
        method19(method20(v25, v26, v27, v28, v29, v30, method8(v25, v26, v27, v28, v29, v30), method12()))



def method21(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str) -> str:
    v8: str = method17()
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "runtime.current_process_kill / exiting... 1") + " / ") + v8) + "")


def closure12(unit_var: None, unit_var_1: None) -> None:
    if method7(US0(3)):
        v4: None
        closure0(None, None)
        v4 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v30: int64 | None = pattern_input[5]
        v29: Mut4 = pattern_input[4]
        v28: Mut3 = pattern_input[3]
        v27: Mut2 = pattern_input[2]
        v26: Mut1 = pattern_input[1]
        v25: Mut0 = pattern_input[0]
        method19(method21(v25, v26, v27, v28, v29, v30, method8(v25, v26, v27, v28, v29, v30), method12()))



def closure4(unit_var: None, unit_var_1: None) -> None:
    pass


def method6(__unit: None=None) -> None:
    pass


def closure3(unit_var: None, unit_var_1: None) -> None:
    method6()


def method26(__unit: None=None) -> str:
    return ""


def method27(v0_1: int64, v1_1: str, v2_1: int64) -> UH0:
    if v2_1 < v0_1:
        return UH0(1, v1_1[int(to_int(v2_1))], method27(v0_1, v1_1, op_addition(v2_1, int64(1))))

    else: 
        return UH0(0)



def method28(v0_1_mut: UH0, v1_1_mut: Any, v2_1_mut: int, v3_mut: int) -> tuple[Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut)
        if v0_1.tag == 0:
            return (v1_1, v2_1, v3)

        else: 
            v4: str = v0_1.fields[0]
            v6: bool = "\n" == v4
            pattern_input: tuple[int, int] = ((v2_1 + 1, 1)) if v6 else ((v2_1, v3 + 1))
            v0_1_mut = v0_1.fields[1]
            def _arrow246(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3) -> Any:
                v13: Any = StringBuilder__Clear(v1_1)
                return v1_1

            def _arrow247(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3) -> Any:
                v24: Any = StringBuilder__Append_Z721C83C5(v1_1, v4)
                return v1_1

            v1_1_mut = _arrow246() if v6 else _arrow247()
            v2_1_mut = pattern_input[0]
            v3_mut = pattern_input[1]
            continue

        break


def closure15(v0_1: int, v1_1: int, v2_1: str) -> str:
    if v1_1 >= v0_1:
        return v2_1

    else: 
        return method29(v0_1, v1_1 + 1)(v2_1 + " ")



def method29(v0_1: int, v1_1: int) -> Callable[[str], str]:
    def _arrow248(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
        return closure15(v0_1, v1_1, v)

    return _arrow248


def closure14(unit_var: None, _arg: tuple[str, Any, int, int]) -> US7:
    v3: int = _arg[3] or 0
    v2_1: int = _arg[2] or 0
    v1_1: Any = _arg[1]
    v0_1: str = _arg[0]
    if "" == v0_1:
        return US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v1_1, v2_1, v3)])))

    else: 
        v10: str = v0_1[0]
        if v10 == "\"":
            v43: int = (len(v0_1) - 1) or 0
            v45: str = v0_1[1:v43 + 1]
            v51: str = v10
            pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v51), False, 2), v51, int64(0)), v1_1, v2_1, v3)
            return US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v66: int = (v0_1.find("\n") - 1) or 0
            v102: int = (((len(v0_1) + 1) if (-2 == v66) else (v66 + 1)) - 1) or 0
            return US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v102 + 1]) + "", "\n", method29(v3 - 1, 0)("") + "^", *"\n"))




def closure16(unit_var: None, _arg: tuple[str, Any, int, int]) -> US7:
    v3: int = _arg[3] or 0
    v2_1: int = _arg[2] or 0
    v1_1: Any = _arg[1]
    v0_1: str = _arg[0]
    if "" == v0_1:
        return US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\'", (v1_1, v2_1, v3)])))

    else: 
        v10: str = v0_1[0]
        if v10 == "\'":
            v43: int = (len(v0_1) - 1) or 0
            v45: str = v0_1[1:v43 + 1]
            v51: str = v10
            pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v51), False, 2), v51, int64(0)), v1_1, v2_1, v3)
            return US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v66: int = (v0_1.find("\n") - 1) or 0
            v102: int = (((len(v0_1) + 1) if (-2 == v66) else (v66 + 1)) - 1) or 0
            return US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\'")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v102 + 1]) + "", "\n", method29(v3 - 1, 0)("") + "^", *"\n"))




def method30(v0_1_mut: str, v1_1_mut: Any, v2_1_mut: UH1) -> US7:
    while True:
        (v0_1, v1_1, v2_1) = (v0_1_mut, v1_1_mut, v2_1_mut)
        if v2_1.tag == 0:
            return US7(1, "parsing.choice / no parsers succeeded")

        else: 
            v7: US7 = v2_1.fields[0]((v0_1, v1_1, 1, 1))
            if v7.tag == 0:
                return v7

            else: 
                v0_1_mut = v0_1
                v1_1_mut = v1_1
                v2_1_mut = v2_1.fields[1]
                continue


        break


def method31(v0_1_mut: str, v1_1_mut: int64) -> bool:
    while True:
        (v0_1, v1_1) = (v0_1_mut, v1_1_mut)
        if v1_1 >= int64(2):
            return False

        else: 
            v11: US9
            if v1_1 == int64(0):
                v11 = US9(0, "\"")

            else: 
                v5: int64 = op_subtraction(v1_1, int64(1))
                if v5 == int64(0):
                    v11 = US9(0, "\'")

                else: 
                    v8: int64 = op_subtraction(v5, int64(1))
                    v11 = US9(1)


            def _arrow249(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v11.fields[0] if (v11.tag == 0) else _arrow249()):
                return True

            else: 
                v0_1_mut = v0_1
                v1_1_mut = op_addition(v1_1, int64(1))
                continue


        break


def method32(v0_1_mut: str, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v98: US7
        if "" == v1_1:
            v98 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'"])), (v2_1, v3, v4)])))

        else: 
            v25: str = v1_1[0]
            if method31(v25, int64(0)) == False:
                v60: int = (len(v1_1) - 1) or 0
                v62: str = v1_1[1:v60 + 1]
                v68: str = v25
                pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v68), False, 2), v68, int64(0)), v2_1, v3, v4)
                v98 = US7(0, v25, v62, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v98 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v25, to_array(of_array(["\"", "\'"])), (v2_1, v3, v4)])))


        v110: US7
        if v98.tag == 0:
            v99: str = v98.fields[0]
            v110 = US7(0, "/" if ("\\" == v99) else v99, v98.fields[1], v98.fields[2], v98.fields[3], v98.fields[4])

        else: 
            v110 = US7(1, v98.fields[0])

        if v110.tag == 0:
            v0_1_mut = v0_1 + v110.fields[0]
            v1_1_mut = v110.fields[1]
            v2_1_mut = v110.fields[2]
            v3_mut = v110.fields[3]
            v4_mut = v110.fields[4]
            continue

        else: 
            return (v0_1, v1_1, v2_1, v3, v4)

        break


def method33(v0_1_mut: str, v1_1_mut: Any, v2_1_mut: int, v3_mut: int, v4_mut: UH1) -> US7:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        if v4.tag == 0:
            return US7(1, "parsing.choice / no parsers succeeded")

        else: 
            v9: US7 = v4.fields[0]((v0_1, v1_1, v2_1, v3))
            if v9.tag == 0:
                return v9

            else: 
                v0_1_mut = v0_1
                v1_1_mut = v1_1
                v2_1_mut = v2_1
                v3_mut = v3
                v4_mut = v4.fields[1]
                continue


        break


def method34(v0_1_mut: str, v1_1_mut: int64) -> bool:
    while True:
        (v0_1, v1_1) = (v0_1_mut, v1_1_mut)
        if v1_1 >= int64(3):
            return False

        else: 
            v15: US9
            if v1_1 == int64(0):
                v15 = US9(0, "\"")

            else: 
                v5: int64 = op_subtraction(v1_1, int64(1))
                if v5 == int64(0):
                    v15 = US9(0, "\'")

                else: 
                    v8: int64 = op_subtraction(v5, int64(1))
                    if v8 == int64(0):
                        v15 = US9(0, " ")

                    else: 
                        v11: int64 = op_subtraction(v8, int64(1))
                        v15 = US9(1)



            def _arrow250(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v15.fields[0] if (v15.tag == 0) else _arrow250()):
                return True

            else: 
                v0_1_mut = v0_1
                v1_1_mut = op_addition(v1_1, int64(1))
                continue


        break


def method35(v0_1_mut: str, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v106: US7
        if "" == v1_1:
            v106 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'", " "])), (v2_1, v3, v4)])))

        else: 
            v29: str = v1_1[0]
            if method34(v29, int64(0)) == False:
                v64: int = (len(v1_1) - 1) or 0
                v66: str = v1_1[1:v64 + 1]
                v72: str = v29
                pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v72), False, 2), v72, int64(0)), v2_1, v3, v4)
                v106 = US7(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v106 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\"", "\'", " "])), (v2_1, v3, v4)])))


        v118: US7
        if v106.tag == 0:
            v107: str = v106.fields[0]
            v118 = US7(0, "/" if ("\\" == v107) else v107, v106.fields[1], v106.fields[2], v106.fields[3], v106.fields[4])

        else: 
            v118 = US7(1, v106.fields[0])

        if v118.tag == 0:
            v0_1_mut = v0_1 + v118.fields[0]
            v1_1_mut = v118.fields[1]
            v2_1_mut = v118.fields[2]
            v3_mut = v118.fields[3]
            v4_mut = v118.fields[4]
            continue

        else: 
            return (v0_1, v1_1, v2_1, v3, v4)

        break


def method36(v0_1_mut: str, v1_1_mut: int) -> int:
    while True:
        (v0_1, v1_1) = (v0_1_mut, v1_1_mut)
        if v1_1 >= len(v0_1):
            return v1_1

        elif " " == v0_1[v1_1]:
            v0_1_mut = v0_1
            v1_1_mut = v1_1 + 1
            continue

        else: 
            return v1_1

        break


def method37(v0_1_mut: str, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v66: US7
        if "" == v1_1:
            v66 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v2_1, v3, v4)])))

        else: 
            v16: str = v1_1[0]
            v48: int = (len(v1_1) - 1) or 0
            v50: str = v1_1[1:v48 + 1]
            v56: str = v16
            pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v56), False, 2), v56, int64(0)), v2_1, v3, v4)
            v66 = US7(0, v16, v50, pattern_input[0], pattern_input[1], pattern_input[2])

        if v66.tag == 0:
            v0_1_mut = v0_1 + v66.fields[0]
            v1_1_mut = v66.fields[1]
            v2_1_mut = v66.fields[2]
            v3_mut = v66.fields[3]
            v4_mut = v66.fields[4]
            continue

        else: 
            return (v0_1, v1_1, v2_1, v3, v4)

        break


def method25(v0_1: str) -> US6:
    _v0: (str | None) | None = None
    _v0 = some(v0_1)
    def _arrow251(__unit: None=None, v0_1: Any=v0_1) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v10: str = default_arg(_arrow251() if (_v0 is None) else value_12(_v0), "")
    v16: Any = StringBuilder__ctor_Z721C83C5(method26())
    def v19_1(_arg10: tuple[str, Any, int, int], v0_1: Any=v0_1) -> US7:
        return closure14(None, _arg10)

    def v20_1(_arg10_1: tuple[str, Any, int, int], v0_1: Any=v0_1) -> US7:
        return closure16(None, _arg10_1)

    v24: US7 = method30(v10, v16, UH1(1, v19_1, UH1(1, v20_1, UH1(0))))
    v197: US8
    if v24.tag == 0:
        v29: int = v24.fields[4] or 0
        v28: int = v24.fields[3] or 0
        v27: Any = v24.fields[2]
        v26: str = v24.fields[1]
        v123: US7
        if "" == v26:
            v123 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'"])), (v27, v28, v29)])))

        else: 
            v50: str = v26[0]
            if method31(v50, int64(0)) == False:
                v85: int = (len(v26) - 1) or 0
                v87: str = v26[1:v85 + 1]
                v93: str = v50
                pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v93), False, 2), v93, int64(0)), v27, v28, v29)
                v123 = US7(0, v50, v87, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v123 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v50, to_array(of_array(["\"", "\'"])), (v27, v28, v29)])))


        v135: US7
        if v123.tag == 0:
            v124: str = v123.fields[0]
            v135 = US7(0, "/" if ("\\" == v124) else v124, v123.fields[1], v123.fields[2], v123.fields[3], v123.fields[4])

        else: 
            v135 = US7(1, v123.fields[0])

        v155: US8
        if v135.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method32(v135.fields[0], v135.fields[1], v135.fields[2], v135.fields[3], v135.fields[4])
            v155 = US8(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v155 = US8(1, v135.fields[0])

        v165: US8 = US8(0, v155.fields[0], v155.fields[1], v155.fields[2], v155.fields[3], v155.fields[4]) if (v155.tag == 0) else US8(0, "", v26, v27, v28, v29)
        if v165.tag == 0:
            v170: int = v165.fields[4] or 0
            v169: int = v165.fields[3] or 0
            v168: Any = v165.fields[2]
            v167: str = v165.fields[1]
            v174: US7 = method33(v167, v168, v169, v170, UH1(1, v19_1, UH1(1, v20_1, UH1(0))))
            v197 = US8(0, v165.fields[0], v174.fields[1], v174.fields[2], v174.fields[3], v174.fields[4]) if (v174.tag == 0) else US8(1, to_text(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v174.fields[0], (v10, v16, 1, 1), (v26, v27, v28, v29), (v167, v168, v169, v170)])))

        else: 
            v197 = US8(1, "parsing.between / expected content")


    else: 
        v197 = US8(1, v24.fields[0])

    v416: US8
    if v197.tag == 0:
        v416 = v197

    else: 
        v307: US7
        if "" == v10:
            v307 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'", " "])), (v16, 1, 1)])))

        else: 
            v228: str = v10[0]
            if method34(v228, int64(0)) == False:
                v263: int = (len(v10) - 1) or 0
                v265: str = v10[1:v263 + 1]
                v271: str = v228
                pattern_input_2: tuple[Any, int, int] = method28(method27(from_integer(len(v271), False, 2), v271, int64(0)), v16, 1, 1)
                v307 = US7(0, v228, v265, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

            else: 
                v307 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v228, to_array(of_array(["\"", "\'", " "])), (v16, 1, 1)])))


        v319: US7
        if v307.tag == 0:
            v308: str = v307.fields[0]
            v319 = US7(0, "/" if ("\\" == v308) else v308, v307.fields[1], v307.fields[2], v307.fields[3], v307.fields[4])

        else: 
            v319 = US7(1, v307.fields[0])

        v339: US8
        if v319.tag == 0:
            pattern_input_3: tuple[str, str, Any, int, int] = method35(v319.fields[0], v319.fields[1], v319.fields[2], v319.fields[3], v319.fields[4])
            v339 = US8(0, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2], pattern_input_3[3], pattern_input_3[4])

        else: 
            v339 = US8(1, v319.fields[0])

        if v339.tag == 0:
            v416 = v339

        else: 
            v354: US10 = US10(0, v10, v16, 1, 1) if (len(v10) == 0) else US10(1, to_text(interpolate("parsing.eof / expected end of input / input: %A%P()", [v10])))
            v363: US8 = US8(0, "", v354.fields[0], v354.fields[1], v354.fields[2], v354.fields[3]) if (v354.tag == 0) else US8(1, v354.fields[0])
            if v363.tag == 0:
                v365: str = v363.fields[1]
                v370: int = method36(v365, 0) or 0
                v402: int = (len(v365) - 1) or 0
                v416 = US8(0, v363.fields[0], v365[v370:v402 + 1], v363.fields[2], v363.fields[3], v363.fields[4])

            else: 
                v416 = US8(1, v363.fields[0])



    v671: US11
    if v416.tag == 0:
        v421: int = v416.fields[4] or 0
        v420: int = v416.fields[3] or 0
        v419: Any = v416.fields[2]
        v418: str = v416.fields[1]
        v542: US7
        if "" == v418:
            v542 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", [" ", (v419, v420, v421)])))

        else: 
            v428: str = v418[0]
            if v428 == " ":
                v461: int = (len(v418) - 1) or 0
                v463: str = v418[1:v461 + 1]
                v469: str = v428
                pattern_input_4: tuple[Any, int, int] = method28(method27(from_integer(len(v469), False, 2), v469, int64(0)), v419, v420, v421)
                v542 = US7(0, v428, v463, pattern_input_4[0], pattern_input_4[1], pattern_input_4[2])

            else: 
                v484: int = (v418.find("\n") - 1) or 0
                v520: int = (((len(v418) + 1) if (-2 == v484) else (v484 + 1)) - 1) or 0
                v542 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str(" ")) + "\' / line: ") + str(v420)) + " / col: ") + str(v421)) + "\n") + str(v419)) + "") + v418[0:v520 + 1]) + "", "\n", method29(v421 - 1, 0)("") + "^", *"\n"))


        v554: US12 = US12(0, US9(0, v542.fields[0]), v542.fields[1], v542.fields[2], v542.fields[3], v542.fields[4]) if (v542.tag == 0) else US12(0, US9(1), v418, v419, v420, v421)
        v645: US8
        if v554.tag == 0:
            v559: int = v554.fields[4] or 0
            v558: int = v554.fields[3] or 0
            v557: Any = v554.fields[2]
            v556: str = v554.fields[1]
            v621: US7
            if "" == v556:
                v621 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v557, v558, v559)])))

            else: 
                v571: str = v556[0]
                v603: int = (len(v556) - 1) or 0
                v605: str = v556[1:v603 + 1]
                v611: str = v571
                pattern_input_5: tuple[Any, int, int] = method28(method27(from_integer(len(v611), False, 2), v611, int64(0)), v557, v558, v559)
                v621 = US7(0, v571, v605, pattern_input_5[0], pattern_input_5[1], pattern_input_5[2])

            if v621.tag == 0:
                pattern_input_6: tuple[str, str, Any, int, int] = method37(v621.fields[0], v621.fields[1], v621.fields[2], v621.fields[3], v621.fields[4])
                v645 = US8(0, pattern_input_6[0], pattern_input_6[1], pattern_input_6[2], pattern_input_6[3], pattern_input_6[4])

            else: 
                v645 = US8(1, v621.fields[0])


        else: 
            v645 = US8(1, v554.fields[0])

        v657: US13 = US13(0, US5(0, v645.fields[0]), v645.fields[1], v645.fields[2], v645.fields[3], v645.fields[4]) if (v645.tag == 0) else US13(0, US5(1), v418, v419, v420, v421)
        v671 = US11(0, v416.fields[0], v657.fields[0], v657.fields[1], v657.fields[2], v657.fields[3], v657.fields[4]) if (v657.tag == 0) else US11(1, v657.fields[0])

    else: 
        v671 = US11(1, v416.fields[0])

    if v671.tag == 0:
        return US6(0, v671.fields[0], v671.fields[1])

    else: 
        return US6(1, v671.fields[0])



def method38(__unit: None=None) -> str:
    v4: str = "Debug".lower()
    return ("\u001b[94m" + method13(v4[0])) + method15()


def method40(v0_1: str, v1_1: US5, v2_1: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None=None) -> str:
    v10: Mut3 = Mut3(method14())
    v19_1: None
    closure7(v10, "{ ", None)
    v19_1 = None
    v30: None
    closure7(v10, "file_name", None)
    v30 = None
    v41: None
    closure7(v10, " = ", None)
    v41 = None
    v50: None
    closure7(v10, v0_1, None)
    v50 = None
    v61: None
    closure7(v10, "; ", None)
    v61 = None
    v72: None
    closure7(v10, "arguments", None)
    v72 = None
    v81: None
    closure7(v10, " = ", None)
    v81 = None
    v94: None
    closure7(v10, to_text(interpolate("%A%P()", [v1_1])), None)
    v94 = None
    v103: None
    closure7(v10, "; ", None)
    v103 = None
    v114: None
    closure7(v10, "options", None)
    v114 = None
    v123: None
    closure7(v10, " = ", None)
    v123 = None
    v132: None
    closure7(v10, "{ ", None)
    v132 = None
    v143: None
    closure7(v10, "command", None)
    v143 = None
    v152: None
    closure7(v10, " = ", None)
    v152 = None
    v161: None
    closure7(v10, v2_1, None)
    v161 = None
    v170: None
    closure7(v10, "; ", None)
    v170 = None
    v181: None
    closure7(v10, "cancellation_token", None)
    v181 = None
    v190: None
    closure7(v10, " = ", None)
    v190 = None
    v238: None
    closure7(v10, to_text(interpolate("%A%P()", [v3])), None)
    v238 = None
    v247: None
    closure7(v10, "; ", None)
    v247 = None
    v258: None
    closure7(v10, "environment_variables", None)
    v258 = None
    v267: None
    closure7(v10, " = ", None)
    v267 = None
    v280: None
    closure7(v10, to_text(interpolate("%A%P()", [v4])), None)
    v280 = None
    v289: None
    closure7(v10, "; ", None)
    v289 = None
    v300: None
    closure7(v10, "on_line", None)
    v300 = None
    v309: None
    closure7(v10, " = ", None)
    v309 = None
    v357: None
    closure7(v10, to_text(interpolate("%A%P()", [v5])), None)
    v357 = None
    v366: None
    closure7(v10, "; ", None)
    v366 = None
    v377: None
    closure7(v10, "stdin", None)
    v377 = None
    v386: None
    closure7(v10, " = ", None)
    v386 = None
    v434: None
    closure7(v10, to_text(interpolate("%A%P()", [v6])), None)
    v434 = None
    v443: None
    closure7(v10, "; ", None)
    v443 = None
    v454: None
    closure7(v10, "trace", None)
    v454 = None
    v463: None
    closure7(v10, " = ", None)
    v463 = None
    v475: None
    closure7(v10, "true" if v7 else "false", None)
    v475 = None
    v484: None
    closure7(v10, "; ", None)
    v484 = None
    v495: None
    closure7(v10, "working_directory", None)
    v495 = None
    v504: None
    closure7(v10, " = ", None)
    v504 = None
    v552: None
    closure7(v10, to_text(interpolate("%A%P()", [v8])), None)
    v552 = None
    v563: None
    closure7(v10, " }", None)
    v563 = None
    v572: None
    closure7(v10, " }", None)
    v572 = None
    return v10.l0


def method39(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: US5, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15: bool, v16: str | None=None) -> str:
    v17_1: str = method40(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v17_1) + "")


def closure17(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: US5, v8: str, unit_var: None) -> None:
    if method7(US0(1)):
        v13: None
        closure0(None, None)
        v13 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v39: int64 | None = pattern_input[5]
        v38: Mut4 = pattern_input[4]
        v37: Mut3 = pattern_input[3]
        v36: Mut2 = pattern_input[2]
        v35: Mut1 = pattern_input[1]
        v34: Mut0 = pattern_input[0]
        method19(method39(v34, v35, v36, v37, v38, v39, method8(v34, v35, v36, v37, v38, v39), method38(), v8, v7, v0_1, v1_1, v2_1, v3, v4, v5, v6))



def method41(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Array[tuple[str, str]]:
    return v2_1


def method42(v0_1: int, v1_1: Mut5) -> bool:
    return v1_1.l0 < v0_1


def method45(v0_1: bool) -> str:
    return None


def closure19(unit_var: None, v0_1: Callable[[tuple[int, str, bool]], Async[None]]) -> US14:
    return US14(0, v0_1)


def method46(__unit: None=None) -> Callable[[Callable[[tuple[int, str, bool]], Async[None]]], US14]:
    def _arrow252(v: Callable[[tuple[int, str, bool]], Async[None]]) -> US14:
        return closure19(None, v)

    return _arrow252


def method47(v0_1: bool) -> int:
    return None


def method48(__unit: None=None) -> str:
    v4: str = "Verbose".lower()
    return ("\u001b[90m" + method13(v4[0])) + method15()


def method49(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v9: str = method17()
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + v8) + " / ") + v9) + "")


def closure20(v0_1: str, unit_var: None) -> None:
    if method7(US0(0)):
        v5: None
        closure0(None, None)
        v5 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v31: int64 | None = pattern_input[5]
        v30: Mut4 = pattern_input[4]
        v29: Mut3 = pattern_input[3]
        v28: Mut2 = pattern_input[2]
        v27: Mut1 = pattern_input[1]
        v26: Mut0 = pattern_input[0]
        method19("" if (v0_1 == "") else method49(v26, v27, v28, v29, v30, v31, method8(v26, v27, v28, v29, v30, v31), method48(), v0_1))



def method44(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> Async[None]:
    def _arrow262(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, v9: Any=v9, v10: Any=v10) -> Async[None]:
        v837: str = method45(v10)
        v843: bool = (v837 is None) != True
        def _arrow260(__unit: None=None) -> Async[None]:
            v862: US14 = default_arg(map(method46(), v3), US14(1))
            def _arrow254(__unit: None=None) -> Async[None]:
                v868: Async[None] = v862.fields[0]((method47(v7), v837, v9))
                def _arrow253(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v868, _arrow253)

            def _expr255():
                return singleton.Zero()

            def _arrow259(__unit: None=None) -> Async[None]:
                v871: str = concat("! ", *v837) if v9 else concat("> ", *v837)
                def _arrow256(__unit: None=None) -> Async[None]:
                    v874: None
                    closure20(v871, None)
                    v874 = None
                    return singleton.Zero()

                def _arrow257(__unit: None=None) -> Async[None]:
                    v926: None
                    closure10(v871, None)
                    v926 = None
                    return singleton.Zero()

                def _arrow258(__unit: None=None) -> Async[None]:
                    v934: str = concat("\u001b[7;4m" if v9 else "", v837, *"\u001b[0m" if v9 else "")
                    return singleton.Zero()

                return singleton.Combine(_arrow256() if v5 else _arrow257(), singleton.Delay(_arrow258))

            return singleton.Combine(_arrow254() if (v862.tag == 0) else _expr255(), singleton.Delay(_arrow259))

        def _arrow261(__unit: None=None) -> Async[None]:
            return singleton.Zero()

        return singleton.Combine(_arrow260() if v843 else singleton.Zero(), singleton.Delay(_arrow261))

    return singleton.Delay(_arrow262)


def method43(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> Async[None]:
    return method44(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10)


def closure18(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> None:
    start_immediate(method43(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10))


def closure21(unit_var: None, v0_1: CancellationToken) -> US15:
    return US15(0, v0_1)


def method50(__unit: None=None) -> Callable[[CancellationToken], US15]:
    def _arrow263(v: CancellationToken) -> US15:
        return closure21(None, v)

    return _arrow263


def method51(v0_1: CancellationToken) -> Async[CancellationToken]:
    def _arrow264(__unit: None=None, v0_1: Any=v0_1) -> Async[CancellationToken]:
        return singleton.Return(None)

    return singleton.Delay(_arrow264)


def method52(v0_1: bool) -> bool:
    return None


def method53(v0_1: bool) -> None:
    pass


def closure22(v0_1: bool, unit_var: None) -> None:
    if method52(v0_1) == False:
        method53(v0_1)



def method56(v0_1: Any) -> str:
    v2_1: Mut3 = Mut3(method14())
    v11: None
    closure7(v2_1, "{ ", None)
    v11 = None
    v22: None
    closure7(v2_1, "ex", None)
    v22 = None
    v33: None
    closure7(v2_1, " = ", None)
    v33 = None
    v81: None
    closure7(v2_1, to_text(interpolate("%A%P()", [v0_1])), None)
    v81 = None
    v92: None
    closure7(v2_1, " }", None)
    v92 = None
    return v2_1.l0


def method55(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: Any) -> str:
    v9: str = method56(v8)
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "runtime.execute_with_options_async / WaitForExitAsync") + " / ") + v9) + "")


def closure23(v0_1: Any, unit_var: None) -> None:
    if method7(US0(3)):
        v5: None
        closure0(None, None)
        v5 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v31: int64 | None = pattern_input[5]
        v30: Mut4 = pattern_input[4]
        v29: Mut3 = pattern_input[3]
        v28: Mut2 = pattern_input[2]
        v27: Mut1 = pattern_input[1]
        v26: Mut0 = pattern_input[0]
        method19(method55(v26, v27, v28, v29, v30, v31, method8(v26, v27, v28, v29, v30, v31), method12(), v0_1))



def method54(v0_1: bool, v1_1: Any, v2_1: CancellationToken) -> Async[int]:
    def _arrow268(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1) -> Async[int]:
        def _arrow266(__unit: None=None) -> Async[int]:
            v3205: Async[None] = await_task(None)
            def _arrow265(__unit: None=None) -> Async[int]:
                return singleton.Return(None)

            return singleton.Bind(v3205, _arrow265)

        def _arrow267(_arg_1: Exception) -> Async[int]:
            v3355: Exception = _arg_1
            v3378: str = to_text(interpolate("%A%P()", [v3355]))
            v3400: None
            closure23(v3355, None)
            v3400 = None
            return singleton.Return(-2147483648)

        return singleton.TryWith(singleton.Delay(_arrow266), _arrow267)

    return singleton.Delay(_arrow268)


def method57(__unit: None=None) -> str:
    return "\n"


def method59(v0_1: int, v1_1: int, v2_1: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None=None) -> str:
    v10: Mut3 = Mut3(method14())
    v19_1: None
    closure7(v10, "{ ", None)
    v19_1 = None
    v30: None
    closure7(v10, "exit_code", None)
    v30 = None
    v41: None
    closure7(v10, " = ", None)
    v41 = None
    v50: None
    closure7(v10, ("" + str(v0_1)) + "", None)
    v50 = None
    v61: None
    closure7(v10, "; ", None)
    v61 = None
    v72: None
    closure7(v10, "output_length", None)
    v72 = None
    v81: None
    closure7(v10, " = ", None)
    v81 = None
    v90: None
    closure7(v10, ("" + str(v1_1)) + "", None)
    v90 = None
    v99: None
    closure7(v10, "; ", None)
    v99 = None
    v110: None
    closure7(v10, "options", None)
    v110 = None
    v119: None
    closure7(v10, " = ", None)
    v119 = None
    v128: None
    closure7(v10, "{ ", None)
    v128 = None
    v139: None
    closure7(v10, "command", None)
    v139 = None
    v148: None
    closure7(v10, " = ", None)
    v148 = None
    v157: None
    closure7(v10, v2_1, None)
    v157 = None
    v166: None
    closure7(v10, "; ", None)
    v166 = None
    v177: None
    closure7(v10, "cancellation_token", None)
    v177 = None
    v186: None
    closure7(v10, " = ", None)
    v186 = None
    v234: None
    closure7(v10, to_text(interpolate("%A%P()", [v3])), None)
    v234 = None
    v243: None
    closure7(v10, "; ", None)
    v243 = None
    v254: None
    closure7(v10, "environment_variables", None)
    v254 = None
    v263: None
    closure7(v10, " = ", None)
    v263 = None
    v276: None
    closure7(v10, to_text(interpolate("%A%P()", [v4])), None)
    v276 = None
    v285: None
    closure7(v10, "; ", None)
    v285 = None
    v296: None
    closure7(v10, "on_line", None)
    v296 = None
    v305: None
    closure7(v10, " = ", None)
    v305 = None
    v353: None
    closure7(v10, to_text(interpolate("%A%P()", [v5])), None)
    v353 = None
    v362: None
    closure7(v10, "; ", None)
    v362 = None
    v373: None
    closure7(v10, "stdin", None)
    v373 = None
    v382: None
    closure7(v10, " = ", None)
    v382 = None
    v430: None
    closure7(v10, to_text(interpolate("%A%P()", [v6])), None)
    v430 = None
    v439: None
    closure7(v10, "; ", None)
    v439 = None
    v450: None
    closure7(v10, "trace", None)
    v450 = None
    v459: None
    closure7(v10, " = ", None)
    v459 = None
    v471: None
    closure7(v10, "true" if v7 else "false", None)
    v471 = None
    v480: None
    closure7(v10, "; ", None)
    v480 = None
    v491: None
    closure7(v10, "working_directory", None)
    v491 = None
    v500: None
    closure7(v10, " = ", None)
    v500 = None
    v548: None
    closure7(v10, to_text(interpolate("%A%P()", [v8])), None)
    v548 = None
    v559: None
    closure7(v10, " }", None)
    v559 = None
    v568: None
    closure7(v10, " }", None)
    v568 = None
    return v10.l0


def method58(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: int, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15: bool, v16: str | None=None) -> str:
    v17_1: str = method59(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v17_1) + "")


def closure24(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: int, v8: str, unit_var: None) -> None:
    if method7(US0(1)):
        v13: None
        closure0(None, None)
        v13 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_12(TraceState_trace_state())
        v39: int64 | None = pattern_input[5]
        v38: Mut4 = pattern_input[4]
        v37: Mut3 = pattern_input[3]
        v36: Mut2 = pattern_input[2]
        v35: Mut1 = pattern_input[1]
        v34: Mut0 = pattern_input[0]
        method19(method58(v34, v35, v36, v37, v38, v39, method8(v34, v35, v36, v37, v38, v39), method38(), v7, len(v8), v0_1, v1_1, v2_1, v3, v4, v5, v6))



def method24(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Async[tuple[int, str]]:
    def _arrow269(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6) -> Async[tuple[int, str]]:
        pattern_input: tuple[int, str] = None
        return singleton.Return((pattern_input[0], pattern_input[1]))

    return singleton.Delay(_arrow269)


def method23(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Async[tuple[int, str]]:
    return method24(v0_1, v1_1, v2_1, v3, v4, v5, v6)


def method22(v0_1: str) -> Async[tuple[int, str]]:
    return method23(v0_1, None, [], None, None, True, None)


def closure13(unit_var: None, v0_1: str) -> Async[tuple[int, str]]:
    return method22(v0_1)


def closure25(unit_var: None, _arg: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return method23(_arg[0], _arg[1], _arg[2], _arg[3], _arg[4], _arg[5], _arg[6])


def closure26(unit_var: None, v0_1: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    v8: Heap0 = v0_1(Heap0("", None, [], None, None, True, None))
    return (v8.l0, v8.l1, v8.l2, v8.l3, v8.l4, v8.l5, v8.l6)


def method62(v0_1_mut: str, v1_1_mut: int64) -> bool:
    while True:
        (v0_1, v1_1) = (v0_1_mut, v1_1_mut)
        if v1_1 >= int64(4):
            return False

        else: 
            v19_1: US9
            if v1_1 == int64(0):
                v19_1 = US9(0, "\\")

            else: 
                v5: int64 = op_subtraction(v1_1, int64(1))
                if v5 == int64(0):
                    v19_1 = US9(0, "`")

                else: 
                    v8: int64 = op_subtraction(v5, int64(1))
                    if v8 == int64(0):
                        v19_1 = US9(0, "\"")

                    else: 
                        v11: int64 = op_subtraction(v8, int64(1))
                        if v11 == int64(0):
                            v19_1 = US9(0, " ")

                        else: 
                            v14: int64 = op_subtraction(v11, int64(1))
                            v19_1 = US9(1)




            def _arrow270(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v19_1.fields[0] if (v19_1.tag == 0) else _arrow270()):
                return True

            else: 
                v0_1_mut = v0_1
                v1_1_mut = op_addition(v1_1, int64(1))
                continue


        break


def method63(v0_1_mut: str, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v114: US7
        if "" == v1_1:
            v114 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))

        else: 
            v33: str = v1_1[0]
            if method62(v33, int64(0)) == False:
                v68: int = (len(v1_1) - 1) or 0
                v70: str = v1_1[1:v68 + 1]
                v76: str = v33
                pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v76), False, 2), v76, int64(0)), v2_1, v3, v4)
                v114 = US7(0, v33, v70, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v114 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))


        if v114.tag == 0:
            v0_1_mut = v0_1 + v114.fields[0]
            v1_1_mut = v114.fields[1]
            v2_1_mut = v114.fields[2]
            v3_mut = v114.fields[3]
            v4_mut = v114.fields[4]
            continue

        else: 
            return (v0_1, v1_1, v2_1, v3, v4)

        break


def method65(v0_1_mut: str, v1_1_mut: int64) -> bool:
    while True:
        (v0_1, v1_1) = (v0_1_mut, v1_1_mut)
        if v1_1 >= int64(3):
            return False

        else: 
            v15: US9
            if v1_1 == int64(0):
                v15 = US9(0, "\\")

            else: 
                v5: int64 = op_subtraction(v1_1, int64(1))
                if v5 == int64(0):
                    v15 = US9(0, "`")

                else: 
                    v8: int64 = op_subtraction(v5, int64(1))
                    if v8 == int64(0):
                        v15 = US9(0, "\"")

                    else: 
                        v11: int64 = op_subtraction(v8, int64(1))
                        v15 = US9(1)



            def _arrow271(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v15.fields[0] if (v15.tag == 0) else _arrow271()):
                return True

            else: 
                v0_1_mut = v0_1
                v1_1_mut = op_addition(v1_1, int64(1))
                continue


        break


def closure28(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2_1: int = _arg[2] or 0
    v1_1: Any = _arg[1]
    v0_1: str = _arg[0]
    v125: US7
    if "" == v0_1:
        v125 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\\", (v1_1, v2_1, v3)])))

    else: 
        v10: str = v0_1[0]
        if v10 == "\\":
            v43: int = (len(v0_1) - 1) or 0
            v45: str = v0_1[1:v43 + 1]
            v51: str = v10
            pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v51), False, 2), v51, int64(0)), v1_1, v2_1, v3)
            v125 = US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v66: int = (v0_1.find("\n") - 1) or 0
            v102: int = (((len(v0_1) + 1) if (-2 == v66) else (v66 + 1)) - 1) or 0
            v125 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\\")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v102 + 1]) + "", "\n", method29(v3 - 1, 0)("") + "^", *"\n"))


    v196: US7
    if v125.tag == 0:
        v130: int = v125.fields[4] or 0
        v129: int = v125.fields[3] or 0
        v128: Any = v125.fields[2]
        v127: str = v125.fields[1]
        if "" == v127:
            v196 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v128, v129, v130)])))

        else: 
            v142: str = v127[0]
            v174: int = (len(v127) - 1) or 0
            v176: str = v127[1:v174 + 1]
            v182: str = v142
            pattern_input_1: tuple[Any, int, int] = method28(method27(from_integer(len(v182), False, 2), v182, int64(0)), v128, v129, v130)
            v196 = US7(0, v142, v176, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v196 = US7(1, v125.fields[0])

    if v196.tag == 0:
        return US8(0, "\\" + v196.fields[0], v196.fields[1], v196.fields[2], v196.fields[3], v196.fields[4])

    else: 
        return US8(1, v196.fields[0])



def closure29(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2_1: int = _arg[2] or 0
    v1_1: Any = _arg[1]
    v0_1: str = _arg[0]
    v125: US7
    if "" == v0_1:
        v125 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["`", (v1_1, v2_1, v3)])))

    else: 
        v10: str = v0_1[0]
        if v10 == "`":
            v43: int = (len(v0_1) - 1) or 0
            v45: str = v0_1[1:v43 + 1]
            v51: str = v10
            pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v51), False, 2), v51, int64(0)), v1_1, v2_1, v3)
            v125 = US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v66: int = (v0_1.find("\n") - 1) or 0
            v102: int = (((len(v0_1) + 1) if (-2 == v66) else (v66 + 1)) - 1) or 0
            v125 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("`")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v102 + 1]) + "", "\n", method29(v3 - 1, 0)("") + "^", *"\n"))


    v196: US7
    if v125.tag == 0:
        v130: int = v125.fields[4] or 0
        v129: int = v125.fields[3] or 0
        v128: Any = v125.fields[2]
        v127: str = v125.fields[1]
        if "" == v127:
            v196 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v128, v129, v130)])))

        else: 
            v142: str = v127[0]
            v174: int = (len(v127) - 1) or 0
            v176: str = v127[1:v174 + 1]
            v182: str = v142
            pattern_input_1: tuple[Any, int, int] = method28(method27(from_integer(len(v182), False, 2), v182, int64(0)), v128, v129, v130)
            v196 = US7(0, v142, v176, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v196 = US7(1, v125.fields[0])

    if v196.tag == 0:
        return US8(0, "`" + v196.fields[0], v196.fields[1], v196.fields[2], v196.fields[3], v196.fields[4])

    else: 
        return US8(1, v196.fields[0])



def method66(v0_1_mut: str, v1_1_mut: Any, v2_1_mut: int, v3_mut: int, v4_mut: UH3) -> US8:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        if v4.tag == 0:
            return US8(1, "parsing.choice / no parsers succeeded")

        else: 
            v9: US8 = v4.fields[0]((v0_1, v1_1, v2_1, v3))
            if v9.tag == 0:
                return v9

            else: 
                v0_1_mut = v0_1
                v1_1_mut = v1_1
                v2_1_mut = v2_1
                v3_mut = v3
                v4_mut = v4.fields[1]
                continue


        break


def method67(v0_1_mut: UH2, v1_1_mut: UH2) -> UH2:
    while True:
        (v0_1, v1_1) = (v0_1_mut, v1_1_mut)
        if v0_1.tag == 0:
            return v1_1

        else: 
            v0_1_mut = v0_1.fields[1]
            v1_1_mut = UH2(1, v0_1.fields[0], v1_1)
            continue

        break


def method64(v0_1_mut: UH2, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> US17:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v106: US7
        if "" == v1_1:
            v106 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))

        else: 
            v29: str = v1_1[0]
            if method65(v29, int64(0)) == False:
                v64: int = (len(v1_1) - 1) or 0
                v66: str = v1_1[1:v64 + 1]
                v72: str = v29
                pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v72), False, 2), v72, int64(0)), v2_1, v3, v4)
                v106 = US7(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v106 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))


        v121: US8 = US8(0, v106.fields[0], v106.fields[1], v106.fields[2], v106.fields[3], v106.fields[4]) if (v106.tag == 0) else US8(1, v106.fields[0])
        def v128(_arg10: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
            return closure28(None, _arg10)

        def v129(_arg10_1: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
            return closure29(None, _arg10_1)

        v135: US8 = v121 if (v121.tag == 0) else method66(v1_1, v2_1, v3, v4, UH3(1, v128, UH3(1, v129, UH3(0))))
        if v135.tag == 0:
            v0_1_mut = UH2(1, v135.fields[0], v0_1)
            v1_1_mut = v135.fields[1]
            v2_1_mut = v135.fields[2]
            v3_mut = v135.fields[3]
            v4_mut = v135.fields[4]
            continue

        else: 
            return US17(0, method67(v0_1, UH2(0)), v1_1, v2_1, v3, v4)

        break


def method68(v0_1: UH2, v1_1: FSharpList[str]) -> FSharpList[str]:
    if v0_1.tag == 0:
        return v1_1

    else: 
        return cons(v0_1.fields[0], method68(v0_1.fields[1], v1_1))



def method69(v0_1_mut: UH2, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> US17:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v106: US7
        if "" == v1_1:
            v106 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))

        else: 
            v29: str = v1_1[0]
            if method65(v29, int64(0)) == False:
                v64: int = (len(v1_1) - 1) or 0
                v66: str = v1_1[1:v64 + 1]
                v72: str = v29
                pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v72), False, 2), v72, int64(0)), v2_1, v3, v4)
                v106 = US7(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v106 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))


        v121: US8 = US8(0, v106.fields[0], v106.fields[1], v106.fields[2], v106.fields[3], v106.fields[4]) if (v106.tag == 0) else US8(1, v106.fields[0])
        if v121.tag == 0:
            v0_1_mut = UH2(1, v121.fields[0], v0_1)
            v1_1_mut = v121.fields[1]
            v2_1_mut = v121.fields[2]
            v3_mut = v121.fields[3]
            v4_mut = v121.fields[4]
            continue

        else: 
            return US17(0, method67(v0_1, UH2(0)), v1_1, v2_1, v3, v4)

        break


def method61(v0_1_mut: UH2, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> US17:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v5: bool = "" == v1_1
        v114: US7
        if v5:
            v114 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))

        else: 
            v33: str = v1_1[0]
            if method62(v33, int64(0)) == False:
                v68: int = (len(v1_1) - 1) or 0
                v70: str = v1_1[1:v68 + 1]
                v76: str = v33
                pattern_input: tuple[Any, int, int] = method28(method27(from_integer(len(v76), False, 2), v76, int64(0)), v2_1, v3, v4)
                v114 = US7(0, v33, v70, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v114 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))


        v134: US8
        if v114.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method63(v114.fields[0], v114.fields[1], v114.fields[2], v114.fields[3], v114.fields[4])
            v134 = US8(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v134 = US8(1, v114.fields[0])

        v522: US8
        if v134.tag == 0:
            v522 = v134

        else: 
            v261: US7
            if v5:
                v261 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v2_1, v3, v4)])))

            else: 
                v146: str = v1_1[0]
                if v146 == "\"":
                    v179: int = (len(v1_1) - 1) or 0
                    v181: str = v1_1[1:v179 + 1]
                    v187: str = v146
                    pattern_input_2: tuple[Any, int, int] = method28(method27(from_integer(len(v187), False, 2), v187, int64(0)), v2_1, v3, v4)
                    v261 = US7(0, v146, v181, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

                else: 
                    v202: int = (v1_1.find("\n") - 1) or 0
                    v238: int = (((len(v1_1) + 1) if (-2 == v202) else (v202 + 1)) - 1) or 0
                    v261 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v3)) + " / col: ") + str(v4)) + "\n") + str(v2_1)) + "") + v1_1[0:v238 + 1]) + "", "\n", method29(v4 - 1, 0)("") + "^", *"\n"))


            v451: US8
            if v261.tag == 0:
                v266: int = v261.fields[4] or 0
                v265: int = v261.fields[3] or 0
                v264: Any = v261.fields[2]
                v263: str = v261.fields[1]
                v268: US17 = method64(UH2(0), v263, v264, v265, v266)
                v301: US8
                if v268.tag == 0:
                    v275: FSharpList[str] = method68(v268.fields[0], empty())
                    def _arrow272(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v275

                    v301 = US8(0, join("", delay(_arrow272)), v268.fields[1], v268.fields[2], v268.fields[3], v268.fields[4])

                else: 
                    v301 = US8(1, v268.fields[0])

                if v301.tag == 0:
                    v306: int = v301.fields[4] or 0
                    v305: int = v301.fields[3] or 0
                    v304: Any = v301.fields[2]
                    v303: str = v301.fields[1]
                    v428: US7
                    if "" == v303:
                        v428 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v304, v305, v306)])))

                    else: 
                        v313: str = v303[0]
                        if v313 == "\"":
                            v346: int = (len(v303) - 1) or 0
                            v348: str = v303[1:v346 + 1]
                            v354: str = v313
                            pattern_input_3: tuple[Any, int, int] = method28(method27(from_integer(len(v354), False, 2), v354, int64(0)), v304, v305, v306)
                            v428 = US7(0, v313, v348, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2])

                        else: 
                            v369: int = (v303.find("\n") - 1) or 0
                            v405: int = (((len(v303) + 1) if (-2 == v369) else (v369 + 1)) - 1) or 0
                            v428 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v305)) + " / col: ") + str(v306)) + "\n") + str(v304)) + "") + v303[0:v405 + 1]) + "", "\n", method29(v306 - 1, 0)("") + "^", *"\n"))


                    v451 = US8(0, v301.fields[0], v428.fields[1], v428.fields[2], v428.fields[3], v428.fields[4]) if (v428.tag == 0) else US8(1, to_text(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v428.fields[0], (v1_1, v2_1, v3, v4), (v263, v264, v265, v266), (v303, v304, v305, v306)])))

                else: 
                    v451 = US8(1, "parsing.between / expected content")


            else: 
                v451 = US8(1, v261.fields[0])

            if v451.tag == 0:
                v522 = v451

            else: 
                def v458(_arg10: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
                    return closure28(None, _arg10)

                def v459(_arg10_1: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
                    return closure29(None, _arg10_1)

                v463: US8 = method66(v1_1, v2_1, v3, v4, UH3(1, v458, UH3(1, v459, UH3(0))))
                v474: US8 = US8(0, "", v463.fields[1], v463.fields[2], v463.fields[3], v463.fields[4]) if (v463.tag == 0) else US8(1, v463.fields[0])
                v485: US17 = method69(UH2(0), v474.fields[1], v474.fields[2], v474.fields[3], v474.fields[4]) if (v474.tag == 0) else US17(1, v474.fields[0])
                if v485.tag == 0:
                    v492: FSharpList[str] = method68(v485.fields[0], empty())
                    def _arrow273(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v492

                    v522 = US8(0, join("", delay(_arrow273)), v485.fields[1], v485.fields[2], v485.fields[3], v485.fields[4])

                else: 
                    v522 = US8(1, v485.fields[0])



        if v522.tag == 0:
            v527: int = v522.fields[4] or 0
            v526: int = v522.fields[3] or 0
            v525: Any = v522.fields[2]
            v524: str = v522.fields[1]
            v523: str = v522.fields[0]
            v529: int = method36(v524, 0) or 0
            v571: US10
            if 0 == v529:
                v571 = US10(1, "parsing.spaces1 / expected at least one space")

            else: 
                v564: int = (len(v524) - 1) or 0
                v571 = US10(0, v524[v529:v564 + 1], v525, v526, v527)

            if v571.tag == 0:
                v0_1_mut = UH2(1, v523, v0_1)
                v1_1_mut = v571.fields[0]
                v2_1_mut = v571.fields[1]
                v3_mut = v571.fields[2]
                v4_mut = v571.fields[3]
                continue

            else: 
                return US17(0, method67(v0_1, UH2(1, v523, UH2(0))), v524, v525, v526, v527)


        else: 
            return US17(0, method67(v0_1, UH2(0)), v1_1, v2_1, v3, v4)

        break


def method60(v0_1: str) -> US16:
    _v0: (str | None) | None = None
    _v0 = some(v0_1)
    def _arrow274(__unit: None=None, v0_1: Any=v0_1) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v22: US17 = method61(UH2(0), default_arg(_arrow274() if (_v0 is None) else value_12(_v0), ""), StringBuilder__ctor_Z721C83C5(method26()), 1, 1)
    if v22.tag == 0:
        return US16(0, to_array(method68(v22.fields[0], empty())))

    else: 
        return US16(1, v22.fields[0])



def closure27(unit_var: None, v0_1: str) -> FSharpResult_2[Array[str], str]:
    v1_1: US16 = method60(v0_1)
    if v1_1.tag == 0:
        return FSharpResult_2(0, v1_1.fields[0])

    else: 
        return FSharpResult_2(1, v1_1.fields[0])



v0: None = None

def _arrow275(__unit: None=None) -> None:
    closure0(None, None)


v1: Callable[[], None] = _arrow275

def _expr276():
    v1(None)
    return v0


v2: None = _expr276()

def _arrow277(__unit: None=None) -> None:
    closure3(None, None)


v17: Callable[[], None] = _arrow277

def current_process_kill(__unit: None=None) -> None:
    v17(None)


def _arrow278(v: str) -> Async[tuple[int, str]]:
    return closure13(None, v)


v18: Callable[[str], Async[tuple[int, str]]] = _arrow278

def execute_async(x: str) -> Async[tuple[int, str]]:
    return v18(x)


def _arrow279(_arg10: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return closure25(None, _arg10)


v19: Callable[[tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]], Async[tuple[int, str]]] = _arrow279

def execute_with_options_async(x: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return v19(x)


def _arrow280(v: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    return closure26(None, v)


v20: Callable[[Callable[[Heap0], Heap0]], tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]] = _arrow280

def execution_options(x: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    return v20(x)


def _arrow281(v: str) -> FSharpResult_2[Array[str], str]:
    return closure27(None, v)


v21: Callable[[str], FSharpResult_2[Array[str], str]] = _arrow281

def split_args(x: str) -> FSharpResult_2[Array[str], str]:
    return v21(x)


