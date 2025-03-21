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
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = method3(v0)
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
    let v16 : string = method4()
    let v17 : string = "$0.unwrap_or($1)"
    let v18 : string = Fable.Core.RustInterop.emitRustExpr struct (v15, v16) v17 
    let _run_target_args'_v2 = v18 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v19 : US3 = US3_1
    let v20 : US4 = US4_3(v19)
    let v21 : string = $"env.get_environment_variable / target: {v20} / var: {v0}"
    let v22 : string = failwith<string> v21
    let _run_target_args'_v2 = v22 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v23 : US3 = US3_2
    let v24 : US4 = US4_3(v23)
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
    let v49 : (string -> US5) = method5()
    let v50 : US5 option = v44 |> Option.map v49 
    let v70 : US5 = US5_1
    let v71 : US5 = v50 |> Option.defaultValue v70 
    let v78 : string =
        match v71 with
        | US5_1 -> (* None *)
            let v76 : string = ""
            v76
        | US5_0(v75) -> (* Some *)
            v75
    let _run_target_args'_v2 = v78 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v79 : US3 = US3_1
    let v80 : US4 = US4_1(v79)
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
    let v93 : (string -> US5) = method5()
    let v94 : US5 option = v88 |> Option.map v93 
    let v114 : US5 = US5_1
    let v115 : US5 = v94 |> Option.defaultValue v114 
    let v122 : string =
        match v115 with
        | US5_1 -> (* None *)
            let v120 : string = ""
            v120
        | US5_0(v119) -> (* Some *)
            v119
    let _run_target_args'_v2 = v122 
    #endif
    let v123 : string = _run_target_args'_v2 
    v123
and method1 () : struct (US1 * US2) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method2(v0)
    
    
    
    
    
    
    
    
    
    
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
    let v41 : US1 =
        if v37 then
            let v38 : US0 = US0_0
            US1_0(v38)
        else
            US1_1
    let v127 : US1 =
        match v41 with
        | US1_1 -> (* None *)
            let v44 : bool = "Debug" = v1
            let v48 : US1 =
                if v44 then
                    let v45 : US0 = US0_1
                    US1_0(v45)
                else
                    US1_1
            match v48 with
            | US1_1 -> (* None *)
                let v51 : bool = "Info" = v1
                let v55 : US1 =
                    if v51 then
                        let v52 : US0 = US0_2
                        US1_0(v52)
                    else
                        US1_1
                match v55 with
                | US1_1 -> (* None *)
                    let v58 : bool = "Warning" = v1
                    let v62 : US1 =
                        if v58 then
                            let v59 : US0 = US0_3
                            US1_0(v59)
                        else
                            US1_1
                    match v62 with
                    | US1_1 -> (* None *)
                        let v65 : bool = "Critical" = v1
                        let v69 : US1 =
                            if v65 then
                                let v66 : US0 = US0_4
                                US1_0(v66)
                            else
                                US1_1
                        match v69 with
                        | US1_1 -> (* None *)
                            let v72 : bool = v34 = v1
                            let v76 : US1 =
                                if v72 then
                                    let v73 : US0 = US0_0
                                    US1_0(v73)
                                else
                                    US1_1
                            match v76 with
                            | US1_1 -> (* None *)
                                let v79 : bool = v27 = v1
                                let v83 : US1 =
                                    if v79 then
                                        let v80 : US0 = US0_1
                                        US1_0(v80)
                                    else
                                        US1_1
                                match v83 with
                                | US1_1 -> (* None *)
                                    let v86 : bool = v20 = v1
                                    let v90 : US1 =
                                        if v86 then
                                            let v87 : US0 = US0_2
                                            US1_0(v87)
                                        else
                                            US1_1
                                    match v90 with
                                    | US1_1 -> (* None *)
                                        let v93 : bool = v13 = v1
                                        let v97 : US1 =
                                            if v93 then
                                                let v94 : US0 = US0_3
                                                US1_0(v94)
                                            else
                                                US1_1
                                        match v97 with
                                        | US1_1 -> (* None *)
                                            let v100 : bool = v6 = v1
                                            let v104 : US1 =
                                                if v100 then
                                                    let v101 : US0 = US0_4
                                                    US1_0(v101)
                                                else
                                                    US1_1
                                            match v104 with
                                            | US1_1 -> (* None *)
                                                US1_1
                                            | US1_0(v105) -> (* Some *)
                                                US1_0(v105)
                                        | US1_0(v98) -> (* Some *)
                                            US1_0(v98)
                                    | US1_0(v91) -> (* Some *)
                                        US1_0(v91)
                                | US1_0(v84) -> (* Some *)
                                    US1_0(v84)
                            | US1_0(v77) -> (* Some *)
                                US1_0(v77)
                        | US1_0(v70) -> (* Some *)
                            US1_0(v70)
                    | US1_0(v63) -> (* Some *)
                        US1_0(v63)
                | US1_0(v56) -> (* Some *)
                    US1_0(v56)
            | US1_0(v49) -> (* Some *)
                US1_0(v49)
        | US1_0(v42) -> (* Some *)
            US1_0(v42)
    let v128 : string = "AUTOMATION"
    let v129 : string = method2(v128)
    let v132 : string = "True"
    let v133 : bool = v129 <> v132 
    let v200 : US2 =
        if v133 then
            US2_1
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
            US2_0(v196)
    struct (v127, v200)
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
    let v198 : int64 option =
        match v173 with
        | US2_1 -> (* None *)
            let v194 : int64 option = None
            v194
        | US2_0(v188) -> (* Some *)
            let v190 : int64 option = Some v188 
            v190
    struct (v178, v180, v181, v183, v187, v198)
and closure0 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US0 = US0_0
        let struct (v2 : Mut0, v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : int64 option) = method0(v1)
        let v9 : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v9 
        ()
and method8 (v0 : US0) : bool =
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure0()
    let v5 : unit = (fun () -> v4 (); v3) ()
    let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
    let v44 : US0 = v30.l0
    let v45 : bool = v28.l0
    let v46 : bool = v45 = false
    if v46 then
        false
    else
        let v47 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v0
        let v48 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v44
        let v49 : bool = v47 >= v48
        v49
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
    let v173 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v176 : (int64 -> US2) = method10()
    let v177 : US2 option = v5 |> Option.map v176 
    let v197 : US2 = US2_1
    let v198 : US2 = v177 |> Option.defaultValue v197 
    let v316 : System.DateTime =
        match v198 with
        | US2_1 -> (* None *)
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
        | US2_0(v202) -> (* Some *)
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
    let v318 : string = method11()
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
    let v343 : (int64 -> US2) = method10()
    let v344 : US2 option = v5 |> Option.map v343 
    let v364 : US2 = US2_1
    let v365 : US2 = v344 |> Option.defaultValue v364 
    let v483 : System.DateTime =
        match v365 with
        | US2_1 -> (* None *)
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
        | US2_0(v369) -> (* Some *)
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
    let v485 : string = method11()
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
    let v512 : (int64 -> US2) = method10()
    let v513 : US2 option = v5 |> Option.map v512 
    let v533 : US2 = US2_1
    let v534 : US2 = v513 |> Option.defaultValue v533 
    let v546 : uint64 =
        match v534 with
        | US2_1 -> (* None *)
            v509
        | US2_0(v538) -> (* Some *)
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
    let v559 : (int64 -> US2) = method10()
    let v560 : US2 option = v5 |> Option.map v559 
    let v580 : US2 = US2_1
    let v581 : US2 = v560 |> Option.defaultValue v580 
    let v699 : System.DateTime =
        match v581 with
        | US2_1 -> (* None *)
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
        | US2_0(v585) -> (* Some *)
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
    let v701 : string = method12()
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
    let v726 : (int64 -> US2) = method10()
    let v727 : US2 option = v5 |> Option.map v726 
    let v747 : US2 = US2_1
    let v748 : US2 = v727 |> Option.defaultValue v747 
    let v866 : System.DateTime =
        match v748 with
        | US2_1 -> (* None *)
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
        | US2_0(v752) -> (* Some *)
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
    let v868 : string = method12()
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
    let v893 : (int64 -> US2) = method10()
    let v894 : US2 option = v5 |> Option.map v893 
    let v914 : US2 = US2_1
    let v915 : US2 = v894 |> Option.defaultValue v914 
    let v1033 : System.DateTime =
        match v915 with
        | US2_1 -> (* None *)
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
        | US2_0(v919) -> (* Some *)
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
    let v1035 : string = method12()
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
    let v1060 : (int64 -> US2) = method10()
    let v1061 : US2 option = v5 |> Option.map v1060 
    let v1081 : US2 = US2_1
    let v1082 : US2 = v1061 |> Option.defaultValue v1081 
    let v1200 : System.DateTime =
        match v1082 with
        | US2_1 -> (* None *)
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
        | US2_0(v1086) -> (* Some *)
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
    let v1202 : string = method12()
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
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method14(v7)
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
    let v138 : string = method16()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[90m"
    let v142 : string = method16()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[90m"
    let v146 : string = method16()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[90m"
    let v150 : string = method16()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method18 (v0 : int32, v1 : string) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure7(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "port"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure7(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure7(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure7(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure7(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "ex"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure7(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure7(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v78 : string = $"{v1}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure7(v3, v78)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v88 : string = " }"
    let v89 : string = $"{v88}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure7(v3, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v97 : string = v3.l0
    v97
and method19 (v0 : string) : string =
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
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure0()
    let v5 : unit = (fun () -> v4 (); v3) ()
    let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
    let v44 : unit = ()
    let v45 : (unit -> unit) = closure8(v26)
    let v46 : unit = (fun () -> v45 (); v44) ()
    let v49 : (string -> unit) = closure9()
    (* run_target_args'
    let v50 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v51 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v51 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v52 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = v29.l0
    let v54 : bool = v53 = ""
    let v62 : string =
        if v54 then
            v0
        else
            let v55 : bool = v0 = ""
            if v55 then
                let v56 : string = v29.l0
                v56
            else
                let v57 : string = v29.l0
                let v58 : string = "\n"
                let v59 : string = v57 + v58 
                let v60 : string = v59 + v0 
                v60
    (* run_target_args'
    let v67 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v68 : string = "&*$0"
    let v69 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v62 v68 
    let _run_target_args'_v67 = v69 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v70 : string = "&*$0"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v62 v70 
    let _run_target_args'_v67 = v71 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v72 : string = "&*$0"
    let v73 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v62 v72 
    let _run_target_args'_v67 = v73 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v75 : Ref<Str> = v62 |> unbox<Ref<Str>>
    let _run_target_args'_v67 = v75 
    #endif
#if FABLE_COMPILER_PYTHON
    let v79 : Ref<Str> = v62 |> unbox<Ref<Str>>
    let _run_target_args'_v67 = v79 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v83 : Ref<Str> = v62 |> unbox<Ref<Str>>
    let _run_target_args'_v67 = v83 
    #endif
#else
    let v87 : Ref<Str> = v62 |> unbox<Ref<Str>>
    let _run_target_args'_v67 = v87 
    #endif
    let v90 : Ref<Str> = _run_target_args'_v67 
    let v96 : string = $"$0.chars()"
    let v97 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v90 v96 
    let v98 : string = "$0"
    let v99 : _ = Fable.Core.RustInterop.emitRustExpr v97 v98 
    let v100 : string = "$0.collect::<Vec<_>>()"
    let v101 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v99 v100 
    let v102 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v103 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let v104 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v105 : bool = Fable.Core.RustInterop.emitRustExpr v103 v104 
    let v106 : string = "x"
    let v107 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v106 
    let v108 : string = "String::from_iter($0)"
    let v109 : std_string_String = Fable.Core.RustInterop.emitRustExpr v107 v108 
    let v110 : string = "true; $0 }).collect::<Vec<_>>()"
    let v111 : bool = Fable.Core.RustInterop.emitRustExpr v109 v110 
    let v112 : string = "_vec_map"
    let v113 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v112 
    let v114 : string = "$0.len()"
    let v115 : unativeint = Fable.Core.RustInterop.emitRustExpr v113 v114 
    let v121 : int32 = v115 |> int32 
    let v131 : string = ""
    let v132 : bool = v0 <> v131 
    let v136 : bool =
        if v132 then
            let v135 : bool = v121 <= 1
            v135
        else
            false
    if v136 then
        v29.l0 <- v62
        ()
    else
        v29.l0 <- v131
        let v137 : string = "true; $0.into_iter().for_each(|x| { //"
        let v138 : bool = Fable.Core.RustInterop.emitRustExpr v113 v137 
        let v139 : string = "x"
        let v140 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v139 
        let v141 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v142 : bool = Fable.Core.RustInterop.emitRustExpr v140 v141 
        let v143 : string = $"true"
        let v144 : bool = Fable.Core.RustInterop.emitRustExpr () v143 
        let v145 : string = "true; }); //"
        let v146 : bool = Fable.Core.RustInterop.emitRustExpr () v145 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v49 v0
    #endif
#if FABLE_COMPILER_PYTHON
    v49 v0
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v49 v0
    #endif
#else
    v49 v0
    #endif
    // run_target_args' is_unit
    let v147 : (string -> unit) = v27.l0
    v147 v0
and closure5 (v0 : int32, v1 : exn) () : unit =
    let v2 : US0 = US0_0
    let v3 : bool = method8(v2)
    if v3 then
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method9(v29, v30, v31, v32, v33, v34)
        let v48 : string = method13()
        (* run_target_args'
        let v53 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v55 : string = $"%A{v1}"
        let _run_target_args'_v53 = v55 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v59 : string = $"%A{v1}"
        let _run_target_args'_v53 = v59 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v63 : string = $"%A{v1}"
        let _run_target_args'_v53 = v63 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v53 = v67 
        #endif
#if FABLE_COMPILER_PYTHON
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v53 = v71 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v53 = v75 
        #endif
#else
        let v78 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v53 = v78 
        #endif
        let v79 : string = _run_target_args'_v53 
        let v85 : string = method17(v29, v30, v31, v32, v33, v34, v47, v48, v0, v79)
        method20(v85)
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
            let v447 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3439 : Async<bool> = _let'_v20 
    let _run_target_args'_v6 = v3439 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3441 : unit = ()
    let _let'_v3441 =
        async {
            let v3444 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v3444 = v3444 
            let v3445 : System.Threading.CancellationToken = v3444 
            (* run_target_args'
            let v3450 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3452 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3450 = v3452 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3456 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3450 = v3456 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3460 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3450 = v3460 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3464 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3450 = v3464 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3468 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3450 = v3468 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3472 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v3450 = v3472 
            #endif
#else
            let v3475 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v3450 = v3475 
            #endif
            let v3476 : System_Net_Sockets_TcpClient = _run_target_args'_v3450 
            use v3476 = v3476 
            let v3482 : System_Net_Sockets_TcpClient = v3476 
            try
                (* run_target_args'
                let v3487 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3489 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3487 = v3489 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3493 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3487 = v3493 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3497 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3487 = v3497 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3501 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3487 = v3501 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3505 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3487 = v3505 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3509 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v3487 = v3509 
                #endif
#else
                let v3512 : System.Threading.Tasks.ValueTask = v3482.ConnectAsync (v0, v1, v3445)
                let _run_target_args'_v3487 = v3512 
                #endif
                let v3513 : System.Threading.Tasks.ValueTask = _run_target_args'_v3487 
                (* run_target_args'
                let v3523 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3525 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3523 = v3525 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3529 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3523 = v3529 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3533 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3523 = v3533 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3537 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3523 = v3537 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3541 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3523 = v3541 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3545 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3523 = v3545 
                #endif
#else
                let v3548 : (unit -> System.Threading.Tasks.Task) = v3513.AsTask
                let v3549 : System.Threading.Tasks.Task = v3548 ()
                let _run_target_args'_v3523 = v3549 
                #endif
                let v3550 : System.Threading.Tasks.Task = _run_target_args'_v3523 
                (* run_target_args'
                let v3560 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3562 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v3560 = v3562 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3566 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v3560 = v3566 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3570 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v3560 = v3570 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3573 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3574 : Async<unit> = v3573 v3550
                let _run_target_args'_v3560 = v3574 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3575 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3576 : Async<unit> = v3575 v3550
                let _run_target_args'_v3560 = v3576 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3577 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3578 : Async<unit> = v3577 v3550
                let _run_target_args'_v3560 = v3578 
                #endif
#else
                let v3579 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3580 : Async<unit> = v3579 v3550
                let _run_target_args'_v3560 = v3580 
                #endif
                let v3581 : Async<unit> = _run_target_args'_v3560 
                do! v3581 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v3691 : exn = ex
                let v3692 : unit = ()
                let v3693 : (unit -> unit) = closure5(v1, v3691)
                let v3694 : unit = (fun () -> v3693 (); v3692) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v3868 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6860 : Async<bool> = _let'_v3441 
    let _run_target_args'_v6 = v6860 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v6862 : unit = ()
    let _let'_v6862 =
        async {
            let v6865 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v6865 = v6865 
            let v6866 : System.Threading.CancellationToken = v6865 
            (* run_target_args'
            let v6871 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6873 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6871 = v6873 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6877 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6871 = v6877 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6881 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6871 = v6881 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6885 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6871 = v6885 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6889 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6871 = v6889 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6893 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v6871 = v6893 
            #endif
#else
            let v6896 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v6871 = v6896 
            #endif
            let v6897 : System_Net_Sockets_TcpClient = _run_target_args'_v6871 
            use v6897 = v6897 
            let v6903 : System_Net_Sockets_TcpClient = v6897 
            try
                (* run_target_args'
                let v6908 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6910 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6908 = v6910 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6914 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6908 = v6914 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6918 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6908 = v6918 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6922 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6908 = v6922 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6926 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6908 = v6926 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6930 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v6908 = v6930 
                #endif
#else
                let v6933 : System.Threading.Tasks.ValueTask = v6903.ConnectAsync (v0, v1, v6866)
                let _run_target_args'_v6908 = v6933 
                #endif
                let v6934 : System.Threading.Tasks.ValueTask = _run_target_args'_v6908 
                (* run_target_args'
                let v6944 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6946 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6944 = v6946 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6950 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6944 = v6950 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6954 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6944 = v6954 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6958 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6944 = v6958 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6962 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6944 = v6962 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6966 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6944 = v6966 
                #endif
#else
                let v6969 : (unit -> System.Threading.Tasks.Task) = v6934.AsTask
                let v6970 : System.Threading.Tasks.Task = v6969 ()
                let _run_target_args'_v6944 = v6970 
                #endif
                let v6971 : System.Threading.Tasks.Task = _run_target_args'_v6944 
                (* run_target_args'
                let v6981 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6983 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v6981 = v6983 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6987 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v6981 = v6987 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6991 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v6981 = v6991 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6994 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6995 : Async<unit> = v6994 v6971
                let _run_target_args'_v6981 = v6995 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6996 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6997 : Async<unit> = v6996 v6971
                let _run_target_args'_v6981 = v6997 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6998 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6999 : Async<unit> = v6998 v6971
                let _run_target_args'_v6981 = v6999 
                #endif
#else
                let v7000 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v7001 : Async<unit> = v7000 v6971
                let _run_target_args'_v6981 = v7001 
                #endif
                let v7002 : Async<unit> = _run_target_args'_v6981 
                do! v7002 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v7112 : exn = ex
                let v7113 : unit = ()
                let v7114 : (unit -> unit) = closure5(v1, v7112)
                let v7115 : unit = (fun () -> v7114 (); v7113) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v7289 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v10281 : Async<bool> = _let'_v6862 
    let _run_target_args'_v6 = v10281 
    #endif
#else
    let v10283 : unit = ()
    let _let'_v10283 =
        async {
            let v10286 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v10286 = v10286 
            let v10287 : System.Threading.CancellationToken = v10286 
            (* run_target_args'
            let v10292 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v10294 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10292 = v10294 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v10298 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10292 = v10298 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v10302 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10292 = v10302 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v10306 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10292 = v10306 
            #endif
#if FABLE_COMPILER_PYTHON
            let v10310 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10292 = v10310 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v10314 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v10292 = v10314 
            #endif
#else
            let v10317 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v10292 = v10317 
            #endif
            let v10318 : System_Net_Sockets_TcpClient = _run_target_args'_v10292 
            use v10318 = v10318 
            let v10324 : System_Net_Sockets_TcpClient = v10318 
            try
                (* run_target_args'
                let v10329 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10331 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10329 = v10331 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10335 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10329 = v10335 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10339 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10329 = v10339 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10343 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10329 = v10343 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10347 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10329 = v10347 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10351 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v10329 = v10351 
                #endif
#else
                let v10354 : System.Threading.Tasks.ValueTask = v10324.ConnectAsync (v0, v1, v10287)
                let _run_target_args'_v10329 = v10354 
                #endif
                let v10355 : System.Threading.Tasks.ValueTask = _run_target_args'_v10329 
                (* run_target_args'
                let v10365 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10367 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10365 = v10367 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10371 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10365 = v10371 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10375 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10365 = v10375 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10379 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10365 = v10379 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10383 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10365 = v10383 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10387 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10365 = v10387 
                #endif
#else
                let v10390 : (unit -> System.Threading.Tasks.Task) = v10355.AsTask
                let v10391 : System.Threading.Tasks.Task = v10390 ()
                let _run_target_args'_v10365 = v10391 
                #endif
                let v10392 : System.Threading.Tasks.Task = _run_target_args'_v10365 
                (* run_target_args'
                let v10402 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10404 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v10402 = v10404 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10408 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v10402 = v10408 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10412 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v10402 = v10412 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10415 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10416 : Async<unit> = v10415 v10392
                let _run_target_args'_v10402 = v10416 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10417 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10418 : Async<unit> = v10417 v10392
                let _run_target_args'_v10402 = v10418 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10419 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10420 : Async<unit> = v10419 v10392
                let _run_target_args'_v10402 = v10420 
                #endif
#else
                let v10421 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10422 : Async<unit> = v10421 v10392
                let _run_target_args'_v10402 = v10422 
                #endif
                let v10423 : Async<unit> = _run_target_args'_v10402 
                do! v10423 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v10533 : exn = ex
                let v10534 : unit = ()
                let v10535 : (unit -> unit) = closure5(v1, v10533)
                let v10536 : unit = (fun () -> v10535 (); v10534) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v10710 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v13702 : Async<bool> = _let'_v10283 
    let _run_target_args'_v6 = v13702 
    #endif
    let v13703 : Async<bool> = _run_target_args'_v6 
    v13703
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
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure7(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "timeout"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure7(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure7(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    let v37 : string = $"{v0}"
    let v40 : unit = ()
    let v41 : (unit -> unit) = closure7(v2, v37)
    let v42 : unit = (fun () -> v41 (); v40) ()
    let v47 : string = " }"
    let v48 : string = $"{v47}"
    let v51 : unit = ()
    let v52 : (unit -> unit) = closure7(v2, v48)
    let v53 : unit = (fun () -> v52 (); v51) ()
    let v56 : string = v2.l0
    v56
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
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure0()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut0, v29 : Mut1, v30 : Mut2, v31 : Mut3, v32 : Mut4, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method9(v28, v29, v30, v31, v32, v33)
        let v47 : string = method13()
        let v48 : string = method30(v28, v29, v30, v31, v32, v33, v46, v47, v0)
        method20(v48)
and method32 () : string =
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method14(v7)
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
    let v138 : string = method16()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[91m"
    let v142 : string = method16()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[91m"
    let v146 : string = method16()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[91m"
    let v150 : string = method16()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method34 (v0 : int32, v1 : string) : string =
    let v2 : string = method15()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure7(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "timeout"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure7(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure7(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure7(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure7(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "ex"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure7(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure7(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v78 : string = $"{v1}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure7(v3, v78)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v88 : string = " }"
    let v89 : string = $"{v88}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure7(v3, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v97 : string = v3.l0
    v97
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
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method9(v29, v30, v31, v32, v33, v34)
        let v48 : string = method32()
        (* run_target_args'
        let v53 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v55 : string = $"%A{v1}"
        let _run_target_args'_v53 = v55 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v59 : string = $"%A{v1}"
        let _run_target_args'_v53 = v59 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v63 : string = $"%A{v1}"
        let _run_target_args'_v53 = v63 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v53 = v67 
        #endif
#if FABLE_COMPILER_PYTHON
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v53 = v71 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v53 = v75 
        #endif
#else
        let v78 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v53 = v78 
        #endif
        let v79 : string = _run_target_args'_v53 
        let v85 : string = method33(v29, v30, v31, v32, v33, v34, v47, v48, v0, v79)
        method20(v85)
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
            let v179 : US6 =
                match v23 with
                | US8_1(v26) -> (* Error *)
                    let v28 : string = $"%A{v26}"
                    let v33 : string = "System.TimeoutException"
                    let v34 : bool = v28.Contains v33 
                    if v34 then
                        let v37 : unit = ()
                        let v38 : (unit -> unit) = closure16(v0)
                        let v39 : unit = (fun () -> v38 (); v37) ()
                        US6_1
                    else
                        let v89 : unit = ()
                        let v90 : (unit -> unit) = closure17(v0, v26)
                        let v91 : unit = (fun () -> v90 (); v89) ()
                        US6_1
                | US8_0(v24) -> (* Ok *)
                    US6_0(v24)
            return v179 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1279 : Async<US6> = _let'_v20 
    let _run_target_args'_v6 = v1279 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1281 : unit = ()
    let _let'_v1281 =
        async {
            let! v1 = v1 
            let v1284 : US8 = v1 
            let v1440 : US6 =
                match v1284 with
                | US8_1(v1287) -> (* Error *)
                    let v1289 : string = $"%A{v1287}"
                    let v1294 : string = "System.TimeoutException"
                    let v1295 : bool = v1289.Contains v1294 
                    if v1295 then
                        let v1298 : unit = ()
                        let v1299 : (unit -> unit) = closure16(v0)
                        let v1300 : unit = (fun () -> v1299 (); v1298) ()
                        US6_1
                    else
                        let v1350 : unit = ()
                        let v1351 : (unit -> unit) = closure17(v0, v1287)
                        let v1352 : unit = (fun () -> v1351 (); v1350) ()
                        US6_1
                | US8_0(v1285) -> (* Ok *)
                    US6_0(v1285)
            return v1440 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2540 : Async<US6> = _let'_v1281 
    let _run_target_args'_v6 = v2540 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2542 : unit = ()
    let _let'_v2542 =
        async {
            let! v1 = v1 
            let v2545 : US8 = v1 
            let v2701 : US6 =
                match v2545 with
                | US8_1(v2548) -> (* Error *)
                    let v2550 : string = $"%A{v2548}"
                    let v2555 : string = "System.TimeoutException"
                    let v2556 : bool = v2550.Contains v2555 
                    if v2556 then
                        let v2559 : unit = ()
                        let v2560 : (unit -> unit) = closure16(v0)
                        let v2561 : unit = (fun () -> v2560 (); v2559) ()
                        US6_1
                    else
                        let v2611 : unit = ()
                        let v2612 : (unit -> unit) = closure17(v0, v2548)
                        let v2613 : unit = (fun () -> v2612 (); v2611) ()
                        US6_1
                | US8_0(v2546) -> (* Ok *)
                    US6_0(v2546)
            return v2701 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3801 : Async<US6> = _let'_v2542 
    let _run_target_args'_v6 = v3801 
    #endif
#else
    let v3803 : unit = ()
    let _let'_v3803 =
        async {
            let! v1 = v1 
            let v3806 : US8 = v1 
            let v3962 : US6 =
                match v3806 with
                | US8_1(v3809) -> (* Error *)
                    let v3811 : string = $"%A{v3809}"
                    let v3816 : string = "System.TimeoutException"
                    let v3817 : bool = v3811.Contains v3816 
                    if v3817 then
                        let v3820 : unit = ()
                        let v3821 : (unit -> unit) = closure16(v0)
                        let v3822 : unit = (fun () -> v3821 (); v3820) ()
                        US6_1
                    else
                        let v3872 : unit = ()
                        let v3873 : (unit -> unit) = closure17(v0, v3809)
                        let v3874 : unit = (fun () -> v3873 (); v3872) ()
                        US6_1
                | US8_0(v3807) -> (* Ok *)
                    US6_0(v3807)
            return v3962 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5062 : Async<US6> = _let'_v3803 
    let _run_target_args'_v6 = v5062 
    #endif
    let v5063 : Async<US6> = _run_target_args'_v6 
    v5063
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
    let v8 : string = "{ "
    let v9 : string = $"{v8}"
    let v12 : unit = ()
    let v13 : (unit -> unit) = closure7(v5, v9)
    let v14 : unit = (fun () -> v13 (); v12) ()
    let v19 : string = "port"
    let v20 : string = $"{v19}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure7(v5, v20)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v30 : string = " = "
    let v31 : string = $"{v30}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure7(v5, v31)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v40 : string = $"{v0}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure7(v5, v40)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v50 : string = "; "
    let v51 : string = $"{v50}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure7(v5, v51)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v61 : string = "retry"
    let v62 : string = $"{v61}"
    let v65 : unit = ()
    let v66 : (unit -> unit) = closure7(v5, v62)
    let v67 : unit = (fun () -> v66 (); v65) ()
    let v71 : string = $"{v30}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure7(v5, v71)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v80 : string = $"{v1}"
    let v83 : unit = ()
    let v84 : (unit -> unit) = closure7(v5, v80)
    let v85 : unit = (fun () -> v84 (); v83) ()
    let v89 : string = $"{v50}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure7(v5, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v99 : string = "timeout"
    let v100 : string = $"{v99}"
    let v103 : unit = ()
    let v104 : (unit -> unit) = closure7(v5, v100)
    let v105 : unit = (fun () -> v104 (); v103) ()
    let v109 : string = $"{v30}"
    let v112 : unit = ()
    let v113 : (unit -> unit) = closure7(v5, v109)
    let v114 : unit = (fun () -> v113 (); v112) ()
    (* run_target_args'
    let v121 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v122 : string = "format!(\"{:#?}\", $0)"
    let v123 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v122 
    let v124 : string = "fable_library_rust::String_::fromString($0)"
    let v125 : string = Fable.Core.RustInterop.emitRustExpr v123 v124 
    let _run_target_args'_v121 = v125 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v126 : string = "format!(\"{:#?}\", $0)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v126 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let _run_target_args'_v121 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "format!(\"{:#?}\", $0)"
    let v131 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v130 
    let v132 : string = "fable_library_rust::String_::fromString($0)"
    let v133 : string = Fable.Core.RustInterop.emitRustExpr v131 v132 
    let _run_target_args'_v121 = v133 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v135 : string = $"%A{v2}"
    let _run_target_args'_v121 = v135 
    #endif
#if FABLE_COMPILER_PYTHON
    let v139 : string = $"%A{v2}"
    let _run_target_args'_v121 = v139 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v143 : string = $"%A{v2}"
    let _run_target_args'_v121 = v143 
    #endif
#else
    let v147 : string = $"%A{v2}"
    let _run_target_args'_v121 = v147 
    #endif
    let v150 : string = _run_target_args'_v121 
    let v157 : string = $"{v150}"
    let v160 : unit = ()
    let v161 : (unit -> unit) = closure7(v5, v157)
    let v162 : unit = (fun () -> v161 (); v160) ()
    let v166 : string = $"{v50}"
    let v169 : unit = ()
    let v170 : (unit -> unit) = closure7(v5, v166)
    let v171 : unit = (fun () -> v170 (); v169) ()
    let v176 : string = "status"
    let v177 : string = $"{v176}"
    let v180 : unit = ()
    let v181 : (unit -> unit) = closure7(v5, v177)
    let v182 : unit = (fun () -> v181 (); v180) ()
    let v186 : string = $"{v30}"
    let v189 : unit = ()
    let v190 : (unit -> unit) = closure7(v5, v186)
    let v191 : unit = (fun () -> v190 (); v189) ()
    let v196 : string =
        if v3 then
            let v194 : string = "true"
            v194
        else
            let v195 : string = "false"
            v195
    let v198 : string = $"{v196}"
    let v201 : unit = ()
    let v202 : (unit -> unit) = closure7(v5, v198)
    let v203 : unit = (fun () -> v202 (); v201) ()
    let v208 : string = " }"
    let v209 : string = $"{v208}"
    let v212 : unit = ()
    let v213 : (unit -> unit) = closure7(v5, v209)
    let v214 : unit = (fun () -> v213 (); v212) ()
    let v217 : string = v5.l0
    v217
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
        let v8 : unit = ()
        let v9 : (unit -> unit) = closure0()
        let v10 : unit = (fun () -> v9 (); v8) ()
        let struct (v31 : Mut0, v32 : Mut1, v33 : Mut2, v34 : Mut3, v35 : Mut4, v36 : int64 option) = TraceState.trace_state.Value
        let v49 : string = method9(v31, v32, v33, v34, v35, v36)
        let v50 : string = method13()
        let v51 : string = method39(v31, v32, v33, v34, v35, v36, v49, v50, v2, v3, v0, v1)
        method20(v51)
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
            let v49 : US9 = US9_1
            let v50 : US9 = v29 |> Option.defaultValue v49 
            let v58 : Async<bool> =
                match v50 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v55) -> (* Some *)
                    method21(v55, v2, v3)
            let! v58 = v58 
            let v59 : bool = v58 
            let v60 : bool = v59 = v1
            if v60 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v61 : int64 = v4 % 100L
                let v62 : bool = v61 = 0L
                if v62 then
                    let v63 : unit = ()
                    let v64 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v65 : unit = (fun () -> v64 (); v63) ()
                    ()
                (* run_target_args'
                let v118 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v119 : (int32 -> Async<unit>) = Async.Sleep
                let v120 : Async<unit> = v119 10
                let _run_target_args'_v118 = v120 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v121 : (int32 -> Async<unit>) = Async.Sleep
                let v122 : Async<unit> = v121 10
                let _run_target_args'_v118 = v122 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v123 : (int32 -> Async<unit>) = Async.Sleep
                let v124 : Async<unit> = v123 10
                let _run_target_args'_v118 = v124 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v125 : (int32 -> Async<unit>) = Async.Sleep
                let v126 : Async<unit> = v125 10
                let _run_target_args'_v118 = v126 
                #endif
#if FABLE_COMPILER_PYTHON
                let v127 : (int32 -> Async<unit>) = Async.Sleep
                let v128 : Async<unit> = v127 10
                let _run_target_args'_v118 = v128 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v129 : (int32 -> Async<unit>) = Async.Sleep
                let v130 : Async<unit> = v129 10
                let _run_target_args'_v118 = v130 
                #endif
#else
                let v131 : (int32 -> Async<unit>) = Async.Sleep
                let v132 : Async<unit> = v131 10
                let _run_target_args'_v118 = v132 
                #endif
                let v133 : Async<unit> = _run_target_args'_v118 
                do! v133 
                let v136 : int64 = v4 + 1L
                let v137 : Async<int64> = method36(v0, v1, v2, v3, v136)
                return! v137 
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
    let v922 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v922 
    #endif
#if FABLE_COMPILER_PYTHON
    let v924 : unit = ()
    let _let'_v924 =
        async {
            let v929 : (int32 -> US9) = method38()
            let v930 : US9 option = v0 |> Option.map v929 
            let v950 : US9 = US9_1
            let v951 : US9 = v930 |> Option.defaultValue v950 
            let v959 : Async<bool> =
                match v951 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v956) -> (* Some *)
                    method21(v956, v2, v3)
            let! v959 = v959 
            let v960 : bool = v959 
            let v961 : bool = v960 = v1
            if v961 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v962 : int64 = v4 % 100L
                let v963 : bool = v962 = 0L
                if v963 then
                    let v964 : unit = ()
                    let v965 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v966 : unit = (fun () -> v965 (); v964) ()
                    ()
                (* run_target_args'
                let v1019 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1020 : (int32 -> Async<unit>) = Async.Sleep
                let v1021 : Async<unit> = v1020 10
                let _run_target_args'_v1019 = v1021 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1022 : (int32 -> Async<unit>) = Async.Sleep
                let v1023 : Async<unit> = v1022 10
                let _run_target_args'_v1019 = v1023 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1024 : (int32 -> Async<unit>) = Async.Sleep
                let v1025 : Async<unit> = v1024 10
                let _run_target_args'_v1019 = v1025 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1026 : (int32 -> Async<unit>) = Async.Sleep
                let v1027 : Async<unit> = v1026 10
                let _run_target_args'_v1019 = v1027 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1028 : (int32 -> Async<unit>) = Async.Sleep
                let v1029 : Async<unit> = v1028 10
                let _run_target_args'_v1019 = v1029 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1030 : (int32 -> Async<unit>) = Async.Sleep
                let v1031 : Async<unit> = v1030 10
                let _run_target_args'_v1019 = v1031 
                #endif
#else
                let v1032 : (int32 -> Async<unit>) = Async.Sleep
                let v1033 : Async<unit> = v1032 10
                let _run_target_args'_v1019 = v1033 
                #endif
                let v1034 : Async<unit> = _run_target_args'_v1019 
                do! v1034 
                let v1037 : int64 = v4 + 1L
                let v1038 : Async<int64> = method36(v0, v1, v2, v3, v1037)
                return! v1038 
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
    let v1823 : Async<int64> = _let'_v924 
    let _run_target_args'_v9 = v1823 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1825 : unit = ()
    let _let'_v1825 =
        async {
            let v1830 : (int32 -> US9) = method38()
            let v1831 : US9 option = v0 |> Option.map v1830 
            let v1851 : US9 = US9_1
            let v1852 : US9 = v1831 |> Option.defaultValue v1851 
            let v1860 : Async<bool> =
                match v1852 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v1857) -> (* Some *)
                    method21(v1857, v2, v3)
            let! v1860 = v1860 
            let v1861 : bool = v1860 
            let v1862 : bool = v1861 = v1
            if v1862 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v1863 : int64 = v4 % 100L
                let v1864 : bool = v1863 = 0L
                if v1864 then
                    let v1865 : unit = ()
                    let v1866 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v1867 : unit = (fun () -> v1866 (); v1865) ()
                    ()
                (* run_target_args'
                let v1920 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1921 : (int32 -> Async<unit>) = Async.Sleep
                let v1922 : Async<unit> = v1921 10
                let _run_target_args'_v1920 = v1922 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1923 : (int32 -> Async<unit>) = Async.Sleep
                let v1924 : Async<unit> = v1923 10
                let _run_target_args'_v1920 = v1924 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1925 : (int32 -> Async<unit>) = Async.Sleep
                let v1926 : Async<unit> = v1925 10
                let _run_target_args'_v1920 = v1926 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1927 : (int32 -> Async<unit>) = Async.Sleep
                let v1928 : Async<unit> = v1927 10
                let _run_target_args'_v1920 = v1928 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1929 : (int32 -> Async<unit>) = Async.Sleep
                let v1930 : Async<unit> = v1929 10
                let _run_target_args'_v1920 = v1930 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1931 : (int32 -> Async<unit>) = Async.Sleep
                let v1932 : Async<unit> = v1931 10
                let _run_target_args'_v1920 = v1932 
                #endif
#else
                let v1933 : (int32 -> Async<unit>) = Async.Sleep
                let v1934 : Async<unit> = v1933 10
                let _run_target_args'_v1920 = v1934 
                #endif
                let v1935 : Async<unit> = _run_target_args'_v1920 
                do! v1935 
                let v1938 : int64 = v4 + 1L
                let v1939 : Async<int64> = method36(v0, v1, v2, v3, v1938)
                return! v1939 
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
    let v2724 : Async<int64> = _let'_v1825 
    let _run_target_args'_v9 = v2724 
    #endif
#else
    let v2726 : unit = ()
    let _let'_v2726 =
        async {
            let v2731 : (int32 -> US9) = method38()
            let v2732 : US9 option = v0 |> Option.map v2731 
            let v2752 : US9 = US9_1
            let v2753 : US9 = v2732 |> Option.defaultValue v2752 
            let v2761 : Async<bool> =
                match v2753 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v2758) -> (* Some *)
                    method21(v2758, v2, v3)
            let! v2761 = v2761 
            let v2762 : bool = v2761 
            let v2763 : bool = v2762 = v1
            if v2763 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v2764 : int64 = v4 % 100L
                let v2765 : bool = v2764 = 0L
                if v2765 then
                    let v2766 : unit = ()
                    let v2767 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v2768 : unit = (fun () -> v2767 (); v2766) ()
                    ()
                (* run_target_args'
                let v2821 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2822 : (int32 -> Async<unit>) = Async.Sleep
                let v2823 : Async<unit> = v2822 10
                let _run_target_args'_v2821 = v2823 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2824 : (int32 -> Async<unit>) = Async.Sleep
                let v2825 : Async<unit> = v2824 10
                let _run_target_args'_v2821 = v2825 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2826 : (int32 -> Async<unit>) = Async.Sleep
                let v2827 : Async<unit> = v2826 10
                let _run_target_args'_v2821 = v2827 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2828 : (int32 -> Async<unit>) = Async.Sleep
                let v2829 : Async<unit> = v2828 10
                let _run_target_args'_v2821 = v2829 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2830 : (int32 -> Async<unit>) = Async.Sleep
                let v2831 : Async<unit> = v2830 10
                let _run_target_args'_v2821 = v2831 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2832 : (int32 -> Async<unit>) = Async.Sleep
                let v2833 : Async<unit> = v2832 10
                let _run_target_args'_v2821 = v2833 
                #endif
#else
                let v2834 : (int32 -> Async<unit>) = Async.Sleep
                let v2835 : Async<unit> = v2834 10
                let _run_target_args'_v2821 = v2835 
                #endif
                let v2836 : Async<unit> = _run_target_args'_v2821 
                do! v2836 
                let v2839 : int64 = v4 + 1L
                let v2840 : Async<int64> = method36(v0, v1, v2, v3, v2839)
                return! v2840 
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
    let v3625 : Async<int64> = _let'_v2726 
    let _run_target_args'_v9 = v3625 
    #endif
    let v3626 : Async<int64> = _run_target_args'_v9 
    v3626
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
            let v47 : US9 = US9_1
            let v48 : US9 = v27 |> Option.defaultValue v47 
            let v56 : Async<bool> =
                match v48 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v53) -> (* Some *)
                    method21(v53, v1, v2)
            let! v56 = v56 
            let v57 : bool = v56 
            let v58 : bool = v57 = false
            if v58 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v59 : int32 = v2 + 1
                let v60 : Async<int32> = method42(v0, v1, v59)
                return! v60 
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
    let v320 : Async<int32> = _let'_v21 
    let _run_target_args'_v7 = v320 
    #endif
#if FABLE_COMPILER_PYTHON
    let v322 : unit = ()
    let _let'_v322 =
        async {
            let v327 : (int32 -> US9) = method38()
            let v328 : US9 option = v0 |> Option.map v327 
            let v348 : US9 = US9_1
            let v349 : US9 = v328 |> Option.defaultValue v348 
            let v357 : Async<bool> =
                match v349 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v354) -> (* Some *)
                    method21(v354, v1, v2)
            let! v357 = v357 
            let v358 : bool = v357 
            let v359 : bool = v358 = false
            if v359 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v360 : int32 = v2 + 1
                let v361 : Async<int32> = method42(v0, v1, v360)
                return! v361 
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
    let v621 : Async<int32> = _let'_v322 
    let _run_target_args'_v7 = v621 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v623 : unit = ()
    let _let'_v623 =
        async {
            let v628 : (int32 -> US9) = method38()
            let v629 : US9 option = v0 |> Option.map v628 
            let v649 : US9 = US9_1
            let v650 : US9 = v629 |> Option.defaultValue v649 
            let v658 : Async<bool> =
                match v650 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v655) -> (* Some *)
                    method21(v655, v1, v2)
            let! v658 = v658 
            let v659 : bool = v658 
            let v660 : bool = v659 = false
            if v660 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v661 : int32 = v2 + 1
                let v662 : Async<int32> = method42(v0, v1, v661)
                return! v662 
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
    let v922 : Async<int32> = _let'_v623 
    let _run_target_args'_v7 = v922 
    #endif
#else
    let v924 : unit = ()
    let _let'_v924 =
        async {
            let v929 : (int32 -> US9) = method38()
            let v930 : US9 option = v0 |> Option.map v929 
            let v950 : US9 = US9_1
            let v951 : US9 = v930 |> Option.defaultValue v950 
            let v959 : Async<bool> =
                match v951 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v956) -> (* Some *)
                    method21(v956, v1, v2)
            let! v959 = v959 
            let v960 : bool = v959 
            let v961 : bool = v960 = false
            if v961 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v962 : int32 = v2 + 1
                let v963 : Async<int32> = method42(v0, v1, v962)
                return! v963 
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
    let v1223 : Async<int32> = _let'_v924 
    let _run_target_args'_v7 = v1223 
    #endif
    let v1224 : Async<int32> = _run_target_args'_v7 
    v1224
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
let v2 : unit = ()
let v3 : (unit -> unit) = closure0()
let v4 : unit = (fun () -> v3 (); v2) ()
let v19 : (string -> (int32 -> Async<bool>)) = closure3()
let test_port_open x = v19 x
let v20 : (int32 -> (string -> (int32 -> Async<bool>))) = closure11()
let test_port_open_timeout x = v20 x
let v21 : (int32 option -> (bool -> (string -> (int32 -> Async<int64>)))) = closure18()
let wait_for_port_access x = v21 x
let v22 : (int32 option -> (string -> (int32 -> Async<int32>))) = closure24()
let get_available_port x = v22 x
()
