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
    let v195 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v198 : (int64 -> US2) = method9()
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
    let v361 : string = method10()
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
    let v384 : (int64 -> US2) = method9()
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
    let v547 : string = method10()
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
    let v572 : (int64 -> US2) = method9()
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
    let v619 : (int64 -> US2) = method9()
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
    let v782 : string = method11()
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
    let v805 : (int64 -> US2) = method9()
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
    let v968 : string = method11()
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
    let v991 : (int64 -> US2) = method9()
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
    let v1154 : string = method11()
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
    let v1177 : (int64 -> US2) = method9()
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
    let v1340 : string = method11()
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
and method13 (v0 : char) : string =
    let v1 : string = method14()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v7 : string = $"{v0}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure7(v2, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v23 : string = v2.l0
    v23
and method15 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method12 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method13(v7)
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v26 : string = "inline_colorization::color_bright_black"
    let v27 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v26 
    (* run_target_args'
    let v32 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v33 : string = "&*$0"
    let v34 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v33 
    let _run_target_args'_v32 = v34 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v35 : string = "&*$0"
    let v36 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v35 
    let _run_target_args'_v32 = v36 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v37 : string = "&*$0"
    let v38 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v37 
    let _run_target_args'_v32 = v38 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v40 
    #endif
#if FABLE_COMPILER_PYTHON
    let v44 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v44 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v48 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v48 
    #endif
#else
    let v52 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v52 
    #endif
    let v55 : Ref<Str> = _run_target_args'_v32 
    let v64 : string = "inline_colorization::color_reset"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v64 
    let v66 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v67 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v27, v55, v65) v66 
    let v68 : string = "fable_library_rust::String_::fromString($0)"
    let v69 : string = Fable.Core.RustInterop.emitRustExpr v67 v68 
    let _run_target_args'_v25 = v69 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v70 : string = "inline_colorization::color_bright_black"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v70 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "&*$0"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : Ref<Str> = _run_target_args'_v76 
    let v108 : string = "inline_colorization::color_reset"
    let v109 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v108 
    let v110 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v111 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v71, v99, v109) v110 
    let v112 : string = "fable_library_rust::String_::fromString($0)"
    let v113 : string = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let _run_target_args'_v25 = v113 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v114 : string = "inline_colorization::color_bright_black"
    let v115 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v114 
    (* run_target_args'
    let v120 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v121 : string = "&*$0"
    let v122 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v121 
    let _run_target_args'_v120 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "&*$0"
    let v124 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v123 
    let _run_target_args'_v120 = v124 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v125 : string = "&*$0"
    let v126 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v125 
    let _run_target_args'_v120 = v126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v128 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v128 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v136 
    #endif
#else
    let v140 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v140 
    #endif
    let v143 : Ref<Str> = _run_target_args'_v120 
    let v152 : string = "inline_colorization::color_reset"
    let v153 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v152 
    let v154 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v115, v143, v153) v154 
    let v156 : string = "fable_library_rust::String_::fromString($0)"
    let v157 : string = Fable.Core.RustInterop.emitRustExpr v155 v156 
    let _run_target_args'_v25 = v157 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v159 : string = "\u001b[90m"
    let v163 : string = method15()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[90m"
    let v179 : string = method15()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[90m"
    let v195 : string = method15()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[90m"
    let v211 : string = method15()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method17 (v0 : int32, v1 : string) : string =
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
and method18 (v0 : string) : string =
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
    let v10 : string = method17(v8, v9)
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
    method18(v54)
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
            let v164 : string = method16(v105, v106, v107, v108, v109, v110, v123, v124, v0, v155)
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
and closure14 () (v0 : bool) : US8 =
    US8_0(v0)
and method24 () : (bool -> US8) =
    closure14()
and closure15 () (v0 : exn) : US8 =
    US8_1(v0)
and method25 () : (exn -> US8) =
    closure15()
and method23 (v0 : Async<Choice<bool, exn>>) : Async<US8> =
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
            let v555 : Choice<bool, exn> = v0 
            (* run_target_args'
            let v560 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v562 : US8 = null |> unbox<US8>
            let _run_target_args'_v560 = v562 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v566 : US8 = null |> unbox<US8>
            let _run_target_args'_v560 = v566 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v570 : US8 = null |> unbox<US8>
            let _run_target_args'_v560 = v570 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v574 : US8 = null |> unbox<US8>
            let _run_target_args'_v560 = v574 
            #endif
#if FABLE_COMPILER_PYTHON
            let v578 : US8 = null |> unbox<US8>
            let _run_target_args'_v560 = v578 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v581 : (bool -> US8) = method24()
            let v582 : (exn -> US8) = method25()
            let v583 : US8 = match v555 with Choice1Of2 x -> v581 x | Choice2Of2 x -> v582 x
            let _run_target_args'_v560 = v583 
            #endif
#else
            let v584 : (bool -> US8) = method24()
            let v585 : (exn -> US8) = method25()
            let v586 : US8 = match v555 with Choice1Of2 x -> v584 x | Choice2Of2 x -> v585 x
            let _run_target_args'_v560 = v586 
            #endif
            let v587 : US8 = _run_target_args'_v560 
            return v587 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1129 : Async<US8> = _let'_v19 
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
            let v1674 : US8 = null |> unbox<US8>
            let _run_target_args'_v1672 = v1674 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1678 : US8 = null |> unbox<US8>
            let _run_target_args'_v1672 = v1678 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1682 : US8 = null |> unbox<US8>
            let _run_target_args'_v1672 = v1682 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1686 : US8 = null |> unbox<US8>
            let _run_target_args'_v1672 = v1686 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1690 : US8 = null |> unbox<US8>
            let _run_target_args'_v1672 = v1690 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1693 : (bool -> US8) = method24()
            let v1694 : (exn -> US8) = method25()
            let v1695 : US8 = match v1667 with Choice1Of2 x -> v1693 x | Choice2Of2 x -> v1694 x
            let _run_target_args'_v1672 = v1695 
            #endif
#else
            let v1696 : (bool -> US8) = method24()
            let v1697 : (exn -> US8) = method25()
            let v1698 : US8 = match v1667 with Choice1Of2 x -> v1696 x | Choice2Of2 x -> v1697 x
            let _run_target_args'_v1672 = v1698 
            #endif
            let v1699 : US8 = _run_target_args'_v1672 
            return v1699 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2241 : Async<US8> = _let'_v1131 
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
            let v2786 : US8 = null |> unbox<US8>
            let _run_target_args'_v2784 = v2786 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2790 : US8 = null |> unbox<US8>
            let _run_target_args'_v2784 = v2790 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2794 : US8 = null |> unbox<US8>
            let _run_target_args'_v2784 = v2794 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2798 : US8 = null |> unbox<US8>
            let _run_target_args'_v2784 = v2798 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2802 : US8 = null |> unbox<US8>
            let _run_target_args'_v2784 = v2802 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2805 : (bool -> US8) = method24()
            let v2806 : (exn -> US8) = method25()
            let v2807 : US8 = match v2779 with Choice1Of2 x -> v2805 x | Choice2Of2 x -> v2806 x
            let _run_target_args'_v2784 = v2807 
            #endif
#else
            let v2808 : (bool -> US8) = method24()
            let v2809 : (exn -> US8) = method25()
            let v2810 : US8 = match v2779 with Choice1Of2 x -> v2808 x | Choice2Of2 x -> v2809 x
            let _run_target_args'_v2784 = v2810 
            #endif
            let v2811 : US8 = _run_target_args'_v2784 
            return v2811 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3353 : Async<US8> = _let'_v2243 
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
            let v3898 : US8 = null |> unbox<US8>
            let _run_target_args'_v3896 = v3898 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3902 : US8 = null |> unbox<US8>
            let _run_target_args'_v3896 = v3902 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3906 : US8 = null |> unbox<US8>
            let _run_target_args'_v3896 = v3906 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3910 : US8 = null |> unbox<US8>
            let _run_target_args'_v3896 = v3910 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3914 : US8 = null |> unbox<US8>
            let _run_target_args'_v3896 = v3914 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3917 : (bool -> US8) = method24()
            let v3918 : (exn -> US8) = method25()
            let v3919 : US8 = match v3891 with Choice1Of2 x -> v3917 x | Choice2Of2 x -> v3918 x
            let _run_target_args'_v3896 = v3919 
            #endif
#else
            let v3920 : (bool -> US8) = method24()
            let v3921 : (exn -> US8) = method25()
            let v3922 : US8 = match v3891 with Choice1Of2 x -> v3920 x | Choice2Of2 x -> v3921 x
            let _run_target_args'_v3896 = v3922 
            #endif
            let v3923 : US8 = _run_target_args'_v3896 
            return v3923 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4465 : Async<US8> = _let'_v3355 
    let _run_target_args'_v5 = v4465 
    #endif
    let v4466 : Async<US8> = _run_target_args'_v5 
    v4466
and method26 (v0 : Async<US8>) : Async<US9> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US9> = null |> unbox<Async<US9>>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : Async<US9> = null |> unbox<Async<US9>>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : Async<US9> = null |> unbox<Async<US9>>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : unit = ()
    let _let'_v19 =
        async {
            let! v0 = v0 
            let v113 : US8 = v0 
            let v119 : US9 =
                match v113 with
                | US8_0(v114) -> (* C1of2 *)
                    US9_0(v114)
                | US8_1(v116) -> (* C2of2 *)
                    US9_1(v116)
            return v119 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v211 : Async<US9> = _let'_v19 
    let _run_target_args'_v5 = v211 
    #endif
#if FABLE_COMPILER_PYTHON
    let v213 : unit = ()
    let _let'_v213 =
        async {
            let! v0 = v0 
            let v307 : US8 = v0 
            let v313 : US9 =
                match v307 with
                | US8_0(v308) -> (* C1of2 *)
                    US9_0(v308)
                | US8_1(v310) -> (* C2of2 *)
                    US9_1(v310)
            return v313 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v405 : Async<US9> = _let'_v213 
    let _run_target_args'_v5 = v405 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v407 : unit = ()
    let _let'_v407 =
        async {
            let! v0 = v0 
            let v501 : US8 = v0 
            let v507 : US9 =
                match v501 with
                | US8_0(v502) -> (* C1of2 *)
                    US9_0(v502)
                | US8_1(v504) -> (* C2of2 *)
                    US9_1(v504)
            return v507 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v599 : Async<US9> = _let'_v407 
    let _run_target_args'_v5 = v599 
    #endif
#else
    let v601 : unit = ()
    let _let'_v601 =
        async {
            let! v0 = v0 
            let v695 : US8 = v0 
            let v701 : US9 =
                match v695 with
                | US8_0(v696) -> (* C1of2 *)
                    US9_0(v696)
                | US8_1(v698) -> (* C2of2 *)
                    US9_1(v698)
            return v701 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v793 : Async<US9> = _let'_v601 
    let _run_target_args'_v5 = v793 
    #endif
    let v794 : Async<US9> = _run_target_args'_v5 
    v794
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
    method18(v53)
and closure16 (v0 : int32) () : unit =
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
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method13(v7)
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v26 : string = "inline_colorization::color_bright_red"
    let v27 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v26 
    (* run_target_args'
    let v32 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v33 : string = "&*$0"
    let v34 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v33 
    let _run_target_args'_v32 = v34 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v35 : string = "&*$0"
    let v36 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v35 
    let _run_target_args'_v32 = v36 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v37 : string = "&*$0"
    let v38 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v37 
    let _run_target_args'_v32 = v38 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v40 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v40 
    #endif
#if FABLE_COMPILER_PYTHON
    let v44 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v44 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v48 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v48 
    #endif
#else
    let v52 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v32 = v52 
    #endif
    let v55 : Ref<Str> = _run_target_args'_v32 
    let v64 : string = "inline_colorization::color_reset"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v64 
    let v66 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v67 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v27, v55, v65) v66 
    let v68 : string = "fable_library_rust::String_::fromString($0)"
    let v69 : string = Fable.Core.RustInterop.emitRustExpr v67 v68 
    let _run_target_args'_v25 = v69 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v70 : string = "inline_colorization::color_bright_red"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v70 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "&*$0"
    let v82 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : Ref<Str> = _run_target_args'_v76 
    let v108 : string = "inline_colorization::color_reset"
    let v109 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v108 
    let v110 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v111 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v71, v99, v109) v110 
    let v112 : string = "fable_library_rust::String_::fromString($0)"
    let v113 : string = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let _run_target_args'_v25 = v113 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v114 : string = "inline_colorization::color_bright_red"
    let v115 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v114 
    (* run_target_args'
    let v120 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v121 : string = "&*$0"
    let v122 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v121 
    let _run_target_args'_v120 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v123 : string = "&*$0"
    let v124 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v123 
    let _run_target_args'_v120 = v124 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v125 : string = "&*$0"
    let v126 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v8 v125 
    let _run_target_args'_v120 = v126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v128 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v128 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v136 
    #endif
#else
    let v140 : Ref<Str> = v8 |> unbox<Ref<Str>>
    let _run_target_args'_v120 = v140 
    #endif
    let v143 : Ref<Str> = _run_target_args'_v120 
    let v152 : string = "inline_colorization::color_reset"
    let v153 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v152 
    let v154 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v115, v143, v153) v154 
    let v156 : string = "fable_library_rust::String_::fromString($0)"
    let v157 : string = Fable.Core.RustInterop.emitRustExpr v155 v156 
    let _run_target_args'_v25 = v157 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v159 : string = "\u001b[91m"
    let v163 : string = method15()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[91m"
    let v179 : string = method15()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[91m"
    let v195 : string = method15()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[91m"
    let v211 : string = method15()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
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
    method18(v54)
and closure17 (v0 : int32, v1 : exn) () : unit =
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
and method27 (v0 : int32, v1 : Async<US9>) : Async<US7> =
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
            let v17551 : US9 = v1 
            let v18903 : US7 =
                match v17551 with
                | US9_1(v17554) -> (* Error *)
                    let v17556 : string = $"%A{v17554}"
                    let v17561 : string = "System.TimeoutException"
                    let v17562 : bool = v17556.Contains v17561 
                    if v17562 then
                        let v17876 : unit = ()
                        let v17877 : (unit -> unit) = closure16(v0)
                        let v17878 : unit = (fun () -> v17877 (); v17876) ()
                        US7_1
                    else
                        let v18544 : unit = ()
                        let v18545 : (unit -> unit) = closure17(v0, v17554)
                        let v18546 : unit = (fun () -> v18545 (); v18544) ()
                        US7_1
                | US9_0(v17552) -> (* Ok *)
                    US7_0(v17552)
            return v18903 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v36446 : Async<US7> = _let'_v20 
    let _run_target_args'_v6 = v36446 
    #endif
#if FABLE_COMPILER_PYTHON
    let v36448 : unit = ()
    let _let'_v36448 =
        async {
            let! v1 = v1 
            let v53979 : US9 = v1 
            let v55331 : US7 =
                match v53979 with
                | US9_1(v53982) -> (* Error *)
                    let v53984 : string = $"%A{v53982}"
                    let v53989 : string = "System.TimeoutException"
                    let v53990 : bool = v53984.Contains v53989 
                    if v53990 then
                        let v54304 : unit = ()
                        let v54305 : (unit -> unit) = closure16(v0)
                        let v54306 : unit = (fun () -> v54305 (); v54304) ()
                        US7_1
                    else
                        let v54972 : unit = ()
                        let v54973 : (unit -> unit) = closure17(v0, v53982)
                        let v54974 : unit = (fun () -> v54973 (); v54972) ()
                        US7_1
                | US9_0(v53980) -> (* Ok *)
                    US7_0(v53980)
            return v55331 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v72874 : Async<US7> = _let'_v36448 
    let _run_target_args'_v6 = v72874 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v72876 : unit = ()
    let _let'_v72876 =
        async {
            let! v1 = v1 
            let v90407 : US9 = v1 
            let v91759 : US7 =
                match v90407 with
                | US9_1(v90410) -> (* Error *)
                    let v90412 : string = $"%A{v90410}"
                    let v90417 : string = "System.TimeoutException"
                    let v90418 : bool = v90412.Contains v90417 
                    if v90418 then
                        let v90732 : unit = ()
                        let v90733 : (unit -> unit) = closure16(v0)
                        let v90734 : unit = (fun () -> v90733 (); v90732) ()
                        US7_1
                    else
                        let v91400 : unit = ()
                        let v91401 : (unit -> unit) = closure17(v0, v90410)
                        let v91402 : unit = (fun () -> v91401 (); v91400) ()
                        US7_1
                | US9_0(v90408) -> (* Ok *)
                    US7_0(v90408)
            return v91759 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v109302 : Async<US7> = _let'_v72876 
    let _run_target_args'_v6 = v109302 
    #endif
#else
    let v109304 : unit = ()
    let _let'_v109304 =
        async {
            let! v1 = v1 
            let v126835 : US9 = v1 
            let v128187 : US7 =
                match v126835 with
                | US9_1(v126838) -> (* Error *)
                    let v126840 : string = $"%A{v126838}"
                    let v126845 : string = "System.TimeoutException"
                    let v126846 : bool = v126840.Contains v126845 
                    if v126846 then
                        let v127160 : unit = ()
                        let v127161 : (unit -> unit) = closure16(v0)
                        let v127162 : unit = (fun () -> v127161 (); v127160) ()
                        US7_1
                    else
                        let v127828 : unit = ()
                        let v127829 : (unit -> unit) = closure17(v0, v126838)
                        let v127830 : unit = (fun () -> v127829 (); v127828) ()
                        US7_1
                | US9_0(v126836) -> (* Ok *)
                    US7_0(v126836)
            return v128187 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v145730 : Async<US7> = _let'_v109304 
    let _run_target_args'_v6 = v145730 
    #endif
    let v145731 : Async<US7> = _run_target_args'_v6 
    v145731
and method22 (v0 : Async<bool>, v1 : int32) : Async<US7> =
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
            let v972 : Async<US8> = method23(v963)
            let v973 : Async<US9> = method26(v972)
            let v974 : Async<US7> = method27(v1, v973)
            return! v974 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1859 : Async<US7> = _let'_v20 
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
            let v2813 : Async<US8> = method23(v2804)
            let v2814 : Async<US9> = method26(v2813)
            let v2815 : Async<US7> = method27(v1, v2814)
            return! v2815 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3700 : Async<US7> = _let'_v1861 
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
            let v4654 : Async<US8> = method23(v4645)
            let v4655 : Async<US9> = method26(v4654)
            let v4656 : Async<US7> = method27(v1, v4655)
            return! v4656 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5541 : Async<US7> = _let'_v3702 
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
            let v6495 : Async<US8> = method23(v6486)
            let v6496 : Async<US9> = method26(v6495)
            let v6497 : Async<US7> = method27(v1, v6496)
            return! v6497 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7382 : Async<US7> = _let'_v5543 
    let _run_target_args'_v6 = v7382 
    #endif
    let v7383 : Async<US7> = _run_target_args'_v6 
    v7383
and method21 (v0 : int32, v1 : Async<bool>) : Async<US7> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US7> = method22(v1, v0)
    let _run_target_args'_v6 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : Async<US7> = method22(v1, v0)
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US7> = method22(v1, v0)
    let _run_target_args'_v6 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : Async<US7> = method22(v1, v0)
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : Async<US7> = method22(v1, v0)
    let _run_target_args'_v6 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : Async<US7> = method22(v1, v0)
    let _run_target_args'_v6 = v12 
    #endif
#else
    let v13 : Async<US7> = method22(v1, v0)
    let _run_target_args'_v6 = v13 
    #endif
    let v14 : Async<US7> = _run_target_args'_v6 
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
            let v103 : Async<US7> = method21(v0, v102)
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
            let v270 : Async<US7> = method21(v0, v269)
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
            let v437 : Async<US7> = method21(v0, v436)
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
            let v604 : Async<US7> = method21(v0, v603)
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
and method19 (v0 : int32, v1 : string, v2 : int32) : Async<bool> =
    method20(v0, v1, v2)
and closure13 (v0 : int32, v1 : string) (v2 : int32) : Async<bool> =
    method19(v0, v1, v2)
and closure12 (v0 : int32) (v1 : string) : (int32 -> Async<bool>) =
    closure13(v0, v1)
and closure11 () (v0 : int32) : (string -> (int32 -> Async<bool>)) =
    closure12(v0)
and closure22 () (v0 : int32) : US10 =
    US10_0(v0)
and method36 () : (int32 -> US10) =
    closure22()
and method38 (v0 : int32, v1 : int64, v2 : int32 option, v3 : bool) : string =
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
and method37 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : int64, v10 : int32 option, v11 : bool) : string =
    let v12 : string = method38(v8, v9, v10, v11)
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
    method18(v56)
and closure23 (v0 : int32 option, v1 : bool, v2 : int32, v3 : int64) () : unit =
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
            let v127 : string = method37(v107, v108, v109, v110, v111, v112, v125, v126, v2, v3, v0, v1)
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
and method35 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32, v4 : int64) : Async<int64> =
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
            let v8994 : (int32 -> US10) = method36()
            let v8995 : US10 option = v0 |> Option.map v8994 
            let v9015 : US10 = US10_1
            let v9016 : US10 = v8995 |> Option.defaultValue v9015 
            let v9024 : Async<bool> =
                match v9016 with
                | US10_1 -> (* None *)
                    method6(v2, v3)
                | US10_0(v9021) -> (* Some *)
                    method19(v9021, v2, v3)
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
                    let v9341 : (unit -> unit) = closure23(v0, v1, v3, v4)
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
                let v9683 : Async<int64> = method34(v0, v1, v2, v3, v9682)
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
            let v27629 : (int32 -> US10) = method36()
            let v27630 : US10 option = v0 |> Option.map v27629 
            let v27650 : US10 = US10_1
            let v27651 : US10 = v27630 |> Option.defaultValue v27650 
            let v27659 : Async<bool> =
                match v27651 with
                | US10_1 -> (* None *)
                    method6(v2, v3)
                | US10_0(v27656) -> (* Some *)
                    method19(v27656, v2, v3)
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
                    let v27976 : (unit -> unit) = closure23(v0, v1, v3, v4)
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
                let v28318 : Async<int64> = method34(v0, v1, v2, v3, v28317)
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
            let v46264 : (int32 -> US10) = method36()
            let v46265 : US10 option = v0 |> Option.map v46264 
            let v46285 : US10 = US10_1
            let v46286 : US10 = v46265 |> Option.defaultValue v46285 
            let v46294 : Async<bool> =
                match v46286 with
                | US10_1 -> (* None *)
                    method6(v2, v3)
                | US10_0(v46291) -> (* Some *)
                    method19(v46291, v2, v3)
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
                    let v46611 : (unit -> unit) = closure23(v0, v1, v3, v4)
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
                let v46953 : Async<int64> = method34(v0, v1, v2, v3, v46952)
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
            let v64899 : (int32 -> US10) = method36()
            let v64900 : US10 option = v0 |> Option.map v64899 
            let v64920 : US10 = US10_1
            let v64921 : US10 = v64900 |> Option.defaultValue v64920 
            let v64929 : Async<bool> =
                match v64921 with
                | US10_1 -> (* None *)
                    method6(v2, v3)
                | US10_0(v64926) -> (* Some *)
                    method19(v64926, v2, v3)
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
                    let v65246 : (unit -> unit) = closure23(v0, v1, v3, v4)
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
                let v65588 : Async<int64> = method34(v0, v1, v2, v3, v65587)
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
and method34 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32, v4 : int64) : Async<int64> =
    method35(v0, v1, v2, v3, v4)
and method33 (v0 : int32 option, v1 : bool, v2 : string, v3 : int32) : Async<int64> =
    let v4 : int64 = 1L
    method34(v0, v1, v2, v3, v4)
and closure21 (v0 : int32 option, v1 : bool, v2 : string) (v3 : int32) : Async<int64> =
    method33(v0, v1, v2, v3)
and closure20 (v0 : int32 option, v1 : bool) (v2 : string) : (int32 -> Async<int64>) =
    closure21(v0, v1, v2)
and closure19 (v0 : int32 option) (v1 : bool) : (string -> (int32 -> Async<int64>)) =
    closure20(v0, v1)
and closure18 () (v0 : int32 option) : (bool -> (string -> (int32 -> Async<int64>))) =
    closure19(v0)
and method41 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
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
            let v507 : (int32 -> US10) = method36()
            let v508 : US10 option = v0 |> Option.map v507 
            let v528 : US10 = US10_1
            let v529 : US10 = v508 |> Option.defaultValue v528 
            let v537 : Async<bool> =
                match v529 with
                | US10_1 -> (* None *)
                    method6(v1, v2)
                | US10_0(v534) -> (* Some *)
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
                let v541 : Async<int32> = method40(v0, v1, v540)
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
            let v1511 : (int32 -> US10) = method36()
            let v1512 : US10 option = v0 |> Option.map v1511 
            let v1532 : US10 = US10_1
            let v1533 : US10 = v1512 |> Option.defaultValue v1532 
            let v1541 : Async<bool> =
                match v1533 with
                | US10_1 -> (* None *)
                    method6(v1, v2)
                | US10_0(v1538) -> (* Some *)
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
                let v1545 : Async<int32> = method40(v0, v1, v1544)
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
            let v2515 : (int32 -> US10) = method36()
            let v2516 : US10 option = v0 |> Option.map v2515 
            let v2536 : US10 = US10_1
            let v2537 : US10 = v2516 |> Option.defaultValue v2536 
            let v2545 : Async<bool> =
                match v2537 with
                | US10_1 -> (* None *)
                    method6(v1, v2)
                | US10_0(v2542) -> (* Some *)
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
                let v2549 : Async<int32> = method40(v0, v1, v2548)
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
            let v3519 : (int32 -> US10) = method36()
            let v3520 : US10 option = v0 |> Option.map v3519 
            let v3540 : US10 = US10_1
            let v3541 : US10 = v3520 |> Option.defaultValue v3540 
            let v3549 : Async<bool> =
                match v3541 with
                | US10_1 -> (* None *)
                    method6(v1, v2)
                | US10_0(v3546) -> (* Some *)
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
                let v3553 : Async<int32> = method40(v0, v1, v3552)
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
and method40 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
    method41(v0, v1, v2)
and method39 (v0 : int32 option, v1 : string, v2 : int32) : Async<int32> =
    method40(v0, v1, v2)
and closure26 (v0 : int32 option, v1 : string) (v2 : int32) : Async<int32> =
    method39(v0, v1, v2)
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
