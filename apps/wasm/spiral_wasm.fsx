#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("&$0")>]
type Ref<'T> = class end
#else
type Ref<'T> = 'T
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("clap::Command")>]
#endif
type clap_Command = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("clap::builder::ValueRange")>]
#endif
type clap_builder_ValueRange = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("clap::Arg")>]
#endif
type clap_Arg = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("Vec<$0>")>]
#endif
type Vec<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::string::String")>]
type std_string_String = class end
#else
type std_string_String = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("Box<$0>")>]
#endif
type Box<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("clap::builder::PossibleValue")>]
#endif
type clap_builder_PossibleValue = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("clap::builder::ValueParser")>]
#endif
type clap_builder_ValueParser = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("clap::ArgMatches")>]
#endif
type clap_ArgMatches = class end
module TraceState = let mutable trace_state = None
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("mut $0")>]
#endif
type Mut<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::Worker<$0>")>]
#endif
type near_workspaces_Worker<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::pin::Pin<$0>")>]
#endif
type std_pin_Pin<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::Contract")>]
#endif
type near_workspaces_Contract = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::operations::CallTransaction")>]
#endif
type near_workspaces_operations_CallTransaction = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::types::Gas")>]
#endif
type near_workspaces_types_Gas = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::result::ExecutionFinalResult")>]
#endif
type near_workspaces_result_ExecutionFinalResult = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::result::ExecutionOutcome")>]
#endif
type near_workspaces_result_ExecutionOutcome = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::types::NearToken")>]
#endif
type near_workspaces_types_NearToken = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("u128")>]
#endif
type u128 = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("anyhow::Error")>]
#endif
type anyhow_Error = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("$0 $1")>]
#endif
type Lifetime<'T, 'U> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("'static")>]
#endif
type StaticLifetime = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("str")>]
type Str = class end
#else
type Str = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::env::VarError")>]
#endif
type std_env_VarError = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("dyn $0")>]
#endif
type Dyn<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::future::Future<Output = $0>")>]
#endif
type std_future_Future<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::io::Error")>]
type std_io_Error = class end
#else
type std_io_Error = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::network::Sandbox")>]
#endif
type near_workspaces_network_Sandbox = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::error::Error")>]
#endif
type near_workspaces_error_Error = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::result::ExecutionSuccess")>]
#endif
type near_workspaces_result_ExecutionSuccess = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("near_workspaces::result::ExecutionFailure")>]
#endif
type near_workspaces_result_ExecutionFailure = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("[$0]")>]
#endif
type Slice<'T> = class end
type [<Struct>] US0 =
    | US0_0 of f0_0 : unativeint
    | US0_1 of f1_0 : exn
and [<Struct>] US1 =
    | US1_0 of f0_0 : unativeint
    | US1_1
and [<Struct>] US2 =
    | US2_0 of f0_0 : std_string_String
    | US2_1
and [<Struct>] US5 =
    | US5_0
    | US5_1
    | US5_2
    | US5_3
    | US5_4
and [<Struct>] US4 =
    | US4_0 of f0_0 : US5
    | US4_1
and [<Struct>] US3 =
    | US3_0 of f0_0 : US4
    | US3_1
and Mut0 = {mutable l0 : int32; mutable l1 : US4}
and Mut1 = {mutable l0 : int64}
and Mut2 = {mutable l0 : (string -> unit)}
and Mut3 = {mutable l0 : bool}
and Mut4 = {mutable l0 : string}
and Mut5 = {mutable l0 : US5}
and [<Struct>] US6 =
    | US6_0 of f0_0 : int64
    | US6_1
and [<Struct>] US7 =
    | US7_0
    | US7_1
and [<Struct>] US8 =
    | US8_0 of f0_0 : US7
    | US8_1
and [<Struct>] US9 =
    | US9_0
    | US9_1
    | US9_2
    | US9_3
    | US9_4
    | US9_5 of f5_0 : US8
    | US9_6
    | US9_7
and [<Struct>] US10 =
    | US10_0 of f0_0 : string
    | US10_1
and [<Struct>] US11 =
    | US11_0 of f0_0 : int64
    | US11_1 of f1_0 : exn
and [<Struct>] US12 =
    | US12_0 of f0_0 : int64
    | US12_1
and [<Struct>] US13 =
    | US13_0 of f0_0 : int64
    | US13_1 of f1_0 : exn
and [<Struct>] US14 =
    | US14_0 of f0_0 : Mut1 * f0_1 : Mut2 * f0_2 : Mut3 * f0_3 : Mut4 * f0_4 : Mut5 * f0_5 : int64 option
    | US14_1
and Mut6 = {mutable l0 : int32}
and [<Struct>] US15 =
    | US15_0 of f0_0 : uint8 * f0_1 : US10
    | US15_1 of f1_0 : uint8 * f1_1 : US10
and [<Struct>] US16 =
    | US16_0 of f0_0 : int32
    | US16_1 of f1_0 : exn
and [<Struct>] US17 =
    | US17_0 of f0_0 : int32
    | US17_1
and [<Struct>] US18 =
    | US18_0 of f0_0 : US10
    | US18_1 of f1_0 : std_string_String
and [<Struct>] US19 =
    | US19_0 of f0_0 : uint8
    | US19_1 of f1_0 : std_string_String
let rec closure1 () () : unativeint =
    let v0 : unativeint = 0 |> unativeint 
    v0
and closure2 () (v0 : unativeint) : US0 =
    US0_0(v0)
and closure3 () (v0 : (unit -> exn)) : exn =
    v0 ()
and closure4 () (v0 : exn) : US0 =
    US0_1(v0)
and method1 () : US0 =
    let v0 : (unit -> unativeint) = closure1()
    let v1 : (unativeint -> US0) = closure2()
    let v2 : ((unit -> exn) -> exn) = closure3()
    let v3 : (exn -> US0) = closure4()
    let v4 : US0 = try v0 () |> v1 with ex -> (fun () -> ex) |> v2 |> v3 
    v4
and closure5 () () : unativeint =
    let v0 : unativeint = 1 |> unativeint 
    v0
and method2 () : US0 =
    let v0 : (unit -> unativeint) = closure5()
    let v1 : (unativeint -> US0) = closure2()
    let v2 : ((unit -> exn) -> exn) = closure3()
    let v3 : (exn -> US0) = closure4()
    let v4 : US0 = try v0 () |> v1 with ex -> (fun () -> ex) |> v2 |> v3 
    v4
and method0 () : clap_Command =
    let v20 : string = "command"
    let v21 : string = "r#\"" + v20 + "\"#"
    let v22 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v21 
    let v56 : string = "clap::Command::new($0)"
    let v57 : clap_Command = Fable.Core.RustInterop.emitRustExpr v22 v56 
    let v58 : string = "clap::Command::args_override_self($0, true)"
    let v59 : clap_Command = Fable.Core.RustInterop.emitRustExpr v57 v58 
    let v76 : US0 = method1()
    let v122 : US1 =
        match v76 with
        | US0_1(v119) -> (* Error *)
            US1_1
        | US0_0(v117) -> (* Ok *)
            US1_0(v117)
    let v179 : unativeint =
        match v122 with
        | US1_1 -> (* None *)
            failwith<unativeint> "Option does not have a value."
        | US1_0(v176) -> (* Some *)
            v176
    let v189 : US0 = method2()
    let v206 : US1 =
        match v189 with
        | US0_1(v203) -> (* Error *)
            US1_1
        | US0_0(v201) -> (* Ok *)
            US1_0(v201)
    let v241 : unativeint =
        match v206 with
        | US1_1 -> (* None *)
            failwith<unativeint> "Option does not have a value."
        | US1_0(v238) -> (* Some *)
            v238
    let v242 : US0 = method1()
    let v248 : US1 =
        match v242 with
        | US0_1(v245) -> (* Error *)
            US1_1
        | US0_0(v243) -> (* Ok *)
            US1_0(v243)
    let v252 : unativeint =
        match v248 with
        | US1_1 -> (* None *)
            failwith<unativeint> "Option does not have a value."
        | US1_0(v249) -> (* Some *)
            v249
    let v255 : bool = v241 = v252 
    let v280 : clap_builder_ValueRange =
        if v255 then
            let v275 : string = "clap::builder::ValueRange::new($0..)"
            let v276 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr v179 v275 
            v276
        else
            let v277 : string = "="
            let v278 : string = "clap::builder::ValueRange::new($0.." + v277 + "$1)"
            let v279 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr struct (v179, v241) v278 
            v279
    let v284 : string = "exception"
    let v285 : string = "r#\"" + v284 + "\"#"
    let v286 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v285 
    let v295 : string = "clap::Arg::new($0)"
    let v296 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v286 v295 
    let v297 : string = "$0.short($1 as char)"
    let v298 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v296, 'e') v297 
    let v299 : string = "r#\"" + v284 + "\"#"
    let v300 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v299 
    let v301 : string = "$0.long($1)"
    let v302 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v298, v300) v301 
    let v303 : string = "$0.num_args($1)"
    let v304 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v302, v280) v303 
    let v305 : string = "$0.require_equals($1)"
    let v306 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v304, true) v305 
    let v327 : string = ""
    let v328 : string = "r#\"" + v327 + "\"#"
    let v329 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v328 
    let v367 : string = "$0.default_missing_value($1)"
    let v368 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v306, v329) v367 
    let v379 : string = "clap::Command::arg($0, $1)"
    let v380 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v59, v368) v379 
    let v384 : string = "trace_level"
    let v385 : string = "r#\"" + v384 + "\"#"
    let v386 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v385 
    let v395 : string = "clap::Arg::new($0)"
    let v396 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v386 v395 
    let v397 : string = "$0.short($1 as char)"
    let v398 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v396, 't') v397 
    let v399 : string = "r#\"" + v384 + "\"#"
    let v400 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v399 
    let v401 : string = "$0.long($1)"
    let v402 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v398, v400) v401 
    
    
    
    
    
    let v407 : string = "Critical"
    let v408 : (unit -> string) = v407.ToLower
    let v409 : string = v408 ()
    let v433 : string = "Warning"
    let v434 : (unit -> string) = v433.ToLower
    let v435 : string = v434 ()
    let v447 : string = "Info"
    let v448 : (unit -> string) = v447.ToLower
    let v449 : string = v448 ()
    let v461 : string = "Debug"
    let v462 : (unit -> string) = v461.ToLower
    let v463 : string = v462 ()
    let v475 : string = "Verbose"
    let v476 : (unit -> string) = v475.ToLower
    let v477 : string = v476 ()
    (* run_target_args'
    let v539 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v540 : string list = []
    let v541 : string list = v409 :: v540 
    let v542 : string list = v435 :: v541 
    let v543 : string list = v449 :: v542 
    let v544 : string list = v463 :: v543 
    let v545 : string list = v477 :: v544 
    let _run_target_args'_v539 = v545 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v546 : string list = []
    let v547 : string list = v409 :: v546 
    let v548 : string list = v435 :: v547 
    let v549 : string list = v449 :: v548 
    let v550 : string list = v463 :: v549 
    let v551 : string list = v477 :: v550 
    let _run_target_args'_v539 = v551 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v552 : string list = []
    let v553 : string list = v409 :: v552 
    let v554 : string list = v435 :: v553 
    let v555 : string list = v449 :: v554 
    let v556 : string list = v463 :: v555 
    let v557 : string list = v477 :: v556 
    let _run_target_args'_v539 = v557 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v558 : string list = []
    let v559 : string list = v409 :: v558 
    let v560 : string list = v435 :: v559 
    let v561 : string list = v449 :: v560 
    let v562 : string list = v463 :: v561 
    let v563 : string list = v477 :: v562 
    let _run_target_args'_v539 = v563 
    #endif
#else
    let v564 : string list = []
    let v565 : string list = v409 :: v564 
    let v566 : string list = v435 :: v565 
    let v567 : string list = v449 :: v566 
    let v568 : string list = v463 :: v567 
    let v569 : string list = v477 :: v568 
    let _run_target_args'_v539 = v569 
    #endif
    let v570 : string list = _run_target_args'_v539 
    let v623 : (string list -> (string [])) = List.toArray
    let v624 : (string []) = v623 v570
    let v661 : string = "$0.to_vec()"
    let v662 : Vec<string> = Fable.Core.RustInterop.emitRustExpr v624 v661 
    let v672 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v673 : bool = Fable.Core.RustInterop.emitRustExpr v662 v672 
    let v674 : string = "x"
    let v675 : string = Fable.Core.RustInterop.emitRustExpr () v674 
    (* run_target_args'
    let v914 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v915 : string = "&*$0"
    let v916 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v675 v915 
    let _run_target_args'_v914 = v916 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v917 : string = "&*$0"
    let v918 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v675 v917 
    let _run_target_args'_v914 = v918 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v919 : string = "&*$0"
    let v920 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v675 v919 
    let _run_target_args'_v914 = v920 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v921 : Ref<Str> = v675 |> unbox<Ref<Str>>
    let _run_target_args'_v914 = v921 
    #endif
#else
    let v922 : Ref<Str> = v675 |> unbox<Ref<Str>>
    let _run_target_args'_v914 = v922 
    #endif
    let v923 : Ref<Str> = _run_target_args'_v914 
    (* run_target_args'
    let v1081 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1082 : string = "String::from($0)"
    let v1083 : std_string_String = Fable.Core.RustInterop.emitRustExpr v923 v1082 
    let _run_target_args'_v1081 = v1083 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1084 : string = "String::from($0)"
    let v1085 : std_string_String = Fable.Core.RustInterop.emitRustExpr v923 v1084 
    let _run_target_args'_v1081 = v1085 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1086 : string = "String::from($0)"
    let v1087 : std_string_String = Fable.Core.RustInterop.emitRustExpr v923 v1086 
    let _run_target_args'_v1081 = v1087 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1088 : std_string_String = v923 |> unbox<std_string_String>
    let _run_target_args'_v1081 = v1088 
    #endif
#else
    let v1089 : std_string_String = v923 |> unbox<std_string_String>
    let _run_target_args'_v1081 = v1089 
    #endif
    let v1090 : std_string_String = _run_target_args'_v1081 
    let v1099 : string = "Box::new($0)"
    let v1100 : Box<std_string_String> = Fable.Core.RustInterop.emitRustExpr v1090 v1099 
    let v1101 : string = "Box::leak($0)"
    let v1102 : Ref<Lifetime<StaticLifetime, Mut<std_string_String>>> = Fable.Core.RustInterop.emitRustExpr v1100 v1101 
    let v1103 : string = "clap::builder::PossibleValue::new(&**$0)"
    let v1104 : clap_builder_PossibleValue = Fable.Core.RustInterop.emitRustExpr v1102 v1103 
    let v1105 : string = "true; $0 }).collect::<Vec<_>>()"
    let v1106 : bool = Fable.Core.RustInterop.emitRustExpr v1104 v1105 
    let v1107 : string = "_vec_map"
    let v1108 : Vec<clap_builder_PossibleValue> = Fable.Core.RustInterop.emitRustExpr () v1107 
    let v1109 : string = "Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new($0))"
    let v1110 : clap_builder_ValueParser = Fable.Core.RustInterop.emitRustExpr v1108 v1109 
    let v1111 : string = "$0.value_parser($1)"
    let v1112 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v402, v1110) v1111 
    let v1113 : string = "clap::Command::arg($0, $1)"
    let v1114 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v380, v1112) v1113 
    let v1118 : string = "wasm"
    let v1119 : string = "r#\"" + v1118 + "\"#"
    let v1120 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v1119 
    let v1129 : string = "clap::Arg::new($0)"
    let v1130 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v1120 v1129 
    let v1131 : string = "$0.short($1 as char)"
    let v1132 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v1130, 'w') v1131 
    let v1133 : string = "r#\"" + v1118 + "\"#"
    let v1134 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v1133 
    let v1135 : string = "$0.long($1)"
    let v1136 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v1132, v1134) v1135 
    let v1137 : string = "$0.required($1)"
    let v1138 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v1136, true) v1137 
    let v1139 : string = "clap::Command::arg($0, $1)"
    let v1140 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v1114, v1138) v1139 
    v1140
and method3 () : string =
    let v0 : string = "trace_level"
    v0
and closure6 () (v0 : std_string_String) : US2 =
    US2_0(v0)
and method4 () : (std_string_String -> US2) =
    closure6()
and method5 (v0 : int32, v1 : Mut0) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method9 (v0 : string) : string =
    v0
and method10 () : string =
    let v0 : string = ""
    v0
and method13 () : string =
    let v0 : string = ""
    v0
and method14 (v0 : Mut4, v1 : string) : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and method12 (v0 : US9) : string =
    let v1 : string = method13()
    let v6 : Mut4 = {l0 = v1} : Mut4
    let v9 : string = $"%A{v0}"
    method14(v6, v9)
    let v54 : string = v6.l0
    v54
and method15 (v0 : string) : string =
    let v1 : string = method13()
    let v2 : Mut4 = {l0 = v1} : Mut4
    method14(v2, v0)
    let v3 : string = v2.l0
    v3
and method11 (v0 : string) : string =
    let v1 : US7 = US7_0
    let v2 : US8 = US8_0(v1)
    let v3 : US9 = US9_5(v2)
    let v4 : string = method12(v3)
    let v9 : string = "env.get_environment_variable / target: "
    let v10 : string = v9 + v4 
    let v22 : string = " / var: "
    let v23 : string = v10 + v22 
    let v31 : string = method15(v0)
    let v32 : string = v23 + v31 
    failwith<string> v32
and method16 (v0 : string) : string =
    let v1 : US7 = US7_1
    let v2 : US8 = US8_0(v1)
    let v3 : US9 = US9_5(v2)
    let v4 : string = method12(v3)
    let v5 : string = "env.get_environment_variable / target: "
    let v6 : string = v5 + v4 
    let v7 : string = " / var: "
    let v8 : string = v6 + v7 
    let v9 : string = method15(v0)
    let v10 : string = v8 + v9 
    failwith<string> v10
and closure8 () (v0 : string) : US10 =
    US10_0(v0)
and method17 () : (string -> US10) =
    closure8()
and method8 (v0 : string) : string =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = method9(v0)
    let v4 : string = "std::env::var(&*$0)"
    let v5 : Result<std_string_String, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr v3 v4 
    let v6 : string = "true; let _result_map_ = $0.map(|x| { //"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr v5 v6 
    let v8 : string = "x"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v8 
    let v10 : string = "fable_library_rust::String_::fromString($0)"
    let v11 : string = Fable.Core.RustInterop.emitRustExpr v9 v10 
    let v12 : string = "true; $0 })"
    let v13 : bool = Fable.Core.RustInterop.emitRustExpr v11 v12 
    let v14 : string = "_result_map_"
    let v15 : Result<string, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr () v14 
    let v16 : string = method10()
    let v17 : string = "$0.unwrap_or($1)"
    let v18 : string = Fable.Core.RustInterop.emitRustExpr struct (v15, v16) v17 
    let _run_target_args'_v2 = v18 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v19 : string = method11(v0)
    let _run_target_args'_v2 = v19 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v20 : string = method16(v0)
    let _run_target_args'_v2 = v20 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : string = "process.env[$0] ?? \"\""
    let v22 : string = Fable.Core.JsInterop.emitJsExpr v0 v21 
    let _run_target_args'_v2 = v22 
    #endif
#else
    let v23 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v24 : string = v23 v0
    let mutable _v24 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v25 : (string -> string option) = Option.ofObj
    let v26 : string option = v25 v24
    v26 
    #else
    Some v24 
    #endif
    |> fun x -> _v24 <- Some x
    let v27 : string option = match _v24 with Some x -> x | None -> failwith "optionm'.of_obj / _v24=None"
    let v28 : (string -> US10) = method17()
    let v29 : US10 option = v27 |> Option.map v28 
    let v30 : US10 = US10_1
    let v31 : US10 = v29 |> Option.defaultValue v30 
    let v35 : string =
        match v31 with
        | US10_1 -> (* None *)
            let v33 : string = ""
            v33
        | US10_0(v32) -> (* Some *)
            v32
    let _run_target_args'_v2 = v35 
    #endif
    let v36 : string = _run_target_args'_v2 
    v36
and closure9 (v0 : float) () : int64 =
    let v1 : int64 = v0 |> int64 
    v1
and closure10 () (v0 : int64) : US11 =
    US11_0(v0)
and closure11 () (v0 : exn) : US11 =
    US11_1(v0)
and method18 (v0 : float) : US11 =
    let v1 : (unit -> int64) = closure9(v0)
    let v2 : (int64 -> US11) = closure10()
    let v3 : ((unit -> exn) -> exn) = closure3()
    let v4 : (exn -> US11) = closure11()
    let v5 : US11 = try v1 () |> v2 with ex -> (fun () -> ex) |> v3 |> v4 
    v5
and closure12 (v0 : int64) () : int64 =
    let v1 : int64 = v0 |> int64 
    v1
and closure13 () (v0 : int64) : US13 =
    US13_0(v0)
and closure14 () (v0 : exn) : US13 =
    US13_1(v0)
and method19 (v0 : int64) : US13 =
    let v1 : (unit -> int64) = closure12(v0)
    let v2 : (int64 -> US13) = closure13()
    let v3 : ((unit -> exn) -> exn) = closure3()
    let v4 : (exn -> US13) = closure14()
    let v5 : US13 = try v1 () |> v2 with ex -> (fun () -> ex) |> v3 |> v4 
    v5
and method7 () : struct (US4 * US6) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method8(v0)
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v5 : string = "Warning"
    let v6 : (unit -> string) = v5.ToLower
    let v7 : string = v6 ()
    let v8 : string = "Info"
    let v9 : (unit -> string) = v8.ToLower
    let v10 : string = v9 ()
    let v11 : string = "Debug"
    let v12 : (unit -> string) = v11.ToLower
    let v13 : string = v12 ()
    let v14 : string = "Verbose"
    let v15 : (unit -> string) = v14.ToLower
    let v16 : string = v15 ()
    (* run_target_args'
    let v17 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v18 : struct (string * US5) list = []
    let v19 : US5 = US5_4
    let v20 : struct (string * US5) list = struct (v4, v19) :: v18 
    let v21 : US5 = US5_3
    let v22 : struct (string * US5) list = struct (v7, v21) :: v20 
    let v23 : US5 = US5_2
    let v24 : struct (string * US5) list = struct (v10, v23) :: v22 
    let v25 : US5 = US5_1
    let v26 : struct (string * US5) list = struct (v13, v25) :: v24 
    let v27 : US5 = US5_0
    let v28 : struct (string * US5) list = struct (v16, v27) :: v26 
    let v29 : US5 = US5_4
    let v30 : struct (string * US5) list = struct (v2, v29) :: v28 
    let v31 : US5 = US5_3
    let v32 : struct (string * US5) list = struct (v5, v31) :: v30 
    let v33 : US5 = US5_2
    let v34 : struct (string * US5) list = struct (v8, v33) :: v32 
    let v35 : US5 = US5_1
    let v36 : struct (string * US5) list = struct (v11, v35) :: v34 
    let v37 : US5 = US5_0
    let v38 : struct (string * US5) list = struct (v14, v37) :: v36 
    let _run_target_args'_v17 = v38 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v39 : struct (string * US5) list = []
    let v40 : US5 = US5_4
    let v41 : struct (string * US5) list = struct (v4, v40) :: v39 
    let v42 : US5 = US5_3
    let v43 : struct (string * US5) list = struct (v7, v42) :: v41 
    let v44 : US5 = US5_2
    let v45 : struct (string * US5) list = struct (v10, v44) :: v43 
    let v46 : US5 = US5_1
    let v47 : struct (string * US5) list = struct (v13, v46) :: v45 
    let v48 : US5 = US5_0
    let v49 : struct (string * US5) list = struct (v16, v48) :: v47 
    let v50 : US5 = US5_4
    let v51 : struct (string * US5) list = struct (v2, v50) :: v49 
    let v52 : US5 = US5_3
    let v53 : struct (string * US5) list = struct (v5, v52) :: v51 
    let v54 : US5 = US5_2
    let v55 : struct (string * US5) list = struct (v8, v54) :: v53 
    let v56 : US5 = US5_1
    let v57 : struct (string * US5) list = struct (v11, v56) :: v55 
    let v58 : US5 = US5_0
    let v59 : struct (string * US5) list = struct (v14, v58) :: v57 
    let _run_target_args'_v17 = v59 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v60 : struct (string * US5) list = []
    let v61 : US5 = US5_4
    let v62 : struct (string * US5) list = struct (v4, v61) :: v60 
    let v63 : US5 = US5_3
    let v64 : struct (string * US5) list = struct (v7, v63) :: v62 
    let v65 : US5 = US5_2
    let v66 : struct (string * US5) list = struct (v10, v65) :: v64 
    let v67 : US5 = US5_1
    let v68 : struct (string * US5) list = struct (v13, v67) :: v66 
    let v69 : US5 = US5_0
    let v70 : struct (string * US5) list = struct (v16, v69) :: v68 
    let v71 : US5 = US5_4
    let v72 : struct (string * US5) list = struct (v2, v71) :: v70 
    let v73 : US5 = US5_3
    let v74 : struct (string * US5) list = struct (v5, v73) :: v72 
    let v75 : US5 = US5_2
    let v76 : struct (string * US5) list = struct (v8, v75) :: v74 
    let v77 : US5 = US5_1
    let v78 : struct (string * US5) list = struct (v11, v77) :: v76 
    let v79 : US5 = US5_0
    let v80 : struct (string * US5) list = struct (v14, v79) :: v78 
    let _run_target_args'_v17 = v80 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v81 : struct (string * US5) list = []
    let v82 : US5 = US5_4
    let v83 : struct (string * US5) list = struct (v4, v82) :: v81 
    let v84 : US5 = US5_3
    let v85 : struct (string * US5) list = struct (v7, v84) :: v83 
    let v86 : US5 = US5_2
    let v87 : struct (string * US5) list = struct (v10, v86) :: v85 
    let v88 : US5 = US5_1
    let v89 : struct (string * US5) list = struct (v13, v88) :: v87 
    let v90 : US5 = US5_0
    let v91 : struct (string * US5) list = struct (v16, v90) :: v89 
    let v92 : US5 = US5_4
    let v93 : struct (string * US5) list = struct (v2, v92) :: v91 
    let v94 : US5 = US5_3
    let v95 : struct (string * US5) list = struct (v5, v94) :: v93 
    let v96 : US5 = US5_2
    let v97 : struct (string * US5) list = struct (v8, v96) :: v95 
    let v98 : US5 = US5_1
    let v99 : struct (string * US5) list = struct (v11, v98) :: v97 
    let v100 : US5 = US5_0
    let v101 : struct (string * US5) list = struct (v14, v100) :: v99 
    let _run_target_args'_v17 = v101 
    #endif
#else
    let v102 : struct (string * US5) list = []
    let v103 : US5 = US5_4
    let v104 : struct (string * US5) list = struct (v4, v103) :: v102 
    let v105 : US5 = US5_3
    let v106 : struct (string * US5) list = struct (v7, v105) :: v104 
    let v107 : US5 = US5_2
    let v108 : struct (string * US5) list = struct (v10, v107) :: v106 
    let v109 : US5 = US5_1
    let v110 : struct (string * US5) list = struct (v13, v109) :: v108 
    let v111 : US5 = US5_0
    let v112 : struct (string * US5) list = struct (v16, v111) :: v110 
    let v113 : US5 = US5_4
    let v114 : struct (string * US5) list = struct (v2, v113) :: v112 
    let v115 : US5 = US5_3
    let v116 : struct (string * US5) list = struct (v5, v115) :: v114 
    let v117 : US5 = US5_2
    let v118 : struct (string * US5) list = struct (v8, v117) :: v116 
    let v119 : US5 = US5_1
    let v120 : struct (string * US5) list = struct (v11, v119) :: v118 
    let v121 : US5 = US5_0
    let v122 : struct (string * US5) list = struct (v14, v121) :: v120 
    let _run_target_args'_v17 = v122 
    #endif
    let v123 : struct (string * US5) list = _run_target_args'_v17 
    let v124 : (struct (string * US5) list -> (struct (string * US5) [])) = List.toArray
    let v125 : (struct (string * US5) []) = v124 v123
    let v126 : int32 = v125.Length
    let v127 : US4 = US4_1
    let v128 : Mut0 = {l0 = 0; l1 = v127} : Mut0
    while method5(v126, v128) do
        let v130 : int32 = v128.l0
        let v131 : int32 =  -v130
        let v132 : int32 = v131 + v126
        let v133 : int32 = v132 - 1
        let v134 : US4 = v128.l1
        let struct (v135 : string, v136 : US5) = v125.[int v133]
        let v143 : US4 =
            match v134 with
            | US4_1 -> (* None *)
                let v138 : bool = v135 = v1 
                if v138 then
                    US4_0(v136)
                else
                    US4_1
            | US4_0(v137) -> (* Some *)
                v134
        let v144 : int32 = v130 + 1
        v128.l0 <- v144
        v128.l1 <- v143
        ()
    let v145 : US4 = v128.l1
    let v146 : string = "AUTOMATION"
    let v147 : string = method8(v146)
    let v148 : string = "True"
    let v149 : bool = v147 <> v148 
    let v203 : US6 =
        if v149 then
            US6_1
        else
            (* run_target_args'
            let v151 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v152 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v151 = v152 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v153 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v151 = v153 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v154 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v151 = v154 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v155 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v151 = v155 
            #endif
#else
            let v156 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v151 = v156 
            #endif
            let v157 : System.DateTime = _run_target_args'_v151 
            let v158 : System.DateTime = System.DateTime.MinValue
            (* run_target_args'
            let v159 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v160 : System.TimeSpan = v157 - v158 
            let _run_target_args'_v159 = v160 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v161 : System.TimeSpan = v157 - v158 
            let _run_target_args'_v159 = v161 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v162 : System.TimeSpan = null |> unbox<System.TimeSpan>
            let _run_target_args'_v159 = v162 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v163 : System.TimeSpan = v157 - v158 
            let _run_target_args'_v159 = v163 
            #endif
#else
            let v164 : System.TimeSpan = v157 - v158 
            let _run_target_args'_v159 = v164 
            #endif
            let v165 : System.TimeSpan = _run_target_args'_v159 
            (* run_target_args'
            let v166 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v167 : (System.TimeSpan -> int64) = _.Ticks
            let v168 : int64 = v167 v165
            let _run_target_args'_v166 = v168 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v169 : (System.TimeSpan -> int64) = _.Ticks
            let v170 : int64 = v169 v165
            let _run_target_args'_v166 = v170 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v171 : int64 = null |> unbox<int64>
            let _run_target_args'_v166 = v171 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v172 : (System.TimeSpan -> int64) = _.Ticks
            let v173 : int64 = v172 v165
            let _run_target_args'_v166 = v173 
            #endif
#else
            let v174 : (System.TimeSpan -> int64) = _.Ticks
            let v175 : int64 = v174 v165
            let _run_target_args'_v166 = v175 
            #endif
            let v176 : int64 = _run_target_args'_v166 
            let v177 : int64 = v176 / 10000000L
            let v178 : float = float v177
            let v179 : float = 10000000.0 * v178
            let v180 : US11 = method18(v179)
            let v186 : US12 =
                match v180 with
                | US11_1(v183) -> (* Error *)
                    US12_1
                | US11_0(v181) -> (* Ok *)
                    US12_0(v181)
            let v190 : int64 =
                match v186 with
                | US12_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US12_0(v187) -> (* Some *)
                    v187
            let v191 : US13 = method19(v190)
            let v197 : US6 =
                match v191 with
                | US13_1(v194) -> (* Error *)
                    US6_1
                | US13_0(v192) -> (* Ok *)
                    US6_0(v192)
            let v201 : int64 =
                match v197 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v198) -> (* Some *)
                    v198
            US6_0(v201)
    struct (v145, v203)
and closure15 () (v0 : string) : unit =
    ()
and method6 (v0 : US5) : struct (Mut1 * Mut2 * Mut3 * Mut4 * Mut5 * int64 option) =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : US4 = US4_1
    let v3 : US6 = US6_1
    let _run_target_args'_v1 = struct (v2, v3) 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4 : US4 = US4_1
    let v5 : US6 = US6_1
    let _run_target_args'_v1 = struct (v4, v5) 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v6 : string = "AUTOMATION"
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "option_env!(\"" + v6 + "\").unwrap_or(\"\")"
    let v9 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v8 
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "String::from($0)"
    let v16 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v17 : std_string_String = v9 |> unbox<std_string_String>
    let _run_target_args'_v10 = v17 
    #endif
#else
    let v18 : std_string_String = v9 |> unbox<std_string_String>
    let _run_target_args'_v10 = v18 
    #endif
    let v19 : std_string_String = _run_target_args'_v10 
    let v20 : string = "fable_library_rust::String_::fromString($0)"
    let v21 : string = Fable.Core.RustInterop.emitRustExpr v19 v20 
    let _run_target_args'_v7 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v22 : string = "option_env!(\"" + v6 + "\").unwrap_or(\"\")"
    let v23 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v22 
    (* run_target_args'
    let v24 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v25 : string = "String::from($0)"
    let v26 : std_string_String = Fable.Core.RustInterop.emitRustExpr v23 v25 
    let _run_target_args'_v24 = v26 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v27 : string = "String::from($0)"
    let v28 : std_string_String = Fable.Core.RustInterop.emitRustExpr v23 v27 
    let _run_target_args'_v24 = v28 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v29 : string = "String::from($0)"
    let v30 : std_string_String = Fable.Core.RustInterop.emitRustExpr v23 v29 
    let _run_target_args'_v24 = v30 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v31 : std_string_String = v23 |> unbox<std_string_String>
    let _run_target_args'_v24 = v31 
    #endif
#else
    let v32 : std_string_String = v23 |> unbox<std_string_String>
    let _run_target_args'_v24 = v32 
    #endif
    let v33 : std_string_String = _run_target_args'_v24 
    let v34 : string = "fable_library_rust::String_::fromString($0)"
    let v35 : string = Fable.Core.RustInterop.emitRustExpr v33 v34 
    let _run_target_args'_v7 = v35 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v36 : string = "option_env!(\"" + v6 + "\").unwrap_or(\"\")"
    let v37 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v36 
    (* run_target_args'
    let v38 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v39 : string = "String::from($0)"
    let v40 : std_string_String = Fable.Core.RustInterop.emitRustExpr v37 v39 
    let _run_target_args'_v38 = v40 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v41 : string = "String::from($0)"
    let v42 : std_string_String = Fable.Core.RustInterop.emitRustExpr v37 v41 
    let _run_target_args'_v38 = v42 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v43 : string = "String::from($0)"
    let v44 : std_string_String = Fable.Core.RustInterop.emitRustExpr v37 v43 
    let _run_target_args'_v38 = v44 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v45 : std_string_String = v37 |> unbox<std_string_String>
    let _run_target_args'_v38 = v45 
    #endif
#else
    let v46 : std_string_String = v37 |> unbox<std_string_String>
    let _run_target_args'_v38 = v46 
    #endif
    let v47 : std_string_String = _run_target_args'_v38 
    let v48 : string = "fable_library_rust::String_::fromString($0)"
    let v49 : string = Fable.Core.RustInterop.emitRustExpr v47 v48 
    let _run_target_args'_v7 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v50 : string = null |> unbox<string>
    let _run_target_args'_v7 = v50 
    #endif
#else
    let v51 : string = null |> unbox<string>
    let _run_target_args'_v7 = v51 
    #endif
    let v52 : string = _run_target_args'_v7 
    let v53 : string = "True"
    let v54 : bool = v52 <> v53 
    let v61 : US6 =
        if v54 then
            US6_1
        else
            let v56 : string = $"near_sdk::env::block_timestamp()"
            let v57 : uint64 = Fable.Core.RustInterop.emitRustExpr () v56 
            let v58 : (uint64 -> int64) = int64
            let v59 : int64 = v58 v57
            US6_0(v59)
    let v62 : US4 = US4_1
    let _run_target_args'_v1 = struct (v62, v61) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v63 : US4, v64 : US6) = method7()
    let _run_target_args'_v1 = struct (v63, v64) 
    #endif
#else
    let struct (v65 : US4, v66 : US6) = method7()
    let _run_target_args'_v1 = struct (v65, v66) 
    #endif
    let struct (v67 : US4, v68 : US6) = _run_target_args'_v1 
    let v69 : Mut1 = {l0 = 1L} : Mut1
    let v70 : (string -> unit) = closure15()
    let v71 : Mut2 = {l0 = v70} : Mut2
    let v72 : Mut3 = {l0 = true} : Mut3
    let v73 : string = ""
    let v74 : Mut4 = {l0 = v73} : Mut4
    let v77 : US5 =
        match v67 with
        | US4_1 -> (* None *)
            v0
        | US4_0(v75) -> (* Some *)
            v75
    let v78 : Mut5 = {l0 = v77} : Mut5
    let v83 : int64 option =
        match v68 with
        | US6_1 -> (* None *)
            let v81 : int64 option = None
            v81
        | US6_0(v79) -> (* Some *)
            let v80 : int64 option = Some v79 
            v80
    struct (v69, v71, v72, v74, v78, v83)
and closure7 (v0 : US5) () : unit =
    let v1 : bool = TraceState.trace_state.IsNone
    if v1 then
        let struct (v2 : Mut1, v3 : Mut2, v4 : Mut3, v5 : Mut4, v6 : Mut5, v7 : int64 option) = method6(v0)
        let v8 : struct (Mut1 * Mut2 * Mut3 * Mut4 * Mut5 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v8 
        ()
and closure17 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US5 = US5_0
        let struct (v2 : Mut1, v3 : Mut2, v4 : Mut3, v5 : Mut4, v6 : Mut5, v7 : int64 option) = method6(v1)
        let v8 : struct (Mut1 * Mut2 * Mut3 * Mut4 * Mut5 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v8 
        ()
and closure18 () (v0 : int64) : US6 =
    US6_0(v0)
and method21 () : (int64 -> US6) =
    closure18()
and method22 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method23 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method20 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option) : string =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : (int64 -> US6) = method21()
    let v8 : US6 option = v5 |> Option.map v7 
    let v9 : US6 = US6_1
    let v10 : US6 = v8 |> Option.defaultValue v9 
    let v82 : System.DateTime =
        match v10 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v74 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v75 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v74 = v75 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v76 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v74 = v76 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v77 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v74 = v77 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v78 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v74 = v78 
            #endif
#else
            let v79 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v74 = v79 
            #endif
            let v80 : System.DateTime = _run_target_args'_v74 
            v80
        | US6_0(v11) -> (* Some *)
            (* run_target_args'
            let v12 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v13 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v12 = v13 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v14 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v12 = v14 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v15 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v12 = v15 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v16 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v12 = v16 
            #endif
#else
            let v17 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v12 = v17 
            #endif
            let v18 : System.DateTime = _run_target_args'_v12 
            let v19 : System.DateTime = System.DateTime.MinValue
            (* run_target_args'
            let v20 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v21 : System.TimeSpan = v18 - v19 
            let _run_target_args'_v20 = v21 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v22 : System.TimeSpan = v18 - v19 
            let _run_target_args'_v20 = v22 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v23 : System.TimeSpan = null |> unbox<System.TimeSpan>
            let _run_target_args'_v20 = v23 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v24 : System.TimeSpan = v18 - v19 
            let _run_target_args'_v20 = v24 
            #endif
#else
            let v25 : System.TimeSpan = v18 - v19 
            let _run_target_args'_v20 = v25 
            #endif
            let v26 : System.TimeSpan = _run_target_args'_v20 
            (* run_target_args'
            let v27 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v28 : (System.TimeSpan -> int64) = _.Ticks
            let v29 : int64 = v28 v26
            let _run_target_args'_v27 = v29 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v30 : (System.TimeSpan -> int64) = _.Ticks
            let v31 : int64 = v30 v26
            let _run_target_args'_v27 = v31 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v32 : int64 = null |> unbox<int64>
            let _run_target_args'_v27 = v32 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v33 : (System.TimeSpan -> int64) = _.Ticks
            let v34 : int64 = v33 v26
            let _run_target_args'_v27 = v34 
            #endif
#else
            let v35 : (System.TimeSpan -> int64) = _.Ticks
            let v36 : int64 = v35 v26
            let _run_target_args'_v27 = v36 
            #endif
            let v37 : int64 = _run_target_args'_v27 
            let v38 : int64 = v37 / 10000000L
            let v39 : float = float v38
            let v40 : float = 10000000.0 * v39
            let v41 : US11 = method18(v40)
            let v47 : US12 =
                match v41 with
                | US11_1(v44) -> (* Error *)
                    US12_1
                | US11_0(v42) -> (* Ok *)
                    US12_0(v42)
            let v51 : int64 =
                match v47 with
                | US12_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US12_0(v48) -> (* Some *)
                    v48
            let v52 : US13 = method19(v51)
            let v58 : US6 =
                match v52 with
                | US13_1(v55) -> (* Error *)
                    US6_1
                | US13_0(v53) -> (* Ok *)
                    US6_0(v53)
            let v62 : int64 =
                match v58 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v59) -> (* Some *)
                    v59
            let v63 : int64 = v62 - v11
            let v64 : System.TimeSpan = v63 |> System.TimeSpan 
            let v65 : (System.TimeSpan -> int32) = _.Hours
            let v66 : int32 = v65 v64
            let v67 : (System.TimeSpan -> int32) = _.Minutes
            let v68 : int32 = v67 v64
            let v69 : (System.TimeSpan -> int32) = _.Seconds
            let v70 : int32 = v69 v64
            let v71 : (System.TimeSpan -> int32) = _.Milliseconds
            let v72 : int32 = v71 v64
            let v73 : System.DateTime = System.DateTime (1, 1, 1, v66, v68, v70, v72)
            v73
    let v83 : string = method22()
    let v84 : bool = v83 = ""
    let v86 : string =
        if v84 then
            let v85 : string = "M-d-y hh:mm:ss tt"
            v85
        else
            v83
    let v87 : (string -> string) = v82.ToString
    let v88 : string = v87 v86
    let _run_target_args'_v6 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : (int64 -> US6) = method21()
    let v90 : US6 option = v5 |> Option.map v89 
    let v91 : US6 = US6_1
    let v92 : US6 = v90 |> Option.defaultValue v91 
    let v164 : System.DateTime =
        match v92 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v156 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v157 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v156 = v157 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v158 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v156 = v158 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v159 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v156 = v159 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v160 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v156 = v160 
            #endif
#else
            let v161 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v156 = v161 
            #endif
            let v162 : System.DateTime = _run_target_args'_v156 
            v162
        | US6_0(v93) -> (* Some *)
            (* run_target_args'
            let v94 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v95 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v94 = v95 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v96 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v94 = v96 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v97 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v94 = v97 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v98 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v94 = v98 
            #endif
#else
            let v99 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v94 = v99 
            #endif
            let v100 : System.DateTime = _run_target_args'_v94 
            let v101 : System.DateTime = System.DateTime.MinValue
            (* run_target_args'
            let v102 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v103 : System.TimeSpan = v100 - v101 
            let _run_target_args'_v102 = v103 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v104 : System.TimeSpan = v100 - v101 
            let _run_target_args'_v102 = v104 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v105 : System.TimeSpan = null |> unbox<System.TimeSpan>
            let _run_target_args'_v102 = v105 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v106 : System.TimeSpan = v100 - v101 
            let _run_target_args'_v102 = v106 
            #endif
#else
            let v107 : System.TimeSpan = v100 - v101 
            let _run_target_args'_v102 = v107 
            #endif
            let v108 : System.TimeSpan = _run_target_args'_v102 
            (* run_target_args'
            let v109 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v110 : (System.TimeSpan -> int64) = _.Ticks
            let v111 : int64 = v110 v108
            let _run_target_args'_v109 = v111 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v112 : (System.TimeSpan -> int64) = _.Ticks
            let v113 : int64 = v112 v108
            let _run_target_args'_v109 = v113 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v114 : int64 = null |> unbox<int64>
            let _run_target_args'_v109 = v114 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v115 : (System.TimeSpan -> int64) = _.Ticks
            let v116 : int64 = v115 v108
            let _run_target_args'_v109 = v116 
            #endif
#else
            let v117 : (System.TimeSpan -> int64) = _.Ticks
            let v118 : int64 = v117 v108
            let _run_target_args'_v109 = v118 
            #endif
            let v119 : int64 = _run_target_args'_v109 
            let v120 : int64 = v119 / 10000000L
            let v121 : float = float v120
            let v122 : float = 10000000.0 * v121
            let v123 : US11 = method18(v122)
            let v129 : US12 =
                match v123 with
                | US11_1(v126) -> (* Error *)
                    US12_1
                | US11_0(v124) -> (* Ok *)
                    US12_0(v124)
            let v133 : int64 =
                match v129 with
                | US12_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US12_0(v130) -> (* Some *)
                    v130
            let v134 : US13 = method19(v133)
            let v140 : US6 =
                match v134 with
                | US13_1(v137) -> (* Error *)
                    US6_1
                | US13_0(v135) -> (* Ok *)
                    US6_0(v135)
            let v144 : int64 =
                match v140 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v141) -> (* Some *)
                    v141
            let v145 : int64 = v144 - v93
            let v146 : System.TimeSpan = v145 |> System.TimeSpan 
            let v147 : (System.TimeSpan -> int32) = _.Hours
            let v148 : int32 = v147 v146
            let v149 : (System.TimeSpan -> int32) = _.Minutes
            let v150 : int32 = v149 v146
            let v151 : (System.TimeSpan -> int32) = _.Seconds
            let v152 : int32 = v151 v146
            let v153 : (System.TimeSpan -> int32) = _.Milliseconds
            let v154 : int32 = v153 v146
            let v155 : System.DateTime = System.DateTime (1, 1, 1, v148, v150, v152, v154)
            v155
    let v165 : string = method22()
    let v166 : bool = v165 = ""
    let v168 : string =
        if v166 then
            let v167 : string = "M-d-y hh:mm:ss tt"
            v167
        else
            v165
    let v169 : (string -> string) = v164.ToString
    let v170 : string = v169 v168
    let _run_target_args'_v6 = v170 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v171 : string = $"near_sdk::env::block_timestamp()"
    let v172 : uint64 = Fable.Core.RustInterop.emitRustExpr () v171 
    let v173 : (int64 -> US6) = method21()
    let v174 : US6 option = v5 |> Option.map v173 
    let v175 : US6 = US6_1
    let v176 : US6 = v174 |> Option.defaultValue v175 
    let v182 : uint64 =
        match v176 with
        | US6_1 -> (* None *)
            v172
        | US6_0(v177) -> (* Some *)
            let v178 : (int64 -> uint64) = uint64
            let v179 : uint64 = v178 v177
            let v180 : uint64 = v172 - v179
            v180
    let v183 : uint64 = v182 / 1000000000UL
    let v184 : uint64 = v183 % 60UL
    let v185 : uint64 = v183 / 60UL
    let v186 : uint64 = v185 % 60UL
    let v187 : uint64 = v183 / 3600UL
    let v188 : uint64 = v187 % 24UL
    let v189 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v190 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v188, v186, v184) v189 
    let v191 : string = "fable_library_rust::String_::fromString($0)"
    let v192 : string = Fable.Core.RustInterop.emitRustExpr v190 v191 
    let _run_target_args'_v6 = v192 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v193 : (int64 -> US6) = method21()
    let v194 : US6 option = v5 |> Option.map v193 
    let v195 : US6 = US6_1
    let v196 : US6 = v194 |> Option.defaultValue v195 
    let v268 : System.DateTime =
        match v196 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v260 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v261 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v260 = v261 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v262 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v260 = v262 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v263 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v260 = v263 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v264 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v260 = v264 
            #endif
#else
            let v265 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v260 = v265 
            #endif
            let v266 : System.DateTime = _run_target_args'_v260 
            v266
        | US6_0(v197) -> (* Some *)
            (* run_target_args'
            let v198 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v199 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v198 = v199 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v200 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v198 = v200 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v201 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v198 = v201 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v202 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v198 = v202 
            #endif
#else
            let v203 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v198 = v203 
            #endif
            let v204 : System.DateTime = _run_target_args'_v198 
            let v205 : System.DateTime = System.DateTime.MinValue
            (* run_target_args'
            let v206 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v207 : System.TimeSpan = v204 - v205 
            let _run_target_args'_v206 = v207 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v208 : System.TimeSpan = v204 - v205 
            let _run_target_args'_v206 = v208 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v209 : System.TimeSpan = null |> unbox<System.TimeSpan>
            let _run_target_args'_v206 = v209 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v210 : System.TimeSpan = v204 - v205 
            let _run_target_args'_v206 = v210 
            #endif
#else
            let v211 : System.TimeSpan = v204 - v205 
            let _run_target_args'_v206 = v211 
            #endif
            let v212 : System.TimeSpan = _run_target_args'_v206 
            (* run_target_args'
            let v213 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v214 : (System.TimeSpan -> int64) = _.Ticks
            let v215 : int64 = v214 v212
            let _run_target_args'_v213 = v215 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v216 : (System.TimeSpan -> int64) = _.Ticks
            let v217 : int64 = v216 v212
            let _run_target_args'_v213 = v217 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : int64 = null |> unbox<int64>
            let _run_target_args'_v213 = v218 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v219 : (System.TimeSpan -> int64) = _.Ticks
            let v220 : int64 = v219 v212
            let _run_target_args'_v213 = v220 
            #endif
#else
            let v221 : (System.TimeSpan -> int64) = _.Ticks
            let v222 : int64 = v221 v212
            let _run_target_args'_v213 = v222 
            #endif
            let v223 : int64 = _run_target_args'_v213 
            let v224 : int64 = v223 / 10000000L
            let v225 : float = float v224
            let v226 : float = 10000000.0 * v225
            let v227 : US11 = method18(v226)
            let v233 : US12 =
                match v227 with
                | US11_1(v230) -> (* Error *)
                    US12_1
                | US11_0(v228) -> (* Ok *)
                    US12_0(v228)
            let v237 : int64 =
                match v233 with
                | US12_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US12_0(v234) -> (* Some *)
                    v234
            let v238 : US13 = method19(v237)
            let v244 : US6 =
                match v238 with
                | US13_1(v241) -> (* Error *)
                    US6_1
                | US13_0(v239) -> (* Ok *)
                    US6_0(v239)
            let v248 : int64 =
                match v244 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v245) -> (* Some *)
                    v245
            let v249 : int64 = v248 - v197
            let v250 : System.TimeSpan = v249 |> System.TimeSpan 
            let v251 : (System.TimeSpan -> int32) = _.Hours
            let v252 : int32 = v251 v250
            let v253 : (System.TimeSpan -> int32) = _.Minutes
            let v254 : int32 = v253 v250
            let v255 : (System.TimeSpan -> int32) = _.Seconds
            let v256 : int32 = v255 v250
            let v257 : (System.TimeSpan -> int32) = _.Milliseconds
            let v258 : int32 = v257 v250
            let v259 : System.DateTime = System.DateTime (1, 1, 1, v252, v254, v256, v258)
            v259
    let v269 : string = method23()
    let v270 : bool = v269 = ""
    let v272 : string =
        if v270 then
            let v271 : string = "M-d-y hh:mm:ss tt"
            v271
        else
            v269
    let v273 : (string -> string) = v268.ToString
    let v274 : string = v273 v272
    let _run_target_args'_v6 = v274 
    #endif
#else
    let v275 : (int64 -> US6) = method21()
    let v276 : US6 option = v5 |> Option.map v275 
    let v277 : US6 = US6_1
    let v278 : US6 = v276 |> Option.defaultValue v277 
    let v350 : System.DateTime =
        match v278 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v342 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v343 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v342 = v343 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v344 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v342 = v344 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v345 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v342 = v345 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v346 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v342 = v346 
            #endif
#else
            let v347 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v342 = v347 
            #endif
            let v348 : System.DateTime = _run_target_args'_v342 
            v348
        | US6_0(v279) -> (* Some *)
            (* run_target_args'
            let v280 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v281 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v280 = v281 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v282 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v280 = v282 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v283 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v280 = v283 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v284 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v280 = v284 
            #endif
#else
            let v285 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v280 = v285 
            #endif
            let v286 : System.DateTime = _run_target_args'_v280 
            let v287 : System.DateTime = System.DateTime.MinValue
            (* run_target_args'
            let v288 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v289 : System.TimeSpan = v286 - v287 
            let _run_target_args'_v288 = v289 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v290 : System.TimeSpan = v286 - v287 
            let _run_target_args'_v288 = v290 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v291 : System.TimeSpan = null |> unbox<System.TimeSpan>
            let _run_target_args'_v288 = v291 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v292 : System.TimeSpan = v286 - v287 
            let _run_target_args'_v288 = v292 
            #endif
#else
            let v293 : System.TimeSpan = v286 - v287 
            let _run_target_args'_v288 = v293 
            #endif
            let v294 : System.TimeSpan = _run_target_args'_v288 
            (* run_target_args'
            let v295 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v296 : (System.TimeSpan -> int64) = _.Ticks
            let v297 : int64 = v296 v294
            let _run_target_args'_v295 = v297 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v298 : (System.TimeSpan -> int64) = _.Ticks
            let v299 : int64 = v298 v294
            let _run_target_args'_v295 = v299 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v300 : int64 = null |> unbox<int64>
            let _run_target_args'_v295 = v300 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v301 : (System.TimeSpan -> int64) = _.Ticks
            let v302 : int64 = v301 v294
            let _run_target_args'_v295 = v302 
            #endif
#else
            let v303 : (System.TimeSpan -> int64) = _.Ticks
            let v304 : int64 = v303 v294
            let _run_target_args'_v295 = v304 
            #endif
            let v305 : int64 = _run_target_args'_v295 
            let v306 : int64 = v305 / 10000000L
            let v307 : float = float v306
            let v308 : float = 10000000.0 * v307
            let v309 : US11 = method18(v308)
            let v315 : US12 =
                match v309 with
                | US11_1(v312) -> (* Error *)
                    US12_1
                | US11_0(v310) -> (* Ok *)
                    US12_0(v310)
            let v319 : int64 =
                match v315 with
                | US12_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US12_0(v316) -> (* Some *)
                    v316
            let v320 : US13 = method19(v319)
            let v326 : US6 =
                match v320 with
                | US13_1(v323) -> (* Error *)
                    US6_1
                | US13_0(v321) -> (* Ok *)
                    US6_0(v321)
            let v330 : int64 =
                match v326 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v327) -> (* Some *)
                    v327
            let v331 : int64 = v330 - v279
            let v332 : System.TimeSpan = v331 |> System.TimeSpan 
            let v333 : (System.TimeSpan -> int32) = _.Hours
            let v334 : int32 = v333 v332
            let v335 : (System.TimeSpan -> int32) = _.Minutes
            let v336 : int32 = v335 v332
            let v337 : (System.TimeSpan -> int32) = _.Seconds
            let v338 : int32 = v337 v332
            let v339 : (System.TimeSpan -> int32) = _.Milliseconds
            let v340 : int32 = v339 v332
            let v341 : System.DateTime = System.DateTime (1, 1, 1, v334, v336, v338, v340)
            v341
    let v351 : string = method23()
    let v352 : bool = v351 = ""
    let v354 : string =
        if v352 then
            let v353 : string = "M-d-y hh:mm:ss tt"
            v353
        else
            v351
    let v355 : (string -> string) = v350.ToString
    let v356 : string = v355 v354
    let _run_target_args'_v6 = v356 
    #endif
    let v357 : string = _run_target_args'_v6 
    v357
and method25 (v0 : char) : string =
    let v1 : string = method13()
    let v2 : Mut4 = {l0 = v1} : Mut4
    let v3 : string = $"{v0}"
    method14(v2, v3)
    let v4 : string = v2.l0
    v4
and method24 () : string =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1 : string = "inline_colorization::color_bright_black"
    let v2 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1 
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "String::from($0)"
    let v5 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v4 
    let _run_target_args'_v3 = v5 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : string = "String::from($0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : string = "String::from($0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let _run_target_args'_v3 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : std_string_String = v2 |> unbox<std_string_String>
    let _run_target_args'_v3 = v10 
    #endif
#else
    let v11 : std_string_String = v2 |> unbox<std_string_String>
    let _run_target_args'_v3 = v11 
    #endif
    let v12 : std_string_String = _run_target_args'_v3 
    let v13 : string = "fable_library_rust::String_::fromString($0)"
    let v14 : string = Fable.Core.RustInterop.emitRustExpr v12 v13 
    let _run_target_args'_v0 = v14 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v15 : string = "inline_colorization::color_bright_black"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v15 
    (* run_target_args'
    let v17 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v18 : string = "String::from($0)"
    let v19 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v18 
    let _run_target_args'_v17 = v19 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v20 : string = "String::from($0)"
    let v21 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v20 
    let _run_target_args'_v17 = v21 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v22 : string = "String::from($0)"
    let v23 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v22 
    let _run_target_args'_v17 = v23 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v24 : std_string_String = v16 |> unbox<std_string_String>
    let _run_target_args'_v17 = v24 
    #endif
#else
    let v25 : std_string_String = v16 |> unbox<std_string_String>
    let _run_target_args'_v17 = v25 
    #endif
    let v26 : std_string_String = _run_target_args'_v17 
    let v27 : string = "fable_library_rust::String_::fromString($0)"
    let v28 : string = Fable.Core.RustInterop.emitRustExpr v26 v27 
    let _run_target_args'_v0 = v28 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v29 : string = "inline_colorization::color_bright_black"
    let v30 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v29 
    (* run_target_args'
    let v31 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v32 : string = "String::from($0)"
    let v33 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v32 
    let _run_target_args'_v31 = v33 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v34 : string = "String::from($0)"
    let v35 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v34 
    let _run_target_args'_v31 = v35 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v36 : string = "String::from($0)"
    let v37 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v36 
    let _run_target_args'_v31 = v37 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v38 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v31 = v38 
    #endif
#else
    let v39 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v31 = v39 
    #endif
    let v40 : std_string_String = _run_target_args'_v31 
    let v41 : string = "fable_library_rust::String_::fromString($0)"
    let v42 : string = Fable.Core.RustInterop.emitRustExpr v40 v41 
    let _run_target_args'_v0 = v42 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v43 : string = "\u001b[90m"
    let _run_target_args'_v0 = v43 
    #endif
#else
    let v44 : string = "\u001b[90m"
    let _run_target_args'_v0 = v44 
    #endif
    let v45 : string = _run_target_args'_v0 
    
    
    
    
    
    let v46 : string = "Verbose"
    let v47 : (unit -> string) = v46.ToLower
    let v48 : string = v47 ()
    let v49 : char = v48.[int 0]
    let v50 : string = method25(v49)
    let v51 : string = v45 + v50 
    (* run_target_args'
    let v52 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v53 : string = "inline_colorization::color_reset"
    let v54 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v53 
    (* run_target_args'
    let v55 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v56 : string = "String::from($0)"
    let v57 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v56 
    let _run_target_args'_v55 = v57 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v58 : string = "String::from($0)"
    let v59 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v58 
    let _run_target_args'_v55 = v59 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v60 : string = "String::from($0)"
    let v61 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v60 
    let _run_target_args'_v55 = v61 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v62 : std_string_String = v54 |> unbox<std_string_String>
    let _run_target_args'_v55 = v62 
    #endif
#else
    let v63 : std_string_String = v54 |> unbox<std_string_String>
    let _run_target_args'_v55 = v63 
    #endif
    let v64 : std_string_String = _run_target_args'_v55 
    let v65 : string = "fable_library_rust::String_::fromString($0)"
    let v66 : string = Fable.Core.RustInterop.emitRustExpr v64 v65 
    let _run_target_args'_v52 = v66 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v67 : string = "inline_colorization::color_reset"
    let v68 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v67 
    (* run_target_args'
    let v69 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v70 : string = "String::from($0)"
    let v71 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v70 
    let _run_target_args'_v69 = v71 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v72 : string = "String::from($0)"
    let v73 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v72 
    let _run_target_args'_v69 = v73 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v74 : string = "String::from($0)"
    let v75 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v74 
    let _run_target_args'_v69 = v75 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v76 : std_string_String = v68 |> unbox<std_string_String>
    let _run_target_args'_v69 = v76 
    #endif
#else
    let v77 : std_string_String = v68 |> unbox<std_string_String>
    let _run_target_args'_v69 = v77 
    #endif
    let v78 : std_string_String = _run_target_args'_v69 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v52 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "inline_colorization::color_reset"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v81 
    (* run_target_args'
    let v83 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v84 : string = "String::from($0)"
    let v85 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v84 
    let _run_target_args'_v83 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "String::from($0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v86 
    let _run_target_args'_v83 = v87 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v88 : string = "String::from($0)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v88 
    let _run_target_args'_v83 = v89 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : std_string_String = v82 |> unbox<std_string_String>
    let _run_target_args'_v83 = v90 
    #endif
#else
    let v91 : std_string_String = v82 |> unbox<std_string_String>
    let _run_target_args'_v83 = v91 
    #endif
    let v92 : std_string_String = _run_target_args'_v83 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v52 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v95 : string = "\u001b[0m"
    let _run_target_args'_v52 = v95 
    #endif
#else
    let v96 : string = "\u001b[0m"
    let _run_target_args'_v52 = v96 
    #endif
    let v97 : string = _run_target_args'_v52 
    let v98 : string = v51 + v97 
    v98
and method27 (v0 : int64) : string =
    let v1 : string = method13()
    let v2 : Mut4 = {l0 = v1} : Mut4
    let v3 : string = $"{v0}"
    method14(v2, v3)
    let v4 : string = v2.l0
    v4
and method29 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "{ "
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method30 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "args"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method31 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = " = "
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method32 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = " }"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method28 (v0 : (string [])) : string =
    let v1 : string = method13()
    let v2 : Mut4 = {l0 = v1} : Mut4
    method29(v2)
    method30(v2)
    method31(v2)
    let v3 : string = $"%A{v0}"
    method14(v2, v3)
    method32(v2)
    let v4 : string = v2.l0
    v4
and method34 (v0 : string, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v2 >= v1
    if v3 then
        v1
    else
        let v4 : char = v0.[int v2]
        let v5 : bool = v4 = ' '
        let v11 : bool =
            if v5 then
                true
            else
                let v6 : bool = v4 = '\t'
                if v6 then
                    true
                else
                    let v7 : bool = v4 = '\r'
                    if v7 then
                        true
                    else
                        let v8 : bool = v4 = '\n'
                        v8
        if v11 then
            let v12 : int32 = v2 + 1
            method34(v0, v1, v12)
        else
            v2
and method35 (v0 : string, v1 : int32) : int32 =
    let v2 : bool = v1 <= 0
    if v2 then
        -1
    else
        let v3 : int32 = v1 - 1
        let v4 : char = v0.[int v3]
        let v5 : bool = v4 = ' '
        let v7 : bool =
            if v5 then
                true
            else
                let v6 : bool = v4 = '/'
                v6
        if v7 then
            method35(v0, v3)
        else
            v3
and method33 (v0 : string) : string =
    let v1 : int32 = v0.Length
    let v2 : int32 = 0
    let v3 : int32 = method34(v0, v1, v2)
    let v4 : int32 = v1 - 1
    let v5 : string = v0.[int v3..int v4]
    let v6 : int32 = v5.Length
    let v7 : int32 = method35(v5, v6)
    let v8 : string = v5.[int 0..int v7]
    v8
and method26 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : (string [])) : string =
    let v9 : int64 = v0.l0
    let v10 : string = " "
    let v11 : string = v6 + v10 
    let v12 : string = method27(v9)
    let v13 : string = v11 + v12 
    let v14 : string = v13 + v7 
    let v15 : string = v14 + v10 
    let v16 : string = "spiral_wasm.main"
    let v17 : string = v15 + v16 
    let v18 : string = " / "
    let v19 : string = v17 + v18 
    let v20 : string = method28(v8)
    let v21 : string = v19 + v20 
    method33(v21)
and closure19 (v0 : Mut1) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure21 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure20 () (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure21(v0)
    let v3 : unit = (fun () -> v2 (); v1) ()
    ()
and method36 (v0 : int32, v1 : Mut6) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and closure16 (v0 : (string [])) () : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure17()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v4 : Mut1, v5 : Mut2, v6 : Mut3, v7 : Mut4, v8 : Mut5, v9 : int64 option) = TraceState.trace_state.Value
    let v10 : US5 = v8.l0
    let v15 : int32 =
        match v10 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v16 : bool = v6.l0
    let v17 : bool = v16 = false
    let v19 : bool =
        if v17 then
            false
        else
            let v18 : bool = 10 >= v15
            v18
    let v20 : bool = v19 = false
    let v102 : US14 =
        if v20 then
            US14_1
        else
            let v22 : unit = ()
            let v23 : unit = (fun () -> v2 (); v22) ()
            let struct (v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : Mut5, v29 : int64 option) = TraceState.trace_state.Value
            let v30 : string = method20(v24, v25, v26, v27, v28, v29)
            let v31 : string = method24()
            let v32 : string = method26(v24, v25, v26, v27, v28, v29, v30, v31, v0)
            let v33 : unit = ()
            let v34 : unit = (fun () -> v2 (); v33) ()
            let struct (v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : Mut5, v40 : int64 option) = TraceState.trace_state.Value
            let v41 : unit = ()
            let v42 : (unit -> unit) = closure19(v35)
            let v43 : unit = (fun () -> v42 (); v41) ()
            let v44 : (string -> unit) = closure20()
            (* run_target_args'
            let v45 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v46 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v46 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v47 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v48 : string = v38.l0
            let v49 : bool = v48 = ""
            let v57 : string =
                if v49 then
                    v32
                else
                    let v50 : bool = v32 = ""
                    if v50 then
                        let v51 : string = v38.l0
                        v51
                    else
                        let v52 : string = v38.l0
                        let v53 : string = "\n"
                        let v54 : string = v52 + v53 
                        let v55 : string = v54 + v32 
                        v55
            (* run_target_args'
            let v58 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v59 : string = "&*$0"
            let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v59 
            let _run_target_args'_v58 = v60 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : string = "&*$0"
            let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v61 
            let _run_target_args'_v58 = v62 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63 : string = "&*$0"
            let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v63 
            let _run_target_args'_v58 = v64 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v65 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v65 
            #endif
#else
            let v66 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v66 
            #endif
            let v67 : Ref<Str> = _run_target_args'_v58 
            let v68 : string = $"$0.chars()"
            let v69 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v67 v68 
            let v70 : string = "$0"
            let v71 : _ = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "$0.collect::<Vec<_>>()"
            let v73 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v71 v72 
            let v74 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v75 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v77 : bool = Fable.Core.RustInterop.emitRustExpr v75 v76 
            let v78 : string = "x"
            let v79 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v78 
            let v80 : string = "String::from_iter($0)"
            let v81 : std_string_String = Fable.Core.RustInterop.emitRustExpr v79 v80 
            let v82 : string = "true; $0 }).collect::<Vec<_>>()"
            let v83 : bool = Fable.Core.RustInterop.emitRustExpr v81 v82 
            let v84 : string = "_vec_map"
            let v85 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v84 
            let v86 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v87 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v85 v86 
            let v88 : int32 = v87.Length
            let v89 : string = ""
            let v90 : bool = v32 <> v89 
            let v92 : bool =
                if v90 then
                    let v91 : bool = v88 <= 1
                    v91
                else
                    false
            if v92 then
                v38.l0 <- v57
                ()
            else
                v38.l0 <- v89
                let v93 : Mut6 = {l0 = 0} : Mut6
                while method36(v88, v93) do
                    let v95 : int32 = v93.l0
                    let v96 : std_string_String = v87.[int v95]
                    let v97 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v98 : bool = Fable.Core.RustInterop.emitRustExpr v96 v97 
                    let v99 : int32 = v95 + 1
                    v93.l0 <- v99
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v44 v32
            #endif
#else
            v44 v32
            #endif
            // run_target_args' is_unit
            let v100 : (string -> unit) = v36.l0
            v100 v32
            US14_0(v35, v36, v37, v38, v39, v40)
    ()
and method37 () : string =
    let v0 : string = "exception"
    v0
and method39 (v0 : string, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v2 >= v1
    if v3 then
        v1
    else
        let v4 : char = v0.[int v2]
        let v5 : bool = v4 = '\\'
        if v5 then
            let v6 : int32 = v2 + 1
            method39(v0, v1, v6)
        else
            v2
and method40 (v0 : string, v1 : int32) : int32 =
    let v2 : bool = v1 <= 0
    if v2 then
        -1
    else
        let v3 : int32 = v1 - 1
        let v4 : char = v0.[int v3]
        let v5 : bool = v4 = '\\'
        if v5 then
            method40(v0, v3)
        else
            v3
and closure22 () (v0 : std_string_String) : string =
    let v1 : string = "fable_library_rust::String_::fromString($0)"
    let v2 : string = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : int32 = v2.Length
    let v4 : int32 = 0
    let v5 : int32 = method39(v2, v3, v4)
    let v6 : int32 = v3 - 1
    let v7 : string = v2.[int v5..int v6]
    let v8 : int32 = v7.Length
    let v9 : int32 = method40(v7, v8)
    let v10 : string = v7.[int 0..int v9]
    v10
and method38 () : (std_string_String -> string) =
    closure22()
and method42 () : string =
    let v0 : string = "wasm"
    v0
and method45 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "wasm_path"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method44 (v0 : string) : string =
    let v1 : string = method13()
    let v2 : Mut4 = {l0 = v1} : Mut4
    method29(v2)
    method45(v2)
    method31(v2)
    method14(v2, v0)
    method32(v2)
    let v3 : string = v2.l0
    v3
and method43 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : int64 = v0.l0
    let v10 : string = " "
    let v11 : string = v6 + v10 
    let v12 : string = method27(v9)
    let v13 : string = v11 + v12 
    let v14 : string = v13 + v7 
    let v15 : string = v14 + v10 
    let v16 : string = "spiral_wasm.run"
    let v17 : string = v15 + v16 
    let v18 : string = " / "
    let v19 : string = v17 + v18 
    let v20 : string = method44(v8)
    let v21 : string = v19 + v20 
    method33(v21)
and closure23 (v0 : string) () : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure17()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v4 : Mut1, v5 : Mut2, v6 : Mut3, v7 : Mut4, v8 : Mut5, v9 : int64 option) = TraceState.trace_state.Value
    let v10 : US5 = v8.l0
    let v15 : int32 =
        match v10 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v16 : bool = v6.l0
    let v17 : bool = v16 = false
    let v19 : bool =
        if v17 then
            false
        else
            let v18 : bool = 10 >= v15
            v18
    let v20 : bool = v19 = false
    let v102 : US14 =
        if v20 then
            US14_1
        else
            let v22 : unit = ()
            let v23 : unit = (fun () -> v2 (); v22) ()
            let struct (v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : Mut5, v29 : int64 option) = TraceState.trace_state.Value
            let v30 : string = method20(v24, v25, v26, v27, v28, v29)
            let v31 : string = method24()
            let v32 : string = method43(v24, v25, v26, v27, v28, v29, v30, v31, v0)
            let v33 : unit = ()
            let v34 : unit = (fun () -> v2 (); v33) ()
            let struct (v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : Mut5, v40 : int64 option) = TraceState.trace_state.Value
            let v41 : unit = ()
            let v42 : (unit -> unit) = closure19(v35)
            let v43 : unit = (fun () -> v42 (); v41) ()
            let v44 : (string -> unit) = closure20()
            (* run_target_args'
            let v45 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v46 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v46 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v47 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v48 : string = v38.l0
            let v49 : bool = v48 = ""
            let v57 : string =
                if v49 then
                    v32
                else
                    let v50 : bool = v32 = ""
                    if v50 then
                        let v51 : string = v38.l0
                        v51
                    else
                        let v52 : string = v38.l0
                        let v53 : string = "\n"
                        let v54 : string = v52 + v53 
                        let v55 : string = v54 + v32 
                        v55
            (* run_target_args'
            let v58 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v59 : string = "&*$0"
            let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v59 
            let _run_target_args'_v58 = v60 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : string = "&*$0"
            let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v61 
            let _run_target_args'_v58 = v62 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63 : string = "&*$0"
            let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v63 
            let _run_target_args'_v58 = v64 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v65 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v65 
            #endif
#else
            let v66 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v66 
            #endif
            let v67 : Ref<Str> = _run_target_args'_v58 
            let v68 : string = $"$0.chars()"
            let v69 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v67 v68 
            let v70 : string = "$0"
            let v71 : _ = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "$0.collect::<Vec<_>>()"
            let v73 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v71 v72 
            let v74 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v75 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v77 : bool = Fable.Core.RustInterop.emitRustExpr v75 v76 
            let v78 : string = "x"
            let v79 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v78 
            let v80 : string = "String::from_iter($0)"
            let v81 : std_string_String = Fable.Core.RustInterop.emitRustExpr v79 v80 
            let v82 : string = "true; $0 }).collect::<Vec<_>>()"
            let v83 : bool = Fable.Core.RustInterop.emitRustExpr v81 v82 
            let v84 : string = "_vec_map"
            let v85 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v84 
            let v86 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v87 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v85 v86 
            let v88 : int32 = v87.Length
            let v89 : string = ""
            let v90 : bool = v32 <> v89 
            let v92 : bool =
                if v90 then
                    let v91 : bool = v88 <= 1
                    v91
                else
                    false
            if v92 then
                v38.l0 <- v57
                ()
            else
                v38.l0 <- v89
                let v93 : Mut6 = {l0 = 0} : Mut6
                while method36(v88, v93) do
                    let v95 : int32 = v93.l0
                    let v96 : std_string_String = v87.[int v95]
                    let v97 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v98 : bool = Fable.Core.RustInterop.emitRustExpr v96 v97 
                    let v99 : int32 = v95 + 1
                    v93.l0 <- v99
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v44 v32
            #endif
#else
            v44 v32
            #endif
            // run_target_args' is_unit
            let v100 : (string -> unit) = v36.l0
            v100 v32
            US14_0(v35, v36, v37, v38, v39, v40)
    ()
and method50 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "retry"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method51 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "; "
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method52 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "worker"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method53 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "contract"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method49 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) : string =
    let v3 : string = method13()
    let v4 : Mut4 = {l0 = v3} : Mut4
    method29(v4)
    method50(v4)
    method31(v4)
    let v5 : string = $"{v0}"
    method14(v4, v5)
    method51(v4)
    method52(v4)
    method31(v4)
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : string = "format!(\"{:#?}\", $0)"
    let v8 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v7 
    let v9 : string = "fable_library_rust::String_::fromString($0)"
    let v10 : string = Fable.Core.RustInterop.emitRustExpr v8 v9 
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "format!(\"{:#?}\", $0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v11 
    let v13 : string = "fable_library_rust::String_::fromString($0)"
    let v14 : string = Fable.Core.RustInterop.emitRustExpr v12 v13 
    let _run_target_args'_v6 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "format!(\"{:#?}\", $0)"
    let v16 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v15 
    let v17 : string = "fable_library_rust::String_::fromString($0)"
    let v18 : string = Fable.Core.RustInterop.emitRustExpr v16 v17 
    let _run_target_args'_v6 = v18 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : string = $"%A{v1}"
    let _run_target_args'_v6 = v19 
    #endif
#else
    let v20 : string = $"%A{v1}"
    let _run_target_args'_v6 = v20 
    #endif
    let v21 : string = _run_target_args'_v6 
    method14(v4, v21)
    method51(v4)
    method53(v4)
    method31(v4)
    (* run_target_args'
    let v22 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v23 : string = "format!(\"{:#?}\", $0)"
    let v24 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v23 
    let v25 : string = "fable_library_rust::String_::fromString($0)"
    let v26 : string = Fable.Core.RustInterop.emitRustExpr v24 v25 
    let _run_target_args'_v22 = v26 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v27 : string = "format!(\"{:#?}\", $0)"
    let v28 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v27 
    let v29 : string = "fable_library_rust::String_::fromString($0)"
    let v30 : string = Fable.Core.RustInterop.emitRustExpr v28 v29 
    let _run_target_args'_v22 = v30 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v31 : string = "format!(\"{:#?}\", $0)"
    let v32 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v31 
    let v33 : string = "fable_library_rust::String_::fromString($0)"
    let v34 : string = Fable.Core.RustInterop.emitRustExpr v32 v33 
    let _run_target_args'_v22 = v34 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v35 : string = $"%A{v2}"
    let _run_target_args'_v22 = v35 
    #endif
#else
    let v36 : string = $"%A{v2}"
    let _run_target_args'_v22 = v36 
    #endif
    let v37 : string = _run_target_args'_v22 
    method14(v4, v37)
    method32(v4)
    let v38 : string = v4.l0
    v38
and method48 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v10 : near_workspaces_Contract) : string =
    let v11 : int64 = v0.l0
    let v12 : string = " "
    let v13 : string = v6 + v12 
    let v14 : string = method27(v11)
    let v15 : string = v13 + v14 
    let v16 : string = v15 + v7 
    let v17 : string = v16 + v12 
    let v18 : string = "spiral_wasm.run"
    let v19 : string = v17 + v18 
    let v20 : string = " / "
    let v21 : string = v19 + v20 
    let v22 : string = method49(v8, v9, v10)
    let v23 : string = v21 + v22 
    method33(v23)
and closure24 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) () : unit =
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure17()
    let v5 : unit = (fun () -> v4 (); v3) ()
    let struct (v6 : Mut1, v7 : Mut2, v8 : Mut3, v9 : Mut4, v10 : Mut5, v11 : int64 option) = TraceState.trace_state.Value
    let v12 : US5 = v10.l0
    let v17 : int32 =
        match v12 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v18 : bool = v8.l0
    let v19 : bool = v18 = false
    let v21 : bool =
        if v19 then
            false
        else
            let v20 : bool = 10 >= v17
            v20
    let v22 : bool = v21 = false
    let v104 : US14 =
        if v22 then
            US14_1
        else
            let v24 : unit = ()
            let v25 : unit = (fun () -> v4 (); v24) ()
            let struct (v26 : Mut1, v27 : Mut2, v28 : Mut3, v29 : Mut4, v30 : Mut5, v31 : int64 option) = TraceState.trace_state.Value
            let v32 : string = method20(v26, v27, v28, v29, v30, v31)
            let v33 : string = method24()
            let v34 : string = method48(v26, v27, v28, v29, v30, v31, v32, v33, v0, v1, v2)
            let v35 : unit = ()
            let v36 : unit = (fun () -> v4 (); v35) ()
            let struct (v37 : Mut1, v38 : Mut2, v39 : Mut3, v40 : Mut4, v41 : Mut5, v42 : int64 option) = TraceState.trace_state.Value
            let v43 : unit = ()
            let v44 : (unit -> unit) = closure19(v37)
            let v45 : unit = (fun () -> v44 (); v43) ()
            let v46 : (string -> unit) = closure20()
            (* run_target_args'
            let v47 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v48 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v34 v48 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v49 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v34 v49 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v50 : string = v40.l0
            let v51 : bool = v50 = ""
            let v59 : string =
                if v51 then
                    v34
                else
                    let v52 : bool = v34 = ""
                    if v52 then
                        let v53 : string = v40.l0
                        v53
                    else
                        let v54 : string = v40.l0
                        let v55 : string = "\n"
                        let v56 : string = v54 + v55 
                        let v57 : string = v56 + v34 
                        v57
            (* run_target_args'
            let v60 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v61 : string = "&*$0"
            let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v59 v61 
            let _run_target_args'_v60 = v62 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v63 : string = "&*$0"
            let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v59 v63 
            let _run_target_args'_v60 = v64 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v65 : string = "&*$0"
            let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v59 v65 
            let _run_target_args'_v60 = v66 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v67 : Ref<Str> = v59 |> unbox<Ref<Str>>
            let _run_target_args'_v60 = v67 
            #endif
#else
            let v68 : Ref<Str> = v59 |> unbox<Ref<Str>>
            let _run_target_args'_v60 = v68 
            #endif
            let v69 : Ref<Str> = _run_target_args'_v60 
            let v70 : string = $"$0.chars()"
            let v71 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "$0"
            let v73 : _ = Fable.Core.RustInterop.emitRustExpr v71 v72 
            let v74 : string = "$0.collect::<Vec<_>>()"
            let v75 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v77 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v75 v76 
            let v78 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v79 : bool = Fable.Core.RustInterop.emitRustExpr v77 v78 
            let v80 : string = "x"
            let v81 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v80 
            let v82 : string = "String::from_iter($0)"
            let v83 : std_string_String = Fable.Core.RustInterop.emitRustExpr v81 v82 
            let v84 : string = "true; $0 }).collect::<Vec<_>>()"
            let v85 : bool = Fable.Core.RustInterop.emitRustExpr v83 v84 
            let v86 : string = "_vec_map"
            let v87 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v86 
            let v88 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v89 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v87 v88 
            let v90 : int32 = v89.Length
            let v91 : string = ""
            let v92 : bool = v34 <> v91 
            let v94 : bool =
                if v92 then
                    let v93 : bool = v90 <= 1
                    v93
                else
                    false
            if v94 then
                v40.l0 <- v59
                ()
            else
                v40.l0 <- v91
                let v95 : Mut6 = {l0 = 0} : Mut6
                while method36(v90, v95) do
                    let v97 : int32 = v95.l0
                    let v98 : std_string_String = v89.[int v97]
                    let v99 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v100 : bool = Fable.Core.RustInterop.emitRustExpr v98 v99 
                    let v101 : int32 = v97 + 1
                    v95.l0 <- v101
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v46 v34
            #endif
#else
            v46 v34
            #endif
            // run_target_args' is_unit
            let v102 : (string -> unit) = v38.l0
            v102 v34
            US14_0(v37, v38, v39, v40, v41, v42)
    ()
and method56 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "result"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method55 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) : string =
    let v2 : string = method13()
    let v3 : Mut4 = {l0 = v2} : Mut4
    method29(v3)
    method50(v3)
    method31(v3)
    let v4 : string = $"{v0}"
    method14(v3, v4)
    method51(v3)
    method56(v3)
    method31(v3)
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = "format!(\"{:#?}\", $0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v6 
    let v8 : string = "fable_library_rust::String_::fromString($0)"
    let v9 : string = Fable.Core.RustInterop.emitRustExpr v7 v8 
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v10 : string = "format!(\"{:#?}\", $0)"
    let v11 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v10 
    let v12 : string = "fable_library_rust::String_::fromString($0)"
    let v13 : string = Fable.Core.RustInterop.emitRustExpr v11 v12 
    let _run_target_args'_v5 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v14 : string = "format!(\"{:#?}\", $0)"
    let v15 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v14 
    let v16 : string = "fable_library_rust::String_::fromString($0)"
    let v17 : string = Fable.Core.RustInterop.emitRustExpr v15 v16 
    let _run_target_args'_v5 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : string = $"%A{v1}"
    let _run_target_args'_v5 = v18 
    #endif
#else
    let v19 : string = $"%A{v1}"
    let _run_target_args'_v5 = v19 
    #endif
    let v20 : string = _run_target_args'_v5 
    method14(v3, v20)
    method32(v3)
    let v21 : string = v3.l0
    v21
and method54 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_result_ExecutionFinalResult) : string =
    let v10 : int64 = v0.l0
    let v11 : string = " "
    let v12 : string = v6 + v11 
    let v13 : string = method27(v10)
    let v14 : string = v12 + v13 
    let v15 : string = v14 + v7 
    let v16 : string = v15 + v11 
    let v17 : string = "spiral_wasm.run"
    let v18 : string = v16 + v17 
    let v19 : string = " / "
    let v20 : string = v18 + v19 
    let v21 : string = method55(v8, v9)
    let v22 : string = v20 + v21 
    method33(v22)
and closure25 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) () : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure17()
    let v4 : unit = (fun () -> v3 (); v2) ()
    let struct (v5 : Mut1, v6 : Mut2, v7 : Mut3, v8 : Mut4, v9 : Mut5, v10 : int64 option) = TraceState.trace_state.Value
    let v11 : US5 = v9.l0
    let v16 : int32 =
        match v11 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v17 : bool = v7.l0
    let v18 : bool = v17 = false
    let v20 : bool =
        if v18 then
            false
        else
            let v19 : bool = 10 >= v16
            v19
    let v21 : bool = v20 = false
    let v103 : US14 =
        if v21 then
            US14_1
        else
            let v23 : unit = ()
            let v24 : unit = (fun () -> v3 (); v23) ()
            let struct (v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : Mut5, v30 : int64 option) = TraceState.trace_state.Value
            let v31 : string = method20(v25, v26, v27, v28, v29, v30)
            let v32 : string = method24()
            let v33 : string = method54(v25, v26, v27, v28, v29, v30, v31, v32, v0, v1)
            let v34 : unit = ()
            let v35 : unit = (fun () -> v3 (); v34) ()
            let struct (v36 : Mut1, v37 : Mut2, v38 : Mut3, v39 : Mut4, v40 : Mut5, v41 : int64 option) = TraceState.trace_state.Value
            let v42 : unit = ()
            let v43 : (unit -> unit) = closure19(v36)
            let v44 : unit = (fun () -> v43 (); v42) ()
            let v45 : (string -> unit) = closure20()
            (* run_target_args'
            let v46 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v47 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v48 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v48 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v49 : string = v39.l0
            let v50 : bool = v49 = ""
            let v58 : string =
                if v50 then
                    v33
                else
                    let v51 : bool = v33 = ""
                    if v51 then
                        let v52 : string = v39.l0
                        v52
                    else
                        let v53 : string = v39.l0
                        let v54 : string = "\n"
                        let v55 : string = v53 + v54 
                        let v56 : string = v55 + v33 
                        v56
            (* run_target_args'
            let v59 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v60 : string = "&*$0"
            let v61 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v60 
            let _run_target_args'_v59 = v61 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v62 : string = "&*$0"
            let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v62 
            let _run_target_args'_v59 = v63 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v64 : string = "&*$0"
            let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v64 
            let _run_target_args'_v59 = v65 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v66 
            #endif
#else
            let v67 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v67 
            #endif
            let v68 : Ref<Str> = _run_target_args'_v59 
            let v69 : string = $"$0.chars()"
            let v70 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v68 v69 
            let v71 : string = "$0"
            let v72 : _ = Fable.Core.RustInterop.emitRustExpr v70 v71 
            let v73 : string = "$0.collect::<Vec<_>>()"
            let v74 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v72 v73 
            let v75 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v76 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v74 v75 
            let v77 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v78 : bool = Fable.Core.RustInterop.emitRustExpr v76 v77 
            let v79 : string = "x"
            let v80 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v79 
            let v81 : string = "String::from_iter($0)"
            let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v80 v81 
            let v83 : string = "true; $0 }).collect::<Vec<_>>()"
            let v84 : bool = Fable.Core.RustInterop.emitRustExpr v82 v83 
            let v85 : string = "_vec_map"
            let v86 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v85 
            let v87 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v88 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v86 v87 
            let v89 : int32 = v88.Length
            let v90 : string = ""
            let v91 : bool = v33 <> v90 
            let v93 : bool =
                if v91 then
                    let v92 : bool = v89 <= 1
                    v92
                else
                    false
            if v93 then
                v39.l0 <- v58
                ()
            else
                v39.l0 <- v90
                let v94 : Mut6 = {l0 = 0} : Mut6
                while method36(v89, v94) do
                    let v96 : int32 = v94.l0
                    let v97 : std_string_String = v88.[int v96]
                    let v98 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v99 : bool = Fable.Core.RustInterop.emitRustExpr v97 v98 
                    let v100 : int32 = v96 + 1
                    v94.l0 <- v100
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v45 v33
            #endif
#else
            v45 v33
            #endif
            // run_target_args' is_unit
            let v101 : (string -> unit) = v37.l0
            v101 v33
            US14_0(v36, v37, v38, v39, v40, v41)
    ()
and closure27 (v0 : std_string_String) () : unit =
    let v1 : (std_string_String -> unit) = System.Console.WriteLine
    v1 v0
and closure26 () (v0 : std_string_String) : unit =
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure27(v0)
    let v5 : unit = (fun () -> v4 (); v3) ()
    ()
and closure28 () () : unit =
    let v0 : unit = ()
    let v1 : (unit -> unit) = closure17()
    let v2 : unit = (fun () -> v1 (); v0) ()
    let struct (v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : Mut5, v8 : int64 option) = TraceState.trace_state.Value
    let v9 : US5 = v7.l0
    let v14 : int32 =
        match v9 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v15 : bool = v5.l0
    let v16 : bool = v15 = false
    let v18 : bool =
        if v16 then
            false
        else
            let v17 : bool = 30 >= v14
            v17
    let v19 : bool = v18 = false
    let v91 : US14 =
        if v19 then
            US14_1
        else
            let v21 : unit = ()
            let v22 : unit = (fun () -> v1 (); v21) ()
            let struct (v23 : Mut1, v24 : Mut2, v25 : Mut3, v26 : Mut4, v27 : Mut5, v28 : int64 option) = TraceState.trace_state.Value
            let v29 : unit = ()
            let v30 : (unit -> unit) = closure19(v23)
            let v31 : unit = (fun () -> v30 (); v29) ()
            let v32 : string = " "
            let v33 : (string -> unit) = closure20()
            (* run_target_args'
            let v34 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v35 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v35 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v36 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v36 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v37 : string = v26.l0
            let v38 : bool = v37 = ""
            let v46 : string =
                if v38 then
                    v32
                else
                    let v39 : bool = v32 = ""
                    if v39 then
                        let v40 : string = v26.l0
                        v40
                    else
                        let v41 : string = v26.l0
                        let v42 : string = "\n"
                        let v43 : string = v41 + v42 
                        let v44 : string = v43 + v32 
                        v44
            (* run_target_args'
            let v47 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v48 : string = "&*$0"
            let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v46 v48 
            let _run_target_args'_v47 = v49 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v50 : string = "&*$0"
            let v51 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v46 v50 
            let _run_target_args'_v47 = v51 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v52 : string = "&*$0"
            let v53 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v46 v52 
            let _run_target_args'_v47 = v53 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v54 : Ref<Str> = v46 |> unbox<Ref<Str>>
            let _run_target_args'_v47 = v54 
            #endif
#else
            let v55 : Ref<Str> = v46 |> unbox<Ref<Str>>
            let _run_target_args'_v47 = v55 
            #endif
            let v56 : Ref<Str> = _run_target_args'_v47 
            let v57 : string = $"$0.chars()"
            let v58 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v56 v57 
            let v59 : string = "$0"
            let v60 : _ = Fable.Core.RustInterop.emitRustExpr v58 v59 
            let v61 : string = "$0.collect::<Vec<_>>()"
            let v62 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v60 v61 
            let v63 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v64 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v62 v63 
            let v65 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v66 : bool = Fable.Core.RustInterop.emitRustExpr v64 v65 
            let v67 : string = "x"
            let v68 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v67 
            let v69 : string = "String::from_iter($0)"
            let v70 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v69 
            let v71 : string = "true; $0 }).collect::<Vec<_>>()"
            let v72 : bool = Fable.Core.RustInterop.emitRustExpr v70 v71 
            let v73 : string = "_vec_map"
            let v74 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v73 
            let v75 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v76 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v74 v75 
            let v77 : int32 = v76.Length
            let v78 : string = ""
            let v79 : bool = v32 <> v78 
            let v81 : bool =
                if v79 then
                    let v80 : bool = v77 <= 1
                    v80
                else
                    false
            if v81 then
                v26.l0 <- v46
                ()
            else
                v26.l0 <- v78
                let v82 : Mut6 = {l0 = 0} : Mut6
                while method36(v77, v82) do
                    let v84 : int32 = v82.l0
                    let v85 : std_string_String = v76.[int v84]
                    let v86 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v87 : bool = Fable.Core.RustInterop.emitRustExpr v85 v86 
                    let v88 : int32 = v84 + 1
                    v82.l0 <- v88
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v33 v32
            #endif
#else
            v33 v32
            #endif
            // run_target_args' is_unit
            let v89 : (string -> unit) = v24.l0
            v89 v32
            US14_0(v23, v24, v25, v26, v27, v28)
    ()
and method57 () : string =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1 : string = "inline_colorization::color_bright_green"
    let v2 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1 
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "String::from($0)"
    let v5 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v4 
    let _run_target_args'_v3 = v5 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : string = "String::from($0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : string = "String::from($0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let _run_target_args'_v3 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : std_string_String = v2 |> unbox<std_string_String>
    let _run_target_args'_v3 = v10 
    #endif
#else
    let v11 : std_string_String = v2 |> unbox<std_string_String>
    let _run_target_args'_v3 = v11 
    #endif
    let v12 : std_string_String = _run_target_args'_v3 
    let v13 : string = "fable_library_rust::String_::fromString($0)"
    let v14 : string = Fable.Core.RustInterop.emitRustExpr v12 v13 
    let _run_target_args'_v0 = v14 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v15 : string = "inline_colorization::color_bright_green"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v15 
    (* run_target_args'
    let v17 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v18 : string = "String::from($0)"
    let v19 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v18 
    let _run_target_args'_v17 = v19 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v20 : string = "String::from($0)"
    let v21 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v20 
    let _run_target_args'_v17 = v21 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v22 : string = "String::from($0)"
    let v23 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v22 
    let _run_target_args'_v17 = v23 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v24 : std_string_String = v16 |> unbox<std_string_String>
    let _run_target_args'_v17 = v24 
    #endif
#else
    let v25 : std_string_String = v16 |> unbox<std_string_String>
    let _run_target_args'_v17 = v25 
    #endif
    let v26 : std_string_String = _run_target_args'_v17 
    let v27 : string = "fable_library_rust::String_::fromString($0)"
    let v28 : string = Fable.Core.RustInterop.emitRustExpr v26 v27 
    let _run_target_args'_v0 = v28 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v29 : string = "inline_colorization::color_bright_green"
    let v30 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v29 
    (* run_target_args'
    let v31 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v32 : string = "String::from($0)"
    let v33 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v32 
    let _run_target_args'_v31 = v33 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v34 : string = "String::from($0)"
    let v35 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v34 
    let _run_target_args'_v31 = v35 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v36 : string = "String::from($0)"
    let v37 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v36 
    let _run_target_args'_v31 = v37 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v38 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v31 = v38 
    #endif
#else
    let v39 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v31 = v39 
    #endif
    let v40 : std_string_String = _run_target_args'_v31 
    let v41 : string = "fable_library_rust::String_::fromString($0)"
    let v42 : string = Fable.Core.RustInterop.emitRustExpr v40 v41 
    let _run_target_args'_v0 = v42 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v43 : string = "\u001b[92m"
    let _run_target_args'_v0 = v43 
    #endif
#else
    let v44 : string = "\u001b[92m"
    let _run_target_args'_v0 = v44 
    #endif
    let v45 : string = _run_target_args'_v0 
    
    
    
    
    
    let v46 : string = "Info"
    let v47 : (unit -> string) = v46.ToLower
    let v48 : string = v47 ()
    let v49 : char = v48.[int 0]
    let v50 : string = method25(v49)
    let v51 : string = v45 + v50 
    (* run_target_args'
    let v52 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v53 : string = "inline_colorization::color_reset"
    let v54 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v53 
    (* run_target_args'
    let v55 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v56 : string = "String::from($0)"
    let v57 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v56 
    let _run_target_args'_v55 = v57 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v58 : string = "String::from($0)"
    let v59 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v58 
    let _run_target_args'_v55 = v59 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v60 : string = "String::from($0)"
    let v61 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v60 
    let _run_target_args'_v55 = v61 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v62 : std_string_String = v54 |> unbox<std_string_String>
    let _run_target_args'_v55 = v62 
    #endif
#else
    let v63 : std_string_String = v54 |> unbox<std_string_String>
    let _run_target_args'_v55 = v63 
    #endif
    let v64 : std_string_String = _run_target_args'_v55 
    let v65 : string = "fable_library_rust::String_::fromString($0)"
    let v66 : string = Fable.Core.RustInterop.emitRustExpr v64 v65 
    let _run_target_args'_v52 = v66 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v67 : string = "inline_colorization::color_reset"
    let v68 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v67 
    (* run_target_args'
    let v69 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v70 : string = "String::from($0)"
    let v71 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v70 
    let _run_target_args'_v69 = v71 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v72 : string = "String::from($0)"
    let v73 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v72 
    let _run_target_args'_v69 = v73 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v74 : string = "String::from($0)"
    let v75 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v74 
    let _run_target_args'_v69 = v75 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v76 : std_string_String = v68 |> unbox<std_string_String>
    let _run_target_args'_v69 = v76 
    #endif
#else
    let v77 : std_string_String = v68 |> unbox<std_string_String>
    let _run_target_args'_v69 = v77 
    #endif
    let v78 : std_string_String = _run_target_args'_v69 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v52 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "inline_colorization::color_reset"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v81 
    (* run_target_args'
    let v83 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v84 : string = "String::from($0)"
    let v85 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v84 
    let _run_target_args'_v83 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "String::from($0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v86 
    let _run_target_args'_v83 = v87 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v88 : string = "String::from($0)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v88 
    let _run_target_args'_v83 = v89 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : std_string_String = v82 |> unbox<std_string_String>
    let _run_target_args'_v83 = v90 
    #endif
#else
    let v91 : std_string_String = v82 |> unbox<std_string_String>
    let _run_target_args'_v83 = v91 
    #endif
    let v92 : std_string_String = _run_target_args'_v83 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v52 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v95 : string = "\u001b[0m"
    let _run_target_args'_v52 = v95 
    #endif
#else
    let v96 : string = "\u001b[0m"
    let _run_target_args'_v52 = v96 
    #endif
    let v97 : string = _run_target_args'_v52 
    let v98 : string = v51 + v97 
    v98
and method60 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "total_gas_burnt_usd"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method61 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "total_gas_burnt"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method59 (v0 : uint8, v1 : float, v2 : uint64) : string =
    let v3 : string = method13()
    let v4 : Mut4 = {l0 = v3} : Mut4
    method29(v4)
    method50(v4)
    method31(v4)
    let v5 : string = $"{v0}"
    method14(v4, v5)
    method51(v4)
    method60(v4)
    method31(v4)
    let v6 : string = $"%+.6f{v1}"
    method14(v4, v6)
    method51(v4)
    method61(v4)
    method31(v4)
    let v7 : string = $"{v2}"
    method14(v4, v7)
    method32(v4)
    let v8 : string = v4.l0
    v8
and method58 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : float, v10 : uint64) : string =
    let v11 : int64 = v0.l0
    let v12 : string = " "
    let v13 : string = v6 + v12 
    let v14 : string = method27(v11)
    let v15 : string = v13 + v14 
    let v16 : string = v15 + v7 
    let v17 : string = v16 + v12 
    let v18 : string = "near_workspaces.print_usd"
    let v19 : string = v17 + v18 
    let v20 : string = " / "
    let v21 : string = v19 + v20 
    let v22 : string = method59(v8, v9, v10)
    let v23 : string = v21 + v22 
    method33(v23)
and closure29 (v0 : uint8, v1 : uint64, v2 : float) () : unit =
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure17()
    let v5 : unit = (fun () -> v4 (); v3) ()
    let struct (v6 : Mut1, v7 : Mut2, v8 : Mut3, v9 : Mut4, v10 : Mut5, v11 : int64 option) = TraceState.trace_state.Value
    let v12 : US5 = v10.l0
    let v17 : int32 =
        match v12 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v18 : bool = v8.l0
    let v19 : bool = v18 = false
    let v21 : bool =
        if v19 then
            false
        else
            let v20 : bool = 30 >= v17
            v20
    let v22 : bool = v21 = false
    let v104 : US14 =
        if v22 then
            US14_1
        else
            let v24 : unit = ()
            let v25 : unit = (fun () -> v4 (); v24) ()
            let struct (v26 : Mut1, v27 : Mut2, v28 : Mut3, v29 : Mut4, v30 : Mut5, v31 : int64 option) = TraceState.trace_state.Value
            let v32 : string = method20(v26, v27, v28, v29, v30, v31)
            let v33 : string = method57()
            let v34 : string = method58(v26, v27, v28, v29, v30, v31, v32, v33, v0, v2, v1)
            let v35 : unit = ()
            let v36 : unit = (fun () -> v4 (); v35) ()
            let struct (v37 : Mut1, v38 : Mut2, v39 : Mut3, v40 : Mut4, v41 : Mut5, v42 : int64 option) = TraceState.trace_state.Value
            let v43 : unit = ()
            let v44 : (unit -> unit) = closure19(v37)
            let v45 : unit = (fun () -> v44 (); v43) ()
            let v46 : (string -> unit) = closure20()
            (* run_target_args'
            let v47 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v48 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v34 v48 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v49 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v34 v49 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v50 : string = v40.l0
            let v51 : bool = v50 = ""
            let v59 : string =
                if v51 then
                    v34
                else
                    let v52 : bool = v34 = ""
                    if v52 then
                        let v53 : string = v40.l0
                        v53
                    else
                        let v54 : string = v40.l0
                        let v55 : string = "\n"
                        let v56 : string = v54 + v55 
                        let v57 : string = v56 + v34 
                        v57
            (* run_target_args'
            let v60 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v61 : string = "&*$0"
            let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v59 v61 
            let _run_target_args'_v60 = v62 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v63 : string = "&*$0"
            let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v59 v63 
            let _run_target_args'_v60 = v64 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v65 : string = "&*$0"
            let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v59 v65 
            let _run_target_args'_v60 = v66 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v67 : Ref<Str> = v59 |> unbox<Ref<Str>>
            let _run_target_args'_v60 = v67 
            #endif
#else
            let v68 : Ref<Str> = v59 |> unbox<Ref<Str>>
            let _run_target_args'_v60 = v68 
            #endif
            let v69 : Ref<Str> = _run_target_args'_v60 
            let v70 : string = $"$0.chars()"
            let v71 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "$0"
            let v73 : _ = Fable.Core.RustInterop.emitRustExpr v71 v72 
            let v74 : string = "$0.collect::<Vec<_>>()"
            let v75 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v77 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v75 v76 
            let v78 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v79 : bool = Fable.Core.RustInterop.emitRustExpr v77 v78 
            let v80 : string = "x"
            let v81 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v80 
            let v82 : string = "String::from_iter($0)"
            let v83 : std_string_String = Fable.Core.RustInterop.emitRustExpr v81 v82 
            let v84 : string = "true; $0 }).collect::<Vec<_>>()"
            let v85 : bool = Fable.Core.RustInterop.emitRustExpr v83 v84 
            let v86 : string = "_vec_map"
            let v87 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v86 
            let v88 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v89 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v87 v88 
            let v90 : int32 = v89.Length
            let v91 : string = ""
            let v92 : bool = v34 <> v91 
            let v94 : bool =
                if v92 then
                    let v93 : bool = v90 <= 1
                    v93
                else
                    false
            if v94 then
                v40.l0 <- v59
                ()
            else
                v40.l0 <- v91
                let v95 : Mut6 = {l0 = 0} : Mut6
                while method36(v90, v95) do
                    let v97 : int32 = v95.l0
                    let v98 : std_string_String = v89.[int v97]
                    let v99 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v100 : bool = Fable.Core.RustInterop.emitRustExpr v98 v99 
                    let v101 : int32 = v97 + 1
                    v95.l0 <- v101
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v46 v34
            #endif
#else
            v46 v34
            #endif
            // run_target_args' is_unit
            let v102 : (string -> unit) = v38.l0
            v102 v34
            US14_0(v37, v38, v39, v40, v41, v42)
    ()
and method64 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "is_success"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method65 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "gas_burnt_usd"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method66 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "tokens_burnt_usd"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method67 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "gas_burnt"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method68 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "tokens_burnt"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method63 (v0 : bool, v1 : float, v2 : float, v3 : uint64, v4 : u128) : string =
    let v5 : string = method13()
    let v6 : Mut4 = {l0 = v5} : Mut4
    method29(v6)
    method64(v6)
    method31(v6)
    let v9 : string =
        if v0 then
            let v7 : string = "true"
            v7
        else
            let v8 : string = "false"
            v8
    method14(v6, v9)
    method51(v6)
    method65(v6)
    method31(v6)
    let v10 : string = $"%+.6f{v1}"
    method14(v6, v10)
    method51(v6)
    method66(v6)
    method31(v6)
    let v11 : string = $"%+.6f{v2}"
    method14(v6, v11)
    method51(v6)
    method67(v6)
    method31(v6)
    let v12 : string = $"{v3}"
    method14(v6, v12)
    method51(v6)
    method68(v6)
    method31(v6)
    (* run_target_args'
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "format!(\"{:#?}\", $0)"
    let v15 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v14 
    let v16 : string = "fable_library_rust::String_::fromString($0)"
    let v17 : string = Fable.Core.RustInterop.emitRustExpr v15 v16 
    let _run_target_args'_v13 = v17 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v18 : string = "format!(\"{:#?}\", $0)"
    let v19 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v18 
    let v20 : string = "fable_library_rust::String_::fromString($0)"
    let v21 : string = Fable.Core.RustInterop.emitRustExpr v19 v20 
    let _run_target_args'_v13 = v21 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v22 : string = "format!(\"{:#?}\", $0)"
    let v23 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v22 
    let v24 : string = "fable_library_rust::String_::fromString($0)"
    let v25 : string = Fable.Core.RustInterop.emitRustExpr v23 v24 
    let _run_target_args'_v13 = v25 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v26 : string = $"%A{v4}"
    let _run_target_args'_v13 = v26 
    #endif
#else
    let v27 : string = $"%A{v4}"
    let _run_target_args'_v13 = v27 
    #endif
    let v28 : string = _run_target_args'_v13 
    method14(v6, v28)
    method32(v6)
    let v29 : string = v6.l0
    v29
and method62 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : bool, v9 : float, v10 : float, v11 : uint64, v12 : u128) : string =
    let v13 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v16 : string = method27(v13)
    let v17 : string = v15 + v16 
    let v18 : string = v17 + v7 
    let v19 : string = v18 + v14 
    let v20 : string = "near_workspaces.print_usd / outcome"
    let v21 : string = v19 + v20 
    let v22 : string = " / "
    let v23 : string = v21 + v22 
    let v24 : string = method63(v8, v9, v10, v11, v12)
    let v25 : string = v23 + v24 
    method33(v25)
and closure31 (v0 : bool, v1 : uint64, v2 : float, v3 : u128, v4 : float) () : unit =
    let v5 : unit = ()
    let v6 : (unit -> unit) = closure17()
    let v7 : unit = (fun () -> v6 (); v5) ()
    let struct (v8 : Mut1, v9 : Mut2, v10 : Mut3, v11 : Mut4, v12 : Mut5, v13 : int64 option) = TraceState.trace_state.Value
    let v14 : US5 = v12.l0
    let v19 : int32 =
        match v14 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v20 : bool = v10.l0
    let v21 : bool = v20 = false
    let v23 : bool =
        if v21 then
            false
        else
            let v22 : bool = 30 >= v19
            v22
    let v24 : bool = v23 = false
    let v106 : US14 =
        if v24 then
            US14_1
        else
            let v26 : unit = ()
            let v27 : unit = (fun () -> v6 (); v26) ()
            let struct (v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : Mut5, v33 : int64 option) = TraceState.trace_state.Value
            let v34 : string = method20(v28, v29, v30, v31, v32, v33)
            let v35 : string = method57()
            let v36 : string = method62(v28, v29, v30, v31, v32, v33, v34, v35, v0, v2, v4, v1, v3)
            let v37 : unit = ()
            let v38 : unit = (fun () -> v6 (); v37) ()
            let struct (v39 : Mut1, v40 : Mut2, v41 : Mut3, v42 : Mut4, v43 : Mut5, v44 : int64 option) = TraceState.trace_state.Value
            let v45 : unit = ()
            let v46 : (unit -> unit) = closure19(v39)
            let v47 : unit = (fun () -> v46 (); v45) ()
            let v48 : (string -> unit) = closure20()
            (* run_target_args'
            let v49 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v50 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v36 v50 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v51 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v36 v51 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v52 : string = v42.l0
            let v53 : bool = v52 = ""
            let v61 : string =
                if v53 then
                    v36
                else
                    let v54 : bool = v36 = ""
                    if v54 then
                        let v55 : string = v42.l0
                        v55
                    else
                        let v56 : string = v42.l0
                        let v57 : string = "\n"
                        let v58 : string = v56 + v57 
                        let v59 : string = v58 + v36 
                        v59
            (* run_target_args'
            let v62 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v63 : string = "&*$0"
            let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v61 v63 
            let _run_target_args'_v62 = v64 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v65 : string = "&*$0"
            let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v61 v65 
            let _run_target_args'_v62 = v66 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v67 : string = "&*$0"
            let v68 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v61 v67 
            let _run_target_args'_v62 = v68 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v69 : Ref<Str> = v61 |> unbox<Ref<Str>>
            let _run_target_args'_v62 = v69 
            #endif
#else
            let v70 : Ref<Str> = v61 |> unbox<Ref<Str>>
            let _run_target_args'_v62 = v70 
            #endif
            let v71 : Ref<Str> = _run_target_args'_v62 
            let v72 : string = $"$0.chars()"
            let v73 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v71 v72 
            let v74 : string = "$0"
            let v75 : _ = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : string = "$0.collect::<Vec<_>>()"
            let v77 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v75 v76 
            let v78 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v79 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v77 v78 
            let v80 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v81 : bool = Fable.Core.RustInterop.emitRustExpr v79 v80 
            let v82 : string = "x"
            let v83 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v82 
            let v84 : string = "String::from_iter($0)"
            let v85 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v84 
            let v86 : string = "true; $0 }).collect::<Vec<_>>()"
            let v87 : bool = Fable.Core.RustInterop.emitRustExpr v85 v86 
            let v88 : string = "_vec_map"
            let v89 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v88 
            let v90 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v91 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v89 v90 
            let v92 : int32 = v91.Length
            let v93 : string = ""
            let v94 : bool = v36 <> v93 
            let v96 : bool =
                if v94 then
                    let v95 : bool = v92 <= 1
                    v95
                else
                    false
            if v96 then
                v42.l0 <- v61
                ()
            else
                v42.l0 <- v93
                let v97 : Mut6 = {l0 = 0} : Mut6
                while method36(v92, v97) do
                    let v99 : int32 = v97.l0
                    let v100 : std_string_String = v91.[int v99]
                    let v101 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v102 : bool = Fable.Core.RustInterop.emitRustExpr v100 v101 
                    let v103 : int32 = v99 + 1
                    v97.l0 <- v103
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v48 v36
            #endif
#else
            v48 v36
            #endif
            // run_target_args' is_unit
            let v104 : (string -> unit) = v40.l0
            v104 v36
            US14_0(v39, v40, v41, v42, v43, v44)
    ()
and closure30 () (v0 : near_workspaces_result_ExecutionOutcome) : unit =
    let v1 : string = "$0.is_success()"
    let v2 : bool = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : string = "$0.gas_burnt"
    let v4 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let v5 : string = "$0.as_gas()"
    let v6 : uint64 = Fable.Core.RustInterop.emitRustExpr v4 v5 
    let v7 : (uint64 -> float) = float
    let v8 : float = v7 v6
    let v9 : float = v8 / 10000000000000000.0
    let v10 : float = v9 * 6.68
    let v11 : string = "$0.tokens_burnt"
    let v12 : near_workspaces_types_NearToken = Fable.Core.RustInterop.emitRustExpr v0 v11 
    let v13 : string = "$0.as_yoctonear()"
    let v14 : u128 = Fable.Core.RustInterop.emitRustExpr v12 v13 
    let v15 : string = "$0 as f64"
    let v16 : float = Fable.Core.RustInterop.emitRustExpr v14 v15 
    let v17 : float = v16 / 1E+24
    let v18 : float = v17 * 6.68
    let v118 : unit = ()
    let v119 : (unit -> unit) = closure31(v2, v6, v10, v14, v18)
    let v120 : unit = (fun () -> v119 (); v118) ()
    ()
and method71 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "result2"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method70 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v1 : string = method13()
    let v2 : Mut4 = {l0 = v1} : Mut4
    method29(v2)
    method71(v2)
    method31(v2)
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "format!(\"{:#?}\", $0)"
    let v5 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v4 
    let v6 : string = "fable_library_rust::String_::fromString($0)"
    let v7 : string = Fable.Core.RustInterop.emitRustExpr v5 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : string = "format!(\"{:#?}\", $0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v8 
    let v10 : string = "fable_library_rust::String_::fromString($0)"
    let v11 : string = Fable.Core.RustInterop.emitRustExpr v9 v10 
    let _run_target_args'_v3 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v12 : string = "format!(\"{:#?}\", $0)"
    let v13 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v12 
    let v14 : string = "fable_library_rust::String_::fromString($0)"
    let v15 : string = Fable.Core.RustInterop.emitRustExpr v13 v14 
    let _run_target_args'_v3 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : string = $"%A{v0}"
    let _run_target_args'_v3 = v16 
    #endif
#else
    let v17 : string = $"%A{v0}"
    let _run_target_args'_v3 = v17 
    #endif
    let v18 : string = _run_target_args'_v3 
    method14(v2, v18)
    method32(v2)
    let v19 : string = v2.l0
    v19
and method69 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v9 : int64 = v0.l0
    let v10 : string = " "
    let v11 : string = v6 + v10 
    let v12 : string = method27(v9)
    let v13 : string = v11 + v12 
    let v14 : string = v13 + v7 
    let v15 : string = v14 + v10 
    let v16 : string = "spiral_wasm.run"
    let v17 : string = v15 + v16 
    let v18 : string = " / "
    let v19 : string = v17 + v18 
    let v20 : string = method70(v8)
    let v21 : string = v19 + v20 
    method33(v21)
and closure32 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) () : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure17()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v4 : Mut1, v5 : Mut2, v6 : Mut3, v7 : Mut4, v8 : Mut5, v9 : int64 option) = TraceState.trace_state.Value
    let v10 : US5 = v8.l0
    let v15 : int32 =
        match v10 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v16 : bool = v6.l0
    let v17 : bool = v16 = false
    let v19 : bool =
        if v17 then
            false
        else
            let v18 : bool = 10 >= v15
            v18
    let v20 : bool = v19 = false
    let v102 : US14 =
        if v20 then
            US14_1
        else
            let v22 : unit = ()
            let v23 : unit = (fun () -> v2 (); v22) ()
            let struct (v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : Mut5, v29 : int64 option) = TraceState.trace_state.Value
            let v30 : string = method20(v24, v25, v26, v27, v28, v29)
            let v31 : string = method24()
            let v32 : string = method69(v24, v25, v26, v27, v28, v29, v30, v31, v0)
            let v33 : unit = ()
            let v34 : unit = (fun () -> v2 (); v33) ()
            let struct (v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : Mut5, v40 : int64 option) = TraceState.trace_state.Value
            let v41 : unit = ()
            let v42 : (unit -> unit) = closure19(v35)
            let v43 : unit = (fun () -> v42 (); v41) ()
            let v44 : (string -> unit) = closure20()
            (* run_target_args'
            let v45 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v46 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v46 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v47 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v48 : string = v38.l0
            let v49 : bool = v48 = ""
            let v57 : string =
                if v49 then
                    v32
                else
                    let v50 : bool = v32 = ""
                    if v50 then
                        let v51 : string = v38.l0
                        v51
                    else
                        let v52 : string = v38.l0
                        let v53 : string = "\n"
                        let v54 : string = v52 + v53 
                        let v55 : string = v54 + v32 
                        v55
            (* run_target_args'
            let v58 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v59 : string = "&*$0"
            let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v59 
            let _run_target_args'_v58 = v60 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : string = "&*$0"
            let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v61 
            let _run_target_args'_v58 = v62 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63 : string = "&*$0"
            let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v63 
            let _run_target_args'_v58 = v64 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v65 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v65 
            #endif
#else
            let v66 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v66 
            #endif
            let v67 : Ref<Str> = _run_target_args'_v58 
            let v68 : string = $"$0.chars()"
            let v69 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v67 v68 
            let v70 : string = "$0"
            let v71 : _ = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "$0.collect::<Vec<_>>()"
            let v73 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v71 v72 
            let v74 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v75 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v77 : bool = Fable.Core.RustInterop.emitRustExpr v75 v76 
            let v78 : string = "x"
            let v79 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v78 
            let v80 : string = "String::from_iter($0)"
            let v81 : std_string_String = Fable.Core.RustInterop.emitRustExpr v79 v80 
            let v82 : string = "true; $0 }).collect::<Vec<_>>()"
            let v83 : bool = Fable.Core.RustInterop.emitRustExpr v81 v82 
            let v84 : string = "_vec_map"
            let v85 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v84 
            let v86 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v87 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v85 v86 
            let v88 : int32 = v87.Length
            let v89 : string = ""
            let v90 : bool = v32 <> v89 
            let v92 : bool =
                if v90 then
                    let v91 : bool = v88 <= 1
                    v91
                else
                    false
            if v92 then
                v38.l0 <- v57
                ()
            else
                v38.l0 <- v89
                let v93 : Mut6 = {l0 = 0} : Mut6
                while method36(v88, v93) do
                    let v95 : int32 = v93.l0
                    let v96 : std_string_String = v87.[int v95]
                    let v97 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v98 : bool = Fable.Core.RustInterop.emitRustExpr v96 v97 
                    let v99 : int32 = v95 + 1
                    v93.l0 <- v99
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v44 v32
            #endif
#else
            v44 v32
            #endif
            // run_target_args' is_unit
            let v100 : (string -> unit) = v36.l0
            v100 v32
            US14_0(v35, v36, v37, v38, v39, v40)
    ()
and method72 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and closure33 (v0 : unativeint) () : int32 =
    let v1 : int32 = v0 |> int32 
    v1
and closure34 () (v0 : int32) : US16 =
    US16_0(v0)
and closure35 () (v0 : exn) : US16 =
    US16_1(v0)
and method73 (v0 : unativeint) : US16 =
    let v1 : (unit -> int32) = closure33(v0)
    let v2 : (int32 -> US16) = closure34()
    let v3 : ((unit -> exn) -> exn) = closure3()
    let v4 : (exn -> US16) = closure35()
    let v5 : US16 = try v1 () |> v2 with ex -> (fun () -> ex) |> v3 |> v4 
    v5
and method76 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "receipt_failures_len"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method77 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "receipt_failures"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method75 (v0 : int32, v1 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v2 : string = method13()
    let v3 : Mut4 = {l0 = v2} : Mut4
    method29(v3)
    method76(v3)
    method31(v3)
    let v4 : string = $"{v0}"
    method14(v3, v4)
    method51(v3)
    method77(v3)
    method31(v3)
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = "format!(\"{:#?}\", $0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v6 
    let v8 : string = "fable_library_rust::String_::fromString($0)"
    let v9 : string = Fable.Core.RustInterop.emitRustExpr v7 v8 
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v10 : string = "format!(\"{:#?}\", $0)"
    let v11 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v10 
    let v12 : string = "fable_library_rust::String_::fromString($0)"
    let v13 : string = Fable.Core.RustInterop.emitRustExpr v11 v12 
    let _run_target_args'_v5 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v14 : string = "format!(\"{:#?}\", $0)"
    let v15 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v14 
    let v16 : string = "fable_library_rust::String_::fromString($0)"
    let v17 : string = Fable.Core.RustInterop.emitRustExpr v15 v16 
    let _run_target_args'_v5 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : string = $"%A{v1}"
    let _run_target_args'_v5 = v18 
    #endif
#else
    let v19 : string = $"%A{v1}"
    let _run_target_args'_v5 = v19 
    #endif
    let v20 : string = _run_target_args'_v5 
    method14(v3, v20)
    method32(v3)
    let v21 : string = v3.l0
    v21
and method74 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v10 : int64 = v0.l0
    let v11 : string = " "
    let v12 : string = v6 + v11 
    let v13 : string = method27(v10)
    let v14 : string = v12 + v13 
    let v15 : string = v14 + v7 
    let v16 : string = v15 + v11 
    let v17 : string = "spiral_wasm.run"
    let v18 : string = v16 + v17 
    let v19 : string = " / "
    let v20 : string = v18 + v19 
    let v21 : string = method75(v8, v9)
    let v22 : string = v20 + v21 
    method33(v22)
and closure36 (v0 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>, v1 : int32) () : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure17()
    let v4 : unit = (fun () -> v3 (); v2) ()
    let struct (v5 : Mut1, v6 : Mut2, v7 : Mut3, v8 : Mut4, v9 : Mut5, v10 : int64 option) = TraceState.trace_state.Value
    let v11 : US5 = v9.l0
    let v16 : int32 =
        match v11 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v17 : bool = v7.l0
    let v18 : bool = v17 = false
    let v20 : bool =
        if v18 then
            false
        else
            let v19 : bool = 10 >= v16
            v19
    let v21 : bool = v20 = false
    let v103 : US14 =
        if v21 then
            US14_1
        else
            let v23 : unit = ()
            let v24 : unit = (fun () -> v3 (); v23) ()
            let struct (v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : Mut5, v30 : int64 option) = TraceState.trace_state.Value
            let v31 : string = method20(v25, v26, v27, v28, v29, v30)
            let v32 : string = method24()
            let v33 : string = method74(v25, v26, v27, v28, v29, v30, v31, v32, v1, v0)
            let v34 : unit = ()
            let v35 : unit = (fun () -> v3 (); v34) ()
            let struct (v36 : Mut1, v37 : Mut2, v38 : Mut3, v39 : Mut4, v40 : Mut5, v41 : int64 option) = TraceState.trace_state.Value
            let v42 : unit = ()
            let v43 : (unit -> unit) = closure19(v36)
            let v44 : unit = (fun () -> v43 (); v42) ()
            let v45 : (string -> unit) = closure20()
            (* run_target_args'
            let v46 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v47 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v48 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v48 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v49 : string = v39.l0
            let v50 : bool = v49 = ""
            let v58 : string =
                if v50 then
                    v33
                else
                    let v51 : bool = v33 = ""
                    if v51 then
                        let v52 : string = v39.l0
                        v52
                    else
                        let v53 : string = v39.l0
                        let v54 : string = "\n"
                        let v55 : string = v53 + v54 
                        let v56 : string = v55 + v33 
                        v56
            (* run_target_args'
            let v59 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v60 : string = "&*$0"
            let v61 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v60 
            let _run_target_args'_v59 = v61 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v62 : string = "&*$0"
            let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v62 
            let _run_target_args'_v59 = v63 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v64 : string = "&*$0"
            let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v64 
            let _run_target_args'_v59 = v65 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v66 
            #endif
#else
            let v67 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v67 
            #endif
            let v68 : Ref<Str> = _run_target_args'_v59 
            let v69 : string = $"$0.chars()"
            let v70 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v68 v69 
            let v71 : string = "$0"
            let v72 : _ = Fable.Core.RustInterop.emitRustExpr v70 v71 
            let v73 : string = "$0.collect::<Vec<_>>()"
            let v74 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v72 v73 
            let v75 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v76 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v74 v75 
            let v77 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v78 : bool = Fable.Core.RustInterop.emitRustExpr v76 v77 
            let v79 : string = "x"
            let v80 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v79 
            let v81 : string = "String::from_iter($0)"
            let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v80 v81 
            let v83 : string = "true; $0 }).collect::<Vec<_>>()"
            let v84 : bool = Fable.Core.RustInterop.emitRustExpr v82 v83 
            let v85 : string = "_vec_map"
            let v86 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v85 
            let v87 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v88 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v86 v87 
            let v89 : int32 = v88.Length
            let v90 : string = ""
            let v91 : bool = v33 <> v90 
            let v93 : bool =
                if v91 then
                    let v92 : bool = v89 <= 1
                    v92
                else
                    false
            if v93 then
                v39.l0 <- v58
                ()
            else
                v39.l0 <- v90
                let v94 : Mut6 = {l0 = 0} : Mut6
                while method36(v89, v94) do
                    let v96 : int32 = v94.l0
                    let v97 : std_string_String = v88.[int v96]
                    let v98 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v99 : bool = Fable.Core.RustInterop.emitRustExpr v97 v98 
                    let v100 : int32 = v96 + 1
                    v94.l0 <- v100
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v45 v33
            #endif
#else
            v45 v33
            #endif
            // run_target_args' is_unit
            let v101 : (string -> unit) = v37.l0
            v101 v33
            US14_0(v36, v37, v38, v39, v40, v41)
    ()
and method78 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method81 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "receipt_outcomes_len"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method82 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "receipt_outcomes"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method80 (v0 : int32, v1 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v2 : string = method13()
    let v3 : Mut4 = {l0 = v2} : Mut4
    method29(v3)
    method81(v3)
    method31(v3)
    let v4 : string = $"{v0}"
    method14(v3, v4)
    method51(v3)
    method82(v3)
    method31(v3)
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = "format!(\"{:#?}\", $0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v6 
    let v8 : string = "fable_library_rust::String_::fromString($0)"
    let v9 : string = Fable.Core.RustInterop.emitRustExpr v7 v8 
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v10 : string = "format!(\"{:#?}\", $0)"
    let v11 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v10 
    let v12 : string = "fable_library_rust::String_::fromString($0)"
    let v13 : string = Fable.Core.RustInterop.emitRustExpr v11 v12 
    let _run_target_args'_v5 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v14 : string = "format!(\"{:#?}\", $0)"
    let v15 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v14 
    let v16 : string = "fable_library_rust::String_::fromString($0)"
    let v17 : string = Fable.Core.RustInterop.emitRustExpr v15 v16 
    let _run_target_args'_v5 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : string = $"%A{v1}"
    let _run_target_args'_v5 = v18 
    #endif
#else
    let v19 : string = $"%A{v1}"
    let _run_target_args'_v5 = v19 
    #endif
    let v20 : string = _run_target_args'_v5 
    method14(v3, v20)
    method32(v3)
    let v21 : string = v3.l0
    v21
and method79 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v10 : int64 = v0.l0
    let v11 : string = " "
    let v12 : string = v6 + v11 
    let v13 : string = method27(v10)
    let v14 : string = v12 + v13 
    let v15 : string = v14 + v7 
    let v16 : string = v15 + v11 
    let v17 : string = "spiral_wasm.run"
    let v18 : string = v16 + v17 
    let v19 : string = " / "
    let v20 : string = v18 + v19 
    let v21 : string = method80(v8, v9)
    let v22 : string = v20 + v21 
    method33(v22)
and closure37 (v0 : Vec<near_workspaces_result_ExecutionOutcome>, v1 : int32) () : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure17()
    let v4 : unit = (fun () -> v3 (); v2) ()
    let struct (v5 : Mut1, v6 : Mut2, v7 : Mut3, v8 : Mut4, v9 : Mut5, v10 : int64 option) = TraceState.trace_state.Value
    let v11 : US5 = v9.l0
    let v16 : int32 =
        match v11 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v17 : bool = v7.l0
    let v18 : bool = v17 = false
    let v20 : bool =
        if v18 then
            false
        else
            let v19 : bool = 10 >= v16
            v19
    let v21 : bool = v20 = false
    let v103 : US14 =
        if v21 then
            US14_1
        else
            let v23 : unit = ()
            let v24 : unit = (fun () -> v3 (); v23) ()
            let struct (v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : Mut5, v30 : int64 option) = TraceState.trace_state.Value
            let v31 : string = method20(v25, v26, v27, v28, v29, v30)
            let v32 : string = method24()
            let v33 : string = method79(v25, v26, v27, v28, v29, v30, v31, v32, v1, v0)
            let v34 : unit = ()
            let v35 : unit = (fun () -> v3 (); v34) ()
            let struct (v36 : Mut1, v37 : Mut2, v38 : Mut3, v39 : Mut4, v40 : Mut5, v41 : int64 option) = TraceState.trace_state.Value
            let v42 : unit = ()
            let v43 : (unit -> unit) = closure19(v36)
            let v44 : unit = (fun () -> v43 (); v42) ()
            let v45 : (string -> unit) = closure20()
            (* run_target_args'
            let v46 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v47 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v48 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v48 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v49 : string = v39.l0
            let v50 : bool = v49 = ""
            let v58 : string =
                if v50 then
                    v33
                else
                    let v51 : bool = v33 = ""
                    if v51 then
                        let v52 : string = v39.l0
                        v52
                    else
                        let v53 : string = v39.l0
                        let v54 : string = "\n"
                        let v55 : string = v53 + v54 
                        let v56 : string = v55 + v33 
                        v56
            (* run_target_args'
            let v59 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v60 : string = "&*$0"
            let v61 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v60 
            let _run_target_args'_v59 = v61 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v62 : string = "&*$0"
            let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v62 
            let _run_target_args'_v59 = v63 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v64 : string = "&*$0"
            let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v64 
            let _run_target_args'_v59 = v65 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v66 
            #endif
#else
            let v67 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v67 
            #endif
            let v68 : Ref<Str> = _run_target_args'_v59 
            let v69 : string = $"$0.chars()"
            let v70 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v68 v69 
            let v71 : string = "$0"
            let v72 : _ = Fable.Core.RustInterop.emitRustExpr v70 v71 
            let v73 : string = "$0.collect::<Vec<_>>()"
            let v74 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v72 v73 
            let v75 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v76 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v74 v75 
            let v77 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v78 : bool = Fable.Core.RustInterop.emitRustExpr v76 v77 
            let v79 : string = "x"
            let v80 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v79 
            let v81 : string = "String::from_iter($0)"
            let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v80 v81 
            let v83 : string = "true; $0 }).collect::<Vec<_>>()"
            let v84 : bool = Fable.Core.RustInterop.emitRustExpr v82 v83 
            let v85 : string = "_vec_map"
            let v86 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v85 
            let v87 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v88 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v86 v87 
            let v89 : int32 = v88.Length
            let v90 : string = ""
            let v91 : bool = v33 <> v90 
            let v93 : bool =
                if v91 then
                    let v92 : bool = v89 <= 1
                    v92
                else
                    false
            if v93 then
                v39.l0 <- v58
                ()
            else
                v39.l0 <- v90
                let v94 : Mut6 = {l0 = 0} : Mut6
                while method36(v89, v94) do
                    let v96 : int32 = v94.l0
                    let v97 : std_string_String = v88.[int v96]
                    let v98 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v99 : bool = Fable.Core.RustInterop.emitRustExpr v97 v98 
                    let v100 : int32 = v96 + 1
                    v94.l0 <- v100
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v45 v33
            #endif
#else
            v45 v33
            #endif
            // run_target_args' is_unit
            let v101 : (string -> unit) = v37.l0
            v101 v33
            US14_0(v36, v37, v38, v39, v40, v41)
    ()
and method85 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "json"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method84 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method13()
    let v2 : Mut4 = {l0 = v1} : Mut4
    method29(v2)
    method85(v2)
    method31(v2)
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "format!(\"{:#?}\", $0)"
    let v5 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v4 
    let v6 : string = "fable_library_rust::String_::fromString($0)"
    let v7 : string = Fable.Core.RustInterop.emitRustExpr v5 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : string = "format!(\"{:#?}\", $0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v8 
    let v10 : string = "fable_library_rust::String_::fromString($0)"
    let v11 : string = Fable.Core.RustInterop.emitRustExpr v9 v10 
    let _run_target_args'_v3 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v12 : string = "format!(\"{:#?}\", $0)"
    let v13 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v12 
    let v14 : string = "fable_library_rust::String_::fromString($0)"
    let v15 : string = Fable.Core.RustInterop.emitRustExpr v13 v14 
    let _run_target_args'_v3 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : string = $"%A{v0}"
    let _run_target_args'_v3 = v16 
    #endif
#else
    let v17 : string = $"%A{v0}"
    let _run_target_args'_v3 = v17 
    #endif
    let v18 : string = _run_target_args'_v3 
    method14(v2, v18)
    method32(v2)
    let v19 : string = v2.l0
    v19
and method83 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : int64 = v0.l0
    let v10 : string = " "
    let v11 : string = v6 + v10 
    let v12 : string = method27(v9)
    let v13 : string = v11 + v12 
    let v14 : string = v13 + v7 
    let v15 : string = v14 + v10 
    let v16 : string = "spiral_wasm.run"
    let v17 : string = v15 + v16 
    let v18 : string = " / "
    let v19 : string = v17 + v18 
    let v20 : string = method84(v8)
    let v21 : string = v19 + v20 
    method33(v21)
and closure38 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure17()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v4 : Mut1, v5 : Mut2, v6 : Mut3, v7 : Mut4, v8 : Mut5, v9 : int64 option) = TraceState.trace_state.Value
    let v10 : US5 = v8.l0
    let v15 : int32 =
        match v10 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v16 : bool = v6.l0
    let v17 : bool = v16 = false
    let v19 : bool =
        if v17 then
            false
        else
            let v18 : bool = 10 >= v15
            v18
    let v20 : bool = v19 = false
    let v102 : US14 =
        if v20 then
            US14_1
        else
            let v22 : unit = ()
            let v23 : unit = (fun () -> v2 (); v22) ()
            let struct (v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : Mut5, v29 : int64 option) = TraceState.trace_state.Value
            let v30 : string = method20(v24, v25, v26, v27, v28, v29)
            let v31 : string = method24()
            let v32 : string = method83(v24, v25, v26, v27, v28, v29, v30, v31, v0)
            let v33 : unit = ()
            let v34 : unit = (fun () -> v2 (); v33) ()
            let struct (v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : Mut5, v40 : int64 option) = TraceState.trace_state.Value
            let v41 : unit = ()
            let v42 : (unit -> unit) = closure19(v35)
            let v43 : unit = (fun () -> v42 (); v41) ()
            let v44 : (string -> unit) = closure20()
            (* run_target_args'
            let v45 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v46 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v46 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v47 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v48 : string = v38.l0
            let v49 : bool = v48 = ""
            let v57 : string =
                if v49 then
                    v32
                else
                    let v50 : bool = v32 = ""
                    if v50 then
                        let v51 : string = v38.l0
                        v51
                    else
                        let v52 : string = v38.l0
                        let v53 : string = "\n"
                        let v54 : string = v52 + v53 
                        let v55 : string = v54 + v32 
                        v55
            (* run_target_args'
            let v58 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v59 : string = "&*$0"
            let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v59 
            let _run_target_args'_v58 = v60 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : string = "&*$0"
            let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v61 
            let _run_target_args'_v58 = v62 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63 : string = "&*$0"
            let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v63 
            let _run_target_args'_v58 = v64 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v65 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v65 
            #endif
#else
            let v66 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v66 
            #endif
            let v67 : Ref<Str> = _run_target_args'_v58 
            let v68 : string = $"$0.chars()"
            let v69 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v67 v68 
            let v70 : string = "$0"
            let v71 : _ = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "$0.collect::<Vec<_>>()"
            let v73 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v71 v72 
            let v74 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v75 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v77 : bool = Fable.Core.RustInterop.emitRustExpr v75 v76 
            let v78 : string = "x"
            let v79 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v78 
            let v80 : string = "String::from_iter($0)"
            let v81 : std_string_String = Fable.Core.RustInterop.emitRustExpr v79 v80 
            let v82 : string = "true; $0 }).collect::<Vec<_>>()"
            let v83 : bool = Fable.Core.RustInterop.emitRustExpr v81 v82 
            let v84 : string = "_vec_map"
            let v85 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v84 
            let v86 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v87 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v85 v86 
            let v88 : int32 = v87.Length
            let v89 : string = ""
            let v90 : bool = v32 <> v89 
            let v92 : bool =
                if v90 then
                    let v91 : bool = v88 <= 1
                    v91
                else
                    false
            if v92 then
                v38.l0 <- v57
                ()
            else
                v38.l0 <- v89
                let v93 : Mut6 = {l0 = 0} : Mut6
                while method36(v88, v93) do
                    let v95 : int32 = v93.l0
                    let v96 : std_string_String = v87.[int v95]
                    let v97 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v98 : bool = Fable.Core.RustInterop.emitRustExpr v96 v97 
                    let v99 : int32 = v95 + 1
                    v93.l0 <- v99
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v44 v32
            #endif
#else
            v44 v32
            #endif
            // run_target_args' is_unit
            let v100 : (string -> unit) = v36.l0
            v100 v32
            US14_0(v35, v36, v37, v38, v39, v40)
    ()
and method88 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "borsh"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method87 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method13()
    let v2 : Mut4 = {l0 = v1} : Mut4
    method29(v2)
    method88(v2)
    method31(v2)
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "format!(\"{:#?}\", $0)"
    let v5 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v4 
    let v6 : string = "fable_library_rust::String_::fromString($0)"
    let v7 : string = Fable.Core.RustInterop.emitRustExpr v5 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : string = "format!(\"{:#?}\", $0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v8 
    let v10 : string = "fable_library_rust::String_::fromString($0)"
    let v11 : string = Fable.Core.RustInterop.emitRustExpr v9 v10 
    let _run_target_args'_v3 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v12 : string = "format!(\"{:#?}\", $0)"
    let v13 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v12 
    let v14 : string = "fable_library_rust::String_::fromString($0)"
    let v15 : string = Fable.Core.RustInterop.emitRustExpr v13 v14 
    let _run_target_args'_v3 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : string = $"%A{v0}"
    let _run_target_args'_v3 = v16 
    #endif
#else
    let v17 : string = $"%A{v0}"
    let _run_target_args'_v3 = v17 
    #endif
    let v18 : string = _run_target_args'_v3 
    method14(v2, v18)
    method32(v2)
    let v19 : string = v2.l0
    v19
and method86 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : int64 = v0.l0
    let v10 : string = " "
    let v11 : string = v6 + v10 
    let v12 : string = method27(v9)
    let v13 : string = v11 + v12 
    let v14 : string = v13 + v7 
    let v15 : string = v14 + v10 
    let v16 : string = "spiral_wasm.run"
    let v17 : string = v15 + v16 
    let v18 : string = " / "
    let v19 : string = v17 + v18 
    let v20 : string = method87(v8)
    let v21 : string = v19 + v20 
    method33(v21)
and closure39 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure17()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v4 : Mut1, v5 : Mut2, v6 : Mut3, v7 : Mut4, v8 : Mut5, v9 : int64 option) = TraceState.trace_state.Value
    let v10 : US5 = v8.l0
    let v15 : int32 =
        match v10 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v16 : bool = v6.l0
    let v17 : bool = v16 = false
    let v19 : bool =
        if v17 then
            false
        else
            let v18 : bool = 10 >= v15
            v18
    let v20 : bool = v19 = false
    let v102 : US14 =
        if v20 then
            US14_1
        else
            let v22 : unit = ()
            let v23 : unit = (fun () -> v2 (); v22) ()
            let struct (v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : Mut5, v29 : int64 option) = TraceState.trace_state.Value
            let v30 : string = method20(v24, v25, v26, v27, v28, v29)
            let v31 : string = method24()
            let v32 : string = method86(v24, v25, v26, v27, v28, v29, v30, v31, v0)
            let v33 : unit = ()
            let v34 : unit = (fun () -> v2 (); v33) ()
            let struct (v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : Mut5, v40 : int64 option) = TraceState.trace_state.Value
            let v41 : unit = ()
            let v42 : (unit -> unit) = closure19(v35)
            let v43 : unit = (fun () -> v42 (); v41) ()
            let v44 : (string -> unit) = closure20()
            (* run_target_args'
            let v45 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v46 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v46 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v47 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v48 : string = v38.l0
            let v49 : bool = v48 = ""
            let v57 : string =
                if v49 then
                    v32
                else
                    let v50 : bool = v32 = ""
                    if v50 then
                        let v51 : string = v38.l0
                        v51
                    else
                        let v52 : string = v38.l0
                        let v53 : string = "\n"
                        let v54 : string = v52 + v53 
                        let v55 : string = v54 + v32 
                        v55
            (* run_target_args'
            let v58 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v59 : string = "&*$0"
            let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v59 
            let _run_target_args'_v58 = v60 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : string = "&*$0"
            let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v61 
            let _run_target_args'_v58 = v62 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63 : string = "&*$0"
            let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v63 
            let _run_target_args'_v58 = v64 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v65 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v65 
            #endif
#else
            let v66 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v66 
            #endif
            let v67 : Ref<Str> = _run_target_args'_v58 
            let v68 : string = $"$0.chars()"
            let v69 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v67 v68 
            let v70 : string = "$0"
            let v71 : _ = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "$0.collect::<Vec<_>>()"
            let v73 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v71 v72 
            let v74 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v75 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v77 : bool = Fable.Core.RustInterop.emitRustExpr v75 v76 
            let v78 : string = "x"
            let v79 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v78 
            let v80 : string = "String::from_iter($0)"
            let v81 : std_string_String = Fable.Core.RustInterop.emitRustExpr v79 v80 
            let v82 : string = "true; $0 }).collect::<Vec<_>>()"
            let v83 : bool = Fable.Core.RustInterop.emitRustExpr v81 v82 
            let v84 : string = "_vec_map"
            let v85 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v84 
            let v86 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v87 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v85 v86 
            let v88 : int32 = v87.Length
            let v89 : string = ""
            let v90 : bool = v32 <> v89 
            let v92 : bool =
                if v90 then
                    let v91 : bool = v88 <= 1
                    v91
                else
                    false
            if v92 then
                v38.l0 <- v57
                ()
            else
                v38.l0 <- v89
                let v93 : Mut6 = {l0 = 0} : Mut6
                while method36(v88, v93) do
                    let v95 : int32 = v93.l0
                    let v96 : std_string_String = v87.[int v95]
                    let v97 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v98 : bool = Fable.Core.RustInterop.emitRustExpr v96 v97 
                    let v99 : int32 = v95 + 1
                    v93.l0 <- v99
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v44 v32
            #endif
#else
            v44 v32
            #endif
            // run_target_args' is_unit
            let v100 : (string -> unit) = v36.l0
            v100 v32
            US14_0(v35, v36, v37, v38, v39, v40)
    ()
and method89 (v0 : int32, v1 : uint8, v2 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v3 : string = method13()
    let v4 : Mut4 = {l0 = v3} : Mut4
    method29(v4)
    method81(v4)
    method31(v4)
    let v5 : string = $"{v0}"
    method14(v4, v5)
    method51(v4)
    method50(v4)
    method31(v4)
    let v6 : string = $"{v1}"
    method14(v4, v6)
    method51(v4)
    method77(v4)
    method31(v4)
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "format!(\"{:#?}\", $0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let v10 : string = "fable_library_rust::String_::fromString($0)"
    let v11 : string = Fable.Core.RustInterop.emitRustExpr v9 v10 
    let _run_target_args'_v7 = v11 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : string = "format!(\"{:#?}\", $0)"
    let v13 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v12 
    let v14 : string = "fable_library_rust::String_::fromString($0)"
    let v15 : string = Fable.Core.RustInterop.emitRustExpr v13 v14 
    let _run_target_args'_v7 = v15 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : string = "format!(\"{:#?}\", $0)"
    let v17 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v16 
    let v18 : string = "fable_library_rust::String_::fromString($0)"
    let v19 : string = Fable.Core.RustInterop.emitRustExpr v17 v18 
    let _run_target_args'_v7 = v19 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : string = $"%A{v2}"
    let _run_target_args'_v7 = v20 
    #endif
#else
    let v21 : string = $"%A{v2}"
    let _run_target_args'_v7 = v21 
    #endif
    let v22 : string = _run_target_args'_v7 
    method14(v4, v22)
    method32(v4)
    let v23 : string = v4.l0
    v23
and method47 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<Result<US10, anyhow_Error>>>>> =
    let v2 : string = "true; let __future_init = Box::pin(/*"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let v4 : string = "*/ async move { /*"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let v6 : string = "*/ ()"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let v8 : string = "near_workspaces::sandbox().await"
    let v9 : Result<near_workspaces_Worker<near_workspaces_network_Sandbox>, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v8 
    let v10 : string = "$0?"
    let v11 : near_workspaces_Worker<near_workspaces_network_Sandbox> = Fable.Core.RustInterop.emitRustExpr v9 v10 
    let v12 : string = "$0"
    let v13 : near_workspaces_Worker<near_workspaces_network_Sandbox> = Fable.Core.RustInterop.emitRustExpr v11 v12 
    let v14 : string = "Box::pin(v13.dev_deploy(&$0))"
    let v15 : std_pin_Pin<Box<Dyn<std_future_Future<Result<near_workspaces_Contract, near_workspaces_error_Error>>>>> = Fable.Core.RustInterop.emitRustExpr v0 v14 
    let v16 : string = "v15.await"
    let v17 : Result<near_workspaces_Contract, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v16 
    let v18 : string = "$0?"
    let v19 : near_workspaces_Contract = Fable.Core.RustInterop.emitRustExpr v17 v18 
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure24(v1, v11, v19)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v276 : string = "$0.call(&*$1)"
    let v277 : string = "state_main"
    let v278 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr struct (v19, v277) v276 
    let v283 : string = "near_workspaces::types::Gas::from_tgas(300)"
    let v284 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr () v283 
    let v295 : string = "v278.gas(v284)"
    let v296 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr () v295 
    let v297 : string = "Box::pin(v296.transact())"
    let v298 : std_pin_Pin<Box<Dyn<std_future_Future<Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v297 
    let v299 : string = "v298.await"
    let v300 : Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v299 
    let v301 : string = "$0?"
    let v302 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v300 v301 
    let v402 : unit = ()
    let v403 : (unit -> unit) = closure25(v1, v302)
    let v404 : unit = (fun () -> v403 (); v402) ()
    let v559 : string = "v302.logs()"
    let v560 : Vec<Ref<Str>> = Fable.Core.RustInterop.emitRustExpr () v559 
    let v561 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v562 : bool = Fable.Core.RustInterop.emitRustExpr v560 v561 
    let v563 : string = "x"
    let v564 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v563 
    (* run_target_args'
    let v565 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v566 : string = "String::from($0)"
    let v567 : std_string_String = Fable.Core.RustInterop.emitRustExpr v564 v566 
    let _run_target_args'_v565 = v567 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v568 : string = "String::from($0)"
    let v569 : std_string_String = Fable.Core.RustInterop.emitRustExpr v564 v568 
    let _run_target_args'_v565 = v569 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v570 : string = "String::from($0)"
    let v571 : std_string_String = Fable.Core.RustInterop.emitRustExpr v564 v570 
    let _run_target_args'_v565 = v571 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v572 : std_string_String = v564 |> unbox<std_string_String>
    let _run_target_args'_v565 = v572 
    #endif
#else
    let v573 : std_string_String = v564 |> unbox<std_string_String>
    let _run_target_args'_v565 = v573 
    #endif
    let v574 : std_string_String = _run_target_args'_v565 
    let v575 : string = "true; $0 }).collect::<Vec<_>>()"
    let v576 : bool = Fable.Core.RustInterop.emitRustExpr v574 v575 
    let v577 : string = "_vec_map"
    let v578 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v577 
    let v579 : string = "true; $0.iter().for_each(|x| { $1(x.clone()); }); //"
    let v580 : (std_string_String -> unit) = closure26()
    let v581 : bool = Fable.Core.RustInterop.emitRustExpr struct (v578, v580) v579 
    let v662 : unit = ()
    let v663 : (unit -> unit) = closure28()
    let v664 : unit = (fun () -> v663 (); v662) ()
    let v791 : string = "$0.total_gas_burnt"
    let v792 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v302 v791 
    let v793 : string = "$0.as_gas()"
    let v794 : uint64 = Fable.Core.RustInterop.emitRustExpr v792 v793 
    let v854 : (uint64 -> float) = float
    let v855 : float = v854 v794
    let v863 : float = v855 / 10000000000000000.0
    let v864 : float = v863 * 6.68
    let v964 : unit = ()
    let v965 : (unit -> unit) = closure29(v1, v794, v864)
    let v966 : unit = (fun () -> v965 (); v964) ()
    let v1121 : string = "$0"
    let v1122 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v302 v1121 
    let v1123 : string = "v1122.outcomes()"
    let v1124 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v1123 
    let v1125 : string = "v1124.into_iter()"
    let v1126 : _ = Fable.Core.RustInterop.emitRustExpr () v1125 
    let v1127 : string = "v1126.cloned()"
    let v1128 : _ = Fable.Core.RustInterop.emitRustExpr () v1127 
    let v1129 : string = "true; v1128.for_each(|x| $0(x))"
    let v1130 : (near_workspaces_result_ExecutionOutcome -> unit) = closure30()
    let v1131 : bool = Fable.Core.RustInterop.emitRustExpr v1130 v1129 
    let v1132 : string = "$0.into_result()"
    let v1133 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure> = Fable.Core.RustInterop.emitRustExpr v302 v1132 
    let v1233 : unit = ()
    let v1234 : (unit -> unit) = closure32(v1133)
    let v1235 : unit = (fun () -> v1234 (); v1233) ()
    let v1390 : near_workspaces_result_ExecutionFinalResult = method72(v302)
    let v1391 : string = "v1390.receipt_failures()"
    let v1392 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v1391 
    let v1397 : string = "$0.len()"
    let v1398 : unativeint = Fable.Core.RustInterop.emitRustExpr v1392 v1397 
    let v1540 : US16 = method73(v1398)
    let v1546 : US17 =
        match v1540 with
        | US16_1(v1543) -> (* Error *)
            US17_1
        | US16_0(v1541) -> (* Ok *)
            US17_0(v1541)
    let v1550 : int32 =
        match v1546 with
        | US17_1 -> (* None *)
            failwith<int32> "Option does not have a value."
        | US17_0(v1547) -> (* Some *)
            v1547
    let v1671 : unit = ()
    let v1672 : (unit -> unit) = closure36(v1392, v1550)
    let v1673 : unit = (fun () -> v1672 (); v1671) ()
    let v1828 : near_workspaces_result_ExecutionFinalResult = method78(v302)
    let v1829 : string = "v1828.receipt_outcomes()"
    let v1830 : Ref<Slice<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v1829 
    let v1831 : string = "v1830.into()"
    let v1832 : Vec<near_workspaces_result_ExecutionOutcome> = Fable.Core.RustInterop.emitRustExpr () v1831 
    let v1837 : string = "$0.len()"
    let v1838 : unativeint = Fable.Core.RustInterop.emitRustExpr v1832 v1837 
    let v1848 : US16 = method73(v1838)
    let v1854 : US17 =
        match v1848 with
        | US16_1(v1851) -> (* Error *)
            US17_1
        | US16_0(v1849) -> (* Ok *)
            US17_0(v1849)
    let v1858 : int32 =
        match v1854 with
        | US17_1 -> (* None *)
            failwith<int32> "Option does not have a value."
        | US17_0(v1855) -> (* Some *)
            v1855
    let v1958 : unit = ()
    let v1959 : (unit -> unit) = closure37(v1832, v1858)
    let v1960 : unit = (fun () -> v1959 (); v1958) ()
    let v2117 : string = "$0.json()"
    let v2118 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v302 v2117 
    let v2218 : unit = ()
    let v2219 : (unit -> unit) = closure38(v2118)
    let v2220 : unit = (fun () -> v2219 (); v2218) ()
    let v2375 : string = "$0.borsh()"
    let v2376 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v302 v2375 
    let v2476 : unit = ()
    let v2477 : (unit -> unit) = closure39(v2376)
    let v2478 : unit = (fun () -> v2477 (); v2476) ()
    let v2633 : string = method89(v1858, v1, v1392)
    let v2634 : bool = v1550 > 0
    let v2723 : Result<US10, anyhow_Error> =
        if v2634 then
            let v2639 : US10 = US10_0(v2633)
            let v2640 : Result<US10, anyhow_Error> = Ok v2639 
            v2640
        else
            let v2672 : bool = v1858 > 1
            if v2672 then
                let v2677 : US10 = US10_1
                let v2678 : Result<US10, anyhow_Error> = Ok v2677 
                v2678
            else
                let v2692 : string = "anyhow::anyhow!($0)"
                let v2693 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v2633 v2692 
                (* run_target_args'
                let v2706 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2707 : string = "Err($0)"
                let v2708 : Result<US10, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v2693 v2707 
                let _run_target_args'_v2706 = v2708 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2709 : string = "Err($0)"
                let v2710 : Result<US10, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v2693 v2709 
                let _run_target_args'_v2706 = v2710 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2711 : string = "Err($0)"
                let v2712 : Result<US10, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v2693 v2711 
                let _run_target_args'_v2706 = v2712 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2713 : Result<US10, anyhow_Error> = v2693 |> Error
                let _run_target_args'_v2706 = v2713 
                #endif
#else
                let v2714 : Result<US10, anyhow_Error> = v2693 |> Error
                let _run_target_args'_v2706 = v2714 
                #endif
                let v2715 : Result<US10, anyhow_Error> = _run_target_args'_v2706 
                v2715
    let v2748 : string = ""
    let v2749 : string = "}"
    let v2750 : string = v2748 + v2749 
    let x = v2723 //
    let v2751 : _ = x
    let v2752 : unit = ()
    (* run_target_args'
    let v2753 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2754 : string = $"true; let _fix_closure_v2752 = $0"
    let v2755 : bool = Fable.Core.RustInterop.emitRustExpr v2751 v2754 
    let _run_target_args'_v2753 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2756 : string = $"true; let _fix_closure_v2752 = $0"
    let v2757 : bool = Fable.Core.RustInterop.emitRustExpr v2751 v2756 
    let _run_target_args'_v2753 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2758 : string = $"true; let _fix_closure_v2752 = $0"
    let v2759 : bool = Fable.Core.RustInterop.emitRustExpr v2751 v2758 
    let _run_target_args'_v2753 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v2753 = false 
    #endif
#else
    let _run_target_args'_v2753 = false 
    #endif
    let v2760 : bool = _run_target_args'_v2753 
    let v2761 : string = $"true; _fix_closure_v2752 " + v2750 + "); " + v2748 + " // rust.fix_closure'"
    let v2762 : bool = Fable.Core.RustInterop.emitRustExpr () v2761 
    let v2784 : string = "__future_init"
    let v2785 : _ = Fable.Core.RustInterop.emitRustExpr () v2784 
    let v2786 : string = "v2785"
    let v2787 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US10, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v2786 
    v2787
and closure40 () (v0 : anyhow_Error) : std_string_String =
    (* run_target_args'
    let v23 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v24 : string = "format!(\"{}\", $0)"
    let v25 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v24 
    let _run_target_args'_v23 = v25 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v26 : string = "format!(\"{}\", $0)"
    let v27 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v26 
    let _run_target_args'_v23 = v27 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v28 : string = "format!(\"{}\", $0)"
    let v29 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v28 
    let _run_target_args'_v23 = v29 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v30 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v23 = v30 
    #endif
#else
    let v31 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v23 = v31 
    #endif
    let v32 : std_string_String = _run_target_args'_v23 
    v32
and method90 () : (anyhow_Error -> std_string_String) =
    closure40()
and closure41 () (v0 : US10) : US18 =
    US18_0(v0)
and method91 () : (US10 -> US18) =
    closure41()
and closure42 () (v0 : std_string_String) : US18 =
    US18_1(v0)
and method92 () : (std_string_String -> US18) =
    closure42()
and method93 () : string =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1 : string = "inline_colorization::color_yellow"
    let v2 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1 
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "String::from($0)"
    let v5 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v4 
    let _run_target_args'_v3 = v5 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : string = "String::from($0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : string = "String::from($0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let _run_target_args'_v3 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : std_string_String = v2 |> unbox<std_string_String>
    let _run_target_args'_v3 = v10 
    #endif
#else
    let v11 : std_string_String = v2 |> unbox<std_string_String>
    let _run_target_args'_v3 = v11 
    #endif
    let v12 : std_string_String = _run_target_args'_v3 
    let v13 : string = "fable_library_rust::String_::fromString($0)"
    let v14 : string = Fable.Core.RustInterop.emitRustExpr v12 v13 
    let _run_target_args'_v0 = v14 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v15 : string = "inline_colorization::color_yellow"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v15 
    (* run_target_args'
    let v17 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v18 : string = "String::from($0)"
    let v19 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v18 
    let _run_target_args'_v17 = v19 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v20 : string = "String::from($0)"
    let v21 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v20 
    let _run_target_args'_v17 = v21 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v22 : string = "String::from($0)"
    let v23 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v22 
    let _run_target_args'_v17 = v23 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v24 : std_string_String = v16 |> unbox<std_string_String>
    let _run_target_args'_v17 = v24 
    #endif
#else
    let v25 : std_string_String = v16 |> unbox<std_string_String>
    let _run_target_args'_v17 = v25 
    #endif
    let v26 : std_string_String = _run_target_args'_v17 
    let v27 : string = "fable_library_rust::String_::fromString($0)"
    let v28 : string = Fable.Core.RustInterop.emitRustExpr v26 v27 
    let _run_target_args'_v0 = v28 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v29 : string = "inline_colorization::color_yellow"
    let v30 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v29 
    (* run_target_args'
    let v31 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v32 : string = "String::from($0)"
    let v33 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v32 
    let _run_target_args'_v31 = v33 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v34 : string = "String::from($0)"
    let v35 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v34 
    let _run_target_args'_v31 = v35 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v36 : string = "String::from($0)"
    let v37 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v36 
    let _run_target_args'_v31 = v37 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v38 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v31 = v38 
    #endif
#else
    let v39 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v31 = v39 
    #endif
    let v40 : std_string_String = _run_target_args'_v31 
    let v41 : string = "fable_library_rust::String_::fromString($0)"
    let v42 : string = Fable.Core.RustInterop.emitRustExpr v40 v41 
    let _run_target_args'_v0 = v42 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v43 : string = "\u001b[93m"
    let _run_target_args'_v0 = v43 
    #endif
#else
    let v44 : string = "\u001b[93m"
    let _run_target_args'_v0 = v44 
    #endif
    let v45 : string = _run_target_args'_v0 
    
    
    
    
    
    let v46 : string = "Warning"
    let v47 : (unit -> string) = v46.ToLower
    let v48 : string = v47 ()
    let v49 : char = v48.[int 0]
    let v50 : string = method25(v49)
    let v51 : string = v45 + v50 
    (* run_target_args'
    let v52 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v53 : string = "inline_colorization::color_reset"
    let v54 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v53 
    (* run_target_args'
    let v55 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v56 : string = "String::from($0)"
    let v57 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v56 
    let _run_target_args'_v55 = v57 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v58 : string = "String::from($0)"
    let v59 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v58 
    let _run_target_args'_v55 = v59 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v60 : string = "String::from($0)"
    let v61 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v60 
    let _run_target_args'_v55 = v61 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v62 : std_string_String = v54 |> unbox<std_string_String>
    let _run_target_args'_v55 = v62 
    #endif
#else
    let v63 : std_string_String = v54 |> unbox<std_string_String>
    let _run_target_args'_v55 = v63 
    #endif
    let v64 : std_string_String = _run_target_args'_v55 
    let v65 : string = "fable_library_rust::String_::fromString($0)"
    let v66 : string = Fable.Core.RustInterop.emitRustExpr v64 v65 
    let _run_target_args'_v52 = v66 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v67 : string = "inline_colorization::color_reset"
    let v68 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v67 
    (* run_target_args'
    let v69 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v70 : string = "String::from($0)"
    let v71 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v70 
    let _run_target_args'_v69 = v71 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v72 : string = "String::from($0)"
    let v73 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v72 
    let _run_target_args'_v69 = v73 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v74 : string = "String::from($0)"
    let v75 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v74 
    let _run_target_args'_v69 = v75 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v76 : std_string_String = v68 |> unbox<std_string_String>
    let _run_target_args'_v69 = v76 
    #endif
#else
    let v77 : std_string_String = v68 |> unbox<std_string_String>
    let _run_target_args'_v69 = v77 
    #endif
    let v78 : std_string_String = _run_target_args'_v69 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v52 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "inline_colorization::color_reset"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v81 
    (* run_target_args'
    let v83 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v84 : string = "String::from($0)"
    let v85 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v84 
    let _run_target_args'_v83 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "String::from($0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v86 
    let _run_target_args'_v83 = v87 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v88 : string = "String::from($0)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v88 
    let _run_target_args'_v83 = v89 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : std_string_String = v82 |> unbox<std_string_String>
    let _run_target_args'_v83 = v90 
    #endif
#else
    let v91 : std_string_String = v82 |> unbox<std_string_String>
    let _run_target_args'_v83 = v91 
    #endif
    let v92 : std_string_String = _run_target_args'_v83 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v52 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v95 : string = "\u001b[0m"
    let _run_target_args'_v52 = v95 
    #endif
#else
    let v96 : string = "\u001b[0m"
    let _run_target_args'_v52 = v96 
    #endif
    let v97 : string = _run_target_args'_v52 
    let v98 : string = v51 + v97 
    v98
and method96 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "error"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method95 (v0 : uint8, v1 : std_string_String) : string =
    let v2 : string = method13()
    let v3 : Mut4 = {l0 = v2} : Mut4
    method29(v3)
    method50(v3)
    method31(v3)
    let v4 : string = $"{v0}"
    method14(v3, v4)
    method51(v3)
    method96(v3)
    method31(v3)
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = "format!(\"{:#?}\", $0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v6 
    let v8 : string = "fable_library_rust::String_::fromString($0)"
    let v9 : string = Fable.Core.RustInterop.emitRustExpr v7 v8 
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v10 : string = "format!(\"{:#?}\", $0)"
    let v11 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v10 
    let v12 : string = "fable_library_rust::String_::fromString($0)"
    let v13 : string = Fable.Core.RustInterop.emitRustExpr v11 v12 
    let _run_target_args'_v5 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v14 : string = "format!(\"{:#?}\", $0)"
    let v15 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v14 
    let v16 : string = "fable_library_rust::String_::fromString($0)"
    let v17 : string = Fable.Core.RustInterop.emitRustExpr v15 v16 
    let _run_target_args'_v5 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : string = $"%A{v1}"
    let _run_target_args'_v5 = v18 
    #endif
#else
    let v19 : string = $"%A{v1}"
    let _run_target_args'_v5 = v19 
    #endif
    let v20 : string = _run_target_args'_v5 
    method14(v3, v20)
    method32(v3)
    let v21 : string = v3.l0
    v21
and method94 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : std_string_String) : string =
    let v10 : int64 = v0.l0
    let v11 : string = " "
    let v12 : string = v6 + v11 
    let v13 : string = method27(v10)
    let v14 : string = v12 + v13 
    let v15 : string = v14 + v7 
    let v16 : string = v15 + v11 
    let v17 : string = "spiral_wasm.run / Error error"
    let v18 : string = v16 + v17 
    let v19 : string = " / "
    let v20 : string = v18 + v19 
    let v21 : string = method95(v8, v9)
    let v22 : string = v20 + v21 
    method33(v22)
and closure43 (v0 : uint8, v1 : std_string_String) () : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure17()
    let v4 : unit = (fun () -> v3 (); v2) ()
    let struct (v5 : Mut1, v6 : Mut2, v7 : Mut3, v8 : Mut4, v9 : Mut5, v10 : int64 option) = TraceState.trace_state.Value
    let v11 : US5 = v9.l0
    let v16 : int32 =
        match v11 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v17 : bool = v7.l0
    let v18 : bool = v17 = false
    let v20 : bool =
        if v18 then
            false
        else
            let v19 : bool = 40 >= v16
            v19
    let v21 : bool = v20 = false
    let v103 : US14 =
        if v21 then
            US14_1
        else
            let v23 : unit = ()
            let v24 : unit = (fun () -> v3 (); v23) ()
            let struct (v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : Mut5, v30 : int64 option) = TraceState.trace_state.Value
            let v31 : string = method20(v25, v26, v27, v28, v29, v30)
            let v32 : string = method93()
            let v33 : string = method94(v25, v26, v27, v28, v29, v30, v31, v32, v0, v1)
            let v34 : unit = ()
            let v35 : unit = (fun () -> v3 (); v34) ()
            let struct (v36 : Mut1, v37 : Mut2, v38 : Mut3, v39 : Mut4, v40 : Mut5, v41 : int64 option) = TraceState.trace_state.Value
            let v42 : unit = ()
            let v43 : (unit -> unit) = closure19(v36)
            let v44 : unit = (fun () -> v43 (); v42) ()
            let v45 : (string -> unit) = closure20()
            (* run_target_args'
            let v46 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v47 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v48 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v48 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v49 : string = v39.l0
            let v50 : bool = v49 = ""
            let v58 : string =
                if v50 then
                    v33
                else
                    let v51 : bool = v33 = ""
                    if v51 then
                        let v52 : string = v39.l0
                        v52
                    else
                        let v53 : string = v39.l0
                        let v54 : string = "\n"
                        let v55 : string = v53 + v54 
                        let v56 : string = v55 + v33 
                        v56
            (* run_target_args'
            let v59 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v60 : string = "&*$0"
            let v61 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v60 
            let _run_target_args'_v59 = v61 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v62 : string = "&*$0"
            let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v62 
            let _run_target_args'_v59 = v63 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v64 : string = "&*$0"
            let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v64 
            let _run_target_args'_v59 = v65 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v66 
            #endif
#else
            let v67 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v67 
            #endif
            let v68 : Ref<Str> = _run_target_args'_v59 
            let v69 : string = $"$0.chars()"
            let v70 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v68 v69 
            let v71 : string = "$0"
            let v72 : _ = Fable.Core.RustInterop.emitRustExpr v70 v71 
            let v73 : string = "$0.collect::<Vec<_>>()"
            let v74 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v72 v73 
            let v75 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v76 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v74 v75 
            let v77 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v78 : bool = Fable.Core.RustInterop.emitRustExpr v76 v77 
            let v79 : string = "x"
            let v80 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v79 
            let v81 : string = "String::from_iter($0)"
            let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v80 v81 
            let v83 : string = "true; $0 }).collect::<Vec<_>>()"
            let v84 : bool = Fable.Core.RustInterop.emitRustExpr v82 v83 
            let v85 : string = "_vec_map"
            let v86 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v85 
            let v87 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v88 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v86 v87 
            let v89 : int32 = v88.Length
            let v90 : string = ""
            let v91 : bool = v33 <> v90 
            let v93 : bool =
                if v91 then
                    let v92 : bool = v89 <= 1
                    v92
                else
                    false
            if v93 then
                v39.l0 <- v58
                ()
            else
                v39.l0 <- v90
                let v94 : Mut6 = {l0 = 0} : Mut6
                while method36(v89, v94) do
                    let v96 : int32 = v94.l0
                    let v97 : std_string_String = v88.[int v96]
                    let v98 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v99 : bool = Fable.Core.RustInterop.emitRustExpr v97 v98 
                    let v100 : int32 = v96 + 1
                    v94.l0 <- v100
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v45 v33
            #endif
#else
            v45 v33
            #endif
            // run_target_args' is_unit
            let v101 : (string -> unit) = v37.l0
            v101 v33
            US14_0(v36, v37, v38, v39, v40, v41)
    ()
and closure44 () () : unit =
    let v0 : unit = ()
    let v1 : (unit -> unit) = closure17()
    let v2 : unit = (fun () -> v1 (); v0) ()
    let struct (v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : Mut5, v8 : int64 option) = TraceState.trace_state.Value
    let v9 : US5 = v7.l0
    let v14 : int32 =
        match v9 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v15 : bool = v5.l0
    let v16 : bool = v15 = false
    let v18 : bool =
        if v16 then
            false
        else
            let v17 : bool = 40 >= v14
            v17
    let v19 : bool = v18 = false
    let v90 : US14 =
        if v19 then
            US14_1
        else
            let v21 : unit = ()
            let v22 : unit = (fun () -> v1 (); v21) ()
            let struct (v23 : Mut1, v24 : Mut2, v25 : Mut3, v26 : Mut4, v27 : Mut5, v28 : int64 option) = TraceState.trace_state.Value
            let v29 : unit = ()
            let v30 : (unit -> unit) = closure19(v23)
            let v31 : unit = (fun () -> v30 (); v29) ()
            let v32 : string = "\n"
            let v33 : (string -> unit) = closure20()
            (* run_target_args'
            let v34 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v35 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v35 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v36 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v36 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v37 : string = v26.l0
            let v38 : bool = v37 = ""
            let v45 : string =
                if v38 then
                    v32
                else
                    let v39 : bool = v32 = ""
                    if v39 then
                        let v40 : string = v26.l0
                        v40
                    else
                        let v41 : string = v26.l0
                        let v42 : string = v41 + v32 
                        let v43 : string = v42 + v32 
                        v43
            (* run_target_args'
            let v46 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v47 : string = "&*$0"
            let v48 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v45 v47 
            let _run_target_args'_v46 = v48 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v49 : string = "&*$0"
            let v50 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v45 v49 
            let _run_target_args'_v46 = v50 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v51 : string = "&*$0"
            let v52 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v45 v51 
            let _run_target_args'_v46 = v52 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v53 : Ref<Str> = v45 |> unbox<Ref<Str>>
            let _run_target_args'_v46 = v53 
            #endif
#else
            let v54 : Ref<Str> = v45 |> unbox<Ref<Str>>
            let _run_target_args'_v46 = v54 
            #endif
            let v55 : Ref<Str> = _run_target_args'_v46 
            let v56 : string = $"$0.chars()"
            let v57 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v55 v56 
            let v58 : string = "$0"
            let v59 : _ = Fable.Core.RustInterop.emitRustExpr v57 v58 
            let v60 : string = "$0.collect::<Vec<_>>()"
            let v61 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v59 v60 
            let v62 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v63 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v61 v62 
            let v64 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v65 : bool = Fable.Core.RustInterop.emitRustExpr v63 v64 
            let v66 : string = "x"
            let v67 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v66 
            let v68 : string = "String::from_iter($0)"
            let v69 : std_string_String = Fable.Core.RustInterop.emitRustExpr v67 v68 
            let v70 : string = "true; $0 }).collect::<Vec<_>>()"
            let v71 : bool = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "_vec_map"
            let v73 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v72 
            let v74 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v75 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : int32 = v75.Length
            let v77 : string = ""
            let v78 : bool = v32 <> v77 
            let v80 : bool =
                if v78 then
                    let v79 : bool = v76 <= 1
                    v79
                else
                    false
            if v80 then
                v26.l0 <- v45
                ()
            else
                v26.l0 <- v77
                let v81 : Mut6 = {l0 = 0} : Mut6
                while method36(v76, v81) do
                    let v83 : int32 = v81.l0
                    let v84 : std_string_String = v75.[int v83]
                    let v85 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v86 : bool = Fable.Core.RustInterop.emitRustExpr v84 v85 
                    let v87 : int32 = v83 + 1
                    v81.l0 <- v87
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v33 v32
            #endif
#else
            v33 v32
            #endif
            // run_target_args' is_unit
            let v88 : (string -> unit) = v24.l0
            v88 v32
            US14_0(v23, v24, v25, v26, v27, v28)
    ()
and closure45 (v0 : uint8, v1 : std_string_String) () : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure17()
    let v4 : unit = (fun () -> v3 (); v2) ()
    let struct (v5 : Mut1, v6 : Mut2, v7 : Mut3, v8 : Mut4, v9 : Mut5, v10 : int64 option) = TraceState.trace_state.Value
    let v11 : US5 = v9.l0
    let v16 : int32 =
        match v11 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v17 : bool = v7.l0
    let v18 : bool = v17 = false
    let v20 : bool =
        if v18 then
            false
        else
            let v19 : bool = 40 >= v16
            v19
    let v21 : bool = v20 = false
    let v103 : US14 =
        if v21 then
            US14_1
        else
            let v23 : unit = ()
            let v24 : unit = (fun () -> v3 (); v23) ()
            let struct (v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : Mut5, v30 : int64 option) = TraceState.trace_state.Value
            let v31 : string = method20(v25, v26, v27, v28, v29, v30)
            let v32 : string = method93()
            let v33 : string = method94(v25, v26, v27, v28, v29, v30, v31, v32, v0, v1)
            let v34 : unit = ()
            let v35 : unit = (fun () -> v3 (); v34) ()
            let struct (v36 : Mut1, v37 : Mut2, v38 : Mut3, v39 : Mut4, v40 : Mut5, v41 : int64 option) = TraceState.trace_state.Value
            let v42 : unit = ()
            let v43 : (unit -> unit) = closure19(v36)
            let v44 : unit = (fun () -> v43 (); v42) ()
            let v45 : (string -> unit) = closure20()
            (* run_target_args'
            let v46 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v47 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v48 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v48 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v49 : string = v39.l0
            let v50 : bool = v49 = ""
            let v58 : string =
                if v50 then
                    v33
                else
                    let v51 : bool = v33 = ""
                    if v51 then
                        let v52 : string = v39.l0
                        v52
                    else
                        let v53 : string = v39.l0
                        let v54 : string = "\n"
                        let v55 : string = v53 + v54 
                        let v56 : string = v55 + v33 
                        v56
            (* run_target_args'
            let v59 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v60 : string = "&*$0"
            let v61 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v60 
            let _run_target_args'_v59 = v61 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v62 : string = "&*$0"
            let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v62 
            let _run_target_args'_v59 = v63 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v64 : string = "&*$0"
            let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v64 
            let _run_target_args'_v59 = v65 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v66 
            #endif
#else
            let v67 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v67 
            #endif
            let v68 : Ref<Str> = _run_target_args'_v59 
            let v69 : string = $"$0.chars()"
            let v70 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v68 v69 
            let v71 : string = "$0"
            let v72 : _ = Fable.Core.RustInterop.emitRustExpr v70 v71 
            let v73 : string = "$0.collect::<Vec<_>>()"
            let v74 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v72 v73 
            let v75 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v76 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v74 v75 
            let v77 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v78 : bool = Fable.Core.RustInterop.emitRustExpr v76 v77 
            let v79 : string = "x"
            let v80 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v79 
            let v81 : string = "String::from_iter($0)"
            let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v80 v81 
            let v83 : string = "true; $0 }).collect::<Vec<_>>()"
            let v84 : bool = Fable.Core.RustInterop.emitRustExpr v82 v83 
            let v85 : string = "_vec_map"
            let v86 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v85 
            let v87 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v88 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v86 v87 
            let v89 : int32 = v88.Length
            let v90 : string = ""
            let v91 : bool = v33 <> v90 
            let v93 : bool =
                if v91 then
                    let v92 : bool = v89 <= 1
                    v92
                else
                    false
            if v93 then
                v39.l0 <- v58
                ()
            else
                v39.l0 <- v90
                let v94 : Mut6 = {l0 = 0} : Mut6
                while method36(v89, v94) do
                    let v96 : int32 = v94.l0
                    let v97 : std_string_String = v88.[int v96]
                    let v98 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v99 : bool = Fable.Core.RustInterop.emitRustExpr v97 v98 
                    let v100 : int32 = v96 + 1
                    v94.l0 <- v100
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v45 v33
            #endif
#else
            v45 v33
            #endif
            // run_target_args' is_unit
            let v101 : (string -> unit) = v37.l0
            v101 v33
            US14_0(v36, v37, v38, v39, v40, v41)
    ()
and closure46 () () : unit =
    let v0 : unit = ()
    let v1 : (unit -> unit) = closure17()
    let v2 : unit = (fun () -> v1 (); v0) ()
    let struct (v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : Mut5, v8 : int64 option) = TraceState.trace_state.Value
    let v9 : US5 = v7.l0
    let v14 : int32 =
        match v9 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v15 : bool = v5.l0
    let v16 : bool = v15 = false
    let v18 : bool =
        if v16 then
            false
        else
            let v17 : bool = 40 >= v14
            v17
    let v19 : bool = v18 = false
    let v90 : US14 =
        if v19 then
            US14_1
        else
            let v21 : unit = ()
            let v22 : unit = (fun () -> v1 (); v21) ()
            let struct (v23 : Mut1, v24 : Mut2, v25 : Mut3, v26 : Mut4, v27 : Mut5, v28 : int64 option) = TraceState.trace_state.Value
            let v29 : unit = ()
            let v30 : (unit -> unit) = closure19(v23)
            let v31 : unit = (fun () -> v30 (); v29) ()
            let v32 : string = "\n"
            let v33 : (string -> unit) = closure20()
            (* run_target_args'
            let v34 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v35 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v35 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v36 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v36 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v37 : string = v26.l0
            let v38 : bool = v37 = ""
            let v45 : string =
                if v38 then
                    v32
                else
                    let v39 : bool = v32 = ""
                    if v39 then
                        let v40 : string = v26.l0
                        v40
                    else
                        let v41 : string = v26.l0
                        let v42 : string = v41 + v32 
                        let v43 : string = v42 + v32 
                        v43
            (* run_target_args'
            let v46 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v47 : string = "&*$0"
            let v48 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v45 v47 
            let _run_target_args'_v46 = v48 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v49 : string = "&*$0"
            let v50 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v45 v49 
            let _run_target_args'_v46 = v50 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v51 : string = "&*$0"
            let v52 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v45 v51 
            let _run_target_args'_v46 = v52 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v53 : Ref<Str> = v45 |> unbox<Ref<Str>>
            let _run_target_args'_v46 = v53 
            #endif
#else
            let v54 : Ref<Str> = v45 |> unbox<Ref<Str>>
            let _run_target_args'_v46 = v54 
            #endif
            let v55 : Ref<Str> = _run_target_args'_v46 
            let v56 : string = $"$0.chars()"
            let v57 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v55 v56 
            let v58 : string = "$0"
            let v59 : _ = Fable.Core.RustInterop.emitRustExpr v57 v58 
            let v60 : string = "$0.collect::<Vec<_>>()"
            let v61 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v59 v60 
            let v62 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v63 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v61 v62 
            let v64 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v65 : bool = Fable.Core.RustInterop.emitRustExpr v63 v64 
            let v66 : string = "x"
            let v67 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v66 
            let v68 : string = "String::from_iter($0)"
            let v69 : std_string_String = Fable.Core.RustInterop.emitRustExpr v67 v68 
            let v70 : string = "true; $0 }).collect::<Vec<_>>()"
            let v71 : bool = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "_vec_map"
            let v73 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v72 
            let v74 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v75 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : int32 = v75.Length
            let v77 : string = ""
            let v78 : bool = v32 <> v77 
            let v80 : bool =
                if v78 then
                    let v79 : bool = v76 <= 1
                    v79
                else
                    false
            if v80 then
                v26.l0 <- v45
                ()
            else
                v26.l0 <- v77
                let v81 : Mut6 = {l0 = 0} : Mut6
                while method36(v76, v81) do
                    let v83 : int32 = v81.l0
                    let v84 : std_string_String = v75.[int v83]
                    let v85 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v86 : bool = Fable.Core.RustInterop.emitRustExpr v84 v85 
                    let v87 : int32 = v83 + 1
                    v81.l0 <- v87
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v33 v32
            #endif
#else
            v33 v32
            #endif
            // run_target_args' is_unit
            let v88 : (string -> unit) = v24.l0
            v88 v32
            US14_0(v23, v24, v25, v26, v27, v28)
    ()
and method97 () : string =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1 : string = "inline_colorization::color_bright_red"
    let v2 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1 
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "String::from($0)"
    let v5 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v4 
    let _run_target_args'_v3 = v5 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : string = "String::from($0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : string = "String::from($0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let _run_target_args'_v3 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : std_string_String = v2 |> unbox<std_string_String>
    let _run_target_args'_v3 = v10 
    #endif
#else
    let v11 : std_string_String = v2 |> unbox<std_string_String>
    let _run_target_args'_v3 = v11 
    #endif
    let v12 : std_string_String = _run_target_args'_v3 
    let v13 : string = "fable_library_rust::String_::fromString($0)"
    let v14 : string = Fable.Core.RustInterop.emitRustExpr v12 v13 
    let _run_target_args'_v0 = v14 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v15 : string = "inline_colorization::color_bright_red"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v15 
    (* run_target_args'
    let v17 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v18 : string = "String::from($0)"
    let v19 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v18 
    let _run_target_args'_v17 = v19 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v20 : string = "String::from($0)"
    let v21 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v20 
    let _run_target_args'_v17 = v21 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v22 : string = "String::from($0)"
    let v23 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v22 
    let _run_target_args'_v17 = v23 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v24 : std_string_String = v16 |> unbox<std_string_String>
    let _run_target_args'_v17 = v24 
    #endif
#else
    let v25 : std_string_String = v16 |> unbox<std_string_String>
    let _run_target_args'_v17 = v25 
    #endif
    let v26 : std_string_String = _run_target_args'_v17 
    let v27 : string = "fable_library_rust::String_::fromString($0)"
    let v28 : string = Fable.Core.RustInterop.emitRustExpr v26 v27 
    let _run_target_args'_v0 = v28 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v29 : string = "inline_colorization::color_bright_red"
    let v30 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v29 
    (* run_target_args'
    let v31 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v32 : string = "String::from($0)"
    let v33 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v32 
    let _run_target_args'_v31 = v33 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v34 : string = "String::from($0)"
    let v35 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v34 
    let _run_target_args'_v31 = v35 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v36 : string = "String::from($0)"
    let v37 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v36 
    let _run_target_args'_v31 = v37 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v38 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v31 = v38 
    #endif
#else
    let v39 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v31 = v39 
    #endif
    let v40 : std_string_String = _run_target_args'_v31 
    let v41 : string = "fable_library_rust::String_::fromString($0)"
    let v42 : string = Fable.Core.RustInterop.emitRustExpr v40 v41 
    let _run_target_args'_v0 = v42 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v43 : string = "\u001b[91m"
    let _run_target_args'_v0 = v43 
    #endif
#else
    let v44 : string = "\u001b[91m"
    let _run_target_args'_v0 = v44 
    #endif
    let v45 : string = _run_target_args'_v0 
    
    
    
    
    
    let v46 : string = "Critical"
    let v47 : (unit -> string) = v46.ToLower
    let v48 : string = v47 ()
    let v49 : char = v48.[int 0]
    let v50 : string = method25(v49)
    let v51 : string = v45 + v50 
    (* run_target_args'
    let v52 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v53 : string = "inline_colorization::color_reset"
    let v54 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v53 
    (* run_target_args'
    let v55 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v56 : string = "String::from($0)"
    let v57 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v56 
    let _run_target_args'_v55 = v57 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v58 : string = "String::from($0)"
    let v59 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v58 
    let _run_target_args'_v55 = v59 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v60 : string = "String::from($0)"
    let v61 : std_string_String = Fable.Core.RustInterop.emitRustExpr v54 v60 
    let _run_target_args'_v55 = v61 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v62 : std_string_String = v54 |> unbox<std_string_String>
    let _run_target_args'_v55 = v62 
    #endif
#else
    let v63 : std_string_String = v54 |> unbox<std_string_String>
    let _run_target_args'_v55 = v63 
    #endif
    let v64 : std_string_String = _run_target_args'_v55 
    let v65 : string = "fable_library_rust::String_::fromString($0)"
    let v66 : string = Fable.Core.RustInterop.emitRustExpr v64 v65 
    let _run_target_args'_v52 = v66 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v67 : string = "inline_colorization::color_reset"
    let v68 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v67 
    (* run_target_args'
    let v69 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v70 : string = "String::from($0)"
    let v71 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v70 
    let _run_target_args'_v69 = v71 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v72 : string = "String::from($0)"
    let v73 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v72 
    let _run_target_args'_v69 = v73 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v74 : string = "String::from($0)"
    let v75 : std_string_String = Fable.Core.RustInterop.emitRustExpr v68 v74 
    let _run_target_args'_v69 = v75 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v76 : std_string_String = v68 |> unbox<std_string_String>
    let _run_target_args'_v69 = v76 
    #endif
#else
    let v77 : std_string_String = v68 |> unbox<std_string_String>
    let _run_target_args'_v69 = v77 
    #endif
    let v78 : std_string_String = _run_target_args'_v69 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v52 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "inline_colorization::color_reset"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v81 
    (* run_target_args'
    let v83 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v84 : string = "String::from($0)"
    let v85 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v84 
    let _run_target_args'_v83 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "String::from($0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v86 
    let _run_target_args'_v83 = v87 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v88 : string = "String::from($0)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr v82 v88 
    let _run_target_args'_v83 = v89 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : std_string_String = v82 |> unbox<std_string_String>
    let _run_target_args'_v83 = v90 
    #endif
#else
    let v91 : std_string_String = v82 |> unbox<std_string_String>
    let _run_target_args'_v83 = v91 
    #endif
    let v92 : std_string_String = _run_target_args'_v83 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v52 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v95 : string = "\u001b[0m"
    let _run_target_args'_v52 = v95 
    #endif
#else
    let v96 : string = "\u001b[0m"
    let _run_target_args'_v52 = v96 
    #endif
    let v97 : string = _run_target_args'_v52 
    let v98 : string = v51 + v97 
    v98
and method99 (v0 : uint8, v1 : string) : string =
    let v2 : string = method13()
    let v3 : Mut4 = {l0 = v2} : Mut4
    method29(v3)
    method50(v3)
    method31(v3)
    let v4 : string = $"{v0}"
    method14(v3, v4)
    method51(v3)
    method96(v3)
    method31(v3)
    method14(v3, v1)
    method32(v3)
    let v5 : string = v3.l0
    v5
and method98 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : string) : string =
    let v10 : int64 = v0.l0
    let v11 : string = " "
    let v12 : string = v6 + v11 
    let v13 : string = method27(v10)
    let v14 : string = v12 + v13 
    let v15 : string = v14 + v7 
    let v16 : string = v15 + v11 
    let v17 : string = "spiral_wasm.run / Ok (Some error)"
    let v18 : string = v16 + v17 
    let v19 : string = " / "
    let v20 : string = v18 + v19 
    let v21 : string = method99(v8, v9)
    let v22 : string = v20 + v21 
    method33(v22)
and closure47 (v0 : uint8, v1 : string) () : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure17()
    let v4 : unit = (fun () -> v3 (); v2) ()
    let struct (v5 : Mut1, v6 : Mut2, v7 : Mut3, v8 : Mut4, v9 : Mut5, v10 : int64 option) = TraceState.trace_state.Value
    let v11 : US5 = v9.l0
    let v16 : int32 =
        match v11 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v17 : bool = v7.l0
    let v18 : bool = v17 = false
    let v20 : bool =
        if v18 then
            false
        else
            let v19 : bool = 50 >= v16
            v19
    let v21 : bool = v20 = false
    let v103 : US14 =
        if v21 then
            US14_1
        else
            let v23 : unit = ()
            let v24 : unit = (fun () -> v3 (); v23) ()
            let struct (v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : Mut5, v30 : int64 option) = TraceState.trace_state.Value
            let v31 : string = method20(v25, v26, v27, v28, v29, v30)
            let v32 : string = method97()
            let v33 : string = method98(v25, v26, v27, v28, v29, v30, v31, v32, v0, v1)
            let v34 : unit = ()
            let v35 : unit = (fun () -> v3 (); v34) ()
            let struct (v36 : Mut1, v37 : Mut2, v38 : Mut3, v39 : Mut4, v40 : Mut5, v41 : int64 option) = TraceState.trace_state.Value
            let v42 : unit = ()
            let v43 : (unit -> unit) = closure19(v36)
            let v44 : unit = (fun () -> v43 (); v42) ()
            let v45 : (string -> unit) = closure20()
            (* run_target_args'
            let v46 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v47 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v48 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v33 v48 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v49 : string = v39.l0
            let v50 : bool = v49 = ""
            let v58 : string =
                if v50 then
                    v33
                else
                    let v51 : bool = v33 = ""
                    if v51 then
                        let v52 : string = v39.l0
                        v52
                    else
                        let v53 : string = v39.l0
                        let v54 : string = "\n"
                        let v55 : string = v53 + v54 
                        let v56 : string = v55 + v33 
                        v56
            (* run_target_args'
            let v59 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v60 : string = "&*$0"
            let v61 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v60 
            let _run_target_args'_v59 = v61 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v62 : string = "&*$0"
            let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v62 
            let _run_target_args'_v59 = v63 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v64 : string = "&*$0"
            let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v58 v64 
            let _run_target_args'_v59 = v65 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v66 
            #endif
#else
            let v67 : Ref<Str> = v58 |> unbox<Ref<Str>>
            let _run_target_args'_v59 = v67 
            #endif
            let v68 : Ref<Str> = _run_target_args'_v59 
            let v69 : string = $"$0.chars()"
            let v70 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v68 v69 
            let v71 : string = "$0"
            let v72 : _ = Fable.Core.RustInterop.emitRustExpr v70 v71 
            let v73 : string = "$0.collect::<Vec<_>>()"
            let v74 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v72 v73 
            let v75 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v76 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v74 v75 
            let v77 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v78 : bool = Fable.Core.RustInterop.emitRustExpr v76 v77 
            let v79 : string = "x"
            let v80 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v79 
            let v81 : string = "String::from_iter($0)"
            let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v80 v81 
            let v83 : string = "true; $0 }).collect::<Vec<_>>()"
            let v84 : bool = Fable.Core.RustInterop.emitRustExpr v82 v83 
            let v85 : string = "_vec_map"
            let v86 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v85 
            let v87 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v88 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v86 v87 
            let v89 : int32 = v88.Length
            let v90 : string = ""
            let v91 : bool = v33 <> v90 
            let v93 : bool =
                if v91 then
                    let v92 : bool = v89 <= 1
                    v92
                else
                    false
            if v93 then
                v39.l0 <- v58
                ()
            else
                v39.l0 <- v90
                let v94 : Mut6 = {l0 = 0} : Mut6
                while method36(v89, v94) do
                    let v96 : int32 = v94.l0
                    let v97 : std_string_String = v88.[int v96]
                    let v98 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v99 : bool = Fable.Core.RustInterop.emitRustExpr v97 v98 
                    let v100 : int32 = v96 + 1
                    v94.l0 <- v100
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v45 v33
            #endif
#else
            v45 v33
            #endif
            // run_target_args' is_unit
            let v101 : (string -> unit) = v37.l0
            v101 v33
            US14_0(v36, v37, v38, v39, v40, v41)
    ()
and method46 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<US15>>>> =
    let v2 : string = "true; let __future_init = Box::pin(/*"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let v4 : string = "*/ async move { /*"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let v6 : string = "*/ ()"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let v8 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US10, anyhow_Error>>>>> = method47(v0, v1)
    let v9 : string = "v8.await"
    let v10 : Result<US10, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr () v9 
    let v11 : (anyhow_Error -> std_string_String) = method90()
    (* run_target_args'
    let v14 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v15 : string = "$0.map_err(|x| $1(x))"
    let v16 : Result<US10, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v10, v11) v15 
    let _run_target_args'_v14 = v16 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v17 : string = "$0.map_err(|x| $1(x))"
    let v18 : Result<US10, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v10, v11) v17 
    let _run_target_args'_v14 = v18 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v19 : string = "$0.map_err(|x| $1(x))"
    let v20 : Result<US10, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v10, v11) v19 
    let _run_target_args'_v14 = v20 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : Result<US10, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v14 = v21 
    #endif
#else
    let v22 : Result<US10, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v14 = v22 
    #endif
    let v23 : Result<US10, std_string_String> = _run_target_args'_v14 
    let v30 : (US10 -> US18) = method91()
    let v31 : (std_string_String -> US18) = method92()
    let v34 : US18 = match v23 with Ok x -> v30 x | Error x -> v31 x
    let v1434 : US15 =
        match v34 with
        | US18_1(v468) -> (* Error *)
            let v469 : bool = v1 >= 15uy
            if v469 then
                let v569 : unit = ()
                let v570 : (unit -> unit) = closure43(v1, v468)
                let v571 : unit = (fun () -> v570 (); v569) ()
                let v806 : unit = ()
                let v807 : (unit -> unit) = closure44()
                let v808 : unit = (fun () -> v807 (); v806) ()
                let v934 : string = "true; let __future_init = Box::pin(/*"
                let v935 : bool = Fable.Core.RustInterop.emitRustExpr () v934 
                let v936 : string = "*/ async move { /*"
                let v937 : bool = Fable.Core.RustInterop.emitRustExpr () v936 
                let v938 : string = "*/ ()"
                let v939 : bool = Fable.Core.RustInterop.emitRustExpr () v938 
                let v940 : string = ""
                let v941 : string = "}"
                let v942 : string = v940 + v941 
                let v943 : US10 = US10_1
                let x = struct (v1, v943) //
                let v944 : _ = x
                let v945 : unit = ()
                (* run_target_args'
                let v946 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v947 : string = $"true; let _fix_closure_v945 = $0"
                let v948 : bool = Fable.Core.RustInterop.emitRustExpr v944 v947 
                let _run_target_args'_v946 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v949 : string = $"true; let _fix_closure_v945 = $0"
                let v950 : bool = Fable.Core.RustInterop.emitRustExpr v944 v949 
                let _run_target_args'_v946 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v951 : string = $"true; let _fix_closure_v945 = $0"
                let v952 : bool = Fable.Core.RustInterop.emitRustExpr v944 v951 
                let _run_target_args'_v946 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v946 = false 
                #endif
#else
                let _run_target_args'_v946 = false 
                #endif
                let v953 : bool = _run_target_args'_v946 
                let v954 : string = $"true; _fix_closure_v945 " + v942 + "); " + v940 + " // rust.fix_closure'"
                let v955 : bool = Fable.Core.RustInterop.emitRustExpr () v954 
                let v956 : string = "__future_init"
                let v957 : _ = Fable.Core.RustInterop.emitRustExpr () v956 
                let v958 : string = "v957"
                let v959 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US10)>>>> = Fable.Core.RustInterop.emitRustExpr () v958 
                let v960 : string = "v959.await"
                let struct (v961 : uint8, v962 : US10) = Fable.Core.RustInterop.emitRustExpr () v960 
                US15_0(v961, v962)
            else
                let v1063 : unit = ()
                let v1064 : (unit -> unit) = closure45(v1, v468)
                let v1065 : unit = (fun () -> v1064 (); v1063) ()
                let v1300 : unit = ()
                let v1301 : (unit -> unit) = closure46()
                let v1302 : unit = (fun () -> v1301 (); v1300) ()
                let v1428 : uint8 = v1 + 1uy
                let v1429 : std_pin_Pin<Box<Dyn<std_future_Future<US15>>>> = method46(v0, v1428)
                let v1430 : string = "v1429.await"
                let v1431 : US15 = Fable.Core.RustInterop.emitRustExpr () v1430 
                v1431
        | US18_0(v64) -> (* Ok *)
            match v64 with
            | US10_1 -> (* None *)
                let v65 : string = "true; let __future_init = Box::pin(/*"
                let v66 : bool = Fable.Core.RustInterop.emitRustExpr () v65 
                let v67 : string = "*/ async move { /*"
                let v68 : bool = Fable.Core.RustInterop.emitRustExpr () v67 
                let v69 : string = "*/ ()"
                let v70 : bool = Fable.Core.RustInterop.emitRustExpr () v69 
                let v87 : string = ""
                let v88 : string = "}"
                let v89 : string = v87 + v88 
                let v90 : US10 = US10_1
                let x = struct (v1, v90) //
                let v91 : _ = x
                let v92 : unit = ()
                (* run_target_args'
                let v93 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v94 : string = $"true; let _fix_closure_v92 = $0"
                let v95 : bool = Fable.Core.RustInterop.emitRustExpr v91 v94 
                let _run_target_args'_v93 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v96 : string = $"true; let _fix_closure_v92 = $0"
                let v97 : bool = Fable.Core.RustInterop.emitRustExpr v91 v96 
                let _run_target_args'_v93 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v98 : string = $"true; let _fix_closure_v92 = $0"
                let v99 : bool = Fable.Core.RustInterop.emitRustExpr v91 v98 
                let _run_target_args'_v93 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v93 = false 
                #endif
#else
                let _run_target_args'_v93 = false 
                #endif
                let v100 : bool = _run_target_args'_v93 
                let v101 : string = $"true; _fix_closure_v92 " + v89 + "); " + v87 + " // rust.fix_closure'"
                let v102 : bool = Fable.Core.RustInterop.emitRustExpr () v101 
                let v129 : string = "__future_init"
                let v130 : _ = Fable.Core.RustInterop.emitRustExpr () v129 
                let v131 : string = "v130"
                let v132 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US10)>>>> = Fable.Core.RustInterop.emitRustExpr () v131 
                let v133 : string = "v132.await"
                let struct (v134 : uint8, v135 : US10) = Fable.Core.RustInterop.emitRustExpr () v133 
                US15_0(v134, v135)
            | US10_0(v137) -> (* Some *)
                let v237 : unit = ()
                let v238 : (unit -> unit) = closure47(v1, v137)
                let v239 : unit = (fun () -> v238 (); v237) ()
                let v394 : string = "true; let __future_init = Box::pin(/*"
                let v395 : bool = Fable.Core.RustInterop.emitRustExpr () v394 
                let v396 : string = "*/ async move { /*"
                let v397 : bool = Fable.Core.RustInterop.emitRustExpr () v396 
                let v398 : string = "*/ ()"
                let v399 : bool = Fable.Core.RustInterop.emitRustExpr () v398 
                let v416 : string = ""
                let v417 : string = "}"
                let v418 : string = v416 + v417 
                let v419 : US10 = US10_0(v137)
                let x = struct (v1, v419) //
                let v420 : _ = x
                let v421 : unit = ()
                (* run_target_args'
                let v422 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v423 : string = $"true; let _fix_closure_v421 = $0"
                let v424 : bool = Fable.Core.RustInterop.emitRustExpr v420 v423 
                let _run_target_args'_v422 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v425 : string = $"true; let _fix_closure_v421 = $0"
                let v426 : bool = Fable.Core.RustInterop.emitRustExpr v420 v425 
                let _run_target_args'_v422 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v427 : string = $"true; let _fix_closure_v421 = $0"
                let v428 : bool = Fable.Core.RustInterop.emitRustExpr v420 v427 
                let _run_target_args'_v422 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v422 = false 
                #endif
#else
                let _run_target_args'_v422 = false 
                #endif
                let v429 : bool = _run_target_args'_v422 
                let v430 : string = $"true; _fix_closure_v421 " + v418 + "); " + v416 + " // rust.fix_closure'"
                let v431 : bool = Fable.Core.RustInterop.emitRustExpr () v430 
                let v458 : string = "__future_init"
                let v459 : _ = Fable.Core.RustInterop.emitRustExpr () v458 
                let v460 : string = "v459"
                let v461 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US10)>>>> = Fable.Core.RustInterop.emitRustExpr () v460 
                let v462 : string = "v461.await"
                let struct (v463 : uint8, v464 : US10) = Fable.Core.RustInterop.emitRustExpr () v462 
                US15_1(v463, v464)
    let v1449 : string = ""
    let v1450 : string = "}"
    let v1451 : string = v1449 + v1450 
    let x = v1434 //
    let v1452 : _ = x
    let v1453 : unit = ()
    (* run_target_args'
    let v1454 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1455 : string = $"true; let _fix_closure_v1453 = $0"
    let v1456 : bool = Fable.Core.RustInterop.emitRustExpr v1452 v1455 
    let _run_target_args'_v1454 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1457 : string = $"true; let _fix_closure_v1453 = $0"
    let v1458 : bool = Fable.Core.RustInterop.emitRustExpr v1452 v1457 
    let _run_target_args'_v1454 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1459 : string = $"true; let _fix_closure_v1453 = $0"
    let v1460 : bool = Fable.Core.RustInterop.emitRustExpr v1452 v1459 
    let _run_target_args'_v1454 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v1454 = false 
    #endif
#else
    let _run_target_args'_v1454 = false 
    #endif
    let v1461 : bool = _run_target_args'_v1454 
    let v1462 : string = $"true; _fix_closure_v1453 " + v1451 + "); " + v1449 + " // rust.fix_closure'"
    let v1463 : bool = Fable.Core.RustInterop.emitRustExpr () v1462 
    let v1485 : string = "__future_init"
    let v1486 : _ = Fable.Core.RustInterop.emitRustExpr () v1485 
    let v1487 : string = "v1486"
    let v1488 : std_pin_Pin<Box<Dyn<std_future_Future<US15>>>> = Fable.Core.RustInterop.emitRustExpr () v1487 
    v1488
and method102 (v0 : Mut4) : unit =
    let v1 : string = v0.l0
    let v2 : string = "retries"
    let v3 : string = v1 + v2 
    v0.l0 <- v3
    ()
and method101 (v0 : US15) : string =
    let v1 : string = method13()
    let v2 : Mut4 = {l0 = v1} : Mut4
    method29(v2)
    method102(v2)
    method31(v2)
    let v3 : string = $"%A{v0}"
    method14(v2, v3)
    method32(v2)
    let v4 : string = v2.l0
    v4
and method100 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : US15) : string =
    let v9 : int64 = v0.l0
    let v10 : string = " "
    let v11 : string = v6 + v10 
    let v12 : string = method27(v9)
    let v13 : string = v11 + v12 
    let v14 : string = v13 + v7 
    let v15 : string = v14 + v10 
    let v16 : string = "spiral_wasm.run"
    let v17 : string = v15 + v16 
    let v18 : string = " / "
    let v19 : string = v17 + v18 
    let v20 : string = method101(v8)
    let v21 : string = v19 + v20 
    method33(v21)
and closure48 (v0 : US15) () : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure17()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v4 : Mut1, v5 : Mut2, v6 : Mut3, v7 : Mut4, v8 : Mut5, v9 : int64 option) = TraceState.trace_state.Value
    let v10 : US5 = v8.l0
    let v15 : int32 =
        match v10 with
        | US5_4 -> (* Critical *)
            50
        | US5_1 -> (* Debug *)
            20
        | US5_2 -> (* Info *)
            30
        | US5_0 -> (* Verbose *)
            10
        | US5_3 -> (* Warning *)
            40
    let v16 : bool = v6.l0
    let v17 : bool = v16 = false
    let v19 : bool =
        if v17 then
            false
        else
            let v18 : bool = 10 >= v15
            v18
    let v20 : bool = v19 = false
    let v102 : US14 =
        if v20 then
            US14_1
        else
            let v22 : unit = ()
            let v23 : unit = (fun () -> v2 (); v22) ()
            let struct (v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : Mut5, v29 : int64 option) = TraceState.trace_state.Value
            let v30 : string = method20(v24, v25, v26, v27, v28, v29)
            let v31 : string = method24()
            let v32 : string = method100(v24, v25, v26, v27, v28, v29, v30, v31, v0)
            let v33 : unit = ()
            let v34 : unit = (fun () -> v2 (); v33) ()
            let struct (v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : Mut5, v40 : int64 option) = TraceState.trace_state.Value
            let v41 : unit = ()
            let v42 : (unit -> unit) = closure19(v35)
            let v43 : unit = (fun () -> v42 (); v41) ()
            let v44 : (string -> unit) = closure20()
            (* run_target_args'
            let v45 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v46 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v46 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v47 : string = "println!(\"{}\", $0)"
            Fable.Core.RustInterop.emitRustExpr v32 v47 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v48 : string = v38.l0
            let v49 : bool = v48 = ""
            let v57 : string =
                if v49 then
                    v32
                else
                    let v50 : bool = v32 = ""
                    if v50 then
                        let v51 : string = v38.l0
                        v51
                    else
                        let v52 : string = v38.l0
                        let v53 : string = "\n"
                        let v54 : string = v52 + v53 
                        let v55 : string = v54 + v32 
                        v55
            (* run_target_args'
            let v58 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v59 : string = "&*$0"
            let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v59 
            let _run_target_args'_v58 = v60 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : string = "&*$0"
            let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v61 
            let _run_target_args'_v58 = v62 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63 : string = "&*$0"
            let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v63 
            let _run_target_args'_v58 = v64 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v65 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v65 
            #endif
#else
            let v66 : Ref<Str> = v57 |> unbox<Ref<Str>>
            let _run_target_args'_v58 = v66 
            #endif
            let v67 : Ref<Str> = _run_target_args'_v58 
            let v68 : string = $"$0.chars()"
            let v69 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v67 v68 
            let v70 : string = "$0"
            let v71 : _ = Fable.Core.RustInterop.emitRustExpr v69 v70 
            let v72 : string = "$0.collect::<Vec<_>>()"
            let v73 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v71 v72 
            let v74 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v75 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v73 v74 
            let v76 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v77 : bool = Fable.Core.RustInterop.emitRustExpr v75 v76 
            let v78 : string = "x"
            let v79 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v78 
            let v80 : string = "String::from_iter($0)"
            let v81 : std_string_String = Fable.Core.RustInterop.emitRustExpr v79 v80 
            let v82 : string = "true; $0 }).collect::<Vec<_>>()"
            let v83 : bool = Fable.Core.RustInterop.emitRustExpr v81 v82 
            let v84 : string = "_vec_map"
            let v85 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v84 
            let v86 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v87 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v85 v86 
            let v88 : int32 = v87.Length
            let v89 : string = ""
            let v90 : bool = v32 <> v89 
            let v92 : bool =
                if v90 then
                    let v91 : bool = v88 <= 1
                    v91
                else
                    false
            if v92 then
                v38.l0 <- v57
                ()
            else
                v38.l0 <- v89
                let v93 : Mut6 = {l0 = 0} : Mut6
                while method36(v88, v93) do
                    let v95 : int32 = v93.l0
                    let v96 : std_string_String = v87.[int v95]
                    let v97 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v98 : bool = Fable.Core.RustInterop.emitRustExpr v96 v97 
                    let v99 : int32 = v95 + 1
                    v93.l0 <- v99
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v44 v32
            #endif
#else
            v44 v32
            #endif
            // run_target_args' is_unit
            let v100 : (string -> unit) = v36.l0
            v100 v32
            US14_0(v35, v36, v37, v38, v39, v40)
    ()
and method103 (v0 : US15, v1 : US10) : string =
    let v2 : string = method13()
    let v3 : Mut4 = {l0 = v2} : Mut4
    method29(v3)
    method102(v3)
    method31(v3)
    let v4 : string = $"%A{v0}"
    method14(v3, v4)
    method51(v3)
    method96(v3)
    method31(v3)
    let v5 : string = $"%A{v1}"
    method14(v3, v5)
    method32(v3)
    let v6 : string = v3.l0
    v6
and method41 (v0 : clap_ArgMatches) : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> =
    let v1 : string = "true; let __future_init = Box::pin(/*"
    let v2 : bool = Fable.Core.RustInterop.emitRustExpr () v1 
    let v3 : string = "*/ async move { /*"
    let v4 : bool = Fable.Core.RustInterop.emitRustExpr () v3 
    let v5 : string = "*/ ()"
    let v6 : bool = Fable.Core.RustInterop.emitRustExpr () v5 
    let v7 : string = method42()
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "&*$0"
    let v10 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "&*$0"
    let v12 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v15 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v8 = v15 
    #endif
#else
    let v16 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v8 = v16 
    #endif
    let v17 : Ref<Str> = _run_target_args'_v8 
    let v18 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v19 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v0, v17) v18 
    let v20 : (std_string_String -> US2) = method4()
    let v21 : US2 option = v19 |> Option.map v20 
    let v22 : US2 = US2_1
    let v23 : US2 = v21 |> Option.defaultValue v22 
    let v27 : std_string_String =
        match v23 with
        | US2_1 -> (* None *)
            failwith<std_string_String> "Option does not have a value."
        | US2_0(v24) -> (* Some *)
            v24
    let v28 : string = "fable_library_rust::String_::fromString($0)"
    let v29 : string = Fable.Core.RustInterop.emitRustExpr v27 v28 
    let v129 : unit = ()
    let v130 : (unit -> unit) = closure23(v29)
    let v131 : unit = (fun () -> v130 (); v129) ()
    let v286 : string = "std::fs::read(&*$0)"
    let v287 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v29 v286 
    let v288 : string = "$0?"
    let v289 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v287 v288 
    let v290 : uint8 = 1uy
    let v291 : std_pin_Pin<Box<Dyn<std_future_Future<US15>>>> = method46(v289, v290)
    let v292 : string = "v291.await"
    let v293 : US15 = Fable.Core.RustInterop.emitRustExpr () v292 
    let v393 : unit = ()
    let v394 : (unit -> unit) = closure48(v293)
    let v395 : unit = (fun () -> v394 (); v393) ()
    let v608 : Result<uint8, anyhow_Error> =
        match v293 with
        | US15_1(v584, v585) -> (* Error *)
            let v586 : string = method103(v293, v585)
            let v587 : string = "anyhow::anyhow!($0)"
            let v588 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v586 v587 
            (* run_target_args'
            let v591 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v592 : string = "Err($0)"
            let v593 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v588 v592 
            let _run_target_args'_v591 = v593 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v594 : string = "Err($0)"
            let v595 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v588 v594 
            let _run_target_args'_v591 = v595 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v596 : string = "Err($0)"
            let v597 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v588 v596 
            let _run_target_args'_v591 = v597 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v598 : Result<uint8, anyhow_Error> = v588 |> Error
            let _run_target_args'_v591 = v598 
            #endif
#else
            let v599 : Result<uint8, anyhow_Error> = v588 |> Error
            let _run_target_args'_v591 = v599 
            #endif
            let v600 : Result<uint8, anyhow_Error> = _run_target_args'_v591 
            v600
        | US15_0(v550, v551) -> (* Ok *)
            let v554 : Result<uint8, anyhow_Error> = Ok v550 
            v554
    let v623 : string = ""
    let v624 : string = "}"
    let v625 : string = v623 + v624 
    let x = v608 //
    let v626 : _ = x
    let v627 : unit = ()
    (* run_target_args'
    let v628 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v629 : string = $"true; let _fix_closure_v627 = $0"
    let v630 : bool = Fable.Core.RustInterop.emitRustExpr v626 v629 
    let _run_target_args'_v628 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v631 : string = $"true; let _fix_closure_v627 = $0"
    let v632 : bool = Fable.Core.RustInterop.emitRustExpr v626 v631 
    let _run_target_args'_v628 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v633 : string = $"true; let _fix_closure_v627 = $0"
    let v634 : bool = Fable.Core.RustInterop.emitRustExpr v626 v633 
    let _run_target_args'_v628 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v628 = false 
    #endif
#else
    let _run_target_args'_v628 = false 
    #endif
    let v635 : bool = _run_target_args'_v628 
    let v636 : string = $"true; _fix_closure_v627 " + v625 + "); " + v623 + " // rust.fix_closure'"
    let v637 : bool = Fable.Core.RustInterop.emitRustExpr () v636 
    let v659 : string = "__future_init"
    let v660 : _ = Fable.Core.RustInterop.emitRustExpr () v659 
    let v661 : string = "v660"
    let v662 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v661 
    v662
and closure49 () (v0 : uint8) : US19 =
    US19_0(v0)
and method104 () : (uint8 -> US19) =
    closure49()
and closure50 () (v0 : std_string_String) : US19 =
    US19_1(v0)
and method105 () : (std_string_String -> US19) =
    closure50()
and closure0 () (v0 : (string [])) : int32 =
    let v1 : clap_Command = method0()
    let v2 : string = "clap::Command::get_matches($0)"
    let v3 : clap_ArgMatches = Fable.Core.RustInterop.emitRustExpr v1 v2 
    let v4 : string = method3()
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = "&*$0"
    let v7 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v6 
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : string = "&*$0"
    let v9 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v8 
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : string = "&*$0"
    let v11 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v10 
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v5 = v12 
    #endif
#else
    let v13 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v5 = v13 
    #endif
    let v14 : Ref<Str> = _run_target_args'_v5 
    let v15 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v16 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v14) v15 
    let v77 : (std_string_String -> US2) = method4()
    let v78 : US2 option = v16 |> Option.map v77 
    let v106 : US2 = US2_1
    let v107 : US2 = v78 |> Option.defaultValue v106 
    let v698 : US3 =
        match v107 with
        | US2_1 -> (* None *)
            US3_1
        | US2_0(v118) -> (* Some *)
            let v123 : string = "fable_library_rust::String_::fromString($0)"
            let v124 : string = Fable.Core.RustInterop.emitRustExpr v118 v123 
            
            
            
            
            
            let v135 : string = "Critical"
            let v136 : (unit -> string) = v135.ToLower
            let v137 : string = v136 ()
            let v138 : string = "Warning"
            let v139 : (unit -> string) = v138.ToLower
            let v140 : string = v139 ()
            let v141 : string = "Info"
            let v142 : (unit -> string) = v141.ToLower
            let v143 : string = v142 ()
            let v144 : string = "Debug"
            let v145 : (unit -> string) = v144.ToLower
            let v146 : string = v145 ()
            let v147 : string = "Verbose"
            let v148 : (unit -> string) = v147.ToLower
            let v149 : string = v148 ()
            (* run_target_args'
            let v374 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v375 : struct (string * US5) list = []
            let v376 : US5 = US5_4
            let v377 : struct (string * US5) list = struct (v137, v376) :: v375 
            let v378 : US5 = US5_3
            let v379 : struct (string * US5) list = struct (v140, v378) :: v377 
            let v380 : US5 = US5_2
            let v381 : struct (string * US5) list = struct (v143, v380) :: v379 
            let v382 : US5 = US5_1
            let v383 : struct (string * US5) list = struct (v146, v382) :: v381 
            let v384 : US5 = US5_0
            let v385 : struct (string * US5) list = struct (v149, v384) :: v383 
            let v386 : US5 = US5_4
            let v387 : struct (string * US5) list = struct (v135, v386) :: v385 
            let v388 : US5 = US5_3
            let v389 : struct (string * US5) list = struct (v138, v388) :: v387 
            let v390 : US5 = US5_2
            let v391 : struct (string * US5) list = struct (v141, v390) :: v389 
            let v392 : US5 = US5_1
            let v393 : struct (string * US5) list = struct (v144, v392) :: v391 
            let v394 : US5 = US5_0
            let v395 : struct (string * US5) list = struct (v147, v394) :: v393 
            let _run_target_args'_v374 = v395 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v396 : struct (string * US5) list = []
            let v397 : US5 = US5_4
            let v398 : struct (string * US5) list = struct (v137, v397) :: v396 
            let v399 : US5 = US5_3
            let v400 : struct (string * US5) list = struct (v140, v399) :: v398 
            let v401 : US5 = US5_2
            let v402 : struct (string * US5) list = struct (v143, v401) :: v400 
            let v403 : US5 = US5_1
            let v404 : struct (string * US5) list = struct (v146, v403) :: v402 
            let v405 : US5 = US5_0
            let v406 : struct (string * US5) list = struct (v149, v405) :: v404 
            let v407 : US5 = US5_4
            let v408 : struct (string * US5) list = struct (v135, v407) :: v406 
            let v409 : US5 = US5_3
            let v410 : struct (string * US5) list = struct (v138, v409) :: v408 
            let v411 : US5 = US5_2
            let v412 : struct (string * US5) list = struct (v141, v411) :: v410 
            let v413 : US5 = US5_1
            let v414 : struct (string * US5) list = struct (v144, v413) :: v412 
            let v415 : US5 = US5_0
            let v416 : struct (string * US5) list = struct (v147, v415) :: v414 
            let _run_target_args'_v374 = v416 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v417 : struct (string * US5) list = []
            let v418 : US5 = US5_4
            let v419 : struct (string * US5) list = struct (v137, v418) :: v417 
            let v420 : US5 = US5_3
            let v421 : struct (string * US5) list = struct (v140, v420) :: v419 
            let v422 : US5 = US5_2
            let v423 : struct (string * US5) list = struct (v143, v422) :: v421 
            let v424 : US5 = US5_1
            let v425 : struct (string * US5) list = struct (v146, v424) :: v423 
            let v426 : US5 = US5_0
            let v427 : struct (string * US5) list = struct (v149, v426) :: v425 
            let v428 : US5 = US5_4
            let v429 : struct (string * US5) list = struct (v135, v428) :: v427 
            let v430 : US5 = US5_3
            let v431 : struct (string * US5) list = struct (v138, v430) :: v429 
            let v432 : US5 = US5_2
            let v433 : struct (string * US5) list = struct (v141, v432) :: v431 
            let v434 : US5 = US5_1
            let v435 : struct (string * US5) list = struct (v144, v434) :: v433 
            let v436 : US5 = US5_0
            let v437 : struct (string * US5) list = struct (v147, v436) :: v435 
            let _run_target_args'_v374 = v437 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v438 : struct (string * US5) list = []
            let v439 : US5 = US5_4
            let v440 : struct (string * US5) list = struct (v137, v439) :: v438 
            let v441 : US5 = US5_3
            let v442 : struct (string * US5) list = struct (v140, v441) :: v440 
            let v443 : US5 = US5_2
            let v444 : struct (string * US5) list = struct (v143, v443) :: v442 
            let v445 : US5 = US5_1
            let v446 : struct (string * US5) list = struct (v146, v445) :: v444 
            let v447 : US5 = US5_0
            let v448 : struct (string * US5) list = struct (v149, v447) :: v446 
            let v449 : US5 = US5_4
            let v450 : struct (string * US5) list = struct (v135, v449) :: v448 
            let v451 : US5 = US5_3
            let v452 : struct (string * US5) list = struct (v138, v451) :: v450 
            let v453 : US5 = US5_2
            let v454 : struct (string * US5) list = struct (v141, v453) :: v452 
            let v455 : US5 = US5_1
            let v456 : struct (string * US5) list = struct (v144, v455) :: v454 
            let v457 : US5 = US5_0
            let v458 : struct (string * US5) list = struct (v147, v457) :: v456 
            let _run_target_args'_v374 = v458 
            #endif
#else
            let v459 : struct (string * US5) list = []
            let v460 : US5 = US5_4
            let v461 : struct (string * US5) list = struct (v137, v460) :: v459 
            let v462 : US5 = US5_3
            let v463 : struct (string * US5) list = struct (v140, v462) :: v461 
            let v464 : US5 = US5_2
            let v465 : struct (string * US5) list = struct (v143, v464) :: v463 
            let v466 : US5 = US5_1
            let v467 : struct (string * US5) list = struct (v146, v466) :: v465 
            let v468 : US5 = US5_0
            let v469 : struct (string * US5) list = struct (v149, v468) :: v467 
            let v470 : US5 = US5_4
            let v471 : struct (string * US5) list = struct (v135, v470) :: v469 
            let v472 : US5 = US5_3
            let v473 : struct (string * US5) list = struct (v138, v472) :: v471 
            let v474 : US5 = US5_2
            let v475 : struct (string * US5) list = struct (v141, v474) :: v473 
            let v476 : US5 = US5_1
            let v477 : struct (string * US5) list = struct (v144, v476) :: v475 
            let v478 : US5 = US5_0
            let v479 : struct (string * US5) list = struct (v147, v478) :: v477 
            let _run_target_args'_v374 = v479 
            #endif
            let v480 : struct (string * US5) list = _run_target_args'_v374 
            let v632 : (struct (string * US5) list -> (struct (string * US5) [])) = List.toArray
            let v633 : (struct (string * US5) []) = v632 v480
            let v666 : int32 = v633.Length
            let v667 : US4 = US4_1
            let v668 : Mut0 = {l0 = 0; l1 = v667} : Mut0
            while method5(v666, v668) do
                let v670 : int32 = v668.l0
                let v671 : int32 =  -v670
                let v672 : int32 = v671 + v666
                let v673 : int32 = v672 - 1
                let v674 : US4 = v668.l1
                let struct (v675 : string, v676 : US5) = v633.[int v673]
                let v692 : US4 =
                    match v674 with
                    | US4_1 -> (* None *)
                        let v680 : bool = v675 = v124 
                        if v680 then
                            US4_0(v676)
                        else
                            US4_1
                    | US4_0(v677) -> (* Some *)
                        v674
                let v693 : int32 = v670 + 1
                v668.l0 <- v693
                v668.l1 <- v692
                ()
            let v694 : US4 = v668.l1
            US3_0(v694)
    let v705 : US4 =
        match v698 with
        | US3_0(v699) -> (* Some *)
            match v699 with
            | US4_0(v700) -> (* Some *)
                US4_0(v700)
            | _ ->
                US4_1
        | _ ->
            US4_1
    let v709 : US5 =
        match v705 with
        | US4_1 -> (* None *)
            US5_0
        | US4_0(v706) -> (* Some *)
            v706
    let v754 : unit = ()
    let v755 : (unit -> unit) = closure7(v709)
    let v756 : unit = (fun () -> v755 (); v754) ()
    let struct (v802 : Mut1, v803 : Mut2, v804 : Mut3, v805 : Mut4, v806 : Mut5, v807 : int64 option) = TraceState.trace_state.Value
    let v1259 : unit = ()
    let v1260 : (unit -> unit) = closure16(v0)
    let v1261 : unit = (fun () -> v1260 (); v1259) ()
    let v1416 : string = method37()
    (* run_target_args'
    let v1417 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1418 : string = "&*$0"
    let v1419 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1416 v1418 
    let _run_target_args'_v1417 = v1419 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1420 : string = "&*$0"
    let v1421 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1416 v1420 
    let _run_target_args'_v1417 = v1421 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1422 : string = "&*$0"
    let v1423 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1416 v1422 
    let _run_target_args'_v1417 = v1423 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1424 : Ref<Str> = v1416 |> unbox<Ref<Str>>
    let _run_target_args'_v1417 = v1424 
    #endif
#else
    let v1425 : Ref<Str> = v1416 |> unbox<Ref<Str>>
    let _run_target_args'_v1417 = v1425 
    #endif
    let v1426 : Ref<Str> = _run_target_args'_v1417 
    let v1427 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v1428 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v1426) v1427 
    let v1447 : (std_string_String -> string) = method38()
    let v1448 : string option = v1428 |> Option.map v1447 
    let v1489 : (string -> US10) = method17()
    let v1490 : US10 option = v1448 |> Option.map v1489 
    let v1491 : US10 = US10_1
    let v1492 : US10 = v1490 |> Option.defaultValue v1491 
    let v1493 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method41(v3)
    let v1494 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v1495 : _ = Fable.Core.RustInterop.emitRustExpr () v1494 
    let v1496 : string = "v1495.handle().block_on($0)"
    let v1497 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1493 v1496 
    let v1498 : (anyhow_Error -> std_string_String) = method90()
    (* run_target_args'
    let v1501 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1502 : string = "$0.map_err(|x| $1(x))"
    let v1503 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v1497, v1498) v1502 
    let _run_target_args'_v1501 = v1503 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1504 : string = "$0.map_err(|x| $1(x))"
    let v1505 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v1497, v1498) v1504 
    let _run_target_args'_v1501 = v1505 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1506 : string = "$0.map_err(|x| $1(x))"
    let v1507 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v1497, v1498) v1506 
    let _run_target_args'_v1501 = v1507 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1508 : Result<uint8, std_string_String> = match v1497 with Ok x -> Ok x | Error x -> Error (v1498 x)
    let _run_target_args'_v1501 = v1508 
    #endif
#else
    let v1509 : Result<uint8, std_string_String> = match v1497 with Ok x -> Ok x | Error x -> Error (v1498 x)
    let _run_target_args'_v1501 = v1509 
    #endif
    let v1510 : Result<uint8, std_string_String> = _run_target_args'_v1501 
    let v1519 : (uint8 -> US19) = method104()
    let v1520 : (std_string_String -> US19) = method105()
    let v1523 : US19 = match v1510 with Ok x -> v1519 x | Error x -> v1520 x
    match v1523 with
    | US19_1(v1575) -> (* Error *)
        match v1492 with
        | US10_0(v1576) -> (* Some *)
            let v1577 : bool = "" = v1576
            if v1577 then
                ()
            else
                let v1578 : string = "fable_library_rust::String_::fromString($0)"
                let v1579 : string = Fable.Core.RustInterop.emitRustExpr v1575 v1578 
                let v1582 : bool = v1579.Contains v1576 
                if v1582 then
                    ()
                else
                    let v1590 : string = $"spiral_wasm.main / exception: '{v1576}' / error: {v1575}"
                    (* run_target_args'
                    let v1591 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v1592 : string = "Err($0)"
                    let v1593 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1590 v1592 
                    let _run_target_args'_v1591 = v1593 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v1594 : string = "Err($0)"
                    let v1595 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1590 v1594 
                    let _run_target_args'_v1591 = v1595 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v1596 : string = "Err($0)"
                    let v1597 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1590 v1596 
                    let _run_target_args'_v1591 = v1597 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v1598 : Result<unit, string> = v1590 |> Error
                    let _run_target_args'_v1591 = v1598 
                    #endif
#else
                    let v1599 : Result<unit, string> = v1590 |> Error
                    let _run_target_args'_v1591 = v1599 
                    #endif
                    let v1600 : Result<unit, string> = _run_target_args'_v1591 
                    let v1601 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v1600 v1601 
                    ()
        | _ ->
            let v1602 : string = "$0.unwrap()"
            let v1603 : uint8 = Fable.Core.RustInterop.emitRustExpr v1510 v1602 
            ()
    | US19_0(v1553) -> (* Ok *)
        match v1492 with
        | US10_0(v1554) -> (* Some *)
            let v1555 : string = $"spiral_wasm.main / retries: {v1553} / exception: '{v1554}'"
            (* run_target_args'
            let v1558 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1559 : string = "Err($0)"
            let v1560 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1555 v1559 
            let _run_target_args'_v1558 = v1560 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1561 : string = "Err($0)"
            let v1562 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1555 v1561 
            let _run_target_args'_v1558 = v1562 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1563 : string = "Err($0)"
            let v1564 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1555 v1563 
            let _run_target_args'_v1558 = v1564 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1565 : Result<unit, string> = v1555 |> Error
            let _run_target_args'_v1558 = v1565 
            #endif
#else
            let v1566 : Result<unit, string> = v1555 |> Error
            let _run_target_args'_v1558 = v1566 
            #endif
            let v1567 : Result<unit, string> = _run_target_args'_v1558 
            let v1574 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v1567 v1574 
            ()
        | _ ->
            ()
    0
let v6 : ((string []) -> int32) = closure0()
let main args = v6 args
()
