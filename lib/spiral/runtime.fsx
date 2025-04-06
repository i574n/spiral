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
[<CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module System =
 module Diagnostics =
  type Process = bool
  type DataReceivedEventArgs = bool
#endif
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
    let v86 : string = "inline_colorization::color_reset"
    let v87 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v87) v88 
    let v90 : string = "fable_library_rust::String_::fromString($0)"
    let v91 : string = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let _run_target_args'_v47 = v91 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v92 : string = "inline_colorization::color_yellow"
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
    let v136 : string = "inline_colorization::color_yellow"
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
    let v181 : string = "\u001b[93m"
    let v185 : string = method14()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[93m"
    let v201 : string = method14()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[93m"
    let v217 : string = method14()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[93m"
    let v233 : string = method14()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method16 (v0 : string) : string =
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
    let v86 : string = "inline_colorization::color_reset"
    let v87 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v89 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v87) v88 
    let v90 : string = "fable_library_rust::String_::fromString($0)"
    let v91 : string = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let _run_target_args'_v47 = v91 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v92 : string = "inline_colorization::color_bright_blue"
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
    let v136 : string = "inline_colorization::color_bright_blue"
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
    let v181 : string = "\u001b[94m"
    let v185 : string = method14()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[94m"
    let v201 : string = method14()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[94m"
    let v217 : string = method14()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[94m"
    let v233 : string = method14()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
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
    let v388 : string = $"{v378}"
    let v396 : unit = ()
    let v397 : (unit -> unit) = closure7(v18, v388)
    let v398 : unit = (fun () -> v397 (); v396) ()
    let v405 : string = $"{v95}"
    let v413 : unit = ()
    let v414 : (unit -> unit) = closure7(v18, v405)
    let v415 : unit = (fun () -> v414 (); v413) ()
    let v423 : string = "environment_variables"
    let v424 : string = $"{v423}"
    let v432 : unit = ()
    let v433 : (unit -> unit) = closure7(v18, v424)
    let v434 : unit = (fun () -> v433 (); v432) ()
    let v441 : string = $"{v59}"
    let v449 : unit = ()
    let v450 : (unit -> unit) = closure7(v18, v441)
    let v451 : unit = (fun () -> v450 (); v449) ()
    let v458 : string = $"%A{v12}"
    let v462 : string = $"{v458}"
    let v470 : unit = ()
    let v471 : (unit -> unit) = closure7(v18, v462)
    let v472 : unit = (fun () -> v471 (); v470) ()
    let v479 : string = $"{v95}"
    let v487 : unit = ()
    let v488 : (unit -> unit) = closure7(v18, v479)
    let v489 : unit = (fun () -> v488 (); v487) ()
    let v497 : string = "on_line"
    let v498 : string = $"{v497}"
    let v506 : unit = ()
    let v507 : (unit -> unit) = closure7(v18, v498)
    let v508 : unit = (fun () -> v507 (); v506) ()
    let v515 : string = $"{v59}"
    let v523 : unit = ()
    let v524 : (unit -> unit) = closure7(v18, v515)
    let v525 : unit = (fun () -> v524 (); v523) ()
    (* run_target_args'
    let v535 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v536 : string = "format!(\"{:#?}\", $0)"
    let v537 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v536 
    let v538 : string = "fable_library_rust::String_::fromString($0)"
    let v539 : string = Fable.Core.RustInterop.emitRustExpr v537 v538 
    let _run_target_args'_v535 = v539 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v540 : string = "format!(\"{:#?}\", $0)"
    let v541 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v540 
    let v542 : string = "fable_library_rust::String_::fromString($0)"
    let v543 : string = Fable.Core.RustInterop.emitRustExpr v541 v542 
    let _run_target_args'_v535 = v543 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v544 : string = "format!(\"{:#?}\", $0)"
    let v545 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v544 
    let v546 : string = "fable_library_rust::String_::fromString($0)"
    let v547 : string = Fable.Core.RustInterop.emitRustExpr v545 v546 
    let _run_target_args'_v535 = v547 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v549 : string = $"%A{v13}"
    let _run_target_args'_v535 = v549 
    #endif
#if FABLE_COMPILER_PYTHON
    let v553 : string = $"%A{v13}"
    let _run_target_args'_v535 = v553 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v557 : string = $"%A{v13}"
    let _run_target_args'_v535 = v557 
    #endif
#else
    let v561 : string = $"%A{v13}"
    let _run_target_args'_v535 = v561 
    #endif
    let v564 : string = _run_target_args'_v535 
    let v574 : string = $"{v564}"
    let v582 : unit = ()
    let v583 : (unit -> unit) = closure7(v18, v574)
    let v584 : unit = (fun () -> v583 (); v582) ()
    let v591 : string = $"{v95}"
    let v599 : unit = ()
    let v600 : (unit -> unit) = closure7(v18, v591)
    let v601 : unit = (fun () -> v600 (); v599) ()
    let v609 : string = "stdin"
    let v610 : string = $"{v609}"
    let v618 : unit = ()
    let v619 : (unit -> unit) = closure7(v18, v610)
    let v620 : unit = (fun () -> v619 (); v618) ()
    let v627 : string = $"{v59}"
    let v635 : unit = ()
    let v636 : (unit -> unit) = closure7(v18, v627)
    let v637 : unit = (fun () -> v636 (); v635) ()
    (* run_target_args'
    let v647 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v648 : string = "format!(\"{:#?}\", $0)"
    let v649 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v648 
    let v650 : string = "fable_library_rust::String_::fromString($0)"
    let v651 : string = Fable.Core.RustInterop.emitRustExpr v649 v650 
    let _run_target_args'_v647 = v651 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v652 : string = "format!(\"{:#?}\", $0)"
    let v653 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v652 
    let v654 : string = "fable_library_rust::String_::fromString($0)"
    let v655 : string = Fable.Core.RustInterop.emitRustExpr v653 v654 
    let _run_target_args'_v647 = v655 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v656 : string = "format!(\"{:#?}\", $0)"
    let v657 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v656 
    let v658 : string = "fable_library_rust::String_::fromString($0)"
    let v659 : string = Fable.Core.RustInterop.emitRustExpr v657 v658 
    let _run_target_args'_v647 = v659 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v661 : string = $"%A{v14}"
    let _run_target_args'_v647 = v661 
    #endif
#if FABLE_COMPILER_PYTHON
    let v665 : string = $"%A{v14}"
    let _run_target_args'_v647 = v665 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v669 : string = $"%A{v14}"
    let _run_target_args'_v647 = v669 
    #endif
#else
    let v673 : string = $"%A{v14}"
    let _run_target_args'_v647 = v673 
    #endif
    let v676 : string = _run_target_args'_v647 
    let v686 : string = $"{v676}"
    let v694 : unit = ()
    let v695 : (unit -> unit) = closure7(v18, v686)
    let v696 : unit = (fun () -> v695 (); v694) ()
    let v703 : string = $"{v95}"
    let v711 : unit = ()
    let v712 : (unit -> unit) = closure7(v18, v703)
    let v713 : unit = (fun () -> v712 (); v711) ()
    let v721 : string = "trace"
    let v722 : string = $"{v721}"
    let v730 : unit = ()
    let v731 : (unit -> unit) = closure7(v18, v722)
    let v732 : unit = (fun () -> v731 (); v730) ()
    let v739 : string = $"{v59}"
    let v747 : unit = ()
    let v748 : (unit -> unit) = closure7(v18, v739)
    let v749 : unit = (fun () -> v748 (); v747) ()
    let v757 : string =
        if v15 then
            let v755 : string = "true"
            v755
        else
            let v756 : string = "false"
            v756
    let v759 : string = $"{v757}"
    let v767 : unit = ()
    let v768 : (unit -> unit) = closure7(v18, v759)
    let v769 : unit = (fun () -> v768 (); v767) ()
    let v776 : string = $"{v95}"
    let v784 : unit = ()
    let v785 : (unit -> unit) = closure7(v18, v776)
    let v786 : unit = (fun () -> v785 (); v784) ()
    let v794 : string = "working_directory"
    let v795 : string = $"{v794}"
    let v803 : unit = ()
    let v804 : (unit -> unit) = closure7(v18, v795)
    let v805 : unit = (fun () -> v804 (); v803) ()
    let v812 : string = $"{v59}"
    let v820 : unit = ()
    let v821 : (unit -> unit) = closure7(v18, v812)
    let v822 : unit = (fun () -> v821 (); v820) ()
    (* run_target_args'
    let v832 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v833 : string = "format!(\"{:#?}\", $0)"
    let v834 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v833 
    let v835 : string = "fable_library_rust::String_::fromString($0)"
    let v836 : string = Fable.Core.RustInterop.emitRustExpr v834 v835 
    let _run_target_args'_v832 = v836 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v837 : string = "format!(\"{:#?}\", $0)"
    let v838 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v837 
    let v839 : string = "fable_library_rust::String_::fromString($0)"
    let v840 : string = Fable.Core.RustInterop.emitRustExpr v838 v839 
    let _run_target_args'_v832 = v840 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v841 : string = "format!(\"{:#?}\", $0)"
    let v842 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v841 
    let v843 : string = "fable_library_rust::String_::fromString($0)"
    let v844 : string = Fable.Core.RustInterop.emitRustExpr v842 v843 
    let _run_target_args'_v832 = v844 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v846 : string = $"%A{v16}"
    let _run_target_args'_v832 = v846 
    #endif
#if FABLE_COMPILER_PYTHON
    let v850 : string = $"%A{v16}"
    let _run_target_args'_v832 = v850 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v854 : string = $"%A{v16}"
    let _run_target_args'_v832 = v854 
    #endif
#else
    let v858 : string = $"%A{v16}"
    let _run_target_args'_v832 = v858 
    #endif
    let v861 : string = _run_target_args'_v832 
    let v871 : string = $"{v861}"
    let v879 : unit = ()
    let v880 : (unit -> unit) = closure7(v18, v871)
    let v881 : unit = (fun () -> v880 (); v879) ()
    let v889 : string = " }"
    let v890 : string = $"{v889}"
    let v898 : unit = ()
    let v899 : (unit -> unit) = closure7(v18, v890)
    let v900 : unit = (fun () -> v899 (); v898) ()
    let v907 : string = $"{v889}"
    let v915 : unit = ()
    let v916 : (unit -> unit) = closure7(v18, v907)
    let v917 : unit = (fun () -> v916 (); v915) ()
    let v923 : string = v18.l0
    let v924 : int64 = v0.l0
    let v927 : string = " "
    let v928 : string = v6 + v927 
    let v932 : string = v928 + v7 
    let v937 : string = " #"
    let v938 : string = v932 + v937 
    let v942 : (int64 -> string) = _.ToString()
    let v943 : string = v942 v924
    let v947 : string = v938 + v943 
    let v951 : string = v947 + v927 
    let v956 : string = "runtime.execute_with_options_async"
    let v957 : string = v951 + v956 
    let v962 : string = " / "
    let v963 : string = v957 + v962 
    let v967 : string = v963 + v923 
    method16(v967)
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
    let v185 : string = method14()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[90m"
    let v201 : string = method14()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[90m"
    let v217 : string = method14()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[90m"
    let v233 : string = method14()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
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
            let v598 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v600 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v600 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v604 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v604 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v608 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v608 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v612 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v612 
            #endif
#if FABLE_COMPILER_PYTHON
            let v616 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v616 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v620 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v620 
            #endif
#else
            let v623 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v623 = v623 
            let v624 : System.Threading.CancellationToken = v623 
            let v625 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v626 : (System.Threading.CancellationToken []) = [|v624; v625; v0|]
            let v627 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v628 : System.Threading.CancellationTokenSource = v627 v626
            let v629 : System.Threading.CancellationToken = v628.Token
            return v629 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1210 : Async<System.Threading.CancellationToken> = _let'_v19 
    let _run_target_args'_v5 = v1210 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1212 : unit = ()
    let _let'_v1212 =
        async {
            (* run_target_args'
            let v1791 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1793 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1793 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1797 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1797 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1801 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1801 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1805 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1805 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1809 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1809 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1813 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1813 
            #endif
#else
            let v1816 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v1816 = v1816 
            let v1817 : System.Threading.CancellationToken = v1816 
            let v1818 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v1819 : (System.Threading.CancellationToken []) = [|v1817; v1818; v0|]
            let v1820 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v1821 : System.Threading.CancellationTokenSource = v1820 v1819
            let v1822 : System.Threading.CancellationToken = v1821.Token
            return v1822 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2403 : Async<System.Threading.CancellationToken> = _let'_v1212 
    let _run_target_args'_v5 = v2403 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2405 : unit = ()
    let _let'_v2405 =
        async {
            (* run_target_args'
            let v2984 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2986 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2986 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2990 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2990 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2994 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2994 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2998 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2998 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3002 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3002 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3006 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3006 
            #endif
#else
            let v3009 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v3009 = v3009 
            let v3010 : System.Threading.CancellationToken = v3009 
            let v3011 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v3012 : (System.Threading.CancellationToken []) = [|v3010; v3011; v0|]
            let v3013 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v3014 : System.Threading.CancellationTokenSource = v3013 v3012
            let v3015 : System.Threading.CancellationToken = v3014.Token
            return v3015 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3596 : Async<System.Threading.CancellationToken> = _let'_v2405 
    let _run_target_args'_v5 = v3596 
    #endif
#else
    let v3598 : unit = ()
    let _let'_v3598 =
        async {
            (* run_target_args'
            let v4177 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4179 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v4179 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4183 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v4183 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4187 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v4187 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4191 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v4191 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4195 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v4195 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4199 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v4199 
            #endif
#else
            let v4202 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v4202 = v4202 
            let v4203 : System.Threading.CancellationToken = v4202 
            let v4204 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v4205 : (System.Threading.CancellationToken []) = [|v4203; v4204; v0|]
            let v4206 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v4207 : System.Threading.CancellationTokenSource = v4206 v4205
            let v4208 : System.Threading.CancellationToken = v4207.Token
            return v4208 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4789 : Async<System.Threading.CancellationToken> = _let'_v3598 
    let _run_target_args'_v5 = v4789 
    #endif
    let v4790 : Async<System.Threading.CancellationToken> = _run_target_args'_v5 
    v4790
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
    let v111 : string = $"{v101}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure7(v10, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v129 : string = " }"
    let v130 : string = $"{v129}"
    let v138 : unit = ()
    let v139 : (unit -> unit) = closure7(v10, v130)
    let v140 : unit = (fun () -> v139 (); v138) ()
    let v146 : string = v10.l0
    let v147 : int64 = v0.l0
    let v150 : string = " "
    let v151 : string = v6 + v150 
    let v155 : string = v151 + v7 
    let v160 : string = " #"
    let v161 : string = v155 + v160 
    let v165 : (int64 -> string) = _.ToString()
    let v166 : string = v165 v147
    let v170 : string = v161 + v166 
    let v174 : string = v170 + v150 
    let v179 : string = "runtime.execute_with_options_async / WaitForExitAsync"
    let v180 : string = v174 + v179 
    let v185 : string = " / "
    let v186 : string = v180 + v185 
    let v190 : string = v186 + v146 
    method16(v190)
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
                let v11099 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v11101 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v11099 = v11101 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v11105 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v11099 = v11105 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v11109 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v11099 = v11109 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v11113 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v11099 = v11113 
                #endif
#if FABLE_COMPILER_PYTHON
                let v11117 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v11099 = v11117 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v11121 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v11099 = v11121 
                #endif
#else
                let v11124 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v11099 = v11124 
                #endif
                let v11125 : System.Threading.Tasks.Task = _run_target_args'_v11099 
                (* run_target_args'
                let v11138 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v11140 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v11138 = v11140 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v11144 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v11138 = v11144 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v11148 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v11138 = v11148 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v11151 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v11152 : Async<unit> = v11151 v11125
                let _run_target_args'_v11138 = v11152 
                #endif
#if FABLE_COMPILER_PYTHON
                let v11153 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v11154 : Async<unit> = v11153 v11125
                let _run_target_args'_v11138 = v11154 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v11155 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v11156 : Async<unit> = v11155 v11125
                let _run_target_args'_v11138 = v11156 
                #endif
#else
                let v11157 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v11158 : Async<unit> = v11157 v11125
                let _run_target_args'_v11138 = v11158 
                #endif
                let v11159 : Async<unit> = _run_target_args'_v11138 
                do! v11159 
                (* run_target_args'
                let v11172 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v11174 : int32 = null |> unbox<int32>
                let _run_target_args'_v11172 = v11174 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v11178 : int32 = null |> unbox<int32>
                let _run_target_args'_v11172 = v11178 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v11182 : int32 = null |> unbox<int32>
                let _run_target_args'_v11172 = v11182 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v11186 : int32 = null |> unbox<int32>
                let _run_target_args'_v11172 = v11186 
                #endif
#if FABLE_COMPILER_PYTHON
                let v11190 : int32 = null |> unbox<int32>
                let _run_target_args'_v11172 = v11190 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v11194 : int32 = null |> unbox<int32>
                let _run_target_args'_v11172 = v11194 
                #endif
#else
                let v11197 : int32 = v0.ExitCode
                let _run_target_args'_v11172 = v11197 
                #endif
                let v11198 : int32 = _run_target_args'_v11172 
                return v11198 
                (* indent
                ()
            indent *)
            with ex ->
                let v11488 : exn = ex
                (* run_target_args'
                let v11493 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v11495 : string = $"%A{v11488}"
                let _run_target_args'_v11493 = v11495 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v11499 : string = $"%A{v11488}"
                let _run_target_args'_v11493 = v11499 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v11503 : string = $"%A{v11488}"
                let _run_target_args'_v11493 = v11503 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v11507 : string = $"%A{v11488}"
                let _run_target_args'_v11493 = v11507 
                #endif
#if FABLE_COMPILER_PYTHON
                let v11511 : string = $"%A{v11488}"
                let _run_target_args'_v11493 = v11511 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v11515 : string = $"%A{v11488}"
                let _run_target_args'_v11493 = v11515 
                #endif
#else
                let v11518 : string = $"{v11488.GetType ()}: {v11488.Message}"
                let _run_target_args'_v11493 = v11518 
                #endif
                let v11519 : string = _run_target_args'_v11493 
                (* run_target_args'
                let v11528 : unit = ()
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
                let v11529 : (string -> unit) = v1.Push
                v11529 v11519
                #endif
                // run_target_args' is_unit
                let v11531 : System.Threading.Tasks.TaskCanceledException = v11488 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v11594 : unit = ()
                let v11595 : (unit -> unit) = closure23(v11531)
                let v11596 : unit = (fun () -> v11595 (); v11594) ()
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
    let v22785 : Async<int32> = _let'_v21 
    let _run_target_args'_v7 = v22785 
    #endif
#if FABLE_COMPILER_PYTHON
    let v22787 : unit = ()
    let _let'_v22787 =
        async {
            try
                (* run_target_args'
                let v33865 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v33867 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v33865 = v33867 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v33871 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v33865 = v33871 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v33875 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v33865 = v33875 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v33879 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v33865 = v33879 
                #endif
#if FABLE_COMPILER_PYTHON
                let v33883 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v33865 = v33883 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v33887 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v33865 = v33887 
                #endif
#else
                let v33890 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v33865 = v33890 
                #endif
                let v33891 : System.Threading.Tasks.Task = _run_target_args'_v33865 
                (* run_target_args'
                let v33904 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v33906 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v33904 = v33906 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v33910 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v33904 = v33910 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v33914 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v33904 = v33914 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v33917 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v33918 : Async<unit> = v33917 v33891
                let _run_target_args'_v33904 = v33918 
                #endif
#if FABLE_COMPILER_PYTHON
                let v33919 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v33920 : Async<unit> = v33919 v33891
                let _run_target_args'_v33904 = v33920 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v33921 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v33922 : Async<unit> = v33921 v33891
                let _run_target_args'_v33904 = v33922 
                #endif
#else
                let v33923 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v33924 : Async<unit> = v33923 v33891
                let _run_target_args'_v33904 = v33924 
                #endif
                let v33925 : Async<unit> = _run_target_args'_v33904 
                do! v33925 
                (* run_target_args'
                let v33938 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v33940 : int32 = null |> unbox<int32>
                let _run_target_args'_v33938 = v33940 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v33944 : int32 = null |> unbox<int32>
                let _run_target_args'_v33938 = v33944 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v33948 : int32 = null |> unbox<int32>
                let _run_target_args'_v33938 = v33948 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v33952 : int32 = null |> unbox<int32>
                let _run_target_args'_v33938 = v33952 
                #endif
#if FABLE_COMPILER_PYTHON
                let v33956 : int32 = null |> unbox<int32>
                let _run_target_args'_v33938 = v33956 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v33960 : int32 = null |> unbox<int32>
                let _run_target_args'_v33938 = v33960 
                #endif
#else
                let v33963 : int32 = v0.ExitCode
                let _run_target_args'_v33938 = v33963 
                #endif
                let v33964 : int32 = _run_target_args'_v33938 
                return v33964 
                (* indent
                ()
            indent *)
            with ex ->
                let v34254 : exn = ex
                (* run_target_args'
                let v34259 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v34261 : string = $"%A{v34254}"
                let _run_target_args'_v34259 = v34261 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v34265 : string = $"%A{v34254}"
                let _run_target_args'_v34259 = v34265 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v34269 : string = $"%A{v34254}"
                let _run_target_args'_v34259 = v34269 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v34273 : string = $"%A{v34254}"
                let _run_target_args'_v34259 = v34273 
                #endif
#if FABLE_COMPILER_PYTHON
                let v34277 : string = $"%A{v34254}"
                let _run_target_args'_v34259 = v34277 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v34281 : string = $"%A{v34254}"
                let _run_target_args'_v34259 = v34281 
                #endif
#else
                let v34284 : string = $"{v34254.GetType ()}: {v34254.Message}"
                let _run_target_args'_v34259 = v34284 
                #endif
                let v34285 : string = _run_target_args'_v34259 
                (* run_target_args'
                let v34294 : unit = ()
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
                let v34295 : (string -> unit) = v1.Push
                v34295 v34285
                #endif
                // run_target_args' is_unit
                let v34297 : System.Threading.Tasks.TaskCanceledException = v34254 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v34360 : unit = ()
                let v34361 : (unit -> unit) = closure23(v34297)
                let v34362 : unit = (fun () -> v34361 (); v34360) ()
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
    let v45551 : Async<int32> = _let'_v22787 
    let _run_target_args'_v7 = v45551 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v45553 : unit = ()
    let _let'_v45553 =
        async {
            try
                (* run_target_args'
                let v56631 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v56633 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v56631 = v56633 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v56637 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v56631 = v56637 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v56641 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v56631 = v56641 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v56645 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v56631 = v56645 
                #endif
#if FABLE_COMPILER_PYTHON
                let v56649 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v56631 = v56649 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v56653 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v56631 = v56653 
                #endif
#else
                let v56656 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v56631 = v56656 
                #endif
                let v56657 : System.Threading.Tasks.Task = _run_target_args'_v56631 
                (* run_target_args'
                let v56670 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v56672 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v56670 = v56672 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v56676 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v56670 = v56676 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v56680 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v56670 = v56680 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v56683 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v56684 : Async<unit> = v56683 v56657
                let _run_target_args'_v56670 = v56684 
                #endif
#if FABLE_COMPILER_PYTHON
                let v56685 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v56686 : Async<unit> = v56685 v56657
                let _run_target_args'_v56670 = v56686 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v56687 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v56688 : Async<unit> = v56687 v56657
                let _run_target_args'_v56670 = v56688 
                #endif
#else
                let v56689 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v56690 : Async<unit> = v56689 v56657
                let _run_target_args'_v56670 = v56690 
                #endif
                let v56691 : Async<unit> = _run_target_args'_v56670 
                do! v56691 
                (* run_target_args'
                let v56704 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v56706 : int32 = null |> unbox<int32>
                let _run_target_args'_v56704 = v56706 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v56710 : int32 = null |> unbox<int32>
                let _run_target_args'_v56704 = v56710 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v56714 : int32 = null |> unbox<int32>
                let _run_target_args'_v56704 = v56714 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v56718 : int32 = null |> unbox<int32>
                let _run_target_args'_v56704 = v56718 
                #endif
#if FABLE_COMPILER_PYTHON
                let v56722 : int32 = null |> unbox<int32>
                let _run_target_args'_v56704 = v56722 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v56726 : int32 = null |> unbox<int32>
                let _run_target_args'_v56704 = v56726 
                #endif
#else
                let v56729 : int32 = v0.ExitCode
                let _run_target_args'_v56704 = v56729 
                #endif
                let v56730 : int32 = _run_target_args'_v56704 
                return v56730 
                (* indent
                ()
            indent *)
            with ex ->
                let v57020 : exn = ex
                (* run_target_args'
                let v57025 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v57027 : string = $"%A{v57020}"
                let _run_target_args'_v57025 = v57027 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v57031 : string = $"%A{v57020}"
                let _run_target_args'_v57025 = v57031 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v57035 : string = $"%A{v57020}"
                let _run_target_args'_v57025 = v57035 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v57039 : string = $"%A{v57020}"
                let _run_target_args'_v57025 = v57039 
                #endif
#if FABLE_COMPILER_PYTHON
                let v57043 : string = $"%A{v57020}"
                let _run_target_args'_v57025 = v57043 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v57047 : string = $"%A{v57020}"
                let _run_target_args'_v57025 = v57047 
                #endif
#else
                let v57050 : string = $"{v57020.GetType ()}: {v57020.Message}"
                let _run_target_args'_v57025 = v57050 
                #endif
                let v57051 : string = _run_target_args'_v57025 
                (* run_target_args'
                let v57060 : unit = ()
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
                let v57061 : (string -> unit) = v1.Push
                v57061 v57051
                #endif
                // run_target_args' is_unit
                let v57063 : System.Threading.Tasks.TaskCanceledException = v57020 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v57126 : unit = ()
                let v57127 : (unit -> unit) = closure23(v57063)
                let v57128 : unit = (fun () -> v57127 (); v57126) ()
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
    let v68317 : Async<int32> = _let'_v45553 
    let _run_target_args'_v7 = v68317 
    #endif
#else
    let v68319 : unit = ()
    let _let'_v68319 =
        async {
            try
                (* run_target_args'
                let v79397 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v79399 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v79397 = v79399 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v79403 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v79397 = v79403 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v79407 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v79397 = v79407 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v79411 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v79397 = v79411 
                #endif
#if FABLE_COMPILER_PYTHON
                let v79415 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v79397 = v79415 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v79419 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v79397 = v79419 
                #endif
#else
                let v79422 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v79397 = v79422 
                #endif
                let v79423 : System.Threading.Tasks.Task = _run_target_args'_v79397 
                (* run_target_args'
                let v79436 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v79438 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v79436 = v79438 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v79442 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v79436 = v79442 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v79446 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v79436 = v79446 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v79449 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v79450 : Async<unit> = v79449 v79423
                let _run_target_args'_v79436 = v79450 
                #endif
#if FABLE_COMPILER_PYTHON
                let v79451 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v79452 : Async<unit> = v79451 v79423
                let _run_target_args'_v79436 = v79452 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v79453 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v79454 : Async<unit> = v79453 v79423
                let _run_target_args'_v79436 = v79454 
                #endif
#else
                let v79455 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v79456 : Async<unit> = v79455 v79423
                let _run_target_args'_v79436 = v79456 
                #endif
                let v79457 : Async<unit> = _run_target_args'_v79436 
                do! v79457 
                (* run_target_args'
                let v79470 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v79472 : int32 = null |> unbox<int32>
                let _run_target_args'_v79470 = v79472 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v79476 : int32 = null |> unbox<int32>
                let _run_target_args'_v79470 = v79476 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v79480 : int32 = null |> unbox<int32>
                let _run_target_args'_v79470 = v79480 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v79484 : int32 = null |> unbox<int32>
                let _run_target_args'_v79470 = v79484 
                #endif
#if FABLE_COMPILER_PYTHON
                let v79488 : int32 = null |> unbox<int32>
                let _run_target_args'_v79470 = v79488 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v79492 : int32 = null |> unbox<int32>
                let _run_target_args'_v79470 = v79492 
                #endif
#else
                let v79495 : int32 = v0.ExitCode
                let _run_target_args'_v79470 = v79495 
                #endif
                let v79496 : int32 = _run_target_args'_v79470 
                return v79496 
                (* indent
                ()
            indent *)
            with ex ->
                let v79786 : exn = ex
                (* run_target_args'
                let v79791 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v79793 : string = $"%A{v79786}"
                let _run_target_args'_v79791 = v79793 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v79797 : string = $"%A{v79786}"
                let _run_target_args'_v79791 = v79797 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v79801 : string = $"%A{v79786}"
                let _run_target_args'_v79791 = v79801 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v79805 : string = $"%A{v79786}"
                let _run_target_args'_v79791 = v79805 
                #endif
#if FABLE_COMPILER_PYTHON
                let v79809 : string = $"%A{v79786}"
                let _run_target_args'_v79791 = v79809 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v79813 : string = $"%A{v79786}"
                let _run_target_args'_v79791 = v79813 
                #endif
#else
                let v79816 : string = $"{v79786.GetType ()}: {v79786.Message}"
                let _run_target_args'_v79791 = v79816 
                #endif
                let v79817 : string = _run_target_args'_v79791 
                (* run_target_args'
                let v79826 : unit = ()
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
                let v79827 : (string -> unit) = v1.Push
                v79827 v79817
                #endif
                // run_target_args' is_unit
                let v79829 : System.Threading.Tasks.TaskCanceledException = v79786 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v79892 : unit = ()
                let v79893 : (unit -> unit) = closure23(v79829)
                let v79894 : unit = (fun () -> v79893 (); v79892) ()
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
    let v91083 : Async<int32> = _let'_v68319 
    let _run_target_args'_v7 = v91083 
    #endif
    let v91084 : Async<int32> = _run_target_args'_v7 
    v91084
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
    let v390 : string = $"{v380}"
    let v398 : unit = ()
    let v399 : (unit -> unit) = closure7(v18, v390)
    let v400 : unit = (fun () -> v399 (); v398) ()
    let v407 : string = $"{v98}"
    let v415 : unit = ()
    let v416 : (unit -> unit) = closure7(v18, v407)
    let v417 : unit = (fun () -> v416 (); v415) ()
    let v425 : string = "environment_variables"
    let v426 : string = $"{v425}"
    let v434 : unit = ()
    let v435 : (unit -> unit) = closure7(v18, v426)
    let v436 : unit = (fun () -> v435 (); v434) ()
    let v443 : string = $"{v59}"
    let v451 : unit = ()
    let v452 : (unit -> unit) = closure7(v18, v443)
    let v453 : unit = (fun () -> v452 (); v451) ()
    let v460 : string = $"%A{v12}"
    let v464 : string = $"{v460}"
    let v472 : unit = ()
    let v473 : (unit -> unit) = closure7(v18, v464)
    let v474 : unit = (fun () -> v473 (); v472) ()
    let v481 : string = $"{v98}"
    let v489 : unit = ()
    let v490 : (unit -> unit) = closure7(v18, v481)
    let v491 : unit = (fun () -> v490 (); v489) ()
    let v499 : string = "on_line"
    let v500 : string = $"{v499}"
    let v508 : unit = ()
    let v509 : (unit -> unit) = closure7(v18, v500)
    let v510 : unit = (fun () -> v509 (); v508) ()
    let v517 : string = $"{v59}"
    let v525 : unit = ()
    let v526 : (unit -> unit) = closure7(v18, v517)
    let v527 : unit = (fun () -> v526 (); v525) ()
    (* run_target_args'
    let v537 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v538 : string = "format!(\"{:#?}\", $0)"
    let v539 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v538 
    let v540 : string = "fable_library_rust::String_::fromString($0)"
    let v541 : string = Fable.Core.RustInterop.emitRustExpr v539 v540 
    let _run_target_args'_v537 = v541 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v542 : string = "format!(\"{:#?}\", $0)"
    let v543 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v542 
    let v544 : string = "fable_library_rust::String_::fromString($0)"
    let v545 : string = Fable.Core.RustInterop.emitRustExpr v543 v544 
    let _run_target_args'_v537 = v545 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v546 : string = "format!(\"{:#?}\", $0)"
    let v547 : std_string_String = Fable.Core.RustInterop.emitRustExpr v13 v546 
    let v548 : string = "fable_library_rust::String_::fromString($0)"
    let v549 : string = Fable.Core.RustInterop.emitRustExpr v547 v548 
    let _run_target_args'_v537 = v549 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v551 : string = $"%A{v13}"
    let _run_target_args'_v537 = v551 
    #endif
#if FABLE_COMPILER_PYTHON
    let v555 : string = $"%A{v13}"
    let _run_target_args'_v537 = v555 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v559 : string = $"%A{v13}"
    let _run_target_args'_v537 = v559 
    #endif
#else
    let v563 : string = $"%A{v13}"
    let _run_target_args'_v537 = v563 
    #endif
    let v566 : string = _run_target_args'_v537 
    let v576 : string = $"{v566}"
    let v584 : unit = ()
    let v585 : (unit -> unit) = closure7(v18, v576)
    let v586 : unit = (fun () -> v585 (); v584) ()
    let v593 : string = $"{v98}"
    let v601 : unit = ()
    let v602 : (unit -> unit) = closure7(v18, v593)
    let v603 : unit = (fun () -> v602 (); v601) ()
    let v611 : string = "stdin"
    let v612 : string = $"{v611}"
    let v620 : unit = ()
    let v621 : (unit -> unit) = closure7(v18, v612)
    let v622 : unit = (fun () -> v621 (); v620) ()
    let v629 : string = $"{v59}"
    let v637 : unit = ()
    let v638 : (unit -> unit) = closure7(v18, v629)
    let v639 : unit = (fun () -> v638 (); v637) ()
    (* run_target_args'
    let v649 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v650 : string = "format!(\"{:#?}\", $0)"
    let v651 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v650 
    let v652 : string = "fable_library_rust::String_::fromString($0)"
    let v653 : string = Fable.Core.RustInterop.emitRustExpr v651 v652 
    let _run_target_args'_v649 = v653 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v654 : string = "format!(\"{:#?}\", $0)"
    let v655 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v654 
    let v656 : string = "fable_library_rust::String_::fromString($0)"
    let v657 : string = Fable.Core.RustInterop.emitRustExpr v655 v656 
    let _run_target_args'_v649 = v657 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v658 : string = "format!(\"{:#?}\", $0)"
    let v659 : std_string_String = Fable.Core.RustInterop.emitRustExpr v14 v658 
    let v660 : string = "fable_library_rust::String_::fromString($0)"
    let v661 : string = Fable.Core.RustInterop.emitRustExpr v659 v660 
    let _run_target_args'_v649 = v661 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v663 : string = $"%A{v14}"
    let _run_target_args'_v649 = v663 
    #endif
#if FABLE_COMPILER_PYTHON
    let v667 : string = $"%A{v14}"
    let _run_target_args'_v649 = v667 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v671 : string = $"%A{v14}"
    let _run_target_args'_v649 = v671 
    #endif
#else
    let v675 : string = $"%A{v14}"
    let _run_target_args'_v649 = v675 
    #endif
    let v678 : string = _run_target_args'_v649 
    let v688 : string = $"{v678}"
    let v696 : unit = ()
    let v697 : (unit -> unit) = closure7(v18, v688)
    let v698 : unit = (fun () -> v697 (); v696) ()
    let v705 : string = $"{v98}"
    let v713 : unit = ()
    let v714 : (unit -> unit) = closure7(v18, v705)
    let v715 : unit = (fun () -> v714 (); v713) ()
    let v723 : string = "trace"
    let v724 : string = $"{v723}"
    let v732 : unit = ()
    let v733 : (unit -> unit) = closure7(v18, v724)
    let v734 : unit = (fun () -> v733 (); v732) ()
    let v741 : string = $"{v59}"
    let v749 : unit = ()
    let v750 : (unit -> unit) = closure7(v18, v741)
    let v751 : unit = (fun () -> v750 (); v749) ()
    let v759 : string =
        if v15 then
            let v757 : string = "true"
            v757
        else
            let v758 : string = "false"
            v758
    let v761 : string = $"{v759}"
    let v769 : unit = ()
    let v770 : (unit -> unit) = closure7(v18, v761)
    let v771 : unit = (fun () -> v770 (); v769) ()
    let v778 : string = $"{v98}"
    let v786 : unit = ()
    let v787 : (unit -> unit) = closure7(v18, v778)
    let v788 : unit = (fun () -> v787 (); v786) ()
    let v796 : string = "working_directory"
    let v797 : string = $"{v796}"
    let v805 : unit = ()
    let v806 : (unit -> unit) = closure7(v18, v797)
    let v807 : unit = (fun () -> v806 (); v805) ()
    let v814 : string = $"{v59}"
    let v822 : unit = ()
    let v823 : (unit -> unit) = closure7(v18, v814)
    let v824 : unit = (fun () -> v823 (); v822) ()
    (* run_target_args'
    let v834 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v835 : string = "format!(\"{:#?}\", $0)"
    let v836 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v835 
    let v837 : string = "fable_library_rust::String_::fromString($0)"
    let v838 : string = Fable.Core.RustInterop.emitRustExpr v836 v837 
    let _run_target_args'_v834 = v838 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v839 : string = "format!(\"{:#?}\", $0)"
    let v840 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v839 
    let v841 : string = "fable_library_rust::String_::fromString($0)"
    let v842 : string = Fable.Core.RustInterop.emitRustExpr v840 v841 
    let _run_target_args'_v834 = v842 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v843 : string = "format!(\"{:#?}\", $0)"
    let v844 : std_string_String = Fable.Core.RustInterop.emitRustExpr v16 v843 
    let v845 : string = "fable_library_rust::String_::fromString($0)"
    let v846 : string = Fable.Core.RustInterop.emitRustExpr v844 v845 
    let _run_target_args'_v834 = v846 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v848 : string = $"%A{v16}"
    let _run_target_args'_v834 = v848 
    #endif
#if FABLE_COMPILER_PYTHON
    let v852 : string = $"%A{v16}"
    let _run_target_args'_v834 = v852 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v856 : string = $"%A{v16}"
    let _run_target_args'_v834 = v856 
    #endif
#else
    let v860 : string = $"%A{v16}"
    let _run_target_args'_v834 = v860 
    #endif
    let v863 : string = _run_target_args'_v834 
    let v873 : string = $"{v863}"
    let v881 : unit = ()
    let v882 : (unit -> unit) = closure7(v18, v873)
    let v883 : unit = (fun () -> v882 (); v881) ()
    let v891 : string = " }"
    let v892 : string = $"{v891}"
    let v900 : unit = ()
    let v901 : (unit -> unit) = closure7(v18, v892)
    let v902 : unit = (fun () -> v901 (); v900) ()
    let v909 : string = $"{v891}"
    let v917 : unit = ()
    let v918 : (unit -> unit) = closure7(v18, v909)
    let v919 : unit = (fun () -> v918 (); v917) ()
    let v925 : string = v18.l0
    let v926 : int64 = v0.l0
    let v929 : string = " "
    let v930 : string = v6 + v929 
    let v934 : string = v930 + v7 
    let v939 : string = " #"
    let v940 : string = v934 + v939 
    let v944 : (int64 -> string) = _.ToString()
    let v945 : string = v944 v926
    let v949 : string = v940 + v945 
    let v953 : string = v949 + v929 
    let v958 : string = "runtime.execute_with_options_async"
    let v959 : string = v953 + v958 
    let v964 : string = " / "
    let v965 : string = v959 + v964 
    let v969 : string = v965 + v925 
    method16(v969)
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
            let v5938 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v5941 : int32, v5942 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5941, v5942) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v5949 : int32, v5950 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5949, v5950) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v5957 : int32, v5958 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5957, v5958) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v5965 : int32, v5966 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5965, v5966) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v5973 : int32, v5974 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5973, v5974) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v5981 : int32, v5982 : string) = null |> unbox<struct (int32 * string)>
            return struct (v5981, v5982) 
            #endif
#else
            let v5987 : US6 = method23(v0)
            let struct (v5999 : string, v6000 : US5) =
                match v5987 with
                | US6_1(v5990) -> (* Error *)
                    let v5992 : string = $"resultm.get / Result value was Error: {v5990}"
                    failwith<struct (string * US5)> v5992
                | US6_0(v5988, v5989) -> (* Ok *)
                    struct (v5988, v5989)
            let v6003 : (string -> US5) = method5()
            let v6004 : US5 option = v6 |> Option.map v6003 
            let v6024 : US5 = US5_1
            let v6025 : US5 = v6004 |> Option.defaultValue v6024 
            let v6032 : string =
                match v6025 with
                | US5_1 -> (* None *)
                    let v6030 : string = ""
                    v6030
                | US5_0(v6029) -> (* Some *)
                    v6029
            let v6093 : unit = ()
            let v6094 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v6000, v5999)
            let v6095 : unit = (fun () -> v6094 (); v6093) ()
            let v6156 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v6160 : string =
                match v6000 with
                | US5_1 -> (* None *)
                    let v6158 : string = ""
                    v6158
                | US5_0(v6157) -> (* Some *)
                    v6157
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v6160,
              StandardOutputEncoding = v6156,
              WorkingDirectory = v6032,
              FileName = v5999,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v6161 : System.Diagnostics.ProcessStartInfo = start_info
            let v6162 : (struct (string * string) []) = method38(v0, v1, v2, v3, v4, v5, v6)
            let v6163 : int32 = v6162.Length
            let v6164 : Mut5 = {l0 = 0} : Mut5
            while method39(v6163, v6164) do
                let v6166 : int32 = v6164.l0
                let struct (v6167 : string, v6168 : string) = v6162.[int v6166]
                v6161.EnvironmentVariables.[v6167] <- v6168 
                let v6169 : int32 = v6166 + 1
                v6164.l0 <- v6169
                ()
            let v6170 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v6161)
            use v6170 = v6170 
            let v6171 : System.Diagnostics.Process = v6170 
            let v6172 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v6173 : System.Collections.Concurrent.ConcurrentStack<string> = v6172 ()
            let v6174 : bool = false
            let v6175 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v6171, v6173, v6174)
            v6171.OutputDataReceived.Add v6175 
            let v6176 : bool = true
            let v6177 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v6171, v6173, v6176)
            v6171.ErrorDataReceived.Add v6177 
            let v6178 : (unit -> bool) = v6171.Start
            let v6179 : bool = v6178 ()
            let v6180 : bool = v6179 = false
            if v6180 then
                let v6181 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v6181
            let v6182 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v6182 v6171
            let v6183 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v6183 v6171
            let v6186 : (System.Threading.CancellationToken -> US15) = method47()
            let v6187 : US15 option = v1 |> Option.map v6186 
            let v6207 : US15 = US15_1
            let v6208 : US15 = v6187 |> Option.defaultValue v6207 
            let v6215 : System.Threading.CancellationToken =
                match v6208 with
                | US15_1 -> (* None *)
                    let v6213 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v6213
                | US15_0(v6212) -> (* Some *)
                    v6212
            let v6216 : Async<System.Threading.CancellationToken> = method48(v6215)
            let! v6216 = v6216 
            let v6217 : System.Threading.CancellationToken = v6216 
            let v6218 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v6217.Register
            let v6219 : (unit -> unit) = closure22(v6171)
            let v6220 : System.Threading.CancellationTokenRegistration = v6218 v6219
            use v6220 = v6220 
            let v6221 : System.Threading.CancellationTokenRegistration = v6220 
            let v6222 : Async<int32> = method51(v6171, v6173, v6217)
            let! v6222 = v6222 
            let v6223 : int32 = v6222 
            let v6225 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v6226 : string seq = v6225 v6173
            let v6230 : (string seq -> string seq) = Seq.rev
            let v6231 : string seq = v6230 v6226
            let v6236 : string = method53()
            let v6237 : (string -> (string seq -> string)) = String.concat
            let v6238 : (string seq -> string) = v6237 v6236
            let v6239 : string = v6238 v6231
            let v6304 : unit = ()
            let v6305 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v6223, v6239)
            let v6306 : unit = (fun () -> v6305 (); v6304) ()
            return struct (v6223, v6239) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v12286 : Async<struct (int32 * string)> = _let'_v25 
    let _run_target_args'_v11 = v12286 
    #endif
#if FABLE_COMPILER_PYTHON
    let v12288 : unit = ()
    let _let'_v12288 =
        async {
            (* run_target_args'
            let v18201 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v18204 : int32, v18205 : string) = null |> unbox<struct (int32 * string)>
            return struct (v18204, v18205) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v18212 : int32, v18213 : string) = null |> unbox<struct (int32 * string)>
            return struct (v18212, v18213) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v18220 : int32, v18221 : string) = null |> unbox<struct (int32 * string)>
            return struct (v18220, v18221) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v18228 : int32, v18229 : string) = null |> unbox<struct (int32 * string)>
            return struct (v18228, v18229) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v18236 : int32, v18237 : string) = null |> unbox<struct (int32 * string)>
            return struct (v18236, v18237) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v18244 : int32, v18245 : string) = null |> unbox<struct (int32 * string)>
            return struct (v18244, v18245) 
            #endif
#else
            let v18250 : US6 = method23(v0)
            let struct (v18262 : string, v18263 : US5) =
                match v18250 with
                | US6_1(v18253) -> (* Error *)
                    let v18255 : string = $"resultm.get / Result value was Error: {v18253}"
                    failwith<struct (string * US5)> v18255
                | US6_0(v18251, v18252) -> (* Ok *)
                    struct (v18251, v18252)
            let v18266 : (string -> US5) = method5()
            let v18267 : US5 option = v6 |> Option.map v18266 
            let v18287 : US5 = US5_1
            let v18288 : US5 = v18267 |> Option.defaultValue v18287 
            let v18295 : string =
                match v18288 with
                | US5_1 -> (* None *)
                    let v18293 : string = ""
                    v18293
                | US5_0(v18292) -> (* Some *)
                    v18292
            let v18356 : unit = ()
            let v18357 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v18263, v18262)
            let v18358 : unit = (fun () -> v18357 (); v18356) ()
            let v18419 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v18423 : string =
                match v18263 with
                | US5_1 -> (* None *)
                    let v18421 : string = ""
                    v18421
                | US5_0(v18420) -> (* Some *)
                    v18420
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v18423,
              StandardOutputEncoding = v18419,
              WorkingDirectory = v18295,
              FileName = v18262,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v18424 : System.Diagnostics.ProcessStartInfo = start_info
            let v18425 : (struct (string * string) []) = method38(v0, v1, v2, v3, v4, v5, v6)
            let v18426 : int32 = v18425.Length
            let v18427 : Mut5 = {l0 = 0} : Mut5
            while method39(v18426, v18427) do
                let v18429 : int32 = v18427.l0
                let struct (v18430 : string, v18431 : string) = v18425.[int v18429]
                v18424.EnvironmentVariables.[v18430] <- v18431 
                let v18432 : int32 = v18429 + 1
                v18427.l0 <- v18432
                ()
            let v18433 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v18424)
            use v18433 = v18433 
            let v18434 : System.Diagnostics.Process = v18433 
            let v18435 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v18436 : System.Collections.Concurrent.ConcurrentStack<string> = v18435 ()
            let v18437 : bool = false
            let v18438 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v18434, v18436, v18437)
            v18434.OutputDataReceived.Add v18438 
            let v18439 : bool = true
            let v18440 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v18434, v18436, v18439)
            v18434.ErrorDataReceived.Add v18440 
            let v18441 : (unit -> bool) = v18434.Start
            let v18442 : bool = v18441 ()
            let v18443 : bool = v18442 = false
            if v18443 then
                let v18444 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v18444
            let v18445 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v18445 v18434
            let v18446 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v18446 v18434
            let v18449 : (System.Threading.CancellationToken -> US15) = method47()
            let v18450 : US15 option = v1 |> Option.map v18449 
            let v18470 : US15 = US15_1
            let v18471 : US15 = v18450 |> Option.defaultValue v18470 
            let v18478 : System.Threading.CancellationToken =
                match v18471 with
                | US15_1 -> (* None *)
                    let v18476 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v18476
                | US15_0(v18475) -> (* Some *)
                    v18475
            let v18479 : Async<System.Threading.CancellationToken> = method48(v18478)
            let! v18479 = v18479 
            let v18480 : System.Threading.CancellationToken = v18479 
            let v18481 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v18480.Register
            let v18482 : (unit -> unit) = closure22(v18434)
            let v18483 : System.Threading.CancellationTokenRegistration = v18481 v18482
            use v18483 = v18483 
            let v18484 : System.Threading.CancellationTokenRegistration = v18483 
            let v18485 : Async<int32> = method51(v18434, v18436, v18480)
            let! v18485 = v18485 
            let v18486 : int32 = v18485 
            let v18488 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v18489 : string seq = v18488 v18436
            let v18493 : (string seq -> string seq) = Seq.rev
            let v18494 : string seq = v18493 v18489
            let v18499 : string = method53()
            let v18500 : (string -> (string seq -> string)) = String.concat
            let v18501 : (string seq -> string) = v18500 v18499
            let v18502 : string = v18501 v18494
            let v18567 : unit = ()
            let v18568 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v18486, v18502)
            let v18569 : unit = (fun () -> v18568 (); v18567) ()
            return struct (v18486, v18502) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v24549 : Async<struct (int32 * string)> = _let'_v12288 
    let _run_target_args'_v11 = v24549 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24551 : unit = ()
    let _let'_v24551 =
        async {
            (* run_target_args'
            let v30464 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v30467 : int32, v30468 : string) = null |> unbox<struct (int32 * string)>
            return struct (v30467, v30468) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v30475 : int32, v30476 : string) = null |> unbox<struct (int32 * string)>
            return struct (v30475, v30476) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v30483 : int32, v30484 : string) = null |> unbox<struct (int32 * string)>
            return struct (v30483, v30484) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v30491 : int32, v30492 : string) = null |> unbox<struct (int32 * string)>
            return struct (v30491, v30492) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v30499 : int32, v30500 : string) = null |> unbox<struct (int32 * string)>
            return struct (v30499, v30500) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v30507 : int32, v30508 : string) = null |> unbox<struct (int32 * string)>
            return struct (v30507, v30508) 
            #endif
#else
            let v30513 : US6 = method23(v0)
            let struct (v30525 : string, v30526 : US5) =
                match v30513 with
                | US6_1(v30516) -> (* Error *)
                    let v30518 : string = $"resultm.get / Result value was Error: {v30516}"
                    failwith<struct (string * US5)> v30518
                | US6_0(v30514, v30515) -> (* Ok *)
                    struct (v30514, v30515)
            let v30529 : (string -> US5) = method5()
            let v30530 : US5 option = v6 |> Option.map v30529 
            let v30550 : US5 = US5_1
            let v30551 : US5 = v30530 |> Option.defaultValue v30550 
            let v30558 : string =
                match v30551 with
                | US5_1 -> (* None *)
                    let v30556 : string = ""
                    v30556
                | US5_0(v30555) -> (* Some *)
                    v30555
            let v30619 : unit = ()
            let v30620 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v30526, v30525)
            let v30621 : unit = (fun () -> v30620 (); v30619) ()
            let v30682 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v30686 : string =
                match v30526 with
                | US5_1 -> (* None *)
                    let v30684 : string = ""
                    v30684
                | US5_0(v30683) -> (* Some *)
                    v30683
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v30686,
              StandardOutputEncoding = v30682,
              WorkingDirectory = v30558,
              FileName = v30525,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v30687 : System.Diagnostics.ProcessStartInfo = start_info
            let v30688 : (struct (string * string) []) = method38(v0, v1, v2, v3, v4, v5, v6)
            let v30689 : int32 = v30688.Length
            let v30690 : Mut5 = {l0 = 0} : Mut5
            while method39(v30689, v30690) do
                let v30692 : int32 = v30690.l0
                let struct (v30693 : string, v30694 : string) = v30688.[int v30692]
                v30687.EnvironmentVariables.[v30693] <- v30694 
                let v30695 : int32 = v30692 + 1
                v30690.l0 <- v30695
                ()
            let v30696 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v30687)
            use v30696 = v30696 
            let v30697 : System.Diagnostics.Process = v30696 
            let v30698 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v30699 : System.Collections.Concurrent.ConcurrentStack<string> = v30698 ()
            let v30700 : bool = false
            let v30701 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v30697, v30699, v30700)
            v30697.OutputDataReceived.Add v30701 
            let v30702 : bool = true
            let v30703 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v30697, v30699, v30702)
            v30697.ErrorDataReceived.Add v30703 
            let v30704 : (unit -> bool) = v30697.Start
            let v30705 : bool = v30704 ()
            let v30706 : bool = v30705 = false
            if v30706 then
                let v30707 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v30707
            let v30708 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v30708 v30697
            let v30709 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v30709 v30697
            let v30712 : (System.Threading.CancellationToken -> US15) = method47()
            let v30713 : US15 option = v1 |> Option.map v30712 
            let v30733 : US15 = US15_1
            let v30734 : US15 = v30713 |> Option.defaultValue v30733 
            let v30741 : System.Threading.CancellationToken =
                match v30734 with
                | US15_1 -> (* None *)
                    let v30739 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v30739
                | US15_0(v30738) -> (* Some *)
                    v30738
            let v30742 : Async<System.Threading.CancellationToken> = method48(v30741)
            let! v30742 = v30742 
            let v30743 : System.Threading.CancellationToken = v30742 
            let v30744 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v30743.Register
            let v30745 : (unit -> unit) = closure22(v30697)
            let v30746 : System.Threading.CancellationTokenRegistration = v30744 v30745
            use v30746 = v30746 
            let v30747 : System.Threading.CancellationTokenRegistration = v30746 
            let v30748 : Async<int32> = method51(v30697, v30699, v30743)
            let! v30748 = v30748 
            let v30749 : int32 = v30748 
            let v30751 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v30752 : string seq = v30751 v30699
            let v30756 : (string seq -> string seq) = Seq.rev
            let v30757 : string seq = v30756 v30752
            let v30762 : string = method53()
            let v30763 : (string -> (string seq -> string)) = String.concat
            let v30764 : (string seq -> string) = v30763 v30762
            let v30765 : string = v30764 v30757
            let v30830 : unit = ()
            let v30831 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v30749, v30765)
            let v30832 : unit = (fun () -> v30831 (); v30830) ()
            return struct (v30749, v30765) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v36812 : Async<struct (int32 * string)> = _let'_v24551 
    let _run_target_args'_v11 = v36812 
    #endif
#else
    let v36814 : unit = ()
    let _let'_v36814 =
        async {
            (* run_target_args'
            let v42727 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v42730 : int32, v42731 : string) = null |> unbox<struct (int32 * string)>
            return struct (v42730, v42731) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v42738 : int32, v42739 : string) = null |> unbox<struct (int32 * string)>
            return struct (v42738, v42739) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v42746 : int32, v42747 : string) = null |> unbox<struct (int32 * string)>
            return struct (v42746, v42747) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v42754 : int32, v42755 : string) = null |> unbox<struct (int32 * string)>
            return struct (v42754, v42755) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v42762 : int32, v42763 : string) = null |> unbox<struct (int32 * string)>
            return struct (v42762, v42763) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v42770 : int32, v42771 : string) = null |> unbox<struct (int32 * string)>
            return struct (v42770, v42771) 
            #endif
#else
            let v42776 : US6 = method23(v0)
            let struct (v42788 : string, v42789 : US5) =
                match v42776 with
                | US6_1(v42779) -> (* Error *)
                    let v42781 : string = $"resultm.get / Result value was Error: {v42779}"
                    failwith<struct (string * US5)> v42781
                | US6_0(v42777, v42778) -> (* Ok *)
                    struct (v42777, v42778)
            let v42792 : (string -> US5) = method5()
            let v42793 : US5 option = v6 |> Option.map v42792 
            let v42813 : US5 = US5_1
            let v42814 : US5 = v42793 |> Option.defaultValue v42813 
            let v42821 : string =
                match v42814 with
                | US5_1 -> (* None *)
                    let v42819 : string = ""
                    v42819
                | US5_0(v42818) -> (* Some *)
                    v42818
            let v42882 : unit = ()
            let v42883 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v42789, v42788)
            let v42884 : unit = (fun () -> v42883 (); v42882) ()
            let v42945 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v42949 : string =
                match v42789 with
                | US5_1 -> (* None *)
                    let v42947 : string = ""
                    v42947
                | US5_0(v42946) -> (* Some *)
                    v42946
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v42949,
              StandardOutputEncoding = v42945,
              WorkingDirectory = v42821,
              FileName = v42788,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v42950 : System.Diagnostics.ProcessStartInfo = start_info
            let v42951 : (struct (string * string) []) = method38(v0, v1, v2, v3, v4, v5, v6)
            let v42952 : int32 = v42951.Length
            let v42953 : Mut5 = {l0 = 0} : Mut5
            while method39(v42952, v42953) do
                let v42955 : int32 = v42953.l0
                let struct (v42956 : string, v42957 : string) = v42951.[int v42955]
                v42950.EnvironmentVariables.[v42956] <- v42957 
                let v42958 : int32 = v42955 + 1
                v42953.l0 <- v42958
                ()
            let v42959 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v42950)
            use v42959 = v42959 
            let v42960 : System.Diagnostics.Process = v42959 
            let v42961 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v42962 : System.Collections.Concurrent.ConcurrentStack<string> = v42961 ()
            let v42963 : bool = false
            let v42964 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v42960, v42962, v42963)
            v42960.OutputDataReceived.Add v42964 
            let v42965 : bool = true
            let v42966 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v42960, v42962, v42965)
            v42960.ErrorDataReceived.Add v42966 
            let v42967 : (unit -> bool) = v42960.Start
            let v42968 : bool = v42967 ()
            let v42969 : bool = v42968 = false
            if v42969 then
                let v42970 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v42970
            let v42971 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v42971 v42960
            let v42972 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v42972 v42960
            let v42975 : (System.Threading.CancellationToken -> US15) = method47()
            let v42976 : US15 option = v1 |> Option.map v42975 
            let v42996 : US15 = US15_1
            let v42997 : US15 = v42976 |> Option.defaultValue v42996 
            let v43004 : System.Threading.CancellationToken =
                match v42997 with
                | US15_1 -> (* None *)
                    let v43002 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v43002
                | US15_0(v43001) -> (* Some *)
                    v43001
            let v43005 : Async<System.Threading.CancellationToken> = method48(v43004)
            let! v43005 = v43005 
            let v43006 : System.Threading.CancellationToken = v43005 
            let v43007 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v43006.Register
            let v43008 : (unit -> unit) = closure22(v42960)
            let v43009 : System.Threading.CancellationTokenRegistration = v43007 v43008
            use v43009 = v43009 
            let v43010 : System.Threading.CancellationTokenRegistration = v43009 
            let v43011 : Async<int32> = method51(v42960, v42962, v43006)
            let! v43011 = v43011 
            let v43012 : int32 = v43011 
            let v43014 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v43015 : string seq = v43014 v42962
            let v43019 : (string seq -> string seq) = Seq.rev
            let v43020 : string seq = v43019 v43015
            let v43025 : string = method53()
            let v43026 : (string -> (string seq -> string)) = String.concat
            let v43027 : (string seq -> string) = v43026 v43025
            let v43028 : string = v43027 v43020
            let v43093 : unit = ()
            let v43094 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v43012, v43028)
            let v43095 : unit = (fun () -> v43094 (); v43093) ()
            return struct (v43012, v43028) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v49075 : Async<struct (int32 * string)> = _let'_v36814 
    let _run_target_args'_v11 = v49075 
    #endif
    let v49076 : Async<struct (int32 * string)> = _run_target_args'_v11 
    v49076
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
