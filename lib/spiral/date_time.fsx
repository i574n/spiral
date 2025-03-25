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
    let v599 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v605 : System.DateTime = System.DateTime.UnixEpoch
    let v609 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v610 : System.DateTime = v609 v605
    let v614 : System.DateTimeKind = System.DateTimeKind.Local
    let v615 : System.DateTime = System.DateTime.SpecifyKind (v1, v614)
    let v619 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v620 : System.DateTime = v619 v615
    (* run_target_args'
    let v629 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v630 : (System.DateTime -> int64) = _.Ticks
    let v631 : int64 = v630 v620
    let _run_target_args'_v629 = v631 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v632 : (System.DateTime -> int64) = _.Ticks
    let v633 : int64 = v632 v620
    let _run_target_args'_v629 = v633 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v635 : int64 = null |> unbox<int64>
    let _run_target_args'_v629 = v635 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v638 : (System.DateTime -> int64) = _.Ticks
    let v639 : int64 = v638 v620
    let _run_target_args'_v629 = v639 
    #endif
#if FABLE_COMPILER_PYTHON
    let v640 : (System.DateTime -> int64) = _.Ticks
    let v641 : int64 = v640 v620
    let _run_target_args'_v629 = v641 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v642 : (System.DateTime -> int64) = _.Ticks
    let v643 : int64 = v642 v620
    let _run_target_args'_v629 = v643 
    #endif
#else
    let v644 : (System.DateTime -> int64) = _.Ticks
    let v645 : int64 = v644 v620
    let _run_target_args'_v629 = v645 
    #endif
    let v646 : int64 = _run_target_args'_v629 
    (* run_target_args'
    let v672 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v673 : (System.DateTime -> int64) = _.Ticks
    let v674 : int64 = v673 v610
    let _run_target_args'_v672 = v674 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v675 : (System.DateTime -> int64) = _.Ticks
    let v676 : int64 = v675 v610
    let _run_target_args'_v672 = v676 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v678 : int64 = null |> unbox<int64>
    let _run_target_args'_v672 = v678 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v681 : (System.DateTime -> int64) = _.Ticks
    let v682 : int64 = v681 v610
    let _run_target_args'_v672 = v682 
    #endif
#if FABLE_COMPILER_PYTHON
    let v683 : (System.DateTime -> int64) = _.Ticks
    let v684 : int64 = v683 v610
    let _run_target_args'_v672 = v684 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v685 : (System.DateTime -> int64) = _.Ticks
    let v686 : int64 = v685 v610
    let _run_target_args'_v672 = v686 
    #endif
#else
    let v687 : (System.DateTime -> int64) = _.Ticks
    let v688 : int64 = v687 v610
    let _run_target_args'_v672 = v688 
    #endif
    let v689 : int64 = _run_target_args'_v672 
    let v710 : int64 = v646 |> int64 
    let v714 : int64 = v689 |> int64 
    let v717 : int64 = v710 - v714
    let v718 : int64 = v717 / 10L
    let v719 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v720 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v718 v719 
    let v723 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v724 : US0 option = v720 |> Option.map v723 
    let v744 : US0 = US0_1
    let v745 : US0 = v724 |> Option.defaultValue v744 
    let v765 : US1 =
        match v745 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v749) -> (* Some *)
            let v750 : string = "$0.naive_utc()"
            let v751 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v749 v750 
            let v752 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v753 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v751 v752 
            let v754 : string = "%Y%m%d-%H%M-%S%f"
            let v755 : string = "r#\"" + v754 + "\"#"
            let v756 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v755 
            let v757 : string = "$0.format($1).to_string()"
            let v758 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v753, v756) v757 
            let v759 : string = "fable_library_rust::String_::fromString($0)"
            let v760 : string = Fable.Core.RustInterop.emitRustExpr v758 v759 
            let v761 : string = $"{v760.[0..17]}-{v760.[18..21]}-{v760.[22]}"
            US1_0(v761)
    let v769 : string =
        match v765 with
        | US1_1 -> (* None *)
            let v767 : string = ""
            v767
        | US1_0(v766) -> (* Some *)
            v766
    (* run_target_args'
    let v774 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v775 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v776 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v775 
    let _run_target_args'_v774 = v776 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v778 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v774 = v778 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v782 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v774 = v782 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v786 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v774 = v786 
    #endif
#if FABLE_COMPILER_PYTHON
    let v790 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v774 = v790 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v793 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v774 = v793 
    #endif
#else
    let v794 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v774 = v794 
    #endif
    let v795 : System.TimeZoneInfo = _run_target_args'_v774 
    (* run_target_args'
    let v808 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v815 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v816 : (System.DateTime -> int64) = _.Ticks
    let v817 : int64 = v816 v620
    let _run_target_args'_v815 = v817 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v818 : (System.DateTime -> int64) = _.Ticks
    let v819 : int64 = v818 v620
    let _run_target_args'_v815 = v819 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v821 : int64 = null |> unbox<int64>
    let _run_target_args'_v815 = v821 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v824 : (System.DateTime -> int64) = _.Ticks
    let v825 : int64 = v824 v620
    let _run_target_args'_v815 = v825 
    #endif
#if FABLE_COMPILER_PYTHON
    let v826 : (System.DateTime -> int64) = _.Ticks
    let v827 : int64 = v826 v620
    let _run_target_args'_v815 = v827 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v828 : (System.DateTime -> int64) = _.Ticks
    let v829 : int64 = v828 v620
    let _run_target_args'_v815 = v829 
    #endif
#else
    let v830 : (System.DateTime -> int64) = _.Ticks
    let v831 : int64 = v830 v620
    let _run_target_args'_v815 = v831 
    #endif
    let v832 : int64 = _run_target_args'_v815 
    let v852 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v853 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v620, v832) v852 
    let v855 : System.TimeSpan = v853 |> System.TimeSpan 
    let _run_target_args'_v808 = v855 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v864 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v865 : (System.DateTime -> int64) = _.Ticks
    let v866 : int64 = v865 v620
    let _run_target_args'_v864 = v866 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v867 : (System.DateTime -> int64) = _.Ticks
    let v868 : int64 = v867 v620
    let _run_target_args'_v864 = v868 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v870 : int64 = null |> unbox<int64>
    let _run_target_args'_v864 = v870 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v873 : (System.DateTime -> int64) = _.Ticks
    let v874 : int64 = v873 v620
    let _run_target_args'_v864 = v874 
    #endif
#if FABLE_COMPILER_PYTHON
    let v875 : (System.DateTime -> int64) = _.Ticks
    let v876 : int64 = v875 v620
    let _run_target_args'_v864 = v876 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v877 : (System.DateTime -> int64) = _.Ticks
    let v878 : int64 = v877 v620
    let _run_target_args'_v864 = v878 
    #endif
#else
    let v879 : (System.DateTime -> int64) = _.Ticks
    let v880 : int64 = v879 v620
    let _run_target_args'_v864 = v880 
    #endif
    let v881 : int64 = _run_target_args'_v864 
    let v901 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v902 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v620, v881) v901 
    let v904 : System.TimeSpan = v902 |> System.TimeSpan 
    let _run_target_args'_v808 = v904 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v908 : US2 = US2_2
    let v909 : US3 = US3_3(v908)
    let v910 : string = $"date_time.get_utc_offset / target: {v909}"
    let v911 : System.TimeSpan = failwith<System.TimeSpan> v910
    let _run_target_args'_v808 = v911 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v915 : US2 = US2_0
    let v916 : US3 = US3_4(v915)
    let v917 : string = $"date_time.get_utc_offset / target: {v916}"
    let v918 : System.TimeSpan = failwith<System.TimeSpan> v917
    let _run_target_args'_v808 = v918 
    #endif
#if FABLE_COMPILER_PYTHON
    let v922 : US2 = US2_0
    let v923 : US3 = US3_5(v922)
    let v924 : string = $"date_time.get_utc_offset / target: {v923}"
    let v925 : System.TimeSpan = failwith<System.TimeSpan> v924
    let _run_target_args'_v808 = v925 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v928 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v933 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v934 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v935 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v934 
    let _run_target_args'_v933 = v935 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v937 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v933 = v937 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v941 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v933 = v941 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v945 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v933 = v945 
    #endif
#if FABLE_COMPILER_PYTHON
    let v949 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v933 = v949 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v952 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v933 = v952 
    #endif
#else
    let v953 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v933 = v953 
    #endif
    let v954 : System.TimeZoneInfo = _run_target_args'_v933 
    let v960 : (System.DateTime -> System.TimeSpan) = v928 v954
    let v961 : System.TimeSpan = v960 v620
    let _run_target_args'_v808 = v961 
    #endif
#else
    let v962 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v967 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v968 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v969 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v968 
    let _run_target_args'_v967 = v969 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v971 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v967 = v971 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v975 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v967 = v975 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v979 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v967 = v979 
    #endif
#if FABLE_COMPILER_PYTHON
    let v983 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v967 = v983 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v986 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v967 = v986 
    #endif
#else
    let v987 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v967 = v987 
    #endif
    let v988 : System.TimeZoneInfo = _run_target_args'_v967 
    let v994 : (System.DateTime -> System.TimeSpan) = v962 v988
    let v995 : System.TimeSpan = v994 v620
    let _run_target_args'_v808 = v995 
    #endif
    let v996 : System.TimeSpan = _run_target_args'_v808 
    let v1006 : (System.TimeSpan -> int32) = _.Hours
    let v1007 : int32 = v1006 v996
    let v1010 : bool = v1007 > 0
    let v1011 : uint8 =
        if v1010 then
            1uy
        else
            0uy
    let v1012 : string = method2()
    (* run_target_args'
    let v1072 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1073 : string = "$0.toString($1)"
    let v1074 : string = Fable.Core.RustInterop.emitRustExpr struct (v996, v1012) v1073 
    let _run_target_args'_v1072 = v1074 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1075 : string = "$0.toString($1)"
    let v1076 : string = Fable.Core.RustInterop.emitRustExpr struct (v996, v1012) v1075 
    let _run_target_args'_v1072 = v1076 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1077 : string = "$0.toString($1)"
    let v1078 : string = Fable.Core.RustInterop.emitRustExpr struct (v996, v1012) v1077 
    let _run_target_args'_v1072 = v1078 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1079 : string = v996.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1072 = v1079 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1080 : string = v996.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1072 = v1080 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1082 : string = v996.ToString v1012 
    let _run_target_args'_v1072 = v1082 
    #endif
#else
    let v1141 : string = v996.ToString v1012 
    let _run_target_args'_v1072 = v1141 
    #endif
    let v1199 : string = _run_target_args'_v1072 
    let v1260 : string = $"{v1011}{v1199.[0..1]}{v1199.[3..4]}"
    let v1262 : (System.Guid -> string) = _.ToString()
    let v1263 : string = v1262 v0
    let v1266 : int32 = v769.Length
    let v1267 : int32 = v1260.Length
    let v1268 : int32 = v1266 + v1267
    let v1270 : (string -> int32) = String.length
    let v1271 : int32 = v1270 v1263
    let v1279 : int32 = v1268 |> int32 
    let v1292 : int32 = v1271 |> int32 
    let v1300 : int32 = v1292 - 1
    let v1302 : string = v1263.[int v1279..int v1300]
    let v1306 : string = $"{v769}{v1260}{v1302}"
    (* run_target_args'
    let v1311 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1313 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1313 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1317 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1317 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1321 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1311 = v1321 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1325 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1325 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1329 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1329 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1333 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1333 
    #endif
#else
    let v1337 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1337 
    #endif
    let v1340 : System.Guid = _run_target_args'_v1311 
    let _run_target_args'_v599 = v1340 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1351 : System.DateTime = System.DateTime.UnixEpoch
    let v1355 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1356 : System.DateTime = v1355 v1351
    let v1360 : System.DateTimeKind = System.DateTimeKind.Local
    let v1361 : System.DateTime = System.DateTime.SpecifyKind (v1, v1360)
    let v1365 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1366 : System.DateTime = v1365 v1361
    (* run_target_args'
    let v1375 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1376 : (System.DateTime -> int64) = _.Ticks
    let v1377 : int64 = v1376 v1366
    let _run_target_args'_v1375 = v1377 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1378 : (System.DateTime -> int64) = _.Ticks
    let v1379 : int64 = v1378 v1366
    let _run_target_args'_v1375 = v1379 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1381 : int64 = null |> unbox<int64>
    let _run_target_args'_v1375 = v1381 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1384 : (System.DateTime -> int64) = _.Ticks
    let v1385 : int64 = v1384 v1366
    let _run_target_args'_v1375 = v1385 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1386 : (System.DateTime -> int64) = _.Ticks
    let v1387 : int64 = v1386 v1366
    let _run_target_args'_v1375 = v1387 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1388 : (System.DateTime -> int64) = _.Ticks
    let v1389 : int64 = v1388 v1366
    let _run_target_args'_v1375 = v1389 
    #endif
#else
    let v1390 : (System.DateTime -> int64) = _.Ticks
    let v1391 : int64 = v1390 v1366
    let _run_target_args'_v1375 = v1391 
    #endif
    let v1392 : int64 = _run_target_args'_v1375 
    (* run_target_args'
    let v1418 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1419 : (System.DateTime -> int64) = _.Ticks
    let v1420 : int64 = v1419 v1356
    let _run_target_args'_v1418 = v1420 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1421 : (System.DateTime -> int64) = _.Ticks
    let v1422 : int64 = v1421 v1356
    let _run_target_args'_v1418 = v1422 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1424 : int64 = null |> unbox<int64>
    let _run_target_args'_v1418 = v1424 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1427 : (System.DateTime -> int64) = _.Ticks
    let v1428 : int64 = v1427 v1356
    let _run_target_args'_v1418 = v1428 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1429 : (System.DateTime -> int64) = _.Ticks
    let v1430 : int64 = v1429 v1356
    let _run_target_args'_v1418 = v1430 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1431 : (System.DateTime -> int64) = _.Ticks
    let v1432 : int64 = v1431 v1356
    let _run_target_args'_v1418 = v1432 
    #endif
#else
    let v1433 : (System.DateTime -> int64) = _.Ticks
    let v1434 : int64 = v1433 v1356
    let _run_target_args'_v1418 = v1434 
    #endif
    let v1435 : int64 = _run_target_args'_v1418 
    let v1456 : int64 = v1392 |> int64 
    let v1460 : int64 = v1435 |> int64 
    let v1463 : int64 = v1456 - v1460
    let v1464 : int64 = v1463 / 10L
    let v1465 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1466 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1464 v1465 
    let v1469 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v1470 : US0 option = v1466 |> Option.map v1469 
    let v1490 : US0 = US0_1
    let v1491 : US0 = v1470 |> Option.defaultValue v1490 
    let v1511 : US1 =
        match v1491 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v1495) -> (* Some *)
            let v1496 : string = "$0.naive_utc()"
            let v1497 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1495 v1496 
            let v1498 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1499 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1497 v1498 
            let v1500 : string = "%Y%m%d-%H%M-%S%f"
            let v1501 : string = "r#\"" + v1500 + "\"#"
            let v1502 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1501 
            let v1503 : string = "$0.format($1).to_string()"
            let v1504 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1499, v1502) v1503 
            let v1505 : string = "fable_library_rust::String_::fromString($0)"
            let v1506 : string = Fable.Core.RustInterop.emitRustExpr v1504 v1505 
            let v1507 : string = $"{v1506.[0..17]}-{v1506.[18..21]}-{v1506.[22]}"
            US1_0(v1507)
    let v1515 : string =
        match v1511 with
        | US1_1 -> (* None *)
            let v1513 : string = ""
            v1513
        | US1_0(v1512) -> (* Some *)
            v1512
    (* run_target_args'
    let v1520 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1521 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1522 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1521 
    let _run_target_args'_v1520 = v1522 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1524 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1520 = v1524 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1528 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1520 = v1528 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1532 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1520 = v1532 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1536 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1520 = v1536 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1539 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1520 = v1539 
    #endif
#else
    let v1540 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1520 = v1540 
    #endif
    let v1541 : System.TimeZoneInfo = _run_target_args'_v1520 
    (* run_target_args'
    let v1554 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1561 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1562 : (System.DateTime -> int64) = _.Ticks
    let v1563 : int64 = v1562 v1366
    let _run_target_args'_v1561 = v1563 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1564 : (System.DateTime -> int64) = _.Ticks
    let v1565 : int64 = v1564 v1366
    let _run_target_args'_v1561 = v1565 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1567 : int64 = null |> unbox<int64>
    let _run_target_args'_v1561 = v1567 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1570 : (System.DateTime -> int64) = _.Ticks
    let v1571 : int64 = v1570 v1366
    let _run_target_args'_v1561 = v1571 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1572 : (System.DateTime -> int64) = _.Ticks
    let v1573 : int64 = v1572 v1366
    let _run_target_args'_v1561 = v1573 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1574 : (System.DateTime -> int64) = _.Ticks
    let v1575 : int64 = v1574 v1366
    let _run_target_args'_v1561 = v1575 
    #endif
#else
    let v1576 : (System.DateTime -> int64) = _.Ticks
    let v1577 : int64 = v1576 v1366
    let _run_target_args'_v1561 = v1577 
    #endif
    let v1578 : int64 = _run_target_args'_v1561 
    let v1598 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1599 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1366, v1578) v1598 
    let v1601 : System.TimeSpan = v1599 |> System.TimeSpan 
    let _run_target_args'_v1554 = v1601 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1610 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1611 : (System.DateTime -> int64) = _.Ticks
    let v1612 : int64 = v1611 v1366
    let _run_target_args'_v1610 = v1612 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1613 : (System.DateTime -> int64) = _.Ticks
    let v1614 : int64 = v1613 v1366
    let _run_target_args'_v1610 = v1614 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1616 : int64 = null |> unbox<int64>
    let _run_target_args'_v1610 = v1616 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1619 : (System.DateTime -> int64) = _.Ticks
    let v1620 : int64 = v1619 v1366
    let _run_target_args'_v1610 = v1620 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1621 : (System.DateTime -> int64) = _.Ticks
    let v1622 : int64 = v1621 v1366
    let _run_target_args'_v1610 = v1622 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1623 : (System.DateTime -> int64) = _.Ticks
    let v1624 : int64 = v1623 v1366
    let _run_target_args'_v1610 = v1624 
    #endif
#else
    let v1625 : (System.DateTime -> int64) = _.Ticks
    let v1626 : int64 = v1625 v1366
    let _run_target_args'_v1610 = v1626 
    #endif
    let v1627 : int64 = _run_target_args'_v1610 
    let v1647 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1648 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1366, v1627) v1647 
    let v1650 : System.TimeSpan = v1648 |> System.TimeSpan 
    let _run_target_args'_v1554 = v1650 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1654 : US2 = US2_2
    let v1655 : US3 = US3_3(v1654)
    let v1656 : string = $"date_time.get_utc_offset / target: {v1655}"
    let v1657 : System.TimeSpan = failwith<System.TimeSpan> v1656
    let _run_target_args'_v1554 = v1657 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1661 : US2 = US2_0
    let v1662 : US3 = US3_4(v1661)
    let v1663 : string = $"date_time.get_utc_offset / target: {v1662}"
    let v1664 : System.TimeSpan = failwith<System.TimeSpan> v1663
    let _run_target_args'_v1554 = v1664 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1668 : US2 = US2_0
    let v1669 : US3 = US3_5(v1668)
    let v1670 : string = $"date_time.get_utc_offset / target: {v1669}"
    let v1671 : System.TimeSpan = failwith<System.TimeSpan> v1670
    let _run_target_args'_v1554 = v1671 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1674 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1679 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1680 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1681 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1680 
    let _run_target_args'_v1679 = v1681 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1683 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1679 = v1683 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1687 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1679 = v1687 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1691 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1679 = v1691 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1695 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1679 = v1695 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1698 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1679 = v1698 
    #endif
#else
    let v1699 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1679 = v1699 
    #endif
    let v1700 : System.TimeZoneInfo = _run_target_args'_v1679 
    let v1706 : (System.DateTime -> System.TimeSpan) = v1674 v1700
    let v1707 : System.TimeSpan = v1706 v1366
    let _run_target_args'_v1554 = v1707 
    #endif
#else
    let v1708 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1713 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1714 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1715 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1714 
    let _run_target_args'_v1713 = v1715 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1717 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1713 = v1717 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1721 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1713 = v1721 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1725 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1713 = v1725 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1729 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1713 = v1729 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1732 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1713 = v1732 
    #endif
#else
    let v1733 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1713 = v1733 
    #endif
    let v1734 : System.TimeZoneInfo = _run_target_args'_v1713 
    let v1740 : (System.DateTime -> System.TimeSpan) = v1708 v1734
    let v1741 : System.TimeSpan = v1740 v1366
    let _run_target_args'_v1554 = v1741 
    #endif
    let v1742 : System.TimeSpan = _run_target_args'_v1554 
    let v1752 : (System.TimeSpan -> int32) = _.Hours
    let v1753 : int32 = v1752 v1742
    let v1756 : bool = v1753 > 0
    let v1757 : uint8 =
        if v1756 then
            1uy
        else
            0uy
    let v1758 : string = method2()
    (* run_target_args'
    let v1818 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1819 : string = "$0.toString($1)"
    let v1820 : string = Fable.Core.RustInterop.emitRustExpr struct (v1742, v1758) v1819 
    let _run_target_args'_v1818 = v1820 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1821 : string = "$0.toString($1)"
    let v1822 : string = Fable.Core.RustInterop.emitRustExpr struct (v1742, v1758) v1821 
    let _run_target_args'_v1818 = v1822 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1823 : string = "$0.toString($1)"
    let v1824 : string = Fable.Core.RustInterop.emitRustExpr struct (v1742, v1758) v1823 
    let _run_target_args'_v1818 = v1824 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1825 : string = v1742.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1818 = v1825 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1826 : string = v1742.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1818 = v1826 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1828 : string = v1742.ToString v1758 
    let _run_target_args'_v1818 = v1828 
    #endif
#else
    let v1887 : string = v1742.ToString v1758 
    let _run_target_args'_v1818 = v1887 
    #endif
    let v1945 : string = _run_target_args'_v1818 
    let v2006 : string = $"{v1757}{v1945.[0..1]}{v1945.[3..4]}"
    let v2008 : (System.Guid -> string) = _.ToString()
    let v2009 : string = v2008 v0
    let v2012 : int32 = v1515.Length
    let v2013 : int32 = v2006.Length
    let v2014 : int32 = v2012 + v2013
    let v2016 : (string -> int32) = String.length
    let v2017 : int32 = v2016 v2009
    let v2025 : int32 = v2014 |> int32 
    let v2038 : int32 = v2017 |> int32 
    let v2046 : int32 = v2038 - 1
    let v2048 : string = v2009.[int v2025..int v2046]
    let v2052 : string = $"{v1515}{v2006}{v2048}"
    (* run_target_args'
    let v2057 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2059 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2059 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2063 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2063 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2067 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2057 = v2067 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2071 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2071 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2075 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2075 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2079 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2079 
    #endif
#else
    let v2083 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2083 
    #endif
    let v2086 : System.Guid = _run_target_args'_v2057 
    let _run_target_args'_v599 = v2086 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2093 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v599 = v2093 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2096 : string = method3()
    let v2098 : bool = v2096 = ""
    let v2100 : string =
        if v2098 then
            let v2099 : string = "M-d-y hh:mm:ss tt"
            v2099
        else
            v2096
    let v2101 : (string -> string) = v1.ToString
    let v2102 : string = v2101 v2100
    (* run_target_args'
    let v2121 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2122 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2123 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2122 
    let _run_target_args'_v2121 = v2123 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2125 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2121 = v2125 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2129 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2121 = v2129 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2133 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2121 = v2133 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2137 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2121 = v2137 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2140 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2121 = v2140 
    #endif
#else
    let v2141 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2121 = v2141 
    #endif
    let v2142 : System.TimeZoneInfo = _run_target_args'_v2121 
    (* run_target_args'
    let v2155 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2162 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2163 : (System.DateTime -> int64) = _.Ticks
    let v2164 : int64 = v2163 v1
    let _run_target_args'_v2162 = v2164 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2165 : (System.DateTime -> int64) = _.Ticks
    let v2166 : int64 = v2165 v1
    let _run_target_args'_v2162 = v2166 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2168 : int64 = null |> unbox<int64>
    let _run_target_args'_v2162 = v2168 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2171 : (System.DateTime -> int64) = _.Ticks
    let v2172 : int64 = v2171 v1
    let _run_target_args'_v2162 = v2172 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2173 : (System.DateTime -> int64) = _.Ticks
    let v2174 : int64 = v2173 v1
    let _run_target_args'_v2162 = v2174 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2175 : (System.DateTime -> int64) = _.Ticks
    let v2176 : int64 = v2175 v1
    let _run_target_args'_v2162 = v2176 
    #endif
#else
    let v2177 : (System.DateTime -> int64) = _.Ticks
    let v2178 : int64 = v2177 v1
    let _run_target_args'_v2162 = v2178 
    #endif
    let v2179 : int64 = _run_target_args'_v2162 
    let v2199 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2200 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2179) v2199 
    let v2202 : System.TimeSpan = v2200 |> System.TimeSpan 
    let _run_target_args'_v2155 = v2202 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2211 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2212 : (System.DateTime -> int64) = _.Ticks
    let v2213 : int64 = v2212 v1
    let _run_target_args'_v2211 = v2213 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2214 : (System.DateTime -> int64) = _.Ticks
    let v2215 : int64 = v2214 v1
    let _run_target_args'_v2211 = v2215 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2217 : int64 = null |> unbox<int64>
    let _run_target_args'_v2211 = v2217 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2220 : (System.DateTime -> int64) = _.Ticks
    let v2221 : int64 = v2220 v1
    let _run_target_args'_v2211 = v2221 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2222 : (System.DateTime -> int64) = _.Ticks
    let v2223 : int64 = v2222 v1
    let _run_target_args'_v2211 = v2223 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2224 : (System.DateTime -> int64) = _.Ticks
    let v2225 : int64 = v2224 v1
    let _run_target_args'_v2211 = v2225 
    #endif
#else
    let v2226 : (System.DateTime -> int64) = _.Ticks
    let v2227 : int64 = v2226 v1
    let _run_target_args'_v2211 = v2227 
    #endif
    let v2228 : int64 = _run_target_args'_v2211 
    let v2248 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2249 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2228) v2248 
    let v2251 : System.TimeSpan = v2249 |> System.TimeSpan 
    let _run_target_args'_v2155 = v2251 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2255 : US2 = US2_2
    let v2256 : US3 = US3_3(v2255)
    let v2257 : string = $"date_time.get_utc_offset / target: {v2256}"
    let v2258 : System.TimeSpan = failwith<System.TimeSpan> v2257
    let _run_target_args'_v2155 = v2258 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2262 : US2 = US2_0
    let v2263 : US3 = US3_4(v2262)
    let v2264 : string = $"date_time.get_utc_offset / target: {v2263}"
    let v2265 : System.TimeSpan = failwith<System.TimeSpan> v2264
    let _run_target_args'_v2155 = v2265 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2269 : US2 = US2_0
    let v2270 : US3 = US3_5(v2269)
    let v2271 : string = $"date_time.get_utc_offset / target: {v2270}"
    let v2272 : System.TimeSpan = failwith<System.TimeSpan> v2271
    let _run_target_args'_v2155 = v2272 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2275 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2280 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2281 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2282 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2281 
    let _run_target_args'_v2280 = v2282 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2284 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2280 = v2284 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2288 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2280 = v2288 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2292 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2280 = v2292 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2296 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2280 = v2296 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2299 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2280 = v2299 
    #endif
#else
    let v2300 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2280 = v2300 
    #endif
    let v2301 : System.TimeZoneInfo = _run_target_args'_v2280 
    let v2307 : (System.DateTime -> System.TimeSpan) = v2275 v2301
    let v2308 : System.TimeSpan = v2307 v1
    let _run_target_args'_v2155 = v2308 
    #endif
#else
    let v2309 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2314 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2315 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2316 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2315 
    let _run_target_args'_v2314 = v2316 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2318 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2314 = v2318 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2322 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2314 = v2322 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2326 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2314 = v2326 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2330 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2314 = v2330 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2333 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2314 = v2333 
    #endif
#else
    let v2334 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2314 = v2334 
    #endif
    let v2335 : System.TimeZoneInfo = _run_target_args'_v2314 
    let v2341 : (System.DateTime -> System.TimeSpan) = v2309 v2335
    let v2342 : System.TimeSpan = v2341 v1
    let _run_target_args'_v2155 = v2342 
    #endif
    let v2343 : System.TimeSpan = _run_target_args'_v2155 
    let v2353 : (System.TimeSpan -> int32) = _.Hours
    let v2354 : int32 = v2353 v2343
    let v2357 : bool = v2354 > 0
    let v2358 : uint8 =
        if v2357 then
            1uy
        else
            0uy
    let v2359 : string = method4()
    (* run_target_args'
    let v2419 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2420 : string = "$0.toString($1)"
    let v2421 : string = Fable.Core.RustInterop.emitRustExpr struct (v2343, v2359) v2420 
    let _run_target_args'_v2419 = v2421 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2422 : string = "$0.toString($1)"
    let v2423 : string = Fable.Core.RustInterop.emitRustExpr struct (v2343, v2359) v2422 
    let _run_target_args'_v2419 = v2423 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2424 : string = "$0.toString($1)"
    let v2425 : string = Fable.Core.RustInterop.emitRustExpr struct (v2343, v2359) v2424 
    let _run_target_args'_v2419 = v2425 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2426 : string = v2343.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2419 = v2426 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2427 : string = v2343.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2419 = v2427 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2429 : string = v2343.ToString v2359 
    let _run_target_args'_v2419 = v2429 
    #endif
#else
    let v2488 : string = v2343.ToString v2359 
    let _run_target_args'_v2419 = v2488 
    #endif
    let v2546 : string = _run_target_args'_v2419 
    let v2607 : string = $"{v2358}{v2546}"
    let v2609 : (System.Guid -> string) = _.ToString()
    let v2610 : string = v2609 v0
    let v2613 : int32 = v2102.Length
    let v2614 : int32 = v2607.Length
    let v2615 : int32 = v2613 + v2614
    let v2617 : (string -> int32) = String.length
    let v2618 : int32 = v2617 v2610
    let v2626 : int32 = v2615 |> int32 
    let v2639 : int32 = v2618 |> int32 
    let v2647 : int32 = v2639 - 1
    let v2649 : string = v2610.[int v2626..int v2647]
    let v2653 : string = $"{v2102}{v2607}{v2649}"
    (* run_target_args'
    let v2658 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2660 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2660 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2664 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2664 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2668 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2658 = v2668 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2672 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2672 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2676 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2676 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2680 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2680 
    #endif
#else
    let v2684 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2684 
    #endif
    let v2687 : System.Guid = _run_target_args'_v2658 
    let _run_target_args'_v599 = v2687 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2693 : string = method3()
    let v2695 : bool = v2693 = ""
    let v2697 : string =
        if v2695 then
            let v2696 : string = "M-d-y hh:mm:ss tt"
            v2696
        else
            v2693
    let v2698 : (string -> string) = v1.ToString
    let v2699 : string = v2698 v2697
    (* run_target_args'
    let v2718 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2719 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2720 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2719 
    let _run_target_args'_v2718 = v2720 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2722 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2718 = v2722 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2726 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2718 = v2726 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2730 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2718 = v2730 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2734 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2718 = v2734 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2737 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2718 = v2737 
    #endif
#else
    let v2738 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2718 = v2738 
    #endif
    let v2739 : System.TimeZoneInfo = _run_target_args'_v2718 
    (* run_target_args'
    let v2752 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2759 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2760 : (System.DateTime -> int64) = _.Ticks
    let v2761 : int64 = v2760 v1
    let _run_target_args'_v2759 = v2761 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2762 : (System.DateTime -> int64) = _.Ticks
    let v2763 : int64 = v2762 v1
    let _run_target_args'_v2759 = v2763 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2765 : int64 = null |> unbox<int64>
    let _run_target_args'_v2759 = v2765 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2768 : (System.DateTime -> int64) = _.Ticks
    let v2769 : int64 = v2768 v1
    let _run_target_args'_v2759 = v2769 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2770 : (System.DateTime -> int64) = _.Ticks
    let v2771 : int64 = v2770 v1
    let _run_target_args'_v2759 = v2771 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2772 : (System.DateTime -> int64) = _.Ticks
    let v2773 : int64 = v2772 v1
    let _run_target_args'_v2759 = v2773 
    #endif
#else
    let v2774 : (System.DateTime -> int64) = _.Ticks
    let v2775 : int64 = v2774 v1
    let _run_target_args'_v2759 = v2775 
    #endif
    let v2776 : int64 = _run_target_args'_v2759 
    let v2796 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2797 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2776) v2796 
    let v2799 : System.TimeSpan = v2797 |> System.TimeSpan 
    let _run_target_args'_v2752 = v2799 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2808 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2809 : (System.DateTime -> int64) = _.Ticks
    let v2810 : int64 = v2809 v1
    let _run_target_args'_v2808 = v2810 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2811 : (System.DateTime -> int64) = _.Ticks
    let v2812 : int64 = v2811 v1
    let _run_target_args'_v2808 = v2812 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2814 : int64 = null |> unbox<int64>
    let _run_target_args'_v2808 = v2814 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2817 : (System.DateTime -> int64) = _.Ticks
    let v2818 : int64 = v2817 v1
    let _run_target_args'_v2808 = v2818 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2819 : (System.DateTime -> int64) = _.Ticks
    let v2820 : int64 = v2819 v1
    let _run_target_args'_v2808 = v2820 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2821 : (System.DateTime -> int64) = _.Ticks
    let v2822 : int64 = v2821 v1
    let _run_target_args'_v2808 = v2822 
    #endif
#else
    let v2823 : (System.DateTime -> int64) = _.Ticks
    let v2824 : int64 = v2823 v1
    let _run_target_args'_v2808 = v2824 
    #endif
    let v2825 : int64 = _run_target_args'_v2808 
    let v2845 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2846 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2825) v2845 
    let v2848 : System.TimeSpan = v2846 |> System.TimeSpan 
    let _run_target_args'_v2752 = v2848 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2852 : US2 = US2_2
    let v2853 : US3 = US3_3(v2852)
    let v2854 : string = $"date_time.get_utc_offset / target: {v2853}"
    let v2855 : System.TimeSpan = failwith<System.TimeSpan> v2854
    let _run_target_args'_v2752 = v2855 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2859 : US2 = US2_0
    let v2860 : US3 = US3_4(v2859)
    let v2861 : string = $"date_time.get_utc_offset / target: {v2860}"
    let v2862 : System.TimeSpan = failwith<System.TimeSpan> v2861
    let _run_target_args'_v2752 = v2862 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2866 : US2 = US2_0
    let v2867 : US3 = US3_5(v2866)
    let v2868 : string = $"date_time.get_utc_offset / target: {v2867}"
    let v2869 : System.TimeSpan = failwith<System.TimeSpan> v2868
    let _run_target_args'_v2752 = v2869 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2872 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2877 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2878 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2879 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2878 
    let _run_target_args'_v2877 = v2879 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2881 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2877 = v2881 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2885 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2877 = v2885 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2889 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2877 = v2889 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2893 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2877 = v2893 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2896 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2877 = v2896 
    #endif
#else
    let v2897 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2877 = v2897 
    #endif
    let v2898 : System.TimeZoneInfo = _run_target_args'_v2877 
    let v2904 : (System.DateTime -> System.TimeSpan) = v2872 v2898
    let v2905 : System.TimeSpan = v2904 v1
    let _run_target_args'_v2752 = v2905 
    #endif
#else
    let v2906 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2911 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2912 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2913 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2912 
    let _run_target_args'_v2911 = v2913 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2915 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2911 = v2915 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2919 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2911 = v2919 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2923 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2911 = v2923 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2927 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2911 = v2927 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2930 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2911 = v2930 
    #endif
#else
    let v2931 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2911 = v2931 
    #endif
    let v2932 : System.TimeZoneInfo = _run_target_args'_v2911 
    let v2938 : (System.DateTime -> System.TimeSpan) = v2906 v2932
    let v2939 : System.TimeSpan = v2938 v1
    let _run_target_args'_v2752 = v2939 
    #endif
    let v2940 : System.TimeSpan = _run_target_args'_v2752 
    let v2950 : (System.TimeSpan -> int32) = _.Hours
    let v2951 : int32 = v2950 v2940
    let v2954 : bool = v2951 > 0
    let v2955 : uint8 =
        if v2954 then
            1uy
        else
            0uy
    let v2956 : string = method4()
    (* run_target_args'
    let v3016 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3017 : string = "$0.toString($1)"
    let v3018 : string = Fable.Core.RustInterop.emitRustExpr struct (v2940, v2956) v3017 
    let _run_target_args'_v3016 = v3018 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3019 : string = "$0.toString($1)"
    let v3020 : string = Fable.Core.RustInterop.emitRustExpr struct (v2940, v2956) v3019 
    let _run_target_args'_v3016 = v3020 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3021 : string = "$0.toString($1)"
    let v3022 : string = Fable.Core.RustInterop.emitRustExpr struct (v2940, v2956) v3021 
    let _run_target_args'_v3016 = v3022 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3023 : string = v2940.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3016 = v3023 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3024 : string = v2940.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3016 = v3024 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3026 : string = v2940.ToString v2956 
    let _run_target_args'_v3016 = v3026 
    #endif
#else
    let v3085 : string = v2940.ToString v2956 
    let _run_target_args'_v3016 = v3085 
    #endif
    let v3143 : string = _run_target_args'_v3016 
    let v3204 : string = $"{v2955}{v3143}"
    let v3206 : (System.Guid -> string) = _.ToString()
    let v3207 : string = v3206 v0
    let v3210 : int32 = v2699.Length
    let v3211 : int32 = v3204.Length
    let v3212 : int32 = v3210 + v3211
    let v3214 : (string -> int32) = String.length
    let v3215 : int32 = v3214 v3207
    let v3223 : int32 = v3212 |> int32 
    let v3236 : int32 = v3215 |> int32 
    let v3244 : int32 = v3236 - 1
    let v3246 : string = v3207.[int v3223..int v3244]
    let v3250 : string = $"{v2699}{v3204}{v3246}"
    (* run_target_args'
    let v3255 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3257 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3257 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3261 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3261 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3265 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3255 = v3265 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3269 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3269 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3273 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3273 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3277 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3277 
    #endif
#else
    let v3281 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3281 
    #endif
    let v3284 : System.Guid = _run_target_args'_v3255 
    let _run_target_args'_v599 = v3284 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3290 : string = method3()
    let v3292 : bool = v3290 = ""
    let v3294 : string =
        if v3292 then
            let v3293 : string = "M-d-y hh:mm:ss tt"
            v3293
        else
            v3290
    let v3295 : (string -> string) = v1.ToString
    let v3296 : string = v3295 v3294
    (* run_target_args'
    let v3315 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3316 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3317 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3316 
    let _run_target_args'_v3315 = v3317 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3319 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3315 = v3319 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3323 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3315 = v3323 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3327 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3315 = v3327 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3331 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3315 = v3331 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3334 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3315 = v3334 
    #endif
#else
    let v3335 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3315 = v3335 
    #endif
    let v3336 : System.TimeZoneInfo = _run_target_args'_v3315 
    (* run_target_args'
    let v3349 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3356 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3357 : (System.DateTime -> int64) = _.Ticks
    let v3358 : int64 = v3357 v1
    let _run_target_args'_v3356 = v3358 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3359 : (System.DateTime -> int64) = _.Ticks
    let v3360 : int64 = v3359 v1
    let _run_target_args'_v3356 = v3360 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3362 : int64 = null |> unbox<int64>
    let _run_target_args'_v3356 = v3362 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3365 : (System.DateTime -> int64) = _.Ticks
    let v3366 : int64 = v3365 v1
    let _run_target_args'_v3356 = v3366 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3367 : (System.DateTime -> int64) = _.Ticks
    let v3368 : int64 = v3367 v1
    let _run_target_args'_v3356 = v3368 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3369 : (System.DateTime -> int64) = _.Ticks
    let v3370 : int64 = v3369 v1
    let _run_target_args'_v3356 = v3370 
    #endif
#else
    let v3371 : (System.DateTime -> int64) = _.Ticks
    let v3372 : int64 = v3371 v1
    let _run_target_args'_v3356 = v3372 
    #endif
    let v3373 : int64 = _run_target_args'_v3356 
    let v3393 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3394 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3373) v3393 
    let v3396 : System.TimeSpan = v3394 |> System.TimeSpan 
    let _run_target_args'_v3349 = v3396 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3405 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3406 : (System.DateTime -> int64) = _.Ticks
    let v3407 : int64 = v3406 v1
    let _run_target_args'_v3405 = v3407 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3408 : (System.DateTime -> int64) = _.Ticks
    let v3409 : int64 = v3408 v1
    let _run_target_args'_v3405 = v3409 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3411 : int64 = null |> unbox<int64>
    let _run_target_args'_v3405 = v3411 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3414 : (System.DateTime -> int64) = _.Ticks
    let v3415 : int64 = v3414 v1
    let _run_target_args'_v3405 = v3415 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3416 : (System.DateTime -> int64) = _.Ticks
    let v3417 : int64 = v3416 v1
    let _run_target_args'_v3405 = v3417 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3418 : (System.DateTime -> int64) = _.Ticks
    let v3419 : int64 = v3418 v1
    let _run_target_args'_v3405 = v3419 
    #endif
#else
    let v3420 : (System.DateTime -> int64) = _.Ticks
    let v3421 : int64 = v3420 v1
    let _run_target_args'_v3405 = v3421 
    #endif
    let v3422 : int64 = _run_target_args'_v3405 
    let v3442 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3443 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3422) v3442 
    let v3445 : System.TimeSpan = v3443 |> System.TimeSpan 
    let _run_target_args'_v3349 = v3445 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3449 : US2 = US2_2
    let v3450 : US3 = US3_3(v3449)
    let v3451 : string = $"date_time.get_utc_offset / target: {v3450}"
    let v3452 : System.TimeSpan = failwith<System.TimeSpan> v3451
    let _run_target_args'_v3349 = v3452 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3456 : US2 = US2_0
    let v3457 : US3 = US3_4(v3456)
    let v3458 : string = $"date_time.get_utc_offset / target: {v3457}"
    let v3459 : System.TimeSpan = failwith<System.TimeSpan> v3458
    let _run_target_args'_v3349 = v3459 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3463 : US2 = US2_0
    let v3464 : US3 = US3_5(v3463)
    let v3465 : string = $"date_time.get_utc_offset / target: {v3464}"
    let v3466 : System.TimeSpan = failwith<System.TimeSpan> v3465
    let _run_target_args'_v3349 = v3466 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3469 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3474 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3475 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3476 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3475 
    let _run_target_args'_v3474 = v3476 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3478 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3474 = v3478 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3482 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3474 = v3482 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3486 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3474 = v3486 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3490 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3474 = v3490 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3493 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3474 = v3493 
    #endif
#else
    let v3494 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3474 = v3494 
    #endif
    let v3495 : System.TimeZoneInfo = _run_target_args'_v3474 
    let v3501 : (System.DateTime -> System.TimeSpan) = v3469 v3495
    let v3502 : System.TimeSpan = v3501 v1
    let _run_target_args'_v3349 = v3502 
    #endif
#else
    let v3503 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3508 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3509 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3510 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3509 
    let _run_target_args'_v3508 = v3510 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3512 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3508 = v3512 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3516 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3508 = v3516 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3520 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3508 = v3520 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3524 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3508 = v3524 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3527 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3508 = v3527 
    #endif
#else
    let v3528 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3508 = v3528 
    #endif
    let v3529 : System.TimeZoneInfo = _run_target_args'_v3508 
    let v3535 : (System.DateTime -> System.TimeSpan) = v3503 v3529
    let v3536 : System.TimeSpan = v3535 v1
    let _run_target_args'_v3349 = v3536 
    #endif
    let v3537 : System.TimeSpan = _run_target_args'_v3349 
    let v3547 : (System.TimeSpan -> int32) = _.Hours
    let v3548 : int32 = v3547 v3537
    let v3551 : bool = v3548 > 0
    let v3552 : uint8 =
        if v3551 then
            1uy
        else
            0uy
    let v3553 : string = method4()
    (* run_target_args'
    let v3613 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3614 : string = "$0.toString($1)"
    let v3615 : string = Fable.Core.RustInterop.emitRustExpr struct (v3537, v3553) v3614 
    let _run_target_args'_v3613 = v3615 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3616 : string = "$0.toString($1)"
    let v3617 : string = Fable.Core.RustInterop.emitRustExpr struct (v3537, v3553) v3616 
    let _run_target_args'_v3613 = v3617 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3618 : string = "$0.toString($1)"
    let v3619 : string = Fable.Core.RustInterop.emitRustExpr struct (v3537, v3553) v3618 
    let _run_target_args'_v3613 = v3619 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3620 : string = v3537.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3613 = v3620 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3621 : string = v3537.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3613 = v3621 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3623 : string = v3537.ToString v3553 
    let _run_target_args'_v3613 = v3623 
    #endif
#else
    let v3682 : string = v3537.ToString v3553 
    let _run_target_args'_v3613 = v3682 
    #endif
    let v3740 : string = _run_target_args'_v3613 
    let v3801 : string = $"{v3552}{v3740}"
    let v3803 : (System.Guid -> string) = _.ToString()
    let v3804 : string = v3803 v0
    let v3807 : int32 = v3296.Length
    let v3808 : int32 = v3801.Length
    let v3809 : int32 = v3807 + v3808
    let v3811 : (string -> int32) = String.length
    let v3812 : int32 = v3811 v3804
    let v3820 : int32 = v3809 |> int32 
    let v3833 : int32 = v3812 |> int32 
    let v3841 : int32 = v3833 - 1
    let v3843 : string = v3804.[int v3820..int v3841]
    let v3847 : string = $"{v3296}{v3801}{v3843}"
    (* run_target_args'
    let v3852 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3854 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3854 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3858 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3858 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3862 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3852 = v3862 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3866 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3866 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3870 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3870 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3874 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3874 
    #endif
#else
    let v3878 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3878 
    #endif
    let v3881 : System.Guid = _run_target_args'_v3852 
    let _run_target_args'_v599 = v3881 
    #endif
#else
    let v3887 : string = method3()
    let v3889 : bool = v3887 = ""
    let v3891 : string =
        if v3889 then
            let v3890 : string = "M-d-y hh:mm:ss tt"
            v3890
        else
            v3887
    let v3892 : (string -> string) = v1.ToString
    let v3893 : string = v3892 v3891
    (* run_target_args'
    let v3912 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3913 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3914 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3913 
    let _run_target_args'_v3912 = v3914 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3916 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3912 = v3916 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3920 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3912 = v3920 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3924 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3912 = v3924 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3928 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3912 = v3928 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3931 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3912 = v3931 
    #endif
#else
    let v3932 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3912 = v3932 
    #endif
    let v3933 : System.TimeZoneInfo = _run_target_args'_v3912 
    (* run_target_args'
    let v3946 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3953 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3954 : (System.DateTime -> int64) = _.Ticks
    let v3955 : int64 = v3954 v1
    let _run_target_args'_v3953 = v3955 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3956 : (System.DateTime -> int64) = _.Ticks
    let v3957 : int64 = v3956 v1
    let _run_target_args'_v3953 = v3957 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3959 : int64 = null |> unbox<int64>
    let _run_target_args'_v3953 = v3959 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3962 : (System.DateTime -> int64) = _.Ticks
    let v3963 : int64 = v3962 v1
    let _run_target_args'_v3953 = v3963 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3964 : (System.DateTime -> int64) = _.Ticks
    let v3965 : int64 = v3964 v1
    let _run_target_args'_v3953 = v3965 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3966 : (System.DateTime -> int64) = _.Ticks
    let v3967 : int64 = v3966 v1
    let _run_target_args'_v3953 = v3967 
    #endif
#else
    let v3968 : (System.DateTime -> int64) = _.Ticks
    let v3969 : int64 = v3968 v1
    let _run_target_args'_v3953 = v3969 
    #endif
    let v3970 : int64 = _run_target_args'_v3953 
    let v3990 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3991 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3970) v3990 
    let v3993 : System.TimeSpan = v3991 |> System.TimeSpan 
    let _run_target_args'_v3946 = v3993 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4002 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4003 : (System.DateTime -> int64) = _.Ticks
    let v4004 : int64 = v4003 v1
    let _run_target_args'_v4002 = v4004 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4005 : (System.DateTime -> int64) = _.Ticks
    let v4006 : int64 = v4005 v1
    let _run_target_args'_v4002 = v4006 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4008 : int64 = null |> unbox<int64>
    let _run_target_args'_v4002 = v4008 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4011 : (System.DateTime -> int64) = _.Ticks
    let v4012 : int64 = v4011 v1
    let _run_target_args'_v4002 = v4012 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4013 : (System.DateTime -> int64) = _.Ticks
    let v4014 : int64 = v4013 v1
    let _run_target_args'_v4002 = v4014 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4015 : (System.DateTime -> int64) = _.Ticks
    let v4016 : int64 = v4015 v1
    let _run_target_args'_v4002 = v4016 
    #endif
#else
    let v4017 : (System.DateTime -> int64) = _.Ticks
    let v4018 : int64 = v4017 v1
    let _run_target_args'_v4002 = v4018 
    #endif
    let v4019 : int64 = _run_target_args'_v4002 
    let v4039 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4040 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4019) v4039 
    let v4042 : System.TimeSpan = v4040 |> System.TimeSpan 
    let _run_target_args'_v3946 = v4042 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4046 : US2 = US2_2
    let v4047 : US3 = US3_3(v4046)
    let v4048 : string = $"date_time.get_utc_offset / target: {v4047}"
    let v4049 : System.TimeSpan = failwith<System.TimeSpan> v4048
    let _run_target_args'_v3946 = v4049 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4053 : US2 = US2_0
    let v4054 : US3 = US3_4(v4053)
    let v4055 : string = $"date_time.get_utc_offset / target: {v4054}"
    let v4056 : System.TimeSpan = failwith<System.TimeSpan> v4055
    let _run_target_args'_v3946 = v4056 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4060 : US2 = US2_0
    let v4061 : US3 = US3_5(v4060)
    let v4062 : string = $"date_time.get_utc_offset / target: {v4061}"
    let v4063 : System.TimeSpan = failwith<System.TimeSpan> v4062
    let _run_target_args'_v3946 = v4063 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4066 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4071 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4072 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4073 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4072 
    let _run_target_args'_v4071 = v4073 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4075 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4071 = v4075 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4079 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4071 = v4079 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4083 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4071 = v4083 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4087 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4071 = v4087 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4090 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4071 = v4090 
    #endif
#else
    let v4091 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4071 = v4091 
    #endif
    let v4092 : System.TimeZoneInfo = _run_target_args'_v4071 
    let v4098 : (System.DateTime -> System.TimeSpan) = v4066 v4092
    let v4099 : System.TimeSpan = v4098 v1
    let _run_target_args'_v3946 = v4099 
    #endif
#else
    let v4100 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4105 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4106 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4107 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4106 
    let _run_target_args'_v4105 = v4107 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4109 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4105 = v4109 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4113 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4105 = v4113 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4117 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4105 = v4117 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4121 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4105 = v4121 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4124 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4105 = v4124 
    #endif
#else
    let v4125 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4105 = v4125 
    #endif
    let v4126 : System.TimeZoneInfo = _run_target_args'_v4105 
    let v4132 : (System.DateTime -> System.TimeSpan) = v4100 v4126
    let v4133 : System.TimeSpan = v4132 v1
    let _run_target_args'_v3946 = v4133 
    #endif
    let v4134 : System.TimeSpan = _run_target_args'_v3946 
    let v4144 : (System.TimeSpan -> int32) = _.Hours
    let v4145 : int32 = v4144 v4134
    let v4148 : bool = v4145 > 0
    let v4149 : uint8 =
        if v4148 then
            1uy
        else
            0uy
    let v4150 : string = method4()
    (* run_target_args'
    let v4210 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4211 : string = "$0.toString($1)"
    let v4212 : string = Fable.Core.RustInterop.emitRustExpr struct (v4134, v4150) v4211 
    let _run_target_args'_v4210 = v4212 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4213 : string = "$0.toString($1)"
    let v4214 : string = Fable.Core.RustInterop.emitRustExpr struct (v4134, v4150) v4213 
    let _run_target_args'_v4210 = v4214 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4215 : string = "$0.toString($1)"
    let v4216 : string = Fable.Core.RustInterop.emitRustExpr struct (v4134, v4150) v4215 
    let _run_target_args'_v4210 = v4216 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4217 : string = v4134.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4210 = v4217 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4218 : string = v4134.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4210 = v4218 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4220 : string = v4134.ToString v4150 
    let _run_target_args'_v4210 = v4220 
    #endif
#else
    let v4279 : string = v4134.ToString v4150 
    let _run_target_args'_v4210 = v4279 
    #endif
    let v4337 : string = _run_target_args'_v4210 
    let v4398 : string = $"{v4149}{v4337}"
    let v4400 : (System.Guid -> string) = _.ToString()
    let v4401 : string = v4400 v0
    let v4404 : int32 = v3893.Length
    let v4405 : int32 = v4398.Length
    let v4406 : int32 = v4404 + v4405
    let v4408 : (string -> int32) = String.length
    let v4409 : int32 = v4408 v4401
    let v4417 : int32 = v4406 |> int32 
    let v4430 : int32 = v4409 |> int32 
    let v4438 : int32 = v4430 - 1
    let v4440 : string = v4401.[int v4417..int v4438]
    let v4444 : string = $"{v3893}{v4398}{v4440}"
    (* run_target_args'
    let v4449 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4451 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4451 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4455 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4455 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4459 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4449 = v4459 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4463 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4463 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4467 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4467 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4471 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4471 
    #endif
#else
    let v4475 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4475 
    #endif
    let v4478 : System.Guid = _run_target_args'_v4449 
    let _run_target_args'_v599 = v4478 
    #endif
    let v4484 : System.Guid = _run_target_args'_v599 
    v4484
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
    let v3 : bool = v0 = ""
    let v5 : string =
        if v3 then
            let v4 : string = "M-d-y hh:mm:ss tt"
            v4
        else
            v0
    let v6 : (string -> string) = v1.ToString
    v6 v5
and closure11 () (v0 : string) : (System.DateTime -> string) =
    closure12(v0)
and closure13 () (v0 : System.DateTime) : string =
    let v3 : (string -> string) = v0.ToString
    let v4 : string = "yyyy-MM-ddTHH-mm-ss.fff"
    v3 v4
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
