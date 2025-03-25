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

module TraceState = let mutable trace_state = None
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::env::VarError")>]
#endif
type std_env_VarError = class end
type IOsEnviron = abstract environ: x: unit -> obj
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
    let v166 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v167 : string = "String::from($0)"
    let v168 : std_string_String = Fable.Core.RustInterop.emitRustExpr v156 v167 
    let _run_target_args'_v166 = v168 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v169 : string = "String::from($0)"
    let v170 : std_string_String = Fable.Core.RustInterop.emitRustExpr v156 v169 
    let _run_target_args'_v166 = v170 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v171 : string = "String::from($0)"
    let v172 : std_string_String = Fable.Core.RustInterop.emitRustExpr v156 v171 
    let _run_target_args'_v166 = v172 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v174 : std_string_String = v156 |> unbox<std_string_String>
    let _run_target_args'_v166 = v174 
    #endif
#if FABLE_COMPILER_PYTHON
    let v178 : std_string_String = v156 |> unbox<std_string_String>
    let _run_target_args'_v166 = v178 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v182 : std_string_String = v156 |> unbox<std_string_String>
    let _run_target_args'_v166 = v182 
    #endif
#else
    let v186 : std_string_String = v156 |> unbox<std_string_String>
    let _run_target_args'_v166 = v186 
    #endif
    let v189 : std_string_String = _run_target_args'_v166 
    let v195 : string = "Box::new($0)"
    let v196 : Box<std_string_String> = Fable.Core.RustInterop.emitRustExpr v189 v195 
    let v197 : string = "Box::leak($0)"
    let v198 : Ref<Lifetime<StaticLifetime, Mut<std_string_String>>> = Fable.Core.RustInterop.emitRustExpr v196 v197 
    let v199 : string = "clap::builder::PossibleValue::new(&**$0)"
    let v200 : clap_builder_PossibleValue = Fable.Core.RustInterop.emitRustExpr v198 v199 
    let v201 : string = "true; $0 }).collect::<Vec<_>>()"
    let v202 : bool = Fable.Core.RustInterop.emitRustExpr v200 v201 
    let v203 : string = "_vec_map"
    let v204 : Vec<clap_builder_PossibleValue> = Fable.Core.RustInterop.emitRustExpr () v203 
    let v205 : string = "Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new($0))"
    let v206 : clap_builder_ValueParser = Fable.Core.RustInterop.emitRustExpr v204 v205 
    let v207 : string = "$0.value_parser($1)"
    let v208 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v61, v206) v207 
    let v209 : string = "clap::Command::arg($0, $1)"
    let v210 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v50, v208) v209 
    let v211 : string = "wasm"
    let v212 : string = "r#\"" + v211 + "\"#"
    let v213 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v212 
    let v214 : string = "clap::Arg::new($0)"
    let v215 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v213 v214 
    let v216 : string = "$0.short($1)"
    let v217 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v215, 'w') v216 
    let v218 : string = "r#\"" + v211 + "\"#"
    let v219 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v218 
    let v220 : string = "$0.long($1)"
    let v221 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v217, v219) v220 
    let v222 : string = "$0.required($1)"
    let v223 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v221, true) v222 
    let v224 : string = "clap::Command::arg($0, $1)"
    let v225 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v210, v223) v224 
    v225
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
    let v20 : US6 = US6_3(v19)
    let v21 : string = $"env.get_environment_variable / target: {v20} / var: {v0}"
    let v22 : string = failwith<string> v21
    let _run_target_args'_v2 = v22 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v23 : US5 = US5_2
    let v24 : US6 = US6_3(v23)
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
    let v209 : US4 =
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
            let v203 : int64 = v182 |> int64 
            US4_0(v203)
    struct (v127, v209)
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
    let v49 : string = "fable_library_rust::String_::fromString($0)"
    let v50 : string = Fable.Core.RustInterop.emitRustExpr v43 v49 
    let _run_target_args'_v13 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v51 : string = "option_env!(\"" + v8 + "\").unwrap_or(\"\")"
    let v52 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v51 
    (* run_target_args'
    let v57 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v58 : string = "String::from($0)"
    let v59 : std_string_String = Fable.Core.RustInterop.emitRustExpr v52 v58 
    let _run_target_args'_v57 = v59 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v60 : string = "String::from($0)"
    let v61 : std_string_String = Fable.Core.RustInterop.emitRustExpr v52 v60 
    let _run_target_args'_v57 = v61 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v62 : string = "String::from($0)"
    let v63 : std_string_String = Fable.Core.RustInterop.emitRustExpr v52 v62 
    let _run_target_args'_v57 = v63 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v65 : std_string_String = v52 |> unbox<std_string_String>
    let _run_target_args'_v57 = v65 
    #endif
#if FABLE_COMPILER_PYTHON
    let v69 : std_string_String = v52 |> unbox<std_string_String>
    let _run_target_args'_v57 = v69 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v73 : std_string_String = v52 |> unbox<std_string_String>
    let _run_target_args'_v57 = v73 
    #endif
#else
    let v77 : std_string_String = v52 |> unbox<std_string_String>
    let _run_target_args'_v57 = v77 
    #endif
    let v80 : std_string_String = _run_target_args'_v57 
    let v86 : string = "fable_library_rust::String_::fromString($0)"
    let v87 : string = Fable.Core.RustInterop.emitRustExpr v80 v86 
    let _run_target_args'_v13 = v87 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v88 : string = "option_env!(\"" + v8 + "\").unwrap_or(\"\")"
    let v89 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v88 
    (* run_target_args'
    let v94 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v95 : string = "String::from($0)"
    let v96 : std_string_String = Fable.Core.RustInterop.emitRustExpr v89 v95 
    let _run_target_args'_v94 = v96 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v97 : string = "String::from($0)"
    let v98 : std_string_String = Fable.Core.RustInterop.emitRustExpr v89 v97 
    let _run_target_args'_v94 = v98 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v99 : string = "String::from($0)"
    let v100 : std_string_String = Fable.Core.RustInterop.emitRustExpr v89 v99 
    let _run_target_args'_v94 = v100 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v102 : std_string_String = v89 |> unbox<std_string_String>
    let _run_target_args'_v94 = v102 
    #endif
#if FABLE_COMPILER_PYTHON
    let v106 : std_string_String = v89 |> unbox<std_string_String>
    let _run_target_args'_v94 = v106 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v110 : std_string_String = v89 |> unbox<std_string_String>
    let _run_target_args'_v94 = v110 
    #endif
#else
    let v114 : std_string_String = v89 |> unbox<std_string_String>
    let _run_target_args'_v94 = v114 
    #endif
    let v117 : std_string_String = _run_target_args'_v94 
    let v123 : string = "fable_library_rust::String_::fromString($0)"
    let v124 : string = Fable.Core.RustInterop.emitRustExpr v117 v123 
    let _run_target_args'_v13 = v124 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v126 : string = null |> unbox<string>
    let _run_target_args'_v13 = v126 
    #endif
#if FABLE_COMPILER_PYTHON
    let v130 : string = null |> unbox<string>
    let _run_target_args'_v13 = v130 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v134 : string = null |> unbox<string>
    let _run_target_args'_v13 = v134 
    #endif
#else
    let v138 : string = null |> unbox<string>
    let _run_target_args'_v13 = v138 
    #endif
    let v141 : string = _run_target_args'_v13 
    let v149 : string = "True"
    let v150 : bool = v141 <> v149 
    let v162 : US4 =
        if v150 then
            US4_1
        else
            let v154 : string = $"near_sdk::env::block_timestamp()"
            let v155 : uint64 = Fable.Core.RustInterop.emitRustExpr () v154 
            let v157 : (uint64 -> int64) = int64
            let v158 : int64 = v157 v155
            US4_0(v158)
    let v163 : US2 = US2_1
    let _run_target_args'_v3 = struct (v163, v162) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v164 : US2, v165 : US4) = method4()
    let _run_target_args'_v3 = struct (v164, v165) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v166 : US2, v167 : US4) = method4()
    let _run_target_args'_v3 = struct (v166, v167) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v168 : US2, v169 : US4) = method4()
    let _run_target_args'_v3 = struct (v168, v169) 
    #endif
#else
    let struct (v170 : US2, v171 : US4) = method4()
    let _run_target_args'_v3 = struct (v170, v171) 
    #endif
    let struct (v172 : US2, v173 : US4) = _run_target_args'_v3 
    let v178 : Mut0 = {l0 = 1L} : Mut0
    let v179 : (string -> unit) = closure4()
    let v180 : Mut1 = {l0 = v179} : Mut1
    let v181 : Mut2 = {l0 = true} : Mut2
    let v182 : string = ""
    let v183 : Mut3 = {l0 = v182} : Mut3
    let v186 : US3 =
        match v172 with
        | US2_1 -> (* None *)
            v0
        | US2_0(v184) -> (* Some *)
            v184
    let v187 : Mut4 = {l0 = v186} : Mut4
    let v198 : int64 option =
        match v173 with
        | US4_1 -> (* None *)
            let v194 : int64 option = None
            v194
        | US4_0(v188) -> (* Some *)
            let v190 : int64 option = Some v188 
            v190
    struct (v178, v180, v181, v183, v187, v198)
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
    let v187 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v190 : (int64 -> US4) = method11()
    let v191 : US4 option = v5 |> Option.map v190 
    let v211 : US4 = US4_1
    let v212 : US4 = v191 |> Option.defaultValue v211 
    let v344 : System.DateTime =
        match v212 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v327 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v328 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v328 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v329 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v329 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v331 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v327 = v331 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v334 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v334 
            #endif
#if FABLE_COMPILER_PYTHON
            let v335 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v335 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v336 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v336 
            #endif
#else
            let v337 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v337 
            #endif
            let v338 : System.DateTime = _run_target_args'_v327 
            v338
        | US4_0(v216) -> (* Some *)
            (* run_target_args'
            let v223 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v224 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v224 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v225 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v225 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v227 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v223 = v227 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v230 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v230 
            #endif
#if FABLE_COMPILER_PYTHON
            let v231 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v231 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v232 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v232 
            #endif
#else
            let v233 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v233 
            #endif
            let v234 : System.DateTime = _run_target_args'_v223 
            (* run_target_args'
            let v245 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v246 : (System.DateTime -> int64) = _.Ticks
            let v247 : int64 = v246 v234
            let _run_target_args'_v245 = v247 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v248 : (System.DateTime -> int64) = _.Ticks
            let v249 : int64 = v248 v234
            let _run_target_args'_v245 = v249 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v251 : int64 = null |> unbox<int64>
            let _run_target_args'_v245 = v251 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v254 : (System.DateTime -> int64) = _.Ticks
            let v255 : int64 = v254 v234
            let _run_target_args'_v245 = v255 
            #endif
#if FABLE_COMPILER_PYTHON
            let v256 : (System.DateTime -> int64) = _.Ticks
            let v257 : int64 = v256 v234
            let _run_target_args'_v245 = v257 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v258 : (System.DateTime -> int64) = _.Ticks
            let v259 : int64 = v258 v234
            let _run_target_args'_v245 = v259 
            #endif
#else
            let v260 : (System.DateTime -> int64) = _.Ticks
            let v261 : int64 = v260 v234
            let _run_target_args'_v245 = v261 
            #endif
            let v262 : int64 = _run_target_args'_v245 
            let v283 : int64 = v262 |> int64 
            let v286 : int64 = v283 - v216
            let v292 : System.TimeSpan = v286 |> System.TimeSpan 
            let v298 : (System.TimeSpan -> int32) = _.Hours
            let v299 : int32 = v298 v292
            let v303 : (System.TimeSpan -> int32) = _.Minutes
            let v304 : int32 = v303 v292
            let v308 : (System.TimeSpan -> int32) = _.Seconds
            let v309 : int32 = v308 v292
            let v313 : (System.TimeSpan -> int32) = _.Milliseconds
            let v314 : int32 = v313 v292
            let v318 : System.DateTime = System.DateTime (1, 1, 1, v299, v304, v309, v314)
            v318
    let v346 : string = method12()
    let v350 : bool = v346 = ""
    let v352 : string =
        if v350 then
            let v351 : string = "M-d-y hh:mm:ss tt"
            v351
        else
            v346
    let v353 : (string -> string) = v344.ToString
    let v354 : string = v353 v352
    let _run_target_args'_v187 = v354 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v371 : (int64 -> US4) = method11()
    let v372 : US4 option = v5 |> Option.map v371 
    let v392 : US4 = US4_1
    let v393 : US4 = v372 |> Option.defaultValue v392 
    let v525 : System.DateTime =
        match v393 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v508 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v509 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v509 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v510 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v510 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v512 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v508 = v512 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v515 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v515 
            #endif
#if FABLE_COMPILER_PYTHON
            let v516 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v516 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v517 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v517 
            #endif
#else
            let v518 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v518 
            #endif
            let v519 : System.DateTime = _run_target_args'_v508 
            v519
        | US4_0(v397) -> (* Some *)
            (* run_target_args'
            let v404 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v405 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v405 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v406 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v406 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v408 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v404 = v408 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v411 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v411 
            #endif
#if FABLE_COMPILER_PYTHON
            let v412 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v412 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v413 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v413 
            #endif
#else
            let v414 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v414 
            #endif
            let v415 : System.DateTime = _run_target_args'_v404 
            (* run_target_args'
            let v426 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v427 : (System.DateTime -> int64) = _.Ticks
            let v428 : int64 = v427 v415
            let _run_target_args'_v426 = v428 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v429 : (System.DateTime -> int64) = _.Ticks
            let v430 : int64 = v429 v415
            let _run_target_args'_v426 = v430 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v432 : int64 = null |> unbox<int64>
            let _run_target_args'_v426 = v432 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v435 : (System.DateTime -> int64) = _.Ticks
            let v436 : int64 = v435 v415
            let _run_target_args'_v426 = v436 
            #endif
#if FABLE_COMPILER_PYTHON
            let v437 : (System.DateTime -> int64) = _.Ticks
            let v438 : int64 = v437 v415
            let _run_target_args'_v426 = v438 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v439 : (System.DateTime -> int64) = _.Ticks
            let v440 : int64 = v439 v415
            let _run_target_args'_v426 = v440 
            #endif
#else
            let v441 : (System.DateTime -> int64) = _.Ticks
            let v442 : int64 = v441 v415
            let _run_target_args'_v426 = v442 
            #endif
            let v443 : int64 = _run_target_args'_v426 
            let v464 : int64 = v443 |> int64 
            let v467 : int64 = v464 - v397
            let v473 : System.TimeSpan = v467 |> System.TimeSpan 
            let v479 : (System.TimeSpan -> int32) = _.Hours
            let v480 : int32 = v479 v473
            let v484 : (System.TimeSpan -> int32) = _.Minutes
            let v485 : int32 = v484 v473
            let v489 : (System.TimeSpan -> int32) = _.Seconds
            let v490 : int32 = v489 v473
            let v494 : (System.TimeSpan -> int32) = _.Milliseconds
            let v495 : int32 = v494 v473
            let v499 : System.DateTime = System.DateTime (1, 1, 1, v480, v485, v490, v495)
            v499
    let v527 : string = method12()
    let v531 : bool = v527 = ""
    let v533 : string =
        if v531 then
            let v532 : string = "M-d-y hh:mm:ss tt"
            v532
        else
            v527
    let v534 : (string -> string) = v525.ToString
    let v535 : string = v534 v533
    let _run_target_args'_v187 = v535 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v550 : string = $"near_sdk::env::block_timestamp()"
    let v551 : uint64 = Fable.Core.RustInterop.emitRustExpr () v550 
    let v554 : (int64 -> US4) = method11()
    let v555 : US4 option = v5 |> Option.map v554 
    let v575 : US4 = US4_1
    let v576 : US4 = v555 |> Option.defaultValue v575 
    let v588 : uint64 =
        match v576 with
        | US4_1 -> (* None *)
            v551
        | US4_0(v580) -> (* Some *)
            let v582 : (int64 -> uint64) = uint64
            let v583 : uint64 = v582 v580
            let v586 : uint64 = v551 - v583
            v586
    let v589 : uint64 = v588 / 1000000000UL
    let v590 : uint64 = v589 % 60UL
    let v591 : uint64 = v589 / 60UL
    let v592 : uint64 = v591 % 60UL
    let v593 : uint64 = v589 / 3600UL
    let v594 : uint64 = v593 % 24UL
    let v595 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v596 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v594, v592, v590) v595 
    let v597 : string = "fable_library_rust::String_::fromString($0)"
    let v598 : string = Fable.Core.RustInterop.emitRustExpr v596 v597 
    let _run_target_args'_v187 = v598 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v601 : (int64 -> US4) = method11()
    let v602 : US4 option = v5 |> Option.map v601 
    let v622 : US4 = US4_1
    let v623 : US4 = v602 |> Option.defaultValue v622 
    let v755 : System.DateTime =
        match v623 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v738 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v739 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v739 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v740 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v740 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v742 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v738 = v742 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v745 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v745 
            #endif
#if FABLE_COMPILER_PYTHON
            let v746 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v746 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v747 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v747 
            #endif
#else
            let v748 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v748 
            #endif
            let v749 : System.DateTime = _run_target_args'_v738 
            v749
        | US4_0(v627) -> (* Some *)
            (* run_target_args'
            let v634 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v635 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v635 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v636 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v636 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v638 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v634 = v638 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v641 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v641 
            #endif
#if FABLE_COMPILER_PYTHON
            let v642 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v642 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v643 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v643 
            #endif
#else
            let v644 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v644 
            #endif
            let v645 : System.DateTime = _run_target_args'_v634 
            (* run_target_args'
            let v656 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v657 : (System.DateTime -> int64) = _.Ticks
            let v658 : int64 = v657 v645
            let _run_target_args'_v656 = v658 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v659 : (System.DateTime -> int64) = _.Ticks
            let v660 : int64 = v659 v645
            let _run_target_args'_v656 = v660 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v662 : int64 = null |> unbox<int64>
            let _run_target_args'_v656 = v662 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v665 : (System.DateTime -> int64) = _.Ticks
            let v666 : int64 = v665 v645
            let _run_target_args'_v656 = v666 
            #endif
#if FABLE_COMPILER_PYTHON
            let v667 : (System.DateTime -> int64) = _.Ticks
            let v668 : int64 = v667 v645
            let _run_target_args'_v656 = v668 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v669 : (System.DateTime -> int64) = _.Ticks
            let v670 : int64 = v669 v645
            let _run_target_args'_v656 = v670 
            #endif
#else
            let v671 : (System.DateTime -> int64) = _.Ticks
            let v672 : int64 = v671 v645
            let _run_target_args'_v656 = v672 
            #endif
            let v673 : int64 = _run_target_args'_v656 
            let v694 : int64 = v673 |> int64 
            let v697 : int64 = v694 - v627
            let v703 : System.TimeSpan = v697 |> System.TimeSpan 
            let v709 : (System.TimeSpan -> int32) = _.Hours
            let v710 : int32 = v709 v703
            let v714 : (System.TimeSpan -> int32) = _.Minutes
            let v715 : int32 = v714 v703
            let v719 : (System.TimeSpan -> int32) = _.Seconds
            let v720 : int32 = v719 v703
            let v724 : (System.TimeSpan -> int32) = _.Milliseconds
            let v725 : int32 = v724 v703
            let v729 : System.DateTime = System.DateTime (1, 1, 1, v710, v715, v720, v725)
            v729
    let v757 : string = method13()
    let v761 : bool = v757 = ""
    let v763 : string =
        if v761 then
            let v762 : string = "M-d-y hh:mm:ss tt"
            v762
        else
            v757
    let v764 : (string -> string) = v755.ToString
    let v765 : string = v764 v763
    let _run_target_args'_v187 = v765 
    #endif
#if FABLE_COMPILER_PYTHON
    let v782 : (int64 -> US4) = method11()
    let v783 : US4 option = v5 |> Option.map v782 
    let v803 : US4 = US4_1
    let v804 : US4 = v783 |> Option.defaultValue v803 
    let v936 : System.DateTime =
        match v804 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v919 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v920 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v920 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v921 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v921 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v923 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v919 = v923 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v926 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v926 
            #endif
#if FABLE_COMPILER_PYTHON
            let v927 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v927 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v928 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v928 
            #endif
#else
            let v929 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v929 
            #endif
            let v930 : System.DateTime = _run_target_args'_v919 
            v930
        | US4_0(v808) -> (* Some *)
            (* run_target_args'
            let v815 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v816 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v816 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v817 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v817 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v819 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v815 = v819 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v822 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v822 
            #endif
#if FABLE_COMPILER_PYTHON
            let v823 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v823 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v824 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v824 
            #endif
#else
            let v825 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v825 
            #endif
            let v826 : System.DateTime = _run_target_args'_v815 
            (* run_target_args'
            let v837 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v838 : (System.DateTime -> int64) = _.Ticks
            let v839 : int64 = v838 v826
            let _run_target_args'_v837 = v839 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v840 : (System.DateTime -> int64) = _.Ticks
            let v841 : int64 = v840 v826
            let _run_target_args'_v837 = v841 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v843 : int64 = null |> unbox<int64>
            let _run_target_args'_v837 = v843 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v846 : (System.DateTime -> int64) = _.Ticks
            let v847 : int64 = v846 v826
            let _run_target_args'_v837 = v847 
            #endif
#if FABLE_COMPILER_PYTHON
            let v848 : (System.DateTime -> int64) = _.Ticks
            let v849 : int64 = v848 v826
            let _run_target_args'_v837 = v849 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v850 : (System.DateTime -> int64) = _.Ticks
            let v851 : int64 = v850 v826
            let _run_target_args'_v837 = v851 
            #endif
#else
            let v852 : (System.DateTime -> int64) = _.Ticks
            let v853 : int64 = v852 v826
            let _run_target_args'_v837 = v853 
            #endif
            let v854 : int64 = _run_target_args'_v837 
            let v875 : int64 = v854 |> int64 
            let v878 : int64 = v875 - v808
            let v884 : System.TimeSpan = v878 |> System.TimeSpan 
            let v890 : (System.TimeSpan -> int32) = _.Hours
            let v891 : int32 = v890 v884
            let v895 : (System.TimeSpan -> int32) = _.Minutes
            let v896 : int32 = v895 v884
            let v900 : (System.TimeSpan -> int32) = _.Seconds
            let v901 : int32 = v900 v884
            let v905 : (System.TimeSpan -> int32) = _.Milliseconds
            let v906 : int32 = v905 v884
            let v910 : System.DateTime = System.DateTime (1, 1, 1, v891, v896, v901, v906)
            v910
    let v938 : string = method13()
    let v942 : bool = v938 = ""
    let v944 : string =
        if v942 then
            let v943 : string = "M-d-y hh:mm:ss tt"
            v943
        else
            v938
    let v945 : (string -> string) = v936.ToString
    let v946 : string = v945 v944
    let _run_target_args'_v187 = v946 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v963 : (int64 -> US4) = method11()
    let v964 : US4 option = v5 |> Option.map v963 
    let v984 : US4 = US4_1
    let v985 : US4 = v964 |> Option.defaultValue v984 
    let v1117 : System.DateTime =
        match v985 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1100 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1101 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1101 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1102 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1102 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1104 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1100 = v1104 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1107 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1107 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1108 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1108 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1109 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1109 
            #endif
#else
            let v1110 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1110 
            #endif
            let v1111 : System.DateTime = _run_target_args'_v1100 
            v1111
        | US4_0(v989) -> (* Some *)
            (* run_target_args'
            let v996 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v997 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v997 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v998 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v998 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1000 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v996 = v1000 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1003 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v1003 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1004 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v1004 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1005 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v1005 
            #endif
#else
            let v1006 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v1006 
            #endif
            let v1007 : System.DateTime = _run_target_args'_v996 
            (* run_target_args'
            let v1018 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1019 : (System.DateTime -> int64) = _.Ticks
            let v1020 : int64 = v1019 v1007
            let _run_target_args'_v1018 = v1020 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1021 : (System.DateTime -> int64) = _.Ticks
            let v1022 : int64 = v1021 v1007
            let _run_target_args'_v1018 = v1022 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1024 : int64 = null |> unbox<int64>
            let _run_target_args'_v1018 = v1024 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1027 : (System.DateTime -> int64) = _.Ticks
            let v1028 : int64 = v1027 v1007
            let _run_target_args'_v1018 = v1028 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1029 : (System.DateTime -> int64) = _.Ticks
            let v1030 : int64 = v1029 v1007
            let _run_target_args'_v1018 = v1030 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1031 : (System.DateTime -> int64) = _.Ticks
            let v1032 : int64 = v1031 v1007
            let _run_target_args'_v1018 = v1032 
            #endif
#else
            let v1033 : (System.DateTime -> int64) = _.Ticks
            let v1034 : int64 = v1033 v1007
            let _run_target_args'_v1018 = v1034 
            #endif
            let v1035 : int64 = _run_target_args'_v1018 
            let v1056 : int64 = v1035 |> int64 
            let v1059 : int64 = v1056 - v989
            let v1065 : System.TimeSpan = v1059 |> System.TimeSpan 
            let v1071 : (System.TimeSpan -> int32) = _.Hours
            let v1072 : int32 = v1071 v1065
            let v1076 : (System.TimeSpan -> int32) = _.Minutes
            let v1077 : int32 = v1076 v1065
            let v1081 : (System.TimeSpan -> int32) = _.Seconds
            let v1082 : int32 = v1081 v1065
            let v1086 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1087 : int32 = v1086 v1065
            let v1091 : System.DateTime = System.DateTime (1, 1, 1, v1072, v1077, v1082, v1087)
            v1091
    let v1119 : string = method13()
    let v1123 : bool = v1119 = ""
    let v1125 : string =
        if v1123 then
            let v1124 : string = "M-d-y hh:mm:ss tt"
            v1124
        else
            v1119
    let v1126 : (string -> string) = v1117.ToString
    let v1127 : string = v1126 v1125
    let _run_target_args'_v187 = v1127 
    #endif
#else
    let v1144 : (int64 -> US4) = method11()
    let v1145 : US4 option = v5 |> Option.map v1144 
    let v1165 : US4 = US4_1
    let v1166 : US4 = v1145 |> Option.defaultValue v1165 
    let v1298 : System.DateTime =
        match v1166 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1281 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1282 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1282 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1283 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1283 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1285 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1281 = v1285 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1288 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1288 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1289 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1289 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1290 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1290 
            #endif
#else
            let v1291 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1291 
            #endif
            let v1292 : System.DateTime = _run_target_args'_v1281 
            v1292
        | US4_0(v1170) -> (* Some *)
            (* run_target_args'
            let v1177 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1178 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1178 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1179 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1179 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1181 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1177 = v1181 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1184 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1184 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1185 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1185 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1186 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1186 
            #endif
#else
            let v1187 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1187 
            #endif
            let v1188 : System.DateTime = _run_target_args'_v1177 
            (* run_target_args'
            let v1199 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1200 : (System.DateTime -> int64) = _.Ticks
            let v1201 : int64 = v1200 v1188
            let _run_target_args'_v1199 = v1201 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1202 : (System.DateTime -> int64) = _.Ticks
            let v1203 : int64 = v1202 v1188
            let _run_target_args'_v1199 = v1203 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1205 : int64 = null |> unbox<int64>
            let _run_target_args'_v1199 = v1205 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1208 : (System.DateTime -> int64) = _.Ticks
            let v1209 : int64 = v1208 v1188
            let _run_target_args'_v1199 = v1209 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1210 : (System.DateTime -> int64) = _.Ticks
            let v1211 : int64 = v1210 v1188
            let _run_target_args'_v1199 = v1211 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1212 : (System.DateTime -> int64) = _.Ticks
            let v1213 : int64 = v1212 v1188
            let _run_target_args'_v1199 = v1213 
            #endif
#else
            let v1214 : (System.DateTime -> int64) = _.Ticks
            let v1215 : int64 = v1214 v1188
            let _run_target_args'_v1199 = v1215 
            #endif
            let v1216 : int64 = _run_target_args'_v1199 
            let v1237 : int64 = v1216 |> int64 
            let v1240 : int64 = v1237 - v1170
            let v1246 : System.TimeSpan = v1240 |> System.TimeSpan 
            let v1252 : (System.TimeSpan -> int32) = _.Hours
            let v1253 : int32 = v1252 v1246
            let v1257 : (System.TimeSpan -> int32) = _.Minutes
            let v1258 : int32 = v1257 v1246
            let v1262 : (System.TimeSpan -> int32) = _.Seconds
            let v1263 : int32 = v1262 v1246
            let v1267 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1268 : int32 = v1267 v1246
            let v1272 : System.DateTime = System.DateTime (1, 1, 1, v1253, v1258, v1263, v1268)
            v1272
    let v1300 : string = method13()
    let v1304 : bool = v1300 = ""
    let v1306 : string =
        if v1304 then
            let v1305 : string = "M-d-y hh:mm:ss tt"
            v1305
        else
            v1300
    let v1307 : (string -> string) = v1298.ToString
    let v1308 : string = v1307 v1306
    let _run_target_args'_v187 = v1308 
    #endif
    let v1323 : string = _run_target_args'_v187 
    v1323
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
    let v83 : string = "inline_colorization::color_reset"
    let v84 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v83 
    let v85 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v84) v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v47 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "inline_colorization::color_bright_black"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    (* run_target_args'
    let v95 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v96 : string = "&*$0"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v96 
    let _run_target_args'_v95 = v97 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v98 : string = "&*$0"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v98 
    let _run_target_args'_v95 = v99 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v100 : string = "&*$0"
    let v101 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v100 
    let _run_target_args'_v95 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v103 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v107 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v111 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v111 
    #endif
#else
    let v115 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v115 
    #endif
    let v118 : Ref<Str> = _run_target_args'_v95 
    let v124 : string = "inline_colorization::color_reset"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v124 
    let v126 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v90, v118, v125) v126 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let _run_target_args'_v47 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "inline_colorization::color_bright_black"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    (* run_target_args'
    let v136 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v137 : string = "&*$0"
    let v138 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v137 
    let _run_target_args'_v136 = v138 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : string = "&*$0"
    let v140 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v139 
    let _run_target_args'_v136 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = "&*$0"
    let v142 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v141 
    let _run_target_args'_v136 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v152 
    #endif
#else
    let v156 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v156 
    #endif
    let v159 : Ref<Str> = _run_target_args'_v136 
    let v165 : string = "inline_colorization::color_reset"
    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v165 
    let v167 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v168 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v131, v159, v166) v167 
    let v169 : string = "fable_library_rust::String_::fromString($0)"
    let v170 : string = Fable.Core.RustInterop.emitRustExpr v168 v169 
    let _run_target_args'_v47 = v170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v172 : string = "\u001b[90m"
    let v176 : string = method16()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[90m"
    let v192 : string = method16()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[90m"
    let v208 : string = method16()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[90m"
    let v224 : string = method16()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
and method18 (v0 : string) : string =
    let v1 : char list = []
    let v4 : (char list -> (char [])) = List.toArray
    let v5 : (char []) = v4 v1
    let v8 : string = v0.TrimStart v5 
    let v40 : char list = []
    let v42 : char list = '/' :: v40 
    let v46 : char list = ' ' :: v42 
    let v51 : (char list -> (char [])) = List.toArray
    let v52 : (char []) = v51 v46
    let v55 : string = v8.TrimEnd v52 
    v55
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
    let v117 : string = $"$0.chars()"
    let v118 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v111 v117 
    let v119 : string = "$0"
    let v120 : _ = Fable.Core.RustInterop.emitRustExpr v118 v119 
    let v121 : string = "$0.collect::<Vec<_>>()"
    let v122 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let v123 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v124 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v122 v123 
    let v125 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v126 : bool = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let v127 : string = "x"
    let v128 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v127 
    let v129 : string = "String::from_iter($0)"
    let v130 : std_string_String = Fable.Core.RustInterop.emitRustExpr v128 v129 
    let v131 : string = "true; $0 }).collect::<Vec<_>>()"
    let v132 : bool = Fable.Core.RustInterop.emitRustExpr v130 v131 
    let v133 : string = "_vec_map"
    let v134 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v133 
    let v135 : string = "$0.len()"
    let v136 : unativeint = Fable.Core.RustInterop.emitRustExpr v134 v135 
    let v142 : int32 = v136 |> int32 
    let v152 : string = ""
    let v153 : bool = v0 <> v152 
    let v157 : bool =
        if v153 then
            let v156 : bool = v142 <= 1
            v156
        else
            false
    if v157 then
        v41.l0 <- v83
        ()
    else
        v41.l0 <- v152
        let v158 : string = "true; $0.into_iter().for_each(|x| { //"
        let v159 : bool = Fable.Core.RustInterop.emitRustExpr v134 v158 
        let v160 : string = "x"
        let v161 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v160 
        let v162 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v163 : bool = Fable.Core.RustInterop.emitRustExpr v161 v162 
        let v164 : string = $"true"
        let v165 : bool = Fable.Core.RustInterop.emitRustExpr () v164 
        let v166 : string = "true; }); //"
        let v167 : bool = Fable.Core.RustInterop.emitRustExpr () v166 
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
    let v168 : (string -> unit) = v39.l0
    v168 v0
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
    let v46 : char list = []
    let v48 : char list = '\\' :: v46 
    let v53 : (char list -> (char [])) = List.toArray
    let v54 : (char []) = v53 v48
    let v57 : string = v14.TrimEnd v54 
    v57
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
    let v185 : string = $"{v178}"
    let v193 : unit = ()
    let v194 : (unit -> unit) = closure8(v12, v185)
    let v195 : unit = (fun () -> v194 (); v193) ()
    let v202 : string = $"{v92}"
    let v210 : unit = ()
    let v211 : (unit -> unit) = closure8(v12, v202)
    let v212 : unit = (fun () -> v211 (); v210) ()
    let v220 : string = "contract"
    let v221 : string = $"{v220}"
    let v229 : unit = ()
    let v230 : (unit -> unit) = closure8(v12, v221)
    let v231 : unit = (fun () -> v230 (); v229) ()
    let v238 : string = $"{v53}"
    let v246 : unit = ()
    let v247 : (unit -> unit) = closure8(v12, v238)
    let v248 : unit = (fun () -> v247 (); v246) ()
    (* run_target_args'
    let v258 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v259 : string = "format!(\"{:#?}\", $0)"
    let v260 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v259 
    let v261 : string = "fable_library_rust::String_::fromString($0)"
    let v262 : string = Fable.Core.RustInterop.emitRustExpr v260 v261 
    let _run_target_args'_v258 = v262 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v263 : string = "format!(\"{:#?}\", $0)"
    let v264 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v263 
    let v265 : string = "fable_library_rust::String_::fromString($0)"
    let v266 : string = Fable.Core.RustInterop.emitRustExpr v264 v265 
    let _run_target_args'_v258 = v266 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v267 : string = "format!(\"{:#?}\", $0)"
    let v268 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v267 
    let v269 : string = "fable_library_rust::String_::fromString($0)"
    let v270 : string = Fable.Core.RustInterop.emitRustExpr v268 v269 
    let _run_target_args'_v258 = v270 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v272 : string = $"%A{v10}"
    let _run_target_args'_v258 = v272 
    #endif
#if FABLE_COMPILER_PYTHON
    let v276 : string = $"%A{v10}"
    let _run_target_args'_v258 = v276 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v280 : string = $"%A{v10}"
    let _run_target_args'_v258 = v280 
    #endif
#else
    let v284 : string = $"%A{v10}"
    let _run_target_args'_v258 = v284 
    #endif
    let v287 : string = _run_target_args'_v258 
    let v294 : string = $"{v287}"
    let v302 : unit = ()
    let v303 : (unit -> unit) = closure8(v12, v294)
    let v304 : unit = (fun () -> v303 (); v302) ()
    let v312 : string = " }"
    let v313 : string = $"{v312}"
    let v321 : unit = ()
    let v322 : (unit -> unit) = closure8(v12, v313)
    let v323 : unit = (fun () -> v322 (); v321) ()
    let v329 : string = v12.l0
    let v330 : int64 = v0.l0
    let v333 : string = " "
    let v334 : string = v6 + v333 
    let v338 : string = v334 + v7 
    let v343 : string = " #"
    let v344 : string = v338 + v343 
    let v348 : (int64 -> string) = _.ToString()
    let v349 : string = v348 v330
    let v353 : string = v344 + v349 
    let v357 : string = v353 + v333 
    let v362 : string = "spiral_wasm.run"
    let v363 : string = v357 + v362 
    let v368 : string = " / "
    let v369 : string = v363 + v368 
    let v373 : string = v369 + v329 
    method18(v373)
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
    let v184 : string = $"{v177}"
    let v192 : unit = ()
    let v193 : (unit -> unit) = closure8(v11, v184)
    let v194 : unit = (fun () -> v193 (); v192) ()
    let v202 : string = " }"
    let v203 : string = $"{v202}"
    let v211 : unit = ()
    let v212 : (unit -> unit) = closure8(v11, v203)
    let v213 : unit = (fun () -> v212 (); v211) ()
    let v219 : string = v11.l0
    let v220 : int64 = v0.l0
    let v223 : string = " "
    let v224 : string = v6 + v223 
    let v228 : string = v224 + v7 
    let v233 : string = " #"
    let v234 : string = v228 + v233 
    let v238 : (int64 -> string) = _.ToString()
    let v239 : string = v238 v220
    let v243 : string = v234 + v239 
    let v247 : string = v243 + v223 
    let v252 : string = "spiral_wasm.run"
    let v253 : string = v247 + v252 
    let v258 : string = " / "
    let v259 : string = v253 + v258 
    let v263 : string = v259 + v219 
    method18(v263)
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
    let v117 : string = $"$0.chars()"
    let v118 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v111 v117 
    let v119 : string = "$0"
    let v120 : _ = Fable.Core.RustInterop.emitRustExpr v118 v119 
    let v121 : string = "$0.collect::<Vec<_>>()"
    let v122 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let v123 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v124 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v122 v123 
    let v125 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v126 : bool = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let v127 : string = "x"
    let v128 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v127 
    let v129 : string = "String::from_iter($0)"
    let v130 : std_string_String = Fable.Core.RustInterop.emitRustExpr v128 v129 
    let v131 : string = "true; $0 }).collect::<Vec<_>>()"
    let v132 : bool = Fable.Core.RustInterop.emitRustExpr v130 v131 
    let v133 : string = "_vec_map"
    let v134 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v133 
    let v135 : string = "$0.len()"
    let v136 : unativeint = Fable.Core.RustInterop.emitRustExpr v134 v135 
    let v142 : int32 = v136 |> int32 
    let v152 : string = ""
    let v153 : bool = v62 <> v152 
    let v157 : bool =
        if v153 then
            let v156 : bool = v142 <= 1
            v156
        else
            false
    if v157 then
        v40.l0 <- v83
        ()
    else
        v40.l0 <- v152
        let v158 : string = "true; $0.into_iter().for_each(|x| { //"
        let v159 : bool = Fable.Core.RustInterop.emitRustExpr v134 v158 
        let v160 : string = "x"
        let v161 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v160 
        let v162 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v163 : bool = Fable.Core.RustInterop.emitRustExpr v161 v162 
        let v164 : string = $"true"
        let v165 : bool = Fable.Core.RustInterop.emitRustExpr () v164 
        let v166 : string = "true; }); //"
        let v167 : bool = Fable.Core.RustInterop.emitRustExpr () v166 
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
    let v168 : (string -> unit) = v38.l0
    v168 v62
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
    let v83 : string = "inline_colorization::color_reset"
    let v84 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v83 
    let v85 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v84) v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v47 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "inline_colorization::color_bright_green"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    (* run_target_args'
    let v95 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v96 : string = "&*$0"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v96 
    let _run_target_args'_v95 = v97 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v98 : string = "&*$0"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v98 
    let _run_target_args'_v95 = v99 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v100 : string = "&*$0"
    let v101 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v100 
    let _run_target_args'_v95 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v103 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v107 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v111 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v111 
    #endif
#else
    let v115 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v115 
    #endif
    let v118 : Ref<Str> = _run_target_args'_v95 
    let v124 : string = "inline_colorization::color_reset"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v124 
    let v126 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v90, v118, v125) v126 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let _run_target_args'_v47 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "inline_colorization::color_bright_green"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    (* run_target_args'
    let v136 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v137 : string = "&*$0"
    let v138 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v137 
    let _run_target_args'_v136 = v138 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : string = "&*$0"
    let v140 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v139 
    let _run_target_args'_v136 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = "&*$0"
    let v142 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v141 
    let _run_target_args'_v136 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v152 
    #endif
#else
    let v156 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v156 
    #endif
    let v159 : Ref<Str> = _run_target_args'_v136 
    let v165 : string = "inline_colorization::color_reset"
    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v165 
    let v167 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v168 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v131, v159, v166) v167 
    let v169 : string = "fable_library_rust::String_::fromString($0)"
    let v170 : string = Fable.Core.RustInterop.emitRustExpr v168 v169 
    let _run_target_args'_v47 = v170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v172 : string = "\u001b[92m"
    let v176 : string = method16()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[92m"
    let v192 : string = method16()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[92m"
    let v208 : string = method16()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[92m"
    let v224 : string = method16()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
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
    let v406 : string = $"{v399}"
    let v414 : unit = ()
    let v415 : (unit -> unit) = closure8(v14, v406)
    let v416 : unit = (fun () -> v415 (); v414) ()
    let v424 : string = " }"
    let v425 : string = $"{v424}"
    let v433 : unit = ()
    let v434 : (unit -> unit) = closure8(v14, v425)
    let v435 : unit = (fun () -> v434 (); v433) ()
    let v441 : string = v14.l0
    let v442 : int64 = v0.l0
    let v445 : string = " "
    let v446 : string = v6 + v445 
    let v450 : string = v446 + v7 
    let v455 : string = " #"
    let v456 : string = v450 + v455 
    let v460 : (int64 -> string) = _.ToString()
    let v461 : string = v460 v442
    let v465 : string = v456 + v461 
    let v469 : string = v465 + v445 
    let v474 : string = "near_workspaces.print_usd / outcome"
    let v475 : string = v469 + v474 
    let v480 : string = " / "
    let v481 : string = v475 + v480 
    let v485 : string = v481 + v441 
    method18(v485)
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
    let v108 : string = $"{v101}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure8(v10, v108)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v126 : string = " }"
    let v127 : string = $"{v126}"
    let v135 : unit = ()
    let v136 : (unit -> unit) = closure8(v10, v127)
    let v137 : unit = (fun () -> v136 (); v135) ()
    let v143 : string = v10.l0
    let v144 : int64 = v0.l0
    let v147 : string = " "
    let v148 : string = v6 + v147 
    let v152 : string = v148 + v7 
    let v157 : string = " #"
    let v158 : string = v152 + v157 
    let v162 : (int64 -> string) = _.ToString()
    let v163 : string = v162 v144
    let v167 : string = v158 + v163 
    let v171 : string = v167 + v147 
    let v176 : string = "spiral_wasm.run"
    let v177 : string = v171 + v176 
    let v182 : string = " / "
    let v183 : string = v177 + v182 
    let v187 : string = v183 + v143 
    method18(v187)
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
    let v184 : string = $"{v177}"
    let v192 : unit = ()
    let v193 : (unit -> unit) = closure8(v11, v184)
    let v194 : unit = (fun () -> v193 (); v192) ()
    let v202 : string = " }"
    let v203 : string = $"{v202}"
    let v211 : unit = ()
    let v212 : (unit -> unit) = closure8(v11, v203)
    let v213 : unit = (fun () -> v212 (); v211) ()
    let v219 : string = v11.l0
    let v220 : int64 = v0.l0
    let v223 : string = " "
    let v224 : string = v6 + v223 
    let v228 : string = v224 + v7 
    let v233 : string = " #"
    let v234 : string = v228 + v233 
    let v238 : (int64 -> string) = _.ToString()
    let v239 : string = v238 v220
    let v243 : string = v234 + v239 
    let v247 : string = v243 + v223 
    let v252 : string = "spiral_wasm.run"
    let v253 : string = v247 + v252 
    let v258 : string = " / "
    let v259 : string = v253 + v258 
    let v263 : string = v259 + v219 
    method18(v263)
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
    let v184 : string = $"{v177}"
    let v192 : unit = ()
    let v193 : (unit -> unit) = closure8(v11, v184)
    let v194 : unit = (fun () -> v193 (); v192) ()
    let v202 : string = " }"
    let v203 : string = $"{v202}"
    let v211 : unit = ()
    let v212 : (unit -> unit) = closure8(v11, v203)
    let v213 : unit = (fun () -> v212 (); v211) ()
    let v219 : string = v11.l0
    let v220 : int64 = v0.l0
    let v223 : string = " "
    let v224 : string = v6 + v223 
    let v228 : string = v224 + v7 
    let v233 : string = " #"
    let v234 : string = v228 + v233 
    let v238 : (int64 -> string) = _.ToString()
    let v239 : string = v238 v220
    let v243 : string = v234 + v239 
    let v247 : string = v243 + v223 
    let v252 : string = "spiral_wasm.run"
    let v253 : string = v247 + v252 
    let v258 : string = " / "
    let v259 : string = v253 + v258 
    let v263 : string = v259 + v219 
    method18(v263)
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
    let v108 : string = $"{v101}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure8(v10, v108)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v126 : string = " }"
    let v127 : string = $"{v126}"
    let v135 : unit = ()
    let v136 : (unit -> unit) = closure8(v10, v127)
    let v137 : unit = (fun () -> v136 (); v135) ()
    let v143 : string = v10.l0
    let v144 : int64 = v0.l0
    let v147 : string = " "
    let v148 : string = v6 + v147 
    let v152 : string = v148 + v7 
    let v157 : string = " #"
    let v158 : string = v152 + v157 
    let v162 : (int64 -> string) = _.ToString()
    let v163 : string = v162 v144
    let v167 : string = v158 + v163 
    let v171 : string = v167 + v147 
    let v176 : string = "spiral_wasm.run"
    let v177 : string = v171 + v176 
    let v182 : string = " / "
    let v183 : string = v177 + v182 
    let v187 : string = v183 + v143 
    method18(v187)
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
    let v108 : string = $"{v101}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure8(v10, v108)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v126 : string = " }"
    let v127 : string = $"{v126}"
    let v135 : unit = ()
    let v136 : (unit -> unit) = closure8(v10, v127)
    let v137 : unit = (fun () -> v136 (); v135) ()
    let v143 : string = v10.l0
    let v144 : int64 = v0.l0
    let v147 : string = " "
    let v148 : string = v6 + v147 
    let v152 : string = v148 + v7 
    let v157 : string = " #"
    let v158 : string = v152 + v157 
    let v162 : (int64 -> string) = _.ToString()
    let v163 : string = v162 v144
    let v167 : string = v158 + v163 
    let v171 : string = v167 + v147 
    let v176 : string = "spiral_wasm.run"
    let v177 : string = v171 + v176 
    let v182 : string = " / "
    let v183 : string = v177 + v182 
    let v187 : string = v183 + v143 
    method18(v187)
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
    let v318 : string = "true; $0 }).collect::<Vec<_>>()"
    let v319 : bool = Fable.Core.RustInterop.emitRustExpr v312 v318 
    let v320 : string = "_vec_map"
    let v321 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v320 
    let v322 : string = "true; $0.iter().for_each(|x| { $1(x.clone()); }); //"
    let v323 : (std_string_String -> unit) = closure16()
    let v324 : bool = Fable.Core.RustInterop.emitRustExpr struct (v321, v323) v322 
    let v327 : unit = ()
    let v328 : (unit -> unit) = closure18()
    let v329 : unit = (fun () -> v328 (); v327) ()
    let v332 : string = "$0.total_gas_burnt"
    let v333 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v155 v332 
    let v334 : string = "$0.as_gas()"
    let v335 : uint64 = Fable.Core.RustInterop.emitRustExpr v333 v334 
    let v337 : (uint64 -> float) = float
    let v338 : float = v337 v335
    let v341 : float = v338 / 10000000000000000.0
    let v342 : float = v341 * 6.68
    let v403 : unit = ()
    let v404 : (unit -> unit) = closure19(v1, v335, v342)
    let v405 : unit = (fun () -> v404 (); v403) ()
    let v466 : string = "$0"
    let v467 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v155 v466 
    let v468 : string = "v467.outcomes()"
    let v469 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v468 
    let v470 : string = "v469.into_iter()"
    let v471 : _ = Fable.Core.RustInterop.emitRustExpr () v470 
    let v472 : string = "v471.cloned()"
    let v473 : _ = Fable.Core.RustInterop.emitRustExpr () v472 
    let v474 : string = "true; v473.for_each(|x| $0(x))"
    let v475 : (near_workspaces_result_ExecutionOutcome -> unit) = closure20()
    let v476 : bool = Fable.Core.RustInterop.emitRustExpr v475 v474 
    let v477 : string = "$0.into_result()"
    let v478 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure> = Fable.Core.RustInterop.emitRustExpr v155 v477 
    let v539 : unit = ()
    let v540 : (unit -> unit) = closure22(v478)
    let v541 : unit = (fun () -> v540 (); v539) ()
    let v602 : near_workspaces_result_ExecutionFinalResult = method34(v155)
    let v603 : string = "v602.receipt_failures()"
    let v604 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v603 
    let v605 : string = "$0.len()"
    let v606 : unativeint = Fable.Core.RustInterop.emitRustExpr v604 v605 
    let v612 : int32 = v606 |> int32 
    let v680 : unit = ()
    let v681 : (unit -> unit) = closure23(v604, v612)
    let v682 : unit = (fun () -> v681 (); v680) ()
    let v743 : near_workspaces_result_ExecutionFinalResult = method36(v155)
    let v744 : string = "v743.receipt_outcomes()"
    let v745 : Ref<Slice<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v744 
    let v746 : string = "v745.into()"
    let v747 : Vec<near_workspaces_result_ExecutionOutcome> = Fable.Core.RustInterop.emitRustExpr () v746 
    let v748 : string = "$0.len()"
    let v749 : unativeint = Fable.Core.RustInterop.emitRustExpr v747 v748 
    let v755 : int32 = v749 |> int32 
    let v823 : unit = ()
    let v824 : (unit -> unit) = closure24(v747, v755)
    let v825 : unit = (fun () -> v824 (); v823) ()
    let v886 : string = "$0.json()"
    let v887 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v155 v886 
    let v948 : unit = ()
    let v949 : (unit -> unit) = closure25(v887)
    let v950 : unit = (fun () -> v949 (); v948) ()
    let v1011 : string = "$0.borsh()"
    let v1012 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v155 v1011 
    let v1073 : unit = ()
    let v1074 : (unit -> unit) = closure26(v1012)
    let v1075 : unit = (fun () -> v1074 (); v1073) ()
    let v1136 : string = method15()
    let v1137 : Mut3 = {l0 = v1136} : Mut3
    let v1140 : string = "{ "
    let v1141 : string = $"{v1140}"
    let v1149 : unit = ()
    let v1150 : (unit -> unit) = closure8(v1137, v1141)
    let v1151 : unit = (fun () -> v1150 (); v1149) ()
    let v1159 : string = "receipt_outcomes_len"
    let v1160 : string = $"{v1159}"
    let v1168 : unit = ()
    let v1169 : (unit -> unit) = closure8(v1137, v1160)
    let v1170 : unit = (fun () -> v1169 (); v1168) ()
    let v1178 : string = " = "
    let v1179 : string = $"{v1178}"
    let v1187 : unit = ()
    let v1188 : (unit -> unit) = closure8(v1137, v1179)
    let v1189 : unit = (fun () -> v1188 (); v1187) ()
    let v1199 : string = $"{v755}"
    let v1207 : unit = ()
    let v1208 : (unit -> unit) = closure8(v1137, v1199)
    let v1209 : unit = (fun () -> v1208 (); v1207) ()
    let v1217 : string = "; "
    let v1218 : string = $"{v1217}"
    let v1226 : unit = ()
    let v1227 : (unit -> unit) = closure8(v1137, v1218)
    let v1228 : unit = (fun () -> v1227 (); v1226) ()
    let v1236 : string = "retry"
    let v1237 : string = $"{v1236}"
    let v1245 : unit = ()
    let v1246 : (unit -> unit) = closure8(v1137, v1237)
    let v1247 : unit = (fun () -> v1246 (); v1245) ()
    let v1254 : string = $"{v1178}"
    let v1262 : unit = ()
    let v1263 : (unit -> unit) = closure8(v1137, v1254)
    let v1264 : unit = (fun () -> v1263 (); v1262) ()
    let v1274 : string = $"{v1}"
    let v1282 : unit = ()
    let v1283 : (unit -> unit) = closure8(v1137, v1274)
    let v1284 : unit = (fun () -> v1283 (); v1282) ()
    let v1291 : string = $"{v1217}"
    let v1299 : unit = ()
    let v1300 : (unit -> unit) = closure8(v1137, v1291)
    let v1301 : unit = (fun () -> v1300 (); v1299) ()
    let v1309 : string = "receipt_failures"
    let v1310 : string = $"{v1309}"
    let v1318 : unit = ()
    let v1319 : (unit -> unit) = closure8(v1137, v1310)
    let v1320 : unit = (fun () -> v1319 (); v1318) ()
    let v1327 : string = $"{v1178}"
    let v1335 : unit = ()
    let v1336 : (unit -> unit) = closure8(v1137, v1327)
    let v1337 : unit = (fun () -> v1336 (); v1335) ()
    (* run_target_args'
    let v1347 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1348 : string = "format!(\"{:#?}\", $0)"
    let v1349 : std_string_String = Fable.Core.RustInterop.emitRustExpr v604 v1348 
    let v1350 : string = "fable_library_rust::String_::fromString($0)"
    let v1351 : string = Fable.Core.RustInterop.emitRustExpr v1349 v1350 
    let _run_target_args'_v1347 = v1351 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1352 : string = "format!(\"{:#?}\", $0)"
    let v1353 : std_string_String = Fable.Core.RustInterop.emitRustExpr v604 v1352 
    let v1354 : string = "fable_library_rust::String_::fromString($0)"
    let v1355 : string = Fable.Core.RustInterop.emitRustExpr v1353 v1354 
    let _run_target_args'_v1347 = v1355 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1356 : string = "format!(\"{:#?}\", $0)"
    let v1357 : std_string_String = Fable.Core.RustInterop.emitRustExpr v604 v1356 
    let v1358 : string = "fable_library_rust::String_::fromString($0)"
    let v1359 : string = Fable.Core.RustInterop.emitRustExpr v1357 v1358 
    let _run_target_args'_v1347 = v1359 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1361 : string = $"%A{v604}"
    let _run_target_args'_v1347 = v1361 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1365 : string = $"%A{v604}"
    let _run_target_args'_v1347 = v1365 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1369 : string = $"%A{v604}"
    let _run_target_args'_v1347 = v1369 
    #endif
#else
    let v1373 : string = $"%A{v604}"
    let _run_target_args'_v1347 = v1373 
    #endif
    let v1376 : string = _run_target_args'_v1347 
    let v1383 : string = $"{v1376}"
    let v1391 : unit = ()
    let v1392 : (unit -> unit) = closure8(v1137, v1383)
    let v1393 : unit = (fun () -> v1392 (); v1391) ()
    let v1401 : string = " }"
    let v1402 : string = $"{v1401}"
    let v1410 : unit = ()
    let v1411 : (unit -> unit) = closure8(v1137, v1402)
    let v1412 : unit = (fun () -> v1411 (); v1410) ()
    let v1418 : string = v1137.l0
    let v1419 : bool = v612 > 0
    let v1453 : Result<US7, anyhow_Error> =
        if v1419 then
            let v1422 : US7 = US7_0(v1418)
            let v1423 : Result<US7, anyhow_Error> = Ok v1422 
            v1423
        else
            let v1427 : bool = v755 > 1
            if v1427 then
                let v1430 : US7 = US7_1
                let v1431 : Result<US7, anyhow_Error> = Ok v1430 
                v1431
            else
                let v1435 : string = "anyhow::anyhow!($0)"
                let v1436 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v1418 v1435 
                (* run_target_args'
                let v1438 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1439 : string = "Err($0)"
                let v1440 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1436 v1439 
                let _run_target_args'_v1438 = v1440 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1441 : string = "Err($0)"
                let v1442 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1436 v1441 
                let _run_target_args'_v1438 = v1442 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1443 : string = "Err($0)"
                let v1444 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1436 v1443 
                let _run_target_args'_v1438 = v1444 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1445 : Result<US7, anyhow_Error> = v1436 |> Error
                let _run_target_args'_v1438 = v1445 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1446 : Result<US7, anyhow_Error> = v1436 |> Error
                let _run_target_args'_v1438 = v1446 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1447 : Result<US7, anyhow_Error> = v1436 |> Error
                let _run_target_args'_v1438 = v1447 
                #endif
#else
                let v1448 : Result<US7, anyhow_Error> = v1436 |> Error
                let _run_target_args'_v1438 = v1448 
                #endif
                let v1449 : Result<US7, anyhow_Error> = _run_target_args'_v1438 
                v1449
    let v1454 : string = ""
    let v1455 : string = "}"
    let v1456 : string = v1454 + v1455 
    let x = v1453 //
    let v1457 : _ = x
    let v1458 : unit = ()
    (* run_target_args'
    let v1459 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1460 : string = $"true; let _fix_closure_v1458 = $0"
    let v1461 : bool = Fable.Core.RustInterop.emitRustExpr v1457 v1460 
    let _run_target_args'_v1459 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1462 : string = $"true; let _fix_closure_v1458 = $0"
    let v1463 : bool = Fable.Core.RustInterop.emitRustExpr v1457 v1462 
    let _run_target_args'_v1459 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1464 : string = $"true; let _fix_closure_v1458 = $0"
    let v1465 : bool = Fable.Core.RustInterop.emitRustExpr v1457 v1464 
    let _run_target_args'_v1459 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v1459 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v1459 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v1459 = false 
    #endif
#else
    let _run_target_args'_v1459 = false 
    #endif
    let v1466 : bool = _run_target_args'_v1459 
    let v1468 : string = $"true; _fix_closure_v1458 " + v1456 + "); " + v1454 + " // rust.fix_closure'"
    let v1469 : bool = Fable.Core.RustInterop.emitRustExpr () v1468 
    let v1470 : string = "__future_init"
    let v1471 : _ = Fable.Core.RustInterop.emitRustExpr () v1470 
    let v1472 : string = "v1471"
    let v1473 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v1472 
    v1473
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
    let v83 : string = "inline_colorization::color_reset"
    let v84 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v83 
    let v85 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v84) v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v47 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "inline_colorization::color_yellow"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    (* run_target_args'
    let v95 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v96 : string = "&*$0"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v96 
    let _run_target_args'_v95 = v97 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v98 : string = "&*$0"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v98 
    let _run_target_args'_v95 = v99 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v100 : string = "&*$0"
    let v101 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v100 
    let _run_target_args'_v95 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v103 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v107 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v111 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v111 
    #endif
#else
    let v115 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v115 
    #endif
    let v118 : Ref<Str> = _run_target_args'_v95 
    let v124 : string = "inline_colorization::color_reset"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v124 
    let v126 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v90, v118, v125) v126 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let _run_target_args'_v47 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "inline_colorization::color_yellow"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    (* run_target_args'
    let v136 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v137 : string = "&*$0"
    let v138 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v137 
    let _run_target_args'_v136 = v138 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : string = "&*$0"
    let v140 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v139 
    let _run_target_args'_v136 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = "&*$0"
    let v142 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v141 
    let _run_target_args'_v136 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v152 
    #endif
#else
    let v156 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v156 
    #endif
    let v159 : Ref<Str> = _run_target_args'_v136 
    let v165 : string = "inline_colorization::color_reset"
    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v165 
    let v167 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v168 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v131, v159, v166) v167 
    let v169 : string = "fable_library_rust::String_::fromString($0)"
    let v170 : string = Fable.Core.RustInterop.emitRustExpr v168 v169 
    let _run_target_args'_v47 = v170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v172 : string = "\u001b[93m"
    let v176 : string = method16()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[93m"
    let v192 : string = method16()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[93m"
    let v208 : string = method16()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[93m"
    let v224 : string = method16()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
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
    let v184 : string = $"{v177}"
    let v192 : unit = ()
    let v193 : (unit -> unit) = closure8(v11, v184)
    let v194 : unit = (fun () -> v193 (); v192) ()
    let v202 : string = " }"
    let v203 : string = $"{v202}"
    let v211 : unit = ()
    let v212 : (unit -> unit) = closure8(v11, v203)
    let v213 : unit = (fun () -> v212 (); v211) ()
    let v219 : string = v11.l0
    let v220 : int64 = v0.l0
    let v223 : string = " "
    let v224 : string = v6 + v223 
    let v228 : string = v224 + v7 
    let v233 : string = " #"
    let v234 : string = v228 + v233 
    let v238 : (int64 -> string) = _.ToString()
    let v239 : string = v238 v220
    let v243 : string = v234 + v239 
    let v247 : string = v243 + v223 
    let v252 : string = "spiral_wasm.run / Error error"
    let v253 : string = v247 + v252 
    let v258 : string = " / "
    let v259 : string = v253 + v258 
    let v263 : string = v259 + v219 
    method18(v263)
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
    let v115 : string = $"$0.chars()"
    let v116 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v109 v115 
    let v117 : string = "$0"
    let v118 : _ = Fable.Core.RustInterop.emitRustExpr v116 v117 
    let v119 : string = "$0.collect::<Vec<_>>()"
    let v120 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v118 v119 
    let v121 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v122 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let v123 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v124 : bool = Fable.Core.RustInterop.emitRustExpr v122 v123 
    let v125 : string = "x"
    let v126 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v125 
    let v127 : string = "String::from_iter($0)"
    let v128 : std_string_String = Fable.Core.RustInterop.emitRustExpr v126 v127 
    let v129 : string = "true; $0 }).collect::<Vec<_>>()"
    let v130 : bool = Fable.Core.RustInterop.emitRustExpr v128 v129 
    let v131 : string = "_vec_map"
    let v132 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v131 
    let v133 : string = "$0.len()"
    let v134 : unativeint = Fable.Core.RustInterop.emitRustExpr v132 v133 
    let v140 : int32 = v134 |> int32 
    let v150 : string = ""
    let v151 : bool = v62 <> v150 
    let v155 : bool =
        if v151 then
            let v154 : bool = v140 <= 1
            v154
        else
            false
    if v155 then
        v40.l0 <- v81
        ()
    else
        v40.l0 <- v150
        let v156 : string = "true; $0.into_iter().for_each(|x| { //"
        let v157 : bool = Fable.Core.RustInterop.emitRustExpr v132 v156 
        let v158 : string = "x"
        let v159 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v158 
        let v160 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v161 : bool = Fable.Core.RustInterop.emitRustExpr v159 v160 
        let v162 : string = $"true"
        let v163 : bool = Fable.Core.RustInterop.emitRustExpr () v162 
        let v164 : string = "true; }); //"
        let v165 : bool = Fable.Core.RustInterop.emitRustExpr () v164 
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
    let v166 : (string -> unit) = v38.l0
    v166 v62
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
    let v83 : string = "inline_colorization::color_reset"
    let v84 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v83 
    let v85 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v84) v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v47 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "inline_colorization::color_bright_red"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    (* run_target_args'
    let v95 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v96 : string = "&*$0"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v96 
    let _run_target_args'_v95 = v97 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v98 : string = "&*$0"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v98 
    let _run_target_args'_v95 = v99 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v100 : string = "&*$0"
    let v101 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v100 
    let _run_target_args'_v95 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v103 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v107 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v111 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v111 
    #endif
#else
    let v115 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v115 
    #endif
    let v118 : Ref<Str> = _run_target_args'_v95 
    let v124 : string = "inline_colorization::color_reset"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v124 
    let v126 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v90, v118, v125) v126 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let _run_target_args'_v47 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "inline_colorization::color_bright_red"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    (* run_target_args'
    let v136 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v137 : string = "&*$0"
    let v138 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v137 
    let _run_target_args'_v136 = v138 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : string = "&*$0"
    let v140 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v139 
    let _run_target_args'_v136 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = "&*$0"
    let v142 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v141 
    let _run_target_args'_v136 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v152 
    #endif
#else
    let v156 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v156 
    #endif
    let v159 : Ref<Str> = _run_target_args'_v136 
    let v165 : string = "inline_colorization::color_reset"
    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v165 
    let v167 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v168 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v131, v159, v166) v167 
    let v169 : string = "fable_library_rust::String_::fromString($0)"
    let v170 : string = Fable.Core.RustInterop.emitRustExpr v168 v169 
    let _run_target_args'_v47 = v170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v172 : string = "\u001b[91m"
    let v176 : string = method16()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[91m"
    let v192 : string = method16()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[91m"
    let v208 : string = method16()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[91m"
    let v224 : string = method16()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
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
    let v521 : US8 =
        match v30 with
        | US9_1(v222) -> (* Error *)
            let v223 : bool = v1 >= 15uy
            if v223 then
                let v284 : unit = ()
                let v285 : (unit -> unit) = closure30(v1, v222)
                let v286 : unit = (fun () -> v285 (); v284) ()
                let v349 : unit = ()
                let v350 : (unit -> unit) = closure31()
                let v351 : unit = (fun () -> v350 (); v349) ()
                let v354 : string = "true; let __future_init = Box::pin(/*"
                let v355 : bool = Fable.Core.RustInterop.emitRustExpr () v354 
                let v356 : string = "*/ async move { /*"
                let v357 : bool = Fable.Core.RustInterop.emitRustExpr () v356 
                let v358 : string = "*/ ()"
                let v359 : bool = Fable.Core.RustInterop.emitRustExpr () v358 
                let v360 : string = ""
                let v361 : string = "}"
                let v362 : string = v360 + v361 
                let v363 : US7 = US7_1
                let x = struct (v1, v363) //
                let v364 : _ = x
                let v365 : unit = ()
                (* run_target_args'
                let v366 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v367 : string = $"true; let _fix_closure_v365 = $0"
                let v368 : bool = Fable.Core.RustInterop.emitRustExpr v364 v367 
                let _run_target_args'_v366 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v369 : string = $"true; let _fix_closure_v365 = $0"
                let v370 : bool = Fable.Core.RustInterop.emitRustExpr v364 v369 
                let _run_target_args'_v366 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v371 : string = $"true; let _fix_closure_v365 = $0"
                let v372 : bool = Fable.Core.RustInterop.emitRustExpr v364 v371 
                let _run_target_args'_v366 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v366 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v366 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v366 = false 
                #endif
#else
                let _run_target_args'_v366 = false 
                #endif
                let v373 : bool = _run_target_args'_v366 
                let v375 : string = $"true; _fix_closure_v365 " + v362 + "); " + v360 + " // rust.fix_closure'"
                let v376 : bool = Fable.Core.RustInterop.emitRustExpr () v375 
                let v377 : string = "__future_init"
                let v378 : _ = Fable.Core.RustInterop.emitRustExpr () v377 
                let v379 : string = "v378"
                let v380 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v379 
                let v381 : string = "v380.await"
                let struct (v382 : uint8, v383 : US7) = Fable.Core.RustInterop.emitRustExpr () v381 
                US8_0(v382, v383)
            else
                let v445 : unit = ()
                let v446 : (unit -> unit) = closure32(v1, v222)
                let v447 : unit = (fun () -> v446 (); v445) ()
                let v510 : unit = ()
                let v511 : (unit -> unit) = closure33()
                let v512 : unit = (fun () -> v511 (); v510) ()
                let v515 : uint8 = v1 + 1uy
                let v516 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = method25(v0, v515)
                let v517 : string = "v516.await"
                let v518 : US8 = Fable.Core.RustInterop.emitRustExpr () v517 
                v518
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
                let v55 : string = $"true; _fix_closure_v45 " + v42 + "); " + v40 + " // rust.fix_closure'"
                let v56 : bool = Fable.Core.RustInterop.emitRustExpr () v55 
                let v57 : string = "__future_init"
                let v58 : _ = Fable.Core.RustInterop.emitRustExpr () v57 
                let v59 : string = "v58"
                let v60 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v59 
                let v61 : string = "v60.await"
                let struct (v62 : uint8, v63 : US7) = Fable.Core.RustInterop.emitRustExpr () v61 
                US8_0(v62, v63)
            | US7_0(v65) -> (* Some *)
                let v126 : unit = ()
                let v127 : (unit -> unit) = closure34(v1, v65)
                let v128 : unit = (fun () -> v127 (); v126) ()
                let v189 : string = "true; let __future_init = Box::pin(/*"
                let v190 : bool = Fable.Core.RustInterop.emitRustExpr () v189 
                let v191 : string = "*/ async move { /*"
                let v192 : bool = Fable.Core.RustInterop.emitRustExpr () v191 
                let v193 : string = "*/ ()"
                let v194 : bool = Fable.Core.RustInterop.emitRustExpr () v193 
                let v195 : string = ""
                let v196 : string = "}"
                let v197 : string = v195 + v196 
                let v198 : US7 = US7_0(v65)
                let x = struct (v1, v198) //
                let v199 : _ = x
                let v200 : unit = ()
                (* run_target_args'
                let v201 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v202 : string = $"true; let _fix_closure_v200 = $0"
                let v203 : bool = Fable.Core.RustInterop.emitRustExpr v199 v202 
                let _run_target_args'_v201 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v204 : string = $"true; let _fix_closure_v200 = $0"
                let v205 : bool = Fable.Core.RustInterop.emitRustExpr v199 v204 
                let _run_target_args'_v201 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v206 : string = $"true; let _fix_closure_v200 = $0"
                let v207 : bool = Fable.Core.RustInterop.emitRustExpr v199 v206 
                let _run_target_args'_v201 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v201 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v201 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v201 = false 
                #endif
#else
                let _run_target_args'_v201 = false 
                #endif
                let v208 : bool = _run_target_args'_v201 
                let v210 : string = $"true; _fix_closure_v200 " + v197 + "); " + v195 + " // rust.fix_closure'"
                let v211 : bool = Fable.Core.RustInterop.emitRustExpr () v210 
                let v212 : string = "__future_init"
                let v213 : _ = Fable.Core.RustInterop.emitRustExpr () v212 
                let v214 : string = "v213"
                let v215 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v214 
                let v216 : string = "v215.await"
                let struct (v217 : uint8, v218 : US7) = Fable.Core.RustInterop.emitRustExpr () v216 
                US8_1(v217, v218)
    let v522 : string = ""
    let v523 : string = "}"
    let v524 : string = v522 + v523 
    let x = v521 //
    let v525 : _ = x
    let v526 : unit = ()
    (* run_target_args'
    let v527 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v528 : string = $"true; let _fix_closure_v526 = $0"
    let v529 : bool = Fable.Core.RustInterop.emitRustExpr v525 v528 
    let _run_target_args'_v527 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v530 : string = $"true; let _fix_closure_v526 = $0"
    let v531 : bool = Fable.Core.RustInterop.emitRustExpr v525 v530 
    let _run_target_args'_v527 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v532 : string = $"true; let _fix_closure_v526 = $0"
    let v533 : bool = Fable.Core.RustInterop.emitRustExpr v525 v532 
    let _run_target_args'_v527 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v527 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v527 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v527 = false 
    #endif
#else
    let _run_target_args'_v527 = false 
    #endif
    let v534 : bool = _run_target_args'_v527 
    let v536 : string = $"true; _fix_closure_v526 " + v524 + "); " + v522 + " // rust.fix_closure'"
    let v537 : bool = Fable.Core.RustInterop.emitRustExpr () v536 
    let v538 : string = "__future_init"
    let v539 : _ = Fable.Core.RustInterop.emitRustExpr () v538 
    let v540 : string = "v539"
    let v541 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = Fable.Core.RustInterop.emitRustExpr () v540 
    v541
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
    let v41 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v42 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v0, v35) v41 
    let v45 : (std_string_String -> US0) = method2()
    let v46 : US0 option = v42 |> Option.map v45 
    let v66 : US0 = US0_1
    let v67 : US0 = v46 |> Option.defaultValue v66 
    let v74 : std_string_String =
        match v67 with
        | US0_1 -> (* None *)
            failwith<std_string_String> "Option does not have a value."
        | US0_0(v71) -> (* Some *)
            v71
    let v75 : string = "fable_library_rust::String_::fromString($0)"
    let v76 : string = Fable.Core.RustInterop.emitRustExpr v74 v75 
    let v137 : unit = ()
    let v138 : (unit -> unit) = closure13(v76)
    let v139 : unit = (fun () -> v138 (); v137) ()
    let v200 : string = "std::fs::read(&*$0)"
    let v201 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v76 v200 
    let v202 : string = "$0?"
    let v203 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v201 v202 
    let v204 : uint8 = 1uy
    let v205 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = method25(v203, v204)
    let v206 : string = "v205.await"
    let v207 : US8 = Fable.Core.RustInterop.emitRustExpr () v206 
    let v268 : unit = ()
    let v269 : (unit -> unit) = closure35(v207)
    let v270 : unit = (fun () -> v269 (); v268) ()
    let v533 : Result<uint8, anyhow_Error> =
        match v207 with
        | US8_1(v337, v338) -> (* Error *)
            let v339 : string = method15()
            let v340 : Mut3 = {l0 = v339} : Mut3
            let v343 : string = "{ "
            let v344 : string = $"{v343}"
            let v352 : unit = ()
            let v353 : (unit -> unit) = closure8(v340, v344)
            let v354 : unit = (fun () -> v353 (); v352) ()
            let v362 : string = "retries"
            let v363 : string = $"{v362}"
            let v371 : unit = ()
            let v372 : (unit -> unit) = closure8(v340, v363)
            let v373 : unit = (fun () -> v372 (); v371) ()
            let v381 : string = " = "
            let v382 : string = $"{v381}"
            let v390 : unit = ()
            let v391 : (unit -> unit) = closure8(v340, v382)
            let v392 : unit = (fun () -> v391 (); v390) ()
            let v399 : string = $"%A{v207}"
            let v403 : string = $"{v399}"
            let v411 : unit = ()
            let v412 : (unit -> unit) = closure8(v340, v403)
            let v413 : unit = (fun () -> v412 (); v411) ()
            let v421 : string = "; "
            let v422 : string = $"{v421}"
            let v430 : unit = ()
            let v431 : (unit -> unit) = closure8(v340, v422)
            let v432 : unit = (fun () -> v431 (); v430) ()
            let v440 : string = "error"
            let v441 : string = $"{v440}"
            let v449 : unit = ()
            let v450 : (unit -> unit) = closure8(v340, v441)
            let v451 : unit = (fun () -> v450 (); v449) ()
            let v458 : string = $"{v381}"
            let v466 : unit = ()
            let v467 : (unit -> unit) = closure8(v340, v458)
            let v468 : unit = (fun () -> v467 (); v466) ()
            let v475 : string = $"%A{v338}"
            let v479 : string = $"{v475}"
            let v487 : unit = ()
            let v488 : (unit -> unit) = closure8(v340, v479)
            let v489 : unit = (fun () -> v488 (); v487) ()
            let v497 : string = " }"
            let v498 : string = $"{v497}"
            let v506 : unit = ()
            let v507 : (unit -> unit) = closure8(v340, v498)
            let v508 : unit = (fun () -> v507 (); v506) ()
            let v514 : string = v340.l0
            let v515 : string = "anyhow::anyhow!($0)"
            let v516 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v514 v515 
            (* run_target_args'
            let v518 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v519 : string = "Err($0)"
            let v520 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v516 v519 
            let _run_target_args'_v518 = v520 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v521 : string = "Err($0)"
            let v522 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v516 v521 
            let _run_target_args'_v518 = v522 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v523 : string = "Err($0)"
            let v524 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v516 v523 
            let _run_target_args'_v518 = v524 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v525 : Result<uint8, anyhow_Error> = v516 |> Error
            let _run_target_args'_v518 = v525 
            #endif
#if FABLE_COMPILER_PYTHON
            let v526 : Result<uint8, anyhow_Error> = v516 |> Error
            let _run_target_args'_v518 = v526 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v527 : Result<uint8, anyhow_Error> = v516 |> Error
            let _run_target_args'_v518 = v527 
            #endif
#else
            let v528 : Result<uint8, anyhow_Error> = v516 |> Error
            let _run_target_args'_v518 = v528 
            #endif
            let v529 : Result<uint8, anyhow_Error> = _run_target_args'_v518 
            v529
        | US8_0(v331, v332) -> (* Ok *)
            let v334 : Result<uint8, anyhow_Error> = Ok v331 
            v334
    let v534 : string = ""
    let v535 : string = "}"
    let v536 : string = v534 + v535 
    let x = v533 //
    let v537 : _ = x
    let v538 : unit = ()
    (* run_target_args'
    let v539 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v540 : string = $"true; let _fix_closure_v538 = $0"
    let v541 : bool = Fable.Core.RustInterop.emitRustExpr v537 v540 
    let _run_target_args'_v539 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v542 : string = $"true; let _fix_closure_v538 = $0"
    let v543 : bool = Fable.Core.RustInterop.emitRustExpr v537 v542 
    let _run_target_args'_v539 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v544 : string = $"true; let _fix_closure_v538 = $0"
    let v545 : bool = Fable.Core.RustInterop.emitRustExpr v537 v544 
    let _run_target_args'_v539 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v539 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v539 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v539 = false 
    #endif
#else
    let _run_target_args'_v539 = false 
    #endif
    let v546 : bool = _run_target_args'_v539 
    let v548 : string = $"true; _fix_closure_v538 " + v536 + "); " + v534 + " // rust.fix_closure'"
    let v549 : bool = Fable.Core.RustInterop.emitRustExpr () v548 
    let v550 : string = "__future_init"
    let v551 : _ = Fable.Core.RustInterop.emitRustExpr () v550 
    let v552 : string = "v551"
    let v553 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v552 
    v553
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
    let v38 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v39 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v32) v38 
    let v42 : (std_string_String -> US0) = method2()
    let v43 : US0 option = v39 |> Option.map v42 
    let v63 : US0 = US0_1
    let v64 : US0 = v43 |> Option.defaultValue v63 
    let v200 : US1 =
        match v64 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v68) -> (* Some *)
            let v69 : string = "fable_library_rust::String_::fromString($0)"
            let v70 : string = Fable.Core.RustInterop.emitRustExpr v68 v69 
            
            
            
            
            
            
            
            
            
            
            let v73 : string = "Critical"
            let v74 : (unit -> string) = v73.ToLower
            let v75 : string = v74 ()
            let v80 : string = "Warning"
            let v81 : (unit -> string) = v80.ToLower
            let v82 : string = v81 ()
            let v87 : string = "Info"
            let v88 : (unit -> string) = v87.ToLower
            let v89 : string = v88 ()
            let v94 : string = "Debug"
            let v95 : (unit -> string) = v94.ToLower
            let v96 : string = v95 ()
            let v101 : string = "Verbose"
            let v102 : (unit -> string) = v101.ToLower
            let v103 : string = v102 ()
            let v106 : bool = "Verbose" = v70
            let v110 : US2 =
                if v106 then
                    let v107 : US3 = US3_0
                    US2_0(v107)
                else
                    US2_1
            let v196 : US2 =
                match v110 with
                | US2_1 -> (* None *)
                    let v113 : bool = "Debug" = v70
                    let v117 : US2 =
                        if v113 then
                            let v114 : US3 = US3_1
                            US2_0(v114)
                        else
                            US2_1
                    match v117 with
                    | US2_1 -> (* None *)
                        let v120 : bool = "Info" = v70
                        let v124 : US2 =
                            if v120 then
                                let v121 : US3 = US3_2
                                US2_0(v121)
                            else
                                US2_1
                        match v124 with
                        | US2_1 -> (* None *)
                            let v127 : bool = "Warning" = v70
                            let v131 : US2 =
                                if v127 then
                                    let v128 : US3 = US3_3
                                    US2_0(v128)
                                else
                                    US2_1
                            match v131 with
                            | US2_1 -> (* None *)
                                let v134 : bool = "Critical" = v70
                                let v138 : US2 =
                                    if v134 then
                                        let v135 : US3 = US3_4
                                        US2_0(v135)
                                    else
                                        US2_1
                                match v138 with
                                | US2_1 -> (* None *)
                                    let v141 : bool = v103 = v70
                                    let v145 : US2 =
                                        if v141 then
                                            let v142 : US3 = US3_0
                                            US2_0(v142)
                                        else
                                            US2_1
                                    match v145 with
                                    | US2_1 -> (* None *)
                                        let v148 : bool = v96 = v70
                                        let v152 : US2 =
                                            if v148 then
                                                let v149 : US3 = US3_1
                                                US2_0(v149)
                                            else
                                                US2_1
                                        match v152 with
                                        | US2_1 -> (* None *)
                                            let v155 : bool = v89 = v70
                                            let v159 : US2 =
                                                if v155 then
                                                    let v156 : US3 = US3_2
                                                    US2_0(v156)
                                                else
                                                    US2_1
                                            match v159 with
                                            | US2_1 -> (* None *)
                                                let v162 : bool = v82 = v70
                                                let v166 : US2 =
                                                    if v162 then
                                                        let v163 : US3 = US3_3
                                                        US2_0(v163)
                                                    else
                                                        US2_1
                                                match v166 with
                                                | US2_1 -> (* None *)
                                                    let v169 : bool = v75 = v70
                                                    let v173 : US2 =
                                                        if v169 then
                                                            let v170 : US3 = US3_4
                                                            US2_0(v170)
                                                        else
                                                            US2_1
                                                    match v173 with
                                                    | US2_1 -> (* None *)
                                                        US2_1
                                                    | US2_0(v174) -> (* Some *)
                                                        US2_0(v174)
                                                | US2_0(v167) -> (* Some *)
                                                    US2_0(v167)
                                            | US2_0(v160) -> (* Some *)
                                                US2_0(v160)
                                        | US2_0(v153) -> (* Some *)
                                            US2_0(v153)
                                    | US2_0(v146) -> (* Some *)
                                        US2_0(v146)
                                | US2_0(v139) -> (* Some *)
                                    US2_0(v139)
                            | US2_0(v132) -> (* Some *)
                                US2_0(v132)
                        | US2_0(v125) -> (* Some *)
                            US2_0(v125)
                    | US2_0(v118) -> (* Some *)
                        US2_0(v118)
                | US2_0(v111) -> (* Some *)
                    US2_0(v111)
            US1_0(v196)
    let v207 : US2 =
        match v200 with
        | US1_0(v201) -> (* Some *)
            match v201 with
            | US2_0(v202) -> (* Some *)
                US2_0(v202)
            | _ ->
                US2_1
        | _ ->
            US2_1
    let v211 : US3 =
        match v207 with
        | US2_1 -> (* None *)
            US3_0
        | US2_0(v208) -> (* Some *)
            v208
    let v224 : unit = ()
    let v225 : (unit -> unit) = closure2(v211)
    let v226 : unit = (fun () -> v225 (); v224) ()
    let struct (v245 : Mut0, v246 : Mut1, v247 : Mut2, v248 : Mut3, v249 : Mut4, v250 : int64 option) = TraceState.trace_state.Value
    let v323 : unit = ()
    let v324 : (unit -> unit) = closure5(v0)
    let v325 : unit = (fun () -> v324 (); v323) ()
    let v386 : string = method20()
    (* run_target_args'
    let v391 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v392 : string = "&*$0"
    let v393 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v386 v392 
    let _run_target_args'_v391 = v393 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v394 : string = "&*$0"
    let v395 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v386 v394 
    let _run_target_args'_v391 = v395 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v396 : string = "&*$0"
    let v397 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v386 v396 
    let _run_target_args'_v391 = v397 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v399 : Ref<Str> = v386 |> unbox<Ref<Str>>
    let _run_target_args'_v391 = v399 
    #endif
#if FABLE_COMPILER_PYTHON
    let v403 : Ref<Str> = v386 |> unbox<Ref<Str>>
    let _run_target_args'_v391 = v403 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v407 : Ref<Str> = v386 |> unbox<Ref<Str>>
    let _run_target_args'_v391 = v407 
    #endif
#else
    let v411 : Ref<Str> = v386 |> unbox<Ref<Str>>
    let _run_target_args'_v391 = v411 
    #endif
    let v414 : Ref<Str> = _run_target_args'_v391 
    let v420 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v421 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v414) v420 
    let v424 : (std_string_String -> string) = method21()
    let v425 : string option = v421 |> Option.map v424 
    let v532 : (string -> US7) = method8()
    let v533 : US7 option = v425 |> Option.map v532 
    let v553 : US7 = US7_1
    let v554 : US7 = v533 |> Option.defaultValue v553 
    let v558 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method22(v3)
    let v559 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v560 : _ = Fable.Core.RustInterop.emitRustExpr () v559 
    let v561 : string = "v560.handle().block_on($0)"
    let v562 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v558 v561 
    let v563 : (anyhow_Error -> std_string_String) = method40()
    (* run_target_args'
    let v565 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v566 : string = "$0.map_err(|x| $1(x))"
    let v567 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v562, v563) v566 
    let _run_target_args'_v565 = v567 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v568 : string = "$0.map_err(|x| $1(x))"
    let v569 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v562, v563) v568 
    let _run_target_args'_v565 = v569 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v570 : string = "$0.map_err(|x| $1(x))"
    let v571 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v562, v563) v570 
    let _run_target_args'_v565 = v571 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v572 : Result<uint8, std_string_String> = match v562 with Ok x -> Ok x | Error x -> Error (v563 x)
    let _run_target_args'_v565 = v572 
    #endif
#if FABLE_COMPILER_PYTHON
    let v573 : Result<uint8, std_string_String> = match v562 with Ok x -> Ok x | Error x -> Error (v563 x)
    let _run_target_args'_v565 = v573 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v574 : Result<uint8, std_string_String> = match v562 with Ok x -> Ok x | Error x -> Error (v563 x)
    let _run_target_args'_v565 = v574 
    #endif
#else
    let v575 : Result<uint8, std_string_String> = match v562 with Ok x -> Ok x | Error x -> Error (v563 x)
    let _run_target_args'_v565 = v575 
    #endif
    let v576 : Result<uint8, std_string_String> = _run_target_args'_v565 
    let v579 : (uint8 -> US10) = method49()
    let v580 : (std_string_String -> US10) = method50()
    let v582 : US10 = match v576 with Ok x -> v579 x | Error x -> v580 x
    match v582 with
    | US10_1(v607) -> (* Error *)
        match v554 with
        | US7_0(v608) -> (* Some *)
            let v609 : bool = "" = v608
            if v609 then
                ()
            else
                let v610 : string = "fable_library_rust::String_::fromString($0)"
                let v611 : string = Fable.Core.RustInterop.emitRustExpr v607 v610 
                let v613 : bool = v611.Contains v608 
                if v613 then
                    ()
                else
                    let v616 : string = $"spiral_wasm.main / exception: '{v608}' / error: {v607}"
                    (* run_target_args'
                    let v618 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v619 : string = "Err($0)"
                    let v620 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v616 v619 
                    let _run_target_args'_v618 = v620 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v621 : string = "Err($0)"
                    let v622 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v616 v621 
                    let _run_target_args'_v618 = v622 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v623 : string = "Err($0)"
                    let v624 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v616 v623 
                    let _run_target_args'_v618 = v624 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v625 : Result<unit, string> = v616 |> Error
                    let _run_target_args'_v618 = v625 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v626 : Result<unit, string> = v616 |> Error
                    let _run_target_args'_v618 = v626 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v627 : Result<unit, string> = v616 |> Error
                    let _run_target_args'_v618 = v627 
                    #endif
#else
                    let v628 : Result<unit, string> = v616 |> Error
                    let _run_target_args'_v618 = v628 
                    #endif
                    let v629 : Result<unit, string> = _run_target_args'_v618 
                    (* run_target_args'
                    let v632 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v633 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v629 v633 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v634 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v629 v634 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v635 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v629 v635 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    match v629 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if FABLE_COMPILER_PYTHON
                    match v629 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    match v629 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#else
                    match v629 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
                    // run_target_args' is_unit
                    ()
        | _ ->
            (* run_target_args'
            let v637 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v638 : string = "$0.unwrap()"
            let v639 : uint8 = Fable.Core.RustInterop.emitRustExpr v576 v638 
            let _run_target_args'_v637 = v639 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v640 : string = "$0.unwrap()"
            let v641 : uint8 = Fable.Core.RustInterop.emitRustExpr v576 v640 
            let _run_target_args'_v637 = v641 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v642 : string = "$0.unwrap()"
            let v643 : uint8 = Fable.Core.RustInterop.emitRustExpr v576 v642 
            let _run_target_args'_v637 = v643 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v644 : uint8 = match v576 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v637 = v644 
            #endif
#if FABLE_COMPILER_PYTHON
            let v645 : uint8 = match v576 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v637 = v645 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v646 : uint8 = match v576 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v637 = v646 
            #endif
#else
            let v647 : uint8 = match v576 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v637 = v647 
            #endif
            let v648 : uint8 = _run_target_args'_v637 
            ()
    | US10_0(v585) -> (* Ok *)
        match v554 with
        | US7_0(v586) -> (* Some *)
            let v587 : string = $"spiral_wasm.main / retries: {v585} / exception: '{v586}'"
            (* run_target_args'
            let v589 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v590 : string = "Err($0)"
            let v591 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v587 v590 
            let _run_target_args'_v589 = v591 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v592 : string = "Err($0)"
            let v593 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v587 v592 
            let _run_target_args'_v589 = v593 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v594 : string = "Err($0)"
            let v595 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v587 v594 
            let _run_target_args'_v589 = v595 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v596 : Result<unit, string> = v587 |> Error
            let _run_target_args'_v589 = v596 
            #endif
#if FABLE_COMPILER_PYTHON
            let v597 : Result<unit, string> = v587 |> Error
            let _run_target_args'_v589 = v597 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v598 : Result<unit, string> = v587 |> Error
            let _run_target_args'_v589 = v598 
            #endif
#else
            let v599 : Result<unit, string> = v587 |> Error
            let _run_target_args'_v589 = v599 
            #endif
            let v600 : Result<unit, string> = _run_target_args'_v589 
            (* run_target_args'
            let v603 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v604 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v600 v604 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v605 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v600 v605 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v606 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v600 v606 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            match v600 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if FABLE_COMPILER_PYTHON
            match v600 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            match v600 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#else
            match v600 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
            // run_target_args' is_unit
            ()
        | _ ->
            ()
    0
let v0 : ((string []) -> int32) = closure0()
let main args = v0 args
()
