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

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::sync::Arc<$0>")>]
#endif
type std_sync_Arc<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::sync::Mutex<$0>")>]
#endif
type std_sync_Mutex<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::process::ChildStdin")>]
#endif
type std_process_ChildStdin = class end
#if FABLE_COMPILER
[<CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module System =
 module Diagnostics =
  type Process = bool
  type DataReceivedEventArgs = bool
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
    | US6_0 of f0_0 : string * f0_1 : US5
    | US6_1 of f1_0 : string
and [<Struct>] US7 =
    | US7_0 of f0_0 : char * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US7_1 of f1_0 : string
and UH0 =
    | UH0_0
    | UH0_1 of char * UH0
and UH1 =
    | UH1_0
    | UH1_1 of (struct (string * System.Text.StringBuilder * int32 * int32) -> US7) * UH1
and [<Struct>] US8 =
    | US8_0 of f0_0 : string * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US8_1 of f1_0 : string
and [<Struct>] US9 =
    | US9_0 of f0_0 : char
    | US9_1
and [<Struct>] US10 =
    | US10_0 of f0_0 : string * f0_1 : System.Text.StringBuilder * f0_2 : int32 * f0_3 : int32
    | US10_1 of f1_0 : string
and [<Struct>] US11 =
    | US11_0 of f0_0 : string * f0_1 : US5 * f0_2 : string * f0_3 : System.Text.StringBuilder * f0_4 : int32 * f0_5 : int32
    | US11_1 of f1_0 : string
and [<Struct>] US12 =
    | US12_0 of f0_0 : US9 * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US12_1 of f1_0 : string
and [<Struct>] US13 =
    | US13_0 of f0_0 : US5 * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US13_1 of f1_0 : string
and Mut5 = {mutable l0 : int32}
and [<Struct>] US14 =
    | US14_0 of f0_0 : (struct (int32 * string * bool) -> Async<unit>)
    | US14_1
and [<Struct>] US15 =
    | US15_0 of f0_0 : System.Threading.CancellationToken
    | US15_1
and Heap0 = {l0 : string; l1 : System.Threading.CancellationToken option; l2 : (struct (string * string) []); l3 : (struct (int32 * string * bool) -> Async<unit>) option; l4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option; l5 : bool; l6 : string option}
and [<Struct>] US16 =
    | US16_0 of f0_0 : (string [])
    | US16_1 of f1_0 : string
and UH2 =
    | UH2_0
    | UH2_1 of string * UH2
and [<Struct>] US17 =
    | US17_0 of f0_0 : UH2 * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US17_1 of f1_0 : string
and UH3 =
    | UH3_0
    | UH3_1 of (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) * UH3
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
    let v73 : US5 = US5_1
    let v74 : US5 = v53 |> Option.defaultValue v73 
    let v81 : string =
        match v74 with
        | US5_1 -> (* None *)
            let v79 : string = ""
            v79
        | US5_0(v78) -> (* Some *)
            v78
    let _run_target_args'_v5 = v81 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v82 : US3 = US3_1
    let v83 : US4 = US4_1(v82)
    let v84 : string = $"env.get_environment_variable / target: {v83} / var: {v0}"
    let v85 : string = failwith<string> v84
    let _run_target_args'_v5 = v85 
    #endif
#else
    let v86 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v87 : string = v86 v0
    let mutable _v87 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v89 : (string -> string option) = Option.ofObj
    let v90 : string option = v89 v87
    v90 
    #else
    Some v87 
    #endif
    |> fun x -> _v87 <- Some x
    let v91 : string option = match _v87 with Some x -> x | None -> failwith "optionm'.of_obj / _v87=None"
    let v96 : (string -> US5) = method5()
    let v97 : US5 option = v91 |> Option.map v96 
    let v117 : US5 = US5_1
    let v118 : US5 = v97 |> Option.defaultValue v117 
    let v125 : string =
        match v118 with
        | US5_1 -> (* None *)
            let v123 : string = ""
            v123
        | US5_0(v122) -> (* Some *)
            v122
    let _run_target_args'_v5 = v125 
    #endif
    let v126 : string = _run_target_args'_v5 
    v126
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
and method7 (v0 : US0) : bool =
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
    let v173 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v176 : (int64 -> US2) = method9()
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
    let v318 : string = method10()
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
    let v343 : (int64 -> US2) = method9()
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
    let v485 : string = method10()
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
    let v512 : (int64 -> US2) = method9()
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
    let v559 : (int64 -> US2) = method9()
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
    let v701 : string = method11()
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
    let v726 : (int64 -> US2) = method9()
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
    let v868 : string = method11()
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
    let v893 : (int64 -> US2) = method9()
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
    let v1035 : string = method11()
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
    let v1060 : (int64 -> US2) = method9()
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
    let v1202 : string = method11()
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
and method14 () : string =
    let v0 : string = ""
    v0
and closure7 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and method13 (v0 : char) : string =
    let v1 : string = method14()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure7(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = v2.l0
    v12
and method15 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method12 () : string =
    
    
    
    
    
    let v2 : string = "Warning"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method13(v7)
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
    let v138 : string = method15()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[93m"
    let v142 : string = method15()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[93m"
    let v146 : string = method15()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[93m"
    let v150 : string = method15()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method17 () : string =
    let v0 : string = method14()
    let v1 : Mut3 = {l0 = v0} : Mut3
    let v2 : string = v1.l0
    v2
and method18 (v0 : string) : string =
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
and method16 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string) : string =
    let v8 : string = method17()
    let v9 : int64 = v0.l0
    let v11 : string = "runtime.current_process_kill / exiting... 3"
    let v12 : string = $"{v6} {v7} #{v9} %s{v11} / {v8}"
    method18(v12)
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
and method19 (v0 : string) : unit =
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
and closure5 () () : unit =
    let v0 : US0 = US0_3
    let v1 : bool = method7(v0)
    if v1 then
        let v2 : unit = ()
        let v3 : (unit -> unit) = closure0()
        let v4 : unit = (fun () -> v3 (); v2) ()
        let struct (v25 : Mut0, v26 : Mut1, v27 : Mut2, v28 : Mut3, v29 : Mut4, v30 : int64 option) = TraceState.trace_state.Value
        let v43 : string = method8(v25, v26, v27, v28, v29, v30)
        let v44 : string = method12()
        let v45 : string = method16(v25, v26, v27, v28, v29, v30, v43, v44)
        method19(v45)
and method20 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string) : string =
    let v8 : string = method17()
    let v9 : int64 = v0.l0
    let v11 : string = "runtime.current_process_kill / exiting... 2"
    let v12 : string = $"{v6} {v7} #{v9} %s{v11} / {v8}"
    method18(v12)
and closure11 () () : unit =
    let v0 : US0 = US0_3
    let v1 : bool = method7(v0)
    if v1 then
        let v2 : unit = ()
        let v3 : (unit -> unit) = closure0()
        let v4 : unit = (fun () -> v3 (); v2) ()
        let struct (v25 : Mut0, v26 : Mut1, v27 : Mut2, v28 : Mut3, v29 : Mut4, v30 : int64 option) = TraceState.trace_state.Value
        let v43 : string = method8(v25, v26, v27, v28, v29, v30)
        let v44 : string = method12()
        let v45 : string = method20(v25, v26, v27, v28, v29, v30, v43, v44)
        method19(v45)
and method21 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string) : string =
    let v8 : string = method17()
    let v9 : int64 = v0.l0
    let v11 : string = "runtime.current_process_kill / exiting... 1"
    let v12 : string = $"{v6} {v7} #{v9} %s{v11} / {v8}"
    method18(v12)
and closure12 () () : unit =
    let v0 : US0 = US0_3
    let v1 : bool = method7(v0)
    if v1 then
        let v2 : unit = ()
        let v3 : (unit -> unit) = closure0()
        let v4 : unit = (fun () -> v3 (); v2) ()
        let struct (v25 : Mut0, v26 : Mut1, v27 : Mut2, v28 : Mut3, v29 : Mut4, v30 : int64 option) = TraceState.trace_state.Value
        let v43 : string = method8(v25, v26, v27, v28, v29, v30)
        let v44 : string = method12()
        let v45 : string = method21(v25, v26, v27, v28, v29, v30, v43, v44)
        method19(v45)
and closure4 () () : unit =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    #endif
#if FABLE_COMPILER_RUST && WASM
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    #endif
#if FABLE_COMPILER_PYTHON
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    #endif
#else
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure5()
    let v3 : unit = (fun () -> v2 (); v1) ()
    System.Threading.Thread.Sleep 300
    let v50 : unit = ()
    let v51 : (unit -> unit) = closure11()
    let v52 : unit = (fun () -> v51 (); v50) ()
    System.Console.Out.Flush ()
    System.Threading.Thread.Sleep 60
    let v99 : unit = ()
    let v100 : (unit -> unit) = closure12()
    let v101 : unit = (fun () -> v100 (); v99) ()
    System.Diagnostics.Process.GetCurrentProcess().Kill ()
    #endif
    // run_target_args' is_unit
    ()
and method6 () : unit =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    #endif
#if FABLE_COMPILER_RUST && WASM
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    #endif
#if FABLE_COMPILER_PYTHON
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    #endif
#else
    let v1 : (unit -> unit) = closure4()
    let v2 : System.Threading.Thread = new System.Threading.Thread (v1)
    let v3 : (System.Threading.Thread -> unit) = _.Start()
    v3 v2
    #endif
    // run_target_args' is_unit
    ()
and closure3 () () : unit =
    method6()
and method26 () : string =
    let v0 : string = ""
    v0
and method27 (v0 : int64, v1 : string, v2 : int64) : UH0 =
    let v3 : bool = v2 < v0
    if v3 then
        let v4 : char = v1.[int v2]
        let v5 : int64 = v2 + 1L
        let v6 : UH0 = method27(v0, v1, v5)
        UH0_1(v4, v6)
    else
        UH0_0
and method28 (v0 : UH0, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : struct (System.Text.StringBuilder * int32 * int32) =
    match v0 with
    | UH0_1(v4, v5) -> (* Cons *)
        let v6 : bool = '\n' = v4
        let struct (v9 : int32, v10 : int32) =
            if v6 then
                let v7 : int32 = v2 + 1
                struct (v7, 1)
            else
                let v8 : int32 = v3 + 1
                struct (v2, v8)
        let v27 : System.Text.StringBuilder =
            if v6 then
                let v12 : (unit -> System.Text.StringBuilder) = v1.Clear
                let v13 : System.Text.StringBuilder = v12 ()
                v1
            else
                let v18 : (char -> string) = _.ToString()
                let v19 : string = v18 v4
                let v23 : (string -> System.Text.StringBuilder) = v1.Append
                let v24 : System.Text.StringBuilder = v23 v19
                v1
        method28(v5, v27, v9, v10)
    | UH0_0 -> (* Nil *)
        struct (v1, v2, v3)
and closure15 (v0 : int32, v1 : int32) (v2 : string) : string =
    let v3 : bool = v1 >= v0
    if v3 then
        v2
    else
        let v4 : int32 = v1 + 1
        let v5 : (string -> string) = method29(v0, v4)
        let v8 : string = " "
        let v9 : string = v2 + v8 
        v5 v9
and method29 (v0 : int32, v1 : int32) : (string -> string) =
    closure15(v0, v1)
and closure14 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US7 =
    let v4 : bool = "" = v0
    if v4 then
        let v6 : string = $"parsing.p_char / unexpected end of input / c: '{'"'}' / s: %A{struct (v1, v2, v3)}"
        US7_1(v6)
    else
        let v10 : char = v0.[int 0]
        let v11 : bool = v10 = '"'
        if v11 then
            let v13 : (string -> int32) = String.length
            let v14 : int32 = v13 v0
            let v22 : int32 = 1 |> int32 
            let v35 : int32 = v14 |> int32 
            let v43 : int32 = v35 - 1
            let v45 : string = v0.[int v22..int v43]
            let v50 : (char -> string) = _.ToString()
            let v51 : string = v50 v10
            let v54 : int64 = System.Convert.ToInt64 v51.Length
            let v55 : int64 = 0L
            let v56 : UH0 = method27(v54, v51, v55)
            let struct (v57 : System.Text.StringBuilder, v58 : int32, v59 : int32) = method28(v56, v1, v2, v3)
            US7_0(v10, v45, v57, v58, v59)
        else
            let v62 : string = "\n"
            let v63 : int32 = v0.IndexOf v62 
            let v66 : int32 = v63 - 1
            let v67 : bool = -2 = v66
            let v75 : int32 =
                if v67 then
                    let v69 : (string -> int32) = String.length
                    let v70 : int32 = v69 v0
                    let v73 : int32 = v70 + 1
                    v73
                else
                    let v74 : int32 = v66 + 1
                    v74
            let v81 : int32 = 0 |> int32 
            let v94 : int32 = v75 |> int32 
            let v102 : int32 = v94 - 1
            let v104 : string = v0.[int v81..int v102]
            let v109 : string = $"parsing.p_char / expected: '{'"'}' / line: {v2} / col: {v3}
{v1}{v104}"
            let v112 : int32 = v3 - 1
            let v113 : int32 = 0
            let v114 : (string -> string) = method29(v112, v113)
            let v115 : string = ""
            let v116 : string = v114 v115
            let v117 : string = "^"
            let v118 : string = v116 + v117 
            let v120 : string = $"{v109}
{v118}
"
            US7_1(v120)
and closure16 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US7 =
    let v4 : bool = "" = v0
    if v4 then
        let v6 : string = $"parsing.p_char / unexpected end of input / c: '{'''}' / s: %A{struct (v1, v2, v3)}"
        US7_1(v6)
    else
        let v10 : char = v0.[int 0]
        let v11 : bool = v10 = '''
        if v11 then
            let v13 : (string -> int32) = String.length
            let v14 : int32 = v13 v0
            let v22 : int32 = 1 |> int32 
            let v35 : int32 = v14 |> int32 
            let v43 : int32 = v35 - 1
            let v45 : string = v0.[int v22..int v43]
            let v50 : (char -> string) = _.ToString()
            let v51 : string = v50 v10
            let v54 : int64 = System.Convert.ToInt64 v51.Length
            let v55 : int64 = 0L
            let v56 : UH0 = method27(v54, v51, v55)
            let struct (v57 : System.Text.StringBuilder, v58 : int32, v59 : int32) = method28(v56, v1, v2, v3)
            US7_0(v10, v45, v57, v58, v59)
        else
            let v62 : string = "\n"
            let v63 : int32 = v0.IndexOf v62 
            let v66 : int32 = v63 - 1
            let v67 : bool = -2 = v66
            let v75 : int32 =
                if v67 then
                    let v69 : (string -> int32) = String.length
                    let v70 : int32 = v69 v0
                    let v73 : int32 = v70 + 1
                    v73
                else
                    let v74 : int32 = v66 + 1
                    v74
            let v81 : int32 = 0 |> int32 
            let v94 : int32 = v75 |> int32 
            let v102 : int32 = v94 - 1
            let v104 : string = v0.[int v81..int v102]
            let v109 : string = $"parsing.p_char / expected: '{'''}' / line: {v2} / col: {v3}
{v1}{v104}"
            let v112 : int32 = v3 - 1
            let v113 : int32 = 0
            let v114 : (string -> string) = method29(v112, v113)
            let v115 : string = ""
            let v116 : string = v114 v115
            let v117 : string = "^"
            let v118 : string = v116 + v117 
            let v120 : string = $"{v109}
{v118}
"
            US7_1(v120)
and method30 (v0 : string, v1 : System.Text.StringBuilder, v2 : UH1) : US7 =
    match v2 with
    | UH1_1(v5, v6) -> (* Cons *)
        let v7 : US7 = v5 struct (v0, v1, 1, 1)
        match v7 with
        | US7_1(v13) -> (* Error *)
            method30(v0, v1, v6)
        | US7_0(v8, v9, v10, v11, v12) -> (* Ok *)
            v7
    | UH1_0 -> (* Nil *)
        let v3 : string = "parsing.choice / no parsers succeeded"
        US7_1(v3)
and method31 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 2L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v11 : US9 =
            if v3 then
                US9_0('"')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US9_0(''')
                else
                    let v8 : int64 = v5 - 1L
                    US9_1
        let v15 : char =
            match v11 with
            | US9_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US9_0(v12) -> (* Some *)
                v12
        let v16 : bool = v0 = v15
        if v16 then
            true
        else
            let v17 : int64 = v1 + 1L
            method31(v0, v17)
and method32 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v98 : US7 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = ''' :: v6 
            let v12 : char list = '"' :: v8 
            let v16 : (char list -> (char [])) = List.toArray
            let v17 : (char []) = v16 v12
            let v21 : string = $"parsing.none_of / unexpected end of input / chars: %A{v17} / s: %A{struct (v2, v3, v4)}"
            US7_1(v21)
        else
            let v25 : char = v1.[int 0]
            let v26 : int64 = 0L
            let v27 : bool = method31(v25, v26)
            let v28 : bool = v27 = false
            if v28 then
                let v30 : (string -> int32) = String.length
                let v31 : int32 = v30 v1
                let v39 : int32 = 1 |> int32 
                let v52 : int32 = v31 |> int32 
                let v60 : int32 = v52 - 1
                let v62 : string = v1.[int v39..int v60]
                let v67 : (char -> string) = _.ToString()
                let v68 : string = v67 v25
                let v71 : int64 = System.Convert.ToInt64 v68.Length
                let v72 : int64 = 0L
                let v73 : UH0 = method27(v71, v68, v72)
                let struct (v74 : System.Text.StringBuilder, v75 : int32, v76 : int32) = method28(v73, v2, v3, v4)
                US7_0(v25, v62, v74, v75, v76)
            else
                let v78 : char list = []
                let v80 : char list = ''' :: v78 
                let v84 : char list = '"' :: v80 
                let v88 : (char list -> (char [])) = List.toArray
                let v89 : (char []) = v88 v84
                let v93 : string = $"parsing.none_of / unexpected char: '{v25}' / chars: %A{v89} / s: %A{struct (v2, v3, v4)}"
                US7_1(v93)
    let v110 : US7 =
        match v98 with
        | US7_1(v107) -> (* Error *)
            US7_1(v107)
        | US7_0(v99, v100, v101, v102, v103) -> (* Ok *)
            let v104 : bool = '\\' = v99
            let v105 : char =
                if v104 then
                    '/'
                else
                    v99
            US7_0(v105, v100, v101, v102, v103)
    match v110 with
    | US7_1(v127) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v111, v112, v113, v114, v115) -> (* Ok *)
        let v117 : (char -> string) = _.ToString()
        let v118 : string = v117 v111
        let v121 : string = v0 + v118 
        method32(v121, v112, v113, v114, v115)
and method33 (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32, v4 : UH1) : US7 =
    match v4 with
    | UH1_1(v7, v8) -> (* Cons *)
        let v9 : US7 = v7 struct (v0, v1, v2, v3)
        match v9 with
        | US7_1(v15) -> (* Error *)
            method33(v0, v1, v2, v3, v8)
        | US7_0(v10, v11, v12, v13, v14) -> (* Ok *)
            v9
    | UH1_0 -> (* Nil *)
        let v5 : string = "parsing.choice / no parsers succeeded"
        US7_1(v5)
and method34 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 3L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v15 : US9 =
            if v3 then
                US9_0('"')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US9_0(''')
                else
                    let v8 : int64 = v5 - 1L
                    let v9 : bool = v8 = 0L
                    if v9 then
                        US9_0(' ')
                    else
                        let v11 : int64 = v8 - 1L
                        US9_1
        let v19 : char =
            match v15 with
            | US9_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US9_0(v16) -> (* Some *)
                v16
        let v20 : bool = v0 = v19
        if v20 then
            true
        else
            let v21 : int64 = v1 + 1L
            method34(v0, v21)
and method35 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v106 : US7 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = ' ' :: v6 
            let v12 : char list = ''' :: v8 
            let v16 : char list = '"' :: v12 
            let v20 : (char list -> (char [])) = List.toArray
            let v21 : (char []) = v20 v16
            let v25 : string = $"parsing.none_of / unexpected end of input / chars: %A{v21} / s: %A{struct (v2, v3, v4)}"
            US7_1(v25)
        else
            let v29 : char = v1.[int 0]
            let v30 : int64 = 0L
            let v31 : bool = method34(v29, v30)
            let v32 : bool = v31 = false
            if v32 then
                let v34 : (string -> int32) = String.length
                let v35 : int32 = v34 v1
                let v43 : int32 = 1 |> int32 
                let v56 : int32 = v35 |> int32 
                let v64 : int32 = v56 - 1
                let v66 : string = v1.[int v43..int v64]
                let v71 : (char -> string) = _.ToString()
                let v72 : string = v71 v29
                let v75 : int64 = System.Convert.ToInt64 v72.Length
                let v76 : int64 = 0L
                let v77 : UH0 = method27(v75, v72, v76)
                let struct (v78 : System.Text.StringBuilder, v79 : int32, v80 : int32) = method28(v77, v2, v3, v4)
                US7_0(v29, v66, v78, v79, v80)
            else
                let v82 : char list = []
                let v84 : char list = ' ' :: v82 
                let v88 : char list = ''' :: v84 
                let v92 : char list = '"' :: v88 
                let v96 : (char list -> (char [])) = List.toArray
                let v97 : (char []) = v96 v92
                let v101 : string = $"parsing.none_of / unexpected char: '{v29}' / chars: %A{v97} / s: %A{struct (v2, v3, v4)}"
                US7_1(v101)
    let v118 : US7 =
        match v106 with
        | US7_1(v115) -> (* Error *)
            US7_1(v115)
        | US7_0(v107, v108, v109, v110, v111) -> (* Ok *)
            let v112 : bool = '\\' = v107
            let v113 : char =
                if v112 then
                    '/'
                else
                    v107
            US7_0(v113, v108, v109, v110, v111)
    match v118 with
    | US7_1(v135) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v119, v120, v121, v122, v123) -> (* Ok *)
        let v125 : (char -> string) = _.ToString()
        let v126 : string = v125 v119
        let v129 : string = v0 + v126 
        method35(v129, v120, v121, v122, v123)
and method36 (v0 : string, v1 : int32) : int32 =
    let v2 : int32 = v0.Length
    let v3 : bool = v1 >= v2
    if v3 then
        v1
    else
        let v4 : char = v0.[int v1]
        let v5 : bool = ' ' = v4
        if v5 then
            let v6 : int32 = v1 + 1
            method36(v0, v6)
        else
            v1
and method37 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v66 : US7 =
        if v5 then
            let v12 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v2, v3, v4)}"
            US7_1(v12)
        else
            let v16 : char = v1.[int 0]
            let v18 : (string -> int32) = String.length
            let v19 : int32 = v18 v1
            let v27 : int32 = 1 |> int32 
            let v40 : int32 = v19 |> int32 
            let v48 : int32 = v40 - 1
            let v50 : string = v1.[int v27..int v48]
            let v55 : (char -> string) = _.ToString()
            let v56 : string = v55 v16
            let v59 : int64 = System.Convert.ToInt64 v56.Length
            let v60 : int64 = 0L
            let v61 : UH0 = method27(v59, v56, v60)
            let struct (v62 : System.Text.StringBuilder, v63 : int32, v64 : int32) = method28(v61, v2, v3, v4)
            US7_0(v16, v50, v62, v63, v64)
    match v66 with
    | US7_1(v83) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v67, v68, v69, v70, v71) -> (* Ok *)
        let v73 : (char -> string) = _.ToString()
        let v74 : string = v73 v67
        let v77 : string = v0 + v74 
        method37(v77, v68, v69, v70, v71)
and method25 (v0 : string) : US6 =
    let mutable _v0 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v2 : (string -> string option) = Option.ofObj
    let v3 : string option = v2 v0
    v3 
    #else
    Some v0 
    #endif
    |> fun x -> _v0 <- Some x
    let v4 : string option = match _v0 with Some x -> x | None -> failwith "optionm'.of_obj / _v0=None"
    let v9 : string = ""
    let v10 : string = v4 |> Option.defaultValue v9 
    let v13 : string = method26()
    let v15 : (string -> System.Text.StringBuilder) = System.Text.StringBuilder 
    let v16 : System.Text.StringBuilder = v15 v13
    let v19 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US7) = closure14()
    let v20 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US7) = closure16()
    let v21 : UH1 = UH1_0
    let v22 : UH1 = UH1_1(v20, v21)
    let v23 : UH1 = UH1_1(v19, v22)
    let v24 : US7 = method30(v10, v16, v23)
    let v197 : US8 =
        match v24 with
        | US7_1(v194) -> (* Error *)
            US8_1(v194)
        | US7_0(v25, v26, v27, v28, v29) -> (* Ok *)
            let v30 : bool = "" = v26
            let v123 : US7 =
                if v30 then
                    let v31 : char list = []
                    let v33 : char list = ''' :: v31 
                    let v37 : char list = '"' :: v33 
                    let v41 : (char list -> (char [])) = List.toArray
                    let v42 : (char []) = v41 v37
                    let v46 : string = $"parsing.none_of / unexpected end of input / chars: %A{v42} / s: %A{struct (v27, v28, v29)}"
                    US7_1(v46)
                else
                    let v50 : char = v26.[int 0]
                    let v51 : int64 = 0L
                    let v52 : bool = method31(v50, v51)
                    let v53 : bool = v52 = false
                    if v53 then
                        let v55 : (string -> int32) = String.length
                        let v56 : int32 = v55 v26
                        let v64 : int32 = 1 |> int32 
                        let v77 : int32 = v56 |> int32 
                        let v85 : int32 = v77 - 1
                        let v87 : string = v26.[int v64..int v85]
                        let v92 : (char -> string) = _.ToString()
                        let v93 : string = v92 v50
                        let v96 : int64 = System.Convert.ToInt64 v93.Length
                        let v97 : int64 = 0L
                        let v98 : UH0 = method27(v96, v93, v97)
                        let struct (v99 : System.Text.StringBuilder, v100 : int32, v101 : int32) = method28(v98, v27, v28, v29)
                        US7_0(v50, v87, v99, v100, v101)
                    else
                        let v103 : char list = []
                        let v105 : char list = ''' :: v103 
                        let v109 : char list = '"' :: v105 
                        let v113 : (char list -> (char [])) = List.toArray
                        let v114 : (char []) = v113 v109
                        let v118 : string = $"parsing.none_of / unexpected char: '{v50}' / chars: %A{v114} / s: %A{struct (v27, v28, v29)}"
                        US7_1(v118)
            let v135 : US7 =
                match v123 with
                | US7_1(v132) -> (* Error *)
                    US7_1(v132)
                | US7_0(v124, v125, v126, v127, v128) -> (* Ok *)
                    let v129 : bool = '\\' = v124
                    let v130 : char =
                        if v129 then
                            '/'
                        else
                            v124
                    US7_0(v130, v125, v126, v127, v128)
            let v155 : US8 =
                match v135 with
                | US7_1(v152) -> (* Error *)
                    US8_1(v152)
                | US7_0(v136, v137, v138, v139, v140) -> (* Ok *)
                    let v142 : (char -> string) = _.ToString()
                    let v143 : string = v142 v136
                    let struct (v146 : string, v147 : string, v148 : System.Text.StringBuilder, v149 : int32, v150 : int32) = method32(v143, v137, v138, v139, v140)
                    US8_0(v146, v147, v148, v149, v150)
            let v165 : US8 =
                match v155 with
                | US8_1(v162) -> (* Error *)
                    US8_0(v9, v26, v27, v28, v29)
                | US8_0(v156, v157, v158, v159, v160) -> (* Ok *)
                    US8_0(v156, v157, v158, v159, v160)
            match v165 with
            | US8_1(v189) -> (* Error *)
                let v190 : string = "parsing.between / expected content"
                US8_1(v190)
            | US8_0(v166, v167, v168, v169, v170) -> (* Ok *)
                let v171 : UH1 = UH1_0
                let v172 : UH1 = UH1_1(v20, v171)
                let v173 : UH1 = UH1_1(v19, v172)
                let v174 : US7 = method33(v167, v168, v169, v170, v173)
                match v174 with
                | US7_1(v181) -> (* Error *)
                    let v183 : string = $"parsing.between / expected closing delimiter / e: %A{v181} / input: %A{struct (v10, v16, 1, 1)} / rest1: %A{struct (v26, v27, v28, v29)} / rest2: %A{struct (v167, v168, v169, v170)}"
                    US8_1(v183)
                | US7_0(v175, v176, v177, v178, v179) -> (* Ok *)
                    US8_0(v166, v176, v177, v178, v179)
    let v416 : US8 =
        match v197 with
        | US8_1(v203) -> (* Error *)
            let v204 : bool = "" = v10
            let v307 : US7 =
                if v204 then
                    let v205 : char list = []
                    let v207 : char list = ' ' :: v205 
                    let v211 : char list = ''' :: v207 
                    let v215 : char list = '"' :: v211 
                    let v219 : (char list -> (char [])) = List.toArray
                    let v220 : (char []) = v219 v215
                    let v224 : string = $"parsing.none_of / unexpected end of input / chars: %A{v220} / s: %A{struct (v16, 1, 1)}"
                    US7_1(v224)
                else
                    let v228 : char = v10.[int 0]
                    let v229 : int64 = 0L
                    let v230 : bool = method34(v228, v229)
                    let v231 : bool = v230 = false
                    if v231 then
                        let v233 : (string -> int32) = String.length
                        let v234 : int32 = v233 v10
                        let v242 : int32 = 1 |> int32 
                        let v255 : int32 = v234 |> int32 
                        let v263 : int32 = v255 - 1
                        let v265 : string = v10.[int v242..int v263]
                        let v270 : (char -> string) = _.ToString()
                        let v271 : string = v270 v228
                        let v274 : int64 = System.Convert.ToInt64 v271.Length
                        let v275 : int64 = 0L
                        let v276 : UH0 = method27(v274, v271, v275)
                        let v277 : int32 = 1
                        let v278 : int32 = 1
                        let struct (v279 : System.Text.StringBuilder, v280 : int32, v281 : int32) = method28(v276, v16, v277, v278)
                        US7_0(v228, v265, v279, v280, v281)
                    else
                        let v283 : char list = []
                        let v285 : char list = ' ' :: v283 
                        let v289 : char list = ''' :: v285 
                        let v293 : char list = '"' :: v289 
                        let v297 : (char list -> (char [])) = List.toArray
                        let v298 : (char []) = v297 v293
                        let v302 : string = $"parsing.none_of / unexpected char: '{v228}' / chars: %A{v298} / s: %A{struct (v16, 1, 1)}"
                        US7_1(v302)
            let v319 : US7 =
                match v307 with
                | US7_1(v316) -> (* Error *)
                    US7_1(v316)
                | US7_0(v308, v309, v310, v311, v312) -> (* Ok *)
                    let v313 : bool = '\\' = v308
                    let v314 : char =
                        if v313 then
                            '/'
                        else
                            v308
                    US7_0(v314, v309, v310, v311, v312)
            let v339 : US8 =
                match v319 with
                | US7_1(v336) -> (* Error *)
                    US8_1(v336)
                | US7_0(v320, v321, v322, v323, v324) -> (* Ok *)
                    let v326 : (char -> string) = _.ToString()
                    let v327 : string = v326 v320
                    let struct (v330 : string, v331 : string, v332 : System.Text.StringBuilder, v333 : int32, v334 : int32) = method35(v327, v321, v322, v323, v324)
                    US8_0(v330, v331, v332, v333, v334)
            match v339 with
            | US8_1(v345) -> (* Error *)
                let v346 : int32 = v10.Length
                let v347 : bool = v346 = 0
                let v354 : US10 =
                    if v347 then
                        US10_0(v10, v16, 1, 1)
                    else
                        let v350 : string = $"parsing.eof / expected end of input / input: %A{v10}"
                        US10_1(v350)
                let v363 : US8 =
                    match v354 with
                    | US10_1(v360) -> (* Error *)
                        US8_1(v360)
                    | US10_0(v355, v356, v357, v358) -> (* Ok *)
                        US8_0(v9, v355, v356, v357, v358)
                match v363 with
                | US8_1(v409) -> (* Error *)
                    US8_1(v409)
                | US8_0(v364, v365, v366, v367, v368) -> (* Ok *)
                    let v369 : int32 = 0
                    let v370 : int32 = method36(v365, v369)
                    let v372 : (string -> int32) = String.length
                    let v373 : int32 = v372 v365
                    let v381 : int32 = v370 |> int32 
                    let v394 : int32 = v373 |> int32 
                    let v402 : int32 = v394 - 1
                    let v404 : string = v365.[int v381..int v402]
                    US8_0(v364, v404, v366, v367, v368)
            | US8_0(v340, v341, v342, v343, v344) -> (* Ok *)
                v339
        | US8_0(v198, v199, v200, v201, v202) -> (* Ok *)
            v197
    let v671 : US11 =
        match v416 with
        | US8_1(v668) -> (* Error *)
            US11_1(v668)
        | US8_0(v417, v418, v419, v420, v421) -> (* Ok *)
            let v422 : bool = "" = v418
            let v542 : US7 =
                if v422 then
                    let v424 : string = $"parsing.p_char / unexpected end of input / c: '{' '}' / s: %A{struct (v419, v420, v421)}"
                    US7_1(v424)
                else
                    let v428 : char = v418.[int 0]
                    let v429 : bool = v428 = ' '
                    if v429 then
                        let v431 : (string -> int32) = String.length
                        let v432 : int32 = v431 v418
                        let v440 : int32 = 1 |> int32 
                        let v453 : int32 = v432 |> int32 
                        let v461 : int32 = v453 - 1
                        let v463 : string = v418.[int v440..int v461]
                        let v468 : (char -> string) = _.ToString()
                        let v469 : string = v468 v428
                        let v472 : int64 = System.Convert.ToInt64 v469.Length
                        let v473 : int64 = 0L
                        let v474 : UH0 = method27(v472, v469, v473)
                        let struct (v475 : System.Text.StringBuilder, v476 : int32, v477 : int32) = method28(v474, v419, v420, v421)
                        US7_0(v428, v463, v475, v476, v477)
                    else
                        let v480 : string = "\n"
                        let v481 : int32 = v418.IndexOf v480 
                        let v484 : int32 = v481 - 1
                        let v485 : bool = -2 = v484
                        let v493 : int32 =
                            if v485 then
                                let v487 : (string -> int32) = String.length
                                let v488 : int32 = v487 v418
                                let v491 : int32 = v488 + 1
                                v491
                            else
                                let v492 : int32 = v484 + 1
                                v492
                        let v499 : int32 = 0 |> int32 
                        let v512 : int32 = v493 |> int32 
                        let v520 : int32 = v512 - 1
                        let v522 : string = v418.[int v499..int v520]
                        let v527 : string = $"parsing.p_char / expected: '{' '}' / line: {v420} / col: {v421}
{v419}{v522}"
                        let v530 : int32 = v421 - 1
                        let v531 : int32 = 0
                        let v532 : (string -> string) = method29(v530, v531)
                        let v533 : string = v532 v9
                        let v534 : string = "^"
                        let v535 : string = v533 + v534 
                        let v537 : string = $"{v527}
{v535}
"
                        US7_1(v537)
            let v554 : US12 =
                match v542 with
                | US7_1(v550) -> (* Error *)
                    let v551 : US9 = US9_1
                    US12_0(v551, v418, v419, v420, v421)
                | US7_0(v543, v544, v545, v546, v547) -> (* Ok *)
                    let v548 : US9 = US9_0(v543)
                    US12_0(v548, v544, v545, v546, v547)
            let v645 : US8 =
                match v554 with
                | US12_1(v642) -> (* Error *)
                    US8_1(v642)
                | US12_0(v555, v556, v557, v558, v559) -> (* Ok *)
                    let v560 : bool = "" = v556
                    let v621 : US7 =
                        if v560 then
                            let v567 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v557, v558, v559)}"
                            US7_1(v567)
                        else
                            let v571 : char = v556.[int 0]
                            let v573 : (string -> int32) = String.length
                            let v574 : int32 = v573 v556
                            let v582 : int32 = 1 |> int32 
                            let v595 : int32 = v574 |> int32 
                            let v603 : int32 = v595 - 1
                            let v605 : string = v556.[int v582..int v603]
                            let v610 : (char -> string) = _.ToString()
                            let v611 : string = v610 v571
                            let v614 : int64 = System.Convert.ToInt64 v611.Length
                            let v615 : int64 = 0L
                            let v616 : UH0 = method27(v614, v611, v615)
                            let struct (v617 : System.Text.StringBuilder, v618 : int32, v619 : int32) = method28(v616, v557, v558, v559)
                            US7_0(v571, v605, v617, v618, v619)
                    match v621 with
                    | US7_1(v638) -> (* Error *)
                        US8_1(v638)
                    | US7_0(v622, v623, v624, v625, v626) -> (* Ok *)
                        let v628 : (char -> string) = _.ToString()
                        let v629 : string = v628 v622
                        let struct (v632 : string, v633 : string, v634 : System.Text.StringBuilder, v635 : int32, v636 : int32) = method37(v629, v623, v624, v625, v626)
                        US8_0(v632, v633, v634, v635, v636)
            let v657 : US13 =
                match v645 with
                | US8_1(v653) -> (* Error *)
                    let v654 : US5 = US5_1
                    US13_0(v654, v418, v419, v420, v421)
                | US8_0(v646, v647, v648, v649, v650) -> (* Ok *)
                    let v651 : US5 = US5_0(v646)
                    US13_0(v651, v647, v648, v649, v650)
            match v657 with
            | US13_1(v664) -> (* Error *)
                US11_1(v664)
            | US13_0(v658, v659, v660, v661, v662) -> (* Ok *)
                US11_0(v417, v658, v659, v660, v661, v662)
    match v671 with
    | US11_1(v679) -> (* Error *)
        US6_1(v679)
    | US11_0(v672, v673, v674, v675, v676, v677) -> (* Ok *)
        US6_0(v672, v673)
and method38 () : string =
    
    
    
    
    
    let v2 : string = "Debug"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method13(v7)
    (* run_target_args'
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "inline_colorization::color_bright_blue"
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
    let v55 : string = "inline_colorization::color_bright_blue"
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
    let v96 : string = "inline_colorization::color_bright_blue"
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
    let v137 : string = "\u001b[94m"
    let v138 : string = method15()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[94m"
    let v142 : string = method15()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[94m"
    let v146 : string = method15()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[94m"
    let v150 : string = method15()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method40 (v0 : string, v1 : US5, v2 : string, v3 : System.Threading.CancellationToken option, v4 : (struct (string * string) []), v5 : (struct (int32 * string * bool) -> Async<unit>) option, v6 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v7 : bool, v8 : string option) : string =
    let v9 : string = method14()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure7(v10, v14)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v24 : string = "file_name"
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure7(v10, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    let v35 : string = " = "
    let v36 : string = $"{v35}"
    let v39 : unit = ()
    let v40 : (unit -> unit) = closure7(v10, v36)
    let v41 : unit = (fun () -> v40 (); v39) ()
    let v45 : string = $"{v0}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure7(v10, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v55 : string = "; "
    let v56 : string = $"{v55}"
    let v59 : unit = ()
    let v60 : (unit -> unit) = closure7(v10, v56)
    let v61 : unit = (fun () -> v60 (); v59) ()
    let v66 : string = "arguments"
    let v67 : string = $"{v66}"
    let v70 : unit = ()
    let v71 : (unit -> unit) = closure7(v10, v67)
    let v72 : unit = (fun () -> v71 (); v70) ()
    let v76 : string = $"{v35}"
    let v79 : unit = ()
    let v80 : (unit -> unit) = closure7(v10, v76)
    let v81 : unit = (fun () -> v80 (); v79) ()
    let v85 : string = $"%A{v1}"
    let v89 : string = $"{v85}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure7(v10, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v98 : string = $"{v55}"
    let v101 : unit = ()
    let v102 : (unit -> unit) = closure7(v10, v98)
    let v103 : unit = (fun () -> v102 (); v101) ()
    let v108 : string = "options"
    let v109 : string = $"{v108}"
    let v112 : unit = ()
    let v113 : (unit -> unit) = closure7(v10, v109)
    let v114 : unit = (fun () -> v113 (); v112) ()
    let v118 : string = $"{v35}"
    let v121 : unit = ()
    let v122 : (unit -> unit) = closure7(v10, v118)
    let v123 : unit = (fun () -> v122 (); v121) ()
    let v127 : string = $"{v13}"
    let v130 : unit = ()
    let v131 : (unit -> unit) = closure7(v10, v127)
    let v132 : unit = (fun () -> v131 (); v130) ()
    let v137 : string = "command"
    let v138 : string = $"{v137}"
    let v141 : unit = ()
    let v142 : (unit -> unit) = closure7(v10, v138)
    let v143 : unit = (fun () -> v142 (); v141) ()
    let v147 : string = $"{v35}"
    let v150 : unit = ()
    let v151 : (unit -> unit) = closure7(v10, v147)
    let v152 : unit = (fun () -> v151 (); v150) ()
    let v156 : string = $"{v2}"
    let v159 : unit = ()
    let v160 : (unit -> unit) = closure7(v10, v156)
    let v161 : unit = (fun () -> v160 (); v159) ()
    let v165 : string = $"{v55}"
    let v168 : unit = ()
    let v169 : (unit -> unit) = closure7(v10, v165)
    let v170 : unit = (fun () -> v169 (); v168) ()
    let v175 : string = "cancellation_token"
    let v176 : string = $"{v175}"
    let v179 : unit = ()
    let v180 : (unit -> unit) = closure7(v10, v176)
    let v181 : unit = (fun () -> v180 (); v179) ()
    let v185 : string = $"{v35}"
    let v188 : unit = ()
    let v189 : (unit -> unit) = closure7(v10, v185)
    let v190 : unit = (fun () -> v189 (); v188) ()
    (* run_target_args'
    let v197 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v198 : string = "format!(\"{:#?}\", $0)"
    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v198 
    let v200 : string = "fable_library_rust::String_::fromString($0)"
    let v201 : string = Fable.Core.RustInterop.emitRustExpr v199 v200 
    let _run_target_args'_v197 = v201 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v202 : string = "format!(\"{:#?}\", $0)"
    let v203 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v202 
    let v204 : string = "fable_library_rust::String_::fromString($0)"
    let v205 : string = Fable.Core.RustInterop.emitRustExpr v203 v204 
    let _run_target_args'_v197 = v205 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v206 : string = "format!(\"{:#?}\", $0)"
    let v207 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v206 
    let v208 : string = "fable_library_rust::String_::fromString($0)"
    let v209 : string = Fable.Core.RustInterop.emitRustExpr v207 v208 
    let _run_target_args'_v197 = v209 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v211 : string = $"%A{v3}"
    let _run_target_args'_v197 = v211 
    #endif
#if FABLE_COMPILER_PYTHON
    let v215 : string = $"%A{v3}"
    let _run_target_args'_v197 = v215 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v219 : string = $"%A{v3}"
    let _run_target_args'_v197 = v219 
    #endif
#else
    let v223 : string = $"%A{v3}"
    let _run_target_args'_v197 = v223 
    #endif
    let v226 : string = _run_target_args'_v197 
    let v233 : string = $"{v226}"
    let v236 : unit = ()
    let v237 : (unit -> unit) = closure7(v10, v233)
    let v238 : unit = (fun () -> v237 (); v236) ()
    let v242 : string = $"{v55}"
    let v245 : unit = ()
    let v246 : (unit -> unit) = closure7(v10, v242)
    let v247 : unit = (fun () -> v246 (); v245) ()
    let v252 : string = "environment_variables"
    let v253 : string = $"{v252}"
    let v256 : unit = ()
    let v257 : (unit -> unit) = closure7(v10, v253)
    let v258 : unit = (fun () -> v257 (); v256) ()
    let v262 : string = $"{v35}"
    let v265 : unit = ()
    let v266 : (unit -> unit) = closure7(v10, v262)
    let v267 : unit = (fun () -> v266 (); v265) ()
    let v271 : string = $"%A{v4}"
    let v275 : string = $"{v271}"
    let v278 : unit = ()
    let v279 : (unit -> unit) = closure7(v10, v275)
    let v280 : unit = (fun () -> v279 (); v278) ()
    let v284 : string = $"{v55}"
    let v287 : unit = ()
    let v288 : (unit -> unit) = closure7(v10, v284)
    let v289 : unit = (fun () -> v288 (); v287) ()
    let v294 : string = "on_line"
    let v295 : string = $"{v294}"
    let v298 : unit = ()
    let v299 : (unit -> unit) = closure7(v10, v295)
    let v300 : unit = (fun () -> v299 (); v298) ()
    let v304 : string = $"{v35}"
    let v307 : unit = ()
    let v308 : (unit -> unit) = closure7(v10, v304)
    let v309 : unit = (fun () -> v308 (); v307) ()
    (* run_target_args'
    let v316 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v317 : string = "format!(\"{:#?}\", $0)"
    let v318 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v317 
    let v319 : string = "fable_library_rust::String_::fromString($0)"
    let v320 : string = Fable.Core.RustInterop.emitRustExpr v318 v319 
    let _run_target_args'_v316 = v320 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v321 : string = "format!(\"{:#?}\", $0)"
    let v322 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v321 
    let v323 : string = "fable_library_rust::String_::fromString($0)"
    let v324 : string = Fable.Core.RustInterop.emitRustExpr v322 v323 
    let _run_target_args'_v316 = v324 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v325 : string = "format!(\"{:#?}\", $0)"
    let v326 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v325 
    let v327 : string = "fable_library_rust::String_::fromString($0)"
    let v328 : string = Fable.Core.RustInterop.emitRustExpr v326 v327 
    let _run_target_args'_v316 = v328 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v330 : string = $"%A{v5}"
    let _run_target_args'_v316 = v330 
    #endif
#if FABLE_COMPILER_PYTHON
    let v334 : string = $"%A{v5}"
    let _run_target_args'_v316 = v334 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v338 : string = $"%A{v5}"
    let _run_target_args'_v316 = v338 
    #endif
#else
    let v342 : string = $"%A{v5}"
    let _run_target_args'_v316 = v342 
    #endif
    let v345 : string = _run_target_args'_v316 
    let v352 : string = $"{v345}"
    let v355 : unit = ()
    let v356 : (unit -> unit) = closure7(v10, v352)
    let v357 : unit = (fun () -> v356 (); v355) ()
    let v361 : string = $"{v55}"
    let v364 : unit = ()
    let v365 : (unit -> unit) = closure7(v10, v361)
    let v366 : unit = (fun () -> v365 (); v364) ()
    let v371 : string = "stdin"
    let v372 : string = $"{v371}"
    let v375 : unit = ()
    let v376 : (unit -> unit) = closure7(v10, v372)
    let v377 : unit = (fun () -> v376 (); v375) ()
    let v381 : string = $"{v35}"
    let v384 : unit = ()
    let v385 : (unit -> unit) = closure7(v10, v381)
    let v386 : unit = (fun () -> v385 (); v384) ()
    (* run_target_args'
    let v393 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v394 : string = "format!(\"{:#?}\", $0)"
    let v395 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v394 
    let v396 : string = "fable_library_rust::String_::fromString($0)"
    let v397 : string = Fable.Core.RustInterop.emitRustExpr v395 v396 
    let _run_target_args'_v393 = v397 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v398 : string = "format!(\"{:#?}\", $0)"
    let v399 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v398 
    let v400 : string = "fable_library_rust::String_::fromString($0)"
    let v401 : string = Fable.Core.RustInterop.emitRustExpr v399 v400 
    let _run_target_args'_v393 = v401 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v402 : string = "format!(\"{:#?}\", $0)"
    let v403 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v402 
    let v404 : string = "fable_library_rust::String_::fromString($0)"
    let v405 : string = Fable.Core.RustInterop.emitRustExpr v403 v404 
    let _run_target_args'_v393 = v405 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v407 : string = $"%A{v6}"
    let _run_target_args'_v393 = v407 
    #endif
#if FABLE_COMPILER_PYTHON
    let v411 : string = $"%A{v6}"
    let _run_target_args'_v393 = v411 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v415 : string = $"%A{v6}"
    let _run_target_args'_v393 = v415 
    #endif
#else
    let v419 : string = $"%A{v6}"
    let _run_target_args'_v393 = v419 
    #endif
    let v422 : string = _run_target_args'_v393 
    let v429 : string = $"{v422}"
    let v432 : unit = ()
    let v433 : (unit -> unit) = closure7(v10, v429)
    let v434 : unit = (fun () -> v433 (); v432) ()
    let v438 : string = $"{v55}"
    let v441 : unit = ()
    let v442 : (unit -> unit) = closure7(v10, v438)
    let v443 : unit = (fun () -> v442 (); v441) ()
    let v448 : string = "trace"
    let v449 : string = $"{v448}"
    let v452 : unit = ()
    let v453 : (unit -> unit) = closure7(v10, v449)
    let v454 : unit = (fun () -> v453 (); v452) ()
    let v458 : string = $"{v35}"
    let v461 : unit = ()
    let v462 : (unit -> unit) = closure7(v10, v458)
    let v463 : unit = (fun () -> v462 (); v461) ()
    let v468 : string =
        if v7 then
            let v466 : string = "true"
            v466
        else
            let v467 : string = "false"
            v467
    let v470 : string = $"{v468}"
    let v473 : unit = ()
    let v474 : (unit -> unit) = closure7(v10, v470)
    let v475 : unit = (fun () -> v474 (); v473) ()
    let v479 : string = $"{v55}"
    let v482 : unit = ()
    let v483 : (unit -> unit) = closure7(v10, v479)
    let v484 : unit = (fun () -> v483 (); v482) ()
    let v489 : string = "working_directory"
    let v490 : string = $"{v489}"
    let v493 : unit = ()
    let v494 : (unit -> unit) = closure7(v10, v490)
    let v495 : unit = (fun () -> v494 (); v493) ()
    let v499 : string = $"{v35}"
    let v502 : unit = ()
    let v503 : (unit -> unit) = closure7(v10, v499)
    let v504 : unit = (fun () -> v503 (); v502) ()
    (* run_target_args'
    let v511 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v512 : string = "format!(\"{:#?}\", $0)"
    let v513 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v512 
    let v514 : string = "fable_library_rust::String_::fromString($0)"
    let v515 : string = Fable.Core.RustInterop.emitRustExpr v513 v514 
    let _run_target_args'_v511 = v515 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v516 : string = "format!(\"{:#?}\", $0)"
    let v517 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v516 
    let v518 : string = "fable_library_rust::String_::fromString($0)"
    let v519 : string = Fable.Core.RustInterop.emitRustExpr v517 v518 
    let _run_target_args'_v511 = v519 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v520 : string = "format!(\"{:#?}\", $0)"
    let v521 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v520 
    let v522 : string = "fable_library_rust::String_::fromString($0)"
    let v523 : string = Fable.Core.RustInterop.emitRustExpr v521 v522 
    let _run_target_args'_v511 = v523 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v525 : string = $"%A{v8}"
    let _run_target_args'_v511 = v525 
    #endif
#if FABLE_COMPILER_PYTHON
    let v529 : string = $"%A{v8}"
    let _run_target_args'_v511 = v529 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v533 : string = $"%A{v8}"
    let _run_target_args'_v511 = v533 
    #endif
#else
    let v537 : string = $"%A{v8}"
    let _run_target_args'_v511 = v537 
    #endif
    let v540 : string = _run_target_args'_v511 
    let v547 : string = $"{v540}"
    let v550 : unit = ()
    let v551 : (unit -> unit) = closure7(v10, v547)
    let v552 : unit = (fun () -> v551 (); v550) ()
    let v557 : string = " }"
    let v558 : string = $"{v557}"
    let v561 : unit = ()
    let v562 : (unit -> unit) = closure7(v10, v558)
    let v563 : unit = (fun () -> v562 (); v561) ()
    let v567 : string = $"{v557}"
    let v570 : unit = ()
    let v571 : (unit -> unit) = closure7(v10, v567)
    let v572 : unit = (fun () -> v571 (); v570) ()
    let v575 : string = v10.l0
    v575
and method39 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : US5, v10 : string, v11 : System.Threading.CancellationToken option, v12 : (struct (string * string) []), v13 : (struct (int32 * string * bool) -> Async<unit>) option, v14 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v15 : bool, v16 : string option) : string =
    let v17 : string = method40(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    let v18 : int64 = v0.l0
    let v20 : string = "runtime.execute_with_options_async"
    let v21 : string = $"{v6} {v7} #{v18} %s{v20} / {v17}"
    method18(v21)
and closure17 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : US5, v8 : string) () : unit =
    let v9 : US0 = US0_1
    let v10 : bool = method7(v9)
    if v10 then
        let v11 : unit = ()
        let v12 : (unit -> unit) = closure0()
        let v13 : unit = (fun () -> v12 (); v11) ()
        let struct (v34 : Mut0, v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : int64 option) = TraceState.trace_state.Value
        let v52 : string = method8(v34, v35, v36, v37, v38, v39)
        let v53 : string = method38()
        let v54 : string = method39(v34, v35, v36, v37, v38, v39, v52, v53, v8, v7, v0, v1, v2, v3, v4, v5, v6)
        method19(v54)
and method41 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : (struct (string * string) []) =
    v2
and method42 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method45 (v0 : System.Diagnostics.DataReceivedEventArgs) : string =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : string = null |> unbox<string>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = null |> unbox<string>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = null |> unbox<string>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : string = null |> unbox<string>
    let _run_target_args'_v5 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : string = null |> unbox<string>
    let _run_target_args'_v5 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : string = null |> unbox<string>
    let _run_target_args'_v5 = v27 
    #endif
#else
    let v30 : (System.Diagnostics.DataReceivedEventArgs -> string) = _.Data
    let v31 : string = v30 v0
    let _run_target_args'_v5 = v31 
    #endif
    let v32 : string = _run_target_args'_v5 
    v32
and closure19 () (v0 : (struct (int32 * string * bool) -> Async<unit>)) : US14 =
    US14_0(v0)
and method46 () : ((struct (int32 * string * bool) -> Async<unit>) -> US14) =
    closure19()
and method47 (v0 : System.Diagnostics.Process) : int32 =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : int32 = null |> unbox<int32>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : int32 = null |> unbox<int32>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : int32 = null |> unbox<int32>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : int32 = null |> unbox<int32>
    let _run_target_args'_v5 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : int32 = null |> unbox<int32>
    let _run_target_args'_v5 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : int32 = null |> unbox<int32>
    let _run_target_args'_v5 = v27 
    #endif
#else
    let v30 : (System.Diagnostics.Process -> int32) = _.Id
    let v31 : int32 = v30 v0
    let _run_target_args'_v5 = v31 
    #endif
    let v32 : int32 = _run_target_args'_v5 
    v32
and method48 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method13(v7)
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
    let v138 : string = method15()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[90m"
    let v142 : string = method15()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[90m"
    let v146 : string = method15()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[90m"
    let v150 : string = method15()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method49 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method17()
    let v10 : int64 = v0.l0
    let v12 : string = $"{v6} {v7} #{v10} %s{v8} / {v9}"
    method18(v12)
and closure20 (v0 : string) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method7(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure0()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method8(v26, v27, v28, v29, v30, v31)
        let v45 : string = method48()
        let v46 : bool = v0 = ""
        let v49 : string =
            if v46 then
                let v47 : string = ""
                v47
            else
                method49(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method19(v49)
and method44 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool, v10 : System.Diagnostics.DataReceivedEventArgs) : Async<unit> =
    (* run_target_args'
    let v15 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v17 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v15 = v17 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v21 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v15 = v21 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v25 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v15 = v25 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v29 : unit = ()
    let _let'_v29 =
        async {
            let v32 : string = method45(v10)
            let v34 : string = null |> unbox<string>
            let v37 : bool = v32 = v34
            let v38 : bool = v37 <> true
            if v38 then
                let v41 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v42 : US14 option = v3 |> Option.map v41 
                let v62 : US14 = US14_1
                let v63 : US14 = v42 |> Option.defaultValue v62 
                match v63 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v67) -> (* Some *)
                    let v68 : int32 = method47(v7)
                    let v69 : Async<unit> = v67 struct (v68, v32, v9)
                    do! v69 
                    ()
                let v72 : string =
                    if v9 then
                        let v70 : string = $"! {v32}"
                        v70
                    else
                        let v71 : string = $"> {v32}"
                        v71
                if v5 then
                    let v73 : unit = ()
                    let v74 : (unit -> unit) = closure20(v72)
                    let v75 : unit = (fun () -> v74 (); v73) ()
                    ()
                else
                    let v125 : unit = ()
                    let v126 : (unit -> unit) = closure10(v72)
                    let v127 : unit = (fun () -> v126 (); v125) ()
                    ()
                let v131 : string =
                    if v9 then
                        let v129 : string = "\u001b[7;4m"
                        v129
                    else
                        let v130 : string = ""
                        v130
                let v134 : string =
                    if v9 then
                        let v132 : string = "\u001b[0m"
                        v132
                    else
                        let v133 : string = ""
                        v133
                let v135 : string = $"{v131}{v32}{v134}"
                (* run_target_args'
                let v136 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                #endif
#if FABLE_COMPILER_RUST && WASM
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                #endif
#if FABLE_COMPILER_PYTHON
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                #endif
#else
                let v137 : (string -> unit) = v8.Push
                v137 v135
                #endif
                // run_target_args' is_unit
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v880 : Async<unit> = _let'_v29 
    let _run_target_args'_v15 = v880 
    #endif
#if FABLE_COMPILER_PYTHON
    let v882 : unit = ()
    let _let'_v882 =
        async {
            let v885 : string = method45(v10)
            let v887 : string = null |> unbox<string>
            let v890 : bool = v885 = v887
            let v891 : bool = v890 <> true
            if v891 then
                let v894 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v895 : US14 option = v3 |> Option.map v894 
                let v915 : US14 = US14_1
                let v916 : US14 = v895 |> Option.defaultValue v915 
                match v916 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v920) -> (* Some *)
                    let v921 : int32 = method47(v7)
                    let v922 : Async<unit> = v920 struct (v921, v885, v9)
                    do! v922 
                    ()
                let v925 : string =
                    if v9 then
                        let v923 : string = $"! {v885}"
                        v923
                    else
                        let v924 : string = $"> {v885}"
                        v924
                if v5 then
                    let v926 : unit = ()
                    let v927 : (unit -> unit) = closure20(v925)
                    let v928 : unit = (fun () -> v927 (); v926) ()
                    ()
                else
                    let v978 : unit = ()
                    let v979 : (unit -> unit) = closure10(v925)
                    let v980 : unit = (fun () -> v979 (); v978) ()
                    ()
                let v984 : string =
                    if v9 then
                        let v982 : string = "\u001b[7;4m"
                        v982
                    else
                        let v983 : string = ""
                        v983
                let v987 : string =
                    if v9 then
                        let v985 : string = "\u001b[0m"
                        v985
                    else
                        let v986 : string = ""
                        v986
                let v988 : string = $"{v984}{v885}{v987}"
                (* run_target_args'
                let v989 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                #endif
#if FABLE_COMPILER_RUST && WASM
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                #endif
#if FABLE_COMPILER_PYTHON
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                #endif
#else
                let v990 : (string -> unit) = v8.Push
                v990 v988
                #endif
                // run_target_args' is_unit
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1733 : Async<unit> = _let'_v882 
    let _run_target_args'_v15 = v1733 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1735 : unit = ()
    let _let'_v1735 =
        async {
            let v1738 : string = method45(v10)
            let v1740 : string = null |> unbox<string>
            let v1743 : bool = v1738 = v1740
            let v1744 : bool = v1743 <> true
            if v1744 then
                let v1747 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v1748 : US14 option = v3 |> Option.map v1747 
                let v1768 : US14 = US14_1
                let v1769 : US14 = v1748 |> Option.defaultValue v1768 
                match v1769 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v1773) -> (* Some *)
                    let v1774 : int32 = method47(v7)
                    let v1775 : Async<unit> = v1773 struct (v1774, v1738, v9)
                    do! v1775 
                    ()
                let v1778 : string =
                    if v9 then
                        let v1776 : string = $"! {v1738}"
                        v1776
                    else
                        let v1777 : string = $"> {v1738}"
                        v1777
                if v5 then
                    let v1779 : unit = ()
                    let v1780 : (unit -> unit) = closure20(v1778)
                    let v1781 : unit = (fun () -> v1780 (); v1779) ()
                    ()
                else
                    let v1831 : unit = ()
                    let v1832 : (unit -> unit) = closure10(v1778)
                    let v1833 : unit = (fun () -> v1832 (); v1831) ()
                    ()
                let v1837 : string =
                    if v9 then
                        let v1835 : string = "\u001b[7;4m"
                        v1835
                    else
                        let v1836 : string = ""
                        v1836
                let v1840 : string =
                    if v9 then
                        let v1838 : string = "\u001b[0m"
                        v1838
                    else
                        let v1839 : string = ""
                        v1839
                let v1841 : string = $"{v1837}{v1738}{v1840}"
                (* run_target_args'
                let v1842 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                #endif
#if FABLE_COMPILER_RUST && WASM
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                #endif
#if FABLE_COMPILER_PYTHON
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                #endif
#else
                let v1843 : (string -> unit) = v8.Push
                v1843 v1841
                #endif
                // run_target_args' is_unit
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2586 : Async<unit> = _let'_v1735 
    let _run_target_args'_v15 = v2586 
    #endif
#else
    let v2588 : unit = ()
    let _let'_v2588 =
        async {
            let v2591 : string = method45(v10)
            let v2593 : string = null |> unbox<string>
            let v2596 : bool = v2591 = v2593
            let v2597 : bool = v2596 <> true
            if v2597 then
                let v2600 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v2601 : US14 option = v3 |> Option.map v2600 
                let v2621 : US14 = US14_1
                let v2622 : US14 = v2601 |> Option.defaultValue v2621 
                match v2622 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v2626) -> (* Some *)
                    let v2627 : int32 = method47(v7)
                    let v2628 : Async<unit> = v2626 struct (v2627, v2591, v9)
                    do! v2628 
                    ()
                let v2631 : string =
                    if v9 then
                        let v2629 : string = $"! {v2591}"
                        v2629
                    else
                        let v2630 : string = $"> {v2591}"
                        v2630
                if v5 then
                    let v2632 : unit = ()
                    let v2633 : (unit -> unit) = closure20(v2631)
                    let v2634 : unit = (fun () -> v2633 (); v2632) ()
                    ()
                else
                    let v2684 : unit = ()
                    let v2685 : (unit -> unit) = closure10(v2631)
                    let v2686 : unit = (fun () -> v2685 (); v2684) ()
                    ()
                let v2690 : string =
                    if v9 then
                        let v2688 : string = "\u001b[7;4m"
                        v2688
                    else
                        let v2689 : string = ""
                        v2689
                let v2693 : string =
                    if v9 then
                        let v2691 : string = "\u001b[0m"
                        v2691
                    else
                        let v2692 : string = ""
                        v2692
                let v2694 : string = $"{v2690}{v2591}{v2693}"
                (* run_target_args'
                let v2695 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                #endif
#if FABLE_COMPILER_RUST && WASM
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                #endif
#if FABLE_COMPILER_PYTHON
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                #endif
#else
                let v2696 : (string -> unit) = v8.Push
                v2696 v2694
                #endif
                // run_target_args' is_unit
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3439 : Async<unit> = _let'_v2588 
    let _run_target_args'_v15 = v3439 
    #endif
    let v3440 : Async<unit> = _run_target_args'_v15 
    v3440
and method43 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool, v10 : System.Diagnostics.DataReceivedEventArgs) : Async<unit> =
    method44(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
and closure18 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool) (v10 : System.Diagnostics.DataReceivedEventArgs) : unit =
    let v11 : Async<unit> = method43(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    null |> unbox<unit>
    #endif
#if FABLE_COMPILER_RUST && WASM
    null |> unbox<unit>
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    null |> unbox<unit>
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v13 : (Async<unit> -> unit) = Async.StartImmediate
    v13 v11
    #endif
#if FABLE_COMPILER_PYTHON
    let v14 : (Async<unit> -> unit) = Async.StartImmediate
    v14 v11
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v15 : (Async<unit> -> unit) = Async.StartImmediate
    v15 v11
    #endif
#else
    let v16 : (Async<unit> -> unit) = Async.StartImmediate
    v16 v11
    #endif
    // run_target_args' is_unit
    ()
and closure21 () (v0 : System.Threading.CancellationToken) : US15 =
    US15_0(v0)
and method50 () : (System.Threading.CancellationToken -> US15) =
    closure21()
and method51 (v0 : System.Threading.CancellationToken) : Async<System.Threading.CancellationToken> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<System.Threading.CancellationToken> = null |> unbox<Async<System.Threading.CancellationToken>>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : Async<System.Threading.CancellationToken> = null |> unbox<Async<System.Threading.CancellationToken>>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : Async<System.Threading.CancellationToken> = null |> unbox<Async<System.Threading.CancellationToken>>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : unit = ()
    let _let'_v19 =
        async {
            (* run_target_args'
            let v26 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v28 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v28 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v32 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v32 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v36 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v36 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v40 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v40 
            #endif
#if FABLE_COMPILER_PYTHON
            let v44 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v44 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v48 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v48 
            #endif
#else
            let v51 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v51 = v51 
            let v52 : System.Threading.CancellationToken = v51 
            let v53 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v54 : (System.Threading.CancellationToken []) = [|v52; v53; v0|]
            let v55 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v56 : System.Threading.CancellationTokenSource = v55 v54
            let v57 : System.Threading.CancellationToken = v56.Token
            return v57 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v342 : Async<System.Threading.CancellationToken> = _let'_v19 
    let _run_target_args'_v5 = v342 
    #endif
#if FABLE_COMPILER_PYTHON
    let v344 : unit = ()
    let _let'_v344 =
        async {
            (* run_target_args'
            let v351 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v353 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v353 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v357 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v357 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v361 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v361 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v365 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v365 
            #endif
#if FABLE_COMPILER_PYTHON
            let v369 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v369 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v373 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v373 
            #endif
#else
            let v376 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v376 = v376 
            let v377 : System.Threading.CancellationToken = v376 
            let v378 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v379 : (System.Threading.CancellationToken []) = [|v377; v378; v0|]
            let v380 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v381 : System.Threading.CancellationTokenSource = v380 v379
            let v382 : System.Threading.CancellationToken = v381.Token
            return v382 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v667 : Async<System.Threading.CancellationToken> = _let'_v344 
    let _run_target_args'_v5 = v667 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v669 : unit = ()
    let _let'_v669 =
        async {
            (* run_target_args'
            let v676 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v678 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v678 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v682 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v682 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v686 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v686 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v690 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v690 
            #endif
#if FABLE_COMPILER_PYTHON
            let v694 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v694 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v698 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v698 
            #endif
#else
            let v701 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v701 = v701 
            let v702 : System.Threading.CancellationToken = v701 
            let v703 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v704 : (System.Threading.CancellationToken []) = [|v702; v703; v0|]
            let v705 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v706 : System.Threading.CancellationTokenSource = v705 v704
            let v707 : System.Threading.CancellationToken = v706.Token
            return v707 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v992 : Async<System.Threading.CancellationToken> = _let'_v669 
    let _run_target_args'_v5 = v992 
    #endif
#else
    let v994 : unit = ()
    let _let'_v994 =
        async {
            (* run_target_args'
            let v1001 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1003 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1003 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1007 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1007 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1011 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1011 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1015 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1015 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1019 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1019 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1023 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1023 
            #endif
#else
            let v1026 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v1026 = v1026 
            let v1027 : System.Threading.CancellationToken = v1026 
            let v1028 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v1029 : (System.Threading.CancellationToken []) = [|v1027; v1028; v0|]
            let v1030 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v1031 : System.Threading.CancellationTokenSource = v1030 v1029
            let v1032 : System.Threading.CancellationToken = v1031.Token
            return v1032 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1317 : Async<System.Threading.CancellationToken> = _let'_v994 
    let _run_target_args'_v5 = v1317 
    #endif
    let v1318 : Async<System.Threading.CancellationToken> = _run_target_args'_v5 
    v1318
and method52 (v0 : System.Diagnostics.Process) : bool =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v27 
    #endif
#else
    let v30 : (System.Diagnostics.Process -> bool) = _.HasExited
    let v31 : bool = v30 v0
    let _run_target_args'_v5 = v31 
    #endif
    let v32 : bool = _run_target_args'_v5 
    v32
and method53 (v0 : System.Diagnostics.Process) : unit =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    #endif
#if FABLE_COMPILER_RUST && WASM
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    #endif
#if FABLE_COMPILER_PYTHON
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    #endif
#else
    let v2 : (System.Diagnostics.Process -> unit) = _.Kill()
    v2 v0
    #endif
    // run_target_args' is_unit
    ()
and closure22 (v0 : System.Diagnostics.Process) () : unit =
    let v1 : bool = method52(v0)
    let v2 : bool = v1 = false
    if v2 then
        method53(v0)
and method56 (v0 : System.Threading.Tasks.TaskCanceledException) : string =
    let v1 : string = method14()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure7(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "ex"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure7(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure7(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    (* run_target_args'
    let v40 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v41 : string = "format!(\"{:#?}\", $0)"
    let v42 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v41 
    let v43 : string = "fable_library_rust::String_::fromString($0)"
    let v44 : string = Fable.Core.RustInterop.emitRustExpr v42 v43 
    let _run_target_args'_v40 = v44 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v45 : string = "format!(\"{:#?}\", $0)"
    let v46 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v45 
    let v47 : string = "fable_library_rust::String_::fromString($0)"
    let v48 : string = Fable.Core.RustInterop.emitRustExpr v46 v47 
    let _run_target_args'_v40 = v48 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v49 : string = "format!(\"{:#?}\", $0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v49 
    let v51 : string = "fable_library_rust::String_::fromString($0)"
    let v52 : string = Fable.Core.RustInterop.emitRustExpr v50 v51 
    let _run_target_args'_v40 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : string = $"%A{v0}"
    let _run_target_args'_v40 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : string = $"%A{v0}"
    let _run_target_args'_v40 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : string = $"%A{v0}"
    let _run_target_args'_v40 = v62 
    #endif
#else
    let v66 : string = $"%A{v0}"
    let _run_target_args'_v40 = v66 
    #endif
    let v69 : string = _run_target_args'_v40 
    let v76 : string = $"{v69}"
    let v79 : unit = ()
    let v80 : (unit -> unit) = closure7(v2, v76)
    let v81 : unit = (fun () -> v80 (); v79) ()
    let v86 : string = " }"
    let v87 : string = $"{v86}"
    let v90 : unit = ()
    let v91 : (unit -> unit) = closure7(v2, v87)
    let v92 : unit = (fun () -> v91 (); v90) ()
    let v95 : string = v2.l0
    v95
and method55 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : System.Threading.Tasks.TaskCanceledException) : string =
    let v9 : string = method56(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "runtime.execute_with_options_async / WaitForExitAsync"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method18(v13)
and closure23 (v0 : System.Threading.Tasks.TaskCanceledException) () : unit =
    let v1 : US0 = US0_3
    let v2 : bool = method7(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure0()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method8(v26, v27, v28, v29, v30, v31)
        let v45 : string = method12()
        let v46 : string = method55(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method19(v46)
and method54 (v0 : System.Diagnostics.Process, v1 : System.Collections.Concurrent.ConcurrentStack<string>, v2 : System.Threading.CancellationToken) : Async<int32> =
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
            try
                (* run_target_args'
                let v28 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v30 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v28 = v30 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v34 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v28 = v34 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v38 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v28 = v38 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v42 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v28 = v42 
                #endif
#if FABLE_COMPILER_PYTHON
                let v46 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v28 = v46 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v50 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v28 = v50 
                #endif
#else
                let v53 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v28 = v53 
                #endif
                let v54 : System.Threading.Tasks.Task = _run_target_args'_v28 
                (* run_target_args'
                let v64 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v66 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v64 = v66 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v70 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v64 = v70 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v74 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v64 = v74 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v77 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v78 : Async<unit> = v77 v54
                let _run_target_args'_v64 = v78 
                #endif
#if FABLE_COMPILER_PYTHON
                let v79 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v80 : Async<unit> = v79 v54
                let _run_target_args'_v64 = v80 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v81 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v82 : Async<unit> = v81 v54
                let _run_target_args'_v64 = v82 
                #endif
#else
                let v83 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v84 : Async<unit> = v83 v54
                let _run_target_args'_v64 = v84 
                #endif
                let v85 : Async<unit> = _run_target_args'_v64 
                do! v85 
                (* run_target_args'
                let v95 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v97 : int32 = null |> unbox<int32>
                let _run_target_args'_v95 = v97 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v101 : int32 = null |> unbox<int32>
                let _run_target_args'_v95 = v101 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v105 : int32 = null |> unbox<int32>
                let _run_target_args'_v95 = v105 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v109 : int32 = null |> unbox<int32>
                let _run_target_args'_v95 = v109 
                #endif
#if FABLE_COMPILER_PYTHON
                let v113 : int32 = null |> unbox<int32>
                let _run_target_args'_v95 = v113 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v117 : int32 = null |> unbox<int32>
                let _run_target_args'_v95 = v117 
                #endif
#else
                let v120 : int32 = v0.ExitCode
                let _run_target_args'_v95 = v120 
                #endif
                let v121 : int32 = _run_target_args'_v95 
                return v121 
                (* indent
                ()
            indent *)
            with ex ->
                let v230 : exn = ex
                (* run_target_args'
                let v235 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v237 : string = $"%A{v230}"
                let _run_target_args'_v235 = v237 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v241 : string = $"%A{v230}"
                let _run_target_args'_v235 = v241 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v245 : string = $"%A{v230}"
                let _run_target_args'_v235 = v245 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v249 : string = $"%A{v230}"
                let _run_target_args'_v235 = v249 
                #endif
#if FABLE_COMPILER_PYTHON
                let v253 : string = $"%A{v230}"
                let _run_target_args'_v235 = v253 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v257 : string = $"%A{v230}"
                let _run_target_args'_v235 = v257 
                #endif
#else
                let v260 : string = $"{v230.GetType ()}: {v230.Message}"
                let _run_target_args'_v235 = v260 
                #endif
                let v261 : string = _run_target_args'_v235 
                (* run_target_args'
                let v267 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                #endif
#if FABLE_COMPILER_RUST && WASM
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                #endif
#if FABLE_COMPILER_PYTHON
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                #endif
#else
                let v268 : (string -> unit) = v1.Push
                v268 v261
                #endif
                // run_target_args' is_unit
                let v270 : System.Threading.Tasks.TaskCanceledException = v230 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v273 : unit = ()
                let v274 : (unit -> unit) = closure23(v270)
                let v275 : unit = (fun () -> v274 (); v273) ()
                return -2147483648 
                (* indent
                ()
            indent *)
            (* try_unit
            try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3144 : Async<int32> = _let'_v21 
    let _run_target_args'_v7 = v3144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3146 : unit = ()
    let _let'_v3146 =
        async {
            try
                (* run_target_args'
                let v3153 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3155 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3153 = v3155 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3159 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3153 = v3159 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3163 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3153 = v3163 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3167 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3153 = v3167 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3171 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3153 = v3171 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3175 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v3153 = v3175 
                #endif
#else
                let v3178 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v3153 = v3178 
                #endif
                let v3179 : System.Threading.Tasks.Task = _run_target_args'_v3153 
                (* run_target_args'
                let v3189 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3191 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v3189 = v3191 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3195 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v3189 = v3195 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3199 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v3189 = v3199 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3202 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3203 : Async<unit> = v3202 v3179
                let _run_target_args'_v3189 = v3203 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3204 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3205 : Async<unit> = v3204 v3179
                let _run_target_args'_v3189 = v3205 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3206 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3207 : Async<unit> = v3206 v3179
                let _run_target_args'_v3189 = v3207 
                #endif
#else
                let v3208 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v3209 : Async<unit> = v3208 v3179
                let _run_target_args'_v3189 = v3209 
                #endif
                let v3210 : Async<unit> = _run_target_args'_v3189 
                do! v3210 
                (* run_target_args'
                let v3220 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3222 : int32 = null |> unbox<int32>
                let _run_target_args'_v3220 = v3222 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3226 : int32 = null |> unbox<int32>
                let _run_target_args'_v3220 = v3226 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3230 : int32 = null |> unbox<int32>
                let _run_target_args'_v3220 = v3230 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3234 : int32 = null |> unbox<int32>
                let _run_target_args'_v3220 = v3234 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3238 : int32 = null |> unbox<int32>
                let _run_target_args'_v3220 = v3238 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3242 : int32 = null |> unbox<int32>
                let _run_target_args'_v3220 = v3242 
                #endif
#else
                let v3245 : int32 = v0.ExitCode
                let _run_target_args'_v3220 = v3245 
                #endif
                let v3246 : int32 = _run_target_args'_v3220 
                return v3246 
                (* indent
                ()
            indent *)
            with ex ->
                let v3355 : exn = ex
                (* run_target_args'
                let v3360 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3362 : string = $"%A{v3355}"
                let _run_target_args'_v3360 = v3362 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3366 : string = $"%A{v3355}"
                let _run_target_args'_v3360 = v3366 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3370 : string = $"%A{v3355}"
                let _run_target_args'_v3360 = v3370 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3374 : string = $"%A{v3355}"
                let _run_target_args'_v3360 = v3374 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3378 : string = $"%A{v3355}"
                let _run_target_args'_v3360 = v3378 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3382 : string = $"%A{v3355}"
                let _run_target_args'_v3360 = v3382 
                #endif
#else
                let v3385 : string = $"{v3355.GetType ()}: {v3355.Message}"
                let _run_target_args'_v3360 = v3385 
                #endif
                let v3386 : string = _run_target_args'_v3360 
                (* run_target_args'
                let v3392 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                #endif
#if FABLE_COMPILER_RUST && WASM
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                #endif
#if FABLE_COMPILER_PYTHON
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                #endif
#else
                let v3393 : (string -> unit) = v1.Push
                v3393 v3386
                #endif
                // run_target_args' is_unit
                let v3395 : System.Threading.Tasks.TaskCanceledException = v3355 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v3398 : unit = ()
                let v3399 : (unit -> unit) = closure23(v3395)
                let v3400 : unit = (fun () -> v3399 (); v3398) ()
                return -2147483648 
                (* indent
                ()
            indent *)
            (* try_unit
            try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6269 : Async<int32> = _let'_v3146 
    let _run_target_args'_v7 = v6269 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v6271 : unit = ()
    let _let'_v6271 =
        async {
            try
                (* run_target_args'
                let v6278 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6280 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6278 = v6280 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6284 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6278 = v6284 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6288 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6278 = v6288 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6292 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6278 = v6292 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6296 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6278 = v6296 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6300 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v6278 = v6300 
                #endif
#else
                let v6303 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v6278 = v6303 
                #endif
                let v6304 : System.Threading.Tasks.Task = _run_target_args'_v6278 
                (* run_target_args'
                let v6314 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6316 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v6314 = v6316 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6320 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v6314 = v6320 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6324 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v6314 = v6324 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6327 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6328 : Async<unit> = v6327 v6304
                let _run_target_args'_v6314 = v6328 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6329 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6330 : Async<unit> = v6329 v6304
                let _run_target_args'_v6314 = v6330 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6331 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6332 : Async<unit> = v6331 v6304
                let _run_target_args'_v6314 = v6332 
                #endif
#else
                let v6333 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v6334 : Async<unit> = v6333 v6304
                let _run_target_args'_v6314 = v6334 
                #endif
                let v6335 : Async<unit> = _run_target_args'_v6314 
                do! v6335 
                (* run_target_args'
                let v6345 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6347 : int32 = null |> unbox<int32>
                let _run_target_args'_v6345 = v6347 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6351 : int32 = null |> unbox<int32>
                let _run_target_args'_v6345 = v6351 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6355 : int32 = null |> unbox<int32>
                let _run_target_args'_v6345 = v6355 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6359 : int32 = null |> unbox<int32>
                let _run_target_args'_v6345 = v6359 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6363 : int32 = null |> unbox<int32>
                let _run_target_args'_v6345 = v6363 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6367 : int32 = null |> unbox<int32>
                let _run_target_args'_v6345 = v6367 
                #endif
#else
                let v6370 : int32 = v0.ExitCode
                let _run_target_args'_v6345 = v6370 
                #endif
                let v6371 : int32 = _run_target_args'_v6345 
                return v6371 
                (* indent
                ()
            indent *)
            with ex ->
                let v6480 : exn = ex
                (* run_target_args'
                let v6485 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6487 : string = $"%A{v6480}"
                let _run_target_args'_v6485 = v6487 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6491 : string = $"%A{v6480}"
                let _run_target_args'_v6485 = v6491 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6495 : string = $"%A{v6480}"
                let _run_target_args'_v6485 = v6495 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6499 : string = $"%A{v6480}"
                let _run_target_args'_v6485 = v6499 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6503 : string = $"%A{v6480}"
                let _run_target_args'_v6485 = v6503 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6507 : string = $"%A{v6480}"
                let _run_target_args'_v6485 = v6507 
                #endif
#else
                let v6510 : string = $"{v6480.GetType ()}: {v6480.Message}"
                let _run_target_args'_v6485 = v6510 
                #endif
                let v6511 : string = _run_target_args'_v6485 
                (* run_target_args'
                let v6517 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                #endif
#if FABLE_COMPILER_RUST && WASM
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                #endif
#if FABLE_COMPILER_PYTHON
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                #endif
#else
                let v6518 : (string -> unit) = v1.Push
                v6518 v6511
                #endif
                // run_target_args' is_unit
                let v6520 : System.Threading.Tasks.TaskCanceledException = v6480 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v6523 : unit = ()
                let v6524 : (unit -> unit) = closure23(v6520)
                let v6525 : unit = (fun () -> v6524 (); v6523) ()
                return -2147483648 
                (* indent
                ()
            indent *)
            (* try_unit
            try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9394 : Async<int32> = _let'_v6271 
    let _run_target_args'_v7 = v9394 
    #endif
#else
    let v9396 : unit = ()
    let _let'_v9396 =
        async {
            try
                (* run_target_args'
                let v9403 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9405 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v9403 = v9405 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9409 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v9403 = v9409 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9413 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v9403 = v9413 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9417 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v9403 = v9417 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9421 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v9403 = v9421 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9425 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v9403 = v9425 
                #endif
#else
                let v9428 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v9403 = v9428 
                #endif
                let v9429 : System.Threading.Tasks.Task = _run_target_args'_v9403 
                (* run_target_args'
                let v9439 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9441 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v9439 = v9441 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9445 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v9439 = v9445 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9449 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v9439 = v9449 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9452 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v9453 : Async<unit> = v9452 v9429
                let _run_target_args'_v9439 = v9453 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9454 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v9455 : Async<unit> = v9454 v9429
                let _run_target_args'_v9439 = v9455 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9456 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v9457 : Async<unit> = v9456 v9429
                let _run_target_args'_v9439 = v9457 
                #endif
#else
                let v9458 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v9459 : Async<unit> = v9458 v9429
                let _run_target_args'_v9439 = v9459 
                #endif
                let v9460 : Async<unit> = _run_target_args'_v9439 
                do! v9460 
                (* run_target_args'
                let v9470 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9472 : int32 = null |> unbox<int32>
                let _run_target_args'_v9470 = v9472 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9476 : int32 = null |> unbox<int32>
                let _run_target_args'_v9470 = v9476 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9480 : int32 = null |> unbox<int32>
                let _run_target_args'_v9470 = v9480 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9484 : int32 = null |> unbox<int32>
                let _run_target_args'_v9470 = v9484 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9488 : int32 = null |> unbox<int32>
                let _run_target_args'_v9470 = v9488 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9492 : int32 = null |> unbox<int32>
                let _run_target_args'_v9470 = v9492 
                #endif
#else
                let v9495 : int32 = v0.ExitCode
                let _run_target_args'_v9470 = v9495 
                #endif
                let v9496 : int32 = _run_target_args'_v9470 
                return v9496 
                (* indent
                ()
            indent *)
            with ex ->
                let v9605 : exn = ex
                (* run_target_args'
                let v9610 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9612 : string = $"%A{v9605}"
                let _run_target_args'_v9610 = v9612 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9616 : string = $"%A{v9605}"
                let _run_target_args'_v9610 = v9616 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9620 : string = $"%A{v9605}"
                let _run_target_args'_v9610 = v9620 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9624 : string = $"%A{v9605}"
                let _run_target_args'_v9610 = v9624 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9628 : string = $"%A{v9605}"
                let _run_target_args'_v9610 = v9628 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9632 : string = $"%A{v9605}"
                let _run_target_args'_v9610 = v9632 
                #endif
#else
                let v9635 : string = $"{v9605.GetType ()}: {v9605.Message}"
                let _run_target_args'_v9610 = v9635 
                #endif
                let v9636 : string = _run_target_args'_v9610 
                (* run_target_args'
                let v9642 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                #endif
#if FABLE_COMPILER_RUST && WASM
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                #endif
#if FABLE_COMPILER_PYTHON
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                #endif
#else
                let v9643 : (string -> unit) = v1.Push
                v9643 v9636
                #endif
                // run_target_args' is_unit
                let v9645 : System.Threading.Tasks.TaskCanceledException = v9605 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v9648 : unit = ()
                let v9649 : (unit -> unit) = closure23(v9645)
                let v9650 : unit = (fun () -> v9649 (); v9648) ()
                return -2147483648 
                (* indent
                ()
            indent *)
            (* try_unit
            try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v12519 : Async<int32> = _let'_v9396 
    let _run_target_args'_v7 = v12519 
    #endif
    let v12520 : Async<int32> = _run_target_args'_v7 
    v12520
and method57 () : string =
    let v0 : string = "\n"
    v0
and method59 (v0 : int32, v1 : int32, v2 : string, v3 : System.Threading.CancellationToken option, v4 : (struct (string * string) []), v5 : (struct (int32 * string * bool) -> Async<unit>) option, v6 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v7 : bool, v8 : string option) : string =
    let v9 : string = method14()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure7(v10, v14)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v24 : string = "exit_code"
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure7(v10, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    let v35 : string = " = "
    let v36 : string = $"{v35}"
    let v39 : unit = ()
    let v40 : (unit -> unit) = closure7(v10, v36)
    let v41 : unit = (fun () -> v40 (); v39) ()
    let v45 : string = $"{v0}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure7(v10, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v55 : string = "; "
    let v56 : string = $"{v55}"
    let v59 : unit = ()
    let v60 : (unit -> unit) = closure7(v10, v56)
    let v61 : unit = (fun () -> v60 (); v59) ()
    let v66 : string = "output_length"
    let v67 : string = $"{v66}"
    let v70 : unit = ()
    let v71 : (unit -> unit) = closure7(v10, v67)
    let v72 : unit = (fun () -> v71 (); v70) ()
    let v76 : string = $"{v35}"
    let v79 : unit = ()
    let v80 : (unit -> unit) = closure7(v10, v76)
    let v81 : unit = (fun () -> v80 (); v79) ()
    let v85 : string = $"{v1}"
    let v88 : unit = ()
    let v89 : (unit -> unit) = closure7(v10, v85)
    let v90 : unit = (fun () -> v89 (); v88) ()
    let v94 : string = $"{v55}"
    let v97 : unit = ()
    let v98 : (unit -> unit) = closure7(v10, v94)
    let v99 : unit = (fun () -> v98 (); v97) ()
    let v104 : string = "options"
    let v105 : string = $"{v104}"
    let v108 : unit = ()
    let v109 : (unit -> unit) = closure7(v10, v105)
    let v110 : unit = (fun () -> v109 (); v108) ()
    let v114 : string = $"{v35}"
    let v117 : unit = ()
    let v118 : (unit -> unit) = closure7(v10, v114)
    let v119 : unit = (fun () -> v118 (); v117) ()
    let v123 : string = $"{v13}"
    let v126 : unit = ()
    let v127 : (unit -> unit) = closure7(v10, v123)
    let v128 : unit = (fun () -> v127 (); v126) ()
    let v133 : string = "command"
    let v134 : string = $"{v133}"
    let v137 : unit = ()
    let v138 : (unit -> unit) = closure7(v10, v134)
    let v139 : unit = (fun () -> v138 (); v137) ()
    let v143 : string = $"{v35}"
    let v146 : unit = ()
    let v147 : (unit -> unit) = closure7(v10, v143)
    let v148 : unit = (fun () -> v147 (); v146) ()
    let v152 : string = $"{v2}"
    let v155 : unit = ()
    let v156 : (unit -> unit) = closure7(v10, v152)
    let v157 : unit = (fun () -> v156 (); v155) ()
    let v161 : string = $"{v55}"
    let v164 : unit = ()
    let v165 : (unit -> unit) = closure7(v10, v161)
    let v166 : unit = (fun () -> v165 (); v164) ()
    let v171 : string = "cancellation_token"
    let v172 : string = $"{v171}"
    let v175 : unit = ()
    let v176 : (unit -> unit) = closure7(v10, v172)
    let v177 : unit = (fun () -> v176 (); v175) ()
    let v181 : string = $"{v35}"
    let v184 : unit = ()
    let v185 : (unit -> unit) = closure7(v10, v181)
    let v186 : unit = (fun () -> v185 (); v184) ()
    (* run_target_args'
    let v193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v194 : string = "format!(\"{:#?}\", $0)"
    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v194 
    let v196 : string = "fable_library_rust::String_::fromString($0)"
    let v197 : string = Fable.Core.RustInterop.emitRustExpr v195 v196 
    let _run_target_args'_v193 = v197 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v198 : string = "format!(\"{:#?}\", $0)"
    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v198 
    let v200 : string = "fable_library_rust::String_::fromString($0)"
    let v201 : string = Fable.Core.RustInterop.emitRustExpr v199 v200 
    let _run_target_args'_v193 = v201 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v202 : string = "format!(\"{:#?}\", $0)"
    let v203 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v202 
    let v204 : string = "fable_library_rust::String_::fromString($0)"
    let v205 : string = Fable.Core.RustInterop.emitRustExpr v203 v204 
    let _run_target_args'_v193 = v205 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v207 : string = $"%A{v3}"
    let _run_target_args'_v193 = v207 
    #endif
#if FABLE_COMPILER_PYTHON
    let v211 : string = $"%A{v3}"
    let _run_target_args'_v193 = v211 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v215 : string = $"%A{v3}"
    let _run_target_args'_v193 = v215 
    #endif
#else
    let v219 : string = $"%A{v3}"
    let _run_target_args'_v193 = v219 
    #endif
    let v222 : string = _run_target_args'_v193 
    let v229 : string = $"{v222}"
    let v232 : unit = ()
    let v233 : (unit -> unit) = closure7(v10, v229)
    let v234 : unit = (fun () -> v233 (); v232) ()
    let v238 : string = $"{v55}"
    let v241 : unit = ()
    let v242 : (unit -> unit) = closure7(v10, v238)
    let v243 : unit = (fun () -> v242 (); v241) ()
    let v248 : string = "environment_variables"
    let v249 : string = $"{v248}"
    let v252 : unit = ()
    let v253 : (unit -> unit) = closure7(v10, v249)
    let v254 : unit = (fun () -> v253 (); v252) ()
    let v258 : string = $"{v35}"
    let v261 : unit = ()
    let v262 : (unit -> unit) = closure7(v10, v258)
    let v263 : unit = (fun () -> v262 (); v261) ()
    let v267 : string = $"%A{v4}"
    let v271 : string = $"{v267}"
    let v274 : unit = ()
    let v275 : (unit -> unit) = closure7(v10, v271)
    let v276 : unit = (fun () -> v275 (); v274) ()
    let v280 : string = $"{v55}"
    let v283 : unit = ()
    let v284 : (unit -> unit) = closure7(v10, v280)
    let v285 : unit = (fun () -> v284 (); v283) ()
    let v290 : string = "on_line"
    let v291 : string = $"{v290}"
    let v294 : unit = ()
    let v295 : (unit -> unit) = closure7(v10, v291)
    let v296 : unit = (fun () -> v295 (); v294) ()
    let v300 : string = $"{v35}"
    let v303 : unit = ()
    let v304 : (unit -> unit) = closure7(v10, v300)
    let v305 : unit = (fun () -> v304 (); v303) ()
    (* run_target_args'
    let v312 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v313 : string = "format!(\"{:#?}\", $0)"
    let v314 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v313 
    let v315 : string = "fable_library_rust::String_::fromString($0)"
    let v316 : string = Fable.Core.RustInterop.emitRustExpr v314 v315 
    let _run_target_args'_v312 = v316 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v317 : string = "format!(\"{:#?}\", $0)"
    let v318 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v317 
    let v319 : string = "fable_library_rust::String_::fromString($0)"
    let v320 : string = Fable.Core.RustInterop.emitRustExpr v318 v319 
    let _run_target_args'_v312 = v320 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v321 : string = "format!(\"{:#?}\", $0)"
    let v322 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v321 
    let v323 : string = "fable_library_rust::String_::fromString($0)"
    let v324 : string = Fable.Core.RustInterop.emitRustExpr v322 v323 
    let _run_target_args'_v312 = v324 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v326 : string = $"%A{v5}"
    let _run_target_args'_v312 = v326 
    #endif
#if FABLE_COMPILER_PYTHON
    let v330 : string = $"%A{v5}"
    let _run_target_args'_v312 = v330 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v334 : string = $"%A{v5}"
    let _run_target_args'_v312 = v334 
    #endif
#else
    let v338 : string = $"%A{v5}"
    let _run_target_args'_v312 = v338 
    #endif
    let v341 : string = _run_target_args'_v312 
    let v348 : string = $"{v341}"
    let v351 : unit = ()
    let v352 : (unit -> unit) = closure7(v10, v348)
    let v353 : unit = (fun () -> v352 (); v351) ()
    let v357 : string = $"{v55}"
    let v360 : unit = ()
    let v361 : (unit -> unit) = closure7(v10, v357)
    let v362 : unit = (fun () -> v361 (); v360) ()
    let v367 : string = "stdin"
    let v368 : string = $"{v367}"
    let v371 : unit = ()
    let v372 : (unit -> unit) = closure7(v10, v368)
    let v373 : unit = (fun () -> v372 (); v371) ()
    let v377 : string = $"{v35}"
    let v380 : unit = ()
    let v381 : (unit -> unit) = closure7(v10, v377)
    let v382 : unit = (fun () -> v381 (); v380) ()
    (* run_target_args'
    let v389 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v390 : string = "format!(\"{:#?}\", $0)"
    let v391 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v390 
    let v392 : string = "fable_library_rust::String_::fromString($0)"
    let v393 : string = Fable.Core.RustInterop.emitRustExpr v391 v392 
    let _run_target_args'_v389 = v393 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v394 : string = "format!(\"{:#?}\", $0)"
    let v395 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v394 
    let v396 : string = "fable_library_rust::String_::fromString($0)"
    let v397 : string = Fable.Core.RustInterop.emitRustExpr v395 v396 
    let _run_target_args'_v389 = v397 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v398 : string = "format!(\"{:#?}\", $0)"
    let v399 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v398 
    let v400 : string = "fable_library_rust::String_::fromString($0)"
    let v401 : string = Fable.Core.RustInterop.emitRustExpr v399 v400 
    let _run_target_args'_v389 = v401 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v403 : string = $"%A{v6}"
    let _run_target_args'_v389 = v403 
    #endif
#if FABLE_COMPILER_PYTHON
    let v407 : string = $"%A{v6}"
    let _run_target_args'_v389 = v407 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v411 : string = $"%A{v6}"
    let _run_target_args'_v389 = v411 
    #endif
#else
    let v415 : string = $"%A{v6}"
    let _run_target_args'_v389 = v415 
    #endif
    let v418 : string = _run_target_args'_v389 
    let v425 : string = $"{v418}"
    let v428 : unit = ()
    let v429 : (unit -> unit) = closure7(v10, v425)
    let v430 : unit = (fun () -> v429 (); v428) ()
    let v434 : string = $"{v55}"
    let v437 : unit = ()
    let v438 : (unit -> unit) = closure7(v10, v434)
    let v439 : unit = (fun () -> v438 (); v437) ()
    let v444 : string = "trace"
    let v445 : string = $"{v444}"
    let v448 : unit = ()
    let v449 : (unit -> unit) = closure7(v10, v445)
    let v450 : unit = (fun () -> v449 (); v448) ()
    let v454 : string = $"{v35}"
    let v457 : unit = ()
    let v458 : (unit -> unit) = closure7(v10, v454)
    let v459 : unit = (fun () -> v458 (); v457) ()
    let v464 : string =
        if v7 then
            let v462 : string = "true"
            v462
        else
            let v463 : string = "false"
            v463
    let v466 : string = $"{v464}"
    let v469 : unit = ()
    let v470 : (unit -> unit) = closure7(v10, v466)
    let v471 : unit = (fun () -> v470 (); v469) ()
    let v475 : string = $"{v55}"
    let v478 : unit = ()
    let v479 : (unit -> unit) = closure7(v10, v475)
    let v480 : unit = (fun () -> v479 (); v478) ()
    let v485 : string = "working_directory"
    let v486 : string = $"{v485}"
    let v489 : unit = ()
    let v490 : (unit -> unit) = closure7(v10, v486)
    let v491 : unit = (fun () -> v490 (); v489) ()
    let v495 : string = $"{v35}"
    let v498 : unit = ()
    let v499 : (unit -> unit) = closure7(v10, v495)
    let v500 : unit = (fun () -> v499 (); v498) ()
    (* run_target_args'
    let v507 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v508 : string = "format!(\"{:#?}\", $0)"
    let v509 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v508 
    let v510 : string = "fable_library_rust::String_::fromString($0)"
    let v511 : string = Fable.Core.RustInterop.emitRustExpr v509 v510 
    let _run_target_args'_v507 = v511 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v512 : string = "format!(\"{:#?}\", $0)"
    let v513 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v512 
    let v514 : string = "fable_library_rust::String_::fromString($0)"
    let v515 : string = Fable.Core.RustInterop.emitRustExpr v513 v514 
    let _run_target_args'_v507 = v515 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v516 : string = "format!(\"{:#?}\", $0)"
    let v517 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v516 
    let v518 : string = "fable_library_rust::String_::fromString($0)"
    let v519 : string = Fable.Core.RustInterop.emitRustExpr v517 v518 
    let _run_target_args'_v507 = v519 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v521 : string = $"%A{v8}"
    let _run_target_args'_v507 = v521 
    #endif
#if FABLE_COMPILER_PYTHON
    let v525 : string = $"%A{v8}"
    let _run_target_args'_v507 = v525 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v529 : string = $"%A{v8}"
    let _run_target_args'_v507 = v529 
    #endif
#else
    let v533 : string = $"%A{v8}"
    let _run_target_args'_v507 = v533 
    #endif
    let v536 : string = _run_target_args'_v507 
    let v543 : string = $"{v536}"
    let v546 : unit = ()
    let v547 : (unit -> unit) = closure7(v10, v543)
    let v548 : unit = (fun () -> v547 (); v546) ()
    let v553 : string = " }"
    let v554 : string = $"{v553}"
    let v557 : unit = ()
    let v558 : (unit -> unit) = closure7(v10, v554)
    let v559 : unit = (fun () -> v558 (); v557) ()
    let v563 : string = $"{v553}"
    let v566 : unit = ()
    let v567 : (unit -> unit) = closure7(v10, v563)
    let v568 : unit = (fun () -> v567 (); v566) ()
    let v571 : string = v10.l0
    v571
and method58 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : int32, v10 : string, v11 : System.Threading.CancellationToken option, v12 : (struct (string * string) []), v13 : (struct (int32 * string * bool) -> Async<unit>) option, v14 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v15 : bool, v16 : string option) : string =
    let v17 : string = method59(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    let v18 : int64 = v0.l0
    let v20 : string = "runtime.execute_with_options_async"
    let v21 : string = $"{v6} {v7} #{v18} %s{v20} / {v17}"
    method18(v21)
and closure24 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : int32, v8 : string) () : unit =
    let v9 : US0 = US0_1
    let v10 : bool = method7(v9)
    if v10 then
        let v11 : unit = ()
        let v12 : (unit -> unit) = closure0()
        let v13 : unit = (fun () -> v12 (); v11) ()
        let struct (v34 : Mut0, v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : int64 option) = TraceState.trace_state.Value
        let v52 : string = method8(v34, v35, v36, v37, v38, v39)
        let v53 : string = method38()
        let v54 : int32 = v8.Length
        let v55 : string = method58(v34, v35, v36, v37, v38, v39, v52, v53, v7, v54, v0, v1, v2, v3, v4, v5, v6)
        method19(v55)
and method24 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : Async<struct (int32 * string)> =
    (* run_target_args'
    let v11 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : Async<struct (int32 * string)> = null |> unbox<Async<struct (int32 * string)>>
    let _run_target_args'_v11 = v13 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v17 : Async<struct (int32 * string)> = null |> unbox<Async<struct (int32 * string)>>
    let _run_target_args'_v11 = v17 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v21 : Async<struct (int32 * string)> = null |> unbox<Async<struct (int32 * string)>>
    let _run_target_args'_v11 = v21 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v25 : unit = ()
    let _let'_v25 =
        async {
            (* run_target_args'
            let v36 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v39 : int32, v40 : string) = null |> unbox<struct (int32 * string)>
            return struct (v39, v40) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v47 : int32, v48 : string) = null |> unbox<struct (int32 * string)>
            return struct (v47, v48) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v55 : int32, v56 : string) = null |> unbox<struct (int32 * string)>
            return struct (v55, v56) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v63 : int32, v64 : string) = null |> unbox<struct (int32 * string)>
            return struct (v63, v64) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v71 : int32, v72 : string) = null |> unbox<struct (int32 * string)>
            return struct (v71, v72) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v79 : int32, v80 : string) = null |> unbox<struct (int32 * string)>
            return struct (v79, v80) 
            #endif
#else
            let v85 : US6 = method25(v0)
            let struct (v97 : string, v98 : US5) =
                match v85 with
                | US6_1(v88) -> (* Error *)
                    let v90 : string = $"resultm.get / Result value was Error: {v88}"
                    failwith<struct (string * US5)> v90
                | US6_0(v86, v87) -> (* Ok *)
                    struct (v86, v87)
            let v101 : (string -> US5) = method5()
            let v102 : US5 option = v6 |> Option.map v101 
            let v122 : US5 = US5_1
            let v123 : US5 = v102 |> Option.defaultValue v122 
            let v130 : string =
                match v123 with
                | US5_1 -> (* None *)
                    let v128 : string = ""
                    v128
                | US5_0(v127) -> (* Some *)
                    v127
            let v131 : unit = ()
            let v132 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v98, v97)
            let v133 : unit = (fun () -> v132 (); v131) ()
            let v180 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v184 : string =
                match v98 with
                | US5_1 -> (* None *)
                    let v182 : string = ""
                    v182
                | US5_0(v181) -> (* Some *)
                    v181
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v184,
              StandardOutputEncoding = v180,
              WorkingDirectory = v130,
              FileName = v97,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v185 : System.Diagnostics.ProcessStartInfo = start_info
            let v186 : (struct (string * string) []) = method41(v0, v1, v2, v3, v4, v5, v6)
            let v187 : int32 = v186.Length
            let v188 : Mut5 = {l0 = 0} : Mut5
            while method42(v187, v188) do
                let v190 : int32 = v188.l0
                let struct (v191 : string, v192 : string) = v186.[int v190]
                v185.EnvironmentVariables.[v191] <- v192 
                let v193 : int32 = v190 + 1
                v188.l0 <- v193
                ()
            let v194 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v185)
            use v194 = v194 
            let v195 : System.Diagnostics.Process = v194 
            let v196 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v197 : System.Collections.Concurrent.ConcurrentStack<string> = v196 ()
            let v198 : bool = false
            let v199 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v195, v197, v198)
            v195.OutputDataReceived.Add v199 
            let v200 : bool = true
            let v201 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v195, v197, v200)
            v195.ErrorDataReceived.Add v201 
            let v202 : (unit -> bool) = v195.Start
            let v203 : bool = v202 ()
            let v204 : bool = v203 = false
            if v204 then
                let v205 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v205
            let v206 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v206 v195
            let v207 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v207 v195
            let v210 : (System.Threading.CancellationToken -> US15) = method50()
            let v211 : US15 option = v1 |> Option.map v210 
            let v231 : US15 = US15_1
            let v232 : US15 = v211 |> Option.defaultValue v231 
            let v239 : System.Threading.CancellationToken =
                match v232 with
                | US15_1 -> (* None *)
                    let v237 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v237
                | US15_0(v236) -> (* Some *)
                    v236
            let v240 : Async<System.Threading.CancellationToken> = method51(v239)
            let! v240 = v240 
            let v241 : System.Threading.CancellationToken = v240 
            let v242 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v241.Register
            let v243 : (unit -> unit) = closure22(v195)
            let v244 : System.Threading.CancellationTokenRegistration = v242 v243
            use v244 = v244 
            let v245 : System.Threading.CancellationTokenRegistration = v244 
            let v246 : Async<int32> = method54(v195, v197, v241)
            let! v246 = v246 
            let v247 : int32 = v246 
            let v249 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v250 : string seq = v249 v197
            let v254 : (string seq -> string seq) = Seq.rev
            let v255 : string seq = v254 v250
            let v260 : string = method57()
            let v261 : (string -> (string seq -> string)) = String.concat
            let v262 : (string seq -> string) = v261 v260
            let v263 : string = v262 v255
            let v267 : unit = ()
            let v268 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v247, v263)
            let v269 : unit = (fun () -> v268 (); v267) ()
            return struct (v247, v263) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2404 : Async<struct (int32 * string)> = _let'_v25 
    let _run_target_args'_v11 = v2404 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2406 : unit = ()
    let _let'_v2406 =
        async {
            (* run_target_args'
            let v2417 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v2420 : int32, v2421 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2420, v2421) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v2428 : int32, v2429 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2428, v2429) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v2436 : int32, v2437 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2436, v2437) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v2444 : int32, v2445 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2444, v2445) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v2452 : int32, v2453 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2452, v2453) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v2460 : int32, v2461 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2460, v2461) 
            #endif
#else
            let v2466 : US6 = method25(v0)
            let struct (v2478 : string, v2479 : US5) =
                match v2466 with
                | US6_1(v2469) -> (* Error *)
                    let v2471 : string = $"resultm.get / Result value was Error: {v2469}"
                    failwith<struct (string * US5)> v2471
                | US6_0(v2467, v2468) -> (* Ok *)
                    struct (v2467, v2468)
            let v2482 : (string -> US5) = method5()
            let v2483 : US5 option = v6 |> Option.map v2482 
            let v2503 : US5 = US5_1
            let v2504 : US5 = v2483 |> Option.defaultValue v2503 
            let v2511 : string =
                match v2504 with
                | US5_1 -> (* None *)
                    let v2509 : string = ""
                    v2509
                | US5_0(v2508) -> (* Some *)
                    v2508
            let v2512 : unit = ()
            let v2513 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v2479, v2478)
            let v2514 : unit = (fun () -> v2513 (); v2512) ()
            let v2561 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v2565 : string =
                match v2479 with
                | US5_1 -> (* None *)
                    let v2563 : string = ""
                    v2563
                | US5_0(v2562) -> (* Some *)
                    v2562
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v2565,
              StandardOutputEncoding = v2561,
              WorkingDirectory = v2511,
              FileName = v2478,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v2566 : System.Diagnostics.ProcessStartInfo = start_info
            let v2567 : (struct (string * string) []) = method41(v0, v1, v2, v3, v4, v5, v6)
            let v2568 : int32 = v2567.Length
            let v2569 : Mut5 = {l0 = 0} : Mut5
            while method42(v2568, v2569) do
                let v2571 : int32 = v2569.l0
                let struct (v2572 : string, v2573 : string) = v2567.[int v2571]
                v2566.EnvironmentVariables.[v2572] <- v2573 
                let v2574 : int32 = v2571 + 1
                v2569.l0 <- v2574
                ()
            let v2575 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v2566)
            use v2575 = v2575 
            let v2576 : System.Diagnostics.Process = v2575 
            let v2577 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v2578 : System.Collections.Concurrent.ConcurrentStack<string> = v2577 ()
            let v2579 : bool = false
            let v2580 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v2576, v2578, v2579)
            v2576.OutputDataReceived.Add v2580 
            let v2581 : bool = true
            let v2582 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v2576, v2578, v2581)
            v2576.ErrorDataReceived.Add v2582 
            let v2583 : (unit -> bool) = v2576.Start
            let v2584 : bool = v2583 ()
            let v2585 : bool = v2584 = false
            if v2585 then
                let v2586 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v2586
            let v2587 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v2587 v2576
            let v2588 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v2588 v2576
            let v2591 : (System.Threading.CancellationToken -> US15) = method50()
            let v2592 : US15 option = v1 |> Option.map v2591 
            let v2612 : US15 = US15_1
            let v2613 : US15 = v2592 |> Option.defaultValue v2612 
            let v2620 : System.Threading.CancellationToken =
                match v2613 with
                | US15_1 -> (* None *)
                    let v2618 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v2618
                | US15_0(v2617) -> (* Some *)
                    v2617
            let v2621 : Async<System.Threading.CancellationToken> = method51(v2620)
            let! v2621 = v2621 
            let v2622 : System.Threading.CancellationToken = v2621 
            let v2623 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v2622.Register
            let v2624 : (unit -> unit) = closure22(v2576)
            let v2625 : System.Threading.CancellationTokenRegistration = v2623 v2624
            use v2625 = v2625 
            let v2626 : System.Threading.CancellationTokenRegistration = v2625 
            let v2627 : Async<int32> = method54(v2576, v2578, v2622)
            let! v2627 = v2627 
            let v2628 : int32 = v2627 
            let v2630 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v2631 : string seq = v2630 v2578
            let v2635 : (string seq -> string seq) = Seq.rev
            let v2636 : string seq = v2635 v2631
            let v2641 : string = method57()
            let v2642 : (string -> (string seq -> string)) = String.concat
            let v2643 : (string seq -> string) = v2642 v2641
            let v2644 : string = v2643 v2636
            let v2648 : unit = ()
            let v2649 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v2628, v2644)
            let v2650 : unit = (fun () -> v2649 (); v2648) ()
            return struct (v2628, v2644) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4785 : Async<struct (int32 * string)> = _let'_v2406 
    let _run_target_args'_v11 = v4785 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4787 : unit = ()
    let _let'_v4787 =
        async {
            (* run_target_args'
            let v4798 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v4801 : int32, v4802 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4801, v4802) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v4809 : int32, v4810 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4809, v4810) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v4817 : int32, v4818 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4817, v4818) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v4825 : int32, v4826 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4825, v4826) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v4833 : int32, v4834 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4833, v4834) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v4841 : int32, v4842 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4841, v4842) 
            #endif
#else
            let v4847 : US6 = method25(v0)
            let struct (v4859 : string, v4860 : US5) =
                match v4847 with
                | US6_1(v4850) -> (* Error *)
                    let v4852 : string = $"resultm.get / Result value was Error: {v4850}"
                    failwith<struct (string * US5)> v4852
                | US6_0(v4848, v4849) -> (* Ok *)
                    struct (v4848, v4849)
            let v4863 : (string -> US5) = method5()
            let v4864 : US5 option = v6 |> Option.map v4863 
            let v4884 : US5 = US5_1
            let v4885 : US5 = v4864 |> Option.defaultValue v4884 
            let v4892 : string =
                match v4885 with
                | US5_1 -> (* None *)
                    let v4890 : string = ""
                    v4890
                | US5_0(v4889) -> (* Some *)
                    v4889
            let v4893 : unit = ()
            let v4894 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v4860, v4859)
            let v4895 : unit = (fun () -> v4894 (); v4893) ()
            let v4942 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v4946 : string =
                match v4860 with
                | US5_1 -> (* None *)
                    let v4944 : string = ""
                    v4944
                | US5_0(v4943) -> (* Some *)
                    v4943
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v4946,
              StandardOutputEncoding = v4942,
              WorkingDirectory = v4892,
              FileName = v4859,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v4947 : System.Diagnostics.ProcessStartInfo = start_info
            let v4948 : (struct (string * string) []) = method41(v0, v1, v2, v3, v4, v5, v6)
            let v4949 : int32 = v4948.Length
            let v4950 : Mut5 = {l0 = 0} : Mut5
            while method42(v4949, v4950) do
                let v4952 : int32 = v4950.l0
                let struct (v4953 : string, v4954 : string) = v4948.[int v4952]
                v4947.EnvironmentVariables.[v4953] <- v4954 
                let v4955 : int32 = v4952 + 1
                v4950.l0 <- v4955
                ()
            let v4956 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v4947)
            use v4956 = v4956 
            let v4957 : System.Diagnostics.Process = v4956 
            let v4958 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v4959 : System.Collections.Concurrent.ConcurrentStack<string> = v4958 ()
            let v4960 : bool = false
            let v4961 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v4957, v4959, v4960)
            v4957.OutputDataReceived.Add v4961 
            let v4962 : bool = true
            let v4963 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v4957, v4959, v4962)
            v4957.ErrorDataReceived.Add v4963 
            let v4964 : (unit -> bool) = v4957.Start
            let v4965 : bool = v4964 ()
            let v4966 : bool = v4965 = false
            if v4966 then
                let v4967 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v4967
            let v4968 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v4968 v4957
            let v4969 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v4969 v4957
            let v4972 : (System.Threading.CancellationToken -> US15) = method50()
            let v4973 : US15 option = v1 |> Option.map v4972 
            let v4993 : US15 = US15_1
            let v4994 : US15 = v4973 |> Option.defaultValue v4993 
            let v5001 : System.Threading.CancellationToken =
                match v4994 with
                | US15_1 -> (* None *)
                    let v4999 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v4999
                | US15_0(v4998) -> (* Some *)
                    v4998
            let v5002 : Async<System.Threading.CancellationToken> = method51(v5001)
            let! v5002 = v5002 
            let v5003 : System.Threading.CancellationToken = v5002 
            let v5004 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v5003.Register
            let v5005 : (unit -> unit) = closure22(v4957)
            let v5006 : System.Threading.CancellationTokenRegistration = v5004 v5005
            use v5006 = v5006 
            let v5007 : System.Threading.CancellationTokenRegistration = v5006 
            let v5008 : Async<int32> = method54(v4957, v4959, v5003)
            let! v5008 = v5008 
            let v5009 : int32 = v5008 
            let v5011 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v5012 : string seq = v5011 v4959
            let v5016 : (string seq -> string seq) = Seq.rev
            let v5017 : string seq = v5016 v5012
            let v5022 : string = method57()
            let v5023 : (string -> (string seq -> string)) = String.concat
            let v5024 : (string seq -> string) = v5023 v5022
            let v5025 : string = v5024 v5017
            let v5029 : unit = ()
            let v5030 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v5009, v5025)
            let v5031 : unit = (fun () -> v5030 (); v5029) ()
            return struct (v5009, v5025) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7166 : Async<struct (int32 * string)> = _let'_v4787 
    let _run_target_args'_v11 = v7166 
    #endif
#else
    let v7168 : unit = ()
    let _let'_v7168 =
        async {
            (* run_target_args'
            let v7179 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v7182 : int32, v7183 : string) = null |> unbox<struct (int32 * string)>
            return struct (v7182, v7183) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v7190 : int32, v7191 : string) = null |> unbox<struct (int32 * string)>
            return struct (v7190, v7191) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v7198 : int32, v7199 : string) = null |> unbox<struct (int32 * string)>
            return struct (v7198, v7199) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v7206 : int32, v7207 : string) = null |> unbox<struct (int32 * string)>
            return struct (v7206, v7207) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v7214 : int32, v7215 : string) = null |> unbox<struct (int32 * string)>
            return struct (v7214, v7215) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v7222 : int32, v7223 : string) = null |> unbox<struct (int32 * string)>
            return struct (v7222, v7223) 
            #endif
#else
            let v7228 : US6 = method25(v0)
            let struct (v7240 : string, v7241 : US5) =
                match v7228 with
                | US6_1(v7231) -> (* Error *)
                    let v7233 : string = $"resultm.get / Result value was Error: {v7231}"
                    failwith<struct (string * US5)> v7233
                | US6_0(v7229, v7230) -> (* Ok *)
                    struct (v7229, v7230)
            let v7244 : (string -> US5) = method5()
            let v7245 : US5 option = v6 |> Option.map v7244 
            let v7265 : US5 = US5_1
            let v7266 : US5 = v7245 |> Option.defaultValue v7265 
            let v7273 : string =
                match v7266 with
                | US5_1 -> (* None *)
                    let v7271 : string = ""
                    v7271
                | US5_0(v7270) -> (* Some *)
                    v7270
            let v7274 : unit = ()
            let v7275 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v7241, v7240)
            let v7276 : unit = (fun () -> v7275 (); v7274) ()
            let v7323 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v7327 : string =
                match v7241 with
                | US5_1 -> (* None *)
                    let v7325 : string = ""
                    v7325
                | US5_0(v7324) -> (* Some *)
                    v7324
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v7327,
              StandardOutputEncoding = v7323,
              WorkingDirectory = v7273,
              FileName = v7240,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v7328 : System.Diagnostics.ProcessStartInfo = start_info
            let v7329 : (struct (string * string) []) = method41(v0, v1, v2, v3, v4, v5, v6)
            let v7330 : int32 = v7329.Length
            let v7331 : Mut5 = {l0 = 0} : Mut5
            while method42(v7330, v7331) do
                let v7333 : int32 = v7331.l0
                let struct (v7334 : string, v7335 : string) = v7329.[int v7333]
                v7328.EnvironmentVariables.[v7334] <- v7335 
                let v7336 : int32 = v7333 + 1
                v7331.l0 <- v7336
                ()
            let v7337 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v7328)
            use v7337 = v7337 
            let v7338 : System.Diagnostics.Process = v7337 
            let v7339 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v7340 : System.Collections.Concurrent.ConcurrentStack<string> = v7339 ()
            let v7341 : bool = false
            let v7342 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v7338, v7340, v7341)
            v7338.OutputDataReceived.Add v7342 
            let v7343 : bool = true
            let v7344 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v7338, v7340, v7343)
            v7338.ErrorDataReceived.Add v7344 
            let v7345 : (unit -> bool) = v7338.Start
            let v7346 : bool = v7345 ()
            let v7347 : bool = v7346 = false
            if v7347 then
                let v7348 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v7348
            let v7349 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v7349 v7338
            let v7350 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v7350 v7338
            let v7353 : (System.Threading.CancellationToken -> US15) = method50()
            let v7354 : US15 option = v1 |> Option.map v7353 
            let v7374 : US15 = US15_1
            let v7375 : US15 = v7354 |> Option.defaultValue v7374 
            let v7382 : System.Threading.CancellationToken =
                match v7375 with
                | US15_1 -> (* None *)
                    let v7380 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v7380
                | US15_0(v7379) -> (* Some *)
                    v7379
            let v7383 : Async<System.Threading.CancellationToken> = method51(v7382)
            let! v7383 = v7383 
            let v7384 : System.Threading.CancellationToken = v7383 
            let v7385 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v7384.Register
            let v7386 : (unit -> unit) = closure22(v7338)
            let v7387 : System.Threading.CancellationTokenRegistration = v7385 v7386
            use v7387 = v7387 
            let v7388 : System.Threading.CancellationTokenRegistration = v7387 
            let v7389 : Async<int32> = method54(v7338, v7340, v7384)
            let! v7389 = v7389 
            let v7390 : int32 = v7389 
            let v7392 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v7393 : string seq = v7392 v7340
            let v7397 : (string seq -> string seq) = Seq.rev
            let v7398 : string seq = v7397 v7393
            let v7403 : string = method57()
            let v7404 : (string -> (string seq -> string)) = String.concat
            let v7405 : (string seq -> string) = v7404 v7403
            let v7406 : string = v7405 v7398
            let v7410 : unit = ()
            let v7411 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v7390, v7406)
            let v7412 : unit = (fun () -> v7411 (); v7410) ()
            return struct (v7390, v7406) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9547 : Async<struct (int32 * string)> = _let'_v7168 
    let _run_target_args'_v11 = v9547 
    #endif
    let v9548 : Async<struct (int32 * string)> = _run_target_args'_v11 
    v9548
and method23 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : Async<struct (int32 * string)> =
    method24(v0, v1, v2, v3, v4, v5, v6)
and method22 (v0 : string) : Async<struct (int32 * string)> =
    let v2 : System.Threading.CancellationToken option = None
    let v5 : (struct (string * string) []) = [||]
    let v7 : (struct (int32 * string * bool) -> Async<unit>) option = None
    let v11 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option = None
    let v15 : string option = None
    let v18 : bool = true
    method23(v0, v2, v5, v7, v11, v18, v15)
and closure13 () (v0 : string) : Async<struct (int32 * string)> =
    method22(v0)
and closure25 () struct (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : Async<struct (int32 * string)> =
    method23(v0, v1, v2, v3, v4, v5, v6)
and closure26 () (v0 : (Heap0 -> Heap0)) : struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option) =
    let v2 : System.Threading.CancellationToken option = None
    let v5 : (struct (string * string) []) = [||]
    let v7 : (struct (int32 * string * bool) -> Async<unit>) option = None
    let v11 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option = None
    let v15 : string option = None
    let v18 : string = ""
    let v19 : Heap0 = {l0 = v18; l1 = v2; l2 = v5; l3 = v7; l4 = v11; l5 = true; l6 = v15} : Heap0
    let v20 : Heap0 = v0 v19
    let v21 : string = v20.l0
    let v22 : System.Threading.CancellationToken option = v20.l1
    let v23 : (struct (string * string) []) = v20.l2
    let v24 : (struct (int32 * string * bool) -> Async<unit>) option = v20.l3
    let v25 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option = v20.l4
    let v26 : bool = v20.l5
    let v27 : string option = v20.l6
    struct (v21, v22, v23, v24, v25, v26, v27)
and method62 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 4L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v19 : US9 =
            if v3 then
                US9_0('\\')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US9_0('`')
                else
                    let v8 : int64 = v5 - 1L
                    let v9 : bool = v8 = 0L
                    if v9 then
                        US9_0('"')
                    else
                        let v11 : int64 = v8 - 1L
                        let v12 : bool = v11 = 0L
                        if v12 then
                            US9_0(' ')
                        else
                            let v14 : int64 = v11 - 1L
                            US9_1
        let v23 : char =
            match v19 with
            | US9_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US9_0(v20) -> (* Some *)
                v20
        let v24 : bool = v0 = v23
        if v24 then
            true
        else
            let v25 : int64 = v1 + 1L
            method62(v0, v25)
and method63 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v114 : US7 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = ' ' :: v6 
            let v12 : char list = '"' :: v8 
            let v16 : char list = '`' :: v12 
            let v20 : char list = '\\' :: v16 
            let v24 : (char list -> (char [])) = List.toArray
            let v25 : (char []) = v24 v20
            let v29 : string = $"parsing.none_of / unexpected end of input / chars: %A{v25} / s: %A{struct (v2, v3, v4)}"
            US7_1(v29)
        else
            let v33 : char = v1.[int 0]
            let v34 : int64 = 0L
            let v35 : bool = method62(v33, v34)
            let v36 : bool = v35 = false
            if v36 then
                let v38 : (string -> int32) = String.length
                let v39 : int32 = v38 v1
                let v47 : int32 = 1 |> int32 
                let v60 : int32 = v39 |> int32 
                let v68 : int32 = v60 - 1
                let v70 : string = v1.[int v47..int v68]
                let v75 : (char -> string) = _.ToString()
                let v76 : string = v75 v33
                let v79 : int64 = System.Convert.ToInt64 v76.Length
                let v80 : int64 = 0L
                let v81 : UH0 = method27(v79, v76, v80)
                let struct (v82 : System.Text.StringBuilder, v83 : int32, v84 : int32) = method28(v81, v2, v3, v4)
                US7_0(v33, v70, v82, v83, v84)
            else
                let v86 : char list = []
                let v88 : char list = ' ' :: v86 
                let v92 : char list = '"' :: v88 
                let v96 : char list = '`' :: v92 
                let v100 : char list = '\\' :: v96 
                let v104 : (char list -> (char [])) = List.toArray
                let v105 : (char []) = v104 v100
                let v109 : string = $"parsing.none_of / unexpected char: '{v33}' / chars: %A{v105} / s: %A{struct (v2, v3, v4)}"
                US7_1(v109)
    match v114 with
    | US7_1(v131) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v115, v116, v117, v118, v119) -> (* Ok *)
        let v121 : (char -> string) = _.ToString()
        let v122 : string = v121 v115
        let v125 : string = v0 + v122 
        method63(v125, v116, v117, v118, v119)
and method65 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 3L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v15 : US9 =
            if v3 then
                US9_0('\\')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US9_0('`')
                else
                    let v8 : int64 = v5 - 1L
                    let v9 : bool = v8 = 0L
                    if v9 then
                        US9_0('"')
                    else
                        let v11 : int64 = v8 - 1L
                        US9_1
        let v19 : char =
            match v15 with
            | US9_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US9_0(v16) -> (* Some *)
                v16
        let v20 : bool = v0 = v19
        if v20 then
            true
        else
            let v21 : int64 = v1 + 1L
            method65(v0, v21)
and closure28 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US8 =
    let v4 : bool = "" = v0
    let v125 : US7 =
        if v4 then
            let v6 : string = $"parsing.p_char / unexpected end of input / c: '{'\\'}' / s: %A{struct (v1, v2, v3)}"
            US7_1(v6)
        else
            let v10 : char = v0.[int 0]
            let v11 : bool = v10 = '\\'
            if v11 then
                let v13 : (string -> int32) = String.length
                let v14 : int32 = v13 v0
                let v22 : int32 = 1 |> int32 
                let v35 : int32 = v14 |> int32 
                let v43 : int32 = v35 - 1
                let v45 : string = v0.[int v22..int v43]
                let v50 : (char -> string) = _.ToString()
                let v51 : string = v50 v10
                let v54 : int64 = System.Convert.ToInt64 v51.Length
                let v55 : int64 = 0L
                let v56 : UH0 = method27(v54, v51, v55)
                let struct (v57 : System.Text.StringBuilder, v58 : int32, v59 : int32) = method28(v56, v1, v2, v3)
                US7_0(v10, v45, v57, v58, v59)
            else
                let v62 : string = "\n"
                let v63 : int32 = v0.IndexOf v62 
                let v66 : int32 = v63 - 1
                let v67 : bool = -2 = v66
                let v75 : int32 =
                    if v67 then
                        let v69 : (string -> int32) = String.length
                        let v70 : int32 = v69 v0
                        let v73 : int32 = v70 + 1
                        v73
                    else
                        let v74 : int32 = v66 + 1
                        v74
                let v81 : int32 = 0 |> int32 
                let v94 : int32 = v75 |> int32 
                let v102 : int32 = v94 - 1
                let v104 : string = v0.[int v81..int v102]
                let v109 : string = $"parsing.p_char / expected: '{'\\'}' / line: {v2} / col: {v3}
{v1}{v104}"
                let v112 : int32 = v3 - 1
                let v113 : int32 = 0
                let v114 : (string -> string) = method29(v112, v113)
                let v115 : string = ""
                let v116 : string = v114 v115
                let v117 : string = "^"
                let v118 : string = v116 + v117 
                let v120 : string = $"{v109}
{v118}
"
                US7_1(v120)
    let v196 : US7 =
        match v125 with
        | US7_1(v193) -> (* Error *)
            US7_1(v193)
        | US7_0(v126, v127, v128, v129, v130) -> (* Ok *)
            let v131 : bool = "" = v127
            if v131 then
                let v138 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v128, v129, v130)}"
                US7_1(v138)
            else
                let v142 : char = v127.[int 0]
                let v144 : (string -> int32) = String.length
                let v145 : int32 = v144 v127
                let v153 : int32 = 1 |> int32 
                let v166 : int32 = v145 |> int32 
                let v174 : int32 = v166 - 1
                let v176 : string = v127.[int v153..int v174]
                let v181 : (char -> string) = _.ToString()
                let v182 : string = v181 v142
                let v185 : int64 = System.Convert.ToInt64 v182.Length
                let v186 : int64 = 0L
                let v187 : UH0 = method27(v185, v182, v186)
                let struct (v188 : System.Text.StringBuilder, v189 : int32, v190 : int32) = method28(v187, v128, v129, v130)
                US7_0(v142, v176, v188, v189, v190)
    match v196 with
    | US7_1(v214) -> (* Error *)
        US8_1(v214)
    | US7_0(v197, v198, v199, v200, v201) -> (* Ok *)
        let v203 : (char -> string) = _.ToString()
        let v204 : string = v203 '\\'
        let v208 : (char -> string) = _.ToString()
        let v209 : string = v208 v197
        let v212 : string = v204 + v209 
        US8_0(v212, v198, v199, v200, v201)
and closure29 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US8 =
    let v4 : bool = "" = v0
    let v125 : US7 =
        if v4 then
            let v6 : string = $"parsing.p_char / unexpected end of input / c: '{'`'}' / s: %A{struct (v1, v2, v3)}"
            US7_1(v6)
        else
            let v10 : char = v0.[int 0]
            let v11 : bool = v10 = '`'
            if v11 then
                let v13 : (string -> int32) = String.length
                let v14 : int32 = v13 v0
                let v22 : int32 = 1 |> int32 
                let v35 : int32 = v14 |> int32 
                let v43 : int32 = v35 - 1
                let v45 : string = v0.[int v22..int v43]
                let v50 : (char -> string) = _.ToString()
                let v51 : string = v50 v10
                let v54 : int64 = System.Convert.ToInt64 v51.Length
                let v55 : int64 = 0L
                let v56 : UH0 = method27(v54, v51, v55)
                let struct (v57 : System.Text.StringBuilder, v58 : int32, v59 : int32) = method28(v56, v1, v2, v3)
                US7_0(v10, v45, v57, v58, v59)
            else
                let v62 : string = "\n"
                let v63 : int32 = v0.IndexOf v62 
                let v66 : int32 = v63 - 1
                let v67 : bool = -2 = v66
                let v75 : int32 =
                    if v67 then
                        let v69 : (string -> int32) = String.length
                        let v70 : int32 = v69 v0
                        let v73 : int32 = v70 + 1
                        v73
                    else
                        let v74 : int32 = v66 + 1
                        v74
                let v81 : int32 = 0 |> int32 
                let v94 : int32 = v75 |> int32 
                let v102 : int32 = v94 - 1
                let v104 : string = v0.[int v81..int v102]
                let v109 : string = $"parsing.p_char / expected: '{'`'}' / line: {v2} / col: {v3}
{v1}{v104}"
                let v112 : int32 = v3 - 1
                let v113 : int32 = 0
                let v114 : (string -> string) = method29(v112, v113)
                let v115 : string = ""
                let v116 : string = v114 v115
                let v117 : string = "^"
                let v118 : string = v116 + v117 
                let v120 : string = $"{v109}
{v118}
"
                US7_1(v120)
    let v196 : US7 =
        match v125 with
        | US7_1(v193) -> (* Error *)
            US7_1(v193)
        | US7_0(v126, v127, v128, v129, v130) -> (* Ok *)
            let v131 : bool = "" = v127
            if v131 then
                let v138 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v128, v129, v130)}"
                US7_1(v138)
            else
                let v142 : char = v127.[int 0]
                let v144 : (string -> int32) = String.length
                let v145 : int32 = v144 v127
                let v153 : int32 = 1 |> int32 
                let v166 : int32 = v145 |> int32 
                let v174 : int32 = v166 - 1
                let v176 : string = v127.[int v153..int v174]
                let v181 : (char -> string) = _.ToString()
                let v182 : string = v181 v142
                let v185 : int64 = System.Convert.ToInt64 v182.Length
                let v186 : int64 = 0L
                let v187 : UH0 = method27(v185, v182, v186)
                let struct (v188 : System.Text.StringBuilder, v189 : int32, v190 : int32) = method28(v187, v128, v129, v130)
                US7_0(v142, v176, v188, v189, v190)
    match v196 with
    | US7_1(v214) -> (* Error *)
        US8_1(v214)
    | US7_0(v197, v198, v199, v200, v201) -> (* Ok *)
        let v203 : (char -> string) = _.ToString()
        let v204 : string = v203 '`'
        let v208 : (char -> string) = _.ToString()
        let v209 : string = v208 v197
        let v212 : string = v204 + v209 
        US8_0(v212, v198, v199, v200, v201)
and method66 (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32, v4 : UH3) : US8 =
    match v4 with
    | UH3_1(v7, v8) -> (* Cons *)
        let v9 : US8 = v7 struct (v0, v1, v2, v3)
        match v9 with
        | US8_1(v15) -> (* Error *)
            method66(v0, v1, v2, v3, v8)
        | US8_0(v10, v11, v12, v13, v14) -> (* Ok *)
            v9
    | UH3_0 -> (* Nil *)
        let v5 : string = "parsing.choice / no parsers succeeded"
        US8_1(v5)
and method67 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_1(v2, v3) -> (* Cons *)
        let v4 : UH2 = UH2_1(v2, v1)
        method67(v3, v4)
    | UH2_0 -> (* Nil *)
        v1
and method64 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US17 =
    let v5 : bool = "" = v1
    let v106 : US7 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = '"' :: v6 
            let v12 : char list = '`' :: v8 
            let v16 : char list = '\\' :: v12 
            let v20 : (char list -> (char [])) = List.toArray
            let v21 : (char []) = v20 v16
            let v25 : string = $"parsing.none_of / unexpected end of input / chars: %A{v21} / s: %A{struct (v2, v3, v4)}"
            US7_1(v25)
        else
            let v29 : char = v1.[int 0]
            let v30 : int64 = 0L
            let v31 : bool = method65(v29, v30)
            let v32 : bool = v31 = false
            if v32 then
                let v34 : (string -> int32) = String.length
                let v35 : int32 = v34 v1
                let v43 : int32 = 1 |> int32 
                let v56 : int32 = v35 |> int32 
                let v64 : int32 = v56 - 1
                let v66 : string = v1.[int v43..int v64]
                let v71 : (char -> string) = _.ToString()
                let v72 : string = v71 v29
                let v75 : int64 = System.Convert.ToInt64 v72.Length
                let v76 : int64 = 0L
                let v77 : UH0 = method27(v75, v72, v76)
                let struct (v78 : System.Text.StringBuilder, v79 : int32, v80 : int32) = method28(v77, v2, v3, v4)
                US7_0(v29, v66, v78, v79, v80)
            else
                let v82 : char list = []
                let v84 : char list = '"' :: v82 
                let v88 : char list = '`' :: v84 
                let v92 : char list = '\\' :: v88 
                let v96 : (char list -> (char [])) = List.toArray
                let v97 : (char []) = v96 v92
                let v101 : string = $"parsing.none_of / unexpected char: '{v29}' / chars: %A{v97} / s: %A{struct (v2, v3, v4)}"
                US7_1(v101)
    let v121 : US8 =
        match v106 with
        | US7_1(v118) -> (* Error *)
            US8_1(v118)
        | US7_0(v107, v108, v109, v110, v111) -> (* Ok *)
            let v113 : (char -> string) = _.ToString()
            let v114 : string = v113 v107
            US8_0(v114, v108, v109, v110, v111)
    let v135 : US8 =
        match v121 with
        | US8_1(v127) -> (* Error *)
            let v128 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure28()
            let v129 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure29()
            let v130 : UH3 = UH3_0
            let v131 : UH3 = UH3_1(v129, v130)
            let v132 : UH3 = UH3_1(v128, v131)
            method66(v1, v2, v3, v4, v132)
        | US8_0(v122, v123, v124, v125, v126) -> (* Ok *)
            v121
    match v135 with
    | US8_1(v143) -> (* Error *)
        let v144 : UH2 = UH2_0
        let v145 : UH2 = method67(v0, v144)
        US17_0(v145, v1, v2, v3, v4)
    | US8_0(v136, v137, v138, v139, v140) -> (* Ok *)
        let v141 : UH2 = UH2_1(v136, v0)
        method64(v141, v137, v138, v139, v140)
and method68 (v0 : UH2, v1 : string list) : string list =
    match v0 with
    | UH2_1(v2, v3) -> (* Cons *)
        let v4 : string list = method68(v3, v1)
        let v6 : string list = v2 :: v4 
        v6
    | UH2_0 -> (* Nil *)
        v1
and method69 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US17 =
    let v5 : bool = "" = v1
    let v106 : US7 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = '"' :: v6 
            let v12 : char list = '`' :: v8 
            let v16 : char list = '\\' :: v12 
            let v20 : (char list -> (char [])) = List.toArray
            let v21 : (char []) = v20 v16
            let v25 : string = $"parsing.none_of / unexpected end of input / chars: %A{v21} / s: %A{struct (v2, v3, v4)}"
            US7_1(v25)
        else
            let v29 : char = v1.[int 0]
            let v30 : int64 = 0L
            let v31 : bool = method65(v29, v30)
            let v32 : bool = v31 = false
            if v32 then
                let v34 : (string -> int32) = String.length
                let v35 : int32 = v34 v1
                let v43 : int32 = 1 |> int32 
                let v56 : int32 = v35 |> int32 
                let v64 : int32 = v56 - 1
                let v66 : string = v1.[int v43..int v64]
                let v71 : (char -> string) = _.ToString()
                let v72 : string = v71 v29
                let v75 : int64 = System.Convert.ToInt64 v72.Length
                let v76 : int64 = 0L
                let v77 : UH0 = method27(v75, v72, v76)
                let struct (v78 : System.Text.StringBuilder, v79 : int32, v80 : int32) = method28(v77, v2, v3, v4)
                US7_0(v29, v66, v78, v79, v80)
            else
                let v82 : char list = []
                let v84 : char list = '"' :: v82 
                let v88 : char list = '`' :: v84 
                let v92 : char list = '\\' :: v88 
                let v96 : (char list -> (char [])) = List.toArray
                let v97 : (char []) = v96 v92
                let v101 : string = $"parsing.none_of / unexpected char: '{v29}' / chars: %A{v97} / s: %A{struct (v2, v3, v4)}"
                US7_1(v101)
    let v121 : US8 =
        match v106 with
        | US7_1(v118) -> (* Error *)
            US8_1(v118)
        | US7_0(v107, v108, v109, v110, v111) -> (* Ok *)
            let v113 : (char -> string) = _.ToString()
            let v114 : string = v113 v107
            US8_0(v114, v108, v109, v110, v111)
    match v121 with
    | US8_1(v129) -> (* Error *)
        let v130 : UH2 = UH2_0
        let v131 : UH2 = method67(v0, v130)
        US17_0(v131, v1, v2, v3, v4)
    | US8_0(v122, v123, v124, v125, v126) -> (* Ok *)
        let v127 : UH2 = UH2_1(v122, v0)
        method69(v127, v123, v124, v125, v126)
and method61 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US17 =
    let v5 : bool = "" = v1
    let v114 : US7 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = ' ' :: v6 
            let v12 : char list = '"' :: v8 
            let v16 : char list = '`' :: v12 
            let v20 : char list = '\\' :: v16 
            let v24 : (char list -> (char [])) = List.toArray
            let v25 : (char []) = v24 v20
            let v29 : string = $"parsing.none_of / unexpected end of input / chars: %A{v25} / s: %A{struct (v2, v3, v4)}"
            US7_1(v29)
        else
            let v33 : char = v1.[int 0]
            let v34 : int64 = 0L
            let v35 : bool = method62(v33, v34)
            let v36 : bool = v35 = false
            if v36 then
                let v38 : (string -> int32) = String.length
                let v39 : int32 = v38 v1
                let v47 : int32 = 1 |> int32 
                let v60 : int32 = v39 |> int32 
                let v68 : int32 = v60 - 1
                let v70 : string = v1.[int v47..int v68]
                let v75 : (char -> string) = _.ToString()
                let v76 : string = v75 v33
                let v79 : int64 = System.Convert.ToInt64 v76.Length
                let v80 : int64 = 0L
                let v81 : UH0 = method27(v79, v76, v80)
                let struct (v82 : System.Text.StringBuilder, v83 : int32, v84 : int32) = method28(v81, v2, v3, v4)
                US7_0(v33, v70, v82, v83, v84)
            else
                let v86 : char list = []
                let v88 : char list = ' ' :: v86 
                let v92 : char list = '"' :: v88 
                let v96 : char list = '`' :: v92 
                let v100 : char list = '\\' :: v96 
                let v104 : (char list -> (char [])) = List.toArray
                let v105 : (char []) = v104 v100
                let v109 : string = $"parsing.none_of / unexpected char: '{v33}' / chars: %A{v105} / s: %A{struct (v2, v3, v4)}"
                US7_1(v109)
    let v134 : US8 =
        match v114 with
        | US7_1(v131) -> (* Error *)
            US8_1(v131)
        | US7_0(v115, v116, v117, v118, v119) -> (* Ok *)
            let v121 : (char -> string) = _.ToString()
            let v122 : string = v121 v115
            let struct (v125 : string, v126 : string, v127 : System.Text.StringBuilder, v128 : int32, v129 : int32) = method63(v122, v116, v117, v118, v119)
            US8_0(v125, v126, v127, v128, v129)
    let v522 : US8 =
        match v134 with
        | US8_1(v140) -> (* Error *)
            let v261 : US7 =
                if v5 then
                    let v142 : string = $"parsing.p_char / unexpected end of input / c: '{'"'}' / s: %A{struct (v2, v3, v4)}"
                    US7_1(v142)
                else
                    let v146 : char = v1.[int 0]
                    let v147 : bool = v146 = '"'
                    if v147 then
                        let v149 : (string -> int32) = String.length
                        let v150 : int32 = v149 v1
                        let v158 : int32 = 1 |> int32 
                        let v171 : int32 = v150 |> int32 
                        let v179 : int32 = v171 - 1
                        let v181 : string = v1.[int v158..int v179]
                        let v186 : (char -> string) = _.ToString()
                        let v187 : string = v186 v146
                        let v190 : int64 = System.Convert.ToInt64 v187.Length
                        let v191 : int64 = 0L
                        let v192 : UH0 = method27(v190, v187, v191)
                        let struct (v193 : System.Text.StringBuilder, v194 : int32, v195 : int32) = method28(v192, v2, v3, v4)
                        US7_0(v146, v181, v193, v194, v195)
                    else
                        let v198 : string = "\n"
                        let v199 : int32 = v1.IndexOf v198 
                        let v202 : int32 = v199 - 1
                        let v203 : bool = -2 = v202
                        let v211 : int32 =
                            if v203 then
                                let v205 : (string -> int32) = String.length
                                let v206 : int32 = v205 v1
                                let v209 : int32 = v206 + 1
                                v209
                            else
                                let v210 : int32 = v202 + 1
                                v210
                        let v217 : int32 = 0 |> int32 
                        let v230 : int32 = v211 |> int32 
                        let v238 : int32 = v230 - 1
                        let v240 : string = v1.[int v217..int v238]
                        let v245 : string = $"parsing.p_char / expected: '{'"'}' / line: {v3} / col: {v4}
{v2}{v240}"
                        let v248 : int32 = v4 - 1
                        let v249 : int32 = 0
                        let v250 : (string -> string) = method29(v248, v249)
                        let v251 : string = ""
                        let v252 : string = v250 v251
                        let v253 : string = "^"
                        let v254 : string = v252 + v253 
                        let v256 : string = $"{v245}
{v254}
"
                        US7_1(v256)
            let v451 : US8 =
                match v261 with
                | US7_1(v448) -> (* Error *)
                    US8_1(v448)
                | US7_0(v262, v263, v264, v265, v266) -> (* Ok *)
                    let v267 : UH2 = UH2_0
                    let v268 : US17 = method64(v267, v263, v264, v265, v266)
                    let v301 : US8 =
                        match v268 with
                        | US17_1(v298) -> (* Error *)
                            US8_1(v298)
                        | US17_0(v269, v270, v271, v272, v273) -> (* Ok *)
                            let v274 : string list = []
                            let v275 : string list = method68(v269, v274)
                            let v280 : unit = ()
                            let _let'_v280 =
                                seq {
                                    yield! v275 
                                    (* indent
                                    ()
                                indent *)
                                }
                                (* indent
                                ()
                            indent *)
                            let v283 : string seq = _let'_v280 
                            let v291 : (string -> (string seq -> string)) = String.concat
                            let v292 : string = ""
                            let v293 : (string seq -> string) = v291 v292
                            let v294 : string = v293 v283
                            US8_0(v294, v270, v271, v272, v273)
                    match v301 with
                    | US8_1(v443) -> (* Error *)
                        let v444 : string = "parsing.between / expected content"
                        US8_1(v444)
                    | US8_0(v302, v303, v304, v305, v306) -> (* Ok *)
                        let v307 : bool = "" = v303
                        let v428 : US7 =
                            if v307 then
                                let v309 : string = $"parsing.p_char / unexpected end of input / c: '{'"'}' / s: %A{struct (v304, v305, v306)}"
                                US7_1(v309)
                            else
                                let v313 : char = v303.[int 0]
                                let v314 : bool = v313 = '"'
                                if v314 then
                                    let v316 : (string -> int32) = String.length
                                    let v317 : int32 = v316 v303
                                    let v325 : int32 = 1 |> int32 
                                    let v338 : int32 = v317 |> int32 
                                    let v346 : int32 = v338 - 1
                                    let v348 : string = v303.[int v325..int v346]
                                    let v353 : (char -> string) = _.ToString()
                                    let v354 : string = v353 v313
                                    let v357 : int64 = System.Convert.ToInt64 v354.Length
                                    let v358 : int64 = 0L
                                    let v359 : UH0 = method27(v357, v354, v358)
                                    let struct (v360 : System.Text.StringBuilder, v361 : int32, v362 : int32) = method28(v359, v304, v305, v306)
                                    US7_0(v313, v348, v360, v361, v362)
                                else
                                    let v365 : string = "\n"
                                    let v366 : int32 = v303.IndexOf v365 
                                    let v369 : int32 = v366 - 1
                                    let v370 : bool = -2 = v369
                                    let v378 : int32 =
                                        if v370 then
                                            let v372 : (string -> int32) = String.length
                                            let v373 : int32 = v372 v303
                                            let v376 : int32 = v373 + 1
                                            v376
                                        else
                                            let v377 : int32 = v369 + 1
                                            v377
                                    let v384 : int32 = 0 |> int32 
                                    let v397 : int32 = v378 |> int32 
                                    let v405 : int32 = v397 - 1
                                    let v407 : string = v303.[int v384..int v405]
                                    let v412 : string = $"parsing.p_char / expected: '{'"'}' / line: {v305} / col: {v306}
{v304}{v407}"
                                    let v415 : int32 = v306 - 1
                                    let v416 : int32 = 0
                                    let v417 : (string -> string) = method29(v415, v416)
                                    let v418 : string = ""
                                    let v419 : string = v417 v418
                                    let v420 : string = "^"
                                    let v421 : string = v419 + v420 
                                    let v423 : string = $"{v412}
{v421}
"
                                    US7_1(v423)
                        match v428 with
                        | US7_1(v435) -> (* Error *)
                            let v437 : string = $"parsing.between / expected closing delimiter / e: %A{v435} / input: %A{struct (v1, v2, v3, v4)} / rest1: %A{struct (v263, v264, v265, v266)} / rest2: %A{struct (v303, v304, v305, v306)}"
                            US8_1(v437)
                        | US7_0(v429, v430, v431, v432, v433) -> (* Ok *)
                            US8_0(v302, v430, v431, v432, v433)
            match v451 with
            | US8_1(v457) -> (* Error *)
                let v458 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure28()
                let v459 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure29()
                let v460 : UH3 = UH3_0
                let v461 : UH3 = UH3_1(v459, v460)
                let v462 : UH3 = UH3_1(v458, v461)
                let v463 : US8 = method66(v1, v2, v3, v4, v462)
                let v474 : US8 =
                    match v463 with
                    | US8_1(v471) -> (* Error *)
                        US8_1(v471)
                    | US8_0(v464, v465, v466, v467, v468) -> (* Ok *)
                        let v469 : string = ""
                        US8_0(v469, v465, v466, v467, v468)
                let v485 : US17 =
                    match v474 with
                    | US8_1(v482) -> (* Error *)
                        US17_1(v482)
                    | US8_0(v475, v476, v477, v478, v479) -> (* Ok *)
                        let v480 : UH2 = UH2_0
                        method69(v480, v476, v477, v478, v479)
                match v485 with
                | US17_1(v515) -> (* Error *)
                    US8_1(v515)
                | US17_0(v486, v487, v488, v489, v490) -> (* Ok *)
                    let v491 : string list = []
                    let v492 : string list = method68(v486, v491)
                    let v497 : unit = ()
                    let _let'_v497 =
                        seq {
                            yield! v492 
                            (* indent
                            ()
                        indent *)
                        }
                        (* indent
                        ()
                    indent *)
                    let v500 : string seq = _let'_v497 
                    let v508 : (string -> (string seq -> string)) = String.concat
                    let v509 : string = ""
                    let v510 : (string seq -> string) = v508 v509
                    let v511 : string = v510 v500
                    US8_0(v511, v487, v488, v489, v490)
            | US8_0(v452, v453, v454, v455, v456) -> (* Ok *)
                v451
        | US8_0(v135, v136, v137, v138, v139) -> (* Ok *)
            v134
    match v522 with
    | US8_1(v585) -> (* Error *)
        let v586 : UH2 = UH2_0
        let v587 : UH2 = method67(v0, v586)
        US17_0(v587, v1, v2, v3, v4)
    | US8_0(v523, v524, v525, v526, v527) -> (* Ok *)
        let v528 : int32 = 0
        let v529 : int32 = method36(v524, v528)
        let v530 : bool = 0 = v529
        let v571 : US10 =
            if v530 then
                let v531 : string = "parsing.spaces1 / expected at least one space"
                US10_1(v531)
            else
                let v534 : (string -> int32) = String.length
                let v535 : int32 = v534 v524
                let v543 : int32 = v529 |> int32 
                let v556 : int32 = v535 |> int32 
                let v564 : int32 = v556 - 1
                let v566 : string = v524.[int v543..int v564]
                US10_0(v566, v525, v526, v527)
        match v571 with
        | US10_1(v578) -> (* Error *)
            let v579 : UH2 = UH2_0
            let v580 : UH2 = UH2_1(v523, v579)
            let v581 : UH2 = method67(v0, v580)
            US17_0(v581, v524, v525, v526, v527)
        | US10_0(v572, v573, v574, v575) -> (* Ok *)
            let v576 : UH2 = UH2_1(v523, v0)
            method61(v576, v572, v573, v574, v575)
and method60 (v0 : string) : US16 =
    let mutable _v0 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v2 : (string -> string option) = Option.ofObj
    let v3 : string option = v2 v0
    v3 
    #else
    Some v0 
    #endif
    |> fun x -> _v0 <- Some x
    let v4 : string option = match _v0 with Some x -> x | None -> failwith "optionm'.of_obj / _v0=None"
    let v9 : string = ""
    let v10 : string = v4 |> Option.defaultValue v9 
    let v13 : string = method26()
    let v15 : (string -> System.Text.StringBuilder) = System.Text.StringBuilder 
    let v16 : System.Text.StringBuilder = v15 v13
    let v19 : UH2 = UH2_0
    let v20 : int32 = 1
    let v21 : int32 = 1
    let v22 : US17 = method61(v19, v10, v16, v20, v21)
    match v22 with
    | US17_1(v36) -> (* Error *)
        US16_1(v36)
    | US17_0(v23, v24, v25, v26, v27) -> (* Ok *)
        let v28 : string list = []
        let v29 : string list = method68(v23, v28)
        let v31 : (string list -> (string [])) = List.toArray
        let v32 : (string []) = v31 v29
        US16_0(v32)
and closure27 () (v0 : string) : Result<(string []), string> =
    let v1 : US16 = method60(v0)
    match v1 with
    | US16_1(v7) -> (* Error *)
        let v9 : Result<(string []), string> = Error v7 
        v9
    | US16_0(v2) -> (* Ok *)
        let v4 : Result<(string []), string> = Ok v2 
        v4
let v0 : unit = ()
let v1 : (unit -> unit) = closure0()
let v2 : unit = (fun () -> v1 (); v0) ()
let v17 : (unit -> unit) = closure3()
let current_process_kill () = v17 ()
let v18 : (string -> Async<struct (int32 * string)>) = closure13()
let execute_async x = v18 x
let v19 : (struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option) -> Async<struct (int32 * string)>) = closure25()
let execute_with_options_async x = v19 x
let v20 : ((Heap0 -> Heap0) -> struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option)) = closure26()
let execution_options x = v20 x
let v21 : (string -> Result<(string []), string>) = closure27()
let split_args x = v21 x
()
