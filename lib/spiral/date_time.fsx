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
    let v741 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v747 : System.DateTime = System.DateTime.UnixEpoch
    let v751 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v752 : System.DateTime = v751 v747
    let v756 : System.DateTimeKind = System.DateTimeKind.Local
    let v757 : System.DateTime = System.DateTime.SpecifyKind (v1, v756)
    let v761 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v762 : System.DateTime = v761 v757
    (* run_target_args'
    let v771 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v772 : (System.DateTime -> int64) = _.Ticks
    let v773 : int64 = v772 v762
    let _run_target_args'_v771 = v773 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v774 : (System.DateTime -> int64) = _.Ticks
    let v775 : int64 = v774 v762
    let _run_target_args'_v771 = v775 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v777 : int64 = null |> unbox<int64>
    let _run_target_args'_v771 = v777 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v780 : (System.DateTime -> int64) = _.Ticks
    let v781 : int64 = v780 v762
    let _run_target_args'_v771 = v781 
    #endif
#if FABLE_COMPILER_PYTHON
    let v782 : (System.DateTime -> int64) = _.Ticks
    let v783 : int64 = v782 v762
    let _run_target_args'_v771 = v783 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v784 : (System.DateTime -> int64) = _.Ticks
    let v785 : int64 = v784 v762
    let _run_target_args'_v771 = v785 
    #endif
#else
    let v786 : (System.DateTime -> int64) = _.Ticks
    let v787 : int64 = v786 v762
    let _run_target_args'_v771 = v787 
    #endif
    let v788 : int64 = _run_target_args'_v771 
    (* run_target_args'
    let v815 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v816 : (System.DateTime -> int64) = _.Ticks
    let v817 : int64 = v816 v752
    let _run_target_args'_v815 = v817 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v818 : (System.DateTime -> int64) = _.Ticks
    let v819 : int64 = v818 v752
    let _run_target_args'_v815 = v819 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v821 : int64 = null |> unbox<int64>
    let _run_target_args'_v815 = v821 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v824 : (System.DateTime -> int64) = _.Ticks
    let v825 : int64 = v824 v752
    let _run_target_args'_v815 = v825 
    #endif
#if FABLE_COMPILER_PYTHON
    let v826 : (System.DateTime -> int64) = _.Ticks
    let v827 : int64 = v826 v752
    let _run_target_args'_v815 = v827 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v828 : (System.DateTime -> int64) = _.Ticks
    let v829 : int64 = v828 v752
    let _run_target_args'_v815 = v829 
    #endif
#else
    let v830 : (System.DateTime -> int64) = _.Ticks
    let v831 : int64 = v830 v752
    let _run_target_args'_v815 = v831 
    #endif
    let v832 : int64 = _run_target_args'_v815 
    let v854 : int64 = v788 |> int64 
    let v858 : int64 = v832 |> int64 
    let v861 : int64 = v854 - v858
    let v862 : int64 = v861 / 10L
    let v863 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v864 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v862 v863 
    let v867 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v868 : US0 option = v864 |> Option.map v867 
    let v888 : US0 = US0_1
    let v889 : US0 = v868 |> Option.defaultValue v888 
    let v909 : US1 =
        match v889 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v893) -> (* Some *)
            let v894 : string = "$0.naive_utc()"
            let v895 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v893 v894 
            let v896 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v897 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v895 v896 
            let v898 : string = "%Y%m%d-%H%M-%S%f"
            let v899 : string = "r#\"" + v898 + "\"#"
            let v900 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v899 
            let v901 : string = "$0.format($1).to_string()"
            let v902 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v897, v900) v901 
            let v903 : string = "fable_library_rust::String_::fromString($0)"
            let v904 : string = Fable.Core.RustInterop.emitRustExpr v902 v903 
            let v905 : string = $"{v904.[0..17]}-{v904.[18..21]}-{v904.[22]}"
            US1_0(v905)
    let v913 : string =
        match v909 with
        | US1_1 -> (* None *)
            let v911 : string = ""
            v911
        | US1_0(v910) -> (* Some *)
            v910
    (* run_target_args'
    let v918 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v919 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v920 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v919 
    let _run_target_args'_v918 = v920 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v922 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v918 = v922 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v926 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v918 = v926 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v930 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v918 = v930 
    #endif
#if FABLE_COMPILER_PYTHON
    let v934 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v918 = v934 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v937 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v918 = v937 
    #endif
#else
    let v938 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v918 = v938 
    #endif
    let v939 : System.TimeZoneInfo = _run_target_args'_v918 
    (* run_target_args'
    let v955 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v962 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v963 : (System.DateTime -> int64) = _.Ticks
    let v964 : int64 = v963 v762
    let _run_target_args'_v962 = v964 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v965 : (System.DateTime -> int64) = _.Ticks
    let v966 : int64 = v965 v762
    let _run_target_args'_v962 = v966 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v968 : int64 = null |> unbox<int64>
    let _run_target_args'_v962 = v968 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v971 : (System.DateTime -> int64) = _.Ticks
    let v972 : int64 = v971 v762
    let _run_target_args'_v962 = v972 
    #endif
#if FABLE_COMPILER_PYTHON
    let v973 : (System.DateTime -> int64) = _.Ticks
    let v974 : int64 = v973 v762
    let _run_target_args'_v962 = v974 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v975 : (System.DateTime -> int64) = _.Ticks
    let v976 : int64 = v975 v762
    let _run_target_args'_v962 = v976 
    #endif
#else
    let v977 : (System.DateTime -> int64) = _.Ticks
    let v978 : int64 = v977 v762
    let _run_target_args'_v962 = v978 
    #endif
    let v979 : int64 = _run_target_args'_v962 
    let v1000 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1001 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v762, v979) v1000 
    let v1003 : System.TimeSpan = v1001 |> System.TimeSpan 
    let _run_target_args'_v955 = v1003 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1012 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1013 : (System.DateTime -> int64) = _.Ticks
    let v1014 : int64 = v1013 v762
    let _run_target_args'_v1012 = v1014 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1015 : (System.DateTime -> int64) = _.Ticks
    let v1016 : int64 = v1015 v762
    let _run_target_args'_v1012 = v1016 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1018 : int64 = null |> unbox<int64>
    let _run_target_args'_v1012 = v1018 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1021 : (System.DateTime -> int64) = _.Ticks
    let v1022 : int64 = v1021 v762
    let _run_target_args'_v1012 = v1022 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1023 : (System.DateTime -> int64) = _.Ticks
    let v1024 : int64 = v1023 v762
    let _run_target_args'_v1012 = v1024 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1025 : (System.DateTime -> int64) = _.Ticks
    let v1026 : int64 = v1025 v762
    let _run_target_args'_v1012 = v1026 
    #endif
#else
    let v1027 : (System.DateTime -> int64) = _.Ticks
    let v1028 : int64 = v1027 v762
    let _run_target_args'_v1012 = v1028 
    #endif
    let v1029 : int64 = _run_target_args'_v1012 
    let v1050 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1051 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v762, v1029) v1050 
    let v1053 : System.TimeSpan = v1051 |> System.TimeSpan 
    let _run_target_args'_v955 = v1053 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1057 : US2 = US2_2
    let v1058 : US3 = US3_4(v1057)
    let v1059 : string = $"date_time.get_utc_offset / target: {v1058}"
    let v1060 : System.TimeSpan = failwith<System.TimeSpan> v1059
    let _run_target_args'_v955 = v1060 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1064 : US2 = US2_0
    let v1065 : US3 = US3_5(v1064)
    let v1066 : string = $"date_time.get_utc_offset / target: {v1065}"
    let v1067 : System.TimeSpan = failwith<System.TimeSpan> v1066
    let _run_target_args'_v955 = v1067 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1071 : US2 = US2_0
    let v1072 : US3 = US3_6(v1071)
    let v1073 : string = $"date_time.get_utc_offset / target: {v1072}"
    let v1074 : System.TimeSpan = failwith<System.TimeSpan> v1073
    let _run_target_args'_v955 = v1074 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1077 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1082 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1083 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1084 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1083 
    let _run_target_args'_v1082 = v1084 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1086 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1082 = v1086 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1090 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1082 = v1090 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1094 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1082 = v1094 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1098 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1082 = v1098 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1101 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1082 = v1101 
    #endif
#else
    let v1102 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1082 = v1102 
    #endif
    let v1103 : System.TimeZoneInfo = _run_target_args'_v1082 
    let v1112 : (System.DateTime -> System.TimeSpan) = v1077 v1103
    let v1113 : System.TimeSpan = v1112 v762
    let _run_target_args'_v955 = v1113 
    #endif
#else
    let v1114 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1119 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1120 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1121 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1120 
    let _run_target_args'_v1119 = v1121 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1123 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1119 = v1123 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1127 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1119 = v1127 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1131 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1119 = v1131 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1135 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1119 = v1135 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1138 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1119 = v1138 
    #endif
#else
    let v1139 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1119 = v1139 
    #endif
    let v1140 : System.TimeZoneInfo = _run_target_args'_v1119 
    let v1149 : (System.DateTime -> System.TimeSpan) = v1114 v1140
    let v1150 : System.TimeSpan = v1149 v762
    let _run_target_args'_v955 = v1150 
    #endif
    let v1151 : System.TimeSpan = _run_target_args'_v955 
    let v1167 : (System.TimeSpan -> int32) = _.Hours
    let v1168 : int32 = v1167 v1151
    let v1171 : bool = v1168 > 0
    let v1172 : uint8 =
        if v1171 then
            1uy
        else
            0uy
    let v1173 : string = method2()
    (* run_target_args'
    let v1244 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1245 : string = "$0.toString($1)"
    let v1246 : string = Fable.Core.RustInterop.emitRustExpr struct (v1151, v1173) v1245 
    let _run_target_args'_v1244 = v1246 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1247 : string = "$0.toString($1)"
    let v1248 : string = Fable.Core.RustInterop.emitRustExpr struct (v1151, v1173) v1247 
    let _run_target_args'_v1244 = v1248 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1249 : string = "$0.toString($1)"
    let v1250 : string = Fable.Core.RustInterop.emitRustExpr struct (v1151, v1173) v1249 
    let _run_target_args'_v1244 = v1250 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1251 : string = v1151.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1244 = v1251 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1252 : string = v1151.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1244 = v1252 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1254 : string = v1151.ToString v1173 
    let _run_target_args'_v1244 = v1254 
    #endif
#else
    let v1324 : string = v1151.ToString v1173 
    let _run_target_args'_v1244 = v1324 
    #endif
    let v1393 : string = _run_target_args'_v1244 
    let v1534 : string = $"{v1172}{v1393.[0..1]}{v1393.[3..4]}"
    let v1536 : (System.Guid -> string) = _.ToString()
    let v1537 : string = v1536 v0
    let v1540 : int32 = v913.Length
    let v1541 : int32 = v1534.Length
    let v1542 : int32 = v1540 + v1541
    let v1544 : (string -> int32) = String.length
    let v1545 : int32 = v1544 v1537
    let v1549 : int32 = 1
    let v1555 : int32 = v1542 |> int32 
    let v1568 : int32 = v1545 |> int32 
    let v1576 : int32 = v1568 - v1549
    let v1578 : string = v1537.[int v1555..int v1576]
    let v1582 : string = $"{v913}{v1534}{v1578}"
    (* run_target_args'
    let v1587 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1589 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1589 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1593 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1593 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1597 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1587 = v1597 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1601 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1601 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1605 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1605 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1609 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1609 
    #endif
#else
    let v1613 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1613 
    #endif
    let v1616 : System.Guid = _run_target_args'_v1587 
    let _run_target_args'_v741 = v1616 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1630 : System.DateTime = System.DateTime.UnixEpoch
    let v1634 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1635 : System.DateTime = v1634 v1630
    let v1639 : System.DateTimeKind = System.DateTimeKind.Local
    let v1640 : System.DateTime = System.DateTime.SpecifyKind (v1, v1639)
    let v1644 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1645 : System.DateTime = v1644 v1640
    (* run_target_args'
    let v1654 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1655 : (System.DateTime -> int64) = _.Ticks
    let v1656 : int64 = v1655 v1645
    let _run_target_args'_v1654 = v1656 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1657 : (System.DateTime -> int64) = _.Ticks
    let v1658 : int64 = v1657 v1645
    let _run_target_args'_v1654 = v1658 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1660 : int64 = null |> unbox<int64>
    let _run_target_args'_v1654 = v1660 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1663 : (System.DateTime -> int64) = _.Ticks
    let v1664 : int64 = v1663 v1645
    let _run_target_args'_v1654 = v1664 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1665 : (System.DateTime -> int64) = _.Ticks
    let v1666 : int64 = v1665 v1645
    let _run_target_args'_v1654 = v1666 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1667 : (System.DateTime -> int64) = _.Ticks
    let v1668 : int64 = v1667 v1645
    let _run_target_args'_v1654 = v1668 
    #endif
#else
    let v1669 : (System.DateTime -> int64) = _.Ticks
    let v1670 : int64 = v1669 v1645
    let _run_target_args'_v1654 = v1670 
    #endif
    let v1671 : int64 = _run_target_args'_v1654 
    (* run_target_args'
    let v1698 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1699 : (System.DateTime -> int64) = _.Ticks
    let v1700 : int64 = v1699 v1635
    let _run_target_args'_v1698 = v1700 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1701 : (System.DateTime -> int64) = _.Ticks
    let v1702 : int64 = v1701 v1635
    let _run_target_args'_v1698 = v1702 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1704 : int64 = null |> unbox<int64>
    let _run_target_args'_v1698 = v1704 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1707 : (System.DateTime -> int64) = _.Ticks
    let v1708 : int64 = v1707 v1635
    let _run_target_args'_v1698 = v1708 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1709 : (System.DateTime -> int64) = _.Ticks
    let v1710 : int64 = v1709 v1635
    let _run_target_args'_v1698 = v1710 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1711 : (System.DateTime -> int64) = _.Ticks
    let v1712 : int64 = v1711 v1635
    let _run_target_args'_v1698 = v1712 
    #endif
#else
    let v1713 : (System.DateTime -> int64) = _.Ticks
    let v1714 : int64 = v1713 v1635
    let _run_target_args'_v1698 = v1714 
    #endif
    let v1715 : int64 = _run_target_args'_v1698 
    let v1737 : int64 = v1671 |> int64 
    let v1741 : int64 = v1715 |> int64 
    let v1744 : int64 = v1737 - v1741
    let v1745 : int64 = v1744 / 10L
    let v1746 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1747 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1745 v1746 
    let v1750 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v1751 : US0 option = v1747 |> Option.map v1750 
    let v1771 : US0 = US0_1
    let v1772 : US0 = v1751 |> Option.defaultValue v1771 
    let v1792 : US1 =
        match v1772 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v1776) -> (* Some *)
            let v1777 : string = "$0.naive_utc()"
            let v1778 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1776 v1777 
            let v1779 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1780 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1778 v1779 
            let v1781 : string = "%Y%m%d-%H%M-%S%f"
            let v1782 : string = "r#\"" + v1781 + "\"#"
            let v1783 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1782 
            let v1784 : string = "$0.format($1).to_string()"
            let v1785 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1780, v1783) v1784 
            let v1786 : string = "fable_library_rust::String_::fromString($0)"
            let v1787 : string = Fable.Core.RustInterop.emitRustExpr v1785 v1786 
            let v1788 : string = $"{v1787.[0..17]}-{v1787.[18..21]}-{v1787.[22]}"
            US1_0(v1788)
    let v1796 : string =
        match v1792 with
        | US1_1 -> (* None *)
            let v1794 : string = ""
            v1794
        | US1_0(v1793) -> (* Some *)
            v1793
    (* run_target_args'
    let v1801 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1802 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1803 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1802 
    let _run_target_args'_v1801 = v1803 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1805 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1801 = v1805 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1809 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1801 = v1809 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1813 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1801 = v1813 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1817 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1801 = v1817 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1820 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1801 = v1820 
    #endif
#else
    let v1821 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1801 = v1821 
    #endif
    let v1822 : System.TimeZoneInfo = _run_target_args'_v1801 
    (* run_target_args'
    let v1838 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1845 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1846 : (System.DateTime -> int64) = _.Ticks
    let v1847 : int64 = v1846 v1645
    let _run_target_args'_v1845 = v1847 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1848 : (System.DateTime -> int64) = _.Ticks
    let v1849 : int64 = v1848 v1645
    let _run_target_args'_v1845 = v1849 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1851 : int64 = null |> unbox<int64>
    let _run_target_args'_v1845 = v1851 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1854 : (System.DateTime -> int64) = _.Ticks
    let v1855 : int64 = v1854 v1645
    let _run_target_args'_v1845 = v1855 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1856 : (System.DateTime -> int64) = _.Ticks
    let v1857 : int64 = v1856 v1645
    let _run_target_args'_v1845 = v1857 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1858 : (System.DateTime -> int64) = _.Ticks
    let v1859 : int64 = v1858 v1645
    let _run_target_args'_v1845 = v1859 
    #endif
#else
    let v1860 : (System.DateTime -> int64) = _.Ticks
    let v1861 : int64 = v1860 v1645
    let _run_target_args'_v1845 = v1861 
    #endif
    let v1862 : int64 = _run_target_args'_v1845 
    let v1883 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1884 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1645, v1862) v1883 
    let v1886 : System.TimeSpan = v1884 |> System.TimeSpan 
    let _run_target_args'_v1838 = v1886 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1895 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1896 : (System.DateTime -> int64) = _.Ticks
    let v1897 : int64 = v1896 v1645
    let _run_target_args'_v1895 = v1897 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1898 : (System.DateTime -> int64) = _.Ticks
    let v1899 : int64 = v1898 v1645
    let _run_target_args'_v1895 = v1899 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1901 : int64 = null |> unbox<int64>
    let _run_target_args'_v1895 = v1901 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1904 : (System.DateTime -> int64) = _.Ticks
    let v1905 : int64 = v1904 v1645
    let _run_target_args'_v1895 = v1905 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1906 : (System.DateTime -> int64) = _.Ticks
    let v1907 : int64 = v1906 v1645
    let _run_target_args'_v1895 = v1907 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1908 : (System.DateTime -> int64) = _.Ticks
    let v1909 : int64 = v1908 v1645
    let _run_target_args'_v1895 = v1909 
    #endif
#else
    let v1910 : (System.DateTime -> int64) = _.Ticks
    let v1911 : int64 = v1910 v1645
    let _run_target_args'_v1895 = v1911 
    #endif
    let v1912 : int64 = _run_target_args'_v1895 
    let v1933 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1934 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1645, v1912) v1933 
    let v1936 : System.TimeSpan = v1934 |> System.TimeSpan 
    let _run_target_args'_v1838 = v1936 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1940 : US2 = US2_2
    let v1941 : US3 = US3_4(v1940)
    let v1942 : string = $"date_time.get_utc_offset / target: {v1941}"
    let v1943 : System.TimeSpan = failwith<System.TimeSpan> v1942
    let _run_target_args'_v1838 = v1943 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1947 : US2 = US2_0
    let v1948 : US3 = US3_5(v1947)
    let v1949 : string = $"date_time.get_utc_offset / target: {v1948}"
    let v1950 : System.TimeSpan = failwith<System.TimeSpan> v1949
    let _run_target_args'_v1838 = v1950 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1954 : US2 = US2_0
    let v1955 : US3 = US3_6(v1954)
    let v1956 : string = $"date_time.get_utc_offset / target: {v1955}"
    let v1957 : System.TimeSpan = failwith<System.TimeSpan> v1956
    let _run_target_args'_v1838 = v1957 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1960 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1965 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1966 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1967 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1966 
    let _run_target_args'_v1965 = v1967 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1969 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1965 = v1969 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1973 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1965 = v1973 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1977 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1965 = v1977 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1981 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1965 = v1981 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1984 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1965 = v1984 
    #endif
#else
    let v1985 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1965 = v1985 
    #endif
    let v1986 : System.TimeZoneInfo = _run_target_args'_v1965 
    let v1995 : (System.DateTime -> System.TimeSpan) = v1960 v1986
    let v1996 : System.TimeSpan = v1995 v1645
    let _run_target_args'_v1838 = v1996 
    #endif
#else
    let v1997 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2002 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2003 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2004 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2003 
    let _run_target_args'_v2002 = v2004 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2006 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2002 = v2006 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2010 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2002 = v2010 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2014 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2002 = v2014 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2018 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2002 = v2018 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2021 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2002 = v2021 
    #endif
#else
    let v2022 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2002 = v2022 
    #endif
    let v2023 : System.TimeZoneInfo = _run_target_args'_v2002 
    let v2032 : (System.DateTime -> System.TimeSpan) = v1997 v2023
    let v2033 : System.TimeSpan = v2032 v1645
    let _run_target_args'_v1838 = v2033 
    #endif
    let v2034 : System.TimeSpan = _run_target_args'_v1838 
    let v2050 : (System.TimeSpan -> int32) = _.Hours
    let v2051 : int32 = v2050 v2034
    let v2054 : bool = v2051 > 0
    let v2055 : uint8 =
        if v2054 then
            1uy
        else
            0uy
    let v2056 : string = method2()
    (* run_target_args'
    let v2127 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2128 : string = "$0.toString($1)"
    let v2129 : string = Fable.Core.RustInterop.emitRustExpr struct (v2034, v2056) v2128 
    let _run_target_args'_v2127 = v2129 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2130 : string = "$0.toString($1)"
    let v2131 : string = Fable.Core.RustInterop.emitRustExpr struct (v2034, v2056) v2130 
    let _run_target_args'_v2127 = v2131 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2132 : string = "$0.toString($1)"
    let v2133 : string = Fable.Core.RustInterop.emitRustExpr struct (v2034, v2056) v2132 
    let _run_target_args'_v2127 = v2133 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2134 : string = v2034.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2127 = v2134 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2135 : string = v2034.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2127 = v2135 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2137 : string = v2034.ToString v2056 
    let _run_target_args'_v2127 = v2137 
    #endif
#else
    let v2207 : string = v2034.ToString v2056 
    let _run_target_args'_v2127 = v2207 
    #endif
    let v2276 : string = _run_target_args'_v2127 
    let v2417 : string = $"{v2055}{v2276.[0..1]}{v2276.[3..4]}"
    let v2419 : (System.Guid -> string) = _.ToString()
    let v2420 : string = v2419 v0
    let v2423 : int32 = v1796.Length
    let v2424 : int32 = v2417.Length
    let v2425 : int32 = v2423 + v2424
    let v2427 : (string -> int32) = String.length
    let v2428 : int32 = v2427 v2420
    let v2432 : int32 = 1
    let v2438 : int32 = v2425 |> int32 
    let v2451 : int32 = v2428 |> int32 
    let v2459 : int32 = v2451 - v2432
    let v2461 : string = v2420.[int v2438..int v2459]
    let v2465 : string = $"{v1796}{v2417}{v2461}"
    (* run_target_args'
    let v2470 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2472 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2472 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2476 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2476 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2480 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2470 = v2480 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2484 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2484 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2488 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2488 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2492 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2492 
    #endif
#else
    let v2496 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2496 
    #endif
    let v2499 : System.Guid = _run_target_args'_v2470 
    let _run_target_args'_v741 = v2499 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2509 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v741 = v2509 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2512 : string = method3()
    let v2523 : bool = v2512 = ""
    let v2525 : string =
        if v2523 then
            let v2524 : string = "M-d-y hh:mm:ss tt"
            v2524
        else
            v2512
    let v2526 : (string -> string) = v1.ToString
    let v2527 : string = v2526 v2525
    (* run_target_args'
    let v2546 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2547 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2548 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2547 
    let _run_target_args'_v2546 = v2548 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2550 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2546 = v2550 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2554 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2546 = v2554 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2558 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2546 = v2558 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2562 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2546 = v2562 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2565 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2546 = v2565 
    #endif
#else
    let v2566 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2546 = v2566 
    #endif
    let v2567 : System.TimeZoneInfo = _run_target_args'_v2546 
    (* run_target_args'
    let v2583 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2590 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2591 : (System.DateTime -> int64) = _.Ticks
    let v2592 : int64 = v2591 v1
    let _run_target_args'_v2590 = v2592 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2593 : (System.DateTime -> int64) = _.Ticks
    let v2594 : int64 = v2593 v1
    let _run_target_args'_v2590 = v2594 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2596 : int64 = null |> unbox<int64>
    let _run_target_args'_v2590 = v2596 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2599 : (System.DateTime -> int64) = _.Ticks
    let v2600 : int64 = v2599 v1
    let _run_target_args'_v2590 = v2600 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2601 : (System.DateTime -> int64) = _.Ticks
    let v2602 : int64 = v2601 v1
    let _run_target_args'_v2590 = v2602 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2603 : (System.DateTime -> int64) = _.Ticks
    let v2604 : int64 = v2603 v1
    let _run_target_args'_v2590 = v2604 
    #endif
#else
    let v2605 : (System.DateTime -> int64) = _.Ticks
    let v2606 : int64 = v2605 v1
    let _run_target_args'_v2590 = v2606 
    #endif
    let v2607 : int64 = _run_target_args'_v2590 
    let v2628 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2629 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2607) v2628 
    let v2631 : System.TimeSpan = v2629 |> System.TimeSpan 
    let _run_target_args'_v2583 = v2631 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2640 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2641 : (System.DateTime -> int64) = _.Ticks
    let v2642 : int64 = v2641 v1
    let _run_target_args'_v2640 = v2642 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2643 : (System.DateTime -> int64) = _.Ticks
    let v2644 : int64 = v2643 v1
    let _run_target_args'_v2640 = v2644 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2646 : int64 = null |> unbox<int64>
    let _run_target_args'_v2640 = v2646 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2649 : (System.DateTime -> int64) = _.Ticks
    let v2650 : int64 = v2649 v1
    let _run_target_args'_v2640 = v2650 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2651 : (System.DateTime -> int64) = _.Ticks
    let v2652 : int64 = v2651 v1
    let _run_target_args'_v2640 = v2652 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2653 : (System.DateTime -> int64) = _.Ticks
    let v2654 : int64 = v2653 v1
    let _run_target_args'_v2640 = v2654 
    #endif
#else
    let v2655 : (System.DateTime -> int64) = _.Ticks
    let v2656 : int64 = v2655 v1
    let _run_target_args'_v2640 = v2656 
    #endif
    let v2657 : int64 = _run_target_args'_v2640 
    let v2678 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2679 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2657) v2678 
    let v2681 : System.TimeSpan = v2679 |> System.TimeSpan 
    let _run_target_args'_v2583 = v2681 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2685 : US2 = US2_2
    let v2686 : US3 = US3_4(v2685)
    let v2687 : string = $"date_time.get_utc_offset / target: {v2686}"
    let v2688 : System.TimeSpan = failwith<System.TimeSpan> v2687
    let _run_target_args'_v2583 = v2688 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2692 : US2 = US2_0
    let v2693 : US3 = US3_5(v2692)
    let v2694 : string = $"date_time.get_utc_offset / target: {v2693}"
    let v2695 : System.TimeSpan = failwith<System.TimeSpan> v2694
    let _run_target_args'_v2583 = v2695 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2699 : US2 = US2_0
    let v2700 : US3 = US3_6(v2699)
    let v2701 : string = $"date_time.get_utc_offset / target: {v2700}"
    let v2702 : System.TimeSpan = failwith<System.TimeSpan> v2701
    let _run_target_args'_v2583 = v2702 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2705 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2710 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2711 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2712 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2711 
    let _run_target_args'_v2710 = v2712 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2714 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2710 = v2714 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2718 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2710 = v2718 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2722 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2710 = v2722 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2726 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2710 = v2726 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2729 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2710 = v2729 
    #endif
#else
    let v2730 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2710 = v2730 
    #endif
    let v2731 : System.TimeZoneInfo = _run_target_args'_v2710 
    let v2740 : (System.DateTime -> System.TimeSpan) = v2705 v2731
    let v2741 : System.TimeSpan = v2740 v1
    let _run_target_args'_v2583 = v2741 
    #endif
#else
    let v2742 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2747 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2748 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2749 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2748 
    let _run_target_args'_v2747 = v2749 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2751 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2747 = v2751 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2755 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2747 = v2755 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2759 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2747 = v2759 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2763 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2747 = v2763 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2766 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2747 = v2766 
    #endif
#else
    let v2767 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2747 = v2767 
    #endif
    let v2768 : System.TimeZoneInfo = _run_target_args'_v2747 
    let v2777 : (System.DateTime -> System.TimeSpan) = v2742 v2768
    let v2778 : System.TimeSpan = v2777 v1
    let _run_target_args'_v2583 = v2778 
    #endif
    let v2779 : System.TimeSpan = _run_target_args'_v2583 
    let v2795 : (System.TimeSpan -> int32) = _.Hours
    let v2796 : int32 = v2795 v2779
    let v2799 : bool = v2796 > 0
    let v2800 : uint8 =
        if v2799 then
            1uy
        else
            0uy
    let v2801 : string = method4()
    (* run_target_args'
    let v2872 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2873 : string = "$0.toString($1)"
    let v2874 : string = Fable.Core.RustInterop.emitRustExpr struct (v2779, v2801) v2873 
    let _run_target_args'_v2872 = v2874 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2875 : string = "$0.toString($1)"
    let v2876 : string = Fable.Core.RustInterop.emitRustExpr struct (v2779, v2801) v2875 
    let _run_target_args'_v2872 = v2876 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2877 : string = "$0.toString($1)"
    let v2878 : string = Fable.Core.RustInterop.emitRustExpr struct (v2779, v2801) v2877 
    let _run_target_args'_v2872 = v2878 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2879 : string = v2779.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2872 = v2879 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2880 : string = v2779.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2872 = v2880 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2882 : string = v2779.ToString v2801 
    let _run_target_args'_v2872 = v2882 
    #endif
#else
    let v2952 : string = v2779.ToString v2801 
    let _run_target_args'_v2872 = v2952 
    #endif
    let v3021 : string = _run_target_args'_v2872 
    let v3162 : string = $"{v2800}{v3021}"
    let v3164 : (System.Guid -> string) = _.ToString()
    let v3165 : string = v3164 v0
    let v3168 : int32 = v2527.Length
    let v3169 : int32 = v3162.Length
    let v3170 : int32 = v3168 + v3169
    let v3172 : (string -> int32) = String.length
    let v3173 : int32 = v3172 v3165
    let v3177 : int32 = 1
    let v3183 : int32 = v3170 |> int32 
    let v3196 : int32 = v3173 |> int32 
    let v3204 : int32 = v3196 - v3177
    let v3206 : string = v3165.[int v3183..int v3204]
    let v3210 : string = $"{v2527}{v3162}{v3206}"
    (* run_target_args'
    let v3215 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3217 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3217 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3221 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3221 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3225 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3215 = v3225 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3229 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3229 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3233 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3233 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3237 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3237 
    #endif
#else
    let v3241 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3241 
    #endif
    let v3244 : System.Guid = _run_target_args'_v3215 
    let _run_target_args'_v741 = v3244 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3253 : string = method3()
    let v3264 : bool = v3253 = ""
    let v3266 : string =
        if v3264 then
            let v3265 : string = "M-d-y hh:mm:ss tt"
            v3265
        else
            v3253
    let v3267 : (string -> string) = v1.ToString
    let v3268 : string = v3267 v3266
    (* run_target_args'
    let v3287 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3288 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3289 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3288 
    let _run_target_args'_v3287 = v3289 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3291 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3287 = v3291 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3295 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3287 = v3295 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3299 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3287 = v3299 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3303 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3287 = v3303 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3306 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3287 = v3306 
    #endif
#else
    let v3307 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3287 = v3307 
    #endif
    let v3308 : System.TimeZoneInfo = _run_target_args'_v3287 
    (* run_target_args'
    let v3324 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3331 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3332 : (System.DateTime -> int64) = _.Ticks
    let v3333 : int64 = v3332 v1
    let _run_target_args'_v3331 = v3333 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3334 : (System.DateTime -> int64) = _.Ticks
    let v3335 : int64 = v3334 v1
    let _run_target_args'_v3331 = v3335 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3337 : int64 = null |> unbox<int64>
    let _run_target_args'_v3331 = v3337 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3340 : (System.DateTime -> int64) = _.Ticks
    let v3341 : int64 = v3340 v1
    let _run_target_args'_v3331 = v3341 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3342 : (System.DateTime -> int64) = _.Ticks
    let v3343 : int64 = v3342 v1
    let _run_target_args'_v3331 = v3343 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3344 : (System.DateTime -> int64) = _.Ticks
    let v3345 : int64 = v3344 v1
    let _run_target_args'_v3331 = v3345 
    #endif
#else
    let v3346 : (System.DateTime -> int64) = _.Ticks
    let v3347 : int64 = v3346 v1
    let _run_target_args'_v3331 = v3347 
    #endif
    let v3348 : int64 = _run_target_args'_v3331 
    let v3369 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3370 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3348) v3369 
    let v3372 : System.TimeSpan = v3370 |> System.TimeSpan 
    let _run_target_args'_v3324 = v3372 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3381 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3382 : (System.DateTime -> int64) = _.Ticks
    let v3383 : int64 = v3382 v1
    let _run_target_args'_v3381 = v3383 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3384 : (System.DateTime -> int64) = _.Ticks
    let v3385 : int64 = v3384 v1
    let _run_target_args'_v3381 = v3385 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3387 : int64 = null |> unbox<int64>
    let _run_target_args'_v3381 = v3387 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3390 : (System.DateTime -> int64) = _.Ticks
    let v3391 : int64 = v3390 v1
    let _run_target_args'_v3381 = v3391 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3392 : (System.DateTime -> int64) = _.Ticks
    let v3393 : int64 = v3392 v1
    let _run_target_args'_v3381 = v3393 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3394 : (System.DateTime -> int64) = _.Ticks
    let v3395 : int64 = v3394 v1
    let _run_target_args'_v3381 = v3395 
    #endif
#else
    let v3396 : (System.DateTime -> int64) = _.Ticks
    let v3397 : int64 = v3396 v1
    let _run_target_args'_v3381 = v3397 
    #endif
    let v3398 : int64 = _run_target_args'_v3381 
    let v3419 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3420 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3398) v3419 
    let v3422 : System.TimeSpan = v3420 |> System.TimeSpan 
    let _run_target_args'_v3324 = v3422 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3426 : US2 = US2_2
    let v3427 : US3 = US3_4(v3426)
    let v3428 : string = $"date_time.get_utc_offset / target: {v3427}"
    let v3429 : System.TimeSpan = failwith<System.TimeSpan> v3428
    let _run_target_args'_v3324 = v3429 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3433 : US2 = US2_0
    let v3434 : US3 = US3_5(v3433)
    let v3435 : string = $"date_time.get_utc_offset / target: {v3434}"
    let v3436 : System.TimeSpan = failwith<System.TimeSpan> v3435
    let _run_target_args'_v3324 = v3436 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3440 : US2 = US2_0
    let v3441 : US3 = US3_6(v3440)
    let v3442 : string = $"date_time.get_utc_offset / target: {v3441}"
    let v3443 : System.TimeSpan = failwith<System.TimeSpan> v3442
    let _run_target_args'_v3324 = v3443 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3446 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3451 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3452 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3453 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3452 
    let _run_target_args'_v3451 = v3453 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3455 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3451 = v3455 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3459 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3451 = v3459 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3463 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3451 = v3463 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3467 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3451 = v3467 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3470 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3451 = v3470 
    #endif
#else
    let v3471 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3451 = v3471 
    #endif
    let v3472 : System.TimeZoneInfo = _run_target_args'_v3451 
    let v3481 : (System.DateTime -> System.TimeSpan) = v3446 v3472
    let v3482 : System.TimeSpan = v3481 v1
    let _run_target_args'_v3324 = v3482 
    #endif
#else
    let v3483 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3488 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3489 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3490 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3489 
    let _run_target_args'_v3488 = v3490 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3492 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3488 = v3492 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3496 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3488 = v3496 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3500 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3488 = v3500 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3504 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3488 = v3504 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3507 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3488 = v3507 
    #endif
#else
    let v3508 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3488 = v3508 
    #endif
    let v3509 : System.TimeZoneInfo = _run_target_args'_v3488 
    let v3518 : (System.DateTime -> System.TimeSpan) = v3483 v3509
    let v3519 : System.TimeSpan = v3518 v1
    let _run_target_args'_v3324 = v3519 
    #endif
    let v3520 : System.TimeSpan = _run_target_args'_v3324 
    let v3536 : (System.TimeSpan -> int32) = _.Hours
    let v3537 : int32 = v3536 v3520
    let v3540 : bool = v3537 > 0
    let v3541 : uint8 =
        if v3540 then
            1uy
        else
            0uy
    let v3542 : string = method4()
    (* run_target_args'
    let v3613 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3614 : string = "$0.toString($1)"
    let v3615 : string = Fable.Core.RustInterop.emitRustExpr struct (v3520, v3542) v3614 
    let _run_target_args'_v3613 = v3615 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3616 : string = "$0.toString($1)"
    let v3617 : string = Fable.Core.RustInterop.emitRustExpr struct (v3520, v3542) v3616 
    let _run_target_args'_v3613 = v3617 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3618 : string = "$0.toString($1)"
    let v3619 : string = Fable.Core.RustInterop.emitRustExpr struct (v3520, v3542) v3618 
    let _run_target_args'_v3613 = v3619 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3620 : string = v3520.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3613 = v3620 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3621 : string = v3520.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3613 = v3621 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3623 : string = v3520.ToString v3542 
    let _run_target_args'_v3613 = v3623 
    #endif
#else
    let v3693 : string = v3520.ToString v3542 
    let _run_target_args'_v3613 = v3693 
    #endif
    let v3762 : string = _run_target_args'_v3613 
    let v3903 : string = $"{v3541}{v3762}"
    let v3905 : (System.Guid -> string) = _.ToString()
    let v3906 : string = v3905 v0
    let v3909 : int32 = v3268.Length
    let v3910 : int32 = v3903.Length
    let v3911 : int32 = v3909 + v3910
    let v3913 : (string -> int32) = String.length
    let v3914 : int32 = v3913 v3906
    let v3918 : int32 = 1
    let v3924 : int32 = v3911 |> int32 
    let v3937 : int32 = v3914 |> int32 
    let v3945 : int32 = v3937 - v3918
    let v3947 : string = v3906.[int v3924..int v3945]
    let v3951 : string = $"{v3268}{v3903}{v3947}"
    (* run_target_args'
    let v3956 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3958 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3958 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3962 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3962 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3966 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3956 = v3966 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3970 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3970 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3974 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3974 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3978 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3978 
    #endif
#else
    let v3982 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3982 
    #endif
    let v3985 : System.Guid = _run_target_args'_v3956 
    let _run_target_args'_v741 = v3985 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3994 : string = method3()
    let v4005 : bool = v3994 = ""
    let v4007 : string =
        if v4005 then
            let v4006 : string = "M-d-y hh:mm:ss tt"
            v4006
        else
            v3994
    let v4008 : (string -> string) = v1.ToString
    let v4009 : string = v4008 v4007
    (* run_target_args'
    let v4028 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4029 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4030 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4029 
    let _run_target_args'_v4028 = v4030 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4032 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4028 = v4032 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4036 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4028 = v4036 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4040 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4028 = v4040 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4044 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4028 = v4044 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4047 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4028 = v4047 
    #endif
#else
    let v4048 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4028 = v4048 
    #endif
    let v4049 : System.TimeZoneInfo = _run_target_args'_v4028 
    (* run_target_args'
    let v4065 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v4072 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4073 : (System.DateTime -> int64) = _.Ticks
    let v4074 : int64 = v4073 v1
    let _run_target_args'_v4072 = v4074 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4075 : (System.DateTime -> int64) = _.Ticks
    let v4076 : int64 = v4075 v1
    let _run_target_args'_v4072 = v4076 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4078 : int64 = null |> unbox<int64>
    let _run_target_args'_v4072 = v4078 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4081 : (System.DateTime -> int64) = _.Ticks
    let v4082 : int64 = v4081 v1
    let _run_target_args'_v4072 = v4082 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4083 : (System.DateTime -> int64) = _.Ticks
    let v4084 : int64 = v4083 v1
    let _run_target_args'_v4072 = v4084 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4085 : (System.DateTime -> int64) = _.Ticks
    let v4086 : int64 = v4085 v1
    let _run_target_args'_v4072 = v4086 
    #endif
#else
    let v4087 : (System.DateTime -> int64) = _.Ticks
    let v4088 : int64 = v4087 v1
    let _run_target_args'_v4072 = v4088 
    #endif
    let v4089 : int64 = _run_target_args'_v4072 
    let v4110 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4111 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4089) v4110 
    let v4113 : System.TimeSpan = v4111 |> System.TimeSpan 
    let _run_target_args'_v4065 = v4113 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4122 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4123 : (System.DateTime -> int64) = _.Ticks
    let v4124 : int64 = v4123 v1
    let _run_target_args'_v4122 = v4124 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4125 : (System.DateTime -> int64) = _.Ticks
    let v4126 : int64 = v4125 v1
    let _run_target_args'_v4122 = v4126 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4128 : int64 = null |> unbox<int64>
    let _run_target_args'_v4122 = v4128 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4131 : (System.DateTime -> int64) = _.Ticks
    let v4132 : int64 = v4131 v1
    let _run_target_args'_v4122 = v4132 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4133 : (System.DateTime -> int64) = _.Ticks
    let v4134 : int64 = v4133 v1
    let _run_target_args'_v4122 = v4134 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4135 : (System.DateTime -> int64) = _.Ticks
    let v4136 : int64 = v4135 v1
    let _run_target_args'_v4122 = v4136 
    #endif
#else
    let v4137 : (System.DateTime -> int64) = _.Ticks
    let v4138 : int64 = v4137 v1
    let _run_target_args'_v4122 = v4138 
    #endif
    let v4139 : int64 = _run_target_args'_v4122 
    let v4160 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4161 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4139) v4160 
    let v4163 : System.TimeSpan = v4161 |> System.TimeSpan 
    let _run_target_args'_v4065 = v4163 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4167 : US2 = US2_2
    let v4168 : US3 = US3_4(v4167)
    let v4169 : string = $"date_time.get_utc_offset / target: {v4168}"
    let v4170 : System.TimeSpan = failwith<System.TimeSpan> v4169
    let _run_target_args'_v4065 = v4170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4174 : US2 = US2_0
    let v4175 : US3 = US3_5(v4174)
    let v4176 : string = $"date_time.get_utc_offset / target: {v4175}"
    let v4177 : System.TimeSpan = failwith<System.TimeSpan> v4176
    let _run_target_args'_v4065 = v4177 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4181 : US2 = US2_0
    let v4182 : US3 = US3_6(v4181)
    let v4183 : string = $"date_time.get_utc_offset / target: {v4182}"
    let v4184 : System.TimeSpan = failwith<System.TimeSpan> v4183
    let _run_target_args'_v4065 = v4184 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
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
    let _run_target_args'_v4065 = v4223 
    #endif
#else
    let v4224 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4229 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4230 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4231 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4230 
    let _run_target_args'_v4229 = v4231 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4233 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4229 = v4233 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4237 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4229 = v4237 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4241 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4229 = v4241 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4245 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4229 = v4245 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4248 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4229 = v4248 
    #endif
#else
    let v4249 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4229 = v4249 
    #endif
    let v4250 : System.TimeZoneInfo = _run_target_args'_v4229 
    let v4259 : (System.DateTime -> System.TimeSpan) = v4224 v4250
    let v4260 : System.TimeSpan = v4259 v1
    let _run_target_args'_v4065 = v4260 
    #endif
    let v4261 : System.TimeSpan = _run_target_args'_v4065 
    let v4277 : (System.TimeSpan -> int32) = _.Hours
    let v4278 : int32 = v4277 v4261
    let v4281 : bool = v4278 > 0
    let v4282 : uint8 =
        if v4281 then
            1uy
        else
            0uy
    let v4283 : string = method4()
    (* run_target_args'
    let v4354 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4355 : string = "$0.toString($1)"
    let v4356 : string = Fable.Core.RustInterop.emitRustExpr struct (v4261, v4283) v4355 
    let _run_target_args'_v4354 = v4356 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4357 : string = "$0.toString($1)"
    let v4358 : string = Fable.Core.RustInterop.emitRustExpr struct (v4261, v4283) v4357 
    let _run_target_args'_v4354 = v4358 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4359 : string = "$0.toString($1)"
    let v4360 : string = Fable.Core.RustInterop.emitRustExpr struct (v4261, v4283) v4359 
    let _run_target_args'_v4354 = v4360 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4361 : string = v4261.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4354 = v4361 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4362 : string = v4261.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4354 = v4362 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4364 : string = v4261.ToString v4283 
    let _run_target_args'_v4354 = v4364 
    #endif
#else
    let v4434 : string = v4261.ToString v4283 
    let _run_target_args'_v4354 = v4434 
    #endif
    let v4503 : string = _run_target_args'_v4354 
    let v4644 : string = $"{v4282}{v4503}"
    let v4646 : (System.Guid -> string) = _.ToString()
    let v4647 : string = v4646 v0
    let v4650 : int32 = v4009.Length
    let v4651 : int32 = v4644.Length
    let v4652 : int32 = v4650 + v4651
    let v4654 : (string -> int32) = String.length
    let v4655 : int32 = v4654 v4647
    let v4659 : int32 = 1
    let v4665 : int32 = v4652 |> int32 
    let v4678 : int32 = v4655 |> int32 
    let v4686 : int32 = v4678 - v4659
    let v4688 : string = v4647.[int v4665..int v4686]
    let v4692 : string = $"{v4009}{v4644}{v4688}"
    (* run_target_args'
    let v4697 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4699 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4699 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4703 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4703 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4707 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4697 = v4707 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4711 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4711 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4715 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4715 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4719 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4719 
    #endif
#else
    let v4723 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4723 
    #endif
    let v4726 : System.Guid = _run_target_args'_v4697 
    let _run_target_args'_v741 = v4726 
    #endif
#else
    let v4735 : string = method3()
    let v4746 : bool = v4735 = ""
    let v4748 : string =
        if v4746 then
            let v4747 : string = "M-d-y hh:mm:ss tt"
            v4747
        else
            v4735
    let v4749 : (string -> string) = v1.ToString
    let v4750 : string = v4749 v4748
    (* run_target_args'
    let v4769 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4770 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4771 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4770 
    let _run_target_args'_v4769 = v4771 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4773 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4769 = v4773 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4777 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4769 = v4777 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4781 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4769 = v4781 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4785 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4769 = v4785 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4788 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4769 = v4788 
    #endif
#else
    let v4789 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4769 = v4789 
    #endif
    let v4790 : System.TimeZoneInfo = _run_target_args'_v4769 
    (* run_target_args'
    let v4806 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v4813 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4814 : (System.DateTime -> int64) = _.Ticks
    let v4815 : int64 = v4814 v1
    let _run_target_args'_v4813 = v4815 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4816 : (System.DateTime -> int64) = _.Ticks
    let v4817 : int64 = v4816 v1
    let _run_target_args'_v4813 = v4817 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4819 : int64 = null |> unbox<int64>
    let _run_target_args'_v4813 = v4819 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4822 : (System.DateTime -> int64) = _.Ticks
    let v4823 : int64 = v4822 v1
    let _run_target_args'_v4813 = v4823 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4824 : (System.DateTime -> int64) = _.Ticks
    let v4825 : int64 = v4824 v1
    let _run_target_args'_v4813 = v4825 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4826 : (System.DateTime -> int64) = _.Ticks
    let v4827 : int64 = v4826 v1
    let _run_target_args'_v4813 = v4827 
    #endif
#else
    let v4828 : (System.DateTime -> int64) = _.Ticks
    let v4829 : int64 = v4828 v1
    let _run_target_args'_v4813 = v4829 
    #endif
    let v4830 : int64 = _run_target_args'_v4813 
    let v4851 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4852 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4830) v4851 
    let v4854 : System.TimeSpan = v4852 |> System.TimeSpan 
    let _run_target_args'_v4806 = v4854 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4863 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4864 : (System.DateTime -> int64) = _.Ticks
    let v4865 : int64 = v4864 v1
    let _run_target_args'_v4863 = v4865 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4866 : (System.DateTime -> int64) = _.Ticks
    let v4867 : int64 = v4866 v1
    let _run_target_args'_v4863 = v4867 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4869 : int64 = null |> unbox<int64>
    let _run_target_args'_v4863 = v4869 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4872 : (System.DateTime -> int64) = _.Ticks
    let v4873 : int64 = v4872 v1
    let _run_target_args'_v4863 = v4873 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4874 : (System.DateTime -> int64) = _.Ticks
    let v4875 : int64 = v4874 v1
    let _run_target_args'_v4863 = v4875 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4876 : (System.DateTime -> int64) = _.Ticks
    let v4877 : int64 = v4876 v1
    let _run_target_args'_v4863 = v4877 
    #endif
#else
    let v4878 : (System.DateTime -> int64) = _.Ticks
    let v4879 : int64 = v4878 v1
    let _run_target_args'_v4863 = v4879 
    #endif
    let v4880 : int64 = _run_target_args'_v4863 
    let v4901 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4902 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4880) v4901 
    let v4904 : System.TimeSpan = v4902 |> System.TimeSpan 
    let _run_target_args'_v4806 = v4904 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4908 : US2 = US2_2
    let v4909 : US3 = US3_4(v4908)
    let v4910 : string = $"date_time.get_utc_offset / target: {v4909}"
    let v4911 : System.TimeSpan = failwith<System.TimeSpan> v4910
    let _run_target_args'_v4806 = v4911 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4915 : US2 = US2_0
    let v4916 : US3 = US3_5(v4915)
    let v4917 : string = $"date_time.get_utc_offset / target: {v4916}"
    let v4918 : System.TimeSpan = failwith<System.TimeSpan> v4917
    let _run_target_args'_v4806 = v4918 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4922 : US2 = US2_0
    let v4923 : US3 = US3_6(v4922)
    let v4924 : string = $"date_time.get_utc_offset / target: {v4923}"
    let v4925 : System.TimeSpan = failwith<System.TimeSpan> v4924
    let _run_target_args'_v4806 = v4925 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4928 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4933 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4934 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4935 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4934 
    let _run_target_args'_v4933 = v4935 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4937 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4933 = v4937 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4941 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4933 = v4941 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4945 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4933 = v4945 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4949 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4933 = v4949 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4952 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4933 = v4952 
    #endif
#else
    let v4953 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4933 = v4953 
    #endif
    let v4954 : System.TimeZoneInfo = _run_target_args'_v4933 
    let v4963 : (System.DateTime -> System.TimeSpan) = v4928 v4954
    let v4964 : System.TimeSpan = v4963 v1
    let _run_target_args'_v4806 = v4964 
    #endif
#else
    let v4965 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4970 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4971 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4972 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4971 
    let _run_target_args'_v4970 = v4972 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4974 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4970 = v4974 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4978 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4970 = v4978 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4982 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4970 = v4982 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4986 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4970 = v4986 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4989 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4970 = v4989 
    #endif
#else
    let v4990 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4970 = v4990 
    #endif
    let v4991 : System.TimeZoneInfo = _run_target_args'_v4970 
    let v5000 : (System.DateTime -> System.TimeSpan) = v4965 v4991
    let v5001 : System.TimeSpan = v5000 v1
    let _run_target_args'_v4806 = v5001 
    #endif
    let v5002 : System.TimeSpan = _run_target_args'_v4806 
    let v5018 : (System.TimeSpan -> int32) = _.Hours
    let v5019 : int32 = v5018 v5002
    let v5022 : bool = v5019 > 0
    let v5023 : uint8 =
        if v5022 then
            1uy
        else
            0uy
    let v5024 : string = method4()
    (* run_target_args'
    let v5095 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5096 : string = "$0.toString($1)"
    let v5097 : string = Fable.Core.RustInterop.emitRustExpr struct (v5002, v5024) v5096 
    let _run_target_args'_v5095 = v5097 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5098 : string = "$0.toString($1)"
    let v5099 : string = Fable.Core.RustInterop.emitRustExpr struct (v5002, v5024) v5098 
    let _run_target_args'_v5095 = v5099 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5100 : string = "$0.toString($1)"
    let v5101 : string = Fable.Core.RustInterop.emitRustExpr struct (v5002, v5024) v5100 
    let _run_target_args'_v5095 = v5101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5102 : string = v5002.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v5095 = v5102 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5103 : string = v5002.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v5095 = v5103 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5105 : string = v5002.ToString v5024 
    let _run_target_args'_v5095 = v5105 
    #endif
#else
    let v5175 : string = v5002.ToString v5024 
    let _run_target_args'_v5095 = v5175 
    #endif
    let v5244 : string = _run_target_args'_v5095 
    let v5385 : string = $"{v5023}{v5244}"
    let v5387 : (System.Guid -> string) = _.ToString()
    let v5388 : string = v5387 v0
    let v5391 : int32 = v4750.Length
    let v5392 : int32 = v5385.Length
    let v5393 : int32 = v5391 + v5392
    let v5395 : (string -> int32) = String.length
    let v5396 : int32 = v5395 v5388
    let v5400 : int32 = 1
    let v5406 : int32 = v5393 |> int32 
    let v5419 : int32 = v5396 |> int32 
    let v5427 : int32 = v5419 - v5400
    let v5429 : string = v5388.[int v5406..int v5427]
    let v5433 : string = $"{v4750}{v5385}{v5429}"
    (* run_target_args'
    let v5438 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5440 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5440 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5444 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5444 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5448 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v5438 = v5448 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5452 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5452 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5456 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5456 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5460 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5460 
    #endif
#else
    let v5464 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5464 
    #endif
    let v5467 : System.Guid = _run_target_args'_v5438 
    let _run_target_args'_v741 = v5467 
    #endif
    let v5476 : System.Guid = _run_target_args'_v741 
    v5476
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
    let v12 : bool = v0 = ""
    let v14 : string =
        if v12 then
            let v13 : string = "M-d-y hh:mm:ss tt"
            v13
        else
            v0
    let v15 : (string -> string) = v1.ToString
    v15 v14
and closure11 () (v0 : string) : (System.DateTime -> string) =
    closure12(v0)
and closure13 () (v0 : System.DateTime) : string =
    let v10 : (string -> string) = v0.ToString
    let v11 : string = "yyyy-MM-ddTHH-mm-ss.fff"
    v10 v11
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
