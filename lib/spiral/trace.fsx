#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::string::String")>]
type std_string_String = class end
#else
type std_string_String = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("&$0")>]
type Ref<'T> = class end
#else
type Ref<'T> = 'T
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("mut $0")>]
#endif
type Mut<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("Vec<$0>")>]
#endif
type Vec<'T> = class end
module TraceState = let mutable trace_state = None
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::env::VarError")>]
#endif
type std_env_VarError = class end
type IOsEnviron = abstract environ: x: unit -> obj
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("str")>]
type Str = class end
#else
type Str = string
#endif

type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2
    | US0_3
    | US0_4
and Mut0 = {mutable l0 : int64}
and Mut1 = {mutable l0 : (string -> unit)}
and Mut2 = {mutable l0 : bool}
and Mut3 = {mutable l0 : string}
and Mut4 = {mutable l0 : US0}
and [<Struct>] US1 =
    | US1_0 of f0_0 : US0
    | US1_1
and [<Struct>] US2 =
    | US2_0 of f0_0 : int64
    | US2_1
and [<Struct>] US3 =
    | US3_0
    | US3_1
    | US3_2
and [<Struct>] US4 =
    | US4_0 of f0_0 : US3
    | US4_1 of f1_0 : US3
    | US4_2 of f2_0 : US3
    | US4_3 of f3_0 : US3
    | US4_4 of f4_0 : US3
    | US4_5 of f5_0 : US3
and [<Struct>] US5 =
    | US5_0 of f0_0 : string
    | US5_1
let rec method3 (v0 : string) : string =
    v0
and method4 () : string =
    let v0 : string = ""
    v0
and closure1 () (v0 : string) : US5 =
    US5_0(v0)
and method5 () : (string -> US5) =
    closure1()
and method2 (v0 : string) : string =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = method3(v0)
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
    let v19 : string = method4()
    let v20 : string = "$0.unwrap_or($1)"
    let v21 : string = Fable.Core.RustInterop.emitRustExpr struct (v18, v19) v20 
    let _run_target_args'_v5 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v22 : US3 = US3_1
    let v23 : US4 = US4_3(v22)
    let v24 : string = $"env.get_environment_variable / target: {v23} / var: {v0}"
    let v25 : string = failwith<string> v24
    let _run_target_args'_v5 = v25 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v26 : US3 = US3_2
    let v27 : US4 = US4_3(v26)
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
    let v51 : (string -> US5) = method5()
    let v52 : US5 option = v47 |> Option.map v51 
    let v65 : US5 = US5_1
    let v66 : US5 = v52 |> Option.defaultValue v65 
    let v73 : string =
        match v66 with
        | US5_1 -> (* None *)
            let v71 : string = ""
            v71
        | US5_0(v70) -> (* Some *)
            v70
    let _run_target_args'_v5 = v73 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v74 : US3 = US3_1
    let v75 : US4 = US4_1(v74)
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
    let v87 : (string -> US5) = method5()
    let v88 : US5 option = v83 |> Option.map v87 
    let v101 : US5 = US5_1
    let v102 : US5 = v88 |> Option.defaultValue v101 
    let v109 : string =
        match v102 with
        | US5_1 -> (* None *)
            let v107 : string = ""
            v107
        | US5_0(v106) -> (* Some *)
            v106
    let _run_target_args'_v5 = v109 
    #endif
    let v110 : string = _run_target_args'_v5 
    v110
and method1 () : struct (US1 * US2) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method2(v0)
    
    
    
    
    
    let v2 : bool = "Verbose" = v1
    let v6 : US1 =
        if v2 then
            let v3 : US0 = US0_0
            US1_0(v3)
        else
            US1_1
    let v47 : US1 =
        match v6 with
        | US1_1 -> (* None *)
            let v9 : bool = "Debug" = v1
            let v13 : US1 =
                if v9 then
                    let v10 : US0 = US0_1
                    US1_0(v10)
                else
                    US1_1
            match v13 with
            | US1_1 -> (* None *)
                let v16 : bool = "Info" = v1
                let v20 : US1 =
                    if v16 then
                        let v17 : US0 = US0_2
                        US1_0(v17)
                    else
                        US1_1
                match v20 with
                | US1_1 -> (* None *)
                    let v23 : bool = "Warning" = v1
                    let v27 : US1 =
                        if v23 then
                            let v24 : US0 = US0_3
                            US1_0(v24)
                        else
                            US1_1
                    match v27 with
                    | US1_1 -> (* None *)
                        let v30 : bool = "Critical" = v1
                        let v34 : US1 =
                            if v30 then
                                let v31 : US0 = US0_4
                                US1_0(v31)
                            else
                                US1_1
                        match v34 with
                        | US1_1 -> (* None *)
                            US1_1
                        | US1_0(v35) -> (* Some *)
                            US1_0(v35)
                    | US1_0(v28) -> (* Some *)
                        US1_0(v28)
                | US1_0(v21) -> (* Some *)
                    US1_0(v21)
            | US1_0(v14) -> (* Some *)
                US1_0(v14)
        | US1_0(v7) -> (* Some *)
            US1_0(v7)
    let v48 : string = "AUTOMATION"
    let v49 : string = method2(v48)
    let v52 : string = "True"
    let v53 : bool = v49 <> v52 
    let v120 : US2 =
        if v53 then
            US2_1
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
            US2_0(v116)
    struct (v47, v120)
and closure2 () (v0 : string) : unit =
    ()
and method0 (v0 : US0) : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let struct (v4 : US1, v5 : US2) = method1()
    let _run_target_args'_v3 = struct (v4, v5) 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : US1 = US1_1
    let v7 : US2 = US2_1
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
    let v162 : US2 =
        if v150 then
            US2_1
        else
            let v154 : string = $"near_sdk::env::block_timestamp()"
            let v155 : uint64 = Fable.Core.RustInterop.emitRustExpr () v154 
            let v157 : (uint64 -> int64) = int64
            let v158 : int64 = v157 v155
            US2_0(v158)
    let v163 : US1 = US1_1
    let _run_target_args'_v3 = struct (v163, v162) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v164 : US1, v165 : US2) = method1()
    let _run_target_args'_v3 = struct (v164, v165) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v166 : US1, v167 : US2) = method1()
    let _run_target_args'_v3 = struct (v166, v167) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v168 : US1, v169 : US2) = method1()
    let _run_target_args'_v3 = struct (v168, v169) 
    #endif
#else
    let struct (v170 : US1, v171 : US2) = method1()
    let _run_target_args'_v3 = struct (v170, v171) 
    #endif
    let struct (v172 : US1, v173 : US2) = _run_target_args'_v3 
    let v178 : Mut0 = {l0 = 1L} : Mut0
    let v179 : (string -> unit) = closure2()
    let v180 : Mut1 = {l0 = v179} : Mut1
    let v181 : Mut2 = {l0 = true} : Mut2
    let v182 : string = ""
    let v183 : Mut3 = {l0 = v182} : Mut3
    let v186 : US0 =
        match v172 with
        | US1_1 -> (* None *)
            v0
        | US1_0(v184) -> (* Some *)
            v184
    let v187 : Mut4 = {l0 = v186} : Mut4
    let v195 : int64 option =
        match v173 with
        | US2_1 -> (* None *)
            let v193 : int64 option = None
            v193
        | US2_0(v188) -> (* Some *)
            let v190 : int64 option = Some v188 
            v190
    struct (v178, v180, v181, v183, v187, v195)
and closure0 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US0 = US0_0
        let struct (v2 : Mut0, v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : int64 option) = method0(v1)
        let v9 : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v9 
        ()
and method6 (v0 : US0) : bool =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure0()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v24 : Mut0, v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : int64 option) = TraceState.trace_state.Value
    let v42 : US0 = v28.l0
    let v43 : bool = v26.l0
    let v44 : bool = v43 = false
    if v44 then
        false
    else
        let v45 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v0
        let v46 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v42
        let v47 : bool = v45 >= v46
        v47
and closure7 () (v0 : int64) : US2 =
    US2_0(v0)
and method8 () : (int64 -> US2) =
    closure7()
and method9 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method10 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method7 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v165 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v167 : (int64 -> US2) = method8()
    let v168 : US2 option = v5 |> Option.map v167 
    let v181 : US2 = US2_1
    let v182 : US2 = v168 |> Option.defaultValue v181 
    let v300 : System.DateTime =
        match v182 with
        | US2_1 -> (* None *)
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
        | US2_0(v186) -> (* Some *)
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
    let v302 : string = method9()
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
    let v326 : (int64 -> US2) = method8()
    let v327 : US2 option = v5 |> Option.map v326 
    let v340 : US2 = US2_1
    let v341 : US2 = v327 |> Option.defaultValue v340 
    let v459 : System.DateTime =
        match v341 with
        | US2_1 -> (* None *)
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
        | US2_0(v345) -> (* Some *)
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
    let v461 : string = method9()
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
    let v487 : (int64 -> US2) = method8()
    let v488 : US2 option = v5 |> Option.map v487 
    let v501 : US2 = US2_1
    let v502 : US2 = v488 |> Option.defaultValue v501 
    let v514 : uint64 =
        match v502 with
        | US2_1 -> (* None *)
            v485
        | US2_0(v506) -> (* Some *)
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
    let v526 : (int64 -> US2) = method8()
    let v527 : US2 option = v5 |> Option.map v526 
    let v540 : US2 = US2_1
    let v541 : US2 = v527 |> Option.defaultValue v540 
    let v659 : System.DateTime =
        match v541 with
        | US2_1 -> (* None *)
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
        | US2_0(v545) -> (* Some *)
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
    let v661 : string = method10()
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
    let v685 : (int64 -> US2) = method8()
    let v686 : US2 option = v5 |> Option.map v685 
    let v699 : US2 = US2_1
    let v700 : US2 = v686 |> Option.defaultValue v699 
    let v818 : System.DateTime =
        match v700 with
        | US2_1 -> (* None *)
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
        | US2_0(v704) -> (* Some *)
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
    let v820 : string = method10()
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
    let v844 : (int64 -> US2) = method8()
    let v845 : US2 option = v5 |> Option.map v844 
    let v858 : US2 = US2_1
    let v859 : US2 = v845 |> Option.defaultValue v858 
    let v977 : System.DateTime =
        match v859 with
        | US2_1 -> (* None *)
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
        | US2_0(v863) -> (* Some *)
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
    let v979 : string = method10()
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
    let v1003 : (int64 -> US2) = method8()
    let v1004 : US2 option = v5 |> Option.map v1003 
    let v1017 : US2 = US2_1
    let v1018 : US2 = v1004 |> Option.defaultValue v1017 
    let v1136 : System.DateTime =
        match v1018 with
        | US2_1 -> (* None *)
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
        | US2_0(v1022) -> (* Some *)
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
    let v1138 : string = method10()
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
and method13 () : string =
    let v0 : string = ""
    v0
and closure8 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and method12 (v0 : char) : string =
    let v1 : string = method13()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure8(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = v2.l0
    v12
and method14 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method11 (v0 : US0) : string =
    
    
    
    
    
    let v1 : bool =
        match v0 with
        | US0_0 -> (* Verbose *)
            true
        | _ ->
            false
    let v5 : US5 =
        if v1 then
            let v2 : string = "Verbose"
            US5_0(v2)
        else
            US5_1
    let v46 : US5 =
        match v5 with
        | US5_1 -> (* None *)
            let v8 : bool =
                match v0 with
                | US0_1 -> (* Debug *)
                    true
                | _ ->
                    false
            let v12 : US5 =
                if v8 then
                    let v9 : string = "Debug"
                    US5_0(v9)
                else
                    US5_1
            match v12 with
            | US5_1 -> (* None *)
                let v15 : bool =
                    match v0 with
                    | US0_2 -> (* Info *)
                        true
                    | _ ->
                        false
                let v19 : US5 =
                    if v15 then
                        let v16 : string = "Info"
                        US5_0(v16)
                    else
                        US5_1
                match v19 with
                | US5_1 -> (* None *)
                    let v22 : bool =
                        match v0 with
                        | US0_3 -> (* Warning *)
                            true
                        | _ ->
                            false
                    let v26 : US5 =
                        if v22 then
                            let v23 : string = "Warning"
                            US5_0(v23)
                        else
                            US5_1
                    match v26 with
                    | US5_1 -> (* None *)
                        let v29 : bool =
                            match v0 with
                            | US0_4 -> (* Critical *)
                                true
                            | _ ->
                                false
                        let v33 : US5 =
                            if v29 then
                                let v30 : string = "Critical"
                                US5_0(v30)
                            else
                                US5_1
                        match v33 with
                        | US5_1 -> (* None *)
                            US5_1
                        | US5_0(v34) -> (* Some *)
                            US5_0(v34)
                    | US5_0(v27) -> (* Some *)
                        US5_0(v27)
                | US5_0(v20) -> (* Some *)
                    US5_0(v20)
            | US5_0(v13) -> (* Some *)
                US5_0(v13)
        | US5_0(v6) -> (* Some *)
            US5_0(v6)
    let v50 : string =
        match v46 with
        | US5_1 -> (* None *)
            failwith<string> "Option does not have a value."
        | US5_0(v47) -> (* Some *)
            v47
    let v52 : (unit -> string) = v50.ToLower
    let v53 : string = v52 ()
    let v56 : char = v53.[int 0]
    let v57 : string = method12(v56)
    (* run_target_args'
    let v71 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v86 : Ref<Str> =
        match v0 with
        | US0_4 -> (* Critical *)
            let v80 : string = "inline_colorization::color_bright_red"
            let v81 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v80 
            v81
        | US0_1 -> (* Debug *)
            let v74 : string = "inline_colorization::color_bright_blue"
            let v75 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v74 
            v75
        | US0_2 -> (* Info *)
            let v76 : string = "inline_colorization::color_bright_green"
            let v77 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v76 
            v77
        | US0_0 -> (* Verbose *)
            let v72 : string = "inline_colorization::color_bright_black"
            let v73 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v72 
            v73
        | US0_3 -> (* Warning *)
            let v78 : string = "inline_colorization::color_yellow"
            let v79 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v78 
            v79
    (* run_target_args'
    let v91 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v92 : string = "&*$0"
    let v93 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v92 
    let _run_target_args'_v91 = v93 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v94 : string = "&*$0"
    let v95 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v94 
    let _run_target_args'_v91 = v95 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v96 : string = "&*$0"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v96 
    let _run_target_args'_v91 = v97 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v99 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v91 = v99 
    #endif
#if FABLE_COMPILER_PYTHON
    let v103 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v91 = v103 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v107 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v91 = v107 
    #endif
#else
    let v111 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v91 = v111 
    #endif
    let v114 : Ref<Str> = _run_target_args'_v91 
    let v120 : string = "inline_colorization::color_reset"
    let v121 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v120 
    let v122 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v123 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v86, v114, v121) v122 
    let v124 : string = "fable_library_rust::String_::fromString($0)"
    let v125 : string = Fable.Core.RustInterop.emitRustExpr v123 v124 
    let _run_target_args'_v71 = v125 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v140 : Ref<Str> =
        match v0 with
        | US0_4 -> (* Critical *)
            let v134 : string = "inline_colorization::color_bright_red"
            let v135 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v134 
            v135
        | US0_1 -> (* Debug *)
            let v128 : string = "inline_colorization::color_bright_blue"
            let v129 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v128 
            v129
        | US0_2 -> (* Info *)
            let v130 : string = "inline_colorization::color_bright_green"
            let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
            v131
        | US0_0 -> (* Verbose *)
            let v126 : string = "inline_colorization::color_bright_black"
            let v127 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v126 
            v127
        | US0_3 -> (* Warning *)
            let v132 : string = "inline_colorization::color_yellow"
            let v133 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v132 
            v133
    (* run_target_args'
    let v145 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v146 : string = "&*$0"
    let v147 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v146 
    let _run_target_args'_v145 = v147 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v148 : string = "&*$0"
    let v149 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v148 
    let _run_target_args'_v145 = v149 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v150 : string = "&*$0"
    let v151 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v150 
    let _run_target_args'_v145 = v151 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v153 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v145 = v153 
    #endif
#if FABLE_COMPILER_PYTHON
    let v157 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v145 = v157 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v161 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v145 = v161 
    #endif
#else
    let v165 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v145 = v165 
    #endif
    let v168 : Ref<Str> = _run_target_args'_v145 
    let v174 : string = "inline_colorization::color_reset"
    let v175 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v174 
    let v176 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v177 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v140, v168, v175) v176 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v177 v178 
    let _run_target_args'_v71 = v179 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v194 : Ref<Str> =
        match v0 with
        | US0_4 -> (* Critical *)
            let v188 : string = "inline_colorization::color_bright_red"
            let v189 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v188 
            v189
        | US0_1 -> (* Debug *)
            let v182 : string = "inline_colorization::color_bright_blue"
            let v183 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v182 
            v183
        | US0_2 -> (* Info *)
            let v184 : string = "inline_colorization::color_bright_green"
            let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v184 
            v185
        | US0_0 -> (* Verbose *)
            let v180 : string = "inline_colorization::color_bright_black"
            let v181 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v180 
            v181
        | US0_3 -> (* Warning *)
            let v186 : string = "inline_colorization::color_yellow"
            let v187 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v186 
            v187
    (* run_target_args'
    let v199 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v200 : string = "&*$0"
    let v201 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v200 
    let _run_target_args'_v199 = v201 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v202 : string = "&*$0"
    let v203 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v202 
    let _run_target_args'_v199 = v203 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v204 : string = "&*$0"
    let v205 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v57 v204 
    let _run_target_args'_v199 = v205 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v207 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v199 = v207 
    #endif
#if FABLE_COMPILER_PYTHON
    let v211 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v199 = v211 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v215 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v199 = v215 
    #endif
#else
    let v219 : Ref<Str> = v57 |> unbox<Ref<Str>>
    let _run_target_args'_v199 = v219 
    #endif
    let v222 : Ref<Str> = _run_target_args'_v199 
    let v228 : string = "inline_colorization::color_reset"
    let v229 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v228 
    let v230 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v231 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v194, v222, v229) v230 
    let v232 : string = "fable_library_rust::String_::fromString($0)"
    let v233 : string = Fable.Core.RustInterop.emitRustExpr v231 v232 
    let _run_target_args'_v71 = v233 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v243 : string =
        match v0 with
        | US0_4 -> (* Critical *)
            let v238 : string = "\u001b[91m"
            v238
        | US0_1 -> (* Debug *)
            let v235 : string = "\u001b[94m"
            v235
        | US0_2 -> (* Info *)
            let v236 : string = "\u001b[92m"
            v236
        | US0_0 -> (* Verbose *)
            let v234 : string = "\u001b[90m"
            v234
        | US0_3 -> (* Warning *)
            let v237 : string = "\u001b[93m"
            v237
    let v244 : string = method14()
    let v245 : string = v243 + v57 
    let v246 : string = v245 + v244 
    let _run_target_args'_v71 = v246 
    #endif
#if FABLE_COMPILER_PYTHON
    let v256 : string =
        match v0 with
        | US0_4 -> (* Critical *)
            let v251 : string = "\u001b[91m"
            v251
        | US0_1 -> (* Debug *)
            let v248 : string = "\u001b[94m"
            v248
        | US0_2 -> (* Info *)
            let v249 : string = "\u001b[92m"
            v249
        | US0_0 -> (* Verbose *)
            let v247 : string = "\u001b[90m"
            v247
        | US0_3 -> (* Warning *)
            let v250 : string = "\u001b[93m"
            v250
    let v257 : string = method14()
    let v258 : string = v256 + v57 
    let v259 : string = v258 + v257 
    let _run_target_args'_v71 = v259 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v269 : string =
        match v0 with
        | US0_4 -> (* Critical *)
            let v264 : string = "\u001b[91m"
            v264
        | US0_1 -> (* Debug *)
            let v261 : string = "\u001b[94m"
            v261
        | US0_2 -> (* Info *)
            let v262 : string = "\u001b[92m"
            v262
        | US0_0 -> (* Verbose *)
            let v260 : string = "\u001b[90m"
            v260
        | US0_3 -> (* Warning *)
            let v263 : string = "\u001b[93m"
            v263
    let v270 : string = method14()
    let v271 : string = v269 + v57 
    let v272 : string = v271 + v270 
    let _run_target_args'_v71 = v272 
    #endif
#else
    let v282 : string =
        match v0 with
        | US0_4 -> (* Critical *)
            let v277 : string = "\u001b[91m"
            v277
        | US0_1 -> (* Debug *)
            let v274 : string = "\u001b[94m"
            v274
        | US0_2 -> (* Info *)
            let v275 : string = "\u001b[92m"
            v275
        | US0_0 -> (* Verbose *)
            let v273 : string = "\u001b[90m"
            v273
        | US0_3 -> (* Warning *)
            let v276 : string = "\u001b[93m"
            v276
    let v283 : string = method14()
    let v284 : string = v282 + v57 
    let v285 : string = v284 + v283 
    let _run_target_args'_v71 = v285 
    #endif
    let v286 : string = _run_target_args'_v71 
    v286
and method16 (v0 : string) : string =
    let v1 : string = method13()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure8(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = v2.l0
    v12
and method17 (v0 : string) : string =
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
and method15 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method16(v9)
    let v11 : int64 = v0.l0
    let v13 : string = $"{v6} {v7} #{v11} %s{v8} / {v10}"
    method17(v13)
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
and method18 (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure0()
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
and closure6 (v0 : US0, v1 : (unit -> string), v2 : (unit -> string)) () : unit =
    let v3 : bool = method6(v0)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method7(v27, v28, v29, v30, v31, v32)
        let v46 : string = method11(v0)
        let v47 : string = v1 ()
        let v48 : bool = v47 = ""
        let v52 : string =
            if v48 then
                let v49 : string = ""
                v49
            else
                let v50 : string = v2 ()
                method15(v27, v28, v29, v30, v31, v32, v45, v46, v47, v50)
        method18(v52)
and closure5 (v0 : US0, v1 : (unit -> string)) (v2 : (unit -> string)) : unit =
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure6(v0, v1, v2)
    let v5 : unit = (fun () -> v4 (); v3) ()
    ()
and closure4 (v0 : US0) (v1 : (unit -> string)) : ((unit -> string) -> unit) =
    closure5(v0, v1)
and closure3 () (v0 : US0) : ((unit -> string) -> ((unit -> string) -> unit)) =
    closure4(v0)
let v0 : unit = ()
let v1 : (unit -> unit) = closure0()
let v2 : unit = (fun () -> v1 (); v0) ()
let v17 : (US0 -> ((unit -> string) -> ((unit -> string) -> unit))) = closure3()
let trace x = v17 x
()
