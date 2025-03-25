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
and method7 (v0 : US0) : bool =
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
    let v187 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v190 : (int64 -> US2) = method9()
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
    let v346 : string = method10()
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
    let v371 : (int64 -> US2) = method9()
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
    let v527 : string = method10()
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
    let v554 : (int64 -> US2) = method9()
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
    let v601 : (int64 -> US2) = method9()
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
    let v757 : string = method11()
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
    let v782 : (int64 -> US2) = method9()
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
    let v938 : string = method11()
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
    let v963 : (int64 -> US2) = method9()
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
    let v1119 : string = method11()
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
    let v1144 : (int64 -> US2) = method9()
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
    let v1300 : string = method11()
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
and method13 () : string =
    let v0 : string = ""
    v0
and closure7 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v4 : string = v2 + v1 
    v0.l0 <- v4
    ()
and method14 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method12 () : string =
    
    
    
    
    
    let v2 : string = "Warning"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method13()
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
    let v48 : string = "inline_colorization::color_yellow"
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
    let v89 : string = "inline_colorization::color_yellow"
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
    let v130 : string = "inline_colorization::color_yellow"
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
    let v172 : string = "\u001b[93m"
    let v176 : string = method14()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[93m"
    let v192 : string = method14()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[93m"
    let v208 : string = method14()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[93m"
    let v224 : string = method14()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
and method16 (v0 : string) : string =
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
and method15 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string) : string =
    let v8 : string = method13()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v10 : string = v9.l0
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
    let v43 : string = "runtime.current_process_kill / exiting... 3"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method16(v54)
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
and method17 (v0 : string) : unit =
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
and closure5 () () : unit =
    let v0 : US0 = US0_3
    let v1 : bool = method7(v0)
    if v1 then
        let v16 : unit = ()
        let v17 : (unit -> unit) = closure0()
        let v18 : unit = (fun () -> v17 (); v16) ()
        let struct (v39 : Mut0, v40 : Mut1, v41 : Mut2, v42 : Mut3, v43 : Mut4, v44 : int64 option) = TraceState.trace_state.Value
        let v57 : string = method8(v39, v40, v41, v42, v43, v44)
        let v58 : string = method12()
        let v59 : string = method15(v39, v40, v41, v42, v43, v44, v57, v58)
        method17(v59)
and method18 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string) : string =
    let v8 : string = method13()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v10 : string = v9.l0
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
    let v43 : string = "runtime.current_process_kill / exiting... 2"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method16(v54)
and closure11 () () : unit =
    let v0 : US0 = US0_3
    let v1 : bool = method7(v0)
    if v1 then
        let v16 : unit = ()
        let v17 : (unit -> unit) = closure0()
        let v18 : unit = (fun () -> v17 (); v16) ()
        let struct (v39 : Mut0, v40 : Mut1, v41 : Mut2, v42 : Mut3, v43 : Mut4, v44 : int64 option) = TraceState.trace_state.Value
        let v57 : string = method8(v39, v40, v41, v42, v43, v44)
        let v58 : string = method12()
        let v59 : string = method18(v39, v40, v41, v42, v43, v44, v57, v58)
        method17(v59)
and method19 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string) : string =
    let v8 : string = method13()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v10 : string = v9.l0
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
    let v43 : string = "runtime.current_process_kill / exiting... 1"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method16(v54)
and closure12 () () : unit =
    let v0 : US0 = US0_3
    let v1 : bool = method7(v0)
    if v1 then
        let v16 : unit = ()
        let v17 : (unit -> unit) = closure0()
        let v18 : unit = (fun () -> v17 (); v16) ()
        let struct (v39 : Mut0, v40 : Mut1, v41 : Mut2, v42 : Mut3, v43 : Mut4, v44 : int64 option) = TraceState.trace_state.Value
        let v57 : string = method8(v39, v40, v41, v42, v43, v44)
        let v58 : string = method12()
        let v59 : string = method19(v39, v40, v41, v42, v43, v44, v57, v58)
        method17(v59)
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
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure5()
    let v63 : unit = (fun () -> v62 (); v61) ()
    System.Threading.Thread.Sleep 300
    let v184 : unit = ()
    let v185 : (unit -> unit) = closure11()
    let v186 : unit = (fun () -> v185 (); v184) ()
    System.Console.Out.Flush ()
    System.Threading.Thread.Sleep 60
    let v307 : unit = ()
    let v308 : (unit -> unit) = closure12()
    let v309 : unit = (fun () -> v308 (); v307) ()
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
and method24 () : string =
    let v0 : string = ""
    v0
and method25 (v0 : int64, v1 : string, v2 : int64) : UH0 =
    let v3 : bool = v2 < v0
    if v3 then
        let v4 : char = v1.[int v2]
        let v5 : int64 = v2 + 1L
        let v6 : UH0 = method25(v0, v1, v5)
        UH0_1(v4, v6)
    else
        UH0_0
and method26 (v0 : UH0, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : struct (System.Text.StringBuilder * int32 * int32) =
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
        method26(v5, v27, v9, v10)
    | UH0_0 -> (* Nil *)
        struct (v1, v2, v3)
and closure15 (v0 : int32, v1 : int32) (v2 : string) : string =
    let v3 : bool = v1 >= v0
    if v3 then
        v2
    else
        let v4 : int32 = v1 + 1
        let v5 : (string -> string) = method27(v0, v4)
        let v8 : string = " "
        let v9 : string = v2 + v8 
        v5 v9
and method27 (v0 : int32, v1 : int32) : (string -> string) =
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
            let v56 : UH0 = method25(v54, v51, v55)
            let struct (v57 : System.Text.StringBuilder, v58 : int32, v59 : int32) = method26(v56, v1, v2, v3)
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
            let v114 : (string -> string) = method27(v112, v113)
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
            let v56 : UH0 = method25(v54, v51, v55)
            let struct (v57 : System.Text.StringBuilder, v58 : int32, v59 : int32) = method26(v56, v1, v2, v3)
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
            let v114 : (string -> string) = method27(v112, v113)
            let v115 : string = ""
            let v116 : string = v114 v115
            let v117 : string = "^"
            let v118 : string = v116 + v117 
            let v120 : string = $"{v109}
{v118}
"
            US7_1(v120)
and method28 (v0 : string, v1 : System.Text.StringBuilder, v2 : UH1) : US7 =
    match v2 with
    | UH1_1(v5, v6) -> (* Cons *)
        let v7 : US7 = v5 struct (v0, v1, 1, 1)
        match v7 with
        | US7_1(v13) -> (* Error *)
            method28(v0, v1, v6)
        | US7_0(v8, v9, v10, v11, v12) -> (* Ok *)
            v7
    | UH1_0 -> (* Nil *)
        let v3 : string = "parsing.choice / no parsers succeeded"
        US7_1(v3)
and method29 (v0 : char, v1 : int64) : bool =
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
            method29(v0, v17)
and method30 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
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
            let v27 : bool = method29(v25, v26)
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
                let v73 : UH0 = method25(v71, v68, v72)
                let struct (v74 : System.Text.StringBuilder, v75 : int32, v76 : int32) = method26(v73, v2, v3, v4)
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
        method30(v121, v112, v113, v114, v115)
and method31 (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32, v4 : UH1) : US7 =
    match v4 with
    | UH1_1(v7, v8) -> (* Cons *)
        let v9 : US7 = v7 struct (v0, v1, v2, v3)
        match v9 with
        | US7_1(v15) -> (* Error *)
            method31(v0, v1, v2, v3, v8)
        | US7_0(v10, v11, v12, v13, v14) -> (* Ok *)
            v9
    | UH1_0 -> (* Nil *)
        let v5 : string = "parsing.choice / no parsers succeeded"
        US7_1(v5)
and method32 (v0 : char, v1 : int64) : bool =
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
            method32(v0, v21)
and method33 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
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
            let v31 : bool = method32(v29, v30)
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
                let v77 : UH0 = method25(v75, v72, v76)
                let struct (v78 : System.Text.StringBuilder, v79 : int32, v80 : int32) = method26(v77, v2, v3, v4)
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
        method33(v129, v120, v121, v122, v123)
and method34 (v0 : string, v1 : int32) : int32 =
    let v2 : int32 = v0.Length
    let v3 : bool = v1 >= v2
    if v3 then
        v1
    else
        let v4 : char = v0.[int v1]
        let v5 : bool = ' ' = v4
        if v5 then
            let v6 : int32 = v1 + 1
            method34(v0, v6)
        else
            v1
and method35 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
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
            let v61 : UH0 = method25(v59, v56, v60)
            let struct (v62 : System.Text.StringBuilder, v63 : int32, v64 : int32) = method26(v61, v2, v3, v4)
            US7_0(v16, v50, v62, v63, v64)
    match v66 with
    | US7_1(v83) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v67, v68, v69, v70, v71) -> (* Ok *)
        let v73 : (char -> string) = _.ToString()
        let v74 : string = v73 v67
        let v77 : string = v0 + v74 
        method35(v77, v68, v69, v70, v71)
and method23 (v0 : string) : US6 =
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
    let v13 : string = method24()
    let v15 : (string -> System.Text.StringBuilder) = System.Text.StringBuilder 
    let v16 : System.Text.StringBuilder = v15 v13
    let v19 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US7) = closure14()
    let v20 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US7) = closure16()
    let v21 : UH1 = UH1_0
    let v22 : UH1 = UH1_1(v20, v21)
    let v23 : UH1 = UH1_1(v19, v22)
    let v24 : US7 = method28(v10, v16, v23)
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
                    let v52 : bool = method29(v50, v51)
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
                        let v98 : UH0 = method25(v96, v93, v97)
                        let struct (v99 : System.Text.StringBuilder, v100 : int32, v101 : int32) = method26(v98, v27, v28, v29)
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
                    let struct (v146 : string, v147 : string, v148 : System.Text.StringBuilder, v149 : int32, v150 : int32) = method30(v143, v137, v138, v139, v140)
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
                let v174 : US7 = method31(v167, v168, v169, v170, v173)
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
                    let v230 : bool = method32(v228, v229)
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
                        let v276 : UH0 = method25(v274, v271, v275)
                        let v277 : int32 = 1
                        let v278 : int32 = 1
                        let struct (v279 : System.Text.StringBuilder, v280 : int32, v281 : int32) = method26(v276, v16, v277, v278)
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
                    let struct (v330 : string, v331 : string, v332 : System.Text.StringBuilder, v333 : int32, v334 : int32) = method33(v327, v321, v322, v323, v324)
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
                    let v370 : int32 = method34(v365, v369)
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
                        let v474 : UH0 = method25(v472, v469, v473)
                        let struct (v475 : System.Text.StringBuilder, v476 : int32, v477 : int32) = method26(v474, v419, v420, v421)
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
                        let v532 : (string -> string) = method27(v530, v531)
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
                            let v616 : UH0 = method25(v614, v611, v615)
                            let struct (v617 : System.Text.StringBuilder, v618 : int32, v619 : int32) = method26(v616, v557, v558, v559)
                            US7_0(v571, v605, v617, v618, v619)
                    match v621 with
                    | US7_1(v638) -> (* Error *)
                        US8_1(v638)
                    | US7_0(v622, v623, v624, v625, v626) -> (* Ok *)
                        let v628 : (char -> string) = _.ToString()
                        let v629 : string = v628 v622
                        let struct (v632 : string, v633 : string, v634 : System.Text.StringBuilder, v635 : int32, v636 : int32) = method35(v629, v623, v624, v625, v626)
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
and method36 () : string =
    
    
    
    
    
    let v2 : string = "Debug"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method13()
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
    let v48 : string = "inline_colorization::color_bright_blue"
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
    let v89 : string = "inline_colorization::color_bright_blue"
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
    let v130 : string = "inline_colorization::color_bright_blue"
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
    let v172 : string = "\u001b[94m"
    let v176 : string = method14()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[94m"
    let v192 : string = method14()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[94m"
    let v208 : string = method14()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[94m"
    let v224 : string = method14()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
and method37 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : US5, v10 : string, v11 : System.Threading.CancellationToken option, v12 : (struct (string * string) []), v13 : (struct (int32 * string * bool) -> Async<unit>) option, v14 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v15 : bool, v16 : string option) : string =
    let v17 : string = method13()
    let v18 : Mut3 = {l0 = v17} : Mut3
    let v21 : string = "{ "
    let v22 : string = $"{v21}"
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure7(v18, v22)
    let v32 : unit = (fun () -> v31 (); v30) ()
    let v40 : string = "file_name"
    let v41 : string = $"{v40}"
    let v49 : unit = ()
    let v50 : (unit -> unit) = closure7(v18, v41)
    let v51 : unit = (fun () -> v50 (); v49) ()
    let v59 : string = " = "
    let v60 : string = $"{v59}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure7(v18, v60)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v77 : string = $"{v8}"
    let v85 : unit = ()
    let v86 : (unit -> unit) = closure7(v18, v77)
    let v87 : unit = (fun () -> v86 (); v85) ()
    let v95 : string = "; "
    let v96 : string = $"{v95}"
    let v104 : unit = ()
    let v105 : (unit -> unit) = closure7(v18, v96)
    let v106 : unit = (fun () -> v105 (); v104) ()
    let v114 : string = "arguments"
    let v115 : string = $"{v114}"
    let v123 : unit = ()
    let v124 : (unit -> unit) = closure7(v18, v115)
    let v125 : unit = (fun () -> v124 (); v123) ()
    let v132 : string = $"{v59}"
    let v140 : unit = ()
    let v141 : (unit -> unit) = closure7(v18, v132)
    let v142 : unit = (fun () -> v141 (); v140) ()
    let v149 : string = $"%A{v9}"
    let v153 : string = $"{v149}"
    let v161 : unit = ()
    let v162 : (unit -> unit) = closure7(v18, v153)
    let v163 : unit = (fun () -> v162 (); v161) ()
    let v170 : string = $"{v95}"
    let v178 : unit = ()
    let v179 : (unit -> unit) = closure7(v18, v170)
    let v180 : unit = (fun () -> v179 (); v178) ()
    let v188 : string = "options"
    let v189 : string = $"{v188}"
    let v197 : unit = ()
    let v198 : (unit -> unit) = closure7(v18, v189)
    let v199 : unit = (fun () -> v198 (); v197) ()
    let v206 : string = $"{v59}"
    let v214 : unit = ()
    let v215 : (unit -> unit) = closure7(v18, v206)
    let v216 : unit = (fun () -> v215 (); v214) ()
    let v223 : string = $"{v21}"
    let v231 : unit = ()
    let v232 : (unit -> unit) = closure7(v18, v223)
    let v233 : unit = (fun () -> v232 (); v231) ()
    let v241 : string = "command"
    let v242 : string = $"{v241}"
    let v250 : unit = ()
    let v251 : (unit -> unit) = closure7(v18, v242)
    let v252 : unit = (fun () -> v251 (); v250) ()
    let v259 : string = $"{v59}"
    let v267 : unit = ()
    let v268 : (unit -> unit) = closure7(v18, v259)
    let v269 : unit = (fun () -> v268 (); v267) ()
    let v276 : string = $"{v10}"
    let v284 : unit = ()
    let v285 : (unit -> unit) = closure7(v18, v276)
    let v286 : unit = (fun () -> v285 (); v284) ()
    let v293 : string = $"{v95}"
    let v301 : unit = ()
    let v302 : (unit -> unit) = closure7(v18, v293)
    let v303 : unit = (fun () -> v302 (); v301) ()
    let v311 : string = "cancellation_token"
    let v312 : string = $"{v311}"
    let v320 : unit = ()
    let v321 : (unit -> unit) = closure7(v18, v312)
    let v322 : unit = (fun () -> v321 (); v320) ()
    let v329 : string = $"{v59}"
    let v337 : unit = ()
    let v338 : (unit -> unit) = closure7(v18, v329)
    let v339 : unit = (fun () -> v338 (); v337) ()
    (* run_target_args'
    let v349 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v350 : string = "format!(\"{:#?}\", $0)"
    let v351 : std_string_String = Fable.Core.RustInterop.emitRustExpr v11 v350 
    let v352 : string = "fable_library_rust::String_::fromString($0)"
    let v353 : string = Fable.Core.RustInterop.emitRustExpr v351 v352 
    let _run_target_args'_v349 = v353 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v354 : string = "format!(\"{:#?}\", $0)"
    let v355 : std_string_String = Fable.Core.RustInterop.emitRustExpr v11 v354 
    let v356 : string = "fable_library_rust::String_::fromString($0)"
    let v357 : string = Fable.Core.RustInterop.emitRustExpr v355 v356 
    let _run_target_args'_v349 = v357 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v358 : string = "format!(\"{:#?}\", $0)"
    let v359 : std_string_String = Fable.Core.RustInterop.emitRustExpr v11 v358 
    let v360 : string = "fable_library_rust::String_::fromString($0)"
    let v361 : string = Fable.Core.RustInterop.emitRustExpr v359 v360 
    let _run_target_args'_v349 = v361 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v363 : string = $"%A{v11}"
    let _run_target_args'_v349 = v363 
    #endif
#if FABLE_COMPILER_PYTHON
    let v367 : string = $"%A{v11}"
    let _run_target_args'_v349 = v367 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v371 : string = $"%A{v11}"
    let _run_target_args'_v349 = v371 
    #endif
#else
    let v375 : string = $"%A{v11}"
    let _run_target_args'_v349 = v375 
    #endif
    let v378 : string = _run_target_args'_v349 
    let v385 : string = $"{v378}"
    let v393 : unit = ()
    let v394 : (unit -> unit) = closure7(v18, v385)
    let v395 : unit = (fun () -> v394 (); v393) ()
    let v402 : string = $"{v95}"
    let v410 : unit = ()
    let v411 : (unit -> unit) = closure7(v18, v402)
    let v412 : unit = (fun () -> v411 (); v410) ()
    let v420 : string = "environment_variables"
    let v421 : string = $"{v420}"
    let v429 : unit = ()
    let v430 : (unit -> unit) = closure7(v18, v421)
    let v431 : unit = (fun () -> v430 (); v429) ()
    let v438 : string = $"{v59}"
    let v446 : unit = ()
    let v447 : (unit -> unit) = closure7(v18, v438)
    let v448 : unit = (fun () -> v447 (); v446) ()
    let v455 : string = $"%A{v12}"
    let v459 : string = $"{v455}"
    let v467 : unit = ()
    let v468 : (unit -> unit) = closure7(v18, v459)
    let v469 : unit = (fun () -> v468 (); v467) ()
    let v476 : string = $"{v95}"
    let v484 : unit = ()
    let v485 : (unit -> unit) = closure7(v18, v476)
    let v486 : unit = (fun () -> v485 (); v484) ()
    let v494 : string = "on_line"
    let v495 : string = $"{v494}"
    let v503 : unit = ()
    let v504 : (unit -> unit) = closure7(v18, v495)
    let v505 : unit = (fun () -> v504 (); v503) ()
    let v512 : string = $"{v59}"
    let v520 : unit = ()
    let v521 : (unit -> unit) = closure7(v18, v512)
    let v522 : unit = (fun () -> v521 (); v520) ()
    (* run_target_args'
    let v532 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v533 : string = "format!(\"{:#?}\", $0)"
    let v534 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v533 
    let v535 : string = "fable_library_rust::String_::fromString($0)"
    let v536 : string = Fable.Core.RustInterop.emitRustExpr v534 v535 
    let _run_target_args'_v532 = v536 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v537 : string = "format!(\"{:#?}\", $0)"
    let v538 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v537 
    let v539 : string = "fable_library_rust::String_::fromString($0)"
    let v540 : string = Fable.Core.RustInterop.emitRustExpr v538 v539 
    let _run_target_args'_v532 = v540 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v541 : string = "format!(\"{:#?}\", $0)"
    let v542 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v541 
    let v543 : string = "fable_library_rust::String_::fromString($0)"
    let v544 : string = Fable.Core.RustInterop.emitRustExpr v542 v543 
    let _run_target_args'_v532 = v544 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v546 : string = $"%A{v13}"
    let _run_target_args'_v532 = v546 
    #endif
#if FABLE_COMPILER_PYTHON
    let v550 : string = $"%A{v13}"
    let _run_target_args'_v532 = v550 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v554 : string = $"%A{v13}"
    let _run_target_args'_v532 = v554 
    #endif
#else
    let v558 : string = $"%A{v13}"
    let _run_target_args'_v532 = v558 
    #endif
    let v561 : string = _run_target_args'_v532 
    let v568 : string = $"{v561}"
    let v576 : unit = ()
    let v577 : (unit -> unit) = closure7(v18, v568)
    let v578 : unit = (fun () -> v577 (); v576) ()
    let v585 : string = $"{v95}"
    let v593 : unit = ()
    let v594 : (unit -> unit) = closure7(v18, v585)
    let v595 : unit = (fun () -> v594 (); v593) ()
    let v603 : string = "stdin"
    let v604 : string = $"{v603}"
    let v612 : unit = ()
    let v613 : (unit -> unit) = closure7(v18, v604)
    let v614 : unit = (fun () -> v613 (); v612) ()
    let v621 : string = $"{v59}"
    let v629 : unit = ()
    let v630 : (unit -> unit) = closure7(v18, v621)
    let v631 : unit = (fun () -> v630 (); v629) ()
    (* run_target_args'
    let v641 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v642 : string = "format!(\"{:#?}\", $0)"
    let v643 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v642 
    let v644 : string = "fable_library_rust::String_::fromString($0)"
    let v645 : string = Fable.Core.RustInterop.emitRustExpr v643 v644 
    let _run_target_args'_v641 = v645 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v646 : string = "format!(\"{:#?}\", $0)"
    let v647 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v646 
    let v648 : string = "fable_library_rust::String_::fromString($0)"
    let v649 : string = Fable.Core.RustInterop.emitRustExpr v647 v648 
    let _run_target_args'_v641 = v649 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v650 : string = "format!(\"{:#?}\", $0)"
    let v651 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v650 
    let v652 : string = "fable_library_rust::String_::fromString($0)"
    let v653 : string = Fable.Core.RustInterop.emitRustExpr v651 v652 
    let _run_target_args'_v641 = v653 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v655 : string = $"%A{v14}"
    let _run_target_args'_v641 = v655 
    #endif
#if FABLE_COMPILER_PYTHON
    let v659 : string = $"%A{v14}"
    let _run_target_args'_v641 = v659 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v663 : string = $"%A{v14}"
    let _run_target_args'_v641 = v663 
    #endif
#else
    let v667 : string = $"%A{v14}"
    let _run_target_args'_v641 = v667 
    #endif
    let v670 : string = _run_target_args'_v641 
    let v677 : string = $"{v670}"
    let v685 : unit = ()
    let v686 : (unit -> unit) = closure7(v18, v677)
    let v687 : unit = (fun () -> v686 (); v685) ()
    let v694 : string = $"{v95}"
    let v702 : unit = ()
    let v703 : (unit -> unit) = closure7(v18, v694)
    let v704 : unit = (fun () -> v703 (); v702) ()
    let v712 : string = "trace"
    let v713 : string = $"{v712}"
    let v721 : unit = ()
    let v722 : (unit -> unit) = closure7(v18, v713)
    let v723 : unit = (fun () -> v722 (); v721) ()
    let v730 : string = $"{v59}"
    let v738 : unit = ()
    let v739 : (unit -> unit) = closure7(v18, v730)
    let v740 : unit = (fun () -> v739 (); v738) ()
    let v748 : string =
        if v15 then
            let v746 : string = "true"
            v746
        else
            let v747 : string = "false"
            v747
    let v750 : string = $"{v748}"
    let v758 : unit = ()
    let v759 : (unit -> unit) = closure7(v18, v750)
    let v760 : unit = (fun () -> v759 (); v758) ()
    let v767 : string = $"{v95}"
    let v775 : unit = ()
    let v776 : (unit -> unit) = closure7(v18, v767)
    let v777 : unit = (fun () -> v776 (); v775) ()
    let v785 : string = "working_directory"
    let v786 : string = $"{v785}"
    let v794 : unit = ()
    let v795 : (unit -> unit) = closure7(v18, v786)
    let v796 : unit = (fun () -> v795 (); v794) ()
    let v803 : string = $"{v59}"
    let v811 : unit = ()
    let v812 : (unit -> unit) = closure7(v18, v803)
    let v813 : unit = (fun () -> v812 (); v811) ()
    (* run_target_args'
    let v823 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v824 : string = "format!(\"{:#?}\", $0)"
    let v825 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v824 
    let v826 : string = "fable_library_rust::String_::fromString($0)"
    let v827 : string = Fable.Core.RustInterop.emitRustExpr v825 v826 
    let _run_target_args'_v823 = v827 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v828 : string = "format!(\"{:#?}\", $0)"
    let v829 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v828 
    let v830 : string = "fable_library_rust::String_::fromString($0)"
    let v831 : string = Fable.Core.RustInterop.emitRustExpr v829 v830 
    let _run_target_args'_v823 = v831 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v832 : string = "format!(\"{:#?}\", $0)"
    let v833 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v832 
    let v834 : string = "fable_library_rust::String_::fromString($0)"
    let v835 : string = Fable.Core.RustInterop.emitRustExpr v833 v834 
    let _run_target_args'_v823 = v835 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v837 : string = $"%A{v16}"
    let _run_target_args'_v823 = v837 
    #endif
#if FABLE_COMPILER_PYTHON
    let v841 : string = $"%A{v16}"
    let _run_target_args'_v823 = v841 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v845 : string = $"%A{v16}"
    let _run_target_args'_v823 = v845 
    #endif
#else
    let v849 : string = $"%A{v16}"
    let _run_target_args'_v823 = v849 
    #endif
    let v852 : string = _run_target_args'_v823 
    let v859 : string = $"{v852}"
    let v867 : unit = ()
    let v868 : (unit -> unit) = closure7(v18, v859)
    let v869 : unit = (fun () -> v868 (); v867) ()
    let v877 : string = " }"
    let v878 : string = $"{v877}"
    let v886 : unit = ()
    let v887 : (unit -> unit) = closure7(v18, v878)
    let v888 : unit = (fun () -> v887 (); v886) ()
    let v895 : string = $"{v877}"
    let v903 : unit = ()
    let v904 : (unit -> unit) = closure7(v18, v895)
    let v905 : unit = (fun () -> v904 (); v903) ()
    let v911 : string = v18.l0
    let v912 : int64 = v0.l0
    let v915 : string = " "
    let v916 : string = v6 + v915 
    let v920 : string = v916 + v7 
    let v925 : string = " #"
    let v926 : string = v920 + v925 
    let v930 : (int64 -> string) = _.ToString()
    let v931 : string = v930 v912
    let v935 : string = v926 + v931 
    let v939 : string = v935 + v915 
    let v944 : string = "runtime.execute_with_options_async"
    let v945 : string = v939 + v944 
    let v950 : string = " / "
    let v951 : string = v945 + v950 
    let v955 : string = v951 + v911 
    method16(v955)
and closure17 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : US5, v8 : string) () : unit =
    let v9 : US0 = US0_1
    let v10 : bool = method7(v9)
    if v10 then
        let v25 : unit = ()
        let v26 : (unit -> unit) = closure0()
        let v27 : unit = (fun () -> v26 (); v25) ()
        let struct (v48 : Mut0, v49 : Mut1, v50 : Mut2, v51 : Mut3, v52 : Mut4, v53 : int64 option) = TraceState.trace_state.Value
        let v66 : string = method8(v48, v49, v50, v51, v52, v53)
        let v67 : string = method36()
        let v68 : string = method37(v48, v49, v50, v51, v52, v53, v66, v67, v8, v7, v0, v1, v2, v3, v4, v5, v6)
        method17(v68)
and method38 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : (struct (string * string) []) =
    v2
and method39 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method42 (v0 : System.Diagnostics.DataReceivedEventArgs) : string =
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
and method43 () : ((struct (int32 * string * bool) -> Async<unit>) -> US14) =
    closure19()
and method44 (v0 : System.Diagnostics.Process) : int32 =
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
and method45 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method13()
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
    let v176 : string = method14()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[90m"
    let v192 : string = method14()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[90m"
    let v208 : string = method14()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[90m"
    let v224 : string = method14()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
and method46 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method13()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v11 : string = v10.l0
    let v12 : int64 = v0.l0
    let v15 : string = " "
    let v16 : string = v6 + v15 
    let v20 : string = v16 + v7 
    let v25 : string = " #"
    let v26 : string = v20 + v25 
    let v30 : (int64 -> string) = _.ToString()
    let v31 : string = v30 v12
    let v35 : string = v26 + v31 
    let v39 : string = v35 + v15 
    let v43 : string = v39 + v8 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v11 
    method16(v53)
and closure20 (v0 : string) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method7(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure0()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method8(v40, v41, v42, v43, v44, v45)
        let v59 : string = method45()
        let v60 : bool = v0 = ""
        let v63 : string =
            if v60 then
                let v61 : string = ""
                v61
            else
                method46(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method17(v63)
and method41 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool, v10 : System.Diagnostics.DataReceivedEventArgs) : Async<unit> =
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
            let v2424 : string = method42(v10)
            let v2426 : string = null |> unbox<string>
            let v2429 : bool = v2424 = v2426
            let v2430 : bool = v2429 <> true
            if v2430 then
                let v2433 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method43()
                let v2434 : US14 option = v3 |> Option.map v2433 
                let v2454 : US14 = US14_1
                let v2455 : US14 = v2434 |> Option.defaultValue v2454 
                match v2455 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v2459) -> (* Some *)
                    let v2460 : int32 = method44(v7)
                    let v2461 : Async<unit> = v2459 struct (v2460, v2424, v9)
                    do! v2461 
                    ()
                let v2464 : string =
                    if v9 then
                        let v2462 : string = $"! {v2424}"
                        v2462
                    else
                        let v2463 : string = $"> {v2424}"
                        v2463
                if v5 then
                    let v2528 : unit = ()
                    let v2529 : (unit -> unit) = closure20(v2464)
                    let v2530 : unit = (fun () -> v2529 (); v2528) ()
                    ()
                else
                    let v2595 : unit = ()
                    let v2596 : (unit -> unit) = closure10(v2464)
                    let v2597 : unit = (fun () -> v2596 (); v2595) ()
                    ()
                let v2601 : string =
                    if v9 then
                        let v2599 : string = "\u001b[7;4m"
                        v2599
                    else
                        let v2600 : string = ""
                        v2600
                let v2604 : string =
                    if v9 then
                        let v2602 : string = "\u001b[0m"
                        v2602
                    else
                        let v2603 : string = ""
                        v2603
                let v2605 : string = $"{v2601}{v2424}{v2604}"
                (* run_target_args'
                let v2606 : unit = ()
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
                let v2607 : (string -> unit) = v8.Push
                v2607 v2605
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
    let v5000 : Async<unit> = _let'_v29 
    let _run_target_args'_v15 = v5000 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5002 : unit = ()
    let _let'_v5002 =
        async {
            let v7397 : string = method42(v10)
            let v7399 : string = null |> unbox<string>
            let v7402 : bool = v7397 = v7399
            let v7403 : bool = v7402 <> true
            if v7403 then
                let v7406 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method43()
                let v7407 : US14 option = v3 |> Option.map v7406 
                let v7427 : US14 = US14_1
                let v7428 : US14 = v7407 |> Option.defaultValue v7427 
                match v7428 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v7432) -> (* Some *)
                    let v7433 : int32 = method44(v7)
                    let v7434 : Async<unit> = v7432 struct (v7433, v7397, v9)
                    do! v7434 
                    ()
                let v7437 : string =
                    if v9 then
                        let v7435 : string = $"! {v7397}"
                        v7435
                    else
                        let v7436 : string = $"> {v7397}"
                        v7436
                if v5 then
                    let v7501 : unit = ()
                    let v7502 : (unit -> unit) = closure20(v7437)
                    let v7503 : unit = (fun () -> v7502 (); v7501) ()
                    ()
                else
                    let v7568 : unit = ()
                    let v7569 : (unit -> unit) = closure10(v7437)
                    let v7570 : unit = (fun () -> v7569 (); v7568) ()
                    ()
                let v7574 : string =
                    if v9 then
                        let v7572 : string = "\u001b[7;4m"
                        v7572
                    else
                        let v7573 : string = ""
                        v7573
                let v7577 : string =
                    if v9 then
                        let v7575 : string = "\u001b[0m"
                        v7575
                    else
                        let v7576 : string = ""
                        v7576
                let v7578 : string = $"{v7574}{v7397}{v7577}"
                (* run_target_args'
                let v7579 : unit = ()
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
                let v7580 : (string -> unit) = v8.Push
                v7580 v7578
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
    let v9973 : Async<unit> = _let'_v5002 
    let _run_target_args'_v15 = v9973 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v9975 : unit = ()
    let _let'_v9975 =
        async {
            let v12370 : string = method42(v10)
            let v12372 : string = null |> unbox<string>
            let v12375 : bool = v12370 = v12372
            let v12376 : bool = v12375 <> true
            if v12376 then
                let v12379 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method43()
                let v12380 : US14 option = v3 |> Option.map v12379 
                let v12400 : US14 = US14_1
                let v12401 : US14 = v12380 |> Option.defaultValue v12400 
                match v12401 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v12405) -> (* Some *)
                    let v12406 : int32 = method44(v7)
                    let v12407 : Async<unit> = v12405 struct (v12406, v12370, v9)
                    do! v12407 
                    ()
                let v12410 : string =
                    if v9 then
                        let v12408 : string = $"! {v12370}"
                        v12408
                    else
                        let v12409 : string = $"> {v12370}"
                        v12409
                if v5 then
                    let v12474 : unit = ()
                    let v12475 : (unit -> unit) = closure20(v12410)
                    let v12476 : unit = (fun () -> v12475 (); v12474) ()
                    ()
                else
                    let v12541 : unit = ()
                    let v12542 : (unit -> unit) = closure10(v12410)
                    let v12543 : unit = (fun () -> v12542 (); v12541) ()
                    ()
                let v12547 : string =
                    if v9 then
                        let v12545 : string = "\u001b[7;4m"
                        v12545
                    else
                        let v12546 : string = ""
                        v12546
                let v12550 : string =
                    if v9 then
                        let v12548 : string = "\u001b[0m"
                        v12548
                    else
                        let v12549 : string = ""
                        v12549
                let v12551 : string = $"{v12547}{v12370}{v12550}"
                (* run_target_args'
                let v12552 : unit = ()
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
                let v12553 : (string -> unit) = v8.Push
                v12553 v12551
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
    let v14946 : Async<unit> = _let'_v9975 
    let _run_target_args'_v15 = v14946 
    #endif
#else
    let v14948 : unit = ()
    let _let'_v14948 =
        async {
            let v17343 : string = method42(v10)
            let v17345 : string = null |> unbox<string>
            let v17348 : bool = v17343 = v17345
            let v17349 : bool = v17348 <> true
            if v17349 then
                let v17352 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method43()
                let v17353 : US14 option = v3 |> Option.map v17352 
                let v17373 : US14 = US14_1
                let v17374 : US14 = v17353 |> Option.defaultValue v17373 
                match v17374 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v17378) -> (* Some *)
                    let v17379 : int32 = method44(v7)
                    let v17380 : Async<unit> = v17378 struct (v17379, v17343, v9)
                    do! v17380 
                    ()
                let v17383 : string =
                    if v9 then
                        let v17381 : string = $"! {v17343}"
                        v17381
                    else
                        let v17382 : string = $"> {v17343}"
                        v17382
                if v5 then
                    let v17447 : unit = ()
                    let v17448 : (unit -> unit) = closure20(v17383)
                    let v17449 : unit = (fun () -> v17448 (); v17447) ()
                    ()
                else
                    let v17514 : unit = ()
                    let v17515 : (unit -> unit) = closure10(v17383)
                    let v17516 : unit = (fun () -> v17515 (); v17514) ()
                    ()
                let v17520 : string =
                    if v9 then
                        let v17518 : string = "\u001b[7;4m"
                        v17518
                    else
                        let v17519 : string = ""
                        v17519
                let v17523 : string =
                    if v9 then
                        let v17521 : string = "\u001b[0m"
                        v17521
                    else
                        let v17522 : string = ""
                        v17522
                let v17524 : string = $"{v17520}{v17343}{v17523}"
                (* run_target_args'
                let v17525 : unit = ()
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
                let v17526 : (string -> unit) = v8.Push
                v17526 v17524
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
    let v19919 : Async<unit> = _let'_v14948 
    let _run_target_args'_v15 = v19919 
    #endif
    let v19920 : Async<unit> = _run_target_args'_v15 
    v19920
and method40 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool, v10 : System.Diagnostics.DataReceivedEventArgs) : Async<unit> =
    method41(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
and closure18 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool) (v10 : System.Diagnostics.DataReceivedEventArgs) : unit =
    let v11 : Async<unit> = method40(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
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
and method47 () : (System.Threading.CancellationToken -> US15) =
    closure21()
and method48 (v0 : System.Threading.CancellationToken) : Async<System.Threading.CancellationToken> =
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
            let v546 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v548 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v548 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v552 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v552 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v556 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v556 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v560 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v560 
            #endif
#if FABLE_COMPILER_PYTHON
            let v564 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v564 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v568 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v568 
            #endif
#else
            let v571 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v571 = v571 
            let v572 : System.Threading.CancellationToken = v571 
            let v573 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v574 : (System.Threading.CancellationToken []) = [|v572; v573; v0|]
            let v575 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v576 : System.Threading.CancellationTokenSource = v575 v574
            let v577 : System.Threading.CancellationToken = v576.Token
            return v577 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1102 : Async<System.Threading.CancellationToken> = _let'_v19 
    let _run_target_args'_v5 = v1102 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1104 : unit = ()
    let _let'_v1104 =
        async {
            (* run_target_args'
            let v1631 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1633 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1633 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1637 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1637 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1641 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1641 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1645 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1645 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1649 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1649 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1653 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1653 
            #endif
#else
            let v1656 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v1656 = v1656 
            let v1657 : System.Threading.CancellationToken = v1656 
            let v1658 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v1659 : (System.Threading.CancellationToken []) = [|v1657; v1658; v0|]
            let v1660 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v1661 : System.Threading.CancellationTokenSource = v1660 v1659
            let v1662 : System.Threading.CancellationToken = v1661.Token
            return v1662 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2187 : Async<System.Threading.CancellationToken> = _let'_v1104 
    let _run_target_args'_v5 = v2187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2189 : unit = ()
    let _let'_v2189 =
        async {
            (* run_target_args'
            let v2716 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2718 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2718 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2722 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2722 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2726 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2726 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2730 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2730 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2734 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2734 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2738 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2738 
            #endif
#else
            let v2741 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v2741 = v2741 
            let v2742 : System.Threading.CancellationToken = v2741 
            let v2743 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v2744 : (System.Threading.CancellationToken []) = [|v2742; v2743; v0|]
            let v2745 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v2746 : System.Threading.CancellationTokenSource = v2745 v2744
            let v2747 : System.Threading.CancellationToken = v2746.Token
            return v2747 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3272 : Async<System.Threading.CancellationToken> = _let'_v2189 
    let _run_target_args'_v5 = v3272 
    #endif
#else
    let v3274 : unit = ()
    let _let'_v3274 =
        async {
            (* run_target_args'
            let v3801 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3803 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3803 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3807 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3807 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3811 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3811 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3815 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3815 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3819 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3819 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3823 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3823 
            #endif
#else
            let v3826 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v3826 = v3826 
            let v3827 : System.Threading.CancellationToken = v3826 
            let v3828 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v3829 : (System.Threading.CancellationToken []) = [|v3827; v3828; v0|]
            let v3830 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v3831 : System.Threading.CancellationTokenSource = v3830 v3829
            let v3832 : System.Threading.CancellationToken = v3831.Token
            return v3832 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4357 : Async<System.Threading.CancellationToken> = _let'_v3274 
    let _run_target_args'_v5 = v4357 
    #endif
    let v4358 : Async<System.Threading.CancellationToken> = _run_target_args'_v5 
    v4358
and method49 (v0 : System.Diagnostics.Process) : bool =
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
and method50 (v0 : System.Diagnostics.Process) : unit =
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
    let v1 : bool = method49(v0)
    let v2 : bool = v1 = false
    if v2 then
        method50(v0)
and method52 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : System.Threading.Tasks.TaskCanceledException) : string =
    let v9 : string = method13()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure7(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "ex"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure7(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure7(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    (* run_target_args'
    let v72 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v73 : string = "format!(\"{:#?}\", $0)"
    let v74 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v73 
    let v75 : string = "fable_library_rust::String_::fromString($0)"
    let v76 : string = Fable.Core.RustInterop.emitRustExpr v74 v75 
    let _run_target_args'_v72 = v76 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v77 : string = "format!(\"{:#?}\", $0)"
    let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v77 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v72 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "format!(\"{:#?}\", $0)"
    let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v81 
    let v83 : string = "fable_library_rust::String_::fromString($0)"
    let v84 : string = Fable.Core.RustInterop.emitRustExpr v82 v83 
    let _run_target_args'_v72 = v84 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v86 : string = $"%A{v8}"
    let _run_target_args'_v72 = v86 
    #endif
#if FABLE_COMPILER_PYTHON
    let v90 : string = $"%A{v8}"
    let _run_target_args'_v72 = v90 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v94 : string = $"%A{v8}"
    let _run_target_args'_v72 = v94 
    #endif
#else
    let v98 : string = $"%A{v8}"
    let _run_target_args'_v72 = v98 
    #endif
    let v101 : string = _run_target_args'_v72 
    let v108 : string = $"{v101}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure7(v10, v108)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v126 : string = " }"
    let v127 : string = $"{v126}"
    let v135 : unit = ()
    let v136 : (unit -> unit) = closure7(v10, v127)
    let v137 : unit = (fun () -> v136 (); v135) ()
    let v143 : string = v10.l0
    let v144 : int64 = v0.l0
    let v147 : string = " "
    let v148 : string = v6 + v147 
    let v152 : string = v148 + v7 
    let v157 : string = " #"
    let v158 : string = v152 + v157 
    let v162 : (int64 -> string) = _.ToString()
    let v163 : string = v162 v144
    let v167 : string = v158 + v163 
    let v171 : string = v167 + v147 
    let v176 : string = "runtime.execute_with_options_async / WaitForExitAsync"
    let v177 : string = v171 + v176 
    let v182 : string = " / "
    let v183 : string = v177 + v182 
    let v187 : string = v183 + v143 
    method16(v187)
and closure23 (v0 : System.Threading.Tasks.TaskCanceledException) () : unit =
    let v1 : US0 = US0_3
    let v2 : bool = method7(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure0()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method8(v40, v41, v42, v43, v44, v45)
        let v59 : string = method12()
        let v60 : string = method52(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method17(v60)
and method51 (v0 : System.Diagnostics.Process, v1 : System.Collections.Concurrent.ConcurrentStack<string>, v2 : System.Threading.CancellationToken) : Async<int32> =
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
                let v10622 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10624 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10622 = v10624 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10628 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10622 = v10628 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10632 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10622 = v10632 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10636 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10622 = v10636 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10640 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10622 = v10640 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10644 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v10622 = v10644 
                #endif
#else
                let v10647 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v10622 = v10647 
                #endif
                let v10648 : System.Threading.Tasks.Task = _run_target_args'_v10622 
                (* run_target_args'
                let v10658 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10660 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v10658 = v10660 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10664 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v10658 = v10664 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10668 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v10658 = v10668 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10671 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10672 : Async<unit> = v10671 v10648
                let _run_target_args'_v10658 = v10672 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10673 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10674 : Async<unit> = v10673 v10648
                let _run_target_args'_v10658 = v10674 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10675 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10676 : Async<unit> = v10675 v10648
                let _run_target_args'_v10658 = v10676 
                #endif
#else
                let v10677 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v10678 : Async<unit> = v10677 v10648
                let _run_target_args'_v10658 = v10678 
                #endif
                let v10679 : Async<unit> = _run_target_args'_v10658 
                do! v10679 
                (* run_target_args'
                let v10689 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10691 : int32 = null |> unbox<int32>
                let _run_target_args'_v10689 = v10691 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v10695 : int32 = null |> unbox<int32>
                let _run_target_args'_v10689 = v10695 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v10699 : int32 = null |> unbox<int32>
                let _run_target_args'_v10689 = v10699 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v10703 : int32 = null |> unbox<int32>
                let _run_target_args'_v10689 = v10703 
                #endif
#if FABLE_COMPILER_PYTHON
                let v10707 : int32 = null |> unbox<int32>
                let _run_target_args'_v10689 = v10707 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v10711 : int32 = null |> unbox<int32>
                let _run_target_args'_v10689 = v10711 
                #endif
#else
                let v10714 : int32 = v0.ExitCode
                let _run_target_args'_v10689 = v10714 
                #endif
                let v10715 : int32 = _run_target_args'_v10689 
                return v10715 
                (* indent
                ()
            indent *)
            with ex ->
                let v10990 : exn = ex
                (* run_target_args'
                let v10995 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v10997 : string = $"%A{v10990}"
                let _run_target_args'_v10995 = v10997 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v11001 : string = $"%A{v10990}"
                let _run_target_args'_v10995 = v11001 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v11005 : string = $"%A{v10990}"
                let _run_target_args'_v10995 = v11005 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v11009 : string = $"%A{v10990}"
                let _run_target_args'_v10995 = v11009 
                #endif
#if FABLE_COMPILER_PYTHON
                let v11013 : string = $"%A{v10990}"
                let _run_target_args'_v10995 = v11013 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v11017 : string = $"%A{v10990}"
                let _run_target_args'_v10995 = v11017 
                #endif
#else
                let v11020 : string = $"{v10990.GetType ()}: {v10990.Message}"
                let _run_target_args'_v10995 = v11020 
                #endif
                let v11021 : string = _run_target_args'_v10995 
                (* run_target_args'
                let v11027 : unit = ()
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
                let v11028 : (string -> unit) = v1.Push
                v11028 v11021
                #endif
                // run_target_args' is_unit
                let v11030 : System.Threading.Tasks.TaskCanceledException = v10990 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v11093 : unit = ()
                let v11094 : (unit -> unit) = closure23(v11030)
                let v11095 : unit = (fun () -> v11094 (); v11093) ()
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
    let v21813 : Async<int32> = _let'_v21 
    let _run_target_args'_v7 = v21813 
    #endif
#if FABLE_COMPILER_PYTHON
    let v21815 : unit = ()
    let _let'_v21815 =
        async {
            try
                (* run_target_args'
                let v32416 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v32418 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32416 = v32418 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v32422 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32416 = v32422 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v32426 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32416 = v32426 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v32430 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32416 = v32430 
                #endif
#if FABLE_COMPILER_PYTHON
                let v32434 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32416 = v32434 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v32438 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v32416 = v32438 
                #endif
#else
                let v32441 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v32416 = v32441 
                #endif
                let v32442 : System.Threading.Tasks.Task = _run_target_args'_v32416 
                (* run_target_args'
                let v32452 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v32454 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v32452 = v32454 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v32458 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v32452 = v32458 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v32462 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v32452 = v32462 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v32465 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v32466 : Async<unit> = v32465 v32442
                let _run_target_args'_v32452 = v32466 
                #endif
#if FABLE_COMPILER_PYTHON
                let v32467 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v32468 : Async<unit> = v32467 v32442
                let _run_target_args'_v32452 = v32468 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v32469 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v32470 : Async<unit> = v32469 v32442
                let _run_target_args'_v32452 = v32470 
                #endif
#else
                let v32471 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v32472 : Async<unit> = v32471 v32442
                let _run_target_args'_v32452 = v32472 
                #endif
                let v32473 : Async<unit> = _run_target_args'_v32452 
                do! v32473 
                (* run_target_args'
                let v32483 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v32485 : int32 = null |> unbox<int32>
                let _run_target_args'_v32483 = v32485 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v32489 : int32 = null |> unbox<int32>
                let _run_target_args'_v32483 = v32489 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v32493 : int32 = null |> unbox<int32>
                let _run_target_args'_v32483 = v32493 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v32497 : int32 = null |> unbox<int32>
                let _run_target_args'_v32483 = v32497 
                #endif
#if FABLE_COMPILER_PYTHON
                let v32501 : int32 = null |> unbox<int32>
                let _run_target_args'_v32483 = v32501 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v32505 : int32 = null |> unbox<int32>
                let _run_target_args'_v32483 = v32505 
                #endif
#else
                let v32508 : int32 = v0.ExitCode
                let _run_target_args'_v32483 = v32508 
                #endif
                let v32509 : int32 = _run_target_args'_v32483 
                return v32509 
                (* indent
                ()
            indent *)
            with ex ->
                let v32784 : exn = ex
                (* run_target_args'
                let v32789 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v32791 : string = $"%A{v32784}"
                let _run_target_args'_v32789 = v32791 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v32795 : string = $"%A{v32784}"
                let _run_target_args'_v32789 = v32795 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v32799 : string = $"%A{v32784}"
                let _run_target_args'_v32789 = v32799 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v32803 : string = $"%A{v32784}"
                let _run_target_args'_v32789 = v32803 
                #endif
#if FABLE_COMPILER_PYTHON
                let v32807 : string = $"%A{v32784}"
                let _run_target_args'_v32789 = v32807 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v32811 : string = $"%A{v32784}"
                let _run_target_args'_v32789 = v32811 
                #endif
#else
                let v32814 : string = $"{v32784.GetType ()}: {v32784.Message}"
                let _run_target_args'_v32789 = v32814 
                #endif
                let v32815 : string = _run_target_args'_v32789 
                (* run_target_args'
                let v32821 : unit = ()
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
                let v32822 : (string -> unit) = v1.Push
                v32822 v32815
                #endif
                // run_target_args' is_unit
                let v32824 : System.Threading.Tasks.TaskCanceledException = v32784 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v32887 : unit = ()
                let v32888 : (unit -> unit) = closure23(v32824)
                let v32889 : unit = (fun () -> v32888 (); v32887) ()
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
    let v43607 : Async<int32> = _let'_v21815 
    let _run_target_args'_v7 = v43607 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v43609 : unit = ()
    let _let'_v43609 =
        async {
            try
                (* run_target_args'
                let v54210 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v54212 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v54210 = v54212 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v54216 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v54210 = v54216 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v54220 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v54210 = v54220 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v54224 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v54210 = v54224 
                #endif
#if FABLE_COMPILER_PYTHON
                let v54228 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v54210 = v54228 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v54232 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v54210 = v54232 
                #endif
#else
                let v54235 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v54210 = v54235 
                #endif
                let v54236 : System.Threading.Tasks.Task = _run_target_args'_v54210 
                (* run_target_args'
                let v54246 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v54248 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v54246 = v54248 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v54252 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v54246 = v54252 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v54256 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v54246 = v54256 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v54259 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v54260 : Async<unit> = v54259 v54236
                let _run_target_args'_v54246 = v54260 
                #endif
#if FABLE_COMPILER_PYTHON
                let v54261 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v54262 : Async<unit> = v54261 v54236
                let _run_target_args'_v54246 = v54262 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v54263 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v54264 : Async<unit> = v54263 v54236
                let _run_target_args'_v54246 = v54264 
                #endif
#else
                let v54265 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v54266 : Async<unit> = v54265 v54236
                let _run_target_args'_v54246 = v54266 
                #endif
                let v54267 : Async<unit> = _run_target_args'_v54246 
                do! v54267 
                (* run_target_args'
                let v54277 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v54279 : int32 = null |> unbox<int32>
                let _run_target_args'_v54277 = v54279 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v54283 : int32 = null |> unbox<int32>
                let _run_target_args'_v54277 = v54283 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v54287 : int32 = null |> unbox<int32>
                let _run_target_args'_v54277 = v54287 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v54291 : int32 = null |> unbox<int32>
                let _run_target_args'_v54277 = v54291 
                #endif
#if FABLE_COMPILER_PYTHON
                let v54295 : int32 = null |> unbox<int32>
                let _run_target_args'_v54277 = v54295 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v54299 : int32 = null |> unbox<int32>
                let _run_target_args'_v54277 = v54299 
                #endif
#else
                let v54302 : int32 = v0.ExitCode
                let _run_target_args'_v54277 = v54302 
                #endif
                let v54303 : int32 = _run_target_args'_v54277 
                return v54303 
                (* indent
                ()
            indent *)
            with ex ->
                let v54578 : exn = ex
                (* run_target_args'
                let v54583 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v54585 : string = $"%A{v54578}"
                let _run_target_args'_v54583 = v54585 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v54589 : string = $"%A{v54578}"
                let _run_target_args'_v54583 = v54589 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v54593 : string = $"%A{v54578}"
                let _run_target_args'_v54583 = v54593 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v54597 : string = $"%A{v54578}"
                let _run_target_args'_v54583 = v54597 
                #endif
#if FABLE_COMPILER_PYTHON
                let v54601 : string = $"%A{v54578}"
                let _run_target_args'_v54583 = v54601 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v54605 : string = $"%A{v54578}"
                let _run_target_args'_v54583 = v54605 
                #endif
#else
                let v54608 : string = $"{v54578.GetType ()}: {v54578.Message}"
                let _run_target_args'_v54583 = v54608 
                #endif
                let v54609 : string = _run_target_args'_v54583 
                (* run_target_args'
                let v54615 : unit = ()
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
                let v54616 : (string -> unit) = v1.Push
                v54616 v54609
                #endif
                // run_target_args' is_unit
                let v54618 : System.Threading.Tasks.TaskCanceledException = v54578 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v54681 : unit = ()
                let v54682 : (unit -> unit) = closure23(v54618)
                let v54683 : unit = (fun () -> v54682 (); v54681) ()
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
    let v65401 : Async<int32> = _let'_v43609 
    let _run_target_args'_v7 = v65401 
    #endif
#else
    let v65403 : unit = ()
    let _let'_v65403 =
        async {
            try
                (* run_target_args'
                let v76004 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v76006 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v76004 = v76006 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v76010 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v76004 = v76010 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v76014 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v76004 = v76014 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v76018 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v76004 = v76018 
                #endif
#if FABLE_COMPILER_PYTHON
                let v76022 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v76004 = v76022 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v76026 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v76004 = v76026 
                #endif
#else
                let v76029 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v76004 = v76029 
                #endif
                let v76030 : System.Threading.Tasks.Task = _run_target_args'_v76004 
                (* run_target_args'
                let v76040 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v76042 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v76040 = v76042 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v76046 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v76040 = v76046 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v76050 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v76040 = v76050 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v76053 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v76054 : Async<unit> = v76053 v76030
                let _run_target_args'_v76040 = v76054 
                #endif
#if FABLE_COMPILER_PYTHON
                let v76055 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v76056 : Async<unit> = v76055 v76030
                let _run_target_args'_v76040 = v76056 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v76057 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v76058 : Async<unit> = v76057 v76030
                let _run_target_args'_v76040 = v76058 
                #endif
#else
                let v76059 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v76060 : Async<unit> = v76059 v76030
                let _run_target_args'_v76040 = v76060 
                #endif
                let v76061 : Async<unit> = _run_target_args'_v76040 
                do! v76061 
                (* run_target_args'
                let v76071 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v76073 : int32 = null |> unbox<int32>
                let _run_target_args'_v76071 = v76073 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v76077 : int32 = null |> unbox<int32>
                let _run_target_args'_v76071 = v76077 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v76081 : int32 = null |> unbox<int32>
                let _run_target_args'_v76071 = v76081 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v76085 : int32 = null |> unbox<int32>
                let _run_target_args'_v76071 = v76085 
                #endif
#if FABLE_COMPILER_PYTHON
                let v76089 : int32 = null |> unbox<int32>
                let _run_target_args'_v76071 = v76089 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v76093 : int32 = null |> unbox<int32>
                let _run_target_args'_v76071 = v76093 
                #endif
#else
                let v76096 : int32 = v0.ExitCode
                let _run_target_args'_v76071 = v76096 
                #endif
                let v76097 : int32 = _run_target_args'_v76071 
                return v76097 
                (* indent
                ()
            indent *)
            with ex ->
                let v76372 : exn = ex
                (* run_target_args'
                let v76377 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v76379 : string = $"%A{v76372}"
                let _run_target_args'_v76377 = v76379 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v76383 : string = $"%A{v76372}"
                let _run_target_args'_v76377 = v76383 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v76387 : string = $"%A{v76372}"
                let _run_target_args'_v76377 = v76387 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v76391 : string = $"%A{v76372}"
                let _run_target_args'_v76377 = v76391 
                #endif
#if FABLE_COMPILER_PYTHON
                let v76395 : string = $"%A{v76372}"
                let _run_target_args'_v76377 = v76395 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v76399 : string = $"%A{v76372}"
                let _run_target_args'_v76377 = v76399 
                #endif
#else
                let v76402 : string = $"{v76372.GetType ()}: {v76372.Message}"
                let _run_target_args'_v76377 = v76402 
                #endif
                let v76403 : string = _run_target_args'_v76377 
                (* run_target_args'
                let v76409 : unit = ()
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
                let v76410 : (string -> unit) = v1.Push
                v76410 v76403
                #endif
                // run_target_args' is_unit
                let v76412 : System.Threading.Tasks.TaskCanceledException = v76372 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v76475 : unit = ()
                let v76476 : (unit -> unit) = closure23(v76412)
                let v76477 : unit = (fun () -> v76476 (); v76475) ()
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
    let v87195 : Async<int32> = _let'_v65403 
    let _run_target_args'_v7 = v87195 
    #endif
    let v87196 : Async<int32> = _run_target_args'_v7 
    v87196
and method53 () : string =
    let v0 : string = "\n"
    v0
and method54 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : int32, v10 : string, v11 : System.Threading.CancellationToken option, v12 : (struct (string * string) []), v13 : (struct (int32 * string * bool) -> Async<unit>) option, v14 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v15 : bool, v16 : string option) : string =
    let v17 : string = method13()
    let v18 : Mut3 = {l0 = v17} : Mut3
    let v21 : string = "{ "
    let v22 : string = $"{v21}"
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure7(v18, v22)
    let v32 : unit = (fun () -> v31 (); v30) ()
    let v40 : string = "exit_code"
    let v41 : string = $"{v40}"
    let v49 : unit = ()
    let v50 : (unit -> unit) = closure7(v18, v41)
    let v51 : unit = (fun () -> v50 (); v49) ()
    let v59 : string = " = "
    let v60 : string = $"{v59}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure7(v18, v60)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v80 : string = $"{v8}"
    let v88 : unit = ()
    let v89 : (unit -> unit) = closure7(v18, v80)
    let v90 : unit = (fun () -> v89 (); v88) ()
    let v98 : string = "; "
    let v99 : string = $"{v98}"
    let v107 : unit = ()
    let v108 : (unit -> unit) = closure7(v18, v99)
    let v109 : unit = (fun () -> v108 (); v107) ()
    let v117 : string = "output_length"
    let v118 : string = $"{v117}"
    let v126 : unit = ()
    let v127 : (unit -> unit) = closure7(v18, v118)
    let v128 : unit = (fun () -> v127 (); v126) ()
    let v135 : string = $"{v59}"
    let v143 : unit = ()
    let v144 : (unit -> unit) = closure7(v18, v135)
    let v145 : unit = (fun () -> v144 (); v143) ()
    let v155 : string = $"{v9}"
    let v163 : unit = ()
    let v164 : (unit -> unit) = closure7(v18, v155)
    let v165 : unit = (fun () -> v164 (); v163) ()
    let v172 : string = $"{v98}"
    let v180 : unit = ()
    let v181 : (unit -> unit) = closure7(v18, v172)
    let v182 : unit = (fun () -> v181 (); v180) ()
    let v190 : string = "options"
    let v191 : string = $"{v190}"
    let v199 : unit = ()
    let v200 : (unit -> unit) = closure7(v18, v191)
    let v201 : unit = (fun () -> v200 (); v199) ()
    let v208 : string = $"{v59}"
    let v216 : unit = ()
    let v217 : (unit -> unit) = closure7(v18, v208)
    let v218 : unit = (fun () -> v217 (); v216) ()
    let v225 : string = $"{v21}"
    let v233 : unit = ()
    let v234 : (unit -> unit) = closure7(v18, v225)
    let v235 : unit = (fun () -> v234 (); v233) ()
    let v243 : string = "command"
    let v244 : string = $"{v243}"
    let v252 : unit = ()
    let v253 : (unit -> unit) = closure7(v18, v244)
    let v254 : unit = (fun () -> v253 (); v252) ()
    let v261 : string = $"{v59}"
    let v269 : unit = ()
    let v270 : (unit -> unit) = closure7(v18, v261)
    let v271 : unit = (fun () -> v270 (); v269) ()
    let v278 : string = $"{v10}"
    let v286 : unit = ()
    let v287 : (unit -> unit) = closure7(v18, v278)
    let v288 : unit = (fun () -> v287 (); v286) ()
    let v295 : string = $"{v98}"
    let v303 : unit = ()
    let v304 : (unit -> unit) = closure7(v18, v295)
    let v305 : unit = (fun () -> v304 (); v303) ()
    let v313 : string = "cancellation_token"
    let v314 : string = $"{v313}"
    let v322 : unit = ()
    let v323 : (unit -> unit) = closure7(v18, v314)
    let v324 : unit = (fun () -> v323 (); v322) ()
    let v331 : string = $"{v59}"
    let v339 : unit = ()
    let v340 : (unit -> unit) = closure7(v18, v331)
    let v341 : unit = (fun () -> v340 (); v339) ()
    (* run_target_args'
    let v351 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v352 : string = "format!(\"{:#?}\", $0)"
    let v353 : std_string_String = Fable.Core.RustInterop.emitRustExpr v11 v352 
    let v354 : string = "fable_library_rust::String_::fromString($0)"
    let v355 : string = Fable.Core.RustInterop.emitRustExpr v353 v354 
    let _run_target_args'_v351 = v355 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v356 : string = "format!(\"{:#?}\", $0)"
    let v357 : std_string_String = Fable.Core.RustInterop.emitRustExpr v11 v356 
    let v358 : string = "fable_library_rust::String_::fromString($0)"
    let v359 : string = Fable.Core.RustInterop.emitRustExpr v357 v358 
    let _run_target_args'_v351 = v359 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v360 : string = "format!(\"{:#?}\", $0)"
    let v361 : std_string_String = Fable.Core.RustInterop.emitRustExpr v11 v360 
    let v362 : string = "fable_library_rust::String_::fromString($0)"
    let v363 : string = Fable.Core.RustInterop.emitRustExpr v361 v362 
    let _run_target_args'_v351 = v363 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v365 : string = $"%A{v11}"
    let _run_target_args'_v351 = v365 
    #endif
#if FABLE_COMPILER_PYTHON
    let v369 : string = $"%A{v11}"
    let _run_target_args'_v351 = v369 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v373 : string = $"%A{v11}"
    let _run_target_args'_v351 = v373 
    #endif
#else
    let v377 : string = $"%A{v11}"
    let _run_target_args'_v351 = v377 
    #endif
    let v380 : string = _run_target_args'_v351 
    let v387 : string = $"{v380}"
    let v395 : unit = ()
    let v396 : (unit -> unit) = closure7(v18, v387)
    let v397 : unit = (fun () -> v396 (); v395) ()
    let v404 : string = $"{v98}"
    let v412 : unit = ()
    let v413 : (unit -> unit) = closure7(v18, v404)
    let v414 : unit = (fun () -> v413 (); v412) ()
    let v422 : string = "environment_variables"
    let v423 : string = $"{v422}"
    let v431 : unit = ()
    let v432 : (unit -> unit) = closure7(v18, v423)
    let v433 : unit = (fun () -> v432 (); v431) ()
    let v440 : string = $"{v59}"
    let v448 : unit = ()
    let v449 : (unit -> unit) = closure7(v18, v440)
    let v450 : unit = (fun () -> v449 (); v448) ()
    let v457 : string = $"%A{v12}"
    let v461 : string = $"{v457}"
    let v469 : unit = ()
    let v470 : (unit -> unit) = closure7(v18, v461)
    let v471 : unit = (fun () -> v470 (); v469) ()
    let v478 : string = $"{v98}"
    let v486 : unit = ()
    let v487 : (unit -> unit) = closure7(v18, v478)
    let v488 : unit = (fun () -> v487 (); v486) ()
    let v496 : string = "on_line"
    let v497 : string = $"{v496}"
    let v505 : unit = ()
    let v506 : (unit -> unit) = closure7(v18, v497)
    let v507 : unit = (fun () -> v506 (); v505) ()
    let v514 : string = $"{v59}"
    let v522 : unit = ()
    let v523 : (unit -> unit) = closure7(v18, v514)
    let v524 : unit = (fun () -> v523 (); v522) ()
    (* run_target_args'
    let v534 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v535 : string = "format!(\"{:#?}\", $0)"
    let v536 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v535 
    let v537 : string = "fable_library_rust::String_::fromString($0)"
    let v538 : string = Fable.Core.RustInterop.emitRustExpr v536 v537 
    let _run_target_args'_v534 = v538 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v539 : string = "format!(\"{:#?}\", $0)"
    let v540 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v539 
    let v541 : string = "fable_library_rust::String_::fromString($0)"
    let v542 : string = Fable.Core.RustInterop.emitRustExpr v540 v541 
    let _run_target_args'_v534 = v542 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v543 : string = "format!(\"{:#?}\", $0)"
    let v544 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v543 
    let v545 : string = "fable_library_rust::String_::fromString($0)"
    let v546 : string = Fable.Core.RustInterop.emitRustExpr v544 v545 
    let _run_target_args'_v534 = v546 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v548 : string = $"%A{v13}"
    let _run_target_args'_v534 = v548 
    #endif
#if FABLE_COMPILER_PYTHON
    let v552 : string = $"%A{v13}"
    let _run_target_args'_v534 = v552 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v556 : string = $"%A{v13}"
    let _run_target_args'_v534 = v556 
    #endif
#else
    let v560 : string = $"%A{v13}"
    let _run_target_args'_v534 = v560 
    #endif
    let v563 : string = _run_target_args'_v534 
    let v570 : string = $"{v563}"
    let v578 : unit = ()
    let v579 : (unit -> unit) = closure7(v18, v570)
    let v580 : unit = (fun () -> v579 (); v578) ()
    let v587 : string = $"{v98}"
    let v595 : unit = ()
    let v596 : (unit -> unit) = closure7(v18, v587)
    let v597 : unit = (fun () -> v596 (); v595) ()
    let v605 : string = "stdin"
    let v606 : string = $"{v605}"
    let v614 : unit = ()
    let v615 : (unit -> unit) = closure7(v18, v606)
    let v616 : unit = (fun () -> v615 (); v614) ()
    let v623 : string = $"{v59}"
    let v631 : unit = ()
    let v632 : (unit -> unit) = closure7(v18, v623)
    let v633 : unit = (fun () -> v632 (); v631) ()
    (* run_target_args'
    let v643 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v644 : string = "format!(\"{:#?}\", $0)"
    let v645 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v644 
    let v646 : string = "fable_library_rust::String_::fromString($0)"
    let v647 : string = Fable.Core.RustInterop.emitRustExpr v645 v646 
    let _run_target_args'_v643 = v647 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v648 : string = "format!(\"{:#?}\", $0)"
    let v649 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v648 
    let v650 : string = "fable_library_rust::String_::fromString($0)"
    let v651 : string = Fable.Core.RustInterop.emitRustExpr v649 v650 
    let _run_target_args'_v643 = v651 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v652 : string = "format!(\"{:#?}\", $0)"
    let v653 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v652 
    let v654 : string = "fable_library_rust::String_::fromString($0)"
    let v655 : string = Fable.Core.RustInterop.emitRustExpr v653 v654 
    let _run_target_args'_v643 = v655 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v657 : string = $"%A{v14}"
    let _run_target_args'_v643 = v657 
    #endif
#if FABLE_COMPILER_PYTHON
    let v661 : string = $"%A{v14}"
    let _run_target_args'_v643 = v661 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v665 : string = $"%A{v14}"
    let _run_target_args'_v643 = v665 
    #endif
#else
    let v669 : string = $"%A{v14}"
    let _run_target_args'_v643 = v669 
    #endif
    let v672 : string = _run_target_args'_v643 
    let v679 : string = $"{v672}"
    let v687 : unit = ()
    let v688 : (unit -> unit) = closure7(v18, v679)
    let v689 : unit = (fun () -> v688 (); v687) ()
    let v696 : string = $"{v98}"
    let v704 : unit = ()
    let v705 : (unit -> unit) = closure7(v18, v696)
    let v706 : unit = (fun () -> v705 (); v704) ()
    let v714 : string = "trace"
    let v715 : string = $"{v714}"
    let v723 : unit = ()
    let v724 : (unit -> unit) = closure7(v18, v715)
    let v725 : unit = (fun () -> v724 (); v723) ()
    let v732 : string = $"{v59}"
    let v740 : unit = ()
    let v741 : (unit -> unit) = closure7(v18, v732)
    let v742 : unit = (fun () -> v741 (); v740) ()
    let v750 : string =
        if v15 then
            let v748 : string = "true"
            v748
        else
            let v749 : string = "false"
            v749
    let v752 : string = $"{v750}"
    let v760 : unit = ()
    let v761 : (unit -> unit) = closure7(v18, v752)
    let v762 : unit = (fun () -> v761 (); v760) ()
    let v769 : string = $"{v98}"
    let v777 : unit = ()
    let v778 : (unit -> unit) = closure7(v18, v769)
    let v779 : unit = (fun () -> v778 (); v777) ()
    let v787 : string = "working_directory"
    let v788 : string = $"{v787}"
    let v796 : unit = ()
    let v797 : (unit -> unit) = closure7(v18, v788)
    let v798 : unit = (fun () -> v797 (); v796) ()
    let v805 : string = $"{v59}"
    let v813 : unit = ()
    let v814 : (unit -> unit) = closure7(v18, v805)
    let v815 : unit = (fun () -> v814 (); v813) ()
    (* run_target_args'
    let v825 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v826 : string = "format!(\"{:#?}\", $0)"
    let v827 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v826 
    let v828 : string = "fable_library_rust::String_::fromString($0)"
    let v829 : string = Fable.Core.RustInterop.emitRustExpr v827 v828 
    let _run_target_args'_v825 = v829 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v830 : string = "format!(\"{:#?}\", $0)"
    let v831 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v830 
    let v832 : string = "fable_library_rust::String_::fromString($0)"
    let v833 : string = Fable.Core.RustInterop.emitRustExpr v831 v832 
    let _run_target_args'_v825 = v833 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v834 : string = "format!(\"{:#?}\", $0)"
    let v835 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v834 
    let v836 : string = "fable_library_rust::String_::fromString($0)"
    let v837 : string = Fable.Core.RustInterop.emitRustExpr v835 v836 
    let _run_target_args'_v825 = v837 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v839 : string = $"%A{v16}"
    let _run_target_args'_v825 = v839 
    #endif
#if FABLE_COMPILER_PYTHON
    let v843 : string = $"%A{v16}"
    let _run_target_args'_v825 = v843 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v847 : string = $"%A{v16}"
    let _run_target_args'_v825 = v847 
    #endif
#else
    let v851 : string = $"%A{v16}"
    let _run_target_args'_v825 = v851 
    #endif
    let v854 : string = _run_target_args'_v825 
    let v861 : string = $"{v854}"
    let v869 : unit = ()
    let v870 : (unit -> unit) = closure7(v18, v861)
    let v871 : unit = (fun () -> v870 (); v869) ()
    let v879 : string = " }"
    let v880 : string = $"{v879}"
    let v888 : unit = ()
    let v889 : (unit -> unit) = closure7(v18, v880)
    let v890 : unit = (fun () -> v889 (); v888) ()
    let v897 : string = $"{v879}"
    let v905 : unit = ()
    let v906 : (unit -> unit) = closure7(v18, v897)
    let v907 : unit = (fun () -> v906 (); v905) ()
    let v913 : string = v18.l0
    let v914 : int64 = v0.l0
    let v917 : string = " "
    let v918 : string = v6 + v917 
    let v922 : string = v918 + v7 
    let v927 : string = " #"
    let v928 : string = v922 + v927 
    let v932 : (int64 -> string) = _.ToString()
    let v933 : string = v932 v914
    let v937 : string = v928 + v933 
    let v941 : string = v937 + v917 
    let v946 : string = "runtime.execute_with_options_async"
    let v947 : string = v941 + v946 
    let v952 : string = " / "
    let v953 : string = v947 + v952 
    let v957 : string = v953 + v913 
    method16(v957)
and closure24 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : int32, v8 : string) () : unit =
    let v9 : US0 = US0_1
    let v10 : bool = method7(v9)
    if v10 then
        let v25 : unit = ()
        let v26 : (unit -> unit) = closure0()
        let v27 : unit = (fun () -> v26 (); v25) ()
        let struct (v48 : Mut0, v49 : Mut1, v50 : Mut2, v51 : Mut3, v52 : Mut4, v53 : int64 option) = TraceState.trace_state.Value
        let v66 : string = method8(v48, v49, v50, v51, v52, v53)
        let v67 : string = method36()
        let v68 : int32 = v8.Length
        let v69 : string = method54(v48, v49, v50, v51, v52, v53, v66, v67, v7, v68, v0, v1, v2, v3, v4, v5, v6)
        method17(v69)
and method22 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : Async<struct (int32 * string)> =
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
            let v5834 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v5837 : int32, v5838 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5837, v5838) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v5845 : int32, v5846 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5845, v5846) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v5853 : int32, v5854 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5853, v5854) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v5861 : int32, v5862 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5861, v5862) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v5869 : int32, v5870 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5869, v5870) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v5877 : int32, v5878 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5877, v5878) 
            #endif
#else
            let v5883 : US6 = method23(v0)
            let struct (v5895 : string, v5896 : US5) =
                match v5883 with
                | US6_1(v5886) -> (* Error *)
                    let v5888 : string = $"resultm.get / Result value was Error: {v5886}"
                    failwith<struct (string * US5)> v5888
                | US6_0(v5884, v5885) -> (* Ok *)
                    struct (v5884, v5885)
            let v5899 : (string -> US5) = method5()
            let v5900 : US5 option = v6 |> Option.map v5899 
            let v5920 : US5 = US5_1
            let v5921 : US5 = v5900 |> Option.defaultValue v5920 
            let v5928 : string =
                match v5921 with
                | US5_1 -> (* None *)
                    let v5926 : string = ""
                    v5926
                | US5_0(v5925) -> (* Some *)
                    v5925
            let v5989 : unit = ()
            let v5990 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v5896, v5895)
            let v5991 : unit = (fun () -> v5990 (); v5989) ()
            let v6052 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v6056 : string =
                match v5896 with
                | US5_1 -> (* None *)
                    let v6054 : string = ""
                    v6054
                | US5_0(v6053) -> (* Some *)
                    v6053
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v6056,
              StandardOutputEncoding = v6052,
              WorkingDirectory = v5928,
              FileName = v5895,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v6057 : System.Diagnostics.ProcessStartInfo = start_info
            let v6058 : (struct (string * string) []) = method38(v0, v1, v2, v3, v4, v5, v6)
            let v6059 : int32 = v6058.Length
            let v6060 : Mut5 = {l0 = 0} : Mut5
            while method39(v6059, v6060) do
                let v6062 : int32 = v6060.l0
                let struct (v6063 : string, v6064 : string) = v6058.[int v6062]
                v6057.EnvironmentVariables.[v6063] <- v6064 
                let v6065 : int32 = v6062 + 1
                v6060.l0 <- v6065
                ()
            let v6066 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v6057)
            use v6066 = v6066 
            let v6067 : System.Diagnostics.Process = v6066 
            let v6068 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v6069 : System.Collections.Concurrent.ConcurrentStack<string> = v6068 ()
            let v6070 : bool = false
            let v6071 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v6067, v6069, v6070)
            v6067.OutputDataReceived.Add v6071 
            let v6072 : bool = true
            let v6073 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v6067, v6069, v6072)
            v6067.ErrorDataReceived.Add v6073 
            let v6074 : (unit -> bool) = v6067.Start
            let v6075 : bool = v6074 ()
            let v6076 : bool = v6075 = false
            if v6076 then
                let v6077 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v6077
            let v6078 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v6078 v6067
            let v6079 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v6079 v6067
            let v6082 : (System.Threading.CancellationToken -> US15) = method47()
            let v6083 : US15 option = v1 |> Option.map v6082 
            let v6103 : US15 = US15_1
            let v6104 : US15 = v6083 |> Option.defaultValue v6103 
            let v6111 : System.Threading.CancellationToken =
                match v6104 with
                | US15_1 -> (* None *)
                    let v6109 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v6109
                | US15_0(v6108) -> (* Some *)
                    v6108
            let v6112 : Async<System.Threading.CancellationToken> = method48(v6111)
            let! v6112 = v6112 
            let v6113 : System.Threading.CancellationToken = v6112 
            let v6114 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v6113.Register
            let v6115 : (unit -> unit) = closure22(v6067)
            let v6116 : System.Threading.CancellationTokenRegistration = v6114 v6115
            use v6116 = v6116 
            let v6117 : System.Threading.CancellationTokenRegistration = v6116 
            let v6118 : Async<int32> = method51(v6067, v6069, v6113)
            let! v6118 = v6118 
            let v6119 : int32 = v6118 
            let v6121 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v6122 : string seq = v6121 v6069
            let v6126 : (string seq -> string seq) = Seq.rev
            let v6127 : string seq = v6126 v6122
            let v6132 : string = method53()
            let v6133 : (string -> (string seq -> string)) = String.concat
            let v6134 : (string seq -> string) = v6133 v6132
            let v6135 : string = v6134 v6127
            let v6200 : unit = ()
            let v6201 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v6119, v6135)
            let v6202 : unit = (fun () -> v6201 (); v6200) ()
            return struct (v6119, v6135) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v12070 : Async<struct (int32 * string)> = _let'_v25 
    let _run_target_args'_v11 = v12070 
    #endif
#if FABLE_COMPILER_PYTHON
    let v12072 : unit = ()
    let _let'_v12072 =
        async {
            (* run_target_args'
            let v17881 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v17884 : int32, v17885 : string) = null |> unbox<struct (int32 * string)>
            return struct (v17884, v17885) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v17892 : int32, v17893 : string) = null |> unbox<struct (int32 * string)>
            return struct (v17892, v17893) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v17900 : int32, v17901 : string) = null |> unbox<struct (int32 * string)>
            return struct (v17900, v17901) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v17908 : int32, v17909 : string) = null |> unbox<struct (int32 * string)>
            return struct (v17908, v17909) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v17916 : int32, v17917 : string) = null |> unbox<struct (int32 * string)>
            return struct (v17916, v17917) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v17924 : int32, v17925 : string) = null |> unbox<struct (int32 * string)>
            return struct (v17924, v17925) 
            #endif
#else
            let v17930 : US6 = method23(v0)
            let struct (v17942 : string, v17943 : US5) =
                match v17930 with
                | US6_1(v17933) -> (* Error *)
                    let v17935 : string = $"resultm.get / Result value was Error: {v17933}"
                    failwith<struct (string * US5)> v17935
                | US6_0(v17931, v17932) -> (* Ok *)
                    struct (v17931, v17932)
            let v17946 : (string -> US5) = method5()
            let v17947 : US5 option = v6 |> Option.map v17946 
            let v17967 : US5 = US5_1
            let v17968 : US5 = v17947 |> Option.defaultValue v17967 
            let v17975 : string =
                match v17968 with
                | US5_1 -> (* None *)
                    let v17973 : string = ""
                    v17973
                | US5_0(v17972) -> (* Some *)
                    v17972
            let v18036 : unit = ()
            let v18037 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v17943, v17942)
            let v18038 : unit = (fun () -> v18037 (); v18036) ()
            let v18099 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v18103 : string =
                match v17943 with
                | US5_1 -> (* None *)
                    let v18101 : string = ""
                    v18101
                | US5_0(v18100) -> (* Some *)
                    v18100
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v18103,
              StandardOutputEncoding = v18099,
              WorkingDirectory = v17975,
              FileName = v17942,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v18104 : System.Diagnostics.ProcessStartInfo = start_info
            let v18105 : (struct (string * string) []) = method38(v0, v1, v2, v3, v4, v5, v6)
            let v18106 : int32 = v18105.Length
            let v18107 : Mut5 = {l0 = 0} : Mut5
            while method39(v18106, v18107) do
                let v18109 : int32 = v18107.l0
                let struct (v18110 : string, v18111 : string) = v18105.[int v18109]
                v18104.EnvironmentVariables.[v18110] <- v18111 
                let v18112 : int32 = v18109 + 1
                v18107.l0 <- v18112
                ()
            let v18113 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v18104)
            use v18113 = v18113 
            let v18114 : System.Diagnostics.Process = v18113 
            let v18115 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v18116 : System.Collections.Concurrent.ConcurrentStack<string> = v18115 ()
            let v18117 : bool = false
            let v18118 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v18114, v18116, v18117)
            v18114.OutputDataReceived.Add v18118 
            let v18119 : bool = true
            let v18120 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v18114, v18116, v18119)
            v18114.ErrorDataReceived.Add v18120 
            let v18121 : (unit -> bool) = v18114.Start
            let v18122 : bool = v18121 ()
            let v18123 : bool = v18122 = false
            if v18123 then
                let v18124 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v18124
            let v18125 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v18125 v18114
            let v18126 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v18126 v18114
            let v18129 : (System.Threading.CancellationToken -> US15) = method47()
            let v18130 : US15 option = v1 |> Option.map v18129 
            let v18150 : US15 = US15_1
            let v18151 : US15 = v18130 |> Option.defaultValue v18150 
            let v18158 : System.Threading.CancellationToken =
                match v18151 with
                | US15_1 -> (* None *)
                    let v18156 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v18156
                | US15_0(v18155) -> (* Some *)
                    v18155
            let v18159 : Async<System.Threading.CancellationToken> = method48(v18158)
            let! v18159 = v18159 
            let v18160 : System.Threading.CancellationToken = v18159 
            let v18161 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v18160.Register
            let v18162 : (unit -> unit) = closure22(v18114)
            let v18163 : System.Threading.CancellationTokenRegistration = v18161 v18162
            use v18163 = v18163 
            let v18164 : System.Threading.CancellationTokenRegistration = v18163 
            let v18165 : Async<int32> = method51(v18114, v18116, v18160)
            let! v18165 = v18165 
            let v18166 : int32 = v18165 
            let v18168 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v18169 : string seq = v18168 v18116
            let v18173 : (string seq -> string seq) = Seq.rev
            let v18174 : string seq = v18173 v18169
            let v18179 : string = method53()
            let v18180 : (string -> (string seq -> string)) = String.concat
            let v18181 : (string seq -> string) = v18180 v18179
            let v18182 : string = v18181 v18174
            let v18247 : unit = ()
            let v18248 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v18166, v18182)
            let v18249 : unit = (fun () -> v18248 (); v18247) ()
            return struct (v18166, v18182) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v24117 : Async<struct (int32 * string)> = _let'_v12072 
    let _run_target_args'_v11 = v24117 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24119 : unit = ()
    let _let'_v24119 =
        async {
            (* run_target_args'
            let v29928 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v29931 : int32, v29932 : string) = null |> unbox<struct (int32 * string)>
            return struct (v29931, v29932) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v29939 : int32, v29940 : string) = null |> unbox<struct (int32 * string)>
            return struct (v29939, v29940) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v29947 : int32, v29948 : string) = null |> unbox<struct (int32 * string)>
            return struct (v29947, v29948) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v29955 : int32, v29956 : string) = null |> unbox<struct (int32 * string)>
            return struct (v29955, v29956) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v29963 : int32, v29964 : string) = null |> unbox<struct (int32 * string)>
            return struct (v29963, v29964) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v29971 : int32, v29972 : string) = null |> unbox<struct (int32 * string)>
            return struct (v29971, v29972) 
            #endif
#else
            let v29977 : US6 = method23(v0)
            let struct (v29989 : string, v29990 : US5) =
                match v29977 with
                | US6_1(v29980) -> (* Error *)
                    let v29982 : string = $"resultm.get / Result value was Error: {v29980}"
                    failwith<struct (string * US5)> v29982
                | US6_0(v29978, v29979) -> (* Ok *)
                    struct (v29978, v29979)
            let v29993 : (string -> US5) = method5()
            let v29994 : US5 option = v6 |> Option.map v29993 
            let v30014 : US5 = US5_1
            let v30015 : US5 = v29994 |> Option.defaultValue v30014 
            let v30022 : string =
                match v30015 with
                | US5_1 -> (* None *)
                    let v30020 : string = ""
                    v30020
                | US5_0(v30019) -> (* Some *)
                    v30019
            let v30083 : unit = ()
            let v30084 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v29990, v29989)
            let v30085 : unit = (fun () -> v30084 (); v30083) ()
            let v30146 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v30150 : string =
                match v29990 with
                | US5_1 -> (* None *)
                    let v30148 : string = ""
                    v30148
                | US5_0(v30147) -> (* Some *)
                    v30147
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v30150,
              StandardOutputEncoding = v30146,
              WorkingDirectory = v30022,
              FileName = v29989,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v30151 : System.Diagnostics.ProcessStartInfo = start_info
            let v30152 : (struct (string * string) []) = method38(v0, v1, v2, v3, v4, v5, v6)
            let v30153 : int32 = v30152.Length
            let v30154 : Mut5 = {l0 = 0} : Mut5
            while method39(v30153, v30154) do
                let v30156 : int32 = v30154.l0
                let struct (v30157 : string, v30158 : string) = v30152.[int v30156]
                v30151.EnvironmentVariables.[v30157] <- v30158 
                let v30159 : int32 = v30156 + 1
                v30154.l0 <- v30159
                ()
            let v30160 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v30151)
            use v30160 = v30160 
            let v30161 : System.Diagnostics.Process = v30160 
            let v30162 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v30163 : System.Collections.Concurrent.ConcurrentStack<string> = v30162 ()
            let v30164 : bool = false
            let v30165 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v30161, v30163, v30164)
            v30161.OutputDataReceived.Add v30165 
            let v30166 : bool = true
            let v30167 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v30161, v30163, v30166)
            v30161.ErrorDataReceived.Add v30167 
            let v30168 : (unit -> bool) = v30161.Start
            let v30169 : bool = v30168 ()
            let v30170 : bool = v30169 = false
            if v30170 then
                let v30171 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v30171
            let v30172 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v30172 v30161
            let v30173 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v30173 v30161
            let v30176 : (System.Threading.CancellationToken -> US15) = method47()
            let v30177 : US15 option = v1 |> Option.map v30176 
            let v30197 : US15 = US15_1
            let v30198 : US15 = v30177 |> Option.defaultValue v30197 
            let v30205 : System.Threading.CancellationToken =
                match v30198 with
                | US15_1 -> (* None *)
                    let v30203 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v30203
                | US15_0(v30202) -> (* Some *)
                    v30202
            let v30206 : Async<System.Threading.CancellationToken> = method48(v30205)
            let! v30206 = v30206 
            let v30207 : System.Threading.CancellationToken = v30206 
            let v30208 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v30207.Register
            let v30209 : (unit -> unit) = closure22(v30161)
            let v30210 : System.Threading.CancellationTokenRegistration = v30208 v30209
            use v30210 = v30210 
            let v30211 : System.Threading.CancellationTokenRegistration = v30210 
            let v30212 : Async<int32> = method51(v30161, v30163, v30207)
            let! v30212 = v30212 
            let v30213 : int32 = v30212 
            let v30215 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v30216 : string seq = v30215 v30163
            let v30220 : (string seq -> string seq) = Seq.rev
            let v30221 : string seq = v30220 v30216
            let v30226 : string = method53()
            let v30227 : (string -> (string seq -> string)) = String.concat
            let v30228 : (string seq -> string) = v30227 v30226
            let v30229 : string = v30228 v30221
            let v30294 : unit = ()
            let v30295 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v30213, v30229)
            let v30296 : unit = (fun () -> v30295 (); v30294) ()
            return struct (v30213, v30229) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v36164 : Async<struct (int32 * string)> = _let'_v24119 
    let _run_target_args'_v11 = v36164 
    #endif
#else
    let v36166 : unit = ()
    let _let'_v36166 =
        async {
            (* run_target_args'
            let v41975 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v41978 : int32, v41979 : string) = null |> unbox<struct (int32 * string)>
            return struct (v41978, v41979) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v41986 : int32, v41987 : string) = null |> unbox<struct (int32 * string)>
            return struct (v41986, v41987) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v41994 : int32, v41995 : string) = null |> unbox<struct (int32 * string)>
            return struct (v41994, v41995) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v42002 : int32, v42003 : string) = null |> unbox<struct (int32 * string)>
            return struct (v42002, v42003) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v42010 : int32, v42011 : string) = null |> unbox<struct (int32 * string)>
            return struct (v42010, v42011) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v42018 : int32, v42019 : string) = null |> unbox<struct (int32 * string)>
            return struct (v42018, v42019) 
            #endif
#else
            let v42024 : US6 = method23(v0)
            let struct (v42036 : string, v42037 : US5) =
                match v42024 with
                | US6_1(v42027) -> (* Error *)
                    let v42029 : string = $"resultm.get / Result value was Error: {v42027}"
                    failwith<struct (string * US5)> v42029
                | US6_0(v42025, v42026) -> (* Ok *)
                    struct (v42025, v42026)
            let v42040 : (string -> US5) = method5()
            let v42041 : US5 option = v6 |> Option.map v42040 
            let v42061 : US5 = US5_1
            let v42062 : US5 = v42041 |> Option.defaultValue v42061 
            let v42069 : string =
                match v42062 with
                | US5_1 -> (* None *)
                    let v42067 : string = ""
                    v42067
                | US5_0(v42066) -> (* Some *)
                    v42066
            let v42130 : unit = ()
            let v42131 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v42037, v42036)
            let v42132 : unit = (fun () -> v42131 (); v42130) ()
            let v42193 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v42197 : string =
                match v42037 with
                | US5_1 -> (* None *)
                    let v42195 : string = ""
                    v42195
                | US5_0(v42194) -> (* Some *)
                    v42194
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v42197,
              StandardOutputEncoding = v42193,
              WorkingDirectory = v42069,
              FileName = v42036,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v42198 : System.Diagnostics.ProcessStartInfo = start_info
            let v42199 : (struct (string * string) []) = method38(v0, v1, v2, v3, v4, v5, v6)
            let v42200 : int32 = v42199.Length
            let v42201 : Mut5 = {l0 = 0} : Mut5
            while method39(v42200, v42201) do
                let v42203 : int32 = v42201.l0
                let struct (v42204 : string, v42205 : string) = v42199.[int v42203]
                v42198.EnvironmentVariables.[v42204] <- v42205 
                let v42206 : int32 = v42203 + 1
                v42201.l0 <- v42206
                ()
            let v42207 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v42198)
            use v42207 = v42207 
            let v42208 : System.Diagnostics.Process = v42207 
            let v42209 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v42210 : System.Collections.Concurrent.ConcurrentStack<string> = v42209 ()
            let v42211 : bool = false
            let v42212 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v42208, v42210, v42211)
            v42208.OutputDataReceived.Add v42212 
            let v42213 : bool = true
            let v42214 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v42208, v42210, v42213)
            v42208.ErrorDataReceived.Add v42214 
            let v42215 : (unit -> bool) = v42208.Start
            let v42216 : bool = v42215 ()
            let v42217 : bool = v42216 = false
            if v42217 then
                let v42218 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v42218
            let v42219 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v42219 v42208
            let v42220 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v42220 v42208
            let v42223 : (System.Threading.CancellationToken -> US15) = method47()
            let v42224 : US15 option = v1 |> Option.map v42223 
            let v42244 : US15 = US15_1
            let v42245 : US15 = v42224 |> Option.defaultValue v42244 
            let v42252 : System.Threading.CancellationToken =
                match v42245 with
                | US15_1 -> (* None *)
                    let v42250 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v42250
                | US15_0(v42249) -> (* Some *)
                    v42249
            let v42253 : Async<System.Threading.CancellationToken> = method48(v42252)
            let! v42253 = v42253 
            let v42254 : System.Threading.CancellationToken = v42253 
            let v42255 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v42254.Register
            let v42256 : (unit -> unit) = closure22(v42208)
            let v42257 : System.Threading.CancellationTokenRegistration = v42255 v42256
            use v42257 = v42257 
            let v42258 : System.Threading.CancellationTokenRegistration = v42257 
            let v42259 : Async<int32> = method51(v42208, v42210, v42254)
            let! v42259 = v42259 
            let v42260 : int32 = v42259 
            let v42262 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v42263 : string seq = v42262 v42210
            let v42267 : (string seq -> string seq) = Seq.rev
            let v42268 : string seq = v42267 v42263
            let v42273 : string = method53()
            let v42274 : (string -> (string seq -> string)) = String.concat
            let v42275 : (string seq -> string) = v42274 v42273
            let v42276 : string = v42275 v42268
            let v42341 : unit = ()
            let v42342 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v42260, v42276)
            let v42343 : unit = (fun () -> v42342 (); v42341) ()
            return struct (v42260, v42276) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v48211 : Async<struct (int32 * string)> = _let'_v36166 
    let _run_target_args'_v11 = v48211 
    #endif
    let v48212 : Async<struct (int32 * string)> = _run_target_args'_v11 
    v48212
and method21 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : Async<struct (int32 * string)> =
    method22(v0, v1, v2, v3, v4, v5, v6)
and method20 (v0 : string) : Async<struct (int32 * string)> =
    let v2 : System.Threading.CancellationToken option = None
    let v5 : (struct (string * string) []) = [||]
    let v7 : (struct (int32 * string * bool) -> Async<unit>) option = None
    let v11 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option = None
    let v15 : string option = None
    let v18 : bool = true
    method21(v0, v2, v5, v7, v11, v18, v15)
and closure13 () (v0 : string) : Async<struct (int32 * string)> =
    method20(v0)
and closure25 () struct (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : Async<struct (int32 * string)> =
    method21(v0, v1, v2, v3, v4, v5, v6)
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
and method57 (v0 : char, v1 : int64) : bool =
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
            method57(v0, v25)
and method58 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
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
            let v35 : bool = method57(v33, v34)
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
                let v81 : UH0 = method25(v79, v76, v80)
                let struct (v82 : System.Text.StringBuilder, v83 : int32, v84 : int32) = method26(v81, v2, v3, v4)
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
        method58(v125, v116, v117, v118, v119)
and method60 (v0 : char, v1 : int64) : bool =
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
            method60(v0, v21)
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
                let v56 : UH0 = method25(v54, v51, v55)
                let struct (v57 : System.Text.StringBuilder, v58 : int32, v59 : int32) = method26(v56, v1, v2, v3)
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
                let v114 : (string -> string) = method27(v112, v113)
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
                let v187 : UH0 = method25(v185, v182, v186)
                let struct (v188 : System.Text.StringBuilder, v189 : int32, v190 : int32) = method26(v187, v128, v129, v130)
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
                let v56 : UH0 = method25(v54, v51, v55)
                let struct (v57 : System.Text.StringBuilder, v58 : int32, v59 : int32) = method26(v56, v1, v2, v3)
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
                let v114 : (string -> string) = method27(v112, v113)
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
                let v187 : UH0 = method25(v185, v182, v186)
                let struct (v188 : System.Text.StringBuilder, v189 : int32, v190 : int32) = method26(v187, v128, v129, v130)
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
and method61 (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32, v4 : UH3) : US8 =
    match v4 with
    | UH3_1(v7, v8) -> (* Cons *)
        let v9 : US8 = v7 struct (v0, v1, v2, v3)
        match v9 with
        | US8_1(v15) -> (* Error *)
            method61(v0, v1, v2, v3, v8)
        | US8_0(v10, v11, v12, v13, v14) -> (* Ok *)
            v9
    | UH3_0 -> (* Nil *)
        let v5 : string = "parsing.choice / no parsers succeeded"
        US8_1(v5)
and method62 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_1(v2, v3) -> (* Cons *)
        let v4 : UH2 = UH2_1(v2, v1)
        method62(v3, v4)
    | UH2_0 -> (* Nil *)
        v1
and method59 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US17 =
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
            let v31 : bool = method60(v29, v30)
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
                let v77 : UH0 = method25(v75, v72, v76)
                let struct (v78 : System.Text.StringBuilder, v79 : int32, v80 : int32) = method26(v77, v2, v3, v4)
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
            method61(v1, v2, v3, v4, v132)
        | US8_0(v122, v123, v124, v125, v126) -> (* Ok *)
            v121
    match v135 with
    | US8_1(v143) -> (* Error *)
        let v144 : UH2 = UH2_0
        let v145 : UH2 = method62(v0, v144)
        US17_0(v145, v1, v2, v3, v4)
    | US8_0(v136, v137, v138, v139, v140) -> (* Ok *)
        let v141 : UH2 = UH2_1(v136, v0)
        method59(v141, v137, v138, v139, v140)
and method63 (v0 : UH2, v1 : string list) : string list =
    match v0 with
    | UH2_1(v2, v3) -> (* Cons *)
        let v4 : string list = method63(v3, v1)
        let v6 : string list = v2 :: v4 
        v6
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
            let v31 : bool = method60(v29, v30)
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
                let v77 : UH0 = method25(v75, v72, v76)
                let struct (v78 : System.Text.StringBuilder, v79 : int32, v80 : int32) = method26(v77, v2, v3, v4)
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
        let v131 : UH2 = method62(v0, v130)
        US17_0(v131, v1, v2, v3, v4)
    | US8_0(v122, v123, v124, v125, v126) -> (* Ok *)
        let v127 : UH2 = UH2_1(v122, v0)
        method64(v127, v123, v124, v125, v126)
and method56 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US17 =
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
            let v35 : bool = method57(v33, v34)
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
                let v81 : UH0 = method25(v79, v76, v80)
                let struct (v82 : System.Text.StringBuilder, v83 : int32, v84 : int32) = method26(v81, v2, v3, v4)
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
            let struct (v125 : string, v126 : string, v127 : System.Text.StringBuilder, v128 : int32, v129 : int32) = method58(v122, v116, v117, v118, v119)
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
                        let v192 : UH0 = method25(v190, v187, v191)
                        let struct (v193 : System.Text.StringBuilder, v194 : int32, v195 : int32) = method26(v192, v2, v3, v4)
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
                        let v250 : (string -> string) = method27(v248, v249)
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
                    let v268 : US17 = method59(v267, v263, v264, v265, v266)
                    let v301 : US8 =
                        match v268 with
                        | US17_1(v298) -> (* Error *)
                            US8_1(v298)
                        | US17_0(v269, v270, v271, v272, v273) -> (* Ok *)
                            let v274 : string list = []
                            let v275 : string list = method63(v269, v274)
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
                                    let v359 : UH0 = method25(v357, v354, v358)
                                    let struct (v360 : System.Text.StringBuilder, v361 : int32, v362 : int32) = method26(v359, v304, v305, v306)
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
                                    let v417 : (string -> string) = method27(v415, v416)
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
                let v463 : US8 = method61(v1, v2, v3, v4, v462)
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
                        method64(v480, v476, v477, v478, v479)
                match v485 with
                | US17_1(v515) -> (* Error *)
                    US8_1(v515)
                | US17_0(v486, v487, v488, v489, v490) -> (* Ok *)
                    let v491 : string list = []
                    let v492 : string list = method63(v486, v491)
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
        let v587 : UH2 = method62(v0, v586)
        US17_0(v587, v1, v2, v3, v4)
    | US8_0(v523, v524, v525, v526, v527) -> (* Ok *)
        let v528 : int32 = 0
        let v529 : int32 = method34(v524, v528)
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
            let v581 : UH2 = method62(v0, v580)
            US17_0(v581, v524, v525, v526, v527)
        | US10_0(v572, v573, v574, v575) -> (* Ok *)
            let v576 : UH2 = UH2_1(v523, v0)
            method56(v576, v572, v573, v574, v575)
and method55 (v0 : string) : US16 =
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
    let v13 : string = method24()
    let v15 : (string -> System.Text.StringBuilder) = System.Text.StringBuilder 
    let v16 : System.Text.StringBuilder = v15 v13
    let v19 : UH2 = UH2_0
    let v20 : int32 = 1
    let v21 : int32 = 1
    let v22 : US17 = method56(v19, v10, v16, v20, v21)
    match v22 with
    | US17_1(v36) -> (* Error *)
        US16_1(v36)
    | US17_0(v23, v24, v25, v26, v27) -> (* Ok *)
        let v28 : string list = []
        let v29 : string list = method63(v23, v28)
        let v31 : (string list -> (string [])) = List.toArray
        let v32 : (string []) = v31 v29
        US16_0(v32)
and closure27 () (v0 : string) : Result<(string []), string> =
    let v1 : US16 = method55(v0)
    match v1 with
    | US16_1(v7) -> (* Error *)
        let v9 : Result<(string []), string> = Error v7 
        v9
    | US16_0(v2) -> (* Ok *)
        let v4 : Result<(string []), string> = Ok v2 
        v4
let v14 : unit = ()
let v15 : (unit -> unit) = closure0()
let v16 : unit = (fun () -> v15 (); v14) ()
let v31 : (unit -> unit) = closure3()
let current_process_kill () = v31 ()
let v32 : (string -> Async<struct (int32 * string)>) = closure13()
let execute_async x = v32 x
let v33 : (struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option) -> Async<struct (int32 * string)>) = closure25()
let execute_with_options_async x = v33 x
let v34 : ((Heap0 -> Heap0) -> struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option)) = closure26()
let execution_options x = v34 x
let v35 : (string -> Result<(string []), string>) = closure27()
let split_args x = v35 x
()
