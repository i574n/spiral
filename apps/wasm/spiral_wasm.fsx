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
type IOsEnviron = abstract environ: x: unit -> obj
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
and Mut0 = {mutable l0 : int64}
and Mut1 = {mutable l0 : (string -> unit)}
and Mut2 = {mutable l0 : bool}
and Mut3 = {mutable l0 : string}
and Mut4 = {mutable l0 : US5}
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
    | US12_0 of f0_0 : Mut0 * f0_1 : Mut1 * f0_2 : Mut2 * f0_3 : Mut3 * f0_4 : Mut4 * f0_5 : int64 option
    | US12_1
and [<Struct>] US13 =
    | US13_0 of f0_0 : char
    | US13_1
and Mut5 = {mutable l0 : int32}
and [<Struct>] US14 =
    | US14_0 of f0_0 : uint8 * f0_1 : US10
    | US14_1 of f1_0 : uint8 * f1_1 : US10
and [<Struct>] US15 =
    | US15_0 of f0_0 : int32
    | US15_1 of f1_0 : exn
and [<Struct>] US16 =
    | US16_0 of f0_0 : int32
    | US16_1
and [<Struct>] US17 =
    | US17_0 of f0_0 : US10
    | US17_1 of f1_0 : std_string_String
and [<Struct>] US18 =
    | US18_0 of f0_0 : uint8
    | US18_1 of f1_0 : std_string_String
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
    let v0 : string = "command"
    let v1 : string = "r#\"" + v0 + "\"#"
    let v2 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v1 
    let v3 : string = "clap::Command::new($0)"
    let v4 : clap_Command = Fable.Core.RustInterop.emitRustExpr v2 v3 
    let v5 : string = "clap::Command::args_override_self($0, true)"
    let v6 : clap_Command = Fable.Core.RustInterop.emitRustExpr v4 v5 
    let v20 : US0 = method1()
    let v41 : US1 =
        match v20 with
        | US0_1(v38) -> (* Error *)
            US1_1
        | US0_0(v36) -> (* Ok *)
            US1_0(v36)
    let v88 : unativeint =
        match v41 with
        | US1_1 -> (* None *)
            failwith<unativeint> "Option does not have a value."
        | US1_0(v85) -> (* Some *)
            v85
    let v102 : US0 = method2()
    let v123 : US1 =
        match v102 with
        | US0_1(v120) -> (* Error *)
            US1_1
        | US0_0(v118) -> (* Ok *)
            US1_0(v118)
    let v170 : unativeint =
        match v123 with
        | US1_1 -> (* None *)
            failwith<unativeint> "Option does not have a value."
        | US1_0(v167) -> (* Some *)
            v167
    let v184 : US0 = method1()
    let v205 : US1 =
        match v184 with
        | US0_1(v202) -> (* Error *)
            US1_1
        | US0_0(v200) -> (* Ok *)
            US1_0(v200)
    let v252 : unativeint =
        match v205 with
        | US1_1 -> (* None *)
            failwith<unativeint> "Option does not have a value."
        | US1_0(v249) -> (* Some *)
            v249
    let v255 : bool = v170 = v252 
    let v272 : clap_builder_ValueRange =
        if v255 then
            let v267 : string = "clap::builder::ValueRange::new($0..)"
            let v268 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr v88 v267 
            v268
        else
            let v269 : string = "="
            let v270 : string = "clap::builder::ValueRange::new($0.." + v269 + "$1)"
            let v271 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr struct (v88, v170) v270 
            v271
    let v273 : string = "exception"
    let v274 : string = "r#\"" + v273 + "\"#"
    let v275 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v274 
    let v276 : string = "clap::Arg::new($0)"
    let v277 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v275 v276 
    let v278 : string = "$0.short($1)"
    let v279 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v277, 'e') v278 
    let v280 : string = "r#\"" + v273 + "\"#"
    let v281 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v280 
    let v282 : string = "$0.long($1)"
    let v283 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v279, v281) v282 
    let v284 : string = "$0.num_args($1)"
    let v285 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v283, v272) v284 
    let v286 : string = "$0.require_equals($1)"
    let v287 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v285, true) v286 
    let v288 : string = ""
    let v289 : string = "r#\"" + v288 + "\"#"
    let v290 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v289 
    let v291 : string = "$0.default_missing_value($1)"
    let v292 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v287, v290) v291 
    let v293 : string = "clap::Command::arg($0, $1)"
    let v294 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v6, v292) v293 
    let v295 : string = "trace_level"
    let v296 : string = "r#\"" + v295 + "\"#"
    let v297 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v296 
    let v298 : string = "clap::Arg::new($0)"
    let v299 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v297 v298 
    let v300 : string = "$0.short($1)"
    let v301 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v299, 't') v300 
    let v302 : string = "r#\"" + v295 + "\"#"
    let v303 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v302 
    let v304 : string = "$0.long($1)"
    let v305 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v301, v303) v304 
    
    
    
    
    
    let v310 : string = "Critical"
    let v311 : (unit -> string) = v310.ToLower
    let v312 : string = v311 ()
    let v328 : string = "Warning"
    let v329 : (unit -> string) = v328.ToLower
    let v330 : string = v329 ()
    let v346 : string = "Info"
    let v347 : (unit -> string) = v346.ToLower
    let v348 : string = v347 ()
    let v364 : string = "Debug"
    let v365 : (unit -> string) = v364.ToLower
    let v366 : string = v365 ()
    let v382 : string = "Verbose"
    let v383 : (unit -> string) = v382.ToLower
    let v384 : string = v383 ()
    let v396 : string list = []
    let v399 : string list = v312 :: v396 
    let v413 : string list = v330 :: v399 
    let v427 : string list = v348 :: v413 
    let v441 : string list = v366 :: v427 
    let v455 : string list = v384 :: v441 
    let v485 : (string list -> (string [])) = List.toArray
    let v486 : (string []) = v485 v455
    let v498 : string = "$0.to_vec()"
    let v499 : Vec<string> = Fable.Core.RustInterop.emitRustExpr v486 v498 
    let v500 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v501 : bool = Fable.Core.RustInterop.emitRustExpr v499 v500 
    let v502 : string = "x"
    let v503 : string = Fable.Core.RustInterop.emitRustExpr () v502 
    (* run_target_args'
    let v686 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v687 : string = "&*$0"
    let v688 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v503 v687 
    let _run_target_args'_v686 = v688 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v689 : string = "&*$0"
    let v690 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v503 v689 
    let _run_target_args'_v686 = v690 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v691 : string = "&*$0"
    let v692 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v503 v691 
    let _run_target_args'_v686 = v692 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v772 : Ref<Str> = v503 |> unbox<Ref<Str>>
    let _run_target_args'_v686 = v772 
    #endif
#if FABLE_COMPILER_PYTHON
    let v863 : Ref<Str> = v503 |> unbox<Ref<Str>>
    let _run_target_args'_v686 = v863 
    #endif
#else
    let v954 : Ref<Str> = v503 |> unbox<Ref<Str>>
    let _run_target_args'_v686 = v954 
    #endif
    let v966 : Ref<Str> = _run_target_args'_v686 
    (* run_target_args'
    let v1331 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1332 : string = "String::from($0)"
    let v1333 : std_string_String = Fable.Core.RustInterop.emitRustExpr v966 v1332 
    let _run_target_args'_v1331 = v1333 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1334 : string = "String::from($0)"
    let v1335 : std_string_String = Fable.Core.RustInterop.emitRustExpr v966 v1334 
    let _run_target_args'_v1331 = v1335 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1336 : string = "String::from($0)"
    let v1337 : std_string_String = Fable.Core.RustInterop.emitRustExpr v966 v1336 
    let _run_target_args'_v1331 = v1337 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1417 : std_string_String = v966 |> unbox<std_string_String>
    let _run_target_args'_v1331 = v1417 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1508 : std_string_String = v966 |> unbox<std_string_String>
    let _run_target_args'_v1331 = v1508 
    #endif
#else
    let v1599 : std_string_String = v966 |> unbox<std_string_String>
    let _run_target_args'_v1331 = v1599 
    #endif
    let v1611 : std_string_String = _run_target_args'_v1331 
    let v1794 : string = "Box::new($0)"
    let v1795 : Box<std_string_String> = Fable.Core.RustInterop.emitRustExpr v1611 v1794 
    let v1796 : string = "Box::leak($0)"
    let v1797 : Ref<Lifetime<StaticLifetime, Mut<std_string_String>>> = Fable.Core.RustInterop.emitRustExpr v1795 v1796 
    let v1798 : string = "clap::builder::PossibleValue::new(&**$0)"
    let v1799 : clap_builder_PossibleValue = Fable.Core.RustInterop.emitRustExpr v1797 v1798 
    let v1800 : string = "true; $0 }).collect::<Vec<_>>()"
    let v1801 : bool = Fable.Core.RustInterop.emitRustExpr v1799 v1800 
    let v1802 : string = "_vec_map"
    let v1803 : Vec<clap_builder_PossibleValue> = Fable.Core.RustInterop.emitRustExpr () v1802 
    let v1804 : string = "Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new($0))"
    let v1805 : clap_builder_ValueParser = Fable.Core.RustInterop.emitRustExpr v1803 v1804 
    let v1806 : string = "$0.value_parser($1)"
    let v1807 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v305, v1805) v1806 
    let v1808 : string = "clap::Command::arg($0, $1)"
    let v1809 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v294, v1807) v1808 
    let v1810 : string = "wasm"
    let v1811 : string = "r#\"" + v1810 + "\"#"
    let v1812 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v1811 
    let v1813 : string = "clap::Arg::new($0)"
    let v1814 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v1812 v1813 
    let v1815 : string = "$0.short($1)"
    let v1816 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v1814, 'w') v1815 
    let v1817 : string = "r#\"" + v1810 + "\"#"
    let v1818 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v1817 
    let v1819 : string = "$0.long($1)"
    let v1820 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v1816, v1818) v1819 
    let v1821 : string = "$0.required($1)"
    let v1822 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v1820, true) v1821 
    let v1823 : string = "clap::Command::arg($0, $1)"
    let v1824 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v1809, v1822) v1823 
    v1824
and method3 () : string =
    let v0 : string = "trace_level"
    v0
and closure6 () (v0 : std_string_String) : US2 =
    US2_0(v0)
and method4 () : (std_string_String -> US2) =
    closure6()
and method8 (v0 : string) : string =
    v0
and method9 () : string =
    let v0 : string = ""
    v0
and method12 () : string =
    let v0 : string = ""
    v0
and method13 (v0 : Mut3, v1 : string) : unit =
    let v2 : string = v0.l0
    let v5 : string = v2 + v1 
    v0.l0 <- v5
    ()
and method11 (v0 : US9) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    let v15 : string = $"%A{v0}"
    method13(v12, v15)
    let v148 : string = v12.l0
    v148
and method14 (v0 : string) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    method13(v12, v0)
    let v134 : string = v12.l0
    v134
and method10 (v0 : string) : string =
    let v1 : US7 = US7_0
    let v2 : US8 = US8_0(v1)
    let v3 : US9 = US9_5(v2)
    let v4 : string = method11(v3)
    let v9 : string = "env.get_environment_variable / target: "
    let v10 : string = v9 + v4 
    let v26 : string = " / var: "
    let v27 : string = v10 + v26 
    let v39 : string = method14(v0)
    let v42 : string = v27 + v39 
    failwith<string> v42
and method15 (v0 : string) : string =
    let v1 : US7 = US7_1
    let v2 : US8 = US8_0(v1)
    let v3 : US9 = US9_5(v2)
    let v4 : string = method11(v3)
    let v9 : string = "env.get_environment_variable / target: "
    let v10 : string = v9 + v4 
    let v26 : string = " / var: "
    let v27 : string = v10 + v26 
    let v39 : string = method14(v0)
    let v42 : string = v27 + v39 
    failwith<string> v42
and closure8 () (v0 : string) : US10 =
    US10_0(v0)
and method16 () : (string -> US10) =
    closure8()
and method7 (v0 : string) : string =
    (* run_target_args'
    let v31 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v32 : string = method8(v0)
    let v33 : string = "std::env::var(&*$0)"
    let v34 : Result<std_string_String, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr v32 v33 
    let v35 : string = "true; let _result_map_ = $0.map(|x| { //"
    let v36 : bool = Fable.Core.RustInterop.emitRustExpr v34 v35 
    let v37 : string = "x"
    let v38 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v37 
    let v39 : string = "fable_library_rust::String_::fromString($0)"
    let v40 : string = Fable.Core.RustInterop.emitRustExpr v38 v39 
    let v41 : string = "true; $0 })"
    let v42 : bool = Fable.Core.RustInterop.emitRustExpr v40 v41 
    let v43 : string = "_result_map_"
    let v44 : Result<string, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr () v43 
    let v45 : string = method9()
    let v46 : string = "$0.unwrap_or($1)"
    let v47 : string = Fable.Core.RustInterop.emitRustExpr struct (v44, v45) v46 
    let _run_target_args'_v31 = v47 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v48 : string = method10(v0)
    let _run_target_args'_v31 = v48 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v49 : string = method15(v0)
    let _run_target_args'_v31 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v50 : string = "process.env[$0] ?? \"\""
    let v51 : string = Fable.Core.JsInterop.emitJsExpr v0 v50 
    let _run_target_args'_v31 = v51 
    #endif
#if FABLE_COMPILER_PYTHON
    let v65 : string = "os"
    let v66 : IOsEnviron = Fable.Core.PyInterop.importAll v65 
    let v67 : string = "v66.environ"
    let v68 : obj = Fable.Core.PyInterop.emitPyExpr () v67 
    let v93 : string = "v68.get($0)"
    let v94 : string = Fable.Core.PyInterop.emitPyExpr v0 v93 
    let mutable _v94 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v122 : (string -> string option) = Option.ofObj
    let v123 : string option = v122 v94
    v123 
    #else
    Some v94 
    #endif
    |> fun x -> _v94 <- Some x
    let v124 : string option = match _v94 with Some x -> x | None -> failwith "optionm'.of_obj / _v94=None"
    let v198 : (string -> US10) = method16()
    let v199 : US10 option = v124 |> Option.map v198 
    let v260 : US10 = US10_1
    let v261 : US10 = v199 |> Option.defaultValue v260 
    let v277 : string =
        match v261 with
        | US10_1 -> (* None *)
            let v275 : string = ""
            v275
        | US10_0(v274) -> (* Some *)
            v274
    let _run_target_args'_v31 = v277 
    #endif
#else
    let v278 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v279 : string = v278 v0
    let mutable _v279 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v296 : (string -> string option) = Option.ofObj
    let v297 : string option = v296 v279
    v297 
    #else
    Some v279 
    #endif
    |> fun x -> _v279 <- Some x
    let v298 : string option = match _v279 with Some x -> x | None -> failwith "optionm'.of_obj / _v279=None"
    let v372 : (string -> US10) = method16()
    let v373 : US10 option = v298 |> Option.map v372 
    let v434 : US10 = US10_1
    let v435 : US10 = v373 |> Option.defaultValue v434 
    let v451 : string =
        match v435 with
        | US10_1 -> (* None *)
            let v449 : string = ""
            v449
        | US10_0(v448) -> (* Some *)
            v448
    let _run_target_args'_v31 = v451 
    #endif
    let v452 : string = _run_target_args'_v31 
    v452
and closure9 (v0 : int64) () : int64 =
    let v1 : int64 = v0 |> int64 
    v1
and closure10 () (v0 : int64) : US11 =
    US11_0(v0)
and closure11 () (v0 : exn) : US11 =
    US11_1(v0)
and method17 (v0 : int64) : US11 =
    let v1 : (unit -> int64) = closure9(v0)
    let v2 : (int64 -> US11) = closure10()
    let v3 : ((unit -> exn) -> exn) = closure3()
    let v4 : (exn -> US11) = closure11()
    let v5 : US11 = try v1 () |> v2 with ex -> (fun () -> ex) |> v3 |> v4 
    v5
and method6 () : struct (US4 * US6) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method7(v0)
    
    
    
    
    
    
    
    
    
    
    let v6 : string = "Critical"
    let v7 : (unit -> string) = v6.ToLower
    let v8 : string = v7 ()
    let v24 : string = "Warning"
    let v25 : (unit -> string) = v24.ToLower
    let v26 : string = v25 ()
    let v42 : string = "Info"
    let v43 : (unit -> string) = v42.ToLower
    let v44 : string = v43 ()
    let v60 : string = "Debug"
    let v61 : (unit -> string) = v60.ToLower
    let v62 : string = v61 ()
    let v78 : string = "Verbose"
    let v79 : (unit -> string) = v78.ToLower
    let v80 : string = v79 ()
    let v92 : bool = "Verbose" = v1
    let v96 : US4 =
        if v92 then
            let v93 : US5 = US5_0
            US4_0(v93)
        else
            US4_1
    let v182 : US4 =
        match v96 with
        | US4_1 -> (* None *)
            let v99 : bool = "Debug" = v1
            let v103 : US4 =
                if v99 then
                    let v100 : US5 = US5_1
                    US4_0(v100)
                else
                    US4_1
            match v103 with
            | US4_1 -> (* None *)
                let v106 : bool = "Info" = v1
                let v110 : US4 =
                    if v106 then
                        let v107 : US5 = US5_2
                        US4_0(v107)
                    else
                        US4_1
                match v110 with
                | US4_1 -> (* None *)
                    let v113 : bool = "Warning" = v1
                    let v117 : US4 =
                        if v113 then
                            let v114 : US5 = US5_3
                            US4_0(v114)
                        else
                            US4_1
                    match v117 with
                    | US4_1 -> (* None *)
                        let v120 : bool = "Critical" = v1
                        let v124 : US4 =
                            if v120 then
                                let v121 : US5 = US5_4
                                US4_0(v121)
                            else
                                US4_1
                        match v124 with
                        | US4_1 -> (* None *)
                            let v127 : bool = v80 = v1
                            let v131 : US4 =
                                if v127 then
                                    let v128 : US5 = US5_0
                                    US4_0(v128)
                                else
                                    US4_1
                            match v131 with
                            | US4_1 -> (* None *)
                                let v134 : bool = v62 = v1
                                let v138 : US4 =
                                    if v134 then
                                        let v135 : US5 = US5_1
                                        US4_0(v135)
                                    else
                                        US4_1
                                match v138 with
                                | US4_1 -> (* None *)
                                    let v141 : bool = v44 = v1
                                    let v145 : US4 =
                                        if v141 then
                                            let v142 : US5 = US5_2
                                            US4_0(v142)
                                        else
                                            US4_1
                                    match v145 with
                                    | US4_1 -> (* None *)
                                        let v148 : bool = v26 = v1
                                        let v152 : US4 =
                                            if v148 then
                                                let v149 : US5 = US5_3
                                                US4_0(v149)
                                            else
                                                US4_1
                                        match v152 with
                                        | US4_1 -> (* None *)
                                            let v155 : bool = v8 = v1
                                            let v159 : US4 =
                                                if v155 then
                                                    let v156 : US5 = US5_4
                                                    US4_0(v156)
                                                else
                                                    US4_1
                                            match v159 with
                                            | US4_1 -> (* None *)
                                                US4_1
                                            | US4_0(v160) -> (* Some *)
                                                US4_0(v160)
                                        | US4_0(v153) -> (* Some *)
                                            US4_0(v153)
                                    | US4_0(v146) -> (* Some *)
                                        US4_0(v146)
                                | US4_0(v139) -> (* Some *)
                                    US4_0(v139)
                            | US4_0(v132) -> (* Some *)
                                US4_0(v132)
                        | US4_0(v125) -> (* Some *)
                            US4_0(v125)
                    | US4_0(v118) -> (* Some *)
                        US4_0(v118)
                | US4_0(v111) -> (* Some *)
                    US4_0(v111)
            | US4_0(v104) -> (* Some *)
                US4_0(v104)
        | US4_0(v97) -> (* Some *)
            US4_0(v97)
    let v183 : string = "AUTOMATION"
    let v184 : string = method7(v183)
    let v189 : string = "True"
    let v190 : bool = v184 <> v189 
    let v558 : US6 =
        if v190 then
            US6_1
        else
            (* run_target_args'
            let v231 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v232 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v232 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v233 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v233 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v236 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v231 = v236 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v248 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v248 
            #endif
#if FABLE_COMPILER_PYTHON
            let v249 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v249 
            #endif
#else
            let v250 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v250 
            #endif
            let v251 : System.DateTime = _run_target_args'_v231 
            (* run_target_args'
            let v280 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v281 : (System.DateTime -> int64) = _.Ticks
            let v282 : int64 = v281 v251
            let _run_target_args'_v280 = v282 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v283 : (System.DateTime -> int64) = _.Ticks
            let v284 : int64 = v283 v251
            let _run_target_args'_v280 = v284 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v287 : int64 = null |> unbox<int64>
            let _run_target_args'_v280 = v287 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v299 : (System.DateTime -> int64) = _.Ticks
            let v300 : int64 = v299 v251
            let _run_target_args'_v280 = v300 
            #endif
#if FABLE_COMPILER_PYTHON
            let v301 : (System.DateTime -> int64) = _.Ticks
            let v302 : int64 = v301 v251
            let _run_target_args'_v280 = v302 
            #endif
#else
            let v303 : (System.DateTime -> int64) = _.Ticks
            let v304 : int64 = v303 v251
            let _run_target_args'_v280 = v304 
            #endif
            let v305 : int64 = _run_target_args'_v280 
            let v463 : US11 = method17(v305)
            let v484 : US6 =
                match v463 with
                | US11_1(v481) -> (* Error *)
                    US6_1
                | US11_0(v479) -> (* Ok *)
                    US6_0(v479)
            let v531 : int64 =
                match v484 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v528) -> (* Some *)
                    v528
            US6_0(v531)
    struct (v182, v558)
and closure12 () (v0 : string) : unit =
    ()
and method5 (v0 : US5) : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let struct (v6 : US4, v7 : US6) = method6()
    let _run_target_args'_v5 = struct (v6, v7) 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : US4 = US4_1
    let v9 : US6 = US6_1
    let _run_target_args'_v5 = struct (v8, v9) 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : string = "AUTOMATION"
    (* run_target_args'
    let v39 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v40 : string = "option_env!(\"" + v10 + "\").unwrap_or(\"\")"
    let v41 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v40 
    (* run_target_args'
    let v224 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v225 : string = "String::from($0)"
    let v226 : std_string_String = Fable.Core.RustInterop.emitRustExpr v41 v225 
    let _run_target_args'_v224 = v226 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v227 : string = "String::from($0)"
    let v228 : std_string_String = Fable.Core.RustInterop.emitRustExpr v41 v227 
    let _run_target_args'_v224 = v228 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v229 : string = "String::from($0)"
    let v230 : std_string_String = Fable.Core.RustInterop.emitRustExpr v41 v229 
    let _run_target_args'_v224 = v230 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v310 : std_string_String = v41 |> unbox<std_string_String>
    let _run_target_args'_v224 = v310 
    #endif
#if FABLE_COMPILER_PYTHON
    let v401 : std_string_String = v41 |> unbox<std_string_String>
    let _run_target_args'_v224 = v401 
    #endif
#else
    let v492 : std_string_String = v41 |> unbox<std_string_String>
    let _run_target_args'_v224 = v492 
    #endif
    let v504 : std_string_String = _run_target_args'_v224 
    let v687 : string = "fable_library_rust::String_::fromString($0)"
    let v688 : string = Fable.Core.RustInterop.emitRustExpr v504 v687 
    let _run_target_args'_v39 = v688 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v689 : string = "option_env!(\"" + v10 + "\").unwrap_or(\"\")"
    let v690 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v689 
    (* run_target_args'
    let v873 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v874 : string = "String::from($0)"
    let v875 : std_string_String = Fable.Core.RustInterop.emitRustExpr v690 v874 
    let _run_target_args'_v873 = v875 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v876 : string = "String::from($0)"
    let v877 : std_string_String = Fable.Core.RustInterop.emitRustExpr v690 v876 
    let _run_target_args'_v873 = v877 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v878 : string = "String::from($0)"
    let v879 : std_string_String = Fable.Core.RustInterop.emitRustExpr v690 v878 
    let _run_target_args'_v873 = v879 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v959 : std_string_String = v690 |> unbox<std_string_String>
    let _run_target_args'_v873 = v959 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1050 : std_string_String = v690 |> unbox<std_string_String>
    let _run_target_args'_v873 = v1050 
    #endif
#else
    let v1141 : std_string_String = v690 |> unbox<std_string_String>
    let _run_target_args'_v873 = v1141 
    #endif
    let v1153 : std_string_String = _run_target_args'_v873 
    let v1336 : string = "fable_library_rust::String_::fromString($0)"
    let v1337 : string = Fable.Core.RustInterop.emitRustExpr v1153 v1336 
    let _run_target_args'_v39 = v1337 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1338 : string = "option_env!(\"" + v10 + "\").unwrap_or(\"\")"
    let v1339 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1338 
    (* run_target_args'
    let v1522 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1523 : string = "String::from($0)"
    let v1524 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1339 v1523 
    let _run_target_args'_v1522 = v1524 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1525 : string = "String::from($0)"
    let v1526 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1339 v1525 
    let _run_target_args'_v1522 = v1526 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1527 : string = "String::from($0)"
    let v1528 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1339 v1527 
    let _run_target_args'_v1522 = v1528 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1608 : std_string_String = v1339 |> unbox<std_string_String>
    let _run_target_args'_v1522 = v1608 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1699 : std_string_String = v1339 |> unbox<std_string_String>
    let _run_target_args'_v1522 = v1699 
    #endif
#else
    let v1790 : std_string_String = v1339 |> unbox<std_string_String>
    let _run_target_args'_v1522 = v1790 
    #endif
    let v1802 : std_string_String = _run_target_args'_v1522 
    let v1985 : string = "fable_library_rust::String_::fromString($0)"
    let v1986 : string = Fable.Core.RustInterop.emitRustExpr v1802 v1985 
    let _run_target_args'_v39 = v1986 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1989 : string = null |> unbox<string>
    let _run_target_args'_v39 = v1989 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2003 : string = null |> unbox<string>
    let _run_target_args'_v39 = v2003 
    #endif
#else
    let v2017 : string = null |> unbox<string>
    let _run_target_args'_v39 = v2017 
    #endif
    let v2029 : string = _run_target_args'_v39 
    let v2062 : string = "True"
    let v2063 : bool = v2029 <> v2062 
    let v2171 : US6 =
        if v2063 then
            US6_1
        else
            let v2076 : string = $"near_sdk::env::block_timestamp()"
            let v2077 : uint64 = Fable.Core.RustInterop.emitRustExpr () v2076 
            let v2157 : (uint64 -> int64) = int64
            let v2158 : int64 = v2157 v2077
            US6_0(v2158)
    let v2172 : US4 = US4_1
    let _run_target_args'_v5 = struct (v2172, v2171) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v2173 : US4, v2174 : US6) = method6()
    let _run_target_args'_v5 = struct (v2173, v2174) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v2175 : US4, v2176 : US6) = method6()
    let _run_target_args'_v5 = struct (v2175, v2176) 
    #endif
#else
    let struct (v2177 : US4, v2178 : US6) = method6()
    let _run_target_args'_v5 = struct (v2177, v2178) 
    #endif
    let struct (v2179 : US4, v2180 : US6) = _run_target_args'_v5 
    let v2185 : Mut0 = {l0 = 1L} : Mut0
    let v2186 : (string -> unit) = closure12()
    let v2187 : Mut1 = {l0 = v2186} : Mut1
    let v2188 : Mut2 = {l0 = true} : Mut2
    let v2189 : string = ""
    let v2190 : Mut3 = {l0 = v2189} : Mut3
    let v2193 : US5 =
        match v2179 with
        | US4_1 -> (* None *)
            v0
        | US4_0(v2191) -> (* Some *)
            v2191
    let v2194 : Mut4 = {l0 = v2193} : Mut4
    let v2225 : int64 option =
        match v2180 with
        | US6_1 -> (* None *)
            let v2212 : int64 option = None
            v2212
        | US6_0(v2195) -> (* Some *)
            let v2198 : int64 option = Some v2195 
            v2198
    struct (v2185, v2187, v2188, v2190, v2194, v2225)
and closure7 (v0 : US5) () : unit =
    let v1 : bool = TraceState.trace_state.IsNone
    if v1 then
        let struct (v2 : Mut0, v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : int64 option) = method5(v0)
        let v10 : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v10 
        ()
and closure14 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US5 = US5_0
        let struct (v2 : Mut0, v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : int64 option) = method5(v1)
        let v10 : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v10 
        ()
and closure15 () (v0 : int64) : US6 =
    US6_0(v0)
and method19 () : (int64 -> US6) =
    closure15()
and method20 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method21 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method18 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v1630 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1693 : (int64 -> US6) = method19()
    let v1694 : US6 option = v5 |> Option.map v1693 
    let v1755 : US6 = US6_1
    let v1756 : US6 = v1694 |> Option.defaultValue v1755 
    let v2414 : System.DateTime =
        match v1756 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v2379 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2380 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2379 = v2380 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2381 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2379 = v2381 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2384 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v2379 = v2384 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2396 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2379 = v2396 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2397 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2379 = v2397 
            #endif
#else
            let v2398 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2379 = v2398 
            #endif
            let v2399 : System.DateTime = _run_target_args'_v2379 
            v2399
        | US6_0(v1769) -> (* Some *)
            (* run_target_args'
            let v1798 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1799 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1798 = v1799 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1800 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1798 = v1800 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1803 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1798 = v1803 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1815 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1798 = v1815 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1816 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1798 = v1816 
            #endif
#else
            let v1817 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1798 = v1817 
            #endif
            let v1818 : System.DateTime = _run_target_args'_v1798 
            (* run_target_args'
            let v1847 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1848 : (System.DateTime -> int64) = _.Ticks
            let v1849 : int64 = v1848 v1818
            let _run_target_args'_v1847 = v1849 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1850 : (System.DateTime -> int64) = _.Ticks
            let v1851 : int64 = v1850 v1818
            let _run_target_args'_v1847 = v1851 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1854 : int64 = null |> unbox<int64>
            let _run_target_args'_v1847 = v1854 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1866 : (System.DateTime -> int64) = _.Ticks
            let v1867 : int64 = v1866 v1818
            let _run_target_args'_v1847 = v1867 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1868 : (System.DateTime -> int64) = _.Ticks
            let v1869 : int64 = v1868 v1818
            let _run_target_args'_v1847 = v1869 
            #endif
#else
            let v1870 : (System.DateTime -> int64) = _.Ticks
            let v1871 : int64 = v1870 v1818
            let _run_target_args'_v1847 = v1871 
            #endif
            let v1872 : int64 = _run_target_args'_v1847 
            let v2030 : US11 = method17(v1872)
            let v2051 : US6 =
                match v2030 with
                | US11_1(v2048) -> (* Error *)
                    US6_1
                | US11_0(v2046) -> (* Ok *)
                    US6_0(v2046)
            let v2098 : int64 =
                match v2051 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v2095) -> (* Some *)
                    v2095
            let v2110 : int64 = v2098 - v1769
            let v2196 : System.TimeSpan = v2110 |> System.TimeSpan 
            let v2216 : (System.TimeSpan -> int32) = _.Hours
            let v2217 : int32 = v2216 v2196
            let v2237 : (System.TimeSpan -> int32) = _.Minutes
            let v2238 : int32 = v2237 v2196
            let v2258 : (System.TimeSpan -> int32) = _.Seconds
            let v2259 : int32 = v2258 v2196
            let v2279 : (System.TimeSpan -> int32) = _.Milliseconds
            let v2280 : int32 = v2279 v2196
            let v2339 : System.DateTime = System.DateTime (1, 1, 1, v2217, v2238, v2259, v2280)
            v2339
    let v2415 : string = method20()
    let v2443 : bool = v2415 = ""
    let v2445 : string =
        if v2443 then
            let v2444 : string = "M-d-y hh:mm:ss tt"
            v2444
        else
            v2415
    let v2446 : (string -> string) = v2414.ToString
    let v2447 : string = v2446 v2445
    let _run_target_args'_v1630 = v2447 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2549 : (int64 -> US6) = method19()
    let v2550 : US6 option = v5 |> Option.map v2549 
    let v2611 : US6 = US6_1
    let v2612 : US6 = v2550 |> Option.defaultValue v2611 
    let v3270 : System.DateTime =
        match v2612 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v3235 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3236 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3235 = v3236 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3237 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3235 = v3237 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3240 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v3235 = v3240 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3252 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3235 = v3252 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3253 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3235 = v3253 
            #endif
#else
            let v3254 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3235 = v3254 
            #endif
            let v3255 : System.DateTime = _run_target_args'_v3235 
            v3255
        | US6_0(v2625) -> (* Some *)
            (* run_target_args'
            let v2654 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2655 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2654 = v2655 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2656 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2654 = v2656 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2659 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v2654 = v2659 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2671 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2654 = v2671 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2672 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2654 = v2672 
            #endif
#else
            let v2673 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2654 = v2673 
            #endif
            let v2674 : System.DateTime = _run_target_args'_v2654 
            (* run_target_args'
            let v2703 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2704 : (System.DateTime -> int64) = _.Ticks
            let v2705 : int64 = v2704 v2674
            let _run_target_args'_v2703 = v2705 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2706 : (System.DateTime -> int64) = _.Ticks
            let v2707 : int64 = v2706 v2674
            let _run_target_args'_v2703 = v2707 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2710 : int64 = null |> unbox<int64>
            let _run_target_args'_v2703 = v2710 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2722 : (System.DateTime -> int64) = _.Ticks
            let v2723 : int64 = v2722 v2674
            let _run_target_args'_v2703 = v2723 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2724 : (System.DateTime -> int64) = _.Ticks
            let v2725 : int64 = v2724 v2674
            let _run_target_args'_v2703 = v2725 
            #endif
#else
            let v2726 : (System.DateTime -> int64) = _.Ticks
            let v2727 : int64 = v2726 v2674
            let _run_target_args'_v2703 = v2727 
            #endif
            let v2728 : int64 = _run_target_args'_v2703 
            let v2886 : US11 = method17(v2728)
            let v2907 : US6 =
                match v2886 with
                | US11_1(v2904) -> (* Error *)
                    US6_1
                | US11_0(v2902) -> (* Ok *)
                    US6_0(v2902)
            let v2954 : int64 =
                match v2907 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v2951) -> (* Some *)
                    v2951
            let v2966 : int64 = v2954 - v2625
            let v3052 : System.TimeSpan = v2966 |> System.TimeSpan 
            let v3072 : (System.TimeSpan -> int32) = _.Hours
            let v3073 : int32 = v3072 v3052
            let v3093 : (System.TimeSpan -> int32) = _.Minutes
            let v3094 : int32 = v3093 v3052
            let v3114 : (System.TimeSpan -> int32) = _.Seconds
            let v3115 : int32 = v3114 v3052
            let v3135 : (System.TimeSpan -> int32) = _.Milliseconds
            let v3136 : int32 = v3135 v3052
            let v3195 : System.DateTime = System.DateTime (1, 1, 1, v3073, v3094, v3115, v3136)
            v3195
    let v3271 : string = method20()
    let v3299 : bool = v3271 = ""
    let v3301 : string =
        if v3299 then
            let v3300 : string = "M-d-y hh:mm:ss tt"
            v3300
        else
            v3271
    let v3302 : (string -> string) = v3270.ToString
    let v3303 : string = v3302 v3301
    let _run_target_args'_v1630 = v3303 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3343 : string = $"near_sdk::env::block_timestamp()"
    let v3344 : uint64 = Fable.Core.RustInterop.emitRustExpr () v3343 
    let v3407 : (int64 -> US6) = method19()
    let v3408 : US6 option = v5 |> Option.map v3407 
    let v3469 : US6 = US6_1
    let v3470 : US6 = v3408 |> Option.defaultValue v3469 
    let v3578 : uint64 =
        match v3470 with
        | US6_1 -> (* None *)
            v3344
        | US6_0(v3483) -> (* Some *)
            let v3563 : (int64 -> uint64) = uint64
            let v3564 : uint64 = v3563 v3483
            let v3576 : uint64 = v3344 - v3564
            v3576
    let v3579 : uint64 = v3578 / 1000000000UL
    let v3580 : uint64 = v3579 % 60UL
    let v3581 : uint64 = v3579 / 60UL
    let v3582 : uint64 = v3581 % 60UL
    let v3583 : uint64 = v3579 / 3600UL
    let v3584 : uint64 = v3583 % 24UL
    let v3585 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v3586 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v3584, v3582, v3580) v3585 
    let v3587 : string = "fable_library_rust::String_::fromString($0)"
    let v3588 : string = Fable.Core.RustInterop.emitRustExpr v3586 v3587 
    let _run_target_args'_v1630 = v3588 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3651 : (int64 -> US6) = method19()
    let v3652 : US6 option = v5 |> Option.map v3651 
    let v3713 : US6 = US6_1
    let v3714 : US6 = v3652 |> Option.defaultValue v3713 
    let v4372 : System.DateTime =
        match v3714 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v4337 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4338 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4337 = v4338 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4339 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4337 = v4339 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4342 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v4337 = v4342 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4354 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4337 = v4354 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4355 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4337 = v4355 
            #endif
#else
            let v4356 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4337 = v4356 
            #endif
            let v4357 : System.DateTime = _run_target_args'_v4337 
            v4357
        | US6_0(v3727) -> (* Some *)
            (* run_target_args'
            let v3756 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3757 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3756 = v3757 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3758 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3756 = v3758 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3761 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v3756 = v3761 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3773 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3756 = v3773 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3774 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3756 = v3774 
            #endif
#else
            let v3775 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3756 = v3775 
            #endif
            let v3776 : System.DateTime = _run_target_args'_v3756 
            (* run_target_args'
            let v3805 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3806 : (System.DateTime -> int64) = _.Ticks
            let v3807 : int64 = v3806 v3776
            let _run_target_args'_v3805 = v3807 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3808 : (System.DateTime -> int64) = _.Ticks
            let v3809 : int64 = v3808 v3776
            let _run_target_args'_v3805 = v3809 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3812 : int64 = null |> unbox<int64>
            let _run_target_args'_v3805 = v3812 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3824 : (System.DateTime -> int64) = _.Ticks
            let v3825 : int64 = v3824 v3776
            let _run_target_args'_v3805 = v3825 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3826 : (System.DateTime -> int64) = _.Ticks
            let v3827 : int64 = v3826 v3776
            let _run_target_args'_v3805 = v3827 
            #endif
#else
            let v3828 : (System.DateTime -> int64) = _.Ticks
            let v3829 : int64 = v3828 v3776
            let _run_target_args'_v3805 = v3829 
            #endif
            let v3830 : int64 = _run_target_args'_v3805 
            let v3988 : US11 = method17(v3830)
            let v4009 : US6 =
                match v3988 with
                | US11_1(v4006) -> (* Error *)
                    US6_1
                | US11_0(v4004) -> (* Ok *)
                    US6_0(v4004)
            let v4056 : int64 =
                match v4009 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v4053) -> (* Some *)
                    v4053
            let v4068 : int64 = v4056 - v3727
            let v4154 : System.TimeSpan = v4068 |> System.TimeSpan 
            let v4174 : (System.TimeSpan -> int32) = _.Hours
            let v4175 : int32 = v4174 v4154
            let v4195 : (System.TimeSpan -> int32) = _.Minutes
            let v4196 : int32 = v4195 v4154
            let v4216 : (System.TimeSpan -> int32) = _.Seconds
            let v4217 : int32 = v4216 v4154
            let v4237 : (System.TimeSpan -> int32) = _.Milliseconds
            let v4238 : int32 = v4237 v4154
            let v4297 : System.DateTime = System.DateTime (1, 1, 1, v4175, v4196, v4217, v4238)
            v4297
    let v4373 : string = method21()
    let v4401 : bool = v4373 = ""
    let v4403 : string =
        if v4401 then
            let v4402 : string = "M-d-y hh:mm:ss tt"
            v4402
        else
            v4373
    let v4404 : (string -> string) = v4372.ToString
    let v4405 : string = v4404 v4403
    let _run_target_args'_v1630 = v4405 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4507 : (int64 -> US6) = method19()
    let v4508 : US6 option = v5 |> Option.map v4507 
    let v4569 : US6 = US6_1
    let v4570 : US6 = v4508 |> Option.defaultValue v4569 
    let v5228 : System.DateTime =
        match v4570 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v5193 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v5194 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5193 = v5194 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v5195 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5193 = v5195 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v5198 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v5193 = v5198 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v5210 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5193 = v5210 
            #endif
#if FABLE_COMPILER_PYTHON
            let v5211 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5193 = v5211 
            #endif
#else
            let v5212 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5193 = v5212 
            #endif
            let v5213 : System.DateTime = _run_target_args'_v5193 
            v5213
        | US6_0(v4583) -> (* Some *)
            (* run_target_args'
            let v4612 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4613 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4612 = v4613 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4614 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4612 = v4614 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4617 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v4612 = v4617 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4629 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4612 = v4629 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4630 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4612 = v4630 
            #endif
#else
            let v4631 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4612 = v4631 
            #endif
            let v4632 : System.DateTime = _run_target_args'_v4612 
            (* run_target_args'
            let v4661 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4662 : (System.DateTime -> int64) = _.Ticks
            let v4663 : int64 = v4662 v4632
            let _run_target_args'_v4661 = v4663 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4664 : (System.DateTime -> int64) = _.Ticks
            let v4665 : int64 = v4664 v4632
            let _run_target_args'_v4661 = v4665 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4668 : int64 = null |> unbox<int64>
            let _run_target_args'_v4661 = v4668 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4680 : (System.DateTime -> int64) = _.Ticks
            let v4681 : int64 = v4680 v4632
            let _run_target_args'_v4661 = v4681 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4682 : (System.DateTime -> int64) = _.Ticks
            let v4683 : int64 = v4682 v4632
            let _run_target_args'_v4661 = v4683 
            #endif
#else
            let v4684 : (System.DateTime -> int64) = _.Ticks
            let v4685 : int64 = v4684 v4632
            let _run_target_args'_v4661 = v4685 
            #endif
            let v4686 : int64 = _run_target_args'_v4661 
            let v4844 : US11 = method17(v4686)
            let v4865 : US6 =
                match v4844 with
                | US11_1(v4862) -> (* Error *)
                    US6_1
                | US11_0(v4860) -> (* Ok *)
                    US6_0(v4860)
            let v4912 : int64 =
                match v4865 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v4909) -> (* Some *)
                    v4909
            let v4924 : int64 = v4912 - v4583
            let v5010 : System.TimeSpan = v4924 |> System.TimeSpan 
            let v5030 : (System.TimeSpan -> int32) = _.Hours
            let v5031 : int32 = v5030 v5010
            let v5051 : (System.TimeSpan -> int32) = _.Minutes
            let v5052 : int32 = v5051 v5010
            let v5072 : (System.TimeSpan -> int32) = _.Seconds
            let v5073 : int32 = v5072 v5010
            let v5093 : (System.TimeSpan -> int32) = _.Milliseconds
            let v5094 : int32 = v5093 v5010
            let v5153 : System.DateTime = System.DateTime (1, 1, 1, v5031, v5052, v5073, v5094)
            v5153
    let v5229 : string = method21()
    let v5257 : bool = v5229 = ""
    let v5259 : string =
        if v5257 then
            let v5258 : string = "M-d-y hh:mm:ss tt"
            v5258
        else
            v5229
    let v5260 : (string -> string) = v5228.ToString
    let v5261 : string = v5260 v5259
    let _run_target_args'_v1630 = v5261 
    #endif
#else
    let v5363 : (int64 -> US6) = method19()
    let v5364 : US6 option = v5 |> Option.map v5363 
    let v5425 : US6 = US6_1
    let v5426 : US6 = v5364 |> Option.defaultValue v5425 
    let v6084 : System.DateTime =
        match v5426 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v6049 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6050 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v6049 = v6050 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6051 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v6049 = v6051 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6054 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v6049 = v6054 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6066 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v6049 = v6066 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6067 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v6049 = v6067 
            #endif
#else
            let v6068 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v6049 = v6068 
            #endif
            let v6069 : System.DateTime = _run_target_args'_v6049 
            v6069
        | US6_0(v5439) -> (* Some *)
            (* run_target_args'
            let v5468 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v5469 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5468 = v5469 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v5470 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5468 = v5470 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v5473 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v5468 = v5473 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v5485 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5468 = v5485 
            #endif
#if FABLE_COMPILER_PYTHON
            let v5486 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5468 = v5486 
            #endif
#else
            let v5487 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v5468 = v5487 
            #endif
            let v5488 : System.DateTime = _run_target_args'_v5468 
            (* run_target_args'
            let v5517 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v5518 : (System.DateTime -> int64) = _.Ticks
            let v5519 : int64 = v5518 v5488
            let _run_target_args'_v5517 = v5519 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v5520 : (System.DateTime -> int64) = _.Ticks
            let v5521 : int64 = v5520 v5488
            let _run_target_args'_v5517 = v5521 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v5524 : int64 = null |> unbox<int64>
            let _run_target_args'_v5517 = v5524 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v5536 : (System.DateTime -> int64) = _.Ticks
            let v5537 : int64 = v5536 v5488
            let _run_target_args'_v5517 = v5537 
            #endif
#if FABLE_COMPILER_PYTHON
            let v5538 : (System.DateTime -> int64) = _.Ticks
            let v5539 : int64 = v5538 v5488
            let _run_target_args'_v5517 = v5539 
            #endif
#else
            let v5540 : (System.DateTime -> int64) = _.Ticks
            let v5541 : int64 = v5540 v5488
            let _run_target_args'_v5517 = v5541 
            #endif
            let v5542 : int64 = _run_target_args'_v5517 
            let v5700 : US11 = method17(v5542)
            let v5721 : US6 =
                match v5700 with
                | US11_1(v5718) -> (* Error *)
                    US6_1
                | US11_0(v5716) -> (* Ok *)
                    US6_0(v5716)
            let v5768 : int64 =
                match v5721 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v5765) -> (* Some *)
                    v5765
            let v5780 : int64 = v5768 - v5439
            let v5866 : System.TimeSpan = v5780 |> System.TimeSpan 
            let v5886 : (System.TimeSpan -> int32) = _.Hours
            let v5887 : int32 = v5886 v5866
            let v5907 : (System.TimeSpan -> int32) = _.Minutes
            let v5908 : int32 = v5907 v5866
            let v5928 : (System.TimeSpan -> int32) = _.Seconds
            let v5929 : int32 = v5928 v5866
            let v5949 : (System.TimeSpan -> int32) = _.Milliseconds
            let v5950 : int32 = v5949 v5866
            let v6009 : System.DateTime = System.DateTime (1, 1, 1, v5887, v5908, v5929, v5950)
            v6009
    let v6085 : string = method21()
    let v6113 : bool = v6085 = ""
    let v6115 : string =
        if v6113 then
            let v6114 : string = "M-d-y hh:mm:ss tt"
            v6114
        else
            v6085
    let v6116 : (string -> string) = v6084.ToString
    let v6117 : string = v6116 v6115
    let _run_target_args'_v1630 = v6117 
    #endif
    let v6157 : string = _run_target_args'_v1630 
    v6157
and method23 (v0 : char) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    let v41 : string = $"{v0}"
    method13(v12, v41)
    let v164 : string = v12.l0
    v164
and method22 () : string =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "inline_colorization::color_bright_black"
    let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3 
    (* run_target_args'
    let v187 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v188 : string = "String::from($0)"
    let v189 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v188 
    let _run_target_args'_v187 = v189 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v190 : string = "String::from($0)"
    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v190 
    let _run_target_args'_v187 = v191 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v192 : string = "String::from($0)"
    let v193 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v192 
    let _run_target_args'_v187 = v193 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v273 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v273 
    #endif
#if FABLE_COMPILER_PYTHON
    let v364 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v364 
    #endif
#else
    let v455 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v455 
    #endif
    let v467 : std_string_String = _run_target_args'_v187 
    let v650 : string = "fable_library_rust::String_::fromString($0)"
    let v651 : string = Fable.Core.RustInterop.emitRustExpr v467 v650 
    let _run_target_args'_v2 = v651 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v652 : string = "inline_colorization::color_bright_black"
    let v653 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v652 
    (* run_target_args'
    let v836 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v837 : string = "String::from($0)"
    let v838 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v837 
    let _run_target_args'_v836 = v838 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v839 : string = "String::from($0)"
    let v840 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v839 
    let _run_target_args'_v836 = v840 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v841 : string = "String::from($0)"
    let v842 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v841 
    let _run_target_args'_v836 = v842 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v922 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v922 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1013 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v1013 
    #endif
#else
    let v1104 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v1104 
    #endif
    let v1116 : std_string_String = _run_target_args'_v836 
    let v1299 : string = "fable_library_rust::String_::fromString($0)"
    let v1300 : string = Fable.Core.RustInterop.emitRustExpr v1116 v1299 
    let _run_target_args'_v2 = v1300 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1301 : string = "inline_colorization::color_bright_black"
    let v1302 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1301 
    (* run_target_args'
    let v1485 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1486 : string = "String::from($0)"
    let v1487 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1486 
    let _run_target_args'_v1485 = v1487 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1488 : string = "String::from($0)"
    let v1489 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1488 
    let _run_target_args'_v1485 = v1489 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1490 : string = "String::from($0)"
    let v1491 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1490 
    let _run_target_args'_v1485 = v1491 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1571 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1571 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1662 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1662 
    #endif
#else
    let v1753 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1753 
    #endif
    let v1765 : std_string_String = _run_target_args'_v1485 
    let v1948 : string = "fable_library_rust::String_::fromString($0)"
    let v1949 : string = Fable.Core.RustInterop.emitRustExpr v1765 v1948 
    let _run_target_args'_v2 = v1949 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1950 : string = "\u001b[90m"
    let _run_target_args'_v2 = v1950 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1951 : string = "\u001b[90m"
    let _run_target_args'_v2 = v1951 
    #endif
#else
    let v1952 : string = "\u001b[90m"
    let _run_target_args'_v2 = v1952 
    #endif
    let v1953 : string = _run_target_args'_v2 
    
    
    
    
    
    let v1960 : string = "Verbose"
    let v1961 : (unit -> string) = v1960.ToLower
    let v1962 : string = v1961 ()
    let v1974 : char = v1962.[int 0]
    let v1975 : string = method23(v1974)
    let v1978 : string = v1953 + v1975 
    (* run_target_args'
    let v1992 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1993 : string = "inline_colorization::color_reset"
    let v1994 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1993 
    (* run_target_args'
    let v2177 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2178 : string = "String::from($0)"
    let v2179 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2178 
    let _run_target_args'_v2177 = v2179 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2180 : string = "String::from($0)"
    let v2181 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2180 
    let _run_target_args'_v2177 = v2181 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2182 : string = "String::from($0)"
    let v2183 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2182 
    let _run_target_args'_v2177 = v2183 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2263 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2263 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2354 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2354 
    #endif
#else
    let v2445 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2445 
    #endif
    let v2457 : std_string_String = _run_target_args'_v2177 
    let v2640 : string = "fable_library_rust::String_::fromString($0)"
    let v2641 : string = Fable.Core.RustInterop.emitRustExpr v2457 v2640 
    let _run_target_args'_v1992 = v2641 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2642 : string = "inline_colorization::color_reset"
    let v2643 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2642 
    (* run_target_args'
    let v2826 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2827 : string = "String::from($0)"
    let v2828 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2827 
    let _run_target_args'_v2826 = v2828 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2829 : string = "String::from($0)"
    let v2830 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2829 
    let _run_target_args'_v2826 = v2830 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2831 : string = "String::from($0)"
    let v2832 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2831 
    let _run_target_args'_v2826 = v2832 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2912 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v2912 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3003 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v3003 
    #endif
#else
    let v3094 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v3094 
    #endif
    let v3106 : std_string_String = _run_target_args'_v2826 
    let v3289 : string = "fable_library_rust::String_::fromString($0)"
    let v3290 : string = Fable.Core.RustInterop.emitRustExpr v3106 v3289 
    let _run_target_args'_v1992 = v3290 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3291 : string = "inline_colorization::color_reset"
    let v3292 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3291 
    (* run_target_args'
    let v3475 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3476 : string = "String::from($0)"
    let v3477 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3476 
    let _run_target_args'_v3475 = v3477 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3478 : string = "String::from($0)"
    let v3479 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3478 
    let _run_target_args'_v3475 = v3479 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3480 : string = "String::from($0)"
    let v3481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3480 
    let _run_target_args'_v3475 = v3481 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3561 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3561 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3652 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3652 
    #endif
#else
    let v3743 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3743 
    #endif
    let v3755 : std_string_String = _run_target_args'_v3475 
    let v3938 : string = "fable_library_rust::String_::fromString($0)"
    let v3939 : string = Fable.Core.RustInterop.emitRustExpr v3755 v3938 
    let _run_target_args'_v1992 = v3939 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3940 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3940 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3941 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3941 
    #endif
#else
    let v3942 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3942 
    #endif
    let v3943 : string = _run_target_args'_v1992 
    let v3948 : string = v1978 + v3943 
    v3948
and method25 (v0 : int64) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    let v41 : string = $"{v0}"
    method13(v12, v41)
    let v164 : string = v12.l0
    v164
and method27 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "{ "
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method28 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "args"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method29 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = " = "
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method30 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = " }"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method26 (v0 : (string [])) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    method27(v12)
    method28(v12)
    method29(v12)
    let v423 : string = $"%A{v0}"
    method13(v12, v423)
    method30(v12)
    let v681 : string = v12.l0
    v681
and method33 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 4L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v19 : US13 =
            if v3 then
                US13_0(' ')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US13_0('\t')
                else
                    let v8 : int64 = v5 - 1L
                    let v9 : bool = v8 = 0L
                    if v9 then
                        US13_0('\r')
                    else
                        let v11 : int64 = v8 - 1L
                        let v12 : bool = v11 = 0L
                        if v12 then
                            US13_0('\n')
                        else
                            let v14 : int64 = v11 - 1L
                            US13_1
        let v23 : char =
            match v19 with
            | US13_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US13_0(v20) -> (* Some *)
                v20
        let v24 : bool = v0 = v23
        if v24 then
            true
        else
            let v25 : int64 = v1 + 1L
            method33(v0, v25)
and method32 (v0 : string, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v2 >= v1
    if v3 then
        v1
    else
        let v4 : char = v0.[int v2]
        let v5 : int64 = 0L
        let v6 : bool = method33(v4, v5)
        if v6 then
            let v7 : int32 = v2 + 1
            method32(v0, v1, v7)
        else
            v2
and method35 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 2L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v11 : US13 =
            if v3 then
                US13_0(' ')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US13_0('/')
                else
                    let v8 : int64 = v5 - 1L
                    US13_1
        let v15 : char =
            match v11 with
            | US13_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US13_0(v12) -> (* Some *)
                v12
        let v16 : bool = v0 = v15
        if v16 then
            true
        else
            let v17 : int64 = v1 + 1L
            method35(v0, v17)
and method34 (v0 : string, v1 : int32) : int32 =
    let v2 : bool = v1 <= 0
    if v2 then
        0
    else
        let v3 : int32 = v1 - 1
        let v4 : char = v0.[int v3]
        let v5 : int64 = 0L
        let v6 : bool = method35(v4, v5)
        if v6 then
            method34(v0, v3)
        else
            v3
and method31 (v0 : string) : string =
    let v1 : int32 = v0.Length
    let v2 : int32 = 0
    let v3 : int32 = method32(v0, v1, v2)
    let v716 : string = v0.[int v3..int v1]
    let v729 : int32 = v716.Length
    let v730 : int32 = method34(v716, v729)
    let v1443 : string = v716.[int 0..int v730]
    v1443
and method24 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : (string [])) : string =
    let v9 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v27 : string = method25(v9)
    let v30 : string = v15 + v27 
    let v44 : string = v30 + v7 
    let v58 : string = v44 + v14 
    let v74 : string = "spiral_wasm.main"
    let v75 : string = v58 + v74 
    let v91 : string = " / "
    let v92 : string = v75 + v91 
    let v104 : string = method26(v8)
    let v107 : string = v92 + v104 
    method31(v107)
and closure16 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure18 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure17 () (v0 : string) : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure18(v0)
    let v33 : unit = (fun () -> v32 (); v31) ()
    ()
and method36 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and closure13 (v0 : (string [])) () : unit =
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure14()
    let v63 : unit = (fun () -> v62 (); v61) ()
    let struct (v112 : Mut0, v113 : Mut1, v114 : Mut2, v115 : Mut3, v116 : Mut4, v117 : int64 option) = TraceState.trace_state.Value
    let v159 : US5 = v116.l0
    let v160 : bool = v114.l0
    let v161 : bool = v160 = false
    let v164 : bool =
        if v161 then
            false
        else
            let v162 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v159
            let v163 : bool = 0 >= v162
            v163
    let v165 : bool = v164 = false
    let v1234 : US12 =
        if v165 then
            US12_1
        else
            let v227 : unit = ()
            let v228 : unit = (fun () -> v62 (); v227) ()
            let struct (v277 : Mut0, v278 : Mut1, v279 : Mut2, v280 : Mut3, v281 : Mut4, v282 : int64 option) = TraceState.trace_state.Value
            let v324 : string = method18(v277, v278, v279, v280, v281, v282)
            let v325 : string = method22()
            let v326 : string = method24(v277, v278, v279, v280, v281, v282, v324, v325, v0)
            let v387 : unit = ()
            let v388 : unit = (fun () -> v62 (); v387) ()
            let struct (v437 : Mut0, v438 : Mut1, v439 : Mut2, v440 : Mut3, v441 : Mut4, v442 : int64 option) = TraceState.trace_state.Value
            let v488 : unit = ()
            let v489 : (unit -> unit) = closure16(v437)
            let v490 : unit = (fun () -> v489 (); v488) ()
            let v498 : (string -> unit) = closure17()
            (* run_target_args'
            let v499 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v500 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v500 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v501 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v502 : string = v440.l0
            let v503 : bool = v502 = ""
            let v539 : string =
                if v503 then
                    v326
                else
                    let v504 : bool = v326 = ""
                    if v504 then
                        let v505 : string = v440.l0
                        v505
                    else
                        let v506 : string = v440.l0
                        let v511 : string = "\n"
                        let v512 : string = v506 + v511 
                        let v526 : string = v512 + v326 
                        v526
            (* run_target_args'
            let v722 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v723 : string = "&*$0"
            let v724 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v723 
            let _run_target_args'_v722 = v724 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v725 : string = "&*$0"
            let v726 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v725 
            let _run_target_args'_v722 = v726 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v727 : string = "&*$0"
            let v728 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v727 
            let _run_target_args'_v722 = v728 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v808 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v808 
            #endif
#if FABLE_COMPILER_PYTHON
            let v899 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v899 
            #endif
#else
            let v990 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v990 
            #endif
            let v1002 : Ref<Str> = _run_target_args'_v722 
            let v1185 : string = $"$0.chars()"
            let v1186 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1002 v1185 
            let v1187 : string = "$0"
            let v1188 : _ = Fable.Core.RustInterop.emitRustExpr v1186 v1187 
            let v1189 : string = "$0.collect::<Vec<_>>()"
            let v1190 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1188 v1189 
            let v1191 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1192 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1190 v1191 
            let v1193 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1194 : bool = Fable.Core.RustInterop.emitRustExpr v1192 v1193 
            let v1195 : string = "x"
            let v1196 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1195 
            let v1197 : string = "String::from_iter($0)"
            let v1198 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1196 v1197 
            let v1199 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1200 : bool = Fable.Core.RustInterop.emitRustExpr v1198 v1199 
            let v1201 : string = "_vec_map"
            let v1202 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1201 
            let v1203 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1204 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1202 v1203 
            let v1205 : int32 = v1204.Length
            let v1210 : string = ""
            let v1211 : bool = v326 <> v1210 
            let v1224 : bool =
                if v1211 then
                    let v1223 : bool = v1205 <= 1
                    v1223
                else
                    false
            if v1224 then
                v440.l0 <- v539
                ()
            else
                v440.l0 <- v1210
                let v1225 : Mut5 = {l0 = 0} : Mut5
                while method36(v1205, v1225) do
                    let v1227 : int32 = v1225.l0
                    let v1228 : std_string_String = v1204.[int v1227]
                    let v1229 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1230 : bool = Fable.Core.RustInterop.emitRustExpr v1228 v1229 
                    let v1231 : int32 = v1227 + 1
                    v1225.l0 <- v1231
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v498 v326
            #endif
#if FABLE_COMPILER_PYTHON
            v498 v326
            #endif
#else
            v498 v326
            #endif
            // run_target_args' is_unit
            let v1232 : (string -> unit) = v438.l0
            v1232 v326
            US12_0(v437, v438, v439, v440, v441, v442)
    let v1275 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1275 
    ()
and method37 () : string =
    let v0 : string = "exception"
    v0
and method40 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 1L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v7 : US13 =
            if v3 then
                US13_0('\\')
            else
                let v5 : int64 = v1 - 1L
                US13_1
        let v11 : char =
            match v7 with
            | US13_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US13_0(v8) -> (* Some *)
                v8
        let v12 : bool = v0 = v11
        if v12 then
            true
        else
            let v13 : int64 = v1 + 1L
            method40(v0, v13)
and method39 (v0 : string, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v2 >= v1
    if v3 then
        v1
    else
        let v4 : char = v0.[int v2]
        let v5 : int64 = 0L
        let v6 : bool = method40(v4, v5)
        if v6 then
            let v7 : int32 = v2 + 1
            method39(v0, v1, v7)
        else
            v2
and method41 (v0 : string, v1 : int32) : int32 =
    let v2 : bool = v1 <= 0
    if v2 then
        0
    else
        let v3 : int32 = v1 - 1
        let v4 : char = v0.[int v3]
        let v5 : int64 = 0L
        let v6 : bool = method40(v4, v5)
        if v6 then
            method41(v0, v3)
        else
            v3
and closure19 () (v0 : std_string_String) : string =
    let v1 : string = "fable_library_rust::String_::fromString($0)"
    let v2 : string = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : int32 = v2.Length
    let v4 : int32 = 0
    let v5 : int32 = method39(v2, v3, v4)
    let v718 : string = v2.[int v5..int v3]
    let v731 : int32 = v718.Length
    let v732 : int32 = method41(v718, v731)
    let v1445 : string = v718.[int 0..int v732]
    v1445
and method38 () : (std_string_String -> string) =
    closure19()
and method43 () : string =
    let v0 : string = "wasm"
    v0
and method46 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "wasm_path"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method45 (v0 : string) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    method27(v12)
    method46(v12)
    method29(v12)
    method13(v12, v0)
    method30(v12)
    let v634 : string = v12.l0
    v634
and method44 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v27 : string = method25(v9)
    let v30 : string = v15 + v27 
    let v44 : string = v30 + v7 
    let v58 : string = v44 + v14 
    let v74 : string = "spiral_wasm.run"
    let v75 : string = v58 + v74 
    let v91 : string = " / "
    let v92 : string = v75 + v91 
    let v104 : string = method45(v8)
    let v107 : string = v92 + v104 
    method31(v107)
and closure20 (v0 : string) () : unit =
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure14()
    let v63 : unit = (fun () -> v62 (); v61) ()
    let struct (v112 : Mut0, v113 : Mut1, v114 : Mut2, v115 : Mut3, v116 : Mut4, v117 : int64 option) = TraceState.trace_state.Value
    let v159 : US5 = v116.l0
    let v160 : bool = v114.l0
    let v161 : bool = v160 = false
    let v164 : bool =
        if v161 then
            false
        else
            let v162 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v159
            let v163 : bool = 0 >= v162
            v163
    let v165 : bool = v164 = false
    let v1234 : US12 =
        if v165 then
            US12_1
        else
            let v227 : unit = ()
            let v228 : unit = (fun () -> v62 (); v227) ()
            let struct (v277 : Mut0, v278 : Mut1, v279 : Mut2, v280 : Mut3, v281 : Mut4, v282 : int64 option) = TraceState.trace_state.Value
            let v324 : string = method18(v277, v278, v279, v280, v281, v282)
            let v325 : string = method22()
            let v326 : string = method44(v277, v278, v279, v280, v281, v282, v324, v325, v0)
            let v387 : unit = ()
            let v388 : unit = (fun () -> v62 (); v387) ()
            let struct (v437 : Mut0, v438 : Mut1, v439 : Mut2, v440 : Mut3, v441 : Mut4, v442 : int64 option) = TraceState.trace_state.Value
            let v488 : unit = ()
            let v489 : (unit -> unit) = closure16(v437)
            let v490 : unit = (fun () -> v489 (); v488) ()
            let v498 : (string -> unit) = closure17()
            (* run_target_args'
            let v499 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v500 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v500 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v501 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v502 : string = v440.l0
            let v503 : bool = v502 = ""
            let v539 : string =
                if v503 then
                    v326
                else
                    let v504 : bool = v326 = ""
                    if v504 then
                        let v505 : string = v440.l0
                        v505
                    else
                        let v506 : string = v440.l0
                        let v511 : string = "\n"
                        let v512 : string = v506 + v511 
                        let v526 : string = v512 + v326 
                        v526
            (* run_target_args'
            let v722 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v723 : string = "&*$0"
            let v724 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v723 
            let _run_target_args'_v722 = v724 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v725 : string = "&*$0"
            let v726 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v725 
            let _run_target_args'_v722 = v726 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v727 : string = "&*$0"
            let v728 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v727 
            let _run_target_args'_v722 = v728 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v808 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v808 
            #endif
#if FABLE_COMPILER_PYTHON
            let v899 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v899 
            #endif
#else
            let v990 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v990 
            #endif
            let v1002 : Ref<Str> = _run_target_args'_v722 
            let v1185 : string = $"$0.chars()"
            let v1186 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1002 v1185 
            let v1187 : string = "$0"
            let v1188 : _ = Fable.Core.RustInterop.emitRustExpr v1186 v1187 
            let v1189 : string = "$0.collect::<Vec<_>>()"
            let v1190 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1188 v1189 
            let v1191 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1192 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1190 v1191 
            let v1193 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1194 : bool = Fable.Core.RustInterop.emitRustExpr v1192 v1193 
            let v1195 : string = "x"
            let v1196 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1195 
            let v1197 : string = "String::from_iter($0)"
            let v1198 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1196 v1197 
            let v1199 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1200 : bool = Fable.Core.RustInterop.emitRustExpr v1198 v1199 
            let v1201 : string = "_vec_map"
            let v1202 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1201 
            let v1203 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1204 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1202 v1203 
            let v1205 : int32 = v1204.Length
            let v1210 : string = ""
            let v1211 : bool = v326 <> v1210 
            let v1224 : bool =
                if v1211 then
                    let v1223 : bool = v1205 <= 1
                    v1223
                else
                    false
            if v1224 then
                v440.l0 <- v539
                ()
            else
                v440.l0 <- v1210
                let v1225 : Mut5 = {l0 = 0} : Mut5
                while method36(v1205, v1225) do
                    let v1227 : int32 = v1225.l0
                    let v1228 : std_string_String = v1204.[int v1227]
                    let v1229 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1230 : bool = Fable.Core.RustInterop.emitRustExpr v1228 v1229 
                    let v1231 : int32 = v1227 + 1
                    v1225.l0 <- v1231
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v498 v326
            #endif
#if FABLE_COMPILER_PYTHON
            v498 v326
            #endif
#else
            v498 v326
            #endif
            // run_target_args' is_unit
            let v1232 : (string -> unit) = v438.l0
            v1232 v326
            US12_0(v437, v438, v439, v440, v441, v442)
    let v1275 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1275 
    ()
and method51 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "retry"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method52 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "; "
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method53 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "worker"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method54 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "contract"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method50 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) : string =
    let v3 : string = method12()
    let v14 : Mut3 = {l0 = v3} : Mut3
    method27(v14)
    method51(v14)
    method29(v14)
    let v418 : string = $"{v0}"
    method13(v14, v418)
    method52(v14)
    method53(v14)
    method29(v14)
    (* run_target_args'
    let v944 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v945 : string = "format!(\"{:#?}\", $0)"
    let v946 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v945 
    let v947 : string = "fable_library_rust::String_::fromString($0)"
    let v948 : string = Fable.Core.RustInterop.emitRustExpr v946 v947 
    let _run_target_args'_v944 = v948 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v949 : string = "format!(\"{:#?}\", $0)"
    let v950 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v949 
    let v951 : string = "fable_library_rust::String_::fromString($0)"
    let v952 : string = Fable.Core.RustInterop.emitRustExpr v950 v951 
    let _run_target_args'_v944 = v952 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v953 : string = "format!(\"{:#?}\", $0)"
    let v954 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v953 
    let v955 : string = "fable_library_rust::String_::fromString($0)"
    let v956 : string = Fable.Core.RustInterop.emitRustExpr v954 v955 
    let _run_target_args'_v944 = v956 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v959 : string = $"%A{v1}"
    let _run_target_args'_v944 = v959 
    #endif
#if FABLE_COMPILER_PYTHON
    let v973 : string = $"%A{v1}"
    let _run_target_args'_v944 = v973 
    #endif
#else
    let v987 : string = $"%A{v1}"
    let _run_target_args'_v944 = v987 
    #endif
    let v999 : string = _run_target_args'_v944 
    method13(v14, v999)
    method52(v14)
    method54(v14)
    method29(v14)
    (* run_target_args'
    let v1552 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1553 : string = "format!(\"{:#?}\", $0)"
    let v1554 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v1553 
    let v1555 : string = "fable_library_rust::String_::fromString($0)"
    let v1556 : string = Fable.Core.RustInterop.emitRustExpr v1554 v1555 
    let _run_target_args'_v1552 = v1556 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1557 : string = "format!(\"{:#?}\", $0)"
    let v1558 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v1557 
    let v1559 : string = "fable_library_rust::String_::fromString($0)"
    let v1560 : string = Fable.Core.RustInterop.emitRustExpr v1558 v1559 
    let _run_target_args'_v1552 = v1560 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1561 : string = "format!(\"{:#?}\", $0)"
    let v1562 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v1561 
    let v1563 : string = "fable_library_rust::String_::fromString($0)"
    let v1564 : string = Fable.Core.RustInterop.emitRustExpr v1562 v1563 
    let _run_target_args'_v1552 = v1564 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1567 : string = $"%A{v2}"
    let _run_target_args'_v1552 = v1567 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1581 : string = $"%A{v2}"
    let _run_target_args'_v1552 = v1581 
    #endif
#else
    let v1595 : string = $"%A{v2}"
    let _run_target_args'_v1552 = v1595 
    #endif
    let v1607 : string = _run_target_args'_v1552 
    method13(v14, v1607)
    method30(v14)
    let v1882 : string = v14.l0
    v1882
and method49 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v10 : near_workspaces_Contract) : string =
    let v11 : int64 = v0.l0
    let v16 : string = " "
    let v17 : string = v6 + v16 
    let v29 : string = method25(v11)
    let v32 : string = v17 + v29 
    let v46 : string = v32 + v7 
    let v60 : string = v46 + v16 
    let v76 : string = "spiral_wasm.run"
    let v77 : string = v60 + v76 
    let v93 : string = " / "
    let v94 : string = v77 + v93 
    let v106 : string = method50(v8, v9, v10)
    let v109 : string = v94 + v106 
    method31(v109)
and closure21 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) () : unit =
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure14()
    let v65 : unit = (fun () -> v64 (); v63) ()
    let struct (v114 : Mut0, v115 : Mut1, v116 : Mut2, v117 : Mut3, v118 : Mut4, v119 : int64 option) = TraceState.trace_state.Value
    let v161 : US5 = v118.l0
    let v162 : bool = v116.l0
    let v163 : bool = v162 = false
    let v166 : bool =
        if v163 then
            false
        else
            let v164 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v161
            let v165 : bool = 0 >= v164
            v165
    let v167 : bool = v166 = false
    let v1236 : US12 =
        if v167 then
            US12_1
        else
            let v229 : unit = ()
            let v230 : unit = (fun () -> v64 (); v229) ()
            let struct (v279 : Mut0, v280 : Mut1, v281 : Mut2, v282 : Mut3, v283 : Mut4, v284 : int64 option) = TraceState.trace_state.Value
            let v326 : string = method18(v279, v280, v281, v282, v283, v284)
            let v327 : string = method22()
            let v328 : string = method49(v279, v280, v281, v282, v283, v284, v326, v327, v0, v1, v2)
            let v389 : unit = ()
            let v390 : unit = (fun () -> v64 (); v389) ()
            let struct (v439 : Mut0, v440 : Mut1, v441 : Mut2, v442 : Mut3, v443 : Mut4, v444 : int64 option) = TraceState.trace_state.Value
            let v490 : unit = ()
            let v491 : (unit -> unit) = closure16(v439)
            let v492 : unit = (fun () -> v491 (); v490) ()
            let v500 : (string -> unit) = closure17()
            (* run_target_args'
            let v501 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v502 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v328 v502 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v503 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v328 v503 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v504 : string = v442.l0
            let v505 : bool = v504 = ""
            let v541 : string =
                if v505 then
                    v328
                else
                    let v506 : bool = v328 = ""
                    if v506 then
                        let v507 : string = v442.l0
                        v507
                    else
                        let v508 : string = v442.l0
                        let v513 : string = "\n"
                        let v514 : string = v508 + v513 
                        let v528 : string = v514 + v328 
                        v528
            (* run_target_args'
            let v724 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v725 : string = "&*$0"
            let v726 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v541 v725 
            let _run_target_args'_v724 = v726 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v727 : string = "&*$0"
            let v728 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v541 v727 
            let _run_target_args'_v724 = v728 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v729 : string = "&*$0"
            let v730 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v541 v729 
            let _run_target_args'_v724 = v730 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v810 : Ref<Str> = v541 |> unbox<Ref<Str>>
            let _run_target_args'_v724 = v810 
            #endif
#if FABLE_COMPILER_PYTHON
            let v901 : Ref<Str> = v541 |> unbox<Ref<Str>>
            let _run_target_args'_v724 = v901 
            #endif
#else
            let v992 : Ref<Str> = v541 |> unbox<Ref<Str>>
            let _run_target_args'_v724 = v992 
            #endif
            let v1004 : Ref<Str> = _run_target_args'_v724 
            let v1187 : string = $"$0.chars()"
            let v1188 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1004 v1187 
            let v1189 : string = "$0"
            let v1190 : _ = Fable.Core.RustInterop.emitRustExpr v1188 v1189 
            let v1191 : string = "$0.collect::<Vec<_>>()"
            let v1192 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1190 v1191 
            let v1193 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1194 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1192 v1193 
            let v1195 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1196 : bool = Fable.Core.RustInterop.emitRustExpr v1194 v1195 
            let v1197 : string = "x"
            let v1198 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1197 
            let v1199 : string = "String::from_iter($0)"
            let v1200 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1198 v1199 
            let v1201 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1202 : bool = Fable.Core.RustInterop.emitRustExpr v1200 v1201 
            let v1203 : string = "_vec_map"
            let v1204 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1203 
            let v1205 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1206 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1204 v1205 
            let v1207 : int32 = v1206.Length
            let v1212 : string = ""
            let v1213 : bool = v328 <> v1212 
            let v1226 : bool =
                if v1213 then
                    let v1225 : bool = v1207 <= 1
                    v1225
                else
                    false
            if v1226 then
                v442.l0 <- v541
                ()
            else
                v442.l0 <- v1212
                let v1227 : Mut5 = {l0 = 0} : Mut5
                while method36(v1207, v1227) do
                    let v1229 : int32 = v1227.l0
                    let v1230 : std_string_String = v1206.[int v1229]
                    let v1231 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1232 : bool = Fable.Core.RustInterop.emitRustExpr v1230 v1231 
                    let v1233 : int32 = v1229 + 1
                    v1227.l0 <- v1233
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v500 v328
            #endif
#if FABLE_COMPILER_PYTHON
            v500 v328
            #endif
#else
            v500 v328
            #endif
            // run_target_args' is_unit
            let v1234 : (string -> unit) = v440.l0
            v1234 v328
            US12_0(v439, v440, v441, v442, v443, v444)
    let v1277 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1277 
    ()
and method57 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "result"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method56 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) : string =
    let v2 : string = method12()
    let v13 : Mut3 = {l0 = v2} : Mut3
    method27(v13)
    method51(v13)
    method29(v13)
    let v417 : string = $"{v0}"
    method13(v13, v417)
    method52(v13)
    method57(v13)
    method29(v13)
    (* run_target_args'
    let v943 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v944 : string = "format!(\"{:#?}\", $0)"
    let v945 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v944 
    let v946 : string = "fable_library_rust::String_::fromString($0)"
    let v947 : string = Fable.Core.RustInterop.emitRustExpr v945 v946 
    let _run_target_args'_v943 = v947 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v948 : string = "format!(\"{:#?}\", $0)"
    let v949 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v948 
    let v950 : string = "fable_library_rust::String_::fromString($0)"
    let v951 : string = Fable.Core.RustInterop.emitRustExpr v949 v950 
    let _run_target_args'_v943 = v951 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v952 : string = "format!(\"{:#?}\", $0)"
    let v953 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v952 
    let v954 : string = "fable_library_rust::String_::fromString($0)"
    let v955 : string = Fable.Core.RustInterop.emitRustExpr v953 v954 
    let _run_target_args'_v943 = v955 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v958 : string = $"%A{v1}"
    let _run_target_args'_v943 = v958 
    #endif
#if FABLE_COMPILER_PYTHON
    let v972 : string = $"%A{v1}"
    let _run_target_args'_v943 = v972 
    #endif
#else
    let v986 : string = $"%A{v1}"
    let _run_target_args'_v943 = v986 
    #endif
    let v998 : string = _run_target_args'_v943 
    method13(v13, v998)
    method30(v13)
    let v1273 : string = v13.l0
    v1273
and method55 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_result_ExecutionFinalResult) : string =
    let v10 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v28 : string = method25(v10)
    let v31 : string = v16 + v28 
    let v45 : string = v31 + v7 
    let v59 : string = v45 + v15 
    let v75 : string = "spiral_wasm.run"
    let v76 : string = v59 + v75 
    let v92 : string = " / "
    let v93 : string = v76 + v92 
    let v105 : string = method56(v8, v9)
    let v108 : string = v93 + v105 
    method31(v108)
and closure22 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) () : unit =
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure14()
    let v64 : unit = (fun () -> v63 (); v62) ()
    let struct (v113 : Mut0, v114 : Mut1, v115 : Mut2, v116 : Mut3, v117 : Mut4, v118 : int64 option) = TraceState.trace_state.Value
    let v160 : US5 = v117.l0
    let v161 : bool = v115.l0
    let v162 : bool = v161 = false
    let v165 : bool =
        if v162 then
            false
        else
            let v163 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v160
            let v164 : bool = 0 >= v163
            v164
    let v166 : bool = v165 = false
    let v1235 : US12 =
        if v166 then
            US12_1
        else
            let v228 : unit = ()
            let v229 : unit = (fun () -> v63 (); v228) ()
            let struct (v278 : Mut0, v279 : Mut1, v280 : Mut2, v281 : Mut3, v282 : Mut4, v283 : int64 option) = TraceState.trace_state.Value
            let v325 : string = method18(v278, v279, v280, v281, v282, v283)
            let v326 : string = method22()
            let v327 : string = method55(v278, v279, v280, v281, v282, v283, v325, v326, v0, v1)
            let v388 : unit = ()
            let v389 : unit = (fun () -> v63 (); v388) ()
            let struct (v438 : Mut0, v439 : Mut1, v440 : Mut2, v441 : Mut3, v442 : Mut4, v443 : int64 option) = TraceState.trace_state.Value
            let v489 : unit = ()
            let v490 : (unit -> unit) = closure16(v438)
            let v491 : unit = (fun () -> v490 (); v489) ()
            let v499 : (string -> unit) = closure17()
            (* run_target_args'
            let v500 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v501 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v502 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v502 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v503 : string = v441.l0
            let v504 : bool = v503 = ""
            let v540 : string =
                if v504 then
                    v327
                else
                    let v505 : bool = v327 = ""
                    if v505 then
                        let v506 : string = v441.l0
                        v506
                    else
                        let v507 : string = v441.l0
                        let v512 : string = "\n"
                        let v513 : string = v507 + v512 
                        let v527 : string = v513 + v327 
                        v527
            (* run_target_args'
            let v723 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v724 : string = "&*$0"
            let v725 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v724 
            let _run_target_args'_v723 = v725 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v726 : string = "&*$0"
            let v727 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v726 
            let _run_target_args'_v723 = v727 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v728 : string = "&*$0"
            let v729 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v728 
            let _run_target_args'_v723 = v729 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v809 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v809 
            #endif
#if FABLE_COMPILER_PYTHON
            let v900 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v900 
            #endif
#else
            let v991 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v991 
            #endif
            let v1003 : Ref<Str> = _run_target_args'_v723 
            let v1186 : string = $"$0.chars()"
            let v1187 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1003 v1186 
            let v1188 : string = "$0"
            let v1189 : _ = Fable.Core.RustInterop.emitRustExpr v1187 v1188 
            let v1190 : string = "$0.collect::<Vec<_>>()"
            let v1191 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1189 v1190 
            let v1192 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1193 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1191 v1192 
            let v1194 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1195 : bool = Fable.Core.RustInterop.emitRustExpr v1193 v1194 
            let v1196 : string = "x"
            let v1197 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1196 
            let v1198 : string = "String::from_iter($0)"
            let v1199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1197 v1198 
            let v1200 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1201 : bool = Fable.Core.RustInterop.emitRustExpr v1199 v1200 
            let v1202 : string = "_vec_map"
            let v1203 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1202 
            let v1204 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1205 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1203 v1204 
            let v1206 : int32 = v1205.Length
            let v1211 : string = ""
            let v1212 : bool = v327 <> v1211 
            let v1225 : bool =
                if v1212 then
                    let v1224 : bool = v1206 <= 1
                    v1224
                else
                    false
            if v1225 then
                v441.l0 <- v540
                ()
            else
                v441.l0 <- v1211
                let v1226 : Mut5 = {l0 = 0} : Mut5
                while method36(v1206, v1226) do
                    let v1228 : int32 = v1226.l0
                    let v1229 : std_string_String = v1205.[int v1228]
                    let v1230 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1231 : bool = Fable.Core.RustInterop.emitRustExpr v1229 v1230 
                    let v1232 : int32 = v1228 + 1
                    v1226.l0 <- v1232
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v499 v327
            #endif
#if FABLE_COMPILER_PYTHON
            v499 v327
            #endif
#else
            v499 v327
            #endif
            // run_target_args' is_unit
            let v1233 : (string -> unit) = v439.l0
            v1233 v327
            US12_0(v438, v439, v440, v441, v442, v443)
    let v1276 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1276 
    ()
and closure24 (v0 : std_string_String) () : unit =
    let v1 : (std_string_String -> unit) = System.Console.WriteLine
    v1 v0
and closure23 () (v0 : std_string_String) : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure24(v0)
    let v33 : unit = (fun () -> v32 (); v31) ()
    ()
and closure25 () () : unit =
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure14()
    let v62 : unit = (fun () -> v61 (); v60) ()
    let struct (v111 : Mut0, v112 : Mut1, v113 : Mut2, v114 : Mut3, v115 : Mut4, v116 : int64 option) = TraceState.trace_state.Value
    let v158 : US5 = v115.l0
    let v159 : bool = v113.l0
    let v160 : bool = v159 = false
    let v163 : bool =
        if v160 then
            false
        else
            let v161 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v158
            let v162 : bool = 2 >= v161
            v162
    let v164 : bool = v163 = false
    let v1074 : US12 =
        if v164 then
            US12_1
        else
            let v226 : unit = ()
            let v227 : unit = (fun () -> v61 (); v226) ()
            let struct (v276 : Mut0, v277 : Mut1, v278 : Mut2, v279 : Mut3, v280 : Mut4, v281 : int64 option) = TraceState.trace_state.Value
            let v327 : unit = ()
            let v328 : (unit -> unit) = closure16(v276)
            let v329 : unit = (fun () -> v328 (); v327) ()
            let v337 : string = " "
            let v338 : (string -> unit) = closure17()
            (* run_target_args'
            let v339 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v340 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v337 v340 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v341 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v337 v341 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v342 : string = v279.l0
            let v343 : bool = v342 = ""
            let v379 : string =
                if v343 then
                    v337
                else
                    let v344 : bool = v337 = ""
                    if v344 then
                        let v345 : string = v279.l0
                        v345
                    else
                        let v346 : string = v279.l0
                        let v351 : string = "\n"
                        let v352 : string = v346 + v351 
                        let v366 : string = v352 + v337 
                        v366
            (* run_target_args'
            let v562 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v563 : string = "&*$0"
            let v564 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v379 v563 
            let _run_target_args'_v562 = v564 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v565 : string = "&*$0"
            let v566 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v379 v565 
            let _run_target_args'_v562 = v566 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v567 : string = "&*$0"
            let v568 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v379 v567 
            let _run_target_args'_v562 = v568 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v648 : Ref<Str> = v379 |> unbox<Ref<Str>>
            let _run_target_args'_v562 = v648 
            #endif
#if FABLE_COMPILER_PYTHON
            let v739 : Ref<Str> = v379 |> unbox<Ref<Str>>
            let _run_target_args'_v562 = v739 
            #endif
#else
            let v830 : Ref<Str> = v379 |> unbox<Ref<Str>>
            let _run_target_args'_v562 = v830 
            #endif
            let v842 : Ref<Str> = _run_target_args'_v562 
            let v1025 : string = $"$0.chars()"
            let v1026 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v842 v1025 
            let v1027 : string = "$0"
            let v1028 : _ = Fable.Core.RustInterop.emitRustExpr v1026 v1027 
            let v1029 : string = "$0.collect::<Vec<_>>()"
            let v1030 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1028 v1029 
            let v1031 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1032 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1030 v1031 
            let v1033 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1034 : bool = Fable.Core.RustInterop.emitRustExpr v1032 v1033 
            let v1035 : string = "x"
            let v1036 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1035 
            let v1037 : string = "String::from_iter($0)"
            let v1038 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1036 v1037 
            let v1039 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1040 : bool = Fable.Core.RustInterop.emitRustExpr v1038 v1039 
            let v1041 : string = "_vec_map"
            let v1042 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1041 
            let v1043 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1044 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1042 v1043 
            let v1045 : int32 = v1044.Length
            let v1050 : string = ""
            let v1051 : bool = v337 <> v1050 
            let v1064 : bool =
                if v1051 then
                    let v1063 : bool = v1045 <= 1
                    v1063
                else
                    false
            if v1064 then
                v279.l0 <- v379
                ()
            else
                v279.l0 <- v1050
                let v1065 : Mut5 = {l0 = 0} : Mut5
                while method36(v1045, v1065) do
                    let v1067 : int32 = v1065.l0
                    let v1068 : std_string_String = v1044.[int v1067]
                    let v1069 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1070 : bool = Fable.Core.RustInterop.emitRustExpr v1068 v1069 
                    let v1071 : int32 = v1067 + 1
                    v1065.l0 <- v1071
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v338 v337
            #endif
#if FABLE_COMPILER_PYTHON
            v338 v337
            #endif
#else
            v338 v337
            #endif
            // run_target_args' is_unit
            let v1072 : (string -> unit) = v277.l0
            v1072 v337
            US12_0(v276, v277, v278, v279, v280, v281)
    let v1115 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1115 
    ()
and method58 () : string =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "inline_colorization::color_bright_green"
    let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3 
    (* run_target_args'
    let v187 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v188 : string = "String::from($0)"
    let v189 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v188 
    let _run_target_args'_v187 = v189 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v190 : string = "String::from($0)"
    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v190 
    let _run_target_args'_v187 = v191 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v192 : string = "String::from($0)"
    let v193 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v192 
    let _run_target_args'_v187 = v193 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v273 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v273 
    #endif
#if FABLE_COMPILER_PYTHON
    let v364 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v364 
    #endif
#else
    let v455 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v455 
    #endif
    let v467 : std_string_String = _run_target_args'_v187 
    let v650 : string = "fable_library_rust::String_::fromString($0)"
    let v651 : string = Fable.Core.RustInterop.emitRustExpr v467 v650 
    let _run_target_args'_v2 = v651 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v652 : string = "inline_colorization::color_bright_green"
    let v653 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v652 
    (* run_target_args'
    let v836 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v837 : string = "String::from($0)"
    let v838 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v837 
    let _run_target_args'_v836 = v838 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v839 : string = "String::from($0)"
    let v840 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v839 
    let _run_target_args'_v836 = v840 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v841 : string = "String::from($0)"
    let v842 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v841 
    let _run_target_args'_v836 = v842 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v922 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v922 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1013 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v1013 
    #endif
#else
    let v1104 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v1104 
    #endif
    let v1116 : std_string_String = _run_target_args'_v836 
    let v1299 : string = "fable_library_rust::String_::fromString($0)"
    let v1300 : string = Fable.Core.RustInterop.emitRustExpr v1116 v1299 
    let _run_target_args'_v2 = v1300 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1301 : string = "inline_colorization::color_bright_green"
    let v1302 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1301 
    (* run_target_args'
    let v1485 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1486 : string = "String::from($0)"
    let v1487 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1486 
    let _run_target_args'_v1485 = v1487 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1488 : string = "String::from($0)"
    let v1489 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1488 
    let _run_target_args'_v1485 = v1489 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1490 : string = "String::from($0)"
    let v1491 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1490 
    let _run_target_args'_v1485 = v1491 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1571 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1571 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1662 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1662 
    #endif
#else
    let v1753 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1753 
    #endif
    let v1765 : std_string_String = _run_target_args'_v1485 
    let v1948 : string = "fable_library_rust::String_::fromString($0)"
    let v1949 : string = Fable.Core.RustInterop.emitRustExpr v1765 v1948 
    let _run_target_args'_v2 = v1949 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1950 : string = "\u001b[92m"
    let _run_target_args'_v2 = v1950 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1951 : string = "\u001b[92m"
    let _run_target_args'_v2 = v1951 
    #endif
#else
    let v1952 : string = "\u001b[92m"
    let _run_target_args'_v2 = v1952 
    #endif
    let v1953 : string = _run_target_args'_v2 
    
    
    
    
    
    let v1960 : string = "Info"
    let v1961 : (unit -> string) = v1960.ToLower
    let v1962 : string = v1961 ()
    let v1974 : char = v1962.[int 0]
    let v1975 : string = method23(v1974)
    let v1978 : string = v1953 + v1975 
    (* run_target_args'
    let v1992 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1993 : string = "inline_colorization::color_reset"
    let v1994 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1993 
    (* run_target_args'
    let v2177 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2178 : string = "String::from($0)"
    let v2179 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2178 
    let _run_target_args'_v2177 = v2179 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2180 : string = "String::from($0)"
    let v2181 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2180 
    let _run_target_args'_v2177 = v2181 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2182 : string = "String::from($0)"
    let v2183 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2182 
    let _run_target_args'_v2177 = v2183 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2263 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2263 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2354 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2354 
    #endif
#else
    let v2445 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2445 
    #endif
    let v2457 : std_string_String = _run_target_args'_v2177 
    let v2640 : string = "fable_library_rust::String_::fromString($0)"
    let v2641 : string = Fable.Core.RustInterop.emitRustExpr v2457 v2640 
    let _run_target_args'_v1992 = v2641 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2642 : string = "inline_colorization::color_reset"
    let v2643 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2642 
    (* run_target_args'
    let v2826 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2827 : string = "String::from($0)"
    let v2828 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2827 
    let _run_target_args'_v2826 = v2828 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2829 : string = "String::from($0)"
    let v2830 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2829 
    let _run_target_args'_v2826 = v2830 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2831 : string = "String::from($0)"
    let v2832 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2831 
    let _run_target_args'_v2826 = v2832 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2912 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v2912 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3003 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v3003 
    #endif
#else
    let v3094 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v3094 
    #endif
    let v3106 : std_string_String = _run_target_args'_v2826 
    let v3289 : string = "fable_library_rust::String_::fromString($0)"
    let v3290 : string = Fable.Core.RustInterop.emitRustExpr v3106 v3289 
    let _run_target_args'_v1992 = v3290 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3291 : string = "inline_colorization::color_reset"
    let v3292 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3291 
    (* run_target_args'
    let v3475 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3476 : string = "String::from($0)"
    let v3477 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3476 
    let _run_target_args'_v3475 = v3477 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3478 : string = "String::from($0)"
    let v3479 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3478 
    let _run_target_args'_v3475 = v3479 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3480 : string = "String::from($0)"
    let v3481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3480 
    let _run_target_args'_v3475 = v3481 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3561 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3561 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3652 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3652 
    #endif
#else
    let v3743 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3743 
    #endif
    let v3755 : std_string_String = _run_target_args'_v3475 
    let v3938 : string = "fable_library_rust::String_::fromString($0)"
    let v3939 : string = Fable.Core.RustInterop.emitRustExpr v3755 v3938 
    let _run_target_args'_v1992 = v3939 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3940 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3940 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3941 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3941 
    #endif
#else
    let v3942 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3942 
    #endif
    let v3943 : string = _run_target_args'_v1992 
    let v3948 : string = v1978 + v3943 
    v3948
and method61 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "total_gas_burnt_usd"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method62 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "total_gas_burnt"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method60 (v0 : uint8, v1 : float, v2 : uint64) : string =
    let v3 : string = method12()
    let v14 : Mut3 = {l0 = v3} : Mut3
    method27(v14)
    method51(v14)
    method29(v14)
    let v418 : string = $"{v0}"
    method13(v14, v418)
    method52(v14)
    method61(v14)
    method29(v14)
    let v944 : string = $"%+.6f{v1}"
    method13(v14, v944)
    method52(v14)
    method62(v14)
    method29(v14)
    let v1470 : string = $"{v2}"
    method13(v14, v1470)
    method30(v14)
    let v1718 : string = v14.l0
    v1718
and method59 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : float, v10 : uint64) : string =
    let v11 : int64 = v0.l0
    let v16 : string = " "
    let v17 : string = v6 + v16 
    let v29 : string = method25(v11)
    let v32 : string = v17 + v29 
    let v46 : string = v32 + v7 
    let v60 : string = v46 + v16 
    let v76 : string = "near_workspaces.print_usd"
    let v77 : string = v60 + v76 
    let v93 : string = " / "
    let v94 : string = v77 + v93 
    let v106 : string = method60(v8, v9, v10)
    let v109 : string = v94 + v106 
    method31(v109)
and closure26 (v0 : uint8, v1 : uint64, v2 : float) () : unit =
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure14()
    let v65 : unit = (fun () -> v64 (); v63) ()
    let struct (v114 : Mut0, v115 : Mut1, v116 : Mut2, v117 : Mut3, v118 : Mut4, v119 : int64 option) = TraceState.trace_state.Value
    let v161 : US5 = v118.l0
    let v162 : bool = v116.l0
    let v163 : bool = v162 = false
    let v166 : bool =
        if v163 then
            false
        else
            let v164 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v161
            let v165 : bool = 2 >= v164
            v165
    let v167 : bool = v166 = false
    let v1236 : US12 =
        if v167 then
            US12_1
        else
            let v229 : unit = ()
            let v230 : unit = (fun () -> v64 (); v229) ()
            let struct (v279 : Mut0, v280 : Mut1, v281 : Mut2, v282 : Mut3, v283 : Mut4, v284 : int64 option) = TraceState.trace_state.Value
            let v326 : string = method18(v279, v280, v281, v282, v283, v284)
            let v327 : string = method58()
            let v328 : string = method59(v279, v280, v281, v282, v283, v284, v326, v327, v0, v2, v1)
            let v389 : unit = ()
            let v390 : unit = (fun () -> v64 (); v389) ()
            let struct (v439 : Mut0, v440 : Mut1, v441 : Mut2, v442 : Mut3, v443 : Mut4, v444 : int64 option) = TraceState.trace_state.Value
            let v490 : unit = ()
            let v491 : (unit -> unit) = closure16(v439)
            let v492 : unit = (fun () -> v491 (); v490) ()
            let v500 : (string -> unit) = closure17()
            (* run_target_args'
            let v501 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v502 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v328 v502 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v503 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v328 v503 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v504 : string = v442.l0
            let v505 : bool = v504 = ""
            let v541 : string =
                if v505 then
                    v328
                else
                    let v506 : bool = v328 = ""
                    if v506 then
                        let v507 : string = v442.l0
                        v507
                    else
                        let v508 : string = v442.l0
                        let v513 : string = "\n"
                        let v514 : string = v508 + v513 
                        let v528 : string = v514 + v328 
                        v528
            (* run_target_args'
            let v724 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v725 : string = "&*$0"
            let v726 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v541 v725 
            let _run_target_args'_v724 = v726 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v727 : string = "&*$0"
            let v728 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v541 v727 
            let _run_target_args'_v724 = v728 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v729 : string = "&*$0"
            let v730 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v541 v729 
            let _run_target_args'_v724 = v730 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v810 : Ref<Str> = v541 |> unbox<Ref<Str>>
            let _run_target_args'_v724 = v810 
            #endif
#if FABLE_COMPILER_PYTHON
            let v901 : Ref<Str> = v541 |> unbox<Ref<Str>>
            let _run_target_args'_v724 = v901 
            #endif
#else
            let v992 : Ref<Str> = v541 |> unbox<Ref<Str>>
            let _run_target_args'_v724 = v992 
            #endif
            let v1004 : Ref<Str> = _run_target_args'_v724 
            let v1187 : string = $"$0.chars()"
            let v1188 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1004 v1187 
            let v1189 : string = "$0"
            let v1190 : _ = Fable.Core.RustInterop.emitRustExpr v1188 v1189 
            let v1191 : string = "$0.collect::<Vec<_>>()"
            let v1192 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1190 v1191 
            let v1193 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1194 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1192 v1193 
            let v1195 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1196 : bool = Fable.Core.RustInterop.emitRustExpr v1194 v1195 
            let v1197 : string = "x"
            let v1198 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1197 
            let v1199 : string = "String::from_iter($0)"
            let v1200 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1198 v1199 
            let v1201 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1202 : bool = Fable.Core.RustInterop.emitRustExpr v1200 v1201 
            let v1203 : string = "_vec_map"
            let v1204 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1203 
            let v1205 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1206 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1204 v1205 
            let v1207 : int32 = v1206.Length
            let v1212 : string = ""
            let v1213 : bool = v328 <> v1212 
            let v1226 : bool =
                if v1213 then
                    let v1225 : bool = v1207 <= 1
                    v1225
                else
                    false
            if v1226 then
                v442.l0 <- v541
                ()
            else
                v442.l0 <- v1212
                let v1227 : Mut5 = {l0 = 0} : Mut5
                while method36(v1207, v1227) do
                    let v1229 : int32 = v1227.l0
                    let v1230 : std_string_String = v1206.[int v1229]
                    let v1231 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1232 : bool = Fable.Core.RustInterop.emitRustExpr v1230 v1231 
                    let v1233 : int32 = v1229 + 1
                    v1227.l0 <- v1233
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v500 v328
            #endif
#if FABLE_COMPILER_PYTHON
            v500 v328
            #endif
#else
            v500 v328
            #endif
            // run_target_args' is_unit
            let v1234 : (string -> unit) = v440.l0
            v1234 v328
            US12_0(v439, v440, v441, v442, v443, v444)
    let v1277 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1277 
    ()
and method65 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "is_success"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method66 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "gas_burnt_usd"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method67 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "tokens_burnt_usd"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method68 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "gas_burnt"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method69 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "tokens_burnt"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method64 (v0 : bool, v1 : float, v2 : float, v3 : uint64, v4 : u128) : string =
    let v5 : string = method12()
    let v16 : Mut3 = {l0 = v5} : Mut3
    method27(v16)
    method65(v16)
    method29(v16)
    let v394 : string =
        if v0 then
            let v392 : string = "true"
            v392
        else
            let v393 : string = "false"
            v393
    method13(v16, v394)
    method52(v16)
    method66(v16)
    method29(v16)
    let v919 : string = $"%+.6f{v1}"
    method13(v16, v919)
    method52(v16)
    method67(v16)
    method29(v16)
    let v1445 : string = $"%+.6f{v2}"
    method13(v16, v1445)
    method52(v16)
    method68(v16)
    method29(v16)
    let v1971 : string = $"{v3}"
    method13(v16, v1971)
    method52(v16)
    method69(v16)
    method29(v16)
    (* run_target_args'
    let v2497 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2498 : string = "format!(\"{:#?}\", $0)"
    let v2499 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v2498 
    let v2500 : string = "fable_library_rust::String_::fromString($0)"
    let v2501 : string = Fable.Core.RustInterop.emitRustExpr v2499 v2500 
    let _run_target_args'_v2497 = v2501 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2502 : string = "format!(\"{:#?}\", $0)"
    let v2503 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v2502 
    let v2504 : string = "fable_library_rust::String_::fromString($0)"
    let v2505 : string = Fable.Core.RustInterop.emitRustExpr v2503 v2504 
    let _run_target_args'_v2497 = v2505 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2506 : string = "format!(\"{:#?}\", $0)"
    let v2507 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v2506 
    let v2508 : string = "fable_library_rust::String_::fromString($0)"
    let v2509 : string = Fable.Core.RustInterop.emitRustExpr v2507 v2508 
    let _run_target_args'_v2497 = v2509 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2512 : string = $"%A{v4}"
    let _run_target_args'_v2497 = v2512 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2526 : string = $"%A{v4}"
    let _run_target_args'_v2497 = v2526 
    #endif
#else
    let v2540 : string = $"%A{v4}"
    let _run_target_args'_v2497 = v2540 
    #endif
    let v2552 : string = _run_target_args'_v2497 
    method13(v16, v2552)
    method30(v16)
    let v2827 : string = v16.l0
    v2827
and method63 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : bool, v9 : float, v10 : float, v11 : uint64, v12 : u128) : string =
    let v13 : int64 = v0.l0
    let v18 : string = " "
    let v19 : string = v6 + v18 
    let v31 : string = method25(v13)
    let v34 : string = v19 + v31 
    let v48 : string = v34 + v7 
    let v62 : string = v48 + v18 
    let v78 : string = "near_workspaces.print_usd / outcome"
    let v79 : string = v62 + v78 
    let v95 : string = " / "
    let v96 : string = v79 + v95 
    let v108 : string = method64(v8, v9, v10, v11, v12)
    let v111 : string = v96 + v108 
    method31(v111)
and closure28 (v0 : bool, v1 : uint64, v2 : float, v3 : u128, v4 : float) () : unit =
    let v65 : unit = ()
    let v66 : (unit -> unit) = closure14()
    let v67 : unit = (fun () -> v66 (); v65) ()
    let struct (v116 : Mut0, v117 : Mut1, v118 : Mut2, v119 : Mut3, v120 : Mut4, v121 : int64 option) = TraceState.trace_state.Value
    let v163 : US5 = v120.l0
    let v164 : bool = v118.l0
    let v165 : bool = v164 = false
    let v168 : bool =
        if v165 then
            false
        else
            let v166 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v163
            let v167 : bool = 2 >= v166
            v167
    let v169 : bool = v168 = false
    let v1238 : US12 =
        if v169 then
            US12_1
        else
            let v231 : unit = ()
            let v232 : unit = (fun () -> v66 (); v231) ()
            let struct (v281 : Mut0, v282 : Mut1, v283 : Mut2, v284 : Mut3, v285 : Mut4, v286 : int64 option) = TraceState.trace_state.Value
            let v328 : string = method18(v281, v282, v283, v284, v285, v286)
            let v329 : string = method58()
            let v330 : string = method63(v281, v282, v283, v284, v285, v286, v328, v329, v0, v2, v4, v1, v3)
            let v391 : unit = ()
            let v392 : unit = (fun () -> v66 (); v391) ()
            let struct (v441 : Mut0, v442 : Mut1, v443 : Mut2, v444 : Mut3, v445 : Mut4, v446 : int64 option) = TraceState.trace_state.Value
            let v492 : unit = ()
            let v493 : (unit -> unit) = closure16(v441)
            let v494 : unit = (fun () -> v493 (); v492) ()
            let v502 : (string -> unit) = closure17()
            (* run_target_args'
            let v503 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v504 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v330 v504 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v505 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v330 v505 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v506 : string = v444.l0
            let v507 : bool = v506 = ""
            let v543 : string =
                if v507 then
                    v330
                else
                    let v508 : bool = v330 = ""
                    if v508 then
                        let v509 : string = v444.l0
                        v509
                    else
                        let v510 : string = v444.l0
                        let v515 : string = "\n"
                        let v516 : string = v510 + v515 
                        let v530 : string = v516 + v330 
                        v530
            (* run_target_args'
            let v726 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v727 : string = "&*$0"
            let v728 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v543 v727 
            let _run_target_args'_v726 = v728 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v729 : string = "&*$0"
            let v730 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v543 v729 
            let _run_target_args'_v726 = v730 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v731 : string = "&*$0"
            let v732 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v543 v731 
            let _run_target_args'_v726 = v732 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v812 : Ref<Str> = v543 |> unbox<Ref<Str>>
            let _run_target_args'_v726 = v812 
            #endif
#if FABLE_COMPILER_PYTHON
            let v903 : Ref<Str> = v543 |> unbox<Ref<Str>>
            let _run_target_args'_v726 = v903 
            #endif
#else
            let v994 : Ref<Str> = v543 |> unbox<Ref<Str>>
            let _run_target_args'_v726 = v994 
            #endif
            let v1006 : Ref<Str> = _run_target_args'_v726 
            let v1189 : string = $"$0.chars()"
            let v1190 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1006 v1189 
            let v1191 : string = "$0"
            let v1192 : _ = Fable.Core.RustInterop.emitRustExpr v1190 v1191 
            let v1193 : string = "$0.collect::<Vec<_>>()"
            let v1194 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1192 v1193 
            let v1195 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1196 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1194 v1195 
            let v1197 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1198 : bool = Fable.Core.RustInterop.emitRustExpr v1196 v1197 
            let v1199 : string = "x"
            let v1200 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1199 
            let v1201 : string = "String::from_iter($0)"
            let v1202 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1200 v1201 
            let v1203 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1204 : bool = Fable.Core.RustInterop.emitRustExpr v1202 v1203 
            let v1205 : string = "_vec_map"
            let v1206 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1205 
            let v1207 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1208 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1206 v1207 
            let v1209 : int32 = v1208.Length
            let v1214 : string = ""
            let v1215 : bool = v330 <> v1214 
            let v1228 : bool =
                if v1215 then
                    let v1227 : bool = v1209 <= 1
                    v1227
                else
                    false
            if v1228 then
                v444.l0 <- v543
                ()
            else
                v444.l0 <- v1214
                let v1229 : Mut5 = {l0 = 0} : Mut5
                while method36(v1209, v1229) do
                    let v1231 : int32 = v1229.l0
                    let v1232 : std_string_String = v1208.[int v1231]
                    let v1233 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1234 : bool = Fable.Core.RustInterop.emitRustExpr v1232 v1233 
                    let v1235 : int32 = v1231 + 1
                    v1229.l0 <- v1235
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v502 v330
            #endif
#if FABLE_COMPILER_PYTHON
            v502 v330
            #endif
#else
            v502 v330
            #endif
            // run_target_args' is_unit
            let v1236 : (string -> unit) = v442.l0
            v1236 v330
            US12_0(v441, v442, v443, v444, v445, v446)
    let v1279 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1279 
    ()
and closure27 () (v0 : near_workspaces_result_ExecutionOutcome) : unit =
    let v1 : string = "$0.is_success()"
    let v2 : bool = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : string = "$0.gas_burnt"
    let v4 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let v5 : string = "$0.as_gas()"
    let v6 : uint64 = Fable.Core.RustInterop.emitRustExpr v4 v5 
    let v86 : (uint64 -> float) = float
    let v87 : float = v86 v6
    let v99 : float = v87 / 10000000000000000.0
    let v100 : float = v99 * 6.68
    let v101 : string = "$0.tokens_burnt"
    let v102 : near_workspaces_types_NearToken = Fable.Core.RustInterop.emitRustExpr v0 v101 
    let v103 : string = "$0.as_yoctonear()"
    let v104 : u128 = Fable.Core.RustInterop.emitRustExpr v102 v103 
    let v105 : string = "$0 as f64"
    let v106 : float = Fable.Core.RustInterop.emitRustExpr v104 v105 
    let v107 : float = v106 / 1E+24
    let v108 : float = v107 * 6.68
    let v2674 : unit = ()
    let v2675 : (unit -> unit) = closure28(v2, v6, v100, v104, v108)
    let v2676 : unit = (fun () -> v2675 (); v2674) ()
    ()
and method72 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "result2"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method71 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    method27(v12)
    method72(v12)
    method29(v12)
    (* run_target_args'
    let v416 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v417 : string = "format!(\"{:#?}\", $0)"
    let v418 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v417 
    let v419 : string = "fable_library_rust::String_::fromString($0)"
    let v420 : string = Fable.Core.RustInterop.emitRustExpr v418 v419 
    let _run_target_args'_v416 = v420 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v421 : string = "format!(\"{:#?}\", $0)"
    let v422 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v421 
    let v423 : string = "fable_library_rust::String_::fromString($0)"
    let v424 : string = Fable.Core.RustInterop.emitRustExpr v422 v423 
    let _run_target_args'_v416 = v424 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v425 : string = "format!(\"{:#?}\", $0)"
    let v426 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v425 
    let v427 : string = "fable_library_rust::String_::fromString($0)"
    let v428 : string = Fable.Core.RustInterop.emitRustExpr v426 v427 
    let _run_target_args'_v416 = v428 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v431 : string = $"%A{v0}"
    let _run_target_args'_v416 = v431 
    #endif
#if FABLE_COMPILER_PYTHON
    let v445 : string = $"%A{v0}"
    let _run_target_args'_v416 = v445 
    #endif
#else
    let v459 : string = $"%A{v0}"
    let _run_target_args'_v416 = v459 
    #endif
    let v471 : string = _run_target_args'_v416 
    method13(v12, v471)
    method30(v12)
    let v746 : string = v12.l0
    v746
and method70 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v9 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v27 : string = method25(v9)
    let v30 : string = v15 + v27 
    let v44 : string = v30 + v7 
    let v58 : string = v44 + v14 
    let v74 : string = "spiral_wasm.run"
    let v75 : string = v58 + v74 
    let v91 : string = " / "
    let v92 : string = v75 + v91 
    let v104 : string = method71(v8)
    let v107 : string = v92 + v104 
    method31(v107)
and closure29 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) () : unit =
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure14()
    let v63 : unit = (fun () -> v62 (); v61) ()
    let struct (v112 : Mut0, v113 : Mut1, v114 : Mut2, v115 : Mut3, v116 : Mut4, v117 : int64 option) = TraceState.trace_state.Value
    let v159 : US5 = v116.l0
    let v160 : bool = v114.l0
    let v161 : bool = v160 = false
    let v164 : bool =
        if v161 then
            false
        else
            let v162 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v159
            let v163 : bool = 0 >= v162
            v163
    let v165 : bool = v164 = false
    let v1234 : US12 =
        if v165 then
            US12_1
        else
            let v227 : unit = ()
            let v228 : unit = (fun () -> v62 (); v227) ()
            let struct (v277 : Mut0, v278 : Mut1, v279 : Mut2, v280 : Mut3, v281 : Mut4, v282 : int64 option) = TraceState.trace_state.Value
            let v324 : string = method18(v277, v278, v279, v280, v281, v282)
            let v325 : string = method22()
            let v326 : string = method70(v277, v278, v279, v280, v281, v282, v324, v325, v0)
            let v387 : unit = ()
            let v388 : unit = (fun () -> v62 (); v387) ()
            let struct (v437 : Mut0, v438 : Mut1, v439 : Mut2, v440 : Mut3, v441 : Mut4, v442 : int64 option) = TraceState.trace_state.Value
            let v488 : unit = ()
            let v489 : (unit -> unit) = closure16(v437)
            let v490 : unit = (fun () -> v489 (); v488) ()
            let v498 : (string -> unit) = closure17()
            (* run_target_args'
            let v499 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v500 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v500 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v501 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v502 : string = v440.l0
            let v503 : bool = v502 = ""
            let v539 : string =
                if v503 then
                    v326
                else
                    let v504 : bool = v326 = ""
                    if v504 then
                        let v505 : string = v440.l0
                        v505
                    else
                        let v506 : string = v440.l0
                        let v511 : string = "\n"
                        let v512 : string = v506 + v511 
                        let v526 : string = v512 + v326 
                        v526
            (* run_target_args'
            let v722 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v723 : string = "&*$0"
            let v724 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v723 
            let _run_target_args'_v722 = v724 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v725 : string = "&*$0"
            let v726 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v725 
            let _run_target_args'_v722 = v726 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v727 : string = "&*$0"
            let v728 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v727 
            let _run_target_args'_v722 = v728 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v808 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v808 
            #endif
#if FABLE_COMPILER_PYTHON
            let v899 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v899 
            #endif
#else
            let v990 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v990 
            #endif
            let v1002 : Ref<Str> = _run_target_args'_v722 
            let v1185 : string = $"$0.chars()"
            let v1186 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1002 v1185 
            let v1187 : string = "$0"
            let v1188 : _ = Fable.Core.RustInterop.emitRustExpr v1186 v1187 
            let v1189 : string = "$0.collect::<Vec<_>>()"
            let v1190 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1188 v1189 
            let v1191 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1192 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1190 v1191 
            let v1193 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1194 : bool = Fable.Core.RustInterop.emitRustExpr v1192 v1193 
            let v1195 : string = "x"
            let v1196 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1195 
            let v1197 : string = "String::from_iter($0)"
            let v1198 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1196 v1197 
            let v1199 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1200 : bool = Fable.Core.RustInterop.emitRustExpr v1198 v1199 
            let v1201 : string = "_vec_map"
            let v1202 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1201 
            let v1203 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1204 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1202 v1203 
            let v1205 : int32 = v1204.Length
            let v1210 : string = ""
            let v1211 : bool = v326 <> v1210 
            let v1224 : bool =
                if v1211 then
                    let v1223 : bool = v1205 <= 1
                    v1223
                else
                    false
            if v1224 then
                v440.l0 <- v539
                ()
            else
                v440.l0 <- v1210
                let v1225 : Mut5 = {l0 = 0} : Mut5
                while method36(v1205, v1225) do
                    let v1227 : int32 = v1225.l0
                    let v1228 : std_string_String = v1204.[int v1227]
                    let v1229 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1230 : bool = Fable.Core.RustInterop.emitRustExpr v1228 v1229 
                    let v1231 : int32 = v1227 + 1
                    v1225.l0 <- v1231
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v498 v326
            #endif
#if FABLE_COMPILER_PYTHON
            v498 v326
            #endif
#else
            v498 v326
            #endif
            // run_target_args' is_unit
            let v1232 : (string -> unit) = v438.l0
            v1232 v326
            US12_0(v437, v438, v439, v440, v441, v442)
    let v1275 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1275 
    ()
and method73 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and closure30 (v0 : unativeint) () : int32 =
    let v1 : int32 = v0 |> int32 
    v1
and closure31 () (v0 : int32) : US15 =
    US15_0(v0)
and closure32 () (v0 : exn) : US15 =
    US15_1(v0)
and method74 (v0 : unativeint) : US15 =
    let v1 : (unit -> int32) = closure30(v0)
    let v2 : (int32 -> US15) = closure31()
    let v3 : ((unit -> exn) -> exn) = closure3()
    let v4 : (exn -> US15) = closure32()
    let v5 : US15 = try v1 () |> v2 with ex -> (fun () -> ex) |> v3 |> v4 
    v5
and method77 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "receipt_failures_len"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method78 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "receipt_failures"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method76 (v0 : int32, v1 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v2 : string = method12()
    let v13 : Mut3 = {l0 = v2} : Mut3
    method27(v13)
    method77(v13)
    method29(v13)
    let v417 : string = $"{v0}"
    method13(v13, v417)
    method52(v13)
    method78(v13)
    method29(v13)
    (* run_target_args'
    let v943 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v944 : string = "format!(\"{:#?}\", $0)"
    let v945 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v944 
    let v946 : string = "fable_library_rust::String_::fromString($0)"
    let v947 : string = Fable.Core.RustInterop.emitRustExpr v945 v946 
    let _run_target_args'_v943 = v947 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v948 : string = "format!(\"{:#?}\", $0)"
    let v949 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v948 
    let v950 : string = "fable_library_rust::String_::fromString($0)"
    let v951 : string = Fable.Core.RustInterop.emitRustExpr v949 v950 
    let _run_target_args'_v943 = v951 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v952 : string = "format!(\"{:#?}\", $0)"
    let v953 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v952 
    let v954 : string = "fable_library_rust::String_::fromString($0)"
    let v955 : string = Fable.Core.RustInterop.emitRustExpr v953 v954 
    let _run_target_args'_v943 = v955 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v958 : string = $"%A{v1}"
    let _run_target_args'_v943 = v958 
    #endif
#if FABLE_COMPILER_PYTHON
    let v972 : string = $"%A{v1}"
    let _run_target_args'_v943 = v972 
    #endif
#else
    let v986 : string = $"%A{v1}"
    let _run_target_args'_v943 = v986 
    #endif
    let v998 : string = _run_target_args'_v943 
    method13(v13, v998)
    method30(v13)
    let v1273 : string = v13.l0
    v1273
and method75 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v10 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v28 : string = method25(v10)
    let v31 : string = v16 + v28 
    let v45 : string = v31 + v7 
    let v59 : string = v45 + v15 
    let v75 : string = "spiral_wasm.run"
    let v76 : string = v59 + v75 
    let v92 : string = " / "
    let v93 : string = v76 + v92 
    let v105 : string = method76(v8, v9)
    let v108 : string = v93 + v105 
    method31(v108)
and closure33 (v0 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>, v1 : int32) () : unit =
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure14()
    let v64 : unit = (fun () -> v63 (); v62) ()
    let struct (v113 : Mut0, v114 : Mut1, v115 : Mut2, v116 : Mut3, v117 : Mut4, v118 : int64 option) = TraceState.trace_state.Value
    let v160 : US5 = v117.l0
    let v161 : bool = v115.l0
    let v162 : bool = v161 = false
    let v165 : bool =
        if v162 then
            false
        else
            let v163 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v160
            let v164 : bool = 0 >= v163
            v164
    let v166 : bool = v165 = false
    let v1235 : US12 =
        if v166 then
            US12_1
        else
            let v228 : unit = ()
            let v229 : unit = (fun () -> v63 (); v228) ()
            let struct (v278 : Mut0, v279 : Mut1, v280 : Mut2, v281 : Mut3, v282 : Mut4, v283 : int64 option) = TraceState.trace_state.Value
            let v325 : string = method18(v278, v279, v280, v281, v282, v283)
            let v326 : string = method22()
            let v327 : string = method75(v278, v279, v280, v281, v282, v283, v325, v326, v1, v0)
            let v388 : unit = ()
            let v389 : unit = (fun () -> v63 (); v388) ()
            let struct (v438 : Mut0, v439 : Mut1, v440 : Mut2, v441 : Mut3, v442 : Mut4, v443 : int64 option) = TraceState.trace_state.Value
            let v489 : unit = ()
            let v490 : (unit -> unit) = closure16(v438)
            let v491 : unit = (fun () -> v490 (); v489) ()
            let v499 : (string -> unit) = closure17()
            (* run_target_args'
            let v500 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v501 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v502 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v502 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v503 : string = v441.l0
            let v504 : bool = v503 = ""
            let v540 : string =
                if v504 then
                    v327
                else
                    let v505 : bool = v327 = ""
                    if v505 then
                        let v506 : string = v441.l0
                        v506
                    else
                        let v507 : string = v441.l0
                        let v512 : string = "\n"
                        let v513 : string = v507 + v512 
                        let v527 : string = v513 + v327 
                        v527
            (* run_target_args'
            let v723 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v724 : string = "&*$0"
            let v725 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v724 
            let _run_target_args'_v723 = v725 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v726 : string = "&*$0"
            let v727 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v726 
            let _run_target_args'_v723 = v727 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v728 : string = "&*$0"
            let v729 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v728 
            let _run_target_args'_v723 = v729 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v809 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v809 
            #endif
#if FABLE_COMPILER_PYTHON
            let v900 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v900 
            #endif
#else
            let v991 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v991 
            #endif
            let v1003 : Ref<Str> = _run_target_args'_v723 
            let v1186 : string = $"$0.chars()"
            let v1187 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1003 v1186 
            let v1188 : string = "$0"
            let v1189 : _ = Fable.Core.RustInterop.emitRustExpr v1187 v1188 
            let v1190 : string = "$0.collect::<Vec<_>>()"
            let v1191 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1189 v1190 
            let v1192 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1193 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1191 v1192 
            let v1194 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1195 : bool = Fable.Core.RustInterop.emitRustExpr v1193 v1194 
            let v1196 : string = "x"
            let v1197 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1196 
            let v1198 : string = "String::from_iter($0)"
            let v1199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1197 v1198 
            let v1200 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1201 : bool = Fable.Core.RustInterop.emitRustExpr v1199 v1200 
            let v1202 : string = "_vec_map"
            let v1203 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1202 
            let v1204 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1205 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1203 v1204 
            let v1206 : int32 = v1205.Length
            let v1211 : string = ""
            let v1212 : bool = v327 <> v1211 
            let v1225 : bool =
                if v1212 then
                    let v1224 : bool = v1206 <= 1
                    v1224
                else
                    false
            if v1225 then
                v441.l0 <- v540
                ()
            else
                v441.l0 <- v1211
                let v1226 : Mut5 = {l0 = 0} : Mut5
                while method36(v1206, v1226) do
                    let v1228 : int32 = v1226.l0
                    let v1229 : std_string_String = v1205.[int v1228]
                    let v1230 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1231 : bool = Fable.Core.RustInterop.emitRustExpr v1229 v1230 
                    let v1232 : int32 = v1228 + 1
                    v1226.l0 <- v1232
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v499 v327
            #endif
#if FABLE_COMPILER_PYTHON
            v499 v327
            #endif
#else
            v499 v327
            #endif
            // run_target_args' is_unit
            let v1233 : (string -> unit) = v439.l0
            v1233 v327
            US12_0(v438, v439, v440, v441, v442, v443)
    let v1276 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1276 
    ()
and method79 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method82 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "receipt_outcomes_len"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method83 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "receipt_outcomes"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method81 (v0 : int32, v1 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v2 : string = method12()
    let v13 : Mut3 = {l0 = v2} : Mut3
    method27(v13)
    method82(v13)
    method29(v13)
    let v417 : string = $"{v0}"
    method13(v13, v417)
    method52(v13)
    method83(v13)
    method29(v13)
    (* run_target_args'
    let v943 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v944 : string = "format!(\"{:#?}\", $0)"
    let v945 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v944 
    let v946 : string = "fable_library_rust::String_::fromString($0)"
    let v947 : string = Fable.Core.RustInterop.emitRustExpr v945 v946 
    let _run_target_args'_v943 = v947 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v948 : string = "format!(\"{:#?}\", $0)"
    let v949 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v948 
    let v950 : string = "fable_library_rust::String_::fromString($0)"
    let v951 : string = Fable.Core.RustInterop.emitRustExpr v949 v950 
    let _run_target_args'_v943 = v951 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v952 : string = "format!(\"{:#?}\", $0)"
    let v953 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v952 
    let v954 : string = "fable_library_rust::String_::fromString($0)"
    let v955 : string = Fable.Core.RustInterop.emitRustExpr v953 v954 
    let _run_target_args'_v943 = v955 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v958 : string = $"%A{v1}"
    let _run_target_args'_v943 = v958 
    #endif
#if FABLE_COMPILER_PYTHON
    let v972 : string = $"%A{v1}"
    let _run_target_args'_v943 = v972 
    #endif
#else
    let v986 : string = $"%A{v1}"
    let _run_target_args'_v943 = v986 
    #endif
    let v998 : string = _run_target_args'_v943 
    method13(v13, v998)
    method30(v13)
    let v1273 : string = v13.l0
    v1273
and method80 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v10 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v28 : string = method25(v10)
    let v31 : string = v16 + v28 
    let v45 : string = v31 + v7 
    let v59 : string = v45 + v15 
    let v75 : string = "spiral_wasm.run"
    let v76 : string = v59 + v75 
    let v92 : string = " / "
    let v93 : string = v76 + v92 
    let v105 : string = method81(v8, v9)
    let v108 : string = v93 + v105 
    method31(v108)
and closure34 (v0 : Vec<near_workspaces_result_ExecutionOutcome>, v1 : int32) () : unit =
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure14()
    let v64 : unit = (fun () -> v63 (); v62) ()
    let struct (v113 : Mut0, v114 : Mut1, v115 : Mut2, v116 : Mut3, v117 : Mut4, v118 : int64 option) = TraceState.trace_state.Value
    let v160 : US5 = v117.l0
    let v161 : bool = v115.l0
    let v162 : bool = v161 = false
    let v165 : bool =
        if v162 then
            false
        else
            let v163 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v160
            let v164 : bool = 0 >= v163
            v164
    let v166 : bool = v165 = false
    let v1235 : US12 =
        if v166 then
            US12_1
        else
            let v228 : unit = ()
            let v229 : unit = (fun () -> v63 (); v228) ()
            let struct (v278 : Mut0, v279 : Mut1, v280 : Mut2, v281 : Mut3, v282 : Mut4, v283 : int64 option) = TraceState.trace_state.Value
            let v325 : string = method18(v278, v279, v280, v281, v282, v283)
            let v326 : string = method22()
            let v327 : string = method80(v278, v279, v280, v281, v282, v283, v325, v326, v1, v0)
            let v388 : unit = ()
            let v389 : unit = (fun () -> v63 (); v388) ()
            let struct (v438 : Mut0, v439 : Mut1, v440 : Mut2, v441 : Mut3, v442 : Mut4, v443 : int64 option) = TraceState.trace_state.Value
            let v489 : unit = ()
            let v490 : (unit -> unit) = closure16(v438)
            let v491 : unit = (fun () -> v490 (); v489) ()
            let v499 : (string -> unit) = closure17()
            (* run_target_args'
            let v500 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v501 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v502 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v502 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v503 : string = v441.l0
            let v504 : bool = v503 = ""
            let v540 : string =
                if v504 then
                    v327
                else
                    let v505 : bool = v327 = ""
                    if v505 then
                        let v506 : string = v441.l0
                        v506
                    else
                        let v507 : string = v441.l0
                        let v512 : string = "\n"
                        let v513 : string = v507 + v512 
                        let v527 : string = v513 + v327 
                        v527
            (* run_target_args'
            let v723 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v724 : string = "&*$0"
            let v725 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v724 
            let _run_target_args'_v723 = v725 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v726 : string = "&*$0"
            let v727 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v726 
            let _run_target_args'_v723 = v727 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v728 : string = "&*$0"
            let v729 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v728 
            let _run_target_args'_v723 = v729 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v809 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v809 
            #endif
#if FABLE_COMPILER_PYTHON
            let v900 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v900 
            #endif
#else
            let v991 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v991 
            #endif
            let v1003 : Ref<Str> = _run_target_args'_v723 
            let v1186 : string = $"$0.chars()"
            let v1187 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1003 v1186 
            let v1188 : string = "$0"
            let v1189 : _ = Fable.Core.RustInterop.emitRustExpr v1187 v1188 
            let v1190 : string = "$0.collect::<Vec<_>>()"
            let v1191 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1189 v1190 
            let v1192 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1193 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1191 v1192 
            let v1194 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1195 : bool = Fable.Core.RustInterop.emitRustExpr v1193 v1194 
            let v1196 : string = "x"
            let v1197 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1196 
            let v1198 : string = "String::from_iter($0)"
            let v1199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1197 v1198 
            let v1200 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1201 : bool = Fable.Core.RustInterop.emitRustExpr v1199 v1200 
            let v1202 : string = "_vec_map"
            let v1203 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1202 
            let v1204 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1205 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1203 v1204 
            let v1206 : int32 = v1205.Length
            let v1211 : string = ""
            let v1212 : bool = v327 <> v1211 
            let v1225 : bool =
                if v1212 then
                    let v1224 : bool = v1206 <= 1
                    v1224
                else
                    false
            if v1225 then
                v441.l0 <- v540
                ()
            else
                v441.l0 <- v1211
                let v1226 : Mut5 = {l0 = 0} : Mut5
                while method36(v1206, v1226) do
                    let v1228 : int32 = v1226.l0
                    let v1229 : std_string_String = v1205.[int v1228]
                    let v1230 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1231 : bool = Fable.Core.RustInterop.emitRustExpr v1229 v1230 
                    let v1232 : int32 = v1228 + 1
                    v1226.l0 <- v1232
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v499 v327
            #endif
#if FABLE_COMPILER_PYTHON
            v499 v327
            #endif
#else
            v499 v327
            #endif
            // run_target_args' is_unit
            let v1233 : (string -> unit) = v439.l0
            v1233 v327
            US12_0(v438, v439, v440, v441, v442, v443)
    let v1276 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1276 
    ()
and method86 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "json"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method85 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    method27(v12)
    method86(v12)
    method29(v12)
    (* run_target_args'
    let v416 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v417 : string = "format!(\"{:#?}\", $0)"
    let v418 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v417 
    let v419 : string = "fable_library_rust::String_::fromString($0)"
    let v420 : string = Fable.Core.RustInterop.emitRustExpr v418 v419 
    let _run_target_args'_v416 = v420 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v421 : string = "format!(\"{:#?}\", $0)"
    let v422 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v421 
    let v423 : string = "fable_library_rust::String_::fromString($0)"
    let v424 : string = Fable.Core.RustInterop.emitRustExpr v422 v423 
    let _run_target_args'_v416 = v424 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v425 : string = "format!(\"{:#?}\", $0)"
    let v426 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v425 
    let v427 : string = "fable_library_rust::String_::fromString($0)"
    let v428 : string = Fable.Core.RustInterop.emitRustExpr v426 v427 
    let _run_target_args'_v416 = v428 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v431 : string = $"%A{v0}"
    let _run_target_args'_v416 = v431 
    #endif
#if FABLE_COMPILER_PYTHON
    let v445 : string = $"%A{v0}"
    let _run_target_args'_v416 = v445 
    #endif
#else
    let v459 : string = $"%A{v0}"
    let _run_target_args'_v416 = v459 
    #endif
    let v471 : string = _run_target_args'_v416 
    method13(v12, v471)
    method30(v12)
    let v746 : string = v12.l0
    v746
and method84 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v27 : string = method25(v9)
    let v30 : string = v15 + v27 
    let v44 : string = v30 + v7 
    let v58 : string = v44 + v14 
    let v74 : string = "spiral_wasm.run"
    let v75 : string = v58 + v74 
    let v91 : string = " / "
    let v92 : string = v75 + v91 
    let v104 : string = method85(v8)
    let v107 : string = v92 + v104 
    method31(v107)
and closure35 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure14()
    let v63 : unit = (fun () -> v62 (); v61) ()
    let struct (v112 : Mut0, v113 : Mut1, v114 : Mut2, v115 : Mut3, v116 : Mut4, v117 : int64 option) = TraceState.trace_state.Value
    let v159 : US5 = v116.l0
    let v160 : bool = v114.l0
    let v161 : bool = v160 = false
    let v164 : bool =
        if v161 then
            false
        else
            let v162 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v159
            let v163 : bool = 0 >= v162
            v163
    let v165 : bool = v164 = false
    let v1234 : US12 =
        if v165 then
            US12_1
        else
            let v227 : unit = ()
            let v228 : unit = (fun () -> v62 (); v227) ()
            let struct (v277 : Mut0, v278 : Mut1, v279 : Mut2, v280 : Mut3, v281 : Mut4, v282 : int64 option) = TraceState.trace_state.Value
            let v324 : string = method18(v277, v278, v279, v280, v281, v282)
            let v325 : string = method22()
            let v326 : string = method84(v277, v278, v279, v280, v281, v282, v324, v325, v0)
            let v387 : unit = ()
            let v388 : unit = (fun () -> v62 (); v387) ()
            let struct (v437 : Mut0, v438 : Mut1, v439 : Mut2, v440 : Mut3, v441 : Mut4, v442 : int64 option) = TraceState.trace_state.Value
            let v488 : unit = ()
            let v489 : (unit -> unit) = closure16(v437)
            let v490 : unit = (fun () -> v489 (); v488) ()
            let v498 : (string -> unit) = closure17()
            (* run_target_args'
            let v499 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v500 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v500 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v501 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v502 : string = v440.l0
            let v503 : bool = v502 = ""
            let v539 : string =
                if v503 then
                    v326
                else
                    let v504 : bool = v326 = ""
                    if v504 then
                        let v505 : string = v440.l0
                        v505
                    else
                        let v506 : string = v440.l0
                        let v511 : string = "\n"
                        let v512 : string = v506 + v511 
                        let v526 : string = v512 + v326 
                        v526
            (* run_target_args'
            let v722 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v723 : string = "&*$0"
            let v724 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v723 
            let _run_target_args'_v722 = v724 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v725 : string = "&*$0"
            let v726 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v725 
            let _run_target_args'_v722 = v726 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v727 : string = "&*$0"
            let v728 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v727 
            let _run_target_args'_v722 = v728 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v808 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v808 
            #endif
#if FABLE_COMPILER_PYTHON
            let v899 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v899 
            #endif
#else
            let v990 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v990 
            #endif
            let v1002 : Ref<Str> = _run_target_args'_v722 
            let v1185 : string = $"$0.chars()"
            let v1186 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1002 v1185 
            let v1187 : string = "$0"
            let v1188 : _ = Fable.Core.RustInterop.emitRustExpr v1186 v1187 
            let v1189 : string = "$0.collect::<Vec<_>>()"
            let v1190 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1188 v1189 
            let v1191 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1192 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1190 v1191 
            let v1193 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1194 : bool = Fable.Core.RustInterop.emitRustExpr v1192 v1193 
            let v1195 : string = "x"
            let v1196 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1195 
            let v1197 : string = "String::from_iter($0)"
            let v1198 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1196 v1197 
            let v1199 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1200 : bool = Fable.Core.RustInterop.emitRustExpr v1198 v1199 
            let v1201 : string = "_vec_map"
            let v1202 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1201 
            let v1203 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1204 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1202 v1203 
            let v1205 : int32 = v1204.Length
            let v1210 : string = ""
            let v1211 : bool = v326 <> v1210 
            let v1224 : bool =
                if v1211 then
                    let v1223 : bool = v1205 <= 1
                    v1223
                else
                    false
            if v1224 then
                v440.l0 <- v539
                ()
            else
                v440.l0 <- v1210
                let v1225 : Mut5 = {l0 = 0} : Mut5
                while method36(v1205, v1225) do
                    let v1227 : int32 = v1225.l0
                    let v1228 : std_string_String = v1204.[int v1227]
                    let v1229 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1230 : bool = Fable.Core.RustInterop.emitRustExpr v1228 v1229 
                    let v1231 : int32 = v1227 + 1
                    v1225.l0 <- v1231
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v498 v326
            #endif
#if FABLE_COMPILER_PYTHON
            v498 v326
            #endif
#else
            v498 v326
            #endif
            // run_target_args' is_unit
            let v1232 : (string -> unit) = v438.l0
            v1232 v326
            US12_0(v437, v438, v439, v440, v441, v442)
    let v1275 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1275 
    ()
and method89 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "borsh"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method88 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    method27(v12)
    method89(v12)
    method29(v12)
    (* run_target_args'
    let v416 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v417 : string = "format!(\"{:#?}\", $0)"
    let v418 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v417 
    let v419 : string = "fable_library_rust::String_::fromString($0)"
    let v420 : string = Fable.Core.RustInterop.emitRustExpr v418 v419 
    let _run_target_args'_v416 = v420 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v421 : string = "format!(\"{:#?}\", $0)"
    let v422 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v421 
    let v423 : string = "fable_library_rust::String_::fromString($0)"
    let v424 : string = Fable.Core.RustInterop.emitRustExpr v422 v423 
    let _run_target_args'_v416 = v424 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v425 : string = "format!(\"{:#?}\", $0)"
    let v426 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v425 
    let v427 : string = "fable_library_rust::String_::fromString($0)"
    let v428 : string = Fable.Core.RustInterop.emitRustExpr v426 v427 
    let _run_target_args'_v416 = v428 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v431 : string = $"%A{v0}"
    let _run_target_args'_v416 = v431 
    #endif
#if FABLE_COMPILER_PYTHON
    let v445 : string = $"%A{v0}"
    let _run_target_args'_v416 = v445 
    #endif
#else
    let v459 : string = $"%A{v0}"
    let _run_target_args'_v416 = v459 
    #endif
    let v471 : string = _run_target_args'_v416 
    method13(v12, v471)
    method30(v12)
    let v746 : string = v12.l0
    v746
and method87 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v27 : string = method25(v9)
    let v30 : string = v15 + v27 
    let v44 : string = v30 + v7 
    let v58 : string = v44 + v14 
    let v74 : string = "spiral_wasm.run"
    let v75 : string = v58 + v74 
    let v91 : string = " / "
    let v92 : string = v75 + v91 
    let v104 : string = method88(v8)
    let v107 : string = v92 + v104 
    method31(v107)
and closure36 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure14()
    let v63 : unit = (fun () -> v62 (); v61) ()
    let struct (v112 : Mut0, v113 : Mut1, v114 : Mut2, v115 : Mut3, v116 : Mut4, v117 : int64 option) = TraceState.trace_state.Value
    let v159 : US5 = v116.l0
    let v160 : bool = v114.l0
    let v161 : bool = v160 = false
    let v164 : bool =
        if v161 then
            false
        else
            let v162 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v159
            let v163 : bool = 0 >= v162
            v163
    let v165 : bool = v164 = false
    let v1234 : US12 =
        if v165 then
            US12_1
        else
            let v227 : unit = ()
            let v228 : unit = (fun () -> v62 (); v227) ()
            let struct (v277 : Mut0, v278 : Mut1, v279 : Mut2, v280 : Mut3, v281 : Mut4, v282 : int64 option) = TraceState.trace_state.Value
            let v324 : string = method18(v277, v278, v279, v280, v281, v282)
            let v325 : string = method22()
            let v326 : string = method87(v277, v278, v279, v280, v281, v282, v324, v325, v0)
            let v387 : unit = ()
            let v388 : unit = (fun () -> v62 (); v387) ()
            let struct (v437 : Mut0, v438 : Mut1, v439 : Mut2, v440 : Mut3, v441 : Mut4, v442 : int64 option) = TraceState.trace_state.Value
            let v488 : unit = ()
            let v489 : (unit -> unit) = closure16(v437)
            let v490 : unit = (fun () -> v489 (); v488) ()
            let v498 : (string -> unit) = closure17()
            (* run_target_args'
            let v499 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v500 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v500 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v501 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v502 : string = v440.l0
            let v503 : bool = v502 = ""
            let v539 : string =
                if v503 then
                    v326
                else
                    let v504 : bool = v326 = ""
                    if v504 then
                        let v505 : string = v440.l0
                        v505
                    else
                        let v506 : string = v440.l0
                        let v511 : string = "\n"
                        let v512 : string = v506 + v511 
                        let v526 : string = v512 + v326 
                        v526
            (* run_target_args'
            let v722 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v723 : string = "&*$0"
            let v724 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v723 
            let _run_target_args'_v722 = v724 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v725 : string = "&*$0"
            let v726 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v725 
            let _run_target_args'_v722 = v726 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v727 : string = "&*$0"
            let v728 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v727 
            let _run_target_args'_v722 = v728 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v808 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v808 
            #endif
#if FABLE_COMPILER_PYTHON
            let v899 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v899 
            #endif
#else
            let v990 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v990 
            #endif
            let v1002 : Ref<Str> = _run_target_args'_v722 
            let v1185 : string = $"$0.chars()"
            let v1186 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1002 v1185 
            let v1187 : string = "$0"
            let v1188 : _ = Fable.Core.RustInterop.emitRustExpr v1186 v1187 
            let v1189 : string = "$0.collect::<Vec<_>>()"
            let v1190 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1188 v1189 
            let v1191 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1192 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1190 v1191 
            let v1193 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1194 : bool = Fable.Core.RustInterop.emitRustExpr v1192 v1193 
            let v1195 : string = "x"
            let v1196 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1195 
            let v1197 : string = "String::from_iter($0)"
            let v1198 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1196 v1197 
            let v1199 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1200 : bool = Fable.Core.RustInterop.emitRustExpr v1198 v1199 
            let v1201 : string = "_vec_map"
            let v1202 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1201 
            let v1203 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1204 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1202 v1203 
            let v1205 : int32 = v1204.Length
            let v1210 : string = ""
            let v1211 : bool = v326 <> v1210 
            let v1224 : bool =
                if v1211 then
                    let v1223 : bool = v1205 <= 1
                    v1223
                else
                    false
            if v1224 then
                v440.l0 <- v539
                ()
            else
                v440.l0 <- v1210
                let v1225 : Mut5 = {l0 = 0} : Mut5
                while method36(v1205, v1225) do
                    let v1227 : int32 = v1225.l0
                    let v1228 : std_string_String = v1204.[int v1227]
                    let v1229 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1230 : bool = Fable.Core.RustInterop.emitRustExpr v1228 v1229 
                    let v1231 : int32 = v1227 + 1
                    v1225.l0 <- v1231
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v498 v326
            #endif
#if FABLE_COMPILER_PYTHON
            v498 v326
            #endif
#else
            v498 v326
            #endif
            // run_target_args' is_unit
            let v1232 : (string -> unit) = v438.l0
            v1232 v326
            US12_0(v437, v438, v439, v440, v441, v442)
    let v1275 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1275 
    ()
and method90 (v0 : int32, v1 : uint8, v2 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v3 : string = method12()
    let v14 : Mut3 = {l0 = v3} : Mut3
    method27(v14)
    method82(v14)
    method29(v14)
    let v418 : string = $"{v0}"
    method13(v14, v418)
    method52(v14)
    method51(v14)
    method29(v14)
    let v944 : string = $"{v1}"
    method13(v14, v944)
    method52(v14)
    method78(v14)
    method29(v14)
    (* run_target_args'
    let v1470 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1471 : string = "format!(\"{:#?}\", $0)"
    let v1472 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v1471 
    let v1473 : string = "fable_library_rust::String_::fromString($0)"
    let v1474 : string = Fable.Core.RustInterop.emitRustExpr v1472 v1473 
    let _run_target_args'_v1470 = v1474 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1475 : string = "format!(\"{:#?}\", $0)"
    let v1476 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v1475 
    let v1477 : string = "fable_library_rust::String_::fromString($0)"
    let v1478 : string = Fable.Core.RustInterop.emitRustExpr v1476 v1477 
    let _run_target_args'_v1470 = v1478 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1479 : string = "format!(\"{:#?}\", $0)"
    let v1480 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v1479 
    let v1481 : string = "fable_library_rust::String_::fromString($0)"
    let v1482 : string = Fable.Core.RustInterop.emitRustExpr v1480 v1481 
    let _run_target_args'_v1470 = v1482 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1485 : string = $"%A{v2}"
    let _run_target_args'_v1470 = v1485 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1499 : string = $"%A{v2}"
    let _run_target_args'_v1470 = v1499 
    #endif
#else
    let v1513 : string = $"%A{v2}"
    let _run_target_args'_v1470 = v1513 
    #endif
    let v1525 : string = _run_target_args'_v1470 
    method13(v14, v1525)
    method30(v14)
    let v1800 : string = v14.l0
    v1800
and method48 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<Result<US10, anyhow_Error>>>>> =
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
    let v2585 : unit = ()
    let v2586 : (unit -> unit) = closure21(v1, v11, v19)
    let v2587 : unit = (fun () -> v2586 (); v2585) ()
    let v3877 : string = "$0.call(&*$1)"
    let v3878 : string = "state_main"
    let v3879 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr struct (v19, v3878) v3877 
    let v3880 : string = "near_workspaces::types::Gas::from_tgas(300)"
    let v3881 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr () v3880 
    let v3882 : string = "v3879.gas(v3881)"
    let v3883 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr () v3882 
    let v3884 : string = "Box::pin(v3883.transact())"
    let v3885 : std_pin_Pin<Box<Dyn<std_future_Future<Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v3884 
    let v3886 : string = "v3885.await"
    let v3887 : Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v3886 
    let v3888 : string = "$0?"
    let v3889 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v3887 v3888 
    let v6455 : unit = ()
    let v6456 : (unit -> unit) = closure22(v1, v3889)
    let v6457 : unit = (fun () -> v6456 (); v6455) ()
    let v7747 : string = "v3889.logs()"
    let v7748 : Vec<Ref<Str>> = Fable.Core.RustInterop.emitRustExpr () v7747 
    let v7749 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v7750 : bool = Fable.Core.RustInterop.emitRustExpr v7748 v7749 
    let v7751 : string = "x"
    let v7752 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v7751 
    (* run_target_args'
    let v7935 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7936 : string = "String::from($0)"
    let v7937 : std_string_String = Fable.Core.RustInterop.emitRustExpr v7752 v7936 
    let _run_target_args'_v7935 = v7937 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7938 : string = "String::from($0)"
    let v7939 : std_string_String = Fable.Core.RustInterop.emitRustExpr v7752 v7938 
    let _run_target_args'_v7935 = v7939 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v7940 : string = "String::from($0)"
    let v7941 : std_string_String = Fable.Core.RustInterop.emitRustExpr v7752 v7940 
    let _run_target_args'_v7935 = v7941 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v8021 : std_string_String = v7752 |> unbox<std_string_String>
    let _run_target_args'_v7935 = v8021 
    #endif
#if FABLE_COMPILER_PYTHON
    let v8112 : std_string_String = v7752 |> unbox<std_string_String>
    let _run_target_args'_v7935 = v8112 
    #endif
#else
    let v8203 : std_string_String = v7752 |> unbox<std_string_String>
    let _run_target_args'_v7935 = v8203 
    #endif
    let v8215 : std_string_String = _run_target_args'_v7935 
    let v8398 : string = "true; $0 }).collect::<Vec<_>>()"
    let v8399 : bool = Fable.Core.RustInterop.emitRustExpr v8215 v8398 
    let v8400 : string = "_vec_map"
    let v8401 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v8400 
    let v8402 : string = "true; $0.iter().for_each(|x| { $1(x.clone()); }); //"
    let v8403 : (std_string_String -> unit) = closure23()
    let v8404 : bool = Fable.Core.RustInterop.emitRustExpr struct (v8401, v8403) v8402 
    let v10653 : unit = ()
    let v10654 : (unit -> unit) = closure25()
    let v10655 : unit = (fun () -> v10654 (); v10653) ()
    let v11786 : string = "$0.total_gas_burnt"
    let v11787 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v3889 v11786 
    let v11788 : string = "$0.as_gas()"
    let v11789 : uint64 = Fable.Core.RustInterop.emitRustExpr v11787 v11788 
    let v11869 : (uint64 -> float) = float
    let v11870 : float = v11869 v11789
    let v11882 : float = v11870 / 10000000000000000.0
    let v11883 : float = v11882 * 6.68
    let v14449 : unit = ()
    let v14450 : (unit -> unit) = closure26(v1, v11789, v11883)
    let v14451 : unit = (fun () -> v14450 (); v14449) ()
    let v15741 : string = "$0"
    let v15742 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v3889 v15741 
    let v15743 : string = "v15742.outcomes()"
    let v15744 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v15743 
    let v15745 : string = "v15744.into_iter()"
    let v15746 : _ = Fable.Core.RustInterop.emitRustExpr () v15745 
    let v15747 : string = "v15746.cloned()"
    let v15748 : _ = Fable.Core.RustInterop.emitRustExpr () v15747 
    let v15749 : string = "true; v15748.for_each(|x| $0(x))"
    let v15750 : (near_workspaces_result_ExecutionOutcome -> unit) = closure27()
    let v15751 : bool = Fable.Core.RustInterop.emitRustExpr v15750 v15749 
    let v15752 : string = "$0.into_result()"
    let v15753 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure> = Fable.Core.RustInterop.emitRustExpr v3889 v15752 
    let v18319 : unit = ()
    let v18320 : (unit -> unit) = closure29(v15753)
    let v18321 : unit = (fun () -> v18320 (); v18319) ()
    let v19611 : near_workspaces_result_ExecutionFinalResult = method73(v3889)
    let v19612 : string = "v19611.receipt_failures()"
    let v19613 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v19612 
    let v19614 : string = "$0.len()"
    let v19615 : unativeint = Fable.Core.RustInterop.emitRustExpr v19613 v19614 
    let v19804 : US15 = method74(v19615)
    let v19825 : US16 =
        match v19804 with
        | US15_1(v19822) -> (* Error *)
            US16_1
        | US15_0(v19820) -> (* Ok *)
            US16_0(v19820)
    let v19872 : int32 =
        match v19825 with
        | US16_1 -> (* None *)
            failwith<int32> "Option does not have a value."
        | US16_0(v19869) -> (* Some *)
            v19869
    let v22535 : unit = ()
    let v22536 : (unit -> unit) = closure33(v19613, v19872)
    let v22537 : unit = (fun () -> v22536 (); v22535) ()
    let v23827 : near_workspaces_result_ExecutionFinalResult = method79(v3889)
    let v23828 : string = "v23827.receipt_outcomes()"
    let v23829 : Ref<Slice<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v23828 
    let v23830 : string = "v23829.into()"
    let v23831 : Vec<near_workspaces_result_ExecutionOutcome> = Fable.Core.RustInterop.emitRustExpr () v23830 
    let v23832 : string = "$0.len()"
    let v23833 : unativeint = Fable.Core.RustInterop.emitRustExpr v23831 v23832 
    let v24022 : US15 = method74(v23833)
    let v24043 : US16 =
        match v24022 with
        | US15_1(v24040) -> (* Error *)
            US16_1
        | US15_0(v24038) -> (* Ok *)
            US16_0(v24038)
    let v24090 : int32 =
        match v24043 with
        | US16_1 -> (* None *)
            failwith<int32> "Option does not have a value."
        | US16_0(v24087) -> (* Some *)
            v24087
    let v26753 : unit = ()
    let v26754 : (unit -> unit) = closure34(v23831, v24090)
    let v26755 : unit = (fun () -> v26754 (); v26753) ()
    let v28045 : string = "$0.json()"
    let v28046 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v3889 v28045 
    let v30612 : unit = ()
    let v30613 : (unit -> unit) = closure35(v28046)
    let v30614 : unit = (fun () -> v30613 (); v30612) ()
    let v31904 : string = "$0.borsh()"
    let v31905 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v3889 v31904 
    let v34471 : unit = ()
    let v34472 : (unit -> unit) = closure36(v31905)
    let v34473 : unit = (fun () -> v34472 (); v34471) ()
    let v35763 : string = method90(v24090, v1, v19613)
    let v35764 : bool = v19872 > 0
    let v35820 : Result<US10, anyhow_Error> =
        if v35764 then
            let v35769 : US10 = US10_0(v35763)
            let v35770 : Result<US10, anyhow_Error> = Ok v35769 
            v35770
        else
            let v35783 : bool = v24090 > 1
            if v35783 then
                let v35788 : US10 = US10_1
                let v35789 : Result<US10, anyhow_Error> = Ok v35788 
                v35789
            else
                let v35802 : string = "anyhow::anyhow!($0)"
                let v35803 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v35763 v35802 
                (* run_target_args'
                let v35806 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v35807 : string = "Err($0)"
                let v35808 : Result<US10, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v35803 v35807 
                let _run_target_args'_v35806 = v35808 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v35809 : string = "Err($0)"
                let v35810 : Result<US10, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v35803 v35809 
                let _run_target_args'_v35806 = v35810 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v35811 : string = "Err($0)"
                let v35812 : Result<US10, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v35803 v35811 
                let _run_target_args'_v35806 = v35812 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v35813 : Result<US10, anyhow_Error> = v35803 |> Error
                let _run_target_args'_v35806 = v35813 
                #endif
#if FABLE_COMPILER_PYTHON
                let v35814 : Result<US10, anyhow_Error> = v35803 |> Error
                let _run_target_args'_v35806 = v35814 
                #endif
#else
                let v35815 : Result<US10, anyhow_Error> = v35803 |> Error
                let _run_target_args'_v35806 = v35815 
                #endif
                let v35816 : Result<US10, anyhow_Error> = _run_target_args'_v35806 
                v35816
    let v35821 : string = ""
    let v35822 : string = "}"
    let v35823 : string = v35821 + v35822 
    let x = v35820 //
    let v35824 : _ = x
    let v35825 : unit = ()
    (* run_target_args'
    let v35826 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v35827 : string = $"true; let _fix_closure_v35825 = $0"
    let v35828 : bool = Fable.Core.RustInterop.emitRustExpr v35824 v35827 
    let _run_target_args'_v35826 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v35829 : string = $"true; let _fix_closure_v35825 = $0"
    let v35830 : bool = Fable.Core.RustInterop.emitRustExpr v35824 v35829 
    let _run_target_args'_v35826 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v35831 : string = $"true; let _fix_closure_v35825 = $0"
    let v35832 : bool = Fable.Core.RustInterop.emitRustExpr v35824 v35831 
    let _run_target_args'_v35826 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v35826 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v35826 = false 
    #endif
#else
    let _run_target_args'_v35826 = false 
    #endif
    let v35833 : bool = _run_target_args'_v35826 
    let v35834 : string = $"true; _fix_closure_v35825 " + v35823 + "); " + v35821 + " // rust.fix_closure'"
    let v35835 : bool = Fable.Core.RustInterop.emitRustExpr () v35834 
    let v35836 : string = "__future_init"
    let v35837 : _ = Fable.Core.RustInterop.emitRustExpr () v35836 
    let v35838 : string = "v35837"
    let v35839 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US10, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v35838 
    v35839
and closure37 () (v0 : anyhow_Error) : std_string_String =
    (* run_target_args'
    let v29 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v30 : string = "format!(\"{}\", $0)"
    let v31 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v30 
    let _run_target_args'_v29 = v31 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v32 : string = "format!(\"{}\", $0)"
    let v33 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v32 
    let _run_target_args'_v29 = v33 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v34 : string = "format!(\"{}\", $0)"
    let v35 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v34 
    let _run_target_args'_v29 = v35 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v38 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v29 = v38 
    #endif
#if FABLE_COMPILER_PYTHON
    let v52 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v29 = v52 
    #endif
#else
    let v66 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v29 = v66 
    #endif
    let v78 : std_string_String = _run_target_args'_v29 
    v78
and method91 () : (anyhow_Error -> std_string_String) =
    closure37()
and closure38 () (v0 : US10) : US17 =
    US17_0(v0)
and method92 () : (US10 -> US17) =
    closure38()
and closure39 () (v0 : std_string_String) : US17 =
    US17_1(v0)
and method93 () : (std_string_String -> US17) =
    closure39()
and method94 () : string =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "inline_colorization::color_yellow"
    let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3 
    (* run_target_args'
    let v187 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v188 : string = "String::from($0)"
    let v189 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v188 
    let _run_target_args'_v187 = v189 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v190 : string = "String::from($0)"
    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v190 
    let _run_target_args'_v187 = v191 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v192 : string = "String::from($0)"
    let v193 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v192 
    let _run_target_args'_v187 = v193 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v273 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v273 
    #endif
#if FABLE_COMPILER_PYTHON
    let v364 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v364 
    #endif
#else
    let v455 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v455 
    #endif
    let v467 : std_string_String = _run_target_args'_v187 
    let v650 : string = "fable_library_rust::String_::fromString($0)"
    let v651 : string = Fable.Core.RustInterop.emitRustExpr v467 v650 
    let _run_target_args'_v2 = v651 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v652 : string = "inline_colorization::color_yellow"
    let v653 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v652 
    (* run_target_args'
    let v836 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v837 : string = "String::from($0)"
    let v838 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v837 
    let _run_target_args'_v836 = v838 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v839 : string = "String::from($0)"
    let v840 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v839 
    let _run_target_args'_v836 = v840 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v841 : string = "String::from($0)"
    let v842 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v841 
    let _run_target_args'_v836 = v842 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v922 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v922 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1013 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v1013 
    #endif
#else
    let v1104 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v1104 
    #endif
    let v1116 : std_string_String = _run_target_args'_v836 
    let v1299 : string = "fable_library_rust::String_::fromString($0)"
    let v1300 : string = Fable.Core.RustInterop.emitRustExpr v1116 v1299 
    let _run_target_args'_v2 = v1300 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1301 : string = "inline_colorization::color_yellow"
    let v1302 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1301 
    (* run_target_args'
    let v1485 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1486 : string = "String::from($0)"
    let v1487 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1486 
    let _run_target_args'_v1485 = v1487 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1488 : string = "String::from($0)"
    let v1489 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1488 
    let _run_target_args'_v1485 = v1489 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1490 : string = "String::from($0)"
    let v1491 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1490 
    let _run_target_args'_v1485 = v1491 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1571 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1571 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1662 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1662 
    #endif
#else
    let v1753 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1753 
    #endif
    let v1765 : std_string_String = _run_target_args'_v1485 
    let v1948 : string = "fable_library_rust::String_::fromString($0)"
    let v1949 : string = Fable.Core.RustInterop.emitRustExpr v1765 v1948 
    let _run_target_args'_v2 = v1949 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1950 : string = "\u001b[93m"
    let _run_target_args'_v2 = v1950 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1951 : string = "\u001b[93m"
    let _run_target_args'_v2 = v1951 
    #endif
#else
    let v1952 : string = "\u001b[93m"
    let _run_target_args'_v2 = v1952 
    #endif
    let v1953 : string = _run_target_args'_v2 
    
    
    
    
    
    let v1960 : string = "Warning"
    let v1961 : (unit -> string) = v1960.ToLower
    let v1962 : string = v1961 ()
    let v1974 : char = v1962.[int 0]
    let v1975 : string = method23(v1974)
    let v1978 : string = v1953 + v1975 
    (* run_target_args'
    let v1992 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1993 : string = "inline_colorization::color_reset"
    let v1994 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1993 
    (* run_target_args'
    let v2177 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2178 : string = "String::from($0)"
    let v2179 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2178 
    let _run_target_args'_v2177 = v2179 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2180 : string = "String::from($0)"
    let v2181 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2180 
    let _run_target_args'_v2177 = v2181 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2182 : string = "String::from($0)"
    let v2183 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2182 
    let _run_target_args'_v2177 = v2183 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2263 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2263 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2354 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2354 
    #endif
#else
    let v2445 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2445 
    #endif
    let v2457 : std_string_String = _run_target_args'_v2177 
    let v2640 : string = "fable_library_rust::String_::fromString($0)"
    let v2641 : string = Fable.Core.RustInterop.emitRustExpr v2457 v2640 
    let _run_target_args'_v1992 = v2641 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2642 : string = "inline_colorization::color_reset"
    let v2643 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2642 
    (* run_target_args'
    let v2826 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2827 : string = "String::from($0)"
    let v2828 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2827 
    let _run_target_args'_v2826 = v2828 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2829 : string = "String::from($0)"
    let v2830 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2829 
    let _run_target_args'_v2826 = v2830 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2831 : string = "String::from($0)"
    let v2832 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2831 
    let _run_target_args'_v2826 = v2832 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2912 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v2912 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3003 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v3003 
    #endif
#else
    let v3094 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v3094 
    #endif
    let v3106 : std_string_String = _run_target_args'_v2826 
    let v3289 : string = "fable_library_rust::String_::fromString($0)"
    let v3290 : string = Fable.Core.RustInterop.emitRustExpr v3106 v3289 
    let _run_target_args'_v1992 = v3290 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3291 : string = "inline_colorization::color_reset"
    let v3292 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3291 
    (* run_target_args'
    let v3475 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3476 : string = "String::from($0)"
    let v3477 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3476 
    let _run_target_args'_v3475 = v3477 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3478 : string = "String::from($0)"
    let v3479 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3478 
    let _run_target_args'_v3475 = v3479 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3480 : string = "String::from($0)"
    let v3481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3480 
    let _run_target_args'_v3475 = v3481 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3561 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3561 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3652 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3652 
    #endif
#else
    let v3743 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3743 
    #endif
    let v3755 : std_string_String = _run_target_args'_v3475 
    let v3938 : string = "fable_library_rust::String_::fromString($0)"
    let v3939 : string = Fable.Core.RustInterop.emitRustExpr v3755 v3938 
    let _run_target_args'_v1992 = v3939 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3940 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3940 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3941 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3941 
    #endif
#else
    let v3942 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3942 
    #endif
    let v3943 : string = _run_target_args'_v1992 
    let v3948 : string = v1978 + v3943 
    v3948
and method97 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "error"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method96 (v0 : uint8, v1 : std_string_String) : string =
    let v2 : string = method12()
    let v13 : Mut3 = {l0 = v2} : Mut3
    method27(v13)
    method51(v13)
    method29(v13)
    let v417 : string = $"{v0}"
    method13(v13, v417)
    method52(v13)
    method97(v13)
    method29(v13)
    (* run_target_args'
    let v943 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v944 : string = "format!(\"{:#?}\", $0)"
    let v945 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v944 
    let v946 : string = "fable_library_rust::String_::fromString($0)"
    let v947 : string = Fable.Core.RustInterop.emitRustExpr v945 v946 
    let _run_target_args'_v943 = v947 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v948 : string = "format!(\"{:#?}\", $0)"
    let v949 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v948 
    let v950 : string = "fable_library_rust::String_::fromString($0)"
    let v951 : string = Fable.Core.RustInterop.emitRustExpr v949 v950 
    let _run_target_args'_v943 = v951 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v952 : string = "format!(\"{:#?}\", $0)"
    let v953 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v952 
    let v954 : string = "fable_library_rust::String_::fromString($0)"
    let v955 : string = Fable.Core.RustInterop.emitRustExpr v953 v954 
    let _run_target_args'_v943 = v955 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v958 : string = $"%A{v1}"
    let _run_target_args'_v943 = v958 
    #endif
#if FABLE_COMPILER_PYTHON
    let v972 : string = $"%A{v1}"
    let _run_target_args'_v943 = v972 
    #endif
#else
    let v986 : string = $"%A{v1}"
    let _run_target_args'_v943 = v986 
    #endif
    let v998 : string = _run_target_args'_v943 
    method13(v13, v998)
    method30(v13)
    let v1273 : string = v13.l0
    v1273
and method95 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : std_string_String) : string =
    let v10 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v28 : string = method25(v10)
    let v31 : string = v16 + v28 
    let v45 : string = v31 + v7 
    let v59 : string = v45 + v15 
    let v75 : string = "spiral_wasm.run / Error error"
    let v76 : string = v59 + v75 
    let v92 : string = " / "
    let v93 : string = v76 + v92 
    let v105 : string = method96(v8, v9)
    let v108 : string = v93 + v105 
    method31(v108)
and closure40 (v0 : uint8, v1 : std_string_String) () : unit =
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure14()
    let v64 : unit = (fun () -> v63 (); v62) ()
    let struct (v113 : Mut0, v114 : Mut1, v115 : Mut2, v116 : Mut3, v117 : Mut4, v118 : int64 option) = TraceState.trace_state.Value
    let v160 : US5 = v117.l0
    let v161 : bool = v115.l0
    let v162 : bool = v161 = false
    let v165 : bool =
        if v162 then
            false
        else
            let v163 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v160
            let v164 : bool = 3 >= v163
            v164
    let v166 : bool = v165 = false
    let v1235 : US12 =
        if v166 then
            US12_1
        else
            let v228 : unit = ()
            let v229 : unit = (fun () -> v63 (); v228) ()
            let struct (v278 : Mut0, v279 : Mut1, v280 : Mut2, v281 : Mut3, v282 : Mut4, v283 : int64 option) = TraceState.trace_state.Value
            let v325 : string = method18(v278, v279, v280, v281, v282, v283)
            let v326 : string = method94()
            let v327 : string = method95(v278, v279, v280, v281, v282, v283, v325, v326, v0, v1)
            let v388 : unit = ()
            let v389 : unit = (fun () -> v63 (); v388) ()
            let struct (v438 : Mut0, v439 : Mut1, v440 : Mut2, v441 : Mut3, v442 : Mut4, v443 : int64 option) = TraceState.trace_state.Value
            let v489 : unit = ()
            let v490 : (unit -> unit) = closure16(v438)
            let v491 : unit = (fun () -> v490 (); v489) ()
            let v499 : (string -> unit) = closure17()
            (* run_target_args'
            let v500 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v501 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v502 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v502 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v503 : string = v441.l0
            let v504 : bool = v503 = ""
            let v540 : string =
                if v504 then
                    v327
                else
                    let v505 : bool = v327 = ""
                    if v505 then
                        let v506 : string = v441.l0
                        v506
                    else
                        let v507 : string = v441.l0
                        let v512 : string = "\n"
                        let v513 : string = v507 + v512 
                        let v527 : string = v513 + v327 
                        v527
            (* run_target_args'
            let v723 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v724 : string = "&*$0"
            let v725 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v724 
            let _run_target_args'_v723 = v725 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v726 : string = "&*$0"
            let v727 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v726 
            let _run_target_args'_v723 = v727 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v728 : string = "&*$0"
            let v729 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v728 
            let _run_target_args'_v723 = v729 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v809 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v809 
            #endif
#if FABLE_COMPILER_PYTHON
            let v900 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v900 
            #endif
#else
            let v991 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v991 
            #endif
            let v1003 : Ref<Str> = _run_target_args'_v723 
            let v1186 : string = $"$0.chars()"
            let v1187 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1003 v1186 
            let v1188 : string = "$0"
            let v1189 : _ = Fable.Core.RustInterop.emitRustExpr v1187 v1188 
            let v1190 : string = "$0.collect::<Vec<_>>()"
            let v1191 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1189 v1190 
            let v1192 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1193 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1191 v1192 
            let v1194 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1195 : bool = Fable.Core.RustInterop.emitRustExpr v1193 v1194 
            let v1196 : string = "x"
            let v1197 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1196 
            let v1198 : string = "String::from_iter($0)"
            let v1199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1197 v1198 
            let v1200 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1201 : bool = Fable.Core.RustInterop.emitRustExpr v1199 v1200 
            let v1202 : string = "_vec_map"
            let v1203 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1202 
            let v1204 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1205 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1203 v1204 
            let v1206 : int32 = v1205.Length
            let v1211 : string = ""
            let v1212 : bool = v327 <> v1211 
            let v1225 : bool =
                if v1212 then
                    let v1224 : bool = v1206 <= 1
                    v1224
                else
                    false
            if v1225 then
                v441.l0 <- v540
                ()
            else
                v441.l0 <- v1211
                let v1226 : Mut5 = {l0 = 0} : Mut5
                while method36(v1206, v1226) do
                    let v1228 : int32 = v1226.l0
                    let v1229 : std_string_String = v1205.[int v1228]
                    let v1230 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1231 : bool = Fable.Core.RustInterop.emitRustExpr v1229 v1230 
                    let v1232 : int32 = v1228 + 1
                    v1226.l0 <- v1232
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v499 v327
            #endif
#if FABLE_COMPILER_PYTHON
            v499 v327
            #endif
#else
            v499 v327
            #endif
            // run_target_args' is_unit
            let v1233 : (string -> unit) = v439.l0
            v1233 v327
            US12_0(v438, v439, v440, v441, v442, v443)
    let v1276 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1276 
    ()
and closure41 () () : unit =
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure14()
    let v62 : unit = (fun () -> v61 (); v60) ()
    let struct (v111 : Mut0, v112 : Mut1, v113 : Mut2, v114 : Mut3, v115 : Mut4, v116 : int64 option) = TraceState.trace_state.Value
    let v158 : US5 = v115.l0
    let v159 : bool = v113.l0
    let v160 : bool = v159 = false
    let v163 : bool =
        if v160 then
            false
        else
            let v161 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v158
            let v162 : bool = 3 >= v161
            v162
    let v164 : bool = v163 = false
    let v1071 : US12 =
        if v164 then
            US12_1
        else
            let v226 : unit = ()
            let v227 : unit = (fun () -> v61 (); v226) ()
            let struct (v276 : Mut0, v277 : Mut1, v278 : Mut2, v279 : Mut3, v280 : Mut4, v281 : int64 option) = TraceState.trace_state.Value
            let v327 : unit = ()
            let v328 : (unit -> unit) = closure16(v276)
            let v329 : unit = (fun () -> v328 (); v327) ()
            let v337 : string = "\n"
            let v338 : (string -> unit) = closure17()
            (* run_target_args'
            let v339 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v340 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v337 v340 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v341 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v337 v341 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v342 : string = v279.l0
            let v343 : bool = v342 = ""
            let v376 : string =
                if v343 then
                    v337
                else
                    let v344 : bool = v337 = ""
                    if v344 then
                        let v345 : string = v279.l0
                        v345
                    else
                        let v346 : string = v279.l0
                        let v349 : string = v346 + v337 
                        let v363 : string = v349 + v337 
                        v363
            (* run_target_args'
            let v559 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v560 : string = "&*$0"
            let v561 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v376 v560 
            let _run_target_args'_v559 = v561 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v562 : string = "&*$0"
            let v563 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v376 v562 
            let _run_target_args'_v559 = v563 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v564 : string = "&*$0"
            let v565 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v376 v564 
            let _run_target_args'_v559 = v565 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v645 : Ref<Str> = v376 |> unbox<Ref<Str>>
            let _run_target_args'_v559 = v645 
            #endif
#if FABLE_COMPILER_PYTHON
            let v736 : Ref<Str> = v376 |> unbox<Ref<Str>>
            let _run_target_args'_v559 = v736 
            #endif
#else
            let v827 : Ref<Str> = v376 |> unbox<Ref<Str>>
            let _run_target_args'_v559 = v827 
            #endif
            let v839 : Ref<Str> = _run_target_args'_v559 
            let v1022 : string = $"$0.chars()"
            let v1023 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v839 v1022 
            let v1024 : string = "$0"
            let v1025 : _ = Fable.Core.RustInterop.emitRustExpr v1023 v1024 
            let v1026 : string = "$0.collect::<Vec<_>>()"
            let v1027 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1025 v1026 
            let v1028 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1029 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1027 v1028 
            let v1030 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1031 : bool = Fable.Core.RustInterop.emitRustExpr v1029 v1030 
            let v1032 : string = "x"
            let v1033 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1032 
            let v1034 : string = "String::from_iter($0)"
            let v1035 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1033 v1034 
            let v1036 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1037 : bool = Fable.Core.RustInterop.emitRustExpr v1035 v1036 
            let v1038 : string = "_vec_map"
            let v1039 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1038 
            let v1040 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1041 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1039 v1040 
            let v1042 : int32 = v1041.Length
            let v1047 : string = ""
            let v1048 : bool = v337 <> v1047 
            let v1061 : bool =
                if v1048 then
                    let v1060 : bool = v1042 <= 1
                    v1060
                else
                    false
            if v1061 then
                v279.l0 <- v376
                ()
            else
                v279.l0 <- v1047
                let v1062 : Mut5 = {l0 = 0} : Mut5
                while method36(v1042, v1062) do
                    let v1064 : int32 = v1062.l0
                    let v1065 : std_string_String = v1041.[int v1064]
                    let v1066 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1067 : bool = Fable.Core.RustInterop.emitRustExpr v1065 v1066 
                    let v1068 : int32 = v1064 + 1
                    v1062.l0 <- v1068
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v338 v337
            #endif
#if FABLE_COMPILER_PYTHON
            v338 v337
            #endif
#else
            v338 v337
            #endif
            // run_target_args' is_unit
            let v1069 : (string -> unit) = v277.l0
            v1069 v337
            US12_0(v276, v277, v278, v279, v280, v281)
    let v1112 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1112 
    ()
and closure42 (v0 : uint8, v1 : std_string_String) () : unit =
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure14()
    let v64 : unit = (fun () -> v63 (); v62) ()
    let struct (v113 : Mut0, v114 : Mut1, v115 : Mut2, v116 : Mut3, v117 : Mut4, v118 : int64 option) = TraceState.trace_state.Value
    let v160 : US5 = v117.l0
    let v161 : bool = v115.l0
    let v162 : bool = v161 = false
    let v165 : bool =
        if v162 then
            false
        else
            let v163 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v160
            let v164 : bool = 3 >= v163
            v164
    let v166 : bool = v165 = false
    let v1235 : US12 =
        if v166 then
            US12_1
        else
            let v228 : unit = ()
            let v229 : unit = (fun () -> v63 (); v228) ()
            let struct (v278 : Mut0, v279 : Mut1, v280 : Mut2, v281 : Mut3, v282 : Mut4, v283 : int64 option) = TraceState.trace_state.Value
            let v325 : string = method18(v278, v279, v280, v281, v282, v283)
            let v326 : string = method94()
            let v327 : string = method95(v278, v279, v280, v281, v282, v283, v325, v326, v0, v1)
            let v388 : unit = ()
            let v389 : unit = (fun () -> v63 (); v388) ()
            let struct (v438 : Mut0, v439 : Mut1, v440 : Mut2, v441 : Mut3, v442 : Mut4, v443 : int64 option) = TraceState.trace_state.Value
            let v489 : unit = ()
            let v490 : (unit -> unit) = closure16(v438)
            let v491 : unit = (fun () -> v490 (); v489) ()
            let v499 : (string -> unit) = closure17()
            (* run_target_args'
            let v500 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v501 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v502 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v502 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v503 : string = v441.l0
            let v504 : bool = v503 = ""
            let v540 : string =
                if v504 then
                    v327
                else
                    let v505 : bool = v327 = ""
                    if v505 then
                        let v506 : string = v441.l0
                        v506
                    else
                        let v507 : string = v441.l0
                        let v512 : string = "\n"
                        let v513 : string = v507 + v512 
                        let v527 : string = v513 + v327 
                        v527
            (* run_target_args'
            let v723 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v724 : string = "&*$0"
            let v725 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v724 
            let _run_target_args'_v723 = v725 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v726 : string = "&*$0"
            let v727 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v726 
            let _run_target_args'_v723 = v727 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v728 : string = "&*$0"
            let v729 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v728 
            let _run_target_args'_v723 = v729 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v809 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v809 
            #endif
#if FABLE_COMPILER_PYTHON
            let v900 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v900 
            #endif
#else
            let v991 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v991 
            #endif
            let v1003 : Ref<Str> = _run_target_args'_v723 
            let v1186 : string = $"$0.chars()"
            let v1187 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1003 v1186 
            let v1188 : string = "$0"
            let v1189 : _ = Fable.Core.RustInterop.emitRustExpr v1187 v1188 
            let v1190 : string = "$0.collect::<Vec<_>>()"
            let v1191 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1189 v1190 
            let v1192 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1193 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1191 v1192 
            let v1194 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1195 : bool = Fable.Core.RustInterop.emitRustExpr v1193 v1194 
            let v1196 : string = "x"
            let v1197 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1196 
            let v1198 : string = "String::from_iter($0)"
            let v1199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1197 v1198 
            let v1200 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1201 : bool = Fable.Core.RustInterop.emitRustExpr v1199 v1200 
            let v1202 : string = "_vec_map"
            let v1203 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1202 
            let v1204 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1205 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1203 v1204 
            let v1206 : int32 = v1205.Length
            let v1211 : string = ""
            let v1212 : bool = v327 <> v1211 
            let v1225 : bool =
                if v1212 then
                    let v1224 : bool = v1206 <= 1
                    v1224
                else
                    false
            if v1225 then
                v441.l0 <- v540
                ()
            else
                v441.l0 <- v1211
                let v1226 : Mut5 = {l0 = 0} : Mut5
                while method36(v1206, v1226) do
                    let v1228 : int32 = v1226.l0
                    let v1229 : std_string_String = v1205.[int v1228]
                    let v1230 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1231 : bool = Fable.Core.RustInterop.emitRustExpr v1229 v1230 
                    let v1232 : int32 = v1228 + 1
                    v1226.l0 <- v1232
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v499 v327
            #endif
#if FABLE_COMPILER_PYTHON
            v499 v327
            #endif
#else
            v499 v327
            #endif
            // run_target_args' is_unit
            let v1233 : (string -> unit) = v439.l0
            v1233 v327
            US12_0(v438, v439, v440, v441, v442, v443)
    let v1276 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1276 
    ()
and closure43 () () : unit =
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure14()
    let v62 : unit = (fun () -> v61 (); v60) ()
    let struct (v111 : Mut0, v112 : Mut1, v113 : Mut2, v114 : Mut3, v115 : Mut4, v116 : int64 option) = TraceState.trace_state.Value
    let v158 : US5 = v115.l0
    let v159 : bool = v113.l0
    let v160 : bool = v159 = false
    let v163 : bool =
        if v160 then
            false
        else
            let v161 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v158
            let v162 : bool = 3 >= v161
            v162
    let v164 : bool = v163 = false
    let v1071 : US12 =
        if v164 then
            US12_1
        else
            let v226 : unit = ()
            let v227 : unit = (fun () -> v61 (); v226) ()
            let struct (v276 : Mut0, v277 : Mut1, v278 : Mut2, v279 : Mut3, v280 : Mut4, v281 : int64 option) = TraceState.trace_state.Value
            let v327 : unit = ()
            let v328 : (unit -> unit) = closure16(v276)
            let v329 : unit = (fun () -> v328 (); v327) ()
            let v337 : string = "\n"
            let v338 : (string -> unit) = closure17()
            (* run_target_args'
            let v339 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v340 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v337 v340 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v341 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v337 v341 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v342 : string = v279.l0
            let v343 : bool = v342 = ""
            let v376 : string =
                if v343 then
                    v337
                else
                    let v344 : bool = v337 = ""
                    if v344 then
                        let v345 : string = v279.l0
                        v345
                    else
                        let v346 : string = v279.l0
                        let v349 : string = v346 + v337 
                        let v363 : string = v349 + v337 
                        v363
            (* run_target_args'
            let v559 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v560 : string = "&*$0"
            let v561 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v376 v560 
            let _run_target_args'_v559 = v561 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v562 : string = "&*$0"
            let v563 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v376 v562 
            let _run_target_args'_v559 = v563 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v564 : string = "&*$0"
            let v565 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v376 v564 
            let _run_target_args'_v559 = v565 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v645 : Ref<Str> = v376 |> unbox<Ref<Str>>
            let _run_target_args'_v559 = v645 
            #endif
#if FABLE_COMPILER_PYTHON
            let v736 : Ref<Str> = v376 |> unbox<Ref<Str>>
            let _run_target_args'_v559 = v736 
            #endif
#else
            let v827 : Ref<Str> = v376 |> unbox<Ref<Str>>
            let _run_target_args'_v559 = v827 
            #endif
            let v839 : Ref<Str> = _run_target_args'_v559 
            let v1022 : string = $"$0.chars()"
            let v1023 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v839 v1022 
            let v1024 : string = "$0"
            let v1025 : _ = Fable.Core.RustInterop.emitRustExpr v1023 v1024 
            let v1026 : string = "$0.collect::<Vec<_>>()"
            let v1027 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1025 v1026 
            let v1028 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1029 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1027 v1028 
            let v1030 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1031 : bool = Fable.Core.RustInterop.emitRustExpr v1029 v1030 
            let v1032 : string = "x"
            let v1033 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1032 
            let v1034 : string = "String::from_iter($0)"
            let v1035 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1033 v1034 
            let v1036 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1037 : bool = Fable.Core.RustInterop.emitRustExpr v1035 v1036 
            let v1038 : string = "_vec_map"
            let v1039 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1038 
            let v1040 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1041 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1039 v1040 
            let v1042 : int32 = v1041.Length
            let v1047 : string = ""
            let v1048 : bool = v337 <> v1047 
            let v1061 : bool =
                if v1048 then
                    let v1060 : bool = v1042 <= 1
                    v1060
                else
                    false
            if v1061 then
                v279.l0 <- v376
                ()
            else
                v279.l0 <- v1047
                let v1062 : Mut5 = {l0 = 0} : Mut5
                while method36(v1042, v1062) do
                    let v1064 : int32 = v1062.l0
                    let v1065 : std_string_String = v1041.[int v1064]
                    let v1066 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1067 : bool = Fable.Core.RustInterop.emitRustExpr v1065 v1066 
                    let v1068 : int32 = v1064 + 1
                    v1062.l0 <- v1068
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v338 v337
            #endif
#if FABLE_COMPILER_PYTHON
            v338 v337
            #endif
#else
            v338 v337
            #endif
            // run_target_args' is_unit
            let v1069 : (string -> unit) = v277.l0
            v1069 v337
            US12_0(v276, v277, v278, v279, v280, v281)
    let v1112 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1112 
    ()
and method98 () : string =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "inline_colorization::color_bright_red"
    let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3 
    (* run_target_args'
    let v187 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v188 : string = "String::from($0)"
    let v189 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v188 
    let _run_target_args'_v187 = v189 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v190 : string = "String::from($0)"
    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v190 
    let _run_target_args'_v187 = v191 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v192 : string = "String::from($0)"
    let v193 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v192 
    let _run_target_args'_v187 = v193 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v273 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v273 
    #endif
#if FABLE_COMPILER_PYTHON
    let v364 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v364 
    #endif
#else
    let v455 : std_string_String = v4 |> unbox<std_string_String>
    let _run_target_args'_v187 = v455 
    #endif
    let v467 : std_string_String = _run_target_args'_v187 
    let v650 : string = "fable_library_rust::String_::fromString($0)"
    let v651 : string = Fable.Core.RustInterop.emitRustExpr v467 v650 
    let _run_target_args'_v2 = v651 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v652 : string = "inline_colorization::color_bright_red"
    let v653 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v652 
    (* run_target_args'
    let v836 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v837 : string = "String::from($0)"
    let v838 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v837 
    let _run_target_args'_v836 = v838 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v839 : string = "String::from($0)"
    let v840 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v839 
    let _run_target_args'_v836 = v840 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v841 : string = "String::from($0)"
    let v842 : std_string_String = Fable.Core.RustInterop.emitRustExpr v653 v841 
    let _run_target_args'_v836 = v842 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v922 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v922 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1013 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v1013 
    #endif
#else
    let v1104 : std_string_String = v653 |> unbox<std_string_String>
    let _run_target_args'_v836 = v1104 
    #endif
    let v1116 : std_string_String = _run_target_args'_v836 
    let v1299 : string = "fable_library_rust::String_::fromString($0)"
    let v1300 : string = Fable.Core.RustInterop.emitRustExpr v1116 v1299 
    let _run_target_args'_v2 = v1300 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1301 : string = "inline_colorization::color_bright_red"
    let v1302 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1301 
    (* run_target_args'
    let v1485 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1486 : string = "String::from($0)"
    let v1487 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1486 
    let _run_target_args'_v1485 = v1487 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1488 : string = "String::from($0)"
    let v1489 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1488 
    let _run_target_args'_v1485 = v1489 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1490 : string = "String::from($0)"
    let v1491 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1302 v1490 
    let _run_target_args'_v1485 = v1491 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1571 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1571 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1662 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1662 
    #endif
#else
    let v1753 : std_string_String = v1302 |> unbox<std_string_String>
    let _run_target_args'_v1485 = v1753 
    #endif
    let v1765 : std_string_String = _run_target_args'_v1485 
    let v1948 : string = "fable_library_rust::String_::fromString($0)"
    let v1949 : string = Fable.Core.RustInterop.emitRustExpr v1765 v1948 
    let _run_target_args'_v2 = v1949 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1950 : string = "\u001b[91m"
    let _run_target_args'_v2 = v1950 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1951 : string = "\u001b[91m"
    let _run_target_args'_v2 = v1951 
    #endif
#else
    let v1952 : string = "\u001b[91m"
    let _run_target_args'_v2 = v1952 
    #endif
    let v1953 : string = _run_target_args'_v2 
    
    
    
    
    
    let v1960 : string = "Critical"
    let v1961 : (unit -> string) = v1960.ToLower
    let v1962 : string = v1961 ()
    let v1974 : char = v1962.[int 0]
    let v1975 : string = method23(v1974)
    let v1978 : string = v1953 + v1975 
    (* run_target_args'
    let v1992 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1993 : string = "inline_colorization::color_reset"
    let v1994 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1993 
    (* run_target_args'
    let v2177 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2178 : string = "String::from($0)"
    let v2179 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2178 
    let _run_target_args'_v2177 = v2179 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2180 : string = "String::from($0)"
    let v2181 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2180 
    let _run_target_args'_v2177 = v2181 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2182 : string = "String::from($0)"
    let v2183 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1994 v2182 
    let _run_target_args'_v2177 = v2183 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2263 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2263 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2354 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2354 
    #endif
#else
    let v2445 : std_string_String = v1994 |> unbox<std_string_String>
    let _run_target_args'_v2177 = v2445 
    #endif
    let v2457 : std_string_String = _run_target_args'_v2177 
    let v2640 : string = "fable_library_rust::String_::fromString($0)"
    let v2641 : string = Fable.Core.RustInterop.emitRustExpr v2457 v2640 
    let _run_target_args'_v1992 = v2641 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2642 : string = "inline_colorization::color_reset"
    let v2643 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2642 
    (* run_target_args'
    let v2826 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2827 : string = "String::from($0)"
    let v2828 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2827 
    let _run_target_args'_v2826 = v2828 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2829 : string = "String::from($0)"
    let v2830 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2829 
    let _run_target_args'_v2826 = v2830 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2831 : string = "String::from($0)"
    let v2832 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2643 v2831 
    let _run_target_args'_v2826 = v2832 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2912 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v2912 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3003 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v3003 
    #endif
#else
    let v3094 : std_string_String = v2643 |> unbox<std_string_String>
    let _run_target_args'_v2826 = v3094 
    #endif
    let v3106 : std_string_String = _run_target_args'_v2826 
    let v3289 : string = "fable_library_rust::String_::fromString($0)"
    let v3290 : string = Fable.Core.RustInterop.emitRustExpr v3106 v3289 
    let _run_target_args'_v1992 = v3290 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3291 : string = "inline_colorization::color_reset"
    let v3292 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3291 
    (* run_target_args'
    let v3475 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3476 : string = "String::from($0)"
    let v3477 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3476 
    let _run_target_args'_v3475 = v3477 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3478 : string = "String::from($0)"
    let v3479 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3478 
    let _run_target_args'_v3475 = v3479 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3480 : string = "String::from($0)"
    let v3481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3292 v3480 
    let _run_target_args'_v3475 = v3481 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3561 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3561 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3652 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3652 
    #endif
#else
    let v3743 : std_string_String = v3292 |> unbox<std_string_String>
    let _run_target_args'_v3475 = v3743 
    #endif
    let v3755 : std_string_String = _run_target_args'_v3475 
    let v3938 : string = "fable_library_rust::String_::fromString($0)"
    let v3939 : string = Fable.Core.RustInterop.emitRustExpr v3755 v3938 
    let _run_target_args'_v1992 = v3939 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3940 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3940 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3941 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3941 
    #endif
#else
    let v3942 : string = "\u001b[0m"
    let _run_target_args'_v1992 = v3942 
    #endif
    let v3943 : string = _run_target_args'_v1992 
    let v3948 : string = v1978 + v3943 
    v3948
and method100 (v0 : uint8, v1 : string) : string =
    let v2 : string = method12()
    let v13 : Mut3 = {l0 = v2} : Mut3
    method27(v13)
    method51(v13)
    method29(v13)
    let v417 : string = $"{v0}"
    method13(v13, v417)
    method52(v13)
    method97(v13)
    method29(v13)
    method13(v13, v1)
    method30(v13)
    let v1161 : string = v13.l0
    v1161
and method99 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : string) : string =
    let v10 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v28 : string = method25(v10)
    let v31 : string = v16 + v28 
    let v45 : string = v31 + v7 
    let v59 : string = v45 + v15 
    let v75 : string = "spiral_wasm.run / Ok (Some error)"
    let v76 : string = v59 + v75 
    let v92 : string = " / "
    let v93 : string = v76 + v92 
    let v105 : string = method100(v8, v9)
    let v108 : string = v93 + v105 
    method31(v108)
and closure44 (v0 : uint8, v1 : string) () : unit =
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure14()
    let v64 : unit = (fun () -> v63 (); v62) ()
    let struct (v113 : Mut0, v114 : Mut1, v115 : Mut2, v116 : Mut3, v117 : Mut4, v118 : int64 option) = TraceState.trace_state.Value
    let v160 : US5 = v117.l0
    let v161 : bool = v115.l0
    let v162 : bool = v161 = false
    let v165 : bool =
        if v162 then
            false
        else
            let v163 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v160
            let v164 : bool = 4 >= v163
            v164
    let v166 : bool = v165 = false
    let v1235 : US12 =
        if v166 then
            US12_1
        else
            let v228 : unit = ()
            let v229 : unit = (fun () -> v63 (); v228) ()
            let struct (v278 : Mut0, v279 : Mut1, v280 : Mut2, v281 : Mut3, v282 : Mut4, v283 : int64 option) = TraceState.trace_state.Value
            let v325 : string = method18(v278, v279, v280, v281, v282, v283)
            let v326 : string = method98()
            let v327 : string = method99(v278, v279, v280, v281, v282, v283, v325, v326, v0, v1)
            let v388 : unit = ()
            let v389 : unit = (fun () -> v63 (); v388) ()
            let struct (v438 : Mut0, v439 : Mut1, v440 : Mut2, v441 : Mut3, v442 : Mut4, v443 : int64 option) = TraceState.trace_state.Value
            let v489 : unit = ()
            let v490 : (unit -> unit) = closure16(v438)
            let v491 : unit = (fun () -> v490 (); v489) ()
            let v499 : (string -> unit) = closure17()
            (* run_target_args'
            let v500 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v501 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v502 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v327 v502 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v503 : string = v441.l0
            let v504 : bool = v503 = ""
            let v540 : string =
                if v504 then
                    v327
                else
                    let v505 : bool = v327 = ""
                    if v505 then
                        let v506 : string = v441.l0
                        v506
                    else
                        let v507 : string = v441.l0
                        let v512 : string = "\n"
                        let v513 : string = v507 + v512 
                        let v527 : string = v513 + v327 
                        v527
            (* run_target_args'
            let v723 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v724 : string = "&*$0"
            let v725 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v724 
            let _run_target_args'_v723 = v725 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v726 : string = "&*$0"
            let v727 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v726 
            let _run_target_args'_v723 = v727 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v728 : string = "&*$0"
            let v729 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v540 v728 
            let _run_target_args'_v723 = v729 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v809 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v809 
            #endif
#if FABLE_COMPILER_PYTHON
            let v900 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v900 
            #endif
#else
            let v991 : Ref<Str> = v540 |> unbox<Ref<Str>>
            let _run_target_args'_v723 = v991 
            #endif
            let v1003 : Ref<Str> = _run_target_args'_v723 
            let v1186 : string = $"$0.chars()"
            let v1187 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1003 v1186 
            let v1188 : string = "$0"
            let v1189 : _ = Fable.Core.RustInterop.emitRustExpr v1187 v1188 
            let v1190 : string = "$0.collect::<Vec<_>>()"
            let v1191 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1189 v1190 
            let v1192 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1193 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1191 v1192 
            let v1194 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1195 : bool = Fable.Core.RustInterop.emitRustExpr v1193 v1194 
            let v1196 : string = "x"
            let v1197 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1196 
            let v1198 : string = "String::from_iter($0)"
            let v1199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1197 v1198 
            let v1200 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1201 : bool = Fable.Core.RustInterop.emitRustExpr v1199 v1200 
            let v1202 : string = "_vec_map"
            let v1203 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1202 
            let v1204 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1205 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1203 v1204 
            let v1206 : int32 = v1205.Length
            let v1211 : string = ""
            let v1212 : bool = v327 <> v1211 
            let v1225 : bool =
                if v1212 then
                    let v1224 : bool = v1206 <= 1
                    v1224
                else
                    false
            if v1225 then
                v441.l0 <- v540
                ()
            else
                v441.l0 <- v1211
                let v1226 : Mut5 = {l0 = 0} : Mut5
                while method36(v1206, v1226) do
                    let v1228 : int32 = v1226.l0
                    let v1229 : std_string_String = v1205.[int v1228]
                    let v1230 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1231 : bool = Fable.Core.RustInterop.emitRustExpr v1229 v1230 
                    let v1232 : int32 = v1228 + 1
                    v1226.l0 <- v1232
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v499 v327
            #endif
#if FABLE_COMPILER_PYTHON
            v499 v327
            #endif
#else
            v499 v327
            #endif
            // run_target_args' is_unit
            let v1233 : (string -> unit) = v439.l0
            v1233 v327
            US12_0(v438, v439, v440, v441, v442, v443)
    let v1276 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1276 
    ()
and method47 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<US14>>>> =
    let v2 : string = "true; let __future_init = Box::pin(/*"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let v4 : string = "*/ async move { /*"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let v6 : string = "*/ ()"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let v8 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US10, anyhow_Error>>>>> = method48(v0, v1)
    let v9 : string = "v8.await"
    let v10 : Result<US10, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr () v9 
    let v11 : (anyhow_Error -> std_string_String) = method91()
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
#if FABLE_COMPILER_PYTHON
    let v22 : Result<US10, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v14 = v22 
    #endif
#else
    let v23 : Result<US10, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v14 = v23 
    #endif
    let v24 : Result<US10, std_string_String> = _run_target_args'_v14 
    let v27 : (US10 -> US17) = method92()
    let v28 : (std_string_String -> US17) = method93()
    let v31 : US17 = match v24 with Ok x -> v27 x | Error x -> v28 x
    let v18460 : US14 =
        match v31 with
        | US17_1(v3964) -> (* Error *)
            let v3965 : bool = v1 >= 15uy
            if v3965 then
                let v6531 : unit = ()
                let v6532 : (unit -> unit) = closure40(v1, v3964)
                let v6533 : unit = (fun () -> v6532 (); v6531) ()
                let v10065 : unit = ()
                let v10066 : (unit -> unit) = closure41()
                let v10067 : unit = (fun () -> v10066 (); v10065) ()
                let v11195 : string = "true; let __future_init = Box::pin(/*"
                let v11196 : bool = Fable.Core.RustInterop.emitRustExpr () v11195 
                let v11197 : string = "*/ async move { /*"
                let v11198 : bool = Fable.Core.RustInterop.emitRustExpr () v11197 
                let v11199 : string = "*/ ()"
                let v11200 : bool = Fable.Core.RustInterop.emitRustExpr () v11199 
                let v11201 : string = ""
                let v11202 : string = "}"
                let v11203 : string = v11201 + v11202 
                let v11204 : US10 = US10_1
                let x = struct (v1, v11204) //
                let v11205 : _ = x
                let v11206 : unit = ()
                (* run_target_args'
                let v11207 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v11208 : string = $"true; let _fix_closure_v11206 = $0"
                let v11209 : bool = Fable.Core.RustInterop.emitRustExpr v11205 v11208 
                let _run_target_args'_v11207 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v11210 : string = $"true; let _fix_closure_v11206 = $0"
                let v11211 : bool = Fable.Core.RustInterop.emitRustExpr v11205 v11210 
                let _run_target_args'_v11207 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v11212 : string = $"true; let _fix_closure_v11206 = $0"
                let v11213 : bool = Fable.Core.RustInterop.emitRustExpr v11205 v11212 
                let _run_target_args'_v11207 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v11207 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v11207 = false 
                #endif
#else
                let _run_target_args'_v11207 = false 
                #endif
                let v11214 : bool = _run_target_args'_v11207 
                let v11215 : string = $"true; _fix_closure_v11206 " + v11203 + "); " + v11201 + " // rust.fix_closure'"
                let v11216 : bool = Fable.Core.RustInterop.emitRustExpr () v11215 
                let v11217 : string = "__future_init"
                let v11218 : _ = Fable.Core.RustInterop.emitRustExpr () v11217 
                let v11219 : string = "v11218"
                let v11220 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US10)>>>> = Fable.Core.RustInterop.emitRustExpr () v11219 
                let v11221 : string = "v11220.await"
                let struct (v11222 : uint8, v11223 : US10) = Fable.Core.RustInterop.emitRustExpr () v11221 
                US14_0(v11222, v11223)
            else
                let v13790 : unit = ()
                let v13791 : (unit -> unit) = closure42(v1, v3964)
                let v13792 : unit = (fun () -> v13791 (); v13790) ()
                let v17324 : unit = ()
                let v17325 : (unit -> unit) = closure43()
                let v17326 : unit = (fun () -> v17325 (); v17324) ()
                let v18454 : uint8 = v1 + 1uy
                let v18455 : std_pin_Pin<Box<Dyn<std_future_Future<US14>>>> = method47(v0, v18454)
                let v18456 : string = "v18455.await"
                let v18457 : US14 = Fable.Core.RustInterop.emitRustExpr () v18456 
                v18457
        | US17_0(v43) -> (* Ok *)
            match v43 with
            | US10_1 -> (* None *)
                let v44 : string = "true; let __future_init = Box::pin(/*"
                let v45 : bool = Fable.Core.RustInterop.emitRustExpr () v44 
                let v46 : string = "*/ async move { /*"
                let v47 : bool = Fable.Core.RustInterop.emitRustExpr () v46 
                let v48 : string = "*/ ()"
                let v49 : bool = Fable.Core.RustInterop.emitRustExpr () v48 
                let v50 : string = ""
                let v51 : string = "}"
                let v52 : string = v50 + v51 
                let v53 : US10 = US10_1
                let x = struct (v1, v53) //
                let v54 : _ = x
                let v55 : unit = ()
                (* run_target_args'
                let v56 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v57 : string = $"true; let _fix_closure_v55 = $0"
                let v58 : bool = Fable.Core.RustInterop.emitRustExpr v54 v57 
                let _run_target_args'_v56 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v59 : string = $"true; let _fix_closure_v55 = $0"
                let v60 : bool = Fable.Core.RustInterop.emitRustExpr v54 v59 
                let _run_target_args'_v56 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v61 : string = $"true; let _fix_closure_v55 = $0"
                let v62 : bool = Fable.Core.RustInterop.emitRustExpr v54 v61 
                let _run_target_args'_v56 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v56 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v56 = false 
                #endif
#else
                let _run_target_args'_v56 = false 
                #endif
                let v63 : bool = _run_target_args'_v56 
                let v64 : string = $"true; _fix_closure_v55 " + v52 + "); " + v50 + " // rust.fix_closure'"
                let v65 : bool = Fable.Core.RustInterop.emitRustExpr () v64 
                let v66 : string = "__future_init"
                let v67 : _ = Fable.Core.RustInterop.emitRustExpr () v66 
                let v68 : string = "v67"
                let v69 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US10)>>>> = Fable.Core.RustInterop.emitRustExpr () v68 
                let v70 : string = "v69.await"
                let struct (v71 : uint8, v72 : US10) = Fable.Core.RustInterop.emitRustExpr () v70 
                US14_0(v71, v72)
            | US10_0(v74) -> (* Some *)
                let v2640 : unit = ()
                let v2641 : (unit -> unit) = closure44(v1, v74)
                let v2642 : unit = (fun () -> v2641 (); v2640) ()
                let v3932 : string = "true; let __future_init = Box::pin(/*"
                let v3933 : bool = Fable.Core.RustInterop.emitRustExpr () v3932 
                let v3934 : string = "*/ async move { /*"
                let v3935 : bool = Fable.Core.RustInterop.emitRustExpr () v3934 
                let v3936 : string = "*/ ()"
                let v3937 : bool = Fable.Core.RustInterop.emitRustExpr () v3936 
                let v3938 : string = ""
                let v3939 : string = "}"
                let v3940 : string = v3938 + v3939 
                let v3941 : US10 = US10_0(v74)
                let x = struct (v1, v3941) //
                let v3942 : _ = x
                let v3943 : unit = ()
                (* run_target_args'
                let v3944 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3945 : string = $"true; let _fix_closure_v3943 = $0"
                let v3946 : bool = Fable.Core.RustInterop.emitRustExpr v3942 v3945 
                let _run_target_args'_v3944 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3947 : string = $"true; let _fix_closure_v3943 = $0"
                let v3948 : bool = Fable.Core.RustInterop.emitRustExpr v3942 v3947 
                let _run_target_args'_v3944 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3949 : string = $"true; let _fix_closure_v3943 = $0"
                let v3950 : bool = Fable.Core.RustInterop.emitRustExpr v3942 v3949 
                let _run_target_args'_v3944 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v3944 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v3944 = false 
                #endif
#else
                let _run_target_args'_v3944 = false 
                #endif
                let v3951 : bool = _run_target_args'_v3944 
                let v3952 : string = $"true; _fix_closure_v3943 " + v3940 + "); " + v3938 + " // rust.fix_closure'"
                let v3953 : bool = Fable.Core.RustInterop.emitRustExpr () v3952 
                let v3954 : string = "__future_init"
                let v3955 : _ = Fable.Core.RustInterop.emitRustExpr () v3954 
                let v3956 : string = "v3955"
                let v3957 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US10)>>>> = Fable.Core.RustInterop.emitRustExpr () v3956 
                let v3958 : string = "v3957.await"
                let struct (v3959 : uint8, v3960 : US10) = Fable.Core.RustInterop.emitRustExpr () v3958 
                US14_1(v3959, v3960)
    let v18461 : string = ""
    let v18462 : string = "}"
    let v18463 : string = v18461 + v18462 
    let x = v18460 //
    let v18464 : _ = x
    let v18465 : unit = ()
    (* run_target_args'
    let v18466 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v18467 : string = $"true; let _fix_closure_v18465 = $0"
    let v18468 : bool = Fable.Core.RustInterop.emitRustExpr v18464 v18467 
    let _run_target_args'_v18466 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v18469 : string = $"true; let _fix_closure_v18465 = $0"
    let v18470 : bool = Fable.Core.RustInterop.emitRustExpr v18464 v18469 
    let _run_target_args'_v18466 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v18471 : string = $"true; let _fix_closure_v18465 = $0"
    let v18472 : bool = Fable.Core.RustInterop.emitRustExpr v18464 v18471 
    let _run_target_args'_v18466 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v18466 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v18466 = false 
    #endif
#else
    let _run_target_args'_v18466 = false 
    #endif
    let v18473 : bool = _run_target_args'_v18466 
    let v18474 : string = $"true; _fix_closure_v18465 " + v18463 + "); " + v18461 + " // rust.fix_closure'"
    let v18475 : bool = Fable.Core.RustInterop.emitRustExpr () v18474 
    let v18476 : string = "__future_init"
    let v18477 : _ = Fable.Core.RustInterop.emitRustExpr () v18476 
    let v18478 : string = "v18477"
    let v18479 : std_pin_Pin<Box<Dyn<std_future_Future<US14>>>> = Fable.Core.RustInterop.emitRustExpr () v18478 
    v18479
and method103 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v6 : string = "retries"
    let v7 : string = v1 + v6 
    v0.l0 <- v7
    ()
and method102 (v0 : US14) : string =
    let v1 : string = method12()
    let v12 : Mut3 = {l0 = v1} : Mut3
    method27(v12)
    method103(v12)
    method29(v12)
    let v390 : string = $"%A{v0}"
    method13(v12, v390)
    method30(v12)
    let v648 : string = v12.l0
    v648
and method101 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : US14) : string =
    let v9 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v27 : string = method25(v9)
    let v30 : string = v15 + v27 
    let v44 : string = v30 + v7 
    let v58 : string = v44 + v14 
    let v74 : string = "spiral_wasm.run"
    let v75 : string = v58 + v74 
    let v91 : string = " / "
    let v92 : string = v75 + v91 
    let v104 : string = method102(v8)
    let v107 : string = v92 + v104 
    method31(v107)
and closure45 (v0 : US14) () : unit =
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure14()
    let v63 : unit = (fun () -> v62 (); v61) ()
    let struct (v112 : Mut0, v113 : Mut1, v114 : Mut2, v115 : Mut3, v116 : Mut4, v117 : int64 option) = TraceState.trace_state.Value
    let v159 : US5 = v116.l0
    let v160 : bool = v114.l0
    let v161 : bool = v160 = false
    let v164 : bool =
        if v161 then
            false
        else
            let v162 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v159
            let v163 : bool = 0 >= v162
            v163
    let v165 : bool = v164 = false
    let v1234 : US12 =
        if v165 then
            US12_1
        else
            let v227 : unit = ()
            let v228 : unit = (fun () -> v62 (); v227) ()
            let struct (v277 : Mut0, v278 : Mut1, v279 : Mut2, v280 : Mut3, v281 : Mut4, v282 : int64 option) = TraceState.trace_state.Value
            let v324 : string = method18(v277, v278, v279, v280, v281, v282)
            let v325 : string = method22()
            let v326 : string = method101(v277, v278, v279, v280, v281, v282, v324, v325, v0)
            let v387 : unit = ()
            let v388 : unit = (fun () -> v62 (); v387) ()
            let struct (v437 : Mut0, v438 : Mut1, v439 : Mut2, v440 : Mut3, v441 : Mut4, v442 : int64 option) = TraceState.trace_state.Value
            let v488 : unit = ()
            let v489 : (unit -> unit) = closure16(v437)
            let v490 : unit = (fun () -> v489 (); v488) ()
            let v498 : (string -> unit) = closure17()
            (* run_target_args'
            let v499 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v500 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v500 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v501 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v326 v501 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v502 : string = v440.l0
            let v503 : bool = v502 = ""
            let v539 : string =
                if v503 then
                    v326
                else
                    let v504 : bool = v326 = ""
                    if v504 then
                        let v505 : string = v440.l0
                        v505
                    else
                        let v506 : string = v440.l0
                        let v511 : string = "\n"
                        let v512 : string = v506 + v511 
                        let v526 : string = v512 + v326 
                        v526
            (* run_target_args'
            let v722 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v723 : string = "&*$0"
            let v724 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v723 
            let _run_target_args'_v722 = v724 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v725 : string = "&*$0"
            let v726 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v725 
            let _run_target_args'_v722 = v726 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v727 : string = "&*$0"
            let v728 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v539 v727 
            let _run_target_args'_v722 = v728 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v808 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v808 
            #endif
#if FABLE_COMPILER_PYTHON
            let v899 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v899 
            #endif
#else
            let v990 : Ref<Str> = v539 |> unbox<Ref<Str>>
            let _run_target_args'_v722 = v990 
            #endif
            let v1002 : Ref<Str> = _run_target_args'_v722 
            let v1185 : string = $"$0.chars()"
            let v1186 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v1002 v1185 
            let v1187 : string = "$0"
            let v1188 : _ = Fable.Core.RustInterop.emitRustExpr v1186 v1187 
            let v1189 : string = "$0.collect::<Vec<_>>()"
            let v1190 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v1188 v1189 
            let v1191 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v1192 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v1190 v1191 
            let v1193 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v1194 : bool = Fable.Core.RustInterop.emitRustExpr v1192 v1193 
            let v1195 : string = "x"
            let v1196 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v1195 
            let v1197 : string = "String::from_iter($0)"
            let v1198 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1196 v1197 
            let v1199 : string = "true; $0 }).collect::<Vec<_>>()"
            let v1200 : bool = Fable.Core.RustInterop.emitRustExpr v1198 v1199 
            let v1201 : string = "_vec_map"
            let v1202 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1201 
            let v1203 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
            let v1204 : (std_string_String []) = Fable.Core.RustInterop.emitRustExpr v1202 v1203 
            let v1205 : int32 = v1204.Length
            let v1210 : string = ""
            let v1211 : bool = v326 <> v1210 
            let v1224 : bool =
                if v1211 then
                    let v1223 : bool = v1205 <= 1
                    v1223
                else
                    false
            if v1224 then
                v440.l0 <- v539
                ()
            else
                v440.l0 <- v1210
                let v1225 : Mut5 = {l0 = 0} : Mut5
                while method36(v1205, v1225) do
                    let v1227 : int32 = v1225.l0
                    let v1228 : std_string_String = v1204.[int v1227]
                    let v1229 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                    let v1230 : bool = Fable.Core.RustInterop.emitRustExpr v1228 v1229 
                    let v1231 : int32 = v1227 + 1
                    v1225.l0 <- v1231
                    ()
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v498 v326
            #endif
#if FABLE_COMPILER_PYTHON
            v498 v326
            #endif
#else
            v498 v326
            #endif
            // run_target_args' is_unit
            let v1232 : (string -> unit) = v438.l0
            v1232 v326
            US12_0(v437, v438, v439, v440, v441, v442)
    let v1275 : string = "Fsharp"
    () // base.backend_switch / record_type_try_find / key: v1275 
    ()
and method104 (v0 : US14, v1 : US10) : string =
    let v2 : string = method12()
    let v13 : Mut3 = {l0 = v2} : Mut3
    method27(v13)
    method103(v13)
    method29(v13)
    let v391 : string = $"%A{v0}"
    method13(v13, v391)
    method52(v13)
    method97(v13)
    method29(v13)
    let v901 : string = $"%A{v1}"
    method13(v13, v901)
    method30(v13)
    let v1159 : string = v13.l0
    v1159
and method42 (v0 : clap_ArgMatches) : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> =
    let v1 : string = "true; let __future_init = Box::pin(/*"
    let v2 : bool = Fable.Core.RustInterop.emitRustExpr () v1 
    let v3 : string = "*/ async move { /*"
    let v4 : bool = Fable.Core.RustInterop.emitRustExpr () v3 
    let v5 : string = "*/ ()"
    let v6 : bool = Fable.Core.RustInterop.emitRustExpr () v5 
    let v7 : string = method43()
    (* run_target_args'
    let v190 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v191 : string = "&*$0"
    let v192 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v191 
    let _run_target_args'_v190 = v192 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v193 : string = "&*$0"
    let v194 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v193 
    let _run_target_args'_v190 = v194 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v195 : string = "&*$0"
    let v196 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v195 
    let _run_target_args'_v190 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v276 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v190 = v276 
    #endif
#if FABLE_COMPILER_PYTHON
    let v367 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v190 = v367 
    #endif
#else
    let v458 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v190 = v458 
    #endif
    let v470 : Ref<Str> = _run_target_args'_v190 
    let v653 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v654 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v0, v470) v653 
    let v717 : (std_string_String -> US2) = method4()
    let v718 : US2 option = v654 |> Option.map v717 
    let v779 : US2 = US2_1
    let v780 : US2 = v718 |> Option.defaultValue v779 
    let v796 : std_string_String =
        match v780 with
        | US2_1 -> (* None *)
            failwith<std_string_String> "Option does not have a value."
        | US2_0(v793) -> (* Some *)
            v793
    let v797 : string = "fable_library_rust::String_::fromString($0)"
    let v798 : string = Fable.Core.RustInterop.emitRustExpr v796 v797 
    let v3364 : unit = ()
    let v3365 : (unit -> unit) = closure20(v798)
    let v3366 : unit = (fun () -> v3365 (); v3364) ()
    let v4656 : string = "std::fs::read(&*$0)"
    let v4657 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v798 v4656 
    let v4658 : string = "$0?"
    let v4659 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v4657 v4658 
    let v4660 : uint8 = 1uy
    let v4661 : std_pin_Pin<Box<Dyn<std_future_Future<US14>>>> = method47(v4659, v4660)
    let v4662 : string = "v4661.await"
    let v4663 : US14 = Fable.Core.RustInterop.emitRustExpr () v4662 
    let v7229 : unit = ()
    let v7230 : (unit -> unit) = closure45(v4663)
    let v7231 : unit = (fun () -> v7230 (); v7229) ()
    let v8558 : Result<uint8, anyhow_Error> =
        match v4663 with
        | US14_1(v8537, v8538) -> (* Error *)
            let v8539 : string = method104(v4663, v8538)
            let v8540 : string = "anyhow::anyhow!($0)"
            let v8541 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v8539 v8540 
            (* run_target_args'
            let v8544 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v8545 : string = "Err($0)"
            let v8546 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v8541 v8545 
            let _run_target_args'_v8544 = v8546 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v8547 : string = "Err($0)"
            let v8548 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v8541 v8547 
            let _run_target_args'_v8544 = v8548 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v8549 : string = "Err($0)"
            let v8550 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v8541 v8549 
            let _run_target_args'_v8544 = v8550 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v8551 : Result<uint8, anyhow_Error> = v8541 |> Error
            let _run_target_args'_v8544 = v8551 
            #endif
#if FABLE_COMPILER_PYTHON
            let v8552 : Result<uint8, anyhow_Error> = v8541 |> Error
            let _run_target_args'_v8544 = v8552 
            #endif
#else
            let v8553 : Result<uint8, anyhow_Error> = v8541 |> Error
            let _run_target_args'_v8544 = v8553 
            #endif
            let v8554 : Result<uint8, anyhow_Error> = _run_target_args'_v8544 
            v8554
        | US14_0(v8521, v8522) -> (* Ok *)
            let v8525 : Result<uint8, anyhow_Error> = Ok v8521 
            v8525
    let v8559 : string = ""
    let v8560 : string = "}"
    let v8561 : string = v8559 + v8560 
    let x = v8558 //
    let v8562 : _ = x
    let v8563 : unit = ()
    (* run_target_args'
    let v8564 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8565 : string = $"true; let _fix_closure_v8563 = $0"
    let v8566 : bool = Fable.Core.RustInterop.emitRustExpr v8562 v8565 
    let _run_target_args'_v8564 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8567 : string = $"true; let _fix_closure_v8563 = $0"
    let v8568 : bool = Fable.Core.RustInterop.emitRustExpr v8562 v8567 
    let _run_target_args'_v8564 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8569 : string = $"true; let _fix_closure_v8563 = $0"
    let v8570 : bool = Fable.Core.RustInterop.emitRustExpr v8562 v8569 
    let _run_target_args'_v8564 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v8564 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v8564 = false 
    #endif
#else
    let _run_target_args'_v8564 = false 
    #endif
    let v8571 : bool = _run_target_args'_v8564 
    let v8572 : string = $"true; _fix_closure_v8563 " + v8561 + "); " + v8559 + " // rust.fix_closure'"
    let v8573 : bool = Fable.Core.RustInterop.emitRustExpr () v8572 
    let v8574 : string = "__future_init"
    let v8575 : _ = Fable.Core.RustInterop.emitRustExpr () v8574 
    let v8576 : string = "v8575"
    let v8577 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v8576 
    v8577
and closure46 () (v0 : uint8) : US18 =
    US18_0(v0)
and method105 () : (uint8 -> US18) =
    closure46()
and closure47 () (v0 : std_string_String) : US18 =
    US18_1(v0)
and method106 () : (std_string_String -> US18) =
    closure47()
and closure0 () (v0 : (string [])) : int32 =
    let v1 : clap_Command = method0()
    let v2 : string = "clap::Command::get_matches($0)"
    let v3 : clap_ArgMatches = Fable.Core.RustInterop.emitRustExpr v1 v2 
    let v4 : string = method3()
    (* run_target_args'
    let v187 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v188 : string = "&*$0"
    let v189 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v188 
    let _run_target_args'_v187 = v189 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v190 : string = "&*$0"
    let v191 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v190 
    let _run_target_args'_v187 = v191 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v192 : string = "&*$0"
    let v193 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v192 
    let _run_target_args'_v187 = v193 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v273 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v187 = v273 
    #endif
#if FABLE_COMPILER_PYTHON
    let v364 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v187 = v364 
    #endif
#else
    let v455 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v187 = v455 
    #endif
    let v467 : Ref<Str> = _run_target_args'_v187 
    let v650 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v651 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v467) v650 
    let v714 : (std_string_String -> US2) = method4()
    let v715 : US2 option = v651 |> Option.map v714 
    let v776 : US2 = US2_1
    let v777 : US2 = v715 |> Option.defaultValue v776 
    let v977 : US3 =
        match v777 with
        | US2_1 -> (* None *)
            US3_1
        | US2_0(v790) -> (* Some *)
            let v791 : string = "fable_library_rust::String_::fromString($0)"
            let v792 : string = Fable.Core.RustInterop.emitRustExpr v790 v791 
            
            
            
            
            
            
            
            
            
            
            let v797 : string = "Critical"
            let v798 : (unit -> string) = v797.ToLower
            let v799 : string = v798 ()
            let v815 : string = "Warning"
            let v816 : (unit -> string) = v815.ToLower
            let v817 : string = v816 ()
            let v833 : string = "Info"
            let v834 : (unit -> string) = v833.ToLower
            let v835 : string = v834 ()
            let v851 : string = "Debug"
            let v852 : (unit -> string) = v851.ToLower
            let v853 : string = v852 ()
            let v869 : string = "Verbose"
            let v870 : (unit -> string) = v869.ToLower
            let v871 : string = v870 ()
            let v883 : bool = "Verbose" = v792
            let v887 : US4 =
                if v883 then
                    let v884 : US5 = US5_0
                    US4_0(v884)
                else
                    US4_1
            let v973 : US4 =
                match v887 with
                | US4_1 -> (* None *)
                    let v890 : bool = "Debug" = v792
                    let v894 : US4 =
                        if v890 then
                            let v891 : US5 = US5_1
                            US4_0(v891)
                        else
                            US4_1
                    match v894 with
                    | US4_1 -> (* None *)
                        let v897 : bool = "Info" = v792
                        let v901 : US4 =
                            if v897 then
                                let v898 : US5 = US5_2
                                US4_0(v898)
                            else
                                US4_1
                        match v901 with
                        | US4_1 -> (* None *)
                            let v904 : bool = "Warning" = v792
                            let v908 : US4 =
                                if v904 then
                                    let v905 : US5 = US5_3
                                    US4_0(v905)
                                else
                                    US4_1
                            match v908 with
                            | US4_1 -> (* None *)
                                let v911 : bool = "Critical" = v792
                                let v915 : US4 =
                                    if v911 then
                                        let v912 : US5 = US5_4
                                        US4_0(v912)
                                    else
                                        US4_1
                                match v915 with
                                | US4_1 -> (* None *)
                                    let v918 : bool = v871 = v792
                                    let v922 : US4 =
                                        if v918 then
                                            let v919 : US5 = US5_0
                                            US4_0(v919)
                                        else
                                            US4_1
                                    match v922 with
                                    | US4_1 -> (* None *)
                                        let v925 : bool = v853 = v792
                                        let v929 : US4 =
                                            if v925 then
                                                let v926 : US5 = US5_1
                                                US4_0(v926)
                                            else
                                                US4_1
                                        match v929 with
                                        | US4_1 -> (* None *)
                                            let v932 : bool = v835 = v792
                                            let v936 : US4 =
                                                if v932 then
                                                    let v933 : US5 = US5_2
                                                    US4_0(v933)
                                                else
                                                    US4_1
                                            match v936 with
                                            | US4_1 -> (* None *)
                                                let v939 : bool = v817 = v792
                                                let v943 : US4 =
                                                    if v939 then
                                                        let v940 : US5 = US5_3
                                                        US4_0(v940)
                                                    else
                                                        US4_1
                                                match v943 with
                                                | US4_1 -> (* None *)
                                                    let v946 : bool = v799 = v792
                                                    let v950 : US4 =
                                                        if v946 then
                                                            let v947 : US5 = US5_4
                                                            US4_0(v947)
                                                        else
                                                            US4_1
                                                    match v950 with
                                                    | US4_1 -> (* None *)
                                                        US4_1
                                                    | US4_0(v951) -> (* Some *)
                                                        US4_0(v951)
                                                | US4_0(v944) -> (* Some *)
                                                    US4_0(v944)
                                            | US4_0(v937) -> (* Some *)
                                                US4_0(v937)
                                        | US4_0(v930) -> (* Some *)
                                            US4_0(v930)
                                    | US4_0(v923) -> (* Some *)
                                        US4_0(v923)
                                | US4_0(v916) -> (* Some *)
                                    US4_0(v916)
                            | US4_0(v909) -> (* Some *)
                                US4_0(v909)
                        | US4_0(v902) -> (* Some *)
                            US4_0(v902)
                    | US4_0(v895) -> (* Some *)
                        US4_0(v895)
                | US4_0(v888) -> (* Some *)
                    US4_0(v888)
            US3_0(v973)
    let v984 : US4 =
        match v977 with
        | US3_0(v978) -> (* Some *)
            match v978 with
            | US4_0(v979) -> (* Some *)
                US4_0(v979)
            | _ ->
                US4_1
        | _ ->
            US4_1
    let v988 : US5 =
        match v984 with
        | US4_1 -> (* None *)
            US5_0
        | US4_0(v985) -> (* Some *)
            v985
    let v1045 : unit = ()
    let v1046 : (unit -> unit) = closure7(v988)
    let v1047 : unit = (fun () -> v1046 (); v1045) ()
    let struct (v1093 : Mut0, v1094 : Mut1, v1095 : Mut2, v1096 : Mut3, v1097 : Mut4, v1098 : int64 option) = TraceState.trace_state.Value
    let v3705 : unit = ()
    let v3706 : (unit -> unit) = closure13(v0)
    let v3707 : unit = (fun () -> v3706 (); v3705) ()
    let v4997 : string = method37()
    (* run_target_args'
    let v5180 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5181 : string = "&*$0"
    let v5182 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4997 v5181 
    let _run_target_args'_v5180 = v5182 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5183 : string = "&*$0"
    let v5184 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4997 v5183 
    let _run_target_args'_v5180 = v5184 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5185 : string = "&*$0"
    let v5186 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4997 v5185 
    let _run_target_args'_v5180 = v5186 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5266 : Ref<Str> = v4997 |> unbox<Ref<Str>>
    let _run_target_args'_v5180 = v5266 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5357 : Ref<Str> = v4997 |> unbox<Ref<Str>>
    let _run_target_args'_v5180 = v5357 
    #endif
#else
    let v5448 : Ref<Str> = v4997 |> unbox<Ref<Str>>
    let _run_target_args'_v5180 = v5448 
    #endif
    let v5460 : Ref<Str> = _run_target_args'_v5180 
    let v5643 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v5644 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v5460) v5643 
    let v7161 : (std_string_String -> string) = method38()
    let v7162 : string option = v5644 |> Option.map v7161 
    let v8737 : (string -> US10) = method16()
    let v8738 : US10 option = v7162 |> Option.map v8737 
    let v8799 : US10 = US10_1
    let v8800 : US10 = v8738 |> Option.defaultValue v8799 
    let v8813 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method42(v3)
    let v8814 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v8815 : _ = Fable.Core.RustInterop.emitRustExpr () v8814 
    let v8816 : string = "v8815.handle().block_on($0)"
    let v8817 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v8813 v8816 
    let v8818 : (anyhow_Error -> std_string_String) = method91()
    (* run_target_args'
    let v8821 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8822 : string = "$0.map_err(|x| $1(x))"
    let v8823 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v8817, v8818) v8822 
    let _run_target_args'_v8821 = v8823 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8824 : string = "$0.map_err(|x| $1(x))"
    let v8825 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v8817, v8818) v8824 
    let _run_target_args'_v8821 = v8825 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8826 : string = "$0.map_err(|x| $1(x))"
    let v8827 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v8817, v8818) v8826 
    let _run_target_args'_v8821 = v8827 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v8828 : Result<uint8, std_string_String> = match v8817 with Ok x -> Ok x | Error x -> Error (v8818 x)
    let _run_target_args'_v8821 = v8828 
    #endif
#if FABLE_COMPILER_PYTHON
    let v8829 : Result<uint8, std_string_String> = match v8817 with Ok x -> Ok x | Error x -> Error (v8818 x)
    let _run_target_args'_v8821 = v8829 
    #endif
#else
    let v8830 : Result<uint8, std_string_String> = match v8817 with Ok x -> Ok x | Error x -> Error (v8818 x)
    let _run_target_args'_v8821 = v8830 
    #endif
    let v8831 : Result<uint8, std_string_String> = _run_target_args'_v8821 
    let v8834 : (uint8 -> US18) = method105()
    let v8835 : (std_string_String -> US18) = method106()
    let v8838 : US18 = match v8831 with Ok x -> v8834 x | Error x -> v8835 x
    match v8838 with
    | US18_1(v8869) -> (* Error *)
        match v8800 with
        | US10_0(v8870) -> (* Some *)
            let v8871 : bool = "" = v8870
            if v8871 then
                ()
            else
                let v8872 : string = "fable_library_rust::String_::fromString($0)"
                let v8873 : string = Fable.Core.RustInterop.emitRustExpr v8869 v8872 
                let v8876 : bool = v8873.Contains v8870 
                if v8876 then
                    ()
                else
                    let v8888 : string = $"spiral_wasm.main / exception: '{v8870}' / error: {v8869}"
                    (* run_target_args'
                    let v8891 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v8892 : string = "Err($0)"
                    let v8893 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v8888 v8892 
                    let _run_target_args'_v8891 = v8893 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v8894 : string = "Err($0)"
                    let v8895 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v8888 v8894 
                    let _run_target_args'_v8891 = v8895 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v8896 : string = "Err($0)"
                    let v8897 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v8888 v8896 
                    let _run_target_args'_v8891 = v8897 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v8898 : Result<unit, string> = v8888 |> Error
                    let _run_target_args'_v8891 = v8898 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v8899 : Result<unit, string> = v8888 |> Error
                    let _run_target_args'_v8891 = v8899 
                    #endif
#else
                    let v8900 : Result<unit, string> = v8888 |> Error
                    let _run_target_args'_v8891 = v8900 
                    #endif
                    let v8901 : Result<unit, string> = _run_target_args'_v8891 
                    let v8904 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v8901 v8904 
                    ()
        | _ ->
            let v8905 : string = "$0.unwrap()"
            let v8906 : uint8 = Fable.Core.RustInterop.emitRustExpr v8831 v8905 
            ()
    | US18_0(v8850) -> (* Ok *)
        match v8800 with
        | US10_0(v8851) -> (* Some *)
            let v8852 : string = $"spiral_wasm.main / retries: {v8850} / exception: '{v8851}'"
            (* run_target_args'
            let v8855 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v8856 : string = "Err($0)"
            let v8857 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v8852 v8856 
            let _run_target_args'_v8855 = v8857 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v8858 : string = "Err($0)"
            let v8859 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v8852 v8858 
            let _run_target_args'_v8855 = v8859 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v8860 : string = "Err($0)"
            let v8861 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v8852 v8860 
            let _run_target_args'_v8855 = v8861 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v8862 : Result<unit, string> = v8852 |> Error
            let _run_target_args'_v8855 = v8862 
            #endif
#if FABLE_COMPILER_PYTHON
            let v8863 : Result<unit, string> = v8852 |> Error
            let _run_target_args'_v8855 = v8863 
            #endif
#else
            let v8864 : Result<unit, string> = v8852 |> Error
            let _run_target_args'_v8855 = v8864 
            #endif
            let v8865 : Result<unit, string> = _run_target_args'_v8855 
            let v8868 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v8865 v8868 
            ()
        | _ ->
            ()
    0
let v0 : ((string []) -> int32) = closure0()
let main args = v0 args
()
