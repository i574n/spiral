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
    | US0_0 of f0_0 : std_string_String
    | US0_1
and [<Struct>] US3 =
    | US3_0
    | US3_1
    | US3_2
    | US3_3
    | US3_4
and [<Struct>] US2 =
    | US2_0 of f0_0 : US3
    | US2_1
and [<Struct>] US1 =
    | US1_0 of f0_0 : US2
    | US1_1
and Mut0 = {mutable l0 : int64}
and Mut1 = {mutable l0 : (string -> unit)}
and Mut2 = {mutable l0 : bool}
and Mut3 = {mutable l0 : string}
and Mut4 = {mutable l0 : US3}
and [<Struct>] US4 =
    | US4_0 of f0_0 : int64
    | US4_1
and [<Struct>] US5 =
    | US5_0
    | US5_1
    | US5_2
and [<Struct>] US6 =
    | US6_0 of f0_0 : US5
    | US6_1 of f1_0 : US5
    | US6_2 of f2_0 : US5
    | US6_3 of f3_0 : US5
    | US6_4 of f4_0 : US5
    | US6_5 of f5_0 : US5
    | US6_6 of f6_0 : US5
and [<Struct>] US7 =
    | US7_0 of f0_0 : string
    | US7_1
and [<Struct>] US8 =
    | US8_0 of f0_0 : Mut0 * f0_1 : Mut1 * f0_2 : Mut2 * f0_3 : Mut3 * f0_4 : Mut4 * f0_5 : int64 option
    | US8_1
and [<Struct>] US9 =
    | US9_0 of f0_0 : char
    | US9_1
and [<Struct>] US10 =
    | US10_0 of f0_0 : uint8 * f0_1 : US7
    | US10_1 of f1_0 : uint8 * f1_1 : US7
and [<Struct>] US11 =
    | US11_0 of f0_0 : US7
    | US11_1 of f1_0 : std_string_String
and [<Struct>] US12 =
    | US12_0 of f0_0 : uint8
    | US12_1 of f1_0 : std_string_String
let rec method0 () : clap_Command =
    let v0 : string = "command"
    let v1 : string = "r#\"" + v0 + "\"#"
    let v2 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v1 
    let v3 : string = "clap::Command::new($0)"
    let v4 : clap_Command = Fable.Core.RustInterop.emitRustExpr v2 v3 
    let v5 : string = "clap::Command::args_override_self($0, true)"
    let v6 : clap_Command = Fable.Core.RustInterop.emitRustExpr v4 v5 
    let v8 : unativeint = 0 |> unativeint 
    let v19 : unativeint = 1 |> unativeint 
    let v30 : unativeint = 0 |> unativeint 
    let v41 : bool = v19 = v30 
    let v56 : clap_builder_ValueRange =
        if v41 then
            let v51 : string = "clap::builder::ValueRange::new($0..)"
            let v52 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr v8 v51 
            v52
        else
            let v53 : string = "="
            let v54 : string = "clap::builder::ValueRange::new($0.." + v53 + "$1)"
            let v55 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr struct (v8, v19) v54 
            v55
    let v57 : string = "exception"
    let v58 : string = "r#\"" + v57 + "\"#"
    let v59 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v58 
    let v60 : string = "clap::Arg::new($0)"
    let v61 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v59 v60 
    let v62 : string = "$0.short($1)"
    let v63 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v61, 'e') v62 
    let v64 : string = "r#\"" + v57 + "\"#"
    let v65 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v64 
    let v66 : string = "$0.long($1)"
    let v67 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v63, v65) v66 
    let v68 : string = "$0.num_args($1)"
    let v69 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v67, v56) v68 
    let v70 : string = "$0.require_equals($1)"
    let v71 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v69, true) v70 
    let v72 : string = ""
    let v73 : string = "r#\"" + v72 + "\"#"
    let v74 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v73 
    let v75 : string = "$0.default_missing_value($1)"
    let v76 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v71, v74) v75 
    let v77 : string = "clap::Command::arg($0, $1)"
    let v78 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v6, v76) v77 
    let v79 : string = "trace_level"
    let v80 : string = "r#\"" + v79 + "\"#"
    let v81 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v80 
    let v82 : string = "clap::Arg::new($0)"
    let v83 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v81 v82 
    let v84 : string = "$0.short($1)"
    let v85 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v83, 't') v84 
    let v86 : string = "r#\"" + v79 + "\"#"
    let v87 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = "$0.long($1)"
    let v89 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v85, v87) v88 
    
    
    
    
    
    let v92 : string = "Critical"
    let v93 : (unit -> string) = v92.ToLower
    let v94 : string = v93 ()
    let v106 : string = "Warning"
    let v107 : (unit -> string) = v106.ToLower
    let v108 : string = v107 ()
    let v120 : string = "Info"
    let v121 : (unit -> string) = v120.ToLower
    let v122 : string = v121 ()
    let v134 : string = "Debug"
    let v135 : (unit -> string) = v134.ToLower
    let v136 : string = v135 ()
    let v148 : string = "Verbose"
    let v149 : (unit -> string) = v148.ToLower
    let v150 : string = v149 ()
    let v160 : string list = []
    let v162 : string list = v94 :: v160 
    let v173 : string list = v108 :: v162 
    let v184 : string list = v122 :: v173 
    let v195 : string list = v136 :: v184 
    let v206 : string list = v150 :: v195 
    let v232 : (string list -> (string [])) = List.toArray
    let v233 : (string []) = v232 v206
    let v243 : string = "$0.to_vec()"
    let v244 : Vec<string> = Fable.Core.RustInterop.emitRustExpr v233 v243 
    let v245 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v246 : bool = Fable.Core.RustInterop.emitRustExpr v244 v245 
    let v247 : string = "x"
    let v248 : string = Fable.Core.RustInterop.emitRustExpr () v247 
    (* run_target_args'
    let v260 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v261 : string = "&*$0"
    let v262 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v261 
    let _run_target_args'_v260 = v262 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v263 : string = "&*$0"
    let v264 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v263 
    let _run_target_args'_v260 = v264 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v265 : string = "&*$0"
    let v266 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v265 
    let _run_target_args'_v260 = v266 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v268 : Ref<Str> = v248 |> unbox<Ref<Str>>
    let _run_target_args'_v260 = v268 
    #endif
#if FABLE_COMPILER_PYTHON
    let v279 : Ref<Str> = v248 |> unbox<Ref<Str>>
    let _run_target_args'_v260 = v279 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v290 : Ref<Str> = v248 |> unbox<Ref<Str>>
    let _run_target_args'_v260 = v290 
    #endif
#else
    let v301 : Ref<Str> = v248 |> unbox<Ref<Str>>
    let _run_target_args'_v260 = v301 
    #endif
    let v311 : Ref<Str> = _run_target_args'_v260 
    (* run_target_args'
    let v345 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v346 : string = "String::from($0)"
    let v347 : std_string_String = Fable.Core.RustInterop.emitRustExpr v311 v346 
    let _run_target_args'_v345 = v347 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v348 : string = "String::from($0)"
    let v349 : std_string_String = Fable.Core.RustInterop.emitRustExpr v311 v348 
    let _run_target_args'_v345 = v349 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v350 : string = "String::from($0)"
    let v351 : std_string_String = Fable.Core.RustInterop.emitRustExpr v311 v350 
    let _run_target_args'_v345 = v351 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v353 : std_string_String = v311 |> unbox<std_string_String>
    let _run_target_args'_v345 = v353 
    #endif
#if FABLE_COMPILER_PYTHON
    let v364 : std_string_String = v311 |> unbox<std_string_String>
    let _run_target_args'_v345 = v364 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v375 : std_string_String = v311 |> unbox<std_string_String>
    let _run_target_args'_v345 = v375 
    #endif
#else
    let v386 : std_string_String = v311 |> unbox<std_string_String>
    let _run_target_args'_v345 = v386 
    #endif
    let v396 : std_string_String = _run_target_args'_v345 
    let v419 : string = "Box::new($0)"
    let v420 : Box<std_string_String> = Fable.Core.RustInterop.emitRustExpr v396 v419 
    let v421 : string = "Box::leak($0)"
    let v422 : Ref<Lifetime<StaticLifetime, Mut<std_string_String>>> = Fable.Core.RustInterop.emitRustExpr v420 v421 
    let v423 : string = "clap::builder::PossibleValue::new(&**$0)"
    let v424 : clap_builder_PossibleValue = Fable.Core.RustInterop.emitRustExpr v422 v423 
    let v425 : string = "true; $0 }).collect::<Vec<_>>()"
    let v426 : bool = Fable.Core.RustInterop.emitRustExpr v424 v425 
    let v427 : string = "_vec_map"
    let v428 : Vec<clap_builder_PossibleValue> = Fable.Core.RustInterop.emitRustExpr () v427 
    let v429 : string = "Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new($0))"
    let v430 : clap_builder_ValueParser = Fable.Core.RustInterop.emitRustExpr v428 v429 
    let v431 : string = "$0.value_parser($1)"
    let v432 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v89, v430) v431 
    let v433 : string = "clap::Command::arg($0, $1)"
    let v434 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v78, v432) v433 
    let v435 : string = "wasm"
    let v436 : string = "r#\"" + v435 + "\"#"
    let v437 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v436 
    let v438 : string = "clap::Arg::new($0)"
    let v439 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v437 v438 
    let v440 : string = "$0.short($1)"
    let v441 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v439, 'w') v440 
    let v442 : string = "r#\"" + v435 + "\"#"
    let v443 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v442 
    let v444 : string = "$0.long($1)"
    let v445 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v441, v443) v444 
    let v446 : string = "$0.required($1)"
    let v447 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v445, true) v446 
    let v448 : string = "clap::Command::arg($0, $1)"
    let v449 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v434, v447) v448 
    v449
and method1 () : string =
    let v0 : string = "trace_level"
    v0
and closure1 () (v0 : std_string_String) : US0 =
    US0_0(v0)
and method2 () : (std_string_String -> US0) =
    closure1()
and method6 (v0 : string) : string =
    v0
and method7 () : string =
    let v0 : string = ""
    v0
and closure3 () (v0 : string) : US7 =
    US7_0(v0)
and method8 () : (string -> US7) =
    closure3()
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
    let v37 : US5 = US5_1
    let v38 : US6 = US6_4(v37)
    let v39 : string = $"env.get_environment_variable / target: {v38} / var: {v0}"
    let v40 : string = failwith<string> v39
    let _run_target_args'_v20 = v40 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v41 : US5 = US5_2
    let v42 : US6 = US6_4(v41)
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
    let v114 : (string -> US7) = method8()
    let v115 : US7 option = v93 |> Option.map v114 
    let v163 : US7 = US7_1
    let v164 : US7 = v115 |> Option.defaultValue v163 
    let v178 : string =
        match v164 with
        | US7_1 -> (* None *)
            let v176 : string = ""
            v176
        | US7_0(v175) -> (* Some *)
            v175
    let _run_target_args'_v20 = v178 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v179 : US5 = US5_1
    let v180 : US6 = US6_1(v179)
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
    let v218 : (string -> US7) = method8()
    let v219 : US7 option = v197 |> Option.map v218 
    let v267 : US7 = US7_1
    let v268 : US7 = v219 |> Option.defaultValue v267 
    let v282 : string =
        match v268 with
        | US7_1 -> (* None *)
            let v280 : string = ""
            v280
        | US7_0(v279) -> (* Some *)
            v279
    let _run_target_args'_v20 = v282 
    #endif
    let v283 : string = _run_target_args'_v20 
    v283
and method4 () : struct (US2 * US4) =
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
    let v76 : US2 =
        if v72 then
            let v73 : US3 = US3_0
            US2_0(v73)
        else
            US2_1
    let v162 : US2 =
        match v76 with
        | US2_1 -> (* None *)
            let v79 : bool = "Debug" = v1
            let v83 : US2 =
                if v79 then
                    let v80 : US3 = US3_1
                    US2_0(v80)
                else
                    US2_1
            match v83 with
            | US2_1 -> (* None *)
                let v86 : bool = "Info" = v1
                let v90 : US2 =
                    if v86 then
                        let v87 : US3 = US3_2
                        US2_0(v87)
                    else
                        US2_1
                match v90 with
                | US2_1 -> (* None *)
                    let v93 : bool = "Warning" = v1
                    let v97 : US2 =
                        if v93 then
                            let v94 : US3 = US3_3
                            US2_0(v94)
                        else
                            US2_1
                    match v97 with
                    | US2_1 -> (* None *)
                        let v100 : bool = "Critical" = v1
                        let v104 : US2 =
                            if v100 then
                                let v101 : US3 = US3_4
                                US2_0(v101)
                            else
                                US2_1
                        match v104 with
                        | US2_1 -> (* None *)
                            let v107 : bool = v62 = v1
                            let v111 : US2 =
                                if v107 then
                                    let v108 : US3 = US3_0
                                    US2_0(v108)
                                else
                                    US2_1
                            match v111 with
                            | US2_1 -> (* None *)
                                let v114 : bool = v48 = v1
                                let v118 : US2 =
                                    if v114 then
                                        let v115 : US3 = US3_1
                                        US2_0(v115)
                                    else
                                        US2_1
                                match v118 with
                                | US2_1 -> (* None *)
                                    let v121 : bool = v34 = v1
                                    let v125 : US2 =
                                        if v121 then
                                            let v122 : US3 = US3_2
                                            US2_0(v122)
                                        else
                                            US2_1
                                    match v125 with
                                    | US2_1 -> (* None *)
                                        let v128 : bool = v20 = v1
                                        let v132 : US2 =
                                            if v128 then
                                                let v129 : US3 = US3_3
                                                US2_0(v129)
                                            else
                                                US2_1
                                        match v132 with
                                        | US2_1 -> (* None *)
                                            let v135 : bool = v6 = v1
                                            let v139 : US2 =
                                                if v135 then
                                                    let v136 : US3 = US3_4
                                                    US2_0(v136)
                                                else
                                                    US2_1
                                            match v139 with
                                            | US2_1 -> (* None *)
                                                US2_1
                                            | US2_0(v140) -> (* Some *)
                                                US2_0(v140)
                                        | US2_0(v133) -> (* Some *)
                                            US2_0(v133)
                                    | US2_0(v126) -> (* Some *)
                                        US2_0(v126)
                                | US2_0(v119) -> (* Some *)
                                    US2_0(v119)
                            | US2_0(v112) -> (* Some *)
                                US2_0(v112)
                        | US2_0(v105) -> (* Some *)
                            US2_0(v105)
                    | US2_0(v98) -> (* Some *)
                        US2_0(v98)
                | US2_0(v91) -> (* Some *)
                    US2_0(v91)
            | US2_0(v84) -> (* Some *)
                US2_0(v84)
        | US2_0(v77) -> (* Some *)
            US2_0(v77)
    let v163 : string = "AUTOMATION"
    let v164 : string = method5(v163)
    let v167 : string = "True"
    let v168 : bool = v164 <> v167 
    let v337 : US4 =
        if v168 then
            US4_1
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
            let v308 : int64 = v254 |> int64 
            US4_0(v308)
    struct (v162, v337)
and closure4 () (v0 : string) : unit =
    ()
and method3 (v0 : US3) : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let struct (v4 : US2, v5 : US4) = method4()
    let _run_target_args'_v3 = struct (v4, v5) 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : US2 = US2_1
    let v7 : US4 = US4_1
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
    let v384 : US4 =
        if v358 then
            US4_1
        else
            let v369 : string = $"near_sdk::env::block_timestamp()"
            let v370 : uint64 = Fable.Core.RustInterop.emitRustExpr () v369 
            let v372 : (uint64 -> int64) = int64
            let v373 : int64 = v372 v370
            US4_0(v373)
    let v385 : US2 = US2_1
    let _run_target_args'_v3 = struct (v385, v384) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v386 : US2, v387 : US4) = method4()
    let _run_target_args'_v3 = struct (v386, v387) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v388 : US2, v389 : US4) = method4()
    let _run_target_args'_v3 = struct (v388, v389) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v390 : US2, v391 : US4) = method4()
    let _run_target_args'_v3 = struct (v390, v391) 
    #endif
#else
    let struct (v392 : US2, v393 : US4) = method4()
    let _run_target_args'_v3 = struct (v392, v393) 
    #endif
    let struct (v394 : US2, v395 : US4) = _run_target_args'_v3 
    let v400 : Mut0 = {l0 = 1L} : Mut0
    let v401 : (string -> unit) = closure4()
    let v402 : Mut1 = {l0 = v401} : Mut1
    let v403 : Mut2 = {l0 = true} : Mut2
    let v404 : string = ""
    let v405 : Mut3 = {l0 = v404} : Mut3
    let v408 : US3 =
        match v394 with
        | US2_1 -> (* None *)
            v0
        | US2_0(v406) -> (* Some *)
            v406
    let v409 : Mut4 = {l0 = v408} : Mut4
    let v434 : int64 option =
        match v395 with
        | US4_1 -> (* None *)
            let v423 : int64 option = None
            v423
        | US4_0(v410) -> (* Some *)
            let v412 : int64 option = Some v410 
            v412
    struct (v400, v402, v403, v405, v409, v434)
and closure2 (v0 : US3) () : unit =
    let v1 : bool = TraceState.trace_state.IsNone
    if v1 then
        let struct (v2 : Mut0, v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : int64 option) = method3(v0)
        let v9 : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v9 
        ()
and closure6 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US3 = US3_0
        let struct (v2 : Mut0, v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : int64 option) = method3(v1)
        let v9 : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v9 
        ()
and closure7 () (v0 : int64) : US4 =
    US4_0(v0)
and method10 () : (int64 -> US4) =
    closure7()
and method11 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method12 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method9 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v433 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v445 : (int64 -> US4) = method10()
    let v446 : US4 option = v5 |> Option.map v445 
    let v494 : US4 = US4_1
    let v495 : US4 = v446 |> Option.defaultValue v494 
    let v831 : System.DateTime =
        match v495 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v800 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v801 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v800 = v801 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v802 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v800 = v802 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v804 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v800 = v804 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v814 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v800 = v814 
            #endif
#if FABLE_COMPILER_PYTHON
            let v815 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v800 = v815 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v816 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v800 = v816 
            #endif
#else
            let v817 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v800 = v817 
            #endif
            let v818 : System.DateTime = _run_target_args'_v800 
            v818
        | US4_0(v506) -> (* Some *)
            (* run_target_args'
            let v522 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v523 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v522 = v523 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v524 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v522 = v524 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v526 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v522 = v526 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v536 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v522 = v536 
            #endif
#if FABLE_COMPILER_PYTHON
            let v537 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v522 = v537 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v538 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v522 = v538 
            #endif
#else
            let v539 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v522 = v539 
            #endif
            let v540 : System.DateTime = _run_target_args'_v522 
            (* run_target_args'
            let v558 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v559 : (System.DateTime -> int64) = _.Ticks
            let v560 : int64 = v559 v540
            let _run_target_args'_v558 = v560 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v561 : (System.DateTime -> int64) = _.Ticks
            let v562 : int64 = v561 v540
            let _run_target_args'_v558 = v562 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v564 : int64 = null |> unbox<int64>
            let _run_target_args'_v558 = v564 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v574 : (System.DateTime -> int64) = _.Ticks
            let v575 : int64 = v574 v540
            let _run_target_args'_v558 = v575 
            #endif
#if FABLE_COMPILER_PYTHON
            let v576 : (System.DateTime -> int64) = _.Ticks
            let v577 : int64 = v576 v540
            let _run_target_args'_v558 = v577 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v578 : (System.DateTime -> int64) = _.Ticks
            let v579 : int64 = v578 v540
            let _run_target_args'_v558 = v579 
            #endif
#else
            let v580 : (System.DateTime -> int64) = _.Ticks
            let v581 : int64 = v580 v540
            let _run_target_args'_v558 = v581 
            #endif
            let v582 : int64 = _run_target_args'_v558 
            let v636 : int64 = v582 |> int64 
            let v655 : int64 = v636 - v506
            let v668 : System.TimeSpan = v655 |> System.TimeSpan 
            let v688 : (System.TimeSpan -> int32) = _.Hours
            let v689 : int32 = v688 v668
            let v700 : (System.TimeSpan -> int32) = _.Minutes
            let v701 : int32 = v700 v668
            let v712 : (System.TimeSpan -> int32) = _.Seconds
            let v713 : int32 = v712 v668
            let v724 : (System.TimeSpan -> int32) = _.Milliseconds
            let v725 : int32 = v724 v668
            let v775 : System.DateTime = System.DateTime (1, 1, 1, v689, v701, v713, v725)
            v775
    let v832 : string = method11()
    let v851 : bool = v832 = ""
    let v853 : string =
        if v851 then
            let v852 : string = "M-d-y hh:mm:ss tt"
            v852
        else
            v832
    let v854 : (string -> string) = v831.ToString
    let v855 : string = v854 v853
    let _run_target_args'_v433 = v855 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v895 : (int64 -> US4) = method10()
    let v896 : US4 option = v5 |> Option.map v895 
    let v944 : US4 = US4_1
    let v945 : US4 = v896 |> Option.defaultValue v944 
    let v1281 : System.DateTime =
        match v945 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1250 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1251 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1250 = v1251 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1252 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1250 = v1252 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1254 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1250 = v1254 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1264 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1250 = v1264 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1265 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1250 = v1265 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1266 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1250 = v1266 
            #endif
#else
            let v1267 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1250 = v1267 
            #endif
            let v1268 : System.DateTime = _run_target_args'_v1250 
            v1268
        | US4_0(v956) -> (* Some *)
            (* run_target_args'
            let v972 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v973 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v972 = v973 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v974 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v972 = v974 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v976 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v972 = v976 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v986 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v972 = v986 
            #endif
#if FABLE_COMPILER_PYTHON
            let v987 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v972 = v987 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v988 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v972 = v988 
            #endif
#else
            let v989 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v972 = v989 
            #endif
            let v990 : System.DateTime = _run_target_args'_v972 
            (* run_target_args'
            let v1008 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1009 : (System.DateTime -> int64) = _.Ticks
            let v1010 : int64 = v1009 v990
            let _run_target_args'_v1008 = v1010 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1011 : (System.DateTime -> int64) = _.Ticks
            let v1012 : int64 = v1011 v990
            let _run_target_args'_v1008 = v1012 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1014 : int64 = null |> unbox<int64>
            let _run_target_args'_v1008 = v1014 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1024 : (System.DateTime -> int64) = _.Ticks
            let v1025 : int64 = v1024 v990
            let _run_target_args'_v1008 = v1025 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1026 : (System.DateTime -> int64) = _.Ticks
            let v1027 : int64 = v1026 v990
            let _run_target_args'_v1008 = v1027 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1028 : (System.DateTime -> int64) = _.Ticks
            let v1029 : int64 = v1028 v990
            let _run_target_args'_v1008 = v1029 
            #endif
#else
            let v1030 : (System.DateTime -> int64) = _.Ticks
            let v1031 : int64 = v1030 v990
            let _run_target_args'_v1008 = v1031 
            #endif
            let v1032 : int64 = _run_target_args'_v1008 
            let v1086 : int64 = v1032 |> int64 
            let v1105 : int64 = v1086 - v956
            let v1118 : System.TimeSpan = v1105 |> System.TimeSpan 
            let v1138 : (System.TimeSpan -> int32) = _.Hours
            let v1139 : int32 = v1138 v1118
            let v1150 : (System.TimeSpan -> int32) = _.Minutes
            let v1151 : int32 = v1150 v1118
            let v1162 : (System.TimeSpan -> int32) = _.Seconds
            let v1163 : int32 = v1162 v1118
            let v1174 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1175 : int32 = v1174 v1118
            let v1225 : System.DateTime = System.DateTime (1, 1, 1, v1139, v1151, v1163, v1175)
            v1225
    let v1282 : string = method11()
    let v1301 : bool = v1282 = ""
    let v1303 : string =
        if v1301 then
            let v1302 : string = "M-d-y hh:mm:ss tt"
            v1302
        else
            v1282
    let v1304 : (string -> string) = v1281.ToString
    let v1305 : string = v1304 v1303
    let _run_target_args'_v433 = v1305 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1334 : string = $"near_sdk::env::block_timestamp()"
    let v1335 : uint64 = Fable.Core.RustInterop.emitRustExpr () v1334 
    let v1347 : (int64 -> US4) = method10()
    let v1348 : US4 option = v5 |> Option.map v1347 
    let v1396 : US4 = US4_1
    let v1397 : US4 = v1348 |> Option.defaultValue v1396 
    let v1423 : uint64 =
        match v1397 with
        | US4_1 -> (* None *)
            v1335
        | US4_0(v1408) -> (* Some *)
            let v1410 : (int64 -> uint64) = uint64
            let v1411 : uint64 = v1410 v1408
            let v1421 : uint64 = v1335 - v1411
            v1421
    let v1424 : uint64 = v1423 / 1000000000UL
    let v1425 : uint64 = v1424 % 60UL
    let v1426 : uint64 = v1424 / 60UL
    let v1427 : uint64 = v1426 % 60UL
    let v1428 : uint64 = v1424 / 3600UL
    let v1429 : uint64 = v1428 % 24UL
    let v1430 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v1431 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1429, v1427, v1425) v1430 
    let v1432 : string = "fable_library_rust::String_::fromString($0)"
    let v1433 : string = Fable.Core.RustInterop.emitRustExpr v1431 v1432 
    let _run_target_args'_v433 = v1433 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1445 : (int64 -> US4) = method10()
    let v1446 : US4 option = v5 |> Option.map v1445 
    let v1494 : US4 = US4_1
    let v1495 : US4 = v1446 |> Option.defaultValue v1494 
    let v1831 : System.DateTime =
        match v1495 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1800 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1801 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1800 = v1801 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1802 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1800 = v1802 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1804 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1800 = v1804 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1814 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1800 = v1814 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1815 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1800 = v1815 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1816 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1800 = v1816 
            #endif
#else
            let v1817 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1800 = v1817 
            #endif
            let v1818 : System.DateTime = _run_target_args'_v1800 
            v1818
        | US4_0(v1506) -> (* Some *)
            (* run_target_args'
            let v1522 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1523 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1522 = v1523 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1524 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1522 = v1524 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1526 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1522 = v1526 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1536 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1522 = v1536 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1537 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1522 = v1537 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1538 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1522 = v1538 
            #endif
#else
            let v1539 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1522 = v1539 
            #endif
            let v1540 : System.DateTime = _run_target_args'_v1522 
            (* run_target_args'
            let v1558 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1559 : (System.DateTime -> int64) = _.Ticks
            let v1560 : int64 = v1559 v1540
            let _run_target_args'_v1558 = v1560 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1561 : (System.DateTime -> int64) = _.Ticks
            let v1562 : int64 = v1561 v1540
            let _run_target_args'_v1558 = v1562 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1564 : int64 = null |> unbox<int64>
            let _run_target_args'_v1558 = v1564 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1574 : (System.DateTime -> int64) = _.Ticks
            let v1575 : int64 = v1574 v1540
            let _run_target_args'_v1558 = v1575 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1576 : (System.DateTime -> int64) = _.Ticks
            let v1577 : int64 = v1576 v1540
            let _run_target_args'_v1558 = v1577 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1578 : (System.DateTime -> int64) = _.Ticks
            let v1579 : int64 = v1578 v1540
            let _run_target_args'_v1558 = v1579 
            #endif
#else
            let v1580 : (System.DateTime -> int64) = _.Ticks
            let v1581 : int64 = v1580 v1540
            let _run_target_args'_v1558 = v1581 
            #endif
            let v1582 : int64 = _run_target_args'_v1558 
            let v1636 : int64 = v1582 |> int64 
            let v1655 : int64 = v1636 - v1506
            let v1668 : System.TimeSpan = v1655 |> System.TimeSpan 
            let v1688 : (System.TimeSpan -> int32) = _.Hours
            let v1689 : int32 = v1688 v1668
            let v1700 : (System.TimeSpan -> int32) = _.Minutes
            let v1701 : int32 = v1700 v1668
            let v1712 : (System.TimeSpan -> int32) = _.Seconds
            let v1713 : int32 = v1712 v1668
            let v1724 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1725 : int32 = v1724 v1668
            let v1775 : System.DateTime = System.DateTime (1, 1, 1, v1689, v1701, v1713, v1725)
            v1775
    let v1832 : string = method12()
    let v1851 : bool = v1832 = ""
    let v1853 : string =
        if v1851 then
            let v1852 : string = "M-d-y hh:mm:ss tt"
            v1852
        else
            v1832
    let v1854 : (string -> string) = v1831.ToString
    let v1855 : string = v1854 v1853
    let _run_target_args'_v433 = v1855 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1895 : (int64 -> US4) = method10()
    let v1896 : US4 option = v5 |> Option.map v1895 
    let v1944 : US4 = US4_1
    let v1945 : US4 = v1896 |> Option.defaultValue v1944 
    let v2281 : System.DateTime =
        match v1945 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v2250 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2251 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2250 = v2251 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2252 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2250 = v2252 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2254 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v2250 = v2254 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2264 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2250 = v2264 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2265 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2250 = v2265 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2266 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2250 = v2266 
            #endif
#else
            let v2267 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2250 = v2267 
            #endif
            let v2268 : System.DateTime = _run_target_args'_v2250 
            v2268
        | US4_0(v1956) -> (* Some *)
            (* run_target_args'
            let v1972 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1973 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1972 = v1973 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1974 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1972 = v1974 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1976 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1972 = v1976 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1986 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1972 = v1986 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1987 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1972 = v1987 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1988 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1972 = v1988 
            #endif
#else
            let v1989 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1972 = v1989 
            #endif
            let v1990 : System.DateTime = _run_target_args'_v1972 
            (* run_target_args'
            let v2008 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2009 : (System.DateTime -> int64) = _.Ticks
            let v2010 : int64 = v2009 v1990
            let _run_target_args'_v2008 = v2010 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2011 : (System.DateTime -> int64) = _.Ticks
            let v2012 : int64 = v2011 v1990
            let _run_target_args'_v2008 = v2012 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2014 : int64 = null |> unbox<int64>
            let _run_target_args'_v2008 = v2014 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2024 : (System.DateTime -> int64) = _.Ticks
            let v2025 : int64 = v2024 v1990
            let _run_target_args'_v2008 = v2025 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2026 : (System.DateTime -> int64) = _.Ticks
            let v2027 : int64 = v2026 v1990
            let _run_target_args'_v2008 = v2027 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2028 : (System.DateTime -> int64) = _.Ticks
            let v2029 : int64 = v2028 v1990
            let _run_target_args'_v2008 = v2029 
            #endif
#else
            let v2030 : (System.DateTime -> int64) = _.Ticks
            let v2031 : int64 = v2030 v1990
            let _run_target_args'_v2008 = v2031 
            #endif
            let v2032 : int64 = _run_target_args'_v2008 
            let v2086 : int64 = v2032 |> int64 
            let v2105 : int64 = v2086 - v1956
            let v2118 : System.TimeSpan = v2105 |> System.TimeSpan 
            let v2138 : (System.TimeSpan -> int32) = _.Hours
            let v2139 : int32 = v2138 v2118
            let v2150 : (System.TimeSpan -> int32) = _.Minutes
            let v2151 : int32 = v2150 v2118
            let v2162 : (System.TimeSpan -> int32) = _.Seconds
            let v2163 : int32 = v2162 v2118
            let v2174 : (System.TimeSpan -> int32) = _.Milliseconds
            let v2175 : int32 = v2174 v2118
            let v2225 : System.DateTime = System.DateTime (1, 1, 1, v2139, v2151, v2163, v2175)
            v2225
    let v2282 : string = method12()
    let v2301 : bool = v2282 = ""
    let v2303 : string =
        if v2301 then
            let v2302 : string = "M-d-y hh:mm:ss tt"
            v2302
        else
            v2282
    let v2304 : (string -> string) = v2281.ToString
    let v2305 : string = v2304 v2303
    let _run_target_args'_v433 = v2305 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2345 : (int64 -> US4) = method10()
    let v2346 : US4 option = v5 |> Option.map v2345 
    let v2394 : US4 = US4_1
    let v2395 : US4 = v2346 |> Option.defaultValue v2394 
    let v2731 : System.DateTime =
        match v2395 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v2700 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2701 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2700 = v2701 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2702 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2700 = v2702 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2704 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v2700 = v2704 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2714 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2700 = v2714 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2715 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2700 = v2715 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2716 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2700 = v2716 
            #endif
#else
            let v2717 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2700 = v2717 
            #endif
            let v2718 : System.DateTime = _run_target_args'_v2700 
            v2718
        | US4_0(v2406) -> (* Some *)
            (* run_target_args'
            let v2422 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2423 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2422 = v2423 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2424 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2422 = v2424 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2426 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v2422 = v2426 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2436 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2422 = v2436 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2437 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2422 = v2437 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2438 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2422 = v2438 
            #endif
#else
            let v2439 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2422 = v2439 
            #endif
            let v2440 : System.DateTime = _run_target_args'_v2422 
            (* run_target_args'
            let v2458 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2459 : (System.DateTime -> int64) = _.Ticks
            let v2460 : int64 = v2459 v2440
            let _run_target_args'_v2458 = v2460 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2461 : (System.DateTime -> int64) = _.Ticks
            let v2462 : int64 = v2461 v2440
            let _run_target_args'_v2458 = v2462 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2464 : int64 = null |> unbox<int64>
            let _run_target_args'_v2458 = v2464 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2474 : (System.DateTime -> int64) = _.Ticks
            let v2475 : int64 = v2474 v2440
            let _run_target_args'_v2458 = v2475 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2476 : (System.DateTime -> int64) = _.Ticks
            let v2477 : int64 = v2476 v2440
            let _run_target_args'_v2458 = v2477 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2478 : (System.DateTime -> int64) = _.Ticks
            let v2479 : int64 = v2478 v2440
            let _run_target_args'_v2458 = v2479 
            #endif
#else
            let v2480 : (System.DateTime -> int64) = _.Ticks
            let v2481 : int64 = v2480 v2440
            let _run_target_args'_v2458 = v2481 
            #endif
            let v2482 : int64 = _run_target_args'_v2458 
            let v2536 : int64 = v2482 |> int64 
            let v2555 : int64 = v2536 - v2406
            let v2568 : System.TimeSpan = v2555 |> System.TimeSpan 
            let v2588 : (System.TimeSpan -> int32) = _.Hours
            let v2589 : int32 = v2588 v2568
            let v2600 : (System.TimeSpan -> int32) = _.Minutes
            let v2601 : int32 = v2600 v2568
            let v2612 : (System.TimeSpan -> int32) = _.Seconds
            let v2613 : int32 = v2612 v2568
            let v2624 : (System.TimeSpan -> int32) = _.Milliseconds
            let v2625 : int32 = v2624 v2568
            let v2675 : System.DateTime = System.DateTime (1, 1, 1, v2589, v2601, v2613, v2625)
            v2675
    let v2732 : string = method12()
    let v2751 : bool = v2732 = ""
    let v2753 : string =
        if v2751 then
            let v2752 : string = "M-d-y hh:mm:ss tt"
            v2752
        else
            v2732
    let v2754 : (string -> string) = v2731.ToString
    let v2755 : string = v2754 v2753
    let _run_target_args'_v433 = v2755 
    #endif
#else
    let v2795 : (int64 -> US4) = method10()
    let v2796 : US4 option = v5 |> Option.map v2795 
    let v2844 : US4 = US4_1
    let v2845 : US4 = v2796 |> Option.defaultValue v2844 
    let v3181 : System.DateTime =
        match v2845 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v3150 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3151 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3150 = v3151 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3152 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3150 = v3152 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3154 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v3150 = v3154 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3164 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3150 = v3164 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3165 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3150 = v3165 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3166 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3150 = v3166 
            #endif
#else
            let v3167 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v3150 = v3167 
            #endif
            let v3168 : System.DateTime = _run_target_args'_v3150 
            v3168
        | US4_0(v2856) -> (* Some *)
            (* run_target_args'
            let v2872 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2873 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2872 = v2873 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2874 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2872 = v2874 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2876 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v2872 = v2876 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2886 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2872 = v2886 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2887 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2872 = v2887 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2888 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2872 = v2888 
            #endif
#else
            let v2889 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v2872 = v2889 
            #endif
            let v2890 : System.DateTime = _run_target_args'_v2872 
            (* run_target_args'
            let v2908 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2909 : (System.DateTime -> int64) = _.Ticks
            let v2910 : int64 = v2909 v2890
            let _run_target_args'_v2908 = v2910 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2911 : (System.DateTime -> int64) = _.Ticks
            let v2912 : int64 = v2911 v2890
            let _run_target_args'_v2908 = v2912 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2914 : int64 = null |> unbox<int64>
            let _run_target_args'_v2908 = v2914 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2924 : (System.DateTime -> int64) = _.Ticks
            let v2925 : int64 = v2924 v2890
            let _run_target_args'_v2908 = v2925 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2926 : (System.DateTime -> int64) = _.Ticks
            let v2927 : int64 = v2926 v2890
            let _run_target_args'_v2908 = v2927 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2928 : (System.DateTime -> int64) = _.Ticks
            let v2929 : int64 = v2928 v2890
            let _run_target_args'_v2908 = v2929 
            #endif
#else
            let v2930 : (System.DateTime -> int64) = _.Ticks
            let v2931 : int64 = v2930 v2890
            let _run_target_args'_v2908 = v2931 
            #endif
            let v2932 : int64 = _run_target_args'_v2908 
            let v2986 : int64 = v2932 |> int64 
            let v3005 : int64 = v2986 - v2856
            let v3018 : System.TimeSpan = v3005 |> System.TimeSpan 
            let v3038 : (System.TimeSpan -> int32) = _.Hours
            let v3039 : int32 = v3038 v3018
            let v3050 : (System.TimeSpan -> int32) = _.Minutes
            let v3051 : int32 = v3050 v3018
            let v3062 : (System.TimeSpan -> int32) = _.Seconds
            let v3063 : int32 = v3062 v3018
            let v3074 : (System.TimeSpan -> int32) = _.Milliseconds
            let v3075 : int32 = v3074 v3018
            let v3125 : System.DateTime = System.DateTime (1, 1, 1, v3039, v3051, v3063, v3075)
            v3125
    let v3182 : string = method12()
    let v3201 : bool = v3182 = ""
    let v3203 : string =
        if v3201 then
            let v3202 : string = "M-d-y hh:mm:ss tt"
            v3202
        else
            v3182
    let v3204 : (string -> string) = v3181.ToString
    let v3205 : string = v3204 v3203
    let _run_target_args'_v433 = v3205 
    #endif
    let v3234 : string = _run_target_args'_v433 
    v3234
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
        let v19 : US9 =
            if v3 then
                US9_0(' ')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US9_0('\t')
                else
                    let v8 : int64 = v5 - 1L
                    let v9 : bool = v8 = 0L
                    if v9 then
                        US9_0('\r')
                    else
                        let v11 : int64 = v8 - 1L
                        let v12 : bool = v11 = 0L
                        if v12 then
                            US9_0('\n')
                        else
                            let v14 : int64 = v11 - 1L
                            US9_1
        let v23 : char =
            match v19 with
            | US9_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US9_0(v20) -> (* Some *)
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
        let v11 : US9 =
            if v3 then
                US9_0(' ')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US9_0('/')
                else
                    let v8 : int64 = v5 - 1L
                    US9_1
        let v15 : char =
            match v11 with
            | US9_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US9_0(v12) -> (* Some *)
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
    let v537 : string = v0.[int v3..int v1]
    let v548 : int32 = v537.Length
    let v549 : int32 = method26(v537, v548)
    let v1083 : string = v537.[int 0..int v549]
    v1083
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
and closure8 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure10 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure9 () (v0 : string) : unit =
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure10(v0)
    let v22 : unit = (fun () -> v21 (); v20) ()
    ()
and closure5 (v0 : (string [])) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure6()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US3 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v556 : US8 =
        if v116 then
            US8_1
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
            let v340 : (unit -> unit) = closure8(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure9()
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
            let v500 : int32 = v487 |> int32 
            let v531 : string = ""
            let v532 : bool = v228 <> v531 
            let v543 : bool =
                if v532 then
                    let v542 : bool = v500 <= 1
                    v542
                else
                    false
            if v543 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v531
                let v544 : string = "true; $0.into_iter().for_each(|x| { //"
                let v545 : bool = Fable.Core.RustInterop.emitRustExpr v485 v544 
                let v546 : string = "x"
                let v547 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v546 
                let v548 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v549 : bool = Fable.Core.RustInterop.emitRustExpr v547 v548 
                let v550 : string = $"true"
                let v551 : bool = Fable.Core.RustInterop.emitRustExpr () v550 
                let v552 : string = "true; }); //"
                let v553 : bool = Fable.Core.RustInterop.emitRustExpr () v552 
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
            let v554 : (string -> unit) = v298.l0
            v554 v228
            US8_0(v297, v298, v299, v300, v301, v302)
    let v588 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v588 
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
        let v7 : US9 =
            if v3 then
                US9_0('\\')
            else
                let v5 : int64 = v1 - 1L
                US9_1
        let v11 : char =
            match v7 with
            | US9_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US9_0(v8) -> (* Some *)
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
and closure11 () (v0 : std_string_String) : string =
    let v1 : string = "fable_library_rust::String_::fromString($0)"
    let v2 : string = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : int32 = v2.Length
    let v4 : int32 = 0
    let v5 : int32 = method30(v2, v3, v4)
    let v539 : string = v2.[int v5..int v3]
    let v550 : int32 = v539.Length
    let v551 : int32 = method32(v539, v550)
    let v1085 : string = v539.[int 0..int v551]
    v1085
and method29 () : (std_string_String -> string) =
    closure11()
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
and closure12 (v0 : string) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure6()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US3 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v556 : US8 =
        if v116 then
            US8_1
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
            let v340 : (unit -> unit) = closure8(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure9()
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
            let v500 : int32 = v487 |> int32 
            let v531 : string = ""
            let v532 : bool = v228 <> v531 
            let v543 : bool =
                if v532 then
                    let v542 : bool = v500 <= 1
                    v542
                else
                    false
            if v543 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v531
                let v544 : string = "true; $0.into_iter().for_each(|x| { //"
                let v545 : bool = Fable.Core.RustInterop.emitRustExpr v485 v544 
                let v546 : string = "x"
                let v547 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v546 
                let v548 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v549 : bool = Fable.Core.RustInterop.emitRustExpr v547 v548 
                let v550 : string = $"true"
                let v551 : bool = Fable.Core.RustInterop.emitRustExpr () v550 
                let v552 : string = "true; }); //"
                let v553 : bool = Fable.Core.RustInterop.emitRustExpr () v552 
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
            let v554 : (string -> unit) = v298.l0
            v554 v228
            US8_0(v297, v298, v299, v300, v301, v302)
    let v588 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v588 
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
and closure13 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) () : unit =
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure6()
    let v34 : unit = (fun () -> v33 (); v32) ()
    let struct (v72 : Mut0, v73 : Mut1, v74 : Mut2, v75 : Mut3, v76 : Mut4, v77 : int64 option) = TraceState.trace_state.Value
    let v112 : US3 = v76.l0
    let v113 : bool = v74.l0
    let v114 : bool = v113 = false
    let v117 : bool =
        if v114 then
            false
        else
            let v115 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v112
            let v116 : bool = 0 >= v115
            v116
    let v118 : bool = v117 = false
    let v558 : US8 =
        if v118 then
            US8_1
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
            let v342 : (unit -> unit) = closure8(v299)
            let v343 : unit = (fun () -> v342 (); v341) ()
            let v350 : (string -> unit) = closure9()
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
            let v502 : int32 = v489 |> int32 
            let v533 : string = ""
            let v534 : bool = v230 <> v533 
            let v545 : bool =
                if v534 then
                    let v544 : bool = v502 <= 1
                    v544
                else
                    false
            if v545 then
                v302.l0 <- v384
                ()
            else
                v302.l0 <- v533
                let v546 : string = "true; $0.into_iter().for_each(|x| { //"
                let v547 : bool = Fable.Core.RustInterop.emitRustExpr v487 v546 
                let v548 : string = "x"
                let v549 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v548 
                let v550 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v551 : bool = Fable.Core.RustInterop.emitRustExpr v549 v550 
                let v552 : string = $"true"
                let v553 : bool = Fable.Core.RustInterop.emitRustExpr () v552 
                let v554 : string = "true; }); //"
                let v555 : bool = Fable.Core.RustInterop.emitRustExpr () v554 
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
            let v556 : (string -> unit) = v300.l0
            v556 v230
            US8_0(v299, v300, v301, v302, v303, v304)
    let v590 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v590 
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
and closure14 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure6()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US3 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 0 >= v114
            v115
    let v117 : bool = v116 = false
    let v557 : US8 =
        if v117 then
            US8_1
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
            let v341 : (unit -> unit) = closure8(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure9()
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
            let v501 : int32 = v488 |> int32 
            let v532 : string = ""
            let v533 : bool = v229 <> v532 
            let v544 : bool =
                if v533 then
                    let v543 : bool = v501 <= 1
                    v543
                else
                    false
            if v544 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v532
                let v545 : string = "true; $0.into_iter().for_each(|x| { //"
                let v546 : bool = Fable.Core.RustInterop.emitRustExpr v486 v545 
                let v547 : string = "x"
                let v548 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v547 
                let v549 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v550 : bool = Fable.Core.RustInterop.emitRustExpr v548 v549 
                let v551 : string = $"true"
                let v552 : bool = Fable.Core.RustInterop.emitRustExpr () v551 
                let v553 : string = "true; }); //"
                let v554 : bool = Fable.Core.RustInterop.emitRustExpr () v553 
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
            let v555 : (string -> unit) = v299.l0
            v555 v229
            US8_0(v298, v299, v300, v301, v302, v303)
    let v589 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v589 
    ()
and closure16 (v0 : std_string_String) () : unit =
    let v1 : (std_string_String -> unit) = System.Console.WriteLine
    v1 v0
and closure15 () (v0 : std_string_String) : unit =
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure16(v0)
    let v22 : unit = (fun () -> v21 (); v20) ()
    ()
and closure17 () () : unit =
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6()
    let v31 : unit = (fun () -> v30 (); v29) ()
    let struct (v69 : Mut0, v70 : Mut1, v71 : Mut2, v72 : Mut3, v73 : Mut4, v74 : int64 option) = TraceState.trace_state.Value
    let v109 : US3 = v73.l0
    let v110 : bool = v71.l0
    let v111 : bool = v110 = false
    let v114 : bool =
        if v111 then
            false
        else
            let v112 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v109
            let v113 : bool = 2 >= v112
            v113
    let v115 : bool = v114 = false
    let v445 : US8 =
        if v115 then
            US8_1
        else
            let v146 : unit = ()
            let v147 : unit = (fun () -> v30 (); v146) ()
            let struct (v185 : Mut0, v186 : Mut1, v187 : Mut2, v188 : Mut3, v189 : Mut4, v190 : int64 option) = TraceState.trace_state.Value
            let v227 : unit = ()
            let v228 : (unit -> unit) = closure8(v185)
            let v229 : unit = (fun () -> v228 (); v227) ()
            let v236 : string = " "
            let v237 : (string -> unit) = closure9()
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
            let v389 : int32 = v376 |> int32 
            let v420 : string = ""
            let v421 : bool = v236 <> v420 
            let v432 : bool =
                if v421 then
                    let v431 : bool = v389 <= 1
                    v431
                else
                    false
            if v432 then
                v188.l0 <- v271
                ()
            else
                v188.l0 <- v420
                let v433 : string = "true; $0.into_iter().for_each(|x| { //"
                let v434 : bool = Fable.Core.RustInterop.emitRustExpr v374 v433 
                let v435 : string = "x"
                let v436 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v435 
                let v437 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v438 : bool = Fable.Core.RustInterop.emitRustExpr v436 v437 
                let v439 : string = $"true"
                let v440 : bool = Fable.Core.RustInterop.emitRustExpr () v439 
                let v441 : string = "true; }); //"
                let v442 : bool = Fable.Core.RustInterop.emitRustExpr () v441 
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
            let v443 : (string -> unit) = v186.l0
            v443 v236
            US8_0(v185, v186, v187, v188, v189, v190)
    let v477 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v477 
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
and closure18 (v0 : uint8, v1 : uint64, v2 : float) () : unit =
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure6()
    let v34 : unit = (fun () -> v33 (); v32) ()
    let struct (v72 : Mut0, v73 : Mut1, v74 : Mut2, v75 : Mut3, v76 : Mut4, v77 : int64 option) = TraceState.trace_state.Value
    let v112 : US3 = v76.l0
    let v113 : bool = v74.l0
    let v114 : bool = v113 = false
    let v117 : bool =
        if v114 then
            false
        else
            let v115 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v112
            let v116 : bool = 2 >= v115
            v116
    let v118 : bool = v117 = false
    let v558 : US8 =
        if v118 then
            US8_1
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
            let v342 : (unit -> unit) = closure8(v299)
            let v343 : unit = (fun () -> v342 (); v341) ()
            let v350 : (string -> unit) = closure9()
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
            let v502 : int32 = v489 |> int32 
            let v533 : string = ""
            let v534 : bool = v230 <> v533 
            let v545 : bool =
                if v534 then
                    let v544 : bool = v502 <= 1
                    v544
                else
                    false
            if v545 then
                v302.l0 <- v384
                ()
            else
                v302.l0 <- v533
                let v546 : string = "true; $0.into_iter().for_each(|x| { //"
                let v547 : bool = Fable.Core.RustInterop.emitRustExpr v487 v546 
                let v548 : string = "x"
                let v549 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v548 
                let v550 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v551 : bool = Fable.Core.RustInterop.emitRustExpr v549 v550 
                let v552 : string = $"true"
                let v553 : bool = Fable.Core.RustInterop.emitRustExpr () v552 
                let v554 : string = "true; }); //"
                let v555 : bool = Fable.Core.RustInterop.emitRustExpr () v554 
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
            let v556 : (string -> unit) = v300.l0
            v556 v230
            US8_0(v299, v300, v301, v302, v303, v304)
    let v590 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v590 
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
and closure20 (v0 : bool, v1 : uint64, v2 : float, v3 : u128, v4 : float) () : unit =
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6()
    let v36 : unit = (fun () -> v35 (); v34) ()
    let struct (v74 : Mut0, v75 : Mut1, v76 : Mut2, v77 : Mut3, v78 : Mut4, v79 : int64 option) = TraceState.trace_state.Value
    let v114 : US3 = v78.l0
    let v115 : bool = v76.l0
    let v116 : bool = v115 = false
    let v119 : bool =
        if v116 then
            false
        else
            let v117 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v114
            let v118 : bool = 2 >= v117
            v118
    let v120 : bool = v119 = false
    let v560 : US8 =
        if v120 then
            US8_1
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
            let v344 : (unit -> unit) = closure8(v301)
            let v345 : unit = (fun () -> v344 (); v343) ()
            let v352 : (string -> unit) = closure9()
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
            let v504 : int32 = v491 |> int32 
            let v535 : string = ""
            let v536 : bool = v232 <> v535 
            let v547 : bool =
                if v536 then
                    let v546 : bool = v504 <= 1
                    v546
                else
                    false
            if v547 then
                v304.l0 <- v386
                ()
            else
                v304.l0 <- v535
                let v548 : string = "true; $0.into_iter().for_each(|x| { //"
                let v549 : bool = Fable.Core.RustInterop.emitRustExpr v489 v548 
                let v550 : string = "x"
                let v551 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v550 
                let v552 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v553 : bool = Fable.Core.RustInterop.emitRustExpr v551 v552 
                let v554 : string = $"true"
                let v555 : bool = Fable.Core.RustInterop.emitRustExpr () v554 
                let v556 : string = "true; }); //"
                let v557 : bool = Fable.Core.RustInterop.emitRustExpr () v556 
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
            let v558 : (string -> unit) = v302.l0
            v558 v232
            US8_0(v301, v302, v303, v304, v305, v306)
    let v592 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v592 
    ()
and closure19 () (v0 : near_workspaces_result_ExecutionOutcome) : unit =
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
    let v621 : unit = ()
    let v622 : (unit -> unit) = closure20(v2, v6, v20, v24, v28)
    let v623 : unit = (fun () -> v622 (); v621) ()
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
and closure21 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure6()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US3 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v556 : US8 =
        if v116 then
            US8_1
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
            let v340 : (unit -> unit) = closure8(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure9()
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
            let v500 : int32 = v487 |> int32 
            let v531 : string = ""
            let v532 : bool = v228 <> v531 
            let v543 : bool =
                if v532 then
                    let v542 : bool = v500 <= 1
                    v542
                else
                    false
            if v543 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v531
                let v544 : string = "true; $0.into_iter().for_each(|x| { //"
                let v545 : bool = Fable.Core.RustInterop.emitRustExpr v485 v544 
                let v546 : string = "x"
                let v547 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v546 
                let v548 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v549 : bool = Fable.Core.RustInterop.emitRustExpr v547 v548 
                let v550 : string = $"true"
                let v551 : bool = Fable.Core.RustInterop.emitRustExpr () v550 
                let v552 : string = "true; }); //"
                let v553 : bool = Fable.Core.RustInterop.emitRustExpr () v552 
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
            let v554 : (string -> unit) = v298.l0
            v554 v228
            US8_0(v297, v298, v299, v300, v301, v302)
    let v588 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v588 
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
and closure22 (v0 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>, v1 : int32) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure6()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US3 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 0 >= v114
            v115
    let v117 : bool = v116 = false
    let v557 : US8 =
        if v117 then
            US8_1
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
            let v341 : (unit -> unit) = closure8(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure9()
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
            let v501 : int32 = v488 |> int32 
            let v532 : string = ""
            let v533 : bool = v229 <> v532 
            let v544 : bool =
                if v533 then
                    let v543 : bool = v501 <= 1
                    v543
                else
                    false
            if v544 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v532
                let v545 : string = "true; $0.into_iter().for_each(|x| { //"
                let v546 : bool = Fable.Core.RustInterop.emitRustExpr v486 v545 
                let v547 : string = "x"
                let v548 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v547 
                let v549 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v550 : bool = Fable.Core.RustInterop.emitRustExpr v548 v549 
                let v551 : string = $"true"
                let v552 : bool = Fable.Core.RustInterop.emitRustExpr () v551 
                let v553 : string = "true; }); //"
                let v554 : bool = Fable.Core.RustInterop.emitRustExpr () v553 
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
            let v555 : (string -> unit) = v299.l0
            v555 v229
            US8_0(v298, v299, v300, v301, v302, v303)
    let v589 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v589 
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
and closure23 (v0 : Vec<near_workspaces_result_ExecutionOutcome>, v1 : int32) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure6()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US3 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 0 >= v114
            v115
    let v117 : bool = v116 = false
    let v557 : US8 =
        if v117 then
            US8_1
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
            let v341 : (unit -> unit) = closure8(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure9()
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
            let v501 : int32 = v488 |> int32 
            let v532 : string = ""
            let v533 : bool = v229 <> v532 
            let v544 : bool =
                if v533 then
                    let v543 : bool = v501 <= 1
                    v543
                else
                    false
            if v544 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v532
                let v545 : string = "true; $0.into_iter().for_each(|x| { //"
                let v546 : bool = Fable.Core.RustInterop.emitRustExpr v486 v545 
                let v547 : string = "x"
                let v548 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v547 
                let v549 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v550 : bool = Fable.Core.RustInterop.emitRustExpr v548 v549 
                let v551 : string = $"true"
                let v552 : bool = Fable.Core.RustInterop.emitRustExpr () v551 
                let v553 : string = "true; }); //"
                let v554 : bool = Fable.Core.RustInterop.emitRustExpr () v553 
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
            let v555 : (string -> unit) = v299.l0
            v555 v229
            US8_0(v298, v299, v300, v301, v302, v303)
    let v589 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v589 
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
and closure24 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure6()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US3 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v556 : US8 =
        if v116 then
            US8_1
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
            let v340 : (unit -> unit) = closure8(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure9()
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
            let v500 : int32 = v487 |> int32 
            let v531 : string = ""
            let v532 : bool = v228 <> v531 
            let v543 : bool =
                if v532 then
                    let v542 : bool = v500 <= 1
                    v542
                else
                    false
            if v543 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v531
                let v544 : string = "true; $0.into_iter().for_each(|x| { //"
                let v545 : bool = Fable.Core.RustInterop.emitRustExpr v485 v544 
                let v546 : string = "x"
                let v547 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v546 
                let v548 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v549 : bool = Fable.Core.RustInterop.emitRustExpr v547 v548 
                let v550 : string = $"true"
                let v551 : bool = Fable.Core.RustInterop.emitRustExpr () v550 
                let v552 : string = "true; }); //"
                let v553 : bool = Fable.Core.RustInterop.emitRustExpr () v552 
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
            let v554 : (string -> unit) = v298.l0
            v554 v228
            US8_0(v297, v298, v299, v300, v301, v302)
    let v588 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v588 
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
and closure25 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure6()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US3 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v556 : US8 =
        if v116 then
            US8_1
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
            let v340 : (unit -> unit) = closure8(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure9()
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
            let v500 : int32 = v487 |> int32 
            let v531 : string = ""
            let v532 : bool = v228 <> v531 
            let v543 : bool =
                if v532 then
                    let v542 : bool = v500 <= 1
                    v542
                else
                    false
            if v543 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v531
                let v544 : string = "true; $0.into_iter().for_each(|x| { //"
                let v545 : bool = Fable.Core.RustInterop.emitRustExpr v485 v544 
                let v546 : string = "x"
                let v547 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v546 
                let v548 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v549 : bool = Fable.Core.RustInterop.emitRustExpr v547 v548 
                let v550 : string = $"true"
                let v551 : bool = Fable.Core.RustInterop.emitRustExpr () v550 
                let v552 : string = "true; }); //"
                let v553 : bool = Fable.Core.RustInterop.emitRustExpr () v552 
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
            let v554 : (string -> unit) = v298.l0
            v554 v228
            US8_0(v297, v298, v299, v300, v301, v302)
    let v588 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v588 
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
and method39 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> =
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
    let v612 : unit = ()
    let v613 : (unit -> unit) = closure13(v1, v11, v19)
    let v614 : unit = (fun () -> v613 (); v612) ()
    let v1214 : string = "$0.call(&*$1)"
    let v1215 : string = "state_main"
    let v1216 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr struct (v19, v1215) v1214 
    let v1217 : string = "near_workspaces::types::Gas::from_tgas(300)"
    let v1218 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr () v1217 
    let v1219 : string = "v1216.gas(v1218)"
    let v1220 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr () v1219 
    let v1221 : string = "Box::pin(v1220.transact())"
    let v1222 : std_pin_Pin<Box<Dyn<std_future_Future<Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v1221 
    let v1223 : string = "v1222.await"
    let v1224 : Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v1223 
    let v1225 : string = "$0?"
    let v1226 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v1224 v1225 
    let v1819 : unit = ()
    let v1820 : (unit -> unit) = closure14(v1, v1226)
    let v1821 : unit = (fun () -> v1820 (); v1819) ()
    let v2421 : string = "v1226.logs()"
    let v2422 : Vec<Ref<Str>> = Fable.Core.RustInterop.emitRustExpr () v2421 
    let v2423 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v2424 : bool = Fable.Core.RustInterop.emitRustExpr v2422 v2423 
    let v2425 : string = "x"
    let v2426 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2425 
    (* run_target_args'
    let v2438 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2439 : string = "String::from($0)"
    let v2440 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2426 v2439 
    let _run_target_args'_v2438 = v2440 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2441 : string = "String::from($0)"
    let v2442 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2426 v2441 
    let _run_target_args'_v2438 = v2442 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2443 : string = "String::from($0)"
    let v2444 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2426 v2443 
    let _run_target_args'_v2438 = v2444 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2446 : std_string_String = v2426 |> unbox<std_string_String>
    let _run_target_args'_v2438 = v2446 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2457 : std_string_String = v2426 |> unbox<std_string_String>
    let _run_target_args'_v2438 = v2457 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2468 : std_string_String = v2426 |> unbox<std_string_String>
    let _run_target_args'_v2438 = v2468 
    #endif
#else
    let v2479 : std_string_String = v2426 |> unbox<std_string_String>
    let _run_target_args'_v2438 = v2479 
    #endif
    let v2489 : std_string_String = _run_target_args'_v2438 
    let v2512 : string = "true; $0 }).collect::<Vec<_>>()"
    let v2513 : bool = Fable.Core.RustInterop.emitRustExpr v2489 v2512 
    let v2514 : string = "_vec_map"
    let v2515 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v2514 
    let v2516 : string = "true; $0.iter().for_each(|x| { $1(x.clone()); }); //"
    let v2517 : (std_string_String -> unit) = closure15()
    let v2518 : bool = Fable.Core.RustInterop.emitRustExpr struct (v2515, v2517) v2516 
    let v3002 : unit = ()
    let v3003 : (unit -> unit) = closure17()
    let v3004 : unit = (fun () -> v3003 (); v3002) ()
    let v3494 : string = "$0.total_gas_burnt"
    let v3495 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v1226 v3494 
    let v3496 : string = "$0.as_gas()"
    let v3497 : uint64 = Fable.Core.RustInterop.emitRustExpr v3495 v3496 
    let v3499 : (uint64 -> float) = float
    let v3500 : float = v3499 v3497
    let v3510 : float = v3500 / 10000000000000000.0
    let v3511 : float = v3510 * 6.68
    let v4104 : unit = ()
    let v4105 : (unit -> unit) = closure18(v1, v3497, v3511)
    let v4106 : unit = (fun () -> v4105 (); v4104) ()
    let v4706 : string = "$0"
    let v4707 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v1226 v4706 
    let v4708 : string = "v4707.outcomes()"
    let v4709 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v4708 
    let v4710 : string = "v4709.into_iter()"
    let v4711 : _ = Fable.Core.RustInterop.emitRustExpr () v4710 
    let v4712 : string = "v4711.cloned()"
    let v4713 : _ = Fable.Core.RustInterop.emitRustExpr () v4712 
    let v4714 : string = "true; v4713.for_each(|x| $0(x))"
    let v4715 : (near_workspaces_result_ExecutionOutcome -> unit) = closure19()
    let v4716 : bool = Fable.Core.RustInterop.emitRustExpr v4715 v4714 
    let v4717 : string = "$0.into_result()"
    let v4718 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure> = Fable.Core.RustInterop.emitRustExpr v1226 v4717 
    let v5311 : unit = ()
    let v5312 : (unit -> unit) = closure21(v4718)
    let v5313 : unit = (fun () -> v5312 (); v5311) ()
    let v5913 : near_workspaces_result_ExecutionFinalResult = method64(v1226)
    let v5914 : string = "v5913.receipt_failures()"
    let v5915 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v5914 
    let v5916 : string = "$0.len()"
    let v5917 : unativeint = Fable.Core.RustInterop.emitRustExpr v5915 v5916 
    let v5930 : int32 = v5917 |> int32 
    let v6551 : unit = ()
    let v6552 : (unit -> unit) = closure22(v5915, v5930)
    let v6553 : unit = (fun () -> v6552 (); v6551) ()
    let v7153 : near_workspaces_result_ExecutionFinalResult = method69(v1226)
    let v7154 : string = "v7153.receipt_outcomes()"
    let v7155 : Ref<Slice<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v7154 
    let v7156 : string = "v7155.into()"
    let v7157 : Vec<near_workspaces_result_ExecutionOutcome> = Fable.Core.RustInterop.emitRustExpr () v7156 
    let v7158 : string = "$0.len()"
    let v7159 : unativeint = Fable.Core.RustInterop.emitRustExpr v7157 v7158 
    let v7172 : int32 = v7159 |> int32 
    let v7793 : unit = ()
    let v7794 : (unit -> unit) = closure23(v7157, v7172)
    let v7795 : unit = (fun () -> v7794 (); v7793) ()
    let v8395 : string = "$0.json()"
    let v8396 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v1226 v8395 
    let v8989 : unit = ()
    let v8990 : (unit -> unit) = closure24(v8396)
    let v8991 : unit = (fun () -> v8990 (); v8989) ()
    let v9591 : string = "$0.borsh()"
    let v9592 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v1226 v9591 
    let v10185 : unit = ()
    let v10186 : (unit -> unit) = closure25(v9592)
    let v10187 : unit = (fun () -> v10186 (); v10185) ()
    let v10787 : string = method80(v7172, v1, v5915)
    let v10788 : bool = v5930 > 0
    let v10836 : Result<US7, anyhow_Error> =
        if v10788 then
            let v10791 : US7 = US7_0(v10787)
            let v10792 : Result<US7, anyhow_Error> = Ok v10791 
            v10792
        else
            let v10803 : bool = v7172 > 1
            if v10803 then
                let v10806 : US7 = US7_1
                let v10807 : Result<US7, anyhow_Error> = Ok v10806 
                v10807
            else
                let v10818 : string = "anyhow::anyhow!($0)"
                let v10819 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v10787 v10818 
                (* run_target_args'
                let v10821 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10822 : string = "Err($0)"
                let v10823 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v10819 v10822 
                let _run_target_args'_v10821 = v10823 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10824 : string = "Err($0)"
                let v10825 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v10819 v10824 
                let _run_target_args'_v10821 = v10825 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10826 : string = "Err($0)"
                let v10827 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v10819 v10826 
                let _run_target_args'_v10821 = v10827 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10828 : Result<US7, anyhow_Error> = v10819 |> Error
                let _run_target_args'_v10821 = v10828 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10829 : Result<US7, anyhow_Error> = v10819 |> Error
                let _run_target_args'_v10821 = v10829 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10830 : Result<US7, anyhow_Error> = v10819 |> Error
                let _run_target_args'_v10821 = v10830 
                #endif
#else
                let v10831 : Result<US7, anyhow_Error> = v10819 |> Error
                let _run_target_args'_v10821 = v10831 
                #endif
                let v10832 : Result<US7, anyhow_Error> = _run_target_args'_v10821 
                v10832
    let v10837 : string = ""
    let v10838 : string = "}"
    let v10839 : string = v10837 + v10838 
    let x = v10836 //
    let v10840 : _ = x
    let v10841 : unit = ()
    (* run_target_args'
    let v10842 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v10843 : string = $"true; let _fix_closure_v10841 = $0"
    let v10844 : bool = Fable.Core.RustInterop.emitRustExpr v10840 v10843 
    let _run_target_args'_v10842 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v10845 : string = $"true; let _fix_closure_v10841 = $0"
    let v10846 : bool = Fable.Core.RustInterop.emitRustExpr v10840 v10845 
    let _run_target_args'_v10842 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10847 : string = $"true; let _fix_closure_v10841 = $0"
    let v10848 : bool = Fable.Core.RustInterop.emitRustExpr v10840 v10847 
    let _run_target_args'_v10842 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v10842 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v10842 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v10842 = false 
    #endif
#else
    let _run_target_args'_v10842 = false 
    #endif
    let v10849 : bool = _run_target_args'_v10842 
    let v10850 : string = $"true; _fix_closure_v10841 " + v10839 + "); " + v10837 + " // rust.fix_closure'"
    let v10851 : bool = Fable.Core.RustInterop.emitRustExpr () v10850 
    let v10852 : string = "__future_init"
    let v10853 : _ = Fable.Core.RustInterop.emitRustExpr () v10852 
    let v10854 : string = "v10853"
    let v10855 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v10854 
    v10855
and closure26 () (v0 : anyhow_Error) : std_string_String =
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
    closure26()
and closure27 () (v0 : US7) : US11 =
    US11_0(v0)
and method82 () : (US7 -> US11) =
    closure27()
and closure28 () (v0 : std_string_String) : US11 =
    US11_1(v0)
and method83 () : (std_string_String -> US11) =
    closure28()
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
and closure29 (v0 : uint8, v1 : std_string_String) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure6()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US3 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 3 >= v114
            v115
    let v117 : bool = v116 = false
    let v557 : US8 =
        if v117 then
            US8_1
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
            let v341 : (unit -> unit) = closure8(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure9()
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
            let v501 : int32 = v488 |> int32 
            let v532 : string = ""
            let v533 : bool = v229 <> v532 
            let v544 : bool =
                if v533 then
                    let v543 : bool = v501 <= 1
                    v543
                else
                    false
            if v544 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v532
                let v545 : string = "true; $0.into_iter().for_each(|x| { //"
                let v546 : bool = Fable.Core.RustInterop.emitRustExpr v486 v545 
                let v547 : string = "x"
                let v548 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v547 
                let v549 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v550 : bool = Fable.Core.RustInterop.emitRustExpr v548 v549 
                let v551 : string = $"true"
                let v552 : bool = Fable.Core.RustInterop.emitRustExpr () v551 
                let v553 : string = "true; }); //"
                let v554 : bool = Fable.Core.RustInterop.emitRustExpr () v553 
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
            let v555 : (string -> unit) = v299.l0
            v555 v229
            US8_0(v298, v299, v300, v301, v302, v303)
    let v589 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v589 
    ()
and closure30 () () : unit =
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6()
    let v31 : unit = (fun () -> v30 (); v29) ()
    let struct (v69 : Mut0, v70 : Mut1, v71 : Mut2, v72 : Mut3, v73 : Mut4, v74 : int64 option) = TraceState.trace_state.Value
    let v109 : US3 = v73.l0
    let v110 : bool = v71.l0
    let v111 : bool = v110 = false
    let v114 : bool =
        if v111 then
            false
        else
            let v112 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v109
            let v113 : bool = 3 >= v112
            v113
    let v115 : bool = v114 = false
    let v443 : US8 =
        if v115 then
            US8_1
        else
            let v146 : unit = ()
            let v147 : unit = (fun () -> v30 (); v146) ()
            let struct (v185 : Mut0, v186 : Mut1, v187 : Mut2, v188 : Mut3, v189 : Mut4, v190 : int64 option) = TraceState.trace_state.Value
            let v227 : unit = ()
            let v228 : (unit -> unit) = closure8(v185)
            let v229 : unit = (fun () -> v228 (); v227) ()
            let v236 : string = "\n"
            let v237 : (string -> unit) = closure9()
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
            let v387 : int32 = v374 |> int32 
            let v418 : string = ""
            let v419 : bool = v236 <> v418 
            let v430 : bool =
                if v419 then
                    let v429 : bool = v387 <= 1
                    v429
                else
                    false
            if v430 then
                v188.l0 <- v269
                ()
            else
                v188.l0 <- v418
                let v431 : string = "true; $0.into_iter().for_each(|x| { //"
                let v432 : bool = Fable.Core.RustInterop.emitRustExpr v372 v431 
                let v433 : string = "x"
                let v434 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v433 
                let v435 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v436 : bool = Fable.Core.RustInterop.emitRustExpr v434 v435 
                let v437 : string = $"true"
                let v438 : bool = Fable.Core.RustInterop.emitRustExpr () v437 
                let v439 : string = "true; }); //"
                let v440 : bool = Fable.Core.RustInterop.emitRustExpr () v439 
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
            let v441 : (string -> unit) = v186.l0
            v441 v236
            US8_0(v185, v186, v187, v188, v189, v190)
    let v475 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v475 
    ()
and closure31 (v0 : uint8, v1 : std_string_String) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure6()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US3 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 3 >= v114
            v115
    let v117 : bool = v116 = false
    let v557 : US8 =
        if v117 then
            US8_1
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
            let v341 : (unit -> unit) = closure8(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure9()
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
            let v501 : int32 = v488 |> int32 
            let v532 : string = ""
            let v533 : bool = v229 <> v532 
            let v544 : bool =
                if v533 then
                    let v543 : bool = v501 <= 1
                    v543
                else
                    false
            if v544 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v532
                let v545 : string = "true; $0.into_iter().for_each(|x| { //"
                let v546 : bool = Fable.Core.RustInterop.emitRustExpr v486 v545 
                let v547 : string = "x"
                let v548 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v547 
                let v549 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v550 : bool = Fable.Core.RustInterop.emitRustExpr v548 v549 
                let v551 : string = $"true"
                let v552 : bool = Fable.Core.RustInterop.emitRustExpr () v551 
                let v553 : string = "true; }); //"
                let v554 : bool = Fable.Core.RustInterop.emitRustExpr () v553 
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
            let v555 : (string -> unit) = v299.l0
            v555 v229
            US8_0(v298, v299, v300, v301, v302, v303)
    let v589 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v589 
    ()
and closure32 () () : unit =
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6()
    let v31 : unit = (fun () -> v30 (); v29) ()
    let struct (v69 : Mut0, v70 : Mut1, v71 : Mut2, v72 : Mut3, v73 : Mut4, v74 : int64 option) = TraceState.trace_state.Value
    let v109 : US3 = v73.l0
    let v110 : bool = v71.l0
    let v111 : bool = v110 = false
    let v114 : bool =
        if v111 then
            false
        else
            let v112 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v109
            let v113 : bool = 3 >= v112
            v113
    let v115 : bool = v114 = false
    let v443 : US8 =
        if v115 then
            US8_1
        else
            let v146 : unit = ()
            let v147 : unit = (fun () -> v30 (); v146) ()
            let struct (v185 : Mut0, v186 : Mut1, v187 : Mut2, v188 : Mut3, v189 : Mut4, v190 : int64 option) = TraceState.trace_state.Value
            let v227 : unit = ()
            let v228 : (unit -> unit) = closure8(v185)
            let v229 : unit = (fun () -> v228 (); v227) ()
            let v236 : string = "\n"
            let v237 : (string -> unit) = closure9()
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
            let v387 : int32 = v374 |> int32 
            let v418 : string = ""
            let v419 : bool = v236 <> v418 
            let v430 : bool =
                if v419 then
                    let v429 : bool = v387 <= 1
                    v429
                else
                    false
            if v430 then
                v188.l0 <- v269
                ()
            else
                v188.l0 <- v418
                let v431 : string = "true; $0.into_iter().for_each(|x| { //"
                let v432 : bool = Fable.Core.RustInterop.emitRustExpr v372 v431 
                let v433 : string = "x"
                let v434 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v433 
                let v435 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v436 : bool = Fable.Core.RustInterop.emitRustExpr v434 v435 
                let v437 : string = $"true"
                let v438 : bool = Fable.Core.RustInterop.emitRustExpr () v437 
                let v439 : string = "true; }); //"
                let v440 : bool = Fable.Core.RustInterop.emitRustExpr () v439 
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
            let v441 : (string -> unit) = v186.l0
            v441 v236
            US8_0(v185, v186, v187, v188, v189, v190)
    let v475 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v475 
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
and closure33 (v0 : uint8, v1 : string) () : unit =
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure6()
    let v33 : unit = (fun () -> v32 (); v31) ()
    let struct (v71 : Mut0, v72 : Mut1, v73 : Mut2, v74 : Mut3, v75 : Mut4, v76 : int64 option) = TraceState.trace_state.Value
    let v111 : US3 = v75.l0
    let v112 : bool = v73.l0
    let v113 : bool = v112 = false
    let v116 : bool =
        if v113 then
            false
        else
            let v114 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v111
            let v115 : bool = 4 >= v114
            v115
    let v117 : bool = v116 = false
    let v557 : US8 =
        if v117 then
            US8_1
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
            let v341 : (unit -> unit) = closure8(v298)
            let v342 : unit = (fun () -> v341 (); v340) ()
            let v349 : (string -> unit) = closure9()
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
            let v501 : int32 = v488 |> int32 
            let v532 : string = ""
            let v533 : bool = v229 <> v532 
            let v544 : bool =
                if v533 then
                    let v543 : bool = v501 <= 1
                    v543
                else
                    false
            if v544 then
                v301.l0 <- v383
                ()
            else
                v301.l0 <- v532
                let v545 : string = "true; $0.into_iter().for_each(|x| { //"
                let v546 : bool = Fable.Core.RustInterop.emitRustExpr v486 v545 
                let v547 : string = "x"
                let v548 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v547 
                let v549 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v550 : bool = Fable.Core.RustInterop.emitRustExpr v548 v549 
                let v551 : string = $"true"
                let v552 : bool = Fable.Core.RustInterop.emitRustExpr () v551 
                let v553 : string = "true; }); //"
                let v554 : bool = Fable.Core.RustInterop.emitRustExpr () v553 
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
            let v555 : (string -> unit) = v299.l0
            v555 v229
            US8_0(v298, v299, v300, v301, v302, v303)
    let v589 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v589 
    ()
and method38 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<US10>>>> =
    let v2 : string = "true; let __future_init = Box::pin(/*"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let v4 : string = "*/ async move { /*"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let v6 : string = "*/ ()"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let v8 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = method39(v0, v1)
    let v9 : string = "v8.await"
    let v10 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr () v9 
    let v11 : (anyhow_Error -> std_string_String) = method81()
    (* run_target_args'
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "$0.map_err(|x| $1(x))"
    let v15 : Result<US7, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v10, v11) v14 
    let _run_target_args'_v13 = v15 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v16 : string = "$0.map_err(|x| $1(x))"
    let v17 : Result<US7, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v10, v11) v16 
    let _run_target_args'_v13 = v17 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v18 : string = "$0.map_err(|x| $1(x))"
    let v19 : Result<US7, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v10, v11) v18 
    let _run_target_args'_v13 = v19 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : Result<US7, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v13 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v21 : Result<US7, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v13 = v21 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v22 : Result<US7, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v13 = v22 
    #endif
#else
    let v23 : Result<US7, std_string_String> = match v10 with Ok x -> Ok x | Error x -> Error (v11 x)
    let _run_target_args'_v13 = v23 
    #endif
    let v24 : Result<US7, std_string_String> = _run_target_args'_v13 
    let v27 : (US7 -> US11) = method82()
    let v28 : (std_string_String -> US11) = method83()
    let v30 : US11 = match v24 with Ok x -> v27 x | Error x -> v28 x
    let v5672 : US10 =
        match v30 with
        | US11_1(v1304) -> (* Error *)
            let v1305 : bool = v1 >= 15uy
            if v1305 then
                let v1898 : unit = ()
                let v1899 : (unit -> unit) = closure29(v1, v1304)
                let v1900 : unit = (fun () -> v1899 (); v1898) ()
                let v2981 : unit = ()
                let v2982 : (unit -> unit) = closure30()
                let v2983 : unit = (fun () -> v2982 (); v2981) ()
                let v3471 : string = "true; let __future_init = Box::pin(/*"
                let v3472 : bool = Fable.Core.RustInterop.emitRustExpr () v3471 
                let v3473 : string = "*/ async move { /*"
                let v3474 : bool = Fable.Core.RustInterop.emitRustExpr () v3473 
                let v3475 : string = "*/ ()"
                let v3476 : bool = Fable.Core.RustInterop.emitRustExpr () v3475 
                let v3477 : string = ""
                let v3478 : string = "}"
                let v3479 : string = v3477 + v3478 
                let v3480 : US7 = US7_1
                let x = struct (v1, v3480) //
                let v3481 : _ = x
                let v3482 : unit = ()
                (* run_target_args'
                let v3483 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3484 : string = $"true; let _fix_closure_v3482 = $0"
                let v3485 : bool = Fable.Core.RustInterop.emitRustExpr v3481 v3484 
                let _run_target_args'_v3483 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3486 : string = $"true; let _fix_closure_v3482 = $0"
                let v3487 : bool = Fable.Core.RustInterop.emitRustExpr v3481 v3486 
                let _run_target_args'_v3483 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3488 : string = $"true; let _fix_closure_v3482 = $0"
                let v3489 : bool = Fable.Core.RustInterop.emitRustExpr v3481 v3488 
                let _run_target_args'_v3483 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v3483 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v3483 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v3483 = false 
                #endif
#else
                let _run_target_args'_v3483 = false 
                #endif
                let v3490 : bool = _run_target_args'_v3483 
                let v3491 : string = $"true; _fix_closure_v3482 " + v3479 + "); " + v3477 + " // rust.fix_closure'"
                let v3492 : bool = Fable.Core.RustInterop.emitRustExpr () v3491 
                let v3493 : string = "__future_init"
                let v3494 : _ = Fable.Core.RustInterop.emitRustExpr () v3493 
                let v3495 : string = "v3494"
                let v3496 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v3495 
                let v3497 : string = "v3496.await"
                let struct (v3498 : uint8, v3499 : US7) = Fable.Core.RustInterop.emitRustExpr () v3497 
                US10_0(v3498, v3499)
            else
                let v4093 : unit = ()
                let v4094 : (unit -> unit) = closure31(v1, v1304)
                let v4095 : unit = (fun () -> v4094 (); v4093) ()
                let v5176 : unit = ()
                let v5177 : (unit -> unit) = closure32()
                let v5178 : unit = (fun () -> v5177 (); v5176) ()
                let v5666 : uint8 = v1 + 1uy
                let v5667 : std_pin_Pin<Box<Dyn<std_future_Future<US10>>>> = method38(v0, v5666)
                let v5668 : string = "v5667.await"
                let v5669 : US10 = Fable.Core.RustInterop.emitRustExpr () v5668 
                v5669
        | US11_0(v46) -> (* Ok *)
            match v46 with
            | US7_1 -> (* None *)
                let v47 : string = "true; let __future_init = Box::pin(/*"
                let v48 : bool = Fable.Core.RustInterop.emitRustExpr () v47 
                let v49 : string = "*/ async move { /*"
                let v50 : bool = Fable.Core.RustInterop.emitRustExpr () v49 
                let v51 : string = "*/ ()"
                let v52 : bool = Fable.Core.RustInterop.emitRustExpr () v51 
                let v53 : string = ""
                let v54 : string = "}"
                let v55 : string = v53 + v54 
                let v56 : US7 = US7_1
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
                let v72 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v71 
                let v73 : string = "v72.await"
                let struct (v74 : uint8, v75 : US7) = Fable.Core.RustInterop.emitRustExpr () v73 
                US10_0(v74, v75)
            | US7_0(v77) -> (* Some *)
                let v670 : unit = ()
                let v671 : (unit -> unit) = closure33(v1, v77)
                let v672 : unit = (fun () -> v671 (); v670) ()
                let v1272 : string = "true; let __future_init = Box::pin(/*"
                let v1273 : bool = Fable.Core.RustInterop.emitRustExpr () v1272 
                let v1274 : string = "*/ async move { /*"
                let v1275 : bool = Fable.Core.RustInterop.emitRustExpr () v1274 
                let v1276 : string = "*/ ()"
                let v1277 : bool = Fable.Core.RustInterop.emitRustExpr () v1276 
                let v1278 : string = ""
                let v1279 : string = "}"
                let v1280 : string = v1278 + v1279 
                let v1281 : US7 = US7_0(v77)
                let x = struct (v1, v1281) //
                let v1282 : _ = x
                let v1283 : unit = ()
                (* run_target_args'
                let v1284 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1285 : string = $"true; let _fix_closure_v1283 = $0"
                let v1286 : bool = Fable.Core.RustInterop.emitRustExpr v1282 v1285 
                let _run_target_args'_v1284 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1287 : string = $"true; let _fix_closure_v1283 = $0"
                let v1288 : bool = Fable.Core.RustInterop.emitRustExpr v1282 v1287 
                let _run_target_args'_v1284 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1289 : string = $"true; let _fix_closure_v1283 = $0"
                let v1290 : bool = Fable.Core.RustInterop.emitRustExpr v1282 v1289 
                let _run_target_args'_v1284 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v1284 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v1284 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v1284 = false 
                #endif
#else
                let _run_target_args'_v1284 = false 
                #endif
                let v1291 : bool = _run_target_args'_v1284 
                let v1292 : string = $"true; _fix_closure_v1283 " + v1280 + "); " + v1278 + " // rust.fix_closure'"
                let v1293 : bool = Fable.Core.RustInterop.emitRustExpr () v1292 
                let v1294 : string = "__future_init"
                let v1295 : _ = Fable.Core.RustInterop.emitRustExpr () v1294 
                let v1296 : string = "v1295"
                let v1297 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v1296 
                let v1298 : string = "v1297.await"
                let struct (v1299 : uint8, v1300 : US7) = Fable.Core.RustInterop.emitRustExpr () v1298 
                US10_1(v1299, v1300)
    let v5673 : string = ""
    let v5674 : string = "}"
    let v5675 : string = v5673 + v5674 
    let x = v5672 //
    let v5676 : _ = x
    let v5677 : unit = ()
    (* run_target_args'
    let v5678 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5679 : string = $"true; let _fix_closure_v5677 = $0"
    let v5680 : bool = Fable.Core.RustInterop.emitRustExpr v5676 v5679 
    let _run_target_args'_v5678 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5681 : string = $"true; let _fix_closure_v5677 = $0"
    let v5682 : bool = Fable.Core.RustInterop.emitRustExpr v5676 v5681 
    let _run_target_args'_v5678 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5683 : string = $"true; let _fix_closure_v5677 = $0"
    let v5684 : bool = Fable.Core.RustInterop.emitRustExpr v5676 v5683 
    let _run_target_args'_v5678 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v5678 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v5678 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v5678 = false 
    #endif
#else
    let _run_target_args'_v5678 = false 
    #endif
    let v5685 : bool = _run_target_args'_v5678 
    let v5686 : string = $"true; _fix_closure_v5677 " + v5675 + "); " + v5673 + " // rust.fix_closure'"
    let v5687 : bool = Fable.Core.RustInterop.emitRustExpr () v5686 
    let v5688 : string = "__future_init"
    let v5689 : _ = Fable.Core.RustInterop.emitRustExpr () v5688 
    let v5690 : string = "v5689"
    let v5691 : std_pin_Pin<Box<Dyn<std_future_Future<US10>>>> = Fable.Core.RustInterop.emitRustExpr () v5690 
    v5691
and method93 (v0 : Mut3) : unit =
    let v1 : string = v0.l0
    let v4 : string = "retries"
    let v5 : string = v1 + v4 
    v0.l0 <- v5
    ()
and method92 (v0 : US10) : string =
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
and method91 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : US10) : string =
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
and closure34 (v0 : US10) () : unit =
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure6()
    let v32 : unit = (fun () -> v31 (); v30) ()
    let struct (v70 : Mut0, v71 : Mut1, v72 : Mut2, v73 : Mut3, v74 : Mut4, v75 : int64 option) = TraceState.trace_state.Value
    let v110 : US3 = v74.l0
    let v111 : bool = v72.l0
    let v112 : bool = v111 = false
    let v115 : bool =
        if v112 then
            false
        else
            let v113 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v110
            let v114 : bool = 0 >= v113
            v114
    let v116 : bool = v115 = false
    let v556 : US8 =
        if v116 then
            US8_1
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
            let v340 : (unit -> unit) = closure8(v297)
            let v341 : unit = (fun () -> v340 (); v339) ()
            let v348 : (string -> unit) = closure9()
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
            let v500 : int32 = v487 |> int32 
            let v531 : string = ""
            let v532 : bool = v228 <> v531 
            let v543 : bool =
                if v532 then
                    let v542 : bool = v500 <= 1
                    v542
                else
                    false
            if v543 then
                v300.l0 <- v382
                ()
            else
                v300.l0 <- v531
                let v544 : string = "true; $0.into_iter().for_each(|x| { //"
                let v545 : bool = Fable.Core.RustInterop.emitRustExpr v485 v544 
                let v546 : string = "x"
                let v547 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v546 
                let v548 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v549 : bool = Fable.Core.RustInterop.emitRustExpr v547 v548 
                let v550 : string = $"true"
                let v551 : bool = Fable.Core.RustInterop.emitRustExpr () v550 
                let v552 : string = "true; }); //"
                let v553 : bool = Fable.Core.RustInterop.emitRustExpr () v552 
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
            let v554 : (string -> unit) = v298.l0
            v554 v228
            US8_0(v297, v298, v299, v300, v301, v302)
    let v588 : string = "Fsharp"
    // base.backend_switch / record_type_try_find / key: v588 
    ()
and method94 (v0 : US10, v1 : US7) : string =
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
    let v106 : (std_string_String -> US0) = method2()
    let v107 : US0 option = v94 |> Option.map v106 
    let v155 : US0 = US0_1
    let v156 : US0 = v107 |> Option.defaultValue v155 
    let v170 : std_string_String =
        match v156 with
        | US0_1 -> (* None *)
            failwith<std_string_String> "Option does not have a value."
        | US0_0(v167) -> (* Some *)
            v167
    let v171 : string = "fable_library_rust::String_::fromString($0)"
    let v172 : string = Fable.Core.RustInterop.emitRustExpr v170 v171 
    let v765 : unit = ()
    let v766 : (unit -> unit) = closure12(v172)
    let v767 : unit = (fun () -> v766 (); v765) ()
    let v1367 : string = "std::fs::read(&*$0)"
    let v1368 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v172 v1367 
    let v1369 : string = "$0?"
    let v1370 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v1368 v1369 
    let v1371 : uint8 = 1uy
    let v1372 : std_pin_Pin<Box<Dyn<std_future_Future<US10>>>> = method38(v1370, v1371)
    let v1373 : string = "v1372.await"
    let v1374 : US10 = Fable.Core.RustInterop.emitRustExpr () v1373 
    let v1967 : unit = ()
    let v1968 : (unit -> unit) = closure34(v1374)
    let v1969 : unit = (fun () -> v1968 (); v1967) ()
    let v2603 : Result<uint8, anyhow_Error> =
        match v1374 with
        | US10_1(v2582, v2583) -> (* Error *)
            let v2584 : string = method94(v1374, v2583)
            let v2585 : string = "anyhow::anyhow!($0)"
            let v2586 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v2584 v2585 
            (* run_target_args'
            let v2588 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2589 : string = "Err($0)"
            let v2590 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v2586 v2589 
            let _run_target_args'_v2588 = v2590 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2591 : string = "Err($0)"
            let v2592 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v2586 v2591 
            let _run_target_args'_v2588 = v2592 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2593 : string = "Err($0)"
            let v2594 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v2586 v2593 
            let _run_target_args'_v2588 = v2594 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2595 : Result<uint8, anyhow_Error> = v2586 |> Error
            let _run_target_args'_v2588 = v2595 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2596 : Result<uint8, anyhow_Error> = v2586 |> Error
            let _run_target_args'_v2588 = v2596 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2597 : Result<uint8, anyhow_Error> = v2586 |> Error
            let _run_target_args'_v2588 = v2597 
            #endif
#else
            let v2598 : Result<uint8, anyhow_Error> = v2586 |> Error
            let _run_target_args'_v2588 = v2598 
            #endif
            let v2599 : Result<uint8, anyhow_Error> = _run_target_args'_v2588 
            v2599
        | US10_0(v2569, v2570) -> (* Ok *)
            let v2572 : Result<uint8, anyhow_Error> = Ok v2569 
            v2572
    let v2604 : string = ""
    let v2605 : string = "}"
    let v2606 : string = v2604 + v2605 
    let x = v2603 //
    let v2607 : _ = x
    let v2608 : unit = ()
    (* run_target_args'
    let v2609 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2610 : string = $"true; let _fix_closure_v2608 = $0"
    let v2611 : bool = Fable.Core.RustInterop.emitRustExpr v2607 v2610 
    let _run_target_args'_v2609 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2612 : string = $"true; let _fix_closure_v2608 = $0"
    let v2613 : bool = Fable.Core.RustInterop.emitRustExpr v2607 v2612 
    let _run_target_args'_v2609 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2614 : string = $"true; let _fix_closure_v2608 = $0"
    let v2615 : bool = Fable.Core.RustInterop.emitRustExpr v2607 v2614 
    let _run_target_args'_v2609 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v2609 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v2609 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v2609 = false 
    #endif
#else
    let _run_target_args'_v2609 = false 
    #endif
    let v2616 : bool = _run_target_args'_v2609 
    let v2617 : string = $"true; _fix_closure_v2608 " + v2606 + "); " + v2604 + " // rust.fix_closure'"
    let v2618 : bool = Fable.Core.RustInterop.emitRustExpr () v2617 
    let v2619 : string = "__future_init"
    let v2620 : _ = Fable.Core.RustInterop.emitRustExpr () v2619 
    let v2621 : string = "v2620"
    let v2622 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v2621 
    v2622
and closure35 () (v0 : uint8) : US12 =
    US12_0(v0)
and method95 () : (uint8 -> US12) =
    closure35()
and closure36 () (v0 : std_string_String) : US12 =
    US12_1(v0)
and method96 () : (std_string_String -> US12) =
    closure36()
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
    let v103 : (std_string_String -> US0) = method2()
    let v104 : US0 option = v91 |> Option.map v103 
    let v152 : US0 = US0_1
    let v153 : US0 = v104 |> Option.defaultValue v152 
    let v331 : US1 =
        match v153 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v164) -> (* Some *)
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
            let v241 : US2 =
                if v237 then
                    let v238 : US3 = US3_0
                    US2_0(v238)
                else
                    US2_1
            let v327 : US2 =
                match v241 with
                | US2_1 -> (* None *)
                    let v244 : bool = "Debug" = v166
                    let v248 : US2 =
                        if v244 then
                            let v245 : US3 = US3_1
                            US2_0(v245)
                        else
                            US2_1
                    match v248 with
                    | US2_1 -> (* None *)
                        let v251 : bool = "Info" = v166
                        let v255 : US2 =
                            if v251 then
                                let v252 : US3 = US3_2
                                US2_0(v252)
                            else
                                US2_1
                        match v255 with
                        | US2_1 -> (* None *)
                            let v258 : bool = "Warning" = v166
                            let v262 : US2 =
                                if v258 then
                                    let v259 : US3 = US3_3
                                    US2_0(v259)
                                else
                                    US2_1
                            match v262 with
                            | US2_1 -> (* None *)
                                let v265 : bool = "Critical" = v166
                                let v269 : US2 =
                                    if v265 then
                                        let v266 : US3 = US3_4
                                        US2_0(v266)
                                    else
                                        US2_1
                                match v269 with
                                | US2_1 -> (* None *)
                                    let v272 : bool = v227 = v166
                                    let v276 : US2 =
                                        if v272 then
                                            let v273 : US3 = US3_0
                                            US2_0(v273)
                                        else
                                            US2_1
                                    match v276 with
                                    | US2_1 -> (* None *)
                                        let v279 : bool = v213 = v166
                                        let v283 : US2 =
                                            if v279 then
                                                let v280 : US3 = US3_1
                                                US2_0(v280)
                                            else
                                                US2_1
                                        match v283 with
                                        | US2_1 -> (* None *)
                                            let v286 : bool = v199 = v166
                                            let v290 : US2 =
                                                if v286 then
                                                    let v287 : US3 = US3_2
                                                    US2_0(v287)
                                                else
                                                    US2_1
                                            match v290 with
                                            | US2_1 -> (* None *)
                                                let v293 : bool = v185 = v166
                                                let v297 : US2 =
                                                    if v293 then
                                                        let v294 : US3 = US3_3
                                                        US2_0(v294)
                                                    else
                                                        US2_1
                                                match v297 with
                                                | US2_1 -> (* None *)
                                                    let v300 : bool = v171 = v166
                                                    let v304 : US2 =
                                                        if v300 then
                                                            let v301 : US3 = US3_4
                                                            US2_0(v301)
                                                        else
                                                            US2_1
                                                    match v304 with
                                                    | US2_1 -> (* None *)
                                                        US2_1
                                                    | US2_0(v305) -> (* Some *)
                                                        US2_0(v305)
                                                | US2_0(v298) -> (* Some *)
                                                    US2_0(v298)
                                            | US2_0(v291) -> (* Some *)
                                                US2_0(v291)
                                        | US2_0(v284) -> (* Some *)
                                            US2_0(v284)
                                    | US2_0(v277) -> (* Some *)
                                        US2_0(v277)
                                | US2_0(v270) -> (* Some *)
                                    US2_0(v270)
                            | US2_0(v263) -> (* Some *)
                                US2_0(v263)
                        | US2_0(v256) -> (* Some *)
                            US2_0(v256)
                    | US2_0(v249) -> (* Some *)
                        US2_0(v249)
                | US2_0(v242) -> (* Some *)
                    US2_0(v242)
            US1_0(v327)
    let v338 : US2 =
        match v331 with
        | US1_0(v332) -> (* Some *)
            match v332 with
            | US2_0(v333) -> (* Some *)
                US2_0(v333)
            | _ ->
                US2_1
        | _ ->
            US2_1
    let v342 : US3 =
        match v338 with
        | US2_1 -> (* None *)
            US3_0
        | US2_0(v339) -> (* Some *)
            v339
    let v370 : unit = ()
    let v371 : (unit -> unit) = closure2(v342)
    let v372 : unit = (fun () -> v371 (); v370) ()
    let struct (v407 : Mut0, v408 : Mut1, v409 : Mut2, v410 : Mut3, v411 : Mut4, v412 : int64 option) = TraceState.trace_state.Value
    let v1039 : unit = ()
    let v1040 : (unit -> unit) = closure5(v0)
    let v1041 : unit = (fun () -> v1040 (); v1039) ()
    let v1641 : string = method28()
    (* run_target_args'
    let v1653 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1654 : string = "&*$0"
    let v1655 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1641 v1654 
    let _run_target_args'_v1653 = v1655 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1656 : string = "&*$0"
    let v1657 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1641 v1656 
    let _run_target_args'_v1653 = v1657 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1658 : string = "&*$0"
    let v1659 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1641 v1658 
    let _run_target_args'_v1653 = v1659 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1661 : Ref<Str> = v1641 |> unbox<Ref<Str>>
    let _run_target_args'_v1653 = v1661 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1672 : Ref<Str> = v1641 |> unbox<Ref<Str>>
    let _run_target_args'_v1653 = v1672 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1683 : Ref<Str> = v1641 |> unbox<Ref<Str>>
    let _run_target_args'_v1653 = v1683 
    #endif
#else
    let v1694 : Ref<Str> = v1641 |> unbox<Ref<Str>>
    let _run_target_args'_v1653 = v1694 
    #endif
    let v1704 : Ref<Str> = _run_target_args'_v1653 
    let v1727 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v1728 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v1704) v1727 
    let v1740 : (std_string_String -> string) = method29()
    let v1741 : string option = v1728 |> Option.map v1740 
    let v2892 : (string -> US7) = method8()
    let v2893 : US7 option = v1741 |> Option.map v2892 
    let v2941 : US7 = US7_1
    let v2942 : US7 = v2893 |> Option.defaultValue v2941 
    let v2953 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method33(v3)
    let v2954 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v2955 : _ = Fable.Core.RustInterop.emitRustExpr () v2954 
    let v2956 : string = "v2955.handle().block_on($0)"
    let v2957 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v2953 v2956 
    let v2958 : (anyhow_Error -> std_string_String) = method81()
    (* run_target_args'
    let v2960 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2961 : string = "$0.map_err(|x| $1(x))"
    let v2962 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v2957, v2958) v2961 
    let _run_target_args'_v2960 = v2962 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2963 : string = "$0.map_err(|x| $1(x))"
    let v2964 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v2957, v2958) v2963 
    let _run_target_args'_v2960 = v2964 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2965 : string = "$0.map_err(|x| $1(x))"
    let v2966 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v2957, v2958) v2965 
    let _run_target_args'_v2960 = v2966 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2967 : Result<uint8, std_string_String> = match v2957 with Ok x -> Ok x | Error x -> Error (v2958 x)
    let _run_target_args'_v2960 = v2967 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2968 : Result<uint8, std_string_String> = match v2957 with Ok x -> Ok x | Error x -> Error (v2958 x)
    let _run_target_args'_v2960 = v2968 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2969 : Result<uint8, std_string_String> = match v2957 with Ok x -> Ok x | Error x -> Error (v2958 x)
    let _run_target_args'_v2960 = v2969 
    #endif
#else
    let v2970 : Result<uint8, std_string_String> = match v2957 with Ok x -> Ok x | Error x -> Error (v2958 x)
    let _run_target_args'_v2960 = v2970 
    #endif
    let v2971 : Result<uint8, std_string_String> = _run_target_args'_v2960 
    let v2974 : (uint8 -> US12) = method95()
    let v2975 : (std_string_String -> US12) = method96()
    let v2977 : US12 = match v2971 with Ok x -> v2974 x | Error x -> v2975 x
    match v2977 with
    | US12_1(v3015) -> (* Error *)
        match v2942 with
        | US7_0(v3016) -> (* Some *)
            let v3017 : bool = "" = v3016
            if v3017 then
                ()
            else
                let v3018 : string = "fable_library_rust::String_::fromString($0)"
                let v3019 : string = Fable.Core.RustInterop.emitRustExpr v3015 v3018 
                let v3021 : bool = v3019.Contains v3016 
                if v3021 then
                    ()
                else
                    let v3031 : string = $"spiral_wasm.main / exception: '{v3016}' / error: {v3015}"
                    (* run_target_args'
                    let v3033 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v3034 : string = "Err($0)"
                    let v3035 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v3031 v3034 
                    let _run_target_args'_v3033 = v3035 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v3036 : string = "Err($0)"
                    let v3037 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v3031 v3036 
                    let _run_target_args'_v3033 = v3037 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v3038 : string = "Err($0)"
                    let v3039 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v3031 v3038 
                    let _run_target_args'_v3033 = v3039 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v3040 : Result<unit, string> = v3031 |> Error
                    let _run_target_args'_v3033 = v3040 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v3041 : Result<unit, string> = v3031 |> Error
                    let _run_target_args'_v3033 = v3041 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v3042 : Result<unit, string> = v3031 |> Error
                    let _run_target_args'_v3033 = v3042 
                    #endif
#else
                    let v3043 : Result<unit, string> = v3031 |> Error
                    let _run_target_args'_v3033 = v3043 
                    #endif
                    let v3044 : Result<unit, string> = _run_target_args'_v3033 
                    (* run_target_args'
                    let v3047 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v3048 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v3044 v3048 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v3049 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v3044 v3049 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v3050 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v3044 v3050 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    match v3044 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if FABLE_COMPILER_PYTHON
                    match v3044 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    match v3044 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#else
                    match v3044 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
                    // run_target_args' is_unit
                    ()
        | _ ->
            (* run_target_args'
            let v3052 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3053 : string = "$0.unwrap()"
            let v3054 : uint8 = Fable.Core.RustInterop.emitRustExpr v2971 v3053 
            let _run_target_args'_v3052 = v3054 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3055 : string = "$0.unwrap()"
            let v3056 : uint8 = Fable.Core.RustInterop.emitRustExpr v2971 v3055 
            let _run_target_args'_v3052 = v3056 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3057 : string = "$0.unwrap()"
            let v3058 : uint8 = Fable.Core.RustInterop.emitRustExpr v2971 v3057 
            let _run_target_args'_v3052 = v3058 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3059 : uint8 = match v2971 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v3052 = v3059 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3060 : uint8 = match v2971 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v3052 = v3060 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3061 : uint8 = match v2971 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v3052 = v3061 
            #endif
#else
            let v3062 : uint8 = match v2971 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v3052 = v3062 
            #endif
            let v3063 : uint8 = _run_target_args'_v3052 
            ()
    | US12_0(v2993) -> (* Ok *)
        match v2942 with
        | US7_0(v2994) -> (* Some *)
            let v2995 : string = $"spiral_wasm.main / retries: {v2993} / exception: '{v2994}'"
            (* run_target_args'
            let v2997 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2998 : string = "Err($0)"
            let v2999 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v2995 v2998 
            let _run_target_args'_v2997 = v2999 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3000 : string = "Err($0)"
            let v3001 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v2995 v3000 
            let _run_target_args'_v2997 = v3001 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3002 : string = "Err($0)"
            let v3003 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v2995 v3002 
            let _run_target_args'_v2997 = v3003 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3004 : Result<unit, string> = v2995 |> Error
            let _run_target_args'_v2997 = v3004 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3005 : Result<unit, string> = v2995 |> Error
            let _run_target_args'_v2997 = v3005 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3006 : Result<unit, string> = v2995 |> Error
            let _run_target_args'_v2997 = v3006 
            #endif
#else
            let v3007 : Result<unit, string> = v2995 |> Error
            let _run_target_args'_v2997 = v3007 
            #endif
            let v3008 : Result<unit, string> = _run_target_args'_v2997 
            (* run_target_args'
            let v3011 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3012 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v3008 v3012 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3013 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v3008 v3013 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3014 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v3008 v3014 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            match v3008 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if FABLE_COMPILER_PYTHON
            match v3008 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            match v3008 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#else
            match v3008 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
            // run_target_args' is_unit
            ()
        | _ ->
            ()
    0
let v0 : ((string []) -> int32) = closure0()
let main args = v0 args
()
