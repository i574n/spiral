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

type System_Net_Sockets_TcpClient = System.IDisposable
#else
type System_Net_Sockets_TcpClient = System.Net.Sockets.TcpClient
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
and [<Struct>] US6 =
    | US6_0 of f0_0 : bool
    | US6_1
and [<Struct>] US7 =
    | US7_0 of f0_0 : bool
    | US7_1 of f1_0 : exn
and [<Struct>] US8 =
    | US8_0 of f0_0 : bool
    | US8_1 of f1_0 : exn
and [<Struct>] US9 =
    | US9_0 of f0_0 : int32
    | US9_1
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
    let v52 : (string -> US5) = method5()
    let v53 : US5 option = v47 |> Option.map v52 
    let v67 : US5 = US5_1
    let v68 : US5 = v53 |> Option.defaultValue v67 
    let v75 : string =
        match v68 with
        | US5_1 -> (* None *)
            let v73 : string = ""
            v73
        | US5_0(v72) -> (* Some *)
            v72
    let _run_target_args'_v5 = v75 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : US3 = US3_1
    let v77 : US4 = US4_1(v76)
    let v78 : string = $"env.get_environment_variable / target: {v77} / var: {v0}"
    let v79 : string = failwith<string> v78
    let _run_target_args'_v5 = v79 
    #endif
#else
    let v80 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v81 : string = v80 v0
    let mutable _v81 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v83 : (string -> string option) = Option.ofObj
    let v84 : string option = v83 v81
    v84 
    #else
    Some v81 
    #endif
    |> fun x -> _v81 <- Some x
    let v85 : string option = match _v81 with Some x -> x | None -> failwith "optionm'.of_obj / _v81=None"
    let v90 : (string -> US5) = method5()
    let v91 : US5 option = v85 |> Option.map v90 
    let v105 : US5 = US5_1
    let v106 : US5 = v91 |> Option.defaultValue v105 
    let v113 : string =
        match v106 with
        | US5_1 -> (* None *)
            let v111 : string = ""
            v111
        | US5_0(v110) -> (* Some *)
            v110
    let _run_target_args'_v5 = v113 
    #endif
    let v114 : string = _run_target_args'_v5 
    v114
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
and method8 (v0 : US0) : bool =
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
and closure6 () (v0 : int64) : US2 =
    US2_0(v0)
and method10 () : (int64 -> US2) =
    closure6()
and method11 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method12 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method9 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v167 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v170 : (int64 -> US2) = method10()
    let v171 : US2 option = v5 |> Option.map v170 
    let v185 : US2 = US2_1
    let v186 : US2 = v171 |> Option.defaultValue v185 
    let v304 : System.DateTime =
        match v186 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v287 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v288 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v288 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v289 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v289 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v291 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v287 = v291 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v294 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v294 
            #endif
#if FABLE_COMPILER_PYTHON
            let v295 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v295 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v296 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v296 
            #endif
#else
            let v297 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v297 
            #endif
            let v298 : System.DateTime = _run_target_args'_v287 
            v298
        | US2_0(v190) -> (* Some *)
            (* run_target_args'
            let v193 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v194 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v194 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v195 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v195 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v197 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v193 = v197 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v200 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v200 
            #endif
#if FABLE_COMPILER_PYTHON
            let v201 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v201 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v202 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v202 
            #endif
#else
            let v203 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v203 
            #endif
            let v204 : System.DateTime = _run_target_args'_v193 
            (* run_target_args'
            let v212 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v213 : (System.DateTime -> int64) = _.Ticks
            let v214 : int64 = v213 v204
            let _run_target_args'_v212 = v214 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v215 : (System.DateTime -> int64) = _.Ticks
            let v216 : int64 = v215 v204
            let _run_target_args'_v212 = v216 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : int64 = null |> unbox<int64>
            let _run_target_args'_v212 = v218 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v221 : (System.DateTime -> int64) = _.Ticks
            let v222 : int64 = v221 v204
            let _run_target_args'_v212 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v223 : (System.DateTime -> int64) = _.Ticks
            let v224 : int64 = v223 v204
            let _run_target_args'_v212 = v224 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v225 : (System.DateTime -> int64) = _.Ticks
            let v226 : int64 = v225 v204
            let _run_target_args'_v212 = v226 
            #endif
#else
            let v227 : (System.DateTime -> int64) = _.Ticks
            let v228 : int64 = v227 v204
            let _run_target_args'_v212 = v228 
            #endif
            let v229 : int64 = _run_target_args'_v212 
            let v250 : int64 = v229 |> int64 
            let v253 : int64 = v250 - v190
            let v256 : System.TimeSpan = v253 |> System.TimeSpan 
            let v262 : (System.TimeSpan -> int32) = _.Hours
            let v263 : int32 = v262 v256
            let v267 : (System.TimeSpan -> int32) = _.Minutes
            let v268 : int32 = v267 v256
            let v272 : (System.TimeSpan -> int32) = _.Seconds
            let v273 : int32 = v272 v256
            let v277 : (System.TimeSpan -> int32) = _.Milliseconds
            let v278 : int32 = v277 v256
            let v282 : System.DateTime = System.DateTime (1, 1, 1, v263, v268, v273, v278)
            v282
    let v306 : string = method11()
    let v310 : bool = v306 = ""
    let v312 : string =
        if v310 then
            let v311 : string = "M-d-y hh:mm:ss tt"
            v311
        else
            v306
    let v313 : (string -> string) = v304.ToString
    let v314 : string = v313 v312
    let _run_target_args'_v167 = v314 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v331 : (int64 -> US2) = method10()
    let v332 : US2 option = v5 |> Option.map v331 
    let v346 : US2 = US2_1
    let v347 : US2 = v332 |> Option.defaultValue v346 
    let v465 : System.DateTime =
        match v347 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v448 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v449 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v449 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v450 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v450 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v452 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v448 = v452 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v455 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v455 
            #endif
#if FABLE_COMPILER_PYTHON
            let v456 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v456 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v457 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v457 
            #endif
#else
            let v458 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v458 
            #endif
            let v459 : System.DateTime = _run_target_args'_v448 
            v459
        | US2_0(v351) -> (* Some *)
            (* run_target_args'
            let v354 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v355 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v355 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v356 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v356 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v358 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v354 = v358 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v361 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v361 
            #endif
#if FABLE_COMPILER_PYTHON
            let v362 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v362 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v363 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v363 
            #endif
#else
            let v364 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v364 
            #endif
            let v365 : System.DateTime = _run_target_args'_v354 
            (* run_target_args'
            let v373 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v374 : (System.DateTime -> int64) = _.Ticks
            let v375 : int64 = v374 v365
            let _run_target_args'_v373 = v375 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v376 : (System.DateTime -> int64) = _.Ticks
            let v377 : int64 = v376 v365
            let _run_target_args'_v373 = v377 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v379 : int64 = null |> unbox<int64>
            let _run_target_args'_v373 = v379 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v382 : (System.DateTime -> int64) = _.Ticks
            let v383 : int64 = v382 v365
            let _run_target_args'_v373 = v383 
            #endif
#if FABLE_COMPILER_PYTHON
            let v384 : (System.DateTime -> int64) = _.Ticks
            let v385 : int64 = v384 v365
            let _run_target_args'_v373 = v385 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v386 : (System.DateTime -> int64) = _.Ticks
            let v387 : int64 = v386 v365
            let _run_target_args'_v373 = v387 
            #endif
#else
            let v388 : (System.DateTime -> int64) = _.Ticks
            let v389 : int64 = v388 v365
            let _run_target_args'_v373 = v389 
            #endif
            let v390 : int64 = _run_target_args'_v373 
            let v411 : int64 = v390 |> int64 
            let v414 : int64 = v411 - v351
            let v417 : System.TimeSpan = v414 |> System.TimeSpan 
            let v423 : (System.TimeSpan -> int32) = _.Hours
            let v424 : int32 = v423 v417
            let v428 : (System.TimeSpan -> int32) = _.Minutes
            let v429 : int32 = v428 v417
            let v433 : (System.TimeSpan -> int32) = _.Seconds
            let v434 : int32 = v433 v417
            let v438 : (System.TimeSpan -> int32) = _.Milliseconds
            let v439 : int32 = v438 v417
            let v443 : System.DateTime = System.DateTime (1, 1, 1, v424, v429, v434, v439)
            v443
    let v467 : string = method11()
    let v471 : bool = v467 = ""
    let v473 : string =
        if v471 then
            let v472 : string = "M-d-y hh:mm:ss tt"
            v472
        else
            v467
    let v474 : (string -> string) = v465.ToString
    let v475 : string = v474 v473
    let _run_target_args'_v167 = v475 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v490 : string = $"near_sdk::env::block_timestamp()"
    let v491 : uint64 = Fable.Core.RustInterop.emitRustExpr () v490 
    let v494 : (int64 -> US2) = method10()
    let v495 : US2 option = v5 |> Option.map v494 
    let v509 : US2 = US2_1
    let v510 : US2 = v495 |> Option.defaultValue v509 
    let v522 : uint64 =
        match v510 with
        | US2_1 -> (* None *)
            v491
        | US2_0(v514) -> (* Some *)
            let v516 : (int64 -> uint64) = uint64
            let v517 : uint64 = v516 v514
            let v520 : uint64 = v491 - v517
            v520
    let v523 : uint64 = v522 / 1000000000UL
    let v524 : uint64 = v523 % 60UL
    let v525 : uint64 = v523 / 60UL
    let v526 : uint64 = v525 % 60UL
    let v527 : uint64 = v523 / 3600UL
    let v528 : uint64 = v527 % 24UL
    let v529 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v530 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v528, v526, v524) v529 
    let v531 : string = "fable_library_rust::String_::fromString($0)"
    let v532 : string = Fable.Core.RustInterop.emitRustExpr v530 v531 
    let _run_target_args'_v167 = v532 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v535 : (int64 -> US2) = method10()
    let v536 : US2 option = v5 |> Option.map v535 
    let v550 : US2 = US2_1
    let v551 : US2 = v536 |> Option.defaultValue v550 
    let v669 : System.DateTime =
        match v551 with
        | US2_1 -> (* None *)
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
            v663
        | US2_0(v555) -> (* Some *)
            (* run_target_args'
            let v558 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v559 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v559 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v560 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v560 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v562 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v558 = v562 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v565 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v565 
            #endif
#if FABLE_COMPILER_PYTHON
            let v566 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v566 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v567 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v567 
            #endif
#else
            let v568 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v568 
            #endif
            let v569 : System.DateTime = _run_target_args'_v558 
            (* run_target_args'
            let v577 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v578 : (System.DateTime -> int64) = _.Ticks
            let v579 : int64 = v578 v569
            let _run_target_args'_v577 = v579 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v580 : (System.DateTime -> int64) = _.Ticks
            let v581 : int64 = v580 v569
            let _run_target_args'_v577 = v581 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v583 : int64 = null |> unbox<int64>
            let _run_target_args'_v577 = v583 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v586 : (System.DateTime -> int64) = _.Ticks
            let v587 : int64 = v586 v569
            let _run_target_args'_v577 = v587 
            #endif
#if FABLE_COMPILER_PYTHON
            let v588 : (System.DateTime -> int64) = _.Ticks
            let v589 : int64 = v588 v569
            let _run_target_args'_v577 = v589 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v590 : (System.DateTime -> int64) = _.Ticks
            let v591 : int64 = v590 v569
            let _run_target_args'_v577 = v591 
            #endif
#else
            let v592 : (System.DateTime -> int64) = _.Ticks
            let v593 : int64 = v592 v569
            let _run_target_args'_v577 = v593 
            #endif
            let v594 : int64 = _run_target_args'_v577 
            let v615 : int64 = v594 |> int64 
            let v618 : int64 = v615 - v555
            let v621 : System.TimeSpan = v618 |> System.TimeSpan 
            let v627 : (System.TimeSpan -> int32) = _.Hours
            let v628 : int32 = v627 v621
            let v632 : (System.TimeSpan -> int32) = _.Minutes
            let v633 : int32 = v632 v621
            let v637 : (System.TimeSpan -> int32) = _.Seconds
            let v638 : int32 = v637 v621
            let v642 : (System.TimeSpan -> int32) = _.Milliseconds
            let v643 : int32 = v642 v621
            let v647 : System.DateTime = System.DateTime (1, 1, 1, v628, v633, v638, v643)
            v647
    let v671 : string = method12()
    let v675 : bool = v671 = ""
    let v677 : string =
        if v675 then
            let v676 : string = "M-d-y hh:mm:ss tt"
            v676
        else
            v671
    let v678 : (string -> string) = v669.ToString
    let v679 : string = v678 v677
    let _run_target_args'_v167 = v679 
    #endif
#if FABLE_COMPILER_PYTHON
    let v696 : (int64 -> US2) = method10()
    let v697 : US2 option = v5 |> Option.map v696 
    let v711 : US2 = US2_1
    let v712 : US2 = v697 |> Option.defaultValue v711 
    let v830 : System.DateTime =
        match v712 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v813 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v814 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v814 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v815 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v815 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v817 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v813 = v817 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v820 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v820 
            #endif
#if FABLE_COMPILER_PYTHON
            let v821 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v821 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v822 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v822 
            #endif
#else
            let v823 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v823 
            #endif
            let v824 : System.DateTime = _run_target_args'_v813 
            v824
        | US2_0(v716) -> (* Some *)
            (* run_target_args'
            let v719 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v720 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v720 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v721 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v721 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v723 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v719 = v723 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v726 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v726 
            #endif
#if FABLE_COMPILER_PYTHON
            let v727 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v727 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v728 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v728 
            #endif
#else
            let v729 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v729 
            #endif
            let v730 : System.DateTime = _run_target_args'_v719 
            (* run_target_args'
            let v738 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v739 : (System.DateTime -> int64) = _.Ticks
            let v740 : int64 = v739 v730
            let _run_target_args'_v738 = v740 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v741 : (System.DateTime -> int64) = _.Ticks
            let v742 : int64 = v741 v730
            let _run_target_args'_v738 = v742 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v744 : int64 = null |> unbox<int64>
            let _run_target_args'_v738 = v744 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v747 : (System.DateTime -> int64) = _.Ticks
            let v748 : int64 = v747 v730
            let _run_target_args'_v738 = v748 
            #endif
#if FABLE_COMPILER_PYTHON
            let v749 : (System.DateTime -> int64) = _.Ticks
            let v750 : int64 = v749 v730
            let _run_target_args'_v738 = v750 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v751 : (System.DateTime -> int64) = _.Ticks
            let v752 : int64 = v751 v730
            let _run_target_args'_v738 = v752 
            #endif
#else
            let v753 : (System.DateTime -> int64) = _.Ticks
            let v754 : int64 = v753 v730
            let _run_target_args'_v738 = v754 
            #endif
            let v755 : int64 = _run_target_args'_v738 
            let v776 : int64 = v755 |> int64 
            let v779 : int64 = v776 - v716
            let v782 : System.TimeSpan = v779 |> System.TimeSpan 
            let v788 : (System.TimeSpan -> int32) = _.Hours
            let v789 : int32 = v788 v782
            let v793 : (System.TimeSpan -> int32) = _.Minutes
            let v794 : int32 = v793 v782
            let v798 : (System.TimeSpan -> int32) = _.Seconds
            let v799 : int32 = v798 v782
            let v803 : (System.TimeSpan -> int32) = _.Milliseconds
            let v804 : int32 = v803 v782
            let v808 : System.DateTime = System.DateTime (1, 1, 1, v789, v794, v799, v804)
            v808
    let v832 : string = method12()
    let v836 : bool = v832 = ""
    let v838 : string =
        if v836 then
            let v837 : string = "M-d-y hh:mm:ss tt"
            v837
        else
            v832
    let v839 : (string -> string) = v830.ToString
    let v840 : string = v839 v838
    let _run_target_args'_v167 = v840 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v857 : (int64 -> US2) = method10()
    let v858 : US2 option = v5 |> Option.map v857 
    let v872 : US2 = US2_1
    let v873 : US2 = v858 |> Option.defaultValue v872 
    let v991 : System.DateTime =
        match v873 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v974 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v975 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v975 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v976 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v976 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v978 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v974 = v978 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v981 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v981 
            #endif
#if FABLE_COMPILER_PYTHON
            let v982 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v982 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v983 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v983 
            #endif
#else
            let v984 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v984 
            #endif
            let v985 : System.DateTime = _run_target_args'_v974 
            v985
        | US2_0(v877) -> (* Some *)
            (* run_target_args'
            let v880 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v881 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v881 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v882 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v882 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v884 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v880 = v884 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v887 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v887 
            #endif
#if FABLE_COMPILER_PYTHON
            let v888 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v888 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v889 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v889 
            #endif
#else
            let v890 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v890 
            #endif
            let v891 : System.DateTime = _run_target_args'_v880 
            (* run_target_args'
            let v899 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v900 : (System.DateTime -> int64) = _.Ticks
            let v901 : int64 = v900 v891
            let _run_target_args'_v899 = v901 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v902 : (System.DateTime -> int64) = _.Ticks
            let v903 : int64 = v902 v891
            let _run_target_args'_v899 = v903 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v905 : int64 = null |> unbox<int64>
            let _run_target_args'_v899 = v905 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v908 : (System.DateTime -> int64) = _.Ticks
            let v909 : int64 = v908 v891
            let _run_target_args'_v899 = v909 
            #endif
#if FABLE_COMPILER_PYTHON
            let v910 : (System.DateTime -> int64) = _.Ticks
            let v911 : int64 = v910 v891
            let _run_target_args'_v899 = v911 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v912 : (System.DateTime -> int64) = _.Ticks
            let v913 : int64 = v912 v891
            let _run_target_args'_v899 = v913 
            #endif
#else
            let v914 : (System.DateTime -> int64) = _.Ticks
            let v915 : int64 = v914 v891
            let _run_target_args'_v899 = v915 
            #endif
            let v916 : int64 = _run_target_args'_v899 
            let v937 : int64 = v916 |> int64 
            let v940 : int64 = v937 - v877
            let v943 : System.TimeSpan = v940 |> System.TimeSpan 
            let v949 : (System.TimeSpan -> int32) = _.Hours
            let v950 : int32 = v949 v943
            let v954 : (System.TimeSpan -> int32) = _.Minutes
            let v955 : int32 = v954 v943
            let v959 : (System.TimeSpan -> int32) = _.Seconds
            let v960 : int32 = v959 v943
            let v964 : (System.TimeSpan -> int32) = _.Milliseconds
            let v965 : int32 = v964 v943
            let v969 : System.DateTime = System.DateTime (1, 1, 1, v950, v955, v960, v965)
            v969
    let v993 : string = method12()
    let v997 : bool = v993 = ""
    let v999 : string =
        if v997 then
            let v998 : string = "M-d-y hh:mm:ss tt"
            v998
        else
            v993
    let v1000 : (string -> string) = v991.ToString
    let v1001 : string = v1000 v999
    let _run_target_args'_v167 = v1001 
    #endif
#else
    let v1018 : (int64 -> US2) = method10()
    let v1019 : US2 option = v5 |> Option.map v1018 
    let v1033 : US2 = US2_1
    let v1034 : US2 = v1019 |> Option.defaultValue v1033 
    let v1152 : System.DateTime =
        match v1034 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1135 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1136 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1136 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1137 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1137 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1139 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1135 = v1139 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1142 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1142 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1143 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1143 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1144 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1144 
            #endif
#else
            let v1145 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1145 
            #endif
            let v1146 : System.DateTime = _run_target_args'_v1135 
            v1146
        | US2_0(v1038) -> (* Some *)
            (* run_target_args'
            let v1041 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1042 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1042 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1043 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1043 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1045 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1041 = v1045 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1048 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1048 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1049 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1049 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1050 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1050 
            #endif
#else
            let v1051 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1051 
            #endif
            let v1052 : System.DateTime = _run_target_args'_v1041 
            (* run_target_args'
            let v1060 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1061 : (System.DateTime -> int64) = _.Ticks
            let v1062 : int64 = v1061 v1052
            let _run_target_args'_v1060 = v1062 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1063 : (System.DateTime -> int64) = _.Ticks
            let v1064 : int64 = v1063 v1052
            let _run_target_args'_v1060 = v1064 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1066 : int64 = null |> unbox<int64>
            let _run_target_args'_v1060 = v1066 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1069 : (System.DateTime -> int64) = _.Ticks
            let v1070 : int64 = v1069 v1052
            let _run_target_args'_v1060 = v1070 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1071 : (System.DateTime -> int64) = _.Ticks
            let v1072 : int64 = v1071 v1052
            let _run_target_args'_v1060 = v1072 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1073 : (System.DateTime -> int64) = _.Ticks
            let v1074 : int64 = v1073 v1052
            let _run_target_args'_v1060 = v1074 
            #endif
#else
            let v1075 : (System.DateTime -> int64) = _.Ticks
            let v1076 : int64 = v1075 v1052
            let _run_target_args'_v1060 = v1076 
            #endif
            let v1077 : int64 = _run_target_args'_v1060 
            let v1098 : int64 = v1077 |> int64 
            let v1101 : int64 = v1098 - v1038
            let v1104 : System.TimeSpan = v1101 |> System.TimeSpan 
            let v1110 : (System.TimeSpan -> int32) = _.Hours
            let v1111 : int32 = v1110 v1104
            let v1115 : (System.TimeSpan -> int32) = _.Minutes
            let v1116 : int32 = v1115 v1104
            let v1120 : (System.TimeSpan -> int32) = _.Seconds
            let v1121 : int32 = v1120 v1104
            let v1125 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1126 : int32 = v1125 v1104
            let v1130 : System.DateTime = System.DateTime (1, 1, 1, v1111, v1116, v1121, v1126)
            v1130
    let v1154 : string = method12()
    let v1158 : bool = v1154 = ""
    let v1160 : string =
        if v1158 then
            let v1159 : string = "M-d-y hh:mm:ss tt"
            v1159
        else
            v1154
    let v1161 : (string -> string) = v1152.ToString
    let v1162 : string = v1161 v1160
    let _run_target_args'_v167 = v1162 
    #endif
    let v1177 : string = _run_target_args'_v167 
    v1177
and method15 () : string =
    let v0 : string = ""
    v0
and closure7 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and method14 (v0 : char) : string =
    let v1 : string = method15()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure7(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = v2.l0
    v12
and method16 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method13 () : string =
    
    
    
    
    
    let v1 : string = "Verbose"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method14(v6)
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
    let v137 : string = method16()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[90m"
    let v141 : string = method16()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[90m"
    let v145 : string = method16()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[90m"
    let v149 : string = method16()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method18 (v0 : int32, v1 : string) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure7(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "port"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure7(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure7(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure7(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure7(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "ex"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure7(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure7(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v1}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure7(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure7(v3, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v3.l0
    v91
and method19 (v0 : string) : string =
    let v1 : char list = []
    let v4 : (char list -> (char [])) = List.toArray
    let v5 : (char []) = v4 v1
    let v8 : string = v0.TrimStart v5 
    let v38 : char list = []
    let v40 : char list = '/' :: v38 
    let v44 : char list = ' ' :: v40 
    let v49 : (char list -> (char [])) = List.toArray
    let v50 : (char []) = v49 v44
    let v53 : string = v8.TrimEnd v50 
    v53
and method17 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method18(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "networking.test_port_open"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method19(v14)
and closure8 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure10 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure9 () (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure10(v0)
    let v3 : unit = (fun () -> v2 (); v1) ()
    ()
and method20 (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure0()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v24 : Mut0, v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : int64 option) = TraceState.trace_state.Value
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v24)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v47 : (string -> unit) = closure9()
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
and closure5 (v0 : int32, v1 : exn) () : unit =
    let v2 : US0 = US0_0
    let v3 : bool = method8(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method9(v27, v28, v29, v30, v31, v32)
        let v46 : string = method13()
        (* run_target_args'
        let v51 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v53 : string = $"%A{v1}"
        let _run_target_args'_v51 = v53 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v57 : string = $"%A{v1}"
        let _run_target_args'_v51 = v57 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v61 : string = $"%A{v1}"
        let _run_target_args'_v51 = v61 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v65 : string = $"%A{v1}"
        let _run_target_args'_v51 = v65 
        #endif
#if FABLE_COMPILER_PYTHON
        let v69 : string = $"%A{v1}"
        let _run_target_args'_v51 = v69 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v73 : string = $"%A{v1}"
        let _run_target_args'_v51 = v73 
        #endif
#else
        let v76 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v51 = v76 
        #endif
        let v77 : string = _run_target_args'_v51 
        let v83 : string = method17(v27, v28, v29, v30, v31, v32, v45, v46, v0, v77)
        method20(v83)
and method7 (v0 : string, v1 : int32) : Async<bool> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let v23 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v23 = v23 
            let v24 : System.Threading.CancellationToken = v23 
            (* run_target_args'
            let v29 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v31 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v29 = v31 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v35 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v29 = v35 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v39 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v29 = v39 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v43 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v29 = v43 
            #endif
#if FABLE_COMPILER_PYTHON
            let v47 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v29 = v47 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v51 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v29 = v51 
            #endif
#else
            let v54 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v29 = v54 
            #endif
            let v55 : System_Net_Sockets_TcpClient = _run_target_args'_v29 
            use v55 = v55 
            let v61 : System_Net_Sockets_TcpClient = v55 
            try
                (* run_target_args'
                let v66 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v68 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66 = v68 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v72 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66 = v72 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v76 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66 = v76 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v80 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66 = v80 
                #endif
#if FABLE_COMPILER_PYTHON
                let v84 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66 = v84 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v88 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66 = v88 
                #endif
#else
                let v91 : System.Threading.Tasks.ValueTask = v61.ConnectAsync (v0, v1, v24)
                let _run_target_args'_v66 = v91 
                #endif
                let v92 : System.Threading.Tasks.ValueTask = _run_target_args'_v66 
                (* run_target_args'
                let v102 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v104 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v102 = v104 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v108 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v102 = v108 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v112 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v102 = v112 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v116 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v102 = v116 
                #endif
#if FABLE_COMPILER_PYTHON
                let v120 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v102 = v120 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v124 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v102 = v124 
                #endif
#else
                let v127 : (unit -> System.Threading.Tasks.Task) = v92.AsTask
                let v128 : System.Threading.Tasks.Task = v127 ()
                let _run_target_args'_v102 = v128 
                #endif
                let v129 : System.Threading.Tasks.Task = _run_target_args'_v102 
                (* run_target_args'
                let v139 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v141 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v139 = v141 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v145 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v139 = v145 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v149 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v139 = v149 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v152 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v153 : Async<unit> = v152 v129
                let _run_target_args'_v139 = v153 
                #endif
#if FABLE_COMPILER_PYTHON
                let v154 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v155 : Async<unit> = v154 v129
                let _run_target_args'_v139 = v155 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v156 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v157 : Async<unit> = v156 v129
                let _run_target_args'_v139 = v157 
                #endif
#else
                let v158 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v159 : Async<unit> = v158 v129
                let _run_target_args'_v139 = v159 
                #endif
                let v160 : Async<unit> = _run_target_args'_v139 
                do! v160 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v270 : exn = ex
                let v271 : unit = ()
                let v272 : (unit -> unit) = closure5(v1, v270)
                let v273 : unit = (fun () -> v272 (); v271) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v443 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3407 : Async<bool> = _let'_v20 
    let _run_target_args'_v6 = v3407 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3409 : unit = ()
    let _let'_v3409 =
        async {
            let v3412 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v3412 = v3412 
            let v3413 : System.Threading.CancellationToken = v3412 
            (* run_target_args'
            let v3418 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3420 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3418 = v3420 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3424 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3418 = v3424 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3428 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3418 = v3428 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3432 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3418 = v3432 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3436 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3418 = v3436 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3440 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3418 = v3440 
            #endif
#else
            let v3443 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v3418 = v3443 
            #endif
            let v3444 : System_Net_Sockets_TcpClient = _run_target_args'_v3418 
            use v3444 = v3444 
            let v3450 : System_Net_Sockets_TcpClient = v3444 
            try
                (* run_target_args'
                let v3455 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3457 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3455 = v3457 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3461 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3455 = v3461 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3465 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3455 = v3465 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3469 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3455 = v3469 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3473 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3455 = v3473 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3477 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3455 = v3477 
                #endif
#else
                let v3480 : System.Threading.Tasks.ValueTask = v3450.ConnectAsync (v0, v1, v3413)
                let _run_target_args'_v3455 = v3480 
                #endif
                let v3481 : System.Threading.Tasks.ValueTask = _run_target_args'_v3455 
                (* run_target_args'
                let v3491 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3493 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3491 = v3493 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3497 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3491 = v3497 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3501 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3491 = v3501 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3505 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3491 = v3505 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3509 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3491 = v3509 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3513 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3491 = v3513 
                #endif
#else
                let v3516 : (unit -> System.Threading.Tasks.Task) = v3481.AsTask
                let v3517 : System.Threading.Tasks.Task = v3516 ()
                let _run_target_args'_v3491 = v3517 
                #endif
                let v3518 : System.Threading.Tasks.Task = _run_target_args'_v3491 
                (* run_target_args'
                let v3528 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3530 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v3528 = v3530 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3534 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v3528 = v3534 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3538 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v3528 = v3538 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3541 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3542 : Async<unit> = v3541 v3518
                let _run_target_args'_v3528 = v3542 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3543 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3544 : Async<unit> = v3543 v3518
                let _run_target_args'_v3528 = v3544 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3545 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3546 : Async<unit> = v3545 v3518
                let _run_target_args'_v3528 = v3546 
                #endif
#else
                let v3547 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3548 : Async<unit> = v3547 v3518
                let _run_target_args'_v3528 = v3548 
                #endif
                let v3549 : Async<unit> = _run_target_args'_v3528 
                do! v3549 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v3659 : exn = ex
                let v3660 : unit = ()
                let v3661 : (unit -> unit) = closure5(v1, v3659)
                let v3662 : unit = (fun () -> v3661 (); v3660) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v3832 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6796 : Async<bool> = _let'_v3409 
    let _run_target_args'_v6 = v6796 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v6798 : unit = ()
    let _let'_v6798 =
        async {
            let v6801 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v6801 = v6801 
            let v6802 : System.Threading.CancellationToken = v6801 
            (* run_target_args'
            let v6807 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6809 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6807 = v6809 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6813 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6807 = v6813 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6817 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6807 = v6817 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6821 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6807 = v6821 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6825 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6807 = v6825 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6829 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6807 = v6829 
            #endif
#else
            let v6832 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v6807 = v6832 
            #endif
            let v6833 : System_Net_Sockets_TcpClient = _run_target_args'_v6807 
            use v6833 = v6833 
            let v6839 : System_Net_Sockets_TcpClient = v6833 
            try
                (* run_target_args'
                let v6844 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6846 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6844 = v6846 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6850 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6844 = v6850 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6854 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6844 = v6854 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6858 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6844 = v6858 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6862 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6844 = v6862 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6866 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6844 = v6866 
                #endif
#else
                let v6869 : System.Threading.Tasks.ValueTask = v6839.ConnectAsync (v0, v1, v6802)
                let _run_target_args'_v6844 = v6869 
                #endif
                let v6870 : System.Threading.Tasks.ValueTask = _run_target_args'_v6844 
                (* run_target_args'
                let v6880 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6882 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6880 = v6882 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6886 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6880 = v6886 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6890 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6880 = v6890 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6894 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6880 = v6894 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6898 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6880 = v6898 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6902 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6880 = v6902 
                #endif
#else
                let v6905 : (unit -> System.Threading.Tasks.Task) = v6870.AsTask
                let v6906 : System.Threading.Tasks.Task = v6905 ()
                let _run_target_args'_v6880 = v6906 
                #endif
                let v6907 : System.Threading.Tasks.Task = _run_target_args'_v6880 
                (* run_target_args'
                let v6917 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6919 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v6917 = v6919 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6923 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v6917 = v6923 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6927 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v6917 = v6927 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6930 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6931 : Async<unit> = v6930 v6907
                let _run_target_args'_v6917 = v6931 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6932 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6933 : Async<unit> = v6932 v6907
                let _run_target_args'_v6917 = v6933 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6934 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6935 : Async<unit> = v6934 v6907
                let _run_target_args'_v6917 = v6935 
                #endif
#else
                let v6936 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6937 : Async<unit> = v6936 v6907
                let _run_target_args'_v6917 = v6937 
                #endif
                let v6938 : Async<unit> = _run_target_args'_v6917 
                do! v6938 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v7048 : exn = ex
                let v7049 : unit = ()
                let v7050 : (unit -> unit) = closure5(v1, v7048)
                let v7051 : unit = (fun () -> v7050 (); v7049) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v7221 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v10185 : Async<bool> = _let'_v6798 
    let _run_target_args'_v6 = v10185 
    #endif
#else
    let v10187 : unit = ()
    let _let'_v10187 =
        async {
            let v10190 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v10190 = v10190 
            let v10191 : System.Threading.CancellationToken = v10190 
            (* run_target_args'
            let v10196 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v10198 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10196 = v10198 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v10202 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10196 = v10202 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v10206 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10196 = v10206 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v10210 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10196 = v10210 
            #endif
#if FABLE_COMPILER_PYTHON
            let v10214 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10196 = v10214 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v10218 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10196 = v10218 
            #endif
#else
            let v10221 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v10196 = v10221 
            #endif
            let v10222 : System_Net_Sockets_TcpClient = _run_target_args'_v10196 
            use v10222 = v10222 
            let v10228 : System_Net_Sockets_TcpClient = v10222 
            try
                (* run_target_args'
                let v10233 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10235 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10233 = v10235 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10239 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10233 = v10239 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10243 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10233 = v10243 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10247 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10233 = v10247 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10251 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10233 = v10251 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10255 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10233 = v10255 
                #endif
#else
                let v10258 : System.Threading.Tasks.ValueTask = v10228.ConnectAsync (v0, v1, v10191)
                let _run_target_args'_v10233 = v10258 
                #endif
                let v10259 : System.Threading.Tasks.ValueTask = _run_target_args'_v10233 
                (* run_target_args'
                let v10269 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10271 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10269 = v10271 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10275 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10269 = v10275 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10279 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10269 = v10279 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10283 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10269 = v10283 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10287 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10269 = v10287 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10291 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10269 = v10291 
                #endif
#else
                let v10294 : (unit -> System.Threading.Tasks.Task) = v10259.AsTask
                let v10295 : System.Threading.Tasks.Task = v10294 ()
                let _run_target_args'_v10269 = v10295 
                #endif
                let v10296 : System.Threading.Tasks.Task = _run_target_args'_v10269 
                (* run_target_args'
                let v10306 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10308 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v10306 = v10308 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10312 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v10306 = v10312 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10316 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v10306 = v10316 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10319 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10320 : Async<unit> = v10319 v10296
                let _run_target_args'_v10306 = v10320 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10321 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10322 : Async<unit> = v10321 v10296
                let _run_target_args'_v10306 = v10322 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10323 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10324 : Async<unit> = v10323 v10296
                let _run_target_args'_v10306 = v10324 
                #endif
#else
                let v10325 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10326 : Async<unit> = v10325 v10296
                let _run_target_args'_v10306 = v10326 
                #endif
                let v10327 : Async<unit> = _run_target_args'_v10306 
                do! v10327 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v10437 : exn = ex
                let v10438 : unit = ()
                let v10439 : (unit -> unit) = closure5(v1, v10437)
                let v10440 : unit = (fun () -> v10439 (); v10438) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v10610 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v13574 : Async<bool> = _let'_v10187 
    let _run_target_args'_v6 = v13574 
    #endif
    let v13575 : Async<bool> = _run_target_args'_v6 
    v13575
and method6 (v0 : string, v1 : int32) : Async<bool> =
    method7(v0, v1)
and closure4 (v0 : string) (v1 : int32) : Async<bool> =
    method6(v0, v1)
and closure3 () (v0 : string) : (int32 -> Async<bool>) =
    closure4(v0)
and closure14 () (v0 : bool) : US7 =
    US7_0(v0)
and method26 () : (bool -> US7) =
    closure14()
and closure15 () (v0 : exn) : US7 =
    US7_1(v0)
and method27 () : (exn -> US7) =
    closure15()
and method25 (v0 : Async<Choice<bool, exn>>) : Async<US7> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US7> = null |> unbox<Async<US7>>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : Async<US7> = null |> unbox<Async<US7>>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : Async<US7> = null |> unbox<Async<US7>>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : unit = ()
    let _let'_v19 =
        async {
            let! v0 = v0 
            let v22 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v27 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v29 : US7 = null |> unbox<US7>
            let _run_target_args'_v27 = v29 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v33 : US7 = null |> unbox<US7>
            let _run_target_args'_v27 = v33 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v37 : US7 = null |> unbox<US7>
            let _run_target_args'_v27 = v37 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v41 : US7 = null |> unbox<US7>
            let _run_target_args'_v27 = v41 
            #endif
#if FABLE_COMPILER_PYTHON
            let v45 : US7 = null |> unbox<US7>
            let _run_target_args'_v27 = v45 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v48 : (bool -> US7) = method26()
            let v49 : (exn -> US7) = method27()
            let v50 : US7 = match v22 with Choice1Of2 x -> v48 x | Choice2Of2 x -> v49 x
            let _run_target_args'_v27 = v50 
            #endif
#else
            let v51 : (bool -> US7) = method26()
            let v52 : (exn -> US7) = method27()
            let v53 : US7 = match v22 with Choice1Of2 x -> v51 x | Choice2Of2 x -> v52 x
            let _run_target_args'_v27 = v53 
            #endif
            let v54 : US7 = _run_target_args'_v27 
            return v54 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v326 : Async<US7> = _let'_v19 
    let _run_target_args'_v5 = v326 
    #endif
#if FABLE_COMPILER_PYTHON
    let v328 : unit = ()
    let _let'_v328 =
        async {
            let! v0 = v0 
            let v331 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v336 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v338 : US7 = null |> unbox<US7>
            let _run_target_args'_v336 = v338 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v342 : US7 = null |> unbox<US7>
            let _run_target_args'_v336 = v342 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v346 : US7 = null |> unbox<US7>
            let _run_target_args'_v336 = v346 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v350 : US7 = null |> unbox<US7>
            let _run_target_args'_v336 = v350 
            #endif
#if FABLE_COMPILER_PYTHON
            let v354 : US7 = null |> unbox<US7>
            let _run_target_args'_v336 = v354 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v357 : (bool -> US7) = method26()
            let v358 : (exn -> US7) = method27()
            let v359 : US7 = match v331 with Choice1Of2 x -> v357 x | Choice2Of2 x -> v358 x
            let _run_target_args'_v336 = v359 
            #endif
#else
            let v360 : (bool -> US7) = method26()
            let v361 : (exn -> US7) = method27()
            let v362 : US7 = match v331 with Choice1Of2 x -> v360 x | Choice2Of2 x -> v361 x
            let _run_target_args'_v336 = v362 
            #endif
            let v363 : US7 = _run_target_args'_v336 
            return v363 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v635 : Async<US7> = _let'_v328 
    let _run_target_args'_v5 = v635 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v637 : unit = ()
    let _let'_v637 =
        async {
            let! v0 = v0 
            let v640 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v645 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v647 : US7 = null |> unbox<US7>
            let _run_target_args'_v645 = v647 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v651 : US7 = null |> unbox<US7>
            let _run_target_args'_v645 = v651 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v655 : US7 = null |> unbox<US7>
            let _run_target_args'_v645 = v655 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v659 : US7 = null |> unbox<US7>
            let _run_target_args'_v645 = v659 
            #endif
#if FABLE_COMPILER_PYTHON
            let v663 : US7 = null |> unbox<US7>
            let _run_target_args'_v645 = v663 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v666 : (bool -> US7) = method26()
            let v667 : (exn -> US7) = method27()
            let v668 : US7 = match v640 with Choice1Of2 x -> v666 x | Choice2Of2 x -> v667 x
            let _run_target_args'_v645 = v668 
            #endif
#else
            let v669 : (bool -> US7) = method26()
            let v670 : (exn -> US7) = method27()
            let v671 : US7 = match v640 with Choice1Of2 x -> v669 x | Choice2Of2 x -> v670 x
            let _run_target_args'_v645 = v671 
            #endif
            let v672 : US7 = _run_target_args'_v645 
            return v672 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v944 : Async<US7> = _let'_v637 
    let _run_target_args'_v5 = v944 
    #endif
#else
    let v946 : unit = ()
    let _let'_v946 =
        async {
            let! v0 = v0 
            let v949 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v954 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v956 : US7 = null |> unbox<US7>
            let _run_target_args'_v954 = v956 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v960 : US7 = null |> unbox<US7>
            let _run_target_args'_v954 = v960 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v964 : US7 = null |> unbox<US7>
            let _run_target_args'_v954 = v964 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v968 : US7 = null |> unbox<US7>
            let _run_target_args'_v954 = v968 
            #endif
#if FABLE_COMPILER_PYTHON
            let v972 : US7 = null |> unbox<US7>
            let _run_target_args'_v954 = v972 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v975 : (bool -> US7) = method26()
            let v976 : (exn -> US7) = method27()
            let v977 : US7 = match v949 with Choice1Of2 x -> v975 x | Choice2Of2 x -> v976 x
            let _run_target_args'_v954 = v977 
            #endif
#else
            let v978 : (bool -> US7) = method26()
            let v979 : (exn -> US7) = method27()
            let v980 : US7 = match v949 with Choice1Of2 x -> v978 x | Choice2Of2 x -> v979 x
            let _run_target_args'_v954 = v980 
            #endif
            let v981 : US7 = _run_target_args'_v954 
            return v981 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1253 : Async<US7> = _let'_v946 
    let _run_target_args'_v5 = v1253 
    #endif
    let v1254 : Async<US7> = _run_target_args'_v5 
    v1254
and method28 (v0 : Async<US7>) : Async<US8> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US8> = null |> unbox<Async<US8>>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : Async<US8> = null |> unbox<Async<US8>>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : Async<US8> = null |> unbox<Async<US8>>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : unit = ()
    let _let'_v19 =
        async {
            let! v0 = v0 
            let v22 : US7 = v0 
            let v28 : US8 =
                match v22 with
                | US7_0(v23) -> (* C1of2 *)
                    US8_0(v23)
                | US7_1(v25) -> (* C2of2 *)
                    US8_1(v25)
            return v28 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v78 : Async<US8> = _let'_v19 
    let _run_target_args'_v5 = v78 
    #endif
#if FABLE_COMPILER_PYTHON
    let v80 : unit = ()
    let _let'_v80 =
        async {
            let! v0 = v0 
            let v83 : US7 = v0 
            let v89 : US8 =
                match v83 with
                | US7_0(v84) -> (* C1of2 *)
                    US8_0(v84)
                | US7_1(v86) -> (* C2of2 *)
                    US8_1(v86)
            return v89 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v139 : Async<US8> = _let'_v80 
    let _run_target_args'_v5 = v139 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v141 : unit = ()
    let _let'_v141 =
        async {
            let! v0 = v0 
            let v144 : US7 = v0 
            let v150 : US8 =
                match v144 with
                | US7_0(v145) -> (* C1of2 *)
                    US8_0(v145)
                | US7_1(v147) -> (* C2of2 *)
                    US8_1(v147)
            return v150 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v200 : Async<US8> = _let'_v141 
    let _run_target_args'_v5 = v200 
    #endif
#else
    let v202 : unit = ()
    let _let'_v202 =
        async {
            let! v0 = v0 
            let v205 : US7 = v0 
            let v211 : US8 =
                match v205 with
                | US7_0(v206) -> (* C1of2 *)
                    US8_0(v206)
                | US7_1(v208) -> (* C2of2 *)
                    US8_1(v208)
            return v211 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v261 : Async<US8> = _let'_v202 
    let _run_target_args'_v5 = v261 
    #endif
    let v262 : Async<US8> = _run_target_args'_v5 
    v262
and method31 (v0 : int32) : string =
    let v1 : string = method15()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure7(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "timeout"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure7(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure7(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    let v34 : string = $"{v0}"
    let v37 : unit = ()
    let v38 : (unit -> unit) = closure7(v2, v34)
    let v39 : unit = (fun () -> v38 (); v37) ()
    let v43 : string = " }"
    let v44 : string = $"{v43}"
    let v47 : unit = ()
    let v48 : (unit -> unit) = closure7(v2, v44)
    let v49 : unit = (fun () -> v48 (); v47) ()
    let v52 : string = v2.l0
    v52
and method30 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32) : string =
    let v9 : string = method31(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "async.run_with_timeout_async"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method19(v13)
and closure16 (v0 : int32) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method8(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure0()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method9(v26, v27, v28, v29, v30, v31)
        let v45 : string = method13()
        let v46 : string = method30(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method20(v46)
and method32 () : string =
    
    
    
    
    
    let v1 : string = "Critical"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method14(v6)
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
    let v137 : string = method16()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[91m"
    let v141 : string = method16()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[91m"
    let v145 : string = method16()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[91m"
    let v149 : string = method16()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method34 (v0 : int32, v1 : string) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure7(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "timeout"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure7(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure7(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure7(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure7(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "ex"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure7(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure7(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v1}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure7(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure7(v3, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v3.l0
    v91
and method33 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method34(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "async.run_with_timeout_async**"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method19(v14)
and closure17 (v0 : int32, v1 : exn) () : unit =
    let v2 : US0 = US0_4
    let v3 : bool = method8(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method9(v27, v28, v29, v30, v31, v32)
        let v46 : string = method32()
        (* run_target_args'
        let v51 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v53 : string = $"%A{v1}"
        let _run_target_args'_v51 = v53 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v57 : string = $"%A{v1}"
        let _run_target_args'_v51 = v57 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v61 : string = $"%A{v1}"
        let _run_target_args'_v51 = v61 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v65 : string = $"%A{v1}"
        let _run_target_args'_v51 = v65 
        #endif
#if FABLE_COMPILER_PYTHON
        let v69 : string = $"%A{v1}"
        let _run_target_args'_v51 = v69 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v73 : string = $"%A{v1}"
        let _run_target_args'_v51 = v73 
        #endif
#else
        let v76 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v51 = v76 
        #endif
        let v77 : string = _run_target_args'_v51 
        let v83 : string = method33(v27, v28, v29, v30, v31, v32, v45, v46, v0, v77)
        method20(v83)
and method29 (v0 : int32, v1 : Async<US8>) : Async<US6> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US6> = null |> unbox<Async<US6>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US6> = null |> unbox<Async<US6>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US6> = null |> unbox<Async<US6>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let! v1 = v1 
            let v23 : US8 = v1 
            let v174 : US6 =
                match v23 with
                | US8_1(v26) -> (* Error *)
                    let v28 : string = $"%A{v26}"
                    let v32 : string = "System.TimeoutException"
                    let v33 : bool = v28.Contains v32 
                    if v33 then
                        let v36 : unit = ()
                        let v37 : (unit -> unit) = closure16(v0)
                        let v38 : unit = (fun () -> v37 (); v36) ()
                        US6_1
                    else
                        let v86 : unit = ()
                        let v87 : (unit -> unit) = closure17(v0, v26)
                        let v88 : unit = (fun () -> v87 (); v86) ()
                        US6_1
                | US8_0(v24) -> (* Ok *)
                    US6_0(v24)
            return v174 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1239 : Async<US6> = _let'_v20 
    let _run_target_args'_v6 = v1239 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1241 : unit = ()
    let _let'_v1241 =
        async {
            let! v1 = v1 
            let v1244 : US8 = v1 
            let v1395 : US6 =
                match v1244 with
                | US8_1(v1247) -> (* Error *)
                    let v1249 : string = $"%A{v1247}"
                    let v1253 : string = "System.TimeoutException"
                    let v1254 : bool = v1249.Contains v1253 
                    if v1254 then
                        let v1257 : unit = ()
                        let v1258 : (unit -> unit) = closure16(v0)
                        let v1259 : unit = (fun () -> v1258 (); v1257) ()
                        US6_1
                    else
                        let v1307 : unit = ()
                        let v1308 : (unit -> unit) = closure17(v0, v1247)
                        let v1309 : unit = (fun () -> v1308 (); v1307) ()
                        US6_1
                | US8_0(v1245) -> (* Ok *)
                    US6_0(v1245)
            return v1395 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2460 : Async<US6> = _let'_v1241 
    let _run_target_args'_v6 = v2460 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2462 : unit = ()
    let _let'_v2462 =
        async {
            let! v1 = v1 
            let v2465 : US8 = v1 
            let v2616 : US6 =
                match v2465 with
                | US8_1(v2468) -> (* Error *)
                    let v2470 : string = $"%A{v2468}"
                    let v2474 : string = "System.TimeoutException"
                    let v2475 : bool = v2470.Contains v2474 
                    if v2475 then
                        let v2478 : unit = ()
                        let v2479 : (unit -> unit) = closure16(v0)
                        let v2480 : unit = (fun () -> v2479 (); v2478) ()
                        US6_1
                    else
                        let v2528 : unit = ()
                        let v2529 : (unit -> unit) = closure17(v0, v2468)
                        let v2530 : unit = (fun () -> v2529 (); v2528) ()
                        US6_1
                | US8_0(v2466) -> (* Ok *)
                    US6_0(v2466)
            return v2616 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3681 : Async<US6> = _let'_v2462 
    let _run_target_args'_v6 = v3681 
    #endif
#else
    let v3683 : unit = ()
    let _let'_v3683 =
        async {
            let! v1 = v1 
            let v3686 : US8 = v1 
            let v3837 : US6 =
                match v3686 with
                | US8_1(v3689) -> (* Error *)
                    let v3691 : string = $"%A{v3689}"
                    let v3695 : string = "System.TimeoutException"
                    let v3696 : bool = v3691.Contains v3695 
                    if v3696 then
                        let v3699 : unit = ()
                        let v3700 : (unit -> unit) = closure16(v0)
                        let v3701 : unit = (fun () -> v3700 (); v3699) ()
                        US6_1
                    else
                        let v3749 : unit = ()
                        let v3750 : (unit -> unit) = closure17(v0, v3689)
                        let v3751 : unit = (fun () -> v3750 (); v3749) ()
                        US6_1
                | US8_0(v3687) -> (* Ok *)
                    US6_0(v3687)
            return v3837 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4902 : Async<US6> = _let'_v3683 
    let _run_target_args'_v6 = v4902 
    #endif
    let v4903 : Async<US6> = _run_target_args'_v6 
    v4903
and method24 (v0 : Async<bool>, v1 : int32) : Async<US6> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US6> = null |> unbox<Async<US6>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US6> = null |> unbox<Async<US6>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US6> = null |> unbox<Async<US6>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            (* run_target_args'
            let v27 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v29 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v27 = v29 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v33 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v27 = v33 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v37 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v27 = v37 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v40 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v27 = v40 
            #endif
#if FABLE_COMPILER_PYTHON
            let v41 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v27 = v41 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v42 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v27 = v42 
            #endif
#else
            let v43 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v27 = v43 
            #endif
            let v44 : Async<Async<bool>> = _run_target_args'_v27 
            let! v44 = v44 
            let v50 : Async<bool> = v44 
            (* run_target_args'
            let v55 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v57 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v55 = v57 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v55 = v61 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v65 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v55 = v65 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v68 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v69 : Async<Choice<bool, exn>> = v68 v50
            let _run_target_args'_v55 = v69 
            #endif
#if FABLE_COMPILER_PYTHON
            let v70 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v71 : Async<Choice<bool, exn>> = v70 v50
            let _run_target_args'_v55 = v71 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v72 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v73 : Async<Choice<bool, exn>> = v72 v50
            let _run_target_args'_v55 = v73 
            #endif
#else
            let v74 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v75 : Async<Choice<bool, exn>> = v74 v50
            let _run_target_args'_v55 = v75 
            #endif
            let v76 : Async<Choice<bool, exn>> = _run_target_args'_v55 
            let v82 : Async<US7> = method25(v76)
            let v83 : Async<US8> = method28(v82)
            let v84 : Async<US6> = method29(v1, v83)
            return! v84 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v519 : Async<US6> = _let'_v20 
    let _run_target_args'_v6 = v519 
    #endif
#if FABLE_COMPILER_PYTHON
    let v521 : unit = ()
    let _let'_v521 =
        async {
            (* run_target_args'
            let v528 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v530 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v528 = v530 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v534 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v528 = v534 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v538 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v528 = v538 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v541 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v528 = v541 
            #endif
#if FABLE_COMPILER_PYTHON
            let v542 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v528 = v542 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v543 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v528 = v543 
            #endif
#else
            let v544 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v528 = v544 
            #endif
            let v545 : Async<Async<bool>> = _run_target_args'_v528 
            let! v545 = v545 
            let v551 : Async<bool> = v545 
            (* run_target_args'
            let v556 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v558 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v556 = v558 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v562 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v556 = v562 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v566 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v556 = v566 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v569 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v570 : Async<Choice<bool, exn>> = v569 v551
            let _run_target_args'_v556 = v570 
            #endif
#if FABLE_COMPILER_PYTHON
            let v571 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v572 : Async<Choice<bool, exn>> = v571 v551
            let _run_target_args'_v556 = v572 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v573 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v574 : Async<Choice<bool, exn>> = v573 v551
            let _run_target_args'_v556 = v574 
            #endif
#else
            let v575 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v576 : Async<Choice<bool, exn>> = v575 v551
            let _run_target_args'_v556 = v576 
            #endif
            let v577 : Async<Choice<bool, exn>> = _run_target_args'_v556 
            let v583 : Async<US7> = method25(v577)
            let v584 : Async<US8> = method28(v583)
            let v585 : Async<US6> = method29(v1, v584)
            return! v585 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1020 : Async<US6> = _let'_v521 
    let _run_target_args'_v6 = v1020 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1022 : unit = ()
    let _let'_v1022 =
        async {
            (* run_target_args'
            let v1029 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1031 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v1029 = v1031 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1035 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v1029 = v1035 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1039 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v1029 = v1039 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1042 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1029 = v1042 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1043 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1029 = v1043 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1044 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1029 = v1044 
            #endif
#else
            let v1045 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1029 = v1045 
            #endif
            let v1046 : Async<Async<bool>> = _run_target_args'_v1029 
            let! v1046 = v1046 
            let v1052 : Async<bool> = v1046 
            (* run_target_args'
            let v1057 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1059 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v1057 = v1059 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1063 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v1057 = v1063 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1067 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v1057 = v1067 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1070 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v1071 : Async<Choice<bool, exn>> = v1070 v1052
            let _run_target_args'_v1057 = v1071 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1072 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v1073 : Async<Choice<bool, exn>> = v1072 v1052
            let _run_target_args'_v1057 = v1073 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1074 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v1075 : Async<Choice<bool, exn>> = v1074 v1052
            let _run_target_args'_v1057 = v1075 
            #endif
#else
            let v1076 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v1077 : Async<Choice<bool, exn>> = v1076 v1052
            let _run_target_args'_v1057 = v1077 
            #endif
            let v1078 : Async<Choice<bool, exn>> = _run_target_args'_v1057 
            let v1084 : Async<US7> = method25(v1078)
            let v1085 : Async<US8> = method28(v1084)
            let v1086 : Async<US6> = method29(v1, v1085)
            return! v1086 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1521 : Async<US6> = _let'_v1022 
    let _run_target_args'_v6 = v1521 
    #endif
#else
    let v1523 : unit = ()
    let _let'_v1523 =
        async {
            (* run_target_args'
            let v1530 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1532 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v1530 = v1532 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1536 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v1530 = v1536 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1540 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v1530 = v1540 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1543 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1530 = v1543 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1544 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1530 = v1544 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1545 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1530 = v1545 
            #endif
#else
            let v1546 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1530 = v1546 
            #endif
            let v1547 : Async<Async<bool>> = _run_target_args'_v1530 
            let! v1547 = v1547 
            let v1553 : Async<bool> = v1547 
            (* run_target_args'
            let v1558 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1560 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v1558 = v1560 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1564 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v1558 = v1564 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1568 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v1558 = v1568 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1571 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v1572 : Async<Choice<bool, exn>> = v1571 v1553
            let _run_target_args'_v1558 = v1572 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1573 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v1574 : Async<Choice<bool, exn>> = v1573 v1553
            let _run_target_args'_v1558 = v1574 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1575 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v1576 : Async<Choice<bool, exn>> = v1575 v1553
            let _run_target_args'_v1558 = v1576 
            #endif
#else
            let v1577 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v1578 : Async<Choice<bool, exn>> = v1577 v1553
            let _run_target_args'_v1558 = v1578 
            #endif
            let v1579 : Async<Choice<bool, exn>> = _run_target_args'_v1558 
            let v1585 : Async<US7> = method25(v1579)
            let v1586 : Async<US8> = method28(v1585)
            let v1587 : Async<US6> = method29(v1, v1586)
            return! v1587 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2022 : Async<US6> = _let'_v1523 
    let _run_target_args'_v6 = v2022 
    #endif
    let v2023 : Async<US6> = _run_target_args'_v6 
    v2023
and method23 (v0 : int32, v1 : Async<bool>) : Async<US6> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US6> = method24(v1, v0)
    let _run_target_args'_v6 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : Async<US6> = method24(v1, v0)
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US6> = method24(v1, v0)
    let _run_target_args'_v6 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : Async<US6> = method24(v1, v0)
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : Async<US6> = method24(v1, v0)
    let _run_target_args'_v6 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : Async<US6> = method24(v1, v0)
    let _run_target_args'_v6 = v12 
    #endif
#else
    let v13 : Async<US6> = method24(v1, v0)
    let _run_target_args'_v6 = v13 
    #endif
    let v14 : Async<US6> = _run_target_args'_v6 
    v14
and method22 (v0 : int32, v1 : string, v2 : int32) : Async<bool> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v7 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v7 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v17 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v7 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : unit = ()
    let _let'_v21 =
        async {
            let v24 : Async<bool> = method6(v1, v2)
            let v25 : Async<US6> = method23(v0, v24)
            let! v25 = v25 
            let v26 : US6 = v25 
            let v29 : bool =
                match v26 with
                | US6_1 -> (* None *)
                    false
                | US6_0(v27) -> (* Some *)
                    v27
            return v29 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v72 : Async<bool> = _let'_v21 
    let _run_target_args'_v7 = v72 
    #endif
#if FABLE_COMPILER_PYTHON
    let v74 : unit = ()
    let _let'_v74 =
        async {
            let v77 : Async<bool> = method6(v1, v2)
            let v78 : Async<US6> = method23(v0, v77)
            let! v78 = v78 
            let v79 : US6 = v78 
            let v82 : bool =
                match v79 with
                | US6_1 -> (* None *)
                    false
                | US6_0(v80) -> (* Some *)
                    v80
            return v82 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v125 : Async<bool> = _let'_v74 
    let _run_target_args'_v7 = v125 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v127 : unit = ()
    let _let'_v127 =
        async {
            let v130 : Async<bool> = method6(v1, v2)
            let v131 : Async<US6> = method23(v0, v130)
            let! v131 = v131 
            let v132 : US6 = v131 
            let v135 : bool =
                match v132 with
                | US6_1 -> (* None *)
                    false
                | US6_0(v133) -> (* Some *)
                    v133
            return v135 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v178 : Async<bool> = _let'_v127 
    let _run_target_args'_v7 = v178 
    #endif
#else
    let v180 : unit = ()
    let _let'_v180 =
        async {
            let v183 : Async<bool> = method6(v1, v2)
            let v184 : Async<US6> = method23(v0, v183)
            let! v184 = v184 
            let v185 : US6 = v184 
            let v188 : bool =
                match v185 with
                | US6_1 -> (* None *)
                    false
                | US6_0(v186) -> (* Some *)
                    v186
            return v188 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v231 : Async<bool> = _let'_v180 
    let _run_target_args'_v7 = v231 
    #endif
    let v232 : Async<bool> = _run_target_args'_v7 
    v232
and method21 (v0 : int32, v1 : string, v2 : int32) : Async<bool> =
    method22(v0, v1, v2)
and closure13 (v0 : int32, v1 : string) (v2 : int32) : Async<bool> =
    method21(v0, v1, v2)
and closure12 (v0 : int32) (v1 : string) : (int32 -> Async<bool>) =
    closure13(v0, v1)
and closure11 () (v0 : int32) : (string -> (int32 -> Async<bool>)) =
    closure12(v0)
and closure22 () (v0 : int32) : US9 =
    US9_0(v0)
and method38 () : (int32 -> US9) =
    closure22()
and method40 (v0 : int32, v1 : int64, v2 : int32 option, v3 : bool) : string =
    let v4 : string = method15()
    let v5 : Mut3 = {l0 = v4} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v11 : unit = ()
    let v12 : (unit -> unit) = closure7(v5, v8)
    let v13 : unit = (fun () -> v12 (); v11) ()
    let v17 : string = "port"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure7(v5, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure7(v5, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    let v37 : string = $"{v0}"
    let v40 : unit = ()
    let v41 : (unit -> unit) = closure7(v5, v37)
    let v42 : unit = (fun () -> v41 (); v40) ()
    let v46 : string = "; "
    let v47 : string = $"{v46}"
    let v50 : unit = ()
    let v51 : (unit -> unit) = closure7(v5, v47)
    let v52 : unit = (fun () -> v51 (); v50) ()
    let v56 : string = "retry"
    let v57 : string = $"{v56}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure7(v5, v57)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v66 : string = $"{v27}"
    let v69 : unit = ()
    let v70 : (unit -> unit) = closure7(v5, v66)
    let v71 : unit = (fun () -> v70 (); v69) ()
    let v75 : string = $"{v1}"
    let v78 : unit = ()
    let v79 : (unit -> unit) = closure7(v5, v75)
    let v80 : unit = (fun () -> v79 (); v78) ()
    let v84 : string = $"{v46}"
    let v87 : unit = ()
    let v88 : (unit -> unit) = closure7(v5, v84)
    let v89 : unit = (fun () -> v88 (); v87) ()
    let v93 : string = "timeout"
    let v94 : string = $"{v93}"
    let v97 : unit = ()
    let v98 : (unit -> unit) = closure7(v5, v94)
    let v99 : unit = (fun () -> v98 (); v97) ()
    let v103 : string = $"{v27}"
    let v106 : unit = ()
    let v107 : (unit -> unit) = closure7(v5, v103)
    let v108 : unit = (fun () -> v107 (); v106) ()
    (* run_target_args'
    let v115 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v116 : string = "format!(\"{:#?}\", $0)"
    let v117 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v116 
    let v118 : string = "fable_library_rust::String_::fromString($0)"
    let v119 : string = Fable.Core.RustInterop.emitRustExpr v117 v118 
    let _run_target_args'_v115 = v119 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v120 : string = "format!(\"{:#?}\", $0)"
    let v121 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v120 
    let v122 : string = "fable_library_rust::String_::fromString($0)"
    let v123 : string = Fable.Core.RustInterop.emitRustExpr v121 v122 
    let _run_target_args'_v115 = v123 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v124 : string = "format!(\"{:#?}\", $0)"
    let v125 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v124 
    let v126 : string = "fable_library_rust::String_::fromString($0)"
    let v127 : string = Fable.Core.RustInterop.emitRustExpr v125 v126 
    let _run_target_args'_v115 = v127 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v129 : string = $"%A{v2}"
    let _run_target_args'_v115 = v129 
    #endif
#if FABLE_COMPILER_PYTHON
    let v133 : string = $"%A{v2}"
    let _run_target_args'_v115 = v133 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v137 : string = $"%A{v2}"
    let _run_target_args'_v115 = v137 
    #endif
#else
    let v141 : string = $"%A{v2}"
    let _run_target_args'_v115 = v141 
    #endif
    let v144 : string = _run_target_args'_v115 
    let v151 : string = $"{v144}"
    let v154 : unit = ()
    let v155 : (unit -> unit) = closure7(v5, v151)
    let v156 : unit = (fun () -> v155 (); v154) ()
    let v160 : string = $"{v46}"
    let v163 : unit = ()
    let v164 : (unit -> unit) = closure7(v5, v160)
    let v165 : unit = (fun () -> v164 (); v163) ()
    let v169 : string = "status"
    let v170 : string = $"{v169}"
    let v173 : unit = ()
    let v174 : (unit -> unit) = closure7(v5, v170)
    let v175 : unit = (fun () -> v174 (); v173) ()
    let v179 : string = $"{v27}"
    let v182 : unit = ()
    let v183 : (unit -> unit) = closure7(v5, v179)
    let v184 : unit = (fun () -> v183 (); v182) ()
    let v189 : string =
        if v3 then
            let v187 : string = "true"
            v187
        else
            let v188 : string = "false"
            v188
    let v191 : string = $"{v189}"
    let v194 : unit = ()
    let v195 : (unit -> unit) = closure7(v5, v191)
    let v196 : unit = (fun () -> v195 (); v194) ()
    let v200 : string = " }"
    let v201 : string = $"{v200}"
    let v204 : unit = ()
    let v205 : (unit -> unit) = closure7(v5, v201)
    let v206 : unit = (fun () -> v205 (); v204) ()
    let v209 : string = v5.l0
    v209
and method39 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : int64, v10 : int32 option, v11 : bool) : string =
    let v12 : string = method40(v8, v9, v10, v11)
    let v13 : int64 = v0.l0
    let v15 : string = "networking.wait_for_port_access"
    let v16 : string = $"{v6} {v7} #{v13} %s{v15} / {v12}"
    method19(v16)
and closure23 (v0 : int32 option, v1 : bool, v2 : int32, v3 : int64) () : unit =
    let v4 : US0 = US0_0
    let v5 : bool = method8(v4)
    if v5 then
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method9(v29, v30, v31, v32, v33, v34)
        let v48 : string = method13()
        let v49 : string = method39(v29, v30, v31, v32, v33, v34, v47, v48, v2, v3, v0, v1)
        method20(v49)
and method37 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32, v4 : int64) : Async<int64> =
    (* run_target_args'
    let v9 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v9 = v11 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v15 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v9 = v15 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v19 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v9 = v19 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v23 : unit = ()
    let _let'_v23 =
        async {
            let v28 : (int32 -> US9) = method38()
            let v29 : US9 option = v0 |> Option.map v28 
            let v43 : US9 = US9_1
            let v44 : US9 = v29 |> Option.defaultValue v43 
            let v52 : Async<bool> =
                match v44 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v49) -> (* Some *)
                    method21(v49, v2, v3)
            let! v52 = v52 
            let v53 : bool = v52 
            let v54 : bool = v53 = v1
            if v54 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v55 : int64 = v4 % 100L
                let v56 : bool = v55 = 0L
                if v56 then
                    let v57 : unit = ()
                    let v58 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v59 : unit = (fun () -> v58 (); v57) ()
                    ()
                (* run_target_args'
                let v110 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v111 : (int32 -> Async<unit>) = Async.Sleep
                let v112 : Async<unit> = v111 10
                let _run_target_args'_v110 = v112 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v113 : (int32 -> Async<unit>) = Async.Sleep
                let v114 : Async<unit> = v113 10
                let _run_target_args'_v110 = v114 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v115 : (int32 -> Async<unit>) = Async.Sleep
                let v116 : Async<unit> = v115 10
                let _run_target_args'_v110 = v116 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v117 : (int32 -> Async<unit>) = Async.Sleep
                let v118 : Async<unit> = v117 10
                let _run_target_args'_v110 = v118 
                #endif
#if FABLE_COMPILER_PYTHON
                let v119 : (int32 -> Async<unit>) = Async.Sleep
                let v120 : Async<unit> = v119 10
                let _run_target_args'_v110 = v120 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v121 : (int32 -> Async<unit>) = Async.Sleep
                let v122 : Async<unit> = v121 10
                let _run_target_args'_v110 = v122 
                #endif
#else
                let v123 : (int32 -> Async<unit>) = Async.Sleep
                let v124 : Async<unit> = v123 10
                let _run_target_args'_v110 = v124 
                #endif
                let v125 : Async<unit> = _run_target_args'_v110 
                do! v125 
                let v128 : int64 = v4 + 1L
                let v129 : Async<int64> = method36(v0, v1, v2, v3, v128)
                return! v129 
                (* fix_condition else
                ()
            fix_condition else *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v858 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v858 
    #endif
#if FABLE_COMPILER_PYTHON
    let v860 : unit = ()
    let _let'_v860 =
        async {
            let v865 : (int32 -> US9) = method38()
            let v866 : US9 option = v0 |> Option.map v865 
            let v880 : US9 = US9_1
            let v881 : US9 = v866 |> Option.defaultValue v880 
            let v889 : Async<bool> =
                match v881 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v886) -> (* Some *)
                    method21(v886, v2, v3)
            let! v889 = v889 
            let v890 : bool = v889 
            let v891 : bool = v890 = v1
            if v891 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v892 : int64 = v4 % 100L
                let v893 : bool = v892 = 0L
                if v893 then
                    let v894 : unit = ()
                    let v895 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v896 : unit = (fun () -> v895 (); v894) ()
                    ()
                (* run_target_args'
                let v947 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v948 : (int32 -> Async<unit>) = Async.Sleep
                let v949 : Async<unit> = v948 10
                let _run_target_args'_v947 = v949 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v950 : (int32 -> Async<unit>) = Async.Sleep
                let v951 : Async<unit> = v950 10
                let _run_target_args'_v947 = v951 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v952 : (int32 -> Async<unit>) = Async.Sleep
                let v953 : Async<unit> = v952 10
                let _run_target_args'_v947 = v953 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v954 : (int32 -> Async<unit>) = Async.Sleep
                let v955 : Async<unit> = v954 10
                let _run_target_args'_v947 = v955 
                #endif
#if FABLE_COMPILER_PYTHON
                let v956 : (int32 -> Async<unit>) = Async.Sleep
                let v957 : Async<unit> = v956 10
                let _run_target_args'_v947 = v957 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v958 : (int32 -> Async<unit>) = Async.Sleep
                let v959 : Async<unit> = v958 10
                let _run_target_args'_v947 = v959 
                #endif
#else
                let v960 : (int32 -> Async<unit>) = Async.Sleep
                let v961 : Async<unit> = v960 10
                let _run_target_args'_v947 = v961 
                #endif
                let v962 : Async<unit> = _run_target_args'_v947 
                do! v962 
                let v965 : int64 = v4 + 1L
                let v966 : Async<int64> = method36(v0, v1, v2, v3, v965)
                return! v966 
                (* fix_condition else
                ()
            fix_condition else *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1695 : Async<int64> = _let'_v860 
    let _run_target_args'_v9 = v1695 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1697 : unit = ()
    let _let'_v1697 =
        async {
            let v1702 : (int32 -> US9) = method38()
            let v1703 : US9 option = v0 |> Option.map v1702 
            let v1717 : US9 = US9_1
            let v1718 : US9 = v1703 |> Option.defaultValue v1717 
            let v1726 : Async<bool> =
                match v1718 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v1723) -> (* Some *)
                    method21(v1723, v2, v3)
            let! v1726 = v1726 
            let v1727 : bool = v1726 
            let v1728 : bool = v1727 = v1
            if v1728 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v1729 : int64 = v4 % 100L
                let v1730 : bool = v1729 = 0L
                if v1730 then
                    let v1731 : unit = ()
                    let v1732 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v1733 : unit = (fun () -> v1732 (); v1731) ()
                    ()
                (* run_target_args'
                let v1784 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1785 : (int32 -> Async<unit>) = Async.Sleep
                let v1786 : Async<unit> = v1785 10
                let _run_target_args'_v1784 = v1786 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1787 : (int32 -> Async<unit>) = Async.Sleep
                let v1788 : Async<unit> = v1787 10
                let _run_target_args'_v1784 = v1788 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1789 : (int32 -> Async<unit>) = Async.Sleep
                let v1790 : Async<unit> = v1789 10
                let _run_target_args'_v1784 = v1790 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1791 : (int32 -> Async<unit>) = Async.Sleep
                let v1792 : Async<unit> = v1791 10
                let _run_target_args'_v1784 = v1792 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1793 : (int32 -> Async<unit>) = Async.Sleep
                let v1794 : Async<unit> = v1793 10
                let _run_target_args'_v1784 = v1794 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1795 : (int32 -> Async<unit>) = Async.Sleep
                let v1796 : Async<unit> = v1795 10
                let _run_target_args'_v1784 = v1796 
                #endif
#else
                let v1797 : (int32 -> Async<unit>) = Async.Sleep
                let v1798 : Async<unit> = v1797 10
                let _run_target_args'_v1784 = v1798 
                #endif
                let v1799 : Async<unit> = _run_target_args'_v1784 
                do! v1799 
                let v1802 : int64 = v4 + 1L
                let v1803 : Async<int64> = method36(v0, v1, v2, v3, v1802)
                return! v1803 
                (* fix_condition else
                ()
            fix_condition else *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2532 : Async<int64> = _let'_v1697 
    let _run_target_args'_v9 = v2532 
    #endif
#else
    let v2534 : unit = ()
    let _let'_v2534 =
        async {
            let v2539 : (int32 -> US9) = method38()
            let v2540 : US9 option = v0 |> Option.map v2539 
            let v2554 : US9 = US9_1
            let v2555 : US9 = v2540 |> Option.defaultValue v2554 
            let v2563 : Async<bool> =
                match v2555 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v2560) -> (* Some *)
                    method21(v2560, v2, v3)
            let! v2563 = v2563 
            let v2564 : bool = v2563 
            let v2565 : bool = v2564 = v1
            if v2565 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v2566 : int64 = v4 % 100L
                let v2567 : bool = v2566 = 0L
                if v2567 then
                    let v2568 : unit = ()
                    let v2569 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v2570 : unit = (fun () -> v2569 (); v2568) ()
                    ()
                (* run_target_args'
                let v2621 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2622 : (int32 -> Async<unit>) = Async.Sleep
                let v2623 : Async<unit> = v2622 10
                let _run_target_args'_v2621 = v2623 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2624 : (int32 -> Async<unit>) = Async.Sleep
                let v2625 : Async<unit> = v2624 10
                let _run_target_args'_v2621 = v2625 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2626 : (int32 -> Async<unit>) = Async.Sleep
                let v2627 : Async<unit> = v2626 10
                let _run_target_args'_v2621 = v2627 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2628 : (int32 -> Async<unit>) = Async.Sleep
                let v2629 : Async<unit> = v2628 10
                let _run_target_args'_v2621 = v2629 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2630 : (int32 -> Async<unit>) = Async.Sleep
                let v2631 : Async<unit> = v2630 10
                let _run_target_args'_v2621 = v2631 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2632 : (int32 -> Async<unit>) = Async.Sleep
                let v2633 : Async<unit> = v2632 10
                let _run_target_args'_v2621 = v2633 
                #endif
#else
                let v2634 : (int32 -> Async<unit>) = Async.Sleep
                let v2635 : Async<unit> = v2634 10
                let _run_target_args'_v2621 = v2635 
                #endif
                let v2636 : Async<unit> = _run_target_args'_v2621 
                do! v2636 
                let v2639 : int64 = v4 + 1L
                let v2640 : Async<int64> = method36(v0, v1, v2, v3, v2639)
                return! v2640 
                (* fix_condition else
                ()
            fix_condition else *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3369 : Async<int64> = _let'_v2534 
    let _run_target_args'_v9 = v3369 
    #endif
    let v3370 : Async<int64> = _run_target_args'_v9 
    v3370
and method36 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32, v4 : int64) : Async<int64> =
    method37(v0, v1, v2, v3, v4)
and method35 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32) : Async<int64> =
    let v4 : int64 = 1L
    method36(v0, v1, v2, v3, v4)
and closure21 (v0 : int32 option, v1 : bool, v2 : string) (v3 : int32) : Async<int64> =
    method35(v0, v1, v2, v3)
and closure20 (v0 : int32 option, v1 : bool) (v2 : string) : (int32 -> Async<int64>) =
    closure21(v0, v1, v2)
and closure19 (v0 : int32 option) (v1 : bool) : (string -> (int32 -> Async<int64>)) =
    closure20(v0, v1)
and closure18 () (v0 : int32 option) : (bool -> (string -> (int32 -> Async<int64>))) =
    closure19(v0)
and method43 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : Async<int32> = null |> unbox<Async<int32>>
    let _run_target_args'_v7 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : Async<int32> = null |> unbox<Async<int32>>
    let _run_target_args'_v7 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v17 : Async<int32> = null |> unbox<Async<int32>>
    let _run_target_args'_v7 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : unit = ()
    let _let'_v21 =
        async {
            let v26 : (int32 -> US9) = method38()
            let v27 : US9 option = v0 |> Option.map v26 
            let v41 : US9 = US9_1
            let v42 : US9 = v27 |> Option.defaultValue v41 
            let v50 : Async<bool> =
                match v42 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v47) -> (* Some *)
                    method21(v47, v1, v2)
            let! v50 = v50 
            let v51 : bool = v50 
            let v52 : bool = v51 = false
            if v52 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v53 : int32 = v2 + 1
                let v54 : Async<int32> = method42(v0, v1, v53)
                return! v54 
                (* fix_condition else
                ()
            fix_condition else *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v272 : Async<int32> = _let'_v21 
    let _run_target_args'_v7 = v272 
    #endif
#if FABLE_COMPILER_PYTHON
    let v274 : unit = ()
    let _let'_v274 =
        async {
            let v279 : (int32 -> US9) = method38()
            let v280 : US9 option = v0 |> Option.map v279 
            let v294 : US9 = US9_1
            let v295 : US9 = v280 |> Option.defaultValue v294 
            let v303 : Async<bool> =
                match v295 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v300) -> (* Some *)
                    method21(v300, v1, v2)
            let! v303 = v303 
            let v304 : bool = v303 
            let v305 : bool = v304 = false
            if v305 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v306 : int32 = v2 + 1
                let v307 : Async<int32> = method42(v0, v1, v306)
                return! v307 
                (* fix_condition else
                ()
            fix_condition else *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v525 : Async<int32> = _let'_v274 
    let _run_target_args'_v7 = v525 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v527 : unit = ()
    let _let'_v527 =
        async {
            let v532 : (int32 -> US9) = method38()
            let v533 : US9 option = v0 |> Option.map v532 
            let v547 : US9 = US9_1
            let v548 : US9 = v533 |> Option.defaultValue v547 
            let v556 : Async<bool> =
                match v548 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v553) -> (* Some *)
                    method21(v553, v1, v2)
            let! v556 = v556 
            let v557 : bool = v556 
            let v558 : bool = v557 = false
            if v558 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v559 : int32 = v2 + 1
                let v560 : Async<int32> = method42(v0, v1, v559)
                return! v560 
                (* fix_condition else
                ()
            fix_condition else *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v778 : Async<int32> = _let'_v527 
    let _run_target_args'_v7 = v778 
    #endif
#else
    let v780 : unit = ()
    let _let'_v780 =
        async {
            let v785 : (int32 -> US9) = method38()
            let v786 : US9 option = v0 |> Option.map v785 
            let v800 : US9 = US9_1
            let v801 : US9 = v786 |> Option.defaultValue v800 
            let v809 : Async<bool> =
                match v801 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v806) -> (* Some *)
                    method21(v806, v1, v2)
            let! v809 = v809 
            let v810 : bool = v809 
            let v811 : bool = v810 = false
            if v811 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v812 : int32 = v2 + 1
                let v813 : Async<int32> = method42(v0, v1, v812)
                return! v813 
                (* fix_condition else
                ()
            fix_condition else *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1031 : Async<int32> = _let'_v780 
    let _run_target_args'_v7 = v1031 
    #endif
    let v1032 : Async<int32> = _run_target_args'_v7 
    v1032
and method42 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
    method43(v0, v1, v2)
and method41 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
    method42(v0, v1, v2)
and closure26 (v0 : int32 option, v1 : string) (v2 : int32) : Async<int32> =
    method41(v0, v1, v2)
and closure25 (v0 : int32 option) (v1 : string) : (int32 -> Async<int32>) =
    closure26(v0, v1)
and closure24 () (v0 : int32 option) : (string -> (int32 -> Async<int32>)) =
    closure25(v0)
let v0 : unit = ()
let v1 : (unit -> unit) = closure0()
let v2 : unit = (fun () -> v1 (); v0) ()
let v17 : (string -> (int32 -> Async<bool>)) = closure3()
let test_port_open x = v17 x
let v18 : (int32 -> (string -> (int32 -> Async<bool>))) = closure11()
let test_port_open_timeout x = v18 x
let v19 : (int32 option -> (bool -> (string -> (int32 -> Async<int64>)))) = closure18()
let wait_for_port_access x = v19 x
let v20 : (int32 option -> (string -> (int32 -> Async<int32>))) = closure24()
let get_available_port x = v20 x
()
