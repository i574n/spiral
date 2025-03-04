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
    
    
    
    
    
    let v62 : string list = []
    let v64 : string = "Critical"
    let v65 : string list = v64 :: v62 
    let v69 : string = "Warning"
    let v70 : string list = v69 :: v65 
    let v74 : string = "Info"
    let v75 : string list = v74 :: v70 
    let v79 : string = "Debug"
    let v80 : string list = v79 :: v75 
    let v84 : string = "Verbose"
    let v85 : string list = v84 :: v80 
    let v89 : (string list -> (string [])) = List.toArray
    let v90 : (string []) = v89 v85
    let v93 : string = "$0.to_vec()"
    let v94 : Vec<string> = Fable.Core.RustInterop.emitRustExpr v90 v93 
    let v95 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v96 : bool = Fable.Core.RustInterop.emitRustExpr v94 v95 
    let v97 : string = "x"
    let v98 : string = Fable.Core.RustInterop.emitRustExpr () v97 
    (* run_target_args'
    let v103 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v104 : string = "&*$0"
    let v105 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v98 v104 
    let _run_target_args'_v103 = v105 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v106 : string = "&*$0"
    let v107 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v98 v106 
    let _run_target_args'_v103 = v107 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v108 : string = "&*$0"
    let v109 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v98 v108 
    let _run_target_args'_v103 = v109 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v111 : Ref<Str> = v98 |> unbox<Ref<Str>>
    let _run_target_args'_v103 = v111 
    #endif
#if FABLE_COMPILER_PYTHON
    let v115 : Ref<Str> = v98 |> unbox<Ref<Str>>
    let _run_target_args'_v103 = v115 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v119 : Ref<Str> = v98 |> unbox<Ref<Str>>
    let _run_target_args'_v103 = v119 
    #endif
#else
    let v123 : Ref<Str> = v98 |> unbox<Ref<Str>>
    let _run_target_args'_v103 = v123 
    #endif
    let v126 : Ref<Str> = _run_target_args'_v103 
    (* run_target_args'
    let v136 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v137 : string = "String::from($0)"
    let v138 : std_string_String = Fable.Core.RustInterop.emitRustExpr v126 v137 
    let _run_target_args'_v136 = v138 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : string = "String::from($0)"
    let v140 : std_string_String = Fable.Core.RustInterop.emitRustExpr v126 v139 
    let _run_target_args'_v136 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = "String::from($0)"
    let v142 : std_string_String = Fable.Core.RustInterop.emitRustExpr v126 v141 
    let _run_target_args'_v136 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : std_string_String = v126 |> unbox<std_string_String>
    let _run_target_args'_v136 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : std_string_String = v126 |> unbox<std_string_String>
    let _run_target_args'_v136 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : std_string_String = v126 |> unbox<std_string_String>
    let _run_target_args'_v136 = v152 
    #endif
#else
    let v156 : std_string_String = v126 |> unbox<std_string_String>
    let _run_target_args'_v136 = v156 
    #endif
    let v159 : std_string_String = _run_target_args'_v136 
    let v165 : string = "Box::new($0)"
    let v166 : Box<std_string_String> = Fable.Core.RustInterop.emitRustExpr v159 v165 
    let v167 : string = "Box::leak($0)"
    let v168 : Ref<Lifetime<StaticLifetime, Mut<std_string_String>>> = Fable.Core.RustInterop.emitRustExpr v166 v167 
    let v169 : string = "clap::builder::PossibleValue::new(&**$0)"
    let v170 : clap_builder_PossibleValue = Fable.Core.RustInterop.emitRustExpr v168 v169 
    let v171 : string = "true; $0 }).collect::<Vec<_>>()"
    let v172 : bool = Fable.Core.RustInterop.emitRustExpr v170 v171 
    let v173 : string = "_vec_map"
    let v174 : Vec<clap_builder_PossibleValue> = Fable.Core.RustInterop.emitRustExpr () v173 
    let v175 : string = "Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new($0))"
    let v176 : clap_builder_ValueParser = Fable.Core.RustInterop.emitRustExpr v174 v175 
    let v177 : string = "$0.value_parser($1)"
    let v178 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v61, v176) v177 
    let v179 : string = "clap::Command::arg($0, $1)"
    let v180 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v50, v178) v179 
    let v181 : string = "wasm"
    let v182 : string = "r#\"" + v181 + "\"#"
    let v183 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v182 
    let v184 : string = "clap::Arg::new($0)"
    let v185 : clap_Arg = Fable.Core.RustInterop.emitRustExpr v183 v184 
    let v186 : string = "$0.short($1)"
    let v187 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v185, 'w') v186 
    let v188 : string = "r#\"" + v181 + "\"#"
    let v189 : Ref<Lifetime<StaticLifetime, Str>> = Fable.Core.RustInterop.emitRustExpr () v188 
    let v190 : string = "$0.long($1)"
    let v191 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v187, v189) v190 
    let v192 : string = "$0.required($1)"
    let v193 : clap_Arg = Fable.Core.RustInterop.emitRustExpr struct (v191, true) v192 
    let v194 : string = "clap::Command::arg($0, $1)"
    let v195 : clap_Command = Fable.Core.RustInterop.emitRustExpr struct (v180, v193) v194 
    v195
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
    let v51 : (string -> US7) = method8()
    let v52 : US7 option = v47 |> Option.map v51 
    let v65 : US7 = US7_1
    let v66 : US7 = v52 |> Option.defaultValue v65 
    let v73 : string =
        match v66 with
        | US7_1 -> (* None *)
            let v71 : string = ""
            v71
        | US7_0(v70) -> (* Some *)
            v70
    let _run_target_args'_v5 = v73 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v74 : US5 = US5_1
    let v75 : US6 = US6_1(v74)
    let v76 : string = $"env.get_environment_variable / target: {v75} / var: {v0}"
    let v77 : string = failwith<string> v76
    let _run_target_args'_v5 = v77 
    #endif
#else
    let v78 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v79 : string = v78 v0
    let mutable _v79 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v81 : (string -> string option) = Option.ofObj
    let v82 : string option = v81 v79
    v82 
    #else
    Some v79 
    #endif
    |> fun x -> _v79 <- Some x
    let v83 : string option = match _v79 with Some x -> x | None -> failwith "optionm'.of_obj / _v79=None"
    let v87 : (string -> US7) = method8()
    let v88 : US7 option = v83 |> Option.map v87 
    let v101 : US7 = US7_1
    let v102 : US7 = v88 |> Option.defaultValue v101 
    let v109 : string =
        match v102 with
        | US7_1 -> (* None *)
            let v107 : string = ""
            v107
        | US7_0(v106) -> (* Some *)
            v106
    let _run_target_args'_v5 = v109 
    #endif
    let v110 : string = _run_target_args'_v5 
    v110
and method4 () : struct (US2 * US4) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method5(v0)
    
    
    
    
    
    let v2 : bool = "Verbose" = v1
    let v6 : US2 =
        if v2 then
            let v3 : US3 = US3_0
            US2_0(v3)
        else
            US2_1
    let v47 : US2 =
        match v6 with
        | US2_1 -> (* None *)
            let v9 : bool = "Debug" = v1
            let v13 : US2 =
                if v9 then
                    let v10 : US3 = US3_1
                    US2_0(v10)
                else
                    US2_1
            match v13 with
            | US2_1 -> (* None *)
                let v16 : bool = "Info" = v1
                let v20 : US2 =
                    if v16 then
                        let v17 : US3 = US3_2
                        US2_0(v17)
                    else
                        US2_1
                match v20 with
                | US2_1 -> (* None *)
                    let v23 : bool = "Warning" = v1
                    let v27 : US2 =
                        if v23 then
                            let v24 : US3 = US3_3
                            US2_0(v24)
                        else
                            US2_1
                    match v27 with
                    | US2_1 -> (* None *)
                        let v30 : bool = "Critical" = v1
                        let v34 : US2 =
                            if v30 then
                                let v31 : US3 = US3_4
                                US2_0(v31)
                            else
                                US2_1
                        match v34 with
                        | US2_1 -> (* None *)
                            US2_1
                        | US2_0(v35) -> (* Some *)
                            US2_0(v35)
                    | US2_0(v28) -> (* Some *)
                        US2_0(v28)
                | US2_0(v21) -> (* Some *)
                    US2_0(v21)
            | US2_0(v14) -> (* Some *)
                US2_0(v14)
        | US2_0(v7) -> (* Some *)
            US2_0(v7)
    let v48 : string = "AUTOMATION"
    let v49 : string = method5(v48)
    let v52 : string = "True"
    let v53 : bool = v49 <> v52 
    let v120 : US4 =
        if v53 then
            US4_1
        else
            (* run_target_args'
            let v59 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v60 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v60 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v61 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v59 = v63 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v66 
            #endif
#if FABLE_COMPILER_PYTHON
            let v67 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v67 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v68 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v68 
            #endif
#else
            let v69 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v69 
            #endif
            let v70 : System.DateTime = _run_target_args'_v59 
            (* run_target_args'
            let v78 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v79 : (System.DateTime -> int64) = _.Ticks
            let v80 : int64 = v79 v70
            let _run_target_args'_v78 = v80 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v81 : (System.DateTime -> int64) = _.Ticks
            let v82 : int64 = v81 v70
            let _run_target_args'_v78 = v82 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v84 : int64 = null |> unbox<int64>
            let _run_target_args'_v78 = v84 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v87 : (System.DateTime -> int64) = _.Ticks
            let v88 : int64 = v87 v70
            let _run_target_args'_v78 = v88 
            #endif
#if FABLE_COMPILER_PYTHON
            let v89 : (System.DateTime -> int64) = _.Ticks
            let v90 : int64 = v89 v70
            let _run_target_args'_v78 = v90 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v91 : (System.DateTime -> int64) = _.Ticks
            let v92 : int64 = v91 v70
            let _run_target_args'_v78 = v92 
            #endif
#else
            let v93 : (System.DateTime -> int64) = _.Ticks
            let v94 : int64 = v93 v70
            let _run_target_args'_v78 = v94 
            #endif
            let v95 : int64 = _run_target_args'_v78 
            let v116 : int64 = v95 |> int64 
            US4_0(v116)
    struct (v47, v120)
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
    let v195 : int64 option =
        match v173 with
        | US4_1 -> (* None *)
            let v193 : int64 option = None
            v193
        | US4_0(v188) -> (* Some *)
            let v190 : int64 option = Some v188 
            v190
    struct (v178, v180, v181, v183, v187, v195)
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
    let v165 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v167 : (int64 -> US4) = method11()
    let v168 : US4 option = v5 |> Option.map v167 
    let v181 : US4 = US4_1
    let v182 : US4 = v168 |> Option.defaultValue v181 
    let v300 : System.DateTime =
        match v182 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v283 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v284 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v284 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v285 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v285 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v287 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v283 = v287 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v290 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v290 
            #endif
#if FABLE_COMPILER_PYTHON
            let v291 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v291 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v292 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v292 
            #endif
#else
            let v293 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v293 
            #endif
            let v294 : System.DateTime = _run_target_args'_v283 
            v294
        | US4_0(v186) -> (* Some *)
            (* run_target_args'
            let v189 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v190 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v190 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v191 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v191 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v189 = v193 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v196 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v196 
            #endif
#if FABLE_COMPILER_PYTHON
            let v197 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v197 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v198 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v198 
            #endif
#else
            let v199 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v199 
            #endif
            let v200 : System.DateTime = _run_target_args'_v189 
            (* run_target_args'
            let v208 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v209 : (System.DateTime -> int64) = _.Ticks
            let v210 : int64 = v209 v200
            let _run_target_args'_v208 = v210 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v211 : (System.DateTime -> int64) = _.Ticks
            let v212 : int64 = v211 v200
            let _run_target_args'_v208 = v212 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v214 : int64 = null |> unbox<int64>
            let _run_target_args'_v208 = v214 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v217 : (System.DateTime -> int64) = _.Ticks
            let v218 : int64 = v217 v200
            let _run_target_args'_v208 = v218 
            #endif
#if FABLE_COMPILER_PYTHON
            let v219 : (System.DateTime -> int64) = _.Ticks
            let v220 : int64 = v219 v200
            let _run_target_args'_v208 = v220 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v221 : (System.DateTime -> int64) = _.Ticks
            let v222 : int64 = v221 v200
            let _run_target_args'_v208 = v222 
            #endif
#else
            let v223 : (System.DateTime -> int64) = _.Ticks
            let v224 : int64 = v223 v200
            let _run_target_args'_v208 = v224 
            #endif
            let v225 : int64 = _run_target_args'_v208 
            let v246 : int64 = v225 |> int64 
            let v249 : int64 = v246 - v186
            let v252 : System.TimeSpan = v249 |> System.TimeSpan 
            let v258 : (System.TimeSpan -> int32) = _.Hours
            let v259 : int32 = v258 v252
            let v263 : (System.TimeSpan -> int32) = _.Minutes
            let v264 : int32 = v263 v252
            let v268 : (System.TimeSpan -> int32) = _.Seconds
            let v269 : int32 = v268 v252
            let v273 : (System.TimeSpan -> int32) = _.Milliseconds
            let v274 : int32 = v273 v252
            let v278 : System.DateTime = System.DateTime (1, 1, 1, v259, v264, v269, v274)
            v278
    let v302 : string = method12()
    let v306 : bool = v302 = ""
    let v308 : string =
        if v306 then
            let v307 : string = "M-d-y hh:mm:ss tt"
            v307
        else
            v302
    let v309 : (string -> string) = v300.ToString
    let v310 : string = v309 v308
    let _run_target_args'_v165 = v310 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v326 : (int64 -> US4) = method11()
    let v327 : US4 option = v5 |> Option.map v326 
    let v340 : US4 = US4_1
    let v341 : US4 = v327 |> Option.defaultValue v340 
    let v459 : System.DateTime =
        match v341 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v442 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v443 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v443 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v444 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v444 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v446 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v442 = v446 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v449 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v449 
            #endif
#if FABLE_COMPILER_PYTHON
            let v450 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v450 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v451 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v451 
            #endif
#else
            let v452 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v452 
            #endif
            let v453 : System.DateTime = _run_target_args'_v442 
            v453
        | US4_0(v345) -> (* Some *)
            (* run_target_args'
            let v348 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v349 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v349 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v350 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v350 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v352 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v348 = v352 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v355 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v355 
            #endif
#if FABLE_COMPILER_PYTHON
            let v356 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v356 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v357 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v357 
            #endif
#else
            let v358 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v358 
            #endif
            let v359 : System.DateTime = _run_target_args'_v348 
            (* run_target_args'
            let v367 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v368 : (System.DateTime -> int64) = _.Ticks
            let v369 : int64 = v368 v359
            let _run_target_args'_v367 = v369 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v370 : (System.DateTime -> int64) = _.Ticks
            let v371 : int64 = v370 v359
            let _run_target_args'_v367 = v371 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v373 : int64 = null |> unbox<int64>
            let _run_target_args'_v367 = v373 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v376 : (System.DateTime -> int64) = _.Ticks
            let v377 : int64 = v376 v359
            let _run_target_args'_v367 = v377 
            #endif
#if FABLE_COMPILER_PYTHON
            let v378 : (System.DateTime -> int64) = _.Ticks
            let v379 : int64 = v378 v359
            let _run_target_args'_v367 = v379 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v380 : (System.DateTime -> int64) = _.Ticks
            let v381 : int64 = v380 v359
            let _run_target_args'_v367 = v381 
            #endif
#else
            let v382 : (System.DateTime -> int64) = _.Ticks
            let v383 : int64 = v382 v359
            let _run_target_args'_v367 = v383 
            #endif
            let v384 : int64 = _run_target_args'_v367 
            let v405 : int64 = v384 |> int64 
            let v408 : int64 = v405 - v345
            let v411 : System.TimeSpan = v408 |> System.TimeSpan 
            let v417 : (System.TimeSpan -> int32) = _.Hours
            let v418 : int32 = v417 v411
            let v422 : (System.TimeSpan -> int32) = _.Minutes
            let v423 : int32 = v422 v411
            let v427 : (System.TimeSpan -> int32) = _.Seconds
            let v428 : int32 = v427 v411
            let v432 : (System.TimeSpan -> int32) = _.Milliseconds
            let v433 : int32 = v432 v411
            let v437 : System.DateTime = System.DateTime (1, 1, 1, v418, v423, v428, v433)
            v437
    let v461 : string = method12()
    let v465 : bool = v461 = ""
    let v467 : string =
        if v465 then
            let v466 : string = "M-d-y hh:mm:ss tt"
            v466
        else
            v461
    let v468 : (string -> string) = v459.ToString
    let v469 : string = v468 v467
    let _run_target_args'_v165 = v469 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v484 : string = $"near_sdk::env::block_timestamp()"
    let v485 : uint64 = Fable.Core.RustInterop.emitRustExpr () v484 
    let v487 : (int64 -> US4) = method11()
    let v488 : US4 option = v5 |> Option.map v487 
    let v501 : US4 = US4_1
    let v502 : US4 = v488 |> Option.defaultValue v501 
    let v514 : uint64 =
        match v502 with
        | US4_1 -> (* None *)
            v485
        | US4_0(v506) -> (* Some *)
            let v508 : (int64 -> uint64) = uint64
            let v509 : uint64 = v508 v506
            let v512 : uint64 = v485 - v509
            v512
    let v515 : uint64 = v514 / 1000000000UL
    let v516 : uint64 = v515 % 60UL
    let v517 : uint64 = v515 / 60UL
    let v518 : uint64 = v517 % 60UL
    let v519 : uint64 = v515 / 3600UL
    let v520 : uint64 = v519 % 24UL
    let v521 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v522 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v520, v518, v516) v521 
    let v523 : string = "fable_library_rust::String_::fromString($0)"
    let v524 : string = Fable.Core.RustInterop.emitRustExpr v522 v523 
    let _run_target_args'_v165 = v524 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v526 : (int64 -> US4) = method11()
    let v527 : US4 option = v5 |> Option.map v526 
    let v540 : US4 = US4_1
    let v541 : US4 = v527 |> Option.defaultValue v540 
    let v659 : System.DateTime =
        match v541 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v642 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v643 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v643 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v644 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v644 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v646 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v642 = v646 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v649 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v649 
            #endif
#if FABLE_COMPILER_PYTHON
            let v650 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v650 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v651 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v651 
            #endif
#else
            let v652 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v652 
            #endif
            let v653 : System.DateTime = _run_target_args'_v642 
            v653
        | US4_0(v545) -> (* Some *)
            (* run_target_args'
            let v548 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v549 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v549 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v550 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v550 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v552 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v548 = v552 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v555 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v555 
            #endif
#if FABLE_COMPILER_PYTHON
            let v556 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v556 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v557 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v557 
            #endif
#else
            let v558 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v558 
            #endif
            let v559 : System.DateTime = _run_target_args'_v548 
            (* run_target_args'
            let v567 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v568 : (System.DateTime -> int64) = _.Ticks
            let v569 : int64 = v568 v559
            let _run_target_args'_v567 = v569 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v570 : (System.DateTime -> int64) = _.Ticks
            let v571 : int64 = v570 v559
            let _run_target_args'_v567 = v571 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v573 : int64 = null |> unbox<int64>
            let _run_target_args'_v567 = v573 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v576 : (System.DateTime -> int64) = _.Ticks
            let v577 : int64 = v576 v559
            let _run_target_args'_v567 = v577 
            #endif
#if FABLE_COMPILER_PYTHON
            let v578 : (System.DateTime -> int64) = _.Ticks
            let v579 : int64 = v578 v559
            let _run_target_args'_v567 = v579 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v580 : (System.DateTime -> int64) = _.Ticks
            let v581 : int64 = v580 v559
            let _run_target_args'_v567 = v581 
            #endif
#else
            let v582 : (System.DateTime -> int64) = _.Ticks
            let v583 : int64 = v582 v559
            let _run_target_args'_v567 = v583 
            #endif
            let v584 : int64 = _run_target_args'_v567 
            let v605 : int64 = v584 |> int64 
            let v608 : int64 = v605 - v545
            let v611 : System.TimeSpan = v608 |> System.TimeSpan 
            let v617 : (System.TimeSpan -> int32) = _.Hours
            let v618 : int32 = v617 v611
            let v622 : (System.TimeSpan -> int32) = _.Minutes
            let v623 : int32 = v622 v611
            let v627 : (System.TimeSpan -> int32) = _.Seconds
            let v628 : int32 = v627 v611
            let v632 : (System.TimeSpan -> int32) = _.Milliseconds
            let v633 : int32 = v632 v611
            let v637 : System.DateTime = System.DateTime (1, 1, 1, v618, v623, v628, v633)
            v637
    let v661 : string = method13()
    let v665 : bool = v661 = ""
    let v667 : string =
        if v665 then
            let v666 : string = "M-d-y hh:mm:ss tt"
            v666
        else
            v661
    let v668 : (string -> string) = v659.ToString
    let v669 : string = v668 v667
    let _run_target_args'_v165 = v669 
    #endif
#if FABLE_COMPILER_PYTHON
    let v685 : (int64 -> US4) = method11()
    let v686 : US4 option = v5 |> Option.map v685 
    let v699 : US4 = US4_1
    let v700 : US4 = v686 |> Option.defaultValue v699 
    let v818 : System.DateTime =
        match v700 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v801 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v802 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v802 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v803 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v803 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v805 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v801 = v805 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v808 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v808 
            #endif
#if FABLE_COMPILER_PYTHON
            let v809 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v809 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v810 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v810 
            #endif
#else
            let v811 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v811 
            #endif
            let v812 : System.DateTime = _run_target_args'_v801 
            v812
        | US4_0(v704) -> (* Some *)
            (* run_target_args'
            let v707 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v708 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v708 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v709 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v709 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v711 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v707 = v711 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v714 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v714 
            #endif
#if FABLE_COMPILER_PYTHON
            let v715 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v715 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v716 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v716 
            #endif
#else
            let v717 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v717 
            #endif
            let v718 : System.DateTime = _run_target_args'_v707 
            (* run_target_args'
            let v726 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v727 : (System.DateTime -> int64) = _.Ticks
            let v728 : int64 = v727 v718
            let _run_target_args'_v726 = v728 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v729 : (System.DateTime -> int64) = _.Ticks
            let v730 : int64 = v729 v718
            let _run_target_args'_v726 = v730 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v732 : int64 = null |> unbox<int64>
            let _run_target_args'_v726 = v732 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v735 : (System.DateTime -> int64) = _.Ticks
            let v736 : int64 = v735 v718
            let _run_target_args'_v726 = v736 
            #endif
#if FABLE_COMPILER_PYTHON
            let v737 : (System.DateTime -> int64) = _.Ticks
            let v738 : int64 = v737 v718
            let _run_target_args'_v726 = v738 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v739 : (System.DateTime -> int64) = _.Ticks
            let v740 : int64 = v739 v718
            let _run_target_args'_v726 = v740 
            #endif
#else
            let v741 : (System.DateTime -> int64) = _.Ticks
            let v742 : int64 = v741 v718
            let _run_target_args'_v726 = v742 
            #endif
            let v743 : int64 = _run_target_args'_v726 
            let v764 : int64 = v743 |> int64 
            let v767 : int64 = v764 - v704
            let v770 : System.TimeSpan = v767 |> System.TimeSpan 
            let v776 : (System.TimeSpan -> int32) = _.Hours
            let v777 : int32 = v776 v770
            let v781 : (System.TimeSpan -> int32) = _.Minutes
            let v782 : int32 = v781 v770
            let v786 : (System.TimeSpan -> int32) = _.Seconds
            let v787 : int32 = v786 v770
            let v791 : (System.TimeSpan -> int32) = _.Milliseconds
            let v792 : int32 = v791 v770
            let v796 : System.DateTime = System.DateTime (1, 1, 1, v777, v782, v787, v792)
            v796
    let v820 : string = method13()
    let v824 : bool = v820 = ""
    let v826 : string =
        if v824 then
            let v825 : string = "M-d-y hh:mm:ss tt"
            v825
        else
            v820
    let v827 : (string -> string) = v818.ToString
    let v828 : string = v827 v826
    let _run_target_args'_v165 = v828 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v844 : (int64 -> US4) = method11()
    let v845 : US4 option = v5 |> Option.map v844 
    let v858 : US4 = US4_1
    let v859 : US4 = v845 |> Option.defaultValue v858 
    let v977 : System.DateTime =
        match v859 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v960 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v961 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v961 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v962 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v962 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v964 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v960 = v964 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v967 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v967 
            #endif
#if FABLE_COMPILER_PYTHON
            let v968 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v968 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v969 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v969 
            #endif
#else
            let v970 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v970 
            #endif
            let v971 : System.DateTime = _run_target_args'_v960 
            v971
        | US4_0(v863) -> (* Some *)
            (* run_target_args'
            let v866 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v867 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v867 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v868 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v868 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v870 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v866 = v870 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v873 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v873 
            #endif
#if FABLE_COMPILER_PYTHON
            let v874 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v874 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v875 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v875 
            #endif
#else
            let v876 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v876 
            #endif
            let v877 : System.DateTime = _run_target_args'_v866 
            (* run_target_args'
            let v885 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v886 : (System.DateTime -> int64) = _.Ticks
            let v887 : int64 = v886 v877
            let _run_target_args'_v885 = v887 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v888 : (System.DateTime -> int64) = _.Ticks
            let v889 : int64 = v888 v877
            let _run_target_args'_v885 = v889 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v891 : int64 = null |> unbox<int64>
            let _run_target_args'_v885 = v891 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v894 : (System.DateTime -> int64) = _.Ticks
            let v895 : int64 = v894 v877
            let _run_target_args'_v885 = v895 
            #endif
#if FABLE_COMPILER_PYTHON
            let v896 : (System.DateTime -> int64) = _.Ticks
            let v897 : int64 = v896 v877
            let _run_target_args'_v885 = v897 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v898 : (System.DateTime -> int64) = _.Ticks
            let v899 : int64 = v898 v877
            let _run_target_args'_v885 = v899 
            #endif
#else
            let v900 : (System.DateTime -> int64) = _.Ticks
            let v901 : int64 = v900 v877
            let _run_target_args'_v885 = v901 
            #endif
            let v902 : int64 = _run_target_args'_v885 
            let v923 : int64 = v902 |> int64 
            let v926 : int64 = v923 - v863
            let v929 : System.TimeSpan = v926 |> System.TimeSpan 
            let v935 : (System.TimeSpan -> int32) = _.Hours
            let v936 : int32 = v935 v929
            let v940 : (System.TimeSpan -> int32) = _.Minutes
            let v941 : int32 = v940 v929
            let v945 : (System.TimeSpan -> int32) = _.Seconds
            let v946 : int32 = v945 v929
            let v950 : (System.TimeSpan -> int32) = _.Milliseconds
            let v951 : int32 = v950 v929
            let v955 : System.DateTime = System.DateTime (1, 1, 1, v936, v941, v946, v951)
            v955
    let v979 : string = method13()
    let v983 : bool = v979 = ""
    let v985 : string =
        if v983 then
            let v984 : string = "M-d-y hh:mm:ss tt"
            v984
        else
            v979
    let v986 : (string -> string) = v977.ToString
    let v987 : string = v986 v985
    let _run_target_args'_v165 = v987 
    #endif
#else
    let v1003 : (int64 -> US4) = method11()
    let v1004 : US4 option = v5 |> Option.map v1003 
    let v1017 : US4 = US4_1
    let v1018 : US4 = v1004 |> Option.defaultValue v1017 
    let v1136 : System.DateTime =
        match v1018 with
        | US4_1 -> (* None *)
            (* run_target_args'
            let v1119 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1120 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1120 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1121 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1121 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1123 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1119 = v1123 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1126 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1126 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1127 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1127 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1128 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1128 
            #endif
#else
            let v1129 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1129 
            #endif
            let v1130 : System.DateTime = _run_target_args'_v1119 
            v1130
        | US4_0(v1022) -> (* Some *)
            (* run_target_args'
            let v1025 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1026 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1026 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1027 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1027 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1029 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1025 = v1029 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1032 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1032 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1033 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1033 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1034 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1034 
            #endif
#else
            let v1035 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1035 
            #endif
            let v1036 : System.DateTime = _run_target_args'_v1025 
            (* run_target_args'
            let v1044 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1045 : (System.DateTime -> int64) = _.Ticks
            let v1046 : int64 = v1045 v1036
            let _run_target_args'_v1044 = v1046 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1047 : (System.DateTime -> int64) = _.Ticks
            let v1048 : int64 = v1047 v1036
            let _run_target_args'_v1044 = v1048 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1050 : int64 = null |> unbox<int64>
            let _run_target_args'_v1044 = v1050 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1053 : (System.DateTime -> int64) = _.Ticks
            let v1054 : int64 = v1053 v1036
            let _run_target_args'_v1044 = v1054 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1055 : (System.DateTime -> int64) = _.Ticks
            let v1056 : int64 = v1055 v1036
            let _run_target_args'_v1044 = v1056 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1057 : (System.DateTime -> int64) = _.Ticks
            let v1058 : int64 = v1057 v1036
            let _run_target_args'_v1044 = v1058 
            #endif
#else
            let v1059 : (System.DateTime -> int64) = _.Ticks
            let v1060 : int64 = v1059 v1036
            let _run_target_args'_v1044 = v1060 
            #endif
            let v1061 : int64 = _run_target_args'_v1044 
            let v1082 : int64 = v1061 |> int64 
            let v1085 : int64 = v1082 - v1022
            let v1088 : System.TimeSpan = v1085 |> System.TimeSpan 
            let v1094 : (System.TimeSpan -> int32) = _.Hours
            let v1095 : int32 = v1094 v1088
            let v1099 : (System.TimeSpan -> int32) = _.Minutes
            let v1100 : int32 = v1099 v1088
            let v1104 : (System.TimeSpan -> int32) = _.Seconds
            let v1105 : int32 = v1104 v1088
            let v1109 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1110 : int32 = v1109 v1088
            let v1114 : System.DateTime = System.DateTime (1, 1, 1, v1095, v1100, v1105, v1110)
            v1114
    let v1138 : string = method13()
    let v1142 : bool = v1138 = ""
    let v1144 : string =
        if v1142 then
            let v1143 : string = "M-d-y hh:mm:ss tt"
            v1143
        else
            v1138
    let v1145 : (string -> string) = v1136.ToString
    let v1146 : string = v1145 v1144
    let _run_target_args'_v165 = v1146 
    #endif
    let v1161 : string = _run_target_args'_v165 
    v1161
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
    
    
    
    
    
    let v1 : string = "Verbose"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method15(v6)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "inline_colorization::color_bright_black"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v13 
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
    let v31 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v31 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v35 
    #endif
#else
    let v39 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v39 
    #endif
    let v42 : Ref<Str> = _run_target_args'_v19 
    let v48 : string = "inline_colorization::color_reset"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    let v50 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v14, v42, v49) v50 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v51 v52 
    let _run_target_args'_v12 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "inline_colorization::color_bright_black"
    let v55 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v54 
    (* run_target_args'
    let v60 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v61 : string = "&*$0"
    let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v61 
    let _run_target_args'_v60 = v62 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v63 : string = "&*$0"
    let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v63 
    let _run_target_args'_v60 = v64 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v65 : string = "&*$0"
    let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v65 
    let _run_target_args'_v60 = v66 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v68 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v68 
    #endif
#if FABLE_COMPILER_PYTHON
    let v72 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v72 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v76 
    #endif
#else
    let v80 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v80 
    #endif
    let v83 : Ref<Str> = _run_target_args'_v60 
    let v89 : string = "inline_colorization::color_reset"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    let v91 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v55, v83, v90) v91 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v12 = v94 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : string = "inline_colorization::color_bright_black"
    let v96 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v95 
    (* run_target_args'
    let v101 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v102 : string = "&*$0"
    let v103 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v102 
    let _run_target_args'_v101 = v103 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v104 : string = "&*$0"
    let v105 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v104 
    let _run_target_args'_v101 = v105 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v106 : string = "&*$0"
    let v107 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v106 
    let _run_target_args'_v101 = v107 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v109 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v109 
    #endif
#if FABLE_COMPILER_PYTHON
    let v113 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v113 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v117 
    #endif
#else
    let v121 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v121 
    #endif
    let v124 : Ref<Str> = _run_target_args'_v101 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v96, v124, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v12 = v135 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v136 : string = "\u001b[90m"
    let v137 : string = method17()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[90m"
    let v141 : string = method17()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[90m"
    let v145 : string = method17()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[90m"
    let v149 : string = method17()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method19 (v0 : (string [])) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure8(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "args"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure8(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure8(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    let v34 : string = $"%A{v0}"
    let v38 : string = $"{v34}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v2, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v47 : string = " }"
    let v48 : string = $"{v47}"
    let v51 : unit = ()
    let v52 : (unit -> unit) = closure8(v2, v48)
    let v53 : unit = (fun () -> v52 (); v51) ()
    let v56 : string = v2.l0
    v56
and method20 (v0 : string) : string =
    let v1 : char list = []
    let v4 : (char list -> (char [])) = List.toArray
    let v5 : (char []) = v4 v1
    let v8 : string = v0.TrimStart v5 
    let v37 : char list = []
    let v39 : char list = '/' :: v37 
    let v43 : char list = ' ' :: v39 
    let v48 : (char list -> (char [])) = List.toArray
    let v49 : (char []) = v48 v43
    let v52 : string = v8.TrimEnd v49 
    v52
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
    let v43 : char list = []
    let v45 : char list = '\\' :: v43 
    let v50 : (char list -> (char [])) = List.toArray
    let v51 : (char []) = v50 v45
    let v54 : string = v14.TrimEnd v51 
    v54
and method23 () : (std_string_String -> string) =
    closure12()
and method25 () : string =
    let v0 : string = "wasm"
    v0
and method27 (v0 : string) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure8(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "wasm_path"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure8(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure8(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    let v34 : string = $"{v0}"
    let v37 : unit = ()
    let v38 : (unit -> unit) = closure8(v2, v34)
    let v39 : unit = (fun () -> v38 (); v37) ()
    let v43 : string = " }"
    let v44 : string = $"{v43}"
    let v47 : unit = ()
    let v48 : (unit -> unit) = closure8(v2, v44)
    let v49 : unit = (fun () -> v48 (); v47) ()
    let v52 : string = v2.l0
    v52
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
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure8(v4, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v16 : string = "retry"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure8(v4, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v26 : string = " = "
    let v27 : string = $"{v26}"
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure8(v4, v27)
    let v32 : unit = (fun () -> v31 (); v30) ()
    let v36 : string = $"{v0}"
    let v39 : unit = ()
    let v40 : (unit -> unit) = closure8(v4, v36)
    let v41 : unit = (fun () -> v40 (); v39) ()
    let v45 : string = "; "
    let v46 : string = $"{v45}"
    let v49 : unit = ()
    let v50 : (unit -> unit) = closure8(v4, v46)
    let v51 : unit = (fun () -> v50 (); v49) ()
    let v55 : string = "worker"
    let v56 : string = $"{v55}"
    let v59 : unit = ()
    let v60 : (unit -> unit) = closure8(v4, v56)
    let v61 : unit = (fun () -> v60 (); v59) ()
    let v65 : string = $"{v26}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure8(v4, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    (* run_target_args'
    let v77 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v78 : string = "format!(\"{:#?}\", $0)"
    let v79 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v78 
    let v80 : string = "fable_library_rust::String_::fromString($0)"
    let v81 : string = Fable.Core.RustInterop.emitRustExpr v79 v80 
    let _run_target_args'_v77 = v81 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v82 : string = "format!(\"{:#?}\", $0)"
    let v83 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v82 
    let v84 : string = "fable_library_rust::String_::fromString($0)"
    let v85 : string = Fable.Core.RustInterop.emitRustExpr v83 v84 
    let _run_target_args'_v77 = v85 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v86 : string = "format!(\"{:#?}\", $0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v86 
    let v88 : string = "fable_library_rust::String_::fromString($0)"
    let v89 : string = Fable.Core.RustInterop.emitRustExpr v87 v88 
    let _run_target_args'_v77 = v89 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v91 : string = $"%A{v1}"
    let _run_target_args'_v77 = v91 
    #endif
#if FABLE_COMPILER_PYTHON
    let v95 : string = $"%A{v1}"
    let _run_target_args'_v77 = v95 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v99 : string = $"%A{v1}"
    let _run_target_args'_v77 = v99 
    #endif
#else
    let v103 : string = $"%A{v1}"
    let _run_target_args'_v77 = v103 
    #endif
    let v106 : string = _run_target_args'_v77 
    let v113 : string = $"{v106}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure8(v4, v113)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v122 : string = $"{v45}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure8(v4, v122)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v131 : string = "contract"
    let v132 : string = $"{v131}"
    let v135 : unit = ()
    let v136 : (unit -> unit) = closure8(v4, v132)
    let v137 : unit = (fun () -> v136 (); v135) ()
    let v141 : string = $"{v26}"
    let v144 : unit = ()
    let v145 : (unit -> unit) = closure8(v4, v141)
    let v146 : unit = (fun () -> v145 (); v144) ()
    (* run_target_args'
    let v153 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v154 : string = "format!(\"{:#?}\", $0)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v154 
    let v156 : string = "fable_library_rust::String_::fromString($0)"
    let v157 : string = Fable.Core.RustInterop.emitRustExpr v155 v156 
    let _run_target_args'_v153 = v157 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v158 : string = "format!(\"{:#?}\", $0)"
    let v159 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v158 
    let v160 : string = "fable_library_rust::String_::fromString($0)"
    let v161 : string = Fable.Core.RustInterop.emitRustExpr v159 v160 
    let _run_target_args'_v153 = v161 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v162 : string = "format!(\"{:#?}\", $0)"
    let v163 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v162 
    let v164 : string = "fable_library_rust::String_::fromString($0)"
    let v165 : string = Fable.Core.RustInterop.emitRustExpr v163 v164 
    let _run_target_args'_v153 = v165 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v167 : string = $"%A{v2}"
    let _run_target_args'_v153 = v167 
    #endif
#if FABLE_COMPILER_PYTHON
    let v171 : string = $"%A{v2}"
    let _run_target_args'_v153 = v171 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v175 : string = $"%A{v2}"
    let _run_target_args'_v153 = v175 
    #endif
#else
    let v179 : string = $"%A{v2}"
    let _run_target_args'_v153 = v179 
    #endif
    let v182 : string = _run_target_args'_v153 
    let v189 : string = $"{v182}"
    let v192 : unit = ()
    let v193 : (unit -> unit) = closure8(v4, v189)
    let v194 : unit = (fun () -> v193 (); v192) ()
    let v198 : string = " }"
    let v199 : string = $"{v198}"
    let v202 : unit = ()
    let v203 : (unit -> unit) = closure8(v4, v199)
    let v204 : unit = (fun () -> v203 (); v202) ()
    let v207 : string = v4.l0
    v207
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
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "retry"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure8(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure8(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure8(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure8(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "result"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure8(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure8(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "format!(\"{:#?}\", $0)"
    let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v77 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v81 : string = "format!(\"{:#?}\", $0)"
    let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v81 
    let v83 : string = "fable_library_rust::String_::fromString($0)"
    let v84 : string = Fable.Core.RustInterop.emitRustExpr v82 v83 
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v85 : string = "format!(\"{:#?}\", $0)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v76 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : string = $"%A{v1}"
    let _run_target_args'_v76 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : string = $"%A{v1}"
    let _run_target_args'_v76 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : string = $"%A{v1}"
    let _run_target_args'_v76 = v98 
    #endif
#else
    let v102 : string = $"%A{v1}"
    let _run_target_args'_v76 = v102 
    #endif
    let v105 : string = _run_target_args'_v76 
    let v112 : string = $"{v105}"
    let v115 : unit = ()
    let v116 : (unit -> unit) = closure8(v3, v112)
    let v117 : unit = (fun () -> v116 (); v115) ()
    let v121 : string = " }"
    let v122 : string = $"{v121}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure8(v3, v122)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v130 : string = v3.l0
    v130
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
    
    
    
    
    
    let v1 : string = "Info"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method15(v6)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "inline_colorization::color_bright_green"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v13 
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
    let v31 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v31 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v35 
    #endif
#else
    let v39 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v39 
    #endif
    let v42 : Ref<Str> = _run_target_args'_v19 
    let v48 : string = "inline_colorization::color_reset"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    let v50 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v14, v42, v49) v50 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v51 v52 
    let _run_target_args'_v12 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "inline_colorization::color_bright_green"
    let v55 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v54 
    (* run_target_args'
    let v60 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v61 : string = "&*$0"
    let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v61 
    let _run_target_args'_v60 = v62 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v63 : string = "&*$0"
    let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v63 
    let _run_target_args'_v60 = v64 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v65 : string = "&*$0"
    let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v65 
    let _run_target_args'_v60 = v66 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v68 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v68 
    #endif
#if FABLE_COMPILER_PYTHON
    let v72 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v72 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v76 
    #endif
#else
    let v80 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v80 
    #endif
    let v83 : Ref<Str> = _run_target_args'_v60 
    let v89 : string = "inline_colorization::color_reset"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    let v91 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v55, v83, v90) v91 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v12 = v94 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : string = "inline_colorization::color_bright_green"
    let v96 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v95 
    (* run_target_args'
    let v101 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v102 : string = "&*$0"
    let v103 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v102 
    let _run_target_args'_v101 = v103 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v104 : string = "&*$0"
    let v105 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v104 
    let _run_target_args'_v101 = v105 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v106 : string = "&*$0"
    let v107 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v106 
    let _run_target_args'_v101 = v107 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v109 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v109 
    #endif
#if FABLE_COMPILER_PYTHON
    let v113 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v113 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v117 
    #endif
#else
    let v121 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v121 
    #endif
    let v124 : Ref<Str> = _run_target_args'_v101 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v96, v124, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v12 = v135 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v136 : string = "\u001b[92m"
    let v137 : string = method17()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[92m"
    let v141 : string = method17()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[92m"
    let v145 : string = method17()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[92m"
    let v149 : string = method17()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method37 (v0 : uint8, v1 : float, v2 : uint64) : string =
    let v3 : string = method16()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure8(v4, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v16 : string = "retry"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure8(v4, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v26 : string = " = "
    let v27 : string = $"{v26}"
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure8(v4, v27)
    let v32 : unit = (fun () -> v31 (); v30) ()
    let v36 : string = $"{v0}"
    let v39 : unit = ()
    let v40 : (unit -> unit) = closure8(v4, v36)
    let v41 : unit = (fun () -> v40 (); v39) ()
    let v45 : string = "; "
    let v46 : string = $"{v45}"
    let v49 : unit = ()
    let v50 : (unit -> unit) = closure8(v4, v46)
    let v51 : unit = (fun () -> v50 (); v49) ()
    let v55 : string = "total_gas_burnt_usd"
    let v56 : string = $"{v55}"
    let v59 : unit = ()
    let v60 : (unit -> unit) = closure8(v4, v56)
    let v61 : unit = (fun () -> v60 (); v59) ()
    let v65 : string = $"{v26}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure8(v4, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v74 : string = $"%+.6f{v1}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure8(v4, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v83 : string = $"{v45}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure8(v4, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v92 : string = "total_gas_burnt"
    let v93 : string = $"{v92}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure8(v4, v93)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v102 : string = $"{v26}"
    let v105 : unit = ()
    let v106 : (unit -> unit) = closure8(v4, v102)
    let v107 : unit = (fun () -> v106 (); v105) ()
    let v111 : string = $"{v2}"
    let v114 : unit = ()
    let v115 : (unit -> unit) = closure8(v4, v111)
    let v116 : unit = (fun () -> v115 (); v114) ()
    let v120 : string = " }"
    let v121 : string = $"{v120}"
    let v124 : unit = ()
    let v125 : (unit -> unit) = closure8(v4, v121)
    let v126 : unit = (fun () -> v125 (); v124) ()
    let v129 : string = v4.l0
    v129
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
    let v8 : string = "{ "
    let v9 : string = $"{v8}"
    let v12 : unit = ()
    let v13 : (unit -> unit) = closure8(v6, v9)
    let v14 : unit = (fun () -> v13 (); v12) ()
    let v18 : string = "is_success"
    let v19 : string = $"{v18}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure8(v6, v19)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure8(v6, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v39 : string =
        if v0 then
            let v37 : string = "true"
            v37
        else
            let v38 : string = "false"
            v38
    let v41 : string = $"{v39}"
    let v44 : unit = ()
    let v45 : (unit -> unit) = closure8(v6, v41)
    let v46 : unit = (fun () -> v45 (); v44) ()
    let v50 : string = "; "
    let v51 : string = $"{v50}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure8(v6, v51)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v60 : string = "gas_burnt_usd"
    let v61 : string = $"{v60}"
    let v64 : unit = ()
    let v65 : (unit -> unit) = closure8(v6, v61)
    let v66 : unit = (fun () -> v65 (); v64) ()
    let v70 : string = $"{v28}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure8(v6, v70)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v79 : string = $"%+.6f{v1}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure8(v6, v79)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v88 : string = $"{v50}"
    let v91 : unit = ()
    let v92 : (unit -> unit) = closure8(v6, v88)
    let v93 : unit = (fun () -> v92 (); v91) ()
    let v97 : string = "tokens_burnt_usd"
    let v98 : string = $"{v97}"
    let v101 : unit = ()
    let v102 : (unit -> unit) = closure8(v6, v98)
    let v103 : unit = (fun () -> v102 (); v101) ()
    let v107 : string = $"{v28}"
    let v110 : unit = ()
    let v111 : (unit -> unit) = closure8(v6, v107)
    let v112 : unit = (fun () -> v111 (); v110) ()
    let v116 : string = $"%+.6f{v2}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure8(v6, v116)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v125 : string = $"{v50}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure8(v6, v125)
    let v130 : unit = (fun () -> v129 (); v128) ()
    let v134 : string = "gas_burnt"
    let v135 : string = $"{v134}"
    let v138 : unit = ()
    let v139 : (unit -> unit) = closure8(v6, v135)
    let v140 : unit = (fun () -> v139 (); v138) ()
    let v144 : string = $"{v28}"
    let v147 : unit = ()
    let v148 : (unit -> unit) = closure8(v6, v144)
    let v149 : unit = (fun () -> v148 (); v147) ()
    let v153 : string = $"{v3}"
    let v156 : unit = ()
    let v157 : (unit -> unit) = closure8(v6, v153)
    let v158 : unit = (fun () -> v157 (); v156) ()
    let v162 : string = $"{v50}"
    let v165 : unit = ()
    let v166 : (unit -> unit) = closure8(v6, v162)
    let v167 : unit = (fun () -> v166 (); v165) ()
    let v171 : string = "tokens_burnt"
    let v172 : string = $"{v171}"
    let v175 : unit = ()
    let v176 : (unit -> unit) = closure8(v6, v172)
    let v177 : unit = (fun () -> v176 (); v175) ()
    let v181 : string = $"{v28}"
    let v184 : unit = ()
    let v185 : (unit -> unit) = closure8(v6, v181)
    let v186 : unit = (fun () -> v185 (); v184) ()
    (* run_target_args'
    let v193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v194 : string = "format!(\"{:#?}\", $0)"
    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v194 
    let v196 : string = "fable_library_rust::String_::fromString($0)"
    let v197 : string = Fable.Core.RustInterop.emitRustExpr v195 v196 
    let _run_target_args'_v193 = v197 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v198 : string = "format!(\"{:#?}\", $0)"
    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v198 
    let v200 : string = "fable_library_rust::String_::fromString($0)"
    let v201 : string = Fable.Core.RustInterop.emitRustExpr v199 v200 
    let _run_target_args'_v193 = v201 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v202 : string = "format!(\"{:#?}\", $0)"
    let v203 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v202 
    let v204 : string = "fable_library_rust::String_::fromString($0)"
    let v205 : string = Fable.Core.RustInterop.emitRustExpr v203 v204 
    let _run_target_args'_v193 = v205 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v207 : string = $"%A{v4}"
    let _run_target_args'_v193 = v207 
    #endif
#if FABLE_COMPILER_PYTHON
    let v211 : string = $"%A{v4}"
    let _run_target_args'_v193 = v211 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v215 : string = $"%A{v4}"
    let _run_target_args'_v193 = v215 
    #endif
#else
    let v219 : string = $"%A{v4}"
    let _run_target_args'_v193 = v219 
    #endif
    let v222 : string = _run_target_args'_v193 
    let v229 : string = $"{v222}"
    let v232 : unit = ()
    let v233 : (unit -> unit) = closure8(v6, v229)
    let v234 : unit = (fun () -> v233 (); v232) ()
    let v238 : string = " }"
    let v239 : string = $"{v238}"
    let v242 : unit = ()
    let v243 : (unit -> unit) = closure8(v6, v239)
    let v244 : unit = (fun () -> v243 (); v242) ()
    let v247 : string = v6.l0
    v247
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
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure8(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "result2"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure8(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure8(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    (* run_target_args'
    let v37 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v38 : string = "format!(\"{:#?}\", $0)"
    let v39 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v38 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v39 v40 
    let _run_target_args'_v37 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "format!(\"{:#?}\", $0)"
    let v43 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v42 
    let v44 : string = "fable_library_rust::String_::fromString($0)"
    let v45 : string = Fable.Core.RustInterop.emitRustExpr v43 v44 
    let _run_target_args'_v37 = v45 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v46 : string = "format!(\"{:#?}\", $0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v46 
    let v48 : string = "fable_library_rust::String_::fromString($0)"
    let v49 : string = Fable.Core.RustInterop.emitRustExpr v47 v48 
    let _run_target_args'_v37 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v51 : string = $"%A{v0}"
    let _run_target_args'_v37 = v51 
    #endif
#if FABLE_COMPILER_PYTHON
    let v55 : string = $"%A{v0}"
    let _run_target_args'_v37 = v55 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v59 : string = $"%A{v0}"
    let _run_target_args'_v37 = v59 
    #endif
#else
    let v63 : string = $"%A{v0}"
    let _run_target_args'_v37 = v63 
    #endif
    let v66 : string = _run_target_args'_v37 
    let v73 : string = $"{v66}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure8(v2, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure8(v2, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v2.l0
    v91
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
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "receipt_failures_len"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure8(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure8(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure8(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure8(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "receipt_failures"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure8(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure8(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "format!(\"{:#?}\", $0)"
    let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v77 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v81 : string = "format!(\"{:#?}\", $0)"
    let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v81 
    let v83 : string = "fable_library_rust::String_::fromString($0)"
    let v84 : string = Fable.Core.RustInterop.emitRustExpr v82 v83 
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v85 : string = "format!(\"{:#?}\", $0)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v76 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : string = $"%A{v1}"
    let _run_target_args'_v76 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : string = $"%A{v1}"
    let _run_target_args'_v76 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : string = $"%A{v1}"
    let _run_target_args'_v76 = v98 
    #endif
#else
    let v102 : string = $"%A{v1}"
    let _run_target_args'_v76 = v102 
    #endif
    let v105 : string = _run_target_args'_v76 
    let v112 : string = $"{v105}"
    let v115 : unit = ()
    let v116 : (unit -> unit) = closure8(v3, v112)
    let v117 : unit = (fun () -> v116 (); v115) ()
    let v121 : string = " }"
    let v122 : string = $"{v121}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure8(v3, v122)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v130 : string = v3.l0
    v130
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
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "receipt_outcomes_len"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure8(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure8(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure8(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure8(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "receipt_outcomes"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure8(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure8(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "format!(\"{:#?}\", $0)"
    let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v77 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v81 : string = "format!(\"{:#?}\", $0)"
    let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v81 
    let v83 : string = "fable_library_rust::String_::fromString($0)"
    let v84 : string = Fable.Core.RustInterop.emitRustExpr v82 v83 
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v85 : string = "format!(\"{:#?}\", $0)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v76 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : string = $"%A{v1}"
    let _run_target_args'_v76 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : string = $"%A{v1}"
    let _run_target_args'_v76 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : string = $"%A{v1}"
    let _run_target_args'_v76 = v98 
    #endif
#else
    let v102 : string = $"%A{v1}"
    let _run_target_args'_v76 = v102 
    #endif
    let v105 : string = _run_target_args'_v76 
    let v112 : string = $"{v105}"
    let v115 : unit = ()
    let v116 : (unit -> unit) = closure8(v3, v112)
    let v117 : unit = (fun () -> v116 (); v115) ()
    let v121 : string = " }"
    let v122 : string = $"{v121}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure8(v3, v122)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v130 : string = v3.l0
    v130
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
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure8(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "json"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure8(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure8(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    (* run_target_args'
    let v37 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v38 : string = "format!(\"{:#?}\", $0)"
    let v39 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v38 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v39 v40 
    let _run_target_args'_v37 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "format!(\"{:#?}\", $0)"
    let v43 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v42 
    let v44 : string = "fable_library_rust::String_::fromString($0)"
    let v45 : string = Fable.Core.RustInterop.emitRustExpr v43 v44 
    let _run_target_args'_v37 = v45 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v46 : string = "format!(\"{:#?}\", $0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v46 
    let v48 : string = "fable_library_rust::String_::fromString($0)"
    let v49 : string = Fable.Core.RustInterop.emitRustExpr v47 v48 
    let _run_target_args'_v37 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v51 : string = $"%A{v0}"
    let _run_target_args'_v37 = v51 
    #endif
#if FABLE_COMPILER_PYTHON
    let v55 : string = $"%A{v0}"
    let _run_target_args'_v37 = v55 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v59 : string = $"%A{v0}"
    let _run_target_args'_v37 = v59 
    #endif
#else
    let v63 : string = $"%A{v0}"
    let _run_target_args'_v37 = v63 
    #endif
    let v66 : string = _run_target_args'_v37 
    let v73 : string = $"{v66}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure8(v2, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure8(v2, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v2.l0
    v91
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
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure8(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "borsh"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure8(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure8(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    (* run_target_args'
    let v37 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v38 : string = "format!(\"{:#?}\", $0)"
    let v39 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v38 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v39 v40 
    let _run_target_args'_v37 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "format!(\"{:#?}\", $0)"
    let v43 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v42 
    let v44 : string = "fable_library_rust::String_::fromString($0)"
    let v45 : string = Fable.Core.RustInterop.emitRustExpr v43 v44 
    let _run_target_args'_v37 = v45 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v46 : string = "format!(\"{:#?}\", $0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v46 
    let v48 : string = "fable_library_rust::String_::fromString($0)"
    let v49 : string = Fable.Core.RustInterop.emitRustExpr v47 v48 
    let _run_target_args'_v37 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v51 : string = $"%A{v0}"
    let _run_target_args'_v37 = v51 
    #endif
#if FABLE_COMPILER_PYTHON
    let v55 : string = $"%A{v0}"
    let _run_target_args'_v37 = v55 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v59 : string = $"%A{v0}"
    let _run_target_args'_v37 = v59 
    #endif
#else
    let v63 : string = $"%A{v0}"
    let _run_target_args'_v37 = v63 
    #endif
    let v66 : string = _run_target_args'_v37 
    let v73 : string = $"{v66}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure8(v2, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure8(v2, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v2.l0
    v91
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
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure8(v4, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v16 : string = "receipt_outcomes_len"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure8(v4, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v26 : string = " = "
    let v27 : string = $"{v26}"
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure8(v4, v27)
    let v32 : unit = (fun () -> v31 (); v30) ()
    let v36 : string = $"{v0}"
    let v39 : unit = ()
    let v40 : (unit -> unit) = closure8(v4, v36)
    let v41 : unit = (fun () -> v40 (); v39) ()
    let v45 : string = "; "
    let v46 : string = $"{v45}"
    let v49 : unit = ()
    let v50 : (unit -> unit) = closure8(v4, v46)
    let v51 : unit = (fun () -> v50 (); v49) ()
    let v55 : string = "retry"
    let v56 : string = $"{v55}"
    let v59 : unit = ()
    let v60 : (unit -> unit) = closure8(v4, v56)
    let v61 : unit = (fun () -> v60 (); v59) ()
    let v65 : string = $"{v26}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure8(v4, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v74 : string = $"{v1}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure8(v4, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v83 : string = $"{v45}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure8(v4, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v92 : string = "receipt_failures"
    let v93 : string = $"{v92}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure8(v4, v93)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v102 : string = $"{v26}"
    let v105 : unit = ()
    let v106 : (unit -> unit) = closure8(v4, v102)
    let v107 : unit = (fun () -> v106 (); v105) ()
    (* run_target_args'
    let v114 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v115 : string = "format!(\"{:#?}\", $0)"
    let v116 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v115 
    let v117 : string = "fable_library_rust::String_::fromString($0)"
    let v118 : string = Fable.Core.RustInterop.emitRustExpr v116 v117 
    let _run_target_args'_v114 = v118 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v119 : string = "format!(\"{:#?}\", $0)"
    let v120 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v119 
    let v121 : string = "fable_library_rust::String_::fromString($0)"
    let v122 : string = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let _run_target_args'_v114 = v122 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v123 : string = "format!(\"{:#?}\", $0)"
    let v124 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v123 
    let v125 : string = "fable_library_rust::String_::fromString($0)"
    let v126 : string = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let _run_target_args'_v114 = v126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v128 : string = $"%A{v2}"
    let _run_target_args'_v114 = v128 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : string = $"%A{v2}"
    let _run_target_args'_v114 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : string = $"%A{v2}"
    let _run_target_args'_v114 = v136 
    #endif
#else
    let v140 : string = $"%A{v2}"
    let _run_target_args'_v114 = v140 
    #endif
    let v143 : string = _run_target_args'_v114 
    let v150 : string = $"{v143}"
    let v153 : unit = ()
    let v154 : (unit -> unit) = closure8(v4, v150)
    let v155 : unit = (fun () -> v154 (); v153) ()
    let v159 : string = " }"
    let v160 : string = $"{v159}"
    let v163 : unit = ()
    let v164 : (unit -> unit) = closure8(v4, v160)
    let v165 : unit = (fun () -> v164 (); v163) ()
    let v168 : string = v4.l0
    v168
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
    let v567 : Result<US7, anyhow_Error> =
        if v543 then
            let v544 : US7 = US7_0(v542)
            let v545 : Result<US7, anyhow_Error> = Ok v544 
            v545
        else
            let v546 : bool = v383 > 1
            if v546 then
                let v547 : US7 = US7_1
                let v548 : Result<US7, anyhow_Error> = Ok v547 
                v548
            else
                let v549 : string = "anyhow::anyhow!($0)"
                let v550 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v542 v549 
                (* run_target_args'
                let v552 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v553 : string = "Err($0)"
                let v554 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v550 v553 
                let _run_target_args'_v552 = v554 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v555 : string = "Err($0)"
                let v556 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v550 v555 
                let _run_target_args'_v552 = v556 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v557 : string = "Err($0)"
                let v558 : Result<US7, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v550 v557 
                let _run_target_args'_v552 = v558 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v559 : Result<US7, anyhow_Error> = v550 |> Error
                let _run_target_args'_v552 = v559 
                #endif
#if FABLE_COMPILER_PYTHON
                let v560 : Result<US7, anyhow_Error> = v550 |> Error
                let _run_target_args'_v552 = v560 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v561 : Result<US7, anyhow_Error> = v550 |> Error
                let _run_target_args'_v552 = v561 
                #endif
#else
                let v562 : Result<US7, anyhow_Error> = v550 |> Error
                let _run_target_args'_v552 = v562 
                #endif
                let v563 : Result<US7, anyhow_Error> = _run_target_args'_v552 
                v563
    let v568 : string = ""
    let v569 : string = "}"
    let v570 : string = v568 + v569 
    let x = v567 //
    let v571 : _ = x
    let v572 : unit = ()
    (* run_target_args'
    let v573 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v574 : string = $"true; let _fix_closure_v572 = $0"
    let v575 : bool = Fable.Core.RustInterop.emitRustExpr v571 v574 
    let _run_target_args'_v573 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v576 : string = $"true; let _fix_closure_v572 = $0"
    let v577 : bool = Fable.Core.RustInterop.emitRustExpr v571 v576 
    let _run_target_args'_v573 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v578 : string = $"true; let _fix_closure_v572 = $0"
    let v579 : bool = Fable.Core.RustInterop.emitRustExpr v571 v578 
    let _run_target_args'_v573 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v573 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v573 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v573 = false 
    #endif
#else
    let _run_target_args'_v573 = false 
    #endif
    let v580 : bool = _run_target_args'_v573 
    let v582 : string = $"true; _fix_closure_v572 " + v570 + "); " + v568 + " // rust.fix_closure'"
    let v583 : bool = Fable.Core.RustInterop.emitRustExpr () v582 
    let v584 : string = "__future_init"
    let v585 : _ = Fable.Core.RustInterop.emitRustExpr () v584 
    let v586 : string = "v585"
    let v587 : std_pin_Pin<Box<Dyn<std_future_Future<Result<US7, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v586 
    v587
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
    
    
    
    
    
    let v1 : string = "Warning"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method15(v6)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "inline_colorization::color_yellow"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v13 
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
    let v31 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v31 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v35 
    #endif
#else
    let v39 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v39 
    #endif
    let v42 : Ref<Str> = _run_target_args'_v19 
    let v48 : string = "inline_colorization::color_reset"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    let v50 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v14, v42, v49) v50 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v51 v52 
    let _run_target_args'_v12 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "inline_colorization::color_yellow"
    let v55 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v54 
    (* run_target_args'
    let v60 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v61 : string = "&*$0"
    let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v61 
    let _run_target_args'_v60 = v62 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v63 : string = "&*$0"
    let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v63 
    let _run_target_args'_v60 = v64 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v65 : string = "&*$0"
    let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v65 
    let _run_target_args'_v60 = v66 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v68 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v68 
    #endif
#if FABLE_COMPILER_PYTHON
    let v72 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v72 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v76 
    #endif
#else
    let v80 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v80 
    #endif
    let v83 : Ref<Str> = _run_target_args'_v60 
    let v89 : string = "inline_colorization::color_reset"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    let v91 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v55, v83, v90) v91 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v12 = v94 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : string = "inline_colorization::color_yellow"
    let v96 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v95 
    (* run_target_args'
    let v101 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v102 : string = "&*$0"
    let v103 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v102 
    let _run_target_args'_v101 = v103 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v104 : string = "&*$0"
    let v105 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v104 
    let _run_target_args'_v101 = v105 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v106 : string = "&*$0"
    let v107 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v106 
    let _run_target_args'_v101 = v107 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v109 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v109 
    #endif
#if FABLE_COMPILER_PYTHON
    let v113 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v113 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v117 
    #endif
#else
    let v121 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v121 
    #endif
    let v124 : Ref<Str> = _run_target_args'_v101 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v96, v124, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v12 = v135 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v136 : string = "\u001b[93m"
    let v137 : string = method17()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[93m"
    let v141 : string = method17()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[93m"
    let v145 : string = method17()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[93m"
    let v149 : string = method17()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method58 (v0 : uint8, v1 : std_string_String) : string =
    let v2 : string = method16()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "retry"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure8(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure8(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure8(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure8(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "error"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure8(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure8(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "format!(\"{:#?}\", $0)"
    let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v77 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v81 : string = "format!(\"{:#?}\", $0)"
    let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v81 
    let v83 : string = "fable_library_rust::String_::fromString($0)"
    let v84 : string = Fable.Core.RustInterop.emitRustExpr v82 v83 
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v85 : string = "format!(\"{:#?}\", $0)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v76 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : string = $"%A{v1}"
    let _run_target_args'_v76 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : string = $"%A{v1}"
    let _run_target_args'_v76 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : string = $"%A{v1}"
    let _run_target_args'_v76 = v98 
    #endif
#else
    let v102 : string = $"%A{v1}"
    let _run_target_args'_v76 = v102 
    #endif
    let v105 : string = _run_target_args'_v76 
    let v112 : string = $"{v105}"
    let v115 : unit = ()
    let v116 : (unit -> unit) = closure8(v3, v112)
    let v117 : unit = (fun () -> v116 (); v115) ()
    let v121 : string = " }"
    let v122 : string = $"{v121}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure8(v3, v122)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v130 : string = v3.l0
    v130
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
    
    
    
    
    
    let v1 : string = "Critical"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method15(v6)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "inline_colorization::color_bright_red"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v13 
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
    let v31 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v31 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v35 
    #endif
#else
    let v39 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v39 
    #endif
    let v42 : Ref<Str> = _run_target_args'_v19 
    let v48 : string = "inline_colorization::color_reset"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    let v50 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v14, v42, v49) v50 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v51 v52 
    let _run_target_args'_v12 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "inline_colorization::color_bright_red"
    let v55 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v54 
    (* run_target_args'
    let v60 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v61 : string = "&*$0"
    let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v61 
    let _run_target_args'_v60 = v62 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v63 : string = "&*$0"
    let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v63 
    let _run_target_args'_v60 = v64 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v65 : string = "&*$0"
    let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v65 
    let _run_target_args'_v60 = v66 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v68 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v68 
    #endif
#if FABLE_COMPILER_PYTHON
    let v72 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v72 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v76 
    #endif
#else
    let v80 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v80 
    #endif
    let v83 : Ref<Str> = _run_target_args'_v60 
    let v89 : string = "inline_colorization::color_reset"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    let v91 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v55, v83, v90) v91 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v12 = v94 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : string = "inline_colorization::color_bright_red"
    let v96 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v95 
    (* run_target_args'
    let v101 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v102 : string = "&*$0"
    let v103 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v102 
    let _run_target_args'_v101 = v103 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v104 : string = "&*$0"
    let v105 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v104 
    let _run_target_args'_v101 = v105 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v106 : string = "&*$0"
    let v107 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v106 
    let _run_target_args'_v101 = v107 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v109 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v109 
    #endif
#if FABLE_COMPILER_PYTHON
    let v113 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v113 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v117 
    #endif
#else
    let v121 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v121 
    #endif
    let v124 : Ref<Str> = _run_target_args'_v101 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v96, v124, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v12 = v135 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v136 : string = "\u001b[91m"
    let v137 : string = method17()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[91m"
    let v141 : string = method17()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[91m"
    let v145 : string = method17()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[91m"
    let v149 : string = method17()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method62 (v0 : uint8, v1 : string) : string =
    let v2 : string = method16()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "retry"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure8(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure8(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure8(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure8(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "error"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure8(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure8(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v1}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure8(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure8(v3, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v3.l0
    v91
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
    let v29 : US9 = match v24 with Ok x -> v27 x | Error x -> v28 x
    let v292 : US8 =
        match v29 with
        | US9_1(v145) -> (* Error *)
            let v146 : bool = v1 >= 15uy
            if v146 then
                let v147 : unit = ()
                let v148 : (unit -> unit) = closure30(v1, v145)
                let v149 : unit = (fun () -> v148 (); v147) ()
                let v196 : unit = ()
                let v197 : (unit -> unit) = closure31()
                let v198 : unit = (fun () -> v197 (); v196) ()
                let v201 : string = "true; let __future_init = Box::pin(/*"
                let v202 : bool = Fable.Core.RustInterop.emitRustExpr () v201 
                let v203 : string = "*/ async move { /*"
                let v204 : bool = Fable.Core.RustInterop.emitRustExpr () v203 
                let v205 : string = "*/ ()"
                let v206 : bool = Fable.Core.RustInterop.emitRustExpr () v205 
                let v207 : string = ""
                let v208 : string = "}"
                let v209 : string = v207 + v208 
                let v210 : US7 = US7_1
                let x = struct (v1, v210) //
                let v211 : _ = x
                let v212 : unit = ()
                (* run_target_args'
                let v213 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v214 : string = $"true; let _fix_closure_v212 = $0"
                let v215 : bool = Fable.Core.RustInterop.emitRustExpr v211 v214 
                let _run_target_args'_v213 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v216 : string = $"true; let _fix_closure_v212 = $0"
                let v217 : bool = Fable.Core.RustInterop.emitRustExpr v211 v216 
                let _run_target_args'_v213 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v218 : string = $"true; let _fix_closure_v212 = $0"
                let v219 : bool = Fable.Core.RustInterop.emitRustExpr v211 v218 
                let _run_target_args'_v213 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v213 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v213 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v213 = false 
                #endif
#else
                let _run_target_args'_v213 = false 
                #endif
                let v220 : bool = _run_target_args'_v213 
                let v222 : string = $"true; _fix_closure_v212 " + v209 + "); " + v207 + " // rust.fix_closure'"
                let v223 : bool = Fable.Core.RustInterop.emitRustExpr () v222 
                let v224 : string = "__future_init"
                let v225 : _ = Fable.Core.RustInterop.emitRustExpr () v224 
                let v226 : string = "v225"
                let v227 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v226 
                let v228 : string = "v227.await"
                let struct (v229 : uint8, v230 : US7) = Fable.Core.RustInterop.emitRustExpr () v228 
                US8_0(v229, v230)
            else
                let v232 : unit = ()
                let v233 : (unit -> unit) = closure32(v1, v145)
                let v234 : unit = (fun () -> v233 (); v232) ()
                let v281 : unit = ()
                let v282 : (unit -> unit) = closure33()
                let v283 : unit = (fun () -> v282 (); v281) ()
                let v286 : uint8 = v1 + 1uy
                let v287 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = method28(v0, v286)
                let v288 : string = "v287.await"
                let v289 : US8 = Fable.Core.RustInterop.emitRustExpr () v288 
                v289
        | US9_0(v30) -> (* Ok *)
            match v30 with
            | US7_1 -> (* None *)
                let v31 : string = "true; let __future_init = Box::pin(/*"
                let v32 : bool = Fable.Core.RustInterop.emitRustExpr () v31 
                let v33 : string = "*/ async move { /*"
                let v34 : bool = Fable.Core.RustInterop.emitRustExpr () v33 
                let v35 : string = "*/ ()"
                let v36 : bool = Fable.Core.RustInterop.emitRustExpr () v35 
                let v37 : string = ""
                let v38 : string = "}"
                let v39 : string = v37 + v38 
                let v40 : US7 = US7_1
                let x = struct (v1, v40) //
                let v41 : _ = x
                let v42 : unit = ()
                (* run_target_args'
                let v43 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v44 : string = $"true; let _fix_closure_v42 = $0"
                let v45 : bool = Fable.Core.RustInterop.emitRustExpr v41 v44 
                let _run_target_args'_v43 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v46 : string = $"true; let _fix_closure_v42 = $0"
                let v47 : bool = Fable.Core.RustInterop.emitRustExpr v41 v46 
                let _run_target_args'_v43 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v48 : string = $"true; let _fix_closure_v42 = $0"
                let v49 : bool = Fable.Core.RustInterop.emitRustExpr v41 v48 
                let _run_target_args'_v43 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v43 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v43 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v43 = false 
                #endif
#else
                let _run_target_args'_v43 = false 
                #endif
                let v50 : bool = _run_target_args'_v43 
                let v52 : string = $"true; _fix_closure_v42 " + v39 + "); " + v37 + " // rust.fix_closure'"
                let v53 : bool = Fable.Core.RustInterop.emitRustExpr () v52 
                let v54 : string = "__future_init"
                let v55 : _ = Fable.Core.RustInterop.emitRustExpr () v54 
                let v56 : string = "v55"
                let v57 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v56 
                let v58 : string = "v57.await"
                let struct (v59 : uint8, v60 : US7) = Fable.Core.RustInterop.emitRustExpr () v58 
                US8_0(v59, v60)
            | US7_0(v62) -> (* Some *)
                let v63 : unit = ()
                let v64 : (unit -> unit) = closure34(v1, v62)
                let v65 : unit = (fun () -> v64 (); v63) ()
                let v112 : string = "true; let __future_init = Box::pin(/*"
                let v113 : bool = Fable.Core.RustInterop.emitRustExpr () v112 
                let v114 : string = "*/ async move { /*"
                let v115 : bool = Fable.Core.RustInterop.emitRustExpr () v114 
                let v116 : string = "*/ ()"
                let v117 : bool = Fable.Core.RustInterop.emitRustExpr () v116 
                let v118 : string = ""
                let v119 : string = "}"
                let v120 : string = v118 + v119 
                let v121 : US7 = US7_0(v62)
                let x = struct (v1, v121) //
                let v122 : _ = x
                let v123 : unit = ()
                (* run_target_args'
                let v124 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v125 : string = $"true; let _fix_closure_v123 = $0"
                let v126 : bool = Fable.Core.RustInterop.emitRustExpr v122 v125 
                let _run_target_args'_v124 = true 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v127 : string = $"true; let _fix_closure_v123 = $0"
                let v128 : bool = Fable.Core.RustInterop.emitRustExpr v122 v127 
                let _run_target_args'_v124 = true 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v129 : string = $"true; let _fix_closure_v123 = $0"
                let v130 : bool = Fable.Core.RustInterop.emitRustExpr v122 v129 
                let _run_target_args'_v124 = true 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let _run_target_args'_v124 = false 
                #endif
#if FABLE_COMPILER_PYTHON
                let _run_target_args'_v124 = false 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let _run_target_args'_v124 = false 
                #endif
#else
                let _run_target_args'_v124 = false 
                #endif
                let v131 : bool = _run_target_args'_v124 
                let v133 : string = $"true; _fix_closure_v123 " + v120 + "); " + v118 + " // rust.fix_closure'"
                let v134 : bool = Fable.Core.RustInterop.emitRustExpr () v133 
                let v135 : string = "__future_init"
                let v136 : _ = Fable.Core.RustInterop.emitRustExpr () v135 
                let v137 : string = "v136"
                let v138 : std_pin_Pin<Box<Dyn<std_future_Future<struct (uint8 * US7)>>>> = Fable.Core.RustInterop.emitRustExpr () v137 
                let v139 : string = "v138.await"
                let struct (v140 : uint8, v141 : US7) = Fable.Core.RustInterop.emitRustExpr () v139 
                US8_1(v140, v141)
    let v293 : string = ""
    let v294 : string = "}"
    let v295 : string = v293 + v294 
    let x = v292 //
    let v296 : _ = x
    let v297 : unit = ()
    (* run_target_args'
    let v298 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v299 : string = $"true; let _fix_closure_v297 = $0"
    let v300 : bool = Fable.Core.RustInterop.emitRustExpr v296 v299 
    let _run_target_args'_v298 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v301 : string = $"true; let _fix_closure_v297 = $0"
    let v302 : bool = Fable.Core.RustInterop.emitRustExpr v296 v301 
    let _run_target_args'_v298 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v303 : string = $"true; let _fix_closure_v297 = $0"
    let v304 : bool = Fable.Core.RustInterop.emitRustExpr v296 v303 
    let _run_target_args'_v298 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v298 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v298 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v298 = false 
    #endif
#else
    let _run_target_args'_v298 = false 
    #endif
    let v305 : bool = _run_target_args'_v298 
    let v307 : string = $"true; _fix_closure_v297 " + v295 + "); " + v293 + " // rust.fix_closure'"
    let v308 : bool = Fable.Core.RustInterop.emitRustExpr () v307 
    let v309 : string = "__future_init"
    let v310 : _ = Fable.Core.RustInterop.emitRustExpr () v309 
    let v311 : string = "v310"
    let v312 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = Fable.Core.RustInterop.emitRustExpr () v311 
    v312
and method64 (v0 : US8) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure8(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "retries"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure8(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure8(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    let v34 : string = $"%A{v0}"
    let v38 : string = $"{v34}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure8(v2, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v47 : string = " }"
    let v48 : string = $"{v47}"
    let v51 : unit = ()
    let v52 : (unit -> unit) = closure8(v2, v48)
    let v53 : unit = (fun () -> v52 (); v51) ()
    let v56 : string = v2.l0
    v56
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
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure8(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "retries"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure8(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure8(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"%A{v0}"
    let v39 : string = $"{v35}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v3, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure8(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v58 : string = "error"
    let v59 : string = $"{v58}"
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure8(v3, v59)
    let v64 : unit = (fun () -> v63 (); v62) ()
    let v68 : string = $"{v25}"
    let v71 : unit = ()
    let v72 : (unit -> unit) = closure8(v3, v68)
    let v73 : unit = (fun () -> v72 (); v71) ()
    let v77 : string = $"%A{v1}"
    let v81 : string = $"{v77}"
    let v84 : unit = ()
    let v85 : (unit -> unit) = closure8(v3, v81)
    let v86 : unit = (fun () -> v85 (); v84) ()
    let v90 : string = " }"
    let v91 : string = $"{v90}"
    let v94 : unit = ()
    let v95 : (unit -> unit) = closure8(v3, v91)
    let v96 : unit = (fun () -> v95 (); v94) ()
    let v99 : string = v3.l0
    v99
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
    let v44 : (std_string_String -> US0) = method2()
    let v45 : US0 option = v42 |> Option.map v44 
    let v58 : US0 = US0_1
    let v59 : US0 = v45 |> Option.defaultValue v58 
    let v66 : std_string_String =
        match v59 with
        | US0_1 -> (* None *)
            failwith<std_string_String> "Option does not have a value."
        | US0_0(v63) -> (* Some *)
            v63
    let v67 : string = "fable_library_rust::String_::fromString($0)"
    let v68 : string = Fable.Core.RustInterop.emitRustExpr v66 v67 
    let v69 : unit = ()
    let v70 : (unit -> unit) = closure13(v68)
    let v71 : unit = (fun () -> v70 (); v69) ()
    let v118 : string = "std::fs::read(&*$0)"
    let v119 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v68 v118 
    let v120 : string = "$0?"
    let v121 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v119 v120 
    let v122 : uint8 = 1uy
    let v123 : std_pin_Pin<Box<Dyn<std_future_Future<US8>>>> = method28(v121, v122)
    let v124 : string = "v123.await"
    let v125 : US8 = Fable.Core.RustInterop.emitRustExpr () v124 
    let v126 : unit = ()
    let v127 : (unit -> unit) = closure35(v125)
    let v128 : unit = (fun () -> v127 (); v126) ()
    let v199 : Result<uint8, anyhow_Error> =
        match v125 with
        | US8_1(v178, v179) -> (* Error *)
            let v180 : string = method65(v125, v179)
            let v181 : string = "anyhow::anyhow!($0)"
            let v182 : anyhow_Error = Fable.Core.RustInterop.emitRustExpr v180 v181 
            (* run_target_args'
            let v184 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v185 : string = "Err($0)"
            let v186 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v182 v185 
            let _run_target_args'_v184 = v186 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v187 : string = "Err($0)"
            let v188 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v182 v187 
            let _run_target_args'_v184 = v188 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v189 : string = "Err($0)"
            let v190 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v182 v189 
            let _run_target_args'_v184 = v190 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v191 : Result<uint8, anyhow_Error> = v182 |> Error
            let _run_target_args'_v184 = v191 
            #endif
#if FABLE_COMPILER_PYTHON
            let v192 : Result<uint8, anyhow_Error> = v182 |> Error
            let _run_target_args'_v184 = v192 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v193 : Result<uint8, anyhow_Error> = v182 |> Error
            let _run_target_args'_v184 = v193 
            #endif
#else
            let v194 : Result<uint8, anyhow_Error> = v182 |> Error
            let _run_target_args'_v184 = v194 
            #endif
            let v195 : Result<uint8, anyhow_Error> = _run_target_args'_v184 
            v195
        | US8_0(v175, v176) -> (* Ok *)
            let v177 : Result<uint8, anyhow_Error> = Ok v175 
            v177
    let v200 : string = ""
    let v201 : string = "}"
    let v202 : string = v200 + v201 
    let x = v199 //
    let v203 : _ = x
    let v204 : unit = ()
    (* run_target_args'
    let v205 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v206 : string = $"true; let _fix_closure_v204 = $0"
    let v207 : bool = Fable.Core.RustInterop.emitRustExpr v203 v206 
    let _run_target_args'_v205 = true 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v208 : string = $"true; let _fix_closure_v204 = $0"
    let v209 : bool = Fable.Core.RustInterop.emitRustExpr v203 v208 
    let _run_target_args'_v205 = true 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v210 : string = $"true; let _fix_closure_v204 = $0"
    let v211 : bool = Fable.Core.RustInterop.emitRustExpr v203 v210 
    let _run_target_args'_v205 = true 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v205 = false 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v205 = false 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let _run_target_args'_v205 = false 
    #endif
#else
    let _run_target_args'_v205 = false 
    #endif
    let v212 : bool = _run_target_args'_v205 
    let v214 : string = $"true; _fix_closure_v204 " + v202 + "); " + v200 + " // rust.fix_closure'"
    let v215 : bool = Fable.Core.RustInterop.emitRustExpr () v214 
    let v216 : string = "__future_init"
    let v217 : _ = Fable.Core.RustInterop.emitRustExpr () v216 
    let v218 : string = "v217"
    let v219 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = Fable.Core.RustInterop.emitRustExpr () v218 
    v219
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
    let v41 : (std_string_String -> US0) = method2()
    let v42 : US0 option = v39 |> Option.map v41 
    let v55 : US0 = US0_1
    let v56 : US0 = v42 |> Option.defaultValue v55 
    let v112 : US1 =
        match v56 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v60) -> (* Some *)
            let v61 : string = "fable_library_rust::String_::fromString($0)"
            let v62 : string = Fable.Core.RustInterop.emitRustExpr v60 v61 
            
            
            
            
            
            let v63 : bool = "Verbose" = v62
            let v67 : US2 =
                if v63 then
                    let v64 : US3 = US3_0
                    US2_0(v64)
                else
                    US2_1
            let v108 : US2 =
                match v67 with
                | US2_1 -> (* None *)
                    let v70 : bool = "Debug" = v62
                    let v74 : US2 =
                        if v70 then
                            let v71 : US3 = US3_1
                            US2_0(v71)
                        else
                            US2_1
                    match v74 with
                    | US2_1 -> (* None *)
                        let v77 : bool = "Info" = v62
                        let v81 : US2 =
                            if v77 then
                                let v78 : US3 = US3_2
                                US2_0(v78)
                            else
                                US2_1
                        match v81 with
                        | US2_1 -> (* None *)
                            let v84 : bool = "Warning" = v62
                            let v88 : US2 =
                                if v84 then
                                    let v85 : US3 = US3_3
                                    US2_0(v85)
                                else
                                    US2_1
                            match v88 with
                            | US2_1 -> (* None *)
                                let v91 : bool = "Critical" = v62
                                let v95 : US2 =
                                    if v91 then
                                        let v92 : US3 = US3_4
                                        US2_0(v92)
                                    else
                                        US2_1
                                match v95 with
                                | US2_1 -> (* None *)
                                    US2_1
                                | US2_0(v96) -> (* Some *)
                                    US2_0(v96)
                            | US2_0(v89) -> (* Some *)
                                US2_0(v89)
                        | US2_0(v82) -> (* Some *)
                            US2_0(v82)
                    | US2_0(v75) -> (* Some *)
                        US2_0(v75)
                | US2_0(v68) -> (* Some *)
                    US2_0(v68)
            US1_0(v108)
    let v119 : US2 =
        match v112 with
        | US1_0(v113) -> (* Some *)
            match v113 with
            | US2_0(v114) -> (* Some *)
                US2_0(v114)
            | _ ->
                US2_1
        | _ ->
            US2_1
    let v123 : US3 =
        match v119 with
        | US2_1 -> (* None *)
            US3_0
        | US2_0(v120) -> (* Some *)
            v120
    let v124 : unit = ()
    let v125 : (unit -> unit) = closure2(v123)
    let v126 : unit = (fun () -> v125 (); v124) ()
    let struct (v145 : Mut0, v146 : Mut1, v147 : Mut2, v148 : Mut3, v149 : Mut4, v150 : int64 option) = TraceState.trace_state.Value
    let v163 : unit = ()
    let v164 : (unit -> unit) = closure5(v0)
    let v165 : unit = (fun () -> v164 (); v163) ()
    let v212 : string = method22()
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
    let v246 : string = "clap::ArgMatches::get_one(&$0, $1).cloned()"
    let v247 : std_string_String option = Fable.Core.RustInterop.emitRustExpr struct (v3, v240) v246 
    let v249 : (std_string_String -> string) = method23()
    let v250 : string option = v247 |> Option.map v249 
    let v344 : (string -> US7) = method8()
    let v345 : US7 option = v250 |> Option.map v344 
    let v358 : US7 = US7_1
    let v359 : US7 = v345 |> Option.defaultValue v358 
    let v363 : std_pin_Pin<Box<Dyn<std_future_Future<Result<uint8, anyhow_Error>>>>> = method24(v3)
    let v364 : string = $"tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap()"
    let v365 : _ = Fable.Core.RustInterop.emitRustExpr () v364 
    let v366 : string = "v365.handle().block_on($0)"
    let v367 : Result<uint8, anyhow_Error> = Fable.Core.RustInterop.emitRustExpr v363 v366 
    let v368 : (anyhow_Error -> std_string_String) = method53()
    (* run_target_args'
    let v370 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v371 : string = "$0.map_err(|x| $1(x))"
    let v372 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v367, v368) v371 
    let _run_target_args'_v370 = v372 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v373 : string = "$0.map_err(|x| $1(x))"
    let v374 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v367, v368) v373 
    let _run_target_args'_v370 = v374 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v375 : string = "$0.map_err(|x| $1(x))"
    let v376 : Result<uint8, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v367, v368) v375 
    let _run_target_args'_v370 = v376 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v377 : Result<uint8, std_string_String> = match v367 with Ok x -> Ok x | Error x -> Error (v368 x)
    let _run_target_args'_v370 = v377 
    #endif
#if FABLE_COMPILER_PYTHON
    let v378 : Result<uint8, std_string_String> = match v367 with Ok x -> Ok x | Error x -> Error (v368 x)
    let _run_target_args'_v370 = v378 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v379 : Result<uint8, std_string_String> = match v367 with Ok x -> Ok x | Error x -> Error (v368 x)
    let _run_target_args'_v370 = v379 
    #endif
#else
    let v380 : Result<uint8, std_string_String> = match v367 with Ok x -> Ok x | Error x -> Error (v368 x)
    let _run_target_args'_v370 = v380 
    #endif
    let v381 : Result<uint8, std_string_String> = _run_target_args'_v370 
    let v384 : (uint8 -> US10) = method66()
    let v385 : (std_string_String -> US10) = method67()
    let v386 : US10 = match v381 with Ok x -> v384 x | Error x -> v385 x
    match v386 with
    | US10_1(v409) -> (* Error *)
        match v359 with
        | US7_0(v410) -> (* Some *)
            let v411 : bool = "" = v410
            if v411 then
                ()
            else
                let v412 : string = "fable_library_rust::String_::fromString($0)"
                let v413 : string = Fable.Core.RustInterop.emitRustExpr v409 v412 
                let v415 : bool = v413.Contains v410 
                if v415 then
                    ()
                else
                    let v418 : string = $"spiral_wasm.main / exception: '{v410}' / error: {v409}"
                    (* run_target_args'
                    let v420 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v421 : string = "Err($0)"
                    let v422 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v418 v421 
                    let _run_target_args'_v420 = v422 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v423 : string = "Err($0)"
                    let v424 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v418 v423 
                    let _run_target_args'_v420 = v424 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v425 : string = "Err($0)"
                    let v426 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v418 v425 
                    let _run_target_args'_v420 = v426 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v427 : Result<unit, string> = v418 |> Error
                    let _run_target_args'_v420 = v427 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v428 : Result<unit, string> = v418 |> Error
                    let _run_target_args'_v420 = v428 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v429 : Result<unit, string> = v418 |> Error
                    let _run_target_args'_v420 = v429 
                    #endif
#else
                    let v430 : Result<unit, string> = v418 |> Error
                    let _run_target_args'_v420 = v430 
                    #endif
                    let v431 : Result<unit, string> = _run_target_args'_v420 
                    (* run_target_args'
                    let v434 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v435 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v431 v435 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v436 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v431 v436 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v437 : string = "$0.unwrap()"
                    Fable.Core.RustInterop.emitRustExpr v431 v437 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    match v431 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if FABLE_COMPILER_PYTHON
                    match v431 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    match v431 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
#else
                    match v431 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
                    #endif
                    // run_target_args' is_unit
                    ()
        | _ ->
            (* run_target_args'
            let v439 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v440 : string = "$0.unwrap()"
            let v441 : uint8 = Fable.Core.RustInterop.emitRustExpr v381 v440 
            let _run_target_args'_v439 = v441 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v442 : string = "$0.unwrap()"
            let v443 : uint8 = Fable.Core.RustInterop.emitRustExpr v381 v442 
            let _run_target_args'_v439 = v443 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v444 : string = "$0.unwrap()"
            let v445 : uint8 = Fable.Core.RustInterop.emitRustExpr v381 v444 
            let _run_target_args'_v439 = v445 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v446 : uint8 = match v381 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v439 = v446 
            #endif
#if FABLE_COMPILER_PYTHON
            let v447 : uint8 = match v381 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v439 = v447 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v448 : uint8 = match v381 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v439 = v448 
            #endif
#else
            let v449 : uint8 = match v381 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v439 = v449 
            #endif
            let v450 : uint8 = _run_target_args'_v439 
            ()
    | US10_0(v387) -> (* Ok *)
        match v359 with
        | US7_0(v388) -> (* Some *)
            let v389 : string = $"spiral_wasm.main / retries: {v387} / exception: '{v388}'"
            (* run_target_args'
            let v391 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v392 : string = "Err($0)"
            let v393 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v389 v392 
            let _run_target_args'_v391 = v393 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v394 : string = "Err($0)"
            let v395 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v389 v394 
            let _run_target_args'_v391 = v395 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v396 : string = "Err($0)"
            let v397 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr v389 v396 
            let _run_target_args'_v391 = v397 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v398 : Result<unit, string> = v389 |> Error
            let _run_target_args'_v391 = v398 
            #endif
#if FABLE_COMPILER_PYTHON
            let v399 : Result<unit, string> = v389 |> Error
            let _run_target_args'_v391 = v399 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v400 : Result<unit, string> = v389 |> Error
            let _run_target_args'_v391 = v400 
            #endif
#else
            let v401 : Result<unit, string> = v389 |> Error
            let _run_target_args'_v391 = v401 
            #endif
            let v402 : Result<unit, string> = _run_target_args'_v391 
            (* run_target_args'
            let v405 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v406 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v402 v406 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v407 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v402 v407 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v408 : string = "$0.unwrap()"
            Fable.Core.RustInterop.emitRustExpr v402 v408 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            match v402 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if FABLE_COMPILER_PYTHON
            match v402 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            match v402 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
#else
            match v402 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            #endif
            // run_target_args' is_unit
            ()
        | _ ->
            ()
    0
let v0 : ((string []) -> int32) = closure0()
let main args = v0 args
()
