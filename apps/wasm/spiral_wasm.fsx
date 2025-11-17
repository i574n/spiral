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
    | US7_2
and [<Struct>] US8 =
    | US8_0 of f0_0 : US7
    | US8_1 of f1_0 : US7
    | US8_2 of f2_0 : US7
    | US8_3 of f3_0 : US7
    | US8_4 of f4_0 : US7
    | US8_5 of f5_0 : US7
    | US8_6 of f6_0 : US7
and [<Struct>] US9 =
    | US9_0 of f0_0 : string
    | US9_1
and [<Struct>] US10 =
    | US10_0 of f0_0 : int64
    | US10_1 of f1_0 : exn
and [<Struct>] US11 =
    | US11_0 of f0_0 : Mut0 * f0_1 : Mut1 * f0_2 : Mut2 * f0_3 : Mut3 * f0_4 : Mut4 * f0_5 : int64 option
    | US11_1
and [<Struct>] US12 =
    | US12_0 of f0_0 : char
    | US12_1
and [<Struct>] US13 =
    | US13_0 of f0_0 : int32
    | US13_1 of f1_0 : exn
and [<Struct>] US14 =
    | US14_0 of f0_0 : int32
    | US14_1
and [<Struct>] US15 =
    | US15_0 of f0_0 : uint8 * f0_1 : US9
    | US15_1 of f1_0 : uint8 * f1_1 : US9
and [<Struct>] US16 =
    | US16_0 of f0_0 : US9
    | US16_1 of f1_0 : std_string_String
and [<Struct>] US17 =
    | US17_0 of f0_0 : uint8
    | US17_1 of f1_0 : std_string_String
let rec closure1 () () : unativeint =
    let v0 : unativeint = 0 |> unativeint 
    v0
and closure2 () (v0 : unativeint) : US0 =
    US0_0(v0)
and closure3 () (v0 : (unit -> exn)) : exn =
    v0 ()
and closure4 () (v0 : exn) : US0 =
    US0_1(v0)
and closure5 () () : unativeint =
    let v0 : unativeint = 1 |> unativeint 
    v0
and method0 () : clap_Command =
    let v0 : string = "command"
    let v1 : string = "r#\"" + v0 + "\"#"
    let v2 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v1 
    let v3 : string = "clap::Command::new($0)"
    let v4 : clap_Command = Fable.Core.RustInterop.emitRustExpr v2 v3 
    let v5 : string = "clap::Command::args_override_self($0, true)"
    let v6 : clap_Command = Fable.Core.RustInterop.emitRustExpr v4 v5 
    let v13 : (unit -> unativeint) = closure1()
    let v14 : (unativeint -> US0) = closure2()
    let v15 : ((unit -> exn) -> exn) = closure3()
    let v16 : (exn -> US0) = closure4()
    let v17 : US0 = try v13 () |> v14 with ex -> (fun () -> ex) |> v15 |> v16 
    let v36 : US1 =
        match v17 with
        | US0_1(v33) -> (* Error *)
            US1_1
        | US0_0(v31) -> (* Ok *)
            US1_0(v31)
    let v74 : unativeint =
        match v36 with
        | US1_1 -> (* None *)
            failwith<unativeint> "Option does not have a value."
        | US1_0(v71) -> (* Some *)
            v71
    let v81 : (unit -> unativeint) = closure5()
    let v82 : US0 = try v81 () |> v14 with ex -> (fun () -> ex) |> v15 |> v16 
    let v101 : US1 =
        match v82 with
        | US0_1(v98) -> (* Error *)
            US1_1
        | US0_0(v96) -> (* Ok *)
            US1_0(v96)
    let v139 : unativeint =
        match v101 with
        | US1_1 -> (* None *)
            failwith<unativeint> "Option does not have a value."
        | US1_0(v136) -> (* Some *)
            v136
    let v146 : US0 = try v13 () |> v14 with ex -> (fun () -> ex) |> v15 |> v16 
    let v165 : US1 =
        match v146 with
        | US0_1(v162) -> (* Error *)
            US1_1
        | US0_0(v160) -> (* Ok *)
            US1_0(v160)
    let v203 : unativeint =
        match v165 with
        | US1_1 -> (* None *)
            failwith<unativeint> "Option does not have a value."
        | US1_0(v200) -> (* Some *)
            v200
    let v205 : bool = v139 = v203 
    let v220 : clap_builder_ValueRange =
        if v205 then
            let v215 : string = "clap::builder::ValueRange::new($0..)"
            let v216 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr v74 v215 
            v216
        else
            let v217 : string = "="
            let v218 : string = "clap::builder::ValueRange::new($0.." + v217 + "$1)"
            let v219 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr struct (v74, v139) v218 
            v219
    let v221 : string = "exception"
    let v222 : string = "r#\"" + v221 + "\"#"
    let v223 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v222 
    let v224 : string = "clap::Arg::new($0)"
    let v225 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v223 v224 
    let v226 : string = "$0.short($1)"
    let v227 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v225, 'e') v226 
    let v228 : string = "r#\"" + v221 + "\"#"
    let v229 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v228 
    let v230 : string = "$0.long($1)"
    let v231 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v227, v229) v230 
    let v232 : string = "$0.num_args($1)"
    let v233 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v231, v220) v232 
    let v234 : string = "$0.require_equals($1)"
    let v235 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v233, true) v234 
    let v236 : string = ""
    let v237 : string = "r#\"" + v236 + "\"#"
    let v238 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v237 
    let v239 : string = "$0.default_missing_value($1)"
    let v240 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v235, v238) v239 
    let v241 : string = "clap::Command::arg($0, $1)"
    let v242 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v6, v240) v241 
    let v243 : string = "trace_level"
    let v244 : string = "r#\"" + v243 + "\"#"
    let v245 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v244 
    let v246 : string = "clap::Arg::new($0)"
    let v247 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v245 v246 
    let v248 : string = "$0.short($1)"
    let v249 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v247, 't') v248 
    let v250 : string = "r#\"" + v243 + "\"#"
    let v251 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v250 
    let v252 : string = "$0.long($1)"
    let v253 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v249, v251) v252 
    
    
    
    
    
    let v256 : string = "Critical"
    let v257 : (unit -> string) = v256.ToLower
    let v258 : string = v257 ()
    let v270 : string = "Warning"
    let v271 : (unit -> string) = v270.ToLower
    let v272 : string = v271 ()
    let v284 : string = "Info"
    let v285 : (unit -> string) = v284.ToLower
    let v286 : string = v285 ()
    let v298 : string = "Debug"
    let v299 : (unit -> string) = v298.ToLower
    let v300 : string = v299 ()
    let v312 : string = "Verbose"
    let v313 : (unit -> string) = v312.ToLower
    let v314 : string = v313 ()
    let v324 : string list = []
    let v326 : string list = v258 :: v324 
    let v337 : string list = v272 :: v326 
    let v348 : string list = v286 :: v337 
    let v359 : string list = v300 :: v348 
    let v370 : string list = v314 :: v359 
    let v396 : (string list -> (string [])) = List.toArray
    let v397 : (string []) = v396 v370
    let v407 : string = "$0.to_vec()"
    let v408 : Vec<string> = Fable.Core.RustInterop.emitRustExpr v397 v407 
    let v409 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v410 : bool = Fable.Core.RustInterop.emitRustExpr v408 v409 
    let v411 : string = "x"
    let v412 : string = Fable.Core.RustInterop.emitRustExpr () v411 
    (* run_target_args'
    let v424 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v425 : string = "&*$0"
    let v426 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v412 v425 
    let _run_target_args'_v424 = v426 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v427 : string = "&*$0"
    let v428 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v412 v427 
    let _run_target_args'_v424 = v428 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v429 : string = "&*$0"
    let v430 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v412 v429 
    let _run_target_args'_v424 = v430 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v432 : Ref<Str> = v412 |> unbox<Ref<Str>>
    let _run_target_args'_v424 = v432 
    #endif
#if FABLE_COMPILER_PYTHON
    let v443 : Ref<Str> = v412 |> unbox<Ref<Str>>
    let _run_target_args'_v424 = v443 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v454 : Ref<Str> = v412 |> unbox<Ref<Str>>
    let _run_target_args'_v424 = v454 
    #endif
#else
    let v465 : Ref<Str> = v412 |> unbox<Ref<Str>>
    let _run_target_args'_v424 = v465 
    #endif
    let v475 : Ref<Str> = _run_target_args'_v424 
    (* run_target_args'
    let v509 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v510 : string = "String::from($0)"
    let v511 : std_string_String = Fable.Core.RustInterop.emitRustExpr v475 v510 
    let _run_target_args'_v509 = v511 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v512 : string = "String::from($0)"
    let v513 : std_string_String = Fable.Core.RustInterop.emitRustExpr v475 v512 
    let _run_target_args'_v509 = v513 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v514 : string = "String::from($0)"
    let v515 : std_string_String = Fable.Core.RustInterop.emitRustExpr v475 v514 
    let _run_target_args'_v509 = v515 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v517 : std_string_String = v475 |> unbox<std_string_String>
    let _run_target_args'_v509 = v517 
    #endif
#if FABLE_COMPILER_PYTHON
    let v528 : std_string_String = v475 |> unbox<std_string_String>
    let _run_target_args'_v509 = v528 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v539 : std_string_String = v475 |> unbox<std_string_String>
    let _run_target_args'_v509 = v539 
    #endif
#else
    let v550 : std_string_String = v475 |> unbox<std_string_String>
    let _run_target_args'_v509 = v550 
    #endif
    let v560 : std_string_String = _run_target_args'_v509 
    let v583 : string = "Box::new($0)"
    let v584 : Box<std_string_String> = Fable.Core.RustInterop.emitRustExpr v560 v583 
    let v585 : string = "Box::leak($0)"
    let v586 : Ref<Lifetime<StaticLifetime, Mut<std_string_String>>> = Fable.Core.RustInterop.emitRustExpr v584 v585 
    let v587 : string = "clap::builder::PossibleValue::new(&**$0)"
    let v588 : clap_builder_PossibleValue = Fable.Core.RustInterop.emitRustExpr v586 v587 
    let v589 : string = "true; $0 }).collect::<Vec<_>>()"
    let v590 : bool = Fable.Core.RustInterop.emitRustExpr v588 v589 
    let v591 : string = "_vec_map"
    let v592 : Vec<clap_builder_PossibleValue> = Fable.Core.RustInterop.emitRustExpr () v591 
    let v593 : string = "Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new($0))"
    let v594 : clap_builder_ValueParser = Fable.Core.RustInterop.emitRustExpr v592 v593 
    let v595 : string = "$0.value_parser($1)"
    let v596 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v253, v594) v595 
    let v597 : string = "clap::Command::arg($0, $1)"
    let v598 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v242, v596) v597 
    let v599 : string = "wasm"
    let v600 : string = "r#\"" + v599 + "\"#"
    let v601 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v600 
    let v602 : string = "clap::Arg::new($0)"
    let v603 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v601 v602 
    let v604 : string = "$0.short($1)"
    let v605 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v603, 'w') v604 
    let v606 : string = "r#\"" + v599 + "\"#"
    let v607 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v606 
    let v608 : string = "$0.long($1)"
    let v609 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v605, v607) v608 
    let v610 : string = "$0.required($1)"
    let v611 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v609, true) v610 
    let v612 : string = "clap::Command::arg($0, $1)"
    let v613 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v598, v611) v612 
    v613
and method1 () : string =
    let v0 : string = "trace_level"
    v0
and closure6 () (v0 : std_string_String) : US2 =
    US2_0(v0)
and method2 () : (std_string_String -> US2) =
    closure6()
and method6 (v0 : string) : string =
    v0
and method7 () : string =
    let v0 : string = ""
    v0
and closure8 () (v0 : string) : US9 =
    US9_0(v0)
and method8 () : (string -> US9) =
    closure8()
and method5 (v0 : string) : string =
    (* run_target_args'
    let v20 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v21 : string = method6(v0)
    let v22 : string = "std::env::var(&*$0)"
    let v23 : Result<std_string_String, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr v21 v22 
    let v24 : string = "true; let _result_map_ = $0.map(|x| { //"
    let v25 : bool = Fable.Core.RustInterop.emitRustExpr v23 v24 
    let v26 : string = "x"
    let v27 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v26 
    let v28 : string = "fable_library_rust::String_::fromString($0)"
    let v29 : string = Fable.Core.RustInterop.emitRustExpr v27 v28 
    let v30 : string = "true; $0 })"
    let v31 : bool = Fable.Core.RustInterop.emitRustExpr v29 v30 
    let v32 : string = "_result_map_"
    let v33 : Result<string, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr () v32 
    let v34 : string = method7()
    let v35 : string = "$0.unwrap_or($1)"
    let v36 : string = Fable.Core.RustInterop.emitRustExpr struct (v33, v34) v35 
    let _run_target_args'_v20 = v36 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v37 : US7 = US7_1
    let v38 : US8 = US8_4(v37)
    let v39 : string = $"env.get_environment_variable / target: {v38} / var: {v0}"
    let v40 : string = failwith<string> v39
    let _run_target_args'_v20 = v40 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v41 : US7 = US7_2
    let v42 : US8 = US8_4(v41)
    let v43 : string = $"env.get_environment_variable / target: {v42} / var: {v0}"
    let v44 : string = failwith<string> v43
    let _run_target_args'_v20 = v44 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v45 : string = "process.env[$0] ?? \"\""
    let v46 : string = Fable.Core.JsInterop.emitJsExpr v0 v45 
    let _run_target_args'_v20 = v46 
    #endif
#if FABLE_COMPILER_PYTHON
    let v52 : string = "os"
    let v53 : IOsEnviron = Fable.Core.PyInterop.importAll v52 
    let v54 : string = "v53.environ"
    let v55 : obj = Fable.Core.PyInterop.emitPyExpr () v54 
    let v70 : string = "v55.get($0)"
    let v71 : string = Fable.Core.PyInterop.emitPyExpr v0 v70 
    let mutable _v71 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v91 : (string -> string option) = Option.ofObj
    let v92 : string option = v91 v71
    v92 
    #else
    Some v71 
    #endif
    |> fun x -> _v71 <- Some x
    let v93 : string option = match _v71 with Some x -> x | None -> failwith "optionm'.of_obj / _v71=None"
    let v114 : (string -> US9) = method8()
    let v115 : US9 option = v93 |> Option.map v114 
    let v163 : US9 = US9_1
    let v164 : US9 = v115 |> Option.defaultValue v163 
    let v178 : string =
        match v164 with
        | US9_1 -> (* None *)
            let v176 : string = ""
            v176
        | US9_0(v175) -> (* Some *)
            v175
    let _run_target_args'_v20 = v178 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v179 : US7 = US7_1
    let v180 : US8 = US8_1(v179)
    let v181 : string = $"env.get_environment_variable / target: {v180} / var: {v0}"
    let v182 : string = failwith<string> v181
    let _run_target_args'_v20 = v182 
    #endif
#else
    let v183 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v184 : string = v183 v0
    let mutable _v184 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v195 : (string -> string option) = Option.ofObj
    let v196 : string option = v195 v184
    v196 
    #else
    Some v184 
    #endif
    |> fun x -> _v184 <- Some x
    let v197 : string option = match _v184 with Some x -> x | None -> failwith "optionm'.of_obj / _v184=None"
    let v218 : (string -> US9) = method8()
    let v219 : US9 option = v197 |> Option.map v218 
    let v267 : US9 = US9_1
    let v268 : US9 = v219 |> Option.defaultValue v267 
    let v282 : string =
        match v268 with
        | US9_1 -> (* None *)
            let v280 : string = ""
            v280
        | US9_0(v279) -> (* Some *)
            v279
    let _run_target_args'_v20 = v282 
    #endif
    let v283 : string = _run_target_args'_v20 
    v283
and closure9 (v0 : int64) () : int64 =
    let v1 : int64 = v0 |> int64 
    v1
and closure10 () (v0 : int64) : US10 =
    US10_0(v0)
and closure11 () (v0 : exn) : US10 =
    US10_1(v0)
and method4 () : struct (US4 * US6) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method5(v0)
    
    
    
    
    
    
    
    
    
    
    let v4 : string = "Critical"
    let v5 : (unit -> string) = v4.ToLower
    let v6 : string = v5 ()
    let v18 : string = "Warning"
    let v19 : (unit -> string) = v18.ToLower
    let v20 : string = v19 ()
    let v32 : string = "Info"
    let v33 : (unit -> string) = v32.ToLower
    let v34 : string = v33 ()
    let v46 : string = "Debug"
    let v47 : (unit -> string) = v46.ToLower
    let v48 : string = v47 ()
    let v60 : string = "Verbose"
    let v61 : (unit -> string) = v60.ToLower
    let v62 : string = v61 ()
    let v72 : bool = "Verbose" = v1
    let v76 : US4 =
        if v72 then
            let v73 : US5 = US5_0
            US4_0(v73)
        else
            US4_1
    let v162 : US4 =
        match v76 with
        | US4_1 -> (* None *)
            let v79 : bool = "Debug" = v1
            let v83 : US4 =
                if v79 then
                    let v80 : US5 = US5_1
                    US4_0(v80)
                else
                    US4_1
            match v83 with
            | US4_1 -> (* None *)
                let v86 : bool = "Info" = v1
                let v90 : US4 =
                    if v86 then
                        let v87 : US5 = US5_2
                        US4_0(v87)
                    else
                        US4_1
                match v90 with
                | US4_1 -> (* None *)
                    let v93 : bool = "Warning" = v1
                    let v97 : US4 =
                        if v93 then
                            let v94 : US5 = US5_3
                            US4_0(v94)
                        else
                            US4_1
                    match v97 with
                    | US4_1 -> (* None *)
                        let v100 : bool = "Critical" = v1
                        let v104 : US4 =
                            if v100 then
                                let v101 : US5 = US5_4
                                US4_0(v101)
                            else
                                US4_1
                        match v104 with
                        | US4_1 -> (* None *)
                            let v107 : bool = v62 = v1
                            let v111 : US4 =
                                if v107 then
                                    let v108 : US5 = US5_0
                                    US4_0(v108)
                                else
                                    US4_1
                            match v111 with
                            | US4_1 -> (* None *)
                                let v114 : bool = v48 = v1
                                let v118 : US4 =
                                    if v114 then
                                        let v115 : US5 = US5_1
                                        US4_0(v115)
                                    else
                                        US4_1
                                match v118 with
                                | US4_1 -> (* None *)
                                    let v121 : bool = v34 = v1
                                    let v125 : US4 =
                                        if v121 then
                                            let v122 : US5 = US5_2
                                            US4_0(v122)
                                        else
                                            US4_1
                                    match v125 with
                                    | US4_1 -> (* None *)
                                        let v128 : bool = v20 = v1
                                        let v132 : US4 =
                                            if v128 then
                                                let v129 : US5 = US5_3
                                                US4_0(v129)
                                            else
                                                US4_1
                                        match v132 with
                                        | US4_1 -> (* None *)
                                            let v135 : bool = v6 = v1
                                            let v139 : US4 =
                                                if v135 then
                                                    let v136 : US5 = US5_4
                                                    US4_0(v136)
                                                else
                                                    US4_1
                                            match v139 with
                                            | US4_1 -> (* None *)
                                                US4_1
                                            | US4_0(v140) -> (* Some *)
                                                US4_0(v140)
                                        | US4_0(v133) -> (* Some *)
                                            US4_0(v133)
                                    | US4_0(v126) -> (* Some *)
                                        US4_0(v126)
                                | US4_0(v119) -> (* Some *)
                                    US4_0(v119)
                            | US4_0(v112) -> (* Some *)
                                US4_0(v112)
                        | US4_0(v105) -> (* Some *)
                            US4_0(v105)
                    | US4_0(v98) -> (* Some *)
                        US4_0(v98)
                | US4_0(v91) -> (* Some *)
                    US4_0(v91)
            | US4_0(v84) -> (* Some *)
                US4_0(v84)
        | US4_0(v77) -> (* Some *)
            US4_0(v77)
    let v163 : string = "AUTOMATION"
    let v164 : string = method5(v163)
    let v167 : string = "True"
    let v168 : bool = v164 <> v167 
    let v454 : US6 =
        if v168 then
            US6_1
        else
            (* run_target_args'
            let v194 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v195 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v194 = v195 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v196 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v194 = v196 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v198 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v194 = v198 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v208 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v194 = v208 
            #endif
#if FABLE_COMPILER_PYTHON
            let v209 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v194 = v209 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v210 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v194 = v210 
            #endif
#else
            let v211 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v194 = v211 
            #endif
            let v212 : System.DateTime = _run_target_args'_v194 
            (* run_target_args'
            let v230 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v231 : (System.DateTime -> int64) = _.Ticks
            let v232 : int64 = v231 v212
            let _run_target_args'_v230 = v232 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v233 : (System.DateTime -> int64) = _.Ticks
            let v234 : int64 = v233 v212
            let _run_target_args'_v230 = v234 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v236 : int64 = null |> unbox<int64>
            let _run_target_args'_v230 = v236 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v246 : (System.DateTime -> int64) = _.Ticks
            let v247 : int64 = v246 v212
            let _run_target_args'_v230 = v247 
            #endif
#if FABLE_COMPILER_PYTHON
            let v248 : (System.DateTime -> int64) = _.Ticks
            let v249 : int64 = v248 v212
            let _run_target_args'_v230 = v249 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v250 : (System.DateTime -> int64) = _.Ticks
            let v251 : int64 = v250 v212
            let _run_target_args'_v230 = v251 
            #endif
#else
            let v252 : (System.DateTime -> int64) = _.Ticks
            let v253 : int64 = v252 v212
            let _run_target_args'_v230 = v253 
            #endif
            let v254 : int64 = _run_target_args'_v230 
            let v373 : (unit -> int64) = closure9(v254)
            let v374 : (int64 -> US10) = closure10()
            let v375 : ((unit -> exn) -> exn) = closure3()
            let v376 : (exn -> US10) = closure11()
            let v377 : US10 = try v373 () |> v374 with ex -> (fun () -> ex) |> v375 |> v376 
            let v396 : US6 =
                match v377 with
                | US10_1(v393) -> (* Error *)
                    US6_1
                | US10_0(v391) -> (* Ok *)
                    US6_0(v391)
            let v434 : int64 =
                match v396 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v431) -> (* Some *)
                    v431
            US6_0(v434)
    struct (v162, v454)
and closure12 () (v0 : string) : unit =
    ()
and method3 (v0 : US5) : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let struct (v4 : US4, v5 : US6) = method4()
    let _run_target_args'_v3 = struct (v4, v5) 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : US4 = US4_1
    let v7 : US6 = US6_1
    let _run_target_args'_v3 = struct (v6, v7) 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : string = "AUTOMATION"
    (* run_target_args'
    let v20 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v21 : string = "option_env!(\"" + v8 + "\").unwrap_or(\"\")"
    let v22 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v21 
    (* run_target_args'
    let v34 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v35 : string = "String::from($0)"
    let v36 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v35 
    let _run_target_args'_v34 = v36 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v37 : string = "String::from($0)"
    let v38 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v37 
    let _run_target_args'_v34 = v38 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v39 : string = "String::from($0)"
    let v40 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v39 
    let _run_target_args'_v34 = v40 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v42 : std_string_String = v22 |> unbox<std_string_String>
    let _run_target_args'_v34 = v42 
    #endif
#if FABLE_COMPILER_PYTHON
    let v53 : std_string_String = v22 |> unbox<std_string_String>
    let _run_target_args'_v34 = v53 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_string_String = v22 |> unbox<std_string_String>
    let _run_target_args'_v34 = v64 
    #endif
#else
    let v75 : std_string_String = v22 |> unbox<std_string_String>
    let _run_target_args'_v34 = v75 
    #endif
    let v85 : std_string_String = _run_target_args'_v34 
    let v108 : string = "fable_library_rust::String_::fromString($0)"
    let v109 : string = Fable.Core.RustInterop.emitRustExpr v85 v108 
    let _run_target_args'_v20 = v109 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v110 : string = "option_env!(\"" + v8 + "\").unwrap_or(\"\")"
    let v111 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v110 
    (* run_target_args'
    let v123 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v124 : string = "String::from($0)"
    let v125 : std_string_String = Fable.Core.RustInterop.emitRustExpr v111 v124 
    let _run_target_args'_v123 = v125 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v126 : string = "String::from($0)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr v111 v126 
    let _run_target_args'_v123 = v127 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v128 : string = "String::from($0)"
    let v129 : std_string_String = Fable.Core.RustInterop.emitRustExpr v111 v128 
    let _run_target_args'_v123 = v129 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v131 : std_string_String = v111 |> unbox<std_string_String>
    let _run_target_args'_v123 = v131 
    #endif
#if FABLE_COMPILER_PYTHON
    let v142 : std_string_String = v111 |> unbox<std_string_String>
    let _run_target_args'_v123 = v142 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v153 : std_string_String = v111 |> unbox<std_string_String>
    let _run_target_args'_v123 = v153 
    #endif
#else
    let v164 : std_string_String = v111 |> unbox<std_string_String>
    let _run_target_args'_v123 = v164 
    #endif
    let v174 : std_string_String = _run_target_args'_v123 
    let v197 : string = "fable_library_rust::String_::fromString($0)"
    let v198 : string = Fable.Core.RustInterop.emitRustExpr v174 v197 
    let _run_target_args'_v20 = v198 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v199 : string = "option_env!(\"" + v8 + "\").unwrap_or(\"\")"
    let v200 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v199 
    (* run_target_args'
    let v212 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v213 : string = "String::from($0)"
    let v214 : std_string_String = Fable.Core.RustInterop.emitRustExpr v200 v213 
    let _run_target_args'_v212 = v214 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v215 : string = "String::from($0)"
    let v216 : std_string_String = Fable.Core.RustInterop.emitRustExpr v200 v215 
    let _run_target_args'_v212 = v216 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v217 : string = "String::from($0)"
    let v218 : std_string_String = Fable.Core.RustInterop.emitRustExpr v200 v217 
    let _run_target_args'_v212 = v218 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v220 : std_string_String = v200 |> unbox<std_string_String>
    let _run_target_args'_v212 = v220 
    #endif
#if FABLE_COMPILER_PYTHON
    let v231 : std_string_String = v200 |> unbox<std_string_String>
    let _run_target_args'_v212 = v231 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v242 : std_string_String = v200 |> unbox<std_string_String>
    let _run_target_args'_v212 = v242 
    #endif
#else
    let v253 : std_string_String = v200 |> unbox<std_string_String>
    let _run_target_args'_v212 = v253 
    #endif
    let v263 : std_string_String = _run_target_args'_v212 
    let v286 : string = "fable_library_rust::String_::fromString($0)"
    let v287 : string = Fable.Core.RustInterop.emitRustExpr v263 v286 
    let _run_target_args'_v20 = v287 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v289 : string = null |> unbox<string>
    let _run_target_args'_v20 = v289 
    #endif
#if FABLE_COMPILER_PYTHON
    let v300 : string = null |> unbox<string>
    let _run_target_args'_v20 = v300 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v311 : string = null |> unbox<string>
    let _run_target_args'_v20 = v311 
    #endif
#else
    let v322 : string = null |> unbox<string>
    let _run_target_args'_v20 = v322 
    #endif
    let v332 : string = _run_target_args'_v20 
    let v357 : string = "True"
    let v358 : bool = v332 <> v357 
    let v384 : US6 =
        if v358 then
            US6_1
        else
            let v369 : string = $"near_sdk::env::block_timestamp()"
            let v370 : uint64 = Fable.Core.RustInterop.emitRustExpr () v369 
            let v372 : (uint64 -> int64) = int64
            let v373 : int64 = v372 v370
            US6_0(v373)
    let v385 : US4 = US4_1
    let _run_target_args'_v3 = struct (v385, v384) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v386 : US4, v387 : US6) = method4()
    let _run_target_args'_v3 = struct (v386, v387) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v388 : US4, v389 : US6) = method4()
    let _run_target_args'_v3 = struct (v388, v389) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v390 : US4, v391 : US6) = method4()
    let _run_target_args'_v3 = struct (v390, v391) 
    #endif
#else
    let struct (v392 : US4, v393 : US6) = method4()
    let _run_target_args'_v3 = struct (v392, v393) 
    #endif
    let struct (v394 : US4, v395 : US6) = _run_target_args'_v3 
    let v400 : Mut0 = {l0 = 1L} : Mut0
    let v401 : (string -> unit) = closure12()
    let v402 : Mut1 = {l0 = v401} : Mut1
    let v403 : Mut2 = {l0 = true} : Mut2
    let v404 : string = ""
    let v405 : Mut3 = {l0 = v404} : Mut3
    let v408 : US5 =
        match v394 with
        | US4_1 -> (* None *)
            v0
        | US4_0(v406) -> (* Some *)
            v406
    let v409 : Mut4 = {l0 = v408} : Mut4
    let v434 : int64 option =
        match v395 with
        | US6_1 -> (* None *)
            let v423 : int64 option = None
            v423
        | US6_0(v410) -> (* Some *)
            let v412 : int64 option = Some v410 
            v412
    struct (v400, v402, v403, v405, v409, v434)
and closure7 (v0 : US5) () : unit =
    let v1 : bool = TraceState.trace_state.IsNone
    if v1 then
        let struct (v2 : Mut0, v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : int64 option) = method3(v0)
        let v9 : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v9 
        ()
and closure14 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US5 = US5_0
        let struct (v2 : Mut0, v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : int64 option) = method3(v1)
        let v9 : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v9 
        ()
and closure15 () (v0 : int64) : US6 =
    US6_0(v0)
and method10 () : (int64 -> US6) =
    closure15()
and method11 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method12 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method9 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v595 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v607 : (int64 -> US6) = method10()
    let v608 : US6 option = v5 |> Option.map v607 
    let v656 : US6 = US6_1
    let v657 : US6 = v608 |> Option.defaultValue v656 
    let v1154 : System.DateTime =
        match v657 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v1123 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1124 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1123 = v1124 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1125 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1123 = v1125 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1127 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1123 = v1127 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1137 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1123 = v1137 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1138 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1123 = v1138 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1139 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1123 = v1139 
            #endif
#else
            let v1140 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1123 = v1140 
            #endif
            let v1141 : System.DateTime = _run_target_args'_v1123 
            v1141
        | US6_0(v668) -> (* Some *)
            (* run_target_args'
            let v684 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v685 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v684 = v685 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v686 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v684 = v686 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v688 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v684 = v688 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v698 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v684 = v698 
            #endif
#if FABLE_COMPILER_PYTHON
            let v699 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v684 = v699 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v700 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v684 = v700 
            #endif
#else
            let v701 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v684 = v701 
            #endif
            let v702 : System.DateTime = _run_target_args'_v684 
            (* run_target_args'
            let v720 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v721 : (System.DateTime -> int64) = _.Ticks
            let v722 : int64 = v721 v702
            let _run_target_args'_v720 = v722 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v723 : (System.DateTime -> int64) = _.Ticks
            let v724 : int64 = v723 v702
            let _run_target_args'_v720 = v724 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v726 : int64 = null |> unbox<int64>
            let _run_target_args'_v720 = v726 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v736 : (System.DateTime -> int64) = _.Ticks
            let v737 : int64 = v736 v702
            let _run_target_args'_v720 = v737 
            #endif
#if FABLE_COMPILER_PYTHON
            let v738 : (System.DateTime -> int64) = _.Ticks
            let v739 : int64 = v738 v702
            let _run_target_args'_v720 = v739 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v740 : (System.DateTime -> int64) = _.Ticks
            let v741 : int64 = v740 v702
            let _run_target_args'_v720 = v741 
            #endif
#else
            let v742 : (System.DateTime -> int64) = _.Ticks
            let v743 : int64 = v742 v702
            let _run_target_args'_v720 = v743 
            #endif
            let v744 : int64 = _run_target_args'_v720 
            let v863 : (unit -> int64) = closure9(v744)
            let v864 : (int64 -> US10) = closure10()
            let v865 : ((unit -> exn) -> exn) = closure3()
            let v866 : (exn -> US10) = closure11()
            let v867 : US10 = try v863 () |> v864 with ex -> (fun () -> ex) |> v865 |> v866 
            let v886 : US6 =
                match v867 with
                | US10_1(v883) -> (* Error *)
                    US6_1
                | US10_0(v881) -> (* Ok *)
                    US6_0(v881)
            let v924 : int64 =
                match v886 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v921) -> (* Some *)
                    v921
            let v934 : int64 = v924 - v668
            let v1000 : System.TimeSpan = v934 |> System.TimeSpan 
            let v1011 : (System.TimeSpan -> int32) = _.Hours
            let v1012 : int32 = v1011 v1000
            let v1023 : (System.TimeSpan -> int32) = _.Minutes
            let v1024 : int32 = v1023 v1000
            let v1035 : (System.TimeSpan -> int32) = _.Seconds
            let v1036 : int32 = v1035 v1000
            let v1047 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1048 : int32 = v1047 v1000
            let v1098 : System.DateTime = System.DateTime (1, 1, 1, v1012, v1024, v1036, v1048)
            v1098
    let v1155 : string = method11()
    let v1174 : bool = v1155 = ""
    let v1176 : string =
        if v1174 then
            let v1175 : string = "M-d-y hh:mm:ss tt"
            v1175
        else
            v1155
    let v1177 : (string -> string) = v1154.ToString
    let v1178 : string = v1177 v1176
    let _run_target_args'_v595 = v1178 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1218 : (int64 -> US6) = method10()
    let v1219 : US6 option = v5 |> Option.map v1218 
    let v1267 : US6 = US6_1
    let v1268 : US6 = v1219 |> Option.defaultValue v1267 
    let v1765 : System.DateTime =
        match v1268 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v1734 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1735 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1734 = v1735 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1736 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1734 = v1736 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1738 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1734 = v1738 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1748 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1734 = v1748 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1749 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1734 = v1749 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1750 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1734 = v1750 
            #endif
#else
            let v1751 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1734 = v1751 
            #endif
            let v1752 : System.DateTime = _run_target_args'_v1734 
            v1752
        | US6_0(v1279) -> (* Some *)
            (* run_target_args'
            let v1295 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1296 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1295 = v1296 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1297 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1295 = v1297 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1299 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1295 = v1299 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1309 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1295 = v1309 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1310 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1295 = v1310 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1311 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1295 = v1311 
            #endif
#else
            let v1312 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1295 = v1312 
            #endif
            let v1313 : System.DateTime = _run_target_args'_v1295 
            (* run_target_args'
            let v1331 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1332 : (System.DateTime -> int64) = _.Ticks
            let v1333 : int64 = v1332 v1313
            let _run_target_args'_v1331 = v1333 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1334 : (System.DateTime -> int64) = _.Ticks
            let v1335 : int64 = v1334 v1313
            let _run_target_args'_v1331 = v1335 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1337 : int64 = null |> unbox<int64>
            let _run_target_args'_v1331 = v1337 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1347 : (System.DateTime -> int64) = _.Ticks
            let v1348 : int64 = v1347 v1313
            let _run_target_args'_v1331 = v1348 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1349 : (System.DateTime -> int64) = _.Ticks
            let v1350 : int64 = v1349 v1313
            let _run_target_args'_v1331 = v1350 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1351 : (System.DateTime -> int64) = _.Ticks
            let v1352 : int64 = v1351 v1313
            let _run_target_args'_v1331 = v1352 
            #endif
#else
            let v1353 : (System.DateTime -> int64) = _.Ticks
            let v1354 : int64 = v1353 v1313
            let _run_target_args'_v1331 = v1354 
            #endif
            let v1355 : int64 = _run_target_args'_v1331 
            let v1474 : (unit -> int64) = closure9(v1355)
            let v1475 : (int64 -> US10) = closure10()
            let v1476 : ((unit -> exn) -> exn) = closure3()
            let v1477 : (exn -> US10) = closure11()
            let v1478 : US10 = try v1474 () |> v1475 with ex -> (fun () -> ex) |> v1476 |> v1477 
            let v1497 : US6 =
                match v1478 with
                | US10_1(v1494) -> (* Error *)
                    US6_1
                | US10_0(v1492) -> (* Ok *)
                    US6_0(v1492)
            let v1535 : int64 =
                match v1497 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v1532) -> (* Some *)
                    v1532
            let v1545 : int64 = v1535 - v1279
            let v1611 : System.TimeSpan = v1545 |> System.TimeSpan 
            let v1622 : (System.TimeSpan -> int32) = _.Hours
            let v1623 : int32 = v1622 v1611
            let v1634 : (System.TimeSpan -> int32) = _.Minutes
            let v1635 : int32 = v1634 v1611
            let v1646 : (System.TimeSpan -> int32) = _.Seconds
            let v1647 : int32 = v1646 v1611
            let v1658 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1659 : int32 = v1658 v1611
            let v1709 : System.DateTime = System.DateTime (1, 1, 1, v1623, v1635, v1647, v1659)
            v1709
    let v1766 : string = method11()
    let v1785 : bool = v1766 = ""
    let v1787 : string =
        if v1785 then
            let v1786 : string = "M-d-y hh:mm:ss tt"
            v1786
        else
            v1766
    let v1788 : (string -> string) = v1765.ToString
    let v1789 : string = v1788 v1787
    let _run_target_args'_v595 = v1789 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1818 : string = $"near_sdk::env::block_timestamp()"
    let v1819 : uint64 = Fable.Core.RustInterop.emitRustExpr () v1818 
    let v1831 : (int64 -> US6) = method10()
    let v1832 : US6 option = v5 |> Option.map v1831 
    let v1880 : US6 = US6_1
    let v1881 : US6 = v1832 |> Option.defaultValue v1880 
    let v1907 : uint64 =
        match v1881 with
        | US6_1 -> (* None *)
            v1819
        | US6_0(v1892) -> (* Some *)
            let v1894 : (int64 -> uint64) = uint64
            let v1895 : uint64 = v1894 v1892
            let v1905 : uint64 = v1819 - v1895
            v1905
    let v1908 : uint64 = v1907 / 1000000000UL
    let v1909 : uint64 = v1908 % 60UL
    let v1910 : uint64 = v1908 / 60UL
    let v1911 : uint64 = v1910 % 60UL
    let v1912 : uint64 = v1908 / 3600UL
    let v1913 : uint64 = v1912 % 24UL
    let v1914 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v1915 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1913, v1911, v1909) v1914 
    let v1916 : string = "fable_library_rust::String_::fromString($0)"
    let v1917 : string = Fable.Core.RustInterop.emitRustExpr v1915 v1916 
    let _run_target_args'_v595 = v1917 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1929 : (int64 -> US6) = method10()
    let v1930 : US6 option = v5 |> Option.map v1929 
    let v1978 : US6 = US6_1
    let v1979 : US6 = v1930 |> Option.defaultValue v1978 
    let v2476 : System.DateTime =
        match v1979 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v2445 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2446 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2445 = v2446 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2447 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2445 = v2447 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2449 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v2445 = v2449 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2459 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2445 = v2459 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2460 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2445 = v2460 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2461 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2445 = v2461 
            #endif
#else
            let v2462 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2445 = v2462 
            #endif
            let v2463 : System.DateTime = _run_target_args'_v2445 
            v2463
        | US6_0(v1990) -> (* Some *)
            (* run_target_args'
            let v2006 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2007 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2006 = v2007 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2008 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2006 = v2008 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2010 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v2006 = v2010 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2020 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2006 = v2020 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2021 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2006 = v2021 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2022 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2006 = v2022 
            #endif
#else
            let v2023 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2006 = v2023 
            #endif
            let v2024 : System.DateTime = _run_target_args'_v2006 
            (* run_target_args'
            let v2042 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2043 : (System.DateTime -> int64) = _.Ticks
            let v2044 : int64 = v2043 v2024
            let _run_target_args'_v2042 = v2044 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2045 : (System.DateTime -> int64) = _.Ticks
            let v2046 : int64 = v2045 v2024
            let _run_target_args'_v2042 = v2046 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2048 : int64 = null |> unbox<int64>
            let _run_target_args'_v2042 = v2048 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2058 : (System.DateTime -> int64) = _.Ticks
            let v2059 : int64 = v2058 v2024
            let _run_target_args'_v2042 = v2059 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2060 : (System.DateTime -> int64) = _.Ticks
            let v2061 : int64 = v2060 v2024
            let _run_target_args'_v2042 = v2061 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2062 : (System.DateTime -> int64) = _.Ticks
            let v2063 : int64 = v2062 v2024
            let _run_target_args'_v2042 = v2063 
            #endif
#else
            let v2064 : (System.DateTime -> int64) = _.Ticks
            let v2065 : int64 = v2064 v2024
            let _run_target_args'_v2042 = v2065 
            #endif
            let v2066 : int64 = _run_target_args'_v2042 
            let v2185 : (unit -> int64) = closure9(v2066)
            let v2186 : (int64 -> US10) = closure10()
            let v2187 : ((unit -> exn) -> exn) = closure3()
            let v2188 : (exn -> US10) = closure11()
            let v2189 : US10 = try v2185 () |> v2186 with ex -> (fun () -> ex) |> v2187 |> v2188 
            let v2208 : US6 =
                match v2189 with
                | US10_1(v2205) -> (* Error *)
                    US6_1
                | US10_0(v2203) -> (* Ok *)
                    US6_0(v2203)
            let v2246 : int64 =
                match v2208 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v2243) -> (* Some *)
                    v2243
            let v2256 : int64 = v2246 - v1990
            let v2322 : System.TimeSpan = v2256 |> System.TimeSpan 
            let v2333 : (System.TimeSpan -> int32) = _.Hours
            let v2334 : int32 = v2333 v2322
            let v2345 : (System.TimeSpan -> int32) = _.Minutes
            let v2346 : int32 = v2345 v2322
            let v2357 : (System.TimeSpan -> int32) = _.Seconds
            let v2358 : int32 = v2357 v2322
            let v2369 : (System.TimeSpan -> int32) = _.Milliseconds
            let v2370 : int32 = v2369 v2322
            let v2420 : System.DateTime = System.DateTime (1, 1, 1, v2334, v2346, v2358, v2370)
            v2420
    let v2477 : string = method12()
    let v2496 : bool = v2477 = ""
    let v2498 : string =
        if v2496 then
            let v2497 : string = "M-d-y hh:mm:ss tt"
            v2497
        else
            v2477
    let v2499 : (string -> string) = v2476.ToString
    let v2500 : string = v2499 v2498
    let _run_target_args'_v595 = v2500 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2540 : (int64 -> US6) = method10()
    let v2541 : US6 option = v5 |> Option.map v2540 
    let v2589 : US6 = US6_1
    let v2590 : US6 = v2541 |> Option.defaultValue v2589 
    let v3087 : System.DateTime =
        match v2590 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v3056 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3057 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3056 = v3057 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3058 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3056 = v3058 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3060 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v3056 = v3060 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3070 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3056 = v3070 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3071 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3056 = v3071 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3072 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3056 = v3072 
            #endif
#else
            let v3073 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3056 = v3073 
            #endif
            let v3074 : System.DateTime = _run_target_args'_v3056 
            v3074
        | US6_0(v2601) -> (* Some *)
            (* run_target_args'
            let v2617 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2618 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2617 = v2618 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2619 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2617 = v2619 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2621 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v2617 = v2621 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2631 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2617 = v2631 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2632 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2617 = v2632 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2633 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2617 = v2633 
            #endif
#else
            let v2634 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2617 = v2634 
            #endif
            let v2635 : System.DateTime = _run_target_args'_v2617 
            (* run_target_args'
            let v2653 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2654 : (System.DateTime -> int64) = _.Ticks
            let v2655 : int64 = v2654 v2635
            let _run_target_args'_v2653 = v2655 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2656 : (System.DateTime -> int64) = _.Ticks
            let v2657 : int64 = v2656 v2635
            let _run_target_args'_v2653 = v2657 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2659 : int64 = null |> unbox<int64>
            let _run_target_args'_v2653 = v2659 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2669 : (System.DateTime -> int64) = _.Ticks
            let v2670 : int64 = v2669 v2635
            let _run_target_args'_v2653 = v2670 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2671 : (System.DateTime -> int64) = _.Ticks
            let v2672 : int64 = v2671 v2635
            let _run_target_args'_v2653 = v2672 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2673 : (System.DateTime -> int64) = _.Ticks
            let v2674 : int64 = v2673 v2635
            let _run_target_args'_v2653 = v2674 
            #endif
#else
            let v2675 : (System.DateTime -> int64) = _.Ticks
            let v2676 : int64 = v2675 v2635
            let _run_target_args'_v2653 = v2676 
            #endif
            let v2677 : int64 = _run_target_args'_v2653 
            let v2796 : (unit -> int64) = closure9(v2677)
            let v2797 : (int64 -> US10) = closure10()
            let v2798 : ((unit -> exn) -> exn) = closure3()
            let v2799 : (exn -> US10) = closure11()
            let v2800 : US10 = try v2796 () |> v2797 with ex -> (fun () -> ex) |> v2798 |> v2799 
            let v2819 : US6 =
                match v2800 with
                | US10_1(v2816) -> (* Error *)
                    US6_1
                | US10_0(v2814) -> (* Ok *)
                    US6_0(v2814)
            let v2857 : int64 =
                match v2819 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v2854) -> (* Some *)
                    v2854
            let v2867 : int64 = v2857 - v2601
            let v2933 : System.TimeSpan = v2867 |> System.TimeSpan 
            let v2944 : (System.TimeSpan -> int32) = _.Hours
            let v2945 : int32 = v2944 v2933
            let v2956 : (System.TimeSpan -> int32) = _.Minutes
            let v2957 : int32 = v2956 v2933
            let v2968 : (System.TimeSpan -> int32) = _.Seconds
            let v2969 : int32 = v2968 v2933
            let v2980 : (System.TimeSpan -> int32) = _.Milliseconds
            let v2981 : int32 = v2980 v2933
            let v3031 : System.DateTime = System.DateTime (1, 1, 1, v2945, v2957, v2969, v2981)
            v3031
    let v3088 : string = method12()
    let v3107 : bool = v3088 = ""
    let v3109 : string =
        if v3107 then
            let v3108 : string = "M-d-y hh:mm:ss tt"
            v3108
        else
            v3088
    let v3110 : (string -> string) = v3087.ToString
    let v3111 : string = v3110 v3109
    let _run_target_args'_v595 = v3111 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3151 : (int64 -> US6) = method10()
    let v3152 : US6 option = v5 |> Option.map v3151 
    let v3200 : US6 = US6_1
    let v3201 : US6 = v3152 |> Option.defaultValue v3200 
    let v3698 : System.DateTime =
        match v3201 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v3667 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3668 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3667 = v3668 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3669 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3667 = v3669 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3671 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v3667 = v3671 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3681 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3667 = v3681 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3682 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3667 = v3682 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3683 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3667 = v3683 
            #endif
#else
            let v3684 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3667 = v3684 
            #endif
            let v3685 : System.DateTime = _run_target_args'_v3667 
            v3685
        | US6_0(v3212) -> (* Some *)
            (* run_target_args'
            let v3228 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3229 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3228 = v3229 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3230 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3228 = v3230 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3232 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v3228 = v3232 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3242 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3228 = v3242 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3243 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3228 = v3243 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3244 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3228 = v3244 
            #endif
#else
            let v3245 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3228 = v3245 
            #endif
            let v3246 : System.DateTime = _run_target_args'_v3228 
            (* run_target_args'
            let v3264 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3265 : (System.DateTime -> int64) = _.Ticks
            let v3266 : int64 = v3265 v3246
            let _run_target_args'_v3264 = v3266 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3267 : (System.DateTime -> int64) = _.Ticks
            let v3268 : int64 = v3267 v3246
            let _run_target_args'_v3264 = v3268 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3270 : int64 = null |> unbox<int64>
            let _run_target_args'_v3264 = v3270 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3280 : (System.DateTime -> int64) = _.Ticks
            let v3281 : int64 = v3280 v3246
            let _run_target_args'_v3264 = v3281 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3282 : (System.DateTime -> int64) = _.Ticks
            let v3283 : int64 = v3282 v3246
            let _run_target_args'_v3264 = v3283 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3284 : (System.DateTime -> int64) = _.Ticks
            let v3285 : int64 = v3284 v3246
            let _run_target_args'_v3264 = v3285 
            #endif
#else
            let v3286 : (System.DateTime -> int64) = _.Ticks
            let v3287 : int64 = v3286 v3246
            let _run_target_args'_v3264 = v3287 
            #endif
            let v3288 : int64 = _run_target_args'_v3264 
            let v3407 : (unit -> int64) = closure9(v3288)
            let v3408 : (int64 -> US10) = closure10()
            let v3409 : ((unit -> exn) -> exn) = closure3()
            let v3410 : (exn -> US10) = closure11()
            let v3411 : US10 = try v3407 () |> v3408 with ex -> (fun () -> ex) |> v3409 |> v3410 
            let v3430 : US6 =
                match v3411 with
                | US10_1(v3427) -> (* Error *)
                    US6_1
                | US10_0(v3425) -> (* Ok *)
                    US6_0(v3425)
            let v3468 : int64 =
                match v3430 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v3465) -> (* Some *)
                    v3465
            let v3478 : int64 = v3468 - v3212
            let v3544 : System.TimeSpan = v3478 |> System.TimeSpan 
            let v3555 : (System.TimeSpan -> int32) = _.Hours
            let v3556 : int32 = v3555 v3544
            let v3567 : (System.TimeSpan -> int32) = _.Minutes
            let v3568 : int32 = v3567 v3544
            let v3579 : (System.TimeSpan -> int32) = _.Seconds
            let v3580 : int32 = v3579 v3544
            let v3591 : (System.TimeSpan -> int32) = _.Milliseconds
            let v3592 : int32 = v3591 v3544
            let v3642 : System.DateTime = System.DateTime (1, 1, 1, v3556, v3568, v3580, v3592)
            v3642
    let v3699 : string = method12()
    let v3718 : bool = v3699 = ""
    let v3720 : string =
        if v3718 then
            let v3719 : string = "M-d-y hh:mm:ss tt"
            v3719
        else
            v3699
    let v3721 : (string -> string) = v3698.ToString
    let v3722 : string = v3721 v3720
    let _run_target_args'_v595 = v3722 
    #endif
#else
    let v3762 : (int64 -> US6) = method10()
    let v3763 : US6 option = v5 |> Option.map v3762 
    let v3811 : US6 = US6_1
    let v3812 : US6 = v3763 |> Option.defaultValue v3811 
    let v4309 : System.DateTime =
        match v3812 with
        | US6_1 -> (* None *)
            (* run_target_args'
            let v4278 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4279 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4278 = v4279 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4280 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4278 = v4280 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4282 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v4278 = v4282 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4292 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4278 = v4292 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4293 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4278 = v4293 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4294 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4278 = v4294 
            #endif
#else
            let v4295 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v4278 = v4295 
            #endif
            let v4296 : System.DateTime = _run_target_args'_v4278 
            v4296
        | US6_0(v3823) -> (* Some *)
            (* run_target_args'
            let v3839 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3840 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3839 = v3840 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3841 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3839 = v3841 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3843 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v3839 = v3843 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3853 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3839 = v3853 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3854 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3839 = v3854 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3855 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3839 = v3855 
            #endif
#else
            let v3856 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3839 = v3856 
            #endif
            let v3857 : System.DateTime = _run_target_args'_v3839 
            (* run_target_args'
            let v3875 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3876 : (System.DateTime -> int64) = _.Ticks
            let v3877 : int64 = v3876 v3857
            let _run_target_args'_v3875 = v3877 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3878 : (System.DateTime -> int64) = _.Ticks
            let v3879 : int64 = v3878 v3857
            let _run_target_args'_v3875 = v3879 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3881 : int64 = null |> unbox<int64>
            let _run_target_args'_v3875 = v3881 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3891 : (System.DateTime -> int64) = _.Ticks
            let v3892 : int64 = v3891 v3857
            let _run_target_args'_v3875 = v3892 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3893 : (System.DateTime -> int64) = _.Ticks
            let v3894 : int64 = v3893 v3857
            let _run_target_args'_v3875 = v3894 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3895 : (System.DateTime -> int64) = _.Ticks
            let v3896 : int64 = v3895 v3857
            let _run_target_args'_v3875 = v3896 
            #endif
#else
            let v3897 : (System.DateTime -> int64) = _.Ticks
            let v3898 : int64 = v3897 v3857
            let _run_target_args'_v3875 = v3898 
            #endif
            let v3899 : int64 = _run_target_args'_v3875 
            let v4018 : (unit -> int64) = closure9(v3899)
            let v4019 : (int64 -> US10) = closure10()
            let v4020 : ((unit -> exn) -> exn) = closure3()
            let v4021 : (exn -> US10) = closure11()
            let v4022 : US10 = try v4018 () |> v4019 with ex -> (fun () -> ex) |> v4020 |> v4021 
            let v4041 : US6 =
                match v4022 with
                | US10_1(v4038) -> (* Error *)
                    US6_1
                | US10_0(v4036) -> (* Ok *)
                    US6_0(v4036)
            let v4079 : int64 =
                match v4041 with
                | US6_1 -> (* None *)
                    failwith<int64> "Option does not have a value."
                | US6_0(v4076) -> (* Some *)
                    v4076
            let v4089 : int64 = v4079 - v3823
            let v4155 : System.TimeSpan = v4089 |> System.TimeSpan 
            let v4166 : (System.TimeSpan -> int32) = _.Hours
            let v4167 : int32 = v4166 v4155
            let v4178 : (System.TimeSpan -> int32) = _.Minutes
            let v4179 : int32 = v4178 v4155
            let v4190 : (System.TimeSpan -> int32) = _.Seconds
            let v4191 : int32 = v4190 v4155
            let v4202 : (System.TimeSpan -> int32) = _.Milliseconds
            let v4203 : int32 = v4202 v4155
            let v4253 : System.DateTime = System.DateTime (1, 1, 1, v4167, v4179, v4191, v4203)
            v4253
    let v4310 : string = method12()
    let v4329 : bool = v4310 = ""
    let v4331 : string =
        if v4329 then
            let v4330 : string = "M-d-y hh:mm:ss tt"
            v4330
        else
            v4310
    let v4332 : (string -> string) = v4309.ToString
    let v4333 : string = v4332 v4331
    let _run_target_args'_v595 = v4333 
    #endif
    let v4362 : string = _run_target_args'_v595 
    v4362
and method15 () : string =
    let v0 : string = ""
    v0
and method16 (v0 : Mut3, v1 : string) : unit =
    let v2 : string = v0.l0
    let v4 : string = v2 + v1 
    v0.l0 <- v4
    ()
and method14 (v0 : char) : string =
    let v1 : string = method15()
    let v10 : Mut3 = {l0 = v1} : Mut3
    let v22 : string = $"{v0}"
    method16(v10, v22)
    let v67 : string = v10.l0
    v67
and method13 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_bright_black"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v15 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v16 : string = "String::from($0)"
    let v17 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v16 
    let _run_target_args'_v15 = v17 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v18 : string = "String::from($0)"
    let v19 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v18 
    let _run_target_args'_v15 = v19 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v20 : string = "String::from($0)"
    let v21 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v20 
    let _run_target_args'_v15 = v21 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v23 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v23 
    #endif
#if FABLE_COMPILER_PYTHON
    let v34 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v34 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v45 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v45 
    #endif
#else
    let v56 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v56 
    #endif
    let v66 : std_string_String = _run_target_args'_v15 
    let v89 : string = "fable_library_rust::String_::fromString($0)"
    let v90 : string = Fable.Core.RustInterop.emitRustExpr v66 v89 
    let _run_target_args'_v1 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "inline_colorization::color_bright_black"
    let v92 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v91 
    (* run_target_args'
    let v104 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v105 : string = "String::from($0)"
    let v106 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v105 
    let _run_target_args'_v104 = v106 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v107 : string = "String::from($0)"
    let v108 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v107 
    let _run_target_args'_v104 = v108 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v109 : string = "String::from($0)"
    let v110 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v109 
    let _run_target_args'_v104 = v110 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v112 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v112 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v134 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v134 
    #endif
#else
    let v145 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v145 
    #endif
    let v155 : std_string_String = _run_target_args'_v104 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v155 v178 
    let _run_target_args'_v1 = v179 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v180 : string = "inline_colorization::color_bright_black"
    let v181 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v180 
    (* run_target_args'
    let v193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v194 : string = "String::from($0)"
    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v194 
    let _run_target_args'_v193 = v195 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v196 : string = "String::from($0)"
    let v197 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v196 
    let _run_target_args'_v193 = v197 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v198 : string = "String::from($0)"
    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v198 
    let _run_target_args'_v193 = v199 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v201 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v201 
    #endif
#if FABLE_COMPILER_PYTHON
    let v212 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v212 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v223 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v223 
    #endif
#else
    let v234 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v234 
    #endif
    let v244 : std_string_String = _run_target_args'_v193 
    let v267 : string = "fable_library_rust::String_::fromString($0)"
    let v268 : string = Fable.Core.RustInterop.emitRustExpr v244 v267 
    let _run_target_args'_v1 = v268 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v269 : string = "\u001b[90m"
    let _run_target_args'_v1 = v269 
    #endif
#if FABLE_COMPILER_PYTHON
    let v270 : string = "\u001b[90m"
    let _run_target_args'_v1 = v270 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v271 : string = "\u001b[90m"
    let _run_target_args'_v1 = v271 
    #endif
#else
    let v272 : string = "\u001b[90m"
    let _run_target_args'_v1 = v272 
    #endif
    let v273 : string = _run_target_args'_v1 
    
    
    
    
    
    let v278 : string = "Verbose"
    let v279 : (unit -> string) = v278.ToLower
    let v280 : string = v279 ()
    let v290 : char = v280.[int 0]
    let v291 : string = method14(v290)
    let v293 : string = v273 + v291 
    (* run_target_args'
    let v304 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v305 : string = "inline_colorization::color_reset"
    let v306 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v305 
    (* run_target_args'
    let v318 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v319 : string = "String::from($0)"
    let v320 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v319 
    let _run_target_args'_v318 = v320 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v321 : string = "String::from($0)"
    let v322 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v321 
    let _run_target_args'_v318 = v322 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v323 : string = "String::from($0)"
    let v324 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v323 
    let _run_target_args'_v318 = v324 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v326 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v326 
    #endif
#if FABLE_COMPILER_PYTHON
    let v337 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v337 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v348 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v348 
    #endif
#else
    let v359 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v359 
    #endif
    let v369 : std_string_String = _run_target_args'_v318 
    let v392 : string = "fable_library_rust::String_::fromString($0)"
    let v393 : string = Fable.Core.RustInterop.emitRustExpr v369 v392 
    let _run_target_args'_v304 = v393 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v394 : string = "inline_colorization::color_reset"
    let v395 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v394 
    (* run_target_args'
    let v407 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v408 : string = "String::from($0)"
    let v409 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v408 
    let _run_target_args'_v407 = v409 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v410 : string = "String::from($0)"
    let v411 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v410 
    let _run_target_args'_v407 = v411 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v412 : string = "String::from($0)"
    let v413 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v412 
    let _run_target_args'_v407 = v413 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v415 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v415 
    #endif
#if FABLE_COMPILER_PYTHON
    let v426 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v426 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v437 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v437 
    #endif
#else
    let v448 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v448 
    #endif
    let v458 : std_string_String = _run_target_args'_v407 
    let v481 : string = "fable_library_rust::String_::fromString($0)"
    let v482 : string = Fable.Core.RustInterop.emitRustExpr v458 v481 
    let _run_target_args'_v304 = v482 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v483 : string = "inline_colorization::color_reset"
    let v484 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v483 
    (* run_target_args'
    let v496 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v497 : string = "String::from($0)"
    let v498 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v497 
    let _run_target_args'_v496 = v498 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v499 : string = "String::from($0)"
    let v500 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v499 
    let _run_target_args'_v496 = v500 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v501 : string = "String::from($0)"
    let v502 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v501 
    let _run_target_args'_v496 = v502 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v504 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v504 
    #endif
#if FABLE_COMPILER_PYTHON
    let v515 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v515 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v526 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v526 
    #endif
#else
    let v537 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v537 
    #endif
    let v547 : std_string_String = _run_target_args'_v496 
    let v570 : string = "fable_library_rust::String_::fromString($0)"
    let v571 : string = Fable.Core.RustInterop.emitRustExpr v547 v570 
    let _run_target_args'_v304 = v571 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v572 : string = "\u001b[0m"
    let _run_target_args'_v304 = v572 
    #endif
#if FABLE_COMPILER_PYTHON
    let v573 : string = "\u001b[0m"
    let _run_target_args'_v304 = v573 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v574 : string = "\u001b[0m"
    let _run_target_args'_v304 = v574 
    #endif
#else
    let v575 : string = "\u001b[0m"
    let _run_target_args'_v304 = v575 
    #endif
    let v576 : string = _run_target_args'_v304 
    let v580 : string = v293 + v576 
    v580
and method19 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "{ "
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method20 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "args"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method21 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = " = "
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method22 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = " }"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method18 (v0 : (string [])) : string =
    let v1 : string = method15()
    let v10 : Mut3 = {l0 = v1} : Mut3
    method19(v10)
    method20(v10)
    method21(v10)
    let v145 : string = $"%A{v0}"
    method16(v10, v145)
    method22(v10)
    let v242 : string = v10.l0
    v242
and method25 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 4L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v19 : US12 =
            if v3 then
                US12_0(' ')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US12_0('\t')
                else
                    let v8 : int64 = v5 - 1L
                    let v9 : bool = v8 = 0L
                    if v9 then
                        US12_0('\r')
                    else
                        let v11 : int64 = v8 - 1L
                        let v12 : bool = v11 = 0L
                        if v12 then
                            US12_0('\n')
                        else
                            let v14 : int64 = v11 - 1L
                            US12_1
        let v23 : char =
            match v19 with
            | US12_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US12_0(v20) -> (* Some *)
                v20
        let v24 : bool = v0 = v23
        if v24 then
            true
        else
            let v25 : int64 = v1 + 1L
            method25(v0, v25)
and method24 (v0 : string, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v2 >= v1
    if v3 then
        v1
    else
        let v4 : char = v0.[int v2]
        let v5 : int64 = 0L
        let v6 : bool = method25(v4, v5)
        if v6 then
            let v7 : int32 = v2 + 1
            method24(v0, v1, v7)
        else
            v2
and method27 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 2L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v11 : US12 =
            if v3 then
                US12_0(' ')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US12_0('/')
                else
                    let v8 : int64 = v5 - 1L
                    US12_1
        let v15 : char =
            match v11 with
            | US12_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US12_0(v12) -> (* Some *)
                v12
        let v16 : bool = v0 = v15
        if v16 then
            true
        else
            let v17 : int64 = v1 + 1L
            method27(v0, v17)
and method26 (v0 : string, v1 : int32) : int32 =
    let v2 : bool = v1 <= 0
    if v2 then
        0
    else
        let v3 : int32 = v1 - 1
        let v4 : char = v0.[int v3]
        let v5 : int64 = 0L
        let v6 : bool = method27(v4, v5)
        if v6 then
            method26(v0, v3)
        else
            v3
and method23 (v0 : string) : string =
    let v1 : int32 = v0.Length
    let v2 : int32 = 0
    let v3 : int32 = method24(v0, v1, v2)
    let v492 : string = v0.[int v3..int v1]
    let v503 : int32 = v492.Length
    let v504 : int32 = method26(v492, v503)
    let v993 : string = v492.[int 0..int v504]
    v993
and method17 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : (string [])) : string =
    let v9 : string = method18(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v25 : string = v14 + v7 
    let v37 : string = " #"
    let v38 : string = v25 + v37 
    let v59 : string = v10 |> _.ToString()
    let v70 : string = v38 + v59 
    let v81 : string = v70 + v13 
    let v93 : string = "spiral_wasm.main"
    let v94 : string = v81 + v93 
    let v106 : string = " / "
    let v107 : string = v94 + v106 
    let v118 : string = v107 + v9 
    method23(v118)
and closure16 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure18 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure17 () (v0 : string) : unit =
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure18(v0)
    let v22 : unit = (fun () -> v21 (); v20) ()
    ()
and closure19 (v0 : unativeint) () : int32 =
    let v1 : int32 = v0 |> int32 
    v1
and closure20 () (v0 : int32) : US13 =
    US13_0(v0)
and closure21 () (v0 : exn) : US13 =
    US13_1(v0)
and closure13 (v0 : (string [])) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure14()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US5 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v741 : US11 =
        if v116 then
            US11_1
        else
            let v147 : unit = ()
            let v148 : unit = (fun () -> v31 (); v147) ()
            let struct (v186 : Mut0, v187 : Mut1, v188 : Mut2, v189 : Mut3, v190 : Mut4, v191 : int64 option) = TraceState.trace_state.Value
            let v226 : string = method9(v186, v187, v188, v189, v190, v191)
            let v227 : string = method13()
            let v228 : string = method17(v186, v187, v188, v189, v190, v191, v226, v227, v0)
            let v258 : unit = ()
            let v259 : unit = (fun () -> v31 (); v258) ()
            let struct (v297 : Mut0, v298 : Mut1, v299 : Mut2, v300 : Mut3, v301 : Mut4, v302 : int64 option) = TraceState.trace_state.Value
            let v339 : unit = ()
            let v340 : (unit -> unit) = closure16(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure17()
            (* run_target_args'
            let v349 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v350 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v350 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v351 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v352 : string = v300.l0
            let v353 : bool = v352 = ""
            let v382 : string =
                if v353 then
                    v228
                else
                    let v354 : bool = v228 = ""
                    if v354 then
                        let v355 : string = v300.l0
                        v355
                    else
                        let v356 : string = v300.l0
                        let v359 : string = "\n"
                        let v360 : string = v356 + v359 
                        let v371 : string = v360 + v228 
                        v371
            (* run_target_args'
            let v394 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v395 : string = "&*$0"
            let v396 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v395 
            let _run_target_args'_v394 = v396 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v397 : string = "&*$0"
            let v398 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v397 
            let _run_target_args'_v394 = v398 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v399 : string = "&*$0"
            let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v399 
            let _run_target_args'_v394 = v400 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v402 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v402 
            #endif
#if FABLE_COMPILER_PYTHON
            let v413 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v413 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v424 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v424 
            #endif
#else
            let v435 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v435 
            #endif
            let v445 : Ref<Str> = _run_target_args'_v394 
            let v468 : string = $"$0.chars()"
            let v469 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v445 v468 
            let v470 : string = "$0"
            let v471 : _ = Fable.Core.RustInterop.emitRustExpr v469 v470 
            let v472 : string = "$0.collect::<Vec<_>>()"
            let v473 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v471 v472 
            let v474 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v475 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v473 v474 
            let v476 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v477 : bool = Fable.Core.RustInterop.emitRustExpr v475 v476 
            let v478 : string = "x"
            let v479 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v478 
            let v480 : string = "String::from_iter($0)"
            let v481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v479 v480 
            let v482 : string = "true; $0 }).collect::<Vec<_>>()"
            let v483 : bool = Fable.Core.RustInterop.emitRustExpr v481 v482 
            let v484 : string = "_vec_map"
            let v485 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v484 
            let v486 : string = "$0.len()"
            let v487 : unativeint = Fable.Core.RustInterop.emitRustExpr v485 v486 
            let v575 : (unit -> int32) = closure19(v487)
            let v576 : (int32 -> US13) = closure20()
            let v577 : ((unit -> exn) -> exn) = closure3()
            let v578 : (exn -> US13) = closure21()
            let v579 : US13 = try v575 () |> v576 with ex -> (fun () -> ex) |> v577 |> v578 
            let v598 : US14 =
                match v579 with
                | US13_1(v595) -> (* Error *)
                    US14_1
                | US13_0(v593) -> (* Ok *)
                    US14_0(v593)
            let v636 : int32 =
                match v598 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v633) -> (* Some *)
                    v633
            let v716 : string = ""
            let v717 : bool = v228 <> v716 
            let v728 : bool =
                if v717 then
                    let v727 : bool = v636 <= 1
                    v727
                else
                    false
            if v728 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v716
                let v729 : string = "true; $0.into_iter().for_each(|x| { //"
                let v730 : bool = Fable.Core.RustInterop.emitRustExpr v485 v729 
                let v731 : string = "x"
                let v732 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v731 
                let v733 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v734 : bool = Fable.Core.RustInterop.emitRustExpr v732 v733 
                let v735 : string = $"true"
                let v736 : bool = Fable.Core.RustInterop.emitRustExpr () v735 
                let v737 : string = "true; }); //"
                let v738 : bool = Fable.Core.RustInterop.emitRustExpr () v737 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v348 v228
            #endif
#if FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#else
            v348 v228
            #endif
            // run_target_args' is_unit
            let v739 : (string -> unit) = v298.l0
            v739 v228
            US11_0(v297, v298, v299, v300, v301, v302)
    let v773 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v773 
    ()
and method28 () : string =
    let v0 : string = "exception"
    v0
and method31 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 1L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v7 : US12 =
            if v3 then
                US12_0('\\')
            else
                let v5 : int64 = v1 - 1L
                US12_1
        let v11 : char =
            match v7 with
            | US12_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US12_0(v8) -> (* Some *)
                v8
        let v12 : bool = v0 = v11
        if v12 then
            true
        else
            let v13 : int64 = v1 + 1L
            method31(v0, v13)
and method30 (v0 : string, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v2 >= v1
    if v3 then
        v1
    else
        let v4 : char = v0.[int v2]
        let v5 : int64 = 0L
        let v6 : bool = method31(v4, v5)
        if v6 then
            let v7 : int32 = v2 + 1
            method30(v0, v1, v7)
        else
            v2
and method32 (v0 : string, v1 : int32) : int32 =
    let v2 : bool = v1 <= 0
    if v2 then
        0
    else
        let v3 : int32 = v1 - 1
        let v4 : char = v0.[int v3]
        let v5 : int64 = 0L
        let v6 : bool = method31(v4, v5)
        if v6 then
            method32(v0, v3)
        else
            v3
and closure22 () (v0 : std_string_String) : string =
    let v1 : string = "fable_library_rust::String_::fromString($0)"
    let v2 : string = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : int32 = v2.Length
    let v4 : int32 = 0
    let v5 : int32 = method30(v2, v3, v4)
    let v494 : string = v2.[int v5..int v3]
    let v505 : int32 = v494.Length
    let v506 : int32 = method32(v494, v505)
    let v995 : string = v494.[int 0..int v506]
    v995
and method29 () : (std_string_String -> string) =
    closure22()
and method34 () : string =
    let v0 : string = "wasm"
    v0
and method37 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "wasm_path"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method36 (v0 : string) : string =
    let v1 : string = method15()
    let v10 : Mut3 = {l0 = v1} : Mut3
    method19(v10)
    method37(v10)
    method21(v10)
    method16(v10, v0)
    method22(v10)
    let v230 : string = v10.l0
    v230
and method35 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method36(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v25 : string = v14 + v7 
    let v37 : string = " #"
    let v38 : string = v25 + v37 
    let v59 : string = v10 |> _.ToString()
    let v70 : string = v38 + v59 
    let v81 : string = v70 + v13 
    let v93 : string = "spiral_wasm.run"
    let v94 : string = v81 + v93 
    let v106 : string = " / "
    let v107 : string = v94 + v106 
    let v118 : string = v107 + v9 
    method23(v118)
and closure23 (v0 : string) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure14()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US5 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v741 : US11 =
        if v116 then
            US11_1
        else
            let v147 : unit = ()
            let v148 : unit = (fun () -> v31 (); v147) ()
            let struct (v186 : Mut0, v187 : Mut1, v188 : Mut2, v189 : Mut3, v190 : Mut4, v191 : int64 option) = TraceState.trace_state.Value
            let v226 : string = method9(v186, v187, v188, v189, v190, v191)
            let v227 : string = method13()
            let v228 : string = method35(v186, v187, v188, v189, v190, v191, v226, v227, v0)
            let v258 : unit = ()
            let v259 : unit = (fun () -> v31 (); v258) ()
            let struct (v297 : Mut0, v298 : Mut1, v299 : Mut2, v300 : Mut3, v301 : Mut4, v302 : int64 option) = TraceState.trace_state.Value
            let v339 : unit = ()
            let v340 : (unit -> unit) = closure16(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure17()
            (* run_target_args'
            let v349 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v350 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v350 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v351 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v352 : string = v300.l0
            let v353 : bool = v352 = ""
            let v382 : string =
                if v353 then
                    v228
                else
                    let v354 : bool = v228 = ""
                    if v354 then
                        let v355 : string = v300.l0
                        v355
                    else
                        let v356 : string = v300.l0
                        let v359 : string = "\n"
                        let v360 : string = v356 + v359 
                        let v371 : string = v360 + v228 
                        v371
            (* run_target_args'
            let v394 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v395 : string = "&*$0"
            let v396 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v395 
            let _run_target_args'_v394 = v396 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v397 : string = "&*$0"
            let v398 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v397 
            let _run_target_args'_v394 = v398 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v399 : string = "&*$0"
            let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v399 
            let _run_target_args'_v394 = v400 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v402 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v402 
            #endif
#if FABLE_COMPILER_PYTHON
            let v413 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v413 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v424 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v424 
            #endif
#else
            let v435 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v435 
            #endif
            let v445 : Ref<Str> = _run_target_args'_v394 
            let v468 : string = $"$0.chars()"
            let v469 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v445 v468 
            let v470 : string = "$0"
            let v471 : _ = Fable.Core.RustInterop.emitRustExpr v469 v470 
            let v472 : string = "$0.collect::<Vec<_>>()"
            let v473 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v471 v472 
            let v474 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v475 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v473 v474 
            let v476 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v477 : bool = Fable.Core.RustInterop.emitRustExpr v475 v476 
            let v478 : string = "x"
            let v479 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v478 
            let v480 : string = "String::from_iter($0)"
            let v481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v479 v480 
            let v482 : string = "true; $0 }).collect::<Vec<_>>()"
            let v483 : bool = Fable.Core.RustInterop.emitRustExpr v481 v482 
            let v484 : string = "_vec_map"
            let v485 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v484 
            let v486 : string = "$0.len()"
            let v487 : unativeint = Fable.Core.RustInterop.emitRustExpr v485 v486 
            let v575 : (unit -> int32) = closure19(v487)
            let v576 : (int32 -> US13) = closure20()
            let v577 : ((unit -> exn) -> exn) = closure3()
            let v578 : (exn -> US13) = closure21()
            let v579 : US13 = try v575 () |> v576 with ex -> (fun () -> ex) |> v577 |> v578 
            let v598 : US14 =
                match v579 with
                | US13_1(v595) -> (* Error *)
                    US14_1
                | US13_0(v593) -> (* Ok *)
                    US14_0(v593)
            let v636 : int32 =
                match v598 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v633) -> (* Some *)
                    v633
            let v716 : string = ""
            let v717 : bool = v228 <> v716 
            let v728 : bool =
                if v717 then
                    let v727 : bool = v636 <= 1
                    v727
                else
                    false
            if v728 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v716
                let v729 : string = "true; $0.into_iter().for_each(|x| { //"
                let v730 : bool = Fable.Core.RustInterop.emitRustExpr v485 v729 
                let v731 : string = "x"
                let v732 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v731 
                let v733 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v734 : bool = Fable.Core.RustInterop.emitRustExpr v732 v733 
                let v735 : string = $"true"
                let v736 : bool = Fable.Core.RustInterop.emitRustExpr () v735 
                let v737 : string = "true; }); //"
                let v738 : bool = Fable.Core.RustInterop.emitRustExpr () v737 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v348 v228
            #endif
#if FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#else
            v348 v228
            #endif
            // run_target_args' is_unit
            let v739 : (string -> unit) = v298.l0
            v739 v228
            US11_0(v297, v298, v299, v300, v301, v302)
    let v773 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v773 
    ()
and method42 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "retry"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method43 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "; "
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method44 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "worker"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method45 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "contract"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method41 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) : string =
    let v3 : string = method15()
    let v12 : Mut3 = {l0 = v3} : Mut3
    method19(v12)
    method42(v12)
    method21(v12)
    let v156 : string = $"{v0}"
    method16(v12, v156)
    method43(v12)
    method44(v12)
    method21(v12)
    (* run_target_args'
    let v344 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v345 : string = "format!(\"{:#?}\", $0)"
    let v346 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v345 
    let v347 : string = "fable_library_rust::String_::fromString($0)"
    let v348 : string = Fable.Core.RustInterop.emitRustExpr v346 v347 
    let _run_target_args'_v344 = v348 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v349 : string = "format!(\"{:#?}\", $0)"
    let v350 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v349 
    let v351 : string = "fable_library_rust::String_::fromString($0)"
    let v352 : string = Fable.Core.RustInterop.emitRustExpr v350 v351 
    let _run_target_args'_v344 = v352 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v353 : string = "format!(\"{:#?}\", $0)"
    let v354 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v353 
    let v355 : string = "fable_library_rust::String_::fromString($0)"
    let v356 : string = Fable.Core.RustInterop.emitRustExpr v354 v355 
    let _run_target_args'_v344 = v356 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v358 : string = $"%A{v1}"
    let _run_target_args'_v344 = v358 
    #endif
#if FABLE_COMPILER_PYTHON
    let v369 : string = $"%A{v1}"
    let _run_target_args'_v344 = v369 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v380 : string = $"%A{v1}"
    let _run_target_args'_v344 = v380 
    #endif
#else
    let v391 : string = $"%A{v1}"
    let _run_target_args'_v344 = v391 
    #endif
    let v401 : string = _run_target_args'_v344 
    method16(v12, v401)
    method43(v12)
    method45(v12)
    method21(v12)
    (* run_target_args'
    let v610 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v611 : string = "format!(\"{:#?}\", $0)"
    let v612 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v611 
    let v613 : string = "fable_library_rust::String_::fromString($0)"
    let v614 : string = Fable.Core.RustInterop.emitRustExpr v612 v613 
    let _run_target_args'_v610 = v614 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v615 : string = "format!(\"{:#?}\", $0)"
    let v616 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v615 
    let v617 : string = "fable_library_rust::String_::fromString($0)"
    let v618 : string = Fable.Core.RustInterop.emitRustExpr v616 v617 
    let _run_target_args'_v610 = v618 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v619 : string = "format!(\"{:#?}\", $0)"
    let v620 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v619 
    let v621 : string = "fable_library_rust::String_::fromString($0)"
    let v622 : string = Fable.Core.RustInterop.emitRustExpr v620 v621 
    let _run_target_args'_v610 = v622 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v624 : string = $"%A{v2}"
    let _run_target_args'_v610 = v624 
    #endif
#if FABLE_COMPILER_PYTHON
    let v635 : string = $"%A{v2}"
    let _run_target_args'_v610 = v635 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v646 : string = $"%A{v2}"
    let _run_target_args'_v610 = v646 
    #endif
#else
    let v657 : string = $"%A{v2}"
    let _run_target_args'_v610 = v657 
    #endif
    let v667 : string = _run_target_args'_v610 
    method16(v12, v667)
    method22(v12)
    let v777 : string = v12.l0
    v777
and method40 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v10 : near_workspaces_Contract) : string =
    let v11 : string = method41(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v27 : string = v16 + v7 
    let v39 : string = " #"
    let v40 : string = v27 + v39 
    let v61 : string = v12 |> _.ToString()
    let v72 : string = v40 + v61 
    let v83 : string = v72 + v15 
    let v95 : string = "spiral_wasm.run"
    let v96 : string = v83 + v95 
    let v108 : string = " / "
    let v109 : string = v96 + v108 
    let v120 : string = v109 + v11 
    method23(v120)
and closure24 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) () : unit =
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure14()
    let v34 : unit = (fun () -> v33 (); v32) ()
    let struct (v72 : Mut0, v73 : Mut1, v74 : Mut2, v75 : Mut3, v76 : Mut4, v77 : int64 option) = TraceState.trace_state.Value
    let v112 : US5 = v76.l0
    let v113 : bool = v74.l0
    let v114 : bool = v113 = false
    let v117 : bool =
        if v114 then
            false
        else
            let v115 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v112
            let v116 : bool = 0 >= v115
            v116
    let v118 : bool = v117 = false
    let v743 : US11 =
        if v118 then
            US11_1
        else
            let v149 : unit = ()
            let v150 : unit = (fun () -> v33 (); v149) ()
            let struct (v188 : Mut0, v189 : Mut1, v190 : Mut2, v191 : Mut3, v192 : Mut4, v193 : int64 option) = TraceState.trace_state.Value
            let v228 : string = method9(v188, v189, v190, v191, v192, v193)
            let v229 : string = method13()
            let v230 : string = method40(v188, v189, v190, v191, v192, v193, v228, v229, v0, v1, v2)
            let v260 : unit = ()
            let v261 : unit = (fun () -> v33 (); v260) ()
            let struct (v299 : Mut0, v300 : Mut1, v301 : Mut2, v302 : Mut3, v303 : Mut4, v304 : int64 option) = TraceState.trace_state.Value
            let v341 : unit = ()
            let v342 : (unit -> unit) = closure16(v299)
            let v343 : unit = (fun () -> v342 (); v341) ()
            let v350 : (string -> unit) = closure17()
            (* run_target_args'
            let v351 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v352 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v230 v352 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v353 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v230 v353 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v354 : string = v302.l0
            let v355 : bool = v354 = ""
            let v384 : string =
                if v355 then
                    v230
                else
                    let v356 : bool = v230 = ""
                    if v356 then
                        let v357 : string = v302.l0
                        v357
                    else
                        let v358 : string = v302.l0
                        let v361 : string = "\n"
                        let v362 : string = v358 + v361 
                        let v373 : string = v362 + v230 
                        v373
            (* run_target_args'
            let v396 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v397 : string = "&*$0"
            let v398 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v384 v397 
            let _run_target_args'_v396 = v398 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v399 : string = "&*$0"
            let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v384 v399 
            let _run_target_args'_v396 = v400 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v401 : string = "&*$0"
            let v402 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v384 v401 
            let _run_target_args'_v396 = v402 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v404 : Ref<Str> = v384 |> unbox<Ref<Str>>
            let _run_target_args'_v396 = v404 
            #endif
#if FABLE_COMPILER_PYTHON
            let v415 : Ref<Str> = v384 |> unbox<Ref<Str>>
            let _run_target_args'_v396 = v415 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v426 : Ref<Str> = v384 |> unbox<Ref<Str>>
            let _run_target_args'_v396 = v426 
            #endif
#else
            let v437 : Ref<Str> = v384 |> unbox<Ref<Str>>
            let _run_target_args'_v396 = v437 
            #endif
            let v447 : Ref<Str> = _run_target_args'_v396 
            let v470 : string = $"$0.chars()"
            let v471 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v447 v470 
            let v472 : string = "$0"
            let v473 : _ = Fable.Core.RustInterop.emitRustExpr v471 v472 
            let v474 : string = "$0.collect::<Vec<_>>()"
            let v475 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v473 v474 
            let v476 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v477 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v475 v476 
            let v478 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v479 : bool = Fable.Core.RustInterop.emitRustExpr v477 v478 
            let v480 : string = "x"
            let v481 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v480 
            let v482 : string = "String::from_iter($0)"
            let v483 : std_string_String = Fable.Core.RustInterop.emitRustExpr v481 v482 
            let v484 : string = "true; $0 }).collect::<Vec<_>>()"
            let v485 : bool = Fable.Core.RustInterop.emitRustExpr v483 v484 
            let v486 : string = "_vec_map"
            let v487 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v486 
            let v488 : string = "$0.len()"
            let v489 : unativeint = Fable.Core.RustInterop.emitRustExpr v487 v488 
            let v577 : (unit -> int32) = closure19(v489)
            let v578 : (int32 -> US13) = closure20()
            let v579 : ((unit -> exn) -> exn) = closure3()
            let v580 : (exn -> US13) = closure21()
            let v581 : US13 = try v577 () |> v578 with ex -> (fun () -> ex) |> v579 |> v580 
            let v600 : US14 =
                match v581 with
                | US13_1(v597) -> (* Error *)
                    US14_1
                | US13_0(v595) -> (* Ok *)
                    US14_0(v595)
            let v638 : int32 =
                match v600 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v635) -> (* Some *)
                    v635
            let v718 : string = ""
            let v719 : bool = v230 <> v718 
            let v730 : bool =
                if v719 then
                    let v729 : bool = v638 <= 1
                    v729
                else
                    false
            if v730 then
                v302.l0 <- v384
                ()
            else
                v302.l0 <- v718
                let v731 : string = "true; $0.into_iter().for_each(|x| { //"
                let v732 : bool = Fable.Core.RustInterop.emitRustExpr v487 v731 
                let v733 : string = "x"
                let v734 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v733 
                let v735 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v736 : bool = Fable.Core.RustInterop.emitRustExpr v734 v735 
                let v737 : string = $"true"
                let v738 : bool = Fable.Core.RustInterop.emitRustExpr () v737 
                let v739 : string = "true; }); //"
                let v740 : bool = Fable.Core.RustInterop.emitRustExpr () v739 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v350 v230
            #endif
#if FABLE_COMPILER_PYTHON
            v350 v230
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v350 v230
            #endif
#else
            v350 v230
            #endif
            // run_target_args' is_unit
            let v741 : (string -> unit) = v300.l0
            v741 v230
            US11_0(v299, v300, v301, v302, v303, v304)
    let v775 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v775 
    ()
and method48 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "result"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method47 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) : string =
    let v2 : string = method15()
    let v11 : Mut3 = {l0 = v2} : Mut3
    method19(v11)
    method42(v11)
    method21(v11)
    let v155 : string = $"{v0}"
    method16(v11, v155)
    method43(v11)
    method48(v11)
    method21(v11)
    (* run_target_args'
    let v343 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v344 : string = "format!(\"{:#?}\", $0)"
    let v345 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v344 
    let v346 : string = "fable_library_rust::String_::fromString($0)"
    let v347 : string = Fable.Core.RustInterop.emitRustExpr v345 v346 
    let _run_target_args'_v343 = v347 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v348 : string = "format!(\"{:#?}\", $0)"
    let v349 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v348 
    let v350 : string = "fable_library_rust::String_::fromString($0)"
    let v351 : string = Fable.Core.RustInterop.emitRustExpr v349 v350 
    let _run_target_args'_v343 = v351 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v352 : string = "format!(\"{:#?}\", $0)"
    let v353 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v352 
    let v354 : string = "fable_library_rust::String_::fromString($0)"
    let v355 : string = Fable.Core.RustInterop.emitRustExpr v353 v354 
    let _run_target_args'_v343 = v355 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v357 : string = $"%A{v1}"
    let _run_target_args'_v343 = v357 
    #endif
#if FABLE_COMPILER_PYTHON
    let v368 : string = $"%A{v1}"
    let _run_target_args'_v343 = v368 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v379 : string = $"%A{v1}"
    let _run_target_args'_v343 = v379 
    #endif
#else
    let v390 : string = $"%A{v1}"
    let _run_target_args'_v343 = v390 
    #endif
    let v400 : string = _run_target_args'_v343 
    method16(v11, v400)
    method22(v11)
    let v510 : string = v11.l0
    v510
and method46 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_result_ExecutionFinalResult) : string =
    let v10 : string = method47(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v26 : string = v15 + v7 
    let v38 : string = " #"
    let v39 : string = v26 + v38 
    let v60 : string = v11 |> _.ToString()
    let v71 : string = v39 + v60 
    let v82 : string = v71 + v14 
    let v94 : string = "spiral_wasm.run"
    let v95 : string = v82 + v94 
    let v107 : string = " / "
    let v108 : string = v95 + v107 
    let v119 : string = v108 + v10 
    method23(v119)
and closure25 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure14()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US5 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 0 >= v114
            v115
    let v117 : bool = v116 = false
    let v742 : US11 =
        if v117 then
            US11_1
        else
            let v148 : unit = ()
            let v149 : unit = (fun () -> v32 (); v148) ()
            let struct (v187 : Mut0, v188 : Mut1, v189 : Mut2, v190 : Mut3, v191 : Mut4, v192 : int64 option) = TraceState.trace_state.Value
            let v227 : string = method9(v187, v188, v189, v190, v191, v192)
            let v228 : string = method13()
            let v229 : string = method46(v187, v188, v189, v190, v191, v192, v227, v228, v0, v1)
            let v259 : unit = ()
            let v260 : unit = (fun () -> v32 (); v259) ()
            let struct (v298 : Mut0, v299 : Mut1, v300 : Mut2, v301 : Mut3, v302 : Mut4, v303 : int64 option) = TraceState.trace_state.Value
            let v340 : unit = ()
            let v341 : (unit -> unit) = closure16(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure17()
            (* run_target_args'
            let v350 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v351 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v352 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v352 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v353 : string = v301.l0
            let v354 : bool = v353 = ""
            let v383 : string =
                if v354 then
                    v229
                else
                    let v355 : bool = v229 = ""
                    if v355 then
                        let v356 : string = v301.l0
                        v356
                    else
                        let v357 : string = v301.l0
                        let v360 : string = "\n"
                        let v361 : string = v357 + v360 
                        let v372 : string = v361 + v229 
                        v372
            (* run_target_args'
            let v395 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v396 : string = "&*$0"
            let v397 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v396 
            let _run_target_args'_v395 = v397 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v398 : string = "&*$0"
            let v399 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v398 
            let _run_target_args'_v395 = v399 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v400 : string = "&*$0"
            let v401 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v400 
            let _run_target_args'_v395 = v401 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v403 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v403 
            #endif
#if FABLE_COMPILER_PYTHON
            let v414 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v414 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v425 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v425 
            #endif
#else
            let v436 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v436 
            #endif
            let v446 : Ref<Str> = _run_target_args'_v395 
            let v469 : string = $"$0.chars()"
            let v470 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v446 v469 
            let v471 : string = "$0"
            let v472 : _ = Fable.Core.RustInterop.emitRustExpr v470 v471 
            let v473 : string = "$0.collect::<Vec<_>>()"
            let v474 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v472 v473 
            let v475 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v476 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v474 v475 
            let v477 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v478 : bool = Fable.Core.RustInterop.emitRustExpr v476 v477 
            let v479 : string = "x"
            let v480 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v479 
            let v481 : string = "String::from_iter($0)"
            let v482 : std_string_String = Fable.Core.RustInterop.emitRustExpr v480 v481 
            let v483 : string = "true; $0 }).collect::<Vec<_>>()"
            let v484 : bool = Fable.Core.RustInterop.emitRustExpr v482 v483 
            let v485 : string = "_vec_map"
            let v486 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v485 
            let v487 : string = "$0.len()"
            let v488 : unativeint = Fable.Core.RustInterop.emitRustExpr v486 v487 
            let v576 : (unit -> int32) = closure19(v488)
            let v577 : (int32 -> US13) = closure20()
            let v578 : ((unit -> exn) -> exn) = closure3()
            let v579 : (exn -> US13) = closure21()
            let v580 : US13 = try v576 () |> v577 with ex -> (fun () -> ex) |> v578 |> v579 
            let v599 : US14 =
                match v580 with
                | US13_1(v596) -> (* Error *)
                    US14_1
                | US13_0(v594) -> (* Ok *)
                    US14_0(v594)
            let v637 : int32 =
                match v599 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v634) -> (* Some *)
                    v634
            let v717 : string = ""
            let v718 : bool = v229 <> v717 
            let v729 : bool =
                if v718 then
                    let v728 : bool = v637 <= 1
                    v728
                else
                    false
            if v729 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v717
                let v730 : string = "true; $0.into_iter().for_each(|x| { //"
                let v731 : bool = Fable.Core.RustInterop.emitRustExpr v486 v730 
                let v732 : string = "x"
                let v733 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v732 
                let v734 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v735 : bool = Fable.Core.RustInterop.emitRustExpr v733 v734 
                let v736 : string = $"true"
                let v737 : bool = Fable.Core.RustInterop.emitRustExpr () v736 
                let v738 : string = "true; }); //"
                let v739 : bool = Fable.Core.RustInterop.emitRustExpr () v738 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v349 v229
            #endif
#if FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#else
            v349 v229
            #endif
            // run_target_args' is_unit
            let v740 : (string -> unit) = v299.l0
            v740 v229
            US11_0(v298, v299, v300, v301, v302, v303)
    let v774 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v774 
    ()
and closure27 (v0 : std_string_String) () : unit =
    let v1 : (std_string_String -> unit) = System.Console.WriteLine
    v1 v0
and closure26 () (v0 : std_string_String) : unit =
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure27(v0)
    let v22 : unit = (fun () -> v21 (); v20) ()
    ()
and closure28 () () : unit =
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure14()
    let v31 : unit = (fun () -> v30 (); v29) ()
    let struct (v69 : Mut0, v70 : Mut1, v71 : Mut2, v72 : Mut3, v73 : Mut4, v74 : int64 option) = TraceState.trace_state.Value
    let v109 : US5 = v73.l0
    let v110 : bool = v71.l0
    let v111 : bool = v110 = false
    let v114 : bool =
        if v111 then
            false
        else
            let v112 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v109
            let v113 : bool = 2 >= v112
            v113
    let v115 : bool = v114 = false
    let v630 : US11 =
        if v115 then
            US11_1
        else
            let v146 : unit = ()
            let v147 : unit = (fun () -> v30 (); v146) ()
            let struct (v185 : Mut0, v186 : Mut1, v187 : Mut2, v188 : Mut3, v189 : Mut4, v190 : int64 option) = TraceState.trace_state.Value
            let v227 : unit = ()
            let v228 : (unit -> unit) = closure16(v185)
            let v229 : unit = (fun () -> v228 (); v227) ()
            let v236 : string = " "
            let v237 : (string -> unit) = closure17()
            (* run_target_args'
            let v238 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v239 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v236 v239 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v240 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v236 v240 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v241 : string = v188.l0
            let v242 : bool = v241 = ""
            let v271 : string =
                if v242 then
                    v236
                else
                    let v243 : bool = v236 = ""
                    if v243 then
                        let v244 : string = v188.l0
                        v244
                    else
                        let v245 : string = v188.l0
                        let v248 : string = "\n"
                        let v249 : string = v245 + v248 
                        let v260 : string = v249 + v236 
                        v260
            (* run_target_args'
            let v283 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v284 : string = "&*$0"
            let v285 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v271 v284 
            let _run_target_args'_v283 = v285 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v286 : string = "&*$0"
            let v287 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v271 v286 
            let _run_target_args'_v283 = v287 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v288 : string = "&*$0"
            let v289 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v271 v288 
            let _run_target_args'_v283 = v289 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v291 : Ref<Str> = v271 |> unbox<Ref<Str>>
            let _run_target_args'_v283 = v291 
            #endif
#if FABLE_COMPILER_PYTHON
            let v302 : Ref<Str> = v271 |> unbox<Ref<Str>>
            let _run_target_args'_v283 = v302 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v313 : Ref<Str> = v271 |> unbox<Ref<Str>>
            let _run_target_args'_v283 = v313 
            #endif
#else
            let v324 : Ref<Str> = v271 |> unbox<Ref<Str>>
            let _run_target_args'_v283 = v324 
            #endif
            let v334 : Ref<Str> = _run_target_args'_v283 
            let v357 : string = $"$0.chars()"
            let v358 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v334 v357 
            let v359 : string = "$0"
            let v360 : _ = Fable.Core.RustInterop.emitRustExpr v358 v359 
            let v361 : string = "$0.collect::<Vec<_>>()"
            let v362 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v360 v361 
            let v363 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v364 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v362 v363 
            let v365 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v366 : bool = Fable.Core.RustInterop.emitRustExpr v364 v365 
            let v367 : string = "x"
            let v368 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v367 
            let v369 : string = "String::from_iter($0)"
            let v370 : std_string_String = Fable.Core.RustInterop.emitRustExpr v368 v369 
            let v371 : string = "true; $0 }).collect::<Vec<_>>()"
            let v372 : bool = Fable.Core.RustInterop.emitRustExpr v370 v371 
            let v373 : string = "_vec_map"
            let v374 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v373 
            let v375 : string = "$0.len()"
            let v376 : unativeint = Fable.Core.RustInterop.emitRustExpr v374 v375 
            let v464 : (unit -> int32) = closure19(v376)
            let v465 : (int32 -> US13) = closure20()
            let v466 : ((unit -> exn) -> exn) = closure3()
            let v467 : (exn -> US13) = closure21()
            let v468 : US13 = try v464 () |> v465 with ex -> (fun () -> ex) |> v466 |> v467 
            let v487 : US14 =
                match v468 with
                | US13_1(v484) -> (* Error *)
                    US14_1
                | US13_0(v482) -> (* Ok *)
                    US14_0(v482)
            let v525 : int32 =
                match v487 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v522) -> (* Some *)
                    v522
            let v605 : string = ""
            let v606 : bool = v236 <> v605 
            let v617 : bool =
                if v606 then
                    let v616 : bool = v525 <= 1
                    v616
                else
                    false
            if v617 then
                v188.l0 <- v271
                ()
            else
                v188.l0 <- v605
                let v618 : string = "true; $0.into_iter().for_each(|x| { //"
                let v619 : bool = Fable.Core.RustInterop.emitRustExpr v374 v618 
                let v620 : string = "x"
                let v621 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v620 
                let v622 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v623 : bool = Fable.Core.RustInterop.emitRustExpr v621 v622 
                let v624 : string = $"true"
                let v625 : bool = Fable.Core.RustInterop.emitRustExpr () v624 
                let v626 : string = "true; }); //"
                let v627 : bool = Fable.Core.RustInterop.emitRustExpr () v626 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v237 v236
            #endif
#if FABLE_COMPILER_PYTHON
            v237 v236
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v237 v236
            #endif
#else
            v237 v236
            #endif
            // run_target_args' is_unit
            let v628 : (string -> unit) = v186.l0
            v628 v236
            US11_0(v185, v186, v187, v188, v189, v190)
    let v662 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v662 
    ()
and method49 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_bright_green"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v15 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v16 : string = "String::from($0)"
    let v17 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v16 
    let _run_target_args'_v15 = v17 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v18 : string = "String::from($0)"
    let v19 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v18 
    let _run_target_args'_v15 = v19 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v20 : string = "String::from($0)"
    let v21 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v20 
    let _run_target_args'_v15 = v21 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v23 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v23 
    #endif
#if FABLE_COMPILER_PYTHON
    let v34 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v34 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v45 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v45 
    #endif
#else
    let v56 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v56 
    #endif
    let v66 : std_string_String = _run_target_args'_v15 
    let v89 : string = "fable_library_rust::String_::fromString($0)"
    let v90 : string = Fable.Core.RustInterop.emitRustExpr v66 v89 
    let _run_target_args'_v1 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "inline_colorization::color_bright_green"
    let v92 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v91 
    (* run_target_args'
    let v104 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v105 : string = "String::from($0)"
    let v106 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v105 
    let _run_target_args'_v104 = v106 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v107 : string = "String::from($0)"
    let v108 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v107 
    let _run_target_args'_v104 = v108 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v109 : string = "String::from($0)"
    let v110 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v109 
    let _run_target_args'_v104 = v110 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v112 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v112 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v134 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v134 
    #endif
#else
    let v145 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v145 
    #endif
    let v155 : std_string_String = _run_target_args'_v104 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v155 v178 
    let _run_target_args'_v1 = v179 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v180 : string = "inline_colorization::color_bright_green"
    let v181 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v180 
    (* run_target_args'
    let v193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v194 : string = "String::from($0)"
    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v194 
    let _run_target_args'_v193 = v195 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v196 : string = "String::from($0)"
    let v197 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v196 
    let _run_target_args'_v193 = v197 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v198 : string = "String::from($0)"
    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v198 
    let _run_target_args'_v193 = v199 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v201 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v201 
    #endif
#if FABLE_COMPILER_PYTHON
    let v212 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v212 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v223 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v223 
    #endif
#else
    let v234 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v234 
    #endif
    let v244 : std_string_String = _run_target_args'_v193 
    let v267 : string = "fable_library_rust::String_::fromString($0)"
    let v268 : string = Fable.Core.RustInterop.emitRustExpr v244 v267 
    let _run_target_args'_v1 = v268 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v269 : string = "\u001b[92m"
    let _run_target_args'_v1 = v269 
    #endif
#if FABLE_COMPILER_PYTHON
    let v270 : string = "\u001b[92m"
    let _run_target_args'_v1 = v270 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v271 : string = "\u001b[92m"
    let _run_target_args'_v1 = v271 
    #endif
#else
    let v272 : string = "\u001b[92m"
    let _run_target_args'_v1 = v272 
    #endif
    let v273 : string = _run_target_args'_v1 
    
    
    
    
    
    let v278 : string = "Info"
    let v279 : (unit -> string) = v278.ToLower
    let v280 : string = v279 ()
    let v290 : char = v280.[int 0]
    let v291 : string = method14(v290)
    let v293 : string = v273 + v291 
    (* run_target_args'
    let v304 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v305 : string = "inline_colorization::color_reset"
    let v306 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v305 
    (* run_target_args'
    let v318 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v319 : string = "String::from($0)"
    let v320 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v319 
    let _run_target_args'_v318 = v320 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v321 : string = "String::from($0)"
    let v322 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v321 
    let _run_target_args'_v318 = v322 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v323 : string = "String::from($0)"
    let v324 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v323 
    let _run_target_args'_v318 = v324 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v326 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v326 
    #endif
#if FABLE_COMPILER_PYTHON
    let v337 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v337 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v348 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v348 
    #endif
#else
    let v359 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v359 
    #endif
    let v369 : std_string_String = _run_target_args'_v318 
    let v392 : string = "fable_library_rust::String_::fromString($0)"
    let v393 : string = Fable.Core.RustInterop.emitRustExpr v369 v392 
    let _run_target_args'_v304 = v393 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v394 : string = "inline_colorization::color_reset"
    let v395 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v394 
    (* run_target_args'
    let v407 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v408 : string = "String::from($0)"
    let v409 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v408 
    let _run_target_args'_v407 = v409 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v410 : string = "String::from($0)"
    let v411 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v410 
    let _run_target_args'_v407 = v411 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v412 : string = "String::from($0)"
    let v413 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v412 
    let _run_target_args'_v407 = v413 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v415 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v415 
    #endif
#if FABLE_COMPILER_PYTHON
    let v426 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v426 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v437 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v437 
    #endif
#else
    let v448 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v448 
    #endif
    let v458 : std_string_String = _run_target_args'_v407 
    let v481 : string = "fable_library_rust::String_::fromString($0)"
    let v482 : string = Fable.Core.RustInterop.emitRustExpr v458 v481 
    let _run_target_args'_v304 = v482 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v483 : string = "inline_colorization::color_reset"
    let v484 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v483 
    (* run_target_args'
    let v496 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v497 : string = "String::from($0)"
    let v498 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v497 
    let _run_target_args'_v496 = v498 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v499 : string = "String::from($0)"
    let v500 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v499 
    let _run_target_args'_v496 = v500 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v501 : string = "String::from($0)"
    let v502 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v501 
    let _run_target_args'_v496 = v502 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v504 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v504 
    #endif
#if FABLE_COMPILER_PYTHON
    let v515 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v515 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v526 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v526 
    #endif
#else
    let v537 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v537 
    #endif
    let v547 : std_string_String = _run_target_args'_v496 
    let v570 : string = "fable_library_rust::String_::fromString($0)"
    let v571 : string = Fable.Core.RustInterop.emitRustExpr v547 v570 
    let _run_target_args'_v304 = v571 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v572 : string = "\u001b[0m"
    let _run_target_args'_v304 = v572 
    #endif
#if FABLE_COMPILER_PYTHON
    let v573 : string = "\u001b[0m"
    let _run_target_args'_v304 = v573 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v574 : string = "\u001b[0m"
    let _run_target_args'_v304 = v574 
    #endif
#else
    let v575 : string = "\u001b[0m"
    let _run_target_args'_v304 = v575 
    #endif
    let v576 : string = _run_target_args'_v304 
    let v580 : string = v293 + v576 
    v580
and method52 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "total_gas_burnt_usd"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method53 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "total_gas_burnt"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method51 (v0 : uint8, v1 : float, v2 : uint64) : string =
    let v3 : string = method15()
    let v12 : Mut3 = {l0 = v3} : Mut3
    method19(v12)
    method42(v12)
    method21(v12)
    let v156 : string = $"{v0}"
    method16(v12, v156)
    method43(v12)
    method52(v12)
    method21(v12)
    let v344 : string = $"%+.6f{v1}"
    method16(v12, v344)
    method43(v12)
    method53(v12)
    method21(v12)
    let v532 : string = $"{v2}"
    method16(v12, v532)
    method22(v12)
    let v621 : string = v12.l0
    v621
and method50 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : float, v10 : uint64) : string =
    let v11 : string = method51(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v27 : string = v16 + v7 
    let v39 : string = " #"
    let v40 : string = v27 + v39 
    let v61 : string = v12 |> _.ToString()
    let v72 : string = v40 + v61 
    let v83 : string = v72 + v15 
    let v95 : string = "near_workspaces.print_usd"
    let v96 : string = v83 + v95 
    let v108 : string = " / "
    let v109 : string = v96 + v108 
    let v120 : string = v109 + v11 
    method23(v120)
and closure29 (v0 : uint8, v1 : uint64, v2 : float) () : unit =
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure14()
    let v34 : unit = (fun () -> v33 (); v32) ()
    let struct (v72 : Mut0, v73 : Mut1, v74 : Mut2, v75 : Mut3, v76 : Mut4, v77 : int64 option) = TraceState.trace_state.Value
    let v112 : US5 = v76.l0
    let v113 : bool = v74.l0
    let v114 : bool = v113 = false
    let v117 : bool =
        if v114 then
            false
        else
            let v115 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v112
            let v116 : bool = 2 >= v115
            v116
    let v118 : bool = v117 = false
    let v743 : US11 =
        if v118 then
            US11_1
        else
            let v149 : unit = ()
            let v150 : unit = (fun () -> v33 (); v149) ()
            let struct (v188 : Mut0, v189 : Mut1, v190 : Mut2, v191 : Mut3, v192 : Mut4, v193 : int64 option) = TraceState.trace_state.Value
            let v228 : string = method9(v188, v189, v190, v191, v192, v193)
            let v229 : string = method49()
            let v230 : string = method50(v188, v189, v190, v191, v192, v193, v228, v229, v0, v2, v1)
            let v260 : unit = ()
            let v261 : unit = (fun () -> v33 (); v260) ()
            let struct (v299 : Mut0, v300 : Mut1, v301 : Mut2, v302 : Mut3, v303 : Mut4, v304 : int64 option) = TraceState.trace_state.Value
            let v341 : unit = ()
            let v342 : (unit -> unit) = closure16(v299)
            let v343 : unit = (fun () -> v342 (); v341) ()
            let v350 : (string -> unit) = closure17()
            (* run_target_args'
            let v351 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v352 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v230 v352 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v353 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v230 v353 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v354 : string = v302.l0
            let v355 : bool = v354 = ""
            let v384 : string =
                if v355 then
                    v230
                else
                    let v356 : bool = v230 = ""
                    if v356 then
                        let v357 : string = v302.l0
                        v357
                    else
                        let v358 : string = v302.l0
                        let v361 : string = "\n"
                        let v362 : string = v358 + v361 
                        let v373 : string = v362 + v230 
                        v373
            (* run_target_args'
            let v396 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v397 : string = "&*$0"
            let v398 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v384 v397 
            let _run_target_args'_v396 = v398 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v399 : string = "&*$0"
            let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v384 v399 
            let _run_target_args'_v396 = v400 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v401 : string = "&*$0"
            let v402 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v384 v401 
            let _run_target_args'_v396 = v402 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v404 : Ref<Str> = v384 |> unbox<Ref<Str>>
            let _run_target_args'_v396 = v404 
            #endif
#if FABLE_COMPILER_PYTHON
            let v415 : Ref<Str> = v384 |> unbox<Ref<Str>>
            let _run_target_args'_v396 = v415 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v426 : Ref<Str> = v384 |> unbox<Ref<Str>>
            let _run_target_args'_v396 = v426 
            #endif
#else
            let v437 : Ref<Str> = v384 |> unbox<Ref<Str>>
            let _run_target_args'_v396 = v437 
            #endif
            let v447 : Ref<Str> = _run_target_args'_v396 
            let v470 : string = $"$0.chars()"
            let v471 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v447 v470 
            let v472 : string = "$0"
            let v473 : _ = Fable.Core.RustInterop.emitRustExpr v471 v472 
            let v474 : string = "$0.collect::<Vec<_>>()"
            let v475 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v473 v474 
            let v476 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v477 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v475 v476 
            let v478 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v479 : bool = Fable.Core.RustInterop.emitRustExpr v477 v478 
            let v480 : string = "x"
            let v481 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v480 
            let v482 : string = "String::from_iter($0)"
            let v483 : std_string_String = Fable.Core.RustInterop.emitRustExpr v481 v482 
            let v484 : string = "true; $0 }).collect::<Vec<_>>()"
            let v485 : bool = Fable.Core.RustInterop.emitRustExpr v483 v484 
            let v486 : string = "_vec_map"
            let v487 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v486 
            let v488 : string = "$0.len()"
            let v489 : unativeint = Fable.Core.RustInterop.emitRustExpr v487 v488 
            let v577 : (unit -> int32) = closure19(v489)
            let v578 : (int32 -> US13) = closure20()
            let v579 : ((unit -> exn) -> exn) = closure3()
            let v580 : (exn -> US13) = closure21()
            let v581 : US13 = try v577 () |> v578 with ex -> (fun () -> ex) |> v579 |> v580 
            let v600 : US14 =
                match v581 with
                | US13_1(v597) -> (* Error *)
                    US14_1
                | US13_0(v595) -> (* Ok *)
                    US14_0(v595)
            let v638 : int32 =
                match v600 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v635) -> (* Some *)
                    v635
            let v718 : string = ""
            let v719 : bool = v230 <> v718 
            let v730 : bool =
                if v719 then
                    let v729 : bool = v638 <= 1
                    v729
                else
                    false
            if v730 then
                v302.l0 <- v384
                ()
            else
                v302.l0 <- v718
                let v731 : string = "true; $0.into_iter().for_each(|x| { //"
                let v732 : bool = Fable.Core.RustInterop.emitRustExpr v487 v731 
                let v733 : string = "x"
                let v734 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v733 
                let v735 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v736 : bool = Fable.Core.RustInterop.emitRustExpr v734 v735 
                let v737 : string = $"true"
                let v738 : bool = Fable.Core.RustInterop.emitRustExpr () v737 
                let v739 : string = "true; }); //"
                let v740 : bool = Fable.Core.RustInterop.emitRustExpr () v739 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v350 v230
            #endif
#if FABLE_COMPILER_PYTHON
            v350 v230
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v350 v230
            #endif
#else
            v350 v230
            #endif
            // run_target_args' is_unit
            let v741 : (string -> unit) = v300.l0
            v741 v230
            US11_0(v299, v300, v301, v302, v303, v304)
    let v775 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v775 
    ()
and method56 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "is_success"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method57 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "gas_burnt_usd"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method58 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "tokens_burnt_usd"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method59 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "gas_burnt"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method60 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "tokens_burnt"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method55 (v0 : bool, v1 : float, v2 : float, v3 : uint64, v4 : u128) : string =
    let v5 : string = method15()
    let v14 : Mut3 = {l0 = v5} : Mut3
    method19(v14)
    method56(v14)
    method21(v14)
    let v149 : string =
        if v0 then
            let v147 : string = "true"
            v147
        else
            let v148 : string = "false"
            v148
    method16(v14, v149)
    method43(v14)
    method57(v14)
    method21(v14)
    let v336 : string = $"%+.6f{v1}"
    method16(v14, v336)
    method43(v14)
    method58(v14)
    method21(v14)
    let v524 : string = $"%+.6f{v2}"
    method16(v14, v524)
    method43(v14)
    method59(v14)
    method21(v14)
    let v712 : string = $"{v3}"
    method16(v14, v712)
    method43(v14)
    method60(v14)
    method21(v14)
    (* run_target_args'
    let v900 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v901 : string = "format!(\"{:#?}\", $0)"
    let v902 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v901 
    let v903 : string = "fable_library_rust::String_::fromString($0)"
    let v904 : string = Fable.Core.RustInterop.emitRustExpr v902 v903 
    let _run_target_args'_v900 = v904 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v905 : string = "format!(\"{:#?}\", $0)"
    let v906 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v905 
    let v907 : string = "fable_library_rust::String_::fromString($0)"
    let v908 : string = Fable.Core.RustInterop.emitRustExpr v906 v907 
    let _run_target_args'_v900 = v908 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v909 : string = "format!(\"{:#?}\", $0)"
    let v910 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v909 
    let v911 : string = "fable_library_rust::String_::fromString($0)"
    let v912 : string = Fable.Core.RustInterop.emitRustExpr v910 v911 
    let _run_target_args'_v900 = v912 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v914 : string = $"%A{v4}"
    let _run_target_args'_v900 = v914 
    #endif
#if FABLE_COMPILER_PYTHON
    let v925 : string = $"%A{v4}"
    let _run_target_args'_v900 = v925 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v936 : string = $"%A{v4}"
    let _run_target_args'_v900 = v936 
    #endif
#else
    let v947 : string = $"%A{v4}"
    let _run_target_args'_v900 = v947 
    #endif
    let v957 : string = _run_target_args'_v900 
    method16(v14, v957)
    method22(v14)
    let v1067 : string = v14.l0
    v1067
and method54 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : bool, v9 : float, v10 : float, v11 : uint64, v12 : u128) : string =
    let v13 : string = method55(v8, v9, v10, v11, v12)
    let v14 : int64 = v0.l0
    let v17 : string = " "
    let v18 : string = v6 + v17 
    let v29 : string = v18 + v7 
    let v41 : string = " #"
    let v42 : string = v29 + v41 
    let v63 : string = v14 |> _.ToString()
    let v74 : string = v42 + v63 
    let v85 : string = v74 + v17 
    let v97 : string = "near_workspaces.print_usd / outcome"
    let v98 : string = v85 + v97 
    let v110 : string = " / "
    let v111 : string = v98 + v110 
    let v122 : string = v111 + v13 
    method23(v122)
and closure31 (v0 : bool, v1 : uint64, v2 : float, v3 : u128, v4 : float) () : unit =
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure14()
    let v36 : unit = (fun () -> v35 (); v34) ()
    let struct (v74 : Mut0, v75 : Mut1, v76 : Mut2, v77 : Mut3, v78 : Mut4, v79 : int64 option) = TraceState.trace_state.Value
    let v114 : US5 = v78.l0
    let v115 : bool = v76.l0
    let v116 : bool = v115 = false
    let v119 : bool =
        if v116 then
            false
        else
            let v117 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v114
            let v118 : bool = 2 >= v117
            v118
    let v120 : bool = v119 = false
    let v745 : US11 =
        if v120 then
            US11_1
        else
            let v151 : unit = ()
            let v152 : unit = (fun () -> v35 (); v151) ()
            let struct (v190 : Mut0, v191 : Mut1, v192 : Mut2, v193 : Mut3, v194 : Mut4, v195 : int64 option) = TraceState.trace_state.Value
            let v230 : string = method9(v190, v191, v192, v193, v194, v195)
            let v231 : string = method49()
            let v232 : string = method54(v190, v191, v192, v193, v194, v195, v230, v231, v0, v2, v4, v1, v3)
            let v262 : unit = ()
            let v263 : unit = (fun () -> v35 (); v262) ()
            let struct (v301 : Mut0, v302 : Mut1, v303 : Mut2, v304 : Mut3, v305 : Mut4, v306 : int64 option) = TraceState.trace_state.Value
            let v343 : unit = ()
            let v344 : (unit -> unit) = closure16(v301)
            let v345 : unit = (fun () -> v344 (); v343) ()
            let v352 : (string -> unit) = closure17()
            (* run_target_args'
            let v353 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v354 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v232 v354 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v355 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v232 v355 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v356 : string = v304.l0
            let v357 : bool = v356 = ""
            let v386 : string =
                if v357 then
                    v232
                else
                    let v358 : bool = v232 = ""
                    if v358 then
                        let v359 : string = v304.l0
                        v359
                    else
                        let v360 : string = v304.l0
                        let v363 : string = "\n"
                        let v364 : string = v360 + v363 
                        let v375 : string = v364 + v232 
                        v375
            (* run_target_args'
            let v398 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v399 : string = "&*$0"
            let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v386 v399 
            let _run_target_args'_v398 = v400 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v401 : string = "&*$0"
            let v402 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v386 v401 
            let _run_target_args'_v398 = v402 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v403 : string = "&*$0"
            let v404 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v386 v403 
            let _run_target_args'_v398 = v404 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v406 : Ref<Str> = v386 |> unbox<Ref<Str>>
            let _run_target_args'_v398 = v406 
            #endif
#if FABLE_COMPILER_PYTHON
            let v417 : Ref<Str> = v386 |> unbox<Ref<Str>>
            let _run_target_args'_v398 = v417 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v428 : Ref<Str> = v386 |> unbox<Ref<Str>>
            let _run_target_args'_v398 = v428 
            #endif
#else
            let v439 : Ref<Str> = v386 |> unbox<Ref<Str>>
            let _run_target_args'_v398 = v439 
            #endif
            let v449 : Ref<Str> = _run_target_args'_v398 
            let v472 : string = $"$0.chars()"
            let v473 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v449 v472 
            let v474 : string = "$0"
            let v475 : _ = Fable.Core.RustInterop.emitRustExpr v473 v474 
            let v476 : string = "$0.collect::<Vec<_>>()"
            let v477 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v475 v476 
            let v478 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v479 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v477 v478 
            let v480 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v481 : bool = Fable.Core.RustInterop.emitRustExpr v479 v480 
            let v482 : string = "x"
            let v483 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v482 
            let v484 : string = "String::from_iter($0)"
            let v485 : std_string_String = Fable.Core.RustInterop.emitRustExpr v483 v484 
            let v486 : string = "true; $0 }).collect::<Vec<_>>()"
            let v487 : bool = Fable.Core.RustInterop.emitRustExpr v485 v486 
            let v488 : string = "_vec_map"
            let v489 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v488 
            let v490 : string = "$0.len()"
            let v491 : unativeint = Fable.Core.RustInterop.emitRustExpr v489 v490 
            let v579 : (unit -> int32) = closure19(v491)
            let v580 : (int32 -> US13) = closure20()
            let v581 : ((unit -> exn) -> exn) = closure3()
            let v582 : (exn -> US13) = closure21()
            let v583 : US13 = try v579 () |> v580 with ex -> (fun () -> ex) |> v581 |> v582 
            let v602 : US14 =
                match v583 with
                | US13_1(v599) -> (* Error *)
                    US14_1
                | US13_0(v597) -> (* Ok *)
                    US14_0(v597)
            let v640 : int32 =
                match v602 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v637) -> (* Some *)
                    v637
            let v720 : string = ""
            let v721 : bool = v232 <> v720 
            let v732 : bool =
                if v721 then
                    let v731 : bool = v640 <= 1
                    v731
                else
                    false
            if v732 then
                v304.l0 <- v386
                ()
            else
                v304.l0 <- v720
                let v733 : string = "true; $0.into_iter().for_each(|x| { //"
                let v734 : bool = Fable.Core.RustInterop.emitRustExpr v489 v733 
                let v735 : string = "x"
                let v736 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v735 
                let v737 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v738 : bool = Fable.Core.RustInterop.emitRustExpr v736 v737 
                let v739 : string = $"true"
                let v740 : bool = Fable.Core.RustInterop.emitRustExpr () v739 
                let v741 : string = "true; }); //"
                let v742 : bool = Fable.Core.RustInterop.emitRustExpr () v741 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v352 v232
            #endif
#if FABLE_COMPILER_PYTHON
            v352 v232
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v352 v232
            #endif
#else
            v352 v232
            #endif
            // run_target_args' is_unit
            let v743 : (string -> unit) = v302.l0
            v743 v232
            US11_0(v301, v302, v303, v304, v305, v306)
    let v777 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v777 
    ()
and closure30 () (v0 : near_workspaces_result_ExecutionOutcome) : unit =
    let v1 : string = "$0.is_success()"
    let v2 : bool = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : string = "$0.gas_burnt"
    let v4 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let v5 : string = "$0.as_gas()"
    let v6 : uint64 = Fable.Core.RustInterop.emitRustExpr v4 v5 
    let v8 : (uint64 -> float) = float
    let v9 : float = v8 v6
    let v19 : float = v9 / 10000000000000000.0
    let v20 : float = v19 * 6.68
    let v21 : string = "$0.tokens_burnt"
    let v22 : near_workspaces_types_NearToken = Fable.Core.RustInterop.emitRustExpr v0 v21 
    let v23 : string = "$0.as_yoctonear()"
    let v24 : u128 = Fable.Core.RustInterop.emitRustExpr v22 v23 
    let v25 : string = "$0 as f64"
    let v26 : float = Fable.Core.RustInterop.emitRustExpr v24 v25 
    let v27 : float = v26 / 1E+24
    let v28 : float = v27 * 6.68
    let v806 : unit = ()
    let v807 : (unit -> unit) = closure31(v2, v6, v20, v24, v28)
    let v808 : unit = (fun () -> v807 (); v806) ()
    ()
and method63 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "result2"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method62 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v1 : string = method15()
    let v10 : Mut3 = {l0 = v1} : Mut3
    method19(v10)
    method63(v10)
    method21(v10)
    (* run_target_args'
    let v154 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v155 : string = "format!(\"{:#?}\", $0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v155 
    let v157 : string = "fable_library_rust::String_::fromString($0)"
    let v158 : string = Fable.Core.RustInterop.emitRustExpr v156 v157 
    let _run_target_args'_v154 = v158 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v159 : string = "format!(\"{:#?}\", $0)"
    let v160 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v159 
    let v161 : string = "fable_library_rust::String_::fromString($0)"
    let v162 : string = Fable.Core.RustInterop.emitRustExpr v160 v161 
    let _run_target_args'_v154 = v162 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v163 : string = "format!(\"{:#?}\", $0)"
    let v164 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v163 
    let v165 : string = "fable_library_rust::String_::fromString($0)"
    let v166 : string = Fable.Core.RustInterop.emitRustExpr v164 v165 
    let _run_target_args'_v154 = v166 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v168 : string = $"%A{v0}"
    let _run_target_args'_v154 = v168 
    #endif
#if FABLE_COMPILER_PYTHON
    let v179 : string = $"%A{v0}"
    let _run_target_args'_v154 = v179 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v190 : string = $"%A{v0}"
    let _run_target_args'_v154 = v190 
    #endif
#else
    let v201 : string = $"%A{v0}"
    let _run_target_args'_v154 = v201 
    #endif
    let v211 : string = _run_target_args'_v154 
    method16(v10, v211)
    method22(v10)
    let v321 : string = v10.l0
    v321
and method61 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v9 : string = method62(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v25 : string = v14 + v7 
    let v37 : string = " #"
    let v38 : string = v25 + v37 
    let v59 : string = v10 |> _.ToString()
    let v70 : string = v38 + v59 
    let v81 : string = v70 + v13 
    let v93 : string = "spiral_wasm.run"
    let v94 : string = v81 + v93 
    let v106 : string = " / "
    let v107 : string = v94 + v106 
    let v118 : string = v107 + v9 
    method23(v118)
and closure32 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure14()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US5 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v741 : US11 =
        if v116 then
            US11_1
        else
            let v147 : unit = ()
            let v148 : unit = (fun () -> v31 (); v147) ()
            let struct (v186 : Mut0, v187 : Mut1, v188 : Mut2, v189 : Mut3, v190 : Mut4, v191 : int64 option) = TraceState.trace_state.Value
            let v226 : string = method9(v186, v187, v188, v189, v190, v191)
            let v227 : string = method13()
            let v228 : string = method61(v186, v187, v188, v189, v190, v191, v226, v227, v0)
            let v258 : unit = ()
            let v259 : unit = (fun () -> v31 (); v258) ()
            let struct (v297 : Mut0, v298 : Mut1, v299 : Mut2, v300 : Mut3, v301 : Mut4, v302 : int64 option) = TraceState.trace_state.Value
            let v339 : unit = ()
            let v340 : (unit -> unit) = closure16(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure17()
            (* run_target_args'
            let v349 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v350 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v350 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v351 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v352 : string = v300.l0
            let v353 : bool = v352 = ""
            let v382 : string =
                if v353 then
                    v228
                else
                    let v354 : bool = v228 = ""
                    if v354 then
                        let v355 : string = v300.l0
                        v355
                    else
                        let v356 : string = v300.l0
                        let v359 : string = "\n"
                        let v360 : string = v356 + v359 
                        let v371 : string = v360 + v228 
                        v371
            (* run_target_args'
            let v394 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v395 : string = "&*$0"
            let v396 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v395 
            let _run_target_args'_v394 = v396 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v397 : string = "&*$0"
            let v398 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v397 
            let _run_target_args'_v394 = v398 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v399 : string = "&*$0"
            let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v399 
            let _run_target_args'_v394 = v400 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v402 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v402 
            #endif
#if FABLE_COMPILER_PYTHON
            let v413 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v413 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v424 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v424 
            #endif
#else
            let v435 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v435 
            #endif
            let v445 : Ref<Str> = _run_target_args'_v394 
            let v468 : string = $"$0.chars()"
            let v469 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v445 v468 
            let v470 : string = "$0"
            let v471 : _ = Fable.Core.RustInterop.emitRustExpr v469 v470 
            let v472 : string = "$0.collect::<Vec<_>>()"
            let v473 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v471 v472 
            let v474 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v475 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v473 v474 
            let v476 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v477 : bool = Fable.Core.RustInterop.emitRustExpr v475 v476 
            let v478 : string = "x"
            let v479 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v478 
            let v480 : string = "String::from_iter($0)"
            let v481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v479 v480 
            let v482 : string = "true; $0 }).collect::<Vec<_>>()"
            let v483 : bool = Fable.Core.RustInterop.emitRustExpr v481 v482 
            let v484 : string = "_vec_map"
            let v485 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v484 
            let v486 : string = "$0.len()"
            let v487 : unativeint = Fable.Core.RustInterop.emitRustExpr v485 v486 
            let v575 : (unit -> int32) = closure19(v487)
            let v576 : (int32 -> US13) = closure20()
            let v577 : ((unit -> exn) -> exn) = closure3()
            let v578 : (exn -> US13) = closure21()
            let v579 : US13 = try v575 () |> v576 with ex -> (fun () -> ex) |> v577 |> v578 
            let v598 : US14 =
                match v579 with
                | US13_1(v595) -> (* Error *)
                    US14_1
                | US13_0(v593) -> (* Ok *)
                    US14_0(v593)
            let v636 : int32 =
                match v598 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v633) -> (* Some *)
                    v633
            let v716 : string = ""
            let v717 : bool = v228 <> v716 
            let v728 : bool =
                if v717 then
                    let v727 : bool = v636 <= 1
                    v727
                else
                    false
            if v728 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v716
                let v729 : string = "true; $0.into_iter().for_each(|x| { //"
                let v730 : bool = Fable.Core.RustInterop.emitRustExpr v485 v729 
                let v731 : string = "x"
                let v732 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v731 
                let v733 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v734 : bool = Fable.Core.RustInterop.emitRustExpr v732 v733 
                let v735 : string = $"true"
                let v736 : bool = Fable.Core.RustInterop.emitRustExpr () v735 
                let v737 : string = "true; }); //"
                let v738 : bool = Fable.Core.RustInterop.emitRustExpr () v737 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v348 v228
            #endif
#if FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#else
            v348 v228
            #endif
            // run_target_args' is_unit
            let v739 : (string -> unit) = v298.l0
            v739 v228
            US11_0(v297, v298, v299, v300, v301, v302)
    let v773 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v773 
    ()
and method64 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method67 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "receipt_failures_len"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method68 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "receipt_failures"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method66 (v0 : int32, v1 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v2 : string = method15()
    let v11 : Mut3 = {l0 = v2} : Mut3
    method19(v11)
    method67(v11)
    method21(v11)
    let v155 : string = $"{v0}"
    method16(v11, v155)
    method43(v11)
    method68(v11)
    method21(v11)
    (* run_target_args'
    let v343 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v344 : string = "format!(\"{:#?}\", $0)"
    let v345 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v344 
    let v346 : string = "fable_library_rust::String_::fromString($0)"
    let v347 : string = Fable.Core.RustInterop.emitRustExpr v345 v346 
    let _run_target_args'_v343 = v347 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v348 : string = "format!(\"{:#?}\", $0)"
    let v349 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v348 
    let v350 : string = "fable_library_rust::String_::fromString($0)"
    let v351 : string = Fable.Core.RustInterop.emitRustExpr v349 v350 
    let _run_target_args'_v343 = v351 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v352 : string = "format!(\"{:#?}\", $0)"
    let v353 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v352 
    let v354 : string = "fable_library_rust::String_::fromString($0)"
    let v355 : string = Fable.Core.RustInterop.emitRustExpr v353 v354 
    let _run_target_args'_v343 = v355 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v357 : string = $"%A{v1}"
    let _run_target_args'_v343 = v357 
    #endif
#if FABLE_COMPILER_PYTHON
    let v368 : string = $"%A{v1}"
    let _run_target_args'_v343 = v368 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v379 : string = $"%A{v1}"
    let _run_target_args'_v343 = v379 
    #endif
#else
    let v390 : string = $"%A{v1}"
    let _run_target_args'_v343 = v390 
    #endif
    let v400 : string = _run_target_args'_v343 
    method16(v11, v400)
    method22(v11)
    let v510 : string = v11.l0
    v510
and method65 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v10 : string = method66(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v26 : string = v15 + v7 
    let v38 : string = " #"
    let v39 : string = v26 + v38 
    let v60 : string = v11 |> _.ToString()
    let v71 : string = v39 + v60 
    let v82 : string = v71 + v14 
    let v94 : string = "spiral_wasm.run"
    let v95 : string = v82 + v94 
    let v107 : string = " / "
    let v108 : string = v95 + v107 
    let v119 : string = v108 + v10 
    method23(v119)
and closure33 (v0 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>, v1 : int32) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure14()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US5 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 0 >= v114
            v115
    let v117 : bool = v116 = false
    let v742 : US11 =
        if v117 then
            US11_1
        else
            let v148 : unit = ()
            let v149 : unit = (fun () -> v32 (); v148) ()
            let struct (v187 : Mut0, v188 : Mut1, v189 : Mut2, v190 : Mut3, v191 : Mut4, v192 : int64 option) = TraceState.trace_state.Value
            let v227 : string = method9(v187, v188, v189, v190, v191, v192)
            let v228 : string = method13()
            let v229 : string = method65(v187, v188, v189, v190, v191, v192, v227, v228, v1, v0)
            let v259 : unit = ()
            let v260 : unit = (fun () -> v32 (); v259) ()
            let struct (v298 : Mut0, v299 : Mut1, v300 : Mut2, v301 : Mut3, v302 : Mut4, v303 : int64 option) = TraceState.trace_state.Value
            let v340 : unit = ()
            let v341 : (unit -> unit) = closure16(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure17()
            (* run_target_args'
            let v350 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v351 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v352 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v352 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v353 : string = v301.l0
            let v354 : bool = v353 = ""
            let v383 : string =
                if v354 then
                    v229
                else
                    let v355 : bool = v229 = ""
                    if v355 then
                        let v356 : string = v301.l0
                        v356
                    else
                        let v357 : string = v301.l0
                        let v360 : string = "\n"
                        let v361 : string = v357 + v360 
                        let v372 : string = v361 + v229 
                        v372
            (* run_target_args'
            let v395 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v396 : string = "&*$0"
            let v397 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v396 
            let _run_target_args'_v395 = v397 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v398 : string = "&*$0"
            let v399 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v398 
            let _run_target_args'_v395 = v399 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v400 : string = "&*$0"
            let v401 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v400 
            let _run_target_args'_v395 = v401 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v403 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v403 
            #endif
#if FABLE_COMPILER_PYTHON
            let v414 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v414 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v425 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v425 
            #endif
#else
            let v436 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v436 
            #endif
            let v446 : Ref<Str> = _run_target_args'_v395 
            let v469 : string = $"$0.chars()"
            let v470 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v446 v469 
            let v471 : string = "$0"
            let v472 : _ = Fable.Core.RustInterop.emitRustExpr v470 v471 
            let v473 : string = "$0.collect::<Vec<_>>()"
            let v474 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v472 v473 
            let v475 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v476 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v474 v475 
            let v477 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v478 : bool = Fable.Core.RustInterop.emitRustExpr v476 v477 
            let v479 : string = "x"
            let v480 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v479 
            let v481 : string = "String::from_iter($0)"
            let v482 : std_string_String = Fable.Core.RustInterop.emitRustExpr v480 v481 
            let v483 : string = "true; $0 }).collect::<Vec<_>>()"
            let v484 : bool = Fable.Core.RustInterop.emitRustExpr v482 v483 
            let v485 : string = "_vec_map"
            let v486 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v485 
            let v487 : string = "$0.len()"
            let v488 : unativeint = Fable.Core.RustInterop.emitRustExpr v486 v487 
            let v576 : (unit -> int32) = closure19(v488)
            let v577 : (int32 -> US13) = closure20()
            let v578 : ((unit -> exn) -> exn) = closure3()
            let v579 : (exn -> US13) = closure21()
            let v580 : US13 = try v576 () |> v577 with ex -> (fun () -> ex) |> v578 |> v579 
            let v599 : US14 =
                match v580 with
                | US13_1(v596) -> (* Error *)
                    US14_1
                | US13_0(v594) -> (* Ok *)
                    US14_0(v594)
            let v637 : int32 =
                match v599 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v634) -> (* Some *)
                    v634
            let v717 : string = ""
            let v718 : bool = v229 <> v717 
            let v729 : bool =
                if v718 then
                    let v728 : bool = v637 <= 1
                    v728
                else
                    false
            if v729 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v717
                let v730 : string = "true; $0.into_iter().for_each(|x| { //"
                let v731 : bool = Fable.Core.RustInterop.emitRustExpr v486 v730 
                let v732 : string = "x"
                let v733 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v732 
                let v734 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v735 : bool = Fable.Core.RustInterop.emitRustExpr v733 v734 
                let v736 : string = $"true"
                let v737 : bool = Fable.Core.RustInterop.emitRustExpr () v736 
                let v738 : string = "true; }); //"
                let v739 : bool = Fable.Core.RustInterop.emitRustExpr () v738 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v349 v229
            #endif
#if FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#else
            v349 v229
            #endif
            // run_target_args' is_unit
            let v740 : (string -> unit) = v299.l0
            v740 v229
            US11_0(v298, v299, v300, v301, v302, v303)
    let v774 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v774 
    ()
and method69 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method72 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "receipt_outcomes_len"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method73 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "receipt_outcomes"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method71 (v0 : int32, v1 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v2 : string = method15()
    let v11 : Mut3 = {l0 = v2} : Mut3
    method19(v11)
    method72(v11)
    method21(v11)
    let v155 : string = $"{v0}"
    method16(v11, v155)
    method43(v11)
    method73(v11)
    method21(v11)
    (* run_target_args'
    let v343 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v344 : string = "format!(\"{:#?}\", $0)"
    let v345 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v344 
    let v346 : string = "fable_library_rust::String_::fromString($0)"
    let v347 : string = Fable.Core.RustInterop.emitRustExpr v345 v346 
    let _run_target_args'_v343 = v347 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v348 : string = "format!(\"{:#?}\", $0)"
    let v349 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v348 
    let v350 : string = "fable_library_rust::String_::fromString($0)"
    let v351 : string = Fable.Core.RustInterop.emitRustExpr v349 v350 
    let _run_target_args'_v343 = v351 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v352 : string = "format!(\"{:#?}\", $0)"
    let v353 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v352 
    let v354 : string = "fable_library_rust::String_::fromString($0)"
    let v355 : string = Fable.Core.RustInterop.emitRustExpr v353 v354 
    let _run_target_args'_v343 = v355 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v357 : string = $"%A{v1}"
    let _run_target_args'_v343 = v357 
    #endif
#if FABLE_COMPILER_PYTHON
    let v368 : string = $"%A{v1}"
    let _run_target_args'_v343 = v368 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v379 : string = $"%A{v1}"
    let _run_target_args'_v343 = v379 
    #endif
#else
    let v390 : string = $"%A{v1}"
    let _run_target_args'_v343 = v390 
    #endif
    let v400 : string = _run_target_args'_v343 
    method16(v11, v400)
    method22(v11)
    let v510 : string = v11.l0
    v510
and method70 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v10 : string = method71(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v26 : string = v15 + v7 
    let v38 : string = " #"
    let v39 : string = v26 + v38 
    let v60 : string = v11 |> _.ToString()
    let v71 : string = v39 + v60 
    let v82 : string = v71 + v14 
    let v94 : string = "spiral_wasm.run"
    let v95 : string = v82 + v94 
    let v107 : string = " / "
    let v108 : string = v95 + v107 
    let v119 : string = v108 + v10 
    method23(v119)
and closure34 (v0 : Vec<near_workspaces_result_ExecutionOutcome>, v1 : int32) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure14()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US5 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 0 >= v114
            v115
    let v117 : bool = v116 = false
    let v742 : US11 =
        if v117 then
            US11_1
        else
            let v148 : unit = ()
            let v149 : unit = (fun () -> v32 (); v148) ()
            let struct (v187 : Mut0, v188 : Mut1, v189 : Mut2, v190 : Mut3, v191 : Mut4, v192 : int64 option) = TraceState.trace_state.Value
            let v227 : string = method9(v187, v188, v189, v190, v191, v192)
            let v228 : string = method13()
            let v229 : string = method70(v187, v188, v189, v190, v191, v192, v227, v228, v1, v0)
            let v259 : unit = ()
            let v260 : unit = (fun () -> v32 (); v259) ()
            let struct (v298 : Mut0, v299 : Mut1, v300 : Mut2, v301 : Mut3, v302 : Mut4, v303 : int64 option) = TraceState.trace_state.Value
            let v340 : unit = ()
            let v341 : (unit -> unit) = closure16(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure17()
            (* run_target_args'
            let v350 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v351 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v352 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v352 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v353 : string = v301.l0
            let v354 : bool = v353 = ""
            let v383 : string =
                if v354 then
                    v229
                else
                    let v355 : bool = v229 = ""
                    if v355 then
                        let v356 : string = v301.l0
                        v356
                    else
                        let v357 : string = v301.l0
                        let v360 : string = "\n"
                        let v361 : string = v357 + v360 
                        let v372 : string = v361 + v229 
                        v372
            (* run_target_args'
            let v395 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v396 : string = "&*$0"
            let v397 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v396 
            let _run_target_args'_v395 = v397 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v398 : string = "&*$0"
            let v399 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v398 
            let _run_target_args'_v395 = v399 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v400 : string = "&*$0"
            let v401 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v400 
            let _run_target_args'_v395 = v401 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v403 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v403 
            #endif
#if FABLE_COMPILER_PYTHON
            let v414 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v414 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v425 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v425 
            #endif
#else
            let v436 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v436 
            #endif
            let v446 : Ref<Str> = _run_target_args'_v395 
            let v469 : string = $"$0.chars()"
            let v470 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v446 v469 
            let v471 : string = "$0"
            let v472 : _ = Fable.Core.RustInterop.emitRustExpr v470 v471 
            let v473 : string = "$0.collect::<Vec<_>>()"
            let v474 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v472 v473 
            let v475 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v476 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v474 v475 
            let v477 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v478 : bool = Fable.Core.RustInterop.emitRustExpr v476 v477 
            let v479 : string = "x"
            let v480 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v479 
            let v481 : string = "String::from_iter($0)"
            let v482 : std_string_String = Fable.Core.RustInterop.emitRustExpr v480 v481 
            let v483 : string = "true; $0 }).collect::<Vec<_>>()"
            let v484 : bool = Fable.Core.RustInterop.emitRustExpr v482 v483 
            let v485 : string = "_vec_map"
            let v486 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v485 
            let v487 : string = "$0.len()"
            let v488 : unativeint = Fable.Core.RustInterop.emitRustExpr v486 v487 
            let v576 : (unit -> int32) = closure19(v488)
            let v577 : (int32 -> US13) = closure20()
            let v578 : ((unit -> exn) -> exn) = closure3()
            let v579 : (exn -> US13) = closure21()
            let v580 : US13 = try v576 () |> v577 with ex -> (fun () -> ex) |> v578 |> v579 
            let v599 : US14 =
                match v580 with
                | US13_1(v596) -> (* Error *)
                    US14_1
                | US13_0(v594) -> (* Ok *)
                    US14_0(v594)
            let v637 : int32 =
                match v599 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v634) -> (* Some *)
                    v634
            let v717 : string = ""
            let v718 : bool = v229 <> v717 
            let v729 : bool =
                if v718 then
                    let v728 : bool = v637 <= 1
                    v728
                else
                    false
            if v729 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v717
                let v730 : string = "true; $0.into_iter().for_each(|x| { //"
                let v731 : bool = Fable.Core.RustInterop.emitRustExpr v486 v730 
                let v732 : string = "x"
                let v733 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v732 
                let v734 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v735 : bool = Fable.Core.RustInterop.emitRustExpr v733 v734 
                let v736 : string = $"true"
                let v737 : bool = Fable.Core.RustInterop.emitRustExpr () v736 
                let v738 : string = "true; }); //"
                let v739 : bool = Fable.Core.RustInterop.emitRustExpr () v738 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v349 v229
            #endif
#if FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#else
            v349 v229
            #endif
            // run_target_args' is_unit
            let v740 : (string -> unit) = v299.l0
            v740 v229
            US11_0(v298, v299, v300, v301, v302, v303)
    let v774 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v774 
    ()
and method76 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "json"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method75 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method15()
    let v10 : Mut3 = {l0 = v1} : Mut3
    method19(v10)
    method76(v10)
    method21(v10)
    (* run_target_args'
    let v154 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v155 : string = "format!(\"{:#?}\", $0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v155 
    let v157 : string = "fable_library_rust::String_::fromString($0)"
    let v158 : string = Fable.Core.RustInterop.emitRustExpr v156 v157 
    let _run_target_args'_v154 = v158 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v159 : string = "format!(\"{:#?}\", $0)"
    let v160 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v159 
    let v161 : string = "fable_library_rust::String_::fromString($0)"
    let v162 : string = Fable.Core.RustInterop.emitRustExpr v160 v161 
    let _run_target_args'_v154 = v162 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v163 : string = "format!(\"{:#?}\", $0)"
    let v164 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v163 
    let v165 : string = "fable_library_rust::String_::fromString($0)"
    let v166 : string = Fable.Core.RustInterop.emitRustExpr v164 v165 
    let _run_target_args'_v154 = v166 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v168 : string = $"%A{v0}"
    let _run_target_args'_v154 = v168 
    #endif
#if FABLE_COMPILER_PYTHON
    let v179 : string = $"%A{v0}"
    let _run_target_args'_v154 = v179 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v190 : string = $"%A{v0}"
    let _run_target_args'_v154 = v190 
    #endif
#else
    let v201 : string = $"%A{v0}"
    let _run_target_args'_v154 = v201 
    #endif
    let v211 : string = _run_target_args'_v154 
    method16(v10, v211)
    method22(v10)
    let v321 : string = v10.l0
    v321
and method74 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method75(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v25 : string = v14 + v7 
    let v37 : string = " #"
    let v38 : string = v25 + v37 
    let v59 : string = v10 |> _.ToString()
    let v70 : string = v38 + v59 
    let v81 : string = v70 + v13 
    let v93 : string = "spiral_wasm.run"
    let v94 : string = v81 + v93 
    let v106 : string = " / "
    let v107 : string = v94 + v106 
    let v118 : string = v107 + v9 
    method23(v118)
and closure35 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure14()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US5 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v741 : US11 =
        if v116 then
            US11_1
        else
            let v147 : unit = ()
            let v148 : unit = (fun () -> v31 (); v147) ()
            let struct (v186 : Mut0, v187 : Mut1, v188 : Mut2, v189 : Mut3, v190 : Mut4, v191 : int64 option) = TraceState.trace_state.Value
            let v226 : string = method9(v186, v187, v188, v189, v190, v191)
            let v227 : string = method13()
            let v228 : string = method74(v186, v187, v188, v189, v190, v191, v226, v227, v0)
            let v258 : unit = ()
            let v259 : unit = (fun () -> v31 (); v258) ()
            let struct (v297 : Mut0, v298 : Mut1, v299 : Mut2, v300 : Mut3, v301 : Mut4, v302 : int64 option) = TraceState.trace_state.Value
            let v339 : unit = ()
            let v340 : (unit -> unit) = closure16(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure17()
            (* run_target_args'
            let v349 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v350 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v350 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v351 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v352 : string = v300.l0
            let v353 : bool = v352 = ""
            let v382 : string =
                if v353 then
                    v228
                else
                    let v354 : bool = v228 = ""
                    if v354 then
                        let v355 : string = v300.l0
                        v355
                    else
                        let v356 : string = v300.l0
                        let v359 : string = "\n"
                        let v360 : string = v356 + v359 
                        let v371 : string = v360 + v228 
                        v371
            (* run_target_args'
            let v394 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v395 : string = "&*$0"
            let v396 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v395 
            let _run_target_args'_v394 = v396 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v397 : string = "&*$0"
            let v398 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v397 
            let _run_target_args'_v394 = v398 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v399 : string = "&*$0"
            let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v399 
            let _run_target_args'_v394 = v400 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v402 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v402 
            #endif
#if FABLE_COMPILER_PYTHON
            let v413 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v413 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v424 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v424 
            #endif
#else
            let v435 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v435 
            #endif
            let v445 : Ref<Str> = _run_target_args'_v394 
            let v468 : string = $"$0.chars()"
            let v469 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v445 v468 
            let v470 : string = "$0"
            let v471 : _ = Fable.Core.RustInterop.emitRustExpr v469 v470 
            let v472 : string = "$0.collect::<Vec<_>>()"
            let v473 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v471 v472 
            let v474 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v475 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v473 v474 
            let v476 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v477 : bool = Fable.Core.RustInterop.emitRustExpr v475 v476 
            let v478 : string = "x"
            let v479 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v478 
            let v480 : string = "String::from_iter($0)"
            let v481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v479 v480 
            let v482 : string = "true; $0 }).collect::<Vec<_>>()"
            let v483 : bool = Fable.Core.RustInterop.emitRustExpr v481 v482 
            let v484 : string = "_vec_map"
            let v485 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v484 
            let v486 : string = "$0.len()"
            let v487 : unativeint = Fable.Core.RustInterop.emitRustExpr v485 v486 
            let v575 : (unit -> int32) = closure19(v487)
            let v576 : (int32 -> US13) = closure20()
            let v577 : ((unit -> exn) -> exn) = closure3()
            let v578 : (exn -> US13) = closure21()
            let v579 : US13 = try v575 () |> v576 with ex -> (fun () -> ex) |> v577 |> v578 
            let v598 : US14 =
                match v579 with
                | US13_1(v595) -> (* Error *)
                    US14_1
                | US13_0(v593) -> (* Ok *)
                    US14_0(v593)
            let v636 : int32 =
                match v598 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v633) -> (* Some *)
                    v633
            let v716 : string = ""
            let v717 : bool = v228 <> v716 
            let v728 : bool =
                if v717 then
                    let v727 : bool = v636 <= 1
                    v727
                else
                    false
            if v728 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v716
                let v729 : string = "true; $0.into_iter().for_each(|x| { //"
                let v730 : bool = Fable.Core.RustInterop.emitRustExpr v485 v729 
                let v731 : string = "x"
                let v732 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v731 
                let v733 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v734 : bool = Fable.Core.RustInterop.emitRustExpr v732 v733 
                let v735 : string = $"true"
                let v736 : bool = Fable.Core.RustInterop.emitRustExpr () v735 
                let v737 : string = "true; }); //"
                let v738 : bool = Fable.Core.RustInterop.emitRustExpr () v737 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v348 v228
            #endif
#if FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#else
            v348 v228
            #endif
            // run_target_args' is_unit
            let v739 : (string -> unit) = v298.l0
            v739 v228
            US11_0(v297, v298, v299, v300, v301, v302)
    let v773 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v773 
    ()
and method79 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "borsh"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method78 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method15()
    let v10 : Mut3 = {l0 = v1} : Mut3
    method19(v10)
    method79(v10)
    method21(v10)
    (* run_target_args'
    let v154 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v155 : string = "format!(\"{:#?}\", $0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v155 
    let v157 : string = "fable_library_rust::String_::fromString($0)"
    let v158 : string = Fable.Core.RustInterop.emitRustExpr v156 v157 
    let _run_target_args'_v154 = v158 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v159 : string = "format!(\"{:#?}\", $0)"
    let v160 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v159 
    let v161 : string = "fable_library_rust::String_::fromString($0)"
    let v162 : string = Fable.Core.RustInterop.emitRustExpr v160 v161 
    let _run_target_args'_v154 = v162 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v163 : string = "format!(\"{:#?}\", $0)"
    let v164 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v163 
    let v165 : string = "fable_library_rust::String_::fromString($0)"
    let v166 : string = Fable.Core.RustInterop.emitRustExpr v164 v165 
    let _run_target_args'_v154 = v166 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v168 : string = $"%A{v0}"
    let _run_target_args'_v154 = v168 
    #endif
#if FABLE_COMPILER_PYTHON
    let v179 : string = $"%A{v0}"
    let _run_target_args'_v154 = v179 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v190 : string = $"%A{v0}"
    let _run_target_args'_v154 = v190 
    #endif
#else
    let v201 : string = $"%A{v0}"
    let _run_target_args'_v154 = v201 
    #endif
    let v211 : string = _run_target_args'_v154 
    method16(v10, v211)
    method22(v10)
    let v321 : string = v10.l0
    v321
and method77 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method78(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v25 : string = v14 + v7 
    let v37 : string = " #"
    let v38 : string = v25 + v37 
    let v59 : string = v10 |> _.ToString()
    let v70 : string = v38 + v59 
    let v81 : string = v70 + v13 
    let v93 : string = "spiral_wasm.run"
    let v94 : string = v81 + v93 
    let v106 : string = " / "
    let v107 : string = v94 + v106 
    let v118 : string = v107 + v9 
    method23(v118)
and closure36 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure14()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US5 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v741 : US11 =
        if v116 then
            US11_1
        else
            let v147 : unit = ()
            let v148 : unit = (fun () -> v31 (); v147) ()
            let struct (v186 : Mut0, v187 : Mut1, v188 : Mut2, v189 : Mut3, v190 : Mut4, v191 : int64 option) = TraceState.trace_state.Value
            let v226 : string = method9(v186, v187, v188, v189, v190, v191)
            let v227 : string = method13()
            let v228 : string = method77(v186, v187, v188, v189, v190, v191, v226, v227, v0)
            let v258 : unit = ()
            let v259 : unit = (fun () -> v31 (); v258) ()
            let struct (v297 : Mut0, v298 : Mut1, v299 : Mut2, v300 : Mut3, v301 : Mut4, v302 : int64 option) = TraceState.trace_state.Value
            let v339 : unit = ()
            let v340 : (unit -> unit) = closure16(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure17()
            (* run_target_args'
            let v349 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v350 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v350 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v351 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v352 : string = v300.l0
            let v353 : bool = v352 = ""
            let v382 : string =
                if v353 then
                    v228
                else
                    let v354 : bool = v228 = ""
                    if v354 then
                        let v355 : string = v300.l0
                        v355
                    else
                        let v356 : string = v300.l0
                        let v359 : string = "\n"
                        let v360 : string = v356 + v359 
                        let v371 : string = v360 + v228 
                        v371
            (* run_target_args'
            let v394 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v395 : string = "&*$0"
            let v396 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v395 
            let _run_target_args'_v394 = v396 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v397 : string = "&*$0"
            let v398 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v397 
            let _run_target_args'_v394 = v398 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v399 : string = "&*$0"
            let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v399 
            let _run_target_args'_v394 = v400 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v402 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v402 
            #endif
#if FABLE_COMPILER_PYTHON
            let v413 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v413 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v424 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v424 
            #endif
#else
            let v435 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v435 
            #endif
            let v445 : Ref<Str> = _run_target_args'_v394 
            let v468 : string = $"$0.chars()"
            let v469 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v445 v468 
            let v470 : string = "$0"
            let v471 : _ = Fable.Core.RustInterop.emitRustExpr v469 v470 
            let v472 : string = "$0.collect::<Vec<_>>()"
            let v473 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v471 v472 
            let v474 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v475 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v473 v474 
            let v476 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v477 : bool = Fable.Core.RustInterop.emitRustExpr v475 v476 
            let v478 : string = "x"
            let v479 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v478 
            let v480 : string = "String::from_iter($0)"
            let v481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v479 v480 
            let v482 : string = "true; $0 }).collect::<Vec<_>>()"
            let v483 : bool = Fable.Core.RustInterop.emitRustExpr v481 v482 
            let v484 : string = "_vec_map"
            let v485 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v484 
            let v486 : string = "$0.len()"
            let v487 : unativeint = Fable.Core.RustInterop.emitRustExpr v485 v486 
            let v575 : (unit -> int32) = closure19(v487)
            let v576 : (int32 -> US13) = closure20()
            let v577 : ((unit -> exn) -> exn) = closure3()
            let v578 : (exn -> US13) = closure21()
            let v579 : US13 = try v575 () |> v576 with ex -> (fun () -> ex) |> v577 |> v578 
            let v598 : US14 =
                match v579 with
                | US13_1(v595) -> (* Error *)
                    US14_1
                | US13_0(v593) -> (* Ok *)
                    US14_0(v593)
            let v636 : int32 =
                match v598 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v633) -> (* Some *)
                    v633
            let v716 : string = ""
            let v717 : bool = v228 <> v716 
            let v728 : bool =
                if v717 then
                    let v727 : bool = v636 <= 1
                    v727
                else
                    false
            if v728 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v716
                let v729 : string = "true; $0.into_iter().for_each(|x| { //"
                let v730 : bool = Fable.Core.RustInterop.emitRustExpr v485 v729 
                let v731 : string = "x"
                let v732 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v731 
                let v733 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v734 : bool = Fable.Core.RustInterop.emitRustExpr v732 v733 
                let v735 : string = $"true"
                let v736 : bool = Fable.Core.RustInterop.emitRustExpr () v735 
                let v737 : string = "true; }); //"
                let v738 : bool = Fable.Core.RustInterop.emitRustExpr () v737 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v348 v228
            #endif
#if FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#else
            v348 v228
            #endif
            // run_target_args' is_unit
            let v739 : (string -> unit) = v298.l0
            v739 v228
            US11_0(v297, v298, v299, v300, v301, v302)
    let v773 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v773 
    ()
and method80 (v0 : int32, v1 : uint8, v2 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v3 : string = method15()
    let v12 : Mut3 = {l0 = v3} : Mut3
    method19(v12)
    method72(v12)
    method21(v12)
    let v156 : string = $"{v0}"
    method16(v12, v156)
    method43(v12)
    method42(v12)
    method21(v12)
    let v344 : string = $"{v1}"
    method16(v12, v344)
    method43(v12)
    method68(v12)
    method21(v12)
    (* run_target_args'
    let v532 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v533 : string = "format!(\"{:#?}\", $0)"
    let v534 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v533 
    let v535 : string = "fable_library_rust::String_::fromString($0)"
    let v536 : string = Fable.Core.RustInterop.emitRustExpr v534 v535 
    let _run_target_args'_v532 = v536 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v537 : string = "format!(\"{:#?}\", $0)"
    let v538 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v537 
    let v539 : string = "fable_library_rust::String_::fromString($0)"
    let v540 : string = Fable.Core.RustInterop.emitRustExpr v538 v539 
    let _run_target_args'_v532 = v540 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v541 : string = "format!(\"{:#?}\", $0)"
    let v542 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v541 
    let v543 : string = "fable_library_rust::String_::fromString($0)"
    let v544 : string = Fable.Core.RustInterop.emitRustExpr v542 v543 
    let _run_target_args'_v532 = v544 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v546 : string = $"%A{v2}"
    let _run_target_args'_v532 = v546 
    #endif
#if FABLE_COMPILER_PYTHON
    let v557 : string = $"%A{v2}"
    let _run_target_args'_v532 = v557 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v568 : string = $"%A{v2}"
    let _run_target_args'_v532 = v568 
    #endif
#else
    let v579 : string = $"%A{v2}"
    let _run_target_args'_v532 = v579 
    #endif
    let v589 : string = _run_target_args'_v532 
    method16(v12, v589)
    method22(v12)
    let v699 : string = v12.l0
    v699
and method39 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<Result<US9, anyhow_Error>>>>> =
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
    let v797 : unit = ()
    let v798 : (unit -> unit) = closure24(v1, v11, v19)
    let v799 : unit = (fun () -> v798 (); v797) ()
    let v1584 : string = "$0.call(&*$1)"
    let v1585 : string = "state_main"
    let v1586 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr struct (v19, v1585) v1584 
    let v1587 : string = "near_workspaces::types::Gas::from_tgas(300)"
    let v1588 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr () v1587 
    let v1589 : string = "v1586.gas(v1588)"
    let v1590 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr () v1589 
    let v1591 : string = "Box::pin(v1590.transact())"
    let v1592 : std_pin_Pin<Box<Dyn<std_future_Future<Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v1591 
    let v1593 : string = "v1592.await"
    let v1594 : Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v1593 
    let v1595 : string = "$0?"
    let v1596 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v1594 v1595 
    let v2374 : unit = ()
    let v2375 : (unit -> unit) = closure25(v1, v1596)
    let v2376 : unit = (fun () -> v2375 (); v2374) ()
    let v3161 : string = "v1596.logs()"
    let v3162 : Vec<Ref<Str>> = Fable.Core.RustInterop.emitRustExpr () v3161 
    let v3163 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v3164 : bool = Fable.Core.RustInterop.emitRustExpr v3162 v3163 
    let v3165 : string = "x"
    let v3166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3165 
    (* run_target_args'
    let v3178 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3179 : string = "String::from($0)"
    let v3180 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3166 v3179 
    let _run_target_args'_v3178 = v3180 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3181 : string = "String::from($0)"
    let v3182 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3166 v3181 
    let _run_target_args'_v3178 = v3182 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3183 : string = "String::from($0)"
    let v3184 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3166 v3183 
    let _run_target_args'_v3178 = v3184 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3186 : std_string_String = v3166 |> unbox<std_string_String>
    let _run_target_args'_v3178 = v3186 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3197 : std_string_String = v3166 |> unbox<std_string_String>
    let _run_target_args'_v3178 = v3197 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3208 : std_string_String = v3166 |> unbox<std_string_String>
    let _run_target_args'_v3178 = v3208 
    #endif
#else
    let v3219 : std_string_String = v3166 |> unbox<std_string_String>
    let _run_target_args'_v3178 = v3219 
    #endif
    let v3229 : std_string_String = _run_target_args'_v3178 
    let v3252 : string = "true; $0 }).collect::<Vec<_>>()"
    let v3253 : bool = Fable.Core.RustInterop.emitRustExpr v3229 v3252 
    let v3254 : string = "_vec_map"
    let v3255 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v3254 
    let v3256 : string = "true; $0.iter().for_each(|x| { $1(x.clone()); }); //"
    let v3257 : (std_string_String -> unit) = closure26()
    let v3258 : bool = Fable.Core.RustInterop.emitRustExpr struct (v3255, v3257) v3256 
    let v3927 : unit = ()
    let v3928 : (unit -> unit) = closure28()
    let v3929 : unit = (fun () -> v3928 (); v3927) ()
    let v4604 : string = "$0.total_gas_burnt"
    let v4605 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v1596 v4604 
    let v4606 : string = "$0.as_gas()"
    let v4607 : uint64 = Fable.Core.RustInterop.emitRustExpr v4605 v4606 
    let v4609 : (uint64 -> float) = float
    let v4610 : float = v4609 v4607
    let v4620 : float = v4610 / 10000000000000000.0
    let v4621 : float = v4620 * 6.68
    let v5399 : unit = ()
    let v5400 : (unit -> unit) = closure29(v1, v4607, v4621)
    let v5401 : unit = (fun () -> v5400 (); v5399) ()
    let v6186 : string = "$0"
    let v6187 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v1596 v6186 
    let v6188 : string = "v6187.outcomes()"
    let v6189 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v6188 
    let v6190 : string = "v6189.into_iter()"
    let v6191 : _ = Fable.Core.RustInterop.emitRustExpr () v6190 
    let v6192 : string = "v6191.cloned()"
    let v6193 : _ = Fable.Core.RustInterop.emitRustExpr () v6192 
    let v6194 : string = "true; v6193.for_each(|x| $0(x))"
    let v6195 : (near_workspaces_result_ExecutionOutcome -> unit) = closure30()
    let v6196 : bool = Fable.Core.RustInterop.emitRustExpr v6195 v6194 
    let v6197 : string = "$0.into_result()"
    let v6198 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure> = Fable.Core.RustInterop.emitRustExpr v1596 v6197 
    let v6976 : unit = ()
    let v6977 : (unit -> unit) = closure32(v6198)
    let v6978 : unit = (fun () -> v6977 (); v6976) ()
    let v7763 : near_workspaces_result_ExecutionFinalResult = method64(v1596)
    let v7764 : string = "v7763.receipt_failures()"
    let v7765 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v7764 
    let v7766 : string = "$0.len()"
    let v7767 : unativeint = Fable.Core.RustInterop.emitRustExpr v7765 v7766 
    let v7855 : (unit -> int32) = closure19(v7767)
    let v7856 : (int32 -> US13) = closure20()
    let v7857 : ((unit -> exn) -> exn) = closure3()
    let v7858 : (exn -> US13) = closure21()
    let v7859 : US13 = try v7855 () |> v7856 with ex -> (fun () -> ex) |> v7857 |> v7858 
    let v7878 : US14 =
        match v7859 with
        | US13_1(v7875) -> (* Error *)
            US14_1
        | US13_0(v7873) -> (* Ok *)
            US14_0(v7873)
    let v7916 : int32 =
        match v7878 with
        | US14_1 -> (* None *)
            failwith<int32> "Option does not have a value."
        | US14_0(v7913) -> (* Some *)
            v7913
    let v8762 : unit = ()
    let v8763 : (unit -> unit) = closure33(v7765, v7916)
    let v8764 : unit = (fun () -> v8763 (); v8762) ()
    let v9540 : near_workspaces_result_ExecutionFinalResult = method69(v1596)
    let v9541 : string = "v9540.receipt_outcomes()"
    let v9542 : Ref<Slice<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v9541 
    let v9543 : string = "v9542.into()"
    let v9544 : Vec<near_workspaces_result_ExecutionOutcome> = Fable.Core.RustInterop.emitRustExpr () v9543 
    let v9545 : string = "$0.len()"
    let v9546 : unativeint = Fable.Core.RustInterop.emitRustExpr v9544 v9545 
    let v9628 : (unit -> int32) = closure19(v9546)
    let v9629 : US13 = try v9628 () |> v7856 with ex -> (fun () -> ex) |> v7857 |> v7858 
    let v9648 : US14 =
        match v9629 with
        | US13_1(v9645) -> (* Error *)
            US14_1
        | US13_0(v9643) -> (* Ok *)
            US14_0(v9643)
    let v9686 : int32 =
        match v9648 with
        | US14_1 -> (* None *)
            failwith<int32> "Option does not have a value."
        | US14_0(v9683) -> (* Some *)
            v9683
    let v10532 : unit = ()
    let v10533 : (unit -> unit) = closure34(v9544, v9686)
    let v10534 : unit = (fun () -> v10533 (); v10532) ()
    let v11310 : string = "$0.json()"
    let v11311 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v1596 v11310 
    let v12080 : unit = ()
    let v12081 : (unit -> unit) = closure35(v11311)
    let v12082 : unit = (fun () -> v12081 (); v12080) ()
    let v12858 : string = "$0.borsh()"
    let v12859 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v1596 v12858 
    let v13628 : unit = ()
    let v13629 : (unit -> unit) = closure36(v12859)
    let v13630 : unit = (fun () -> v13629 (); v13628) ()
    let v14406 : string = method80(v9686, v1, v7765)
    let v14407 : bool = v7916 > 0
    let v14455 : Result<US9, anyhow_Error> =
        if v14407 then
            let v14410 : US9 = US9_0(v14406)
            let v14411 : Result<US9, anyhow_Error> = Ok v14410 
            v14411
        else
            let v14422 : bool = v9686 > 1
            if v14422 then
                let v14425 : US9 = US9_1
                let v14426 : Result<US9, anyhow_Error> = Ok v14425 
                v14426
            else
                let v14437 : string = "anyhow::anyhow!($0)"
                let v14438 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v14406 v14437 
                (* run_target_args'
                let v14440 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v14441 : string = "Err($0)"
                let v14442 : Result<US9, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v14438 v14441 
                let _run_target_args'_v14440 = v14442 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v14443 : string = "Err($0)"
                let v14444 : Result<US9, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v14438 v14443 
                let _run_target_args'_v14440 = v14444 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v14445 : string = "Err($0)"
                let v14446 : Result<US9, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v14438 v14445 
                let _run_target_args'_v14440 = v14446 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v14447 : Result<US9, anyhow_Error> = v14438 |> Error
                let _run_target_args'_v14440 = v14447 
                #endif
#if FABLE_COMPILER_PYTHON
                let v14448 : Result<US9, anyhow_Error> = v14438 |> Error
                let _run_target_args'_v14440 = v14448 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v14449 : Result<US9, anyhow_Error> = v14438 |> Error
                let _run_target_args'_v14440 = v14449 
                #endif
#else
                let v14450 : Result<US9, anyhow_Error> = v14438 |> Error
                let _run_target_args'_v14440 = v14450 
                #endif
                let v14451 : Result<US9, anyhow_Error> = _run_target_args'_v14440 
                v14451
    let v14456 : string = ""
    let v14457 : string = "}"
    let v14458 : string = v14456 + v14457 
    let x = v14455 //
    let v14459 : _ = x
    let v14460 : unit = ()
    (* run_target_args'
    let v14461 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14462 : string = $"true; let _fix_closure_v14460 = $0"
    let v14463 : bool = Fable.Core.RustInterop.emitRustExpr v14459 v14462 
    let _run_target_args'_v14461 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v14464 : string = $"true; let _fix_closure_v14460 = $0"
    let v14465 : bool = Fable.Core.RustInterop.emitRustExpr v14459 v14464 
    let _run_target_args'_v14461 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v14466 : string = $"true; let _fix_closure_v14460 = $0"
    let v14467 : bool = Fable.Core.RustInterop.emitRustExpr v14459 v14466 
    let _run_target_args'_v14461 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v14461 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v14461 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v14461 = false 
    #endif
#else
    let _run_target_args'_v14461 = false 
    #endif
    let v14468 : bool = _run_target_args'_v14461 
    let v14469 : string = $"true; _fix_closure_v14460 " + v14458 + "); " + v14456 + " // rust.fix_closure'"
    let v14470 : bool = Fable.Core.RustInterop.emitRustExpr () v14469 
    let v14471 : string = "__future_init"
    let v14472 : _ = Fable.Core.RustInterop.emitRustExpr () v14471 
    let v14473 : string = "v14472"
    let v14474 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US9, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v14473 
    v14474
and closure37 () (v0 : anyhow_Error) : std_string_String =
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "format!(\"{}\", $0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v13 
    let _run_target_args'_v12 = v14 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v15 : string = "format!(\"{}\", $0)"
    let v16 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v15 
    let _run_target_args'_v12 = v16 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v17 : string = "format!(\"{}\", $0)"
    let v18 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v17 
    let _run_target_args'_v12 = v18 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v12 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v31 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v12 = v31 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v42 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v12 = v42 
    #endif
#else
    let v53 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v12 = v53 
    #endif
    let v63 : std_string_String = _run_target_args'_v12 
    v63
and method81 () : (anyhow_Error -> std_string_String) =
    closure37()
and closure38 () (v0 : US9) : US16 =
    US16_0(v0)
and method82 () : (US9 -> US16) =
    closure38()
and closure39 () (v0 : std_string_String) : US16 =
    US16_1(v0)
and method83 () : (std_string_String -> US16) =
    closure39()
and method84 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_yellow"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v15 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v16 : string = "String::from($0)"
    let v17 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v16 
    let _run_target_args'_v15 = v17 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v18 : string = "String::from($0)"
    let v19 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v18 
    let _run_target_args'_v15 = v19 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v20 : string = "String::from($0)"
    let v21 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v20 
    let _run_target_args'_v15 = v21 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v23 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v23 
    #endif
#if FABLE_COMPILER_PYTHON
    let v34 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v34 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v45 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v45 
    #endif
#else
    let v56 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v56 
    #endif
    let v66 : std_string_String = _run_target_args'_v15 
    let v89 : string = "fable_library_rust::String_::fromString($0)"
    let v90 : string = Fable.Core.RustInterop.emitRustExpr v66 v89 
    let _run_target_args'_v1 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "inline_colorization::color_yellow"
    let v92 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v91 
    (* run_target_args'
    let v104 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v105 : string = "String::from($0)"
    let v106 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v105 
    let _run_target_args'_v104 = v106 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v107 : string = "String::from($0)"
    let v108 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v107 
    let _run_target_args'_v104 = v108 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v109 : string = "String::from($0)"
    let v110 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v109 
    let _run_target_args'_v104 = v110 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v112 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v112 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v134 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v134 
    #endif
#else
    let v145 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v145 
    #endif
    let v155 : std_string_String = _run_target_args'_v104 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v155 v178 
    let _run_target_args'_v1 = v179 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v180 : string = "inline_colorization::color_yellow"
    let v181 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v180 
    (* run_target_args'
    let v193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v194 : string = "String::from($0)"
    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v194 
    let _run_target_args'_v193 = v195 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v196 : string = "String::from($0)"
    let v197 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v196 
    let _run_target_args'_v193 = v197 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v198 : string = "String::from($0)"
    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v198 
    let _run_target_args'_v193 = v199 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v201 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v201 
    #endif
#if FABLE_COMPILER_PYTHON
    let v212 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v212 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v223 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v223 
    #endif
#else
    let v234 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v234 
    #endif
    let v244 : std_string_String = _run_target_args'_v193 
    let v267 : string = "fable_library_rust::String_::fromString($0)"
    let v268 : string = Fable.Core.RustInterop.emitRustExpr v244 v267 
    let _run_target_args'_v1 = v268 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v269 : string = "\u001b[93m"
    let _run_target_args'_v1 = v269 
    #endif
#if FABLE_COMPILER_PYTHON
    let v270 : string = "\u001b[93m"
    let _run_target_args'_v1 = v270 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v271 : string = "\u001b[93m"
    let _run_target_args'_v1 = v271 
    #endif
#else
    let v272 : string = "\u001b[93m"
    let _run_target_args'_v1 = v272 
    #endif
    let v273 : string = _run_target_args'_v1 
    
    
    
    
    
    let v278 : string = "Warning"
    let v279 : (unit -> string) = v278.ToLower
    let v280 : string = v279 ()
    let v290 : char = v280.[int 0]
    let v291 : string = method14(v290)
    let v293 : string = v273 + v291 
    (* run_target_args'
    let v304 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v305 : string = "inline_colorization::color_reset"
    let v306 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v305 
    (* run_target_args'
    let v318 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v319 : string = "String::from($0)"
    let v320 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v319 
    let _run_target_args'_v318 = v320 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v321 : string = "String::from($0)"
    let v322 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v321 
    let _run_target_args'_v318 = v322 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v323 : string = "String::from($0)"
    let v324 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v323 
    let _run_target_args'_v318 = v324 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v326 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v326 
    #endif
#if FABLE_COMPILER_PYTHON
    let v337 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v337 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v348 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v348 
    #endif
#else
    let v359 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v359 
    #endif
    let v369 : std_string_String = _run_target_args'_v318 
    let v392 : string = "fable_library_rust::String_::fromString($0)"
    let v393 : string = Fable.Core.RustInterop.emitRustExpr v369 v392 
    let _run_target_args'_v304 = v393 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v394 : string = "inline_colorization::color_reset"
    let v395 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v394 
    (* run_target_args'
    let v407 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v408 : string = "String::from($0)"
    let v409 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v408 
    let _run_target_args'_v407 = v409 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v410 : string = "String::from($0)"
    let v411 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v410 
    let _run_target_args'_v407 = v411 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v412 : string = "String::from($0)"
    let v413 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v412 
    let _run_target_args'_v407 = v413 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v415 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v415 
    #endif
#if FABLE_COMPILER_PYTHON
    let v426 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v426 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v437 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v437 
    #endif
#else
    let v448 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v448 
    #endif
    let v458 : std_string_String = _run_target_args'_v407 
    let v481 : string = "fable_library_rust::String_::fromString($0)"
    let v482 : string = Fable.Core.RustInterop.emitRustExpr v458 v481 
    let _run_target_args'_v304 = v482 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v483 : string = "inline_colorization::color_reset"
    let v484 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v483 
    (* run_target_args'
    let v496 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v497 : string = "String::from($0)"
    let v498 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v497 
    let _run_target_args'_v496 = v498 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v499 : string = "String::from($0)"
    let v500 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v499 
    let _run_target_args'_v496 = v500 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v501 : string = "String::from($0)"
    let v502 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v501 
    let _run_target_args'_v496 = v502 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v504 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v504 
    #endif
#if FABLE_COMPILER_PYTHON
    let v515 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v515 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v526 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v526 
    #endif
#else
    let v537 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v537 
    #endif
    let v547 : std_string_String = _run_target_args'_v496 
    let v570 : string = "fable_library_rust::String_::fromString($0)"
    let v571 : string = Fable.Core.RustInterop.emitRustExpr v547 v570 
    let _run_target_args'_v304 = v571 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v572 : string = "\u001b[0m"
    let _run_target_args'_v304 = v572 
    #endif
#if FABLE_COMPILER_PYTHON
    let v573 : string = "\u001b[0m"
    let _run_target_args'_v304 = v573 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v574 : string = "\u001b[0m"
    let _run_target_args'_v304 = v574 
    #endif
#else
    let v575 : string = "\u001b[0m"
    let _run_target_args'_v304 = v575 
    #endif
    let v576 : string = _run_target_args'_v304 
    let v580 : string = v293 + v576 
    v580
and method87 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "error"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method86 (v0 : uint8, v1 : std_string_String) : string =
    let v2 : string = method15()
    let v11 : Mut3 = {l0 = v2} : Mut3
    method19(v11)
    method42(v11)
    method21(v11)
    let v155 : string = $"{v0}"
    method16(v11, v155)
    method43(v11)
    method87(v11)
    method21(v11)
    (* run_target_args'
    let v343 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v344 : string = "format!(\"{:#?}\", $0)"
    let v345 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v344 
    let v346 : string = "fable_library_rust::String_::fromString($0)"
    let v347 : string = Fable.Core.RustInterop.emitRustExpr v345 v346 
    let _run_target_args'_v343 = v347 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v348 : string = "format!(\"{:#?}\", $0)"
    let v349 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v348 
    let v350 : string = "fable_library_rust::String_::fromString($0)"
    let v351 : string = Fable.Core.RustInterop.emitRustExpr v349 v350 
    let _run_target_args'_v343 = v351 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v352 : string = "format!(\"{:#?}\", $0)"
    let v353 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v352 
    let v354 : string = "fable_library_rust::String_::fromString($0)"
    let v355 : string = Fable.Core.RustInterop.emitRustExpr v353 v354 
    let _run_target_args'_v343 = v355 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v357 : string = $"%A{v1}"
    let _run_target_args'_v343 = v357 
    #endif
#if FABLE_COMPILER_PYTHON
    let v368 : string = $"%A{v1}"
    let _run_target_args'_v343 = v368 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v379 : string = $"%A{v1}"
    let _run_target_args'_v343 = v379 
    #endif
#else
    let v390 : string = $"%A{v1}"
    let _run_target_args'_v343 = v390 
    #endif
    let v400 : string = _run_target_args'_v343 
    method16(v11, v400)
    method22(v11)
    let v510 : string = v11.l0
    v510
and method85 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : std_string_String) : string =
    let v10 : string = method86(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v26 : string = v15 + v7 
    let v38 : string = " #"
    let v39 : string = v26 + v38 
    let v60 : string = v11 |> _.ToString()
    let v71 : string = v39 + v60 
    let v82 : string = v71 + v14 
    let v94 : string = "spiral_wasm.run / Error error"
    let v95 : string = v82 + v94 
    let v107 : string = " / "
    let v108 : string = v95 + v107 
    let v119 : string = v108 + v10 
    method23(v119)
and closure40 (v0 : uint8, v1 : std_string_String) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure14()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US5 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 3 >= v114
            v115
    let v117 : bool = v116 = false
    let v742 : US11 =
        if v117 then
            US11_1
        else
            let v148 : unit = ()
            let v149 : unit = (fun () -> v32 (); v148) ()
            let struct (v187 : Mut0, v188 : Mut1, v189 : Mut2, v190 : Mut3, v191 : Mut4, v192 : int64 option) = TraceState.trace_state.Value
            let v227 : string = method9(v187, v188, v189, v190, v191, v192)
            let v228 : string = method84()
            let v229 : string = method85(v187, v188, v189, v190, v191, v192, v227, v228, v0, v1)
            let v259 : unit = ()
            let v260 : unit = (fun () -> v32 (); v259) ()
            let struct (v298 : Mut0, v299 : Mut1, v300 : Mut2, v301 : Mut3, v302 : Mut4, v303 : int64 option) = TraceState.trace_state.Value
            let v340 : unit = ()
            let v341 : (unit -> unit) = closure16(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure17()
            (* run_target_args'
            let v350 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v351 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v352 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v352 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v353 : string = v301.l0
            let v354 : bool = v353 = ""
            let v383 : string =
                if v354 then
                    v229
                else
                    let v355 : bool = v229 = ""
                    if v355 then
                        let v356 : string = v301.l0
                        v356
                    else
                        let v357 : string = v301.l0
                        let v360 : string = "\n"
                        let v361 : string = v357 + v360 
                        let v372 : string = v361 + v229 
                        v372
            (* run_target_args'
            let v395 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v396 : string = "&*$0"
            let v397 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v396 
            let _run_target_args'_v395 = v397 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v398 : string = "&*$0"
            let v399 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v398 
            let _run_target_args'_v395 = v399 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v400 : string = "&*$0"
            let v401 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v400 
            let _run_target_args'_v395 = v401 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v403 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v403 
            #endif
#if FABLE_COMPILER_PYTHON
            let v414 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v414 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v425 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v425 
            #endif
#else
            let v436 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v436 
            #endif
            let v446 : Ref<Str> = _run_target_args'_v395 
            let v469 : string = $"$0.chars()"
            let v470 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v446 v469 
            let v471 : string = "$0"
            let v472 : _ = Fable.Core.RustInterop.emitRustExpr v470 v471 
            let v473 : string = "$0.collect::<Vec<_>>()"
            let v474 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v472 v473 
            let v475 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v476 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v474 v475 
            let v477 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v478 : bool = Fable.Core.RustInterop.emitRustExpr v476 v477 
            let v479 : string = "x"
            let v480 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v479 
            let v481 : string = "String::from_iter($0)"
            let v482 : std_string_String = Fable.Core.RustInterop.emitRustExpr v480 v481 
            let v483 : string = "true; $0 }).collect::<Vec<_>>()"
            let v484 : bool = Fable.Core.RustInterop.emitRustExpr v482 v483 
            let v485 : string = "_vec_map"
            let v486 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v485 
            let v487 : string = "$0.len()"
            let v488 : unativeint = Fable.Core.RustInterop.emitRustExpr v486 v487 
            let v576 : (unit -> int32) = closure19(v488)
            let v577 : (int32 -> US13) = closure20()
            let v578 : ((unit -> exn) -> exn) = closure3()
            let v579 : (exn -> US13) = closure21()
            let v580 : US13 = try v576 () |> v577 with ex -> (fun () -> ex) |> v578 |> v579 
            let v599 : US14 =
                match v580 with
                | US13_1(v596) -> (* Error *)
                    US14_1
                | US13_0(v594) -> (* Ok *)
                    US14_0(v594)
            let v637 : int32 =
                match v599 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v634) -> (* Some *)
                    v634
            let v717 : string = ""
            let v718 : bool = v229 <> v717 
            let v729 : bool =
                if v718 then
                    let v728 : bool = v637 <= 1
                    v728
                else
                    false
            if v729 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v717
                let v730 : string = "true; $0.into_iter().for_each(|x| { //"
                let v731 : bool = Fable.Core.RustInterop.emitRustExpr v486 v730 
                let v732 : string = "x"
                let v733 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v732 
                let v734 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v735 : bool = Fable.Core.RustInterop.emitRustExpr v733 v734 
                let v736 : string = $"true"
                let v737 : bool = Fable.Core.RustInterop.emitRustExpr () v736 
                let v738 : string = "true; }); //"
                let v739 : bool = Fable.Core.RustInterop.emitRustExpr () v738 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v349 v229
            #endif
#if FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#else
            v349 v229
            #endif
            // run_target_args' is_unit
            let v740 : (string -> unit) = v299.l0
            v740 v229
            US11_0(v298, v299, v300, v301, v302, v303)
    let v774 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v774 
    ()
and closure41 () () : unit =
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure14()
    let v31 : unit = (fun () -> v30 (); v29) ()
    let struct (v69 : Mut0, v70 : Mut1, v71 : Mut2, v72 : Mut3, v73 : Mut4, v74 : int64 option) = TraceState.trace_state.Value
    let v109 : US5 = v73.l0
    let v110 : bool = v71.l0
    let v111 : bool = v110 = false
    let v114 : bool =
        if v111 then
            false
        else
            let v112 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v109
            let v113 : bool = 3 >= v112
            v113
    let v115 : bool = v114 = false
    let v628 : US11 =
        if v115 then
            US11_1
        else
            let v146 : unit = ()
            let v147 : unit = (fun () -> v30 (); v146) ()
            let struct (v185 : Mut0, v186 : Mut1, v187 : Mut2, v188 : Mut3, v189 : Mut4, v190 : int64 option) = TraceState.trace_state.Value
            let v227 : unit = ()
            let v228 : (unit -> unit) = closure16(v185)
            let v229 : unit = (fun () -> v228 (); v227) ()
            let v236 : string = "\n"
            let v237 : (string -> unit) = closure17()
            (* run_target_args'
            let v238 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v239 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v236 v239 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v240 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v236 v240 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v241 : string = v188.l0
            let v242 : bool = v241 = ""
            let v269 : string =
                if v242 then
                    v236
                else
                    let v243 : bool = v236 = ""
                    if v243 then
                        let v244 : string = v188.l0
                        v244
                    else
                        let v245 : string = v188.l0
                        let v247 : string = v245 + v236 
                        let v258 : string = v247 + v236 
                        v258
            (* run_target_args'
            let v281 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v282 : string = "&*$0"
            let v283 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v269 v282 
            let _run_target_args'_v281 = v283 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v284 : string = "&*$0"
            let v285 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v269 v284 
            let _run_target_args'_v281 = v285 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v286 : string = "&*$0"
            let v287 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v269 v286 
            let _run_target_args'_v281 = v287 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v289 : Ref<Str> = v269 |> unbox<Ref<Str>>
            let _run_target_args'_v281 = v289 
            #endif
#if FABLE_COMPILER_PYTHON
            let v300 : Ref<Str> = v269 |> unbox<Ref<Str>>
            let _run_target_args'_v281 = v300 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v311 : Ref<Str> = v269 |> unbox<Ref<Str>>
            let _run_target_args'_v281 = v311 
            #endif
#else
            let v322 : Ref<Str> = v269 |> unbox<Ref<Str>>
            let _run_target_args'_v281 = v322 
            #endif
            let v332 : Ref<Str> = _run_target_args'_v281 
            let v355 : string = $"$0.chars()"
            let v356 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v332 v355 
            let v357 : string = "$0"
            let v358 : _ = Fable.Core.RustInterop.emitRustExpr v356 v357 
            let v359 : string = "$0.collect::<Vec<_>>()"
            let v360 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v358 v359 
            let v361 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v362 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v360 v361 
            let v363 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v364 : bool = Fable.Core.RustInterop.emitRustExpr v362 v363 
            let v365 : string = "x"
            let v366 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v365 
            let v367 : string = "String::from_iter($0)"
            let v368 : std_string_String = Fable.Core.RustInterop.emitRustExpr v366 v367 
            let v369 : string = "true; $0 }).collect::<Vec<_>>()"
            let v370 : bool = Fable.Core.RustInterop.emitRustExpr v368 v369 
            let v371 : string = "_vec_map"
            let v372 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v371 
            let v373 : string = "$0.len()"
            let v374 : unativeint = Fable.Core.RustInterop.emitRustExpr v372 v373 
            let v462 : (unit -> int32) = closure19(v374)
            let v463 : (int32 -> US13) = closure20()
            let v464 : ((unit -> exn) -> exn) = closure3()
            let v465 : (exn -> US13) = closure21()
            let v466 : US13 = try v462 () |> v463 with ex -> (fun () -> ex) |> v464 |> v465 
            let v485 : US14 =
                match v466 with
                | US13_1(v482) -> (* Error *)
                    US14_1
                | US13_0(v480) -> (* Ok *)
                    US14_0(v480)
            let v523 : int32 =
                match v485 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v520) -> (* Some *)
                    v520
            let v603 : string = ""
            let v604 : bool = v236 <> v603 
            let v615 : bool =
                if v604 then
                    let v614 : bool = v523 <= 1
                    v614
                else
                    false
            if v615 then
                v188.l0 <- v269
                ()
            else
                v188.l0 <- v603
                let v616 : string = "true; $0.into_iter().for_each(|x| { //"
                let v617 : bool = Fable.Core.RustInterop.emitRustExpr v372 v616 
                let v618 : string = "x"
                let v619 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v618 
                let v620 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v621 : bool = Fable.Core.RustInterop.emitRustExpr v619 v620 
                let v622 : string = $"true"
                let v623 : bool = Fable.Core.RustInterop.emitRustExpr () v622 
                let v624 : string = "true; }); //"
                let v625 : bool = Fable.Core.RustInterop.emitRustExpr () v624 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v237 v236
            #endif
#if FABLE_COMPILER_PYTHON
            v237 v236
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v237 v236
            #endif
#else
            v237 v236
            #endif
            // run_target_args' is_unit
            let v626 : (string -> unit) = v186.l0
            v626 v236
            US11_0(v185, v186, v187, v188, v189, v190)
    let v660 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v660 
    ()
and closure42 (v0 : uint8, v1 : std_string_String) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure14()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US5 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 3 >= v114
            v115
    let v117 : bool = v116 = false
    let v742 : US11 =
        if v117 then
            US11_1
        else
            let v148 : unit = ()
            let v149 : unit = (fun () -> v32 (); v148) ()
            let struct (v187 : Mut0, v188 : Mut1, v189 : Mut2, v190 : Mut3, v191 : Mut4, v192 : int64 option) = TraceState.trace_state.Value
            let v227 : string = method9(v187, v188, v189, v190, v191, v192)
            let v228 : string = method84()
            let v229 : string = method85(v187, v188, v189, v190, v191, v192, v227, v228, v0, v1)
            let v259 : unit = ()
            let v260 : unit = (fun () -> v32 (); v259) ()
            let struct (v298 : Mut0, v299 : Mut1, v300 : Mut2, v301 : Mut3, v302 : Mut4, v303 : int64 option) = TraceState.trace_state.Value
            let v340 : unit = ()
            let v341 : (unit -> unit) = closure16(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure17()
            (* run_target_args'
            let v350 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v351 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v352 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v352 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v353 : string = v301.l0
            let v354 : bool = v353 = ""
            let v383 : string =
                if v354 then
                    v229
                else
                    let v355 : bool = v229 = ""
                    if v355 then
                        let v356 : string = v301.l0
                        v356
                    else
                        let v357 : string = v301.l0
                        let v360 : string = "\n"
                        let v361 : string = v357 + v360 
                        let v372 : string = v361 + v229 
                        v372
            (* run_target_args'
            let v395 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v396 : string = "&*$0"
            let v397 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v396 
            let _run_target_args'_v395 = v397 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v398 : string = "&*$0"
            let v399 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v398 
            let _run_target_args'_v395 = v399 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v400 : string = "&*$0"
            let v401 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v400 
            let _run_target_args'_v395 = v401 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v403 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v403 
            #endif
#if FABLE_COMPILER_PYTHON
            let v414 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v414 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v425 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v425 
            #endif
#else
            let v436 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v436 
            #endif
            let v446 : Ref<Str> = _run_target_args'_v395 
            let v469 : string = $"$0.chars()"
            let v470 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v446 v469 
            let v471 : string = "$0"
            let v472 : _ = Fable.Core.RustInterop.emitRustExpr v470 v471 
            let v473 : string = "$0.collect::<Vec<_>>()"
            let v474 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v472 v473 
            let v475 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v476 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v474 v475 
            let v477 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v478 : bool = Fable.Core.RustInterop.emitRustExpr v476 v477 
            let v479 : string = "x"
            let v480 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v479 
            let v481 : string = "String::from_iter($0)"
            let v482 : std_string_String = Fable.Core.RustInterop.emitRustExpr v480 v481 
            let v483 : string = "true; $0 }).collect::<Vec<_>>()"
            let v484 : bool = Fable.Core.RustInterop.emitRustExpr v482 v483 
            let v485 : string = "_vec_map"
            let v486 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v485 
            let v487 : string = "$0.len()"
            let v488 : unativeint = Fable.Core.RustInterop.emitRustExpr v486 v487 
            let v576 : (unit -> int32) = closure19(v488)
            let v577 : (int32 -> US13) = closure20()
            let v578 : ((unit -> exn) -> exn) = closure3()
            let v579 : (exn -> US13) = closure21()
            let v580 : US13 = try v576 () |> v577 with ex -> (fun () -> ex) |> v578 |> v579 
            let v599 : US14 =
                match v580 with
                | US13_1(v596) -> (* Error *)
                    US14_1
                | US13_0(v594) -> (* Ok *)
                    US14_0(v594)
            let v637 : int32 =
                match v599 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v634) -> (* Some *)
                    v634
            let v717 : string = ""
            let v718 : bool = v229 <> v717 
            let v729 : bool =
                if v718 then
                    let v728 : bool = v637 <= 1
                    v728
                else
                    false
            if v729 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v717
                let v730 : string = "true; $0.into_iter().for_each(|x| { //"
                let v731 : bool = Fable.Core.RustInterop.emitRustExpr v486 v730 
                let v732 : string = "x"
                let v733 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v732 
                let v734 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v735 : bool = Fable.Core.RustInterop.emitRustExpr v733 v734 
                let v736 : string = $"true"
                let v737 : bool = Fable.Core.RustInterop.emitRustExpr () v736 
                let v738 : string = "true; }); //"
                let v739 : bool = Fable.Core.RustInterop.emitRustExpr () v738 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v349 v229
            #endif
#if FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#else
            v349 v229
            #endif
            // run_target_args' is_unit
            let v740 : (string -> unit) = v299.l0
            v740 v229
            US11_0(v298, v299, v300, v301, v302, v303)
    let v774 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v774 
    ()
and closure43 () () : unit =
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure14()
    let v31 : unit = (fun () -> v30 (); v29) ()
    let struct (v69 : Mut0, v70 : Mut1, v71 : Mut2, v72 : Mut3, v73 : Mut4, v74 : int64 option) = TraceState.trace_state.Value
    let v109 : US5 = v73.l0
    let v110 : bool = v71.l0
    let v111 : bool = v110 = false
    let v114 : bool =
        if v111 then
            false
        else
            let v112 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v109
            let v113 : bool = 3 >= v112
            v113
    let v115 : bool = v114 = false
    let v628 : US11 =
        if v115 then
            US11_1
        else
            let v146 : unit = ()
            let v147 : unit = (fun () -> v30 (); v146) ()
            let struct (v185 : Mut0, v186 : Mut1, v187 : Mut2, v188 : Mut3, v189 : Mut4, v190 : int64 option) = TraceState.trace_state.Value
            let v227 : unit = ()
            let v228 : (unit -> unit) = closure16(v185)
            let v229 : unit = (fun () -> v228 (); v227) ()
            let v236 : string = "\n"
            let v237 : (string -> unit) = closure17()
            (* run_target_args'
            let v238 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v239 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v236 v239 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v240 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v236 v240 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v241 : string = v188.l0
            let v242 : bool = v241 = ""
            let v269 : string =
                if v242 then
                    v236
                else
                    let v243 : bool = v236 = ""
                    if v243 then
                        let v244 : string = v188.l0
                        v244
                    else
                        let v245 : string = v188.l0
                        let v247 : string = v245 + v236 
                        let v258 : string = v247 + v236 
                        v258
            (* run_target_args'
            let v281 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v282 : string = "&*$0"
            let v283 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v269 v282 
            let _run_target_args'_v281 = v283 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v284 : string = "&*$0"
            let v285 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v269 v284 
            let _run_target_args'_v281 = v285 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v286 : string = "&*$0"
            let v287 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v269 v286 
            let _run_target_args'_v281 = v287 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v289 : Ref<Str> = v269 |> unbox<Ref<Str>>
            let _run_target_args'_v281 = v289 
            #endif
#if FABLE_COMPILER_PYTHON
            let v300 : Ref<Str> = v269 |> unbox<Ref<Str>>
            let _run_target_args'_v281 = v300 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v311 : Ref<Str> = v269 |> unbox<Ref<Str>>
            let _run_target_args'_v281 = v311 
            #endif
#else
            let v322 : Ref<Str> = v269 |> unbox<Ref<Str>>
            let _run_target_args'_v281 = v322 
            #endif
            let v332 : Ref<Str> = _run_target_args'_v281 
            let v355 : string = $"$0.chars()"
            let v356 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v332 v355 
            let v357 : string = "$0"
            let v358 : _ = Fable.Core.RustInterop.emitRustExpr v356 v357 
            let v359 : string = "$0.collect::<Vec<_>>()"
            let v360 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v358 v359 
            let v361 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v362 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v360 v361 
            let v363 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v364 : bool = Fable.Core.RustInterop.emitRustExpr v362 v363 
            let v365 : string = "x"
            let v366 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v365 
            let v367 : string = "String::from_iter($0)"
            let v368 : std_string_String = Fable.Core.RustInterop.emitRustExpr v366 v367 
            let v369 : string = "true; $0 }).collect::<Vec<_>>()"
            let v370 : bool = Fable.Core.RustInterop.emitRustExpr v368 v369 
            let v371 : string = "_vec_map"
            let v372 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v371 
            let v373 : string = "$0.len()"
            let v374 : unativeint = Fable.Core.RustInterop.emitRustExpr v372 v373 
            let v462 : (unit -> int32) = closure19(v374)
            let v463 : (int32 -> US13) = closure20()
            let v464 : ((unit -> exn) -> exn) = closure3()
            let v465 : (exn -> US13) = closure21()
            let v466 : US13 = try v462 () |> v463 with ex -> (fun () -> ex) |> v464 |> v465 
            let v485 : US14 =
                match v466 with
                | US13_1(v482) -> (* Error *)
                    US14_1
                | US13_0(v480) -> (* Ok *)
                    US14_0(v480)
            let v523 : int32 =
                match v485 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v520) -> (* Some *)
                    v520
            let v603 : string = ""
            let v604 : bool = v236 <> v603 
            let v615 : bool =
                if v604 then
                    let v614 : bool = v523 <= 1
                    v614
                else
                    false
            if v615 then
                v188.l0 <- v269
                ()
            else
                v188.l0 <- v603
                let v616 : string = "true; $0.into_iter().for_each(|x| { //"
                let v617 : bool = Fable.Core.RustInterop.emitRustExpr v372 v616 
                let v618 : string = "x"
                let v619 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v618 
                let v620 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v621 : bool = Fable.Core.RustInterop.emitRustExpr v619 v620 
                let v622 : string = $"true"
                let v623 : bool = Fable.Core.RustInterop.emitRustExpr () v622 
                let v624 : string = "true; }); //"
                let v625 : bool = Fable.Core.RustInterop.emitRustExpr () v624 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v237 v236
            #endif
#if FABLE_COMPILER_PYTHON
            v237 v236
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v237 v236
            #endif
#else
            v237 v236
            #endif
            // run_target_args' is_unit
            let v626 : (string -> unit) = v186.l0
            v626 v236
            US11_0(v185, v186, v187, v188, v189, v190)
    let v660 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v660 
    ()
and method88 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_bright_red"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v15 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v16 : string = "String::from($0)"
    let v17 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v16 
    let _run_target_args'_v15 = v17 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v18 : string = "String::from($0)"
    let v19 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v18 
    let _run_target_args'_v15 = v19 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v20 : string = "String::from($0)"
    let v21 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v20 
    let _run_target_args'_v15 = v21 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v23 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v23 
    #endif
#if FABLE_COMPILER_PYTHON
    let v34 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v34 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v45 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v45 
    #endif
#else
    let v56 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v15 = v56 
    #endif
    let v66 : std_string_String = _run_target_args'_v15 
    let v89 : string = "fable_library_rust::String_::fromString($0)"
    let v90 : string = Fable.Core.RustInterop.emitRustExpr v66 v89 
    let _run_target_args'_v1 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "inline_colorization::color_bright_red"
    let v92 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v91 
    (* run_target_args'
    let v104 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v105 : string = "String::from($0)"
    let v106 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v105 
    let _run_target_args'_v104 = v106 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v107 : string = "String::from($0)"
    let v108 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v107 
    let _run_target_args'_v104 = v108 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v109 : string = "String::from($0)"
    let v110 : std_string_String = Fable.Core.RustInterop.emitRustExpr v92 v109 
    let _run_target_args'_v104 = v110 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v112 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v112 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v134 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v134 
    #endif
#else
    let v145 : std_string_String = v92 |> unbox<std_string_String>
    let _run_target_args'_v104 = v145 
    #endif
    let v155 : std_string_String = _run_target_args'_v104 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v155 v178 
    let _run_target_args'_v1 = v179 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v180 : string = "inline_colorization::color_bright_red"
    let v181 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v180 
    (* run_target_args'
    let v193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v194 : string = "String::from($0)"
    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v194 
    let _run_target_args'_v193 = v195 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v196 : string = "String::from($0)"
    let v197 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v196 
    let _run_target_args'_v193 = v197 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v198 : string = "String::from($0)"
    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v181 v198 
    let _run_target_args'_v193 = v199 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v201 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v201 
    #endif
#if FABLE_COMPILER_PYTHON
    let v212 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v212 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v223 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v223 
    #endif
#else
    let v234 : std_string_String = v181 |> unbox<std_string_String>
    let _run_target_args'_v193 = v234 
    #endif
    let v244 : std_string_String = _run_target_args'_v193 
    let v267 : string = "fable_library_rust::String_::fromString($0)"
    let v268 : string = Fable.Core.RustInterop.emitRustExpr v244 v267 
    let _run_target_args'_v1 = v268 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v269 : string = "\u001b[91m"
    let _run_target_args'_v1 = v269 
    #endif
#if FABLE_COMPILER_PYTHON
    let v270 : string = "\u001b[91m"
    let _run_target_args'_v1 = v270 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v271 : string = "\u001b[91m"
    let _run_target_args'_v1 = v271 
    #endif
#else
    let v272 : string = "\u001b[91m"
    let _run_target_args'_v1 = v272 
    #endif
    let v273 : string = _run_target_args'_v1 
    
    
    
    
    
    let v278 : string = "Critical"
    let v279 : (unit -> string) = v278.ToLower
    let v280 : string = v279 ()
    let v290 : char = v280.[int 0]
    let v291 : string = method14(v290)
    let v293 : string = v273 + v291 
    (* run_target_args'
    let v304 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v305 : string = "inline_colorization::color_reset"
    let v306 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v305 
    (* run_target_args'
    let v318 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v319 : string = "String::from($0)"
    let v320 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v319 
    let _run_target_args'_v318 = v320 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v321 : string = "String::from($0)"
    let v322 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v321 
    let _run_target_args'_v318 = v322 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v323 : string = "String::from($0)"
    let v324 : std_string_String = Fable.Core.RustInterop.emitRustExpr v306 v323 
    let _run_target_args'_v318 = v324 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v326 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v326 
    #endif
#if FABLE_COMPILER_PYTHON
    let v337 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v337 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v348 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v348 
    #endif
#else
    let v359 : std_string_String = v306 |> unbox<std_string_String>
    let _run_target_args'_v318 = v359 
    #endif
    let v369 : std_string_String = _run_target_args'_v318 
    let v392 : string = "fable_library_rust::String_::fromString($0)"
    let v393 : string = Fable.Core.RustInterop.emitRustExpr v369 v392 
    let _run_target_args'_v304 = v393 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v394 : string = "inline_colorization::color_reset"
    let v395 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v394 
    (* run_target_args'
    let v407 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v408 : string = "String::from($0)"
    let v409 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v408 
    let _run_target_args'_v407 = v409 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v410 : string = "String::from($0)"
    let v411 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v410 
    let _run_target_args'_v407 = v411 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v412 : string = "String::from($0)"
    let v413 : std_string_String = Fable.Core.RustInterop.emitRustExpr v395 v412 
    let _run_target_args'_v407 = v413 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v415 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v415 
    #endif
#if FABLE_COMPILER_PYTHON
    let v426 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v426 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v437 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v437 
    #endif
#else
    let v448 : std_string_String = v395 |> unbox<std_string_String>
    let _run_target_args'_v407 = v448 
    #endif
    let v458 : std_string_String = _run_target_args'_v407 
    let v481 : string = "fable_library_rust::String_::fromString($0)"
    let v482 : string = Fable.Core.RustInterop.emitRustExpr v458 v481 
    let _run_target_args'_v304 = v482 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v483 : string = "inline_colorization::color_reset"
    let v484 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v483 
    (* run_target_args'
    let v496 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v497 : string = "String::from($0)"
    let v498 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v497 
    let _run_target_args'_v496 = v498 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v499 : string = "String::from($0)"
    let v500 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v499 
    let _run_target_args'_v496 = v500 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v501 : string = "String::from($0)"
    let v502 : std_string_String = Fable.Core.RustInterop.emitRustExpr v484 v501 
    let _run_target_args'_v496 = v502 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v504 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v504 
    #endif
#if FABLE_COMPILER_PYTHON
    let v515 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v515 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v526 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v526 
    #endif
#else
    let v537 : std_string_String = v484 |> unbox<std_string_String>
    let _run_target_args'_v496 = v537 
    #endif
    let v547 : std_string_String = _run_target_args'_v496 
    let v570 : string = "fable_library_rust::String_::fromString($0)"
    let v571 : string = Fable.Core.RustInterop.emitRustExpr v547 v570 
    let _run_target_args'_v304 = v571 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v572 : string = "\u001b[0m"
    let _run_target_args'_v304 = v572 
    #endif
#if FABLE_COMPILER_PYTHON
    let v573 : string = "\u001b[0m"
    let _run_target_args'_v304 = v573 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v574 : string = "\u001b[0m"
    let _run_target_args'_v304 = v574 
    #endif
#else
    let v575 : string = "\u001b[0m"
    let _run_target_args'_v304 = v575 
    #endif
    let v576 : string = _run_target_args'_v304 
    let v580 : string = v293 + v576 
    v580
and method90 (v0 : uint8, v1 : string) : string =
    let v2 : string = method15()
    let v11 : Mut3 = {l0 = v2} : Mut3
    method19(v11)
    method42(v11)
    method21(v11)
    let v155 : string = $"{v0}"
    method16(v11, v155)
    method43(v11)
    method87(v11)
    method21(v11)
    method16(v11, v1)
    method22(v11)
    let v419 : string = v11.l0
    v419
and method89 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : string) : string =
    let v10 : string = method90(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v26 : string = v15 + v7 
    let v38 : string = " #"
    let v39 : string = v26 + v38 
    let v60 : string = v11 |> _.ToString()
    let v71 : string = v39 + v60 
    let v82 : string = v71 + v14 
    let v94 : string = "spiral_wasm.run / Ok (Some error)"
    let v95 : string = v82 + v94 
    let v107 : string = " / "
    let v108 : string = v95 + v107 
    let v119 : string = v108 + v10 
    method23(v119)
and closure44 (v0 : uint8, v1 : string) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure14()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US5 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 4 >= v114
            v115
    let v117 : bool = v116 = false
    let v742 : US11 =
        if v117 then
            US11_1
        else
            let v148 : unit = ()
            let v149 : unit = (fun () -> v32 (); v148) ()
            let struct (v187 : Mut0, v188 : Mut1, v189 : Mut2, v190 : Mut3, v191 : Mut4, v192 : int64 option) = TraceState.trace_state.Value
            let v227 : string = method9(v187, v188, v189, v190, v191, v192)
            let v228 : string = method88()
            let v229 : string = method89(v187, v188, v189, v190, v191, v192, v227, v228, v0, v1)
            let v259 : unit = ()
            let v260 : unit = (fun () -> v32 (); v259) ()
            let struct (v298 : Mut0, v299 : Mut1, v300 : Mut2, v301 : Mut3, v302 : Mut4, v303 : int64 option) = TraceState.trace_state.Value
            let v340 : unit = ()
            let v341 : (unit -> unit) = closure16(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure17()
            (* run_target_args'
            let v350 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v351 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v352 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v229 v352 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v353 : string = v301.l0
            let v354 : bool = v353 = ""
            let v383 : string =
                if v354 then
                    v229
                else
                    let v355 : bool = v229 = ""
                    if v355 then
                        let v356 : string = v301.l0
                        v356
                    else
                        let v357 : string = v301.l0
                        let v360 : string = "\n"
                        let v361 : string = v357 + v360 
                        let v372 : string = v361 + v229 
                        v372
            (* run_target_args'
            let v395 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v396 : string = "&*$0"
            let v397 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v396 
            let _run_target_args'_v395 = v397 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v398 : string = "&*$0"
            let v399 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v398 
            let _run_target_args'_v395 = v399 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v400 : string = "&*$0"
            let v401 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v383 v400 
            let _run_target_args'_v395 = v401 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v403 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v403 
            #endif
#if FABLE_COMPILER_PYTHON
            let v414 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v414 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v425 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v425 
            #endif
#else
            let v436 : Ref<Str> = v383 |> unbox<Ref<Str>>
            let _run_target_args'_v395 = v436 
            #endif
            let v446 : Ref<Str> = _run_target_args'_v395 
            let v469 : string = $"$0.chars()"
            let v470 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v446 v469 
            let v471 : string = "$0"
            let v472 : _ = Fable.Core.RustInterop.emitRustExpr v470 v471 
            let v473 : string = "$0.collect::<Vec<_>>()"
            let v474 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v472 v473 
            let v475 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v476 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v474 v475 
            let v477 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v478 : bool = Fable.Core.RustInterop.emitRustExpr v476 v477 
            let v479 : string = "x"
            let v480 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v479 
            let v481 : string = "String::from_iter($0)"
            let v482 : std_string_String = Fable.Core.RustInterop.emitRustExpr v480 v481 
            let v483 : string = "true; $0 }).collect::<Vec<_>>()"
            let v484 : bool = Fable.Core.RustInterop.emitRustExpr v482 v483 
            let v485 : string = "_vec_map"
            let v486 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v485 
            let v487 : string = "$0.len()"
            let v488 : unativeint = Fable.Core.RustInterop.emitRustExpr v486 v487 
            let v576 : (unit -> int32) = closure19(v488)
            let v577 : (int32 -> US13) = closure20()
            let v578 : ((unit -> exn) -> exn) = closure3()
            let v579 : (exn -> US13) = closure21()
            let v580 : US13 = try v576 () |> v577 with ex -> (fun () -> ex) |> v578 |> v579 
            let v599 : US14 =
                match v580 with
                | US13_1(v596) -> (* Error *)
                    US14_1
                | US13_0(v594) -> (* Ok *)
                    US14_0(v594)
            let v637 : int32 =
                match v599 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v634) -> (* Some *)
                    v634
            let v717 : string = ""
            let v718 : bool = v229 <> v717 
            let v729 : bool =
                if v718 then
                    let v728 : bool = v637 <= 1
                    v728
                else
                    false
            if v729 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v717
                let v730 : string = "true; $0.into_iter().for_each(|x| { //"
                let v731 : bool = Fable.Core.RustInterop.emitRustExpr v486 v730 
                let v732 : string = "x"
                let v733 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v732 
                let v734 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v735 : bool = Fable.Core.RustInterop.emitRustExpr v733 v734 
                let v736 : string = $"true"
                let v737 : bool = Fable.Core.RustInterop.emitRustExpr () v736 
                let v738 : string = "true; }); //"
                let v739 : bool = Fable.Core.RustInterop.emitRustExpr () v738 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v349 v229
            #endif
#if FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v349 v229
            #endif
#else
            v349 v229
            #endif
            // run_target_args' is_unit
            let v740 : (string -> unit) = v299.l0
            v740 v229
            US11_0(v298, v299, v300, v301, v302, v303)
    let v774 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v774 
    ()
and method38 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<US15>>>> =
    let v2 : string = "true; let __future_init = Box::pin(/*"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let v4 : string = "*/ async move { /*"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let v6 : string = "*/ ()"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let v8 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US9, anyhow_Error>>>>> = method39(v0, v1)
    let v9 : string = "v8.await"
    let v10 : Result<US9, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr () v9 
    let v11 : (anyhow_Error -> std_string_String) = method81()
    (* run_target_args'
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "$0.map_err(|x| $1(x))"
    let v15 : Result<US9, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v10, v11) v14 
    let _run_target_args'_v13 = v15 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v16 : string = "$0.map_err(|x| $1(x))"
    let v17 : Result<US9, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v10, v11) v16 
    let _run_target_args'_v13 = v17 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v18 : string = "$0.map_err(|x| $1(x))"
    let v19 : Result<US9, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v10, v11) v18 
    let _run_target_args'_v13 = v19 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : Result<US9, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v13 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v21 : Result<US9, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v13 = v21 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v22 : Result<US9, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v13 = v22 
    #endif
#else
    let v23 : Result<US9, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v13 = v23 
    #endif
    let v24 : Result<US9, std_string_String> = _run_target_args'_v13 
    let v27 : (US9 -> US16) = method82()
    let v28 : (std_string_String -> US16) = method83()
    let v30 : US16 = match v24 with Ok x -> v27 x | Error x -> v28 x
    let v7522 : US15 =
        match v30 with
        | US16_1(v1674) -> (* Error *)
            let v1675 : bool = v1 >= 15uy
            if v1675 then
                let v2453 : unit = ()
                let v2454 : (unit -> unit) = closure40(v1, v1674)
                let v2455 : unit = (fun () -> v2454 (); v2453) ()
                let v3906 : unit = ()
                let v3907 : (unit -> unit) = closure41()
                let v3908 : unit = (fun () -> v3907 (); v3906) ()
                let v4581 : string = "true; let __future_init = Box::pin(/*"
                let v4582 : bool = Fable.Core.RustInterop.emitRustExpr () v4581 
                let v4583 : string = "*/ async move { /*"
                let v4584 : bool = Fable.Core.RustInterop.emitRustExpr () v4583 
                let v4585 : string = "*/ ()"
                let v4586 : bool = Fable.Core.RustInterop.emitRustExpr () v4585 
                let v4587 : string = ""
                let v4588 : string = "}"
                let v4589 : string = v4587 + v4588 
                let v4590 : US9 = US9_1
                let x = struct (v1, v4590) //
                let v4591 : _ = x
                let v4592 : unit = ()
                (* run_target_args'
                let v4593 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4594 : string = $"true; let _fix_closure_v4592 = $0"
                let v4595 : bool = Fable.Core.RustInterop.emitRustExpr v4591 v4594 
                let _run_target_args'_v4593 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4596 : string = $"true; let _fix_closure_v4592 = $0"
                let v4597 : bool = Fable.Core.RustInterop.emitRustExpr v4591 v4596 
                let _run_target_args'_v4593 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4598 : string = $"true; let _fix_closure_v4592 = $0"
                let v4599 : bool = Fable.Core.RustInterop.emitRustExpr v4591 v4598 
                let _run_target_args'_v4593 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v4593 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v4593 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v4593 = false 
                #endif
#else
                let _run_target_args'_v4593 = false 
                #endif
                let v4600 : bool = _run_target_args'_v4593 
                let v4601 : string = $"true; _fix_closure_v4592 " + v4589 + "); " + v4587 + " // rust.fix_closure'"
                let v4602 : bool = Fable.Core.RustInterop.emitRustExpr () v4601 
                let v4603 : string = "__future_init"
                let v4604 : _ = Fable.Core.RustInterop.emitRustExpr () v4603 
                let v4605 : string = "v4604"
                let v4606 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US9)>>>> = Fable.Core.RustInterop.emitRustExpr () v4605 
                let v4607 : string = "v4606.await"
                let struct (v4608 : uint8, v4609 : US9) = Fable.Core.RustInterop.emitRustExpr () v4607 
                US15_0(v4608, v4609)
            else
                let v5388 : unit = ()
                let v5389 : (unit -> unit) = closure42(v1, v1674)
                let v5390 : unit = (fun () -> v5389 (); v5388) ()
                let v6841 : unit = ()
                let v6842 : (unit -> unit) = closure43()
                let v6843 : unit = (fun () -> v6842 (); v6841) ()
                let v7516 : uint8 = v1 + 1uy
                let v7517 : std_pin_Pin<Box<Dyn<std_future_Future<US15>>>> = method38(v0, v7516)
                let v7518 : string = "v7517.await"
                let v7519 : US15 = Fable.Core.RustInterop.emitRustExpr () v7518 
                v7519
        | US16_0(v46) -> (* Ok *)
            match v46 with
            | US9_1 -> (* None *)
                let v47 : string = "true; let __future_init = Box::pin(/*"
                let v48 : bool = Fable.Core.RustInterop.emitRustExpr () v47 
                let v49 : string = "*/ async move { /*"
                let v50 : bool = Fable.Core.RustInterop.emitRustExpr () v49 
                let v51 : string = "*/ ()"
                let v52 : bool = Fable.Core.RustInterop.emitRustExpr () v51 
                let v53 : string = ""
                let v54 : string = "}"
                let v55 : string = v53 + v54 
                let v56 : US9 = US9_1
                let x = struct (v1, v56) //
                let v57 : _ = x
                let v58 : unit = ()
                (* run_target_args'
                let v59 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v60 : string = $"true; let _fix_closure_v58 = $0"
                let v61 : bool = Fable.Core.RustInterop.emitRustExpr v57 v60 
                let _run_target_args'_v59 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v62 : string = $"true; let _fix_closure_v58 = $0"
                let v63 : bool = Fable.Core.RustInterop.emitRustExpr v57 v62 
                let _run_target_args'_v59 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v64 : string = $"true; let _fix_closure_v58 = $0"
                let v65 : bool = Fable.Core.RustInterop.emitRustExpr v57 v64 
                let _run_target_args'_v59 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v59 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v59 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v59 = false 
                #endif
#else
                let _run_target_args'_v59 = false 
                #endif
                let v66 : bool = _run_target_args'_v59 
                let v67 : string = $"true; _fix_closure_v58 " + v55 + "); " + v53 + " // rust.fix_closure'"
                let v68 : bool = Fable.Core.RustInterop.emitRustExpr () v67 
                let v69 : string = "__future_init"
                let v70 : _ = Fable.Core.RustInterop.emitRustExpr () v69 
                let v71 : string = "v70"
                let v72 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US9)>>>> = Fable.Core.RustInterop.emitRustExpr () v71 
                let v73 : string = "v72.await"
                let struct (v74 : uint8, v75 : US9) = Fable.Core.RustInterop.emitRustExpr () v73 
                US15_0(v74, v75)
            | US9_0(v77) -> (* Some *)
                let v855 : unit = ()
                let v856 : (unit -> unit) = closure44(v1, v77)
                let v857 : unit = (fun () -> v856 (); v855) ()
                let v1642 : string = "true; let __future_init = Box::pin(/*"
                let v1643 : bool = Fable.Core.RustInterop.emitRustExpr () v1642 
                let v1644 : string = "*/ async move { /*"
                let v1645 : bool = Fable.Core.RustInterop.emitRustExpr () v1644 
                let v1646 : string = "*/ ()"
                let v1647 : bool = Fable.Core.RustInterop.emitRustExpr () v1646 
                let v1648 : string = ""
                let v1649 : string = "}"
                let v1650 : string = v1648 + v1649 
                let v1651 : US9 = US9_0(v77)
                let x = struct (v1, v1651) //
                let v1652 : _ = x
                let v1653 : unit = ()
                (* run_target_args'
                let v1654 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1655 : string = $"true; let _fix_closure_v1653 = $0"
                let v1656 : bool = Fable.Core.RustInterop.emitRustExpr v1652 v1655 
                let _run_target_args'_v1654 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1657 : string = $"true; let _fix_closure_v1653 = $0"
                let v1658 : bool = Fable.Core.RustInterop.emitRustExpr v1652 v1657 
                let _run_target_args'_v1654 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1659 : string = $"true; let _fix_closure_v1653 = $0"
                let v1660 : bool = Fable.Core.RustInterop.emitRustExpr v1652 v1659 
                let _run_target_args'_v1654 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v1654 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v1654 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v1654 = false 
                #endif
#else
                let _run_target_args'_v1654 = false 
                #endif
                let v1661 : bool = _run_target_args'_v1654 
                let v1662 : string = $"true; _fix_closure_v1653 " + v1650 + "); " + v1648 + " // rust.fix_closure'"
                let v1663 : bool = Fable.Core.RustInterop.emitRustExpr () v1662 
                let v1664 : string = "__future_init"
                let v1665 : _ = Fable.Core.RustInterop.emitRustExpr () v1664 
                let v1666 : string = "v1665"
                let v1667 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US9)>>>> = Fable.Core.RustInterop.emitRustExpr () v1666 
                let v1668 : string = "v1667.await"
                let struct (v1669 : uint8, v1670 : US9) = Fable.Core.RustInterop.emitRustExpr () v1668 
                US15_1(v1669, v1670)
    let v7523 : string = ""
    let v7524 : string = "}"
    let v7525 : string = v7523 + v7524 
    let x = v7522 //
    let v7526 : _ = x
    let v7527 : unit = ()
    (* run_target_args'
    let v7528 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7529 : string = $"true; let _fix_closure_v7527 = $0"
    let v7530 : bool = Fable.Core.RustInterop.emitRustExpr v7526 v7529 
    let _run_target_args'_v7528 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7531 : string = $"true; let _fix_closure_v7527 = $0"
    let v7532 : bool = Fable.Core.RustInterop.emitRustExpr v7526 v7531 
    let _run_target_args'_v7528 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v7533 : string = $"true; let _fix_closure_v7527 = $0"
    let v7534 : bool = Fable.Core.RustInterop.emitRustExpr v7526 v7533 
    let _run_target_args'_v7528 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v7528 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v7528 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v7528 = false 
    #endif
#else
    let _run_target_args'_v7528 = false 
    #endif
    let v7535 : bool = _run_target_args'_v7528 
    let v7536 : string = $"true; _fix_closure_v7527 " + v7525 + "); " + v7523 + " // rust.fix_closure'"
    let v7537 : bool = Fable.Core.RustInterop.emitRustExpr () v7536 
    let v7538 : string = "__future_init"
    let v7539 : _ = Fable.Core.RustInterop.emitRustExpr () v7538 
    let v7540 : string = "v7539"
    let v7541 : std_pin_Pin<Box<Dyn<std_future_Future<US15>>>> = Fable.Core.RustInterop.emitRustExpr () v7540 
    v7541
and method93 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "retries"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method92 (v0 : US15) : string =
    let v1 : string = method15()
    let v10 : Mut3 = {l0 = v1} : Mut3
    method19(v10)
    method93(v10)
    method21(v10)
    let v144 : string = $"%A{v0}"
    method16(v10, v144)
    method22(v10)
    let v241 : string = v10.l0
    v241
and method91 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : US15) : string =
    let v9 : string = method92(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v25 : string = v14 + v7 
    let v37 : string = " #"
    let v38 : string = v25 + v37 
    let v59 : string = v10 |> _.ToString()
    let v70 : string = v38 + v59 
    let v81 : string = v70 + v13 
    let v93 : string = "spiral_wasm.run"
    let v94 : string = v81 + v93 
    let v106 : string = " / "
    let v107 : string = v94 + v106 
    let v118 : string = v107 + v9 
    method23(v118)
and closure45 (v0 : US15) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure14()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US5 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US5_0, 0; US5_1, 1; US5_2, 2; US5_3, 3; US5_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v741 : US11 =
        if v116 then
            US11_1
        else
            let v147 : unit = ()
            let v148 : unit = (fun () -> v31 (); v147) ()
            let struct (v186 : Mut0, v187 : Mut1, v188 : Mut2, v189 : Mut3, v190 : Mut4, v191 : int64 option) = TraceState.trace_state.Value
            let v226 : string = method9(v186, v187, v188, v189, v190, v191)
            let v227 : string = method13()
            let v228 : string = method91(v186, v187, v188, v189, v190, v191, v226, v227, v0)
            let v258 : unit = ()
            let v259 : unit = (fun () -> v31 (); v258) ()
            let struct (v297 : Mut0, v298 : Mut1, v299 : Mut2, v300 : Mut3, v301 : Mut4, v302 : int64 option) = TraceState.trace_state.Value
            let v339 : unit = ()
            let v340 : (unit -> unit) = closure16(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure17()
            (* run_target_args'
            let v349 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v350 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v350 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v351 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v228 v351 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v352 : string = v300.l0
            let v353 : bool = v352 = ""
            let v382 : string =
                if v353 then
                    v228
                else
                    let v354 : bool = v228 = ""
                    if v354 then
                        let v355 : string = v300.l0
                        v355
                    else
                        let v356 : string = v300.l0
                        let v359 : string = "\n"
                        let v360 : string = v356 + v359 
                        let v371 : string = v360 + v228 
                        v371
            (* run_target_args'
            let v394 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v395 : string = "&*$0"
            let v396 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v395 
            let _run_target_args'_v394 = v396 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v397 : string = "&*$0"
            let v398 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v397 
            let _run_target_args'_v394 = v398 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v399 : string = "&*$0"
            let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v382 v399 
            let _run_target_args'_v394 = v400 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v402 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v402 
            #endif
#if FABLE_COMPILER_PYTHON
            let v413 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v413 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v424 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v424 
            #endif
#else
            let v435 : Ref<Str> = v382 |> unbox<Ref<Str>>
            let _run_target_args'_v394 = v435 
            #endif
            let v445 : Ref<Str> = _run_target_args'_v394 
            let v468 : string = $"$0.chars()"
            let v469 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v445 v468 
            let v470 : string = "$0"
            let v471 : _ = Fable.Core.RustInterop.emitRustExpr v469 v470 
            let v472 : string = "$0.collect::<Vec<_>>()"
            let v473 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v471 v472 
            let v474 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v475 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v473 v474 
            let v476 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v477 : bool = Fable.Core.RustInterop.emitRustExpr v475 v476 
            let v478 : string = "x"
            let v479 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v478 
            let v480 : string = "String::from_iter($0)"
            let v481 : std_string_String = Fable.Core.RustInterop.emitRustExpr v479 v480 
            let v482 : string = "true; $0 }).collect::<Vec<_>>()"
            let v483 : bool = Fable.Core.RustInterop.emitRustExpr v481 v482 
            let v484 : string = "_vec_map"
            let v485 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v484 
            let v486 : string = "$0.len()"
            let v487 : unativeint = Fable.Core.RustInterop.emitRustExpr v485 v486 
            let v575 : (unit -> int32) = closure19(v487)
            let v576 : (int32 -> US13) = closure20()
            let v577 : ((unit -> exn) -> exn) = closure3()
            let v578 : (exn -> US13) = closure21()
            let v579 : US13 = try v575 () |> v576 with ex -> (fun () -> ex) |> v577 |> v578 
            let v598 : US14 =
                match v579 with
                | US13_1(v595) -> (* Error *)
                    US14_1
                | US13_0(v593) -> (* Ok *)
                    US14_0(v593)
            let v636 : int32 =
                match v598 with
                | US14_1 -> (* None *)
                    failwith<int32> "Option does not have a value."
                | US14_0(v633) -> (* Some *)
                    v633
            let v716 : string = ""
            let v717 : bool = v228 <> v716 
            let v728 : bool =
                if v717 then
                    let v727 : bool = v636 <= 1
                    v727
                else
                    false
            if v728 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v716
                let v729 : string = "true; $0.into_iter().for_each(|x| { //"
                let v730 : bool = Fable.Core.RustInterop.emitRustExpr v485 v729 
                let v731 : string = "x"
                let v732 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v731 
                let v733 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v734 : bool = Fable.Core.RustInterop.emitRustExpr v732 v733 
                let v735 : string = $"true"
                let v736 : bool = Fable.Core.RustInterop.emitRustExpr () v735 
                let v737 : string = "true; }); //"
                let v738 : bool = Fable.Core.RustInterop.emitRustExpr () v737 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v348 v228
            #endif
#if FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v348 v228
            #endif
#else
            v348 v228
            #endif
            // run_target_args' is_unit
            let v739 : (string -> unit) = v298.l0
            v739 v228
            US11_0(v297, v298, v299, v300, v301, v302)
    let v773 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v773 
    ()
and method94 (v0 : US15, v1 : US9) : string =
    let v2 : string = method15()
    let v11 : Mut3 = {l0 = v2} : Mut3
    method19(v11)
    method93(v11)
    method21(v11)
    let v145 : string = $"%A{v0}"
    method16(v11, v145)
    method43(v11)
    method87(v11)
    method21(v11)
    let v331 : string = $"%A{v1}"
    method16(v11, v331)
    method22(v11)
    let v428 : string = v11.l0
    v428
and method33 (v0 : clap_ArgMatches) : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> =
    let v1 : string = "true; let __future_init = Box::pin(/*"
    let v2 : bool = Fable.Core.RustInterop.emitRustExpr () v1 
    let v3 : string = "*/ async move { /*"
    let v4 : bool = Fable.Core.RustInterop.emitRustExpr () v3 
    let v5 : string = "*/ ()"
    let v6 : bool = Fable.Core.RustInterop.emitRustExpr () v5 
    let v7 : string = method34()
    (* run_target_args'
    let v19 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v20 : string = "&*$0"
    let v21 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v20 
    let _run_target_args'_v19 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v22 : string = "&*$0"
    let v23 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v22 
    let _run_target_args'_v19 = v23 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v24 : string = "&*$0"
    let v25 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v24 
    let _run_target_args'_v19 = v25 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v27 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v27 
    #endif
#if FABLE_COMPILER_PYTHON
    let v38 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v38 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v49 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v49 
    #endif
#else
    let v60 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v60 
    #endif
    let v70 : Ref<Str> = _run_target_args'_v19 
    let v93 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v94 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v0, v70) v93 
    let v106 : (std_string_String -> US2) = method2()
    let v107 : US2 option = v94 |> Option.map v106 
    let v155 : US2 = US2_1
    let v156 : US2 = v107 |> Option.defaultValue v155 
    let v170 : std_string_String =
        match v156 with
        | US2_1 -> (* None *)
            failwith<std_string_String> "Option does not have a value."
        | US2_0(v167) -> (* Some *)
            v167
    let v171 : string = "fable_library_rust::String_::fromString($0)"
    let v172 : string = Fable.Core.RustInterop.emitRustExpr v170 v171 
    let v950 : unit = ()
    let v951 : (unit -> unit) = closure23(v172)
    let v952 : unit = (fun () -> v951 (); v950) ()
    let v1737 : string = "std::fs::read(&*$0)"
    let v1738 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v172 v1737 
    let v1739 : string = "$0?"
    let v1740 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v1738 v1739 
    let v1741 : uint8 = 1uy
    let v1742 : std_pin_Pin<Box<Dyn<std_future_Future<US15>>>> = method38(v1740, v1741)
    let v1743 : string = "v1742.await"
    let v1744 : US15 = Fable.Core.RustInterop.emitRustExpr () v1743 
    let v2522 : unit = ()
    let v2523 : (unit -> unit) = closure45(v1744)
    let v2524 : unit = (fun () -> v2523 (); v2522) ()
    let v3343 : Result<uint8, anyhow_Error> =
        match v1744 with
        | US15_1(v3322, v3323) -> (* Error *)
            let v3324 : string = method94(v1744, v3323)
            let v3325 : string = "anyhow::anyhow!($0)"
            let v3326 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v3324 v3325 
            (* run_target_args'
            let v3328 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3329 : string = "Err($0)"
            let v3330 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v3326 v3329 
            let _run_target_args'_v3328 = v3330 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3331 : string = "Err($0)"
            let v3332 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v3326 v3331 
            let _run_target_args'_v3328 = v3332 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3333 : string = "Err($0)"
            let v3334 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v3326 v3333 
            let _run_target_args'_v3328 = v3334 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3335 : Result<uint8, anyhow_Error> = v3326 |> Error
            let _run_target_args'_v3328 = v3335 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3336 : Result<uint8, anyhow_Error> = v3326 |> Error
            let _run_target_args'_v3328 = v3336 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3337 : Result<uint8, anyhow_Error> = v3326 |> Error
            let _run_target_args'_v3328 = v3337 
            #endif
#else
            let v3338 : Result<uint8, anyhow_Error> = v3326 |> Error
            let _run_target_args'_v3328 = v3338 
            #endif
            let v3339 : Result<uint8, anyhow_Error> = _run_target_args'_v3328 
            v3339
        | US15_0(v3309, v3310) -> (* Ok *)
            let v3312 : Result<uint8, anyhow_Error> = Ok v3309 
            v3312
    let v3344 : string = ""
    let v3345 : string = "}"
    let v3346 : string = v3344 + v3345 
    let x = v3343 //
    let v3347 : _ = x
    let v3348 : unit = ()
    (* run_target_args'
    let v3349 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3350 : string = $"true; let _fix_closure_v3348 = $0"
    let v3351 : bool = Fable.Core.RustInterop.emitRustExpr v3347 v3350 
    let _run_target_args'_v3349 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3352 : string = $"true; let _fix_closure_v3348 = $0"
    let v3353 : bool = Fable.Core.RustInterop.emitRustExpr v3347 v3352 
    let _run_target_args'_v3349 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3354 : string = $"true; let _fix_closure_v3348 = $0"
    let v3355 : bool = Fable.Core.RustInterop.emitRustExpr v3347 v3354 
    let _run_target_args'_v3349 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v3349 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v3349 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v3349 = false 
    #endif
#else
    let _run_target_args'_v3349 = false 
    #endif
    let v3356 : bool = _run_target_args'_v3349 
    let v3357 : string = $"true; _fix_closure_v3348 " + v3346 + "); " + v3344 + " // rust.fix_closure'"
    let v3358 : bool = Fable.Core.RustInterop.emitRustExpr () v3357 
    let v3359 : string = "__future_init"
    let v3360 : _ = Fable.Core.RustInterop.emitRustExpr () v3359 
    let v3361 : string = "v3360"
    let v3362 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v3361 
    v3362
and closure46 () (v0 : uint8) : US17 =
    US17_0(v0)
and method95 () : (uint8 -> US17) =
    closure46()
and closure47 () (v0 : std_string_String) : US17 =
    US17_1(v0)
and method96 () : (std_string_String -> US17) =
    closure47()
and closure0 () (v0 : (string [])) : int32 =
    let v1 : clap_Command = method0()
    let v2 : string = "clap::Command::get_matches($0)"
    let v3 : clap_ArgMatches = Fable.Core.RustInterop.emitRustExpr v1 v2 
    let v4 : string = method1()
    (* run_target_args'
    let v16 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v17 : string = "&*$0"
    let v18 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v17 
    let _run_target_args'_v16 = v18 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v19 : string = "&*$0"
    let v20 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v19 
    let _run_target_args'_v16 = v20 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v21 : string = "&*$0"
    let v22 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v21 
    let _run_target_args'_v16 = v22 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v24 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v16 = v24 
    #endif
#if FABLE_COMPILER_PYTHON
    let v35 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v16 = v35 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v46 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v16 = v46 
    #endif
#else
    let v57 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v16 = v57 
    #endif
    let v67 : Ref<Str> = _run_target_args'_v16 
    let v90 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v91 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v67) v90 
    let v103 : (std_string_String -> US2) = method2()
    let v104 : US2 option = v91 |> Option.map v103 
    let v152 : US2 = US2_1
    let v153 : US2 = v104 |> Option.defaultValue v152 
    let v331 : US3 =
        match v153 with
        | US2_1 -> (* None *)
            US3_1
        | US2_0(v164) -> (* Some *)
            let v165 : string = "fable_library_rust::String_::fromString($0)"
            let v166 : string = Fable.Core.RustInterop.emitRustExpr v164 v165 
            
            
            
            
            
            
            
            
            
            
            let v169 : string = "Critical"
            let v170 : (unit -> string) = v169.ToLower
            let v171 : string = v170 ()
            let v183 : string = "Warning"
            let v184 : (unit -> string) = v183.ToLower
            let v185 : string = v184 ()
            let v197 : string = "Info"
            let v198 : (unit -> string) = v197.ToLower
            let v199 : string = v198 ()
            let v211 : string = "Debug"
            let v212 : (unit -> string) = v211.ToLower
            let v213 : string = v212 ()
            let v225 : string = "Verbose"
            let v226 : (unit -> string) = v225.ToLower
            let v227 : string = v226 ()
            let v237 : bool = "Verbose" = v166
            let v241 : US4 =
                if v237 then
                    let v238 : US5 = US5_0
                    US4_0(v238)
                else
                    US4_1
            let v327 : US4 =
                match v241 with
                | US4_1 -> (* None *)
                    let v244 : bool = "Debug" = v166
                    let v248 : US4 =
                        if v244 then
                            let v245 : US5 = US5_1
                            US4_0(v245)
                        else
                            US4_1
                    match v248 with
                    | US4_1 -> (* None *)
                        let v251 : bool = "Info" = v166
                        let v255 : US4 =
                            if v251 then
                                let v252 : US5 = US5_2
                                US4_0(v252)
                            else
                                US4_1
                        match v255 with
                        | US4_1 -> (* None *)
                            let v258 : bool = "Warning" = v166
                            let v262 : US4 =
                                if v258 then
                                    let v259 : US5 = US5_3
                                    US4_0(v259)
                                else
                                    US4_1
                            match v262 with
                            | US4_1 -> (* None *)
                                let v265 : bool = "Critical" = v166
                                let v269 : US4 =
                                    if v265 then
                                        let v266 : US5 = US5_4
                                        US4_0(v266)
                                    else
                                        US4_1
                                match v269 with
                                | US4_1 -> (* None *)
                                    let v272 : bool = v227 = v166
                                    let v276 : US4 =
                                        if v272 then
                                            let v273 : US5 = US5_0
                                            US4_0(v273)
                                        else
                                            US4_1
                                    match v276 with
                                    | US4_1 -> (* None *)
                                        let v279 : bool = v213 = v166
                                        let v283 : US4 =
                                            if v279 then
                                                let v280 : US5 = US5_1
                                                US4_0(v280)
                                            else
                                                US4_1
                                        match v283 with
                                        | US4_1 -> (* None *)
                                            let v286 : bool = v199 = v166
                                            let v290 : US4 =
                                                if v286 then
                                                    let v287 : US5 = US5_2
                                                    US4_0(v287)
                                                else
                                                    US4_1
                                            match v290 with
                                            | US4_1 -> (* None *)
                                                let v293 : bool = v185 = v166
                                                let v297 : US4 =
                                                    if v293 then
                                                        let v294 : US5 = US5_3
                                                        US4_0(v294)
                                                    else
                                                        US4_1
                                                match v297 with
                                                | US4_1 -> (* None *)
                                                    let v300 : bool = v171 = v166
                                                    let v304 : US4 =
                                                        if v300 then
                                                            let v301 : US5 = US5_4
                                                            US4_0(v301)
                                                        else
                                                            US4_1
                                                    match v304 with
                                                    | US4_1 -> (* None *)
                                                        US4_1
                                                    | US4_0(v305) -> (* Some *)
                                                        US4_0(v305)
                                                | US4_0(v298) -> (* Some *)
                                                    US4_0(v298)
                                            | US4_0(v291) -> (* Some *)
                                                US4_0(v291)
                                        | US4_0(v284) -> (* Some *)
                                            US4_0(v284)
                                    | US4_0(v277) -> (* Some *)
                                        US4_0(v277)
                                | US4_0(v270) -> (* Some *)
                                    US4_0(v270)
                            | US4_0(v263) -> (* Some *)
                                US4_0(v263)
                        | US4_0(v256) -> (* Some *)
                            US4_0(v256)
                    | US4_0(v249) -> (* Some *)
                        US4_0(v249)
                | US4_0(v242) -> (* Some *)
                    US4_0(v242)
            US3_0(v327)
    let v338 : US4 =
        match v331 with
        | US3_0(v332) -> (* Some *)
            match v332 with
            | US4_0(v333) -> (* Some *)
                US4_0(v333)
            | _ ->
                US4_1
        | _ ->
            US4_1
    let v342 : US5 =
        match v338 with
        | US4_1 -> (* None *)
            US5_0
        | US4_0(v339) -> (* Some *)
            v339
    let v370 : unit = ()
    let v371 : (unit -> unit) = closure7(v342)
    let v372 : unit = (fun () -> v371 (); v370) ()
    let struct (v407 : Mut0, v408 : Mut1, v409 : Mut2, v410 : Mut3, v411 : Mut4, v412 : int64 option) = TraceState.trace_state.Value
    let v1224 : unit = ()
    let v1225 : (unit -> unit) = closure13(v0)
    let v1226 : unit = (fun () -> v1225 (); v1224) ()
    let v2011 : string = method28()
    (* run_target_args'
    let v2023 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2024 : string = "&*$0"
    let v2025 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v2011 v2024 
    let _run_target_args'_v2023 = v2025 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2026 : string = "&*$0"
    let v2027 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v2011 v2026 
    let _run_target_args'_v2023 = v2027 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2028 : string = "&*$0"
    let v2029 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v2011 v2028 
    let _run_target_args'_v2023 = v2029 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2031 : Ref<Str> = v2011 |> unbox<Ref<Str>>
    let _run_target_args'_v2023 = v2031 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2042 : Ref<Str> = v2011 |> unbox<Ref<Str>>
    let _run_target_args'_v2023 = v2042 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2053 : Ref<Str> = v2011 |> unbox<Ref<Str>>
    let _run_target_args'_v2023 = v2053 
    #endif
#else
    let v2064 : Ref<Str> = v2011 |> unbox<Ref<Str>>
    let _run_target_args'_v2023 = v2064 
    #endif
    let v2074 : Ref<Str> = _run_target_args'_v2023 
    let v2097 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v2098 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v2074) v2097 
    let v2110 : (std_string_String -> string) = method29()
    let v2111 : string option = v2098 |> Option.map v2110 
    let v3172 : (string -> US9) = method8()
    let v3173 : US9 option = v2111 |> Option.map v3172 
    let v3221 : US9 = US9_1
    let v3222 : US9 = v3173 |> Option.defaultValue v3221 
    let v3233 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method33(v3)
    let v3234 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v3235 : _ = Fable.Core.RustInterop.emitRustExpr () v3234 
    let v3236 : string = "v3235.handle().block_on($0)"
    let v3237 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v3233 v3236 
    let v3238 : (anyhow_Error -> std_string_String) = method81()
    (* run_target_args'
    let v3240 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3241 : string = "$0.map_err(|x| $1(x))"
    let v3242 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v3237, v3238) v3241 
    let _run_target_args'_v3240 = v3242 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3243 : string = "$0.map_err(|x| $1(x))"
    let v3244 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v3237, v3238) v3243 
    let _run_target_args'_v3240 = v3244 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3245 : string = "$0.map_err(|x| $1(x))"
    let v3246 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v3237, v3238) v3245 
    let _run_target_args'_v3240 = v3246 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3247 : Result<uint8, std_string_String> = match v3237 with Ok x -> Ok x | Error x -> Error (v3238 x)
    let _run_target_args'_v3240 = v3247 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3248 : Result<uint8, std_string_String> = match v3237 with Ok x -> Ok x | Error x -> Error (v3238 x)
    let _run_target_args'_v3240 = v3248 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3249 : Result<uint8, std_string_String> = match v3237 with Ok x -> Ok x | Error x -> Error (v3238 x)
    let _run_target_args'_v3240 = v3249 
    #endif
#else
    let v3250 : Result<uint8, std_string_String> = match v3237 with Ok x -> Ok x | Error x -> Error (v3238 x)
    let _run_target_args'_v3240 = v3250 
    #endif
    let v3251 : Result<uint8, std_string_String> = _run_target_args'_v3240 
    let v3254 : (uint8 -> US17) = method95()
    let v3255 : (std_string_String -> US17) = method96()
    let v3257 : US17 = match v3251 with Ok x -> v3254 x | Error x -> v3255 x
    match v3257 with
    | US17_1(v3295) -> (* Error *)
        match v3222 with
        | US9_0(v3296) -> (* Some *)
            let v3297 : bool = "" = v3296
            if v3297 then
                ()
            else
                let v3298 : string = "fable_library_rust::String_::fromString($0)"
                let v3299 : string = Fable.Core.RustInterop.emitRustExpr v3295 v3298 
                let v3301 : bool = v3299.Contains v3296 
                if v3301 then
                    ()
                else
                    let v3311 : string = $"spiral_wasm.main / exception: '{v3296}' / error: {v3295}"
                    (* run_target_args'
                    let v3313 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v3314 : string = "Err($0)"
                    let v3315 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v3311 v3314 
                    let _run_target_args'_v3313 = v3315 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v3316 : string = "Err($0)"
                    let v3317 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v3311 v3316 
                    let _run_target_args'_v3313 = v3317 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v3318 : string = "Err($0)"
                    let v3319 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v3311 v3318 
                    let _run_target_args'_v3313 = v3319 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v3320 : Result<unit, string> = v3311 |> Error
                    let _run_target_args'_v3313 = v3320 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v3321 : Result<unit, string> = v3311 |> Error
                    let _run_target_args'_v3313 = v3321 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v3322 : Result<unit, string> = v3311 |> Error
                    let _run_target_args'_v3313 = v3322 
                    #endif
#else
                    let v3323 : Result<unit, string> = v3311 |> Error
                    let _run_target_args'_v3313 = v3323 
                    #endif
                    let v3324 : Result<unit, string> = _run_target_args'_v3313 
                    (* run_target_args'
                    let v3327 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v3328 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v3324 v3328 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v3329 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v3324 v3329 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v3330 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v3324 v3330 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    match v3324 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if FABLE_COMPILER_PYTHON
                    match v3324 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    match v3324 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#else
                    match v3324 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
                    // run_target_args' is_unit
                    ()
        | _ ->
            (* run_target_args'
            let v3332 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3333 : string = "$0.unwrap()"
            let v3334 : uint8 = Fable.Core.RustInterop.emitRustExpr v3251 v3333 
            let _run_target_args'_v3332 = v3334 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3335 : string = "$0.unwrap()"
            let v3336 : uint8 = Fable.Core.RustInterop.emitRustExpr v3251 v3335 
            let _run_target_args'_v3332 = v3336 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3337 : string = "$0.unwrap()"
            let v3338 : uint8 = Fable.Core.RustInterop.emitRustExpr v3251 v3337 
            let _run_target_args'_v3332 = v3338 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3339 : uint8 = match v3251 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v3332 = v3339 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3340 : uint8 = match v3251 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v3332 = v3340 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3341 : uint8 = match v3251 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v3332 = v3341 
            #endif
#else
            let v3342 : uint8 = match v3251 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v3332 = v3342 
            #endif
            let v3343 : uint8 = _run_target_args'_v3332 
            ()
    | US17_0(v3273) -> (* Ok *)
        match v3222 with
        | US9_0(v3274) -> (* Some *)
            let v3275 : string = $"spiral_wasm.main / retries: {v3273} / exception: '{v3274}'"
            (* run_target_args'
            let v3277 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3278 : string = "Err($0)"
            let v3279 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v3275 v3278 
            let _run_target_args'_v3277 = v3279 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3280 : string = "Err($0)"
            let v3281 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v3275 v3280 
            let _run_target_args'_v3277 = v3281 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3282 : string = "Err($0)"
            let v3283 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v3275 v3282 
            let _run_target_args'_v3277 = v3283 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3284 : Result<unit, string> = v3275 |> Error
            let _run_target_args'_v3277 = v3284 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3285 : Result<unit, string> = v3275 |> Error
            let _run_target_args'_v3277 = v3285 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3286 : Result<unit, string> = v3275 |> Error
            let _run_target_args'_v3277 = v3286 
            #endif
#else
            let v3287 : Result<unit, string> = v3275 |> Error
            let _run_target_args'_v3277 = v3287 
            #endif
            let v3288 : Result<unit, string> = _run_target_args'_v3277 
            (* run_target_args'
            let v3291 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3292 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v3288 v3292 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3293 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v3288 v3293 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3294 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v3288 v3294 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            match v3288 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if FABLE_COMPILER_PYTHON
            match v3288 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            match v3288 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#else
            match v3288 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
            // run_target_args' is_unit
            ()
        | _ ->
            ()
    0
let v0 : ((string []) -> int32) = closure0()
let main args = v0 args
()
