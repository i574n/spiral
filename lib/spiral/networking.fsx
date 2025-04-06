#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::string::String")>]
type std_string_String = class end
#else
type std_string_String = string
#endif

type IOsEnviron = abstract environ: x: unit -> obj
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("&$0")>]
type Ref<'T> = class end
#else
type Ref<'T> = 'T
#endif

module TraceState = let mutable trace_state = None
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
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::env::VarError")>]
#endif
type std_env_VarError = class end
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
    | US4_6 of f6_0 : US3
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
    let v20 : US4 = US4_4(v19)
    let v21 : string = $"env.get_environment_variable / target: {v20} / var: {v0}"
    let v22 : string = failwith<string> v21
    let _run_target_args'_v2 = v22 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v23 : US3 = US3_2
    let v24 : US4 = US4_4(v23)
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
    let v210 : US2 =
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
            let v204 : int64 = v182 |> int64 
            US2_0(v204)
    struct (v127, v210)
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
    let v174 : US2 =
        if v162 then
            US2_1
        else
            let v166 : string = $"near_sdk::env::block_timestamp()"
            let v167 : uint64 = Fable.Core.RustInterop.emitRustExpr () v166 
            let v169 : (uint64 -> int64) = int64
            let v170 : int64 = v169 v167
            US2_0(v170)
    let v175 : US1 = US1_1
    let _run_target_args'_v3 = struct (v175, v174) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v176 : US1, v177 : US2) = method1()
    let _run_target_args'_v3 = struct (v176, v177) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v178 : US1, v179 : US2) = method1()
    let _run_target_args'_v3 = struct (v178, v179) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v180 : US1, v181 : US2) = method1()
    let _run_target_args'_v3 = struct (v180, v181) 
    #endif
#else
    let struct (v182 : US1, v183 : US2) = method1()
    let _run_target_args'_v3 = struct (v182, v183) 
    #endif
    let struct (v184 : US1, v185 : US2) = _run_target_args'_v3 
    let v190 : Mut0 = {l0 = 1L} : Mut0
    let v191 : (string -> unit) = closure2()
    let v192 : Mut1 = {l0 = v191} : Mut1
    let v193 : Mut2 = {l0 = true} : Mut2
    let v194 : string = ""
    let v195 : Mut3 = {l0 = v194} : Mut3
    let v198 : US0 =
        match v184 with
        | US1_1 -> (* None *)
            v0
        | US1_0(v196) -> (* Some *)
            v196
    let v199 : Mut4 = {l0 = v198} : Mut4
    let v210 : int64 option =
        match v185 with
        | US2_1 -> (* None *)
            let v206 : int64 option = None
            v206
        | US2_0(v200) -> (* Some *)
            let v202 : int64 option = Some v200 
            v202
    struct (v190, v192, v193, v195, v199, v210)
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
    let v195 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v198 : (int64 -> US2) = method10()
    let v199 : US2 option = v5 |> Option.map v198 
    let v219 : US2 = US2_1
    let v220 : US2 = v199 |> Option.defaultValue v219 
    let v360 : System.DateTime =
        match v220 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v343 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v344 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v344 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v345 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v345 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v347 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v343 = v347 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v350 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v350 
            #endif
#if FABLE_COMPILER_PYTHON
            let v351 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v351 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v352 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v352 
            #endif
#else
            let v353 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v343 = v353 
            #endif
            let v354 : System.DateTime = _run_target_args'_v343 
            v354
        | US2_0(v224) -> (* Some *)
            (* run_target_args'
            let v231 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v232 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v232 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v233 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v233 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v235 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v231 = v235 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v238 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v238 
            #endif
#if FABLE_COMPILER_PYTHON
            let v239 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v239 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v240 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v240 
            #endif
#else
            let v241 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v231 = v241 
            #endif
            let v242 : System.DateTime = _run_target_args'_v231 
            (* run_target_args'
            let v253 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v254 : (System.DateTime -> int64) = _.Ticks
            let v255 : int64 = v254 v242
            let _run_target_args'_v253 = v255 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v256 : (System.DateTime -> int64) = _.Ticks
            let v257 : int64 = v256 v242
            let _run_target_args'_v253 = v257 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v259 : int64 = null |> unbox<int64>
            let _run_target_args'_v253 = v259 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v262 : (System.DateTime -> int64) = _.Ticks
            let v263 : int64 = v262 v242
            let _run_target_args'_v253 = v263 
            #endif
#if FABLE_COMPILER_PYTHON
            let v264 : (System.DateTime -> int64) = _.Ticks
            let v265 : int64 = v264 v242
            let _run_target_args'_v253 = v265 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v266 : (System.DateTime -> int64) = _.Ticks
            let v267 : int64 = v266 v242
            let _run_target_args'_v253 = v267 
            #endif
#else
            let v268 : (System.DateTime -> int64) = _.Ticks
            let v269 : int64 = v268 v242
            let _run_target_args'_v253 = v269 
            #endif
            let v270 : int64 = _run_target_args'_v253 
            let v292 : int64 = v270 |> int64 
            let v297 : int64 = v292 - v224
            let v303 : System.TimeSpan = v297 |> System.TimeSpan 
            let v309 : (System.TimeSpan -> int32) = _.Hours
            let v310 : int32 = v309 v303
            let v314 : (System.TimeSpan -> int32) = _.Minutes
            let v315 : int32 = v314 v303
            let v319 : (System.TimeSpan -> int32) = _.Seconds
            let v320 : int32 = v319 v303
            let v324 : (System.TimeSpan -> int32) = _.Milliseconds
            let v325 : int32 = v324 v303
            let v334 : System.DateTime = System.DateTime (1, 1, 1, v310, v315, v320, v325)
            v334
    let v361 : string = method11()
    let v363 : bool = v361 = ""
    let v365 : string =
        if v363 then
            let v364 : string = "M-d-y hh:mm:ss tt"
            v364
        else
            v361
    let v366 : (string -> string) = v360.ToString
    let v367 : string = v366 v365
    let _run_target_args'_v195 = v367 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v384 : (int64 -> US2) = method10()
    let v385 : US2 option = v5 |> Option.map v384 
    let v405 : US2 = US2_1
    let v406 : US2 = v385 |> Option.defaultValue v405 
    let v546 : System.DateTime =
        match v406 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v529 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v530 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v530 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v531 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v531 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v533 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v529 = v533 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v536 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v536 
            #endif
#if FABLE_COMPILER_PYTHON
            let v537 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v537 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v538 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v538 
            #endif
#else
            let v539 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v529 = v539 
            #endif
            let v540 : System.DateTime = _run_target_args'_v529 
            v540
        | US2_0(v410) -> (* Some *)
            (* run_target_args'
            let v417 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v418 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v418 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v419 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v419 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v421 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v417 = v421 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v424 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v424 
            #endif
#if FABLE_COMPILER_PYTHON
            let v425 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v425 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v426 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v426 
            #endif
#else
            let v427 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v417 = v427 
            #endif
            let v428 : System.DateTime = _run_target_args'_v417 
            (* run_target_args'
            let v439 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v440 : (System.DateTime -> int64) = _.Ticks
            let v441 : int64 = v440 v428
            let _run_target_args'_v439 = v441 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v442 : (System.DateTime -> int64) = _.Ticks
            let v443 : int64 = v442 v428
            let _run_target_args'_v439 = v443 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v445 : int64 = null |> unbox<int64>
            let _run_target_args'_v439 = v445 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v448 : (System.DateTime -> int64) = _.Ticks
            let v449 : int64 = v448 v428
            let _run_target_args'_v439 = v449 
            #endif
#if FABLE_COMPILER_PYTHON
            let v450 : (System.DateTime -> int64) = _.Ticks
            let v451 : int64 = v450 v428
            let _run_target_args'_v439 = v451 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v452 : (System.DateTime -> int64) = _.Ticks
            let v453 : int64 = v452 v428
            let _run_target_args'_v439 = v453 
            #endif
#else
            let v454 : (System.DateTime -> int64) = _.Ticks
            let v455 : int64 = v454 v428
            let _run_target_args'_v439 = v455 
            #endif
            let v456 : int64 = _run_target_args'_v439 
            let v478 : int64 = v456 |> int64 
            let v483 : int64 = v478 - v410
            let v489 : System.TimeSpan = v483 |> System.TimeSpan 
            let v495 : (System.TimeSpan -> int32) = _.Hours
            let v496 : int32 = v495 v489
            let v500 : (System.TimeSpan -> int32) = _.Minutes
            let v501 : int32 = v500 v489
            let v505 : (System.TimeSpan -> int32) = _.Seconds
            let v506 : int32 = v505 v489
            let v510 : (System.TimeSpan -> int32) = _.Milliseconds
            let v511 : int32 = v510 v489
            let v520 : System.DateTime = System.DateTime (1, 1, 1, v496, v501, v506, v511)
            v520
    let v547 : string = method11()
    let v549 : bool = v547 = ""
    let v551 : string =
        if v549 then
            let v550 : string = "M-d-y hh:mm:ss tt"
            v550
        else
            v547
    let v552 : (string -> string) = v546.ToString
    let v553 : string = v552 v551
    let _run_target_args'_v195 = v553 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v568 : string = $"near_sdk::env::block_timestamp()"
    let v569 : uint64 = Fable.Core.RustInterop.emitRustExpr () v568 
    let v572 : (int64 -> US2) = method10()
    let v573 : US2 option = v5 |> Option.map v572 
    let v593 : US2 = US2_1
    let v594 : US2 = v573 |> Option.defaultValue v593 
    let v606 : uint64 =
        match v594 with
        | US2_1 -> (* None *)
            v569
        | US2_0(v598) -> (* Some *)
            let v600 : (int64 -> uint64) = uint64
            let v601 : uint64 = v600 v598
            let v604 : uint64 = v569 - v601
            v604
    let v607 : uint64 = v606 / 1000000000UL
    let v608 : uint64 = v607 % 60UL
    let v609 : uint64 = v607 / 60UL
    let v610 : uint64 = v609 % 60UL
    let v611 : uint64 = v607 / 3600UL
    let v612 : uint64 = v611 % 24UL
    let v613 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v614 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v612, v610, v608) v613 
    let v615 : string = "fable_library_rust::String_::fromString($0)"
    let v616 : string = Fable.Core.RustInterop.emitRustExpr v614 v615 
    let _run_target_args'_v195 = v616 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v619 : (int64 -> US2) = method10()
    let v620 : US2 option = v5 |> Option.map v619 
    let v640 : US2 = US2_1
    let v641 : US2 = v620 |> Option.defaultValue v640 
    let v781 : System.DateTime =
        match v641 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v764 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v765 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v765 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v766 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v766 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v768 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v764 = v768 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v771 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v771 
            #endif
#if FABLE_COMPILER_PYTHON
            let v772 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v772 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v773 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v773 
            #endif
#else
            let v774 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v764 = v774 
            #endif
            let v775 : System.DateTime = _run_target_args'_v764 
            v775
        | US2_0(v645) -> (* Some *)
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
            (* run_target_args'
            let v674 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v675 : (System.DateTime -> int64) = _.Ticks
            let v676 : int64 = v675 v663
            let _run_target_args'_v674 = v676 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v677 : (System.DateTime -> int64) = _.Ticks
            let v678 : int64 = v677 v663
            let _run_target_args'_v674 = v678 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v680 : int64 = null |> unbox<int64>
            let _run_target_args'_v674 = v680 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v683 : (System.DateTime -> int64) = _.Ticks
            let v684 : int64 = v683 v663
            let _run_target_args'_v674 = v684 
            #endif
#if FABLE_COMPILER_PYTHON
            let v685 : (System.DateTime -> int64) = _.Ticks
            let v686 : int64 = v685 v663
            let _run_target_args'_v674 = v686 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v687 : (System.DateTime -> int64) = _.Ticks
            let v688 : int64 = v687 v663
            let _run_target_args'_v674 = v688 
            #endif
#else
            let v689 : (System.DateTime -> int64) = _.Ticks
            let v690 : int64 = v689 v663
            let _run_target_args'_v674 = v690 
            #endif
            let v691 : int64 = _run_target_args'_v674 
            let v713 : int64 = v691 |> int64 
            let v718 : int64 = v713 - v645
            let v724 : System.TimeSpan = v718 |> System.TimeSpan 
            let v730 : (System.TimeSpan -> int32) = _.Hours
            let v731 : int32 = v730 v724
            let v735 : (System.TimeSpan -> int32) = _.Minutes
            let v736 : int32 = v735 v724
            let v740 : (System.TimeSpan -> int32) = _.Seconds
            let v741 : int32 = v740 v724
            let v745 : (System.TimeSpan -> int32) = _.Milliseconds
            let v746 : int32 = v745 v724
            let v755 : System.DateTime = System.DateTime (1, 1, 1, v731, v736, v741, v746)
            v755
    let v782 : string = method12()
    let v784 : bool = v782 = ""
    let v786 : string =
        if v784 then
            let v785 : string = "M-d-y hh:mm:ss tt"
            v785
        else
            v782
    let v787 : (string -> string) = v781.ToString
    let v788 : string = v787 v786
    let _run_target_args'_v195 = v788 
    #endif
#if FABLE_COMPILER_PYTHON
    let v805 : (int64 -> US2) = method10()
    let v806 : US2 option = v5 |> Option.map v805 
    let v826 : US2 = US2_1
    let v827 : US2 = v806 |> Option.defaultValue v826 
    let v967 : System.DateTime =
        match v827 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v950 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v951 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v951 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v952 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v952 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v954 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v950 = v954 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v957 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v957 
            #endif
#if FABLE_COMPILER_PYTHON
            let v958 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v958 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v959 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v959 
            #endif
#else
            let v960 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v950 = v960 
            #endif
            let v961 : System.DateTime = _run_target_args'_v950 
            v961
        | US2_0(v831) -> (* Some *)
            (* run_target_args'
            let v838 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v839 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v839 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v840 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v840 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v842 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v838 = v842 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v845 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v845 
            #endif
#if FABLE_COMPILER_PYTHON
            let v846 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v846 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v847 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v847 
            #endif
#else
            let v848 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v838 = v848 
            #endif
            let v849 : System.DateTime = _run_target_args'_v838 
            (* run_target_args'
            let v860 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v861 : (System.DateTime -> int64) = _.Ticks
            let v862 : int64 = v861 v849
            let _run_target_args'_v860 = v862 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v863 : (System.DateTime -> int64) = _.Ticks
            let v864 : int64 = v863 v849
            let _run_target_args'_v860 = v864 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v866 : int64 = null |> unbox<int64>
            let _run_target_args'_v860 = v866 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v869 : (System.DateTime -> int64) = _.Ticks
            let v870 : int64 = v869 v849
            let _run_target_args'_v860 = v870 
            #endif
#if FABLE_COMPILER_PYTHON
            let v871 : (System.DateTime -> int64) = _.Ticks
            let v872 : int64 = v871 v849
            let _run_target_args'_v860 = v872 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v873 : (System.DateTime -> int64) = _.Ticks
            let v874 : int64 = v873 v849
            let _run_target_args'_v860 = v874 
            #endif
#else
            let v875 : (System.DateTime -> int64) = _.Ticks
            let v876 : int64 = v875 v849
            let _run_target_args'_v860 = v876 
            #endif
            let v877 : int64 = _run_target_args'_v860 
            let v899 : int64 = v877 |> int64 
            let v904 : int64 = v899 - v831
            let v910 : System.TimeSpan = v904 |> System.TimeSpan 
            let v916 : (System.TimeSpan -> int32) = _.Hours
            let v917 : int32 = v916 v910
            let v921 : (System.TimeSpan -> int32) = _.Minutes
            let v922 : int32 = v921 v910
            let v926 : (System.TimeSpan -> int32) = _.Seconds
            let v927 : int32 = v926 v910
            let v931 : (System.TimeSpan -> int32) = _.Milliseconds
            let v932 : int32 = v931 v910
            let v941 : System.DateTime = System.DateTime (1, 1, 1, v917, v922, v927, v932)
            v941
    let v968 : string = method12()
    let v970 : bool = v968 = ""
    let v972 : string =
        if v970 then
            let v971 : string = "M-d-y hh:mm:ss tt"
            v971
        else
            v968
    let v973 : (string -> string) = v967.ToString
    let v974 : string = v973 v972
    let _run_target_args'_v195 = v974 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v991 : (int64 -> US2) = method10()
    let v992 : US2 option = v5 |> Option.map v991 
    let v1012 : US2 = US2_1
    let v1013 : US2 = v992 |> Option.defaultValue v1012 
    let v1153 : System.DateTime =
        match v1013 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1136 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1137 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1137 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1138 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1138 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1140 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1136 = v1140 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1143 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1143 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1144 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1144 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1145 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1145 
            #endif
#else
            let v1146 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1136 = v1146 
            #endif
            let v1147 : System.DateTime = _run_target_args'_v1136 
            v1147
        | US2_0(v1017) -> (* Some *)
            (* run_target_args'
            let v1024 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1025 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1025 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1026 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1026 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1028 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1024 = v1028 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1031 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1031 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1032 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1032 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1033 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1033 
            #endif
#else
            let v1034 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1024 = v1034 
            #endif
            let v1035 : System.DateTime = _run_target_args'_v1024 
            (* run_target_args'
            let v1046 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1047 : (System.DateTime -> int64) = _.Ticks
            let v1048 : int64 = v1047 v1035
            let _run_target_args'_v1046 = v1048 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1049 : (System.DateTime -> int64) = _.Ticks
            let v1050 : int64 = v1049 v1035
            let _run_target_args'_v1046 = v1050 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1052 : int64 = null |> unbox<int64>
            let _run_target_args'_v1046 = v1052 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1055 : (System.DateTime -> int64) = _.Ticks
            let v1056 : int64 = v1055 v1035
            let _run_target_args'_v1046 = v1056 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1057 : (System.DateTime -> int64) = _.Ticks
            let v1058 : int64 = v1057 v1035
            let _run_target_args'_v1046 = v1058 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1059 : (System.DateTime -> int64) = _.Ticks
            let v1060 : int64 = v1059 v1035
            let _run_target_args'_v1046 = v1060 
            #endif
#else
            let v1061 : (System.DateTime -> int64) = _.Ticks
            let v1062 : int64 = v1061 v1035
            let _run_target_args'_v1046 = v1062 
            #endif
            let v1063 : int64 = _run_target_args'_v1046 
            let v1085 : int64 = v1063 |> int64 
            let v1090 : int64 = v1085 - v1017
            let v1096 : System.TimeSpan = v1090 |> System.TimeSpan 
            let v1102 : (System.TimeSpan -> int32) = _.Hours
            let v1103 : int32 = v1102 v1096
            let v1107 : (System.TimeSpan -> int32) = _.Minutes
            let v1108 : int32 = v1107 v1096
            let v1112 : (System.TimeSpan -> int32) = _.Seconds
            let v1113 : int32 = v1112 v1096
            let v1117 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1118 : int32 = v1117 v1096
            let v1127 : System.DateTime = System.DateTime (1, 1, 1, v1103, v1108, v1113, v1118)
            v1127
    let v1154 : string = method12()
    let v1156 : bool = v1154 = ""
    let v1158 : string =
        if v1156 then
            let v1157 : string = "M-d-y hh:mm:ss tt"
            v1157
        else
            v1154
    let v1159 : (string -> string) = v1153.ToString
    let v1160 : string = v1159 v1158
    let _run_target_args'_v195 = v1160 
    #endif
#else
    let v1177 : (int64 -> US2) = method10()
    let v1178 : US2 option = v5 |> Option.map v1177 
    let v1198 : US2 = US2_1
    let v1199 : US2 = v1178 |> Option.defaultValue v1198 
    let v1339 : System.DateTime =
        match v1199 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1322 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1323 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1323 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1324 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1324 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1326 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1322 = v1326 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1329 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1329 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1330 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1330 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1331 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1331 
            #endif
#else
            let v1332 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1322 = v1332 
            #endif
            let v1333 : System.DateTime = _run_target_args'_v1322 
            v1333
        | US2_0(v1203) -> (* Some *)
            (* run_target_args'
            let v1210 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1211 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1211 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1212 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1212 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1214 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1210 = v1214 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1217 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1217 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1218 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1218 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1219 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1219 
            #endif
#else
            let v1220 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1210 = v1220 
            #endif
            let v1221 : System.DateTime = _run_target_args'_v1210 
            (* run_target_args'
            let v1232 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1233 : (System.DateTime -> int64) = _.Ticks
            let v1234 : int64 = v1233 v1221
            let _run_target_args'_v1232 = v1234 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1235 : (System.DateTime -> int64) = _.Ticks
            let v1236 : int64 = v1235 v1221
            let _run_target_args'_v1232 = v1236 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1238 : int64 = null |> unbox<int64>
            let _run_target_args'_v1232 = v1238 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1241 : (System.DateTime -> int64) = _.Ticks
            let v1242 : int64 = v1241 v1221
            let _run_target_args'_v1232 = v1242 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1243 : (System.DateTime -> int64) = _.Ticks
            let v1244 : int64 = v1243 v1221
            let _run_target_args'_v1232 = v1244 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1245 : (System.DateTime -> int64) = _.Ticks
            let v1246 : int64 = v1245 v1221
            let _run_target_args'_v1232 = v1246 
            #endif
#else
            let v1247 : (System.DateTime -> int64) = _.Ticks
            let v1248 : int64 = v1247 v1221
            let _run_target_args'_v1232 = v1248 
            #endif
            let v1249 : int64 = _run_target_args'_v1232 
            let v1271 : int64 = v1249 |> int64 
            let v1276 : int64 = v1271 - v1203
            let v1282 : System.TimeSpan = v1276 |> System.TimeSpan 
            let v1288 : (System.TimeSpan -> int32) = _.Hours
            let v1289 : int32 = v1288 v1282
            let v1293 : (System.TimeSpan -> int32) = _.Minutes
            let v1294 : int32 = v1293 v1282
            let v1298 : (System.TimeSpan -> int32) = _.Seconds
            let v1299 : int32 = v1298 v1282
            let v1303 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1304 : int32 = v1303 v1282
            let v1313 : System.DateTime = System.DateTime (1, 1, 1, v1289, v1294, v1299, v1304)
            v1313
    let v1340 : string = method12()
    let v1342 : bool = v1340 = ""
    let v1344 : string =
        if v1342 then
            let v1343 : string = "M-d-y hh:mm:ss tt"
            v1343
        else
            v1340
    let v1345 : (string -> string) = v1339.ToString
    let v1346 : string = v1345 v1344
    let _run_target_args'_v195 = v1346 
    #endif
    let v1361 : string = _run_target_args'_v195 
    v1361
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
    let v86 : string = "inline_colorization::color_reset"
    let v87 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v87) v88 
    let v90 : string = "fable_library_rust::String_::fromString($0)"
    let v91 : string = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let _run_target_args'_v47 = v91 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v92 : string = "inline_colorization::color_bright_black"
    let v93 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v92 
    (* run_target_args'
    let v98 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v99 : string = "&*$0"
    let v100 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v99 
    let _run_target_args'_v98 = v100 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v101 : string = "&*$0"
    let v102 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v101 
    let _run_target_args'_v98 = v102 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v103 
    let _run_target_args'_v98 = v104 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v106 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v106 
    #endif
#if FABLE_COMPILER_PYTHON
    let v110 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v110 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v114 
    #endif
#else
    let v118 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v118 
    #endif
    let v121 : Ref<Str> = _run_target_args'_v98 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v93, v121, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v47 = v135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v136 : string = "inline_colorization::color_bright_black"
    let v137 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v136 
    (* run_target_args'
    let v142 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v143 : string = "&*$0"
    let v144 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v143 
    let _run_target_args'_v142 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "&*$0"
    let v146 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v145 
    let _run_target_args'_v142 = v146 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v147 : string = "&*$0"
    let v148 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v147 
    let _run_target_args'_v142 = v148 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v150 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v150 
    #endif
#if FABLE_COMPILER_PYTHON
    let v154 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v154 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v158 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v158 
    #endif
#else
    let v162 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v162 
    #endif
    let v165 : Ref<Str> = _run_target_args'_v142 
    let v174 : string = "inline_colorization::color_reset"
    let v175 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v174 
    let v176 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v177 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v137, v165, v175) v176 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v177 v178 
    let _run_target_args'_v47 = v179 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v181 : string = "\u001b[90m"
    let v185 : string = method15()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[90m"
    let v201 : string = method15()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[90m"
    let v217 : string = method15()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[90m"
    let v233 : string = method15()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method17 (v0 : string) : string =
    let v1 : char list = []
    let v4 : (char list -> (char [])) = List.toArray
    let v5 : (char []) = v4 v1
    let v8 : string = v0.TrimStart v5 
    let v42 : char list = []
    let v44 : char list = '/' :: v42 
    let v48 : char list = ' ' :: v44 
    let v53 : (char list -> (char [])) = List.toArray
    let v54 : (char []) = v53 v48
    let v57 : string = v8.TrimEnd v54 
    v57
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
    let v120 : string = $"$0.chars()"
    let v121 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let v122 : string = "$0"
    let v123 : _ = Fable.Core.RustInterop.emitRustExpr v121 v122 
    let v124 : string = "$0.collect::<Vec<_>>()"
    let v125 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v123 v124 
    let v126 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v127 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v125 v126 
    let v128 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v129 : bool = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let v130 : string = "x"
    let v131 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = "String::from_iter($0)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr v131 v132 
    let v134 : string = "true; $0 }).collect::<Vec<_>>()"
    let v135 : bool = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let v136 : string = "_vec_map"
    let v137 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v136 
    let v138 : string = "$0.len()"
    let v139 : unativeint = Fable.Core.RustInterop.emitRustExpr v137 v138 
    let v145 : int32 = v139 |> int32 
    let v155 : string = ""
    let v156 : bool = v0 <> v155 
    let v160 : bool =
        if v156 then
            let v159 : bool = v145 <= 1
            v159
        else
            false
    if v160 then
        v41.l0 <- v83
        ()
    else
        v41.l0 <- v155
        let v161 : string = "true; $0.into_iter().for_each(|x| { //"
        let v162 : bool = Fable.Core.RustInterop.emitRustExpr v137 v161 
        let v163 : string = "x"
        let v164 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v163 
        let v165 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v166 : bool = Fable.Core.RustInterop.emitRustExpr v164 v165 
        let v167 : string = $"true"
        let v168 : bool = Fable.Core.RustInterop.emitRustExpr () v167 
        let v169 : string = "true; }); //"
        let v170 : bool = Fable.Core.RustInterop.emitRustExpr () v169 
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
    let v171 : (string -> unit) = v39.l0
    v171 v0
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
        let v100 : string = method16(v41, v42, v43, v44, v45, v46, v59, v60, v0, v91)
        method18(v100)
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
            let v12906 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v12906 = v12906 
            let v12907 : System.Threading.CancellationToken = v12906 
            (* run_target_args'
            let v12912 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v12914 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12912 = v12914 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v12918 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12912 = v12918 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v12922 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12912 = v12922 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v12926 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12912 = v12926 
            #endif
#if FABLE_COMPILER_PYTHON
            let v12930 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12912 = v12930 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v12934 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v12912 = v12934 
            #endif
#else
            let v12937 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v12912 = v12937 
            #endif
            let v12938 : System_Net_Sockets_TcpClient = _run_target_args'_v12912 
            use v12938 = v12938 
            let v12947 : System_Net_Sockets_TcpClient = v12938 
            try
                (* run_target_args'
                let v13065 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v13067 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v13065 = v13067 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v13071 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v13065 = v13071 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v13075 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v13065 = v13075 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v13079 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v13065 = v13079 
                #endif
#if FABLE_COMPILER_PYTHON
                let v13083 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v13065 = v13083 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v13087 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v13065 = v13087 
                #endif
#else
                let v13090 : System.Threading.Tasks.ValueTask = v12947.ConnectAsync (v0, v1, v12907)
                let _run_target_args'_v13065 = v13090 
                #endif
                let v13091 : System.Threading.Tasks.ValueTask = _run_target_args'_v13065 
                (* run_target_args'
                let v13104 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v13106 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v13104 = v13106 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v13110 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v13104 = v13110 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v13114 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v13104 = v13114 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v13118 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v13104 = v13118 
                #endif
#if FABLE_COMPILER_PYTHON
                let v13122 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v13104 = v13122 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v13126 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v13104 = v13126 
                #endif
#else
                let v13129 : (unit -> System.Threading.Tasks.Task) = v13091.AsTask
                let v13130 : System.Threading.Tasks.Task = v13129 ()
                let _run_target_args'_v13104 = v13130 
                #endif
                let v13131 : System.Threading.Tasks.Task = _run_target_args'_v13104 
                (* run_target_args'
                let v13144 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v13146 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v13144 = v13146 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v13150 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v13144 = v13150 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v13154 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v13144 = v13154 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v13157 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v13158 : Async<unit> = v13157 v13131
                let _run_target_args'_v13144 = v13158 
                #endif
#if FABLE_COMPILER_PYTHON
                let v13159 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v13160 : Async<unit> = v13159 v13131
                let _run_target_args'_v13144 = v13160 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v13161 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v13162 : Async<unit> = v13161 v13131
                let _run_target_args'_v13144 = v13162 
                #endif
#else
                let v13163 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v13164 : Async<unit> = v13163 v13131
                let _run_target_args'_v13144 = v13164 
                #endif
                let v13165 : Async<unit> = _run_target_args'_v13144 
                do! v13165 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v13489 : exn = ex
                let v13589 : unit = ()
                let v13590 : (unit -> unit) = closure5(v1, v13489)
                let v13591 : unit = (fun () -> v13590 (); v13589) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v13894 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v26780 : Async<bool> = _let'_v20 
    let _run_target_args'_v6 = v26780 
    #endif
#if FABLE_COMPILER_PYTHON
    let v26782 : unit = ()
    let _let'_v26782 =
        async {
            let v39668 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v39668 = v39668 
            let v39669 : System.Threading.CancellationToken = v39668 
            (* run_target_args'
            let v39674 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v39676 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v39674 = v39676 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v39680 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v39674 = v39680 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v39684 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v39674 = v39684 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v39688 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v39674 = v39688 
            #endif
#if FABLE_COMPILER_PYTHON
            let v39692 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v39674 = v39692 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v39696 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v39674 = v39696 
            #endif
#else
            let v39699 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v39674 = v39699 
            #endif
            let v39700 : System_Net_Sockets_TcpClient = _run_target_args'_v39674 
            use v39700 = v39700 
            let v39709 : System_Net_Sockets_TcpClient = v39700 
            try
                (* run_target_args'
                let v39827 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v39829 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v39827 = v39829 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v39833 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v39827 = v39833 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v39837 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v39827 = v39837 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v39841 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v39827 = v39841 
                #endif
#if FABLE_COMPILER_PYTHON
                let v39845 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v39827 = v39845 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v39849 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v39827 = v39849 
                #endif
#else
                let v39852 : System.Threading.Tasks.ValueTask = v39709.ConnectAsync (v0, v1, v39669)
                let _run_target_args'_v39827 = v39852 
                #endif
                let v39853 : System.Threading.Tasks.ValueTask = _run_target_args'_v39827 
                (* run_target_args'
                let v39866 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v39868 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v39866 = v39868 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v39872 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v39866 = v39872 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v39876 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v39866 = v39876 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v39880 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v39866 = v39880 
                #endif
#if FABLE_COMPILER_PYTHON
                let v39884 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v39866 = v39884 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v39888 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v39866 = v39888 
                #endif
#else
                let v39891 : (unit -> System.Threading.Tasks.Task) = v39853.AsTask
                let v39892 : System.Threading.Tasks.Task = v39891 ()
                let _run_target_args'_v39866 = v39892 
                #endif
                let v39893 : System.Threading.Tasks.Task = _run_target_args'_v39866 
                (* run_target_args'
                let v39906 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v39908 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v39906 = v39908 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v39912 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v39906 = v39912 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v39916 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v39906 = v39916 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v39919 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v39920 : Async<unit> = v39919 v39893
                let _run_target_args'_v39906 = v39920 
                #endif
#if FABLE_COMPILER_PYTHON
                let v39921 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v39922 : Async<unit> = v39921 v39893
                let _run_target_args'_v39906 = v39922 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v39923 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v39924 : Async<unit> = v39923 v39893
                let _run_target_args'_v39906 = v39924 
                #endif
#else
                let v39925 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v39926 : Async<unit> = v39925 v39893
                let _run_target_args'_v39906 = v39926 
                #endif
                let v39927 : Async<unit> = _run_target_args'_v39906 
                do! v39927 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v40251 : exn = ex
                let v40351 : unit = ()
                let v40352 : (unit -> unit) = closure5(v1, v40251)
                let v40353 : unit = (fun () -> v40352 (); v40351) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v40656 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v53542 : Async<bool> = _let'_v26782 
    let _run_target_args'_v6 = v53542 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v53544 : unit = ()
    let _let'_v53544 =
        async {
            let v66430 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v66430 = v66430 
            let v66431 : System.Threading.CancellationToken = v66430 
            (* run_target_args'
            let v66436 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v66438 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v66436 = v66438 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v66442 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v66436 = v66442 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v66446 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v66436 = v66446 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66450 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v66436 = v66450 
            #endif
#if FABLE_COMPILER_PYTHON
            let v66454 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v66436 = v66454 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v66458 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v66436 = v66458 
            #endif
#else
            let v66461 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v66436 = v66461 
            #endif
            let v66462 : System_Net_Sockets_TcpClient = _run_target_args'_v66436 
            use v66462 = v66462 
            let v66471 : System_Net_Sockets_TcpClient = v66462 
            try
                (* run_target_args'
                let v66589 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v66591 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66589 = v66591 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v66595 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66589 = v66595 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v66599 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66589 = v66599 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v66603 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66589 = v66603 
                #endif
#if FABLE_COMPILER_PYTHON
                let v66607 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66589 = v66607 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v66611 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v66589 = v66611 
                #endif
#else
                let v66614 : System.Threading.Tasks.ValueTask = v66471.ConnectAsync (v0, v1, v66431)
                let _run_target_args'_v66589 = v66614 
                #endif
                let v66615 : System.Threading.Tasks.ValueTask = _run_target_args'_v66589 
                (* run_target_args'
                let v66628 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v66630 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v66628 = v66630 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v66634 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v66628 = v66634 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v66638 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v66628 = v66638 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v66642 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v66628 = v66642 
                #endif
#if FABLE_COMPILER_PYTHON
                let v66646 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v66628 = v66646 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v66650 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v66628 = v66650 
                #endif
#else
                let v66653 : (unit -> System.Threading.Tasks.Task) = v66615.AsTask
                let v66654 : System.Threading.Tasks.Task = v66653 ()
                let _run_target_args'_v66628 = v66654 
                #endif
                let v66655 : System.Threading.Tasks.Task = _run_target_args'_v66628 
                (* run_target_args'
                let v66668 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v66670 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v66668 = v66670 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v66674 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v66668 = v66674 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v66678 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v66668 = v66678 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v66681 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v66682 : Async<unit> = v66681 v66655
                let _run_target_args'_v66668 = v66682 
                #endif
#if FABLE_COMPILER_PYTHON
                let v66683 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v66684 : Async<unit> = v66683 v66655
                let _run_target_args'_v66668 = v66684 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v66685 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v66686 : Async<unit> = v66685 v66655
                let _run_target_args'_v66668 = v66686 
                #endif
#else
                let v66687 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v66688 : Async<unit> = v66687 v66655
                let _run_target_args'_v66668 = v66688 
                #endif
                let v66689 : Async<unit> = _run_target_args'_v66668 
                do! v66689 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v67013 : exn = ex
                let v67113 : unit = ()
                let v67114 : (unit -> unit) = closure5(v1, v67013)
                let v67115 : unit = (fun () -> v67114 (); v67113) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v67418 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v80304 : Async<bool> = _let'_v53544 
    let _run_target_args'_v6 = v80304 
    #endif
#else
    let v80306 : unit = ()
    let _let'_v80306 =
        async {
            let v93192 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v93192 = v93192 
            let v93193 : System.Threading.CancellationToken = v93192 
            (* run_target_args'
            let v93198 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v93200 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v93198 = v93200 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v93204 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v93198 = v93204 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v93208 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v93198 = v93208 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v93212 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v93198 = v93212 
            #endif
#if FABLE_COMPILER_PYTHON
            let v93216 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v93198 = v93216 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v93220 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v93198 = v93220 
            #endif
#else
            let v93223 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v93198 = v93223 
            #endif
            let v93224 : System_Net_Sockets_TcpClient = _run_target_args'_v93198 
            use v93224 = v93224 
            let v93233 : System_Net_Sockets_TcpClient = v93224 
            try
                (* run_target_args'
                let v93351 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v93353 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v93351 = v93353 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v93357 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v93351 = v93357 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v93361 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v93351 = v93361 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v93365 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v93351 = v93365 
                #endif
#if FABLE_COMPILER_PYTHON
                let v93369 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v93351 = v93369 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v93373 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v93351 = v93373 
                #endif
#else
                let v93376 : System.Threading.Tasks.ValueTask = v93233.ConnectAsync (v0, v1, v93193)
                let _run_target_args'_v93351 = v93376 
                #endif
                let v93377 : System.Threading.Tasks.ValueTask = _run_target_args'_v93351 
                (* run_target_args'
                let v93390 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v93392 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v93390 = v93392 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v93396 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v93390 = v93396 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v93400 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v93390 = v93400 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v93404 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v93390 = v93404 
                #endif
#if FABLE_COMPILER_PYTHON
                let v93408 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v93390 = v93408 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v93412 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v93390 = v93412 
                #endif
#else
                let v93415 : (unit -> System.Threading.Tasks.Task) = v93377.AsTask
                let v93416 : System.Threading.Tasks.Task = v93415 ()
                let _run_target_args'_v93390 = v93416 
                #endif
                let v93417 : System.Threading.Tasks.Task = _run_target_args'_v93390 
                (* run_target_args'
                let v93430 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v93432 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v93430 = v93432 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v93436 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v93430 = v93436 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v93440 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v93430 = v93440 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v93443 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v93444 : Async<unit> = v93443 v93417
                let _run_target_args'_v93430 = v93444 
                #endif
#if FABLE_COMPILER_PYTHON
                let v93445 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v93446 : Async<unit> = v93445 v93417
                let _run_target_args'_v93430 = v93446 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v93447 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v93448 : Async<unit> = v93447 v93417
                let _run_target_args'_v93430 = v93448 
                #endif
#else
                let v93449 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v93450 : Async<unit> = v93449 v93417
                let _run_target_args'_v93430 = v93450 
                #endif
                let v93451 : Async<unit> = _run_target_args'_v93430 
                do! v93451 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v93775 : exn = ex
                let v93875 : unit = ()
                let v93876 : (unit -> unit) = closure5(v1, v93775)
                let v93877 : unit = (fun () -> v93876 (); v93875) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v94180 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v107066 : Async<bool> = _let'_v80306 
    let _run_target_args'_v6 = v107066 
    #endif
    let v107067 : Async<bool> = _run_target_args'_v6 
    v107067
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
            let v555 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v560 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v562 : US7 = null |> unbox<US7>
            let _run_target_args'_v560 = v562 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v566 : US7 = null |> unbox<US7>
            let _run_target_args'_v560 = v566 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v570 : US7 = null |> unbox<US7>
            let _run_target_args'_v560 = v570 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v574 : US7 = null |> unbox<US7>
            let _run_target_args'_v560 = v574 
            #endif
#if FABLE_COMPILER_PYTHON
            let v578 : US7 = null |> unbox<US7>
            let _run_target_args'_v560 = v578 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v581 : (bool -> US7) = method24()
            let v582 : (exn -> US7) = method25()
            let v583 : US7 = match v555 with Choice1Of2 x -> v581 x | Choice2Of2 x -> v582 x
            let _run_target_args'_v560 = v583 
            #endif
#else
            let v584 : (bool -> US7) = method24()
            let v585 : (exn -> US7) = method25()
            let v586 : US7 = match v555 with Choice1Of2 x -> v584 x | Choice2Of2 x -> v585 x
            let _run_target_args'_v560 = v586 
            #endif
            let v587 : US7 = _run_target_args'_v560 
            return v587 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1129 : Async<US7> = _let'_v19 
    let _run_target_args'_v5 = v1129 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1131 : unit = ()
    let _let'_v1131 =
        async {
            let! v0 = v0 
            let v1667 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v1672 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1674 : US7 = null |> unbox<US7>
            let _run_target_args'_v1672 = v1674 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1678 : US7 = null |> unbox<US7>
            let _run_target_args'_v1672 = v1678 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1682 : US7 = null |> unbox<US7>
            let _run_target_args'_v1672 = v1682 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1686 : US7 = null |> unbox<US7>
            let _run_target_args'_v1672 = v1686 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1690 : US7 = null |> unbox<US7>
            let _run_target_args'_v1672 = v1690 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1693 : (bool -> US7) = method24()
            let v1694 : (exn -> US7) = method25()
            let v1695 : US7 = match v1667 with Choice1Of2 x -> v1693 x | Choice2Of2 x -> v1694 x
            let _run_target_args'_v1672 = v1695 
            #endif
#else
            let v1696 : (bool -> US7) = method24()
            let v1697 : (exn -> US7) = method25()
            let v1698 : US7 = match v1667 with Choice1Of2 x -> v1696 x | Choice2Of2 x -> v1697 x
            let _run_target_args'_v1672 = v1698 
            #endif
            let v1699 : US7 = _run_target_args'_v1672 
            return v1699 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2241 : Async<US7> = _let'_v1131 
    let _run_target_args'_v5 = v2241 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2243 : unit = ()
    let _let'_v2243 =
        async {
            let! v0 = v0 
            let v2779 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v2784 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2786 : US7 = null |> unbox<US7>
            let _run_target_args'_v2784 = v2786 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2790 : US7 = null |> unbox<US7>
            let _run_target_args'_v2784 = v2790 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2794 : US7 = null |> unbox<US7>
            let _run_target_args'_v2784 = v2794 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2798 : US7 = null |> unbox<US7>
            let _run_target_args'_v2784 = v2798 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2802 : US7 = null |> unbox<US7>
            let _run_target_args'_v2784 = v2802 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2805 : (bool -> US7) = method24()
            let v2806 : (exn -> US7) = method25()
            let v2807 : US7 = match v2779 with Choice1Of2 x -> v2805 x | Choice2Of2 x -> v2806 x
            let _run_target_args'_v2784 = v2807 
            #endif
#else
            let v2808 : (bool -> US7) = method24()
            let v2809 : (exn -> US7) = method25()
            let v2810 : US7 = match v2779 with Choice1Of2 x -> v2808 x | Choice2Of2 x -> v2809 x
            let _run_target_args'_v2784 = v2810 
            #endif
            let v2811 : US7 = _run_target_args'_v2784 
            return v2811 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3353 : Async<US7> = _let'_v2243 
    let _run_target_args'_v5 = v3353 
    #endif
#else
    let v3355 : unit = ()
    let _let'_v3355 =
        async {
            let! v0 = v0 
            let v3891 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v3896 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3898 : US7 = null |> unbox<US7>
            let _run_target_args'_v3896 = v3898 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3902 : US7 = null |> unbox<US7>
            let _run_target_args'_v3896 = v3902 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3906 : US7 = null |> unbox<US7>
            let _run_target_args'_v3896 = v3906 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3910 : US7 = null |> unbox<US7>
            let _run_target_args'_v3896 = v3910 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3914 : US7 = null |> unbox<US7>
            let _run_target_args'_v3896 = v3914 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3917 : (bool -> US7) = method24()
            let v3918 : (exn -> US7) = method25()
            let v3919 : US7 = match v3891 with Choice1Of2 x -> v3917 x | Choice2Of2 x -> v3918 x
            let _run_target_args'_v3896 = v3919 
            #endif
#else
            let v3920 : (bool -> US7) = method24()
            let v3921 : (exn -> US7) = method25()
            let v3922 : US7 = match v3891 with Choice1Of2 x -> v3920 x | Choice2Of2 x -> v3921 x
            let _run_target_args'_v3896 = v3922 
            #endif
            let v3923 : US7 = _run_target_args'_v3896 
            return v3923 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4465 : Async<US7> = _let'_v3355 
    let _run_target_args'_v5 = v4465 
    #endif
    let v4466 : Async<US7> = _run_target_args'_v5 
    v4466
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
    let v86 : string = "inline_colorization::color_reset"
    let v87 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v87) v88 
    let v90 : string = "fable_library_rust::String_::fromString($0)"
    let v91 : string = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let _run_target_args'_v47 = v91 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v92 : string = "inline_colorization::color_bright_red"
    let v93 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v92 
    (* run_target_args'
    let v98 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v99 : string = "&*$0"
    let v100 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v99 
    let _run_target_args'_v98 = v100 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v101 : string = "&*$0"
    let v102 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v101 
    let _run_target_args'_v98 = v102 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v103 : string = "&*$0"
    let v104 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v103 
    let _run_target_args'_v98 = v104 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v106 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v106 
    #endif
#if FABLE_COMPILER_PYTHON
    let v110 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v110 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v114 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v114 
    #endif
#else
    let v118 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v98 = v118 
    #endif
    let v121 : Ref<Str> = _run_target_args'_v98 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v93, v121, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v47 = v135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v136 : string = "inline_colorization::color_bright_red"
    let v137 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v136 
    (* run_target_args'
    let v142 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v143 : string = "&*$0"
    let v144 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v143 
    let _run_target_args'_v142 = v144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v145 : string = "&*$0"
    let v146 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v145 
    let _run_target_args'_v142 = v146 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v147 : string = "&*$0"
    let v148 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v147 
    let _run_target_args'_v142 = v148 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v150 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v150 
    #endif
#if FABLE_COMPILER_PYTHON
    let v154 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v154 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v158 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v158 
    #endif
#else
    let v162 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v142 = v162 
    #endif
    let v165 : Ref<Str> = _run_target_args'_v142 
    let v174 : string = "inline_colorization::color_reset"
    let v175 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v174 
    let v176 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v177 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v137, v165, v175) v176 
    let v178 : string = "fable_library_rust::String_::fromString($0)"
    let v179 : string = Fable.Core.RustInterop.emitRustExpr v177 v178 
    let _run_target_args'_v47 = v179 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v181 : string = "\u001b[91m"
    let v185 : string = method15()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[91m"
    let v201 : string = method15()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[91m"
    let v217 : string = method15()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[91m"
    let v233 : string = method15()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
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
        let v100 : string = method30(v41, v42, v43, v44, v45, v46, v59, v60, v0, v91)
        method18(v100)
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
            let v4481 : US8 = v1 
            let v4823 : US6 =
                match v4481 with
                | US8_1(v4484) -> (* Error *)
                    let v4486 : string = $"%A{v4484}"
                    let v4491 : string = "System.TimeoutException"
                    let v4492 : bool = v4486.Contains v4491 
                    if v4492 then
                        let v4555 : unit = ()
                        let v4556 : (unit -> unit) = closure16(v0)
                        let v4557 : unit = (fun () -> v4556 (); v4555) ()
                        US6_1
                    else
                        let v4718 : unit = ()
                        let v4719 : (unit -> unit) = closure17(v0, v4484)
                        let v4720 : unit = (fun () -> v4719 (); v4718) ()
                        US6_1
                | US8_0(v4482) -> (* Ok *)
                    US6_0(v4482)
            return v4823 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9284 : Async<US6> = _let'_v20 
    let _run_target_args'_v6 = v9284 
    #endif
#if FABLE_COMPILER_PYTHON
    let v9286 : unit = ()
    let _let'_v9286 =
        async {
            let! v1 = v1 
            let v13747 : US8 = v1 
            let v14089 : US6 =
                match v13747 with
                | US8_1(v13750) -> (* Error *)
                    let v13752 : string = $"%A{v13750}"
                    let v13757 : string = "System.TimeoutException"
                    let v13758 : bool = v13752.Contains v13757 
                    if v13758 then
                        let v13821 : unit = ()
                        let v13822 : (unit -> unit) = closure16(v0)
                        let v13823 : unit = (fun () -> v13822 (); v13821) ()
                        US6_1
                    else
                        let v13984 : unit = ()
                        let v13985 : (unit -> unit) = closure17(v0, v13750)
                        let v13986 : unit = (fun () -> v13985 (); v13984) ()
                        US6_1
                | US8_0(v13748) -> (* Ok *)
                    US6_0(v13748)
            return v14089 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v18550 : Async<US6> = _let'_v9286 
    let _run_target_args'_v6 = v18550 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18552 : unit = ()
    let _let'_v18552 =
        async {
            let! v1 = v1 
            let v23013 : US8 = v1 
            let v23355 : US6 =
                match v23013 with
                | US8_1(v23016) -> (* Error *)
                    let v23018 : string = $"%A{v23016}"
                    let v23023 : string = "System.TimeoutException"
                    let v23024 : bool = v23018.Contains v23023 
                    if v23024 then
                        let v23087 : unit = ()
                        let v23088 : (unit -> unit) = closure16(v0)
                        let v23089 : unit = (fun () -> v23088 (); v23087) ()
                        US6_1
                    else
                        let v23250 : unit = ()
                        let v23251 : (unit -> unit) = closure17(v0, v23016)
                        let v23252 : unit = (fun () -> v23251 (); v23250) ()
                        US6_1
                | US8_0(v23014) -> (* Ok *)
                    US6_0(v23014)
            return v23355 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v27816 : Async<US6> = _let'_v18552 
    let _run_target_args'_v6 = v27816 
    #endif
#else
    let v27818 : unit = ()
    let _let'_v27818 =
        async {
            let! v1 = v1 
            let v32279 : US8 = v1 
            let v32621 : US6 =
                match v32279 with
                | US8_1(v32282) -> (* Error *)
                    let v32284 : string = $"%A{v32282}"
                    let v32289 : string = "System.TimeoutException"
                    let v32290 : bool = v32284.Contains v32289 
                    if v32290 then
                        let v32353 : unit = ()
                        let v32354 : (unit -> unit) = closure16(v0)
                        let v32355 : unit = (fun () -> v32354 (); v32353) ()
                        US6_1
                    else
                        let v32516 : unit = ()
                        let v32517 : (unit -> unit) = closure17(v0, v32282)
                        let v32518 : unit = (fun () -> v32517 (); v32516) ()
                        US6_1
                | US8_0(v32280) -> (* Ok *)
                    US6_0(v32280)
            return v32621 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v37082 : Async<US6> = _let'_v27818 
    let _run_target_args'_v6 = v37082 
    #endif
    let v37083 : Async<US6> = _run_target_args'_v6 
    v37083
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
            let v911 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v913 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v911 = v913 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v917 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v911 = v917 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v921 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v911 = v921 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v924 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v911 = v924 
            #endif
#if FABLE_COMPILER_PYTHON
            let v925 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v911 = v925 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v926 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v911 = v926 
            #endif
#else
            let v927 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v911 = v927 
            #endif
            let v928 : Async<Async<bool>> = _run_target_args'_v911 
            let! v928 = v928 
            let v937 : Async<bool> = v928 
            (* run_target_args'
            let v942 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v944 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v942 = v944 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v948 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v942 = v948 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v952 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v942 = v952 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v955 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v956 : Async<Choice<bool, exn>> = v955 v937
            let _run_target_args'_v942 = v956 
            #endif
#if FABLE_COMPILER_PYTHON
            let v957 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v958 : Async<Choice<bool, exn>> = v957 v937
            let _run_target_args'_v942 = v958 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v959 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v960 : Async<Choice<bool, exn>> = v959 v937
            let _run_target_args'_v942 = v960 
            #endif
#else
            let v961 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v962 : Async<Choice<bool, exn>> = v961 v937
            let _run_target_args'_v942 = v962 
            #endif
            let v963 : Async<Choice<bool, exn>> = _run_target_args'_v942 
            let v972 : Async<US7> = method23(v963)
            let v973 : Async<US8> = method26(v972)
            let v974 : Async<US6> = method27(v1, v973)
            return! v974 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1859 : Async<US6> = _let'_v20 
    let _run_target_args'_v6 = v1859 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1861 : unit = ()
    let _let'_v1861 =
        async {
            (* run_target_args'
            let v2752 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2754 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v2752 = v2754 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2758 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v2752 = v2758 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2762 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v2752 = v2762 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2765 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2752 = v2765 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2766 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2752 = v2766 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2767 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2752 = v2767 
            #endif
#else
            let v2768 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2752 = v2768 
            #endif
            let v2769 : Async<Async<bool>> = _run_target_args'_v2752 
            let! v2769 = v2769 
            let v2778 : Async<bool> = v2769 
            (* run_target_args'
            let v2783 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2785 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v2783 = v2785 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2789 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v2783 = v2789 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2793 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v2783 = v2793 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2796 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2797 : Async<Choice<bool, exn>> = v2796 v2778
            let _run_target_args'_v2783 = v2797 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2798 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2799 : Async<Choice<bool, exn>> = v2798 v2778
            let _run_target_args'_v2783 = v2799 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2800 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2801 : Async<Choice<bool, exn>> = v2800 v2778
            let _run_target_args'_v2783 = v2801 
            #endif
#else
            let v2802 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2803 : Async<Choice<bool, exn>> = v2802 v2778
            let _run_target_args'_v2783 = v2803 
            #endif
            let v2804 : Async<Choice<bool, exn>> = _run_target_args'_v2783 
            let v2813 : Async<US7> = method23(v2804)
            let v2814 : Async<US8> = method26(v2813)
            let v2815 : Async<US6> = method27(v1, v2814)
            return! v2815 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3700 : Async<US6> = _let'_v1861 
    let _run_target_args'_v6 = v3700 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3702 : unit = ()
    let _let'_v3702 =
        async {
            (* run_target_args'
            let v4593 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4595 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v4593 = v4595 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4599 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v4593 = v4599 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4603 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v4593 = v4603 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4606 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4593 = v4606 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4607 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4593 = v4607 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4608 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4593 = v4608 
            #endif
#else
            let v4609 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4593 = v4609 
            #endif
            let v4610 : Async<Async<bool>> = _run_target_args'_v4593 
            let! v4610 = v4610 
            let v4619 : Async<bool> = v4610 
            (* run_target_args'
            let v4624 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4626 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v4624 = v4626 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4630 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v4624 = v4630 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4634 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v4624 = v4634 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4637 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4638 : Async<Choice<bool, exn>> = v4637 v4619
            let _run_target_args'_v4624 = v4638 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4639 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4640 : Async<Choice<bool, exn>> = v4639 v4619
            let _run_target_args'_v4624 = v4640 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4641 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4642 : Async<Choice<bool, exn>> = v4641 v4619
            let _run_target_args'_v4624 = v4642 
            #endif
#else
            let v4643 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4644 : Async<Choice<bool, exn>> = v4643 v4619
            let _run_target_args'_v4624 = v4644 
            #endif
            let v4645 : Async<Choice<bool, exn>> = _run_target_args'_v4624 
            let v4654 : Async<US7> = method23(v4645)
            let v4655 : Async<US8> = method26(v4654)
            let v4656 : Async<US6> = method27(v1, v4655)
            return! v4656 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5541 : Async<US6> = _let'_v3702 
    let _run_target_args'_v6 = v5541 
    #endif
#else
    let v5543 : unit = ()
    let _let'_v5543 =
        async {
            (* run_target_args'
            let v6434 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6436 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v6434 = v6436 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6440 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v6434 = v6440 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6444 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v6434 = v6444 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6447 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6434 = v6447 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6448 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6434 = v6448 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6449 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6434 = v6449 
            #endif
#else
            let v6450 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6434 = v6450 
            #endif
            let v6451 : Async<Async<bool>> = _run_target_args'_v6434 
            let! v6451 = v6451 
            let v6460 : Async<bool> = v6451 
            (* run_target_args'
            let v6465 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6467 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v6465 = v6467 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6471 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v6465 = v6471 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6475 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v6465 = v6475 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6478 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v6479 : Async<Choice<bool, exn>> = v6478 v6460
            let _run_target_args'_v6465 = v6479 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6480 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v6481 : Async<Choice<bool, exn>> = v6480 v6460
            let _run_target_args'_v6465 = v6481 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6482 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v6483 : Async<Choice<bool, exn>> = v6482 v6460
            let _run_target_args'_v6465 = v6483 
            #endif
#else
            let v6484 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v6485 : Async<Choice<bool, exn>> = v6484 v6460
            let _run_target_args'_v6465 = v6485 
            #endif
            let v6486 : Async<Choice<bool, exn>> = _run_target_args'_v6465 
            let v6495 : Async<US7> = method23(v6486)
            let v6496 : Async<US8> = method26(v6495)
            let v6497 : Async<US6> = method27(v1, v6496)
            return! v6497 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7382 : Async<US6> = _let'_v5543 
    let _run_target_args'_v6 = v7382 
    #endif
    let v7383 : Async<US6> = _run_target_args'_v6 
    v7383
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
    let v262 : string = $"{v252}"
    let v270 : unit = ()
    let v271 : (unit -> unit) = closure7(v13, v262)
    let v272 : unit = (fun () -> v271 (); v270) ()
    let v279 : string = $"{v93}"
    let v287 : unit = ()
    let v288 : (unit -> unit) = closure7(v13, v279)
    let v289 : unit = (fun () -> v288 (); v287) ()
    let v297 : string = "status"
    let v298 : string = $"{v297}"
    let v306 : unit = ()
    let v307 : (unit -> unit) = closure7(v13, v298)
    let v308 : unit = (fun () -> v307 (); v306) ()
    let v315 : string = $"{v54}"
    let v323 : unit = ()
    let v324 : (unit -> unit) = closure7(v13, v315)
    let v325 : unit = (fun () -> v324 (); v323) ()
    let v333 : string =
        if v11 then
            let v331 : string = "true"
            v331
        else
            let v332 : string = "false"
            v332
    let v335 : string = $"{v333}"
    let v343 : unit = ()
    let v344 : (unit -> unit) = closure7(v13, v335)
    let v345 : unit = (fun () -> v344 (); v343) ()
    let v353 : string = " }"
    let v354 : string = $"{v353}"
    let v362 : unit = ()
    let v363 : (unit -> unit) = closure7(v13, v354)
    let v364 : unit = (fun () -> v363 (); v362) ()
    let v370 : string = v13.l0
    let v371 : int64 = v0.l0
    let v374 : string = " "
    let v375 : string = v6 + v374 
    let v379 : string = v375 + v7 
    let v384 : string = " #"
    let v385 : string = v379 + v384 
    let v389 : (int64 -> string) = _.ToString()
    let v390 : string = v389 v371
    let v394 : string = v385 + v390 
    let v398 : string = v394 + v374 
    let v403 : string = "networking.wait_for_port_access"
    let v404 : string = v398 + v403 
    let v409 : string = " / "
    let v410 : string = v404 + v409 
    let v414 : string = v410 + v370 
    method17(v414)
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
            let v2459 : (int32 -> US9) = method34()
            let v2460 : US9 option = v0 |> Option.map v2459 
            let v2480 : US9 = US9_1
            let v2481 : US9 = v2460 |> Option.defaultValue v2480 
            let v2489 : Async<bool> =
                match v2481 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v2486) -> (* Some *)
                    method19(v2486, v2, v3)
            let! v2489 = v2489 
            let v2490 : bool = v2489 
            let v2491 : bool = v2490 = v1
            if v2491 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v2492 : int64 = v4 % 100L
                let v2493 : bool = v2492 = 0L
                if v2493 then
                    let v2554 : unit = ()
                    let v2555 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v2556 : unit = (fun () -> v2555 (); v2554) ()
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
                let v2642 : int64 = v4 + 1L
                let v2643 : Async<int64> = method32(v0, v1, v2, v3, v2642)
                return! v2643 
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
    let v5075 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v5075 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5077 : unit = ()
    let _let'_v5077 =
        async {
            let v7513 : (int32 -> US9) = method34()
            let v7514 : US9 option = v0 |> Option.map v7513 
            let v7534 : US9 = US9_1
            let v7535 : US9 = v7514 |> Option.defaultValue v7534 
            let v7543 : Async<bool> =
                match v7535 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v7540) -> (* Some *)
                    method19(v7540, v2, v3)
            let! v7543 = v7543 
            let v7544 : bool = v7543 
            let v7545 : bool = v7544 = v1
            if v7545 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v7546 : int64 = v4 % 100L
                let v7547 : bool = v7546 = 0L
                if v7547 then
                    let v7608 : unit = ()
                    let v7609 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v7610 : unit = (fun () -> v7609 (); v7608) ()
                    ()
                (* run_target_args'
                let v7675 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7676 : (int32 -> Async<unit>) = Async.Sleep
                let v7677 : Async<unit> = v7676 10
                let _run_target_args'_v7675 = v7677 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7678 : (int32 -> Async<unit>) = Async.Sleep
                let v7679 : Async<unit> = v7678 10
                let _run_target_args'_v7675 = v7679 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7680 : (int32 -> Async<unit>) = Async.Sleep
                let v7681 : Async<unit> = v7680 10
                let _run_target_args'_v7675 = v7681 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7682 : (int32 -> Async<unit>) = Async.Sleep
                let v7683 : Async<unit> = v7682 10
                let _run_target_args'_v7675 = v7683 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7684 : (int32 -> Async<unit>) = Async.Sleep
                let v7685 : Async<unit> = v7684 10
                let _run_target_args'_v7675 = v7685 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7686 : (int32 -> Async<unit>) = Async.Sleep
                let v7687 : Async<unit> = v7686 10
                let _run_target_args'_v7675 = v7687 
                #endif
#else
                let v7688 : (int32 -> Async<unit>) = Async.Sleep
                let v7689 : Async<unit> = v7688 10
                let _run_target_args'_v7675 = v7689 
                #endif
                let v7690 : Async<unit> = _run_target_args'_v7675 
                do! v7690 
                let v7696 : int64 = v4 + 1L
                let v7697 : Async<int64> = method32(v0, v1, v2, v3, v7696)
                return! v7697 
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
    let v10129 : Async<int64> = _let'_v5077 
    let _run_target_args'_v9 = v10129 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v10131 : unit = ()
    let _let'_v10131 =
        async {
            let v12567 : (int32 -> US9) = method34()
            let v12568 : US9 option = v0 |> Option.map v12567 
            let v12588 : US9 = US9_1
            let v12589 : US9 = v12568 |> Option.defaultValue v12588 
            let v12597 : Async<bool> =
                match v12589 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v12594) -> (* Some *)
                    method19(v12594, v2, v3)
            let! v12597 = v12597 
            let v12598 : bool = v12597 
            let v12599 : bool = v12598 = v1
            if v12599 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v12600 : int64 = v4 % 100L
                let v12601 : bool = v12600 = 0L
                if v12601 then
                    let v12662 : unit = ()
                    let v12663 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v12664 : unit = (fun () -> v12663 (); v12662) ()
                    ()
                (* run_target_args'
                let v12729 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v12730 : (int32 -> Async<unit>) = Async.Sleep
                let v12731 : Async<unit> = v12730 10
                let _run_target_args'_v12729 = v12731 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v12732 : (int32 -> Async<unit>) = Async.Sleep
                let v12733 : Async<unit> = v12732 10
                let _run_target_args'_v12729 = v12733 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v12734 : (int32 -> Async<unit>) = Async.Sleep
                let v12735 : Async<unit> = v12734 10
                let _run_target_args'_v12729 = v12735 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v12736 : (int32 -> Async<unit>) = Async.Sleep
                let v12737 : Async<unit> = v12736 10
                let _run_target_args'_v12729 = v12737 
                #endif
#if FABLE_COMPILER_PYTHON
                let v12738 : (int32 -> Async<unit>) = Async.Sleep
                let v12739 : Async<unit> = v12738 10
                let _run_target_args'_v12729 = v12739 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v12740 : (int32 -> Async<unit>) = Async.Sleep
                let v12741 : Async<unit> = v12740 10
                let _run_target_args'_v12729 = v12741 
                #endif
#else
                let v12742 : (int32 -> Async<unit>) = Async.Sleep
                let v12743 : Async<unit> = v12742 10
                let _run_target_args'_v12729 = v12743 
                #endif
                let v12744 : Async<unit> = _run_target_args'_v12729 
                do! v12744 
                let v12750 : int64 = v4 + 1L
                let v12751 : Async<int64> = method32(v0, v1, v2, v3, v12750)
                return! v12751 
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
    let v15183 : Async<int64> = _let'_v10131 
    let _run_target_args'_v9 = v15183 
    #endif
#else
    let v15185 : unit = ()
    let _let'_v15185 =
        async {
            let v17621 : (int32 -> US9) = method34()
            let v17622 : US9 option = v0 |> Option.map v17621 
            let v17642 : US9 = US9_1
            let v17643 : US9 = v17622 |> Option.defaultValue v17642 
            let v17651 : Async<bool> =
                match v17643 with
                | US9_1 -> (* None *)
                    method6(v2, v3)
                | US9_0(v17648) -> (* Some *)
                    method19(v17648, v2, v3)
            let! v17651 = v17651 
            let v17652 : bool = v17651 
            let v17653 : bool = v17652 = v1
            if v17653 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v17654 : int64 = v4 % 100L
                let v17655 : bool = v17654 = 0L
                if v17655 then
                    let v17716 : unit = ()
                    let v17717 : (unit -> unit) = closure23(v0, v1, v3, v4)
                    let v17718 : unit = (fun () -> v17717 (); v17716) ()
                    ()
                (* run_target_args'
                let v17783 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v17784 : (int32 -> Async<unit>) = Async.Sleep
                let v17785 : Async<unit> = v17784 10
                let _run_target_args'_v17783 = v17785 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v17786 : (int32 -> Async<unit>) = Async.Sleep
                let v17787 : Async<unit> = v17786 10
                let _run_target_args'_v17783 = v17787 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v17788 : (int32 -> Async<unit>) = Async.Sleep
                let v17789 : Async<unit> = v17788 10
                let _run_target_args'_v17783 = v17789 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v17790 : (int32 -> Async<unit>) = Async.Sleep
                let v17791 : Async<unit> = v17790 10
                let _run_target_args'_v17783 = v17791 
                #endif
#if FABLE_COMPILER_PYTHON
                let v17792 : (int32 -> Async<unit>) = Async.Sleep
                let v17793 : Async<unit> = v17792 10
                let _run_target_args'_v17783 = v17793 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v17794 : (int32 -> Async<unit>) = Async.Sleep
                let v17795 : Async<unit> = v17794 10
                let _run_target_args'_v17783 = v17795 
                #endif
#else
                let v17796 : (int32 -> Async<unit>) = Async.Sleep
                let v17797 : Async<unit> = v17796 10
                let _run_target_args'_v17783 = v17797 
                #endif
                let v17798 : Async<unit> = _run_target_args'_v17783 
                do! v17798 
                let v17804 : int64 = v4 + 1L
                let v17805 : Async<int64> = method32(v0, v1, v2, v3, v17804)
                return! v17805 
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
    let v20237 : Async<int64> = _let'_v15185 
    let _run_target_args'_v9 = v20237 
    #endif
    let v20238 : Async<int64> = _run_target_args'_v9 
    v20238
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
