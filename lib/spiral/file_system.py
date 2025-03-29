from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.async_ import (sleep, await_task, start_child, catch_async, ignore, run_synchronously)
from fable_modules.fable_library.async_builder import (singleton, Async)
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.guid import (parse, new_guid)
from fable_modules.fable_library.list import (to_array, empty, of_array, singleton as singleton_1)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition, op_modulus)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_10, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, class_type, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type, int32_type, array_type, enum_type)
from fable_modules.fable_library.result import FSharpResult_2
from fable_modules.fable_library.string_ import (trim_end, trim_start, to_text, interpolate, concat, replace)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds, to_string as to_string_1)
from fable_modules.fable_library.types import (int64, Array, Union, Record, uint8, to_string as to_string_2)
from fable_modules.fable_library.util import (create_atom, IDisposable, to_enumerable, compare, int64_to_string, uncurry2)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


class IFsExistsSync(Protocol):
    @abstractmethod
    def exists_sync(self, path: str) -> bool:
        ...


class IPathBasename(Protocol):
    @abstractmethod
    def basename(self, path: str) -> str:
        ...


class IPathJoin(Protocol):
    @abstractmethod
    def join(self, paths: Array[str]) -> str:
        ...


def _expr282() -> TypeInfo:
    return class_type("File_system.Disposable", None, Disposable)


class Disposable(IDisposable):
    def __init__(self, f: Callable[[], None]) -> None:
        self.f: Callable[[], None] = f

    def Dispose(self, __unit: None=None) -> None:
        _: Disposable = self
        _.f(None)


Disposable_reflection = _expr282

def Disposable__ctor_3A5B6456(f: Callable[[], None]) -> Disposable:
    return Disposable(f)


class IPathDirname(Protocol):
    @abstractmethod
    def dirname(self, path: str) -> str:
        ...


class IFs(Protocol):
    @abstractmethod
    def realpath_sync(self, path: str) -> str:
        ...


def _expr283() -> TypeInfo:
    return union_type("File_system.US0", [], US0, lambda: [[], [], [], [], []])


class US0(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US0_0", "US0_1", "US0_2", "US0_3", "US0_4"]


US0_reflection = _expr283

def _expr284() -> TypeInfo:
    return record_type("File_system.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr284

def _expr285() -> TypeInfo:
    return record_type("File_system.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr285

def _expr286() -> TypeInfo:
    return record_type("File_system.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr286

def _expr287() -> TypeInfo:
    return record_type("File_system.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr287

def _expr288() -> TypeInfo:
    return record_type("File_system.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr288

def _expr289() -> TypeInfo:
    return union_type("File_system.US1", [], US1, lambda: [[("f0_0", US0_reflection())], []])


class US1(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US1_0", "US1_1"]


US1_reflection = _expr289

def _expr290() -> TypeInfo:
    return union_type("File_system.US2", [], US2, lambda: [[("f0_0", int64_type)], []])


class US2(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US2_0", "US2_1"]


US2_reflection = _expr290

def _expr291() -> TypeInfo:
    return union_type("File_system.US3", [], US3, lambda: [[], [], []])


class US3(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US3_0", "US3_1", "US3_2"]


US3_reflection = _expr291

def _expr292() -> TypeInfo:
    return union_type("File_system.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5"]


US4_reflection = _expr292

def _expr293() -> TypeInfo:
    return union_type("File_system.US5", [], US5, lambda: [[("f0_0", string_type)], []])


class US5(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US5_0", "US5_1"]


US5_reflection = _expr293

def _expr294() -> TypeInfo:
    return union_type("File_system.US7", [], US7, lambda: [[], [], []])


class US7(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US7_0", "US7_1", "US7_2"]


US7_reflection = _expr294

def _expr295() -> TypeInfo:
    return union_type("File_system.US8", [], US8, lambda: [[], [], [], [], []])


class US8(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US8_0", "US8_1", "US8_2", "US8_3", "US8_4"]


US8_reflection = _expr295

def _expr296() -> TypeInfo:
    return union_type("File_system.US6", [], US6, lambda: [[("f0_0", US7_reflection()), ("f0_1", US8_reflection())], []])


class US6(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US6_0", "US6_1"]


US6_reflection = _expr296

def _expr297() -> TypeInfo:
    return union_type("File_system.US9", [], US9, lambda: [[], [("f1_0", string_type)]])


class US9(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US9_0", "US9_1"]


US9_reflection = _expr297

def _expr298() -> TypeInfo:
    return union_type("File_system.US10", [], US10, lambda: [[("f0_0", int64_type)], [("f1_0", class_type("System.Exception"))]])


class US10(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US10_0", "US10_1"]


US10_reflection = _expr298

def _expr299() -> TypeInfo:
    return union_type("File_system.US11", [], US11, lambda: [[("f0_0", int64_type)], [("f1_0", class_type("System.Exception"))]])


class US11(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US11_0", "US11_1"]


US11_reflection = _expr299

def _expr300() -> TypeInfo:
    return union_type("File_system.US12", [], US12, lambda: [[("f0_0", class_type("File_system.chrono_DateTime`1", [class_type("File_system.chrono_Utc")]))], []])


class US12(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US12_0", "US12_1"]


US12_reflection = _expr300

def _expr301() -> TypeInfo:
    return union_type("File_system.US13", [], US13, lambda: [[], [("f1_0", class_type("File_system.std_string_String"))]])


class US13(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US13_0", "US13_1"]


US13_reflection = _expr301

def _expr302() -> TypeInfo:
    return union_type("File_system.US14", [], US14, lambda: [[("f0_0", class_type("File_system.std_path_PathBuf"))], [("f1_0", string_type)]])


class US14(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US14_0", "US14_1"]


US14_reflection = _expr302

def _expr303() -> TypeInfo:
    return union_type("File_system.US15", [], US15, lambda: [[("f0_0", class_type("File_system.std_path_PathBuf"))], []])


class US15(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US15_0", "US15_1"]


US15_reflection = _expr303

def _expr304() -> TypeInfo:
    return record_type("File_system.Mut5", [], Mut5, lambda: [("l0", int32_type), ("l1", int32_type), ("l2", array_type(string_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut5(Record):
    l0: int
    l1: int
    l2: Array[str]

Mut5_reflection = _expr304

def _expr305() -> TypeInfo:
    return record_type("File_system.Mut6", [], Mut6, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut6(Record):
    l0: int

Mut6_reflection = _expr305

def _expr306() -> TypeInfo:
    return union_type("File_system.US16", [], US16, lambda: [[], []])


class US16(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US16_0", "US16_1"]


US16_reflection = _expr306

def _expr307() -> TypeInfo:
    return union_type("File_system.US17", [], US17, lambda: [[("f0_0", string_type)], [("f1_0", string_type)]])


class US17(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US17_0", "US17_1"]


US17_reflection = _expr307

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow308(v: str) -> US5:
        return closure1(None, v)

    return _arrow308


def method2(v0: str) -> str:
    v31_1: IOsEnviron = os
    v33_1: Any = v31.environ
    _v38: (str | None) | None = None
    x: str | None = v33.get(v0)
    _v38 = some(x)
    v44_1: str | None
    if _v38 is None:
        raise Exception("optionm\'.of_obj / _v38=None")

    else: 
        v44_1 = value_10(_v38)

    v71: US5 = default_arg(map(method5(), v44_1), US5(1))
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
    v41_1: US1 = US1(0, US0(0)) if ("Verbose" == v1) else US1(1)
    def _arrow309(__unit: None=None) -> US1:
        v48_1: US1 = US1(0, US0(1)) if ("Debug" == v1) else US1(1)
        if v48_1.tag == 0:
            return US1(0, v48_1.fields[0])

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









    return (US1(0, v41_1.fields[0]) if (v41_1.tag == 0) else _arrow309(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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



def method10(v0: str) -> bool:
    return None


def method9(v0: bool, v1: str) -> None:
    pass


def method11(v0: US0) -> bool:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v56: US0 = pattern_input[4].l0
    if pattern_input[2].l0 == False:
        return False

    else: 
        class ObjectExpr310:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        class ObjectExpr311:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        return find(v0, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr310())) >= find(v56, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr311()))



def closure5(unit_var: None, v0: int64) -> US2:
    return US2(0, v0)


def method13(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow312(v: int64) -> US2:
        return closure5(None, v)

    return _arrow312


def method14(__unit: None=None) -> str:
    return "hh:mm:ss"


def method15(__unit: None=None) -> str:
    return "HH:mm:ss"


def method12(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v804: US2 = default_arg(map(method13(), v5), US2(1))
    v936: Any
    if v804.tag == 0:
        v884: Any = create(op_subtraction(from_value(ticks_1(now()), False), v804.fields[0]))
        v936 = create_1(1, 1, 1, hours(v884), minutes(v884), seconds(v884), milliseconds(v884))

    else: 
        v936 = now()

    v938: str = method15()
    return to_string(v936, "M-d-y hh:mm:ss tt" if (v938 == "") else v938)


def method17(__unit: None=None) -> str:
    return ""


def closure6(v0: Mut3, v1: str, unit_var: None) -> None:
    v4: str = v0.l0 + v1
    v0.l0 = v4


def method18(__unit: None=None) -> str:
    return "\u001b[0m"


def method16(__unit: None=None) -> str:
    v4: str = "Debug".lower()
    v7: str = v4[0]
    v9: Mut3 = Mut3(method17())
    v24: None
    closure6(v9, ("" + str(v7)) + "", None)
    v24 = None
    return ("\u001b[94m" + v9.l0) + method18()


def method19(v0: str) -> str:
    raise Exception(((("file_system.get_file_name / target: " + str(US4(5, US3(0)))) + " / path: ") + v0) + "")


def method21(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method20(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v11: Mut3 = Mut3(method17())
    v25: None
    closure6(v11, "{ ", None)
    v25 = None
    v44_1: None
    closure6(v11, "ex", None)
    v44_1 = None
    v63: None
    closure6(v11, " = ", None)
    v63 = None
    v80: None
    closure6(v11, v8, None)
    v80 = None
    v99: None
    closure6(v11, "; ", None)
    v99 = None
    v118: None
    closure6(v11, "path", None)
    v118 = None
    v135: None
    closure6(v11, " = ", None)
    v135 = None
    v152: None
    closure6(v11, v9, None)
    v152 = None
    v171: None
    closure6(v11, " }", None)
    v171 = None
    v177: str = v11.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.delete_directory_async") + " / ") + v177)


def closure7(v0: Mut0, unit_var: None) -> None:
    v2: int64 = op_addition(v0.l0, int64(1))
    v0.l0 = v2


def closure9(v0: str, unit_var: None) -> None:
    print(v0)


def closure8(unit_var: None, v0: str) -> None:
    v4: None
    closure9(v0, None)
    v4 = None


def method22(v0: str) -> None:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v60: None
    closure7(pattern_input[0], None)
    v60 = None
    closure8(None, v0)
    pattern_input[1].l0(v0)


def closure4(v0: str, v1: Exception, unit_var: None) -> None:
    if method11(US0(1)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v46_1: int64 | None = pattern_input[5]
        v45_1: Mut4 = pattern_input[4]
        v44_1: Mut3 = pattern_input[3]
        v43_1: Mut2 = pattern_input[2]
        v42_1: Mut1 = pattern_input[1]
        v41_1: Mut0 = pattern_input[0]
        method22(method20(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method16(), to_text(interpolate("%A%P()", [v1])), method19(v0)))



def method8(v0: str, v1: int64) -> Async[int64]:
    def _arrow318(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[int64]:
        def _arrow313(__unit: None=None) -> Async[int64]:
            method9(True, v0)
            return singleton.Return(v1)

        def _arrow317(_arg: Exception) -> Async[int64]:
            v27417: bool = op_modulus(v1, int64(100)) == int64(0)
            def _arrow314(__unit: None=None) -> Async[None]:
                v27517: None
                closure4(v0, _arg, None)
                v27517 = None
                return singleton.Zero()

            def _arrow316(__unit: None=None) -> Async[int64]:
                v27629: Async[None] = sleep(10)
                def _arrow315(__unit: None=None) -> Async[int64]:
                    v27638: Async[int64] = method7(v0, op_addition(v1, int64(1)))
                    return singleton.ReturnFrom(v27638)

                return singleton.Bind(v27629, _arrow315)

            return singleton.Combine(_arrow314() if v27417 else singleton.Zero(), singleton.Delay(_arrow316))

        return singleton.TryWith(singleton.Delay(_arrow313), _arrow317)

    return singleton.Delay(_arrow318)


def method7(v0: str, v1: int64) -> Async[int64]:
    return None


def method6(v0: str) -> Async[int64]:
    return method7(v0, int64(0))


def closure3(unit_var: None, v0: str) -> Async[int64]:
    return method6(v0)


def method26(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: int64, v10: str) -> str:
    v12: Mut3 = Mut3(method17())
    v26: None
    closure6(v12, "{ ", None)
    v26 = None
    v45_1: None
    closure6(v12, "path", None)
    v45_1 = None
    v64: None
    closure6(v12, " = ", None)
    v64 = None
    v81: None
    closure6(v12, v8, None)
    v81 = None
    v100: None
    closure6(v12, "; ", None)
    v100 = None
    v119: None
    closure6(v12, "retry", None)
    v119 = None
    v136: None
    closure6(v12, " = ", None)
    v136 = None
    v156: None
    closure6(v12, ("" + str(v9)) + "", None)
    v156 = None
    v173: None
    closure6(v12, "; ", None)
    v173 = None
    v192: None
    closure6(v12, "ex", None)
    v192 = None
    v209: None
    closure6(v12, " = ", None)
    v209 = None
    v226: None
    closure6(v12, v10, None)
    v226 = None
    v245: None
    closure6(v12, " }", None)
    v245 = None
    v251: str = v12.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.wait_for_file_access") + " / ") + v251)


def closure12(v0: str, v1: int64, v2: Exception, unit_var: None) -> None:
    if method11(US0(1)):
        v21: None
        closure0(None, None)
        v21 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v47_1: int64 | None = pattern_input[5]
        v46_1: Mut4 = pattern_input[4]
        v45_1: Mut3 = pattern_input[3]
        v44_1: Mut2 = pattern_input[2]
        v43_1: Mut1 = pattern_input[1]
        v42_1: Mut0 = pattern_input[0]
        method22(method26(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1, method12(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1), method16(), method19(v0), v1, to_text(interpolate("%A%P()", [v2]))))



def method25(v0: US6, v1: str, v2: int64, v3: US8, v4: US7) -> Async[int64]:
    def _arrow325(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> Async[int64]:
        def _arrow320(__unit: None=None) -> Async[int64]:
            def _arrow319(_arg: Any) -> Async[int64]:
                return singleton.Return(v2)

            return singleton.Using(None, _arrow319)

        def _arrow324(_arg_1: Exception) -> Async[int64]:
            v34183: bool = (op_modulus(v2, int64(100)) == int64(0)) if (v2 > int64(0)) else False
            def _arrow321(__unit: None=None) -> Async[None]:
                v34283: None
                closure12(v1, v2, _arg_1, None)
                v34283 = None
                return singleton.Zero()

            def _arrow323(__unit: None=None) -> Async[int64]:
                v34395: Async[None] = sleep(10)
                def _arrow322(__unit: None=None) -> Async[int64]:
                    v34404: Async[int64] = method24(v0, v1, op_addition(v2, int64(1)))
                    return singleton.ReturnFrom(v34404)

                return singleton.Bind(v34395, _arrow322)

            return singleton.Combine(_arrow321() if v34183 else singleton.Zero(), singleton.Delay(_arrow323))

        return singleton.TryWith(singleton.Delay(_arrow320), _arrow324)

    return singleton.Delay(_arrow325)


def method24(v0: US6, v1: str, v2: int64) -> Async[int64]:
    return None


def method23(v0: US6, v1: str) -> Async[int64]:
    return method24(v0, v1, int64(0))


def closure11(v0: US6, v1: str) -> Async[int64]:
    return method23(v0, v1)


def closure10(unit_var: None, v0: US6) -> Callable[[str], Async[int64]]:
    def _arrow326(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Async[int64]:
        return closure11(v0, v)

    return _arrow326


def method27(v0: str) -> Async[int64]:
    return method23(US6(0, US7(0), US8(1)), v0)


def closure13(unit_var: None, v0: str) -> Async[int64]:
    return method27(v0)


def method31(__unit: None=None) -> str:
    v4: str = "Verbose".lower()
    v7: str = v4[0]
    v9: Mut3 = Mut3(method17())
    v24: None
    closure6(v9, ("" + str(v7)) + "", None)
    v24 = None
    return ("\u001b[90m" + v9.l0) + method18()


def method32(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int64, v9: str, v10: Exception) -> str:
    v12: Mut3 = Mut3(method17())
    v26: None
    closure6(v12, "{ ", None)
    v26 = None
    v45_1: None
    closure6(v12, "retry", None)
    v45_1 = None
    v64: None
    closure6(v12, " = ", None)
    v64 = None
    v84: None
    closure6(v12, ("" + str(v8)) + "", None)
    v84 = None
    v103: None
    closure6(v12, "; ", None)
    v103 = None
    v122: None
    closure6(v12, "path", None)
    v122 = None
    v139: None
    closure6(v12, " = ", None)
    v139 = None
    v156: None
    closure6(v12, v9, None)
    v156 = None
    v173: None
    closure6(v12, "; ", None)
    v173 = None
    v192: None
    closure6(v12, "ex", None)
    v192 = None
    v209: None
    closure6(v12, " = ", None)
    v209 = None
    v265: None
    closure6(v12, to_text(interpolate("%A%P()", [v10])), None)
    v265 = None
    v284: None
    closure6(v12, " }", None)
    v284 = None
    v290: str = v12.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.read_all_text_async") + " / ") + v290)


def closure15(v0: str, v1: int64, v2: Exception, unit_var: None) -> None:
    if method11(US0(0)):
        v21: None
        closure0(None, None)
        v21 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v47_1: int64 | None = pattern_input[5]
        v46_1: Mut4 = pattern_input[4]
        v45_1: Mut3 = pattern_input[3]
        v44_1: Mut2 = pattern_input[2]
        v43_1: Mut1 = pattern_input[1]
        v42_1: Mut0 = pattern_input[0]
        method22(method32(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1, method12(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1), method31(), v1, v0, v2))



def method30(v0: str, v1: int64) -> Async[str]:
    def _arrow330(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[str]:
        def _arrow327(__unit: None=None) -> Async[str]:
            v26713: Async[str] = await_task(None)
            return singleton.ReturnFrom(v26713)

        def _arrow329(_arg: Exception) -> Async[str]:
            v27007: None
            closure15(v0, v1, _arg, None)
            v27007 = None
            v27082: Async[None] = sleep(10)
            def _arrow328(__unit: None=None) -> Async[str]:
                v27095: Async[str]
                if v1 < int64(3):
                    v27095 = method29(v0, op_addition(v1, int64(1)))

                else: 
                    raise Exception(((("file_system.read_all_text_async / retry: " + str(v1)) + " / path: ") + v0) + "")

                return singleton.ReturnFrom(v27095)

            return singleton.Bind(v27082, _arrow328)

        return singleton.TryWith(singleton.Delay(_arrow327), _arrow329)

    return singleton.Delay(_arrow330)


def method29(v0: str, v1: int64) -> Async[str]:
    return method30(v0, v1)


def method28(v0: str) -> Async[str]:
    return method29(v0, int64(0))


def closure14(unit_var: None, v0: str) -> Async[str]:
    return method28(v0)


def method34(v0: str) -> bool:
    return None


def method35(v0: Vec_1[uint8]) -> Vec_1[uint8]:
    return v0


def method33(v0: str, v1: str) -> bool:
    return None


def closure17(v0: str, v1: str) -> bool:
    return method33(v0, v1)


def closure16(unit_var: None, v0: str) -> Callable[[str], bool]:
    def _arrow331(v: str, unit_var: Any=unit_var, v0: Any=v0) -> bool:
        return closure17(v0, v)

    return _arrow331


def method36(v0: str, v1: str) -> Async[None]:
    return None


def closure19(v0: str, v1: str) -> Async[None]:
    return method36(v0, v1)


def closure18(unit_var: None, v0: str) -> Callable[[str], Async[None]]:
    def _arrow332(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Async[None]:
        return closure19(v0, v)

    return _arrow332


def method40(v0: str, v1: str) -> Async[bool]:
    def _arrow334(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[bool]:
        if method34(v0) == False:
            return singleton.Return(False)

        else: 
            v230: Async[str] = method28(v0)
            def _arrow333(_arg: str) -> Async[bool]:
                v232: bool = v1 == _arg
                return singleton.Return(v232)

            return singleton.Bind(v230, _arrow333)


    return singleton.Delay(_arrow334)


def method39(v0: str, v1: str) -> Async[bool]:
    return None


def method38(v0: str, v1: str) -> Async[None]:
    def _arrow339(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[None]:
        v188: Async[bool] = method39(v0, v1)
        def _arrow338(_arg: bool) -> Async[None]:
            v190: bool = _arg == False
            def _arrow336(__unit: None=None) -> Async[None]:
                v191: Async[None] = method36(v0, v1)
                def _arrow335(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v191, _arrow335)

            def _arrow337(__unit: None=None) -> Async[None]:
                return singleton.Zero()

            return singleton.Combine(_arrow336() if v190 else singleton.Zero(), singleton.Delay(_arrow337))

        return singleton.Bind(v188, _arrow338)

    return singleton.Delay(_arrow339)


def method37(v0: str, v1: str) -> Async[None]:
    return method38(v0, v1)


def closure21(v0: str, v1: str) -> Async[None]:
    return method37(v0, v1)


def closure20(unit_var: None, v0: str) -> Callable[[str], Async[None]]:
    def _arrow340(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Async[None]:
        return closure21(v0, v)

    return _arrow340


def closure23(unit_var: None, v0: std_io_error) -> str:
    v2: Mut3 = Mut3(method17())
    v53_1: None
    closure6(v2, to_text(interpolate("%A%P()", [v0])), None)
    v53_1 = None
    return v2.l0


def method44(__unit: None=None) -> Callable[[std_io_error], str]:
    def _arrow341(v: std_io_error) -> str:
        return closure23(None, v)

    return _arrow341


def closure24(unit_var: None, unit_var_1: None) -> US9:
    return US9(0)


def method45(__unit: None=None) -> Callable[[], US9]:
    def _arrow342(__unit: None=None) -> US9:
        return closure24(None, None)

    return _arrow342


def closure25(unit_var: None, v0: str) -> US9:
    return US9(1, v0)


def method46(__unit: None=None) -> Callable[[str], US9]:
    def _arrow343(v: str) -> US9:
        return closure25(None, v)

    return _arrow343


def method47(__unit: None=None) -> str:
    v4: str = "Critical".lower()
    v7: str = v4[0]
    v9: Mut3 = Mut3(method17())
    v24: None
    closure6(v9, ("" + str(v7)) + "", None)
    v24 = None
    return ("\u001b[91m" + v9.l0) + method18()


def method48(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v10: Mut3 = Mut3(method17())
    v24: None
    closure6(v10, "{ ", None)
    v24 = None
    v43_1: None
    closure6(v10, "error\'", None)
    v43_1 = None
    v62: None
    closure6(v10, " = ", None)
    v62 = None
    v79: None
    closure6(v10, v8, None)
    v79 = None
    v98: None
    closure6(v10, " }", None)
    v98 = None
    v104: str = v10.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.file_delete") + " / ") + v104)


def closure26(v0: str, unit_var: None) -> None:
    if method11(US0(4)):
        v19: None
        closure0(None, None)
        v19 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v45_1: int64 | None = pattern_input[5]
        v44_1: Mut4 = pattern_input[4]
        v43_1: Mut3 = pattern_input[3]
        v42_1: Mut2 = pattern_input[2]
        v41_1: Mut1 = pattern_input[1]
        v40_1: Mut0 = pattern_input[0]
        method22(method48(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1, method12(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1), method47(), v0))



def method49(__unit: None=None) -> str:
    v4: str = "Warning".lower()
    v7: str = v4[0]
    v9: Mut3 = Mut3(method17())
    v24: None
    closure6(v9, ("" + str(v7)) + "", None)
    v24 = None
    return ("\u001b[93m" + v9.l0) + method18()


def method50(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v11: Mut3 = Mut3(method17())
    v25: None
    closure6(v11, "{ ", None)
    v25 = None
    v44_1: None
    closure6(v11, "path", None)
    v44_1 = None
    v63: None
    closure6(v11, " = ", None)
    v63 = None
    v80: None
    closure6(v11, v8, None)
    v80 = None
    v99: None
    closure6(v11, "; ", None)
    v99 = None
    v118: None
    closure6(v11, "ex", None)
    v118 = None
    v135: None
    closure6(v11, " = ", None)
    v135 = None
    v152: None
    closure6(v11, v9, None)
    v152 = None
    v171: None
    closure6(v11, " }", None)
    v171 = None
    v177: str = v11.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "delete_file_async") + " / ") + v177)


def closure27(v0: str, v1: Exception, unit_var: None) -> None:
    if method11(US0(3)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v46_1: int64 | None = pattern_input[5]
        v45_1: Mut4 = pattern_input[4]
        v44_1: Mut3 = pattern_input[3]
        v43_1: Mut2 = pattern_input[2]
        v42_1: Mut1 = pattern_input[1]
        v41_1: Mut0 = pattern_input[0]
        method22(method50(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method49(), method19(v0), to_text(interpolate("%A%P()", [v1]))))



def method43(v0: str, v1: int64) -> Async[int64]:
    def _arrow349(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[int64]:
        def _arrow344(__unit: None=None) -> Async[int64]:
            return singleton.Return(v1)

        def _arrow348(_arg: Exception) -> Async[int64]:
            v45744: bool = op_modulus(v1, int64(100)) == int64(0)
            def _arrow345(__unit: None=None) -> Async[None]:
                v45844: None
                closure27(v0, _arg, None)
                v45844 = None
                return singleton.Zero()

            def _arrow347(__unit: None=None) -> Async[int64]:
                v45956: Async[None] = sleep(10)
                def _arrow346(__unit: None=None) -> Async[int64]:
                    v45965: Async[int64] = method42(v0, op_addition(v1, int64(1)))
                    return singleton.ReturnFrom(v45965)

                return singleton.Bind(v45956, _arrow346)

            return singleton.Combine(_arrow345() if v45744 else singleton.Zero(), singleton.Delay(_arrow347))

        return singleton.TryWith(singleton.Delay(_arrow344), _arrow348)

    return singleton.Delay(_arrow349)


def method42(v0: str, v1: int64) -> Async[int64]:
    return None


def method41(v0: str) -> Async[int64]:
    return method42(v0, int64(0))


def closure22(unit_var: None, v0: str) -> Async[int64]:
    return method41(v0)


def method54(v0: str, v1: str) -> None:
    pass


def method55(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str, v10: str) -> str:
    v12: Mut3 = Mut3(method17())
    v26: None
    closure6(v12, "{ ", None)
    v26 = None
    v45_1: None
    closure6(v12, "old_path", None)
    v45_1 = None
    v64: None
    closure6(v12, " = ", None)
    v64 = None
    v81: None
    closure6(v12, v8, None)
    v81 = None
    v100: None
    closure6(v12, "; ", None)
    v100 = None
    v119: None
    closure6(v12, "new_path", None)
    v119 = None
    v136: None
    closure6(v12, " = ", None)
    v136 = None
    v153: None
    closure6(v12, v9, None)
    v153 = None
    v170: None
    closure6(v12, "; ", None)
    v170 = None
    v189: None
    closure6(v12, "ex", None)
    v189 = None
    v206: None
    closure6(v12, " = ", None)
    v206 = None
    v223: None
    closure6(v12, v10, None)
    v223 = None
    v242: None
    closure6(v12, " }", None)
    v242 = None
    v248: str = v12.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "move_file_async") + " / ") + v248)


def closure30(v0: str, v1: str, v2: Exception, unit_var: None) -> None:
    if method11(US0(3)):
        v21: None
        closure0(None, None)
        v21 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v47_1: int64 | None = pattern_input[5]
        v46_1: Mut4 = pattern_input[4]
        v45_1: Mut3 = pattern_input[3]
        v44_1: Mut2 = pattern_input[2]
        v43_1: Mut1 = pattern_input[1]
        v42_1: Mut0 = pattern_input[0]
        method22(method55(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1, method12(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1), method49(), method19(v1), method19(v0), to_text(interpolate("%A%P()", [v2]))))



def method53(v0: str, v1: str, v2: int64) -> Async[int64]:
    def _arrow355(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[int64]:
        def _arrow350(__unit: None=None) -> Async[int64]:
            method54(v0, v1)
            return singleton.Return(v2)

        def _arrow354(_arg: Exception) -> Async[int64]:
            v27377: bool = op_modulus(v2, int64(100)) == int64(0)
            def _arrow351(__unit: None=None) -> Async[None]:
                v27478: None
                closure30(v0, v1, _arg, None)
                v27478 = None
                return singleton.Zero()

            def _arrow353(__unit: None=None) -> Async[int64]:
                v27591: Async[None] = sleep(10)
                def _arrow352(__unit: None=None) -> Async[int64]:
                    v27600: Async[int64] = method52(v0, v1, op_addition(v2, int64(1)))
                    return singleton.ReturnFrom(v27600)

                return singleton.Bind(v27591, _arrow352)

            return singleton.Combine(_arrow351() if v27377 else singleton.Zero(), singleton.Delay(_arrow353))

        return singleton.TryWith(singleton.Delay(_arrow350), _arrow354)

    return singleton.Delay(_arrow355)


def method52(v0: str, v1: str, v2: int64) -> Async[int64]:
    return None


def method51(v0: str, v1: str) -> Async[int64]:
    return method52(v0, v1, int64(0))


def closure29(v0: str, v1: str) -> Async[int64]:
    return method51(v0, v1)


def closure28(unit_var: None, v0: str) -> Callable[[str], Async[int64]]:
    def _arrow356(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Async[int64]:
        return closure29(v0, v)

    return _arrow356


def closure32(unit_var: None, v0: int64) -> US10:
    return US10(0, v0)


def method62(__unit: None=None) -> Callable[[int64], US10]:
    def _arrow357(v: int64) -> US10:
        return closure32(None, v)

    return _arrow357


def closure33(unit_var: None, v0: Exception) -> US10:
    return US10(1, v0)


def method63(__unit: None=None) -> Callable[[Exception], US10]:
    def _arrow358(v: Exception) -> US10:
        return closure33(None, v)

    return _arrow358


def method61(v0: Async[Any]) -> Async[US10]:
    def _arrow360(__unit: None=None, v0: Any=v0) -> Async[US10]:
        def _arrow359(_arg: Any) -> Async[US10]:
            return singleton.Return(None)

        return singleton.Bind(v0, _arrow359)

    return singleton.Delay(_arrow360)


def method64(v0: Async[US10]) -> Async[US11]:
    def _arrow362(__unit: None=None, v0: Any=v0) -> Async[US11]:
        def _arrow361(_arg: US10) -> Async[US11]:
            v307: US10 = _arg
            v313: US11 = US11(1, v307.fields[0]) if (v307.tag == 1) else US11(0, v307.fields[0])
            return singleton.Return(v313)

        return singleton.Bind(v0, _arrow361)

    return singleton.Delay(_arrow362)


def method66(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int) -> str:
    v10: Mut3 = Mut3(method17())
    v24: None
    closure6(v10, "{ ", None)
    v24 = None
    v43_1: None
    closure6(v10, "timeout", None)
    v43_1 = None
    v62: None
    closure6(v10, " = ", None)
    v62 = None
    v82: None
    closure6(v10, ("" + str(v8)) + "", None)
    v82 = None
    v101: None
    closure6(v10, " }", None)
    v101 = None
    v107: str = v10.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "async.run_with_timeout_async") + " / ") + v107)


def closure34(v0: int, unit_var: None) -> None:
    if method11(US0(0)):
        v19: None
        closure0(None, None)
        v19 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v45_1: int64 | None = pattern_input[5]
        v44_1: Mut4 = pattern_input[4]
        v43_1: Mut3 = pattern_input[3]
        v42_1: Mut2 = pattern_input[2]
        v41_1: Mut1 = pattern_input[1]
        v40_1: Mut0 = pattern_input[0]
        method22(method66(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1, method12(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1), method31(), v0))



def method67(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: str) -> str:
    v11: Mut3 = Mut3(method17())
    v25: None
    closure6(v11, "{ ", None)
    v25 = None
    v44_1: None
    closure6(v11, "timeout", None)
    v44_1 = None
    v63: None
    closure6(v11, " = ", None)
    v63 = None
    v83: None
    closure6(v11, ("" + str(v8)) + "", None)
    v83 = None
    v102: None
    closure6(v11, "; ", None)
    v102 = None
    v121: None
    closure6(v11, "ex", None)
    v121 = None
    v138: None
    closure6(v11, " = ", None)
    v138 = None
    v155: None
    closure6(v11, v9, None)
    v155 = None
    v174: None
    closure6(v11, " }", None)
    v174 = None
    v180: str = v11.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "async.run_with_timeout_async**") + " / ") + v180)


def closure35(v0: int, v1: Exception, unit_var: None) -> None:
    if method11(US0(4)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v46_1: int64 | None = pattern_input[5]
        v45_1: Mut4 = pattern_input[4]
        v44_1: Mut3 = pattern_input[3]
        v43_1: Mut2 = pattern_input[2]
        v42_1: Mut1 = pattern_input[1]
        v41_1: Mut0 = pattern_input[0]
        method22(method67(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method47(), v0, to_text(interpolate("%A%P()", [v1]))))



def method65(v0: int, v1: Async[US11]) -> Async[US2]:
    def _arrow364(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US2]:
        def _arrow363(_arg: US11) -> Async[US2]:
            v13508: US11 = _arg
            v13844: US2
            if v13508.tag == 0:
                v13844 = US2(0, v13508.fields[0])

            else: 
                v13511: Exception = v13508.fields[0]
                v13513: str = to_text(interpolate("%A%P()", [v13511]))
                if v13513.find("System.TimeoutException") >= 0:
                    v13584: None
                    closure34(v0, None)
                    v13584 = None
                    v13844 = US2(1)

                else: 
                    v13744: None
                    closure35(v0, v13511, None)
                    v13744 = None
                    v13844 = US2(1)


            return singleton.Return(v13844)

        return singleton.Bind(v1, _arrow363)

    return singleton.Delay(_arrow364)


def method60(v0: Async[int64], v1: int) -> Async[US2]:
    def _arrow366(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US2]:
        v2526: Async[Async[int64]] = start_child(v0, v1)
        def _arrow365(_arg: Async[int64]) -> Async[US2]:
            v2569: Async[US2] = method65(v1, method64(method61(catch_async(_arg))))
            return singleton.ReturnFrom(v2569)

        return singleton.Bind(v2526, _arrow365)

    return singleton.Delay(_arrow366)


def method59(v0: int, v1: Async[int64]) -> Async[US2]:
    return method60(v1, v0)


def method68(v0: Async[str]) -> Async[str | None]:
    def _arrow368(__unit: None=None, v0: Any=v0) -> Async[str | None]:
        def _arrow367(_arg: str) -> Async[str | None]:
            return singleton.Return(_arg)

        return singleton.Bind(v0, _arrow367)

    return singleton.Delay(_arrow368)


def method69(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int64, v9: str) -> str:
    v11: Mut3 = Mut3(method17())
    v25: None
    closure6(v11, "{ ", None)
    v25 = None
    v44_1: None
    closure6(v11, "retry", None)
    v44_1 = None
    v63: None
    closure6(v11, " = ", None)
    v63 = None
    v83: None
    closure6(v11, ("" + str(v8)) + "", None)
    v83 = None
    v102: None
    closure6(v11, "; ", None)
    v102 = None
    v121: None
    closure6(v11, "ex", None)
    v121 = None
    v138: None
    closure6(v11, " = ", None)
    v138 = None
    v155: None
    closure6(v11, v9, None)
    v155 = None
    v174: None
    closure6(v11, " }", None)
    v174 = None
    v180: str = v11.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.read_all_text_retry_async") + " / ") + v180)


def closure36(v0: int64, v1: Exception, unit_var: None) -> None:
    if method11(US0(1)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v46_1: int64 | None = pattern_input[5]
        v45_1: Mut4 = pattern_input[4]
        v44_1: Mut3 = pattern_input[3]
        v43_1: Mut2 = pattern_input[2]
        v42_1: Mut1 = pattern_input[1]
        v41_1: Mut0 = pattern_input[0]
        method22(method69(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method16(), v0, to_text(interpolate("%A%P()", [v1]))))



def method58(v0: str, v1: int64) -> Async[str | None]:
    def _arrow374(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[str | None]:
        def _arrow372(__unit: None=None) -> Async[str | None]:
            v29145: bool = v1 > int64(0)
            def _arrow370(__unit: None=None) -> Async[None]:
                v29169: Async[None] = ignore(method59(1000, method27(v0)))
                def _arrow369(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v29169, _arrow369)

            def _arrow371(__unit: None=None) -> Async[str | None]:
                v29181: Async[str | None] = method68(method28(v0))
                return singleton.ReturnFrom(v29181)

            return singleton.Combine(_arrow370() if v29145 else singleton.Zero(), singleton.Delay(_arrow371))

        def _arrow373(_arg_1: Exception) -> Async[str | None]:
            if (v1 == int64(0)) != True:
                v29524: None
                closure36(v1, _arg_1, None)
                v29524 = None
                return singleton.Return(None)

            else: 
                v29626: Async[str | None] = method57(v0, op_addition(v1, int64(1)))
                return singleton.ReturnFrom(v29626)


        return singleton.TryWith(singleton.Delay(_arrow372), _arrow373)

    return singleton.Delay(_arrow374)


def method57(v0: str, v1: int64) -> Async[str | None]:
    return method58(v0, v1)


def method56(v0: str) -> Async[str | None]:
    return method57(v0, int64(0))


def closure31(unit_var: None, v0: str) -> Async[str | None]:
    return method56(v0)


def closure38(unit_var: None, v0: chrono_date_time_1[chrono_utc]) -> US12:
    return US12(0, v0)


def method72(__unit: None=None) -> Callable[[chrono_date_time_1[chrono_utc]], US12]:
    def _arrow375(v: chrono_date_time_1[chrono_utc]) -> US12:
        return closure38(None, v)

    return _arrow375


def method73(__unit: None=None) -> str:
    return "hh:mm"


def method74(__unit: None=None) -> str:
    return "yyyyMMdd-HHmm-ssff-ffff-f"


def method75(__unit: None=None) -> str:
    return "hhmm"


def method71(v0: str, v1: Any) -> str:
    v2693: str = method74()
    v2699: str = to_string(v1, "M-d-y hh:mm:ss tt" if (v2693 == "") else v2693)
    v2940: Any
    raise Exception(("date_time.get_utc_offset / target: " + str(US4(5, US3(0)))) + "")
    v2955: uint8 = uint8(1) if (hours(v2940) > 0) else uint8(0)
    v2956: str = method75()
    v3204: str = ((("" + str(v2955)) + "") + to_string_1(v2940, "c", {})) + ""
    v3207: str = str(v0)
    v3212: int = (len(v2699) + len(v3204)) or 0
    v3244: int = (len(v3207) - 1) or 0
    return parse(concat(v2699, v3204, *v3207[v3212:v3244 + 1]))


def method77(__unit: None=None) -> str:
    raise Exception(("file_system.get_temp_path / target: " + str(US4(5, US3(0)))) + "")


def method78(__unit: None=None) -> str:
    return "!create_temp_path_"


def method79(v0: str, v1: str) -> str:
    raise Exception(((((("file_system.(</>) / target: " + str(US4(5, US3(0)))) + " / a: ") + v0) + " / b: ") + v1) + "")


def method81(__unit: None=None) -> str:
    return "CARGO_PKG_NAME"


def method80(__unit: None=None) -> str:
    raise Exception(("env.get_entry_assembly_name / target: " + str(US4(5, US3(0)))) + "")


def method76(v0: str) -> str:
    return method79(method79(method79(method77(), method78()), method80()), str(v0))


def method70(__unit: None=None) -> str:
    v135: Any = now()
    return method76(method71(new_guid(), v135))


def closure37(unit_var: None, unit_var_1: None) -> str:
    return method70()


def closure40(unit_var: None, v0: std_io_error) -> std_string_string:
    return None


def method83(__unit: None=None) -> Callable[[std_io_error], std_string_string]:
    def _arrow376(v: std_io_error) -> std_string_string:
        return closure40(None, v)

    return _arrow376


def closure41(unit_var: None, unit_var_1: None) -> US13:
    return US13(0)


def method84(__unit: None=None) -> Callable[[], US13]:
    def _arrow377(__unit: None=None) -> US13:
        return closure41(None, None)

    return _arrow377


def closure42(unit_var: None, v0: std_string_string) -> US13:
    return US13(1, v0)


def method85(__unit: None=None) -> Callable[[std_string_string], US13]:
    def _arrow378(v: std_string_string) -> US13:
        return closure42(None, v)

    return _arrow378


def method86(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: std_string_string) -> str:
    v11: Mut3 = Mut3(method17())
    v25: None
    closure6(v11, "{ ", None)
    v25 = None
    v44_1: None
    closure6(v11, "dir", None)
    v44_1 = None
    v63: None
    closure6(v11, " = ", None)
    v63 = None
    v80: None
    closure6(v11, v8, None)
    v80 = None
    v99: None
    closure6(v11, "; ", None)
    v99 = None
    v118: None
    closure6(v11, "error", None)
    v118 = None
    v135: None
    closure6(v11, " = ", None)
    v135 = None
    v191: None
    closure6(v11, to_text(interpolate("%A%P()", [v9])), None)
    v191 = None
    v210: None
    closure6(v11, " }", None)
    v210 = None
    v216: str = v11.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v216)


def closure43(v0: str, v1: std_string_string, unit_var: None) -> None:
    if method11(US0(4)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v46_1: int64 | None = pattern_input[5]
        v45_1: Mut4 = pattern_input[4]
        v44_1: Mut3 = pattern_input[3]
        v43_1: Mut2 = pattern_input[2]
        v42_1: Mut1 = pattern_input[1]
        v41_1: Mut0 = pattern_input[0]
        method22(method86(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method47(), v0, v1))



def method87(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v10: Mut3 = Mut3(method17())
    v24: None
    closure6(v10, "{ ", None)
    v24 = None
    v43_1: None
    closure6(v10, "dir", None)
    v43_1 = None
    v62: None
    closure6(v10, " = ", None)
    v62 = None
    v79: None
    closure6(v10, v8, None)
    v79 = None
    v98: None
    closure6(v10, " }", None)
    v98 = None
    v104: str = v10.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v104)


def closure44(v0: str, unit_var: None) -> None:
    if method11(US0(0)):
        v19: None
        closure0(None, None)
        v19 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v45_1: int64 | None = pattern_input[5]
        v44_1: Mut4 = pattern_input[4]
        v43_1: Mut3 = pattern_input[3]
        v42_1: Mut2 = pattern_input[2]
        v41_1: Mut1 = pattern_input[1]
        v40_1: Mut0 = pattern_input[0]
        method22(method87(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1, method12(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1), method31(), v0))



def closure45(v0: str, unit_var: None) -> None:
    method9(True, v0)


def method88(v0: str) -> Callable[[], None]:
    def _arrow379(__unit: None=None, v0: Any=v0) -> None:
        closure45(v0, None)

    return _arrow379


def method89(v0: str) -> Callable[[], None]:
    def _arrow380(__unit: None=None, v0: Any=v0) -> None:
        closure45(v0, None)

    return _arrow380


def method90(v0: str) -> bool:
    return None


def method91(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v11: Mut3 = Mut3(method17())
    v25: None
    closure6(v11, "{ ", None)
    v25 = None
    v44_1: None
    closure6(v11, "dir", None)
    v44_1 = None
    v63: None
    closure6(v11, " = ", None)
    v63 = None
    v80: None
    closure6(v11, v8, None)
    v80 = None
    v99: None
    closure6(v11, "; ", None)
    v99 = None
    v118: None
    closure6(v11, "result", None)
    v118 = None
    v135: None
    closure6(v11, " = ", None)
    v135 = None
    v152: None
    closure6(v11, v9, None)
    v152 = None
    v171: None
    closure6(v11, " }", None)
    v171 = None
    v177: str = v11.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v177)


def closure46(v0: str, v1: str, unit_var: None) -> None:
    if method11(US0(1)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v46_1: int64 | None = pattern_input[5]
        v45_1: Mut4 = pattern_input[4]
        v44_1: Mut3 = pattern_input[3]
        v43_1: Mut2 = pattern_input[2]
        v42_1: Mut1 = pattern_input[1]
        v41_1: Mut0 = pattern_input[0]
        method22(method91(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method16(), v0, v1))



def closure47(v0: str, unit_var: None) -> None:
    run_synchronously(ignore(method6(v0)))


def method92(v0: str) -> Callable[[], None]:
    def _arrow381(__unit: None=None, v0: Any=v0) -> None:
        closure47(v0, None)

    return _arrow381


def method93(v0: str) -> Callable[[], None]:
    def _arrow382(__unit: None=None, v0: Any=v0) -> None:
        closure47(v0, None)

    return _arrow382


def method82(v0: str) -> IDisposable:
    v758: bool = method90(v0)
    v790: bool = None
    if v790 == False:
        v901: None
        closure46(v0, to_text(interpolate("%A%P()", [{
            "CreationTime": None,
            "Exists": v790
        }])), None)
        v901 = None

    v975: Callable[[], None] = method93(v0)
    class ObjectExpr383(IDisposable):
        def Dispose(self, __unit: None=None, v0: Any=v0) -> None:
            v975(None)

    return ObjectExpr383()


def closure39(unit_var: None, unit_var_1: None) -> tuple[str, IDisposable]:
    v0: str = method70()
    return (v0, method82(v0))


def closure49(v0: int, v1: str, v2: int, v3: str) -> str:
    if v2 >= v0:
        return v3

    else: 
        return method95(v0, v1, v2 + 1)(v3 + v1)



def method95(v0: int, v1: str, v2: int) -> Callable[[str], str]:
    def _arrow384(v: str, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> str:
        return closure49(v0, v1, v2, v)

    return _arrow384


def method94(v0: str) -> str:
    v13: str = method95(32 - len(v0), "0", 0)("") + v0
    v972: int = (8 - 1) or 0
    v1004: int = (12 - 1) or 0
    v1036: int = (16 - 1) or 0
    v1068: int = (20 - 1) or 0
    v1100: int = (32 - 1) or 0
    return parse((((((((v13[0:v972 + 1] + "-") + v13[8:v1004 + 1]) + "-") + v13[12:v1036 + 1]) + "-") + v13[16:v1068 + 1]) + "-") + v13[20:v1100 + 1])


def closure48(unit_var: None, v0: str) -> tuple[str, IDisposable]:
    v2: str = method76(method94(v0))
    return (v2, method82(v2))


def closure50(unit_var: None, unit_var_1: None) -> str:
    return "c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral"


def closure52(unit_var: None, v0: std_path_path_buf) -> US14:
    return US14(0, v0)


def method99(__unit: None=None) -> Callable[[std_path_path_buf], US14]:
    def _arrow385(v: std_path_path_buf) -> US14:
        return closure52(None, v)

    return _arrow385


def closure53(unit_var: None, v0: str) -> US14:
    return US14(1, v0)


def method100(__unit: None=None) -> Callable[[str], US14]:
    def _arrow386(v: str) -> US14:
        return closure53(None, v)

    return _arrow386


def method103(v0: str) -> str | None:
    return None


def method102(v0: str, v1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2: uint8, v3: str, v4: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v5: str = method19(v4)
    v6: str | None = method103(v4)
    v31_1: US5 = default_arg(map(method5(), v6), US5(1))
    v36_1: Mut3 = Mut3(method17())
    v48_1: None
    closure6(v36_1, v3, None)
    v48_1 = None
    v54: str = v36_1.l0
    if v2 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0) + " / n: ") + str(v2)) + " / path\': ") + v4) + " / name: ") + v5) + ""))

    elif v31_1.tag == 0:
        if v4 != "":
            v116: FSharpResult_2[std_path_path_buf, std_io_error] = v1(v2 + uint8(1), v31_1.fields[0])
            v117: Callable[[std_io_error], str] = method44()
            v130: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v117(v116.fields[0])) if (v116.tag == 1) else FSharpResult_2(0, v116.fields[0])
            v133: Callable[[std_path_path_buf], US14] = method99()
            v134: Callable[[str], US14] = method100()
            v136: US14 = v134(v130.fields[0]) if (v130.tag == 1) else v133(v130.fields[0])
            if v136.tag == 0:
                return FSharpResult_2(0, method79(to_string_2(v136.fields[0]), v5))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v136.fields[0]) + " / error: ") + v54) + " / name: ") + v5) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v54) + " / path\': ") + v4) + " / name: ") + v5) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v54) + " / path\': ") + v4) + " / name: ") + v5) + ""))



def method101(v0: str, v1: uint8, v2: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return None


def closure55(v0: str, v1: uint8, v2: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return method101(v0, v1, v2)


def closure54(v0: str, v1: uint8) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
    def _arrow387(v: str, v0: Any=v0, v1: Any=v1) -> FSharpResult_2[std_path_path_buf, std_io_error]:
        return closure55(v0, v1, v)

    return _arrow387


def method104(v0: str, v1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2: uint8, v3: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v4: str = method19(v0)
    v5: str | None = method103(v0)
    v30: US5 = default_arg(map(method5(), v5), US5(1))
    v35_1: Mut3 = Mut3(method17())
    v47_1: None
    closure6(v35_1, v3, None)
    v47_1 = None
    v53_1: str = v35_1.l0
    if v2 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0) + " / n: ") + str(v2)) + " / path\': ") + v0) + " / name: ") + v4) + ""))

    elif v30.tag == 0:
        if v0 != "":
            v115: FSharpResult_2[std_path_path_buf, std_io_error] = v1(v2 + uint8(1), v30.fields[0])
            v116: Callable[[std_io_error], str] = method44()
            v129: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v116(v115.fields[0])) if (v115.tag == 1) else FSharpResult_2(0, v115.fields[0])
            v132: Callable[[std_path_path_buf], US14] = method99()
            v133: Callable[[str], US14] = method100()
            v135: US14 = v133(v129.fields[0]) if (v129.tag == 1) else v132(v129.fields[0])
            if v135.tag == 0:
                return FSharpResult_2(0, method79(to_string_2(v135.fields[0]), v4))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v135.fields[0]) + " / error: ") + v53_1) + " / name: ") + v4) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v53_1) + " / path\': ") + v0) + " / name: ") + v4) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v53_1) + " / path\': ") + v0) + " / name: ") + v4) + ""))



def method98(v0: str, v1: uint8) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return None


def method106(v0: bool) -> enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]):
    return None


def method107(__unit: None=None) -> enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]):
    return None


def method108(v0: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]), v1: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)])) -> bool:
    return None


def method110(v0: str, v1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2: uint8, v3: std_io_error, v4: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v5: str = method19(v4)
    v6: str | None = method103(v4)
    v31_1: US5 = default_arg(map(method5(), v6), US5(1))
    v36_1: Mut3 = Mut3(method17())
    v87: None
    closure6(v36_1, to_text(interpolate("%A%P()", [v3])), None)
    v87 = None
    v93: str = v36_1.l0
    if v2 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0) + " / n: ") + str(v2)) + " / path\': ") + v4) + " / name: ") + v5) + ""))

    elif v31_1.tag == 0:
        if v4 != "":
            v155: FSharpResult_2[std_path_path_buf, std_io_error] = v1(v2 + uint8(1), v31_1.fields[0])
            v156: Callable[[std_io_error], str] = method44()
            v169: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v156(v155.fields[0])) if (v155.tag == 1) else FSharpResult_2(0, v155.fields[0])
            v172: Callable[[std_path_path_buf], US14] = method99()
            v173: Callable[[str], US14] = method100()
            v175: US14 = v173(v169.fields[0]) if (v169.tag == 1) else v172(v169.fields[0])
            if v175.tag == 0:
                return FSharpResult_2(0, method79(to_string_2(v175.fields[0]), v5))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v175.fields[0]) + " / error: ") + v93) + " / name: ") + v5) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v93) + " / path\': ") + v4) + " / name: ") + v5) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v93) + " / path\': ") + v4) + " / name: ") + v5) + ""))



def method109(v0: str, v1: uint8, v2: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v42_1: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]) = method106(None) or 0
    v44_1: bool = method108(method107(), v42_1)
    if v44_1:
        return FSharpResult_2(0, None)

    else: 
        def v178(v: uint8, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
            return closure56(v0, v)

        return method110(v0, uncurry2(v178), v1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / result: ") + str(v44_1)) + " / path\': ") + v2) + " / n: ") + str(v1)) + ""), v2)



def closure57(v0: str, v1: uint8, v2: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return method109(v0, v1, v2)


def closure56(v0: str, v1: uint8) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
    def _arrow388(v: str, v0: Any=v0, v1: Any=v1) -> FSharpResult_2[std_path_path_buf, std_io_error]:
        return closure57(v0, v1, v)

    return _arrow388


def method111(v0: str, v1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2: uint8, v3: std_io_error) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v4: str = method19(v0)
    v5: str | None = method103(v0)
    v30: US5 = default_arg(map(method5(), v5), US5(1))
    v35_1: Mut3 = Mut3(method17())
    v86: None
    closure6(v35_1, to_text(interpolate("%A%P()", [v3])), None)
    v86 = None
    v92: str = v35_1.l0
    if v2 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0) + " / n: ") + str(v2)) + " / path\': ") + v0) + " / name: ") + v4) + ""))

    elif v30.tag == 0:
        if v0 != "":
            v154: FSharpResult_2[std_path_path_buf, std_io_error] = v1(v2 + uint8(1), v30.fields[0])
            v155: Callable[[std_io_error], str] = method44()
            v168: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v155(v154.fields[0])) if (v154.tag == 1) else FSharpResult_2(0, v154.fields[0])
            v171: Callable[[std_path_path_buf], US14] = method99()
            v172: Callable[[str], US14] = method100()
            v174: US14 = v172(v168.fields[0]) if (v168.tag == 1) else v171(v168.fields[0])
            if v174.tag == 0:
                return FSharpResult_2(0, method79(to_string_2(v174.fields[0]), v4))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v174.fields[0]) + " / error: ") + v92) + " / name: ") + v4) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v92) + " / path\': ") + v0) + " / name: ") + v4) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v92) + " / path\': ") + v0) + " / name: ") + v4) + ""))



def method105(v0: str, v1: uint8) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v41_1: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]) = method106(None) or 0
    v43_1: bool = method108(method107(), v41_1)
    if v43_1:
        return FSharpResult_2(0, None)

    else: 
        def v177(v: uint8, v0: Any=v0, v1: Any=v1) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
            return closure56(v0, v)

        return method111(v0, uncurry2(v177), v1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / result: ") + str(v43_1)) + " / path\': ") + v0) + " / n: ") + str(v1)) + ""))



def method97(v0: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return FSharpResult_2()


def closure58(unit_var: None, v0: std_path_path_buf) -> US15:
    return US15(0, v0)


def method112(__unit: None=None) -> Callable[[std_path_path_buf], US15]:
    def _arrow389(v: std_path_path_buf) -> US15:
        return closure58(None, v)

    return _arrow389


def method114(v0: str) -> str:
    return v0


def method115(__unit: None=None) -> str:
    return ""


def method113(v0: str, v1: str, v2: str) -> str:
    return method115()


def method96(v0: str) -> str:
    if v0 == "":
        return ""

    else: 
        v3: FSharpResult_2[std_path_path_buf, std_io_error] = method97(v0)
        v13: std_path_path_buf | None = None if (v3.tag == 1) else v3.fields[0]
        v43_1: US15 = default_arg(map(method112(), v13), US15(1))
        v86: str = to_string_2(v43_1.fields[0]) if (v43_1.tag == 0) else v0
        v91: str = method113("^\\\\\\\\\\?\\\\", "", v0 if (v86 == "") else v86)
        if len(v91) < 2:
            return v0

        else: 
            def _arrow390(__unit: None=None, v0: Any=v0) -> str:
                _arg: str = v91[0]
                return _arg.lower()

            return replace(concat(_arrow390(), *v91[1:len(v91)]), "\\", "/")




def closure51(unit_var: None, v0: str) -> str:
    return method96(v0)


def method117(__unit: None=None) -> str:
    return None


def method118(v0: int, v1: Mut5) -> bool:
    return v1.l0 < v0


def method119(v0: int, v1: Mut6) -> bool:
    return v1.l0 < v0


def method120(__unit: None=None) -> str:
    return "/"


def method121(v0: str) -> str:
    return v0


def method116(v0: str) -> str:
    return None


def closure59(unit_var: None, v0: str) -> str:
    return method116(v0)


def method122(v0: str) -> str:
    return method96(method116(v0))


def closure60(unit_var: None, v0: str) -> str:
    return method122(v0)


def closure61(unit_var: None, v0: str) -> str:
    return concat("file:///", *trim_start(v0, *to_array(singleton_1("/"))))


def closure63(unit_var: None, v0: str) -> bool:
    return method34(v0)


def closure64(unit_var: None, v0: str) -> bool:
    return method10(v0)


def method126(v0_mut: str, v1_mut: str, v2_mut: bool, v3_mut: Callable[[str], bool], v4_mut: str) -> US17:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        if v3(method79(v4, v0)):
            return US17(0, v4)

        else: 
            v8: str | None = method103(v4)
            v33_1: US5 = default_arg(map(method5(), v8), US5(1))
            if v33_1.tag == 0:
                v0_mut = v0
                v1_mut = v1
                v2_mut = v2
                v3_mut = v3
                v4_mut = v33_1.fields[0]
                continue

            else: 
                return US17(1, concat("file_system.find_parent / No parent for ", *"file" if v2 else "dir") + ((((((" \'" + v0) + "\' at \'") + v1) + "\' (until \'") + v4) + "\')"))


        break


def method125(v0: str, v1: str, v2: bool, v3: Callable[[str], bool]) -> US17:
    if v3(method79(v1, v0)):
        return US17(0, v1)

    else: 
        v7: str | None = method103(v1)
        v32_1: US5 = default_arg(map(method5(), v7), US5(1))
        if v32_1.tag == 0:
            return method126(v0, v1, v2, v3, v32_1.fields[0])

        else: 
            return US17(1, concat("file_system.find_parent / No parent for ", *"file" if v2 else "dir") + ((((((" \'" + v0) + "\' at \'") + v1) + "\' (until \'") + v1) + "\')"))




def method124(v0: US16, v1: str, v2: str) -> US17:
    v3: bool = True if (v0.tag == 0) else False
    def _arrow391(v: str, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> bool:
        return closure63(None, v)

    def _arrow392(v_1: str, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> bool:
        return closure64(None, v_1)

    return method125(v1, v2, v3, _arrow391 if v3 else _arrow392)


def method127(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v11: Mut3 = Mut3(method17())
    v25: None
    closure6(v11, "{ ", None)
    v25 = None
    v44_1: None
    closure6(v11, "dir", None)
    v44_1 = None
    v63: None
    closure6(v11, " = ", None)
    v63 = None
    v80: None
    closure6(v11, v8, None)
    v80 = None
    v99: None
    closure6(v11, "; ", None)
    v99 = None
    v118: None
    closure6(v11, "error", None)
    v118 = None
    v135: None
    closure6(v11, " = ", None)
    v135 = None
    v152: None
    closure6(v11, v9, None)
    v152 = None
    v171: None
    closure6(v11, " }", None)
    v171 = None
    v177: str = v11.l0
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.get_workspace_root") + " / ") + v177)


def closure65(v0: str, v1: str, unit_var: None) -> None:
    if method11(US0(3)):
        v20: None
        closure0(None, None)
        v20 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v46_1: int64 | None = pattern_input[5]
        v45_1: Mut4 = pattern_input[4]
        v44_1: Mut3 = pattern_input[3]
        v43_1: Mut2 = pattern_input[2]
        v42_1: Mut1 = pattern_input[1]
        v41_1: Mut0 = pattern_input[0]
        method22(method127(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method49(), v0, v1))



def method123(v0: str) -> US5:
    v5: US17 = method124(US16(1), method79("spiral", "workspace"), v0)
    if v5.tag == 0:
        return US5(0, method96(v5.fields[0]))

    else: 
        v72: None
        closure65(v0, v5.fields[0], None)
        v72 = None
        return US5(1)



def closure62(unit_var: None, unit_var_1: None) -> str:
    v1: US5 = method123(method117())
    v7: US5 = US5(0, v1.fields[0]) if (v1.tag == 0) else method123("c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral")
    v13: US5 = US5(0, v7.fields[0]) if (v7.tag == 0) else method123("/workspaces")
    v17: str
    if v13.tag == 0:
        v17 = v13.fields[0]

    else: 
        raise Exception("Option does not have a value.")

    def _arrow393(__unit: None=None, unit_var: Any=unit_var, unit_var_1: Any=unit_var_1) -> str:
        v25: US5 = method123(value_10(method103(v17)))
        if v25.tag == 0:
            return v25.fields[0]

        else: 
            raise Exception("Option does not have a value.")


    return method79(_arrow393() if ("deps" == method19(v17)) else v17, "polyglot")


def closure67(v0: Exception, unit_var: None) -> Exception:
    return v0


def method128(v0: str) -> None:
    pass


def closure66(unit_var: None, v0: str) -> None:
    method128(v0)


def closure68(unit_var: None, v0: bool) -> None:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    def _arrow394(v: str, unit_var: Any=unit_var, v0: Any=v0) -> None:
        closure66(None, v)

    def _arrow395(v_1: str, unit_var: Any=unit_var, v0: Any=v0) -> None:
        closure2(None, v_1)

    v58: Callable[[str], None] = _arrow394 if v0 else _arrow395
    pattern_input[1].l0 = v58


def method129(v0: str, v1: str) -> None:
    if method10(v0) == False:
        v4: IDisposable = method82(v0)

    v9: str = default_arg(method103(v1), "")
    if method10(v9) == False:
        v14_1: IDisposable = method82(v9)

    def _arrow396(__unit: None=None, v0: Any=v0, v1: Any=v1) -> bool:
        v16_1: FSharpResult_2[std_path_path_buf, std_io_error] = method97(v1)
        return True

    if _arrow396() if method10(v1) else False:
        method9(True, v1)

    if method10(v1) == False:
        pass



def closure70(v0: str, v1: str) -> None:
    method129(v0, v1)


def closure69(unit_var: None, v0: str) -> Callable[[str], None]:
    def _arrow397(v: str, unit_var: Any=unit_var, v0: Any=v0) -> None:
        closure70(v0, v)

    return _arrow397


def closure72(v0: str, v1: str) -> str:
    return method79(v0, v1)


def closure71(unit_var: None, v0: str) -> Callable[[str], str]:
    def _arrow398(v: str, unit_var: Any=unit_var, v0: Any=v0) -> str:
        return closure72(v0, v)

    return _arrow398


v14: None = None

def _arrow399(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow399

def _expr400():
    v15(None)
    return v14


v16: None = _expr400()

def _arrow401(v: str) -> Async[int64]:
    return closure3(None, v)


v31: Callable[[str], Async[int64]] = _arrow401

def delete_directory_async(x: str) -> Async[int64]:
    return v31(x)


def _arrow402(v: US6) -> Callable[[str], Async[int64]]:
    return closure10(None, v)


v32: Callable[[US6, str], Async[int64]] = _arrow402

def wait_for_file_access(x: US6) -> Callable[[str], Async[int64]]:
    return v32(x)


def _arrow403(v: str) -> Async[int64]:
    return closure13(None, v)


v33: Callable[[str], Async[int64]] = _arrow403

def wait_for_file_access_read(x: str) -> Async[int64]:
    return v33(x)


def _arrow404(v: str) -> Async[str]:
    return closure14(None, v)


v34: Callable[[str], Async[str]] = _arrow404

def read_all_text_async(x: str) -> Async[str]:
    return v34(x)


def _arrow405(v: str) -> Callable[[str], bool]:
    return closure16(None, v)


v35: Callable[[str, str], bool] = _arrow405

def file_exists_content(x: str) -> Callable[[str], bool]:
    return v35(x)


def _arrow406(v: str) -> Callable[[str], Async[None]]:
    return closure18(None, v)


v36: Callable[[str, str], Async[None]] = _arrow406

def write_all_text_async(x: str) -> Callable[[str], Async[None]]:
    return v36(x)


def _arrow407(v: str) -> Callable[[str], Async[None]]:
    return closure20(None, v)


v37: Callable[[str, str], Async[None]] = _arrow407

def write_all_text_exists(x: str) -> Callable[[str], Async[None]]:
    return v37(x)


def _arrow408(v: str) -> Async[int64]:
    return closure22(None, v)


v38: Callable[[str], Async[int64]] = _arrow408

def delete_file_async(x: str) -> Async[int64]:
    return v38(x)


def _arrow409(v: str) -> Callable[[str], Async[int64]]:
    return closure28(None, v)


v39: Callable[[str, str], Async[int64]] = _arrow409

def move_file_async(x: str) -> Callable[[str], Async[int64]]:
    return v39(x)


def _arrow410(v: str) -> Async[str | None]:
    return closure31(None, v)


v40: Callable[[str], Async[str | None]] = _arrow410

def read_all_text_retry_async(x: str) -> Async[str | None]:
    return v40(x)


def _arrow411(__unit: None=None) -> str:
    return closure37(None, None)


v41: Callable[[], str] = _arrow411

def create_temp_path(__unit: None=None) -> str:
    return v41(None)


def _arrow412(__unit: None=None) -> tuple[str, IDisposable]:
    return closure39(None, None)


v42: Callable[[], tuple[str, IDisposable]] = _arrow412

def create_temp_dir(__unit: None=None) -> tuple[str, IDisposable]:
    return v42(None)


def _arrow413(v: str) -> tuple[str, IDisposable]:
    return closure48(None, v)


v43: Callable[[str], tuple[str, IDisposable]] = _arrow413

def create_temp_dir_0027(x: str) -> tuple[str, IDisposable]:
    return v43(x)


def _arrow414(__unit: None=None) -> str:
    return closure50(None, None)


v44: Callable[[], str] = _arrow414

def get_source_directory(__unit: None=None) -> str:
    return v44(None)


def _arrow415(v: str) -> str:
    return closure51(None, v)


v45: Callable[[str], str] = _arrow415

def normalize_path(x: str) -> str:
    return v45(x)


def _arrow416(v: str) -> str:
    return closure59(None, v)


v46: Callable[[str], str] = _arrow416

def get_full_path(x: str) -> str:
    return v46(x)


def _arrow417(v: str) -> str:
    return closure60(None, v)


v47: Callable[[str], str] = _arrow417

def standardize_path(x: str) -> str:
    return v47(x)


def _arrow418(v: str) -> str:
    return closure61(None, v)


v48: Callable[[str], str] = _arrow418

def new_file_uri(x: str) -> str:
    return v48(x)


def _arrow419(__unit: None=None) -> str:
    return closure62(None, None)


v49: Callable[[], str] = _arrow419

def get_workspace_root(__unit: None=None) -> str:
    return v49(None)


def _arrow420(v: str) -> None:
    closure66(None, v)


v50: Callable[[str], None] = _arrow420

def trace_file(x: str) -> None:
    v50(x)


def _arrow421(v: bool) -> None:
    closure68(None, v)


v51: Callable[[bool], None] = _arrow421

def init_trace_file(x: bool) -> None:
    v51(x)


def _arrow422(v: str) -> Callable[[str], None]:
    return closure69(None, v)


v52: Callable[[str, str], None] = _arrow422

def link_directory(x: str) -> Callable[[str], None]:
    return v52(x)


def _arrow423(v: str) -> Callable[[str], str]:
    return closure71(None, v)


v53: Callable[[str, str], str] = _arrow423

def op_less_divide_greater(x: str) -> Callable[[str], str]:
    return v53(x)


