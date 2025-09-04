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
from fable_modules.fable_library.reflection import (TypeInfo, class_type, union_type, int64_type, record_type, string_type, unit_type, lambda_type, bool_type, option_type, int32_type, array_type, enum_type)
from fable_modules.fable_library.result import FSharpResult_2
from fable_modules.fable_library.string_ import (trim_end, trim_start, to_text, interpolate, concat, replace)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds, to_string as to_string_1)
from fable_modules.fable_library.types import (int64, Array, Union, Record, uint8, to_string as to_string_2)
from fable_modules.fable_library.util import (create_atom, IDisposable, int64_to_string, to_enumerable, compare, uncurry2)
from collections.abc import Callable
from dataclasses import dataclass
import os
from typing import (Any, Protocol)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


TraceState_trace_state: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] | None = create_atom(None)

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


def _expr323() -> TypeInfo:
    return class_type("File_system.Disposable", None, Disposable)


class Disposable(IDisposable):
    def __init__(self, f: Callable[[], None]) -> None:
        self.f: Callable[[], None] = f

    def Dispose(self, __unit: None=None) -> None:
        _: Disposable = self
        _.f(None)


Disposable_reflection = _expr323

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


def _expr324() -> TypeInfo:
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


US0_reflection = _expr324

def _expr325() -> TypeInfo:
    return record_type("File_system.Mut0", [], Mut0, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int64

Mut0_reflection = _expr325

def _expr326() -> TypeInfo:
    return record_type("File_system.Mut1", [], Mut1, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: Callable[[str], None]

Mut1_reflection = _expr326

def _expr327() -> TypeInfo:
    return record_type("File_system.Mut2", [], Mut2, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: bool

Mut2_reflection = _expr327

def _expr328() -> TypeInfo:
    return record_type("File_system.Mut3", [], Mut3, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: str

Mut3_reflection = _expr328

def _expr329() -> TypeInfo:
    return record_type("File_system.Mut4", [], Mut4, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: US0

Mut4_reflection = _expr329

def _expr330() -> TypeInfo:
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


US1_reflection = _expr330

def _expr331() -> TypeInfo:
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


US2_reflection = _expr331

def _expr332() -> TypeInfo:
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


US3_reflection = _expr332

def _expr333() -> TypeInfo:
    return union_type("File_system.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())], [("f6_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5", "US4_6"]


US4_reflection = _expr333

def _expr334() -> TypeInfo:
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


US5_reflection = _expr334

def _expr335() -> TypeInfo:
    return union_type("File_system.US6", [], US6, lambda: [[("f0_0", Mut0_reflection()), ("f0_1", Mut1_reflection()), ("f0_2", Mut2_reflection()), ("f0_3", Mut3_reflection()), ("f0_4", Mut4_reflection()), ("f0_5", option_type(int64_type))], []])


class US6(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US6_0", "US6_1"]


US6_reflection = _expr335

def _expr336() -> TypeInfo:
    return union_type("File_system.US8", [], US8, lambda: [[], [], []])


class US8(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US8_0", "US8_1", "US8_2"]


US8_reflection = _expr336

def _expr337() -> TypeInfo:
    return union_type("File_system.US9", [], US9, lambda: [[], [], [], [], []])


class US9(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US9_0", "US9_1", "US9_2", "US9_3", "US9_4"]


US9_reflection = _expr337

def _expr338() -> TypeInfo:
    return union_type("File_system.US7", [], US7, lambda: [[("f0_0", US8_reflection()), ("f0_1", US9_reflection())], []])


class US7(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US7_0", "US7_1"]


US7_reflection = _expr338

def _expr339() -> TypeInfo:
    return union_type("File_system.US10", [], US10, lambda: [[], [("f1_0", string_type)]])


class US10(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US10_0", "US10_1"]


US10_reflection = _expr339

def _expr340() -> TypeInfo:
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


US11_reflection = _expr340

def _expr341() -> TypeInfo:
    return union_type("File_system.US12", [], US12, lambda: [[("f0_0", int64_type)], [("f1_0", class_type("System.Exception"))]])


class US12(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US12_0", "US12_1"]


US12_reflection = _expr341

def _expr342() -> TypeInfo:
    return union_type("File_system.US13", [], US13, lambda: [[("f0_0", class_type("File_system.chrono_DateTime`1", [class_type("File_system.chrono_Utc")]))], []])


class US13(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US13_0", "US13_1"]


US13_reflection = _expr342

def _expr343() -> TypeInfo:
    return union_type("File_system.US14", [], US14, lambda: [[], [("f1_0", class_type("File_system.std_string_String"))]])


class US14(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US14_0", "US14_1"]


US14_reflection = _expr343

def _expr344() -> TypeInfo:
    return union_type("File_system.US15", [], US15, lambda: [[("f0_0", class_type("File_system.std_path_PathBuf"))], [("f1_0", string_type)]])


class US15(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US15_0", "US15_1"]


US15_reflection = _expr344

def _expr345() -> TypeInfo:
    return union_type("File_system.US16", [], US16, lambda: [[("f0_0", class_type("File_system.std_path_PathBuf"))], []])


class US16(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US16_0", "US16_1"]


US16_reflection = _expr345

def _expr346() -> TypeInfo:
    return record_type("File_system.Mut5", [], Mut5, lambda: [("l0", int32_type), ("l1", int32_type), ("l2", array_type(string_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut5(Record):
    l0: int
    l1: int
    l2: Array[str]

Mut5_reflection = _expr346

def _expr347() -> TypeInfo:
    return record_type("File_system.Mut6", [], Mut6, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut6(Record):
    l0: int

Mut6_reflection = _expr347

def _expr348() -> TypeInfo:
    return union_type("File_system.US17", [], US17, lambda: [[], []])


class US17(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US17_0", "US17_1"]


US17_reflection = _expr348

def _expr349() -> TypeInfo:
    return union_type("File_system.US18", [], US18, lambda: [[("f0_0", string_type)], [("f1_0", string_type)]])


class US18(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US18_0", "US18_1"]


US18_reflection = _expr349

def method3(v0: str) -> str:
    return v0


def method4(__unit: None=None) -> str:
    return ""


def closure1(unit_var: None, v0: str) -> US5:
    return US5(0, v0)


def method5(__unit: None=None) -> Callable[[str], US5]:
    def _arrow350(v: str) -> US5:
        return closure1(None, v)

    return _arrow350


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
    def _arrow351(__unit: None=None) -> US1:
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









    return (US1(0, v41_1.fields[0]) if (v41_1.tag == 0) else _arrow351(), US2(1) if (method2("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


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



def method10(v0: str) -> bool:
    return None


def method9(v0: bool, v1: str) -> None:
    pass


def closure5(unit_var: None, v0: int64) -> US2:
    return US2(0, v0)


def method12(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow352(v: int64) -> US2:
        return closure5(None, v)

    return _arrow352


def method13(__unit: None=None) -> str:
    return "hh:mm:ss"


def method14(__unit: None=None) -> str:
    return "HH:mm:ss"


def method11(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None=None) -> str:
    v920: US2 = default_arg(map(method12(), v5), US2(1))
    v1074: Any
    if v920.tag == 0:
        v1003: Any = create(op_subtraction(from_value(ticks_1(now()), False), v920.fields[0]))
        v1074 = create_1(1, 1, 1, hours(v1003), minutes(v1003), seconds(v1003), milliseconds(v1003))

    else: 
        v1074 = now()

    v1075: str = method14()
    return to_string(v1074, "M-d-y hh:mm:ss tt" if (v1075 == "") else v1075)


def method17(__unit: None=None) -> str:
    return ""


def closure6(v0: Mut3, v1: str, unit_var: None) -> None:
    v4: str = v0.l0 + v1
    v0.l0 = v4


def method16(v0: str) -> str:
    v2: Mut3 = Mut3(method17())
    v17: None
    closure6(v2, ("" + str(v0)) + "", None)
    v17 = None
    return v2.l0


def method15(__unit: None=None) -> str:
    v133: str = "Debug".lower()
    return ("\u001b[94m" + method16(v133[0])) + "\u001b[0m"


def method18(v0: str) -> str:
    raise Exception(((("file_system.get_file_name / target: " + str(US4(6, US3(0)))) + " / path: ") + v0) + "")


def method20(v0: str, v1: str) -> str:
    v3: Mut3 = Mut3(method17())
    v17: None
    closure6(v3, "{ ", None)
    v17 = None
    v36_1: None
    closure6(v3, "ex", None)
    v36_1 = None
    v55: None
    closure6(v3, " = ", None)
    v55 = None
    v72: None
    closure6(v3, v0, None)
    v72 = None
    v91: None
    closure6(v3, "; ", None)
    v91 = None
    v110: None
    closure6(v3, "path", None)
    v110 = None
    v127: None
    closure6(v3, " = ", None)
    v127 = None
    v144: None
    closure6(v3, v1, None)
    v144 = None
    v163: None
    closure6(v3, " }", None)
    v163 = None
    return v3.l0


def method21(v0: str) -> str:
    return trim_end(trim_start(v0, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method19(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v10: str = method20(v8, v9)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.delete_directory_async") + " / ") + v10)


def closure7(v0: Mut0, unit_var: None) -> None:
    v2: int64 = op_addition(v0.l0, int64(1))
    v0.l0 = v2


def closure9(v0: str, unit_var: None) -> None:
    print(v0)


def closure8(unit_var: None, v0: str) -> None:
    v4: None
    closure9(v0, None)
    v4 = None


def closure4(v0: str, v1: Exception, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v339: US6
    class ObjectExpr353:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr353())))) == False:
        v339 = US6(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v165: str = method19(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method15(), to_text(interpolate("%A%P()", [v1])), method18(v0))
        v181: None
        v17(None)
        v181 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v205: Mut1 = pattern_input_2[1]
        v204: Mut0 = pattern_input_2[0]
        v226: None
        closure7(v204, None)
        v226 = None
        closure8(None, v165)
        v205.l0(v165)
        v339 = US6(0, v204, v205, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method8(v0: str, v1: int64) -> Async[int64]:
    def _arrow359(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[int64]:
        def _arrow354(__unit: None=None) -> Async[int64]:
            method9(True, v0)
            return singleton.Return(v1)

        def _arrow358(_arg: Exception) -> Async[int64]:
            v89365: bool = op_modulus(v1, int64(100)) == int64(0)
            def _arrow355(__unit: None=None) -> Async[None]:
                v89719: None
                closure4(v0, _arg, None)
                v89719 = None
                return singleton.Zero()

            def _arrow357(__unit: None=None) -> Async[int64]:
                v90088: Async[None] = sleep(10)
                def _arrow356(__unit: None=None) -> Async[int64]:
                    v90100: Async[int64] = method7(v0, op_addition(v1, int64(1)))
                    return singleton.ReturnFrom(v90100)

                return singleton.Bind(v90088, _arrow356)

            return singleton.Combine(_arrow355() if v89365 else singleton.Zero(), singleton.Delay(_arrow357))

        return singleton.TryWith(singleton.Delay(_arrow354), _arrow358)

    return singleton.Delay(_arrow359)


def method7(v0: str, v1: int64) -> Async[int64]:
    return None


def method6(v0: str) -> Async[int64]:
    return method7(v0, int64(0))


def closure3(unit_var: None, v0: str) -> Async[int64]:
    return method6(v0)


def method26(v0: str, v1: int64, v2: str) -> str:
    v4: Mut3 = Mut3(method17())
    v18: None
    closure6(v4, "{ ", None)
    v18 = None
    v37_1: None
    closure6(v4, "path", None)
    v37_1 = None
    v56: None
    closure6(v4, " = ", None)
    v56 = None
    v73: None
    closure6(v4, v0, None)
    v73 = None
    v92: None
    closure6(v4, "; ", None)
    v92 = None
    v111: None
    closure6(v4, "retry", None)
    v111 = None
    v128: None
    closure6(v4, " = ", None)
    v128 = None
    v148: None
    closure6(v4, ("" + str(v1)) + "", None)
    v148 = None
    v165: None
    closure6(v4, "; ", None)
    v165 = None
    v184: None
    closure6(v4, "ex", None)
    v184 = None
    v201: None
    closure6(v4, " = ", None)
    v201 = None
    v218: None
    closure6(v4, v2, None)
    v218 = None
    v237: None
    closure6(v4, " }", None)
    v237 = None
    return v4.l0


def method25(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: int64, v10: str) -> str:
    v11: str = method26(v8, v9, v10)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.wait_for_file_access") + " / ") + v11)


def closure12(v0: str, v1: int64, v2: Exception, unit_var: None) -> None:
    def v18(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v19: None
    v18(None)
    v19 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v60: US0 = pattern_input[4].l0
    v340: US6
    class ObjectExpr360:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v60, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr360())))) == False:
        v340 = US6(1)

    else: 
        v83: None
        v18(None)
        v83 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v111: int64 | None = pattern_input_1[5]
        v110: Mut4 = pattern_input_1[4]
        v109: Mut3 = pattern_input_1[3]
        v108: Mut2 = pattern_input_1[2]
        v107: Mut1 = pattern_input_1[1]
        v106: Mut0 = pattern_input_1[0]
        v166: str = method25(v106, v107, v108, v109, v110, v111, method11(v106, v107, v108, v109, v110, v111), method15(), method18(v0), v1, to_text(interpolate("%A%P()", [v2])))
        v182: None
        v18(None)
        v182 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v206: Mut1 = pattern_input_2[1]
        v205: Mut0 = pattern_input_2[0]
        v227: None
        closure7(v205, None)
        v227 = None
        closure8(None, v166)
        v206.l0(v166)
        v340 = US6(0, v205, v206, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method24(v0: US7, v1: str, v2: int64, v3: US9, v4: US8) -> Async[int64]:
    def _arrow367(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, v3: Any=v3, v4: Any=v4) -> Async[int64]:
        def _arrow362(__unit: None=None) -> Async[int64]:
            def _arrow361(_arg: Any) -> Async[int64]:
                return singleton.Return(v2)

            return singleton.Using(None, _arrow361)

        def _arrow366(_arg_1: Exception) -> Async[int64]:
            v96500: bool = (op_modulus(v2, int64(100)) == int64(0)) if (v2 > int64(0)) else False
            def _arrow363(__unit: None=None) -> Async[None]:
                v96854: None
                closure12(v1, v2, _arg_1, None)
                v96854 = None
                return singleton.Zero()

            def _arrow365(__unit: None=None) -> Async[int64]:
                v97223: Async[None] = sleep(10)
                def _arrow364(__unit: None=None) -> Async[int64]:
                    v97235: Async[int64] = method23(v0, v1, op_addition(v2, int64(1)))
                    return singleton.ReturnFrom(v97235)

                return singleton.Bind(v97223, _arrow364)

            return singleton.Combine(_arrow363() if v96500 else singleton.Zero(), singleton.Delay(_arrow365))

        return singleton.TryWith(singleton.Delay(_arrow362), _arrow366)

    return singleton.Delay(_arrow367)


def method23(v0: US7, v1: str, v2: int64) -> Async[int64]:
    return None


def method22(v0: US7, v1: str) -> Async[int64]:
    return method23(v0, v1, int64(0))


def closure11(v0: US7, v1: str) -> Async[int64]:
    return method22(v0, v1)


def closure10(unit_var: None, v0: US7) -> Callable[[str], Async[int64]]:
    def _arrow368(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Async[int64]:
        return closure11(v0, v)

    return _arrow368


def method27(v0: str) -> Async[int64]:
    return method22(US7(0, US8(0), US9(1)), v0)


def closure13(unit_var: None, v0: str) -> Async[int64]:
    return method27(v0)


def method31(__unit: None=None) -> str:
    v133: str = "Verbose".lower()
    return ("\u001b[90m" + method16(v133[0])) + "\u001b[0m"


def method33(v0: int64, v1: str, v2: Exception) -> str:
    v4: Mut3 = Mut3(method17())
    v18: None
    closure6(v4, "{ ", None)
    v18 = None
    v37_1: None
    closure6(v4, "retry", None)
    v37_1 = None
    v56: None
    closure6(v4, " = ", None)
    v56 = None
    v76: None
    closure6(v4, ("" + str(v0)) + "", None)
    v76 = None
    v95: None
    closure6(v4, "; ", None)
    v95 = None
    v114: None
    closure6(v4, "path", None)
    v114 = None
    v131: None
    closure6(v4, " = ", None)
    v131 = None
    v148: None
    closure6(v4, v1, None)
    v148 = None
    v165: None
    closure6(v4, "; ", None)
    v165 = None
    v184: None
    closure6(v4, "ex", None)
    v184 = None
    v201: None
    closure6(v4, " = ", None)
    v201 = None
    v260: None
    closure6(v4, to_text(interpolate("%A%P()", [v2])), None)
    v260 = None
    v279: None
    closure6(v4, " }", None)
    v279 = None
    return v4.l0


def method32(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int64, v9: str, v10: Exception) -> str:
    v11: str = method33(v8, v9, v10)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.read_all_text_async") + " / ") + v11)


def closure15(v0: str, v1: int64, v2: Exception, unit_var: None) -> None:
    def v18(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v19: None
    v18(None)
    v19 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v60: US0 = pattern_input[4].l0
    v300: US6
    class ObjectExpr369:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (0 >= find(v60, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr369())))) == False:
        v300 = US6(1)

    else: 
        v83: None
        v18(None)
        v83 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v111: int64 | None = pattern_input_1[5]
        v110: Mut4 = pattern_input_1[4]
        v109: Mut3 = pattern_input_1[3]
        v108: Mut2 = pattern_input_1[2]
        v107: Mut1 = pattern_input_1[1]
        v106: Mut0 = pattern_input_1[0]
        v126: str = method32(v106, v107, v108, v109, v110, v111, method11(v106, v107, v108, v109, v110, v111), method31(), v1, v0, v2)
        v142: None
        v18(None)
        v142 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v166: Mut1 = pattern_input_2[1]
        v165: Mut0 = pattern_input_2[0]
        v187: None
        closure7(v165, None)
        v187 = None
        closure8(None, v126)
        v166.l0(v126)
        v300 = US6(0, v165, v166, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method30(v0: str, v1: int64) -> Async[str]:
    def _arrow373(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[str]:
        def _arrow370(__unit: None=None) -> Async[str]:
            v88162: Async[str] = await_task(None)
            return singleton.ReturnFrom(v88162)

        def _arrow372(_arg: Exception) -> Async[str]:
            v89218: None
            closure15(v0, v1, _arg, None)
            v89218 = None
            v89547: Async[None] = sleep(10)
            def _arrow371(__unit: None=None) -> Async[str]:
                v89563: Async[str]
                if v1 < int64(3):
                    v89563 = method29(v0, op_addition(v1, int64(1)))

                else: 
                    raise Exception(((("file_system.read_all_text_async / retry: " + str(v1)) + " / path: ") + v0) + "")

                return singleton.ReturnFrom(v89563)

            return singleton.Bind(v89547, _arrow371)

        return singleton.TryWith(singleton.Delay(_arrow370), _arrow372)

    return singleton.Delay(_arrow373)


def method29(v0: str, v1: int64) -> Async[str]:
    return method30(v0, v1)


def method28(v0: str) -> Async[str]:
    return method29(v0, int64(0))


def closure14(unit_var: None, v0: str) -> Async[str]:
    return method28(v0)


def method35(v0: str) -> bool:
    return None


def method36(v0: Vec_1[uint8]) -> Vec_1[uint8]:
    return v0


def method34(v0: str, v1: str) -> bool:
    return None


def closure17(v0: str, v1: str) -> bool:
    return method34(v0, v1)


def closure16(unit_var: None, v0: str) -> Callable[[str], bool]:
    def _arrow374(v: str, unit_var: Any=unit_var, v0: Any=v0) -> bool:
        return closure17(v0, v)

    return _arrow374


def method37(v0: str, v1: str) -> Async[None]:
    return None


def closure19(v0: str, v1: str) -> Async[None]:
    return method37(v0, v1)


def closure18(unit_var: None, v0: str) -> Callable[[str], Async[None]]:
    def _arrow375(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Async[None]:
        return closure19(v0, v)

    return _arrow375


def method41(v0: str, v1: str) -> Async[bool]:
    def _arrow377(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[bool]:
        if method35(v0) == False:
            return singleton.Return(False)

        else: 
            v230: Async[str] = method28(v0)
            def _arrow376(_arg: str) -> Async[bool]:
                v232: bool = v1 == _arg
                return singleton.Return(v232)

            return singleton.Bind(v230, _arrow376)


    return singleton.Delay(_arrow377)


def method40(v0: str, v1: str) -> Async[bool]:
    return None


def method39(v0: str, v1: str) -> Async[None]:
    def _arrow382(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[None]:
        v188: Async[bool] = method40(v0, v1)
        def _arrow381(_arg: bool) -> Async[None]:
            v190: bool = _arg == False
            def _arrow379(__unit: None=None) -> Async[None]:
                v191: Async[None] = method37(v0, v1)
                def _arrow378(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v191, _arrow378)

            def _arrow380(__unit: None=None) -> Async[None]:
                return singleton.Zero()

            return singleton.Combine(_arrow379() if v190 else singleton.Zero(), singleton.Delay(_arrow380))

        return singleton.Bind(v188, _arrow381)

    return singleton.Delay(_arrow382)


def method38(v0: str, v1: str) -> Async[None]:
    return method39(v0, v1)


def closure21(v0: str, v1: str) -> Async[None]:
    return method38(v0, v1)


def closure20(unit_var: None, v0: str) -> Callable[[str], Async[None]]:
    def _arrow383(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Async[None]:
        return closure21(v0, v)

    return _arrow383


def method46(v0: std_io_error) -> str:
    v2: Mut3 = Mut3(method17())
    v56: None
    closure6(v2, to_text(interpolate("%A%P()", [v0])), None)
    v56 = None
    return v2.l0


def closure23(unit_var: None, v0: std_io_error) -> str:
    return method46(v0)


def method45(__unit: None=None) -> Callable[[std_io_error], str]:
    def _arrow384(v: std_io_error) -> str:
        return closure23(None, v)

    return _arrow384


def closure24(unit_var: None, unit_var_1: None) -> US10:
    return US10(0)


def method47(__unit: None=None) -> Callable[[], US10]:
    def _arrow385(__unit: None=None) -> US10:
        return closure24(None, None)

    return _arrow385


def closure25(unit_var: None, v0: str) -> US10:
    return US10(1, v0)


def method48(__unit: None=None) -> Callable[[str], US10]:
    def _arrow386(v: str) -> US10:
        return closure25(None, v)

    return _arrow386


def method49(__unit: None=None) -> str:
    v133: str = "Critical".lower()
    return ("\u001b[91m" + method16(v133[0])) + "\u001b[0m"


def method51(v0: str) -> str:
    v2: Mut3 = Mut3(method17())
    v16_1: None
    closure6(v2, "{ ", None)
    v16_1 = None
    v35_1: None
    closure6(v2, "error\'", None)
    v35_1 = None
    v54: None
    closure6(v2, " = ", None)
    v54 = None
    v71: None
    closure6(v2, v0, None)
    v71 = None
    v90: None
    closure6(v2, " }", None)
    v90 = None
    return v2.l0


def method50(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v9: str = method51(v8)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.file_delete") + " / ") + v9)


def closure26(v0: str, unit_var: None) -> None:
    def v16_1(__unit: None=None, v0: Any=v0, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v17: None
    v16_1(None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v58: US0 = pattern_input[4].l0
    v298: US6
    class ObjectExpr387:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (4 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr387())))) == False:
        v298 = US6(1)

    else: 
        v81: None
        v16_1(None)
        v81 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v109: int64 | None = pattern_input_1[5]
        v108: Mut4 = pattern_input_1[4]
        v107: Mut3 = pattern_input_1[3]
        v106: Mut2 = pattern_input_1[2]
        v105: Mut1 = pattern_input_1[1]
        v104: Mut0 = pattern_input_1[0]
        v124: str = method50(v104, v105, v106, v107, v108, v109, method11(v104, v105, v106, v107, v108, v109), method49(), v0)
        v140: None
        v16_1(None)
        v140 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v164: Mut1 = pattern_input_2[1]
        v163: Mut0 = pattern_input_2[0]
        v185: None
        closure7(v163, None)
        v185 = None
        closure8(None, v124)
        v164.l0(v124)
        v298 = US6(0, v163, v164, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method52(__unit: None=None) -> str:
    v133: str = "Warning".lower()
    return ("\u001b[93m" + method16(v133[0])) + "\u001b[0m"


def method54(v0: str, v1: str) -> str:
    v3: Mut3 = Mut3(method17())
    v17: None
    closure6(v3, "{ ", None)
    v17 = None
    v36_1: None
    closure6(v3, "path", None)
    v36_1 = None
    v55: None
    closure6(v3, " = ", None)
    v55 = None
    v72: None
    closure6(v3, v0, None)
    v72 = None
    v91: None
    closure6(v3, "; ", None)
    v91 = None
    v110: None
    closure6(v3, "ex", None)
    v110 = None
    v127: None
    closure6(v3, " = ", None)
    v127 = None
    v144: None
    closure6(v3, v1, None)
    v144 = None
    v163: None
    closure6(v3, " }", None)
    v163 = None
    return v3.l0


def method53(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v10: str = method54(v8, v9)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "delete_file_async") + " / ") + v10)


def closure27(v0: str, v1: Exception, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v339: US6
    class ObjectExpr388:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr388())))) == False:
        v339 = US6(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v165: str = method53(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method52(), method18(v0), to_text(interpolate("%A%P()", [v1])))
        v181: None
        v17(None)
        v181 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v205: Mut1 = pattern_input_2[1]
        v204: Mut0 = pattern_input_2[0]
        v226: None
        closure7(v204, None)
        v226 = None
        closure8(None, v165)
        v205.l0(v165)
        v339 = US6(0, v204, v205, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method44(v0: str, v1: int64) -> Async[int64]:
    def _arrow394(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[int64]:
        def _arrow389(__unit: None=None) -> Async[int64]:
            return singleton.Return(v1)

        def _arrow393(_arg: Exception) -> Async[int64]:
            v169807: bool = op_modulus(v1, int64(100)) == int64(0)
            def _arrow390(__unit: None=None) -> Async[None]:
                v170161: None
                closure27(v0, _arg, None)
                v170161 = None
                return singleton.Zero()

            def _arrow392(__unit: None=None) -> Async[int64]:
                v170530: Async[None] = sleep(10)
                def _arrow391(__unit: None=None) -> Async[int64]:
                    v170542: Async[int64] = method43(v0, op_addition(v1, int64(1)))
                    return singleton.ReturnFrom(v170542)

                return singleton.Bind(v170530, _arrow391)

            return singleton.Combine(_arrow390() if v169807 else singleton.Zero(), singleton.Delay(_arrow392))

        return singleton.TryWith(singleton.Delay(_arrow389), _arrow393)

    return singleton.Delay(_arrow394)


def method43(v0: str, v1: int64) -> Async[int64]:
    return None


def method42(v0: str) -> Async[int64]:
    return method43(v0, int64(0))


def closure22(unit_var: None, v0: str) -> Async[int64]:
    return method42(v0)


def method58(v0: str, v1: str) -> None:
    pass


def method60(v0: str, v1: str, v2: str) -> str:
    v4: Mut3 = Mut3(method17())
    v18: None
    closure6(v4, "{ ", None)
    v18 = None
    v37_1: None
    closure6(v4, "old_path", None)
    v37_1 = None
    v56: None
    closure6(v4, " = ", None)
    v56 = None
    v73: None
    closure6(v4, v0, None)
    v73 = None
    v92: None
    closure6(v4, "; ", None)
    v92 = None
    v111: None
    closure6(v4, "new_path", None)
    v111 = None
    v128: None
    closure6(v4, " = ", None)
    v128 = None
    v145: None
    closure6(v4, v1, None)
    v145 = None
    v162: None
    closure6(v4, "; ", None)
    v162 = None
    v181: None
    closure6(v4, "ex", None)
    v181 = None
    v198: None
    closure6(v4, " = ", None)
    v198 = None
    v215: None
    closure6(v4, v2, None)
    v215 = None
    v234: None
    closure6(v4, " }", None)
    v234 = None
    return v4.l0


def method59(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str, v10: str) -> str:
    v11: str = method60(v8, v9, v10)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "move_file_async") + " / ") + v11)


def closure30(v0: str, v1: str, v2: Exception, unit_var: None) -> None:
    def v18(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v19: None
    v18(None)
    v19 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v60: US0 = pattern_input[4].l0
    v341: US6
    class ObjectExpr395:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v60, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr395())))) == False:
        v341 = US6(1)

    else: 
        v83: None
        v18(None)
        v83 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v111: int64 | None = pattern_input_1[5]
        v110: Mut4 = pattern_input_1[4]
        v109: Mut3 = pattern_input_1[3]
        v108: Mut2 = pattern_input_1[2]
        v107: Mut1 = pattern_input_1[1]
        v106: Mut0 = pattern_input_1[0]
        v167: str = method59(v106, v107, v108, v109, v110, v111, method11(v106, v107, v108, v109, v110, v111), method52(), method18(v1), method18(v0), to_text(interpolate("%A%P()", [v2])))
        v183: None
        v18(None)
        v183 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v207: Mut1 = pattern_input_2[1]
        v206: Mut0 = pattern_input_2[0]
        v228: None
        closure7(v206, None)
        v228 = None
        closure8(None, v167)
        v207.l0(v167)
        v341 = US6(0, v206, v207, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method57(v0: str, v1: str, v2: int64) -> Async[int64]:
    def _arrow401(__unit: None=None, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Async[int64]:
        def _arrow396(__unit: None=None) -> Async[int64]:
            method58(v0, v1)
            return singleton.Return(v2)

        def _arrow400(_arg: Exception) -> Async[int64]:
            v89325: bool = op_modulus(v2, int64(100)) == int64(0)
            def _arrow397(__unit: None=None) -> Async[None]:
                v89680: None
                closure30(v0, v1, _arg, None)
                v89680 = None
                return singleton.Zero()

            def _arrow399(__unit: None=None) -> Async[int64]:
                v90050: Async[None] = sleep(10)
                def _arrow398(__unit: None=None) -> Async[int64]:
                    v90062: Async[int64] = method56(v0, v1, op_addition(v2, int64(1)))
                    return singleton.ReturnFrom(v90062)

                return singleton.Bind(v90050, _arrow398)

            return singleton.Combine(_arrow397() if v89325 else singleton.Zero(), singleton.Delay(_arrow399))

        return singleton.TryWith(singleton.Delay(_arrow396), _arrow400)

    return singleton.Delay(_arrow401)


def method56(v0: str, v1: str, v2: int64) -> Async[int64]:
    return None


def method55(v0: str, v1: str) -> Async[int64]:
    return method56(v0, v1, int64(0))


def closure29(v0: str, v1: str) -> Async[int64]:
    return method55(v0, v1)


def closure28(unit_var: None, v0: str) -> Callable[[str], Async[int64]]:
    def _arrow402(v: str, unit_var: Any=unit_var, v0: Any=v0) -> Async[int64]:
        return closure29(v0, v)

    return _arrow402


def closure33(unit_var: None, v0: int64) -> US11:
    return US11(0, v0)


def method66(__unit: None=None) -> Callable[[int64], US11]:
    def _arrow403(v: int64) -> US11:
        return closure33(None, v)

    return _arrow403


def closure34(unit_var: None, v0: Exception) -> US11:
    return US11(1, v0)


def method67(__unit: None=None) -> Callable[[Exception], US11]:
    def _arrow404(v: Exception) -> US11:
        return closure34(None, v)

    return _arrow404


def closure32(unit_var: None, v0: Any) -> US11:
    return None


def method69(v0: Callable[[Any], US11], v1: Async[Any]) -> Async[US11]:
    def _arrow406(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US11]:
        def _arrow405(_arg: Any) -> Async[US11]:
            v109: US11 = v0(_arg)
            return singleton.Return(v109)

        return singleton.Bind(v1, _arrow405)

    return singleton.Delay(_arrow406)


def method68(v0: Callable[[Any], US11], v1: Async[Any]) -> Async[US11]:
    return method69(v0, v1)


def closure35(unit_var: None, v0: US11) -> US12:
    if v0.tag == 1:
        return US12(1, v0.fields[0])

    else: 
        return US12(0, v0.fields[0])



def method71(v0: Callable[[US11], US12], v1: Async[US11]) -> Async[US12]:
    def _arrow408(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US12]:
        def _arrow407(_arg: US11) -> Async[US12]:
            v109: US12 = v0(_arg)
            return singleton.Return(v109)

        return singleton.Bind(v1, _arrow407)

    return singleton.Delay(_arrow408)


def method70(v0: Callable[[US11], US12], v1: Async[US11]) -> Async[US12]:
    return method71(v0, v1)


def method73(v0: int) -> str:
    v2: Mut3 = Mut3(method17())
    v16_1: None
    closure6(v2, "{ ", None)
    v16_1 = None
    v35_1: None
    closure6(v2, "timeout", None)
    v35_1 = None
    v54: None
    closure6(v2, " = ", None)
    v54 = None
    v74: None
    closure6(v2, ("" + str(v0)) + "", None)
    v74 = None
    v93: None
    closure6(v2, " }", None)
    v93 = None
    return v2.l0


def method72(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int) -> str:
    v9: str = method73(v8)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "async.run_with_timeout_async") + " / ") + v9)


def closure37(v0: int, unit_var: None) -> None:
    def v16_1(__unit: None=None, v0: Any=v0, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v17: None
    v16_1(None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v58: US0 = pattern_input[4].l0
    v298: US6
    class ObjectExpr409:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (0 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr409())))) == False:
        v298 = US6(1)

    else: 
        v81: None
        v16_1(None)
        v81 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v109: int64 | None = pattern_input_1[5]
        v108: Mut4 = pattern_input_1[4]
        v107: Mut3 = pattern_input_1[3]
        v106: Mut2 = pattern_input_1[2]
        v105: Mut1 = pattern_input_1[1]
        v104: Mut0 = pattern_input_1[0]
        v124: str = method72(v104, v105, v106, v107, v108, v109, method11(v104, v105, v106, v107, v108, v109), method31(), v0)
        v140: None
        v16_1(None)
        v140 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v164: Mut1 = pattern_input_2[1]
        v163: Mut0 = pattern_input_2[0]
        v185: None
        closure7(v163, None)
        v185 = None
        closure8(None, v124)
        v164.l0(v124)
        v298 = US6(0, v163, v164, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method75(v0: int, v1: str) -> str:
    v3: Mut3 = Mut3(method17())
    v17: None
    closure6(v3, "{ ", None)
    v17 = None
    v36_1: None
    closure6(v3, "timeout", None)
    v36_1 = None
    v55: None
    closure6(v3, " = ", None)
    v55 = None
    v75: None
    closure6(v3, ("" + str(v0)) + "", None)
    v75 = None
    v94: None
    closure6(v3, "; ", None)
    v94 = None
    v113: None
    closure6(v3, "ex", None)
    v113 = None
    v130: None
    closure6(v3, " = ", None)
    v130 = None
    v147: None
    closure6(v3, v1, None)
    v147 = None
    v166: None
    closure6(v3, " }", None)
    v166 = None
    return v3.l0


def method74(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int, v9: str) -> str:
    v10: str = method75(v8, v9)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "async.run_with_timeout_async**") + " / ") + v10)


def closure38(v0: int, v1: Exception, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v338: US6
    class ObjectExpr410:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (4 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr410())))) == False:
        v338 = US6(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v164: str = method74(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method49(), v0, to_text(interpolate("%A%P()", [v1])))
        v180: None
        v17(None)
        v180 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v204: Mut1 = pattern_input_2[1]
        v203: Mut0 = pattern_input_2[0]
        v225: None
        closure7(v203, None)
        v225 = None
        closure8(None, v164)
        v204.l0(v164)
        v338 = US6(0, v203, v204, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def closure36(v0: int, v1: US12) -> US2:
    if v1.tag == 0:
        return US2(0, v1.fields[0])

    else: 
        v4: Exception = v1.fields[0]
        v6: str = to_text(interpolate("%A%P()", [v4]))
        if v6.find("System.TimeoutException") >= 0:
            v328: None
            closure37(v0, None)
            v328 = None
            return US2(1)

        else: 
            v996: None
            closure38(v0, v4, None)
            v996 = None
            return US2(1)




def method77(v0: Callable[[US12], US2], v1: Async[US12]) -> Async[US2]:
    def _arrow412(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US2]:
        def _arrow411(_arg: US12) -> Async[US2]:
            v109: US2 = v0(_arg)
            return singleton.Return(v109)

        return singleton.Bind(v1, _arrow411)

    return singleton.Delay(_arrow412)


def method76(v0: Callable[[US12], US2], v1: Async[US12]) -> Async[US2]:
    return method77(v0, v1)


def method65(v0: Async[int64], v1: int) -> Async[US2]:
    def _arrow414(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[US2]:
        v2886: Async[Async[int64]] = start_child(v0, v1)
        def _arrow413(_arg: Async[int64]) -> Async[US2]:
            def v2937(v_2: US12) -> US2:
                return closure36(v1, v_2)

            def v2935(v_1: US11) -> US12:
                return closure35(None, v_1)

            def v2933(v: Any) -> US11:
                return closure32(None, v)

            v2938: Async[US2] = method76(v2937, method70(v2935, method68(v2933, catch_async(_arg))))
            return singleton.ReturnFrom(v2938)

        return singleton.Bind(v2886, _arrow413)

    return singleton.Delay(_arrow414)


def method64(v0: int, v1: Async[int64]) -> Async[US2]:
    return method65(v1, v0)


def closure39(unit_var: None, v0: str) -> str | None:
    return v0


def method79(v0: Callable[[str], str | None], v1: Async[str]) -> Async[str | None]:
    def _arrow416(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[str | None]:
        def _arrow415(_arg: str) -> Async[str | None]:
            v109: str | None = v0(_arg)
            return singleton.Return(v109)

        return singleton.Bind(v1, _arrow415)

    return singleton.Delay(_arrow416)


def method78(v0: Callable[[str], str | None], v1: Async[str]) -> Async[str | None]:
    return method79(v0, v1)


def method81(v0: int64, v1: str) -> str:
    v3: Mut3 = Mut3(method17())
    v17: None
    closure6(v3, "{ ", None)
    v17 = None
    v36_1: None
    closure6(v3, "retry", None)
    v36_1 = None
    v55: None
    closure6(v3, " = ", None)
    v55 = None
    v75: None
    closure6(v3, ("" + str(v0)) + "", None)
    v75 = None
    v94: None
    closure6(v3, "; ", None)
    v94 = None
    v113: None
    closure6(v3, "ex", None)
    v113 = None
    v130: None
    closure6(v3, " = ", None)
    v130 = None
    v147: None
    closure6(v3, v1, None)
    v147 = None
    v166: None
    closure6(v3, " }", None)
    v166 = None
    return v3.l0


def method80(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: int64, v9: str) -> str:
    v10: str = method81(v8, v9)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.read_all_text_retry_async") + " / ") + v10)


def closure40(v0: int64, v1: Exception, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v338: US6
    class ObjectExpr417:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr417())))) == False:
        v338 = US6(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v164: str = method80(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method15(), v0, to_text(interpolate("%A%P()", [v1])))
        v180: None
        v17(None)
        v180 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v204: Mut1 = pattern_input_2[1]
        v203: Mut0 = pattern_input_2[0]
        v225: None
        closure7(v203, None)
        v225 = None
        closure8(None, v164)
        v204.l0(v164)
        v338 = US6(0, v203, v204, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method63(v0: str, v1: int64) -> Async[str | None]:
    def _arrow423(__unit: None=None, v0: Any=v0, v1: Any=v1) -> Async[str | None]:
        def _arrow421(__unit: None=None) -> Async[str | None]:
            v90709: bool = v1 > int64(0)
            def _arrow419(__unit: None=None) -> Async[None]:
                v90733: Async[None] = ignore(method64(1000, method27(v0)))
                def _arrow418(__unit: None=None) -> Async[None]:
                    return singleton.Zero()

                return singleton.Bind(v90733, _arrow418)

            def _arrow420(__unit: None=None) -> Async[str | None]:
                def v90748(v: str) -> str | None:
                    return closure39(None, v)

                v90749: Async[str | None] = method78(v90748, method28(v0))
                return singleton.ReturnFrom(v90749)

            return singleton.Combine(_arrow419() if v90709 else singleton.Zero(), singleton.Delay(_arrow420))

        def _arrow422(_arg_1: Exception) -> Async[str | None]:
            if (v1 == int64(0)) != True:
                v91855: None
                closure40(v1, _arg_1, None)
                v91855 = None
                return singleton.Return(None)

            else: 
                v92214: Async[str | None] = method62(v0, op_addition(v1, int64(1)))
                return singleton.ReturnFrom(v92214)


        return singleton.TryWith(singleton.Delay(_arrow421), _arrow422)

    return singleton.Delay(_arrow423)


def method62(v0: str, v1: int64) -> Async[str | None]:
    return method63(v0, v1)


def method61(v0: str) -> Async[str | None]:
    return method62(v0, int64(0))


def closure31(unit_var: None, v0: str) -> Async[str | None]:
    return method61(v0)


def closure42(unit_var: None, v0: chrono_date_time_1[chrono_utc]) -> US13:
    return US13(0, v0)


def method84(__unit: None=None) -> Callable[[chrono_date_time_1[chrono_utc]], US13]:
    def _arrow424(v: chrono_date_time_1[chrono_utc]) -> US13:
        return closure42(None, v)

    return _arrow424


def method85(__unit: None=None) -> str:
    return "hh:mm"


def method86(__unit: None=None) -> str:
    return "yyyyMMdd-HHmm-ssff-ffff-f"


def method87(__unit: None=None) -> str:
    return "hhmm"


def method83(v0: str, v1: Any) -> str:
    v3253: str = method86()
    v3268: str = to_string(v1, "M-d-y hh:mm:ss tt" if (v3253 == "") else v3253)
    v3520: Any
    raise Exception(("date_time.get_utc_offset / target: " + str(US4(6, US3(0)))) + "")
    v3541: uint8 = uint8(1) if (hours(v3520) > 0) else uint8(0)
    v3542: str = method87()
    v3903: str = ((("" + str(v3541)) + "") + to_string_1(v3520, "c", {})) + ""
    v3906: str = str(v0)
    v3911: int = (len(v3268) + len(v3903)) or 0
    v3945: int = (len(v3906) - 1) or 0
    return parse(concat(v3268, v3903, *v3906[v3911:v3945 + 1]))


def method89(__unit: None=None) -> str:
    raise Exception(("file_system.get_temp_path / target: " + str(US4(6, US3(0)))) + "")


def method90(__unit: None=None) -> str:
    return "!create_temp_path_"


def method91(v0: str, v1: str) -> str:
    raise Exception(((((("file_system.(</>) / target: " + str(US4(6, US3(0)))) + " / a: ") + v0) + " / b: ") + v1) + "")


def method93(__unit: None=None) -> str:
    return "CARGO_PKG_NAME"


def method92(__unit: None=None) -> str:
    raise Exception(("env.get_entry_assembly_name / target: " + str(US4(6, US3(0)))) + "")


def method88(v0: str) -> str:
    return method91(method91(method91(method89(), method90()), method92()), str(v0))


def method82(__unit: None=None) -> str:
    v135: Any = now()
    return method88(method83(new_guid(), v135))


def closure41(unit_var: None, unit_var_1: None) -> str:
    return method82()


def closure44(unit_var: None, v0: std_io_error) -> std_string_string:
    return None


def method95(__unit: None=None) -> Callable[[std_io_error], std_string_string]:
    def _arrow425(v: std_io_error) -> std_string_string:
        return closure44(None, v)

    return _arrow425


def closure45(unit_var: None, unit_var_1: None) -> US14:
    return US14(0)


def method96(__unit: None=None) -> Callable[[], US14]:
    def _arrow426(__unit: None=None) -> US14:
        return closure45(None, None)

    return _arrow426


def closure46(unit_var: None, v0: std_string_string) -> US14:
    return US14(1, v0)


def method97(__unit: None=None) -> Callable[[std_string_string], US14]:
    def _arrow427(v: std_string_string) -> US14:
        return closure46(None, v)

    return _arrow427


def method99(v0: str, v1: std_string_string) -> str:
    v3: Mut3 = Mut3(method17())
    v17: None
    closure6(v3, "{ ", None)
    v17 = None
    v36_1: None
    closure6(v3, "dir", None)
    v36_1 = None
    v55: None
    closure6(v3, " = ", None)
    v55 = None
    v72: None
    closure6(v3, v0, None)
    v72 = None
    v91: None
    closure6(v3, "; ", None)
    v91 = None
    v110: None
    closure6(v3, "error", None)
    v110 = None
    v127: None
    closure6(v3, " = ", None)
    v127 = None
    v186: None
    closure6(v3, to_text(interpolate("%A%P()", [v1])), None)
    v186 = None
    v205: None
    closure6(v3, " }", None)
    v205 = None
    return v3.l0


def method98(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: std_string_string) -> str:
    v10: str = method99(v8, v9)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v10)


def closure47(v0: str, v1: std_string_string, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v299: US6
    class ObjectExpr428:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (4 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr428())))) == False:
        v299 = US6(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v125: str = method98(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method49(), v0, v1)
        v141: None
        v17(None)
        v141 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v165: Mut1 = pattern_input_2[1]
        v164: Mut0 = pattern_input_2[0]
        v186: None
        closure7(v164, None)
        v186 = None
        closure8(None, v125)
        v165.l0(v125)
        v299 = US6(0, v164, v165, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method101(v0: str) -> str:
    v2: Mut3 = Mut3(method17())
    v16_1: None
    closure6(v2, "{ ", None)
    v16_1 = None
    v35_1: None
    closure6(v2, "dir", None)
    v35_1 = None
    v54: None
    closure6(v2, " = ", None)
    v54 = None
    v71: None
    closure6(v2, v0, None)
    v71 = None
    v90: None
    closure6(v2, " }", None)
    v90 = None
    return v2.l0


def method100(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str) -> str:
    v9: str = method101(v8)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v9)


def closure48(v0: str, unit_var: None) -> None:
    def v16_1(__unit: None=None, v0: Any=v0, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v17: None
    v16_1(None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v58: US0 = pattern_input[4].l0
    v298: US6
    class ObjectExpr429:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (0 >= find(v58, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr429())))) == False:
        v298 = US6(1)

    else: 
        v81: None
        v16_1(None)
        v81 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v109: int64 | None = pattern_input_1[5]
        v108: Mut4 = pattern_input_1[4]
        v107: Mut3 = pattern_input_1[3]
        v106: Mut2 = pattern_input_1[2]
        v105: Mut1 = pattern_input_1[1]
        v104: Mut0 = pattern_input_1[0]
        v124: str = method100(v104, v105, v106, v107, v108, v109, method11(v104, v105, v106, v107, v108, v109), method31(), v0)
        v140: None
        v16_1(None)
        v140 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v164: Mut1 = pattern_input_2[1]
        v163: Mut0 = pattern_input_2[0]
        v185: None
        closure7(v163, None)
        v185 = None
        closure8(None, v124)
        v164.l0(v124)
        v298 = US6(0, v163, v164, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def closure49(v0: str, unit_var: None) -> None:
    method9(True, v0)


def method102(v0: str) -> Callable[[], None]:
    def _arrow430(__unit: None=None, v0: Any=v0) -> None:
        closure49(v0, None)

    return _arrow430


def method103(v0: str) -> Callable[[], None]:
    def _arrow431(__unit: None=None, v0: Any=v0) -> None:
        closure49(v0, None)

    return _arrow431


def method104(v0: str) -> bool:
    return None


def method106(v0: str, v1: str) -> str:
    v3: Mut3 = Mut3(method17())
    v17: None
    closure6(v3, "{ ", None)
    v17 = None
    v36_1: None
    closure6(v3, "dir", None)
    v36_1 = None
    v55: None
    closure6(v3, " = ", None)
    v55 = None
    v72: None
    closure6(v3, v0, None)
    v72 = None
    v91: None
    closure6(v3, "; ", None)
    v91 = None
    v110: None
    closure6(v3, "result", None)
    v110 = None
    v127: None
    closure6(v3, " = ", None)
    v127 = None
    v144: None
    closure6(v3, v1, None)
    v144 = None
    v163: None
    closure6(v3, " }", None)
    v163 = None
    return v3.l0


def method105(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v10: str = method106(v8, v9)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v10)


def closure50(v0: str, v1: str, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v299: US6
    class ObjectExpr432:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (1 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr432())))) == False:
        v299 = US6(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v125: str = method105(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method15(), v0, v1)
        v141: None
        v17(None)
        v141 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v165: Mut1 = pattern_input_2[1]
        v164: Mut0 = pattern_input_2[0]
        v186: None
        closure7(v164, None)
        v186 = None
        closure8(None, v125)
        v165.l0(v125)
        v299 = US6(0, v164, v165, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def closure51(v0: str, unit_var: None) -> None:
    run_synchronously(ignore(method6(v0)))


def method107(v0: str) -> Callable[[], None]:
    def _arrow433(__unit: None=None, v0: Any=v0) -> None:
        closure51(v0, None)

    return _arrow433


def method108(v0: str) -> Callable[[], None]:
    def _arrow434(__unit: None=None, v0: Any=v0) -> None:
        closure51(v0, None)

    return _arrow434


def method94(v0: str) -> IDisposable:
    v2793: bool = method104(v0)
    v2825: bool = None
    if v2825 == False:
        v3193: None
        closure50(v0, to_text(interpolate("%A%P()", [{
            "CreationTime": None,
            "Exists": v2825
        }])), None)
        v3193 = None

    v3521: Callable[[], None] = method108(v0)
    class ObjectExpr435(IDisposable):
        def Dispose(self, __unit: None=None, v0: Any=v0) -> None:
            v3521(None)

    return ObjectExpr435()


def closure43(unit_var: None, unit_var_1: None) -> tuple[str, IDisposable]:
    v0: str = method82()
    return (v0, method94(v0))


def closure53(v0: int, v1: str, v2: int, v3: str) -> str:
    if v2 >= v0:
        return v3

    else: 
        return method110(v0, v1, v2 + 1)(v3 + v1)



def method110(v0: int, v1: str, v2: int) -> Callable[[str], str]:
    def _arrow436(v: str, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> str:
        return closure53(v0, v1, v2, v)

    return _arrow436


def method109(v0: str) -> str:
    v13: str = method110(32 - len(v0), "0", 0)("") + v0
    v1021: int = (8 - 1) or 0
    v1055: int = (12 - 1) or 0
    v1089: int = (16 - 1) or 0
    v1123: int = (20 - 1) or 0
    v1157: int = (32 - 1) or 0
    return parse((((((((v13[0:v1021 + 1] + "-") + v13[8:v1055 + 1]) + "-") + v13[12:v1089 + 1]) + "-") + v13[16:v1123 + 1]) + "-") + v13[20:v1157 + 1])


def closure52(unit_var: None, v0: str) -> tuple[str, IDisposable]:
    v2: str = method88(method109(v0))
    return (v2, method94(v2))


def closure54(unit_var: None, unit_var_1: None) -> str:
    return "c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral"


def closure56(unit_var: None, v0: std_path_path_buf) -> US15:
    return US15(0, v0)


def method114(__unit: None=None) -> Callable[[std_path_path_buf], US15]:
    def _arrow437(v: std_path_path_buf) -> US15:
        return closure56(None, v)

    return _arrow437


def closure57(unit_var: None, v0: str) -> US15:
    return US15(1, v0)


def method115(__unit: None=None) -> Callable[[str], US15]:
    def _arrow438(v: str) -> US15:
        return closure57(None, v)

    return _arrow438


def method118(v0: str) -> str | None:
    return None


def method119(v0: str) -> str:
    v2: Mut3 = Mut3(method17())
    v14_1: None
    closure6(v2, v0, None)
    v14_1 = None
    return v2.l0


def method117(v0: str, v1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2: uint8, v3: str, v4: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v5: str = method18(v4)
    v6: str | None = method118(v4)
    v31_1: US5 = default_arg(map(method5(), v6), US5(1))
    v35_1: str = method119(v3)
    if v2 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0) + " / n: ") + str(v2)) + " / path\': ") + v4) + " / name: ") + v5) + ""))

    elif v31_1.tag == 0:
        if v4 != "":
            v100: FSharpResult_2[std_path_path_buf, std_io_error] = v1(v2 + uint8(1), v31_1.fields[0])
            v101: Callable[[std_io_error], str] = method45()
            v114: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v101(v100.fields[0])) if (v100.tag == 1) else FSharpResult_2(0, v100.fields[0])
            v117: Callable[[std_path_path_buf], US15] = method114()
            v118: Callable[[str], US15] = method115()
            v120: US15 = v118(v114.fields[0]) if (v114.tag == 1) else v117(v114.fields[0])
            if v120.tag == 0:
                return FSharpResult_2(0, method91(to_string_2(v120.fields[0]), v5))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v120.fields[0]) + " / error: ") + v35_1) + " / name: ") + v5) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v35_1) + " / path\': ") + v4) + " / name: ") + v5) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v35_1) + " / path\': ") + v4) + " / name: ") + v5) + ""))



def method116(v0: str, v1: uint8, v2: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return None


def closure59(v0: str, v1: uint8, v2: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return method116(v0, v1, v2)


def closure58(v0: str, v1: uint8) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
    def _arrow439(v: str, v0: Any=v0, v1: Any=v1) -> FSharpResult_2[std_path_path_buf, std_io_error]:
        return closure59(v0, v1, v)

    return _arrow439


def method120(v0: str, v1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2: uint8, v3: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v4: str = method18(v0)
    v5: str | None = method118(v0)
    v30: US5 = default_arg(map(method5(), v5), US5(1))
    v34_1: str = method119(v3)
    if v2 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0) + " / n: ") + str(v2)) + " / path\': ") + v0) + " / name: ") + v4) + ""))

    elif v30.tag == 0:
        if v0 != "":
            v99: FSharpResult_2[std_path_path_buf, std_io_error] = v1(v2 + uint8(1), v30.fields[0])
            v100: Callable[[std_io_error], str] = method45()
            v113: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v100(v99.fields[0])) if (v99.tag == 1) else FSharpResult_2(0, v99.fields[0])
            v116: Callable[[std_path_path_buf], US15] = method114()
            v117: Callable[[str], US15] = method115()
            v119: US15 = v117(v113.fields[0]) if (v113.tag == 1) else v116(v113.fields[0])
            if v119.tag == 0:
                return FSharpResult_2(0, method91(to_string_2(v119.fields[0]), v4))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v119.fields[0]) + " / error: ") + v34_1) + " / name: ") + v4) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v34_1) + " / path\': ") + v0) + " / name: ") + v4) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v34_1) + " / path\': ") + v0) + " / name: ") + v4) + ""))



def method113(v0: str, v1: uint8) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return None


def method122(v0: bool) -> enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]):
    return None


def method123(__unit: None=None) -> enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]):
    return None


def method124(v0: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]), v1: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)])) -> bool:
    return None


def method126(v0: str, v1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2: uint8, v3: std_io_error, v4: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v5: str = method18(v4)
    v6: str | None = method118(v4)
    v31_1: US5 = default_arg(map(method5(), v6), US5(1))
    v35_1: str = method46(v3)
    if v2 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0) + " / n: ") + str(v2)) + " / path\': ") + v4) + " / name: ") + v5) + ""))

    elif v31_1.tag == 0:
        if v4 != "":
            v100: FSharpResult_2[std_path_path_buf, std_io_error] = v1(v2 + uint8(1), v31_1.fields[0])
            v101: Callable[[std_io_error], str] = method45()
            v114: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v101(v100.fields[0])) if (v100.tag == 1) else FSharpResult_2(0, v100.fields[0])
            v117: Callable[[std_path_path_buf], US15] = method114()
            v118: Callable[[str], US15] = method115()
            v120: US15 = v118(v114.fields[0]) if (v114.tag == 1) else v117(v114.fields[0])
            if v120.tag == 0:
                return FSharpResult_2(0, method91(to_string_2(v120.fields[0]), v5))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v120.fields[0]) + " / error: ") + v35_1) + " / name: ") + v5) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v35_1) + " / path\': ") + v4) + " / name: ") + v5) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v35_1) + " / path\': ") + v4) + " / name: ") + v5) + ""))



def method125(v0: str, v1: uint8, v2: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v45_1: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]) = method122(None) or 0
    v47_1: bool = method124(method123(), v45_1)
    if v47_1:
        return FSharpResult_2(0, None)

    else: 
        def v190(v: uint8, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
            return closure60(v0, v)

        return method126(v0, uncurry2(v190), v1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / result: ") + str(v47_1)) + " / path\': ") + v2) + " / n: ") + str(v1)) + ""), v2)



def closure61(v0: str, v1: uint8, v2: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return method125(v0, v1, v2)


def closure60(v0: str, v1: uint8) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
    def _arrow440(v: str, v0: Any=v0, v1: Any=v1) -> FSharpResult_2[std_path_path_buf, std_io_error]:
        return closure61(v0, v1, v)

    return _arrow440


def method127(v0: str, v1: Callable[[uint8, str], FSharpResult_2[std_path_path_buf, std_io_error]], v2: uint8, v3: std_io_error) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v4: str = method18(v0)
    v5: str | None = method118(v0)
    v30: US5 = default_arg(map(method5(), v5), US5(1))
    v34_1: str = method46(v3)
    if v2 >= uint8(11):
        return FSharpResult_2(1, "file_system.read_link / " + (((((((("path: " + v0) + " / n: ") + str(v2)) + " / path\': ") + v0) + " / name: ") + v4) + ""))

    elif v30.tag == 0:
        if v0 != "":
            v99: FSharpResult_2[std_path_path_buf, std_io_error] = v1(v2 + uint8(1), v30.fields[0])
            v100: Callable[[std_io_error], str] = method45()
            v113: FSharpResult_2[std_path_path_buf, str] = FSharpResult_2(1, v100(v99.fields[0])) if (v99.tag == 1) else FSharpResult_2(0, v99.fields[0])
            v116: Callable[[std_path_path_buf], US15] = method114()
            v117: Callable[[str], US15] = method115()
            v119: US15 = v117(v113.fields[0]) if (v113.tag == 1) else v116(v113.fields[0])
            if v119.tag == 0:
                return FSharpResult_2(0, method91(to_string_2(v119.fields[0]), v4))

            else: 
                return FSharpResult_2(1, "file_system.read_link / " + (((((("error\': " + v119.fields[0]) + " / error: ") + v34_1) + " / name: ") + v4) + ""))


        else: 
            return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v34_1) + " / path\': ") + v0) + " / name: ") + v4) + ""))


    else: 
        return FSharpResult_2(1, "file_system.read_link / run / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / error: ") + v34_1) + " / path\': ") + v0) + " / name: ") + v4) + ""))



def method121(v0: str, v1: uint8) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    v44_1: enum_type("System.IO.FileAttributes", int, [("None", 0.0), ("ReadOnly", 1.0), ("Hidden", 2.0), ("System", 4.0), ("Directory", 16.0), ("Archive", 32.0), ("Device", 64.0), ("Normal", 128.0), ("Temporary", 256.0), ("SparseFile", 512.0), ("ReparsePoint", 1024.0), ("Compressed", 2048.0), ("Offline", 4096.0), ("NotContentIndexed", 8192.0), ("Encrypted", 16384.0), ("IntegrityStream", 32768.0), ("NoScrubData", 131072.0)]) = method122(None) or 0
    v46_1: bool = method124(method123(), v44_1)
    if v46_1:
        return FSharpResult_2(0, None)

    else: 
        def v189(v: uint8, v0: Any=v0, v1: Any=v1) -> Callable[[str], FSharpResult_2[std_path_path_buf, std_io_error]]:
            return closure60(v0, v)

        return method127(v0, uncurry2(v189), v1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (((((((("path: " + v0) + " / result: ") + str(v46_1)) + " / path\': ") + v0) + " / n: ") + str(v1)) + ""))



def method112(v0: str) -> FSharpResult_2[std_path_path_buf, std_io_error]:
    return FSharpResult_2()


def closure62(unit_var: None, v0: std_path_path_buf) -> US16:
    return US16(0, v0)


def method128(__unit: None=None) -> Callable[[std_path_path_buf], US16]:
    def _arrow441(v: std_path_path_buf) -> US16:
        return closure62(None, v)

    return _arrow441


def method130(v0: str) -> str:
    return v0


def method131(__unit: None=None) -> str:
    return ""


def method129(v0: str, v1: str, v2: str) -> str:
    return method131()


def method111(v0: str) -> str:
    if v0 == "":
        return ""

    else: 
        v3: FSharpResult_2[std_path_path_buf, std_io_error] = method112(v0)
        v13: std_path_path_buf | None = None if (v3.tag == 1) else v3.fields[0]
        v43_1: US16 = default_arg(map(method128(), v13), US16(1))
        v89: str = to_string_2(v43_1.fields[0]) if (v43_1.tag == 0) else v0
        v94: str = method129("^\\\\\\\\\\?\\\\", "", v0 if (v89 == "") else v89)
        if len(v94) < 2:
            return v0

        else: 
            def _arrow442(__unit: None=None, v0: Any=v0) -> str:
                _arg: str = v94[0]
                return _arg.lower()

            return replace(concat(_arrow442(), *v94[1:len(v94)]), "\\", "/")




def closure55(unit_var: None, v0: str) -> str:
    return method111(v0)


def method133(__unit: None=None) -> str:
    return None


def method134(v0: int, v1: Mut5) -> bool:
    return v1.l0 < v0


def method135(v0: int, v1: Mut6) -> bool:
    return v1.l0 < v0


def method136(__unit: None=None) -> str:
    return "/"


def method137(v0: str) -> str:
    return v0


def method132(v0: str) -> str:
    return None


def closure63(unit_var: None, v0: str) -> str:
    return method132(v0)


def method138(v0: str) -> str:
    return method111(method132(v0))


def closure64(unit_var: None, v0: str) -> str:
    return method138(v0)


def closure65(unit_var: None, v0: str) -> str:
    return concat("file:///", *trim_start(v0, *to_array(singleton_1("/"))))


def closure67(unit_var: None, v0: str) -> bool:
    return method35(v0)


def closure68(unit_var: None, v0: str) -> bool:
    return method10(v0)


def method142(v0_mut: str, v1_mut: str, v2_mut: bool, v3_mut: Callable[[str], bool], v4_mut: str) -> US18:
    while True:
        (v0, v1, v2, v3, v4) = (v0_mut, v1_mut, v2_mut, v3_mut, v4_mut)
        if v3(method91(v4, v0)):
            return US18(0, v4)

        else: 
            v8: str | None = method118(v4)
            v33_1: US5 = default_arg(map(method5(), v8), US5(1))
            if v33_1.tag == 0:
                v0_mut = v0
                v1_mut = v1
                v2_mut = v2
                v3_mut = v3
                v4_mut = v33_1.fields[0]
                continue

            else: 
                return US18(1, concat("file_system.find_parent / No parent for ", *"file" if v2 else "dir") + ((((((" \'" + v0) + "\' at \'") + v1) + "\' (until \'") + v4) + "\')"))


        break


def method141(v0: str, v1: str, v2: bool, v3: Callable[[str], bool]) -> US18:
    if v3(method91(v1, v0)):
        return US18(0, v1)

    else: 
        v7: str | None = method118(v1)
        v32_1: US5 = default_arg(map(method5(), v7), US5(1))
        if v32_1.tag == 0:
            return method142(v0, v1, v2, v3, v32_1.fields[0])

        else: 
            return US18(1, concat("file_system.find_parent / No parent for ", *"file" if v2 else "dir") + ((((((" \'" + v0) + "\' at \'") + v1) + "\' (until \'") + v1) + "\')"))




def method140(v0: US17, v1: str, v2: str) -> US18:
    v3: bool = True if (v0.tag == 0) else False
    def _arrow443(v: str, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> bool:
        return closure67(None, v)

    def _arrow444(v_1: str, v0: Any=v0, v1: Any=v1, v2: Any=v2) -> bool:
        return closure68(None, v_1)

    return method141(v1, v2, v3, _arrow443 if v3 else _arrow444)


def method144(v0: str, v1: str) -> str:
    v3: Mut3 = Mut3(method17())
    v17: None
    closure6(v3, "{ ", None)
    v17 = None
    v36_1: None
    closure6(v3, "dir", None)
    v36_1 = None
    v55: None
    closure6(v3, " = ", None)
    v55 = None
    v72: None
    closure6(v3, v0, None)
    v72 = None
    v91: None
    closure6(v3, "; ", None)
    v91 = None
    v110: None
    closure6(v3, "error", None)
    v110 = None
    v127: None
    closure6(v3, " = ", None)
    v127 = None
    v144: None
    closure6(v3, v1, None)
    v144 = None
    v163: None
    closure6(v3, " }", None)
    v163 = None
    return v3.l0


def method143(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: int64 | None, v6: str, v7: str, v8: str, v9: str) -> str:
    v10: str = method144(v8, v9)
    return method21((((((((v6 + " ") + v7) + " #") + int64_to_string(v0.l0)) + " ") + "file_system.get_workspace_root") + " / ") + v10)


def closure69(v0: str, v1: str, unit_var: None) -> None:
    def v17(__unit: None=None, v0: Any=v0, v1: Any=v1, unit_var: Any=unit_var) -> None:
        closure0(None, None)

    v18: None
    v17(None)
    v18 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    v59: US0 = pattern_input[4].l0
    v299: US6
    class ObjectExpr445:
        @property
        def Compare(self) -> Callable[[US0, US0], int]:
            return compare

    if (False if (pattern_input[2].l0 == False) else (3 >= find(v59, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr445())))) == False:
        v299 = US6(1)

    else: 
        v82: None
        v17(None)
        v82 = None
        pattern_input_1: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v110: int64 | None = pattern_input_1[5]
        v109: Mut4 = pattern_input_1[4]
        v108: Mut3 = pattern_input_1[3]
        v107: Mut2 = pattern_input_1[2]
        v106: Mut1 = pattern_input_1[1]
        v105: Mut0 = pattern_input_1[0]
        v125: str = method143(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method52(), v0, v1)
        v141: None
        v17(None)
        v141 = None
        pattern_input_2: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
        v165: Mut1 = pattern_input_2[1]
        v164: Mut0 = pattern_input_2[0]
        v186: None
        closure7(v164, None)
        v186 = None
        closure8(None, v125)
        v165.l0(v125)
        v299 = US6(0, v164, v165, pattern_input_2[2], pattern_input_2[3], pattern_input_2[4], pattern_input_2[5])



def method139(v0: str) -> US5:
    v5: US18 = method140(US17(1), method91("spiral", "workspace"), v0)
    if v5.tag == 0:
        return US5(0, method111(v5.fields[0]))

    else: 
        v323: None
        closure69(v0, v5.fields[0], None)
        v323 = None
        return US5(1)



def closure66(unit_var: None, unit_var_1: None) -> str:
    v1: US5 = method139(method133())
    v7: US5 = US5(0, v1.fields[0]) if (v1.tag == 0) else method139("c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral")
    v13: US5 = US5(0, v7.fields[0]) if (v7.tag == 0) else method139("/workspaces")
    v17: str
    if v13.tag == 0:
        v17 = v13.fields[0]

    else: 
        raise Exception("Option does not have a value.")

    def _arrow446(__unit: None=None, unit_var: Any=unit_var, unit_var_1: Any=unit_var_1) -> str:
        v25: US5 = method139(value_10(method118(v17)))
        if v25.tag == 0:
            return v25.fields[0]

        else: 
            raise Exception("Option does not have a value.")


    return method91(_arrow446() if ("deps" == method18(v17)) else v17, "polyglot")


def closure71(v0: Exception, unit_var: None) -> Exception:
    return v0


def method145(v0: str) -> None:
    pass


def closure70(unit_var: None, v0: str) -> None:
    method145(v0)


def closure72(unit_var: None, v0: bool) -> None:
    v17: None
    closure0(None, None)
    v17 = None
    pattern_input: tuple[Mut0, Mut1, Mut2, Mut3, Mut4, int64 | None] = value_10(TraceState_trace_state())
    def _arrow447(v: str, unit_var: Any=unit_var, v0: Any=v0) -> None:
        closure70(None, v)

    def _arrow448(v_1: str, unit_var: Any=unit_var, v0: Any=v0) -> None:
        closure2(None, v_1)

    v60: Callable[[str], None] = _arrow447 if v0 else _arrow448
    pattern_input[1].l0 = v60


def method146(v0: str, v1: str) -> None:
    if method10(v0) == False:
        v4: IDisposable = method94(v0)

    v9: str = default_arg(method118(v1), "")
    if method10(v9) == False:
        v14_1: IDisposable = method94(v9)

    def _arrow449(__unit: None=None, v0: Any=v0, v1: Any=v1) -> bool:
        v16_1: FSharpResult_2[std_path_path_buf, std_io_error] = method112(v1)
        return True

    if _arrow449() if method10(v1) else False:
        method9(True, v1)

    if method10(v1) == False:
        pass



def closure74(v0: str, v1: str) -> None:
    method146(v0, v1)


def closure73(unit_var: None, v0: str) -> Callable[[str], None]:
    def _arrow450(v: str, unit_var: Any=unit_var, v0: Any=v0) -> None:
        closure74(v0, v)

    return _arrow450


def closure76(v0: str, v1: str) -> str:
    return method91(v0, v1)


def closure75(unit_var: None, v0: str) -> Callable[[str], str]:
    def _arrow451(v: str, unit_var: Any=unit_var, v0: Any=v0) -> str:
        return closure76(v0, v)

    return _arrow451


v14: None = None

def _arrow452(__unit: None=None) -> None:
    closure0(None, None)


v15: Callable[[], None] = _arrow452

def _expr453():
    v15(None)
    return v14


v16: None = _expr453()

def _arrow454(v: str) -> Async[int64]:
    return closure3(None, v)


v31: Callable[[str], Async[int64]] = _arrow454

def delete_directory_async(x: str) -> Async[int64]:
    return v31(x)


def _arrow455(v: US7) -> Callable[[str], Async[int64]]:
    return closure10(None, v)


v32: Callable[[US7, str], Async[int64]] = _arrow455

def wait_for_file_access(x: US7) -> Callable[[str], Async[int64]]:
    return v32(x)


def _arrow456(v: str) -> Async[int64]:
    return closure13(None, v)


v33: Callable[[str], Async[int64]] = _arrow456

def wait_for_file_access_read(x: str) -> Async[int64]:
    return v33(x)


def _arrow457(v: str) -> Async[str]:
    return closure14(None, v)


v34: Callable[[str], Async[str]] = _arrow457

def read_all_text_async(x: str) -> Async[str]:
    return v34(x)


def _arrow458(v: str) -> Callable[[str], bool]:
    return closure16(None, v)


v35: Callable[[str, str], bool] = _arrow458

def file_exists_content(x: str) -> Callable[[str], bool]:
    return v35(x)


def _arrow459(v: str) -> Callable[[str], Async[None]]:
    return closure18(None, v)


v36: Callable[[str, str], Async[None]] = _arrow459

def write_all_text_async(x: str) -> Callable[[str], Async[None]]:
    return v36(x)


def _arrow460(v: str) -> Callable[[str], Async[None]]:
    return closure20(None, v)


v37: Callable[[str, str], Async[None]] = _arrow460

def write_all_text_exists(x: str) -> Callable[[str], Async[None]]:
    return v37(x)


def _arrow461(v: str) -> Async[int64]:
    return closure22(None, v)


v38: Callable[[str], Async[int64]] = _arrow461

def delete_file_async(x: str) -> Async[int64]:
    return v38(x)


def _arrow462(v: str) -> Callable[[str], Async[int64]]:
    return closure28(None, v)


v39: Callable[[str, str], Async[int64]] = _arrow462

def move_file_async(x: str) -> Callable[[str], Async[int64]]:
    return v39(x)


def _arrow463(v: str) -> Async[str | None]:
    return closure31(None, v)


v40: Callable[[str], Async[str | None]] = _arrow463

def read_all_text_retry_async(x: str) -> Async[str | None]:
    return v40(x)


def _arrow464(__unit: None=None) -> str:
    return closure41(None, None)


v41: Callable[[], str] = _arrow464

def create_temp_path(__unit: None=None) -> str:
    return v41(None)


def _arrow465(__unit: None=None) -> tuple[str, IDisposable]:
    return closure43(None, None)


v42: Callable[[], tuple[str, IDisposable]] = _arrow465

def create_temp_dir(__unit: None=None) -> tuple[str, IDisposable]:
    return v42(None)


def _arrow466(v: str) -> tuple[str, IDisposable]:
    return closure52(None, v)


v43: Callable[[str], tuple[str, IDisposable]] = _arrow466

def create_temp_dir_0027(x: str) -> tuple[str, IDisposable]:
    return v43(x)


def _arrow467(__unit: None=None) -> str:
    return closure54(None, None)


v44: Callable[[], str] = _arrow467

def get_source_directory(__unit: None=None) -> str:
    return v44(None)


def _arrow468(v: str) -> str:
    return closure55(None, v)


v45: Callable[[str], str] = _arrow468

def normalize_path(x: str) -> str:
    return v45(x)


def _arrow469(v: str) -> str:
    return closure63(None, v)


v46: Callable[[str], str] = _arrow469

def get_full_path(x: str) -> str:
    return v46(x)


def _arrow470(v: str) -> str:
    return closure64(None, v)


v47: Callable[[str], str] = _arrow470

def standardize_path(x: str) -> str:
    return v47(x)


def _arrow471(v: str) -> str:
    return closure65(None, v)


v48: Callable[[str], str] = _arrow471

def new_file_uri(x: str) -> str:
    return v48(x)


def _arrow472(__unit: None=None) -> str:
    return closure66(None, None)


v49: Callable[[], str] = _arrow472

def get_workspace_root(__unit: None=None) -> str:
    return v49(None)


def _arrow473(v: str) -> None:
    closure70(None, v)


v50: Callable[[str], None] = _arrow473

def trace_file(x: str) -> None:
    v50(x)


def _arrow474(v: bool) -> None:
    closure72(None, v)


v51: Callable[[bool], None] = _arrow474

def init_trace_file(x: bool) -> None:
    v51(x)


def _arrow475(v: str) -> Callable[[str], None]:
    return closure73(None, v)


v52: Callable[[str, str], None] = _arrow475

def link_directory(x: str) -> Callable[[str], None]:
    return v52(x)


def _arrow476(v: str) -> Callable[[str], str]:
    return closure75(None, v)


v53: Callable[[str, str], str] = _arrow476

def op_less_divide_greater(x: str) -> Callable[[str], str]:
    return v53(x)


