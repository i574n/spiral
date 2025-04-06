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
    let v677 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v683 : System.DateTime = System.DateTime.UnixEpoch
    let v687 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v688 : System.DateTime = v687 v683
    let v692 : System.DateTimeKind = System.DateTimeKind.Local
    let v693 : System.DateTime = System.DateTime.SpecifyKind (v1, v692)
    let v697 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v698 : System.DateTime = v697 v693
    (* run_target_args'
    let v707 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v708 : (System.DateTime -> int64) = _.Ticks
    let v709 : int64 = v708 v698
    let _run_target_args'_v707 = v709 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v710 : (System.DateTime -> int64) = _.Ticks
    let v711 : int64 = v710 v698
    let _run_target_args'_v707 = v711 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v713 : int64 = null |> unbox<int64>
    let _run_target_args'_v707 = v713 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v716 : (System.DateTime -> int64) = _.Ticks
    let v717 : int64 = v716 v698
    let _run_target_args'_v707 = v717 
    #endif
#if FABLE_COMPILER_PYTHON
    let v718 : (System.DateTime -> int64) = _.Ticks
    let v719 : int64 = v718 v698
    let _run_target_args'_v707 = v719 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v720 : (System.DateTime -> int64) = _.Ticks
    let v721 : int64 = v720 v698
    let _run_target_args'_v707 = v721 
    #endif
#else
    let v722 : (System.DateTime -> int64) = _.Ticks
    let v723 : int64 = v722 v698
    let _run_target_args'_v707 = v723 
    #endif
    let v724 : int64 = _run_target_args'_v707 
    (* run_target_args'
    let v751 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v752 : (System.DateTime -> int64) = _.Ticks
    let v753 : int64 = v752 v688
    let _run_target_args'_v751 = v753 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v754 : (System.DateTime -> int64) = _.Ticks
    let v755 : int64 = v754 v688
    let _run_target_args'_v751 = v755 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v757 : int64 = null |> unbox<int64>
    let _run_target_args'_v751 = v757 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v760 : (System.DateTime -> int64) = _.Ticks
    let v761 : int64 = v760 v688
    let _run_target_args'_v751 = v761 
    #endif
#if FABLE_COMPILER_PYTHON
    let v762 : (System.DateTime -> int64) = _.Ticks
    let v763 : int64 = v762 v688
    let _run_target_args'_v751 = v763 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v764 : (System.DateTime -> int64) = _.Ticks
    let v765 : int64 = v764 v688
    let _run_target_args'_v751 = v765 
    #endif
#else
    let v766 : (System.DateTime -> int64) = _.Ticks
    let v767 : int64 = v766 v688
    let _run_target_args'_v751 = v767 
    #endif
    let v768 : int64 = _run_target_args'_v751 
    let v790 : int64 = v724 |> int64 
    let v794 : int64 = v768 |> int64 
    let v797 : int64 = v790 - v794
    let v798 : int64 = v797 / 10L
    let v799 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v800 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v798 v799 
    let v803 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v804 : US0 option = v800 |> Option.map v803 
    let v824 : US0 = US0_1
    let v825 : US0 = v804 |> Option.defaultValue v824 
    let v845 : US1 =
        match v825 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v829) -> (* Some *)
            let v830 : string = "$0.naive_utc()"
            let v831 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v829 v830 
            let v832 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v833 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v831 v832 
            let v834 : string = "%Y%m%d-%H%M-%S%f"
            let v835 : string = "r#\"" + v834 + "\"#"
            let v836 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v835 
            let v837 : string = "$0.format($1).to_string()"
            let v838 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v833, v836) v837 
            let v839 : string = "fable_library_rust::String_::fromString($0)"
            let v840 : string = Fable.Core.RustInterop.emitRustExpr v838 v839 
            let v841 : string = $"{v840.[0..17]}-{v840.[18..21]}-{v840.[22]}"
            US1_0(v841)
    let v849 : string =
        match v845 with
        | US1_1 -> (* None *)
            let v847 : string = ""
            v847
        | US1_0(v846) -> (* Some *)
            v846
    (* run_target_args'
    let v854 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v855 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v856 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v855 
    let _run_target_args'_v854 = v856 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v858 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v854 = v858 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v862 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v854 = v862 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v866 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v854 = v866 
    #endif
#if FABLE_COMPILER_PYTHON
    let v870 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v854 = v870 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v873 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v854 = v873 
    #endif
#else
    let v874 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v854 = v874 
    #endif
    let v875 : System.TimeZoneInfo = _run_target_args'_v854 
    (* run_target_args'
    let v891 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v898 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v899 : (System.DateTime -> int64) = _.Ticks
    let v900 : int64 = v899 v698
    let _run_target_args'_v898 = v900 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v901 : (System.DateTime -> int64) = _.Ticks
    let v902 : int64 = v901 v698
    let _run_target_args'_v898 = v902 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v904 : int64 = null |> unbox<int64>
    let _run_target_args'_v898 = v904 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v907 : (System.DateTime -> int64) = _.Ticks
    let v908 : int64 = v907 v698
    let _run_target_args'_v898 = v908 
    #endif
#if FABLE_COMPILER_PYTHON
    let v909 : (System.DateTime -> int64) = _.Ticks
    let v910 : int64 = v909 v698
    let _run_target_args'_v898 = v910 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v911 : (System.DateTime -> int64) = _.Ticks
    let v912 : int64 = v911 v698
    let _run_target_args'_v898 = v912 
    #endif
#else
    let v913 : (System.DateTime -> int64) = _.Ticks
    let v914 : int64 = v913 v698
    let _run_target_args'_v898 = v914 
    #endif
    let v915 : int64 = _run_target_args'_v898 
    let v936 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v937 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v698, v915) v936 
    let v939 : System.TimeSpan = v937 |> System.TimeSpan 
    let _run_target_args'_v891 = v939 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v948 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v949 : (System.DateTime -> int64) = _.Ticks
    let v950 : int64 = v949 v698
    let _run_target_args'_v948 = v950 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v951 : (System.DateTime -> int64) = _.Ticks
    let v952 : int64 = v951 v698
    let _run_target_args'_v948 = v952 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v954 : int64 = null |> unbox<int64>
    let _run_target_args'_v948 = v954 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v957 : (System.DateTime -> int64) = _.Ticks
    let v958 : int64 = v957 v698
    let _run_target_args'_v948 = v958 
    #endif
#if FABLE_COMPILER_PYTHON
    let v959 : (System.DateTime -> int64) = _.Ticks
    let v960 : int64 = v959 v698
    let _run_target_args'_v948 = v960 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v961 : (System.DateTime -> int64) = _.Ticks
    let v962 : int64 = v961 v698
    let _run_target_args'_v948 = v962 
    #endif
#else
    let v963 : (System.DateTime -> int64) = _.Ticks
    let v964 : int64 = v963 v698
    let _run_target_args'_v948 = v964 
    #endif
    let v965 : int64 = _run_target_args'_v948 
    let v986 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v987 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v698, v965) v986 
    let v989 : System.TimeSpan = v987 |> System.TimeSpan 
    let _run_target_args'_v891 = v989 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v993 : US2 = US2_2
    let v994 : US3 = US3_4(v993)
    let v995 : string = $"date_time.get_utc_offset / target: {v994}"
    let v996 : System.TimeSpan = failwith<System.TimeSpan> v995
    let _run_target_args'_v891 = v996 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1000 : US2 = US2_0
    let v1001 : US3 = US3_5(v1000)
    let v1002 : string = $"date_time.get_utc_offset / target: {v1001}"
    let v1003 : System.TimeSpan = failwith<System.TimeSpan> v1002
    let _run_target_args'_v891 = v1003 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1007 : US2 = US2_0
    let v1008 : US3 = US3_6(v1007)
    let v1009 : string = $"date_time.get_utc_offset / target: {v1008}"
    let v1010 : System.TimeSpan = failwith<System.TimeSpan> v1009
    let _run_target_args'_v891 = v1010 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1013 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1018 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1019 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1020 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1019 
    let _run_target_args'_v1018 = v1020 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1022 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1018 = v1022 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1026 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1018 = v1026 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1030 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1018 = v1030 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1034 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1018 = v1034 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1037 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1018 = v1037 
    #endif
#else
    let v1038 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1018 = v1038 
    #endif
    let v1039 : System.TimeZoneInfo = _run_target_args'_v1018 
    let v1048 : (System.DateTime -> System.TimeSpan) = v1013 v1039
    let v1049 : System.TimeSpan = v1048 v698
    let _run_target_args'_v891 = v1049 
    #endif
#else
    let v1050 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1055 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1056 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1057 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1056 
    let _run_target_args'_v1055 = v1057 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1059 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1055 = v1059 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1063 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1055 = v1063 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1067 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1055 = v1067 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1071 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1055 = v1071 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1074 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1055 = v1074 
    #endif
#else
    let v1075 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1055 = v1075 
    #endif
    let v1076 : System.TimeZoneInfo = _run_target_args'_v1055 
    let v1085 : (System.DateTime -> System.TimeSpan) = v1050 v1076
    let v1086 : System.TimeSpan = v1085 v698
    let _run_target_args'_v891 = v1086 
    #endif
    let v1087 : System.TimeSpan = _run_target_args'_v891 
    let v1103 : (System.TimeSpan -> int32) = _.Hours
    let v1104 : int32 = v1103 v1087
    let v1107 : bool = v1104 > 0
    let v1108 : uint8 =
        if v1107 then
            1uy
        else
            0uy
    let v1109 : string = method2()
    (* run_target_args'
    let v1169 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1170 : string = "$0.toString($1)"
    let v1171 : string = Fable.Core.RustInterop.emitRustExpr struct (v1087, v1109) v1170 
    let _run_target_args'_v1169 = v1171 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1172 : string = "$0.toString($1)"
    let v1173 : string = Fable.Core.RustInterop.emitRustExpr struct (v1087, v1109) v1172 
    let _run_target_args'_v1169 = v1173 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1174 : string = "$0.toString($1)"
    let v1175 : string = Fable.Core.RustInterop.emitRustExpr struct (v1087, v1109) v1174 
    let _run_target_args'_v1169 = v1175 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1176 : string = v1087.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1169 = v1176 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1177 : string = v1087.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1169 = v1177 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1179 : string = v1087.ToString v1109 
    let _run_target_args'_v1169 = v1179 
    #endif
#else
    let v1238 : string = v1087.ToString v1109 
    let _run_target_args'_v1169 = v1238 
    #endif
    let v1296 : string = _run_target_args'_v1169 
    let v1415 : string = $"{v1108}{v1296.[0..1]}{v1296.[3..4]}"
    let v1417 : (System.Guid -> string) = _.ToString()
    let v1418 : string = v1417 v0
    let v1421 : int32 = v849.Length
    let v1422 : int32 = v1415.Length
    let v1423 : int32 = v1421 + v1422
    let v1425 : (string -> int32) = String.length
    let v1426 : int32 = v1425 v1418
    let v1434 : int32 = v1423 |> int32 
    let v1447 : int32 = v1426 |> int32 
    let v1455 : int32 = v1447 - 1
    let v1457 : string = v1418.[int v1434..int v1455]
    let v1461 : string = $"{v849}{v1415}{v1457}"
    (* run_target_args'
    let v1466 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1468 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1468 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1472 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1472 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1476 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1466 = v1476 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1480 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1480 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1484 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1484 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1488 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1488 
    #endif
#else
    let v1492 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1492 
    #endif
    let v1495 : System.Guid = _run_target_args'_v1466 
    let _run_target_args'_v677 = v1495 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1509 : System.DateTime = System.DateTime.UnixEpoch
    let v1513 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1514 : System.DateTime = v1513 v1509
    let v1518 : System.DateTimeKind = System.DateTimeKind.Local
    let v1519 : System.DateTime = System.DateTime.SpecifyKind (v1, v1518)
    let v1523 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1524 : System.DateTime = v1523 v1519
    (* run_target_args'
    let v1533 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1534 : (System.DateTime -> int64) = _.Ticks
    let v1535 : int64 = v1534 v1524
    let _run_target_args'_v1533 = v1535 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1536 : (System.DateTime -> int64) = _.Ticks
    let v1537 : int64 = v1536 v1524
    let _run_target_args'_v1533 = v1537 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1539 : int64 = null |> unbox<int64>
    let _run_target_args'_v1533 = v1539 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1542 : (System.DateTime -> int64) = _.Ticks
    let v1543 : int64 = v1542 v1524
    let _run_target_args'_v1533 = v1543 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1544 : (System.DateTime -> int64) = _.Ticks
    let v1545 : int64 = v1544 v1524
    let _run_target_args'_v1533 = v1545 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1546 : (System.DateTime -> int64) = _.Ticks
    let v1547 : int64 = v1546 v1524
    let _run_target_args'_v1533 = v1547 
    #endif
#else
    let v1548 : (System.DateTime -> int64) = _.Ticks
    let v1549 : int64 = v1548 v1524
    let _run_target_args'_v1533 = v1549 
    #endif
    let v1550 : int64 = _run_target_args'_v1533 
    (* run_target_args'
    let v1577 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1578 : (System.DateTime -> int64) = _.Ticks
    let v1579 : int64 = v1578 v1514
    let _run_target_args'_v1577 = v1579 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1580 : (System.DateTime -> int64) = _.Ticks
    let v1581 : int64 = v1580 v1514
    let _run_target_args'_v1577 = v1581 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1583 : int64 = null |> unbox<int64>
    let _run_target_args'_v1577 = v1583 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1586 : (System.DateTime -> int64) = _.Ticks
    let v1587 : int64 = v1586 v1514
    let _run_target_args'_v1577 = v1587 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1588 : (System.DateTime -> int64) = _.Ticks
    let v1589 : int64 = v1588 v1514
    let _run_target_args'_v1577 = v1589 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1590 : (System.DateTime -> int64) = _.Ticks
    let v1591 : int64 = v1590 v1514
    let _run_target_args'_v1577 = v1591 
    #endif
#else
    let v1592 : (System.DateTime -> int64) = _.Ticks
    let v1593 : int64 = v1592 v1514
    let _run_target_args'_v1577 = v1593 
    #endif
    let v1594 : int64 = _run_target_args'_v1577 
    let v1616 : int64 = v1550 |> int64 
    let v1620 : int64 = v1594 |> int64 
    let v1623 : int64 = v1616 - v1620
    let v1624 : int64 = v1623 / 10L
    let v1625 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1626 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1624 v1625 
    let v1629 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v1630 : US0 option = v1626 |> Option.map v1629 
    let v1650 : US0 = US0_1
    let v1651 : US0 = v1630 |> Option.defaultValue v1650 
    let v1671 : US1 =
        match v1651 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v1655) -> (* Some *)
            let v1656 : string = "$0.naive_utc()"
            let v1657 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1655 v1656 
            let v1658 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1659 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1657 v1658 
            let v1660 : string = "%Y%m%d-%H%M-%S%f"
            let v1661 : string = "r#\"" + v1660 + "\"#"
            let v1662 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1661 
            let v1663 : string = "$0.format($1).to_string()"
            let v1664 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1659, v1662) v1663 
            let v1665 : string = "fable_library_rust::String_::fromString($0)"
            let v1666 : string = Fable.Core.RustInterop.emitRustExpr v1664 v1665 
            let v1667 : string = $"{v1666.[0..17]}-{v1666.[18..21]}-{v1666.[22]}"
            US1_0(v1667)
    let v1675 : string =
        match v1671 with
        | US1_1 -> (* None *)
            let v1673 : string = ""
            v1673
        | US1_0(v1672) -> (* Some *)
            v1672
    (* run_target_args'
    let v1680 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1681 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1682 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1681 
    let _run_target_args'_v1680 = v1682 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1684 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1680 = v1684 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1688 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1680 = v1688 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1692 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1680 = v1692 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1696 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1680 = v1696 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1699 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1680 = v1699 
    #endif
#else
    let v1700 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1680 = v1700 
    #endif
    let v1701 : System.TimeZoneInfo = _run_target_args'_v1680 
    (* run_target_args'
    let v1717 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1724 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1725 : (System.DateTime -> int64) = _.Ticks
    let v1726 : int64 = v1725 v1524
    let _run_target_args'_v1724 = v1726 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1727 : (System.DateTime -> int64) = _.Ticks
    let v1728 : int64 = v1727 v1524
    let _run_target_args'_v1724 = v1728 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1730 : int64 = null |> unbox<int64>
    let _run_target_args'_v1724 = v1730 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1733 : (System.DateTime -> int64) = _.Ticks
    let v1734 : int64 = v1733 v1524
    let _run_target_args'_v1724 = v1734 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1735 : (System.DateTime -> int64) = _.Ticks
    let v1736 : int64 = v1735 v1524
    let _run_target_args'_v1724 = v1736 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1737 : (System.DateTime -> int64) = _.Ticks
    let v1738 : int64 = v1737 v1524
    let _run_target_args'_v1724 = v1738 
    #endif
#else
    let v1739 : (System.DateTime -> int64) = _.Ticks
    let v1740 : int64 = v1739 v1524
    let _run_target_args'_v1724 = v1740 
    #endif
    let v1741 : int64 = _run_target_args'_v1724 
    let v1762 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1763 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1524, v1741) v1762 
    let v1765 : System.TimeSpan = v1763 |> System.TimeSpan 
    let _run_target_args'_v1717 = v1765 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1774 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1775 : (System.DateTime -> int64) = _.Ticks
    let v1776 : int64 = v1775 v1524
    let _run_target_args'_v1774 = v1776 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1777 : (System.DateTime -> int64) = _.Ticks
    let v1778 : int64 = v1777 v1524
    let _run_target_args'_v1774 = v1778 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1780 : int64 = null |> unbox<int64>
    let _run_target_args'_v1774 = v1780 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1783 : (System.DateTime -> int64) = _.Ticks
    let v1784 : int64 = v1783 v1524
    let _run_target_args'_v1774 = v1784 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1785 : (System.DateTime -> int64) = _.Ticks
    let v1786 : int64 = v1785 v1524
    let _run_target_args'_v1774 = v1786 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1787 : (System.DateTime -> int64) = _.Ticks
    let v1788 : int64 = v1787 v1524
    let _run_target_args'_v1774 = v1788 
    #endif
#else
    let v1789 : (System.DateTime -> int64) = _.Ticks
    let v1790 : int64 = v1789 v1524
    let _run_target_args'_v1774 = v1790 
    #endif
    let v1791 : int64 = _run_target_args'_v1774 
    let v1812 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1813 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1524, v1791) v1812 
    let v1815 : System.TimeSpan = v1813 |> System.TimeSpan 
    let _run_target_args'_v1717 = v1815 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1819 : US2 = US2_2
    let v1820 : US3 = US3_4(v1819)
    let v1821 : string = $"date_time.get_utc_offset / target: {v1820}"
    let v1822 : System.TimeSpan = failwith<System.TimeSpan> v1821
    let _run_target_args'_v1717 = v1822 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1826 : US2 = US2_0
    let v1827 : US3 = US3_5(v1826)
    let v1828 : string = $"date_time.get_utc_offset / target: {v1827}"
    let v1829 : System.TimeSpan = failwith<System.TimeSpan> v1828
    let _run_target_args'_v1717 = v1829 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1833 : US2 = US2_0
    let v1834 : US3 = US3_6(v1833)
    let v1835 : string = $"date_time.get_utc_offset / target: {v1834}"
    let v1836 : System.TimeSpan = failwith<System.TimeSpan> v1835
    let _run_target_args'_v1717 = v1836 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1839 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1844 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1845 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1846 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1845 
    let _run_target_args'_v1844 = v1846 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1848 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1844 = v1848 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1852 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1844 = v1852 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1856 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1844 = v1856 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1860 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1844 = v1860 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1863 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1844 = v1863 
    #endif
#else
    let v1864 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1844 = v1864 
    #endif
    let v1865 : System.TimeZoneInfo = _run_target_args'_v1844 
    let v1874 : (System.DateTime -> System.TimeSpan) = v1839 v1865
    let v1875 : System.TimeSpan = v1874 v1524
    let _run_target_args'_v1717 = v1875 
    #endif
#else
    let v1876 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1881 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1882 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1883 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1882 
    let _run_target_args'_v1881 = v1883 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1885 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1885 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1889 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1889 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1893 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1893 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1897 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1897 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1900 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1881 = v1900 
    #endif
#else
    let v1901 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1881 = v1901 
    #endif
    let v1902 : System.TimeZoneInfo = _run_target_args'_v1881 
    let v1911 : (System.DateTime -> System.TimeSpan) = v1876 v1902
    let v1912 : System.TimeSpan = v1911 v1524
    let _run_target_args'_v1717 = v1912 
    #endif
    let v1913 : System.TimeSpan = _run_target_args'_v1717 
    let v1929 : (System.TimeSpan -> int32) = _.Hours
    let v1930 : int32 = v1929 v1913
    let v1933 : bool = v1930 > 0
    let v1934 : uint8 =
        if v1933 then
            1uy
        else
            0uy
    let v1935 : string = method2()
    (* run_target_args'
    let v1995 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1996 : string = "$0.toString($1)"
    let v1997 : string = Fable.Core.RustInterop.emitRustExpr struct (v1913, v1935) v1996 
    let _run_target_args'_v1995 = v1997 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1998 : string = "$0.toString($1)"
    let v1999 : string = Fable.Core.RustInterop.emitRustExpr struct (v1913, v1935) v1998 
    let _run_target_args'_v1995 = v1999 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2000 : string = "$0.toString($1)"
    let v2001 : string = Fable.Core.RustInterop.emitRustExpr struct (v1913, v1935) v2000 
    let _run_target_args'_v1995 = v2001 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2002 : string = v1913.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1995 = v2002 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2003 : string = v1913.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1995 = v2003 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2005 : string = v1913.ToString v1935 
    let _run_target_args'_v1995 = v2005 
    #endif
#else
    let v2064 : string = v1913.ToString v1935 
    let _run_target_args'_v1995 = v2064 
    #endif
    let v2122 : string = _run_target_args'_v1995 
    let v2241 : string = $"{v1934}{v2122.[0..1]}{v2122.[3..4]}"
    let v2243 : (System.Guid -> string) = _.ToString()
    let v2244 : string = v2243 v0
    let v2247 : int32 = v1675.Length
    let v2248 : int32 = v2241.Length
    let v2249 : int32 = v2247 + v2248
    let v2251 : (string -> int32) = String.length
    let v2252 : int32 = v2251 v2244
    let v2260 : int32 = v2249 |> int32 
    let v2273 : int32 = v2252 |> int32 
    let v2281 : int32 = v2273 - 1
    let v2283 : string = v2244.[int v2260..int v2281]
    let v2287 : string = $"{v1675}{v2241}{v2283}"
    (* run_target_args'
    let v2292 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2294 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2294 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2298 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2298 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2302 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2292 = v2302 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2306 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2306 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2310 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2310 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2314 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2314 
    #endif
#else
    let v2318 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2318 
    #endif
    let v2321 : System.Guid = _run_target_args'_v2292 
    let _run_target_args'_v677 = v2321 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2331 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v677 = v2331 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2334 : string = method3()
    let v2335 : bool = v2334 = ""
    let v2337 : string =
        if v2335 then
            let v2336 : string = "M-d-y hh:mm:ss tt"
            v2336
        else
            v2334
    let v2338 : (string -> string) = v1.ToString
    let v2339 : string = v2338 v2337
    (* run_target_args'
    let v2358 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2359 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2360 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2359 
    let _run_target_args'_v2358 = v2360 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2362 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2358 = v2362 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2366 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2358 = v2366 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2370 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2358 = v2370 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2374 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2358 = v2374 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2377 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2358 = v2377 
    #endif
#else
    let v2378 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2358 = v2378 
    #endif
    let v2379 : System.TimeZoneInfo = _run_target_args'_v2358 
    (* run_target_args'
    let v2395 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2402 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2403 : (System.DateTime -> int64) = _.Ticks
    let v2404 : int64 = v2403 v1
    let _run_target_args'_v2402 = v2404 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2405 : (System.DateTime -> int64) = _.Ticks
    let v2406 : int64 = v2405 v1
    let _run_target_args'_v2402 = v2406 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2408 : int64 = null |> unbox<int64>
    let _run_target_args'_v2402 = v2408 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2411 : (System.DateTime -> int64) = _.Ticks
    let v2412 : int64 = v2411 v1
    let _run_target_args'_v2402 = v2412 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2413 : (System.DateTime -> int64) = _.Ticks
    let v2414 : int64 = v2413 v1
    let _run_target_args'_v2402 = v2414 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2415 : (System.DateTime -> int64) = _.Ticks
    let v2416 : int64 = v2415 v1
    let _run_target_args'_v2402 = v2416 
    #endif
#else
    let v2417 : (System.DateTime -> int64) = _.Ticks
    let v2418 : int64 = v2417 v1
    let _run_target_args'_v2402 = v2418 
    #endif
    let v2419 : int64 = _run_target_args'_v2402 
    let v2440 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2441 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2419) v2440 
    let v2443 : System.TimeSpan = v2441 |> System.TimeSpan 
    let _run_target_args'_v2395 = v2443 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2452 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2453 : (System.DateTime -> int64) = _.Ticks
    let v2454 : int64 = v2453 v1
    let _run_target_args'_v2452 = v2454 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2455 : (System.DateTime -> int64) = _.Ticks
    let v2456 : int64 = v2455 v1
    let _run_target_args'_v2452 = v2456 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2458 : int64 = null |> unbox<int64>
    let _run_target_args'_v2452 = v2458 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2461 : (System.DateTime -> int64) = _.Ticks
    let v2462 : int64 = v2461 v1
    let _run_target_args'_v2452 = v2462 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2463 : (System.DateTime -> int64) = _.Ticks
    let v2464 : int64 = v2463 v1
    let _run_target_args'_v2452 = v2464 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2465 : (System.DateTime -> int64) = _.Ticks
    let v2466 : int64 = v2465 v1
    let _run_target_args'_v2452 = v2466 
    #endif
#else
    let v2467 : (System.DateTime -> int64) = _.Ticks
    let v2468 : int64 = v2467 v1
    let _run_target_args'_v2452 = v2468 
    #endif
    let v2469 : int64 = _run_target_args'_v2452 
    let v2490 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2491 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2469) v2490 
    let v2493 : System.TimeSpan = v2491 |> System.TimeSpan 
    let _run_target_args'_v2395 = v2493 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2497 : US2 = US2_2
    let v2498 : US3 = US3_4(v2497)
    let v2499 : string = $"date_time.get_utc_offset / target: {v2498}"
    let v2500 : System.TimeSpan = failwith<System.TimeSpan> v2499
    let _run_target_args'_v2395 = v2500 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2504 : US2 = US2_0
    let v2505 : US3 = US3_5(v2504)
    let v2506 : string = $"date_time.get_utc_offset / target: {v2505}"
    let v2507 : System.TimeSpan = failwith<System.TimeSpan> v2506
    let _run_target_args'_v2395 = v2507 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2511 : US2 = US2_0
    let v2512 : US3 = US3_6(v2511)
    let v2513 : string = $"date_time.get_utc_offset / target: {v2512}"
    let v2514 : System.TimeSpan = failwith<System.TimeSpan> v2513
    let _run_target_args'_v2395 = v2514 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2517 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2522 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2523 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2524 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2523 
    let _run_target_args'_v2522 = v2524 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2526 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2522 = v2526 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2530 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2522 = v2530 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2534 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2522 = v2534 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2538 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2522 = v2538 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2541 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2522 = v2541 
    #endif
#else
    let v2542 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2522 = v2542 
    #endif
    let v2543 : System.TimeZoneInfo = _run_target_args'_v2522 
    let v2552 : (System.DateTime -> System.TimeSpan) = v2517 v2543
    let v2553 : System.TimeSpan = v2552 v1
    let _run_target_args'_v2395 = v2553 
    #endif
#else
    let v2554 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2559 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2560 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2561 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2560 
    let _run_target_args'_v2559 = v2561 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2563 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2559 = v2563 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2567 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2559 = v2567 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2571 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2559 = v2571 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2575 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2559 = v2575 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2578 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2559 = v2578 
    #endif
#else
    let v2579 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2559 = v2579 
    #endif
    let v2580 : System.TimeZoneInfo = _run_target_args'_v2559 
    let v2589 : (System.DateTime -> System.TimeSpan) = v2554 v2580
    let v2590 : System.TimeSpan = v2589 v1
    let _run_target_args'_v2395 = v2590 
    #endif
    let v2591 : System.TimeSpan = _run_target_args'_v2395 
    let v2607 : (System.TimeSpan -> int32) = _.Hours
    let v2608 : int32 = v2607 v2591
    let v2611 : bool = v2608 > 0
    let v2612 : uint8 =
        if v2611 then
            1uy
        else
            0uy
    let v2613 : string = method4()
    (* run_target_args'
    let v2673 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2674 : string = "$0.toString($1)"
    let v2675 : string = Fable.Core.RustInterop.emitRustExpr struct (v2591, v2613) v2674 
    let _run_target_args'_v2673 = v2675 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2676 : string = "$0.toString($1)"
    let v2677 : string = Fable.Core.RustInterop.emitRustExpr struct (v2591, v2613) v2676 
    let _run_target_args'_v2673 = v2677 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2678 : string = "$0.toString($1)"
    let v2679 : string = Fable.Core.RustInterop.emitRustExpr struct (v2591, v2613) v2678 
    let _run_target_args'_v2673 = v2679 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2680 : string = v2591.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2673 = v2680 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2681 : string = v2591.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2673 = v2681 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2683 : string = v2591.ToString v2613 
    let _run_target_args'_v2673 = v2683 
    #endif
#else
    let v2742 : string = v2591.ToString v2613 
    let _run_target_args'_v2673 = v2742 
    #endif
    let v2800 : string = _run_target_args'_v2673 
    let v2919 : string = $"{v2612}{v2800}"
    let v2921 : (System.Guid -> string) = _.ToString()
    let v2922 : string = v2921 v0
    let v2925 : int32 = v2339.Length
    let v2926 : int32 = v2919.Length
    let v2927 : int32 = v2925 + v2926
    let v2929 : (string -> int32) = String.length
    let v2930 : int32 = v2929 v2922
    let v2938 : int32 = v2927 |> int32 
    let v2951 : int32 = v2930 |> int32 
    let v2959 : int32 = v2951 - 1
    let v2961 : string = v2922.[int v2938..int v2959]
    let v2965 : string = $"{v2339}{v2919}{v2961}"
    (* run_target_args'
    let v2970 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2972 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2972 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2976 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2976 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2980 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2970 = v2980 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2984 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2984 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2988 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2988 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2992 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2992 
    #endif
#else
    let v2996 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2996 
    #endif
    let v2999 : System.Guid = _run_target_args'_v2970 
    let _run_target_args'_v677 = v2999 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3008 : string = method3()
    let v3009 : bool = v3008 = ""
    let v3011 : string =
        if v3009 then
            let v3010 : string = "M-d-y hh:mm:ss tt"
            v3010
        else
            v3008
    let v3012 : (string -> string) = v1.ToString
    let v3013 : string = v3012 v3011
    (* run_target_args'
    let v3032 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3033 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3034 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3033 
    let _run_target_args'_v3032 = v3034 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3036 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3032 = v3036 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3040 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3032 = v3040 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3044 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3032 = v3044 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3048 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3032 = v3048 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3051 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3032 = v3051 
    #endif
#else
    let v3052 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3032 = v3052 
    #endif
    let v3053 : System.TimeZoneInfo = _run_target_args'_v3032 
    (* run_target_args'
    let v3069 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3076 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3077 : (System.DateTime -> int64) = _.Ticks
    let v3078 : int64 = v3077 v1
    let _run_target_args'_v3076 = v3078 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3079 : (System.DateTime -> int64) = _.Ticks
    let v3080 : int64 = v3079 v1
    let _run_target_args'_v3076 = v3080 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3082 : int64 = null |> unbox<int64>
    let _run_target_args'_v3076 = v3082 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3085 : (System.DateTime -> int64) = _.Ticks
    let v3086 : int64 = v3085 v1
    let _run_target_args'_v3076 = v3086 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3087 : (System.DateTime -> int64) = _.Ticks
    let v3088 : int64 = v3087 v1
    let _run_target_args'_v3076 = v3088 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3089 : (System.DateTime -> int64) = _.Ticks
    let v3090 : int64 = v3089 v1
    let _run_target_args'_v3076 = v3090 
    #endif
#else
    let v3091 : (System.DateTime -> int64) = _.Ticks
    let v3092 : int64 = v3091 v1
    let _run_target_args'_v3076 = v3092 
    #endif
    let v3093 : int64 = _run_target_args'_v3076 
    let v3114 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3115 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3093) v3114 
    let v3117 : System.TimeSpan = v3115 |> System.TimeSpan 
    let _run_target_args'_v3069 = v3117 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3126 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3127 : (System.DateTime -> int64) = _.Ticks
    let v3128 : int64 = v3127 v1
    let _run_target_args'_v3126 = v3128 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3129 : (System.DateTime -> int64) = _.Ticks
    let v3130 : int64 = v3129 v1
    let _run_target_args'_v3126 = v3130 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3132 : int64 = null |> unbox<int64>
    let _run_target_args'_v3126 = v3132 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3135 : (System.DateTime -> int64) = _.Ticks
    let v3136 : int64 = v3135 v1
    let _run_target_args'_v3126 = v3136 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3137 : (System.DateTime -> int64) = _.Ticks
    let v3138 : int64 = v3137 v1
    let _run_target_args'_v3126 = v3138 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3139 : (System.DateTime -> int64) = _.Ticks
    let v3140 : int64 = v3139 v1
    let _run_target_args'_v3126 = v3140 
    #endif
#else
    let v3141 : (System.DateTime -> int64) = _.Ticks
    let v3142 : int64 = v3141 v1
    let _run_target_args'_v3126 = v3142 
    #endif
    let v3143 : int64 = _run_target_args'_v3126 
    let v3164 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3165 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3143) v3164 
    let v3167 : System.TimeSpan = v3165 |> System.TimeSpan 
    let _run_target_args'_v3069 = v3167 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3171 : US2 = US2_2
    let v3172 : US3 = US3_4(v3171)
    let v3173 : string = $"date_time.get_utc_offset / target: {v3172}"
    let v3174 : System.TimeSpan = failwith<System.TimeSpan> v3173
    let _run_target_args'_v3069 = v3174 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3178 : US2 = US2_0
    let v3179 : US3 = US3_5(v3178)
    let v3180 : string = $"date_time.get_utc_offset / target: {v3179}"
    let v3181 : System.TimeSpan = failwith<System.TimeSpan> v3180
    let _run_target_args'_v3069 = v3181 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3185 : US2 = US2_0
    let v3186 : US3 = US3_6(v3185)
    let v3187 : string = $"date_time.get_utc_offset / target: {v3186}"
    let v3188 : System.TimeSpan = failwith<System.TimeSpan> v3187
    let _run_target_args'_v3069 = v3188 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3191 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3196 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3197 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3198 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3197 
    let _run_target_args'_v3196 = v3198 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3200 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3196 = v3200 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3204 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3196 = v3204 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3208 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3196 = v3208 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3212 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3196 = v3212 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3215 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3196 = v3215 
    #endif
#else
    let v3216 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3196 = v3216 
    #endif
    let v3217 : System.TimeZoneInfo = _run_target_args'_v3196 
    let v3226 : (System.DateTime -> System.TimeSpan) = v3191 v3217
    let v3227 : System.TimeSpan = v3226 v1
    let _run_target_args'_v3069 = v3227 
    #endif
#else
    let v3228 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3233 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3234 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3235 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3234 
    let _run_target_args'_v3233 = v3235 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3237 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3233 = v3237 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3241 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3233 = v3241 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3245 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3233 = v3245 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3249 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3233 = v3249 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3252 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3233 = v3252 
    #endif
#else
    let v3253 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3233 = v3253 
    #endif
    let v3254 : System.TimeZoneInfo = _run_target_args'_v3233 
    let v3263 : (System.DateTime -> System.TimeSpan) = v3228 v3254
    let v3264 : System.TimeSpan = v3263 v1
    let _run_target_args'_v3069 = v3264 
    #endif
    let v3265 : System.TimeSpan = _run_target_args'_v3069 
    let v3281 : (System.TimeSpan -> int32) = _.Hours
    let v3282 : int32 = v3281 v3265
    let v3285 : bool = v3282 > 0
    let v3286 : uint8 =
        if v3285 then
            1uy
        else
            0uy
    let v3287 : string = method4()
    (* run_target_args'
    let v3347 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3348 : string = "$0.toString($1)"
    let v3349 : string = Fable.Core.RustInterop.emitRustExpr struct (v3265, v3287) v3348 
    let _run_target_args'_v3347 = v3349 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3350 : string = "$0.toString($1)"
    let v3351 : string = Fable.Core.RustInterop.emitRustExpr struct (v3265, v3287) v3350 
    let _run_target_args'_v3347 = v3351 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3352 : string = "$0.toString($1)"
    let v3353 : string = Fable.Core.RustInterop.emitRustExpr struct (v3265, v3287) v3352 
    let _run_target_args'_v3347 = v3353 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3354 : string = v3265.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3347 = v3354 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3355 : string = v3265.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3347 = v3355 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3357 : string = v3265.ToString v3287 
    let _run_target_args'_v3347 = v3357 
    #endif
#else
    let v3416 : string = v3265.ToString v3287 
    let _run_target_args'_v3347 = v3416 
    #endif
    let v3474 : string = _run_target_args'_v3347 
    let v3593 : string = $"{v3286}{v3474}"
    let v3595 : (System.Guid -> string) = _.ToString()
    let v3596 : string = v3595 v0
    let v3599 : int32 = v3013.Length
    let v3600 : int32 = v3593.Length
    let v3601 : int32 = v3599 + v3600
    let v3603 : (string -> int32) = String.length
    let v3604 : int32 = v3603 v3596
    let v3612 : int32 = v3601 |> int32 
    let v3625 : int32 = v3604 |> int32 
    let v3633 : int32 = v3625 - 1
    let v3635 : string = v3596.[int v3612..int v3633]
    let v3639 : string = $"{v3013}{v3593}{v3635}"
    (* run_target_args'
    let v3644 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3646 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3646 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3650 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3650 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3654 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3644 = v3654 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3658 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3658 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3662 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3662 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3666 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3666 
    #endif
#else
    let v3670 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3670 
    #endif
    let v3673 : System.Guid = _run_target_args'_v3644 
    let _run_target_args'_v677 = v3673 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3682 : string = method3()
    let v3683 : bool = v3682 = ""
    let v3685 : string =
        if v3683 then
            let v3684 : string = "M-d-y hh:mm:ss tt"
            v3684
        else
            v3682
    let v3686 : (string -> string) = v1.ToString
    let v3687 : string = v3686 v3685
    (* run_target_args'
    let v3706 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3707 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3708 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3707 
    let _run_target_args'_v3706 = v3708 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3710 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3706 = v3710 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3714 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3706 = v3714 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3718 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3706 = v3718 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3722 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3706 = v3722 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3725 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3706 = v3725 
    #endif
#else
    let v3726 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3706 = v3726 
    #endif
    let v3727 : System.TimeZoneInfo = _run_target_args'_v3706 
    (* run_target_args'
    let v3743 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3750 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3751 : (System.DateTime -> int64) = _.Ticks
    let v3752 : int64 = v3751 v1
    let _run_target_args'_v3750 = v3752 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3753 : (System.DateTime -> int64) = _.Ticks
    let v3754 : int64 = v3753 v1
    let _run_target_args'_v3750 = v3754 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3756 : int64 = null |> unbox<int64>
    let _run_target_args'_v3750 = v3756 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3759 : (System.DateTime -> int64) = _.Ticks
    let v3760 : int64 = v3759 v1
    let _run_target_args'_v3750 = v3760 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3761 : (System.DateTime -> int64) = _.Ticks
    let v3762 : int64 = v3761 v1
    let _run_target_args'_v3750 = v3762 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3763 : (System.DateTime -> int64) = _.Ticks
    let v3764 : int64 = v3763 v1
    let _run_target_args'_v3750 = v3764 
    #endif
#else
    let v3765 : (System.DateTime -> int64) = _.Ticks
    let v3766 : int64 = v3765 v1
    let _run_target_args'_v3750 = v3766 
    #endif
    let v3767 : int64 = _run_target_args'_v3750 
    let v3788 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3789 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3767) v3788 
    let v3791 : System.TimeSpan = v3789 |> System.TimeSpan 
    let _run_target_args'_v3743 = v3791 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3800 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3801 : (System.DateTime -> int64) = _.Ticks
    let v3802 : int64 = v3801 v1
    let _run_target_args'_v3800 = v3802 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3803 : (System.DateTime -> int64) = _.Ticks
    let v3804 : int64 = v3803 v1
    let _run_target_args'_v3800 = v3804 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3806 : int64 = null |> unbox<int64>
    let _run_target_args'_v3800 = v3806 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3809 : (System.DateTime -> int64) = _.Ticks
    let v3810 : int64 = v3809 v1
    let _run_target_args'_v3800 = v3810 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3811 : (System.DateTime -> int64) = _.Ticks
    let v3812 : int64 = v3811 v1
    let _run_target_args'_v3800 = v3812 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3813 : (System.DateTime -> int64) = _.Ticks
    let v3814 : int64 = v3813 v1
    let _run_target_args'_v3800 = v3814 
    #endif
#else
    let v3815 : (System.DateTime -> int64) = _.Ticks
    let v3816 : int64 = v3815 v1
    let _run_target_args'_v3800 = v3816 
    #endif
    let v3817 : int64 = _run_target_args'_v3800 
    let v3838 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3839 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3817) v3838 
    let v3841 : System.TimeSpan = v3839 |> System.TimeSpan 
    let _run_target_args'_v3743 = v3841 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3845 : US2 = US2_2
    let v3846 : US3 = US3_4(v3845)
    let v3847 : string = $"date_time.get_utc_offset / target: {v3846}"
    let v3848 : System.TimeSpan = failwith<System.TimeSpan> v3847
    let _run_target_args'_v3743 = v3848 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3852 : US2 = US2_0
    let v3853 : US3 = US3_5(v3852)
    let v3854 : string = $"date_time.get_utc_offset / target: {v3853}"
    let v3855 : System.TimeSpan = failwith<System.TimeSpan> v3854
    let _run_target_args'_v3743 = v3855 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3859 : US2 = US2_0
    let v3860 : US3 = US3_6(v3859)
    let v3861 : string = $"date_time.get_utc_offset / target: {v3860}"
    let v3862 : System.TimeSpan = failwith<System.TimeSpan> v3861
    let _run_target_args'_v3743 = v3862 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3865 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3870 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3871 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3872 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3871 
    let _run_target_args'_v3870 = v3872 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3874 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3870 = v3874 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3878 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3870 = v3878 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3882 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3870 = v3882 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3886 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3870 = v3886 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3889 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3870 = v3889 
    #endif
#else
    let v3890 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3870 = v3890 
    #endif
    let v3891 : System.TimeZoneInfo = _run_target_args'_v3870 
    let v3900 : (System.DateTime -> System.TimeSpan) = v3865 v3891
    let v3901 : System.TimeSpan = v3900 v1
    let _run_target_args'_v3743 = v3901 
    #endif
#else
    let v3902 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3907 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3908 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3909 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3908 
    let _run_target_args'_v3907 = v3909 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3911 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3907 = v3911 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3915 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3907 = v3915 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3919 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3907 = v3919 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3923 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3907 = v3923 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3926 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3907 = v3926 
    #endif
#else
    let v3927 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3907 = v3927 
    #endif
    let v3928 : System.TimeZoneInfo = _run_target_args'_v3907 
    let v3937 : (System.DateTime -> System.TimeSpan) = v3902 v3928
    let v3938 : System.TimeSpan = v3937 v1
    let _run_target_args'_v3743 = v3938 
    #endif
    let v3939 : System.TimeSpan = _run_target_args'_v3743 
    let v3955 : (System.TimeSpan -> int32) = _.Hours
    let v3956 : int32 = v3955 v3939
    let v3959 : bool = v3956 > 0
    let v3960 : uint8 =
        if v3959 then
            1uy
        else
            0uy
    let v3961 : string = method4()
    (* run_target_args'
    let v4021 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4022 : string = "$0.toString($1)"
    let v4023 : string = Fable.Core.RustInterop.emitRustExpr struct (v3939, v3961) v4022 
    let _run_target_args'_v4021 = v4023 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4024 : string = "$0.toString($1)"
    let v4025 : string = Fable.Core.RustInterop.emitRustExpr struct (v3939, v3961) v4024 
    let _run_target_args'_v4021 = v4025 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4026 : string = "$0.toString($1)"
    let v4027 : string = Fable.Core.RustInterop.emitRustExpr struct (v3939, v3961) v4026 
    let _run_target_args'_v4021 = v4027 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4028 : string = v3939.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4021 = v4028 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4029 : string = v3939.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4021 = v4029 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4031 : string = v3939.ToString v3961 
    let _run_target_args'_v4021 = v4031 
    #endif
#else
    let v4090 : string = v3939.ToString v3961 
    let _run_target_args'_v4021 = v4090 
    #endif
    let v4148 : string = _run_target_args'_v4021 
    let v4267 : string = $"{v3960}{v4148}"
    let v4269 : (System.Guid -> string) = _.ToString()
    let v4270 : string = v4269 v0
    let v4273 : int32 = v3687.Length
    let v4274 : int32 = v4267.Length
    let v4275 : int32 = v4273 + v4274
    let v4277 : (string -> int32) = String.length
    let v4278 : int32 = v4277 v4270
    let v4286 : int32 = v4275 |> int32 
    let v4299 : int32 = v4278 |> int32 
    let v4307 : int32 = v4299 - 1
    let v4309 : string = v4270.[int v4286..int v4307]
    let v4313 : string = $"{v3687}{v4267}{v4309}"
    (* run_target_args'
    let v4318 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4320 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4320 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4324 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4324 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4328 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4318 = v4328 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4332 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4332 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4336 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4336 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4340 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4340 
    #endif
#else
    let v4344 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4344 
    #endif
    let v4347 : System.Guid = _run_target_args'_v4318 
    let _run_target_args'_v677 = v4347 
    #endif
#else
    let v4356 : string = method3()
    let v4357 : bool = v4356 = ""
    let v4359 : string =
        if v4357 then
            let v4358 : string = "M-d-y hh:mm:ss tt"
            v4358
        else
            v4356
    let v4360 : (string -> string) = v1.ToString
    let v4361 : string = v4360 v4359
    (* run_target_args'
    let v4380 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4381 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4382 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4381 
    let _run_target_args'_v4380 = v4382 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4384 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4380 = v4384 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4388 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4380 = v4388 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4392 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4380 = v4392 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4396 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4380 = v4396 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4399 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4380 = v4399 
    #endif
#else
    let v4400 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4380 = v4400 
    #endif
    let v4401 : System.TimeZoneInfo = _run_target_args'_v4380 
    (* run_target_args'
    let v4417 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v4424 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4425 : (System.DateTime -> int64) = _.Ticks
    let v4426 : int64 = v4425 v1
    let _run_target_args'_v4424 = v4426 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4427 : (System.DateTime -> int64) = _.Ticks
    let v4428 : int64 = v4427 v1
    let _run_target_args'_v4424 = v4428 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4430 : int64 = null |> unbox<int64>
    let _run_target_args'_v4424 = v4430 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4433 : (System.DateTime -> int64) = _.Ticks
    let v4434 : int64 = v4433 v1
    let _run_target_args'_v4424 = v4434 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4435 : (System.DateTime -> int64) = _.Ticks
    let v4436 : int64 = v4435 v1
    let _run_target_args'_v4424 = v4436 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4437 : (System.DateTime -> int64) = _.Ticks
    let v4438 : int64 = v4437 v1
    let _run_target_args'_v4424 = v4438 
    #endif
#else
    let v4439 : (System.DateTime -> int64) = _.Ticks
    let v4440 : int64 = v4439 v1
    let _run_target_args'_v4424 = v4440 
    #endif
    let v4441 : int64 = _run_target_args'_v4424 
    let v4462 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4463 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4441) v4462 
    let v4465 : System.TimeSpan = v4463 |> System.TimeSpan 
    let _run_target_args'_v4417 = v4465 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4474 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4475 : (System.DateTime -> int64) = _.Ticks
    let v4476 : int64 = v4475 v1
    let _run_target_args'_v4474 = v4476 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4477 : (System.DateTime -> int64) = _.Ticks
    let v4478 : int64 = v4477 v1
    let _run_target_args'_v4474 = v4478 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4480 : int64 = null |> unbox<int64>
    let _run_target_args'_v4474 = v4480 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4483 : (System.DateTime -> int64) = _.Ticks
    let v4484 : int64 = v4483 v1
    let _run_target_args'_v4474 = v4484 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4485 : (System.DateTime -> int64) = _.Ticks
    let v4486 : int64 = v4485 v1
    let _run_target_args'_v4474 = v4486 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4487 : (System.DateTime -> int64) = _.Ticks
    let v4488 : int64 = v4487 v1
    let _run_target_args'_v4474 = v4488 
    #endif
#else
    let v4489 : (System.DateTime -> int64) = _.Ticks
    let v4490 : int64 = v4489 v1
    let _run_target_args'_v4474 = v4490 
    #endif
    let v4491 : int64 = _run_target_args'_v4474 
    let v4512 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4513 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4491) v4512 
    let v4515 : System.TimeSpan = v4513 |> System.TimeSpan 
    let _run_target_args'_v4417 = v4515 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4519 : US2 = US2_2
    let v4520 : US3 = US3_4(v4519)
    let v4521 : string = $"date_time.get_utc_offset / target: {v4520}"
    let v4522 : System.TimeSpan = failwith<System.TimeSpan> v4521
    let _run_target_args'_v4417 = v4522 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4526 : US2 = US2_0
    let v4527 : US3 = US3_5(v4526)
    let v4528 : string = $"date_time.get_utc_offset / target: {v4527}"
    let v4529 : System.TimeSpan = failwith<System.TimeSpan> v4528
    let _run_target_args'_v4417 = v4529 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4533 : US2 = US2_0
    let v4534 : US3 = US3_6(v4533)
    let v4535 : string = $"date_time.get_utc_offset / target: {v4534}"
    let v4536 : System.TimeSpan = failwith<System.TimeSpan> v4535
    let _run_target_args'_v4417 = v4536 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4539 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4544 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4545 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4546 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4545 
    let _run_target_args'_v4544 = v4546 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4548 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4544 = v4548 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4552 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4544 = v4552 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4556 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4544 = v4556 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4560 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4544 = v4560 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4563 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4544 = v4563 
    #endif
#else
    let v4564 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4544 = v4564 
    #endif
    let v4565 : System.TimeZoneInfo = _run_target_args'_v4544 
    let v4574 : (System.DateTime -> System.TimeSpan) = v4539 v4565
    let v4575 : System.TimeSpan = v4574 v1
    let _run_target_args'_v4417 = v4575 
    #endif
#else
    let v4576 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4581 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4582 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4583 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4582 
    let _run_target_args'_v4581 = v4583 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4585 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4581 = v4585 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4589 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4581 = v4589 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4593 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4581 = v4593 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4597 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4581 = v4597 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4600 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4581 = v4600 
    #endif
#else
    let v4601 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4581 = v4601 
    #endif
    let v4602 : System.TimeZoneInfo = _run_target_args'_v4581 
    let v4611 : (System.DateTime -> System.TimeSpan) = v4576 v4602
    let v4612 : System.TimeSpan = v4611 v1
    let _run_target_args'_v4417 = v4612 
    #endif
    let v4613 : System.TimeSpan = _run_target_args'_v4417 
    let v4629 : (System.TimeSpan -> int32) = _.Hours
    let v4630 : int32 = v4629 v4613
    let v4633 : bool = v4630 > 0
    let v4634 : uint8 =
        if v4633 then
            1uy
        else
            0uy
    let v4635 : string = method4()
    (* run_target_args'
    let v4695 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4696 : string = "$0.toString($1)"
    let v4697 : string = Fable.Core.RustInterop.emitRustExpr struct (v4613, v4635) v4696 
    let _run_target_args'_v4695 = v4697 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4698 : string = "$0.toString($1)"
    let v4699 : string = Fable.Core.RustInterop.emitRustExpr struct (v4613, v4635) v4698 
    let _run_target_args'_v4695 = v4699 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4700 : string = "$0.toString($1)"
    let v4701 : string = Fable.Core.RustInterop.emitRustExpr struct (v4613, v4635) v4700 
    let _run_target_args'_v4695 = v4701 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4702 : string = v4613.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4695 = v4702 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4703 : string = v4613.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4695 = v4703 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4705 : string = v4613.ToString v4635 
    let _run_target_args'_v4695 = v4705 
    #endif
#else
    let v4764 : string = v4613.ToString v4635 
    let _run_target_args'_v4695 = v4764 
    #endif
    let v4822 : string = _run_target_args'_v4695 
    let v4941 : string = $"{v4634}{v4822}"
    let v4943 : (System.Guid -> string) = _.ToString()
    let v4944 : string = v4943 v0
    let v4947 : int32 = v4361.Length
    let v4948 : int32 = v4941.Length
    let v4949 : int32 = v4947 + v4948
    let v4951 : (string -> int32) = String.length
    let v4952 : int32 = v4951 v4944
    let v4960 : int32 = v4949 |> int32 
    let v4973 : int32 = v4952 |> int32 
    let v4981 : int32 = v4973 - 1
    let v4983 : string = v4944.[int v4960..int v4981]
    let v4987 : string = $"{v4361}{v4941}{v4983}"
    (* run_target_args'
    let v4992 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4994 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v4994 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4998 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v4998 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5002 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4992 = v5002 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5006 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v5006 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5010 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v5010 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5014 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v5014 
    #endif
#else
    let v5018 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v5018 
    #endif
    let v5021 : System.Guid = _run_target_args'_v4992 
    let _run_target_args'_v677 = v5021 
    #endif
    let v5030 : System.Guid = _run_target_args'_v677 
    v5030
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
