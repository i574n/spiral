from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.array_ import fill
from fable_modules.fable_library.async_ import (start_immediate, await_task)
from fable_modules.fable_library.async_builder import (Async, CancellationToken, singleton)
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.list import (to_array, empty, of_array, FSharpList, fold_back, cons)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_12, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type, char_type, class_type, int32_type, tuple_type, option_type, array_type)
from fable_modules.fable_library.result import FSharpResult_2
from fable_modules.fable_library.seq import delay
from fable_modules.fable_library.string_ import (trim_end, trim_start, to_text, interpolate, concat, join)
from fable_modules.fable_library.system_text import (StringBuilder__Clear, StringBuilder__Append_Z721C83C5, StringBuilder__ctor_Z721C83C5)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Array, Union, Record)
from fable_modules.fable_library.util import (create_atom, to_enumerable, compare, uncurry2, IEnumerable_1)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


def _expr191() -> TypeInfo:
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


US0_reflection = _expr191

def _expr192() -> TypeInfo:
    return record_type("Runtime.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr192

def _expr193() -> TypeInfo:
    return record_type("Runtime.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr193

def _expr194() -> TypeInfo:
    return record_type("Runtime.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr194

def _expr195() -> TypeInfo:
    return record_type("Runtime.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr195

def _expr196() -> TypeInfo:
    return record_type("Runtime.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr196

def _expr197() -> TypeInfo:
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


US1_reflection = _expr197

def _expr198() -> TypeInfo:
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


US2_reflection = _expr198

def _expr199() -> TypeInfo:
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


US3_reflection = _expr199

def _expr200() -> TypeInfo:
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


US4_reflection = _expr200

def _expr201() -> TypeInfo:
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


US5_reflection = _expr201

def _expr202() -> TypeInfo:
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


US6_reflection = _expr202

def _expr203() -> TypeInfo:
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


US7_reflection = _expr203

def _expr204() -> TypeInfo:
    return record_type("Runtime.Mut5", [], Mut5, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut5(Record):
    l0: int

Mut5_reflection = _expr204

def _expr205() -> TypeInfo:
    return union_type("Runtime.UH0", [], UH0, lambda: [[], [("Item1", char_type), ("Item2", UH0_reflection())]])


class UH0(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH0_0", "UH0_1"]


UH0_reflection = _expr205

def _expr206() -> TypeInfo:
    return union_type("Runtime.UH1", [], UH1, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US7_reflection())), ("Item2", UH1_reflection())]])


class UH1(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH1_0", "UH1_1"]


UH1_reflection = _expr206

def _expr207() -> TypeInfo:
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


US8_reflection = _expr207

def _expr208() -> TypeInfo:
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


US9_reflection = _expr208

def _expr209() -> TypeInfo:
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


US10_reflection = _expr209

def _expr210() -> TypeInfo:
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


US11_reflection = _expr210

def _expr211() -> TypeInfo:
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


US12_reflection = _expr211

def _expr212() -> TypeInfo:
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


US13_reflection = _expr212

def _expr213() -> TypeInfo:
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


US14_reflection = _expr213

def _expr214() -> TypeInfo:
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


US15_reflection = _expr214

def _expr215() -> TypeInfo:
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

Heap0_reflection = _expr215

def _expr216() -> TypeInfo:
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


US16_reflection = _expr216

def _expr217() -> TypeInfo:
    return union_type("Runtime.UH2", [], UH2, lambda: [[], [("Item1", string_type), ("Item2", UH2_reflection())]])


class UH2(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH2_0", "UH2_1"]


UH2_reflection = _expr217

def _expr218() -> TypeInfo:
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


US17_reflection = _expr218

def _expr219() -> TypeInfo:
    return union_type("Runtime.UH3", [], UH3, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US8_reflection())), ("Item2", UH3_reflection())]])


class UH3(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH3_0", "UH3_1"]


UH3_reflection = _expr219

def method3(v0_1: str) -> str:
    return v0_1


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0_1: str) -> US5:
    return US5(0, v0_1)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow220(v: str) -> US5:
        return closure1(None, v)

    return _arrow220


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

    v66: US5 = default_arg(map(method5(), v47), US5(1))
    if v66.tag == 0:
        return v66.fields[0]

    else: 
        return ""



def method1(__unit: None=None) -> tuple[US1, US2]:
    v1_1: str = method2("TRACE_LEVEL")
    v6: US1 = US1(0, US0(0)) if ("Verbose" == v1_1) else US1(1)
    def _arrow221(__unit: None=None) -> US1:
        v13: US1 = US1(0, US0(1)) if ("Debug" == v1_1) else US1(1)
        if v13.tag == 0:
            return US1(0, v13.fields[0])

        else: 
            v20_1: US1 = US1(0, US0(2)) if ("Info" == v1_1) else US1(1)
            if v20_1.tag == 0:
                return US1(0, v20_1.fields[0])

            else: 
                v27: US1 = US1(0, US0(3)) if ("Warning" == v1_1) else US1(1)
                if v27.tag == 0:
                    return US1(0, v27.fields[0])

                else: 
                    v34: US1 = US1(0, US0(4)) if ("Critical" == v1_1) else US1(1)
                    return US1(0, v34.fields[0]) if (v34.tag == 0) else US1(1)




    return (US1(0, v6.fields[0]) if (v6.tag == 0) else _arrow221(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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
        class ObjectExpr222:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        class ObjectExpr223:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        return find(v0_1, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr222())) >= find(v42, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr223()))



def closure6(unit_var: None, v0_1: int64) -> US2:
    return US2(0, v0_1)


def method9(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow224(v: int64) -> US2:
        return closure6(None, v)

    return _arrow224


def method10(__unit: None=None) -> str:
    return "hh:mm:ss"


def method11(__unit: None=None) -> str:
    return "HH:mm:ss"


def method8(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v700: US2 = default_arg(map(method9(), v5), US2(1))
    v818: Any
    if v700.tag == 0:
        v770: Any = create(op_subtraction(from_value(ticks_1(now()), False), v700.fields[0]))
        v818 = create_1(1, 1, 1, hours(v770), minutes(v770), seconds(v770), milliseconds(v770))

    else: 
        v818 = now()

    v820: str = method11()
    return to_string(v818, "M-d-y hh:mm:ss tt" if (v820 == "") else v820)


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
    v3: str = "Warning".lower()
    return ("\u001b[93m" + method13(v3[0])) + method15()


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


def method27(v0_1: int, v1_1: Mut5) -> bool:
    return v1_1.l0 < v0_1


def closure16(v0_1: str, v1_1: UH0) -> UH0:
    return UH0(1, v0_1, v1_1)


def closure15(unit_var: None, v0_1: str) -> Callable[[UH0], UH0]:
    def _arrow225(v: UH0, unit_var: Any=unit_var, v0_1: Any=v0_1) -> UH0:
        return closure16(v0_1, v)

    return _arrow225


def method28(__unit: None=None) -> Callable[[str, UH0], UH0]:
    def _arrow226(v: str) -> Callable[[UH0], UH0]:
        return closure15(None, v)

    return _arrow226


def method29(v0_1_mut: UH0, v1_1_mut: Any, v2_1_mut: int, v3_mut: int) -> tuple[Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut)
        if v0_1.tag == 0:
            return (v1_1, v2_1, v3)

        else: 
            v4: str = v0_1.fields[0]
            v6: bool = "\n" == v4
            pattern_input: tuple[int, int] = ((v2_1 + 1, 1)) if v6 else ((v2_1, v3 + 1))
            v0_1_mut = v0_1.fields[1]
            def _arrow227(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3) -> Any:
                v13: Any = StringBuilder__Clear(v1_1)
                return v1_1

            def _arrow228(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3) -> Any:
                v24: Any = StringBuilder__Append_Z721C83C5(v1_1, v4)
                return v1_1

            v1_1_mut = _arrow227() if v6 else _arrow228()
            v2_1_mut = pattern_input[0]
            v3_mut = pattern_input[1]
            continue

        break


def closure17(v0_1: int, v1_1: int, v2_1: str) -> str:
    if v1_1 >= v0_1:
        return v2_1

    else: 
        return method30(v0_1, v1_1 + 1)(v2_1 + " ")



def method30(v0_1: int, v1_1: int) -> Callable[[str], str]:
    def _arrow229(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
        return closure17(v0_1, v1_1, v)

    return _arrow229


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
            v54: int = len(v51) or 0
            v55: Array[str] = fill([0] * v54, 0, v54, "")
            v56: Mut5 = Mut5(0)
            while method27(v54, v56):
                v58: int = v56.l0 or 0
                v59: str = v51[v58]
                v55[v58] = v59
                v60: int = (v58 + 1) or 0
                v56.l0 = v60 or 0
            v62: FSharpList[str] = of_array(v55)
            pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v62, UH0(0)), v1_1, v2_1, v3)
            return US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v105: int = (v0_1.find("\n") - 1) or 0
            v141: int = (((len(v0_1) + 1) if (-2 == v105) else (v105 + 1)) - 1) or 0
            return US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v141 + 1]) + "", "\n", method30(v3 - 1, 0)("") + "^", *"\n"))




def closure18(unit_var: None, _arg: tuple[str, Any, int, int]) -> US7:
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
            v54: int = len(v51) or 0
            v55: Array[str] = fill([0] * v54, 0, v54, "")
            v56: Mut5 = Mut5(0)
            while method27(v54, v56):
                v58: int = v56.l0 or 0
                v59: str = v51[v58]
                v55[v58] = v59
                v60: int = (v58 + 1) or 0
                v56.l0 = v60 or 0
            v62: FSharpList[str] = of_array(v55)
            pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v62, UH0(0)), v1_1, v2_1, v3)
            return US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v105: int = (v0_1.find("\n") - 1) or 0
            v141: int = (((len(v0_1) + 1) if (-2 == v105) else (v105 + 1)) - 1) or 0
            return US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\'")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v141 + 1]) + "", "\n", method30(v3 - 1, 0)("") + "^", *"\n"))




def method31(v0_1_mut: str, v1_1_mut: Any, v2_1_mut: UH1) -> US7:
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


def method32(v0_1_mut: str, v1_1_mut: int64) -> bool:
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


            def _arrow230(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v11.fields[0] if (v11.tag == 0) else _arrow230()):
                return True

            else: 
                v0_1_mut = v0_1
                v1_1_mut = op_addition(v1_1, int64(1))
                continue


        break


def method33(v0_1_mut: str, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v137: US7
        if "" == v1_1:
            v137 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'"])), (v2_1, v3, v4)])))

        else: 
            v25: str = v1_1[0]
            if method32(v25, int64(0)) == False:
                v60: int = (len(v1_1) - 1) or 0
                v62: str = v1_1[1:v60 + 1]
                v68: str = v25
                v71: int = len(v68) or 0
                v72: Array[str] = fill([0] * v71, 0, v71, "")
                v73: Mut5 = Mut5(0)
                while method27(v71, v73):
                    v75: int = v73.l0 or 0
                    v76: str = v68[v75]
                    v72[v75] = v76
                    v77: int = (v75 + 1) or 0
                    v73.l0 = v77 or 0
                v79: FSharpList[str] = of_array(v72)
                pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v79, UH0(0)), v2_1, v3, v4)
                v137 = US7(0, v25, v62, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v137 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v25, to_array(of_array(["\"", "\'"])), (v2_1, v3, v4)])))


        v149: US7
        if v137.tag == 0:
            v138: str = v137.fields[0]
            v149 = US7(0, "/" if ("\\" == v138) else v138, v137.fields[1], v137.fields[2], v137.fields[3], v137.fields[4])

        else: 
            v149 = US7(1, v137.fields[0])

        if v149.tag == 0:
            v0_1_mut = v0_1 + v149.fields[0]
            v1_1_mut = v149.fields[1]
            v2_1_mut = v149.fields[2]
            v3_mut = v149.fields[3]
            v4_mut = v149.fields[4]
            continue

        else: 
            return (v0_1, v1_1, v2_1, v3, v4)

        break


def method34(v0_1_mut: str, v1_1_mut: Any, v2_1_mut: int, v3_mut: int, v4_mut: UH1) -> US7:
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


def method35(v0_1_mut: str, v1_1_mut: int64) -> bool:
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



            def _arrow231(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v15.fields[0] if (v15.tag == 0) else _arrow231()):
                return True

            else: 
                v0_1_mut = v0_1
                v1_1_mut = op_addition(v1_1, int64(1))
                continue


        break


def method36(v0_1_mut: str, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v145: US7
        if "" == v1_1:
            v145 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'", " "])), (v2_1, v3, v4)])))

        else: 
            v29: str = v1_1[0]
            if method35(v29, int64(0)) == False:
                v64: int = (len(v1_1) - 1) or 0
                v66: str = v1_1[1:v64 + 1]
                v72: str = v29
                v75: int = len(v72) or 0
                v76: Array[str] = fill([0] * v75, 0, v75, "")
                v77: Mut5 = Mut5(0)
                while method27(v75, v77):
                    v79: int = v77.l0 or 0
                    v80: str = v72[v79]
                    v76[v79] = v80
                    v81: int = (v79 + 1) or 0
                    v77.l0 = v81 or 0
                v83: FSharpList[str] = of_array(v76)
                pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v83, UH0(0)), v2_1, v3, v4)
                v145 = US7(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v145 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\"", "\'", " "])), (v2_1, v3, v4)])))


        v157: US7
        if v145.tag == 0:
            v146: str = v145.fields[0]
            v157 = US7(0, "/" if ("\\" == v146) else v146, v145.fields[1], v145.fields[2], v145.fields[3], v145.fields[4])

        else: 
            v157 = US7(1, v145.fields[0])

        if v157.tag == 0:
            v0_1_mut = v0_1 + v157.fields[0]
            v1_1_mut = v157.fields[1]
            v2_1_mut = v157.fields[2]
            v3_mut = v157.fields[3]
            v4_mut = v157.fields[4]
            continue

        else: 
            return (v0_1, v1_1, v2_1, v3, v4)

        break


def method37(v0_1_mut: str, v1_1_mut: int) -> int:
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


def method38(v0_1_mut: str, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v100: US7
        if "" == v1_1:
            v100 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v2_1, v3, v4)])))

        else: 
            v11: str = v1_1[0]
            v43: int = (len(v1_1) - 1) or 0
            v45: str = v1_1[1:v43 + 1]
            v51: str = v11
            v54: int = len(v51) or 0
            v55: Array[str] = fill([0] * v54, 0, v54, "")
            v56: Mut5 = Mut5(0)
            while method27(v54, v56):
                v58: int = v56.l0 or 0
                v59: str = v51[v58]
                v55[v58] = v59
                v60: int = (v58 + 1) or 0
                v56.l0 = v60 or 0
            v62: FSharpList[str] = of_array(v55)
            pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v62, UH0(0)), v2_1, v3, v4)
            v100 = US7(0, v11, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        if v100.tag == 0:
            v0_1_mut = v0_1 + v100.fields[0]
            v1_1_mut = v100.fields[1]
            v2_1_mut = v100.fields[2]
            v3_mut = v100.fields[3]
            v4_mut = v100.fields[4]
            continue

        else: 
            return (v0_1, v1_1, v2_1, v3, v4)

        break


def method25(v0_1: str) -> US6:
    _v0: (str | None) | None = None
    _v0 = some(v0_1)
    def _arrow232(__unit: None=None, v0_1: Any=v0_1) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v9: str = default_arg(_arrow232() if (_v0 is None) else value_12(_v0), "")
    v15: Any = StringBuilder__ctor_Z721C83C5(method26())
    def v18_1(_arg10: tuple[str, Any, int, int], v0_1: Any=v0_1) -> US7:
        return closure14(None, _arg10)

    def v19_1(_arg10_1: tuple[str, Any, int, int], v0_1: Any=v0_1) -> US7:
        return closure18(None, _arg10_1)

    v23: US7 = method31(v9, v15, UH1(1, v18_1, UH1(1, v19_1, UH1(0))))
    v235: US8
    if v23.tag == 0:
        v28: int = v23.fields[4] or 0
        v27: int = v23.fields[3] or 0
        v26: Any = v23.fields[2]
        v25: str = v23.fields[1]
        v161: US7
        if "" == v25:
            v161 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'"])), (v26, v27, v28)])))

        else: 
            v49: str = v25[0]
            if method32(v49, int64(0)) == False:
                v84: int = (len(v25) - 1) or 0
                v86: str = v25[1:v84 + 1]
                v92: str = v49
                v95: int = len(v92) or 0
                v96: Array[str] = fill([0] * v95, 0, v95, "")
                v97: Mut5 = Mut5(0)
                while method27(v95, v97):
                    v99: int = v97.l0 or 0
                    v100: str = v92[v99]
                    v96[v99] = v100
                    v101: int = (v99 + 1) or 0
                    v97.l0 = v101 or 0
                v103: FSharpList[str] = of_array(v96)
                pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v103, UH0(0)), v26, v27, v28)
                v161 = US7(0, v49, v86, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v161 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v49, to_array(of_array(["\"", "\'"])), (v26, v27, v28)])))


        v173: US7
        if v161.tag == 0:
            v162: str = v161.fields[0]
            v173 = US7(0, "/" if ("\\" == v162) else v162, v161.fields[1], v161.fields[2], v161.fields[3], v161.fields[4])

        else: 
            v173 = US7(1, v161.fields[0])

        v193: US8
        if v173.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method33(v173.fields[0], v173.fields[1], v173.fields[2], v173.fields[3], v173.fields[4])
            v193 = US8(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v193 = US8(1, v173.fields[0])

        v203: US8 = US8(0, v193.fields[0], v193.fields[1], v193.fields[2], v193.fields[3], v193.fields[4]) if (v193.tag == 0) else US8(0, "", v25, v26, v27, v28)
        if v203.tag == 0:
            v208: int = v203.fields[4] or 0
            v207: int = v203.fields[3] or 0
            v206: Any = v203.fields[2]
            v205: str = v203.fields[1]
            v212: US7 = method34(v205, v206, v207, v208, UH1(1, v18_1, UH1(1, v19_1, UH1(0))))
            v235 = US8(0, v203.fields[0], v212.fields[1], v212.fields[2], v212.fields[3], v212.fields[4]) if (v212.tag == 0) else US8(1, to_text(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v212.fields[0], (v9, v15, 1, 1), (v25, v26, v27, v28), (v205, v206, v207, v208)])))

        else: 
            v235 = US8(1, "parsing.between / expected content")


    else: 
        v235 = US8(1, v23.fields[0])

    v493: US8
    if v235.tag == 0:
        v493 = v235

    else: 
        v384: US7
        if "" == v9:
            v384 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'", " "])), (v15, 1, 1)])))

        else: 
            v266: str = v9[0]
            if method35(v266, int64(0)) == False:
                v301: int = (len(v9) - 1) or 0
                v303: str = v9[1:v301 + 1]
                v309: str = v266
                v312: int = len(v309) or 0
                v313: Array[str] = fill([0] * v312, 0, v312, "")
                v314: Mut5 = Mut5(0)
                while method27(v312, v314):
                    v316: int = v314.l0 or 0
                    v317: str = v309[v316]
                    v313[v316] = v317
                    v318: int = (v316 + 1) or 0
                    v314.l0 = v318 or 0
                v320: FSharpList[str] = of_array(v313)
                pattern_input_2: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v320, UH0(0)), v15, 1, 1)
                v384 = US7(0, v266, v303, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

            else: 
                v384 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v266, to_array(of_array(["\"", "\'", " "])), (v15, 1, 1)])))


        v396: US7
        if v384.tag == 0:
            v385: str = v384.fields[0]
            v396 = US7(0, "/" if ("\\" == v385) else v385, v384.fields[1], v384.fields[2], v384.fields[3], v384.fields[4])

        else: 
            v396 = US7(1, v384.fields[0])

        v416: US8
        if v396.tag == 0:
            pattern_input_3: tuple[str, str, Any, int, int] = method36(v396.fields[0], v396.fields[1], v396.fields[2], v396.fields[3], v396.fields[4])
            v416 = US8(0, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2], pattern_input_3[3], pattern_input_3[4])

        else: 
            v416 = US8(1, v396.fields[0])

        if v416.tag == 0:
            v493 = v416

        else: 
            v431: US10 = US10(0, v9, v15, 1, 1) if (len(v9) == 0) else US10(1, to_text(interpolate("parsing.eof / expected end of input / input: %A%P()", [v9])))
            v440: US8 = US8(0, "", v431.fields[0], v431.fields[1], v431.fields[2], v431.fields[3]) if (v431.tag == 0) else US8(1, v431.fields[0])
            if v440.tag == 0:
                v442: str = v440.fields[1]
                v447: int = method37(v442, 0) or 0
                v479: int = (len(v442) - 1) or 0
                v493 = US8(0, v440.fields[0], v442[v447:v479 + 1], v440.fields[2], v440.fields[3], v440.fields[4])

            else: 
                v493 = US8(1, v440.fields[0])



    v821: US11
    if v493.tag == 0:
        v498: int = v493.fields[4] or 0
        v497: int = v493.fields[3] or 0
        v496: Any = v493.fields[2]
        v495: str = v493.fields[1]
        v658: US7
        if "" == v495:
            v658 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", [" ", (v496, v497, v498)])))

        else: 
            v505: str = v495[0]
            if v505 == " ":
                v538: int = (len(v495) - 1) or 0
                v540: str = v495[1:v538 + 1]
                v546: str = v505
                v549: int = len(v546) or 0
                v550: Array[str] = fill([0] * v549, 0, v549, "")
                v551: Mut5 = Mut5(0)
                while method27(v549, v551):
                    v553: int = v551.l0 or 0
                    v554: str = v546[v553]
                    v550[v553] = v554
                    v555: int = (v553 + 1) or 0
                    v551.l0 = v555 or 0
                v557: FSharpList[str] = of_array(v550)
                pattern_input_4: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v557, UH0(0)), v496, v497, v498)
                v658 = US7(0, v505, v540, pattern_input_4[0], pattern_input_4[1], pattern_input_4[2])

            else: 
                v600: int = (v495.find("\n") - 1) or 0
                v636: int = (((len(v495) + 1) if (-2 == v600) else (v600 + 1)) - 1) or 0
                v658 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str(" ")) + "\' / line: ") + str(v497)) + " / col: ") + str(v498)) + "\n") + str(v496)) + "") + v495[0:v636 + 1]) + "", "\n", method30(v498 - 1, 0)("") + "^", *"\n"))


        v670: US12 = US12(0, US9(0, v658.fields[0]), v658.fields[1], v658.fields[2], v658.fields[3], v658.fields[4]) if (v658.tag == 0) else US12(0, US9(1), v495, v496, v497, v498)
        v795: US8
        if v670.tag == 0:
            v675: int = v670.fields[4] or 0
            v674: int = v670.fields[3] or 0
            v673: Any = v670.fields[2]
            v672: str = v670.fields[1]
            v771: US7
            if "" == v672:
                v771 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v673, v674, v675)])))

            else: 
                v682: str = v672[0]
                v714: int = (len(v672) - 1) or 0
                v716: str = v672[1:v714 + 1]
                v722: str = v682
                v725: int = len(v722) or 0
                v726: Array[str] = fill([0] * v725, 0, v725, "")
                v727: Mut5 = Mut5(0)
                while method27(v725, v727):
                    v729: int = v727.l0 or 0
                    v730: str = v722[v729]
                    v726[v729] = v730
                    v731: int = (v729 + 1) or 0
                    v727.l0 = v731 or 0
                v733: FSharpList[str] = of_array(v726)
                pattern_input_5: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v733, UH0(0)), v673, v674, v675)
                v771 = US7(0, v682, v716, pattern_input_5[0], pattern_input_5[1], pattern_input_5[2])

            if v771.tag == 0:
                pattern_input_6: tuple[str, str, Any, int, int] = method38(v771.fields[0], v771.fields[1], v771.fields[2], v771.fields[3], v771.fields[4])
                v795 = US8(0, pattern_input_6[0], pattern_input_6[1], pattern_input_6[2], pattern_input_6[3], pattern_input_6[4])

            else: 
                v795 = US8(1, v771.fields[0])


        else: 
            v795 = US8(1, v670.fields[0])

        v807: US13 = US13(0, US5(0, v795.fields[0]), v795.fields[1], v795.fields[2], v795.fields[3], v795.fields[4]) if (v795.tag == 0) else US13(0, US5(1), v495, v496, v497, v498)
        v821 = US11(0, v493.fields[0], v807.fields[0], v807.fields[1], v807.fields[2], v807.fields[3], v807.fields[4]) if (v807.tag == 0) else US11(1, v807.fields[0])

    else: 
        v821 = US11(1, v493.fields[0])

    if v821.tag == 0:
        return US6(0, v821.fields[0], v821.fields[1])

    else: 
        return US6(1, v821.fields[0])



def method39(__unit: None=None) -> str:
    v3: str = "Debug".lower()
    return ("\u001b[94m" + method13(v3[0])) + method15()


def method41(v0_1: str, v1_1: US5, v2_1: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None=None) -> str:
    v10: Mut3 = Mut3(method14())
    v18_1: None
    closure7(v10, "{ ", None)
    v18_1 = None
    v28: None
    closure7(v10, "file_name", None)
    v28 = None
    v38: None
    closure7(v10, " = ", None)
    v38 = None
    v47: None
    closure7(v10, v0_1, None)
    v47 = None
    v57: None
    closure7(v10, "; ", None)
    v57 = None
    v67: None
    closure7(v10, "arguments", None)
    v67 = None
    v76: None
    closure7(v10, " = ", None)
    v76 = None
    v89: None
    closure7(v10, to_text(interpolate("%A%P()", [v1_1])), None)
    v89 = None
    v98: None
    closure7(v10, "; ", None)
    v98 = None
    v108: None
    closure7(v10, "options", None)
    v108 = None
    v117: None
    closure7(v10, " = ", None)
    v117 = None
    v126: None
    closure7(v10, "{ ", None)
    v126 = None
    v136: None
    closure7(v10, "command", None)
    v136 = None
    v145: None
    closure7(v10, " = ", None)
    v145 = None
    v154: None
    closure7(v10, v2_1, None)
    v154 = None
    v163: None
    closure7(v10, "; ", None)
    v163 = None
    v173: None
    closure7(v10, "cancellation_token", None)
    v173 = None
    v182: None
    closure7(v10, " = ", None)
    v182 = None
    v230: None
    closure7(v10, to_text(interpolate("%A%P()", [v3])), None)
    v230 = None
    v239: None
    closure7(v10, "; ", None)
    v239 = None
    v249: None
    closure7(v10, "environment_variables", None)
    v249 = None
    v258: None
    closure7(v10, " = ", None)
    v258 = None
    v271: None
    closure7(v10, to_text(interpolate("%A%P()", [v4])), None)
    v271 = None
    v280: None
    closure7(v10, "; ", None)
    v280 = None
    v290: None
    closure7(v10, "on_line", None)
    v290 = None
    v299: None
    closure7(v10, " = ", None)
    v299 = None
    v347: None
    closure7(v10, to_text(interpolate("%A%P()", [v5])), None)
    v347 = None
    v356: None
    closure7(v10, "; ", None)
    v356 = None
    v366: None
    closure7(v10, "stdin", None)
    v366 = None
    v375: None
    closure7(v10, " = ", None)
    v375 = None
    v423: None
    closure7(v10, to_text(interpolate("%A%P()", [v6])), None)
    v423 = None
    v432: None
    closure7(v10, "; ", None)
    v432 = None
    v442: None
    closure7(v10, "trace", None)
    v442 = None
    v451: None
    closure7(v10, " = ", None)
    v451 = None
    v463: None
    closure7(v10, "true" if v7 else "false", None)
    v463 = None
    v472: None
    closure7(v10, "; ", None)
    v472 = None
    v482: None
    closure7(v10, "working_directory", None)
    v482 = None
    v491: None
    closure7(v10, " = ", None)
    v491 = None
    v539: None
    closure7(v10, to_text(interpolate("%A%P()", [v8])), None)
    v539 = None
    v549: None
    closure7(v10, " }", None)
    v549 = None
    v558: None
    closure7(v10, " }", None)
    v558 = None
    return v10.l0


def method40(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: US5, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15: bool, v16: str | None=None) -> str:
    v17_1: str = method41(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v17_1) + "")


def closure19(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: US5, v8: str, unit_var: None) -> None:
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
        method19(method40(v34, v35, v36, v37, v38, v39, method8(v34, v35, v36, v37, v38, v39), method39(), v8, v7, v0_1, v1_1, v2_1, v3, v4, v5, v6))



def method42(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Array[tuple[str, str]]:
    return v2_1


def method45(v0_1: bool) -> str:
    return None


def closure21(unit_var: None, v0_1: Callable[[tuple[int, str, bool]], Async[None]]) -> US14:
    return US14(0, v0_1)


def method46(__unit: None=None) -> Callable[[Callable[[tuple[int, str, bool]], Async[None]]], US14]:
    def _arrow246(v: Callable[[tuple[int, str, bool]], Async[None]]) -> US14:
        return closure21(None, v)

    return _arrow246


def method47(v0_1: bool) -> int:
    return None


def method48(__unit: None=None) -> str:
    v3: str = "Verbose".lower()
    return ("\u001b[90m" + method13(v3[0])) + method15()


def method49(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v9: str = method17()
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + v8) + " / ") + v9) + "")


def closure22(v0_1: str, unit_var: None) -> None:
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
    def _arrow259(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, v9: Any=v9, v10: Any=v10) -> Async[None]:
        v821: str = method45(v10)
        v827: bool = (v821 is None) != True
        def _arrow257(__unit: None=None) -> Async[None]:
            v844: US14 = default_arg(map(method46(), v3), US14(1))
            def _arrow251(__unit: None=None) -> Async[None]:
                v850: Async[None] = v844.fields[0]((method47(v7), v821, v9))
                def _arrow250(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v850, _arrow250)

            def _expr252():
                return singleton.Zero()

            def _arrow256(__unit: None=None) -> Async[None]:
                v853: str = concat("! ", *v821) if v9 else concat("> ", *v821)
                def _arrow253(__unit: None=None) -> Async[None]:
                    v856: None
                    closure22(v853, None)
                    v856 = None
                    return singleton.Zero()

                def _arrow254(__unit: None=None) -> Async[None]:
                    v908: None
                    closure10(v853, None)
                    v908 = None
                    return singleton.Zero()

                def _arrow255(__unit: None=None) -> Async[None]:
                    v916: str = concat("\u001b[7;4m" if v9 else "", v821, *"\u001b[0m" if v9 else "")
                    return singleton.Zero()

                return singleton.Combine(_arrow253() if v5 else _arrow254(), singleton.Delay(_arrow255))

            return singleton.Combine(_arrow251() if (v844.tag == 0) else _expr252(), singleton.Delay(_arrow256))

        def _arrow258(__unit: None=None) -> Async[None]:
            return singleton.Zero()

        return singleton.Combine(_arrow257() if v827 else singleton.Zero(), singleton.Delay(_arrow258))

    return singleton.Delay(_arrow259)


def method43(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> Async[None]:
    return method44(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10)


def closure20(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> None:
    start_immediate(method43(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10))


def closure23(unit_var: None, v0_1: CancellationToken) -> US15:
    return US15(0, v0_1)


def method50(__unit: None=None) -> Callable[[CancellationToken], US15]:
    def _arrow260(v: CancellationToken) -> US15:
        return closure23(None, v)

    return _arrow260


def method51(v0_1: CancellationToken) -> Async[CancellationToken]:
    def _arrow261(__unit: None=None, v0_1: Any=v0_1) -> Async[CancellationToken]:
        return singleton.Return(None)

    return singleton.Delay(_arrow261)


def method52(v0_1: bool) -> bool:
    return None


def method53(v0_1: bool) -> None:
    pass


def closure24(v0_1: bool, unit_var: None) -> None:
    if method52(v0_1) == False:
        method53(v0_1)



def method56(v0_1: Any) -> str:
    v2_1: Mut3 = Mut3(method14())
    v10: None
    closure7(v2_1, "{ ", None)
    v10 = None
    v20_1: None
    closure7(v2_1, "ex", None)
    v20_1 = None
    v30: None
    closure7(v2_1, " = ", None)
    v30 = None
    v78: None
    closure7(v2_1, to_text(interpolate("%A%P()", [v0_1])), None)
    v78 = None
    v88: None
    closure7(v2_1, " }", None)
    v88 = None
    return v2_1.l0


def method55(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: Any) -> str:
    v9: str = method56(v8)
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "runtime.execute_with_options_async / WaitForExitAsync") + " / ") + v9) + "")


def closure25(v0_1: Any, unit_var: None) -> None:
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
    def _arrow270(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1) -> Async[int]:
        def _arrow268(__unit: None=None) -> Async[int]:
            v3205: Async[None] = await_task(None)
            def _arrow267(__unit: None=None) -> Async[int]:
                return singleton.Return(None)

            return singleton.Bind(v3205, _arrow267)

        def _arrow269(_arg_1: Exception) -> Async[int]:
            v3355: Exception = _arg_1
            v3378: str = to_text(interpolate("%A%P()", [v3355]))
            v3400: None
            closure25(v3355, None)
            v3400 = None
            return singleton.Return(-2147483648)

        return singleton.TryWith(singleton.Delay(_arrow268), _arrow269)

    return singleton.Delay(_arrow270)


def method57(__unit: None=None) -> str:
    return "\n"


def method59(v0_1: int, v1_1: int, v2_1: str, v3: CancellationToken | None, v4: Array[tuple[str, str]], v5: Callable[[tuple[int, str, bool]], Async[None]] | None, v6: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v7: bool, v8: str | None=None) -> str:
    v10: Mut3 = Mut3(method14())
    v18_1: None
    closure7(v10, "{ ", None)
    v18_1 = None
    v28: None
    closure7(v10, "exit_code", None)
    v28 = None
    v38: None
    closure7(v10, " = ", None)
    v38 = None
    v47: None
    closure7(v10, ("" + str(v0_1)) + "", None)
    v47 = None
    v57: None
    closure7(v10, "; ", None)
    v57 = None
    v67: None
    closure7(v10, "output_length", None)
    v67 = None
    v76: None
    closure7(v10, " = ", None)
    v76 = None
    v85: None
    closure7(v10, ("" + str(v1_1)) + "", None)
    v85 = None
    v94: None
    closure7(v10, "; ", None)
    v94 = None
    v104: None
    closure7(v10, "options", None)
    v104 = None
    v113: None
    closure7(v10, " = ", None)
    v113 = None
    v122: None
    closure7(v10, "{ ", None)
    v122 = None
    v132: None
    closure7(v10, "command", None)
    v132 = None
    v141: None
    closure7(v10, " = ", None)
    v141 = None
    v150: None
    closure7(v10, v2_1, None)
    v150 = None
    v159: None
    closure7(v10, "; ", None)
    v159 = None
    v169: None
    closure7(v10, "cancellation_token", None)
    v169 = None
    v178: None
    closure7(v10, " = ", None)
    v178 = None
    v226: None
    closure7(v10, to_text(interpolate("%A%P()", [v3])), None)
    v226 = None
    v235: None
    closure7(v10, "; ", None)
    v235 = None
    v245: None
    closure7(v10, "environment_variables", None)
    v245 = None
    v254: None
    closure7(v10, " = ", None)
    v254 = None
    v267: None
    closure7(v10, to_text(interpolate("%A%P()", [v4])), None)
    v267 = None
    v276: None
    closure7(v10, "; ", None)
    v276 = None
    v286: None
    closure7(v10, "on_line", None)
    v286 = None
    v295: None
    closure7(v10, " = ", None)
    v295 = None
    v343: None
    closure7(v10, to_text(interpolate("%A%P()", [v5])), None)
    v343 = None
    v352: None
    closure7(v10, "; ", None)
    v352 = None
    v362: None
    closure7(v10, "stdin", None)
    v362 = None
    v371: None
    closure7(v10, " = ", None)
    v371 = None
    v419: None
    closure7(v10, to_text(interpolate("%A%P()", [v6])), None)
    v419 = None
    v428: None
    closure7(v10, "; ", None)
    v428 = None
    v438: None
    closure7(v10, "trace", None)
    v438 = None
    v447: None
    closure7(v10, " = ", None)
    v447 = None
    v459: None
    closure7(v10, "true" if v7 else "false", None)
    v459 = None
    v468: None
    closure7(v10, "; ", None)
    v468 = None
    v478: None
    closure7(v10, "working_directory", None)
    v478 = None
    v487: None
    closure7(v10, " = ", None)
    v487 = None
    v535: None
    closure7(v10, to_text(interpolate("%A%P()", [v8])), None)
    v535 = None
    v545: None
    closure7(v10, " }", None)
    v545 = None
    v554: None
    closure7(v10, " }", None)
    v554 = None
    return v10.l0


def method58(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: int, v10: str, v11: CancellationToken | None, v12: Array[tuple[str, str]], v13: Callable[[tuple[int, str, bool]], Async[None]] | None, v14: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v15: bool, v16: str | None=None) -> str:
    v17_1: str = method59(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    return method18(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v17_1) + "")


def closure26(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: int, v8: str, unit_var: None) -> None:
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
        method19(method58(v34, v35, v36, v37, v38, v39, method8(v34, v35, v36, v37, v38, v39), method39(), v7, len(v8), v0_1, v1_1, v2_1, v3, v4, v5, v6))



def method24(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Async[tuple[int, str]]:
    def _arrow271(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6) -> Async[tuple[int, str]]:
        pattern_input: tuple[int, str] = None
        return singleton.Return((pattern_input[0], pattern_input[1]))

    return singleton.Delay(_arrow271)


def method23(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None=None) -> Async[tuple[int, str]]:
    return method24(v0_1, v1_1, v2_1, v3, v4, v5, v6)


def method22(v0_1: str) -> Async[tuple[int, str]]:
    return method23(v0_1, None, [], None, None, True, None)


def closure13(unit_var: None, v0_1: str) -> Async[tuple[int, str]]:
    return method22(v0_1)


def closure27(unit_var: None, _arg: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return method23(_arg[0], _arg[1], _arg[2], _arg[3], _arg[4], _arg[5], _arg[6])


def closure28(unit_var: None, v0_1: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
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




            def _arrow272(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v19_1.fields[0] if (v19_1.tag == 0) else _arrow272()):
                return True

            else: 
                v0_1_mut = v0_1
                v1_1_mut = op_addition(v1_1, int64(1))
                continue


        break


def method63(v0_1_mut: str, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v153: US7
        if "" == v1_1:
            v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))

        else: 
            v33: str = v1_1[0]
            if method62(v33, int64(0)) == False:
                v68: int = (len(v1_1) - 1) or 0
                v70: str = v1_1[1:v68 + 1]
                v76: str = v33
                v79: int = len(v76) or 0
                v80: Array[str] = fill([0] * v79, 0, v79, "")
                v81: Mut5 = Mut5(0)
                while method27(v79, v81):
                    v83: int = v81.l0 or 0
                    v84: str = v76[v83]
                    v80[v83] = v84
                    v85: int = (v83 + 1) or 0
                    v81.l0 = v85 or 0
                v87: FSharpList[str] = of_array(v80)
                pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v87, UH0(0)), v2_1, v3, v4)
                v153 = US7(0, v33, v70, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))


        if v153.tag == 0:
            v0_1_mut = v0_1 + v153.fields[0]
            v1_1_mut = v153.fields[1]
            v2_1_mut = v153.fields[2]
            v3_mut = v153.fields[3]
            v4_mut = v153.fields[4]
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



            def _arrow273(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v15.fields[0] if (v15.tag == 0) else _arrow273()):
                return True

            else: 
                v0_1_mut = v0_1
                v1_1_mut = op_addition(v1_1, int64(1))
                continue


        break


def closure30(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2_1: int = _arg[2] or 0
    v1_1: Any = _arg[1]
    v0_1: str = _arg[0]
    v164: US7
    if "" == v0_1:
        v164 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\\", (v1_1, v2_1, v3)])))

    else: 
        v10: str = v0_1[0]
        if v10 == "\\":
            v43: int = (len(v0_1) - 1) or 0
            v45: str = v0_1[1:v43 + 1]
            v51: str = v10
            v54: int = len(v51) or 0
            v55: Array[str] = fill([0] * v54, 0, v54, "")
            v56: Mut5 = Mut5(0)
            while method27(v54, v56):
                v58: int = v56.l0 or 0
                v59: str = v51[v58]
                v55[v58] = v59
                v60: int = (v58 + 1) or 0
                v56.l0 = v60 or 0
            v62: FSharpList[str] = of_array(v55)
            pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v62, UH0(0)), v1_1, v2_1, v3)
            v164 = US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v105: int = (v0_1.find("\n") - 1) or 0
            v141: int = (((len(v0_1) + 1) if (-2 == v105) else (v105 + 1)) - 1) or 0
            v164 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\\")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v141 + 1]) + "", "\n", method30(v3 - 1, 0)("") + "^", *"\n"))


    v269: US7
    if v164.tag == 0:
        v169: int = v164.fields[4] or 0
        v168: int = v164.fields[3] or 0
        v167: Any = v164.fields[2]
        v166: str = v164.fields[1]
        if "" == v166:
            v269 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v167, v168, v169)])))

        else: 
            v176: str = v166[0]
            v208: int = (len(v166) - 1) or 0
            v210: str = v166[1:v208 + 1]
            v216: str = v176
            v219: int = len(v216) or 0
            v220: Array[str] = fill([0] * v219, 0, v219, "")
            v221: Mut5 = Mut5(0)
            while method27(v219, v221):
                v223: int = v221.l0 or 0
                v224: str = v216[v223]
                v220[v223] = v224
                v225: int = (v223 + 1) or 0
                v221.l0 = v225 or 0
            v227: FSharpList[str] = of_array(v220)
            pattern_input_1: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v227, UH0(0)), v167, v168, v169)
            v269 = US7(0, v176, v210, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v269 = US7(1, v164.fields[0])

    if v269.tag == 0:
        return US8(0, "\\" + v269.fields[0], v269.fields[1], v269.fields[2], v269.fields[3], v269.fields[4])

    else: 
        return US8(1, v269.fields[0])



def closure31(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2_1: int = _arg[2] or 0
    v1_1: Any = _arg[1]
    v0_1: str = _arg[0]
    v164: US7
    if "" == v0_1:
        v164 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["`", (v1_1, v2_1, v3)])))

    else: 
        v10: str = v0_1[0]
        if v10 == "`":
            v43: int = (len(v0_1) - 1) or 0
            v45: str = v0_1[1:v43 + 1]
            v51: str = v10
            v54: int = len(v51) or 0
            v55: Array[str] = fill([0] * v54, 0, v54, "")
            v56: Mut5 = Mut5(0)
            while method27(v54, v56):
                v58: int = v56.l0 or 0
                v59: str = v51[v58]
                v55[v58] = v59
                v60: int = (v58 + 1) or 0
                v56.l0 = v60 or 0
            v62: FSharpList[str] = of_array(v55)
            pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v62, UH0(0)), v1_1, v2_1, v3)
            v164 = US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v105: int = (v0_1.find("\n") - 1) or 0
            v141: int = (((len(v0_1) + 1) if (-2 == v105) else (v105 + 1)) - 1) or 0
            v164 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("`")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v141 + 1]) + "", "\n", method30(v3 - 1, 0)("") + "^", *"\n"))


    v269: US7
    if v164.tag == 0:
        v169: int = v164.fields[4] or 0
        v168: int = v164.fields[3] or 0
        v167: Any = v164.fields[2]
        v166: str = v164.fields[1]
        if "" == v166:
            v269 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v167, v168, v169)])))

        else: 
            v176: str = v166[0]
            v208: int = (len(v166) - 1) or 0
            v210: str = v166[1:v208 + 1]
            v216: str = v176
            v219: int = len(v216) or 0
            v220: Array[str] = fill([0] * v219, 0, v219, "")
            v221: Mut5 = Mut5(0)
            while method27(v219, v221):
                v223: int = v221.l0 or 0
                v224: str = v216[v223]
                v220[v223] = v224
                v225: int = (v223 + 1) or 0
                v221.l0 = v225 or 0
            v227: FSharpList[str] = of_array(v220)
            pattern_input_1: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v227, UH0(0)), v167, v168, v169)
            v269 = US7(0, v176, v210, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v269 = US7(1, v164.fields[0])

    if v269.tag == 0:
        return US8(0, "`" + v269.fields[0], v269.fields[1], v269.fields[2], v269.fields[3], v269.fields[4])

    else: 
        return US8(1, v269.fields[0])



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
        v145: US7
        if "" == v1_1:
            v145 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))

        else: 
            v29: str = v1_1[0]
            if method65(v29, int64(0)) == False:
                v64: int = (len(v1_1) - 1) or 0
                v66: str = v1_1[1:v64 + 1]
                v72: str = v29
                v75: int = len(v72) or 0
                v76: Array[str] = fill([0] * v75, 0, v75, "")
                v77: Mut5 = Mut5(0)
                while method27(v75, v77):
                    v79: int = v77.l0 or 0
                    v80: str = v72[v79]
                    v76[v79] = v80
                    v81: int = (v79 + 1) or 0
                    v77.l0 = v81 or 0
                v83: FSharpList[str] = of_array(v76)
                pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v83, UH0(0)), v2_1, v3, v4)
                v145 = US7(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v145 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))


        v160: US8 = US8(0, v145.fields[0], v145.fields[1], v145.fields[2], v145.fields[3], v145.fields[4]) if (v145.tag == 0) else US8(1, v145.fields[0])
        def v167(_arg10: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
            return closure30(None, _arg10)

        def v168(_arg10_1: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
            return closure31(None, _arg10_1)

        v174: US8 = v160 if (v160.tag == 0) else method66(v1_1, v2_1, v3, v4, UH3(1, v167, UH3(1, v168, UH3(0))))
        if v174.tag == 0:
            v0_1_mut = UH2(1, v174.fields[0], v0_1)
            v1_1_mut = v174.fields[1]
            v2_1_mut = v174.fields[2]
            v3_mut = v174.fields[3]
            v4_mut = v174.fields[4]
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
        v145: US7
        if "" == v1_1:
            v145 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))

        else: 
            v29: str = v1_1[0]
            if method65(v29, int64(0)) == False:
                v64: int = (len(v1_1) - 1) or 0
                v66: str = v1_1[1:v64 + 1]
                v72: str = v29
                v75: int = len(v72) or 0
                v76: Array[str] = fill([0] * v75, 0, v75, "")
                v77: Mut5 = Mut5(0)
                while method27(v75, v77):
                    v79: int = v77.l0 or 0
                    v80: str = v72[v79]
                    v76[v79] = v80
                    v81: int = (v79 + 1) or 0
                    v77.l0 = v81 or 0
                v83: FSharpList[str] = of_array(v76)
                pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v83, UH0(0)), v2_1, v3, v4)
                v145 = US7(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v145 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))


        v160: US8 = US8(0, v145.fields[0], v145.fields[1], v145.fields[2], v145.fields[3], v145.fields[4]) if (v145.tag == 0) else US8(1, v145.fields[0])
        if v160.tag == 0:
            v0_1_mut = UH2(1, v160.fields[0], v0_1)
            v1_1_mut = v160.fields[1]
            v2_1_mut = v160.fields[2]
            v3_mut = v160.fields[3]
            v4_mut = v160.fields[4]
            continue

        else: 
            return US17(0, method67(v0_1, UH2(0)), v1_1, v2_1, v3, v4)

        break


def method61(v0_1_mut: UH2, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> US17:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v5: bool = "" == v1_1
        v153: US7
        if v5:
            v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))

        else: 
            v33: str = v1_1[0]
            if method62(v33, int64(0)) == False:
                v68: int = (len(v1_1) - 1) or 0
                v70: str = v1_1[1:v68 + 1]
                v76: str = v33
                v79: int = len(v76) or 0
                v80: Array[str] = fill([0] * v79, 0, v79, "")
                v81: Mut5 = Mut5(0)
                while method27(v79, v81):
                    v83: int = v81.l0 or 0
                    v84: str = v76[v83]
                    v80[v83] = v84
                    v85: int = (v83 + 1) or 0
                    v81.l0 = v85 or 0
                v87: FSharpList[str] = of_array(v80)
                pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v87, UH0(0)), v2_1, v3, v4)
                v153 = US7(0, v33, v70, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))


        v173: US8
        if v153.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method63(v153.fields[0], v153.fields[1], v153.fields[2], v153.fields[3], v153.fields[4])
            v173 = US8(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v173 = US8(1, v153.fields[0])

        v635: US8
        if v173.tag == 0:
            v635 = v173

        else: 
            v339: US7
            if v5:
                v339 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v2_1, v3, v4)])))

            else: 
                v185: str = v1_1[0]
                if v185 == "\"":
                    v218: int = (len(v1_1) - 1) or 0
                    v220: str = v1_1[1:v218 + 1]
                    v226: str = v185
                    v229: int = len(v226) or 0
                    v230: Array[str] = fill([0] * v229, 0, v229, "")
                    v231: Mut5 = Mut5(0)
                    while method27(v229, v231):
                        v233: int = v231.l0 or 0
                        v234: str = v226[v233]
                        v230[v233] = v234
                        v235: int = (v233 + 1) or 0
                        v231.l0 = v235 or 0
                    v237: FSharpList[str] = of_array(v230)
                    pattern_input_2: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v237, UH0(0)), v2_1, v3, v4)
                    v339 = US7(0, v185, v220, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

                else: 
                    v280: int = (v1_1.find("\n") - 1) or 0
                    v316: int = (((len(v1_1) + 1) if (-2 == v280) else (v280 + 1)) - 1) or 0
                    v339 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v3)) + " / col: ") + str(v4)) + "\n") + str(v2_1)) + "") + v1_1[0:v316 + 1]) + "", "\n", method30(v4 - 1, 0)("") + "^", *"\n"))


            v566: US8
            if v339.tag == 0:
                v344: int = v339.fields[4] or 0
                v343: int = v339.fields[3] or 0
                v342: Any = v339.fields[2]
                v341: str = v339.fields[1]
                v346: US17 = method64(UH2(0), v341, v342, v343, v344)
                v377: US8
                if v346.tag == 0:
                    v353: FSharpList[str] = method68(v346.fields[0], empty())
                    def _arrow274(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v353

                    v377 = US8(0, join("", delay(_arrow274)), v346.fields[1], v346.fields[2], v346.fields[3], v346.fields[4])

                else: 
                    v377 = US8(1, v346.fields[0])

                if v377.tag == 0:
                    v382: int = v377.fields[4] or 0
                    v381: int = v377.fields[3] or 0
                    v380: Any = v377.fields[2]
                    v379: str = v377.fields[1]
                    v543: US7
                    if "" == v379:
                        v543 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v380, v381, v382)])))

                    else: 
                        v389: str = v379[0]
                        if v389 == "\"":
                            v422: int = (len(v379) - 1) or 0
                            v424: str = v379[1:v422 + 1]
                            v430: str = v389
                            v433: int = len(v430) or 0
                            v434: Array[str] = fill([0] * v433, 0, v433, "")
                            v435: Mut5 = Mut5(0)
                            while method27(v433, v435):
                                v437: int = v435.l0 or 0
                                v438: str = v430[v437]
                                v434[v437] = v438
                                v439: int = (v437 + 1) or 0
                                v435.l0 = v439 or 0
                            v441: FSharpList[str] = of_array(v434)
                            pattern_input_3: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v441, UH0(0)), v380, v381, v382)
                            v543 = US7(0, v389, v424, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2])

                        else: 
                            v484: int = (v379.find("\n") - 1) or 0
                            v520: int = (((len(v379) + 1) if (-2 == v484) else (v484 + 1)) - 1) or 0
                            v543 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v381)) + " / col: ") + str(v382)) + "\n") + str(v380)) + "") + v379[0:v520 + 1]) + "", "\n", method30(v382 - 1, 0)("") + "^", *"\n"))


                    v566 = US8(0, v377.fields[0], v543.fields[1], v543.fields[2], v543.fields[3], v543.fields[4]) if (v543.tag == 0) else US8(1, to_text(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v543.fields[0], (v1_1, v2_1, v3, v4), (v341, v342, v343, v344), (v379, v380, v381, v382)])))

                else: 
                    v566 = US8(1, "parsing.between / expected content")


            else: 
                v566 = US8(1, v339.fields[0])

            if v566.tag == 0:
                v635 = v566

            else: 
                def v573(_arg10: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
                    return closure30(None, _arg10)

                def v574(_arg10_1: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
                    return closure31(None, _arg10_1)

                v578: US8 = method66(v1_1, v2_1, v3, v4, UH3(1, v573, UH3(1, v574, UH3(0))))
                v589: US8 = US8(0, "", v578.fields[1], v578.fields[2], v578.fields[3], v578.fields[4]) if (v578.tag == 0) else US8(1, v578.fields[0])
                v600: US17 = method69(UH2(0), v589.fields[1], v589.fields[2], v589.fields[3], v589.fields[4]) if (v589.tag == 0) else US17(1, v589.fields[0])
                if v600.tag == 0:
                    v607: FSharpList[str] = method68(v600.fields[0], empty())
                    def _arrow275(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v607

                    v635 = US8(0, join("", delay(_arrow275)), v600.fields[1], v600.fields[2], v600.fields[3], v600.fields[4])

                else: 
                    v635 = US8(1, v600.fields[0])



        if v635.tag == 0:
            v640: int = v635.fields[4] or 0
            v639: int = v635.fields[3] or 0
            v638: Any = v635.fields[2]
            v637: str = v635.fields[1]
            v636: str = v635.fields[0]
            v642: int = method37(v637, 0) or 0
            v684: US10
            if 0 == v642:
                v684 = US10(1, "parsing.spaces1 / expected at least one space")

            else: 
                v677: int = (len(v637) - 1) or 0
                v684 = US10(0, v637[v642:v677 + 1], v638, v639, v640)

            if v684.tag == 0:
                v0_1_mut = UH2(1, v636, v0_1)
                v1_1_mut = v684.fields[0]
                v2_1_mut = v684.fields[1]
                v3_mut = v684.fields[2]
                v4_mut = v684.fields[3]
                continue

            else: 
                return US17(0, method67(v0_1, UH2(1, v636, UH2(0))), v637, v638, v639, v640)


        else: 
            return US17(0, method67(v0_1, UH2(0)), v1_1, v2_1, v3, v4)

        break


def method60(v0_1: str) -> US16:
    _v0: (str | None) | None = None
    _v0 = some(v0_1)
    def _arrow276(__unit: None=None, v0_1: Any=v0_1) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v21_1: US17 = method61(UH2(0), default_arg(_arrow276() if (_v0 is None) else value_12(_v0), ""), StringBuilder__ctor_Z721C83C5(method26()), 1, 1)
    if v21_1.tag == 0:
        return US16(0, to_array(method68(v21_1.fields[0], empty())))

    else: 
        return US16(1, v21_1.fields[0])



def closure29(unit_var: None, v0_1: str) -> FSharpResult_2[Array[str], str]:
    v1_1: US16 = method60(v0_1)
    if v1_1.tag == 0:
        return FSharpResult_2(0, v1_1.fields[0])

    else: 
        return FSharpResult_2(1, v1_1.fields[0])



v0: None = None

def _arrow277(__unit: None=None) -> None:
    closure0(None, None)


v1: Callable[[], None] = _arrow277

def _expr278():
    v1(None)
    return v0


v2: None = _expr278()

def _arrow279(__unit: None=None) -> None:
    closure3(None, None)


v17: Callable[[], None] = _arrow279

def current_process_kill(__unit: None=None) -> None:
    v17(None)


def _arrow280(v: str) -> Async[tuple[int, str]]:
    return closure13(None, v)


v18: Callable[[str], Async[tuple[int, str]]] = _arrow280

def execute_async(x: str) -> Async[tuple[int, str]]:
    return v18(x)


def _arrow281(_arg10: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return closure27(None, _arg10)


v19: Callable[[tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]], Async[tuple[int, str]]] = _arrow281

def execute_with_options_async(x: tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]) -> Async[tuple[int, str]]:
    return v19(x)


def _arrow282(v: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    return closure28(None, v)


v20: Callable[[Callable[[Heap0], Heap0]], tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]] = _arrow282

def execution_options(x: Callable[[Heap0], Heap0]) -> tuple[str, CancellationToken | None, Array[tuple[str, str]], Callable[[tuple[int, str, bool]], Async[None]] | None, Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, bool, str | None]:
    return v20(x)


def _arrow283(v: str) -> FSharpResult_2[Array[str], str]:
    return closure29(None, v)


v21: Callable[[str], FSharpResult_2[Array[str], str]] = _arrow283

def split_args(x: str) -> FSharpResult_2[Array[str], str]:
    return v21(x)


