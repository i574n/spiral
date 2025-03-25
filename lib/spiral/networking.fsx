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
    let v209 : US2 =
        if v133 then
            US2_1
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
            US2_0(v203)
    struct (v127, v209)
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
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure0()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v38 : Mut0, v39 : Mut1, v40 : Mut2, v41 : Mut3, v42 : Mut4, v43 : int64 option) = TraceState.trace_state.Value
    let v56 : US0 = v42.l0
    let v57 : bool = v40.l0
    let v58 : bool = v57 = false
    if v58 then
        false
    else
        let v59 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v0
        let v60 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v56
        let v61 : bool = v59 >= v60
        v61
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
    let v187 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v190 : (int64 -> US2) = method10()
    let v191 : US2 option = v5 |> Option.map v190 
    let v211 : US2 = US2_1
    let v212 : US2 = v191 |> Option.defaultValue v211 
    let v344 : System.DateTime =
        match v212 with
        | US2_1 -> (* None *)
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
        | US2_0(v216) -> (* Some *)
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
    let v346 : string = method11()
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
    let v371 : (int64 -> US2) = method10()
    let v372 : US2 option = v5 |> Option.map v371 
    let v392 : US2 = US2_1
    let v393 : US2 = v372 |> Option.defaultValue v392 
    let v525 : System.DateTime =
        match v393 with
        | US2_1 -> (* None *)
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
        | US2_0(v397) -> (* Some *)
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
    let v527 : string = method11()
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
    let v554 : (int64 -> US2) = method10()
    let v555 : US2 option = v5 |> Option.map v554 
    let v575 : US2 = US2_1
    let v576 : US2 = v555 |> Option.defaultValue v575 
    let v588 : uint64 =
        match v576 with
        | US2_1 -> (* None *)
            v551
        | US2_0(v580) -> (* Some *)
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
    let v601 : (int64 -> US2) = method10()
    let v602 : US2 option = v5 |> Option.map v601 
    let v622 : US2 = US2_1
    let v623 : US2 = v602 |> Option.defaultValue v622 
    let v755 : System.DateTime =
        match v623 with
        | US2_1 -> (* None *)
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
        | US2_0(v627) -> (* Some *)
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
    let v757 : string = method12()
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
    let v782 : (int64 -> US2) = method10()
    let v783 : US2 option = v5 |> Option.map v782 
    let v803 : US2 = US2_1
    let v804 : US2 = v783 |> Option.defaultValue v803 
    let v936 : System.DateTime =
        match v804 with
        | US2_1 -> (* None *)
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
        | US2_0(v808) -> (* Some *)
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
    let v938 : string = method12()
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
    let v963 : (int64 -> US2) = method10()
    let v964 : US2 option = v5 |> Option.map v963 
    let v984 : US2 = US2_1
    let v985 : US2 = v964 |> Option.defaultValue v984 
    let v1117 : System.DateTime =
        match v985 with
        | US2_1 -> (* None *)
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
        | US2_0(v989) -> (* Some *)
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
    let v1119 : string = method12()
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
    let v1144 : (int64 -> US2) = method10()
    let v1145 : US2 option = v5 |> Option.map v1144 
    let v1165 : US2 = US2_1
    let v1166 : US2 = v1145 |> Option.defaultValue v1165 
    let v1298 : System.DateTime =
        match v1166 with
        | US2_1 -> (* None *)
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
        | US2_0(v1170) -> (* Some *)
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
    let v1300 : string = method12()
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
and method14 () : string =
    let v0 : string = ""
    v0
and closure7 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v4 : string = v2 + v1 
    v0.l0 <- v4
    ()
and method15 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method13 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method14()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure7(v9, v14)
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
    let v176 : string = method15()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[90m"
    let v192 : string = method15()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[90m"
    let v208 : string = method15()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[90m"
    let v224 : string = method15()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
and method17 (v0 : string) : string =
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
and method16 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method14()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure7(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "port"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure7(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure7(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v73 : string = $"{v8}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure7(v11, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure7(v11, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "ex"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure7(v11, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v52}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure7(v11, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    let v145 : string = $"{v9}"
    let v153 : unit = ()
    let v154 : (unit -> unit) = closure7(v11, v145)
    let v155 : unit = (fun () -> v154 (); v153) ()
    let v163 : string = " }"
    let v164 : string = $"{v163}"
    let v172 : unit = ()
    let v173 : (unit -> unit) = closure7(v11, v164)
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
    let v213 : string = "networking.test_port_open"
    let v214 : string = v208 + v213 
    let v219 : string = " / "
    let v220 : string = v214 + v219 
    let v224 : string = v220 + v180 
    method17(v224)
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
and method18 (v0 : string) : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure0()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v38 : Mut0, v39 : Mut1, v40 : Mut2, v41 : Mut3, v42 : Mut4, v43 : int64 option) = TraceState.trace_state.Value
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure8(v38)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v63 : (string -> unit) = closure9()
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
and closure5 (v0 : int32, v1 : exn) () : unit =
    let v2 : US0 = US0_0
    let v3 : bool = method8(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure0()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method9(v41, v42, v43, v44, v45, v46)
        let v60 : string = method13()
        (* run_target_args'
        let v65 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v65 = v67 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v65 = v71 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v65 = v75 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v79 : string = $"%A{v1}"
        let _run_target_args'_v65 = v79 
        #endif
#if FABLE_COMPILER_PYTHON
        let v83 : string = $"%A{v1}"
        let _run_target_args'_v65 = v83 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v87 : string = $"%A{v1}"
        let _run_target_args'_v65 = v87 
        #endif
#else
        let v90 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v65 = v90 
        #endif
        let v91 : string = _run_target_args'_v65 
        let v97 : string = method16(v41, v42, v43, v44, v45, v46, v59, v60, v0, v91)
        method18(v97)
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
            let v12282 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v12282 = v12282 
            let v12283 : System.Threading.CancellationToken = v12282 
            (* run_target_args'
            let v12288 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v12290 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12288 = v12290 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v12294 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12288 = v12294 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v12298 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12288 = v12298 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v12302 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12288 = v12302 
            #endif
#if FABLE_COMPILER_PYTHON
            let v12306 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12288 = v12306 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v12310 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12288 = v12310 
            #endif
#else
            let v12313 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v12288 = v12313 
            #endif
            let v12314 : System_Net_Sockets_TcpClient = _run_target_args'_v12288 
            use v12314 = v12314 
            let v12320 : System_Net_Sockets_TcpClient = v12314 
            try
                (* run_target_args'
                let v12429 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v12431 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v12429 = v12431 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v12435 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v12429 = v12435 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v12439 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v12429 = v12439 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v12443 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v12429 = v12443 
                #endif
#if FABLE_COMPILER_PYTHON
                let v12447 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v12429 = v12447 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v12451 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v12429 = v12451 
                #endif
#else
                let v12454 : System.Threading.Tasks.ValueTask = v12320.ConnectAsync (v0, v1, v12283)
                let _run_target_args'_v12429 = v12454 
                #endif
                let v12455 : System.Threading.Tasks.ValueTask = _run_target_args'_v12429 
                (* run_target_args'
                let v12465 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v12467 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v12465 = v12467 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v12471 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v12465 = v12471 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v12475 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v12465 = v12475 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v12479 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v12465 = v12479 
                #endif
#if FABLE_COMPILER_PYTHON
                let v12483 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v12465 = v12483 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v12487 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v12465 = v12487 
                #endif
#else
                let v12490 : (unit -> System.Threading.Tasks.Task) = v12455.AsTask
                let v12491 : System.Threading.Tasks.Task = v12490 ()
                let _run_target_args'_v12465 = v12491 
                #endif
                let v12492 : System.Threading.Tasks.Task = _run_target_args'_v12465 
                (* run_target_args'
                let v12502 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v12504 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v12502 = v12504 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v12508 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v12502 = v12508 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v12512 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v12502 = v12512 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v12515 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v12516 : Async<unit> = v12515 v12492
                let _run_target_args'_v12502 = v12516 
                #endif
#if FABLE_COMPILER_PYTHON
                let v12517 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v12518 : Async<unit> = v12517 v12492
                let _run_target_args'_v12502 = v12518 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v12519 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v12520 : Async<unit> = v12519 v12492
                let _run_target_args'_v12502 = v12520 
                #endif
#else
                let v12521 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v12522 : Async<unit> = v12521 v12492
                let _run_target_args'_v12502 = v12522 
                #endif
                let v12523 : Async<unit> = _run_target_args'_v12502 
                do! v12523 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v12829 : exn = ex
                let v12926 : unit = ()
                let v12927 : (unit -> unit) = closure5(v1, v12829)
                let v12928 : unit = (fun () -> v12927 (); v12926) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v13222 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v25484 : Async<bool> = _let'_v20 
    let _run_target_args'_v6 = v25484 
    #endif
#if FABLE_COMPILER_PYTHON
    let v25486 : unit = ()
    let _let'_v25486 =
        async {
            let v37748 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v37748 = v37748 
            let v37749 : System.Threading.CancellationToken = v37748 
            (* run_target_args'
            let v37754 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v37756 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v37754 = v37756 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v37760 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v37754 = v37760 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v37764 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v37754 = v37764 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v37768 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v37754 = v37768 
            #endif
#if FABLE_COMPILER_PYTHON
            let v37772 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v37754 = v37772 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v37776 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v37754 = v37776 
            #endif
#else
            let v37779 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v37754 = v37779 
            #endif
            let v37780 : System_Net_Sockets_TcpClient = _run_target_args'_v37754 
            use v37780 = v37780 
            let v37786 : System_Net_Sockets_TcpClient = v37780 
            try
                (* run_target_args'
                let v37895 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v37897 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v37895 = v37897 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v37901 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v37895 = v37901 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v37905 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v37895 = v37905 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v37909 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v37895 = v37909 
                #endif
#if FABLE_COMPILER_PYTHON
                let v37913 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v37895 = v37913 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v37917 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v37895 = v37917 
                #endif
#else
                let v37920 : System.Threading.Tasks.ValueTask = v37786.ConnectAsync (v0, v1, v37749)
                let _run_target_args'_v37895 = v37920 
                #endif
                let v37921 : System.Threading.Tasks.ValueTask = _run_target_args'_v37895 
                (* run_target_args'
                let v37931 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v37933 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v37931 = v37933 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v37937 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v37931 = v37937 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v37941 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v37931 = v37941 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v37945 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v37931 = v37945 
                #endif
#if FABLE_COMPILER_PYTHON
                let v37949 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v37931 = v37949 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v37953 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v37931 = v37953 
                #endif
#else
                let v37956 : (unit -> System.Threading.Tasks.Task) = v37921.AsTask
                let v37957 : System.Threading.Tasks.Task = v37956 ()
                let _run_target_args'_v37931 = v37957 
                #endif
                let v37958 : System.Threading.Tasks.Task = _run_target_args'_v37931 
                (* run_target_args'
                let v37968 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v37970 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v37968 = v37970 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v37974 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v37968 = v37974 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v37978 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v37968 = v37978 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v37981 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v37982 : Async<unit> = v37981 v37958
                let _run_target_args'_v37968 = v37982 
                #endif
#if FABLE_COMPILER_PYTHON
                let v37983 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v37984 : Async<unit> = v37983 v37958
                let _run_target_args'_v37968 = v37984 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v37985 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v37986 : Async<unit> = v37985 v37958
                let _run_target_args'_v37968 = v37986 
                #endif
#else
                let v37987 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v37988 : Async<unit> = v37987 v37958
                let _run_target_args'_v37968 = v37988 
                #endif
                let v37989 : Async<unit> = _run_target_args'_v37968 
                do! v37989 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v38295 : exn = ex
                let v38392 : unit = ()
                let v38393 : (unit -> unit) = closure5(v1, v38295)
                let v38394 : unit = (fun () -> v38393 (); v38392) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v38688 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v50950 : Async<bool> = _let'_v25486 
    let _run_target_args'_v6 = v50950 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v50952 : unit = ()
    let _let'_v50952 =
        async {
            let v63214 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v63214 = v63214 
            let v63215 : System.Threading.CancellationToken = v63214 
            (* run_target_args'
            let v63220 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v63222 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v63220 = v63222 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v63226 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v63220 = v63226 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63230 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v63220 = v63230 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v63234 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v63220 = v63234 
            #endif
#if FABLE_COMPILER_PYTHON
            let v63238 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v63220 = v63238 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v63242 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v63220 = v63242 
            #endif
#else
            let v63245 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v63220 = v63245 
            #endif
            let v63246 : System_Net_Sockets_TcpClient = _run_target_args'_v63220 
            use v63246 = v63246 
            let v63252 : System_Net_Sockets_TcpClient = v63246 
            try
                (* run_target_args'
                let v63361 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v63363 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v63361 = v63363 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v63367 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v63361 = v63367 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v63371 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v63361 = v63371 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v63375 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v63361 = v63375 
                #endif
#if FABLE_COMPILER_PYTHON
                let v63379 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v63361 = v63379 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v63383 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v63361 = v63383 
                #endif
#else
                let v63386 : System.Threading.Tasks.ValueTask = v63252.ConnectAsync (v0, v1, v63215)
                let _run_target_args'_v63361 = v63386 
                #endif
                let v63387 : System.Threading.Tasks.ValueTask = _run_target_args'_v63361 
                (* run_target_args'
                let v63397 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v63399 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v63397 = v63399 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v63403 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v63397 = v63403 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v63407 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v63397 = v63407 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v63411 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v63397 = v63411 
                #endif
#if FABLE_COMPILER_PYTHON
                let v63415 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v63397 = v63415 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v63419 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v63397 = v63419 
                #endif
#else
                let v63422 : (unit -> System.Threading.Tasks.Task) = v63387.AsTask
                let v63423 : System.Threading.Tasks.Task = v63422 ()
                let _run_target_args'_v63397 = v63423 
                #endif
                let v63424 : System.Threading.Tasks.Task = _run_target_args'_v63397 
                (* run_target_args'
                let v63434 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v63436 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v63434 = v63436 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v63440 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v63434 = v63440 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v63444 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v63434 = v63444 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v63447 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v63448 : Async<unit> = v63447 v63424
                let _run_target_args'_v63434 = v63448 
                #endif
#if FABLE_COMPILER_PYTHON
                let v63449 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v63450 : Async<unit> = v63449 v63424
                let _run_target_args'_v63434 = v63450 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v63451 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v63452 : Async<unit> = v63451 v63424
                let _run_target_args'_v63434 = v63452 
                #endif
#else
                let v63453 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v63454 : Async<unit> = v63453 v63424
                let _run_target_args'_v63434 = v63454 
                #endif
                let v63455 : Async<unit> = _run_target_args'_v63434 
                do! v63455 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v63761 : exn = ex
                let v63858 : unit = ()
                let v63859 : (unit -> unit) = closure5(v1, v63761)
                let v63860 : unit = (fun () -> v63859 (); v63858) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v64154 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v76416 : Async<bool> = _let'_v50952 
    let _run_target_args'_v6 = v76416 
    #endif
#else
    let v76418 : unit = ()
    let _let'_v76418 =
        async {
            let v88680 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v88680 = v88680 
            let v88681 : System.Threading.CancellationToken = v88680 
            (* run_target_args'
            let v88686 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v88688 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v88686 = v88688 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v88692 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v88686 = v88692 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v88696 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v88686 = v88696 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v88700 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v88686 = v88700 
            #endif
#if FABLE_COMPILER_PYTHON
            let v88704 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v88686 = v88704 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v88708 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v88686 = v88708 
            #endif
#else
            let v88711 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v88686 = v88711 
            #endif
            let v88712 : System_Net_Sockets_TcpClient = _run_target_args'_v88686 
            use v88712 = v88712 
            let v88718 : System_Net_Sockets_TcpClient = v88712 
            try
                (* run_target_args'
                let v88827 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v88829 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v88827 = v88829 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v88833 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v88827 = v88833 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v88837 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v88827 = v88837 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v88841 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v88827 = v88841 
                #endif
#if FABLE_COMPILER_PYTHON
                let v88845 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v88827 = v88845 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v88849 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v88827 = v88849 
                #endif
#else
                let v88852 : System.Threading.Tasks.ValueTask = v88718.ConnectAsync (v0, v1, v88681)
                let _run_target_args'_v88827 = v88852 
                #endif
                let v88853 : System.Threading.Tasks.ValueTask = _run_target_args'_v88827 
                (* run_target_args'
                let v88863 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v88865 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v88863 = v88865 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v88869 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v88863 = v88869 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v88873 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v88863 = v88873 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v88877 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v88863 = v88877 
                #endif
#if FABLE_COMPILER_PYTHON
                let v88881 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v88863 = v88881 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v88885 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v88863 = v88885 
                #endif
#else
                let v88888 : (unit -> System.Threading.Tasks.Task) = v88853.AsTask
                let v88889 : System.Threading.Tasks.Task = v88888 ()
                let _run_target_args'_v88863 = v88889 
                #endif
                let v88890 : System.Threading.Tasks.Task = _run_target_args'_v88863 
                (* run_target_args'
                let v88900 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v88902 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v88900 = v88902 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v88906 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v88900 = v88906 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v88910 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v88900 = v88910 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v88913 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v88914 : Async<unit> = v88913 v88890
                let _run_target_args'_v88900 = v88914 
                #endif
#if FABLE_COMPILER_PYTHON
                let v88915 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v88916 : Async<unit> = v88915 v88890
                let _run_target_args'_v88900 = v88916 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v88917 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v88918 : Async<unit> = v88917 v88890
                let _run_target_args'_v88900 = v88918 
                #endif
#else
                let v88919 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v88920 : Async<unit> = v88919 v88890
                let _run_target_args'_v88900 = v88920 
                #endif
                let v88921 : Async<unit> = _run_target_args'_v88900 
                do! v88921 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v89227 : exn = ex
                let v89324 : unit = ()
                let v89325 : (unit -> unit) = closure5(v1, v89227)
                let v89326 : unit = (fun () -> v89325 (); v89324) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v89620 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v101882 : Async<bool> = _let'_v76418 
    let _run_target_args'_v6 = v101882 
    #endif
    let v101883 : Async<bool> = _run_target_args'_v6 
    v101883
and method6 (v0 : string, v1 : int32) : Async<bool> =
    method7(v0, v1)
and closure4 (v0 : string) (v1 : int32) : Async<bool> =
    method6(v0, v1)
and closure3 () (v0 : string) : (int32 -> Async<bool>) =
    closure4(v0)
and closure14 () (v0 : bool) : US7 =
    US7_0(v0)
and method24 () : (bool -> US7) =
    closure14()
and closure15 () (v0 : exn) : US7 =
    US7_1(v0)
and method25 () : (exn -> US7) =
    closure15()
and method23 (v0 : Async<Choice<bool, exn>>) : Async<US7> =
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
            let v516 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v521 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v523 : US7 = null |> unbox<US7>
            let _run_target_args'_v521 = v523 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v527 : US7 = null |> unbox<US7>
            let _run_target_args'_v521 = v527 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v531 : US7 = null |> unbox<US7>
            let _run_target_args'_v521 = v531 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v535 : US7 = null |> unbox<US7>
            let _run_target_args'_v521 = v535 
            #endif
#if FABLE_COMPILER_PYTHON
            let v539 : US7 = null |> unbox<US7>
            let _run_target_args'_v521 = v539 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v542 : (bool -> US7) = method24()
            let v543 : (exn -> US7) = method25()
            let v544 : US7 = match v516 with Choice1Of2 x -> v542 x | Choice2Of2 x -> v543 x
            let _run_target_args'_v521 = v544 
            #endif
#else
            let v545 : (bool -> US7) = method24()
            let v546 : (exn -> US7) = method25()
            let v547 : US7 = match v516 with Choice1Of2 x -> v545 x | Choice2Of2 x -> v546 x
            let _run_target_args'_v521 = v547 
            #endif
            let v548 : US7 = _run_target_args'_v521 
            return v548 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1048 : Async<US7> = _let'_v19 
    let _run_target_args'_v5 = v1048 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1050 : unit = ()
    let _let'_v1050 =
        async {
            let! v0 = v0 
            let v1547 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v1552 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1554 : US7 = null |> unbox<US7>
            let _run_target_args'_v1552 = v1554 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1558 : US7 = null |> unbox<US7>
            let _run_target_args'_v1552 = v1558 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1562 : US7 = null |> unbox<US7>
            let _run_target_args'_v1552 = v1562 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1566 : US7 = null |> unbox<US7>
            let _run_target_args'_v1552 = v1566 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1570 : US7 = null |> unbox<US7>
            let _run_target_args'_v1552 = v1570 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1573 : (bool -> US7) = method24()
            let v1574 : (exn -> US7) = method25()
            let v1575 : US7 = match v1547 with Choice1Of2 x -> v1573 x | Choice2Of2 x -> v1574 x
            let _run_target_args'_v1552 = v1575 
            #endif
#else
            let v1576 : (bool -> US7) = method24()
            let v1577 : (exn -> US7) = method25()
            let v1578 : US7 = match v1547 with Choice1Of2 x -> v1576 x | Choice2Of2 x -> v1577 x
            let _run_target_args'_v1552 = v1578 
            #endif
            let v1579 : US7 = _run_target_args'_v1552 
            return v1579 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2079 : Async<US7> = _let'_v1050 
    let _run_target_args'_v5 = v2079 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2081 : unit = ()
    let _let'_v2081 =
        async {
            let! v0 = v0 
            let v2578 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v2583 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2585 : US7 = null |> unbox<US7>
            let _run_target_args'_v2583 = v2585 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2589 : US7 = null |> unbox<US7>
            let _run_target_args'_v2583 = v2589 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2593 : US7 = null |> unbox<US7>
            let _run_target_args'_v2583 = v2593 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2597 : US7 = null |> unbox<US7>
            let _run_target_args'_v2583 = v2597 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2601 : US7 = null |> unbox<US7>
            let _run_target_args'_v2583 = v2601 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2604 : (bool -> US7) = method24()
            let v2605 : (exn -> US7) = method25()
            let v2606 : US7 = match v2578 with Choice1Of2 x -> v2604 x | Choice2Of2 x -> v2605 x
            let _run_target_args'_v2583 = v2606 
            #endif
#else
            let v2607 : (bool -> US7) = method24()
            let v2608 : (exn -> US7) = method25()
            let v2609 : US7 = match v2578 with Choice1Of2 x -> v2607 x | Choice2Of2 x -> v2608 x
            let _run_target_args'_v2583 = v2609 
            #endif
            let v2610 : US7 = _run_target_args'_v2583 
            return v2610 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3110 : Async<US7> = _let'_v2081 
    let _run_target_args'_v5 = v3110 
    #endif
#else
    let v3112 : unit = ()
    let _let'_v3112 =
        async {
            let! v0 = v0 
            let v3609 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v3614 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3616 : US7 = null |> unbox<US7>
            let _run_target_args'_v3614 = v3616 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3620 : US7 = null |> unbox<US7>
            let _run_target_args'_v3614 = v3620 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3624 : US7 = null |> unbox<US7>
            let _run_target_args'_v3614 = v3624 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3628 : US7 = null |> unbox<US7>
            let _run_target_args'_v3614 = v3628 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3632 : US7 = null |> unbox<US7>
            let _run_target_args'_v3614 = v3632 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3635 : (bool -> US7) = method24()
            let v3636 : (exn -> US7) = method25()
            let v3637 : US7 = match v3609 with Choice1Of2 x -> v3635 x | Choice2Of2 x -> v3636 x
            let _run_target_args'_v3614 = v3637 
            #endif
#else
            let v3638 : (bool -> US7) = method24()
            let v3639 : (exn -> US7) = method25()
            let v3640 : US7 = match v3609 with Choice1Of2 x -> v3638 x | Choice2Of2 x -> v3639 x
            let _run_target_args'_v3614 = v3640 
            #endif
            let v3641 : US7 = _run_target_args'_v3614 
            return v3641 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4141 : Async<US7> = _let'_v3112 
    let _run_target_args'_v5 = v4141 
    #endif
    let v4142 : Async<US7> = _run_target_args'_v5 
    v4142
and method26 (v0 : Async<US7>) : Async<US8> =
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
            let v113 : US7 = v0 
            let v119 : US8 =
                match v113 with
                | US7_0(v114) -> (* C1of2 *)
                    US8_0(v114)
                | US7_1(v116) -> (* C2of2 *)
                    US8_1(v116)
            return v119 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v211 : Async<US8> = _let'_v19 
    let _run_target_args'_v5 = v211 
    #endif
#if FABLE_COMPILER_PYTHON
    let v213 : unit = ()
    let _let'_v213 =
        async {
            let! v0 = v0 
            let v307 : US7 = v0 
            let v313 : US8 =
                match v307 with
                | US7_0(v308) -> (* C1of2 *)
                    US8_0(v308)
                | US7_1(v310) -> (* C2of2 *)
                    US8_1(v310)
            return v313 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v405 : Async<US8> = _let'_v213 
    let _run_target_args'_v5 = v405 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v407 : unit = ()
    let _let'_v407 =
        async {
            let! v0 = v0 
            let v501 : US7 = v0 
            let v507 : US8 =
                match v501 with
                | US7_0(v502) -> (* C1of2 *)
                    US8_0(v502)
                | US7_1(v504) -> (* C2of2 *)
                    US8_1(v504)
            return v507 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v599 : Async<US8> = _let'_v407 
    let _run_target_args'_v5 = v599 
    #endif
#else
    let v601 : unit = ()
    let _let'_v601 =
        async {
            let! v0 = v0 
            let v695 : US7 = v0 
            let v701 : US8 =
                match v695 with
                | US7_0(v696) -> (* C1of2 *)
                    US8_0(v696)
                | US7_1(v698) -> (* C2of2 *)
                    US8_1(v698)
            return v701 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v793 : Async<US8> = _let'_v601 
    let _run_target_args'_v5 = v793 
    #endif
    let v794 : Async<US8> = _run_target_args'_v5 
    v794
and method28 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32) : string =
    let v9 : string = method14()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure7(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "timeout"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure7(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure7(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v72 : string = $"{v8}"
    let v80 : unit = ()
    let v81 : (unit -> unit) = closure7(v10, v72)
    let v82 : unit = (fun () -> v81 (); v80) ()
    let v90 : string = " }"
    let v91 : string = $"{v90}"
    let v99 : unit = ()
    let v100 : (unit -> unit) = closure7(v10, v91)
    let v101 : unit = (fun () -> v100 (); v99) ()
    let v107 : string = v10.l0
    let v108 : int64 = v0.l0
    let v111 : string = " "
    let v112 : string = v6 + v111 
    let v116 : string = v112 + v7 
    let v121 : string = " #"
    let v122 : string = v116 + v121 
    let v126 : (int64 -> string) = _.ToString()
    let v127 : string = v126 v108
    let v131 : string = v122 + v127 
    let v135 : string = v131 + v111 
    let v140 : string = "async.run_with_timeout_async"
    let v141 : string = v135 + v140 
    let v146 : string = " / "
    let v147 : string = v141 + v146 
    let v151 : string = v147 + v107 
    method17(v151)
and closure16 (v0 : int32) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method8(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure0()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method9(v40, v41, v42, v43, v44, v45)
        let v59 : string = method13()
        let v60 : string = method28(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method18(v60)
and method29 () : string =
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method14()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure7(v9, v14)
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
    let v176 : string = method15()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[91m"
    let v192 : string = method15()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[91m"
    let v208 : string = method15()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[91m"
    let v224 : string = method15()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
and method30 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method14()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure7(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "timeout"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure7(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure7(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v73 : string = $"{v8}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure7(v11, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure7(v11, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "ex"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure7(v11, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v52}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure7(v11, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    let v145 : string = $"{v9}"
    let v153 : unit = ()
    let v154 : (unit -> unit) = closure7(v11, v145)
    let v155 : unit = (fun () -> v154 (); v153) ()
    let v163 : string = " }"
    let v164 : string = $"{v163}"
    let v172 : unit = ()
    let v173 : (unit -> unit) = closure7(v11, v164)
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
    let v213 : string = "async.run_with_timeout_async**"
    let v214 : string = v208 + v213 
    let v219 : string = " / "
    let v220 : string = v214 + v219 
    let v224 : string = v220 + v180 
    method17(v224)
and closure17 (v0 : int32, v1 : exn) () : unit =
    let v2 : US0 = US0_4
    let v3 : bool = method8(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure0()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method9(v41, v42, v43, v44, v45, v46)
        let v60 : string = method29()
        (* run_target_args'
        let v65 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v65 = v67 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v65 = v71 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v65 = v75 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v79 : string = $"%A{v1}"
        let _run_target_args'_v65 = v79 
        #endif
#if FABLE_COMPILER_PYTHON
        let v83 : string = $"%A{v1}"
        let _run_target_args'_v65 = v83 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v87 : string = $"%A{v1}"
        let _run_target_args'_v65 = v87 
        #endif
#else
        let v90 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v65 = v90 
        #endif
        let v91 : string = _run_target_args'_v65 
        let v97 : string = method30(v41, v42, v43, v44, v45, v46, v59, v60, v0, v91)
        method18(v97)
and method27 (v0 : int32, v1 : Async<US8>) : Async<US6> =
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
            let v4404 : US8 = v1 
            let v4740 : US6 =
                match v4404 with
                | US8_1(v4407) -> (* Error *)
                    let v4409 : string = $"%A{v4407}"
                    let v4414 : string = "System.TimeoutException"
                    let v4415 : bool = v4409.Contains v4414 
                    if v4415 then
                        let v4478 : unit = ()
                        let v4479 : (unit -> unit) = closure16(v0)
                        let v4480 : unit = (fun () -> v4479 (); v4478) ()
                        US6_1
                    else
                        let v4638 : unit = ()
                        let v4639 : (unit -> unit) = closure17(v0, v4407)
                        let v4640 : unit = (fun () -> v4639 (); v4638) ()
                        US6_1
                | US8_0(v4405) -> (* Ok *)
                    US6_0(v4405)
            return v4740 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9122 : Async<US6> = _let'_v20 
    let _run_target_args'_v6 = v9122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v9124 : unit = ()
    let _let'_v9124 =
        async {
            let! v1 = v1 
            let v13508 : US8 = v1 
            let v13844 : US6 =
                match v13508 with
                | US8_1(v13511) -> (* Error *)
                    let v13513 : string = $"%A{v13511}"
                    let v13518 : string = "System.TimeoutException"
                    let v13519 : bool = v13513.Contains v13518 
                    if v13519 then
                        let v13582 : unit = ()
                        let v13583 : (unit -> unit) = closure16(v0)
                        let v13584 : unit = (fun () -> v13583 (); v13582) ()
                        US6_1
                    else
                        let v13742 : unit = ()
                        let v13743 : (unit -> unit) = closure17(v0, v13511)
                        let v13744 : unit = (fun () -> v13743 (); v13742) ()
                        US6_1
                | US8_0(v13509) -> (* Ok *)
                    US6_0(v13509)
            return v13844 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v18226 : Async<US6> = _let'_v9124 
    let _run_target_args'_v6 = v18226 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18228 : unit = ()
    let _let'_v18228 =
        async {
            let! v1 = v1 
            let v22612 : US8 = v1 
            let v22948 : US6 =
                match v22612 with
                | US8_1(v22615) -> (* Error *)
                    let v22617 : string = $"%A{v22615}"
                    let v22622 : string = "System.TimeoutException"
                    let v22623 : bool = v22617.Contains v22622 
                    if v22623 then
                        let v22686 : unit = ()
                        let v22687 : (unit -> unit) = closure16(v0)
                        let v22688 : unit = (fun () -> v22687 (); v22686) ()
                        US6_1
                    else
                        let v22846 : unit = ()
                        let v22847 : (unit -> unit) = closure17(v0, v22615)
                        let v22848 : unit = (fun () -> v22847 (); v22846) ()
                        US6_1
                | US8_0(v22613) -> (* Ok *)
                    US6_0(v22613)
            return v22948 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v27330 : Async<US6> = _let'_v18228 
    let _run_target_args'_v6 = v27330 
    #endif
#else
    let v27332 : unit = ()
    let _let'_v27332 =
        async {
            let! v1 = v1 
            let v31716 : US8 = v1 
            let v32052 : US6 =
                match v31716 with
                | US8_1(v31719) -> (* Error *)
                    let v31721 : string = $"%A{v31719}"
                    let v31726 : string = "System.TimeoutException"
                    let v31727 : bool = v31721.Contains v31726 
                    if v31727 then
                        let v31790 : unit = ()
                        let v31791 : (unit -> unit) = closure16(v0)
                        let v31792 : unit = (fun () -> v31791 (); v31790) ()
                        US6_1
                    else
                        let v31950 : unit = ()
                        let v31951 : (unit -> unit) = closure17(v0, v31719)
                        let v31952 : unit = (fun () -> v31951 (); v31950) ()
                        US6_1
                | US8_0(v31717) -> (* Ok *)
                    US6_0(v31717)
            return v32052 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v36434 : Async<US6> = _let'_v27332 
    let _run_target_args'_v6 = v36434 
    #endif
    let v36435 : Async<US6> = _run_target_args'_v6 
    v36435
and method22 (v0 : Async<bool>, v1 : int32) : Async<US6> =
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
            let v833 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v835 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v833 = v835 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v839 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v833 = v839 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v843 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v833 = v843 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v846 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v833 = v846 
            #endif
#if FABLE_COMPILER_PYTHON
            let v847 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v833 = v847 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v848 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v833 = v848 
            #endif
#else
            let v849 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v833 = v849 
            #endif
            let v850 : Async<Async<bool>> = _run_target_args'_v833 
            let! v850 = v850 
            let v856 : Async<bool> = v850 
            (* run_target_args'
            let v861 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v863 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v861 = v863 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v867 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v861 = v867 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v871 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v861 = v871 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v874 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v875 : Async<Choice<bool, exn>> = v874 v856
            let _run_target_args'_v861 = v875 
            #endif
#if FABLE_COMPILER_PYTHON
            let v876 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v877 : Async<Choice<bool, exn>> = v876 v856
            let _run_target_args'_v861 = v877 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v878 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v879 : Async<Choice<bool, exn>> = v878 v856
            let _run_target_args'_v861 = v879 
            #endif
#else
            let v880 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v881 : Async<Choice<bool, exn>> = v880 v856
            let _run_target_args'_v861 = v881 
            #endif
            let v882 : Async<Choice<bool, exn>> = _run_target_args'_v861 
            let v888 : Async<US7> = method23(v882)
            let v889 : Async<US8> = method26(v888)
            let v890 : Async<US6> = method27(v1, v889)
            return! v890 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1697 : Async<US6> = _let'_v20 
    let _run_target_args'_v6 = v1697 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1699 : unit = ()
    let _let'_v1699 =
        async {
            (* run_target_args'
            let v2512 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2514 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v2512 = v2514 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2518 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v2512 = v2518 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2522 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v2512 = v2522 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2525 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2512 = v2525 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2526 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2512 = v2526 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2527 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2512 = v2527 
            #endif
#else
            let v2528 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2512 = v2528 
            #endif
            let v2529 : Async<Async<bool>> = _run_target_args'_v2512 
            let! v2529 = v2529 
            let v2535 : Async<bool> = v2529 
            (* run_target_args'
            let v2540 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2542 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v2540 = v2542 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2546 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v2540 = v2546 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2550 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v2540 = v2550 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2553 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2554 : Async<Choice<bool, exn>> = v2553 v2535
            let _run_target_args'_v2540 = v2554 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2555 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2556 : Async<Choice<bool, exn>> = v2555 v2535
            let _run_target_args'_v2540 = v2556 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2557 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2558 : Async<Choice<bool, exn>> = v2557 v2535
            let _run_target_args'_v2540 = v2558 
            #endif
#else
            let v2559 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2560 : Async<Choice<bool, exn>> = v2559 v2535
            let _run_target_args'_v2540 = v2560 
            #endif
            let v2561 : Async<Choice<bool, exn>> = _run_target_args'_v2540 
            let v2567 : Async<US7> = method23(v2561)
            let v2568 : Async<US8> = method26(v2567)
            let v2569 : Async<US6> = method27(v1, v2568)
            return! v2569 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3376 : Async<US6> = _let'_v1699 
    let _run_target_args'_v6 = v3376 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3378 : unit = ()
    let _let'_v3378 =
        async {
            (* run_target_args'
            let v4191 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4193 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v4191 = v4193 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4197 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v4191 = v4197 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4201 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v4191 = v4201 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4204 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4191 = v4204 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4205 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4191 = v4205 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4206 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4191 = v4206 
            #endif
#else
            let v4207 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4191 = v4207 
            #endif
            let v4208 : Async<Async<bool>> = _run_target_args'_v4191 
            let! v4208 = v4208 
            let v4214 : Async<bool> = v4208 
            (* run_target_args'
            let v4219 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4221 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v4219 = v4221 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4225 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v4219 = v4225 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4229 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v4219 = v4229 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4232 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4233 : Async<Choice<bool, exn>> = v4232 v4214
            let _run_target_args'_v4219 = v4233 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4234 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4235 : Async<Choice<bool, exn>> = v4234 v4214
            let _run_target_args'_v4219 = v4235 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4236 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4237 : Async<Choice<bool, exn>> = v4236 v4214
            let _run_target_args'_v4219 = v4237 
            #endif
#else
            let v4238 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4239 : Async<Choice<bool, exn>> = v4238 v4214
            let _run_target_args'_v4219 = v4239 
            #endif
            let v4240 : Async<Choice<bool, exn>> = _run_target_args'_v4219 
            let v4246 : Async<US7> = method23(v4240)
            let v4247 : Async<US8> = method26(v4246)
            let v4248 : Async<US6> = method27(v1, v4247)
            return! v4248 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5055 : Async<US6> = _let'_v3378 
    let _run_target_args'_v6 = v5055 
    #endif
#else
    let v5057 : unit = ()
    let _let'_v5057 =
        async {
            (* run_target_args'
            let v5870 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v5872 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v5870 = v5872 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v5876 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v5870 = v5876 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v5880 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v5870 = v5880 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v5883 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v5870 = v5883 
            #endif
#if FABLE_COMPILER_PYTHON
            let v5884 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v5870 = v5884 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v5885 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v5870 = v5885 
            #endif
#else
            let v5886 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v5870 = v5886 
            #endif
            let v5887 : Async<Async<bool>> = _run_target_args'_v5870 
            let! v5887 = v5887 
            let v5893 : Async<bool> = v5887 
            (* run_target_args'
            let v5898 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v5900 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v5898 = v5900 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v5904 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v5898 = v5904 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v5908 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v5898 = v5908 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v5911 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v5912 : Async<Choice<bool, exn>> = v5911 v5893
            let _run_target_args'_v5898 = v5912 
            #endif
#if FABLE_COMPILER_PYTHON
            let v5913 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v5914 : Async<Choice<bool, exn>> = v5913 v5893
            let _run_target_args'_v5898 = v5914 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v5915 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v5916 : Async<Choice<bool, exn>> = v5915 v5893
            let _run_target_args'_v5898 = v5916 
            #endif
#else
            let v5917 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v5918 : Async<Choice<bool, exn>> = v5917 v5893
            let _run_target_args'_v5898 = v5918 
            #endif
            let v5919 : Async<Choice<bool, exn>> = _run_target_args'_v5898 
            let v5925 : Async<US7> = method23(v5919)
            let v5926 : Async<US8> = method26(v5925)
            let v5927 : Async<US6> = method27(v1, v5926)
            return! v5927 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6734 : Async<US6> = _let'_v5057 
    let _run_target_args'_v6 = v6734 
    #endif
    let v6735 : Async<US6> = _run_target_args'_v6 
    v6735
and method21 (v0 : int32, v1 : Async<bool>) : Async<US6> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US6> = method22(v1, v0)
    let _run_target_args'_v6 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : Async<US6> = method22(v1, v0)
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US6> = method22(v1, v0)
    let _run_target_args'_v6 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : Async<US6> = method22(v1, v0)
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : Async<US6> = method22(v1, v0)
    let _run_target_args'_v6 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : Async<US6> = method22(v1, v0)
    let _run_target_args'_v6 = v12 
    #endif
#else
    let v13 : Async<US6> = method22(v1, v0)
    let _run_target_args'_v6 = v13 
    #endif
    let v14 : Async<US6> = _run_target_args'_v6 
    v14
and method20 (v0 : int32, v1 : string, v2 : int32) : Async<bool> =
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
            let v102 : Async<bool> = method6(v1, v2)
            let v103 : Async<US6> = method21(v0, v102)
            let! v103 = v103 
            let v104 : US6 = v103 
            let v107 : bool =
                match v104 with
                | US6_1 -> (* None *)
                    false
                | US6_0(v105) -> (* Some *)
                    v105
            return v107 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v186 : Async<bool> = _let'_v21 
    let _run_target_args'_v7 = v186 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : unit = ()
    let _let'_v188 =
        async {
            let v269 : Async<bool> = method6(v1, v2)
            let v270 : Async<US6> = method21(v0, v269)
            let! v270 = v270 
            let v271 : US6 = v270 
            let v274 : bool =
                match v271 with
                | US6_1 -> (* None *)
                    false
                | US6_0(v272) -> (* Some *)
                    v272
            return v274 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v353 : Async<bool> = _let'_v188 
    let _run_target_args'_v7 = v353 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v355 : unit = ()
    let _let'_v355 =
        async {
            let v436 : Async<bool> = method6(v1, v2)
            let v437 : Async<US6> = method21(v0, v436)
            let! v437 = v437 
            let v438 : US6 = v437 
            let v441 : bool =
                match v438 with
                | US6_1 -> (* None *)
                    false
                | US6_0(v439) -> (* Some *)
                    v439
            return v441 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v520 : Async<bool> = _let'_v355 
    let _run_target_args'_v7 = v520 
    #endif
#else
    let v522 : unit = ()
    let _let'_v522 =
        async {
            let v603 : Async<bool> = method6(v1, v2)
            let v604 : Async<US6> = method21(v0, v603)
            let! v604 = v604 
            let v605 : US6 = v604 
            let v608 : bool =
                match v605 with
                | US6_1 -> (* None *)
                    false
                | US6_0(v606) -> (* Some *)
                    v606
            return v608 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v687 : Async<bool> = _let'_v522 
    let _run_target_args'_v7 = v687 
    #endif
    let v688 : Async<bool> = _run_target_args'_v7 
    v688
and method19 (v0 : int32, v1 : string, v2 : int32) : Async<bool> =
    method20(v0, v1, v2)
and closure13 (v0 : int32, v1 : string) (v2 : int32) : Async<bool> =
    method19(v0, v1, v2)
and closure12 (v0 : int32) (v1 : string) : (int32 -> Async<bool>) =
    closure13(v0, v1)
and closure11 () (v0 : int32) : (string -> (int32 -> Async<bool>)) =
    closure12(v0)
and closure22 () (v0 : int32) : US9 =
    US9_0(v0)
and method34 () : (int32 -> US9) =
    closure22()
and method35 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : int64, v10 : int32 option, v11 : bool) : string =
    let v12 : string = method14()
    let v13 : Mut3 = {l0 = v12} : Mut3
    let v16 : string = "{ "
    let v17 : string = $"{v16}"
    let v25 : unit = ()
    let v26 : (unit -> unit) = closure7(v13, v17)
    let v27 : unit = (fun () -> v26 (); v25) ()
    let v35 : string = "port"
    let v36 : string = $"{v35}"
    let v44 : unit = ()
    let v45 : (unit -> unit) = closure7(v13, v36)
    let v46 : unit = (fun () -> v45 (); v44) ()
    let v54 : string = " = "
    let v55 : string = $"{v54}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure7(v13, v55)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v75 : string = $"{v8}"
    let v83 : unit = ()
    let v84 : (unit -> unit) = closure7(v13, v75)
    let v85 : unit = (fun () -> v84 (); v83) ()
    let v93 : string = "; "
    let v94 : string = $"{v93}"
    let v102 : unit = ()
    let v103 : (unit -> unit) = closure7(v13, v94)
    let v104 : unit = (fun () -> v103 (); v102) ()
    let v112 : string = "retry"
    let v113 : string = $"{v112}"
    let v121 : unit = ()
    let v122 : (unit -> unit) = closure7(v13, v113)
    let v123 : unit = (fun () -> v122 (); v121) ()
    let v130 : string = $"{v54}"
    let v138 : unit = ()
    let v139 : (unit -> unit) = closure7(v13, v130)
    let v140 : unit = (fun () -> v139 (); v138) ()
    let v150 : string = $"{v9}"
    let v158 : unit = ()
    let v159 : (unit -> unit) = closure7(v13, v150)
    let v160 : unit = (fun () -> v159 (); v158) ()
    let v167 : string = $"{v93}"
    let v175 : unit = ()
    let v176 : (unit -> unit) = closure7(v13, v167)
    let v177 : unit = (fun () -> v176 (); v175) ()
    let v185 : string = "timeout"
    let v186 : string = $"{v185}"
    let v194 : unit = ()
    let v195 : (unit -> unit) = closure7(v13, v186)
    let v196 : unit = (fun () -> v195 (); v194) ()
    let v203 : string = $"{v54}"
    let v211 : unit = ()
    let v212 : (unit -> unit) = closure7(v13, v203)
    let v213 : unit = (fun () -> v212 (); v211) ()
    (* run_target_args'
    let v223 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v224 : string = "format!(\"{:#?}\", $0)"
    let v225 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v224 
    let v226 : string = "fable_library_rust::String_::fromString($0)"
    let v227 : string = Fable.Core.RustInterop.emitRustExpr v225 v226 
    let _run_target_args'_v223 = v227 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v228 : string = "format!(\"{:#?}\", $0)"
    let v229 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v228 
    let v230 : string = "fable_library_rust::String_::fromString($0)"
    let v231 : string = Fable.Core.RustInterop.emitRustExpr v229 v230 
    let _run_target_args'_v223 = v231 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v232 : string = "format!(\"{:#?}\", $0)"
    let v233 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v232 
    let v234 : string = "fable_library_rust::String_::fromString($0)"
    let v235 : string = Fable.Core.RustInterop.emitRustExpr v233 v234 
    let _run_target_args'_v223 = v235 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v237 : string = $"%A{v10}"
    let _run_target_args'_v223 = v237 
    #endif
#if FABLE_COMPILER_PYTHON
    let v241 : string = $"%A{v10}"
    let _run_target_args'_v223 = v241 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v245 : string = $"%A{v10}"
    let _run_target_args'_v223 = v245 
    #endif
#else
    let v249 : string = $"%A{v10}"
    let _run_target_args'_v223 = v249 
    #endif
    let v252 : string = _run_target_args'_v223 
    let v259 : string = $"{v252}"
    let v267 : unit = ()
    let v268 : (unit -> unit) = closure7(v13, v259)
    let v269 : unit = (fun () -> v268 (); v267) ()
    let v276 : string = $"{v93}"
    let v284 : unit = ()
    let v285 : (unit -> unit) = closure7(v13, v276)
    let v286 : unit = (fun () -> v285 (); v284) ()
    let v294 : string = "status"
    let v295 : string = $"{v294}"
    let v303 : unit = ()
    let v304 : (unit -> unit) = closure7(v13, v295)
    let v305 : unit = (fun () -> v304 (); v303) ()
    let v312 : string = $"{v54}"
    let v320 : unit = ()
    let v321 : (unit -> unit) = closure7(v13, v312)
    let v322 : unit = (fun () -> v321 (); v320) ()
    let v330 : string =
        if v11 then
            let v328 : string = "true"
            v328
        else
            let v329 : string = "false"
            v329
    let v332 : string = $"{v330}"
    let v340 : unit = ()
    let v341 : (unit -> unit) = closure7(v13, v332)
    let v342 : unit = (fun () -> v341 (); v340) ()
    let v350 : string = " }"
    let v351 : string = $"{v350}"
    let v359 : unit = ()
    let v360 : (unit -> unit) = closure7(v13, v351)
    let v361 : unit = (fun () -> v360 (); v359) ()
    let v367 : string = v13.l0
    let v368 : int64 = v0.l0
    let v371 : string = " "
    let v372 : string = v6 + v371 
    let v376 : string = v372 + v7 
    let v381 : string = " #"
    let v382 : string = v376 + v381 
    let v386 : (int64 -> string) = _.ToString()
    let v387 : string = v386 v368
    let v391 : string = v382 + v387 
    let v395 : string = v391 + v371 
    let v400 : string = "networking.wait_for_port_access"
    let v401 : string = v395 + v400 
    let v406 : string = " / "
    let v407 : string = v401 + v406 
    let v411 : string = v407 + v367 
    method17(v411)
and closure23 (v0 : int32 option, v1 : bool, v2 : int32, v3 : int64) () : unit =
    let v4 : US0 = US0_0
    let v5 : bool = method8(v4)
    if v5 then
        let v20 : unit = ()
        let v21 : (unit -> unit) = closure0()
        let v22 : unit = (fun () -> v21 (); v20) ()
        let struct (v43 : Mut0, v44 : Mut1, v45 : Mut2, v46 : Mut3, v47 : Mut4, v48 : int64 option) = TraceState.trace_state.Value
        let v61 : string = method9(v43, v44, v45, v46, v47, v48)
        let v62 : string = method13()
        let v63 : string = method35(v43, v44, v45, v46, v47, v48, v61, v62, v2, v3, v0, v1)
        method18(v63)
and method33 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32, v4 : int64) : Async<int64> =
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
            let v2420 : (int32 -> US9) = method34()
            let v2421 : US9 option = v0 |> Option.map v2420 
            let v2441 : US9 = US9_1
            let v2442 : US9 = v2421 |> Option.defaultValue v2441 
            let v2450 : Async<bool> =
                match v2442 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v2447) -> (* Some *)
                    method19(v2447, v2, v3)
            let! v2450 = v2450 
            let v2451 : bool = v2450 
            let v2452 : bool = v2451 = v1
            if v2452 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v2453 : int64 = v4 % 100L
                let v2454 : bool = v2453 = 0L
                if v2454 then
                    let v2515 : unit = ()
                    let v2516 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v2517 : unit = (fun () -> v2516 (); v2515) ()
                    ()
                (* run_target_args'
                let v2582 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2583 : (int32 -> Async<unit>) = Async.Sleep
                let v2584 : Async<unit> = v2583 10
                let _run_target_args'_v2582 = v2584 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2585 : (int32 -> Async<unit>) = Async.Sleep
                let v2586 : Async<unit> = v2585 10
                let _run_target_args'_v2582 = v2586 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2587 : (int32 -> Async<unit>) = Async.Sleep
                let v2588 : Async<unit> = v2587 10
                let _run_target_args'_v2582 = v2588 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2589 : (int32 -> Async<unit>) = Async.Sleep
                let v2590 : Async<unit> = v2589 10
                let _run_target_args'_v2582 = v2590 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2591 : (int32 -> Async<unit>) = Async.Sleep
                let v2592 : Async<unit> = v2591 10
                let _run_target_args'_v2582 = v2592 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2593 : (int32 -> Async<unit>) = Async.Sleep
                let v2594 : Async<unit> = v2593 10
                let _run_target_args'_v2582 = v2594 
                #endif
#else
                let v2595 : (int32 -> Async<unit>) = Async.Sleep
                let v2596 : Async<unit> = v2595 10
                let _run_target_args'_v2582 = v2596 
                #endif
                let v2597 : Async<unit> = _run_target_args'_v2582 
                do! v2597 
                let v2600 : int64 = v4 + 1L
                let v2601 : Async<int64> = method32(v0, v1, v2, v3, v2600)
                return! v2601 
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
    let v4994 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v4994 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4996 : unit = ()
    let _let'_v4996 =
        async {
            let v7393 : (int32 -> US9) = method34()
            let v7394 : US9 option = v0 |> Option.map v7393 
            let v7414 : US9 = US9_1
            let v7415 : US9 = v7394 |> Option.defaultValue v7414 
            let v7423 : Async<bool> =
                match v7415 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v7420) -> (* Some *)
                    method19(v7420, v2, v3)
            let! v7423 = v7423 
            let v7424 : bool = v7423 
            let v7425 : bool = v7424 = v1
            if v7425 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v7426 : int64 = v4 % 100L
                let v7427 : bool = v7426 = 0L
                if v7427 then
                    let v7488 : unit = ()
                    let v7489 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v7490 : unit = (fun () -> v7489 (); v7488) ()
                    ()
                (* run_target_args'
                let v7555 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7556 : (int32 -> Async<unit>) = Async.Sleep
                let v7557 : Async<unit> = v7556 10
                let _run_target_args'_v7555 = v7557 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7558 : (int32 -> Async<unit>) = Async.Sleep
                let v7559 : Async<unit> = v7558 10
                let _run_target_args'_v7555 = v7559 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7560 : (int32 -> Async<unit>) = Async.Sleep
                let v7561 : Async<unit> = v7560 10
                let _run_target_args'_v7555 = v7561 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7562 : (int32 -> Async<unit>) = Async.Sleep
                let v7563 : Async<unit> = v7562 10
                let _run_target_args'_v7555 = v7563 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7564 : (int32 -> Async<unit>) = Async.Sleep
                let v7565 : Async<unit> = v7564 10
                let _run_target_args'_v7555 = v7565 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7566 : (int32 -> Async<unit>) = Async.Sleep
                let v7567 : Async<unit> = v7566 10
                let _run_target_args'_v7555 = v7567 
                #endif
#else
                let v7568 : (int32 -> Async<unit>) = Async.Sleep
                let v7569 : Async<unit> = v7568 10
                let _run_target_args'_v7555 = v7569 
                #endif
                let v7570 : Async<unit> = _run_target_args'_v7555 
                do! v7570 
                let v7573 : int64 = v4 + 1L
                let v7574 : Async<int64> = method32(v0, v1, v2, v3, v7573)
                return! v7574 
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
    let v9967 : Async<int64> = _let'_v4996 
    let _run_target_args'_v9 = v9967 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v9969 : unit = ()
    let _let'_v9969 =
        async {
            let v12366 : (int32 -> US9) = method34()
            let v12367 : US9 option = v0 |> Option.map v12366 
            let v12387 : US9 = US9_1
            let v12388 : US9 = v12367 |> Option.defaultValue v12387 
            let v12396 : Async<bool> =
                match v12388 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v12393) -> (* Some *)
                    method19(v12393, v2, v3)
            let! v12396 = v12396 
            let v12397 : bool = v12396 
            let v12398 : bool = v12397 = v1
            if v12398 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v12399 : int64 = v4 % 100L
                let v12400 : bool = v12399 = 0L
                if v12400 then
                    let v12461 : unit = ()
                    let v12462 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v12463 : unit = (fun () -> v12462 (); v12461) ()
                    ()
                (* run_target_args'
                let v12528 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v12529 : (int32 -> Async<unit>) = Async.Sleep
                let v12530 : Async<unit> = v12529 10
                let _run_target_args'_v12528 = v12530 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v12531 : (int32 -> Async<unit>) = Async.Sleep
                let v12532 : Async<unit> = v12531 10
                let _run_target_args'_v12528 = v12532 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v12533 : (int32 -> Async<unit>) = Async.Sleep
                let v12534 : Async<unit> = v12533 10
                let _run_target_args'_v12528 = v12534 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v12535 : (int32 -> Async<unit>) = Async.Sleep
                let v12536 : Async<unit> = v12535 10
                let _run_target_args'_v12528 = v12536 
                #endif
#if FABLE_COMPILER_PYTHON
                let v12537 : (int32 -> Async<unit>) = Async.Sleep
                let v12538 : Async<unit> = v12537 10
                let _run_target_args'_v12528 = v12538 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v12539 : (int32 -> Async<unit>) = Async.Sleep
                let v12540 : Async<unit> = v12539 10
                let _run_target_args'_v12528 = v12540 
                #endif
#else
                let v12541 : (int32 -> Async<unit>) = Async.Sleep
                let v12542 : Async<unit> = v12541 10
                let _run_target_args'_v12528 = v12542 
                #endif
                let v12543 : Async<unit> = _run_target_args'_v12528 
                do! v12543 
                let v12546 : int64 = v4 + 1L
                let v12547 : Async<int64> = method32(v0, v1, v2, v3, v12546)
                return! v12547 
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
    let v14940 : Async<int64> = _let'_v9969 
    let _run_target_args'_v9 = v14940 
    #endif
#else
    let v14942 : unit = ()
    let _let'_v14942 =
        async {
            let v17339 : (int32 -> US9) = method34()
            let v17340 : US9 option = v0 |> Option.map v17339 
            let v17360 : US9 = US9_1
            let v17361 : US9 = v17340 |> Option.defaultValue v17360 
            let v17369 : Async<bool> =
                match v17361 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v17366) -> (* Some *)
                    method19(v17366, v2, v3)
            let! v17369 = v17369 
            let v17370 : bool = v17369 
            let v17371 : bool = v17370 = v1
            if v17371 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v17372 : int64 = v4 % 100L
                let v17373 : bool = v17372 = 0L
                if v17373 then
                    let v17434 : unit = ()
                    let v17435 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v17436 : unit = (fun () -> v17435 (); v17434) ()
                    ()
                (* run_target_args'
                let v17501 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v17502 : (int32 -> Async<unit>) = Async.Sleep
                let v17503 : Async<unit> = v17502 10
                let _run_target_args'_v17501 = v17503 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v17504 : (int32 -> Async<unit>) = Async.Sleep
                let v17505 : Async<unit> = v17504 10
                let _run_target_args'_v17501 = v17505 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v17506 : (int32 -> Async<unit>) = Async.Sleep
                let v17507 : Async<unit> = v17506 10
                let _run_target_args'_v17501 = v17507 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v17508 : (int32 -> Async<unit>) = Async.Sleep
                let v17509 : Async<unit> = v17508 10
                let _run_target_args'_v17501 = v17509 
                #endif
#if FABLE_COMPILER_PYTHON
                let v17510 : (int32 -> Async<unit>) = Async.Sleep
                let v17511 : Async<unit> = v17510 10
                let _run_target_args'_v17501 = v17511 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v17512 : (int32 -> Async<unit>) = Async.Sleep
                let v17513 : Async<unit> = v17512 10
                let _run_target_args'_v17501 = v17513 
                #endif
#else
                let v17514 : (int32 -> Async<unit>) = Async.Sleep
                let v17515 : Async<unit> = v17514 10
                let _run_target_args'_v17501 = v17515 
                #endif
                let v17516 : Async<unit> = _run_target_args'_v17501 
                do! v17516 
                let v17519 : int64 = v4 + 1L
                let v17520 : Async<int64> = method32(v0, v1, v2, v3, v17519)
                return! v17520 
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
    let v19913 : Async<int64> = _let'_v14942 
    let _run_target_args'_v9 = v19913 
    #endif
    let v19914 : Async<int64> = _run_target_args'_v9 
    v19914
and method32 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32, v4 : int64) : Async<int64> =
    method33(v0, v1, v2, v3, v4)
and method31 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32) : Async<int64> =
    let v4 : int64 = 1L
    method32(v0, v1, v2, v3, v4)
and closure21 (v0 : int32 option, v1 : bool, v2 : string) (v3 : int32) : Async<int64> =
    method31(v0, v1, v2, v3)
and closure20 (v0 : int32 option, v1 : bool) (v2 : string) : (int32 -> Async<int64>) =
    closure21(v0, v1, v2)
and closure19 (v0 : int32 option) (v1 : bool) : (string -> (int32 -> Async<int64>)) =
    closure20(v0, v1)
and closure18 () (v0 : int32 option) : (bool -> (string -> (int32 -> Async<int64>))) =
    closure19(v0)
and method38 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
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
            let v507 : (int32 -> US9) = method34()
            let v508 : US9 option = v0 |> Option.map v507 
            let v528 : US9 = US9_1
            let v529 : US9 = v508 |> Option.defaultValue v528 
            let v537 : Async<bool> =
                match v529 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v534) -> (* Some *)
                    method19(v534, v1, v2)
            let! v537 = v537 
            let v538 : bool = v537 
            let v539 : bool = v538 = false
            if v539 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v540 : int32 = v2 + 1
                let v541 : Async<int32> = method37(v0, v1, v540)
                return! v541 
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
    let v1023 : Async<int32> = _let'_v21 
    let _run_target_args'_v7 = v1023 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1025 : unit = ()
    let _let'_v1025 =
        async {
            let v1511 : (int32 -> US9) = method34()
            let v1512 : US9 option = v0 |> Option.map v1511 
            let v1532 : US9 = US9_1
            let v1533 : US9 = v1512 |> Option.defaultValue v1532 
            let v1541 : Async<bool> =
                match v1533 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v1538) -> (* Some *)
                    method19(v1538, v1, v2)
            let! v1541 = v1541 
            let v1542 : bool = v1541 
            let v1543 : bool = v1542 = false
            if v1543 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v1544 : int32 = v2 + 1
                let v1545 : Async<int32> = method37(v0, v1, v1544)
                return! v1545 
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
    let v2027 : Async<int32> = _let'_v1025 
    let _run_target_args'_v7 = v2027 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2029 : unit = ()
    let _let'_v2029 =
        async {
            let v2515 : (int32 -> US9) = method34()
            let v2516 : US9 option = v0 |> Option.map v2515 
            let v2536 : US9 = US9_1
            let v2537 : US9 = v2516 |> Option.defaultValue v2536 
            let v2545 : Async<bool> =
                match v2537 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v2542) -> (* Some *)
                    method19(v2542, v1, v2)
            let! v2545 = v2545 
            let v2546 : bool = v2545 
            let v2547 : bool = v2546 = false
            if v2547 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v2548 : int32 = v2 + 1
                let v2549 : Async<int32> = method37(v0, v1, v2548)
                return! v2549 
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
    let v3031 : Async<int32> = _let'_v2029 
    let _run_target_args'_v7 = v3031 
    #endif
#else
    let v3033 : unit = ()
    let _let'_v3033 =
        async {
            let v3519 : (int32 -> US9) = method34()
            let v3520 : US9 option = v0 |> Option.map v3519 
            let v3540 : US9 = US9_1
            let v3541 : US9 = v3520 |> Option.defaultValue v3540 
            let v3549 : Async<bool> =
                match v3541 with
                | US9_1 -> (* None *)
                    method6(v1, v2)
                | US9_0(v3546) -> (* Some *)
                    method19(v3546, v1, v2)
            let! v3549 = v3549 
            let v3550 : bool = v3549 
            let v3551 : bool = v3550 = false
            if v3551 then
                return v2 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v3552 : int32 = v2 + 1
                let v3553 : Async<int32> = method37(v0, v1, v3552)
                return! v3553 
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
    let v4035 : Async<int32> = _let'_v3033 
    let _run_target_args'_v7 = v4035 
    #endif
    let v4036 : Async<int32> = _run_target_args'_v7 
    v4036
and method37 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
    method38(v0, v1, v2)
and method36 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
    method37(v0, v1, v2)
and closure26 (v0 : int32 option, v1 : string) (v2 : int32) : Async<int32> =
    method36(v0, v1, v2)
and closure25 (v0 : int32 option) (v1 : string) : (int32 -> Async<int32>) =
    closure26(v0, v1)
and closure24 () (v0 : int32 option) : (string -> (int32 -> Async<int32>)) =
    closure25(v0)
let v14 : unit = ()
let v15 : (unit -> unit) = closure0()
let v16 : unit = (fun () -> v15 (); v14) ()
let v31 : (string -> (int32 -> Async<bool>)) = closure3()
let test_port_open x = v31 x
let v32 : (int32 -> (string -> (int32 -> Async<bool>))) = closure11()
let test_port_open_timeout x = v32 x
let v33 : (int32 option -> (bool -> (string -> (int32 -> Async<int64>)))) = closure18()
let wait_for_port_access x = v33 x
let v34 : (int32 option -> (string -> (int32 -> Async<int32>))) = closure24()
let get_available_port x = v34 x
()
