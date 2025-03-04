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
    let v569 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v571 : System.DateTime = System.DateTime.UnixEpoch
    let v575 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v576 : System.DateTime = v575 v571
    let v580 : System.DateTimeKind = System.DateTimeKind.Local
    let v581 : System.DateTime = System.DateTime.SpecifyKind (v1, v580)
    let v585 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v586 : System.DateTime = v585 v581
    (* run_target_args'
    let v592 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v593 : (System.DateTime -> int64) = _.Ticks
    let v594 : int64 = v593 v586
    let _run_target_args'_v592 = v594 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v595 : (System.DateTime -> int64) = _.Ticks
    let v596 : int64 = v595 v586
    let _run_target_args'_v592 = v596 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v598 : int64 = null |> unbox<int64>
    let _run_target_args'_v592 = v598 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v601 : (System.DateTime -> int64) = _.Ticks
    let v602 : int64 = v601 v586
    let _run_target_args'_v592 = v602 
    #endif
#if FABLE_COMPILER_PYTHON
    let v603 : (System.DateTime -> int64) = _.Ticks
    let v604 : int64 = v603 v586
    let _run_target_args'_v592 = v604 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v605 : (System.DateTime -> int64) = _.Ticks
    let v606 : int64 = v605 v586
    let _run_target_args'_v592 = v606 
    #endif
#else
    let v607 : (System.DateTime -> int64) = _.Ticks
    let v608 : int64 = v607 v586
    let _run_target_args'_v592 = v608 
    #endif
    let v609 : int64 = _run_target_args'_v592 
    (* run_target_args'
    let v632 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v633 : (System.DateTime -> int64) = _.Ticks
    let v634 : int64 = v633 v576
    let _run_target_args'_v632 = v634 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v635 : (System.DateTime -> int64) = _.Ticks
    let v636 : int64 = v635 v576
    let _run_target_args'_v632 = v636 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v638 : int64 = null |> unbox<int64>
    let _run_target_args'_v632 = v638 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v641 : (System.DateTime -> int64) = _.Ticks
    let v642 : int64 = v641 v576
    let _run_target_args'_v632 = v642 
    #endif
#if FABLE_COMPILER_PYTHON
    let v643 : (System.DateTime -> int64) = _.Ticks
    let v644 : int64 = v643 v576
    let _run_target_args'_v632 = v644 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v645 : (System.DateTime -> int64) = _.Ticks
    let v646 : int64 = v645 v576
    let _run_target_args'_v632 = v646 
    #endif
#else
    let v647 : (System.DateTime -> int64) = _.Ticks
    let v648 : int64 = v647 v576
    let _run_target_args'_v632 = v648 
    #endif
    let v649 : int64 = _run_target_args'_v632 
    let v670 : int64 = v609 |> int64 
    let v674 : int64 = v649 |> int64 
    let v677 : int64 = v670 - v674
    let v678 : int64 = v677 / 10L
    let v679 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v680 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v678 v679 
    let v682 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v683 : US0 option = v680 |> Option.map v682 
    let v696 : US0 = US0_1
    let v697 : US0 = v683 |> Option.defaultValue v696 
    let v717 : US1 =
        match v697 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v701) -> (* Some *)
            let v702 : string = "$0.naive_utc()"
            let v703 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v701 v702 
            let v704 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v705 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v703 v704 
            let v706 : string = "%Y%m%d-%H%M-%S%f"
            let v707 : string = "r#\"" + v706 + "\"#"
            let v708 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v707 
            let v709 : string = "$0.format($1).to_string()"
            let v710 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v705, v708) v709 
            let v711 : string = "fable_library_rust::String_::fromString($0)"
            let v712 : string = Fable.Core.RustInterop.emitRustExpr v710 v711 
            let v713 : string = $"{v712.[0..17]}-{v712.[18..21]}-{v712.[22]}"
            US1_0(v713)
    let v721 : string =
        match v717 with
        | US1_1 -> (* None *)
            let v719 : string = ""
            v719
        | US1_0(v718) -> (* Some *)
            v718
    (* run_target_args'
    let v726 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v727 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v728 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v727 
    let _run_target_args'_v726 = v728 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v730 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v726 = v730 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v734 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v726 = v734 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v738 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v726 = v738 
    #endif
#if FABLE_COMPILER_PYTHON
    let v742 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v726 = v742 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v745 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v726 = v745 
    #endif
#else
    let v746 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v726 = v746 
    #endif
    let v747 : System.TimeZoneInfo = _run_target_args'_v726 
    (* run_target_args'
    let v760 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v764 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v765 : (System.DateTime -> int64) = _.Ticks
    let v766 : int64 = v765 v586
    let _run_target_args'_v764 = v766 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v767 : (System.DateTime -> int64) = _.Ticks
    let v768 : int64 = v767 v586
    let _run_target_args'_v764 = v768 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v770 : int64 = null |> unbox<int64>
    let _run_target_args'_v764 = v770 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v773 : (System.DateTime -> int64) = _.Ticks
    let v774 : int64 = v773 v586
    let _run_target_args'_v764 = v774 
    #endif
#if FABLE_COMPILER_PYTHON
    let v775 : (System.DateTime -> int64) = _.Ticks
    let v776 : int64 = v775 v586
    let _run_target_args'_v764 = v776 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v777 : (System.DateTime -> int64) = _.Ticks
    let v778 : int64 = v777 v586
    let _run_target_args'_v764 = v778 
    #endif
#else
    let v779 : (System.DateTime -> int64) = _.Ticks
    let v780 : int64 = v779 v586
    let _run_target_args'_v764 = v780 
    #endif
    let v781 : int64 = _run_target_args'_v764 
    let v801 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v802 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v781) v801 
    let v804 : System.TimeSpan = v802 |> System.TimeSpan 
    let _run_target_args'_v760 = v804 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v810 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v811 : (System.DateTime -> int64) = _.Ticks
    let v812 : int64 = v811 v586
    let _run_target_args'_v810 = v812 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v813 : (System.DateTime -> int64) = _.Ticks
    let v814 : int64 = v813 v586
    let _run_target_args'_v810 = v814 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v816 : int64 = null |> unbox<int64>
    let _run_target_args'_v810 = v816 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v819 : (System.DateTime -> int64) = _.Ticks
    let v820 : int64 = v819 v586
    let _run_target_args'_v810 = v820 
    #endif
#if FABLE_COMPILER_PYTHON
    let v821 : (System.DateTime -> int64) = _.Ticks
    let v822 : int64 = v821 v586
    let _run_target_args'_v810 = v822 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v823 : (System.DateTime -> int64) = _.Ticks
    let v824 : int64 = v823 v586
    let _run_target_args'_v810 = v824 
    #endif
#else
    let v825 : (System.DateTime -> int64) = _.Ticks
    let v826 : int64 = v825 v586
    let _run_target_args'_v810 = v826 
    #endif
    let v827 : int64 = _run_target_args'_v810 
    let v847 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v848 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v827) v847 
    let v850 : System.TimeSpan = v848 |> System.TimeSpan 
    let _run_target_args'_v760 = v850 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v854 : US2 = US2_2
    let v855 : US3 = US3_3(v854)
    let v856 : string = $"date_time.get_utc_offset / target: {v855}"
    let v857 : System.TimeSpan = failwith<System.TimeSpan> v856
    let _run_target_args'_v760 = v857 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v861 : US2 = US2_0
    let v862 : US3 = US3_4(v861)
    let v863 : string = $"date_time.get_utc_offset / target: {v862}"
    let v864 : System.TimeSpan = failwith<System.TimeSpan> v863
    let _run_target_args'_v760 = v864 
    #endif
#if FABLE_COMPILER_PYTHON
    let v868 : US2 = US2_0
    let v869 : US3 = US3_5(v868)
    let v870 : string = $"date_time.get_utc_offset / target: {v869}"
    let v871 : System.TimeSpan = failwith<System.TimeSpan> v870
    let _run_target_args'_v760 = v871 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v874 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v879 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v880 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v881 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v880 
    let _run_target_args'_v879 = v881 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v883 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v879 = v883 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v887 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v879 = v887 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v891 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v879 = v891 
    #endif
#if FABLE_COMPILER_PYTHON
    let v895 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v879 = v895 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v898 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v879 = v898 
    #endif
#else
    let v899 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v879 = v899 
    #endif
    let v900 : System.TimeZoneInfo = _run_target_args'_v879 
    let v906 : (System.DateTime -> System.TimeSpan) = v874 v900
    let v907 : System.TimeSpan = v906 v586
    let _run_target_args'_v760 = v907 
    #endif
#else
    let v908 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v913 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v914 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v915 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v914 
    let _run_target_args'_v913 = v915 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v917 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v913 = v917 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v921 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v913 = v921 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v925 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v913 = v925 
    #endif
#if FABLE_COMPILER_PYTHON
    let v929 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v913 = v929 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v932 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v913 = v932 
    #endif
#else
    let v933 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v913 = v933 
    #endif
    let v934 : System.TimeZoneInfo = _run_target_args'_v913 
    let v940 : (System.DateTime -> System.TimeSpan) = v908 v934
    let v941 : System.TimeSpan = v940 v586
    let _run_target_args'_v760 = v941 
    #endif
    let v942 : System.TimeSpan = _run_target_args'_v760 
    let v952 : (System.TimeSpan -> int32) = _.Hours
    let v953 : int32 = v952 v942
    let v956 : bool = v953 > 0
    let v957 : uint8 =
        if v956 then
            1uy
        else
            0uy
    let v958 : string = method2()
    (* run_target_args'
    let v1012 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1013 : string = "$0.toString($1)"
    let v1014 : string = Fable.Core.RustInterop.emitRustExpr struct (v942, v958) v1013 
    let _run_target_args'_v1012 = v1014 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1015 : string = "$0.toString($1)"
    let v1016 : string = Fable.Core.RustInterop.emitRustExpr struct (v942, v958) v1015 
    let _run_target_args'_v1012 = v1016 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1017 : string = "$0.toString($1)"
    let v1018 : string = Fable.Core.RustInterop.emitRustExpr struct (v942, v958) v1017 
    let _run_target_args'_v1012 = v1018 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1019 : string = v942.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1012 = v1019 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1020 : string = v942.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1012 = v1020 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1022 : string = v942.ToString v958 
    let _run_target_args'_v1012 = v1022 
    #endif
#else
    let v1075 : string = v942.ToString v958 
    let _run_target_args'_v1012 = v1075 
    #endif
    let v1127 : string = _run_target_args'_v1012 
    let v1182 : string = $"{v957}{v1127.[0..1]}{v1127.[3..4]}"
    let v1184 : (System.Guid -> string) = _.ToString()
    let v1185 : string = v1184 v0
    let v1188 : int32 = v721.Length
    let v1189 : int32 = v1182.Length
    let v1190 : int32 = v1188 + v1189
    let v1192 : (string -> int32) = String.length
    let v1193 : int32 = v1192 v1185
    let v1201 : int32 = v1190 |> int32 
    let v1214 : int32 = v1193 |> int32 
    let v1222 : int32 = v1214 - 1
    let v1224 : string = v1185.[int v1201..int v1222]
    let v1228 : string = $"{v721}{v1182}{v1224}"
    (* run_target_args'
    let v1233 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1235 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1235 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1239 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1239 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1243 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1233 = v1243 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1247 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1247 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1251 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1251 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1255 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1255 
    #endif
#else
    let v1259 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1259 
    #endif
    let v1262 : System.Guid = _run_target_args'_v1233 
    let _run_target_args'_v569 = v1262 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1269 : System.DateTime = System.DateTime.UnixEpoch
    let v1273 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1274 : System.DateTime = v1273 v1269
    let v1278 : System.DateTimeKind = System.DateTimeKind.Local
    let v1279 : System.DateTime = System.DateTime.SpecifyKind (v1, v1278)
    let v1283 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1284 : System.DateTime = v1283 v1279
    (* run_target_args'
    let v1290 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1291 : (System.DateTime -> int64) = _.Ticks
    let v1292 : int64 = v1291 v1284
    let _run_target_args'_v1290 = v1292 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1293 : (System.DateTime -> int64) = _.Ticks
    let v1294 : int64 = v1293 v1284
    let _run_target_args'_v1290 = v1294 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1296 : int64 = null |> unbox<int64>
    let _run_target_args'_v1290 = v1296 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1299 : (System.DateTime -> int64) = _.Ticks
    let v1300 : int64 = v1299 v1284
    let _run_target_args'_v1290 = v1300 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1301 : (System.DateTime -> int64) = _.Ticks
    let v1302 : int64 = v1301 v1284
    let _run_target_args'_v1290 = v1302 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1303 : (System.DateTime -> int64) = _.Ticks
    let v1304 : int64 = v1303 v1284
    let _run_target_args'_v1290 = v1304 
    #endif
#else
    let v1305 : (System.DateTime -> int64) = _.Ticks
    let v1306 : int64 = v1305 v1284
    let _run_target_args'_v1290 = v1306 
    #endif
    let v1307 : int64 = _run_target_args'_v1290 
    (* run_target_args'
    let v1330 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1331 : (System.DateTime -> int64) = _.Ticks
    let v1332 : int64 = v1331 v1274
    let _run_target_args'_v1330 = v1332 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1333 : (System.DateTime -> int64) = _.Ticks
    let v1334 : int64 = v1333 v1274
    let _run_target_args'_v1330 = v1334 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1336 : int64 = null |> unbox<int64>
    let _run_target_args'_v1330 = v1336 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1339 : (System.DateTime -> int64) = _.Ticks
    let v1340 : int64 = v1339 v1274
    let _run_target_args'_v1330 = v1340 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1341 : (System.DateTime -> int64) = _.Ticks
    let v1342 : int64 = v1341 v1274
    let _run_target_args'_v1330 = v1342 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1343 : (System.DateTime -> int64) = _.Ticks
    let v1344 : int64 = v1343 v1274
    let _run_target_args'_v1330 = v1344 
    #endif
#else
    let v1345 : (System.DateTime -> int64) = _.Ticks
    let v1346 : int64 = v1345 v1274
    let _run_target_args'_v1330 = v1346 
    #endif
    let v1347 : int64 = _run_target_args'_v1330 
    let v1368 : int64 = v1307 |> int64 
    let v1372 : int64 = v1347 |> int64 
    let v1375 : int64 = v1368 - v1372
    let v1376 : int64 = v1375 / 10L
    let v1377 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1378 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1376 v1377 
    let v1380 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v1381 : US0 option = v1378 |> Option.map v1380 
    let v1394 : US0 = US0_1
    let v1395 : US0 = v1381 |> Option.defaultValue v1394 
    let v1415 : US1 =
        match v1395 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v1399) -> (* Some *)
            let v1400 : string = "$0.naive_utc()"
            let v1401 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1399 v1400 
            let v1402 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1403 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1401 v1402 
            let v1404 : string = "%Y%m%d-%H%M-%S%f"
            let v1405 : string = "r#\"" + v1404 + "\"#"
            let v1406 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1405 
            let v1407 : string = "$0.format($1).to_string()"
            let v1408 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1403, v1406) v1407 
            let v1409 : string = "fable_library_rust::String_::fromString($0)"
            let v1410 : string = Fable.Core.RustInterop.emitRustExpr v1408 v1409 
            let v1411 : string = $"{v1410.[0..17]}-{v1410.[18..21]}-{v1410.[22]}"
            US1_0(v1411)
    let v1419 : string =
        match v1415 with
        | US1_1 -> (* None *)
            let v1417 : string = ""
            v1417
        | US1_0(v1416) -> (* Some *)
            v1416
    (* run_target_args'
    let v1424 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1425 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1426 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1425 
    let _run_target_args'_v1424 = v1426 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1428 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1424 = v1428 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1432 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1424 = v1432 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1436 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1424 = v1436 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1440 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1424 = v1440 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1443 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1424 = v1443 
    #endif
#else
    let v1444 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1424 = v1444 
    #endif
    let v1445 : System.TimeZoneInfo = _run_target_args'_v1424 
    (* run_target_args'
    let v1458 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1462 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1463 : (System.DateTime -> int64) = _.Ticks
    let v1464 : int64 = v1463 v1284
    let _run_target_args'_v1462 = v1464 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1465 : (System.DateTime -> int64) = _.Ticks
    let v1466 : int64 = v1465 v1284
    let _run_target_args'_v1462 = v1466 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1468 : int64 = null |> unbox<int64>
    let _run_target_args'_v1462 = v1468 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1471 : (System.DateTime -> int64) = _.Ticks
    let v1472 : int64 = v1471 v1284
    let _run_target_args'_v1462 = v1472 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1473 : (System.DateTime -> int64) = _.Ticks
    let v1474 : int64 = v1473 v1284
    let _run_target_args'_v1462 = v1474 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1475 : (System.DateTime -> int64) = _.Ticks
    let v1476 : int64 = v1475 v1284
    let _run_target_args'_v1462 = v1476 
    #endif
#else
    let v1477 : (System.DateTime -> int64) = _.Ticks
    let v1478 : int64 = v1477 v1284
    let _run_target_args'_v1462 = v1478 
    #endif
    let v1479 : int64 = _run_target_args'_v1462 
    let v1499 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1500 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1284, v1479) v1499 
    let v1502 : System.TimeSpan = v1500 |> System.TimeSpan 
    let _run_target_args'_v1458 = v1502 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1508 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1509 : (System.DateTime -> int64) = _.Ticks
    let v1510 : int64 = v1509 v1284
    let _run_target_args'_v1508 = v1510 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1511 : (System.DateTime -> int64) = _.Ticks
    let v1512 : int64 = v1511 v1284
    let _run_target_args'_v1508 = v1512 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1514 : int64 = null |> unbox<int64>
    let _run_target_args'_v1508 = v1514 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1517 : (System.DateTime -> int64) = _.Ticks
    let v1518 : int64 = v1517 v1284
    let _run_target_args'_v1508 = v1518 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1519 : (System.DateTime -> int64) = _.Ticks
    let v1520 : int64 = v1519 v1284
    let _run_target_args'_v1508 = v1520 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1521 : (System.DateTime -> int64) = _.Ticks
    let v1522 : int64 = v1521 v1284
    let _run_target_args'_v1508 = v1522 
    #endif
#else
    let v1523 : (System.DateTime -> int64) = _.Ticks
    let v1524 : int64 = v1523 v1284
    let _run_target_args'_v1508 = v1524 
    #endif
    let v1525 : int64 = _run_target_args'_v1508 
    let v1545 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1546 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1284, v1525) v1545 
    let v1548 : System.TimeSpan = v1546 |> System.TimeSpan 
    let _run_target_args'_v1458 = v1548 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1552 : US2 = US2_2
    let v1553 : US3 = US3_3(v1552)
    let v1554 : string = $"date_time.get_utc_offset / target: {v1553}"
    let v1555 : System.TimeSpan = failwith<System.TimeSpan> v1554
    let _run_target_args'_v1458 = v1555 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1559 : US2 = US2_0
    let v1560 : US3 = US3_4(v1559)
    let v1561 : string = $"date_time.get_utc_offset / target: {v1560}"
    let v1562 : System.TimeSpan = failwith<System.TimeSpan> v1561
    let _run_target_args'_v1458 = v1562 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1566 : US2 = US2_0
    let v1567 : US3 = US3_5(v1566)
    let v1568 : string = $"date_time.get_utc_offset / target: {v1567}"
    let v1569 : System.TimeSpan = failwith<System.TimeSpan> v1568
    let _run_target_args'_v1458 = v1569 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1572 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1577 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1578 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1579 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1578 
    let _run_target_args'_v1577 = v1579 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1581 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1577 = v1581 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1585 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1577 = v1585 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1589 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1577 = v1589 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1593 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1577 = v1593 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1596 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1577 = v1596 
    #endif
#else
    let v1597 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1577 = v1597 
    #endif
    let v1598 : System.TimeZoneInfo = _run_target_args'_v1577 
    let v1604 : (System.DateTime -> System.TimeSpan) = v1572 v1598
    let v1605 : System.TimeSpan = v1604 v1284
    let _run_target_args'_v1458 = v1605 
    #endif
#else
    let v1606 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1611 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1612 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1613 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1612 
    let _run_target_args'_v1611 = v1613 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1615 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1611 = v1615 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1619 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1611 = v1619 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1623 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1611 = v1623 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1627 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1611 = v1627 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1630 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1611 = v1630 
    #endif
#else
    let v1631 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1611 = v1631 
    #endif
    let v1632 : System.TimeZoneInfo = _run_target_args'_v1611 
    let v1638 : (System.DateTime -> System.TimeSpan) = v1606 v1632
    let v1639 : System.TimeSpan = v1638 v1284
    let _run_target_args'_v1458 = v1639 
    #endif
    let v1640 : System.TimeSpan = _run_target_args'_v1458 
    let v1650 : (System.TimeSpan -> int32) = _.Hours
    let v1651 : int32 = v1650 v1640
    let v1654 : bool = v1651 > 0
    let v1655 : uint8 =
        if v1654 then
            1uy
        else
            0uy
    let v1656 : string = method2()
    (* run_target_args'
    let v1710 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1711 : string = "$0.toString($1)"
    let v1712 : string = Fable.Core.RustInterop.emitRustExpr struct (v1640, v1656) v1711 
    let _run_target_args'_v1710 = v1712 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1713 : string = "$0.toString($1)"
    let v1714 : string = Fable.Core.RustInterop.emitRustExpr struct (v1640, v1656) v1713 
    let _run_target_args'_v1710 = v1714 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1715 : string = "$0.toString($1)"
    let v1716 : string = Fable.Core.RustInterop.emitRustExpr struct (v1640, v1656) v1715 
    let _run_target_args'_v1710 = v1716 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1717 : string = v1640.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1710 = v1717 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1718 : string = v1640.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1710 = v1718 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1720 : string = v1640.ToString v1656 
    let _run_target_args'_v1710 = v1720 
    #endif
#else
    let v1773 : string = v1640.ToString v1656 
    let _run_target_args'_v1710 = v1773 
    #endif
    let v1825 : string = _run_target_args'_v1710 
    let v1880 : string = $"{v1655}{v1825.[0..1]}{v1825.[3..4]}"
    let v1882 : (System.Guid -> string) = _.ToString()
    let v1883 : string = v1882 v0
    let v1886 : int32 = v1419.Length
    let v1887 : int32 = v1880.Length
    let v1888 : int32 = v1886 + v1887
    let v1890 : (string -> int32) = String.length
    let v1891 : int32 = v1890 v1883
    let v1899 : int32 = v1888 |> int32 
    let v1912 : int32 = v1891 |> int32 
    let v1920 : int32 = v1912 - 1
    let v1922 : string = v1883.[int v1899..int v1920]
    let v1926 : string = $"{v1419}{v1880}{v1922}"
    (* run_target_args'
    let v1931 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1933 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1933 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1937 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1937 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1941 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1931 = v1941 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1945 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1945 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1949 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1949 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1953 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1953 
    #endif
#else
    let v1957 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1957 
    #endif
    let v1960 : System.Guid = _run_target_args'_v1931 
    let _run_target_args'_v569 = v1960 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1967 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v569 = v1967 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1970 : string = method3()
    let v1972 : bool = v1970 = ""
    let v1974 : string =
        if v1972 then
            let v1973 : string = "M-d-y hh:mm:ss tt"
            v1973
        else
            v1970
    let v1975 : (string -> string) = v1.ToString
    let v1976 : string = v1975 v1974
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
    (* run_target_args'
    let v2029 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2033 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2034 : (System.DateTime -> int64) = _.Ticks
    let v2035 : int64 = v2034 v1
    let _run_target_args'_v2033 = v2035 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2036 : (System.DateTime -> int64) = _.Ticks
    let v2037 : int64 = v2036 v1
    let _run_target_args'_v2033 = v2037 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2039 : int64 = null |> unbox<int64>
    let _run_target_args'_v2033 = v2039 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2042 : (System.DateTime -> int64) = _.Ticks
    let v2043 : int64 = v2042 v1
    let _run_target_args'_v2033 = v2043 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2044 : (System.DateTime -> int64) = _.Ticks
    let v2045 : int64 = v2044 v1
    let _run_target_args'_v2033 = v2045 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2046 : (System.DateTime -> int64) = _.Ticks
    let v2047 : int64 = v2046 v1
    let _run_target_args'_v2033 = v2047 
    #endif
#else
    let v2048 : (System.DateTime -> int64) = _.Ticks
    let v2049 : int64 = v2048 v1
    let _run_target_args'_v2033 = v2049 
    #endif
    let v2050 : int64 = _run_target_args'_v2033 
    let v2070 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2071 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2050) v2070 
    let v2073 : System.TimeSpan = v2071 |> System.TimeSpan 
    let _run_target_args'_v2029 = v2073 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2079 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2080 : (System.DateTime -> int64) = _.Ticks
    let v2081 : int64 = v2080 v1
    let _run_target_args'_v2079 = v2081 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2082 : (System.DateTime -> int64) = _.Ticks
    let v2083 : int64 = v2082 v1
    let _run_target_args'_v2079 = v2083 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2085 : int64 = null |> unbox<int64>
    let _run_target_args'_v2079 = v2085 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2088 : (System.DateTime -> int64) = _.Ticks
    let v2089 : int64 = v2088 v1
    let _run_target_args'_v2079 = v2089 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2090 : (System.DateTime -> int64) = _.Ticks
    let v2091 : int64 = v2090 v1
    let _run_target_args'_v2079 = v2091 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2092 : (System.DateTime -> int64) = _.Ticks
    let v2093 : int64 = v2092 v1
    let _run_target_args'_v2079 = v2093 
    #endif
#else
    let v2094 : (System.DateTime -> int64) = _.Ticks
    let v2095 : int64 = v2094 v1
    let _run_target_args'_v2079 = v2095 
    #endif
    let v2096 : int64 = _run_target_args'_v2079 
    let v2116 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2117 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2096) v2116 
    let v2119 : System.TimeSpan = v2117 |> System.TimeSpan 
    let _run_target_args'_v2029 = v2119 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2123 : US2 = US2_2
    let v2124 : US3 = US3_3(v2123)
    let v2125 : string = $"date_time.get_utc_offset / target: {v2124}"
    let v2126 : System.TimeSpan = failwith<System.TimeSpan> v2125
    let _run_target_args'_v2029 = v2126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2130 : US2 = US2_0
    let v2131 : US3 = US3_4(v2130)
    let v2132 : string = $"date_time.get_utc_offset / target: {v2131}"
    let v2133 : System.TimeSpan = failwith<System.TimeSpan> v2132
    let _run_target_args'_v2029 = v2133 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2137 : US2 = US2_0
    let v2138 : US3 = US3_5(v2137)
    let v2139 : string = $"date_time.get_utc_offset / target: {v2138}"
    let v2140 : System.TimeSpan = failwith<System.TimeSpan> v2139
    let _run_target_args'_v2029 = v2140 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2143 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2148 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2149 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2150 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2149 
    let _run_target_args'_v2148 = v2150 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2152 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2148 = v2152 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2156 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2148 = v2156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2160 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2148 = v2160 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2164 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2148 = v2164 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2167 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2148 = v2167 
    #endif
#else
    let v2168 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2148 = v2168 
    #endif
    let v2169 : System.TimeZoneInfo = _run_target_args'_v2148 
    let v2175 : (System.DateTime -> System.TimeSpan) = v2143 v2169
    let v2176 : System.TimeSpan = v2175 v1
    let _run_target_args'_v2029 = v2176 
    #endif
#else
    let v2177 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2182 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2183 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2184 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2183 
    let _run_target_args'_v2182 = v2184 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2186 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2182 = v2186 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2190 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2182 = v2190 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2194 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2182 = v2194 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2198 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2182 = v2198 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2201 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2182 = v2201 
    #endif
#else
    let v2202 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2182 = v2202 
    #endif
    let v2203 : System.TimeZoneInfo = _run_target_args'_v2182 
    let v2209 : (System.DateTime -> System.TimeSpan) = v2177 v2203
    let v2210 : System.TimeSpan = v2209 v1
    let _run_target_args'_v2029 = v2210 
    #endif
    let v2211 : System.TimeSpan = _run_target_args'_v2029 
    let v2221 : (System.TimeSpan -> int32) = _.Hours
    let v2222 : int32 = v2221 v2211
    let v2225 : bool = v2222 > 0
    let v2226 : uint8 =
        if v2225 then
            1uy
        else
            0uy
    let v2227 : string = method4()
    (* run_target_args'
    let v2281 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2282 : string = "$0.toString($1)"
    let v2283 : string = Fable.Core.RustInterop.emitRustExpr struct (v2211, v2227) v2282 
    let _run_target_args'_v2281 = v2283 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2284 : string = "$0.toString($1)"
    let v2285 : string = Fable.Core.RustInterop.emitRustExpr struct (v2211, v2227) v2284 
    let _run_target_args'_v2281 = v2285 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2286 : string = "$0.toString($1)"
    let v2287 : string = Fable.Core.RustInterop.emitRustExpr struct (v2211, v2227) v2286 
    let _run_target_args'_v2281 = v2287 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2288 : string = v2211.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2281 = v2288 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2289 : string = v2211.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2281 = v2289 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2291 : string = v2211.ToString v2227 
    let _run_target_args'_v2281 = v2291 
    #endif
#else
    let v2344 : string = v2211.ToString v2227 
    let _run_target_args'_v2281 = v2344 
    #endif
    let v2396 : string = _run_target_args'_v2281 
    let v2451 : string = $"{v2226}{v2396}"
    let v2453 : (System.Guid -> string) = _.ToString()
    let v2454 : string = v2453 v0
    let v2457 : int32 = v1976.Length
    let v2458 : int32 = v2451.Length
    let v2459 : int32 = v2457 + v2458
    let v2461 : (string -> int32) = String.length
    let v2462 : int32 = v2461 v2454
    let v2470 : int32 = v2459 |> int32 
    let v2483 : int32 = v2462 |> int32 
    let v2491 : int32 = v2483 - 1
    let v2493 : string = v2454.[int v2470..int v2491]
    let v2497 : string = $"{v1976}{v2451}{v2493}"
    (* run_target_args'
    let v2502 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2504 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2504 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2508 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2508 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2512 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2502 = v2512 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2516 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2516 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2520 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2520 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2524 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2524 
    #endif
#else
    let v2528 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2528 
    #endif
    let v2531 : System.Guid = _run_target_args'_v2502 
    let _run_target_args'_v569 = v2531 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2537 : string = method3()
    let v2539 : bool = v2537 = ""
    let v2541 : string =
        if v2539 then
            let v2540 : string = "M-d-y hh:mm:ss tt"
            v2540
        else
            v2537
    let v2542 : (string -> string) = v1.ToString
    let v2543 : string = v2542 v2541
    (* run_target_args'
    let v2562 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2563 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2564 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2563 
    let _run_target_args'_v2562 = v2564 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2566 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2562 = v2566 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2570 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2562 = v2570 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2574 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2562 = v2574 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2578 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2562 = v2578 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2581 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2562 = v2581 
    #endif
#else
    let v2582 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2562 = v2582 
    #endif
    let v2583 : System.TimeZoneInfo = _run_target_args'_v2562 
    (* run_target_args'
    let v2596 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2600 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2601 : (System.DateTime -> int64) = _.Ticks
    let v2602 : int64 = v2601 v1
    let _run_target_args'_v2600 = v2602 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2603 : (System.DateTime -> int64) = _.Ticks
    let v2604 : int64 = v2603 v1
    let _run_target_args'_v2600 = v2604 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2606 : int64 = null |> unbox<int64>
    let _run_target_args'_v2600 = v2606 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2609 : (System.DateTime -> int64) = _.Ticks
    let v2610 : int64 = v2609 v1
    let _run_target_args'_v2600 = v2610 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2611 : (System.DateTime -> int64) = _.Ticks
    let v2612 : int64 = v2611 v1
    let _run_target_args'_v2600 = v2612 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2613 : (System.DateTime -> int64) = _.Ticks
    let v2614 : int64 = v2613 v1
    let _run_target_args'_v2600 = v2614 
    #endif
#else
    let v2615 : (System.DateTime -> int64) = _.Ticks
    let v2616 : int64 = v2615 v1
    let _run_target_args'_v2600 = v2616 
    #endif
    let v2617 : int64 = _run_target_args'_v2600 
    let v2637 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2638 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2617) v2637 
    let v2640 : System.TimeSpan = v2638 |> System.TimeSpan 
    let _run_target_args'_v2596 = v2640 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2646 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2647 : (System.DateTime -> int64) = _.Ticks
    let v2648 : int64 = v2647 v1
    let _run_target_args'_v2646 = v2648 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2649 : (System.DateTime -> int64) = _.Ticks
    let v2650 : int64 = v2649 v1
    let _run_target_args'_v2646 = v2650 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2652 : int64 = null |> unbox<int64>
    let _run_target_args'_v2646 = v2652 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2655 : (System.DateTime -> int64) = _.Ticks
    let v2656 : int64 = v2655 v1
    let _run_target_args'_v2646 = v2656 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2657 : (System.DateTime -> int64) = _.Ticks
    let v2658 : int64 = v2657 v1
    let _run_target_args'_v2646 = v2658 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2659 : (System.DateTime -> int64) = _.Ticks
    let v2660 : int64 = v2659 v1
    let _run_target_args'_v2646 = v2660 
    #endif
#else
    let v2661 : (System.DateTime -> int64) = _.Ticks
    let v2662 : int64 = v2661 v1
    let _run_target_args'_v2646 = v2662 
    #endif
    let v2663 : int64 = _run_target_args'_v2646 
    let v2683 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2684 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2663) v2683 
    let v2686 : System.TimeSpan = v2684 |> System.TimeSpan 
    let _run_target_args'_v2596 = v2686 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2690 : US2 = US2_2
    let v2691 : US3 = US3_3(v2690)
    let v2692 : string = $"date_time.get_utc_offset / target: {v2691}"
    let v2693 : System.TimeSpan = failwith<System.TimeSpan> v2692
    let _run_target_args'_v2596 = v2693 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2697 : US2 = US2_0
    let v2698 : US3 = US3_4(v2697)
    let v2699 : string = $"date_time.get_utc_offset / target: {v2698}"
    let v2700 : System.TimeSpan = failwith<System.TimeSpan> v2699
    let _run_target_args'_v2596 = v2700 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2704 : US2 = US2_0
    let v2705 : US3 = US3_5(v2704)
    let v2706 : string = $"date_time.get_utc_offset / target: {v2705}"
    let v2707 : System.TimeSpan = failwith<System.TimeSpan> v2706
    let _run_target_args'_v2596 = v2707 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2710 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2715 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2716 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2717 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2716 
    let _run_target_args'_v2715 = v2717 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2719 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2715 = v2719 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2723 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2715 = v2723 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2727 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2715 = v2727 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2731 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2715 = v2731 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2734 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2715 = v2734 
    #endif
#else
    let v2735 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2715 = v2735 
    #endif
    let v2736 : System.TimeZoneInfo = _run_target_args'_v2715 
    let v2742 : (System.DateTime -> System.TimeSpan) = v2710 v2736
    let v2743 : System.TimeSpan = v2742 v1
    let _run_target_args'_v2596 = v2743 
    #endif
#else
    let v2744 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2749 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2750 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2751 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2750 
    let _run_target_args'_v2749 = v2751 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2753 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2749 = v2753 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2757 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2749 = v2757 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2761 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2749 = v2761 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2765 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2749 = v2765 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2768 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2749 = v2768 
    #endif
#else
    let v2769 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2749 = v2769 
    #endif
    let v2770 : System.TimeZoneInfo = _run_target_args'_v2749 
    let v2776 : (System.DateTime -> System.TimeSpan) = v2744 v2770
    let v2777 : System.TimeSpan = v2776 v1
    let _run_target_args'_v2596 = v2777 
    #endif
    let v2778 : System.TimeSpan = _run_target_args'_v2596 
    let v2788 : (System.TimeSpan -> int32) = _.Hours
    let v2789 : int32 = v2788 v2778
    let v2792 : bool = v2789 > 0
    let v2793 : uint8 =
        if v2792 then
            1uy
        else
            0uy
    let v2794 : string = method4()
    (* run_target_args'
    let v2848 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2849 : string = "$0.toString($1)"
    let v2850 : string = Fable.Core.RustInterop.emitRustExpr struct (v2778, v2794) v2849 
    let _run_target_args'_v2848 = v2850 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2851 : string = "$0.toString($1)"
    let v2852 : string = Fable.Core.RustInterop.emitRustExpr struct (v2778, v2794) v2851 
    let _run_target_args'_v2848 = v2852 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2853 : string = "$0.toString($1)"
    let v2854 : string = Fable.Core.RustInterop.emitRustExpr struct (v2778, v2794) v2853 
    let _run_target_args'_v2848 = v2854 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2855 : string = v2778.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2848 = v2855 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2856 : string = v2778.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2848 = v2856 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2858 : string = v2778.ToString v2794 
    let _run_target_args'_v2848 = v2858 
    #endif
#else
    let v2911 : string = v2778.ToString v2794 
    let _run_target_args'_v2848 = v2911 
    #endif
    let v2963 : string = _run_target_args'_v2848 
    let v3018 : string = $"{v2793}{v2963}"
    let v3020 : (System.Guid -> string) = _.ToString()
    let v3021 : string = v3020 v0
    let v3024 : int32 = v2543.Length
    let v3025 : int32 = v3018.Length
    let v3026 : int32 = v3024 + v3025
    let v3028 : (string -> int32) = String.length
    let v3029 : int32 = v3028 v3021
    let v3037 : int32 = v3026 |> int32 
    let v3050 : int32 = v3029 |> int32 
    let v3058 : int32 = v3050 - 1
    let v3060 : string = v3021.[int v3037..int v3058]
    let v3064 : string = $"{v2543}{v3018}{v3060}"
    (* run_target_args'
    let v3069 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3071 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3071 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3075 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3075 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3079 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3069 = v3079 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3083 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3083 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3087 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3087 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3091 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3091 
    #endif
#else
    let v3095 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3095 
    #endif
    let v3098 : System.Guid = _run_target_args'_v3069 
    let _run_target_args'_v569 = v3098 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3104 : string = method3()
    let v3106 : bool = v3104 = ""
    let v3108 : string =
        if v3106 then
            let v3107 : string = "M-d-y hh:mm:ss tt"
            v3107
        else
            v3104
    let v3109 : (string -> string) = v1.ToString
    let v3110 : string = v3109 v3108
    (* run_target_args'
    let v3129 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3130 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3131 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3130 
    let _run_target_args'_v3129 = v3131 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3133 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3129 = v3133 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3137 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3129 = v3137 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3141 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3129 = v3141 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3145 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3129 = v3145 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3148 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3129 = v3148 
    #endif
#else
    let v3149 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3129 = v3149 
    #endif
    let v3150 : System.TimeZoneInfo = _run_target_args'_v3129 
    (* run_target_args'
    let v3163 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3167 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3168 : (System.DateTime -> int64) = _.Ticks
    let v3169 : int64 = v3168 v1
    let _run_target_args'_v3167 = v3169 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3170 : (System.DateTime -> int64) = _.Ticks
    let v3171 : int64 = v3170 v1
    let _run_target_args'_v3167 = v3171 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3173 : int64 = null |> unbox<int64>
    let _run_target_args'_v3167 = v3173 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3176 : (System.DateTime -> int64) = _.Ticks
    let v3177 : int64 = v3176 v1
    let _run_target_args'_v3167 = v3177 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3178 : (System.DateTime -> int64) = _.Ticks
    let v3179 : int64 = v3178 v1
    let _run_target_args'_v3167 = v3179 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3180 : (System.DateTime -> int64) = _.Ticks
    let v3181 : int64 = v3180 v1
    let _run_target_args'_v3167 = v3181 
    #endif
#else
    let v3182 : (System.DateTime -> int64) = _.Ticks
    let v3183 : int64 = v3182 v1
    let _run_target_args'_v3167 = v3183 
    #endif
    let v3184 : int64 = _run_target_args'_v3167 
    let v3204 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3205 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3184) v3204 
    let v3207 : System.TimeSpan = v3205 |> System.TimeSpan 
    let _run_target_args'_v3163 = v3207 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3213 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3214 : (System.DateTime -> int64) = _.Ticks
    let v3215 : int64 = v3214 v1
    let _run_target_args'_v3213 = v3215 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3216 : (System.DateTime -> int64) = _.Ticks
    let v3217 : int64 = v3216 v1
    let _run_target_args'_v3213 = v3217 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3219 : int64 = null |> unbox<int64>
    let _run_target_args'_v3213 = v3219 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3222 : (System.DateTime -> int64) = _.Ticks
    let v3223 : int64 = v3222 v1
    let _run_target_args'_v3213 = v3223 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3224 : (System.DateTime -> int64) = _.Ticks
    let v3225 : int64 = v3224 v1
    let _run_target_args'_v3213 = v3225 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3226 : (System.DateTime -> int64) = _.Ticks
    let v3227 : int64 = v3226 v1
    let _run_target_args'_v3213 = v3227 
    #endif
#else
    let v3228 : (System.DateTime -> int64) = _.Ticks
    let v3229 : int64 = v3228 v1
    let _run_target_args'_v3213 = v3229 
    #endif
    let v3230 : int64 = _run_target_args'_v3213 
    let v3250 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3251 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3230) v3250 
    let v3253 : System.TimeSpan = v3251 |> System.TimeSpan 
    let _run_target_args'_v3163 = v3253 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3257 : US2 = US2_2
    let v3258 : US3 = US3_3(v3257)
    let v3259 : string = $"date_time.get_utc_offset / target: {v3258}"
    let v3260 : System.TimeSpan = failwith<System.TimeSpan> v3259
    let _run_target_args'_v3163 = v3260 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3264 : US2 = US2_0
    let v3265 : US3 = US3_4(v3264)
    let v3266 : string = $"date_time.get_utc_offset / target: {v3265}"
    let v3267 : System.TimeSpan = failwith<System.TimeSpan> v3266
    let _run_target_args'_v3163 = v3267 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3271 : US2 = US2_0
    let v3272 : US3 = US3_5(v3271)
    let v3273 : string = $"date_time.get_utc_offset / target: {v3272}"
    let v3274 : System.TimeSpan = failwith<System.TimeSpan> v3273
    let _run_target_args'_v3163 = v3274 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3277 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3282 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3283 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3284 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3283 
    let _run_target_args'_v3282 = v3284 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3286 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3282 = v3286 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3290 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3282 = v3290 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3294 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3282 = v3294 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3298 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3282 = v3298 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3301 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3282 = v3301 
    #endif
#else
    let v3302 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3282 = v3302 
    #endif
    let v3303 : System.TimeZoneInfo = _run_target_args'_v3282 
    let v3309 : (System.DateTime -> System.TimeSpan) = v3277 v3303
    let v3310 : System.TimeSpan = v3309 v1
    let _run_target_args'_v3163 = v3310 
    #endif
#else
    let v3311 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3316 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3317 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3318 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3317 
    let _run_target_args'_v3316 = v3318 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3320 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3316 = v3320 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3324 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3316 = v3324 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3328 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3316 = v3328 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3332 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3316 = v3332 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3335 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3316 = v3335 
    #endif
#else
    let v3336 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3316 = v3336 
    #endif
    let v3337 : System.TimeZoneInfo = _run_target_args'_v3316 
    let v3343 : (System.DateTime -> System.TimeSpan) = v3311 v3337
    let v3344 : System.TimeSpan = v3343 v1
    let _run_target_args'_v3163 = v3344 
    #endif
    let v3345 : System.TimeSpan = _run_target_args'_v3163 
    let v3355 : (System.TimeSpan -> int32) = _.Hours
    let v3356 : int32 = v3355 v3345
    let v3359 : bool = v3356 > 0
    let v3360 : uint8 =
        if v3359 then
            1uy
        else
            0uy
    let v3361 : string = method4()
    (* run_target_args'
    let v3415 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3416 : string = "$0.toString($1)"
    let v3417 : string = Fable.Core.RustInterop.emitRustExpr struct (v3345, v3361) v3416 
    let _run_target_args'_v3415 = v3417 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3418 : string = "$0.toString($1)"
    let v3419 : string = Fable.Core.RustInterop.emitRustExpr struct (v3345, v3361) v3418 
    let _run_target_args'_v3415 = v3419 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3420 : string = "$0.toString($1)"
    let v3421 : string = Fable.Core.RustInterop.emitRustExpr struct (v3345, v3361) v3420 
    let _run_target_args'_v3415 = v3421 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3422 : string = v3345.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3415 = v3422 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3423 : string = v3345.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3415 = v3423 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3425 : string = v3345.ToString v3361 
    let _run_target_args'_v3415 = v3425 
    #endif
#else
    let v3478 : string = v3345.ToString v3361 
    let _run_target_args'_v3415 = v3478 
    #endif
    let v3530 : string = _run_target_args'_v3415 
    let v3585 : string = $"{v3360}{v3530}"
    let v3587 : (System.Guid -> string) = _.ToString()
    let v3588 : string = v3587 v0
    let v3591 : int32 = v3110.Length
    let v3592 : int32 = v3585.Length
    let v3593 : int32 = v3591 + v3592
    let v3595 : (string -> int32) = String.length
    let v3596 : int32 = v3595 v3588
    let v3604 : int32 = v3593 |> int32 
    let v3617 : int32 = v3596 |> int32 
    let v3625 : int32 = v3617 - 1
    let v3627 : string = v3588.[int v3604..int v3625]
    let v3631 : string = $"{v3110}{v3585}{v3627}"
    (* run_target_args'
    let v3636 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3638 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3638 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3642 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3642 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3646 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3636 = v3646 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3650 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3650 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3654 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3654 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3658 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3658 
    #endif
#else
    let v3662 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3662 
    #endif
    let v3665 : System.Guid = _run_target_args'_v3636 
    let _run_target_args'_v569 = v3665 
    #endif
#else
    let v3671 : string = method3()
    let v3673 : bool = v3671 = ""
    let v3675 : string =
        if v3673 then
            let v3674 : string = "M-d-y hh:mm:ss tt"
            v3674
        else
            v3671
    let v3676 : (string -> string) = v1.ToString
    let v3677 : string = v3676 v3675
    (* run_target_args'
    let v3696 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3697 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3698 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3697 
    let _run_target_args'_v3696 = v3698 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3700 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3696 = v3700 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3704 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3696 = v3704 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3708 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3696 = v3708 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3712 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3696 = v3712 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3715 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3696 = v3715 
    #endif
#else
    let v3716 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3696 = v3716 
    #endif
    let v3717 : System.TimeZoneInfo = _run_target_args'_v3696 
    (* run_target_args'
    let v3730 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3734 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3735 : (System.DateTime -> int64) = _.Ticks
    let v3736 : int64 = v3735 v1
    let _run_target_args'_v3734 = v3736 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3737 : (System.DateTime -> int64) = _.Ticks
    let v3738 : int64 = v3737 v1
    let _run_target_args'_v3734 = v3738 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3740 : int64 = null |> unbox<int64>
    let _run_target_args'_v3734 = v3740 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3743 : (System.DateTime -> int64) = _.Ticks
    let v3744 : int64 = v3743 v1
    let _run_target_args'_v3734 = v3744 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3745 : (System.DateTime -> int64) = _.Ticks
    let v3746 : int64 = v3745 v1
    let _run_target_args'_v3734 = v3746 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3747 : (System.DateTime -> int64) = _.Ticks
    let v3748 : int64 = v3747 v1
    let _run_target_args'_v3734 = v3748 
    #endif
#else
    let v3749 : (System.DateTime -> int64) = _.Ticks
    let v3750 : int64 = v3749 v1
    let _run_target_args'_v3734 = v3750 
    #endif
    let v3751 : int64 = _run_target_args'_v3734 
    let v3771 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3772 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3751) v3771 
    let v3774 : System.TimeSpan = v3772 |> System.TimeSpan 
    let _run_target_args'_v3730 = v3774 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3780 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3781 : (System.DateTime -> int64) = _.Ticks
    let v3782 : int64 = v3781 v1
    let _run_target_args'_v3780 = v3782 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3783 : (System.DateTime -> int64) = _.Ticks
    let v3784 : int64 = v3783 v1
    let _run_target_args'_v3780 = v3784 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3786 : int64 = null |> unbox<int64>
    let _run_target_args'_v3780 = v3786 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3789 : (System.DateTime -> int64) = _.Ticks
    let v3790 : int64 = v3789 v1
    let _run_target_args'_v3780 = v3790 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3791 : (System.DateTime -> int64) = _.Ticks
    let v3792 : int64 = v3791 v1
    let _run_target_args'_v3780 = v3792 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3793 : (System.DateTime -> int64) = _.Ticks
    let v3794 : int64 = v3793 v1
    let _run_target_args'_v3780 = v3794 
    #endif
#else
    let v3795 : (System.DateTime -> int64) = _.Ticks
    let v3796 : int64 = v3795 v1
    let _run_target_args'_v3780 = v3796 
    #endif
    let v3797 : int64 = _run_target_args'_v3780 
    let v3817 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3818 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3797) v3817 
    let v3820 : System.TimeSpan = v3818 |> System.TimeSpan 
    let _run_target_args'_v3730 = v3820 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3824 : US2 = US2_2
    let v3825 : US3 = US3_3(v3824)
    let v3826 : string = $"date_time.get_utc_offset / target: {v3825}"
    let v3827 : System.TimeSpan = failwith<System.TimeSpan> v3826
    let _run_target_args'_v3730 = v3827 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3831 : US2 = US2_0
    let v3832 : US3 = US3_4(v3831)
    let v3833 : string = $"date_time.get_utc_offset / target: {v3832}"
    let v3834 : System.TimeSpan = failwith<System.TimeSpan> v3833
    let _run_target_args'_v3730 = v3834 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3838 : US2 = US2_0
    let v3839 : US3 = US3_5(v3838)
    let v3840 : string = $"date_time.get_utc_offset / target: {v3839}"
    let v3841 : System.TimeSpan = failwith<System.TimeSpan> v3840
    let _run_target_args'_v3730 = v3841 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3844 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3849 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3850 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3851 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3850 
    let _run_target_args'_v3849 = v3851 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3853 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3849 = v3853 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3857 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3849 = v3857 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3861 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3849 = v3861 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3865 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3849 = v3865 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3868 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3849 = v3868 
    #endif
#else
    let v3869 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3849 = v3869 
    #endif
    let v3870 : System.TimeZoneInfo = _run_target_args'_v3849 
    let v3876 : (System.DateTime -> System.TimeSpan) = v3844 v3870
    let v3877 : System.TimeSpan = v3876 v1
    let _run_target_args'_v3730 = v3877 
    #endif
#else
    let v3878 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3883 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3884 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3885 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3884 
    let _run_target_args'_v3883 = v3885 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3887 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3883 = v3887 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3891 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3883 = v3891 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3895 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3883 = v3895 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3899 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3883 = v3899 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3902 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3883 = v3902 
    #endif
#else
    let v3903 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3883 = v3903 
    #endif
    let v3904 : System.TimeZoneInfo = _run_target_args'_v3883 
    let v3910 : (System.DateTime -> System.TimeSpan) = v3878 v3904
    let v3911 : System.TimeSpan = v3910 v1
    let _run_target_args'_v3730 = v3911 
    #endif
    let v3912 : System.TimeSpan = _run_target_args'_v3730 
    let v3922 : (System.TimeSpan -> int32) = _.Hours
    let v3923 : int32 = v3922 v3912
    let v3926 : bool = v3923 > 0
    let v3927 : uint8 =
        if v3926 then
            1uy
        else
            0uy
    let v3928 : string = method4()
    (* run_target_args'
    let v3982 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3983 : string = "$0.toString($1)"
    let v3984 : string = Fable.Core.RustInterop.emitRustExpr struct (v3912, v3928) v3983 
    let _run_target_args'_v3982 = v3984 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3985 : string = "$0.toString($1)"
    let v3986 : string = Fable.Core.RustInterop.emitRustExpr struct (v3912, v3928) v3985 
    let _run_target_args'_v3982 = v3986 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3987 : string = "$0.toString($1)"
    let v3988 : string = Fable.Core.RustInterop.emitRustExpr struct (v3912, v3928) v3987 
    let _run_target_args'_v3982 = v3988 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3989 : string = v3912.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3982 = v3989 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3990 : string = v3912.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3982 = v3990 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3992 : string = v3912.ToString v3928 
    let _run_target_args'_v3982 = v3992 
    #endif
#else
    let v4045 : string = v3912.ToString v3928 
    let _run_target_args'_v3982 = v4045 
    #endif
    let v4097 : string = _run_target_args'_v3982 
    let v4152 : string = $"{v3927}{v4097}"
    let v4154 : (System.Guid -> string) = _.ToString()
    let v4155 : string = v4154 v0
    let v4158 : int32 = v3677.Length
    let v4159 : int32 = v4152.Length
    let v4160 : int32 = v4158 + v4159
    let v4162 : (string -> int32) = String.length
    let v4163 : int32 = v4162 v4155
    let v4171 : int32 = v4160 |> int32 
    let v4184 : int32 = v4163 |> int32 
    let v4192 : int32 = v4184 - 1
    let v4194 : string = v4155.[int v4171..int v4192]
    let v4198 : string = $"{v3677}{v4152}{v4194}"
    (* run_target_args'
    let v4203 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4205 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4205 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4209 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4209 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4213 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4203 = v4213 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4217 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4217 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4221 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4221 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4225 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4225 
    #endif
#else
    let v4229 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4229 
    #endif
    let v4232 : System.Guid = _run_target_args'_v4203 
    let _run_target_args'_v569 = v4232 
    #endif
    let v4238 : System.Guid = _run_target_args'_v569 
    v4238
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
        let v7 : string = v3 + v1 
        v6 v7
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
    let v23 : string = v22 + v9 
    let v24 : System.Guid = System.Guid $"{v23.[0..7]}-{v23.[8..11]}-{v23.[12..15]}-{v23.[16..17]}{v4.[21..]}"
    v24
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
    let v27 : string = v26 + v13 
    let v28 : System.Guid = System.Guid $"{v27.[0..7]}-{v27.[8..11]}-{v27.[12..15]}-{v27.[16..17]}{v8.[21..]}"
    v28
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
