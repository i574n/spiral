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
    | US6_0 of f0_0 : Mut0 * f0_1 : Mut1 * f0_2 : Mut2 * f0_3 : Mut3 * f0_4 : Mut4 * f0_5 : int64 option
    | US6_1
and [<Struct>] US7 =
    | US7_0 of f0_0 : bool
    | US7_1
and [<Struct>] US8 =
    | US8_0 of f0_0 : bool
    | US8_1 of f1_0 : exn
and [<Struct>] US9 =
    | US9_0 of f0_0 : bool
    | US9_1 of f1_0 : exn
and [<Struct>] US10 =
    | US10_0 of f0_0 : int32
    | US10_1
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
and closure6 () (v0 : int64) : US2 =
    US2_0(v0)
and method9 () : (int64 -> US2) =
    closure6()
and method10 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method11 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method8 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v216 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v219 : (int64 -> US2) = method9()
    let v220 : US2 option = v5 |> Option.map v219 
    let v240 : US2 = US2_1
    let v241 : US2 = v220 |> Option.defaultValue v240 
    let v395 : System.DateTime =
        match v241 with
        | US2_1 -> (* None *)
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
        | US2_0(v245) -> (* Some *)
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
    let v396 : string = method10()
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
    let v429 : (int64 -> US2) = method9()
    let v430 : US2 option = v5 |> Option.map v429 
    let v450 : US2 = US2_1
    let v451 : US2 = v430 |> Option.defaultValue v450 
    let v605 : System.DateTime =
        match v451 with
        | US2_1 -> (* None *)
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
        | US2_0(v455) -> (* Some *)
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
    let v606 : string = method10()
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
    let v641 : (int64 -> US2) = method9()
    let v642 : US2 option = v5 |> Option.map v641 
    let v662 : US2 = US2_1
    let v663 : US2 = v642 |> Option.defaultValue v662 
    let v675 : uint64 =
        match v663 with
        | US2_1 -> (* None *)
            v638
        | US2_0(v667) -> (* Some *)
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
    let v688 : (int64 -> US2) = method9()
    let v689 : US2 option = v5 |> Option.map v688 
    let v709 : US2 = US2_1
    let v710 : US2 = v689 |> Option.defaultValue v709 
    let v864 : System.DateTime =
        match v710 with
        | US2_1 -> (* None *)
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
        | US2_0(v714) -> (* Some *)
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
    let v865 : string = method11()
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
    let v898 : (int64 -> US2) = method9()
    let v899 : US2 option = v5 |> Option.map v898 
    let v919 : US2 = US2_1
    let v920 : US2 = v899 |> Option.defaultValue v919 
    let v1074 : System.DateTime =
        match v920 with
        | US2_1 -> (* None *)
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
        | US2_0(v924) -> (* Some *)
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
    let v1075 : string = method11()
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
    let v1108 : (int64 -> US2) = method9()
    let v1109 : US2 option = v5 |> Option.map v1108 
    let v1129 : US2 = US2_1
    let v1130 : US2 = v1109 |> Option.defaultValue v1129 
    let v1284 : System.DateTime =
        match v1130 with
        | US2_1 -> (* None *)
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
        | US2_0(v1134) -> (* Some *)
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
    let v1285 : string = method11()
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
    let v1318 : (int64 -> US2) = method9()
    let v1319 : US2 option = v5 |> Option.map v1318 
    let v1339 : US2 = US2_1
    let v1340 : US2 = v1319 |> Option.defaultValue v1339 
    let v1494 : System.DateTime =
        match v1340 with
        | US2_1 -> (* None *)
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
        | US2_0(v1344) -> (* Some *)
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
    let v1495 : string = method11()
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
and method14 () : string =
    let v0 : string = ""
    v0
and closure7 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v4 : string = v2 + v1 
    v0.l0 <- v4
    ()
and method13 (v0 : char) : string =
    let v1 : string = method14()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v7 : string = $"{v0}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure7(v2, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v23 : string = v2.l0
    v23
and method12 () : string =
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
    let v137 : string = method13(v136)
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
and method16 (v0 : int32, v1 : string) : string =
    let v2 : string = method14()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure7(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "port"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure7(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure7(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v65 : string = $"{v0}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure7(v3, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = "; "
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure7(v3, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v102 : string = "ex"
    let v103 : string = $"{v102}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure7(v3, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v120 : string = $"{v44}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure7(v3, v120)
    let v130 : unit = (fun () -> v129 (); v128) ()
    let v137 : string = $"{v1}"
    let v145 : unit = ()
    let v146 : (unit -> unit) = closure7(v3, v137)
    let v147 : unit = (fun () -> v146 (); v145) ()
    let v155 : string = " }"
    let v156 : string = $"{v155}"
    let v164 : unit = ()
    let v165 : (unit -> unit) = closure7(v3, v156)
    let v166 : unit = (fun () -> v165 (); v164) ()
    let v172 : string = v3.l0
    v172
and method17 (v0 : string) : string =
    let v1 : char list = []
    let v8 : (char list -> (char [])) = List.toArray
    let v9 : (char []) = v8 v1
    let v12 : string = v0.TrimStart v9 
    let v46 : char list = []
    let v48 : char list = '/' :: v46 
    let v52 : char list = ' ' :: v48 
    let v61 : (char list -> (char [])) = List.toArray
    let v62 : (char []) = v61 v52
    let v65 : string = v12.TrimEnd v62 
    v65
and method15 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method16(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v29 : (int64 -> string) = _.ToString()
    let v30 : string = v29 v11
    let v34 : string = v25 + v30 
    let v38 : string = v34 + v14 
    let v43 : string = "networking.test_port_open"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method17(v54)
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
and closure5 (v0 : int32, v1 : exn) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure0()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US0 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 0 >= v62
            v63
    let v65 : bool = v64 = false
    let v338 : US6 =
        if v65 then
            US6_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method8(v105, v106, v107, v108, v109, v110)
            let v124 : string = method12()
            (* run_target_args'
            let v129 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v131 : string = $"%A{v1}"
            let _run_target_args'_v129 = v131 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v135 : string = $"%A{v1}"
            let _run_target_args'_v129 = v135 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v139 : string = $"%A{v1}"
            let _run_target_args'_v129 = v139 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v143 : string = $"%A{v1}"
            let _run_target_args'_v129 = v143 
            #endif
#if FABLE_COMPILER_PYTHON
            let v147 : string = $"%A{v1}"
            let _run_target_args'_v129 = v147 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v151 : string = $"%A{v1}"
            let _run_target_args'_v129 = v151 
            #endif
#else
            let v154 : string = $"{v1.GetType ()}: {v1.Message}"
            let _run_target_args'_v129 = v154 
            #endif
            let v155 : string = _run_target_args'_v129 
            let v164 : string = method15(v105, v106, v107, v108, v109, v110, v123, v124, v0, v155)
            let v179 : unit = ()
            let v180 : unit = (fun () -> v17 (); v179) ()
            let struct (v203 : Mut0, v204 : Mut1, v205 : Mut2, v206 : Mut3, v207 : Mut4, v208 : int64 option) = TraceState.trace_state.Value
            let v223 : unit = ()
            let v224 : (unit -> unit) = closure8(v203)
            let v225 : unit = (fun () -> v224 (); v223) ()
            let v228 : (string -> unit) = closure9()
            (* run_target_args'
            let v229 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v230 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v164 v230 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v231 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v164 v231 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v232 : string = v206.l0
            let v233 : bool = v232 = ""
            let v248 : string =
                if v233 then
                    v164
                else
                    let v234 : bool = v164 = ""
                    if v234 then
                        let v235 : string = v206.l0
                        v235
                    else
                        let v236 : string = v206.l0
                        let v239 : string = "\n"
                        let v240 : string = v236 + v239 
                        let v244 : string = v240 + v164 
                        v244
            (* run_target_args'
            let v253 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v254 : string = "&*$0"
            let v255 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v254 
            let _run_target_args'_v253 = v255 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v256 : string = "&*$0"
            let v257 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v256 
            let _run_target_args'_v253 = v257 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v258 : string = "&*$0"
            let v259 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v258 
            let _run_target_args'_v253 = v259 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v261 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v261 
            #endif
#if FABLE_COMPILER_PYTHON
            let v265 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v265 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v269 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v269 
            #endif
#else
            let v273 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v273 
            #endif
            let v276 : Ref<Str> = _run_target_args'_v253 
            let v285 : string = $"$0.chars()"
            let v286 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v276 v285 
            let v287 : string = "$0"
            let v288 : _ = Fable.Core.RustInterop.emitRustExpr v286 v287 
            let v289 : string = "$0.collect::<Vec<_>>()"
            let v290 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v288 v289 
            let v291 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v292 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v290 v291 
            let v293 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v294 : bool = Fable.Core.RustInterop.emitRustExpr v292 v293 
            let v295 : string = "x"
            let v296 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v295 
            let v297 : string = "String::from_iter($0)"
            let v298 : std_string_String = Fable.Core.RustInterop.emitRustExpr v296 v297 
            let v299 : string = "true; $0 }).collect::<Vec<_>>()"
            let v300 : bool = Fable.Core.RustInterop.emitRustExpr v298 v299 
            let v301 : string = "_vec_map"
            let v302 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v301 
            let v303 : string = "$0.len()"
            let v304 : unativeint = Fable.Core.RustInterop.emitRustExpr v302 v303 
            let v310 : int32 = v304 |> int32 
            let v320 : string = ""
            let v321 : bool = v164 <> v320 
            let v325 : bool =
                if v321 then
                    let v324 : bool = v310 <= 1
                    v324
                else
                    false
            if v325 then
                v206.l0 <- v248
                ()
            else
                v206.l0 <- v320
                let v326 : string = "true; $0.into_iter().for_each(|x| { //"
                let v327 : bool = Fable.Core.RustInterop.emitRustExpr v302 v326 
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
            v228 v164
            #endif
#if FABLE_COMPILER_PYTHON
            v228 v164
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v228 v164
            #endif
#else
            v228 v164
            #endif
            // run_target_args' is_unit
            let v336 : (string -> unit) = v204.l0
            v336 v164
            US6_0(v203, v204, v205, v206, v207, v208)
    
    ()
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
            let v32523 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v32523 = v32523 
            let v32524 : System.Threading.CancellationToken = v32523 
            (* run_target_args'
            let v32529 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v32531 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v32529 = v32531 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v32535 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v32529 = v32535 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v32539 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v32529 = v32539 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v32543 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v32529 = v32543 
            #endif
#if FABLE_COMPILER_PYTHON
            let v32547 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v32529 = v32547 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v32551 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v32529 = v32551 
            #endif
#else
            let v32554 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v32529 = v32554 
            #endif
            let v32555 : System_Net_Sockets_TcpClient = _run_target_args'_v32529 
            use v32555 = v32555 
            let v32564 : System_Net_Sockets_TcpClient = v32555 
            try
                (* run_target_args'
                let v32682 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v32684 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v32682 = v32684 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v32688 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v32682 = v32688 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v32692 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v32682 = v32692 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v32696 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v32682 = v32696 
                #endif
#if FABLE_COMPILER_PYTHON
                let v32700 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v32682 = v32700 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v32704 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v32682 = v32704 
                #endif
#else
                let v32707 : System.Threading.Tasks.ValueTask = v32564.ConnectAsync (v0, v1, v32524)
                let _run_target_args'_v32682 = v32707 
                #endif
                let v32708 : System.Threading.Tasks.ValueTask = _run_target_args'_v32682 
                (* run_target_args'
                let v32721 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v32723 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32721 = v32723 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v32727 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32721 = v32727 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v32731 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32721 = v32731 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v32735 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32721 = v32735 
                #endif
#if FABLE_COMPILER_PYTHON
                let v32739 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32721 = v32739 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v32743 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32721 = v32743 
                #endif
#else
                let v32746 : (unit -> System.Threading.Tasks.Task) = v32708.AsTask
                let v32747 : System.Threading.Tasks.Task = v32746 ()
                let _run_target_args'_v32721 = v32747 
                #endif
                let v32748 : System.Threading.Tasks.Task = _run_target_args'_v32721 
                (* run_target_args'
                let v32761 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v32763 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v32761 = v32763 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v32767 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v32761 = v32767 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v32771 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v32761 = v32771 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v32774 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v32775 : Async<unit> = v32774 v32748
                let _run_target_args'_v32761 = v32775 
                #endif
#if FABLE_COMPILER_PYTHON
                let v32776 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v32777 : Async<unit> = v32776 v32748
                let _run_target_args'_v32761 = v32777 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v32778 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v32779 : Async<unit> = v32778 v32748
                let _run_target_args'_v32761 = v32779 
                #endif
#else
                let v32780 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v32781 : Async<unit> = v32780 v32748
                let _run_target_args'_v32761 = v32781 
                #endif
                let v32782 : Async<unit> = _run_target_args'_v32761 
                do! v32782 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v33605 : exn = ex
                let v33956 : unit = ()
                let v33957 : (unit -> unit) = closure5(v1, v33605)
                let v33958 : unit = (fun () -> v33957 (); v33956) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v35020 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v67523 : Async<bool> = _let'_v20 
    let _run_target_args'_v6 = v67523 
    #endif
#if FABLE_COMPILER_PYTHON
    let v67525 : unit = ()
    let _let'_v67525 =
        async {
            let v100028 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v100028 = v100028 
            let v100029 : System.Threading.CancellationToken = v100028 
            (* run_target_args'
            let v100034 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v100036 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v100034 = v100036 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v100040 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v100034 = v100040 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v100044 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v100034 = v100044 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v100048 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v100034 = v100048 
            #endif
#if FABLE_COMPILER_PYTHON
            let v100052 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v100034 = v100052 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v100056 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v100034 = v100056 
            #endif
#else
            let v100059 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v100034 = v100059 
            #endif
            let v100060 : System_Net_Sockets_TcpClient = _run_target_args'_v100034 
            use v100060 = v100060 
            let v100069 : System_Net_Sockets_TcpClient = v100060 
            try
                (* run_target_args'
                let v100187 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v100189 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v100187 = v100189 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v100193 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v100187 = v100193 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v100197 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v100187 = v100197 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v100201 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v100187 = v100201 
                #endif
#if FABLE_COMPILER_PYTHON
                let v100205 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v100187 = v100205 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v100209 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v100187 = v100209 
                #endif
#else
                let v100212 : System.Threading.Tasks.ValueTask = v100069.ConnectAsync (v0, v1, v100029)
                let _run_target_args'_v100187 = v100212 
                #endif
                let v100213 : System.Threading.Tasks.ValueTask = _run_target_args'_v100187 
                (* run_target_args'
                let v100226 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v100228 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v100226 = v100228 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v100232 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v100226 = v100232 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v100236 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v100226 = v100236 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v100240 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v100226 = v100240 
                #endif
#if FABLE_COMPILER_PYTHON
                let v100244 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v100226 = v100244 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v100248 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v100226 = v100248 
                #endif
#else
                let v100251 : (unit -> System.Threading.Tasks.Task) = v100213.AsTask
                let v100252 : System.Threading.Tasks.Task = v100251 ()
                let _run_target_args'_v100226 = v100252 
                #endif
                let v100253 : System.Threading.Tasks.Task = _run_target_args'_v100226 
                (* run_target_args'
                let v100266 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v100268 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v100266 = v100268 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v100272 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v100266 = v100272 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v100276 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v100266 = v100276 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v100279 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v100280 : Async<unit> = v100279 v100253
                let _run_target_args'_v100266 = v100280 
                #endif
#if FABLE_COMPILER_PYTHON
                let v100281 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v100282 : Async<unit> = v100281 v100253
                let _run_target_args'_v100266 = v100282 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v100283 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v100284 : Async<unit> = v100283 v100253
                let _run_target_args'_v100266 = v100284 
                #endif
#else
                let v100285 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v100286 : Async<unit> = v100285 v100253
                let _run_target_args'_v100266 = v100286 
                #endif
                let v100287 : Async<unit> = _run_target_args'_v100266 
                do! v100287 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v101110 : exn = ex
                let v101461 : unit = ()
                let v101462 : (unit -> unit) = closure5(v1, v101110)
                let v101463 : unit = (fun () -> v101462 (); v101461) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v102525 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v135028 : Async<bool> = _let'_v67525 
    let _run_target_args'_v6 = v135028 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v135030 : unit = ()
    let _let'_v135030 =
        async {
            let v167533 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v167533 = v167533 
            let v167534 : System.Threading.CancellationToken = v167533 
            (* run_target_args'
            let v167539 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v167541 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v167539 = v167541 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v167545 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v167539 = v167545 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v167549 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v167539 = v167549 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v167553 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v167539 = v167553 
            #endif
#if FABLE_COMPILER_PYTHON
            let v167557 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v167539 = v167557 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v167561 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v167539 = v167561 
            #endif
#else
            let v167564 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v167539 = v167564 
            #endif
            let v167565 : System_Net_Sockets_TcpClient = _run_target_args'_v167539 
            use v167565 = v167565 
            let v167574 : System_Net_Sockets_TcpClient = v167565 
            try
                (* run_target_args'
                let v167692 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v167694 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v167692 = v167694 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v167698 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v167692 = v167698 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v167702 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v167692 = v167702 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v167706 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v167692 = v167706 
                #endif
#if FABLE_COMPILER_PYTHON
                let v167710 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v167692 = v167710 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v167714 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v167692 = v167714 
                #endif
#else
                let v167717 : System.Threading.Tasks.ValueTask = v167574.ConnectAsync (v0, v1, v167534)
                let _run_target_args'_v167692 = v167717 
                #endif
                let v167718 : System.Threading.Tasks.ValueTask = _run_target_args'_v167692 
                (* run_target_args'
                let v167731 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v167733 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v167731 = v167733 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v167737 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v167731 = v167737 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v167741 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v167731 = v167741 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v167745 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v167731 = v167745 
                #endif
#if FABLE_COMPILER_PYTHON
                let v167749 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v167731 = v167749 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v167753 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v167731 = v167753 
                #endif
#else
                let v167756 : (unit -> System.Threading.Tasks.Task) = v167718.AsTask
                let v167757 : System.Threading.Tasks.Task = v167756 ()
                let _run_target_args'_v167731 = v167757 
                #endif
                let v167758 : System.Threading.Tasks.Task = _run_target_args'_v167731 
                (* run_target_args'
                let v167771 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v167773 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v167771 = v167773 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v167777 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v167771 = v167777 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v167781 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v167771 = v167781 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v167784 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v167785 : Async<unit> = v167784 v167758
                let _run_target_args'_v167771 = v167785 
                #endif
#if FABLE_COMPILER_PYTHON
                let v167786 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v167787 : Async<unit> = v167786 v167758
                let _run_target_args'_v167771 = v167787 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v167788 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v167789 : Async<unit> = v167788 v167758
                let _run_target_args'_v167771 = v167789 
                #endif
#else
                let v167790 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v167791 : Async<unit> = v167790 v167758
                let _run_target_args'_v167771 = v167791 
                #endif
                let v167792 : Async<unit> = _run_target_args'_v167771 
                do! v167792 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v168615 : exn = ex
                let v168966 : unit = ()
                let v168967 : (unit -> unit) = closure5(v1, v168615)
                let v168968 : unit = (fun () -> v168967 (); v168966) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v170030 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v202533 : Async<bool> = _let'_v135030 
    let _run_target_args'_v6 = v202533 
    #endif
#else
    let v202535 : unit = ()
    let _let'_v202535 =
        async {
            let v235038 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v235038 = v235038 
            let v235039 : System.Threading.CancellationToken = v235038 
            (* run_target_args'
            let v235044 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v235046 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v235044 = v235046 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v235050 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v235044 = v235050 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v235054 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v235044 = v235054 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v235058 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v235044 = v235058 
            #endif
#if FABLE_COMPILER_PYTHON
            let v235062 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v235044 = v235062 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v235066 : System_Net_Sockets_TcpClient = null |> unbox<System_Net_Sockets_TcpClient>
            let _run_target_args'_v235044 = v235066 
            #endif
#else
            let v235069 : System_Net_Sockets_TcpClient = new System_Net_Sockets_TcpClient ()
            let _run_target_args'_v235044 = v235069 
            #endif
            let v235070 : System_Net_Sockets_TcpClient = _run_target_args'_v235044 
            use v235070 = v235070 
            let v235079 : System_Net_Sockets_TcpClient = v235070 
            try
                (* run_target_args'
                let v235197 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v235199 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v235197 = v235199 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v235203 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v235197 = v235203 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v235207 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v235197 = v235207 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v235211 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v235197 = v235211 
                #endif
#if FABLE_COMPILER_PYTHON
                let v235215 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v235197 = v235215 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v235219 : System.Threading.Tasks.ValueTask = null |> unbox<System.Threading.Tasks.ValueTask>
                let _run_target_args'_v235197 = v235219 
                #endif
#else
                let v235222 : System.Threading.Tasks.ValueTask = v235079.ConnectAsync (v0, v1, v235039)
                let _run_target_args'_v235197 = v235222 
                #endif
                let v235223 : System.Threading.Tasks.ValueTask = _run_target_args'_v235197 
                (* run_target_args'
                let v235236 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v235238 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v235236 = v235238 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v235242 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v235236 = v235242 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v235246 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v235236 = v235246 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v235250 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v235236 = v235250 
                #endif
#if FABLE_COMPILER_PYTHON
                let v235254 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v235236 = v235254 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v235258 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v235236 = v235258 
                #endif
#else
                let v235261 : (unit -> System.Threading.Tasks.Task) = v235223.AsTask
                let v235262 : System.Threading.Tasks.Task = v235261 ()
                let _run_target_args'_v235236 = v235262 
                #endif
                let v235263 : System.Threading.Tasks.Task = _run_target_args'_v235236 
                (* run_target_args'
                let v235276 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v235278 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v235276 = v235278 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v235282 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v235276 = v235282 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v235286 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v235276 = v235286 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v235289 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v235290 : Async<unit> = v235289 v235263
                let _run_target_args'_v235276 = v235290 
                #endif
#if FABLE_COMPILER_PYTHON
                let v235291 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v235292 : Async<unit> = v235291 v235263
                let _run_target_args'_v235276 = v235292 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v235293 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v235294 : Async<unit> = v235293 v235263
                let _run_target_args'_v235276 = v235294 
                #endif
#else
                let v235295 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v235296 : Async<unit> = v235295 v235263
                let _run_target_args'_v235276 = v235296 
                #endif
                let v235297 : Async<unit> = _run_target_args'_v235276 
                do! v235297 
                return true 
                (* indent
                ()
            indent *)
            with ex ->
                let v236120 : exn = ex
                let v236471 : unit = ()
                let v236472 : (unit -> unit) = closure5(v1, v236120)
                let v236473 : unit = (fun () -> v236472 (); v236471) ()
                return false 
                (* indent
                ()
            indent *)
            (* try_unit
            let v237535 : bool = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v270038 : Async<bool> = _let'_v202535 
    let _run_target_args'_v6 = v270038 
    #endif
    let v270039 : Async<bool> = _run_target_args'_v6 
    v270039
and method6 (v0 : string, v1 : int32) : Async<bool> =
    method7(v0, v1)
and closure4 (v0 : string) (v1 : int32) : Async<bool> =
    method6(v0, v1)
and closure3 () (v0 : string) : (int32 -> Async<bool>) =
    closure4(v0)
and closure15 () (v0 : bool) : US8 =
    US8_0(v0)
and method22 () : (bool -> US8) =
    closure15()
and closure16 () (v0 : exn) : US8 =
    US8_1(v0)
and method23 () : (exn -> US8) =
    closure16()
and closure14 () (v0 : Choice<bool, exn>) : US8 =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : US8 = null |> unbox<US8>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : US8 = null |> unbox<US8>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : US8 = null |> unbox<US8>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : US8 = null |> unbox<US8>
    let _run_target_args'_v5 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : US8 = null |> unbox<US8>
    let _run_target_args'_v5 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v26 : (bool -> US8) = method22()
    let v27 : (exn -> US8) = method23()
    let v28 : US8 = match v0 with Choice1Of2 x -> v26 x | Choice2Of2 x -> v27 x
    let _run_target_args'_v5 = v28 
    #endif
#else
    let v29 : (bool -> US8) = method22()
    let v30 : (exn -> US8) = method23()
    let v31 : US8 = match v0 with Choice1Of2 x -> v29 x | Choice2Of2 x -> v30 x
    let _run_target_args'_v5 = v31 
    #endif
    let v32 : US8 = _run_target_args'_v5 
    v32
and method25 (v0 : (Choice<bool, exn> -> US8), v1 : Async<Choice<bool, exn>>) : Async<US8> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US8> = null |> unbox<Async<US8>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US8> = null |> unbox<Async<US8>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US8> = null |> unbox<Async<US8>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let! v1 = v1 
            let v49 : Choice<bool, exn> = v1 
            let v50 : US8 = v0 v49
            return v50 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v77 : Async<US8> = _let'_v20 
    let _run_target_args'_v6 = v77 
    #endif
#if FABLE_COMPILER_PYTHON
    let v79 : unit = ()
    let _let'_v79 =
        async {
            let! v1 = v1 
            let v108 : Choice<bool, exn> = v1 
            let v109 : US8 = v0 v108
            return v109 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v136 : Async<US8> = _let'_v79 
    let _run_target_args'_v6 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v138 : unit = ()
    let _let'_v138 =
        async {
            let! v1 = v1 
            let v167 : Choice<bool, exn> = v1 
            let v168 : US8 = v0 v167
            return v168 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v195 : Async<US8> = _let'_v138 
    let _run_target_args'_v6 = v195 
    #endif
#else
    let v197 : unit = ()
    let _let'_v197 =
        async {
            let! v1 = v1 
            let v226 : Choice<bool, exn> = v1 
            let v227 : US8 = v0 v226
            return v227 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v254 : Async<US8> = _let'_v197 
    let _run_target_args'_v6 = v254 
    #endif
    let v255 : Async<US8> = _run_target_args'_v6 
    v255
and method24 (v0 : (Choice<bool, exn> -> US8), v1 : Async<Choice<bool, exn>>) : Async<US8> =
    method25(v0, v1)
and closure17 () (v0 : US8) : US9 =
    match v0 with
    | US8_0(v1) -> (* C1of2 *)
        US9_0(v1)
    | US8_1(v3) -> (* C2of2 *)
        US9_1(v3)
and method27 (v0 : (US8 -> US9), v1 : Async<US8>) : Async<US9> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US9> = null |> unbox<Async<US9>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US9> = null |> unbox<Async<US9>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US9> = null |> unbox<Async<US9>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let! v1 = v1 
            let v49 : US8 = v1 
            let v50 : US9 = v0 v49
            return v50 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v77 : Async<US9> = _let'_v20 
    let _run_target_args'_v6 = v77 
    #endif
#if FABLE_COMPILER_PYTHON
    let v79 : unit = ()
    let _let'_v79 =
        async {
            let! v1 = v1 
            let v108 : US8 = v1 
            let v109 : US9 = v0 v108
            return v109 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v136 : Async<US9> = _let'_v79 
    let _run_target_args'_v6 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v138 : unit = ()
    let _let'_v138 =
        async {
            let! v1 = v1 
            let v167 : US8 = v1 
            let v168 : US9 = v0 v167
            return v168 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v195 : Async<US9> = _let'_v138 
    let _run_target_args'_v6 = v195 
    #endif
#else
    let v197 : unit = ()
    let _let'_v197 =
        async {
            let! v1 = v1 
            let v226 : US8 = v1 
            let v227 : US9 = v0 v226
            return v227 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v254 : Async<US9> = _let'_v197 
    let _run_target_args'_v6 = v254 
    #endif
    let v255 : Async<US9> = _run_target_args'_v6 
    v255
and method26 (v0 : (US8 -> US9), v1 : Async<US8>) : Async<US9> =
    method27(v0, v1)
and method29 (v0 : int32) : string =
    let v1 : string = method14()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure7(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "timeout"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure7(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure7(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v64 : string = $"{v0}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure7(v2, v64)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v91 : unit = ()
    let v92 : (unit -> unit) = closure7(v2, v83)
    let v93 : unit = (fun () -> v92 (); v91) ()
    let v99 : string = v2.l0
    v99
and method28 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32) : string =
    let v9 : string = method29(v8)
    let v10 : int64 = v0.l0
    let v13 : string = " "
    let v14 : string = v6 + v13 
    let v18 : string = v14 + v7 
    let v23 : string = " #"
    let v24 : string = v18 + v23 
    let v28 : (int64 -> string) = _.ToString()
    let v29 : string = v28 v10
    let v33 : string = v24 + v29 
    let v37 : string = v33 + v13 
    let v42 : string = "async.run_with_timeout_async"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method17(v53)
and closure19 (v0 : int32) () : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure0()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
    let v58 : US0 = v44.l0
    let v59 : bool = v42.l0
    let v60 : bool = v59 = false
    let v63 : bool =
        if v60 then
            false
        else
            let v61 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v58
            let v62 : bool = 0 >= v61
            v62
    let v64 : bool = v63 = false
    let v298 : US6 =
        if v64 then
            US6_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method8(v104, v105, v106, v107, v108, v109)
            let v123 : string = method12()
            let v124 : string = method28(v104, v105, v106, v107, v108, v109, v122, v123, v0)
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
            let v270 : int32 = v264 |> int32 
            let v280 : string = ""
            let v281 : bool = v124 <> v280 
            let v285 : bool =
                if v281 then
                    let v284 : bool = v270 <= 1
                    v284
                else
                    false
            if v285 then
                v166.l0 <- v208
                ()
            else
                v166.l0 <- v280
                let v286 : string = "true; $0.into_iter().for_each(|x| { //"
                let v287 : bool = Fable.Core.RustInterop.emitRustExpr v262 v286 
                let v288 : string = "x"
                let v289 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v288 
                let v290 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v291 : bool = Fable.Core.RustInterop.emitRustExpr v289 v290 
                let v292 : string = $"true"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr () v292 
                let v294 : string = "true; }); //"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
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
            let v296 : (string -> unit) = v164.l0
            v296 v124
            US6_0(v163, v164, v165, v166, v167, v168)
    
    ()
and method30 () : string =
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
    let v137 : string = method13(v136)
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
and method32 (v0 : int32, v1 : string) : string =
    let v2 : string = method14()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure7(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "timeout"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure7(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure7(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v65 : string = $"{v0}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure7(v3, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = "; "
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure7(v3, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v102 : string = "ex"
    let v103 : string = $"{v102}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure7(v3, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v120 : string = $"{v44}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure7(v3, v120)
    let v130 : unit = (fun () -> v129 (); v128) ()
    let v137 : string = $"{v1}"
    let v145 : unit = ()
    let v146 : (unit -> unit) = closure7(v3, v137)
    let v147 : unit = (fun () -> v146 (); v145) ()
    let v155 : string = " }"
    let v156 : string = $"{v155}"
    let v164 : unit = ()
    let v165 : (unit -> unit) = closure7(v3, v156)
    let v166 : unit = (fun () -> v165 (); v164) ()
    let v172 : string = v3.l0
    v172
and method31 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method32(v8, v9)
    let v11 : int64 = v0.l0
    let v14 : string = " "
    let v15 : string = v6 + v14 
    let v19 : string = v15 + v7 
    let v24 : string = " #"
    let v25 : string = v19 + v24 
    let v29 : (int64 -> string) = _.ToString()
    let v30 : string = v29 v11
    let v34 : string = v25 + v30 
    let v38 : string = v34 + v14 
    let v43 : string = "async.run_with_timeout_async**"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method17(v54)
and closure20 (v0 : int32, v1 : exn) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure0()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US0 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 4 >= v62
            v63
    let v65 : bool = v64 = false
    let v338 : US6 =
        if v65 then
            US6_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method8(v105, v106, v107, v108, v109, v110)
            let v124 : string = method30()
            (* run_target_args'
            let v129 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v131 : string = $"%A{v1}"
            let _run_target_args'_v129 = v131 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v135 : string = $"%A{v1}"
            let _run_target_args'_v129 = v135 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v139 : string = $"%A{v1}"
            let _run_target_args'_v129 = v139 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v143 : string = $"%A{v1}"
            let _run_target_args'_v129 = v143 
            #endif
#if FABLE_COMPILER_PYTHON
            let v147 : string = $"%A{v1}"
            let _run_target_args'_v129 = v147 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v151 : string = $"%A{v1}"
            let _run_target_args'_v129 = v151 
            #endif
#else
            let v154 : string = $"{v1.GetType ()}: {v1.Message}"
            let _run_target_args'_v129 = v154 
            #endif
            let v155 : string = _run_target_args'_v129 
            let v164 : string = method31(v105, v106, v107, v108, v109, v110, v123, v124, v0, v155)
            let v179 : unit = ()
            let v180 : unit = (fun () -> v17 (); v179) ()
            let struct (v203 : Mut0, v204 : Mut1, v205 : Mut2, v206 : Mut3, v207 : Mut4, v208 : int64 option) = TraceState.trace_state.Value
            let v223 : unit = ()
            let v224 : (unit -> unit) = closure8(v203)
            let v225 : unit = (fun () -> v224 (); v223) ()
            let v228 : (string -> unit) = closure9()
            (* run_target_args'
            let v229 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v230 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v164 v230 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v231 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v164 v231 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v232 : string = v206.l0
            let v233 : bool = v232 = ""
            let v248 : string =
                if v233 then
                    v164
                else
                    let v234 : bool = v164 = ""
                    if v234 then
                        let v235 : string = v206.l0
                        v235
                    else
                        let v236 : string = v206.l0
                        let v239 : string = "\n"
                        let v240 : string = v236 + v239 
                        let v244 : string = v240 + v164 
                        v244
            (* run_target_args'
            let v253 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v254 : string = "&*$0"
            let v255 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v254 
            let _run_target_args'_v253 = v255 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v256 : string = "&*$0"
            let v257 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v256 
            let _run_target_args'_v253 = v257 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v258 : string = "&*$0"
            let v259 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v258 
            let _run_target_args'_v253 = v259 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v261 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v261 
            #endif
#if FABLE_COMPILER_PYTHON
            let v265 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v265 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v269 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v269 
            #endif
#else
            let v273 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v273 
            #endif
            let v276 : Ref<Str> = _run_target_args'_v253 
            let v285 : string = $"$0.chars()"
            let v286 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v276 v285 
            let v287 : string = "$0"
            let v288 : _ = Fable.Core.RustInterop.emitRustExpr v286 v287 
            let v289 : string = "$0.collect::<Vec<_>>()"
            let v290 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v288 v289 
            let v291 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v292 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v290 v291 
            let v293 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v294 : bool = Fable.Core.RustInterop.emitRustExpr v292 v293 
            let v295 : string = "x"
            let v296 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v295 
            let v297 : string = "String::from_iter($0)"
            let v298 : std_string_String = Fable.Core.RustInterop.emitRustExpr v296 v297 
            let v299 : string = "true; $0 }).collect::<Vec<_>>()"
            let v300 : bool = Fable.Core.RustInterop.emitRustExpr v298 v299 
            let v301 : string = "_vec_map"
            let v302 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v301 
            let v303 : string = "$0.len()"
            let v304 : unativeint = Fable.Core.RustInterop.emitRustExpr v302 v303 
            let v310 : int32 = v304 |> int32 
            let v320 : string = ""
            let v321 : bool = v164 <> v320 
            let v325 : bool =
                if v321 then
                    let v324 : bool = v310 <= 1
                    v324
                else
                    false
            if v325 then
                v206.l0 <- v248
                ()
            else
                v206.l0 <- v320
                let v326 : string = "true; $0.into_iter().for_each(|x| { //"
                let v327 : bool = Fable.Core.RustInterop.emitRustExpr v302 v326 
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
            v228 v164
            #endif
#if FABLE_COMPILER_PYTHON
            v228 v164
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v228 v164
            #endif
#else
            v228 v164
            #endif
            // run_target_args' is_unit
            let v336 : (string -> unit) = v204.l0
            v336 v164
            US6_0(v203, v204, v205, v206, v207, v208)
    
    ()
and closure18 (v0 : int32) (v1 : US9) : US7 =
    match v1 with
    | US9_1(v4) -> (* Error *)
        let v6 : string = $"%A{v4}"
        let v11 : string = "System.TimeoutException"
        let v12 : bool = v6.Contains v11 
        if v12 then
            let v326 : unit = ()
            let v327 : (unit -> unit) = closure19(v0)
            let v328 : unit = (fun () -> v327 (); v326) ()
            US7_1
        else
            let v994 : unit = ()
            let v995 : (unit -> unit) = closure20(v0, v4)
            let v996 : unit = (fun () -> v995 (); v994) ()
            US7_1
    | US9_0(v2) -> (* Ok *)
        US7_0(v2)
and method34 (v0 : (US9 -> US7), v1 : Async<US9>) : Async<US7> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US7> = null |> unbox<Async<US7>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US7> = null |> unbox<Async<US7>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US7> = null |> unbox<Async<US7>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let! v1 = v1 
            let v49 : US9 = v1 
            let v50 : US7 = v0 v49
            return v50 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v77 : Async<US7> = _let'_v20 
    let _run_target_args'_v6 = v77 
    #endif
#if FABLE_COMPILER_PYTHON
    let v79 : unit = ()
    let _let'_v79 =
        async {
            let! v1 = v1 
            let v108 : US9 = v1 
            let v109 : US7 = v0 v108
            return v109 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v136 : Async<US7> = _let'_v79 
    let _run_target_args'_v6 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v138 : unit = ()
    let _let'_v138 =
        async {
            let! v1 = v1 
            let v167 : US9 = v1 
            let v168 : US7 = v0 v167
            return v168 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v195 : Async<US7> = _let'_v138 
    let _run_target_args'_v6 = v195 
    #endif
#else
    let v197 : unit = ()
    let _let'_v197 =
        async {
            let! v1 = v1 
            let v226 : US9 = v1 
            let v227 : US7 = v0 v226
            return v227 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v254 : Async<US7> = _let'_v197 
    let _run_target_args'_v6 = v254 
    #endif
    let v255 : Async<US7> = _run_target_args'_v6 
    v255
and method33 (v0 : (US9 -> US7), v1 : Async<US9>) : Async<US7> =
    method34(v0, v1)
and method21 (v0 : Async<bool>, v1 : int32) : Async<US7> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US7> = null |> unbox<Async<US7>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US7> = null |> unbox<Async<US7>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US7> = null |> unbox<Async<US7>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            (* run_target_args'
            let v950 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v952 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v950 = v952 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v956 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v950 = v956 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v960 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v950 = v960 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v963 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v950 = v963 
            #endif
#if FABLE_COMPILER_PYTHON
            let v964 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v950 = v964 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v965 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v950 = v965 
            #endif
#else
            let v966 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v950 = v966 
            #endif
            let v967 : Async<Async<bool>> = _run_target_args'_v950 
            let! v967 = v967 
            let v976 : Async<bool> = v967 
            (* run_target_args'
            let v981 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v983 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v981 = v983 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v987 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v981 = v987 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v991 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v981 = v991 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v994 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v995 : Async<Choice<bool, exn>> = v994 v976
            let _run_target_args'_v981 = v995 
            #endif
#if FABLE_COMPILER_PYTHON
            let v996 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v997 : Async<Choice<bool, exn>> = v996 v976
            let _run_target_args'_v981 = v997 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v998 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v999 : Async<Choice<bool, exn>> = v998 v976
            let _run_target_args'_v981 = v999 
            #endif
#else
            let v1000 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v1001 : Async<Choice<bool, exn>> = v1000 v976
            let _run_target_args'_v981 = v1001 
            #endif
            let v1002 : Async<Choice<bool, exn>> = _run_target_args'_v981 
            let v1011 : (Choice<bool, exn> -> US8) = closure14()
            let v1012 : Async<US8> = method24(v1011, v1002)
            let v1013 : (US8 -> US9) = closure17()
            let v1014 : Async<US9> = method26(v1013, v1012)
            let v1015 : (US9 -> US7) = closure18(v1)
            let v1016 : Async<US7> = method33(v1015, v1014)
            return! v1016 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1940 : Async<US7> = _let'_v20 
    let _run_target_args'_v6 = v1940 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1942 : unit = ()
    let _let'_v1942 =
        async {
            (* run_target_args'
            let v2872 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2874 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v2872 = v2874 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2878 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v2872 = v2878 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2882 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v2872 = v2882 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2885 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2872 = v2885 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2886 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2872 = v2886 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2887 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2872 = v2887 
            #endif
#else
            let v2888 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2872 = v2888 
            #endif
            let v2889 : Async<Async<bool>> = _run_target_args'_v2872 
            let! v2889 = v2889 
            let v2898 : Async<bool> = v2889 
            (* run_target_args'
            let v2903 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2905 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v2903 = v2905 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2909 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v2903 = v2909 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2913 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v2903 = v2913 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2916 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2917 : Async<Choice<bool, exn>> = v2916 v2898
            let _run_target_args'_v2903 = v2917 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2918 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2919 : Async<Choice<bool, exn>> = v2918 v2898
            let _run_target_args'_v2903 = v2919 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2920 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2921 : Async<Choice<bool, exn>> = v2920 v2898
            let _run_target_args'_v2903 = v2921 
            #endif
#else
            let v2922 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v2923 : Async<Choice<bool, exn>> = v2922 v2898
            let _run_target_args'_v2903 = v2923 
            #endif
            let v2924 : Async<Choice<bool, exn>> = _run_target_args'_v2903 
            let v2933 : (Choice<bool, exn> -> US8) = closure14()
            let v2934 : Async<US8> = method24(v2933, v2924)
            let v2935 : (US8 -> US9) = closure17()
            let v2936 : Async<US9> = method26(v2935, v2934)
            let v2937 : (US9 -> US7) = closure18(v1)
            let v2938 : Async<US7> = method33(v2937, v2936)
            return! v2938 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3862 : Async<US7> = _let'_v1942 
    let _run_target_args'_v6 = v3862 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3864 : unit = ()
    let _let'_v3864 =
        async {
            (* run_target_args'
            let v4794 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4796 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v4794 = v4796 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4800 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v4794 = v4800 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4804 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v4794 = v4804 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4807 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4794 = v4807 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4808 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4794 = v4808 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4809 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4794 = v4809 
            #endif
#else
            let v4810 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4794 = v4810 
            #endif
            let v4811 : Async<Async<bool>> = _run_target_args'_v4794 
            let! v4811 = v4811 
            let v4820 : Async<bool> = v4811 
            (* run_target_args'
            let v4825 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4827 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v4825 = v4827 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4831 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v4825 = v4831 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4835 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v4825 = v4835 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4838 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4839 : Async<Choice<bool, exn>> = v4838 v4820
            let _run_target_args'_v4825 = v4839 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4840 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4841 : Async<Choice<bool, exn>> = v4840 v4820
            let _run_target_args'_v4825 = v4841 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4842 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4843 : Async<Choice<bool, exn>> = v4842 v4820
            let _run_target_args'_v4825 = v4843 
            #endif
#else
            let v4844 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v4845 : Async<Choice<bool, exn>> = v4844 v4820
            let _run_target_args'_v4825 = v4845 
            #endif
            let v4846 : Async<Choice<bool, exn>> = _run_target_args'_v4825 
            let v4855 : (Choice<bool, exn> -> US8) = closure14()
            let v4856 : Async<US8> = method24(v4855, v4846)
            let v4857 : (US8 -> US9) = closure17()
            let v4858 : Async<US9> = method26(v4857, v4856)
            let v4859 : (US9 -> US7) = closure18(v1)
            let v4860 : Async<US7> = method33(v4859, v4858)
            return! v4860 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5784 : Async<US7> = _let'_v3864 
    let _run_target_args'_v6 = v5784 
    #endif
#else
    let v5786 : unit = ()
    let _let'_v5786 =
        async {
            (* run_target_args'
            let v6716 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6718 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v6716 = v6718 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6722 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v6716 = v6722 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6726 : Async<Async<bool>> = null |> unbox<Async<Async<bool>>>
            let _run_target_args'_v6716 = v6726 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6729 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6716 = v6729 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6730 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6716 = v6730 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6731 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6716 = v6731 
            #endif
#else
            let v6732 : Async<Async<bool>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6716 = v6732 
            #endif
            let v6733 : Async<Async<bool>> = _run_target_args'_v6716 
            let! v6733 = v6733 
            let v6742 : Async<bool> = v6733 
            (* run_target_args'
            let v6747 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6749 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v6747 = v6749 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6753 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v6747 = v6753 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6757 : Async<Choice<bool, exn>> = null |> unbox<Async<Choice<bool, exn>>>
            let _run_target_args'_v6747 = v6757 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6760 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v6761 : Async<Choice<bool, exn>> = v6760 v6742
            let _run_target_args'_v6747 = v6761 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6762 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v6763 : Async<Choice<bool, exn>> = v6762 v6742
            let _run_target_args'_v6747 = v6763 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6764 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v6765 : Async<Choice<bool, exn>> = v6764 v6742
            let _run_target_args'_v6747 = v6765 
            #endif
#else
            let v6766 : (Async<bool> -> Async<Choice<bool, exn>>) = Async.Catch
            let v6767 : Async<Choice<bool, exn>> = v6766 v6742
            let _run_target_args'_v6747 = v6767 
            #endif
            let v6768 : Async<Choice<bool, exn>> = _run_target_args'_v6747 
            let v6777 : (Choice<bool, exn> -> US8) = closure14()
            let v6778 : Async<US8> = method24(v6777, v6768)
            let v6779 : (US8 -> US9) = closure17()
            let v6780 : Async<US9> = method26(v6779, v6778)
            let v6781 : (US9 -> US7) = closure18(v1)
            let v6782 : Async<US7> = method33(v6781, v6780)
            return! v6782 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7706 : Async<US7> = _let'_v5786 
    let _run_target_args'_v6 = v7706 
    #endif
    let v7707 : Async<US7> = _run_target_args'_v6 
    v7707
and method20 (v0 : int32, v1 : Async<bool>) : Async<US7> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US7> = method21(v1, v0)
    let _run_target_args'_v6 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : Async<US7> = method21(v1, v0)
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US7> = method21(v1, v0)
    let _run_target_args'_v6 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : Async<US7> = method21(v1, v0)
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : Async<US7> = method21(v1, v0)
    let _run_target_args'_v6 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : Async<US7> = method21(v1, v0)
    let _run_target_args'_v6 = v12 
    #endif
#else
    let v13 : Async<US7> = method21(v1, v0)
    let _run_target_args'_v6 = v13 
    #endif
    let v14 : Async<US7> = _run_target_args'_v6 
    v14
and method19 (v0 : int32, v1 : string, v2 : int32) : Async<bool> =
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
            let v103 : Async<US7> = method20(v0, v102)
            let! v103 = v103 
            let v104 : US7 = v103 
            let v107 : bool =
                match v104 with
                | US7_1 -> (* None *)
                    false
                | US7_0(v105) -> (* Some *)
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
            let v270 : Async<US7> = method20(v0, v269)
            let! v270 = v270 
            let v271 : US7 = v270 
            let v274 : bool =
                match v271 with
                | US7_1 -> (* None *)
                    false
                | US7_0(v272) -> (* Some *)
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
            let v437 : Async<US7> = method20(v0, v436)
            let! v437 = v437 
            let v438 : US7 = v437 
            let v441 : bool =
                match v438 with
                | US7_1 -> (* None *)
                    false
                | US7_0(v439) -> (* Some *)
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
            let v604 : Async<US7> = method20(v0, v603)
            let! v604 = v604 
            let v605 : US7 = v604 
            let v608 : bool =
                match v605 with
                | US7_1 -> (* None *)
                    false
                | US7_0(v606) -> (* Some *)
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
and method18 (v0 : int32, v1 : string, v2 : int32) : Async<bool> =
    method19(v0, v1, v2)
and closure13 (v0 : int32, v1 : string) (v2 : int32) : Async<bool> =
    method18(v0, v1, v2)
and closure12 (v0 : int32) (v1 : string) : (int32 -> Async<bool>) =
    closure13(v0, v1)
and closure11 () (v0 : int32) : (string -> (int32 -> Async<bool>)) =
    closure12(v0)
and closure25 () (v0 : int32) : US10 =
    US10_0(v0)
and method38 () : (int32 -> US10) =
    closure25()
and method40 (v0 : int32, v1 : int64, v2 : int32 option, v3 : bool) : string =
    let v4 : string = method14()
    let v5 : Mut3 = {l0 = v4} : Mut3
    let v8 : string = "{ "
    let v9 : string = $"{v8}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure7(v5, v9)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v27 : string = "port"
    let v28 : string = $"{v27}"
    let v36 : unit = ()
    let v37 : (unit -> unit) = closure7(v5, v28)
    let v38 : unit = (fun () -> v37 (); v36) ()
    let v46 : string = " = "
    let v47 : string = $"{v46}"
    let v55 : unit = ()
    let v56 : (unit -> unit) = closure7(v5, v47)
    let v57 : unit = (fun () -> v56 (); v55) ()
    let v67 : string = $"{v0}"
    let v75 : unit = ()
    let v76 : (unit -> unit) = closure7(v5, v67)
    let v77 : unit = (fun () -> v76 (); v75) ()
    let v85 : string = "; "
    let v86 : string = $"{v85}"
    let v94 : unit = ()
    let v95 : (unit -> unit) = closure7(v5, v86)
    let v96 : unit = (fun () -> v95 (); v94) ()
    let v104 : string = "retry"
    let v105 : string = $"{v104}"
    let v113 : unit = ()
    let v114 : (unit -> unit) = closure7(v5, v105)
    let v115 : unit = (fun () -> v114 (); v113) ()
    let v122 : string = $"{v46}"
    let v130 : unit = ()
    let v131 : (unit -> unit) = closure7(v5, v122)
    let v132 : unit = (fun () -> v131 (); v130) ()
    let v142 : string = $"{v1}"
    let v150 : unit = ()
    let v151 : (unit -> unit) = closure7(v5, v142)
    let v152 : unit = (fun () -> v151 (); v150) ()
    let v159 : string = $"{v85}"
    let v167 : unit = ()
    let v168 : (unit -> unit) = closure7(v5, v159)
    let v169 : unit = (fun () -> v168 (); v167) ()
    let v177 : string = "timeout"
    let v178 : string = $"{v177}"
    let v186 : unit = ()
    let v187 : (unit -> unit) = closure7(v5, v178)
    let v188 : unit = (fun () -> v187 (); v186) ()
    let v195 : string = $"{v46}"
    let v203 : unit = ()
    let v204 : (unit -> unit) = closure7(v5, v195)
    let v205 : unit = (fun () -> v204 (); v203) ()
    (* run_target_args'
    let v215 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v216 : string = "format!(\"{:#?}\", $0)"
    let v217 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v216 
    let v218 : string = "fable_library_rust::String_::fromString($0)"
    let v219 : string = Fable.Core.RustInterop.emitRustExpr v217 v218 
    let _run_target_args'_v215 = v219 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v220 : string = "format!(\"{:#?}\", $0)"
    let v221 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v220 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v221 v222 
    let _run_target_args'_v215 = v223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v224 : string = "format!(\"{:#?}\", $0)"
    let v225 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v224 
    let v226 : string = "fable_library_rust::String_::fromString($0)"
    let v227 : string = Fable.Core.RustInterop.emitRustExpr v225 v226 
    let _run_target_args'_v215 = v227 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v229 : string = $"%A{v2}"
    let _run_target_args'_v215 = v229 
    #endif
#if FABLE_COMPILER_PYTHON
    let v233 : string = $"%A{v2}"
    let _run_target_args'_v215 = v233 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v237 : string = $"%A{v2}"
    let _run_target_args'_v215 = v237 
    #endif
#else
    let v241 : string = $"%A{v2}"
    let _run_target_args'_v215 = v241 
    #endif
    let v244 : string = _run_target_args'_v215 
    let v254 : string = $"{v244}"
    let v262 : unit = ()
    let v263 : (unit -> unit) = closure7(v5, v254)
    let v264 : unit = (fun () -> v263 (); v262) ()
    let v271 : string = $"{v85}"
    let v279 : unit = ()
    let v280 : (unit -> unit) = closure7(v5, v271)
    let v281 : unit = (fun () -> v280 (); v279) ()
    let v289 : string = "status"
    let v290 : string = $"{v289}"
    let v298 : unit = ()
    let v299 : (unit -> unit) = closure7(v5, v290)
    let v300 : unit = (fun () -> v299 (); v298) ()
    let v307 : string = $"{v46}"
    let v315 : unit = ()
    let v316 : (unit -> unit) = closure7(v5, v307)
    let v317 : unit = (fun () -> v316 (); v315) ()
    let v325 : string =
        if v3 then
            let v323 : string = "true"
            v323
        else
            let v324 : string = "false"
            v324
    let v327 : string = $"{v325}"
    let v335 : unit = ()
    let v336 : (unit -> unit) = closure7(v5, v327)
    let v337 : unit = (fun () -> v336 (); v335) ()
    let v345 : string = " }"
    let v346 : string = $"{v345}"
    let v354 : unit = ()
    let v355 : (unit -> unit) = closure7(v5, v346)
    let v356 : unit = (fun () -> v355 (); v354) ()
    let v362 : string = v5.l0
    v362
and method39 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : int64, v10 : int32 option, v11 : bool) : string =
    let v12 : string = method40(v8, v9, v10, v11)
    let v13 : int64 = v0.l0
    let v16 : string = " "
    let v17 : string = v6 + v16 
    let v21 : string = v17 + v7 
    let v26 : string = " #"
    let v27 : string = v21 + v26 
    let v31 : (int64 -> string) = _.ToString()
    let v32 : string = v31 v13
    let v36 : string = v27 + v32 
    let v40 : string = v36 + v16 
    let v45 : string = "networking.wait_for_port_access"
    let v46 : string = v40 + v45 
    let v51 : string = " / "
    let v52 : string = v46 + v51 
    let v56 : string = v52 + v12 
    method17(v56)
and closure26 (v0 : int32 option, v1 : bool, v2 : int32, v3 : int64) () : unit =
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure0()
    let v20 : unit = (fun () -> v19 (); v18) ()
    let struct (v43 : Mut0, v44 : Mut1, v45 : Mut2, v46 : Mut3, v47 : Mut4, v48 : int64 option) = TraceState.trace_state.Value
    let v61 : US0 = v47.l0
    let v62 : bool = v45.l0
    let v63 : bool = v62 = false
    let v66 : bool =
        if v63 then
            false
        else
            let v64 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v61
            let v65 : bool = 0 >= v64
            v65
    let v67 : bool = v66 = false
    let v301 : US6 =
        if v67 then
            US6_1
        else
            let v83 : unit = ()
            let v84 : unit = (fun () -> v19 (); v83) ()
            let struct (v107 : Mut0, v108 : Mut1, v109 : Mut2, v110 : Mut3, v111 : Mut4, v112 : int64 option) = TraceState.trace_state.Value
            let v125 : string = method8(v107, v108, v109, v110, v111, v112)
            let v126 : string = method12()
            let v127 : string = method39(v107, v108, v109, v110, v111, v112, v125, v126, v2, v3, v0, v1)
            let v142 : unit = ()
            let v143 : unit = (fun () -> v19 (); v142) ()
            let struct (v166 : Mut0, v167 : Mut1, v168 : Mut2, v169 : Mut3, v170 : Mut4, v171 : int64 option) = TraceState.trace_state.Value
            let v186 : unit = ()
            let v187 : (unit -> unit) = closure8(v166)
            let v188 : unit = (fun () -> v187 (); v186) ()
            let v191 : (string -> unit) = closure9()
            (* run_target_args'
            let v192 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v193 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v127 v193 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v194 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v127 v194 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v195 : string = v169.l0
            let v196 : bool = v195 = ""
            let v211 : string =
                if v196 then
                    v127
                else
                    let v197 : bool = v127 = ""
                    if v197 then
                        let v198 : string = v169.l0
                        v198
                    else
                        let v199 : string = v169.l0
                        let v202 : string = "\n"
                        let v203 : string = v199 + v202 
                        let v207 : string = v203 + v127 
                        v207
            (* run_target_args'
            let v216 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v211 v217 
            let _run_target_args'_v216 = v218 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v211 v219 
            let _run_target_args'_v216 = v220 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v221 : string = "&*$0"
            let v222 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v211 v221 
            let _run_target_args'_v216 = v222 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v224 : Ref<Str> = v211 |> unbox<Ref<Str>>
            let _run_target_args'_v216 = v224 
            #endif
#if FABLE_COMPILER_PYTHON
            let v228 : Ref<Str> = v211 |> unbox<Ref<Str>>
            let _run_target_args'_v216 = v228 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v232 : Ref<Str> = v211 |> unbox<Ref<Str>>
            let _run_target_args'_v216 = v232 
            #endif
#else
            let v236 : Ref<Str> = v211 |> unbox<Ref<Str>>
            let _run_target_args'_v216 = v236 
            #endif
            let v239 : Ref<Str> = _run_target_args'_v216 
            let v248 : string = $"$0.chars()"
            let v249 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v239 v248 
            let v250 : string = "$0"
            let v251 : _ = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.collect::<Vec<_>>()"
            let v253 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v255 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v257 : bool = Fable.Core.RustInterop.emitRustExpr v255 v256 
            let v258 : string = "x"
            let v259 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v258 
            let v260 : string = "String::from_iter($0)"
            let v261 : std_string_String = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "true; $0 }).collect::<Vec<_>>()"
            let v263 : bool = Fable.Core.RustInterop.emitRustExpr v261 v262 
            let v264 : string = "_vec_map"
            let v265 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v264 
            let v266 : string = "$0.len()"
            let v267 : unativeint = Fable.Core.RustInterop.emitRustExpr v265 v266 
            let v273 : int32 = v267 |> int32 
            let v283 : string = ""
            let v284 : bool = v127 <> v283 
            let v288 : bool =
                if v284 then
                    let v287 : bool = v273 <= 1
                    v287
                else
                    false
            if v288 then
                v169.l0 <- v211
                ()
            else
                v169.l0 <- v283
                let v289 : string = "true; $0.into_iter().for_each(|x| { //"
                let v290 : bool = Fable.Core.RustInterop.emitRustExpr v265 v289 
                let v291 : string = "x"
                let v292 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v291 
                let v293 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr v292 v293 
                let v295 : string = $"true"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                let v297 : string = "true; }); //"
                let v298 : bool = Fable.Core.RustInterop.emitRustExpr () v297 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v191 v127
            #endif
#if FABLE_COMPILER_PYTHON
            v191 v127
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v191 v127
            #endif
#else
            v191 v127
            #endif
            // run_target_args' is_unit
            let v299 : (string -> unit) = v167.l0
            v299 v127
            US6_0(v166, v167, v168, v169, v170, v171)
    
    ()
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
            let v8994 : (int32 -> US10) = method38()
            let v8995 : US10 option = v0 |> Option.map v8994 
            let v9015 : US10 = US10_1
            let v9016 : US10 = v8995 |> Option.defaultValue v9015 
            let v9024 : Async<bool> =
                match v9016 with
                | US10_1 -> (* None *)
                    method6(v2, v3)
                | US10_0(v9021) -> (* Some *)
                    method18(v9021, v2, v3)
            let! v9024 = v9024 
            let v9025 : bool = v9024 
            let v9026 : bool = v9025 = v1
            if v9026 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v9027 : int64 = v4 % 100L
                let v9028 : bool = v9027 = 0L
                if v9028 then
                    let v9340 : unit = ()
                    let v9341 : (unit -> unit) = closure26(v0, v1, v3, v4)
                    let v9342 : unit = (fun () -> v9341 (); v9340) ()
                    ()
                (* run_target_args'
                let v9661 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9662 : (int32 -> Async<unit>) = Async.Sleep
                let v9663 : Async<unit> = v9662 10
                let _run_target_args'_v9661 = v9663 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9664 : (int32 -> Async<unit>) = Async.Sleep
                let v9665 : Async<unit> = v9664 10
                let _run_target_args'_v9661 = v9665 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9666 : (int32 -> Async<unit>) = Async.Sleep
                let v9667 : Async<unit> = v9666 10
                let _run_target_args'_v9661 = v9667 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9668 : (int32 -> Async<unit>) = Async.Sleep
                let v9669 : Async<unit> = v9668 10
                let _run_target_args'_v9661 = v9669 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9670 : (int32 -> Async<unit>) = Async.Sleep
                let v9671 : Async<unit> = v9670 10
                let _run_target_args'_v9661 = v9671 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9672 : (int32 -> Async<unit>) = Async.Sleep
                let v9673 : Async<unit> = v9672 10
                let _run_target_args'_v9661 = v9673 
                #endif
#else
                let v9674 : (int32 -> Async<unit>) = Async.Sleep
                let v9675 : Async<unit> = v9674 10
                let _run_target_args'_v9661 = v9675 
                #endif
                let v9676 : Async<unit> = _run_target_args'_v9661 
                do! v9676 
                let v9682 : int64 = v4 + 1L
                let v9683 : Async<int64> = method36(v0, v1, v2, v3, v9682)
                return! v9683 
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
    let v18656 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v18656 
    #endif
#if FABLE_COMPILER_PYTHON
    let v18658 : unit = ()
    let _let'_v18658 =
        async {
            let v27629 : (int32 -> US10) = method38()
            let v27630 : US10 option = v0 |> Option.map v27629 
            let v27650 : US10 = US10_1
            let v27651 : US10 = v27630 |> Option.defaultValue v27650 
            let v27659 : Async<bool> =
                match v27651 with
                | US10_1 -> (* None *)
                    method6(v2, v3)
                | US10_0(v27656) -> (* Some *)
                    method18(v27656, v2, v3)
            let! v27659 = v27659 
            let v27660 : bool = v27659 
            let v27661 : bool = v27660 = v1
            if v27661 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v27662 : int64 = v4 % 100L
                let v27663 : bool = v27662 = 0L
                if v27663 then
                    let v27975 : unit = ()
                    let v27976 : (unit -> unit) = closure26(v0, v1, v3, v4)
                    let v27977 : unit = (fun () -> v27976 (); v27975) ()
                    ()
                (* run_target_args'
                let v28296 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v28297 : (int32 -> Async<unit>) = Async.Sleep
                let v28298 : Async<unit> = v28297 10
                let _run_target_args'_v28296 = v28298 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v28299 : (int32 -> Async<unit>) = Async.Sleep
                let v28300 : Async<unit> = v28299 10
                let _run_target_args'_v28296 = v28300 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v28301 : (int32 -> Async<unit>) = Async.Sleep
                let v28302 : Async<unit> = v28301 10
                let _run_target_args'_v28296 = v28302 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v28303 : (int32 -> Async<unit>) = Async.Sleep
                let v28304 : Async<unit> = v28303 10
                let _run_target_args'_v28296 = v28304 
                #endif
#if FABLE_COMPILER_PYTHON
                let v28305 : (int32 -> Async<unit>) = Async.Sleep
                let v28306 : Async<unit> = v28305 10
                let _run_target_args'_v28296 = v28306 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v28307 : (int32 -> Async<unit>) = Async.Sleep
                let v28308 : Async<unit> = v28307 10
                let _run_target_args'_v28296 = v28308 
                #endif
#else
                let v28309 : (int32 -> Async<unit>) = Async.Sleep
                let v28310 : Async<unit> = v28309 10
                let _run_target_args'_v28296 = v28310 
                #endif
                let v28311 : Async<unit> = _run_target_args'_v28296 
                do! v28311 
                let v28317 : int64 = v4 + 1L
                let v28318 : Async<int64> = method36(v0, v1, v2, v3, v28317)
                return! v28318 
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
    let v37291 : Async<int64> = _let'_v18658 
    let _run_target_args'_v9 = v37291 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v37293 : unit = ()
    let _let'_v37293 =
        async {
            let v46264 : (int32 -> US10) = method38()
            let v46265 : US10 option = v0 |> Option.map v46264 
            let v46285 : US10 = US10_1
            let v46286 : US10 = v46265 |> Option.defaultValue v46285 
            let v46294 : Async<bool> =
                match v46286 with
                | US10_1 -> (* None *)
                    method6(v2, v3)
                | US10_0(v46291) -> (* Some *)
                    method18(v46291, v2, v3)
            let! v46294 = v46294 
            let v46295 : bool = v46294 
            let v46296 : bool = v46295 = v1
            if v46296 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v46297 : int64 = v4 % 100L
                let v46298 : bool = v46297 = 0L
                if v46298 then
                    let v46610 : unit = ()
                    let v46611 : (unit -> unit) = closure26(v0, v1, v3, v4)
                    let v46612 : unit = (fun () -> v46611 (); v46610) ()
                    ()
                (* run_target_args'
                let v46931 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v46932 : (int32 -> Async<unit>) = Async.Sleep
                let v46933 : Async<unit> = v46932 10
                let _run_target_args'_v46931 = v46933 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v46934 : (int32 -> Async<unit>) = Async.Sleep
                let v46935 : Async<unit> = v46934 10
                let _run_target_args'_v46931 = v46935 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v46936 : (int32 -> Async<unit>) = Async.Sleep
                let v46937 : Async<unit> = v46936 10
                let _run_target_args'_v46931 = v46937 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v46938 : (int32 -> Async<unit>) = Async.Sleep
                let v46939 : Async<unit> = v46938 10
                let _run_target_args'_v46931 = v46939 
                #endif
#if FABLE_COMPILER_PYTHON
                let v46940 : (int32 -> Async<unit>) = Async.Sleep
                let v46941 : Async<unit> = v46940 10
                let _run_target_args'_v46931 = v46941 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v46942 : (int32 -> Async<unit>) = Async.Sleep
                let v46943 : Async<unit> = v46942 10
                let _run_target_args'_v46931 = v46943 
                #endif
#else
                let v46944 : (int32 -> Async<unit>) = Async.Sleep
                let v46945 : Async<unit> = v46944 10
                let _run_target_args'_v46931 = v46945 
                #endif
                let v46946 : Async<unit> = _run_target_args'_v46931 
                do! v46946 
                let v46952 : int64 = v4 + 1L
                let v46953 : Async<int64> = method36(v0, v1, v2, v3, v46952)
                return! v46953 
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
    let v55926 : Async<int64> = _let'_v37293 
    let _run_target_args'_v9 = v55926 
    #endif
#else
    let v55928 : unit = ()
    let _let'_v55928 =
        async {
            let v64899 : (int32 -> US10) = method38()
            let v64900 : US10 option = v0 |> Option.map v64899 
            let v64920 : US10 = US10_1
            let v64921 : US10 = v64900 |> Option.defaultValue v64920 
            let v64929 : Async<bool> =
                match v64921 with
                | US10_1 -> (* None *)
                    method6(v2, v3)
                | US10_0(v64926) -> (* Some *)
                    method18(v64926, v2, v3)
            let! v64929 = v64929 
            let v64930 : bool = v64929 
            let v64931 : bool = v64930 = v1
            if v64931 then
                return v4 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v64932 : int64 = v4 % 100L
                let v64933 : bool = v64932 = 0L
                if v64933 then
                    let v65245 : unit = ()
                    let v65246 : (unit -> unit) = closure26(v0, v1, v3, v4)
                    let v65247 : unit = (fun () -> v65246 (); v65245) ()
                    ()
                (* run_target_args'
                let v65566 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v65567 : (int32 -> Async<unit>) = Async.Sleep
                let v65568 : Async<unit> = v65567 10
                let _run_target_args'_v65566 = v65568 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v65569 : (int32 -> Async<unit>) = Async.Sleep
                let v65570 : Async<unit> = v65569 10
                let _run_target_args'_v65566 = v65570 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v65571 : (int32 -> Async<unit>) = Async.Sleep
                let v65572 : Async<unit> = v65571 10
                let _run_target_args'_v65566 = v65572 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v65573 : (int32 -> Async<unit>) = Async.Sleep
                let v65574 : Async<unit> = v65573 10
                let _run_target_args'_v65566 = v65574 
                #endif
#if FABLE_COMPILER_PYTHON
                let v65575 : (int32 -> Async<unit>) = Async.Sleep
                let v65576 : Async<unit> = v65575 10
                let _run_target_args'_v65566 = v65576 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v65577 : (int32 -> Async<unit>) = Async.Sleep
                let v65578 : Async<unit> = v65577 10
                let _run_target_args'_v65566 = v65578 
                #endif
#else
                let v65579 : (int32 -> Async<unit>) = Async.Sleep
                let v65580 : Async<unit> = v65579 10
                let _run_target_args'_v65566 = v65580 
                #endif
                let v65581 : Async<unit> = _run_target_args'_v65566 
                do! v65581 
                let v65587 : int64 = v4 + 1L
                let v65588 : Async<int64> = method36(v0, v1, v2, v3, v65587)
                return! v65588 
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
    let v74561 : Async<int64> = _let'_v55928 
    let _run_target_args'_v9 = v74561 
    #endif
    let v74562 : Async<int64> = _run_target_args'_v9 
    v74562
and method36 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32, v4 : int64) : Async<int64> =
    method37(v0, v1, v2, v3, v4)
and method35 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32) : Async<int64> =
    let v4 : int64 = 1L
    method36(v0, v1, v2, v3, v4)
and closure24 (v0 : int32 option, v1 : bool, v2 : string) (v3 : int32) : Async<int64> =
    method35(v0, v1, v2, v3)
and closure23 (v0 : int32 option, v1 : bool) (v2 : string) : (int32 -> Async<int64>) =
    closure24(v0, v1, v2)
and closure22 (v0 : int32 option) (v1 : bool) : (string -> (int32 -> Async<int64>)) =
    closure23(v0, v1)
and closure21 () (v0 : int32 option) : (bool -> (string -> (int32 -> Async<int64>))) =
    closure22(v0)
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
            let v507 : (int32 -> US10) = method38()
            let v508 : US10 option = v0 |> Option.map v507 
            let v528 : US10 = US10_1
            let v529 : US10 = v508 |> Option.defaultValue v528 
            let v537 : Async<bool> =
                match v529 with
                | US10_1 -> (* None *)
                    method6(v1, v2)
                | US10_0(v534) -> (* Some *)
                    method18(v534, v1, v2)
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
                let v541 : Async<int32> = method42(v0, v1, v540)
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
            let v1511 : (int32 -> US10) = method38()
            let v1512 : US10 option = v0 |> Option.map v1511 
            let v1532 : US10 = US10_1
            let v1533 : US10 = v1512 |> Option.defaultValue v1532 
            let v1541 : Async<bool> =
                match v1533 with
                | US10_1 -> (* None *)
                    method6(v1, v2)
                | US10_0(v1538) -> (* Some *)
                    method18(v1538, v1, v2)
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
                let v1545 : Async<int32> = method42(v0, v1, v1544)
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
            let v2515 : (int32 -> US10) = method38()
            let v2516 : US10 option = v0 |> Option.map v2515 
            let v2536 : US10 = US10_1
            let v2537 : US10 = v2516 |> Option.defaultValue v2536 
            let v2545 : Async<bool> =
                match v2537 with
                | US10_1 -> (* None *)
                    method6(v1, v2)
                | US10_0(v2542) -> (* Some *)
                    method18(v2542, v1, v2)
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
                let v2549 : Async<int32> = method42(v0, v1, v2548)
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
            let v3519 : (int32 -> US10) = method38()
            let v3520 : US10 option = v0 |> Option.map v3519 
            let v3540 : US10 = US10_1
            let v3541 : US10 = v3520 |> Option.defaultValue v3540 
            let v3549 : Async<bool> =
                match v3541 with
                | US10_1 -> (* None *)
                    method6(v1, v2)
                | US10_0(v3546) -> (* Some *)
                    method18(v3546, v1, v2)
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
                let v3553 : Async<int32> = method42(v0, v1, v3552)
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
and method42 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
    method43(v0, v1, v2)
and method41 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
    method42(v0, v1, v2)
and closure29 (v0 : int32 option, v1 : string) (v2 : int32) : Async<int32> =
    method41(v0, v1, v2)
and closure28 (v0 : int32 option) (v1 : string) : (int32 -> Async<int32>) =
    closure29(v0, v1)
and closure27 () (v0 : int32 option) : (string -> (int32 -> Async<int32>)) =
    closure28(v0)
let v14 : unit = ()
let v15 : (unit -> unit) = closure0()
let v16 : unit = (fun () -> v15 (); v14) ()
let v31 : (string -> (int32 -> Async<bool>)) = closure3()
let test_port_open x = v31 x
let v32 : (int32 -> (string -> (int32 -> Async<bool>))) = closure11()
let test_port_open_timeout x = v32 x
let v33 : (int32 option -> (bool -> (string -> (int32 -> Async<int64>)))) = closure21()
let wait_for_port_access x = v33 x
let v34 : (int32 option -> (string -> (int32 -> Async<int32>))) = closure27()
let get_available_port x = v34 x
()
