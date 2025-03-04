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
    let v165 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v167 : (int64 -> US2) = method10()
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
    let v302 : string = method11()
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
    let v326 : (int64 -> US2) = method10()
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
    let v461 : string = method11()
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
    let v487 : (int64 -> US2) = method10()
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
    let v526 : (int64 -> US2) = method10()
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
    let v661 : string = method12()
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
    let v685 : (int64 -> US2) = method10()
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
    let v820 : string = method12()
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
    let v844 : (int64 -> US2) = method10()
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
    let v979 : string = method12()
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
    let v1003 : (int64 -> US2) = method10()
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
    let v1138 : string = method12()
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
    let v37 : char list = []
    let v39 : char list = '/' :: v37 
    let v43 : char list = ' ' :: v39 
    let v48 : (char list -> (char [])) = List.toArray
    let v49 : (char []) = v48 v43
    let v52 : string = v8.TrimEnd v49 
    v52
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
            let v27 : (int32 -> US9) = method38()
            let v28 : US9 option = v0 |> Option.map v27 
            let v41 : US9 = US9_1
            let v42 : US9 = v28 |> Option.defaultValue v41 
            let v50 : Async<bool> =
                match v42 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v47) -> (* Some *)
                    method21(v47, v2, v3)
            let! v50 = v50 
            let v51 : bool = v50 
            let v52 : bool = v51 = v1
            if v52 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v53 : int64 = v4 % 100L
                let v54 : bool = v53 = 0L
                if v54 then
                    let v55 : unit = ()
                    let v56 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v57 : unit = (fun () -> v56 (); v55) ()
                    ()
                (* run_target_args'
                let v108 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v109 : (int32 -> Async<unit>) = Async.Sleep
                let v110 : Async<unit> = v109 10
                let _run_target_args'_v108 = v110 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v111 : (int32 -> Async<unit>) = Async.Sleep
                let v112 : Async<unit> = v111 10
                let _run_target_args'_v108 = v112 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v113 : (int32 -> Async<unit>) = Async.Sleep
                let v114 : Async<unit> = v113 10
                let _run_target_args'_v108 = v114 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v115 : (int32 -> Async<unit>) = Async.Sleep
                let v116 : Async<unit> = v115 10
                let _run_target_args'_v108 = v116 
                #endif
#if FABLE_COMPILER_PYTHON
                let v117 : (int32 -> Async<unit>) = Async.Sleep
                let v118 : Async<unit> = v117 10
                let _run_target_args'_v108 = v118 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v119 : (int32 -> Async<unit>) = Async.Sleep
                let v120 : Async<unit> = v119 10
                let _run_target_args'_v108 = v120 
                #endif
#else
                let v121 : (int32 -> Async<unit>) = Async.Sleep
                let v122 : Async<unit> = v121 10
                let _run_target_args'_v108 = v122 
                #endif
                let v123 : Async<unit> = _run_target_args'_v108 
                do! v123 
                let v126 : int64 = v4 + 1L
                let v127 : Async<int64> = method36(v0, v1, v2, v3, v126)
                return! v127 
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
    let v842 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v842 
    #endif
#if FABLE_COMPILER_PYTHON
    let v844 : unit = ()
    let _let'_v844 =
        async {
            let v848 : (int32 -> US9) = method38()
            let v849 : US9 option = v0 |> Option.map v848 
            let v862 : US9 = US9_1
            let v863 : US9 = v849 |> Option.defaultValue v862 
            let v871 : Async<bool> =
                match v863 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v868) -> (* Some *)
                    method21(v868, v2, v3)
            let! v871 = v871 
            let v872 : bool = v871 
            let v873 : bool = v872 = v1
            if v873 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v874 : int64 = v4 % 100L
                let v875 : bool = v874 = 0L
                if v875 then
                    let v876 : unit = ()
                    let v877 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v878 : unit = (fun () -> v877 (); v876) ()
                    ()
                (* run_target_args'
                let v929 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v930 : (int32 -> Async<unit>) = Async.Sleep
                let v931 : Async<unit> = v930 10
                let _run_target_args'_v929 = v931 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v932 : (int32 -> Async<unit>) = Async.Sleep
                let v933 : Async<unit> = v932 10
                let _run_target_args'_v929 = v933 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v934 : (int32 -> Async<unit>) = Async.Sleep
                let v935 : Async<unit> = v934 10
                let _run_target_args'_v929 = v935 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v936 : (int32 -> Async<unit>) = Async.Sleep
                let v937 : Async<unit> = v936 10
                let _run_target_args'_v929 = v937 
                #endif
#if FABLE_COMPILER_PYTHON
                let v938 : (int32 -> Async<unit>) = Async.Sleep
                let v939 : Async<unit> = v938 10
                let _run_target_args'_v929 = v939 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v940 : (int32 -> Async<unit>) = Async.Sleep
                let v941 : Async<unit> = v940 10
                let _run_target_args'_v929 = v941 
                #endif
#else
                let v942 : (int32 -> Async<unit>) = Async.Sleep
                let v943 : Async<unit> = v942 10
                let _run_target_args'_v929 = v943 
                #endif
                let v944 : Async<unit> = _run_target_args'_v929 
                do! v944 
                let v947 : int64 = v4 + 1L
                let v948 : Async<int64> = method36(v0, v1, v2, v3, v947)
                return! v948 
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
    let v1663 : Async<int64> = _let'_v844 
    let _run_target_args'_v9 = v1663 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1665 : unit = ()
    let _let'_v1665 =
        async {
            let v1669 : (int32 -> US9) = method38()
            let v1670 : US9 option = v0 |> Option.map v1669 
            let v1683 : US9 = US9_1
            let v1684 : US9 = v1670 |> Option.defaultValue v1683 
            let v1692 : Async<bool> =
                match v1684 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v1689) -> (* Some *)
                    method21(v1689, v2, v3)
            let! v1692 = v1692 
            let v1693 : bool = v1692 
            let v1694 : bool = v1693 = v1
            if v1694 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v1695 : int64 = v4 % 100L
                let v1696 : bool = v1695 = 0L
                if v1696 then
                    let v1697 : unit = ()
                    let v1698 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v1699 : unit = (fun () -> v1698 (); v1697) ()
                    ()
                (* run_target_args'
                let v1750 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1751 : (int32 -> Async<unit>) = Async.Sleep
                let v1752 : Async<unit> = v1751 10
                let _run_target_args'_v1750 = v1752 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1753 : (int32 -> Async<unit>) = Async.Sleep
                let v1754 : Async<unit> = v1753 10
                let _run_target_args'_v1750 = v1754 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1755 : (int32 -> Async<unit>) = Async.Sleep
                let v1756 : Async<unit> = v1755 10
                let _run_target_args'_v1750 = v1756 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1757 : (int32 -> Async<unit>) = Async.Sleep
                let v1758 : Async<unit> = v1757 10
                let _run_target_args'_v1750 = v1758 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1759 : (int32 -> Async<unit>) = Async.Sleep
                let v1760 : Async<unit> = v1759 10
                let _run_target_args'_v1750 = v1760 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1761 : (int32 -> Async<unit>) = Async.Sleep
                let v1762 : Async<unit> = v1761 10
                let _run_target_args'_v1750 = v1762 
                #endif
#else
                let v1763 : (int32 -> Async<unit>) = Async.Sleep
                let v1764 : Async<unit> = v1763 10
                let _run_target_args'_v1750 = v1764 
                #endif
                let v1765 : Async<unit> = _run_target_args'_v1750 
                do! v1765 
                let v1768 : int64 = v4 + 1L
                let v1769 : Async<int64> = method36(v0, v1, v2, v3, v1768)
                return! v1769 
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
    let v2484 : Async<int64> = _let'_v1665 
    let _run_target_args'_v9 = v2484 
    #endif
#else
    let v2486 : unit = ()
    let _let'_v2486 =
        async {
            let v2490 : (int32 -> US9) = method38()
            let v2491 : US9 option = v0 |> Option.map v2490 
            let v2504 : US9 = US9_1
            let v2505 : US9 = v2491 |> Option.defaultValue v2504 
            let v2513 : Async<bool> =
                match v2505 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v2510) -> (* Some *)
                    method21(v2510, v2, v3)
            let! v2513 = v2513 
            let v2514 : bool = v2513 
            let v2515 : bool = v2514 = v1
            if v2515 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v2516 : int64 = v4 % 100L
                let v2517 : bool = v2516 = 0L
                if v2517 then
                    let v2518 : unit = ()
                    let v2519 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v2520 : unit = (fun () -> v2519 (); v2518) ()
                    ()
                (* run_target_args'
                let v2571 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2572 : (int32 -> Async<unit>) = Async.Sleep
                let v2573 : Async<unit> = v2572 10
                let _run_target_args'_v2571 = v2573 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2574 : (int32 -> Async<unit>) = Async.Sleep
                let v2575 : Async<unit> = v2574 10
                let _run_target_args'_v2571 = v2575 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2576 : (int32 -> Async<unit>) = Async.Sleep
                let v2577 : Async<unit> = v2576 10
                let _run_target_args'_v2571 = v2577 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2578 : (int32 -> Async<unit>) = Async.Sleep
                let v2579 : Async<unit> = v2578 10
                let _run_target_args'_v2571 = v2579 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2580 : (int32 -> Async<unit>) = Async.Sleep
                let v2581 : Async<unit> = v2580 10
                let _run_target_args'_v2571 = v2581 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2582 : (int32 -> Async<unit>) = Async.Sleep
                let v2583 : Async<unit> = v2582 10
                let _run_target_args'_v2571 = v2583 
                #endif
#else
                let v2584 : (int32 -> Async<unit>) = Async.Sleep
                let v2585 : Async<unit> = v2584 10
                let _run_target_args'_v2571 = v2585 
                #endif
                let v2586 : Async<unit> = _run_target_args'_v2571 
                do! v2586 
                let v2589 : int64 = v4 + 1L
                let v2590 : Async<int64> = method36(v0, v1, v2, v3, v2589)
                return! v2590 
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
    let v3305 : Async<int64> = _let'_v2486 
    let _run_target_args'_v9 = v3305 
    #endif
    let v3306 : Async<int64> = _run_target_args'_v9 
    v3306
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
            let v25 : (int32 -> US9) = method38()
            let v26 : US9 option = v0 |> Option.map v25 
            let v39 : US9 = US9_1
            let v40 : US9 = v26 |> Option.defaultValue v39 
            let v48 : Async<bool> =
                match v40 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v45) -> (* Some *)
                    method21(v45, v1, v2)
            let! v48 = v48 
            let v49 : bool = v48 
            let v50 : bool = v49 = false
            if v50 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v51 : int32 = v2 + 1
                let v52 : Async<int32> = method42(v0, v1, v51)
                return! v52 
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
    let v256 : Async<int32> = _let'_v21 
    let _run_target_args'_v7 = v256 
    #endif
#if FABLE_COMPILER_PYTHON
    let v258 : unit = ()
    let _let'_v258 =
        async {
            let v262 : (int32 -> US9) = method38()
            let v263 : US9 option = v0 |> Option.map v262 
            let v276 : US9 = US9_1
            let v277 : US9 = v263 |> Option.defaultValue v276 
            let v285 : Async<bool> =
                match v277 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v282) -> (* Some *)
                    method21(v282, v1, v2)
            let! v285 = v285 
            let v286 : bool = v285 
            let v287 : bool = v286 = false
            if v287 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v288 : int32 = v2 + 1
                let v289 : Async<int32> = method42(v0, v1, v288)
                return! v289 
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
    let v493 : Async<int32> = _let'_v258 
    let _run_target_args'_v7 = v493 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v495 : unit = ()
    let _let'_v495 =
        async {
            let v499 : (int32 -> US9) = method38()
            let v500 : US9 option = v0 |> Option.map v499 
            let v513 : US9 = US9_1
            let v514 : US9 = v500 |> Option.defaultValue v513 
            let v522 : Async<bool> =
                match v514 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v519) -> (* Some *)
                    method21(v519, v1, v2)
            let! v522 = v522 
            let v523 : bool = v522 
            let v524 : bool = v523 = false
            if v524 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v525 : int32 = v2 + 1
                let v526 : Async<int32> = method42(v0, v1, v525)
                return! v526 
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
    let v730 : Async<int32> = _let'_v495 
    let _run_target_args'_v7 = v730 
    #endif
#else
    let v732 : unit = ()
    let _let'_v732 =
        async {
            let v736 : (int32 -> US9) = method38()
            let v737 : US9 option = v0 |> Option.map v736 
            let v750 : US9 = US9_1
            let v751 : US9 = v737 |> Option.defaultValue v750 
            let v759 : Async<bool> =
                match v751 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v756) -> (* Some *)
                    method21(v756, v1, v2)
            let! v759 = v759 
            let v760 : bool = v759 
            let v761 : bool = v760 = false
            if v761 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v762 : int32 = v2 + 1
                let v763 : Async<int32> = method42(v0, v1, v762)
                return! v763 
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
    let v967 : Async<int32> = _let'_v732 
    let _run_target_args'_v7 = v967 
    #endif
    let v968 : Async<int32> = _run_target_args'_v7 
    v968
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
