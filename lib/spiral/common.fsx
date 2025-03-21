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

type Disposable (f : unit -> unit) = interface System.IDisposable with member _.Dispose () = f ()
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
    | US6_0
    | US6_1
and [<Struct>] US7 =
    | US7_0 of f0_0 : US6
    | US7_1
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
and method6 (v0 : (unit -> unit)) : (unit -> unit) =
    v0
and method7 (v0 : (unit -> unit)) : (unit -> unit) =
    v0
and closure3 () (v0 : (unit -> unit)) : System.IDisposable =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : (unit -> unit) = method6(v0)
    let v7 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v6 "$0()" )
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : (unit -> unit) = method6(v0)
    let v9 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v8 "$0()" )
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : (unit -> unit) = method6(v0)
    let v11 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v10 "$0()" )
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : (unit -> unit) = method7(v0)
    let v13 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v12 () }
    let _run_target_args'_v5 = v13 
    #endif
#if FABLE_COMPILER_PYTHON
    let v14 : (unit -> unit) = method7(v0)
    let v15 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v14 () }
    let _run_target_args'_v5 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v16 : (unit -> unit) = method7(v0)
    let v17 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v16 () }
    let _run_target_args'_v5 = v17 
    #endif
#else
    let v18 : (unit -> unit) = method7(v0)
    let v19 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v18 () }
    let _run_target_args'_v5 = v19 
    #endif
    let v20 : System.IDisposable = _run_target_args'_v5 
    v20
and closure6 () (v0 : US6) : US7 =
    US7_0(v0)
and closure7 (v0 : int32, v1 : (unit -> unit), v2 : int32) () : US6 =
    let v3 : bool = v2 < v0
    if v3 then
        v1 ()
        US6_0
    else
        US6_1
and method9 (v0 : US0) : bool =
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
and closure10 () (v0 : int64) : US2 =
    US2_0(v0)
and method11 () : (int64 -> US2) =
    closure10()
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
    let v176 : (int64 -> US2) = method11()
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
    let v343 : (int64 -> US2) = method11()
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
    let v512 : (int64 -> US2) = method11()
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
    let v559 : (int64 -> US2) = method11()
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
    let v726 : (int64 -> US2) = method11()
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
    let v893 : (int64 -> US2) = method11()
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
    let v1060 : (int64 -> US2) = method11()
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
and closure11 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and method15 (v0 : char) : string =
    let v1 : string = method16()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure11(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = v2.l0
    v12
and method17 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method14 () : string =
    
    
    
    
    
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
and method19 (v0 : int32, v1 : exn) : string =
    let v2 : string = method16()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure11(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "retry"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure11(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure11(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure11(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure11(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "ex"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure11(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure11(v3, v69)
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
    let v121 : (unit -> unit) = closure11(v3, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v127 : string = " }"
    let v128 : string = $"{v127}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure11(v3, v128)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v136 : string = v3.l0
    v136
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
and method18 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : exn) : string =
    let v10 : string = method19(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "common.retry_fn"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method20(v14)
and closure12 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure14 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure13 () (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure14(v0)
    let v3 : unit = (fun () -> v2 (); v1) ()
    ()
and method21 (v0 : string) : unit =
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure0()
    let v5 : unit = (fun () -> v4 (); v3) ()
    let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
    let v44 : unit = ()
    let v45 : (unit -> unit) = closure12(v26)
    let v46 : unit = (fun () -> v45 (); v44) ()
    let v49 : (string -> unit) = closure13()
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
and closure9 (v0 : int32, v1 : exn) () : unit =
    let v2 : US0 = US0_3
    let v3 : bool = method9(v2)
    if v3 then
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method10(v29, v30, v31, v32, v33, v34)
        let v48 : string = method14()
        let v49 : string = method18(v29, v30, v31, v32, v33, v34, v47, v48, v0, v1)
        method21(v49)
and closure8 (v0 : int32) (v1 : exn) : US7 =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure9(v0, v1)
    let v4 : unit = (fun () -> v3 (); v2) ()
    US7_1
and method8 (v0 : int32, v1 : (unit -> unit), v2 : int32) : US6 =
    let v3 : (US6 -> US7) = closure6()
    let v4 : (unit -> US6) = closure7(v0, v1, v2)
    let v5 : (exn -> US7) = closure8(v2)
    let v7 : US7 = US7_1
    let result = ref v7
    try
        result.Value <- v4 () |> v3 
    with ex ->
        result.Value <- v5 ex 
    let v8 : US7 = result.Value
    match v8 with
    | US7_1 -> (* None *)
        let v13 : int32 = v2 + 1
        method8(v0, v1, v13)
    | US7_0(v12) -> (* Some *)
        v12
and closure5 (v0 : int32) (v1 : (unit -> unit)) : unit option =
    let v2 : int32 = 0
    let v3 : US6 = method8(v0, v1, v2)
    match v3 with
    | US6_1 -> (* None *)
        let v9 : unit option = None
        v9
    | US6_0 -> (* Some *)
        let v5 : unit option = Some () 
        v5
and closure4 () (v0 : int32) : ((unit -> unit) -> unit option) =
    closure5(v0)
and method22 (v0 : (unit -> unit)) : (unit -> unit) =
    v0
and closure16 (v0 : Lazy<unit>) () : unit =
    v0.Value
    ()
and closure15 () (v0 : (unit -> unit)) : (unit -> unit) =
    let v1 : (unit -> unit) = method22(v0)
    let v6 : Lazy<unit> = lazy v1 ()
    closure16(v6)
let v2 : unit = ()
let v3 : (unit -> unit) = closure0()
let v4 : unit = (fun () -> v3 (); v2) ()
let v19 : ((unit -> unit) -> System.IDisposable) = closure3()
let new_disposable x = v19 x
let v20 : (int32 -> ((unit -> unit) -> unit option)) = closure4()
let retry_fn x = v20 x
let v21 : ((unit -> unit) -> (unit -> unit)) = closure15()
let memoize x = v21 x
()
