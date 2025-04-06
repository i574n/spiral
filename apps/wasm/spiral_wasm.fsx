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
    | US8_0 of f0_0 : uint8 * f0_1 : US7
    | US8_1 of f1_0 : uint8 * f1_1 : US7
and [<Struct>] US9 =
    | US9_0 of f0_0 : US7
    | US9_1 of f1_0 : std_string_String
and [<Struct>] US10 =
    | US10_0 of f0_0 : uint8
    | US10_1 of f1_0 : std_string_String
let rec method0 () : clap_Command =
    let v0 : string = "command"
    let v1 : string = "r#\"" + v0 + "\"#"
    let v2 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v1 
    let v3 : string = "clap::Command::new($0)"
    let v4 : clap_Command = Fable.Core.RustInterop.emitRustExpr v2 v3 
    let v5 : string = "clap::Command::args_override_self($0, true)"
    let v6 : clap_Command = Fable.Core.RustInterop.emitRustExpr v4 v5 
    let v8 : unativeint = 0 |> unativeint 
    let v12 : unativeint = 1 |> unativeint 
    let v16 : unativeint = 0 |> unativeint 
    let v20 : bool = v12 = v16 
    let v28 : clap_builder_ValueRange =
        if v20 then
            let v23 : string = "clap::builder::ValueRange::new($0..)"
            let v24 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr v8 v23 
            v24
        else
            let v25 : string = "="
            let v26 : string = "clap::builder::ValueRange::new($0.." + v25 + "$1)"
            let v27 : clap_builder_ValueRange = Fable.Core.RustInterop.emitRustExpr struct (v8, v12) v26 
            v27
    let v29 : string = "exception"
    let v30 : string = "r#\"" + v29 + "\"#"
    let v31 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v30 
    let v32 : string = "clap::Arg::new($0)"
    let v33 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v31 v32 
    let v34 : string = "$0.short($1)"
    let v35 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v33, 'e') v34 
    let v36 : string = "r#\"" + v29 + "\"#"
    let v37 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v36 
    let v38 : string = "$0.long($1)"
    let v39 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v35, v37) v38 
    let v40 : string = "$0.num_args($1)"
    let v41 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v39, v28) v40 
    let v42 : string = "$0.require_equals($1)"
    let v43 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v41, true) v42 
    let v44 : string = ""
    let v45 : string = "r#\"" + v44 + "\"#"
    let v46 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v45 
    let v47 : string = "$0.default_missing_value($1)"
    let v48 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v43, v46) v47 
    let v49 : string = "clap::Command::arg($0, $1)"
    let v50 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v6, v48) v49 
    let v51 : string = "trace_level"
    let v52 : string = "r#\"" + v51 + "\"#"
    let v53 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v52 
    let v54 : string = "clap::Arg::new($0)"
    let v55 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v53 v54 
    let v56 : string = "$0.short($1)"
    let v57 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v55, 't') v56 
    let v58 : string = "r#\"" + v51 + "\"#"
    let v59 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v58 
    let v60 : string = "$0.long($1)"
    let v61 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v57, v59) v60 
    
    
    
    
    
    let v64 : string = "Critical"
    let v65 : (unit -> string) = v64.ToLower
    let v66 : string = v65 ()
    let v71 : string = "Warning"
    let v72 : (unit -> string) = v71.ToLower
    let v73 : string = v72 ()
    let v78 : string = "Info"
    let v79 : (unit -> string) = v78.ToLower
    let v80 : string = v79 ()
    let v85 : string = "Debug"
    let v86 : (unit -> string) = v85.ToLower
    let v87 : string = v86 ()
    let v92 : string = "Verbose"
    let v93 : (unit -> string) = v92.ToLower
    let v94 : string = v93 ()
    let v97 : string list = []
    let v99 : string list = v66 :: v97 
    let v103 : string list = v73 :: v99 
    let v107 : string list = v80 :: v103 
    let v111 : string list = v87 :: v107 
    let v115 : string list = v94 :: v111 
    let v119 : (string list -> (string [])) = List.toArray
    let v120 : (string []) = v119 v115
    let v123 : string = "$0.to_vec()"
    let v124 : Vec<string> = Fable.Core.RustInterop.emitRustExpr v120 v123 
    let v125 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v126 : bool = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let v127 : string = "x"
    let v128 : string = Fable.Core.RustInterop.emitRustExpr () v127 
    (* run_target_args'
    let v133 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v134 : string = "&*$0"
    let v135 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v128 v134 
    let _run_target_args'_v133 = v135 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v136 : string = "&*$0"
    let v137 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v128 v136 
    let _run_target_args'_v133 = v137 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v138 : string = "&*$0"
    let v139 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v128 v138 
    let _run_target_args'_v133 = v139 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v141 : Ref<Str> = v128 |> unbox<Ref<Str>>
    let _run_target_args'_v133 = v141 
    #endif
#if FABLE_COMPILER_PYTHON
    let v145 : Ref<Str> = v128 |> unbox<Ref<Str>>
    let _run_target_args'_v133 = v145 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v149 : Ref<Str> = v128 |> unbox<Ref<Str>>
    let _run_target_args'_v133 = v149 
    #endif
#else
    let v153 : Ref<Str> = v128 |> unbox<Ref<Str>>
    let _run_target_args'_v133 = v153 
    #endif
    let v156 : Ref<Str> = _run_target_args'_v133 
    (* run_target_args'
    let v169 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v170 : string = "String::from($0)"
    let v171 : std_string_String = Fable.Core.RustInterop.emitRustExpr v156 v170 
    let _run_target_args'_v169 = v171 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v172 : string = "String::from($0)"
    let v173 : std_string_String = Fable.Core.RustInterop.emitRustExpr v156 v172 
    let _run_target_args'_v169 = v173 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v174 : string = "String::from($0)"
    let v175 : std_string_String = Fable.Core.RustInterop.emitRustExpr v156 v174 
    let _run_target_args'_v169 = v175 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v177 : std_string_String = v156 |> unbox<std_string_String>
    let _run_target_args'_v169 = v177 
    #endif
#if FABLE_COMPILER_PYTHON
    let v181 : std_string_String = v156 |> unbox<std_string_String>
    let _run_target_args'_v169 = v181 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v185 : std_string_String = v156 |> unbox<std_string_String>
    let _run_target_args'_v169 = v185 
    #endif
#else
    let v189 : std_string_String = v156 |> unbox<std_string_String>
    let _run_target_args'_v169 = v189 
    #endif
    let v192 : std_string_String = _run_target_args'_v169 
    let v201 : string = "Box::new($0)"
    let v202 : Box<std_string_String> = Fable.Core.RustInterop.emitRustExpr v192 v201 
    let v203 : string = "Box::leak($0)"
    let v204 : Ref<Lifetime<StaticLifetime, Mut<std_string_String>>> = Fable.Core.RustInterop.emitRustExpr v202 v203 
    let v205 : string = "clap::builder::PossibleValue::new(&**$0)"
    let v206 : clap_builder_PossibleValue = Fable.Core.RustInterop.emitRustExpr v204 v205 
    let v207 : string = "true; $0 }).collect::<Vec<_>>()"
    let v208 : bool = Fable.Core.RustInterop.emitRustExpr v206 v207 
    let v209 : string = "_vec_map"
    let v210 : Vec<clap_builder_PossibleValue> = Fable.Core.RustInterop.emitRustExpr () v209 
    let v211 : string = "Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new($0))"
    let v212 : clap_builder_ValueParser = Fable.Core.RustInterop.emitRustExpr v210 v211 
    let v213 : string = "$0.value_parser($1)"
    let v214 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v61, v212) v213 
    let v215 : string = "clap::Command::arg($0, $1)"
    let v216 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v50, v214) v215 
    let v217 : string = "wasm"
    let v218 : string = "r#\"" + v217 + "\"#"
    let v219 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v218 
    let v220 : string = "clap::Arg::new($0)"
    let v221 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v219 v220 
    let v222 : string = "$0.short($1)"
    let v223 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v221, 'w') v222 
    let v224 : string = "r#\"" + v217 + "\"#"
    let v225 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v224 
    let v226 : string = "$0.long($1)"
    let v227 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v223, v225) v226 
    let v228 : string = "$0.required($1)"
    let v229 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v227, true) v228 
    let v230 : string = "clap::Command::arg($0, $1)"
    let v231 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v216, v229) v230 
    v231
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
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = method6(v0)
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
    let v16 : string = method7()
    let v17 : string = "$0.unwrap_or($1)"
    let v18 : string = Fable.Core.RustInterop.emitRustExpr struct (v15, v16) v17 
    let _run_target_args'_v2 = v18 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v19 : US5 = US5_1
    let v20 : US6 = US6_4(v19)
    let v21 : string = $"env.get_environment_variable / target: {v20} / var: {v0}"
    let v22 : string = failwith<string> v21
    let _run_target_args'_v2 = v22 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v23 : US5 = US5_2
    let v24 : US6 = US6_4(v23)
    let v25 : string = $"env.get_environment_variable / target: {v24} / var: {v0}"
    let v26 : string = failwith<string> v25
    let _run_target_args'_v2 = v26 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v27 : string = "process.env[$0] ?? \"\""
    let v28 : string = Fable.Core.JsInterop.emitJsExpr v0 v27 
    let _run_target_args'_v2 = v28 
    #endif
#if FABLE_COMPILER_PYTHON
    let v30 : string = "os"
    let v31 : IOsEnviron = Fable.Core.PyInterop.importAll v30 
    let v32 : string = "v31.environ"
    let v33 : obj = Fable.Core.PyInterop.emitPyExpr () v32 
    let v37 : string = "v33.get($0)"
    let v38 : string = Fable.Core.PyInterop.emitPyExpr v0 v37 
    let mutable _v38 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v42 : (string -> string option) = Option.ofObj
    let v43 : string option = v42 v38
    v43 
    #else
    Some v38 
    #endif
    |> fun x -> _v38 <- Some x
    let v44 : string option = match _v38 with Some x -> x | None -> failwith "optionm'.of_obj / _v38=None"
    let v49 : (string -> US7) = method8()
    let v50 : US7 option = v44 |> Option.map v49 
    let v70 : US7 = US7_1
    let v71 : US7 = v50 |> Option.defaultValue v70 
    let v78 : string =
        match v71 with
        | US7_1 -> (* None *)
            let v76 : string = ""
            v76
        | US7_0(v75) -> (* Some *)
            v75
    let _run_target_args'_v2 = v78 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v79 : US5 = US5_1
    let v80 : US6 = US6_1(v79)
    let v81 : string = $"env.get_environment_variable / target: {v80} / var: {v0}"
    let v82 : string = failwith<string> v81
    let _run_target_args'_v2 = v82 
    #endif
#else
    let v83 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v84 : string = v83 v0
    let mutable _v84 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v86 : (string -> string option) = Option.ofObj
    let v87 : string option = v86 v84
    v87 
    #else
    Some v84 
    #endif
    |> fun x -> _v84 <- Some x
    let v88 : string option = match _v84 with Some x -> x | None -> failwith "optionm'.of_obj / _v84=None"
    let v93 : (string -> US7) = method8()
    let v94 : US7 option = v88 |> Option.map v93 
    let v114 : US7 = US7_1
    let v115 : US7 = v94 |> Option.defaultValue v114 
    let v122 : string =
        match v115 with
        | US7_1 -> (* None *)
            let v120 : string = ""
            v120
        | US7_0(v119) -> (* Some *)
            v119
    let _run_target_args'_v2 = v122 
    #endif
    let v123 : string = _run_target_args'_v2 
    v123
and method4 () : struct (US2 * US4) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method5(v0)
    
    
    
    
    
    
    
    
    
    
    let v4 : string = "Critical"
    let v5 : (unit -> string) = v4.ToLower
    let v6 : string = v5 ()
    let v11 : string = "Warning"
    let v12 : (unit -> string) = v11.ToLower
    let v13 : string = v12 ()
    let v18 : string = "Info"
    let v19 : (unit -> string) = v18.ToLower
    let v20 : string = v19 ()
    let v25 : string = "Debug"
    let v26 : (unit -> string) = v25.ToLower
    let v27 : string = v26 ()
    let v32 : string = "Verbose"
    let v33 : (unit -> string) = v32.ToLower
    let v34 : string = v33 ()
    let v37 : bool = "Verbose" = v1
    let v41 : US2 =
        if v37 then
            let v38 : US3 = US3_0
            US2_0(v38)
        else
            US2_1
    let v127 : US2 =
        match v41 with
        | US2_1 -> (* None *)
            let v44 : bool = "Debug" = v1
            let v48 : US2 =
                if v44 then
                    let v45 : US3 = US3_1
                    US2_0(v45)
                else
                    US2_1
            match v48 with
            | US2_1 -> (* None *)
                let v51 : bool = "Info" = v1
                let v55 : US2 =
                    if v51 then
                        let v52 : US3 = US3_2
                        US2_0(v52)
                    else
                        US2_1
                match v55 with
                | US2_1 -> (* None *)
                    let v58 : bool = "Warning" = v1
                    let v62 : US2 =
                        if v58 then
                            let v59 : US3 = US3_3
                            US2_0(v59)
                        else
                            US2_1
                    match v62 with
                    | US2_1 -> (* None *)
                        let v65 : bool = "Critical" = v1
                        let v69 : US2 =
                            if v65 then
                                let v66 : US3 = US3_4
                                US2_0(v66)
                            else
                                US2_1
                        match v69 with
                        | US2_1 -> (* None *)
                            let v72 : bool = v34 = v1
                            let v76 : US2 =
                                if v72 then
                                    let v73 : US3 = US3_0
                                    US2_0(v73)
                                else
                                    US2_1
                            match v76 with
                            | US2_1 -> (* None *)
                                let v79 : bool = v27 = v1
                                let v83 : US2 =
                                    if v79 then
                                        let v80 : US3 = US3_1
                                        US2_0(v80)
                                    else
                                        US2_1
                                match v83 with
                                | US2_1 -> (* None *)
                                    let v86 : bool = v20 = v1
                                    let v90 : US2 =
                                        if v86 then
                                            let v87 : US3 = US3_2
                                            US2_0(v87)
                                        else
                                            US2_1
                                    match v90 with
                                    | US2_1 -> (* None *)
                                        let v93 : bool = v13 = v1
                                        let v97 : US2 =
                                            if v93 then
                                                let v94 : US3 = US3_3
                                                US2_0(v94)
                                            else
                                                US2_1
                                        match v97 with
                                        | US2_1 -> (* None *)
                                            let v100 : bool = v6 = v1
                                            let v104 : US2 =
                                                if v100 then
                                                    let v101 : US3 = US3_4
                                                    US2_0(v101)
                                                else
                                                    US2_1
                                            match v104 with
                                            | US2_1 -> (* None *)
                                                US2_1
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
                        | US2_0(v70) -> (* Some *)
                            US2_0(v70)
                    | US2_0(v63) -> (* Some *)
                        US2_0(v63)
                | US2_0(v56) -> (* Some *)
                    US2_0(v56)
            | US2_0(v49) -> (* Some *)
                US2_0(v49)
        | US2_0(v42) -> (* Some *)
            US2_0(v42)
    let v128 : string = "AUTOMATION"
    let v129 : string = method5(v128)
    let v132 : string = "True"
    let v133 : bool = v129 <> v132 
    let v210 : US4 =
        if v133 then
            US4_1
        else
            (* run_target_args'
            let v143 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v144 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v143 = v144 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v145 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v143 = v145 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v147 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v143 = v147 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v150 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v143 = v150 
            #endif
#if FABLE_COMPILER_PYTHON
            let v151 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v143 = v151 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v152 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v143 = v152 
            #endif
#else
            let v153 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v143 = v153 
            #endif
            let v154 : System.DateTime = _run_target_args'_v143 
            (* run_target_args'
            let v165 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v166 : (System.DateTime -> int64) = _.Ticks
            let v167 : int64 = v166 v154
            let _run_target_args'_v165 = v167 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v168 : (System.DateTime -> int64) = _.Ticks
            let v169 : int64 = v168 v154
            let _run_target_args'_v165 = v169 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v171 : int64 = null |> unbox<int64>
            let _run_target_args'_v165 = v171 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v174 : (System.DateTime -> int64) = _.Ticks
            let v175 : int64 = v174 v154
            let _run_target_args'_v165 = v175 
            #endif
#if FABLE_COMPILER_PYTHON
            let v176 : (System.DateTime -> int64) = _.Ticks
            let v177 : int64 = v176 v154
            let _run_target_args'_v165 = v177 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v178 : (System.DateTime -> int64) = _.Ticks
            let v179 : int64 = v178 v154
            let _run_target_args'_v165 = v179 
            #endif
#else
            let v180 : (System.DateTime -> int64) = _.Ticks
            let v181 : int64 = v180 v154
            let _run_target_args'_v165 = v181 
            #endif
            let v182 : int64 = _run_target_args'_v165 
            let v204 : int64 = v182 |> int64 
            US4_0(v204)
    struct (v127, v210)
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
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "option_env!(\"" + v8 + "\").unwrap_or(\"\")"
    let v15 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v14 
    (* run_target_args'
    let v20 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v21 : string = "String::from($0)"
    let v22 : std_string_String = Fable.Core.RustInterop.emitRustExpr v15 v21 
    let _run_target_args'_v20 = v22 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v23 : string = "String::from($0)"
    let v24 : std_string_String = Fable.Core.RustInterop.emitRustExpr v15 v23 
    let _run_target_args'_v20 = v24 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v25 : string = "String::from($0)"
    let v26 : std_string_String = Fable.Core.RustInterop.emitRustExpr v15 v25 
    let _run_target_args'_v20 = v26 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v28 : std_string_String = v15 |> unbox<std_string_String>
    let _run_target_args'_v20 = v28 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : std_string_String = v15 |> unbox<std_string_String>
    let _run_target_args'_v20 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v36 : std_string_String = v15 |> unbox<std_string_String>
    let _run_target_args'_v20 = v36 
    #endif
#else
    let v40 : std_string_String = v15 |> unbox<std_string_String>
    let _run_target_args'_v20 = v40 
    #endif
    let v43 : std_string_String = _run_target_args'_v20 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v43 v52 
    let _run_target_args'_v13 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "option_env!(\"" + v8 + "\").unwrap_or(\"\")"
    let v55 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v54 
    (* run_target_args'
    let v60 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v61 : string = "String::from($0)"
    let v62 : std_string_String = Fable.Core.RustInterop.emitRustExpr v55 v61 
    let _run_target_args'_v60 = v62 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v63 : string = "String::from($0)"
    let v64 : std_string_String = Fable.Core.RustInterop.emitRustExpr v55 v63 
    let _run_target_args'_v60 = v64 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v65 : string = "String::from($0)"
    let v66 : std_string_String = Fable.Core.RustInterop.emitRustExpr v55 v65 
    let _run_target_args'_v60 = v66 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v68 : std_string_String = v55 |> unbox<std_string_String>
    let _run_target_args'_v60 = v68 
    #endif
#if FABLE_COMPILER_PYTHON
    let v72 : std_string_String = v55 |> unbox<std_string_String>
    let _run_target_args'_v60 = v72 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : std_string_String = v55 |> unbox<std_string_String>
    let _run_target_args'_v60 = v76 
    #endif
#else
    let v80 : std_string_String = v55 |> unbox<std_string_String>
    let _run_target_args'_v60 = v80 
    #endif
    let v83 : std_string_String = _run_target_args'_v60 
    let v92 : string = "fable_library_rust::String_::fromString($0)"
    let v93 : string = Fable.Core.RustInterop.emitRustExpr v83 v92 
    let _run_target_args'_v13 = v93 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v94 : string = "option_env!(\"" + v8 + "\").unwrap_or(\"\")"
    let v95 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v94 
    (* run_target_args'
    let v100 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v101 : string = "String::from($0)"
    let v102 : std_string_String = Fable.Core.RustInterop.emitRustExpr v95 v101 
    let _run_target_args'_v100 = v102 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v103 : string = "String::from($0)"
    let v104 : std_string_String = Fable.Core.RustInterop.emitRustExpr v95 v103 
    let _run_target_args'_v100 = v104 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v105 : string = "String::from($0)"
    let v106 : std_string_String = Fable.Core.RustInterop.emitRustExpr v95 v105 
    let _run_target_args'_v100 = v106 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v108 : std_string_String = v95 |> unbox<std_string_String>
    let _run_target_args'_v100 = v108 
    #endif
#if FABLE_COMPILER_PYTHON
    let v112 : std_string_String = v95 |> unbox<std_string_String>
    let _run_target_args'_v100 = v112 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v116 : std_string_String = v95 |> unbox<std_string_String>
    let _run_target_args'_v100 = v116 
    #endif
#else
    let v120 : std_string_String = v95 |> unbox<std_string_String>
    let _run_target_args'_v100 = v120 
    #endif
    let v123 : std_string_String = _run_target_args'_v100 
    let v132 : string = "fable_library_rust::String_::fromString($0)"
    let v133 : string = Fable.Core.RustInterop.emitRustExpr v123 v132 
    let _run_target_args'_v13 = v133 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v135 : string = null |> unbox<string>
    let _run_target_args'_v13 = v135 
    #endif
#if FABLE_COMPILER_PYTHON
    let v139 : string = null |> unbox<string>
    let _run_target_args'_v13 = v139 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v143 : string = null |> unbox<string>
    let _run_target_args'_v13 = v143 
    #endif
#else
    let v147 : string = null |> unbox<string>
    let _run_target_args'_v13 = v147 
    #endif
    let v150 : string = _run_target_args'_v13 
    let v161 : string = "True"
    let v162 : bool = v150 <> v161 
    let v174 : US4 =
        if v162 then
            US4_1
        else
            let v166 : string = $"near_sdk::env::block_timestamp()"
            let v167 : uint64 = Fable.Core.RustInterop.emitRustExpr () v166 
            let v169 : (uint64 -> int64) = int64
            let v170 : int64 = v169 v167
            US4_0(v170)
    let v175 : US2 = US2_1
    let _run_target_args'_v3 = struct (v175, v174) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v176 : US2, v177 : US4) = method4()
    let _run_target_args'_v3 = struct (v176, v177) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v178 : US2, v179 : US4) = method4()
    let _run_target_args'_v3 = struct (v178, v179) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v180 : US2, v181 : US4) = method4()
    let _run_target_args'_v3 = struct (v180, v181) 
    #endif
#else
    let struct (v182 : US2, v183 : US4) = method4()
    let _run_target_args'_v3 = struct (v182, v183) 
    #endif
    let struct (v184 : US2, v185 : US4) = _run_target_args'_v3 
    let v190 : Mut0 = {l0 = 1L} : Mut0
    let v191 : (string -> unit) = closure4()
    let v192 : Mut1 = {l0 = v191} : Mut1
    let v193 : Mut2 = {l0 = true} : Mut2
    let v194 : string = ""
    let v195 : Mut3 = {l0 = v194} : Mut3
    let v198 : US3 =
        match v184 with
        | US2_1 -> (* None *)
            v0
        | US2_0(v196) -> (* Some *)
            v196
    let v199 : Mut4 = {l0 = v198} : Mut4
    let v210 : int64 option =
        match v185 with
        | US4_1 -> (* None *)
            let v206 : int64 option = None
            v206
        | US4_0(v200) -> (* Some *)
            let v202 : int64 option = Some v200 
            v202
    struct (v190, v192, v193, v195, v199, v210)
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
and method9 (v0 : US3) : bool =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v38 : Mut0, v39 : Mut1, v40 : Mut2, v41 : Mut3, v42 : Mut4, v43 : int64 option) = TraceState.trace_state.Value
    let v56 : US3 = v42.l0
    let v57 : bool = v40.l0
    let v58 : bool = v57 = false
    if v58 then
        false
    else
        let v59 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v0
        let v60 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v56
        let v61 : bool = v59 >= v60
        v61
and closure7 () (v0 : int64) : US4 =
    US4_0(v0)
and method11 () : (int64 -> US4) =
    closure7()
and method12 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method13 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method10 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v195 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v198 : (int64 -> US4) = method11()
    let v199 : US4 option = v5 |> Option.map v198 
    let v219 : US4 = US4_1
    let v220 : US4 = v199 |> Option.defaultValue v219 
    let v360 : System.DateTime =
        match v220 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v343 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v344 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v344 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v345 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v345 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v347 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v343 = v347 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v350 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v350 
            #endif
#if FABLE_COMPILER_PYTHON
            let v351 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v351 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v352 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v352 
            #endif
#else
            let v353 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v353 
            #endif
            let v354 : System.DateTime = _run_target_args'_v343 
            v354
        | US4_0(v224) -> (* Some *)
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
            let v235 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v231 = v235 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v238 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v238 
            #endif
#if FABLE_COMPILER_PYTHON
            let v239 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v239 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v240 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v240 
            #endif
#else
            let v241 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v241 
            #endif
            let v242 : System.DateTime = _run_target_args'_v231 
            (* run_target_args'
            let v253 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v254 : (System.DateTime -> int64) = _.Ticks
            let v255 : int64 = v254 v242
            let _run_target_args'_v253 = v255 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v256 : (System.DateTime -> int64) = _.Ticks
            let v257 : int64 = v256 v242
            let _run_target_args'_v253 = v257 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v259 : int64 = null |> unbox<int64>
            let _run_target_args'_v253 = v259 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v262 : (System.DateTime -> int64) = _.Ticks
            let v263 : int64 = v262 v242
            let _run_target_args'_v253 = v263 
            #endif
#if FABLE_COMPILER_PYTHON
            let v264 : (System.DateTime -> int64) = _.Ticks
            let v265 : int64 = v264 v242
            let _run_target_args'_v253 = v265 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v266 : (System.DateTime -> int64) = _.Ticks
            let v267 : int64 = v266 v242
            let _run_target_args'_v253 = v267 
            #endif
#else
            let v268 : (System.DateTime -> int64) = _.Ticks
            let v269 : int64 = v268 v242
            let _run_target_args'_v253 = v269 
            #endif
            let v270 : int64 = _run_target_args'_v253 
            let v292 : int64 = v270 |> int64 
            let v297 : int64 = v292 - v224
            let v303 : System.TimeSpan = v297 |> System.TimeSpan 
            let v309 : (System.TimeSpan -> int32) = _.Hours
            let v310 : int32 = v309 v303
            let v314 : (System.TimeSpan -> int32) = _.Minutes
            let v315 : int32 = v314 v303
            let v319 : (System.TimeSpan -> int32) = _.Seconds
            let v320 : int32 = v319 v303
            let v324 : (System.TimeSpan -> int32) = _.Milliseconds
            let v325 : int32 = v324 v303
            let v334 : System.DateTime = System.DateTime (1, 1, 1, v310, v315, v320, v325)
            v334
    let v361 : string = method12()
    let v363 : bool = v361 = ""
    let v365 : string =
        if v363 then
            let v364 : string = "M-d-y hh:mm:ss tt"
            v364
        else
            v361
    let v366 : (string -> string) = v360.ToString
    let v367 : string = v366 v365
    let _run_target_args'_v195 = v367 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v384 : (int64 -> US4) = method11()
    let v385 : US4 option = v5 |> Option.map v384 
    let v405 : US4 = US4_1
    let v406 : US4 = v385 |> Option.defaultValue v405 
    let v546 : System.DateTime =
        match v406 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v529 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v530 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v530 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v531 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v531 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v533 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v529 = v533 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v536 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v536 
            #endif
#if FABLE_COMPILER_PYTHON
            let v537 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v537 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v538 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v538 
            #endif
#else
            let v539 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v539 
            #endif
            let v540 : System.DateTime = _run_target_args'_v529 
            v540
        | US4_0(v410) -> (* Some *)
            (* run_target_args'
            let v417 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v418 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v418 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v419 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v419 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v421 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v417 = v421 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v424 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v424 
            #endif
#if FABLE_COMPILER_PYTHON
            let v425 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v425 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v426 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v426 
            #endif
#else
            let v427 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v427 
            #endif
            let v428 : System.DateTime = _run_target_args'_v417 
            (* run_target_args'
            let v439 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v440 : (System.DateTime -> int64) = _.Ticks
            let v441 : int64 = v440 v428
            let _run_target_args'_v439 = v441 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v442 : (System.DateTime -> int64) = _.Ticks
            let v443 : int64 = v442 v428
            let _run_target_args'_v439 = v443 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v445 : int64 = null |> unbox<int64>
            let _run_target_args'_v439 = v445 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v448 : (System.DateTime -> int64) = _.Ticks
            let v449 : int64 = v448 v428
            let _run_target_args'_v439 = v449 
            #endif
#if FABLE_COMPILER_PYTHON
            let v450 : (System.DateTime -> int64) = _.Ticks
            let v451 : int64 = v450 v428
            let _run_target_args'_v439 = v451 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v452 : (System.DateTime -> int64) = _.Ticks
            let v453 : int64 = v452 v428
            let _run_target_args'_v439 = v453 
            #endif
#else
            let v454 : (System.DateTime -> int64) = _.Ticks
            let v455 : int64 = v454 v428
            let _run_target_args'_v439 = v455 
            #endif
            let v456 : int64 = _run_target_args'_v439 
            let v478 : int64 = v456 |> int64 
            let v483 : int64 = v478 - v410
            let v489 : System.TimeSpan = v483 |> System.TimeSpan 
            let v495 : (System.TimeSpan -> int32) = _.Hours
            let v496 : int32 = v495 v489
            let v500 : (System.TimeSpan -> int32) = _.Minutes
            let v501 : int32 = v500 v489
            let v505 : (System.TimeSpan -> int32) = _.Seconds
            let v506 : int32 = v505 v489
            let v510 : (System.TimeSpan -> int32) = _.Milliseconds
            let v511 : int32 = v510 v489
            let v520 : System.DateTime = System.DateTime (1, 1, 1, v496, v501, v506, v511)
            v520
    let v547 : string = method12()
    let v549 : bool = v547 = ""
    let v551 : string =
        if v549 then
            let v550 : string = "M-d-y hh:mm:ss tt"
            v550
        else
            v547
    let v552 : (string -> string) = v546.ToString
    let v553 : string = v552 v551
    let _run_target_args'_v195 = v553 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v568 : string = $"near_sdk::env::block_timestamp()"
    let v569 : uint64 = Fable.Core.RustInterop.emitRustExpr () v568 
    let v572 : (int64 -> US4) = method11()
    let v573 : US4 option = v5 |> Option.map v572 
    let v593 : US4 = US4_1
    let v594 : US4 = v573 |> Option.defaultValue v593 
    let v606 : uint64 =
        match v594 with
        | US4_1 -> (* None *)
            v569
        | US4_0(v598) -> (* Some *)
            let v600 : (int64 -> uint64) = uint64
            let v601 : uint64 = v600 v598
            let v604 : uint64 = v569 - v601
            v604
    let v607 : uint64 = v606 / 1000000000UL
    let v608 : uint64 = v607 % 60UL
    let v609 : uint64 = v607 / 60UL
    let v610 : uint64 = v609 % 60UL
    let v611 : uint64 = v607 / 3600UL
    let v612 : uint64 = v611 % 24UL
    let v613 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v614 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v612, v610, v608) v613 
    let v615 : string = "fable_library_rust::String_::fromString($0)"
    let v616 : string = Fable.Core.RustInterop.emitRustExpr v614 v615 
    let _run_target_args'_v195 = v616 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v619 : (int64 -> US4) = method11()
    let v620 : US4 option = v5 |> Option.map v619 
    let v640 : US4 = US4_1
    let v641 : US4 = v620 |> Option.defaultValue v640 
    let v781 : System.DateTime =
        match v641 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v764 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v765 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v765 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v766 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v766 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v768 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v764 = v768 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v771 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v771 
            #endif
#if FABLE_COMPILER_PYTHON
            let v772 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v772 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v773 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v773 
            #endif
#else
            let v774 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v774 
            #endif
            let v775 : System.DateTime = _run_target_args'_v764 
            v775
        | US4_0(v645) -> (* Some *)
            (* run_target_args'
            let v652 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v653 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v652 = v653 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v654 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v652 = v654 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v656 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v652 = v656 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v659 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v652 = v659 
            #endif
#if FABLE_COMPILER_PYTHON
            let v660 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v652 = v660 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v661 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v652 = v661 
            #endif
#else
            let v662 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v652 = v662 
            #endif
            let v663 : System.DateTime = _run_target_args'_v652 
            (* run_target_args'
            let v674 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v675 : (System.DateTime -> int64) = _.Ticks
            let v676 : int64 = v675 v663
            let _run_target_args'_v674 = v676 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v677 : (System.DateTime -> int64) = _.Ticks
            let v678 : int64 = v677 v663
            let _run_target_args'_v674 = v678 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v680 : int64 = null |> unbox<int64>
            let _run_target_args'_v674 = v680 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v683 : (System.DateTime -> int64) = _.Ticks
            let v684 : int64 = v683 v663
            let _run_target_args'_v674 = v684 
            #endif
#if FABLE_COMPILER_PYTHON
            let v685 : (System.DateTime -> int64) = _.Ticks
            let v686 : int64 = v685 v663
            let _run_target_args'_v674 = v686 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v687 : (System.DateTime -> int64) = _.Ticks
            let v688 : int64 = v687 v663
            let _run_target_args'_v674 = v688 
            #endif
#else
            let v689 : (System.DateTime -> int64) = _.Ticks
            let v690 : int64 = v689 v663
            let _run_target_args'_v674 = v690 
            #endif
            let v691 : int64 = _run_target_args'_v674 
            let v713 : int64 = v691 |> int64 
            let v718 : int64 = v713 - v645
            let v724 : System.TimeSpan = v718 |> System.TimeSpan 
            let v730 : (System.TimeSpan -> int32) = _.Hours
            let v731 : int32 = v730 v724
            let v735 : (System.TimeSpan -> int32) = _.Minutes
            let v736 : int32 = v735 v724
            let v740 : (System.TimeSpan -> int32) = _.Seconds
            let v741 : int32 = v740 v724
            let v745 : (System.TimeSpan -> int32) = _.Milliseconds
            let v746 : int32 = v745 v724
            let v755 : System.DateTime = System.DateTime (1, 1, 1, v731, v736, v741, v746)
            v755
    let v782 : string = method13()
    let v784 : bool = v782 = ""
    let v786 : string =
        if v784 then
            let v785 : string = "M-d-y hh:mm:ss tt"
            v785
        else
            v782
    let v787 : (string -> string) = v781.ToString
    let v788 : string = v787 v786
    let _run_target_args'_v195 = v788 
    #endif
#if FABLE_COMPILER_PYTHON
    let v805 : (int64 -> US4) = method11()
    let v806 : US4 option = v5 |> Option.map v805 
    let v826 : US4 = US4_1
    let v827 : US4 = v806 |> Option.defaultValue v826 
    let v967 : System.DateTime =
        match v827 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v950 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v951 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v951 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v952 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v952 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v954 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v950 = v954 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v957 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v957 
            #endif
#if FABLE_COMPILER_PYTHON
            let v958 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v958 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v959 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v959 
            #endif
#else
            let v960 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v960 
            #endif
            let v961 : System.DateTime = _run_target_args'_v950 
            v961
        | US4_0(v831) -> (* Some *)
            (* run_target_args'
            let v838 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v839 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v839 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v840 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v840 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v842 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v838 = v842 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v845 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v845 
            #endif
#if FABLE_COMPILER_PYTHON
            let v846 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v846 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v847 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v847 
            #endif
#else
            let v848 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v848 
            #endif
            let v849 : System.DateTime = _run_target_args'_v838 
            (* run_target_args'
            let v860 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v861 : (System.DateTime -> int64) = _.Ticks
            let v862 : int64 = v861 v849
            let _run_target_args'_v860 = v862 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v863 : (System.DateTime -> int64) = _.Ticks
            let v864 : int64 = v863 v849
            let _run_target_args'_v860 = v864 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v866 : int64 = null |> unbox<int64>
            let _run_target_args'_v860 = v866 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v869 : (System.DateTime -> int64) = _.Ticks
            let v870 : int64 = v869 v849
            let _run_target_args'_v860 = v870 
            #endif
#if FABLE_COMPILER_PYTHON
            let v871 : (System.DateTime -> int64) = _.Ticks
            let v872 : int64 = v871 v849
            let _run_target_args'_v860 = v872 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v873 : (System.DateTime -> int64) = _.Ticks
            let v874 : int64 = v873 v849
            let _run_target_args'_v860 = v874 
            #endif
#else
            let v875 : (System.DateTime -> int64) = _.Ticks
            let v876 : int64 = v875 v849
            let _run_target_args'_v860 = v876 
            #endif
            let v877 : int64 = _run_target_args'_v860 
            let v899 : int64 = v877 |> int64 
            let v904 : int64 = v899 - v831
            let v910 : System.TimeSpan = v904 |> System.TimeSpan 
            let v916 : (System.TimeSpan -> int32) = _.Hours
            let v917 : int32 = v916 v910
            let v921 : (System.TimeSpan -> int32) = _.Minutes
            let v922 : int32 = v921 v910
            let v926 : (System.TimeSpan -> int32) = _.Seconds
            let v927 : int32 = v926 v910
            let v931 : (System.TimeSpan -> int32) = _.Milliseconds
            let v932 : int32 = v931 v910
            let v941 : System.DateTime = System.DateTime (1, 1, 1, v917, v922, v927, v932)
            v941
    let v968 : string = method13()
    let v970 : bool = v968 = ""
    let v972 : string =
        if v970 then
            let v971 : string = "M-d-y hh:mm:ss tt"
            v971
        else
            v968
    let v973 : (string -> string) = v967.ToString
    let v974 : string = v973 v972
    let _run_target_args'_v195 = v974 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v991 : (int64 -> US4) = method11()
    let v992 : US4 option = v5 |> Option.map v991 
    let v1012 : US4 = US4_1
    let v1013 : US4 = v992 |> Option.defaultValue v1012 
    let v1153 : System.DateTime =
        match v1013 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1136 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1137 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1137 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1138 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1138 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1140 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1136 = v1140 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1143 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1143 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1144 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1144 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1145 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1145 
            #endif
#else
            let v1146 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1146 
            #endif
            let v1147 : System.DateTime = _run_target_args'_v1136 
            v1147
        | US4_0(v1017) -> (* Some *)
            (* run_target_args'
            let v1024 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1025 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1025 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1026 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1026 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1028 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1024 = v1028 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1031 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1031 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1032 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1032 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1033 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1033 
            #endif
#else
            let v1034 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1034 
            #endif
            let v1035 : System.DateTime = _run_target_args'_v1024 
            (* run_target_args'
            let v1046 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1047 : (System.DateTime -> int64) = _.Ticks
            let v1048 : int64 = v1047 v1035
            let _run_target_args'_v1046 = v1048 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1049 : (System.DateTime -> int64) = _.Ticks
            let v1050 : int64 = v1049 v1035
            let _run_target_args'_v1046 = v1050 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1052 : int64 = null |> unbox<int64>
            let _run_target_args'_v1046 = v1052 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1055 : (System.DateTime -> int64) = _.Ticks
            let v1056 : int64 = v1055 v1035
            let _run_target_args'_v1046 = v1056 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1057 : (System.DateTime -> int64) = _.Ticks
            let v1058 : int64 = v1057 v1035
            let _run_target_args'_v1046 = v1058 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1059 : (System.DateTime -> int64) = _.Ticks
            let v1060 : int64 = v1059 v1035
            let _run_target_args'_v1046 = v1060 
            #endif
#else
            let v1061 : (System.DateTime -> int64) = _.Ticks
            let v1062 : int64 = v1061 v1035
            let _run_target_args'_v1046 = v1062 
            #endif
            let v1063 : int64 = _run_target_args'_v1046 
            let v1085 : int64 = v1063 |> int64 
            let v1090 : int64 = v1085 - v1017
            let v1096 : System.TimeSpan = v1090 |> System.TimeSpan 
            let v1102 : (System.TimeSpan -> int32) = _.Hours
            let v1103 : int32 = v1102 v1096
            let v1107 : (System.TimeSpan -> int32) = _.Minutes
            let v1108 : int32 = v1107 v1096
            let v1112 : (System.TimeSpan -> int32) = _.Seconds
            let v1113 : int32 = v1112 v1096
            let v1117 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1118 : int32 = v1117 v1096
            let v1127 : System.DateTime = System.DateTime (1, 1, 1, v1103, v1108, v1113, v1118)
            v1127
    let v1154 : string = method13()
    let v1156 : bool = v1154 = ""
    let v1158 : string =
        if v1156 then
            let v1157 : string = "M-d-y hh:mm:ss tt"
            v1157
        else
            v1154
    let v1159 : (string -> string) = v1153.ToString
    let v1160 : string = v1159 v1158
    let _run_target_args'_v195 = v1160 
    #endif
#else
    let v1177 : (int64 -> US4) = method11()
    let v1178 : US4 option = v5 |> Option.map v1177 
    let v1198 : US4 = US4_1
    let v1199 : US4 = v1178 |> Option.defaultValue v1198 
    let v1339 : System.DateTime =
        match v1199 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1322 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1323 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1323 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1324 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1324 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1326 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1322 = v1326 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1329 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1329 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1330 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1330 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1331 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1331 
            #endif
#else
            let v1332 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1332 
            #endif
            let v1333 : System.DateTime = _run_target_args'_v1322 
            v1333
        | US4_0(v1203) -> (* Some *)
            (* run_target_args'
            let v1210 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1211 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1211 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1212 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1212 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1214 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1210 = v1214 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1217 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1217 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1218 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1218 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1219 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1219 
            #endif
#else
            let v1220 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1220 
            #endif
            let v1221 : System.DateTime = _run_target_args'_v1210 
            (* run_target_args'
            let v1232 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1233 : (System.DateTime -> int64) = _.Ticks
            let v1234 : int64 = v1233 v1221
            let _run_target_args'_v1232 = v1234 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1235 : (System.DateTime -> int64) = _.Ticks
            let v1236 : int64 = v1235 v1221
            let _run_target_args'_v1232 = v1236 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1238 : int64 = null |> unbox<int64>
            let _run_target_args'_v1232 = v1238 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1241 : (System.DateTime -> int64) = _.Ticks
            let v1242 : int64 = v1241 v1221
            let _run_target_args'_v1232 = v1242 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1243 : (System.DateTime -> int64) = _.Ticks
            let v1244 : int64 = v1243 v1221
            let _run_target_args'_v1232 = v1244 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1245 : (System.DateTime -> int64) = _.Ticks
            let v1246 : int64 = v1245 v1221
            let _run_target_args'_v1232 = v1246 
            #endif
#else
            let v1247 : (System.DateTime -> int64) = _.Ticks
            let v1248 : int64 = v1247 v1221
            let _run_target_args'_v1232 = v1248 
            #endif
            let v1249 : int64 = _run_target_args'_v1232 
            let v1271 : int64 = v1249 |> int64 
            let v1276 : int64 = v1271 - v1203
            let v1282 : System.TimeSpan = v1276 |> System.TimeSpan 
            let v1288 : (System.TimeSpan -> int32) = _.Hours
            let v1289 : int32 = v1288 v1282
            let v1293 : (System.TimeSpan -> int32) = _.Minutes
            let v1294 : int32 = v1293 v1282
            let v1298 : (System.TimeSpan -> int32) = _.Seconds
            let v1299 : int32 = v1298 v1282
            let v1303 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1304 : int32 = v1303 v1282
            let v1313 : System.DateTime = System.DateTime (1, 1, 1, v1289, v1294, v1299, v1304)
            v1313
    let v1340 : string = method13()
    let v1342 : bool = v1340 = ""
    let v1344 : string =
        if v1342 then
            let v1343 : string = "M-d-y hh:mm:ss tt"
            v1343
        else
            v1340
    let v1345 : (string -> string) = v1339.ToString
    let v1346 : string = v1345 v1344
    let _run_target_args'_v195 = v1346 
    #endif
    let v1361 : string = _run_target_args'_v195 
    v1361
and method15 () : string =
    let v0 : string = ""
    v0
and closure8 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v4 : string = v2 + v1 
    v0.l0 <- v4
    ()
and method16 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method14 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method15()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v9, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v30 : string = v9.l0
    (* run_target_args'
    let v47 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v48 : string = "inline_colorization::color_bright_black"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    (* run_target_args'
    let v54 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v55 : string = "&*$0"
    let v56 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v55 
    let _run_target_args'_v54 = v56 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v57 : string = "&*$0"
    let v58 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v57 
    let _run_target_args'_v54 = v58 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v59 : string = "&*$0"
    let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v59 
    let _run_target_args'_v54 = v60 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v62 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v62 
    #endif
#if FABLE_COMPILER_PYTHON
    let v66 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v66 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v70 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v70 
    #endif
#else
    let v74 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v74 
    #endif
    let v77 : Ref<Str> = _run_target_args'_v54 
    let v86 : string = "inline_colorization::color_reset"
    let v87 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v87) v88 
    let v90 : string = "fable_library_rust::String_::fromString($0)"
    let v91 : string = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let _run_target_args'_v47 = v91 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v92 : string = "inline_colorization::color_bright_black"
    let v93 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v92 
    (* run_target_args'
    let v98 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v99 : string = "&*$0"
    let v100 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v99 
    let _run_target_args'_v98 = v100 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v101 : string = "&*$0"
    let v102 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v101 
    let _run_target_args'_v98 = v102 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v103 
    let _run_target_args'_v98 = v104 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v106 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v106 
    #endif
#if FABLE_COMPILER_PYTHON
    let v110 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v110 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v114 
    #endif
#else
    let v118 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v118 
    #endif
    let v121 : Ref<Str> = _run_target_args'_v98 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v93, v121, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v47 = v135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v136 : string = "inline_colorization::color_bright_black"
    let v137 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v136 
    (* run_target_args'
    let v142 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v143 : string = "&*$0"
    let v144 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v143 
    let _run_target_args'_v142 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "&*$0"
    let v146 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v145 
    let _run_target_args'_v142 = v146 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v147 : string = "&*$0"
    let v148 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v147 
    let _run_target_args'_v142 = v148 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v150 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v150 
    #endif
#if FABLE_COMPILER_PYTHON
    let v154 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v154 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v158 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v158 
    #endif
#else
    let v162 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v162 
    #endif
    let v165 : Ref<Str> = _run_target_args'_v142 
    let v174 : string = "inline_colorization::color_reset"
    let v175 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v174 
    let v176 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v177 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v137, v165, v175) v176 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v177 v178 
    let _run_target_args'_v47 = v179 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v181 : string = "\u001b[90m"
    let v185 : string = method16()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[90m"
    let v201 : string = method16()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[90m"
    let v217 : string = method16()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[90m"
    let v233 : string = method16()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method18 (v0 : string) : string =
    let v1 : char list = []
    let v4 : (char list -> (char [])) = List.toArray
    let v5 : (char []) = v4 v1
    let v8 : string = v0.TrimStart v5 
    let v42 : char list = []
    let v44 : char list = '/' :: v42 
    let v48 : char list = ' ' :: v44 
    let v53 : (char list -> (char [])) = List.toArray
    let v54 : (char []) = v53 v48
    let v57 : string = v8.TrimEnd v54 
    v57
and method17 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : (string [])) : string =
    let v9 : string = method15()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "args"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure8(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v69 : string = $"%A{v8}"
    let v73 : string = $"{v69}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure8(v10, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = " }"
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure8(v10, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v108 : string = v10.l0
    let v109 : int64 = v0.l0
    let v112 : string = " "
    let v113 : string = v6 + v112 
    let v117 : string = v113 + v7 
    let v122 : string = " #"
    let v123 : string = v117 + v122 
    let v127 : (int64 -> string) = _.ToString()
    let v128 : string = v127 v109
    let v132 : string = v123 + v128 
    let v136 : string = v132 + v112 
    let v141 : string = "spiral_wasm.main"
    let v142 : string = v136 + v141 
    let v147 : string = " / "
    let v148 : string = v142 + v147 
    let v152 : string = v148 + v108 
    method18(v152)
and closure9 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure11 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure10 () (v0 : string) : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure11(v0)
    let v4 : unit = (fun () -> v3 (); v2) ()
    ()
and method19 (v0 : string) : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v38 : Mut0, v39 : Mut1, v40 : Mut2, v41 : Mut3, v42 : Mut4, v43 : int64 option) = TraceState.trace_state.Value
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure9(v38)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v63 : (string -> unit) = closure10()
    (* run_target_args'
    let v64 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v65 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v65 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v66 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v66 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v67 : string = v41.l0
    let v68 : bool = v67 = ""
    let v83 : string =
        if v68 then
            v0
        else
            let v69 : bool = v0 = ""
            if v69 then
                let v70 : string = v41.l0
                v70
            else
                let v71 : string = v41.l0
                let v74 : string = "\n"
                let v75 : string = v71 + v74 
                let v79 : string = v75 + v0 
                v79
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "&*$0"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "&*$0"
    let v92 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "&*$0"
    let v94 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : Ref<Str> = v83 |> unbox<Ref<Str>>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : Ref<Str> = v83 |> unbox<Ref<Str>>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : Ref<Str> = v83 |> unbox<Ref<Str>>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : Ref<Str> = v83 |> unbox<Ref<Str>>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : Ref<Str> = _run_target_args'_v88 
    let v120 : string = $"$0.chars()"
    let v121 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let v122 : string = "$0"
    let v123 : _ = Fable.Core.RustInterop.emitRustExpr v121 v122 
    let v124 : string = "$0.collect::<Vec<_>>()"
    let v125 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v123 v124 
    let v126 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v127 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v125 v126 
    let v128 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v129 : bool = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let v130 : string = "x"
    let v131 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = "String::from_iter($0)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr v131 v132 
    let v134 : string = "true; $0 }).collect::<Vec<_>>()"
    let v135 : bool = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let v136 : string = "_vec_map"
    let v137 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v136 
    let v138 : string = "$0.len()"
    let v139 : unativeint = Fable.Core.RustInterop.emitRustExpr v137 v138 
    let v145 : int32 = v139 |> int32 
    let v155 : string = ""
    let v156 : bool = v0 <> v155 
    let v160 : bool =
        if v156 then
            let v159 : bool = v145 <= 1
            v159
        else
            false
    if v160 then
        v41.l0 <- v83
        ()
    else
        v41.l0 <- v155
        let v161 : string = "true; $0.into_iter().for_each(|x| { //"
        let v162 : bool = Fable.Core.RustInterop.emitRustExpr v137 v161 
        let v163 : string = "x"
        let v164 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v163 
        let v165 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v166 : bool = Fable.Core.RustInterop.emitRustExpr v164 v165 
        let v167 : string = $"true"
        let v168 : bool = Fable.Core.RustInterop.emitRustExpr () v167 
        let v169 : string = "true; }); //"
        let v170 : bool = Fable.Core.RustInterop.emitRustExpr () v169 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v63 v0
    #endif
#if FABLE_COMPILER_PYTHON
    v63 v0
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v63 v0
    #endif
#else
    v63 v0
    #endif
    // run_target_args' is_unit
    let v171 : (string -> unit) = v39.l0
    v171 v0
and closure5 (v0 : (string [])) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure6()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method10(v40, v41, v42, v43, v44, v45)
        let v59 : string = method14()
        let v60 : string = method17(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method19(v60)
and method20 () : string =
    let v0 : string = "exception"
    v0
and closure12 () (v0 : std_string_String) : string =
    let v1 : string = "fable_library_rust::String_::fromString($0)"
    let v2 : string = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : char list = []
    let v5 : char list = '\\' :: v3 
    let v10 : (char list -> (char [])) = List.toArray
    let v11 : (char []) = v10 v5
    let v14 : string = v2.TrimStart v11 
    let v48 : char list = []
    let v50 : char list = '\\' :: v48 
    let v55 : (char list -> (char [])) = List.toArray
    let v56 : (char []) = v55 v50
    let v59 : string = v14.TrimEnd v56 
    v59
and method21 () : (std_string_String -> string) =
    closure12()
and method23 () : string =
    let v0 : string = "wasm"
    v0
and method24 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method15()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "wasm_path"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure8(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v69 : string = $"{v8}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure8(v10, v69)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v87 : string = " }"
    let v88 : string = $"{v87}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure8(v10, v88)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v104 : string = v10.l0
    let v105 : int64 = v0.l0
    let v108 : string = " "
    let v109 : string = v6 + v108 
    let v113 : string = v109 + v7 
    let v118 : string = " #"
    let v119 : string = v113 + v118 
    let v123 : (int64 -> string) = _.ToString()
    let v124 : string = v123 v105
    let v128 : string = v119 + v124 
    let v132 : string = v128 + v108 
    let v137 : string = "spiral_wasm.run"
    let v138 : string = v132 + v137 
    let v143 : string = " / "
    let v144 : string = v138 + v143 
    let v148 : string = v144 + v104 
    method18(v148)
and closure13 (v0 : string) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure6()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method10(v40, v41, v42, v43, v44, v45)
        let v59 : string = method14()
        let v60 : string = method24(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method19(v60)
and method27 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v10 : near_workspaces_Contract) : string =
    let v11 : string = method15()
    let v12 : Mut3 = {l0 = v11} : Mut3
    let v15 : string = "{ "
    let v16 : string = $"{v15}"
    let v24 : unit = ()
    let v25 : (unit -> unit) = closure8(v12, v16)
    let v26 : unit = (fun () -> v25 (); v24) ()
    let v34 : string = "retry"
    let v35 : string = $"{v34}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure8(v12, v35)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v53 : string = " = "
    let v54 : string = $"{v53}"
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure8(v12, v54)
    let v64 : unit = (fun () -> v63 (); v62) ()
    let v74 : string = $"{v8}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure8(v12, v74)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v92 : string = "; "
    let v93 : string = $"{v92}"
    let v101 : unit = ()
    let v102 : (unit -> unit) = closure8(v12, v93)
    let v103 : unit = (fun () -> v102 (); v101) ()
    let v111 : string = "worker"
    let v112 : string = $"{v111}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure8(v12, v112)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v129 : string = $"{v53}"
    let v137 : unit = ()
    let v138 : (unit -> unit) = closure8(v12, v129)
    let v139 : unit = (fun () -> v138 (); v137) ()
    (* run_target_args'
    let v149 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v150 : string = "format!(\"{:#?}\", $0)"
    let v151 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v150 
    let v152 : string = "fable_library_rust::String_::fromString($0)"
    let v153 : string = Fable.Core.RustInterop.emitRustExpr v151 v152 
    let _run_target_args'_v149 = v153 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v154 : string = "format!(\"{:#?}\", $0)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v154 
    let v156 : string = "fable_library_rust::String_::fromString($0)"
    let v157 : string = Fable.Core.RustInterop.emitRustExpr v155 v156 
    let _run_target_args'_v149 = v157 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v158 : string = "format!(\"{:#?}\", $0)"
    let v159 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v158 
    let v160 : string = "fable_library_rust::String_::fromString($0)"
    let v161 : string = Fable.Core.RustInterop.emitRustExpr v159 v160 
    let _run_target_args'_v149 = v161 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v163 : string = $"%A{v9}"
    let _run_target_args'_v149 = v163 
    #endif
#if FABLE_COMPILER_PYTHON
    let v167 : string = $"%A{v9}"
    let _run_target_args'_v149 = v167 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v171 : string = $"%A{v9}"
    let _run_target_args'_v149 = v171 
    #endif
#else
    let v175 : string = $"%A{v9}"
    let _run_target_args'_v149 = v175 
    #endif
    let v178 : string = _run_target_args'_v149 
    let v188 : string = $"{v178}"
    let v196 : unit = ()
    let v197 : (unit -> unit) = closure8(v12, v188)
    let v198 : unit = (fun () -> v197 (); v196) ()
    let v205 : string = $"{v92}"
    let v213 : unit = ()
    let v214 : (unit -> unit) = closure8(v12, v205)
    let v215 : unit = (fun () -> v214 (); v213) ()
    let v223 : string = "contract"
    let v224 : string = $"{v223}"
    let v232 : unit = ()
    let v233 : (unit -> unit) = closure8(v12, v224)
    let v234 : unit = (fun () -> v233 (); v232) ()
    let v241 : string = $"{v53}"
    let v249 : unit = ()
    let v250 : (unit -> unit) = closure8(v12, v241)
    let v251 : unit = (fun () -> v250 (); v249) ()
    (* run_target_args'
    let v261 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v262 : string = "format!(\"{:#?}\", $0)"
    let v263 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v262 
    let v264 : string = "fable_library_rust::String_::fromString($0)"
    let v265 : string = Fable.Core.RustInterop.emitRustExpr v263 v264 
    let _run_target_args'_v261 = v265 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v266 : string = "format!(\"{:#?}\", $0)"
    let v267 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v266 
    let v268 : string = "fable_library_rust::String_::fromString($0)"
    let v269 : string = Fable.Core.RustInterop.emitRustExpr v267 v268 
    let _run_target_args'_v261 = v269 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v270 : string = "format!(\"{:#?}\", $0)"
    let v271 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v270 
    let v272 : string = "fable_library_rust::String_::fromString($0)"
    let v273 : string = Fable.Core.RustInterop.emitRustExpr v271 v272 
    let _run_target_args'_v261 = v273 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v275 : string = $"%A{v10}"
    let _run_target_args'_v261 = v275 
    #endif
#if FABLE_COMPILER_PYTHON
    let v279 : string = $"%A{v10}"
    let _run_target_args'_v261 = v279 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v283 : string = $"%A{v10}"
    let _run_target_args'_v261 = v283 
    #endif
#else
    let v287 : string = $"%A{v10}"
    let _run_target_args'_v261 = v287 
    #endif
    let v290 : string = _run_target_args'_v261 
    let v300 : string = $"{v290}"
    let v308 : unit = ()
    let v309 : (unit -> unit) = closure8(v12, v300)
    let v310 : unit = (fun () -> v309 (); v308) ()
    let v318 : string = " }"
    let v319 : string = $"{v318}"
    let v327 : unit = ()
    let v328 : (unit -> unit) = closure8(v12, v319)
    let v329 : unit = (fun () -> v328 (); v327) ()
    let v335 : string = v12.l0
    let v336 : int64 = v0.l0
    let v339 : string = " "
    let v340 : string = v6 + v339 
    let v344 : string = v340 + v7 
    let v349 : string = " #"
    let v350 : string = v344 + v349 
    let v354 : (int64 -> string) = _.ToString()
    let v355 : string = v354 v336
    let v359 : string = v350 + v355 
    let v363 : string = v359 + v339 
    let v368 : string = "spiral_wasm.run"
    let v369 : string = v363 + v368 
    let v374 : string = " / "
    let v375 : string = v369 + v374 
    let v379 : string = v375 + v335 
    method18(v379)
and closure14 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) () : unit =
    let v3 : US3 = US3_0
    let v4 : bool = method9(v3)
    if v4 then
        let v19 : unit = ()
        let v20 : (unit -> unit) = closure6()
        let v21 : unit = (fun () -> v20 (); v19) ()
        let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
        let v60 : string = method10(v42, v43, v44, v45, v46, v47)
        let v61 : string = method14()
        let v62 : string = method27(v42, v43, v44, v45, v46, v47, v60, v61, v0, v1, v2)
        method19(v62)
and method28 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_result_ExecutionFinalResult) : string =
    let v10 : string = method15()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure8(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "retry"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure8(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v73 : string = $"{v8}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure8(v11, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure8(v11, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "result"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure8(v11, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v52}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure8(v11, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    (* run_target_args'
    let v148 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v149 : string = "format!(\"{:#?}\", $0)"
    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v149 
    let v151 : string = "fable_library_rust::String_::fromString($0)"
    let v152 : string = Fable.Core.RustInterop.emitRustExpr v150 v151 
    let _run_target_args'_v148 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "format!(\"{:#?}\", $0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v153 
    let v155 : string = "fable_library_rust::String_::fromString($0)"
    let v156 : string = Fable.Core.RustInterop.emitRustExpr v154 v155 
    let _run_target_args'_v148 = v156 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v157 : string = "format!(\"{:#?}\", $0)"
    let v158 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v157 
    let v159 : string = "fable_library_rust::String_::fromString($0)"
    let v160 : string = Fable.Core.RustInterop.emitRustExpr v158 v159 
    let _run_target_args'_v148 = v160 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v162 : string = $"%A{v9}"
    let _run_target_args'_v148 = v162 
    #endif
#if FABLE_COMPILER_PYTHON
    let v166 : string = $"%A{v9}"
    let _run_target_args'_v148 = v166 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v170 : string = $"%A{v9}"
    let _run_target_args'_v148 = v170 
    #endif
#else
    let v174 : string = $"%A{v9}"
    let _run_target_args'_v148 = v174 
    #endif
    let v177 : string = _run_target_args'_v148 
    let v187 : string = $"{v177}"
    let v195 : unit = ()
    let v196 : (unit -> unit) = closure8(v11, v187)
    let v197 : unit = (fun () -> v196 (); v195) ()
    let v205 : string = " }"
    let v206 : string = $"{v205}"
    let v214 : unit = ()
    let v215 : (unit -> unit) = closure8(v11, v206)
    let v216 : unit = (fun () -> v215 (); v214) ()
    let v222 : string = v11.l0
    let v223 : int64 = v0.l0
    let v226 : string = " "
    let v227 : string = v6 + v226 
    let v231 : string = v227 + v7 
    let v236 : string = " #"
    let v237 : string = v231 + v236 
    let v241 : (int64 -> string) = _.ToString()
    let v242 : string = v241 v223
    let v246 : string = v237 + v242 
    let v250 : string = v246 + v226 
    let v255 : string = "spiral_wasm.run"
    let v256 : string = v250 + v255 
    let v261 : string = " / "
    let v262 : string = v256 + v261 
    let v266 : string = v262 + v222 
    method18(v266)
and closure15 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) () : unit =
    let v2 : US3 = US3_0
    let v3 : bool = method9(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure6()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method10(v41, v42, v43, v44, v45, v46)
        let v60 : string = method14()
        let v61 : string = method28(v41, v42, v43, v44, v45, v46, v59, v60, v0, v1)
        method19(v61)
and closure17 (v0 : std_string_String) () : unit =
    let v1 : (std_string_String -> unit) = System.Console.WriteLine
    v1 v0
and closure16 () (v0 : std_string_String) : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure17(v0)
    let v4 : unit = (fun () -> v3 (); v2) ()
    ()
and method29 () : unit =
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure6()
    let v16 : unit = (fun () -> v15 (); v14) ()
    let struct (v37 : Mut0, v38 : Mut1, v39 : Mut2, v40 : Mut3, v41 : Mut4, v42 : int64 option) = TraceState.trace_state.Value
    let v57 : unit = ()
    let v58 : (unit -> unit) = closure9(v37)
    let v59 : unit = (fun () -> v58 (); v57) ()
    let v62 : string = " "
    let v63 : (string -> unit) = closure10()
    (* run_target_args'
    let v64 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v65 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v62 v65 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v66 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v62 v66 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v67 : string = v40.l0
    let v68 : bool = v67 = ""
    let v83 : string =
        if v68 then
            v62
        else
            let v69 : bool = v62 = ""
            if v69 then
                let v70 : string = v40.l0
                v70
            else
                let v71 : string = v40.l0
                let v74 : string = "\n"
                let v75 : string = v71 + v74 
                let v79 : string = v75 + v62 
                v79
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "&*$0"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "&*$0"
    let v92 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "&*$0"
    let v94 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : Ref<Str> = v83 |> unbox<Ref<Str>>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : Ref<Str> = v83 |> unbox<Ref<Str>>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : Ref<Str> = v83 |> unbox<Ref<Str>>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : Ref<Str> = v83 |> unbox<Ref<Str>>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : Ref<Str> = _run_target_args'_v88 
    let v120 : string = $"$0.chars()"
    let v121 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let v122 : string = "$0"
    let v123 : _ = Fable.Core.RustInterop.emitRustExpr v121 v122 
    let v124 : string = "$0.collect::<Vec<_>>()"
    let v125 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v123 v124 
    let v126 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v127 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v125 v126 
    let v128 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v129 : bool = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let v130 : string = "x"
    let v131 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = "String::from_iter($0)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr v131 v132 
    let v134 : string = "true; $0 }).collect::<Vec<_>>()"
    let v135 : bool = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let v136 : string = "_vec_map"
    let v137 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v136 
    let v138 : string = "$0.len()"
    let v139 : unativeint = Fable.Core.RustInterop.emitRustExpr v137 v138 
    let v145 : int32 = v139 |> int32 
    let v155 : string = ""
    let v156 : bool = v62 <> v155 
    let v160 : bool =
        if v156 then
            let v159 : bool = v145 <= 1
            v159
        else
            false
    if v160 then
        v40.l0 <- v83
        ()
    else
        v40.l0 <- v155
        let v161 : string = "true; $0.into_iter().for_each(|x| { //"
        let v162 : bool = Fable.Core.RustInterop.emitRustExpr v137 v161 
        let v163 : string = "x"
        let v164 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v163 
        let v165 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v166 : bool = Fable.Core.RustInterop.emitRustExpr v164 v165 
        let v167 : string = $"true"
        let v168 : bool = Fable.Core.RustInterop.emitRustExpr () v167 
        let v169 : string = "true; }); //"
        let v170 : bool = Fable.Core.RustInterop.emitRustExpr () v169 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v63 v62
    #endif
#if FABLE_COMPILER_PYTHON
    v63 v62
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v63 v62
    #endif
#else
    v63 v62
    #endif
    // run_target_args' is_unit
    let v171 : (string -> unit) = v38.l0
    v171 v62
and closure18 () () : unit =
    let v0 : US3 = US3_2
    let v1 : bool = method9(v0)
    if v1 then
        method29()
and method30 () : string =
    
    
    
    
    
    let v2 : string = "Info"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method15()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v9, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v30 : string = v9.l0
    (* run_target_args'
    let v47 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v48 : string = "inline_colorization::color_bright_green"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    (* run_target_args'
    let v54 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v55 : string = "&*$0"
    let v56 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v55 
    let _run_target_args'_v54 = v56 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v57 : string = "&*$0"
    let v58 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v57 
    let _run_target_args'_v54 = v58 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v59 : string = "&*$0"
    let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v59 
    let _run_target_args'_v54 = v60 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v62 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v62 
    #endif
#if FABLE_COMPILER_PYTHON
    let v66 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v66 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v70 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v70 
    #endif
#else
    let v74 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v74 
    #endif
    let v77 : Ref<Str> = _run_target_args'_v54 
    let v86 : string = "inline_colorization::color_reset"
    let v87 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v87) v88 
    let v90 : string = "fable_library_rust::String_::fromString($0)"
    let v91 : string = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let _run_target_args'_v47 = v91 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v92 : string = "inline_colorization::color_bright_green"
    let v93 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v92 
    (* run_target_args'
    let v98 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v99 : string = "&*$0"
    let v100 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v99 
    let _run_target_args'_v98 = v100 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v101 : string = "&*$0"
    let v102 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v101 
    let _run_target_args'_v98 = v102 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v103 
    let _run_target_args'_v98 = v104 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v106 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v106 
    #endif
#if FABLE_COMPILER_PYTHON
    let v110 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v110 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v114 
    #endif
#else
    let v118 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v118 
    #endif
    let v121 : Ref<Str> = _run_target_args'_v98 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v93, v121, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v47 = v135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v136 : string = "inline_colorization::color_bright_green"
    let v137 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v136 
    (* run_target_args'
    let v142 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v143 : string = "&*$0"
    let v144 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v143 
    let _run_target_args'_v142 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "&*$0"
    let v146 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v145 
    let _run_target_args'_v142 = v146 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v147 : string = "&*$0"
    let v148 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v147 
    let _run_target_args'_v142 = v148 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v150 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v150 
    #endif
#if FABLE_COMPILER_PYTHON
    let v154 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v154 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v158 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v158 
    #endif
#else
    let v162 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v162 
    #endif
    let v165 : Ref<Str> = _run_target_args'_v142 
    let v174 : string = "inline_colorization::color_reset"
    let v175 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v174 
    let v176 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v177 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v137, v165, v175) v176 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v177 v178 
    let _run_target_args'_v47 = v179 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v181 : string = "\u001b[92m"
    let v185 : string = method16()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[92m"
    let v201 : string = method16()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[92m"
    let v217 : string = method16()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[92m"
    let v233 : string = method16()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method31 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : float, v10 : uint64) : string =
    let v11 : string = method15()
    let v12 : Mut3 = {l0 = v11} : Mut3
    let v15 : string = "{ "
    let v16 : string = $"{v15}"
    let v24 : unit = ()
    let v25 : (unit -> unit) = closure8(v12, v16)
    let v26 : unit = (fun () -> v25 (); v24) ()
    let v34 : string = "retry"
    let v35 : string = $"{v34}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure8(v12, v35)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v53 : string = " = "
    let v54 : string = $"{v53}"
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure8(v12, v54)
    let v64 : unit = (fun () -> v63 (); v62) ()
    let v74 : string = $"{v8}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure8(v12, v74)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v92 : string = "; "
    let v93 : string = $"{v92}"
    let v101 : unit = ()
    let v102 : (unit -> unit) = closure8(v12, v93)
    let v103 : unit = (fun () -> v102 (); v101) ()
    let v111 : string = "total_gas_burnt_usd"
    let v112 : string = $"{v111}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure8(v12, v112)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v129 : string = $"{v53}"
    let v137 : unit = ()
    let v138 : (unit -> unit) = closure8(v12, v129)
    let v139 : unit = (fun () -> v138 (); v137) ()
    let v149 : string = $"%+.6f{v9}"
    let v157 : unit = ()
    let v158 : (unit -> unit) = closure8(v12, v149)
    let v159 : unit = (fun () -> v158 (); v157) ()
    let v166 : string = $"{v92}"
    let v174 : unit = ()
    let v175 : (unit -> unit) = closure8(v12, v166)
    let v176 : unit = (fun () -> v175 (); v174) ()
    let v184 : string = "total_gas_burnt"
    let v185 : string = $"{v184}"
    let v193 : unit = ()
    let v194 : (unit -> unit) = closure8(v12, v185)
    let v195 : unit = (fun () -> v194 (); v193) ()
    let v202 : string = $"{v53}"
    let v210 : unit = ()
    let v211 : (unit -> unit) = closure8(v12, v202)
    let v212 : unit = (fun () -> v211 (); v210) ()
    let v222 : string = $"{v10}"
    let v230 : unit = ()
    let v231 : (unit -> unit) = closure8(v12, v222)
    let v232 : unit = (fun () -> v231 (); v230) ()
    let v240 : string = " }"
    let v241 : string = $"{v240}"
    let v249 : unit = ()
    let v250 : (unit -> unit) = closure8(v12, v241)
    let v251 : unit = (fun () -> v250 (); v249) ()
    let v257 : string = v12.l0
    let v258 : int64 = v0.l0
    let v261 : string = " "
    let v262 : string = v6 + v261 
    let v266 : string = v262 + v7 
    let v271 : string = " #"
    let v272 : string = v266 + v271 
    let v276 : (int64 -> string) = _.ToString()
    let v277 : string = v276 v258
    let v281 : string = v272 + v277 
    let v285 : string = v281 + v261 
    let v290 : string = "near_workspaces.print_usd"
    let v291 : string = v285 + v290 
    let v296 : string = " / "
    let v297 : string = v291 + v296 
    let v301 : string = v297 + v257 
    method18(v301)
and closure19 (v0 : uint8, v1 : uint64, v2 : float) () : unit =
    let v3 : US3 = US3_2
    let v4 : bool = method9(v3)
    if v4 then
        let v19 : unit = ()
        let v20 : (unit -> unit) = closure6()
        let v21 : unit = (fun () -> v20 (); v19) ()
        let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
        let v60 : string = method10(v42, v43, v44, v45, v46, v47)
        let v61 : string = method30()
        let v62 : string = method31(v42, v43, v44, v45, v46, v47, v60, v61, v0, v2, v1)
        method19(v62)
and method32 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : bool, v9 : float, v10 : float, v11 : uint64, v12 : u128) : string =
    let v13 : string = method15()
    let v14 : Mut3 = {l0 = v13} : Mut3
    let v17 : string = "{ "
    let v18 : string = $"{v17}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure8(v14, v18)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v36 : string = "is_success"
    let v37 : string = $"{v36}"
    let v45 : unit = ()
    let v46 : (unit -> unit) = closure8(v14, v37)
    let v47 : unit = (fun () -> v46 (); v45) ()
    let v55 : string = " = "
    let v56 : string = $"{v55}"
    let v64 : unit = ()
    let v65 : (unit -> unit) = closure8(v14, v56)
    let v66 : unit = (fun () -> v65 (); v64) ()
    let v74 : string =
        if v8 then
            let v72 : string = "true"
            v72
        else
            let v73 : string = "false"
            v73
    let v76 : string = $"{v74}"
    let v84 : unit = ()
    let v85 : (unit -> unit) = closure8(v14, v76)
    let v86 : unit = (fun () -> v85 (); v84) ()
    let v94 : string = "; "
    let v95 : string = $"{v94}"
    let v103 : unit = ()
    let v104 : (unit -> unit) = closure8(v14, v95)
    let v105 : unit = (fun () -> v104 (); v103) ()
    let v113 : string = "gas_burnt_usd"
    let v114 : string = $"{v113}"
    let v122 : unit = ()
    let v123 : (unit -> unit) = closure8(v14, v114)
    let v124 : unit = (fun () -> v123 (); v122) ()
    let v131 : string = $"{v55}"
    let v139 : unit = ()
    let v140 : (unit -> unit) = closure8(v14, v131)
    let v141 : unit = (fun () -> v140 (); v139) ()
    let v151 : string = $"%+.6f{v9}"
    let v159 : unit = ()
    let v160 : (unit -> unit) = closure8(v14, v151)
    let v161 : unit = (fun () -> v160 (); v159) ()
    let v168 : string = $"{v94}"
    let v176 : unit = ()
    let v177 : (unit -> unit) = closure8(v14, v168)
    let v178 : unit = (fun () -> v177 (); v176) ()
    let v186 : string = "tokens_burnt_usd"
    let v187 : string = $"{v186}"
    let v195 : unit = ()
    let v196 : (unit -> unit) = closure8(v14, v187)
    let v197 : unit = (fun () -> v196 (); v195) ()
    let v204 : string = $"{v55}"
    let v212 : unit = ()
    let v213 : (unit -> unit) = closure8(v14, v204)
    let v214 : unit = (fun () -> v213 (); v212) ()
    let v224 : string = $"%+.6f{v10}"
    let v232 : unit = ()
    let v233 : (unit -> unit) = closure8(v14, v224)
    let v234 : unit = (fun () -> v233 (); v232) ()
    let v241 : string = $"{v94}"
    let v249 : unit = ()
    let v250 : (unit -> unit) = closure8(v14, v241)
    let v251 : unit = (fun () -> v250 (); v249) ()
    let v259 : string = "gas_burnt"
    let v260 : string = $"{v259}"
    let v268 : unit = ()
    let v269 : (unit -> unit) = closure8(v14, v260)
    let v270 : unit = (fun () -> v269 (); v268) ()
    let v277 : string = $"{v55}"
    let v285 : unit = ()
    let v286 : (unit -> unit) = closure8(v14, v277)
    let v287 : unit = (fun () -> v286 (); v285) ()
    let v297 : string = $"{v11}"
    let v305 : unit = ()
    let v306 : (unit -> unit) = closure8(v14, v297)
    let v307 : unit = (fun () -> v306 (); v305) ()
    let v314 : string = $"{v94}"
    let v322 : unit = ()
    let v323 : (unit -> unit) = closure8(v14, v314)
    let v324 : unit = (fun () -> v323 (); v322) ()
    let v332 : string = "tokens_burnt"
    let v333 : string = $"{v332}"
    let v341 : unit = ()
    let v342 : (unit -> unit) = closure8(v14, v333)
    let v343 : unit = (fun () -> v342 (); v341) ()
    let v350 : string = $"{v55}"
    let v358 : unit = ()
    let v359 : (unit -> unit) = closure8(v14, v350)
    let v360 : unit = (fun () -> v359 (); v358) ()
    (* run_target_args'
    let v370 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v371 : string = "format!(\"{:#?}\", $0)"
    let v372 : std_string_String = Fable.Core.RustInterop.emitRustExpr v12 v371 
    let v373 : string = "fable_library_rust::String_::fromString($0)"
    let v374 : string = Fable.Core.RustInterop.emitRustExpr v372 v373 
    let _run_target_args'_v370 = v374 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v375 : string = "format!(\"{:#?}\", $0)"
    let v376 : std_string_String = Fable.Core.RustInterop.emitRustExpr v12 v375 
    let v377 : string = "fable_library_rust::String_::fromString($0)"
    let v378 : string = Fable.Core.RustInterop.emitRustExpr v376 v377 
    let _run_target_args'_v370 = v378 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v379 : string = "format!(\"{:#?}\", $0)"
    let v380 : std_string_String = Fable.Core.RustInterop.emitRustExpr v12 v379 
    let v381 : string = "fable_library_rust::String_::fromString($0)"
    let v382 : string = Fable.Core.RustInterop.emitRustExpr v380 v381 
    let _run_target_args'_v370 = v382 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v384 : string = $"%A{v12}"
    let _run_target_args'_v370 = v384 
    #endif
#if FABLE_COMPILER_PYTHON
    let v388 : string = $"%A{v12}"
    let _run_target_args'_v370 = v388 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v392 : string = $"%A{v12}"
    let _run_target_args'_v370 = v392 
    #endif
#else
    let v396 : string = $"%A{v12}"
    let _run_target_args'_v370 = v396 
    #endif
    let v399 : string = _run_target_args'_v370 
    let v409 : string = $"{v399}"
    let v417 : unit = ()
    let v418 : (unit -> unit) = closure8(v14, v409)
    let v419 : unit = (fun () -> v418 (); v417) ()
    let v427 : string = " }"
    let v428 : string = $"{v427}"
    let v436 : unit = ()
    let v437 : (unit -> unit) = closure8(v14, v428)
    let v438 : unit = (fun () -> v437 (); v436) ()
    let v444 : string = v14.l0
    let v445 : int64 = v0.l0
    let v448 : string = " "
    let v449 : string = v6 + v448 
    let v453 : string = v449 + v7 
    let v458 : string = " #"
    let v459 : string = v453 + v458 
    let v463 : (int64 -> string) = _.ToString()
    let v464 : string = v463 v445
    let v468 : string = v459 + v464 
    let v472 : string = v468 + v448 
    let v477 : string = "near_workspaces.print_usd / outcome"
    let v478 : string = v472 + v477 
    let v483 : string = " / "
    let v484 : string = v478 + v483 
    let v488 : string = v484 + v444 
    method18(v488)
and closure21 (v0 : bool, v1 : uint64, v2 : float, v3 : u128, v4 : float) () : unit =
    let v5 : US3 = US3_2
    let v6 : bool = method9(v5)
    if v6 then
        let v21 : unit = ()
        let v22 : (unit -> unit) = closure6()
        let v23 : unit = (fun () -> v22 (); v21) ()
        let struct (v44 : Mut0, v45 : Mut1, v46 : Mut2, v47 : Mut3, v48 : Mut4, v49 : int64 option) = TraceState.trace_state.Value
        let v62 : string = method10(v44, v45, v46, v47, v48, v49)
        let v63 : string = method30()
        let v64 : string = method32(v44, v45, v46, v47, v48, v49, v62, v63, v0, v2, v4, v1, v3)
        method19(v64)
and closure20 () (v0 : near_workspaces_result_ExecutionOutcome) : unit =
    let v1 : string = "$0.is_success()"
    let v2 : bool = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : string = "$0.gas_burnt"
    let v4 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let v5 : string = "$0.as_gas()"
    let v6 : uint64 = Fable.Core.RustInterop.emitRustExpr v4 v5 
    let v8 : (uint64 -> float) = float
    let v9 : float = v8 v6
    let v12 : float = v9 / 10000000000000000.0
    let v13 : float = v12 * 6.68
    let v14 : string = "$0.tokens_burnt"
    let v15 : near_workspaces_types_NearToken = Fable.Core.RustInterop.emitRustExpr v0 v14 
    let v16 : string = "$0.as_yoctonear()"
    let v17 : u128 = Fable.Core.RustInterop.emitRustExpr v15 v16 
    let v18 : string = "$0 as f64"
    let v19 : float = Fable.Core.RustInterop.emitRustExpr v17 v18 
    let v20 : float = v19 / 1E+24
    let v21 : float = v20 * 6.68
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure21(v2, v6, v13, v17, v21)
    let v84 : unit = (fun () -> v83 (); v82) ()
    ()
and method33 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v9 : string = method15()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "result2"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure8(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    (* run_target_args'
    let v72 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v73 : string = "format!(\"{:#?}\", $0)"
    let v74 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v73 
    let v75 : string = "fable_library_rust::String_::fromString($0)"
    let v76 : string = Fable.Core.RustInterop.emitRustExpr v74 v75 
    let _run_target_args'_v72 = v76 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v77 : string = "format!(\"{:#?}\", $0)"
    let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v72 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "format!(\"{:#?}\", $0)"
    let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let v83 : string = "fable_library_rust::String_::fromString($0)"
    let v84 : string = Fable.Core.RustInterop.emitRustExpr v82 v83 
    let _run_target_args'_v72 = v84 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v86 : string = $"%A{v8}"
    let _run_target_args'_v72 = v86 
    #endif
#if FABLE_COMPILER_PYTHON
    let v90 : string = $"%A{v8}"
    let _run_target_args'_v72 = v90 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v94 : string = $"%A{v8}"
    let _run_target_args'_v72 = v94 
    #endif
#else
    let v98 : string = $"%A{v8}"
    let _run_target_args'_v72 = v98 
    #endif
    let v101 : string = _run_target_args'_v72 
    let v111 : string = $"{v101}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure8(v10, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v129 : string = " }"
    let v130 : string = $"{v129}"
    let v138 : unit = ()
    let v139 : (unit -> unit) = closure8(v10, v130)
    let v140 : unit = (fun () -> v139 (); v138) ()
    let v146 : string = v10.l0
    let v147 : int64 = v0.l0
    let v150 : string = " "
    let v151 : string = v6 + v150 
    let v155 : string = v151 + v7 
    let v160 : string = " #"
    let v161 : string = v155 + v160 
    let v165 : (int64 -> string) = _.ToString()
    let v166 : string = v165 v147
    let v170 : string = v161 + v166 
    let v174 : string = v170 + v150 
    let v179 : string = "spiral_wasm.run"
    let v180 : string = v174 + v179 
    let v185 : string = " / "
    let v186 : string = v180 + v185 
    let v190 : string = v186 + v146 
    method18(v190)
and closure22 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure6()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method10(v40, v41, v42, v43, v44, v45)
        let v59 : string = method14()
        let v60 : string = method33(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method19(v60)
and method34 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method35 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v10 : string = method15()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure8(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "receipt_failures_len"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure8(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v73 : string = $"{v8}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure8(v11, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure8(v11, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "receipt_failures"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure8(v11, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v52}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure8(v11, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    (* run_target_args'
    let v148 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v149 : string = "format!(\"{:#?}\", $0)"
    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v149 
    let v151 : string = "fable_library_rust::String_::fromString($0)"
    let v152 : string = Fable.Core.RustInterop.emitRustExpr v150 v151 
    let _run_target_args'_v148 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "format!(\"{:#?}\", $0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v153 
    let v155 : string = "fable_library_rust::String_::fromString($0)"
    let v156 : string = Fable.Core.RustInterop.emitRustExpr v154 v155 
    let _run_target_args'_v148 = v156 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v157 : string = "format!(\"{:#?}\", $0)"
    let v158 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v157 
    let v159 : string = "fable_library_rust::String_::fromString($0)"
    let v160 : string = Fable.Core.RustInterop.emitRustExpr v158 v159 
    let _run_target_args'_v148 = v160 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v162 : string = $"%A{v9}"
    let _run_target_args'_v148 = v162 
    #endif
#if FABLE_COMPILER_PYTHON
    let v166 : string = $"%A{v9}"
    let _run_target_args'_v148 = v166 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v170 : string = $"%A{v9}"
    let _run_target_args'_v148 = v170 
    #endif
#else
    let v174 : string = $"%A{v9}"
    let _run_target_args'_v148 = v174 
    #endif
    let v177 : string = _run_target_args'_v148 
    let v187 : string = $"{v177}"
    let v195 : unit = ()
    let v196 : (unit -> unit) = closure8(v11, v187)
    let v197 : unit = (fun () -> v196 (); v195) ()
    let v205 : string = " }"
    let v206 : string = $"{v205}"
    let v214 : unit = ()
    let v215 : (unit -> unit) = closure8(v11, v206)
    let v216 : unit = (fun () -> v215 (); v214) ()
    let v222 : string = v11.l0
    let v223 : int64 = v0.l0
    let v226 : string = " "
    let v227 : string = v6 + v226 
    let v231 : string = v227 + v7 
    let v236 : string = " #"
    let v237 : string = v231 + v236 
    let v241 : (int64 -> string) = _.ToString()
    let v242 : string = v241 v223
    let v246 : string = v237 + v242 
    let v250 : string = v246 + v226 
    let v255 : string = "spiral_wasm.run"
    let v256 : string = v250 + v255 
    let v261 : string = " / "
    let v262 : string = v256 + v261 
    let v266 : string = v262 + v222 
    method18(v266)
and closure23 (v0 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>, v1 : int32) () : unit =
    let v2 : US3 = US3_0
    let v3 : bool = method9(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure6()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method10(v41, v42, v43, v44, v45, v46)
        let v60 : string = method14()
        let v61 : string = method35(v41, v42, v43, v44, v45, v46, v59, v60, v1, v0)
        method19(v61)
and method36 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method37 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v10 : string = method15()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure8(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "receipt_outcomes_len"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure8(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v73 : string = $"{v8}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure8(v11, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure8(v11, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "receipt_outcomes"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure8(v11, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v52}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure8(v11, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    (* run_target_args'
    let v148 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v149 : string = "format!(\"{:#?}\", $0)"
    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v149 
    let v151 : string = "fable_library_rust::String_::fromString($0)"
    let v152 : string = Fable.Core.RustInterop.emitRustExpr v150 v151 
    let _run_target_args'_v148 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "format!(\"{:#?}\", $0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v153 
    let v155 : string = "fable_library_rust::String_::fromString($0)"
    let v156 : string = Fable.Core.RustInterop.emitRustExpr v154 v155 
    let _run_target_args'_v148 = v156 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v157 : string = "format!(\"{:#?}\", $0)"
    let v158 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v157 
    let v159 : string = "fable_library_rust::String_::fromString($0)"
    let v160 : string = Fable.Core.RustInterop.emitRustExpr v158 v159 
    let _run_target_args'_v148 = v160 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v162 : string = $"%A{v9}"
    let _run_target_args'_v148 = v162 
    #endif
#if FABLE_COMPILER_PYTHON
    let v166 : string = $"%A{v9}"
    let _run_target_args'_v148 = v166 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v170 : string = $"%A{v9}"
    let _run_target_args'_v148 = v170 
    #endif
#else
    let v174 : string = $"%A{v9}"
    let _run_target_args'_v148 = v174 
    #endif
    let v177 : string = _run_target_args'_v148 
    let v187 : string = $"{v177}"
    let v195 : unit = ()
    let v196 : (unit -> unit) = closure8(v11, v187)
    let v197 : unit = (fun () -> v196 (); v195) ()
    let v205 : string = " }"
    let v206 : string = $"{v205}"
    let v214 : unit = ()
    let v215 : (unit -> unit) = closure8(v11, v206)
    let v216 : unit = (fun () -> v215 (); v214) ()
    let v222 : string = v11.l0
    let v223 : int64 = v0.l0
    let v226 : string = " "
    let v227 : string = v6 + v226 
    let v231 : string = v227 + v7 
    let v236 : string = " #"
    let v237 : string = v231 + v236 
    let v241 : (int64 -> string) = _.ToString()
    let v242 : string = v241 v223
    let v246 : string = v237 + v242 
    let v250 : string = v246 + v226 
    let v255 : string = "spiral_wasm.run"
    let v256 : string = v250 + v255 
    let v261 : string = " / "
    let v262 : string = v256 + v261 
    let v266 : string = v262 + v222 
    method18(v266)
and closure24 (v0 : Vec<near_workspaces_result_ExecutionOutcome>, v1 : int32) () : unit =
    let v2 : US3 = US3_0
    let v3 : bool = method9(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure6()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method10(v41, v42, v43, v44, v45, v46)
        let v60 : string = method14()
        let v61 : string = method37(v41, v42, v43, v44, v45, v46, v59, v60, v1, v0)
        method19(v61)
and method38 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method15()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "json"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure8(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    (* run_target_args'
    let v72 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v73 : string = "format!(\"{:#?}\", $0)"
    let v74 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v73 
    let v75 : string = "fable_library_rust::String_::fromString($0)"
    let v76 : string = Fable.Core.RustInterop.emitRustExpr v74 v75 
    let _run_target_args'_v72 = v76 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v77 : string = "format!(\"{:#?}\", $0)"
    let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v72 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "format!(\"{:#?}\", $0)"
    let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let v83 : string = "fable_library_rust::String_::fromString($0)"
    let v84 : string = Fable.Core.RustInterop.emitRustExpr v82 v83 
    let _run_target_args'_v72 = v84 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v86 : string = $"%A{v8}"
    let _run_target_args'_v72 = v86 
    #endif
#if FABLE_COMPILER_PYTHON
    let v90 : string = $"%A{v8}"
    let _run_target_args'_v72 = v90 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v94 : string = $"%A{v8}"
    let _run_target_args'_v72 = v94 
    #endif
#else
    let v98 : string = $"%A{v8}"
    let _run_target_args'_v72 = v98 
    #endif
    let v101 : string = _run_target_args'_v72 
    let v111 : string = $"{v101}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure8(v10, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v129 : string = " }"
    let v130 : string = $"{v129}"
    let v138 : unit = ()
    let v139 : (unit -> unit) = closure8(v10, v130)
    let v140 : unit = (fun () -> v139 (); v138) ()
    let v146 : string = v10.l0
    let v147 : int64 = v0.l0
    let v150 : string = " "
    let v151 : string = v6 + v150 
    let v155 : string = v151 + v7 
    let v160 : string = " #"
    let v161 : string = v155 + v160 
    let v165 : (int64 -> string) = _.ToString()
    let v166 : string = v165 v147
    let v170 : string = v161 + v166 
    let v174 : string = v170 + v150 
    let v179 : string = "spiral_wasm.run"
    let v180 : string = v174 + v179 
    let v185 : string = " / "
    let v186 : string = v180 + v185 
    let v190 : string = v186 + v146 
    method18(v190)
and closure25 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure6()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method10(v40, v41, v42, v43, v44, v45)
        let v59 : string = method14()
        let v60 : string = method38(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method19(v60)
and method39 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method15()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "borsh"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure8(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    (* run_target_args'
    let v72 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v73 : string = "format!(\"{:#?}\", $0)"
    let v74 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v73 
    let v75 : string = "fable_library_rust::String_::fromString($0)"
    let v76 : string = Fable.Core.RustInterop.emitRustExpr v74 v75 
    let _run_target_args'_v72 = v76 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v77 : string = "format!(\"{:#?}\", $0)"
    let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v72 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "format!(\"{:#?}\", $0)"
    let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let v83 : string = "fable_library_rust::String_::fromString($0)"
    let v84 : string = Fable.Core.RustInterop.emitRustExpr v82 v83 
    let _run_target_args'_v72 = v84 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v86 : string = $"%A{v8}"
    let _run_target_args'_v72 = v86 
    #endif
#if FABLE_COMPILER_PYTHON
    let v90 : string = $"%A{v8}"
    let _run_target_args'_v72 = v90 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v94 : string = $"%A{v8}"
    let _run_target_args'_v72 = v94 
    #endif
#else
    let v98 : string = $"%A{v8}"
    let _run_target_args'_v72 = v98 
    #endif
    let v101 : string = _run_target_args'_v72 
    let v111 : string = $"{v101}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure8(v10, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v129 : string = " }"
    let v130 : string = $"{v129}"
    let v138 : unit = ()
    let v139 : (unit -> unit) = closure8(v10, v130)
    let v140 : unit = (fun () -> v139 (); v138) ()
    let v146 : string = v10.l0
    let v147 : int64 = v0.l0
    let v150 : string = " "
    let v151 : string = v6 + v150 
    let v155 : string = v151 + v7 
    let v160 : string = " #"
    let v161 : string = v155 + v160 
    let v165 : (int64 -> string) = _.ToString()
    let v166 : string = v165 v147
    let v170 : string = v161 + v166 
    let v174 : string = v170 + v150 
    let v179 : string = "spiral_wasm.run"
    let v180 : string = v174 + v179 
    let v185 : string = " / "
    let v186 : string = v180 + v185 
    let v190 : string = v186 + v146 
    method18(v190)
and closure26 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure6()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method10(v40, v41, v42, v43, v44, v45)
        let v59 : string = method14()
        let v60 : string = method39(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method19(v60)
and method26 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> =
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
    let v80 : unit = ()
    let v81 : (unit -> unit) = closure14(v1, v11, v19)
    let v82 : unit = (fun () -> v81 (); v80) ()
    let v143 : string = "$0.call(&*$1)"
    let v144 : string = "state_main"
    let v145 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr struct (v19, v144) v143 
    let v146 : string = "near_workspaces::types::Gas::from_tgas(300)"
    let v147 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr () v146 
    let v148 : string = "v145.gas(v147)"
    let v149 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr () v148 
    let v150 : string = "Box::pin(v149.transact())"
    let v151 : std_pin_Pin<Box<Dyn<std_future_Future<Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v150 
    let v152 : string = "v151.await"
    let v153 : Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v152 
    let v154 : string = "$0?"
    let v155 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v153 v154 
    let v216 : unit = ()
    let v217 : (unit -> unit) = closure15(v1, v155)
    let v218 : unit = (fun () -> v217 (); v216) ()
    let v279 : string = "v155.logs()"
    let v280 : Vec<Ref<Str>> = Fable.Core.RustInterop.emitRustExpr () v279 
    let v281 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v282 : bool = Fable.Core.RustInterop.emitRustExpr v280 v281 
    let v283 : string = "x"
    let v284 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v283 
    (* run_target_args'
    let v289 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v290 : string = "String::from($0)"
    let v291 : std_string_String = Fable.Core.RustInterop.emitRustExpr v284 v290 
    let _run_target_args'_v289 = v291 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v292 : string = "String::from($0)"
    let v293 : std_string_String = Fable.Core.RustInterop.emitRustExpr v284 v292 
    let _run_target_args'_v289 = v293 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v294 : string = "String::from($0)"
    let v295 : std_string_String = Fable.Core.RustInterop.emitRustExpr v284 v294 
    let _run_target_args'_v289 = v295 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v297 : std_string_String = v284 |> unbox<std_string_String>
    let _run_target_args'_v289 = v297 
    #endif
#if FABLE_COMPILER_PYTHON
    let v301 : std_string_String = v284 |> unbox<std_string_String>
    let _run_target_args'_v289 = v301 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v305 : std_string_String = v284 |> unbox<std_string_String>
    let _run_target_args'_v289 = v305 
    #endif
#else
    let v309 : std_string_String = v284 |> unbox<std_string_String>
    let _run_target_args'_v289 = v309 
    #endif
    let v312 : std_string_String = _run_target_args'_v289 
    let v321 : string = "true; $0 }).collect::<Vec<_>>()"
    let v322 : bool = Fable.Core.RustInterop.emitRustExpr v312 v321 
    let v323 : string = "_vec_map"
    let v324 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v323 
    let v325 : string = "true; $0.iter().for_each(|x| { $1(x.clone()); }); //"
    let v326 : (std_string_String -> unit) = closure16()
    let v327 : bool = Fable.Core.RustInterop.emitRustExpr struct (v324, v326) v325 
    let v330 : unit = ()
    let v331 : (unit -> unit) = closure18()
    let v332 : unit = (fun () -> v331 (); v330) ()
    let v335 : string = "$0.total_gas_burnt"
    let v336 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v155 v335 
    let v337 : string = "$0.as_gas()"
    let v338 : uint64 = Fable.Core.RustInterop.emitRustExpr v336 v337 
    let v340 : (uint64 -> float) = float
    let v341 : float = v340 v338
    let v344 : float = v341 / 10000000000000000.0
    let v345 : float = v344 * 6.68
    let v406 : unit = ()
    let v407 : (unit -> unit) = closure19(v1, v338, v345)
    let v408 : unit = (fun () -> v407 (); v406) ()
    let v469 : string = "$0"
    let v470 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v155 v469 
    let v471 : string = "v470.outcomes()"
    let v472 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v471 
    let v473 : string = "v472.into_iter()"
    let v474 : _ = Fable.Core.RustInterop.emitRustExpr () v473 
    let v475 : string = "v474.cloned()"
    let v476 : _ = Fable.Core.RustInterop.emitRustExpr () v475 
    let v477 : string = "true; v476.for_each(|x| $0(x))"
    let v478 : (near_workspaces_result_ExecutionOutcome -> unit) = closure20()
    let v479 : bool = Fable.Core.RustInterop.emitRustExpr v478 v477 
    let v480 : string = "$0.into_result()"
    let v481 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure> = Fable.Core.RustInterop.emitRustExpr v155 v480 
    let v542 : unit = ()
    let v543 : (unit -> unit) = closure22(v481)
    let v544 : unit = (fun () -> v543 (); v542) ()
    let v605 : near_workspaces_result_ExecutionFinalResult = method34(v155)
    let v606 : string = "v605.receipt_failures()"
    let v607 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v606 
    let v608 : string = "$0.len()"
    let v609 : unativeint = Fable.Core.RustInterop.emitRustExpr v607 v608 
    let v615 : int32 = v609 |> int32 
    let v683 : unit = ()
    let v684 : (unit -> unit) = closure23(v607, v615)
    let v685 : unit = (fun () -> v684 (); v683) ()
    let v746 : near_workspaces_result_ExecutionFinalResult = method36(v155)
    let v747 : string = "v746.receipt_outcomes()"
    let v748 : Ref<Slice<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v747 
    let v749 : string = "v748.into()"
    let v750 : Vec<near_workspaces_result_ExecutionOutcome> = Fable.Core.RustInterop.emitRustExpr () v749 
    let v751 : string = "$0.len()"
    let v752 : unativeint = Fable.Core.RustInterop.emitRustExpr v750 v751 
    let v758 : int32 = v752 |> int32 
    let v826 : unit = ()
    let v827 : (unit -> unit) = closure24(v750, v758)
    let v828 : unit = (fun () -> v827 (); v826) ()
    let v889 : string = "$0.json()"
    let v890 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v155 v889 
    let v951 : unit = ()
    let v952 : (unit -> unit) = closure25(v890)
    let v953 : unit = (fun () -> v952 (); v951) ()
    let v1014 : string = "$0.borsh()"
    let v1015 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v155 v1014 
    let v1076 : unit = ()
    let v1077 : (unit -> unit) = closure26(v1015)
    let v1078 : unit = (fun () -> v1077 (); v1076) ()
    let v1139 : string = method15()
    let v1140 : Mut3 = {l0 = v1139} : Mut3
    let v1143 : string = "{ "
    let v1144 : string = $"{v1143}"
    let v1152 : unit = ()
    let v1153 : (unit -> unit) = closure8(v1140, v1144)
    let v1154 : unit = (fun () -> v1153 (); v1152) ()
    let v1162 : string = "receipt_outcomes_len"
    let v1163 : string = $"{v1162}"
    let v1171 : unit = ()
    let v1172 : (unit -> unit) = closure8(v1140, v1163)
    let v1173 : unit = (fun () -> v1172 (); v1171) ()
    let v1181 : string = " = "
    let v1182 : string = $"{v1181}"
    let v1190 : unit = ()
    let v1191 : (unit -> unit) = closure8(v1140, v1182)
    let v1192 : unit = (fun () -> v1191 (); v1190) ()
    let v1202 : string = $"{v758}"
    let v1210 : unit = ()
    let v1211 : (unit -> unit) = closure8(v1140, v1202)
    let v1212 : unit = (fun () -> v1211 (); v1210) ()
    let v1220 : string = "; "
    let v1221 : string = $"{v1220}"
    let v1229 : unit = ()
    let v1230 : (unit -> unit) = closure8(v1140, v1221)
    let v1231 : unit = (fun () -> v1230 (); v1229) ()
    let v1239 : string = "retry"
    let v1240 : string = $"{v1239}"
    let v1248 : unit = ()
    let v1249 : (unit -> unit) = closure8(v1140, v1240)
    let v1250 : unit = (fun () -> v1249 (); v1248) ()
    let v1257 : string = $"{v1181}"
    let v1265 : unit = ()
    let v1266 : (unit -> unit) = closure8(v1140, v1257)
    let v1267 : unit = (fun () -> v1266 (); v1265) ()
    let v1277 : string = $"{v1}"
    let v1285 : unit = ()
    let v1286 : (unit -> unit) = closure8(v1140, v1277)
    let v1287 : unit = (fun () -> v1286 (); v1285) ()
    let v1294 : string = $"{v1220}"
    let v1302 : unit = ()
    let v1303 : (unit -> unit) = closure8(v1140, v1294)
    let v1304 : unit = (fun () -> v1303 (); v1302) ()
    let v1312 : string = "receipt_failures"
    let v1313 : string = $"{v1312}"
    let v1321 : unit = ()
    let v1322 : (unit -> unit) = closure8(v1140, v1313)
    let v1323 : unit = (fun () -> v1322 (); v1321) ()
    let v1330 : string = $"{v1181}"
    let v1338 : unit = ()
    let v1339 : (unit -> unit) = closure8(v1140, v1330)
    let v1340 : unit = (fun () -> v1339 (); v1338) ()
    (* run_target_args'
    let v1350 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1351 : string = "format!(\"{:#?}\", $0)"
    let v1352 : std_string_String = Fable.Core.RustInterop.emitRustExpr v607 v1351 
    let v1353 : string = "fable_library_rust::String_::fromString($0)"
    let v1354 : string = Fable.Core.RustInterop.emitRustExpr v1352 v1353 
    let _run_target_args'_v1350 = v1354 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1355 : string = "format!(\"{:#?}\", $0)"
    let v1356 : std_string_String = Fable.Core.RustInterop.emitRustExpr v607 v1355 
    let v1357 : string = "fable_library_rust::String_::fromString($0)"
    let v1358 : string = Fable.Core.RustInterop.emitRustExpr v1356 v1357 
    let _run_target_args'_v1350 = v1358 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1359 : string = "format!(\"{:#?}\", $0)"
    let v1360 : std_string_String = Fable.Core.RustInterop.emitRustExpr v607 v1359 
    let v1361 : string = "fable_library_rust::String_::fromString($0)"
    let v1362 : string = Fable.Core.RustInterop.emitRustExpr v1360 v1361 
    let _run_target_args'_v1350 = v1362 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1364 : string = $"%A{v607}"
    let _run_target_args'_v1350 = v1364 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1368 : string = $"%A{v607}"
    let _run_target_args'_v1350 = v1368 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1372 : string = $"%A{v607}"
    let _run_target_args'_v1350 = v1372 
    #endif
#else
    let v1376 : string = $"%A{v607}"
    let _run_target_args'_v1350 = v1376 
    #endif
    let v1379 : string = _run_target_args'_v1350 
    let v1389 : string = $"{v1379}"
    let v1397 : unit = ()
    let v1398 : (unit -> unit) = closure8(v1140, v1389)
    let v1399 : unit = (fun () -> v1398 (); v1397) ()
    let v1407 : string = " }"
    let v1408 : string = $"{v1407}"
    let v1416 : unit = ()
    let v1417 : (unit -> unit) = closure8(v1140, v1408)
    let v1418 : unit = (fun () -> v1417 (); v1416) ()
    let v1424 : string = v1140.l0
    let v1425 : bool = v615 > 0
    let v1459 : Result<US7, anyhow_Error> =
        if v1425 then
            let v1428 : US7 = US7_0(v1424)
            let v1429 : Result<US7, anyhow_Error> = Ok v1428 
            v1429
        else
            let v1433 : bool = v758 > 1
            if v1433 then
                let v1436 : US7 = US7_1
                let v1437 : Result<US7, anyhow_Error> = Ok v1436 
                v1437
            else
                let v1441 : string = "anyhow::anyhow!($0)"
                let v1442 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v1424 v1441 
                (* run_target_args'
                let v1444 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1445 : string = "Err($0)"
                let v1446 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1442 v1445 
                let _run_target_args'_v1444 = v1446 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1447 : string = "Err($0)"
                let v1448 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1442 v1447 
                let _run_target_args'_v1444 = v1448 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1449 : string = "Err($0)"
                let v1450 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1442 v1449 
                let _run_target_args'_v1444 = v1450 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1451 : Result<US7, anyhow_Error> = v1442 |> Error
                let _run_target_args'_v1444 = v1451 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1452 : Result<US7, anyhow_Error> = v1442 |> Error
                let _run_target_args'_v1444 = v1452 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1453 : Result<US7, anyhow_Error> = v1442 |> Error
                let _run_target_args'_v1444 = v1453 
                #endif
#else
                let v1454 : Result<US7, anyhow_Error> = v1442 |> Error
                let _run_target_args'_v1444 = v1454 
                #endif
                let v1455 : Result<US7, anyhow_Error> = _run_target_args'_v1444 
                v1455
    let v1460 : string = ""
    let v1461 : string = "}"
    let v1462 : string = v1460 + v1461 
    let x = v1459 //
    let v1463 : _ = x
    let v1464 : unit = ()
    (* run_target_args'
    let v1465 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1466 : string = $"true; let _fix_closure_v1464 = $0"
    let v1467 : bool = Fable.Core.RustInterop.emitRustExpr v1463 v1466 
    let _run_target_args'_v1465 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1468 : string = $"true; let _fix_closure_v1464 = $0"
    let v1469 : bool = Fable.Core.RustInterop.emitRustExpr v1463 v1468 
    let _run_target_args'_v1465 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1470 : string = $"true; let _fix_closure_v1464 = $0"
    let v1471 : bool = Fable.Core.RustInterop.emitRustExpr v1463 v1470 
    let _run_target_args'_v1465 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v1465 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v1465 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v1465 = false 
    #endif
#else
    let _run_target_args'_v1465 = false 
    #endif
    let v1472 : bool = _run_target_args'_v1465 
    let v1473 : string = $"true; _fix_closure_v1464 " + v1462 + "); " + v1460 + " // rust.fix_closure'"
    let v1474 : bool = Fable.Core.RustInterop.emitRustExpr () v1473 
    let v1475 : string = "__future_init"
    let v1476 : _ = Fable.Core.RustInterop.emitRustExpr () v1475 
    let v1477 : string = "v1476"
    let v1478 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v1477 
    v1478
and closure27 () (v0 : anyhow_Error) : std_string_String =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = "format!(\"{}\", $0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v6 
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : string = "format!(\"{}\", $0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v8 
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : string = "format!(\"{}\", $0)"
    let v11 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v10 
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v13 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v5 = v13 
    #endif
#if FABLE_COMPILER_PYTHON
    let v17 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v5 = v17 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v21 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v5 = v21 
    #endif
#else
    let v25 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v5 = v25 
    #endif
    let v28 : std_string_String = _run_target_args'_v5 
    v28
and method40 () : (anyhow_Error -> std_string_String) =
    closure27()
and closure28 () (v0 : US7) : US9 =
    US9_0(v0)
and method41 () : (US7 -> US9) =
    closure28()
and closure29 () (v0 : std_string_String) : US9 =
    US9_1(v0)
and method42 () : (std_string_String -> US9) =
    closure29()
and method43 () : string =
    
    
    
    
    
    let v2 : string = "Warning"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method15()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v9, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v30 : string = v9.l0
    (* run_target_args'
    let v47 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v48 : string = "inline_colorization::color_yellow"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    (* run_target_args'
    let v54 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v55 : string = "&*$0"
    let v56 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v55 
    let _run_target_args'_v54 = v56 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v57 : string = "&*$0"
    let v58 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v57 
    let _run_target_args'_v54 = v58 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v59 : string = "&*$0"
    let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v59 
    let _run_target_args'_v54 = v60 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v62 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v62 
    #endif
#if FABLE_COMPILER_PYTHON
    let v66 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v66 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v70 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v70 
    #endif
#else
    let v74 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v74 
    #endif
    let v77 : Ref<Str> = _run_target_args'_v54 
    let v86 : string = "inline_colorization::color_reset"
    let v87 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v87) v88 
    let v90 : string = "fable_library_rust::String_::fromString($0)"
    let v91 : string = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let _run_target_args'_v47 = v91 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v92 : string = "inline_colorization::color_yellow"
    let v93 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v92 
    (* run_target_args'
    let v98 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v99 : string = "&*$0"
    let v100 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v99 
    let _run_target_args'_v98 = v100 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v101 : string = "&*$0"
    let v102 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v101 
    let _run_target_args'_v98 = v102 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v103 
    let _run_target_args'_v98 = v104 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v106 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v106 
    #endif
#if FABLE_COMPILER_PYTHON
    let v110 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v110 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v114 
    #endif
#else
    let v118 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v118 
    #endif
    let v121 : Ref<Str> = _run_target_args'_v98 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v93, v121, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v47 = v135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v136 : string = "inline_colorization::color_yellow"
    let v137 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v136 
    (* run_target_args'
    let v142 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v143 : string = "&*$0"
    let v144 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v143 
    let _run_target_args'_v142 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "&*$0"
    let v146 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v145 
    let _run_target_args'_v142 = v146 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v147 : string = "&*$0"
    let v148 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v147 
    let _run_target_args'_v142 = v148 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v150 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v150 
    #endif
#if FABLE_COMPILER_PYTHON
    let v154 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v154 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v158 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v158 
    #endif
#else
    let v162 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v162 
    #endif
    let v165 : Ref<Str> = _run_target_args'_v142 
    let v174 : string = "inline_colorization::color_reset"
    let v175 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v174 
    let v176 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v177 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v137, v165, v175) v176 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v177 v178 
    let _run_target_args'_v47 = v179 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v181 : string = "\u001b[93m"
    let v185 : string = method16()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[93m"
    let v201 : string = method16()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[93m"
    let v217 : string = method16()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[93m"
    let v233 : string = method16()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method44 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : std_string_String) : string =
    let v10 : string = method15()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure8(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "retry"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure8(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v73 : string = $"{v8}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure8(v11, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure8(v11, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "error"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure8(v11, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v52}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure8(v11, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    (* run_target_args'
    let v148 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v149 : string = "format!(\"{:#?}\", $0)"
    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v149 
    let v151 : string = "fable_library_rust::String_::fromString($0)"
    let v152 : string = Fable.Core.RustInterop.emitRustExpr v150 v151 
    let _run_target_args'_v148 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "format!(\"{:#?}\", $0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v153 
    let v155 : string = "fable_library_rust::String_::fromString($0)"
    let v156 : string = Fable.Core.RustInterop.emitRustExpr v154 v155 
    let _run_target_args'_v148 = v156 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v157 : string = "format!(\"{:#?}\", $0)"
    let v158 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v157 
    let v159 : string = "fable_library_rust::String_::fromString($0)"
    let v160 : string = Fable.Core.RustInterop.emitRustExpr v158 v159 
    let _run_target_args'_v148 = v160 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v162 : string = $"%A{v9}"
    let _run_target_args'_v148 = v162 
    #endif
#if FABLE_COMPILER_PYTHON
    let v166 : string = $"%A{v9}"
    let _run_target_args'_v148 = v166 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v170 : string = $"%A{v9}"
    let _run_target_args'_v148 = v170 
    #endif
#else
    let v174 : string = $"%A{v9}"
    let _run_target_args'_v148 = v174 
    #endif
    let v177 : string = _run_target_args'_v148 
    let v187 : string = $"{v177}"
    let v195 : unit = ()
    let v196 : (unit -> unit) = closure8(v11, v187)
    let v197 : unit = (fun () -> v196 (); v195) ()
    let v205 : string = " }"
    let v206 : string = $"{v205}"
    let v214 : unit = ()
    let v215 : (unit -> unit) = closure8(v11, v206)
    let v216 : unit = (fun () -> v215 (); v214) ()
    let v222 : string = v11.l0
    let v223 : int64 = v0.l0
    let v226 : string = " "
    let v227 : string = v6 + v226 
    let v231 : string = v227 + v7 
    let v236 : string = " #"
    let v237 : string = v231 + v236 
    let v241 : (int64 -> string) = _.ToString()
    let v242 : string = v241 v223
    let v246 : string = v237 + v242 
    let v250 : string = v246 + v226 
    let v255 : string = "spiral_wasm.run / Error error"
    let v256 : string = v250 + v255 
    let v261 : string = " / "
    let v262 : string = v256 + v261 
    let v266 : string = v262 + v222 
    method18(v266)
and closure30 (v0 : uint8, v1 : std_string_String) () : unit =
    let v2 : US3 = US3_3
    let v3 : bool = method9(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure6()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method10(v41, v42, v43, v44, v45, v46)
        let v60 : string = method43()
        let v61 : string = method44(v41, v42, v43, v44, v45, v46, v59, v60, v0, v1)
        method19(v61)
and method45 () : unit =
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure6()
    let v16 : unit = (fun () -> v15 (); v14) ()
    let struct (v37 : Mut0, v38 : Mut1, v39 : Mut2, v40 : Mut3, v41 : Mut4, v42 : int64 option) = TraceState.trace_state.Value
    let v57 : unit = ()
    let v58 : (unit -> unit) = closure9(v37)
    let v59 : unit = (fun () -> v58 (); v57) ()
    let v62 : string = "\n"
    let v63 : (string -> unit) = closure10()
    (* run_target_args'
    let v64 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v65 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v62 v65 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v66 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v62 v66 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v67 : string = v40.l0
    let v68 : bool = v67 = ""
    let v81 : string =
        if v68 then
            v62
        else
            let v69 : bool = v62 = ""
            if v69 then
                let v70 : string = v40.l0
                v70
            else
                let v71 : string = v40.l0
                let v73 : string = v71 + v62 
                let v77 : string = v73 + v62 
                v77
    (* run_target_args'
    let v86 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v87 : string = "&*$0"
    let v88 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v81 v87 
    let _run_target_args'_v86 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "&*$0"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v81 v89 
    let _run_target_args'_v86 = v90 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v91 : string = "&*$0"
    let v92 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v81 v91 
    let _run_target_args'_v86 = v92 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v94 : Ref<Str> = v81 |> unbox<Ref<Str>>
    let _run_target_args'_v86 = v94 
    #endif
#if FABLE_COMPILER_PYTHON
    let v98 : Ref<Str> = v81 |> unbox<Ref<Str>>
    let _run_target_args'_v86 = v98 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v102 : Ref<Str> = v81 |> unbox<Ref<Str>>
    let _run_target_args'_v86 = v102 
    #endif
#else
    let v106 : Ref<Str> = v81 |> unbox<Ref<Str>>
    let _run_target_args'_v86 = v106 
    #endif
    let v109 : Ref<Str> = _run_target_args'_v86 
    let v118 : string = $"$0.chars()"
    let v119 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v109 v118 
    let v120 : string = "$0"
    let v121 : _ = Fable.Core.RustInterop.emitRustExpr v119 v120 
    let v122 : string = "$0.collect::<Vec<_>>()"
    let v123 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v121 v122 
    let v124 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v125 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v123 v124 
    let v126 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v127 : bool = Fable.Core.RustInterop.emitRustExpr v125 v126 
    let v128 : string = "x"
    let v129 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v128 
    let v130 : string = "String::from_iter($0)"
    let v131 : std_string_String = Fable.Core.RustInterop.emitRustExpr v129 v130 
    let v132 : string = "true; $0 }).collect::<Vec<_>>()"
    let v133 : bool = Fable.Core.RustInterop.emitRustExpr v131 v132 
    let v134 : string = "_vec_map"
    let v135 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v134 
    let v136 : string = "$0.len()"
    let v137 : unativeint = Fable.Core.RustInterop.emitRustExpr v135 v136 
    let v143 : int32 = v137 |> int32 
    let v153 : string = ""
    let v154 : bool = v62 <> v153 
    let v158 : bool =
        if v154 then
            let v157 : bool = v143 <= 1
            v157
        else
            false
    if v158 then
        v40.l0 <- v81
        ()
    else
        v40.l0 <- v153
        let v159 : string = "true; $0.into_iter().for_each(|x| { //"
        let v160 : bool = Fable.Core.RustInterop.emitRustExpr v135 v159 
        let v161 : string = "x"
        let v162 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v161 
        let v163 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v164 : bool = Fable.Core.RustInterop.emitRustExpr v162 v163 
        let v165 : string = $"true"
        let v166 : bool = Fable.Core.RustInterop.emitRustExpr () v165 
        let v167 : string = "true; }); //"
        let v168 : bool = Fable.Core.RustInterop.emitRustExpr () v167 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v63 v62
    #endif
#if FABLE_COMPILER_PYTHON
    v63 v62
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v63 v62
    #endif
#else
    v63 v62
    #endif
    // run_target_args' is_unit
    let v169 : (string -> unit) = v38.l0
    v169 v62
and closure31 () () : unit =
    let v0 : US3 = US3_3
    let v1 : bool = method9(v0)
    if v1 then
        method45()
and closure32 (v0 : uint8, v1 : std_string_String) () : unit =
    let v2 : US3 = US3_3
    let v3 : bool = method9(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure6()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method10(v41, v42, v43, v44, v45, v46)
        let v60 : string = method43()
        let v61 : string = method44(v41, v42, v43, v44, v45, v46, v59, v60, v0, v1)
        method19(v61)
and closure33 () () : unit =
    let v0 : US3 = US3_3
    let v1 : bool = method9(v0)
    if v1 then
        method45()
and method46 () : string =
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method15()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v9, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v30 : string = v9.l0
    (* run_target_args'
    let v47 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v48 : string = "inline_colorization::color_bright_red"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    (* run_target_args'
    let v54 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v55 : string = "&*$0"
    let v56 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v55 
    let _run_target_args'_v54 = v56 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v57 : string = "&*$0"
    let v58 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v57 
    let _run_target_args'_v54 = v58 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v59 : string = "&*$0"
    let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v59 
    let _run_target_args'_v54 = v60 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v62 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v62 
    #endif
#if FABLE_COMPILER_PYTHON
    let v66 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v66 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v70 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v70 
    #endif
#else
    let v74 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v74 
    #endif
    let v77 : Ref<Str> = _run_target_args'_v54 
    let v86 : string = "inline_colorization::color_reset"
    let v87 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v87) v88 
    let v90 : string = "fable_library_rust::String_::fromString($0)"
    let v91 : string = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let _run_target_args'_v47 = v91 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v92 : string = "inline_colorization::color_bright_red"
    let v93 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v92 
    (* run_target_args'
    let v98 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v99 : string = "&*$0"
    let v100 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v99 
    let _run_target_args'_v98 = v100 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v101 : string = "&*$0"
    let v102 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v101 
    let _run_target_args'_v98 = v102 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v103 
    let _run_target_args'_v98 = v104 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v106 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v106 
    #endif
#if FABLE_COMPILER_PYTHON
    let v110 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v110 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v114 
    #endif
#else
    let v118 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v118 
    #endif
    let v121 : Ref<Str> = _run_target_args'_v98 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v93, v121, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v47 = v135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v136 : string = "inline_colorization::color_bright_red"
    let v137 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v136 
    (* run_target_args'
    let v142 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v143 : string = "&*$0"
    let v144 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v143 
    let _run_target_args'_v142 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "&*$0"
    let v146 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v145 
    let _run_target_args'_v142 = v146 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v147 : string = "&*$0"
    let v148 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v147 
    let _run_target_args'_v142 = v148 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v150 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v150 
    #endif
#if FABLE_COMPILER_PYTHON
    let v154 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v154 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v158 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v158 
    #endif
#else
    let v162 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v162 
    #endif
    let v165 : Ref<Str> = _run_target_args'_v142 
    let v174 : string = "inline_colorization::color_reset"
    let v175 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v174 
    let v176 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v177 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v137, v165, v175) v176 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v177 v178 
    let _run_target_args'_v47 = v179 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v181 : string = "\u001b[91m"
    let v185 : string = method16()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[91m"
    let v201 : string = method16()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[91m"
    let v217 : string = method16()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[91m"
    let v233 : string = method16()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method47 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : string) : string =
    let v10 : string = method15()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure8(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "retry"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure8(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v73 : string = $"{v8}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure8(v11, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure8(v11, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "error"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure8(v11, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v52}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure8(v11, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    let v145 : string = $"{v9}"
    let v153 : unit = ()
    let v154 : (unit -> unit) = closure8(v11, v145)
    let v155 : unit = (fun () -> v154 (); v153) ()
    let v163 : string = " }"
    let v164 : string = $"{v163}"
    let v172 : unit = ()
    let v173 : (unit -> unit) = closure8(v11, v164)
    let v174 : unit = (fun () -> v173 (); v172) ()
    let v180 : string = v11.l0
    let v181 : int64 = v0.l0
    let v184 : string = " "
    let v185 : string = v6 + v184 
    let v189 : string = v185 + v7 
    let v194 : string = " #"
    let v195 : string = v189 + v194 
    let v199 : (int64 -> string) = _.ToString()
    let v200 : string = v199 v181
    let v204 : string = v195 + v200 
    let v208 : string = v204 + v184 
    let v213 : string = "spiral_wasm.run / Ok (Some error)"
    let v214 : string = v208 + v213 
    let v219 : string = " / "
    let v220 : string = v214 + v219 
    let v224 : string = v220 + v180 
    method18(v224)
and closure34 (v0 : uint8, v1 : string) () : unit =
    let v2 : US3 = US3_4
    let v3 : bool = method9(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure6()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method10(v41, v42, v43, v44, v45, v46)
        let v60 : string = method46()
        let v61 : string = method47(v41, v42, v43, v44, v45, v46, v59, v60, v0, v1)
        method19(v61)
and method25 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> =
    let v2 : string = "true; let __future_init = Box::pin(/*"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let v4 : string = "*/ async move { /*"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let v6 : string = "*/ ()"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let v8 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = method26(v0, v1)
    let v9 : string = "v8.await"
    let v10 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr () v9 
    let v11 : (anyhow_Error -> std_string_String) = method40()
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
    let v27 : (US7 -> US9) = method41()
    let v28 : (std_string_String -> US9) = method42()
    let v30 : US9 = match v24 with Ok x -> v27 x | Error x -> v28 x
    let v518 : US8 =
        match v30 with
        | US9_1(v220) -> (* Error *)
            let v221 : bool = v1 >= 15uy
            if v221 then
                let v282 : unit = ()
                let v283 : (unit -> unit) = closure30(v1, v220)
                let v284 : unit = (fun () -> v283 (); v282) ()
                let v347 : unit = ()
                let v348 : (unit -> unit) = closure31()
                let v349 : unit = (fun () -> v348 (); v347) ()
                let v352 : string = "true; let __future_init = Box::pin(/*"
                let v353 : bool = Fable.Core.RustInterop.emitRustExpr () v352 
                let v354 : string = "*/ async move { /*"
                let v355 : bool = Fable.Core.RustInterop.emitRustExpr () v354 
                let v356 : string = "*/ ()"
                let v357 : bool = Fable.Core.RustInterop.emitRustExpr () v356 
                let v358 : string = ""
                let v359 : string = "}"
                let v360 : string = v358 + v359 
                let v361 : US7 = US7_1
                let x = struct (v1, v361) //
                let v362 : _ = x
                let v363 : unit = ()
                (* run_target_args'
                let v364 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v365 : string = $"true; let _fix_closure_v363 = $0"
                let v366 : bool = Fable.Core.RustInterop.emitRustExpr v362 v365 
                let _run_target_args'_v364 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v367 : string = $"true; let _fix_closure_v363 = $0"
                let v368 : bool = Fable.Core.RustInterop.emitRustExpr v362 v367 
                let _run_target_args'_v364 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v369 : string = $"true; let _fix_closure_v363 = $0"
                let v370 : bool = Fable.Core.RustInterop.emitRustExpr v362 v369 
                let _run_target_args'_v364 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v364 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v364 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v364 = false 
                #endif
#else
                let _run_target_args'_v364 = false 
                #endif
                let v371 : bool = _run_target_args'_v364 
                let v372 : string = $"true; _fix_closure_v363 " + v360 + "); " + v358 + " // rust.fix_closure'"
                let v373 : bool = Fable.Core.RustInterop.emitRustExpr () v372 
                let v374 : string = "__future_init"
                let v375 : _ = Fable.Core.RustInterop.emitRustExpr () v374 
                let v376 : string = "v375"
                let v377 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v376 
                let v378 : string = "v377.await"
                let struct (v379 : uint8, v380 : US7) = Fable.Core.RustInterop.emitRustExpr () v378 
                US8_0(v379, v380)
            else
                let v442 : unit = ()
                let v443 : (unit -> unit) = closure32(v1, v220)
                let v444 : unit = (fun () -> v443 (); v442) ()
                let v507 : unit = ()
                let v508 : (unit -> unit) = closure33()
                let v509 : unit = (fun () -> v508 (); v507) ()
                let v512 : uint8 = v1 + 1uy
                let v513 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = method25(v0, v512)
                let v514 : string = "v513.await"
                let v515 : US8 = Fable.Core.RustInterop.emitRustExpr () v514 
                v515
        | US9_0(v33) -> (* Ok *)
            match v33 with
            | US7_1 -> (* None *)
                let v34 : string = "true; let __future_init = Box::pin(/*"
                let v35 : bool = Fable.Core.RustInterop.emitRustExpr () v34 
                let v36 : string = "*/ async move { /*"
                let v37 : bool = Fable.Core.RustInterop.emitRustExpr () v36 
                let v38 : string = "*/ ()"
                let v39 : bool = Fable.Core.RustInterop.emitRustExpr () v38 
                let v40 : string = ""
                let v41 : string = "}"
                let v42 : string = v40 + v41 
                let v43 : US7 = US7_1
                let x = struct (v1, v43) //
                let v44 : _ = x
                let v45 : unit = ()
                (* run_target_args'
                let v46 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v47 : string = $"true; let _fix_closure_v45 = $0"
                let v48 : bool = Fable.Core.RustInterop.emitRustExpr v44 v47 
                let _run_target_args'_v46 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v49 : string = $"true; let _fix_closure_v45 = $0"
                let v50 : bool = Fable.Core.RustInterop.emitRustExpr v44 v49 
                let _run_target_args'_v46 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v51 : string = $"true; let _fix_closure_v45 = $0"
                let v52 : bool = Fable.Core.RustInterop.emitRustExpr v44 v51 
                let _run_target_args'_v46 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v46 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v46 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v46 = false 
                #endif
#else
                let _run_target_args'_v46 = false 
                #endif
                let v53 : bool = _run_target_args'_v46 
                let v54 : string = $"true; _fix_closure_v45 " + v42 + "); " + v40 + " // rust.fix_closure'"
                let v55 : bool = Fable.Core.RustInterop.emitRustExpr () v54 
                let v56 : string = "__future_init"
                let v57 : _ = Fable.Core.RustInterop.emitRustExpr () v56 
                let v58 : string = "v57"
                let v59 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v58 
                let v60 : string = "v59.await"
                let struct (v61 : uint8, v62 : US7) = Fable.Core.RustInterop.emitRustExpr () v60 
                US8_0(v61, v62)
            | US7_0(v64) -> (* Some *)
                let v125 : unit = ()
                let v126 : (unit -> unit) = closure34(v1, v64)
                let v127 : unit = (fun () -> v126 (); v125) ()
                let v188 : string = "true; let __future_init = Box::pin(/*"
                let v189 : bool = Fable.Core.RustInterop.emitRustExpr () v188 
                let v190 : string = "*/ async move { /*"
                let v191 : bool = Fable.Core.RustInterop.emitRustExpr () v190 
                let v192 : string = "*/ ()"
                let v193 : bool = Fable.Core.RustInterop.emitRustExpr () v192 
                let v194 : string = ""
                let v195 : string = "}"
                let v196 : string = v194 + v195 
                let v197 : US7 = US7_0(v64)
                let x = struct (v1, v197) //
                let v198 : _ = x
                let v199 : unit = ()
                (* run_target_args'
                let v200 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v201 : string = $"true; let _fix_closure_v199 = $0"
                let v202 : bool = Fable.Core.RustInterop.emitRustExpr v198 v201 
                let _run_target_args'_v200 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v203 : string = $"true; let _fix_closure_v199 = $0"
                let v204 : bool = Fable.Core.RustInterop.emitRustExpr v198 v203 
                let _run_target_args'_v200 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v205 : string = $"true; let _fix_closure_v199 = $0"
                let v206 : bool = Fable.Core.RustInterop.emitRustExpr v198 v205 
                let _run_target_args'_v200 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v200 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v200 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v200 = false 
                #endif
#else
                let _run_target_args'_v200 = false 
                #endif
                let v207 : bool = _run_target_args'_v200 
                let v208 : string = $"true; _fix_closure_v199 " + v196 + "); " + v194 + " // rust.fix_closure'"
                let v209 : bool = Fable.Core.RustInterop.emitRustExpr () v208 
                let v210 : string = "__future_init"
                let v211 : _ = Fable.Core.RustInterop.emitRustExpr () v210 
                let v212 : string = "v211"
                let v213 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v212 
                let v214 : string = "v213.await"
                let struct (v215 : uint8, v216 : US7) = Fable.Core.RustInterop.emitRustExpr () v214 
                US8_1(v215, v216)
    let v519 : string = ""
    let v520 : string = "}"
    let v521 : string = v519 + v520 
    let x = v518 //
    let v522 : _ = x
    let v523 : unit = ()
    (* run_target_args'
    let v524 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v525 : string = $"true; let _fix_closure_v523 = $0"
    let v526 : bool = Fable.Core.RustInterop.emitRustExpr v522 v525 
    let _run_target_args'_v524 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v527 : string = $"true; let _fix_closure_v523 = $0"
    let v528 : bool = Fable.Core.RustInterop.emitRustExpr v522 v527 
    let _run_target_args'_v524 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v529 : string = $"true; let _fix_closure_v523 = $0"
    let v530 : bool = Fable.Core.RustInterop.emitRustExpr v522 v529 
    let _run_target_args'_v524 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v524 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v524 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v524 = false 
    #endif
#else
    let _run_target_args'_v524 = false 
    #endif
    let v531 : bool = _run_target_args'_v524 
    let v532 : string = $"true; _fix_closure_v523 " + v521 + "); " + v519 + " // rust.fix_closure'"
    let v533 : bool = Fable.Core.RustInterop.emitRustExpr () v532 
    let v534 : string = "__future_init"
    let v535 : _ = Fable.Core.RustInterop.emitRustExpr () v534 
    let v536 : string = "v535"
    let v537 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = Fable.Core.RustInterop.emitRustExpr () v536 
    v537
and method48 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : US8) : string =
    let v9 : string = method15()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "retries"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure8(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v69 : string = $"%A{v8}"
    let v73 : string = $"{v69}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure8(v10, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = " }"
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure8(v10, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v108 : string = v10.l0
    let v109 : int64 = v0.l0
    let v112 : string = " "
    let v113 : string = v6 + v112 
    let v117 : string = v113 + v7 
    let v122 : string = " #"
    let v123 : string = v117 + v122 
    let v127 : (int64 -> string) = _.ToString()
    let v128 : string = v127 v109
    let v132 : string = v123 + v128 
    let v136 : string = v132 + v112 
    let v141 : string = "spiral_wasm.run"
    let v142 : string = v136 + v141 
    let v147 : string = " / "
    let v148 : string = v142 + v147 
    let v152 : string = v148 + v108 
    method18(v152)
and closure35 (v0 : US8) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure6()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method10(v40, v41, v42, v43, v44, v45)
        let v59 : string = method14()
        let v60 : string = method48(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method19(v60)
and method22 (v0 : clap_ArgMatches) : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> =
    let v1 : string = "true; let __future_init = Box::pin(/*"
    let v2 : bool = Fable.Core.RustInterop.emitRustExpr () v1 
    let v3 : string = "*/ async move { /*"
    let v4 : bool = Fable.Core.RustInterop.emitRustExpr () v3 
    let v5 : string = "*/ ()"
    let v6 : bool = Fable.Core.RustInterop.emitRustExpr () v5 
    let v7 : string = method23()
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v13 
    let _run_target_args'_v12 = v14 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v15 : string = "&*$0"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v15 
    let _run_target_args'_v12 = v16 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v17 : string = "&*$0"
    let v18 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v17 
    let _run_target_args'_v12 = v18 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v12 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v24 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v12 = v24 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v28 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v12 = v28 
    #endif
#else
    let v32 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v12 = v32 
    #endif
    let v35 : Ref<Str> = _run_target_args'_v12 
    let v44 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v45 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v0, v35) v44 
    let v48 : (std_string_String -> US0) = method2()
    let v49 : US0 option = v45 |> Option.map v48 
    let v69 : US0 = US0_1
    let v70 : US0 = v49 |> Option.defaultValue v69 
    let v77 : std_string_String =
        match v70 with
        | US0_1 -> (* None *)
            failwith<std_string_String> "Option does not have a value."
        | US0_0(v74) -> (* Some *)
            v74
    let v78 : string = "fable_library_rust::String_::fromString($0)"
    let v79 : string = Fable.Core.RustInterop.emitRustExpr v77 v78 
    let v140 : unit = ()
    let v141 : (unit -> unit) = closure13(v79)
    let v142 : unit = (fun () -> v141 (); v140) ()
    let v203 : string = "std::fs::read(&*$0)"
    let v204 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v79 v203 
    let v205 : string = "$0?"
    let v206 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v204 v205 
    let v207 : uint8 = 1uy
    let v208 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = method25(v206, v207)
    let v209 : string = "v208.await"
    let v210 : US8 = Fable.Core.RustInterop.emitRustExpr () v209 
    let v271 : unit = ()
    let v272 : (unit -> unit) = closure35(v210)
    let v273 : unit = (fun () -> v272 (); v271) ()
    let v536 : Result<uint8, anyhow_Error> =
        match v210 with
        | US8_1(v340, v341) -> (* Error *)
            let v342 : string = method15()
            let v343 : Mut3 = {l0 = v342} : Mut3
            let v346 : string = "{ "
            let v347 : string = $"{v346}"
            let v355 : unit = ()
            let v356 : (unit -> unit) = closure8(v343, v347)
            let v357 : unit = (fun () -> v356 (); v355) ()
            let v365 : string = "retries"
            let v366 : string = $"{v365}"
            let v374 : unit = ()
            let v375 : (unit -> unit) = closure8(v343, v366)
            let v376 : unit = (fun () -> v375 (); v374) ()
            let v384 : string = " = "
            let v385 : string = $"{v384}"
            let v393 : unit = ()
            let v394 : (unit -> unit) = closure8(v343, v385)
            let v395 : unit = (fun () -> v394 (); v393) ()
            let v402 : string = $"%A{v210}"
            let v406 : string = $"{v402}"
            let v414 : unit = ()
            let v415 : (unit -> unit) = closure8(v343, v406)
            let v416 : unit = (fun () -> v415 (); v414) ()
            let v424 : string = "; "
            let v425 : string = $"{v424}"
            let v433 : unit = ()
            let v434 : (unit -> unit) = closure8(v343, v425)
            let v435 : unit = (fun () -> v434 (); v433) ()
            let v443 : string = "error"
            let v444 : string = $"{v443}"
            let v452 : unit = ()
            let v453 : (unit -> unit) = closure8(v343, v444)
            let v454 : unit = (fun () -> v453 (); v452) ()
            let v461 : string = $"{v384}"
            let v469 : unit = ()
            let v470 : (unit -> unit) = closure8(v343, v461)
            let v471 : unit = (fun () -> v470 (); v469) ()
            let v478 : string = $"%A{v341}"
            let v482 : string = $"{v478}"
            let v490 : unit = ()
            let v491 : (unit -> unit) = closure8(v343, v482)
            let v492 : unit = (fun () -> v491 (); v490) ()
            let v500 : string = " }"
            let v501 : string = $"{v500}"
            let v509 : unit = ()
            let v510 : (unit -> unit) = closure8(v343, v501)
            let v511 : unit = (fun () -> v510 (); v509) ()
            let v517 : string = v343.l0
            let v518 : string = "anyhow::anyhow!($0)"
            let v519 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v517 v518 
            (* run_target_args'
            let v521 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v522 : string = "Err($0)"
            let v523 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v519 v522 
            let _run_target_args'_v521 = v523 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v524 : string = "Err($0)"
            let v525 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v519 v524 
            let _run_target_args'_v521 = v525 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v526 : string = "Err($0)"
            let v527 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v519 v526 
            let _run_target_args'_v521 = v527 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v528 : Result<uint8, anyhow_Error> = v519 |> Error
            let _run_target_args'_v521 = v528 
            #endif
#if FABLE_COMPILER_PYTHON
            let v529 : Result<uint8, anyhow_Error> = v519 |> Error
            let _run_target_args'_v521 = v529 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v530 : Result<uint8, anyhow_Error> = v519 |> Error
            let _run_target_args'_v521 = v530 
            #endif
#else
            let v531 : Result<uint8, anyhow_Error> = v519 |> Error
            let _run_target_args'_v521 = v531 
            #endif
            let v532 : Result<uint8, anyhow_Error> = _run_target_args'_v521 
            v532
        | US8_0(v334, v335) -> (* Ok *)
            let v337 : Result<uint8, anyhow_Error> = Ok v334 
            v337
    let v537 : string = ""
    let v538 : string = "}"
    let v539 : string = v537 + v538 
    let x = v536 //
    let v540 : _ = x
    let v541 : unit = ()
    (* run_target_args'
    let v542 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v543 : string = $"true; let _fix_closure_v541 = $0"
    let v544 : bool = Fable.Core.RustInterop.emitRustExpr v540 v543 
    let _run_target_args'_v542 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v545 : string = $"true; let _fix_closure_v541 = $0"
    let v546 : bool = Fable.Core.RustInterop.emitRustExpr v540 v545 
    let _run_target_args'_v542 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v547 : string = $"true; let _fix_closure_v541 = $0"
    let v548 : bool = Fable.Core.RustInterop.emitRustExpr v540 v547 
    let _run_target_args'_v542 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v542 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v542 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v542 = false 
    #endif
#else
    let _run_target_args'_v542 = false 
    #endif
    let v549 : bool = _run_target_args'_v542 
    let v550 : string = $"true; _fix_closure_v541 " + v539 + "); " + v537 + " // rust.fix_closure'"
    let v551 : bool = Fable.Core.RustInterop.emitRustExpr () v550 
    let v552 : string = "__future_init"
    let v553 : _ = Fable.Core.RustInterop.emitRustExpr () v552 
    let v554 : string = "v553"
    let v555 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v554 
    v555
and closure36 () (v0 : uint8) : US10 =
    US10_0(v0)
and method49 () : (uint8 -> US10) =
    closure36()
and closure37 () (v0 : std_string_String) : US10 =
    US10_1(v0)
and method50 () : (std_string_String -> US10) =
    closure37()
and closure0 () (v0 : (string [])) : int32 =
    let v1 : clap_Command = method0()
    let v2 : string = "clap::Command::get_matches($0)"
    let v3 : clap_ArgMatches = Fable.Core.RustInterop.emitRustExpr v1 v2 
    let v4 : string = method1()
    (* run_target_args'
    let v9 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v10 : string = "&*$0"
    let v11 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v10 
    let _run_target_args'_v9 = v11 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : string = "&*$0"
    let v13 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v12 
    let _run_target_args'_v9 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v14 : string = "&*$0"
    let v15 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v4 v14 
    let _run_target_args'_v9 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v17 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v9 = v17 
    #endif
#if FABLE_COMPILER_PYTHON
    let v21 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v9 = v21 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v25 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v9 = v25 
    #endif
#else
    let v29 : Ref<Str> = v4 |> unbox<Ref<Str>>
    let _run_target_args'_v9 = v29 
    #endif
    let v32 : Ref<Str> = _run_target_args'_v9 
    let v41 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v42 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v32) v41 
    let v45 : (std_string_String -> US0) = method2()
    let v46 : US0 option = v42 |> Option.map v45 
    let v66 : US0 = US0_1
    let v67 : US0 = v46 |> Option.defaultValue v66 
    let v203 : US1 =
        match v67 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v71) -> (* Some *)
            let v72 : string = "fable_library_rust::String_::fromString($0)"
            let v73 : string = Fable.Core.RustInterop.emitRustExpr v71 v72 
            
            
            
            
            
            
            
            
            
            
            let v76 : string = "Critical"
            let v77 : (unit -> string) = v76.ToLower
            let v78 : string = v77 ()
            let v83 : string = "Warning"
            let v84 : (unit -> string) = v83.ToLower
            let v85 : string = v84 ()
            let v90 : string = "Info"
            let v91 : (unit -> string) = v90.ToLower
            let v92 : string = v91 ()
            let v97 : string = "Debug"
            let v98 : (unit -> string) = v97.ToLower
            let v99 : string = v98 ()
            let v104 : string = "Verbose"
            let v105 : (unit -> string) = v104.ToLower
            let v106 : string = v105 ()
            let v109 : bool = "Verbose" = v73
            let v113 : US2 =
                if v109 then
                    let v110 : US3 = US3_0
                    US2_0(v110)
                else
                    US2_1
            let v199 : US2 =
                match v113 with
                | US2_1 -> (* None *)
                    let v116 : bool = "Debug" = v73
                    let v120 : US2 =
                        if v116 then
                            let v117 : US3 = US3_1
                            US2_0(v117)
                        else
                            US2_1
                    match v120 with
                    | US2_1 -> (* None *)
                        let v123 : bool = "Info" = v73
                        let v127 : US2 =
                            if v123 then
                                let v124 : US3 = US3_2
                                US2_0(v124)
                            else
                                US2_1
                        match v127 with
                        | US2_1 -> (* None *)
                            let v130 : bool = "Warning" = v73
                            let v134 : US2 =
                                if v130 then
                                    let v131 : US3 = US3_3
                                    US2_0(v131)
                                else
                                    US2_1
                            match v134 with
                            | US2_1 -> (* None *)
                                let v137 : bool = "Critical" = v73
                                let v141 : US2 =
                                    if v137 then
                                        let v138 : US3 = US3_4
                                        US2_0(v138)
                                    else
                                        US2_1
                                match v141 with
                                | US2_1 -> (* None *)
                                    let v144 : bool = v106 = v73
                                    let v148 : US2 =
                                        if v144 then
                                            let v145 : US3 = US3_0
                                            US2_0(v145)
                                        else
                                            US2_1
                                    match v148 with
                                    | US2_1 -> (* None *)
                                        let v151 : bool = v99 = v73
                                        let v155 : US2 =
                                            if v151 then
                                                let v152 : US3 = US3_1
                                                US2_0(v152)
                                            else
                                                US2_1
                                        match v155 with
                                        | US2_1 -> (* None *)
                                            let v158 : bool = v92 = v73
                                            let v162 : US2 =
                                                if v158 then
                                                    let v159 : US3 = US3_2
                                                    US2_0(v159)
                                                else
                                                    US2_1
                                            match v162 with
                                            | US2_1 -> (* None *)
                                                let v165 : bool = v85 = v73
                                                let v169 : US2 =
                                                    if v165 then
                                                        let v166 : US3 = US3_3
                                                        US2_0(v166)
                                                    else
                                                        US2_1
                                                match v169 with
                                                | US2_1 -> (* None *)
                                                    let v172 : bool = v78 = v73
                                                    let v176 : US2 =
                                                        if v172 then
                                                            let v173 : US3 = US3_4
                                                            US2_0(v173)
                                                        else
                                                            US2_1
                                                    match v176 with
                                                    | US2_1 -> (* None *)
                                                        US2_1
                                                    | US2_0(v177) -> (* Some *)
                                                        US2_0(v177)
                                                | US2_0(v170) -> (* Some *)
                                                    US2_0(v170)
                                            | US2_0(v163) -> (* Some *)
                                                US2_0(v163)
                                        | US2_0(v156) -> (* Some *)
                                            US2_0(v156)
                                    | US2_0(v149) -> (* Some *)
                                        US2_0(v149)
                                | US2_0(v142) -> (* Some *)
                                    US2_0(v142)
                            | US2_0(v135) -> (* Some *)
                                US2_0(v135)
                        | US2_0(v128) -> (* Some *)
                            US2_0(v128)
                    | US2_0(v121) -> (* Some *)
                        US2_0(v121)
                | US2_0(v114) -> (* Some *)
                    US2_0(v114)
            US1_0(v199)
    let v210 : US2 =
        match v203 with
        | US1_0(v204) -> (* Some *)
            match v204 with
            | US2_0(v205) -> (* Some *)
                US2_0(v205)
            | _ ->
                US2_1
        | _ ->
            US2_1
    let v214 : US3 =
        match v210 with
        | US2_1 -> (* None *)
            US3_0
        | US2_0(v211) -> (* Some *)
            v211
    let v227 : unit = ()
    let v228 : (unit -> unit) = closure2(v214)
    let v229 : unit = (fun () -> v228 (); v227) ()
    let struct (v248 : Mut0, v249 : Mut1, v250 : Mut2, v251 : Mut3, v252 : Mut4, v253 : int64 option) = TraceState.trace_state.Value
    let v326 : unit = ()
    let v327 : (unit -> unit) = closure5(v0)
    let v328 : unit = (fun () -> v327 (); v326) ()
    let v389 : string = method20()
    (* run_target_args'
    let v394 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v395 : string = "&*$0"
    let v396 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v389 v395 
    let _run_target_args'_v394 = v396 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v397 : string = "&*$0"
    let v398 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v389 v397 
    let _run_target_args'_v394 = v398 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v399 : string = "&*$0"
    let v400 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v389 v399 
    let _run_target_args'_v394 = v400 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v402 : Ref<Str> = v389 |> unbox<Ref<Str>>
    let _run_target_args'_v394 = v402 
    #endif
#if FABLE_COMPILER_PYTHON
    let v406 : Ref<Str> = v389 |> unbox<Ref<Str>>
    let _run_target_args'_v394 = v406 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v410 : Ref<Str> = v389 |> unbox<Ref<Str>>
    let _run_target_args'_v394 = v410 
    #endif
#else
    let v414 : Ref<Str> = v389 |> unbox<Ref<Str>>
    let _run_target_args'_v394 = v414 
    #endif
    let v417 : Ref<Str> = _run_target_args'_v394 
    let v426 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v427 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v417) v426 
    let v430 : (std_string_String -> string) = method21()
    let v431 : string option = v427 |> Option.map v430 
    let v538 : (string -> US7) = method8()
    let v539 : US7 option = v431 |> Option.map v538 
    let v559 : US7 = US7_1
    let v560 : US7 = v539 |> Option.defaultValue v559 
    let v564 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method22(v3)
    let v565 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v566 : _ = Fable.Core.RustInterop.emitRustExpr () v565 
    let v567 : string = "v566.handle().block_on($0)"
    let v568 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v564 v567 
    let v569 : (anyhow_Error -> std_string_String) = method40()
    (* run_target_args'
    let v571 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v572 : string = "$0.map_err(|x| $1(x))"
    let v573 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v568, v569) v572 
    let _run_target_args'_v571 = v573 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v574 : string = "$0.map_err(|x| $1(x))"
    let v575 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v568, v569) v574 
    let _run_target_args'_v571 = v575 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v576 : string = "$0.map_err(|x| $1(x))"
    let v577 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v568, v569) v576 
    let _run_target_args'_v571 = v577 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v578 : Result<uint8, std_string_String> = match v568 with Ok x -> Ok x | Error x -> Error (v569 x)
    let _run_target_args'_v571 = v578 
    #endif
#if FABLE_COMPILER_PYTHON
    let v579 : Result<uint8, std_string_String> = match v568 with Ok x -> Ok x | Error x -> Error (v569 x)
    let _run_target_args'_v571 = v579 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v580 : Result<uint8, std_string_String> = match v568 with Ok x -> Ok x | Error x -> Error (v569 x)
    let _run_target_args'_v571 = v580 
    #endif
#else
    let v581 : Result<uint8, std_string_String> = match v568 with Ok x -> Ok x | Error x -> Error (v569 x)
    let _run_target_args'_v571 = v581 
    #endif
    let v582 : Result<uint8, std_string_String> = _run_target_args'_v571 
    let v585 : (uint8 -> US10) = method49()
    let v586 : (std_string_String -> US10) = method50()
    let v588 : US10 = match v582 with Ok x -> v585 x | Error x -> v586 x
    match v588 with
    | US10_1(v613) -> (* Error *)
        match v560 with
        | US7_0(v614) -> (* Some *)
            let v615 : bool = "" = v614
            if v615 then
                ()
            else
                let v616 : string = "fable_library_rust::String_::fromString($0)"
                let v617 : string = Fable.Core.RustInterop.emitRustExpr v613 v616 
                let v619 : bool = v617.Contains v614 
                if v619 then
                    ()
                else
                    let v622 : string = $"spiral_wasm.main / exception: '{v614}' / error: {v613}"
                    (* run_target_args'
                    let v624 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v625 : string = "Err($0)"
                    let v626 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v622 v625 
                    let _run_target_args'_v624 = v626 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v627 : string = "Err($0)"
                    let v628 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v622 v627 
                    let _run_target_args'_v624 = v628 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v629 : string = "Err($0)"
                    let v630 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v622 v629 
                    let _run_target_args'_v624 = v630 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v631 : Result<unit, string> = v622 |> Error
                    let _run_target_args'_v624 = v631 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v632 : Result<unit, string> = v622 |> Error
                    let _run_target_args'_v624 = v632 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v633 : Result<unit, string> = v622 |> Error
                    let _run_target_args'_v624 = v633 
                    #endif
#else
                    let v634 : Result<unit, string> = v622 |> Error
                    let _run_target_args'_v624 = v634 
                    #endif
                    let v635 : Result<unit, string> = _run_target_args'_v624 
                    (* run_target_args'
                    let v638 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v639 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v635 v639 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v640 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v635 v640 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v641 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v635 v641 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    match v635 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if FABLE_COMPILER_PYTHON
                    match v635 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    match v635 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#else
                    match v635 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
                    // run_target_args' is_unit
                    ()
        | _ ->
            (* run_target_args'
            let v643 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v644 : string = "$0.unwrap()"
            let v645 : uint8 = Fable.Core.RustInterop.emitRustExpr v582 v644 
            let _run_target_args'_v643 = v645 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v646 : string = "$0.unwrap()"
            let v647 : uint8 = Fable.Core.RustInterop.emitRustExpr v582 v646 
            let _run_target_args'_v643 = v647 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v648 : string = "$0.unwrap()"
            let v649 : uint8 = Fable.Core.RustInterop.emitRustExpr v582 v648 
            let _run_target_args'_v643 = v649 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v650 : uint8 = match v582 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v643 = v650 
            #endif
#if FABLE_COMPILER_PYTHON
            let v651 : uint8 = match v582 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v643 = v651 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v652 : uint8 = match v582 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v643 = v652 
            #endif
#else
            let v653 : uint8 = match v582 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v643 = v653 
            #endif
            let v654 : uint8 = _run_target_args'_v643 
            ()
    | US10_0(v591) -> (* Ok *)
        match v560 with
        | US7_0(v592) -> (* Some *)
            let v593 : string = $"spiral_wasm.main / retries: {v591} / exception: '{v592}'"
            (* run_target_args'
            let v595 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v596 : string = "Err($0)"
            let v597 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v593 v596 
            let _run_target_args'_v595 = v597 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v598 : string = "Err($0)"
            let v599 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v593 v598 
            let _run_target_args'_v595 = v599 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v600 : string = "Err($0)"
            let v601 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v593 v600 
            let _run_target_args'_v595 = v601 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v602 : Result<unit, string> = v593 |> Error
            let _run_target_args'_v595 = v602 
            #endif
#if FABLE_COMPILER_PYTHON
            let v603 : Result<unit, string> = v593 |> Error
            let _run_target_args'_v595 = v603 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v604 : Result<unit, string> = v593 |> Error
            let _run_target_args'_v595 = v604 
            #endif
#else
            let v605 : Result<unit, string> = v593 |> Error
            let _run_target_args'_v595 = v605 
            #endif
            let v606 : Result<unit, string> = _run_target_args'_v595 
            (* run_target_args'
            let v609 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v610 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v606 v610 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v611 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v606 v611 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v612 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v606 v612 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            match v606 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if FABLE_COMPILER_PYTHON
            match v606 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            match v606 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#else
            match v606 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
            // run_target_args' is_unit
            ()
        | _ ->
            ()
    0
let v0 : ((string []) -> int32) = closure0()
let main args = v0 args
()
