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
and closure7 () (v0 : int64) : US2 =
    US2_0(v0)
and method7 () : (int64 -> US2) =
    closure7()
and method8 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method9 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method6 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v216 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v219 : (int64 -> US2) = method7()
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
    let v396 : string = method8()
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
    let v429 : (int64 -> US2) = method7()
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
    let v606 : string = method8()
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
    let v641 : (int64 -> US2) = method7()
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
    let v688 : (int64 -> US2) = method7()
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
    let v865 : string = method9()
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
    let v898 : (int64 -> US2) = method7()
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
    let v1075 : string = method9()
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
    let v1108 : (int64 -> US2) = method7()
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
    let v1285 : string = method9()
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
    let v1318 : (int64 -> US2) = method7()
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
    let v1495 : string = method9()
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
and method12 () : string =
    let v0 : string = ""
    v0
and closure8 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v4 : string = v2 + v1 
    v0.l0 <- v4
    ()
and method11 (v0 : char) : string =
    let v1 : string = method12()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v7 : string = $"{v0}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure8(v2, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v23 : string = v2.l0
    v23
and method10 (v0 : US0) : string =
    let v650 : string =
        match v0 with
        | US0_4 -> (* Critical *)
            (* run_target_args'
            let v518 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v519 : string = "inline_colorization::color_bright_red"
            let v520 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v519 
            (* run_target_args'
            let v525 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v526 : string = "String::from($0)"
            let v527 : std_string_String = Fable.Core.RustInterop.emitRustExpr v520 v526 
            let _run_target_args'_v525 = v527 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v528 : string = "String::from($0)"
            let v529 : std_string_String = Fable.Core.RustInterop.emitRustExpr v520 v528 
            let _run_target_args'_v525 = v529 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v530 : string = "String::from($0)"
            let v531 : std_string_String = Fable.Core.RustInterop.emitRustExpr v520 v530 
            let _run_target_args'_v525 = v531 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v533 : std_string_String = v520 |> unbox<std_string_String>
            let _run_target_args'_v525 = v533 
            #endif
#if FABLE_COMPILER_PYTHON
            let v537 : std_string_String = v520 |> unbox<std_string_String>
            let _run_target_args'_v525 = v537 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v541 : std_string_String = v520 |> unbox<std_string_String>
            let _run_target_args'_v525 = v541 
            #endif
#else
            let v545 : std_string_String = v520 |> unbox<std_string_String>
            let _run_target_args'_v525 = v545 
            #endif
            let v548 : std_string_String = _run_target_args'_v525 
            let v557 : string = "fable_library_rust::String_::fromString($0)"
            let v558 : string = Fable.Core.RustInterop.emitRustExpr v548 v557 
            let _run_target_args'_v518 = v558 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v559 : string = "inline_colorization::color_bright_red"
            let v560 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v559 
            (* run_target_args'
            let v565 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v566 : string = "String::from($0)"
            let v567 : std_string_String = Fable.Core.RustInterop.emitRustExpr v560 v566 
            let _run_target_args'_v565 = v567 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v568 : string = "String::from($0)"
            let v569 : std_string_String = Fable.Core.RustInterop.emitRustExpr v560 v568 
            let _run_target_args'_v565 = v569 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v570 : string = "String::from($0)"
            let v571 : std_string_String = Fable.Core.RustInterop.emitRustExpr v560 v570 
            let _run_target_args'_v565 = v571 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v573 : std_string_String = v560 |> unbox<std_string_String>
            let _run_target_args'_v565 = v573 
            #endif
#if FABLE_COMPILER_PYTHON
            let v577 : std_string_String = v560 |> unbox<std_string_String>
            let _run_target_args'_v565 = v577 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v581 : std_string_String = v560 |> unbox<std_string_String>
            let _run_target_args'_v565 = v581 
            #endif
#else
            let v585 : std_string_String = v560 |> unbox<std_string_String>
            let _run_target_args'_v565 = v585 
            #endif
            let v588 : std_string_String = _run_target_args'_v565 
            let v597 : string = "fable_library_rust::String_::fromString($0)"
            let v598 : string = Fable.Core.RustInterop.emitRustExpr v588 v597 
            let _run_target_args'_v518 = v598 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v599 : string = "inline_colorization::color_bright_red"
            let v600 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v599 
            (* run_target_args'
            let v605 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v606 : string = "String::from($0)"
            let v607 : std_string_String = Fable.Core.RustInterop.emitRustExpr v600 v606 
            let _run_target_args'_v605 = v607 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v608 : string = "String::from($0)"
            let v609 : std_string_String = Fable.Core.RustInterop.emitRustExpr v600 v608 
            let _run_target_args'_v605 = v609 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v610 : string = "String::from($0)"
            let v611 : std_string_String = Fable.Core.RustInterop.emitRustExpr v600 v610 
            let _run_target_args'_v605 = v611 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v613 : std_string_String = v600 |> unbox<std_string_String>
            let _run_target_args'_v605 = v613 
            #endif
#if FABLE_COMPILER_PYTHON
            let v617 : std_string_String = v600 |> unbox<std_string_String>
            let _run_target_args'_v605 = v617 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v621 : std_string_String = v600 |> unbox<std_string_String>
            let _run_target_args'_v605 = v621 
            #endif
#else
            let v625 : std_string_String = v600 |> unbox<std_string_String>
            let _run_target_args'_v605 = v625 
            #endif
            let v628 : std_string_String = _run_target_args'_v605 
            let v637 : string = "fable_library_rust::String_::fromString($0)"
            let v638 : string = Fable.Core.RustInterop.emitRustExpr v628 v637 
            let _run_target_args'_v518 = v638 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v639 : string = "\u001b[91m"
            let _run_target_args'_v518 = v639 
            #endif
#if FABLE_COMPILER_PYTHON
            let v640 : string = "\u001b[91m"
            let _run_target_args'_v518 = v640 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v641 : string = "\u001b[91m"
            let _run_target_args'_v518 = v641 
            #endif
#else
            let v642 : string = "\u001b[91m"
            let _run_target_args'_v518 = v642 
            #endif
            let v643 : string = _run_target_args'_v518 
            v643
        | US0_1 -> (* Debug *)
            (* run_target_args'
            let v131 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v132 : string = "inline_colorization::color_bright_blue"
            let v133 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v132 
            (* run_target_args'
            let v138 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v139 : string = "String::from($0)"
            let v140 : std_string_String = Fable.Core.RustInterop.emitRustExpr v133 v139 
            let _run_target_args'_v138 = v140 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v141 : string = "String::from($0)"
            let v142 : std_string_String = Fable.Core.RustInterop.emitRustExpr v133 v141 
            let _run_target_args'_v138 = v142 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v143 : string = "String::from($0)"
            let v144 : std_string_String = Fable.Core.RustInterop.emitRustExpr v133 v143 
            let _run_target_args'_v138 = v144 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v146 : std_string_String = v133 |> unbox<std_string_String>
            let _run_target_args'_v138 = v146 
            #endif
#if FABLE_COMPILER_PYTHON
            let v150 : std_string_String = v133 |> unbox<std_string_String>
            let _run_target_args'_v138 = v150 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v154 : std_string_String = v133 |> unbox<std_string_String>
            let _run_target_args'_v138 = v154 
            #endif
#else
            let v158 : std_string_String = v133 |> unbox<std_string_String>
            let _run_target_args'_v138 = v158 
            #endif
            let v161 : std_string_String = _run_target_args'_v138 
            let v170 : string = "fable_library_rust::String_::fromString($0)"
            let v171 : string = Fable.Core.RustInterop.emitRustExpr v161 v170 
            let _run_target_args'_v131 = v171 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v172 : string = "inline_colorization::color_bright_blue"
            let v173 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v172 
            (* run_target_args'
            let v178 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v179 : string = "String::from($0)"
            let v180 : std_string_String = Fable.Core.RustInterop.emitRustExpr v173 v179 
            let _run_target_args'_v178 = v180 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v181 : string = "String::from($0)"
            let v182 : std_string_String = Fable.Core.RustInterop.emitRustExpr v173 v181 
            let _run_target_args'_v178 = v182 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v183 : string = "String::from($0)"
            let v184 : std_string_String = Fable.Core.RustInterop.emitRustExpr v173 v183 
            let _run_target_args'_v178 = v184 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v186 : std_string_String = v173 |> unbox<std_string_String>
            let _run_target_args'_v178 = v186 
            #endif
#if FABLE_COMPILER_PYTHON
            let v190 : std_string_String = v173 |> unbox<std_string_String>
            let _run_target_args'_v178 = v190 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v194 : std_string_String = v173 |> unbox<std_string_String>
            let _run_target_args'_v178 = v194 
            #endif
#else
            let v198 : std_string_String = v173 |> unbox<std_string_String>
            let _run_target_args'_v178 = v198 
            #endif
            let v201 : std_string_String = _run_target_args'_v178 
            let v210 : string = "fable_library_rust::String_::fromString($0)"
            let v211 : string = Fable.Core.RustInterop.emitRustExpr v201 v210 
            let _run_target_args'_v131 = v211 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v212 : string = "inline_colorization::color_bright_blue"
            let v213 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v212 
            (* run_target_args'
            let v218 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v219 : string = "String::from($0)"
            let v220 : std_string_String = Fable.Core.RustInterop.emitRustExpr v213 v219 
            let _run_target_args'_v218 = v220 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v221 : string = "String::from($0)"
            let v222 : std_string_String = Fable.Core.RustInterop.emitRustExpr v213 v221 
            let _run_target_args'_v218 = v222 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v223 : string = "String::from($0)"
            let v224 : std_string_String = Fable.Core.RustInterop.emitRustExpr v213 v223 
            let _run_target_args'_v218 = v224 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v226 : std_string_String = v213 |> unbox<std_string_String>
            let _run_target_args'_v218 = v226 
            #endif
#if FABLE_COMPILER_PYTHON
            let v230 : std_string_String = v213 |> unbox<std_string_String>
            let _run_target_args'_v218 = v230 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v234 : std_string_String = v213 |> unbox<std_string_String>
            let _run_target_args'_v218 = v234 
            #endif
#else
            let v238 : std_string_String = v213 |> unbox<std_string_String>
            let _run_target_args'_v218 = v238 
            #endif
            let v241 : std_string_String = _run_target_args'_v218 
            let v250 : string = "fable_library_rust::String_::fromString($0)"
            let v251 : string = Fable.Core.RustInterop.emitRustExpr v241 v250 
            let _run_target_args'_v131 = v251 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v252 : string = "\u001b[94m"
            let _run_target_args'_v131 = v252 
            #endif
#if FABLE_COMPILER_PYTHON
            let v253 : string = "\u001b[94m"
            let _run_target_args'_v131 = v253 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v254 : string = "\u001b[94m"
            let _run_target_args'_v131 = v254 
            #endif
#else
            let v255 : string = "\u001b[94m"
            let _run_target_args'_v131 = v255 
            #endif
            let v256 : string = _run_target_args'_v131 
            v256
        | US0_2 -> (* Info *)
            (* run_target_args'
            let v260 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v261 : string = "inline_colorization::color_bright_green"
            let v262 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v261 
            (* run_target_args'
            let v267 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v268 : string = "String::from($0)"
            let v269 : std_string_String = Fable.Core.RustInterop.emitRustExpr v262 v268 
            let _run_target_args'_v267 = v269 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v270 : string = "String::from($0)"
            let v271 : std_string_String = Fable.Core.RustInterop.emitRustExpr v262 v270 
            let _run_target_args'_v267 = v271 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v272 : string = "String::from($0)"
            let v273 : std_string_String = Fable.Core.RustInterop.emitRustExpr v262 v272 
            let _run_target_args'_v267 = v273 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v275 : std_string_String = v262 |> unbox<std_string_String>
            let _run_target_args'_v267 = v275 
            #endif
#if FABLE_COMPILER_PYTHON
            let v279 : std_string_String = v262 |> unbox<std_string_String>
            let _run_target_args'_v267 = v279 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v283 : std_string_String = v262 |> unbox<std_string_String>
            let _run_target_args'_v267 = v283 
            #endif
#else
            let v287 : std_string_String = v262 |> unbox<std_string_String>
            let _run_target_args'_v267 = v287 
            #endif
            let v290 : std_string_String = _run_target_args'_v267 
            let v299 : string = "fable_library_rust::String_::fromString($0)"
            let v300 : string = Fable.Core.RustInterop.emitRustExpr v290 v299 
            let _run_target_args'_v260 = v300 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v301 : string = "inline_colorization::color_bright_green"
            let v302 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v301 
            (* run_target_args'
            let v307 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v308 : string = "String::from($0)"
            let v309 : std_string_String = Fable.Core.RustInterop.emitRustExpr v302 v308 
            let _run_target_args'_v307 = v309 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v310 : string = "String::from($0)"
            let v311 : std_string_String = Fable.Core.RustInterop.emitRustExpr v302 v310 
            let _run_target_args'_v307 = v311 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v312 : string = "String::from($0)"
            let v313 : std_string_String = Fable.Core.RustInterop.emitRustExpr v302 v312 
            let _run_target_args'_v307 = v313 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v315 : std_string_String = v302 |> unbox<std_string_String>
            let _run_target_args'_v307 = v315 
            #endif
#if FABLE_COMPILER_PYTHON
            let v319 : std_string_String = v302 |> unbox<std_string_String>
            let _run_target_args'_v307 = v319 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v323 : std_string_String = v302 |> unbox<std_string_String>
            let _run_target_args'_v307 = v323 
            #endif
#else
            let v327 : std_string_String = v302 |> unbox<std_string_String>
            let _run_target_args'_v307 = v327 
            #endif
            let v330 : std_string_String = _run_target_args'_v307 
            let v339 : string = "fable_library_rust::String_::fromString($0)"
            let v340 : string = Fable.Core.RustInterop.emitRustExpr v330 v339 
            let _run_target_args'_v260 = v340 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v341 : string = "inline_colorization::color_bright_green"
            let v342 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v341 
            (* run_target_args'
            let v347 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v348 : string = "String::from($0)"
            let v349 : std_string_String = Fable.Core.RustInterop.emitRustExpr v342 v348 
            let _run_target_args'_v347 = v349 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v350 : string = "String::from($0)"
            let v351 : std_string_String = Fable.Core.RustInterop.emitRustExpr v342 v350 
            let _run_target_args'_v347 = v351 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v352 : string = "String::from($0)"
            let v353 : std_string_String = Fable.Core.RustInterop.emitRustExpr v342 v352 
            let _run_target_args'_v347 = v353 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v355 : std_string_String = v342 |> unbox<std_string_String>
            let _run_target_args'_v347 = v355 
            #endif
#if FABLE_COMPILER_PYTHON
            let v359 : std_string_String = v342 |> unbox<std_string_String>
            let _run_target_args'_v347 = v359 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v363 : std_string_String = v342 |> unbox<std_string_String>
            let _run_target_args'_v347 = v363 
            #endif
#else
            let v367 : std_string_String = v342 |> unbox<std_string_String>
            let _run_target_args'_v347 = v367 
            #endif
            let v370 : std_string_String = _run_target_args'_v347 
            let v379 : string = "fable_library_rust::String_::fromString($0)"
            let v380 : string = Fable.Core.RustInterop.emitRustExpr v370 v379 
            let _run_target_args'_v260 = v380 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v381 : string = "\u001b[92m"
            let _run_target_args'_v260 = v381 
            #endif
#if FABLE_COMPILER_PYTHON
            let v382 : string = "\u001b[92m"
            let _run_target_args'_v260 = v382 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v383 : string = "\u001b[92m"
            let _run_target_args'_v260 = v383 
            #endif
#else
            let v384 : string = "\u001b[92m"
            let _run_target_args'_v260 = v384 
            #endif
            let v385 : string = _run_target_args'_v260 
            v385
        | US0_0 -> (* Verbose *)
            (* run_target_args'
            let v2 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3 : string = "inline_colorization::color_bright_black"
            let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v3 
            (* run_target_args'
            let v9 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v10 : string = "String::from($0)"
            let v11 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v10 
            let _run_target_args'_v9 = v11 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v12 : string = "String::from($0)"
            let v13 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v12 
            let _run_target_args'_v9 = v13 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v14 : string = "String::from($0)"
            let v15 : std_string_String = Fable.Core.RustInterop.emitRustExpr v4 v14 
            let _run_target_args'_v9 = v15 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v17 : std_string_String = v4 |> unbox<std_string_String>
            let _run_target_args'_v9 = v17 
            #endif
#if FABLE_COMPILER_PYTHON
            let v21 : std_string_String = v4 |> unbox<std_string_String>
            let _run_target_args'_v9 = v21 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v25 : std_string_String = v4 |> unbox<std_string_String>
            let _run_target_args'_v9 = v25 
            #endif
#else
            let v29 : std_string_String = v4 |> unbox<std_string_String>
            let _run_target_args'_v9 = v29 
            #endif
            let v32 : std_string_String = _run_target_args'_v9 
            let v41 : string = "fable_library_rust::String_::fromString($0)"
            let v42 : string = Fable.Core.RustInterop.emitRustExpr v32 v41 
            let _run_target_args'_v2 = v42 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v43 : string = "inline_colorization::color_bright_black"
            let v44 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v43 
            (* run_target_args'
            let v49 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v50 : string = "String::from($0)"
            let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr v44 v50 
            let _run_target_args'_v49 = v51 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v52 : string = "String::from($0)"
            let v53 : std_string_String = Fable.Core.RustInterop.emitRustExpr v44 v52 
            let _run_target_args'_v49 = v53 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v54 : string = "String::from($0)"
            let v55 : std_string_String = Fable.Core.RustInterop.emitRustExpr v44 v54 
            let _run_target_args'_v49 = v55 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v57 : std_string_String = v44 |> unbox<std_string_String>
            let _run_target_args'_v49 = v57 
            #endif
#if FABLE_COMPILER_PYTHON
            let v61 : std_string_String = v44 |> unbox<std_string_String>
            let _run_target_args'_v49 = v61 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v65 : std_string_String = v44 |> unbox<std_string_String>
            let _run_target_args'_v49 = v65 
            #endif
#else
            let v69 : std_string_String = v44 |> unbox<std_string_String>
            let _run_target_args'_v49 = v69 
            #endif
            let v72 : std_string_String = _run_target_args'_v49 
            let v81 : string = "fable_library_rust::String_::fromString($0)"
            let v82 : string = Fable.Core.RustInterop.emitRustExpr v72 v81 
            let _run_target_args'_v2 = v82 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v83 : string = "inline_colorization::color_bright_black"
            let v84 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v83 
            (* run_target_args'
            let v89 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v90 : string = "String::from($0)"
            let v91 : std_string_String = Fable.Core.RustInterop.emitRustExpr v84 v90 
            let _run_target_args'_v89 = v91 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v92 : string = "String::from($0)"
            let v93 : std_string_String = Fable.Core.RustInterop.emitRustExpr v84 v92 
            let _run_target_args'_v89 = v93 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v94 : string = "String::from($0)"
            let v95 : std_string_String = Fable.Core.RustInterop.emitRustExpr v84 v94 
            let _run_target_args'_v89 = v95 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v97 : std_string_String = v84 |> unbox<std_string_String>
            let _run_target_args'_v89 = v97 
            #endif
#if FABLE_COMPILER_PYTHON
            let v101 : std_string_String = v84 |> unbox<std_string_String>
            let _run_target_args'_v89 = v101 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v105 : std_string_String = v84 |> unbox<std_string_String>
            let _run_target_args'_v89 = v105 
            #endif
#else
            let v109 : std_string_String = v84 |> unbox<std_string_String>
            let _run_target_args'_v89 = v109 
            #endif
            let v112 : std_string_String = _run_target_args'_v89 
            let v121 : string = "fable_library_rust::String_::fromString($0)"
            let v122 : string = Fable.Core.RustInterop.emitRustExpr v112 v121 
            let _run_target_args'_v2 = v122 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v123 : string = "\u001b[90m"
            let _run_target_args'_v2 = v123 
            #endif
#if FABLE_COMPILER_PYTHON
            let v124 : string = "\u001b[90m"
            let _run_target_args'_v2 = v124 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v125 : string = "\u001b[90m"
            let _run_target_args'_v2 = v125 
            #endif
#else
            let v126 : string = "\u001b[90m"
            let _run_target_args'_v2 = v126 
            #endif
            let v127 : string = _run_target_args'_v2 
            v127
        | US0_3 -> (* Warning *)
            (* run_target_args'
            let v389 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v390 : string = "inline_colorization::color_yellow"
            let v391 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v390 
            (* run_target_args'
            let v396 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v397 : string = "String::from($0)"
            let v398 : std_string_String = Fable.Core.RustInterop.emitRustExpr v391 v397 
            let _run_target_args'_v396 = v398 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v399 : string = "String::from($0)"
            let v400 : std_string_String = Fable.Core.RustInterop.emitRustExpr v391 v399 
            let _run_target_args'_v396 = v400 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v401 : string = "String::from($0)"
            let v402 : std_string_String = Fable.Core.RustInterop.emitRustExpr v391 v401 
            let _run_target_args'_v396 = v402 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v404 : std_string_String = v391 |> unbox<std_string_String>
            let _run_target_args'_v396 = v404 
            #endif
#if FABLE_COMPILER_PYTHON
            let v408 : std_string_String = v391 |> unbox<std_string_String>
            let _run_target_args'_v396 = v408 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v412 : std_string_String = v391 |> unbox<std_string_String>
            let _run_target_args'_v396 = v412 
            #endif
#else
            let v416 : std_string_String = v391 |> unbox<std_string_String>
            let _run_target_args'_v396 = v416 
            #endif
            let v419 : std_string_String = _run_target_args'_v396 
            let v428 : string = "fable_library_rust::String_::fromString($0)"
            let v429 : string = Fable.Core.RustInterop.emitRustExpr v419 v428 
            let _run_target_args'_v389 = v429 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v430 : string = "inline_colorization::color_yellow"
            let v431 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v430 
            (* run_target_args'
            let v436 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v437 : string = "String::from($0)"
            let v438 : std_string_String = Fable.Core.RustInterop.emitRustExpr v431 v437 
            let _run_target_args'_v436 = v438 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v439 : string = "String::from($0)"
            let v440 : std_string_String = Fable.Core.RustInterop.emitRustExpr v431 v439 
            let _run_target_args'_v436 = v440 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v441 : string = "String::from($0)"
            let v442 : std_string_String = Fable.Core.RustInterop.emitRustExpr v431 v441 
            let _run_target_args'_v436 = v442 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v444 : std_string_String = v431 |> unbox<std_string_String>
            let _run_target_args'_v436 = v444 
            #endif
#if FABLE_COMPILER_PYTHON
            let v448 : std_string_String = v431 |> unbox<std_string_String>
            let _run_target_args'_v436 = v448 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v452 : std_string_String = v431 |> unbox<std_string_String>
            let _run_target_args'_v436 = v452 
            #endif
#else
            let v456 : std_string_String = v431 |> unbox<std_string_String>
            let _run_target_args'_v436 = v456 
            #endif
            let v459 : std_string_String = _run_target_args'_v436 
            let v468 : string = "fable_library_rust::String_::fromString($0)"
            let v469 : string = Fable.Core.RustInterop.emitRustExpr v459 v468 
            let _run_target_args'_v389 = v469 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v470 : string = "inline_colorization::color_yellow"
            let v471 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v470 
            (* run_target_args'
            let v476 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v477 : string = "String::from($0)"
            let v478 : std_string_String = Fable.Core.RustInterop.emitRustExpr v471 v477 
            let _run_target_args'_v476 = v478 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v479 : string = "String::from($0)"
            let v480 : std_string_String = Fable.Core.RustInterop.emitRustExpr v471 v479 
            let _run_target_args'_v476 = v480 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v481 : string = "String::from($0)"
            let v482 : std_string_String = Fable.Core.RustInterop.emitRustExpr v471 v481 
            let _run_target_args'_v476 = v482 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v484 : std_string_String = v471 |> unbox<std_string_String>
            let _run_target_args'_v476 = v484 
            #endif
#if FABLE_COMPILER_PYTHON
            let v488 : std_string_String = v471 |> unbox<std_string_String>
            let _run_target_args'_v476 = v488 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v492 : std_string_String = v471 |> unbox<std_string_String>
            let _run_target_args'_v476 = v492 
            #endif
#else
            let v496 : std_string_String = v471 |> unbox<std_string_String>
            let _run_target_args'_v476 = v496 
            #endif
            let v499 : std_string_String = _run_target_args'_v476 
            let v508 : string = "fable_library_rust::String_::fromString($0)"
            let v509 : string = Fable.Core.RustInterop.emitRustExpr v499 v508 
            let _run_target_args'_v389 = v509 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v510 : string = "\u001b[93m"
            let _run_target_args'_v389 = v510 
            #endif
#if FABLE_COMPILER_PYTHON
            let v511 : string = "\u001b[93m"
            let _run_target_args'_v389 = v511 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v512 : string = "\u001b[93m"
            let _run_target_args'_v389 = v512 
            #endif
#else
            let v513 : string = "\u001b[93m"
            let _run_target_args'_v389 = v513 
            #endif
            let v514 : string = _run_target_args'_v389 
            v514
    
    
    
    
    
    let v651 : bool =
        match v0 with
        | US0_0 -> (* Verbose *)
            true
        | _ ->
            false
    let v655 : US5 =
        if v651 then
            let v652 : string = "Verbose"
            US5_0(v652)
        else
            US5_1
    let v696 : US5 =
        match v655 with
        | US5_1 -> (* None *)
            let v658 : bool =
                match v0 with
                | US0_1 -> (* Debug *)
                    true
                | _ ->
                    false
            let v662 : US5 =
                if v658 then
                    let v659 : string = "Debug"
                    US5_0(v659)
                else
                    US5_1
            match v662 with
            | US5_1 -> (* None *)
                let v665 : bool =
                    match v0 with
                    | US0_2 -> (* Info *)
                        true
                    | _ ->
                        false
                let v669 : US5 =
                    if v665 then
                        let v666 : string = "Info"
                        US5_0(v666)
                    else
                        US5_1
                match v669 with
                | US5_1 -> (* None *)
                    let v672 : bool =
                        match v0 with
                        | US0_3 -> (* Warning *)
                            true
                        | _ ->
                            false
                    let v676 : US5 =
                        if v672 then
                            let v673 : string = "Warning"
                            US5_0(v673)
                        else
                            US5_1
                    match v676 with
                    | US5_1 -> (* None *)
                        let v679 : bool =
                            match v0 with
                            | US0_4 -> (* Critical *)
                                true
                            | _ ->
                                false
                        let v683 : US5 =
                            if v679 then
                                let v680 : string = "Critical"
                                US5_0(v680)
                            else
                                US5_1
                        match v683 with
                        | US5_1 -> (* None *)
                            US5_1
                        | US5_0(v684) -> (* Some *)
                            US5_0(v684)
                    | US5_0(v677) -> (* Some *)
                        US5_0(v677)
                | US5_0(v670) -> (* Some *)
                    US5_0(v670)
            | US5_0(v663) -> (* Some *)
                US5_0(v663)
        | US5_0(v656) -> (* Some *)
            US5_0(v656)
    let v700 : string =
        match v696 with
        | US5_1 -> (* None *)
            failwith<string> "Option does not have a value."
        | US5_0(v697) -> (* Some *)
            v697
    let v702 : (unit -> string) = v700.ToLower
    let v703 : string = v702 ()
    let v706 : char = v703.[int 0]
    let v707 : string = method11(v706)
    let v709 : string = v650 + v707 
    (* run_target_args'
    let v713 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v714 : string = "inline_colorization::color_reset"
    let v715 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v714 
    (* run_target_args'
    let v720 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v721 : string = "String::from($0)"
    let v722 : std_string_String = Fable.Core.RustInterop.emitRustExpr v715 v721 
    let _run_target_args'_v720 = v722 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v723 : string = "String::from($0)"
    let v724 : std_string_String = Fable.Core.RustInterop.emitRustExpr v715 v723 
    let _run_target_args'_v720 = v724 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v725 : string = "String::from($0)"
    let v726 : std_string_String = Fable.Core.RustInterop.emitRustExpr v715 v725 
    let _run_target_args'_v720 = v726 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v728 : std_string_String = v715 |> unbox<std_string_String>
    let _run_target_args'_v720 = v728 
    #endif
#if FABLE_COMPILER_PYTHON
    let v732 : std_string_String = v715 |> unbox<std_string_String>
    let _run_target_args'_v720 = v732 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v736 : std_string_String = v715 |> unbox<std_string_String>
    let _run_target_args'_v720 = v736 
    #endif
#else
    let v740 : std_string_String = v715 |> unbox<std_string_String>
    let _run_target_args'_v720 = v740 
    #endif
    let v743 : std_string_String = _run_target_args'_v720 
    let v752 : string = "fable_library_rust::String_::fromString($0)"
    let v753 : string = Fable.Core.RustInterop.emitRustExpr v743 v752 
    let _run_target_args'_v713 = v753 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v754 : string = "inline_colorization::color_reset"
    let v755 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v754 
    (* run_target_args'
    let v760 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v761 : string = "String::from($0)"
    let v762 : std_string_String = Fable.Core.RustInterop.emitRustExpr v755 v761 
    let _run_target_args'_v760 = v762 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v763 : string = "String::from($0)"
    let v764 : std_string_String = Fable.Core.RustInterop.emitRustExpr v755 v763 
    let _run_target_args'_v760 = v764 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v765 : string = "String::from($0)"
    let v766 : std_string_String = Fable.Core.RustInterop.emitRustExpr v755 v765 
    let _run_target_args'_v760 = v766 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v768 : std_string_String = v755 |> unbox<std_string_String>
    let _run_target_args'_v760 = v768 
    #endif
#if FABLE_COMPILER_PYTHON
    let v772 : std_string_String = v755 |> unbox<std_string_String>
    let _run_target_args'_v760 = v772 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v776 : std_string_String = v755 |> unbox<std_string_String>
    let _run_target_args'_v760 = v776 
    #endif
#else
    let v780 : std_string_String = v755 |> unbox<std_string_String>
    let _run_target_args'_v760 = v780 
    #endif
    let v783 : std_string_String = _run_target_args'_v760 
    let v792 : string = "fable_library_rust::String_::fromString($0)"
    let v793 : string = Fable.Core.RustInterop.emitRustExpr v783 v792 
    let _run_target_args'_v713 = v793 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v794 : string = "inline_colorization::color_reset"
    let v795 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v794 
    (* run_target_args'
    let v800 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v801 : string = "String::from($0)"
    let v802 : std_string_String = Fable.Core.RustInterop.emitRustExpr v795 v801 
    let _run_target_args'_v800 = v802 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v803 : string = "String::from($0)"
    let v804 : std_string_String = Fable.Core.RustInterop.emitRustExpr v795 v803 
    let _run_target_args'_v800 = v804 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v805 : string = "String::from($0)"
    let v806 : std_string_String = Fable.Core.RustInterop.emitRustExpr v795 v805 
    let _run_target_args'_v800 = v806 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v808 : std_string_String = v795 |> unbox<std_string_String>
    let _run_target_args'_v800 = v808 
    #endif
#if FABLE_COMPILER_PYTHON
    let v812 : std_string_String = v795 |> unbox<std_string_String>
    let _run_target_args'_v800 = v812 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v816 : std_string_String = v795 |> unbox<std_string_String>
    let _run_target_args'_v800 = v816 
    #endif
#else
    let v820 : std_string_String = v795 |> unbox<std_string_String>
    let _run_target_args'_v800 = v820 
    #endif
    let v823 : std_string_String = _run_target_args'_v800 
    let v832 : string = "fable_library_rust::String_::fromString($0)"
    let v833 : string = Fable.Core.RustInterop.emitRustExpr v823 v832 
    let _run_target_args'_v713 = v833 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v834 : string = "\u001b[0m"
    let _run_target_args'_v713 = v834 
    #endif
#if FABLE_COMPILER_PYTHON
    let v835 : string = "\u001b[0m"
    let _run_target_args'_v713 = v835 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v836 : string = "\u001b[0m"
    let _run_target_args'_v713 = v836 
    #endif
#else
    let v837 : string = "\u001b[0m"
    let _run_target_args'_v713 = v837 
    #endif
    let v838 : string = _run_target_args'_v713 
    let v842 : string = v709 + v838 
    v842
and method14 (v0 : string) : string =
    let v1 : string = method12()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v12 : unit = ()
    let v13 : (unit -> unit) = closure8(v2, v4)
    let v14 : unit = (fun () -> v13 (); v12) ()
    let v20 : string = v2.l0
    v20
and method15 (v0 : string) : string =
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
and method13 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method14(v9)
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
    let v42 : string = v38 + v8 
    let v47 : string = " / "
    let v48 : string = v42 + v47 
    let v52 : string = v48 + v10 
    method15(v52)
and closure9 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure11 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure10 () (v0 : string) : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure11(v0)
    let v4 : unit = (fun () -> v3 (); v2) ()
    ()
and closure6 (v0 : US0, v1 : (unit -> string), v2 : (unit -> string)) () : unit =
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure0()
    let v19 : unit = (fun () -> v18 (); v17) ()
    let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
    let v60 : US0 = v46.l0
    let v61 : bool = v44.l0
    let v62 : bool = v61 = false
    let v66 : bool =
        if v62 then
            false
        else
            let v63 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v0
            let v64 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v60
            let v65 : bool = v63 >= v64
            v65
    let v67 : bool = v66 = false
    let v306 : US6 =
        if v67 then
            US6_1
        else
            let v83 : unit = ()
            let v84 : unit = (fun () -> v18 (); v83) ()
            let struct (v107 : Mut0, v108 : Mut1, v109 : Mut2, v110 : Mut3, v111 : Mut4, v112 : int64 option) = TraceState.trace_state.Value
            let v125 : string = method6(v107, v108, v109, v110, v111, v112)
            let v126 : string = method10(v0)
            let v127 : string = v1 ()
            let v128 : bool = v127 = ""
            let v132 : string =
                if v128 then
                    let v129 : string = ""
                    v129
                else
                    let v130 : string = v2 ()
                    method13(v107, v108, v109, v110, v111, v112, v125, v126, v127, v130)
            let v147 : unit = ()
            let v148 : unit = (fun () -> v18 (); v147) ()
            let struct (v171 : Mut0, v172 : Mut1, v173 : Mut2, v174 : Mut3, v175 : Mut4, v176 : int64 option) = TraceState.trace_state.Value
            let v191 : unit = ()
            let v192 : (unit -> unit) = closure9(v171)
            let v193 : unit = (fun () -> v192 (); v191) ()
            let v196 : (string -> unit) = closure10()
            (* run_target_args'
            let v197 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v198 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v132 v198 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v199 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v132 v199 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v200 : string = v174.l0
            let v201 : bool = v200 = ""
            let v216 : string =
                if v201 then
                    v132
                else
                    let v202 : bool = v132 = ""
                    if v202 then
                        let v203 : string = v174.l0
                        v203
                    else
                        let v204 : string = v174.l0
                        let v207 : string = "\n"
                        let v208 : string = v204 + v207 
                        let v212 : string = v208 + v132 
                        v212
            (* run_target_args'
            let v221 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v222 : string = "&*$0"
            let v223 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v216 v222 
            let _run_target_args'_v221 = v223 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v224 : string = "&*$0"
            let v225 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v216 v224 
            let _run_target_args'_v221 = v225 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v226 : string = "&*$0"
            let v227 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v216 v226 
            let _run_target_args'_v221 = v227 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v229 : Ref<Str> = v216 |> unbox<Ref<Str>>
            let _run_target_args'_v221 = v229 
            #endif
#if FABLE_COMPILER_PYTHON
            let v233 : Ref<Str> = v216 |> unbox<Ref<Str>>
            let _run_target_args'_v221 = v233 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v237 : Ref<Str> = v216 |> unbox<Ref<Str>>
            let _run_target_args'_v221 = v237 
            #endif
#else
            let v241 : Ref<Str> = v216 |> unbox<Ref<Str>>
            let _run_target_args'_v221 = v241 
            #endif
            let v244 : Ref<Str> = _run_target_args'_v221 
            let v253 : string = $"$0.chars()"
            let v254 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v244 v253 
            let v255 : string = "$0"
            let v256 : _ = Fable.Core.RustInterop.emitRustExpr v254 v255 
            let v257 : string = "$0.collect::<Vec<_>>()"
            let v258 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v256 v257 
            let v259 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v260 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v262 : bool = Fable.Core.RustInterop.emitRustExpr v260 v261 
            let v263 : string = "x"
            let v264 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v263 
            let v265 : string = "String::from_iter($0)"
            let v266 : std_string_String = Fable.Core.RustInterop.emitRustExpr v264 v265 
            let v267 : string = "true; $0 }).collect::<Vec<_>>()"
            let v268 : bool = Fable.Core.RustInterop.emitRustExpr v266 v267 
            let v269 : string = "_vec_map"
            let v270 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v269 
            let v271 : string = "$0.len()"
            let v272 : unativeint = Fable.Core.RustInterop.emitRustExpr v270 v271 
            let v278 : int32 = v272 |> int32 
            let v288 : string = ""
            let v289 : bool = v132 <> v288 
            let v293 : bool =
                if v289 then
                    let v292 : bool = v278 <= 1
                    v292
                else
                    false
            if v293 then
                v174.l0 <- v216
                ()
            else
                v174.l0 <- v288
                let v294 : string = "true; $0.into_iter().for_each(|x| { //"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr v270 v294 
                let v296 : string = "x"
                let v297 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v296 
                let v298 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v299 : bool = Fable.Core.RustInterop.emitRustExpr v297 v298 
                let v300 : string = $"true"
                let v301 : bool = Fable.Core.RustInterop.emitRustExpr () v300 
                let v302 : string = "true; }); //"
                let v303 : bool = Fable.Core.RustInterop.emitRustExpr () v302 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v196 v132
            #endif
#if FABLE_COMPILER_PYTHON
            v196 v132
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v196 v132
            #endif
#else
            v196 v132
            #endif
            // run_target_args' is_unit
            let v304 : (string -> unit) = v172.l0
            v304 v132
            US6_0(v171, v172, v173, v174, v175, v176)
    
    ()
and closure5 (v0 : US0, v1 : (unit -> string)) (v2 : (unit -> string)) : unit =
    let v320 : unit = ()
    let v321 : (unit -> unit) = closure6(v0, v1, v2)
    let v322 : unit = (fun () -> v321 (); v320) ()
    ()
and closure4 (v0 : US0) (v1 : (unit -> string)) : ((unit -> string) -> unit) =
    closure5(v0, v1)
and closure3 () (v0 : US0) : ((unit -> string) -> ((unit -> string) -> unit)) =
    closure4(v0)
let v14 : unit = ()
let v15 : (unit -> unit) = closure0()
let v16 : unit = (fun () -> v15 (); v14) ()
let v31 : (US0 -> ((unit -> string) -> ((unit -> string) -> unit))) = closure3()
let trace x = v31 x
()
