from __future__ import annotations
from abc import abstractmethod
from fable_modules.fable_library.char import char_code_at
from fable_modules.fable_library.date import (ticks as ticks_1, now, create as create_1, to_string)
from fable_modules.fable_library.int32 import parse
from fable_modules.fable_library.list import (to_array, empty, of_array)
from fable_modules.fable_library.long import (from_value, op_subtraction, op_addition)
from fable_modules.fable_library.map import (find, of_seq)
from fable_modules.fable_library.option import (some, value as value_2, default_arg, map)
from fable_modules.fable_library.reflection import (TypeInfo, int32_type, record_type, union_type, int64_type, string_type, unit_type, lambda_type, bool_type)
from fable_modules.fable_library.string_ import (trim_end, trim_start)
from fable_modules.fable_library.time_span import (create, hours, minutes, seconds, milliseconds)
from fable_modules.fable_library.types import (int64, Record, Array, Union, uint16)
from fable_modules.fable_library.util import (create_atom, to_enumerable, compare)
from collections.abc import Callable
from dataclasses import dataclass
import hashlib
import os
from typing import (Any, Protocol)

class ICryptoCreateHash(Protocol):
    @abstractmethod
    def create_hash(self, x: str) -> Any:
        ...


class IHashlibSha256(Protocol):
    @abstractmethod
    def sha256(self) -> Any:
        ...


TraceState_trace_state: tuple[Mut1, Mut2, Mut3, Mut4, Mut5, int64 | None] | None = create_atom(None)

class IOsEnviron(Protocol):
    @abstractmethod
    def environ(self) -> Any:
        ...


def _expr81() -> TypeInfo:
    return record_type("Crypto.Mut0", [], Mut0, lambda: [("l0", int32_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut0(Record):
    l0: int

Mut0_reflection = _expr81

def _expr82() -> TypeInfo:
    return union_type("Crypto.US0", [], US0, lambda: [[], [], [], [], []])


class US0(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US0_0", "US0_1", "US0_2", "US0_3", "US0_4"]


US0_reflection = _expr82

def _expr83() -> TypeInfo:
    return record_type("Crypto.Mut1", [], Mut1, lambda: [("l0", int64_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut1(Record):
    l0: int64

Mut1_reflection = _expr83

def _expr84() -> TypeInfo:
    return record_type("Crypto.Mut2", [], Mut2, lambda: [("l0", lambda_type(string_type, unit_type))])


@dataclass(eq = False, repr = False, slots = True)
class Mut2(Record):
    l0: Callable[[str], None]

Mut2_reflection = _expr84

def _expr85() -> TypeInfo:
    return record_type("Crypto.Mut3", [], Mut3, lambda: [("l0", bool_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut3(Record):
    l0: bool

Mut3_reflection = _expr85

def _expr86() -> TypeInfo:
    return record_type("Crypto.Mut4", [], Mut4, lambda: [("l0", string_type)])


@dataclass(eq = False, repr = False, slots = True)
class Mut4(Record):
    l0: str

Mut4_reflection = _expr86

def _expr87() -> TypeInfo:
    return record_type("Crypto.Mut5", [], Mut5, lambda: [("l0", US0_reflection())])


@dataclass(eq = False, repr = False, slots = True)
class Mut5(Record):
    l0: US0

Mut5_reflection = _expr87

def _expr88() -> TypeInfo:
    return union_type("Crypto.US1", [], US1, lambda: [[("f0_0", US0_reflection())], []])


class US1(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US1_0", "US1_1"]


US1_reflection = _expr88

def _expr89() -> TypeInfo:
    return union_type("Crypto.US2", [], US2, lambda: [[("f0_0", int64_type)], []])


class US2(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US2_0", "US2_1"]


US2_reflection = _expr89

def _expr90() -> TypeInfo:
    return union_type("Crypto.US3", [], US3, lambda: [[], [], []])


class US3(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US3_0", "US3_1", "US3_2"]


US3_reflection = _expr90

def _expr91() -> TypeInfo:
    return union_type("Crypto.US4", [], US4, lambda: [[("f0_0", US3_reflection())], [("f1_0", US3_reflection())], [("f2_0", US3_reflection())], [("f3_0", US3_reflection())], [("f4_0", US3_reflection())], [("f5_0", US3_reflection())]])


class US4(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5"]


US4_reflection = _expr91

def _expr92() -> TypeInfo:
    return union_type("Crypto.US5", [], US5, lambda: [[("f0_0", string_type)], []])


class US5(Union):
    __slots__ = ["tag", "fields"]
    def __init__(self, tag: int, *fields: Any) -> None:
        super().__init__()
        self.tag: int = tag or 0
        self.fields: Array[Any] = list(fields)

    @staticmethod
    def cases() -> list[str]:
        return ["US5_0", "US5_1"]


US5_reflection = _expr92

def method1(__unit: None=None) -> str:
    return ""


def method2(v0_1: str) -> str:
    return v0_1


def method3(v0_1: int, v1_1: Mut0) -> bool:
    return v1_1.l0 < v0_1


def method4(__unit: None=None) -> str:
    return ""


def method0(v0_1: str) -> str:
    v166: IHashlibSha256 = hashlib
    v168: Any = v166.sha256()
    v174: str = v0_1.encode("utf-8")
    v168.update(v174)
    return v168.hexdigest()


def closure0(unit_var: None, v0_1: str) -> str:
    return method0(v0_1)


def method9(v0_1: str) -> str:
    return v0_1


def method10(__unit: None=None) -> str:
    return ""


def closure4(unit_var: None, v0_1: str) -> US5:
    return US5(0, v0_1)


def method11(__unit: None=None) -> Callable[[str], US5]:
    def _arrow93(v: str) -> US5:
        return closure4(None, v)

    return _arrow93


def method8(v0_1: str) -> str:
    v34: IOsEnviron = os
    v36: Any = v34.environ
    _v41: (str | None) | None = None
    x: str | None = v36.get(v0_1)
    _v41 = some(x)
    v47: str | None
    if _v41 is None:
        raise Exception("optionm\'.of_obj / _v41=None")

    else: 
        v47 = value_2(_v41)

    v74: US5 = default_arg(map(method11(), v47), US5(1))
    if v74.tag == 0:
        return v74.fields[0]

    else: 
        return ""



def method7(__unit: None=None) -> tuple[US1, US2]:
    v1_1: str = method8("TRACE_LEVEL")
    v6: str = "Critical".lower()
    v13: str = "Warning".lower()
    v20: str = "Info".lower()
    v27: str = "Debug".lower()
    v34: str = "Verbose".lower()
    v41: US1 = US1(0, US0(0)) if ("Verbose" == v1_1) else US1(1)
    def _arrow94(__unit: None=None) -> US1:
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
                                v90: US1 = US1(0, US0(2)) if (v20 == v1_1) else US1(1)
                                if v90.tag == 0:
                                    return US1(0, v90.fields[0])

                                else: 
                                    v97: US1 = US1(0, US0(3)) if (v13 == v1_1) else US1(1)
                                    if v97.tag == 0:
                                        return US1(0, v97.fields[0])

                                    else: 
                                        v104: US1 = US1(0, US0(4)) if (v6 == v1_1) else US1(1)
                                        return US1(0, v104.fields[0]) if (v104.tag == 0) else US1(1)









    return (US1(0, v41.fields[0]) if (v41.tag == 0) else _arrow94(), US2(1) if (method8("AUTOMATION") != "True") else US2(0, from_value(ticks_1(now()), False)))


def closure5(unit_var: None, v0_1: str) -> None:
    pass


def method6(v0_1: US0) -> tuple[Mut1, Mut2, Mut3, Mut4, Mut5, int64 | None]:
    pattern_input: tuple[US1, US2] = method7()
    _run_target_args_0027_v3: tuple[US1, US2] = (pattern_input[0], pattern_input[1])
    v173: US2 = _run_target_args_0027_v3[1]
    v172: US1 = _run_target_args_0027_v3[0]
    def v179(v: str, v0_1: Any=v0_1) -> None:
        closure5(None, v)

    return (Mut1(int64(1)), Mut2(v179), Mut3(True), Mut4(""), Mut5(v172.fields[0] if (v172.tag == 0) else v0_1), v173.fields[0] if (v173.tag == 0) else None)


def closure3(unit_var: None, unit_var_1: None) -> None:
    if TraceState_trace_state() is None:
        pattern_input: tuple[Mut1, Mut2, Mut3, Mut4, Mut5, int64 | None] = method6(US0(0))
        TraceState_trace_state((pattern_input[0], pattern_input[1], pattern_input[2], pattern_input[3], pattern_input[4], pattern_input[5]))



def method5(v0_1: US0) -> bool:
    v3: None
    closure3(None, None)
    v3 = None
    pattern_input: tuple[Mut1, Mut2, Mut3, Mut4, Mut5, int64 | None] = value_2(TraceState_trace_state())
    v42: US0 = pattern_input[4].l0
    if pattern_input[2].l0 == False:
        return False

    else: 
        class ObjectExpr95:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        class ObjectExpr96:
            @property
            def Compare(self) -> Callable[[US0, US0], int]:
                return compare

        return find(v0_1, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr95())) >= find(v42, of_seq(to_enumerable([(US0(0), 0), (US0(1), 1), (US0(2), 2), (US0(3), 3), (US0(4), 4)]), ObjectExpr96()))



def closure6(unit_var: None, v0_1: int64) -> US2:
    return US2(0, v0_1)


def method13(__unit: None=None) -> Callable[[int64], US2]:
    def _arrow97(v: int64) -> US2:
        return closure6(None, v)

    return _arrow97


def method14(__unit: None=None) -> str:
    return "hh:mm:ss"


def method15(__unit: None=None) -> str:
    return "HH:mm:ss"


def method12(v0_1: Mut1, v1_1: Mut2, v2: Mut3, v3: Mut4, v4: Mut5, v5: int64 | None=None) -> str:
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


def closure7(v0_1: Mut4, v1_1: str, unit_var: None) -> None:
    v3: str = v0_1.l0 + v1_1
    v0_1.l0 = v3


def method17(v0_1: str) -> str:
    v2: Mut4 = Mut4(method18())
    v9: None
    closure7(v2, ("" + str(v0_1)) + "", None)
    v9 = None
    return v2.l0


def method19(__unit: None=None) -> str:
    return "\u001b[0m"


def method16(__unit: None=None) -> str:
    v4: str = "Verbose".lower()
    return ("\u001b[90m" + method17(v4[0])) + method19()


def method21(v0_1: int, v1_1: str, v2: uint16) -> str:
    v4: Mut4 = Mut4(method18())
    v13: None
    closure7(v4, "{ ", None)
    v13 = None
    v24: None
    closure7(v4, "first_letter_code", None)
    v24 = None
    v35: None
    closure7(v4, " = ", None)
    v35 = None
    v44: None
    closure7(v4, ("" + str(v0_1)) + "", None)
    v44 = None
    v55: None
    closure7(v4, "; ", None)
    v55 = None
    v66: None
    closure7(v4, "hash_part", None)
    v66 = None
    v75: None
    closure7(v4, " = ", None)
    v75 = None
    v84: None
    closure7(v4, v1_1, None)
    v84 = None
    v93: None
    closure7(v4, "; ", None)
    v93 = None
    v104: None
    closure7(v4, "combined_value", None)
    v104 = None
    v113: None
    closure7(v4, " = ", None)
    v113 = None
    v122: None
    closure7(v4, ("" + str(v2)) + "", None)
    v122 = None
    v133: None
    closure7(v4, " }", None)
    v133 = None
    return v4.l0


def method22(v0_1: str) -> str:
    return trim_end(trim_start(v0_1, *to_array(empty())), *to_array(of_array([" ", "/"])))


def method20(v0_1: Mut1, v1_1: Mut2, v2: Mut3, v3: Mut4, v4: Mut5, v5: int64 | None, v6: str, v7: str, v8: int, v9: str, v10: uint16) -> str:
    v11: str = method21(v8, v9, v10)
    return method22(((((((((("" + v6) + " ") + v7) + " #") + str(v0_1.l0)) + " ") + "crypto.hash_to_port") + " / ") + v11) + "")


def closure8(v0_1: Mut1, unit_var: None) -> None:
    v2: int64 = op_addition(v0_1.l0, int64(1))
    v0_1.l0 = v2


def closure10(v0_1: str, unit_var: None) -> None:
    print(v0_1)


def closure9(unit_var: None, v0_1: str) -> None:
    v3: None
    closure10(v0_1, None)
    v3 = None


def method23(v0_1: str) -> None:
    v3: None
    closure3(None, None)
    v3 = None
    pattern_input: tuple[Mut1, Mut2, Mut3, Mut4, Mut5, int64 | None] = value_2(TraceState_trace_state())
    v44: None
    closure8(pattern_input[0], None)
    v44 = None
    closure9(None, v0_1)
    pattern_input[1].l0(v0_1)


def closure2(v0_1: int, v1_1: str, v2: uint16, unit_var: None) -> None:
    if method5(US0(0)):
        v7: None
        closure3(None, None)
        v7 = None
        pattern_input: tuple[Mut1, Mut2, Mut3, Mut4, Mut5, int64 | None] = value_2(TraceState_trace_state())
        v33: int64 | None = pattern_input[5]
        v32: Mut5 = pattern_input[4]
        v31: Mut4 = pattern_input[3]
        v30: Mut3 = pattern_input[2]
        v29: Mut2 = pattern_input[1]
        v28: Mut1 = pattern_input[0]
        method23(method20(v28, v29, v30, v31, v32, v33, method12(v28, v29, v30, v31, v32, v33), method16(), v0_1, v1_1, v2))



def closure1(unit_var: None, v0_1: str) -> uint16:
    v96: int = int(char_code_at(v0_1[0], 0)) or 0
    v114: str = v0_1[0:7 + 1]
    v124: uint16
    value_1: int = (parse(v114, 511, False, 32, 16) + v96) or 0
    v124 = int(value_1+0x10000 if value_1 < 0 else value_1) & 0xFFFF
    v129: None
    closure2(v96, v114, v124, None)
    v129 = None
    return (v124 % uint16(48128)) + uint16(1024)


def _arrow98(v: str) -> str:
    return closure0(None, v)


v0: Callable[[str], str] = _arrow98

def hash_text(x: str) -> str:
    return v0(x)


def _arrow99(v: str) -> uint16:
    return closure1(None, v)


v1: Callable[[str], uint16] = _arrow99

def hash_to_port(x: str) -> uint16:
    return v1(x)


