#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::DateTime<$0>")>]
#endif
type chrono_DateTime<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::NaiveDateTime")>]
#endif
type chrono_NaiveDateTime = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("&$0")>]
type Ref<'T> = class end
#else
type Ref<'T> = 'T
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::string::String")>]
type std_string_String = class end
#else
type std_string_String = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::Utc")>]
#endif
type chrono_Utc = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::Local")>]
#endif
type chrono_Local = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("str")>]
type Str = class end
#else
type Str = string
#endif

type [<Struct>] US0 =
    | US0_0 of f0_0 : chrono_DateTime<chrono_Utc>
    | US0_1
and [<Struct>] US1 =
    | US1_0 of f0_0 : string
    | US1_1
and [<Struct>] US2 =
    | US2_0
    | US2_1
    | US2_2
and [<Struct>] US3 =
    | US3_0 of f0_0 : US2
    | US3_1 of f1_0 : US2
    | US3_2 of f2_0 : US2
    | US3_3 of f3_0 : US2
    | US3_4 of f4_0 : US2
    | US3_5 of f5_0 : US2
    | US3_6 of f6_0 : US2
let rec closure2 () (v0 : chrono_DateTime<chrono_Utc>) : US0 =
    US0_0(v0)
and method1 () : (chrono_DateTime<chrono_Utc> -> US0) =
    closure2()
and method2 () : string =
    let v0 : string = "hh:mm"
    v0
and method3 () : string =
    let v0 : string = "yyyyMMdd-HHmm-ssff-ffff-f"
    v0
and method4 () : string =
    let v0 : string = "hhmm"
    v0
and method0 (v0 : System.Guid, v1 : System.DateTime) : System.Guid =
    (* run_target_args'
    let v734 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v740 : System.DateTime = System.DateTime.UnixEpoch
    let v744 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v745 : System.DateTime = v744 v740
    let v749 : System.DateTimeKind = System.DateTimeKind.Local
    let v750 : System.DateTime = System.DateTime.SpecifyKind (v1, v749)
    let v754 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v755 : System.DateTime = v754 v750
    (* run_target_args'
    let v764 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v765 : (System.DateTime -> int64) = _.Ticks
    let v766 : int64 = v765 v755
    let _run_target_args'_v764 = v766 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v767 : (System.DateTime -> int64) = _.Ticks
    let v768 : int64 = v767 v755
    let _run_target_args'_v764 = v768 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v770 : int64 = null |> unbox<int64>
    let _run_target_args'_v764 = v770 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v773 : (System.DateTime -> int64) = _.Ticks
    let v774 : int64 = v773 v755
    let _run_target_args'_v764 = v774 
    #endif
#if FABLE_COMPILER_PYTHON
    let v775 : (System.DateTime -> int64) = _.Ticks
    let v776 : int64 = v775 v755
    let _run_target_args'_v764 = v776 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v777 : (System.DateTime -> int64) = _.Ticks
    let v778 : int64 = v777 v755
    let _run_target_args'_v764 = v778 
    #endif
#else
    let v779 : (System.DateTime -> int64) = _.Ticks
    let v780 : int64 = v779 v755
    let _run_target_args'_v764 = v780 
    #endif
    let v781 : int64 = _run_target_args'_v764 
    (* run_target_args'
    let v808 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v809 : (System.DateTime -> int64) = _.Ticks
    let v810 : int64 = v809 v745
    let _run_target_args'_v808 = v810 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v811 : (System.DateTime -> int64) = _.Ticks
    let v812 : int64 = v811 v745
    let _run_target_args'_v808 = v812 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v814 : int64 = null |> unbox<int64>
    let _run_target_args'_v808 = v814 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v817 : (System.DateTime -> int64) = _.Ticks
    let v818 : int64 = v817 v745
    let _run_target_args'_v808 = v818 
    #endif
#if FABLE_COMPILER_PYTHON
    let v819 : (System.DateTime -> int64) = _.Ticks
    let v820 : int64 = v819 v745
    let _run_target_args'_v808 = v820 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v821 : (System.DateTime -> int64) = _.Ticks
    let v822 : int64 = v821 v745
    let _run_target_args'_v808 = v822 
    #endif
#else
    let v823 : (System.DateTime -> int64) = _.Ticks
    let v824 : int64 = v823 v745
    let _run_target_args'_v808 = v824 
    #endif
    let v825 : int64 = _run_target_args'_v808 
    let v847 : int64 = v781 |> int64 
    let v851 : int64 = v825 |> int64 
    let v854 : int64 = v847 - v851
    let v855 : int64 = v854 / 10L
    let v856 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v857 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v855 v856 
    let v860 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v861 : US0 option = v857 |> Option.map v860 
    let v881 : US0 = US0_1
    let v882 : US0 = v861 |> Option.defaultValue v881 
    let v902 : US1 =
        match v882 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v886) -> (* Some *)
            let v887 : string = "$0.naive_utc()"
            let v888 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v886 v887 
            let v889 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v890 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v888 v889 
            let v891 : string = "%Y%m%d-%H%M-%S%f"
            let v892 : string = "r#\"" + v891 + "\"#"
            let v893 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v892 
            let v894 : string = "$0.format($1).to_string()"
            let v895 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v890, v893) v894 
            let v896 : string = "fable_library_rust::String_::fromString($0)"
            let v897 : string = Fable.Core.RustInterop.emitRustExpr v895 v896 
            let v898 : string = $"{v897.[0..17]}-{v897.[18..21]}-{v897.[22]}"
            US1_0(v898)
    let v906 : string =
        match v902 with
        | US1_1 -> (* None *)
            let v904 : string = ""
            v904
        | US1_0(v903) -> (* Some *)
            v903
    (* run_target_args'
    let v911 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v912 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v913 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v912 
    let _run_target_args'_v911 = v913 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v915 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v911 = v915 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v919 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v911 = v919 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v923 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v911 = v923 
    #endif
#if FABLE_COMPILER_PYTHON
    let v927 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v911 = v927 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v930 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v911 = v930 
    #endif
#else
    let v931 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v911 = v931 
    #endif
    let v932 : System.TimeZoneInfo = _run_target_args'_v911 
    (* run_target_args'
    let v948 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v955 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v956 : (System.DateTime -> int64) = _.Ticks
    let v957 : int64 = v956 v755
    let _run_target_args'_v955 = v957 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v958 : (System.DateTime -> int64) = _.Ticks
    let v959 : int64 = v958 v755
    let _run_target_args'_v955 = v959 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v961 : int64 = null |> unbox<int64>
    let _run_target_args'_v955 = v961 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v964 : (System.DateTime -> int64) = _.Ticks
    let v965 : int64 = v964 v755
    let _run_target_args'_v955 = v965 
    #endif
#if FABLE_COMPILER_PYTHON
    let v966 : (System.DateTime -> int64) = _.Ticks
    let v967 : int64 = v966 v755
    let _run_target_args'_v955 = v967 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v968 : (System.DateTime -> int64) = _.Ticks
    let v969 : int64 = v968 v755
    let _run_target_args'_v955 = v969 
    #endif
#else
    let v970 : (System.DateTime -> int64) = _.Ticks
    let v971 : int64 = v970 v755
    let _run_target_args'_v955 = v971 
    #endif
    let v972 : int64 = _run_target_args'_v955 
    let v993 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v994 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v755, v972) v993 
    let v996 : System.TimeSpan = v994 |> System.TimeSpan 
    let _run_target_args'_v948 = v996 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1005 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1006 : (System.DateTime -> int64) = _.Ticks
    let v1007 : int64 = v1006 v755
    let _run_target_args'_v1005 = v1007 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1008 : (System.DateTime -> int64) = _.Ticks
    let v1009 : int64 = v1008 v755
    let _run_target_args'_v1005 = v1009 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1011 : int64 = null |> unbox<int64>
    let _run_target_args'_v1005 = v1011 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1014 : (System.DateTime -> int64) = _.Ticks
    let v1015 : int64 = v1014 v755
    let _run_target_args'_v1005 = v1015 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1016 : (System.DateTime -> int64) = _.Ticks
    let v1017 : int64 = v1016 v755
    let _run_target_args'_v1005 = v1017 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1018 : (System.DateTime -> int64) = _.Ticks
    let v1019 : int64 = v1018 v755
    let _run_target_args'_v1005 = v1019 
    #endif
#else
    let v1020 : (System.DateTime -> int64) = _.Ticks
    let v1021 : int64 = v1020 v755
    let _run_target_args'_v1005 = v1021 
    #endif
    let v1022 : int64 = _run_target_args'_v1005 
    let v1043 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1044 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v755, v1022) v1043 
    let v1046 : System.TimeSpan = v1044 |> System.TimeSpan 
    let _run_target_args'_v948 = v1046 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1050 : US2 = US2_2
    let v1051 : US3 = US3_4(v1050)
    let v1052 : string = $"date_time.get_utc_offset / target: {v1051}"
    let v1053 : System.TimeSpan = failwith<System.TimeSpan> v1052
    let _run_target_args'_v948 = v1053 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1057 : US2 = US2_0
    let v1058 : US3 = US3_5(v1057)
    let v1059 : string = $"date_time.get_utc_offset / target: {v1058}"
    let v1060 : System.TimeSpan = failwith<System.TimeSpan> v1059
    let _run_target_args'_v948 = v1060 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1064 : US2 = US2_0
    let v1065 : US3 = US3_6(v1064)
    let v1066 : string = $"date_time.get_utc_offset / target: {v1065}"
    let v1067 : System.TimeSpan = failwith<System.TimeSpan> v1066
    let _run_target_args'_v948 = v1067 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1070 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1075 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1076 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1077 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1076 
    let _run_target_args'_v1075 = v1077 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1079 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1075 = v1079 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1083 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1075 = v1083 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1087 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1075 = v1087 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1091 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1075 = v1091 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1094 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1075 = v1094 
    #endif
#else
    let v1095 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1075 = v1095 
    #endif
    let v1096 : System.TimeZoneInfo = _run_target_args'_v1075 
    let v1105 : (System.DateTime -> System.TimeSpan) = v1070 v1096
    let v1106 : System.TimeSpan = v1105 v755
    let _run_target_args'_v948 = v1106 
    #endif
#else
    let v1107 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1112 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1113 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1114 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1113 
    let _run_target_args'_v1112 = v1114 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1116 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1112 = v1116 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1120 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1112 = v1120 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1124 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1112 = v1124 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1128 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1112 = v1128 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1131 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1112 = v1131 
    #endif
#else
    let v1132 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1112 = v1132 
    #endif
    let v1133 : System.TimeZoneInfo = _run_target_args'_v1112 
    let v1142 : (System.DateTime -> System.TimeSpan) = v1107 v1133
    let v1143 : System.TimeSpan = v1142 v755
    let _run_target_args'_v948 = v1143 
    #endif
    let v1144 : System.TimeSpan = _run_target_args'_v948 
    let v1160 : (System.TimeSpan -> int32) = _.Hours
    let v1161 : int32 = v1160 v1144
    let v1164 : bool = v1161 > 0
    let v1165 : uint8 =
        if v1164 then
            1uy
        else
            0uy
    let v1166 : string = method2()
    (* run_target_args'
    let v1237 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1238 : string = "$0.toString($1)"
    let v1239 : string = Fable.Core.RustInterop.emitRustExpr struct (v1144, v1166) v1238 
    let _run_target_args'_v1237 = v1239 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1240 : string = "$0.toString($1)"
    let v1241 : string = Fable.Core.RustInterop.emitRustExpr struct (v1144, v1166) v1240 
    let _run_target_args'_v1237 = v1241 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1242 : string = "$0.toString($1)"
    let v1243 : string = Fable.Core.RustInterop.emitRustExpr struct (v1144, v1166) v1242 
    let _run_target_args'_v1237 = v1243 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1244 : string = v1144.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1237 = v1244 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1245 : string = v1144.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1237 = v1245 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1247 : string = v1144.ToString v1166 
    let _run_target_args'_v1237 = v1247 
    #endif
#else
    let v1317 : string = v1144.ToString v1166 
    let _run_target_args'_v1237 = v1317 
    #endif
    let v1386 : string = _run_target_args'_v1237 
    let v1527 : string = $"{v1165}{v1386.[0..1]}{v1386.[3..4]}"
    let v1529 : (System.Guid -> string) = _.ToString()
    let v1530 : string = v1529 v0
    let v1533 : int32 = v906.Length
    let v1534 : int32 = v1527.Length
    let v1535 : int32 = v1533 + v1534
    let v1537 : (string -> int32) = String.length
    let v1538 : int32 = v1537 v1530
    let v1542 : int32 = 1
    let v1548 : int32 = v1535 |> int32 
    let v1561 : int32 = v1538 |> int32 
    let v1569 : int32 = v1561 - v1542
    let v1571 : string = v1530.[int v1548..int v1569]
    let v1575 : string = $"{v906}{v1527}{v1571}"
    (* run_target_args'
    let v1580 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1582 : System.Guid = v1575 |> System.Guid 
    let _run_target_args'_v1580 = v1582 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1586 : System.Guid = v1575 |> System.Guid 
    let _run_target_args'_v1580 = v1586 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1590 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1580 = v1590 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1594 : System.Guid = v1575 |> System.Guid 
    let _run_target_args'_v1580 = v1594 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1598 : System.Guid = v1575 |> System.Guid 
    let _run_target_args'_v1580 = v1598 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1602 : System.Guid = v1575 |> System.Guid 
    let _run_target_args'_v1580 = v1602 
    #endif
#else
    let v1606 : System.Guid = v1575 |> System.Guid 
    let _run_target_args'_v1580 = v1606 
    #endif
    let v1609 : System.Guid = _run_target_args'_v1580 
    let _run_target_args'_v734 = v1609 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1623 : System.DateTime = System.DateTime.UnixEpoch
    let v1627 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1628 : System.DateTime = v1627 v1623
    let v1632 : System.DateTimeKind = System.DateTimeKind.Local
    let v1633 : System.DateTime = System.DateTime.SpecifyKind (v1, v1632)
    let v1637 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1638 : System.DateTime = v1637 v1633
    (* run_target_args'
    let v1647 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1648 : (System.DateTime -> int64) = _.Ticks
    let v1649 : int64 = v1648 v1638
    let _run_target_args'_v1647 = v1649 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1650 : (System.DateTime -> int64) = _.Ticks
    let v1651 : int64 = v1650 v1638
    let _run_target_args'_v1647 = v1651 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1653 : int64 = null |> unbox<int64>
    let _run_target_args'_v1647 = v1653 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1656 : (System.DateTime -> int64) = _.Ticks
    let v1657 : int64 = v1656 v1638
    let _run_target_args'_v1647 = v1657 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1658 : (System.DateTime -> int64) = _.Ticks
    let v1659 : int64 = v1658 v1638
    let _run_target_args'_v1647 = v1659 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1660 : (System.DateTime -> int64) = _.Ticks
    let v1661 : int64 = v1660 v1638
    let _run_target_args'_v1647 = v1661 
    #endif
#else
    let v1662 : (System.DateTime -> int64) = _.Ticks
    let v1663 : int64 = v1662 v1638
    let _run_target_args'_v1647 = v1663 
    #endif
    let v1664 : int64 = _run_target_args'_v1647 
    (* run_target_args'
    let v1691 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1692 : (System.DateTime -> int64) = _.Ticks
    let v1693 : int64 = v1692 v1628
    let _run_target_args'_v1691 = v1693 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1694 : (System.DateTime -> int64) = _.Ticks
    let v1695 : int64 = v1694 v1628
    let _run_target_args'_v1691 = v1695 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1697 : int64 = null |> unbox<int64>
    let _run_target_args'_v1691 = v1697 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1700 : (System.DateTime -> int64) = _.Ticks
    let v1701 : int64 = v1700 v1628
    let _run_target_args'_v1691 = v1701 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1702 : (System.DateTime -> int64) = _.Ticks
    let v1703 : int64 = v1702 v1628
    let _run_target_args'_v1691 = v1703 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1704 : (System.DateTime -> int64) = _.Ticks
    let v1705 : int64 = v1704 v1628
    let _run_target_args'_v1691 = v1705 
    #endif
#else
    let v1706 : (System.DateTime -> int64) = _.Ticks
    let v1707 : int64 = v1706 v1628
    let _run_target_args'_v1691 = v1707 
    #endif
    let v1708 : int64 = _run_target_args'_v1691 
    let v1730 : int64 = v1664 |> int64 
    let v1734 : int64 = v1708 |> int64 
    let v1737 : int64 = v1730 - v1734
    let v1738 : int64 = v1737 / 10L
    let v1739 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1740 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1738 v1739 
    let v1743 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v1744 : US0 option = v1740 |> Option.map v1743 
    let v1764 : US0 = US0_1
    let v1765 : US0 = v1744 |> Option.defaultValue v1764 
    let v1785 : US1 =
        match v1765 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v1769) -> (* Some *)
            let v1770 : string = "$0.naive_utc()"
            let v1771 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1769 v1770 
            let v1772 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1773 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1771 v1772 
            let v1774 : string = "%Y%m%d-%H%M-%S%f"
            let v1775 : string = "r#\"" + v1774 + "\"#"
            let v1776 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1775 
            let v1777 : string = "$0.format($1).to_string()"
            let v1778 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1773, v1776) v1777 
            let v1779 : string = "fable_library_rust::String_::fromString($0)"
            let v1780 : string = Fable.Core.RustInterop.emitRustExpr v1778 v1779 
            let v1781 : string = $"{v1780.[0..17]}-{v1780.[18..21]}-{v1780.[22]}"
            US1_0(v1781)
    let v1789 : string =
        match v1785 with
        | US1_1 -> (* None *)
            let v1787 : string = ""
            v1787
        | US1_0(v1786) -> (* Some *)
            v1786
    (* run_target_args'
    let v1794 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1795 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1796 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1795 
    let _run_target_args'_v1794 = v1796 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1798 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1794 = v1798 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1802 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1794 = v1802 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1806 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1794 = v1806 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1810 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1794 = v1810 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1813 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1794 = v1813 
    #endif
#else
    let v1814 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1794 = v1814 
    #endif
    let v1815 : System.TimeZoneInfo = _run_target_args'_v1794 
    (* run_target_args'
    let v1831 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1838 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1839 : (System.DateTime -> int64) = _.Ticks
    let v1840 : int64 = v1839 v1638
    let _run_target_args'_v1838 = v1840 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1841 : (System.DateTime -> int64) = _.Ticks
    let v1842 : int64 = v1841 v1638
    let _run_target_args'_v1838 = v1842 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1844 : int64 = null |> unbox<int64>
    let _run_target_args'_v1838 = v1844 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1847 : (System.DateTime -> int64) = _.Ticks
    let v1848 : int64 = v1847 v1638
    let _run_target_args'_v1838 = v1848 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1849 : (System.DateTime -> int64) = _.Ticks
    let v1850 : int64 = v1849 v1638
    let _run_target_args'_v1838 = v1850 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1851 : (System.DateTime -> int64) = _.Ticks
    let v1852 : int64 = v1851 v1638
    let _run_target_args'_v1838 = v1852 
    #endif
#else
    let v1853 : (System.DateTime -> int64) = _.Ticks
    let v1854 : int64 = v1853 v1638
    let _run_target_args'_v1838 = v1854 
    #endif
    let v1855 : int64 = _run_target_args'_v1838 
    let v1876 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1877 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1638, v1855) v1876 
    let v1879 : System.TimeSpan = v1877 |> System.TimeSpan 
    let _run_target_args'_v1831 = v1879 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1888 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1889 : (System.DateTime -> int64) = _.Ticks
    let v1890 : int64 = v1889 v1638
    let _run_target_args'_v1888 = v1890 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1891 : (System.DateTime -> int64) = _.Ticks
    let v1892 : int64 = v1891 v1638
    let _run_target_args'_v1888 = v1892 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1894 : int64 = null |> unbox<int64>
    let _run_target_args'_v1888 = v1894 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1897 : (System.DateTime -> int64) = _.Ticks
    let v1898 : int64 = v1897 v1638
    let _run_target_args'_v1888 = v1898 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1899 : (System.DateTime -> int64) = _.Ticks
    let v1900 : int64 = v1899 v1638
    let _run_target_args'_v1888 = v1900 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1901 : (System.DateTime -> int64) = _.Ticks
    let v1902 : int64 = v1901 v1638
    let _run_target_args'_v1888 = v1902 
    #endif
#else
    let v1903 : (System.DateTime -> int64) = _.Ticks
    let v1904 : int64 = v1903 v1638
    let _run_target_args'_v1888 = v1904 
    #endif
    let v1905 : int64 = _run_target_args'_v1888 
    let v1926 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1927 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1638, v1905) v1926 
    let v1929 : System.TimeSpan = v1927 |> System.TimeSpan 
    let _run_target_args'_v1831 = v1929 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1933 : US2 = US2_2
    let v1934 : US3 = US3_4(v1933)
    let v1935 : string = $"date_time.get_utc_offset / target: {v1934}"
    let v1936 : System.TimeSpan = failwith<System.TimeSpan> v1935
    let _run_target_args'_v1831 = v1936 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1940 : US2 = US2_0
    let v1941 : US3 = US3_5(v1940)
    let v1942 : string = $"date_time.get_utc_offset / target: {v1941}"
    let v1943 : System.TimeSpan = failwith<System.TimeSpan> v1942
    let _run_target_args'_v1831 = v1943 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1947 : US2 = US2_0
    let v1948 : US3 = US3_6(v1947)
    let v1949 : string = $"date_time.get_utc_offset / target: {v1948}"
    let v1950 : System.TimeSpan = failwith<System.TimeSpan> v1949
    let _run_target_args'_v1831 = v1950 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1953 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1958 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1959 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1960 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1959 
    let _run_target_args'_v1958 = v1960 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1962 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1958 = v1962 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1966 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1958 = v1966 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1970 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1958 = v1970 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1974 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1958 = v1974 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1977 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1958 = v1977 
    #endif
#else
    let v1978 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1958 = v1978 
    #endif
    let v1979 : System.TimeZoneInfo = _run_target_args'_v1958 
    let v1988 : (System.DateTime -> System.TimeSpan) = v1953 v1979
    let v1989 : System.TimeSpan = v1988 v1638
    let _run_target_args'_v1831 = v1989 
    #endif
#else
    let v1990 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1995 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1996 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1997 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1996 
    let _run_target_args'_v1995 = v1997 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1999 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1995 = v1999 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2003 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1995 = v2003 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2007 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1995 = v2007 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2011 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1995 = v2011 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2014 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1995 = v2014 
    #endif
#else
    let v2015 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1995 = v2015 
    #endif
    let v2016 : System.TimeZoneInfo = _run_target_args'_v1995 
    let v2025 : (System.DateTime -> System.TimeSpan) = v1990 v2016
    let v2026 : System.TimeSpan = v2025 v1638
    let _run_target_args'_v1831 = v2026 
    #endif
    let v2027 : System.TimeSpan = _run_target_args'_v1831 
    let v2043 : (System.TimeSpan -> int32) = _.Hours
    let v2044 : int32 = v2043 v2027
    let v2047 : bool = v2044 > 0
    let v2048 : uint8 =
        if v2047 then
            1uy
        else
            0uy
    let v2049 : string = method2()
    (* run_target_args'
    let v2120 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2121 : string = "$0.toString($1)"
    let v2122 : string = Fable.Core.RustInterop.emitRustExpr struct (v2027, v2049) v2121 
    let _run_target_args'_v2120 = v2122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2123 : string = "$0.toString($1)"
    let v2124 : string = Fable.Core.RustInterop.emitRustExpr struct (v2027, v2049) v2123 
    let _run_target_args'_v2120 = v2124 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2125 : string = "$0.toString($1)"
    let v2126 : string = Fable.Core.RustInterop.emitRustExpr struct (v2027, v2049) v2125 
    let _run_target_args'_v2120 = v2126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2127 : string = v2027.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2120 = v2127 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2128 : string = v2027.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2120 = v2128 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2130 : string = v2027.ToString v2049 
    let _run_target_args'_v2120 = v2130 
    #endif
#else
    let v2200 : string = v2027.ToString v2049 
    let _run_target_args'_v2120 = v2200 
    #endif
    let v2269 : string = _run_target_args'_v2120 
    let v2410 : string = $"{v2048}{v2269.[0..1]}{v2269.[3..4]}"
    let v2412 : (System.Guid -> string) = _.ToString()
    let v2413 : string = v2412 v0
    let v2416 : int32 = v1789.Length
    let v2417 : int32 = v2410.Length
    let v2418 : int32 = v2416 + v2417
    let v2420 : (string -> int32) = String.length
    let v2421 : int32 = v2420 v2413
    let v2425 : int32 = 1
    let v2431 : int32 = v2418 |> int32 
    let v2444 : int32 = v2421 |> int32 
    let v2452 : int32 = v2444 - v2425
    let v2454 : string = v2413.[int v2431..int v2452]
    let v2458 : string = $"{v1789}{v2410}{v2454}"
    (* run_target_args'
    let v2463 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2465 : System.Guid = v2458 |> System.Guid 
    let _run_target_args'_v2463 = v2465 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2469 : System.Guid = v2458 |> System.Guid 
    let _run_target_args'_v2463 = v2469 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2473 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2463 = v2473 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2477 : System.Guid = v2458 |> System.Guid 
    let _run_target_args'_v2463 = v2477 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2481 : System.Guid = v2458 |> System.Guid 
    let _run_target_args'_v2463 = v2481 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2485 : System.Guid = v2458 |> System.Guid 
    let _run_target_args'_v2463 = v2485 
    #endif
#else
    let v2489 : System.Guid = v2458 |> System.Guid 
    let _run_target_args'_v2463 = v2489 
    #endif
    let v2492 : System.Guid = _run_target_args'_v2463 
    let _run_target_args'_v734 = v2492 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2502 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v734 = v2502 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2505 : string = method3()
    let v2506 : bool = v2505 = ""
    let v2508 : string =
        if v2506 then
            let v2507 : string = "M-d-y hh:mm:ss tt"
            v2507
        else
            v2505
    let v2509 : (string -> string) = v1.ToString
    let v2510 : string = v2509 v2508
    (* run_target_args'
    let v2529 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2530 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2531 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2530 
    let _run_target_args'_v2529 = v2531 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2533 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2529 = v2533 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2537 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2529 = v2537 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2541 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2529 = v2541 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2545 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2529 = v2545 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2548 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2529 = v2548 
    #endif
#else
    let v2549 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2529 = v2549 
    #endif
    let v2550 : System.TimeZoneInfo = _run_target_args'_v2529 
    (* run_target_args'
    let v2566 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2573 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2574 : (System.DateTime -> int64) = _.Ticks
    let v2575 : int64 = v2574 v1
    let _run_target_args'_v2573 = v2575 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2576 : (System.DateTime -> int64) = _.Ticks
    let v2577 : int64 = v2576 v1
    let _run_target_args'_v2573 = v2577 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2579 : int64 = null |> unbox<int64>
    let _run_target_args'_v2573 = v2579 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2582 : (System.DateTime -> int64) = _.Ticks
    let v2583 : int64 = v2582 v1
    let _run_target_args'_v2573 = v2583 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2584 : (System.DateTime -> int64) = _.Ticks
    let v2585 : int64 = v2584 v1
    let _run_target_args'_v2573 = v2585 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2586 : (System.DateTime -> int64) = _.Ticks
    let v2587 : int64 = v2586 v1
    let _run_target_args'_v2573 = v2587 
    #endif
#else
    let v2588 : (System.DateTime -> int64) = _.Ticks
    let v2589 : int64 = v2588 v1
    let _run_target_args'_v2573 = v2589 
    #endif
    let v2590 : int64 = _run_target_args'_v2573 
    let v2611 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2612 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2590) v2611 
    let v2614 : System.TimeSpan = v2612 |> System.TimeSpan 
    let _run_target_args'_v2566 = v2614 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2623 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2624 : (System.DateTime -> int64) = _.Ticks
    let v2625 : int64 = v2624 v1
    let _run_target_args'_v2623 = v2625 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2626 : (System.DateTime -> int64) = _.Ticks
    let v2627 : int64 = v2626 v1
    let _run_target_args'_v2623 = v2627 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2629 : int64 = null |> unbox<int64>
    let _run_target_args'_v2623 = v2629 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2632 : (System.DateTime -> int64) = _.Ticks
    let v2633 : int64 = v2632 v1
    let _run_target_args'_v2623 = v2633 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2634 : (System.DateTime -> int64) = _.Ticks
    let v2635 : int64 = v2634 v1
    let _run_target_args'_v2623 = v2635 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2636 : (System.DateTime -> int64) = _.Ticks
    let v2637 : int64 = v2636 v1
    let _run_target_args'_v2623 = v2637 
    #endif
#else
    let v2638 : (System.DateTime -> int64) = _.Ticks
    let v2639 : int64 = v2638 v1
    let _run_target_args'_v2623 = v2639 
    #endif
    let v2640 : int64 = _run_target_args'_v2623 
    let v2661 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2662 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2640) v2661 
    let v2664 : System.TimeSpan = v2662 |> System.TimeSpan 
    let _run_target_args'_v2566 = v2664 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2668 : US2 = US2_2
    let v2669 : US3 = US3_4(v2668)
    let v2670 : string = $"date_time.get_utc_offset / target: {v2669}"
    let v2671 : System.TimeSpan = failwith<System.TimeSpan> v2670
    let _run_target_args'_v2566 = v2671 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2675 : US2 = US2_0
    let v2676 : US3 = US3_5(v2675)
    let v2677 : string = $"date_time.get_utc_offset / target: {v2676}"
    let v2678 : System.TimeSpan = failwith<System.TimeSpan> v2677
    let _run_target_args'_v2566 = v2678 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2682 : US2 = US2_0
    let v2683 : US3 = US3_6(v2682)
    let v2684 : string = $"date_time.get_utc_offset / target: {v2683}"
    let v2685 : System.TimeSpan = failwith<System.TimeSpan> v2684
    let _run_target_args'_v2566 = v2685 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2688 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2693 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2694 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2695 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2694 
    let _run_target_args'_v2693 = v2695 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2697 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2693 = v2697 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2701 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2693 = v2701 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2705 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2693 = v2705 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2709 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2693 = v2709 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2712 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2693 = v2712 
    #endif
#else
    let v2713 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2693 = v2713 
    #endif
    let v2714 : System.TimeZoneInfo = _run_target_args'_v2693 
    let v2723 : (System.DateTime -> System.TimeSpan) = v2688 v2714
    let v2724 : System.TimeSpan = v2723 v1
    let _run_target_args'_v2566 = v2724 
    #endif
#else
    let v2725 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2730 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2731 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2732 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2731 
    let _run_target_args'_v2730 = v2732 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2734 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2730 = v2734 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2738 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2730 = v2738 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2742 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2730 = v2742 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2746 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2730 = v2746 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2749 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2730 = v2749 
    #endif
#else
    let v2750 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2730 = v2750 
    #endif
    let v2751 : System.TimeZoneInfo = _run_target_args'_v2730 
    let v2760 : (System.DateTime -> System.TimeSpan) = v2725 v2751
    let v2761 : System.TimeSpan = v2760 v1
    let _run_target_args'_v2566 = v2761 
    #endif
    let v2762 : System.TimeSpan = _run_target_args'_v2566 
    let v2778 : (System.TimeSpan -> int32) = _.Hours
    let v2779 : int32 = v2778 v2762
    let v2782 : bool = v2779 > 0
    let v2783 : uint8 =
        if v2782 then
            1uy
        else
            0uy
    let v2784 : string = method4()
    (* run_target_args'
    let v2855 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2856 : string = "$0.toString($1)"
    let v2857 : string = Fable.Core.RustInterop.emitRustExpr struct (v2762, v2784) v2856 
    let _run_target_args'_v2855 = v2857 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2858 : string = "$0.toString($1)"
    let v2859 : string = Fable.Core.RustInterop.emitRustExpr struct (v2762, v2784) v2858 
    let _run_target_args'_v2855 = v2859 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2860 : string = "$0.toString($1)"
    let v2861 : string = Fable.Core.RustInterop.emitRustExpr struct (v2762, v2784) v2860 
    let _run_target_args'_v2855 = v2861 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2862 : string = v2762.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2855 = v2862 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2863 : string = v2762.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2855 = v2863 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2865 : string = v2762.ToString v2784 
    let _run_target_args'_v2855 = v2865 
    #endif
#else
    let v2935 : string = v2762.ToString v2784 
    let _run_target_args'_v2855 = v2935 
    #endif
    let v3004 : string = _run_target_args'_v2855 
    let v3145 : string = $"{v2783}{v3004}"
    let v3147 : (System.Guid -> string) = _.ToString()
    let v3148 : string = v3147 v0
    let v3151 : int32 = v2510.Length
    let v3152 : int32 = v3145.Length
    let v3153 : int32 = v3151 + v3152
    let v3155 : (string -> int32) = String.length
    let v3156 : int32 = v3155 v3148
    let v3160 : int32 = 1
    let v3166 : int32 = v3153 |> int32 
    let v3179 : int32 = v3156 |> int32 
    let v3187 : int32 = v3179 - v3160
    let v3189 : string = v3148.[int v3166..int v3187]
    let v3193 : string = $"{v2510}{v3145}{v3189}"
    (* run_target_args'
    let v3198 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3200 : System.Guid = v3193 |> System.Guid 
    let _run_target_args'_v3198 = v3200 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3204 : System.Guid = v3193 |> System.Guid 
    let _run_target_args'_v3198 = v3204 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3208 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3198 = v3208 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3212 : System.Guid = v3193 |> System.Guid 
    let _run_target_args'_v3198 = v3212 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3216 : System.Guid = v3193 |> System.Guid 
    let _run_target_args'_v3198 = v3216 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3220 : System.Guid = v3193 |> System.Guid 
    let _run_target_args'_v3198 = v3220 
    #endif
#else
    let v3224 : System.Guid = v3193 |> System.Guid 
    let _run_target_args'_v3198 = v3224 
    #endif
    let v3227 : System.Guid = _run_target_args'_v3198 
    let _run_target_args'_v734 = v3227 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3236 : string = method3()
    let v3237 : bool = v3236 = ""
    let v3239 : string =
        if v3237 then
            let v3238 : string = "M-d-y hh:mm:ss tt"
            v3238
        else
            v3236
    let v3240 : (string -> string) = v1.ToString
    let v3241 : string = v3240 v3239
    (* run_target_args'
    let v3260 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3261 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3262 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3261 
    let _run_target_args'_v3260 = v3262 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3264 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3260 = v3264 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3268 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3260 = v3268 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3272 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3260 = v3272 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3276 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3260 = v3276 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3279 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3260 = v3279 
    #endif
#else
    let v3280 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3260 = v3280 
    #endif
    let v3281 : System.TimeZoneInfo = _run_target_args'_v3260 
    (* run_target_args'
    let v3297 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3304 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3305 : (System.DateTime -> int64) = _.Ticks
    let v3306 : int64 = v3305 v1
    let _run_target_args'_v3304 = v3306 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3307 : (System.DateTime -> int64) = _.Ticks
    let v3308 : int64 = v3307 v1
    let _run_target_args'_v3304 = v3308 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3310 : int64 = null |> unbox<int64>
    let _run_target_args'_v3304 = v3310 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3313 : (System.DateTime -> int64) = _.Ticks
    let v3314 : int64 = v3313 v1
    let _run_target_args'_v3304 = v3314 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3315 : (System.DateTime -> int64) = _.Ticks
    let v3316 : int64 = v3315 v1
    let _run_target_args'_v3304 = v3316 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3317 : (System.DateTime -> int64) = _.Ticks
    let v3318 : int64 = v3317 v1
    let _run_target_args'_v3304 = v3318 
    #endif
#else
    let v3319 : (System.DateTime -> int64) = _.Ticks
    let v3320 : int64 = v3319 v1
    let _run_target_args'_v3304 = v3320 
    #endif
    let v3321 : int64 = _run_target_args'_v3304 
    let v3342 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3343 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3321) v3342 
    let v3345 : System.TimeSpan = v3343 |> System.TimeSpan 
    let _run_target_args'_v3297 = v3345 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3354 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3355 : (System.DateTime -> int64) = _.Ticks
    let v3356 : int64 = v3355 v1
    let _run_target_args'_v3354 = v3356 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3357 : (System.DateTime -> int64) = _.Ticks
    let v3358 : int64 = v3357 v1
    let _run_target_args'_v3354 = v3358 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3360 : int64 = null |> unbox<int64>
    let _run_target_args'_v3354 = v3360 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3363 : (System.DateTime -> int64) = _.Ticks
    let v3364 : int64 = v3363 v1
    let _run_target_args'_v3354 = v3364 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3365 : (System.DateTime -> int64) = _.Ticks
    let v3366 : int64 = v3365 v1
    let _run_target_args'_v3354 = v3366 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3367 : (System.DateTime -> int64) = _.Ticks
    let v3368 : int64 = v3367 v1
    let _run_target_args'_v3354 = v3368 
    #endif
#else
    let v3369 : (System.DateTime -> int64) = _.Ticks
    let v3370 : int64 = v3369 v1
    let _run_target_args'_v3354 = v3370 
    #endif
    let v3371 : int64 = _run_target_args'_v3354 
    let v3392 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3393 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3371) v3392 
    let v3395 : System.TimeSpan = v3393 |> System.TimeSpan 
    let _run_target_args'_v3297 = v3395 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3399 : US2 = US2_2
    let v3400 : US3 = US3_4(v3399)
    let v3401 : string = $"date_time.get_utc_offset / target: {v3400}"
    let v3402 : System.TimeSpan = failwith<System.TimeSpan> v3401
    let _run_target_args'_v3297 = v3402 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3406 : US2 = US2_0
    let v3407 : US3 = US3_5(v3406)
    let v3408 : string = $"date_time.get_utc_offset / target: {v3407}"
    let v3409 : System.TimeSpan = failwith<System.TimeSpan> v3408
    let _run_target_args'_v3297 = v3409 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3413 : US2 = US2_0
    let v3414 : US3 = US3_6(v3413)
    let v3415 : string = $"date_time.get_utc_offset / target: {v3414}"
    let v3416 : System.TimeSpan = failwith<System.TimeSpan> v3415
    let _run_target_args'_v3297 = v3416 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3419 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3424 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3425 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3426 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3425 
    let _run_target_args'_v3424 = v3426 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3428 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3424 = v3428 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3432 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3424 = v3432 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3436 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3424 = v3436 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3440 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3424 = v3440 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3443 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3424 = v3443 
    #endif
#else
    let v3444 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3424 = v3444 
    #endif
    let v3445 : System.TimeZoneInfo = _run_target_args'_v3424 
    let v3454 : (System.DateTime -> System.TimeSpan) = v3419 v3445
    let v3455 : System.TimeSpan = v3454 v1
    let _run_target_args'_v3297 = v3455 
    #endif
#else
    let v3456 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3461 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3462 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3463 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3462 
    let _run_target_args'_v3461 = v3463 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3465 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3461 = v3465 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3469 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3461 = v3469 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3473 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3461 = v3473 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3477 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3461 = v3477 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3480 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3461 = v3480 
    #endif
#else
    let v3481 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3461 = v3481 
    #endif
    let v3482 : System.TimeZoneInfo = _run_target_args'_v3461 
    let v3491 : (System.DateTime -> System.TimeSpan) = v3456 v3482
    let v3492 : System.TimeSpan = v3491 v1
    let _run_target_args'_v3297 = v3492 
    #endif
    let v3493 : System.TimeSpan = _run_target_args'_v3297 
    let v3509 : (System.TimeSpan -> int32) = _.Hours
    let v3510 : int32 = v3509 v3493
    let v3513 : bool = v3510 > 0
    let v3514 : uint8 =
        if v3513 then
            1uy
        else
            0uy
    let v3515 : string = method4()
    (* run_target_args'
    let v3586 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3587 : string = "$0.toString($1)"
    let v3588 : string = Fable.Core.RustInterop.emitRustExpr struct (v3493, v3515) v3587 
    let _run_target_args'_v3586 = v3588 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3589 : string = "$0.toString($1)"
    let v3590 : string = Fable.Core.RustInterop.emitRustExpr struct (v3493, v3515) v3589 
    let _run_target_args'_v3586 = v3590 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3591 : string = "$0.toString($1)"
    let v3592 : string = Fable.Core.RustInterop.emitRustExpr struct (v3493, v3515) v3591 
    let _run_target_args'_v3586 = v3592 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3593 : string = v3493.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3586 = v3593 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3594 : string = v3493.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3586 = v3594 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3596 : string = v3493.ToString v3515 
    let _run_target_args'_v3586 = v3596 
    #endif
#else
    let v3666 : string = v3493.ToString v3515 
    let _run_target_args'_v3586 = v3666 
    #endif
    let v3735 : string = _run_target_args'_v3586 
    let v3876 : string = $"{v3514}{v3735}"
    let v3878 : (System.Guid -> string) = _.ToString()
    let v3879 : string = v3878 v0
    let v3882 : int32 = v3241.Length
    let v3883 : int32 = v3876.Length
    let v3884 : int32 = v3882 + v3883
    let v3886 : (string -> int32) = String.length
    let v3887 : int32 = v3886 v3879
    let v3891 : int32 = 1
    let v3897 : int32 = v3884 |> int32 
    let v3910 : int32 = v3887 |> int32 
    let v3918 : int32 = v3910 - v3891
    let v3920 : string = v3879.[int v3897..int v3918]
    let v3924 : string = $"{v3241}{v3876}{v3920}"
    (* run_target_args'
    let v3929 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3931 : System.Guid = v3924 |> System.Guid 
    let _run_target_args'_v3929 = v3931 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3935 : System.Guid = v3924 |> System.Guid 
    let _run_target_args'_v3929 = v3935 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3939 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3929 = v3939 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3943 : System.Guid = v3924 |> System.Guid 
    let _run_target_args'_v3929 = v3943 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3947 : System.Guid = v3924 |> System.Guid 
    let _run_target_args'_v3929 = v3947 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3951 : System.Guid = v3924 |> System.Guid 
    let _run_target_args'_v3929 = v3951 
    #endif
#else
    let v3955 : System.Guid = v3924 |> System.Guid 
    let _run_target_args'_v3929 = v3955 
    #endif
    let v3958 : System.Guid = _run_target_args'_v3929 
    let _run_target_args'_v734 = v3958 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3967 : string = method3()
    let v3968 : bool = v3967 = ""
    let v3970 : string =
        if v3968 then
            let v3969 : string = "M-d-y hh:mm:ss tt"
            v3969
        else
            v3967
    let v3971 : (string -> string) = v1.ToString
    let v3972 : string = v3971 v3970
    (* run_target_args'
    let v3991 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3992 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3993 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3992 
    let _run_target_args'_v3991 = v3993 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3995 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3991 = v3995 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3999 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3991 = v3999 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4003 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3991 = v4003 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4007 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3991 = v4007 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4010 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3991 = v4010 
    #endif
#else
    let v4011 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3991 = v4011 
    #endif
    let v4012 : System.TimeZoneInfo = _run_target_args'_v3991 
    (* run_target_args'
    let v4028 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v4035 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4036 : (System.DateTime -> int64) = _.Ticks
    let v4037 : int64 = v4036 v1
    let _run_target_args'_v4035 = v4037 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4038 : (System.DateTime -> int64) = _.Ticks
    let v4039 : int64 = v4038 v1
    let _run_target_args'_v4035 = v4039 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4041 : int64 = null |> unbox<int64>
    let _run_target_args'_v4035 = v4041 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4044 : (System.DateTime -> int64) = _.Ticks
    let v4045 : int64 = v4044 v1
    let _run_target_args'_v4035 = v4045 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4046 : (System.DateTime -> int64) = _.Ticks
    let v4047 : int64 = v4046 v1
    let _run_target_args'_v4035 = v4047 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4048 : (System.DateTime -> int64) = _.Ticks
    let v4049 : int64 = v4048 v1
    let _run_target_args'_v4035 = v4049 
    #endif
#else
    let v4050 : (System.DateTime -> int64) = _.Ticks
    let v4051 : int64 = v4050 v1
    let _run_target_args'_v4035 = v4051 
    #endif
    let v4052 : int64 = _run_target_args'_v4035 
    let v4073 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4074 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4052) v4073 
    let v4076 : System.TimeSpan = v4074 |> System.TimeSpan 
    let _run_target_args'_v4028 = v4076 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4085 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4086 : (System.DateTime -> int64) = _.Ticks
    let v4087 : int64 = v4086 v1
    let _run_target_args'_v4085 = v4087 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4088 : (System.DateTime -> int64) = _.Ticks
    let v4089 : int64 = v4088 v1
    let _run_target_args'_v4085 = v4089 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4091 : int64 = null |> unbox<int64>
    let _run_target_args'_v4085 = v4091 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4094 : (System.DateTime -> int64) = _.Ticks
    let v4095 : int64 = v4094 v1
    let _run_target_args'_v4085 = v4095 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4096 : (System.DateTime -> int64) = _.Ticks
    let v4097 : int64 = v4096 v1
    let _run_target_args'_v4085 = v4097 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4098 : (System.DateTime -> int64) = _.Ticks
    let v4099 : int64 = v4098 v1
    let _run_target_args'_v4085 = v4099 
    #endif
#else
    let v4100 : (System.DateTime -> int64) = _.Ticks
    let v4101 : int64 = v4100 v1
    let _run_target_args'_v4085 = v4101 
    #endif
    let v4102 : int64 = _run_target_args'_v4085 
    let v4123 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4124 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4102) v4123 
    let v4126 : System.TimeSpan = v4124 |> System.TimeSpan 
    let _run_target_args'_v4028 = v4126 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4130 : US2 = US2_2
    let v4131 : US3 = US3_4(v4130)
    let v4132 : string = $"date_time.get_utc_offset / target: {v4131}"
    let v4133 : System.TimeSpan = failwith<System.TimeSpan> v4132
    let _run_target_args'_v4028 = v4133 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4137 : US2 = US2_0
    let v4138 : US3 = US3_5(v4137)
    let v4139 : string = $"date_time.get_utc_offset / target: {v4138}"
    let v4140 : System.TimeSpan = failwith<System.TimeSpan> v4139
    let _run_target_args'_v4028 = v4140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4144 : US2 = US2_0
    let v4145 : US3 = US3_6(v4144)
    let v4146 : string = $"date_time.get_utc_offset / target: {v4145}"
    let v4147 : System.TimeSpan = failwith<System.TimeSpan> v4146
    let _run_target_args'_v4028 = v4147 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4150 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4155 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4156 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4157 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4156 
    let _run_target_args'_v4155 = v4157 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4159 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4155 = v4159 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4163 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4155 = v4163 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4167 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4155 = v4167 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4171 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4155 = v4171 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4174 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4155 = v4174 
    #endif
#else
    let v4175 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4155 = v4175 
    #endif
    let v4176 : System.TimeZoneInfo = _run_target_args'_v4155 
    let v4185 : (System.DateTime -> System.TimeSpan) = v4150 v4176
    let v4186 : System.TimeSpan = v4185 v1
    let _run_target_args'_v4028 = v4186 
    #endif
#else
    let v4187 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4192 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4193 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4194 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4193 
    let _run_target_args'_v4192 = v4194 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4196 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4192 = v4196 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4200 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4192 = v4200 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4204 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4192 = v4204 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4208 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4192 = v4208 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4211 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4192 = v4211 
    #endif
#else
    let v4212 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4192 = v4212 
    #endif
    let v4213 : System.TimeZoneInfo = _run_target_args'_v4192 
    let v4222 : (System.DateTime -> System.TimeSpan) = v4187 v4213
    let v4223 : System.TimeSpan = v4222 v1
    let _run_target_args'_v4028 = v4223 
    #endif
    let v4224 : System.TimeSpan = _run_target_args'_v4028 
    let v4240 : (System.TimeSpan -> int32) = _.Hours
    let v4241 : int32 = v4240 v4224
    let v4244 : bool = v4241 > 0
    let v4245 : uint8 =
        if v4244 then
            1uy
        else
            0uy
    let v4246 : string = method4()
    (* run_target_args'
    let v4317 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4318 : string = "$0.toString($1)"
    let v4319 : string = Fable.Core.RustInterop.emitRustExpr struct (v4224, v4246) v4318 
    let _run_target_args'_v4317 = v4319 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4320 : string = "$0.toString($1)"
    let v4321 : string = Fable.Core.RustInterop.emitRustExpr struct (v4224, v4246) v4320 
    let _run_target_args'_v4317 = v4321 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4322 : string = "$0.toString($1)"
    let v4323 : string = Fable.Core.RustInterop.emitRustExpr struct (v4224, v4246) v4322 
    let _run_target_args'_v4317 = v4323 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4324 : string = v4224.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4317 = v4324 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4325 : string = v4224.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4317 = v4325 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4327 : string = v4224.ToString v4246 
    let _run_target_args'_v4317 = v4327 
    #endif
#else
    let v4397 : string = v4224.ToString v4246 
    let _run_target_args'_v4317 = v4397 
    #endif
    let v4466 : string = _run_target_args'_v4317 
    let v4607 : string = $"{v4245}{v4466}"
    let v4609 : (System.Guid -> string) = _.ToString()
    let v4610 : string = v4609 v0
    let v4613 : int32 = v3972.Length
    let v4614 : int32 = v4607.Length
    let v4615 : int32 = v4613 + v4614
    let v4617 : (string -> int32) = String.length
    let v4618 : int32 = v4617 v4610
    let v4622 : int32 = 1
    let v4628 : int32 = v4615 |> int32 
    let v4641 : int32 = v4618 |> int32 
    let v4649 : int32 = v4641 - v4622
    let v4651 : string = v4610.[int v4628..int v4649]
    let v4655 : string = $"{v3972}{v4607}{v4651}"
    (* run_target_args'
    let v4660 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4662 : System.Guid = v4655 |> System.Guid 
    let _run_target_args'_v4660 = v4662 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4666 : System.Guid = v4655 |> System.Guid 
    let _run_target_args'_v4660 = v4666 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4670 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4660 = v4670 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4674 : System.Guid = v4655 |> System.Guid 
    let _run_target_args'_v4660 = v4674 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4678 : System.Guid = v4655 |> System.Guid 
    let _run_target_args'_v4660 = v4678 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4682 : System.Guid = v4655 |> System.Guid 
    let _run_target_args'_v4660 = v4682 
    #endif
#else
    let v4686 : System.Guid = v4655 |> System.Guid 
    let _run_target_args'_v4660 = v4686 
    #endif
    let v4689 : System.Guid = _run_target_args'_v4660 
    let _run_target_args'_v734 = v4689 
    #endif
#else
    let v4698 : string = method3()
    let v4699 : bool = v4698 = ""
    let v4701 : string =
        if v4699 then
            let v4700 : string = "M-d-y hh:mm:ss tt"
            v4700
        else
            v4698
    let v4702 : (string -> string) = v1.ToString
    let v4703 : string = v4702 v4701
    (* run_target_args'
    let v4722 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4723 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4724 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4723 
    let _run_target_args'_v4722 = v4724 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4726 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4722 = v4726 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4730 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4722 = v4730 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4734 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4722 = v4734 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4738 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4722 = v4738 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4741 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4722 = v4741 
    #endif
#else
    let v4742 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4722 = v4742 
    #endif
    let v4743 : System.TimeZoneInfo = _run_target_args'_v4722 
    (* run_target_args'
    let v4759 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v4766 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4767 : (System.DateTime -> int64) = _.Ticks
    let v4768 : int64 = v4767 v1
    let _run_target_args'_v4766 = v4768 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4769 : (System.DateTime -> int64) = _.Ticks
    let v4770 : int64 = v4769 v1
    let _run_target_args'_v4766 = v4770 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4772 : int64 = null |> unbox<int64>
    let _run_target_args'_v4766 = v4772 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4775 : (System.DateTime -> int64) = _.Ticks
    let v4776 : int64 = v4775 v1
    let _run_target_args'_v4766 = v4776 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4777 : (System.DateTime -> int64) = _.Ticks
    let v4778 : int64 = v4777 v1
    let _run_target_args'_v4766 = v4778 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4779 : (System.DateTime -> int64) = _.Ticks
    let v4780 : int64 = v4779 v1
    let _run_target_args'_v4766 = v4780 
    #endif
#else
    let v4781 : (System.DateTime -> int64) = _.Ticks
    let v4782 : int64 = v4781 v1
    let _run_target_args'_v4766 = v4782 
    #endif
    let v4783 : int64 = _run_target_args'_v4766 
    let v4804 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4805 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4783) v4804 
    let v4807 : System.TimeSpan = v4805 |> System.TimeSpan 
    let _run_target_args'_v4759 = v4807 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4816 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4817 : (System.DateTime -> int64) = _.Ticks
    let v4818 : int64 = v4817 v1
    let _run_target_args'_v4816 = v4818 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4819 : (System.DateTime -> int64) = _.Ticks
    let v4820 : int64 = v4819 v1
    let _run_target_args'_v4816 = v4820 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4822 : int64 = null |> unbox<int64>
    let _run_target_args'_v4816 = v4822 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4825 : (System.DateTime -> int64) = _.Ticks
    let v4826 : int64 = v4825 v1
    let _run_target_args'_v4816 = v4826 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4827 : (System.DateTime -> int64) = _.Ticks
    let v4828 : int64 = v4827 v1
    let _run_target_args'_v4816 = v4828 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4829 : (System.DateTime -> int64) = _.Ticks
    let v4830 : int64 = v4829 v1
    let _run_target_args'_v4816 = v4830 
    #endif
#else
    let v4831 : (System.DateTime -> int64) = _.Ticks
    let v4832 : int64 = v4831 v1
    let _run_target_args'_v4816 = v4832 
    #endif
    let v4833 : int64 = _run_target_args'_v4816 
    let v4854 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4855 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4833) v4854 
    let v4857 : System.TimeSpan = v4855 |> System.TimeSpan 
    let _run_target_args'_v4759 = v4857 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4861 : US2 = US2_2
    let v4862 : US3 = US3_4(v4861)
    let v4863 : string = $"date_time.get_utc_offset / target: {v4862}"
    let v4864 : System.TimeSpan = failwith<System.TimeSpan> v4863
    let _run_target_args'_v4759 = v4864 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4868 : US2 = US2_0
    let v4869 : US3 = US3_5(v4868)
    let v4870 : string = $"date_time.get_utc_offset / target: {v4869}"
    let v4871 : System.TimeSpan = failwith<System.TimeSpan> v4870
    let _run_target_args'_v4759 = v4871 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4875 : US2 = US2_0
    let v4876 : US3 = US3_6(v4875)
    let v4877 : string = $"date_time.get_utc_offset / target: {v4876}"
    let v4878 : System.TimeSpan = failwith<System.TimeSpan> v4877
    let _run_target_args'_v4759 = v4878 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4881 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4886 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4887 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4888 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4887 
    let _run_target_args'_v4886 = v4888 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4890 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4886 = v4890 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4894 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4886 = v4894 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4898 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4886 = v4898 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4902 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4886 = v4902 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4905 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4886 = v4905 
    #endif
#else
    let v4906 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4886 = v4906 
    #endif
    let v4907 : System.TimeZoneInfo = _run_target_args'_v4886 
    let v4916 : (System.DateTime -> System.TimeSpan) = v4881 v4907
    let v4917 : System.TimeSpan = v4916 v1
    let _run_target_args'_v4759 = v4917 
    #endif
#else
    let v4918 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4923 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4924 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4925 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4924 
    let _run_target_args'_v4923 = v4925 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4927 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4923 = v4927 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4931 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4923 = v4931 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4935 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4923 = v4935 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4939 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4923 = v4939 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4942 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4923 = v4942 
    #endif
#else
    let v4943 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4923 = v4943 
    #endif
    let v4944 : System.TimeZoneInfo = _run_target_args'_v4923 
    let v4953 : (System.DateTime -> System.TimeSpan) = v4918 v4944
    let v4954 : System.TimeSpan = v4953 v1
    let _run_target_args'_v4759 = v4954 
    #endif
    let v4955 : System.TimeSpan = _run_target_args'_v4759 
    let v4971 : (System.TimeSpan -> int32) = _.Hours
    let v4972 : int32 = v4971 v4955
    let v4975 : bool = v4972 > 0
    let v4976 : uint8 =
        if v4975 then
            1uy
        else
            0uy
    let v4977 : string = method4()
    (* run_target_args'
    let v5048 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5049 : string = "$0.toString($1)"
    let v5050 : string = Fable.Core.RustInterop.emitRustExpr struct (v4955, v4977) v5049 
    let _run_target_args'_v5048 = v5050 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5051 : string = "$0.toString($1)"
    let v5052 : string = Fable.Core.RustInterop.emitRustExpr struct (v4955, v4977) v5051 
    let _run_target_args'_v5048 = v5052 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5053 : string = "$0.toString($1)"
    let v5054 : string = Fable.Core.RustInterop.emitRustExpr struct (v4955, v4977) v5053 
    let _run_target_args'_v5048 = v5054 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5055 : string = v4955.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v5048 = v5055 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5056 : string = v4955.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v5048 = v5056 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5058 : string = v4955.ToString v4977 
    let _run_target_args'_v5048 = v5058 
    #endif
#else
    let v5128 : string = v4955.ToString v4977 
    let _run_target_args'_v5048 = v5128 
    #endif
    let v5197 : string = _run_target_args'_v5048 
    let v5338 : string = $"{v4976}{v5197}"
    let v5340 : (System.Guid -> string) = _.ToString()
    let v5341 : string = v5340 v0
    let v5344 : int32 = v4703.Length
    let v5345 : int32 = v5338.Length
    let v5346 : int32 = v5344 + v5345
    let v5348 : (string -> int32) = String.length
    let v5349 : int32 = v5348 v5341
    let v5353 : int32 = 1
    let v5359 : int32 = v5346 |> int32 
    let v5372 : int32 = v5349 |> int32 
    let v5380 : int32 = v5372 - v5353
    let v5382 : string = v5341.[int v5359..int v5380]
    let v5386 : string = $"{v4703}{v5338}{v5382}"
    (* run_target_args'
    let v5391 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5393 : System.Guid = v5386 |> System.Guid 
    let _run_target_args'_v5391 = v5393 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5397 : System.Guid = v5386 |> System.Guid 
    let _run_target_args'_v5391 = v5397 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5401 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v5391 = v5401 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5405 : System.Guid = v5386 |> System.Guid 
    let _run_target_args'_v5391 = v5405 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5409 : System.Guid = v5386 |> System.Guid 
    let _run_target_args'_v5391 = v5409 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5413 : System.Guid = v5386 |> System.Guid 
    let _run_target_args'_v5391 = v5413 
    #endif
#else
    let v5417 : System.Guid = v5386 |> System.Guid 
    let _run_target_args'_v5391 = v5417 
    #endif
    let v5420 : System.Guid = _run_target_args'_v5391 
    let _run_target_args'_v734 = v5420 
    #endif
    let v5429 : System.Guid = _run_target_args'_v734 
    v5429
and closure1 (v0 : System.Guid) (v1 : System.DateTime) : System.Guid =
    method0(v0, v1)
and closure0 () (v0 : System.Guid) : (System.DateTime -> System.Guid) =
    closure1(v0)
and closure4 () (v0 : string) : string =
    let v1 : string = "-"
    let v2 : string = ""
    let v3 : string = v0.Replace (v1, v2)
    v3
and closure3 () (v0 : System.Guid) : System.DateTime =
    let v2 : (System.Guid -> string) = _.ToString()
    let v3 : string = v2 v0
    let v6 : (string -> string) = closure4()
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : System.DateTime = System.DateTime.Parse (v3.[..24] |> v6)
    let _run_target_args'_v8 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v10 : System.DateTime = System.DateTime.Parse (v3.[..24] |> v6)
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v11 : System.DateTime = System.DateTime.Parse (v3.[..24] |> v6)
    let _run_target_args'_v8 = v11 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : System.DateTime = System.DateTime.Parse (v3.[..24] |> v6)
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_PYTHON
    let v13 : System.DateTime = System.DateTime.ParseExact (v3.[..24] |> v6, "yyyyMMddHHmmssfffffff", null)
    let _run_target_args'_v8 = v13 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v14 : System.DateTime = System.DateTime.ParseExact (v3.[..24] |> v6, "yyyyMMddHHmmssfffffff", null)
    let _run_target_args'_v8 = v14 
    #endif
#else
    let v15 : System.DateTime = System.DateTime.ParseExact (v3.[..24] |> v6, "yyyyMMddHHmmssfffffff", null)
    let _run_target_args'_v8 = v15 
    #endif
    let v16 : System.DateTime = _run_target_args'_v8 
    v16
and closure7 (v0 : int32, v1 : string, v2 : int32) (v3 : string) : string =
    let v4 : bool = v2 >= v0
    if v4 then
        v3
    else
        let v5 : int32 = v2 + 1
        let v6 : (string -> string) = method5(v0, v1, v5)
        let v8 : string = v3 + v1 
        v6 v8
and method5 (v0 : int32, v1 : string, v2 : int32) : (string -> string) =
    closure7(v0, v1, v2)
and closure6 (v0 : System.Guid) (v1 : int64) : System.Guid =
    let v3 : (System.Guid -> string) = _.ToString()
    let v4 : string = v3 v0
    let v8 : (int64 -> string) = _.ToString()
    let v9 : string = v8 v1
    let v13 : (char -> string) = _.ToString()
    let v14 : string = v13 '0'
    let v17 : int32 = v9.Length
    let v18 : int32 = 18 - v17
    let v19 : int32 = 0
    let v20 : (string -> string) = method5(v18, v14, v19)
    let v21 : string = ""
    let v22 : string = v20 v21
    let v24 : string = v22 + v9 
    let v27 : System.Guid = System.Guid $"{v24.[0..7]}-{v24.[8..11]}-{v24.[12..15]}-{v24.[16..17]}{v4.[21..]}"
    v27
and closure5 () (v0 : System.Guid) : (int64 -> System.Guid) =
    closure6(v0)
and closure8 () (v0 : System.Guid) : int64 =
    let v2 : (System.Guid -> string) = _.ToString()
    let v3 : string = v2 v0
    let v6 : int64 = int64 $"{v3.[0..7]}{v3.[9..12]}{v3.[14..17]}{v3.[19..20]}"
    v6
and closure9 () (v0 : System.DateTime) : System.Guid =
    let v2 : (unit -> System.Guid) = System.Guid.NewGuid
    let v3 : System.Guid = v2 ()
    method0(v3, v0)
and closure10 () (v0 : int64) : System.Guid =
    let v2 : (unit -> System.Guid) = System.Guid.NewGuid
    let v3 : System.Guid = v2 ()
    let v7 : (System.Guid -> string) = _.ToString()
    let v8 : string = v7 v3
    let v12 : (int64 -> string) = _.ToString()
    let v13 : string = v12 v0
    let v17 : (char -> string) = _.ToString()
    let v18 : string = v17 '0'
    let v21 : int32 = v13.Length
    let v22 : int32 = 18 - v21
    let v23 : int32 = 0
    let v24 : (string -> string) = method5(v22, v18, v23)
    let v25 : string = ""
    let v26 : string = v24 v25
    let v28 : string = v26 + v13 
    let v31 : System.Guid = System.Guid $"{v28.[0..7]}-{v28.[8..11]}-{v28.[12..15]}-{v28.[16..17]}{v8.[21..]}"
    v31
and closure12 (v0 : string) (v1 : System.DateTime) : string =
    let v2 : bool = v0 = ""
    let v4 : string =
        if v2 then
            let v3 : string = "M-d-y hh:mm:ss tt"
            v3
        else
            v0
    let v5 : (string -> string) = v1.ToString
    v5 v4
and closure11 () (v0 : string) : (System.DateTime -> string) =
    closure12(v0)
and closure13 () (v0 : System.DateTime) : string =
    let v2 : (string -> string) = v0.ToString
    let v3 : string = "yyyy-MM-ddTHH-mm-ss.fff"
    v2 v3
let v0 : (System.Guid -> (System.DateTime -> System.Guid)) = closure0()
let date_time_guid_from_date_time x = v0 x
let v1 : (System.Guid -> System.DateTime) = closure3()
let date_time_from_guid x = v1 x
let v2 : (System.Guid -> (int64 -> System.Guid)) = closure5()
let timestamp_guid_from_timestamp x = v2 x
let v3 : (System.Guid -> int64) = closure8()
let timestamp_from_guid x = v3 x
let v4 : (System.DateTime -> System.Guid) = closure9()
let new_guid_from_date_time x = v4 x
let v5 : (int64 -> System.Guid) = closure10()
let new_guid_from_timestamp x = v5 x
let v6 : (string -> (System.DateTime -> string)) = closure11()
let format x = v6 x
let v7 : (System.DateTime -> string) = closure13()
let format_iso8601 x = v7 x
()
