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
from fable_modules.fable_library.util import (create_atom, IDisposable, to_enumerable, compare, uncurry2)
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

def method3(v0_1: str) -> str:
    return v0_1


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0_1: str) -> US5:
    return US5(0, v0_1)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow308(v: str) -> US5:
        return closure1(None, v)

    return _arrow308


def method2(v0_1: str) -> str:
    v34_1: IOsEnviron = os
    v36_1: Any = v34.environ
    _v41: (str | None) | None = None
    x: str | None = v36.get(v0_1)
    _v41 = some(x)
    v47: str | None
    if _v41 is None:
        raise Exception("optionm\'.of_obj / _v41=None")

    else: 
        v47 = value_10(_v41)

    v74: US5 = default_arg(map(method5(), v47), US5(1))
    if v74.tag == 0:
        return v74.fields[0]

    else: 
        return ""



def method1(__unit: None=None) -> tuple[US1, US2]:
    v1_1: str = method2("TRACE_LEVEL")
    v6: str = "Critical".lower()
    v13: str = "Warning".lower()
    v20_1: str = "Info".lower()
    v27_1: str = "Debug".lower()
    v34_1: str = "Verbose".lower()
    v41: US1 = US1(0, US0(0)) if ("Verbose" == v1_1) else US1(1)
    def _arrow309(__unit: None=None) -> US1:
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
                        v76: US1 = US1(0, US0(0)) if (v34_1 == v1_1) else US1(1)
                        if v76.tag == 0:
                            return US1(0, v76.fields[0])

                        else: 
                            v83: US1 = US1(0, US0(1)) if (v27_1 == v1_1) else US1(1)
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









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow309(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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



def method10(v0_1: str) -> bool:
    return None


def method9(v0_1: bool, v1_1: str) -> None:
    pass


def method11(v0_1: US0) -> bool:
    v3: None
    closure0(None, None)
    v3 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v42: US0 = pattern_input[4].l0
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

        return find(v0_1, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr310())) >= find(v42, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr311()))



def closure5(unit_var: None, v0_1: int64) -> US2:
    return US2(0, v0_1)


def method13(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow312(v: int64) -> US2:
        return closure5(None, v)

    return _arrow312


def method14(__unit: None=None) -> str:
    return "hh:mm:ss"


def method15(__unit: None=None) -> str:
    return "HH:mm:ss"


def method12(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v748: US2 = default_arg(map(method13(), v5), US2(1))
    v866: Any
    if v748.tag == 0:
        v818: Any = create(op_subtraction(from_value(ticks_1(now()), False), v748.fields[0]))
        v866 = create_1(1, 1, 1, hours(v818), minutes(v818), seconds(v818), milliseconds(v818))

    else: 
        v866 = now()

    v868: str = method15()
    return to_string(v866, "M-d-y hh:mm:ss tt" if (v868 == "") else v868)


def method18(__unit: None=None) -> str:
    return ""


def closure6(v0_1: Mut3, v1_1: str, unit_var: None) -> None:
    v3: str = v0_1.l0 + v1_1
    v0_1.l0 = v3


def method17(v0_1: str) -> str:
    v2_1: Mut3 = Mut3(method18())
    v9: None
    closure6(v2_1, ("" + str(v0_1)) + "", None)
    v9 = None
    return v2_1.l0


def method19(__unit: None=None) -> str:
    return "\u001b[0m"


def method16(__unit: None=None) -> str:
    v4: str = "Debug".lower()
    return ("\u001b[94m" + method17(v4[0])) + method19()


def method20(v0_1: str) -> str:
    raise Exception(((("file_system.get_file_name / target: " + str(US4(5, US3(0)))) + " / path: ") + v0_1) + "")


def method22(v0_1: str, v1_1: str) -> str:
    v3: Mut3 = Mut3(method18())
    v12: None
    closure6(v3, "{ ", None)
    v12 = None
    v23_1: None
    closure6(v3, "ex", None)
    v23_1 = None
    v34_1: None
    closure6(v3, " = ", None)
    v34_1 = None
    v43: None
    closure6(v3, v0_1, None)
    v43 = None
    v54: None
    closure6(v3, "; ", None)
    v54 = None
    v65: None
    closure6(v3, "path", None)
    v65 = None
    v74: None
    closure6(v3, " = ", None)
    v74 = None
    v83: None
    closure6(v3, v1_1, None)
    v83 = None
    v94: None
    closure6(v3, " }", None)
    v94 = None
    return v3.l0


def method23(v0_1: str) -> str:
    return trim_end(trim_start(v0_1, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method21(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v10: str = method22(v8, v9)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "file_system.delete_directory_async") + " / ") + v10) + "")


def closure7(v0_1: Mut0, unit_var: None) -> None:
    v2_1: int64 = op_addition(v0_1.l0, int64(1))
    v0_1.l0 = v2_1


def closure9(v0_1: str, unit_var: None) -> None:
    print(v0_1)


def closure8(unit_var: None, v0_1: str) -> None:
    v3: None
    closure9(v0_1, None)
    v3 = None


def method24(v0_1: str) -> None:
    v3: None
    closure0(None, None)
    v3 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v44: None
    closure7(pattern_input[0], None)
    v44 = None
    closure8(None, v0_1)
    pattern_input[1].l0(v0_1)


def closure4(v0_1: str, v1_1: Exception, unit_var: None) -> None:
    if method11(US0(1)):
        v6: None
        closure0(None, None)
        v6 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v32_1: int64 | None = pattern_input[5]
        v31_1: Mut4 = pattern_input[4]
        v30_1: Mut3 = pattern_input[3]
        v29_1: Mut2 = pattern_input[2]
        v28_1: Mut1 = pattern_input[1]
        v27_1: Mut0 = pattern_input[0]
        method24(method21(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1, method12(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1), method16(), to_text(interpolate("%A%P()", [v1_1])), method20(v0_1)))



def method8(v0_1: str, v1_1: int64) -> Async[int64]:
    def _arrow318(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> Async[int64]:
        def _arrow313(__unit: None=None) -> Async[int64]:
            method9(True, v0_1)
            return singleton.Return(v1_1)

        def _arrow317(_arg: Exception) -> Async[int64]:
            v1888: bool = op_modulus(v1_1, int64(100)) == int64(0)
            def _arrow314(__unit: None=None) -> Async[None]:
                v1891: None
                closure4(v0_1, _arg, None)
                v1891 = None
                return singleton.Zero()

            def _arrow316(__unit: None=None) -> Async[int64]:
                v1989: Async[None] = sleep(10)
                def _arrow315(__unit: None=None) -> Async[int64]:
                    v1998: Async[int64] = method7(v0_1, op_addition(v1_1, int64(1)))
                    return singleton.ReturnFrom(v1998)

                return singleton.Bind(v1989, _arrow315)

            return singleton.Combine(_arrow314() if v1888 else singleton.Zero(), singleton.Delay(_arrow316))

        return singleton.TryWith(singleton.Delay(_arrow313), _arrow317)

    return singleton.Delay(_arrow318)


def method7(v0_1: str, v1_1: int64) -> Async[int64]:
    return None


def method6(v0_1: str) -> Async[int64]:
    return method7(v0_1, int64(0))


def closure3(unit_var: None, v0_1: str) -> Async[int64]:
    return method6(v0_1)


def method29(v0_1: str, v1_1: int64, v2_1: str) -> str:
    v4: Mut3 = Mut3(method18())
    v13: None
    closure6(v4, "{ ", None)
    v13 = None
    v24_1: None
    closure6(v4, "path", None)
    v24_1 = None
    v35_1: None
    closure6(v4, " = ", None)
    v35_1 = None
    v44: None
    closure6(v4, v0_1, None)
    v44 = None
    v55: None
    closure6(v4, "; ", None)
    v55 = None
    v66: None
    closure6(v4, "retry", None)
    v66 = None
    v75: None
    closure6(v4, " = ", None)
    v75 = None
    v84: None
    closure6(v4, ("" + str(v1_1)) + "", None)
    v84 = None
    v93: None
    closure6(v4, "; ", None)
    v93 = None
    v104: None
    closure6(v4, "ex", None)
    v104 = None
    v113: None
    closure6(v4, " = ", None)
    v113 = None
    v122: None
    closure6(v4, v2_1, None)
    v122 = None
    v133: None
    closure6(v4, " }", None)
    v133 = None
    return v4.l0


def method28(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: int64, v10: str) -> str:
    v11: str = method29(v8, v9, v10)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "file_system.wait_for_file_access") + " / ") + v11) + "")


def closure12(v0_1: str, v1_1: int64, v2_1: Exception, unit_var: None) -> None:
    if method11(US0(1)):
        v7: None
        closure0(None, None)
        v7 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v33_1: int64 | None = pattern_input[5]
        v32_1: Mut4 = pattern_input[4]
        v31_1: Mut3 = pattern_input[3]
        v30_1: Mut2 = pattern_input[2]
        v29_1: Mut1 = pattern_input[1]
        v28_1: Mut0 = pattern_input[0]
        method24(method28(v28_1, v29_1, v30_1, v31_1, v32_1, v33_1, method12(v28_1, v29_1, v30_1, v31_1, v32_1, v33_1), method16(), method20(v0_1), v1_1, to_text(interpolate("%A%P()", [v2_1]))))



def method27(v0_1: US6, v1_1: str, v2_1: int64, v3: US8, v4: US7) -> Async[int64]:
    def _arrow325(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1, v3: Any=v3, v4: Any=v4) -> Async[int64]:
        def _arrow320(__unit: None=None) -> Async[int64]:
            def _arrow319(_arg: Any) -> Async[int64]:
                return singleton.Return(v2_1)

            return singleton.Using(None, _arrow319)

        def _arrow324(_arg_1: Exception) -> Async[int64]:
            v2879: bool = (op_modulus(v2_1, int64(100)) == int64(0)) if (v2_1 > int64(0)) else False
            def _arrow321(__unit: None=None) -> Async[None]:
                v2882: None
                closure12(v1_1, v2_1, _arg_1, None)
                v2882 = None
                return singleton.Zero()

            def _arrow323(__unit: None=None) -> Async[int64]:
                v2980: Async[None] = sleep(10)
                def _arrow322(__unit: None=None) -> Async[int64]:
                    v2989: Async[int64] = method26(v0_1, v1_1, op_addition(v2_1, int64(1)))
                    return singleton.ReturnFrom(v2989)

                return singleton.Bind(v2980, _arrow322)

            return singleton.Combine(_arrow321() if v2879 else singleton.Zero(), singleton.Delay(_arrow323))

        return singleton.TryWith(singleton.Delay(_arrow320), _arrow324)

    return singleton.Delay(_arrow325)


def method26(v0_1: US6, v1_1: str, v2_1: int64) -> Async[int64]:
    return None


def method25(v0_1: US6, v1_1: str) -> Async[int64]:
    return method26(v0_1, v1_1, int64(0))


def closure11(v0_1: US6, v1_1: str) -> Async[int64]:
    return method25(v0_1, v1_1)


def closure10(unit_var: None, v0_1: US6) -> Callable[[str], Async[int64]]:
    def _arrow326(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Async[int64]:
        return closure11(v0_1, v)

    return _arrow326


def method30(v0_1: str) -> Async[int64]:
    return method25(US6(0, US7(0), US8(1)), v0_1)


def closure13(unit_var: None, v0_1: str) -> Async[int64]:
    return method30(v0_1)


def method34(__unit: None=None) -> str:
    v4: str = "Verbose".lower()
    return ("\u001b[90m" + method17(v4[0])) + method19()


def method36(v0_1: int64, v1_1: str, v2_1: Exception) -> str:
    v4: Mut3 = Mut3(method18())
    v13: None
    closure6(v4, "{ ", None)
    v13 = None
    v24_1: None
    closure6(v4, "retry", None)
    v24_1 = None
    v35_1: None
    closure6(v4, " = ", None)
    v35_1 = None
    v44: None
    closure6(v4, ("" + str(v0_1)) + "", None)
    v44 = None
    v55: None
    closure6(v4, "; ", None)
    v55 = None
    v66: None
    closure6(v4, "path", None)
    v66 = None
    v75: None
    closure6(v4, " = ", None)
    v75 = None
    v84: None
    closure6(v4, v1_1, None)
    v84 = None
    v93: None
    closure6(v4, "; ", None)
    v93 = None
    v104: None
    closure6(v4, "ex", None)
    v104 = None
    v113: None
    closure6(v4, " = ", None)
    v113 = None
    v161: None
    closure6(v4, to_text(interpolate("%A%P()", [v2_1])), None)
    v161 = None
    v172: None
    closure6(v4, " }", None)
    v172 = None
    return v4.l0


def method35(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int64, v9: str, v10: Exception) -> str:
    v11: str = method36(v8, v9, v10)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "file_system.read_all_text_async") + " / ") + v11) + "")


def closure15(v0_1: str, v1_1: int64, v2_1: Exception, unit_var: None) -> None:
    if method11(US0(0)):
        v7: None
        closure0(None, None)
        v7 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v33_1: int64 | None = pattern_input[5]
        v32_1: Mut4 = pattern_input[4]
        v31_1: Mut3 = pattern_input[3]
        v30_1: Mut2 = pattern_input[2]
        v29_1: Mut1 = pattern_input[1]
        v28_1: Mut0 = pattern_input[0]
        method24(method35(v28_1, v29_1, v30_1, v31_1, v32_1, v33_1, method12(v28_1, v29_1, v30_1, v31_1, v32_1, v33_1), method34(), v1_1, v0_1, v2_1))



def method33(v0_1: str, v1_1: int64) -> Async[str]:
    def _arrow330(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> Async[str]:
        def _arrow327(__unit: None=None) -> Async[str]:
            v2453: Async[str] = await_task(None)
            return singleton.ReturnFrom(v2453)

        def _arrow329(_arg: Exception) -> Async[str]:
            v2535: None
            closure15(v0_1, v1_1, _arg, None)
            v2535 = None
            v2596: Async[None] = sleep(10)
            def _arrow328(__unit: None=None) -> Async[str]:
                v2609: Async[str]
                if v1_1 < int64(3):
                    v2609 = method32(v0_1, op_addition(v1_1, int64(1)))

                else: 
                    raise Exception(((("file_system.read_all_text_async / retry: " + str(v1_1)) + " / path: ") + v0_1) + "")

                return singleton.ReturnFrom(v2609)

            return singleton.Bind(v2596, _arrow328)

        return singleton.TryWith(singleton.Delay(_arrow327), _arrow329)

    return singleton.Delay(_arrow330)


def method32(v0_1: str, v1_1: int64) -> Async[str]:
    return method33(v0_1, v1_1)


def method31(v0_1: str) -> Async[str]:
    return method32(v0_1, int64(0))


def closure14(unit_var: None, v0_1: str) -> Async[str]:
    return method31(v0_1)


def method38(v0_1: str) -> bool:
    return None


def method39(v0_1: Vec_1[uint8]) -> Vec_1[uint8]:
    return v0_1


def method37(v0_1: str, v1_1: str) -> bool:
    return None


def closure17(v0_1: str, v1_1: str) -> bool:
    return method37(v0_1, v1_1)


def closure16(unit_var: None, v0_1: str) -> Callable[[str], bool]:
    def _arrow331(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> bool:
        return closure17(v0_1, v)

    return _arrow331


def method40(v0_1: str, v1_1: str) -> Async[None]:
    return None


def closure19(v0_1: str, v1_1: str) -> Async[None]:
    return method40(v0_1, v1_1)


def closure18(unit_var: None, v0_1: str) -> Callable[[str], Async[None]]:
    def _arrow332(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Async[None]:
        return closure19(v0_1, v)

    return _arrow332


def method44(v0_1: str, v1_1: str) -> Async[bool]:
    def _arrow334(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> Async[bool]:
        if method38(v0_1) == False:
            return singleton.Return(False)

        else: 
            v70: Async[str] = method31(v0_1)
            def _arrow333(_arg: str) -> Async[bool]:
                v72: bool = v1_1 == _arg
                return singleton.Return(v72)

            return singleton.Bind(v70, _arrow333)


    return singleton.Delay(_arrow334)


def method43(v0_1: str, v1_1: str) -> Async[bool]:
    return None


def method42(v0_1: str, v1_1: str) -> Async[None]:
    def _arrow339(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> Async[None]:
        v60: Async[bool] = method43(v0_1, v1_1)
        def _arrow338(_arg: bool) -> Async[None]:
            v62: bool = _arg == False
            def _arrow336(__unit: None=None) -> Async[None]:
                v63: Async[None] = method40(v0_1, v1_1)
                def _arrow335(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v63, _arrow335)

            def _arrow337(__unit: None=None) -> Async[None]:
                return singleton.Zero()

            return singleton.Combine(_arrow336() if v62 else singleton.Zero(), singleton.Delay(_arrow337))

        return singleton.Bind(v60, _arrow338)

    return singleton.Delay(_arrow339)


def method41(v0_1: str, v1_1: str) -> Async[None]:
    return method42(v0_1, v1_1)


def closure21(v0_1: str, v1_1: str) -> Async[None]:
    return method41(v0_1, v1_1)


def closure20(unit_var: None, v0_1: str) -> Callable[[str], Async[None]]:
    def _arrow340(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Async[None]:
        return closure21(v0_1, v)

    return _arrow340


def method49(v0_1: std_io_error) -> str:
    v2_1: Mut3 = Mut3(method18())
    v48: None
    closure6(v2_1, to_text(interpolate("%A%P()", [v0_1])), None)
    v48 = None
    return v2_1.l0


def closure23(unit_var: None, v0_1: std_io_error) -> str:
    return method49(v0_1)


def method48(__unit: None=None) -> Callable[[std_io_error], str]:
    def _arrow341(v: std_io_error) -> str:
        return closure23(None, v)

    return _arrow341


def closure24(unit_var: None, unit_var_1: None) -> US9:
    return US9(0)


def method50(__unit: None=None) -> Callable[[], US9]:
    def _arrow342(__unit: None=None) -> US9:
        return closure24(None, None)

    return _arrow342


def closure25(unit_var: None, v0_1: str) -> US9:
    return US9(1, v0_1)


def method51(__unit: None=None) -> Callable[[str], US9]:
    def _arrow343(v: str) -> US9:
        return closure25(None, v)

    return _arrow343


def method52(__unit: None=None) -> str:
    v4: str = "Critical".lower()
    return ("\u001b[91m" + method17(v4[0])) + method19()


def method54(v0_1: str) -> str:
    v2_1: Mut3 = Mut3(method18())
    v11: None
    closure6(v2_1, "{ ", None)
    v11 = None
    v22_1: None
    closure6(v2_1, "error\'", None)
    v22_1 = None
    v33_1: None
    closure6(v2_1, " = ", None)
    v33_1 = None
    v42: None
    closure6(v2_1, v0_1, None)
    v42 = None
    v53: None
    closure6(v2_1, " }", None)
    v53 = None
    return v2_1.l0


def method53(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v9: str = method54(v8)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "file_system.file_delete") + " / ") + v9) + "")


def closure26(v0_1: str, unit_var: None) -> None:
    if method11(US0(4)):
        v5: None
        closure0(None, None)
        v5 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v31_1: int64 | None = pattern_input[5]
        v30_1: Mut4 = pattern_input[4]
        v29_1: Mut3 = pattern_input[3]
        v28_1: Mut2 = pattern_input[2]
        v27_1: Mut1 = pattern_input[1]
        v26_1: Mut0 = pattern_input[0]
        method24(method53(v26_1, v27_1, v28_1, v29_1, v30_1, v31_1, method12(v26_1, v27_1, v28_1, v29_1, v30_1, v31_1), method52(), v0_1))



def method55(__unit: None=None) -> str:
    v4: str = "Warning".lower()
    return ("\u001b[93m" + method17(v4[0])) + method19()


def method57(v0_1: str, v1_1: str) -> str:
    v3: Mut3 = Mut3(method18())
    v12: None
    closure6(v3, "{ ", None)
    v12 = None
    v23_1: None
    closure6(v3, "path", None)
    v23_1 = None
    v34_1: None
    closure6(v3, " = ", None)
    v34_1 = None
    v43: None
    closure6(v3, v0_1, None)
    v43 = None
    v54: None
    closure6(v3, "; ", None)
    v54 = None
    v65: None
    closure6(v3, "ex", None)
    v65 = None
    v74: None
    closure6(v3, " = ", None)
    v74 = None
    v83: None
    closure6(v3, v1_1, None)
    v83 = None
    v94: None
    closure6(v3, " }", None)
    v94 = None
    return v3.l0


def method56(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v10: str = method57(v8, v9)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "delete_file_async") + " / ") + v10) + "")


def closure27(v0_1: str, v1_1: Exception, unit_var: None) -> None:
    if method11(US0(3)):
        v6: None
        closure0(None, None)
        v6 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v32_1: int64 | None = pattern_input[5]
        v31_1: Mut4 = pattern_input[4]
        v30_1: Mut3 = pattern_input[3]
        v29_1: Mut2 = pattern_input[2]
        v28_1: Mut1 = pattern_input[1]
        v27_1: Mut0 = pattern_input[0]
        method24(method56(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1, method12(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1), method55(), method20(v0_1), to_text(interpolate("%A%P()", [v1_1]))))



def method47(v0_1: str, v1_1: int64) -> Async[int64]:
    def _arrow349(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> Async[int64]:
        def _arrow344(__unit: None=None) -> Async[int64]:
            return singleton.Return(v1_1)

        def _arrow348(_arg: Exception) -> Async[int64]:
            v3238: bool = op_modulus(v1_1, int64(100)) == int64(0)
            def _arrow345(__unit: None=None) -> Async[None]:
                v3241: None
                closure27(v0_1, _arg, None)
                v3241 = None
                return singleton.Zero()

            def _arrow347(__unit: None=None) -> Async[int64]:
                v3339: Async[None] = sleep(10)
                def _arrow346(__unit: None=None) -> Async[int64]:
                    v3348: Async[int64] = method46(v0_1, op_addition(v1_1, int64(1)))
                    return singleton.ReturnFrom(v3348)

                return singleton.Bind(v3339, _arrow346)

            return singleton.Combine(_arrow345() if v3238 else singleton.Zero(), singleton.Delay(_arrow347))

        return singleton.TryWith(singleton.Delay(_arrow344), _arrow348)

    return singleton.Delay(_arrow349)


def method46(v0_1: str, v1_1: int64) -> Async[int64]:
    return None


def method45(v0_1: str) -> Async[int64]:
    return method46(v0_1, int64(0))


def closure22(unit_var: None, v0_1: str) -> Async[int64]:
    return method45(v0_1)


def method61(v0_1: str, v1_1: str) -> None:
    pass


def method63(v0_1: str, v1_1: str, v2_1: str) -> str:
    v4: Mut3 = Mut3(method18())
    v13: None
    closure6(v4, "{ ", None)
    v13 = None
    v24_1: None
    closure6(v4, "old_path", None)
    v24_1 = None
    v35_1: None
    closure6(v4, " = ", None)
    v35_1 = None
    v44: None
    closure6(v4, v0_1, None)
    v44 = None
    v55: None
    closure6(v4, "; ", None)
    v55 = None
    v66: None
    closure6(v4, "new_path", None)
    v66 = None
    v75: None
    closure6(v4, " = ", None)
    v75 = None
    v84: None
    closure6(v4, v1_1, None)
    v84 = None
    v93: None
    closure6(v4, "; ", None)
    v93 = None
    v104: None
    closure6(v4, "ex", None)
    v104 = None
    v113: None
    closure6(v4, " = ", None)
    v113 = None
    v122: None
    closure6(v4, v2_1, None)
    v122 = None
    v133: None
    closure6(v4, " }", None)
    v133 = None
    return v4.l0


def method62(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str, v10: str) -> str:
    v11: str = method63(v8, v9, v10)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "move_file_async") + " / ") + v11) + "")


def closure30(v0_1: str, v1_1: str, v2_1: Exception, unit_var: None) -> None:
    if method11(US0(3)):
        v7: None
        closure0(None, None)
        v7 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v33_1: int64 | None = pattern_input[5]
        v32_1: Mut4 = pattern_input[4]
        v31_1: Mut3 = pattern_input[3]
        v30_1: Mut2 = pattern_input[2]
        v29_1: Mut1 = pattern_input[1]
        v28_1: Mut0 = pattern_input[0]
        method24(method62(v28_1, v29_1, v30_1, v31_1, v32_1, v33_1, method12(v28_1, v29_1, v30_1, v31_1, v32_1, v33_1), method55(), method20(v1_1), method20(v0_1), to_text(interpolate("%A%P()", [v2_1]))))



def method60(v0_1: str, v1_1: str, v2_1: int64) -> Async[int64]:
    def _arrow355(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1) -> Async[int64]:
        def _arrow350(__unit: None=None) -> Async[int64]:
            method61(v0_1, v1_1)
            return singleton.Return(v2_1)

        def _arrow354(_arg: Exception) -> Async[int64]:
            v1855: bool = op_modulus(v2_1, int64(100)) == int64(0)
            def _arrow351(__unit: None=None) -> Async[None]:
                v1858: None
                closure30(v0_1, v1_1, _arg, None)
                v1858 = None
                return singleton.Zero()

            def _arrow353(__unit: None=None) -> Async[int64]:
                v1957: Async[None] = sleep(10)
                def _arrow352(__unit: None=None) -> Async[int64]:
                    v1966: Async[int64] = method59(v0_1, v1_1, op_addition(v2_1, int64(1)))
                    return singleton.ReturnFrom(v1966)

                return singleton.Bind(v1957, _arrow352)

            return singleton.Combine(_arrow351() if v1855 else singleton.Zero(), singleton.Delay(_arrow353))

        return singleton.TryWith(singleton.Delay(_arrow350), _arrow354)

    return singleton.Delay(_arrow355)


def method59(v0_1: str, v1_1: str, v2_1: int64) -> Async[int64]:
    return None


def method58(v0_1: str, v1_1: str) -> Async[int64]:
    return method59(v0_1, v1_1, int64(0))


def closure29(v0_1: str, v1_1: str) -> Async[int64]:
    return method58(v0_1, v1_1)


def closure28(unit_var: None, v0_1: str) -> Callable[[str], Async[int64]]:
    def _arrow356(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> Async[int64]:
        return closure29(v0_1, v)

    return _arrow356


def closure32(unit_var: None, v0_1: int64) -> US10:
    return US10(0, v0_1)


def method70(__unit: None=None) -> Callable[[int64], US10]:
    def _arrow357(v: int64) -> US10:
        return closure32(None, v)

    return _arrow357


def closure33(unit_var: None, v0_1: Exception) -> US10:
    return US10(1, v0_1)


def method71(__unit: None=None) -> Callable[[Exception], US10]:
    def _arrow358(v: Exception) -> US10:
        return closure33(None, v)

    return _arrow358


def method69(v0_1: Async[Any]) -> Async[US10]:
    def _arrow360(__unit: None=None, v0_1: Any=v0_1) -> Async[US10]:
        def _arrow359(_arg: Any) -> Async[US10]:
            return singleton.Return(None)

        return singleton.Bind(v0_1, _arrow359)

    return singleton.Delay(_arrow360)


def method72(v0_1: Async[US10]) -> Async[US11]:
    def _arrow362(__unit: None=None, v0_1: Any=v0_1) -> Async[US11]:
        def _arrow361(_arg: US10) -> Async[US11]:
            v83: US10 = _arg
            v89: US11 = US11(1, v83.fields[0]) if (v83.tag == 1) else US11(0, v83.fields[0])
            return singleton.Return(v89)

        return singleton.Bind(v0_1, _arrow361)

    return singleton.Delay(_arrow362)


def method75(v0_1: int) -> str:
    v2_1: Mut3 = Mut3(method18())
    v11: None
    closure6(v2_1, "{ ", None)
    v11 = None
    v22_1: None
    closure6(v2_1, "timeout", None)
    v22_1 = None
    v33_1: None
    closure6(v2_1, " = ", None)
    v33_1 = None
    v42: None
    closure6(v2_1, ("" + str(v0_1)) + "", None)
    v42 = None
    v53: None
    closure6(v2_1, " }", None)
    v53 = None
    return v2_1.l0


def method74(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int) -> str:
    v9: str = method75(v8)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "async.run_with_timeout_async") + " / ") + v9) + "")


def closure34(v0_1: int, unit_var: None) -> None:
    if method11(US0(0)):
        v5: None
        closure0(None, None)
        v5 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v31_1: int64 | None = pattern_input[5]
        v30_1: Mut4 = pattern_input[4]
        v29_1: Mut3 = pattern_input[3]
        v28_1: Mut2 = pattern_input[2]
        v27_1: Mut1 = pattern_input[1]
        v26_1: Mut0 = pattern_input[0]
        method24(method74(v26_1, v27_1, v28_1, v29_1, v30_1, v31_1, method12(v26_1, v27_1, v28_1, v29_1, v30_1, v31_1), method34(), v0_1))



def method77(v0_1: int, v1_1: str) -> str:
    v3: Mut3 = Mut3(method18())
    v12: None
    closure6(v3, "{ ", None)
    v12 = None
    v23_1: None
    closure6(v3, "timeout", None)
    v23_1 = None
    v34_1: None
    closure6(v3, " = ", None)
    v34_1 = None
    v43: None
    closure6(v3, ("" + str(v0_1)) + "", None)
    v43 = None
    v54: None
    closure6(v3, "; ", None)
    v54 = None
    v65: None
    closure6(v3, "ex", None)
    v65 = None
    v74: None
    closure6(v3, " = ", None)
    v74 = None
    v83: None
    closure6(v3, v1_1, None)
    v83 = None
    v94: None
    closure6(v3, " }", None)
    v94 = None
    return v3.l0


def method76(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: str) -> str:
    v10: str = method77(v8, v9)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "async.run_with_timeout_async**") + " / ") + v10) + "")


def closure35(v0_1: int, v1_1: Exception, unit_var: None) -> None:
    if method11(US0(4)):
        v6: None
        closure0(None, None)
        v6 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v32_1: int64 | None = pattern_input[5]
        v31_1: Mut4 = pattern_input[4]
        v30_1: Mut3 = pattern_input[3]
        v29_1: Mut2 = pattern_input[2]
        v28_1: Mut1 = pattern_input[1]
        v27_1: Mut0 = pattern_input[0]
        method24(method76(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1, method12(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1), method52(), v0_1, to_text(interpolate("%A%P()", [v1_1]))))



def method73(v0_1: int, v1_1: Async[US11]) -> Async[US2]:
    def _arrow364(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> Async[US2]:
        def _arrow363(_arg: US11) -> Async[US2]:
            v1252: US11 = _arg
            v1404: US2
            if v1252.tag == 0:
                v1404 = US2(0, v1252.fields[0])

            else: 
                v1255: Exception = v1252.fields[0]
                v1257: str = to_text(interpolate("%A%P()", [v1255]))
                if v1257.find("System.TimeoutException") >= 0:
                    v1268: None
                    closure34(v0_1, None)
                    v1268 = None
                    v1404 = US2(1)

                else: 
                    v1318: None
                    closure35(v0_1, v1255, None)
                    v1318 = None
                    v1404 = US2(1)


            return singleton.Return(v1404)

        return singleton.Bind(v1_1, _arrow363)

    return singleton.Delay(_arrow364)


def method68(v0_1: Async[int64], v1_1: int) -> Async[US2]:
    def _arrow366(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> Async[US2]:
        v542: Async[Async[int64]] = start_child(v0_1, v1_1)
        def _arrow365(_arg: Async[int64]) -> Async[US2]:
            v585: Async[US2] = method73(v1_1, method72(method69(catch_async(_arg))))
            return singleton.ReturnFrom(v585)

        return singleton.Bind(v542, _arrow365)

    return singleton.Delay(_arrow366)


def method67(v0_1: int, v1_1: Async[int64]) -> Async[US2]:
    return method68(v1_1, v0_1)


def method78(v0_1: Async[str]) -> Async[str | None]:
    def _arrow368(__unit: None=None, v0_1: Any=v0_1) -> Async[str | None]:
        def _arrow367(_arg: str) -> Async[str | None]:
            return singleton.Return(_arg)

        return singleton.Bind(v0_1, _arrow367)

    return singleton.Delay(_arrow368)


def method80(v0_1: int64, v1_1: str) -> str:
    v3: Mut3 = Mut3(method18())
    v12: None
    closure6(v3, "{ ", None)
    v12 = None
    v23_1: None
    closure6(v3, "retry", None)
    v23_1 = None
    v34_1: None
    closure6(v3, " = ", None)
    v34_1 = None
    v43: None
    closure6(v3, ("" + str(v0_1)) + "", None)
    v43 = None
    v54: None
    closure6(v3, "; ", None)
    v54 = None
    v65: None
    closure6(v3, "ex", None)
    v65 = None
    v74: None
    closure6(v3, " = ", None)
    v74 = None
    v83: None
    closure6(v3, v1_1, None)
    v83 = None
    v94: None
    closure6(v3, " }", None)
    v94 = None
    return v3.l0


def method79(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int64, v9: str) -> str:
    v10: str = method80(v8, v9)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "file_system.read_all_text_retry_async") + " / ") + v10) + "")


def closure36(v0_1: int64, v1_1: Exception, unit_var: None) -> None:
    if method11(US0(1)):
        v6: None
        closure0(None, None)
        v6 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v32_1: int64 | None = pattern_input[5]
        v31_1: Mut4 = pattern_input[4]
        v30_1: Mut3 = pattern_input[3]
        v29_1: Mut2 = pattern_input[2]
        v28_1: Mut1 = pattern_input[1]
        v27_1: Mut0 = pattern_input[0]
        method24(method79(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1, method12(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1), method16(), v0_1, to_text(interpolate("%A%P()", [v1_1]))))



def method66(v0_1: str, v1_1: int64) -> Async[str | None]:
    def _arrow374(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> Async[str | None]:
        def _arrow372(__unit: None=None) -> Async[str | None]:
            v2156: bool = v1_1 > int64(0)
            def _arrow370(__unit: None=None) -> Async[None]:
                v2180: Async[None] = ignore(method67(1000, method30(v0_1)))
                def _arrow369(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v2180, _arrow369)

            def _arrow371(__unit: None=None) -> Async[str | None]:
                v2192: Async[str | None] = method78(method31(v0_1))
                return singleton.ReturnFrom(v2192)

            return singleton.Combine(_arrow370() if v2156 else singleton.Zero(), singleton.Delay(_arrow371))

        def _arrow373(_arg_1: Exception) -> Async[str | None]:
            if (v1_1 == int64(0)) != True:
                v2235: None
                closure36(v1_1, _arg_1, None)
                v2235 = None
                return singleton.Return(None)

            else: 
                v2323: Async[str | None] = method65(v0_1, op_addition(v1_1, int64(1)))
                return singleton.ReturnFrom(v2323)


        return singleton.TryWith(singleton.Delay(_arrow372), _arrow373)

    return singleton.Delay(_arrow374)


def method65(v0_1: str, v1_1: int64) -> Async[str | None]:
    return method66(v0_1, v1_1)


def method64(v0_1: str) -> Async[str | None]:
    return method65(v0_1, int64(0))


def closure31(unit_var: None, v0_1: str) -> Async[str | None]:
    return method64(v0_1)


def closure38(unit_var: None, v0_1: chrono_date_time_1[chrono_utc]) -> US12:
    return US12(0, v0_1)


def method83(__unit: None=None) -> Callable[[chrono_date_time_1[chrono_utc]], US12]:
    def _arrow375(v: chrono_date_time_1[chrono_utc]) -> US12:
        return closure38(None, v)

    return _arrow375


def method84(__unit: None=None) -> str:
    return "hh:mm"


def method85(__unit: None=None) -> str:
    return "yyyyMMdd-HHmm-ssff-ffff-f"


def method86(__unit: None=None) -> str:
    return "hhmm"


def method82(v0_1: str, v1_1: Any) -> str:
    v2553: str = method85()
    v2559: str = to_string(v1_1, "M-d-y hh:mm:ss tt" if (v2553 == "") else v2553)
    v2794: Any
    raise Exception(("date_time.get_utc_offset / target: " + str(US4(5, US3(0)))) + "")
    v2809: uint8 = uint8(1) if (hours(v2794) > 0) else uint8(0)
    v2810: str = method86()
    v3034: str = ((("" + str(v2809)) + "") + to_string_1(v2794, "c", {})) + ""
    v3037: str = str(v0_1)
    v3042: int = (len(v2559) + len(v3034)) or 0
    v3074: int = (len(v3037) - 1) or 0
    return parse(concat(v2559, v3034, *v3037[v3042:v3074 + 1]))


def method88(__unit: None=None) -> str:
    raise Exception(("file_system.get_temp_path / target: " + str(US4(5, US3(0)))) + "")


def method89(__unit: None=None) -> str:
    return "!create_temp_path_"


def method90(v0_1: str, v1_1: str) -> str:
    raise Exception(((((("file_system.(</>) / target: " + str(US4(5, US3(0)))) + " / a: ") + v0_1) + " / b: ") + v1_1) + "")


def method92(__unit: None=None) -> str:
    return "CARGO_PKG_NAME"


def method91(__unit: None=None) -> str:
    raise Exception(("env.get_entry_assembly_name / target: " + str(US4(5, US3(0)))) + "")


def method87(v0_1: str) -> str:
    return method90(method90(method90(method88(), method89()), method91()), str(v0_1))


def method81(__unit: None=None) -> str:
    v115: Any = now()
    return method87(method82(new_guid(), v115))


def closure37(unit_var: None, unit_var_1: None) -> str:
    return method81()


def closure40(unit_var: None, v0_1: std_io_error) -> std_string_string:
    return None


def method94(__unit: None=None) -> Callable[[std_io_error], std_string_string]:
    def _arrow376(v: std_io_error) -> std_string_string:
        return closure40(None, v)

    return _arrow376


def closure41(unit_var: None, unit_var_1: None) -> US13:
    return US13(0)


def method95(__unit: None=None) -> Callable[[], US13]:
    def _arrow377(__unit: None=None) -> US13:
        return closure41(None, None)

    return _arrow377


def closure42(unit_var: None, v0_1: std_string_string) -> US13:
    return US13(1, v0_1)


def method96(__unit: None=None) -> Callable[[std_string_string], US13]:
    def _arrow378(v: std_string_string) -> US13:
        return closure42(None, v)

    return _arrow378


def method98(v0_1: str, v1_1: std_string_string) -> str:
    v3: Mut3 = Mut3(method18())
    v12: None
    closure6(v3, "{ ", None)
    v12 = None
    v23_1: None
    closure6(v3, "dir", None)
    v23_1 = None
    v34_1: None
    closure6(v3, " = ", None)
    v34_1 = None
    v43: None
    closure6(v3, v0_1, None)
    v43 = None
    v54: None
    closure6(v3, "; ", None)
    v54 = None
    v65: None
    closure6(v3, "error", None)
    v65 = None
    v74: None
    closure6(v3, " = ", None)
    v74 = None
    v122: None
    closure6(v3, to_text(interpolate("%A%P()", [v1_1])), None)
    v122 = None
    v133: None
    closure6(v3, " }", None)
    v133 = None
    return v3.l0


def method97(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: std_string_string) -> str:
    v10: str = method98(v8, v9)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "file_system.create_dir") + " / ") + v10) + "")


def closure43(v0_1: str, v1_1: std_string_string, unit_var: None) -> None:
    if method11(US0(4)):
        v6: None
        closure0(None, None)
        v6 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v32_1: int64 | None = pattern_input[5]
        v31_1: Mut4 = pattern_input[4]
        v30_1: Mut3 = pattern_input[3]
        v29_1: Mut2 = pattern_input[2]
        v28_1: Mut1 = pattern_input[1]
        v27_1: Mut0 = pattern_input[0]
        method24(method97(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1, method12(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1), method52(), v0_1, v1_1))



def method100(v0_1: str) -> str:
    v2_1: Mut3 = Mut3(method18())
    v11: None
    closure6(v2_1, "{ ", None)
    v11 = None
    v22_1: None
    closure6(v2_1, "dir", None)
    v22_1 = None
    v33_1: None
    closure6(v2_1, " = ", None)
    v33_1 = None
    v42: None
    closure6(v2_1, v0_1, None)
    v42 = None
    v53: None
    closure6(v2_1, " }", None)
    v53 = None
    return v2_1.l0


def method99(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v9: str = method100(v8)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "file_system.create_dir") + " / ") + v9) + "")


def closure44(v0_1: str, unit_var: None) -> None:
    if method11(US0(0)):
        v5: None
        closure0(None, None)
        v5 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v31_1: int64 | None = pattern_input[5]
        v30_1: Mut4 = pattern_input[4]
        v29_1: Mut3 = pattern_input[3]
        v28_1: Mut2 = pattern_input[2]
        v27_1: Mut1 = pattern_input[1]
        v26_1: Mut0 = pattern_input[0]
        method24(method99(v26_1, v27_1, v28_1, v29_1, v30_1, v31_1, method12(v26_1, v27_1, v28_1, v29_1, v30_1, v31_1), method34(), v0_1))



def closure45(v0_1: str, unit_var: None) -> None:
    method9(True, v0_1)


def method101(v0_1: str) -> Callable[[], None]:
    def _arrow379(__unit: None=None, v0_1: Any=v0_1) -> None:
        closure45(v0_1, None)

    return _arrow379


def method102(v0_1: str) -> Callable[[], None]:
    def _arrow380(__unit: None=None, v0_1: Any=v0_1) -> None:
        closure45(v0_1, None)

    return _arrow380


def method103(v0_1: str) -> bool:
    return None


def method105(v0_1: str, v1_1: str) -> str:
    v3: Mut3 = Mut3(method18())
    v12: None
    closure6(v3, "{ ", None)
    v12 = None
    v23_1: None
    closure6(v3, "dir", None)
    v23_1 = None
    v34_1: None
    closure6(v3, " = ", None)
    v34_1 = None
    v43: None
    closure6(v3, v0_1, None)
    v43 = None
    v54: None
    closure6(v3, "; ", None)
    v54 = None
    v65: None
    closure6(v3, "result", None)
    v65 = None
    v74: None
    closure6(v3, " = ", None)
    v74 = None
    v83: None
    closure6(v3, v1_1, None)
    v83 = None
    v94: None
    closure6(v3, " }", None)
    v94 = None
    return v3.l0


def method104(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v10: str = method105(v8, v9)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "file_system.create_dir") + " / ") + v10) + "")


def closure46(v0_1: str, v1_1: str, unit_var: None) -> None:
    if method11(US0(1)):
        v6: None
        closure0(None, None)
        v6 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v32_1: int64 | None = pattern_input[5]
        v31_1: Mut4 = pattern_input[4]
        v30_1: Mut3 = pattern_input[3]
        v29_1: Mut2 = pattern_input[2]
        v28_1: Mut1 = pattern_input[1]
        v27_1: Mut0 = pattern_input[0]
        method24(method104(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1, method12(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1), method16(), v0_1, v1_1))



def closure47(v0_1: str, unit_var: None) -> None:
    run_synchronously(ignore(method6(v0_1)))


def method106(v0_1: str) -> Callable[[], None]:
    def _arrow381(__unit: None=None, v0_1: Any=v0_1) -> None:
        closure47(v0_1, None)

    return _arrow381


def method107(v0_1: str) -> Callable[[], None]:
    def _arrow382(__unit: None=None, v0_1: Any=v0_1) -> None:
        closure47(v0_1, None)

    return _arrow382


def method93(v0_1: str) -> IDisposable:
    v462: bool = method103(v0_1)
    v494: bool = None
    if v494 == False:
        v545: None
        closure46(v0_1, to_text(interpolate("%A%P()", [{
            "CreationTime": None,
            "Exists": v494
        }])), None)
        v545 = None

    v605: Callable[[], None] = method107(v0_1)
    class ObjectExpr383(IDisposable):
        def Dispose(self, __unit: None=None, v0_1: Any=v0_1) -> None:
            v605(None)

    return ObjectExpr383()


def closure39(unit_var: None, unit_var_1: None) -> tuple[str, IDisposable]:
    v0_1: str = method81()
    return (v0_1, method93(v0_1))


def closure49(v0_1: int, v1_1: str, v2_1: int, v3: str) -> str:
    if v2_1 >= v0_1:
        return v3

    else: 
        return method109(v0_1, v1_1, v2_1 + 1)(v3 + v1_1)



def method109(v0_1: int, v1_1: str, v2_1: int) -> Callable[[str], str]:
    def _arrow384(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1) -> str:
        return closure49(v0_1, v1_1, v2_1, v)

    return _arrow384


def method108(v0_1: str) -> str:
    v12: str = method109(32 - len(v0_1), "0", 0)("") + v0_1
    v844: int = (8 - 1) or 0
    v876: int = (12 - 1) or 0
    v908: int = (16 - 1) or 0
    v940: int = (20 - 1) or 0
    v972: int = (32 - 1) or 0
    return parse(((((((((("" + v12[0:v844 + 1]) + "-") + v12[8:v876 + 1]) + "-") + v12[12:v908 + 1]) + "-") + v12[16:v940 + 1]) + "-") + v12[20:v972 + 1]) + "")


def closure48(unit_var: None, v0_1: str) -> tuple[str, IDisposable]:
    v2_1: str = method87(method108(v0_1))
    return (v2_1, method93(v2_1))


def closure50(unit_var: None, unit_var_1: None) -> str:
    return "c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral"


def closure52(unit_var: None, v0_1: std_path_path_buf) -> US14:
    return US14(0, v0_1)


def method113(__unit: None=None) -> Callable[[std_path_path_buf], US14]:
    def _arrow385(v: std_path_path_buf) -> US14:
        return closure52(None, v)

    return _arrow385


def closure53(unit_var: None, v0_1: str) -> US14:
    return US14(1, v0_1)


def method114(__unit: None=None) -> Callable[[str], US14]:
    def _arrow386(v: str) -> US14:
        return closure53(None, v)

    return _arrow386


def method117(v0_1: str) -> str | None:
    return None


def method118(v0_1: str) -> str:
    v2_1: Mut3 = Mut3(method18())
    v9: None
    closure6(v2_1, v0_1, None)
    v9 = None
    return v2_1.l0


def method116(v0_1: str, v1_1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2_1: uint8, v3: str, v4: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v5: str = method20(v4)
    v6: str | None = method117(v4)
    v31_1: US5 = default_arg(map(method5(), v6), US5(1))
    v35_1: str = method118(v3)
    if v2_1 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0_1) + " / n: ") + str(v2_1)) + " / path\': ") + v4) + " / name: ") + v5) + ""))

    elif v31_1.tag == 0:
        if v4 != "":
            v97: FSharpResult_2[std_path_path_buf, std_io_error] = v1_1(v2_1 + uint8(1), v31_1.fields[0])
            v98: Callable[[std_io_error], str] = method48()
            v111: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v98(v97.fields[0])) if (v97.tag == 1) else FSharpResult_2(0, v97.fields[0])
            v114: Callable[[std_path_path_buf], US14] = method113()
            v115: Callable[[str], US14] = method114()
            v117: US14 = v115(v111.fields[0]) if (v111.tag == 1) else v114(v111.fields[0])
            if v117.tag == 0:
                return FSharpResult_2(0, method90(to_string_2(v117.fields[0]), v5))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v117.fields[0]) + " / error: ") + v35_1) + " / name: ") + v5) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / error: ") + v35_1) + " / path\': ") + v4) + " / name: ") + v5) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / error: ") + v35_1) + " / path\': ") + v4) + " / name: ") + v5) + ""))



def method115(v0_1: str, v1_1: uint8, v2_1: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return None


def closure55(v0_1: str, v1_1: uint8, v2_1: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return method115(v0_1, v1_1, v2_1)


def closure54(v0_1: str, v1_1: uint8) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
    def _arrow387(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> FSharpResult_2[std_path_path_buf, std_io_error]:
        return closure55(v0_1, v1_1, v)

    return _arrow387


def method119(v0_1: str, v1_1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2_1: uint8, v3: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v4: str = method20(v0_1)
    v5: str | None = method117(v0_1)
    v30_1: US5 = default_arg(map(method5(), v5), US5(1))
    v34_1: str = method118(v3)
    if v2_1 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0_1) + " / n: ") + str(v2_1)) + " / path\': ") + v0_1) + " / name: ") + v4) + ""))

    elif v30_1.tag == 0:
        if v0_1 != "":
            v96: FSharpResult_2[std_path_path_buf, std_io_error] = v1_1(v2_1 + uint8(1), v30_1.fields[0])
            v97: Callable[[std_io_error], str] = method48()
            v110: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v97(v96.fields[0])) if (v96.tag == 1) else FSharpResult_2(0, v96.fields[0])
            v113: Callable[[std_path_path_buf], US14] = method113()
            v114: Callable[[str], US14] = method114()
            v116: US14 = v114(v110.fields[0]) if (v110.tag == 1) else v113(v110.fields[0])
            if v116.tag == 0:
                return FSharpResult_2(0, method90(to_string_2(v116.fields[0]), v4))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v116.fields[0]) + " / error: ") + v34_1) + " / name: ") + v4) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / error: ") + v34_1) + " / path\': ") + v0_1) + " / name: ") + v4) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / error: ") + v34_1) + " / path\': ") + v0_1) + " / name: ") + v4) + ""))



def method112(v0_1: str, v1_1: uint8) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return None


def method121(v0_1: bool) -> enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]):
    return None


def method122(__unit: None=None) -> enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]):
    return None


def method123(v0_1: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]), v1_1: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)])) -> bool:
    return None


def method125(v0_1: str, v1_1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2_1: uint8, v3: std_io_error, v4: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v5: str = method20(v4)
    v6: str | None = method117(v4)
    v31_1: US5 = default_arg(map(method5(), v6), US5(1))
    v35_1: str = method49(v3)
    if v2_1 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0_1) + " / n: ") + str(v2_1)) + " / path\': ") + v4) + " / name: ") + v5) + ""))

    elif v31_1.tag == 0:
        if v4 != "":
            v97: FSharpResult_2[std_path_path_buf, std_io_error] = v1_1(v2_1 + uint8(1), v31_1.fields[0])
            v98: Callable[[std_io_error], str] = method48()
            v111: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v98(v97.fields[0])) if (v97.tag == 1) else FSharpResult_2(0, v97.fields[0])
            v114: Callable[[std_path_path_buf], US14] = method113()
            v115: Callable[[str], US14] = method114()
            v117: US14 = v115(v111.fields[0]) if (v111.tag == 1) else v114(v111.fields[0])
            if v117.tag == 0:
                return FSharpResult_2(0, method90(to_string_2(v117.fields[0]), v5))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v117.fields[0]) + " / error: ") + v35_1) + " / name: ") + v5) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / error: ") + v35_1) + " / path\': ") + v4) + " / name: ") + v5) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / error: ") + v35_1) + " / path\': ") + v4) + " / name: ") + v5) + ""))



def method124(v0_1: str, v1_1: uint8, v2_1: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v42: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]) = method121(None) or 0
    v44: bool = method123(method122(), v42)
    if v44:
        return FSharpResult_2(0, None)

    else: 
        def v178(v: uint8, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
            return closure56(v0_1, v)

        return method125(v0_1, uncurry2(v178), v1_1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / result: ") + str(v44)) + " / path\': ") + v2_1) + " / n: ") + str(v1_1)) + ""), v2_1)



def closure57(v0_1: str, v1_1: uint8, v2_1: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return method124(v0_1, v1_1, v2_1)


def closure56(v0_1: str, v1_1: uint8) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
    def _arrow388(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1) -> FSharpResult_2[std_path_path_buf, std_io_error]:
        return closure57(v0_1, v1_1, v)

    return _arrow388


def method126(v0_1: str, v1_1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2_1: uint8, v3: std_io_error) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v4: str = method20(v0_1)
    v5: str | None = method117(v0_1)
    v30_1: US5 = default_arg(map(method5(), v5), US5(1))
    v34_1: str = method49(v3)
    if v2_1 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0_1) + " / n: ") + str(v2_1)) + " / path\': ") + v0_1) + " / name: ") + v4) + ""))

    elif v30_1.tag == 0:
        if v0_1 != "":
            v96: FSharpResult_2[std_path_path_buf, std_io_error] = v1_1(v2_1 + uint8(1), v30_1.fields[0])
            v97: Callable[[std_io_error], str] = method48()
            v110: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v97(v96.fields[0])) if (v96.tag == 1) else FSharpResult_2(0, v96.fields[0])
            v113: Callable[[std_path_path_buf], US14] = method113()
            v114: Callable[[str], US14] = method114()
            v116: US14 = v114(v110.fields[0]) if (v110.tag == 1) else v113(v110.fields[0])
            if v116.tag == 0:
                return FSharpResult_2(0, method90(to_string_2(v116.fields[0]), v4))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v116.fields[0]) + " / error: ") + v34_1) + " / name: ") + v4) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / error: ") + v34_1) + " / path\': ") + v0_1) + " / name: ") + v4) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / error: ") + v34_1) + " / path\': ") + v0_1) + " / name: ") + v4) + ""))



def method120(v0_1: str, v1_1: uint8) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v41: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]) = method121(None) or 0
    v43: bool = method123(method122(), v41)
    if v43:
        return FSharpResult_2(0, None)

    else: 
        def v177(v: uint8, v0_1: Any=v0_1, v1_1: Any=v1_1) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
            return closure56(v0_1, v)

        return method126(v0_1, uncurry2(v177), v1_1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (((((((("path: " + v0_1) + " / result: ") + str(v43)) + " / path\': ") + v0_1) + " / n: ") + str(v1_1)) + ""))



def method111(v0_1: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return FSharpResult_2()


def closure58(unit_var: None, v0_1: std_path_path_buf) -> US15:
    return US15(0, v0_1)


def method127(__unit: None=None) -> Callable[[std_path_path_buf], US15]:
    def _arrow389(v: std_path_path_buf) -> US15:
        return closure58(None, v)

    return _arrow389


def method129(v0_1: str) -> str:
    return v0_1


def method130(__unit: None=None) -> str:
    return ""


def method128(v0_1: str, v1_1: str, v2_1: str) -> str:
    return method130()


def method110(v0_1: str) -> str:
    if v0_1 == "":
        return ""

    else: 
        v3: FSharpResult_2[std_path_path_buf, std_io_error] = method111(v0_1)
        v13: std_path_path_buf | None = None if (v3.tag == 1) else v3.fields[0]
        v43: US15 = default_arg(map(method127(), v13), US15(1))
        v86: str = to_string_2(v43.fields[0]) if (v43.tag == 0) else v0_1
        v91: str = method128("^\\\\\\\\\\?\\\\", "", v0_1 if (v86 == "") else v86)
        if len(v91) < 2:
            return v0_1

        else: 
            def _arrow390(__unit: None=None, v0_1: Any=v0_1) -> str:
                _arg: str = v91[0]
                return _arg.lower()

            return replace(concat(_arrow390(), *v91[1:len(v91)]), "\\", "/")




def closure51(unit_var: None, v0_1: str) -> str:
    return method110(v0_1)


def method132(__unit: None=None) -> str:
    return None


def method133(v0_1: int, v1_1: Mut5) -> bool:
    return v1_1.l0 < v0_1


def method134(v0_1: int, v1_1: Mut6) -> bool:
    return v1_1.l0 < v0_1


def method135(__unit: None=None) -> str:
    return "/"


def method136(v0_1: str) -> str:
    return v0_1


def method131(v0_1: str) -> str:
    return None


def closure59(unit_var: None, v0_1: str) -> str:
    return method131(v0_1)


def method137(v0_1: str) -> str:
    return method110(method131(v0_1))


def closure60(unit_var: None, v0_1: str) -> str:
    return method137(v0_1)


def closure61(unit_var: None, v0_1: str) -> str:
    return concat("file:///", *trim_start(v0_1, *to_array(singleton_1("/"))))


def closure63(unit_var: None, v0_1: str) -> bool:
    return method38(v0_1)


def closure64(unit_var: None, v0_1: str) -> bool:
    return method10(v0_1)


def method141(v0_1_mut: str, v1_1_mut: str, v2_1_mut: bool, v3_mut: Callable[[str], bool], v4_mut: str) -> US17:
    while True:
        (v0_1, v1_1, v2_1, v3, v4) = (v0_1_mut, v1_1_mut, v2_1_mut, v3_mut, v4_mut)
        if v3(method90(v4, v0_1)):
            return US17(0, v4)

        else: 
            v8: str | None = method117(v4)
            v33_1: US5 = default_arg(map(method5(), v8), US5(1))
            if v33_1.tag == 0:
                v0_1_mut = v0_1
                v1_1_mut = v1_1
                v2_1_mut = v2_1
                v3_mut = v3
                v4_mut = v33_1.fields[0]
                continue

            else: 
                return US17(1, concat("file_system.find_parent / No parent for ", *"file" if v2_1 else "dir") + ((((((" \'" + v0_1) + "\' at \'") + v1_1) + "\' (until \'") + v4) + "\')"))


        break


def method140(v0_1: str, v1_1: str, v2_1: bool, v3: Callable[[str], bool]) -> US17:
    if v3(method90(v1_1, v0_1)):
        return US17(0, v1_1)

    else: 
        v7: str | None = method117(v1_1)
        v32_1: US5 = default_arg(map(method5(), v7), US5(1))
        if v32_1.tag == 0:
            return method141(v0_1, v1_1, v2_1, v3, v32_1.fields[0])

        else: 
            return US17(1, concat("file_system.find_parent / No parent for ", *"file" if v2_1 else "dir") + ((((((" \'" + v0_1) + "\' at \'") + v1_1) + "\' (until \'") + v1_1) + "\')"))




def method139(v0_1: US16, v1_1: str, v2_1: str) -> US17:
    v3: bool = True if (v0_1.tag == 0) else False
    def _arrow391(v: str, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1) -> bool:
        return closure63(None, v)

    def _arrow392(v_1: str, v0_1: Any=v0_1, v1_1: Any=v1_1, v2_1: Any=v2_1) -> bool:
        return closure64(None, v_1)

    return method140(v1_1, v2_1, v3, _arrow391 if v3 else _arrow392)


def method143(v0_1: str, v1_1: str) -> str:
    v3: Mut3 = Mut3(method18())
    v12: None
    closure6(v3, "{ ", None)
    v12 = None
    v23_1: None
    closure6(v3, "dir", None)
    v23_1 = None
    v34_1: None
    closure6(v3, " = ", None)
    v34_1 = None
    v43: None
    closure6(v3, v0_1, None)
    v43 = None
    v54: None
    closure6(v3, "; ", None)
    v54 = None
    v65: None
    closure6(v3, "error", None)
    v65 = None
    v74: None
    closure6(v3, " = ", None)
    v74 = None
    v83: None
    closure6(v3, v1_1, None)
    v83 = None
    v94: None
    closure6(v3, " }", None)
    v94 = None
    return v3.l0


def method142(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v10: str = method143(v8, v9)
    return method23(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "file_system.get_workspace_root") + " / ") + v10) + "")


def closure65(v0_1: str, v1_1: str, unit_var: None) -> None:
    if method11(US0(3)):
        v6: None
        closure0(None, None)
        v6 = None
        pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v32_1: int64 | None = pattern_input[5]
        v31_1: Mut4 = pattern_input[4]
        v30_1: Mut3 = pattern_input[3]
        v29_1: Mut2 = pattern_input[2]
        v28_1: Mut1 = pattern_input[1]
        v27_1: Mut0 = pattern_input[0]
        method24(method142(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1, method12(v27_1, v28_1, v29_1, v30_1, v31_1, v32_1), method55(), v0_1, v1_1))



def method138(v0_1: str) -> US5:
    v5: US17 = method139(US16(1), method90("spiral", "workspace"), v0_1)
    if v5.tag == 0:
        return US5(0, method110(v5.fields[0]))

    else: 
        v12: None
        closure65(v0_1, v5.fields[0], None)
        v12 = None
        return US5(1)



def closure62(unit_var: None, unit_var_1: None) -> str:
    v1_1: US5 = method138(method132())
    v7: US5 = US5(0, v1_1.fields[0]) if (v1_1.tag == 0) else method138("c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral")
    v13: US5 = US5(0, v7.fields[0]) if (v7.tag == 0) else method138("/workspaces")
    v17_1: str
    if v13.tag == 0:
        v17_1 = v13.fields[0]

    else: 
        raise Exception("Option does not have a value.")

    def _arrow393(__unit: None=None, unit_var: Any=unit_var, unit_var_1: Any=unit_var_1) -> str:
        v25_1: US5 = method138(value_10(method117(v17_1)))
        if v25_1.tag == 0:
            return v25_1.fields[0]

        else: 
            raise Exception("Option does not have a value.")


    return method90(_arrow393() if ("deps" == method20(v17_1)) else v17_1, "polyglot")


def closure67(v0_1: Exception, unit_var: None) -> Exception:
    return v0_1


def method144(v0_1: str) -> None:
    pass


def closure66(unit_var: None, v0_1: str) -> None:
    method144(v0_1)


def closure68(unit_var: None, v0_1: bool) -> None:
    v3: None
    closure0(None, None)
    v3 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    def _arrow394(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> None:
        closure66(None, v)

    def _arrow395(v_1: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> None:
        closure2(None, v_1)

    v44: Callable[[str], None] = _arrow394 if v0_1 else _arrow395
    pattern_input[1].l0 = v44


def method145(v0_1: str, v1_1: str) -> None:
    if method10(v0_1) == False:
        v4: IDisposable = method93(v0_1)

    v9: str = default_arg(method117(v1_1), "")
    if method10(v9) == False:
        v14: IDisposable = method93(v9)

    def _arrow396(__unit: None=None, v0_1: Any=v0_1, v1_1: Any=v1_1) -> bool:
        v16: FSharpResult_2[std_path_path_buf, std_io_error] = method111(v1_1)
        return True

    if _arrow396() if method10(v1_1) else False:
        method9(True, v1_1)

    if method10(v1_1) == False:
        pass



def closure70(v0_1: str, v1_1: str) -> None:
    method145(v0_1, v1_1)


def closure69(unit_var: None, v0_1: str) -> Callable[[str], None]:
    def _arrow397(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> None:
        closure70(v0_1, v)

    return _arrow397


def closure72(v0_1: str, v1_1: str) -> str:
    return method90(v0_1, v1_1)


def closure71(unit_var: None, v0_1: str) -> Callable[[str], str]:
    def _arrow398(v: str, unit_var: Any=unit_var, v0_1: Any=v0_1) -> str:
        return closure72(v0_1, v)

    return _arrow398


v0: None = None

def _arrow399(__unit: None=None) -> None:
    closure0(None, None)


v1: Callable[[], None] = _arrow399

def _expr400():
    v1(None)
    return v0


v2: None = _expr400()

def _arrow401(v: str) -> Async[int64]:
    return closure3(None, v)


v17: Callable[[str], Async[int64]] = _arrow401

def delete_directory_async(x: str) -> Async[int64]:
    return v17(x)


def _arrow402(v: US6) -> Callable[[str], Async[int64]]:
    return closure10(None, v)


v18: Callable[[US6, str], Async[int64]] = _arrow402

def wait_for_file_access(x: US6) -> Callable[[str], Async[int64]]:
    return v18(x)


def _arrow403(v: str) -> Async[int64]:
    return closure13(None, v)


v19: Callable[[str], Async[int64]] = _arrow403

def wait_for_file_access_read(x: str) -> Async[int64]:
    return v19(x)


def _arrow404(v: str) -> Async[str]:
    return closure14(None, v)


v20: Callable[[str], Async[str]] = _arrow404

def read_all_text_async(x: str) -> Async[str]:
    return v20(x)


def _arrow405(v: str) -> Callable[[str], bool]:
    return closure16(None, v)


v21: Callable[[str, str], bool] = _arrow405

def file_exists_content(x: str) -> Callable[[str], bool]:
    return v21(x)


def _arrow406(v: str) -> Callable[[str], Async[None]]:
    return closure18(None, v)


v22: Callable[[str, str], Async[None]] = _arrow406

def write_all_text_async(x: str) -> Callable[[str], Async[None]]:
    return v22(x)


def _arrow407(v: str) -> Callable[[str], Async[None]]:
    return closure20(None, v)


v23: Callable[[str, str], Async[None]] = _arrow407

def write_all_text_exists(x: str) -> Callable[[str], Async[None]]:
    return v23(x)


def _arrow408(v: str) -> Async[int64]:
    return closure22(None, v)


v24: Callable[[str], Async[int64]] = _arrow408

def delete_file_async(x: str) -> Async[int64]:
    return v24(x)


def _arrow409(v: str) -> Callable[[str], Async[int64]]:
    return closure28(None, v)


v25: Callable[[str, str], Async[int64]] = _arrow409

def move_file_async(x: str) -> Callable[[str], Async[int64]]:
    return v25(x)


def _arrow410(v: str) -> Async[str | None]:
    return closure31(None, v)


v26: Callable[[str], Async[str | None]] = _arrow410

def read_all_text_retry_async(x: str) -> Async[str | None]:
    return v26(x)


def _arrow411(__unit: None=None) -> str:
    return closure37(None, None)


v27: Callable[[], str] = _arrow411

def create_temp_path(__unit: None=None) -> str:
    return v27(None)


def _arrow412(__unit: None=None) -> tuple[str, IDisposable]:
    return closure39(None, None)


v28: Callable[[], tuple[str, IDisposable]] = _arrow412

def create_temp_dir(__unit: None=None) -> tuple[str, IDisposable]:
    return v28(None)


def _arrow413(v: str) -> tuple[str, IDisposable]:
    return closure48(None, v)


v29: Callable[[str], tuple[str, IDisposable]] = _arrow413

def create_temp_dir_0027(x: str) -> tuple[str, IDisposable]:
    return v29(x)


def _arrow414(__unit: None=None) -> str:
    return closure50(None, None)


v30: Callable[[], str] = _arrow414

def get_source_directory(__unit: None=None) -> str:
    return v30(None)


def _arrow415(v: str) -> str:
    return closure51(None, v)


v31: Callable[[str], str] = _arrow415

def normalize_path(x: str) -> str:
    return v31(x)


def _arrow416(v: str) -> str:
    return closure59(None, v)


v32: Callable[[str], str] = _arrow416

def get_full_path(x: str) -> str:
    return v32(x)


def _arrow417(v: str) -> str:
    return closure60(None, v)


v33: Callable[[str], str] = _arrow417

def standardize_path(x: str) -> str:
    return v33(x)


def _arrow418(v: str) -> str:
    return closure61(None, v)


v34: Callable[[str], str] = _arrow418

def new_file_uri(x: str) -> str:
    return v34(x)


def _arrow419(__unit: None=None) -> str:
    return closure62(None, None)


v35: Callable[[], str] = _arrow419

def get_workspace_root(__unit: None=None) -> str:
    return v35(None)


def _arrow420(v: str) -> None:
    closure66(None, v)


v36: Callable[[str], None] = _arrow420

def trace_file(x: str) -> None:
    v36(x)


def _arrow421(v: bool) -> None:
    closure68(None, v)


v37: Callable[[bool], None] = _arrow421

def init_trace_file(x: bool) -> None:
    v37(x)


def _arrow422(v: str) -> Callable[[str], None]:
    return closure69(None, v)


v38: Callable[[str, str], None] = _arrow422

def link_directory(x: str) -> Callable[[str], None]:
    return v38(x)


def _arrow423(v: str) -> Callable[[str], str]:
    return closure71(None, v)


v39: Callable[[str, str], str] = _arrow423

def op_less_divide_greater(x: str) -> Callable[[str], str]:
    return v39(x)


