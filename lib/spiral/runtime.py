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


def _expr190() -> TypeInfo:
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


US0_reflection = _expr190

def _expr191() -> TypeInfo:
    return record_type("Runtime.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr191

def _expr192() -> TypeInfo:
    return record_type("Runtime.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr192

def _expr193() -> TypeInfo:
    return record_type("Runtime.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr193

def _expr194() -> TypeInfo:
    return record_type("Runtime.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr194

def _expr195() -> TypeInfo:
    return record_type("Runtime.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr195

def _expr196() -> TypeInfo:
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


US1_reflection = _expr196

def _expr197() -> TypeInfo:
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


US2_reflection = _expr197

def _expr198() -> TypeInfo:
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


US3_reflection = _expr198

def _expr199() -> TypeInfo:
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


US4_reflection = _expr199

def _expr200() -> TypeInfo:
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


US5_reflection = _expr200

def _expr201() -> TypeInfo:
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


US6_reflection = _expr201

def _expr202() -> TypeInfo:
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


US7_reflection = _expr202

def _expr203() -> TypeInfo:
    return record_type("Runtime.Mut5", [], Mut5, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut5(Record):
    l0: int

Mut5_reflection = _expr203

def _expr204() -> TypeInfo:
    return union_type("Runtime.UH0", [], UH0, lambda: [[], [("Item1", char_type), ("Item2", UH0_reflection())]])


class UH0(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH0_0", "UH0_1"]


UH0_reflection = _expr204

def _expr205() -> TypeInfo:
    return union_type("Runtime.UH1", [], UH1, lambda: [[], [("Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US7_reflection())), ("Item2", UH1_reflection())]])


class UH1(Union):
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["UH1_0", "UH1_1"]


UH1_reflection = _expr205

def _expr206() -> TypeInfo:
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


US8_reflection = _expr206

def _expr207() -> TypeInfo:
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


US9_reflection = _expr207

def _expr208() -> TypeInfo:
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


US10_reflection = _expr208

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

    v68: US5 = default_arg(map(method5(), v47), US5(1))
    if v68.tag == 0:
        return v68.fields[0]

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
            v113: int = (v0_1.find("\n") - 1) or 0
            v149: int = (((len(v0_1) + 1) if (-2 == v113) else (v113 + 1)) - 1) or 0
            return US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v149 + 1]) + "", "\n", method30(v3 - 1, 0)("") + "^", *"\n"))




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
            v113: int = (v0_1.find("\n") - 1) or 0
            v149: int = (((len(v0_1) + 1) if (-2 == v113) else (v113 + 1)) - 1) or 0
            return US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\'")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v149 + 1]) + "", "\n", method30(v3 - 1, 0)("") + "^", *"\n"))




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
        v145: US7
        if "" == v1_1:
            v145 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'"])), (v2_1, v3, v4)])))

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
                v145 = US7(0, v25, v62, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v145 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v25, to_array(of_array(["\"", "\'"])), (v2_1, v3, v4)])))


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
        v153: US7
        if "" == v1_1:
            v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'", " "])), (v2_1, v3, v4)])))

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
                v153 = US7(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\"", "\'", " "])), (v2_1, v3, v4)])))


        v165: US7
        if v153.tag == 0:
            v154: str = v153.fields[0]
            v165 = US7(0, "/" if ("\\" == v154) else v154, v153.fields[1], v153.fields[2], v153.fields[3], v153.fields[4])

        else: 
            v165 = US7(1, v153.fields[0])

        if v165.tag == 0:
            v0_1_mut = v0_1 + v165.fields[0]
            v1_1_mut = v165.fields[1]
            v2_1_mut = v165.fields[2]
            v3_mut = v165.fields[3]
            v4_mut = v165.fields[4]
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
        v108: US7
        if "" == v1_1:
            v108 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v2_1, v3, v4)])))

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
            v108 = US7(0, v11, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        if v108.tag == 0:
            v0_1_mut = v0_1 + v108.fields[0]
            v1_1_mut = v108.fields[1]
            v2_1_mut = v108.fields[2]
            v3_mut = v108.fields[3]
            v4_mut = v108.fields[4]
            continue

        else: 
            return (v0_1, v1_1, v2_1, v3, v4)

        break


def method25(v0_1: str) -> US6:
    _v0: (str | None) | None = None
    _v0 = some(v0_1)
    def _arrow232(__unit: None=None, v0_1: Any=v0_1) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v10: str = default_arg(_arrow232() if (_v0 is None) else value_12(_v0), "")
    v16: Any = StringBuilder__ctor_Z721C83C5(method26())
    def v19_1(_arg10: tuple[str, Any, int, int], v0_1: Any=v0_1) -> US7:
        return closure14(None, _arg10)

    def v20_1(_arg10_1: tuple[str, Any, int, int], v0_1: Any=v0_1) -> US7:
        return closure18(None, _arg10_1)

    v24: US7 = method31(v10, v16, UH1(1, v19_1, UH1(1, v20_1, UH1(0))))
    v244: US8
    if v24.tag == 0:
        v29: int = v24.fields[4] or 0
        v28: int = v24.fields[3] or 0
        v27: Any = v24.fields[2]
        v26: str = v24.fields[1]
        v170: US7
        if "" == v26:
            v170 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'"])), (v27, v28, v29)])))

        else: 
            v50: str = v26[0]
            if method32(v50, int64(0)) == False:
                v85: int = (len(v26) - 1) or 0
                v87: str = v26[1:v85 + 1]
                v93: str = v50
                v96: int = len(v93) or 0
                v97: Array[str] = fill([0] * v96, 0, v96, "")
                v98: Mut5 = Mut5(0)
                while method27(v96, v98):
                    v100: int = v98.l0 or 0
                    v101: str = v93[v100]
                    v97[v100] = v101
                    v102: int = (v100 + 1) or 0
                    v98.l0 = v102 or 0
                v104: FSharpList[str] = of_array(v97)
                pattern_input: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v104, UH0(0)), v27, v28, v29)
                v170 = US7(0, v50, v87, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v170 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v50, to_array(of_array(["\"", "\'"])), (v27, v28, v29)])))


        v182: US7
        if v170.tag == 0:
            v171: str = v170.fields[0]
            v182 = US7(0, "/" if ("\\" == v171) else v171, v170.fields[1], v170.fields[2], v170.fields[3], v170.fields[4])

        else: 
            v182 = US7(1, v170.fields[0])

        v202: US8
        if v182.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method33(v182.fields[0], v182.fields[1], v182.fields[2], v182.fields[3], v182.fields[4])
            v202 = US8(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v202 = US8(1, v182.fields[0])

        v212: US8 = US8(0, v202.fields[0], v202.fields[1], v202.fields[2], v202.fields[3], v202.fields[4]) if (v202.tag == 0) else US8(0, "", v26, v27, v28, v29)
        if v212.tag == 0:
            v217: int = v212.fields[4] or 0
            v216: int = v212.fields[3] or 0
            v215: Any = v212.fields[2]
            v214: str = v212.fields[1]
            v221: US7 = method34(v214, v215, v216, v217, UH1(1, v19_1, UH1(1, v20_1, UH1(0))))
            v244 = US8(0, v212.fields[0], v221.fields[1], v221.fields[2], v221.fields[3], v221.fields[4]) if (v221.tag == 0) else US8(1, to_text(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v221.fields[0], (v10, v16, 1, 1), (v26, v27, v28, v29), (v214, v215, v216, v217)])))

        else: 
            v244 = US8(1, "parsing.between / expected content")


    else: 
        v244 = US8(1, v24.fields[0])

    v510: US8
    if v244.tag == 0:
        v510 = v244

    else: 
        v401: US7
        if "" == v10:
            v401 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\"", "\'", " "])), (v16, 1, 1)])))

        else: 
            v275: str = v10[0]
            if method35(v275, int64(0)) == False:
                v310: int = (len(v10) - 1) or 0
                v312: str = v10[1:v310 + 1]
                v318: str = v275
                v321: int = len(v318) or 0
                v322: Array[str] = fill([0] * v321, 0, v321, "")
                v323: Mut5 = Mut5(0)
                while method27(v321, v323):
                    v325: int = v323.l0 or 0
                    v326: str = v318[v325]
                    v322[v325] = v326
                    v327: int = (v325 + 1) or 0
                    v323.l0 = v327 or 0
                v329: FSharpList[str] = of_array(v322)
                pattern_input_2: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v329, UH0(0)), v16, 1, 1)
                v401 = US7(0, v275, v312, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

            else: 
                v401 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v275, to_array(of_array(["\"", "\'", " "])), (v16, 1, 1)])))


        v413: US7
        if v401.tag == 0:
            v402: str = v401.fields[0]
            v413 = US7(0, "/" if ("\\" == v402) else v402, v401.fields[1], v401.fields[2], v401.fields[3], v401.fields[4])

        else: 
            v413 = US7(1, v401.fields[0])

        v433: US8
        if v413.tag == 0:
            pattern_input_3: tuple[str, str, Any, int, int] = method36(v413.fields[0], v413.fields[1], v413.fields[2], v413.fields[3], v413.fields[4])
            v433 = US8(0, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2], pattern_input_3[3], pattern_input_3[4])

        else: 
            v433 = US8(1, v413.fields[0])

        if v433.tag == 0:
            v510 = v433

        else: 
            v448: US10 = US10(0, v10, v16, 1, 1) if (len(v10) == 0) else US10(1, to_text(interpolate("parsing.eof / expected end of input / input: %A%P()", [v10])))
            v457: US8 = US8(0, "", v448.fields[0], v448.fields[1], v448.fields[2], v448.fields[3]) if (v448.tag == 0) else US8(1, v448.fields[0])
            if v457.tag == 0:
                v459: str = v457.fields[1]
                v464: int = method37(v459, 0) or 0
                v496: int = (len(v459) - 1) or 0
                v510 = US8(0, v457.fields[0], v459[v464:v496 + 1], v457.fields[2], v457.fields[3], v457.fields[4])

            else: 
                v510 = US8(1, v457.fields[0])



    v854: US11
    if v510.tag == 0:
        v515: int = v510.fields[4] or 0
        v514: int = v510.fields[3] or 0
        v513: Any = v510.fields[2]
        v512: str = v510.fields[1]
        v683: US7
        if "" == v512:
            v683 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", [" ", (v513, v514, v515)])))

        else: 
            v522: str = v512[0]
            if v522 == " ":
                v555: int = (len(v512) - 1) or 0
                v557: str = v512[1:v555 + 1]
                v563: str = v522
                v566: int = len(v563) or 0
                v567: Array[str] = fill([0] * v566, 0, v566, "")
                v568: Mut5 = Mut5(0)
                while method27(v566, v568):
                    v570: int = v568.l0 or 0
                    v571: str = v563[v570]
                    v567[v570] = v571
                    v572: int = (v570 + 1) or 0
                    v568.l0 = v572 or 0
                v574: FSharpList[str] = of_array(v567)
                pattern_input_4: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v574, UH0(0)), v513, v514, v515)
                v683 = US7(0, v522, v557, pattern_input_4[0], pattern_input_4[1], pattern_input_4[2])

            else: 
                v625: int = (v512.find("\n") - 1) or 0
                v661: int = (((len(v512) + 1) if (-2 == v625) else (v625 + 1)) - 1) or 0
                v683 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str(" ")) + "\' / line: ") + str(v514)) + " / col: ") + str(v515)) + "\n") + str(v513)) + "") + v512[0:v661 + 1]) + "", "\n", method30(v515 - 1, 0)("") + "^", *"\n"))


        v695: US12 = US12(0, US9(0, v683.fields[0]), v683.fields[1], v683.fields[2], v683.fields[3], v683.fields[4]) if (v683.tag == 0) else US12(0, US9(1), v512, v513, v514, v515)
        v828: US8
        if v695.tag == 0:
            v700: int = v695.fields[4] or 0
            v699: int = v695.fields[3] or 0
            v698: Any = v695.fields[2]
            v697: str = v695.fields[1]
            v804: US7
            if "" == v697:
                v804 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v698, v699, v700)])))

            else: 
                v707: str = v697[0]
                v739: int = (len(v697) - 1) or 0
                v741: str = v697[1:v739 + 1]
                v747: str = v707
                v750: int = len(v747) or 0
                v751: Array[str] = fill([0] * v750, 0, v750, "")
                v752: Mut5 = Mut5(0)
                while method27(v750, v752):
                    v754: int = v752.l0 or 0
                    v755: str = v747[v754]
                    v751[v754] = v755
                    v756: int = (v754 + 1) or 0
                    v752.l0 = v756 or 0
                v758: FSharpList[str] = of_array(v751)
                pattern_input_5: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v758, UH0(0)), v698, v699, v700)
                v804 = US7(0, v707, v741, pattern_input_5[0], pattern_input_5[1], pattern_input_5[2])

            if v804.tag == 0:
                pattern_input_6: tuple[str, str, Any, int, int] = method38(v804.fields[0], v804.fields[1], v804.fields[2], v804.fields[3], v804.fields[4])
                v828 = US8(0, pattern_input_6[0], pattern_input_6[1], pattern_input_6[2], pattern_input_6[3], pattern_input_6[4])

            else: 
                v828 = US8(1, v804.fields[0])


        else: 
            v828 = US8(1, v695.fields[0])

        v840: US13 = US13(0, US5(0, v828.fields[0]), v828.fields[1], v828.fields[2], v828.fields[3], v828.fields[4]) if (v828.tag == 0) else US13(0, US5(1), v512, v513, v514, v515)
        v854 = US11(0, v510.fields[0], v840.fields[0], v840.fields[1], v840.fields[2], v840.fields[3], v840.fields[4]) if (v840.tag == 0) else US11(1, v840.fields[0])

    else: 
        v854 = US11(1, v510.fields[0])

    if v854.tag == 0:
        return US6(0, v854.fields[0], v854.fields[1])

    else: 
        return US6(1, v854.fields[0])



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
    def _arrow233(v: Callable[[tuple[int, str, bool]], Async[None]]) -> US14:
        return closure21(None, v)

    return _arrow233


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
    def _arrow243(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6, v7: Any=v7, v8: Any=v8, v9: Any=v9, v10: Any=v10) -> Async[None]:
        v837: str = method45(v10)
        v843: bool = (v837 is None) != True
        def _arrow241(__unit: None=None) -> Async[None]:
            v862: US14 = default_arg(map(method46(), v3), US14(1))
            def _arrow235(__unit: None=None) -> Async[None]:
                v868: Async[None] = v862.fields[0]((method47(v7), v837, v9))
                def _arrow234(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v868, _arrow234)

            def _expr236():
                return singleton.Zero()

            def _arrow240(__unit: None=None) -> Async[None]:
                v871: str = concat("! ", *v837) if v9 else concat("> ", *v837)
                def _arrow237(__unit: None=None) -> Async[None]:
                    v874: None
                    closure22(v871, None)
                    v874 = None
                    return singleton.Zero()

                def _arrow238(__unit: None=None) -> Async[None]:
                    v926: None
                    closure10(v871, None)
                    v926 = None
                    return singleton.Zero()

                def _arrow239(__unit: None=None) -> Async[None]:
                    v934: str = concat("\u001b[7;4m" if v9 else "", v837, *"\u001b[0m" if v9 else "")
                    return singleton.Zero()

                return singleton.Combine(_arrow237() if v5 else _arrow238(), singleton.Delay(_arrow239))

            return singleton.Combine(_arrow235() if (v862.tag == 0) else _expr236(), singleton.Delay(_arrow240))

        def _arrow242(__unit: None=None) -> Async[None]:
            return singleton.Zero()

        return singleton.Combine(_arrow241() if v843 else singleton.Zero(), singleton.Delay(_arrow242))

    return singleton.Delay(_arrow243)


def method43(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> Async[None]:
    return method44(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10)


def closure20(v0_1: str, v1_1: CancellationToken | None, v2_1: Array[tuple[str, str]], v3: Callable[[tuple[int, str, bool]], Async[None]] | None, v4: Callable[[std_sync_arc_1[std_sync_mutex_1[std_process_child_stdin]]], None] | None, v5: bool, v6: str | None, v7: bool, v8: Any, v9: bool, v10: bool) -> None:
    start_immediate(method43(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10))


def closure23(unit_var: None, v0_1: CancellationToken) -> US15:
    return US15(0, v0_1)


def method50(__unit: None=None) -> Callable[[CancellationToken], US15]:
    def _arrow244(v: CancellationToken) -> US15:
        return closure23(None, v)

    return _arrow244


def method51(v0_1: CancellationToken) -> Async[CancellationToken]:
    def _arrow245(__unit: None=None, v0_1: Any=v0_1) -> Async[CancellationToken]:
        return singleton.Return(None)

    return singleton.Delay(_arrow245)


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
    def _arrow249(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1) -> Async[int]:
        def _arrow247(__unit: None=None) -> Async[int]:
            v3205: Async[None] = await_task(None)
            def _arrow246(__unit: None=None) -> Async[int]:
                return singleton.Return(None)

            return singleton.Bind(v3205, _arrow246)

        def _arrow248(_arg_1: Exception) -> Async[int]:
            v3355: Exception = _arg_1
            v3378: str = to_text(interpolate("%A%P()", [v3355]))
            v3400: None
            closure25(v3355, None)
            v3400 = None
            return singleton.Return(-2147483648)

        return singleton.TryWith(singleton.Delay(_arrow247), _arrow248)

    return singleton.Delay(_arrow249)


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
    def _arrow262(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4, v5: Any=v5, v6: Any=v6) -> Async[tuple[int, str]]:
        pattern_input: tuple[int, str] = None
        return singleton.Return((pattern_input[0], pattern_input[1]))

    return singleton.Delay(_arrow262)


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




            def _arrow267(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v19_1.fields[0] if (v19_1.tag == 0) else _arrow267()):
                return True

            else: 
                v0_1_mut = v0_1
                v1_1_mut = op_addition(v1_1, int64(1))
                continue


        break


def method63(v0_1_mut: str, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> tuple[str, str, Any, int, int]:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v161: US7
        if "" == v1_1:
            v161 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))

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
                v161 = US7(0, v33, v70, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v161 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))


        if v161.tag == 0:
            v0_1_mut = v0_1 + v161.fields[0]
            v1_1_mut = v161.fields[1]
            v2_1_mut = v161.fields[2]
            v3_mut = v161.fields[3]
            v4_mut = v161.fields[4]
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



            def _arrow268(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> str:
                raise Exception("Option does not have a value.")

            if v0_1 == (v15.fields[0] if (v15.tag == 0) else _arrow268()):
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
    v172: US7
    if "" == v0_1:
        v172 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\\", (v1_1, v2_1, v3)])))

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
            v172 = US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v113: int = (v0_1.find("\n") - 1) or 0
            v149: int = (((len(v0_1) + 1) if (-2 == v113) else (v113 + 1)) - 1) or 0
            v172 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\\")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v149 + 1]) + "", "\n", method30(v3 - 1, 0)("") + "^", *"\n"))


    v285: US7
    if v172.tag == 0:
        v177: int = v172.fields[4] or 0
        v176: int = v172.fields[3] or 0
        v175: Any = v172.fields[2]
        v174: str = v172.fields[1]
        if "" == v174:
            v285 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v175, v176, v177)])))

        else: 
            v184: str = v174[0]
            v216: int = (len(v174) - 1) or 0
            v218: str = v174[1:v216 + 1]
            v224: str = v184
            v227: int = len(v224) or 0
            v228: Array[str] = fill([0] * v227, 0, v227, "")
            v229: Mut5 = Mut5(0)
            while method27(v227, v229):
                v231: int = v229.l0 or 0
                v232: str = v224[v231]
                v228[v231] = v232
                v233: int = (v231 + 1) or 0
                v229.l0 = v233 or 0
            v235: FSharpList[str] = of_array(v228)
            pattern_input_1: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v235, UH0(0)), v175, v176, v177)
            v285 = US7(0, v184, v218, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v285 = US7(1, v172.fields[0])

    if v285.tag == 0:
        return US8(0, "\\" + v285.fields[0], v285.fields[1], v285.fields[2], v285.fields[3], v285.fields[4])

    else: 
        return US8(1, v285.fields[0])



def closure31(unit_var: None, _arg: tuple[str, Any, int, int]) -> US8:
    v3: int = _arg[3] or 0
    v2_1: int = _arg[2] or 0
    v1_1: Any = _arg[1]
    v0_1: str = _arg[0]
    v172: US7
    if "" == v0_1:
        v172 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["`", (v1_1, v2_1, v3)])))

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
            v172 = US7(0, v10, v45, pattern_input[0], pattern_input[1], pattern_input[2])

        else: 
            v113: int = (v0_1.find("\n") - 1) or 0
            v149: int = (((len(v0_1) + 1) if (-2 == v113) else (v113 + 1)) - 1) or 0
            v172 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("`")) + "\' / line: ") + str(v2_1)) + " / col: ") + str(v3)) + "\n") + str(v1_1)) + "") + v0_1[0:v149 + 1]) + "", "\n", method30(v3 - 1, 0)("") + "^", *"\n"))


    v285: US7
    if v172.tag == 0:
        v177: int = v172.fields[4] or 0
        v176: int = v172.fields[3] or 0
        v175: Any = v172.fields[2]
        v174: str = v172.fields[1]
        if "" == v174:
            v285 = US7(1, to_text(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [(v175, v176, v177)])))

        else: 
            v184: str = v174[0]
            v216: int = (len(v174) - 1) or 0
            v218: str = v174[1:v216 + 1]
            v224: str = v184
            v227: int = len(v224) or 0
            v228: Array[str] = fill([0] * v227, 0, v227, "")
            v229: Mut5 = Mut5(0)
            while method27(v227, v229):
                v231: int = v229.l0 or 0
                v232: str = v224[v231]
                v228[v231] = v232
                v233: int = (v231 + 1) or 0
                v229.l0 = v233 or 0
            v235: FSharpList[str] = of_array(v228)
            pattern_input_1: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v235, UH0(0)), v175, v176, v177)
            v285 = US7(0, v184, v218, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2])


    else: 
        v285 = US7(1, v172.fields[0])

    if v285.tag == 0:
        return US8(0, "`" + v285.fields[0], v285.fields[1], v285.fields[2], v285.fields[3], v285.fields[4])

    else: 
        return US8(1, v285.fields[0])



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
        v153: US7
        if "" == v1_1:
            v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))

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
                v153 = US7(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))


        v168: US8 = US8(0, v153.fields[0], v153.fields[1], v153.fields[2], v153.fields[3], v153.fields[4]) if (v153.tag == 0) else US8(1, v153.fields[0])
        def v175(_arg10: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
            return closure30(None, _arg10)

        def v176(_arg10_1: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
            return closure31(None, _arg10_1)

        v182: US8 = v168 if (v168.tag == 0) else method66(v1_1, v2_1, v3, v4, UH3(1, v175, UH3(1, v176, UH3(0))))
        if v182.tag == 0:
            v0_1_mut = UH2(1, v182.fields[0], v0_1)
            v1_1_mut = v182.fields[1]
            v2_1_mut = v182.fields[2]
            v3_mut = v182.fields[3]
            v4_mut = v182.fields[4]
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
        v153: US7
        if "" == v1_1:
            v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))

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
                v153 = US7(0, v29, v66, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v153 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, to_array(of_array(["\\", "`", "\""])), (v2_1, v3, v4)])))


        v168: US8 = US8(0, v153.fields[0], v153.fields[1], v153.fields[2], v153.fields[3], v153.fields[4]) if (v153.tag == 0) else US8(1, v153.fields[0])
        if v168.tag == 0:
            v0_1_mut = UH2(1, v168.fields[0], v0_1)
            v1_1_mut = v168.fields[1]
            v2_1_mut = v168.fields[2]
            v3_mut = v168.fields[3]
            v4_mut = v168.fields[4]
            continue

        else: 
            return US17(0, method67(v0_1, UH2(0)), v1_1, v2_1, v3, v4)

        break


def method61(v0_1_mut: UH2, v1_1_mut: str, v2_1_mut: Any, v3_mut: int, v4_mut: int) -> US17:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        v5: bool = "" == v1_1
        v161: US7
        if v5:
            v161 = US7(1, to_text(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))

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
                v161 = US7(0, v33, v70, pattern_input[0], pattern_input[1], pattern_input[2])

            else: 
                v161 = US7(1, to_text(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, to_array(of_array(["\\", "`", "\"", " "])), (v2_1, v3, v4)])))


        v181: US8
        if v161.tag == 0:
            pattern_input_1: tuple[str, str, Any, int, int] = method63(v161.fields[0], v161.fields[1], v161.fields[2], v161.fields[3], v161.fields[4])
            v181 = US8(0, pattern_input_1[0], pattern_input_1[1], pattern_input_1[2], pattern_input_1[3], pattern_input_1[4])

        else: 
            v181 = US8(1, v161.fields[0])

        v659: US8
        if v181.tag == 0:
            v659 = v181

        else: 
            v355: US7
            if v5:
                v355 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v2_1, v3, v4)])))

            else: 
                v193: str = v1_1[0]
                if v193 == "\"":
                    v226: int = (len(v1_1) - 1) or 0
                    v228: str = v1_1[1:v226 + 1]
                    v234: str = v193
                    v237: int = len(v234) or 0
                    v238: Array[str] = fill([0] * v237, 0, v237, "")
                    v239: Mut5 = Mut5(0)
                    while method27(v237, v239):
                        v241: int = v239.l0 or 0
                        v242: str = v234[v241]
                        v238[v241] = v242
                        v243: int = (v241 + 1) or 0
                        v239.l0 = v243 or 0
                    v245: FSharpList[str] = of_array(v238)
                    pattern_input_2: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v245, UH0(0)), v2_1, v3, v4)
                    v355 = US7(0, v193, v228, pattern_input_2[0], pattern_input_2[1], pattern_input_2[2])

                else: 
                    v296: int = (v1_1.find("\n") - 1) or 0
                    v332: int = (((len(v1_1) + 1) if (-2 == v296) else (v296 + 1)) - 1) or 0
                    v355 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v3)) + " / col: ") + str(v4)) + "\n") + str(v2_1)) + "") + v1_1[0:v332 + 1]) + "", "\n", method30(v4 - 1, 0)("") + "^", *"\n"))


            v590: US8
            if v355.tag == 0:
                v360: int = v355.fields[4] or 0
                v359: int = v355.fields[3] or 0
                v358: Any = v355.fields[2]
                v357: str = v355.fields[1]
                v362: US17 = method64(UH2(0), v357, v358, v359, v360)
                v393: US8
                if v362.tag == 0:
                    v369: FSharpList[str] = method68(v362.fields[0], empty())
                    def _arrow274(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v369

                    v393 = US8(0, join("", delay(_arrow274)), v362.fields[1], v362.fields[2], v362.fields[3], v362.fields[4])

                else: 
                    v393 = US8(1, v362.fields[0])

                if v393.tag == 0:
                    v398: int = v393.fields[4] or 0
                    v397: int = v393.fields[3] or 0
                    v396: Any = v393.fields[2]
                    v395: str = v393.fields[1]
                    v567: US7
                    if "" == v395:
                        v567 = US7(1, to_text(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", (v396, v397, v398)])))

                    else: 
                        v405: str = v395[0]
                        if v405 == "\"":
                            v438: int = (len(v395) - 1) or 0
                            v440: str = v395[1:v438 + 1]
                            v446: str = v405
                            v449: int = len(v446) or 0
                            v450: Array[str] = fill([0] * v449, 0, v449, "")
                            v451: Mut5 = Mut5(0)
                            while method27(v449, v451):
                                v453: int = v451.l0 or 0
                                v454: str = v446[v453]
                                v450[v453] = v454
                                v455: int = (v453 + 1) or 0
                                v451.l0 = v455 or 0
                            v457: FSharpList[str] = of_array(v450)
                            pattern_input_3: tuple[Any, int, int] = method29(fold_back(uncurry2(method28()), v457, UH0(0)), v396, v397, v398)
                            v567 = US7(0, v405, v440, pattern_input_3[0], pattern_input_3[1], pattern_input_3[2])

                        else: 
                            v508: int = (v395.find("\n") - 1) or 0
                            v544: int = (((len(v395) + 1) if (-2 == v508) else (v508 + 1)) - 1) or 0
                            v567 = US7(1, concat(((((((((("parsing.p_char / expected: \'" + str("\"")) + "\' / line: ") + str(v397)) + " / col: ") + str(v398)) + "\n") + str(v396)) + "") + v395[0:v544 + 1]) + "", "\n", method30(v398 - 1, 0)("") + "^", *"\n"))


                    v590 = US8(0, v393.fields[0], v567.fields[1], v567.fields[2], v567.fields[3], v567.fields[4]) if (v567.tag == 0) else US8(1, to_text(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v567.fields[0], (v1_1, v2_1, v3, v4), (v357, v358, v359, v360), (v395, v396, v397, v398)])))

                else: 
                    v590 = US8(1, "parsing.between / expected content")


            else: 
                v590 = US8(1, v355.fields[0])

            if v590.tag == 0:
                v659 = v590

            else: 
                def v597(_arg10: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
                    return closure30(None, _arg10)

                def v598(_arg10_1: tuple[str, Any, int, int], v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> US8:
                    return closure31(None, _arg10_1)

                v602: US8 = method66(v1_1, v2_1, v3, v4, UH3(1, v597, UH3(1, v598, UH3(0))))
                v613: US8 = US8(0, "", v602.fields[1], v602.fields[2], v602.fields[3], v602.fields[4]) if (v602.tag == 0) else US8(1, v602.fields[0])
                v624: US17 = method69(UH2(0), v613.fields[1], v613.fields[2], v613.fields[3], v613.fields[4]) if (v613.tag == 0) else US17(1, v613.fields[0])
                if v624.tag == 0:
                    v631: FSharpList[str] = method68(v624.fields[0], empty())
                    def _arrow275(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> IEnumerable_1[str]:
                        return v631

                    v659 = US8(0, join("", delay(_arrow275)), v624.fields[1], v624.fields[2], v624.fields[3], v624.fields[4])

                else: 
                    v659 = US8(1, v624.fields[0])



        if v659.tag == 0:
            v664: int = v659.fields[4] or 0
            v663: int = v659.fields[3] or 0
            v662: Any = v659.fields[2]
            v661: str = v659.fields[1]
            v660: str = v659.fields[0]
            v666: int = method37(v661, 0) or 0
            v708: US10
            if 0 == v666:
                v708 = US10(1, "parsing.spaces1 / expected at least one space")

            else: 
                v701: int = (len(v661) - 1) or 0
                v708 = US10(0, v661[v666:v701 + 1], v662, v663, v664)

            if v708.tag == 0:
                v0_1_mut = UH2(1, v660, v0_1)
                v1_1_mut = v708.fields[0]
                v2_1_mut = v708.fields[1]
                v3_mut = v708.fields[2]
                v4_mut = v708.fields[3]
                continue

            else: 
                return US17(0, method67(v0_1, UH2(1, v660, UH2(0))), v661, v662, v663, v664)


        else: 
            return US17(0, method67(v0_1, UH2(0)), v1_1, v2_1, v3, v4)

        break


def method60(v0_1: str) -> US16:
    _v0: (str | None) | None = None
    _v0 = some(v0_1)
    def _arrow276(__unit: None=None, v0_1: Any=v0_1) -> str | None:
        raise Exception("optionm\'.of_obj / _v0=None")

    v22: US17 = method61(UH2(0), default_arg(_arrow276() if (_v0 is None) else value_12(_v0), ""), StringBuilder__ctor_Z721C83C5(method26()), 1, 1)
    if v22.tag == 0:
        return US16(0, to_array(method68(v22.fields[0], empty())))

    else: 
        return US16(1, v22.fields[0])



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


