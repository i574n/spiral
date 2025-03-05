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
    let v698 : US0 = US0_1
    let v699 : US0 = v684 |> Option.defaultValue v698 
    let v719 : US1 =
        match v699 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v703) -> (* Some *)
            let v704 : string = "$0.naive_utc()"
            let v705 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v703 v704 
            let v706 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v707 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v705 v706 
            let v708 : string = "%Y%m%d-%H%M-%S%f"
            let v709 : string = "r#\"" + v708 + "\"#"
            let v710 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v709 
            let v711 : string = "$0.format($1).to_string()"
            let v712 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v707, v710) v711 
            let v713 : string = "fable_library_rust::String_::fromString($0)"
            let v714 : string = Fable.Core.RustInterop.emitRustExpr v712 v713 
            let v715 : string = $"{v714.[0..17]}-{v714.[18..21]}-{v714.[22]}"
            US1_0(v715)
    let v723 : string =
        match v719 with
        | US1_1 -> (* None *)
            let v721 : string = ""
            v721
        | US1_0(v720) -> (* Some *)
            v720
    (* run_target_args'
    let v728 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v729 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v730 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v729 
    let _run_target_args'_v728 = v730 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v732 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v728 = v732 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v736 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v728 = v736 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v740 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v728 = v740 
    #endif
#if FABLE_COMPILER_PYTHON
    let v744 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v728 = v744 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v747 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v728 = v747 
    #endif
#else
    let v748 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v728 = v748 
    #endif
    let v749 : System.TimeZoneInfo = _run_target_args'_v728 
    (* run_target_args'
    let v762 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v766 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v767 : (System.DateTime -> int64) = _.Ticks
    let v768 : int64 = v767 v586
    let _run_target_args'_v766 = v768 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v769 : (System.DateTime -> int64) = _.Ticks
    let v770 : int64 = v769 v586
    let _run_target_args'_v766 = v770 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v772 : int64 = null |> unbox<int64>
    let _run_target_args'_v766 = v772 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v775 : (System.DateTime -> int64) = _.Ticks
    let v776 : int64 = v775 v586
    let _run_target_args'_v766 = v776 
    #endif
#if FABLE_COMPILER_PYTHON
    let v777 : (System.DateTime -> int64) = _.Ticks
    let v778 : int64 = v777 v586
    let _run_target_args'_v766 = v778 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v779 : (System.DateTime -> int64) = _.Ticks
    let v780 : int64 = v779 v586
    let _run_target_args'_v766 = v780 
    #endif
#else
    let v781 : (System.DateTime -> int64) = _.Ticks
    let v782 : int64 = v781 v586
    let _run_target_args'_v766 = v782 
    #endif
    let v783 : int64 = _run_target_args'_v766 
    let v803 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v804 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v783) v803 
    let v806 : System.TimeSpan = v804 |> System.TimeSpan 
    let _run_target_args'_v762 = v806 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v812 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v813 : (System.DateTime -> int64) = _.Ticks
    let v814 : int64 = v813 v586
    let _run_target_args'_v812 = v814 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v815 : (System.DateTime -> int64) = _.Ticks
    let v816 : int64 = v815 v586
    let _run_target_args'_v812 = v816 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v818 : int64 = null |> unbox<int64>
    let _run_target_args'_v812 = v818 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v821 : (System.DateTime -> int64) = _.Ticks
    let v822 : int64 = v821 v586
    let _run_target_args'_v812 = v822 
    #endif
#if FABLE_COMPILER_PYTHON
    let v823 : (System.DateTime -> int64) = _.Ticks
    let v824 : int64 = v823 v586
    let _run_target_args'_v812 = v824 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v825 : (System.DateTime -> int64) = _.Ticks
    let v826 : int64 = v825 v586
    let _run_target_args'_v812 = v826 
    #endif
#else
    let v827 : (System.DateTime -> int64) = _.Ticks
    let v828 : int64 = v827 v586
    let _run_target_args'_v812 = v828 
    #endif
    let v829 : int64 = _run_target_args'_v812 
    let v849 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v850 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v829) v849 
    let v852 : System.TimeSpan = v850 |> System.TimeSpan 
    let _run_target_args'_v762 = v852 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v856 : US2 = US2_2
    let v857 : US3 = US3_3(v856)
    let v858 : string = $"date_time.get_utc_offset / target: {v857}"
    let v859 : System.TimeSpan = failwith<System.TimeSpan> v858
    let _run_target_args'_v762 = v859 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v863 : US2 = US2_0
    let v864 : US3 = US3_4(v863)
    let v865 : string = $"date_time.get_utc_offset / target: {v864}"
    let v866 : System.TimeSpan = failwith<System.TimeSpan> v865
    let _run_target_args'_v762 = v866 
    #endif
#if FABLE_COMPILER_PYTHON
    let v870 : US2 = US2_0
    let v871 : US3 = US3_5(v870)
    let v872 : string = $"date_time.get_utc_offset / target: {v871}"
    let v873 : System.TimeSpan = failwith<System.TimeSpan> v872
    let _run_target_args'_v762 = v873 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v876 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v881 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v882 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v883 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v882 
    let _run_target_args'_v881 = v883 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v885 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v881 = v885 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v889 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v881 = v889 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v893 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v881 = v893 
    #endif
#if FABLE_COMPILER_PYTHON
    let v897 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v881 = v897 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v900 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v881 = v900 
    #endif
#else
    let v901 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v881 = v901 
    #endif
    let v902 : System.TimeZoneInfo = _run_target_args'_v881 
    let v908 : (System.DateTime -> System.TimeSpan) = v876 v902
    let v909 : System.TimeSpan = v908 v586
    let _run_target_args'_v762 = v909 
    #endif
#else
    let v910 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v915 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v916 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v917 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v916 
    let _run_target_args'_v915 = v917 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v919 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v915 = v919 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v923 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v915 = v923 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v927 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v915 = v927 
    #endif
#if FABLE_COMPILER_PYTHON
    let v931 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v915 = v931 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v934 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v915 = v934 
    #endif
#else
    let v935 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v915 = v935 
    #endif
    let v936 : System.TimeZoneInfo = _run_target_args'_v915 
    let v942 : (System.DateTime -> System.TimeSpan) = v910 v936
    let v943 : System.TimeSpan = v942 v586
    let _run_target_args'_v762 = v943 
    #endif
    let v944 : System.TimeSpan = _run_target_args'_v762 
    let v954 : (System.TimeSpan -> int32) = _.Hours
    let v955 : int32 = v954 v944
    let v958 : bool = v955 > 0
    let v959 : uint8 =
        if v958 then
            1uy
        else
            0uy
    let v960 : string = method2()
    (* run_target_args'
    let v1014 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1015 : string = "$0.toString($1)"
    let v1016 : string = Fable.Core.RustInterop.emitRustExpr struct (v944, v960) v1015 
    let _run_target_args'_v1014 = v1016 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1017 : string = "$0.toString($1)"
    let v1018 : string = Fable.Core.RustInterop.emitRustExpr struct (v944, v960) v1017 
    let _run_target_args'_v1014 = v1018 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1019 : string = "$0.toString($1)"
    let v1020 : string = Fable.Core.RustInterop.emitRustExpr struct (v944, v960) v1019 
    let _run_target_args'_v1014 = v1020 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1021 : string = v944.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1014 = v1021 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1022 : string = v944.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1014 = v1022 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1024 : string = v944.ToString v960 
    let _run_target_args'_v1014 = v1024 
    #endif
#else
    let v1077 : string = v944.ToString v960 
    let _run_target_args'_v1014 = v1077 
    #endif
    let v1129 : string = _run_target_args'_v1014 
    let v1184 : string = $"{v959}{v1129.[0..1]}{v1129.[3..4]}"
    let v1186 : (System.Guid -> string) = _.ToString()
    let v1187 : string = v1186 v0
    let v1190 : int32 = v723.Length
    let v1191 : int32 = v1184.Length
    let v1192 : int32 = v1190 + v1191
    let v1194 : (string -> int32) = String.length
    let v1195 : int32 = v1194 v1187
    let v1203 : int32 = v1192 |> int32 
    let v1216 : int32 = v1195 |> int32 
    let v1224 : int32 = v1216 - 1
    let v1226 : string = v1187.[int v1203..int v1224]
    let v1230 : string = $"{v723}{v1184}{v1226}"
    (* run_target_args'
    let v1235 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1237 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1237 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1241 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1241 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1245 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1235 = v1245 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1249 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1249 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1253 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1253 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1257 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1257 
    #endif
#else
    let v1261 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1261 
    #endif
    let v1264 : System.Guid = _run_target_args'_v1235 
    let _run_target_args'_v569 = v1264 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1271 : System.DateTime = System.DateTime.UnixEpoch
    let v1275 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1276 : System.DateTime = v1275 v1271
    let v1280 : System.DateTimeKind = System.DateTimeKind.Local
    let v1281 : System.DateTime = System.DateTime.SpecifyKind (v1, v1280)
    let v1285 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1286 : System.DateTime = v1285 v1281
    (* run_target_args'
    let v1292 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1293 : (System.DateTime -> int64) = _.Ticks
    let v1294 : int64 = v1293 v1286
    let _run_target_args'_v1292 = v1294 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1295 : (System.DateTime -> int64) = _.Ticks
    let v1296 : int64 = v1295 v1286
    let _run_target_args'_v1292 = v1296 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1298 : int64 = null |> unbox<int64>
    let _run_target_args'_v1292 = v1298 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1301 : (System.DateTime -> int64) = _.Ticks
    let v1302 : int64 = v1301 v1286
    let _run_target_args'_v1292 = v1302 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1303 : (System.DateTime -> int64) = _.Ticks
    let v1304 : int64 = v1303 v1286
    let _run_target_args'_v1292 = v1304 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1305 : (System.DateTime -> int64) = _.Ticks
    let v1306 : int64 = v1305 v1286
    let _run_target_args'_v1292 = v1306 
    #endif
#else
    let v1307 : (System.DateTime -> int64) = _.Ticks
    let v1308 : int64 = v1307 v1286
    let _run_target_args'_v1292 = v1308 
    #endif
    let v1309 : int64 = _run_target_args'_v1292 
    (* run_target_args'
    let v1332 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1333 : (System.DateTime -> int64) = _.Ticks
    let v1334 : int64 = v1333 v1276
    let _run_target_args'_v1332 = v1334 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1335 : (System.DateTime -> int64) = _.Ticks
    let v1336 : int64 = v1335 v1276
    let _run_target_args'_v1332 = v1336 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1338 : int64 = null |> unbox<int64>
    let _run_target_args'_v1332 = v1338 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1341 : (System.DateTime -> int64) = _.Ticks
    let v1342 : int64 = v1341 v1276
    let _run_target_args'_v1332 = v1342 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1343 : (System.DateTime -> int64) = _.Ticks
    let v1344 : int64 = v1343 v1276
    let _run_target_args'_v1332 = v1344 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1345 : (System.DateTime -> int64) = _.Ticks
    let v1346 : int64 = v1345 v1276
    let _run_target_args'_v1332 = v1346 
    #endif
#else
    let v1347 : (System.DateTime -> int64) = _.Ticks
    let v1348 : int64 = v1347 v1276
    let _run_target_args'_v1332 = v1348 
    #endif
    let v1349 : int64 = _run_target_args'_v1332 
    let v1370 : int64 = v1309 |> int64 
    let v1374 : int64 = v1349 |> int64 
    let v1377 : int64 = v1370 - v1374
    let v1378 : int64 = v1377 / 10L
    let v1379 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1380 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1378 v1379 
    let v1383 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v1384 : US0 option = v1380 |> Option.map v1383 
    let v1398 : US0 = US0_1
    let v1399 : US0 = v1384 |> Option.defaultValue v1398 
    let v1419 : US1 =
        match v1399 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v1403) -> (* Some *)
            let v1404 : string = "$0.naive_utc()"
            let v1405 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1403 v1404 
            let v1406 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1407 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1405 v1406 
            let v1408 : string = "%Y%m%d-%H%M-%S%f"
            let v1409 : string = "r#\"" + v1408 + "\"#"
            let v1410 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1409 
            let v1411 : string = "$0.format($1).to_string()"
            let v1412 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1407, v1410) v1411 
            let v1413 : string = "fable_library_rust::String_::fromString($0)"
            let v1414 : string = Fable.Core.RustInterop.emitRustExpr v1412 v1413 
            let v1415 : string = $"{v1414.[0..17]}-{v1414.[18..21]}-{v1414.[22]}"
            US1_0(v1415)
    let v1423 : string =
        match v1419 with
        | US1_1 -> (* None *)
            let v1421 : string = ""
            v1421
        | US1_0(v1420) -> (* Some *)
            v1420
    (* run_target_args'
    let v1428 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1429 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1430 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1429 
    let _run_target_args'_v1428 = v1430 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1432 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1428 = v1432 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1436 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1428 = v1436 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1440 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1428 = v1440 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1444 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1428 = v1444 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1447 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1428 = v1447 
    #endif
#else
    let v1448 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1428 = v1448 
    #endif
    let v1449 : System.TimeZoneInfo = _run_target_args'_v1428 
    (* run_target_args'
    let v1462 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1466 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1467 : (System.DateTime -> int64) = _.Ticks
    let v1468 : int64 = v1467 v1286
    let _run_target_args'_v1466 = v1468 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1469 : (System.DateTime -> int64) = _.Ticks
    let v1470 : int64 = v1469 v1286
    let _run_target_args'_v1466 = v1470 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1472 : int64 = null |> unbox<int64>
    let _run_target_args'_v1466 = v1472 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1475 : (System.DateTime -> int64) = _.Ticks
    let v1476 : int64 = v1475 v1286
    let _run_target_args'_v1466 = v1476 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1477 : (System.DateTime -> int64) = _.Ticks
    let v1478 : int64 = v1477 v1286
    let _run_target_args'_v1466 = v1478 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1479 : (System.DateTime -> int64) = _.Ticks
    let v1480 : int64 = v1479 v1286
    let _run_target_args'_v1466 = v1480 
    #endif
#else
    let v1481 : (System.DateTime -> int64) = _.Ticks
    let v1482 : int64 = v1481 v1286
    let _run_target_args'_v1466 = v1482 
    #endif
    let v1483 : int64 = _run_target_args'_v1466 
    let v1503 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1504 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1286, v1483) v1503 
    let v1506 : System.TimeSpan = v1504 |> System.TimeSpan 
    let _run_target_args'_v1462 = v1506 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1512 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1513 : (System.DateTime -> int64) = _.Ticks
    let v1514 : int64 = v1513 v1286
    let _run_target_args'_v1512 = v1514 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1515 : (System.DateTime -> int64) = _.Ticks
    let v1516 : int64 = v1515 v1286
    let _run_target_args'_v1512 = v1516 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1518 : int64 = null |> unbox<int64>
    let _run_target_args'_v1512 = v1518 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1521 : (System.DateTime -> int64) = _.Ticks
    let v1522 : int64 = v1521 v1286
    let _run_target_args'_v1512 = v1522 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1523 : (System.DateTime -> int64) = _.Ticks
    let v1524 : int64 = v1523 v1286
    let _run_target_args'_v1512 = v1524 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1525 : (System.DateTime -> int64) = _.Ticks
    let v1526 : int64 = v1525 v1286
    let _run_target_args'_v1512 = v1526 
    #endif
#else
    let v1527 : (System.DateTime -> int64) = _.Ticks
    let v1528 : int64 = v1527 v1286
    let _run_target_args'_v1512 = v1528 
    #endif
    let v1529 : int64 = _run_target_args'_v1512 
    let v1549 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1550 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1286, v1529) v1549 
    let v1552 : System.TimeSpan = v1550 |> System.TimeSpan 
    let _run_target_args'_v1462 = v1552 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1556 : US2 = US2_2
    let v1557 : US3 = US3_3(v1556)
    let v1558 : string = $"date_time.get_utc_offset / target: {v1557}"
    let v1559 : System.TimeSpan = failwith<System.TimeSpan> v1558
    let _run_target_args'_v1462 = v1559 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1563 : US2 = US2_0
    let v1564 : US3 = US3_4(v1563)
    let v1565 : string = $"date_time.get_utc_offset / target: {v1564}"
    let v1566 : System.TimeSpan = failwith<System.TimeSpan> v1565
    let _run_target_args'_v1462 = v1566 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1570 : US2 = US2_0
    let v1571 : US3 = US3_5(v1570)
    let v1572 : string = $"date_time.get_utc_offset / target: {v1571}"
    let v1573 : System.TimeSpan = failwith<System.TimeSpan> v1572
    let _run_target_args'_v1462 = v1573 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1576 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1581 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1582 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1583 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1582 
    let _run_target_args'_v1581 = v1583 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1585 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1581 = v1585 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1589 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1581 = v1589 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1593 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1581 = v1593 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1597 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1581 = v1597 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1600 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1581 = v1600 
    #endif
#else
    let v1601 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1581 = v1601 
    #endif
    let v1602 : System.TimeZoneInfo = _run_target_args'_v1581 
    let v1608 : (System.DateTime -> System.TimeSpan) = v1576 v1602
    let v1609 : System.TimeSpan = v1608 v1286
    let _run_target_args'_v1462 = v1609 
    #endif
#else
    let v1610 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1615 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1616 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1617 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1616 
    let _run_target_args'_v1615 = v1617 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1619 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1619 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1623 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1623 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1627 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1627 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1631 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1631 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1634 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1615 = v1634 
    #endif
#else
    let v1635 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1615 = v1635 
    #endif
    let v1636 : System.TimeZoneInfo = _run_target_args'_v1615 
    let v1642 : (System.DateTime -> System.TimeSpan) = v1610 v1636
    let v1643 : System.TimeSpan = v1642 v1286
    let _run_target_args'_v1462 = v1643 
    #endif
    let v1644 : System.TimeSpan = _run_target_args'_v1462 
    let v1654 : (System.TimeSpan -> int32) = _.Hours
    let v1655 : int32 = v1654 v1644
    let v1658 : bool = v1655 > 0
    let v1659 : uint8 =
        if v1658 then
            1uy
        else
            0uy
    let v1660 : string = method2()
    (* run_target_args'
    let v1714 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1715 : string = "$0.toString($1)"
    let v1716 : string = Fable.Core.RustInterop.emitRustExpr struct (v1644, v1660) v1715 
    let _run_target_args'_v1714 = v1716 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1717 : string = "$0.toString($1)"
    let v1718 : string = Fable.Core.RustInterop.emitRustExpr struct (v1644, v1660) v1717 
    let _run_target_args'_v1714 = v1718 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1719 : string = "$0.toString($1)"
    let v1720 : string = Fable.Core.RustInterop.emitRustExpr struct (v1644, v1660) v1719 
    let _run_target_args'_v1714 = v1720 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1721 : string = v1644.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1714 = v1721 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1722 : string = v1644.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1714 = v1722 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1724 : string = v1644.ToString v1660 
    let _run_target_args'_v1714 = v1724 
    #endif
#else
    let v1777 : string = v1644.ToString v1660 
    let _run_target_args'_v1714 = v1777 
    #endif
    let v1829 : string = _run_target_args'_v1714 
    let v1884 : string = $"{v1659}{v1829.[0..1]}{v1829.[3..4]}"
    let v1886 : (System.Guid -> string) = _.ToString()
    let v1887 : string = v1886 v0
    let v1890 : int32 = v1423.Length
    let v1891 : int32 = v1884.Length
    let v1892 : int32 = v1890 + v1891
    let v1894 : (string -> int32) = String.length
    let v1895 : int32 = v1894 v1887
    let v1903 : int32 = v1892 |> int32 
    let v1916 : int32 = v1895 |> int32 
    let v1924 : int32 = v1916 - 1
    let v1926 : string = v1887.[int v1903..int v1924]
    let v1930 : string = $"{v1423}{v1884}{v1926}"
    (* run_target_args'
    let v1935 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1937 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1937 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1941 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1941 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1945 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1935 = v1945 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1949 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1949 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1953 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1953 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1957 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1957 
    #endif
#else
    let v1961 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1961 
    #endif
    let v1964 : System.Guid = _run_target_args'_v1935 
    let _run_target_args'_v569 = v1964 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1971 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v569 = v1971 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1974 : string = method3()
    let v1976 : bool = v1974 = ""
    let v1978 : string =
        if v1976 then
            let v1977 : string = "M-d-y hh:mm:ss tt"
            v1977
        else
            v1974
    let v1979 : (string -> string) = v1.ToString
    let v1980 : string = v1979 v1978
    (* run_target_args'
    let v1999 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2000 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2001 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2000 
    let _run_target_args'_v1999 = v2001 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2003 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2003 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2007 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2007 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2011 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2011 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2015 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2015 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2018 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1999 = v2018 
    #endif
#else
    let v2019 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1999 = v2019 
    #endif
    let v2020 : System.TimeZoneInfo = _run_target_args'_v1999 
    (* run_target_args'
    let v2033 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2037 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2038 : (System.DateTime -> int64) = _.Ticks
    let v2039 : int64 = v2038 v1
    let _run_target_args'_v2037 = v2039 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2040 : (System.DateTime -> int64) = _.Ticks
    let v2041 : int64 = v2040 v1
    let _run_target_args'_v2037 = v2041 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2043 : int64 = null |> unbox<int64>
    let _run_target_args'_v2037 = v2043 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2046 : (System.DateTime -> int64) = _.Ticks
    let v2047 : int64 = v2046 v1
    let _run_target_args'_v2037 = v2047 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2048 : (System.DateTime -> int64) = _.Ticks
    let v2049 : int64 = v2048 v1
    let _run_target_args'_v2037 = v2049 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2050 : (System.DateTime -> int64) = _.Ticks
    let v2051 : int64 = v2050 v1
    let _run_target_args'_v2037 = v2051 
    #endif
#else
    let v2052 : (System.DateTime -> int64) = _.Ticks
    let v2053 : int64 = v2052 v1
    let _run_target_args'_v2037 = v2053 
    #endif
    let v2054 : int64 = _run_target_args'_v2037 
    let v2074 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2075 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2054) v2074 
    let v2077 : System.TimeSpan = v2075 |> System.TimeSpan 
    let _run_target_args'_v2033 = v2077 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2083 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2084 : (System.DateTime -> int64) = _.Ticks
    let v2085 : int64 = v2084 v1
    let _run_target_args'_v2083 = v2085 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2086 : (System.DateTime -> int64) = _.Ticks
    let v2087 : int64 = v2086 v1
    let _run_target_args'_v2083 = v2087 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2089 : int64 = null |> unbox<int64>
    let _run_target_args'_v2083 = v2089 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2092 : (System.DateTime -> int64) = _.Ticks
    let v2093 : int64 = v2092 v1
    let _run_target_args'_v2083 = v2093 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2094 : (System.DateTime -> int64) = _.Ticks
    let v2095 : int64 = v2094 v1
    let _run_target_args'_v2083 = v2095 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2096 : (System.DateTime -> int64) = _.Ticks
    let v2097 : int64 = v2096 v1
    let _run_target_args'_v2083 = v2097 
    #endif
#else
    let v2098 : (System.DateTime -> int64) = _.Ticks
    let v2099 : int64 = v2098 v1
    let _run_target_args'_v2083 = v2099 
    #endif
    let v2100 : int64 = _run_target_args'_v2083 
    let v2120 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2121 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2100) v2120 
    let v2123 : System.TimeSpan = v2121 |> System.TimeSpan 
    let _run_target_args'_v2033 = v2123 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2127 : US2 = US2_2
    let v2128 : US3 = US3_3(v2127)
    let v2129 : string = $"date_time.get_utc_offset / target: {v2128}"
    let v2130 : System.TimeSpan = failwith<System.TimeSpan> v2129
    let _run_target_args'_v2033 = v2130 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2134 : US2 = US2_0
    let v2135 : US3 = US3_4(v2134)
    let v2136 : string = $"date_time.get_utc_offset / target: {v2135}"
    let v2137 : System.TimeSpan = failwith<System.TimeSpan> v2136
    let _run_target_args'_v2033 = v2137 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2141 : US2 = US2_0
    let v2142 : US3 = US3_5(v2141)
    let v2143 : string = $"date_time.get_utc_offset / target: {v2142}"
    let v2144 : System.TimeSpan = failwith<System.TimeSpan> v2143
    let _run_target_args'_v2033 = v2144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2147 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2152 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2153 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2154 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2153 
    let _run_target_args'_v2152 = v2154 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2156 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2152 = v2156 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2160 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2152 = v2160 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2164 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2152 = v2164 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2168 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2152 = v2168 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2171 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2152 = v2171 
    #endif
#else
    let v2172 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2152 = v2172 
    #endif
    let v2173 : System.TimeZoneInfo = _run_target_args'_v2152 
    let v2179 : (System.DateTime -> System.TimeSpan) = v2147 v2173
    let v2180 : System.TimeSpan = v2179 v1
    let _run_target_args'_v2033 = v2180 
    #endif
#else
    let v2181 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2186 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2187 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2188 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2187 
    let _run_target_args'_v2186 = v2188 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2190 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2186 = v2190 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2194 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2186 = v2194 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2198 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2186 = v2198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2202 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2186 = v2202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2205 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2186 = v2205 
    #endif
#else
    let v2206 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2186 = v2206 
    #endif
    let v2207 : System.TimeZoneInfo = _run_target_args'_v2186 
    let v2213 : (System.DateTime -> System.TimeSpan) = v2181 v2207
    let v2214 : System.TimeSpan = v2213 v1
    let _run_target_args'_v2033 = v2214 
    #endif
    let v2215 : System.TimeSpan = _run_target_args'_v2033 
    let v2225 : (System.TimeSpan -> int32) = _.Hours
    let v2226 : int32 = v2225 v2215
    let v2229 : bool = v2226 > 0
    let v2230 : uint8 =
        if v2229 then
            1uy
        else
            0uy
    let v2231 : string = method4()
    (* run_target_args'
    let v2285 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2286 : string = "$0.toString($1)"
    let v2287 : string = Fable.Core.RustInterop.emitRustExpr struct (v2215, v2231) v2286 
    let _run_target_args'_v2285 = v2287 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2288 : string = "$0.toString($1)"
    let v2289 : string = Fable.Core.RustInterop.emitRustExpr struct (v2215, v2231) v2288 
    let _run_target_args'_v2285 = v2289 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2290 : string = "$0.toString($1)"
    let v2291 : string = Fable.Core.RustInterop.emitRustExpr struct (v2215, v2231) v2290 
    let _run_target_args'_v2285 = v2291 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2292 : string = v2215.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2285 = v2292 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2293 : string = v2215.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2285 = v2293 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2295 : string = v2215.ToString v2231 
    let _run_target_args'_v2285 = v2295 
    #endif
#else
    let v2348 : string = v2215.ToString v2231 
    let _run_target_args'_v2285 = v2348 
    #endif
    let v2400 : string = _run_target_args'_v2285 
    let v2455 : string = $"{v2230}{v2400}"
    let v2457 : (System.Guid -> string) = _.ToString()
    let v2458 : string = v2457 v0
    let v2461 : int32 = v1980.Length
    let v2462 : int32 = v2455.Length
    let v2463 : int32 = v2461 + v2462
    let v2465 : (string -> int32) = String.length
    let v2466 : int32 = v2465 v2458
    let v2474 : int32 = v2463 |> int32 
    let v2487 : int32 = v2466 |> int32 
    let v2495 : int32 = v2487 - 1
    let v2497 : string = v2458.[int v2474..int v2495]
    let v2501 : string = $"{v1980}{v2455}{v2497}"
    (* run_target_args'
    let v2506 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2508 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2508 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2512 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2512 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2516 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2506 = v2516 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2520 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2520 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2524 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2524 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2528 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2528 
    #endif
#else
    let v2532 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2532 
    #endif
    let v2535 : System.Guid = _run_target_args'_v2506 
    let _run_target_args'_v569 = v2535 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2541 : string = method3()
    let v2543 : bool = v2541 = ""
    let v2545 : string =
        if v2543 then
            let v2544 : string = "M-d-y hh:mm:ss tt"
            v2544
        else
            v2541
    let v2546 : (string -> string) = v1.ToString
    let v2547 : string = v2546 v2545
    (* run_target_args'
    let v2566 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2567 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2568 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2567 
    let _run_target_args'_v2566 = v2568 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2570 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2566 = v2570 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2574 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2566 = v2574 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2578 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2566 = v2578 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2582 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2566 = v2582 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2585 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2566 = v2585 
    #endif
#else
    let v2586 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2566 = v2586 
    #endif
    let v2587 : System.TimeZoneInfo = _run_target_args'_v2566 
    (* run_target_args'
    let v2600 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2604 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2605 : (System.DateTime -> int64) = _.Ticks
    let v2606 : int64 = v2605 v1
    let _run_target_args'_v2604 = v2606 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2607 : (System.DateTime -> int64) = _.Ticks
    let v2608 : int64 = v2607 v1
    let _run_target_args'_v2604 = v2608 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2610 : int64 = null |> unbox<int64>
    let _run_target_args'_v2604 = v2610 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2613 : (System.DateTime -> int64) = _.Ticks
    let v2614 : int64 = v2613 v1
    let _run_target_args'_v2604 = v2614 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2615 : (System.DateTime -> int64) = _.Ticks
    let v2616 : int64 = v2615 v1
    let _run_target_args'_v2604 = v2616 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2617 : (System.DateTime -> int64) = _.Ticks
    let v2618 : int64 = v2617 v1
    let _run_target_args'_v2604 = v2618 
    #endif
#else
    let v2619 : (System.DateTime -> int64) = _.Ticks
    let v2620 : int64 = v2619 v1
    let _run_target_args'_v2604 = v2620 
    #endif
    let v2621 : int64 = _run_target_args'_v2604 
    let v2641 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2642 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2621) v2641 
    let v2644 : System.TimeSpan = v2642 |> System.TimeSpan 
    let _run_target_args'_v2600 = v2644 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2650 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2651 : (System.DateTime -> int64) = _.Ticks
    let v2652 : int64 = v2651 v1
    let _run_target_args'_v2650 = v2652 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2653 : (System.DateTime -> int64) = _.Ticks
    let v2654 : int64 = v2653 v1
    let _run_target_args'_v2650 = v2654 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2656 : int64 = null |> unbox<int64>
    let _run_target_args'_v2650 = v2656 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2659 : (System.DateTime -> int64) = _.Ticks
    let v2660 : int64 = v2659 v1
    let _run_target_args'_v2650 = v2660 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2661 : (System.DateTime -> int64) = _.Ticks
    let v2662 : int64 = v2661 v1
    let _run_target_args'_v2650 = v2662 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2663 : (System.DateTime -> int64) = _.Ticks
    let v2664 : int64 = v2663 v1
    let _run_target_args'_v2650 = v2664 
    #endif
#else
    let v2665 : (System.DateTime -> int64) = _.Ticks
    let v2666 : int64 = v2665 v1
    let _run_target_args'_v2650 = v2666 
    #endif
    let v2667 : int64 = _run_target_args'_v2650 
    let v2687 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2688 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2667) v2687 
    let v2690 : System.TimeSpan = v2688 |> System.TimeSpan 
    let _run_target_args'_v2600 = v2690 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2694 : US2 = US2_2
    let v2695 : US3 = US3_3(v2694)
    let v2696 : string = $"date_time.get_utc_offset / target: {v2695}"
    let v2697 : System.TimeSpan = failwith<System.TimeSpan> v2696
    let _run_target_args'_v2600 = v2697 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2701 : US2 = US2_0
    let v2702 : US3 = US3_4(v2701)
    let v2703 : string = $"date_time.get_utc_offset / target: {v2702}"
    let v2704 : System.TimeSpan = failwith<System.TimeSpan> v2703
    let _run_target_args'_v2600 = v2704 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2708 : US2 = US2_0
    let v2709 : US3 = US3_5(v2708)
    let v2710 : string = $"date_time.get_utc_offset / target: {v2709}"
    let v2711 : System.TimeSpan = failwith<System.TimeSpan> v2710
    let _run_target_args'_v2600 = v2711 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2714 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2719 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2720 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2721 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2720 
    let _run_target_args'_v2719 = v2721 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2723 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2719 = v2723 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2727 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2719 = v2727 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2731 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2719 = v2731 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2735 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2719 = v2735 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2738 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2719 = v2738 
    #endif
#else
    let v2739 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2719 = v2739 
    #endif
    let v2740 : System.TimeZoneInfo = _run_target_args'_v2719 
    let v2746 : (System.DateTime -> System.TimeSpan) = v2714 v2740
    let v2747 : System.TimeSpan = v2746 v1
    let _run_target_args'_v2600 = v2747 
    #endif
#else
    let v2748 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2753 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2754 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2755 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2754 
    let _run_target_args'_v2753 = v2755 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2757 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2753 = v2757 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2761 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2753 = v2761 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2765 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2753 = v2765 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2769 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2753 = v2769 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2772 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2753 = v2772 
    #endif
#else
    let v2773 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2753 = v2773 
    #endif
    let v2774 : System.TimeZoneInfo = _run_target_args'_v2753 
    let v2780 : (System.DateTime -> System.TimeSpan) = v2748 v2774
    let v2781 : System.TimeSpan = v2780 v1
    let _run_target_args'_v2600 = v2781 
    #endif
    let v2782 : System.TimeSpan = _run_target_args'_v2600 
    let v2792 : (System.TimeSpan -> int32) = _.Hours
    let v2793 : int32 = v2792 v2782
    let v2796 : bool = v2793 > 0
    let v2797 : uint8 =
        if v2796 then
            1uy
        else
            0uy
    let v2798 : string = method4()
    (* run_target_args'
    let v2852 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2853 : string = "$0.toString($1)"
    let v2854 : string = Fable.Core.RustInterop.emitRustExpr struct (v2782, v2798) v2853 
    let _run_target_args'_v2852 = v2854 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2855 : string = "$0.toString($1)"
    let v2856 : string = Fable.Core.RustInterop.emitRustExpr struct (v2782, v2798) v2855 
    let _run_target_args'_v2852 = v2856 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2857 : string = "$0.toString($1)"
    let v2858 : string = Fable.Core.RustInterop.emitRustExpr struct (v2782, v2798) v2857 
    let _run_target_args'_v2852 = v2858 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2859 : string = v2782.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2852 = v2859 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2860 : string = v2782.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2852 = v2860 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2862 : string = v2782.ToString v2798 
    let _run_target_args'_v2852 = v2862 
    #endif
#else
    let v2915 : string = v2782.ToString v2798 
    let _run_target_args'_v2852 = v2915 
    #endif
    let v2967 : string = _run_target_args'_v2852 
    let v3022 : string = $"{v2797}{v2967}"
    let v3024 : (System.Guid -> string) = _.ToString()
    let v3025 : string = v3024 v0
    let v3028 : int32 = v2547.Length
    let v3029 : int32 = v3022.Length
    let v3030 : int32 = v3028 + v3029
    let v3032 : (string -> int32) = String.length
    let v3033 : int32 = v3032 v3025
    let v3041 : int32 = v3030 |> int32 
    let v3054 : int32 = v3033 |> int32 
    let v3062 : int32 = v3054 - 1
    let v3064 : string = v3025.[int v3041..int v3062]
    let v3068 : string = $"{v2547}{v3022}{v3064}"
    (* run_target_args'
    let v3073 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3075 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3075 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3079 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3079 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3083 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3073 = v3083 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3087 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3087 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3091 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3091 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3095 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3095 
    #endif
#else
    let v3099 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3099 
    #endif
    let v3102 : System.Guid = _run_target_args'_v3073 
    let _run_target_args'_v569 = v3102 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3108 : string = method3()
    let v3110 : bool = v3108 = ""
    let v3112 : string =
        if v3110 then
            let v3111 : string = "M-d-y hh:mm:ss tt"
            v3111
        else
            v3108
    let v3113 : (string -> string) = v1.ToString
    let v3114 : string = v3113 v3112
    (* run_target_args'
    let v3133 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3134 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3135 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3134 
    let _run_target_args'_v3133 = v3135 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3137 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3133 = v3137 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3141 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3133 = v3141 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3145 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3133 = v3145 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3149 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3133 = v3149 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3152 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3133 = v3152 
    #endif
#else
    let v3153 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3133 = v3153 
    #endif
    let v3154 : System.TimeZoneInfo = _run_target_args'_v3133 
    (* run_target_args'
    let v3167 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3171 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3172 : (System.DateTime -> int64) = _.Ticks
    let v3173 : int64 = v3172 v1
    let _run_target_args'_v3171 = v3173 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3174 : (System.DateTime -> int64) = _.Ticks
    let v3175 : int64 = v3174 v1
    let _run_target_args'_v3171 = v3175 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3177 : int64 = null |> unbox<int64>
    let _run_target_args'_v3171 = v3177 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3180 : (System.DateTime -> int64) = _.Ticks
    let v3181 : int64 = v3180 v1
    let _run_target_args'_v3171 = v3181 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3182 : (System.DateTime -> int64) = _.Ticks
    let v3183 : int64 = v3182 v1
    let _run_target_args'_v3171 = v3183 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3184 : (System.DateTime -> int64) = _.Ticks
    let v3185 : int64 = v3184 v1
    let _run_target_args'_v3171 = v3185 
    #endif
#else
    let v3186 : (System.DateTime -> int64) = _.Ticks
    let v3187 : int64 = v3186 v1
    let _run_target_args'_v3171 = v3187 
    #endif
    let v3188 : int64 = _run_target_args'_v3171 
    let v3208 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3209 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3188) v3208 
    let v3211 : System.TimeSpan = v3209 |> System.TimeSpan 
    let _run_target_args'_v3167 = v3211 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3217 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3218 : (System.DateTime -> int64) = _.Ticks
    let v3219 : int64 = v3218 v1
    let _run_target_args'_v3217 = v3219 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3220 : (System.DateTime -> int64) = _.Ticks
    let v3221 : int64 = v3220 v1
    let _run_target_args'_v3217 = v3221 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3223 : int64 = null |> unbox<int64>
    let _run_target_args'_v3217 = v3223 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3226 : (System.DateTime -> int64) = _.Ticks
    let v3227 : int64 = v3226 v1
    let _run_target_args'_v3217 = v3227 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3228 : (System.DateTime -> int64) = _.Ticks
    let v3229 : int64 = v3228 v1
    let _run_target_args'_v3217 = v3229 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3230 : (System.DateTime -> int64) = _.Ticks
    let v3231 : int64 = v3230 v1
    let _run_target_args'_v3217 = v3231 
    #endif
#else
    let v3232 : (System.DateTime -> int64) = _.Ticks
    let v3233 : int64 = v3232 v1
    let _run_target_args'_v3217 = v3233 
    #endif
    let v3234 : int64 = _run_target_args'_v3217 
    let v3254 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3255 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3234) v3254 
    let v3257 : System.TimeSpan = v3255 |> System.TimeSpan 
    let _run_target_args'_v3167 = v3257 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3261 : US2 = US2_2
    let v3262 : US3 = US3_3(v3261)
    let v3263 : string = $"date_time.get_utc_offset / target: {v3262}"
    let v3264 : System.TimeSpan = failwith<System.TimeSpan> v3263
    let _run_target_args'_v3167 = v3264 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3268 : US2 = US2_0
    let v3269 : US3 = US3_4(v3268)
    let v3270 : string = $"date_time.get_utc_offset / target: {v3269}"
    let v3271 : System.TimeSpan = failwith<System.TimeSpan> v3270
    let _run_target_args'_v3167 = v3271 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3275 : US2 = US2_0
    let v3276 : US3 = US3_5(v3275)
    let v3277 : string = $"date_time.get_utc_offset / target: {v3276}"
    let v3278 : System.TimeSpan = failwith<System.TimeSpan> v3277
    let _run_target_args'_v3167 = v3278 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3281 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3286 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3287 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3288 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3287 
    let _run_target_args'_v3286 = v3288 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3290 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3286 = v3290 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3294 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3286 = v3294 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3298 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3286 = v3298 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3302 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3286 = v3302 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3305 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3286 = v3305 
    #endif
#else
    let v3306 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3286 = v3306 
    #endif
    let v3307 : System.TimeZoneInfo = _run_target_args'_v3286 
    let v3313 : (System.DateTime -> System.TimeSpan) = v3281 v3307
    let v3314 : System.TimeSpan = v3313 v1
    let _run_target_args'_v3167 = v3314 
    #endif
#else
    let v3315 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3320 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3321 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3322 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3321 
    let _run_target_args'_v3320 = v3322 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3324 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3320 = v3324 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3328 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3320 = v3328 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3332 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3320 = v3332 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3336 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3320 = v3336 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3339 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3320 = v3339 
    #endif
#else
    let v3340 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3320 = v3340 
    #endif
    let v3341 : System.TimeZoneInfo = _run_target_args'_v3320 
    let v3347 : (System.DateTime -> System.TimeSpan) = v3315 v3341
    let v3348 : System.TimeSpan = v3347 v1
    let _run_target_args'_v3167 = v3348 
    #endif
    let v3349 : System.TimeSpan = _run_target_args'_v3167 
    let v3359 : (System.TimeSpan -> int32) = _.Hours
    let v3360 : int32 = v3359 v3349
    let v3363 : bool = v3360 > 0
    let v3364 : uint8 =
        if v3363 then
            1uy
        else
            0uy
    let v3365 : string = method4()
    (* run_target_args'
    let v3419 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3420 : string = "$0.toString($1)"
    let v3421 : string = Fable.Core.RustInterop.emitRustExpr struct (v3349, v3365) v3420 
    let _run_target_args'_v3419 = v3421 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3422 : string = "$0.toString($1)"
    let v3423 : string = Fable.Core.RustInterop.emitRustExpr struct (v3349, v3365) v3422 
    let _run_target_args'_v3419 = v3423 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3424 : string = "$0.toString($1)"
    let v3425 : string = Fable.Core.RustInterop.emitRustExpr struct (v3349, v3365) v3424 
    let _run_target_args'_v3419 = v3425 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3426 : string = v3349.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3419 = v3426 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3427 : string = v3349.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3419 = v3427 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3429 : string = v3349.ToString v3365 
    let _run_target_args'_v3419 = v3429 
    #endif
#else
    let v3482 : string = v3349.ToString v3365 
    let _run_target_args'_v3419 = v3482 
    #endif
    let v3534 : string = _run_target_args'_v3419 
    let v3589 : string = $"{v3364}{v3534}"
    let v3591 : (System.Guid -> string) = _.ToString()
    let v3592 : string = v3591 v0
    let v3595 : int32 = v3114.Length
    let v3596 : int32 = v3589.Length
    let v3597 : int32 = v3595 + v3596
    let v3599 : (string -> int32) = String.length
    let v3600 : int32 = v3599 v3592
    let v3608 : int32 = v3597 |> int32 
    let v3621 : int32 = v3600 |> int32 
    let v3629 : int32 = v3621 - 1
    let v3631 : string = v3592.[int v3608..int v3629]
    let v3635 : string = $"{v3114}{v3589}{v3631}"
    (* run_target_args'
    let v3640 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3642 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3642 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3646 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3646 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3650 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3640 = v3650 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3654 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3654 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3658 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3658 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3662 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3662 
    #endif
#else
    let v3666 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3666 
    #endif
    let v3669 : System.Guid = _run_target_args'_v3640 
    let _run_target_args'_v569 = v3669 
    #endif
#else
    let v3675 : string = method3()
    let v3677 : bool = v3675 = ""
    let v3679 : string =
        if v3677 then
            let v3678 : string = "M-d-y hh:mm:ss tt"
            v3678
        else
            v3675
    let v3680 : (string -> string) = v1.ToString
    let v3681 : string = v3680 v3679
    (* run_target_args'
    let v3700 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3701 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3702 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3701 
    let _run_target_args'_v3700 = v3702 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3704 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3700 = v3704 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3708 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3700 = v3708 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3712 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3700 = v3712 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3716 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3700 = v3716 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3719 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3700 = v3719 
    #endif
#else
    let v3720 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3700 = v3720 
    #endif
    let v3721 : System.TimeZoneInfo = _run_target_args'_v3700 
    (* run_target_args'
    let v3734 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3738 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3739 : (System.DateTime -> int64) = _.Ticks
    let v3740 : int64 = v3739 v1
    let _run_target_args'_v3738 = v3740 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3741 : (System.DateTime -> int64) = _.Ticks
    let v3742 : int64 = v3741 v1
    let _run_target_args'_v3738 = v3742 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3744 : int64 = null |> unbox<int64>
    let _run_target_args'_v3738 = v3744 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3747 : (System.DateTime -> int64) = _.Ticks
    let v3748 : int64 = v3747 v1
    let _run_target_args'_v3738 = v3748 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3749 : (System.DateTime -> int64) = _.Ticks
    let v3750 : int64 = v3749 v1
    let _run_target_args'_v3738 = v3750 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3751 : (System.DateTime -> int64) = _.Ticks
    let v3752 : int64 = v3751 v1
    let _run_target_args'_v3738 = v3752 
    #endif
#else
    let v3753 : (System.DateTime -> int64) = _.Ticks
    let v3754 : int64 = v3753 v1
    let _run_target_args'_v3738 = v3754 
    #endif
    let v3755 : int64 = _run_target_args'_v3738 
    let v3775 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3776 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3755) v3775 
    let v3778 : System.TimeSpan = v3776 |> System.TimeSpan 
    let _run_target_args'_v3734 = v3778 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3784 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3785 : (System.DateTime -> int64) = _.Ticks
    let v3786 : int64 = v3785 v1
    let _run_target_args'_v3784 = v3786 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3787 : (System.DateTime -> int64) = _.Ticks
    let v3788 : int64 = v3787 v1
    let _run_target_args'_v3784 = v3788 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3790 : int64 = null |> unbox<int64>
    let _run_target_args'_v3784 = v3790 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3793 : (System.DateTime -> int64) = _.Ticks
    let v3794 : int64 = v3793 v1
    let _run_target_args'_v3784 = v3794 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3795 : (System.DateTime -> int64) = _.Ticks
    let v3796 : int64 = v3795 v1
    let _run_target_args'_v3784 = v3796 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3797 : (System.DateTime -> int64) = _.Ticks
    let v3798 : int64 = v3797 v1
    let _run_target_args'_v3784 = v3798 
    #endif
#else
    let v3799 : (System.DateTime -> int64) = _.Ticks
    let v3800 : int64 = v3799 v1
    let _run_target_args'_v3784 = v3800 
    #endif
    let v3801 : int64 = _run_target_args'_v3784 
    let v3821 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3822 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3801) v3821 
    let v3824 : System.TimeSpan = v3822 |> System.TimeSpan 
    let _run_target_args'_v3734 = v3824 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3828 : US2 = US2_2
    let v3829 : US3 = US3_3(v3828)
    let v3830 : string = $"date_time.get_utc_offset / target: {v3829}"
    let v3831 : System.TimeSpan = failwith<System.TimeSpan> v3830
    let _run_target_args'_v3734 = v3831 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3835 : US2 = US2_0
    let v3836 : US3 = US3_4(v3835)
    let v3837 : string = $"date_time.get_utc_offset / target: {v3836}"
    let v3838 : System.TimeSpan = failwith<System.TimeSpan> v3837
    let _run_target_args'_v3734 = v3838 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3842 : US2 = US2_0
    let v3843 : US3 = US3_5(v3842)
    let v3844 : string = $"date_time.get_utc_offset / target: {v3843}"
    let v3845 : System.TimeSpan = failwith<System.TimeSpan> v3844
    let _run_target_args'_v3734 = v3845 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3848 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3853 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3854 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3855 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3854 
    let _run_target_args'_v3853 = v3855 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3857 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3853 = v3857 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3861 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3853 = v3861 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3865 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3853 = v3865 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3869 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3853 = v3869 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3872 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3853 = v3872 
    #endif
#else
    let v3873 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3853 = v3873 
    #endif
    let v3874 : System.TimeZoneInfo = _run_target_args'_v3853 
    let v3880 : (System.DateTime -> System.TimeSpan) = v3848 v3874
    let v3881 : System.TimeSpan = v3880 v1
    let _run_target_args'_v3734 = v3881 
    #endif
#else
    let v3882 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3887 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3888 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3889 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3888 
    let _run_target_args'_v3887 = v3889 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3891 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3887 = v3891 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3895 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3887 = v3895 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3899 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3887 = v3899 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3903 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3887 = v3903 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3906 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3887 = v3906 
    #endif
#else
    let v3907 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3887 = v3907 
    #endif
    let v3908 : System.TimeZoneInfo = _run_target_args'_v3887 
    let v3914 : (System.DateTime -> System.TimeSpan) = v3882 v3908
    let v3915 : System.TimeSpan = v3914 v1
    let _run_target_args'_v3734 = v3915 
    #endif
    let v3916 : System.TimeSpan = _run_target_args'_v3734 
    let v3926 : (System.TimeSpan -> int32) = _.Hours
    let v3927 : int32 = v3926 v3916
    let v3930 : bool = v3927 > 0
    let v3931 : uint8 =
        if v3930 then
            1uy
        else
            0uy
    let v3932 : string = method4()
    (* run_target_args'
    let v3986 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3987 : string = "$0.toString($1)"
    let v3988 : string = Fable.Core.RustInterop.emitRustExpr struct (v3916, v3932) v3987 
    let _run_target_args'_v3986 = v3988 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3989 : string = "$0.toString($1)"
    let v3990 : string = Fable.Core.RustInterop.emitRustExpr struct (v3916, v3932) v3989 
    let _run_target_args'_v3986 = v3990 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3991 : string = "$0.toString($1)"
    let v3992 : string = Fable.Core.RustInterop.emitRustExpr struct (v3916, v3932) v3991 
    let _run_target_args'_v3986 = v3992 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3993 : string = v3916.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3986 = v3993 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3994 : string = v3916.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3986 = v3994 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3996 : string = v3916.ToString v3932 
    let _run_target_args'_v3986 = v3996 
    #endif
#else
    let v4049 : string = v3916.ToString v3932 
    let _run_target_args'_v3986 = v4049 
    #endif
    let v4101 : string = _run_target_args'_v3986 
    let v4156 : string = $"{v3931}{v4101}"
    let v4158 : (System.Guid -> string) = _.ToString()
    let v4159 : string = v4158 v0
    let v4162 : int32 = v3681.Length
    let v4163 : int32 = v4156.Length
    let v4164 : int32 = v4162 + v4163
    let v4166 : (string -> int32) = String.length
    let v4167 : int32 = v4166 v4159
    let v4175 : int32 = v4164 |> int32 
    let v4188 : int32 = v4167 |> int32 
    let v4196 : int32 = v4188 - 1
    let v4198 : string = v4159.[int v4175..int v4196]
    let v4202 : string = $"{v3681}{v4156}{v4198}"
    (* run_target_args'
    let v4207 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4209 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4209 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4213 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4213 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4217 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4207 = v4217 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4221 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4221 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4225 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4225 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4229 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4229 
    #endif
#else
    let v4233 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4233 
    #endif
    let v4236 : System.Guid = _run_target_args'_v4207 
    let _run_target_args'_v569 = v4236 
    #endif
    let v4242 : System.Guid = _run_target_args'_v569 
    v4242
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
