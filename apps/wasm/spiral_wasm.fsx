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
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = method6(v0)
    let v7 : string = "std::env::var(&*$0)"
    let v8 : Result<std_string_String, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr v6 v7 
    let v9 : string = "true; let _result_map_ = $0.map(|x| { //"
    let v10 : bool = Fable.Core.RustInterop.emitRustExpr v8 v9 
    let v11 : string = "x"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v11 
    let v13 : string = "fable_library_rust::String_::fromString($0)"
    let v14 : string = Fable.Core.RustInterop.emitRustExpr v12 v13 
    let v15 : string = "true; $0 })"
    let v16 : bool = Fable.Core.RustInterop.emitRustExpr v14 v15 
    let v17 : string = "_result_map_"
    let v18 : Result<string, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr () v17 
    let v19 : string = method7()
    let v20 : string = "$0.unwrap_or($1)"
    let v21 : string = Fable.Core.RustInterop.emitRustExpr struct (v18, v19) v20 
    let _run_target_args'_v5 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v22 : US5 = US5_1
    let v23 : US6 = US6_3(v22)
    let v24 : string = $"env.get_environment_variable / target: {v23} / var: {v0}"
    let v25 : string = failwith<string> v24
    let _run_target_args'_v5 = v25 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v26 : US5 = US5_2
    let v27 : US6 = US6_3(v26)
    let v28 : string = $"env.get_environment_variable / target: {v27} / var: {v0}"
    let v29 : string = failwith<string> v28
    let _run_target_args'_v5 = v29 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v30 : string = "process.env[$0] ?? \"\""
    let v31 : string = Fable.Core.JsInterop.emitJsExpr v0 v30 
    let _run_target_args'_v5 = v31 
    #endif
#if FABLE_COMPILER_PYTHON
    let v33 : string = "os"
    let v34 : IOsEnviron = Fable.Core.PyInterop.importAll v33 
    let v35 : string = "v34.environ"
    let v36 : obj = Fable.Core.PyInterop.emitPyExpr () v35 
    let v40 : string = "v36.get($0)"
    let v41 : string = Fable.Core.PyInterop.emitPyExpr v0 v40 
    let mutable _v41 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v45 : (string -> string option) = Option.ofObj
    let v46 : string option = v45 v41
    v46 
    #else
    Some v41 
    #endif
    |> fun x -> _v41 <- Some x
    let v47 : string option = match _v41 with Some x -> x | None -> failwith "optionm'.of_obj / _v41=None"
    let v52 : (string -> US7) = method8()
    let v53 : US7 option = v47 |> Option.map v52 
    let v73 : US7 = US7_1
    let v74 : US7 = v53 |> Option.defaultValue v73 
    let v81 : string =
        match v74 with
        | US7_1 -> (* None *)
            let v79 : string = ""
            v79
        | US7_0(v78) -> (* Some *)
            v78
    let _run_target_args'_v5 = v81 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v82 : US5 = US5_1
    let v83 : US6 = US6_1(v82)
    let v84 : string = $"env.get_environment_variable / target: {v83} / var: {v0}"
    let v85 : string = failwith<string> v84
    let _run_target_args'_v5 = v85 
    #endif
#else
    let v86 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v87 : string = v86 v0
    let mutable _v87 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v89 : (string -> string option) = Option.ofObj
    let v90 : string option = v89 v87
    v90 
    #else
    Some v87 
    #endif
    |> fun x -> _v87 <- Some x
    let v91 : string option = match _v87 with Some x -> x | None -> failwith "optionm'.of_obj / _v87=None"
    let v96 : (string -> US7) = method8()
    let v97 : US7 option = v91 |> Option.map v96 
    let v117 : US7 = US7_1
    let v118 : US7 = v97 |> Option.defaultValue v117 
    let v125 : string =
        match v118 with
        | US7_1 -> (* None *)
            let v123 : string = ""
            v123
        | US7_0(v122) -> (* Some *)
            v122
    let _run_target_args'_v5 = v125 
    #endif
    let v126 : string = _run_target_args'_v5 
    v126
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
    let v200 : US4 =
        if v133 then
            US4_1
        else
            (* run_target_args'
            let v139 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v140 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v139 = v140 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v141 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v139 = v141 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v143 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v139 = v143 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v146 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v139 = v146 
            #endif
#if FABLE_COMPILER_PYTHON
            let v147 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v139 = v147 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v148 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v139 = v148 
            #endif
#else
            let v149 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v139 = v149 
            #endif
            let v150 : System.DateTime = _run_target_args'_v139 
            (* run_target_args'
            let v158 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v159 : (System.DateTime -> int64) = _.Ticks
            let v160 : int64 = v159 v150
            let _run_target_args'_v158 = v160 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v161 : (System.DateTime -> int64) = _.Ticks
            let v162 : int64 = v161 v150
            let _run_target_args'_v158 = v162 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v164 : int64 = null |> unbox<int64>
            let _run_target_args'_v158 = v164 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v167 : (System.DateTime -> int64) = _.Ticks
            let v168 : int64 = v167 v150
            let _run_target_args'_v158 = v168 
            #endif
#if FABLE_COMPILER_PYTHON
            let v169 : (System.DateTime -> int64) = _.Ticks
            let v170 : int64 = v169 v150
            let _run_target_args'_v158 = v170 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v171 : (System.DateTime -> int64) = _.Ticks
            let v172 : int64 = v171 v150
            let _run_target_args'_v158 = v172 
            #endif
#else
            let v173 : (System.DateTime -> int64) = _.Ticks
            let v174 : int64 = v173 v150
            let _run_target_args'_v158 = v174 
            #endif
            let v175 : int64 = _run_target_args'_v158 
            let v196 : int64 = v175 |> int64 
            US4_0(v196)
    struct (v127, v200)
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
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure6()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v24 : Mut0, v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : int64 option) = TraceState.trace_state.Value
    let v42 : US3 = v28.l0
    let v43 : bool = v26.l0
    let v44 : bool = v43 = false
    if v44 then
        false
    else
        let v45 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v0
        let v46 : int32 = [ US3_0, 0; US3_1, 1; US3_2, 2; US3_3, 3; US3_4, 4 ] |> Map |> Map.find v42
        let v47 : bool = v45 >= v46
        v47
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
    let v173 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v176 : (int64 -> US4) = method11()
    let v177 : US4 option = v5 |> Option.map v176 
    let v197 : US4 = US4_1
    let v198 : US4 = v177 |> Option.defaultValue v197 
    let v316 : System.DateTime =
        match v198 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v299 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v300 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v299 = v300 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v301 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v299 = v301 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v303 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v299 = v303 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v306 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v299 = v306 
            #endif
#if FABLE_COMPILER_PYTHON
            let v307 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v299 = v307 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v308 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v299 = v308 
            #endif
#else
            let v309 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v299 = v309 
            #endif
            let v310 : System.DateTime = _run_target_args'_v299 
            v310
        | US4_0(v202) -> (* Some *)
            (* run_target_args'
            let v205 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v206 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v205 = v206 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v207 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v205 = v207 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v209 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v205 = v209 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v212 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v205 = v212 
            #endif
#if FABLE_COMPILER_PYTHON
            let v213 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v205 = v213 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v214 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v205 = v214 
            #endif
#else
            let v215 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v205 = v215 
            #endif
            let v216 : System.DateTime = _run_target_args'_v205 
            (* run_target_args'
            let v224 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v225 : (System.DateTime -> int64) = _.Ticks
            let v226 : int64 = v225 v216
            let _run_target_args'_v224 = v226 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v227 : (System.DateTime -> int64) = _.Ticks
            let v228 : int64 = v227 v216
            let _run_target_args'_v224 = v228 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v230 : int64 = null |> unbox<int64>
            let _run_target_args'_v224 = v230 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v233 : (System.DateTime -> int64) = _.Ticks
            let v234 : int64 = v233 v216
            let _run_target_args'_v224 = v234 
            #endif
#if FABLE_COMPILER_PYTHON
            let v235 : (System.DateTime -> int64) = _.Ticks
            let v236 : int64 = v235 v216
            let _run_target_args'_v224 = v236 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v237 : (System.DateTime -> int64) = _.Ticks
            let v238 : int64 = v237 v216
            let _run_target_args'_v224 = v238 
            #endif
#else
            let v239 : (System.DateTime -> int64) = _.Ticks
            let v240 : int64 = v239 v216
            let _run_target_args'_v224 = v240 
            #endif
            let v241 : int64 = _run_target_args'_v224 
            let v262 : int64 = v241 |> int64 
            let v265 : int64 = v262 - v202
            let v268 : System.TimeSpan = v265 |> System.TimeSpan 
            let v274 : (System.TimeSpan -> int32) = _.Hours
            let v275 : int32 = v274 v268
            let v279 : (System.TimeSpan -> int32) = _.Minutes
            let v280 : int32 = v279 v268
            let v284 : (System.TimeSpan -> int32) = _.Seconds
            let v285 : int32 = v284 v268
            let v289 : (System.TimeSpan -> int32) = _.Milliseconds
            let v290 : int32 = v289 v268
            let v294 : System.DateTime = System.DateTime (1, 1, 1, v275, v280, v285, v290)
            v294
    let v318 : string = method12()
    let v322 : bool = v318 = ""
    let v324 : string =
        if v322 then
            let v323 : string = "M-d-y hh:mm:ss tt"
            v323
        else
            v318
    let v325 : (string -> string) = v316.ToString
    let v326 : string = v325 v324
    let _run_target_args'_v173 = v326 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v343 : (int64 -> US4) = method11()
    let v344 : US4 option = v5 |> Option.map v343 
    let v364 : US4 = US4_1
    let v365 : US4 = v344 |> Option.defaultValue v364 
    let v483 : System.DateTime =
        match v365 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v466 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v467 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v466 = v467 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v468 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v466 = v468 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v470 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v466 = v470 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v473 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v466 = v473 
            #endif
#if FABLE_COMPILER_PYTHON
            let v474 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v466 = v474 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v475 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v466 = v475 
            #endif
#else
            let v476 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v466 = v476 
            #endif
            let v477 : System.DateTime = _run_target_args'_v466 
            v477
        | US4_0(v369) -> (* Some *)
            (* run_target_args'
            let v372 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v373 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v372 = v373 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v374 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v372 = v374 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v376 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v372 = v376 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v379 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v372 = v379 
            #endif
#if FABLE_COMPILER_PYTHON
            let v380 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v372 = v380 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v381 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v372 = v381 
            #endif
#else
            let v382 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v372 = v382 
            #endif
            let v383 : System.DateTime = _run_target_args'_v372 
            (* run_target_args'
            let v391 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v392 : (System.DateTime -> int64) = _.Ticks
            let v393 : int64 = v392 v383
            let _run_target_args'_v391 = v393 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v394 : (System.DateTime -> int64) = _.Ticks
            let v395 : int64 = v394 v383
            let _run_target_args'_v391 = v395 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v397 : int64 = null |> unbox<int64>
            let _run_target_args'_v391 = v397 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v400 : (System.DateTime -> int64) = _.Ticks
            let v401 : int64 = v400 v383
            let _run_target_args'_v391 = v401 
            #endif
#if FABLE_COMPILER_PYTHON
            let v402 : (System.DateTime -> int64) = _.Ticks
            let v403 : int64 = v402 v383
            let _run_target_args'_v391 = v403 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v404 : (System.DateTime -> int64) = _.Ticks
            let v405 : int64 = v404 v383
            let _run_target_args'_v391 = v405 
            #endif
#else
            let v406 : (System.DateTime -> int64) = _.Ticks
            let v407 : int64 = v406 v383
            let _run_target_args'_v391 = v407 
            #endif
            let v408 : int64 = _run_target_args'_v391 
            let v429 : int64 = v408 |> int64 
            let v432 : int64 = v429 - v369
            let v435 : System.TimeSpan = v432 |> System.TimeSpan 
            let v441 : (System.TimeSpan -> int32) = _.Hours
            let v442 : int32 = v441 v435
            let v446 : (System.TimeSpan -> int32) = _.Minutes
            let v447 : int32 = v446 v435
            let v451 : (System.TimeSpan -> int32) = _.Seconds
            let v452 : int32 = v451 v435
            let v456 : (System.TimeSpan -> int32) = _.Milliseconds
            let v457 : int32 = v456 v435
            let v461 : System.DateTime = System.DateTime (1, 1, 1, v442, v447, v452, v457)
            v461
    let v485 : string = method12()
    let v489 : bool = v485 = ""
    let v491 : string =
        if v489 then
            let v490 : string = "M-d-y hh:mm:ss tt"
            v490
        else
            v485
    let v492 : (string -> string) = v483.ToString
    let v493 : string = v492 v491
    let _run_target_args'_v173 = v493 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v508 : string = $"near_sdk::env::block_timestamp()"
    let v509 : uint64 = Fable.Core.RustInterop.emitRustExpr () v508 
    let v512 : (int64 -> US4) = method11()
    let v513 : US4 option = v5 |> Option.map v512 
    let v533 : US4 = US4_1
    let v534 : US4 = v513 |> Option.defaultValue v533 
    let v546 : uint64 =
        match v534 with
        | US4_1 -> (* None *)
            v509
        | US4_0(v538) -> (* Some *)
            let v540 : (int64 -> uint64) = uint64
            let v541 : uint64 = v540 v538
            let v544 : uint64 = v509 - v541
            v544
    let v547 : uint64 = v546 / 1000000000UL
    let v548 : uint64 = v547 % 60UL
    let v549 : uint64 = v547 / 60UL
    let v550 : uint64 = v549 % 60UL
    let v551 : uint64 = v547 / 3600UL
    let v552 : uint64 = v551 % 24UL
    let v553 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v554 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v552, v550, v548) v553 
    let v555 : string = "fable_library_rust::String_::fromString($0)"
    let v556 : string = Fable.Core.RustInterop.emitRustExpr v554 v555 
    let _run_target_args'_v173 = v556 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v559 : (int64 -> US4) = method11()
    let v560 : US4 option = v5 |> Option.map v559 
    let v580 : US4 = US4_1
    let v581 : US4 = v560 |> Option.defaultValue v580 
    let v699 : System.DateTime =
        match v581 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v682 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v683 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v682 = v683 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v684 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v682 = v684 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v686 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v682 = v686 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v689 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v682 = v689 
            #endif
#if FABLE_COMPILER_PYTHON
            let v690 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v682 = v690 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v691 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v682 = v691 
            #endif
#else
            let v692 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v682 = v692 
            #endif
            let v693 : System.DateTime = _run_target_args'_v682 
            v693
        | US4_0(v585) -> (* Some *)
            (* run_target_args'
            let v588 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v589 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v588 = v589 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v590 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v588 = v590 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v592 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v588 = v592 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v595 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v588 = v595 
            #endif
#if FABLE_COMPILER_PYTHON
            let v596 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v588 = v596 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v597 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v588 = v597 
            #endif
#else
            let v598 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v588 = v598 
            #endif
            let v599 : System.DateTime = _run_target_args'_v588 
            (* run_target_args'
            let v607 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v608 : (System.DateTime -> int64) = _.Ticks
            let v609 : int64 = v608 v599
            let _run_target_args'_v607 = v609 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v610 : (System.DateTime -> int64) = _.Ticks
            let v611 : int64 = v610 v599
            let _run_target_args'_v607 = v611 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v613 : int64 = null |> unbox<int64>
            let _run_target_args'_v607 = v613 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v616 : (System.DateTime -> int64) = _.Ticks
            let v617 : int64 = v616 v599
            let _run_target_args'_v607 = v617 
            #endif
#if FABLE_COMPILER_PYTHON
            let v618 : (System.DateTime -> int64) = _.Ticks
            let v619 : int64 = v618 v599
            let _run_target_args'_v607 = v619 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v620 : (System.DateTime -> int64) = _.Ticks
            let v621 : int64 = v620 v599
            let _run_target_args'_v607 = v621 
            #endif
#else
            let v622 : (System.DateTime -> int64) = _.Ticks
            let v623 : int64 = v622 v599
            let _run_target_args'_v607 = v623 
            #endif
            let v624 : int64 = _run_target_args'_v607 
            let v645 : int64 = v624 |> int64 
            let v648 : int64 = v645 - v585
            let v651 : System.TimeSpan = v648 |> System.TimeSpan 
            let v657 : (System.TimeSpan -> int32) = _.Hours
            let v658 : int32 = v657 v651
            let v662 : (System.TimeSpan -> int32) = _.Minutes
            let v663 : int32 = v662 v651
            let v667 : (System.TimeSpan -> int32) = _.Seconds
            let v668 : int32 = v667 v651
            let v672 : (System.TimeSpan -> int32) = _.Milliseconds
            let v673 : int32 = v672 v651
            let v677 : System.DateTime = System.DateTime (1, 1, 1, v658, v663, v668, v673)
            v677
    let v701 : string = method13()
    let v705 : bool = v701 = ""
    let v707 : string =
        if v705 then
            let v706 : string = "M-d-y hh:mm:ss tt"
            v706
        else
            v701
    let v708 : (string -> string) = v699.ToString
    let v709 : string = v708 v707
    let _run_target_args'_v173 = v709 
    #endif
#if FABLE_COMPILER_PYTHON
    let v726 : (int64 -> US4) = method11()
    let v727 : US4 option = v5 |> Option.map v726 
    let v747 : US4 = US4_1
    let v748 : US4 = v727 |> Option.defaultValue v747 
    let v866 : System.DateTime =
        match v748 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v849 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v850 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v849 = v850 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v851 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v849 = v851 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v853 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v849 = v853 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v856 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v849 = v856 
            #endif
#if FABLE_COMPILER_PYTHON
            let v857 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v849 = v857 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v858 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v849 = v858 
            #endif
#else
            let v859 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v849 = v859 
            #endif
            let v860 : System.DateTime = _run_target_args'_v849 
            v860
        | US4_0(v752) -> (* Some *)
            (* run_target_args'
            let v755 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v756 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v755 = v756 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v757 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v755 = v757 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v759 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v755 = v759 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v762 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v755 = v762 
            #endif
#if FABLE_COMPILER_PYTHON
            let v763 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v755 = v763 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v764 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v755 = v764 
            #endif
#else
            let v765 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v755 = v765 
            #endif
            let v766 : System.DateTime = _run_target_args'_v755 
            (* run_target_args'
            let v774 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v775 : (System.DateTime -> int64) = _.Ticks
            let v776 : int64 = v775 v766
            let _run_target_args'_v774 = v776 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v777 : (System.DateTime -> int64) = _.Ticks
            let v778 : int64 = v777 v766
            let _run_target_args'_v774 = v778 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v780 : int64 = null |> unbox<int64>
            let _run_target_args'_v774 = v780 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v783 : (System.DateTime -> int64) = _.Ticks
            let v784 : int64 = v783 v766
            let _run_target_args'_v774 = v784 
            #endif
#if FABLE_COMPILER_PYTHON
            let v785 : (System.DateTime -> int64) = _.Ticks
            let v786 : int64 = v785 v766
            let _run_target_args'_v774 = v786 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v787 : (System.DateTime -> int64) = _.Ticks
            let v788 : int64 = v787 v766
            let _run_target_args'_v774 = v788 
            #endif
#else
            let v789 : (System.DateTime -> int64) = _.Ticks
            let v790 : int64 = v789 v766
            let _run_target_args'_v774 = v790 
            #endif
            let v791 : int64 = _run_target_args'_v774 
            let v812 : int64 = v791 |> int64 
            let v815 : int64 = v812 - v752
            let v818 : System.TimeSpan = v815 |> System.TimeSpan 
            let v824 : (System.TimeSpan -> int32) = _.Hours
            let v825 : int32 = v824 v818
            let v829 : (System.TimeSpan -> int32) = _.Minutes
            let v830 : int32 = v829 v818
            let v834 : (System.TimeSpan -> int32) = _.Seconds
            let v835 : int32 = v834 v818
            let v839 : (System.TimeSpan -> int32) = _.Milliseconds
            let v840 : int32 = v839 v818
            let v844 : System.DateTime = System.DateTime (1, 1, 1, v825, v830, v835, v840)
            v844
    let v868 : string = method13()
    let v872 : bool = v868 = ""
    let v874 : string =
        if v872 then
            let v873 : string = "M-d-y hh:mm:ss tt"
            v873
        else
            v868
    let v875 : (string -> string) = v866.ToString
    let v876 : string = v875 v874
    let _run_target_args'_v173 = v876 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v893 : (int64 -> US4) = method11()
    let v894 : US4 option = v5 |> Option.map v893 
    let v914 : US4 = US4_1
    let v915 : US4 = v894 |> Option.defaultValue v914 
    let v1033 : System.DateTime =
        match v915 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1016 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1017 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1016 = v1017 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1018 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1016 = v1018 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1020 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1016 = v1020 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1023 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1016 = v1023 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1024 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1016 = v1024 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1025 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1016 = v1025 
            #endif
#else
            let v1026 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1016 = v1026 
            #endif
            let v1027 : System.DateTime = _run_target_args'_v1016 
            v1027
        | US4_0(v919) -> (* Some *)
            (* run_target_args'
            let v922 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v923 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v922 = v923 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v924 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v922 = v924 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v926 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v922 = v926 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v929 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v922 = v929 
            #endif
#if FABLE_COMPILER_PYTHON
            let v930 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v922 = v930 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v931 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v922 = v931 
            #endif
#else
            let v932 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v922 = v932 
            #endif
            let v933 : System.DateTime = _run_target_args'_v922 
            (* run_target_args'
            let v941 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v942 : (System.DateTime -> int64) = _.Ticks
            let v943 : int64 = v942 v933
            let _run_target_args'_v941 = v943 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v944 : (System.DateTime -> int64) = _.Ticks
            let v945 : int64 = v944 v933
            let _run_target_args'_v941 = v945 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v947 : int64 = null |> unbox<int64>
            let _run_target_args'_v941 = v947 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v950 : (System.DateTime -> int64) = _.Ticks
            let v951 : int64 = v950 v933
            let _run_target_args'_v941 = v951 
            #endif
#if FABLE_COMPILER_PYTHON
            let v952 : (System.DateTime -> int64) = _.Ticks
            let v953 : int64 = v952 v933
            let _run_target_args'_v941 = v953 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v954 : (System.DateTime -> int64) = _.Ticks
            let v955 : int64 = v954 v933
            let _run_target_args'_v941 = v955 
            #endif
#else
            let v956 : (System.DateTime -> int64) = _.Ticks
            let v957 : int64 = v956 v933
            let _run_target_args'_v941 = v957 
            #endif
            let v958 : int64 = _run_target_args'_v941 
            let v979 : int64 = v958 |> int64 
            let v982 : int64 = v979 - v919
            let v985 : System.TimeSpan = v982 |> System.TimeSpan 
            let v991 : (System.TimeSpan -> int32) = _.Hours
            let v992 : int32 = v991 v985
            let v996 : (System.TimeSpan -> int32) = _.Minutes
            let v997 : int32 = v996 v985
            let v1001 : (System.TimeSpan -> int32) = _.Seconds
            let v1002 : int32 = v1001 v985
            let v1006 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1007 : int32 = v1006 v985
            let v1011 : System.DateTime = System.DateTime (1, 1, 1, v992, v997, v1002, v1007)
            v1011
    let v1035 : string = method13()
    let v1039 : bool = v1035 = ""
    let v1041 : string =
        if v1039 then
            let v1040 : string = "M-d-y hh:mm:ss tt"
            v1040
        else
            v1035
    let v1042 : (string -> string) = v1033.ToString
    let v1043 : string = v1042 v1041
    let _run_target_args'_v173 = v1043 
    #endif
#else
    let v1060 : (int64 -> US4) = method11()
    let v1061 : US4 option = v5 |> Option.map v1060 
    let v1081 : US4 = US4_1
    let v1082 : US4 = v1061 |> Option.defaultValue v1081 
    let v1200 : System.DateTime =
        match v1082 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1183 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1184 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1183 = v1184 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1185 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1183 = v1185 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1187 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1183 = v1187 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1190 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1183 = v1190 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1191 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1183 = v1191 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1192 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1183 = v1192 
            #endif
#else
            let v1193 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1183 = v1193 
            #endif
            let v1194 : System.DateTime = _run_target_args'_v1183 
            v1194
        | US4_0(v1086) -> (* Some *)
            (* run_target_args'
            let v1089 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1090 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1089 = v1090 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1091 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1089 = v1091 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1093 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1089 = v1093 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1096 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1089 = v1096 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1097 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1089 = v1097 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1098 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1089 = v1098 
            #endif
#else
            let v1099 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1089 = v1099 
            #endif
            let v1100 : System.DateTime = _run_target_args'_v1089 
            (* run_target_args'
            let v1108 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1109 : (System.DateTime -> int64) = _.Ticks
            let v1110 : int64 = v1109 v1100
            let _run_target_args'_v1108 = v1110 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1111 : (System.DateTime -> int64) = _.Ticks
            let v1112 : int64 = v1111 v1100
            let _run_target_args'_v1108 = v1112 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1114 : int64 = null |> unbox<int64>
            let _run_target_args'_v1108 = v1114 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1117 : (System.DateTime -> int64) = _.Ticks
            let v1118 : int64 = v1117 v1100
            let _run_target_args'_v1108 = v1118 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1119 : (System.DateTime -> int64) = _.Ticks
            let v1120 : int64 = v1119 v1100
            let _run_target_args'_v1108 = v1120 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1121 : (System.DateTime -> int64) = _.Ticks
            let v1122 : int64 = v1121 v1100
            let _run_target_args'_v1108 = v1122 
            #endif
#else
            let v1123 : (System.DateTime -> int64) = _.Ticks
            let v1124 : int64 = v1123 v1100
            let _run_target_args'_v1108 = v1124 
            #endif
            let v1125 : int64 = _run_target_args'_v1108 
            let v1146 : int64 = v1125 |> int64 
            let v1149 : int64 = v1146 - v1086
            let v1152 : System.TimeSpan = v1149 |> System.TimeSpan 
            let v1158 : (System.TimeSpan -> int32) = _.Hours
            let v1159 : int32 = v1158 v1152
            let v1163 : (System.TimeSpan -> int32) = _.Minutes
            let v1164 : int32 = v1163 v1152
            let v1168 : (System.TimeSpan -> int32) = _.Seconds
            let v1169 : int32 = v1168 v1152
            let v1173 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1174 : int32 = v1173 v1152
            let v1178 : System.DateTime = System.DateTime (1, 1, 1, v1159, v1164, v1169, v1174)
            v1178
    let v1202 : string = method13()
    let v1206 : bool = v1202 = ""
    let v1208 : string =
        if v1206 then
            let v1207 : string = "M-d-y hh:mm:ss tt"
            v1207
        else
            v1202
    let v1209 : (string -> string) = v1200.ToString
    let v1210 : string = v1209 v1208
    let _run_target_args'_v173 = v1210 
    #endif
    let v1225 : string = _run_target_args'_v173 
    v1225
and method16 () : string =
    let v0 : string = ""
    v0
and closure8 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and method15 (v0 : char) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure8(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = v2.l0
    v12
and method17 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method14 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method15(v7)
    (* run_target_args'
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "inline_colorization::color_bright_black"
    let v15 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v14 
    (* run_target_args'
    let v20 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v21 : string = "&*$0"
    let v22 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v21 
    let _run_target_args'_v20 = v22 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v23 : string = "&*$0"
    let v24 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v23 
    let _run_target_args'_v20 = v24 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v25 : string = "&*$0"
    let v26 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v25 
    let _run_target_args'_v20 = v26 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v28 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v28 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v36 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v36 
    #endif
#else
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v40 
    #endif
    let v43 : Ref<Str> = _run_target_args'_v20 
    let v49 : string = "inline_colorization::color_reset"
    let v50 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v49 
    let v51 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v15, v43, v50) v51 
    let v53 : string = "fable_library_rust::String_::fromString($0)"
    let v54 : string = Fable.Core.RustInterop.emitRustExpr v52 v53 
    let _run_target_args'_v13 = v54 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v55 : string = "inline_colorization::color_bright_black"
    let v56 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v55 
    (* run_target_args'
    let v61 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v62 : string = "&*$0"
    let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v62 
    let _run_target_args'_v61 = v63 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v64 : string = "&*$0"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v64 
    let _run_target_args'_v61 = v65 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v66 : string = "&*$0"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v66 
    let _run_target_args'_v61 = v67 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v69 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v69 
    #endif
#if FABLE_COMPILER_PYTHON
    let v73 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v73 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v77 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v77 
    #endif
#else
    let v81 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v81 
    #endif
    let v84 : Ref<Str> = _run_target_args'_v61 
    let v90 : string = "inline_colorization::color_reset"
    let v91 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v90 
    let v92 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v93 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v56, v84, v91) v92 
    let v94 : string = "fable_library_rust::String_::fromString($0)"
    let v95 : string = Fable.Core.RustInterop.emitRustExpr v93 v94 
    let _run_target_args'_v13 = v95 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v96 : string = "inline_colorization::color_bright_black"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v96 
    (* run_target_args'
    let v102 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v103 
    let _run_target_args'_v102 = v104 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v105 : string = "&*$0"
    let v106 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v105 
    let _run_target_args'_v102 = v106 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v107 : string = "&*$0"
    let v108 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v107 
    let _run_target_args'_v102 = v108 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v110 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v110 
    #endif
#if FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v114 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v118 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v118 
    #endif
#else
    let v122 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v122 
    #endif
    let v125 : Ref<Str> = _run_target_args'_v102 
    let v131 : string = "inline_colorization::color_reset"
    let v132 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v131 
    let v133 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v134 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v97, v125, v132) v133 
    let v135 : string = "fable_library_rust::String_::fromString($0)"
    let v136 : string = Fable.Core.RustInterop.emitRustExpr v134 v135 
    let _run_target_args'_v13 = v136 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v137 : string = "\u001b[90m"
    let v138 : string = method17()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[90m"
    let v142 : string = method17()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[90m"
    let v146 : string = method17()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[90m"
    let v150 : string = method17()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method19 (v0 : (string [])) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "args"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure8(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure8(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    let v37 : string = $"%A{v0}"
    let v41 : string = $"{v37}"
    let v44 : unit = ()
    let v45 : (unit -> unit) = closure8(v2, v41)
    let v46 : unit = (fun () -> v45 (); v44) ()
    let v51 : string = " }"
    let v52 : string = $"{v51}"
    let v55 : unit = ()
    let v56 : (unit -> unit) = closure8(v2, v52)
    let v57 : unit = (fun () -> v56 (); v55) ()
    let v60 : string = v2.l0
    v60
and method20 (v0 : string) : string =
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
and method18 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : (string [])) : string =
    let v9 : string = method19(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "spiral_wasm.main"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method20(v13)
and closure9 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure11 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure10 () (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure11(v0)
    let v3 : unit = (fun () -> v2 (); v1) ()
    ()
and method21 (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure6()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v24 : Mut0, v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : int64 option) = TraceState.trace_state.Value
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure9(v24)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v47 : (string -> unit) = closure10()
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v49 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v50 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = v27.l0
    let v52 : bool = v51 = ""
    let v60 : string =
        if v52 then
            v0
        else
            let v53 : bool = v0 = ""
            if v53 then
                let v54 : string = v27.l0
                v54
            else
                let v55 : string = v27.l0
                let v56 : string = "\n"
                let v57 : string = v55 + v56 
                let v58 : string = v57 + v0 
                v58
    (* run_target_args'
    let v65 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v66 : string = "&*$0"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v60 v66 
    let _run_target_args'_v65 = v67 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v68 : string = "&*$0"
    let v69 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v60 v68 
    let _run_target_args'_v65 = v69 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v70 : string = "&*$0"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v60 v70 
    let _run_target_args'_v65 = v71 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v73 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v73 
    #endif
#if FABLE_COMPILER_PYTHON
    let v77 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v77 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v81 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v81 
    #endif
#else
    let v85 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v85 
    #endif
    let v88 : Ref<Str> = _run_target_args'_v65 
    let v94 : string = $"$0.chars()"
    let v95 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v88 v94 
    let v96 : string = "$0"
    let v97 : _ = Fable.Core.RustInterop.emitRustExpr v95 v96 
    let v98 : string = "$0.collect::<Vec<_>>()"
    let v99 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v97 v98 
    let v100 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v101 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v99 v100 
    let v102 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v103 : bool = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let v104 : string = "x"
    let v105 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v104 
    let v106 : string = "String::from_iter($0)"
    let v107 : std_string_String = Fable.Core.RustInterop.emitRustExpr v105 v106 
    let v108 : string = "true; $0 }).collect::<Vec<_>>()"
    let v109 : bool = Fable.Core.RustInterop.emitRustExpr v107 v108 
    let v110 : string = "_vec_map"
    let v111 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v110 
    let v112 : string = "$0.len()"
    let v113 : unativeint = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let v119 : int32 = v113 |> int32 
    let v129 : string = ""
    let v130 : bool = v0 <> v129 
    let v134 : bool =
        if v130 then
            let v133 : bool = v119 <= 1
            v133
        else
            false
    if v134 then
        v27.l0 <- v60
        ()
    else
        v27.l0 <- v129
        let v135 : string = "true; $0.into_iter().for_each(|x| { //"
        let v136 : bool = Fable.Core.RustInterop.emitRustExpr v111 v135 
        let v137 : string = "x"
        let v138 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v137 
        let v139 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v140 : bool = Fable.Core.RustInterop.emitRustExpr v138 v139 
        let v141 : string = $"true"
        let v142 : bool = Fable.Core.RustInterop.emitRustExpr () v141 
        let v143 : string = "true; }); //"
        let v144 : bool = Fable.Core.RustInterop.emitRustExpr () v143 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v47 v0
    #endif
#if FABLE_COMPILER_PYTHON
    v47 v0
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v47 v0
    #endif
#else
    v47 v0
    #endif
    // run_target_args' is_unit
    let v145 : (string -> unit) = v25.l0
    v145 v0
and closure5 (v0 : (string [])) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure6()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method10(v26, v27, v28, v29, v30, v31)
        let v45 : string = method14()
        let v46 : string = method18(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method21(v46)
and method22 () : string =
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
and method23 () : (std_string_String -> string) =
    closure12()
and method25 () : string =
    let v0 : string = "wasm"
    v0
and method27 (v0 : string) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "wasm_path"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure8(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure8(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    let v37 : string = $"{v0}"
    let v40 : unit = ()
    let v41 : (unit -> unit) = closure8(v2, v37)
    let v42 : unit = (fun () -> v41 (); v40) ()
    let v47 : string = " }"
    let v48 : string = $"{v47}"
    let v51 : unit = ()
    let v52 : (unit -> unit) = closure8(v2, v48)
    let v53 : unit = (fun () -> v52 (); v51) ()
    let v56 : string = v2.l0
    v56
and method26 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method27(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "spiral_wasm.run"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method20(v13)
and closure13 (v0 : string) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure6()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method10(v26, v27, v28, v29, v30, v31)
        let v45 : string = method14()
        let v46 : string = method26(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method21(v46)
and method31 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) : string =
    let v3 : string = method16()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v11 : unit = ()
    let v12 : (unit -> unit) = closure8(v4, v8)
    let v13 : unit = (fun () -> v12 (); v11) ()
    let v18 : string = "retry"
    let v19 : string = $"{v18}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v4, v19)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v29 : string = " = "
    let v30 : string = $"{v29}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure8(v4, v30)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v39 : string = $"{v0}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v4, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v49 : string = "; "
    let v50 : string = $"{v49}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure8(v4, v50)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v60 : string = "worker"
    let v61 : string = $"{v60}"
    let v64 : unit = ()
    let v65 : (unit -> unit) = closure8(v4, v61)
    let v66 : unit = (fun () -> v65 (); v64) ()
    let v70 : string = $"{v29}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v4, v70)
    let v75 : unit = (fun () -> v74 (); v73) ()
    (* run_target_args'
    let v82 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v83 : string = "format!(\"{:#?}\", $0)"
    let v84 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v83 
    let v85 : string = "fable_library_rust::String_::fromString($0)"
    let v86 : string = Fable.Core.RustInterop.emitRustExpr v84 v85 
    let _run_target_args'_v82 = v86 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v87 : string = "format!(\"{:#?}\", $0)"
    let v88 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v87 
    let v89 : string = "fable_library_rust::String_::fromString($0)"
    let v90 : string = Fable.Core.RustInterop.emitRustExpr v88 v89 
    let _run_target_args'_v82 = v90 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v91 : string = "format!(\"{:#?}\", $0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v91 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v82 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : string = $"%A{v1}"
    let _run_target_args'_v82 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : string = $"%A{v1}"
    let _run_target_args'_v82 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : string = $"%A{v1}"
    let _run_target_args'_v82 = v104 
    #endif
#else
    let v108 : string = $"%A{v1}"
    let _run_target_args'_v82 = v108 
    #endif
    let v111 : string = _run_target_args'_v82 
    let v118 : string = $"{v111}"
    let v121 : unit = ()
    let v122 : (unit -> unit) = closure8(v4, v118)
    let v123 : unit = (fun () -> v122 (); v121) ()
    let v127 : string = $"{v49}"
    let v130 : unit = ()
    let v131 : (unit -> unit) = closure8(v4, v127)
    let v132 : unit = (fun () -> v131 (); v130) ()
    let v137 : string = "contract"
    let v138 : string = $"{v137}"
    let v141 : unit = ()
    let v142 : (unit -> unit) = closure8(v4, v138)
    let v143 : unit = (fun () -> v142 (); v141) ()
    let v147 : string = $"{v29}"
    let v150 : unit = ()
    let v151 : (unit -> unit) = closure8(v4, v147)
    let v152 : unit = (fun () -> v151 (); v150) ()
    (* run_target_args'
    let v159 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v160 : string = "format!(\"{:#?}\", $0)"
    let v161 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v160 
    let v162 : string = "fable_library_rust::String_::fromString($0)"
    let v163 : string = Fable.Core.RustInterop.emitRustExpr v161 v162 
    let _run_target_args'_v159 = v163 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v164 : string = "format!(\"{:#?}\", $0)"
    let v165 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v164 
    let v166 : string = "fable_library_rust::String_::fromString($0)"
    let v167 : string = Fable.Core.RustInterop.emitRustExpr v165 v166 
    let _run_target_args'_v159 = v167 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v168 : string = "format!(\"{:#?}\", $0)"
    let v169 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v168 
    let v170 : string = "fable_library_rust::String_::fromString($0)"
    let v171 : string = Fable.Core.RustInterop.emitRustExpr v169 v170 
    let _run_target_args'_v159 = v171 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v173 : string = $"%A{v2}"
    let _run_target_args'_v159 = v173 
    #endif
#if FABLE_COMPILER_PYTHON
    let v177 : string = $"%A{v2}"
    let _run_target_args'_v159 = v177 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v181 : string = $"%A{v2}"
    let _run_target_args'_v159 = v181 
    #endif
#else
    let v185 : string = $"%A{v2}"
    let _run_target_args'_v159 = v185 
    #endif
    let v188 : string = _run_target_args'_v159 
    let v195 : string = $"{v188}"
    let v198 : unit = ()
    let v199 : (unit -> unit) = closure8(v4, v195)
    let v200 : unit = (fun () -> v199 (); v198) ()
    let v205 : string = " }"
    let v206 : string = $"{v205}"
    let v209 : unit = ()
    let v210 : (unit -> unit) = closure8(v4, v206)
    let v211 : unit = (fun () -> v210 (); v209) ()
    let v214 : string = v4.l0
    v214
and method30 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v10 : near_workspaces_Contract) : string =
    let v11 : string = method31(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v14 : string = "spiral_wasm.run"
    let v15 : string = $"{v6} {v7} #{v12} %s{v14} / {v11}"
    method20(v15)
and closure14 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) () : unit =
    let v3 : US3 = US3_0
    let v4 : bool = method9(v3)
    if v4 then
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure6()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut0, v29 : Mut1, v30 : Mut2, v31 : Mut3, v32 : Mut4, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method10(v28, v29, v30, v31, v32, v33)
        let v47 : string = method14()
        let v48 : string = method30(v28, v29, v30, v31, v32, v33, v46, v47, v0, v1, v2)
        method21(v48)
and method33 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) : string =
    let v2 : string = method16()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure8(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "retry"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure8(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure8(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "result"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure8(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure8(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    (* run_target_args'
    let v81 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v82 : string = "format!(\"{:#?}\", $0)"
    let v83 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v82 
    let v84 : string = "fable_library_rust::String_::fromString($0)"
    let v85 : string = Fable.Core.RustInterop.emitRustExpr v83 v84 
    let _run_target_args'_v81 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "format!(\"{:#?}\", $0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v86 
    let v88 : string = "fable_library_rust::String_::fromString($0)"
    let v89 : string = Fable.Core.RustInterop.emitRustExpr v87 v88 
    let _run_target_args'_v81 = v89 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v90 : string = "format!(\"{:#?}\", $0)"
    let v91 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v90 
    let v92 : string = "fable_library_rust::String_::fromString($0)"
    let v93 : string = Fable.Core.RustInterop.emitRustExpr v91 v92 
    let _run_target_args'_v81 = v93 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v95 : string = $"%A{v1}"
    let _run_target_args'_v81 = v95 
    #endif
#if FABLE_COMPILER_PYTHON
    let v99 : string = $"%A{v1}"
    let _run_target_args'_v81 = v99 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v103 : string = $"%A{v1}"
    let _run_target_args'_v81 = v103 
    #endif
#else
    let v107 : string = $"%A{v1}"
    let _run_target_args'_v81 = v107 
    #endif
    let v110 : string = _run_target_args'_v81 
    let v117 : string = $"{v110}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure8(v3, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v127 : string = " }"
    let v128 : string = $"{v127}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure8(v3, v128)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v136 : string = v3.l0
    v136
and method32 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_result_ExecutionFinalResult) : string =
    let v10 : string = method33(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "spiral_wasm.run"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method20(v14)
and closure15 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) () : unit =
    let v2 : US3 = US3_0
    let v3 : bool = method9(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure6()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method10(v27, v28, v29, v30, v31, v32)
        let v46 : string = method14()
        let v47 : string = method32(v27, v28, v29, v30, v31, v32, v45, v46, v0, v1)
        method21(v47)
and closure17 (v0 : std_string_String) () : unit =
    let v1 : (std_string_String -> unit) = System.Console.WriteLine
    v1 v0
and closure16 () (v0 : std_string_String) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure17(v0)
    let v3 : unit = (fun () -> v2 (); v1) ()
    ()
and method34 () : unit =
    let v0 : unit = ()
    let v1 : (unit -> unit) = closure6()
    let v2 : unit = (fun () -> v1 (); v0) ()
    let struct (v23 : Mut0, v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : int64 option) = TraceState.trace_state.Value
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure9(v23)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v46 : string = " "
    let v47 : (string -> unit) = closure10()
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v46 v49 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v50 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v46 v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = v26.l0
    let v52 : bool = v51 = ""
    let v60 : string =
        if v52 then
            v46
        else
            let v53 : bool = v46 = ""
            if v53 then
                let v54 : string = v26.l0
                v54
            else
                let v55 : string = v26.l0
                let v56 : string = "\n"
                let v57 : string = v55 + v56 
                let v58 : string = v57 + v46 
                v58
    (* run_target_args'
    let v65 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v66 : string = "&*$0"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v60 v66 
    let _run_target_args'_v65 = v67 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v68 : string = "&*$0"
    let v69 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v60 v68 
    let _run_target_args'_v65 = v69 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v70 : string = "&*$0"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v60 v70 
    let _run_target_args'_v65 = v71 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v73 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v73 
    #endif
#if FABLE_COMPILER_PYTHON
    let v77 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v77 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v81 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v81 
    #endif
#else
    let v85 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v85 
    #endif
    let v88 : Ref<Str> = _run_target_args'_v65 
    let v94 : string = $"$0.chars()"
    let v95 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v88 v94 
    let v96 : string = "$0"
    let v97 : _ = Fable.Core.RustInterop.emitRustExpr v95 v96 
    let v98 : string = "$0.collect::<Vec<_>>()"
    let v99 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v97 v98 
    let v100 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v101 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v99 v100 
    let v102 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v103 : bool = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let v104 : string = "x"
    let v105 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v104 
    let v106 : string = "String::from_iter($0)"
    let v107 : std_string_String = Fable.Core.RustInterop.emitRustExpr v105 v106 
    let v108 : string = "true; $0 }).collect::<Vec<_>>()"
    let v109 : bool = Fable.Core.RustInterop.emitRustExpr v107 v108 
    let v110 : string = "_vec_map"
    let v111 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v110 
    let v112 : string = "$0.len()"
    let v113 : unativeint = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let v119 : int32 = v113 |> int32 
    let v129 : string = ""
    let v130 : bool = v46 <> v129 
    let v134 : bool =
        if v130 then
            let v133 : bool = v119 <= 1
            v133
        else
            false
    if v134 then
        v26.l0 <- v60
        ()
    else
        v26.l0 <- v129
        let v135 : string = "true; $0.into_iter().for_each(|x| { //"
        let v136 : bool = Fable.Core.RustInterop.emitRustExpr v111 v135 
        let v137 : string = "x"
        let v138 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v137 
        let v139 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v140 : bool = Fable.Core.RustInterop.emitRustExpr v138 v139 
        let v141 : string = $"true"
        let v142 : bool = Fable.Core.RustInterop.emitRustExpr () v141 
        let v143 : string = "true; }); //"
        let v144 : bool = Fable.Core.RustInterop.emitRustExpr () v143 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v47 v46
    #endif
#if FABLE_COMPILER_PYTHON
    v47 v46
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v47 v46
    #endif
#else
    v47 v46
    #endif
    // run_target_args' is_unit
    let v145 : (string -> unit) = v24.l0
    v145 v46
and closure18 () () : unit =
    let v0 : US3 = US3_2
    let v1 : bool = method9(v0)
    if v1 then
        method34()
and method35 () : string =
    
    
    
    
    
    let v2 : string = "Info"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method15(v7)
    (* run_target_args'
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "inline_colorization::color_bright_green"
    let v15 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v14 
    (* run_target_args'
    let v20 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v21 : string = "&*$0"
    let v22 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v21 
    let _run_target_args'_v20 = v22 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v23 : string = "&*$0"
    let v24 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v23 
    let _run_target_args'_v20 = v24 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v25 : string = "&*$0"
    let v26 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v25 
    let _run_target_args'_v20 = v26 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v28 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v28 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v36 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v36 
    #endif
#else
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v40 
    #endif
    let v43 : Ref<Str> = _run_target_args'_v20 
    let v49 : string = "inline_colorization::color_reset"
    let v50 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v49 
    let v51 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v15, v43, v50) v51 
    let v53 : string = "fable_library_rust::String_::fromString($0)"
    let v54 : string = Fable.Core.RustInterop.emitRustExpr v52 v53 
    let _run_target_args'_v13 = v54 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v55 : string = "inline_colorization::color_bright_green"
    let v56 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v55 
    (* run_target_args'
    let v61 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v62 : string = "&*$0"
    let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v62 
    let _run_target_args'_v61 = v63 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v64 : string = "&*$0"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v64 
    let _run_target_args'_v61 = v65 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v66 : string = "&*$0"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v66 
    let _run_target_args'_v61 = v67 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v69 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v69 
    #endif
#if FABLE_COMPILER_PYTHON
    let v73 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v73 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v77 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v77 
    #endif
#else
    let v81 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v81 
    #endif
    let v84 : Ref<Str> = _run_target_args'_v61 
    let v90 : string = "inline_colorization::color_reset"
    let v91 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v90 
    let v92 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v93 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v56, v84, v91) v92 
    let v94 : string = "fable_library_rust::String_::fromString($0)"
    let v95 : string = Fable.Core.RustInterop.emitRustExpr v93 v94 
    let _run_target_args'_v13 = v95 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v96 : string = "inline_colorization::color_bright_green"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v96 
    (* run_target_args'
    let v102 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v103 
    let _run_target_args'_v102 = v104 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v105 : string = "&*$0"
    let v106 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v105 
    let _run_target_args'_v102 = v106 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v107 : string = "&*$0"
    let v108 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v107 
    let _run_target_args'_v102 = v108 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v110 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v110 
    #endif
#if FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v114 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v118 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v118 
    #endif
#else
    let v122 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v122 
    #endif
    let v125 : Ref<Str> = _run_target_args'_v102 
    let v131 : string = "inline_colorization::color_reset"
    let v132 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v131 
    let v133 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v134 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v97, v125, v132) v133 
    let v135 : string = "fable_library_rust::String_::fromString($0)"
    let v136 : string = Fable.Core.RustInterop.emitRustExpr v134 v135 
    let _run_target_args'_v13 = v136 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v137 : string = "\u001b[92m"
    let v138 : string = method17()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[92m"
    let v142 : string = method17()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[92m"
    let v146 : string = method17()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[92m"
    let v150 : string = method17()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method37 (v0 : uint8, v1 : float, v2 : uint64) : string =
    let v3 : string = method16()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v11 : unit = ()
    let v12 : (unit -> unit) = closure8(v4, v8)
    let v13 : unit = (fun () -> v12 (); v11) ()
    let v18 : string = "retry"
    let v19 : string = $"{v18}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v4, v19)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v29 : string = " = "
    let v30 : string = $"{v29}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure8(v4, v30)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v39 : string = $"{v0}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v4, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v49 : string = "; "
    let v50 : string = $"{v49}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure8(v4, v50)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v60 : string = "total_gas_burnt_usd"
    let v61 : string = $"{v60}"
    let v64 : unit = ()
    let v65 : (unit -> unit) = closure8(v4, v61)
    let v66 : unit = (fun () -> v65 (); v64) ()
    let v70 : string = $"{v29}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v4, v70)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v79 : string = $"%+.6f{v1}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure8(v4, v79)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v88 : string = $"{v49}"
    let v91 : unit = ()
    let v92 : (unit -> unit) = closure8(v4, v88)
    let v93 : unit = (fun () -> v92 (); v91) ()
    let v98 : string = "total_gas_burnt"
    let v99 : string = $"{v98}"
    let v102 : unit = ()
    let v103 : (unit -> unit) = closure8(v4, v99)
    let v104 : unit = (fun () -> v103 (); v102) ()
    let v108 : string = $"{v29}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v4, v108)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v117 : string = $"{v2}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure8(v4, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v127 : string = " }"
    let v128 : string = $"{v127}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure8(v4, v128)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v136 : string = v4.l0
    v136
and method36 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : float, v10 : uint64) : string =
    let v11 : string = method37(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v14 : string = "near_workspaces.print_usd"
    let v15 : string = $"{v6} {v7} #{v12} %s{v14} / {v11}"
    method20(v15)
and closure19 (v0 : uint8, v1 : uint64, v2 : float) () : unit =
    let v3 : US3 = US3_2
    let v4 : bool = method9(v3)
    if v4 then
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure6()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut0, v29 : Mut1, v30 : Mut2, v31 : Mut3, v32 : Mut4, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method10(v28, v29, v30, v31, v32, v33)
        let v47 : string = method35()
        let v48 : string = method36(v28, v29, v30, v31, v32, v33, v46, v47, v0, v2, v1)
        method21(v48)
and method39 (v0 : bool, v1 : float, v2 : float, v3 : uint64, v4 : u128) : string =
    let v5 : string = method16()
    let v6 : Mut3 = {l0 = v5} : Mut3
    let v9 : string = "{ "
    let v10 : string = $"{v9}"
    let v13 : unit = ()
    let v14 : (unit -> unit) = closure8(v6, v10)
    let v15 : unit = (fun () -> v14 (); v13) ()
    let v20 : string = "is_success"
    let v21 : string = $"{v20}"
    let v24 : unit = ()
    let v25 : (unit -> unit) = closure8(v6, v21)
    let v26 : unit = (fun () -> v25 (); v24) ()
    let v31 : string = " = "
    let v32 : string = $"{v31}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure8(v6, v32)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v42 : string =
        if v0 then
            let v40 : string = "true"
            v40
        else
            let v41 : string = "false"
            v41
    let v44 : string = $"{v42}"
    let v47 : unit = ()
    let v48 : (unit -> unit) = closure8(v6, v44)
    let v49 : unit = (fun () -> v48 (); v47) ()
    let v54 : string = "; "
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure8(v6, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v65 : string = "gas_burnt_usd"
    let v66 : string = $"{v65}"
    let v69 : unit = ()
    let v70 : (unit -> unit) = closure8(v6, v66)
    let v71 : unit = (fun () -> v70 (); v69) ()
    let v75 : string = $"{v31}"
    let v78 : unit = ()
    let v79 : (unit -> unit) = closure8(v6, v75)
    let v80 : unit = (fun () -> v79 (); v78) ()
    let v84 : string = $"%+.6f{v1}"
    let v87 : unit = ()
    let v88 : (unit -> unit) = closure8(v6, v84)
    let v89 : unit = (fun () -> v88 (); v87) ()
    let v93 : string = $"{v54}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure8(v6, v93)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v103 : string = "tokens_burnt_usd"
    let v104 : string = $"{v103}"
    let v107 : unit = ()
    let v108 : (unit -> unit) = closure8(v6, v104)
    let v109 : unit = (fun () -> v108 (); v107) ()
    let v113 : string = $"{v31}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure8(v6, v113)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v122 : string = $"%+.6f{v2}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure8(v6, v122)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v131 : string = $"{v54}"
    let v134 : unit = ()
    let v135 : (unit -> unit) = closure8(v6, v131)
    let v136 : unit = (fun () -> v135 (); v134) ()
    let v141 : string = "gas_burnt"
    let v142 : string = $"{v141}"
    let v145 : unit = ()
    let v146 : (unit -> unit) = closure8(v6, v142)
    let v147 : unit = (fun () -> v146 (); v145) ()
    let v151 : string = $"{v31}"
    let v154 : unit = ()
    let v155 : (unit -> unit) = closure8(v6, v151)
    let v156 : unit = (fun () -> v155 (); v154) ()
    let v160 : string = $"{v3}"
    let v163 : unit = ()
    let v164 : (unit -> unit) = closure8(v6, v160)
    let v165 : unit = (fun () -> v164 (); v163) ()
    let v169 : string = $"{v54}"
    let v172 : unit = ()
    let v173 : (unit -> unit) = closure8(v6, v169)
    let v174 : unit = (fun () -> v173 (); v172) ()
    let v179 : string = "tokens_burnt"
    let v180 : string = $"{v179}"
    let v183 : unit = ()
    let v184 : (unit -> unit) = closure8(v6, v180)
    let v185 : unit = (fun () -> v184 (); v183) ()
    let v189 : string = $"{v31}"
    let v192 : unit = ()
    let v193 : (unit -> unit) = closure8(v6, v189)
    let v194 : unit = (fun () -> v193 (); v192) ()
    (* run_target_args'
    let v201 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v202 : string = "format!(\"{:#?}\", $0)"
    let v203 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v202 
    let v204 : string = "fable_library_rust::String_::fromString($0)"
    let v205 : string = Fable.Core.RustInterop.emitRustExpr v203 v204 
    let _run_target_args'_v201 = v205 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v206 : string = "format!(\"{:#?}\", $0)"
    let v207 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v206 
    let v208 : string = "fable_library_rust::String_::fromString($0)"
    let v209 : string = Fable.Core.RustInterop.emitRustExpr v207 v208 
    let _run_target_args'_v201 = v209 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v210 : string = "format!(\"{:#?}\", $0)"
    let v211 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v210 
    let v212 : string = "fable_library_rust::String_::fromString($0)"
    let v213 : string = Fable.Core.RustInterop.emitRustExpr v211 v212 
    let _run_target_args'_v201 = v213 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v215 : string = $"%A{v4}"
    let _run_target_args'_v201 = v215 
    #endif
#if FABLE_COMPILER_PYTHON
    let v219 : string = $"%A{v4}"
    let _run_target_args'_v201 = v219 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v223 : string = $"%A{v4}"
    let _run_target_args'_v201 = v223 
    #endif
#else
    let v227 : string = $"%A{v4}"
    let _run_target_args'_v201 = v227 
    #endif
    let v230 : string = _run_target_args'_v201 
    let v237 : string = $"{v230}"
    let v240 : unit = ()
    let v241 : (unit -> unit) = closure8(v6, v237)
    let v242 : unit = (fun () -> v241 (); v240) ()
    let v247 : string = " }"
    let v248 : string = $"{v247}"
    let v251 : unit = ()
    let v252 : (unit -> unit) = closure8(v6, v248)
    let v253 : unit = (fun () -> v252 (); v251) ()
    let v256 : string = v6.l0
    v256
and method38 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : bool, v9 : float, v10 : float, v11 : uint64, v12 : u128) : string =
    let v13 : string = method39(v8, v9, v10, v11, v12)
    let v14 : int64 = v0.l0
    let v16 : string = "near_workspaces.print_usd / outcome"
    let v17 : string = $"{v6} {v7} #{v14} %s{v16} / {v13}"
    method20(v17)
and closure21 (v0 : bool, v1 : uint64, v2 : float, v3 : u128, v4 : float) () : unit =
    let v5 : US3 = US3_2
    let v6 : bool = method9(v5)
    if v6 then
        let v7 : unit = ()
        let v8 : (unit -> unit) = closure6()
        let v9 : unit = (fun () -> v8 (); v7) ()
        let struct (v30 : Mut0, v31 : Mut1, v32 : Mut2, v33 : Mut3, v34 : Mut4, v35 : int64 option) = TraceState.trace_state.Value
        let v48 : string = method10(v30, v31, v32, v33, v34, v35)
        let v49 : string = method35()
        let v50 : string = method38(v30, v31, v32, v33, v34, v35, v48, v49, v0, v2, v4, v1, v3)
        method21(v50)
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
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure21(v2, v6, v13, v17, v21)
    let v24 : unit = (fun () -> v23 (); v22) ()
    ()
and method41 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "result2"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure8(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure8(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    (* run_target_args'
    let v40 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v41 : string = "format!(\"{:#?}\", $0)"
    let v42 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v41 
    let v43 : string = "fable_library_rust::String_::fromString($0)"
    let v44 : string = Fable.Core.RustInterop.emitRustExpr v42 v43 
    let _run_target_args'_v40 = v44 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v45 : string = "format!(\"{:#?}\", $0)"
    let v46 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v45 
    let v47 : string = "fable_library_rust::String_::fromString($0)"
    let v48 : string = Fable.Core.RustInterop.emitRustExpr v46 v47 
    let _run_target_args'_v40 = v48 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v49 : string = "format!(\"{:#?}\", $0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v49 
    let v51 : string = "fable_library_rust::String_::fromString($0)"
    let v52 : string = Fable.Core.RustInterop.emitRustExpr v50 v51 
    let _run_target_args'_v40 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : string = $"%A{v0}"
    let _run_target_args'_v40 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : string = $"%A{v0}"
    let _run_target_args'_v40 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : string = $"%A{v0}"
    let _run_target_args'_v40 = v62 
    #endif
#else
    let v66 : string = $"%A{v0}"
    let _run_target_args'_v40 = v66 
    #endif
    let v69 : string = _run_target_args'_v40 
    let v76 : string = $"{v69}"
    let v79 : unit = ()
    let v80 : (unit -> unit) = closure8(v2, v76)
    let v81 : unit = (fun () -> v80 (); v79) ()
    let v86 : string = " }"
    let v87 : string = $"{v86}"
    let v90 : unit = ()
    let v91 : (unit -> unit) = closure8(v2, v87)
    let v92 : unit = (fun () -> v91 (); v90) ()
    let v95 : string = v2.l0
    v95
and method40 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v9 : string = method41(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "spiral_wasm.run"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method20(v13)
and closure22 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure6()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method10(v26, v27, v28, v29, v30, v31)
        let v45 : string = method14()
        let v46 : string = method40(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method21(v46)
and method42 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method44 (v0 : int32, v1 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v2 : string = method16()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure8(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "receipt_failures_len"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure8(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure8(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "receipt_failures"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure8(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure8(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    (* run_target_args'
    let v81 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v82 : string = "format!(\"{:#?}\", $0)"
    let v83 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v82 
    let v84 : string = "fable_library_rust::String_::fromString($0)"
    let v85 : string = Fable.Core.RustInterop.emitRustExpr v83 v84 
    let _run_target_args'_v81 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "format!(\"{:#?}\", $0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v86 
    let v88 : string = "fable_library_rust::String_::fromString($0)"
    let v89 : string = Fable.Core.RustInterop.emitRustExpr v87 v88 
    let _run_target_args'_v81 = v89 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v90 : string = "format!(\"{:#?}\", $0)"
    let v91 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v90 
    let v92 : string = "fable_library_rust::String_::fromString($0)"
    let v93 : string = Fable.Core.RustInterop.emitRustExpr v91 v92 
    let _run_target_args'_v81 = v93 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v95 : string = $"%A{v1}"
    let _run_target_args'_v81 = v95 
    #endif
#if FABLE_COMPILER_PYTHON
    let v99 : string = $"%A{v1}"
    let _run_target_args'_v81 = v99 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v103 : string = $"%A{v1}"
    let _run_target_args'_v81 = v103 
    #endif
#else
    let v107 : string = $"%A{v1}"
    let _run_target_args'_v81 = v107 
    #endif
    let v110 : string = _run_target_args'_v81 
    let v117 : string = $"{v110}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure8(v3, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v127 : string = " }"
    let v128 : string = $"{v127}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure8(v3, v128)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v136 : string = v3.l0
    v136
and method43 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v10 : string = method44(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "spiral_wasm.run"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method20(v14)
and closure23 (v0 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>, v1 : int32) () : unit =
    let v2 : US3 = US3_0
    let v3 : bool = method9(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure6()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method10(v27, v28, v29, v30, v31, v32)
        let v46 : string = method14()
        let v47 : string = method43(v27, v28, v29, v30, v31, v32, v45, v46, v1, v0)
        method21(v47)
and method45 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method47 (v0 : int32, v1 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v2 : string = method16()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure8(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "receipt_outcomes_len"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure8(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure8(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "receipt_outcomes"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure8(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure8(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    (* run_target_args'
    let v81 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v82 : string = "format!(\"{:#?}\", $0)"
    let v83 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v82 
    let v84 : string = "fable_library_rust::String_::fromString($0)"
    let v85 : string = Fable.Core.RustInterop.emitRustExpr v83 v84 
    let _run_target_args'_v81 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "format!(\"{:#?}\", $0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v86 
    let v88 : string = "fable_library_rust::String_::fromString($0)"
    let v89 : string = Fable.Core.RustInterop.emitRustExpr v87 v88 
    let _run_target_args'_v81 = v89 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v90 : string = "format!(\"{:#?}\", $0)"
    let v91 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v90 
    let v92 : string = "fable_library_rust::String_::fromString($0)"
    let v93 : string = Fable.Core.RustInterop.emitRustExpr v91 v92 
    let _run_target_args'_v81 = v93 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v95 : string = $"%A{v1}"
    let _run_target_args'_v81 = v95 
    #endif
#if FABLE_COMPILER_PYTHON
    let v99 : string = $"%A{v1}"
    let _run_target_args'_v81 = v99 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v103 : string = $"%A{v1}"
    let _run_target_args'_v81 = v103 
    #endif
#else
    let v107 : string = $"%A{v1}"
    let _run_target_args'_v81 = v107 
    #endif
    let v110 : string = _run_target_args'_v81 
    let v117 : string = $"{v110}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure8(v3, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v127 : string = " }"
    let v128 : string = $"{v127}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure8(v3, v128)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v136 : string = v3.l0
    v136
and method46 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v10 : string = method47(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "spiral_wasm.run"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method20(v14)
and closure24 (v0 : Vec<near_workspaces_result_ExecutionOutcome>, v1 : int32) () : unit =
    let v2 : US3 = US3_0
    let v3 : bool = method9(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure6()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method10(v27, v28, v29, v30, v31, v32)
        let v46 : string = method14()
        let v47 : string = method46(v27, v28, v29, v30, v31, v32, v45, v46, v1, v0)
        method21(v47)
and method49 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "json"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure8(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure8(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    (* run_target_args'
    let v40 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v41 : string = "format!(\"{:#?}\", $0)"
    let v42 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v41 
    let v43 : string = "fable_library_rust::String_::fromString($0)"
    let v44 : string = Fable.Core.RustInterop.emitRustExpr v42 v43 
    let _run_target_args'_v40 = v44 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v45 : string = "format!(\"{:#?}\", $0)"
    let v46 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v45 
    let v47 : string = "fable_library_rust::String_::fromString($0)"
    let v48 : string = Fable.Core.RustInterop.emitRustExpr v46 v47 
    let _run_target_args'_v40 = v48 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v49 : string = "format!(\"{:#?}\", $0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v49 
    let v51 : string = "fable_library_rust::String_::fromString($0)"
    let v52 : string = Fable.Core.RustInterop.emitRustExpr v50 v51 
    let _run_target_args'_v40 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : string = $"%A{v0}"
    let _run_target_args'_v40 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : string = $"%A{v0}"
    let _run_target_args'_v40 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : string = $"%A{v0}"
    let _run_target_args'_v40 = v62 
    #endif
#else
    let v66 : string = $"%A{v0}"
    let _run_target_args'_v40 = v66 
    #endif
    let v69 : string = _run_target_args'_v40 
    let v76 : string = $"{v69}"
    let v79 : unit = ()
    let v80 : (unit -> unit) = closure8(v2, v76)
    let v81 : unit = (fun () -> v80 (); v79) ()
    let v86 : string = " }"
    let v87 : string = $"{v86}"
    let v90 : unit = ()
    let v91 : (unit -> unit) = closure8(v2, v87)
    let v92 : unit = (fun () -> v91 (); v90) ()
    let v95 : string = v2.l0
    v95
and method48 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method49(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "spiral_wasm.run"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method20(v13)
and closure25 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure6()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method10(v26, v27, v28, v29, v30, v31)
        let v45 : string = method14()
        let v46 : string = method48(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method21(v46)
and method51 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "borsh"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure8(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure8(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    (* run_target_args'
    let v40 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v41 : string = "format!(\"{:#?}\", $0)"
    let v42 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v41 
    let v43 : string = "fable_library_rust::String_::fromString($0)"
    let v44 : string = Fable.Core.RustInterop.emitRustExpr v42 v43 
    let _run_target_args'_v40 = v44 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v45 : string = "format!(\"{:#?}\", $0)"
    let v46 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v45 
    let v47 : string = "fable_library_rust::String_::fromString($0)"
    let v48 : string = Fable.Core.RustInterop.emitRustExpr v46 v47 
    let _run_target_args'_v40 = v48 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v49 : string = "format!(\"{:#?}\", $0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v49 
    let v51 : string = "fable_library_rust::String_::fromString($0)"
    let v52 : string = Fable.Core.RustInterop.emitRustExpr v50 v51 
    let _run_target_args'_v40 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : string = $"%A{v0}"
    let _run_target_args'_v40 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : string = $"%A{v0}"
    let _run_target_args'_v40 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : string = $"%A{v0}"
    let _run_target_args'_v40 = v62 
    #endif
#else
    let v66 : string = $"%A{v0}"
    let _run_target_args'_v40 = v66 
    #endif
    let v69 : string = _run_target_args'_v40 
    let v76 : string = $"{v69}"
    let v79 : unit = ()
    let v80 : (unit -> unit) = closure8(v2, v76)
    let v81 : unit = (fun () -> v80 (); v79) ()
    let v86 : string = " }"
    let v87 : string = $"{v86}"
    let v90 : unit = ()
    let v91 : (unit -> unit) = closure8(v2, v87)
    let v92 : unit = (fun () -> v91 (); v90) ()
    let v95 : string = v2.l0
    v95
and method50 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method51(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "spiral_wasm.run"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method20(v13)
and closure26 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure6()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method10(v26, v27, v28, v29, v30, v31)
        let v45 : string = method14()
        let v46 : string = method50(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method21(v46)
and method52 (v0 : int32, v1 : uint8, v2 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v3 : string = method16()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v11 : unit = ()
    let v12 : (unit -> unit) = closure8(v4, v8)
    let v13 : unit = (fun () -> v12 (); v11) ()
    let v18 : string = "receipt_outcomes_len"
    let v19 : string = $"{v18}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v4, v19)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v29 : string = " = "
    let v30 : string = $"{v29}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure8(v4, v30)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v39 : string = $"{v0}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v4, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v49 : string = "; "
    let v50 : string = $"{v49}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure8(v4, v50)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v60 : string = "retry"
    let v61 : string = $"{v60}"
    let v64 : unit = ()
    let v65 : (unit -> unit) = closure8(v4, v61)
    let v66 : unit = (fun () -> v65 (); v64) ()
    let v70 : string = $"{v29}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v4, v70)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v79 : string = $"{v1}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure8(v4, v79)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v88 : string = $"{v49}"
    let v91 : unit = ()
    let v92 : (unit -> unit) = closure8(v4, v88)
    let v93 : unit = (fun () -> v92 (); v91) ()
    let v98 : string = "receipt_failures"
    let v99 : string = $"{v98}"
    let v102 : unit = ()
    let v103 : (unit -> unit) = closure8(v4, v99)
    let v104 : unit = (fun () -> v103 (); v102) ()
    let v108 : string = $"{v29}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure8(v4, v108)
    let v113 : unit = (fun () -> v112 (); v111) ()
    (* run_target_args'
    let v120 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v121 : string = "format!(\"{:#?}\", $0)"
    let v122 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v121 
    let v123 : string = "fable_library_rust::String_::fromString($0)"
    let v124 : string = Fable.Core.RustInterop.emitRustExpr v122 v123 
    let _run_target_args'_v120 = v124 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v125 : string = "format!(\"{:#?}\", $0)"
    let v126 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v125 
    let v127 : string = "fable_library_rust::String_::fromString($0)"
    let v128 : string = Fable.Core.RustInterop.emitRustExpr v126 v127 
    let _run_target_args'_v120 = v128 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v129 : string = "format!(\"{:#?}\", $0)"
    let v130 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v129 
    let v131 : string = "fable_library_rust::String_::fromString($0)"
    let v132 : string = Fable.Core.RustInterop.emitRustExpr v130 v131 
    let _run_target_args'_v120 = v132 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v134 : string = $"%A{v2}"
    let _run_target_args'_v120 = v134 
    #endif
#if FABLE_COMPILER_PYTHON
    let v138 : string = $"%A{v2}"
    let _run_target_args'_v120 = v138 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v142 : string = $"%A{v2}"
    let _run_target_args'_v120 = v142 
    #endif
#else
    let v146 : string = $"%A{v2}"
    let _run_target_args'_v120 = v146 
    #endif
    let v149 : string = _run_target_args'_v120 
    let v156 : string = $"{v149}"
    let v159 : unit = ()
    let v160 : (unit -> unit) = closure8(v4, v156)
    let v161 : unit = (fun () -> v160 (); v159) ()
    let v166 : string = " }"
    let v167 : string = $"{v166}"
    let v170 : unit = ()
    let v171 : (unit -> unit) = closure8(v4, v167)
    let v172 : unit = (fun () -> v171 (); v170) ()
    let v175 : string = v4.l0
    v175
and method29 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> =
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
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure14(v1, v11, v19)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v69 : string = "$0.call(&*$1)"
    let v70 : string = "state_main"
    let v71 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr struct (v19, v70) v69 
    let v72 : string = "near_workspaces::types::Gas::from_tgas(300)"
    let v73 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr () v72 
    let v74 : string = "v71.gas(v73)"
    let v75 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr () v74 
    let v76 : string = "Box::pin(v75.transact())"
    let v77 : std_pin_Pin<Box<Dyn<std_future_Future<Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v76 
    let v78 : string = "v77.await"
    let v79 : Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v78 
    let v80 : string = "$0?"
    let v81 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v79 v80 
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure15(v1, v81)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v131 : string = "v81.logs()"
    let v132 : Vec<Ref<Str>> = Fable.Core.RustInterop.emitRustExpr () v131 
    let v133 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v134 : bool = Fable.Core.RustInterop.emitRustExpr v132 v133 
    let v135 : string = "x"
    let v136 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v135 
    (* run_target_args'
    let v141 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v142 : string = "String::from($0)"
    let v143 : std_string_String = Fable.Core.RustInterop.emitRustExpr v136 v142 
    let _run_target_args'_v141 = v143 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v144 : string = "String::from($0)"
    let v145 : std_string_String = Fable.Core.RustInterop.emitRustExpr v136 v144 
    let _run_target_args'_v141 = v145 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v146 : string = "String::from($0)"
    let v147 : std_string_String = Fable.Core.RustInterop.emitRustExpr v136 v146 
    let _run_target_args'_v141 = v147 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v149 : std_string_String = v136 |> unbox<std_string_String>
    let _run_target_args'_v141 = v149 
    #endif
#if FABLE_COMPILER_PYTHON
    let v153 : std_string_String = v136 |> unbox<std_string_String>
    let _run_target_args'_v141 = v153 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v157 : std_string_String = v136 |> unbox<std_string_String>
    let _run_target_args'_v141 = v157 
    #endif
#else
    let v161 : std_string_String = v136 |> unbox<std_string_String>
    let _run_target_args'_v141 = v161 
    #endif
    let v164 : std_string_String = _run_target_args'_v141 
    let v170 : string = "true; $0 }).collect::<Vec<_>>()"
    let v171 : bool = Fable.Core.RustInterop.emitRustExpr v164 v170 
    let v172 : string = "_vec_map"
    let v173 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v172 
    let v174 : string = "true; $0.iter().for_each(|x| { $1(x.clone()); }); //"
    let v175 : (std_string_String -> unit) = closure16()
    let v176 : bool = Fable.Core.RustInterop.emitRustExpr struct (v173, v175) v174 
    let v177 : unit = ()
    let v178 : (unit -> unit) = closure18()
    let v179 : unit = (fun () -> v178 (); v177) ()
    let v182 : string = "$0.total_gas_burnt"
    let v183 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v81 v182 
    let v184 : string = "$0.as_gas()"
    let v185 : uint64 = Fable.Core.RustInterop.emitRustExpr v183 v184 
    let v187 : (uint64 -> float) = float
    let v188 : float = v187 v185
    let v191 : float = v188 / 10000000000000000.0
    let v192 : float = v191 * 6.68
    let v193 : unit = ()
    let v194 : (unit -> unit) = closure19(v1, v185, v192)
    let v195 : unit = (fun () -> v194 (); v193) ()
    let v242 : string = "$0"
    let v243 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v81 v242 
    let v244 : string = "v243.outcomes()"
    let v245 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v244 
    let v246 : string = "v245.into_iter()"
    let v247 : _ = Fable.Core.RustInterop.emitRustExpr () v246 
    let v248 : string = "v247.cloned()"
    let v249 : _ = Fable.Core.RustInterop.emitRustExpr () v248 
    let v250 : string = "true; v249.for_each(|x| $0(x))"
    let v251 : (near_workspaces_result_ExecutionOutcome -> unit) = closure20()
    let v252 : bool = Fable.Core.RustInterop.emitRustExpr v251 v250 
    let v253 : string = "$0.into_result()"
    let v254 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure> = Fable.Core.RustInterop.emitRustExpr v81 v253 
    let v255 : unit = ()
    let v256 : (unit -> unit) = closure22(v254)
    let v257 : unit = (fun () -> v256 (); v255) ()
    let v304 : near_workspaces_result_ExecutionFinalResult = method42(v81)
    let v305 : string = "v304.receipt_failures()"
    let v306 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v305 
    let v307 : string = "$0.len()"
    let v308 : unativeint = Fable.Core.RustInterop.emitRustExpr v306 v307 
    let v314 : int32 = v308 |> int32 
    let v322 : unit = ()
    let v323 : (unit -> unit) = closure23(v306, v314)
    let v324 : unit = (fun () -> v323 (); v322) ()
    let v371 : near_workspaces_result_ExecutionFinalResult = method45(v81)
    let v372 : string = "v371.receipt_outcomes()"
    let v373 : Ref<Slice<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v372 
    let v374 : string = "v373.into()"
    let v375 : Vec<near_workspaces_result_ExecutionOutcome> = Fable.Core.RustInterop.emitRustExpr () v374 
    let v376 : string = "$0.len()"
    let v377 : unativeint = Fable.Core.RustInterop.emitRustExpr v375 v376 
    let v383 : int32 = v377 |> int32 
    let v391 : unit = ()
    let v392 : (unit -> unit) = closure24(v375, v383)
    let v393 : unit = (fun () -> v392 (); v391) ()
    let v440 : string = "$0.json()"
    let v441 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v81 v440 
    let v442 : unit = ()
    let v443 : (unit -> unit) = closure25(v441)
    let v444 : unit = (fun () -> v443 (); v442) ()
    let v491 : string = "$0.borsh()"
    let v492 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v81 v491 
    let v493 : unit = ()
    let v494 : (unit -> unit) = closure26(v492)
    let v495 : unit = (fun () -> v494 (); v493) ()
    let v542 : string = method52(v383, v1, v306)
    let v543 : bool = v314 > 0
    let v577 : Result<US7, anyhow_Error> =
        if v543 then
            let v546 : US7 = US7_0(v542)
            let v547 : Result<US7, anyhow_Error> = Ok v546 
            v547
        else
            let v551 : bool = v383 > 1
            if v551 then
                let v554 : US7 = US7_1
                let v555 : Result<US7, anyhow_Error> = Ok v554 
                v555
            else
                let v559 : string = "anyhow::anyhow!($0)"
                let v560 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v542 v559 
                (* run_target_args'
                let v562 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v563 : string = "Err($0)"
                let v564 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v560 v563 
                let _run_target_args'_v562 = v564 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v565 : string = "Err($0)"
                let v566 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v560 v565 
                let _run_target_args'_v562 = v566 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v567 : string = "Err($0)"
                let v568 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v560 v567 
                let _run_target_args'_v562 = v568 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v569 : Result<US7, anyhow_Error> = v560 |> Error
                let _run_target_args'_v562 = v569 
                #endif
#if FABLE_COMPILER_PYTHON
                let v570 : Result<US7, anyhow_Error> = v560 |> Error
                let _run_target_args'_v562 = v570 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v571 : Result<US7, anyhow_Error> = v560 |> Error
                let _run_target_args'_v562 = v571 
                #endif
#else
                let v572 : Result<US7, anyhow_Error> = v560 |> Error
                let _run_target_args'_v562 = v572 
                #endif
                let v573 : Result<US7, anyhow_Error> = _run_target_args'_v562 
                v573
    let v578 : string = ""
    let v579 : string = "}"
    let v580 : string = v578 + v579 
    let x = v577 //
    let v581 : _ = x
    let v582 : unit = ()
    (* run_target_args'
    let v583 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v584 : string = $"true; let _fix_closure_v582 = $0"
    let v585 : bool = Fable.Core.RustInterop.emitRustExpr v581 v584 
    let _run_target_args'_v583 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v586 : string = $"true; let _fix_closure_v582 = $0"
    let v587 : bool = Fable.Core.RustInterop.emitRustExpr v581 v586 
    let _run_target_args'_v583 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v588 : string = $"true; let _fix_closure_v582 = $0"
    let v589 : bool = Fable.Core.RustInterop.emitRustExpr v581 v588 
    let _run_target_args'_v583 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v583 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v583 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v583 = false 
    #endif
#else
    let _run_target_args'_v583 = false 
    #endif
    let v590 : bool = _run_target_args'_v583 
    let v592 : string = $"true; _fix_closure_v582 " + v580 + "); " + v578 + " // rust.fix_closure'"
    let v593 : bool = Fable.Core.RustInterop.emitRustExpr () v592 
    let v594 : string = "__future_init"
    let v595 : _ = Fable.Core.RustInterop.emitRustExpr () v594 
    let v596 : string = "v595"
    let v597 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v596 
    v597
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
and method53 () : (anyhow_Error -> std_string_String) =
    closure27()
and closure28 () (v0 : US7) : US9 =
    US9_0(v0)
and method54 () : (US7 -> US9) =
    closure28()
and closure29 () (v0 : std_string_String) : US9 =
    US9_1(v0)
and method55 () : (std_string_String -> US9) =
    closure29()
and method56 () : string =
    
    
    
    
    
    let v2 : string = "Warning"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method15(v7)
    (* run_target_args'
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "inline_colorization::color_yellow"
    let v15 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v14 
    (* run_target_args'
    let v20 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v21 : string = "&*$0"
    let v22 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v21 
    let _run_target_args'_v20 = v22 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v23 : string = "&*$0"
    let v24 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v23 
    let _run_target_args'_v20 = v24 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v25 : string = "&*$0"
    let v26 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v25 
    let _run_target_args'_v20 = v26 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v28 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v28 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v36 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v36 
    #endif
#else
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v40 
    #endif
    let v43 : Ref<Str> = _run_target_args'_v20 
    let v49 : string = "inline_colorization::color_reset"
    let v50 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v49 
    let v51 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v15, v43, v50) v51 
    let v53 : string = "fable_library_rust::String_::fromString($0)"
    let v54 : string = Fable.Core.RustInterop.emitRustExpr v52 v53 
    let _run_target_args'_v13 = v54 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v55 : string = "inline_colorization::color_yellow"
    let v56 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v55 
    (* run_target_args'
    let v61 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v62 : string = "&*$0"
    let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v62 
    let _run_target_args'_v61 = v63 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v64 : string = "&*$0"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v64 
    let _run_target_args'_v61 = v65 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v66 : string = "&*$0"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v66 
    let _run_target_args'_v61 = v67 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v69 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v69 
    #endif
#if FABLE_COMPILER_PYTHON
    let v73 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v73 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v77 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v77 
    #endif
#else
    let v81 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v81 
    #endif
    let v84 : Ref<Str> = _run_target_args'_v61 
    let v90 : string = "inline_colorization::color_reset"
    let v91 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v90 
    let v92 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v93 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v56, v84, v91) v92 
    let v94 : string = "fable_library_rust::String_::fromString($0)"
    let v95 : string = Fable.Core.RustInterop.emitRustExpr v93 v94 
    let _run_target_args'_v13 = v95 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v96 : string = "inline_colorization::color_yellow"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v96 
    (* run_target_args'
    let v102 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v103 
    let _run_target_args'_v102 = v104 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v105 : string = "&*$0"
    let v106 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v105 
    let _run_target_args'_v102 = v106 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v107 : string = "&*$0"
    let v108 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v107 
    let _run_target_args'_v102 = v108 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v110 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v110 
    #endif
#if FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v114 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v118 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v118 
    #endif
#else
    let v122 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v122 
    #endif
    let v125 : Ref<Str> = _run_target_args'_v102 
    let v131 : string = "inline_colorization::color_reset"
    let v132 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v131 
    let v133 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v134 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v97, v125, v132) v133 
    let v135 : string = "fable_library_rust::String_::fromString($0)"
    let v136 : string = Fable.Core.RustInterop.emitRustExpr v134 v135 
    let _run_target_args'_v13 = v136 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v137 : string = "\u001b[93m"
    let v138 : string = method17()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[93m"
    let v142 : string = method17()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[93m"
    let v146 : string = method17()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[93m"
    let v150 : string = method17()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method58 (v0 : uint8, v1 : std_string_String) : string =
    let v2 : string = method16()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure8(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "retry"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure8(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure8(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "error"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure8(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure8(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    (* run_target_args'
    let v81 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v82 : string = "format!(\"{:#?}\", $0)"
    let v83 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v82 
    let v84 : string = "fable_library_rust::String_::fromString($0)"
    let v85 : string = Fable.Core.RustInterop.emitRustExpr v83 v84 
    let _run_target_args'_v81 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "format!(\"{:#?}\", $0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v86 
    let v88 : string = "fable_library_rust::String_::fromString($0)"
    let v89 : string = Fable.Core.RustInterop.emitRustExpr v87 v88 
    let _run_target_args'_v81 = v89 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v90 : string = "format!(\"{:#?}\", $0)"
    let v91 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v90 
    let v92 : string = "fable_library_rust::String_::fromString($0)"
    let v93 : string = Fable.Core.RustInterop.emitRustExpr v91 v92 
    let _run_target_args'_v81 = v93 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v95 : string = $"%A{v1}"
    let _run_target_args'_v81 = v95 
    #endif
#if FABLE_COMPILER_PYTHON
    let v99 : string = $"%A{v1}"
    let _run_target_args'_v81 = v99 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v103 : string = $"%A{v1}"
    let _run_target_args'_v81 = v103 
    #endif
#else
    let v107 : string = $"%A{v1}"
    let _run_target_args'_v81 = v107 
    #endif
    let v110 : string = _run_target_args'_v81 
    let v117 : string = $"{v110}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure8(v3, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v127 : string = " }"
    let v128 : string = $"{v127}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure8(v3, v128)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v136 : string = v3.l0
    v136
and method57 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : std_string_String) : string =
    let v10 : string = method58(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "spiral_wasm.run / Error error"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method20(v14)
and closure30 (v0 : uint8, v1 : std_string_String) () : unit =
    let v2 : US3 = US3_3
    let v3 : bool = method9(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure6()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method10(v27, v28, v29, v30, v31, v32)
        let v46 : string = method56()
        let v47 : string = method57(v27, v28, v29, v30, v31, v32, v45, v46, v0, v1)
        method21(v47)
and method59 () : unit =
    let v0 : unit = ()
    let v1 : (unit -> unit) = closure6()
    let v2 : unit = (fun () -> v1 (); v0) ()
    let struct (v23 : Mut0, v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : int64 option) = TraceState.trace_state.Value
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure9(v23)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v46 : string = "\n"
    let v47 : (string -> unit) = closure10()
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v46 v49 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v50 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v46 v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = v26.l0
    let v52 : bool = v51 = ""
    let v59 : string =
        if v52 then
            v46
        else
            let v53 : bool = v46 = ""
            if v53 then
                let v54 : string = v26.l0
                v54
            else
                let v55 : string = v26.l0
                let v56 : string = v55 + v46 
                let v57 : string = v56 + v46 
                v57
    (* run_target_args'
    let v64 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v65 : string = "&*$0"
    let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v59 v65 
    let _run_target_args'_v64 = v66 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v67 : string = "&*$0"
    let v68 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v59 v67 
    let _run_target_args'_v64 = v68 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v69 : string = "&*$0"
    let v70 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v59 v69 
    let _run_target_args'_v64 = v70 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v72 : Ref<Str> = v59 |> unbox<Ref<Str>>
    let _run_target_args'_v64 = v72 
    #endif
#if FABLE_COMPILER_PYTHON
    let v76 : Ref<Str> = v59 |> unbox<Ref<Str>>
    let _run_target_args'_v64 = v76 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v80 : Ref<Str> = v59 |> unbox<Ref<Str>>
    let _run_target_args'_v64 = v80 
    #endif
#else
    let v84 : Ref<Str> = v59 |> unbox<Ref<Str>>
    let _run_target_args'_v64 = v84 
    #endif
    let v87 : Ref<Str> = _run_target_args'_v64 
    let v93 : string = $"$0.chars()"
    let v94 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v87 v93 
    let v95 : string = "$0"
    let v96 : _ = Fable.Core.RustInterop.emitRustExpr v94 v95 
    let v97 : string = "$0.collect::<Vec<_>>()"
    let v98 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v96 v97 
    let v99 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v100 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v98 v99 
    let v101 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v102 : bool = Fable.Core.RustInterop.emitRustExpr v100 v101 
    let v103 : string = "x"
    let v104 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v103 
    let v105 : string = "String::from_iter($0)"
    let v106 : std_string_String = Fable.Core.RustInterop.emitRustExpr v104 v105 
    let v107 : string = "true; $0 }).collect::<Vec<_>>()"
    let v108 : bool = Fable.Core.RustInterop.emitRustExpr v106 v107 
    let v109 : string = "_vec_map"
    let v110 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v109 
    let v111 : string = "$0.len()"
    let v112 : unativeint = Fable.Core.RustInterop.emitRustExpr v110 v111 
    let v118 : int32 = v112 |> int32 
    let v128 : string = ""
    let v129 : bool = v46 <> v128 
    let v133 : bool =
        if v129 then
            let v132 : bool = v118 <= 1
            v132
        else
            false
    if v133 then
        v26.l0 <- v59
        ()
    else
        v26.l0 <- v128
        let v134 : string = "true; $0.into_iter().for_each(|x| { //"
        let v135 : bool = Fable.Core.RustInterop.emitRustExpr v110 v134 
        let v136 : string = "x"
        let v137 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v136 
        let v138 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v139 : bool = Fable.Core.RustInterop.emitRustExpr v137 v138 
        let v140 : string = $"true"
        let v141 : bool = Fable.Core.RustInterop.emitRustExpr () v140 
        let v142 : string = "true; }); //"
        let v143 : bool = Fable.Core.RustInterop.emitRustExpr () v142 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v47 v46
    #endif
#if FABLE_COMPILER_PYTHON
    v47 v46
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v47 v46
    #endif
#else
    v47 v46
    #endif
    // run_target_args' is_unit
    let v144 : (string -> unit) = v24.l0
    v144 v46
and closure31 () () : unit =
    let v0 : US3 = US3_3
    let v1 : bool = method9(v0)
    if v1 then
        method59()
and closure32 (v0 : uint8, v1 : std_string_String) () : unit =
    let v2 : US3 = US3_3
    let v3 : bool = method9(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure6()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method10(v27, v28, v29, v30, v31, v32)
        let v46 : string = method56()
        let v47 : string = method57(v27, v28, v29, v30, v31, v32, v45, v46, v0, v1)
        method21(v47)
and closure33 () () : unit =
    let v0 : US3 = US3_3
    let v1 : bool = method9(v0)
    if v1 then
        method59()
and method60 () : string =
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method15(v7)
    (* run_target_args'
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "inline_colorization::color_bright_red"
    let v15 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v14 
    (* run_target_args'
    let v20 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v21 : string = "&*$0"
    let v22 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v21 
    let _run_target_args'_v20 = v22 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v23 : string = "&*$0"
    let v24 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v23 
    let _run_target_args'_v20 = v24 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v25 : string = "&*$0"
    let v26 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v25 
    let _run_target_args'_v20 = v26 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v28 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v28 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v36 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v36 
    #endif
#else
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v20 = v40 
    #endif
    let v43 : Ref<Str> = _run_target_args'_v20 
    let v49 : string = "inline_colorization::color_reset"
    let v50 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v49 
    let v51 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v15, v43, v50) v51 
    let v53 : string = "fable_library_rust::String_::fromString($0)"
    let v54 : string = Fable.Core.RustInterop.emitRustExpr v52 v53 
    let _run_target_args'_v13 = v54 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v55 : string = "inline_colorization::color_bright_red"
    let v56 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v55 
    (* run_target_args'
    let v61 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v62 : string = "&*$0"
    let v63 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v62 
    let _run_target_args'_v61 = v63 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v64 : string = "&*$0"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v64 
    let _run_target_args'_v61 = v65 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v66 : string = "&*$0"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v66 
    let _run_target_args'_v61 = v67 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v69 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v69 
    #endif
#if FABLE_COMPILER_PYTHON
    let v73 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v73 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v77 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v77 
    #endif
#else
    let v81 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v61 = v81 
    #endif
    let v84 : Ref<Str> = _run_target_args'_v61 
    let v90 : string = "inline_colorization::color_reset"
    let v91 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v90 
    let v92 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v93 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v56, v84, v91) v92 
    let v94 : string = "fable_library_rust::String_::fromString($0)"
    let v95 : string = Fable.Core.RustInterop.emitRustExpr v93 v94 
    let _run_target_args'_v13 = v95 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v96 : string = "inline_colorization::color_bright_red"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v96 
    (* run_target_args'
    let v102 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v103 
    let _run_target_args'_v102 = v104 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v105 : string = "&*$0"
    let v106 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v105 
    let _run_target_args'_v102 = v106 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v107 : string = "&*$0"
    let v108 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v107 
    let _run_target_args'_v102 = v108 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v110 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v110 
    #endif
#if FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v114 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v118 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v118 
    #endif
#else
    let v122 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v102 = v122 
    #endif
    let v125 : Ref<Str> = _run_target_args'_v102 
    let v131 : string = "inline_colorization::color_reset"
    let v132 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v131 
    let v133 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v134 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v97, v125, v132) v133 
    let v135 : string = "fable_library_rust::String_::fromString($0)"
    let v136 : string = Fable.Core.RustInterop.emitRustExpr v134 v135 
    let _run_target_args'_v13 = v136 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v137 : string = "\u001b[91m"
    let v138 : string = method17()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[91m"
    let v142 : string = method17()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[91m"
    let v146 : string = method17()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[91m"
    let v150 : string = method17()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method62 (v0 : uint8, v1 : string) : string =
    let v2 : string = method16()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure8(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "retry"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure8(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure8(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "error"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure8(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure8(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v78 : string = $"{v1}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure8(v3, v78)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v88 : string = " }"
    let v89 : string = $"{v88}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure8(v3, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v97 : string = v3.l0
    v97
and method61 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : string) : string =
    let v10 : string = method62(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "spiral_wasm.run / Ok (Some error)"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method20(v14)
and closure34 (v0 : uint8, v1 : string) () : unit =
    let v2 : US3 = US3_4
    let v3 : bool = method9(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure6()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method10(v27, v28, v29, v30, v31, v32)
        let v46 : string = method60()
        let v47 : string = method61(v27, v28, v29, v30, v31, v32, v45, v46, v0, v1)
        method21(v47)
and method28 (v0 : Vec<uint8>, v1 : uint8) : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> =
    let v2 : string = "true; let __future_init = Box::pin(/*"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let v4 : string = "*/ async move { /*"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let v6 : string = "*/ ()"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let v8 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = method29(v0, v1)
    let v9 : string = "v8.await"
    let v10 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr () v9 
    let v11 : (anyhow_Error -> std_string_String) = method53()
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
    let v27 : (US7 -> US9) = method54()
    let v28 : (std_string_String -> US9) = method55()
    let v30 : US9 = match v24 with Ok x -> v27 x | Error x -> v28 x
    let v295 : US8 =
        match v30 with
        | US9_1(v148) -> (* Error *)
            let v149 : bool = v1 >= 15uy
            if v149 then
                let v150 : unit = ()
                let v151 : (unit -> unit) = closure30(v1, v148)
                let v152 : unit = (fun () -> v151 (); v150) ()
                let v199 : unit = ()
                let v200 : (unit -> unit) = closure31()
                let v201 : unit = (fun () -> v200 (); v199) ()
                let v204 : string = "true; let __future_init = Box::pin(/*"
                let v205 : bool = Fable.Core.RustInterop.emitRustExpr () v204 
                let v206 : string = "*/ async move { /*"
                let v207 : bool = Fable.Core.RustInterop.emitRustExpr () v206 
                let v208 : string = "*/ ()"
                let v209 : bool = Fable.Core.RustInterop.emitRustExpr () v208 
                let v210 : string = ""
                let v211 : string = "}"
                let v212 : string = v210 + v211 
                let v213 : US7 = US7_1
                let x = struct (v1, v213) //
                let v214 : _ = x
                let v215 : unit = ()
                (* run_target_args'
                let v216 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v217 : string = $"true; let _fix_closure_v215 = $0"
                let v218 : bool = Fable.Core.RustInterop.emitRustExpr v214 v217 
                let _run_target_args'_v216 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v219 : string = $"true; let _fix_closure_v215 = $0"
                let v220 : bool = Fable.Core.RustInterop.emitRustExpr v214 v219 
                let _run_target_args'_v216 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v221 : string = $"true; let _fix_closure_v215 = $0"
                let v222 : bool = Fable.Core.RustInterop.emitRustExpr v214 v221 
                let _run_target_args'_v216 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v216 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v216 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v216 = false 
                #endif
#else
                let _run_target_args'_v216 = false 
                #endif
                let v223 : bool = _run_target_args'_v216 
                let v225 : string = $"true; _fix_closure_v215 " + v212 + "); " + v210 + " // rust.fix_closure'"
                let v226 : bool = Fable.Core.RustInterop.emitRustExpr () v225 
                let v227 : string = "__future_init"
                let v228 : _ = Fable.Core.RustInterop.emitRustExpr () v227 
                let v229 : string = "v228"
                let v230 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v229 
                let v231 : string = "v230.await"
                let struct (v232 : uint8, v233 : US7) = Fable.Core.RustInterop.emitRustExpr () v231 
                US8_0(v232, v233)
            else
                let v235 : unit = ()
                let v236 : (unit -> unit) = closure32(v1, v148)
                let v237 : unit = (fun () -> v236 (); v235) ()
                let v284 : unit = ()
                let v285 : (unit -> unit) = closure33()
                let v286 : unit = (fun () -> v285 (); v284) ()
                let v289 : uint8 = v1 + 1uy
                let v290 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = method28(v0, v289)
                let v291 : string = "v290.await"
                let v292 : US8 = Fable.Core.RustInterop.emitRustExpr () v291 
                v292
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
                let v66 : unit = ()
                let v67 : (unit -> unit) = closure34(v1, v65)
                let v68 : unit = (fun () -> v67 (); v66) ()
                let v115 : string = "true; let __future_init = Box::pin(/*"
                let v116 : bool = Fable.Core.RustInterop.emitRustExpr () v115 
                let v117 : string = "*/ async move { /*"
                let v118 : bool = Fable.Core.RustInterop.emitRustExpr () v117 
                let v119 : string = "*/ ()"
                let v120 : bool = Fable.Core.RustInterop.emitRustExpr () v119 
                let v121 : string = ""
                let v122 : string = "}"
                let v123 : string = v121 + v122 
                let v124 : US7 = US7_0(v65)
                let x = struct (v1, v124) //
                let v125 : _ = x
                let v126 : unit = ()
                (* run_target_args'
                let v127 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v128 : string = $"true; let _fix_closure_v126 = $0"
                let v129 : bool = Fable.Core.RustInterop.emitRustExpr v125 v128 
                let _run_target_args'_v127 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v130 : string = $"true; let _fix_closure_v126 = $0"
                let v131 : bool = Fable.Core.RustInterop.emitRustExpr v125 v130 
                let _run_target_args'_v127 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v132 : string = $"true; let _fix_closure_v126 = $0"
                let v133 : bool = Fable.Core.RustInterop.emitRustExpr v125 v132 
                let _run_target_args'_v127 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v127 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v127 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v127 = false 
                #endif
#else
                let _run_target_args'_v127 = false 
                #endif
                let v134 : bool = _run_target_args'_v127 
                let v136 : string = $"true; _fix_closure_v126 " + v123 + "); " + v121 + " // rust.fix_closure'"
                let v137 : bool = Fable.Core.RustInterop.emitRustExpr () v136 
                let v138 : string = "__future_init"
                let v139 : _ = Fable.Core.RustInterop.emitRustExpr () v138 
                let v140 : string = "v139"
                let v141 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v140 
                let v142 : string = "v141.await"
                let struct (v143 : uint8, v144 : US7) = Fable.Core.RustInterop.emitRustExpr () v142 
                US8_1(v143, v144)
    let v296 : string = ""
    let v297 : string = "}"
    let v298 : string = v296 + v297 
    let x = v295 //
    let v299 : _ = x
    let v300 : unit = ()
    (* run_target_args'
    let v301 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v302 : string = $"true; let _fix_closure_v300 = $0"
    let v303 : bool = Fable.Core.RustInterop.emitRustExpr v299 v302 
    let _run_target_args'_v301 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v304 : string = $"true; let _fix_closure_v300 = $0"
    let v305 : bool = Fable.Core.RustInterop.emitRustExpr v299 v304 
    let _run_target_args'_v301 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v306 : string = $"true; let _fix_closure_v300 = $0"
    let v307 : bool = Fable.Core.RustInterop.emitRustExpr v299 v306 
    let _run_target_args'_v301 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v301 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v301 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v301 = false 
    #endif
#else
    let _run_target_args'_v301 = false 
    #endif
    let v308 : bool = _run_target_args'_v301 
    let v310 : string = $"true; _fix_closure_v300 " + v298 + "); " + v296 + " // rust.fix_closure'"
    let v311 : bool = Fable.Core.RustInterop.emitRustExpr () v310 
    let v312 : string = "__future_init"
    let v313 : _ = Fable.Core.RustInterop.emitRustExpr () v312 
    let v314 : string = "v313"
    let v315 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = Fable.Core.RustInterop.emitRustExpr () v314 
    v315
and method64 (v0 : US8) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "retries"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure8(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure8(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    let v37 : string = $"%A{v0}"
    let v41 : string = $"{v37}"
    let v44 : unit = ()
    let v45 : (unit -> unit) = closure8(v2, v41)
    let v46 : unit = (fun () -> v45 (); v44) ()
    let v51 : string = " }"
    let v52 : string = $"{v51}"
    let v55 : unit = ()
    let v56 : (unit -> unit) = closure8(v2, v52)
    let v57 : unit = (fun () -> v56 (); v55) ()
    let v60 : string = v2.l0
    v60
and method63 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : US8) : string =
    let v9 : string = method64(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "spiral_wasm.run"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method20(v13)
and closure35 (v0 : US8) () : unit =
    let v1 : US3 = US3_0
    let v2 : bool = method9(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure6()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method10(v26, v27, v28, v29, v30, v31)
        let v45 : string = method14()
        let v46 : string = method63(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method21(v46)
and method65 (v0 : US8, v1 : US7) : string =
    let v2 : string = method16()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure8(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "retries"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure8(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure8(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"%A{v0}"
    let v42 : string = $"{v38}"
    let v45 : unit = ()
    let v46 : (unit -> unit) = closure8(v3, v42)
    let v47 : unit = (fun () -> v46 (); v45) ()
    let v52 : string = "; "
    let v53 : string = $"{v52}"
    let v56 : unit = ()
    let v57 : (unit -> unit) = closure8(v3, v53)
    let v58 : unit = (fun () -> v57 (); v56) ()
    let v63 : string = "error"
    let v64 : string = $"{v63}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure8(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v28}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure8(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = $"%A{v1}"
    let v86 : string = $"{v82}"
    let v89 : unit = ()
    let v90 : (unit -> unit) = closure8(v3, v86)
    let v91 : unit = (fun () -> v90 (); v89) ()
    let v96 : string = " }"
    let v97 : string = $"{v96}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure8(v3, v97)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v105 : string = v3.l0
    v105
and method24 (v0 : clap_ArgMatches) : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> =
    let v1 : string = "true; let __future_init = Box::pin(/*"
    let v2 : bool = Fable.Core.RustInterop.emitRustExpr () v1 
    let v3 : string = "*/ async move { /*"
    let v4 : bool = Fable.Core.RustInterop.emitRustExpr () v3 
    let v5 : string = "*/ ()"
    let v6 : bool = Fable.Core.RustInterop.emitRustExpr () v5 
    let v7 : string = method25()
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
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure13(v76)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v126 : string = "std::fs::read(&*$0)"
    let v127 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v76 v126 
    let v128 : string = "$0?"
    let v129 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let v130 : uint8 = 1uy
    let v131 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = method28(v129, v130)
    let v132 : string = "v131.await"
    let v133 : US8 = Fable.Core.RustInterop.emitRustExpr () v132 
    let v134 : unit = ()
    let v135 : (unit -> unit) = closure35(v133)
    let v136 : unit = (fun () -> v135 (); v134) ()
    let v210 : Result<uint8, anyhow_Error> =
        match v133 with
        | US8_1(v189, v190) -> (* Error *)
            let v191 : string = method65(v133, v190)
            let v192 : string = "anyhow::anyhow!($0)"
            let v193 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v191 v192 
            (* run_target_args'
            let v195 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v196 : string = "Err($0)"
            let v197 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v193 v196 
            let _run_target_args'_v195 = v197 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v198 : string = "Err($0)"
            let v199 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v193 v198 
            let _run_target_args'_v195 = v199 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v200 : string = "Err($0)"
            let v201 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v193 v200 
            let _run_target_args'_v195 = v201 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v202 : Result<uint8, anyhow_Error> = v193 |> Error
            let _run_target_args'_v195 = v202 
            #endif
#if FABLE_COMPILER_PYTHON
            let v203 : Result<uint8, anyhow_Error> = v193 |> Error
            let _run_target_args'_v195 = v203 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v204 : Result<uint8, anyhow_Error> = v193 |> Error
            let _run_target_args'_v195 = v204 
            #endif
#else
            let v205 : Result<uint8, anyhow_Error> = v193 |> Error
            let _run_target_args'_v195 = v205 
            #endif
            let v206 : Result<uint8, anyhow_Error> = _run_target_args'_v195 
            v206
        | US8_0(v183, v184) -> (* Ok *)
            let v186 : Result<uint8, anyhow_Error> = Ok v183 
            v186
    let v211 : string = ""
    let v212 : string = "}"
    let v213 : string = v211 + v212 
    let x = v210 //
    let v214 : _ = x
    let v215 : unit = ()
    (* run_target_args'
    let v216 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v217 : string = $"true; let _fix_closure_v215 = $0"
    let v218 : bool = Fable.Core.RustInterop.emitRustExpr v214 v217 
    let _run_target_args'_v216 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v219 : string = $"true; let _fix_closure_v215 = $0"
    let v220 : bool = Fable.Core.RustInterop.emitRustExpr v214 v219 
    let _run_target_args'_v216 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v221 : string = $"true; let _fix_closure_v215 = $0"
    let v222 : bool = Fable.Core.RustInterop.emitRustExpr v214 v221 
    let _run_target_args'_v216 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v216 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v216 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v216 = false 
    #endif
#else
    let _run_target_args'_v216 = false 
    #endif
    let v223 : bool = _run_target_args'_v216 
    let v225 : string = $"true; _fix_closure_v215 " + v213 + "); " + v211 + " // rust.fix_closure'"
    let v226 : bool = Fable.Core.RustInterop.emitRustExpr () v225 
    let v227 : string = "__future_init"
    let v228 : _ = Fable.Core.RustInterop.emitRustExpr () v227 
    let v229 : string = "v228"
    let v230 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v229 
    v230
and closure36 () (v0 : uint8) : US10 =
    US10_0(v0)
and method66 () : (uint8 -> US10) =
    closure36()
and closure37 () (v0 : std_string_String) : US10 =
    US10_1(v0)
and method67 () : (std_string_String -> US10) =
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
    let v212 : unit = ()
    let v213 : (unit -> unit) = closure2(v211)
    let v214 : unit = (fun () -> v213 (); v212) ()
    let struct (v233 : Mut0, v234 : Mut1, v235 : Mut2, v236 : Mut3, v237 : Mut4, v238 : int64 option) = TraceState.trace_state.Value
    let v251 : unit = ()
    let v252 : (unit -> unit) = closure5(v0)
    let v253 : unit = (fun () -> v252 (); v251) ()
    let v300 : string = method22()
    (* run_target_args'
    let v305 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v306 : string = "&*$0"
    let v307 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v300 v306 
    let _run_target_args'_v305 = v307 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v308 : string = "&*$0"
    let v309 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v300 v308 
    let _run_target_args'_v305 = v309 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v310 : string = "&*$0"
    let v311 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v300 v310 
    let _run_target_args'_v305 = v311 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v313 : Ref<Str> = v300 |> unbox<Ref<Str>>
    let _run_target_args'_v305 = v313 
    #endif
#if FABLE_COMPILER_PYTHON
    let v317 : Ref<Str> = v300 |> unbox<Ref<Str>>
    let _run_target_args'_v305 = v317 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v321 : Ref<Str> = v300 |> unbox<Ref<Str>>
    let _run_target_args'_v305 = v321 
    #endif
#else
    let v325 : Ref<Str> = v300 |> unbox<Ref<Str>>
    let _run_target_args'_v305 = v325 
    #endif
    let v328 : Ref<Str> = _run_target_args'_v305 
    let v334 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v335 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v328) v334 
    let v338 : (std_string_String -> string) = method23()
    let v339 : string option = v335 |> Option.map v338 
    let v446 : (string -> US7) = method8()
    let v447 : US7 option = v339 |> Option.map v446 
    let v467 : US7 = US7_1
    let v468 : US7 = v447 |> Option.defaultValue v467 
    let v472 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method24(v3)
    let v473 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v474 : _ = Fable.Core.RustInterop.emitRustExpr () v473 
    let v475 : string = "v474.handle().block_on($0)"
    let v476 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v472 v475 
    let v477 : (anyhow_Error -> std_string_String) = method53()
    (* run_target_args'
    let v479 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v480 : string = "$0.map_err(|x| $1(x))"
    let v481 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v476, v477) v480 
    let _run_target_args'_v479 = v481 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v482 : string = "$0.map_err(|x| $1(x))"
    let v483 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v476, v477) v482 
    let _run_target_args'_v479 = v483 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v484 : string = "$0.map_err(|x| $1(x))"
    let v485 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v476, v477) v484 
    let _run_target_args'_v479 = v485 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v486 : Result<uint8, std_string_String> = match v476 with Ok x -> Ok x | Error x -> Error (v477 x)
    let _run_target_args'_v479 = v486 
    #endif
#if FABLE_COMPILER_PYTHON
    let v487 : Result<uint8, std_string_String> = match v476 with Ok x -> Ok x | Error x -> Error (v477 x)
    let _run_target_args'_v479 = v487 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v488 : Result<uint8, std_string_String> = match v476 with Ok x -> Ok x | Error x -> Error (v477 x)
    let _run_target_args'_v479 = v488 
    #endif
#else
    let v489 : Result<uint8, std_string_String> = match v476 with Ok x -> Ok x | Error x -> Error (v477 x)
    let _run_target_args'_v479 = v489 
    #endif
    let v490 : Result<uint8, std_string_String> = _run_target_args'_v479 
    let v493 : (uint8 -> US10) = method66()
    let v494 : (std_string_String -> US10) = method67()
    let v496 : US10 = match v490 with Ok x -> v493 x | Error x -> v494 x
    match v496 with
    | US10_1(v521) -> (* Error *)
        match v468 with
        | US7_0(v522) -> (* Some *)
            let v523 : bool = "" = v522
            if v523 then
                ()
            else
                let v524 : string = "fable_library_rust::String_::fromString($0)"
                let v525 : string = Fable.Core.RustInterop.emitRustExpr v521 v524 
                let v527 : bool = v525.Contains v522 
                if v527 then
                    ()
                else
                    let v530 : string = $"spiral_wasm.main / exception: '{v522}' / error: {v521}"
                    (* run_target_args'
                    let v532 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v533 : string = "Err($0)"
                    let v534 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v530 v533 
                    let _run_target_args'_v532 = v534 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v535 : string = "Err($0)"
                    let v536 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v530 v535 
                    let _run_target_args'_v532 = v536 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v537 : string = "Err($0)"
                    let v538 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v530 v537 
                    let _run_target_args'_v532 = v538 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v539 : Result<unit, string> = v530 |> Error
                    let _run_target_args'_v532 = v539 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v540 : Result<unit, string> = v530 |> Error
                    let _run_target_args'_v532 = v540 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v541 : Result<unit, string> = v530 |> Error
                    let _run_target_args'_v532 = v541 
                    #endif
#else
                    let v542 : Result<unit, string> = v530 |> Error
                    let _run_target_args'_v532 = v542 
                    #endif
                    let v543 : Result<unit, string> = _run_target_args'_v532 
                    (* run_target_args'
                    let v546 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v547 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v543 v547 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v548 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v543 v548 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v549 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v543 v549 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    match v543 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if FABLE_COMPILER_PYTHON
                    match v543 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    match v543 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#else
                    match v543 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
                    // run_target_args' is_unit
                    ()
        | _ ->
            (* run_target_args'
            let v551 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v552 : string = "$0.unwrap()"
            let v553 : uint8 = Fable.Core.RustInterop.emitRustExpr v490 v552 
            let _run_target_args'_v551 = v553 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v554 : string = "$0.unwrap()"
            let v555 : uint8 = Fable.Core.RustInterop.emitRustExpr v490 v554 
            let _run_target_args'_v551 = v555 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v556 : string = "$0.unwrap()"
            let v557 : uint8 = Fable.Core.RustInterop.emitRustExpr v490 v556 
            let _run_target_args'_v551 = v557 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v558 : uint8 = match v490 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v551 = v558 
            #endif
#if FABLE_COMPILER_PYTHON
            let v559 : uint8 = match v490 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v551 = v559 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v560 : uint8 = match v490 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v551 = v560 
            #endif
#else
            let v561 : uint8 = match v490 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v551 = v561 
            #endif
            let v562 : uint8 = _run_target_args'_v551 
            ()
    | US10_0(v499) -> (* Ok *)
        match v468 with
        | US7_0(v500) -> (* Some *)
            let v501 : string = $"spiral_wasm.main / retries: {v499} / exception: '{v500}'"
            (* run_target_args'
            let v503 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v504 : string = "Err($0)"
            let v505 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v501 v504 
            let _run_target_args'_v503 = v505 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v506 : string = "Err($0)"
            let v507 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v501 v506 
            let _run_target_args'_v503 = v507 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v508 : string = "Err($0)"
            let v509 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v501 v508 
            let _run_target_args'_v503 = v509 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v510 : Result<unit, string> = v501 |> Error
            let _run_target_args'_v503 = v510 
            #endif
#if FABLE_COMPILER_PYTHON
            let v511 : Result<unit, string> = v501 |> Error
            let _run_target_args'_v503 = v511 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v512 : Result<unit, string> = v501 |> Error
            let _run_target_args'_v503 = v512 
            #endif
#else
            let v513 : Result<unit, string> = v501 |> Error
            let _run_target_args'_v503 = v513 
            #endif
            let v514 : Result<unit, string> = _run_target_args'_v503 
            (* run_target_args'
            let v517 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v518 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v514 v518 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v519 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v514 v519 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v520 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v514 v520 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            match v514 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if FABLE_COMPILER_PYTHON
            match v514 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            match v514 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#else
            match v514 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
            // run_target_args' is_unit
            ()
        | _ ->
            ()
    0
let v0 : ((string []) -> int32) = closure0()
let main args = v0 args
()
