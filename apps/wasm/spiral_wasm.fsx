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
    let v121 : (string list -> (string [])) = List.toArray
    let v122 : (string []) = v121 v115
    let v125 : string = "$0.to_vec()"
    let v126 : Vec<string> = Fable.Core.RustInterop.emitRustExpr v122 v125 
    let v127 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v128 : bool = Fable.Core.RustInterop.emitRustExpr v126 v127 
    let v129 : string = "x"
    let v130 : string = Fable.Core.RustInterop.emitRustExpr () v129 
    (* run_target_args'
    let v135 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v136 : string = "&*$0"
    let v137 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v130 v136 
    let _run_target_args'_v135 = v137 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v138 : string = "&*$0"
    let v139 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v130 v138 
    let _run_target_args'_v135 = v139 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v140 : string = "&*$0"
    let v141 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v130 v140 
    let _run_target_args'_v135 = v141 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v143 : Ref<Str> = v130 |> unbox<Ref<Str>>
    let _run_target_args'_v135 = v143 
    #endif
#if FABLE_COMPILER_PYTHON
    let v147 : Ref<Str> = v130 |> unbox<Ref<Str>>
    let _run_target_args'_v135 = v147 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v151 : Ref<Str> = v130 |> unbox<Ref<Str>>
    let _run_target_args'_v135 = v151 
    #endif
#else
    let v155 : Ref<Str> = v130 |> unbox<Ref<Str>>
    let _run_target_args'_v135 = v155 
    #endif
    let v158 : Ref<Str> = _run_target_args'_v135 
    (* run_target_args'
    let v171 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v172 : string = "String::from($0)"
    let v173 : std_string_String = Fable.Core.RustInterop.emitRustExpr v158 v172 
    let _run_target_args'_v171 = v173 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v174 : string = "String::from($0)"
    let v175 : std_string_String = Fable.Core.RustInterop.emitRustExpr v158 v174 
    let _run_target_args'_v171 = v175 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v176 : string = "String::from($0)"
    let v177 : std_string_String = Fable.Core.RustInterop.emitRustExpr v158 v176 
    let _run_target_args'_v171 = v177 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v179 : std_string_String = v158 |> unbox<std_string_String>
    let _run_target_args'_v171 = v179 
    #endif
#if FABLE_COMPILER_PYTHON
    let v183 : std_string_String = v158 |> unbox<std_string_String>
    let _run_target_args'_v171 = v183 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v187 : std_string_String = v158 |> unbox<std_string_String>
    let _run_target_args'_v171 = v187 
    #endif
#else
    let v191 : std_string_String = v158 |> unbox<std_string_String>
    let _run_target_args'_v171 = v191 
    #endif
    let v194 : std_string_String = _run_target_args'_v171 
    let v203 : string = "Box::new($0)"
    let v204 : Box<std_string_String> = Fable.Core.RustInterop.emitRustExpr v194 v203 
    let v205 : string = "Box::leak($0)"
    let v206 : Ref<Lifetime<StaticLifetime, Mut<std_string_String>>> = Fable.Core.RustInterop.emitRustExpr v204 v205 
    let v207 : string = "clap::builder::PossibleValue::new(&**$0)"
    let v208 : clap_builder_PossibleValue = Fable.Core.RustInterop.emitRustExpr v206 v207 
    let v209 : string = "true; $0 }).collect::<Vec<_>>()"
    let v210 : bool = Fable.Core.RustInterop.emitRustExpr v208 v209 
    let v211 : string = "_vec_map"
    let v212 : Vec<clap_builder_PossibleValue> = Fable.Core.RustInterop.emitRustExpr () v211 
    let v213 : string = "Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new($0))"
    let v214 : clap_builder_ValueParser = Fable.Core.RustInterop.emitRustExpr v212 v213 
    let v215 : string = "$0.value_parser($1)"
    let v216 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v61, v214) v215 
    let v217 : string = "clap::Command::arg($0, $1)"
    let v218 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v50, v216) v217 
    let v219 : string = "wasm"
    let v220 : string = "r#\"" + v219 + "\"#"
    let v221 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v220 
    let v222 : string = "clap::Arg::new($0)"
    let v223 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v221 v222 
    let v224 : string = "$0.short($1)"
    let v225 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v223, 'w') v224 
    let v226 : string = "r#\"" + v219 + "\"#"
    let v227 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v226 
    let v228 : string = "$0.long($1)"
    let v229 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v225, v227) v228 
    let v230 : string = "$0.required($1)"
    let v231 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v229, true) v230 
    let v232 : string = "clap::Command::arg($0, $1)"
    let v233 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v218, v231) v232 
    v233
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
    let v216 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v219 : (int64 -> US4) = method10()
    let v220 : US4 option = v5 |> Option.map v219 
    let v240 : US4 = US4_1
    let v241 : US4 = v220 |> Option.defaultValue v240 
    let v395 : System.DateTime =
        match v241 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v378 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v379 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v379 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v380 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v380 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v382 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v378 = v382 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v385 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v385 
            #endif
#if FABLE_COMPILER_PYTHON
            let v386 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v386 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v387 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v387 
            #endif
#else
            let v388 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v388 
            #endif
            let v389 : System.DateTime = _run_target_args'_v378 
            v389
        | US4_0(v245) -> (* Some *)
            (* run_target_args'
            let v252 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v253 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v253 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v254 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v254 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v256 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v252 = v256 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v259 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v259 
            #endif
#if FABLE_COMPILER_PYTHON
            let v260 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v260 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v261 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v261 
            #endif
#else
            let v262 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v262 
            #endif
            let v263 : System.DateTime = _run_target_args'_v252 
            (* run_target_args'
            let v274 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v275 : (System.DateTime -> int64) = _.Ticks
            let v276 : int64 = v275 v263
            let _run_target_args'_v274 = v276 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v277 : (System.DateTime -> int64) = _.Ticks
            let v278 : int64 = v277 v263
            let _run_target_args'_v274 = v278 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v280 : int64 = null |> unbox<int64>
            let _run_target_args'_v274 = v280 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v283 : (System.DateTime -> int64) = _.Ticks
            let v284 : int64 = v283 v263
            let _run_target_args'_v274 = v284 
            #endif
#if FABLE_COMPILER_PYTHON
            let v285 : (System.DateTime -> int64) = _.Ticks
            let v286 : int64 = v285 v263
            let _run_target_args'_v274 = v286 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v287 : (System.DateTime -> int64) = _.Ticks
            let v288 : int64 = v287 v263
            let _run_target_args'_v274 = v288 
            #endif
#else
            let v289 : (System.DateTime -> int64) = _.Ticks
            let v290 : int64 = v289 v263
            let _run_target_args'_v274 = v290 
            #endif
            let v291 : int64 = _run_target_args'_v274 
            let v313 : int64 = v291 |> int64 
            let v318 : int64 = v313 - v245
            let v324 : System.TimeSpan = v318 |> System.TimeSpan 
            let v330 : (System.TimeSpan -> int32) = _.Hours
            let v331 : int32 = v330 v324
            let v335 : (System.TimeSpan -> int32) = _.Minutes
            let v336 : int32 = v335 v324
            let v340 : (System.TimeSpan -> int32) = _.Seconds
            let v341 : int32 = v340 v324
            let v345 : (System.TimeSpan -> int32) = _.Milliseconds
            let v346 : int32 = v345 v324
            let v369 : System.DateTime = System.DateTime (1, 1, 1, v331, v336, v341, v346)
            v369
    let v396 : string = method11()
    let v408 : bool = v396 = ""
    let v410 : string =
        if v408 then
            let v409 : string = "M-d-y hh:mm:ss tt"
            v409
        else
            v396
    let v411 : (string -> string) = v395.ToString
    let v412 : string = v411 v410
    let _run_target_args'_v216 = v412 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v429 : (int64 -> US4) = method10()
    let v430 : US4 option = v5 |> Option.map v429 
    let v450 : US4 = US4_1
    let v451 : US4 = v430 |> Option.defaultValue v450 
    let v605 : System.DateTime =
        match v451 with
        | US4_1 -> (* None *)
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
            v599
        | US4_0(v455) -> (* Some *)
            (* run_target_args'
            let v462 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v463 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v463 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v464 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v464 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v466 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v462 = v466 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v469 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v469 
            #endif
#if FABLE_COMPILER_PYTHON
            let v470 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v470 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v471 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v471 
            #endif
#else
            let v472 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v472 
            #endif
            let v473 : System.DateTime = _run_target_args'_v462 
            (* run_target_args'
            let v484 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v485 : (System.DateTime -> int64) = _.Ticks
            let v486 : int64 = v485 v473
            let _run_target_args'_v484 = v486 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v487 : (System.DateTime -> int64) = _.Ticks
            let v488 : int64 = v487 v473
            let _run_target_args'_v484 = v488 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v490 : int64 = null |> unbox<int64>
            let _run_target_args'_v484 = v490 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v493 : (System.DateTime -> int64) = _.Ticks
            let v494 : int64 = v493 v473
            let _run_target_args'_v484 = v494 
            #endif
#if FABLE_COMPILER_PYTHON
            let v495 : (System.DateTime -> int64) = _.Ticks
            let v496 : int64 = v495 v473
            let _run_target_args'_v484 = v496 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v497 : (System.DateTime -> int64) = _.Ticks
            let v498 : int64 = v497 v473
            let _run_target_args'_v484 = v498 
            #endif
#else
            let v499 : (System.DateTime -> int64) = _.Ticks
            let v500 : int64 = v499 v473
            let _run_target_args'_v484 = v500 
            #endif
            let v501 : int64 = _run_target_args'_v484 
            let v523 : int64 = v501 |> int64 
            let v528 : int64 = v523 - v455
            let v534 : System.TimeSpan = v528 |> System.TimeSpan 
            let v540 : (System.TimeSpan -> int32) = _.Hours
            let v541 : int32 = v540 v534
            let v545 : (System.TimeSpan -> int32) = _.Minutes
            let v546 : int32 = v545 v534
            let v550 : (System.TimeSpan -> int32) = _.Seconds
            let v551 : int32 = v550 v534
            let v555 : (System.TimeSpan -> int32) = _.Milliseconds
            let v556 : int32 = v555 v534
            let v579 : System.DateTime = System.DateTime (1, 1, 1, v541, v546, v551, v556)
            v579
    let v606 : string = method11()
    let v618 : bool = v606 = ""
    let v620 : string =
        if v618 then
            let v619 : string = "M-d-y hh:mm:ss tt"
            v619
        else
            v606
    let v621 : (string -> string) = v605.ToString
    let v622 : string = v621 v620
    let _run_target_args'_v216 = v622 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v637 : string = $"near_sdk::env::block_timestamp()"
    let v638 : uint64 = Fable.Core.RustInterop.emitRustExpr () v637 
    let v641 : (int64 -> US4) = method10()
    let v642 : US4 option = v5 |> Option.map v641 
    let v662 : US4 = US4_1
    let v663 : US4 = v642 |> Option.defaultValue v662 
    let v675 : uint64 =
        match v663 with
        | US4_1 -> (* None *)
            v638
        | US4_0(v667) -> (* Some *)
            let v669 : (int64 -> uint64) = uint64
            let v670 : uint64 = v669 v667
            let v673 : uint64 = v638 - v670
            v673
    let v676 : uint64 = v675 / 1000000000UL
    let v677 : uint64 = v676 % 60UL
    let v678 : uint64 = v676 / 60UL
    let v679 : uint64 = v678 % 60UL
    let v680 : uint64 = v676 / 3600UL
    let v681 : uint64 = v680 % 24UL
    let v682 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v683 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v681, v679, v677) v682 
    let v684 : string = "fable_library_rust::String_::fromString($0)"
    let v685 : string = Fable.Core.RustInterop.emitRustExpr v683 v684 
    let _run_target_args'_v216 = v685 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v688 : (int64 -> US4) = method10()
    let v689 : US4 option = v5 |> Option.map v688 
    let v709 : US4 = US4_1
    let v710 : US4 = v689 |> Option.defaultValue v709 
    let v864 : System.DateTime =
        match v710 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v847 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v848 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v848 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v849 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v849 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v851 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v847 = v851 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v854 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v854 
            #endif
#if FABLE_COMPILER_PYTHON
            let v855 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v855 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v856 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v856 
            #endif
#else
            let v857 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v857 
            #endif
            let v858 : System.DateTime = _run_target_args'_v847 
            v858
        | US4_0(v714) -> (* Some *)
            (* run_target_args'
            let v721 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v722 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v722 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v723 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v723 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v725 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v721 = v725 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v728 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v728 
            #endif
#if FABLE_COMPILER_PYTHON
            let v729 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v729 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v730 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v730 
            #endif
#else
            let v731 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v731 
            #endif
            let v732 : System.DateTime = _run_target_args'_v721 
            (* run_target_args'
            let v743 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v744 : (System.DateTime -> int64) = _.Ticks
            let v745 : int64 = v744 v732
            let _run_target_args'_v743 = v745 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v746 : (System.DateTime -> int64) = _.Ticks
            let v747 : int64 = v746 v732
            let _run_target_args'_v743 = v747 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v749 : int64 = null |> unbox<int64>
            let _run_target_args'_v743 = v749 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v752 : (System.DateTime -> int64) = _.Ticks
            let v753 : int64 = v752 v732
            let _run_target_args'_v743 = v753 
            #endif
#if FABLE_COMPILER_PYTHON
            let v754 : (System.DateTime -> int64) = _.Ticks
            let v755 : int64 = v754 v732
            let _run_target_args'_v743 = v755 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v756 : (System.DateTime -> int64) = _.Ticks
            let v757 : int64 = v756 v732
            let _run_target_args'_v743 = v757 
            #endif
#else
            let v758 : (System.DateTime -> int64) = _.Ticks
            let v759 : int64 = v758 v732
            let _run_target_args'_v743 = v759 
            #endif
            let v760 : int64 = _run_target_args'_v743 
            let v782 : int64 = v760 |> int64 
            let v787 : int64 = v782 - v714
            let v793 : System.TimeSpan = v787 |> System.TimeSpan 
            let v799 : (System.TimeSpan -> int32) = _.Hours
            let v800 : int32 = v799 v793
            let v804 : (System.TimeSpan -> int32) = _.Minutes
            let v805 : int32 = v804 v793
            let v809 : (System.TimeSpan -> int32) = _.Seconds
            let v810 : int32 = v809 v793
            let v814 : (System.TimeSpan -> int32) = _.Milliseconds
            let v815 : int32 = v814 v793
            let v838 : System.DateTime = System.DateTime (1, 1, 1, v800, v805, v810, v815)
            v838
    let v865 : string = method12()
    let v877 : bool = v865 = ""
    let v879 : string =
        if v877 then
            let v878 : string = "M-d-y hh:mm:ss tt"
            v878
        else
            v865
    let v880 : (string -> string) = v864.ToString
    let v881 : string = v880 v879
    let _run_target_args'_v216 = v881 
    #endif
#if FABLE_COMPILER_PYTHON
    let v898 : (int64 -> US4) = method10()
    let v899 : US4 option = v5 |> Option.map v898 
    let v919 : US4 = US4_1
    let v920 : US4 = v899 |> Option.defaultValue v919 
    let v1074 : System.DateTime =
        match v920 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1057 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1058 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1058 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1059 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1059 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1061 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1057 = v1061 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1064 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1064 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1065 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1065 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1066 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1066 
            #endif
#else
            let v1067 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1067 
            #endif
            let v1068 : System.DateTime = _run_target_args'_v1057 
            v1068
        | US4_0(v924) -> (* Some *)
            (* run_target_args'
            let v931 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v932 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v932 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v933 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v933 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v935 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v931 = v935 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v938 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v938 
            #endif
#if FABLE_COMPILER_PYTHON
            let v939 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v939 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v940 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v940 
            #endif
#else
            let v941 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v941 
            #endif
            let v942 : System.DateTime = _run_target_args'_v931 
            (* run_target_args'
            let v953 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v954 : (System.DateTime -> int64) = _.Ticks
            let v955 : int64 = v954 v942
            let _run_target_args'_v953 = v955 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v956 : (System.DateTime -> int64) = _.Ticks
            let v957 : int64 = v956 v942
            let _run_target_args'_v953 = v957 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v959 : int64 = null |> unbox<int64>
            let _run_target_args'_v953 = v959 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v962 : (System.DateTime -> int64) = _.Ticks
            let v963 : int64 = v962 v942
            let _run_target_args'_v953 = v963 
            #endif
#if FABLE_COMPILER_PYTHON
            let v964 : (System.DateTime -> int64) = _.Ticks
            let v965 : int64 = v964 v942
            let _run_target_args'_v953 = v965 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v966 : (System.DateTime -> int64) = _.Ticks
            let v967 : int64 = v966 v942
            let _run_target_args'_v953 = v967 
            #endif
#else
            let v968 : (System.DateTime -> int64) = _.Ticks
            let v969 : int64 = v968 v942
            let _run_target_args'_v953 = v969 
            #endif
            let v970 : int64 = _run_target_args'_v953 
            let v992 : int64 = v970 |> int64 
            let v997 : int64 = v992 - v924
            let v1003 : System.TimeSpan = v997 |> System.TimeSpan 
            let v1009 : (System.TimeSpan -> int32) = _.Hours
            let v1010 : int32 = v1009 v1003
            let v1014 : (System.TimeSpan -> int32) = _.Minutes
            let v1015 : int32 = v1014 v1003
            let v1019 : (System.TimeSpan -> int32) = _.Seconds
            let v1020 : int32 = v1019 v1003
            let v1024 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1025 : int32 = v1024 v1003
            let v1048 : System.DateTime = System.DateTime (1, 1, 1, v1010, v1015, v1020, v1025)
            v1048
    let v1075 : string = method12()
    let v1087 : bool = v1075 = ""
    let v1089 : string =
        if v1087 then
            let v1088 : string = "M-d-y hh:mm:ss tt"
            v1088
        else
            v1075
    let v1090 : (string -> string) = v1074.ToString
    let v1091 : string = v1090 v1089
    let _run_target_args'_v216 = v1091 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1108 : (int64 -> US4) = method10()
    let v1109 : US4 option = v5 |> Option.map v1108 
    let v1129 : US4 = US4_1
    let v1130 : US4 = v1109 |> Option.defaultValue v1129 
    let v1284 : System.DateTime =
        match v1130 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1267 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1268 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1268 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1269 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1269 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1271 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1267 = v1271 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1274 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1274 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1275 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1275 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1276 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1276 
            #endif
#else
            let v1277 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1277 
            #endif
            let v1278 : System.DateTime = _run_target_args'_v1267 
            v1278
        | US4_0(v1134) -> (* Some *)
            (* run_target_args'
            let v1141 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1142 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1142 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1143 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1143 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1145 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1141 = v1145 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1148 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1148 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1149 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1149 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1150 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1150 
            #endif
#else
            let v1151 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1151 
            #endif
            let v1152 : System.DateTime = _run_target_args'_v1141 
            (* run_target_args'
            let v1163 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1164 : (System.DateTime -> int64) = _.Ticks
            let v1165 : int64 = v1164 v1152
            let _run_target_args'_v1163 = v1165 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1166 : (System.DateTime -> int64) = _.Ticks
            let v1167 : int64 = v1166 v1152
            let _run_target_args'_v1163 = v1167 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1169 : int64 = null |> unbox<int64>
            let _run_target_args'_v1163 = v1169 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1172 : (System.DateTime -> int64) = _.Ticks
            let v1173 : int64 = v1172 v1152
            let _run_target_args'_v1163 = v1173 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1174 : (System.DateTime -> int64) = _.Ticks
            let v1175 : int64 = v1174 v1152
            let _run_target_args'_v1163 = v1175 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1176 : (System.DateTime -> int64) = _.Ticks
            let v1177 : int64 = v1176 v1152
            let _run_target_args'_v1163 = v1177 
            #endif
#else
            let v1178 : (System.DateTime -> int64) = _.Ticks
            let v1179 : int64 = v1178 v1152
            let _run_target_args'_v1163 = v1179 
            #endif
            let v1180 : int64 = _run_target_args'_v1163 
            let v1202 : int64 = v1180 |> int64 
            let v1207 : int64 = v1202 - v1134
            let v1213 : System.TimeSpan = v1207 |> System.TimeSpan 
            let v1219 : (System.TimeSpan -> int32) = _.Hours
            let v1220 : int32 = v1219 v1213
            let v1224 : (System.TimeSpan -> int32) = _.Minutes
            let v1225 : int32 = v1224 v1213
            let v1229 : (System.TimeSpan -> int32) = _.Seconds
            let v1230 : int32 = v1229 v1213
            let v1234 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1235 : int32 = v1234 v1213
            let v1258 : System.DateTime = System.DateTime (1, 1, 1, v1220, v1225, v1230, v1235)
            v1258
    let v1285 : string = method12()
    let v1297 : bool = v1285 = ""
    let v1299 : string =
        if v1297 then
            let v1298 : string = "M-d-y hh:mm:ss tt"
            v1298
        else
            v1285
    let v1300 : (string -> string) = v1284.ToString
    let v1301 : string = v1300 v1299
    let _run_target_args'_v216 = v1301 
    #endif
#else
    let v1318 : (int64 -> US4) = method10()
    let v1319 : US4 option = v5 |> Option.map v1318 
    let v1339 : US4 = US4_1
    let v1340 : US4 = v1319 |> Option.defaultValue v1339 
    let v1494 : System.DateTime =
        match v1340 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1477 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1478 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1478 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1479 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1479 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1481 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1477 = v1481 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1484 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1484 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1485 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1485 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1486 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1486 
            #endif
#else
            let v1487 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1487 
            #endif
            let v1488 : System.DateTime = _run_target_args'_v1477 
            v1488
        | US4_0(v1344) -> (* Some *)
            (* run_target_args'
            let v1351 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1352 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1352 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1353 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1353 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1355 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1351 = v1355 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1358 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1358 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1359 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1359 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1360 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1360 
            #endif
#else
            let v1361 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1361 
            #endif
            let v1362 : System.DateTime = _run_target_args'_v1351 
            (* run_target_args'
            let v1373 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1374 : (System.DateTime -> int64) = _.Ticks
            let v1375 : int64 = v1374 v1362
            let _run_target_args'_v1373 = v1375 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1376 : (System.DateTime -> int64) = _.Ticks
            let v1377 : int64 = v1376 v1362
            let _run_target_args'_v1373 = v1377 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1379 : int64 = null |> unbox<int64>
            let _run_target_args'_v1373 = v1379 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1382 : (System.DateTime -> int64) = _.Ticks
            let v1383 : int64 = v1382 v1362
            let _run_target_args'_v1373 = v1383 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1384 : (System.DateTime -> int64) = _.Ticks
            let v1385 : int64 = v1384 v1362
            let _run_target_args'_v1373 = v1385 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1386 : (System.DateTime -> int64) = _.Ticks
            let v1387 : int64 = v1386 v1362
            let _run_target_args'_v1373 = v1387 
            #endif
#else
            let v1388 : (System.DateTime -> int64) = _.Ticks
            let v1389 : int64 = v1388 v1362
            let _run_target_args'_v1373 = v1389 
            #endif
            let v1390 : int64 = _run_target_args'_v1373 
            let v1412 : int64 = v1390 |> int64 
            let v1417 : int64 = v1412 - v1344
            let v1423 : System.TimeSpan = v1417 |> System.TimeSpan 
            let v1429 : (System.TimeSpan -> int32) = _.Hours
            let v1430 : int32 = v1429 v1423
            let v1434 : (System.TimeSpan -> int32) = _.Minutes
            let v1435 : int32 = v1434 v1423
            let v1439 : (System.TimeSpan -> int32) = _.Seconds
            let v1440 : int32 = v1439 v1423
            let v1444 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1445 : int32 = v1444 v1423
            let v1468 : System.DateTime = System.DateTime (1, 1, 1, v1430, v1435, v1440, v1445)
            v1468
    let v1495 : string = method12()
    let v1507 : bool = v1495 = ""
    let v1509 : string =
        if v1507 then
            let v1508 : string = "M-d-y hh:mm:ss tt"
            v1508
        else
            v1495
    let v1510 : (string -> string) = v1494.ToString
    let v1511 : string = v1510 v1509
    let _run_target_args'_v216 = v1511 
    #endif
    let v1526 : string = _run_target_args'_v216 
    v1526
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
    let v3 : Mut3 = {l0 = v1} : Mut3
    let v8 : string = $"{v0}"
    method16(v3, v8)
    let v24 : string = v3.l0
    v24
and method13 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_bright_black"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "String::from($0)"
    let v10 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v16 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v24 
    #endif
#else
    let v28 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v28 
    #endif
    let v31 : std_string_String = _run_target_args'_v8 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v31 v40 
    let _run_target_args'_v1 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "inline_colorization::color_bright_black"
    let v43 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v42 
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v49 
    let _run_target_args'_v48 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v51 
    let _run_target_args'_v48 = v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = "String::from($0)"
    let v54 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v53 
    let _run_target_args'_v48 = v54 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v56 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v56 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v64 
    #endif
#else
    let v68 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v68 
    #endif
    let v71 : std_string_String = _run_target_args'_v48 
    let v80 : string = "fable_library_rust::String_::fromString($0)"
    let v81 : string = Fable.Core.RustInterop.emitRustExpr v71 v80 
    let _run_target_args'_v1 = v81 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string = "inline_colorization::color_bright_black"
    let v83 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v82 
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "String::from($0)"
    let v90 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "String::from($0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "String::from($0)"
    let v94 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : std_string_String = _run_target_args'_v88 
    let v120 : string = "fable_library_rust::String_::fromString($0)"
    let v121 : string = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let _run_target_args'_v1 = v121 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v122 : string = "\u001b[90m"
    let _run_target_args'_v1 = v122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : string = "\u001b[90m"
    let _run_target_args'_v1 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v124 : string = "\u001b[90m"
    let _run_target_args'_v1 = v124 
    #endif
#else
    let v125 : string = "\u001b[90m"
    let _run_target_args'_v1 = v125 
    #endif
    let v126 : string = _run_target_args'_v1 
    
    
    
    
    
    let v131 : string = "Verbose"
    let v132 : (unit -> string) = v131.ToLower
    let v133 : string = v132 ()
    let v136 : char = v133.[int 0]
    let v137 : string = method14(v136)
    let v139 : string = v126 + v137 
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "inline_colorization::color_reset"
    let v145 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v144 
    (* run_target_args'
    let v150 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v151 : string = "String::from($0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v151 
    let _run_target_args'_v150 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "String::from($0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v153 
    let _run_target_args'_v150 = v154 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v155 : string = "String::from($0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v155 
    let _run_target_args'_v150 = v156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v158 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v158 
    #endif
#if FABLE_COMPILER_PYTHON
    let v162 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v162 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v166 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v166 
    #endif
#else
    let v170 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v170 
    #endif
    let v173 : std_string_String = _run_target_args'_v150 
    let v182 : string = "fable_library_rust::String_::fromString($0)"
    let v183 : string = Fable.Core.RustInterop.emitRustExpr v173 v182 
    let _run_target_args'_v143 = v183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v184 : string = "inline_colorization::color_reset"
    let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v184 
    (* run_target_args'
    let v190 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v191 : string = "String::from($0)"
    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v191 
    let _run_target_args'_v190 = v192 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v193 : string = "String::from($0)"
    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v193 
    let _run_target_args'_v190 = v194 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v195 : string = "String::from($0)"
    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v195 
    let _run_target_args'_v190 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v198 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v202 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v206 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v206 
    #endif
#else
    let v210 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v210 
    #endif
    let v213 : std_string_String = _run_target_args'_v190 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v213 v222 
    let _run_target_args'_v143 = v223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v224 : string = "inline_colorization::color_reset"
    let v225 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v224 
    (* run_target_args'
    let v230 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v231 : string = "String::from($0)"
    let v232 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v231 
    let _run_target_args'_v230 = v232 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v233 : string = "String::from($0)"
    let v234 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v233 
    let _run_target_args'_v230 = v234 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v235 : string = "String::from($0)"
    let v236 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v235 
    let _run_target_args'_v230 = v236 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v238 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v238 
    #endif
#if FABLE_COMPILER_PYTHON
    let v242 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v246 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v246 
    #endif
#else
    let v250 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v250 
    #endif
    let v253 : std_string_String = _run_target_args'_v230 
    let v262 : string = "fable_library_rust::String_::fromString($0)"
    let v263 : string = Fable.Core.RustInterop.emitRustExpr v253 v262 
    let _run_target_args'_v143 = v263 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v264 : string = "\u001b[0m"
    let _run_target_args'_v143 = v264 
    #endif
#if FABLE_COMPILER_PYTHON
    let v265 : string = "\u001b[0m"
    let _run_target_args'_v143 = v265 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v266 : string = "\u001b[0m"
    let _run_target_args'_v143 = v266 
    #endif
#else
    let v267 : string = "\u001b[0m"
    let _run_target_args'_v143 = v267 
    #endif
    let v268 : string = _run_target_args'_v143 
    let v272 : string = v139 + v268 
    v272
and method18 (v0 : (string [])) : string =
    let v1 : string = method15()
    let v3 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    method16(v3, v5)
    let v20 : string = "args"
    method16(v3, v20)
    let v35 : string = " = "
    method16(v3, v35)
    let v51 : string = $"%A{v0}"
    method16(v3, v51)
    let v69 : string = " }"
    method16(v3, v69)
    let v83 : string = v3.l0
    v83
and method19 (v0 : string) : string =
    let v1 : char list = []
    let v7 : (char list -> (char [])) = List.toArray
    let v8 : (char []) = v7 v1
    let v11 : string = v0.TrimStart v8 
    let v45 : char list = []
    let v47 : char list = '/' :: v45 
    let v51 : char list = ' ' :: v47 
    let v59 : (char list -> (char [])) = List.toArray
    let v60 : (char []) = v59 v51
    let v63 : string = v11.TrimEnd v60 
    v63
and method17 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : (string [])) : string =
    let v9 : string = method18(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v31 : (int64 -> string) = _.ToString()
    let v32 : string = v31 v10
    let v36 : string = v24 + v32 
    let v40 : string = v36 + v13 
    let v45 : string = "spiral_wasm.main"
    let v46 : string = v40 + v45 
    let v51 : string = " / "
    let v52 : string = v46 + v51 
    let v56 : string = v52 + v9 
    method19(v56)
and closure8 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure10 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure9 () (v0 : string) : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure10(v0)
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
    let v336 : US8 =
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
            let v184 : (unit -> unit) = closure8(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure9()
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
            let v308 : int32 = v264 |> int32 
            let v318 : string = ""
            let v319 : bool = v124 <> v318 
            let v323 : bool =
                if v319 then
                    let v322 : bool = v308 <= 1
                    v322
                else
                    false
            if v323 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v318
                let v324 : string = "true; $0.into_iter().for_each(|x| { //"
                let v325 : bool = Fable.Core.RustInterop.emitRustExpr v262 v324 
                let v326 : string = "x"
                let v327 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v326 
                let v328 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v329 : bool = Fable.Core.RustInterop.emitRustExpr v327 v328 
                let v330 : string = $"true"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr () v330 
                let v332 : string = "true; }); //"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
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
            let v334 : (string -> unit) = v164.l0
            v334 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method20 () : string =
    let v0 : string = "exception"
    v0
and closure11 () (v0 : std_string_String) : string =
    let v1 : string = "fable_library_rust::String_::fromString($0)"
    let v2 : string = Fable.Core.RustInterop.emitRustExpr v0 v1 
    let v3 : char list = []
    let v5 : char list = '\\' :: v3 
    let v13 : (char list -> (char [])) = List.toArray
    let v14 : (char []) = v13 v5
    let v17 : string = v2.TrimStart v14 
    let v51 : char list = []
    let v53 : char list = '\\' :: v51 
    let v61 : (char list -> (char [])) = List.toArray
    let v62 : (char []) = v61 v53
    let v65 : string = v17.TrimEnd v62 
    v65
and method21 () : (std_string_String -> string) =
    closure11()
and method23 () : string =
    let v0 : string = "wasm"
    v0
and method25 (v0 : string) : string =
    let v1 : string = method15()
    let v3 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    method16(v3, v5)
    let v20 : string = "wasm_path"
    method16(v3, v20)
    let v35 : string = " = "
    method16(v3, v35)
    method16(v3, v0)
    let v64 : string = " }"
    method16(v3, v64)
    let v78 : string = v3.l0
    v78
and method24 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method25(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v31 : (int64 -> string) = _.ToString()
    let v32 : string = v31 v10
    let v36 : string = v24 + v32 
    let v40 : string = v36 + v13 
    let v45 : string = "spiral_wasm.run"
    let v46 : string = v40 + v45 
    let v51 : string = " / "
    let v52 : string = v46 + v51 
    let v56 : string = v52 + v9 
    method19(v56)
and closure12 (v0 : string) () : unit =
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
    let v336 : US8 =
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
            let v184 : (unit -> unit) = closure8(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure9()
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
            let v308 : int32 = v264 |> int32 
            let v318 : string = ""
            let v319 : bool = v124 <> v318 
            let v323 : bool =
                if v319 then
                    let v322 : bool = v308 <= 1
                    v322
                else
                    false
            if v323 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v318
                let v324 : string = "true; $0.into_iter().for_each(|x| { //"
                let v325 : bool = Fable.Core.RustInterop.emitRustExpr v262 v324 
                let v326 : string = "x"
                let v327 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v326 
                let v328 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v329 : bool = Fable.Core.RustInterop.emitRustExpr v327 v328 
                let v330 : string = $"true"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr () v330 
                let v332 : string = "true; }); //"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
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
            let v334 : (string -> unit) = v164.l0
            v334 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method29 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) : string =
    let v3 : string = method15()
    let v5 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    method16(v5, v7)
    let v22 : string = "retry"
    method16(v5, v22)
    let v37 : string = " = "
    method16(v5, v37)
    let v55 : string = $"{v0}"
    method16(v5, v55)
    let v72 : string = "; "
    method16(v5, v72)
    let v87 : string = "worker"
    method16(v5, v87)
    method16(v5, v37)
    (* run_target_args'
    let v119 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v120 : string = "format!(\"{:#?}\", $0)"
    let v121 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v120 
    let v122 : string = "fable_library_rust::String_::fromString($0)"
    let v123 : string = Fable.Core.RustInterop.emitRustExpr v121 v122 
    let _run_target_args'_v119 = v123 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v124 : string = "format!(\"{:#?}\", $0)"
    let v125 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v124 
    let v126 : string = "fable_library_rust::String_::fromString($0)"
    let v127 : string = Fable.Core.RustInterop.emitRustExpr v125 v126 
    let _run_target_args'_v119 = v127 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v128 : string = "format!(\"{:#?}\", $0)"
    let v129 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v128 
    let v130 : string = "fable_library_rust::String_::fromString($0)"
    let v131 : string = Fable.Core.RustInterop.emitRustExpr v129 v130 
    let _run_target_args'_v119 = v131 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v133 : string = $"%A{v1}"
    let _run_target_args'_v119 = v133 
    #endif
#if FABLE_COMPILER_PYTHON
    let v137 : string = $"%A{v1}"
    let _run_target_args'_v119 = v137 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v141 : string = $"%A{v1}"
    let _run_target_args'_v119 = v141 
    #endif
#else
    let v145 : string = $"%A{v1}"
    let _run_target_args'_v119 = v145 
    #endif
    let v148 : string = _run_target_args'_v119 
    method16(v5, v148)
    method16(v5, v72)
    let v186 : string = "contract"
    method16(v5, v186)
    method16(v5, v37)
    (* run_target_args'
    let v218 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v219 : string = "format!(\"{:#?}\", $0)"
    let v220 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v219 
    let v221 : string = "fable_library_rust::String_::fromString($0)"
    let v222 : string = Fable.Core.RustInterop.emitRustExpr v220 v221 
    let _run_target_args'_v218 = v222 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v223 : string = "format!(\"{:#?}\", $0)"
    let v224 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v223 
    let v225 : string = "fable_library_rust::String_::fromString($0)"
    let v226 : string = Fable.Core.RustInterop.emitRustExpr v224 v225 
    let _run_target_args'_v218 = v226 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v227 : string = "format!(\"{:#?}\", $0)"
    let v228 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v227 
    let v229 : string = "fable_library_rust::String_::fromString($0)"
    let v230 : string = Fable.Core.RustInterop.emitRustExpr v228 v229 
    let _run_target_args'_v218 = v230 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v232 : string = $"%A{v2}"
    let _run_target_args'_v218 = v232 
    #endif
#if FABLE_COMPILER_PYTHON
    let v236 : string = $"%A{v2}"
    let _run_target_args'_v218 = v236 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v240 : string = $"%A{v2}"
    let _run_target_args'_v218 = v240 
    #endif
#else
    let v244 : string = $"%A{v2}"
    let _run_target_args'_v218 = v244 
    #endif
    let v247 : string = _run_target_args'_v218 
    method16(v5, v247)
    let v271 : string = " }"
    method16(v5, v271)
    let v285 : string = v5.l0
    v285
and method28 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v10 : near_workspaces_Contract) : string =
    let v11 : string = method29(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v20 : string = v16 + v7 
    let v25 : string = " #"
    let v26 : string = v20 + v25 
    let v33 : (int64 -> string) = _.ToString()
    let v34 : string = v33 v12
    let v38 : string = v26 + v34 
    let v42 : string = v38 + v15 
    let v47 : string = "spiral_wasm.run"
    let v48 : string = v42 + v47 
    let v53 : string = " / "
    let v54 : string = v48 + v53 
    let v58 : string = v54 + v11 
    method19(v58)
and closure13 (v0 : uint8, v1 : near_workspaces_Worker<near_workspaces_network_Sandbox>, v2 : near_workspaces_Contract) () : unit =
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
    let v338 : US8 =
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
            let v186 : (unit -> unit) = closure8(v165)
            let v187 : unit = (fun () -> v186 (); v185) ()
            let v190 : (string -> unit) = closure9()
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
            let v310 : int32 = v266 |> int32 
            let v320 : string = ""
            let v321 : bool = v126 <> v320 
            let v325 : bool =
                if v321 then
                    let v324 : bool = v310 <= 1
                    v324
                else
                    false
            if v325 then
                v168.l0 <- v210
                ()
            else
                v168.l0 <- v320
                let v326 : string = "true; $0.into_iter().for_each(|x| { //"
                let v327 : bool = Fable.Core.RustInterop.emitRustExpr v264 v326 
                let v328 : string = "x"
                let v329 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v328 
                let v330 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr v329 v330 
                let v332 : string = $"true"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
                let v334 : string = "true; }); //"
                let v335 : bool = Fable.Core.RustInterop.emitRustExpr () v334 
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
            let v336 : (string -> unit) = v166.l0
            v336 v126
            US8_0(v165, v166, v167, v168, v169, v170)
    
    ()
and method31 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) : string =
    let v2 : string = method15()
    let v4 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    method16(v4, v6)
    let v21 : string = "retry"
    method16(v4, v21)
    let v36 : string = " = "
    method16(v4, v36)
    let v54 : string = $"{v0}"
    method16(v4, v54)
    let v71 : string = "; "
    method16(v4, v71)
    let v86 : string = "result"
    method16(v4, v86)
    method16(v4, v36)
    (* run_target_args'
    let v118 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v119 : string = "format!(\"{:#?}\", $0)"
    let v120 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v119 
    let v121 : string = "fable_library_rust::String_::fromString($0)"
    let v122 : string = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let _run_target_args'_v118 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "format!(\"{:#?}\", $0)"
    let v124 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v123 
    let v125 : string = "fable_library_rust::String_::fromString($0)"
    let v126 : string = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let _run_target_args'_v118 = v126 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v127 : string = "format!(\"{:#?}\", $0)"
    let v128 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v127 
    let v129 : string = "fable_library_rust::String_::fromString($0)"
    let v130 : string = Fable.Core.RustInterop.emitRustExpr v128 v129 
    let _run_target_args'_v118 = v130 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v132 : string = $"%A{v1}"
    let _run_target_args'_v118 = v132 
    #endif
#if FABLE_COMPILER_PYTHON
    let v136 : string = $"%A{v1}"
    let _run_target_args'_v118 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v140 : string = $"%A{v1}"
    let _run_target_args'_v118 = v140 
    #endif
#else
    let v144 : string = $"%A{v1}"
    let _run_target_args'_v118 = v144 
    #endif
    let v147 : string = _run_target_args'_v118 
    method16(v4, v147)
    let v171 : string = " }"
    method16(v4, v171)
    let v185 : string = v4.l0
    v185
and method30 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : near_workspaces_result_ExecutionFinalResult) : string =
    let v10 : string = method31(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v32 : (int64 -> string) = _.ToString()
    let v33 : string = v32 v11
    let v37 : string = v25 + v33 
    let v41 : string = v37 + v14 
    let v46 : string = "spiral_wasm.run"
    let v47 : string = v41 + v46 
    let v52 : string = " / "
    let v53 : string = v47 + v52 
    let v57 : string = v53 + v10 
    method19(v57)
and closure14 (v0 : uint8, v1 : near_workspaces_result_ExecutionFinalResult) () : unit =
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
    let v337 : US8 =
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
            let v185 : (unit -> unit) = closure8(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure9()
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
            let v309 : int32 = v265 |> int32 
            let v319 : string = ""
            let v320 : bool = v125 <> v319 
            let v324 : bool =
                if v320 then
                    let v323 : bool = v309 <= 1
                    v323
                else
                    false
            if v324 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v319
                let v325 : string = "true; $0.into_iter().for_each(|x| { //"
                let v326 : bool = Fable.Core.RustInterop.emitRustExpr v263 v325 
                let v327 : string = "x"
                let v328 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v327 
                let v329 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v330 : bool = Fable.Core.RustInterop.emitRustExpr v328 v329 
                let v331 : string = $"true"
                let v332 : bool = Fable.Core.RustInterop.emitRustExpr () v331 
                let v333 : string = "true; }); //"
                let v334 : bool = Fable.Core.RustInterop.emitRustExpr () v333 
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
            let v335 : (string -> unit) = v165.l0
            v335 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and closure16 (v0 : std_string_String) () : unit =
    let v1 : (std_string_String -> unit) = System.Console.WriteLine
    v1 v0
and closure15 () (v0 : std_string_String) : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure16(v0)
    let v4 : unit = (fun () -> v3 (); v2) ()
    ()
and closure17 () () : unit =
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
    let v277 : US8 =
        if v63 then
            US8_1
        else
            let v79 : unit = ()
            let v80 : unit = (fun () -> v15 (); v79) ()
            let struct (v103 : Mut0, v104 : Mut1, v105 : Mut2, v106 : Mut3, v107 : Mut4, v108 : int64 option) = TraceState.trace_state.Value
            let v123 : unit = ()
            let v124 : (unit -> unit) = closure8(v103)
            let v125 : unit = (fun () -> v124 (); v123) ()
            let v128 : string = " "
            let v129 : (string -> unit) = closure9()
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
            let v249 : int32 = v205 |> int32 
            let v259 : string = ""
            let v260 : bool = v128 <> v259 
            let v264 : bool =
                if v260 then
                    let v263 : bool = v249 <= 1
                    v263
                else
                    false
            if v264 then
                v106.l0 <- v149
                ()
            else
                v106.l0 <- v259
                let v265 : string = "true; $0.into_iter().for_each(|x| { //"
                let v266 : bool = Fable.Core.RustInterop.emitRustExpr v203 v265 
                let v267 : string = "x"
                let v268 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v267 
                let v269 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v270 : bool = Fable.Core.RustInterop.emitRustExpr v268 v269 
                let v271 : string = $"true"
                let v272 : bool = Fable.Core.RustInterop.emitRustExpr () v271 
                let v273 : string = "true; }); //"
                let v274 : bool = Fable.Core.RustInterop.emitRustExpr () v273 
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
            let v275 : (string -> unit) = v104.l0
            v275 v128
            US8_0(v103, v104, v105, v106, v107, v108)
    
    ()
and method32 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_bright_green"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "String::from($0)"
    let v10 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v16 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v24 
    #endif
#else
    let v28 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v28 
    #endif
    let v31 : std_string_String = _run_target_args'_v8 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v31 v40 
    let _run_target_args'_v1 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "inline_colorization::color_bright_green"
    let v43 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v42 
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v49 
    let _run_target_args'_v48 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v51 
    let _run_target_args'_v48 = v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = "String::from($0)"
    let v54 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v53 
    let _run_target_args'_v48 = v54 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v56 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v56 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v64 
    #endif
#else
    let v68 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v68 
    #endif
    let v71 : std_string_String = _run_target_args'_v48 
    let v80 : string = "fable_library_rust::String_::fromString($0)"
    let v81 : string = Fable.Core.RustInterop.emitRustExpr v71 v80 
    let _run_target_args'_v1 = v81 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string = "inline_colorization::color_bright_green"
    let v83 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v82 
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "String::from($0)"
    let v90 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "String::from($0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "String::from($0)"
    let v94 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : std_string_String = _run_target_args'_v88 
    let v120 : string = "fable_library_rust::String_::fromString($0)"
    let v121 : string = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let _run_target_args'_v1 = v121 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v122 : string = "\u001b[92m"
    let _run_target_args'_v1 = v122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : string = "\u001b[92m"
    let _run_target_args'_v1 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v124 : string = "\u001b[92m"
    let _run_target_args'_v1 = v124 
    #endif
#else
    let v125 : string = "\u001b[92m"
    let _run_target_args'_v1 = v125 
    #endif
    let v126 : string = _run_target_args'_v1 
    
    
    
    
    
    let v131 : string = "Info"
    let v132 : (unit -> string) = v131.ToLower
    let v133 : string = v132 ()
    let v136 : char = v133.[int 0]
    let v137 : string = method14(v136)
    let v139 : string = v126 + v137 
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "inline_colorization::color_reset"
    let v145 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v144 
    (* run_target_args'
    let v150 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v151 : string = "String::from($0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v151 
    let _run_target_args'_v150 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "String::from($0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v153 
    let _run_target_args'_v150 = v154 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v155 : string = "String::from($0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v155 
    let _run_target_args'_v150 = v156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v158 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v158 
    #endif
#if FABLE_COMPILER_PYTHON
    let v162 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v162 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v166 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v166 
    #endif
#else
    let v170 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v170 
    #endif
    let v173 : std_string_String = _run_target_args'_v150 
    let v182 : string = "fable_library_rust::String_::fromString($0)"
    let v183 : string = Fable.Core.RustInterop.emitRustExpr v173 v182 
    let _run_target_args'_v143 = v183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v184 : string = "inline_colorization::color_reset"
    let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v184 
    (* run_target_args'
    let v190 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v191 : string = "String::from($0)"
    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v191 
    let _run_target_args'_v190 = v192 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v193 : string = "String::from($0)"
    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v193 
    let _run_target_args'_v190 = v194 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v195 : string = "String::from($0)"
    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v195 
    let _run_target_args'_v190 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v198 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v202 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v206 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v206 
    #endif
#else
    let v210 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v210 
    #endif
    let v213 : std_string_String = _run_target_args'_v190 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v213 v222 
    let _run_target_args'_v143 = v223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v224 : string = "inline_colorization::color_reset"
    let v225 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v224 
    (* run_target_args'
    let v230 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v231 : string = "String::from($0)"
    let v232 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v231 
    let _run_target_args'_v230 = v232 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v233 : string = "String::from($0)"
    let v234 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v233 
    let _run_target_args'_v230 = v234 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v235 : string = "String::from($0)"
    let v236 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v235 
    let _run_target_args'_v230 = v236 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v238 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v238 
    #endif
#if FABLE_COMPILER_PYTHON
    let v242 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v246 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v246 
    #endif
#else
    let v250 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v250 
    #endif
    let v253 : std_string_String = _run_target_args'_v230 
    let v262 : string = "fable_library_rust::String_::fromString($0)"
    let v263 : string = Fable.Core.RustInterop.emitRustExpr v253 v262 
    let _run_target_args'_v143 = v263 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v264 : string = "\u001b[0m"
    let _run_target_args'_v143 = v264 
    #endif
#if FABLE_COMPILER_PYTHON
    let v265 : string = "\u001b[0m"
    let _run_target_args'_v143 = v265 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v266 : string = "\u001b[0m"
    let _run_target_args'_v143 = v266 
    #endif
#else
    let v267 : string = "\u001b[0m"
    let _run_target_args'_v143 = v267 
    #endif
    let v268 : string = _run_target_args'_v143 
    let v272 : string = v139 + v268 
    v272
and method34 (v0 : uint8, v1 : float, v2 : uint64) : string =
    let v3 : string = method15()
    let v5 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    method16(v5, v7)
    let v22 : string = "retry"
    method16(v5, v22)
    let v37 : string = " = "
    method16(v5, v37)
    let v55 : string = $"{v0}"
    method16(v5, v55)
    let v72 : string = "; "
    method16(v5, v72)
    let v87 : string = "total_gas_burnt_usd"
    method16(v5, v87)
    method16(v5, v37)
    let v119 : string = $"%+.6f{v1}"
    method16(v5, v119)
    method16(v5, v72)
    let v150 : string = "total_gas_burnt"
    method16(v5, v150)
    method16(v5, v37)
    let v182 : string = $"{v2}"
    method16(v5, v182)
    let v199 : string = " }"
    method16(v5, v199)
    let v213 : string = v5.l0
    v213
and method33 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : float, v10 : uint64) : string =
    let v11 : string = method34(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v20 : string = v16 + v7 
    let v25 : string = " #"
    let v26 : string = v20 + v25 
    let v33 : (int64 -> string) = _.ToString()
    let v34 : string = v33 v12
    let v38 : string = v26 + v34 
    let v42 : string = v38 + v15 
    let v47 : string = "near_workspaces.print_usd"
    let v48 : string = v42 + v47 
    let v53 : string = " / "
    let v54 : string = v48 + v53 
    let v58 : string = v54 + v11 
    method19(v58)
and closure18 (v0 : uint8, v1 : uint64, v2 : float) () : unit =
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
    let v338 : US8 =
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
            let v186 : (unit -> unit) = closure8(v165)
            let v187 : unit = (fun () -> v186 (); v185) ()
            let v190 : (string -> unit) = closure9()
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
            let v310 : int32 = v266 |> int32 
            let v320 : string = ""
            let v321 : bool = v126 <> v320 
            let v325 : bool =
                if v321 then
                    let v324 : bool = v310 <= 1
                    v324
                else
                    false
            if v325 then
                v168.l0 <- v210
                ()
            else
                v168.l0 <- v320
                let v326 : string = "true; $0.into_iter().for_each(|x| { //"
                let v327 : bool = Fable.Core.RustInterop.emitRustExpr v264 v326 
                let v328 : string = "x"
                let v329 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v328 
                let v330 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr v329 v330 
                let v332 : string = $"true"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
                let v334 : string = "true; }); //"
                let v335 : bool = Fable.Core.RustInterop.emitRustExpr () v334 
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
            let v336 : (string -> unit) = v166.l0
            v336 v126
            US8_0(v165, v166, v167, v168, v169, v170)
    
    ()
and method36 (v0 : bool, v1 : float, v2 : float, v3 : uint64, v4 : u128) : string =
    let v5 : string = method15()
    let v7 : Mut3 = {l0 = v5} : Mut3
    let v9 : string = "{ "
    method16(v7, v9)
    let v24 : string = "is_success"
    method16(v7, v24)
    let v39 : string = " = "
    method16(v7, v39)
    let v55 : string =
        if v0 then
            let v53 : string = "true"
            v53
        else
            let v54 : string = "false"
            v54
    method16(v7, v55)
    let v71 : string = "; "
    method16(v7, v71)
    let v86 : string = "gas_burnt_usd"
    method16(v7, v86)
    method16(v7, v39)
    let v118 : string = $"%+.6f{v1}"
    method16(v7, v118)
    method16(v7, v71)
    let v149 : string = "tokens_burnt_usd"
    method16(v7, v149)
    method16(v7, v39)
    let v181 : string = $"%+.6f{v2}"
    method16(v7, v181)
    method16(v7, v71)
    let v212 : string = "gas_burnt"
    method16(v7, v212)
    method16(v7, v39)
    let v244 : string = $"{v3}"
    method16(v7, v244)
    method16(v7, v71)
    let v275 : string = "tokens_burnt"
    method16(v7, v275)
    method16(v7, v39)
    (* run_target_args'
    let v307 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v308 : string = "format!(\"{:#?}\", $0)"
    let v309 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v308 
    let v310 : string = "fable_library_rust::String_::fromString($0)"
    let v311 : string = Fable.Core.RustInterop.emitRustExpr v309 v310 
    let _run_target_args'_v307 = v311 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v312 : string = "format!(\"{:#?}\", $0)"
    let v313 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v312 
    let v314 : string = "fable_library_rust::String_::fromString($0)"
    let v315 : string = Fable.Core.RustInterop.emitRustExpr v313 v314 
    let _run_target_args'_v307 = v315 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v316 : string = "format!(\"{:#?}\", $0)"
    let v317 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v316 
    let v318 : string = "fable_library_rust::String_::fromString($0)"
    let v319 : string = Fable.Core.RustInterop.emitRustExpr v317 v318 
    let _run_target_args'_v307 = v319 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v321 : string = $"%A{v4}"
    let _run_target_args'_v307 = v321 
    #endif
#if FABLE_COMPILER_PYTHON
    let v325 : string = $"%A{v4}"
    let _run_target_args'_v307 = v325 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v329 : string = $"%A{v4}"
    let _run_target_args'_v307 = v329 
    #endif
#else
    let v333 : string = $"%A{v4}"
    let _run_target_args'_v307 = v333 
    #endif
    let v336 : string = _run_target_args'_v307 
    method16(v7, v336)
    let v360 : string = " }"
    method16(v7, v360)
    let v374 : string = v7.l0
    v374
and method35 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : bool, v9 : float, v10 : float, v11 : uint64, v12 : u128) : string =
    let v13 : string = method36(v8, v9, v10, v11, v12)
    let v14 : int64 = v0.l0
    let v17 : string = " "
    let v18 : string = v6 + v17 
    let v22 : string = v18 + v7 
    let v27 : string = " #"
    let v28 : string = v22 + v27 
    let v35 : (int64 -> string) = _.ToString()
    let v36 : string = v35 v14
    let v40 : string = v28 + v36 
    let v44 : string = v40 + v17 
    let v49 : string = "near_workspaces.print_usd / outcome"
    let v50 : string = v44 + v49 
    let v55 : string = " / "
    let v56 : string = v50 + v55 
    let v60 : string = v56 + v13 
    method19(v60)
and closure20 (v0 : bool, v1 : uint64, v2 : float, v3 : u128, v4 : float) () : unit =
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
    let v340 : US8 =
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
            let v188 : (unit -> unit) = closure8(v167)
            let v189 : unit = (fun () -> v188 (); v187) ()
            let v192 : (string -> unit) = closure9()
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
            let v312 : int32 = v268 |> int32 
            let v322 : string = ""
            let v323 : bool = v128 <> v322 
            let v327 : bool =
                if v323 then
                    let v326 : bool = v312 <= 1
                    v326
                else
                    false
            if v327 then
                v170.l0 <- v212
                ()
            else
                v170.l0 <- v322
                let v328 : string = "true; $0.into_iter().for_each(|x| { //"
                let v329 : bool = Fable.Core.RustInterop.emitRustExpr v266 v328 
                let v330 : string = "x"
                let v331 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v330 
                let v332 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr v331 v332 
                let v334 : string = $"true"
                let v335 : bool = Fable.Core.RustInterop.emitRustExpr () v334 
                let v336 : string = "true; }); //"
                let v337 : bool = Fable.Core.RustInterop.emitRustExpr () v336 
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
            let v338 : (string -> unit) = v168.l0
            v338 v128
            US8_0(v167, v168, v169, v170, v171, v172)
    
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
    let v371 : unit = ()
    let v372 : (unit -> unit) = closure20(v2, v6, v13, v17, v21)
    let v373 : unit = (fun () -> v372 (); v371) ()
    ()
and method38 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v1 : string = method15()
    let v3 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    method16(v3, v5)
    let v20 : string = "result2"
    method16(v3, v20)
    let v35 : string = " = "
    method16(v3, v35)
    (* run_target_args'
    let v53 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v54 : string = "format!(\"{:#?}\", $0)"
    let v55 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v54 
    let v56 : string = "fable_library_rust::String_::fromString($0)"
    let v57 : string = Fable.Core.RustInterop.emitRustExpr v55 v56 
    let _run_target_args'_v53 = v57 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v58 : string = "format!(\"{:#?}\", $0)"
    let v59 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v58 
    let v60 : string = "fable_library_rust::String_::fromString($0)"
    let v61 : string = Fable.Core.RustInterop.emitRustExpr v59 v60 
    let _run_target_args'_v53 = v61 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v62 : string = "format!(\"{:#?}\", $0)"
    let v63 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v62 
    let v64 : string = "fable_library_rust::String_::fromString($0)"
    let v65 : string = Fable.Core.RustInterop.emitRustExpr v63 v64 
    let _run_target_args'_v53 = v65 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v67 : string = $"%A{v0}"
    let _run_target_args'_v53 = v67 
    #endif
#if FABLE_COMPILER_PYTHON
    let v71 : string = $"%A{v0}"
    let _run_target_args'_v53 = v71 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v75 : string = $"%A{v0}"
    let _run_target_args'_v53 = v75 
    #endif
#else
    let v79 : string = $"%A{v0}"
    let _run_target_args'_v53 = v79 
    #endif
    let v82 : string = _run_target_args'_v53 
    method16(v3, v82)
    let v106 : string = " }"
    method16(v3, v106)
    let v120 : string = v3.l0
    v120
and method37 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) : string =
    let v9 : string = method38(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v31 : (int64 -> string) = _.ToString()
    let v32 : string = v31 v10
    let v36 : string = v24 + v32 
    let v40 : string = v36 + v13 
    let v45 : string = "spiral_wasm.run"
    let v46 : string = v40 + v45 
    let v51 : string = " / "
    let v52 : string = v46 + v51 
    let v56 : string = v52 + v9 
    method19(v56)
and closure21 (v0 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure>) () : unit =
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
    let v336 : US8 =
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
            let v184 : (unit -> unit) = closure8(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure9()
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
            let v308 : int32 = v264 |> int32 
            let v318 : string = ""
            let v319 : bool = v124 <> v318 
            let v323 : bool =
                if v319 then
                    let v322 : bool = v308 <= 1
                    v322
                else
                    false
            if v323 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v318
                let v324 : string = "true; $0.into_iter().for_each(|x| { //"
                let v325 : bool = Fable.Core.RustInterop.emitRustExpr v262 v324 
                let v326 : string = "x"
                let v327 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v326 
                let v328 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v329 : bool = Fable.Core.RustInterop.emitRustExpr v327 v328 
                let v330 : string = $"true"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr () v330 
                let v332 : string = "true; }); //"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
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
            let v334 : (string -> unit) = v164.l0
            v334 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method39 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method41 (v0 : int32, v1 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v2 : string = method15()
    let v4 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    method16(v4, v6)
    let v21 : string = "receipt_failures_len"
    method16(v4, v21)
    let v36 : string = " = "
    method16(v4, v36)
    let v54 : string = $"{v0}"
    method16(v4, v54)
    let v71 : string = "; "
    method16(v4, v71)
    let v86 : string = "receipt_failures"
    method16(v4, v86)
    method16(v4, v36)
    (* run_target_args'
    let v118 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v119 : string = "format!(\"{:#?}\", $0)"
    let v120 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v119 
    let v121 : string = "fable_library_rust::String_::fromString($0)"
    let v122 : string = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let _run_target_args'_v118 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "format!(\"{:#?}\", $0)"
    let v124 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v123 
    let v125 : string = "fable_library_rust::String_::fromString($0)"
    let v126 : string = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let _run_target_args'_v118 = v126 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v127 : string = "format!(\"{:#?}\", $0)"
    let v128 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v127 
    let v129 : string = "fable_library_rust::String_::fromString($0)"
    let v130 : string = Fable.Core.RustInterop.emitRustExpr v128 v129 
    let _run_target_args'_v118 = v130 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v132 : string = $"%A{v1}"
    let _run_target_args'_v118 = v132 
    #endif
#if FABLE_COMPILER_PYTHON
    let v136 : string = $"%A{v1}"
    let _run_target_args'_v118 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v140 : string = $"%A{v1}"
    let _run_target_args'_v118 = v140 
    #endif
#else
    let v144 : string = $"%A{v1}"
    let _run_target_args'_v118 = v144 
    #endif
    let v147 : string = _run_target_args'_v118 
    method16(v4, v147)
    let v171 : string = " }"
    method16(v4, v171)
    let v185 : string = v4.l0
    v185
and method40 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v10 : string = method41(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v32 : (int64 -> string) = _.ToString()
    let v33 : string = v32 v11
    let v37 : string = v25 + v33 
    let v41 : string = v37 + v14 
    let v46 : string = "spiral_wasm.run"
    let v47 : string = v41 + v46 
    let v52 : string = " / "
    let v53 : string = v47 + v52 
    let v57 : string = v53 + v10 
    method19(v57)
and closure22 (v0 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>, v1 : int32) () : unit =
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
    let v337 : US8 =
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
            let v185 : (unit -> unit) = closure8(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure9()
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
            let v309 : int32 = v265 |> int32 
            let v319 : string = ""
            let v320 : bool = v125 <> v319 
            let v324 : bool =
                if v320 then
                    let v323 : bool = v309 <= 1
                    v323
                else
                    false
            if v324 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v319
                let v325 : string = "true; $0.into_iter().for_each(|x| { //"
                let v326 : bool = Fable.Core.RustInterop.emitRustExpr v263 v325 
                let v327 : string = "x"
                let v328 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v327 
                let v329 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v330 : bool = Fable.Core.RustInterop.emitRustExpr v328 v329 
                let v331 : string = $"true"
                let v332 : bool = Fable.Core.RustInterop.emitRustExpr () v331 
                let v333 : string = "true; }); //"
                let v334 : bool = Fable.Core.RustInterop.emitRustExpr () v333 
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
            let v335 : (string -> unit) = v165.l0
            v335 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and method42 (v0 : near_workspaces_result_ExecutionFinalResult) : near_workspaces_result_ExecutionFinalResult =
    v0
and method44 (v0 : int32, v1 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v2 : string = method15()
    let v4 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    method16(v4, v6)
    let v21 : string = "receipt_outcomes_len"
    method16(v4, v21)
    let v36 : string = " = "
    method16(v4, v36)
    let v54 : string = $"{v0}"
    method16(v4, v54)
    let v71 : string = "; "
    method16(v4, v71)
    let v86 : string = "receipt_outcomes"
    method16(v4, v86)
    method16(v4, v36)
    (* run_target_args'
    let v118 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v119 : string = "format!(\"{:#?}\", $0)"
    let v120 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v119 
    let v121 : string = "fable_library_rust::String_::fromString($0)"
    let v122 : string = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let _run_target_args'_v118 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "format!(\"{:#?}\", $0)"
    let v124 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v123 
    let v125 : string = "fable_library_rust::String_::fromString($0)"
    let v126 : string = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let _run_target_args'_v118 = v126 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v127 : string = "format!(\"{:#?}\", $0)"
    let v128 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v127 
    let v129 : string = "fable_library_rust::String_::fromString($0)"
    let v130 : string = Fable.Core.RustInterop.emitRustExpr v128 v129 
    let _run_target_args'_v118 = v130 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v132 : string = $"%A{v1}"
    let _run_target_args'_v118 = v132 
    #endif
#if FABLE_COMPILER_PYTHON
    let v136 : string = $"%A{v1}"
    let _run_target_args'_v118 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v140 : string = $"%A{v1}"
    let _run_target_args'_v118 = v140 
    #endif
#else
    let v144 : string = $"%A{v1}"
    let _run_target_args'_v118 = v144 
    #endif
    let v147 : string = _run_target_args'_v118 
    method16(v4, v147)
    let v171 : string = " }"
    method16(v4, v171)
    let v185 : string = v4.l0
    v185
and method43 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : Vec<near_workspaces_result_ExecutionOutcome>) : string =
    let v10 : string = method44(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v32 : (int64 -> string) = _.ToString()
    let v33 : string = v32 v11
    let v37 : string = v25 + v33 
    let v41 : string = v37 + v14 
    let v46 : string = "spiral_wasm.run"
    let v47 : string = v41 + v46 
    let v52 : string = " / "
    let v53 : string = v47 + v52 
    let v57 : string = v53 + v10 
    method19(v57)
and closure23 (v0 : Vec<near_workspaces_result_ExecutionOutcome>, v1 : int32) () : unit =
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
    let v337 : US8 =
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
            let v185 : (unit -> unit) = closure8(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure9()
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
            let v309 : int32 = v265 |> int32 
            let v319 : string = ""
            let v320 : bool = v125 <> v319 
            let v324 : bool =
                if v320 then
                    let v323 : bool = v309 <= 1
                    v323
                else
                    false
            if v324 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v319
                let v325 : string = "true; $0.into_iter().for_each(|x| { //"
                let v326 : bool = Fable.Core.RustInterop.emitRustExpr v263 v325 
                let v327 : string = "x"
                let v328 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v327 
                let v329 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v330 : bool = Fable.Core.RustInterop.emitRustExpr v328 v329 
                let v331 : string = $"true"
                let v332 : bool = Fable.Core.RustInterop.emitRustExpr () v331 
                let v333 : string = "true; }); //"
                let v334 : bool = Fable.Core.RustInterop.emitRustExpr () v333 
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
            let v335 : (string -> unit) = v165.l0
            v335 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and method46 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method15()
    let v3 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    method16(v3, v5)
    let v20 : string = "json"
    method16(v3, v20)
    let v35 : string = " = "
    method16(v3, v35)
    (* run_target_args'
    let v53 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v54 : string = "format!(\"{:#?}\", $0)"
    let v55 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v54 
    let v56 : string = "fable_library_rust::String_::fromString($0)"
    let v57 : string = Fable.Core.RustInterop.emitRustExpr v55 v56 
    let _run_target_args'_v53 = v57 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v58 : string = "format!(\"{:#?}\", $0)"
    let v59 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v58 
    let v60 : string = "fable_library_rust::String_::fromString($0)"
    let v61 : string = Fable.Core.RustInterop.emitRustExpr v59 v60 
    let _run_target_args'_v53 = v61 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v62 : string = "format!(\"{:#?}\", $0)"
    let v63 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v62 
    let v64 : string = "fable_library_rust::String_::fromString($0)"
    let v65 : string = Fable.Core.RustInterop.emitRustExpr v63 v64 
    let _run_target_args'_v53 = v65 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v67 : string = $"%A{v0}"
    let _run_target_args'_v53 = v67 
    #endif
#if FABLE_COMPILER_PYTHON
    let v71 : string = $"%A{v0}"
    let _run_target_args'_v53 = v71 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v75 : string = $"%A{v0}"
    let _run_target_args'_v53 = v75 
    #endif
#else
    let v79 : string = $"%A{v0}"
    let _run_target_args'_v53 = v79 
    #endif
    let v82 : string = _run_target_args'_v53 
    method16(v3, v82)
    let v106 : string = " }"
    method16(v3, v106)
    let v120 : string = v3.l0
    v120
and method45 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method46(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v31 : (int64 -> string) = _.ToString()
    let v32 : string = v31 v10
    let v36 : string = v24 + v32 
    let v40 : string = v36 + v13 
    let v45 : string = "spiral_wasm.run"
    let v46 : string = v40 + v45 
    let v51 : string = " / "
    let v52 : string = v46 + v51 
    let v56 : string = v52 + v9 
    method19(v56)
and closure24 (v0 : Result<std_string_String, near_workspaces_error_Error>) () : unit =
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
    let v336 : US8 =
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
            let v184 : (unit -> unit) = closure8(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure9()
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
            let v308 : int32 = v264 |> int32 
            let v318 : string = ""
            let v319 : bool = v124 <> v318 
            let v323 : bool =
                if v319 then
                    let v322 : bool = v308 <= 1
                    v322
                else
                    false
            if v323 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v318
                let v324 : string = "true; $0.into_iter().for_each(|x| { //"
                let v325 : bool = Fable.Core.RustInterop.emitRustExpr v262 v324 
                let v326 : string = "x"
                let v327 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v326 
                let v328 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v329 : bool = Fable.Core.RustInterop.emitRustExpr v327 v328 
                let v330 : string = $"true"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr () v330 
                let v332 : string = "true; }); //"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
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
            let v334 : (string -> unit) = v164.l0
            v334 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method48 (v0 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v1 : string = method15()
    let v3 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    method16(v3, v5)
    let v20 : string = "borsh"
    method16(v3, v20)
    let v35 : string = " = "
    method16(v3, v35)
    (* run_target_args'
    let v53 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v54 : string = "format!(\"{:#?}\", $0)"
    let v55 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v54 
    let v56 : string = "fable_library_rust::String_::fromString($0)"
    let v57 : string = Fable.Core.RustInterop.emitRustExpr v55 v56 
    let _run_target_args'_v53 = v57 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v58 : string = "format!(\"{:#?}\", $0)"
    let v59 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v58 
    let v60 : string = "fable_library_rust::String_::fromString($0)"
    let v61 : string = Fable.Core.RustInterop.emitRustExpr v59 v60 
    let _run_target_args'_v53 = v61 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v62 : string = "format!(\"{:#?}\", $0)"
    let v63 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v62 
    let v64 : string = "fable_library_rust::String_::fromString($0)"
    let v65 : string = Fable.Core.RustInterop.emitRustExpr v63 v64 
    let _run_target_args'_v53 = v65 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v67 : string = $"%A{v0}"
    let _run_target_args'_v53 = v67 
    #endif
#if FABLE_COMPILER_PYTHON
    let v71 : string = $"%A{v0}"
    let _run_target_args'_v53 = v71 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v75 : string = $"%A{v0}"
    let _run_target_args'_v53 = v75 
    #endif
#else
    let v79 : string = $"%A{v0}"
    let _run_target_args'_v53 = v79 
    #endif
    let v82 : string = _run_target_args'_v53 
    method16(v3, v82)
    let v106 : string = " }"
    method16(v3, v106)
    let v120 : string = v3.l0
    v120
and method47 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : Result<std_string_String, near_workspaces_error_Error>) : string =
    let v9 : string = method48(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v31 : (int64 -> string) = _.ToString()
    let v32 : string = v31 v10
    let v36 : string = v24 + v32 
    let v40 : string = v36 + v13 
    let v45 : string = "spiral_wasm.run"
    let v46 : string = v40 + v45 
    let v51 : string = " / "
    let v52 : string = v46 + v51 
    let v56 : string = v52 + v9 
    method19(v56)
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
    let v336 : US8 =
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
            let v184 : (unit -> unit) = closure8(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure9()
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
            let v308 : int32 = v264 |> int32 
            let v318 : string = ""
            let v319 : bool = v124 <> v318 
            let v323 : bool =
                if v319 then
                    let v322 : bool = v308 <= 1
                    v322
                else
                    false
            if v323 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v318
                let v324 : string = "true; $0.into_iter().for_each(|x| { //"
                let v325 : bool = Fable.Core.RustInterop.emitRustExpr v262 v324 
                let v326 : string = "x"
                let v327 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v326 
                let v328 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v329 : bool = Fable.Core.RustInterop.emitRustExpr v327 v328 
                let v330 : string = $"true"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr () v330 
                let v332 : string = "true; }); //"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
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
            let v334 : (string -> unit) = v164.l0
            v334 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method49 (v0 : int32, v1 : uint8, v2 : Vec<Ref<near_workspaces_result_ExecutionOutcome>>) : string =
    let v3 : string = method15()
    let v5 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    method16(v5, v7)
    let v22 : string = "receipt_outcomes_len"
    method16(v5, v22)
    let v37 : string = " = "
    method16(v5, v37)
    let v55 : string = $"{v0}"
    method16(v5, v55)
    let v72 : string = "; "
    method16(v5, v72)
    let v87 : string = "retry"
    method16(v5, v87)
    method16(v5, v37)
    let v119 : string = $"{v1}"
    method16(v5, v119)
    method16(v5, v72)
    let v150 : string = "receipt_failures"
    method16(v5, v150)
    method16(v5, v37)
    (* run_target_args'
    let v182 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v183 : string = "format!(\"{:#?}\", $0)"
    let v184 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v183 
    let v185 : string = "fable_library_rust::String_::fromString($0)"
    let v186 : string = Fable.Core.RustInterop.emitRustExpr v184 v185 
    let _run_target_args'_v182 = v186 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v187 : string = "format!(\"{:#?}\", $0)"
    let v188 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v187 
    let v189 : string = "fable_library_rust::String_::fromString($0)"
    let v190 : string = Fable.Core.RustInterop.emitRustExpr v188 v189 
    let _run_target_args'_v182 = v190 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v191 : string = "format!(\"{:#?}\", $0)"
    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v191 
    let v193 : string = "fable_library_rust::String_::fromString($0)"
    let v194 : string = Fable.Core.RustInterop.emitRustExpr v192 v193 
    let _run_target_args'_v182 = v194 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v196 : string = $"%A{v2}"
    let _run_target_args'_v182 = v196 
    #endif
#if FABLE_COMPILER_PYTHON
    let v200 : string = $"%A{v2}"
    let _run_target_args'_v182 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = $"%A{v2}"
    let _run_target_args'_v182 = v204 
    #endif
#else
    let v208 : string = $"%A{v2}"
    let _run_target_args'_v182 = v208 
    #endif
    let v211 : string = _run_target_args'_v182 
    method16(v5, v211)
    let v235 : string = " }"
    method16(v5, v235)
    let v249 : string = v5.l0
    v249
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
    let v369 : unit = ()
    let v370 : (unit -> unit) = closure13(v1, v11, v19)
    let v371 : unit = (fun () -> v370 (); v369) ()
    let v724 : string = "$0.call(&*$1)"
    let v725 : string = "state_main"
    let v726 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr struct (v19, v725) v724 
    let v727 : string = "near_workspaces::types::Gas::from_tgas(300)"
    let v728 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr () v727 
    let v729 : string = "v726.gas(v728)"
    let v730 : near_workspaces_operations_CallTransaction = Fable.Core.RustInterop.emitRustExpr () v729 
    let v731 : string = "Box::pin(v730.transact())"
    let v732 : std_pin_Pin<Box<Dyn<std_future_Future<Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v731 
    let v733 : string = "v732.await"
    let v734 : Result<near_workspaces_result_ExecutionFinalResult, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr () v733 
    let v735 : string = "$0?"
    let v736 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v734 v735 
    let v1086 : unit = ()
    let v1087 : (unit -> unit) = closure14(v1, v736)
    let v1088 : unit = (fun () -> v1087 (); v1086) ()
    let v1441 : string = "v736.logs()"
    let v1442 : Vec<Ref<Str>> = Fable.Core.RustInterop.emitRustExpr () v1441 
    let v1443 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v1444 : bool = Fable.Core.RustInterop.emitRustExpr v1442 v1443 
    let v1445 : string = "x"
    let v1446 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1445 
    (* run_target_args'
    let v1451 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1452 : string = "String::from($0)"
    let v1453 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1446 v1452 
    let _run_target_args'_v1451 = v1453 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1454 : string = "String::from($0)"
    let v1455 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1446 v1454 
    let _run_target_args'_v1451 = v1455 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1456 : string = "String::from($0)"
    let v1457 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1446 v1456 
    let _run_target_args'_v1451 = v1457 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1459 : std_string_String = v1446 |> unbox<std_string_String>
    let _run_target_args'_v1451 = v1459 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1463 : std_string_String = v1446 |> unbox<std_string_String>
    let _run_target_args'_v1451 = v1463 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1467 : std_string_String = v1446 |> unbox<std_string_String>
    let _run_target_args'_v1451 = v1467 
    #endif
#else
    let v1471 : std_string_String = v1446 |> unbox<std_string_String>
    let _run_target_args'_v1451 = v1471 
    #endif
    let v1474 : std_string_String = _run_target_args'_v1451 
    let v1483 : string = "true; $0 }).collect::<Vec<_>>()"
    let v1484 : bool = Fable.Core.RustInterop.emitRustExpr v1474 v1483 
    let v1485 : string = "_vec_map"
    let v1486 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v1485 
    let v1487 : string = "true; $0.iter().for_each(|x| { $1(x.clone()); }); //"
    let v1488 : (std_string_String -> unit) = closure15()
    let v1489 : bool = Fable.Core.RustInterop.emitRustExpr struct (v1486, v1488) v1487 
    let v1782 : unit = ()
    let v1783 : (unit -> unit) = closure17()
    let v1784 : unit = (fun () -> v1783 (); v1782) ()
    let v2079 : string = "$0.total_gas_burnt"
    let v2080 : near_workspaces_types_Gas = Fable.Core.RustInterop.emitRustExpr v736 v2079 
    let v2081 : string = "$0.as_gas()"
    let v2082 : uint64 = Fable.Core.RustInterop.emitRustExpr v2080 v2081 
    let v2084 : (uint64 -> float) = float
    let v2085 : float = v2084 v2082
    let v2088 : float = v2085 / 10000000000000000.0
    let v2089 : float = v2088 * 6.68
    let v2439 : unit = ()
    let v2440 : (unit -> unit) = closure18(v1, v2082, v2089)
    let v2441 : unit = (fun () -> v2440 (); v2439) ()
    let v2794 : string = "$0"
    let v2795 : near_workspaces_result_ExecutionFinalResult = Fable.Core.RustInterop.emitRustExpr v736 v2794 
    let v2796 : string = "v2795.outcomes()"
    let v2797 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v2796 
    let v2798 : string = "v2797.into_iter()"
    let v2799 : _ = Fable.Core.RustInterop.emitRustExpr () v2798 
    let v2800 : string = "v2799.cloned()"
    let v2801 : _ = Fable.Core.RustInterop.emitRustExpr () v2800 
    let v2802 : string = "true; v2801.for_each(|x| $0(x))"
    let v2803 : (near_workspaces_result_ExecutionOutcome -> unit) = closure19()
    let v2804 : bool = Fable.Core.RustInterop.emitRustExpr v2803 v2802 
    let v2805 : string = "$0.into_result()"
    let v2806 : Result<near_workspaces_result_ExecutionSuccess, near_workspaces_result_ExecutionFailure> = Fable.Core.RustInterop.emitRustExpr v736 v2805 
    let v3156 : unit = ()
    let v3157 : (unit -> unit) = closure21(v2806)
    let v3158 : unit = (fun () -> v3157 (); v3156) ()
    let v3511 : near_workspaces_result_ExecutionFinalResult = method39(v736)
    let v3512 : string = "v3511.receipt_failures()"
    let v3513 : Vec<Ref<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v3512 
    let v3514 : string = "$0.len()"
    let v3515 : unativeint = Fable.Core.RustInterop.emitRustExpr v3513 v3514 
    let v3559 : int32 = v3515 |> int32 
    let v3916 : unit = ()
    let v3917 : (unit -> unit) = closure22(v3513, v3559)
    let v3918 : unit = (fun () -> v3917 (); v3916) ()
    let v4271 : near_workspaces_result_ExecutionFinalResult = method42(v736)
    let v4272 : string = "v4271.receipt_outcomes()"
    let v4273 : Ref<Slice<near_workspaces_result_ExecutionOutcome>> = Fable.Core.RustInterop.emitRustExpr () v4272 
    let v4274 : string = "v4273.into()"
    let v4275 : Vec<near_workspaces_result_ExecutionOutcome> = Fable.Core.RustInterop.emitRustExpr () v4274 
    let v4276 : string = "$0.len()"
    let v4277 : unativeint = Fable.Core.RustInterop.emitRustExpr v4275 v4276 
    let v4321 : int32 = v4277 |> int32 
    let v4678 : unit = ()
    let v4679 : (unit -> unit) = closure23(v4275, v4321)
    let v4680 : unit = (fun () -> v4679 (); v4678) ()
    let v5033 : string = "$0.json()"
    let v5034 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v736 v5033 
    let v5384 : unit = ()
    let v5385 : (unit -> unit) = closure24(v5034)
    let v5386 : unit = (fun () -> v5385 (); v5384) ()
    let v5739 : string = "$0.borsh()"
    let v5740 : Result<std_string_String, near_workspaces_error_Error> = Fable.Core.RustInterop.emitRustExpr v736 v5739 
    let v6090 : unit = ()
    let v6091 : (unit -> unit) = closure25(v5740)
    let v6092 : unit = (fun () -> v6091 (); v6090) ()
    let v6445 : string = method49(v4321, v1, v3513)
    let v6446 : bool = v3559 > 0
    let v6480 : Result<US7, anyhow_Error> =
        if v6446 then
            let v6449 : US7 = US7_0(v6445)
            let v6450 : Result<US7, anyhow_Error> = Ok v6449 
            v6450
        else
            let v6454 : bool = v4321 > 1
            if v6454 then
                let v6457 : US7 = US7_1
                let v6458 : Result<US7, anyhow_Error> = Ok v6457 
                v6458
            else
                let v6462 : string = "anyhow::anyhow!($0)"
                let v6463 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v6445 v6462 
                (* run_target_args'
                let v6465 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6466 : string = "Err($0)"
                let v6467 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v6463 v6466 
                let _run_target_args'_v6465 = v6467 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6468 : string = "Err($0)"
                let v6469 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v6463 v6468 
                let _run_target_args'_v6465 = v6469 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6470 : string = "Err($0)"
                let v6471 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v6463 v6470 
                let _run_target_args'_v6465 = v6471 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6472 : Result<US7, anyhow_Error> = v6463 |> Error
                let _run_target_args'_v6465 = v6472 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6473 : Result<US7, anyhow_Error> = v6463 |> Error
                let _run_target_args'_v6465 = v6473 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6474 : Result<US7, anyhow_Error> = v6463 |> Error
                let _run_target_args'_v6465 = v6474 
                #endif
#else
                let v6475 : Result<US7, anyhow_Error> = v6463 |> Error
                let _run_target_args'_v6465 = v6475 
                #endif
                let v6476 : Result<US7, anyhow_Error> = _run_target_args'_v6465 
                v6476
    let v6481 : string = ""
    let v6482 : string = "}"
    let v6483 : string = v6481 + v6482 
    let x = v6480 //
    let v6484 : _ = x
    let v6485 : unit = ()
    (* run_target_args'
    let v6486 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6487 : string = $"true; let _fix_closure_v6485 = $0"
    let v6488 : bool = Fable.Core.RustInterop.emitRustExpr v6484 v6487 
    let _run_target_args'_v6486 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6489 : string = $"true; let _fix_closure_v6485 = $0"
    let v6490 : bool = Fable.Core.RustInterop.emitRustExpr v6484 v6489 
    let _run_target_args'_v6486 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v6491 : string = $"true; let _fix_closure_v6485 = $0"
    let v6492 : bool = Fable.Core.RustInterop.emitRustExpr v6484 v6491 
    let _run_target_args'_v6486 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v6486 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v6486 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v6486 = false 
    #endif
#else
    let _run_target_args'_v6486 = false 
    #endif
    let v6493 : bool = _run_target_args'_v6486 
    let v6494 : string = $"true; _fix_closure_v6485 " + v6483 + "); " + v6481 + " // rust.fix_closure'"
    let v6495 : bool = Fable.Core.RustInterop.emitRustExpr () v6494 
    let v6496 : string = "__future_init"
    let v6497 : _ = Fable.Core.RustInterop.emitRustExpr () v6496 
    let v6498 : string = "v6497"
    let v6499 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v6498 
    v6499
and closure26 () (v0 : anyhow_Error) : std_string_String =
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
    closure26()
and closure27 () (v0 : US7) : US10 =
    US10_0(v0)
and method51 () : (US7 -> US10) =
    closure27()
and closure28 () (v0 : std_string_String) : US10 =
    US10_1(v0)
and method52 () : (std_string_String -> US10) =
    closure28()
and method53 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_yellow"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "String::from($0)"
    let v10 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v16 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v24 
    #endif
#else
    let v28 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v28 
    #endif
    let v31 : std_string_String = _run_target_args'_v8 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v31 v40 
    let _run_target_args'_v1 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "inline_colorization::color_yellow"
    let v43 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v42 
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v49 
    let _run_target_args'_v48 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v51 
    let _run_target_args'_v48 = v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = "String::from($0)"
    let v54 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v53 
    let _run_target_args'_v48 = v54 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v56 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v56 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v64 
    #endif
#else
    let v68 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v68 
    #endif
    let v71 : std_string_String = _run_target_args'_v48 
    let v80 : string = "fable_library_rust::String_::fromString($0)"
    let v81 : string = Fable.Core.RustInterop.emitRustExpr v71 v80 
    let _run_target_args'_v1 = v81 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string = "inline_colorization::color_yellow"
    let v83 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v82 
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "String::from($0)"
    let v90 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "String::from($0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "String::from($0)"
    let v94 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : std_string_String = _run_target_args'_v88 
    let v120 : string = "fable_library_rust::String_::fromString($0)"
    let v121 : string = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let _run_target_args'_v1 = v121 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v122 : string = "\u001b[93m"
    let _run_target_args'_v1 = v122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : string = "\u001b[93m"
    let _run_target_args'_v1 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v124 : string = "\u001b[93m"
    let _run_target_args'_v1 = v124 
    #endif
#else
    let v125 : string = "\u001b[93m"
    let _run_target_args'_v1 = v125 
    #endif
    let v126 : string = _run_target_args'_v1 
    
    
    
    
    
    let v131 : string = "Warning"
    let v132 : (unit -> string) = v131.ToLower
    let v133 : string = v132 ()
    let v136 : char = v133.[int 0]
    let v137 : string = method14(v136)
    let v139 : string = v126 + v137 
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "inline_colorization::color_reset"
    let v145 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v144 
    (* run_target_args'
    let v150 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v151 : string = "String::from($0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v151 
    let _run_target_args'_v150 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "String::from($0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v153 
    let _run_target_args'_v150 = v154 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v155 : string = "String::from($0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v155 
    let _run_target_args'_v150 = v156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v158 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v158 
    #endif
#if FABLE_COMPILER_PYTHON
    let v162 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v162 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v166 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v166 
    #endif
#else
    let v170 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v170 
    #endif
    let v173 : std_string_String = _run_target_args'_v150 
    let v182 : string = "fable_library_rust::String_::fromString($0)"
    let v183 : string = Fable.Core.RustInterop.emitRustExpr v173 v182 
    let _run_target_args'_v143 = v183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v184 : string = "inline_colorization::color_reset"
    let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v184 
    (* run_target_args'
    let v190 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v191 : string = "String::from($0)"
    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v191 
    let _run_target_args'_v190 = v192 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v193 : string = "String::from($0)"
    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v193 
    let _run_target_args'_v190 = v194 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v195 : string = "String::from($0)"
    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v195 
    let _run_target_args'_v190 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v198 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v202 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v206 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v206 
    #endif
#else
    let v210 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v210 
    #endif
    let v213 : std_string_String = _run_target_args'_v190 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v213 v222 
    let _run_target_args'_v143 = v223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v224 : string = "inline_colorization::color_reset"
    let v225 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v224 
    (* run_target_args'
    let v230 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v231 : string = "String::from($0)"
    let v232 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v231 
    let _run_target_args'_v230 = v232 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v233 : string = "String::from($0)"
    let v234 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v233 
    let _run_target_args'_v230 = v234 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v235 : string = "String::from($0)"
    let v236 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v235 
    let _run_target_args'_v230 = v236 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v238 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v238 
    #endif
#if FABLE_COMPILER_PYTHON
    let v242 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v246 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v246 
    #endif
#else
    let v250 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v250 
    #endif
    let v253 : std_string_String = _run_target_args'_v230 
    let v262 : string = "fable_library_rust::String_::fromString($0)"
    let v263 : string = Fable.Core.RustInterop.emitRustExpr v253 v262 
    let _run_target_args'_v143 = v263 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v264 : string = "\u001b[0m"
    let _run_target_args'_v143 = v264 
    #endif
#if FABLE_COMPILER_PYTHON
    let v265 : string = "\u001b[0m"
    let _run_target_args'_v143 = v265 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v266 : string = "\u001b[0m"
    let _run_target_args'_v143 = v266 
    #endif
#else
    let v267 : string = "\u001b[0m"
    let _run_target_args'_v143 = v267 
    #endif
    let v268 : string = _run_target_args'_v143 
    let v272 : string = v139 + v268 
    v272
and method55 (v0 : uint8, v1 : std_string_String) : string =
    let v2 : string = method15()
    let v4 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    method16(v4, v6)
    let v21 : string = "retry"
    method16(v4, v21)
    let v36 : string = " = "
    method16(v4, v36)
    let v54 : string = $"{v0}"
    method16(v4, v54)
    let v71 : string = "; "
    method16(v4, v71)
    let v86 : string = "error"
    method16(v4, v86)
    method16(v4, v36)
    (* run_target_args'
    let v118 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v119 : string = "format!(\"{:#?}\", $0)"
    let v120 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v119 
    let v121 : string = "fable_library_rust::String_::fromString($0)"
    let v122 : string = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let _run_target_args'_v118 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "format!(\"{:#?}\", $0)"
    let v124 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v123 
    let v125 : string = "fable_library_rust::String_::fromString($0)"
    let v126 : string = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let _run_target_args'_v118 = v126 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v127 : string = "format!(\"{:#?}\", $0)"
    let v128 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v127 
    let v129 : string = "fable_library_rust::String_::fromString($0)"
    let v130 : string = Fable.Core.RustInterop.emitRustExpr v128 v129 
    let _run_target_args'_v118 = v130 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v132 : string = $"%A{v1}"
    let _run_target_args'_v118 = v132 
    #endif
#if FABLE_COMPILER_PYTHON
    let v136 : string = $"%A{v1}"
    let _run_target_args'_v118 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v140 : string = $"%A{v1}"
    let _run_target_args'_v118 = v140 
    #endif
#else
    let v144 : string = $"%A{v1}"
    let _run_target_args'_v118 = v144 
    #endif
    let v147 : string = _run_target_args'_v118 
    method16(v4, v147)
    let v171 : string = " }"
    method16(v4, v171)
    let v185 : string = v4.l0
    v185
and method54 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : std_string_String) : string =
    let v10 : string = method55(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v32 : (int64 -> string) = _.ToString()
    let v33 : string = v32 v11
    let v37 : string = v25 + v33 
    let v41 : string = v37 + v14 
    let v46 : string = "spiral_wasm.run / Error error"
    let v47 : string = v41 + v46 
    let v52 : string = " / "
    let v53 : string = v47 + v52 
    let v57 : string = v53 + v10 
    method19(v57)
and closure29 (v0 : uint8, v1 : std_string_String) () : unit =
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
    let v337 : US8 =
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
            let v185 : (unit -> unit) = closure8(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure9()
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
            let v309 : int32 = v265 |> int32 
            let v319 : string = ""
            let v320 : bool = v125 <> v319 
            let v324 : bool =
                if v320 then
                    let v323 : bool = v309 <= 1
                    v323
                else
                    false
            if v324 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v319
                let v325 : string = "true; $0.into_iter().for_each(|x| { //"
                let v326 : bool = Fable.Core.RustInterop.emitRustExpr v263 v325 
                let v327 : string = "x"
                let v328 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v327 
                let v329 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v330 : bool = Fable.Core.RustInterop.emitRustExpr v328 v329 
                let v331 : string = $"true"
                let v332 : bool = Fable.Core.RustInterop.emitRustExpr () v331 
                let v333 : string = "true; }); //"
                let v334 : bool = Fable.Core.RustInterop.emitRustExpr () v333 
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
            let v335 : (string -> unit) = v165.l0
            v335 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and closure30 () () : unit =
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
    let v275 : US8 =
        if v63 then
            US8_1
        else
            let v79 : unit = ()
            let v80 : unit = (fun () -> v15 (); v79) ()
            let struct (v103 : Mut0, v104 : Mut1, v105 : Mut2, v106 : Mut3, v107 : Mut4, v108 : int64 option) = TraceState.trace_state.Value
            let v123 : unit = ()
            let v124 : (unit -> unit) = closure8(v103)
            let v125 : unit = (fun () -> v124 (); v123) ()
            let v128 : string = "\n"
            let v129 : (string -> unit) = closure9()
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
            let v247 : int32 = v203 |> int32 
            let v257 : string = ""
            let v258 : bool = v128 <> v257 
            let v262 : bool =
                if v258 then
                    let v261 : bool = v247 <= 1
                    v261
                else
                    false
            if v262 then
                v106.l0 <- v147
                ()
            else
                v106.l0 <- v257
                let v263 : string = "true; $0.into_iter().for_each(|x| { //"
                let v264 : bool = Fable.Core.RustInterop.emitRustExpr v201 v263 
                let v265 : string = "x"
                let v266 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v265 
                let v267 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v268 : bool = Fable.Core.RustInterop.emitRustExpr v266 v267 
                let v269 : string = $"true"
                let v270 : bool = Fable.Core.RustInterop.emitRustExpr () v269 
                let v271 : string = "true; }); //"
                let v272 : bool = Fable.Core.RustInterop.emitRustExpr () v271 
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
            let v273 : (string -> unit) = v104.l0
            v273 v128
            US8_0(v103, v104, v105, v106, v107, v108)
    
    ()
and closure31 (v0 : uint8, v1 : std_string_String) () : unit =
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
    let v337 : US8 =
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
            let v185 : (unit -> unit) = closure8(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure9()
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
            let v309 : int32 = v265 |> int32 
            let v319 : string = ""
            let v320 : bool = v125 <> v319 
            let v324 : bool =
                if v320 then
                    let v323 : bool = v309 <= 1
                    v323
                else
                    false
            if v324 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v319
                let v325 : string = "true; $0.into_iter().for_each(|x| { //"
                let v326 : bool = Fable.Core.RustInterop.emitRustExpr v263 v325 
                let v327 : string = "x"
                let v328 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v327 
                let v329 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v330 : bool = Fable.Core.RustInterop.emitRustExpr v328 v329 
                let v331 : string = $"true"
                let v332 : bool = Fable.Core.RustInterop.emitRustExpr () v331 
                let v333 : string = "true; }); //"
                let v334 : bool = Fable.Core.RustInterop.emitRustExpr () v333 
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
            let v335 : (string -> unit) = v165.l0
            v335 v125
            US8_0(v164, v165, v166, v167, v168, v169)
    
    ()
and closure32 () () : unit =
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
    let v275 : US8 =
        if v63 then
            US8_1
        else
            let v79 : unit = ()
            let v80 : unit = (fun () -> v15 (); v79) ()
            let struct (v103 : Mut0, v104 : Mut1, v105 : Mut2, v106 : Mut3, v107 : Mut4, v108 : int64 option) = TraceState.trace_state.Value
            let v123 : unit = ()
            let v124 : (unit -> unit) = closure8(v103)
            let v125 : unit = (fun () -> v124 (); v123) ()
            let v128 : string = "\n"
            let v129 : (string -> unit) = closure9()
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
            let v247 : int32 = v203 |> int32 
            let v257 : string = ""
            let v258 : bool = v128 <> v257 
            let v262 : bool =
                if v258 then
                    let v261 : bool = v247 <= 1
                    v261
                else
                    false
            if v262 then
                v106.l0 <- v147
                ()
            else
                v106.l0 <- v257
                let v263 : string = "true; $0.into_iter().for_each(|x| { //"
                let v264 : bool = Fable.Core.RustInterop.emitRustExpr v201 v263 
                let v265 : string = "x"
                let v266 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v265 
                let v267 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v268 : bool = Fable.Core.RustInterop.emitRustExpr v266 v267 
                let v269 : string = $"true"
                let v270 : bool = Fable.Core.RustInterop.emitRustExpr () v269 
                let v271 : string = "true; }); //"
                let v272 : bool = Fable.Core.RustInterop.emitRustExpr () v271 
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
            let v273 : (string -> unit) = v104.l0
            v273 v128
            US8_0(v103, v104, v105, v106, v107, v108)
    
    ()
and method56 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_bright_red"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "String::from($0)"
    let v10 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v16 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v24 
    #endif
#else
    let v28 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v28 
    #endif
    let v31 : std_string_String = _run_target_args'_v8 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v31 v40 
    let _run_target_args'_v1 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "inline_colorization::color_bright_red"
    let v43 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v42 
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v49 
    let _run_target_args'_v48 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v51 
    let _run_target_args'_v48 = v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = "String::from($0)"
    let v54 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v53 
    let _run_target_args'_v48 = v54 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v56 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v56 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v64 
    #endif
#else
    let v68 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v68 
    #endif
    let v71 : std_string_String = _run_target_args'_v48 
    let v80 : string = "fable_library_rust::String_::fromString($0)"
    let v81 : string = Fable.Core.RustInterop.emitRustExpr v71 v80 
    let _run_target_args'_v1 = v81 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string = "inline_colorization::color_bright_red"
    let v83 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v82 
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "String::from($0)"
    let v90 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "String::from($0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "String::from($0)"
    let v94 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : std_string_String = _run_target_args'_v88 
    let v120 : string = "fable_library_rust::String_::fromString($0)"
    let v121 : string = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let _run_target_args'_v1 = v121 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v122 : string = "\u001b[91m"
    let _run_target_args'_v1 = v122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : string = "\u001b[91m"
    let _run_target_args'_v1 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v124 : string = "\u001b[91m"
    let _run_target_args'_v1 = v124 
    #endif
#else
    let v125 : string = "\u001b[91m"
    let _run_target_args'_v1 = v125 
    #endif
    let v126 : string = _run_target_args'_v1 
    
    
    
    
    
    let v131 : string = "Critical"
    let v132 : (unit -> string) = v131.ToLower
    let v133 : string = v132 ()
    let v136 : char = v133.[int 0]
    let v137 : string = method14(v136)
    let v139 : string = v126 + v137 
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "inline_colorization::color_reset"
    let v145 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v144 
    (* run_target_args'
    let v150 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v151 : string = "String::from($0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v151 
    let _run_target_args'_v150 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "String::from($0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v153 
    let _run_target_args'_v150 = v154 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v155 : string = "String::from($0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v155 
    let _run_target_args'_v150 = v156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v158 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v158 
    #endif
#if FABLE_COMPILER_PYTHON
    let v162 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v162 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v166 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v166 
    #endif
#else
    let v170 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v170 
    #endif
    let v173 : std_string_String = _run_target_args'_v150 
    let v182 : string = "fable_library_rust::String_::fromString($0)"
    let v183 : string = Fable.Core.RustInterop.emitRustExpr v173 v182 
    let _run_target_args'_v143 = v183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v184 : string = "inline_colorization::color_reset"
    let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v184 
    (* run_target_args'
    let v190 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v191 : string = "String::from($0)"
    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v191 
    let _run_target_args'_v190 = v192 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v193 : string = "String::from($0)"
    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v193 
    let _run_target_args'_v190 = v194 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v195 : string = "String::from($0)"
    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v195 
    let _run_target_args'_v190 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v198 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v202 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v206 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v206 
    #endif
#else
    let v210 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v210 
    #endif
    let v213 : std_string_String = _run_target_args'_v190 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v213 v222 
    let _run_target_args'_v143 = v223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v224 : string = "inline_colorization::color_reset"
    let v225 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v224 
    (* run_target_args'
    let v230 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v231 : string = "String::from($0)"
    let v232 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v231 
    let _run_target_args'_v230 = v232 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v233 : string = "String::from($0)"
    let v234 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v233 
    let _run_target_args'_v230 = v234 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v235 : string = "String::from($0)"
    let v236 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v235 
    let _run_target_args'_v230 = v236 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v238 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v238 
    #endif
#if FABLE_COMPILER_PYTHON
    let v242 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v246 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v246 
    #endif
#else
    let v250 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v250 
    #endif
    let v253 : std_string_String = _run_target_args'_v230 
    let v262 : string = "fable_library_rust::String_::fromString($0)"
    let v263 : string = Fable.Core.RustInterop.emitRustExpr v253 v262 
    let _run_target_args'_v143 = v263 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v264 : string = "\u001b[0m"
    let _run_target_args'_v143 = v264 
    #endif
#if FABLE_COMPILER_PYTHON
    let v265 : string = "\u001b[0m"
    let _run_target_args'_v143 = v265 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v266 : string = "\u001b[0m"
    let _run_target_args'_v143 = v266 
    #endif
#else
    let v267 : string = "\u001b[0m"
    let _run_target_args'_v143 = v267 
    #endif
    let v268 : string = _run_target_args'_v143 
    let v272 : string = v139 + v268 
    v272
and method58 (v0 : uint8, v1 : string) : string =
    let v2 : string = method15()
    let v4 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    method16(v4, v6)
    let v21 : string = "retry"
    method16(v4, v21)
    let v36 : string = " = "
    method16(v4, v36)
    let v54 : string = $"{v0}"
    method16(v4, v54)
    let v71 : string = "; "
    method16(v4, v71)
    let v86 : string = "error"
    method16(v4, v86)
    method16(v4, v36)
    method16(v4, v1)
    let v129 : string = " }"
    method16(v4, v129)
    let v143 : string = v4.l0
    v143
and method57 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : uint8, v9 : string) : string =
    let v10 : string = method58(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v32 : (int64 -> string) = _.ToString()
    let v33 : string = v32 v11
    let v37 : string = v25 + v33 
    let v41 : string = v37 + v14 
    let v46 : string = "spiral_wasm.run / Ok (Some error)"
    let v47 : string = v41 + v46 
    let v52 : string = " / "
    let v53 : string = v47 + v52 
    let v57 : string = v53 + v10 
    method19(v57)
and closure33 (v0 : uint8, v1 : string) () : unit =
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
    let v337 : US8 =
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
            let v185 : (unit -> unit) = closure8(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure9()
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
            let v309 : int32 = v265 |> int32 
            let v319 : string = ""
            let v320 : bool = v125 <> v319 
            let v324 : bool =
                if v320 then
                    let v323 : bool = v309 <= 1
                    v323
                else
                    false
            if v324 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v319
                let v325 : string = "true; $0.into_iter().for_each(|x| { //"
                let v326 : bool = Fable.Core.RustInterop.emitRustExpr v263 v325 
                let v327 : string = "x"
                let v328 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v327 
                let v329 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v330 : bool = Fable.Core.RustInterop.emitRustExpr v328 v329 
                let v331 : string = $"true"
                let v332 : bool = Fable.Core.RustInterop.emitRustExpr () v331 
                let v333 : string = "true; }); //"
                let v334 : bool = Fable.Core.RustInterop.emitRustExpr () v333 
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
            let v335 : (string -> unit) = v165.l0
            v335 v125
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
    let v3417 : US9 =
        match v30 with
        | US10_1(v801) -> (* Error *)
            let v802 : bool = v1 >= 15uy
            if v802 then
                let v1152 : unit = ()
                let v1153 : (unit -> unit) = closure29(v1, v801)
                let v1154 : unit = (fun () -> v1153 (); v1152) ()
                let v1797 : unit = ()
                let v1798 : (unit -> unit) = closure30()
                let v1799 : unit = (fun () -> v1798 (); v1797) ()
                let v2092 : string = "true; let __future_init = Box::pin(/*"
                let v2093 : bool = Fable.Core.RustInterop.emitRustExpr () v2092 
                let v2094 : string = "*/ async move { /*"
                let v2095 : bool = Fable.Core.RustInterop.emitRustExpr () v2094 
                let v2096 : string = "*/ ()"
                let v2097 : bool = Fable.Core.RustInterop.emitRustExpr () v2096 
                let v2098 : string = ""
                let v2099 : string = "}"
                let v2100 : string = v2098 + v2099 
                let v2101 : US7 = US7_1
                let x = struct (v1, v2101) //
                let v2102 : _ = x
                let v2103 : unit = ()
                (* run_target_args'
                let v2104 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2105 : string = $"true; let _fix_closure_v2103 = $0"
                let v2106 : bool = Fable.Core.RustInterop.emitRustExpr v2102 v2105 
                let _run_target_args'_v2104 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2107 : string = $"true; let _fix_closure_v2103 = $0"
                let v2108 : bool = Fable.Core.RustInterop.emitRustExpr v2102 v2107 
                let _run_target_args'_v2104 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2109 : string = $"true; let _fix_closure_v2103 = $0"
                let v2110 : bool = Fable.Core.RustInterop.emitRustExpr v2102 v2109 
                let _run_target_args'_v2104 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v2104 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v2104 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v2104 = false 
                #endif
#else
                let _run_target_args'_v2104 = false 
                #endif
                let v2111 : bool = _run_target_args'_v2104 
                let v2112 : string = $"true; _fix_closure_v2103 " + v2100 + "); " + v2098 + " // rust.fix_closure'"
                let v2113 : bool = Fable.Core.RustInterop.emitRustExpr () v2112 
                let v2114 : string = "__future_init"
                let v2115 : _ = Fable.Core.RustInterop.emitRustExpr () v2114 
                let v2116 : string = "v2115"
                let v2117 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v2116 
                let v2118 : string = "v2117.await"
                let struct (v2119 : uint8, v2120 : US7) = Fable.Core.RustInterop.emitRustExpr () v2118 
                US9_0(v2119, v2120)
            else
                let v2471 : unit = ()
                let v2472 : (unit -> unit) = closure31(v1, v801)
                let v2473 : unit = (fun () -> v2472 (); v2471) ()
                let v3116 : unit = ()
                let v3117 : (unit -> unit) = closure32()
                let v3118 : unit = (fun () -> v3117 (); v3116) ()
                let v3411 : uint8 = v1 + 1uy
                let v3412 : std_pin_Pin<Box<Dyn<std_future_Future<US9>>>> = method26(v0, v3411)
                let v3413 : string = "v3412.await"
                let v3414 : US9 = Fable.Core.RustInterop.emitRustExpr () v3413 
                v3414
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
                let v414 : unit = ()
                let v415 : (unit -> unit) = closure33(v1, v64)
                let v416 : unit = (fun () -> v415 (); v414) ()
                let v769 : string = "true; let __future_init = Box::pin(/*"
                let v770 : bool = Fable.Core.RustInterop.emitRustExpr () v769 
                let v771 : string = "*/ async move { /*"
                let v772 : bool = Fable.Core.RustInterop.emitRustExpr () v771 
                let v773 : string = "*/ ()"
                let v774 : bool = Fable.Core.RustInterop.emitRustExpr () v773 
                let v775 : string = ""
                let v776 : string = "}"
                let v777 : string = v775 + v776 
                let v778 : US7 = US7_0(v64)
                let x = struct (v1, v778) //
                let v779 : _ = x
                let v780 : unit = ()
                (* run_target_args'
                let v781 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v782 : string = $"true; let _fix_closure_v780 = $0"
                let v783 : bool = Fable.Core.RustInterop.emitRustExpr v779 v782 
                let _run_target_args'_v781 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v784 : string = $"true; let _fix_closure_v780 = $0"
                let v785 : bool = Fable.Core.RustInterop.emitRustExpr v779 v784 
                let _run_target_args'_v781 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v786 : string = $"true; let _fix_closure_v780 = $0"
                let v787 : bool = Fable.Core.RustInterop.emitRustExpr v779 v786 
                let _run_target_args'_v781 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v781 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v781 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v781 = false 
                #endif
#else
                let _run_target_args'_v781 = false 
                #endif
                let v788 : bool = _run_target_args'_v781 
                let v789 : string = $"true; _fix_closure_v780 " + v777 + "); " + v775 + " // rust.fix_closure'"
                let v790 : bool = Fable.Core.RustInterop.emitRustExpr () v789 
                let v791 : string = "__future_init"
                let v792 : _ = Fable.Core.RustInterop.emitRustExpr () v791 
                let v793 : string = "v792"
                let v794 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v793 
                let v795 : string = "v794.await"
                let struct (v796 : uint8, v797 : US7) = Fable.Core.RustInterop.emitRustExpr () v795 
                US9_1(v796, v797)
    let v3418 : string = ""
    let v3419 : string = "}"
    let v3420 : string = v3418 + v3419 
    let x = v3417 //
    let v3421 : _ = x
    let v3422 : unit = ()
    (* run_target_args'
    let v3423 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3424 : string = $"true; let _fix_closure_v3422 = $0"
    let v3425 : bool = Fable.Core.RustInterop.emitRustExpr v3421 v3424 
    let _run_target_args'_v3423 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3426 : string = $"true; let _fix_closure_v3422 = $0"
    let v3427 : bool = Fable.Core.RustInterop.emitRustExpr v3421 v3426 
    let _run_target_args'_v3423 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3428 : string = $"true; let _fix_closure_v3422 = $0"
    let v3429 : bool = Fable.Core.RustInterop.emitRustExpr v3421 v3428 
    let _run_target_args'_v3423 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v3423 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v3423 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v3423 = false 
    #endif
#else
    let _run_target_args'_v3423 = false 
    #endif
    let v3430 : bool = _run_target_args'_v3423 
    let v3431 : string = $"true; _fix_closure_v3422 " + v3420 + "); " + v3418 + " // rust.fix_closure'"
    let v3432 : bool = Fable.Core.RustInterop.emitRustExpr () v3431 
    let v3433 : string = "__future_init"
    let v3434 : _ = Fable.Core.RustInterop.emitRustExpr () v3433 
    let v3435 : string = "v3434"
    let v3436 : std_pin_Pin<Box<Dyn<std_future_Future<US9>>>> = Fable.Core.RustInterop.emitRustExpr () v3435 
    v3436
and method60 (v0 : US9) : string =
    let v1 : string = method15()
    let v3 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    method16(v3, v5)
    let v20 : string = "retries"
    method16(v3, v20)
    let v35 : string = " = "
    method16(v3, v35)
    let v50 : string = $"%A{v0}"
    method16(v3, v50)
    let v68 : string = " }"
    method16(v3, v68)
    let v82 : string = v3.l0
    v82
and method59 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : US9) : string =
    let v9 : string = method60(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v31 : (int64 -> string) = _.ToString()
    let v32 : string = v31 v10
    let v36 : string = v24 + v32 
    let v40 : string = v36 + v13 
    let v45 : string = "spiral_wasm.run"
    let v46 : string = v40 + v45 
    let v51 : string = " / "
    let v52 : string = v46 + v51 
    let v56 : string = v52 + v9 
    method19(v56)
and closure34 (v0 : US9) () : unit =
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
    let v336 : US8 =
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
            let v184 : (unit -> unit) = closure8(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure9()
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
            let v308 : int32 = v264 |> int32 
            let v318 : string = ""
            let v319 : bool = v124 <> v318 
            let v323 : bool =
                if v319 then
                    let v322 : bool = v308 <= 1
                    v322
                else
                    false
            if v323 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v318
                let v324 : string = "true; $0.into_iter().for_each(|x| { //"
                let v325 : bool = Fable.Core.RustInterop.emitRustExpr v262 v324 
                let v326 : string = "x"
                let v327 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v326 
                let v328 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v329 : bool = Fable.Core.RustInterop.emitRustExpr v327 v328 
                let v330 : string = $"true"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr () v330 
                let v332 : string = "true; }); //"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
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
            let v334 : (string -> unit) = v164.l0
            v334 v124
            US8_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method61 (v0 : US9, v1 : US7) : string =
    let v2 : string = method15()
    let v4 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    method16(v4, v6)
    let v21 : string = "retries"
    method16(v4, v21)
    let v36 : string = " = "
    method16(v4, v36)
    let v51 : string = $"%A{v0}"
    method16(v4, v51)
    let v69 : string = "; "
    method16(v4, v69)
    let v84 : string = "error"
    method16(v4, v84)
    method16(v4, v36)
    let v113 : string = $"%A{v1}"
    method16(v4, v113)
    let v131 : string = " }"
    method16(v4, v131)
    let v145 : string = v4.l0
    v145
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
    let v429 : unit = ()
    let v430 : (unit -> unit) = closure12(v79)
    let v431 : unit = (fun () -> v430 (); v429) ()
    let v784 : string = "std::fs::read(&*$0)"
    let v785 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v79 v784 
    let v786 : string = "$0?"
    let v787 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v785 v786 
    let v788 : uint8 = 1uy
    let v789 : std_pin_Pin<Box<Dyn<std_future_Future<US9>>>> = method26(v787, v788)
    let v790 : string = "v789.await"
    let v791 : US9 = Fable.Core.RustInterop.emitRustExpr () v790 
    let v1141 : unit = ()
    let v1142 : (unit -> unit) = closure34(v791)
    let v1143 : unit = (fun () -> v1142 (); v1141) ()
    let v1523 : Result<uint8, anyhow_Error> =
        match v791 with
        | US9_1(v1502, v1503) -> (* Error *)
            let v1504 : string = method61(v791, v1503)
            let v1505 : string = "anyhow::anyhow!($0)"
            let v1506 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v1504 v1505 
            (* run_target_args'
            let v1508 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1509 : string = "Err($0)"
            let v1510 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1506 v1509 
            let _run_target_args'_v1508 = v1510 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1511 : string = "Err($0)"
            let v1512 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1506 v1511 
            let _run_target_args'_v1508 = v1512 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1513 : string = "Err($0)"
            let v1514 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1506 v1513 
            let _run_target_args'_v1508 = v1514 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1515 : Result<uint8, anyhow_Error> = v1506 |> Error
            let _run_target_args'_v1508 = v1515 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1516 : Result<uint8, anyhow_Error> = v1506 |> Error
            let _run_target_args'_v1508 = v1516 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1517 : Result<uint8, anyhow_Error> = v1506 |> Error
            let _run_target_args'_v1508 = v1517 
            #endif
#else
            let v1518 : Result<uint8, anyhow_Error> = v1506 |> Error
            let _run_target_args'_v1508 = v1518 
            #endif
            let v1519 : Result<uint8, anyhow_Error> = _run_target_args'_v1508 
            v1519
        | US9_0(v1496, v1497) -> (* Ok *)
            let v1499 : Result<uint8, anyhow_Error> = Ok v1496 
            v1499
    let v1524 : string = ""
    let v1525 : string = "}"
    let v1526 : string = v1524 + v1525 
    let x = v1523 //
    let v1527 : _ = x
    let v1528 : unit = ()
    (* run_target_args'
    let v1529 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1530 : string = $"true; let _fix_closure_v1528 = $0"
    let v1531 : bool = Fable.Core.RustInterop.emitRustExpr v1527 v1530 
    let _run_target_args'_v1529 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1532 : string = $"true; let _fix_closure_v1528 = $0"
    let v1533 : bool = Fable.Core.RustInterop.emitRustExpr v1527 v1532 
    let _run_target_args'_v1529 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1534 : string = $"true; let _fix_closure_v1528 = $0"
    let v1535 : bool = Fable.Core.RustInterop.emitRustExpr v1527 v1534 
    let _run_target_args'_v1529 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v1529 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v1529 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v1529 = false 
    #endif
#else
    let _run_target_args'_v1529 = false 
    #endif
    let v1536 : bool = _run_target_args'_v1529 
    let v1537 : string = $"true; _fix_closure_v1528 " + v1526 + "); " + v1524 + " // rust.fix_closure'"
    let v1538 : bool = Fable.Core.RustInterop.emitRustExpr () v1537 
    let v1539 : string = "__future_init"
    let v1540 : _ = Fable.Core.RustInterop.emitRustExpr () v1539 
    let v1541 : string = "v1540"
    let v1542 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v1541 
    v1542
and closure35 () (v0 : uint8) : US11 =
    US11_0(v0)
and method62 () : (uint8 -> US11) =
    closure35()
and closure36 () (v0 : std_string_String) : US11 =
    US11_1(v0)
and method63 () : (std_string_String -> US11) =
    closure36()
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
    let v616 : unit = ()
    let v617 : (unit -> unit) = closure5(v0)
    let v618 : unit = (fun () -> v617 (); v616) ()
    let v971 : string = method20()
    (* run_target_args'
    let v976 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v977 : string = "&*$0"
    let v978 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v971 v977 
    let _run_target_args'_v976 = v978 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v979 : string = "&*$0"
    let v980 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v971 v979 
    let _run_target_args'_v976 = v980 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v981 : string = "&*$0"
    let v982 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v971 v981 
    let _run_target_args'_v976 = v982 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v984 : Ref<Str> = v971 |> unbox<Ref<Str>>
    let _run_target_args'_v976 = v984 
    #endif
#if FABLE_COMPILER_PYTHON
    let v988 : Ref<Str> = v971 |> unbox<Ref<Str>>
    let _run_target_args'_v976 = v988 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v992 : Ref<Str> = v971 |> unbox<Ref<Str>>
    let _run_target_args'_v976 = v992 
    #endif
#else
    let v996 : Ref<Str> = v971 |> unbox<Ref<Str>>
    let _run_target_args'_v976 = v996 
    #endif
    let v999 : Ref<Str> = _run_target_args'_v976 
    let v1008 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v1009 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v999) v1008 
    let v1012 : (std_string_String -> string) = method21()
    let v1013 : string option = v1009 |> Option.map v1012 
    let v1126 : (string -> US7) = method8()
    let v1127 : US7 option = v1013 |> Option.map v1126 
    let v1147 : US7 = US7_1
    let v1148 : US7 = v1127 |> Option.defaultValue v1147 
    let v1152 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method22(v3)
    let v1153 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v1154 : _ = Fable.Core.RustInterop.emitRustExpr () v1153 
    let v1155 : string = "v1154.handle().block_on($0)"
    let v1156 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v1152 v1155 
    let v1157 : (anyhow_Error -> std_string_String) = method50()
    (* run_target_args'
    let v1159 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1160 : string = "$0.map_err(|x| $1(x))"
    let v1161 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v1156, v1157) v1160 
    let _run_target_args'_v1159 = v1161 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1162 : string = "$0.map_err(|x| $1(x))"
    let v1163 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v1156, v1157) v1162 
    let _run_target_args'_v1159 = v1163 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1164 : string = "$0.map_err(|x| $1(x))"
    let v1165 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v1156, v1157) v1164 
    let _run_target_args'_v1159 = v1165 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1166 : Result<uint8, std_string_String> = match v1156 with Ok x -> Ok x | Error x -> Error (v1157 x)
    let _run_target_args'_v1159 = v1166 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1167 : Result<uint8, std_string_String> = match v1156 with Ok x -> Ok x | Error x -> Error (v1157 x)
    let _run_target_args'_v1159 = v1167 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1168 : Result<uint8, std_string_String> = match v1156 with Ok x -> Ok x | Error x -> Error (v1157 x)
    let _run_target_args'_v1159 = v1168 
    #endif
#else
    let v1169 : Result<uint8, std_string_String> = match v1156 with Ok x -> Ok x | Error x -> Error (v1157 x)
    let _run_target_args'_v1159 = v1169 
    #endif
    let v1170 : Result<uint8, std_string_String> = _run_target_args'_v1159 
    let v1173 : (uint8 -> US11) = method62()
    let v1174 : (std_string_String -> US11) = method63()
    let v1176 : US11 = match v1170 with Ok x -> v1173 x | Error x -> v1174 x
    match v1176 with
    | US11_1(v1201) -> (* Error *)
        match v1148 with
        | US7_0(v1202) -> (* Some *)
            let v1203 : bool = "" = v1202
            if v1203 then
                ()
            else
                let v1204 : string = "fable_library_rust::String_::fromString($0)"
                let v1205 : string = Fable.Core.RustInterop.emitRustExpr v1201 v1204 
                let v1207 : bool = v1205.Contains v1202 
                if v1207 then
                    ()
                else
                    let v1210 : string = $"spiral_wasm.main / exception: '{v1202}' / error: {v1201}"
                    (* run_target_args'
                    let v1212 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v1213 : string = "Err($0)"
                    let v1214 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1210 v1213 
                    let _run_target_args'_v1212 = v1214 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v1215 : string = "Err($0)"
                    let v1216 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1210 v1215 
                    let _run_target_args'_v1212 = v1216 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v1217 : string = "Err($0)"
                    let v1218 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1210 v1217 
                    let _run_target_args'_v1212 = v1218 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v1219 : Result<unit, string> = v1210 |> Error
                    let _run_target_args'_v1212 = v1219 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v1220 : Result<unit, string> = v1210 |> Error
                    let _run_target_args'_v1212 = v1220 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v1221 : Result<unit, string> = v1210 |> Error
                    let _run_target_args'_v1212 = v1221 
                    #endif
#else
                    let v1222 : Result<unit, string> = v1210 |> Error
                    let _run_target_args'_v1212 = v1222 
                    #endif
                    let v1223 : Result<unit, string> = _run_target_args'_v1212 
                    (* run_target_args'
                    let v1226 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v1227 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v1223 v1227 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v1228 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v1223 v1228 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v1229 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v1223 v1229 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    match v1223 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if FABLE_COMPILER_PYTHON
                    match v1223 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    match v1223 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#else
                    match v1223 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
                    // run_target_args' is_unit
                    ()
        | _ ->
            (* run_target_args'
            let v1231 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1232 : string = "$0.unwrap()"
            let v1233 : uint8 = Fable.Core.RustInterop.emitRustExpr v1170 v1232 
            let _run_target_args'_v1231 = v1233 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1234 : string = "$0.unwrap()"
            let v1235 : uint8 = Fable.Core.RustInterop.emitRustExpr v1170 v1234 
            let _run_target_args'_v1231 = v1235 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1236 : string = "$0.unwrap()"
            let v1237 : uint8 = Fable.Core.RustInterop.emitRustExpr v1170 v1236 
            let _run_target_args'_v1231 = v1237 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1238 : uint8 = match v1170 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v1231 = v1238 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1239 : uint8 = match v1170 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v1231 = v1239 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1240 : uint8 = match v1170 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v1231 = v1240 
            #endif
#else
            let v1241 : uint8 = match v1170 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v1231 = v1241 
            #endif
            let v1242 : uint8 = _run_target_args'_v1231 
            ()
    | US11_0(v1179) -> (* Ok *)
        match v1148 with
        | US7_0(v1180) -> (* Some *)
            let v1181 : string = $"spiral_wasm.main / retries: {v1179} / exception: '{v1180}'"
            (* run_target_args'
            let v1183 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1184 : string = "Err($0)"
            let v1185 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1181 v1184 
            let _run_target_args'_v1183 = v1185 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1186 : string = "Err($0)"
            let v1187 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1181 v1186 
            let _run_target_args'_v1183 = v1187 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1188 : string = "Err($0)"
            let v1189 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v1181 v1188 
            let _run_target_args'_v1183 = v1189 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1190 : Result<unit, string> = v1181 |> Error
            let _run_target_args'_v1183 = v1190 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1191 : Result<unit, string> = v1181 |> Error
            let _run_target_args'_v1183 = v1191 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1192 : Result<unit, string> = v1181 |> Error
            let _run_target_args'_v1183 = v1192 
            #endif
#else
            let v1193 : Result<unit, string> = v1181 |> Error
            let _run_target_args'_v1183 = v1193 
            #endif
            let v1194 : Result<unit, string> = _run_target_args'_v1183 
            (* run_target_args'
            let v1197 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1198 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v1194 v1198 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1199 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v1194 v1199 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1200 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v1194 v1200 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            match v1194 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if FABLE_COMPILER_PYTHON
            match v1194 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            match v1194 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#else
            match v1194 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
            // run_target_args' is_unit
            ()
        | _ ->
            ()
    0
let v0 : ((string []) -> int32) = closure0()
let main args = v0 args
()
