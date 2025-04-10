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
    | US9_0 of f0_0 : uint8 * f0_1 : US7
    | US9_1 of f1_0 : uint8 * f1_1 : US7
and [<Struct>] US10 =
    | US10_0 of f0_0 : US7
    | US10_1 of f1_0 : std_string_String
and [<Struct>] US11 =
    | US11_0 of f0_0 : uint8
    | US11_1 of f1_0 : std_string_String
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
    let v195 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v198 : (int64 -> US4) = method10()
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
    let v361 : string = method11()
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
    let v384 : (int64 -> US4) = method10()
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
    let v547 : string = method11()
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
    let v572 : (int64 -> US4) = method10()
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
    let v619 : (int64 -> US4) = method10()
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
    let v782 : string = method12()
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
    let v805 : (int64 -> US4) = method10()
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
    let v968 : string = method12()
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
    let v991 : (int64 -> US4) = method10()
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
    let v1154 : string = method12()
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
    let v1177 : (int64 -> US4) = method10()
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
    let v1340 : string = method12()
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
and method14 (v0 : char) : string =
    let v1 : string = method15()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v7 : string = $"{v0}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure8(v2, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v23 : string = v2.l0
    v23
and method16 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method13 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method14(v7)
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v26 : string = "inline_colorization::color_bright_black"
    let v27 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v26 
    (* run_target_args'
    let v32 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v33 : string = "&*$0"
    let v34 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v33 
    let _run_target_args'_v32 = v34 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v35 : string = "&*$0"
    let v36 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v35 
    let _run_target_args'_v32 = v36 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v37 : string = "&*$0"
    let v38 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v37 
    let _run_target_args'_v32 = v38 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v40 
    #endif
#if FABLE_COMPILER_PYTHON
    let v44 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v44 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v48 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v48 
    #endif
#else
    let v52 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v52 
    #endif
    let v55 : Ref<Str> = _run_target_args'_v32 
    let v64 : string = "inline_colorization::color_reset"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v64 
    let v66 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v67 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v27, v55, v65) v66 
    let v68 : string = "fable_library_rust::String_::fromString($0)"
    let v69 : string = Fable.Core.RustInterop.emitRustExpr v67 v68 
    let _run_target_args'_v25 = v69 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v70 : string = "inline_colorization::color_bright_black"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v70 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "&*$0"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : Ref<Str> = _run_target_args'_v76 
    let v108 : string = "inline_colorization::color_reset"
    let v109 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v108 
    let v110 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v111 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v71, v99, v109) v110 
    let v112 : string = "fable_library_rust::String_::fromString($0)"
    let v113 : string = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let _run_target_args'_v25 = v113 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v114 : string = "inline_colorization::color_bright_black"
    let v115 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v114 
    (* run_target_args'
    let v120 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v121 : string = "&*$0"
    let v122 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v121 
    let _run_target_args'_v120 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "&*$0"
    let v124 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v123 
    let _run_target_args'_v120 = v124 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v125 : string = "&*$0"
    let v126 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v125 
    let _run_target_args'_v120 = v126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v128 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v128 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v136 
    #endif
#else
    let v140 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v140 
    #endif
    let v143 : Ref<Str> = _run_target_args'_v120 
    let v152 : string = "inline_colorization::color_reset"
    let v153 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v152 
    let v154 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v115, v143, v153) v154 
    let v156 : string = "fable_library_rust::String_::fromString($0)"
    let v157 : string = Fable.Core.RustInterop.emitRustExpr v155 v156 
    let _run_target_args'_v25 = v157 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v159 : string = "\u001b[90m"
    let v163 : string = method16()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[90m"
    let v179 : string = method16()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[90m"
    let v195 : string = method16()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[90m"
    let v211 : string = method16()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method18 (v0 : (string [])) : string =
    let v1 : string = method15()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure8(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "args"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure8(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v61 : string = $"%A{v0}"
    let v65 : string = $"{v61}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v2, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = " }"
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure8(v2, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v100 : string = v2.l0
    v100
and method19 (v0 : string) : string =
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
    let v9 : string = method18(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v28 : (int64 -> string) = _.ToString()
    let v29 : string = v28 v10
    let v33 : string = v24 + v29 
    let v37 : string = v33 + v13 
    let v42 : string = "spiral_wasm.main"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method19(v53)
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
and closure5 (v0 : (string [])) () : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
    let v58 : US3 = v44.l0
    let v59 : bool = v42.l0
    let v60 : bool = v59 = false
    let v63 : bool =
        if v60 then
            false
        else
            let v61 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v58
            let v62 : bool = 0 >= v61
            v62
    let v64 : bool = v63 = false
    let v298 : US8 =
        if v64 then
            US8_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method9(v104, v105, v106, v107, v108, v109)
            let v123 : string = method13()
            let v124 : string = method17(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v139 : unit = ()
            let v140 : unit = (fun () -> v16 (); v139) ()
            let struct (v163 : Mut0, v164 : Mut1, v165 : Mut2, v166 : Mut3, v167 : Mut4, v168 : int64 option) = TraceState.trace_state.Value
            let v183 : unit = ()
            let v184 : (unit -> unit) = closure9(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure10()
            (* run_target_args'
            let v189 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v190 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v190 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v191 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v192 : string = v166.l0
            let v193 : bool = v192 = ""
            let v208 : string =
                if v193 then
                    v124
                else
                    let v194 : bool = v124 = ""
                    if v194 then
                        let v195 : string = v166.l0
                        v195
                    else
                        let v196 : string = v166.l0
                        let v199 : string = "\n"
                        let v200 : string = v196 + v199 
                        let v204 : string = v200 + v124 
                        v204
            (* run_target_args'
            let v213 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v214 : string = "&*$0"
            let v215 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v214 
            let _run_target_args'_v213 = v215 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v216 : string = "&*$0"
            let v217 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v216 
            let _run_target_args'_v213 = v217 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v218 
            let _run_target_args'_v213 = v219 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v221 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v221 
            #endif
#if FABLE_COMPILER_PYTHON
            let v225 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v225 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v229 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v229 
            #endif
#else
            let v233 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v233 
            #endif
            let v236 : Ref<Str> = _run_target_args'_v213 
            let v245 : string = $"$0.chars()"
            let v246 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v236 v245 
            let v247 : string = "$0"
            let v248 : _ = Fable.Core.RustInterop.emitRustExpr v246 v247 
            let v249 : string = "$0.collect::<Vec<_>>()"
            let v250 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v248 v249 
            let v251 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v252 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v254 : bool = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "x"
            let v256 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v255 
            let v257 : string = "String::from_iter($0)"
            let v258 : std_string_String = Fable.Core.RustInterop.emitRustExpr v256 v257 
            let v259 : string = "true; $0 }).collect::<Vec<_>>()"
            let v260 : bool = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "_vec_map"
            let v262 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v261 
            let v263 : string = "$0.len()"
            let v264 : unativeint = Fable.Core.RustInterop.emitRustExpr v262 v263 
            let v270 : int32 = v264 |> int32 
            let v280 : string = ""
            let v281 : bool = v124 <> v280 
            let v285 : bool =
                if v281 then
                    let v284 : bool = v270 <= 1
                    v284
                else
                    false
            if v285 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v280
                let v286 : string = "true; $0.into_iter().for_each(|x| { //"
                let v287 : bool = Fable.Core.RustInterop.emitRustExpr v262 v286 
                let v288 : string = "x"
                let v289 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v288 
                let v290 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v291 : bool = Fable.Core.RustInterop.emitRustExpr v289 v290 
                let v292 : string = $"true"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr () v292 
                let v294 : string = "true; }); //"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v188 v124
            #endif
#if FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#else
            v188 v124
            #endif
            // run_target_args' is_unit
            let v296 : (string -> unit) = v164.l0
            v296 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
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
and method25 (v0 : string) : string =
    let v1 : string = method15()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure8(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "wasm_path"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure8(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v61 : string = $"{v0}"
    let v69 : unit = ()
    let v70 : (unit -> unit) = closure8(v2, v61)
    let v71 : unit = (fun () -> v70 (); v69) ()
    let v79 : string = " }"
    let v80 : string = $"{v79}"
    let v88 : unit = ()
    let v89 : (unit -> unit) = closure8(v2, v80)
    let v90 : unit = (fun () -> v89 (); v88) ()
    let v96 : string = v2.l0
    v96
and method24 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method25(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v28 : (int64 -> string) = _.ToString()
    let v29 : string = v28 v10
    let v33 : string = v24 + v29 
    let v37 : string = v33 + v13 
    let v42 : string = "spiral_wasm.run"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method19(v53)
and closure13 (v0 : string) () : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
    let v58 : US3 = v44.l0
    let v59 : bool = v42.l0
    let v60 : bool = v59 = false
    let v63 : bool =
        if v60 then
            false
        else
            let v61 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v58
            let v62 : bool = 0 >= v61
            v62
    let v64 : bool = v63 = false
    let v298 : US8 =
        if v64 then
            US8_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method9(v104, v105, v106, v107, v108, v109)
            let v123 : string = method13()
            let v124 : string = method24(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v139 : unit = ()
            let v140 : unit = (fun () -> v16 (); v139) ()
            let struct (v163 : Mut0, v164 : Mut1, v165 : Mut2, v166 : Mut3, v167 : Mut4, v168 : int64 option) = TraceState.trace_state.Value
            let v183 : unit = ()
            let v184 : (unit -> unit) = closure9(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure10()
            (* run_target_args'
            let v189 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v190 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v190 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v191 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v192 : string = v166.l0
            let v193 : bool = v192 = ""
            let v208 : string =
                if v193 then
                    v124
                else
                    let v194 : bool = v124 = ""
                    if v194 then
                        let v195 : string = v166.l0
                        v195
                    else
                        let v196 : string = v166.l0
                        let v199 : string = "\n"
                        let v200 : string = v196 + v199 
                        let v204 : string = v200 + v124 
                        v204
            (* run_target_args'
            let v213 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v214 : string = "&*$0"
            let v215 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v214 
            let _run_target_args'_v213 = v215 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v216 : string = "&*$0"
            let v217 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v216 
            let _run_target_args'_v213 = v217 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v218 
            let _run_target_args'_v213 = v219 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v221 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v221 
            #endif
#if FABLE_COMPILER_PYTHON
            let v225 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v225 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v229 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v229 
            #endif
#else
            let v233 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v233 
            #endif
            let v236 : Ref<Str> = _run_target_args'_v213 
            let v245 : string = $"$0.chars()"
            let v246 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v236 v245 
            let v247 : string = "$0"
            let v248 : _ = Fable.Core.RustInterop.emitRustExpr v246 v247 
            let v249 : string = "$0.collect::<Vec<_>>()"
            let v250 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v248 v249 
            let v251 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v252 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v254 : bool = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "x"
            let v256 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v255 
            let v257 : string = "String::from_iter($0)"
            let v258 : std_string_String = Fable.Core.RustInterop.emitRustExpr v256 v257 
            let v259 : string = "true; $0 }).collect::<Vec<_>>()"
            let v260 : bool = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "_vec_map"
            let v262 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v261 
            let v263 : string = "$0.len()"
            let v264 : unativeint = Fable.Core.RustInterop.emitRustExpr v262 v263 
            let v270 : int32 = v264 |> int32 
            let v280 : string = ""
            let v281 : bool = v124 <> v280 
            let v285 : bool =
                if v281 then
                    let v284 : bool = v270 <= 1
                    v284
                else
                    false
            if v285 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v280
                let v286 : string = "true; $0.into_iter().for_each(|x| { //"
                let v287 : bool = Fable.Core.RustInterop.emitRustExpr v262 v286 
                let v288 : string = "x"
                let v289 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v288 
                let v290 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v291 : bool = Fable.Core.RustInterop.emitRustExpr v289 v290 
                let v292 : string = $"true"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr () v292 
                let v294 : string = "true; }); //"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v188 v124
            #endif
#if FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#else
            v188 v124
            #endif
            // run_target_args' is_unit
            let v296 : (string -> unit) = v164.l0
            v296 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method29 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) : string =
    let v3 : string = method15()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure8(v4, v8)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v26 : string = "retry"
    let v27 : string = $"{v26}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure8(v4, v27)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v45 : string = " = "
    let v46 : string = $"{v45}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure8(v4, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v66 : string = $"{v0}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure8(v4, v66)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v84 : string = "; "
    let v85 : string = $"{v84}"
    let v93 : unit = ()
    let v94 : (unit -> unit) = closure8(v4, v85)
    let v95 : unit = (fun () -> v94 (); v93) ()
    let v103 : string = "worker"
    let v104 : string = $"{v103}"
    let v112 : unit = ()
    let v113 : (unit -> unit) = closure8(v4, v104)
    let v114 : unit = (fun () -> v113 (); v112) ()
    let v121 : string = $"{v45}"
    let v129 : unit = ()
    let v130 : (unit -> unit) = closure8(v4, v121)
    let v131 : unit = (fun () -> v130 (); v129) ()
    (* run_target_args'
    let v141 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v142 : string = "format!(\"{:#?}\", $0)"
    let v143 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v142 
    let v144 : string = "fable_library_rust::String_::fromString($0)"
    let v145 : string = Fable.Core.RustInterop.emitRustExpr v143 v144 
    let _run_target_args'_v141 = v145 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v146 : string = "format!(\"{:#?}\", $0)"
    let v147 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v146 
    let v148 : string = "fable_library_rust::String_::fromString($0)"
    let v149 : string = Fable.Core.RustInterop.emitRustExpr v147 v148 
    let _run_target_args'_v141 = v149 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v150 : string = "format!(\"{:#?}\", $0)"
    let v151 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v150 
    let v152 : string = "fable_library_rust::String_::fromString($0)"
    let v153 : string = Fable.Core.RustInterop.emitRustExpr v151 v152 
    let _run_target_args'_v141 = v153 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v155 : string = $"%A{v1}"
    let _run_target_args'_v141 = v155 
    #endif
#if FABLE_COMPILER_PYTHON
    let v159 : string = $"%A{v1}"
    let _run_target_args'_v141 = v159 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v163 : string = $"%A{v1}"
    let _run_target_args'_v141 = v163 
    #endif
#else
    let v167 : string = $"%A{v1}"
    let _run_target_args'_v141 = v167 
    #endif
    let v170 : string = _run_target_args'_v141 
    let v180 : string = $"{v170}"
    let v188 : unit = ()
    let v189 : (unit -> unit) = closure8(v4, v180)
    let v190 : unit = (fun () -> v189 (); v188) ()
    let v197 : string = $"{v84}"
    let v205 : unit = ()
    let v206 : (unit -> unit) = closure8(v4, v197)
    let v207 : unit = (fun () -> v206 (); v205) ()
    let v215 : string = "contract"
    let v216 : string = $"{v215}"
    let v224 : unit = ()
    let v225 : (unit -> unit) = closure8(v4, v216)
    let v226 : unit = (fun () -> v225 (); v224) ()
    let v233 : string = $"{v45}"
    let v241 : unit = ()
    let v242 : (unit -> unit) = closure8(v4, v233)
    let v243 : unit = (fun () -> v242 (); v241) ()
    (* run_target_args'
    let v253 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v254 : string = "format!(\"{:#?}\", $0)"
    let v255 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v254 
    let v256 : string = "fable_library_rust::String_::fromString($0)"
    let v257 : string = Fable.Core.RustInterop.emitRustExpr v255 v256 
    let _run_target_args'_v253 = v257 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v258 : string = "format!(\"{:#?}\", $0)"
    let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v258 
    let v260 : string = "fable_library_rust::String_::fromString($0)"
    let v261 : string = Fable.Core.RustInterop.emitRustExpr v259 v260 
    let _run_target_args'_v253 = v261 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v262 : string = "format!(\"{:#?}\", $0)"
    let v263 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v262 
    let v264 : string = "fable_library_rust::String_::fromString($0)"
    let v265 : string = Fable.Core.RustInterop.emitRustExpr v263 v264 
    let _run_target_args'_v253 = v265 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v267 : string = $"%A{v2}"
    let _run_target_args'_v253 = v267 
    #endif
#if FABLE_COMPILER_PYTHON
    let v271 : string = $"%A{v2}"
    let _run_target_args'_v253 = v271 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v275 : string = $"%A{v2}"
    let _run_target_args'_v253 = v275 
    #endif
#else
    let v279 : string = $"%A{v2}"
    let _run_target_args'_v253 = v279 
    #endif
    let v282 : string = _run_target_args'_v253 
    let v292 : string = $"{v282}"
    let v300 : unit = ()
    let v301 : (unit -> unit) = closure8(v4, v292)
    let v302 : unit = (fun () -> v301 (); v300) ()
    let v310 : string = " }"
    let v311 : string = $"{v310}"
    let v319 : unit = ()
    let v320 : (unit -> unit) = closure8(v4, v311)
    let v321 : unit = (fun () -> v320 (); v319) ()
    let v327 : string = v4.l0
    v327
and method28 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v10 : near_workspaces_Contract) : string =
    let v11 : string = method29(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v20 : string = v16 + v7 
    let v25 : string = " #"
    let v26 : string = v20 + v25 
    let v30 : (int64 -> string) = _.ToString()
    let v31 : string = v30 v12
    let v35 : string = v26 + v31 
    let v39 : string = v35 + v15 
    let v44 : string = "spiral_wasm.run"
    let v45 : string = v39 + v44 
    let v50 : string = " / "
    let v51 : string = v45 + v50 
    let v55 : string = v51 + v11 
    method19(v55)
and closure14 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) () : unit =
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure6()
    let v19 : unit = (fun () -> v18 (); v17) ()
    let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
    let v60 : US3 = v46.l0
    let v61 : bool = v44.l0
    let v62 : bool = v61 = false
    let v65 : bool =
        if v62 then
            false
        else
            let v63 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v60
            let v64 : bool = 0 >= v63
            v64
    let v66 : bool = v65 = false
    let v300 : US8 =
        if v66 then
            US8_1
        else
            let v82 : unit = ()
            let v83 : unit = (fun () -> v18 (); v82) ()
            let struct (v106 : Mut0, v107 : Mut1, v108 : Mut2, v109 : Mut3, v110 : Mut4, v111 : int64 option) = TraceState.trace_state.Value
            let v124 : string = method9(v106, v107, v108, v109, v110, v111)
            let v125 : string = method13()
            let v126 : string = method28(v106, v107, v108, v109, v110, v111, v124, v125, v0, v1, v2)
            let v141 : unit = ()
            let v142 : unit = (fun () -> v18 (); v141) ()
            let struct (v165 : Mut0, v166 : Mut1, v167 : Mut2, v168 : Mut3, v169 : Mut4, v170 : int64 option) = TraceState.trace_state.Value
            let v185 : unit = ()
            let v186 : (unit -> unit) = closure9(v165)
            let v187 : unit = (fun () -> v186 (); v185) ()
            let v190 : (string -> unit) = closure10()
            (* run_target_args'
            let v191 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v126 v192 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v193 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v126 v193 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v194 : string = v168.l0
            let v195 : bool = v194 = ""
            let v210 : string =
                if v195 then
                    v126
                else
                    let v196 : bool = v126 = ""
                    if v196 then
                        let v197 : string = v168.l0
                        v197
                    else
                        let v198 : string = v168.l0
                        let v201 : string = "\n"
                        let v202 : string = v198 + v201 
                        let v206 : string = v202 + v126 
                        v206
            (* run_target_args'
            let v215 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v216 : string = "&*$0"
            let v217 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v210 v216 
            let _run_target_args'_v215 = v217 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v210 v218 
            let _run_target_args'_v215 = v219 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v220 : string = "&*$0"
            let v221 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v210 v220 
            let _run_target_args'_v215 = v221 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v223 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v223 
            #endif
#if FABLE_COMPILER_PYTHON
            let v227 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v227 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v231 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v231 
            #endif
#else
            let v235 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v235 
            #endif
            let v238 : Ref<Str> = _run_target_args'_v215 
            let v247 : string = $"$0.chars()"
            let v248 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v238 v247 
            let v249 : string = "$0"
            let v250 : _ = Fable.Core.RustInterop.emitRustExpr v248 v249 
            let v251 : string = "$0.collect::<Vec<_>>()"
            let v252 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v254 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v256 : bool = Fable.Core.RustInterop.emitRustExpr v254 v255 
            let v257 : string = "x"
            let v258 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v257 
            let v259 : string = "String::from_iter($0)"
            let v260 : std_string_String = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "true; $0 }).collect::<Vec<_>>()"
            let v262 : bool = Fable.Core.RustInterop.emitRustExpr v260 v261 
            let v263 : string = "_vec_map"
            let v264 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v263 
            let v265 : string = "$0.len()"
            let v266 : unativeint = Fable.Core.RustInterop.emitRustExpr v264 v265 
            let v272 : int32 = v266 |> int32 
            let v282 : string = ""
            let v283 : bool = v126 <> v282 
            let v287 : bool =
                if v283 then
                    let v286 : bool = v272 <= 1
                    v286
                else
                    false
            if v287 then
                v168.l0 <- v210
                ()
            else
                v168.l0 <- v282
                let v288 : string = "true; $0.into_iter().for_each(|x| { //"
                let v289 : bool = Fable.Core.RustInterop.emitRustExpr v264 v288 
                let v290 : string = "x"
                let v291 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v290 
                let v292 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr v291 v292 
                let v294 : string = $"true"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
                let v296 : string = "true; }); //"
                let v297 : bool = Fable.Core.RustInterop.emitRustExpr () v296 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v190 v126
            #endif
#if FABLE_COMPILER_PYTHON
            v190 v126
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v190 v126
            #endif
#else
            v190 v126
            #endif
            // run_target_args' is_unit
            let v298 : (string -> unit) = v166.l0
            v298 v126
            US8_0(v165, v166, v167, v168, v169, v170)
    
    ()
and method31 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure8(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "retry"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure8(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure8(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v65 : string = $"{v0}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v3, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = "; "
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure8(v3, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v102 : string = "result"
    let v103 : string = $"{v102}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v3, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v120 : string = $"{v44}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure8(v3, v120)
    let v130 : unit = (fun () -> v129 (); v128) ()
    (* run_target_args'
    let v140 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v141 : string = "format!(\"{:#?}\", $0)"
    let v142 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v141 
    let v143 : string = "fable_library_rust::String_::fromString($0)"
    let v144 : string = Fable.Core.RustInterop.emitRustExpr v142 v143 
    let _run_target_args'_v140 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "format!(\"{:#?}\", $0)"
    let v146 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v145 
    let v147 : string = "fable_library_rust::String_::fromString($0)"
    let v148 : string = Fable.Core.RustInterop.emitRustExpr v146 v147 
    let _run_target_args'_v140 = v148 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v149 : string = "format!(\"{:#?}\", $0)"
    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v149 
    let v151 : string = "fable_library_rust::String_::fromString($0)"
    let v152 : string = Fable.Core.RustInterop.emitRustExpr v150 v151 
    let _run_target_args'_v140 = v152 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v154 : string = $"%A{v1}"
    let _run_target_args'_v140 = v154 
    #endif
#if FABLE_COMPILER_PYTHON
    let v158 : string = $"%A{v1}"
    let _run_target_args'_v140 = v158 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v162 : string = $"%A{v1}"
    let _run_target_args'_v140 = v162 
    #endif
#else
    let v166 : string = $"%A{v1}"
    let _run_target_args'_v140 = v166 
    #endif
    let v169 : string = _run_target_args'_v140 
    let v179 : string = $"{v169}"
    let v187 : unit = ()
    let v188 : (unit -> unit) = closure8(v3, v179)
    let v189 : unit = (fun () -> v188 (); v187) ()
    let v197 : string = " }"
    let v198 : string = $"{v197}"
    let v206 : unit = ()
    let v207 : (unit -> unit) = closure8(v3, v198)
    let v208 : unit = (fun () -> v207 (); v206) ()
    let v214 : string = v3.l0
    v214
and method30 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_result_ExecutionFinalResult) : string =
    let v10 : string = method31(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v29 : (int64 -> string) = _.ToString()
    let v30 : string = v29 v11
    let v34 : string = v25 + v30 
    let v38 : string = v34 + v14 
    let v43 : string = "spiral_wasm.run"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method19(v54)
and closure15 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US3 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 0 >= v62
            v63
    let v65 : bool = v64 = false
    let v299 : US8 =
        if v65 then
            US8_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method9(v105, v106, v107, v108, v109, v110)
            let v124 : string = method13()
            let v125 : string = method30(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
            let v140 : unit = ()
            let v141 : unit = (fun () -> v17 (); v140) ()
            let struct (v164 : Mut0, v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : int64 option) = TraceState.trace_state.Value
            let v184 : unit = ()
            let v185 : (unit -> unit) = closure9(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure10()
            (* run_target_args'
            let v190 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v191 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v192 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : string = v167.l0
            let v194 : bool = v193 = ""
            let v209 : string =
                if v194 then
                    v125
                else
                    let v195 : bool = v125 = ""
                    if v195 then
                        let v196 : string = v167.l0
                        v196
                    else
                        let v197 : string = v167.l0
                        let v200 : string = "\n"
                        let v201 : string = v197 + v200 
                        let v205 : string = v201 + v125 
                        v205
            (* run_target_args'
            let v214 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v215 
            let _run_target_args'_v214 = v216 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v217 
            let _run_target_args'_v214 = v218 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v219 
            let _run_target_args'_v214 = v220 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v226 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v226 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v230 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v230 
            #endif
#else
            let v234 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v234 
            #endif
            let v237 : Ref<Str> = _run_target_args'_v214 
            let v246 : string = $"$0.chars()"
            let v247 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v237 v246 
            let v248 : string = "$0"
            let v249 : _ = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.collect::<Vec<_>>()"
            let v251 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v253 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v255 : bool = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "x"
            let v257 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v256 
            let v258 : string = "String::from_iter($0)"
            let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "true; $0 }).collect::<Vec<_>>()"
            let v261 : bool = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "_vec_map"
            let v263 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v262 
            let v264 : string = "$0.len()"
            let v265 : unativeint = Fable.Core.RustInterop.emitRustExpr v263 v264 
            let v271 : int32 = v265 |> int32 
            let v281 : string = ""
            let v282 : bool = v125 <> v281 
            let v286 : bool =
                if v282 then
                    let v285 : bool = v271 <= 1
                    v285
                else
                    false
            if v286 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v281
                let v287 : string = "true; $0.into_iter().for_each(|x| { //"
                let v288 : bool = Fable.Core.RustInterop.emitRustExpr v263 v287 
                let v289 : string = "x"
                let v290 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v289 
                let v291 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr v290 v291 
                let v293 : string = $"true"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                let v295 : string = "true; }); //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v189 v125
            #endif
#if FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#else
            v189 v125
            #endif
            // run_target_args' is_unit
            let v297 : (string -> unit) = v165.l0
            v297 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and closure17 (v0 : std_string_String) () : unit =
    let v1 : (std_string_String -> unit) = System.Console.WriteLine
    v1 v0
and closure16 () (v0 : std_string_String) : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure17(v0)
    let v4 : unit = (fun () -> v3 (); v2) ()
    ()
and closure18 () () : unit =
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure6()
    let v16 : unit = (fun () -> v15 (); v14) ()
    let struct (v39 : Mut0, v40 : Mut1, v41 : Mut2, v42 : Mut3, v43 : Mut4, v44 : int64 option) = TraceState.trace_state.Value
    let v57 : US3 = v43.l0
    let v58 : bool = v41.l0
    let v59 : bool = v58 = false
    let v62 : bool =
        if v59 then
            false
        else
            let v60 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v57
            let v61 : bool = 2 >= v60
            v61
    let v63 : bool = v62 = false
    let v239 : US8 =
        if v63 then
            US8_1
        else
            let v79 : unit = ()
            let v80 : unit = (fun () -> v15 (); v79) ()
            let struct (v103 : Mut0, v104 : Mut1, v105 : Mut2, v106 : Mut3, v107 : Mut4, v108 : int64 option) = TraceState.trace_state.Value
            let v123 : unit = ()
            let v124 : (unit -> unit) = closure9(v103)
            let v125 : unit = (fun () -> v124 (); v123) ()
            let v128 : string = " "
            let v129 : (string -> unit) = closure10()
            (* run_target_args'
            let v130 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v131 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v128 v131 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v132 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v128 v132 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v133 : string = v106.l0
            let v134 : bool = v133 = ""
            let v149 : string =
                if v134 then
                    v128
                else
                    let v135 : bool = v128 = ""
                    if v135 then
                        let v136 : string = v106.l0
                        v136
                    else
                        let v137 : string = v106.l0
                        let v140 : string = "\n"
                        let v141 : string = v137 + v140 
                        let v145 : string = v141 + v128 
                        v145
            (* run_target_args'
            let v154 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v155 : string = "&*$0"
            let v156 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v149 v155 
            let _run_target_args'_v154 = v156 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v157 : string = "&*$0"
            let v158 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v149 v157 
            let _run_target_args'_v154 = v158 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v159 : string = "&*$0"
            let v160 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v149 v159 
            let _run_target_args'_v154 = v160 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v162 : Ref<Str> = v149 |> unbox<Ref<Str>>
            let _run_target_args'_v154 = v162 
            #endif
#if FABLE_COMPILER_PYTHON
            let v166 : Ref<Str> = v149 |> unbox<Ref<Str>>
            let _run_target_args'_v154 = v166 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v170 : Ref<Str> = v149 |> unbox<Ref<Str>>
            let _run_target_args'_v154 = v170 
            #endif
#else
            let v174 : Ref<Str> = v149 |> unbox<Ref<Str>>
            let _run_target_args'_v154 = v174 
            #endif
            let v177 : Ref<Str> = _run_target_args'_v154 
            let v186 : string = $"$0.chars()"
            let v187 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v177 v186 
            let v188 : string = "$0"
            let v189 : _ = Fable.Core.RustInterop.emitRustExpr v187 v188 
            let v190 : string = "$0.collect::<Vec<_>>()"
            let v191 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v189 v190 
            let v192 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v193 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v191 v192 
            let v194 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v195 : bool = Fable.Core.RustInterop.emitRustExpr v193 v194 
            let v196 : string = "x"
            let v197 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v196 
            let v198 : string = "String::from_iter($0)"
            let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v197 v198 
            let v200 : string = "true; $0 }).collect::<Vec<_>>()"
            let v201 : bool = Fable.Core.RustInterop.emitRustExpr v199 v200 
            let v202 : string = "_vec_map"
            let v203 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v202 
            let v204 : string = "$0.len()"
            let v205 : unativeint = Fable.Core.RustInterop.emitRustExpr v203 v204 
            let v211 : int32 = v205 |> int32 
            let v221 : string = ""
            let v222 : bool = v128 <> v221 
            let v226 : bool =
                if v222 then
                    let v225 : bool = v211 <= 1
                    v225
                else
                    false
            if v226 then
                v106.l0 <- v149
                ()
            else
                v106.l0 <- v221
                let v227 : string = "true; $0.into_iter().for_each(|x| { //"
                let v228 : bool = Fable.Core.RustInterop.emitRustExpr v203 v227 
                let v229 : string = "x"
                let v230 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v229 
                let v231 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v232 : bool = Fable.Core.RustInterop.emitRustExpr v230 v231 
                let v233 : string = $"true"
                let v234 : bool = Fable.Core.RustInterop.emitRustExpr () v233 
                let v235 : string = "true; }); //"
                let v236 : bool = Fable.Core.RustInterop.emitRustExpr () v235 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v129 v128
            #endif
#if FABLE_COMPILER_PYTHON
            v129 v128
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v129 v128
            #endif
#else
            v129 v128
            #endif
            // run_target_args' is_unit
            let v237 : (string -> unit) = v104.l0
            v237 v128
            US8_0(v103, v104, v105, v106, v107, v108)
    
    ()
and method32 () : string =
    
    
    
    
    
    let v2 : string = "Info"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method14(v7)
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v26 : string = "inline_colorization::color_bright_green"
    let v27 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v26 
    (* run_target_args'
    let v32 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v33 : string = "&*$0"
    let v34 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v33 
    let _run_target_args'_v32 = v34 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v35 : string = "&*$0"
    let v36 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v35 
    let _run_target_args'_v32 = v36 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v37 : string = "&*$0"
    let v38 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v37 
    let _run_target_args'_v32 = v38 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v40 
    #endif
#if FABLE_COMPILER_PYTHON
    let v44 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v44 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v48 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v48 
    #endif
#else
    let v52 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v52 
    #endif
    let v55 : Ref<Str> = _run_target_args'_v32 
    let v64 : string = "inline_colorization::color_reset"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v64 
    let v66 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v67 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v27, v55, v65) v66 
    let v68 : string = "fable_library_rust::String_::fromString($0)"
    let v69 : string = Fable.Core.RustInterop.emitRustExpr v67 v68 
    let _run_target_args'_v25 = v69 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v70 : string = "inline_colorization::color_bright_green"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v70 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "&*$0"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : Ref<Str> = _run_target_args'_v76 
    let v108 : string = "inline_colorization::color_reset"
    let v109 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v108 
    let v110 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v111 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v71, v99, v109) v110 
    let v112 : string = "fable_library_rust::String_::fromString($0)"
    let v113 : string = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let _run_target_args'_v25 = v113 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v114 : string = "inline_colorization::color_bright_green"
    let v115 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v114 
    (* run_target_args'
    let v120 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v121 : string = "&*$0"
    let v122 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v121 
    let _run_target_args'_v120 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "&*$0"
    let v124 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v123 
    let _run_target_args'_v120 = v124 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v125 : string = "&*$0"
    let v126 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v125 
    let _run_target_args'_v120 = v126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v128 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v128 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v136 
    #endif
#else
    let v140 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v140 
    #endif
    let v143 : Ref<Str> = _run_target_args'_v120 
    let v152 : string = "inline_colorization::color_reset"
    let v153 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v152 
    let v154 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v115, v143, v153) v154 
    let v156 : string = "fable_library_rust::String_::fromString($0)"
    let v157 : string = Fable.Core.RustInterop.emitRustExpr v155 v156 
    let _run_target_args'_v25 = v157 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v159 : string = "\u001b[92m"
    let v163 : string = method16()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[92m"
    let v179 : string = method16()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[92m"
    let v195 : string = method16()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[92m"
    let v211 : string = method16()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method34 (v0 : uint8, v1 : float, v2 : uint64) : string =
    let v3 : string = method15()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure8(v4, v8)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v26 : string = "retry"
    let v27 : string = $"{v26}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure8(v4, v27)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v45 : string = " = "
    let v46 : string = $"{v45}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure8(v4, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v66 : string = $"{v0}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure8(v4, v66)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v84 : string = "; "
    let v85 : string = $"{v84}"
    let v93 : unit = ()
    let v94 : (unit -> unit) = closure8(v4, v85)
    let v95 : unit = (fun () -> v94 (); v93) ()
    let v103 : string = "total_gas_burnt_usd"
    let v104 : string = $"{v103}"
    let v112 : unit = ()
    let v113 : (unit -> unit) = closure8(v4, v104)
    let v114 : unit = (fun () -> v113 (); v112) ()
    let v121 : string = $"{v45}"
    let v129 : unit = ()
    let v130 : (unit -> unit) = closure8(v4, v121)
    let v131 : unit = (fun () -> v130 (); v129) ()
    let v141 : string = $"%+.6f{v1}"
    let v149 : unit = ()
    let v150 : (unit -> unit) = closure8(v4, v141)
    let v151 : unit = (fun () -> v150 (); v149) ()
    let v158 : string = $"{v84}"
    let v166 : unit = ()
    let v167 : (unit -> unit) = closure8(v4, v158)
    let v168 : unit = (fun () -> v167 (); v166) ()
    let v176 : string = "total_gas_burnt"
    let v177 : string = $"{v176}"
    let v185 : unit = ()
    let v186 : (unit -> unit) = closure8(v4, v177)
    let v187 : unit = (fun () -> v186 (); v185) ()
    let v194 : string = $"{v45}"
    let v202 : unit = ()
    let v203 : (unit -> unit) = closure8(v4, v194)
    let v204 : unit = (fun () -> v203 (); v202) ()
    let v214 : string = $"{v2}"
    let v222 : unit = ()
    let v223 : (unit -> unit) = closure8(v4, v214)
    let v224 : unit = (fun () -> v223 (); v222) ()
    let v232 : string = " }"
    let v233 : string = $"{v232}"
    let v241 : unit = ()
    let v242 : (unit -> unit) = closure8(v4, v233)
    let v243 : unit = (fun () -> v242 (); v241) ()
    let v249 : string = v4.l0
    v249
and method33 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : float, v10 : uint64) : string =
    let v11 : string = method34(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v20 : string = v16 + v7 
    let v25 : string = " #"
    let v26 : string = v20 + v25 
    let v30 : (int64 -> string) = _.ToString()
    let v31 : string = v30 v12
    let v35 : string = v26 + v31 
    let v39 : string = v35 + v15 
    let v44 : string = "near_workspaces.print_usd"
    let v45 : string = v39 + v44 
    let v50 : string = " / "
    let v51 : string = v45 + v50 
    let v55 : string = v51 + v11 
    method19(v55)
and closure19 (v0 : uint8, v1 : uint64, v2 : float) () : unit =
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure6()
    let v19 : unit = (fun () -> v18 (); v17) ()
    let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
    let v60 : US3 = v46.l0
    let v61 : bool = v44.l0
    let v62 : bool = v61 = false
    let v65 : bool =
        if v62 then
            false
        else
            let v63 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v60
            let v64 : bool = 2 >= v63
            v64
    let v66 : bool = v65 = false
    let v300 : US8 =
        if v66 then
            US8_1
        else
            let v82 : unit = ()
            let v83 : unit = (fun () -> v18 (); v82) ()
            let struct (v106 : Mut0, v107 : Mut1, v108 : Mut2, v109 : Mut3, v110 : Mut4, v111 : int64 option) = TraceState.trace_state.Value
            let v124 : string = method9(v106, v107, v108, v109, v110, v111)
            let v125 : string = method32()
            let v126 : string = method33(v106, v107, v108, v109, v110, v111, v124, v125, v0, v2, v1)
            let v141 : unit = ()
            let v142 : unit = (fun () -> v18 (); v141) ()
            let struct (v165 : Mut0, v166 : Mut1, v167 : Mut2, v168 : Mut3, v169 : Mut4, v170 : int64 option) = TraceState.trace_state.Value
            let v185 : unit = ()
            let v186 : (unit -> unit) = closure9(v165)
            let v187 : unit = (fun () -> v186 (); v185) ()
            let v190 : (string -> unit) = closure10()
            (* run_target_args'
            let v191 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v126 v192 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v193 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v126 v193 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v194 : string = v168.l0
            let v195 : bool = v194 = ""
            let v210 : string =
                if v195 then
                    v126
                else
                    let v196 : bool = v126 = ""
                    if v196 then
                        let v197 : string = v168.l0
                        v197
                    else
                        let v198 : string = v168.l0
                        let v201 : string = "\n"
                        let v202 : string = v198 + v201 
                        let v206 : string = v202 + v126 
                        v206
            (* run_target_args'
            let v215 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v216 : string = "&*$0"
            let v217 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v210 v216 
            let _run_target_args'_v215 = v217 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v210 v218 
            let _run_target_args'_v215 = v219 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v220 : string = "&*$0"
            let v221 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v210 v220 
            let _run_target_args'_v215 = v221 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v223 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v223 
            #endif
#if FABLE_COMPILER_PYTHON
            let v227 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v227 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v231 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v231 
            #endif
#else
            let v235 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v235 
            #endif
            let v238 : Ref<Str> = _run_target_args'_v215 
            let v247 : string = $"$0.chars()"
            let v248 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v238 v247 
            let v249 : string = "$0"
            let v250 : _ = Fable.Core.RustInterop.emitRustExpr v248 v249 
            let v251 : string = "$0.collect::<Vec<_>>()"
            let v252 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v254 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v256 : bool = Fable.Core.RustInterop.emitRustExpr v254 v255 
            let v257 : string = "x"
            let v258 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v257 
            let v259 : string = "String::from_iter($0)"
            let v260 : std_string_String = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "true; $0 }).collect::<Vec<_>>()"
            let v262 : bool = Fable.Core.RustInterop.emitRustExpr v260 v261 
            let v263 : string = "_vec_map"
            let v264 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v263 
            let v265 : string = "$0.len()"
            let v266 : unativeint = Fable.Core.RustInterop.emitRustExpr v264 v265 
            let v272 : int32 = v266 |> int32 
            let v282 : string = ""
            let v283 : bool = v126 <> v282 
            let v287 : bool =
                if v283 then
                    let v286 : bool = v272 <= 1
                    v286
                else
                    false
            if v287 then
                v168.l0 <- v210
                ()
            else
                v168.l0 <- v282
                let v288 : string = "true; $0.into_iter().for_each(|x| { //"
                let v289 : bool = Fable.Core.RustInterop.emitRustExpr v264 v288 
                let v290 : string = "x"
                let v291 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v290 
                let v292 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr v291 v292 
                let v294 : string = $"true"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
                let v296 : string = "true; }); //"
                let v297 : bool = Fable.Core.RustInterop.emitRustExpr () v296 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v190 v126
            #endif
#if FABLE_COMPILER_PYTHON
            v190 v126
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v190 v126
            #endif
#else
            v190 v126
            #endif
            // run_target_args' is_unit
            let v298 : (string -> unit) = v166.l0
            v298 v126
            US8_0(v165, v166, v167, v168, v169, v170)
    
    ()
and method36 (v0 : bool, v1 : float, v2 : float, v3 : uint64, v4 : u128) : string =
    let v5 : string = method15()
    let v6 : Mut3 = {l0 = v5} : Mut3
    let v9 : string = "{ "
    let v10 : string = $"{v9}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure8(v6, v10)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v28 : string = "is_success"
    let v29 : string = $"{v28}"
    let v37 : unit = ()
    let v38 : (unit -> unit) = closure8(v6, v29)
    let v39 : unit = (fun () -> v38 (); v37) ()
    let v47 : string = " = "
    let v48 : string = $"{v47}"
    let v56 : unit = ()
    let v57 : (unit -> unit) = closure8(v6, v48)
    let v58 : unit = (fun () -> v57 (); v56) ()
    let v66 : string =
        if v0 then
            let v64 : string = "true"
            v64
        else
            let v65 : string = "false"
            v65
    let v68 : string = $"{v66}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure8(v6, v68)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v86 : string = "; "
    let v87 : string = $"{v86}"
    let v95 : unit = ()
    let v96 : (unit -> unit) = closure8(v6, v87)
    let v97 : unit = (fun () -> v96 (); v95) ()
    let v105 : string = "gas_burnt_usd"
    let v106 : string = $"{v105}"
    let v114 : unit = ()
    let v115 : (unit -> unit) = closure8(v6, v106)
    let v116 : unit = (fun () -> v115 (); v114) ()
    let v123 : string = $"{v47}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure8(v6, v123)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v143 : string = $"%+.6f{v1}"
    let v151 : unit = ()
    let v152 : (unit -> unit) = closure8(v6, v143)
    let v153 : unit = (fun () -> v152 (); v151) ()
    let v160 : string = $"{v86}"
    let v168 : unit = ()
    let v169 : (unit -> unit) = closure8(v6, v160)
    let v170 : unit = (fun () -> v169 (); v168) ()
    let v178 : string = "tokens_burnt_usd"
    let v179 : string = $"{v178}"
    let v187 : unit = ()
    let v188 : (unit -> unit) = closure8(v6, v179)
    let v189 : unit = (fun () -> v188 (); v187) ()
    let v196 : string = $"{v47}"
    let v204 : unit = ()
    let v205 : (unit -> unit) = closure8(v6, v196)
    let v206 : unit = (fun () -> v205 (); v204) ()
    let v216 : string = $"%+.6f{v2}"
    let v224 : unit = ()
    let v225 : (unit -> unit) = closure8(v6, v216)
    let v226 : unit = (fun () -> v225 (); v224) ()
    let v233 : string = $"{v86}"
    let v241 : unit = ()
    let v242 : (unit -> unit) = closure8(v6, v233)
    let v243 : unit = (fun () -> v242 (); v241) ()
    let v251 : string = "gas_burnt"
    let v252 : string = $"{v251}"
    let v260 : unit = ()
    let v261 : (unit -> unit) = closure8(v6, v252)
    let v262 : unit = (fun () -> v261 (); v260) ()
    let v269 : string = $"{v47}"
    let v277 : unit = ()
    let v278 : (unit -> unit) = closure8(v6, v269)
    let v279 : unit = (fun () -> v278 (); v277) ()
    let v289 : string = $"{v3}"
    let v297 : unit = ()
    let v298 : (unit -> unit) = closure8(v6, v289)
    let v299 : unit = (fun () -> v298 (); v297) ()
    let v306 : string = $"{v86}"
    let v314 : unit = ()
    let v315 : (unit -> unit) = closure8(v6, v306)
    let v316 : unit = (fun () -> v315 (); v314) ()
    let v324 : string = "tokens_burnt"
    let v325 : string = $"{v324}"
    let v333 : unit = ()
    let v334 : (unit -> unit) = closure8(v6, v325)
    let v335 : unit = (fun () -> v334 (); v333) ()
    let v342 : string = $"{v47}"
    let v350 : unit = ()
    let v351 : (unit -> unit) = closure8(v6, v342)
    let v352 : unit = (fun () -> v351 (); v350) ()
    (* run_target_args'
    let v362 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v363 : string = "format!(\"{:#?}\", $0)"
    let v364 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v363 
    let v365 : string = "fable_library_rust::String_::fromString($0)"
    let v366 : string = Fable.Core.RustInterop.emitRustExpr v364 v365 
    let _run_target_args'_v362 = v366 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v367 : string = "format!(\"{:#?}\", $0)"
    let v368 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v367 
    let v369 : string = "fable_library_rust::String_::fromString($0)"
    let v370 : string = Fable.Core.RustInterop.emitRustExpr v368 v369 
    let _run_target_args'_v362 = v370 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v371 : string = "format!(\"{:#?}\", $0)"
    let v372 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v371 
    let v373 : string = "fable_library_rust::String_::fromString($0)"
    let v374 : string = Fable.Core.RustInterop.emitRustExpr v372 v373 
    let _run_target_args'_v362 = v374 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v376 : string = $"%A{v4}"
    let _run_target_args'_v362 = v376 
    #endif
#if FABLE_COMPILER_PYTHON
    let v380 : string = $"%A{v4}"
    let _run_target_args'_v362 = v380 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v384 : string = $"%A{v4}"
    let _run_target_args'_v362 = v384 
    #endif
#else
    let v388 : string = $"%A{v4}"
    let _run_target_args'_v362 = v388 
    #endif
    let v391 : string = _run_target_args'_v362 
    let v401 : string = $"{v391}"
    let v409 : unit = ()
    let v410 : (unit -> unit) = closure8(v6, v401)
    let v411 : unit = (fun () -> v410 (); v409) ()
    let v419 : string = " }"
    let v420 : string = $"{v419}"
    let v428 : unit = ()
    let v429 : (unit -> unit) = closure8(v6, v420)
    let v430 : unit = (fun () -> v429 (); v428) ()
    let v436 : string = v6.l0
    v436
and method35 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : bool, v9 : float, v10 : float, v11 : uint64, v12 : u128) : string =
    let v13 : string = method36(v8, v9, v10, v11, v12)
    let v14 : int64 = v0.l0
    let v17 : string = " "
    let v18 : string = v6 + v17 
    let v22 : string = v18 + v7 
    let v27 : string = " #"
    let v28 : string = v22 + v27 
    let v32 : (int64 -> string) = _.ToString()
    let v33 : string = v32 v14
    let v37 : string = v28 + v33 
    let v41 : string = v37 + v17 
    let v46 : string = "near_workspaces.print_usd / outcome"
    let v47 : string = v41 + v46 
    let v52 : string = " / "
    let v53 : string = v47 + v52 
    let v57 : string = v53 + v13 
    method19(v57)
and closure21 (v0 : bool, v1 : uint64, v2 : float, v3 : u128, v4 : float) () : unit =
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure6()
    let v21 : unit = (fun () -> v20 (); v19) ()
    let struct (v44 : Mut0, v45 : Mut1, v46 : Mut2, v47 : Mut3, v48 : Mut4, v49 : int64 option) = TraceState.trace_state.Value
    let v62 : US3 = v48.l0
    let v63 : bool = v46.l0
    let v64 : bool = v63 = false
    let v67 : bool =
        if v64 then
            false
        else
            let v65 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v62
            let v66 : bool = 2 >= v65
            v66
    let v68 : bool = v67 = false
    let v302 : US8 =
        if v68 then
            US8_1
        else
            let v84 : unit = ()
            let v85 : unit = (fun () -> v20 (); v84) ()
            let struct (v108 : Mut0, v109 : Mut1, v110 : Mut2, v111 : Mut3, v112 : Mut4, v113 : int64 option) = TraceState.trace_state.Value
            let v126 : string = method9(v108, v109, v110, v111, v112, v113)
            let v127 : string = method32()
            let v128 : string = method35(v108, v109, v110, v111, v112, v113, v126, v127, v0, v2, v4, v1, v3)
            let v143 : unit = ()
            let v144 : unit = (fun () -> v20 (); v143) ()
            let struct (v167 : Mut0, v168 : Mut1, v169 : Mut2, v170 : Mut3, v171 : Mut4, v172 : int64 option) = TraceState.trace_state.Value
            let v187 : unit = ()
            let v188 : (unit -> unit) = closure9(v167)
            let v189 : unit = (fun () -> v188 (); v187) ()
            let v192 : (string -> unit) = closure10()
            (* run_target_args'
            let v193 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v194 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v128 v194 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v195 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v128 v195 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v196 : string = v170.l0
            let v197 : bool = v196 = ""
            let v212 : string =
                if v197 then
                    v128
                else
                    let v198 : bool = v128 = ""
                    if v198 then
                        let v199 : string = v170.l0
                        v199
                    else
                        let v200 : string = v170.l0
                        let v203 : string = "\n"
                        let v204 : string = v200 + v203 
                        let v208 : string = v204 + v128 
                        v208
            (* run_target_args'
            let v217 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v212 v218 
            let _run_target_args'_v217 = v219 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v220 : string = "&*$0"
            let v221 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v212 v220 
            let _run_target_args'_v217 = v221 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v222 : string = "&*$0"
            let v223 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v212 v222 
            let _run_target_args'_v217 = v223 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v225 : Ref<Str> = v212 |> unbox<Ref<Str>>
            let _run_target_args'_v217 = v225 
            #endif
#if FABLE_COMPILER_PYTHON
            let v229 : Ref<Str> = v212 |> unbox<Ref<Str>>
            let _run_target_args'_v217 = v229 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v233 : Ref<Str> = v212 |> unbox<Ref<Str>>
            let _run_target_args'_v217 = v233 
            #endif
#else
            let v237 : Ref<Str> = v212 |> unbox<Ref<Str>>
            let _run_target_args'_v217 = v237 
            #endif
            let v240 : Ref<Str> = _run_target_args'_v217 
            let v249 : string = $"$0.chars()"
            let v250 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v240 v249 
            let v251 : string = "$0"
            let v252 : _ = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "$0.collect::<Vec<_>>()"
            let v254 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v256 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v254 v255 
            let v257 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v258 : bool = Fable.Core.RustInterop.emitRustExpr v256 v257 
            let v259 : string = "x"
            let v260 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v259 
            let v261 : string = "String::from_iter($0)"
            let v262 : std_string_String = Fable.Core.RustInterop.emitRustExpr v260 v261 
            let v263 : string = "true; $0 }).collect::<Vec<_>>()"
            let v264 : bool = Fable.Core.RustInterop.emitRustExpr v262 v263 
            let v265 : string = "_vec_map"
            let v266 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v265 
            let v267 : string = "$0.len()"
            let v268 : unativeint = Fable.Core.RustInterop.emitRustExpr v266 v267 
            let v274 : int32 = v268 |> int32 
            let v284 : string = ""
            let v285 : bool = v128 <> v284 
            let v289 : bool =
                if v285 then
                    let v288 : bool = v274 <= 1
                    v288
                else
                    false
            if v289 then
                v170.l0 <- v212
                ()
            else
                v170.l0 <- v284
                let v290 : string = "true; $0.into_iter().for_each(|x| { //"
                let v291 : bool = Fable.Core.RustInterop.emitRustExpr v266 v290 
                let v292 : string = "x"
                let v293 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v292 
                let v294 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr v293 v294 
                let v296 : string = $"true"
                let v297 : bool = Fable.Core.RustInterop.emitRustExpr () v296 
                let v298 : string = "true; }); //"
                let v299 : bool = Fable.Core.RustInterop.emitRustExpr () v298 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v192 v128
            #endif
#if FABLE_COMPILER_PYTHON
            v192 v128
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v192 v128
            #endif
#else
            v192 v128
            #endif
            // run_target_args' is_unit
            let v300 : (string -> unit) = v168.l0
            v300 v128
            US8_0(v167, v168, v169, v170, v171, v172)
    
    ()
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
    let v333 : unit = ()
    let v334 : (unit -> unit) = closure21(v2, v6, v13, v17, v21)
    let v335 : unit = (fun () -> v334 (); v333) ()
    ()
and method38 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v1 : string = method15()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure8(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "result2"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure8(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    (* run_target_args'
    let v64 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v65 : string = "format!(\"{:#?}\", $0)"
    let v66 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v65 
    let v67 : string = "fable_library_rust::String_::fromString($0)"
    let v68 : string = Fable.Core.RustInterop.emitRustExpr v66 v67 
    let _run_target_args'_v64 = v68 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v69 : string = "format!(\"{:#?}\", $0)"
    let v70 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v69 
    let v71 : string = "fable_library_rust::String_::fromString($0)"
    let v72 : string = Fable.Core.RustInterop.emitRustExpr v70 v71 
    let _run_target_args'_v64 = v72 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v73 : string = "format!(\"{:#?}\", $0)"
    let v74 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v73 
    let v75 : string = "fable_library_rust::String_::fromString($0)"
    let v76 : string = Fable.Core.RustInterop.emitRustExpr v74 v75 
    let _run_target_args'_v64 = v76 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v78 : string = $"%A{v0}"
    let _run_target_args'_v64 = v78 
    #endif
#if FABLE_COMPILER_PYTHON
    let v82 : string = $"%A{v0}"
    let _run_target_args'_v64 = v82 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v86 : string = $"%A{v0}"
    let _run_target_args'_v64 = v86 
    #endif
#else
    let v90 : string = $"%A{v0}"
    let _run_target_args'_v64 = v90 
    #endif
    let v93 : string = _run_target_args'_v64 
    let v103 : string = $"{v93}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v2, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v121 : string = " }"
    let v122 : string = $"{v121}"
    let v130 : unit = ()
    let v131 : (unit -> unit) = closure8(v2, v122)
    let v132 : unit = (fun () -> v131 (); v130) ()
    let v138 : string = v2.l0
    v138
and method37 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v9 : string = method38(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v28 : (int64 -> string) = _.ToString()
    let v29 : string = v28 v10
    let v33 : string = v24 + v29 
    let v37 : string = v33 + v13 
    let v42 : string = "spiral_wasm.run"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method19(v53)
and closure22 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) () : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
    let v58 : US3 = v44.l0
    let v59 : bool = v42.l0
    let v60 : bool = v59 = false
    let v63 : bool =
        if v60 then
            false
        else
            let v61 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v58
            let v62 : bool = 0 >= v61
            v62
    let v64 : bool = v63 = false
    let v298 : US8 =
        if v64 then
            US8_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method9(v104, v105, v106, v107, v108, v109)
            let v123 : string = method13()
            let v124 : string = method37(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v139 : unit = ()
            let v140 : unit = (fun () -> v16 (); v139) ()
            let struct (v163 : Mut0, v164 : Mut1, v165 : Mut2, v166 : Mut3, v167 : Mut4, v168 : int64 option) = TraceState.trace_state.Value
            let v183 : unit = ()
            let v184 : (unit -> unit) = closure9(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure10()
            (* run_target_args'
            let v189 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v190 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v190 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v191 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v192 : string = v166.l0
            let v193 : bool = v192 = ""
            let v208 : string =
                if v193 then
                    v124
                else
                    let v194 : bool = v124 = ""
                    if v194 then
                        let v195 : string = v166.l0
                        v195
                    else
                        let v196 : string = v166.l0
                        let v199 : string = "\n"
                        let v200 : string = v196 + v199 
                        let v204 : string = v200 + v124 
                        v204
            (* run_target_args'
            let v213 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v214 : string = "&*$0"
            let v215 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v214 
            let _run_target_args'_v213 = v215 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v216 : string = "&*$0"
            let v217 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v216 
            let _run_target_args'_v213 = v217 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v218 
            let _run_target_args'_v213 = v219 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v221 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v221 
            #endif
#if FABLE_COMPILER_PYTHON
            let v225 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v225 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v229 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v229 
            #endif
#else
            let v233 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v233 
            #endif
            let v236 : Ref<Str> = _run_target_args'_v213 
            let v245 : string = $"$0.chars()"
            let v246 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v236 v245 
            let v247 : string = "$0"
            let v248 : _ = Fable.Core.RustInterop.emitRustExpr v246 v247 
            let v249 : string = "$0.collect::<Vec<_>>()"
            let v250 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v248 v249 
            let v251 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v252 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v254 : bool = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "x"
            let v256 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v255 
            let v257 : string = "String::from_iter($0)"
            let v258 : std_string_String = Fable.Core.RustInterop.emitRustExpr v256 v257 
            let v259 : string = "true; $0 }).collect::<Vec<_>>()"
            let v260 : bool = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "_vec_map"
            let v262 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v261 
            let v263 : string = "$0.len()"
            let v264 : unativeint = Fable.Core.RustInterop.emitRustExpr v262 v263 
            let v270 : int32 = v264 |> int32 
            let v280 : string = ""
            let v281 : bool = v124 <> v280 
            let v285 : bool =
                if v281 then
                    let v284 : bool = v270 <= 1
                    v284
                else
                    false
            if v285 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v280
                let v286 : string = "true; $0.into_iter().for_each(|x| { //"
                let v287 : bool = Fable.Core.RustInterop.emitRustExpr v262 v286 
                let v288 : string = "x"
                let v289 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v288 
                let v290 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v291 : bool = Fable.Core.RustInterop.emitRustExpr v289 v290 
                let v292 : string = $"true"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr () v292 
                let v294 : string = "true; }); //"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v188 v124
            #endif
#if FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#else
            v188 v124
            #endif
            // run_target_args' is_unit
            let v296 : (string -> unit) = v164.l0
            v296 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method39 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method41 (v0 : int32, v1 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure8(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "receipt_failures_len"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure8(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure8(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v65 : string = $"{v0}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v3, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = "; "
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure8(v3, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v102 : string = "receipt_failures"
    let v103 : string = $"{v102}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v3, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v120 : string = $"{v44}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure8(v3, v120)
    let v130 : unit = (fun () -> v129 (); v128) ()
    (* run_target_args'
    let v140 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v141 : string = "format!(\"{:#?}\", $0)"
    let v142 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v141 
    let v143 : string = "fable_library_rust::String_::fromString($0)"
    let v144 : string = Fable.Core.RustInterop.emitRustExpr v142 v143 
    let _run_target_args'_v140 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "format!(\"{:#?}\", $0)"
    let v146 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v145 
    let v147 : string = "fable_library_rust::String_::fromString($0)"
    let v148 : string = Fable.Core.RustInterop.emitRustExpr v146 v147 
    let _run_target_args'_v140 = v148 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v149 : string = "format!(\"{:#?}\", $0)"
    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v149 
    let v151 : string = "fable_library_rust::String_::fromString($0)"
    let v152 : string = Fable.Core.RustInterop.emitRustExpr v150 v151 
    let _run_target_args'_v140 = v152 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v154 : string = $"%A{v1}"
    let _run_target_args'_v140 = v154 
    #endif
#if FABLE_COMPILER_PYTHON
    let v158 : string = $"%A{v1}"
    let _run_target_args'_v140 = v158 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v162 : string = $"%A{v1}"
    let _run_target_args'_v140 = v162 
    #endif
#else
    let v166 : string = $"%A{v1}"
    let _run_target_args'_v140 = v166 
    #endif
    let v169 : string = _run_target_args'_v140 
    let v179 : string = $"{v169}"
    let v187 : unit = ()
    let v188 : (unit -> unit) = closure8(v3, v179)
    let v189 : unit = (fun () -> v188 (); v187) ()
    let v197 : string = " }"
    let v198 : string = $"{v197}"
    let v206 : unit = ()
    let v207 : (unit -> unit) = closure8(v3, v198)
    let v208 : unit = (fun () -> v207 (); v206) ()
    let v214 : string = v3.l0
    v214
and method40 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v10 : string = method41(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v29 : (int64 -> string) = _.ToString()
    let v30 : string = v29 v11
    let v34 : string = v25 + v30 
    let v38 : string = v34 + v14 
    let v43 : string = "spiral_wasm.run"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method19(v54)
and closure23 (v0 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>, v1 : int32) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US3 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 0 >= v62
            v63
    let v65 : bool = v64 = false
    let v299 : US8 =
        if v65 then
            US8_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method9(v105, v106, v107, v108, v109, v110)
            let v124 : string = method13()
            let v125 : string = method40(v105, v106, v107, v108, v109, v110, v123, v124, v1, v0)
            let v140 : unit = ()
            let v141 : unit = (fun () -> v17 (); v140) ()
            let struct (v164 : Mut0, v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : int64 option) = TraceState.trace_state.Value
            let v184 : unit = ()
            let v185 : (unit -> unit) = closure9(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure10()
            (* run_target_args'
            let v190 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v191 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v192 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : string = v167.l0
            let v194 : bool = v193 = ""
            let v209 : string =
                if v194 then
                    v125
                else
                    let v195 : bool = v125 = ""
                    if v195 then
                        let v196 : string = v167.l0
                        v196
                    else
                        let v197 : string = v167.l0
                        let v200 : string = "\n"
                        let v201 : string = v197 + v200 
                        let v205 : string = v201 + v125 
                        v205
            (* run_target_args'
            let v214 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v215 
            let _run_target_args'_v214 = v216 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v217 
            let _run_target_args'_v214 = v218 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v219 
            let _run_target_args'_v214 = v220 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v226 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v226 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v230 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v230 
            #endif
#else
            let v234 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v234 
            #endif
            let v237 : Ref<Str> = _run_target_args'_v214 
            let v246 : string = $"$0.chars()"
            let v247 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v237 v246 
            let v248 : string = "$0"
            let v249 : _ = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.collect::<Vec<_>>()"
            let v251 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v253 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v255 : bool = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "x"
            let v257 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v256 
            let v258 : string = "String::from_iter($0)"
            let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "true; $0 }).collect::<Vec<_>>()"
            let v261 : bool = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "_vec_map"
            let v263 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v262 
            let v264 : string = "$0.len()"
            let v265 : unativeint = Fable.Core.RustInterop.emitRustExpr v263 v264 
            let v271 : int32 = v265 |> int32 
            let v281 : string = ""
            let v282 : bool = v125 <> v281 
            let v286 : bool =
                if v282 then
                    let v285 : bool = v271 <= 1
                    v285
                else
                    false
            if v286 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v281
                let v287 : string = "true; $0.into_iter().for_each(|x| { //"
                let v288 : bool = Fable.Core.RustInterop.emitRustExpr v263 v287 
                let v289 : string = "x"
                let v290 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v289 
                let v291 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr v290 v291 
                let v293 : string = $"true"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                let v295 : string = "true; }); //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v189 v125
            #endif
#if FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#else
            v189 v125
            #endif
            // run_target_args' is_unit
            let v297 : (string -> unit) = v165.l0
            v297 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and method42 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method44 (v0 : int32, v1 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure8(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "receipt_outcomes_len"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure8(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure8(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v65 : string = $"{v0}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v3, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = "; "
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure8(v3, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v102 : string = "receipt_outcomes"
    let v103 : string = $"{v102}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v3, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v120 : string = $"{v44}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure8(v3, v120)
    let v130 : unit = (fun () -> v129 (); v128) ()
    (* run_target_args'
    let v140 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v141 : string = "format!(\"{:#?}\", $0)"
    let v142 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v141 
    let v143 : string = "fable_library_rust::String_::fromString($0)"
    let v144 : string = Fable.Core.RustInterop.emitRustExpr v142 v143 
    let _run_target_args'_v140 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "format!(\"{:#?}\", $0)"
    let v146 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v145 
    let v147 : string = "fable_library_rust::String_::fromString($0)"
    let v148 : string = Fable.Core.RustInterop.emitRustExpr v146 v147 
    let _run_target_args'_v140 = v148 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v149 : string = "format!(\"{:#?}\", $0)"
    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v149 
    let v151 : string = "fable_library_rust::String_::fromString($0)"
    let v152 : string = Fable.Core.RustInterop.emitRustExpr v150 v151 
    let _run_target_args'_v140 = v152 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v154 : string = $"%A{v1}"
    let _run_target_args'_v140 = v154 
    #endif
#if FABLE_COMPILER_PYTHON
    let v158 : string = $"%A{v1}"
    let _run_target_args'_v140 = v158 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v162 : string = $"%A{v1}"
    let _run_target_args'_v140 = v162 
    #endif
#else
    let v166 : string = $"%A{v1}"
    let _run_target_args'_v140 = v166 
    #endif
    let v169 : string = _run_target_args'_v140 
    let v179 : string = $"{v169}"
    let v187 : unit = ()
    let v188 : (unit -> unit) = closure8(v3, v179)
    let v189 : unit = (fun () -> v188 (); v187) ()
    let v197 : string = " }"
    let v198 : string = $"{v197}"
    let v206 : unit = ()
    let v207 : (unit -> unit) = closure8(v3, v198)
    let v208 : unit = (fun () -> v207 (); v206) ()
    let v214 : string = v3.l0
    v214
and method43 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v10 : string = method44(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v29 : (int64 -> string) = _.ToString()
    let v30 : string = v29 v11
    let v34 : string = v25 + v30 
    let v38 : string = v34 + v14 
    let v43 : string = "spiral_wasm.run"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method19(v54)
and closure24 (v0 : Vec<near_workspaces_result_ExecutionOutcome>, v1 : int32) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US3 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 0 >= v62
            v63
    let v65 : bool = v64 = false
    let v299 : US8 =
        if v65 then
            US8_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method9(v105, v106, v107, v108, v109, v110)
            let v124 : string = method13()
            let v125 : string = method43(v105, v106, v107, v108, v109, v110, v123, v124, v1, v0)
            let v140 : unit = ()
            let v141 : unit = (fun () -> v17 (); v140) ()
            let struct (v164 : Mut0, v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : int64 option) = TraceState.trace_state.Value
            let v184 : unit = ()
            let v185 : (unit -> unit) = closure9(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure10()
            (* run_target_args'
            let v190 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v191 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v192 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : string = v167.l0
            let v194 : bool = v193 = ""
            let v209 : string =
                if v194 then
                    v125
                else
                    let v195 : bool = v125 = ""
                    if v195 then
                        let v196 : string = v167.l0
                        v196
                    else
                        let v197 : string = v167.l0
                        let v200 : string = "\n"
                        let v201 : string = v197 + v200 
                        let v205 : string = v201 + v125 
                        v205
            (* run_target_args'
            let v214 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v215 
            let _run_target_args'_v214 = v216 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v217 
            let _run_target_args'_v214 = v218 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v219 
            let _run_target_args'_v214 = v220 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v226 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v226 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v230 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v230 
            #endif
#else
            let v234 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v234 
            #endif
            let v237 : Ref<Str> = _run_target_args'_v214 
            let v246 : string = $"$0.chars()"
            let v247 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v237 v246 
            let v248 : string = "$0"
            let v249 : _ = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.collect::<Vec<_>>()"
            let v251 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v253 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v255 : bool = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "x"
            let v257 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v256 
            let v258 : string = "String::from_iter($0)"
            let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "true; $0 }).collect::<Vec<_>>()"
            let v261 : bool = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "_vec_map"
            let v263 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v262 
            let v264 : string = "$0.len()"
            let v265 : unativeint = Fable.Core.RustInterop.emitRustExpr v263 v264 
            let v271 : int32 = v265 |> int32 
            let v281 : string = ""
            let v282 : bool = v125 <> v281 
            let v286 : bool =
                if v282 then
                    let v285 : bool = v271 <= 1
                    v285
                else
                    false
            if v286 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v281
                let v287 : string = "true; $0.into_iter().for_each(|x| { //"
                let v288 : bool = Fable.Core.RustInterop.emitRustExpr v263 v287 
                let v289 : string = "x"
                let v290 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v289 
                let v291 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr v290 v291 
                let v293 : string = $"true"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                let v295 : string = "true; }); //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v189 v125
            #endif
#if FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#else
            v189 v125
            #endif
            // run_target_args' is_unit
            let v297 : (string -> unit) = v165.l0
            v297 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and method46 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method15()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure8(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "json"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure8(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    (* run_target_args'
    let v64 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v65 : string = "format!(\"{:#?}\", $0)"
    let v66 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v65 
    let v67 : string = "fable_library_rust::String_::fromString($0)"
    let v68 : string = Fable.Core.RustInterop.emitRustExpr v66 v67 
    let _run_target_args'_v64 = v68 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v69 : string = "format!(\"{:#?}\", $0)"
    let v70 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v69 
    let v71 : string = "fable_library_rust::String_::fromString($0)"
    let v72 : string = Fable.Core.RustInterop.emitRustExpr v70 v71 
    let _run_target_args'_v64 = v72 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v73 : string = "format!(\"{:#?}\", $0)"
    let v74 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v73 
    let v75 : string = "fable_library_rust::String_::fromString($0)"
    let v76 : string = Fable.Core.RustInterop.emitRustExpr v74 v75 
    let _run_target_args'_v64 = v76 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v78 : string = $"%A{v0}"
    let _run_target_args'_v64 = v78 
    #endif
#if FABLE_COMPILER_PYTHON
    let v82 : string = $"%A{v0}"
    let _run_target_args'_v64 = v82 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v86 : string = $"%A{v0}"
    let _run_target_args'_v64 = v86 
    #endif
#else
    let v90 : string = $"%A{v0}"
    let _run_target_args'_v64 = v90 
    #endif
    let v93 : string = _run_target_args'_v64 
    let v103 : string = $"{v93}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v2, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v121 : string = " }"
    let v122 : string = $"{v121}"
    let v130 : unit = ()
    let v131 : (unit -> unit) = closure8(v2, v122)
    let v132 : unit = (fun () -> v131 (); v130) ()
    let v138 : string = v2.l0
    v138
and method45 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method46(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v28 : (int64 -> string) = _.ToString()
    let v29 : string = v28 v10
    let v33 : string = v24 + v29 
    let v37 : string = v33 + v13 
    let v42 : string = "spiral_wasm.run"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method19(v53)
and closure25 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
    let v58 : US3 = v44.l0
    let v59 : bool = v42.l0
    let v60 : bool = v59 = false
    let v63 : bool =
        if v60 then
            false
        else
            let v61 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v58
            let v62 : bool = 0 >= v61
            v62
    let v64 : bool = v63 = false
    let v298 : US8 =
        if v64 then
            US8_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method9(v104, v105, v106, v107, v108, v109)
            let v123 : string = method13()
            let v124 : string = method45(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v139 : unit = ()
            let v140 : unit = (fun () -> v16 (); v139) ()
            let struct (v163 : Mut0, v164 : Mut1, v165 : Mut2, v166 : Mut3, v167 : Mut4, v168 : int64 option) = TraceState.trace_state.Value
            let v183 : unit = ()
            let v184 : (unit -> unit) = closure9(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure10()
            (* run_target_args'
            let v189 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v190 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v190 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v191 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v192 : string = v166.l0
            let v193 : bool = v192 = ""
            let v208 : string =
                if v193 then
                    v124
                else
                    let v194 : bool = v124 = ""
                    if v194 then
                        let v195 : string = v166.l0
                        v195
                    else
                        let v196 : string = v166.l0
                        let v199 : string = "\n"
                        let v200 : string = v196 + v199 
                        let v204 : string = v200 + v124 
                        v204
            (* run_target_args'
            let v213 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v214 : string = "&*$0"
            let v215 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v214 
            let _run_target_args'_v213 = v215 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v216 : string = "&*$0"
            let v217 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v216 
            let _run_target_args'_v213 = v217 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v218 
            let _run_target_args'_v213 = v219 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v221 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v221 
            #endif
#if FABLE_COMPILER_PYTHON
            let v225 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v225 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v229 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v229 
            #endif
#else
            let v233 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v233 
            #endif
            let v236 : Ref<Str> = _run_target_args'_v213 
            let v245 : string = $"$0.chars()"
            let v246 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v236 v245 
            let v247 : string = "$0"
            let v248 : _ = Fable.Core.RustInterop.emitRustExpr v246 v247 
            let v249 : string = "$0.collect::<Vec<_>>()"
            let v250 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v248 v249 
            let v251 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v252 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v254 : bool = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "x"
            let v256 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v255 
            let v257 : string = "String::from_iter($0)"
            let v258 : std_string_String = Fable.Core.RustInterop.emitRustExpr v256 v257 
            let v259 : string = "true; $0 }).collect::<Vec<_>>()"
            let v260 : bool = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "_vec_map"
            let v262 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v261 
            let v263 : string = "$0.len()"
            let v264 : unativeint = Fable.Core.RustInterop.emitRustExpr v262 v263 
            let v270 : int32 = v264 |> int32 
            let v280 : string = ""
            let v281 : bool = v124 <> v280 
            let v285 : bool =
                if v281 then
                    let v284 : bool = v270 <= 1
                    v284
                else
                    false
            if v285 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v280
                let v286 : string = "true; $0.into_iter().for_each(|x| { //"
                let v287 : bool = Fable.Core.RustInterop.emitRustExpr v262 v286 
                let v288 : string = "x"
                let v289 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v288 
                let v290 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v291 : bool = Fable.Core.RustInterop.emitRustExpr v289 v290 
                let v292 : string = $"true"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr () v292 
                let v294 : string = "true; }); //"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v188 v124
            #endif
#if FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#else
            v188 v124
            #endif
            // run_target_args' is_unit
            let v296 : (string -> unit) = v164.l0
            v296 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method48 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method15()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure8(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "borsh"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure8(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    (* run_target_args'
    let v64 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v65 : string = "format!(\"{:#?}\", $0)"
    let v66 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v65 
    let v67 : string = "fable_library_rust::String_::fromString($0)"
    let v68 : string = Fable.Core.RustInterop.emitRustExpr v66 v67 
    let _run_target_args'_v64 = v68 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v69 : string = "format!(\"{:#?}\", $0)"
    let v70 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v69 
    let v71 : string = "fable_library_rust::String_::fromString($0)"
    let v72 : string = Fable.Core.RustInterop.emitRustExpr v70 v71 
    let _run_target_args'_v64 = v72 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v73 : string = "format!(\"{:#?}\", $0)"
    let v74 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v73 
    let v75 : string = "fable_library_rust::String_::fromString($0)"
    let v76 : string = Fable.Core.RustInterop.emitRustExpr v74 v75 
    let _run_target_args'_v64 = v76 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v78 : string = $"%A{v0}"
    let _run_target_args'_v64 = v78 
    #endif
#if FABLE_COMPILER_PYTHON
    let v82 : string = $"%A{v0}"
    let _run_target_args'_v64 = v82 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v86 : string = $"%A{v0}"
    let _run_target_args'_v64 = v86 
    #endif
#else
    let v90 : string = $"%A{v0}"
    let _run_target_args'_v64 = v90 
    #endif
    let v93 : string = _run_target_args'_v64 
    let v103 : string = $"{v93}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v2, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v121 : string = " }"
    let v122 : string = $"{v121}"
    let v130 : unit = ()
    let v131 : (unit -> unit) = closure8(v2, v122)
    let v132 : unit = (fun () -> v131 (); v130) ()
    let v138 : string = v2.l0
    v138
and method47 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method48(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v28 : (int64 -> string) = _.ToString()
    let v29 : string = v28 v10
    let v33 : string = v24 + v29 
    let v37 : string = v33 + v13 
    let v42 : string = "spiral_wasm.run"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method19(v53)
and closure26 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
    let v58 : US3 = v44.l0
    let v59 : bool = v42.l0
    let v60 : bool = v59 = false
    let v63 : bool =
        if v60 then
            false
        else
            let v61 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v58
            let v62 : bool = 0 >= v61
            v62
    let v64 : bool = v63 = false
    let v298 : US8 =
        if v64 then
            US8_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method9(v104, v105, v106, v107, v108, v109)
            let v123 : string = method13()
            let v124 : string = method47(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v139 : unit = ()
            let v140 : unit = (fun () -> v16 (); v139) ()
            let struct (v163 : Mut0, v164 : Mut1, v165 : Mut2, v166 : Mut3, v167 : Mut4, v168 : int64 option) = TraceState.trace_state.Value
            let v183 : unit = ()
            let v184 : (unit -> unit) = closure9(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure10()
            (* run_target_args'
            let v189 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v190 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v190 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v191 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v192 : string = v166.l0
            let v193 : bool = v192 = ""
            let v208 : string =
                if v193 then
                    v124
                else
                    let v194 : bool = v124 = ""
                    if v194 then
                        let v195 : string = v166.l0
                        v195
                    else
                        let v196 : string = v166.l0
                        let v199 : string = "\n"
                        let v200 : string = v196 + v199 
                        let v204 : string = v200 + v124 
                        v204
            (* run_target_args'
            let v213 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v214 : string = "&*$0"
            let v215 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v214 
            let _run_target_args'_v213 = v215 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v216 : string = "&*$0"
            let v217 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v216 
            let _run_target_args'_v213 = v217 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v218 
            let _run_target_args'_v213 = v219 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v221 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v221 
            #endif
#if FABLE_COMPILER_PYTHON
            let v225 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v225 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v229 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v229 
            #endif
#else
            let v233 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v233 
            #endif
            let v236 : Ref<Str> = _run_target_args'_v213 
            let v245 : string = $"$0.chars()"
            let v246 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v236 v245 
            let v247 : string = "$0"
            let v248 : _ = Fable.Core.RustInterop.emitRustExpr v246 v247 
            let v249 : string = "$0.collect::<Vec<_>>()"
            let v250 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v248 v249 
            let v251 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v252 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v254 : bool = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "x"
            let v256 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v255 
            let v257 : string = "String::from_iter($0)"
            let v258 : std_string_String = Fable.Core.RustInterop.emitRustExpr v256 v257 
            let v259 : string = "true; $0 }).collect::<Vec<_>>()"
            let v260 : bool = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "_vec_map"
            let v262 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v261 
            let v263 : string = "$0.len()"
            let v264 : unativeint = Fable.Core.RustInterop.emitRustExpr v262 v263 
            let v270 : int32 = v264 |> int32 
            let v280 : string = ""
            let v281 : bool = v124 <> v280 
            let v285 : bool =
                if v281 then
                    let v284 : bool = v270 <= 1
                    v284
                else
                    false
            if v285 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v280
                let v286 : string = "true; $0.into_iter().for_each(|x| { //"
                let v287 : bool = Fable.Core.RustInterop.emitRustExpr v262 v286 
                let v288 : string = "x"
                let v289 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v288 
                let v290 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v291 : bool = Fable.Core.RustInterop.emitRustExpr v289 v290 
                let v292 : string = $"true"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr () v292 
                let v294 : string = "true; }); //"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v188 v124
            #endif
#if FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#else
            v188 v124
            #endif
            // run_target_args' is_unit
            let v296 : (string -> unit) = v164.l0
            v296 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method49 (v0 : int32, v1 : uint8, v2 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v3 : string = method15()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure8(v4, v8)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v26 : string = "receipt_outcomes_len"
    let v27 : string = $"{v26}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure8(v4, v27)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v45 : string = " = "
    let v46 : string = $"{v45}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure8(v4, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v66 : string = $"{v0}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure8(v4, v66)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v84 : string = "; "
    let v85 : string = $"{v84}"
    let v93 : unit = ()
    let v94 : (unit -> unit) = closure8(v4, v85)
    let v95 : unit = (fun () -> v94 (); v93) ()
    let v103 : string = "retry"
    let v104 : string = $"{v103}"
    let v112 : unit = ()
    let v113 : (unit -> unit) = closure8(v4, v104)
    let v114 : unit = (fun () -> v113 (); v112) ()
    let v121 : string = $"{v45}"
    let v129 : unit = ()
    let v130 : (unit -> unit) = closure8(v4, v121)
    let v131 : unit = (fun () -> v130 (); v129) ()
    let v141 : string = $"{v1}"
    let v149 : unit = ()
    let v150 : (unit -> unit) = closure8(v4, v141)
    let v151 : unit = (fun () -> v150 (); v149) ()
    let v158 : string = $"{v84}"
    let v166 : unit = ()
    let v167 : (unit -> unit) = closure8(v4, v158)
    let v168 : unit = (fun () -> v167 (); v166) ()
    let v176 : string = "receipt_failures"
    let v177 : string = $"{v176}"
    let v185 : unit = ()
    let v186 : (unit -> unit) = closure8(v4, v177)
    let v187 : unit = (fun () -> v186 (); v185) ()
    let v194 : string = $"{v45}"
    let v202 : unit = ()
    let v203 : (unit -> unit) = closure8(v4, v194)
    let v204 : unit = (fun () -> v203 (); v202) ()
    (* run_target_args'
    let v214 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v215 : string = "format!(\"{:#?}\", $0)"
    let v216 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v215 
    let v217 : string = "fable_library_rust::String_::fromString($0)"
    let v218 : string = Fable.Core.RustInterop.emitRustExpr v216 v217 
    let _run_target_args'_v214 = v218 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v219 : string = "format!(\"{:#?}\", $0)"
    let v220 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v219 
    let v221 : string = "fable_library_rust::String_::fromString($0)"
    let v222 : string = Fable.Core.RustInterop.emitRustExpr v220 v221 
    let _run_target_args'_v214 = v222 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v223 : string = "format!(\"{:#?}\", $0)"
    let v224 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v223 
    let v225 : string = "fable_library_rust::String_::fromString($0)"
    let v226 : string = Fable.Core.RustInterop.emitRustExpr v224 v225 
    let _run_target_args'_v214 = v226 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v228 : string = $"%A{v2}"
    let _run_target_args'_v214 = v228 
    #endif
#if FABLE_COMPILER_PYTHON
    let v232 : string = $"%A{v2}"
    let _run_target_args'_v214 = v232 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v236 : string = $"%A{v2}"
    let _run_target_args'_v214 = v236 
    #endif
#else
    let v240 : string = $"%A{v2}"
    let _run_target_args'_v214 = v240 
    #endif
    let v243 : string = _run_target_args'_v214 
    let v253 : string = $"{v243}"
    let v261 : unit = ()
    let v262 : (unit -> unit) = closure8(v4, v253)
    let v263 : unit = (fun () -> v262 (); v261) ()
    let v271 : string = " }"
    let v272 : string = $"{v271}"
    let v280 : unit = ()
    let v281 : (unit -> unit) = closure8(v4, v272)
    let v282 : unit = (fun () -> v281 (); v280) ()
    let v288 : string = v4.l0
    v288
and method27 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> =
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
    let v331 : unit = ()
    let v332 : (unit -> unit) = closure14(v1, v11, v19)
    let v333 : unit = (fun () -> v332 (); v331) ()
    let v648 : string = "$0.call(&*$1)"
    let v649 : string = "state_main"
    let v650 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr struct (v19, v649) v648 
    let v651 : string = "near_workspaces::types::Gas::from_tgas(300)"
    let v652 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr () v651 
    let v653 : string = "v650.gas(v652)"
    let v654 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr () v653 
    let v655 : string = "Box::pin(v654.transact())"
    let v656 : std_pin_Pin<Box<Dyn<std_future_Future<Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v655 
    let v657 : string = "v656.await"
    let v658 : Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v657 
    let v659 : string = "$0?"
    let v660 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v658 v659 
    let v972 : unit = ()
    let v973 : (unit -> unit) = closure15(v1, v660)
    let v974 : unit = (fun () -> v973 (); v972) ()
    let v1289 : string = "v660.logs()"
    let v1290 : Vec<Ref<Str>> = Fable.Core.RustInterop.emitRustExpr () v1289 
    let v1291 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v1292 : bool = Fable.Core.RustInterop.emitRustExpr v1290 v1291 
    let v1293 : string = "x"
    let v1294 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1293 
    (* run_target_args'
    let v1299 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1300 : string = "String::from($0)"
    let v1301 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1294 v1300 
    let _run_target_args'_v1299 = v1301 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1302 : string = "String::from($0)"
    let v1303 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1294 v1302 
    let _run_target_args'_v1299 = v1303 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1304 : string = "String::from($0)"
    let v1305 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1294 v1304 
    let _run_target_args'_v1299 = v1305 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1307 : std_string_String = v1294 |> unbox<std_string_String>
    let _run_target_args'_v1299 = v1307 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1311 : std_string_String = v1294 |> unbox<std_string_String>
    let _run_target_args'_v1299 = v1311 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1315 : std_string_String = v1294 |> unbox<std_string_String>
    let _run_target_args'_v1299 = v1315 
    #endif
#else
    let v1319 : std_string_String = v1294 |> unbox<std_string_String>
    let _run_target_args'_v1299 = v1319 
    #endif
    let v1322 : std_string_String = _run_target_args'_v1299 
    let v1331 : string = "true; $0 }).collect::<Vec<_>>()"
    let v1332 : bool = Fable.Core.RustInterop.emitRustExpr v1322 v1331 
    let v1333 : string = "_vec_map"
    let v1334 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1333 
    let v1335 : string = "true; $0.iter().for_each(|x| { $1(x.clone()); }); //"
    let v1336 : (std_string_String -> unit) = closure16()
    let v1337 : bool = Fable.Core.RustInterop.emitRustExpr struct (v1334, v1336) v1335 
    let v1592 : unit = ()
    let v1593 : (unit -> unit) = closure18()
    let v1594 : unit = (fun () -> v1593 (); v1592) ()
    let v1851 : string = "$0.total_gas_burnt"
    let v1852 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v660 v1851 
    let v1853 : string = "$0.as_gas()"
    let v1854 : uint64 = Fable.Core.RustInterop.emitRustExpr v1852 v1853 
    let v1856 : (uint64 -> float) = float
    let v1857 : float = v1856 v1854
    let v1860 : float = v1857 / 10000000000000000.0
    let v1861 : float = v1860 * 6.68
    let v2173 : unit = ()
    let v2174 : (unit -> unit) = closure19(v1, v1854, v1861)
    let v2175 : unit = (fun () -> v2174 (); v2173) ()
    let v2490 : string = "$0"
    let v2491 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v660 v2490 
    let v2492 : string = "v2491.outcomes()"
    let v2493 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v2492 
    let v2494 : string = "v2493.into_iter()"
    let v2495 : _ = Fable.Core.RustInterop.emitRustExpr () v2494 
    let v2496 : string = "v2495.cloned()"
    let v2497 : _ = Fable.Core.RustInterop.emitRustExpr () v2496 
    let v2498 : string = "true; v2497.for_each(|x| $0(x))"
    let v2499 : (near_workspaces_result_ExecutionOutcome -> unit) = closure20()
    let v2500 : bool = Fable.Core.RustInterop.emitRustExpr v2499 v2498 
    let v2501 : string = "$0.into_result()"
    let v2502 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure> = Fable.Core.RustInterop.emitRustExpr v660 v2501 
    let v2814 : unit = ()
    let v2815 : (unit -> unit) = closure22(v2502)
    let v2816 : unit = (fun () -> v2815 (); v2814) ()
    let v3131 : near_workspaces_result_ExecutionFinalResult = method39(v660)
    let v3132 : string = "v3131.receipt_failures()"
    let v3133 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v3132 
    let v3134 : string = "$0.len()"
    let v3135 : unativeint = Fable.Core.RustInterop.emitRustExpr v3133 v3134 
    let v3141 : int32 = v3135 |> int32 
    let v3460 : unit = ()
    let v3461 : (unit -> unit) = closure23(v3133, v3141)
    let v3462 : unit = (fun () -> v3461 (); v3460) ()
    let v3777 : near_workspaces_result_ExecutionFinalResult = method42(v660)
    let v3778 : string = "v3777.receipt_outcomes()"
    let v3779 : Ref<Slice<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v3778 
    let v3780 : string = "v3779.into()"
    let v3781 : Vec<near_workspaces_result_ExecutionOutcome> = Fable.Core.RustInterop.emitRustExpr () v3780 
    let v3782 : string = "$0.len()"
    let v3783 : unativeint = Fable.Core.RustInterop.emitRustExpr v3781 v3782 
    let v3789 : int32 = v3783 |> int32 
    let v4108 : unit = ()
    let v4109 : (unit -> unit) = closure24(v3781, v3789)
    let v4110 : unit = (fun () -> v4109 (); v4108) ()
    let v4425 : string = "$0.json()"
    let v4426 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v660 v4425 
    let v4738 : unit = ()
    let v4739 : (unit -> unit) = closure25(v4426)
    let v4740 : unit = (fun () -> v4739 (); v4738) ()
    let v5055 : string = "$0.borsh()"
    let v5056 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v660 v5055 
    let v5368 : unit = ()
    let v5369 : (unit -> unit) = closure26(v5056)
    let v5370 : unit = (fun () -> v5369 (); v5368) ()
    let v5685 : string = method49(v3789, v1, v3133)
    let v5686 : bool = v3141 > 0
    let v5720 : Result<US7, anyhow_Error> =
        if v5686 then
            let v5689 : US7 = US7_0(v5685)
            let v5690 : Result<US7, anyhow_Error> = Ok v5689 
            v5690
        else
            let v5694 : bool = v3789 > 1
            if v5694 then
                let v5697 : US7 = US7_1
                let v5698 : Result<US7, anyhow_Error> = Ok v5697 
                v5698
            else
                let v5702 : string = "anyhow::anyhow!($0)"
                let v5703 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v5685 v5702 
                (* run_target_args'
                let v5705 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5706 : string = "Err($0)"
                let v5707 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v5703 v5706 
                let _run_target_args'_v5705 = v5707 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5708 : string = "Err($0)"
                let v5709 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v5703 v5708 
                let _run_target_args'_v5705 = v5709 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5710 : string = "Err($0)"
                let v5711 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v5703 v5710 
                let _run_target_args'_v5705 = v5711 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5712 : Result<US7, anyhow_Error> = v5703 |> Error
                let _run_target_args'_v5705 = v5712 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5713 : Result<US7, anyhow_Error> = v5703 |> Error
                let _run_target_args'_v5705 = v5713 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5714 : Result<US7, anyhow_Error> = v5703 |> Error
                let _run_target_args'_v5705 = v5714 
                #endif
#else
                let v5715 : Result<US7, anyhow_Error> = v5703 |> Error
                let _run_target_args'_v5705 = v5715 
                #endif
                let v5716 : Result<US7, anyhow_Error> = _run_target_args'_v5705 
                v5716
    let v5721 : string = ""
    let v5722 : string = "}"
    let v5723 : string = v5721 + v5722 
    let x = v5720 //
    let v5724 : _ = x
    let v5725 : unit = ()
    (* run_target_args'
    let v5726 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5727 : string = $"true; let _fix_closure_v5725 = $0"
    let v5728 : bool = Fable.Core.RustInterop.emitRustExpr v5724 v5727 
    let _run_target_args'_v5726 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5729 : string = $"true; let _fix_closure_v5725 = $0"
    let v5730 : bool = Fable.Core.RustInterop.emitRustExpr v5724 v5729 
    let _run_target_args'_v5726 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5731 : string = $"true; let _fix_closure_v5725 = $0"
    let v5732 : bool = Fable.Core.RustInterop.emitRustExpr v5724 v5731 
    let _run_target_args'_v5726 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v5726 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v5726 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v5726 = false 
    #endif
#else
    let _run_target_args'_v5726 = false 
    #endif
    let v5733 : bool = _run_target_args'_v5726 
    let v5734 : string = $"true; _fix_closure_v5725 " + v5723 + "); " + v5721 + " // rust.fix_closure'"
    let v5735 : bool = Fable.Core.RustInterop.emitRustExpr () v5734 
    let v5736 : string = "__future_init"
    let v5737 : _ = Fable.Core.RustInterop.emitRustExpr () v5736 
    let v5738 : string = "v5737"
    let v5739 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v5738 
    v5739
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
and method50 () : (anyhow_Error -> std_string_String) =
    closure27()
and closure28 () (v0 : US7) : US10 =
    US10_0(v0)
and method51 () : (US7 -> US10) =
    closure28()
and closure29 () (v0 : std_string_String) : US10 =
    US10_1(v0)
and method52 () : (std_string_String -> US10) =
    closure29()
and method53 () : string =
    
    
    
    
    
    let v2 : string = "Warning"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method14(v7)
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v26 : string = "inline_colorization::color_yellow"
    let v27 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v26 
    (* run_target_args'
    let v32 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v33 : string = "&*$0"
    let v34 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v33 
    let _run_target_args'_v32 = v34 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v35 : string = "&*$0"
    let v36 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v35 
    let _run_target_args'_v32 = v36 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v37 : string = "&*$0"
    let v38 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v37 
    let _run_target_args'_v32 = v38 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v40 
    #endif
#if FABLE_COMPILER_PYTHON
    let v44 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v44 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v48 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v48 
    #endif
#else
    let v52 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v52 
    #endif
    let v55 : Ref<Str> = _run_target_args'_v32 
    let v64 : string = "inline_colorization::color_reset"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v64 
    let v66 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v67 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v27, v55, v65) v66 
    let v68 : string = "fable_library_rust::String_::fromString($0)"
    let v69 : string = Fable.Core.RustInterop.emitRustExpr v67 v68 
    let _run_target_args'_v25 = v69 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v70 : string = "inline_colorization::color_yellow"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v70 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "&*$0"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : Ref<Str> = _run_target_args'_v76 
    let v108 : string = "inline_colorization::color_reset"
    let v109 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v108 
    let v110 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v111 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v71, v99, v109) v110 
    let v112 : string = "fable_library_rust::String_::fromString($0)"
    let v113 : string = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let _run_target_args'_v25 = v113 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v114 : string = "inline_colorization::color_yellow"
    let v115 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v114 
    (* run_target_args'
    let v120 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v121 : string = "&*$0"
    let v122 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v121 
    let _run_target_args'_v120 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "&*$0"
    let v124 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v123 
    let _run_target_args'_v120 = v124 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v125 : string = "&*$0"
    let v126 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v125 
    let _run_target_args'_v120 = v126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v128 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v128 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v136 
    #endif
#else
    let v140 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v140 
    #endif
    let v143 : Ref<Str> = _run_target_args'_v120 
    let v152 : string = "inline_colorization::color_reset"
    let v153 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v152 
    let v154 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v115, v143, v153) v154 
    let v156 : string = "fable_library_rust::String_::fromString($0)"
    let v157 : string = Fable.Core.RustInterop.emitRustExpr v155 v156 
    let _run_target_args'_v25 = v157 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v159 : string = "\u001b[93m"
    let v163 : string = method16()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[93m"
    let v179 : string = method16()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[93m"
    let v195 : string = method16()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[93m"
    let v211 : string = method16()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method55 (v0 : uint8, v1 : std_string_String) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure8(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "retry"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure8(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure8(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v65 : string = $"{v0}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v3, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = "; "
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure8(v3, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v102 : string = "error"
    let v103 : string = $"{v102}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v3, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v120 : string = $"{v44}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure8(v3, v120)
    let v130 : unit = (fun () -> v129 (); v128) ()
    (* run_target_args'
    let v140 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v141 : string = "format!(\"{:#?}\", $0)"
    let v142 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v141 
    let v143 : string = "fable_library_rust::String_::fromString($0)"
    let v144 : string = Fable.Core.RustInterop.emitRustExpr v142 v143 
    let _run_target_args'_v140 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "format!(\"{:#?}\", $0)"
    let v146 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v145 
    let v147 : string = "fable_library_rust::String_::fromString($0)"
    let v148 : string = Fable.Core.RustInterop.emitRustExpr v146 v147 
    let _run_target_args'_v140 = v148 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v149 : string = "format!(\"{:#?}\", $0)"
    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v149 
    let v151 : string = "fable_library_rust::String_::fromString($0)"
    let v152 : string = Fable.Core.RustInterop.emitRustExpr v150 v151 
    let _run_target_args'_v140 = v152 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v154 : string = $"%A{v1}"
    let _run_target_args'_v140 = v154 
    #endif
#if FABLE_COMPILER_PYTHON
    let v158 : string = $"%A{v1}"
    let _run_target_args'_v140 = v158 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v162 : string = $"%A{v1}"
    let _run_target_args'_v140 = v162 
    #endif
#else
    let v166 : string = $"%A{v1}"
    let _run_target_args'_v140 = v166 
    #endif
    let v169 : string = _run_target_args'_v140 
    let v179 : string = $"{v169}"
    let v187 : unit = ()
    let v188 : (unit -> unit) = closure8(v3, v179)
    let v189 : unit = (fun () -> v188 (); v187) ()
    let v197 : string = " }"
    let v198 : string = $"{v197}"
    let v206 : unit = ()
    let v207 : (unit -> unit) = closure8(v3, v198)
    let v208 : unit = (fun () -> v207 (); v206) ()
    let v214 : string = v3.l0
    v214
and method54 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : std_string_String) : string =
    let v10 : string = method55(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v29 : (int64 -> string) = _.ToString()
    let v30 : string = v29 v11
    let v34 : string = v25 + v30 
    let v38 : string = v34 + v14 
    let v43 : string = "spiral_wasm.run / Error error"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method19(v54)
and closure30 (v0 : uint8, v1 : std_string_String) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US3 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 3 >= v62
            v63
    let v65 : bool = v64 = false
    let v299 : US8 =
        if v65 then
            US8_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method9(v105, v106, v107, v108, v109, v110)
            let v124 : string = method53()
            let v125 : string = method54(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
            let v140 : unit = ()
            let v141 : unit = (fun () -> v17 (); v140) ()
            let struct (v164 : Mut0, v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : int64 option) = TraceState.trace_state.Value
            let v184 : unit = ()
            let v185 : (unit -> unit) = closure9(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure10()
            (* run_target_args'
            let v190 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v191 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v192 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : string = v167.l0
            let v194 : bool = v193 = ""
            let v209 : string =
                if v194 then
                    v125
                else
                    let v195 : bool = v125 = ""
                    if v195 then
                        let v196 : string = v167.l0
                        v196
                    else
                        let v197 : string = v167.l0
                        let v200 : string = "\n"
                        let v201 : string = v197 + v200 
                        let v205 : string = v201 + v125 
                        v205
            (* run_target_args'
            let v214 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v215 
            let _run_target_args'_v214 = v216 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v217 
            let _run_target_args'_v214 = v218 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v219 
            let _run_target_args'_v214 = v220 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v226 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v226 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v230 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v230 
            #endif
#else
            let v234 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v234 
            #endif
            let v237 : Ref<Str> = _run_target_args'_v214 
            let v246 : string = $"$0.chars()"
            let v247 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v237 v246 
            let v248 : string = "$0"
            let v249 : _ = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.collect::<Vec<_>>()"
            let v251 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v253 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v255 : bool = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "x"
            let v257 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v256 
            let v258 : string = "String::from_iter($0)"
            let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "true; $0 }).collect::<Vec<_>>()"
            let v261 : bool = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "_vec_map"
            let v263 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v262 
            let v264 : string = "$0.len()"
            let v265 : unativeint = Fable.Core.RustInterop.emitRustExpr v263 v264 
            let v271 : int32 = v265 |> int32 
            let v281 : string = ""
            let v282 : bool = v125 <> v281 
            let v286 : bool =
                if v282 then
                    let v285 : bool = v271 <= 1
                    v285
                else
                    false
            if v286 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v281
                let v287 : string = "true; $0.into_iter().for_each(|x| { //"
                let v288 : bool = Fable.Core.RustInterop.emitRustExpr v263 v287 
                let v289 : string = "x"
                let v290 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v289 
                let v291 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr v290 v291 
                let v293 : string = $"true"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                let v295 : string = "true; }); //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v189 v125
            #endif
#if FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#else
            v189 v125
            #endif
            // run_target_args' is_unit
            let v297 : (string -> unit) = v165.l0
            v297 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and closure31 () () : unit =
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure6()
    let v16 : unit = (fun () -> v15 (); v14) ()
    let struct (v39 : Mut0, v40 : Mut1, v41 : Mut2, v42 : Mut3, v43 : Mut4, v44 : int64 option) = TraceState.trace_state.Value
    let v57 : US3 = v43.l0
    let v58 : bool = v41.l0
    let v59 : bool = v58 = false
    let v62 : bool =
        if v59 then
            false
        else
            let v60 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v57
            let v61 : bool = 3 >= v60
            v61
    let v63 : bool = v62 = false
    let v237 : US8 =
        if v63 then
            US8_1
        else
            let v79 : unit = ()
            let v80 : unit = (fun () -> v15 (); v79) ()
            let struct (v103 : Mut0, v104 : Mut1, v105 : Mut2, v106 : Mut3, v107 : Mut4, v108 : int64 option) = TraceState.trace_state.Value
            let v123 : unit = ()
            let v124 : (unit -> unit) = closure9(v103)
            let v125 : unit = (fun () -> v124 (); v123) ()
            let v128 : string = "\n"
            let v129 : (string -> unit) = closure10()
            (* run_target_args'
            let v130 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v131 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v128 v131 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v132 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v128 v132 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v133 : string = v106.l0
            let v134 : bool = v133 = ""
            let v147 : string =
                if v134 then
                    v128
                else
                    let v135 : bool = v128 = ""
                    if v135 then
                        let v136 : string = v106.l0
                        v136
                    else
                        let v137 : string = v106.l0
                        let v139 : string = v137 + v128 
                        let v143 : string = v139 + v128 
                        v143
            (* run_target_args'
            let v152 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v153 : string = "&*$0"
            let v154 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v153 
            let _run_target_args'_v152 = v154 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v155 : string = "&*$0"
            let v156 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v155 
            let _run_target_args'_v152 = v156 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v157 : string = "&*$0"
            let v158 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v157 
            let _run_target_args'_v152 = v158 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v160 : Ref<Str> = v147 |> unbox<Ref<Str>>
            let _run_target_args'_v152 = v160 
            #endif
#if FABLE_COMPILER_PYTHON
            let v164 : Ref<Str> = v147 |> unbox<Ref<Str>>
            let _run_target_args'_v152 = v164 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v168 : Ref<Str> = v147 |> unbox<Ref<Str>>
            let _run_target_args'_v152 = v168 
            #endif
#else
            let v172 : Ref<Str> = v147 |> unbox<Ref<Str>>
            let _run_target_args'_v152 = v172 
            #endif
            let v175 : Ref<Str> = _run_target_args'_v152 
            let v184 : string = $"$0.chars()"
            let v185 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v175 v184 
            let v186 : string = "$0"
            let v187 : _ = Fable.Core.RustInterop.emitRustExpr v185 v186 
            let v188 : string = "$0.collect::<Vec<_>>()"
            let v189 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v187 v188 
            let v190 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v191 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v189 v190 
            let v192 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v193 : bool = Fable.Core.RustInterop.emitRustExpr v191 v192 
            let v194 : string = "x"
            let v195 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v194 
            let v196 : string = "String::from_iter($0)"
            let v197 : std_string_String = Fable.Core.RustInterop.emitRustExpr v195 v196 
            let v198 : string = "true; $0 }).collect::<Vec<_>>()"
            let v199 : bool = Fable.Core.RustInterop.emitRustExpr v197 v198 
            let v200 : string = "_vec_map"
            let v201 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v200 
            let v202 : string = "$0.len()"
            let v203 : unativeint = Fable.Core.RustInterop.emitRustExpr v201 v202 
            let v209 : int32 = v203 |> int32 
            let v219 : string = ""
            let v220 : bool = v128 <> v219 
            let v224 : bool =
                if v220 then
                    let v223 : bool = v209 <= 1
                    v223
                else
                    false
            if v224 then
                v106.l0 <- v147
                ()
            else
                v106.l0 <- v219
                let v225 : string = "true; $0.into_iter().for_each(|x| { //"
                let v226 : bool = Fable.Core.RustInterop.emitRustExpr v201 v225 
                let v227 : string = "x"
                let v228 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v227 
                let v229 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v230 : bool = Fable.Core.RustInterop.emitRustExpr v228 v229 
                let v231 : string = $"true"
                let v232 : bool = Fable.Core.RustInterop.emitRustExpr () v231 
                let v233 : string = "true; }); //"
                let v234 : bool = Fable.Core.RustInterop.emitRustExpr () v233 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v129 v128
            #endif
#if FABLE_COMPILER_PYTHON
            v129 v128
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v129 v128
            #endif
#else
            v129 v128
            #endif
            // run_target_args' is_unit
            let v235 : (string -> unit) = v104.l0
            v235 v128
            US8_0(v103, v104, v105, v106, v107, v108)
    
    ()
and closure32 (v0 : uint8, v1 : std_string_String) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US3 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 3 >= v62
            v63
    let v65 : bool = v64 = false
    let v299 : US8 =
        if v65 then
            US8_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method9(v105, v106, v107, v108, v109, v110)
            let v124 : string = method53()
            let v125 : string = method54(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
            let v140 : unit = ()
            let v141 : unit = (fun () -> v17 (); v140) ()
            let struct (v164 : Mut0, v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : int64 option) = TraceState.trace_state.Value
            let v184 : unit = ()
            let v185 : (unit -> unit) = closure9(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure10()
            (* run_target_args'
            let v190 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v191 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v192 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : string = v167.l0
            let v194 : bool = v193 = ""
            let v209 : string =
                if v194 then
                    v125
                else
                    let v195 : bool = v125 = ""
                    if v195 then
                        let v196 : string = v167.l0
                        v196
                    else
                        let v197 : string = v167.l0
                        let v200 : string = "\n"
                        let v201 : string = v197 + v200 
                        let v205 : string = v201 + v125 
                        v205
            (* run_target_args'
            let v214 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v215 
            let _run_target_args'_v214 = v216 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v217 
            let _run_target_args'_v214 = v218 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v219 
            let _run_target_args'_v214 = v220 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v226 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v226 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v230 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v230 
            #endif
#else
            let v234 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v234 
            #endif
            let v237 : Ref<Str> = _run_target_args'_v214 
            let v246 : string = $"$0.chars()"
            let v247 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v237 v246 
            let v248 : string = "$0"
            let v249 : _ = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.collect::<Vec<_>>()"
            let v251 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v253 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v255 : bool = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "x"
            let v257 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v256 
            let v258 : string = "String::from_iter($0)"
            let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "true; $0 }).collect::<Vec<_>>()"
            let v261 : bool = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "_vec_map"
            let v263 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v262 
            let v264 : string = "$0.len()"
            let v265 : unativeint = Fable.Core.RustInterop.emitRustExpr v263 v264 
            let v271 : int32 = v265 |> int32 
            let v281 : string = ""
            let v282 : bool = v125 <> v281 
            let v286 : bool =
                if v282 then
                    let v285 : bool = v271 <= 1
                    v285
                else
                    false
            if v286 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v281
                let v287 : string = "true; $0.into_iter().for_each(|x| { //"
                let v288 : bool = Fable.Core.RustInterop.emitRustExpr v263 v287 
                let v289 : string = "x"
                let v290 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v289 
                let v291 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr v290 v291 
                let v293 : string = $"true"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                let v295 : string = "true; }); //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v189 v125
            #endif
#if FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#else
            v189 v125
            #endif
            // run_target_args' is_unit
            let v297 : (string -> unit) = v165.l0
            v297 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and closure33 () () : unit =
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure6()
    let v16 : unit = (fun () -> v15 (); v14) ()
    let struct (v39 : Mut0, v40 : Mut1, v41 : Mut2, v42 : Mut3, v43 : Mut4, v44 : int64 option) = TraceState.trace_state.Value
    let v57 : US3 = v43.l0
    let v58 : bool = v41.l0
    let v59 : bool = v58 = false
    let v62 : bool =
        if v59 then
            false
        else
            let v60 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v57
            let v61 : bool = 3 >= v60
            v61
    let v63 : bool = v62 = false
    let v237 : US8 =
        if v63 then
            US8_1
        else
            let v79 : unit = ()
            let v80 : unit = (fun () -> v15 (); v79) ()
            let struct (v103 : Mut0, v104 : Mut1, v105 : Mut2, v106 : Mut3, v107 : Mut4, v108 : int64 option) = TraceState.trace_state.Value
            let v123 : unit = ()
            let v124 : (unit -> unit) = closure9(v103)
            let v125 : unit = (fun () -> v124 (); v123) ()
            let v128 : string = "\n"
            let v129 : (string -> unit) = closure10()
            (* run_target_args'
            let v130 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v131 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v128 v131 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v132 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v128 v132 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v133 : string = v106.l0
            let v134 : bool = v133 = ""
            let v147 : string =
                if v134 then
                    v128
                else
                    let v135 : bool = v128 = ""
                    if v135 then
                        let v136 : string = v106.l0
                        v136
                    else
                        let v137 : string = v106.l0
                        let v139 : string = v137 + v128 
                        let v143 : string = v139 + v128 
                        v143
            (* run_target_args'
            let v152 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v153 : string = "&*$0"
            let v154 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v153 
            let _run_target_args'_v152 = v154 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v155 : string = "&*$0"
            let v156 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v155 
            let _run_target_args'_v152 = v156 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v157 : string = "&*$0"
            let v158 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v157 
            let _run_target_args'_v152 = v158 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v160 : Ref<Str> = v147 |> unbox<Ref<Str>>
            let _run_target_args'_v152 = v160 
            #endif
#if FABLE_COMPILER_PYTHON
            let v164 : Ref<Str> = v147 |> unbox<Ref<Str>>
            let _run_target_args'_v152 = v164 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v168 : Ref<Str> = v147 |> unbox<Ref<Str>>
            let _run_target_args'_v152 = v168 
            #endif
#else
            let v172 : Ref<Str> = v147 |> unbox<Ref<Str>>
            let _run_target_args'_v152 = v172 
            #endif
            let v175 : Ref<Str> = _run_target_args'_v152 
            let v184 : string = $"$0.chars()"
            let v185 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v175 v184 
            let v186 : string = "$0"
            let v187 : _ = Fable.Core.RustInterop.emitRustExpr v185 v186 
            let v188 : string = "$0.collect::<Vec<_>>()"
            let v189 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v187 v188 
            let v190 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v191 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v189 v190 
            let v192 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v193 : bool = Fable.Core.RustInterop.emitRustExpr v191 v192 
            let v194 : string = "x"
            let v195 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v194 
            let v196 : string = "String::from_iter($0)"
            let v197 : std_string_String = Fable.Core.RustInterop.emitRustExpr v195 v196 
            let v198 : string = "true; $0 }).collect::<Vec<_>>()"
            let v199 : bool = Fable.Core.RustInterop.emitRustExpr v197 v198 
            let v200 : string = "_vec_map"
            let v201 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v200 
            let v202 : string = "$0.len()"
            let v203 : unativeint = Fable.Core.RustInterop.emitRustExpr v201 v202 
            let v209 : int32 = v203 |> int32 
            let v219 : string = ""
            let v220 : bool = v128 <> v219 
            let v224 : bool =
                if v220 then
                    let v223 : bool = v209 <= 1
                    v223
                else
                    false
            if v224 then
                v106.l0 <- v147
                ()
            else
                v106.l0 <- v219
                let v225 : string = "true; $0.into_iter().for_each(|x| { //"
                let v226 : bool = Fable.Core.RustInterop.emitRustExpr v201 v225 
                let v227 : string = "x"
                let v228 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v227 
                let v229 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v230 : bool = Fable.Core.RustInterop.emitRustExpr v228 v229 
                let v231 : string = $"true"
                let v232 : bool = Fable.Core.RustInterop.emitRustExpr () v231 
                let v233 : string = "true; }); //"
                let v234 : bool = Fable.Core.RustInterop.emitRustExpr () v233 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v129 v128
            #endif
#if FABLE_COMPILER_PYTHON
            v129 v128
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v129 v128
            #endif
#else
            v129 v128
            #endif
            // run_target_args' is_unit
            let v235 : (string -> unit) = v104.l0
            v235 v128
            US8_0(v103, v104, v105, v106, v107, v108)
    
    ()
and method56 () : string =
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method14(v7)
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v26 : string = "inline_colorization::color_bright_red"
    let v27 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v26 
    (* run_target_args'
    let v32 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v33 : string = "&*$0"
    let v34 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v33 
    let _run_target_args'_v32 = v34 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v35 : string = "&*$0"
    let v36 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v35 
    let _run_target_args'_v32 = v36 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v37 : string = "&*$0"
    let v38 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v37 
    let _run_target_args'_v32 = v38 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v40 
    #endif
#if FABLE_COMPILER_PYTHON
    let v44 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v44 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v48 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v48 
    #endif
#else
    let v52 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v52 
    #endif
    let v55 : Ref<Str> = _run_target_args'_v32 
    let v64 : string = "inline_colorization::color_reset"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v64 
    let v66 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v67 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v27, v55, v65) v66 
    let v68 : string = "fable_library_rust::String_::fromString($0)"
    let v69 : string = Fable.Core.RustInterop.emitRustExpr v67 v68 
    let _run_target_args'_v25 = v69 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v70 : string = "inline_colorization::color_bright_red"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v70 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "&*$0"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : Ref<Str> = _run_target_args'_v76 
    let v108 : string = "inline_colorization::color_reset"
    let v109 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v108 
    let v110 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v111 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v71, v99, v109) v110 
    let v112 : string = "fable_library_rust::String_::fromString($0)"
    let v113 : string = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let _run_target_args'_v25 = v113 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v114 : string = "inline_colorization::color_bright_red"
    let v115 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v114 
    (* run_target_args'
    let v120 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v121 : string = "&*$0"
    let v122 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v121 
    let _run_target_args'_v120 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "&*$0"
    let v124 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v123 
    let _run_target_args'_v120 = v124 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v125 : string = "&*$0"
    let v126 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v125 
    let _run_target_args'_v120 = v126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v128 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v128 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v136 
    #endif
#else
    let v140 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v140 
    #endif
    let v143 : Ref<Str> = _run_target_args'_v120 
    let v152 : string = "inline_colorization::color_reset"
    let v153 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v152 
    let v154 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v115, v143, v153) v154 
    let v156 : string = "fable_library_rust::String_::fromString($0)"
    let v157 : string = Fable.Core.RustInterop.emitRustExpr v155 v156 
    let _run_target_args'_v25 = v157 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v159 : string = "\u001b[91m"
    let v163 : string = method16()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[91m"
    let v179 : string = method16()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[91m"
    let v195 : string = method16()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[91m"
    let v211 : string = method16()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method58 (v0 : uint8, v1 : string) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure8(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "retry"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure8(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure8(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v65 : string = $"{v0}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v3, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = "; "
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure8(v3, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v102 : string = "error"
    let v103 : string = $"{v102}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v3, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v120 : string = $"{v44}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure8(v3, v120)
    let v130 : unit = (fun () -> v129 (); v128) ()
    let v137 : string = $"{v1}"
    let v145 : unit = ()
    let v146 : (unit -> unit) = closure8(v3, v137)
    let v147 : unit = (fun () -> v146 (); v145) ()
    let v155 : string = " }"
    let v156 : string = $"{v155}"
    let v164 : unit = ()
    let v165 : (unit -> unit) = closure8(v3, v156)
    let v166 : unit = (fun () -> v165 (); v164) ()
    let v172 : string = v3.l0
    v172
and method57 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : string) : string =
    let v10 : string = method58(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v29 : (int64 -> string) = _.ToString()
    let v30 : string = v29 v11
    let v34 : string = v25 + v30 
    let v38 : string = v34 + v14 
    let v43 : string = "spiral_wasm.run / Ok (Some error)"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method19(v54)
and closure34 (v0 : uint8, v1 : string) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US3 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 4 >= v62
            v63
    let v65 : bool = v64 = false
    let v299 : US8 =
        if v65 then
            US8_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method9(v105, v106, v107, v108, v109, v110)
            let v124 : string = method56()
            let v125 : string = method57(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
            let v140 : unit = ()
            let v141 : unit = (fun () -> v17 (); v140) ()
            let struct (v164 : Mut0, v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : int64 option) = TraceState.trace_state.Value
            let v184 : unit = ()
            let v185 : (unit -> unit) = closure9(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure10()
            (* run_target_args'
            let v190 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v191 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v192 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : string = v167.l0
            let v194 : bool = v193 = ""
            let v209 : string =
                if v194 then
                    v125
                else
                    let v195 : bool = v125 = ""
                    if v195 then
                        let v196 : string = v167.l0
                        v196
                    else
                        let v197 : string = v167.l0
                        let v200 : string = "\n"
                        let v201 : string = v197 + v200 
                        let v205 : string = v201 + v125 
                        v205
            (* run_target_args'
            let v214 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v215 
            let _run_target_args'_v214 = v216 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v217 
            let _run_target_args'_v214 = v218 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v219 
            let _run_target_args'_v214 = v220 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v226 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v226 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v230 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v230 
            #endif
#else
            let v234 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v234 
            #endif
            let v237 : Ref<Str> = _run_target_args'_v214 
            let v246 : string = $"$0.chars()"
            let v247 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v237 v246 
            let v248 : string = "$0"
            let v249 : _ = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.collect::<Vec<_>>()"
            let v251 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v253 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v255 : bool = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "x"
            let v257 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v256 
            let v258 : string = "String::from_iter($0)"
            let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "true; $0 }).collect::<Vec<_>>()"
            let v261 : bool = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "_vec_map"
            let v263 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v262 
            let v264 : string = "$0.len()"
            let v265 : unativeint = Fable.Core.RustInterop.emitRustExpr v263 v264 
            let v271 : int32 = v265 |> int32 
            let v281 : string = ""
            let v282 : bool = v125 <> v281 
            let v286 : bool =
                if v282 then
                    let v285 : bool = v271 <= 1
                    v285
                else
                    false
            if v286 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v281
                let v287 : string = "true; $0.into_iter().for_each(|x| { //"
                let v288 : bool = Fable.Core.RustInterop.emitRustExpr v263 v287 
                let v289 : string = "x"
                let v290 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v289 
                let v291 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr v290 v291 
                let v293 : string = $"true"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                let v295 : string = "true; }); //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v189 v125
            #endif
#if FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#else
            v189 v125
            #endif
            // run_target_args' is_unit
            let v297 : (string -> unit) = v165.l0
            v297 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and method26 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<US9>>>> =
    let v2 : string = "true; let __future_init = Box::pin(/*"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let v4 : string = "*/ async move { /*"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let v6 : string = "*/ ()"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let v8 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = method27(v0, v1)
    let v9 : string = "v8.await"
    let v10 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr () v9 
    let v11 : (anyhow_Error -> std_string_String) = method50()
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
    let v27 : (US7 -> US10) = method51()
    let v28 : (std_string_String -> US10) = method52()
    let v30 : US10 = match v24 with Ok x -> v27 x | Error x -> v28 x
    let v3037 : US9 =
        match v30 with
        | US10_1(v725) -> (* Error *)
            let v726 : bool = v1 >= 15uy
            if v726 then
                let v1038 : unit = ()
                let v1039 : (unit -> unit) = closure30(v1, v725)
                let v1040 : unit = (fun () -> v1039 (); v1038) ()
                let v1607 : unit = ()
                let v1608 : (unit -> unit) = closure31()
                let v1609 : unit = (fun () -> v1608 (); v1607) ()
                let v1864 : string = "true; let __future_init = Box::pin(/*"
                let v1865 : bool = Fable.Core.RustInterop.emitRustExpr () v1864 
                let v1866 : string = "*/ async move { /*"
                let v1867 : bool = Fable.Core.RustInterop.emitRustExpr () v1866 
                let v1868 : string = "*/ ()"
                let v1869 : bool = Fable.Core.RustInterop.emitRustExpr () v1868 
                let v1870 : string = ""
                let v1871 : string = "}"
                let v1872 : string = v1870 + v1871 
                let v1873 : US7 = US7_1
                let x = struct (v1, v1873) //
                let v1874 : _ = x
                let v1875 : unit = ()
                (* run_target_args'
                let v1876 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1877 : string = $"true; let _fix_closure_v1875 = $0"
                let v1878 : bool = Fable.Core.RustInterop.emitRustExpr v1874 v1877 
                let _run_target_args'_v1876 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1879 : string = $"true; let _fix_closure_v1875 = $0"
                let v1880 : bool = Fable.Core.RustInterop.emitRustExpr v1874 v1879 
                let _run_target_args'_v1876 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1881 : string = $"true; let _fix_closure_v1875 = $0"
                let v1882 : bool = Fable.Core.RustInterop.emitRustExpr v1874 v1881 
                let _run_target_args'_v1876 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v1876 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v1876 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v1876 = false 
                #endif
#else
                let _run_target_args'_v1876 = false 
                #endif
                let v1883 : bool = _run_target_args'_v1876 
                let v1884 : string = $"true; _fix_closure_v1875 " + v1872 + "); " + v1870 + " // rust.fix_closure'"
                let v1885 : bool = Fable.Core.RustInterop.emitRustExpr () v1884 
                let v1886 : string = "__future_init"
                let v1887 : _ = Fable.Core.RustInterop.emitRustExpr () v1886 
                let v1888 : string = "v1887"
                let v1889 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v1888 
                let v1890 : string = "v1889.await"
                let struct (v1891 : uint8, v1892 : US7) = Fable.Core.RustInterop.emitRustExpr () v1890 
                US9_0(v1891, v1892)
            else
                let v2205 : unit = ()
                let v2206 : (unit -> unit) = closure32(v1, v725)
                let v2207 : unit = (fun () -> v2206 (); v2205) ()
                let v2774 : unit = ()
                let v2775 : (unit -> unit) = closure33()
                let v2776 : unit = (fun () -> v2775 (); v2774) ()
                let v3031 : uint8 = v1 + 1uy
                let v3032 : std_pin_Pin<Box<Dyn<std_future_Future<US9>>>> = method26(v0, v3031)
                let v3033 : string = "v3032.await"
                let v3034 : US9 = Fable.Core.RustInterop.emitRustExpr () v3033 
                v3034
        | US10_0(v33) -> (* Ok *)
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
                US9_0(v61, v62)
            | US7_0(v64) -> (* Some *)
                let v376 : unit = ()
                let v377 : (unit -> unit) = closure34(v1, v64)
                let v378 : unit = (fun () -> v377 (); v376) ()
                let v693 : string = "true; let __future_init = Box::pin(/*"
                let v694 : bool = Fable.Core.RustInterop.emitRustExpr () v693 
                let v695 : string = "*/ async move { /*"
                let v696 : bool = Fable.Core.RustInterop.emitRustExpr () v695 
                let v697 : string = "*/ ()"
                let v698 : bool = Fable.Core.RustInterop.emitRustExpr () v697 
                let v699 : string = ""
                let v700 : string = "}"
                let v701 : string = v699 + v700 
                let v702 : US7 = US7_0(v64)
                let x = struct (v1, v702) //
                let v703 : _ = x
                let v704 : unit = ()
                (* run_target_args'
                let v705 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v706 : string = $"true; let _fix_closure_v704 = $0"
                let v707 : bool = Fable.Core.RustInterop.emitRustExpr v703 v706 
                let _run_target_args'_v705 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v708 : string = $"true; let _fix_closure_v704 = $0"
                let v709 : bool = Fable.Core.RustInterop.emitRustExpr v703 v708 
                let _run_target_args'_v705 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v710 : string = $"true; let _fix_closure_v704 = $0"
                let v711 : bool = Fable.Core.RustInterop.emitRustExpr v703 v710 
                let _run_target_args'_v705 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v705 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v705 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v705 = false 
                #endif
#else
                let _run_target_args'_v705 = false 
                #endif
                let v712 : bool = _run_target_args'_v705 
                let v713 : string = $"true; _fix_closure_v704 " + v701 + "); " + v699 + " // rust.fix_closure'"
                let v714 : bool = Fable.Core.RustInterop.emitRustExpr () v713 
                let v715 : string = "__future_init"
                let v716 : _ = Fable.Core.RustInterop.emitRustExpr () v715 
                let v717 : string = "v716"
                let v718 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v717 
                let v719 : string = "v718.await"
                let struct (v720 : uint8, v721 : US7) = Fable.Core.RustInterop.emitRustExpr () v719 
                US9_1(v720, v721)
    let v3038 : string = ""
    let v3039 : string = "}"
    let v3040 : string = v3038 + v3039 
    let x = v3037 //
    let v3041 : _ = x
    let v3042 : unit = ()
    (* run_target_args'
    let v3043 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3044 : string = $"true; let _fix_closure_v3042 = $0"
    let v3045 : bool = Fable.Core.RustInterop.emitRustExpr v3041 v3044 
    let _run_target_args'_v3043 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3046 : string = $"true; let _fix_closure_v3042 = $0"
    let v3047 : bool = Fable.Core.RustInterop.emitRustExpr v3041 v3046 
    let _run_target_args'_v3043 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3048 : string = $"true; let _fix_closure_v3042 = $0"
    let v3049 : bool = Fable.Core.RustInterop.emitRustExpr v3041 v3048 
    let _run_target_args'_v3043 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v3043 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v3043 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v3043 = false 
    #endif
#else
    let _run_target_args'_v3043 = false 
    #endif
    let v3050 : bool = _run_target_args'_v3043 
    let v3051 : string = $"true; _fix_closure_v3042 " + v3040 + "); " + v3038 + " // rust.fix_closure'"
    let v3052 : bool = Fable.Core.RustInterop.emitRustExpr () v3051 
    let v3053 : string = "__future_init"
    let v3054 : _ = Fable.Core.RustInterop.emitRustExpr () v3053 
    let v3055 : string = "v3054"
    let v3056 : std_pin_Pin<Box<Dyn<std_future_Future<US9>>>> = Fable.Core.RustInterop.emitRustExpr () v3055 
    v3056
and method60 (v0 : US9) : string =
    let v1 : string = method15()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure8(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "retries"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure8(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v61 : string = $"%A{v0}"
    let v65 : string = $"{v61}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v2, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = " }"
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure8(v2, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v100 : string = v2.l0
    v100
and method59 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : US9) : string =
    let v9 : string = method60(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v28 : (int64 -> string) = _.ToString()
    let v29 : string = v28 v10
    let v33 : string = v24 + v29 
    let v37 : string = v33 + v13 
    let v42 : string = "spiral_wasm.run"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method19(v53)
and closure35 (v0 : US9) () : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
    let v58 : US3 = v44.l0
    let v59 : bool = v42.l0
    let v60 : bool = v59 = false
    let v63 : bool =
        if v60 then
            false
        else
            let v61 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v58
            let v62 : bool = 0 >= v61
            v62
    let v64 : bool = v63 = false
    let v298 : US8 =
        if v64 then
            US8_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method9(v104, v105, v106, v107, v108, v109)
            let v123 : string = method13()
            let v124 : string = method59(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v139 : unit = ()
            let v140 : unit = (fun () -> v16 (); v139) ()
            let struct (v163 : Mut0, v164 : Mut1, v165 : Mut2, v166 : Mut3, v167 : Mut4, v168 : int64 option) = TraceState.trace_state.Value
            let v183 : unit = ()
            let v184 : (unit -> unit) = closure9(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure10()
            (* run_target_args'
            let v189 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v190 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v190 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v124 v191 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v192 : string = v166.l0
            let v193 : bool = v192 = ""
            let v208 : string =
                if v193 then
                    v124
                else
                    let v194 : bool = v124 = ""
                    if v194 then
                        let v195 : string = v166.l0
                        v195
                    else
                        let v196 : string = v166.l0
                        let v199 : string = "\n"
                        let v200 : string = v196 + v199 
                        let v204 : string = v200 + v124 
                        v204
            (* run_target_args'
            let v213 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v214 : string = "&*$0"
            let v215 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v214 
            let _run_target_args'_v213 = v215 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v216 : string = "&*$0"
            let v217 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v216 
            let _run_target_args'_v213 = v217 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v208 v218 
            let _run_target_args'_v213 = v219 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v221 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v221 
            #endif
#if FABLE_COMPILER_PYTHON
            let v225 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v225 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v229 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v229 
            #endif
#else
            let v233 : Ref<Str> = v208 |> unbox<Ref<Str>>
            let _run_target_args'_v213 = v233 
            #endif
            let v236 : Ref<Str> = _run_target_args'_v213 
            let v245 : string = $"$0.chars()"
            let v246 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v236 v245 
            let v247 : string = "$0"
            let v248 : _ = Fable.Core.RustInterop.emitRustExpr v246 v247 
            let v249 : string = "$0.collect::<Vec<_>>()"
            let v250 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v248 v249 
            let v251 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v252 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v254 : bool = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "x"
            let v256 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v255 
            let v257 : string = "String::from_iter($0)"
            let v258 : std_string_String = Fable.Core.RustInterop.emitRustExpr v256 v257 
            let v259 : string = "true; $0 }).collect::<Vec<_>>()"
            let v260 : bool = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "_vec_map"
            let v262 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v261 
            let v263 : string = "$0.len()"
            let v264 : unativeint = Fable.Core.RustInterop.emitRustExpr v262 v263 
            let v270 : int32 = v264 |> int32 
            let v280 : string = ""
            let v281 : bool = v124 <> v280 
            let v285 : bool =
                if v281 then
                    let v284 : bool = v270 <= 1
                    v284
                else
                    false
            if v285 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v280
                let v286 : string = "true; $0.into_iter().for_each(|x| { //"
                let v287 : bool = Fable.Core.RustInterop.emitRustExpr v262 v286 
                let v288 : string = "x"
                let v289 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v288 
                let v290 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v291 : bool = Fable.Core.RustInterop.emitRustExpr v289 v290 
                let v292 : string = $"true"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr () v292 
                let v294 : string = "true; }); //"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v188 v124
            #endif
#if FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v188 v124
            #endif
#else
            v188 v124
            #endif
            // run_target_args' is_unit
            let v296 : (string -> unit) = v164.l0
            v296 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method61 (v0 : US9, v1 : US7) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure8(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "retries"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure8(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure8(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v62 : string = $"%A{v0}"
    let v66 : string = $"{v62}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure8(v3, v66)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v84 : string = "; "
    let v85 : string = $"{v84}"
    let v93 : unit = ()
    let v94 : (unit -> unit) = closure8(v3, v85)
    let v95 : unit = (fun () -> v94 (); v93) ()
    let v103 : string = "error"
    let v104 : string = $"{v103}"
    let v112 : unit = ()
    let v113 : (unit -> unit) = closure8(v3, v104)
    let v114 : unit = (fun () -> v113 (); v112) ()
    let v121 : string = $"{v44}"
    let v129 : unit = ()
    let v130 : (unit -> unit) = closure8(v3, v121)
    let v131 : unit = (fun () -> v130 (); v129) ()
    let v138 : string = $"%A{v1}"
    let v142 : string = $"{v138}"
    let v150 : unit = ()
    let v151 : (unit -> unit) = closure8(v3, v142)
    let v152 : unit = (fun () -> v151 (); v150) ()
    let v160 : string = " }"
    let v161 : string = $"{v160}"
    let v169 : unit = ()
    let v170 : (unit -> unit) = closure8(v3, v161)
    let v171 : unit = (fun () -> v170 (); v169) ()
    let v177 : string = v3.l0
    v177
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
    let v391 : unit = ()
    let v392 : (unit -> unit) = closure13(v79)
    let v393 : unit = (fun () -> v392 (); v391) ()
    let v708 : string = "std::fs::read(&*$0)"
    let v709 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v79 v708 
    let v710 : string = "$0?"
    let v711 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v709 v710 
    let v712 : uint8 = 1uy
    let v713 : std_pin_Pin<Box<Dyn<std_future_Future<US9>>>> = method26(v711, v712)
    let v714 : string = "v713.await"
    let v715 : US9 = Fable.Core.RustInterop.emitRustExpr () v714 
    let v1027 : unit = ()
    let v1028 : (unit -> unit) = closure35(v715)
    let v1029 : unit = (fun () -> v1028 (); v1027) ()
    let v1371 : Result<uint8, anyhow_Error> =
        match v715 with
        | US9_1(v1350, v1351) -> (* Error *)
            let v1352 : string = method61(v715, v1351)
            let v1353 : string = "anyhow::anyhow!($0)"
            let v1354 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v1352 v1353 
            (* run_target_args'
            let v1356 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1357 : string = "Err($0)"
            let v1358 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1354 v1357 
            let _run_target_args'_v1356 = v1358 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1359 : string = "Err($0)"
            let v1360 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1354 v1359 
            let _run_target_args'_v1356 = v1360 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1361 : string = "Err($0)"
            let v1362 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1354 v1361 
            let _run_target_args'_v1356 = v1362 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1363 : Result<uint8, anyhow_Error> = v1354 |> Error
            let _run_target_args'_v1356 = v1363 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1364 : Result<uint8, anyhow_Error> = v1354 |> Error
            let _run_target_args'_v1356 = v1364 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1365 : Result<uint8, anyhow_Error> = v1354 |> Error
            let _run_target_args'_v1356 = v1365 
            #endif
#else
            let v1366 : Result<uint8, anyhow_Error> = v1354 |> Error
            let _run_target_args'_v1356 = v1366 
            #endif
            let v1367 : Result<uint8, anyhow_Error> = _run_target_args'_v1356 
            v1367
        | US9_0(v1344, v1345) -> (* Ok *)
            let v1347 : Result<uint8, anyhow_Error> = Ok v1344 
            v1347
    let v1372 : string = ""
    let v1373 : string = "}"
    let v1374 : string = v1372 + v1373 
    let x = v1371 //
    let v1375 : _ = x
    let v1376 : unit = ()
    (* run_target_args'
    let v1377 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1378 : string = $"true; let _fix_closure_v1376 = $0"
    let v1379 : bool = Fable.Core.RustInterop.emitRustExpr v1375 v1378 
    let _run_target_args'_v1377 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1380 : string = $"true; let _fix_closure_v1376 = $0"
    let v1381 : bool = Fable.Core.RustInterop.emitRustExpr v1375 v1380 
    let _run_target_args'_v1377 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1382 : string = $"true; let _fix_closure_v1376 = $0"
    let v1383 : bool = Fable.Core.RustInterop.emitRustExpr v1375 v1382 
    let _run_target_args'_v1377 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v1377 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v1377 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v1377 = false 
    #endif
#else
    let _run_target_args'_v1377 = false 
    #endif
    let v1384 : bool = _run_target_args'_v1377 
    let v1385 : string = $"true; _fix_closure_v1376 " + v1374 + "); " + v1372 + " // rust.fix_closure'"
    let v1386 : bool = Fable.Core.RustInterop.emitRustExpr () v1385 
    let v1387 : string = "__future_init"
    let v1388 : _ = Fable.Core.RustInterop.emitRustExpr () v1387 
    let v1389 : string = "v1388"
    let v1390 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v1389 
    v1390
and closure36 () (v0 : uint8) : US11 =
    US11_0(v0)
and method62 () : (uint8 -> US11) =
    closure36()
and closure37 () (v0 : std_string_String) : US11 =
    US11_1(v0)
and method63 () : (std_string_String -> US11) =
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
    let struct (v249 : Mut0, v250 : Mut1, v251 : Mut2, v252 : Mut3, v253 : Mut4, v254 : int64 option) = TraceState.trace_state.Value
    let v578 : unit = ()
    let v579 : (unit -> unit) = closure5(v0)
    let v580 : unit = (fun () -> v579 (); v578) ()
    let v895 : string = method20()
    (* run_target_args'
    let v900 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v901 : string = "&*$0"
    let v902 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v895 v901 
    let _run_target_args'_v900 = v902 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v903 : string = "&*$0"
    let v904 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v895 v903 
    let _run_target_args'_v900 = v904 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v905 : string = "&*$0"
    let v906 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v895 v905 
    let _run_target_args'_v900 = v906 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v908 : Ref<Str> = v895 |> unbox<Ref<Str>>
    let _run_target_args'_v900 = v908 
    #endif
#if FABLE_COMPILER_PYTHON
    let v912 : Ref<Str> = v895 |> unbox<Ref<Str>>
    let _run_target_args'_v900 = v912 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v916 : Ref<Str> = v895 |> unbox<Ref<Str>>
    let _run_target_args'_v900 = v916 
    #endif
#else
    let v920 : Ref<Str> = v895 |> unbox<Ref<Str>>
    let _run_target_args'_v900 = v920 
    #endif
    let v923 : Ref<Str> = _run_target_args'_v900 
    let v932 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v933 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v923) v932 
    let v936 : (std_string_String -> string) = method21()
    let v937 : string option = v933 |> Option.map v936 
    let v1044 : (string -> US7) = method8()
    let v1045 : US7 option = v937 |> Option.map v1044 
    let v1065 : US7 = US7_1
    let v1066 : US7 = v1045 |> Option.defaultValue v1065 
    let v1070 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method22(v3)
    let v1071 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v1072 : _ = Fable.Core.RustInterop.emitRustExpr () v1071 
    let v1073 : string = "v1072.handle().block_on($0)"
    let v1074 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1070 v1073 
    let v1075 : (anyhow_Error -> std_string_String) = method50()
    (* run_target_args'
    let v1077 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1078 : string = "$0.map_err(|x| $1(x))"
    let v1079 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v1074, v1075) v1078 
    let _run_target_args'_v1077 = v1079 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1080 : string = "$0.map_err(|x| $1(x))"
    let v1081 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v1074, v1075) v1080 
    let _run_target_args'_v1077 = v1081 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1082 : string = "$0.map_err(|x| $1(x))"
    let v1083 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v1074, v1075) v1082 
    let _run_target_args'_v1077 = v1083 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1084 : Result<uint8, std_string_String> = match v1074 with Ok x -> Ok x | Error x -> Error (v1075 x)
    let _run_target_args'_v1077 = v1084 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1085 : Result<uint8, std_string_String> = match v1074 with Ok x -> Ok x | Error x -> Error (v1075 x)
    let _run_target_args'_v1077 = v1085 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1086 : Result<uint8, std_string_String> = match v1074 with Ok x -> Ok x | Error x -> Error (v1075 x)
    let _run_target_args'_v1077 = v1086 
    #endif
#else
    let v1087 : Result<uint8, std_string_String> = match v1074 with Ok x -> Ok x | Error x -> Error (v1075 x)
    let _run_target_args'_v1077 = v1087 
    #endif
    let v1088 : Result<uint8, std_string_String> = _run_target_args'_v1077 
    let v1091 : (uint8 -> US11) = method62()
    let v1092 : (std_string_String -> US11) = method63()
    let v1094 : US11 = match v1088 with Ok x -> v1091 x | Error x -> v1092 x
    match v1094 with
    | US11_1(v1119) -> (* Error *)
        match v1066 with
        | US7_0(v1120) -> (* Some *)
            let v1121 : bool = "" = v1120
            if v1121 then
                ()
            else
                let v1122 : string = "fable_library_rust::String_::fromString($0)"
                let v1123 : string = Fable.Core.RustInterop.emitRustExpr v1119 v1122 
                let v1125 : bool = v1123.Contains v1120 
                if v1125 then
                    ()
                else
                    let v1128 : string = $"spiral_wasm.main / exception: '{v1120}' / error: {v1119}"
                    (* run_target_args'
                    let v1130 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v1131 : string = "Err($0)"
                    let v1132 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1128 v1131 
                    let _run_target_args'_v1130 = v1132 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v1133 : string = "Err($0)"
                    let v1134 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1128 v1133 
                    let _run_target_args'_v1130 = v1134 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v1135 : string = "Err($0)"
                    let v1136 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1128 v1135 
                    let _run_target_args'_v1130 = v1136 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v1137 : Result<unit, string> = v1128 |> Error
                    let _run_target_args'_v1130 = v1137 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v1138 : Result<unit, string> = v1128 |> Error
                    let _run_target_args'_v1130 = v1138 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v1139 : Result<unit, string> = v1128 |> Error
                    let _run_target_args'_v1130 = v1139 
                    #endif
#else
                    let v1140 : Result<unit, string> = v1128 |> Error
                    let _run_target_args'_v1130 = v1140 
                    #endif
                    let v1141 : Result<unit, string> = _run_target_args'_v1130 
                    (* run_target_args'
                    let v1144 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v1145 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v1141 v1145 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v1146 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v1141 v1146 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v1147 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v1141 v1147 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    match v1141 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if FABLE_COMPILER_PYTHON
                    match v1141 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    match v1141 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#else
                    match v1141 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
                    // run_target_args' is_unit
                    ()
        | _ ->
            (* run_target_args'
            let v1149 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1150 : string = "$0.unwrap()"
            let v1151 : uint8 = Fable.Core.RustInterop.emitRustExpr v1088 v1150 
            let _run_target_args'_v1149 = v1151 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1152 : string = "$0.unwrap()"
            let v1153 : uint8 = Fable.Core.RustInterop.emitRustExpr v1088 v1152 
            let _run_target_args'_v1149 = v1153 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1154 : string = "$0.unwrap()"
            let v1155 : uint8 = Fable.Core.RustInterop.emitRustExpr v1088 v1154 
            let _run_target_args'_v1149 = v1155 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1156 : uint8 = match v1088 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v1149 = v1156 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1157 : uint8 = match v1088 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v1149 = v1157 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1158 : uint8 = match v1088 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v1149 = v1158 
            #endif
#else
            let v1159 : uint8 = match v1088 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v1149 = v1159 
            #endif
            let v1160 : uint8 = _run_target_args'_v1149 
            ()
    | US11_0(v1097) -> (* Ok *)
        match v1066 with
        | US7_0(v1098) -> (* Some *)
            let v1099 : string = $"spiral_wasm.main / retries: {v1097} / exception: '{v1098}'"
            (* run_target_args'
            let v1101 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1102 : string = "Err($0)"
            let v1103 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1099 v1102 
            let _run_target_args'_v1101 = v1103 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1104 : string = "Err($0)"
            let v1105 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1099 v1104 
            let _run_target_args'_v1101 = v1105 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1106 : string = "Err($0)"
            let v1107 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1099 v1106 
            let _run_target_args'_v1101 = v1107 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1108 : Result<unit, string> = v1099 |> Error
            let _run_target_args'_v1101 = v1108 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1109 : Result<unit, string> = v1099 |> Error
            let _run_target_args'_v1101 = v1109 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1110 : Result<unit, string> = v1099 |> Error
            let _run_target_args'_v1101 = v1110 
            #endif
#else
            let v1111 : Result<unit, string> = v1099 |> Error
            let _run_target_args'_v1101 = v1111 
            #endif
            let v1112 : Result<unit, string> = _run_target_args'_v1101 
            (* run_target_args'
            let v1115 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1116 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v1112 v1116 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1117 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v1112 v1117 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1118 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v1112 v1118 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            match v1112 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if FABLE_COMPILER_PYTHON
            match v1112 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            match v1112 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#else
            match v1112 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
            // run_target_args' is_unit
            ()
        | _ ->
            ()
    0
let v0 : ((string []) -> int32) = closure0()
let main args = v0 args
()
