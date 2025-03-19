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
    let v683 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v684 : US0 option = v680 |> Option.map v683 
    let v704 : US0 = US0_1
    let v705 : US0 = v684 |> Option.defaultValue v704 
    let v725 : US1 =
        match v705 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v709) -> (* Some *)
            let v710 : string = "$0.naive_utc()"
            let v711 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v709 v710 
            let v712 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v713 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v711 v712 
            let v714 : string = "%Y%m%d-%H%M-%S%f"
            let v715 : string = "r#\"" + v714 + "\"#"
            let v716 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v715 
            let v717 : string = "$0.format($1).to_string()"
            let v718 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v713, v716) v717 
            let v719 : string = "fable_library_rust::String_::fromString($0)"
            let v720 : string = Fable.Core.RustInterop.emitRustExpr v718 v719 
            let v721 : string = $"{v720.[0..17]}-{v720.[18..21]}-{v720.[22]}"
            US1_0(v721)
    let v729 : string =
        match v725 with
        | US1_1 -> (* None *)
            let v727 : string = ""
            v727
        | US1_0(v726) -> (* Some *)
            v726
    (* run_target_args'
    let v734 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v735 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v736 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v735 
    let _run_target_args'_v734 = v736 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v738 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v734 = v738 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v742 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v734 = v742 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v746 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v734 = v746 
    #endif
#if FABLE_COMPILER_PYTHON
    let v750 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v734 = v750 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v753 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v734 = v753 
    #endif
#else
    let v754 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v734 = v754 
    #endif
    let v755 : System.TimeZoneInfo = _run_target_args'_v734 
    (* run_target_args'
    let v768 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v772 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v773 : (System.DateTime -> int64) = _.Ticks
    let v774 : int64 = v773 v586
    let _run_target_args'_v772 = v774 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v775 : (System.DateTime -> int64) = _.Ticks
    let v776 : int64 = v775 v586
    let _run_target_args'_v772 = v776 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v778 : int64 = null |> unbox<int64>
    let _run_target_args'_v772 = v778 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v781 : (System.DateTime -> int64) = _.Ticks
    let v782 : int64 = v781 v586
    let _run_target_args'_v772 = v782 
    #endif
#if FABLE_COMPILER_PYTHON
    let v783 : (System.DateTime -> int64) = _.Ticks
    let v784 : int64 = v783 v586
    let _run_target_args'_v772 = v784 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v785 : (System.DateTime -> int64) = _.Ticks
    let v786 : int64 = v785 v586
    let _run_target_args'_v772 = v786 
    #endif
#else
    let v787 : (System.DateTime -> int64) = _.Ticks
    let v788 : int64 = v787 v586
    let _run_target_args'_v772 = v788 
    #endif
    let v789 : int64 = _run_target_args'_v772 
    let v809 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v810 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v789) v809 
    let v812 : System.TimeSpan = v810 |> System.TimeSpan 
    let _run_target_args'_v768 = v812 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v818 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v819 : (System.DateTime -> int64) = _.Ticks
    let v820 : int64 = v819 v586
    let _run_target_args'_v818 = v820 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v821 : (System.DateTime -> int64) = _.Ticks
    let v822 : int64 = v821 v586
    let _run_target_args'_v818 = v822 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v824 : int64 = null |> unbox<int64>
    let _run_target_args'_v818 = v824 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v827 : (System.DateTime -> int64) = _.Ticks
    let v828 : int64 = v827 v586
    let _run_target_args'_v818 = v828 
    #endif
#if FABLE_COMPILER_PYTHON
    let v829 : (System.DateTime -> int64) = _.Ticks
    let v830 : int64 = v829 v586
    let _run_target_args'_v818 = v830 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v831 : (System.DateTime -> int64) = _.Ticks
    let v832 : int64 = v831 v586
    let _run_target_args'_v818 = v832 
    #endif
#else
    let v833 : (System.DateTime -> int64) = _.Ticks
    let v834 : int64 = v833 v586
    let _run_target_args'_v818 = v834 
    #endif
    let v835 : int64 = _run_target_args'_v818 
    let v855 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v856 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v835) v855 
    let v858 : System.TimeSpan = v856 |> System.TimeSpan 
    let _run_target_args'_v768 = v858 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v862 : US2 = US2_2
    let v863 : US3 = US3_3(v862)
    let v864 : string = $"date_time.get_utc_offset / target: {v863}"
    let v865 : System.TimeSpan = failwith<System.TimeSpan> v864
    let _run_target_args'_v768 = v865 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v869 : US2 = US2_0
    let v870 : US3 = US3_4(v869)
    let v871 : string = $"date_time.get_utc_offset / target: {v870}"
    let v872 : System.TimeSpan = failwith<System.TimeSpan> v871
    let _run_target_args'_v768 = v872 
    #endif
#if FABLE_COMPILER_PYTHON
    let v876 : US2 = US2_0
    let v877 : US3 = US3_5(v876)
    let v878 : string = $"date_time.get_utc_offset / target: {v877}"
    let v879 : System.TimeSpan = failwith<System.TimeSpan> v878
    let _run_target_args'_v768 = v879 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v882 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v887 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v888 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v889 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v888 
    let _run_target_args'_v887 = v889 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v891 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v887 = v891 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v895 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v887 = v895 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v899 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v887 = v899 
    #endif
#if FABLE_COMPILER_PYTHON
    let v903 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v887 = v903 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v906 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v887 = v906 
    #endif
#else
    let v907 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v887 = v907 
    #endif
    let v908 : System.TimeZoneInfo = _run_target_args'_v887 
    let v914 : (System.DateTime -> System.TimeSpan) = v882 v908
    let v915 : System.TimeSpan = v914 v586
    let _run_target_args'_v768 = v915 
    #endif
#else
    let v916 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v921 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v922 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v923 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v922 
    let _run_target_args'_v921 = v923 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v925 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v921 = v925 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v929 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v921 = v929 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v933 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v921 = v933 
    #endif
#if FABLE_COMPILER_PYTHON
    let v937 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v921 = v937 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v940 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v921 = v940 
    #endif
#else
    let v941 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v921 = v941 
    #endif
    let v942 : System.TimeZoneInfo = _run_target_args'_v921 
    let v948 : (System.DateTime -> System.TimeSpan) = v916 v942
    let v949 : System.TimeSpan = v948 v586
    let _run_target_args'_v768 = v949 
    #endif
    let v950 : System.TimeSpan = _run_target_args'_v768 
    let v960 : (System.TimeSpan -> int32) = _.Hours
    let v961 : int32 = v960 v950
    let v964 : bool = v961 > 0
    let v965 : uint8 =
        if v964 then
            1uy
        else
            0uy
    let v966 : string = method2()
    (* run_target_args'
    let v1020 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1021 : string = "$0.toString($1)"
    let v1022 : string = Fable.Core.RustInterop.emitRustExpr struct (v950, v966) v1021 
    let _run_target_args'_v1020 = v1022 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1023 : string = "$0.toString($1)"
    let v1024 : string = Fable.Core.RustInterop.emitRustExpr struct (v950, v966) v1023 
    let _run_target_args'_v1020 = v1024 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1025 : string = "$0.toString($1)"
    let v1026 : string = Fable.Core.RustInterop.emitRustExpr struct (v950, v966) v1025 
    let _run_target_args'_v1020 = v1026 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1027 : string = v950.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1020 = v1027 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1028 : string = v950.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1020 = v1028 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1030 : string = v950.ToString v966 
    let _run_target_args'_v1020 = v1030 
    #endif
#else
    let v1083 : string = v950.ToString v966 
    let _run_target_args'_v1020 = v1083 
    #endif
    let v1135 : string = _run_target_args'_v1020 
    let v1190 : string = $"{v965}{v1135.[0..1]}{v1135.[3..4]}"
    let v1192 : (System.Guid -> string) = _.ToString()
    let v1193 : string = v1192 v0
    let v1196 : int32 = v729.Length
    let v1197 : int32 = v1190.Length
    let v1198 : int32 = v1196 + v1197
    let v1200 : (string -> int32) = String.length
    let v1201 : int32 = v1200 v1193
    let v1209 : int32 = v1198 |> int32 
    let v1222 : int32 = v1201 |> int32 
    let v1230 : int32 = v1222 - 1
    let v1232 : string = v1193.[int v1209..int v1230]
    let v1236 : string = $"{v729}{v1190}{v1232}"
    (* run_target_args'
    let v1241 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1243 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1243 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1247 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1247 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1251 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1241 = v1251 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1255 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1255 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1259 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1259 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1263 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1263 
    #endif
#else
    let v1267 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1267 
    #endif
    let v1270 : System.Guid = _run_target_args'_v1241 
    let _run_target_args'_v569 = v1270 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1277 : System.DateTime = System.DateTime.UnixEpoch
    let v1281 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1282 : System.DateTime = v1281 v1277
    let v1286 : System.DateTimeKind = System.DateTimeKind.Local
    let v1287 : System.DateTime = System.DateTime.SpecifyKind (v1, v1286)
    let v1291 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1292 : System.DateTime = v1291 v1287
    (* run_target_args'
    let v1298 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1299 : (System.DateTime -> int64) = _.Ticks
    let v1300 : int64 = v1299 v1292
    let _run_target_args'_v1298 = v1300 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1301 : (System.DateTime -> int64) = _.Ticks
    let v1302 : int64 = v1301 v1292
    let _run_target_args'_v1298 = v1302 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1304 : int64 = null |> unbox<int64>
    let _run_target_args'_v1298 = v1304 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1307 : (System.DateTime -> int64) = _.Ticks
    let v1308 : int64 = v1307 v1292
    let _run_target_args'_v1298 = v1308 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1309 : (System.DateTime -> int64) = _.Ticks
    let v1310 : int64 = v1309 v1292
    let _run_target_args'_v1298 = v1310 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1311 : (System.DateTime -> int64) = _.Ticks
    let v1312 : int64 = v1311 v1292
    let _run_target_args'_v1298 = v1312 
    #endif
#else
    let v1313 : (System.DateTime -> int64) = _.Ticks
    let v1314 : int64 = v1313 v1292
    let _run_target_args'_v1298 = v1314 
    #endif
    let v1315 : int64 = _run_target_args'_v1298 
    (* run_target_args'
    let v1338 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1339 : (System.DateTime -> int64) = _.Ticks
    let v1340 : int64 = v1339 v1282
    let _run_target_args'_v1338 = v1340 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1341 : (System.DateTime -> int64) = _.Ticks
    let v1342 : int64 = v1341 v1282
    let _run_target_args'_v1338 = v1342 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1344 : int64 = null |> unbox<int64>
    let _run_target_args'_v1338 = v1344 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1347 : (System.DateTime -> int64) = _.Ticks
    let v1348 : int64 = v1347 v1282
    let _run_target_args'_v1338 = v1348 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1349 : (System.DateTime -> int64) = _.Ticks
    let v1350 : int64 = v1349 v1282
    let _run_target_args'_v1338 = v1350 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1351 : (System.DateTime -> int64) = _.Ticks
    let v1352 : int64 = v1351 v1282
    let _run_target_args'_v1338 = v1352 
    #endif
#else
    let v1353 : (System.DateTime -> int64) = _.Ticks
    let v1354 : int64 = v1353 v1282
    let _run_target_args'_v1338 = v1354 
    #endif
    let v1355 : int64 = _run_target_args'_v1338 
    let v1376 : int64 = v1315 |> int64 
    let v1380 : int64 = v1355 |> int64 
    let v1383 : int64 = v1376 - v1380
    let v1384 : int64 = v1383 / 10L
    let v1385 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1386 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1384 v1385 
    let v1389 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v1390 : US0 option = v1386 |> Option.map v1389 
    let v1410 : US0 = US0_1
    let v1411 : US0 = v1390 |> Option.defaultValue v1410 
    let v1431 : US1 =
        match v1411 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v1415) -> (* Some *)
            let v1416 : string = "$0.naive_utc()"
            let v1417 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1415 v1416 
            let v1418 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1419 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1417 v1418 
            let v1420 : string = "%Y%m%d-%H%M-%S%f"
            let v1421 : string = "r#\"" + v1420 + "\"#"
            let v1422 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1421 
            let v1423 : string = "$0.format($1).to_string()"
            let v1424 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1419, v1422) v1423 
            let v1425 : string = "fable_library_rust::String_::fromString($0)"
            let v1426 : string = Fable.Core.RustInterop.emitRustExpr v1424 v1425 
            let v1427 : string = $"{v1426.[0..17]}-{v1426.[18..21]}-{v1426.[22]}"
            US1_0(v1427)
    let v1435 : string =
        match v1431 with
        | US1_1 -> (* None *)
            let v1433 : string = ""
            v1433
        | US1_0(v1432) -> (* Some *)
            v1432
    (* run_target_args'
    let v1440 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1441 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1442 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1441 
    let _run_target_args'_v1440 = v1442 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1444 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1440 = v1444 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1448 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1440 = v1448 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1452 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1440 = v1452 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1456 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1440 = v1456 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1459 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1440 = v1459 
    #endif
#else
    let v1460 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1440 = v1460 
    #endif
    let v1461 : System.TimeZoneInfo = _run_target_args'_v1440 
    (* run_target_args'
    let v1474 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1478 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1479 : (System.DateTime -> int64) = _.Ticks
    let v1480 : int64 = v1479 v1292
    let _run_target_args'_v1478 = v1480 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1481 : (System.DateTime -> int64) = _.Ticks
    let v1482 : int64 = v1481 v1292
    let _run_target_args'_v1478 = v1482 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1484 : int64 = null |> unbox<int64>
    let _run_target_args'_v1478 = v1484 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1487 : (System.DateTime -> int64) = _.Ticks
    let v1488 : int64 = v1487 v1292
    let _run_target_args'_v1478 = v1488 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1489 : (System.DateTime -> int64) = _.Ticks
    let v1490 : int64 = v1489 v1292
    let _run_target_args'_v1478 = v1490 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1491 : (System.DateTime -> int64) = _.Ticks
    let v1492 : int64 = v1491 v1292
    let _run_target_args'_v1478 = v1492 
    #endif
#else
    let v1493 : (System.DateTime -> int64) = _.Ticks
    let v1494 : int64 = v1493 v1292
    let _run_target_args'_v1478 = v1494 
    #endif
    let v1495 : int64 = _run_target_args'_v1478 
    let v1515 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1516 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1292, v1495) v1515 
    let v1518 : System.TimeSpan = v1516 |> System.TimeSpan 
    let _run_target_args'_v1474 = v1518 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1524 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1525 : (System.DateTime -> int64) = _.Ticks
    let v1526 : int64 = v1525 v1292
    let _run_target_args'_v1524 = v1526 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1527 : (System.DateTime -> int64) = _.Ticks
    let v1528 : int64 = v1527 v1292
    let _run_target_args'_v1524 = v1528 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1530 : int64 = null |> unbox<int64>
    let _run_target_args'_v1524 = v1530 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1533 : (System.DateTime -> int64) = _.Ticks
    let v1534 : int64 = v1533 v1292
    let _run_target_args'_v1524 = v1534 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1535 : (System.DateTime -> int64) = _.Ticks
    let v1536 : int64 = v1535 v1292
    let _run_target_args'_v1524 = v1536 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1537 : (System.DateTime -> int64) = _.Ticks
    let v1538 : int64 = v1537 v1292
    let _run_target_args'_v1524 = v1538 
    #endif
#else
    let v1539 : (System.DateTime -> int64) = _.Ticks
    let v1540 : int64 = v1539 v1292
    let _run_target_args'_v1524 = v1540 
    #endif
    let v1541 : int64 = _run_target_args'_v1524 
    let v1561 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1562 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1292, v1541) v1561 
    let v1564 : System.TimeSpan = v1562 |> System.TimeSpan 
    let _run_target_args'_v1474 = v1564 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1568 : US2 = US2_2
    let v1569 : US3 = US3_3(v1568)
    let v1570 : string = $"date_time.get_utc_offset / target: {v1569}"
    let v1571 : System.TimeSpan = failwith<System.TimeSpan> v1570
    let _run_target_args'_v1474 = v1571 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1575 : US2 = US2_0
    let v1576 : US3 = US3_4(v1575)
    let v1577 : string = $"date_time.get_utc_offset / target: {v1576}"
    let v1578 : System.TimeSpan = failwith<System.TimeSpan> v1577
    let _run_target_args'_v1474 = v1578 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1582 : US2 = US2_0
    let v1583 : US3 = US3_5(v1582)
    let v1584 : string = $"date_time.get_utc_offset / target: {v1583}"
    let v1585 : System.TimeSpan = failwith<System.TimeSpan> v1584
    let _run_target_args'_v1474 = v1585 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1588 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1593 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1594 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1595 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1594 
    let _run_target_args'_v1593 = v1595 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1597 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1593 = v1597 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1601 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1593 = v1601 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1605 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1593 = v1605 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1609 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1593 = v1609 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1612 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1593 = v1612 
    #endif
#else
    let v1613 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1593 = v1613 
    #endif
    let v1614 : System.TimeZoneInfo = _run_target_args'_v1593 
    let v1620 : (System.DateTime -> System.TimeSpan) = v1588 v1614
    let v1621 : System.TimeSpan = v1620 v1292
    let _run_target_args'_v1474 = v1621 
    #endif
#else
    let v1622 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1627 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1628 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1629 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1628 
    let _run_target_args'_v1627 = v1629 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1631 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1627 = v1631 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1635 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1627 = v1635 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1639 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1627 = v1639 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1643 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1627 = v1643 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1646 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1627 = v1646 
    #endif
#else
    let v1647 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1627 = v1647 
    #endif
    let v1648 : System.TimeZoneInfo = _run_target_args'_v1627 
    let v1654 : (System.DateTime -> System.TimeSpan) = v1622 v1648
    let v1655 : System.TimeSpan = v1654 v1292
    let _run_target_args'_v1474 = v1655 
    #endif
    let v1656 : System.TimeSpan = _run_target_args'_v1474 
    let v1666 : (System.TimeSpan -> int32) = _.Hours
    let v1667 : int32 = v1666 v1656
    let v1670 : bool = v1667 > 0
    let v1671 : uint8 =
        if v1670 then
            1uy
        else
            0uy
    let v1672 : string = method2()
    (* run_target_args'
    let v1726 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1727 : string = "$0.toString($1)"
    let v1728 : string = Fable.Core.RustInterop.emitRustExpr struct (v1656, v1672) v1727 
    let _run_target_args'_v1726 = v1728 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1729 : string = "$0.toString($1)"
    let v1730 : string = Fable.Core.RustInterop.emitRustExpr struct (v1656, v1672) v1729 
    let _run_target_args'_v1726 = v1730 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1731 : string = "$0.toString($1)"
    let v1732 : string = Fable.Core.RustInterop.emitRustExpr struct (v1656, v1672) v1731 
    let _run_target_args'_v1726 = v1732 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1733 : string = v1656.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1726 = v1733 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1734 : string = v1656.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1726 = v1734 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1736 : string = v1656.ToString v1672 
    let _run_target_args'_v1726 = v1736 
    #endif
#else
    let v1789 : string = v1656.ToString v1672 
    let _run_target_args'_v1726 = v1789 
    #endif
    let v1841 : string = _run_target_args'_v1726 
    let v1896 : string = $"{v1671}{v1841.[0..1]}{v1841.[3..4]}"
    let v1898 : (System.Guid -> string) = _.ToString()
    let v1899 : string = v1898 v0
    let v1902 : int32 = v1435.Length
    let v1903 : int32 = v1896.Length
    let v1904 : int32 = v1902 + v1903
    let v1906 : (string -> int32) = String.length
    let v1907 : int32 = v1906 v1899
    let v1915 : int32 = v1904 |> int32 
    let v1928 : int32 = v1907 |> int32 
    let v1936 : int32 = v1928 - 1
    let v1938 : string = v1899.[int v1915..int v1936]
    let v1942 : string = $"{v1435}{v1896}{v1938}"
    (* run_target_args'
    let v1947 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1949 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1949 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1953 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1953 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1957 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1947 = v1957 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1961 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1961 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1965 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1965 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1969 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1969 
    #endif
#else
    let v1973 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1973 
    #endif
    let v1976 : System.Guid = _run_target_args'_v1947 
    let _run_target_args'_v569 = v1976 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1983 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v569 = v1983 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1986 : string = method3()
    let v1988 : bool = v1986 = ""
    let v1990 : string =
        if v1988 then
            let v1989 : string = "M-d-y hh:mm:ss tt"
            v1989
        else
            v1986
    let v1991 : (string -> string) = v1.ToString
    let v1992 : string = v1991 v1990
    (* run_target_args'
    let v2011 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2012 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2013 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2012 
    let _run_target_args'_v2011 = v2013 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2015 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2011 = v2015 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2019 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2011 = v2019 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2023 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2011 = v2023 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2027 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2011 = v2027 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2030 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2011 = v2030 
    #endif
#else
    let v2031 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2011 = v2031 
    #endif
    let v2032 : System.TimeZoneInfo = _run_target_args'_v2011 
    (* run_target_args'
    let v2045 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2049 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2050 : (System.DateTime -> int64) = _.Ticks
    let v2051 : int64 = v2050 v1
    let _run_target_args'_v2049 = v2051 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2052 : (System.DateTime -> int64) = _.Ticks
    let v2053 : int64 = v2052 v1
    let _run_target_args'_v2049 = v2053 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2055 : int64 = null |> unbox<int64>
    let _run_target_args'_v2049 = v2055 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2058 : (System.DateTime -> int64) = _.Ticks
    let v2059 : int64 = v2058 v1
    let _run_target_args'_v2049 = v2059 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2060 : (System.DateTime -> int64) = _.Ticks
    let v2061 : int64 = v2060 v1
    let _run_target_args'_v2049 = v2061 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2062 : (System.DateTime -> int64) = _.Ticks
    let v2063 : int64 = v2062 v1
    let _run_target_args'_v2049 = v2063 
    #endif
#else
    let v2064 : (System.DateTime -> int64) = _.Ticks
    let v2065 : int64 = v2064 v1
    let _run_target_args'_v2049 = v2065 
    #endif
    let v2066 : int64 = _run_target_args'_v2049 
    let v2086 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2087 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2066) v2086 
    let v2089 : System.TimeSpan = v2087 |> System.TimeSpan 
    let _run_target_args'_v2045 = v2089 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2095 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2096 : (System.DateTime -> int64) = _.Ticks
    let v2097 : int64 = v2096 v1
    let _run_target_args'_v2095 = v2097 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2098 : (System.DateTime -> int64) = _.Ticks
    let v2099 : int64 = v2098 v1
    let _run_target_args'_v2095 = v2099 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2101 : int64 = null |> unbox<int64>
    let _run_target_args'_v2095 = v2101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2104 : (System.DateTime -> int64) = _.Ticks
    let v2105 : int64 = v2104 v1
    let _run_target_args'_v2095 = v2105 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2106 : (System.DateTime -> int64) = _.Ticks
    let v2107 : int64 = v2106 v1
    let _run_target_args'_v2095 = v2107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2108 : (System.DateTime -> int64) = _.Ticks
    let v2109 : int64 = v2108 v1
    let _run_target_args'_v2095 = v2109 
    #endif
#else
    let v2110 : (System.DateTime -> int64) = _.Ticks
    let v2111 : int64 = v2110 v1
    let _run_target_args'_v2095 = v2111 
    #endif
    let v2112 : int64 = _run_target_args'_v2095 
    let v2132 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2133 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2112) v2132 
    let v2135 : System.TimeSpan = v2133 |> System.TimeSpan 
    let _run_target_args'_v2045 = v2135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2139 : US2 = US2_2
    let v2140 : US3 = US3_3(v2139)
    let v2141 : string = $"date_time.get_utc_offset / target: {v2140}"
    let v2142 : System.TimeSpan = failwith<System.TimeSpan> v2141
    let _run_target_args'_v2045 = v2142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2146 : US2 = US2_0
    let v2147 : US3 = US3_4(v2146)
    let v2148 : string = $"date_time.get_utc_offset / target: {v2147}"
    let v2149 : System.TimeSpan = failwith<System.TimeSpan> v2148
    let _run_target_args'_v2045 = v2149 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2153 : US2 = US2_0
    let v2154 : US3 = US3_5(v2153)
    let v2155 : string = $"date_time.get_utc_offset / target: {v2154}"
    let v2156 : System.TimeSpan = failwith<System.TimeSpan> v2155
    let _run_target_args'_v2045 = v2156 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2159 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2164 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2165 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2166 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2165 
    let _run_target_args'_v2164 = v2166 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2168 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2164 = v2168 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2172 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2164 = v2172 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2176 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2164 = v2176 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2180 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2164 = v2180 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2183 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2164 = v2183 
    #endif
#else
    let v2184 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2164 = v2184 
    #endif
    let v2185 : System.TimeZoneInfo = _run_target_args'_v2164 
    let v2191 : (System.DateTime -> System.TimeSpan) = v2159 v2185
    let v2192 : System.TimeSpan = v2191 v1
    let _run_target_args'_v2045 = v2192 
    #endif
#else
    let v2193 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2198 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2199 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2200 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2199 
    let _run_target_args'_v2198 = v2200 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2202 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2198 = v2202 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2206 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2198 = v2206 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2210 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2198 = v2210 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2214 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2198 = v2214 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2217 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2198 = v2217 
    #endif
#else
    let v2218 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2198 = v2218 
    #endif
    let v2219 : System.TimeZoneInfo = _run_target_args'_v2198 
    let v2225 : (System.DateTime -> System.TimeSpan) = v2193 v2219
    let v2226 : System.TimeSpan = v2225 v1
    let _run_target_args'_v2045 = v2226 
    #endif
    let v2227 : System.TimeSpan = _run_target_args'_v2045 
    let v2237 : (System.TimeSpan -> int32) = _.Hours
    let v2238 : int32 = v2237 v2227
    let v2241 : bool = v2238 > 0
    let v2242 : uint8 =
        if v2241 then
            1uy
        else
            0uy
    let v2243 : string = method4()
    (* run_target_args'
    let v2297 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2298 : string = "$0.toString($1)"
    let v2299 : string = Fable.Core.RustInterop.emitRustExpr struct (v2227, v2243) v2298 
    let _run_target_args'_v2297 = v2299 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2300 : string = "$0.toString($1)"
    let v2301 : string = Fable.Core.RustInterop.emitRustExpr struct (v2227, v2243) v2300 
    let _run_target_args'_v2297 = v2301 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2302 : string = "$0.toString($1)"
    let v2303 : string = Fable.Core.RustInterop.emitRustExpr struct (v2227, v2243) v2302 
    let _run_target_args'_v2297 = v2303 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2304 : string = v2227.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2297 = v2304 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2305 : string = v2227.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2297 = v2305 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2307 : string = v2227.ToString v2243 
    let _run_target_args'_v2297 = v2307 
    #endif
#else
    let v2360 : string = v2227.ToString v2243 
    let _run_target_args'_v2297 = v2360 
    #endif
    let v2412 : string = _run_target_args'_v2297 
    let v2467 : string = $"{v2242}{v2412}"
    let v2469 : (System.Guid -> string) = _.ToString()
    let v2470 : string = v2469 v0
    let v2473 : int32 = v1992.Length
    let v2474 : int32 = v2467.Length
    let v2475 : int32 = v2473 + v2474
    let v2477 : (string -> int32) = String.length
    let v2478 : int32 = v2477 v2470
    let v2486 : int32 = v2475 |> int32 
    let v2499 : int32 = v2478 |> int32 
    let v2507 : int32 = v2499 - 1
    let v2509 : string = v2470.[int v2486..int v2507]
    let v2513 : string = $"{v1992}{v2467}{v2509}"
    (* run_target_args'
    let v2518 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2520 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2520 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2524 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2524 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2528 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2518 = v2528 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2532 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2532 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2536 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2536 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2540 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2540 
    #endif
#else
    let v2544 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2544 
    #endif
    let v2547 : System.Guid = _run_target_args'_v2518 
    let _run_target_args'_v569 = v2547 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2553 : string = method3()
    let v2555 : bool = v2553 = ""
    let v2557 : string =
        if v2555 then
            let v2556 : string = "M-d-y hh:mm:ss tt"
            v2556
        else
            v2553
    let v2558 : (string -> string) = v1.ToString
    let v2559 : string = v2558 v2557
    (* run_target_args'
    let v2578 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2579 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2580 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2579 
    let _run_target_args'_v2578 = v2580 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2582 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2578 = v2582 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2586 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2578 = v2586 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2590 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2578 = v2590 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2594 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2578 = v2594 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2597 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2578 = v2597 
    #endif
#else
    let v2598 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2578 = v2598 
    #endif
    let v2599 : System.TimeZoneInfo = _run_target_args'_v2578 
    (* run_target_args'
    let v2612 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2616 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2617 : (System.DateTime -> int64) = _.Ticks
    let v2618 : int64 = v2617 v1
    let _run_target_args'_v2616 = v2618 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2619 : (System.DateTime -> int64) = _.Ticks
    let v2620 : int64 = v2619 v1
    let _run_target_args'_v2616 = v2620 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2622 : int64 = null |> unbox<int64>
    let _run_target_args'_v2616 = v2622 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2625 : (System.DateTime -> int64) = _.Ticks
    let v2626 : int64 = v2625 v1
    let _run_target_args'_v2616 = v2626 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2627 : (System.DateTime -> int64) = _.Ticks
    let v2628 : int64 = v2627 v1
    let _run_target_args'_v2616 = v2628 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2629 : (System.DateTime -> int64) = _.Ticks
    let v2630 : int64 = v2629 v1
    let _run_target_args'_v2616 = v2630 
    #endif
#else
    let v2631 : (System.DateTime -> int64) = _.Ticks
    let v2632 : int64 = v2631 v1
    let _run_target_args'_v2616 = v2632 
    #endif
    let v2633 : int64 = _run_target_args'_v2616 
    let v2653 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2654 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2633) v2653 
    let v2656 : System.TimeSpan = v2654 |> System.TimeSpan 
    let _run_target_args'_v2612 = v2656 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2662 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2663 : (System.DateTime -> int64) = _.Ticks
    let v2664 : int64 = v2663 v1
    let _run_target_args'_v2662 = v2664 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2665 : (System.DateTime -> int64) = _.Ticks
    let v2666 : int64 = v2665 v1
    let _run_target_args'_v2662 = v2666 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2668 : int64 = null |> unbox<int64>
    let _run_target_args'_v2662 = v2668 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2671 : (System.DateTime -> int64) = _.Ticks
    let v2672 : int64 = v2671 v1
    let _run_target_args'_v2662 = v2672 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2673 : (System.DateTime -> int64) = _.Ticks
    let v2674 : int64 = v2673 v1
    let _run_target_args'_v2662 = v2674 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2675 : (System.DateTime -> int64) = _.Ticks
    let v2676 : int64 = v2675 v1
    let _run_target_args'_v2662 = v2676 
    #endif
#else
    let v2677 : (System.DateTime -> int64) = _.Ticks
    let v2678 : int64 = v2677 v1
    let _run_target_args'_v2662 = v2678 
    #endif
    let v2679 : int64 = _run_target_args'_v2662 
    let v2699 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2700 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2679) v2699 
    let v2702 : System.TimeSpan = v2700 |> System.TimeSpan 
    let _run_target_args'_v2612 = v2702 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2706 : US2 = US2_2
    let v2707 : US3 = US3_3(v2706)
    let v2708 : string = $"date_time.get_utc_offset / target: {v2707}"
    let v2709 : System.TimeSpan = failwith<System.TimeSpan> v2708
    let _run_target_args'_v2612 = v2709 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2713 : US2 = US2_0
    let v2714 : US3 = US3_4(v2713)
    let v2715 : string = $"date_time.get_utc_offset / target: {v2714}"
    let v2716 : System.TimeSpan = failwith<System.TimeSpan> v2715
    let _run_target_args'_v2612 = v2716 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2720 : US2 = US2_0
    let v2721 : US3 = US3_5(v2720)
    let v2722 : string = $"date_time.get_utc_offset / target: {v2721}"
    let v2723 : System.TimeSpan = failwith<System.TimeSpan> v2722
    let _run_target_args'_v2612 = v2723 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2726 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2731 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2732 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2733 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2732 
    let _run_target_args'_v2731 = v2733 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2735 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2731 = v2735 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2739 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2731 = v2739 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2743 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2731 = v2743 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2747 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2731 = v2747 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2750 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2731 = v2750 
    #endif
#else
    let v2751 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2731 = v2751 
    #endif
    let v2752 : System.TimeZoneInfo = _run_target_args'_v2731 
    let v2758 : (System.DateTime -> System.TimeSpan) = v2726 v2752
    let v2759 : System.TimeSpan = v2758 v1
    let _run_target_args'_v2612 = v2759 
    #endif
#else
    let v2760 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2765 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2766 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2767 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2766 
    let _run_target_args'_v2765 = v2767 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2769 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2765 = v2769 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2773 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2765 = v2773 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2777 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2765 = v2777 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2781 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2765 = v2781 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2784 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2765 = v2784 
    #endif
#else
    let v2785 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2765 = v2785 
    #endif
    let v2786 : System.TimeZoneInfo = _run_target_args'_v2765 
    let v2792 : (System.DateTime -> System.TimeSpan) = v2760 v2786
    let v2793 : System.TimeSpan = v2792 v1
    let _run_target_args'_v2612 = v2793 
    #endif
    let v2794 : System.TimeSpan = _run_target_args'_v2612 
    let v2804 : (System.TimeSpan -> int32) = _.Hours
    let v2805 : int32 = v2804 v2794
    let v2808 : bool = v2805 > 0
    let v2809 : uint8 =
        if v2808 then
            1uy
        else
            0uy
    let v2810 : string = method4()
    (* run_target_args'
    let v2864 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2865 : string = "$0.toString($1)"
    let v2866 : string = Fable.Core.RustInterop.emitRustExpr struct (v2794, v2810) v2865 
    let _run_target_args'_v2864 = v2866 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2867 : string = "$0.toString($1)"
    let v2868 : string = Fable.Core.RustInterop.emitRustExpr struct (v2794, v2810) v2867 
    let _run_target_args'_v2864 = v2868 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2869 : string = "$0.toString($1)"
    let v2870 : string = Fable.Core.RustInterop.emitRustExpr struct (v2794, v2810) v2869 
    let _run_target_args'_v2864 = v2870 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2871 : string = v2794.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2864 = v2871 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2872 : string = v2794.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2864 = v2872 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2874 : string = v2794.ToString v2810 
    let _run_target_args'_v2864 = v2874 
    #endif
#else
    let v2927 : string = v2794.ToString v2810 
    let _run_target_args'_v2864 = v2927 
    #endif
    let v2979 : string = _run_target_args'_v2864 
    let v3034 : string = $"{v2809}{v2979}"
    let v3036 : (System.Guid -> string) = _.ToString()
    let v3037 : string = v3036 v0
    let v3040 : int32 = v2559.Length
    let v3041 : int32 = v3034.Length
    let v3042 : int32 = v3040 + v3041
    let v3044 : (string -> int32) = String.length
    let v3045 : int32 = v3044 v3037
    let v3053 : int32 = v3042 |> int32 
    let v3066 : int32 = v3045 |> int32 
    let v3074 : int32 = v3066 - 1
    let v3076 : string = v3037.[int v3053..int v3074]
    let v3080 : string = $"{v2559}{v3034}{v3076}"
    (* run_target_args'
    let v3085 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3087 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3087 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3091 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3091 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3095 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3085 = v3095 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3099 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3099 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3103 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3103 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3107 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3107 
    #endif
#else
    let v3111 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3111 
    #endif
    let v3114 : System.Guid = _run_target_args'_v3085 
    let _run_target_args'_v569 = v3114 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3120 : string = method3()
    let v3122 : bool = v3120 = ""
    let v3124 : string =
        if v3122 then
            let v3123 : string = "M-d-y hh:mm:ss tt"
            v3123
        else
            v3120
    let v3125 : (string -> string) = v1.ToString
    let v3126 : string = v3125 v3124
    (* run_target_args'
    let v3145 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3146 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3147 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3146 
    let _run_target_args'_v3145 = v3147 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3149 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3145 = v3149 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3153 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3145 = v3153 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3157 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3145 = v3157 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3161 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3145 = v3161 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3164 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3145 = v3164 
    #endif
#else
    let v3165 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3145 = v3165 
    #endif
    let v3166 : System.TimeZoneInfo = _run_target_args'_v3145 
    (* run_target_args'
    let v3179 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3183 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3184 : (System.DateTime -> int64) = _.Ticks
    let v3185 : int64 = v3184 v1
    let _run_target_args'_v3183 = v3185 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3186 : (System.DateTime -> int64) = _.Ticks
    let v3187 : int64 = v3186 v1
    let _run_target_args'_v3183 = v3187 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3189 : int64 = null |> unbox<int64>
    let _run_target_args'_v3183 = v3189 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3192 : (System.DateTime -> int64) = _.Ticks
    let v3193 : int64 = v3192 v1
    let _run_target_args'_v3183 = v3193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3194 : (System.DateTime -> int64) = _.Ticks
    let v3195 : int64 = v3194 v1
    let _run_target_args'_v3183 = v3195 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3196 : (System.DateTime -> int64) = _.Ticks
    let v3197 : int64 = v3196 v1
    let _run_target_args'_v3183 = v3197 
    #endif
#else
    let v3198 : (System.DateTime -> int64) = _.Ticks
    let v3199 : int64 = v3198 v1
    let _run_target_args'_v3183 = v3199 
    #endif
    let v3200 : int64 = _run_target_args'_v3183 
    let v3220 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3221 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3200) v3220 
    let v3223 : System.TimeSpan = v3221 |> System.TimeSpan 
    let _run_target_args'_v3179 = v3223 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3229 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3230 : (System.DateTime -> int64) = _.Ticks
    let v3231 : int64 = v3230 v1
    let _run_target_args'_v3229 = v3231 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3232 : (System.DateTime -> int64) = _.Ticks
    let v3233 : int64 = v3232 v1
    let _run_target_args'_v3229 = v3233 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3235 : int64 = null |> unbox<int64>
    let _run_target_args'_v3229 = v3235 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3238 : (System.DateTime -> int64) = _.Ticks
    let v3239 : int64 = v3238 v1
    let _run_target_args'_v3229 = v3239 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3240 : (System.DateTime -> int64) = _.Ticks
    let v3241 : int64 = v3240 v1
    let _run_target_args'_v3229 = v3241 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3242 : (System.DateTime -> int64) = _.Ticks
    let v3243 : int64 = v3242 v1
    let _run_target_args'_v3229 = v3243 
    #endif
#else
    let v3244 : (System.DateTime -> int64) = _.Ticks
    let v3245 : int64 = v3244 v1
    let _run_target_args'_v3229 = v3245 
    #endif
    let v3246 : int64 = _run_target_args'_v3229 
    let v3266 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3267 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3246) v3266 
    let v3269 : System.TimeSpan = v3267 |> System.TimeSpan 
    let _run_target_args'_v3179 = v3269 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3273 : US2 = US2_2
    let v3274 : US3 = US3_3(v3273)
    let v3275 : string = $"date_time.get_utc_offset / target: {v3274}"
    let v3276 : System.TimeSpan = failwith<System.TimeSpan> v3275
    let _run_target_args'_v3179 = v3276 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3280 : US2 = US2_0
    let v3281 : US3 = US3_4(v3280)
    let v3282 : string = $"date_time.get_utc_offset / target: {v3281}"
    let v3283 : System.TimeSpan = failwith<System.TimeSpan> v3282
    let _run_target_args'_v3179 = v3283 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3287 : US2 = US2_0
    let v3288 : US3 = US3_5(v3287)
    let v3289 : string = $"date_time.get_utc_offset / target: {v3288}"
    let v3290 : System.TimeSpan = failwith<System.TimeSpan> v3289
    let _run_target_args'_v3179 = v3290 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3293 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3298 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3299 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3300 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3299 
    let _run_target_args'_v3298 = v3300 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3302 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3298 = v3302 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3306 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3298 = v3306 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3310 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3298 = v3310 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3314 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3298 = v3314 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3317 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3298 = v3317 
    #endif
#else
    let v3318 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3298 = v3318 
    #endif
    let v3319 : System.TimeZoneInfo = _run_target_args'_v3298 
    let v3325 : (System.DateTime -> System.TimeSpan) = v3293 v3319
    let v3326 : System.TimeSpan = v3325 v1
    let _run_target_args'_v3179 = v3326 
    #endif
#else
    let v3327 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3332 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3333 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3334 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3333 
    let _run_target_args'_v3332 = v3334 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3336 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3332 = v3336 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3340 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3332 = v3340 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3344 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3332 = v3344 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3348 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3332 = v3348 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3351 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3332 = v3351 
    #endif
#else
    let v3352 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3332 = v3352 
    #endif
    let v3353 : System.TimeZoneInfo = _run_target_args'_v3332 
    let v3359 : (System.DateTime -> System.TimeSpan) = v3327 v3353
    let v3360 : System.TimeSpan = v3359 v1
    let _run_target_args'_v3179 = v3360 
    #endif
    let v3361 : System.TimeSpan = _run_target_args'_v3179 
    let v3371 : (System.TimeSpan -> int32) = _.Hours
    let v3372 : int32 = v3371 v3361
    let v3375 : bool = v3372 > 0
    let v3376 : uint8 =
        if v3375 then
            1uy
        else
            0uy
    let v3377 : string = method4()
    (* run_target_args'
    let v3431 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3432 : string = "$0.toString($1)"
    let v3433 : string = Fable.Core.RustInterop.emitRustExpr struct (v3361, v3377) v3432 
    let _run_target_args'_v3431 = v3433 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3434 : string = "$0.toString($1)"
    let v3435 : string = Fable.Core.RustInterop.emitRustExpr struct (v3361, v3377) v3434 
    let _run_target_args'_v3431 = v3435 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3436 : string = "$0.toString($1)"
    let v3437 : string = Fable.Core.RustInterop.emitRustExpr struct (v3361, v3377) v3436 
    let _run_target_args'_v3431 = v3437 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3438 : string = v3361.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3431 = v3438 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3439 : string = v3361.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3431 = v3439 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3441 : string = v3361.ToString v3377 
    let _run_target_args'_v3431 = v3441 
    #endif
#else
    let v3494 : string = v3361.ToString v3377 
    let _run_target_args'_v3431 = v3494 
    #endif
    let v3546 : string = _run_target_args'_v3431 
    let v3601 : string = $"{v3376}{v3546}"
    let v3603 : (System.Guid -> string) = _.ToString()
    let v3604 : string = v3603 v0
    let v3607 : int32 = v3126.Length
    let v3608 : int32 = v3601.Length
    let v3609 : int32 = v3607 + v3608
    let v3611 : (string -> int32) = String.length
    let v3612 : int32 = v3611 v3604
    let v3620 : int32 = v3609 |> int32 
    let v3633 : int32 = v3612 |> int32 
    let v3641 : int32 = v3633 - 1
    let v3643 : string = v3604.[int v3620..int v3641]
    let v3647 : string = $"{v3126}{v3601}{v3643}"
    (* run_target_args'
    let v3652 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3654 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3654 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3658 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3658 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3662 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3652 = v3662 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3666 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3666 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3670 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3670 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3674 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3674 
    #endif
#else
    let v3678 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3678 
    #endif
    let v3681 : System.Guid = _run_target_args'_v3652 
    let _run_target_args'_v569 = v3681 
    #endif
#else
    let v3687 : string = method3()
    let v3689 : bool = v3687 = ""
    let v3691 : string =
        if v3689 then
            let v3690 : string = "M-d-y hh:mm:ss tt"
            v3690
        else
            v3687
    let v3692 : (string -> string) = v1.ToString
    let v3693 : string = v3692 v3691
    (* run_target_args'
    let v3712 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3713 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3714 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3713 
    let _run_target_args'_v3712 = v3714 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3716 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3712 = v3716 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3720 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3712 = v3720 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3724 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3712 = v3724 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3728 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3712 = v3728 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3731 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3712 = v3731 
    #endif
#else
    let v3732 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3712 = v3732 
    #endif
    let v3733 : System.TimeZoneInfo = _run_target_args'_v3712 
    (* run_target_args'
    let v3746 : unit = ()
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
    let v3787 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3788 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3767) v3787 
    let v3790 : System.TimeSpan = v3788 |> System.TimeSpan 
    let _run_target_args'_v3746 = v3790 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3796 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3797 : (System.DateTime -> int64) = _.Ticks
    let v3798 : int64 = v3797 v1
    let _run_target_args'_v3796 = v3798 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3799 : (System.DateTime -> int64) = _.Ticks
    let v3800 : int64 = v3799 v1
    let _run_target_args'_v3796 = v3800 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3802 : int64 = null |> unbox<int64>
    let _run_target_args'_v3796 = v3802 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3805 : (System.DateTime -> int64) = _.Ticks
    let v3806 : int64 = v3805 v1
    let _run_target_args'_v3796 = v3806 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3807 : (System.DateTime -> int64) = _.Ticks
    let v3808 : int64 = v3807 v1
    let _run_target_args'_v3796 = v3808 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3809 : (System.DateTime -> int64) = _.Ticks
    let v3810 : int64 = v3809 v1
    let _run_target_args'_v3796 = v3810 
    #endif
#else
    let v3811 : (System.DateTime -> int64) = _.Ticks
    let v3812 : int64 = v3811 v1
    let _run_target_args'_v3796 = v3812 
    #endif
    let v3813 : int64 = _run_target_args'_v3796 
    let v3833 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3834 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3813) v3833 
    let v3836 : System.TimeSpan = v3834 |> System.TimeSpan 
    let _run_target_args'_v3746 = v3836 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3840 : US2 = US2_2
    let v3841 : US3 = US3_3(v3840)
    let v3842 : string = $"date_time.get_utc_offset / target: {v3841}"
    let v3843 : System.TimeSpan = failwith<System.TimeSpan> v3842
    let _run_target_args'_v3746 = v3843 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3847 : US2 = US2_0
    let v3848 : US3 = US3_4(v3847)
    let v3849 : string = $"date_time.get_utc_offset / target: {v3848}"
    let v3850 : System.TimeSpan = failwith<System.TimeSpan> v3849
    let _run_target_args'_v3746 = v3850 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3854 : US2 = US2_0
    let v3855 : US3 = US3_5(v3854)
    let v3856 : string = $"date_time.get_utc_offset / target: {v3855}"
    let v3857 : System.TimeSpan = failwith<System.TimeSpan> v3856
    let _run_target_args'_v3746 = v3857 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3860 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3865 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3866 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3867 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3866 
    let _run_target_args'_v3865 = v3867 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3869 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3865 = v3869 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3873 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3865 = v3873 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3877 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3865 = v3877 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3881 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3865 = v3881 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3884 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3865 = v3884 
    #endif
#else
    let v3885 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3865 = v3885 
    #endif
    let v3886 : System.TimeZoneInfo = _run_target_args'_v3865 
    let v3892 : (System.DateTime -> System.TimeSpan) = v3860 v3886
    let v3893 : System.TimeSpan = v3892 v1
    let _run_target_args'_v3746 = v3893 
    #endif
#else
    let v3894 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3899 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3900 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3901 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3900 
    let _run_target_args'_v3899 = v3901 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3903 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3899 = v3903 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3907 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3899 = v3907 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3911 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3899 = v3911 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3915 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3899 = v3915 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3918 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3899 = v3918 
    #endif
#else
    let v3919 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3899 = v3919 
    #endif
    let v3920 : System.TimeZoneInfo = _run_target_args'_v3899 
    let v3926 : (System.DateTime -> System.TimeSpan) = v3894 v3920
    let v3927 : System.TimeSpan = v3926 v1
    let _run_target_args'_v3746 = v3927 
    #endif
    let v3928 : System.TimeSpan = _run_target_args'_v3746 
    let v3938 : (System.TimeSpan -> int32) = _.Hours
    let v3939 : int32 = v3938 v3928
    let v3942 : bool = v3939 > 0
    let v3943 : uint8 =
        if v3942 then
            1uy
        else
            0uy
    let v3944 : string = method4()
    (* run_target_args'
    let v3998 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3999 : string = "$0.toString($1)"
    let v4000 : string = Fable.Core.RustInterop.emitRustExpr struct (v3928, v3944) v3999 
    let _run_target_args'_v3998 = v4000 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4001 : string = "$0.toString($1)"
    let v4002 : string = Fable.Core.RustInterop.emitRustExpr struct (v3928, v3944) v4001 
    let _run_target_args'_v3998 = v4002 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4003 : string = "$0.toString($1)"
    let v4004 : string = Fable.Core.RustInterop.emitRustExpr struct (v3928, v3944) v4003 
    let _run_target_args'_v3998 = v4004 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4005 : string = v3928.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3998 = v4005 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4006 : string = v3928.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3998 = v4006 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4008 : string = v3928.ToString v3944 
    let _run_target_args'_v3998 = v4008 
    #endif
#else
    let v4061 : string = v3928.ToString v3944 
    let _run_target_args'_v3998 = v4061 
    #endif
    let v4113 : string = _run_target_args'_v3998 
    let v4168 : string = $"{v3943}{v4113}"
    let v4170 : (System.Guid -> string) = _.ToString()
    let v4171 : string = v4170 v0
    let v4174 : int32 = v3693.Length
    let v4175 : int32 = v4168.Length
    let v4176 : int32 = v4174 + v4175
    let v4178 : (string -> int32) = String.length
    let v4179 : int32 = v4178 v4171
    let v4187 : int32 = v4176 |> int32 
    let v4200 : int32 = v4179 |> int32 
    let v4208 : int32 = v4200 - 1
    let v4210 : string = v4171.[int v4187..int v4208]
    let v4214 : string = $"{v3693}{v4168}{v4210}"
    (* run_target_args'
    let v4219 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4221 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4221 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4225 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4225 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4229 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4219 = v4229 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4233 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4233 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4237 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4237 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4241 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4241 
    #endif
#else
    let v4245 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4245 
    #endif
    let v4248 : System.Guid = _run_target_args'_v4219 
    let _run_target_args'_v569 = v4248 
    #endif
    let v4254 : System.Guid = _run_target_args'_v569 
    v4254
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
